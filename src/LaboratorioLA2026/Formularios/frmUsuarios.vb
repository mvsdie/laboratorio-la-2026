Imports MySqlConnector

Public Class frmUsuarios
    Public PreparacionInicial As Boolean = False
    Private idUsuarioSelec As Integer = 0
    Private pasoInicial As Integer = 0
    Private usuariosIniciales() As String = {"admin", "recepcion", "tecnico"}
    Private rolesIniciales() As String = {"ADMIN", "RECEPCIONISTA", "TECNICO"}
    Private nombresIniciales(2) As String
    Private clavesIniciales(2) As String
    Private idsIniciales(2) As Integer

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not PreparacionInicial AndAlso Not Sesion.EsAdmin() Then
            Me.Close()
            Exit Sub
        End If
        txtNombreCompleto.Enabled = True
        txtUsuario.Enabled = True
        txtClave.Enabled = True
        btnGuardar.Enabled = True
        cboRol.Enabled = Not PreparacionInicial
        If PreparacionInicial Then
            lblEstado.Text = "Preparación autorizada: exactamente tres roles y tres cuentas."
            btnModificar.Visible = False
            chkActivo.Visible = False
            For Each rol As String In rolesIniciales
                cboRol.Items.Add(rol)
            Next
            txtUsuario.ReadOnly = True
            MostrarPasoInicial()
            If Not BaseVacia() Then btnGuardar.Enabled = False
        Else
            PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Administración de usuarios y asignación de roles")
            btnGuardar.Visible = Sesion.EsAdmin()
            btnModificar.Visible = Sesion.EsAdmin()
            lblPendiente.Text = "Solo ADMIN administra usuarios. No se muestran claves ni hashes."
            chkActivo.Enabled = True
            chkActivo.Checked = True
            CargarRoles()
            CargarUsuarios()
        End If
    End Sub

    Private Sub frmUsuarios_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Not PreparacionInicial Then
            If Not Sesion.EsAdmin() Then
                Me.Close()
                Exit Sub
            End If
            PresentacionSesion.MostrarRol(pnlEncabezado, lblEstado, "Administración de usuarios y asignación de roles")
        End If
    End Sub

    Private Sub MostrarPasoInicial()
        txtUsuario.Text = usuariosIniciales(pasoInicial)
        txtNombreCompleto.Text = "Cuenta de prueba " & rolesIniciales(pasoInicial)
        cboRol.SelectedIndex = pasoInicial
        txtClave.Clear()
        btnGuardar.Text = If(pasoInicial < 2, "Continuar", "Crear las tres")
        lblPendiente.Text = "Paso " & (pasoInicial + 1).ToString() & " de 3. Elegí la contraseña local de " & usuariosIniciales(pasoInicial) & "."
    End Sub

    Private Function BaseVacia() As Boolean
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                For Each tabla As String In {"roles", "usuarios"}
                    Using cmd As New MySqlCommand("SELECT COUNT(*) FROM " & tabla & ";", cn)
                        If CInt(cmd.ExecuteScalar()) <> 0 Then
                            lblPendiente.Text = "DETENIDO: ya existen roles o usuarios. No se modificó nada."
                            Return False
                        End If
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo comprobar la base. No se creó ninguna cuenta."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Sub CargarRoles()
        If Not Sesion.EsAdmin() Then Exit Sub
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT id_rol, nombre FROM roles WHERE nombre IN ('ADMIN','RECEPCIONISTA','TECNICO') ORDER BY nombre;"
                Using cmd As New MySqlCommand(sql, cn)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    cboRol.DisplayMember = "nombre"
                    cboRol.ValueMember = "id_rol"
                    cboRol.DataSource = tabla
                End Using
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron cargar los roles. Revisá la conexión."
        Finally
            CADENA = ""
        End Try
    End Sub

    Sub CargarUsuarios()
        If Not Sesion.EsAdmin() Then Exit Sub
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "SELECT u.id_usuario,u.nombre_usuario,u.nombre_completo,u.id_rol,r.nombre AS rol,u.activo " &
                    "FROM usuarios u JOIN roles r ON u.id_rol=r.id_rol ORDER BY u.nombre_usuario;"
                Using cmd As New MySqlCommand(sql, cn)
                    Dim tabla As New DataTable
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                    dgvUsuarios.DataSource = tabla
                    dgvUsuarios.Enabled = True
                    dgvUsuarios.Columns("id_rol").Visible = False
                End Using
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo cargar el listado de usuarios."
        Finally
            CADENA = ""
        End Try
    End Sub

    Private Sub dgvUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        Try
            If Not Sesion.EsAdmin() OrElse PreparacionInicial OrElse e.RowIndex < 0 Then Exit Sub
            Dim fila = dgvUsuarios.Rows(e.RowIndex)
            idUsuarioSelec = CInt(fila.Cells("id_usuario").Value)
            txtUsuario.Text = fila.Cells("nombre_usuario").Value.ToString()
            txtNombreCompleto.Text = fila.Cells("nombre_completo").Value.ToString()
            cboRol.SelectedValue = CInt(fila.Cells("id_rol").Value)
            chkActivo.Checked = CBool(fila.Cells("activo").Value)
            txtClave.Clear()
            btnModificar.Enabled = True
            lblPendiente.Text = "Modificar actualiza el usuario seleccionado. Clave vacía conserva su contraseña."
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Not Sesion.EsAdmin() OrElse PreparacionInicial Then
            lblPendiente.Text = "No tenés permiso para modificar usuarios."
            Exit Sub
        End If
        If idUsuarioSelec = 0 OrElse txtUsuario.Text.Trim() = "" OrElse txtNombreCompleto.Text.Trim() = "" OrElse cboRol.SelectedValue Is Nothing Then
            lblPendiente.Text = "Seleccioná un usuario y completá los datos."
            Exit Sub
        End If
        If Not Sesion.RolValido(cboRol.Text) Then Exit Sub
        If idUsuarioSelec = Sesion.idUsuario AndAlso (cboRol.Text <> "ADMIN" OrElse Not chkActivo.Checked) Then
            lblPendiente.Text = "No podés quitar tu propio acceso ADMIN durante la sesión."
            Exit Sub
        End If
        If Not PresentacionSesion.Confirmar("¿Confirmás los cambios de usuario, rol, contraseña o estado?") Then
            lblPendiente.Text = "Operación cancelada; los cambios del editor no se guardaron."
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "UPDATE usuarios SET nombre_usuario=@usuario,nombre_completo=@nombre,id_rol=@rol,activo=@activo"
                If txtClave.Text <> "" Then sql &= ",password_hash=@hash,salt=@salt"
                sql &= " WHERE id_usuario=@id;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())
                    cmd.Parameters.AddWithValue("@nombre", txtNombreCompleto.Text.Trim())
                    cmd.Parameters.AddWithValue("@rol", CInt(cboRol.SelectedValue))
                    cmd.Parameters.AddWithValue("@activo", chkActivo.Checked)
                    cmd.Parameters.AddWithValue("@id", idUsuarioSelec)
                    If txtClave.Text <> "" Then
                        Dim salt As String = Seguridad.CrearSalt()
                        cmd.Parameters.AddWithValue("@salt", salt)
                        cmd.Parameters.AddWithValue("@hash", Seguridad.CrearHash(txtClave.Text, salt))
                    End If
                    If cmd.ExecuteNonQuery() <> 1 Then
                        lblPendiente.Text = "No se encontró el usuario seleccionado."
                        Exit Sub
                    End If
                End Using
            End Using
            If idUsuarioSelec = Sesion.idUsuario Then
                Sesion.nombreUsuario = txtUsuario.Text.Trim()
                Sesion.NombreCompleto = txtNombreCompleto.Text.Trim()
            End If
            lblPendiente.Text = "Usuario actualizado. El rol y el estado se aplican en su próximo ingreso."
            CargarUsuarios()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudo modificar el usuario. Revisá los datos y la conexión."
        Finally
            txtClave.Clear()
            CADENA = ""
        End Try
    End Sub

    Private Sub InsertarUsuario(usuario As String, nombre As String, hash As String, salt As String,
                                rol As Integer, cn As MySqlConnection, tx As MySqlTransaction, Optional activo As Boolean = True)
        Dim sql As String = "INSERT INTO usuarios (nombre_usuario,nombre_completo,password_hash,salt,id_rol,activo) " &
            "VALUES (@usuario,@nombre,@hash,@salt,@rol,@activo);"
        Using cmd As New MySqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@usuario", usuario)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@hash", hash)
            cmd.Parameters.AddWithValue("@salt", salt)
            cmd.Parameters.AddWithValue("@rol", rol)
            cmd.Parameters.AddWithValue("@activo", activo)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not PreparacionInicial AndAlso Not Sesion.EsAdmin() Then
            lblPendiente.Text = "No tenés permiso para guardar usuarios."
            Exit Sub
        End If
        If txtNombreCompleto.Text.Trim() = "" OrElse txtUsuario.Text.Trim() = "" OrElse txtClave.Text = "" Then
            lblPendiente.Text = "Completá nombre, usuario y contraseña."
            Exit Sub
        End If
        If PreparacionInicial Then
            nombresIniciales(pasoInicial) = txtNombreCompleto.Text.Trim()
            clavesIniciales(pasoInicial) = txtClave.Text
            txtClave.Clear()
            If pasoInicial < 2 Then
                pasoInicial += 1
                MostrarPasoInicial()
                Exit Sub
            End If
        ElseIf cboRol.SelectedValue Is Nothing OrElse Not Sesion.RolValido(cboRol.Text) Then
            lblPendiente.Text = "Seleccioná un rol permitido."
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then
            lblPendiente.Text = MensajeConexion
            Exit Sub
        End If
        btnGuardar.Enabled = False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        If PreparacionInicial Then
                            'vuelvo a comprobar justo antes de insertar
                            For Each tabla As String In {"roles", "usuarios"}
                                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM " & tabla & ";", cn, tx)
                                    If CInt(cmd.ExecuteScalar()) <> 0 Then
                                        lblPendiente.Text = "DETENIDO: aparecieron roles o usuarios previos. No se cambió ninguno."
                                        Return
                                    End If
                                End Using
                            Next
                            For i As Integer = 0 To 2
                                Dim idRol As Integer
                                Using cmd As New MySqlCommand("INSERT INTO roles (nombre) VALUES (@nombre);", cn, tx)
                                    cmd.Parameters.AddWithValue("@nombre", rolesIniciales(i))
                                    cmd.ExecuteNonQuery()
                                    idRol = CInt(cmd.LastInsertedId)
                                End Using
                                Dim salt As String = Seguridad.CrearSalt()
                                InsertarUsuario(usuariosIniciales(i), nombresIniciales(i), Seguridad.CrearHash(clavesIniciales(i), salt), salt, idRol, cn, tx)
                            Next
                        Else
                            Dim salt As String = Seguridad.CrearSalt()
                            InsertarUsuario(txtUsuario.Text.Trim(), txtNombreCompleto.Text.Trim(), Seguridad.CrearHash(txtClave.Text, salt),
                                            salt, CInt(cboRol.SelectedValue), cn, tx, chkActivo.Checked)
                        End If
                        tx.Commit()
                        transaccionConfirmada = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            txtClave.Clear()
            If PreparacionInicial Then
                'las claves siguen solo en memoria hasta terminar las pruebas locales
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                lblPendiente.Text = "Usuario guardado correctamente."
                txtNombreCompleto.Clear()
                txtUsuario.Clear()
                CargarUsuarios()
            End If
        Catch ex As MySqlException
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            If ex.Number = 1062 Then
                lblPendiente.Text = "No se guardó: el nombre de usuario o rol ya está utilizado."
            Else
                lblPendiente.Text = "No se pudieron guardar usuarios. No se confirmó la transacción."
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            lblPendiente.Text = "No se pudieron guardar usuarios. No se confirmó la transacción."
        Finally
            txtClave.Clear()
            CADENA = ""
            btnGuardar.Enabled = True
        End Try
    End Sub

    Private Function PermisosCorrectos(rol As String) As Boolean
        Dim acciones() As String = {"CONSULTAR_PACIENTES", "REGISTRAR_PACIENTES", "MODIFICAR_PACIENTES", "BAJAS",
            "CONSULTAR_ORDENES", "CREAR_ORDENES", "ADMIN_ORDENES", "CONSULTAR_MUESTRAS", "REGISTRAR_MUESTRAS",
            "ACTUALIZAR_MUESTRAS", "DERIVACIONES", "CONSULTAR_INSUMOS", "MOVIMIENTOS_STOCK", "ADMIN_CATALOGOS", "ADMIN_USUARIOS"}
        Dim recepcion() As Boolean = {True, True, True, False, True, True, False, True, True, False, True, False, False, False, False}
        Dim tecnico() As Boolean = {True, False, False, False, True, False, False, True, True, True, True, True, True, False, False}
        For i As Integer = 0 To acciones.Length - 1
            Dim esperado As Boolean = True
            If rol = "RECEPCIONISTA" Then esperado = recepcion(i)
            If rol = "TECNICO" Then esperado = tecnico(i)
            If Sesion.Puede(acciones(i)) <> esperado Then Return False
        Next
        Return True
    End Function

    Private Function CambiarActivoRecepcion(activo As Boolean) As Boolean
        If idsIniciales(1) <= 0 OrElse Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Dim sql As String = "UPDATE usuarios u JOIN roles r ON u.id_rol=r.id_rol SET u.activo=@activo " &
                    "WHERE u.id_usuario=@id AND u.nombre_usuario=@usuario AND r.nombre=@rol;"
                Using cmd As New MySqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@activo", activo)
                    cmd.Parameters.AddWithValue("@id", idsIniciales(1))
                    cmd.Parameters.AddWithValue("@usuario", "recepcion")
                    cmd.Parameters.AddWithValue("@rol", "RECEPCIONISTA")
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de los usuarios. Revisá los datos y volvé a intentar.", ex)
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Public Function VerificarPreparacionInicial() As String
        Dim informe As New List(Of String)
        Dim claves() As String = CType(clavesIniciales.Clone(), String())
        Dim requiereReactivar As Boolean = False
        informe.Add("Laboratorio L&A - tres roles. Verificacion local: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"))
        informe.Add("Base exclusiva: laboratorio_la_2026. Creados exactamente 3 roles y 3 cuentas en una transaccion.")
        Try
            For i As Integer = 0 To 2
                Using login As New frmLogin()
                    login.Show()
                    Application.DoEvents()
                    If Not login.Autenticar(usuariosIniciales(i), claves(i)) OrElse Sesion.rolUsuario <> rolesIniciales(i) Then Throw New InvalidOperationException()
                    idsIniciales(i) = Sesion.idUsuario
                    If Not PermisosCorrectos(rolesIniciales(i)) Then Throw New InvalidOperationException()
                    Using menu As New frmPrincipal()
                        menu.Show()
                        Application.DoEvents()
                        If Not menu.Visible Then Throw New InvalidOperationException()
                        Dim admin As Boolean = rolesIniciales(i) = "ADMIN"
                        Dim stock As Boolean = admin OrElse rolesIniciales(i) = "TECNICO"
                        If menu.btnUsuarios.Enabled <> admin OrElse menu.btnAnalisis.Enabled <> admin OrElse
                            menu.btnCentros.Enabled <> admin OrElse menu.btnMovimientosStock.Enabled <> stock OrElse
                            menu.btnInsumos.Enabled <> stock Then Throw New InvalidOperationException()
                        menu.btnVolver.PerformClick()
                        If Sesion.Autenticado() OrElse (Not menu.IsDisposed AndAlso menu.Visible) Then Throw New InvalidOperationException()
                    End Using
                    If login.Autenticar(usuariosIniciales(i), Guid.NewGuid().ToString()) Then Throw New InvalidOperationException()
                    If login.lblResultadoConexion.Text <> "Usuario o contraseña incorrectos." Then Throw New InvalidOperationException()
                    informe.Add(usuariosIniciales(i) & ": login valido OK, clave incorrecta rechazada, 15 permisos y menu OK, logout OK.")
                    login.Close()
                End Using
            Next
            'la cuenta temporalmente desactivada nunca es ADMIN
            requiereReactivar = True
            If Not CambiarActivoRecepcion(False) Then Throw New InvalidOperationException()
            Using login As New frmLogin()
                If login.Autenticar("recepcion", claves(1)) Then Throw New InvalidOperationException()
                If login.lblResultadoConexion.Text <> "Usuario o contraseña incorrectos." Then Throw New InvalidOperationException()
            End Using
            informe.Add("recepcion: usuario inactivo rechazado con el mismo mensaje generico.")
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            informe.Add("FALLO: no se completaron todas las comprobaciones de login/permisos; no se muestran claves ni excepciones.")
        Finally
            If requiereReactivar Then
                If CambiarActivoRecepcion(True) Then
                    informe.Add("recepcion: reactivacion final confirmada por UPDATE de una fila; ADMIN no fue desactivado.")
                Else
                    informe.Add("FALLO: no se pudo confirmar la reactivacion de recepcion. Revisar antes de continuar.")
                End If
            End If
            Sesion.CerrarSesion()
        End Try
        Try
            Using login As New frmLogin()
                If Not login.Autenticar("recepcion", claves(1)) Then Throw New InvalidOperationException()
                Sesion.CerrarSesion()
            End Using
            If Not ObtenerDatosConexion() Then Throw New InvalidOperationException()
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM roles;", cn)
                    If CInt(cmd.ExecuteScalar()) <> 3 Then Throw New InvalidOperationException()
                End Using
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM usuarios;", cn)
                    If CInt(cmd.ExecuteScalar()) <> 3 Then Throw New InvalidOperationException()
                End Using
                For i As Integer = 0 To 2
                    Dim sql As String = "SELECT COUNT(*) FROM usuarios u JOIN roles r ON u.id_rol=r.id_rol " &
                        "WHERE u.nombre_usuario=@usuario AND r.nombre=@rol AND u.activo=TRUE;"
                    Using cmd As New MySqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@usuario", usuariosIniciales(i))
                        cmd.Parameters.AddWithValue("@rol", rolesIniciales(i))
                        If CInt(cmd.ExecuteScalar()) <> 1 Then Throw New InvalidOperationException()
                    End Using
                    informe.Add("Estado final: " & usuariosIniciales(i) & " / " & rolesIniciales(i) & " / ACTIVO.")
                Next
            End Using
            informe.Add("Reingreso de recepcion reactivada OK. Sin cambios de esquema, permisos MariaDB ni datos de otros modulos.")
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar los usuarios. Revisá los datos y volvé a intentar.", ex)
            informe.Add("FALLO: no se pudo confirmar el estado final de las tres cuentas.")
        Finally
            CADENA = ""
            Sesion.CerrarSesion()
            For i As Integer = 0 To 2
                claves(i) = ""
            Next
            LimpiarPreparacion()
        End Try
        Return String.Join(Environment.NewLine, informe)
    End Function

    Public Sub LimpiarPreparacion()
        For i As Integer = 0 To 2
            clavesIniciales(i) = ""
            nombresIniciales(i) = ""
        Next
        txtClave.Clear()
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        txtClave.Clear()
        If Me.DialogResult <> DialogResult.OK Then LimpiarPreparacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub frmUsuarios_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        PresentacionSesion.EjecutarEnter(Me, e, Nothing, btnGuardar, btnModificar)
    End Sub
End Class
