<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenes
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
        lblIdOrden = New Label()
        txtIdOrden = New TextBox()
        lblPaciente = New Label()
        cboPaciente = New ComboBox()
        lblFecha = New Label()
        dtpFecha = New DateTimePicker()
        lblAnalisis = New Label()
        checklistAnalisis = New CheckedListBox()
        dgvOrdenes = New DataGridView()
        btnGuardar = New Button()
        btnCotizar = New Button()
        btnModificar = New Button()
        btnCerrar = New Button()
        lblBuscarPaciente = New Label()
        txtBuscarPaciente = New TextBox()
        btnBuscarPaciente = New Button()
        lblPacienteSeleccionado = New Label()
        lblFiltro = New Label()
        txtFiltro = New TextBox()
        btnBuscar = New Button()
        btnVerTodos = New Button()
        lblFiltroFecha = New Label()
        dtpFiltroFecha = New DateTimePicker()
        lblDetalle = New Label()
        dgvDetalle = New DataGridView()
        btnQuitar = New Button()
        btnNuevo = New Button()
        lblSituacion = New Label()
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
        CType(dgvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
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
        lblTitulo.Text = "Órdenes de análisis"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 126)
        lblEstado.Size = New Size(1100, 38)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Solicitud de un paciente y selección de estudios."
        lblEstado.ForeColor = Color.FromArgb(75, 85, 93)
        lblEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' lblPendiente
        lblPendiente.Name = "lblPendiente"
        lblPendiente.UseMnemonic = False
        lblPendiente.Location = New Point(370, 274)
        lblPendiente.Size = New Size(750, 38)
        lblPendiente.TabIndex = 4
        lblPendiente.Text = "Buscá una orden o prepará una nueva solicitud."
        lblPendiente.ForeColor = Color.FromArgb(157, 43, 59)
        ' lblIdOrden
        lblIdOrden.Name = "lblIdOrden"
        lblIdOrden.UseMnemonic = False
        lblIdOrden.Location = New Point(28, 178)
        lblIdOrden.Size = New Size(316, 20)
        lblIdOrden.TabIndex = 5
        lblIdOrden.Text = "Número de orden"
        ' txtIdOrden
        txtIdOrden.Name = "txtIdOrden"
        txtIdOrden.Location = New Point(28, 200)
        txtIdOrden.Size = New Size(310, 27)
        txtIdOrden.TabIndex = 6
        txtIdOrden.Enabled = False
        txtIdOrden.MaxLength = 255
        txtIdOrden.ReadOnly = True
        ' lblPaciente
        lblPaciente.Name = "lblPaciente"
        lblPaciente.UseMnemonic = False
        lblPaciente.Location = New Point(28, 304)
        lblPaciente.Size = New Size(316, 20)
        lblPaciente.TabIndex = 7
        lblPaciente.Text = "Paciente"
        ' cboPaciente
        cboPaciente.Name = "cboPaciente"
        cboPaciente.Location = New Point(28, 326)
        cboPaciente.Size = New Size(310, 27)
        cboPaciente.TabIndex = 8
        cboPaciente.Enabled = False
        cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList
        ' lblFecha
        lblFecha.Name = "lblFecha"
        lblFecha.UseMnemonic = False
        lblFecha.Location = New Point(28, 398)
        lblFecha.Size = New Size(316, 20)
        lblFecha.TabIndex = 9
        lblFecha.Text = "Fecha (dd/mm/aaaa)"
        ' dtpFecha
        dtpFecha.Name = "dtpFecha"
        dtpFecha.Location = New Point(28, 420)
        dtpFecha.Size = New Size(310, 27)
        dtpFecha.TabIndex = 10
        dtpFecha.Enabled = False
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
        ' lblAnalisis
        lblAnalisis.Name = "lblAnalisis"
        lblAnalisis.UseMnemonic = False
        lblAnalisis.Location = New Point(28, 460)
        lblAnalisis.Size = New Size(316, 20)
        lblAnalisis.TabIndex = 11
        lblAnalisis.Text = "Análisis solicitados"
        ' checklistAnalisis
        checklistAnalisis.Name = "checklistAnalisis"
        checklistAnalisis.Location = New Point(28, 482)
        checklistAnalisis.Size = New Size(310, 116)
        checklistAnalisis.CheckOnClick = True
        checklistAnalisis.IntegralHeight = False
        checklistAnalisis.TabIndex = 12
        checklistAnalisis.Enabled = False
        ' dgvOrdenes
        dgvOrdenes.Name = "dgvOrdenes"
        dgvOrdenes.Location = New Point(370, 320)
        dgvOrdenes.Size = New Size(750, 140)
        dgvOrdenes.TabIndex = 13
        dgvOrdenes.ReadOnly = True
        dgvOrdenes.AllowUserToAddRows = False
        dgvOrdenes.AllowUserToDeleteRows = False
        dgvOrdenes.MultiSelect = False
        dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOrdenes.BackgroundColor = Color.White
        dgvOrdenes.BorderStyle = BorderStyle.FixedSingle
        dgvOrdenes.Enabled = False
        dgvOrdenes.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ' btnGuardar
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Location = New Point(370, 650)
        btnGuardar.Size = New Size(135, 36)
        btnGuardar.TabIndex = 14
        btnGuardar.Text = "✓  Guardar"
        btnGuardar.Enabled = False
        btnGuardar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnModificar
        btnModificar.Name = "btnModificar"
        btnModificar.Location = New Point(515, 620)
        btnModificar.Size = New Size(135, 36)
        btnModificar.TabIndex = 15
        btnModificar.Text = "✎  Modificar"
        btnModificar.Enabled = False
        btnModificar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ' btnCerrar
        btnCerrar.Name = "btnCerrar"
        btnCerrar.Location = New Point(975, 675)
        btnCerrar.Size = New Size(145, 36)
        btnCerrar.TabIndex = 16
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
        lblBuscarPaciente.Name = "lblBuscarPaciente"
        lblBuscarPaciente.Location = New Point(28, 240)
        lblBuscarPaciente.Size = New Size(310, 20)
        lblBuscarPaciente.Text = "Buscar paciente por DNI o nombre"
        txtBuscarPaciente.Name = "txtBuscarPaciente"
        txtBuscarPaciente.Location = New Point(28, 262)
        txtBuscarPaciente.Size = New Size(210, 27)
        txtBuscarPaciente.MaxLength = 100
        btnBuscarPaciente.Name = "btnBuscarPaciente"
        btnBuscarPaciente.Location = New Point(248, 262)
        btnBuscarPaciente.Size = New Size(90, 36)
        btnBuscarPaciente.Text = "⌕ Buscar"
        lblPacienteSeleccionado.Name = "lblPacienteSeleccionado"
        lblPacienteSeleccionado.Location = New Point(28, 360)
        lblPacienteSeleccionado.Size = New Size(310, 32)
        lblPacienteSeleccionado.Text = "Sin paciente seleccionado"
        lblPacienteSeleccionado.AutoEllipsis = True
        lblPacienteSeleccionado.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblFiltro.Name = "lblFiltro"
        lblFiltro.Location = New Point(370, 178)
        lblFiltro.Size = New Size(750, 20)
        lblFiltro.Text = "Buscar orden por número, DNI, nombre o apellido"
        txtFiltro.Name = "txtFiltro"
        txtFiltro.Location = New Point(370, 200)
        txtFiltro.Size = New Size(360, 27)
        txtFiltro.MaxLength = 100
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Location = New Point(740, 200)
        btnBuscar.Size = New Size(135, 36)
        btnBuscar.Text = "⌕ Buscar"
        btnVerTodos.Name = "btnVerTodos"
        btnVerTodos.Location = New Point(885, 200)
        btnVerTodos.Size = New Size(235, 36)
        btnVerTodos.Text = "≡ Ver todas las órdenes"
        lblFiltroFecha.Name = "lblFiltroFecha"
        lblFiltroFecha.Location = New Point(370, 240)
        lblFiltroFecha.Size = New Size(160, 20)
        lblFiltroFecha.Text = "Filtrar también por fecha"
        dtpFiltroFecha.Name = "dtpFiltroFecha"
        dtpFiltroFecha.Location = New Point(540, 238)
        dtpFiltroFecha.Size = New Size(180, 27)
        dtpFiltroFecha.Format = DateTimePickerFormat.Custom
        dtpFiltroFecha.CustomFormat = "dd/MM/yyyy"
        dtpFiltroFecha.ShowCheckBox = True
        dtpFiltroFecha.Checked = False
        lblDetalle.Name = "lblDetalle"
        lblDetalle.Location = New Point(370, 478)
        lblDetalle.Size = New Size(750, 22)
        lblDetalle.Text = "Análisis seleccionados para la nueva orden"
        dgvDetalle.Name = "dgvDetalle"
        dgvDetalle.Location = New Point(370, 506)
        dgvDetalle.Size = New Size(750, 92)
        dgvDetalle.ReadOnly = True
        dgvDetalle.AllowUserToAddRows = False
        dgvDetalle.AllowUserToDeleteRows = False
        dgvDetalle.MultiSelect = False
        dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetalle.BackgroundColor = Color.White
        dgvDetalle.BorderStyle = BorderStyle.FixedSingle
        lblSituacion.Name = "lblSituacion"
        lblSituacion.Location = New Point(28, 610)
        lblSituacion.Size = New Size(1092, 30)
        lblSituacion.Text = "Estado: el esquema actual no registra un estado de orden."
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Location = New Point(515, 650)
        btnNuevo.Size = New Size(135, 36)
        btnNuevo.Text = "＋ Nueva / Limpiar"
        btnQuitar.Name = "btnQuitar"
        btnQuitar.Location = New Point(660, 650)
        btnQuitar.Size = New Size(165, 36)
        btnQuitar.Text = "− Quitar análisis"
        lblBuscarPaciente.TabIndex = 20
        lblBuscarPaciente.UseMnemonic = False
        lblBuscarPaciente.AutoEllipsis = True
        txtBuscarPaciente.TabIndex = 21
        btnBuscarPaciente.TabIndex = 22
        btnBuscarPaciente.FlatStyle = FlatStyle.Flat
        btnBuscarPaciente.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnBuscarPaciente.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnBuscarPaciente.BackColor = Color.White
        btnBuscarPaciente.ForeColor = Color.FromArgb(57, 69, 76)
        btnBuscarPaciente.Cursor = Cursors.Hand
        lblPacienteSeleccionado.TabIndex = 23
        lblPacienteSeleccionado.UseMnemonic = False
        lblPacienteSeleccionado.AutoEllipsis = True
        lblFiltro.TabIndex = 24
        lblFiltro.UseMnemonic = False
        lblFiltro.AutoEllipsis = True
        txtFiltro.TabIndex = 25
        btnBuscar.TabIndex = 26
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnBuscar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnBuscar.BackColor = Color.White
        btnBuscar.ForeColor = Color.FromArgb(57, 69, 76)
        btnBuscar.Cursor = Cursors.Hand
        btnVerTodos.TabIndex = 27
        btnVerTodos.FlatStyle = FlatStyle.Flat
        btnVerTodos.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnVerTodos.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnVerTodos.BackColor = Color.White
        btnVerTodos.ForeColor = Color.FromArgb(57, 69, 76)
        btnVerTodos.Cursor = Cursors.Hand
        lblFiltroFecha.TabIndex = 28
        lblFiltroFecha.UseMnemonic = False
        lblFiltroFecha.AutoEllipsis = True
        dtpFiltroFecha.TabIndex = 29
        lblDetalle.TabIndex = 30
        lblDetalle.UseMnemonic = False
        lblDetalle.AutoEllipsis = True
        dgvDetalle.TabIndex = 31
        btnQuitar.TabIndex = 32
        btnQuitar.FlatStyle = FlatStyle.Flat
        btnQuitar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnQuitar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnQuitar.BackColor = Color.White
        btnQuitar.ForeColor = Color.FromArgb(57, 69, 76)
        btnQuitar.Cursor = Cursors.Hand
        btnNuevo.TabIndex = 33
        btnNuevo.FlatStyle = FlatStyle.Flat
        btnNuevo.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnNuevo.BackColor = Color.White
        btnNuevo.ForeColor = Color.FromArgb(57, 69, 76)
        btnNuevo.Cursor = Cursors.Hand
        lblSituacion.TabIndex = 34
        lblSituacion.UseMnemonic = False
        lblSituacion.AutoEllipsis = True
        ttpAcciones.SetToolTip(btnNuevo, "Preparar una nueva orden; no borra registros.")
        ttpAcciones.SetToolTip(btnQuitar, "Quitar solo de la selección temporal; no elimina el análisis.")
        ttpAcciones.SetToolTip(btnBuscarPaciente, "Buscar pacientes existentes, sin registrar nuevos.")
        ttpAcciones.SetToolTip(btnBuscar, "Aplicar texto y fecha marcada al listado.")
        ttpAcciones.SetToolTip(btnVerTodos, "Quitar filtros y consultar todas las órdenes.")
        txtBuscarPaciente.TabIndex = 0
        btnBuscarPaciente.TabIndex = 1
        cboPaciente.TabIndex = 2
        dtpFecha.TabIndex = 3
        checklistAnalisis.TabIndex = 4
        dgvDetalle.TabIndex = 5
        btnQuitar.TabIndex = 6
        btnGuardar.TabIndex = 7
        btnNuevo.TabIndex = 8
        txtFiltro.TabIndex = 9
        btnBuscar.TabIndex = 10
        dtpFiltroFecha.TabIndex = 11
        btnVerTodos.TabIndex = 12
        dgvOrdenes.TabIndex = 13
        btnCerrar.TabIndex = 14
        btnModificar.TabStop = False
        ttpAcciones.SetToolTip(checklistAnalisis, "Marcar agrega al detalle; desmarcar quita solo de esta selección.")
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
        layEditor.RowCount = 12
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
        layEditor.Dock = DockStyle.Top
        layEditor.AutoSize = True
        layEditor.Padding = New Padding(4, 4, 12, 8)
        layEditorPanel.Controls.Add(layEditor)
        lblIdOrden.Dock = DockStyle.Top
        lblIdOrden.Margin = New Padding(3, 2, 3, 6)
        lblIdOrden.TabIndex = 0
        lblIdOrden.AutoSize = True
        layEditor.Controls.Add(lblIdOrden, 0, 0)
        txtIdOrden.Dock = DockStyle.Top
        txtIdOrden.Margin = New Padding(3, 2, 3, 6)
        txtIdOrden.TabIndex = 1
        layEditor.Controls.Add(txtIdOrden, 0, 1)
        lblBuscarPaciente.Dock = DockStyle.Top
        lblBuscarPaciente.Margin = New Padding(3, 2, 3, 6)
        lblBuscarPaciente.TabIndex = 2
        lblBuscarPaciente.AutoSize = True
        layEditor.Controls.Add(lblBuscarPaciente, 0, 2)
        txtBuscarPaciente.Dock = DockStyle.Top
        txtBuscarPaciente.Margin = New Padding(3, 2, 3, 6)
        txtBuscarPaciente.TabIndex = 3
        layEditor.Controls.Add(txtBuscarPaciente, 0, 3)
        btnBuscarPaciente.Dock = DockStyle.Top
        btnBuscarPaciente.Margin = New Padding(3, 2, 3, 6)
        btnBuscarPaciente.TabIndex = 4
        btnBuscarPaciente.Dock = DockStyle.None
        btnBuscarPaciente.AutoSize = True
        btnBuscarPaciente.MinimumSize = New Size(110, 36)
        btnBuscarPaciente.Margin = New Padding(4, 4, 8, 4)
        layEditor.Controls.Add(btnBuscarPaciente, 0, 4)
        lblPaciente.Dock = DockStyle.Top
        lblPaciente.Margin = New Padding(3, 2, 3, 6)
        lblPaciente.TabIndex = 5
        lblPaciente.AutoSize = True
        layEditor.Controls.Add(lblPaciente, 0, 5)
        cboPaciente.Dock = DockStyle.Top
        cboPaciente.Margin = New Padding(3, 2, 3, 6)
        cboPaciente.TabIndex = 6
        layEditor.Controls.Add(cboPaciente, 0, 6)
        lblPacienteSeleccionado.Dock = DockStyle.Top
        lblPacienteSeleccionado.Margin = New Padding(3, 2, 3, 6)
        lblPacienteSeleccionado.TabIndex = 7
        lblPacienteSeleccionado.AutoSize = True
        layEditor.Controls.Add(lblPacienteSeleccionado, 0, 7)
        lblFecha.Dock = DockStyle.Top
        lblFecha.Margin = New Padding(3, 2, 3, 6)
        lblFecha.TabIndex = 8
        lblFecha.AutoSize = True
        layEditor.Controls.Add(lblFecha, 0, 8)
        dtpFecha.Dock = DockStyle.Top
        dtpFecha.Margin = New Padding(3, 2, 3, 6)
        dtpFecha.TabIndex = 9
        layEditor.Controls.Add(dtpFecha, 0, 9)
        lblAnalisis.Dock = DockStyle.Top
        lblAnalisis.Margin = New Padding(3, 2, 3, 6)
        lblAnalisis.TabIndex = 10
        lblAnalisis.AutoSize = True
        layEditor.Controls.Add(lblAnalisis, 0, 10)
        checklistAnalisis.Dock = DockStyle.Top
        checklistAnalisis.Margin = New Padding(3, 2, 3, 6)
        checklistAnalisis.TabIndex = 11
        checklistAnalisis.Height = 140
        checklistAnalisis.IntegralHeight = False
        checklistAnalisis.CheckOnClick = True
        checklistAnalisis.FormattingEnabled = True
        layEditor.Controls.Add(checklistAnalisis, 0, 11)
        layListado.Name = "layListado"
        layListado.ColumnCount = 1
        layListado.RowCount = 7
        layListado.Dock = DockStyle.Fill
        layListado.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.Percent, 55F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layListado.RowStyles.Add(New RowStyle(SizeType.Percent, 45F))
        layListado.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
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
        lblFiltroFecha.Dock = DockStyle.None
        lblFiltroFecha.Margin = New Padding(4)
        layFiltros.Controls.Add(lblFiltroFecha)
        dtpFiltroFecha.Dock = DockStyle.None
        dtpFiltroFecha.Margin = New Padding(4)
        layFiltros.Controls.Add(dtpFiltroFecha)
        lblPendiente.Dock = DockStyle.Fill
        lblPendiente.Margin = New Padding(4)
        lblPendiente.AutoSize = True
        layListado.Controls.Add(lblPendiente, 0, 2)
        dgvOrdenes.Dock = DockStyle.Fill
        dgvOrdenes.Margin = New Padding(4)
        layListado.Controls.Add(dgvOrdenes, 0, 3)
        lblDetalle.Dock = DockStyle.Fill
        lblDetalle.Margin = New Padding(4)
        lblDetalle.AutoSize = True
        layListado.Controls.Add(lblDetalle, 0, 4)
        dgvDetalle.Dock = DockStyle.Fill
        dgvDetalle.Margin = New Padding(4)
        layListado.Controls.Add(dgvDetalle, 0, 5)
        lblSituacion.Dock = DockStyle.Fill
        lblSituacion.Margin = New Padding(4)
        lblSituacion.AutoSize = True
        layListado.Controls.Add(lblSituacion, 0, 6)
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
        btnCotizar.Name = "btnCotizar"
        btnCotizar.Text = "Continuar a cotización"
        btnCotizar.AutoSize = True
        btnCotizar.MinimumSize = New Size(160, 36)
        btnCotizar.Margin = New Padding(4, 4, 8, 4)
        btnCotizar.FlatStyle = FlatStyle.Flat
        btnCotizar.BackColor = Color.FromArgb(157, 43, 59)
        btnCotizar.ForeColor = Color.White
        layAcciones.Controls.Add(btnCotizar)
        btnModificar.Dock = DockStyle.None
        btnModificar.AutoSize = True
        btnModificar.MinimumSize = New Size(110, 36)
        btnModificar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnModificar)
        btnNuevo.Dock = DockStyle.None
        btnNuevo.AutoSize = True
        btnNuevo.MinimumSize = New Size(110, 36)
        btnNuevo.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnNuevo)
        btnQuitar.Dock = DockStyle.None
        btnQuitar.AutoSize = True
        btnQuitar.MinimumSize = New Size(110, 36)
        btnQuitar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnQuitar)
        btnCerrar.Dock = DockStyle.None
        btnCerrar.AutoSize = True
        btnCerrar.MinimumSize = New Size(110, 36)
        btnCerrar.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnCerrar)
        dgvOrdenes.AllowUserToAddRows = False
        dgvOrdenes.AllowUserToDeleteRows = False
        dgvOrdenes.AllowUserToOrderColumns = False
        dgvOrdenes.AllowUserToResizeColumns = False
        dgvOrdenes.AllowUserToResizeRows = False
        dgvOrdenes.ReadOnly = True
        dgvOrdenes.MultiSelect = False
        dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOrdenes.ScrollBars = ScrollBars.Both
        dgvOrdenes.RowHeadersVisible = False
        dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOrdenes.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvOrdenes.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvOrdenes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvDetalle.AllowUserToAddRows = False
        dgvDetalle.AllowUserToDeleteRows = False
        dgvDetalle.AllowUserToOrderColumns = False
        dgvDetalle.AllowUserToResizeColumns = False
        dgvDetalle.AllowUserToResizeRows = False
        dgvDetalle.ReadOnly = True
        dgvDetalle.MultiSelect = False
        dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetalle.ScrollBars = ScrollBars.Both
        dgvDetalle.RowHeadersVisible = False
        dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDetalle.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvDetalle.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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
        Name = "frmOrdenes"
        Text = "L&A | Órdenes de análisis"
        StartPosition = FormStartPosition.CenterScreen
        CType(dgvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblBuscarPaciente As Label
    Friend WithEvents txtBuscarPaciente As TextBox
    Friend WithEvents btnBuscarPaciente As Button
    Friend WithEvents lblPacienteSeleccionado As Label
    Friend WithEvents lblFiltro As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnVerTodos As Button
    Friend WithEvents lblFiltroFecha As Label
    Friend WithEvents dtpFiltroFecha As DateTimePicker
    Friend WithEvents lblDetalle As Label
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents lblSituacion As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblPendiente As Label
    Friend WithEvents lblIdOrden As Label
    Friend WithEvents txtIdOrden As TextBox
    Friend WithEvents lblPaciente As Label
    Friend WithEvents cboPaciente As ComboBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents lblAnalisis As Label
    Friend WithEvents checklistAnalisis As CheckedListBox
    Friend WithEvents dgvOrdenes As DataGridView
    Friend WithEvents btnCotizar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnCerrar As Button
End Class
