<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMuestras
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
    Friend WithEvents btnGenerarCodigo As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents lblPacienteMuestra As Label
    Friend WithEvents lblFechaRecepcion As Label
    Friend WithEvents dtpFechaRecepcion As DateTimePicker
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents txtObservaciones As TextBox
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
        lblSubtitulo = New Label()
        lblPendiente = New Label()
        lblCodigo = New Label()
        txtCodigo = New TextBox()
        lblOrden = New Label()
        cboOrden = New ComboBox()
        lblTipoMuestra = New Label()
        txtTipoMuestra = New TextBox()
        lblCentroOrigen = New Label()
        cboCentroOrigen = New ComboBox()
        lblEstado = New Label()
        cboEstado = New ComboBox()
        lblDocumentacion = New Label()
        chkDocumentacion = New CheckBox()
        lblAnalisis = New Label()
        checklistAnalisis = New CheckedListBox()
        dgvMuestras = New DataGridView()
        btnGuardar = New Button()
        btnModificar = New Button()
        btnCerrar = New Button()
        lblFiltro = New Label()
        txtFiltro = New TextBox()
        btnBuscar = New Button()
        btnVerTodos = New Button()
        btnGenerarCodigo = New Button()
        btnNuevo = New Button()
        lblPacienteMuestra = New Label()
        lblFechaRecepcion = New Label()
        dtpFechaRecepcion = New DateTimePicker()
        lblObservaciones = New Label()
        txtObservaciones = New TextBox()
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
        CType(dgvMuestras, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitulo.Text = "Registro de muestras"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblSubtitulo
        lblSubtitulo.Name = "lblSubtitulo"
        lblSubtitulo.UseMnemonic = False
        lblSubtitulo.Location = New Point(28, 126)
        lblSubtitulo.Size = New Size(1100, 38)
        lblSubtitulo.TabIndex = 3
        lblSubtitulo.Text = "Una muestra física por código, con sus análisis solicitados."
        lblSubtitulo.ForeColor = Color.FromArgb(75, 85, 93)
        lblSubtitulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(370, 238)
        lblPendiente.Size = New Size(750, 38)
        lblPendiente.TabIndex = 4
        lblPendiente.Text = "Consultá los datos existentes. Las operaciones de registro siguen pendientes."
        lblPendiente.ForeColor = Color.FromArgb(157, 43, 59)
        ' lblCodigo
        lblCodigo.Name = "lblCodigo"
        lblCodigo.UseMnemonic = False
        lblCodigo.Location = New Point(28, 178)
        lblCodigo.Size = New Size(316, 20)
        lblCodigo.TabIndex = 5
        lblCodigo.Text = "Código de contenedor"
        ' txtCodigo
        txtCodigo.Name = "txtCodigo"
        txtCodigo.Location = New Point(28, 200)
        txtCodigo.Size = New Size(310, 27)
        txtCodigo.TabIndex = 6
        txtCodigo.Enabled = False
        txtCodigo.MaxLength = 255
        ' lblOrden
        lblOrden.Name = "lblOrden"
        lblOrden.UseMnemonic = False
        lblOrden.Location = New Point(28, 240)
        lblOrden.Size = New Size(316, 20)
        lblOrden.TabIndex = 7
        lblOrden.Text = "Orden"
        ' cboOrden
        cboOrden.Name = "cboOrden"
        cboOrden.Location = New Point(28, 262)
        cboOrden.Size = New Size(310, 27)
        cboOrden.TabIndex = 8
        cboOrden.Enabled = False
        cboOrden.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblTipoMuestra
        lblTipoMuestra.Name = "lblTipoMuestra"
        lblTipoMuestra.UseMnemonic = False
        lblTipoMuestra.Location = New Point(28, 302)
        lblTipoMuestra.Size = New Size(316, 20)
        lblTipoMuestra.TabIndex = 9
        lblTipoMuestra.Text = "Tipo de muestra"
        ' txtTipoMuestra
        txtTipoMuestra.Name = "txtTipoMuestra"
        txtTipoMuestra.Location = New Point(28, 324)
        txtTipoMuestra.Size = New Size(310, 27)
        txtTipoMuestra.TabIndex = 10
        txtTipoMuestra.Enabled = False
        txtTipoMuestra.MaxLength = 255
        ' lblCentroOrigen
        lblCentroOrigen.Name = "lblCentroOrigen"
        lblCentroOrigen.UseMnemonic = False
        lblCentroOrigen.Location = New Point(28, 364)
        lblCentroOrigen.Size = New Size(316, 20)
        lblCentroOrigen.TabIndex = 11
        lblCentroOrigen.Text = "Centro de origen (opcional)"
        ' cboCentroOrigen
        cboCentroOrigen.Name = "cboCentroOrigen"
        cboCentroOrigen.Location = New Point(28, 386)
        cboCentroOrigen.Size = New Size(310, 27)
        cboCentroOrigen.TabIndex = 12
        cboCentroOrigen.Enabled = False
        cboCentroOrigen.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 426)
        lblEstado.Size = New Size(316, 20)
        lblEstado.TabIndex = 13
        lblEstado.Text = "Estado administrativo"
        ' cboEstado
        cboEstado.Name = "cboEstado"
        cboEstado.Location = New Point(28, 448)
        cboEstado.Size = New Size(310, 27)
        cboEstado.TabIndex = 14
        cboEstado.Enabled = False
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblDocumentacion
        lblDocumentacion.Name = "lblDocumentacion"
        lblDocumentacion.UseMnemonic = False
        lblDocumentacion.Location = New Point(28, 488)
        lblDocumentacion.Size = New Size(316, 20)
        lblDocumentacion.TabIndex = 15
        lblDocumentacion.Text = "Revisión administrativa"
        ' chkDocumentacion
        chkDocumentacion.Name = "chkDocumentacion"
        chkDocumentacion.Text = "Documentación completa"
        chkDocumentacion.Location = New Point(28, 510)
        chkDocumentacion.Size = New Size(310, 27)
        chkDocumentacion.TabIndex = 16
        chkDocumentacion.Enabled = False
        ' lblAnalisis
        lblAnalisis.Name = "lblAnalisis"
        lblAnalisis.UseMnemonic = False
        lblAnalisis.Location = New Point(28, 550)
        lblAnalisis.Size = New Size(316, 20)
        lblAnalisis.TabIndex = 17
        lblAnalisis.Text = "Análisis de la muestra"
        ' checklistAnalisis
        checklistAnalisis.Name = "checklistAnalisis"
        checklistAnalisis.Location = New Point(28, 572)
        checklistAnalisis.Size = New Size(310, 70)
        checklistAnalisis.TabIndex = 18
        checklistAnalisis.Enabled = False
        ' dgvMuestras
        dgvMuestras.Name = "dgvMuestras"
        dgvMuestras.Location = New Point(370, 284)
        dgvMuestras.Size = New Size(750, 314)
        dgvMuestras.TabIndex = 19
        dgvMuestras.ReadOnly = True
        dgvMuestras.AllowUserToAddRows = False
        dgvMuestras.AllowUserToDeleteRows = False
        dgvMuestras.MultiSelect = False
        dgvMuestras.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMuestras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMuestras.BackgroundColor = Color.White
        dgvMuestras.BorderStyle = BorderStyle.FixedSingle
        dgvMuestras.Enabled = False
        dgvMuestras.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
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
        ' btnCerrar
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Location = New Point(975, 675)
        btnCerrar.Size = New Size(145, 36)
        btnCerrar.TabIndex = 22
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
        btnGenerarCodigo.Name = "btnGenerarCodigo"
        btnGenerarCodigo.Size = New Size(250, 30)
        btnGenerarCodigo.Text = "Generar código"
        btnGenerarCodigo.FlatStyle = FlatStyle.Flat
        btnGenerarCodigo.BackColor = Color.White
        btnGenerarCodigo.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(250, 30)
        btnNuevo.Text = "Nueva / Limpiar"
        btnNuevo.FlatStyle = FlatStyle.Flat
        btnNuevo.BackColor = Color.White
        btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        lblPacienteMuestra.Name = "lblPacienteMuestra"
        lblPacienteMuestra.Size = New Size(250, 30)
        lblPacienteMuestra.Text = "Paciente de la orden: sin selección"
        lblFechaRecepcion.Name = "lblFechaRecepcion"
        lblFechaRecepcion.Size = New Size(250, 30)
        lblFechaRecepcion.Text = "Fecha de recepción"
        dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        dtpFechaRecepcion.Size = New Size(250, 30)
        dtpFechaRecepcion.Format = DateTimePickerFormat.Custom
        dtpFechaRecepcion.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        lblObservaciones.Name = "lblObservaciones"
        lblObservaciones.Size = New Size(250, 30)
        lblObservaciones.Text = "Observaciones administrativas"
        txtObservaciones.Name = "txtObservaciones"
        txtObservaciones.Size = New Size(250, 30)
        txtCodigo.MaxLength = 30
        txtTipoMuestra.MaxLength = 60
        txtObservaciones.MaxLength = 255
        txtObservaciones.Multiline = True
        txtObservaciones.Height = 65
        KeyPreview = True
        ttpAcciones.SetToolTip(txtCodigo, "Código de contenedor, distinto del NBU. El escáner actúa como teclado; Enter busca, no guarda.")
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
        lblSubtitulo.Dock = DockStyle.Fill
        lblSubtitulo.Margin = New Padding(4)
        lblSubtitulo.AutoSize = True
        lblSubtitulo.Padding = New Padding(4, 10, 4, 10)
        layPantalla.Controls.Add(lblSubtitulo, 0, 1)
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
        layEditor.RowCount = 21
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
        lblCodigo.Dock = DockStyle.Top
        lblCodigo.Margin = New Padding(3, 2, 3, 6)
        lblCodigo.TabIndex = 0
        lblCodigo.AutoSize = True
        layEditor.Controls.Add(lblCodigo, 0, 0)
        txtCodigo.Dock = DockStyle.Top
        txtCodigo.Margin = New Padding(3, 2, 3, 6)
        txtCodigo.TabIndex = 1
        layEditor.Controls.Add(txtCodigo, 0, 1)
        btnGenerarCodigo.Dock = DockStyle.Top
        btnGenerarCodigo.Margin = New Padding(3, 2, 3, 6)
        btnGenerarCodigo.TabIndex = 2
        btnGenerarCodigo.Dock = DockStyle.None
        btnGenerarCodigo.AutoSize = True
        btnGenerarCodigo.MinimumSize = New Size(110, 36)
        btnGenerarCodigo.Margin = New Padding(4, 4, 8, 4)
        layEditor.Controls.Add(btnGenerarCodigo, 0, 2)
        btnNuevo.Dock = DockStyle.Top
        btnNuevo.Margin = New Padding(3, 2, 3, 6)
        btnNuevo.TabIndex = 3
        btnNuevo.Dock = DockStyle.None
        btnNuevo.AutoSize = True
        btnNuevo.MinimumSize = New Size(110, 36)
        btnNuevo.Margin = New Padding(4, 4, 8, 4)
        layEditor.Controls.Add(btnNuevo, 0, 3)
        lblOrden.Dock = DockStyle.Top
        lblOrden.Margin = New Padding(3, 2, 3, 6)
        lblOrden.TabIndex = 4
        lblOrden.AutoSize = True
        layEditor.Controls.Add(lblOrden, 0, 4)
        cboOrden.Dock = DockStyle.Top
        cboOrden.Margin = New Padding(3, 2, 3, 6)
        cboOrden.TabIndex = 5
        layEditor.Controls.Add(cboOrden, 0, 5)
        lblPacienteMuestra.Dock = DockStyle.Top
        lblPacienteMuestra.Margin = New Padding(3, 2, 3, 6)
        lblPacienteMuestra.TabIndex = 6
        lblPacienteMuestra.AutoSize = True
        layEditor.Controls.Add(lblPacienteMuestra, 0, 6)
        lblFechaRecepcion.Dock = DockStyle.Top
        lblFechaRecepcion.Margin = New Padding(3, 2, 3, 6)
        lblFechaRecepcion.TabIndex = 7
        lblFechaRecepcion.AutoSize = True
        layEditor.Controls.Add(lblFechaRecepcion, 0, 7)
        dtpFechaRecepcion.Dock = DockStyle.Top
        dtpFechaRecepcion.Margin = New Padding(3, 2, 3, 6)
        dtpFechaRecepcion.TabIndex = 8
        layEditor.Controls.Add(dtpFechaRecepcion, 0, 8)
        lblTipoMuestra.Dock = DockStyle.Top
        lblTipoMuestra.Margin = New Padding(3, 2, 3, 6)
        lblTipoMuestra.TabIndex = 9
        lblTipoMuestra.AutoSize = True
        layEditor.Controls.Add(lblTipoMuestra, 0, 9)
        txtTipoMuestra.Dock = DockStyle.Top
        txtTipoMuestra.Margin = New Padding(3, 2, 3, 6)
        txtTipoMuestra.TabIndex = 10
        layEditor.Controls.Add(txtTipoMuestra, 0, 10)
        lblCentroOrigen.Dock = DockStyle.Top
        lblCentroOrigen.Margin = New Padding(3, 2, 3, 6)
        lblCentroOrigen.TabIndex = 11
        lblCentroOrigen.AutoSize = True
        layEditor.Controls.Add(lblCentroOrigen, 0, 11)
        cboCentroOrigen.Dock = DockStyle.Top
        cboCentroOrigen.Margin = New Padding(3, 2, 3, 6)
        cboCentroOrigen.TabIndex = 12
        layEditor.Controls.Add(cboCentroOrigen, 0, 12)
        lblEstado.Dock = DockStyle.Top
        lblEstado.Margin = New Padding(3, 2, 3, 6)
        lblEstado.TabIndex = 13
        lblEstado.AutoSize = True
        layEditor.Controls.Add(lblEstado, 0, 13)
        cboEstado.Dock = DockStyle.Top
        cboEstado.Margin = New Padding(3, 2, 3, 6)
        cboEstado.TabIndex = 14
        layEditor.Controls.Add(cboEstado, 0, 14)
        lblDocumentacion.Dock = DockStyle.Top
        lblDocumentacion.Margin = New Padding(3, 2, 3, 6)
        lblDocumentacion.TabIndex = 15
        lblDocumentacion.AutoSize = True
        layEditor.Controls.Add(lblDocumentacion, 0, 15)
        chkDocumentacion.Dock = DockStyle.Top
        chkDocumentacion.Margin = New Padding(3, 2, 3, 6)
        chkDocumentacion.TabIndex = 16
        chkDocumentacion.AutoSize = True
        layEditor.Controls.Add(chkDocumentacion, 0, 16)
        lblAnalisis.Dock = DockStyle.Top
        lblAnalisis.Margin = New Padding(3, 2, 3, 6)
        lblAnalisis.TabIndex = 17
        lblAnalisis.AutoSize = True
        layEditor.Controls.Add(lblAnalisis, 0, 17)
        checklistAnalisis.Dock = DockStyle.Top
        checklistAnalisis.Margin = New Padding(3, 2, 3, 6)
        checklistAnalisis.TabIndex = 18
        checklistAnalisis.Height = 140
        checklistAnalisis.IntegralHeight = False
        checklistAnalisis.CheckOnClick = True
        checklistAnalisis.FormattingEnabled = True
        layEditor.Controls.Add(checklistAnalisis, 0, 18)
        lblObservaciones.Dock = DockStyle.Top
        lblObservaciones.Margin = New Padding(3, 2, 3, 6)
        lblObservaciones.TabIndex = 19
        lblObservaciones.AutoSize = True
        layEditor.Controls.Add(lblObservaciones, 0, 19)
        txtObservaciones.Dock = DockStyle.Top
        txtObservaciones.Margin = New Padding(3, 2, 3, 6)
        txtObservaciones.TabIndex = 20
        layEditor.Controls.Add(txtObservaciones, 0, 20)
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
        dgvMuestras.Dock = DockStyle.Fill
        dgvMuestras.Margin = New Padding(4)
        layListado.Controls.Add(dgvMuestras, 0, 3)
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
        dgvMuestras.AllowUserToAddRows = False
        dgvMuestras.AllowUserToDeleteRows = False
        dgvMuestras.AllowUserToOrderColumns = False
        dgvMuestras.AllowUserToResizeColumns = False
        dgvMuestras.AllowUserToResizeRows = False
        dgvMuestras.ReadOnly = True
        dgvMuestras.MultiSelect = False
        dgvMuestras.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMuestras.ScrollBars = ScrollBars.Both
        dgvMuestras.RowHeadersVisible = False
        dgvMuestras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMuestras.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMuestras.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMuestras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
        Name = "frmMuestras"
        Text = "L&A | Registro de muestras"
        StartPosition = FormStartPosition.CenterScreen
        CType(dgvMuestras, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents lblPendiente As Label
    Friend WithEvents lblCodigo As Label
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents lblOrden As Label
    Friend WithEvents cboOrden As ComboBox
    Friend WithEvents lblTipoMuestra As Label
    Friend WithEvents txtTipoMuestra As TextBox
    Friend WithEvents lblCentroOrigen As Label
    Friend WithEvents cboCentroOrigen As ComboBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents lblDocumentacion As Label
    Friend WithEvents chkDocumentacion As CheckBox
    Friend WithEvents lblAnalisis As Label
    Friend WithEvents checklistAnalisis As CheckedListBox
    Friend WithEvents dgvMuestras As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnCerrar As Button
End Class
