<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuarios
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
    Friend WithEvents layPantalla As TableLayoutPanel
    Friend WithEvents layCabecera As TableLayoutPanel
    Friend WithEvents layCuerpo As TableLayoutPanel
    Friend WithEvents layEditorPanel As Panel
    Friend WithEvents layEditor As TableLayoutPanel
    Friend WithEvents layListado As TableLayoutPanel
    Friend WithEvents layFiltros As FlowLayoutPanel
    Friend WithEvents layAcciones As FlowLayoutPanel
    Private components As System.ComponentModel.IContainer

    'procedimiento del diseñador de Windows Forms
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlEncabezado = New Panel()
        lblMarca = New Label()
        lblTitulo = New Label()
        lblEstado = New Label()
        lblPendiente = New Label()
        lblNombreCompleto = New Label()
        txtNombreCompleto = New TextBox()
        lblUsuario = New Label()
        txtUsuario = New TextBox()
        lblClave = New Label()
        txtClave = New TextBox()
        lblRol = New Label()
        cboRol = New ComboBox()
        dgvUsuarios = New DataGridView()
        btnGuardar = New Button()
        btnCerrar = New Button()
        btnModificar = New Button()
        chkActivo = New CheckBox()
        components = New System.ComponentModel.Container()
        ttpAcciones = New ToolTip(components)
        pnlContenido = New Panel()
        layPantalla = New TableLayoutPanel()
        layCabecera = New TableLayoutPanel()
        layCuerpo = New TableLayoutPanel()
        layEditorPanel = New Panel()
        layEditor = New TableLayoutPanel()
        layListado = New TableLayoutPanel()
        layFiltros = New FlowLayoutPanel()
        layAcciones = New FlowLayoutPanel()
        pnlContenido.SuspendLayout()
        SuspendLayout()
        CType(dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        ' pnlEncabezado
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Location = New Point(0, 0)
        pnlEncabezado.Size = New Size(1160, 110)
        pnlEncabezado.TabIndex = 0
        pnlEncabezado.BackColor = Color.FromArgb(157, 43, 59)
        pnlEncabezado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblMarca
        lblMarca.Name = "lblMarca"
        lblMarca.UseMnemonic = False
        lblMarca.Location = New Point(26, 15)
        lblMarca.Size = New Size(1090, 24)
        lblMarca.TabIndex = 1
        lblMarca.Text = "L&A  /  LABORATORIO DE ANÁLISIS CLÍNICOS"
        lblMarca.ForeColor = Color.White
        lblMarca.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        ' lblTitulo
        lblTitulo.Name = "lblTitulo"
        lblTitulo.UseMnemonic = False
        lblTitulo.Location = New Point(26, 45)
        lblTitulo.Size = New Size(1090, 46)
        lblTitulo.TabIndex = 2
        lblTitulo.Text = "Usuarios"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 126)
        lblEstado.Size = New Size(1100, 38)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Alta de usuarios y selección de rol, pendiente de habilitar."
        lblEstado.ForeColor = Color.FromArgb(75, 85, 93)
        lblEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(370, 183)
        lblPendiente.Size = New Size(750, 44)
        lblPendiente.TabIndex = 4
        lblPendiente.Text = "Pantalla inicial · Las consultas y el guardado todavía no están implementados."
        lblPendiente.ForeColor = Color.FromArgb(157, 43, 59)
        ' lblNombreCompleto
        lblNombreCompleto.Name = "lblNombreCompleto"
        lblNombreCompleto.UseMnemonic = False
        lblNombreCompleto.Location = New Point(28, 178)
        lblNombreCompleto.Size = New Size(316, 20)
        lblNombreCompleto.TabIndex = 5
        lblNombreCompleto.Text = "Nombre completo"
        ' txtNombreCompleto
        txtNombreCompleto.Name = "txtNombreCompleto"
        txtNombreCompleto.Location = New Point(28, 200)
        txtNombreCompleto.Size = New Size(310, 27)
        txtNombreCompleto.TabIndex = 6
        txtNombreCompleto.Enabled = False
        txtNombreCompleto.MaxLength = 255
        ' lblUsuario
        lblUsuario.Name = "lblUsuario"
        lblUsuario.UseMnemonic = False
        lblUsuario.Location = New Point(28, 240)
        lblUsuario.Size = New Size(316, 20)
        lblUsuario.TabIndex = 7
        lblUsuario.Text = "Nombre de usuario"
        ' txtUsuario
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Location = New Point(28, 262)
        txtUsuario.Size = New Size(310, 27)
        txtUsuario.TabIndex = 8
        txtUsuario.Enabled = False
        txtUsuario.MaxLength = 255
        ' lblClave
        lblClave.Name = "lblClave"
        lblClave.UseMnemonic = False
        lblClave.Location = New Point(28, 302)
        lblClave.Size = New Size(316, 20)
        lblClave.TabIndex = 9
        lblClave.Text = "Clave"
        ' txtClave
        txtClave.Name = "txtClave"
        txtClave.Location = New Point(28, 324)
        txtClave.Size = New Size(310, 27)
        txtClave.TabIndex = 10
        txtClave.Enabled = False
        txtClave.MaxLength = 255
        txtClave.UseSystemPasswordChar = True
        ' lblRol
        lblRol.Name = "lblRol"
        lblRol.UseMnemonic = False
        lblRol.Location = New Point(28, 364)
        lblRol.Size = New Size(316, 20)
        lblRol.TabIndex = 11
        lblRol.Text = "Rol"
        ' cboRol
        cboRol.Name = "cboRol"
        cboRol.Location = New Point(28, 386)
        cboRol.Size = New Size(310, 27)
        cboRol.TabIndex = 12
        cboRol.Enabled = False
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList
        ' dgvUsuarios
        dgvUsuarios.Name = "dgvUsuarios"
        dgvUsuarios.Location = New Point(370, 238)
        dgvUsuarios.Size = New Size(750, 360)
        dgvUsuarios.TabIndex = 13
        dgvUsuarios.ReadOnly = True
        dgvUsuarios.AllowUserToAddRows = False
        dgvUsuarios.AllowUserToDeleteRows = False
        dgvUsuarios.MultiSelect = False
        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsuarios.BackgroundColor = Color.White
        dgvUsuarios.BorderStyle = BorderStyle.FixedSingle
        dgvUsuarios.Enabled = False
        dgvUsuarios.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ' btnGuardar
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Location = New Point(370, 620)
        btnGuardar.Size = New Size(135, 36)
        btnGuardar.TabIndex = 14
        btnGuardar.Text = "✓  Guardar"
        btnGuardar.Enabled = False
        btnGuardar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnCerrar
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Location = New Point(975, 675)
        btnCerrar.Size = New Size(145, 36)
        btnCerrar.TabIndex = 15
        btnCerrar.Text = "←  Volver"
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnModificar.Name = "btnModificar"
        btnModificar.Text = "✎  Modificar"
        btnModificar.Location = New Point(515, 620)
        btnModificar.Size = New Size(135, 36)
        btnModificar.Enabled = False
        btnModificar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnModificar.TabIndex = 30
        chkActivo.Name = "chkActivo"
        chkActivo.Text = "Usuario activo"
        chkActivo.Location = New Point(28, 435)
        chkActivo.Size = New Size(310, 27)
        chkActivo.Enabled = False
        chkActivo.TabIndex = 31
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnGuardar.Cursor = Cursors.Hand
        btnGuardar.UseVisualStyleBackColor = False
        btnGuardar.BackColor = Color.White
        btnGuardar.ForeColor = Color.FromArgb(57, 69, 76)
        btnGuardar.BackColor = Color.FromArgb(157, 43, 59)
        btnGuardar.ForeColor = Color.White
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(125, 34, 47)
        btnCerrar.FlatStyle = FlatStyle.Flat
        btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnCerrar.Cursor = Cursors.Hand
        btnCerrar.UseVisualStyleBackColor = False
        btnCerrar.BackColor = Color.White
        btnCerrar.ForeColor = Color.FromArgb(57, 69, 76)
        btnModificar.FlatStyle = FlatStyle.Flat
        btnModificar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnModificar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnModificar.Cursor = Cursors.Hand
        btnModificar.UseVisualStyleBackColor = False
        btnModificar.BackColor = Color.White
        btnModificar.ForeColor = Color.FromArgb(57, 69, 76)
        lblEstado.AutoEllipsis = True
        lblPendiente.AutoEllipsis = True
        lblUsuario.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnGuardar, "✓  Guardar")
        ttpAcciones.SetToolTip(btnCerrar, "←  Volver")
        ttpAcciones.SetToolTip(btnModificar, "✎  Modificar")
        pnlContenido.Name = "pnlContenido"
        pnlContenido.Location = New Point(0, 0)
        pnlContenido.Size = New Size(1160, 740)
        pnlContenido.TabIndex = 0
        Me.Controls.Add(pnlContenido)
        AutoScroll = False
        KeyPreview = True
        'inicio distribucion adaptable
        layPantalla.Name = "layPantalla"
        layPantalla.ColumnCount = 1
        layPantalla.RowCount = 4
        layPantalla.Dock = DockStyle.Fill
        layPantalla.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Absolute, 105F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPantalla.MinimumSize = New Size(840, 620)
        pnlContenido.Controls.Add(layPantalla)
        pnlEncabezado.Dock = DockStyle.Fill
        pnlEncabezado.Margin = New Padding(4)
        pnlEncabezado.Margin = New Padding(0)
        layPantalla.Controls.Add(pnlEncabezado, 0, 0)
        layCabecera.Name = "layCabecera"
        layCabecera.ColumnCount = 2
        layCabecera.RowCount = 2
        layCabecera.Dock = DockStyle.Fill
        layCabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70F))
        layCabecera.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        layCabecera.RowStyles.Add(New RowStyle(SizeType.Absolute, 30F))
        layCabecera.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layCabecera.Padding = New Padding(12, 4, 12, 4)
        pnlEncabezado.Controls.Add(layCabecera)
        lblMarca.Dock = DockStyle.Fill
        lblMarca.Margin = New Padding(4)
        layCabecera.Controls.Add(lblMarca, 0, 0)
        layCabecera.SetColumnSpan(lblMarca, 2)
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.Margin = New Padding(4)
        lblTitulo.AutoEllipsis = True
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft
        layCabecera.Controls.Add(lblTitulo, 0, 1)
        layCabecera.SetColumnSpan(lblTitulo, 2)
        lblEstado.Dock = DockStyle.Fill
        lblEstado.Margin = New Padding(4)
        lblEstado.AutoSize = True
        lblEstado.Padding = New Padding(4, 10, 4, 10)
        layPantalla.Controls.Add(lblEstado, 0, 1)
        layCuerpo.Name = "layCuerpo"
        layCuerpo.ColumnCount = 2
        layCuerpo.RowCount = 1
        layCuerpo.Dock = DockStyle.Fill
        layCuerpo.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 32F))
        layCuerpo.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 68F))
        layCuerpo.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layPantalla.Controls.Add(layCuerpo, 0, 2)
        layEditorPanel.Name = "layEditorPanel"
        layEditorPanel.Dock = DockStyle.Fill
        layEditorPanel.Margin = New Padding(4)
        layEditorPanel.AutoScroll = True
        layCuerpo.Controls.Add(layEditorPanel, 0, 0)
        layEditor.Name = "layEditor"
        layEditor.ColumnCount = 1
        layEditor.RowCount = 9
        layEditor.Dock = DockStyle.Fill
        layEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.Dock = DockStyle.Top
        layEditor.AutoSize = True
        layEditor.Padding = New Padding(4, 4, 12, 8)
        layEditorPanel.Controls.Add(layEditor)
        lblNombreCompleto.Dock = DockStyle.Top
        lblNombreCompleto.Margin = New Padding(3, 2, 3, 6)
        lblNombreCompleto.TabIndex = 0
        lblNombreCompleto.AutoSize = True
        layEditor.Controls.Add(lblNombreCompleto, 0, 0)
        txtNombreCompleto.Dock = DockStyle.Top
        txtNombreCompleto.Margin = New Padding(3, 2, 3, 6)
        txtNombreCompleto.TabIndex = 1
        layEditor.Controls.Add(txtNombreCompleto, 0, 1)
        lblUsuario.Dock = DockStyle.Top
        lblUsuario.Margin = New Padding(3, 2, 3, 6)
        lblUsuario.TabIndex = 2
        lblUsuario.AutoSize = True
        layEditor.Controls.Add(lblUsuario, 0, 2)
        txtUsuario.Dock = DockStyle.Top
        txtUsuario.Margin = New Padding(3, 2, 3, 6)
        txtUsuario.TabIndex = 3
        layEditor.Controls.Add(txtUsuario, 0, 3)
        lblClave.Dock = DockStyle.Top
        lblClave.Margin = New Padding(3, 2, 3, 6)
        lblClave.TabIndex = 4
        lblClave.AutoSize = True
        layEditor.Controls.Add(lblClave, 0, 4)
        txtClave.Dock = DockStyle.Top
        txtClave.Margin = New Padding(3, 2, 3, 6)
        txtClave.TabIndex = 5
        layEditor.Controls.Add(txtClave, 0, 5)
        lblRol.Dock = DockStyle.Top
        lblRol.Margin = New Padding(3, 2, 3, 6)
        lblRol.TabIndex = 6
        lblRol.AutoSize = True
        layEditor.Controls.Add(lblRol, 0, 6)
        cboRol.Dock = DockStyle.Top
        cboRol.Margin = New Padding(3, 2, 3, 6)
        cboRol.TabIndex = 7
        layEditor.Controls.Add(cboRol, 0, 7)
        chkActivo.Dock = DockStyle.Top
        chkActivo.Margin = New Padding(3, 2, 3, 6)
        chkActivo.TabIndex = 8
        chkActivo.AutoSize = True
        layEditor.Controls.Add(chkActivo, 0, 8)
        layListado.Name = "layListado"
        layListado.ColumnCount = 1
        layListado.RowCount = 4
        layListado.Dock = DockStyle.Fill
        layListado.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.Percent, 55F))
        layListado.Padding = New Padding(8, 4, 4, 4)
        layCuerpo.Controls.Add(layListado, 1, 0)
        layFiltros.Name = "layFiltros"
        layFiltros.Dock = DockStyle.Fill
        layFiltros.AutoSize = True
        layFiltros.WrapContents = True
        layFiltros.Margin = New Padding(0)
        layListado.Controls.Add(layFiltros, 0, 1)
        lblPendiente.Dock = DockStyle.Fill
        lblPendiente.Margin = New Padding(4)
        lblPendiente.AutoSize = True
        layListado.Controls.Add(lblPendiente, 0, 2)
        dgvUsuarios.Dock = DockStyle.Fill
        dgvUsuarios.Margin = New Padding(4)
        layListado.Controls.Add(dgvUsuarios, 0, 3)
        layAcciones.Name = "layAcciones"
        layAcciones.Dock = DockStyle.Fill
        layAcciones.AutoSize = True
        layAcciones.WrapContents = True
        layAcciones.Margin = New Padding(0)
        layPantalla.Controls.Add(layAcciones, 0, 3)
        btnGuardar.Dock = DockStyle.None
        btnGuardar.AutoSize = True
        btnGuardar.MinimumSize = New Size(110, 36)
        btnGuardar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnGuardar)
        btnModificar.Dock = DockStyle.None
        btnModificar.AutoSize = True
        btnModificar.MinimumSize = New Size(110, 36)
        btnModificar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnModificar)
        btnCerrar.Dock = DockStyle.None
        btnCerrar.AutoSize = True
        btnCerrar.MinimumSize = New Size(110, 36)
        btnCerrar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnCerrar)
        dgvUsuarios.AllowUserToAddRows = False
        dgvUsuarios.AllowUserToDeleteRows = False
        dgvUsuarios.AllowUserToOrderColumns = False
        dgvUsuarios.AllowUserToResizeColumns = False
        dgvUsuarios.AllowUserToResizeRows = False
        dgvUsuarios.ReadOnly = True
        dgvUsuarios.MultiSelect = False
        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsuarios.ScrollBars = ScrollBars.Both
        dgvUsuarios.RowHeadersVisible = False
        dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsuarios.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvUsuarios.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        pnlContenido.Dock = DockStyle.Fill
        pnlContenido.AutoScroll = True
        pnlContenido.AutoScrollMinSize = New Size(840, 620)
        pnlContenido.Padding = New Padding(8)
        'fin distribucion adaptable
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(1160, 740)
        MinimumSize = New Size(720, 480)
        BackColor = Color.FromArgb(245, 247, 248)
        Name = "frmUsuarios"
        Text = "L&A | Usuarios"
        StartPosition = FormStartPosition.CenterScreen
        CType(dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblPendiente As Label
    Friend WithEvents lblNombreCompleto As Label
    Friend WithEvents txtNombreCompleto As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lblClave As Label
    Friend WithEvents txtClave As TextBox
    Friend WithEvents lblRol As Label
    Friend WithEvents cboRol As ComboBox
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnCerrar As Button
End Class
