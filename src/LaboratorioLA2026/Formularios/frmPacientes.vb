Imports MySqlConnector

Public Class frmPacientes
    Public DniInicial As String = ""
    Public RegresarAOrden As Boolean = False
    Public PacienteRegistradoId As Integer = 0
    Private idPacienteSelec As Integer = 0
    Private cargandoGrilla As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Me.IsDisposed Then Return False
        If Not Sesion.Puede("CONSULTAR_PACIENTES") Then
            Me.Close()
            Return False
        End If
        Dim editar As Boolean = Sesion.Puede("REGISTRAR_PACIENTES")
        txtIdPaciente.Enabled = True
        txtIdPaciente.ReadOnly = True
        txtIdPaciente.TabStop = False
        txtIdPaciente.BackColor = SystemColors.Control
        txtIdPaciente.ForeColor = SystemColors.ControlDarkDark
        For Each campo As TextBox In {txtDni, txtNombre, txtApellido, txtTelefono, txtEmail}
            campo.Enabled = True
            campo.ReadOnly = Not editar
        Next
        dtpFechaNacimiento.Enabled = editar
        dtpFechaNacimiento.TabStop = editar
        dgvPacientes.Enabled = True
        txtFiltro.Enabled = True
        btnBuscar.Enabled = True
        btnVerTodos.Enabled = True
        btnLimpiar.Enabled = True
        btnGuardar.Enabled = editar AndAlso idPacienteSelec = 0
        btnModificar.Enabled = Sesion.Puede("MODIFICAR_PACIENTES") AndAlso idPacienteSelec > 0
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
        btnGuardar.Visible = Sesion.Puede("REGISTRAR_PACIENTES")
        btnModificar.Visible = Sesion.Puede("MODIFICAR_PACIENTES")
        Dim modo As String = "Solo consulta de pacientes"
        If editar Then modo = "Consulta, registro y modificación de pacientes"
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, modo)
        Return True
    End Function

    Private Sub frmPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaNacimiento.MaxDate = Date.Today
        dtpFechaNacimiento.Value = Date.Today
        dtpFechaNacimiento.Checked = False
        MostrarFechaNacimiento()
        If Not AplicarPermisos() Then Exit Sub
        CargarGrilla()
        If RegresarAOrden Then
            LimpiarForm()
            txtDni.Text = DniInicial
            txtNombre.Focus()
            lblPendiente.Text = "Registrá el paciente. Al guardar regresarás a la orden, sin duplicar DNI."
        End If
    End Sub

    Private Sub frmPacientes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        AplicarPermisos()
    End Sub

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("CONSULTAR_PACIENTES") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT id_paciente,dni,nombre,apellido,fecha_nacimiento,telefono,email " &
                    "FROM pacientes WHERE dni LIKE @filtro OR nombre LIKE @filtro OR apellido LIKE @filtro " &
                    "ORDER BY apellido,nombre,id_paciente;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    'cargo la tabla y dejo la seleccion vacia
                    cargandoGrilla = True
                    dgvPacientes.DataSource = tabla
                    dgvPacientes.Columns("id_paciente").HeaderText = "ID"
                    dgvPacientes.Columns("dni").HeaderText = "DNI"
                    dgvPacientes.Columns("nombre").HeaderText = "Nombre"
                    dgvPacientes.Columns("apellido").HeaderText = "Apellido"
                    dgvPacientes.Columns("fecha_nacimiento").HeaderText = "Nacimiento"
                    dgvPacientes.Columns("fecha_nacimiento").DefaultCellStyle.Format = "dd/MM/yyyy"
                    dgvPacientes.Columns("telefono").HeaderText = "Teléfono"
                    dgvPacientes.Columns("email").HeaderText = "Email"
                    LimpiarForm()
                    lblPendiente.Text = "Pacientes encontrados: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los pacientes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron consultar los pacientes. Revisá la conexión."
            Return False
        Finally
            cargandoGrilla = False
            CADENA = ""
        End Try
    End Function

    Public Sub LimpiarForm()
        'limpio tambien la clave para no modificar otro registro por error
        idPacienteSelec = 0
        txtIdPaciente.Clear()
        txtDni.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        dtpFechaNacimiento.Value = Date.Today
        dtpFechaNacimiento.Checked = False
        MostrarFechaNacimiento()
        txtTelefono.Clear()
        txtEmail.Clear()
        dgvPacientes.ClearSelection()
        AplicarPermisos()
    End Sub

    Private Sub dgvPacientes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPacientes.SelectionChanged
        If cargandoGrilla OrElse Not Sesion.Puede("CONSULTAR_PACIENTES") Then Exit Sub
        If dgvPacientes.SelectedRows.Count <> 1 Then Exit Sub
        Try
            Dim fila = dgvPacientes.SelectedRows(0)
            If fila.IsNewRow Then Exit Sub
            txtDni.Text = fila.Cells("dni").Value.ToString()
            txtNombre.Text = fila.Cells("nombre").Value.ToString()
            txtApellido.Text = fila.Cells("apellido").Value.ToString()
            txtTelefono.Text = fila.Cells("telefono").Value.ToString()
            txtEmail.Text = fila.Cells("email").Value.ToString()
            If IsDBNull(fila.Cells("fecha_nacimiento").Value) Then
                dtpFechaNacimiento.Value = Date.Today
                dtpFechaNacimiento.Checked = False
            Else
                Dim fecha As Date = CDate(fila.Cells("fecha_nacimiento").Value).Date
                If fecha < dtpFechaNacimiento.MinDate OrElse fecha > dtpFechaNacimiento.MaxDate Then
                    LimpiarForm()
                    lblPendiente.Text = "La fecha guardada está fuera del rango del selector. No se modificó el paciente."
                    Exit Sub
                End If
                dtpFechaNacimiento.Value = fecha
                dtpFechaNacimiento.Checked = True
            End If
            MostrarFechaNacimiento()
            idPacienteSelec = CInt(fila.Cells("id_paciente").Value)
            txtIdPaciente.Text = idPacienteSelec.ToString()
            AplicarPermisos()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los pacientes. Revisá los datos y volvé a intentar.", ex)
            LimpiarForm()
            lblPendiente.Text = "No se pudieron mostrar los datos seleccionados."
        End Try
    End Sub

    Private Sub MostrarFechaNacimiento()
        'sin marcar la casilla no se guarda ninguna fecha
        If dtpFechaNacimiento.Checked Then
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy"
        Else
            dtpFechaNacimiento.CustomFormat = " "
        End If
    End Sub

    Private Sub dtpFechaNacimiento_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaNacimiento.ValueChanged
        MostrarFechaNacimiento()
    End Sub

    Private Sub dtpFechaNacimiento_MouseUp(sender As Object, e As MouseEventArgs) Handles dtpFechaNacimiento.MouseUp
        MostrarFechaNacimiento()
    End Sub

    Private Sub dtpFechaNacimiento_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpFechaNacimiento.KeyUp
        MostrarFechaNacimiento()
    End Sub

    Public Function ValidarCampos(ByRef nacimiento As Object) As Boolean
        MostrarFechaNacimiento()
        nacimiento = DBNull.Value
        If txtDni.Text.Trim() = "" OrElse txtNombre.Text.Trim() = "" OrElse txtApellido.Text.Trim() = "" Then
            lblPendiente.Text = "Completá DNI, nombre y apellido."
            Return False
        End If
        If txtDni.Text.Trim().Length > 20 OrElse txtNombre.Text.Trim().Length > 100 OrElse
            txtApellido.Text.Trim().Length > 100 OrElse txtTelefono.Text.Trim().Length > 30 OrElse txtEmail.Text.Trim().Length > 100 Then
            lblPendiente.Text = "Algún campo supera el tamaño permitido."
            Return False
        End If
        'el DNI se guarda como texto, sin puntos ni espacios internos
        For Each caracter As Char In txtDni.Text.Trim()
            If caracter < "0"c OrElse caracter > "9"c Then
                lblPendiente.Text = "Ingresá el DNI solo con números, sin puntos ni espacios."
                Return False
            End If
        Next
        If dtpFechaNacimiento.Checked Then
            If dtpFechaNacimiento.Value.Date > Date.Today Then
                lblPendiente.Text = "La fecha de nacimiento no puede ser futura."
                Return False
            End If
            nacimiento = dtpFechaNacimiento.Value.Date
        End If
        Return True
    End Function

    Private Function DniDuplicado(cn As MySqlConnection, idExcluir As Integer) As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM pacientes WHERE dni=@dni AND id_paciente<>@id;"
        Using cmd As New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@dni", txtDni.Text.Trim())
            cmd.Parameters.AddWithValue("@id", idExcluir)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Sub GuardarPaciente(modificar As Boolean)
        'el permiso se comprueba tambien aqui, antes de abrir la conexion
        Dim permiso As String = "REGISTRAR_PACIENTES"
        If modificar Then permiso = "MODIFICAR_PACIENTES"
        If Not Sesion.Puede(permiso) Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        If modificar AndAlso idPacienteSelec = 0 Then
            lblPendiente.Text = "Seleccioná un paciente para modificar."
            Exit Sub
        End If
        If Not modificar AndAlso idPacienteSelec <> 0 Then
            lblPendiente.Text = "Pulsá Limpiar para registrar otro paciente."
            Exit Sub
        End If
        Dim nacimiento As Object = DBNull.Value
        If Not ValidarCampos(nacimiento) Then Exit Sub
        If modificar AndAlso Not PresentacionSesion.Confirmar("¿Confirmás los cambios del paciente seleccionado?") Then
            lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim idExcluir As Integer = 0
                If modificar Then idExcluir = idPacienteSelec
                If DniDuplicado(cn, idExcluir) Then
                    lblPendiente.Text = "El DNI ya está registrado en otro paciente."
                    Exit Sub
                End If
                Dim sql As String
                If modificar Then
                    sql = "UPDATE pacientes SET dni=@dni,nombre=@nombre,apellido=@apellido," &
                        "fecha_nacimiento=@nacimiento,telefono=@telefono,email=@email WHERE id_paciente=@id;"
                Else
                    sql = "INSERT INTO pacientes (dni,nombre,apellido,fecha_nacimiento,telefono,email) " &
                        "VALUES (@dni,@nombre,@apellido,@nacimiento,@telefono,@email);"
                End If
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@dni", txtDni.Text.Trim())
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim())
                    cmd.Parameters.AddWithValue("@nacimiento", nacimiento)
                    cmd.Parameters.AddWithValue("@telefono", If(txtTelefono.Text.Trim() = "", DBNull.Value, CObj(txtTelefono.Text.Trim())))
                    cmd.Parameters.AddWithValue("@email", If(txtEmail.Text.Trim() = "", DBNull.Value, CObj(txtEmail.Text.Trim())))
                    If modificar Then cmd.Parameters.AddWithValue("@id", idPacienteSelec)
                    If cmd.ExecuteNonQuery() <> 1 Then
                        lblPendiente.Text = "No se encontró el paciente para actualizar. Recargá el listado."
                        Exit Sub
                    End If
                    If Not modificar Then PacienteRegistradoId = CInt(cmd.LastInsertedId)
                End Using
            End Using
            If RegresarAOrden AndAlso Not modificar Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Exit Sub
            End If
            'la escritura ya termino; recargo sin confundir un error de lectura con el guardado
            LimpiarForm()
            If CargarGrilla(txtFiltro.Text) Then
                lblPendiente.Text = If(modificar, "Paciente modificado correctamente.", "Paciente registrado correctamente.")
            Else
                lblPendiente.Text = "El paciente se guardó, pero no se pudo recargar el listado. Pulsá Ver todos."
            End If
        Catch ex As MySqlException
            PresentacionSesion.MostrarError("No se pudo completar el guardado de los pacientes. Revisá los datos y volvé a intentar.", ex)
            If ex.Number = 1062 Then
                lblPendiente.Text = "El DNI ya está registrado en otro paciente."
            Else
                lblPendiente.Text = "No se pudo confirmar el guardado. Revisá el listado y la conexión antes de reintentar."
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de los pacientes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo confirmar el guardado. Revisá el listado antes de reintentar."
        Finally
            CADENA = ""
            AplicarPermisos()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarPaciente(False)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        GuardarPaciente(True)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        If txtFiltro.Text = "" Then
            CargarGrilla()
        Else
            txtFiltro.Clear()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If Not Sesion.Puede("CONSULTAR_PACIENTES") Then Exit Sub
        LimpiarForm()
        lblPendiente.Text = "Campos vacíos. El filtro de búsqueda se conserva."
        txtDni.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        'no hay DELETE en esta etapa, aunque el rol sea ADMIN
        lblPendiente.Text = "La eliminación física no está habilitada: se conservan pacientes y sus relaciones."
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub frmPacientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub
End Class

