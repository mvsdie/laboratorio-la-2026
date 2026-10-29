Imports MySqlConnector

Public Class frmLogin
    Private Sub btnVerPantallas_Click(sender As Object, e As EventArgs) Handles btnVerPantallas.Click
        'la revision no abre el menu sin autenticacion
        lblResultadoConexion.Text = "Ingresá con tu usuario para acceder al sistema."
    End Sub

    Public Function Autenticar(usuario As String, clave As String) As Boolean
        Sesion.CerrarSesion()
        lblResultadoConexion.Text = ""
        If usuario.Trim() = "" OrElse clave = "" Then
            lblResultadoConexion.Text = "Completá usuario y contraseña."
            Return False
        End If
        If Not ObtenerDatosConexion() Then
            lblResultadoConexion.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT u.id_usuario, u.nombre_usuario, u.nombre_completo, " &
                    "u.password_hash, u.salt, r.nombre AS rol " &
                    "FROM usuarios u JOIN roles r ON u.id_rol=r.id_rol " &
                    "WHERE u.nombre_usuario=@usuario AND u.activo=TRUE;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@usuario", usuario.Trim())
                    Using lector = cmd.ExecuteReader()
                        If Not lector.Read() Then
                            lblResultadoConexion.Text = "Usuario o contraseña incorrectos."
                            Return False
                        End If
                        Dim hash As String = Seguridad.CrearHash(clave, lector("salt").ToString())
                        Dim rol As String = lector("rol").ToString()
                        If hash <> lector("password_hash").ToString() OrElse Not Sesion.RolValido(rol) Then
                            lblResultadoConexion.Text = "Usuario o contraseña incorrectos."
                            Return False
                        End If
                        'cargo la sesion solamente despues de comprobar la clave
                        Sesion.idUsuario = CInt(lector("id_usuario"))
                        Sesion.nombreUsuario = lector("nombre_usuario").ToString()
                        Sesion.NombreCompleto = lector("nombre_completo").ToString()
                        Sesion.rolUsuario = rol
                    End Using
                End Using
            End Using
            Return True
        Catch ex As FormatException
            PresentacionSesion.MostrarError("No se pudo completar el acceso. Revisá los datos y volvé a intentar.", ex)
            Sesion.CerrarSesion()
            lblResultadoConexion.Text = "Usuario o contraseña incorrectos."
            Return False
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el acceso. Revisá los datos y volvé a intentar.", ex)
            Sesion.CerrarSesion()
            lblResultadoConexion.Text = "No se pudo iniciar sesión. Revisá la conexión y volvé a intentar."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        btnIngresar.Enabled = False
        Try
            Dim valido As Boolean = Autenticar(txtUsuario.Text, txtClave.Text)
            txtClave.Clear()
            If Not valido Then Exit Sub
            'cierro la lectura antes de abrir el menu
            Me.Hide()
            Using principal As New frmPrincipal()
                principal.ShowDialog()
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo abrir el menú. Volvé a ingresar.", ex)
        Finally
            Sesion.CerrarSesion()
            txtClave.Clear()
            Me.Show()
            btnIngresar.Enabled = True
            txtUsuario.Focus()
        End Try
    End Sub

    Private Sub btnProbarConexion_Click(sender As Object, e As EventArgs) Handles btnProbarConexion.Click
        ProbarConexion()
    End Sub

    Sub ProbarConexion()
        lblResultadoConexion.Text = ""
        If Not ObtenerDatosConexion() Then
            lblResultadoConexion.Text = MensajeConexion
            Exit Sub
        End If

        btnProbarConexion.Enabled = False
        Try
            'abro la conexion y leo solamente metadatos de la base nueva
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim baseActual As String
                Using cmd As New MySqlCommand("SELECT DATABASE();", cn)
                    baseActual = CStr(cmd.ExecuteScalar())
                End Using
                If baseActual <> "laboratorio_la_2026" Then
                    lblResultadoConexion.Text = "La conexión no seleccionó la base esperada."
                    Exit Sub
                End If

                Dim sql As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES " &
                    "WHERE TABLE_SCHEMA=@base AND TABLE_TYPE='BASE TABLE';"
                Dim cantidad As Integer
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@base", "laboratorio_la_2026")
                    cantidad = CInt(cmd.ExecuteScalar())
                End Using

                'cierro antes de mostrar el resultado; Using libera ante cualquier error
                cn.Close()
                If cn.State = ConnectionState.Closed Then
                    lblResultadoConexion.Text = "Lectura correcta: " & cantidad.ToString() & " tablas visibles. Conexión cerrada."
                    If cantidad <> 17 Then
                        lblResultadoConexion.Text &= " Se esperaban 17; revisá estructura o permisos."
                    End If
                Else
                    lblResultadoConexion.Text = "No se pudo confirmar el cierre de la conexión."
                End If
            End Using
        Catch ex As MySqlException
            PresentacionSesion.MostrarError("No se pudo completar el acceso. Revisá los datos y volvé a intentar.", ex)
            'no muestro ex.Message porque puede incluir datos de acceso
            If ex.Number = 1045 OrElse ex.Number = 1044 OrElse ex.Number = 1142 Then
                lblResultadoConexion.Text = "Acceso rechazado. Revisá las credenciales locales y los permisos existentes."
            ElseIf ex.Number = 1049 Then
                lblResultadoConexion.Text = "No se encontró laboratorio_la_2026 en el servidor."
            Else
                lblResultadoConexion.Text = "No se pudo completar la conexión o lectura. Revisá MariaDB y la configuración local."
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el acceso. Revisá los datos y volvé a intentar.", ex)
            lblResultadoConexion.Text = "No se pudo completar la prueba de conexión. No se realizaron cambios."
        Finally
            CADENA = ""
            btnProbarConexion.Enabled = True
        End Try
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Sesion.CerrarSesion()
        txtClave.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Sesion.CerrarSesion()
        Me.Close()
    End Sub
End Class
