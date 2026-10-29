Public Class frmPrincipal
    Private Sub frmPrincipal_Activated(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Activated
        If Not Sesion.Autenticado() Then
            Me.Close()
            Exit Sub
        End If
        lblUsuario.Text = "Usuario: " & Sesion.NombreCompleto
        lblRol.Text = Sesion.rolUsuario
        lblRol.ForeColor = PresentacionSesion.ColorRol()
        lblArea.Text = PresentacionSesion.AreaRol()
        lblArea.ForeColor = PresentacionSesion.ColorRol()
        PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Elegí un módulo habilitado para tu tarea.")
        btnPacientes.Enabled = Sesion.Puede("CONSULTAR_PACIENTES")
        btnPacientes.Visible = Sesion.Puede("CONSULTAR_PACIENTES")
        btnAnalisis.Enabled = Sesion.Puede("ADMIN_CATALOGOS")
        btnAnalisis.Visible = Sesion.Puede("ADMIN_CATALOGOS")
        btnOrdenes.Enabled = Sesion.Puede("CONSULTAR_ORDENES")
        btnOrdenes.Visible = Sesion.Puede("CONSULTAR_ORDENES")
        btnMuestras.Enabled = Sesion.Puede("CONSULTAR_MUESTRAS")
        btnMuestras.Visible = Sesion.Puede("CONSULTAR_MUESTRAS")
        btnDerivaciones.Enabled = Sesion.Puede("DERIVACIONES")
        btnDerivaciones.Visible = Sesion.Puede("DERIVACIONES")
        btnCentros.Enabled = Sesion.Puede("ADMIN_CATALOGOS")
        btnCentros.Visible = Sesion.Puede("ADMIN_CATALOGOS")
        btnInsumos.Enabled = Sesion.Puede("CONSULTAR_INSUMOS")
        btnInsumos.Visible = Sesion.Puede("CONSULTAR_INSUMOS")
        btnMovimientosStock.Enabled = Sesion.Puede("MOVIMIENTOS_STOCK")
        btnMovimientosStock.Visible = Sesion.Puede("MOVIMIENTOS_STOCK")
        btnUsuarios.Enabled = Sesion.Puede("ADMIN_USUARIOS")
        btnUsuarios.Visible = Sesion.Puede("ADMIN_USUARIOS")
        btnFacturacion.Enabled = Sesion.Puede("COTIZAR_ORDENES")
        btnFacturacion.Visible = Sesion.Puede("COTIZAR_ORDENES")
        AcomodarModulos()
    End Sub

    Private Sub AcomodarModulos()
        Dim cantidad As Integer = 0
        For Each control As Control In flpModulos.Controls
            If TypeOf control Is Button AndAlso control.Enabled Then cantidad += 1
        Next
        If cantidad = 0 Then Exit Sub
        Dim columnas As Integer = Math.Max(1, Math.Min(3, (flpModulos.ClientSize.Width - 32) \ 260))
        Dim filas As Integer = CInt(Math.Ceiling(cantidad / CDbl(columnas)))
        Dim ancho As Integer = Math.Max(220, (flpModulos.ClientSize.Width - 32) \ columnas - 16)
        Dim alto As Integer = Math.Max(88, Math.Min(160, (flpModulos.ClientSize.Height - 32) \ filas - 16))
        For Each control As Control In flpModulos.Controls
            If TypeOf control Is Button AndAlso control.Enabled Then control.Size = New Size(ancho, alto)
        Next
    End Sub

    Private Sub flpModulos_SizeChanged(sender As Object, e As EventArgs) Handles flpModulos.SizeChanged
        AcomodarModulos()
    End Sub

    Private Sub btnPacientes_Click(sender As Object, e As EventArgs) Handles btnPacientes.Click
        If Not Sesion.Puede("CONSULTAR_PACIENTES") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmPacientes()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnFacturacion_Click(sender As Object, e As EventArgs) Handles btnFacturacion.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Exit Sub
        Try
            Using formulario As New frmFacturacion()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnAnalisis_Click(sender As Object, e As EventArgs) Handles btnAnalisis.Click
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmAnalisis()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnOrdenes_Click(sender As Object, e As EventArgs) Handles btnOrdenes.Click
        If Not Sesion.Puede("CONSULTAR_ORDENES") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmOrdenes()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnMuestras_Click(sender As Object, e As EventArgs) Handles btnMuestras.Click
        If Not Sesion.Puede("CONSULTAR_MUESTRAS") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmMuestras()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnDerivaciones_Click(sender As Object, e As EventArgs) Handles btnDerivaciones.Click
        If Not Sesion.Puede("DERIVACIONES") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmDerivaciones()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnCentros_Click(sender As Object, e As EventArgs) Handles btnCentros.Click
        If Not Sesion.Puede("ADMIN_CATALOGOS") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmCentros()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnInsumos_Click(sender As Object, e As EventArgs) Handles btnInsumos.Click
        If Not Sesion.Puede("CONSULTAR_INSUMOS") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmInsumos()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnMovimientosStock_Click(sender As Object, e As EventArgs) Handles btnMovimientosStock.Click
        If Not Sesion.Puede("MOVIMIENTOS_STOCK") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmMovimientosStock()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        If Not Sesion.Puede("ADMIN_USUARIOS") Then
            lblEstado.Text = "No tenés permiso para esta opción."
            Exit Sub
        End If
        Try
            Using formulario As New frmUsuarios()
                formulario.ShowDialog(Me)
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el módulo. Volvé a intentar desde el menú.", ex)
        End Try
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Sesion.CerrarSesion()
    End Sub
End Class
