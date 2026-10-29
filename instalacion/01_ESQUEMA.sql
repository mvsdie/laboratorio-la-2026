-- INSTALACIÓN NUEVA. No reejecutar sobre una base existente. Sin DROP ni ALTER.
CREATE DATABASE `laboratorio_la_2026` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `laboratorio_la_2026`;
SET NAMES utf8mb4 COLLATE utf8mb4_unicode_ci;

CREATE TABLE `centros_derivantes` (
  `id_centro` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `direccion` varchar(255) DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `uso` varchar(10) NOT NULL,
  `responsable` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_centro`),
  CONSTRAINT `ck_centros_uso` CHECK (`uso` in ('ORIGEN','DESTINO','AMBOS')),
  CONSTRAINT `ck_centros_activo` CHECK (`activo` in (0,1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `insumos` (
  `id_insumo` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `unidad_medida` varchar(20) NOT NULL,
  `stock_actual` int(11) NOT NULL DEFAULT 0,
  `stock_minimo` int(11) NOT NULL DEFAULT 0,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id_insumo`),
  CONSTRAINT `ck_insumos_stock` CHECK (`stock_actual` >= 0 and `stock_minimo` >= 0),
  CONSTRAINT `ck_insumos_activo` CHECK (`activo` in (0,1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `obras_sociales` (
  `id_obra_social` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id_obra_social`),
  UNIQUE KEY `nombre` (`nombre`),
  CONSTRAINT `ck_e6_obra_nombre` CHECK (trim(`nombre`) <> ''),
  CONSTRAINT `ck_e6_obra_activo` CHECK (`activo` in (0,1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `pacientes` (
  `id_paciente` int(11) NOT NULL AUTO_INCREMENT,
  `dni` varchar(20) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_paciente`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `roles` (
  `id_rol` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `ordenes` (
  `id_orden` int(11) NOT NULL AUTO_INCREMENT,
  `id_paciente` int(11) NOT NULL,
  `fecha` date NOT NULL,
  PRIMARY KEY (`id_orden`),
  KEY `fk_ordenes_paciente` (`id_paciente`),
  CONSTRAINT `fk_ordenes_paciente` FOREIGN KEY (`id_paciente`) REFERENCES `pacientes` (`id_paciente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_usuario` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `salt` varchar(100) NOT NULL,
  `nombre_completo` varchar(150) NOT NULL,
  `id_rol` int(11) NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `fecha_creacion` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `nombre_usuario` (`nombre_usuario`),
  KEY `fk_usuarios_rol` (`id_rol`),
  CONSTRAINT `fk_usuarios_rol` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`),
  CONSTRAINT `ck_usuarios_activo` CHECK (`activo` in (0,1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `analisis` (
  `id_analisis` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `codigo_nbu` varchar(10) DEFAULT NULL,
  `ub_nbu` decimal(10,2) DEFAULT NULL,
  `version_nbu` varchar(100) DEFAULT NULL,
  `material` varchar(60) DEFAULT NULL,
  `precio_referencia_ars` decimal(12,2) DEFAULT NULL,
  `fecha_precio` datetime DEFAULT NULL,
  `fuente_precio` varchar(255) DEFAULT NULL,
  `id_usuario_precio` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_analisis`),
  UNIQUE KEY `uq_analisis_codigo_nbu` (`codigo_nbu`),
  KEY `fk_e6_analisis_usuario_precio` (`id_usuario_precio`),
  CONSTRAINT `fk_e6_analisis_usuario_precio` FOREIGN KEY (`id_usuario_precio`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_analisis_activo` CHECK (`activo` in (0,1)),
  CONSTRAINT `ck_analisis_ub` CHECK (`ub_nbu` is null or `ub_nbu` >= 0),
  CONSTRAINT `ck_e6_precio_no_negativo` CHECK (`precio_referencia_ars` is null or `precio_referencia_ars` >= 0),
  CONSTRAINT `ck_e6_precio_referencia` CHECK (`precio_referencia_ars` is null or `fecha_precio` is not null and `fuente_precio` is not null and trim(`fuente_precio`) <> '' and `id_usuario_precio` is not null)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `configuracion_tarifas` (
  `id_configuracion` int(11) NOT NULL,
  `valor_ub_demo_ars` decimal(12,2) NOT NULL,
  `fecha_vigencia` date NOT NULL,
  `fecha_actualizacion` datetime NOT NULL,
  `fuente` varchar(255) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  PRIMARY KEY (`id_configuracion`),
  KEY `fk_e6_configuracion_usuario` (`id_usuario`),
  CONSTRAINT `fk_e6_configuracion_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_e6_configuracion_unica` CHECK (`id_configuracion` = 1),
  CONSTRAINT `ck_e6_valor_ub` CHECK (`valor_ub_demo_ars` > 0),
  CONSTRAINT `ck_e6_fuente_ub` CHECK (trim(`fuente`) <> '')
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `cotizaciones` (
  `id_cotizacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_orden` int(11) NOT NULL,
  `id_usuario_confirma` int(11) NOT NULL,
  `id_obra_social` int(11) DEFAULT NULL,
  `paciente_nombre` varchar(205) NOT NULL,
  `paciente_dni` varchar(20) NOT NULL,
  `obra_social_nombre` varchar(150) DEFAULT NULL,
  `fecha_orden` date NOT NULL,
  `fecha_emision` datetime NOT NULL DEFAULT current_timestamp(),
  `modo_calculo` varchar(10) NOT NULL,
  `importe_particular_ars` decimal(12,2) DEFAULT NULL,
  `motivo_acuerdo` varchar(255) DEFAULT NULL,
  `fecha_acuerdo` datetime DEFAULT NULL,
  `id_usuario_acuerdo` int(11) DEFAULT NULL,
  `porcentaje_descuento` decimal(5,2) NOT NULL,
  `subtotal_cubierto` decimal(12,2) NOT NULL,
  `base_calculo_ars` decimal(12,2) DEFAULT NULL,
  `importe_descuento` decimal(12,2) DEFAULT NULL,
  `total_final` decimal(12,2) DEFAULT NULL,
  `calculo_completo` tinyint(1) NOT NULL,
  `metodo_pago_previsto` varchar(25) DEFAULT NULL,
  `estado_pago` varchar(10) NOT NULL DEFAULT 'NO PAGADO',
  `metodo_pago_real` varchar(25) DEFAULT NULL,
  `importe_pagado` decimal(12,2) DEFAULT NULL,
  `fecha_pago` datetime DEFAULT NULL,
  `id_usuario_pago` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_cotizacion`),
  UNIQUE KEY `id_orden` (`id_orden`),
  UNIQUE KEY `uq_e6_cotizacion_orden` (`id_cotizacion`,`id_orden`),
  KEY `fk_e6_cotizacion_usuario` (`id_usuario_confirma`),
  KEY `fk_e6_cotizacion_obra` (`id_obra_social`),
  KEY `fk_e6_cotizacion_acuerdo` (`id_usuario_acuerdo`),
  KEY `fk_e6_cotizacion_pago` (`id_usuario_pago`),
  CONSTRAINT `fk_e6_cotizacion_acuerdo` FOREIGN KEY (`id_usuario_acuerdo`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_e6_cotizacion_obra` FOREIGN KEY (`id_obra_social`) REFERENCES `obras_sociales` (`id_obra_social`),
  CONSTRAINT `fk_e6_cotizacion_orden` FOREIGN KEY (`id_orden`) REFERENCES `ordenes` (`id_orden`),
  CONSTRAINT `fk_e6_cotizacion_pago` FOREIGN KEY (`id_usuario_pago`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_e6_cotizacion_usuario` FOREIGN KEY (`id_usuario_confirma`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_e6_cotizacion_modo` CHECK (`modo_calculo` in ('COBERTURA','PARTICULAR')),
  CONSTRAINT `ck_e6_cotizacion_acuerdo` CHECK (`importe_particular_ars` is null and `motivo_acuerdo` is null and `fecha_acuerdo` is null and `id_usuario_acuerdo` is null or `modo_calculo` = 'PARTICULAR' and `importe_particular_ars` is not null and `importe_particular_ars` >= 0 and `motivo_acuerdo` is not null and trim(`motivo_acuerdo`) <> '' and `fecha_acuerdo` is not null and `id_usuario_acuerdo` is not null),
  CONSTRAINT `ck_e6_cotizacion_porcentaje` CHECK (`porcentaje_descuento` between 0 and 100),
  CONSTRAINT `ck_e6_cotizacion_completa` CHECK (`calculo_completo` in (0,1)),
  CONSTRAINT `ck_e6_cotizacion_obra` CHECK (`id_obra_social` is null and `obra_social_nombre` is null or `id_obra_social` is not null and `obra_social_nombre` is not null and trim(`obra_social_nombre`) <> ''),
  CONSTRAINT `ck_e6_cotizacion_base` CHECK (`calculo_completo` = 0 and `base_calculo_ars` is null or `calculo_completo` = 1 and `base_calculo_ars` is not null and `base_calculo_ars` >= 0 and (`modo_calculo` = 'COBERTURA' and `id_obra_social` is not null and `base_calculo_ars` = `subtotal_cubierto` or `modo_calculo` = 'PARTICULAR' and `importe_particular_ars` is not null and `base_calculo_ars` = `importe_particular_ars`)),
  CONSTRAINT `ck_e6_cotizacion_importes` CHECK (`subtotal_cubierto` >= 0 and (`calculo_completo` = 0 and `importe_descuento` is null and `total_final` is null or `calculo_completo` = 1 and `importe_descuento` is not null and `total_final` is not null and `importe_descuento` = round(`base_calculo_ars` * `porcentaje_descuento` / 100,2) and `total_final` = `base_calculo_ars` - `importe_descuento` and `total_final` >= 0)),
  CONSTRAINT `ck_e6_pago_previsto` CHECK (`metodo_pago_previsto` is null or `metodo_pago_previsto` in ('EFECTIVO','TRANSFERENCIA','TARJETA DE DÉBITO','TARJETA DE CRÉDITO','OTRO')),
  CONSTRAINT `ck_e6_pago_real` CHECK (`metodo_pago_real` is null or `metodo_pago_real` in ('EFECTIVO','TRANSFERENCIA','TARJETA DE DÉBITO','TARJETA DE CRÉDITO','OTRO')),
  CONSTRAINT `ck_e6_estado_pago` CHECK (`estado_pago` in ('NO PAGADO','PENDIENTE','PAGADO')),
  CONSTRAINT `ck_e6_pago_registrado` CHECK (`estado_pago` in ('NO PAGADO','PENDIENTE') and `metodo_pago_real` is null and `importe_pagado` is null and `fecha_pago` is null and `id_usuario_pago` is null or `estado_pago` = 'PAGADO' and `calculo_completo` = 1 and `total_final` is not null and `total_final` > 0 and `metodo_pago_real` is not null and `importe_pagado` is not null and `importe_pagado` = `total_final` and `fecha_pago` is not null and `fecha_pago` >= `fecha_emision` and `id_usuario_pago` is not null)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `movimientos_stock` (
  `id_movimiento` int(11) NOT NULL AUTO_INCREMENT,
  `id_insumo` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `tipo_movimiento` varchar(20) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `motivo` varchar(255) NOT NULL,
  PRIMARY KEY (`id_movimiento`),
  KEY `fk_movimientos_insumo` (`id_insumo`),
  KEY `fk_movimientos_usuario` (`id_usuario`),
  CONSTRAINT `fk_movimientos_insumo` FOREIGN KEY (`id_insumo`) REFERENCES `insumos` (`id_insumo`),
  CONSTRAINT `fk_movimientos_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_movimientos_tipo` CHECK (`tipo_movimiento` in ('ENTRADA','SALIDA')),
  CONSTRAINT `ck_movimientos_cantidad` CHECK (`cantidad` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `muestras` (
  `id_muestra` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(30) NOT NULL,
  `id_orden` int(11) NOT NULL,
  `id_centro` int(11) DEFAULT NULL,
  `id_usuario_registro` int(11) NOT NULL,
  `tipo_muestra` varchar(60) NOT NULL,
  `fecha_recepcion` datetime NOT NULL,
  `estado` varchar(30) NOT NULL DEFAULT 'RECIBIDA',
  `documentacion_completa` tinyint(1) NOT NULL DEFAULT 0,
  `observaciones` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_muestra`),
  UNIQUE KEY `codigo` (`codigo`),
  UNIQUE KEY `uq_muestra_orden` (`id_muestra`,`id_orden`),
  KEY `fk_muestras_orden` (`id_orden`),
  KEY `fk_muestras_origen` (`id_centro`),
  KEY `fk_muestras_usuario` (`id_usuario_registro`),
  CONSTRAINT `fk_muestras_orden` FOREIGN KEY (`id_orden`) REFERENCES `ordenes` (`id_orden`),
  CONSTRAINT `fk_muestras_origen` FOREIGN KEY (`id_centro`) REFERENCES `centros_derivantes` (`id_centro`),
  CONSTRAINT `fk_muestras_usuario` FOREIGN KEY (`id_usuario_registro`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_muestras_estado` CHECK (`estado` in ('RECIBIDA','EN PROCESO','CERRADA')),
  CONSTRAINT `ck_muestras_documentacion` CHECK (`documentacion_completa` in (0,1))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `coberturas_analisis` (
  `id_obra_social` int(11) NOT NULL,
  `id_analisis` int(11) NOT NULL,
  `estado_cobertura` varchar(30) NOT NULL DEFAULT 'COBERTURA SIN VERIFICAR',
  `fecha_cobertura` datetime DEFAULT NULL,
  `referencia_cobertura` varchar(255) DEFAULT NULL,
  `id_usuario_cobertura` int(11) DEFAULT NULL,
  `precio_acordado_ars` decimal(12,2) DEFAULT NULL,
  `fecha_precio_acordado` datetime DEFAULT NULL,
  `fuente_precio_acordado` varchar(255) DEFAULT NULL,
  `id_usuario_tarifa` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_obra_social`,`id_analisis`),
  KEY `fk_e6_cobertura_analisis` (`id_analisis`),
  KEY `fk_e6_cobertura_usuario` (`id_usuario_cobertura`),
  KEY `fk_e6_tarifa_usuario` (`id_usuario_tarifa`),
  CONSTRAINT `fk_e6_cobertura_analisis` FOREIGN KEY (`id_analisis`) REFERENCES `analisis` (`id_analisis`),
  CONSTRAINT `fk_e6_cobertura_obra` FOREIGN KEY (`id_obra_social`) REFERENCES `obras_sociales` (`id_obra_social`),
  CONSTRAINT `fk_e6_cobertura_usuario` FOREIGN KEY (`id_usuario_cobertura`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_e6_tarifa_usuario` FOREIGN KEY (`id_usuario_tarifa`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_e6_cobertura_estado` CHECK (`estado_cobertura` in ('CUBIERTO','SIN COBERTURA','COBERTURA SIN VERIFICAR')),
  CONSTRAINT `ck_e6_cobertura_referencia` CHECK (`estado_cobertura` = 'COBERTURA SIN VERIFICAR' or `fecha_cobertura` is not null and `referencia_cobertura` is not null and trim(`referencia_cobertura`) <> '' and `id_usuario_cobertura` is not null),
  CONSTRAINT `ck_e6_cobertura_precio` CHECK (`precio_acordado_ars` is null or `precio_acordado_ars` >= 0),
  CONSTRAINT `ck_e6_tarifa_referencia` CHECK (`precio_acordado_ars` is null or `fecha_precio_acordado` is not null and `fuente_precio_acordado` is not null and trim(`fuente_precio_acordado`) <> '' and `id_usuario_tarifa` is not null)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `derivaciones` (
  `id_derivacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_muestra` int(11) NOT NULL,
  `id_centro_destino` int(11) NOT NULL,
  `fecha_envio` datetime NOT NULL,
  `fecha_retorno` datetime DEFAULT NULL,
  PRIMARY KEY (`id_derivacion`),
  UNIQUE KEY `id_muestra` (`id_muestra`),
  KEY `fk_derivaciones_destino` (`id_centro_destino`),
  CONSTRAINT `fk_derivaciones_destino` FOREIGN KEY (`id_centro_destino`) REFERENCES `centros_derivantes` (`id_centro`),
  CONSTRAINT `fk_derivaciones_muestra` FOREIGN KEY (`id_muestra`) REFERENCES `muestras` (`id_muestra`),
  CONSTRAINT `ck_derivaciones_fechas` CHECK (`fecha_retorno` is null or `fecha_retorno` >= `fecha_envio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `orden_analisis` (
  `id_orden` int(11) NOT NULL,
  `id_analisis` int(11) NOT NULL,
  PRIMARY KEY (`id_orden`,`id_analisis`),
  KEY `fk_oa_analisis` (`id_analisis`),
  CONSTRAINT `fk_oa_analisis` FOREIGN KEY (`id_analisis`) REFERENCES `analisis` (`id_analisis`),
  CONSTRAINT `fk_oa_orden` FOREIGN KEY (`id_orden`) REFERENCES `ordenes` (`id_orden`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `cotizacion_detalle` (
  `id_cotizacion` int(11) NOT NULL,
  `id_orden` int(11) NOT NULL,
  `id_analisis` int(11) NOT NULL,
  `codigo_nbu` varchar(10) DEFAULT NULL,
  `nombre_analisis` varchar(100) NOT NULL,
  `ub_nbu` decimal(10,2) DEFAULT NULL,
  `version_nbu` varchar(100) DEFAULT NULL,
  `precio_catalogo_ars` decimal(12,2) DEFAULT NULL,
  `origen_precio_catalogo` varchar(10) NOT NULL,
  `valor_ub_demo_ars` decimal(12,2) DEFAULT NULL,
  `fecha_precio_catalogo` datetime DEFAULT NULL,
  `fuente_precio_catalogo` varchar(255) DEFAULT NULL,
  `id_usuario_precio_catalogo` int(11) DEFAULT NULL,
  `precio_acordado_ars` decimal(12,2) DEFAULT NULL,
  `precio_efectivo_ars` decimal(12,2) DEFAULT NULL,
  `origen_precio` varchar(10) NOT NULL,
  `fecha_precio_utilizado` datetime DEFAULT NULL,
  `fuente_precio_utilizado` varchar(255) DEFAULT NULL,
  `id_usuario_precio_utilizado` int(11) DEFAULT NULL,
  `estado_cobertura` varchar(30) NOT NULL,
  `fecha_cobertura` datetime DEFAULT NULL,
  `referencia_cobertura` varchar(255) DEFAULT NULL,
  `id_usuario_cobertura` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_cotizacion`,`id_analisis`),
  KEY `fk_e6_detalle_cotizacion_orden` (`id_cotizacion`,`id_orden`),
  KEY `fk_e6_detalle_orden_analisis` (`id_orden`,`id_analisis`),
  KEY `fk_e6_detalle_usuario_precio` (`id_usuario_precio_utilizado`),
  KEY `fk_e6_detalle_usuario_catalogo` (`id_usuario_precio_catalogo`),
  KEY `fk_e6_detalle_usuario_cobertura` (`id_usuario_cobertura`),
  CONSTRAINT `fk_e6_detalle_cotizacion_orden` FOREIGN KEY (`id_cotizacion`, `id_orden`) REFERENCES `cotizaciones` (`id_cotizacion`, `id_orden`),
  CONSTRAINT `fk_e6_detalle_orden_analisis` FOREIGN KEY (`id_orden`, `id_analisis`) REFERENCES `orden_analisis` (`id_orden`, `id_analisis`),
  CONSTRAINT `fk_e6_detalle_usuario_catalogo` FOREIGN KEY (`id_usuario_precio_catalogo`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_e6_detalle_usuario_cobertura` FOREIGN KEY (`id_usuario_cobertura`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `fk_e6_detalle_usuario_precio` FOREIGN KEY (`id_usuario_precio_utilizado`) REFERENCES `usuarios` (`id_usuario`),
  CONSTRAINT `ck_e6_detalle_precios` CHECK ((`precio_catalogo_ars` is null or `precio_catalogo_ars` >= 0) and (`precio_acordado_ars` is null or `precio_acordado_ars` >= 0) and (`precio_efectivo_ars` is null or `precio_efectivo_ars` >= 0)),
  CONSTRAINT `ck_e6_detalle_precio_elegido` CHECK (`origen_precio` = 'ACORDADO' and `precio_acordado_ars` is not null and `precio_efectivo_ars` is not null and `precio_efectivo_ars` = `precio_acordado_ars` or `origen_precio` = 'CATALOGO' and `precio_acordado_ars` is null and `precio_catalogo_ars` is not null and `precio_efectivo_ars` is not null and `precio_efectivo_ars` = `precio_catalogo_ars` or `origen_precio` = 'PENDIENTE' and `precio_acordado_ars` is null and `precio_catalogo_ars` is null and `precio_efectivo_ars` is null),
  CONSTRAINT `ck_e6_detalle_catalogo` CHECK (`origen_precio_catalogo` = 'UB_DEMO' and `codigo_nbu` is not null and `version_nbu` is not null and `ub_nbu` is not null and `ub_nbu` >= 0 and `valor_ub_demo_ars` is not null and `valor_ub_demo_ars` > 0 and `precio_catalogo_ars` is not null and `precio_catalogo_ars` = round(`ub_nbu` * `valor_ub_demo_ars`,2) or `origen_precio_catalogo` = 'MANUAL' and `valor_ub_demo_ars` is null and `precio_catalogo_ars` is not null or `origen_precio_catalogo` = 'PENDIENTE' and `valor_ub_demo_ars` is null and `precio_catalogo_ars` is null),
  CONSTRAINT `ck_e6_detalle_fuente_catalogo` CHECK (`precio_catalogo_ars` is null and `fecha_precio_catalogo` is null and `fuente_precio_catalogo` is null and `id_usuario_precio_catalogo` is null or `precio_catalogo_ars` is not null and `fecha_precio_catalogo` is not null and `fuente_precio_catalogo` is not null and trim(`fuente_precio_catalogo`) <> '' and `id_usuario_precio_catalogo` is not null),
  CONSTRAINT `ck_e6_detalle_fuente` CHECK (`precio_efectivo_ars` is null and `fecha_precio_utilizado` is null and `fuente_precio_utilizado` is null and `id_usuario_precio_utilizado` is null or `precio_efectivo_ars` is not null and `fecha_precio_utilizado` is not null and `fuente_precio_utilizado` is not null and trim(`fuente_precio_utilizado`) <> '' and `id_usuario_precio_utilizado` is not null),
  CONSTRAINT `ck_e6_detalle_ub` CHECK (`ub_nbu` is null or `ub_nbu` >= 0),
  CONSTRAINT `ck_e6_detalle_cobertura` CHECK (`estado_cobertura` in ('CUBIERTO','SIN COBERTURA','COBERTURA SIN VERIFICAR')),
  CONSTRAINT `ck_e6_detalle_referencia` CHECK (`estado_cobertura` = 'COBERTURA SIN VERIFICAR' or `fecha_cobertura` is not null and `referencia_cobertura` is not null and trim(`referencia_cobertura`) <> '' and `id_usuario_cobertura` is not null)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

CREATE TABLE `muestra_analisis` (
  `id_muestra` int(11) NOT NULL,
  `id_orden` int(11) NOT NULL,
  `id_analisis` int(11) NOT NULL,
  PRIMARY KEY (`id_muestra`,`id_analisis`),
  KEY `fk_ma_muestra_orden` (`id_muestra`,`id_orden`),
  KEY `fk_ma_estudio_pedido` (`id_orden`,`id_analisis`),
  CONSTRAINT `fk_ma_estudio_pedido` FOREIGN KEY (`id_orden`, `id_analisis`) REFERENCES `orden_analisis` (`id_orden`, `id_analisis`),
  CONSTRAINT `fk_ma_muestra_orden` FOREIGN KEY (`id_muestra`, `id_orden`) REFERENCES `muestras` (`id_muestra`, `id_orden`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

