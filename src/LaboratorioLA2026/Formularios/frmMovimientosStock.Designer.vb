<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovimientosStock
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
        lblInsumo = New Label()
        cboInsumo = New ComboBox()
        lblTipo = New Label()
        cboTipo = New ComboBox()
        lblCantidad = New Label()
        nudCantidad = New NumericUpDown()
        lblMotivo = New Label()
        txtMotivo = New TextBox()
        dgvMovimientosStock = New DataGridView()
        btnGuardar = New Button()
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
        CType(nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvMovimientosStock, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitulo.Text = "Movimientos de stock"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 126)
        lblEstado.Size = New Size(1100, 38)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Entradas y salidas registradas junto con el cambio de saldo."
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
        ' lblInsumo
        lblInsumo.Name = "lblInsumo"
        lblInsumo.UseMnemonic = False
        lblInsumo.Location = New Point(28, 178)
        lblInsumo.Size = New Size(316, 20)
        lblInsumo.TabIndex = 5
        lblInsumo.Text = "Insumo"
        ' cboInsumo
        cboInsumo.Name = "cboInsumo"
        cboInsumo.Location = New Point(28, 200)
        cboInsumo.Size = New Size(310, 27)
        cboInsumo.TabIndex = 6
        cboInsumo.Enabled = False
        cboInsumo.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblTipo
        lblTipo.Name = "lblTipo"
        lblTipo.UseMnemonic = False
        lblTipo.Location = New Point(28, 240)
        lblTipo.Size = New Size(316, 20)
        lblTipo.TabIndex = 7
        lblTipo.Text = "Entrada / salida"
        ' cboTipo
        cboTipo.Name = "cboTipo"
        cboTipo.Location = New Point(28, 262)
        cboTipo.Size = New Size(310, 27)
        cboTipo.TabIndex = 8
        cboTipo.Enabled = False
        cboTipo.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblCantidad
        lblCantidad.Name = "lblCantidad"
        lblCantidad.UseMnemonic = False
        lblCantidad.Location = New Point(28, 302)
        lblCantidad.Size = New Size(316, 20)
        lblCantidad.TabIndex = 9
        lblCantidad.Text = "Cantidad"
        ' nudCantidad
        nudCantidad.Name = "nudCantidad"
        nudCantidad.Location = New Point(28, 324)
        nudCantidad.Size = New Size(310, 27)
        nudCantidad.TabIndex = 10
        nudCantidad.Enabled = False
        nudCantidad.Maximum = New Decimal(2147483647)
        ' lblMotivo
        lblMotivo.Name = "lblMotivo"
        lblMotivo.UseMnemonic = False
        lblMotivo.Location = New Point(28, 364)
        lblMotivo.Size = New Size(316, 20)
        lblMotivo.TabIndex = 11
        lblMotivo.Text = "Motivo"
        ' txtMotivo
        txtMotivo.Name = "txtMotivo"
        txtMotivo.Location = New Point(28, 386)
        txtMotivo.Size = New Size(310, 27)
        txtMotivo.TabIndex = 12
        txtMotivo.Enabled = False
        txtMotivo.MaxLength = 255
        ' dgvMovimientosStock
        dgvMovimientosStock.Name = "dgvMovimientosStock"
        dgvMovimientosStock.Location = New Point(370, 284)
        dgvMovimientosStock.Size = New Size(750, 314)
        dgvMovimientosStock.TabIndex = 13
        dgvMovimientosStock.ReadOnly = True
        dgvMovimientosStock.AllowUserToAddRows = False
        dgvMovimientosStock.AllowUserToDeleteRows = False
        dgvMovimientosStock.MultiSelect = False
        dgvMovimientosStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMovimientosStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMovimientosStock.BackgroundColor = Color.White
        dgvMovimientosStock.BorderStyle = BorderStyle.FixedSingle
        dgvMovimientosStock.Enabled = False
        dgvMovimientosStock.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
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
        lblEstado.AutoEllipsis = True
        lblPendiente.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnGuardar, "✓  Guardar")
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
        layEditor.RowCount = 8
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
        layEditor.Dock = DockStyle.Top
        layEditor.AutoSize = True
        layEditor.Padding = New Padding(4, 4, 12, 8)
        layEditorPanel.Controls.Add(layEditor)
        lblInsumo.Dock = DockStyle.Top
        lblInsumo.Margin = New Padding(3, 2, 3, 6)
        lblInsumo.TabIndex = 0
        lblInsumo.AutoSize = True
        layEditor.Controls.Add(lblInsumo, 0, 0)
        cboInsumo.Dock = DockStyle.Top
        cboInsumo.Margin = New Padding(3, 2, 3, 6)
        cboInsumo.TabIndex = 1
        layEditor.Controls.Add(cboInsumo, 0, 1)
        lblTipo.Dock = DockStyle.Top
        lblTipo.Margin = New Padding(3, 2, 3, 6)
        lblTipo.TabIndex = 2
        lblTipo.AutoSize = True
        layEditor.Controls.Add(lblTipo, 0, 2)
        cboTipo.Dock = DockStyle.Top
        cboTipo.Margin = New Padding(3, 2, 3, 6)
        cboTipo.TabIndex = 3
        layEditor.Controls.Add(cboTipo, 0, 3)
        lblCantidad.Dock = DockStyle.Top
        lblCantidad.Margin = New Padding(3, 2, 3, 6)
        lblCantidad.TabIndex = 4
        lblCantidad.AutoSize = True
        layEditor.Controls.Add(lblCantidad, 0, 4)
        nudCantidad.Dock = DockStyle.Top
        nudCantidad.Margin = New Padding(3, 2, 3, 6)
        nudCantidad.TabIndex = 5
        layEditor.Controls.Add(nudCantidad, 0, 5)
        lblMotivo.Dock = DockStyle.Top
        lblMotivo.Margin = New Padding(3, 2, 3, 6)
        lblMotivo.TabIndex = 6
        lblMotivo.AutoSize = True
        layEditor.Controls.Add(lblMotivo, 0, 6)
        txtMotivo.Dock = DockStyle.Top
        txtMotivo.Margin = New Padding(3, 2, 3, 6)
        txtMotivo.TabIndex = 7
        layEditor.Controls.Add(txtMotivo, 0, 7)
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
        dgvMovimientosStock.Dock = DockStyle.Fill
        dgvMovimientosStock.Margin = New Padding(4)
        layListado.Controls.Add(dgvMovimientosStock, 0, 3)
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
        btnCerrar.Dock = DockStyle.None
        btnCerrar.AutoSize = True
        btnCerrar.MinimumSize = New Size(110, 36)
        btnCerrar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnCerrar)
        dgvMovimientosStock.AllowUserToAddRows = False
        dgvMovimientosStock.AllowUserToDeleteRows = False
        dgvMovimientosStock.AllowUserToOrderColumns = False
        dgvMovimientosStock.AllowUserToResizeColumns = False
        dgvMovimientosStock.AllowUserToResizeRows = False
        dgvMovimientosStock.ReadOnly = True
        dgvMovimientosStock.MultiSelect = False
        dgvMovimientosStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMovimientosStock.ScrollBars = ScrollBars.Both
        dgvMovimientosStock.RowHeadersVisible = False
        dgvMovimientosStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMovimientosStock.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMovimientosStock.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMovimientosStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
        Name = "frmMovimientosStock"
        Text = "L&A | Movimientos de stock"
        StartPosition = FormStartPosition.CenterScreen
        CType(nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(dgvMovimientosStock, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblInsumo As Label
    Friend WithEvents cboInsumo As ComboBox
    Friend WithEvents lblTipo As Label
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents lblMotivo As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents dgvMovimientosStock As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCerrar As Button
End Class
