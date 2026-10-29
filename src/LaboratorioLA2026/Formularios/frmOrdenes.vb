Imports MySqlConnector

Public Class frmOrdenes
    Private idOrdenSelec As Integer = 0
    Private cargando As Boolean = False
    Private guardando As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("CONSULTAR_ORDENES") Then
            Me.Close()
            Return False
        End If
        Dim crear As Boolean = Sesion.Puede("CREAR_ORDENES")
        Dim editar As Boolean = crear AndAlso idOrdenSelec = 0 AndAlso Not guardando
        txtIdOrden.ReadOnly = True
        txtIdOrden.TabStop = False
        txtIdOrden.BackColor = SystemColors.Control
        txtBuscarPaciente.Enabled = editar
        btnBuscarPaciente.Enabled = editar
        cboPaciente.Enabled = editar
        dtpFecha.Enabled = editar
        checklistAnalisis.Enabled = editar
        btnGuardar.Visible = crear
        btnGuardar.Enabled = editar
        btnQuitar.Visible = crear
        btnQuitar.Enabled = editar
        btnNuevo.Visible = crear
        btnNuevo.Enabled = Not guardando
        btnCotizar.Visible = Sesion.Puede("COTIZAR_ORDENES")
        btnCotizar.Enabled = Sesion.Puede("COTIZAR_ORDENES") AndAlso Not guardando
        btnCotizar.Text = If(idOrdenSelec > 0, "Abrir cotización", "Continuar a cotización")
        btnModificar.Visible = False
        btnModificar.Enabled = False
        btnBuscar.Enabled = Not guardando
        btnVerTodos.Enabled = Not guardando
        dgvOrdenes.Enabled = Not guardando
        Dim modo As String = "Solo consulta de órdenes"
        If crear Then modo = "Registro y consulta; las órdenes guardadas son de solo lectura"
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, modo)
        Return True
    End Function

    Private Sub frmOrdenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AplicarPermisos() Then Exit Sub
        LimpiarForm()
        CargarAnalisis()
        CargarGrilla()
    End Sub

    Private Sub frmOrdenes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        AplicarPermisos()
    End Sub

    Public Sub LimpiarForm()
        If Not Sesion.Puede("CONSULTAR_ORDENES") OrElse guardando Then Exit Sub
        cargando = True
        idOrdenSelec = 0
        txtIdOrden.Clear()
        txtBuscarPaciente.Clear()
        cboPaciente.DataSource = Nothing
        cboPaciente.Items.Clear()
        lblPacienteSeleccionado.Text = "Sin paciente seleccionado"
        dtpFecha.Value = Date.Today
        For i As Integer = 0 To checklistAnalisis.Items.Count - 1
            checklistAnalisis.SetItemChecked(i, False)
        Next
        dgvOrdenes.ClearSelection()
        dgvDetalle.DataSource = Nothing
        lblDetalle.Text = "Análisis seleccionados para la nueva orden"
        lblSituacion.Text = "Estado: el esquema actual no registra un estado de orden."
        cargando = False
        AplicarPermisos()
    End Sub

    Public Function CargarAnalisis() As Boolean
        If Not Sesion.Puede("CONSULTAR_ORDENES") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_analisis,nombre FROM analisis WHERE activo=TRUE ORDER BY nombre,id_analisis;", cn)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cargando = True
                    checklistAnalisis.DataSource = Nothing
                    checklistAnalisis.DisplayMember = "nombre"
                    checklistAnalisis.ValueMember = "id_analisis"
                    checklistAnalisis.DataSource = tabla
                    checklistAnalisis.DisplayMember = "nombre"
                    checklistAnalisis.ValueMember = "id_analisis"
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo cargar el catálogo de análisis."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Public Function BuscarPacientes() As Boolean
        If Not Sesion.Puede("CREAR_ORDENES") OrElse idOrdenSelec <> 0 OrElse guardando Then Return False
        cboPaciente.DataSource = Nothing
        lblPacienteSeleccionado.Text = "Sin paciente seleccionado"
        Dim filtro As String = txtBuscarPaciente.Text.Trim()
        If filtro = "" Then
            lblPendiente.Text = "Escribí DNI, nombre o apellido para buscar un paciente."
            Return False
        End If
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim buscarPorDni As Boolean = EsDni(filtro)
                Dim sql As String = "SELECT id_paciente,CONCAT(apellido,', ',nombre,' - DNI ',dni) AS paciente " &
                    "FROM pacientes WHERE (@dni=TRUE AND dni=@exacto) OR (@dni=FALSE AND (dni LIKE @filtro OR nombre LIKE @filtro OR apellido LIKE @filtro)) " &
                    "ORDER BY apellido,nombre,id_paciente LIMIT 50;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro & "%")
                    cmd.Parameters.AddWithValue("@dni", buscarPorDni)
                    cmd.Parameters.AddWithValue("@exacto", filtro)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboPaciente.DisplayMember = "paciente"
                    cboPaciente.ValueMember = "id_paciente"
                    cboPaciente.DataSource = tabla
                    cboPaciente.SelectedIndex = If(tabla.Rows.Count = 1, 0, -1)
                    If tabla.Rows.Count = 0 Then
                        lblPendiente.Text = "El paciente no está registrado."
                    Else
                        lblPendiente.Text = If(tabla.Rows.Count = 1, "Paciente seleccionado. Marcá uno o varios análisis.", "Pacientes encontrados: " & tabla.Rows.Count.ToString() & ". Seleccioná uno.")
                    End If
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo buscar pacientes. Revisá la conexión."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub cboPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaciente.SelectedIndexChanged
        If cboPaciente.SelectedIndex >= 0 Then
            lblPacienteSeleccionado.Text = cboPaciente.Text
        Else
            lblPacienteSeleccionado.Text = "Sin paciente seleccionado"
        End If
    End Sub

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("CONSULTAR_ORDENES") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT o.id_orden,o.fecha,o.id_paciente,p.dni," &
                    "CONCAT(p.apellido,', ',p.nombre) AS paciente " &
                    "FROM ordenes o INNER JOIN pacientes p ON p.id_paciente=o.id_paciente " &
                    "WHERE (CAST(o.id_orden AS CHAR) LIKE @filtro OR p.dni LIKE @filtro " &
                    "OR p.nombre LIKE @filtro OR p.apellido LIKE @filtro) " &
                    "AND (@usarFecha=FALSE OR o.fecha=@fecha) ORDER BY o.fecha DESC,o.id_orden DESC;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    cmd.Parameters.AddWithValue("@usarFecha", dtpFiltroFecha.Checked)
                    cmd.Parameters.AddWithValue("@fecha", dtpFiltroFecha.Value.Date)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cargando = True
                    dgvOrdenes.DataSource = tabla
                    dgvOrdenes.Columns("id_orden").HeaderText = "Orden"
                    dgvOrdenes.Columns("fecha").HeaderText = "Fecha"
                    dgvOrdenes.Columns("fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
                    dgvOrdenes.Columns("id_paciente").Visible = False
                    dgvOrdenes.Columns("dni").HeaderText = "DNI"
                    dgvOrdenes.Columns("paciente").HeaderText = "Paciente"
                    dgvOrdenes.ClearSelection()
                    lblPendiente.Text = "Órdenes encontradas: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo consultar las órdenes. Revisá la conexión."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Public Function CargarDetalle(idOrden As Integer) As Boolean
        If Not Sesion.Puede("CONSULTAR_ORDENES") OrElse idOrden <= 0 Then Return False
        dgvDetalle.DataSource = Nothing
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT a.id_analisis,a.nombre,a.activo FROM orden_analisis oa " &
                    "INNER JOIN analisis a ON a.id_analisis=oa.id_analisis WHERE oa.id_orden=@id ORDER BY a.nombre,a.id_analisis;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", idOrden)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvDetalle.DataSource = tabla
                    PrepararDetalle()
                    lblDetalle.Text = "Análisis de la orden " & idOrden.ToString() & " (solo consulta)"
                    If tabla.Rows.Count = 0 Then lblDetalle.Text &= " · Sin análisis asociados"
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar los análisis de la orden."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub dgvOrdenes_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOrdenes.SelectionChanged
        If cargando OrElse Not Sesion.Puede("CONSULTAR_ORDENES") Then Exit Sub
        If dgvOrdenes.SelectedRows.Count <> 1 Then Exit Sub
        Try
            Dim fila = dgvOrdenes.SelectedRows(0)
            LimpiarForm()
            idOrdenSelec = CInt(fila.Cells("id_orden").Value)
            txtIdOrden.Text = idOrdenSelec.ToString()
            dtpFecha.Value = CDate(fila.Cells("fecha").Value)
            Dim paciente As New DataTable
            paciente.Columns.Add("id_paciente", GetType(Integer))
            paciente.Columns.Add("paciente", GetType(String))
            paciente.Rows.Add(CInt(fila.Cells("id_paciente").Value), fila.Cells("paciente").Value.ToString() & " - DNI " & fila.Cells("dni").Value.ToString())
            cboPaciente.DisplayMember = "paciente"
            cboPaciente.ValueMember = "id_paciente"
            cboPaciente.DataSource = paciente
            cargando = True
            fila.Selected = True
            cargando = False
            AplicarPermisos()
            CargarDetalle(idOrdenSelec)
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            cargando = False
            LimpiarForm()
            lblPendiente.Text = "No se pudo mostrar la orden seleccionada."
        End Try
    End Sub

    Private Sub PrepararDetalle()
        dgvDetalle.Columns("id_analisis").HeaderText = "ID"
        dgvDetalle.Columns("nombre").HeaderText = "Análisis"
        If dgvDetalle.Columns.Contains("activo") Then dgvDetalle.Columns("activo").HeaderText = "Activo actual"
        dgvDetalle.ClearSelection()
    End Sub

    Private Sub checklistAnalisis_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles checklistAnalisis.ItemCheck
        Try
            If cargando Then Exit Sub
            If Not Sesion.Puede("CREAR_ORDENES") OrElse idOrdenSelec <> 0 OrElse guardando Then
                e.NewValue = e.CurrentValue
                Exit Sub
            End If
            'el evento ocurre antes de cambiar la marca; uso el nuevo valor
            Dim tabla As New DataTable
            tabla.Columns.Add("id_analisis", GetType(Integer))
            tabla.Columns.Add("nombre", GetType(String))
            For i As Integer = 0 To checklistAnalisis.Items.Count - 1
                Dim marcado As Boolean = checklistAnalisis.GetItemChecked(i)
                If i = e.Index Then marcado = e.NewValue = CheckState.Checked
                If marcado Then
                    Dim item As DataRowView = CType(checklistAnalisis.Items(i), DataRowView)
                    tabla.Rows.Add(CInt(item("id_analisis")), item("nombre").ToString())
                End If
            Next
            dgvDetalle.DataSource = tabla
            PrepararDetalle()
            lblDetalle.Text = "Análisis seleccionados: " & tabla.Rows.Count.ToString()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Try
            If Not Sesion.Puede("CREAR_ORDENES") OrElse idOrdenSelec <> 0 OrElse guardando Then Exit Sub
            If dgvDetalle.SelectedRows.Count <> 1 Then
                lblPendiente.Text = "Seleccioná un análisis del detalle para quitarlo de la selección."
                Exit Sub
            End If
            Dim id As Integer = CInt(dgvDetalle.SelectedRows(0).Cells("id_analisis").Value)
            For i As Integer = 0 To checklistAnalisis.Items.Count - 1
                Dim item As DataRowView = CType(checklistAnalisis.Items(i), DataRowView)
                If CInt(item("id_analisis")) = id Then
                    checklistAnalisis.SetItemChecked(i, False)
                    Exit For
                End If
            Next
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Public Function ValidarCampos() As Boolean
        If Not Sesion.Puede("CREAR_ORDENES") OrElse idOrdenSelec <> 0 OrElse guardando Then Return False
        If cboPaciente.SelectedIndex < 0 OrElse cboPaciente.SelectedValue Is Nothing Then
            lblPendiente.Text = "Seleccioná un paciente existente."
            Return False
        End If
        Dim id As Integer
        If Not Integer.TryParse(cboPaciente.SelectedValue.ToString(), id) OrElse id <= 0 Then Return False
        If checklistAnalisis.CheckedItems.Count = 0 Then
            lblPendiente.Text = "Seleccioná al menos un análisis activo."
            Return False
        End If
        Dim ids As New List(Of Integer)
        For Each item As DataRowView In checklistAnalisis.CheckedItems
            Dim idAnalisis As Integer = CInt(item("id_analisis"))
            If idAnalisis <= 0 OrElse ids.Contains(idAnalisis) Then
                lblPendiente.Text = "La selección contiene un análisis inválido o repetido."
                Return False
            End If
            ids.Add(idAnalisis)
        Next
        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not Sesion.Puede("CREAR_ORDENES") Then
            lblPendiente.Text = "No tenés permiso para registrar órdenes."
            Exit Sub
        End If
        If Not ValidarCampos() Then Exit Sub
        If Not PresentacionSesion.Confirmar("¿Confirmás registrar la orden con los estudios seleccionados?") Then
            lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        Dim idPaciente As Integer = CInt(cboPaciente.SelectedValue)
        Dim ids As New List(Of Integer)
        For Each item As DataRowView In checklistAnalisis.CheckedItems
            ids.Add(CInt(item("id_analisis")))
        Next
        ids.Sort()
        Dim nuevaOrden As Integer = 0
        Dim ordenGuardada As Boolean = False
        guardando = True
        AplicarPermisos()
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                'guardo cabecera y analisis juntos, como libro-autores
                Using tx = cn.BeginTransaction()
                    Try
                        Using cmd As New MySqlCommand("SELECT id_paciente FROM pacientes WHERE id_paciente=@id FOR UPDATE;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", idPaciente)
                            If cmd.ExecuteScalar() Is Nothing Then Throw New InvalidOperationException("El paciente ya no está disponible.")
                        End Using
                        For Each id As Integer In ids
                            Using cmd As New MySqlCommand("SELECT activo FROM analisis WHERE id_analisis=@id FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@id", id)
                                Dim activo = cmd.ExecuteScalar()
                                If activo Is Nothing OrElse Not CBool(activo) Then
                                    tx.Rollback()
                                    lblPendiente.Text = "Un análisis ya no está activo. Pulsá Nueva y revisá el catálogo."
                                    Return
                                End If
                            End Using
                        Next
                        Using cmd As New MySqlCommand("INSERT INTO ordenes (id_paciente,fecha) VALUES (@paciente,@fecha);", cn, tx)
                            cmd.Parameters.AddWithValue("@paciente", idPaciente)
                            cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date)
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException()
                            nuevaOrden = CInt(cmd.LastInsertedId)
                        End Using
                        For Each id As Integer In ids
                            Using cmd As New MySqlCommand("INSERT INTO orden_analisis (id_orden,id_analisis) VALUES (@orden,@analisis);", cn, tx)
                                cmd.Parameters.AddWithValue("@orden", nuevaOrden)
                                cmd.Parameters.AddWithValue("@analisis", id)
                                If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException()
                            End Using
                        Next
                        tx.Commit()
                        ordenGuardada = True
                    Catch ex As Exception
                        PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            guardando = False
            LimpiarForm()
            txtFiltro.Clear()
            dtpFiltroFecha.Checked = False
            If CargarGrilla() Then SeleccionarOrdenGuardada(nuevaOrden)
            lblPendiente.Text = "Orden " & nuevaOrden.ToString() & " guardada con sus estudios. No se registró ningún pago."
            If Sesion.Puede("COTIZAR_ORDENES") AndAlso PresentacionSesion.Confirmar("La orden se guardó correctamente. ¿Querés continuar a su cotización sin volver a buscar el paciente?") Then
                idOrdenSelec = nuevaOrden
                ContinuarCotizacion()
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = If(ordenGuardada, "La orden " & nuevaOrden.ToString() & " ya se guardó. Recargá el listado; no repitas el alta.", "No se pudo confirmar el guardado. Consultá el listado antes de volver a intentar.")
        Finally
            guardando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Sub

    Private Sub btnBuscarPaciente_Click(sender As Object, e As EventArgs) Handles btnBuscarPaciente.Click
        BuscarYOfrecerAlta()
    End Sub

    Private Function EsDni(texto As String) As Boolean
        If texto = "" Then Return False
        For Each caracter As Char In texto
            If Not Char.IsDigit(caracter) Then Return False
        Next
        Return True
    End Function

    Private Sub BuscarYOfrecerAlta()
        If Not BuscarPacientes() OrElse cboPaciente.Items.Count <> 0 Then Exit Sub
        If Not Sesion.Puede("REGISTRAR_PACIENTES") Then Exit Sub
        If Not PresentacionSesion.Confirmar("El paciente no está registrado. ¿Querés abrir Pacientes para darlo de alta y regresar a esta orden?") Then Exit Sub
        Using formulario As New frmPacientes()
            formulario.RegresarAOrden = True
            Dim dni As String = txtBuscarPaciente.Text.Trim()
            If EsDni(dni) Then formulario.DniInicial = dni
            If formulario.ShowDialog(Me) = DialogResult.OK AndAlso formulario.PacienteRegistradoId > 0 Then
                SeleccionarPaciente(formulario.PacienteRegistradoId)
            End If
        End Using
    End Sub

    Private Sub SeleccionarPaciente(id As Integer)
        If Not Sesion.Puede("CREAR_ORDENES") OrElse Not ObtenerDatosConexion() Then Exit Sub
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_paciente,dni,CONCAT(apellido,', ',nombre,' - DNI ',dni) AS paciente FROM pacientes WHERE id_paciente=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboPaciente.DisplayMember = "paciente"
                    cboPaciente.ValueMember = "id_paciente"
                    cboPaciente.DataSource = tabla
                    If tabla.Rows.Count = 1 Then txtBuscarPaciente.Text = tabla.Rows(0)("dni").ToString()
                    lblPendiente.Text = "Paciente registrado y seleccionado. Los estudios marcados se conservan."
                End Using
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar las órdenes. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "El paciente se guardó. Buscalo nuevamente por su DNI para continuar."
        Finally
            CADENA = ""
        End Try
    End Sub

    Private Sub SeleccionarOrdenGuardada(id As Integer)
        For Each fila As DataGridViewRow In dgvOrdenes.Rows
            If Not fila.IsNewRow AndAlso CInt(fila.Cells("id_orden").Value) = id Then
                dgvOrdenes.ClearSelection()
                fila.Selected = True
                dgvOrdenes.CurrentCell = fila.Cells("id_orden")
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCotizar_Click(sender As Object, e As EventArgs) Handles btnCotizar.Click
        ContinuarCotizacion()
    End Sub

    Private Sub ContinuarCotizacion()
        If Not Sesion.Puede("COTIZAR_ORDENES") OrElse guardando Then Exit Sub
        If idOrdenSelec = 0 AndAlso Not ValidarCampos() Then Exit Sub
        Using formulario As New frmFacturacion()
            If idOrdenSelec > 0 Then
                formulario.RecibirOrden(idOrdenSelec)
            Else
                Dim ids As New List(Of Integer)
                For Each item As DataRowView In checklistAnalisis.CheckedItems
                    ids.Add(CInt(item("id_analisis")))
                Next
                formulario.RecibirBorrador(CInt(cboPaciente.SelectedValue), dtpFecha.Value.Date, ids)
            End If
            guardando = True
            AplicarPermisos()
            Try
                formulario.ShowDialog(Me)
            Finally
                guardando = False
                AplicarPermisos()
            End Try
            If formulario.OrdenGuardadaId > 0 Then
                txtFiltro.Clear()
                dtpFiltroFecha.Checked = False
                CargarGrilla()
                SeleccionarOrdenGuardada(formulario.OrdenGuardadaId)
                lblPendiente.Text = "Orden y cotización confirmadas. El pago se registra por separado."
            ElseIf idOrdenSelec = 0 Then
                lblPendiente.Text = "Volviste del borrador. La orden no se guardó; podés continuar editándola."
            End If
        End Using
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        txtFiltro.Clear()
        dtpFiltroFecha.Checked = False
        CargarGrilla()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Not Sesion.Puede("CREAR_ORDENES") OrElse guardando Then Exit Sub
        LimpiarForm()
        If CargarAnalisis() Then lblPendiente.Text = "Nueva orden. Seleccioná paciente, fecha y análisis. No se borraron registros."
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        lblPendiente.Text = "Las órdenes guardadas son de solo consulta; edición y cancelación pendientes de alcance."
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub frmOrdenes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtBuscarPaciente.Focused Then
            e.SuppressKeyPress = True
            BuscarYOfrecerAlta()
            Exit Sub
        End If
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub
    Private Sub checklistAnalisis_Format(sender As Object, e As ListControlConvertEventArgs) Handles checklistAnalisis.Format
        Dim fila As DataRowView = TryCast(e.ListItem, DataRowView)
        If fila IsNot Nothing Then e.Value = fila("nombre").ToString()
    End Sub
End Class
