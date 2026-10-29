Imports System.IO
Imports MySqlConnector

Module ConexionBD
    Public CADENA As String = ""
    Public MensajeConexion As String = ""

    Public Function ObtenerDatosConexion() As Boolean
        'leo la configuracion local, sin mostrar las credenciales
        CADENA = ""
        MensajeConexion = ""
        Try
            Dim rutaArchivo As String = Path.Combine(AppContext.BaseDirectory, "conexion.ini")
            If Not File.Exists(rutaArchivo) Then
                MensajeConexion = "Falta configurar conexion.ini. Ejecutá CONFIGURAR_CONEXION_LOCAL.ps1 y volvé a compilar."
                Return False
            End If
            Dim datos As New MySqlConnectionStringBuilder(File.ReadAllText(rutaArchivo).Trim())
            If datos.Server <> "127.0.0.1" OrElse datos.Port <> 3306 OrElse datos.Database <> "laboratorio_la_2026" Then
                MensajeConexion = "La configuración debe apuntar a 127.0.0.1:3306 y laboratorio_la_2026."
                Return False
            End If
            If datos.UserID.Trim() = "" Then
                MensajeConexion = "Falta indicar el usuario de MariaDB en la configuración local."
                Return False
            End If
            'limito la espera y cierro tambien la conexion fisica al terminar
            datos.ConnectionTimeout = 5
            datos.DefaultCommandTimeout = 5
            datos.Pooling = False
            datos.PersistSecurityInfo = False
            CADENA = datos.ConnectionString
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo leer la configuración local de conexión. Revisá el archivo sin compartir sus credenciales.", ex)
            MensajeConexion = "No se pudo leer la configuración local. Revisá el archivo sin compartir su contenido."
            Return False
        End Try
    End Function
End Module
