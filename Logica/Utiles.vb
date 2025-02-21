Imports Entidades.Temporales
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Control
Imports Datos.ConexionSqlite
Imports Datos.Conexion
Public Class Utiles

    'Public Shared Sub guardarConf(ByVal BLNomCon As String, ByVal BLServid As String, ByVal BLUsuari As String, ByVal BLPasswo As String, ByVal BLNomBas As String, ByVal BENomCon As String, ByVal BEServid As String, ByVal BEUsuari As String, ByVal BEPasswo As String, ByVal BENomBas As String)
    '    Dim Arch As New IO.StreamWriter(rutaGeneral + archivoConf, False, System.Text.Encoding.Unicode)
    '    'codigo de nueva linea-> vbNewLine
    '    Arch.Write("!" +
    '               "#" + BLNomCon +
    '               "#" + BLServid +
    '               "#" + BLUsuari +
    '               "#" + BLPasswo +
    '               "#" + BLNomBas +
    '               "!" +
    '               "#" + BENomCon +
    '               "#" + BEServid +
    '               "#" + BEUsuari +
    '               "#" + BEPasswo +
    '               "#" + BENomBas +
    '               "!"
    '               )
    '    Arch.Close()
    '    cifrar(rutaGeneral + archivoConf, True)
    'End Sub

    Public Shared Sub guardarConfSqlite(ByVal BLNomCon As String, ByVal BLServid As String, ByVal BLUsuari As String, ByVal BLPasswo As String, ByVal BLNomBas As String, ByVal BENomCon As String, ByVal BEServid As String, ByVal BEUsuari As String, ByVal BEPasswo As String, ByVal BENomBas As String)
        Dim q As String = String.Empty
        q = "UPDATE SqliteConfiguracion SET Valor='" + BLNomCon + "' WHERE Clave='BLNomCon'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BLServid + "' WHERE Clave='BLServid'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BLUsuari + "' WHERE Clave='BLUsuari'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BLPasswo + "' WHERE Clave='BLPasswo'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BLNomBas + "' WHERE Clave='BLNomBas'"
        ejecutarSqlite(q, tipoProceso.NonQuery)

        q = "UPDATE SqliteConfiguracion SET Valor='" + BENomCon + "' WHERE Clave='BENomCon'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BEServid + "' WHERE Clave='BEServid'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BEUsuari + "' WHERE Clave='BEUsuari'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BEPasswo + "' WHERE Clave='BEPasswo'"
        ejecutarSqlite(q, tipoProceso.NonQuery)
        q = "UPDATE SqliteConfiguracion SET Valor='" + BENomBas + "' WHERE Clave='BENomBas'"
        ejecutarSqlite(q, tipoProceso.NonQuery)

    End Sub

    Public Shared Sub cifrar(ByVal archivoOrigen As String, ByVal flag As Boolean) 'true = cifrar ||| false = descifrar
        Try
            Dim archivoTemp As String = rutaGeneral + rutaTemp + "Temp.txt" 'archivoTemp
            Dim temp As New IO.StreamWriter(archivoTemp, False, System.Text.Encoding.Unicode)
            Dim leer As New IO.StreamReader(archivoOrigen, System.Text.Encoding.Unicode)
            While Not leer.EndOfStream 'leer.Peek() > -1 and leer.EndOfStream
                temp.Write(Chr(leer.Read() + If(flag, llave, llave * -1)))
            End While
            temp.Close()
            leer.Close()
            File.Delete(archivoOrigen)
            My.Computer.FileSystem.CopyFile(archivoTemp, archivoOrigen,
            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            File.Delete(archivoTemp)
        Catch
        End Try
    End Sub

    Public Shared Sub cargarMenus()
        'PARA CREAR UN NUEVO MENU SE DEBEN DAR LOS SIGUIENTES PASOS
        'AGREGARMENU PASO 1: AGREGAR EL NOMBRE DEL MENU AL FINAL DE ESTE DICCIONARIO SIGUIENDO EL MISMO FORMATO
        modulosPermitidos.Add("mnu1_Mantenimiento", True)
        modulosPermitidos.Add("mnu1_1_ConfigBases", True)
        modulosPermitidos.Add("mnu1_2_MantenimientoUsuarios", False)
        modulosPermitidos.Add("mnu2_RecursosHumanos", False)
        'modulosPermitidos.Add("mnu2_1_Asistencia", False)
        'modulosPermitidos.Add("mnu2_1_1_ReporteAsistencia", False)
        'modulosPermitidos.Add("mnu2_1_2_UltimoDiaAsistencia", False)
        'modulosPermitidos.Add("mnu2_1_3_ReporteFaltas", False)
        'modulosPermitidos.Add("mnu2_1_4_ReporteAsistenciaChronos", False)
        modulosPermitidos.Add("mnu3_Fitosanidad", False)
        modulosPermitidos.Add("mnu3_1_Reportes", False)
        modulosPermitidos.Add("mnu1_3_ActualizacionSistema", False)
        'modulosPermitidos.Add("mnu2_2_GestioEstandares", False)
        'modulosPermitidos.Add("mnu2_2_1_ValidarEstandares", False)
        modulosPermitidos.Add("mnu4_Supervision", False)
        modulosPermitidos.Add("mnu4_1_Movimientos", False)
        modulosPermitidos.Add("mnu5_Costos", False)
        modulosPermitidos.Add("mnu5_1_Procesos", False)
        modulosPermitidos.Add("mnu5_1_1_CierreDiario", False)
        modulosPermitidos.Add("mnu5_2_Tablas", False)
        modulosPermitidos.Add("mnu5_2_1_Reglas", False)
        modulosPermitidos.Add("mnu6_Packing", False)
        modulosPermitidos.Add("mnu6_1_Reportes", False)
        modulosPermitidos.Add("mnu6_1_1_FrutaProcesada", False)
        modulosPermitidos.Add("mnu7_Maquinaria", False)
        modulosPermitidos.Add("mnu7_1_Reportes", False)
        modulosPermitidos.Add("mnu7_1_1_ResumenUsoImplementoMaquinaLabor", False)
        modulosPermitidos.Add("mnu7_1_2_HorasMaquinariasXLote", False) '2023-04-20'
        modulosPermitidos.Add("mnu8_Almacenes", False)
        modulosPermitidos.Add("mnu8_1_Reportes", False)
        modulosPermitidos.Add("mnu8_1_1_Ingresos", False)
        modulosPermitidos.Add("mnu9_Produccion", False)
        modulosPermitidos.Add("mnu9_1_Reportes", False)
        modulosPermitidos.Add("mnu9_1_1_CosechaCampoConsolidado", False)
        modulosPermitidos.Add("mnu9_2_Movimientos", False)
        modulosPermitidos.Add("mnu9_2_1_ActualizarDatosPallets", False)
        'modulosPermitidos.Add("mnu2_3_CostosPersonal", False)
        'modulosPermitidos.Add("mnu2_3_1_DetalleHorasPersonaActividadConsumidor", False)
        modulosPermitidos.Add("mnu4_2_Reportes", False)
        modulosPermitidos.Add("mnu4_2_1_FormatoTransferencia", False)
        modulosPermitidos.Add("mnu4_2_2_ResumenTareos", False)
        modulosPermitidos.Add("mnu4_1_1_Tareos", False)
        modulosPermitidos.Add("mnu6_2_Movimientos", False)
        modulosPermitidos.Add("mnu6_2_1_GenerarCodigosPacking", False)
        modulosPermitidos.Add("mnu6_2_2_LecturaEficiencias", False)
        modulosPermitidos.Add("mnu9_1_2_Costeo", False)
        modulosPermitidos.Add("mnu6_2_3_TareosPacking", False)
        modulosPermitidos.Add("mnu6_1_2_EficienciasEnVivo", False)
        modulosPermitidos.Add("mnu5_3_Reportes", False)
        modulosPermitidos.Add("mnu5_3_1_GestionCostosDetallado", False)
        modulosPermitidos.Add("mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen", False)
        modulosPermitidos.Add("mnu6_1_4_EficienciasPersonal", False)
        modulosPermitidos.Add("mnu5_1_2_AsignacionCostosModulosProcesados", False)
        'modulosPermitidos.Add("mnu2_4_CatalogoPersonal", False)
        modulosPermitidos.Add("mnu6_2_4_DistribuirHorasXConsumidorPacking", False)
        modulosPermitidos.Add("mnu3_2_Movimientos", False)
        modulosPermitidos.Add("mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario", False)
        modulosPermitidos.Add("mnu10_Contabilidad", False)
        modulosPermitidos.Add("mnu10_1_Movimientos", False)
        modulosPermitidos.Add("mnu10_2_Reportes", False)
        modulosPermitidos.Add("mnu10_2_1_BalanceComprobacion", False)
        modulosPermitidos.Add("mnu6_1_5_AlcanceEstandares", False) '31-10-2020
        modulosPermitidos.Add("mnu1_4_frmMantenimiento_AbrirCerrarDias", False) '13-11-2020
        'modulosPermitidos.Add("mnu2_5_Movimientos", False) '20-11-2020
        'modulosPermitidos.Add("mnu2_5_1_RegistrarAltasMasivas", False) '20-11-2020
        modulosPermitidos.Add("mnu6_1_6_AlcanceEstandares", False) '23-11-2020
        'modulosPermitidos.Add("mnu2_5_2_DefinicionHorarios", False) '28-11-2020
        modulosPermitidos.Add("mnu5_3_2_ReporteServicios", False) '04-12-2020
        modulosPermitidos.Add("mnu8_1_2_RequerimientosInternos", False) '2020-12-31
        modulosPermitidos.Add("mnu4_2_3_DetalleDiarioXSupuervisorGMO", False) '2020-12-31
        modulosPermitidos.Add("mnu10_1_1_CierreParrones", False) '2021-01-05
        modulosPermitidos.Add("mnu4_2_4_ControlHorasDiario", False) '2021-01-14
        modulosPermitidos.Add("mnu9_1_3_TablaCampanasCultivos", False) '2021-01-18
        modulosPermitidos.Add("mnu5_3_3_HorasMaquinaXActividad", False) '2021-01-19
        modulosPermitidos.Add("mnu4_2_5_ContrasteAsistencias", False) '2021-01-26
        modulosPermitidos.Add("mnu11_Logistica", False) '2021-01-28
        modulosPermitidos.Add("mnu11_1_Indices", False) '2021-01-28
        modulosPermitidos.Add("mnu11_1_1_Vehiculos", False) '2021-01-28
        modulosPermitidos.Add("mnu5_1_3_ActualizarDataCosteo", False) '2021-02-02
        modulosPermitidos.Add("mnu11_1_2_Conductores", False) '2021-02-09
        modulosPermitidos.Add("mnu11_1_3_CiudadesParaderos", False) '2021-02-09
        modulosPermitidos.Add("mnu11_1_4_Rutas", False) '2021-02-24
        modulosPermitidos.Add("mnu11_2_Movimientos", False) '2021-03-11
        modulosPermitidos.Add("mnu11_2_1_ServiciosTransporte", False) '2021-03-11
        '====================Modulos actuales 2023=============================
        modulosPermitidos.Add("mnu11_3_1_TransportePersonalXConsumidor", False)
        modulosPermitidos.Add("mnu2_2_16_CorrespondenciaVacacional", False) '2023-04-05
        '===========================fin 2023==================================

        modulosPermitidos.Add("mnu2_1_Indices", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_Reportes", False) '2021-03-29
        modulosPermitidos.Add("mnu2_3_Movimientos", False) '2021-03-29

        modulosPermitidos.Add("mnu2_1_1_DefinicionDeHorarios", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_1_ReporteAsistencia", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_2_UltimoDiaAsistencia", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_3_ReporteFaltas", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_4_ReporteAsistenciaChronos", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_5_ValidarEstandares", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_6_DetalleDeHorasPersonaPorActividadYConsumidor", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_7_CatalogoDePersonal", False) '2021-03-29
        modulosPermitidos.Add("mnu2_3_1_RegistrarAltasMasivas", False) '2021-03-29

        modulosPermitidos.Add("mnu2_2_8_ReporteDeAusentismo", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_9_ReporteDeCeses", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_10_ReporteDeConceptosXLiquidaciones", False) '2021-03-29
        modulosPermitidos.Add("mnu2_2_11_AntecedentesInternos", False) '2021-03-30


        modulosPermitidos.Add("mnu10_2_2_CostosAcumulados", False) ' 2021-05-03
        modulosPermitidos.Add("mnu2_2_12_CalculoBonos", False) ' 2021-05-05
        modulosPermitidos.Add("mnu2_3_2_ConfiguracionGruposLabores", False) ' 2021-05-06
        modulosPermitidos.Add("mnu2_3_3_ConfiguracionBonos", False) ' 2021-05-11
        modulosPermitidos.Add("mnu3_1_1_ReporteAplicaciones", False) '2021-07-29
        modulosPermitidos.Add("mnu3_1_2_ReporteEvaluaciones", False) '2021-07-29
        modulosPermitidos.Add("mnu6_2_5_FusionarCajasBifurcadas", False) '2021-08-02
        modulosPermitidos.Add("mnu9_1_4_PalletsDespachados", False) '2021-08-11
        modulosPermitidos.Add("mnu12_Exportaciones", False)
        modulosPermitidos.Add("mnu12_1_Reportes", False)
        modulosPermitidos.Add("mnu12_1_1_PackingList", False)
        modulosPermitidos.Add("mnu13_Presupuestos", False) '2021-08-19
        modulosPermitidos.Add("mnu13_1_Reportes", False)
        modulosPermitidos.Add("mnu13_1_1_ControlPresupuestal", False)
        modulosPermitidos.Add("mnu9_1_5_CosechaYProduccion", False)
        modulosPermitidos.Add("mnu2_3_4_AsistenciasGmo", False)
        modulosPermitidos.Add("mnu10_2_3_FacturacionCobranzasExportacion", False)
        modulosPermitidos.Add("mnu10_2_4_ReporteG", False)
        modulosPermitidos.Add("mnu10_1_2_Maquinaria", False)
        modulosPermitidos.Add("mnu10_1_2_1_ActualizarConfiguraciones", False)
        modulosPermitidos.Add("mnu10_1_2_2_GenerarAsientosContables", False)
        modulosPermitidos.Add("mnu10_2_5_ConsumosDeAlmacenVsContabilidad", False)
        modulosPermitidos.Add("mnu10_2_6_IngresoBancosDetalladoFactura", False)
        modulosPermitidos.Add("mnu6_2_6_HorasADistribuir", False)
        modulosPermitidos.Add("mnu11_2_2_GenerarPedidosServicioTransporte", False)
        modulosPermitidos.Add("mnu2_2_13_ResumenPlanillas", False)
        modulosPermitidos.Add("mnu3_2_1_CrearProgramasSemanales", False)
        modulosPermitidos.Add("mnu8_2_Movimientos", False)
        modulosPermitidos.Add("mnu8_2_1_CargarPedidosDeCompra", False)
        modulosPermitidos.Add("mnu8_1_3_PedidosDeCompra", False)
        modulosPermitidos.Add("mnu4_1_2_DistribucionHorasXGaritas", False)
        modulosPermitidos.Add("mnu2_2_14_PlanillaAsistencia", False)
        modulosPermitidos.Add("mnu13_1_2_ResumenPresupuestoGrupoSubgrupo", False)
        modulosPermitidos.Add("mnu13_1_3_PresupuestoGeneral", False)
        modulosPermitidos.Add("mnu13_1_4_SeguimientoPresupuestal", False)
        modulosPermitidos.Add("mnu13_1_5_PresupuestoX", False)
        modulosPermitidos.Add("mnu6_1_7_SeguimientoPlanComercial", False)
        modulosPermitidos.Add("mnu6_1_8_StockPallets", False)
        modulosPermitidos.Add("mnu6_2_7_ManteniminetoPlanesComerciales", False)
        modulosPermitidos.Add("mnu5_3_3_AnalisisDeTareos", False)
        modulosPermitidos.Add("mnu6_1_9_ConsultarCodigos", False)
        modulosPermitidos.Add("mnu2_2_15_IngresosPersonal", False)
        modulosPermitidos.Add("mnu2_2_18_SupervisionSSO", False)

        'Menu actuales 2023-03-30'
        modulosPermitidos.Add("mnu5_3_4_GestionDeCostosDetalladoIndirecto", False) 'Menu de costos Detallado Indirectos
        modulosPermitidos.Add("mnu2_2_17_ControlIntermitencia", False) 'Menu de Control Intermitencia RRHH
        modulosPermitidos.Add("mnu4_1_3_Estandares", False) 'Menu de Estandares
        modulosPermitidos.Add("mnu2_2_19_VacionesGeneradas", False) '2023-09-15
        modulosPermitidos.Add("mnu7_1_3_ListadoPedidosMaquinaria", False) '2023-09-26
        modulosPermitidos.Add("mnu8_2_2_ParteDeAcopioDeCampo", False) '2023-10-13
        modulosPermitidos.Add("mnu11_3_2_RefrigeriosDelPersonal", False) '2023-10-30
        modulosPermitidos.Add("mnu2_2_21_SincronizarBoletas", False) '2023-10-30
        modulosPermitidos.Add("mnu2_3_5_ObservacionesMarcacion", False) '2023-10-30
        modulosPermitidos.Add("mnu2_2_22_Amonestaciones", False) '2023-12-19
        modulosPermitidos.Add("mnu2_2_23_ControlReclutamiento", False) '2024-01-15
        modulosPermitidos.Add("mnu2_2_24_ControlPersonal", False) '2024-01-18
        modulosPermitidos.Add("mnu2_2_25_InformeDirectorio", False) '2024-01-22
        modulosPermitidos.Add("mnu2_3_6_ProgramacionVacaciones", False) '2024-01-30
        modulosPermitidos.Add("mnu2_2_26_RenovacionContratos", False) '2024-01-15
        modulosPermitidos.Add("mnu2_2_27_ImpresionFormatos", False) '2024-02-15
        modulosPermitidos.Add("mnu2_2_28_FormatoBoletas", False) '2024-04-12
        modulosPermitidos.Add("mnu4_2_6_Rendimientos", False) '2024-02-17
        modulosPermitidos.Add("mnu10_2_7_DesviacionBC", False)
        modulosPermitidos.Add("mnu2_3_7_DistribucionHoras", False) '2024-01-30
        modulosPermitidos.Add("mnu2_2_20_GeneradordeCodigodeBarras", False) '2023-10-13
        modulosPermitidos.Add("mnu2_2_29_GenerarFotocheks", False) '2024-04-12
        modulosPermitidos.Add("mnu2_2_30_ReporteMarcaciones", False) '2024-04-12

        modulosPermitidos.Add("mnu2_3_8_CalculoConceptosRemunerativos", False) '2024-05-07
        modulosPermitidos.Add("mnu2_2_31_ComparativaUltimosMovimientosPlanilla", False) '2024-07-11
        modulosPermitidos.Add("mnu2_2_32_CheckListCalculoPlanilla", False) '2024-07-16
        modulosPermitidos.Add("mnu2_2_33_ReporteDelCtaCteDelPersonal", False) '2024-09-13
        ' HATCH 21-11-2024
        modulosPermitidos.Add("mnu1_5_PrivilegiosUsuariosFormularios", False)
        modulosPermitidos.Add("mnu1_6_ConfiguracionLongitudCodigoGeneral", False)
        ' HATCH 10-12-2024
        modulosPermitidos.Add("mnu2_3_9_ConvertirTareosAsistencias", False)



        nTotalModulos = modulosPermitidos.Count
        'AGREGARMENU PASO 2: AGREGAR EL CONTROL (MENU ITEM) EN LA INTERFAZ (MDI) Y PONERLE EL MISMO NOMBRE QUE SE ACABA DE AGREGAR AQUI
    End Sub

    Public Shared Async Sub manejarEtiquetaAsync(etiqueta As Windows.Forms.Label, filas As Integer)
        If filas < 0 Then
            etiqueta.Text = "Consultando..."
            etiqueta.ForeColor = Await Task.Run(Function() rojoAmarath)
        ElseIf filas = 0 Then
            aplicarTema(etiqueta)
            etiqueta.Text = "Listo!"
        Else
            aplicarTema(etiqueta)
            etiqueta.Text = "Registros: " + filas.ToString
        End If
    End Sub

    Public Shared Async Sub cambiarEtiquetaAsync(etiqueta As Windows.Forms.Label)
        'Cambiar estilo de fuente
        'Dim newFont As New Font("Consolas", 10, FontStyle.Bold Or FontStyle.Italic) ' New Font(etiqueta.Font, FontStyle.Italic)
        'etiqueta.Font = newFont
        etiqueta.Text = "Consultando..."
        'etiqueta.BackColor = Await task.Run(Function() Color.FromArgb(255, 80, 80))
        'etiqueta.ForeColor = Await task.Run(Function() Color.FromArgb(255, 255, 255))
        'etiqueta.BackColor = Await task.Run(Function() temaClaroLili)
        etiqueta.ForeColor = Await Task.Run(Function() rojoAmarath)
        'etiqueta.ForeColor = rojoAmarath
    End Sub
    Public Shared Sub resetearEtiqueta(etiqueta As Windows.Forms.Label, Optional filas As Integer = 0)
        'Dim newFont As New Font(etiqueta.Font, FontStyle.Bold)
        'etiqueta.Font = New Font("Consolas", 10, FontStyle.Bold Or FontStyle.Italic)
        'etiqueta.Text = "Listo."
        aplicarTema(etiqueta)
        'etiqueta.BackColor = blancoPuro_
        'etiqueta.ForeColor = temaClaroCasiNegro
        If filas >= 0 Then
            etiqueta.Text = "Registros: " + filas.ToString
        Else
            etiqueta.Text = "Listo!"
        End If
    End Sub

    Public Shared Async Sub gestionarBarraAsync(barra As ProgressBar)
        CheckForIllegalCrossThreadCalls = False 'ALERTA, PODRIA PRODUCIR ERROR DE MULTIHILO #ADVERTENCIA 1
        'Await Task.Run(Sub() barra.Style = ProgressBarStyle.Marquee)
        barra.MarqueeAnimationSpeed = 1
        barra.Style = ProgressBarStyle.Marquee
        barra.Value = 0
        Await Task.Run(Sub() barra.Refresh())
    End Sub

    Public Shared Sub encenderControlesDeEspera(barra As ProgressBar, etiqueta As Label, Optional texto As String = "Consultando...")
        barra.MarqueeAnimationSpeed = 1
        barra.Style = ProgressBarStyle.Marquee
        'barra.Value = 0
        etiqueta.Text = texto
        etiqueta.ForeColor = rojoAmarath
    End Sub

    Public Shared Sub apagarControlesDeEspera(barra As ProgressBar, etiqueta As Label, Optional filas As Integer = 0)
        barra.MarqueeAnimationSpeed = 0
        barra.Style = ProgressBarStyle.Continuous
        barra.Value = barra.Maximum
        aplicarTema(etiqueta)
        If filas >= 0 Then
            etiqueta.Text = "Registros: " + filas.ToString
        ElseIf filas = -1 Then
            etiqueta.Text = "Listo!"
        End If
    End Sub


    Public Shared Sub aplicarTema(ByRef c As Object)
        If True Then
            For Each d As Control In c.Controls
                aplicarTema(d)
            Next
            temaSeleccionado = "Claro"
            Dim nombreControl As String = c.name
            Dim tipoControl As String = ""
            tipoControl = c.GetType.ToString
            If tipoControl.Substring(0, 13) = "DataGreen.frm" Then
                tipoControl = "DataGreen.frm"
            End If
            If temaSeleccionado = "Claro" And tipoControl <> "" Then
                'c.Font = fuenteRegular 'New Font(tipografia1, 8)
                Select Case tipoControl
                    Case "DataGreen.frm" '
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                        c.Font = fuenteRegular
                        'c.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                        'c.WindowState = FormWindowState.Maximized
                        'c.StartPosition = FormStartPosition.CenterScreen
                        'c.Refresh()
                    Case "System.Windows.Forms.TextBox" '"txt"
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                        If c.Name.substring(0, 6).Equals("txtlbl") Then
                            c.BorderStyle = BorderStyle.None
                            c.ReadOnly = True
                            c.BackColor = grisBebe2__
                            c.Font = fuenteMonoespaciada
                            c.Multiline = True
                            c.Size = New Size(c.Size.Width, 15)
                        End If
                    Case "System.Windows.Forms.Button" '"btn"
                        'c.Font = fuenteBotones 'New Font(tipografiaEspecial, 10, FontStyle.Bold)
                        c.Font = fuenteBotones
                        'c.ForeColor = grisOscuro_
                        c.TextAlign = ContentAlignment.MiddleCenter
                        'c.Size = New Size(100, 30)
                        c.Height = 18

                        'Mejora en colores
                        c.FlatStyle = FlatStyle.Flat
                        c.FlatAppearance.BorderSize = 1
                        c.FlatAppearance.BorderColor = azulCielo__
                        c.BackColor = blancoPuro_ 'grisBebe2__
                        c.ForeColor = grisNoventa
                        c.FlatAppearance.MouseOverBackColor = verderCian_
                        'c.FlatAppearance.MouseOverForeColor = blancoPuro_
                    Case "System.Windows.Forms.Label" '"lbl"
                        c.ForeColor = grisOscuro_ 'negroMate__
                        c.Font = fuenteMonoespaciada
                    Case "System.Windows.Forms.DataGridView" '"dgv"
                        c.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, c, New Object() {True})
                        c.EnableHeadersVisualStyles = False
                        c.ColumnHeadersDefaultCellStyle.Font = fuenteMonoespaciada
                        c.DefaultCellStyle.Font = New Font("Ubuntu Mono", 9, FontStyle.Regular) 'fuenteMonoespaciada
                        c.BackgroundColor = blancoHumo_ 'blancoPuro_
                        c.BorderStyle = BorderStyle.None
                        c.CellBorderStyle = DataGridViewCellBorderStyle.None
                        c.AllowUserToOrderColumns = False
                        c.AllowUserToResizeRows = False
                        c.EditMode = DataGridViewEditMode.EditProgrammatically
                        c.AllowUserToAddRows = False
                        c.RowHeadersVisible = False
                        c.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        c.ColumnHeadersHeight = 20
                        'c.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        'c.AutoResizeColumns()
                        'c.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                        'c.AutoResizeRows()
                        'c.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                        'c.AllowUserToAddRows = False
                        'c.RowHeadersVisible = False
                        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
                        c.RowTemplate.Height = 18

                        'Colores de Grid
                        c.ColumnHeadersDefaultCellStyle.BackColor = grisWindows
                        c.ColumnHeadersDefaultCellStyle.ForeColor = blancoPuro_
                        c.DefaultCellStyle.BackColor = blancoHumo_ 'blancoPuro_
                        c.DefaultCellStyle.ForeColor = grisOnyx___
                        c.DefaultCellStyle.SelectionBackColor = verdeClaro_ 'verderCian_
                        c.DefaultCellStyle.SelectionForeColor = negroPuro__
                    Case "System.Windows.Forms.MenuStrip" '"mnu"
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                    Case "System.Windows.Forms.ComboBox" '"cbo"
                        'c.FlatStyle = FlatStyle.Flat
                        c.BackColor = blancoPuro_
                        c.Font = fuenteMonoespaciada
                        'c.SelectNextControl(True, False, True, True)
                        'c.GetNextControl(c, True)
                        c.Select(0, 0)
                        'c.Text = "..."
                    Case "System.Windows.Forms.GroupBox" '"grp"
                        c.ForeColor = grisNoventa
                        c.Font = fuenteMonoespaciada
                        'c.Font = fuenteEtiquetas

                    Case "System.Windows.Forms.DateTimePicker" '"grp"
                        c.Font = fuenteMonoespaciada
                    Case "System.Windows.Forms.ProgressBar"
                        c.Height = 3
                    Case "System.Windows.Forms.TreeView"
                        c.BorderStyle = BorderStyle.None
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                        'c.CollapseAll()
                    Case "System.Windows.Forms.CheckBox"
                        'c.Font = fuenteEtiquetas
                        c.ForeColor = grisNoventa
                        c.Font = fuenteMonoespaciada
                    Case "System.Windows.Forms.RadioButton"
                        'c.Font = fuenteEtiquetas
                        c.ForeColor = grisNoventa
                End Select
            End If
            If temaSeleccionado = "Oscuro" And tipoControl <> "" Then
                c.Font = fuenteRegular 'New Font(tipografia1, 8)
                Select Case tipoControl
                    Case "DataGreen.frm" '
                        c.BackColor = negroVisual 'grisOnyx___
                        c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.MenuStrip" '"mnu"
                        c.BackColor = Color.Black
                        c.ForeColor = grisBebe___
                        'Case "System.Windows.Forms.ToolStripMenuItem"
                        '    c.BackColor = grisOnyx___
                        '    c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.ToolStrip"
                        'c.Visible = False
                        c.BackColor = Color.Black
                        c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.ToolStripMenuItem"
                        'c.Visible = False
                        c.BackColor = Color.Black
                        c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.TextBox" '"txt"
                        c.BackColor = grisOnyx___
                        c.ForeColor = grisBebe___
                        c.BorderStyle = BorderStyle.FixedSingle
                    Case "System.Windows.Forms.Button" '"btn"
                        c.Font = New Font(tipografiaEspecial, 10, FontStyle.Bold)
                        'c.Size = New Size(100, 30)
                        c.Height = 25
                        c.FlatStyle = FlatStyle.Flat
                        c.FlatAppearance.BorderSize = 0
                        c.FlatAppearance.MouseOverBackColor = temaClaroLiliOscuro
                        c.FlatAppearance.BorderSize = 0
                        c.BackColor = violetaClar
                        c.ForeColor = grisBebe___
                        'Dim funteAuxiliar As New Font(tipografia1, 8, FontStyle.Bold)
                        'c.Font = funteAuxiliar
                    Case "System.Windows.Forms.Label" '"lbl"
                        c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.DataGridView" '"dgv"
                        c.EnableHeadersVisualStyles = False
                        c.ColumnHeadersDefaultCellStyle.Font = fuenteMonoespaciada
                        c.DefaultCellStyle.Font = fuenteMonoespaciada
                        c.BackgroundColor = negroVisual
                        c.BorderStyle = BorderStyle.None
                        c.CellBorderStyle = DataGridViewCellBorderStyle.None
                        c.AllowUserToOrderColumns = False
                        c.AllowUserToResizeRows = False
                        c.EditMode = DataGridViewEditMode.EditProgrammatically
                        c.AllowUserToAddRows = False
                        c.RowHeadersVisible = False
                        c.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        c.ColumnHeadersHeight = 20
                        'c.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        'c.AutoResizeColumns()
                        'c.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                        'c.AutoResizeRows()
                        'c.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                        c.AllowUserToAddRows = False
                        c.RowHeadersVisible = False
                        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
                        c.RowTemplate.Height = 20

                        'Colores de Grid
                        c.ColumnHeadersDefaultCellStyle.BackColor = grisSilver_
                        c.ColumnHeadersDefaultCellStyle.ForeColor = negroVisual
                        c.DefaultCellStyle.BackColor = negroVisual
                        c.DefaultCellStyle.ForeColor = grisSilver_
                        c.DefaultCellStyle.SelectionBackColor = negroVisua2
                        c.DefaultCellStyle.SelectionForeColor = blancoPuro_
                    Case "System.Windows.Forms.ComboBox" '"cbo"
                        c.FlatStyle = FlatStyle.Flat
                        c.BackColor = negroVisual
                        c.ForeColor = grisBebe___
                        c.Font = fuenteMonoespaciada
                        'c.Text = "..."
                    Case "System.Windows.Forms.GroupBox" '"grp"
                        c.ForeColor = grisBebe___
                    Case "System.Windows.Forms.DateTimePicker" '"grp"
                        c.Font = fuenteMonoespaciada
                    Case "System.Windows.Forms.ProgressBar"
                        c.Height = 5
                    Case "System.Windows.Forms.TreeView"
                        c.BorderStyle = BorderStyle.None
                        c.BackColor = negroVisual
                        c.ForeColor = grisBebe___
                        'c.CollapseAll()
                End Select
            End If
        End If
    End Sub

    Public Shared Sub aplicarTemaExagerado(ByRef c As Object)
        If True Then
            For Each d As Control In c.Controls
                aplicarTemaExagerado(d)
            Next
            temaSeleccionado = "Claro"
            Dim nombreControl As String = c.name
            Dim tipoControl As String = ""
            tipoControl = c.GetType.ToString
            If tipoControl.Substring(0, 13) = "DataGreen.frm" Then
                tipoControl = "DataGreen.frm"
            End If
            If temaSeleccionado = "Claro" And tipoControl <> "" Then
                'c.Font = fuenteRegular 'New Font(tipografia1, 8)
                Select Case tipoControl
                    Case "DataGreen.frm" '
                        c.BackColor = blancoPuro_ 'blancoPuro_
                        c.ForeColor = negroMate__
                        c.Font = fuenteExagerada
                        'c.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                        'c.WindowState = FormWindowState.Maximized
                        'c.StartPosition = FormStartPosition.CenterScreen
                        'c.Refresh()
                    Case "System.Windows.Forms.TextBox" '"txt"
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                        'c.Height = 12
                        c.Font = fuenteExagerada

                    Case "System.Windows.Forms.Button" '"btn"
                        'c.Font = fuenteBotones 'New Font(tipografiaEspecial, 10, FontStyle.Bold)
                        c.Font = fuenteBotonesExagerada
                        'c.ForeColor = grisOscuro_
                        c.TextAlign = ContentAlignment.MiddleCenter
                        'c.Size = New Size(100, 30)
                        c.Height = 30

                        'Mejora en colores
                        c.FlatStyle = FlatStyle.Flat
                        c.FlatAppearance.BorderSize = 2
                        c.FlatAppearance.BorderColor = azulCielo__
                        c.BackColor = blancoPuro_
                        c.ForeColor = grisNoventa
                        c.FlatAppearance.MouseOverBackColor = verdeMentaT

                    Case "System.Windows.Forms.Label" '"lbl"
                        c.ForeColor = grisOscuro_ 'negroMate__
                        c.Font = fuenteEtiquetasExagerada
                        'PENDIENTE: AGRANDAR TAMAÑO
                    Case "System.Windows.Forms.DataGridView" '"dgv"
                        c.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, c, New Object() {True})
                        c.EnableHeadersVisualStyles = False
                        c.ColumnHeadersDefaultCellStyle.Font = fuenteMonoespaciadaExagerada
                        c.DefaultCellStyle.Font = fuenteMonoespaciadaExagerada
                        c.BackgroundColor = blancoPuro_
                        c.BorderStyle = BorderStyle.None
                        c.CellBorderStyle = DataGridViewCellBorderStyle.None
                        c.AllowUserToOrderColumns = False
                        c.AllowUserToResizeRows = False
                        c.EditMode = DataGridViewEditMode.EditProgrammatically
                        c.AllowUserToAddRows = False
                        c.RowHeadersVisible = False
                        c.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        c.ColumnHeadersHeight = 35
                        c.AllowUserToAddRows = False
                        'c.RowHeadersVisible = False
                        c.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
                        c.RowTemplate.Height = 35

                        'Colores de Grid
                        c.ColumnHeadersDefaultCellStyle.BackColor = grisWindows
                        c.ColumnHeadersDefaultCellStyle.ForeColor = blancoPuro_
                        c.DefaultCellStyle.BackColor = blancoPuro_
                        c.DefaultCellStyle.ForeColor = grisOnyx___
                        c.DefaultCellStyle.SelectionBackColor = verderCian_
                        c.DefaultCellStyle.SelectionForeColor = negroPuro__
                    Case "System.Windows.Forms.MenuStrip" '"mnu"
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                    Case "System.Windows.Forms.ComboBox" '"cbo"
                        'c.FlatStyle = FlatStyle.Flat
                        c.BackColor = blancoPuro_
                        c.Font = fuenteComboBoxExagerada
                        'c.SelectNextControl(True, False, True, True)
                        'c.GetNextControl(c, True)
                        c.Select(0, 0)
                        'c.Text = "..."
                    Case "System.Windows.Forms.GroupBox" '"grp"
                        c.ForeColor = grisNoventa
                        c.Font = fuenteMonoespaciadaExagerada
                        'c.Font = fuenteEtiquetas

                    Case "System.Windows.Forms.DateTimePicker" '"grp"
                        c.Font = fuenteComboBoxExagerada
                    Case "System.Windows.Forms.ProgressBar"
                        c.Height = 3
                    Case "System.Windows.Forms.TreeView"
                        c.BorderStyle = BorderStyle.None
                        c.BackColor = blancoPuro_
                        c.ForeColor = negroMate__
                        'c.CollapseAll()
                    Case "System.Windows.Forms.CheckBox"
                        'c.Font = fuenteEtiquetas
                        c.ForeColor = grisNoventa
                        c.Font = fuenteMonoespaciadaExagerada
                    Case "System.Windows.Forms.RadioButton"
                        'c.Font = fuenteEtiquetas
                        c.ForeColor = grisNoventa
                End Select
            End If
        End If
    End Sub

    Public Shared Sub aplicarTemaMDI(ByRef c As Object)
        c.BackColor = azulNoche__ ' temaClaroBlanco
        c.ForeColor = temaClaroCasiNegro
    End Sub

    Public Shared Sub cargarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "", Optional mostrarClave As Boolean = False)
        'comboBox.DataSource = Nothing
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        'Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            If mostrarClave Then
                comboBox.DisplayMember = "Concatenado"
            Else 'If dataTable.Rows.Count < 10 Then
                comboBox.DisplayMember = "Valor"
                'Else
                '    comboBox.DisplayMember = "Concatenado"
            End If
            comboBox.ValueMember = "Clave"
            comboBox.DataSource = dataTable
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    If mostrarClave Then
                        comboBox.DisplayMember = "Concatenado"
                    ElseIf dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                    comboBox.ValueMember = "Clave"
                    comboBox.DataSource = dataView
                End If
                'i = i + 1
            Next
        End If
        
        'If comboBox.Items.Count > 0 Then
        '    comboBox.SelectedIndex = 0
        'End If
    End Sub

    Public Shared Sub cargarCombo(ByRef combo As ComboBox, tabla As DataTable, c As Integer, v As Integer, Optional preSeleccion As Boolean = False) 'c=clave, v=valor
        'combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'combo.AutoCompleteSource = AutoCompleteSource.ListItems
        combo.DisplayMember = tabla.Columns(v).ColumnName
        combo.ValueMember = tabla.Columns(c).ColumnName
        combo.DataSource = tabla
        If Not preSeleccion Then
            combo.SelectedIndex = -1
        End If
    End Sub

    Public Shared Sub cargarComboConFiltrado(ByRef combo As ComboBox, tabla As DataTable, c As Integer, v As Integer) 'c=clave, v=valor
        Dim strText As String

        strText = combo.Text


        If combo.Text = "" Then
            combo.DataSource = tabla
            combo.ValueMember = tabla.Columns(c).ColumnName
            combo.DisplayMember = tabla.Columns(v).ColumnName
            combo.SelectedIndex = -1
            combo.DroppedDown = False
        End If

        If Len(strText) >= 1 Then

            'cboActividad.DataSource = dataParaControles.Item("Actividades").Select("Concatenado LIKE '%" & strText & "%'")

            Dim dt As New DataTable()
            dt.Columns.Add("Clave")
            dt.Columns.Add("Valor")
            dt.Columns.Add("Concatenado")
            Dim matriz As DataRow()
            matriz = tabla.Select("Concatenado LIKE '%" & strText & "%'")
            For Each fila As DataRow In matriz
                dt.Rows.Add(fila.ItemArray)
            Next

            If dt.Rows.Count > 0 Then
                combo.DataSource = dt
                combo.ValueMember = dt.Columns(c).ColumnName
                combo.DisplayMember = dt.Columns(v).ColumnName

                If combo.Items.Count <> 0 Then
                    combo.DroppedDown = True
                    combo.SelectedIndex = -1
                    combo.Text = ""
                    combo.SelectedText = strText
                    strText = ""
                Else
                    combo.DataSource = dt
                    combo.ValueMember = dt.Columns(c).ColumnName
                    combo.DisplayMember = dt.Columns(v).ColumnName
                    combo.SelectedIndex = -1
                    combo.Text = ""
                    combo.SelectedText = strText
                    strText = ""
                    combo.DroppedDown = False
                End If
            Else
                'combo.DataSource = Nothing
                combo.DroppedDown = False
            End If


        End If
    End Sub

    Public Shared Sub removerFila(ByRef tabla As DataTable, texto As String)
        Dim aux As DataRow = tabla.NewRow
        Dim encontrado As Boolean = False
        For Each fila As DataRow In tabla.Rows
            For Each item In fila.ItemArray
                If item.ToString = texto Then
                    aux = fila
                    encontrado = True
                    Exit For
                End If
            Next
            If encontrado Then
                Exit For
            End If
        Next
        If encontrado Then
            tabla.Rows.Remove(aux)
            removerFila(tabla, texto)
        End If
    End Sub

    Public Shared Sub encadenar(ByRef cadena As String, eslabon As String, Optional separador As String = "!")
        cadena = cadena & IIf(cadena.Length = 0, "", separador) & eslabon
    End Sub

    Public Shared Sub formatearDataGridView(ByRef dgv As DataGridView, Optional ajustarColumnas As Boolean = False)
        'FORMATEAR COLUMNAS SEGUN NOMBRE DE CABECERA
        Dim col As Integer = dgv.ColumnCount - 1, tipo As String
        For i As Integer = 0 To col Step 1
            tipo = dgv.Columns(i).Name.ToString.Substring(0, IIf(dgv.Columns(i).Name.ToString.Length >= 2, 2, 1))
            If tipo = "F_" Then
                dgv.Columns(i).DefaultCellStyle.Format = "yyyy-MM-dd"
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
            ElseIf tipo = "T_" Then
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
                '    dgvResultado.Columns(i).DefaultCellStyle.Format = "@"
                'dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
                'ElseIf tipo = "N" Then
                '    dgvResultado.Columns(i).DefaultCellStyle.Format = "#"
            ElseIf tipo = "H1" Then
                dgv.Columns(i).DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss"
                'La siguiente linea es solo para DGV que no se van a exportar
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
            ElseIf tipo.Substring(0, 1) = "D" AndAlso tipo.Substring(1, 1) >= "0" AndAlso tipo.Substring(1, 1) <= "9" Then
                Dim ceros As Integer = CInt(tipo.Substring(1, 1))
                dgv.Columns(i).DefaultCellStyle.Format = "#,##0." + StrDup(ceros, "0")
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'La siguiente linea es solo para DGV que no se van a exportar
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
                '    dgvResultado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf tipo = "N_" Then 'tipo.Substring(0, 2) = "N_" Then
                'Dim ceros As Integer = CInt(tipo.Substring(1, 1))
                'dgv.Columns(i).DefaultCellStyle.Format = "#,##0." + StrDup(ceros, "0")
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'La siguiente linea es solo para DGV que no se van a exportar
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
            ElseIf tipo.Substring(0, 1) = "P" AndAlso tipo.Substring(1, 1) >= "0" AndAlso tipo.Substring(1, 1) <= "9" Then
                Dim ceros As Integer = CInt(tipo.Substring(1, 1))
                dgv.Columns(i).DefaultCellStyle.Format = "0." + StrDup(ceros, "0") + "%"
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
            Else
                dgv.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'dgv.Columns(i).HeaderText = dgv.Columns(i).Name.ToString.Substring(2)
            End If
            If ajustarColumnas Then
                dgv.AutoResizeColumn(i)
            Else
                If dgv.RowCount < 2000 Then
                    dgv.AutoResizeColumn(i)
                End If
            End If
            'dgv.AllowUserToResizeRows = False
            'dgv.AutoResizeRows()
        Next
        'dgv.AutoResizeColumns()
        'dgv.AutoResizeRows()
    End Sub

    Public Shared Sub bloquearControl(ByRef c As Object)
        For Each d As Control In c.Controls
            bloquearControl(d)
        Next
        Dim nombreControl As String = c.Name
        Dim tipoControl As String = ""
        tipoControl = c.GetType.ToString
        If tipoControl <> "" Then
            Select Case tipoControl
                Case "System.Windows.Forms.Button" '"btn"
                    c.FlatAppearance.BorderColor = grisBebe___
                    c.BackColor = grisBebe___
                    c.ForeColor = grisBebe___
                Case "System.Windows.Forms.Label" '"lbl"
                    c.ForeColor = grisBebe___
                Case "System.Windows.Forms.DataGridView" '"dgv"
                    c.DefaultCellStyle.SelectionBackColor = grisSilver_
                    c.DefaultCellStyle.SelectionForeColor = blancoPuro_
            End Select
            c.Enabled = False
        End If
    End Sub

    Public Shared Sub desbloquearControl(ByRef c As Object)
        For Each d As Control In c.Controls
            desbloquearControl(d)
        Next
        Dim nombreControl As String = c.Name
        Dim tipoControl As String = ""
        tipoControl = c.GetType.ToString
        If tipoControl <> "" Then
            Select Case tipoControl
                Case "System.Windows.Forms.Button" '"btn"
                    c.FlatAppearance.BorderColor = azulCielo__
                    c.BackColor = blancoPuro_
                    c.ForeColor = grisNoventa
                Case "System.Windows.Forms.Label" '"lbl"
                    c.ForeColor = grisOscuro_ 'negroMate__
                Case "System.Windows.Forms.DataGridView" '"dgv"
                    c.DefaultCellStyle.SelectionBackColor = verderCian_
                    c.DefaultCellStyle.SelectionForeColor = negroPuro__
            End Select
            c.Enabled = True
        End If
        'aplicarTema(c)
        'c.Enabled = True
    End Sub

    Public Shared Sub bloquearFilas(dgv As DataGridView)
        'filaObjetivo = dgvResultado.CurrentRow.Index
        dgv.DefaultCellStyle.SelectionBackColor = rojoAmarath
        dgv.DefaultCellStyle.SelectionForeColor = rosaBlanco_
        dgv.Enabled = False
    End Sub

    Public Shared Sub desbloquearFilas(dgv As DataGridView)
        'filaObjetivo = dgvResultado.CurrentRow.Index
        dgv.DefaultCellStyle.SelectionBackColor = verderCian_
        dgv.DefaultCellStyle.SelectionForeColor = negroPuro__
        dgv.Enabled = True
    End Sub

    Public Shared Sub formatearLineasDataGridView(dgv As DataGridView, c As Integer, Optional t As String = "*")
        For Each f As DataGridViewRow In dgv.Rows
            If f.Cells(c).Value.ToString = t Then
                f.DefaultCellStyle.BackColor = grisLobo___
                f.DefaultCellStyle.ForeColor = negroPuro__
                'f.DefaultCellStyle.Font = New Font(f.DefaultCellStyle.Font, FontStyle.Bold)
                f.DefaultCellStyle.Font = New Font("Ubuntu Mono", 9, FontStyle.Bold) 'New Font(fuenteMonoespaciada, FontStyle.Bold)
            End If
        Next
    End Sub

    Public Shared Sub deshabilitarOrdenPorColumnas(datagrid As DataGridView)
        For index = 0 To datagrid.Columns.Count - 1
            datagrid.Columns(index).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Public Shared Function NumeroATexto(ByVal numero As Integer) As String
        Dim unidades() As String = {"", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"}
        Dim decenas() As String = {"", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"}
        Dim especiales() As String = {"diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"}

        If numero < 10 Then
            Return unidades(numero)
        ElseIf numero < 20 Then
            Return especiales(numero - 10)
        ElseIf numero < 100 Then
            Dim texto As String = decenas(numero \ 10)
            If numero Mod 10 > 0 Then
                texto &= " y " & unidades(numero Mod 10)
            End If
            Return texto
        ElseIf numero < 1000 Then
            Dim texto As String
            If numero \ 100 = 1 Then
                texto = "cien"
            Else
                texto = unidades(numero \ 100) & "cientos"
            End If
            If numero Mod 100 > 0 Then
                texto &= " " & NumeroATexto(numero Mod 100)
            End If
            Return texto
        ElseIf numero < 1000000 Then
            Dim texto As String
            If numero \ 1000 = 1 Then
                texto = "mil"
            Else
                texto = NumeroATexto(numero \ 1000) & " mil"
            End If
            If numero Mod 1000 > 0 Then
                texto &= " " & NumeroATexto(numero Mod 1000)
            End If
            Return texto
        Else
            Return "Número demasiado grande"
        End If
    End Function

    Public Shared Function Capitalize(ByVal texto As String) As String
        If String.IsNullOrEmpty(texto) Then
            Return texto ' Retorna el texto tal cual si está vacío o es nulo
        End If

        ' Capitaliza la primera letra y pone el resto en minúsculas
        Return Char.ToUpper(texto(0)) & texto.Substring(1).ToLower()
    End Function

    Public Shared Function obtenerParametroLongitud() As String
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdParametro", "LONCODTRAB")
        Dim resultados As DataTable = New DataTable
        Dim parametroNumero As String = ""
        Dim parametroTexto As String = ""
        resultados = doItBaby("sp_Dg_ObtenerValorParametroNisira", p, TipoQuery.DataTable)
        parametroNumero = resultados.Rows(0).Item("Id")
        parametroTexto = NumeroATexto(parametroNumero)
        Return parametroNumero + "   |   " + Capitalize(parametroTexto)
    End Function
End Class
