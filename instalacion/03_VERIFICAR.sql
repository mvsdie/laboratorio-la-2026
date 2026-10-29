USE `laboratorio_la_2026`;

SELECT 'centros_derivantes' AS tabla,COUNT(*) AS filas,5 AS esperado FROM `centros_derivantes`;

SELECT 'insumos' AS tabla,COUNT(*) AS filas,20 AS esperado FROM `insumos`;

SELECT 'obras_sociales' AS tabla,COUNT(*) AS filas,1 AS esperado FROM `obras_sociales`;

SELECT 'pacientes' AS tabla,COUNT(*) AS filas,20 AS esperado FROM `pacientes`;

SELECT 'roles' AS tabla,COUNT(*) AS filas,3 AS esperado FROM `roles`;

SELECT 'ordenes' AS tabla,COUNT(*) AS filas,21 AS esperado FROM `ordenes`;

SELECT 'usuarios' AS tabla,COUNT(*) AS filas,3 AS esperado FROM `usuarios`;

SELECT 'analisis' AS tabla,COUNT(*) AS filas,22 AS esperado FROM `analisis`;

SELECT 'configuracion_tarifas' AS tabla,COUNT(*) AS filas,1 AS esperado FROM `configuracion_tarifas`;

SELECT 'cotizaciones' AS tabla,COUNT(*) AS filas,8 AS esperado FROM `cotizaciones`;

SELECT 'movimientos_stock' AS tabla,COUNT(*) AS filas,30 AS esperado FROM `movimientos_stock`;

SELECT 'muestras' AS tabla,COUNT(*) AS filas,20 AS esperado FROM `muestras`;

SELECT 'coberturas_analisis' AS tabla,COUNT(*) AS filas,5 AS esperado FROM `coberturas_analisis`;

SELECT 'derivaciones' AS tabla,COUNT(*) AS filas,10 AS esperado FROM `derivaciones`;

SELECT 'orden_analisis' AS tabla,COUNT(*) AS filas,43 AS esperado FROM `orden_analisis`;

SELECT 'cotizacion_detalle' AS tabla,COUNT(*) AS filas,19 AS esperado FROM `cotizacion_detalle`;

SELECT 'muestra_analisis' AS tabla,COUNT(*) AS filas,38 AS esperado FROM `muestra_analisis`;

SELECT CONSTRAINT_TYPE,COUNT(*) cantidad FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_SCHEMA=DATABASE() GROUP BY CONSTRAINT_TYPE;

SELECT 'fk_e6_analisis_usuario_precio' AS relacion,COUNT(*) AS huerfanos FROM `analisis` c LEFT JOIN `usuarios` p ON c.`id_usuario_precio`=p.`id_usuario` WHERE c.`id_usuario_precio` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_cobertura_analisis' AS relacion,COUNT(*) AS huerfanos FROM `coberturas_analisis` c LEFT JOIN `analisis` p ON c.`id_analisis`=p.`id_analisis` WHERE c.`id_analisis` IS NOT NULL AND p.`id_analisis` IS NULL;

SELECT 'fk_e6_cobertura_obra' AS relacion,COUNT(*) AS huerfanos FROM `coberturas_analisis` c LEFT JOIN `obras_sociales` p ON c.`id_obra_social`=p.`id_obra_social` WHERE c.`id_obra_social` IS NOT NULL AND p.`id_obra_social` IS NULL;

SELECT 'fk_e6_cobertura_usuario' AS relacion,COUNT(*) AS huerfanos FROM `coberturas_analisis` c LEFT JOIN `usuarios` p ON c.`id_usuario_cobertura`=p.`id_usuario` WHERE c.`id_usuario_cobertura` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_tarifa_usuario' AS relacion,COUNT(*) AS huerfanos FROM `coberturas_analisis` c LEFT JOIN `usuarios` p ON c.`id_usuario_tarifa`=p.`id_usuario` WHERE c.`id_usuario_tarifa` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_configuracion_usuario' AS relacion,COUNT(*) AS huerfanos FROM `configuracion_tarifas` c LEFT JOIN `usuarios` p ON c.`id_usuario`=p.`id_usuario` WHERE c.`id_usuario` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_cotizacion_acuerdo' AS relacion,COUNT(*) AS huerfanos FROM `cotizaciones` c LEFT JOIN `usuarios` p ON c.`id_usuario_acuerdo`=p.`id_usuario` WHERE c.`id_usuario_acuerdo` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_cotizacion_obra' AS relacion,COUNT(*) AS huerfanos FROM `cotizaciones` c LEFT JOIN `obras_sociales` p ON c.`id_obra_social`=p.`id_obra_social` WHERE c.`id_obra_social` IS NOT NULL AND p.`id_obra_social` IS NULL;

SELECT 'fk_e6_cotizacion_orden' AS relacion,COUNT(*) AS huerfanos FROM `cotizaciones` c LEFT JOIN `ordenes` p ON c.`id_orden`=p.`id_orden` WHERE c.`id_orden` IS NOT NULL AND p.`id_orden` IS NULL;

SELECT 'fk_e6_cotizacion_pago' AS relacion,COUNT(*) AS huerfanos FROM `cotizaciones` c LEFT JOIN `usuarios` p ON c.`id_usuario_pago`=p.`id_usuario` WHERE c.`id_usuario_pago` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_cotizacion_usuario' AS relacion,COUNT(*) AS huerfanos FROM `cotizaciones` c LEFT JOIN `usuarios` p ON c.`id_usuario_confirma`=p.`id_usuario` WHERE c.`id_usuario_confirma` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_detalle_cotizacion_orden' AS relacion,COUNT(*) AS huerfanos FROM `cotizacion_detalle` c LEFT JOIN `cotizaciones` p ON c.`id_cotizacion`=p.`id_cotizacion` AND c.`id_orden`=p.`id_orden` WHERE c.`id_cotizacion` IS NOT NULL AND c.`id_orden` IS NOT NULL AND p.`id_cotizacion` IS NULL;

SELECT 'fk_e6_detalle_orden_analisis' AS relacion,COUNT(*) AS huerfanos FROM `cotizacion_detalle` c LEFT JOIN `orden_analisis` p ON c.`id_orden`=p.`id_orden` AND c.`id_analisis`=p.`id_analisis` WHERE c.`id_orden` IS NOT NULL AND c.`id_analisis` IS NOT NULL AND p.`id_orden` IS NULL;

SELECT 'fk_e6_detalle_usuario_catalogo' AS relacion,COUNT(*) AS huerfanos FROM `cotizacion_detalle` c LEFT JOIN `usuarios` p ON c.`id_usuario_precio_catalogo`=p.`id_usuario` WHERE c.`id_usuario_precio_catalogo` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_detalle_usuario_cobertura' AS relacion,COUNT(*) AS huerfanos FROM `cotizacion_detalle` c LEFT JOIN `usuarios` p ON c.`id_usuario_cobertura`=p.`id_usuario` WHERE c.`id_usuario_cobertura` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_e6_detalle_usuario_precio' AS relacion,COUNT(*) AS huerfanos FROM `cotizacion_detalle` c LEFT JOIN `usuarios` p ON c.`id_usuario_precio_utilizado`=p.`id_usuario` WHERE c.`id_usuario_precio_utilizado` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_derivaciones_destino' AS relacion,COUNT(*) AS huerfanos FROM `derivaciones` c LEFT JOIN `centros_derivantes` p ON c.`id_centro_destino`=p.`id_centro` WHERE c.`id_centro_destino` IS NOT NULL AND p.`id_centro` IS NULL;

SELECT 'fk_derivaciones_muestra' AS relacion,COUNT(*) AS huerfanos FROM `derivaciones` c LEFT JOIN `muestras` p ON c.`id_muestra`=p.`id_muestra` WHERE c.`id_muestra` IS NOT NULL AND p.`id_muestra` IS NULL;

SELECT 'fk_movimientos_insumo' AS relacion,COUNT(*) AS huerfanos FROM `movimientos_stock` c LEFT JOIN `insumos` p ON c.`id_insumo`=p.`id_insumo` WHERE c.`id_insumo` IS NOT NULL AND p.`id_insumo` IS NULL;

SELECT 'fk_movimientos_usuario' AS relacion,COUNT(*) AS huerfanos FROM `movimientos_stock` c LEFT JOIN `usuarios` p ON c.`id_usuario`=p.`id_usuario` WHERE c.`id_usuario` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_muestras_orden' AS relacion,COUNT(*) AS huerfanos FROM `muestras` c LEFT JOIN `ordenes` p ON c.`id_orden`=p.`id_orden` WHERE c.`id_orden` IS NOT NULL AND p.`id_orden` IS NULL;

SELECT 'fk_muestras_origen' AS relacion,COUNT(*) AS huerfanos FROM `muestras` c LEFT JOIN `centros_derivantes` p ON c.`id_centro`=p.`id_centro` WHERE c.`id_centro` IS NOT NULL AND p.`id_centro` IS NULL;

SELECT 'fk_muestras_usuario' AS relacion,COUNT(*) AS huerfanos FROM `muestras` c LEFT JOIN `usuarios` p ON c.`id_usuario_registro`=p.`id_usuario` WHERE c.`id_usuario_registro` IS NOT NULL AND p.`id_usuario` IS NULL;

SELECT 'fk_ma_estudio_pedido' AS relacion,COUNT(*) AS huerfanos FROM `muestra_analisis` c LEFT JOIN `orden_analisis` p ON c.`id_orden`=p.`id_orden` AND c.`id_analisis`=p.`id_analisis` WHERE c.`id_orden` IS NOT NULL AND c.`id_analisis` IS NOT NULL AND p.`id_orden` IS NULL;

SELECT 'fk_ma_muestra_orden' AS relacion,COUNT(*) AS huerfanos FROM `muestra_analisis` c LEFT JOIN `muestras` p ON c.`id_muestra`=p.`id_muestra` AND c.`id_orden`=p.`id_orden` WHERE c.`id_muestra` IS NOT NULL AND c.`id_orden` IS NOT NULL AND p.`id_muestra` IS NULL;

SELECT 'fk_ordenes_paciente' AS relacion,COUNT(*) AS huerfanos FROM `ordenes` c LEFT JOIN `pacientes` p ON c.`id_paciente`=p.`id_paciente` WHERE c.`id_paciente` IS NOT NULL AND p.`id_paciente` IS NULL;

SELECT 'fk_oa_analisis' AS relacion,COUNT(*) AS huerfanos FROM `orden_analisis` c LEFT JOIN `analisis` p ON c.`id_analisis`=p.`id_analisis` WHERE c.`id_analisis` IS NOT NULL AND p.`id_analisis` IS NULL;

SELECT 'fk_oa_orden' AS relacion,COUNT(*) AS huerfanos FROM `orden_analisis` c LEFT JOIN `ordenes` p ON c.`id_orden`=p.`id_orden` WHERE c.`id_orden` IS NOT NULL AND p.`id_orden` IS NULL;

SELECT 'fk_usuarios_rol' AS relacion,COUNT(*) AS huerfanos FROM `usuarios` c LEFT JOIN `roles` p ON c.`id_rol`=p.`id_rol` WHERE c.`id_rol` IS NOT NULL AND p.`id_rol` IS NULL;

SELECT i.id_insumo FROM insumos i LEFT JOIN (SELECT id_insumo,SUM(CASE WHEN tipo_movimiento='ENTRADA' THEN cantidad ELSE -cantidad END) saldo FROM movimientos_stock GROUP BY id_insumo) m ON m.id_insumo=i.id_insumo WHERE i.stock_actual<>COALESCE(m.saldo,0) OR i.stock_actual<0;

WITH detalle AS (
    SELECT d.id_cotizacion,COUNT(*) AS cantidad_detalles,
        SUM(CASE WHEN d.estado_cobertura='CUBIERTO' AND d.precio_efectivo_ars IS NOT NULL THEN d.precio_efectivo_ars ELSE 0 END) AS suma_cubiertos,
        SUM(CASE WHEN d.estado_cobertura='CUBIERTO' AND d.precio_efectivo_ars IS NULL THEN 1 ELSE 0 END) AS cubiertos_sin_precio,
        SUM(CASE WHEN d.estado_cobertura='COBERTURA SIN VERIFICAR' THEN 1 ELSE 0 END) AS sin_verificar,
        SUM(CASE WHEN d.id_orden<>c.id_orden OR oa.id_analisis IS NULL THEN 1 ELSE 0 END) AS estudios_ajenos,
        SUM(CASE WHEN c.id_obra_social IS NULL AND d.estado_cobertura<>'COBERTURA SIN VERIFICAR' THEN 1 ELSE 0 END) AS cobertura_sin_obra
    FROM laboratorio_la_2026.cotizacion_detalle d
    INNER JOIN laboratorio_la_2026.cotizaciones c ON c.id_cotizacion=d.id_cotizacion
    LEFT JOIN laboratorio_la_2026.orden_analisis oa ON oa.id_orden=c.id_orden AND oa.id_analisis=d.id_analisis
    GROUP BY d.id_cotizacion
), pedidos AS (
    SELECT id_orden,COUNT(*) AS cantidad_pedidos
    FROM laboratorio_la_2026.orden_analisis GROUP BY id_orden
), control AS (
    SELECT c.id_cotizacion,c.id_orden,c.id_obra_social,c.modo_calculo,c.importe_particular_ars,
        c.porcentaje_descuento,c.subtotal_cubierto,c.base_calculo_ars,c.importe_descuento,c.total_final,c.calculo_completo,
        c.estado_pago,c.metodo_pago_real,c.importe_pagado,c.fecha_pago,c.id_usuario_pago,c.fecha_emision,
        COALESCE(d.suma_cubiertos,0) AS subtotal_esperado,
        COALESCE(d.cantidad_detalles,0) AS cantidad_detalles,
        COALESCE(p.cantidad_pedidos,0) AS cantidad_pedidos,
        COALESCE(d.estudios_ajenos,0) AS estudios_ajenos,
        COALESCE(d.cobertura_sin_obra,0) AS cobertura_sin_obra,
        CASE
            WHEN c.modo_calculo='PARTICULAR' AND c.importe_particular_ars IS NOT NULL THEN 1
            WHEN c.modo_calculo='COBERTURA' AND c.id_obra_social IS NOT NULL
                AND COALESCE(d.cubiertos_sin_precio,0)=0 AND COALESCE(d.sin_verificar,0)=0 THEN 1
            ELSE 0 END AS completo_esperado,
        CASE
            WHEN c.modo_calculo='PARTICULAR' THEN c.importe_particular_ars
            WHEN c.modo_calculo='COBERTURA' AND c.id_obra_social IS NOT NULL
                AND COALESCE(d.cubiertos_sin_precio,0)=0 AND COALESCE(d.sin_verificar,0)=0 THEN COALESCE(d.suma_cubiertos,0)
            ELSE NULL END AS base_esperada
    FROM laboratorio_la_2026.cotizaciones c
    LEFT JOIN detalle d ON d.id_cotizacion=c.id_cotizacion
    LEFT JOIN pedidos p ON p.id_orden=c.id_orden
)
SELECT id_cotizacion,id_orden,modo_calculo,subtotal_cubierto,subtotal_esperado,
    base_calculo_ars,base_esperada,cantidad_detalles,cantidad_pedidos,
    estudios_ajenos,cobertura_sin_obra,calculo_completo,completo_esperado,
    'NO CONFIRMAR: revisar calculo, detalle o pago' AS resultado
FROM control
WHERE cantidad_detalles=0 OR cantidad_detalles<>cantidad_pedidos OR estudios_ajenos<>0 OR cobertura_sin_obra<>0
    OR subtotal_cubierto<>subtotal_esperado OR subtotal_esperado NOT BETWEEN 0 AND 9999999999.99
    OR porcentaje_descuento NOT BETWEEN 0 AND 100
    OR calculo_completo<>completo_esperado
    OR NOT (base_calculo_ars <=> base_esperada)
    OR (base_esperada IS NOT NULL AND base_esperada NOT BETWEEN 0 AND 9999999999.99)
    OR (calculo_completo=0 AND (importe_descuento IS NOT NULL OR total_final IS NOT NULL))
    OR (calculo_completo=1 AND (importe_descuento IS NULL OR total_final IS NULL
        OR importe_descuento<>ROUND(base_esperada*porcentaje_descuento/100,2)
        OR total_final<>base_esperada-ROUND(base_esperada*porcentaje_descuento/100,2)))
    OR (estado_pago IN ('NO PAGADO','PENDIENTE') AND (metodo_pago_real IS NOT NULL OR importe_pagado IS NOT NULL OR fecha_pago IS NOT NULL OR id_usuario_pago IS NOT NULL))
    OR (estado_pago='PAGADO' AND (calculo_completo<>1 OR total_final IS NULL OR total_final<=0
        OR metodo_pago_real IS NULL OR importe_pagado IS NULL OR importe_pagado<>total_final
        OR fecha_pago IS NULL OR fecha_pago<fecha_emision OR id_usuario_pago IS NULL))
ORDER BY id_cotizacion;
