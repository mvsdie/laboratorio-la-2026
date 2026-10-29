<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCentros
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
        lblIdCentro = New Label()
        txtIdCentro = New TextBox()
        lblNombre = New Label()
        txtNombre = New TextBox()
        lblDireccion = New Label()
        txtDireccion = New TextBox()
        lblTelefono = New Label()
        txtTelefono = New TextBox()
        lblEmail = New Label()
        txtEmail = New TextBox()
        lblUso = New Label()
        cboUso = New ComboBox()
        lblActivo = New Label()
        chkActivo = New CheckBox()
        dgvCentros = New DataGridView()
        btnGuardar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        btnCerrar = New Button()
        lblFiltro = New Label()
        txtFiltro = New TextBox()
        btnBuscar = New Button()
        btnVerTodos = New Button()
        btnLimpiar = New Button()
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
        CType(dgvCentros, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitulo.Text = "Centros externos"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 126)
        lblEstado.Size = New Size(1100, 38)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Origen y destino de muestras, sin duplicar el catálogo."
        lblEstado.ForeColor = Color.FromArgb(75, 85, 93)
        lblEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(370, 238)
        lblPendiente.Size = New Size(750, 38)
        lblPendiente.TabIndex = 4
        lblPendiente.Text = "Buscá, seleccioná o registrá un elemento del catálogo."
        lblPendiente.ForeColor = Color.FromArgb(157, 43, 59)
        ' lblIdCentro
        lblIdCentro.Name = "lblIdCentro"
        lblIdCentro.UseMnemonic = False
        lblIdCentro.Location = New Point(28, 178)
        lblIdCentro.Size = New Size(316, 20)
        lblIdCentro.TabIndex = 5
        lblIdCentro.Text = "ID"
        ' txtIdCentro
        txtIdCentro.Name = "txtIdCentro"
        txtIdCentro.Location = New Point(28, 200)
        txtIdCentro.Size = New Size(310, 27)
        txtIdCentro.TabIndex = 6
        txtIdCentro.Enabled = False
        txtIdCentro.MaxLength = 255
        txtIdCentro.ReadOnly = True
        txtIdCentro.TabStop = False
        txtIdCentro.BackColor = SystemColors.Control
        ' lblNombre
        lblNombre.Name = "lblNombre"
        lblNombre.UseMnemonic = False
        lblNombre.Location = New Point(28, 240)
        lblNombre.Size = New Size(316, 20)
        lblNombre.TabIndex = 7
        lblNombre.Text = "Nombre"
        ' txtNombre
        txtNombre.Name = "txtNombre"
        txtNombre.Location = New Point(28, 262)
        txtNombre.Size = New Size(310, 27)
        txtNombre.TabIndex = 8
        txtNombre.Enabled = False
        txtNombre.MaxLength = 150
        ' lblDireccion
        lblDireccion.Name = "lblDireccion"
        lblDireccion.UseMnemonic = False
        lblDireccion.Location = New Point(28, 302)
        lblDireccion.Size = New Size(316, 20)
        lblDireccion.TabIndex = 9
        lblDireccion.Text = "Dirección"
        ' txtDireccion
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Location = New Point(28, 324)
        txtDireccion.Size = New Size(310, 27)
        txtDireccion.TabIndex = 10
        txtDireccion.Enabled = False
        txtDireccion.MaxLength = 255
        ' lblTelefono
        lblTelefono.Name = "lblTelefono"
        lblTelefono.UseMnemonic = False
        lblTelefono.Location = New Point(28, 364)
        lblTelefono.Size = New Size(316, 20)
        lblTelefono.TabIndex = 11
        lblTelefono.Text = "Teléfono"
        ' txtTelefono
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Location = New Point(28, 386)
        txtTelefono.Size = New Size(310, 27)
        txtTelefono.TabIndex = 12
        txtTelefono.Enabled = False
        txtTelefono.MaxLength = 30
        ' lblEmail
        lblEmail.Name = "lblEmail"
        lblEmail.UseMnemonic = False
        lblEmail.Location = New Point(28, 426)
        lblEmail.Size = New Size(316, 20)
        lblEmail.TabIndex = 13
        lblEmail.Text = "Email"
        ' txtEmail
        txtEmail.Name = "txtEmail"
        txtEmail.Location = New Point(28, 448)
        txtEmail.Size = New Size(310, 27)
        txtEmail.TabIndex = 14
        txtEmail.Enabled = False
        txtEmail.MaxLength = 100
        ' lblUso
        lblUso.Name = "lblUso"
        lblUso.UseMnemonic = False
        lblUso.Location = New Point(28, 488)
        lblUso.Size = New Size(316, 20)
        lblUso.TabIndex = 15
        lblUso.Text = "Uso: origen / destino / ambos"
        ' cboUso
        cboUso.Name = "cboUso"
        cboUso.Location = New Point(28, 510)
        cboUso.Size = New Size(310, 27)
        cboUso.TabIndex = 16
        cboUso.Enabled = False
        cboUso.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblActivo
        lblActivo.Name = "lblActivo"
        lblActivo.UseMnemonic = False
        lblActivo.Location = New Point(28, 550)
        lblActivo.Size = New Size(316, 20)
        lblActivo.TabIndex = 17
        lblActivo.Text = "Activo"
        ' chkActivo
        chkActivo.Name = "chkActivo"
        chkActivo.Location = New Point(28, 572)
        chkActivo.Size = New Size(310, 27)
        chkActivo.TabIndex = 18
        chkActivo.Enabled = False
        ' dgvCentros
        dgvCentros.Name = "dgvCentros"
        dgvCentros.Location = New Point(370, 284)
        dgvCentros.Size = New Size(750, 314)
        dgvCentros.TabIndex = 19
        dgvCentros.ReadOnly = True
        dgvCentros.AllowUserToAddRows = False
        dgvCentros.AllowUserToDeleteRows = False
        dgvCentros.MultiSelect = False
        dgvCentros.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCentros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCentros.BackgroundColor = Color.White
        dgvCentros.BorderStyle = BorderStyle.FixedSingle
        dgvCentros.Enabled = False
        dgvCentros.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ' btnGuardar
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Location = New Point(370, 620)
        btnGuardar.Size = New Size(135, 36)
        btnGuardar.TabIndex = 20
        btnGuardar.Text = "✓  Guardar"
        btnGuardar.Enabled = False
        btnGuardar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnModificar
        btnModificar.Name = "btnModificar"
        btnModificar.Location = New Point(515, 620)
        btnModificar.Size = New Size(135, 36)
        btnModificar.TabIndex = 21
        btnModificar.Text = "✎  Modificar"
        btnModificar.Enabled = False
        btnModificar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnEliminar
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Location = New Point(660, 620)
        btnEliminar.Size = New Size(135, 36)
        btnEliminar.TabIndex = 22
        btnEliminar.Text = "Eliminar"
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnCerrar
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Location = New Point(975, 675)
        btnCerrar.Size = New Size(145, 36)
        btnCerrar.TabIndex = 23
        btnCerrar.Text = "←  Volver"
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblFiltro.Name = "lblFiltro"
        lblFiltro.Text = "Buscar por nombre"
        lblFiltro.Location = New Point(370, 178)
        lblFiltro.Size = New Size(750, 20)
        txtFiltro.Name = "txtFiltro"
        txtFiltro.Location = New Point(370, 202)
        txtFiltro.Size = New Size(450, 27)
        txtFiltro.MaxLength = 150
        txtFiltro.TabIndex = 30
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Text = "⌕  Buscar"
        btnBuscar.Location = New Point(830, 198)
        btnBuscar.Size = New Size(135, 36)
        btnBuscar.TabIndex = 31
        btnVerTodos.Name = "btnVerTodos"
        btnVerTodos.Text = "≡  Ver todos"
        btnVerTodos.Location = New Point(975, 198)
        btnVerTodos.Size = New Size(145, 36)
        btnVerTodos.TabIndex = 32
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Text = "↺  Limpiar"
        btnLimpiar.Location = New Point(660, 620)
        btnLimpiar.Size = New Size(145, 36)
        btnLimpiar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnLimpiar.TabIndex = 33
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
        btnModificar.FlatStyle = FlatStyle.Flat
        btnModificar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnModificar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnModificar.Cursor = Cursors.Hand
        btnModificar.UseVisualStyleBackColor = False
        btnModificar.BackColor = Color.White
        btnModificar.ForeColor = Color.FromArgb(57, 69, 76)
        btnEliminar.FlatStyle = FlatStyle.Flat
        btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnEliminar.Cursor = Cursors.Hand
        btnEliminar.UseVisualStyleBackColor = False
        btnEliminar.BackColor = Color.White
        btnEliminar.ForeColor = Color.FromArgb(57, 69, 76)
        btnCerrar.FlatStyle = FlatStyle.Flat
        btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnCerrar.Cursor = Cursors.Hand
        btnCerrar.UseVisualStyleBackColor = False
        btnCerrar.BackColor = Color.White
        btnCerrar.ForeColor = Color.FromArgb(57, 69, 76)
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnBuscar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnBuscar.Cursor = Cursors.Hand
        btnBuscar.UseVisualStyleBackColor = False
        btnBuscar.BackColor = Color.White
        btnBuscar.ForeColor = Color.FromArgb(57, 69, 76)
        btnVerTodos.FlatStyle = FlatStyle.Flat
        btnVerTodos.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnVerTodos.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnVerTodos.Cursor = Cursors.Hand
        btnVerTodos.UseVisualStyleBackColor = False
        btnVerTodos.BackColor = Color.White
        btnVerTodos.ForeColor = Color.FromArgb(57, 69, 76)
        btnLimpiar.FlatStyle = FlatStyle.Flat
        btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnLimpiar.Cursor = Cursors.Hand
        btnLimpiar.UseVisualStyleBackColor = False
        btnLimpiar.BackColor = Color.White
        btnLimpiar.ForeColor = Color.FromArgb(57, 69, 76)
        lblEstado.AutoEllipsis = True
        lblPendiente.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnGuardar, "✓  Guardar")
        ttpAcciones.SetToolTip(btnModificar, "✎  Modificar")
        ttpAcciones.SetToolTip(btnEliminar, "Eliminar")
        ttpAcciones.SetToolTip(btnCerrar, "←  Volver")
        ttpAcciones.SetToolTip(btnBuscar, "⌕  Buscar")
        ttpAcciones.SetToolTip(btnVerTodos, "≡  Ver todos")
        ttpAcciones.SetToolTip(btnLimpiar, "Vaciar los campos; no elimina registros.")
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
        layEditor.RowCount = 14
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
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.Dock = DockStyle.Top
        layEditor.AutoSize = True
        layEditor.Padding = New Padding(4, 4, 12, 8)
        layEditorPanel.Controls.Add(layEditor)
        lblIdCentro.Dock = DockStyle.Top
        lblIdCentro.Margin = New Padding(3, 2, 3, 6)
        lblIdCentro.TabIndex = 0
        lblIdCentro.AutoSize = True
        layEditor.Controls.Add(lblIdCentro, 0, 0)
        txtIdCentro.Dock = DockStyle.Top
        txtIdCentro.Margin = New Padding(3, 2, 3, 6)
        txtIdCentro.TabIndex = 1
        layEditor.Controls.Add(txtIdCentro, 0, 1)
        lblNombre.Dock = DockStyle.Top
        lblNombre.Margin = New Padding(3, 2, 3, 6)
        lblNombre.TabIndex = 2
        lblNombre.AutoSize = True
        layEditor.Controls.Add(lblNombre, 0, 2)
        txtNombre.Dock = DockStyle.Top
        txtNombre.Margin = New Padding(3, 2, 3, 6)
        txtNombre.TabIndex = 3
        layEditor.Controls.Add(txtNombre, 0, 3)
        lblDireccion.Dock = DockStyle.Top
        lblDireccion.Margin = New Padding(3, 2, 3, 6)
        lblDireccion.TabIndex = 4
        lblDireccion.AutoSize = True
        layEditor.Controls.Add(lblDireccion, 0, 4)
        txtDireccion.Dock = DockStyle.Top
        txtDireccion.Margin = New Padding(3, 2, 3, 6)
        txtDireccion.TabIndex = 5
        layEditor.Controls.Add(txtDireccion, 0, 5)
        lblTelefono.Dock = DockStyle.Top
        lblTelefono.Margin = New Padding(3, 2, 3, 6)
        lblTelefono.TabIndex = 6
        lblTelefono.AutoSize = True
        layEditor.Controls.Add(lblTelefono, 0, 6)
        txtTelefono.Dock = DockStyle.Top
        txtTelefono.Margin = New Padding(3, 2, 3, 6)
        txtTelefono.TabIndex = 7
        layEditor.Controls.Add(txtTelefono, 0, 7)
        lblEmail.Dock = DockStyle.Top
        lblEmail.Margin = New Padding(3, 2, 3, 6)
        lblEmail.TabIndex = 8
        lblEmail.AutoSize = True
        layEditor.Controls.Add(lblEmail, 0, 8)
        txtEmail.Dock = DockStyle.Top
        txtEmail.Margin = New Padding(3, 2, 3, 6)
        txtEmail.TabIndex = 9
        layEditor.Controls.Add(txtEmail, 0, 9)
        lblUso.Dock = DockStyle.Top
        lblUso.Margin = New Padding(3, 2, 3, 6)
        lblUso.TabIndex = 10
        lblUso.AutoSize = True
        layEditor.Controls.Add(lblUso, 0, 10)
        cboUso.Dock = DockStyle.Top
        cboUso.Margin = New Padding(3, 2, 3, 6)
        cboUso.TabIndex = 11
        layEditor.Controls.Add(cboUso, 0, 11)
        lblActivo.Dock = DockStyle.Top
        lblActivo.Margin = New Padding(3, 2, 3, 6)
        lblActivo.TabIndex = 12
        lblActivo.AutoSize = True
        layEditor.Controls.Add(lblActivo, 0, 12)
        chkActivo.Dock = DockStyle.Top
        chkActivo.Margin = New Padding(3, 2, 3, 6)
        chkActivo.TabIndex = 13
        chkActivo.AutoSize = True
        layEditor.Controls.Add(chkActivo, 0, 13)
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
        lblFiltro.Dock = DockStyle.Fill
        lblFiltro.Margin = New Padding(4)
        lblFiltro.AutoSize = True
        layListado.Controls.Add(lblFiltro, 0, 0)
        layFiltros.Name = "layFiltros"
        layFiltros.Dock = DockStyle.Fill
        layFiltros.AutoSize = True
        layFiltros.WrapContents = True
        layFiltros.Margin = New Padding(0)
        layListado.Controls.Add(layFiltros, 0, 1)
        txtFiltro.Dock = DockStyle.None
        txtFiltro.Margin = New Padding(4)
        txtFiltro.Width = 240
        layFiltros.Controls.Add(txtFiltro)
        btnBuscar.Dock = DockStyle.None
        btnBuscar.Margin = New Padding(4)
        btnBuscar.Dock = DockStyle.None
        btnBuscar.AutoSize = True
        btnBuscar.MinimumSize = New Size(110, 36)
        btnBuscar.Margin = New Padding(4, 4, 8, 4)
        layFiltros.Controls.Add(btnBuscar)
        btnVerTodos.Dock = DockStyle.None
        btnVerTodos.Margin = New Padding(4)
        btnVerTodos.Dock = DockStyle.None
        btnVerTodos.AutoSize = True
        btnVerTodos.MinimumSize = New Size(110, 36)
        btnVerTodos.Margin = New Padding(4, 4, 8, 4)
        layFiltros.Controls.Add(btnVerTodos)
        lblPendiente.Dock = DockStyle.Fill
        lblPendiente.Margin = New Padding(4)
        lblPendiente.AutoSize = True
        layListado.Controls.Add(lblPendiente, 0, 2)
        dgvCentros.Dock = DockStyle.Fill
        dgvCentros.Margin = New Padding(4)
        layListado.Controls.Add(dgvCentros, 0, 3)
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
        btnLimpiar.Dock = DockStyle.None
        btnLimpiar.AutoSize = True
        btnLimpiar.MinimumSize = New Size(110, 36)
        btnLimpiar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnLimpiar)
        btnEliminar.Dock = DockStyle.None
        btnEliminar.AutoSize = True
        btnEliminar.MinimumSize = New Size(110, 36)
        btnEliminar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnEliminar)
        btnCerrar.Dock = DockStyle.None
        btnCerrar.AutoSize = True
        btnCerrar.MinimumSize = New Size(110, 36)
        btnCerrar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnCerrar)
        dgvCentros.AllowUserToAddRows = False
        dgvCentros.AllowUserToDeleteRows = False
        dgvCentros.AllowUserToOrderColumns = False
        dgvCentros.AllowUserToResizeColumns = False
        dgvCentros.AllowUserToResizeRows = False
        dgvCentros.ReadOnly = True
        dgvCentros.MultiSelect = False
        dgvCentros.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCentros.ScrollBars = ScrollBars.Both
        dgvCentros.RowHeadersVisible = False
        dgvCentros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCentros.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvCentros.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvCentros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
        Name = "frmCentros"
        Text = "L&A | Centros externos"
        StartPosition = FormStartPosition.CenterScreen
        CType(dgvCentros, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblIdCentro As Label
    Friend WithEvents txtIdCentro As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblDireccion As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents lblTelefono As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblUso As Label
    Friend WithEvents cboUso As ComboBox
    Friend WithEvents lblActivo As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents dgvCentros As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblFiltro As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnVerTodos As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCerrar As Button
End Class
