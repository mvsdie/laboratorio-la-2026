<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFacturacion
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        chkSoloPendientes = New CheckBox()
        lblTipoCotizacion = New Label()
        pnlPantalla = New Panel()
        layPantalla = New TableLayoutPanel()
        pnlEncabezado = New Panel()
        lblTitulo = New Label()
        lblDemo = New Label()
        lblEstado = New Label()
        tabVentana = New TabControl()
        tabCotizacion = New TabPage()
        tabAdmin = New TabPage()
        layCotizacion = New TableLayoutPanel()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        btnBuscar = New Button()
        cboPaciente = New ComboBox()
        lblOrden = New Label()
        cboOrden = New ComboBox()
        btnCargar = New Button()
        flpBusqueda = New FlowLayoutPanel()
        lblObra = New Label()
        cboObra = New ComboBox()
        lblModo = New Label()
        cboModo = New ComboBox()
        chkImporte = New CheckBox()
        nudParticular = New NumericUpDown()
        txtMotivo = New TextBox()
        lblPorcentaje = New Label()
        nudDescuento = New NumericUpDown()
        flpOpciones = New FlowLayoutPanel()
        dgvDetalle = New DataGridView()
        lblSubtotal = New Label()
        lblBase = New Label()
        lblDescuento = New Label()
        lblTotal = New Label()
        lblTotalReferencia = New Label()
        lblCoberturaResumen = New Label()
        flpTotales = New FlowLayoutPanel()
        lblPrevisto = New Label()
        cboMetodoPrevisto = New ComboBox()
        lblPago = New Label()
        cboEstadoPago = New ComboBox()
        lblReal = New Label()
        cboMetodoReal = New ComboBox()
        btnRegistrarPago = New Button()
        flpPago = New FlowLayoutPanel()
        btnVistaPrevia = New Button()
        btnConfirmar = New Button()
        btnImprimir = New Button()
        btnLimpiar = New Button()
        btnVolver = New Button()
        flpAcciones = New FlowLayoutPanel()
        layAdmin = New TableLayoutPanel()
        lblUB = New Label()
        nudUB = New NumericUpDown()
        lblVigencia = New Label()
        dtpVigencia = New DateTimePicker()
        txtFuenteUB = New TextBox()
        btnGuardarUB = New Button()
        flpUB = New FlowLayoutPanel()
        lblAnalisis = New Label()
        cboAnalisis = New ComboBox()
        chkManual = New CheckBox()
        nudManual = New NumericUpDown()
        txtFuenteManual = New TextBox()
        btnGuardarManual = New Button()
        flpManual = New FlowLayoutPanel()
        lblObraAdmin = New Label()
        cboObraAdmin = New ComboBox()
        txtNombreObra = New TextBox()
        chkObraActiva = New CheckBox()
        btnNuevaObra = New Button()
        btnGuardarObra = New Button()
        flpObra = New FlowLayoutPanel()
        lblEstudioCob = New Label()
        cboAnalisisCobertura = New ComboBox()
        cboCobertura = New ComboBox()
        txtRefCobertura = New TextBox()
        chkTarifa = New CheckBox()
        nudTarifa = New NumericUpDown()
        txtFuenteTarifa = New TextBox()
        btnGuardarCobertura = New Button()
        flpCobertura = New FlowLayoutPanel()
        lblAyudaAdmin = New Label()
        lblRol = New Label()
        flpDescuento = New FlowLayoutPanel()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDialog1 = New PrintDialog()
        components.Add(PrintDocument1)
        components.Add(PrintDialog1)
        components.Add(PrintPreviewDialog1)
        pnlEditor = New Panel()
        layEditor = New TableLayoutPanel()
        layPie = New TableLayoutPanel()
        laySeleccion = New TableLayoutPanel()
        grpSeleccion = New GroupBox()
        lblPaciente = New Label()
        layCalculo = New TableLayoutPanel()
        grpCalculo = New GroupBox()
        lblParticular = New Label()
        lblMotivo = New Label()
        grpEstudios = New GroupBox()
        layResumen = New TableLayoutPanel()
        flpPrevisto = New FlowLayoutPanel()
        flpEstadoPago = New FlowLayoutPanel()
        flpReal = New FlowLayoutPanel()
        layUB = New TableLayoutPanel()
        grpUB = New GroupBox()
        lblFuenteUB = New Label()
        layManual = New TableLayoutPanel()
        grpManual = New GroupBox()
        lblImporteManual = New Label()
        flpValorManual = New FlowLayoutPanel()
        lblFuenteManual = New Label()
        layObra = New TableLayoutPanel()
        grpObra = New GroupBox()
        lblNombreObra = New Label()
        layCobertura = New TableLayoutPanel()
        grpCobertura = New GroupBox()
        lblEstadoCobertura = New Label()
        lblRefCobertura = New Label()
        lblTarifa = New Label()
        flpTarifa = New FlowLayoutPanel()
        lblFuenteTarifa = New Label()
        SuspendLayout()
        pnlPantalla.Name = "pnlPantalla"
        pnlPantalla.Dock = DockStyle.Fill
        layPantalla.Name = "layPantalla"
        layPantalla.Dock = DockStyle.Fill
        pnlEncabezado.Name = "pnlEncabezado"
        pnlEncabezado.Dock = DockStyle.Fill
        pnlEncabezado.BackColor = Color.FromArgb(157, 43, 59)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.UseMnemonic = False
        lblTitulo.Dock = DockStyle.Fill
        lblTitulo.ForeColor = Color.White
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft
        lblTitulo.Padding = New Padding(12)
        lblDemo.Name = "lblDemo"
        lblDemo.UseMnemonic = False
        lblDemo.Dock = DockStyle.Fill
        lblDemo.AutoSize = True
        lblDemo.ForeColor = Color.FromArgb(130, 35, 51)
        lblEstado.Name = "lblEstado"
        lblEstado.UseMnemonic = False
        lblEstado.Text = "Seleccioná paciente y orden."
        lblEstado.Dock = DockStyle.Fill
        lblEstado.AutoSize = True
        lblEstado.BackColor = Color.FromArgb(235, 240, 244)
        tabVentana.Name = "tabVentana"
        tabVentana.Dock = DockStyle.Fill
        tabCotizacion.Name = "tabCotizacion"
        tabCotizacion.Text = "Cotización y comprobante"
        tabCotizacion.BackColor = Color.FromArgb(245, 247, 248)
        tabAdmin.Name = "tabAdmin"
        tabAdmin.Text = "Tarifas y cobertura · ADMIN"
        tabAdmin.BackColor = Color.FromArgb(245, 247, 248)
        layCotizacion.Name = "layCotizacion"
        layCotizacion.Dock = DockStyle.Fill
        layCotizacion.ColumnCount = 1
        lblBuscar.Name = "lblBuscar"
        lblBuscar.AutoSize = True
        txtBuscar.Name = "txtBuscar"
        txtBuscar.MaxLength = 255
        txtBuscar.Margin = New Padding(5)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Text = "Buscar"
        btnBuscar.AutoSize = True
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.BackColor = Color.White
        btnBuscar.ForeColor = Color.FromArgb(130, 35, 51)
        btnBuscar.Margin = New Padding(5)
        cboPaciente.Name = "cboPaciente"
        cboPaciente.Width = 310
        cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList
        cboPaciente.IntegralHeight = False
        cboPaciente.DropDownHeight = 260
        lblOrden.Name = "lblOrden"
        lblOrden.Text = "Orden"
        lblOrden.AutoSize = True
        cboOrden.Name = "cboOrden"
        cboOrden.Width = 230
        cboOrden.DropDownStyle = ComboBoxStyle.DropDownList
        cboOrden.IntegralHeight = False
        cboOrden.DropDownHeight = 260
        btnCargar.Name = "btnCargar"
        btnCargar.Text = "Cargar / actualizar"
        btnCargar.AutoSize = True
        btnCargar.FlatStyle = FlatStyle.Flat
        btnCargar.BackColor = Color.White
        btnCargar.ForeColor = Color.FromArgb(130, 35, 51)
        flpBusqueda.Name = "flpBusqueda"
        lblObra.Name = "lblObra"
        lblObra.Text = "Obra social"
        lblObra.AutoSize = True
        cboObra.Name = "cboObra"
        cboObra.Width = 230
        cboObra.DropDownStyle = ComboBoxStyle.DropDownList
        cboObra.IntegralHeight = False
        cboObra.DropDownHeight = 260
        lblModo.Name = "lblModo"
        lblModo.Text = "Cálculo"
        lblModo.AutoSize = True
        cboModo.Name = "cboModo"
        cboModo.Width = 150
        cboModo.DropDownStyle = ComboBoxStyle.DropDownList
        cboModo.IntegralHeight = False
        cboModo.DropDownHeight = 260
        chkImporte.Name = "chkImporte"
        chkImporte.AutoSize = True
        chkImporte.Margin = New Padding(6, 8, 6, 6)
        nudParticular.Name = "nudParticular"
        nudParticular.Width = 140
        nudParticular.DecimalPlaces = 2
        nudParticular.Maximum = 9999999999.99D
        nudParticular.Value = 0D
        nudParticular.ThousandsSeparator = True
        nudParticular.Margin = New Padding(5)
        txtMotivo.Name = "txtMotivo"
        txtMotivo.PlaceholderText = "Motivo / referencia del acuerdo particular"
        txtMotivo.Width = 240
        txtMotivo.MaxLength = 255
        lblPorcentaje.Name = "lblPorcentaje"
        lblPorcentaje.AutoSize = True
        lblPorcentaje.Margin = New Padding(6, 10, 6, 6)
        nudDescuento.Name = "nudDescuento"
        nudDescuento.DecimalPlaces = 2
        nudDescuento.Maximum = 100D
        nudDescuento.Value = 0D
        nudDescuento.ThousandsSeparator = True
        nudDescuento.Margin = New Padding(5)
        flpOpciones.Name = "flpOpciones"
        flpOpciones.Dock = DockStyle.Fill
        flpOpciones.AutoSize = True
        flpOpciones.WrapContents = True
        flpOpciones.Margin = New Padding(3)
        flpOpciones.Padding = New Padding(3)
        dgvDetalle.Name = "dgvDetalle"
        dgvDetalle.Dock = DockStyle.Fill
        dgvDetalle.ReadOnly = True
        dgvDetalle.AllowUserToAddRows = False
        dgvDetalle.AllowUserToDeleteRows = False
        dgvDetalle.AllowUserToOrderColumns = False
        dgvDetalle.AllowUserToResizeRows = False
        dgvDetalle.RowHeadersVisible = False
        dgvDetalle.MultiSelect = False
        dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvDetalle.BackgroundColor = Color.White
        dgvDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Text = "Subtotal cubierto: $0,00"
        lblSubtotal.AutoSize = True
        lblSubtotal.Margin = New Padding(6, 10, 6, 6)
        lblBase.Name = "lblBase"
        lblBase.Text = "Base: pendiente"
        lblBase.AutoSize = True
        lblBase.Margin = New Padding(6, 10, 6, 6)
        lblDescuento.Name = "lblDescuento"
        lblDescuento.Text = "Descuento: pendiente"
        lblDescuento.AutoSize = True
        lblDescuento.Margin = New Padding(6, 10, 6, 6)
        lblTotal.Name = "lblTotal"
        lblTotal.Text = "TOTAL PENDIENTE"
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTotal.ForeColor = Color.FromArgb(130, 35, 51)
        lblTotal.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblTotalReferencia.Name = "lblTotalReferencia"
        lblTotalReferencia.Text = "Total de referencia: pendiente"
        lblTotalReferencia.AutoSize = True
        lblTotalReferencia.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblTotalReferencia.ForeColor = Color.FromArgb(130, 35, 51)
        lblTotalReferencia.Margin = New Padding(6, 8, 6, 6)
        lblCoberturaResumen.Name = "lblCoberturaResumen"
        lblCoberturaResumen.Text = "Cobertura: sin selección"
        lblCoberturaResumen.AutoSize = True
        lblCoberturaResumen.Margin = New Padding(6, 8, 6, 6)
        flpTotales.Name = "flpTotales"
        lblPrevisto.Name = "lblPrevisto"
        lblPrevisto.Text = "Método previsto"
        lblPrevisto.AutoSize = True
        lblPrevisto.Margin = New Padding(6, 10, 6, 6)
        cboMetodoPrevisto.Name = "cboMetodoPrevisto"
        cboMetodoPrevisto.DropDownStyle = ComboBoxStyle.DropDownList
        cboMetodoPrevisto.IntegralHeight = False
        cboMetodoPrevisto.DropDownHeight = 260
        cboMetodoPrevisto.Margin = New Padding(5)
        lblPago.Name = "lblPago"
        lblPago.Text = "Pago"
        lblPago.AutoSize = True
        lblPago.Margin = New Padding(6, 10, 6, 6)
        cboEstadoPago.Name = "cboEstadoPago"
        cboEstadoPago.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstadoPago.IntegralHeight = False
        cboEstadoPago.DropDownHeight = 260
        cboEstadoPago.Margin = New Padding(5)
        lblReal.Name = "lblReal"
        lblReal.AutoSize = True
        lblReal.Margin = New Padding(6, 10, 6, 6)
        cboMetodoReal.Name = "cboMetodoReal"
        cboMetodoReal.DropDownStyle = ComboBoxStyle.DropDownList
        cboMetodoReal.IntegralHeight = False
        cboMetodoReal.DropDownHeight = 260
        cboMetodoReal.Margin = New Padding(5)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Text = "Registrar pago realizado"
        btnRegistrarPago.AutoSize = True
        btnRegistrarPago.MinimumSize = New Size(110, 36)
        btnRegistrarPago.FlatStyle = FlatStyle.Flat
        btnRegistrarPago.BackColor = Color.White
        btnRegistrarPago.ForeColor = Color.FromArgb(130, 35, 51)
        btnRegistrarPago.Margin = New Padding(5)
        flpPago.Name = "flpPago"
        btnVistaPrevia.Name = "btnVistaPrevia"
        btnVistaPrevia.Text = "Vista previa"
        btnVistaPrevia.AutoSize = True
        btnVistaPrevia.FlatStyle = FlatStyle.Flat
        btnVistaPrevia.BackColor = Color.White
        btnVistaPrevia.ForeColor = Color.FromArgb(130, 35, 51)
        btnConfirmar.Name = "btnConfirmar"
        btnConfirmar.Text = "Confirmar cotización"
        btnConfirmar.AutoSize = True
        btnConfirmar.FlatStyle = FlatStyle.Flat
        btnConfirmar.BackColor = Color.White
        btnConfirmar.ForeColor = Color.FromArgb(130, 35, 51)
        btnImprimir.Name = "btnImprimir"
        btnImprimir.Text = "Imprimir / reimprimir"
        btnImprimir.AutoSize = True
        btnImprimir.FlatStyle = FlatStyle.Flat
        btnImprimir.BackColor = Color.White
        btnImprimir.ForeColor = Color.FromArgb(130, 35, 51)
        btnLimpiar.Name = "btnLimpiar"
        btnLimpiar.Text = "Limpiar"
        btnLimpiar.AutoSize = True
        btnLimpiar.FlatStyle = FlatStyle.Flat
        btnLimpiar.BackColor = Color.White
        btnLimpiar.ForeColor = Color.FromArgb(130, 35, 51)
        btnVolver.Name = "btnVolver"
        btnVolver.Text = "Volver"
        btnVolver.AutoSize = True
        btnVolver.FlatStyle = FlatStyle.Flat
        btnVolver.BackColor = Color.White
        btnVolver.ForeColor = Color.FromArgb(130, 35, 51)
        flpAcciones.Name = "flpAcciones"
        layAdmin.Name = "layAdmin"
        layAdmin.Dock = DockStyle.Top
        layAdmin.AutoSize = True
        layAdmin.ColumnCount = 1
        lblUB.Name = "lblUB"
        lblUB.Text = "UB demo ARS"
        lblUB.AutoSize = True
        nudUB.Name = "nudUB"
        nudUB.Width = 140
        nudUB.DecimalPlaces = 2
        nudUB.Maximum = 9999999999.99D
        nudUB.Value = 2400D
        nudUB.ThousandsSeparator = True
        nudUB.Margin = New Padding(5)
        lblVigencia.Name = "lblVigencia"
        lblVigencia.Text = "Vigencia referencia"
        lblVigencia.AutoSize = True
        dtpVigencia.Name = "dtpVigencia"
        dtpVigencia.Format = DateTimePickerFormat.Short
        dtpVigencia.Width = 120
        txtFuenteUB.Name = "txtFuenteUB"
        txtFuenteUB.PlaceholderText = "Fuente del valor UB de demostración"
        txtFuenteUB.Width = 430
        txtFuenteUB.MaxLength = 255
        btnGuardarUB.Name = "btnGuardarUB"
        btnGuardarUB.Text = "Guardar valor UB"
        btnGuardarUB.AutoSize = True
        btnGuardarUB.MinimumSize = New Size(110, 36)
        btnGuardarUB.FlatStyle = FlatStyle.Flat
        btnGuardarUB.BackColor = Color.White
        btnGuardarUB.ForeColor = Color.FromArgb(130, 35, 51)
        btnGuardarUB.Margin = New Padding(5)
        flpUB.Name = "flpUB"
        lblAnalisis.Name = "lblAnalisis"
        lblAnalisis.AutoSize = True
        cboAnalisis.Name = "cboAnalisis"
        cboAnalisis.Width = 320
        cboAnalisis.DropDownStyle = ComboBoxStyle.DropDownList
        cboAnalisis.IntegralHeight = False
        cboAnalisis.DropDownHeight = 260
        chkManual.Name = "chkManual"
        chkManual.AutoSize = True
        chkManual.Margin = New Padding(6, 8, 6, 6)
        nudManual.Name = "nudManual"
        nudManual.Width = 140
        nudManual.DecimalPlaces = 2
        nudManual.Maximum = 9999999999.99D
        nudManual.Value = 0D
        nudManual.ThousandsSeparator = True
        nudManual.Margin = New Padding(5)
        txtFuenteManual.Name = "txtFuenteManual"
        txtFuenteManual.PlaceholderText = "Fuente / referencia del precio manual"
        txtFuenteManual.Width = 300
        txtFuenteManual.MaxLength = 255
        btnGuardarManual.Name = "btnGuardarManual"
        btnGuardarManual.Text = "Guardar precio"
        btnGuardarManual.AutoSize = True
        btnGuardarManual.MinimumSize = New Size(110, 36)
        btnGuardarManual.FlatStyle = FlatStyle.Flat
        btnGuardarManual.BackColor = Color.White
        btnGuardarManual.ForeColor = Color.FromArgb(130, 35, 51)
        btnGuardarManual.Margin = New Padding(5)
        flpManual.Name = "flpManual"
        lblObraAdmin.Name = "lblObraAdmin"
        lblObraAdmin.Text = "Obra social"
        lblObraAdmin.AutoSize = True
        cboObraAdmin.Name = "cboObraAdmin"
        cboObraAdmin.Width = 250
        cboObraAdmin.DropDownStyle = ComboBoxStyle.DropDownList
        cboObraAdmin.IntegralHeight = False
        cboObraAdmin.DropDownHeight = 260
        txtNombreObra.Name = "txtNombreObra"
        txtNombreObra.PlaceholderText = "Nombre de la obra social"
        txtNombreObra.Width = 230
        txtNombreObra.MaxLength = 255
        chkObraActiva.Name = "chkObraActiva"
        chkObraActiva.Text = "Activa"
        chkObraActiva.AutoSize = True
        chkObraActiva.Margin = New Padding(6, 8, 6, 6)
        btnNuevaObra.Name = "btnNuevaObra"
        btnNuevaObra.Text = "Nueva obra social"
        btnNuevaObra.AutoSize = True
        btnNuevaObra.MinimumSize = New Size(110, 36)
        btnNuevaObra.FlatStyle = FlatStyle.Flat
        btnNuevaObra.BackColor = Color.White
        btnNuevaObra.ForeColor = Color.FromArgb(130, 35, 51)
        btnNuevaObra.Margin = New Padding(5)
        btnGuardarObra.Name = "btnGuardarObra"
        btnGuardarObra.Text = "Guardar obra social"
        btnGuardarObra.AutoSize = True
        btnGuardarObra.MinimumSize = New Size(110, 36)
        btnGuardarObra.FlatStyle = FlatStyle.Flat
        btnGuardarObra.BackColor = Color.White
        btnGuardarObra.ForeColor = Color.FromArgb(130, 35, 51)
        btnGuardarObra.Margin = New Padding(5)
        flpObra.Name = "flpObra"
        lblEstudioCob.Name = "lblEstudioCob"
        lblEstudioCob.AutoSize = True
        cboAnalisisCobertura.Name = "cboAnalisisCobertura"
        cboAnalisisCobertura.Width = 320
        cboAnalisisCobertura.DropDownStyle = ComboBoxStyle.DropDownList
        cboAnalisisCobertura.IntegralHeight = False
        cboAnalisisCobertura.DropDownHeight = 260
        cboCobertura.Name = "cboCobertura"
        cboCobertura.Width = 230
        cboCobertura.DropDownStyle = ComboBoxStyle.DropDownList
        cboCobertura.IntegralHeight = False
        cboCobertura.DropDownHeight = 260
        txtRefCobertura.Name = "txtRefCobertura"
        txtRefCobertura.PlaceholderText = "Referencia que confirma esta cobertura"
        txtRefCobertura.Width = 300
        txtRefCobertura.MaxLength = 255
        chkTarifa.Name = "chkTarifa"
        chkTarifa.Text = "Tarifa acordada definida"
        chkTarifa.AutoSize = True
        chkTarifa.Margin = New Padding(6, 8, 6, 6)
        nudTarifa.Name = "nudTarifa"
        nudTarifa.Width = 140
        nudTarifa.DecimalPlaces = 2
        nudTarifa.Maximum = 9999999999.99D
        nudTarifa.Value = 0D
        nudTarifa.ThousandsSeparator = True
        nudTarifa.Margin = New Padding(5)
        txtFuenteTarifa.Name = "txtFuenteTarifa"
        txtFuenteTarifa.PlaceholderText = "Fuente de la tarifa acordada"
        txtFuenteTarifa.Width = 300
        txtFuenteTarifa.MaxLength = 255
        btnGuardarCobertura.Name = "btnGuardarCobertura"
        btnGuardarCobertura.Text = "Guardar cobertura"
        btnGuardarCobertura.AutoSize = True
        btnGuardarCobertura.MinimumSize = New Size(110, 36)
        btnGuardarCobertura.FlatStyle = FlatStyle.Flat
        btnGuardarCobertura.BackColor = Color.White
        btnGuardarCobertura.ForeColor = Color.FromArgb(130, 35, 51)
        btnGuardarCobertura.Margin = New Padding(5)
        flpCobertura.Name = "flpCobertura"
        lblAyudaAdmin.Name = "lblAyudaAdmin"
        lblAyudaAdmin.Text = "Solo ADMIN actualiza tarifas y coberturas. Completá fuente/referencia. Cambiar una tarifa no recalcula comprobantes ya confirmados."
        lblAyudaAdmin.AutoSize = True
        lblAyudaAdmin.Margin = New Padding(6, 10, 6, 6)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintDocument1.DefaultPageSettings.PaperSize = New Printing.PaperSize("A4", 827, 1169)
        PrintDocument1.DefaultPageSettings.Margins = New Printing.Margins(60, 60, 60, 60)
        PrintDocument1.DefaultPageSettings.Landscape = False
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Width = 1100
        PrintPreviewDialog1.Height = 800
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.UseEXDialog = False
        pnlEditor.Name = "pnlEditor"
        layEditor.Name = "layEditor"
        layPie.Name = "layPie"
        laySeleccion.Name = "laySeleccion"
        grpSeleccion.Name = "grpSeleccion"
        lblPaciente.Name = "lblPaciente"
        layCalculo.Name = "layCalculo"
        grpCalculo.Name = "grpCalculo"
        lblParticular.Name = "lblParticular"
        lblMotivo.Name = "lblMotivo"
        grpEstudios.Name = "grpEstudios"
        layResumen.Name = "layResumen"
        flpPrevisto.Name = "flpPrevisto"
        flpEstadoPago.Name = "flpEstadoPago"
        flpReal.Name = "flpReal"
        layUB.Name = "layUB"
        grpUB.Name = "grpUB"
        lblFuenteUB.Name = "lblFuenteUB"
        layManual.Name = "layManual"
        grpManual.Name = "grpManual"
        lblImporteManual.Name = "lblImporteManual"
        flpValorManual.Name = "flpValorManual"
        lblFuenteManual.Name = "lblFuenteManual"
        layObra.Name = "layObra"
        grpObra.Name = "grpObra"
        lblNombreObra.Name = "lblNombreObra"
        layCobertura.Name = "layCobertura"
        grpCobertura.Name = "grpCobertura"
        lblEstadoCobertura.Name = "lblEstadoCobertura"
        lblRefCobertura.Name = "lblRefCobertura"
        lblTarifa.Name = "lblTarifa"
        flpTarifa.Name = "flpTarifa"
        lblFuenteTarifa.Name = "lblFuenteTarifa"
        pnlPantalla.AutoScroll = False
        pnlPantalla.AutoScrollMinSize = Size.Empty
        layPantalla.Padding = New Padding(10)
        layPantalla.ColumnCount = 1
        layPantalla.RowCount = 5
        lblTitulo.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitulo.Text = "L&A | Cotización y facturación"
        lblTitulo.AutoEllipsis = True
        lblRol.Width = 168
        lblEstado.MaximumSize = New Size(0, 0)
        lblEstado.Padding = New Padding(4)
        lblEstado.Margin = New Padding(0, 2, 0, 0)
        lblDemo.Padding = New Padding(4, 4, 4, 4)
        lblDemo.Text = "VALOR DE DEMOSTRACIÓN, NO ARANCEL OFICIAL DE MISIONES · UB: Santa Fe, marzo 2026"
        tabCotizacion.AutoScroll = False
        tabAdmin.AutoScroll = True
        layCotizacion.MinimumSize = Size.Empty
        layCotizacion.Margin = New Padding(0)
        layCotizacion.RowCount = 2
        pnlEditor.Dock = DockStyle.Fill
        pnlEditor.AutoScroll = True
        pnlEditor.Margin = New Padding(0)
        layEditor.ColumnCount = 1
        layEditor.Dock = DockStyle.Top
        layEditor.AutoSize = True
        layEditor.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layEditor.Margin = New Padding(0)
        layEditor.RowCount = 3
        layPie.ColumnCount = 1
        layPie.Dock = DockStyle.Top
        layPie.AutoSize = True
        layPie.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layPie.Margin = New Padding(0)
        layPie.RowCount = 2
        laySeleccion.ColumnCount = 3
        laySeleccion.Dock = DockStyle.Fill
        laySeleccion.AutoSize = False
        laySeleccion.AutoSizeMode = AutoSizeMode.GrowAndShrink
        laySeleccion.Margin = New Padding(0)
        laySeleccion.RowCount = 3
        grpSeleccion.Text = "Paciente y orden"
        grpSeleccion.Dock = DockStyle.Fill
        grpSeleccion.AutoSize = False
        grpSeleccion.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpSeleccion.Padding = New Padding(10, 8, 10, 8)
        grpSeleccion.Margin = New Padding(4, 6, 4, 6)
        grpSeleccion.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        laySeleccion.Font = New Font("Segoe UI", 9.0F)
        lblBuscar.Text = "Buscar paciente"
        flpBusqueda.Dock = DockStyle.Fill
        flpBusqueda.AutoSize = True
        flpBusqueda.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpBusqueda.WrapContents = False
        flpBusqueda.Margin = New Padding(0)
        flpBusqueda.Padding = New Padding(0)
        lblPaciente.Text = "Paciente"
        lblPaciente.AutoSize = True
        lblPaciente.Dock = DockStyle.Fill
        lblPaciente.TextAlign = ContentAlignment.MiddleLeft
        lblPaciente.UseMnemonic = False
        lblPaciente.Margin = New Padding(4, 8, 4, 5)
        layCalculo.ColumnCount = 3
        layCalculo.Dock = DockStyle.Fill
        layCalculo.AutoSize = False
        layCalculo.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layCalculo.Margin = New Padding(0)
        layCalculo.RowCount = 4
        grpCalculo.Text = "Cobertura y acuerdo particular"
        grpCalculo.Dock = DockStyle.Fill
        grpCalculo.AutoSize = False
        grpCalculo.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpCalculo.Padding = New Padding(10, 8, 10, 8)
        grpCalculo.Margin = New Padding(4, 6, 4, 6)
        grpCalculo.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        layCalculo.Font = New Font("Segoe UI", 9.0F)
        lblParticular.Text = "Importe acordado"
        lblParticular.AutoSize = True
        lblParticular.Dock = DockStyle.Fill
        lblParticular.TextAlign = ContentAlignment.MiddleLeft
        lblParticular.UseMnemonic = False
        lblParticular.Margin = New Padding(4, 8, 4, 5)
        flpDescuento.Dock = DockStyle.Fill
        flpDescuento.AutoSize = True
        flpDescuento.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpDescuento.WrapContents = False
        flpDescuento.Margin = New Padding(0)
        flpDescuento.Padding = New Padding(0)
        lblMotivo.Text = "Referencia"
        lblMotivo.AutoSize = True
        lblMotivo.Dock = DockStyle.Fill
        lblMotivo.TextAlign = ContentAlignment.MiddleLeft
        lblMotivo.UseMnemonic = False
        lblMotivo.Margin = New Padding(4, 8, 4, 5)
        chkImporte.Text = "Acuerdo particular"
        nudDescuento.Width = 90
        lblPorcentaje.Text = "Dto. %"
        nudParticular.Dock = DockStyle.Left
        grpEstudios.Text = "Estudios solicitados · referencias y cobertura"
        grpEstudios.Dock = DockStyle.Fill
        grpEstudios.Padding = New Padding(8, 20, 8, 8)
        grpEstudios.Margin = New Padding(4, 6, 4, 6)
        dgvDetalle.MinimumSize = Size.Empty
        layResumen.ColumnCount = 2
        layResumen.Dock = DockStyle.Top
        layResumen.AutoSize = True
        layResumen.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layResumen.Margin = New Padding(0)
        layResumen.RowCount = 1
        flpTotales.Dock = DockStyle.Fill
        flpTotales.AutoSize = True
        flpTotales.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpTotales.WrapContents = True
        flpTotales.Margin = New Padding(0)
        flpTotales.Padding = New Padding(0)
        lblTotal.Dock = DockStyle.None
        lblTotal.TextAlign = ContentAlignment.MiddleLeft
        lblTotal.Margin = New Padding(5, 6, 5, 6)
        flpPrevisto.Dock = DockStyle.None
        flpPrevisto.AutoSize = True
        flpPrevisto.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpPrevisto.WrapContents = False
        flpPrevisto.Margin = New Padding(0)
        flpPrevisto.Padding = New Padding(0)
        flpEstadoPago.Dock = DockStyle.None
        flpEstadoPago.AutoSize = True
        flpEstadoPago.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpEstadoPago.WrapContents = False
        flpEstadoPago.Margin = New Padding(0)
        flpEstadoPago.Padding = New Padding(0)
        flpReal.Dock = DockStyle.None
        flpReal.AutoSize = True
        flpReal.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpReal.WrapContents = False
        flpReal.Margin = New Padding(0)
        flpReal.Padding = New Padding(0)
        lblReal.Text = "Método recibido"
        cboMetodoPrevisto.Width = 165
        cboEstadoPago.Width = 112
        cboMetodoReal.Width = 165
        flpPago.Dock = DockStyle.Fill
        flpPago.AutoSize = True
        flpPago.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpPago.WrapContents = True
        flpPago.Margin = New Padding(0)
        flpPago.Padding = New Padding(0)
        flpAcciones.Dock = DockStyle.Fill
        flpAcciones.AutoSize = True
        flpAcciones.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpAcciones.WrapContents = True
        flpAcciones.Margin = New Padding(0)
        flpAcciones.Padding = New Padding(0)
        btnVistaPrevia.MinimumSize = New Size(100, 34)
        btnVistaPrevia.Margin = New Padding(4)
        btnConfirmar.MinimumSize = New Size(100, 34)
        btnConfirmar.Margin = New Padding(4)
        btnImprimir.MinimumSize = New Size(100, 34)
        btnImprimir.Margin = New Padding(4)
        btnLimpiar.MinimumSize = New Size(100, 34)
        btnLimpiar.Margin = New Padding(4)
        btnVolver.MinimumSize = New Size(100, 34)
        btnVolver.Margin = New Padding(4)
        layAdmin.MinimumSize = Size.Empty
        layAdmin.Padding = New Padding(8)
        layAdmin.RowCount = 5
        layUB.ColumnCount = 3
        layUB.Dock = DockStyle.Top
        layUB.AutoSize = True
        layUB.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layUB.Margin = New Padding(0)
        layUB.RowCount = 3
        grpUB.Text = "1 · Valor UB de demostración"
        grpUB.Dock = DockStyle.Top
        grpUB.AutoSize = True
        grpUB.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpUB.Padding = New Padding(10, 8, 10, 8)
        grpUB.Margin = New Padding(4, 6, 4, 6)
        grpUB.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        layUB.Font = New Font("Segoe UI", 9.0F)
        lblFuenteUB.Text = "Fuente / referencia"
        lblFuenteUB.AutoSize = True
        lblFuenteUB.Dock = DockStyle.Fill
        lblFuenteUB.TextAlign = ContentAlignment.MiddleLeft
        lblFuenteUB.UseMnemonic = False
        lblFuenteUB.Margin = New Padding(4, 8, 4, 5)
        flpUB.Dock = DockStyle.Fill
        flpUB.AutoSize = True
        flpUB.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpUB.WrapContents = True
        flpUB.Margin = New Padding(0)
        flpUB.Padding = New Padding(0)
        layManual.ColumnCount = 3
        layManual.Dock = DockStyle.Top
        layManual.AutoSize = True
        layManual.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layManual.Margin = New Padding(0)
        layManual.RowCount = 3
        grpManual.Text = "2 · Precio por análisis"
        grpManual.Dock = DockStyle.Top
        grpManual.AutoSize = True
        grpManual.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpManual.Padding = New Padding(10, 8, 10, 8)
        grpManual.Margin = New Padding(4, 6, 4, 6)
        grpManual.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        layManual.Font = New Font("Segoe UI", 9.0F)
        lblAnalisis.Text = "Análisis NBU"
        lblImporteManual.Text = "Precio opcional"
        lblImporteManual.AutoSize = True
        lblImporteManual.Dock = DockStyle.Fill
        lblImporteManual.TextAlign = ContentAlignment.MiddleLeft
        lblImporteManual.UseMnemonic = False
        lblImporteManual.Margin = New Padding(4, 8, 4, 5)
        flpValorManual.Dock = DockStyle.Fill
        flpValorManual.AutoSize = True
        flpValorManual.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpValorManual.WrapContents = True
        flpValorManual.Margin = New Padding(0)
        flpValorManual.Padding = New Padding(0)
        chkManual.Text = "Usar precio manual en lugar de UB"
        lblFuenteManual.Text = "Fuente / referencia"
        lblFuenteManual.AutoSize = True
        lblFuenteManual.Dock = DockStyle.Fill
        lblFuenteManual.TextAlign = ContentAlignment.MiddleLeft
        lblFuenteManual.UseMnemonic = False
        lblFuenteManual.Margin = New Padding(4, 8, 4, 5)
        flpManual.Dock = DockStyle.Fill
        flpManual.AutoSize = True
        flpManual.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpManual.WrapContents = True
        flpManual.Margin = New Padding(0)
        flpManual.Padding = New Padding(0)
        layObra.ColumnCount = 3
        layObra.Dock = DockStyle.Top
        layObra.AutoSize = True
        layObra.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layObra.Margin = New Padding(0)
        layObra.RowCount = 3
        grpObra.Text = "3 · Obras sociales"
        grpObra.Dock = DockStyle.Top
        grpObra.AutoSize = True
        grpObra.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpObra.Padding = New Padding(10, 8, 10, 8)
        grpObra.Margin = New Padding(4, 6, 4, 6)
        grpObra.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        layObra.Font = New Font("Segoe UI", 9.0F)
        lblNombreObra.Text = "Nombre"
        lblNombreObra.AutoSize = True
        lblNombreObra.Dock = DockStyle.Fill
        lblNombreObra.TextAlign = ContentAlignment.MiddleLeft
        lblNombreObra.UseMnemonic = False
        lblNombreObra.Margin = New Padding(4, 8, 4, 5)
        flpObra.Dock = DockStyle.Fill
        flpObra.AutoSize = True
        flpObra.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpObra.WrapContents = True
        flpObra.Margin = New Padding(0)
        flpObra.Padding = New Padding(0)
        flpObra.FlowDirection = FlowDirection.RightToLeft
        layCobertura.ColumnCount = 3
        layCobertura.Dock = DockStyle.Top
        layCobertura.AutoSize = True
        layCobertura.AutoSizeMode = AutoSizeMode.GrowAndShrink
        layCobertura.Margin = New Padding(0)
        layCobertura.RowCount = 5
        grpCobertura.Text = "4 · Cobertura de la obra social seleccionada arriba"
        grpCobertura.Dock = DockStyle.Top
        grpCobertura.AutoSize = True
        grpCobertura.AutoSizeMode = AutoSizeMode.GrowAndShrink
        grpCobertura.Padding = New Padding(10, 8, 10, 8)
        grpCobertura.Margin = New Padding(4, 6, 4, 6)
        grpCobertura.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        layCobertura.Font = New Font("Segoe UI", 9.0F)
        lblEstudioCob.Text = "Análisis NBU"
        lblEstadoCobertura.Text = "Estado de cobertura"
        lblEstadoCobertura.AutoSize = True
        lblEstadoCobertura.Dock = DockStyle.Fill
        lblEstadoCobertura.TextAlign = ContentAlignment.MiddleLeft
        lblEstadoCobertura.UseMnemonic = False
        lblEstadoCobertura.Margin = New Padding(4, 8, 4, 5)
        lblRefCobertura.Text = "Referencia cobertura"
        lblRefCobertura.AutoSize = True
        lblRefCobertura.Dock = DockStyle.Fill
        lblRefCobertura.TextAlign = ContentAlignment.MiddleLeft
        lblRefCobertura.UseMnemonic = False
        lblRefCobertura.Margin = New Padding(4, 8, 4, 5)
        lblTarifa.Text = "Tarifa específica"
        lblTarifa.AutoSize = True
        lblTarifa.Dock = DockStyle.Fill
        lblTarifa.TextAlign = ContentAlignment.MiddleLeft
        lblTarifa.UseMnemonic = False
        lblTarifa.Margin = New Padding(4, 8, 4, 5)
        flpTarifa.Dock = DockStyle.Fill
        flpTarifa.AutoSize = True
        flpTarifa.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpTarifa.WrapContents = True
        flpTarifa.Margin = New Padding(0)
        flpTarifa.Padding = New Padding(0)
        lblFuenteTarifa.Text = "Fuente de la tarifa"
        lblFuenteTarifa.AutoSize = True
        lblFuenteTarifa.Dock = DockStyle.Fill
        lblFuenteTarifa.TextAlign = ContentAlignment.MiddleLeft
        lblFuenteTarifa.UseMnemonic = False
        lblFuenteTarifa.Margin = New Padding(4, 8, 4, 5)
        flpCobertura.Dock = DockStyle.Fill
        flpCobertura.AutoSize = True
        flpCobertura.AutoSizeMode = AutoSizeMode.GrowAndShrink
        flpCobertura.WrapContents = True
        flpCobertura.Margin = New Padding(0)
        flpCobertura.Padding = New Padding(0)
        lblAyudaAdmin.MaximumSize = New Size(0, 0)
        lblAyudaAdmin.Dock = DockStyle.Fill
        cboPaciente.Dock = DockStyle.Fill
        cboPaciente.Margin = New Padding(4)
        cboOrden.Dock = DockStyle.Fill
        cboOrden.Margin = New Padding(4)
        cboObra.Dock = DockStyle.Fill
        cboObra.Margin = New Padding(4)
        cboModo.Dock = DockStyle.Fill
        cboModo.Margin = New Padding(4)
        txtMotivo.Dock = DockStyle.Fill
        txtMotivo.Margin = New Padding(4)
        cboAnalisis.Dock = DockStyle.Fill
        cboAnalisis.Margin = New Padding(4)
        txtFuenteUB.Dock = DockStyle.Fill
        txtFuenteUB.Margin = New Padding(4)
        txtFuenteManual.Dock = DockStyle.Fill
        txtFuenteManual.Margin = New Padding(4)
        cboObraAdmin.Dock = DockStyle.Fill
        cboObraAdmin.Margin = New Padding(4)
        txtNombreObra.Dock = DockStyle.Fill
        txtNombreObra.Margin = New Padding(4)
        cboAnalisisCobertura.Dock = DockStyle.Fill
        cboAnalisisCobertura.Margin = New Padding(4)
        cboCobertura.Dock = DockStyle.Fill
        cboCobertura.Margin = New Padding(4)
        txtRefCobertura.Dock = DockStyle.Fill
        txtRefCobertura.Margin = New Padding(4)
        txtFuenteTarifa.Dock = DockStyle.Fill
        txtFuenteTarifa.Margin = New Padding(4)
        lblBuscar.Dock = DockStyle.Fill
        lblBuscar.TextAlign = ContentAlignment.MiddleLeft
        lblBuscar.Margin = New Padding(4, 8, 4, 5)
        lblOrden.Dock = DockStyle.Fill
        lblOrden.TextAlign = ContentAlignment.MiddleLeft
        lblOrden.Margin = New Padding(4, 8, 4, 5)
        lblObra.Dock = DockStyle.Fill
        lblObra.TextAlign = ContentAlignment.MiddleLeft
        lblObra.Margin = New Padding(4, 8, 4, 5)
        lblModo.Dock = DockStyle.Fill
        lblModo.TextAlign = ContentAlignment.MiddleLeft
        lblModo.Margin = New Padding(4, 8, 4, 5)
        lblUB.Dock = DockStyle.Fill
        lblUB.TextAlign = ContentAlignment.MiddleLeft
        lblUB.Margin = New Padding(4, 8, 4, 5)
        lblVigencia.Dock = DockStyle.Fill
        lblVigencia.TextAlign = ContentAlignment.MiddleLeft
        lblVigencia.Margin = New Padding(4, 8, 4, 5)
        lblAnalisis.Dock = DockStyle.Fill
        lblAnalisis.TextAlign = ContentAlignment.MiddleLeft
        lblAnalisis.Margin = New Padding(4, 8, 4, 5)
        lblObraAdmin.Dock = DockStyle.Fill
        lblObraAdmin.TextAlign = ContentAlignment.MiddleLeft
        lblObraAdmin.Margin = New Padding(4, 8, 4, 5)
        lblEstudioCob.Dock = DockStyle.Fill
        lblEstudioCob.TextAlign = ContentAlignment.MiddleLeft
        lblEstudioCob.Margin = New Padding(4, 8, 4, 5)
        btnCargar.Dock = DockStyle.Fill
        btnCargar.Margin = New Padding(4)
        txtBuscar.Width = 210
        lblRol.Name = "lblRol"
        lblRol.Dock = DockStyle.Right
        lblRol.ForeColor = Color.White
        lblRol.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblRol.TextAlign = ContentAlignment.MiddleRight
        lblRol.Padding = New Padding(8)
        lblRol.UseMnemonic = False
        cboPaciente.MinimumSize = New Size(180, 0)
        nudUB.Dock = DockStyle.Left
        nudUB.MinimumSize = New Size(150, 26)
        nudUB.Size = New Size(150, 26)
        dtpVigencia.Dock = DockStyle.Left
        dtpVigencia.MinimumSize = New Size(150, 26)
        dtpVigencia.Size = New Size(150, 26)
        nudParticular.MinimumSize = New Size(150, 26)
        nudParticular.Size = New Size(150, 26)
        flpPrevisto.Size = New Size(1, 1)
        flpEstadoPago.Size = New Size(1, 1)
        flpReal.Size = New Size(1, 1)
        flpTotales.Size = New Size(1, 1)
        flpPago.Size = New Size(1, 1)
        flpAcciones.Size = New Size(1, 1)
        layPie.Size = New Size(1, 1)
        btnBuscar.MinimumSize = New Size(100, 30)
        btnCargar.MinimumSize = New Size(100, 30)
        layPantalla.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Absolute, 62F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPantalla.Controls.Add(pnlEncabezado, 0, 0)
        layPantalla.Controls.Add(lblDemo, 0, 1)
        layPantalla.Controls.Add(tabVentana, 0, 2)
        layPantalla.Controls.Add(flpAcciones, 0, 3)
        layPantalla.Controls.Add(lblEstado, 0, 4)
        pnlEncabezado.Controls.Add(lblTitulo)
        pnlEncabezado.Controls.Add(lblRol)
        layCotizacion.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layCotizacion.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        layCotizacion.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 245F))
        layPie.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layPie.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layPie.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCotizacion.Controls.Add(pnlEditor, 0, 0)
        layCotizacion.Controls.Add(layPie, 0, 1)
        pnlEditor.Controls.Add(layEditor)
        laySeleccion.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        laySeleccion.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        laySeleccion.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpSeleccion.Controls.Add(laySeleccion)
        flpBusqueda.Controls.Add(txtBuscar)
        flpBusqueda.Controls.Add(btnBuscar)
        laySeleccion.Controls.Add(lblBuscar, 0, 0)
        laySeleccion.Controls.Add(flpBusqueda, 1, 0)
        laySeleccion.SetColumnSpan(flpBusqueda, 2)
        laySeleccion.Controls.Add(lblPaciente, 0, 1)
        laySeleccion.Controls.Add(cboPaciente, 1, 1)
        laySeleccion.SetColumnSpan(cboPaciente, 2)
        laySeleccion.Controls.Add(lblOrden, 0, 2)
        laySeleccion.Controls.Add(cboOrden, 1, 2)
        laySeleccion.Controls.Add(btnCargar, 2, 2)
        layCalculo.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        layCalculo.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layCalculo.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpCalculo.Controls.Add(layCalculo)
        layCalculo.Controls.Add(lblObra, 0, 0)
        layCalculo.Controls.Add(cboObra, 1, 0)
        layCalculo.SetColumnSpan(cboObra, 2)
        layCalculo.Controls.Add(lblModo, 0, 1)
        layCalculo.Controls.Add(cboModo, 1, 1)
        layCalculo.Controls.Add(chkImporte, 2, 1)
        layCalculo.Controls.Add(lblParticular, 0, 2)
        layCalculo.Controls.Add(nudParticular, 1, 2)
        flpDescuento.Controls.Add(lblPorcentaje)
        flpDescuento.Controls.Add(nudDescuento)
        layCalculo.Controls.Add(flpDescuento, 2, 2)
        layCalculo.Controls.Add(lblMotivo, 0, 3)
        layCalculo.Controls.Add(txtMotivo, 1, 3)
        layCalculo.SetColumnSpan(txtMotivo, 2)
        grpEstudios.Controls.Add(dgvDetalle)
        layEditor.Controls.Add(grpSeleccion, 0, 0)
        layEditor.Controls.Add(grpCalculo, 0, 1)
        layEditor.Controls.Add(grpEstudios, 0, 2)
        layResumen.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62F))
        layResumen.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38F))
        layResumen.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        flpTotales.Controls.Add(lblSubtotal)
        flpTotales.Controls.Add(lblBase)
        flpTotales.Controls.Add(lblDescuento)
        flpTotales.Controls.Add(lblTotalReferencia)
        flpTotales.Controls.Add(lblCoberturaResumen)
        flpTotales.Controls.Add(lblTotal)
        flpPrevisto.Controls.Add(lblPrevisto)
        flpPrevisto.Controls.Add(cboMetodoPrevisto)
        flpEstadoPago.Controls.Add(lblPago)
        flpEstadoPago.Controls.Add(cboEstadoPago)
        flpReal.Controls.Add(lblReal)
        flpReal.Controls.Add(cboMetodoReal)
        flpPago.Controls.Add(flpPrevisto)
        flpPago.Controls.Add(flpEstadoPago)
        flpPago.Controls.Add(flpReal)
        flpPago.Controls.Add(btnRegistrarPago)
        layPie.Controls.Add(flpTotales, 0, 0)
        layPie.Controls.Add(flpPago, 0, 1)
        flpAcciones.Controls.Add(btnVistaPrevia)
        flpAcciones.Controls.Add(btnConfirmar)
        flpAcciones.Controls.Add(btnImprimir)
        flpAcciones.Controls.Add(btnLimpiar)
        flpAcciones.Controls.Add(btnVolver)
        layAdmin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layAdmin.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layAdmin.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layAdmin.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layAdmin.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layAdmin.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layUB.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        layUB.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layUB.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        layUB.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layUB.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layUB.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpUB.Controls.Add(layUB)
        layUB.Controls.Add(lblUB, 0, 0)
        layUB.Controls.Add(nudUB, 1, 0)
        layUB.Controls.Add(lblVigencia, 0, 1)
        layUB.Controls.Add(dtpVigencia, 1, 1)
        layUB.Controls.Add(lblFuenteUB, 0, 2)
        layUB.Controls.Add(txtFuenteUB, 1, 2)
        flpUB.Controls.Add(btnGuardarUB)
        layUB.Controls.Add(flpUB, 2, 2)
        layManual.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        layManual.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layManual.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        layManual.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layManual.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layManual.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpManual.Controls.Add(layManual)
        layManual.Controls.Add(lblAnalisis, 0, 0)
        layManual.Controls.Add(cboAnalisis, 1, 0)
        layManual.SetColumnSpan(cboAnalisis, 2)
        flpValorManual.Controls.Add(chkManual)
        flpValorManual.Controls.Add(nudManual)
        layManual.Controls.Add(lblImporteManual, 0, 1)
        layManual.Controls.Add(flpValorManual, 1, 1)
        layManual.SetColumnSpan(flpValorManual, 2)
        layManual.Controls.Add(lblFuenteManual, 0, 2)
        layManual.Controls.Add(txtFuenteManual, 1, 2)
        flpManual.Controls.Add(btnGuardarManual)
        layManual.Controls.Add(flpManual, 2, 2)
        layObra.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        layObra.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layObra.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        layObra.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layObra.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layObra.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpObra.Controls.Add(layObra)
        layObra.Controls.Add(lblObraAdmin, 0, 0)
        layObra.Controls.Add(cboObraAdmin, 1, 0)
        layObra.SetColumnSpan(cboObraAdmin, 2)
        layObra.Controls.Add(lblNombreObra, 0, 1)
        layObra.Controls.Add(txtNombreObra, 1, 1)
        layObra.Controls.Add(chkObraActiva, 2, 1)
        flpObra.Controls.Add(btnGuardarObra)
        flpObra.Controls.Add(btnNuevaObra)
        layObra.Controls.Add(flpObra, 0, 2)
        layObra.SetColumnSpan(flpObra, 3)
        layCobertura.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 125F))
        layCobertura.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        layCobertura.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 190F))
        layCobertura.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCobertura.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCobertura.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCobertura.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        layCobertura.RowStyles.Add(New RowStyle(SizeType.AutoSize, 0F))
        grpCobertura.Controls.Add(layCobertura)
        layCobertura.Controls.Add(lblEstudioCob, 0, 0)
        layCobertura.Controls.Add(cboAnalisisCobertura, 1, 0)
        layCobertura.SetColumnSpan(cboAnalisisCobertura, 2)
        layCobertura.Controls.Add(lblEstadoCobertura, 0, 1)
        layCobertura.Controls.Add(cboCobertura, 1, 1)
        layCobertura.SetColumnSpan(cboCobertura, 2)
        layCobertura.Controls.Add(lblRefCobertura, 0, 2)
        layCobertura.Controls.Add(txtRefCobertura, 1, 2)
        layCobertura.SetColumnSpan(txtRefCobertura, 2)
        flpTarifa.Controls.Add(chkTarifa)
        flpTarifa.Controls.Add(nudTarifa)
        layCobertura.Controls.Add(lblTarifa, 0, 3)
        layCobertura.Controls.Add(flpTarifa, 1, 3)
        layCobertura.SetColumnSpan(flpTarifa, 2)
        layCobertura.Controls.Add(lblFuenteTarifa, 0, 4)
        layCobertura.Controls.Add(txtFuenteTarifa, 1, 4)
        flpCobertura.Controls.Add(btnGuardarCobertura)
        layCobertura.Controls.Add(flpCobertura, 2, 4)
        layAdmin.Controls.Add(grpUB, 0, 0)
        layAdmin.Controls.Add(grpManual, 0, 1)
        layAdmin.Controls.Add(grpObra, 0, 2)
        layAdmin.Controls.Add(grpCobertura, 0, 3)
        layAdmin.Controls.Add(lblAyudaAdmin, 0, 4)
        laySeleccion.RowStyles.Clear()
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.333333333333336F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.333333333333336F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.333333333333336F))
        layCalculo.RowStyles.Clear()
        layCalculo.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        layCalculo.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        layEditor.RowStyles.Clear()
        layEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 160F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 165F))
        layEditor.RowStyles.Add(New RowStyle(SizeType.Absolute, 245F))
        tabCotizacion.Controls.Add(layCotizacion)
        tabAdmin.Controls.Add(layAdmin)
        tabVentana.Controls.Add(tabCotizacion)
        tabVentana.Controls.Add(tabAdmin)
        pnlPantalla.Controls.Add(layPantalla)
        Controls.Add(pnlPantalla)
        chkSoloPendientes.Name = "chkSoloPendientes"
        chkSoloPendientes.Text = "Sin cotización"
        chkSoloPendientes.Checked = True
        chkSoloPendientes.AutoSize = True
        chkSoloPendientes.Dock = DockStyle.Fill
        chkSoloPendientes.Margin = New Padding(4)
        lblTipoCotizacion.Name = "lblTipoCotizacion"
        lblTipoCotizacion.Text = "Seleccioná una orden pendiente de cotización."
        lblTipoCotizacion.Dock = DockStyle.Fill
        lblTipoCotizacion.AutoEllipsis = True
        lblTipoCotizacion.TextAlign = ContentAlignment.MiddleLeft
        lblTipoCotizacion.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblTipoCotizacion.Margin = New Padding(4)
        laySeleccion.RowCount = 4
        laySeleccion.RowStyles.Clear()
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        laySeleccion.Controls.Add(chkSoloPendientes, 0, 3)
        laySeleccion.Controls.Add(lblTipoCotizacion, 1, 3)
        laySeleccion.SetColumnSpan(lblTipoCotizacion, 2)
        layEditor.RowStyles(0).Height = 195F
        laySeleccion.Controls.Remove(lblTipoCotizacion)
        laySeleccion.SetColumnSpan(cboPaciente, 1)
        laySeleccion.SetRow(chkSoloPendientes, 1)
        laySeleccion.SetColumn(chkSoloPendientes, 2)
        laySeleccion.RowCount = 3
        laySeleccion.RowStyles.Clear()
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333F))
        laySeleccion.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33334F))
        layEditor.RowStyles(0).Height = 160F
        cboPaciente.DropDownWidth = 600
        layPantalla.RowCount = 6
        layPantalla.SetRow(lblEstado, 5)
        layPantalla.SetRow(flpAcciones, 4)
        layPantalla.SetRow(tabVentana, 3)
        lblTipoCotizacion.AutoSize = True
        lblTipoCotizacion.AutoEllipsis = False
        lblTipoCotizacion.Padding = New Padding(4, 2, 4, 2)
        layPantalla.Controls.Add(lblTipoCotizacion, 0, 2)
        layPantalla.RowStyles.Clear()
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Absolute, 62F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        layPantalla.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(1260, 860)
        MinimumSize = New Size(720, 480)
        BackColor = Color.FromArgb(245, 247, 248)
        Name = "frmFacturacion"
        Text = "L&A | Cotización y facturación interna"
        StartPosition = FormStartPosition.CenterParent
        ResumeLayout(False)
    End Sub
    Friend WithEvents chkSoloPendientes As CheckBox
    Friend WithEvents lblTipoCotizacion As Label
    Friend WithEvents lblRol As Label
    Friend WithEvents flpDescuento As FlowLayoutPanel
    Friend WithEvents pnlPantalla As Panel
    Friend WithEvents layPantalla As TableLayoutPanel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblDemo As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents tabVentana As TabControl
    Friend WithEvents tabCotizacion As TabPage
    Friend WithEvents tabAdmin As TabPage
    Friend WithEvents layCotizacion As TableLayoutPanel
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cboPaciente As ComboBox
    Friend WithEvents lblOrden As Label
    Friend WithEvents cboOrden As ComboBox
    Friend WithEvents btnCargar As Button
    Friend WithEvents flpBusqueda As FlowLayoutPanel
    Friend WithEvents lblObra As Label
    Friend WithEvents cboObra As ComboBox
    Friend WithEvents lblModo As Label
    Friend WithEvents cboModo As ComboBox
    Friend WithEvents chkImporte As CheckBox
    Friend WithEvents nudParticular As NumericUpDown
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents lblPorcentaje As Label
    Friend WithEvents nudDescuento As NumericUpDown
    Friend WithEvents flpOpciones As FlowLayoutPanel
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblBase As Label
    Friend WithEvents lblDescuento As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalReferencia As Label
    Friend WithEvents lblCoberturaResumen As Label
    Friend WithEvents flpTotales As FlowLayoutPanel
    Friend WithEvents lblPrevisto As Label
    Friend WithEvents cboMetodoPrevisto As ComboBox
    Friend WithEvents lblPago As Label
    Friend WithEvents cboEstadoPago As ComboBox
    Friend WithEvents lblReal As Label
    Friend WithEvents cboMetodoReal As ComboBox
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents flpPago As FlowLayoutPanel
    Friend WithEvents btnVistaPrevia As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnVolver As Button
    Friend WithEvents flpAcciones As FlowLayoutPanel
    Friend WithEvents layAdmin As TableLayoutPanel
    Friend WithEvents lblUB As Label
    Friend WithEvents nudUB As NumericUpDown
    Friend WithEvents lblVigencia As Label
    Friend WithEvents dtpVigencia As DateTimePicker
    Friend WithEvents txtFuenteUB As TextBox
    Friend WithEvents btnGuardarUB As Button
    Friend WithEvents flpUB As FlowLayoutPanel
    Friend WithEvents lblAnalisis As Label
    Friend WithEvents cboAnalisis As ComboBox
    Friend WithEvents chkManual As CheckBox
    Friend WithEvents nudManual As NumericUpDown
    Friend WithEvents txtFuenteManual As TextBox
    Friend WithEvents btnGuardarManual As Button
    Friend WithEvents flpManual As FlowLayoutPanel
    Friend WithEvents lblObraAdmin As Label
    Friend WithEvents cboObraAdmin As ComboBox
    Friend WithEvents txtNombreObra As TextBox
    Friend WithEvents chkObraActiva As CheckBox
    Friend WithEvents btnNuevaObra As Button
    Friend WithEvents btnGuardarObra As Button
    Friend WithEvents flpObra As FlowLayoutPanel
    Friend WithEvents lblEstudioCob As Label
    Friend WithEvents cboAnalisisCobertura As ComboBox
    Friend WithEvents cboCobertura As ComboBox
    Friend WithEvents txtRefCobertura As TextBox
    Friend WithEvents chkTarifa As CheckBox
    Friend WithEvents nudTarifa As NumericUpDown
    Friend WithEvents txtFuenteTarifa As TextBox
    Friend WithEvents btnGuardarCobertura As Button
    Friend WithEvents flpCobertura As FlowLayoutPanel
    Friend WithEvents lblAyudaAdmin As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents pnlEditor As Panel
    Friend WithEvents layEditor As TableLayoutPanel
    Friend WithEvents layPie As TableLayoutPanel
    Friend WithEvents laySeleccion As TableLayoutPanel
    Friend WithEvents grpSeleccion As GroupBox
    Friend WithEvents lblPaciente As Label
    Friend WithEvents layCalculo As TableLayoutPanel
    Friend WithEvents grpCalculo As GroupBox
    Friend WithEvents lblParticular As Label
    Friend WithEvents lblMotivo As Label
    Friend WithEvents grpEstudios As GroupBox
    Friend WithEvents layResumen As TableLayoutPanel
    Friend WithEvents flpPrevisto As FlowLayoutPanel
    Friend WithEvents flpEstadoPago As FlowLayoutPanel
    Friend WithEvents flpReal As FlowLayoutPanel
    Friend WithEvents layUB As TableLayoutPanel
    Friend WithEvents grpUB As GroupBox
    Friend WithEvents lblFuenteUB As Label
    Friend WithEvents layManual As TableLayoutPanel
    Friend WithEvents grpManual As GroupBox
    Friend WithEvents lblImporteManual As Label
    Friend WithEvents flpValorManual As FlowLayoutPanel
    Friend WithEvents lblFuenteManual As Label
    Friend WithEvents layObra As TableLayoutPanel
    Friend WithEvents grpObra As GroupBox
    Friend WithEvents lblNombreObra As Label
    Friend WithEvents layCobertura As TableLayoutPanel
    Friend WithEvents grpCobertura As GroupBox
    Friend WithEvents lblEstadoCobertura As Label
    Friend WithEvents lblRefCobertura As Label
    Friend WithEvents lblTarifa As Label
    Friend WithEvents flpTarifa As FlowLayoutPanel
    Friend WithEvents lblFuenteTarifa As Label
End Class
