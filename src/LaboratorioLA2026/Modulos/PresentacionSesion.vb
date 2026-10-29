Module PresentacionSesion
    Public Sub RegistrarError(ex As Exception)
        'dejo tipo y ubicacion para depurar, sin datos ni credenciales
        System.Diagnostics.Debug.WriteLine(ex.GetType().FullName & " · Código " & ex.HResult.ToString())
        If TypeOf ex Is MySqlConnector.MySqlException Then System.Diagnostics.Debug.WriteLine("MariaDB: " & DirectCast(ex, MySqlConnector.MySqlException).Number.ToString())
        System.Diagnostics.Debug.WriteLine(ex.StackTrace)
    End Sub

    Public Sub MostrarError(mensaje As String, ex As Exception)
        RegistrarError(ex)
        MessageBox.Show(mensaje, "L&A | Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub CancelarTransaccion(tx As MySqlConnector.MySqlTransaction)
        Try
            tx.Rollback()
        Catch ex As Exception
            MostrarError("No se pudo confirmar la cancelación. Revisá los datos antes de reintentar.", ex)
        End Try
    End Sub

    Public Function ColorRol() As Color
        If Sesion.rolUsuario = "RECEPCIONISTA" Then Return Color.FromArgb(35, 91, 145)
        If Sesion.rolUsuario = "TECNICO" Then Return Color.FromArgb(39, 106, 76)
        Return Color.FromArgb(157, 43, 59)
    End Function

    Public Function AreaRol() As String
        If Sesion.rolUsuario = "ADMIN" Then Return "ADMINISTRACIÓN GENERAL"
        If Sesion.rolUsuario = "RECEPCIONISTA" Then Return "RECEPCIÓN"
        If Sesion.rolUsuario = "TECNICO" Then Return "ÁREA TÉCNICA"
        Return "SIN SESIÓN"
    End Function

    Public Sub MostrarRol(encabezado As Panel, etiqueta As Label, modo As String)
        'solo cambio la presentacion; los permisos se comprueban en los eventos
        encabezado.BackColor = ColorRol()
        etiqueta.ForeColor = ColorRol()
        etiqueta.Text = Sesion.rolUsuario & " · " & AreaRol() & " · " & modo
    End Sub

    Public Function Confirmar(mensaje As String) As Boolean
        Return MessageBox.Show(mensaje, "L&A | Confirmar", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
    End Function

    Public Sub EjecutarEnter(formulario As Form, e As KeyEventArgs, buscar As Button, guardar As Button, modificar As Button)
        If e.KeyCode <> Keys.Enter Then Exit Sub
        'en listas, tablas y campos multilinea no disparo el guardado
        Dim campo As TextBox = TryCast(formulario.ActiveControl, TextBox)
        If campo Is Nothing OrElse campo.Multiline Then Exit Sub
        If campo.Name = "txtFiltro" Then
            If buscar IsNot Nothing AndAlso buscar.Enabled Then
                e.SuppressKeyPress = True
                buscar.PerformClick()
            End If
            Exit Sub
        End If
        If campo.ReadOnly Then Exit Sub
        Dim accion As Button = Nothing
        If modificar IsNot Nothing AndAlso modificar.Visible AndAlso modificar.Enabled Then
            accion = modificar
        ElseIf guardar IsNot Nothing AndAlso guardar.Visible AndAlso guardar.Enabled Then
            accion = guardar
        End If
        If accion IsNot Nothing Then
            e.SuppressKeyPress = True
            accion.PerformClick()
        End If
    End Sub
End Module
