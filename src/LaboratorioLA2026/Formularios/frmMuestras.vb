Imports MySqlConnector

Public Class frmMuestras
    Private idMuestraSelec As Integer = 0
    Private idOrdenOriginal As Integer = 0
    Private idOrigenOriginal As Integer = 0
    Private codigoOriginal As String = ""
    Private estadoOriginal As String = ""
    Private analisisOriginal As New List(Of Integer)
    Private tieneDerivacion As Boolean = False
    Private cargando As Boolean = False
    Private guardando As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") Then
            Me.Close()
            Return False
        End If
        Dim editar As Boolean = Sesion.Puede("REGISTRAR_MUESTRAS")
        If idMuestraSelec > 0 Then editar = Sesion.Puede("ACTUALIZAR_MUESTRAS")
        editar = editar AndAlso Not guardando
        txtCodigo.ReadOnly = Not editar
        txtTipoMuestra.ReadOnly = Not editar
        txtObservaciones.ReadOnly = Not editar
        txtCodigo.Enabled = True
        txtTipoMuestra.Enabled = True
        txtObservaciones.Enabled = True
        cboOrden.Enabled = editar AndAlso idMuestraSelec = 0
        cboCentroOrigen.Enabled = editar AndAlso idMuestraSelec = 0
        dtpFechaRecepcion.Enabled = editar
        cboEstado.Enabled = editar AndAlso Sesion.Puede("ACTUALIZAR_MUESTRAS")
        chkDocumentacion.Enabled = editar
        checklistAnalisis.Enabled = editar AndAlso (idMuestraSelec = 0 OrElse (estadoOriginal = "RECIBIDA" AndAlso Not tieneDerivacion))
        btnGuardar.Visible = Sesion.Puede("REGISTRAR_MUESTRAS")
        btnGuardar.Enabled = editar AndAlso idMuestraSelec = 0
        btnModificar.Visible = Sesion.Puede("ACTUALIZAR_MUESTRAS")
        btnModificar.Enabled = editar AndAlso idMuestraSelec > 0
        btnNuevo.Visible = Sesion.Puede("REGISTRAR_MUESTRAS")
        btnNuevo.Enabled = Not guardando
        btnGenerarCodigo.Visible = Sesion.Puede("REGISTRAR_MUESTRAS")
        btnGenerarCodigo.Enabled = editar AndAlso idMuestraSelec = 0
        dgvMuestras.Enabled = Not guardando
        Dim modo As String = "Consulta de muestra seleccionada"
        If editar Then modo = "Registro y seguimiento administrativo de muestras"
        PresentacionSesion.MostrarRol(pnlEncabezado, lblSubtitulo, modo)
        PintarEstado()
        Return True
    End Function

    Private Sub frmMuestras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AplicarPermisos() Then Exit Sub
        cboEstado.Items.Clear()
        cboEstado.Items.AddRange(New Object() {"RECIBIDA", "EN PROCESO", "CERRADA"})
        LimpiarForm()
        CargarGrilla()
    End Sub

    Private Sub frmMuestras_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        AplicarPermisos()
    End Sub

    Private Function CargarOpciones(Optional origenActual As Integer = 0) As Boolean
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT o.id_orden,CONCAT(p.apellido,', ',p.nombre,' - DNI ',p.dni) AS paciente," &
                    "CONCAT('Orden ',o.id_orden,' - ',p.apellido,', ',p.nombre) AS orden " &
                    "FROM ordenes o INNER JOIN pacientes p ON p.id_paciente=o.id_paciente ORDER BY o.id_orden DESC;"
                Using cmd As New MySqlCommand(sql, cn)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboOrden.DataSource = tabla
                    cboOrden.DisplayMember = "orden"
                    cboOrden.ValueMember = "id_orden"
                    cboOrden.SelectedIndex = -1
                End Using
                sql = "SELECT id_centro,nombre FROM centros_derivantes WHERE (activo=TRUE AND uso IN ('ORIGEN','AMBOS')) OR id_centro=@actual ORDER BY nombre;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@actual", origenActual)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    Dim sinCentro = tabla.NewRow()
                    sinCentro("id_centro") = 0
                    sinCentro("nombre") = "(Sin centro de origen)"
                    tabla.Rows.InsertAt(sinCentro, 0)
                    cboCentroOrigen.DataSource = tabla
                    cboCentroOrigen.DisplayMember = "nombre"
                    cboCentroOrigen.ValueMember = "id_centro"
                    cboCentroOrigen.SelectedValue = 0
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar las órdenes o centros."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Public Sub LimpiarForm()
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") OrElse guardando Then Exit Sub
        cargando = True
        idMuestraSelec = 0
        idOrdenOriginal = 0
        idOrigenOriginal = 0
        codigoOriginal = ""
        estadoOriginal = ""
        analisisOriginal.Clear()
        tieneDerivacion = False
        txtCodigo.Clear()
        txtTipoMuestra.Clear()
        txtObservaciones.Clear()
        dtpFechaRecepcion.Value = Date.Now
        cboEstado.SelectedItem = "RECIBIDA"
        chkDocumentacion.Checked = False
        checklistAnalisis.DataSource = Nothing
        lblPacienteMuestra.Text = "Paciente de la orden: sin selección"
        CargarOpciones()
        dgvMuestras.ClearSelection()
        cargando = False
        AplicarPermisos()
    End Sub

    Public Function CargarAnalisisOrden(idOrden As Integer) As Boolean
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") OrElse idOrden <= 0 Then Return False
        checklistAnalisis.DataSource = Nothing
        If Not ObtenerDatosConexion() Then Return False
        Dim anterior As Boolean = cargando
        cargando = True
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT a.id_analisis,a.nombre FROM orden_analisis oa INNER JOIN analisis a ON a.id_analisis=oa.id_analisis WHERE oa.id_orden=@orden ORDER BY a.nombre;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@orden", idOrden)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    checklistAnalisis.DataSource = tabla
                    checklistAnalisis.DisplayMember = "nombre"
                    checklistAnalisis.ValueMember = "id_analisis"
                    For i As Integer = 0 To checklistAnalisis.Items.Count - 1
                        Dim fila = CType(checklistAnalisis.Items(i), DataRowView)
                        checklistAnalisis.SetItemChecked(i, analisisOriginal.Contains(CInt(fila("id_analisis"))))
                    Next
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar los estudios solicitados."
            Return False
        Finally
            CADENA = ""
            cargando = anterior
        End Try
    End Function

    Private Sub cboOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrden.SelectedIndexChanged
        Try
            If cargando OrElse idMuestraSelec > 0 Then Exit Sub
            Dim fila = TryCast(cboOrden.SelectedItem, DataRowView)
            If fila Is Nothing Then Exit Sub
            lblPacienteMuestra.Text = "Paciente: " & fila("paciente").ToString()
            analisisOriginal.Clear()
            CargarAnalisisOrden(CInt(fila("id_orden")))
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Public Function CargarMuestra(id As Integer) As Boolean
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") OrElse id <= 0 Then Return False
        If Not ObtenerDatosConexion() Then Return False
        cargando = True
        Try
            Dim tabla As New DataTable
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_muestra,codigo,id_orden,id_centro,tipo_muestra,fecha_recepcion,estado,documentacion_completa,observaciones FROM muestras WHERE id_muestra=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                End Using
                If tabla.Rows.Count <> 1 Then Return False
                analisisOriginal.Clear()
                Using cmd As New MySqlCommand("SELECT id_analisis FROM muestra_analisis WHERE id_muestra=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using lector = cmd.ExecuteReader()
                        While lector.Read()
                            analisisOriginal.Add(CInt(lector("id_analisis")))
                        End While
                    End Using
                End Using
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM derivaciones WHERE id_muestra=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    tieneDerivacion = CInt(cmd.ExecuteScalar()) > 0
                End Using
            End Using
            Dim fila = tabla.Rows(0)
            idMuestraSelec = id
            idOrdenOriginal = CInt(fila("id_orden"))
            idOrigenOriginal = If(IsDBNull(fila("id_centro")), 0, CInt(fila("id_centro")))
            codigoOriginal = fila("codigo").ToString()
            estadoOriginal = fila("estado").ToString()
            If Not CargarOpciones(idOrigenOriginal) Then Return False
            cboOrden.SelectedValue = idOrdenOriginal
            cboCentroOrigen.SelectedValue = idOrigenOriginal
            txtCodigo.Text = codigoOriginal
            txtTipoMuestra.Text = fila("tipo_muestra").ToString()
            txtObservaciones.Text = fila("observaciones").ToString()
            dtpFechaRecepcion.Value = CDate(fila("fecha_recepcion"))
            cboEstado.SelectedItem = estadoOriginal
            chkDocumentacion.Checked = CBool(fila("documentacion_completa"))
            Dim paciente = TryCast(cboOrden.SelectedItem, DataRowView)
            If paciente IsNot Nothing Then lblPacienteMuestra.Text = "Paciente: " & paciente("paciente").ToString()
            If Not CargarAnalisisOrden(idOrdenOriginal) Then Return False
            AplicarPermisos()
            lblPendiente.Text = "Muestra seleccionada. Solo están marcados sus estudios, no todos los de la orden."
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar los datos de la muestra."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") Then Return False
        If Not ObtenerDatosConexion() Then Return False
        cargando = True
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT m.id_muestra,m.codigo,m.id_orden,CONCAT(p.apellido,', ',p.nombre) AS paciente,m.tipo_muestra,m.fecha_recepcion,m.estado,m.documentacion_completa,c.nombre AS origen FROM muestras m INNER JOIN ordenes o ON o.id_orden=m.id_orden INNER JOIN pacientes p ON p.id_paciente=o.id_paciente LEFT JOIN centros_derivantes c ON c.id_centro=m.id_centro WHERE m.codigo LIKE @filtro OR CAST(m.id_orden AS CHAR) LIKE @filtro OR m.estado LIKE @filtro OR c.nombre LIKE @filtro ORDER BY m.fecha_recepcion DESC,m.id_muestra DESC;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvMuestras.DataSource = tabla
                    dgvMuestras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    dgvMuestras.Columns("id_muestra").Visible = False
                    dgvMuestras.Columns("codigo").HeaderText = "Contenedor"
                    dgvMuestras.Columns("id_orden").HeaderText = "Orden"
                    dgvMuestras.Columns("paciente").HeaderText = "Paciente"
                    dgvMuestras.Columns("tipo_muestra").HeaderText = "Material"
                    dgvMuestras.Columns("fecha_recepcion").HeaderText = "Recepción"
                    dgvMuestras.Columns("estado").HeaderText = "Estado"
                    dgvMuestras.Columns("documentacion_completa").HeaderText = "Documentación completa"
                    dgvMuestras.Columns("origen").HeaderText = "Centro de origen"
                    dgvMuestras.Columns("fecha_recepcion").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
                    For Each fila As DataGridViewRow In dgvMuestras.Rows
                        fila.DefaultCellStyle.BackColor = ColorEstado(fila.Cells("estado").Value.ToString())
                    Next
                    dgvMuestras.ClearSelection()
                    lblPendiente.Text = "Muestras encontradas: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo consultar las muestras."
            Return False
        Finally
            CADENA = ""
            cargando = False
        End Try
    End Function

    Private Sub dgvMuestras_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMuestras.SelectionChanged
        Try
            If cargando OrElse dgvMuestras.SelectedRows.Count <> 1 Then Exit Sub
            CargarMuestra(CInt(dgvMuestras.SelectedRows(0).Cells("id_muestra").Value))
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Private Function ColorEstado(estado As String) As Color
        If estado = "RECIBIDA" Then Return Color.LightYellow
        If estado = "EN PROCESO" Then Return Color.AliceBlue
        If estado = "CERRADA" Then Return Color.Honeydew
        Return Color.White
    End Function

    Private Sub PintarEstado()
        cboEstado.BackColor = ColorEstado(cboEstado.Text)
        cboEstado.ForeColor = Color.Black
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        PintarEstado()
    End Sub

    Private Function EstudiosElegidos() As List(Of Integer)
        Dim ids As New List(Of Integer)
        For Each fila As DataRowView In checklistAnalisis.CheckedItems
            ids.Add(CInt(fila("id_analisis")))
        Next
        Return ids
    End Function

    Public Function ValidarCampos() As Boolean
        Dim permiso As String = If(idMuestraSelec = 0, "REGISTRAR_MUESTRAS", "ACTUALIZAR_MUESTRAS")
        If Not Sesion.Puede(permiso) OrElse guardando Then Return False
        If txtCodigo.Text.Trim() = "" OrElse txtTipoMuestra.Text.Trim() = "" OrElse cboOrden.SelectedIndex < 0 Then
            lblPendiente.Text = "Completá código de contenedor, orden y tipo de muestra."
            Return False
        End If
        If txtCodigo.Text.Trim().Length > 30 OrElse txtTipoMuestra.Text.Trim().Length > 60 OrElse txtObservaciones.Text.Trim().Length > 255 Then
            lblPendiente.Text = "Revisá el tamaño de código, tipo u observaciones."
            Return False
        End If
        If cboEstado.Text <> "RECIBIDA" AndAlso cboEstado.Text <> "EN PROCESO" AndAlso cboEstado.Text <> "CERRADA" Then
            lblPendiente.Text = "Seleccioná un estado válido."
            Return False
        End If
        If Not Sesion.Puede("ACTUALIZAR_MUESTRAS") AndAlso cboEstado.Text <> "RECIBIDA" Then Return False
        Dim ids = EstudiosElegidos()
        Dim unicos As New List(Of Integer)
        For Each id In ids
            If id <= 0 OrElse unicos.Contains(id) Then Return False
            unicos.Add(id)
        Next
        If ids.Count = 0 Then
            lblPendiente.Text = "Marcá al menos un estudio de la orden."
            Return False
        End If
        If cboEstado.Text <> "RECIBIDA" AndAlso Not chkDocumentacion.Checked Then
            lblPendiente.Text = "Completá la revisión administrativa de documentación antes de procesar o cerrar."
            Return False
        End If
        If idMuestraSelec > 0 AndAlso (CInt(cboOrden.SelectedValue) <> idOrdenOriginal OrElse CInt(cboCentroOrigen.SelectedValue) <> idOrigenOriginal) Then
            lblPendiente.Text = "La orden y el origen de una muestra guardada no se cambian desde esta pantalla."
            Return False
        End If
        Return True
    End Function

    Private Sub GuardarMuestra(modificar As Boolean)
        Dim permiso As String = If(modificar, "ACTUALIZAR_MUESTRAS", "REGISTRAR_MUESTRAS")
        If Not Sesion.Puede(permiso) Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        If modificar <> (idMuestraSelec > 0) OrElse Not ValidarCampos() Then Exit Sub
        If modificar OrElse cboEstado.Text <> "RECIBIDA" Then
            Dim mensaje As String = "¿Confirmás los datos y el estado de la muestra?"
            If modificar AndAlso txtCodigo.Text.Trim() <> codigoOriginal Then mensaje = "Se cambiará el código histórico del contenedor. ¿Confirmás el cambio y los demás datos?"
            If Not PresentacionSesion.Confirmar(mensaje) Then
                lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
                Exit Sub
            End If
        End If
        If Not ObtenerDatosConexion() Then Exit Sub
        Dim ids = EstudiosElegidos()
        Dim idOrden As Integer = CInt(cboOrden.SelectedValue)
        Dim idOrigen As Integer = If(cboCentroOrigen.SelectedIndex < 0, 0, CInt(cboCentroOrigen.SelectedValue))
        Dim idGuardar As Integer = idMuestraSelec
        guardando = True
        AplicarPermisos()
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Try
                        Dim derivada As Boolean = False
                        Dim cambiarEstudios As Boolean = ids.Count <> analisisOriginal.Count
                        For Each id In ids
                            If Not analisisOriginal.Contains(id) Then cambiarEstudios = True
                        Next
                        If modificar Then
                            Using cmd As New MySqlCommand("SELECT codigo,estado FROM muestras WHERE id_muestra=@id FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@id", idGuardar)
                                Using lector = cmd.ExecuteReader()
                                    If Not lector.Read() Then Throw New InvalidOperationException()
                                    If lector("codigo").ToString() <> codigoOriginal OrElse lector("estado").ToString() <> estadoOriginal Then Throw New InvalidOperationException()
                                End Using
                            End Using
                            Dim retornoPendiente As Boolean = False
                            Using cmd As New MySqlCommand("SELECT fecha_envio,fecha_retorno FROM derivaciones WHERE id_muestra=@id;", cn, tx)
                                cmd.Parameters.AddWithValue("@id", idGuardar)
                                Using lector = cmd.ExecuteReader()
                                    If lector.Read() Then
                                        derivada = True
                                        If dtpFechaRecepcion.Value > CDate(lector("fecha_envio")) Then Throw New InvalidOperationException()
                                        retornoPendiente = IsDBNull(lector("fecha_retorno"))
                                    End If
                                End Using
                            End Using
                            If cboEstado.Text = "CERRADA" AndAlso retornoPendiente Then
                                lblPendiente.Text = "No se puede cerrar una muestra con derivación pendiente."
                                tx.Rollback()
                                Return
                            End If
                            If cambiarEstudios AndAlso (estadoOriginal <> "RECIBIDA" OrElse derivada) Then
                                lblPendiente.Text = "Los estudios de una muestra procesada, cerrada o derivada no pueden cambiarse."
                                tx.Rollback()
                                Return
                            End If
                        ElseIf idOrigen > 0 Then
                            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM centros_derivantes WHERE id_centro=@id AND activo=TRUE AND uso IN ('ORIGEN','AMBOS');", cn, tx)
                                cmd.Parameters.AddWithValue("@id", idOrigen)
                                If CInt(cmd.ExecuteScalar()) <> 1 Then Throw New InvalidOperationException()
                            End Using
                        End If
                        Using cmd As New MySqlCommand("SELECT COUNT(*) FROM muestras WHERE codigo=@codigo AND id_muestra<>@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim())
                            cmd.Parameters.AddWithValue("@id", idGuardar)
                            If CInt(cmd.ExecuteScalar()) > 0 Then
                                tx.Rollback()
                                lblPendiente.Text = "Ese código de contenedor ya existe."
                                Return
                            End If
                        End Using
                        Dim sql As String
                        If modificar Then
                            sql = "UPDATE muestras SET codigo=@codigo,tipo_muestra=@tipo,fecha_recepcion=@fecha,estado=@estado,documentacion_completa=@documentacion,observaciones=@observaciones WHERE id_muestra=@id;"
                        Else
                            sql = "INSERT INTO muestras(codigo,id_orden,id_centro,id_usuario_registro,tipo_muestra,fecha_recepcion,estado,documentacion_completa,observaciones) VALUES(@codigo,@orden,@origen,@usuario,@tipo,@fecha,@estado,@documentacion,@observaciones);"
                        End If
                        Using cmd As New MySqlCommand(sql, cn, tx)
                            cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim())
                            cmd.Parameters.AddWithValue("@tipo", txtTipoMuestra.Text.Trim())
                            cmd.Parameters.AddWithValue("@fecha", dtpFechaRecepcion.Value)
                            cmd.Parameters.AddWithValue("@estado", cboEstado.Text)
                            cmd.Parameters.AddWithValue("@documentacion", chkDocumentacion.Checked)
                            cmd.Parameters.AddWithValue("@observaciones", If(txtObservaciones.Text.Trim() = "", DBNull.Value, CObj(txtObservaciones.Text.Trim())))
                            If modificar Then
                                cmd.Parameters.AddWithValue("@id", idGuardar)
                            Else
                                cmd.Parameters.AddWithValue("@orden", idOrden)
                                cmd.Parameters.AddWithValue("@origen", If(idOrigen = 0, DBNull.Value, CObj(idOrigen)))
                                cmd.Parameters.AddWithValue("@usuario", Sesion.idUsuario)
                            End If
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException()
                            If Not modificar Then idGuardar = CInt(cmd.LastInsertedId)
                        End Using
                        If Not modificar OrElse cambiarEstudios Then
                            If modificar Then
                                Using cmd As New MySqlCommand("DELETE FROM muestra_analisis WHERE id_muestra=@id;", cn, tx)
                                    cmd.Parameters.AddWithValue("@id", idGuardar)
                                    cmd.ExecuteNonQuery()
                                End Using
                            End If
                            For Each id In ids
                                Using cmd As New MySqlCommand("INSERT INTO muestra_analisis(id_muestra,id_orden,id_analisis) VALUES(@muestra,@orden,@analisis);", cn, tx)
                                    cmd.Parameters.AddWithValue("@muestra", idGuardar)
                                    cmd.Parameters.AddWithValue("@orden", idOrden)
                                    cmd.Parameters.AddWithValue("@analisis", id)
                                    cmd.ExecuteNonQuery()
                                End Using
                            Next
                        End If
                        tx.Commit()
                    Catch ex As Exception
                        PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            guardando = False
            LimpiarForm()
            If CargarGrilla(txtFiltro.Text) Then lblPendiente.Text = "Muestra guardada correctamente."
        Catch ex As MySqlException
            PresentacionSesion.MostrarError("No se pudo completar el guardado de las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = If(ex.Number = 1062, "Ese código de contenedor ya existe.", "No se pudo confirmar el guardado. Revisá los datos y el listado antes de reintentar.")
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de las muestras. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo confirmar el guardado. Revisá fechas, relaciones y el listado antes de reintentar."
        Finally
            guardando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarMuestra(False)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        GuardarMuestra(True)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Not Sesion.Puede("REGISTRAR_MUESTRAS") Then Exit Sub
        LimpiarForm()
    End Sub

    Private Sub btnGenerarCodigo_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigo.Click
        If Not Sesion.Puede("REGISTRAR_MUESTRAS") OrElse idMuestraSelec > 0 OrElse guardando Then Exit Sub
        txtCodigo.Text = "LA-" & Guid.NewGuid().ToString("N").Substring(0, 20).ToUpperInvariant()
        lblPendiente.Text = "Código propuesto; podés revisarlo y editarlo antes de guardar."
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        txtFiltro.Clear()
        CargarGrilla()
    End Sub

    Private Sub checklistAnalisis_Format(sender As Object, e As ListControlConvertEventArgs) Handles checklistAnalisis.Format
        Dim fila = TryCast(e.ListItem, DataRowView)
        If fila IsNot Nothing Then e.Value = fila("nombre").ToString()
    End Sub

    Private Sub frmMuestras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtCodigo.Focused Then
            e.SuppressKeyPress = True
            CargarGrilla(txtCodigo.Text.Trim())
            If dgvMuestras.Rows.Count = 1 AndAlso idMuestraSelec = 0 Then
                dgvMuestras.Rows(0).Selected = True
            End If
            Exit Sub
        End If
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
