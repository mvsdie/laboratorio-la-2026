<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInsumos
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
        lblIdInsumo = New Label()
        txtIdInsumo = New TextBox()
        lblNombre = New Label()
        txtNombre = New TextBox()
        lblUnidad = New Label()
        txtUnidad = New TextBox()
        lblDescripcion = New Label()
        txtDescripcion = New TextBox()
        lblStockActual = New Label()
        txtStockActual = New TextBox()
        lblStockMinimo = New Label()
        nudStockMinimo = New NumericUpDown()
        lblActivo = New Label()
        chkActivo = New CheckBox()
        dgvInsumos = New DataGridView()
        btnGuardar = New Button()
        btnModificar = New Button()
        btnEliminar = New Button()
        btnCerrar = New Button()
        lblFiltro = New Label()
        txtFiltro = New TextBox()
        btnBuscar = New Button()
        btnVerTodos = New Button()
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
        CType(nudStockMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitulo.Text = "Insumos"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 126)
        lblEstado.Size = New Size(1100, 38)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Existencias de solo lectura; se modificarán mediante movimientos."
        lblEstado.ForeColor = Color.FromArgb(75, 85, 93)
        lblEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(370, 238)
        lblPendiente.Size = New Size(750, 38)
        lblPendiente.TabIndex = 4
        lblPendiente.Text = "Consultá los datos existentes. Las operaciones de registro siguen pendientes."
        lblPendiente.ForeColor = Color.FromArgb(157, 43, 59)
        ' lblIdInsumo
        lblIdInsumo.Name = "lblIdInsumo"
        lblIdInsumo.UseMnemonic = False
        lblIdInsumo.Location = New Point(28, 178)
        lblIdInsumo.Size = New Size(316, 20)
        lblIdInsumo.TabIndex = 5
        lblIdInsumo.Text = "ID"
        ' txtIdInsumo
        txtIdInsumo.Name = "txtIdInsumo"
        txtIdInsumo.Location = New Point(28, 200)
        txtIdInsumo.Size = New Size(310, 27)
        txtIdInsumo.TabIndex = 6
        txtIdInsumo.Enabled = False
        txtIdInsumo.MaxLength = 255
        txtIdInsumo.ReadOnly = True
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
        txtNombre.MaxLength = 255
        ' lblUnidad
        lblUnidad.Name = "lblUnidad"
        lblUnidad.UseMnemonic = False
        lblUnidad.Location = New Point(28, 302)
        lblUnidad.Size = New Size(316, 20)
        lblUnidad.TabIndex = 9
        lblUnidad.Text = "Unidad de medida"
        ' txtUnidad
        txtUnidad.Name = "txtUnidad"
        txtUnidad.Location = New Point(28, 324)
        txtUnidad.Size = New Size(310, 27)
        txtUnidad.TabIndex = 10
        txtUnidad.Enabled = False
        txtUnidad.MaxLength = 255
        ' lblDescripcion
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.UseMnemonic = False
        lblDescripcion.Location = New Point(28, 364)
        lblDescripcion.Size = New Size(316, 20)
        lblDescripcion.TabIndex = 11
        lblDescripcion.Text = "Descripción"
        ' txtDescripcion
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Location = New Point(28, 386)
        txtDescripcion.Size = New Size(310, 27)
        txtDescripcion.TabIndex = 12
        txtDescripcion.Enabled = False
        txtDescripcion.MaxLength = 255
        ' lblStockActual
        lblStockActual.Name = "lblStockActual"
        lblStockActual.UseMnemonic = False
        lblStockActual.Location = New Point(28, 426)
        lblStockActual.Size = New Size(316, 20)
        lblStockActual.TabIndex = 13
        lblStockActual.Text = "Stock actual (solo lectura)"
        ' txtStockActual
        txtStockActual.Name = "txtStockActual"
        txtStockActual.Location = New Point(28, 448)
        txtStockActual.Size = New Size(310, 27)
        txtStockActual.TabIndex = 14
        txtStockActual.Enabled = False
        txtStockActual.MaxLength = 255
        txtStockActual.ReadOnly = True
        ' lblStockMinimo
        lblStockMinimo.Name = "lblStockMinimo"
        lblStockMinimo.UseMnemonic = False
        lblStockMinimo.Location = New Point(28, 488)
        lblStockMinimo.Size = New Size(316, 20)
        lblStockMinimo.TabIndex = 15
        lblStockMinimo.Text = "Stock mínimo"
        ' nudStockMinimo
        nudStockMinimo.Name = "nudStockMinimo"
        nudStockMinimo.Location = New Point(28, 510)
        nudStockMinimo.Size = New Size(310, 27)
        nudStockMinimo.TabIndex = 16
        nudStockMinimo.Enabled = False
        nudStockMinimo.Maximum = New Decimal(2147483647)
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
        ' dgvInsumos
        dgvInsumos.Name = "dgvInsumos"
        dgvInsumos.Location = New Point(370, 284)
        dgvInsumos.Size = New Size(750, 314)
        dgvInsumos.TabIndex = 19
        dgvInsumos.ReadOnly = True
        dgvInsumos.AllowUserToAddRows = False
        dgvInsumos.AllowUserToDeleteRows = False
        dgvInsumos.MultiSelect = False
        dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInsumos.BackgroundColor = Color.White
        dgvInsumos.BorderStyle = BorderStyle.FixedSingle
        dgvInsumos.Enabled = False
        dgvInsumos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
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
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnCerrar
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Location = New Point(975, 675)
        btnCerrar.Size = New Size(145, 36)
        btnCerrar.TabIndex = 23
        btnCerrar.Text = "←  Volver"
        btnCerrar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
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
        lblEstado.AutoEllipsis = True
        lblPendiente.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnGuardar, "✓  Guardar")
        ttpAcciones.SetToolTip(btnModificar, "✎  Modificar")
        ttpAcciones.SetToolTip(btnEliminar, "Eliminar")
        ttpAcciones.SetToolTip(btnCerrar, "←  Volver")
        lblFiltro.Name = "lblFiltro"
        lblFiltro.Text = "Buscar en el listado (solo consulta)"
        lblFiltro.Location = New Point(370, 178)
        lblFiltro.Size = New Size(750, 20)
        txtFiltro.Name = "txtFiltro"
        txtFiltro.Location = New Point(370, 202)
        txtFiltro.Size = New Size(450, 27)
        txtFiltro.MaxLength = 100
        txtFiltro.TabIndex = 40
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Text = "⌕ Buscar"
        btnBuscar.Location = New Point(830, 202)
        btnBuscar.Size = New Size(135, 36)
        btnBuscar.TabIndex = 41
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnBuscar.BackColor = Color.White
        btnBuscar.Cursor = Cursors.Hand
        ttpAcciones.SetToolTip(btnBuscar, "Consultar sin modificar registros.")
        btnVerTodos.Name = "btnVerTodos"
        btnVerTodos.Text = "≡ Ver todos"
        btnVerTodos.Location = New Point(975, 202)
        btnVerTodos.Size = New Size(145, 36)
        btnVerTodos.TabIndex = 42
        btnVerTodos.FlatStyle = FlatStyle.Flat
        btnVerTodos.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnVerTodos.BackColor = Color.White
        btnVerTodos.Cursor = Cursors.Hand
        ttpAcciones.SetToolTip(btnVerTodos, "Consultar sin modificar registros.")
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
        lblIdInsumo.Dock = DockStyle.Top
        lblIdInsumo.Margin = New Padding(3, 2, 3, 6)
        lblIdInsumo.TabIndex = 0
        lblIdInsumo.AutoSize = True
        layEditor.Controls.Add(lblIdInsumo, 0, 0)
        txtIdInsumo.Dock = DockStyle.Top
        txtIdInsumo.Margin = New Padding(3, 2, 3, 6)
        txtIdInsumo.TabIndex = 1
        layEditor.Controls.Add(txtIdInsumo, 0, 1)
        lblNombre.Dock = DockStyle.Top
        lblNombre.Margin = New Padding(3, 2, 3, 6)
        lblNombre.TabIndex = 2
        lblNombre.AutoSize = True
        layEditor.Controls.Add(lblNombre, 0, 2)
        txtNombre.Dock = DockStyle.Top
        txtNombre.Margin = New Padding(3, 2, 3, 6)
        txtNombre.TabIndex = 3
        layEditor.Controls.Add(txtNombre, 0, 3)
        lblUnidad.Dock = DockStyle.Top
        lblUnidad.Margin = New Padding(3, 2, 3, 6)
        lblUnidad.TabIndex = 4
        lblUnidad.AutoSize = True
        layEditor.Controls.Add(lblUnidad, 0, 4)
        txtUnidad.Dock = DockStyle.Top
        txtUnidad.Margin = New Padding(3, 2, 3, 6)
        txtUnidad.TabIndex = 5
        layEditor.Controls.Add(txtUnidad, 0, 5)
        lblDescripcion.Dock = DockStyle.Top
        lblDescripcion.Margin = New Padding(3, 2, 3, 6)
        lblDescripcion.TabIndex = 6
        lblDescripcion.AutoSize = True
        layEditor.Controls.Add(lblDescripcion, 0, 6)
        txtDescripcion.Dock = DockStyle.Top
        txtDescripcion.Margin = New Padding(3, 2, 3, 6)
        txtDescripcion.TabIndex = 7
        layEditor.Controls.Add(txtDescripcion, 0, 7)
        lblStockActual.Dock = DockStyle.Top
        lblStockActual.Margin = New Padding(3, 2, 3, 6)
        lblStockActual.TabIndex = 8
        lblStockActual.AutoSize = True
        layEditor.Controls.Add(lblStockActual, 0, 8)
        txtStockActual.Dock = DockStyle.Top
        txtStockActual.Margin = New Padding(3, 2, 3, 6)
        txtStockActual.TabIndex = 9
        layEditor.Controls.Add(txtStockActual, 0, 9)
        lblStockMinimo.Dock = DockStyle.Top
        lblStockMinimo.Margin = New Padding(3, 2, 3, 6)
        lblStockMinimo.TabIndex = 10
        lblStockMinimo.AutoSize = True
        layEditor.Controls.Add(lblStockMinimo, 0, 10)
        nudStockMinimo.Dock = DockStyle.Top
        nudStockMinimo.Margin = New Padding(3, 2, 3, 6)
        nudStockMinimo.TabIndex = 11
        layEditor.Controls.Add(nudStockMinimo, 0, 11)
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
        dgvInsumos.Dock = DockStyle.Fill
        dgvInsumos.Margin = New Padding(4)
        layListado.Controls.Add(dgvInsumos, 0, 3)
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
        dgvInsumos.AllowUserToAddRows = False
        dgvInsumos.AllowUserToDeleteRows = False
        dgvInsumos.AllowUserToOrderColumns = False
        dgvInsumos.AllowUserToResizeColumns = False
        dgvInsumos.AllowUserToResizeRows = False
        dgvInsumos.ReadOnly = True
        dgvInsumos.MultiSelect = False
        dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInsumos.ScrollBars = ScrollBars.Both
        dgvInsumos.RowHeadersVisible = False
        dgvInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInsumos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvInsumos.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvInsumos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
        Name = "frmInsumos"
        Text = "L&A | Insumos"
        StartPosition = FormStartPosition.CenterScreen
        CType(nudStockMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(dgvInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblFiltro As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnVerTodos As Button
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblPendiente As Label
    Friend WithEvents lblIdInsumo As Label
    Friend WithEvents txtIdInsumo As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblUnidad As Label
    Friend WithEvents txtUnidad As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblStockActual As Label
    Friend WithEvents txtStockActual As TextBox
    Friend WithEvents lblStockMinimo As Label
    Friend WithEvents nudStockMinimo As NumericUpDown
    Friend WithEvents lblActivo As Label
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents dgvInsumos As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCerrar As Button
End Class
