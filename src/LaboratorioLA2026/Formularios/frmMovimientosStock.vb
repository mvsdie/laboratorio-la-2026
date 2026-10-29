Imports MySqlConnector

Public Class frmMovimientosStock
    Private Sub frmMovimientosStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated
        If Not Sesion.Puede("MOVIMIENTOS_STOCK") Then
            Me.Close()
            Exit Sub
        End If
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Solo consulta; registro y modificación pendientes")
        'no habilito escrituras que todavia no estan implementadas
        btnGuardar.Enabled = False
        btnGuardar.Visible = Sesion.Puede("MOVIMIENTOS_STOCK")
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not Sesion.Puede("MOVIMIENTOS_STOCK") Then
            lblPendiente.Text = "No tenés permiso para esta operación."
            Exit Sub
        End If
        lblPendiente.Text = "Operación pendiente de implementación; no se guardaron cambios."
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmMovimientosStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrilla()
    End Sub

    Public Function CargarGrilla(Optional filtro As String = "") As Boolean
        If Not Sesion.Puede("MOVIMIENTOS_STOCK") Then Return False
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT ms.id_movimiento,i.nombre AS insumo,ms.tipo_movimiento,ms.cantidad,ms.fecha,ms.motivo,u.nombre_usuario AS responsable FROM movimientos_stock ms INNER JOIN insumos i ON i.id_insumo=ms.id_insumo INNER JOIN usuarios u ON u.id_usuario=ms.id_usuario WHERE i.nombre LIKE @filtro OR ms.tipo_movimiento LIKE @filtro OR ms.motivo LIKE @filtro ORDER BY ms.fecha DESC,ms.id_movimiento DESC;", cn)
                    cmd.Parameters.AddWithValue("@filtro", "%" & filtro.Trim() & "%")
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvMovimientosStock.DataSource = tabla
                    dgvMovimientosStock.Enabled = True
                    dgvMovimientosStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
                    For Each columna As DataGridViewColumn In dgvMovimientosStock.Columns
                        columna.HeaderText = columna.Name.Replace("_", " ")
                        columna.MinimumWidth = 80
                        If columna.ValueType = GetType(DateTime) Then columna.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                    Next
                    dgvMovimientosStock.ClearSelection()
                    lblPendiente.Text = "Registros encontrados: " & tabla.Rows.Count.ToString() & ". Solo consulta; no se guardaron cambios."
                End Using
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los movimientos. Revisá los datos y volvé a intentar.", ex)
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
    Private Sub frmMovimientosStock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, btnBuscar, btnGuardar, Nothing)
    End Sub
End Class
