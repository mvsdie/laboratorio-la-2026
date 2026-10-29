# Laboratorio L&A

Proyecto final de Programación con Base de Datos, segundo año de Analista de Sistemas. Aplicación de escritorio para centralizar la gestión administrativa de un laboratorio de análisis clínicos.

Sistema académico de demostración. Los datos personales, instituciones, coberturas y operaciones registradas son ficticios y se utilizan únicamente con fines ilustrativos.

## Tecnologías

- Visual Basic .NET y Windows Forms, .NET 10 para Windows.
- Visual Studio Community 2026 con Desarrollo de escritorio de .NET.
- MariaDB 11.4 y MySqlConnector 2.6.2. HeidiSQL es opcional.

Se utiliza como referencia de clase [Biblioteca2026](https://github.com/claualta/Biblioteca2026): formularios, módulos, eventos, Sub, Function, SQL parametrizado, Using y Try/Catch.

## Funciones

Inicio de sesión con roles ADMIN, RECEPCIONISTA y TECNICO; pacientes, análisis, centros, órdenes, muestras, derivaciones y cotización informativa. Las pantallas de insumos y movimientos mantienen el alcance actual. No se incluyen resultados clínicos, diagnósticos ni facturación fiscal.

ADMIN accede a la administración; RECEPCIONISTA realiza las operaciones de recepción autorizadas; TECNICO conserva las consultas y operaciones técnicas habilitadas. Los permisos se comprueban también en el código de las operaciones.

## Compilar y ejecutar

Abrir `src/LaboratorioLA2026.slnx` en Visual Studio. Los doce formularios conservan sus archivos Designer.vb y resx para editarlos con el diseñador.

Desde la carpeta del repositorio:

```powershell
dotnet restore '.\src\LaboratorioLA2026\LaboratorioLA2026.vbproj' --locked-mode
dotnet build '.\src\LaboratorioLA2026.slnx' -c Debug --no-restore
dotnet build '.\src\LaboratorioLA2026.slnx' -c Release --no-restore
```

`packages.lock.json` fija las dependencias para compilar y `packages.win-x64.lock.json` las de publicación Windows x64.

## Instalar en otra computadora

Seguir la [guía de instalación](docs/INSTALACION_NOTEBOOK.md). El orden es:

1. Instalar MariaDB local en 127.0.0.1:3306, con credenciales propias.
2. Crear el esquema con `instalacion/INSTALAR_BASE_LOCAL.ps1 -Paso Esquema`.
3. Configurar la conexión local mediante el asistente correspondiente al código o al ejecutable.
4. Ejecutar la aplicación con `--preparar-tres-usuarios` y elegir las contraseñas de admin, recepcion y tecnico.
5. Ejecutar el instalador con `-Paso Datos` y después `-Paso Verificar`.
6. Abrir la aplicación e ingresar con las claves elegidas.

No hay contraseña predeterminada. El archivo de conexión se genera localmente y queda excluido de Git. Para usar F5, ejecutar `src/CONFIGURAR_CONEXION_LOCAL.ps1`, recompilar y abrir la solución. No se necesita acceder a la PC de desarrollo.

La publicación Windows x64 incluye el runtime .NET; MariaDB se instala por separado. Para generarla:

```powershell
& '.\herramientas\PUBLICAR_WIN_X64.ps1'
```

La salida queda en `publicacion/win-x64`. Distribuir toda esa carpeta, sin incorporar la configuración privada.

## Datos y límites

La instalación utiliza 17 tablas e incluye 20 pacientes, 22 análisis, cinco centros, 21 órdenes, 20 muestras, diez derivaciones, 20 insumos, 30 movimientos y ocho cotizaciones. Los [recuentos completos](docs/RECUENTOS_DEMOSTRACION.json) permiten comprobar la carga.

El valor de **$2.400 por UB es una referencia de demostración de Santa Fe, marzo de 2026; no es un arancel oficial de Misiones**. Los códigos y UB del catálogo se conservan en `nbu/NBU_2026_VERIFICADO.csv`.

Las constancias son informativas: no constituyen factura fiscal ni acreditan pagos reales. Los comprobantes confirmados conservan sus datos históricos. No se asume cobertura cuando falta información; puede mostrarse TOTAL PENDIENTE. No se cobran automáticamente insumos ni se admiten pagos parciales.

La impresión requiere un controlador configurado en Windows, por ejemplo Microsoft Print to PDF. La instalación y la impresión deben comprobarse en el equipo de destino. El instalador se detiene si la base ya existe; no elimina bases ni reemplaza una instalación anterior.

## Carpetas

- `src`: solución, formularios, módulos y recursos.
- `instalacion`: esquema, datos y verificación de la base; configuración local.
- `herramientas`: publicación Windows x64.
- `docs`: instalación, recuentos y licencias.
- `nbu`: catálogo de referencia.

Consultar los [avisos y licencias](AVISOS_TERCEROS.md).
