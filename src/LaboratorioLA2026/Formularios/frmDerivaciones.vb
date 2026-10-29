Imports MySqlConnector

Public Class frmDerivaciones
    Private idDerivacionSelec As Integer = 0
    Private idMuestraOriginal As Integer = 0
    Private idDestinoOriginal As Integer = 0
    Private cargando As Boolean = False
    Private guardando As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("DERIVACIONES") Then
            Me.Close()
            Return False
        End If
        cboMuestra.Enabled = idDerivacionSelec = 0 AndAlso Not guardando
        cboCentroDestino.Enabled = idDerivacionSelec = 0 AndAlso Not guardando
        dtpFechaEnvio.Enabled = Not guardando
        dtpFechaRetorno.Enabled = Not guardando
        txtIdDerivacion.ReadOnly = True
        txtIdDerivacion.TabStop = False
        txtIdDerivacion.BackColor = SystemColors.Control
        btnGuardar.Visible = True
        btnGuardar.Enabled = idDerivacionSelec = 0 AndAlso Not guardando
        btnModificar.Visible = True
        btnModificar.Enabled = idDerivacionSelec > 0 AndAlso Not guardando
        btnNuevo.Enabled = Not guardando
        dgvDerivaciones.Enabled = Not guardando
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Envío y retorno administrativos; sin resultados clínicos")
        Return True
    End Function

    Private Sub frmDerivaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AplicarPermisos() Then Exit Sub
        cargando = True
        cboFiltroSeguimiento.Items.AddRange(New Object() {"TODAS", "PENDIENTE", "RETORNADA"})
        cboFiltroSeguimiento.SelectedIndex = 0
        If ObtenerDatosConexion() Then
            Try
                Using cn As New MySqlConnection(CADENA)
                    cn.Open()
                    Using cmd As New MySqlCommand("SELECT id_centro,nombre FROM centros_derivantes WHERE uso IN ('DESTINO','AMBOS') ORDER BY nombre;", cn)
                        Dim tabla As New DataTable
                        Using lector = cmd.ExecuteReader()
                            tabla.Load(lector)
                        End Using
                        Dim todas = tabla.NewRow()
                        todas("id_centro") = 0
                        todas("nombre") = "Todos los destinos"
                        tabla.Rows.InsertAt(todas, 0)
                        cboFiltroCentro.DataSource = tabla
                        cboFiltroCentro.DisplayMember = "nombre"
                        cboFiltroCentro.ValueMember = "id_centro"
                        cboFiltroCentro.SelectedValue = 0
                    End Using
                End Using
            Catch ex As Exception
                PresentacionSesion.MostrarError("No se pudieron cargar o procesar las derivaciones. Revisá los datos y volvé a intentar.", ex)
                lblPendiente.Text = "No se pudieron cargar los destinos del filtro."
            Finally
                CADENA = ""
            End Try
        End If
        cargando = False
        LimpiarForm()
        CargarGrilla()
    End Sub

    Private Sub frmDerivaciones_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        AplicarPermisos()
    End Sub

    Private Function CargarOpciones(Optional muestraActual As Integer = 0, Optional destinoActual As Integer = 0) As Boolean
        If Not Sesion.Puede("DERIVACIONES") Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT m.id_muestra,CONCAT(m.codigo,' - Orden ',m.id_orden) AS muestra FROM muestras m WHERE " &
                    "(m.estado<>'CERRADA' AND m.documentacion_completa=TRUE AND EXISTS (SELECT 1 FROM muestra_analisis ma WHERE ma.id_muestra=m.id_muestra) " &
                    "AND NOT EXISTS (SELECT 1 FROM derivaciones d WHERE d.id_muestra=m.id_muestra)) OR m.id_muestra=@actual ORDER BY m.codigo;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@actual", muestraActual)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboMuestra.DataSource = tabla
                    cboMuestra.DisplayMember = "muestra"
                    cboMuestra.ValueMember = "id_muestra"
                    cboMuestra.SelectedIndex = -1
                End Using
                sql = "SELECT id_centro,nombre FROM centros_derivantes WHERE (activo=TRUE AND uso IN ('DESTINO','AMBOS')) OR id_centro=@actual ORDER BY nombre;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@actual", destinoActual)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboCentroDestino.DataSource = tabla
                    cboCentroDestino.DisplayMember = "nombre"
                    cboCentroDestino.ValueMember = "id_centro"
                    cboCentroDestino.SelectedIndex = -1
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar las muestras o los destinos."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Public Sub LimpiarForm()
        If Not Sesion.Puede("DERIVACIONES") OrElse guardando Then Exit Sub
        cargando = True
        idDerivacionSelec = 0
        idMuestraOriginal = 0
        idDestinoOriginal = 0
        txtIdDerivacion.Clear()
        lblDatosMuestra.Text = "Seleccioná una muestra para ver contenedor, paciente y sus estudios."
        dtpFechaEnvio.Value = Date.Now
        dtpFechaRetorno.Value = Date.Now
        dtpFechaRetorno.Checked = False
        MostrarRetorno()
        CargarOpciones()
        dgvDerivaciones.ClearSelection()
        cargando = False
        AplicarPermisos()
    End Sub

    Public Function MostrarDatosMuestra(id As Integer) As Boolean
        If Not Sesion.Puede("DERIVACIONES") OrElse id <= 0 Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT m.codigo,m.id_orden,CONCAT(p.apellido,', ',p.nombre) AS paciente FROM muestras m INNER JOIN ordenes o ON o.id_orden=m.id_orden INNER JOIN pacientes p ON p.id_paciente=o.id_paciente WHERE m.id_muestra=@id;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using lector = cmd.ExecuteReader()
                        If Not lector.Read() Then Return False
                        lblDatosMuestra.Text = "Contenedor: " & lector("codigo").ToString() & vbCrLf & "Paciente: " & lector("paciente").ToString() & vbCrLf & "Orden: " & lector("id_orden").ToString()
                    End Using
                End Using
                sql = "SELECT a.nombre FROM muestra_analisis ma INNER JOIN analisis a ON a.id_analisis=ma.id_analisis WHERE ma.id_muestra=@id ORDER BY a.nombre;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim nombres As New List(Of String)
                    Using lector = cmd.ExecuteReader()
                        While lector.Read()
                            nombres.Add(lector("nombre").ToString())
                        End While
                    End Using
                    lblDatosMuestra.Text &= vbCrLf & "Estudios de la muestra: " & String.Join("; ", nombres)
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo consultar el paciente y los estudios de la muestra."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub cboMuestra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMuestra.SelectedIndexChanged
        Try
            If cargando Then Exit Sub
            Dim fila = TryCast(cboMuestra.SelectedItem, DataRowView)
            If fila IsNot Nothing Then MostrarDatosMuestra(CInt(fila("id_muestra")))
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Public Function CargarDerivacion(id As Integer) As Boolean
        If Not Sesion.Puede("DERIVACIONES") OrElse id <= 0 Then Return False
        If Not ObtenerDatosConexion() Then Return False
        cargando = True
        Try
            Dim tabla As New DataTable
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_derivacion,id_muestra,id_centro_destino,fecha_envio,fecha_retorno FROM derivaciones WHERE id_derivacion=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                End Using
            End Using
            If tabla.Rows.Count <> 1 Then Return False
            Dim fila = tabla.Rows(0)
            idDerivacionSelec = id
            idMuestraOriginal = CInt(fila("id_muestra"))
            idDestinoOriginal = CInt(fila("id_centro_destino"))
            If Not CargarOpciones(idMuestraOriginal, idDestinoOriginal) Then Return False
            txtIdDerivacion.Text = id.ToString()
            cboMuestra.SelectedValue = idMuestraOriginal
            cboCentroDestino.SelectedValue = idDestinoOriginal
            dtpFechaEnvio.Value = CDate(fila("fecha_envio"))
            dtpFechaRetorno.Checked = Not IsDBNull(fila("fecha_retorno"))
            If dtpFechaRetorno.Checked Then dtpFechaRetorno.Value = CDate(fila("fecha_retorno"))
            MostrarRetorno()
            MostrarDatosMuestra(idMuestraOriginal)
            AplicarPermisos()
            lblPendiente.Text = "Derivación seleccionada. El contenedor y destino históricos se conservan."
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar los datos de la derivación."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("DERIVACIONES") Then Return False
        If dtpFiltroDesde.Checked AndAlso dtpFiltroHasta.Checked AndAlso dtpFiltroDesde.Value.Date > dtpFiltroHasta.Value.Date Then
            lblPendiente.Text = "La fecha Desde no puede ser posterior a Hasta."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        cargando = True
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT d.id_derivacion,m.codigo,c.nombre AS destino,d.fecha_envio,d.fecha_retorno," &
                    "CASE WHEN d.fecha_retorno IS NULL THEN 'PENDIENTE' ELSE 'RETORNADA' END AS seguimiento " &
                    "FROM derivaciones d INNER JOIN muestras m ON m.id_muestra=d.id_muestra INNER JOIN centros_derivantes c ON c.id_centro=d.id_centro_destino " &
                    "WHERE (m.codigo LIKE @filtro OR c.nombre LIKE @filtro) AND (@centro=0 OR d.id_centro_destino=@centro) " &
                    "AND (@usarDesde=FALSE OR d.fecha_envio>=@desde) AND (@usarHasta=FALSE OR d.fecha_envio<@hasta) " &
                    "AND (@seguimiento='TODAS' OR (@seguimiento='PENDIENTE' AND d.fecha_retorno IS NULL) OR (@seguimiento='RETORNADA' AND d.fecha_retorno IS NOT NULL)) " &
                    "ORDER BY d.fecha_envio DESC,d.id_derivacion DESC;"
                Using cmd As New MySqlCommand(sql, cn)
                    Dim centro As Integer = 0
                    If cboFiltroCentro.SelectedValue IsNot Nothing Then Integer.TryParse(cboFiltroCentro.SelectedValue.ToString(), centro)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    cmd.Parameters.AddWithValue("@centro", centro)
                    cmd.Parameters.AddWithValue("@usarDesde", dtpFiltroDesde.Checked)
                    cmd.Parameters.AddWithValue("@usarHasta", dtpFiltroHasta.Checked)
                    cmd.Parameters.AddWithValue("@desde", dtpFiltroDesde.Value.Date)
                    cmd.Parameters.AddWithValue("@hasta", dtpFiltroHasta.Value.Date.AddDays(1))
                    cmd.Parameters.AddWithValue("@seguimiento", If(cboFiltroSeguimiento.SelectedIndex < 0, "TODAS", cboFiltroSeguimiento.Text))
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvDerivaciones.DataSource = tabla
                    dgvDerivaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    dgvDerivaciones.Columns("id_derivacion").Visible = False
                    dgvDerivaciones.Columns("codigo").HeaderText = "Contenedor"
                    dgvDerivaciones.Columns("destino").HeaderText = "Centro de destino"
                    dgvDerivaciones.Columns("seguimiento").HeaderText = "Seguimiento"
                    dgvDerivaciones.Columns("fecha_envio").HeaderText = "Envío"
                    dgvDerivaciones.Columns("fecha_envio").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
                    dgvDerivaciones.Columns("fecha_retorno").HeaderText = "Retorno"
                    dgvDerivaciones.Columns("fecha_retorno").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
                    dgvDerivaciones.Columns("fecha_retorno").DefaultCellStyle.NullValue = "Pendiente"
                    dgvDerivaciones.ClearSelection()
                    lblPendiente.Text = "Derivaciones encontradas: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo consultar las derivaciones."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Private Sub dgvDerivaciones_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDerivaciones.SelectionChanged
        Try
            If cargando OrElse dgvDerivaciones.SelectedRows.Count <> 1 Then Exit Sub
            CargarDerivacion(CInt(dgvDerivaciones.SelectedRows(0).Cells("id_derivacion").Value))
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Public Function ValidarCampos() As Boolean
        If Not Sesion.Puede("DERIVACIONES") OrElse guardando Then Return False
        If cboMuestra.SelectedIndex < 0 OrElse cboCentroDestino.SelectedIndex < 0 Then
            lblPendiente.Text = "Seleccioná una muestra y un centro de destino válido."
            Return False
        End If
        If dtpFechaRetorno.Checked AndAlso dtpFechaRetorno.Value < dtpFechaEnvio.Value Then
            lblPendiente.Text = "El retorno no puede ser anterior al envío."
            Return False
        End If
        If idDerivacionSelec > 0 AndAlso (CInt(cboMuestra.SelectedValue) <> idMuestraOriginal OrElse CInt(cboCentroDestino.SelectedValue) <> idDestinoOriginal) Then
            lblPendiente.Text = "La muestra y el destino históricos se conservan; solo se actualizan sus fechas."
            Return False
        End If
        Return True
    End Function

    Private Sub GuardarDerivacion(modificar As Boolean)
        If Not Sesion.Puede("DERIVACIONES") Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        If modificar <> (idDerivacionSelec > 0) OrElse Not ValidarCampos() Then Exit Sub
        If Not PresentacionSesion.Confirmar("¿Confirmás el envío o la actualización de fechas y seguimiento de esta derivación?") Then
            lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then Exit Sub
        Dim idMuestra As Integer = CInt(cboMuestra.SelectedValue)
        Dim idDestino As Integer = CInt(cboCentroDestino.SelectedValue)
        guardando = True
        AplicarPermisos()
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Try
                        Dim muestra As New DataTable
                        Using cmd As New MySqlCommand("SELECT fecha_recepcion,estado,documentacion_completa FROM muestras WHERE id_muestra=@id FOR UPDATE;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", idMuestra)
                            Using lector = cmd.ExecuteReader()
                                muestra.Load(lector)
                            End Using
                        End Using
                        If muestra.Rows.Count <> 1 Then Throw New InvalidOperationException()
                        Dim fila = muestra.Rows(0)
                        If dtpFechaEnvio.Value < CDate(fila("fecha_recepcion")) Then
                            tx.Rollback()
                            lblPendiente.Text = "El envío no puede ser anterior a la recepción de la muestra."
                            Return
                        End If
                        If (Not modificar AndAlso fila("estado").ToString() = "CERRADA") OrElse (fila("estado").ToString() = "CERRADA" AndAlso Not dtpFechaRetorno.Checked) Then
                            tx.Rollback()
                            lblPendiente.Text = "Una muestra cerrada no admite un nuevo envío ni una derivación pendiente."
                            Return
                        End If
                        If Not CBool(fila("documentacion_completa")) Then
                            tx.Rollback()
                            lblPendiente.Text = "Completá la documentación administrativa antes de derivar."
                            Return
                        End If
                        Using cmd As New MySqlCommand("SELECT COUNT(*) FROM muestra_analisis WHERE id_muestra=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", idMuestra)
                            If CInt(cmd.ExecuteScalar()) = 0 Then Throw New InvalidOperationException()
                        End Using
                        If modificar Then
                            Dim datos As New DataTable
                            Using cmd As New MySqlCommand("SELECT id_muestra,id_centro_destino FROM derivaciones WHERE id_derivacion=@id FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@id", idDerivacionSelec)
                                Using lector = cmd.ExecuteReader()
                                    datos.Load(lector)
                                End Using
                            End Using
                            If datos.Rows.Count <> 1 OrElse CInt(datos.Rows(0)("id_muestra")) <> idMuestraOriginal OrElse CInt(datos.Rows(0)("id_centro_destino")) <> idDestinoOriginal Then Throw New InvalidOperationException()
                        Else
                            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM centros_derivantes WHERE id_centro=@id AND activo=TRUE AND uso IN ('DESTINO','AMBOS');", cn, tx)
                                cmd.Parameters.AddWithValue("@id", idDestino)
                                If CInt(cmd.ExecuteScalar()) <> 1 Then Throw New InvalidOperationException()
                            End Using
                        End If
                        Dim sql As String
                        If modificar Then
                            sql = "UPDATE derivaciones SET fecha_envio=@envio,fecha_retorno=@retorno WHERE id_derivacion=@id;"
                        Else
                            sql = "INSERT INTO derivaciones(id_muestra,id_centro_destino,fecha_envio,fecha_retorno) VALUES(@muestra,@destino,@envio,@retorno);"
                        End If
                        Using cmd As New MySqlCommand(sql, cn, tx)
                            cmd.Parameters.AddWithValue("@envio", dtpFechaEnvio.Value)
                            cmd.Parameters.AddWithValue("@retorno", If(dtpFechaRetorno.Checked, CObj(dtpFechaRetorno.Value), DBNull.Value))
                            If modificar Then
                                cmd.Parameters.AddWithValue("@id", idDerivacionSelec)
                            Else
                                cmd.Parameters.AddWithValue("@muestra", idMuestra)
                                cmd.Parameters.AddWithValue("@destino", idDestino)
                            End If
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException()
                        End Using
                        tx.Commit()
                    Catch ex As Exception
                        PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            guardando = False
            LimpiarForm()
            If CargarGrilla(txtFiltro.Text) Then lblPendiente.Text = "Derivación guardada correctamente."
        Catch ex As MySqlException
            PresentacionSesion.MostrarError("No se pudo completar el guardado de las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = If(ex.Number = 1062, "La muestra ya tiene una derivación. No se registró otra.", "No se pudo confirmar el guardado. Revisá las fechas y el listado antes de reintentar.")
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de las derivaciones. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo confirmar el guardado. Revisá los datos y el listado antes de reintentar."
        Finally
            guardando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Sub

    Private Sub MostrarRetorno()
        dtpFechaRetorno.CustomFormat = If(dtpFechaRetorno.Checked, "dd/MM/yyyy HH:mm:ss", "'Pendiente'")
    End Sub

    Private Sub dtpFechaRetorno_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaRetorno.ValueChanged
        MostrarRetorno()
    End Sub

    Private Sub dtpFechaRetorno_MouseUp(sender As Object, e As MouseEventArgs) Handles dtpFechaRetorno.MouseUp
        MostrarRetorno()
    End Sub

    Private Sub dtpFechaRetorno_KeyUp(sender As Object, e As KeyEventArgs) Handles dtpFechaRetorno.KeyUp
        MostrarRetorno()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarDerivacion(False)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        GuardarDerivacion(True)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarForm()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        txtFiltro.Clear()
        cboFiltroCentro.SelectedValue = 0
        cboFiltroSeguimiento.SelectedItem = "TODAS"
        dtpFiltroDesde.Checked = False
        dtpFiltroHasta.Checked = False
        CargarGrilla()
    End Sub

    Private Sub frmDerivaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
