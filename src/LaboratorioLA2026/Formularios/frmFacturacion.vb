Imports MySqlConnector
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Text

Public Class frmFacturacion
    Private detalle As DataTable
    Private cabecera As DataRow
    Private idCotizacion As Integer = 0
    Private cargando As Boolean = False
    Private guardandoCotizacion As Boolean = False
    Private edicionValida As Boolean = True
    Private ordenEntrada As Integer = 0
    Private pacienteEntrada As Integer = 0
    Private fechaBorrador As Date
    Private borradorNuevo As Boolean = False
    Private analisisBorrador As New List(Of Integer)
    Public OrdenGuardadaId As Integer = 0
    Private acomodandoDistribucion As Boolean = False
    Private resumenImpresion As DataTable
    Private filaResumenImpresion As Integer = 0
    Private cabeceraImpresion As DataRow
    Private detalleImpresion As DataTable
    Private paginaImpresion As Integer = 0
    Private filaImpresion As Integer = 0
    Private falloImpresion As Boolean = False
    Private subtotalReferencia As Decimal = 0D
    Private referenciaCompleta As Boolean = False
    Private baseReferencia As Decimal?
    Private descuentoReferencia As Decimal?
    Private totalReferencia As Decimal?
    Private coberturaVerificada As Boolean = False
    Private Const MotivoReferencia As String = "BASE DE REFERENCIA NBU · "
    Private Const FuenteSantaFe As String = "DEMOSTRACIÓN | Santa Fe 1ra., marzo 2026 | https://cobisfe1.org.ar/simplecms/public/publicaciones/valor-del-arancel-profesional-minimo-obligatorio-marzo-2026"
    Private Const Leyenda As String = "Comprobante informativo de estudios solicitados y cobertura registrada. No constituye factura fiscal ni comprobante de pago."

    Private Function AplicarPermisos() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") Then
            Me.Close()
            Return False
        End If
        If Not Sesion.EsAdmin() Then tabVentana.TabPages.Remove(tabAdmin)
        Dim editar As Boolean = idCotizacion = 0 AndAlso cabecera IsNot Nothing AndAlso Not guardandoCotizacion
        cboObra.Enabled = editar
        cboModo.Enabled = editar
        chkImporte.Enabled = editar AndAlso cboModo.Text = "PARTICULAR"
        nudParticular.Enabled = chkImporte.Enabled AndAlso chkImporte.Checked
        txtMotivo.Enabled = nudParticular.Enabled
        nudDescuento.Enabled = editar
        cboMetodoPrevisto.Enabled = editar
        cboEstadoPago.Enabled = editar
        btnConfirmar.Enabled = editar AndAlso edicionValida
        btnConfirmar.Text = If(borradorNuevo, "Confirmar orden y cotización", "Confirmar cotización")
        cboPaciente.Enabled = Not borradorNuevo AndAlso Not guardandoCotizacion
        cboOrden.Enabled = Not borradorNuevo AndAlso Not guardandoCotizacion
        txtBuscar.Enabled = Not borradorNuevo AndAlso Not guardandoCotizacion
        btnBuscar.Enabled = Not borradorNuevo AndAlso Not guardandoCotizacion
        chkSoloPendientes.Enabled = Not borradorNuevo AndAlso Not guardandoCotizacion
        btnCargar.Enabled = (cabecera IsNot Nothing OrElse borradorNuevo) AndAlso Not guardandoCotizacion
        If idCotizacion > 0 Then
            lblTipoCotizacion.Text = "HISTÓRICO CONFIRMADO · Precios, descuento y acuerdo bloqueados. Solo lectura y reimpresión."
            lblTipoCotizacion.ForeColor = Color.FromArgb(110, 65, 65)
            btnCargar.Text = "Recargar histórico"
        ElseIf cabecera IsNot Nothing Then
            lblTipoCotizacion.Text = If(borradorNuevo, "BORRADOR EDITABLE · Orden y cotización se guardan juntas al confirmar.", "COTIZACIÓN NUEVA · Editá base, descuento y método previsto. No registra un pago.")
            If IsDBNull(cabecera("total_final")) Then lblTipoCotizacion.Text &= " TOTAL PENDIENTE: completá cobertura/precios o definí un importe PARTICULAR."
            lblTipoCotizacion.ForeColor = Color.FromArgb(35, 106, 76)
            btnCargar.Text = "Actualizar precios"
        Else
            lblTipoCotizacion.Text = "Seleccioná una orden pendiente. Quitá Sin cotización para consultar históricos."
        End If
        btnImprimir.Enabled = idCotizacion > 0
        btnVistaPrevia.Enabled = cabecera IsNot Nothing AndAlso (idCotizacion > 0 OrElse edicionValida)
        Dim puedePagar As Boolean = idCotizacion > 0 AndAlso cabecera IsNot Nothing
        If puedePagar Then puedePagar = cabecera("modo_calculo").ToString() = "PARTICULAR" AndAlso Not IsDBNull(cabecera("total_final")) AndAlso CDec(If(IsDBNull(cabecera("total_final")), 0D, cabecera("total_final"))) > 0D AndAlso cabecera("estado_pago").ToString() <> "PAGADO"
        btnRegistrarPago.Enabled = puedePagar
        cboMetodoReal.Enabled = puedePagar
        pnlEncabezado.BackColor = PresentacionSesion.ColorRol()
        lblRol.Text = Sesion.rolUsuario & Environment.NewLine & Sesion.nombreUsuario
        Return True
    End Function

    Private Sub frmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosIniciales()
    End Sub

    Private Sub AcomodarDistribucion(sender As Object, e As EventArgs) Handles layCotizacion.SizeChanged, pnlEditor.SizeChanged, lblSubtotal.TextChanged, lblBase.TextChanged, lblDescuento.TextChanged, lblTotal.TextChanged, lblTotalReferencia.TextChanged, lblCoberturaResumen.TextChanged
        'calculo el alto con el ancho disponible para no reservar filas de mas
        If acomodandoDistribucion OrElse layPie Is Nothing OrElse layPie.RowStyles.Count <> 2 Then Exit Sub
        acomodandoDistribucion = True
        Try
            Dim ancho As Integer = Math.Max(1, layCotizacion.ClientSize.Width)
            For Each etiqueta As Label In {lblSubtotal, lblBase, lblDescuento, lblTotalReferencia, lblCoberturaResumen, lblTotal}
                If etiqueta IsNot Nothing Then etiqueta.MaximumSize = New Size(Math.Max(1, ancho - 20), 0)
            Next
            flpTotales.MaximumSize = New Size(ancho, 0)
            flpPago.MaximumSize = New Size(ancho, 0)
            Dim altoTotales As Integer = flpTotales.GetPreferredSize(New Size(ancho, 0)).Height
            Dim altoPago As Integer = flpPago.GetPreferredSize(New Size(ancho, 0)).Height
            layPie.AutoSize = False
            layPie.RowStyles(0).SizeType = SizeType.Absolute
            layPie.RowStyles(0).Height = altoTotales
            layPie.RowStyles(1).SizeType = SizeType.Absolute
            layPie.RowStyles(1).Height = altoPago
            layPie.Height = altoTotales + altoPago
            layCotizacion.RowStyles(1).SizeType = SizeType.Absolute
            layCotizacion.RowStyles(1).Height = altoTotales + altoPago
            Dim anchoEditor As Integer = pnlEditor.ClientSize.Width
            If anchoEditor > 0 AndAlso layEditor.MinimumSize.Width <> anchoEditor Then layEditor.MinimumSize = New Size(anchoEditor, 0)
        Finally
            acomodandoDistribucion = False
        End Try
    End Sub

    Public Function CargarDatosIniciales() As Boolean
        If Not AplicarPermisos() Then Return False
        cargando = True
        cboModo.Items.Clear()
        cboModo.Items.AddRange(New Object() {"COBERTURA", "PARTICULAR"})
        cboModo.SelectedIndex = 0
        For Each combo In New ComboBox() {cboMetodoPrevisto, cboMetodoReal}
            combo.Items.Clear()
            combo.Items.AddRange(New Object() {"SIN DEFINIR", "EFECTIVO", "TRANSFERENCIA", "TARJETA DE DÉBITO", "TARJETA DE CRÉDITO", "OTRO"})
            combo.SelectedIndex = 0
        Next
        cboEstadoPago.Items.Clear()
        cboEstadoPago.Items.AddRange(New Object() {"NO PAGADO", "PENDIENTE"})
        cboEstadoPago.SelectedIndex = 0
        cboCobertura.Items.Clear()
        cboCobertura.Items.AddRange(New Object() {"COBERTURA SIN VERIFICAR", "CUBIERTO", "SIN COBERTURA"})
        cboCobertura.SelectedIndex = 0
        txtFuenteUB.Text = FuenteSantaFe
        dtpVigencia.Value = New Date(2026, 3, 1)
        cargando = False
        If Not CargarCatalogos() Then Return False
        If borradorNuevo Then Return CargarBorrador()
        If ordenEntrada > 0 Then Return CargarOrdenRecibida()
        Return BuscarPacientes()
    End Function

    Public Sub RecibirOrden(id As Integer)
        ordenEntrada = id
        borradorNuevo = False
    End Sub

    Public Sub RecibirBorrador(idPaciente As Integer, fecha As Date, estudios As List(Of Integer))
        pacienteEntrada = idPaciente
        fechaBorrador = fecha.Date
        analisisBorrador = New List(Of Integer)(estudios)
        analisisBorrador.Sort()
        borradorNuevo = True
    End Sub

    Private Function CargarOrdenRecibida() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") OrElse Not ObtenerDatosConexion() Then Return False
        Try
            cargando = True
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT o.id_paciente,o.id_orden,CONCAT(p.dni,' · ',p.apellido,', ',p.nombre) AS paciente,CONCAT('Orden ',o.id_orden,' · ',DATE_FORMAT(o.fecha,'%d/%m/%Y')) AS orden FROM ordenes o JOIN pacientes p ON p.id_paciente=o.id_paciente WHERE o.id_orden=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", ordenEntrada)
                    Dim tabla = LeerTabla(cmd)
                    If tabla.Rows.Count <> 1 Then Throw New InvalidOperationException("No se encontró la orden recibida.")
                    chkSoloPendientes.Checked = False
                    MostrarCombo(cboPaciente, tabla.Copy(), "id_paciente", "paciente")
                    MostrarCombo(cboOrden, tabla.Copy(), "id_orden", "orden")
                End Using
            End Using
            cargando = False
            Return CargarOrden()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo abrir la orden recibida. No se generó ningún registro adicional."
            Return False
        Finally
            cargando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Function

    Private Function CargarBorrador() As Boolean
        If Not Sesion.Puede("CREAR_ORDENES") OrElse Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If pacienteEntrada <= 0 OrElse analisisBorrador.Count = 0 Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Dim detalleValido As Boolean = False
        Try
            cargando = True
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_paciente,CONCAT(dni,' · ',apellido,', ',nombre) AS paciente FROM pacientes WHERE id_paciente=@id;", cn)
                    cmd.Parameters.AddWithValue("@id", pacienteEntrada)
                    Dim tabla = LeerTabla(cmd)
                    If tabla.Rows.Count <> 1 Then Throw New InvalidOperationException()
                    MostrarCombo(cboPaciente, tabla, "id_paciente", "paciente")
                End Using
                Dim orden As New DataTable
                orden.Columns.Add("id_orden", GetType(Integer))
                orden.Columns.Add("orden", GetType(String))
                orden.Rows.Add(0, "NUEVA ORDEN · sin guardar")
                MostrarCombo(cboOrden, orden, "id_orden", "orden")
                cabecera = LeerOrden(cn, Nothing)
                detalle = LeerDetalle(cn, Nothing)
                detalleValido = True
                ActualizarCabecera()
            End Using
            MostrarDetalle()
            MostrarTotales()
            lblEstado.Text = "Paciente y estudios recibidos de Órdenes. Cancelar no guarda la orden; Confirmar guarda todo en una transacción."
            Return True
        Catch ex As InvalidOperationException
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            edicionValida = False
            If detalleValido Then
                MostrarDetalle()
                lblTotal.Text = "TOTAL PENDIENTE · corregí el dato ingresado"
            Else
                cabecera = Nothing
                detalle = Nothing
                dgvDetalle.DataSource = Nothing
            End If
            lblEstado.Text = "Revisá los datos, los importes y la conexión antes de reintentar."
            Return False
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            cabecera = Nothing
            detalle = Nothing
            dgvDetalle.DataSource = Nothing
            lblEstado.Text = "No se pudo preparar el borrador. No se guardó la orden."
            Return False
        Finally
            cargando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Function

    Private Function LeerTabla(cmd As MySqlCommand) As DataTable
        Dim tabla As New DataTable
        Using lector = cmd.ExecuteReader()
            tabla.Load(lector)
        End Using
        Return tabla
    End Function

    Private Function IdCombo(combo As ComboBox) As Integer
        If combo.SelectedValue Is Nothing OrElse IsDBNull(combo.SelectedValue) OrElse TypeOf combo.SelectedValue Is DataRowView Then Return 0
        Dim id As Integer
        If Not Integer.TryParse(combo.SelectedValue.ToString(), id) OrElse id < 0 Then Return 0
        Return id
    End Function

    Private Sub MostrarCombo(combo As ComboBox, tabla As DataTable, id As String, nombre As String)
        combo.DataSource = Nothing
        combo.DisplayMember = nombre
        combo.ValueMember = id
        combo.DataSource = tabla
    End Sub

    Public Function BuscarPacientes() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If borradorNuevo Then Return False
        If Not ObtenerDatosConexion() Then
            lblEstado.Text = MensajeConexion
            Return False
        End If
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT id_paciente,CONCAT(dni,' · ',apellido,', ',nombre) AS paciente FROM pacientes WHERE dni LIKE @f OR nombre LIKE @f OR apellido LIKE @f ORDER BY apellido,nombre;", cn)
                    cmd.Parameters.AddWithValue("@f", "%" & txtBuscar.Text.Trim() & "%")
                    cargando = True
                    MostrarCombo(cboPaciente, LeerTabla(cmd), "id_paciente", "paciente")
                End Using
            End Using
            cargando = False
            Return CargarOrdenes()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo buscar pacientes. Revisá la conexión."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Private Function CargarOrdenes() As Boolean
        cargando = True
        cboOrden.DataSource = Nothing
        cargando = False
        LimpiarCotizacion()
        If IdCombo(cboPaciente) = 0 OrElse Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT o.id_orden,CONCAT('Orden ',o.id_orden,' · ',DATE_FORMAT(o.fecha,'%d/%m/%Y')) AS orden FROM ordenes o WHERE o.id_paciente=@p AND (@pendientes=FALSE OR NOT EXISTS (SELECT 1 FROM cotizaciones c WHERE c.id_orden=o.id_orden)) ORDER BY o.id_orden DESC;", cn)
                    cmd.Parameters.AddWithValue("@p", IdCombo(cboPaciente))
                    cmd.Parameters.AddWithValue("@pendientes", chkSoloPendientes.Checked)
                    cargando = True
                    MostrarCombo(cboOrden, LeerTabla(cmd), "id_orden", "orden")
                End Using
            End Using
            cargando = False
            If IdCombo(cboOrden) > 0 Then Return CargarOrden()
            lblEstado.Text = If(chkSoloPendientes.Checked, "No hay órdenes pendientes de cotización para este paciente. Quitá Sin cotización para ver los históricos.", "El paciente no tiene órdenes registradas.")
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudieron consultar las órdenes."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Public Function CargarCatalogos() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Dim obraAnterior As Integer = IdCombo(cboObra)
        Dim analisisAnterior As Integer = IdCombo(cboAnalisis)
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                cargando = True
                Using cmd As New MySqlCommand("SELECT id_obra_social,nombre,activo FROM obras_sociales ORDER BY nombre;", cn)
                    Dim tabla = LeerTabla(cmd)
                    Dim fila = tabla.NewRow()
                    fila("id_obra_social") = 0
                    fila("nombre") = "SIN OBRA SOCIAL / SIN VERIFICAR"
                    fila("activo") = True
                    tabla.Rows.InsertAt(fila, 0)
                    MostrarCombo(cboObra, tabla.Copy(), "id_obra_social", "nombre")
                    MostrarCombo(cboObraAdmin, tabla.Copy(), "id_obra_social", "nombre")
                    cboObra.SelectedValue = obraAnterior
                End Using
                If Sesion.EsAdmin() Then
                    Using cmd As New MySqlCommand("SELECT id_analisis,CONCAT(COALESCE(codigo_nbu,'PENDIENTE'),' · ',nombre) AS estudio,precio_referencia_ars,fuente_precio FROM analisis ORDER BY nombre;", cn)
                        Dim tabla = LeerTabla(cmd)
                        MostrarCombo(cboAnalisis, tabla.Copy(), "id_analisis", "estudio")
                        MostrarCombo(cboAnalisisCobertura, tabla.Copy(), "id_analisis", "estudio")
                        If analisisAnterior > 0 Then cboAnalisis.SelectedValue = analisisAnterior
                    End Using
                    Using cmd As New MySqlCommand("SELECT valor_ub_demo_ars,fecha_vigencia,fuente FROM configuracion_tarifas WHERE id_configuracion=1;", cn)
                        Dim tabla = LeerTabla(cmd)
                        If tabla.Rows.Count = 1 Then
                            nudUB.Value = CDec(tabla.Rows(0)("valor_ub_demo_ars"))
                            dtpVigencia.Value = CDate(tabla.Rows(0)("fecha_vigencia"))
                            txtFuenteUB.Text = tabla.Rows(0)("fuente").ToString()
                        End If
                    End Using
                End If
            End Using
            cargando = False
            CargarPrecioManual()
            NuevaObra()
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudieron cargar tarifas y obras sociales."
            Return False
        Finally
            cargando = False
            CADENA = ""
        End Try
    End Function

    Private Function LeerOrden(cn As MySqlConnection, tx As MySqlTransaction) As DataRow
        Dim sql As String = "SELECT o.id_orden,o.id_paciente,o.fecha AS fecha_orden,CONCAT(p.apellido,', ',p.nombre) AS paciente_nombre,p.dni AS paciente_dni FROM ordenes o JOIN pacientes p ON p.id_paciente=o.id_paciente WHERE o.id_orden=@o AND o.id_paciente=@p;"
        If borradorNuevo Then sql = "SELECT 0 AS id_orden,p.id_paciente,@fecha AS fecha_orden,CONCAT(p.apellido,', ',p.nombre) AS paciente_nombre,p.dni AS paciente_dni FROM pacientes p WHERE p.id_paciente=@p;"
        Using cmd As New MySqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@o", IdCombo(cboOrden))
            cmd.Parameters.AddWithValue("@p", IdCombo(cboPaciente))
            If borradorNuevo Then cmd.Parameters.AddWithValue("@fecha", fechaBorrador)
            Dim tabla = LeerTabla(cmd)
            If tabla.Rows.Count <> 1 Then Throw New InvalidOperationException("La orden no pertenece al paciente seleccionado.")
            tabla.Columns("id_orden").ReadOnly = False
            For Each campo In {"id_usuario_confirma", "id_obra_social", "obra_social_nombre", "fecha_emision", "modo_calculo", "importe_particular_ars", "motivo_acuerdo", "fecha_acuerdo", "id_usuario_acuerdo", "porcentaje_descuento", "subtotal_cubierto", "base_calculo_ars", "importe_descuento", "total_final", "calculo_completo", "metodo_pago_previsto", "estado_pago", "metodo_pago_real", "importe_pagado", "fecha_pago", "id_usuario_pago"}
                tabla.Columns.Add(campo, GetType(Object))
            Next
            Dim fila = tabla.Rows(0)
            fila("id_usuario_confirma") = Sesion.idUsuario
            fila("fecha_emision") = Date.Now
            Return fila
        End Using
    End Function

    Private Function LeerDetalle(cn As MySqlConnection, tx As MySqlTransaction) As DataTable
        Dim sql As String = "SELECT a.id_analisis,a.activo,a.codigo_nbu,a.nombre AS nombre_analisis,a.ub_nbu,a.version_nbu," &
            "a.precio_referencia_ars,a.fecha_precio,a.fuente_precio,a.id_usuario_precio," &
            "cf.valor_ub_demo_ars,cf.fecha_actualizacion AS fecha_ub,cf.fuente AS fuente_ub,cf.id_usuario AS usuario_ub," &
            "COALESCE(ca.estado_cobertura,'COBERTURA SIN VERIFICAR') AS estado_cobertura,ca.fecha_cobertura,ca.referencia_cobertura,ca.id_usuario_cobertura," &
            "ca.precio_acordado_ars,ca.fecha_precio_acordado,ca.fuente_precio_acordado,ca.id_usuario_tarifa " &
            "FROM orden_analisis oa JOIN analisis a ON a.id_analisis=oa.id_analisis " &
            "LEFT JOIN configuracion_tarifas cf ON cf.id_configuracion=1 " &
            "LEFT JOIN coberturas_analisis ca ON ca.id_analisis=a.id_analisis AND ca.id_obra_social=@obra " &
            "WHERE oa.id_orden=@orden ORDER BY a.id_analisis;"
        If borradorNuevo Then
            Dim parametros As New List(Of String)
            For i As Integer = 0 To analisisBorrador.Count - 1
                parametros.Add("@analisis" & i.ToString())
            Next
            sql = sql.Replace("FROM orden_analisis oa JOIN analisis a ON a.id_analisis=oa.id_analisis ", "FROM analisis a ")
            sql = sql.Replace("WHERE oa.id_orden=@orden", "WHERE a.id_analisis IN (" & String.Join(",", parametros) & ")")
        End If
        Using cmd As New MySqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@orden", IdCombo(cboOrden))
            cmd.Parameters.AddWithValue("@obra", IdCombo(cboObra))
            If borradorNuevo Then
                For i As Integer = 0 To analisisBorrador.Count - 1
                    cmd.Parameters.AddWithValue("@analisis" & i.ToString(), analisisBorrador(i))
                Next
            End If
            Dim tabla = LeerTabla(cmd)
            If borradorNuevo Then
                If tabla.Rows.Count <> analisisBorrador.Count Then Throw New InvalidOperationException("La selección de estudios no es válida. Regresá a Órdenes.")
                For Each fila As DataRow In tabla.Rows
                    If Not CBool(fila("activo")) Then Throw New InvalidOperationException("Un estudio ya no está activo. Regresá a Órdenes y revisá la selección.")
                Next
            End If
            For Each campo In {"precio_catalogo_ars", "origen_precio_catalogo", "fecha_precio_catalogo", "fuente_precio_catalogo", "id_usuario_precio_catalogo", "precio_efectivo_ars", "origen_precio", "fecha_precio_utilizado", "fuente_precio_utilizado", "id_usuario_precio_utilizado"}
                tabla.Columns.Add(campo, GetType(Object))
            Next
            For Each fila As DataRow In tabla.Rows
                fila("origen_precio_catalogo") = "PENDIENTE"
                If Not IsDBNull(fila("precio_referencia_ars")) Then
                    fila("precio_catalogo_ars") = fila("precio_referencia_ars")
                    fila("origen_precio_catalogo") = "MANUAL"
                    fila("fecha_precio_catalogo") = fila("fecha_precio")
                    fila("fuente_precio_catalogo") = fila("fuente_precio")
                    fila("id_usuario_precio_catalogo") = fila("id_usuario_precio")
                    fila("valor_ub_demo_ars") = DBNull.Value
                ElseIf Not IsDBNull(fila("valor_ub_demo_ars")) AndAlso Not IsDBNull(fila("ub_nbu")) AndAlso Not IsDBNull(fila("codigo_nbu")) AndAlso Not IsDBNull(fila("version_nbu")) Then
                    Dim precio As Decimal = Math.Round(CDec(fila("ub_nbu")) * CDec(fila("valor_ub_demo_ars")), 2, MidpointRounding.AwayFromZero)
                    If precio > 9999999999.99D Then Throw New InvalidOperationException("El precio calculado supera el máximo permitido.")
                    fila("precio_catalogo_ars") = precio
                    fila("origen_precio_catalogo") = "UB_DEMO"
                    fila("fecha_precio_catalogo") = fila("fecha_ub")
                    fila("fuente_precio_catalogo") = fila("fuente_ub")
                    fila("id_usuario_precio_catalogo") = fila("usuario_ub")
                Else
                    fila("valor_ub_demo_ars") = DBNull.Value
                End If
                fila("origen_precio") = "PENDIENTE"
                If Not IsDBNull(fila("precio_acordado_ars")) Then
                    fila("precio_efectivo_ars") = fila("precio_acordado_ars")
                    fila("origen_precio") = "ACORDADO"
                    fila("fecha_precio_utilizado") = fila("fecha_precio_acordado")
                    fila("fuente_precio_utilizado") = fila("fuente_precio_acordado")
                    fila("id_usuario_precio_utilizado") = fila("id_usuario_tarifa")
                ElseIf Not IsDBNull(fila("precio_catalogo_ars")) Then
                    fila("precio_efectivo_ars") = fila("precio_catalogo_ars")
                    fila("origen_precio") = "CATALOGO"
                    fila("fecha_precio_utilizado") = fila("fecha_precio_catalogo")
                    fila("fuente_precio_utilizado") = fila("fuente_precio_catalogo")
                    fila("id_usuario_precio_utilizado") = fila("id_usuario_precio_catalogo")
                End If
            Next
            'dejo solamente los datos que se guardan como copia historica
            Dim campos = CamposDetalle().Split(","c)
            Return tabla.DefaultView.ToTable(False, campos)
        End Using
    End Function

    Private Function CamposDetalle() As String
        Return "id_analisis,codigo_nbu,nombre_analisis,ub_nbu,version_nbu,precio_catalogo_ars,origen_precio_catalogo,valor_ub_demo_ars,fecha_precio_catalogo,fuente_precio_catalogo,id_usuario_precio_catalogo,precio_acordado_ars,precio_efectivo_ars,origen_precio,fecha_precio_utilizado,fuente_precio_utilizado,id_usuario_precio_utilizado,estado_cobertura,fecha_cobertura,referencia_cobertura,id_usuario_cobertura"
    End Function

    Public Function CargarOrden() As Boolean
        If borradorNuevo Then Return CargarBorrador()
        If Not Sesion.Puede("COTIZAR_ORDENES") OrElse IdCombo(cboOrden) = 0 Then Return False
        If Not ObtenerDatosConexion() Then Return False
        Try
            cargando = True
            cabecera = Nothing
            detalle = Nothing
            idCotizacion = 0
            dgvDetalle.DataSource = Nothing
            edicionValida = True
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT c.* FROM cotizaciones c JOIN ordenes o ON o.id_orden=c.id_orden WHERE c.id_orden=@o AND o.id_paciente=@p;", cn)
                    cmd.Parameters.AddWithValue("@o", IdCombo(cboOrden))
                    cmd.Parameters.AddWithValue("@p", IdCombo(cboPaciente))
                    Dim tabla = LeerTabla(cmd)
                    idCotizacion = If(tabla.Rows.Count = 1, CInt(tabla.Rows(0)("id_cotizacion")), 0)
                    If idCotizacion > 0 Then
                        cabecera = tabla.Rows(0)
                        Using cmdDetalle As New MySqlCommand("SELECT " & CamposDetalle() & " FROM cotizacion_detalle WHERE id_cotizacion=@id ORDER BY id_analisis;", cn)
                            cmdDetalle.Parameters.AddWithValue("@id", idCotizacion)
                            detalle = LeerTabla(cmdDetalle)
                        End Using
                        cboObra.SelectedValue = If(IsDBNull(cabecera("id_obra_social")), 0, CInt(cabecera("id_obra_social")))
                        cboModo.Text = cabecera("modo_calculo").ToString()
                        chkImporte.Checked = Not IsDBNull(cabecera("importe_particular_ars")) AndAlso Not cabecera("motivo_acuerdo").ToString().StartsWith(MotivoReferencia, StringComparison.Ordinal)
                        nudParticular.Value = If(chkImporte.Checked, CDec(cabecera("importe_particular_ars")), 0D)
                        txtMotivo.Text = cabecera("motivo_acuerdo").ToString()
                        nudDescuento.Value = CDec(cabecera("porcentaje_descuento"))
                        cboMetodoPrevisto.Text = If(IsDBNull(cabecera("metodo_pago_previsto")), "SIN DEFINIR", cabecera("metodo_pago_previsto").ToString())
                        If cabecera("estado_pago").ToString() = "PAGADO" AndAlso Not cboEstadoPago.Items.Contains("PAGADO") Then cboEstadoPago.Items.Add("PAGADO")
                        cboEstadoPago.Text = cabecera("estado_pago").ToString()
                        cboMetodoReal.Text = If(IsDBNull(cabecera("metodo_pago_real")), "SIN DEFINIR", cabecera("metodo_pago_real").ToString())
                    Else
                        cboEstadoPago.Items.Remove("PAGADO")
                        If cboEstadoPago.SelectedIndex < 0 Then cboEstadoPago.SelectedIndex = 0
                        cabecera = LeerOrden(cn, Nothing)
                        detalle = LeerDetalle(cn, Nothing)
                        ActualizarCabecera()
                    End If
                End Using
            End Using
            MostrarDetalle()
            MostrarTotales()
            lblEstado.Text = Sesion.rolUsuario & If(idCotizacion > 0, " · Comprobante histórico " & idCotizacion.ToString() & "; importes de solo lectura.", " · Vista previa sin guardar. Confirmar no registra un pago.")
            Return True
        Catch ex As InvalidOperationException
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "Revisá los datos, los importes y la conexión antes de reintentar."
            Return False
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo cargar la orden y su cotización."
            Return False
        Finally
            cargando = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Function

    Private Sub ActualizarCabecera()
        If cabecera Is Nothing OrElse idCotizacion > 0 Then Exit Sub
        Dim porcentaje As Decimal
        Dim particularValor As Decimal = 0D
        If Not LeerImporte(nudDescuento, "descuento (0 a 100%)", porcentaje) Then Throw New InvalidOperationException(lblEstado.Text)
        If cboModo.Text = "PARTICULAR" AndAlso chkImporte.Checked AndAlso Not LeerImporte(nudParticular, "importe particular", particularValor) Then Throw New InvalidOperationException(lblEstado.Text)
        cabecera("id_obra_social") = If(IdCombo(cboObra) = 0, CType(DBNull.Value, Object), IdCombo(cboObra))
        cabecera("obra_social_nombre") = If(IdCombo(cboObra) = 0, CType(DBNull.Value, Object), cboObra.Text)
        cabecera("modo_calculo") = cboModo.Text
        Dim particular As Boolean = cboModo.Text = "PARTICULAR" AndAlso chkImporte.Checked
        cabecera("importe_particular_ars") = If(particular, CType(particularValor, Object), DBNull.Value)
        cabecera("motivo_acuerdo") = If(particular, CType(txtMotivo.Text.Trim(), Object), DBNull.Value)
        cabecera("fecha_acuerdo") = If(particular, CType(Date.Now, Object), DBNull.Value)
        cabecera("id_usuario_acuerdo") = If(particular, CType(Sesion.idUsuario, Object), DBNull.Value)
        cabecera("porcentaje_descuento") = porcentaje
        cabecera("metodo_pago_previsto") = If(cboMetodoPrevisto.SelectedIndex <= 0, CType(DBNull.Value, Object), cboMetodoPrevisto.Text)
        If cboEstadoPago.Text <> "NO PAGADO" AndAlso cboEstadoPago.Text <> "PENDIENTE" Then Throw New InvalidOperationException("El pago solo se registra después de confirmar, mediante Registrar pago realizado.")
        cabecera("estado_pago") = cboEstadoPago.Text
        CalcularReferencia(cabecera, detalle)
        If cboModo.Text = "PARTICULAR" AndAlso Not particular AndAlso referenciaCompleta Then
            'guardo la base automatica y su origen, sin inventar un acuerdo manual
            cabecera("importe_particular_ars") = subtotalReferencia
            cabecera("motivo_acuerdo") = MotivoReferencia & "Sin acuerdo manual. Referencias de estudios antes del descuento."
            cabecera("fecha_acuerdo") = Date.Now
            cabecera("id_usuario_acuerdo") = Sesion.idUsuario
        End If
        CalcularImportes(cabecera, detalle)
        edicionValida = True
    End Sub

    Private Function LeerImporte(campo As NumericUpDown, nombre As String, ByRef valor As Decimal) As Boolean
        'leo tambien el texto que el usuario todavia esta escribiendo
        If Not Decimal.TryParse(campo.Text, NumberStyles.Number, CultureInfo.CurrentCulture, valor) OrElse valor < campo.Minimum OrElse valor > campo.Maximum OrElse Math.Round(valor, campo.DecimalPlaces) <> valor Then
            lblEstado.Text = "Completá " & nombre & " con un número válido entre " & campo.Minimum.ToString() & " y " & campo.Maximum.ToString() & "."
            Return False
        End If
        Return True
    End Function

    Private Sub CalcularImportes(fila As DataRow, estudios As DataTable)
        Dim subtotal As Decimal = 0D
        Dim completo As Boolean = Not IsDBNull(fila("id_obra_social"))
        For Each estudio As DataRow In estudios.Rows
            If estudio("estado_cobertura").ToString() = "COBERTURA SIN VERIFICAR" Then completo = False
            If estudio("estado_cobertura").ToString() = "CUBIERTO" Then
                If IsDBNull(estudio("precio_efectivo_ars")) Then
                    completo = False
                Else
                    subtotal += CDec(estudio("precio_efectivo_ars"))
                End If
            End If
        Next
        If subtotal > 9999999999.99D Then Throw New InvalidOperationException("El subtotal supera el máximo permitido.")
        fila("subtotal_cubierto") = subtotal
        If fila("modo_calculo").ToString() = "PARTICULAR" Then completo = Not IsDBNull(fila("importe_particular_ars"))
        fila("calculo_completo") = completo
        fila("base_calculo_ars") = DBNull.Value
        fila("importe_descuento") = DBNull.Value
        fila("total_final") = DBNull.Value
        If completo Then
            Dim base As Decimal = If(fila("modo_calculo").ToString() = "PARTICULAR", CDec(If(IsDBNull(fila("importe_particular_ars")), 0D, fila("importe_particular_ars"))), subtotal)
            Dim descuento As Decimal = Math.Round(base * CDec(fila("porcentaje_descuento")) / 100D, 2, MidpointRounding.AwayFromZero)
            fila("base_calculo_ars") = base
            fila("importe_descuento") = descuento
            fila("total_final") = base - descuento
        End If
    End Sub

    Private Function Dinero(valor As Object) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return "PENDIENTE"
        Return Numero(valor).ToString("C2", CultureInfo.GetCultureInfo("es-AR"))
    End Function

    Private Function Numero(valor As Object) As Decimal
        Dim resultado As Decimal
        If valor Is Nothing OrElse IsDBNull(valor) OrElse Not Decimal.TryParse(Convert.ToString(valor, CultureInfo.InvariantCulture), NumberStyles.Number, CultureInfo.InvariantCulture, resultado) Then
            Throw New FormatException("El importe no es válido.")
        End If
        Return resultado
    End Function

    Private Function FechaTexto(valor As Object, Optional incluirHora As Boolean = True) As String
        If valor Is Nothing OrElse IsDBNull(valor) Then Return "Sin registrar"
        Dim fecha As Date
        If TypeOf valor Is Date Then
            fecha = CDate(valor)
        ElseIf Not Date.TryParse(valor.ToString(), CultureInfo.GetCultureInfo("es-AR"), DateTimeStyles.None, fecha) Then
            Throw New FormatException("La fecha del comprobante no es válida.")
        End If
        Return fecha.ToString(If(incluirHora, "dd/MM/yyyy HH:mm", "dd/MM/yyyy"))
    End Function

    Private Sub CalcularReferencia(fila As DataRow, estudios As DataTable)
        If estudios Is Nothing OrElse estudios.Rows.Count = 0 Then Throw New InvalidOperationException("La orden no tiene estudios para cotizar.")
        subtotalReferencia = 0D
        referenciaCompleta = True
        coberturaVerificada = Not IsDBNull(fila("id_obra_social"))
        For Each estudio As DataRow In estudios.Rows
            If IsDBNull(estudio("precio_catalogo_ars")) Then
                referenciaCompleta = False
            Else
                Dim precio As Decimal = Numero(estudio("precio_catalogo_ars"))
                If precio < 0D Then Throw New InvalidOperationException("Revisá el precio del estudio.")
                subtotalReferencia += precio
            End If
            If estudio("estado_cobertura").ToString() = "COBERTURA SIN VERIFICAR" Then coberturaVerificada = False
        Next
        If subtotalReferencia > 9999999999.99D Then Throw New InvalidOperationException("El subtotal supera el máximo permitido.")
        baseReferencia = Nothing
        descuentoReferencia = Nothing
        totalReferencia = Nothing
        If fila("modo_calculo").ToString() = "PARTICULAR" AndAlso Not IsDBNull(fila("importe_particular_ars")) Then
            baseReferencia = Numero(fila("importe_particular_ars"))
        ElseIf referenciaCompleta Then
            baseReferencia = subtotalReferencia
        End If
        Dim porcentaje As Decimal = Numero(fila("porcentaje_descuento"))
        If porcentaje < 0D OrElse porcentaje > 100D Then Throw New InvalidOperationException("El descuento debe estar entre 0 y 100%.")
        If baseReferencia.HasValue Then
            descuentoReferencia = Math.Round(baseReferencia.Value * porcentaje / 100D, 2, MidpointRounding.AwayFromZero)
            totalReferencia = baseReferencia.Value - descuentoReferencia.Value
        End If
    End Sub

    Private Function TextoCobertura() As String
        If cabecera("modo_calculo").ToString() = "PARTICULAR" Then Return "Particular: no se descuenta ningún aporte de obra social."
        If Not coberturaVerificada Then Return "Cobertura sin verificar. Importe reconocido por obra social: SIN CONFIRMAR."
        Dim texto As String = "Cobertura registrada por estudio. Importe reconocido por obra social: no registrado; no se supone $0."
        If CBool(cabecera("calculo_completo")) Then texto &= Environment.NewLine & "Cálculo cubierto informativo: base " & Dinero(cabecera("base_calculo_ars")) & "; descuento " & Dinero(cabecera("importe_descuento")) & "; neto " & Dinero(cabecera("total_final")) & ". No equivale al importe del paciente."
        Return texto
    End Function

    Private Function TextoDefinitivo() As String
        If cabecera("modo_calculo").ToString() = "PARTICULAR" AndAlso Not IsDBNull(cabecera("total_final")) Then
            Return "Importe definitivo a cargo del paciente: " & Dinero(cabecera("total_final"))
        End If
        Return "Importe definitivo a cargo del paciente: PENDIENTE" & If(coberturaVerificada, " de definir aporte o acuerdo particular.", " de verificación de cobertura.")
    End Function

    Private Sub MostrarTotales()
        If cabecera Is Nothing Then Exit Sub
        CalcularReferencia(cabecera, detalle)
        lblSubtotal.Text = "Subtotal bruto de estudios: " & Dinero(subtotalReferencia) & If(referenciaCompleta, "", " (PARCIAL: hay valores pendientes)")
        lblBase.Text = "Base antes del descuento: " & Dinero(If(baseReferencia.HasValue, CType(baseReferencia.Value, Object), DBNull.Value))
        lblDescuento.Text = "Descuento de referencia " & Numero(cabecera("porcentaje_descuento")).ToString("0.##") & "%: " & Dinero(If(descuentoReferencia.HasValue, CType(descuentoReferencia.Value, Object), DBNull.Value))
        lblTotalReferencia.Text = "Total de referencia: " & Dinero(If(totalReferencia.HasValue, CType(totalReferencia.Value, Object), DBNull.Value))
        lblCoberturaResumen.Text = TextoCobertura()
        lblTotal.Text = TextoDefinitivo()
    End Sub

    Private Sub MostrarDetalle()
        dgvDetalle.DataSource = detalle
        For Each columna As DataGridViewColumn In dgvDetalle.Columns
            columna.Visible = False
            columna.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Dim campos = {"codigo_nbu", "nombre_analisis", "ub_nbu", "precio_catalogo_ars", "precio_acordado_ars", "precio_efectivo_ars", "estado_cobertura"}
        Dim titulos = {"Código NBU", "Estudio", "UB", "Referencia NBU ARS", "Acordado obra social", "Precio del cálculo cubierto", "Cobertura"}
        For i As Integer = 0 To campos.Length - 1
            Dim columna = dgvDetalle.Columns(campos(i))
            columna.Visible = True
            columna.DisplayIndex = i
            columna.HeaderText = titulos(i)
            If campos(i).StartsWith("precio_") Then
                columna.DefaultCellStyle.Format = "C2"
                columna.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("es-AR")
                columna.DefaultCellStyle.NullValue = "VALOR NBU PENDIENTE"
                If campos(i) = "precio_acordado_ars" Then columna.DefaultCellStyle.NullValue = "SIN TARIFA ESPECÍFICA"
            End If
        Next
        dgvDetalle.Columns("nombre_analisis").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvDetalle.Columns("nombre_analisis").MinimumWidth = 240
        dgvDetalle.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvDetalle.ClearSelection()
    End Sub

    Private Sub BloquearTarifas(cn As MySqlConnection, tx As MySqlTransaction, obra As Integer)
        'uso el mismo orden de bloqueo al cotizar y al cambiar tarifas
        Using cmd As New MySqlCommand("SELECT id_configuracion FROM configuracion_tarifas WHERE id_configuracion=1 FOR UPDATE;", cn, tx)
            LeerTabla(cmd)
        End Using
        If obra > 0 Then
            Using cmd As New MySqlCommand("SELECT nombre,activo FROM obras_sociales WHERE id_obra_social=@id FOR UPDATE;", cn, tx)
                cmd.Parameters.AddWithValue("@id", obra)
                Dim tabla = LeerTabla(cmd)
                If tabla.Rows.Count <> 1 Then Throw New InvalidOperationException("La obra social ya no está disponible.")
            End Using
        End If
    End Sub

    Private Function DetallesIguales(a As DataTable, b As DataTable) As Boolean
        If a.Rows.Count <> b.Rows.Count Then Return False
        For i As Integer = 0 To a.Rows.Count - 1
            For Each nombre In CamposDetalle().Split(","c)
                If Not Object.Equals(a.Rows(i)(nombre), b.Rows(i)(nombre)) Then Return False
            Next
        Next
        Return True
    End Function

    Public Function ConfirmarCotizacion() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If idCotizacion > 0 Then
            lblEstado.Text = "El comprobante ya está confirmado y es histórico: no se permite modificarlo ni guardarlo otra vez."
            Return False
        End If
        If guardandoCotizacion OrElse cabecera Is Nothing Then Return False
        If borradorNuevo AndAlso Not Sesion.Puede("CREAR_ORDENES") Then Return False
        Try
            ActualizarCabecera()
        Catch ex As InvalidOperationException
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            edicionValida = False
            lblEstado.Text = "Revisá los datos, los importes y la conexión antes de reintentar."
            AplicarPermisos()
            Return False
        End Try
        If detalle Is Nothing OrElse detalle.Rows.Count = 0 Then
            lblEstado.Text = "La orden debe contener estudios."
            Return False
        End If
        If cboEstadoPago.Text = "PAGADO" Then
            lblEstado.Text = "Confirmar no registra un pago. Elegí NO PAGADO o PENDIENTE; después usá Registrar pago realizado."
            Return False
        End If
        If cboModo.Text = "PARTICULAR" AndAlso chkImporte.Checked AndAlso txtMotivo.Text.Trim() = "" Then
            lblEstado.Text = "Explicá el motivo o referencia del importe particular acordado."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Dim confirmada As Boolean = False
        Dim nuevoId As Integer = 0
        guardandoCotizacion = True
        AplicarPermisos()
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        BloquearTarifas(cn, tx, IdCombo(cboObra))
                        If borradorNuevo Then
                            Using cmd As New MySqlCommand("SELECT id_paciente FROM pacientes WHERE id_paciente=@p FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@p", pacienteEntrada)
                                If LeerTabla(cmd).Rows.Count <> 1 Then Throw New InvalidOperationException("El paciente ya no está disponible.")
                            End Using
                            For Each id As Integer In analisisBorrador
                                Using cmd As New MySqlCommand("SELECT activo FROM analisis WHERE id_analisis=@id FOR UPDATE;", cn, tx)
                                    cmd.Parameters.AddWithValue("@id", id)
                                    Dim activo = cmd.ExecuteScalar()
                                    If activo Is Nothing OrElse Not CBool(activo) Then Throw New InvalidOperationException("Un estudio ya no está activo. Regresá a Órdenes y revisá la selección.")
                                End Using
                            Next
                        Else
                            Using cmd As New MySqlCommand("SELECT id_orden FROM ordenes WHERE id_orden=@o AND id_paciente=@p FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@o", IdCombo(cboOrden))
                                cmd.Parameters.AddWithValue("@p", IdCombo(cboPaciente))
                                If LeerTabla(cmd).Rows.Count <> 1 Then Throw New InvalidOperationException("Revisá el paciente y la orden.")
                            End Using
                            Using cmd As New MySqlCommand("SELECT a.id_analisis FROM orden_analisis oa JOIN analisis a ON a.id_analisis=oa.id_analisis WHERE oa.id_orden=@o ORDER BY a.id_analisis FOR UPDATE;", cn, tx)
                                cmd.Parameters.AddWithValue("@o", IdCombo(cboOrden))
                                LeerTabla(cmd)
                            End Using
                        End If
                        If IdCombo(cboObra) > 0 Then
                            Using cmd As New MySqlCommand("SELECT nombre FROM obras_sociales WHERE id_obra_social=@id AND activo=1;", cn, tx)
                                cmd.Parameters.AddWithValue("@id", IdCombo(cboObra))
                                Dim nombre = cmd.ExecuteScalar()
                                If nombre Is Nothing OrElse nombre.ToString() <> cboObra.Text Then Throw New InvalidOperationException("La obra social cambió o está inactiva. Actualizá la vista previa.")
                            End Using
                        End If
                        Dim ordenActual = LeerOrden(cn, tx)
                        For Each campo In {"paciente_nombre", "paciente_dni", "fecha_orden"}
                            If Not Object.Equals(ordenActual(campo), cabecera(campo)) Then Throw New InvalidOperationException("Los datos de la orden cambiaron. Actualizá la vista previa.")
                        Next
                        If Not DetallesIguales(detalle, LeerDetalle(cn, tx)) Then Throw New InvalidOperationException("Cambiaron los estudios, precios o cobertura. Pulsá Cargar / actualizar y revisá nuevamente.")
                        If borradorNuevo Then
                            Using cmd As New MySqlCommand("INSERT INTO ordenes (id_paciente,fecha) VALUES (@p,@fecha);", cn, tx)
                                cmd.Parameters.AddWithValue("@p", pacienteEntrada)
                                cmd.Parameters.AddWithValue("@fecha", fechaBorrador)
                                cmd.ExecuteNonQuery()
                                cabecera("id_orden") = CInt(cmd.LastInsertedId)
                            End Using
                            For Each id As Integer In analisisBorrador
                                Using cmd As New MySqlCommand("INSERT INTO orden_analisis (id_orden,id_analisis) VALUES (@o,@a);", cn, tx)
                                    cmd.Parameters.AddWithValue("@o", CInt(cabecera("id_orden")))
                                    cmd.Parameters.AddWithValue("@a", id)
                                    cmd.ExecuteNonQuery()
                                End Using
                            Next
                        End If
                        Dim campos As String = "id_orden,id_usuario_confirma,id_obra_social,paciente_nombre,paciente_dni,obra_social_nombre,fecha_orden,fecha_emision,modo_calculo,importe_particular_ars,motivo_acuerdo,fecha_acuerdo,id_usuario_acuerdo,porcentaje_descuento,subtotal_cubierto,base_calculo_ars,importe_descuento,total_final,calculo_completo,metodo_pago_previsto,estado_pago"
                        Dim nombres = campos.Split(","c)
                        Dim parametros As New List(Of String)
                        For Each campo In nombres
                            parametros.Add("@" & campo)
                        Next
                        Using cmd As New MySqlCommand("INSERT INTO cotizaciones (" & campos & ") VALUES (" & String.Join(",", parametros) & ");", cn, tx)
                            cabecera("id_usuario_confirma") = Sesion.idUsuario
                            cabecera("fecha_emision") = Date.Now
                            For Each campo In nombres
                                cmd.Parameters.AddWithValue("@" & campo, cabecera(campo))
                            Next
                            cmd.ExecuteNonQuery()
                            nuevoId = CInt(cmd.LastInsertedId)
                        End Using
                        Dim nombresDetalle = CamposDetalle().Split(","c)
                        Dim valores As New List(Of String) From {"@cotizacion", "@orden"}
                        For Each campo In nombresDetalle
                            valores.Add("@" & campo)
                        Next
                        'guardo todos los estudios en la misma transaccion
                        For Each fila As DataRow In detalle.Rows
                            Using cmd As New MySqlCommand("INSERT INTO cotizacion_detalle (id_cotizacion,id_orden," & CamposDetalle() & ") VALUES (" & String.Join(",", valores) & ");", cn, tx)
                                cmd.Parameters.AddWithValue("@cotizacion", nuevoId)
                                cmd.Parameters.AddWithValue("@orden", CInt(cabecera("id_orden")))
                                For Each campo In nombresDetalle
                                    cmd.Parameters.AddWithValue("@" & campo, fila(campo))
                                Next
                                cmd.ExecuteNonQuery()
                            End Using
                        Next
                        Using cmd As New MySqlCommand("SELECT COUNT(*) AS cantidad,COALESCE(SUM(CASE WHEN estado_cobertura='CUBIERTO' THEN precio_efectivo_ars ELSE 0 END),0) AS subtotal FROM cotizacion_detalle WHERE id_cotizacion=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", nuevoId)
                            Dim fila = LeerTabla(cmd).Rows(0)
                            If CInt(fila("cantidad")) <> detalle.Rows.Count OrElse CDec(fila("subtotal")) <> CDec(cabecera("subtotal_cubierto")) Then Throw New InvalidOperationException("No coincide el subtotal con los estudios. No se confirmó la cotización.")
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                        confirmada = True
                        OrdenGuardadaId = CInt(cabecera("id_orden"))
                        idCotizacion = nuevoId
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            borradorNuevo = False
            ordenEntrada = OrdenGuardadaId
            guardandoCotizacion = False
            Dim recargada As Boolean = CargarOrdenRecibida()
            lblEstado.Text = "Orden " & OrdenGuardadaId.ToString() & " y cotización " & nuevoId.ToString() & " confirmadas. No se registró ningún pago." & If(recargada, " Histórico de solo lectura.", " Se guardaron; recargá el listado antes de reintentar.")
            Return True
        Catch ex As InvalidOperationException
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "Revisá los datos, los importes y la conexión antes de reintentar."
            Return False
        Catch ex As MySqlException When ex.Number = 1062
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "La orden ya tiene una cotización. Pulsá Cargar / actualizar para consultarla."
            Return False
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = If(confirmada, "La cotización ya se guardó. Recargá la orden; no la registres otra vez.", "No se pudo confirmar. Se cancelaron juntos la orden nueva y su cotización; revisá la conexión y los datos.")
            Return confirmada
        Finally
            If borradorNuevo AndAlso Not confirmada AndAlso cabecera IsNot Nothing Then cabecera("id_orden") = 0
            guardandoCotizacion = False
            CADENA = ""
            AplicarPermisos()
        End Try
    End Function

    Public Function RegistrarPago() As Boolean
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Return False
        If idCotizacion = 0 Then
            lblEstado.Text = "Primero confirmá la cotización. No se puede registrar un pago de un borrador."
            Return False
        End If
        If cboMetodoReal.SelectedIndex <= 0 Then
            lblEstado.Text = "Seleccioná el método REAL del pago que estás registrando."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Dim pagoGuardado As Boolean = False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        Using cmd As New MySqlCommand("SELECT total_final,estado_pago,calculo_completo,modo_calculo FROM cotizaciones WHERE id_cotizacion=@id FOR UPDATE;", cn, tx)
                            cmd.Parameters.AddWithValue("@id", idCotizacion)
                            Dim tabla = LeerTabla(cmd)
                            If tabla.Rows.Count <> 1 Then
                                lblEstado.Text = "No se encontró el comprobante. Recargá la orden antes de registrar un pago."
                                Return False
                            End If
                            Dim fila = tabla.Rows(0)
                            If fila("modo_calculo").ToString() <> "PARTICULAR" OrElse fila("estado_pago").ToString() = "PAGADO" OrElse IsDBNull(fila("total_final")) OrElse Not CBool(fila("calculo_completo")) OrElse CDec(fila("total_final")) <= 0D Then
                                lblEstado.Text = "No se registra el pago: falta definir el importe del paciente o el pago ya existe."
                                Return False
                            End If
                        End Using
                        Using cmd As New MySqlCommand("UPDATE cotizaciones SET estado_pago='PAGADO',metodo_pago_real=@metodo,importe_pagado=total_final,fecha_pago=CURRENT_TIMESTAMP,id_usuario_pago=@usuario WHERE id_cotizacion=@id AND estado_pago IN ('NO PAGADO','PENDIENTE') AND modo_calculo='PARTICULAR' AND calculo_completo=1 AND total_final>0;", cn, tx)
                            cmd.Parameters.AddWithValue("@metodo", cboMetodoReal.Text)
                            cmd.Parameters.AddWithValue("@usuario", Sesion.idUsuario)
                            cmd.Parameters.AddWithValue("@id", idCotizacion)
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException("No se pudo registrar el pago seleccionado.")
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                        pagoGuardado = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            If CargarOrden() Then
                lblEstado.Text = "Pago completo registrado por " & Sesion.nombreUsuario & ". El método previsto se conservó por separado."
            Else
                lblEstado.Text = "El pago ya se guardó, pero no se pudo recargar. Revisá el comprobante antes de reintentar; no registres otro pago."
            End If
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = If(pagoGuardado, "El pago ya se guardó. Revisá el comprobante antes de reintentar.", "No se pudo registrar el pago. No se confirmó el cambio.")
            Return pagoGuardado
        Finally
            CADENA = ""
        End Try
    End Function

    Public Function GuardarValorUB() As Boolean
        If Not Sesion.EsAdmin() Then Return False
        Dim valorUB As Decimal
        If Not LeerImporte(nudUB, "valor UB", valorUB) Then Return False
        If valorUB <= 0D OrElse txtFuenteUB.Text.Trim() = "" Then
            lblEstado.Text = "Indicá un valor UB positivo y su fuente de demostración."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        BloquearTarifas(cn, tx, 0)
                        Using cmd As New MySqlCommand("INSERT INTO configuracion_tarifas (id_configuracion,valor_ub_demo_ars,fecha_vigencia,fecha_actualizacion,fuente,id_usuario) VALUES (1,@valor,@fecha,CURRENT_TIMESTAMP,@fuente,@usuario) ON DUPLICATE KEY UPDATE valor_ub_demo_ars=@valor,fecha_vigencia=@fecha,fecha_actualizacion=CURRENT_TIMESTAMP,fuente=@fuente,id_usuario=@usuario;", cn, tx)
                            cmd.Parameters.AddWithValue("@valor", valorUB)
                            cmd.Parameters.AddWithValue("@fecha", dtpVigencia.Value.Date)
                            cmd.Parameters.AddWithValue("@fuente", txtFuenteUB.Text.Trim())
                            cmd.Parameters.AddWithValue("@usuario", Sesion.idUsuario)
                            cmd.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            ActualizarDespuesDeTarifa("Valor UB de demostración guardado.")
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo guardar el valor UB."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub CargarPrecioManual()
        If Not Sesion.EsAdmin() OrElse cboAnalisis.SelectedItem Is Nothing Then Exit Sub
        Dim fila = DirectCast(cboAnalisis.SelectedItem, DataRowView).Row
        chkManual.Checked = Not IsDBNull(fila("precio_referencia_ars"))
        nudManual.Value = If(chkManual.Checked, CDec(fila("precio_referencia_ars")), 0D)
        txtFuenteManual.Text = fila("fuente_precio").ToString()
    End Sub

    Public Function GuardarPrecioManual() As Boolean
        If Not Sesion.EsAdmin() OrElse IdCombo(cboAnalisis) = 0 Then Return False
        Dim importeManual As Decimal = 0D
        If chkManual.Checked AndAlso Not LeerImporte(nudManual, "precio manual", importeManual) Then Return False
        If chkManual.Checked AndAlso txtFuenteManual.Text.Trim() = "" Then
            lblEstado.Text = "Completá la fuente del precio manual."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        BloquearTarifas(cn, tx, 0)
                        Using cmd As New MySqlCommand("UPDATE analisis SET precio_referencia_ars=@precio,fecha_precio=CURRENT_TIMESTAMP,fuente_precio=@fuente,id_usuario_precio=@usuario WHERE id_analisis=@id;", cn, tx)
                            cmd.Parameters.AddWithValue("@precio", If(chkManual.Checked, CType(importeManual, Object), DBNull.Value))
                            cmd.Parameters.AddWithValue("@fuente", If(chkManual.Checked, txtFuenteManual.Text.Trim(), "Retiro de precio manual; vuelve a referencia UB de demostración."))
                            cmd.Parameters.AddWithValue("@usuario", Sesion.idUsuario)
                            cmd.Parameters.AddWithValue("@id", IdCombo(cboAnalisis))
                            If cmd.ExecuteNonQuery() <> 1 Then Throw New InvalidOperationException()
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            lblEstado.Text = "Precio actualizado con fecha, fuente y responsable. Los comprobantes históricos se conservan."
            Dim seleccionado = TryCast(cboAnalisis.SelectedItem, DataRowView)
            If seleccionado IsNot Nothing Then
                seleccionado.Row("precio_referencia_ars") = If(chkManual.Checked, CType(importeManual, Object), DBNull.Value)
                seleccionado.Row("fuente_precio") = If(chkManual.Checked, txtFuenteManual.Text.Trim(), "Retiro de precio manual; vuelve a referencia UB de demostración.")
            End If
            ActualizarDespuesDeTarifa("Precio manual guardado con fecha, fuente y responsable.")
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo guardar el precio manual."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub NuevaObra()
        txtNombreObra.Clear()
        chkObraActiva.Checked = True
        cboCobertura.SelectedIndex = 0
        txtRefCobertura.Clear()
        chkTarifa.Checked = False
        nudTarifa.Value = 0D
        txtFuenteTarifa.Clear()
    End Sub

    Public Function GuardarObra() As Boolean
        If Not Sesion.EsAdmin() Then Return False
        If txtNombreObra.Text.Trim() = "" OrElse txtNombreObra.Text.Trim().Length > 150 Then
            lblEstado.Text = "Completá el nombre de la obra social, hasta 150 caracteres."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Try
            Dim id As Integer = IdCombo(cboObraAdmin)
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        BloquearTarifas(cn, tx, id)
                        Dim sql As String = "INSERT INTO obras_sociales (nombre,activo) VALUES (@nombre,@activo);"
                        If id > 0 Then sql = "UPDATE obras_sociales SET nombre=@nombre,activo=@activo WHERE id_obra_social=@id;"
                        Using cmd As New MySqlCommand(sql, cn, tx)
                            cmd.Parameters.AddWithValue("@nombre", txtNombreObra.Text.Trim())
                            cmd.Parameters.AddWithValue("@activo", chkObraActiva.Checked)
                            If id > 0 Then cmd.Parameters.AddWithValue("@id", id)
                            cmd.ExecuteNonQuery()
                            If id = 0 Then id = CInt(cmd.LastInsertedId)
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            CargarCatalogos()
            cboObraAdmin.SelectedValue = id
            ActualizarDespuesDeTarifa("Obra social guardada; no se asignó cobertura automáticamente.")
            Return True
        Catch ex As MySqlException When ex.Number = 1062
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "Ya existe una obra social con ese nombre."
            Return False
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo guardar la obra social."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub CargarCobertura()
        If Not Sesion.EsAdmin() OrElse cargando Then Exit Sub
        If IdCombo(cboObraAdmin) = 0 OrElse IdCombo(cboAnalisisCobertura) = 0 Then
            NuevaCobertura()
            Exit Sub
        End If
        If Not ObtenerDatosConexion() Then Exit Sub
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using cmd As New MySqlCommand("SELECT estado_cobertura,referencia_cobertura,precio_acordado_ars,fuente_precio_acordado FROM coberturas_analisis WHERE id_obra_social=@obra AND id_analisis=@analisis;", cn)
                    cmd.Parameters.AddWithValue("@obra", IdCombo(cboObraAdmin))
                    cmd.Parameters.AddWithValue("@analisis", IdCombo(cboAnalisisCobertura))
                    Dim tabla = LeerTabla(cmd)
                    NuevaCobertura()
                    If tabla.Rows.Count = 1 Then
                        Dim fila = tabla.Rows(0)
                        cboCobertura.Text = fila("estado_cobertura").ToString()
                        txtRefCobertura.Text = fila("referencia_cobertura").ToString()
                        chkTarifa.Checked = Not IsDBNull(fila("precio_acordado_ars"))
                        nudTarifa.Value = If(chkTarifa.Checked, CDec(fila("precio_acordado_ars")), 0D)
                        txtFuenteTarifa.Text = fila("fuente_precio_acordado").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron cargar o procesar la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo consultar la cobertura."
        Finally
            CADENA = ""
        End Try
    End Sub

    Private Sub NuevaCobertura()
        cboCobertura.SelectedIndex = 0
        txtRefCobertura.Clear()
        chkTarifa.Checked = False
        nudTarifa.Value = 0D
        txtFuenteTarifa.Clear()
    End Sub

    Public Function GuardarCobertura() As Boolean
        If Not Sesion.EsAdmin() OrElse IdCombo(cboObraAdmin) = 0 OrElse IdCombo(cboAnalisisCobertura) = 0 Then Return False
        Dim importeTarifa As Decimal = 0D
        If chkTarifa.Checked AndAlso Not LeerImporte(nudTarifa, "tarifa acordada", importeTarifa) Then Return False
        If cboCobertura.SelectedIndex < 0 OrElse (cboCobertura.Text <> "COBERTURA SIN VERIFICAR" AndAlso txtRefCobertura.Text.Trim() = "") OrElse (chkTarifa.Checked AndAlso txtFuenteTarifa.Text.Trim() = "") Then
            lblEstado.Text = "Completá estado y referencia de cobertura, y la fuente de la tarifa si está definida."
            Return False
        End If
        If Not ObtenerDatosConexion() Then Return False
        Try
            Using cn As New MySqlConnection(CADENA)
                cn.Open()
                Using tx = cn.BeginTransaction()
                    Dim transaccionConfirmada As Boolean = False
                    Try
                        BloquearTarifas(cn, tx, IdCombo(cboObraAdmin))
                        Dim sql As String = "INSERT INTO coberturas_analisis (id_obra_social,id_analisis,estado_cobertura,fecha_cobertura,referencia_cobertura,id_usuario_cobertura,precio_acordado_ars,fecha_precio_acordado,fuente_precio_acordado,id_usuario_tarifa) " &
                            "VALUES (@obra,@analisis,@estado,CURRENT_TIMESTAMP,@referencia,@usuario,@precio,CURRENT_TIMESTAMP,@fuente,@usuario) " &
                            "ON DUPLICATE KEY UPDATE estado_cobertura=@estado,fecha_cobertura=CURRENT_TIMESTAMP,referencia_cobertura=@referencia,id_usuario_cobertura=@usuario,precio_acordado_ars=@precio,fecha_precio_acordado=CURRENT_TIMESTAMP,fuente_precio_acordado=@fuente,id_usuario_tarifa=@usuario;"
                        Using cmd As New MySqlCommand(sql, cn, tx)
                            cmd.Parameters.AddWithValue("@obra", IdCombo(cboObraAdmin))
                            cmd.Parameters.AddWithValue("@analisis", IdCombo(cboAnalisisCobertura))
                            cmd.Parameters.AddWithValue("@estado", cboCobertura.Text)
                            cmd.Parameters.AddWithValue("@referencia", If(txtRefCobertura.Text.Trim() = "", CType(DBNull.Value, Object), txtRefCobertura.Text.Trim()))
                            cmd.Parameters.AddWithValue("@usuario", Sesion.idUsuario)
                            cmd.Parameters.AddWithValue("@precio", If(chkTarifa.Checked, CType(importeTarifa, Object), DBNull.Value))
                            cmd.Parameters.AddWithValue("@fuente", If(chkTarifa.Checked, CType(txtFuenteTarifa.Text.Trim(), Object), DBNull.Value))
                            cmd.ExecuteNonQuery()
                        End Using
                        tx.Commit()
                        transaccionConfirmada = True
                    Catch ex As Exception
                        If Not transaccionConfirmada Then PresentacionSesion.CancelarTransaccion(tx)
                        Throw
                    End Try
                End Using
            End Using
            ActualizarDespuesDeTarifa("Cobertura y tarifa guardadas por ADMIN.")
            Return True
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudo completar el guardado de la cotización. Revisá los datos y volvé a intentar.", ex)
            lblEstado.Text = "No se pudo guardar la cobertura."
            Return False
        Finally
            CADENA = ""
        End Try
    End Function

    Private Sub AgregarResumen(seccion As String, concepto As String, valor As String, Optional tipo As String = "texto")
        resumenImpresion.Rows.Add(seccion, concepto, valor, tipo)
    End Sub

    Private Sub PrepararResumenImpresion()
        'uso los mismos importes que muestra la pantalla, sin leer tarifas nuevas
        CalcularReferencia(cabecera, detalle)
        resumenImpresion = New DataTable
        For Each nombre As String In {"seccion", "concepto", "valor", "tipo"}
            resumenImpresion.Columns.Add(nombre, GetType(String))
        Next
        AgregarResumen("REFERENCIA ECONÓMICA", "", "", "seccion")
        AgregarResumen("", "Subtotal bruto de estudios" & If(referenciaCompleta, "", " (parcial)"), Dinero(subtotalReferencia), "importe")
        AgregarResumen("", "Base antes del descuento", Dinero(If(baseReferencia.HasValue, CType(baseReferencia.Value, Object), DBNull.Value)), "importe")
        If cabecera("modo_calculo").ToString() = "PARTICULAR" AndAlso Not IsDBNull(cabecera("importe_particular_ars")) AndAlso Not cabecera("motivo_acuerdo").ToString().StartsWith(MotivoReferencia, StringComparison.Ordinal) Then
            AgregarResumen("", "Acuerdo particular para la orden", Dinero(cabecera("importe_particular_ars")), "importe")
        End If
        AgregarResumen("", "Descuento de referencia (" & Numero(cabecera("porcentaje_descuento")).ToString("0.##") & "%)", Dinero(If(descuentoReferencia.HasValue, CType(descuentoReferencia.Value, Object), DBNull.Value)), "importe")
        AgregarResumen("", "TOTAL DE REFERENCIA", Dinero(If(totalReferencia.HasValue, CType(totalReferencia.Value, Object), DBNull.Value)), "total")
        If Not referenciaCompleta Then AgregarResumen("", "Precios faltantes", "VALOR NBU PENDIENTE. No se interpreta un precio faltante como cero.")

        AgregarResumen("COBERTURA", "", "", "seccion")
        If cabecera("modo_calculo").ToString() = "PARTICULAR" Then
            AgregarResumen("", "Modalidad", "PARTICULAR. No se resta un aporte de obra social.")
        Else
            AgregarResumen("", "Verificación", If(coberturaVerificada, "Estados registrados por estudio; ver tabla.", "COBERTURA SIN VERIFICAR"))
            AgregarResumen("", "Importe reconocido por obra social", If(coberturaVerificada, "No registrado; no se supone cero.", "Sin confirmar."))
            AgregarResumen("", "Subtotal de estudios marcados cubiertos", Dinero(cabecera("subtotal_cubierto")), "importe")
            If CBool(cabecera("calculo_completo")) Then
                AgregarResumen("", "Descuento del cálculo cubierto histórico", Dinero(cabecera("importe_descuento")), "importe")
                AgregarResumen("", "Neto del cálculo cubierto histórico", Dinero(cabecera("total_final")), "importe")
                AgregarResumen("", "Alcance del cálculo cubierto", "Es informativo: no equivale a aporte confirmado ni a importe definitivo del paciente.")
            End If
        End If

        AgregarResumen("IMPORTE A CARGO DEL PACIENTE", "", "", "seccion")
        If cabecera("modo_calculo").ToString() = "PARTICULAR" AndAlso Not IsDBNull(cabecera("total_final")) Then
            AgregarResumen("", "IMPORTE DEFINITIVO", Dinero(cabecera("total_final")), "total")
        Else
            AgregarResumen("", "Estado", If(coberturaVerificada, "PENDIENTE de definir aporte o acuerdo particular.", "PENDIENTE de verificación de cobertura."), "pendiente")
        End If

        AgregarResumen("PAGO · REGISTRO DEL ENTORNO ACADÉMICO", "", "", "seccion")
        AgregarResumen("", "Estado registrado", If(cabecera("estado_pago").ToString() = "PAGADO", "PAGADO · REGISTRO SIMULADO", cabecera("estado_pago").ToString()))
        AgregarResumen("", "Método de pago previsto", If(IsDBNull(cabecera("metodo_pago_previsto")), "Sin definir", cabecera("metodo_pago_previsto").ToString()))
        If cabecera("estado_pago").ToString() = "PAGADO" Then
            AgregarResumen("", "Método registrado", If(IsDBNull(cabecera("metodo_pago_real")), "Sin registrar", cabecera("metodo_pago_real").ToString()))
            AgregarResumen("", "Importe registrado (simulado)", Dinero(cabecera("importe_pagado")), "importe")
            AgregarResumen("", "Fecha del registro de pago", FechaTexto(cabecera("fecha_pago")))
            If IsDBNull(cabecera("fecha_pago")) OrElse IsDBNull(cabecera("importe_pagado")) Then AgregarResumen("", "Advertencia", "Registro incompleto. Consultar al encargado; no se completan datos supuestos.")
        Else
            AgregarResumen("", "Recepción de dinero", "Sin pago registrado. Elegir método previsto no confirma un cobro.")
        End If
        AgregarResumen("OBSERVACIONES", "", "", "seccion")
        Dim observaciones As String = cabecera("motivo_acuerdo").ToString()
        If observaciones.StartsWith(MotivoReferencia, StringComparison.Ordinal) Then observaciones = "Cotización según precios de referencia, sin acuerdo particular manual."
        AgregarResumen("", "", If(observaciones.Trim() = "", "Sin observaciones registradas.", observaciones), "nota")
    End Sub

    Private Sub FalloAlImprimir(ex As Exception)
        If falloImpresion Then Exit Sub
        falloImpresion = True
        lblEstado.Text = "No se pudo generar la impresión. El comprobante guardado se conserva."
        PresentacionSesion.MostrarError(lblEstado.Text, ex)
    End Sub

    Private Sub PrintDocument1_QueryPageSettings(sender As Object, e As QueryPageSettingsEventArgs) Handles PrintDocument1.QueryPageSettings
        Try
            e.PageSettings.PaperSize = New PaperSize("A4", 827, 1169)
            e.PageSettings.Margins = New Margins(60, 60, 60, 60)
            e.PageSettings.Landscape = False
        Catch ex As Exception
            e.Cancel = True
            FalloAlImprimir(ex)
        End Try
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        falloImpresion = False
        paginaImpresion = 0
        filaImpresion = 0
        filaResumenImpresion = 0
        Try
            If Not Sesion.Puede("COTIZAR_ORDENES") OrElse cabecera Is Nothing Then
                e.Cancel = True
                Exit Sub
            End If
            If idCotizacion = 0 Then ActualizarCabecera()
            PrepararResumenImpresion()
            Dim tabla = cabecera.Table.Clone()
            tabla.ImportRow(cabecera)
            cabeceraImpresion = tabla.Rows(0)
            detalleImpresion = detalle.Copy()
        Catch ex As Exception
            e.Cancel = True
            FalloAlImprimir(ex)
        End Try
    End Sub

    Private Function FormatoTexto(alineacion As StringAlignment) As StringFormat
        Return New StringFormat With {.Alignment = alineacion, .LineAlignment = StringAlignment.Near, .Trimming = StringTrimming.None}
    End Function

    Private Function MedirTexto(g As Graphics, texto As String, fuente As Font, ancho As Single) As Single
        Using formato = FormatoTexto(StringAlignment.Near)
            Return CSng(Math.Ceiling(g.MeasureString(If(texto = "", " ", texto), fuente, New SizeF(ancho, 100000), formato).Height))
        End Using
    End Function

    Private Sub DibujarTexto(g As Graphics, texto As String, fuente As Font, color As Brush, area As RectangleF, Optional alineacion As StringAlignment = StringAlignment.Near)
        Using formato = FormatoTexto(alineacion)
            g.DrawString(texto, fuente, color, area, formato)
        End Using
    End Sub

    Private Sub DibujarDato(g As Graphics, etiqueta As String, valor As String, area As RectangleF, fuente As Font, pequena As Font)
        DibujarTexto(g, etiqueta, pequena, Brushes.DimGray, New RectangleF(area.X + 10, area.Y + 6, area.Width - 20, 15))
        DibujarTexto(g, valor, fuente, Brushes.Black, New RectangleF(area.X + 10, area.Y + 22, area.Width - 20, area.Height - 26))
    End Sub

    Private Function DibujarEncabezado(e As PrintPageEventArgs, fuente As Font, negrita As Font, pequena As Font, borde As Pen, bordo As Brush) As Single
        Dim g = e.Graphics
        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top
        Dim ancho As Single = e.MarginBounds.Width
        Using marca As New Font("Segoe UI", 21.0F, FontStyle.Bold), titulo As New Font("Segoe UI", 11.0F, FontStyle.Bold)
            g.DrawLine(borde, x, y, x + ancho, y)
            DibujarTexto(g, "Laboratorio L&A", marca, bordo, New RectangleF(x, y + 8, ancho, 37))
            DibujarTexto(g, "CONSTANCIA DE ESTUDIOS Y COTIZACIÓN", titulo, Brushes.Black, New RectangleF(x, y + 48, ancho, 25))
        End Using
        Dim estado As String = If(idCotizacion = 0, "BORRADOR · SIN CONFIRMAR · NO ACREDITA PAGO", "COMPROBANTE N° " & idCotizacion.ToString() & " · INFORMATIVO · NO ACREDITA PAGO")
        DibujarTexto(g, estado, pequena, bordo, New RectangleF(x, y + 76, ancho, 18))
        y += 100
        Dim medio As Single = ancho / 2
        Dim alto As Single = Math.Max(47, MedirTexto(g, cabeceraImpresion("paciente_nombre").ToString(), negrita, medio - 20) + 29)
        g.DrawRectangle(borde, x, y, ancho, alto)
        g.DrawLine(borde, x + medio, y, x + medio, y + alto)
        DibujarDato(g, "PACIENTE", cabeceraImpresion("paciente_nombre").ToString(), New RectangleF(x, y, medio, alto), negrita, pequena)
        DibujarDato(g, "DOCUMENTO", cabeceraImpresion("paciente_dni").ToString(), New RectangleF(x + medio, y, medio, alto), fuente, pequena)
        y += alto
        g.DrawRectangle(borde, x, y, ancho, 47)
        g.DrawLine(borde, x + medio, y, x + medio, y + 47)
        DibujarDato(g, "ORDEN / FECHA", If(borradorNuevo, "Por confirmar", cabeceraImpresion("id_orden").ToString()) & " · " & FechaTexto(cabeceraImpresion("fecha_orden"), False), New RectangleF(x, y, medio, 47), fuente, pequena)
        DibujarDato(g, "FECHA DE EMISIÓN", FechaTexto(cabeceraImpresion("fecha_emision")), New RectangleF(x + medio, y, medio, 47), fuente, pequena)
        y += 47
        Dim obra As String = If(IsDBNull(cabeceraImpresion("obra_social_nombre")), "Sin obra social seleccionada", cabeceraImpresion("obra_social_nombre").ToString())
        alto = Math.Max(47, MedirTexto(g, obra, fuente, ancho - 20) + 29)
        g.DrawRectangle(borde, x, y, ancho, alto)
        DibujarDato(g, "OBRA SOCIAL", obra, New RectangleF(x, y, ancho, alto), fuente, pequena)
        Return y + alto + 15
    End Function

    Private Sub DibujarPie(e As PrintPageEventArgs)
        Using pequena As New Font("Segoe UI", 8.0F)
            Dim x As Single = e.MarginBounds.Left
            Dim ancho As Single = e.MarginBounds.Width
            Dim y As Single = e.MarginBounds.Bottom - 66
            e.Graphics.DrawLine(Pens.LightGray, x, y - 6, x + ancho, y - 6)
            DibujarTexto(e.Graphics, Leyenda, pequena, Brushes.Black, New RectangleF(x, y, ancho, 28))
            DibujarTexto(e.Graphics, "Sistema académico: datos y operaciones ficticios. Referencia de Santa Fe, no arancel oficial de Misiones.", pequena, Brushes.DimGray, New RectangleF(x, y + 30, ancho, 25))
            DibujarTexto(e.Graphics, "Página " & paginaImpresion.ToString(), pequena, Brushes.Black, New RectangleF(x, y + 52, ancho, 14), StringAlignment.Far)
        End Using
    End Sub

    Private Function AltoResumen(g As Graphics, fila As DataRow, fuente As Font, negrita As Font, ancho As Single) As Single
        Dim tipo As String = fila("tipo").ToString()
        If tipo = "seccion" Then Return 26
        If tipo = "nota" Then Return MedirTexto(g, fila("valor").ToString(), fuente, ancho - 20) + 16
        Dim numerico As Boolean = tipo = "importe" OrElse tipo = "total"
        Dim letra As Font = If(tipo = "total", negrita, fuente)
        Dim izquierda As Single = ancho * If(numerico, 0.66F, 0.36F)
        Return Math.Max(22, Math.Max(MedirTexto(g, fila("concepto").ToString(), letra, izquierda - 16), MedirTexto(g, fila("valor").ToString(), letra, ancho - izquierda - 16)) + 10)
    End Function

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            If falloImpresion OrElse Not Sesion.Puede("COTIZAR_ORDENES") Then
                e.Cancel = True
                Exit Sub
            End If
            If e.MarginBounds.Width < 600 OrElse e.MarginBounds.Height < 800 Then Throw New InvalidOperationException("Revisá el papel A4 y los márgenes.")
            paginaImpresion += 1
            e.Graphics.Clear(Color.White)
            Dim g = e.Graphics
            Dim x As Single = e.MarginBounds.Left
            Dim ancho As Single = e.MarginBounds.Width
            Dim limite As Single = e.MarginBounds.Bottom - 84
            Using fuente As New Font("Segoe UI", 9.0F), negrita As New Font("Segoe UI", 10.0F, FontStyle.Bold), pequena As New Font("Segoe UI", 8.0F), borde As New Pen(Color.FromArgb(210, 214, 219)), bordo As New SolidBrush(Color.FromArgb(130, 35, 51)), fondo As New SolidBrush(Color.FromArgb(243, 245, 247))
                Dim y As Single = DibujarEncabezado(e, fuente, negrita, pequena, borde, bordo)
                Dim inicio As Single = y
                If filaImpresion < detalleImpresion.Rows.Count Then
                    Dim anchos As Single() = {ancho * 0.13F, ancho * 0.60F, ancho * 0.08F, ancho * 0.19F}
                    Dim titulos As String() = {"CÓDIGO NBU", "DESCRIPCIÓN DEL ESTUDIO", "UB", "IMPORTE ARS"}
                    Dim cx As Single = x
                    For i As Integer = 0 To 3
                        g.FillRectangle(fondo, cx, y, anchos(i), 28)
                        g.DrawRectangle(borde, cx, y, anchos(i), 28)
                        DibujarTexto(g, titulos(i), pequena, Brushes.Black, New RectangleF(cx + 6, y + 7, anchos(i) - 12, 19), If(i >= 2, StringAlignment.Far, StringAlignment.Near))
                        cx += anchos(i)
                    Next
                    y += 28
                    While filaImpresion < detalleImpresion.Rows.Count
                        Dim fila = detalleImpresion.Rows(filaImpresion)
                        Dim descripcion As String = fila("nombre_analisis").ToString()
                        Dim cobertura As String = fila("estado_cobertura").ToString()
                        If Not cobertura.StartsWith("COBERTURA", StringComparison.Ordinal) Then cobertura = "Cobertura: " & cobertura
                        Dim altoDescripcion As Single = MedirTexto(g, descripcion, fuente, anchos(1) - 12)
                        Dim altoCobertura As Single = MedirTexto(g, cobertura, pequena, anchos(1) - 12)
                        Dim alto As Single = Math.Max(37, altoDescripcion + altoCobertura + 14)
                        alto = Math.Max(alto, MedirTexto(g, Dinero(fila("precio_catalogo_ars")), fuente, anchos(3) - 12) + 14)
                        alto = Math.Max(alto, MedirTexto(g, If(IsDBNull(fila("ub_nbu")), "Pendiente", fila("ub_nbu").ToString()), fuente, anchos(2) - 12) + 14)
                        If alto > limite - inicio - 28 Then Throw New InvalidOperationException("La descripción supera el espacio de una página A4. Revisá el estudio.")
                        If y + alto > limite Then
                            DibujarPie(e)
                            e.HasMorePages = True
                            Exit Sub
                        End If
                        cx = x
                        For i As Integer = 0 To 3
                            If filaImpresion Mod 2 = 1 Then g.FillRectangle(fondo, cx, y, anchos(i), alto)
                            g.DrawRectangle(borde, cx, y, anchos(i), alto)
                            cx += anchos(i)
                        Next
                        DibujarTexto(g, fila("codigo_nbu").ToString(), fuente, Brushes.Black, New RectangleF(x + 6, y + 7, anchos(0) - 12, alto - 12))
                        cx = x + anchos(0)
                        DibujarTexto(g, descripcion, fuente, Brushes.Black, New RectangleF(cx + 6, y + 6, anchos(1) - 12, altoDescripcion + 2))
                        DibujarTexto(g, cobertura, pequena, Brushes.DimGray, New RectangleF(cx + 6, y + altoDescripcion + 8, anchos(1) - 12, altoCobertura + 2))
                        cx += anchos(1)
                        DibujarTexto(g, If(IsDBNull(fila("ub_nbu")), "Pendiente", fila("ub_nbu").ToString()), fuente, Brushes.Black, New RectangleF(cx + 6, y + 7, anchos(2) - 12, alto - 12), StringAlignment.Far)
                        cx += anchos(2)
                        DibujarTexto(g, Dinero(fila("precio_catalogo_ars")), fuente, Brushes.Black, New RectangleF(cx + 6, y + 7, anchos(3) - 12, alto - 12), StringAlignment.Far)
                        y += alto
                        filaImpresion += 1
                    End While
                    y += 12
                End If
                While filaResumenImpresion < resumenImpresion.Rows.Count
                    Dim fila = resumenImpresion.Rows(filaResumenImpresion)
                    Dim tipo As String = fila("tipo").ToString()
                    Dim alto As Single = AltoResumen(g, fila, fuente, negrita, ancho)
                    Dim reserva As Single = alto
                    If tipo = "seccion" AndAlso filaResumenImpresion + 1 < resumenImpresion.Rows.Count Then
                        Dim bloque As Single = alto
                        For j As Integer = filaResumenImpresion + 1 To resumenImpresion.Rows.Count - 1
                            If resumenImpresion.Rows(j)("tipo").ToString() = "seccion" Then Exit For
                            bloque += AltoResumen(g, resumenImpresion.Rows(j), fuente, negrita, ancho)
                        Next
                        reserva = If(bloque <= limite - inicio, bloque, alto + AltoResumen(g, resumenImpresion.Rows(filaResumenImpresion + 1), fuente, negrita, ancho))
                    End If
                    If reserva > limite - inicio Then Throw New InvalidOperationException("Las observaciones superan el espacio imprimible. Revisá su extensión.")
                    If y + reserva > limite Then
                        DibujarPie(e)
                        e.HasMorePages = True
                        Exit Sub
                    End If
                    If tipo = "seccion" Then
                        g.FillRectangle(fondo, x, y, ancho, alto)
                        DibujarTexto(g, fila("seccion").ToString(), pequena, bordo, New RectangleF(x + 8, y + 8, ancho - 16, alto - 10))
                    ElseIf tipo = "nota" Then
                        DibujarTexto(g, fila("valor").ToString(), fuente, Brushes.Black, New RectangleF(x + 8, y + 7, ancho - 16, alto - 10))
                    Else
                        Dim numerico As Boolean = tipo = "importe" OrElse tipo = "total"
                        Dim izquierda As Single = ancho * If(numerico, 0.66F, 0.36F)
                        Dim letra As Font = If(tipo = "total", negrita, fuente)
                        If tipo = "total" Then g.FillRectangle(fondo, x, y, ancho, alto)
                        DibujarTexto(g, fila("concepto").ToString(), letra, If(tipo = "total", bordo, Brushes.Black), New RectangleF(x + 8, y + 5, izquierda - 16, alto - 8))
                        DibujarTexto(g, fila("valor").ToString(), letra, If(tipo = "total", bordo, Brushes.Black), New RectangleF(x + izquierda + 8, y + 5, ancho - izquierda - 16, alto - 8), If(numerico, StringAlignment.Far, StringAlignment.Near))
                        g.DrawLine(borde, x, y + alto, x + ancho, y + alto)
                    End If
                    y += alto
                    filaResumenImpresion += 1
                End While
            End Using
            DibujarPie(e)
            e.HasMorePages = False
        Catch ex As Exception
            e.Cancel = True
            e.HasMorePages = False
            FalloAlImprimir(ex)
        End Try
    End Sub

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") OrElse cabecera Is Nothing Then Exit Sub
        Try
            falloImpresion = False
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog(Me)
        Catch ex As Exception
            FalloAlImprimir(ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") OrElse idCotizacion = 0 Then Exit Sub
        Try
            falloImpresion = False
            If PrintDialog1.ShowDialog(Me) = DialogResult.OK Then PrintDocument1.Print()
        Catch ex As Exception
            FalloAlImprimir(ex)
        End Try
    End Sub


    Private Sub LimpiarCotizacion()
        cargando = True
        cabecera = Nothing
        detalle = Nothing
        idCotizacion = 0
        dgvDetalle.DataSource = Nothing
        cboModo.SelectedIndex = 0
        chkImporte.Checked = False
        nudParticular.Value = 0D
        nudDescuento.Value = 0D
        txtMotivo.Clear()
        cboMetodoPrevisto.SelectedIndex = 0
        cboMetodoReal.SelectedIndex = 0
        cboEstadoPago.SelectedIndex = 0
        cboEstadoPago.Items.Remove("PAGADO")
        If cboObra.DataSource IsNot Nothing Then cboObra.SelectedValue = 0
        lblSubtotal.Text = "Subtotal bruto: sin selección"
        lblBase.Text = "Base: pendiente"
        lblDescuento.Text = "Descuento: pendiente"
        lblTotalReferencia.Text = "Total de referencia: pendiente"
        lblCoberturaResumen.Text = "Cobertura: sin selección"
        lblTotal.Text = "TOTAL PENDIENTE"
        cargando = False
        AplicarPermisos()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Exit Sub
        LimpiarCotizacion()
        lblEstado.Text = "Se vació el editor; no se eliminó ninguna cotización. Pulsá Cargar para consultar la orden."
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarPacientes()
    End Sub

    Private Sub cboPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaciente.SelectedIndexChanged
        If Not cargando Then CargarOrdenes()
    End Sub

    Private Sub cboOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrden.SelectedIndexChanged
        If Not cargando AndAlso IdCombo(cboOrden) > 0 Then
            LimpiarCotizacion()
            CargarOrden()
        End If
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        CargarOrden()
    End Sub

    Private Sub chkSoloPendientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloPendientes.CheckedChanged
        If Me.IsHandleCreated AndAlso Not cargando AndAlso Not borradorNuevo Then CargarOrdenes()
    End Sub

    Private Sub ActualizarDespuesDeTarifa(mensaje As String)
        If cabecera Is Nothing Then
            lblEstado.Text = mensaje
            Exit Sub
        End If
        Dim historico As Boolean = idCotizacion > 0
        Dim actualizado As Boolean = CargarOrden()
        lblEstado.Text = mensaje & If(historico, " El comprobante histórico conserva sus valores originales.", If(actualizado, " Grilla y resumen del borrador recalculados.", " Se guardó la tarifa; revisá la lectura antes de reintentar."))
    End Sub

    Private Sub cboObra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObra.SelectedIndexChanged
        If Not cargando AndAlso idCotizacion = 0 AndAlso (borradorNuevo OrElse IdCombo(cboOrden) > 0) Then CargarOrden()
    End Sub

    Private Sub DatosCalculoChanged(sender As Object, e As EventArgs) Handles cboModo.SelectedIndexChanged, chkImporte.CheckedChanged, nudParticular.ValueChanged, nudParticular.TextChanged, txtMotivo.TextChanged, nudDescuento.ValueChanged, nudDescuento.TextChanged, cboMetodoPrevisto.SelectedIndexChanged, cboEstadoPago.SelectedIndexChanged
        If cargando OrElse idCotizacion > 0 OrElse cabecera Is Nothing Then Exit Sub
        Try
            ActualizarCabecera()
            MostrarTotales()
            AplicarPermisos()
            lblEstado.Text = If(IsDBNull(cabecera("total_final")), "TOTAL PENDIENTE: completá cobertura/precios o definí un importe PARTICULAR. Cambios sin guardar.", "Borrador recalculado. Confirmá para guardar; elegir un método no registra un pago.")
        Catch ex As InvalidOperationException
            PresentacionSesion.RegistrarError(ex)
            edicionValida = False
            lblEstado.Text = "Revisá los datos, los importes y la conexión antes de reintentar."
            lblTotal.Text = "TOTAL PENDIENTE · revisá el dato ingresado"
            AplicarPermisos()
        Catch ex As Exception
            edicionValida = False
            lblTotal.Text = "No se pudo recalcular. Revisá los datos."
            AplicarPermisos()
            PresentacionSesion.MostrarError("No se pudo recalcular la cotización. Revisá los importes antes de confirmar.", ex)
        End Try
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Exit Sub
        If PresentacionSesion.Confirmar(If(borradorNuevo, "¿Confirmás guardar la orden y su cotización juntas? Cancelar no guarda ninguna. Esta acción no registra un pago.", "¿Confirmás esta cotización informativa? Los importes quedarán guardados como históricos. Esta acción no registra un pago.")) Then ConfirmarCotizacion()
    End Sub

    Private Sub btnRegistrarPago_Click(sender As Object, e As EventArgs) Handles btnRegistrarPago.Click
        If Not Sesion.Puede("COTIZAR_ORDENES") Then Exit Sub
        If PresentacionSesion.Confirmar("¿Confirmás registrar la recepción del pago completo por el método REAL seleccionado? Elegir un método previsto no es un pago.") Then RegistrarPago()
    End Sub

    Private Sub btnGuardarUB_Click(sender As Object, e As EventArgs) Handles btnGuardarUB.Click
        If Not Sesion.EsAdmin() Then Exit Sub
        If PresentacionSesion.Confirmar("¿Guardás este valor UB exclusivamente de demostración, con tu usuario y fuente?") Then GuardarValorUB()
    End Sub

    Private Sub cboAnalisis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnalisis.SelectedIndexChanged
        Try
            If Not cargando Then CargarPrecioManual()
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Private Sub btnGuardarManual_Click(sender As Object, e As EventArgs) Handles btnGuardarManual.Click
        If Not Sesion.EsAdmin() Then Exit Sub
        If PresentacionSesion.Confirmar("¿Confirmás guardar o retirar el reemplazo manual de este análisis?") Then GuardarPrecioManual()
    End Sub

    Private Sub cboObraAdmin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObraAdmin.SelectedIndexChanged
        Try
            If cargando OrElse Not Sesion.EsAdmin() Then Exit Sub
            If IdCombo(cboObraAdmin) = 0 Then
                NuevaObra()
            Else
                Dim fila = DirectCast(cboObraAdmin.SelectedItem, DataRowView).Row
                txtNombreObra.Text = fila("nombre").ToString()
                chkObraActiva.Checked = CBool(fila("activo"))
                CargarCobertura()
            End If
        Catch ex As Exception
            PresentacionSesion.MostrarError("No se pudieron mostrar los datos seleccionados. Volvé a seleccionar el registro.", ex)
        End Try
    End Sub

    Private Sub cboAnalisisCobertura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnalisisCobertura.SelectedIndexChanged
        If Not cargando Then CargarCobertura()
    End Sub

    Private Sub btnNuevaObra_Click(sender As Object, e As EventArgs) Handles btnNuevaObra.Click
        If Sesion.EsAdmin() Then cboObraAdmin.SelectedValue = 0
        If Sesion.EsAdmin() Then NuevaObra()
    End Sub

    Private Sub btnGuardarObra_Click(sender As Object, e As EventArgs) Handles btnGuardarObra.Click
        If Not Sesion.EsAdmin() Then Exit Sub
        If PresentacionSesion.Confirmar("¿Guardás esta obra social sin asignar coberturas automáticas?") Then GuardarObra()
    End Sub

    Private Sub btnGuardarCobertura_Click(sender As Object, e As EventArgs) Handles btnGuardarCobertura.Click
        If Not Sesion.EsAdmin() Then Exit Sub
        If PresentacionSesion.Confirmar("¿Confirmás la cobertura y tarifa con las referencias ingresadas?") Then GuardarCobertura()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class
