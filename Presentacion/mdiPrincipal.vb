Imports System.Windows.Forms
Imports Entidades.Temporales
Imports Logica.Funciones
Imports Logica.Utiles
Imports Datos.Conexion

'IMPLEMENTAR VENTANA PARA VERIFICAR TAREOS DUPLICADOS DE LA ROCA

Public Class mdiPrincipal

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Crear una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Convertir en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
        My.Computer.Clipboard.GetDataObject()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub mdiPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub mdiPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Color.White
            End If
        Next ctl
        'Me.BackColor = Color.Purple
        Me.Text = "DataGreen " + versionActual
        'cargarMenus()
        habilitarMenus()
        If probarConexionDG() Then
            versionDisponible = obtenerUltimaVersion("DataGreen")
        End If
        If versionActual < versionDisponible Then
            mnu1_3_ActualizacionSistema.Enabled = True
            mnu1_3_ActualizacionSistema.BackColor = colorAlerta
            mnu1_Mantenimiento.BackColor = colorAlerta
        Else
            mnu1_3_ActualizacionSistema.Enabled = False
        End If
        aplicarTema(Me)
        realizarValidacionesIniciales()
    End Sub

    Private Function obtenerUltimaVersion(aplicativo As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Aplicativo", aplicativo)
        Dim r As String
        Try
            r = doItBaby("spObtenerUltimaVersion", p, TipoQuery.Scalar)
            Return IIf(r.Length > 0, r, "")
        Catch ex As Exception
            Throw ex
            Return ""
        End Try
    End Function

    Private Sub habilitarMenus()
        'AGREGARMENU PASO 3: AGREGAR EL MENU AQUI PARA PODER HABILITARLO
        mnu1_Mantenimiento.Enabled = modulosPermitidos.Item("mnu1_Mantenimiento")
        mnu1_1_ConfigBases.Enabled = modulosPermitidos.Item("mnu1_1_ConfigBases")
        mnu1_2_MantenimientoUsuarios.Enabled = modulosPermitidos.Item("mnu1_2_MantenimientoUsuarios")
        mnu2_RecursosHumanos.Enabled = modulosPermitidos.Item("mnu2_RecursosHumanos")
        'mnu2_2_Reportes.Enabled = modulosPermitidos.Item("mnu2_1_Asistencia")
        'mnu2_2_1_ReporteAsistencia.Enabled = modulosPermitidos.Item("mnu2_1_1_ReporteAsistencia")
        'mnu2_2_2_UltimoDiaAsistencia.Enabled = modulosPermitidos.Item("mnu2_1_2_UltimoDiaAsistencia")
        'mnu2_2_3_ReporteFaltas.Enabled = modulosPermitidos.Item("mnu2_1_3_ReporteFaltas")
        'mnu2_2_4_ReporteAsistenciaChronos.Enabled = modulosPermitidos.Item("mnu2_1_4_ReporteAsistenciaChronos")
        mnu3_Fitosanidad.Enabled = modulosPermitidos.Item("mnu3_Fitosanidad")
        mnu3_1_Reportes.Enabled = modulosPermitidos.Item("mnu3_1_Reportes")
        mnu1_3_ActualizacionSistema.Enabled = modulosPermitidos.Item("mnu1_3_ActualizacionSistema")
        'mnu2_2_GestioEstandares.Enabled = modulosPermitidos.Item("mnu2_2_GestioEstandares")
        'mnu2_2_1_ValidarEstandares.Enabled = modulosPermitidos.Item("mnu2_2_1_ValidarEstandares")
        mnu4_Supervision.Enabled = modulosPermitidos.Item("mnu4_Supervision")
        mnu4_1_Movimientos.Enabled = modulosPermitidos.Item("mnu4_1_Movimientos")
        mnu5_Costos.Enabled = modulosPermitidos.Item("mnu5_Costos")
        mnu5_1_Procesos.Enabled = modulosPermitidos.Item("mnu5_1_Procesos")
        mnu5_1_1_CierreDiario.Enabled = modulosPermitidos.Item("mnu5_1_1_CierreDiario")
        mnu5_2_Tablas.Enabled = modulosPermitidos.Item("mnu5_2_Tablas")
        mnu5_2_1_Reglas.Enabled = modulosPermitidos.Item("mnu5_2_1_Reglas")
        mnu6_Packing.Enabled = modulosPermitidos.Item("mnu6_Packing")
        mnu6_1_Reportes.Enabled = modulosPermitidos.Item("mnu6_1_Reportes")
        mnu6_1_1_FrutaProcesada.Enabled = modulosPermitidos.Item("mnu6_1_1_FrutaProcesada")
        mnu7_Maquinaria.Enabled = modulosPermitidos.Item("mnu7_Maquinaria")
        mnu7_1_Reportes.Enabled = modulosPermitidos.Item("mnu7_1_Reportes")
        mnu7_1_1_ResumenUsoImplementoMaquinaLabor.Enabled = modulosPermitidos.Item("mnu7_1_1_ResumenUsoImplementoMaquinaLabor")
        mnu7_1_2_HorasMaquinariasXLote.Enabled = modulosPermitidos.Item("mnu7_1_2_HorasMaquinariasXLote") '2023-04-20 -> Menu Actual'
        mnu8_Almacenes.Enabled = modulosPermitidos.Item("mnu8_Almacenes")
        mnu8_1_Reportes.Enabled = modulosPermitidos.Item("mnu8_1_Reportes")
        mnu8_1_1_Ingresos.Enabled = modulosPermitidos.Item("mnu8_1_1_Ingresos")
        mnu9_Produccion.Enabled = modulosPermitidos.Item("mnu9_Produccion")
        mnu9_1_Reportes.Enabled = modulosPermitidos.Item("mnu9_1_Reportes")
        mnu9_1_1_CosechaCampoConsolidado.Enabled = modulosPermitidos.Item("mnu9_1_1_CosechaCampoConsolidado")
        mnu9_2_Movimientos.Enabled = modulosPermitidos.Item("mnu9_2_Movimientos")
        mnu9_2_1_ActualizarDatosPallets.Enabled = modulosPermitidos.Item("mnu9_2_1_ActualizarDatosPallets")
        'mnu2_3_CostosPersonal.Enabled = modulosPermitidos.Item("mnu2_3_CostosPersonal")
        'mnu2_3_1_DetalleHorasPersonaActividadConsumidor.Enabled = modulosPermitidos.Item("mnu2_3_1_DetalleHorasPersonaActividadConsumidor")
        mnu4_2_Reportes.Enabled = modulosPermitidos.Item("mnu4_2_Reportes")
        mnu4_2_1_FormatoTransferencia.Enabled = modulosPermitidos.Item("mnu4_2_1_FormatoTransferencia")
        mnu4_2_2_ResumenTareos.Enabled = modulosPermitidos.Item("mnu4_2_2_ResumenTareos")
        mnu4_1_1_Tareos.Enabled = modulosPermitidos.Item("mnu4_1_1_Tareos")
        mnu6_2_Movimientos.Enabled = modulosPermitidos.Item("mnu6_2_Movimientos")
        mnu6_2_1_GenerarCodigosPacking.Enabled = modulosPermitidos.Item("mnu6_2_1_GenerarCodigosPacking")
        mnu6_2_2_LecturaEficiencias.Enabled = modulosPermitidos.Item("mnu6_2_2_LecturaEficiencias")
        mnu9_1_2_Costeo.Enabled = modulosPermitidos.Item("mnu9_1_2_Costeo")
        mnu6_2_3_TareosPacking.Enabled = modulosPermitidos.Item("mnu6_2_3_TareosPacking")
        mnu6_1_2_EficienciasEnVivo.Enabled = modulosPermitidos.Item("mnu6_1_2_EficienciasEnVivo")
        mnu5_3_Reportes.Enabled = modulosPermitidos.Item("mnu5_3_Reportes")
        mnu5_3_1_GestionCostosDetallado.Enabled = modulosPermitidos.Item("mnu5_3_1_GestionCostosDetallado")
        mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen.Enabled = modulosPermitidos.Item("mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen")
        mnu6_1_4_EficienciasPersonal.Enabled = modulosPermitidos.Item("mnu6_1_4_EficienciasPersonal")
        mnu5_1_2_AsignacionCostosModulosProcesados.Enabled = modulosPermitidos.Item("mnu5_1_2_AsignacionCostosModulosProcesados")
        'mnu2_4_CatalogoPersonal.Enabled = modulosPermitidos.Item("mnu2_4_CatalogoPersonal")
        mnu6_2_4_DistribuirHorasXConsumidorPacking.Enabled = modulosPermitidos.Item("mnu6_2_4_DistribuirHorasXConsumidorPacking")
        mnu3_2_Movimientos.Enabled = modulosPermitidos.Item("mnu3_2_Movimientos")
        mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario.Enabled = modulosPermitidos.Item("mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario")
        mnu10_Contabilidad.Enabled = modulosPermitidos.Item("mnu10_Contabilidad")
        mnu10_1_Movimientos.Enabled = modulosPermitidos.Item("mnu10_1_Movimientos")
        mnu10_2_Reportes.Enabled = modulosPermitidos.Item("mnu10_2_Reportes")
        mnu10_2_1_BalanceComprobacion.Enabled = modulosPermitidos.Item("mnu10_2_1_BalanceComprobacion")
        mnu6_1_5_AlcanceEstandares.Enabled = modulosPermitidos.Item("mnu6_1_5_AlcanceEstandares")
        mnu1_4_frmMantenimiento_AbrirCerrarDias.Enabled = modulosPermitidos.Item("mnu1_4_frmMantenimiento_AbrirCerrarDias")
        'mnu2_3_Movimientos.Enabled = modulosPermitidos.Item("mnu2_5_Movimientos")
        'mnu2_3_1_RegistrarAltasMasivas.Enabled = modulosPermitidos.Item("mnu2_5_1_RegistrarAltasMasivas")
        mnu6_1_6_AlcanceEstandares.Enabled = modulosPermitidos.Item("mnu6_1_6_AlcanceEstandares")
        'mnu2_5_2_DefinicionHorarios.Enabled = modulosPermitidos.Item("mnu2_5_2_DefinicionHorarios")
        mnu5_3_2_ReporteServicios.Enabled = modulosPermitidos.Item("mnu5_3_2_ReporteServicios")
        mnu8_1_2_RequerimientosInternos.Enabled = modulosPermitidos.Item("mnu8_1_2_RequerimientosInternos")
        mnu4_2_3_DetalleDiarioXSupuervisorGMO.Enabled = modulosPermitidos.Item("mnu4_2_3_DetalleDiarioXSupuervisorGMO")
        mnu10_1_1_CierreParrones.Enabled = modulosPermitidos.Item("mnu10_1_1_CierreParrones") '2021-01-05
        mnu4_2_4_ControlHorasDiario.Enabled = modulosPermitidos.Item("mnu4_2_4_ControlHorasDiario") '2020-01-14
        mnu9_1_3_TablaCampanasCultivos.Enabled = modulosPermitidos.Item("mnu9_1_3_TablaCampanasCultivos") '2021-01-18
        mnu5_3_3_HorasMaquinaXActividad.Enabled = modulosPermitidos.Item("mnu5_3_3_HorasMaquinaXActividad") ' 2021-01-19
        mnu4_2_5_ContrasteAsistencias.Enabled = modulosPermitidos.Item("mnu4_2_5_ContrasteAsistencias") '2021-01-26
        mnu11_Logistica.Enabled = modulosPermitidos.Item("mnu11_Logistica") '2021-01-28
        mnu11_1_Indices.Enabled = modulosPermitidos.Item("mnu11_1_Indices") '2021-01-28
        mnu11_1_1_Vehiculos.Enabled = modulosPermitidos.Item("mnu11_1_1_Vehiculos") '2021-01-28
        mnu5_1_3_ActualizarDataCosteo.Enabled = modulosPermitidos.Item("mnu5_1_3_ActualizarDataCosteo") '2021-02-02
        mnu11_1_2_Conductores.Enabled = modulosPermitidos.Item("mnu11_1_2_Conductores") '2021-02-09
        mnu11_1_3_CiudadesParaderos.Enabled = modulosPermitidos.Item("mnu11_1_3_CiudadesParaderos") '2021-02-16
        mnu11_1_4_Rutas.Enabled = modulosPermitidos.Item("mnu11_1_4_Rutas") '2021-02-24 
        mnu11_2_Movimientos.Enabled = modulosPermitidos.Item("mnu11_2_Movimientos") '2021-03-13
        mnu11_2_1_ServiciosTransporte.Enabled = modulosPermitidos.Item("mnu11_2_1_ServiciosTransporte")

        mnu2_1_Indices.Enabled = modulosPermitidos.Item("mnu2_1_Indices")
        mnu2_2_Reportes.Enabled = modulosPermitidos.Item("mnu2_2_Reportes")
        mnu2_3_Movimientos.Enabled = modulosPermitidos.Item("mnu2_3_Movimientos")

        mnu2_1_1_DefinicionDeHorarios.Enabled = modulosPermitidos.Item("mnu2_1_1_DefinicionDeHorarios")
        mnu2_2_1_ReporteAsistencia.Enabled = modulosPermitidos.Item("mnu2_2_1_ReporteAsistencia")
        mnu2_2_2_UltimoDiaAsistencia.Enabled = modulosPermitidos.Item("mnu2_2_2_UltimoDiaAsistencia")
        mnu2_2_3_ReporteFaltas.Enabled = modulosPermitidos.Item("mnu2_2_3_ReporteFaltas")
        mnu2_2_4_ReporteAsistenciaChronos.Enabled = modulosPermitidos.Item("mnu2_2_4_ReporteAsistenciaChronos")
        mnu2_2_5_ValidarEstandares.Enabled = modulosPermitidos.Item("mnu2_2_5_ValidarEstandares")
        mnu2_2_6_DetalleDeHorasPersonaPorActividadYConsumidor.Enabled = modulosPermitidos.Item("mnu2_2_6_DetalleDeHorasPersonaPorActividadYConsumidor")
        mnu2_2_7_CatalogoDePersonal.Enabled = modulosPermitidos.Item("mnu2_2_7_CatalogoDePersonal")
        mnu2_3_1_RegistrarAltasMasivas.Enabled = modulosPermitidos.Item("mnu2_3_1_RegistrarAltasMasivas")

        mnu2_2_8_ReporteDeAusentismo.Enabled = modulosPermitidos.Item("mnu2_2_8_ReporteDeAusentismo")
        mnu2_2_9_ReporteDeCeses.Enabled = modulosPermitidos.Item("mnu2_2_9_ReporteDeCeses")
        mnu2_2_10_ReporteDeConceptosXLiquidaciones.Enabled = modulosPermitidos.Item("mnu2_2_10_ReporteDeConceptosXLiquidaciones")
        mnu2_2_11_AntecedentesInternos.Enabled = modulosPermitidos.Item("mnu2_2_11_AntecedentesInternos")

        mnu10_2_2_CostosAcumulados.Enabled = modulosPermitidos("mnu10_2_2_CostosAcumulados")
        mnu2_2_12_CalculoBonos.Enabled = modulosPermitidos("mnu2_2_12_CalculoBonos")
        mnu2_3_2_ConfiguracionGruposLabores.Enabled = modulosPermitidos("mnu2_3_2_ConfiguracionGruposLabores")
        mnu2_3_3_ConfiguracionBonos.Enabled = modulosPermitidos("mnu2_3_3_ConfiguracionBonos")
        mnu3_1_1_ReporteAplicaciones.Enabled = modulosPermitidos.Item("mnu3_1_1_ReporteAplicaciones")
        mnu3_1_2_ReporteEvaluaciones.Enabled = modulosPermitidos.Item("mnu3_1_2_ReporteEvaluaciones")
        mnu6_2_5_FusionarCajasBifurcadas.Enabled = modulosPermitidos.Item("mnu6_2_5_FusionarCajasBifurcadas")
        mnu9_1_4_PalletsDespachados.Enabled = modulosPermitidos.Item("mnu9_1_4_PalletsDespachados")

        mnu12_Exportaciones.Enabled = modulosPermitidos.Item("mnu12_Exportaciones")
        mnu12_1_Reportes.Enabled = modulosPermitidos.Item("mnu12_1_Reportes")
        mnu12_1_1_PackingList.Enabled = modulosPermitidos.Item("mnu12_1_1_PackingList")

        mnu13_Presupuestos.Enabled = modulosPermitidos.Item("mnu13_Presupuestos")
        mnu13_1_Reportes.Enabled = modulosPermitidos.Item("mnu13_1_Reportes")
        mnu13_1_1_ControlPresupuestal.Enabled = modulosPermitidos.Item("mnu13_1_1_ControlPresupuestal")
        mnu9_1_5_CosechaYProduccion.Enabled = modulosPermitidos.Item("mnu9_1_5_CosechaYProduccion")
        mnu2_3_4_AsistenciasGmos.Enabled = modulosPermitidos.Item("mnu2_3_4_AsistenciasGmo")
        mnu10_2_3_FacturacionCobranzasExportacion.Enabled = modulosPermitidos.Item("mnu10_2_3_FacturacionCobranzasExportacion")
        mnu10_2_4_ReporteG.Enabled = modulosPermitidos.Item("mnu10_2_4_ReporteG")
        'mnu10_1_2_ActualizarConfiguracionesMaquinaria.Enabled = modulosPermitidos.Item("mnu10_1_2_ActualizarConfiguracionesMaquinaria")
        mnu10_1_2_Maquinaria.Enabled = modulosPermitidos.Item("mnu10_1_2_Maquinaria")
        mnu10_1_2_1_ActualizarConfiguraciones.Enabled = modulosPermitidos.Item("mnu10_1_2_1_ActualizarConfiguraciones")
        mnu10_1_2_2_GenerarAsientosContables.Enabled = modulosPermitidos.Item("mnu10_1_2_2_GenerarAsientosContables")
        mnu10_2_5_ConsumosDeAlmacenVsContabilidad.Enabled = modulosPermitidos.Item("mnu10_2_5_ConsumosDeAlmacenVsContabilidad")
        mnu10_2_6_IngresoBancosDetalladoFactura.Enabled = modulosPermitidos.Item("mnu10_2_6_IngresoBancosDetalladoFactura")
        mnu6_2_6_HorasADistribuir.Enabled = modulosPermitidos.Item("mnu6_2_6_HorasADistribuir")
        mnu11_2_2_GenerarPedidosServicioTransporte.Enabled = modulosPermitidos.Item("mnu11_2_2_GenerarPedidosServicioTransporte")
        mnu2_2_13_ResumenPlanillas.Enabled = modulosPermitidos.Item("mnu2_2_13_ResumenPlanillas")
        mnu3_2_1_CrearProgramasSemanales.Enabled = modulosPermitidos.Item("mnu3_2_1_CrearProgramasSemanales")

        mnu8_2_Movimientos.Enabled = modulosPermitidos.Item("mnu8_2_Movimientos")
        mnu8_2_1_CargarPedidosDeCompra.Enabled = modulosPermitidos.Item("mnu8_2_1_CargarPedidosDeCompra")

        mnu8_1_3_PedidosDeCompra.Enabled = modulosPermitidos.Item("mnu8_1_3_PedidosDeCompra")

        mnu4_1_2_DistribucionHorasXGaritas.Enabled = modulosPermitidos.Item("mnu4_1_2_DistribucionHorasXGaritas")
        mnu2_2_14_PlanillaAsistencia.Enabled = modulosPermitidos.Item("mnu2_2_14_PlanillaAsistencia")
        mnu13_1_2_ResumenPresupuestoGrupoSubgrupo.Enabled = modulosPermitidos.Item("mnu13_1_2_ResumenPresupuestoGrupoSubgrupo")
        mnu13_1_3_PresupuestoGeneral.Enabled = modulosPermitidos.Item("mnu13_1_3_PresupuestoGeneral")
        mnu13_1_4_SeguimientoPresupuestal.Enabled = modulosPermitidos.Item("mnu13_1_4_SeguimientoPresupuestal")
        mnu13_1_5_PresupuestoX.Enabled = modulosPermitidos.Item("mnu13_1_5_PresupuestoX")
        mnu6_1_7_SeguimientoPlanComercial.Enabled = modulosPermitidos.Item("mnu6_1_7_SeguimientoPlanComercial")
        mnu6_1_8_StockPallets.Enabled = modulosPermitidos.Item("mnu6_1_8_StockPallets")
        mnu6_2_7_ManteniminetoPlanesComerciales.Enabled = modulosPermitidos.Item("mnu6_2_7_ManteniminetoPlanesComerciales")
        mnu5_3_3_AnalisisDeTareos.Enabled = modulosPermitidos.Item("mnu5_3_3_AnalisisDeTareos")
        mnu6_1_9_ConsultarCodigos.Enabled = modulosPermitidos.Item("mnu6_1_9_ConsultarCodigos")
        mnu2_2_15_IngresosPersonal.Enabled = modulosPermitidos.Item("mnu2_2_15_IngresosPersonal")

        'Menu Actuales 2023-03-30'
        mnu5_3_4_GestionDeCostosDetalladoIndirecto.Enabled = modulosPermitidos.Item("mnu5_3_4_GestionDeCostosDetalladoIndirecto")
        mnu2_2_16_CorrespondenciaVacacional.Enabled = modulosPermitidos.Item("mnu2_2_16_CorrespondenciaVacacional") '2023-04-05
        mnu2_2_17_ControlIntermitencia.Enabled = modulosPermitidos.Item("mnu2_2_17_ControlIntermitencia") '2023-06-5'
        mnu4_1_3_Estandares.Enabled = modulosPermitidos.Item("mnu4_1_3_Estandares") '2023-06-02'
        mnu2_2_19_VacacionesGeneradas.Enabled = modulosPermitidos.Item("mnu2_2_19_VacionesGeneradas") '2023-09-15
        mnu7_1_3_ListadoPedidosMaquinaria.Enabled = modulosPermitidos.Item("mnu7_1_3_ListadoPedidosMaquinaria") '2023-09-26
        mnu8_2_2_ParteDeAcopioDeCampo.Enabled = modulosPermitidos.Item("mnu8_2_2_ParteDeAcopioDeCampo") '2023-10-13
        mnu11_3_2_RefrigeriosDelPersonal.Enabled = modulosPermitidos.Item("mnu11_3_2_RefrigeriosDelPersonal") '2023-10-30
        mnu2_2_21_SincronizarBoletas.Enabled = modulosPermitidos.Item("mnu2_2_21_SincronizarBoletas") '2023-10-30
        mnu2_3_5_ObservacionesMarcacion.Enabled = modulosPermitidos.Item("mnu2_3_5_ObservacionesMarcacion") '2023-10-30
        mnu2_2_22_Amonestaciones.Enabled = modulosPermitidos.Item("mnu2_2_22_Amonestaciones") '2023-12-19
        mnu2_2_23_ControlReclutamiento.Enabled = modulosPermitidos.Item("mnu2_2_23_ControlReclutamiento") '2024-01-11
        mnu2_2_24_ControlPersonal.Enabled = modulosPermitidos.Item("mnu2_2_24_ControlPersonal") '2024-01-11
        mnu2_2_25_InformeDirectorio.Enabled = modulosPermitidos.Item("mnu2_2_25_InformeDirectorio") '2024-01-22
        mnu2_3_6_ProgramacionVacaciones.Enabled = modulosPermitidos.Item("mnu2_3_6_ProgramacionVacaciones") '2023-10-30

        mnu2_2_18_SupervisionSSO.Enabled = modulosPermitidos.Item("mnu2_2_18_SupervisionSSO") '2023-06-08

        mnu2_2_26_RenovacionContratos.Enabled = modulosPermitidos.Item("mnu2_2_26_RenovacionContratos") '2024-01-22
        mnu2_2_27_ImpresionFormatos.Enabled = modulosPermitidos.Item("mnu2_2_27_ImpresionFormatos") '2024-01-22
        mnu4_2_6_Rendimientos.Enabled = modulosPermitidos.Item("mnu4_2_6_Rendimientos") '2021-01-26
        mnu10_2_7_DesviacionBC.Enabled = modulosPermitidos.Item("mnu10_2_7_DesviacionBC")
        mnu2_3_7_DistribucionHoras.Enabled = modulosPermitidos.Item("mnu2_3_7_DistribucionHoras") '2023-10-30
        mnu2_2_20_GeneradordeCodigodeBarras.Enabled = modulosPermitidos.Item("mnu2_2_20_GeneradordeCodigodeBarras") '2023-10-30


        mnu2_2_28_FormatoBoletas.Enabled = modulosPermitidos.Item("mnu2_2_28_FormatoBoletas") '2024-04-12

        mnu2_2_29_GenerarFotocheks.Enabled = modulosPermitidos.Item("mnu2_2_29_GenerarFotocheks") '2024-04-12
        mnu2_2_30_ReporteMarcaciones.Enabled = modulosPermitidos.Item("mnu2_2_30_ReporteMarcaciones") '2024-04-12


        mnu2_3_8_CalculoConceptosRemunerativos.Enabled = modulosPermitidos.Item("mnu2_3_8_CalculoConceptosRemunerativos") '2024-05-07 @Jota

        'Dim spid As String = doItBaby("sp_obtenerSPID", Nothing, TipoQuery.Scalar)
        'MessageBox.Show(spid)
        'Implentenacion para entrar a mantenimiento de usuarios por defecto 
        'mnu1_Mantenimiento.Enabled = True
        'mnu1_1_ConfigBases.Enabled = True
        'mnu1_2_MantenimientoUsuarios.Enabled = True

        'Inhabilitacion Temporal hasta implementacion
        mnuArchivo.Enabled = False
        stdEstado.Text = "Usuario: " + usuarioActual
        'stdEstado.Text = "Usuario: " + usuarioActual + " | SPID: " + spid
    End Sub

    Private Sub mnu2_2_2_UltimoDiaAsistencia_Click(sender As Object, e As EventArgs) Handles mnu2_2_2_UltimoDiaAsistencia.Click
        Dim VenActual As New frmRrhhUltimoDiaAsistencia
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_3_ReporteFaltas_Click(sender As Object, e As EventArgs) Handles mnu2_2_3_ReporteFaltas.Click
        Dim VenActual As New frmRrhh_Reportes_Faltas 'frmRrhhAsisRpteFaltas
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_1_ReporteAsistencia_Click(sender As Object, e As EventArgs) Handles mnu2_2_1_ReporteAsistencia.Click
        Dim VenActual As New frmRrhhReporteAsistencia
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_4_ReporteAsistenciaChronos_Click(sender As Object, e As EventArgs) Handles mnu2_2_4_ReporteAsistenciaChronos.Click
        Dim VenActual As New frmRrhhReporteAsistenciaChronos
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    'Private Sub mnu3_1_Reportes_Click(sender As Object, e As EventArgs) Handles mnu3_1_Reportes.Click
    '    Dim VenActual As New frmFitosanidad_RepAplicaciones
    '    VenActual.MdiParent = Me
    '    'VenActual.txtClave.PasswordChar = pwc
    '    'VenActual.btnGuardar.Enabled = False
    '    VenActual.Show()
    'End Sub

    Private Sub mnu1_1_ConfigBases_Click(sender As Object, e As EventArgs) Handles mnu1_1_ConfigBases.Click
        Dim VenActual As New frmConfigBases
        VenActual.MdiParent = Me
        VenActual.txtBLPassword.PasswordChar = pwc
        VenActual.txtBEPassword.PasswordChar = pwc
        VenActual.Show()
    End Sub

    Private Sub mnu1_2_MantenimientoUsuarios_Click(sender As Object, e As EventArgs) Handles mnu1_2_MantenimientoUsuarios.Click
        Dim VenActual As New frmMantenimientoUsuarios
        VenActual.MdiParent = Me
        VenActual.txtClave.PasswordChar = pwc
        VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu1_3_ActualizacionSistema_Click(sender As Object, e As EventArgs) Handles mnu1_3_ActualizacionSistema.Click
        Dim VenActual As New frmActualizarSistema
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_5_ValidarEstandares_Click(sender As Object, e As EventArgs) Handles mnu2_2_5_ValidarEstandares.Click
        Dim VenActual As New frmRrhhGestionEstandares_ValidarEstandares
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    'Private Sub mnu4_1_RegistrarTareos_Click(sender As Object, e As EventArgs) Handles mnu4_1_Movimientos.Click
    '    Dim VenActual As New frmSupervision_Movimientos_Tareos
    '    VenActual.MdiParent = Me
    '    VenActual.Show()
    'End Sub

    Private Sub mnu5_1_1_CierreDiario_Click(sender As Object, e As EventArgs) Handles mnu5_1_1_CierreDiario.Click
        Dim VenActual As New frmCostos_Procesos_CierreDiario
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_2_1_Reglas_Click(sender As Object, e As EventArgs) Handles mnu5_2_1_Reglas.Click
        Dim VenActual As New frmCostos_Tablas_Reglas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_1_FrutaProcesada_Click(sender As Object, e As EventArgs) Handles mnu6_1_1_FrutaProcesada.Click
        Dim VenActual As New frmPacking_Reportes_FrutaProcesada
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu7_1_1_ResumenUsoImplementoMaquinaLabor_Click(sender As Object, e As EventArgs) Handles mnu7_1_1_ResumenUsoImplementoMaquinaLabor.Click
        Dim VenActual As New frmMaquinaria_Reportes_ResumenUsoImplementoMaquinaLabor
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu8_1_1_Ingresos_Click(sender As Object, e As EventArgs) Handles mnu8_1_1_Ingresos.Click
        Dim VenActual As New frmAlmacenes_Reportes_Ingresos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_1_1_CosechaCampoConsolidado_Click(sender As Object, e As EventArgs) Handles mnu9_1_1_CosechaCampoConsolidado.Click
        Dim VenActual As New frmProduccion_Reportes_CosechaCampoConsolidado
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_2_1_ActualizarDatosPallets_Click(sender As Object, e As EventArgs) Handles mnu9_2_1_ActualizarDatosPallets.Click
        Dim VenActual As New frmProduccion_Movimientos_ActualizarDatosPallets
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_6_DetalleHorasPersonaActividadConsumidor_Click(sender As Object, e As EventArgs) Handles mnu2_2_6_DetalleDeHorasPersonaPorActividadYConsumidor.Click
        Dim VenActual As New frmRrhh_Reportes_CostoPersonal_DetalleHorasPersonaActividadConsumidor
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_2_1_FormatoTransferencia_Click(sender As Object, e As EventArgs) Handles mnu4_2_1_FormatoTransferencia.Click
        Dim VenActual As New frmSupervision_Reportes_FormatoTransferencia
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub ResumenDeTareosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu4_2_2_ResumenTareos.Click
        Dim VenActual As New frmSupervision_Reportes_ResumenTareos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub TareosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu4_1_1_Tareos.Click
        Dim VenActual As New frmSupervision_Movimientos_Tareos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_1_GenerarCodigosPacking_Click(sender As Object, e As EventArgs) Handles mnu6_2_1_GenerarCodigosPacking.Click
        Dim VenActual As New frmPacking_Movimientos_GenerarCodigosPacking
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_2_LecturaEficiencias_Click(sender As Object, e As EventArgs) Handles mnu6_2_2_LecturaEficiencias.Click
        Dim VenActual As New frmPacking_Movimientos_LecturaEficiencias
        'VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_1_2_Costeo_Click(sender As Object, e As EventArgs) Handles mnu9_1_2_Costeo.Click
        Dim VenActual As New frmProduccion_Reportes_Costeo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub


    Private Sub mnu6_2_3_TareosPacking_Click(sender As Object, e As EventArgs) Handles mnu6_2_3_TareosPacking.Click
        Dim VenActual As New frmPacking_Movimientos_TareosPacking
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_2_EficienciasEnVivo_Click(sender As Object, e As EventArgs) Handles mnu6_1_2_EficienciasEnVivo.Click
        Dim VenActual As New frmPacking_Reportes_EficienciasEnVivo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_1_GestionCostosDetallado_Click(sender As Object, e As EventArgs) Handles mnu5_3_1_GestionCostosDetallado.Click
        Dim VenActual As New frmCostos_Reportes_GestionCostosDetallado
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen_Click(sender As Object, e As EventArgs) Handles mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen.Click
        Dim VenActual As New frmPacking_Reportes_CajasXEmpaqueNisiraVsDatagreen
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_4_EficienciasPersonal_Click(sender As Object, e As EventArgs) Handles mnu6_1_4_EficienciasPersonal.Click
        Dim VenActual As New frmPacking_Reportes_EficienciasPersonal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_1_2_AsignacionCostosModulosProcesados_Click(sender As Object, e As EventArgs) Handles mnu5_1_2_AsignacionCostosModulosProcesados.Click
        Dim VenActual As New frmCostos_Procesos_AsignacionCostosModulosProcesados
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_7_CatalogoPersonal_Click(sender As Object, e As EventArgs) Handles mnu2_2_7_CatalogoDePersonal.Click
        Dim VenActual As New frmRrhh_Reportes_CatalogoPersonal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_4_DistribuirHorasXConsumidorPacking_Click(sender As Object, e As EventArgs) Handles mnu6_2_4_DistribuirHorasXConsumidorPacking.Click
        Dim VenActual As New frmPacking_Movimientos_DistribuirHorasXConsumidorPacking
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario_Click(sender As Object, e As EventArgs) Handles mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario.Click
        Dim VenActual As New frmFitosanidad_Movimientos_ActualizarRequerimientosProgramaSemanalDiario
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_1_BalanceComprobacion_Click(sender As Object, e As EventArgs) Handles mnu10_2_1_BalanceComprobacion.Click
        Dim VenActual As New frmContabilidad_Reportes_BalanceComprobacion
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_5_AlcanceEstandares_Click(sender As Object, e As EventArgs) Handles mnu6_1_5_AlcanceEstandares.Click
        Dim VenActual As New frmPacking_Reportes_AlcanceEstandares
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub frmMantenimiento_AbrirCerrarDias_Click(sender As Object, e As EventArgs) Handles mnu1_4_frmMantenimiento_AbrirCerrarDias.Click
        Dim VenActual As New frmMantenimiento_AbrirCerrarDias
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_1_RegistrarAltasMasivas_Click(sender As Object, e As EventArgs) Handles mnu2_3_1_RegistrarAltasMasivas.Click
        Dim VenActual As New frmRrhh_Movimientos_RegistrarAltasMasivas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_6_AlcanceEstandares_Click(sender As Object, e As EventArgs) Handles mnu6_1_6_AlcanceEstandares.Click
        Dim VenActual As New frmPacking_Reportes_UsabilidadCodigos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_1_1_DefinicionHorarios_Click(sender As Object, e As EventArgs) Handles mnu2_1_1_DefinicionDeHorarios.Click
        Dim VenActual As New frmRrhh_Movimientos_DefinicionHorarios
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_2_ReporteServicios_Click(sender As Object, e As EventArgs) Handles mnu5_3_2_ReporteServicios.Click
        Dim VenActual As New frmCostos_Reportes_ReporteServicios
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu8_1_2_RequerimientosInternos_Click(sender As Object, e As EventArgs) Handles mnu8_1_2_RequerimientosInternos.Click
        Dim VenActual As New frmAlmacenes_Reportes_RequerimientosInternos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_2_3_DetalleDiarioXSupuervisorGMO_Click(sender As Object, e As EventArgs) Handles mnu4_2_3_DetalleDiarioXSupuervisorGMO.Click
        Dim VenActual As New frmSupervision_Reportes_DetalleDiarioXSupuervisorGMO
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_1_1_CierreParrones_Click(sender As Object, e As EventArgs) Handles mnu10_1_1_CierreParrones.Click
        Dim VenActual As New frmContabilidad_Movimientos_CierreParrones
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_2_4_ControlHorasDiario_Click(sender As Object, e As EventArgs) Handles mnu4_2_4_ControlHorasDiario.Click
        Dim VenActual As New frmSupervision_Reportes_ControlHorasDiario
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_1_3_TablaCampanasCultivos_Click(sender As Object, e As EventArgs) Handles mnu9_1_3_TablaCampanasCultivos.Click
        Dim VenActual As New frmProduccion_Reportes_TablasCampanasCultivos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_3_HorasMaquinaXActividad_Click(sender As Object, e As EventArgs) Handles mnu5_3_3_HorasMaquinaXActividad.Click
        Dim VenActual As New frmCostos_Reportes_HorasMaquinaXActividad
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_2_5_ContrasteAsistencias_Click(sender As Object, e As EventArgs) Handles mnu4_2_5_ContrasteAsistencias.Click
        Dim VenActual As New frmSupervision_Reportes_ContrasteAsistencias
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_1_1_Vehiculos_Click(sender As Object, e As EventArgs) Handles mnu11_1_1_Vehiculos.Click
        Dim VenActual As New frmLogistica_Indices_Vehiculos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_1_3_ActualizarDataCosteo_Click(sender As Object, e As EventArgs) Handles mnu5_1_3_ActualizarDataCosteo.Click
        Dim VenActual As New frmCostos_Procesos_ActualizarDataCosteo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_1_2_Conductores_Click(sender As Object, e As EventArgs) Handles mnu11_1_2_Conductores.Click
        Dim VenActual As New frmLogistica_Indices_Conductores
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_1_3_CiudadesParaderos_Click(sender As Object, e As EventArgs) Handles mnu11_1_3_CiudadesParaderos.Click
        Dim VenActual As New frmLogistica_Indices_CiudadesParaderos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub RutasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu11_1_4_Rutas.Click
        Dim VenActual As New frmLogistica_Indices_Rutas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_2_1_ServiciosTransporte_Click(sender As Object, e As EventArgs) Handles mnu11_2_1_ServiciosTransporte.Click
        Dim VenActual As New frmLogistica_Movimientos_ServiciosTransporte
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub


    Private Sub mnu2_2_8_ReporteDeAusentismo_Click(sender As Object, e As EventArgs) Handles mnu2_2_8_ReporteDeAusentismo.Click
        Dim VenActual As New frmRrhh_Reportes_Ausentismo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_9_ReporteDeCeses_Click(sender As Object, e As EventArgs) Handles mnu2_2_9_ReporteDeCeses.Click
        Dim VenActual As New frmRrhh_Reportes_Ceses
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_10_ReporteDeConceptosXLiquidaciones_Click(sender As Object, e As EventArgs) Handles mnu2_2_10_ReporteDeConceptosXLiquidaciones.Click
        Dim VenActual As New frmRrhh_Reportes_ConceptosXLiquidaciones
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_11_AntecedentesInternos_Click(sender As Object, e As EventArgs) Handles mnu2_2_11_AntecedentesInternos.Click
        Dim VenActual As New frmRrhh_Reportes_AntecedentesInternos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_2_CostosAcumulados_Click(sender As Object, e As EventArgs) Handles mnu10_2_2_CostosAcumulados.Click
        Dim VenActual As New frmContabilidad_Reportes_CostosAcumulados
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_12_CalculoBonos_Click(sender As Object, e As EventArgs) Handles mnu2_2_12_CalculoBonos.Click
        Dim VenActual As New frmRrhh_Reportes_CalculoBonos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_2_ConfiguracionGruposLabores_Click(sender As Object, e As EventArgs) Handles mnu2_3_2_ConfiguracionGruposLabores.Click
        Dim VenActual As New frmRrhh_Movimientos_ConfiguracionGruposLabores
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_3_ConfiguracionBonos_Click(sender As Object, e As EventArgs) Handles mnu2_3_3_ConfiguracionBonos.Click
        Dim VenActual As New frmRrhh_Movimientos_ConfiguracionBonos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu3_1_1_ReporteAplicaciones_Click(sender As Object, e As EventArgs) Handles mnu3_1_1_ReporteAplicaciones.Click
        Dim VenActual As New frmFitosanidad_RepAplicaciones
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu3_1_2_ReporteEvaluaciones_Click(sender As Object, e As EventArgs) Handles mnu3_1_2_ReporteEvaluaciones.Click
        Dim VenActual As New frmFitosanidad_Reportes_Evaluaciones
        VenActual.MdiParent = Me
        'VenActual.txtClave.PasswordChar = pwc
        'VenActual.btnGuardar.Enabled = False
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_5_FusionarCajasBifurcadas_Click(sender As Object, e As EventArgs) Handles mnu6_2_5_FusionarCajasBifurcadas.Click
        Dim VenActual As New frmPacking_Movimientos_FusionarCajasBifurcadas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_1_4_PalletsDespachados_Click(sender As Object, e As EventArgs) Handles mnu9_1_4_PalletsDespachados.Click
        Dim VenActual As New frmProduccion_Reportes_PalletsDespachados
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu12_1_1_PackingList_Click(sender As Object, e As EventArgs) Handles mnu12_1_1_PackingList.Click
        Dim VenActual As New frmExportaciones_Reportes_PackingList
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu13_1_1_ControlPresupuestal_Click(sender As Object, e As EventArgs) Handles mnu13_1_1_ControlPresupuestal.Click
        Dim VenActual As New frmPresupuestos_Reportes_ControlPresupuestal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu9_1_5_CosechaYProduccion_Click(sender As Object, e As EventArgs) Handles mnu9_1_5_CosechaYProduccion.Click
        Dim VenActual As New frmProduccion_Reportes_CosechaYProduccion
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_4_AsistenciasGmo_Click(sender As Object, e As EventArgs) Handles mnu2_3_4_AsistenciasGmos.Click
        Dim VenActual As New frmRrhh_Movimientos_AsistenciaGmo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_3_FacturacionCobranzasExportacion_Click(sender As Object, e As EventArgs) Handles mnu10_2_3_FacturacionCobranzasExportacion.Click
        Dim VenActual As New frmContabilidad_Reportes_FacturacionCobranzasExportacion
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_4_ReporteG_Click(sender As Object, e As EventArgs) Handles mnu10_2_4_ReporteG.Click
        Dim VenActual As New frmContabilidad_Reportes_ReporteG
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    'Private Sub mnu10_1_2_ActualizarConfiguracionMaquinaria_Click(sender As Object, e As EventArgs) Handles mnu10_1_2_Maquinaria.Click
    '    Dim VenActual As New frmContabilidad_Movimientos_ActualizarConfiguracionesMaquinaria
    '    VenActual.MdiParent = Me
    '    VenActual.Show()
    'End Sub

    Private Sub mnu10_1_2_1_ActualizarConfiguraciones_Click(sender As Object, e As EventArgs) Handles mnu10_1_2_1_ActualizarConfiguraciones.Click
        Dim VenActual As New frmContabilidad_Movimientos_Maquinaria_ActualizarConfiguraciones
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_1_2_2_GenerarAsientosContables_Click(sender As Object, e As EventArgs) Handles mnu10_1_2_2_GenerarAsientosContables.Click
        Dim VenActual As New frmContabilidad_Movimientos_Maquinaria_GenerarAsientosContables
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_5_ConsumosDeAlmacenVsContabilidad_Click(sender As Object, e As EventArgs) Handles mnu10_2_5_ConsumosDeAlmacenVsContabilidad.Click
        Dim VenActual As New frmContabilidad_Reportes_ConsumosAlmacenVsContabilidad
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_6_IngresoBancosDetalladoFactura_Click(sender As Object, e As EventArgs) Handles mnu10_2_6_IngresoBancosDetalladoFactura.Click
        Dim VenActual As New frmContabilidad_Reportes_IngresoBancosDetalladoFactura
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_6_HorasADistribuir_Click(sender As Object, e As EventArgs) Handles mnu6_2_6_HorasADistribuir.Click
        Dim VenActual As New frmPacking_Movimientos_HorasADistribuir
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_2_2_GenerarPedidosServicioTransporte_Click(sender As Object, e As EventArgs) Handles mnu11_2_2_GenerarPedidosServicioTransporte.Click
        Dim VenActual As New frmLogistica_Movimientos_GenerarPedidoServicio
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_13_ResumenPlanillas_Click(sender As Object, e As EventArgs) Handles mnu2_2_13_ResumenPlanillas.Click
        Dim VenActual As New frmRrhh_Reportes_ResumenPlanillas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu3_2_1_CrearProgramasSemanales_Click(sender As Object, e As EventArgs) Handles mnu3_2_1_CrearProgramasSemanales.Click
        Dim VenActual As New frmFitosanidad_Movimientos_CrearProgramasSemanales
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu8_2_1_CargarPedidosDeCompra_Click(sender As Object, e As EventArgs) Handles mnu8_2_1_CargarPedidosDeCompra.Click
        Dim VenActual As New frmAlmacenes_Movimientos_CargarPedidosCompra
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu8_1_3_PedidosDeCompra_Click(sender As Object, e As EventArgs) Handles mnu8_1_3_PedidosDeCompra.Click
        Dim VenActual As New frmAlmacenes_Reportes_PedidosCompra
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_1_2_DistribucionHorasXGaritas_Click(sender As Object, e As EventArgs) Handles mnu4_1_2_DistribucionHorasXGaritas.Click
        Dim VenActual As New frmSupervision_Movimientos_DistribucionHorasXGaritas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_14_PlanillaAsistencia_Click(sender As Object, e As EventArgs) Handles mnu2_2_14_PlanillaAsistencia.Click
        'mnu2_2_14_PlanillaAsistencia
        Dim VenActual As New frmRrhh_Reportes_PlanillaAsistencia
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu13_1_2_ResumenPresupuestoGrupoSubgrupo_Click(sender As Object, e As EventArgs) Handles mnu13_1_2_ResumenPresupuestoGrupoSubgrupo.Click
        Dim VenActual As New frmPresupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu13_1_3_PresupuestoGeneral_Click(sender As Object, e As EventArgs) Handles mnu13_1_3_PresupuestoGeneral.Click
        Dim VenActual As New frmPresupuestos_Reportes_PresupuestoGeneral
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu13_1_4_SeguimientoPresupuestal_Click(sender As Object, e As EventArgs) Handles mnu13_1_4_SeguimientoPresupuestal.Click
        Dim VenActual As New frmPresupuestos_Reportes_SeguimientoPresupuestal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu13_1_5_PresupuestoX_Click(sender As Object, e As EventArgs) Handles mnu13_1_5_PresupuestoX.Click
        Dim VenActual As New frmPresupuestos_Reportes_PresupuestoX
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_7_SeguimientoPlanComercial_Click(sender As Object, e As EventArgs) Handles mnu6_1_7_SeguimientoPlanComercial.Click
        Dim VenActual As New frmPacking_Reportes_SeguimientoPlanComercial
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_8_StockPallets_Click(sender As Object, e As EventArgs) Handles mnu6_1_8_StockPallets.Click
        Dim VenActual As New frmPacking_Reportes_StockPallets
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_2_7_ManteniminetoPlanesComerciales_Click(sender As Object, e As EventArgs) Handles mnu6_2_7_ManteniminetoPlanesComerciales.Click
        Dim VenActual As New frmPacking_Movimientos_MantenimientoPlanesComerciales
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_3_AnalisisDeTareos_Click(sender As Object, e As EventArgs) Handles mnu5_3_3_AnalisisDeTareos.Click
        Dim VenActual As New frmCostos_Reportes_AnalisisTareos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu6_1_9_ConsultarCodigos_Click(sender As Object, e As EventArgs) Handles mnu6_1_9_ConsultarCodigos.Click
        Dim VenActual As New frmPacking_Reportes_ConsultarCodigos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_15_IngresosPersonal_Click(sender As Object, e As EventArgs) Handles mnu2_2_15_IngresosPersonal.Click
        Dim VenActual As New frmRrhh_Reportes_IngresosPersonal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_4_GestionDeCostosDetalladoIndirecto_Click(sender As Object, e As EventArgs) Handles mnu5_3_4_GestionDeCostosDetalladoIndirecto.Click
        Dim VenActual As New frmCostos_Reportes_GestionCostosDetalladoIndirectos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu5_3_5_GestionDeCostosPorTipoCosto_Click(sender As Object, e As EventArgs) Handles mnu5_3_5_GestionDeCostosPorTipoCosto.Click
        Dim VenActual As New frmCostos_Reportes_Costos_Tipo_Costos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu11_3_1_TransportePersonalXConsumidor_Click(sender As Object, e As EventArgs) Handles mnu11_3_1_TransportePersonalXConsumidor.Click
        Dim VenActual As New frmLogistica_Reportes_TransportePersonalXConsumidor
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_16_CorrespondenciaVacacional_Click(sender As Object, e As EventArgs) Handles mnu2_2_16_CorrespondenciaVacacional.Click
        Dim VenActual As New frmRrhh_Reportes_CorrespondenciaVacacional
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu7_1_2_HorasMaquinariasXLote_Click(sender As Object, e As EventArgs) Handles mnu7_1_2_HorasMaquinariasXLote.Click
        Dim VenActual As New frmMaquinarias_Movimientos_CargarPedidosPartesMaquinarias
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub MantenimientoDePesajeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDePesajeToolStripMenuItem.Click
        Dim VenActual As New frmPesaje
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub EstandaresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles mnu4_1_3_Estandares.Click
        Dim VenActual As New frmEstandares
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_17_ControlIntermitencia_Click(sender As Object, e As EventArgs) Handles mnu2_2_17_ControlIntermitencia.Click
        Dim VenActual As New frmRrhh_Reportes_ControlIntermitencia
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_18_SupervisionSSO_Click(sender As Object, e As EventArgs) Handles mnu2_2_18_SupervisionSSO.Click
        Dim VenActual As New frmRrhh_Reportes_SupervisordeSSO
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_19_VacionesGeneradas_Click(sender As Object, e As EventArgs) Handles mnu2_2_19_VacacionesGeneradas.Click
        Dim VenActual As New frmRrhh_Reportes_VacacionesGeneradas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_20_GeneradordeCodigodeBarras_Click(sender As Object, e As EventArgs) Handles mnu2_2_20_GeneradordeCodigodeBarras.Click
        Dim VenActual As New frmRrhh_Reportes_GeneradordeCodigodeBarras
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu7_1_3_ListadoPedidosMaquinaria_Click(sender As Object, e As EventArgs) Handles mnu7_1_3_ListadoPedidosMaquinaria.Click
        Dim VenActual As New frmMaquinarias_Movimientos_CargarPedidosPartesMaquinarias_Nisira
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu8_2_2_ParteDeAcopioDeCampo_Click(sender As Object, e As EventArgs) Handles mnu8_2_2_ParteDeAcopioDeCampo.Click
        Dim VenActual As New frmAlmacenes_Movimientos_ParteDeAcopioDeCampo
        VenActual.MdiParent = Me
        VenActual.Show()

    End Sub

    Private Sub mnu2_2_21_SincronizarBoletas_Click(sender As Object, e As EventArgs) Handles mnu2_2_21_SincronizarBoletas.Click
        Dim VenActual As New frmRrhh_Reportes_SincronizarBoletas
        VenActual.MdiParent = Me
        VenActual.Show()

    End Sub

    Private Sub mnu11_3_2_RefrigeriosDelPersonal_Click(sender As Object, e As EventArgs) Handles mnu11_3_2_RefrigeriosDelPersonal.Click
        Dim VenActual As New frmRrhh_Reportes_RefrigeriosDelPersonal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub BloqueoDeIngresoPorRenovacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu2_3_5_ObservacionesMarcacion.Click
        Dim VenActual As New frmRrhh_Movimientos_ObservacionesMarcacion
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_22_Amonestaciones_Click(sender As Object, e As EventArgs) Handles mnu2_2_22_Amonestaciones.Click
        Dim VenActual As New frmRrhh_Reportes_Amonestaciones
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_23_ProgramacionVacaciones_Click(sender As Object, e As EventArgs) Handles mnu2_2_23_ControlReclutamiento.Click
        Dim VenActual As New frmRrhh_Reportes_ControlReclutamiento
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_24_ControlPersonal_Click(sender As Object, e As EventArgs) Handles mnu2_2_24_ControlPersonal.Click
        Dim VenActual As New frmRrhh_Reportes_ControlPersonal
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_25_InformeDirectorio_Click(sender As Object, e As EventArgs) Handles mnu2_2_25_InformeDirectorio.Click
        Dim VenActual As New frmRrhh_Reportes_InformeDirectorio
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_6_ProgramacionVacaciones_Click(sender As Object, e As EventArgs) Handles mnu2_3_6_ProgramacionVacaciones.Click
        Dim VenActual As New frmRrhh_Movimientos_ProgramacionVacaciones
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_26_RenovacionContratos_Click(sender As Object, e As EventArgs) Handles mnu2_2_26_RenovacionContratos.Click
        Dim VenActual As New frmRrhh_Reportes_RenovacionContratos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_27_ImpresionFormatos_Click(sender As Object, e As EventArgs) Handles mnu2_2_27_ImpresionFormatos.Click
        Dim VenActual As New frmRrhh_Reportes_ImpresionFormatos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu4_2_6_Rendimientos_Click(sender As Object, e As EventArgs) Handles mnu4_2_6_Rendimientos.Click
        Dim VenActual As New frmSupervision_Reportes_Rendimientos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu10_2_7_DesviacionBC_Click(sender As Object, e As EventArgs) Handles mnu10_2_7_DesviacionBC.Click
        Dim VenActual As New frmContabilidad_Reportes_DesviacionBC
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_7_DistribucionHoras_Click(sender As Object, e As EventArgs) Handles mnu2_3_7_DistribucionHoras.Click
        Dim VenActual As New frmRrhh_Movimientos_DistribucionHoras
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_28_FormatoBoletas_Click(sender As Object, e As EventArgs) Handles mnu2_2_28_FormatoBoletas.Click
        Dim VenActual As New frmRrhh_Reportes_FormatoBoletas
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub GenerarFotochecksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnu2_2_29_GenerarFotocheks.Click
        Dim VenActual As New frmRrhh_Reportes_GenerarFotocheck
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_2_30_ReporteMarcaciones_Click(sender As Object, e As EventArgs) Handles mnu2_2_30_ReporteMarcaciones.Click
        Dim VenActual As New frmRrhh_Reportes_ReporteMarcacionesChronos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_8_AsistenciaDataGreen_Click(sender As Object, e As EventArgs) Handles mnu2_3_8_AsistenciaDataGreen.Click
        Dim VenActual As New frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mnu2_3_8_CalculoConceptosRemunerativos_Click(sender As Object, e As EventArgs) Handles mnu2_3_8_CalculoConceptosRemunerativos.Click
        Dim VenActual As New frmRrhh_Movimientos_CalculoConceptosRemunerativos
        VenActual.MdiParent = Me
        VenActual.Show()
    End Sub

    Private Sub mdiPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        MessageBox.Show("finaso")
    End Sub

End Class
