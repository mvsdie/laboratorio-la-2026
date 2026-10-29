Imports MySqlConnector

Public Class frmCentros
    Private idSelec As Integer = 0
    Private cargandoGrilla As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            Me.Close()
            Return False
        End If
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Administración de centros externos; activar o desactivar sin eliminar")
        txtIdCentro.Enabled = True
        txtIdCentro.ReadOnly = True
        txtNombre.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
        txtEmail.Enabled = True
        cboUso.Enabled = True
        chkActivo.Enabled = True
        dgvCentros.Enabled = True
        btnGuardar.Visible = True
        btnModificar.Visible = True
        btnGuardar.Enabled = idSelec = 0
        btnModificar.Enabled = idSelec > 0
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
        Return True
    End Function

    Private Sub frmCentros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AplicarPermisos() Then Exit Sub
        cboUso.Items.Clear()
        cboUso.Items.AddRange(New Object() {"ORIGEN", "DESTINO", "AMBOS"})
        LimpiarForm()
        CargarGrilla()
    End Sub

    Private Sub frmCentros_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        AplicarPermisos()
    End Sub

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT id_centro,nombre,direccion,telefono,email,activo,uso FROM centros_derivantes " &
                    "WHERE nombre LIKE @filtro ORDER BY nombre,id_centro;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cargandoGrilla = True
                    dgvCentros.DataSource = tabla
                    dgvCentros.Columns("id_centro").HeaderText = "ID"
                    dgvCentros.Columns("nombre").HeaderText = "Nombre"
                    dgvCentros.Columns("direccion").HeaderText = "Dirección"
                    dgvCentros.Columns("telefono").HeaderText = "Teléfono"
                    dgvCentros.Columns("email").HeaderText = "Email"
                    dgvCentros.Columns("activo").HeaderText = "Activo"
                    dgvCentros.Columns("uso").HeaderText = "Uso"
                    LimpiarForm()
                    lblPendiente.Text = "Registros encontrados: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los centros. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo cargar el catálogo. Revisá la conexión."
            Return False
        Finally
            cargandoGrilla = False
            CADENA = ""
        End Try
    End Function

    Public Sub LimpiarForm()
        idSelec = 0
        txtIdCentro.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtEmail.Clear()
        cboUso.SelectedIndex = -1
        chkActivo.Checked = True
        dgvCentros.ClearSelection()
        AplicarPermisos()
    End Sub

    Private Sub dgvCentros_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCentros.SelectionChanged
        If cargandoGrilla OrElse Not Sesion.Puede("ADMIN_CATALOGOS") Then Exit Sub
        If dgvCentros.SelectedRows.Count <> 1 Then Exit Sub
        Try
            Dim fila = dgvCentros.SelectedRows(0)
            If fila.IsNewRow Then Exit Sub
            txtNombre.Text = fila.Cells("nombre").Value.ToString()
            txtDireccion.Text = fila.Cells("direccion").Value.ToString()
            txtTelefono.Text = fila.Cells("telefono").Value.ToString()
            txtEmail.Text = fila.Cells("email").Value.ToString()
            cboUso.SelectedItem = fila.Cells("uso").Value.ToString()
            chkActivo.Checked = CBool(fila.Cells("activo").Value)
            idSelec = CInt(fila.Cells("id_centro").Value)
            txtIdCentro.Text = idSelec.ToString()
            AplicarPermisos()
            lblPendiente.Text = "Registro seleccionado. Modificar guarda los datos y el estado Activo."
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los centros. Revisá los datos y volvé a intentar.", ex)
            LimpiarForm()
            lblPendiente.Text = "No se pudieron mostrar los datos seleccionados."
        End Try
    End Sub

    Public Function ValidarCampos() As Boolean
        If txtNombre.Text.Trim() = "" Then
            lblPendiente.Text = "Completá el nombre."
            Return False
        End If
        If txtNombre.Text.Trim().Length > 150 Then
            lblPendiente.Text = "El nombre supera los 150 caracteres."
            Return False
        End If
        If txtDireccion.Text.Trim().Length > 255 OrElse txtTelefono.Text.Trim().Length > 30 OrElse txtEmail.Text.Trim().Length > 100 Then
            lblPendiente.Text = "Dirección, teléfono o email superan el tamaño permitido."
            Return False
        End If
        If cboUso.SelectedIndex < 0 OrElse (cboUso.Text <> "ORIGEN" AndAlso cboUso.Text <> "DESTINO" AndAlso cboUso.Text <> "AMBOS") Then
            lblPendiente.Text = "Seleccioná un uso válido: ORIGEN, DESTINO o AMBOS."
            Return False
        End If
        Return True
    End Function

    Private Sub GuardarRegistro(modificar As Boolean)
        'compruebo el permiso tambien antes de ejecutar la escritura
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            lblPendiente.Text = "No tenés permiso para administrar este catálogo."
            Exit Sub
        End If
        If modificar AndAlso idSelec = 0 Then
            lblPendiente.Text = "Seleccioná una fila para modificar."
            Exit Sub
        End If
        If Not modificar AndAlso idSelec <> 0 Then
            lblPendiente.Text = "Pulsá Limpiar para registrar otro elemento."
            Exit Sub
        End If
        If Not ValidarCampos() Then Exit Sub
        If modificar OrElse Not chkActivo.Checked Then
            Dim mensaje As String = "¿Confirmás la modificación del registro seleccionado?"
            If Not chkActivo.Checked Then mensaje = "¿Confirmás desactivar este registro? Se conservará su historial."
            If Not PresentacionSesion.Confirmar(mensaje) Then
                lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
                Exit Sub
            End If
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
                Dim sql As String
                If modificar Then
                    sql = "UPDATE centros_derivantes SET nombre=@nombre,direccion=@direccion,telefono=@telefono,email=@email,activo=@activo,uso=@uso WHERE id_centro=@id;"
                Else
                    sql = "INSERT INTO centros_derivantes (nombre,direccion,telefono,email,activo,uso) VALUES (@nombre,@direccion,@telefono,@email,@activo,@uso);"
                End If
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@activo", chkActivo.Checked)
                    cmd.Parameters.AddWithValue("@direccion", If(txtDireccion.Text.Trim() = "", DBNull.Value, CObj(txtDireccion.Text.Trim())))
                    cmd.Parameters.AddWithValue("@telefono", If(txtTelefono.Text.Trim() = "", DBNull.Value, CObj(txtTelefono.Text.Trim())))
                    cmd.Parameters.AddWithValue("@email", If(txtEmail.Text.Trim() = "", DBNull.Value, CObj(txtEmail.Text.Trim())))
                    cmd.Parameters.AddWithValue("@uso", cboUso.Text)
                    If modificar Then cmd.Parameters.AddWithValue("@id", idSelec)
                    If cmd.ExecuteNonQuery() <> 1 Then
                        lblPendiente.Text = "No se encontró el registro. Recargá el listado."
                        Exit Sub
                    End If
                End Using
            End Using
            LimpiarForm()
            If CargarGrilla(txtFiltro.Text) Then
                lblPendiente.Text = If(modificar, "Registro modificado correctamente.", "Registro guardado correctamente.")
            Else
                lblPendiente.Text = "Se guardó el registro, pero no se pudo recargar el listado."
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de los centros. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo confirmar el guardado. Revisá el listado y la conexión antes de reintentar."
        Finally
            CADENA = ""
            AplicarPermisos()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarRegistro(False)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        GuardarRegistro(True)
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
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then Exit Sub
        LimpiarForm()
        lblPendiente.Text = "Campos vacíos. El filtro se conserva."
        txtNombre.Focus()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        lblPendiente.Text = "No se eliminan registros. Utilizá Activo y Modificar."
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub frmCentros_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub
End Class
