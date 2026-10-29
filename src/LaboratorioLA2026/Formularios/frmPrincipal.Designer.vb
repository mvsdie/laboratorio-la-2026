<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
    Friend WithEvents layIdentidad As TableLayoutPanel
    Friend WithEvents layAcciones As FlowLayoutPanel
    Private components As System.ComponentModel.IContainer

    'procedimiento del diseñador de Windows Forms
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlEncabezado = New Panel()
        lblMarca = New Label()
        lblTitulo = New Label()
        lblEstado = New Label()
        btnPacientes = New Button()
        btnAnalisis = New Button()
        btnOrdenes = New Button()
        btnMuestras = New Button()
        btnDerivaciones = New Button()
        btnCentros = New Button()
        btnInsumos = New Button()
        btnMovimientosStock = New Button()
        btnUsuarios = New Button()
        btnFacturacion = New Button()
        btnVolver = New Button()
        lblUsuario = New Label()
        lblRol = New Label()
        lblArea = New Label()
        flpModulos = New FlowLayoutPanel()
        components = New System.ComponentModel.Container()
        ttpAcciones = New ToolTip(components)
        pnlContenido = New Panel()
        layPantalla = New TableLayoutPanel()
        layCabecera = New TableLayoutPanel()
        layIdentidad = New TableLayoutPanel()
        layAcciones = New FlowLayoutPanel()
        pnlContenido.SuspendLayout()
        SuspendLayout()
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
        lblTitulo.Size = New Size(760, 46)
        lblTitulo.TabIndex = 2
        lblTitulo.Text = "Sistema de gestión"
        lblTitulo.ForeColor = Color.White
        lblTitulo.Font = New Font("Segoe UI", 23.0F, FontStyle.Bold)
        ' lblEstado
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Location = New Point(28, 166)
        lblEstado.Size = New Size(1100, 40)
        lblEstado.TabIndex = 3
        lblEstado.Text = "Iniciá sesión para acceder al sistema."
        lblEstado.ForeColor = Color.FromArgb(75, 85, 93)
        lblEstado.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ' btnPacientes
        btnPacientes.Name = "btnPacientes"
        btnPacientes.Location = New Point(28, 196)
        btnPacientes.Size = New Size(344, 102)
        btnPacientes.TabIndex = 4
        btnPacientes.Text = "Pacientes"
        btnPacientes.BackColor = Color.White
        btnPacientes.ForeColor = Color.FromArgb(57, 69, 76)
        btnPacientes.FlatStyle = FlatStyle.Flat
        btnPacientes.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnAnalisis
        btnAnalisis.Name = "btnAnalisis"
        btnAnalisis.Location = New Point(398, 196)
        btnAnalisis.Size = New Size(344, 102)
        btnAnalisis.TabIndex = 5
        btnAnalisis.Text = "Catálogo de análisis"
        btnAnalisis.BackColor = Color.White
        btnAnalisis.ForeColor = Color.FromArgb(57, 69, 76)
        btnAnalisis.FlatStyle = FlatStyle.Flat
        btnAnalisis.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnOrdenes
        btnOrdenes.Name = "btnOrdenes"
        btnOrdenes.Location = New Point(768, 196)
        btnOrdenes.Size = New Size(344, 102)
        btnOrdenes.TabIndex = 6
        btnOrdenes.Text = "Órdenes de análisis"
        btnOrdenes.BackColor = Color.White
        btnOrdenes.ForeColor = Color.FromArgb(57, 69, 76)
        btnOrdenes.FlatStyle = FlatStyle.Flat
        btnOrdenes.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnMuestras
        btnMuestras.Name = "btnMuestras"
        btnMuestras.Location = New Point(28, 326)
        btnMuestras.Size = New Size(344, 102)
        btnMuestras.TabIndex = 7
        btnMuestras.Text = "Muestras"
        btnMuestras.BackColor = Color.White
        btnMuestras.ForeColor = Color.FromArgb(57, 69, 76)
        btnMuestras.FlatStyle = FlatStyle.Flat
        btnMuestras.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnDerivaciones
        btnDerivaciones.Name = "btnDerivaciones"
        btnDerivaciones.Location = New Point(398, 326)
        btnDerivaciones.Size = New Size(344, 102)
        btnDerivaciones.TabIndex = 8
        btnDerivaciones.Text = "Derivaciones externas"
        btnDerivaciones.BackColor = Color.White
        btnDerivaciones.ForeColor = Color.FromArgb(57, 69, 76)
        btnDerivaciones.FlatStyle = FlatStyle.Flat
        btnDerivaciones.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnCentros
        btnCentros.Name = "btnCentros"
        btnCentros.Location = New Point(768, 326)
        btnCentros.Size = New Size(344, 102)
        btnCentros.TabIndex = 9
        btnCentros.Text = "Centros externos"
        btnCentros.BackColor = Color.White
        btnCentros.ForeColor = Color.FromArgb(57, 69, 76)
        btnCentros.FlatStyle = FlatStyle.Flat
        btnCentros.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnInsumos
        btnInsumos.Name = "btnInsumos"
        btnInsumos.Location = New Point(28, 456)
        btnInsumos.Size = New Size(344, 102)
        btnInsumos.TabIndex = 10
        btnInsumos.Text = "Insumos"
        btnInsumos.BackColor = Color.White
        btnInsumos.ForeColor = Color.FromArgb(57, 69, 76)
        btnInsumos.FlatStyle = FlatStyle.Flat
        btnInsumos.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnMovimientosStock
        btnMovimientosStock.Name = "btnMovimientosStock"
        btnMovimientosStock.Location = New Point(398, 456)
        btnMovimientosStock.Size = New Size(344, 102)
        btnMovimientosStock.TabIndex = 11
        btnMovimientosStock.Text = "Movimientos de stock"
        btnMovimientosStock.BackColor = Color.White
        btnMovimientosStock.ForeColor = Color.FromArgb(57, 69, 76)
        btnMovimientosStock.FlatStyle = FlatStyle.Flat
        btnMovimientosStock.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnUsuarios
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Location = New Point(768, 456)
        btnUsuarios.Size = New Size(344, 102)
        btnUsuarios.TabIndex = 12
        btnUsuarios.Text = "Usuarios"
        btnUsuarios.BackColor = Color.White
        btnUsuarios.ForeColor = Color.FromArgb(57, 69, 76)
        btnUsuarios.FlatStyle = FlatStyle.Flat
        btnUsuarios.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        ' btnVolver
        btnVolver.Name = "btnVolver"
        btnVolver.Location = New Point(945, 655)
        btnVolver.Size = New Size(165, 40)
        btnVolver.TabIndex = 13
        btnVolver.Text = "←  Cerrar sesión"
        lblUsuario.Name = "lblUsuario"
        lblUsuario.UseMnemonic = False
        lblUsuario.Location = New Point(610, 126)
        lblUsuario.Size = New Size(510, 32)
        lblUsuario.Font = New Font("Segoe UI", 10.0F)
        lblUsuario.TextAlign = ContentAlignment.MiddleRight
        lblUsuario.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblRol.Name = "lblRol"
        lblRol.UseMnemonic = False
        lblRol.Location = New Point(835, 44)
        lblRol.Size = New Size(285, 40)
        lblRol.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblRol.BackColor = Color.White
        lblRol.TextAlign = ContentAlignment.MiddleCenter
        lblRol.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblArea.Name = "lblArea"
        lblArea.UseMnemonic = False
        lblArea.Location = New Point(28, 126)
        lblArea.Size = New Size(570, 32)
        lblArea.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        flpModulos.Controls.Add(btnPacientes)
        flpModulos.Controls.Add(btnAnalisis)
        flpModulos.Controls.Add(btnOrdenes)
        flpModulos.Controls.Add(btnMuestras)
        flpModulos.Controls.Add(btnDerivaciones)
        flpModulos.Controls.Add(btnCentros)
        flpModulos.Controls.Add(btnInsumos)
        flpModulos.Controls.Add(btnMovimientosStock)
        flpModulos.Controls.Add(btnUsuarios)
        btnPacientes.FlatStyle = FlatStyle.Flat
        btnPacientes.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnPacientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnPacientes.Cursor = Cursors.Hand
        btnPacientes.UseVisualStyleBackColor = False
        btnPacientes.BackColor = Color.White
        btnPacientes.ForeColor = Color.FromArgb(57, 69, 76)
        btnAnalisis.FlatStyle = FlatStyle.Flat
        btnAnalisis.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnAnalisis.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnAnalisis.Cursor = Cursors.Hand
        btnAnalisis.UseVisualStyleBackColor = False
        btnAnalisis.BackColor = Color.White
        btnAnalisis.ForeColor = Color.FromArgb(57, 69, 76)
        btnOrdenes.FlatStyle = FlatStyle.Flat
        btnOrdenes.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnOrdenes.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnOrdenes.Cursor = Cursors.Hand
        btnOrdenes.UseVisualStyleBackColor = False
        btnOrdenes.BackColor = Color.White
        btnOrdenes.ForeColor = Color.FromArgb(57, 69, 76)
        btnMuestras.FlatStyle = FlatStyle.Flat
        btnMuestras.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnMuestras.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnMuestras.Cursor = Cursors.Hand
        btnMuestras.UseVisualStyleBackColor = False
        btnMuestras.BackColor = Color.White
        btnMuestras.ForeColor = Color.FromArgb(57, 69, 76)
        btnDerivaciones.FlatStyle = FlatStyle.Flat
        btnDerivaciones.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnDerivaciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnDerivaciones.Cursor = Cursors.Hand
        btnDerivaciones.UseVisualStyleBackColor = False
        btnDerivaciones.BackColor = Color.White
        btnDerivaciones.ForeColor = Color.FromArgb(57, 69, 76)
        btnCentros.FlatStyle = FlatStyle.Flat
        btnCentros.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnCentros.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnCentros.Cursor = Cursors.Hand
        btnCentros.UseVisualStyleBackColor = False
        btnCentros.BackColor = Color.White
        btnCentros.ForeColor = Color.FromArgb(57, 69, 76)
        btnInsumos.FlatStyle = FlatStyle.Flat
        btnInsumos.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnInsumos.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnInsumos.Cursor = Cursors.Hand
        btnInsumos.UseVisualStyleBackColor = False
        btnInsumos.BackColor = Color.White
        btnInsumos.ForeColor = Color.FromArgb(57, 69, 76)
        btnMovimientosStock.FlatStyle = FlatStyle.Flat
        btnMovimientosStock.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnMovimientosStock.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnMovimientosStock.Cursor = Cursors.Hand
        btnMovimientosStock.UseVisualStyleBackColor = False
        btnMovimientosStock.BackColor = Color.White
        btnMovimientosStock.ForeColor = Color.FromArgb(57, 69, 76)
        btnUsuarios.FlatStyle = FlatStyle.Flat
        btnUsuarios.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnUsuarios.Cursor = Cursors.Hand
        btnUsuarios.UseVisualStyleBackColor = False
        btnUsuarios.BackColor = Color.White
        btnUsuarios.ForeColor = Color.FromArgb(57, 69, 76)
        btnVolver.FlatStyle = FlatStyle.Flat
        btnVolver.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 210)
        btnVolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 229, 232)
        btnVolver.Cursor = Cursors.Hand
        btnVolver.UseVisualStyleBackColor = False
        btnVolver.BackColor = Color.White
        btnVolver.ForeColor = Color.FromArgb(57, 69, 76)
        lblEstado.AutoEllipsis = True
        lblUsuario.AutoEllipsis = True
        lblArea.AutoEllipsis = True
        flpModulos.Name = "flpModulos"
        flpModulos.Location = New Point(28, 216)
        flpModulos.Size = New Size(1104, 414)
        flpModulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        flpModulos.AutoScroll = True
        flpModulos.TabIndex = 4
        btnPacientes.Margin = New Padding(0, 0, 20, 20)
        btnPacientes.Size = New Size(344, 102)
        btnAnalisis.Margin = New Padding(0, 0, 20, 20)
        btnAnalisis.Size = New Size(344, 102)
        btnOrdenes.Margin = New Padding(0, 0, 20, 20)
        btnOrdenes.Size = New Size(344, 102)
        btnMuestras.Margin = New Padding(0, 0, 20, 20)
        btnMuestras.Size = New Size(344, 102)
        btnDerivaciones.Margin = New Padding(0, 0, 20, 20)
        btnDerivaciones.Size = New Size(344, 102)
        btnCentros.Margin = New Padding(0, 0, 20, 20)
        btnCentros.Size = New Size(344, 102)
        btnInsumos.Margin = New Padding(0, 0, 20, 20)
        btnInsumos.Size = New Size(344, 102)
        btnMovimientosStock.Margin = New Padding(0, 0, 20, 20)
        btnMovimientosStock.Size = New Size(344, 102)
        btnUsuarios.Margin = New Padding(0, 0, 20, 20)
        btnUsuarios.Size = New Size(344, 102)
        ttpAcciones.SetToolTip(btnPacientes, "Pacientes")
        ttpAcciones.SetToolTip(btnAnalisis, "Catálogo de análisis")
        ttpAcciones.SetToolTip(btnOrdenes, "Órdenes de análisis")
        ttpAcciones.SetToolTip(btnMuestras, "Muestras")
        ttpAcciones.SetToolTip(btnDerivaciones, "Derivaciones externas")
        ttpAcciones.SetToolTip(btnCentros, "Centros externos")
        ttpAcciones.SetToolTip(btnInsumos, "Insumos")
        ttpAcciones.SetToolTip(btnMovimientosStock, "Movimientos de stock")
        ttpAcciones.SetToolTip(btnUsuarios, "Usuarios")
        ttpAcciones.SetToolTip(btnVolver, "←  Cerrar sesión")
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
        lblRol.Dock = DockStyle.Fill
        lblRol.Margin = New Padding(4)
        layCabecera.Controls.Add(lblRol, 1, 1)
        layIdentidad.Name = "layIdentidad"
        layIdentidad.ColumnCount = 2
        layIdentidad.RowCount = 2
        layIdentidad.Dock = DockStyle.Fill
        layIdentidad.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 53F))
        layIdentidad.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 47F))
        layIdentidad.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        layIdentidad.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layIdentidad.AutoSize = True
        lblArea.Dock = DockStyle.Fill
        lblArea.Margin = New Padding(4)
        layIdentidad.Controls.Add(lblArea, 0, 0)
        lblUsuario.Dock = DockStyle.Fill
        lblUsuario.Margin = New Padding(4)
        layIdentidad.Controls.Add(lblUsuario, 1, 0)
        lblEstado.Dock = DockStyle.Fill
        lblEstado.Margin = New Padding(4)
        layIdentidad.Controls.Add(lblEstado, 0, 1)
        layIdentidad.SetColumnSpan(lblEstado, 2)
        lblEstado.AutoSize = True
        layPantalla.Controls.Add(layIdentidad, 0, 1)
        flpModulos.Dock = DockStyle.Fill
        flpModulos.Margin = New Padding(4)
        flpModulos.AutoScroll = True
        flpModulos.Padding = New Padding(8)
        layPantalla.Controls.Add(flpModulos, 0, 2)
        btnPacientes.Size = New Size(320, 100)
        btnPacientes.Margin = New Padding(8)
        btnAnalisis.Size = New Size(320, 100)
        btnAnalisis.Margin = New Padding(8)
        btnOrdenes.Size = New Size(320, 100)
        btnOrdenes.Margin = New Padding(8)
        btnMuestras.Size = New Size(320, 100)
        btnMuestras.Margin = New Padding(8)
        btnDerivaciones.Size = New Size(320, 100)
        btnDerivaciones.Margin = New Padding(8)
        btnCentros.Size = New Size(320, 100)
        btnCentros.Margin = New Padding(8)
        btnInsumos.Size = New Size(320, 100)
        btnInsumos.Margin = New Padding(8)
        btnMovimientosStock.Size = New Size(320, 100)
        btnMovimientosStock.Margin = New Padding(8)
        btnUsuarios.Size = New Size(320, 100)
        btnUsuarios.Margin = New Padding(8)
        btnFacturacion.Name = "btnFacturacion"
        btnFacturacion.Text = "Cotización y facturación"
        btnFacturacion.Size = New Size(320, 100)
        btnFacturacion.Margin = New Padding(8)
        btnFacturacion.BackColor = Color.White
        btnFacturacion.ForeColor = Color.FromArgb(57, 69, 76)
        btnFacturacion.FlatStyle = FlatStyle.Flat
        btnFacturacion.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        btnFacturacion.Enabled = False
        btnFacturacion.Visible = False
        flpModulos.Controls.Add(btnFacturacion)
        layAcciones.Name = "layAcciones"
        layAcciones.Dock = DockStyle.Fill
        layAcciones.AutoSize = True
        layAcciones.WrapContents = True
        layAcciones.Margin = New Padding(0)
        btnVolver.Dock = DockStyle.None
        btnVolver.AutoSize = True
        btnVolver.MinimumSize = New Size(110, 36)
        btnVolver.Margin = New Padding(4, 4, 8, 4)
        layAcciones.Controls.Add(btnVolver)
        layPantalla.Controls.Add(layAcciones, 0, 3)
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
        Name = "frmPrincipal"
        Text = "L&A | Sistema de gestión"
        StartPosition = FormStartPosition.CenterScreen
        pnlContenido.ResumeLayout(False)
        pnlContenido.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents flpModulos As FlowLayoutPanel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnPacientes As Button
    Friend WithEvents btnAnalisis As Button
    Friend WithEvents btnOrdenes As Button
    Friend WithEvents btnMuestras As Button
    Friend WithEvents btnDerivaciones As Button
    Friend WithEvents btnCentros As Button
    Friend WithEvents btnInsumos As Button
    Friend WithEvents btnMovimientosStock As Button
    Friend WithEvents btnUsuarios As Button
    Friend WithEvents btnFacturacion As Button
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblRol As Label
    Friend WithEvents lblArea As Label
    Friend WithEvents btnVolver As Button
End Class
