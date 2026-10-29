Imports MySqlConnector

Public Class frmAnalisis
    Private idSelec As Integer = 0
    Private cargandoGrilla As Boolean = False

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            Me.Close()
            Return False
        End If
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Administración de análisis; activar o desactivar sin eliminar")
        txtIdAnalisis.Enabled = True
        txtIdAnalisis.ReadOnly = True
        txtNombre.Enabled = True
        chkActivo.Enabled = True
        dgvAnalisis.Enabled = True
        btnGuardar.Visible = True
        btnModificar.Visible = True
        btnGuardar.Enabled = idSelec = 0
        btnModificar.Enabled = idSelec > 0
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
        Return True
    End Function

    Private Sub frmAnalisis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AplicarPermisos() Then Exit Sub
        LimpiarForm()
        CargarGrilla()
    End Sub

    Private Sub frmAnalisis_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
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
                Dim sql As String = "SELECT id_analisis,nombre,activo,codigo_nbu,ub_nbu,version_nbu,material,CASE WHEN activo=TRUE THEN 'ACTIVO' ELSE 'INACTIVO' END AS estado FROM analisis " &
                    "WHERE nombre LIKE @filtro ORDER BY nombre,id_analisis;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cargandoGrilla = True
                    dgvAnalisis.DataSource = tabla
                    dgvAnalisis.Columns("id_analisis").HeaderText = "ID"
                    dgvAnalisis.Columns("nombre").HeaderText = "Nombre"
                    dgvAnalisis.Columns("activo").Visible = False
                    dgvAnalisis.Columns("id_analisis").Visible = False
                    dgvAnalisis.Columns("version_nbu").Visible = False
                    dgvAnalisis.Columns("material").Visible = False
                    dgvAnalisis.Columns("codigo_nbu").HeaderText = "Código NBU"
                    dgvAnalisis.Columns("nombre").HeaderText = "Nombre"
                    dgvAnalisis.Columns("ub_nbu").HeaderText = "Unidades Bioquímicas (UB)"
                    dgvAnalisis.Columns("estado").HeaderText = "Estado"
                    dgvAnalisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                    dgvAnalisis.Columns("codigo_nbu").Width = 100
                    dgvAnalisis.Columns("ub_nbu").Width = 190
                    dgvAnalisis.Columns("estado").Width = 90
                    dgvAnalisis.Columns("nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    dgvAnalisis.Columns("nombre").MinimumWidth = 200
                    dgvAnalisis.Columns("codigo_nbu").DisplayIndex = 0
                    dgvAnalisis.Columns("nombre").DisplayIndex = 1
                    dgvAnalisis.Columns("ub_nbu").DisplayIndex = 2
                    dgvAnalisis.Columns("estado").DisplayIndex = 3
                    dgvAnalisis.Columns("ub_nbu").DefaultCellStyle.Format = "0.##"
                    dgvAnalisis.DefaultCellStyle.NullValue = "Sin dato"
                    dgvAnalisis.Columns("nombre").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    dgvAnalisis.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    LimpiarForm()
                    lblPendiente.Text = "Registros encontrados: " & tabla.Rows.Count.ToString()
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los análisis. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo cargar el catálogo. Revisá la conexión."
            Return False
        Finally
            cargandoGrilla = False
            CADENA = ""
        End Try
    End Function

    Public Sub LimpiarForm()
        idSelec = 0
        txtIdAnalisis.Clear()
        txtNombre.Clear()
        chkActivo.Checked = True
        dgvAnalisis.ClearSelection()
        AplicarPermisos()
    End Sub

    Private Sub dgvAnalisis_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAnalisis.SelectionChanged
        If cargandoGrilla OrElse Not Sesion.Puede("ADMIN_CATALOGOS") Then Exit Sub
        If dgvAnalisis.SelectedRows.Count <> 1 Then Exit Sub
        Try
            Dim fila = dgvAnalisis.SelectedRows(0)
            If fila.IsNewRow Then Exit Sub
            txtNombre.Text = fila.Cells("nombre").Value.ToString()
            chkActivo.Checked = CBool(fila.Cells("activo").Value)
            idSelec = CInt(fila.Cells("id_analisis").Value)
            txtIdAnalisis.Text = idSelec.ToString()
            AplicarPermisos()
            lblPendiente.Text = "Registro seleccionado. Modificar guarda los datos y el estado Activo."
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los análisis. Revisá los datos y volvé a intentar.", ex)
            LimpiarForm()
            lblPendiente.Text = "No se pudieron mostrar los datos seleccionados."
        End Try
    End Sub

    Public Function ValidarCampos() As Boolean
        If txtNombre.Text.Trim() = "" Then
            lblPendiente.Text = "Completá el nombre."
            Return False
        End If
        If txtNombre.Text.Trim().Length > 100 Then
            lblPendiente.Text = "El nombre supera los 100 caracteres."
            Return False
        End If
        Return True
    End Function

    Private Function NombreDuplicado(cn As MySqlConnection, idExcluir As Integer) As Boolean
        Using cmd As New MySqlCommand("SELECT COUNT(*) FROM analisis WHERE nombre=@nombre AND id_analisis<>@id;", cn)
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
            cmd.Parameters.AddWithValue("@id", idExcluir)
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
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
                Dim idExcluir As Integer = 0
                If modificar Then idExcluir = idSelec
                If NombreDuplicado(cn, idExcluir) Then
                    lblPendiente.Text = "Ya existe un análisis con ese nombre, incluso si está inactivo."
                    Exit Sub
                End If
                Dim sql As String
                If modificar Then
                    sql = "UPDATE analisis SET nombre=@nombre,activo=@activo WHERE id_analisis=@id;"
                Else
                    sql = "INSERT INTO analisis (nombre,activo) VALUES (@nombre,@activo);"
                End If
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@activo", chkActivo.Checked)
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
            PresentacionSesion.MostrarError("No se pudo completar el guardado de los análisis. Revisá los datos y volvé a intentar.", ex)
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
    Private Sub frmAnalisis_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub
End Class
