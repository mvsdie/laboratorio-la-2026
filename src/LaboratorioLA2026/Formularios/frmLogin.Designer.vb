<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents ttpAcciones As ToolTip
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents layLogin As TableLayoutPanel
    Friend WithEvents layMarca As TableLayoutPanel
    Friend WithEvents layIngreso As TableLayoutPanel
    Friend WithEvents layBotonesLogin As FlowLayoutPanel
    Private components As System.ComponentModel.IContainer

    'procedimiento del diseñador de Windows Forms
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlMarca = New Panel()
        lblMarca = New Label()
        lblLaboratorio = New Label()
        lblVersion = New Label()
        lblTitulo = New Label()
        lblPendiente = New Label()
        lblUsuario = New Label()
        txtUsuario = New TextBox()
        lblClave = New Label()
        txtClave = New TextBox()
        btnIngresar = New Button()
        btnVerPantallas = New Button()
        btnSalir = New Button()
        btnProbarConexion = New Button()
        lblResultadoConexion = New Label()
        components = New System.ComponentModel.Container()
        ttpAcciones = New ToolTip(components)
        pnlContenido = New Panel()
        layLogin = New TableLayoutPanel()
        layMarca = New TableLayoutPanel()
        layIngreso = New TableLayoutPanel()
        layBotonesLogin = New FlowLayoutPanel()
        pnlContenido.SuspendLayout()
        SuspendLayout()
        ' pnlMarca
        pnlMarca.Name = "pnlMarca"
        pnlMarca.Location = New Point(0, 0)
        pnlMarca.Size = New Size(370, 620)
        pnlMarca.TabIndex = 0
        pnlMarca.BackColor = Color.FromArgb(157, 43, 59)
        pnlMarca.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        ' lblMarca
        lblMarca.Name = "lblMarca"
        lblMarca.UseMnemonic = False
        lblMarca.Location = New Point(35, 65)
        lblMarca.Size = New Size(300, 85)
        lblMarca.TabIndex = 1
        lblMarca.Text = "L&A"
        lblMarca.Font = New Font("Segoe UI", 46.0F, FontStyle.Bold)
        lblMarca.ForeColor = Color.White
        ' lblLaboratorio
        lblLaboratorio.Name = "lblLaboratorio"
        lblLaboratorio.UseMnemonic = False
        lblLaboratorio.Location = New Point(38, 170)
        lblLaboratorio.Size = New Size(295, 80)
        lblLaboratorio.TabIndex = 2
        lblLaboratorio.Text = "LABORATORIO DE ANÁLISIS CLÍNICOS"
        lblLaboratorio.Font = New Font("Segoe UI", 17.0F)
        lblLaboratorio.ForeColor = Color.White
        ' lblVersion
        lblVersion.Name = "lblVersion"
        lblVersion.UseMnemonic = False
        lblVersion.Location = New Point(38, 430)
        lblVersion.Size = New Size(290, 70)
        lblVersion.TabIndex = 3
        lblVersion.Text = "Sistema de gestión · Versión académica inicial"
        lblVersion.ForeColor = Color.White
        ' lblTitulo
        lblTitulo.Name = "lblTitulo"
        lblTitulo.UseMnemonic = False
        lblTitulo.Location = New Point(415, 45)
        lblTitulo.Size = New Size(460, 50)
        lblTitulo.TabIndex = 4
        lblTitulo.Text = "Bienvenidas a L&A"
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(418, 108)
        lblPendiente.Size = New Size(435, 65)
        lblPendiente.TabIndex = 5
        lblPendiente.Text = "Ingresá con tu usuario y contraseña de la aplicación. La prueba de conexión no inicia sesión."
        lblPendiente.ForeColor = Color.FromArgb(75, 85, 93)
        ' lblUsuario
        lblUsuario.Name = "lblUsuario"
        lblUsuario.UseMnemonic = False
        lblUsuario.Location = New Point(418, 185)
        lblUsuario.Size = New Size(430, 22)
        lblUsuario.TabIndex = 6
        lblUsuario.Text = "Usuario"
        ' txtUsuario
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Location = New Point(418, 210)
        txtUsuario.Size = New Size(430, 30)
        txtUsuario.TabIndex = 7
        txtUsuario.Enabled = True
        ' lblClave
        lblClave.Name = "lblClave"
        lblClave.UseMnemonic = False
        lblClave.Location = New Point(418, 257)
        lblClave.Size = New Size(430, 22)
        lblClave.TabIndex = 8
        lblClave.Text = "Clave"
        ' txtClave
        txtClave.Name = "txtClave"
        txtClave.Location = New Point(418, 282)
        txtClave.Size = New Size(430, 30)
        txtClave.TabIndex = 9
        txtClave.Enabled = True
        txtClave.UseSystemPasswordChar = True
        ' btnIngresar
        btnIngresar.Name = "btnIngresar"
        btnIngresar.Location = New Point(418, 335)
        btnIngresar.Size = New Size(430, 40)
        btnIngresar.TabIndex = 10
        btnIngresar.Text = "→  Ingresar"
        btnIngresar.Enabled = True
        ' btnVerPantallas
        btnVerPantallas.Name = "btnVerPantallas"
        btnVerPantallas.Location = New Point(418, 395)
        btnVerPantallas.Size = New Size(430, 46)
        btnVerPantallas.TabIndex = 11
        btnVerPantallas.Text = "Revisión sin sesión deshabilitada"
        btnVerPantallas.Enabled = False
        btnVerPantallas.Visible = False
        btnVerPantallas.TabStop = False
        btnVerPantallas.BackColor = Color.FromArgb(157, 43, 59)
        btnVerPantallas.ForeColor = Color.White
        btnVerPantallas.FlatStyle = FlatStyle.Flat
        ' btnSalir
        btnSalir.Name = "btnSalir"
        btnSalir.Location = New Point(688, 470)
        btnSalir.Size = New Size(160, 36)
        btnSalir.TabIndex = 13
        btnSalir.Text = "×  Salir"
        ' btnProbarConexion
        btnProbarConexion.Name = "btnProbarConexion"
        btnProbarConexion.Location = New Point(418, 470)
        btnProbarConexion.Size = New Size(250, 36)
        btnProbarConexion.Text = "Probar conexión y lectura"
        btnProbarConexion.TabIndex = 12
        ' lblResultadoConexion
        lblResultadoConexion.Name = "lblResultadoConexion"
        lblResultadoConexion.UseMnemonic = False
        lblResultadoConexion.Location = New Point(418, 520)
        lblResultadoConexion.Size = New Size(430, 78)
        lblResultadoConexion.ForeColor = Color.FromArgb(75, 85, 93)
        lblResultadoConexion.TabIndex = 14
        btnIngresar.FlatStyle = FlatStyle.Flat
        btnIngresar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnIngresar.Cursor = Cursors.Hand
        btnIngresar.UseVisualStyleBackColor = False
        btnIngresar.BackColor = Color.White
        btnIngresar.ForeColor = Color.FromArgb(57, 69, 76)
        btnIngresar.BackColor = Color.FromArgb(157, 43, 59)
        btnIngresar.ForeColor = Color.White
        btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(125, 34, 47)
        btnVerPantallas.FlatStyle = FlatStyle.Flat
        btnVerPantallas.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnVerPantallas.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnVerPantallas.Cursor = Cursors.Hand
        btnVerPantallas.UseVisualStyleBackColor = False
        btnVerPantallas.BackColor = Color.White
        btnVerPantallas.ForeColor = Color.FromArgb(57, 69, 76)
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnSalir.Cursor = Cursors.Hand
        btnSalir.UseVisualStyleBackColor = False
        btnSalir.BackColor = Color.White
        btnSalir.ForeColor = Color.FromArgb(57, 69, 76)
        btnProbarConexion.FlatStyle = FlatStyle.Flat
        btnProbarConexion.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnProbarConexion.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnProbarConexion.Cursor = Cursors.Hand
        btnProbarConexion.UseVisualStyleBackColor = False
        btnProbarConexion.BackColor = Color.White
        btnProbarConexion.ForeColor = Color.FromArgb(57, 69, 76)
        lblPendiente.AutoEllipsis = True
        lblUsuario.AutoEllipsis = True
        lblResultadoConexion.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnIngresar, "→  Ingresar")
        ttpAcciones.SetToolTip(btnVerPantallas, "Revisión sin sesión deshabilitada")
        ttpAcciones.SetToolTip(btnSalir, "×  Salir")
        ttpAcciones.SetToolTip(btnProbarConexion, "Probar conexión y lectura")
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Location = New Point(0, 0)
        pnlContenido.Size = New Size(910, 620)
        pnlContenido.TabIndex = 0
        Me.Controls.Add(pnlContenido)
        AutoScroll = False
        KeyPreview = True
        'inicio distribucion adaptable
        layLogin.Name = "layLogin"
        layLogin.ColumnCount = 2
        layLogin.RowCount = 1
        layLogin.Dock = DockStyle.Fill
        layLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 36F))
        layLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 64F))
        layLogin.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layLogin.MinimumSize = New Size(760, 540)
        layMarca.Name = "layMarca"
        layMarca.ColumnCount = 1
        layMarca.RowCount = 3
        layMarca.Dock = DockStyle.Fill
        layMarca.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layMarca.RowStyles.Add(New RowStyle(SizeType.Absolute, 140F))
        layMarca.RowStyles.Add(New RowStyle(SizeType.Absolute, 150F))
        layMarca.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layMarca.Padding = New Padding(24)
        pnlMarca.Dock = DockStyle.Fill
        pnlMarca.Margin = New Padding(4)
        layLogin.Controls.Add(pnlMarca, 0, 0)
        pnlMarca.Controls.Add(layMarca)
        lblMarca.Dock = DockStyle.Fill
        lblMarca.Margin = New Padding(4)
        layMarca.Controls.Add(lblMarca, 0, 0)
        lblLaboratorio.Dock = DockStyle.Fill
        lblLaboratorio.Margin = New Padding(4)
        layMarca.Controls.Add(lblLaboratorio, 0, 1)
        lblVersion.Dock = DockStyle.Fill
        lblVersion.Margin = New Padding(4)
        layMarca.Controls.Add(lblVersion, 0, 2)
        lblVersion.TextAlign = ContentAlignment.BottomLeft
        layIngreso.Name = "layIngreso"
        layIngreso.ColumnCount = 1
        layIngreso.RowCount = 9
        layIngreso.Dock = DockStyle.Fill
        layIngreso.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIngreso.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layIngreso.Padding = New Padding(24)
        layLogin.Controls.Add(layIngreso, 1, 0)
        layBotonesLogin.Name = "layBotonesLogin"
        layBotonesLogin.Dock = DockStyle.Fill
        layBotonesLogin.AutoSize = True
        layBotonesLogin.WrapContents = True
        layBotonesLogin.Margin = New Padding(0)
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Margin = New Padding(4)
        lblTitulo.AutoSize = True
        lblTitulo.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(lblTitulo, 0, 0)
        lblPendiente.Dock = DockStyle.Fill
        lblPendiente.Margin = New Padding(4)
        lblPendiente.AutoSize = True
        lblPendiente.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(lblPendiente, 0, 1)
        lblUsuario.Dock = DockStyle.Fill
        lblUsuario.Margin = New Padding(4)
        lblUsuario.AutoSize = True
        lblUsuario.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(lblUsuario, 0, 2)
        txtUsuario.Dock = DockStyle.Fill
        txtUsuario.Margin = New Padding(4)
        txtUsuario.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(txtUsuario, 0, 3)
        lblClave.Dock = DockStyle.Fill
        lblClave.Margin = New Padding(4)
        lblClave.AutoSize = True
        lblClave.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(lblClave, 0, 4)
        txtClave.Dock = DockStyle.Fill
        txtClave.Margin = New Padding(4)
        txtClave.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(txtClave, 0, 5)
        btnIngresar.Dock = DockStyle.Fill
        btnIngresar.Margin = New Padding(4)
        btnIngresar.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(btnIngresar, 0, 6)
        layBotonesLogin.Dock = DockStyle.Fill
        layBotonesLogin.Margin = New Padding(4)
        layBotonesLogin.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(layBotonesLogin, 0, 7)
        lblResultadoConexion.Dock = DockStyle.Fill
        lblResultadoConexion.Margin = New Padding(4)
        lblResultadoConexion.Margin = New Padding(4, 6, 4, 12)
        layIngreso.Controls.Add(lblResultadoConexion, 0, 8)
        btnIngresar.MinimumSize = New Size(100, 42)
        btnProbarConexion.Dock = DockStyle.None
        btnProbarConexion.AutoSize = True
        btnProbarConexion.MinimumSize = New Size(110, 36)
        btnProbarConexion.Margin = New Padding(4, 4, 8, 4)
        layBotonesLogin.Controls.Add(btnProbarConexion)
        btnSalir.Dock = DockStyle.None
        btnSalir.AutoSize = True
        btnSalir.MinimumSize = New Size(110, 36)
        btnSalir.Margin = New Padding(4, 4, 8, 4)
        layBotonesLogin.Controls.Add(btnSalir)
        btnVerPantallas.Dock = DockStyle.None
        btnVerPantallas.AutoSize = True
        btnVerPantallas.MinimumSize = New Size(110, 36)
        btnVerPantallas.Margin = New Padding(4, 4, 8, 4)
        layBotonesLogin.Controls.Add(btnVerPantallas)
        btnVerPantallas.Visible = False
        Me.AcceptButton = btnIngresar
        pnlContenido.Controls.Add(layLogin)
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.AutoScroll = True
        pnlContenido.AutoScrollMinSize = New Size(760, 540)
        pnlContenido.Padding = New Padding(8)
        'fin distribucion adaptable
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(910, 620)
        MinimumSize = New Size(700, 460)
        BackColor = Color.FromArgb(245, 247, 248)
        Name = "frmLogin"
        Text = "L&A | Inicio"
        StartPosition = FormStartPosition.CenterScreen
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlMarca As Panel
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblLaboratorio As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblPendiente As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lblClave As Label
    Friend WithEvents txtClave As TextBox
    Friend WithEvents btnIngresar As Button
    Friend WithEvents btnVerPantallas As Button
    Friend WithEvents btnProbarConexion As Button
    Friend WithEvents lblResultadoConexion As Label
    Friend WithEvents btnSalir As Button
End Class
