Module Sesion
    Public idUsuario As Integer = 0
    Public nombreUsuario As String = ""
    Public rolUsuario As String = ""
    Public NombreCompleto As String = ""

    Public Function Autenticado() As Boolean
        Return idUsuario > 0 AndAlso RolValido(rolUsuario)
    End Function

    Public Function RolValido(rol As String) As Boolean
        Return rol = "ADMIN" OrElse rol = "RECEPCIONISTA" OrElse rol = "TECNICO"
    End Function

    Public Function Puede(operacion As String) As Boolean
        If Not Autenticado() Then Return False
        If EsAdmin() Then Return True
        If rolUsuario = "RECEPCIONISTA" Then
            Return operacion = "CONSULTAR_PACIENTES" OrElse operacion = "REGISTRAR_PACIENTES" OrElse
                operacion = "MODIFICAR_PACIENTES" OrElse operacion = "CONSULTAR_ORDENES" OrElse
                operacion = "CREAR_ORDENES" OrElse operacion = "CONSULTAR_MUESTRAS" OrElse
                operacion = "REGISTRAR_MUESTRAS" OrElse operacion = "DERIVACIONES" OrElse
                operacion = "COTIZAR_ORDENES"
        End If
        If rolUsuario = "TECNICO" Then
            Return operacion = "CONSULTAR_PACIENTES" OrElse operacion = "CONSULTAR_ORDENES" OrElse
                operacion = "CONSULTAR_MUESTRAS" OrElse operacion = "REGISTRAR_MUESTRAS" OrElse
                operacion = "ACTUALIZAR_MUESTRAS" OrElse operacion = "DERIVACIONES" OrElse
                operacion = "CONSULTAR_INSUMOS" OrElse operacion = "MOVIMIENTOS_STOCK"
        End If
        Return False
    End Function

    Public Function EsAdmin() As Boolean
        Return Autenticado() AndAlso rolUsuario = "ADMIN"
    End Function

    Public Sub CerrarSesion()
        'limpio la sesion antes de cerrar las ventanas operativas
        idUsuario = 0
        nombreUsuario = ""
        rolUsuario = ""
        NombreCompleto = ""
        Dim ventanas As New List(Of Form)
        For Each ventana As Form In Application.OpenForms
            If Not TypeOf ventana Is frmLogin Then ventanas.Add(ventana)
        Next
        For Each ventana As Form In ventanas
            If Not ventana.IsDisposed Then ventana.Close()
        Next
    End Sub
End Module
