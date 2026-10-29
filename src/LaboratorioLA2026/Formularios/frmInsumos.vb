Imports MySqlConnector

Public Class frmInsumos
    Private Sub frmInsumos_Activated(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated
        If Not Sesion.Puede("CONSULTAR_INSUMOS") Then
            Me.Close()
            Exit Sub
        End If
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Solo consulta; registro y modificación pendientes")
        'no habilito escrituras que todavia no estan implementadas
        btnGuardar.Enabled = False
        btnGuardar.Visible = Sesion.Puede("ADMIN_CATALOGOS")
        btnModificar.Enabled = False
        btnModificar.Visible = Sesion.Puede("ADMIN_CATALOGOS")
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        lblPendiente.Text = "Operación pendiente de implementación; no se guardaron cambios."
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        lblPendiente.Text = "Operación pendiente de implementación; no se guardaron cambios."
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Not Sesion.Puede("BAJAS") Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        lblPendiente.Text = "Operación pendiente de implementación; no se guardaron cambios."
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmInsumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
    End Sub

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("CONSULTAR_INSUMOS") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_insumo,nombre,descripcion,unidad_medida,stock_actual,stock_minimo,activo,CASE WHEN stock_actual=0 THEN 'AGOTADO' WHEN stock_actual<stock_minimo THEN 'BAJO MINIMO' ELSE 'NORMAL' END AS situacion FROM insumos WHERE nombre LIKE @filtro OR descripcion LIKE @filtro ORDER BY nombre,id_insumo;", cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvInsumos.DataSource = tabla
                    dgvInsumos.Enabled = True
                    dgvInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    For Each columna As DataGridViewColumn In dgvInsumos.Columns
                        columna.HeaderText = columna.Name.Replace("_", " ")
                        columna.MinimumWidth = 80
                        If columna.ValueType = GetType(DateTime) Then columna.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                    Next
                    dgvInsumos.ClearSelection()
                    lblPendiente.Text = "Registros encontrados: " & tabla.Rows.Count.ToString() & ". Solo consulta; no se guardaron cambios."
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los insumos. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo consultar el listado. Revisá la conexión."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarGrilla(txtFiltro.Text)
    End Sub

    Private Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        txtFiltro.Clear()
        CargarGrilla()
    End Sub
    Private Sub frmInsumos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, btnModificar)
    End Sub
End Class
