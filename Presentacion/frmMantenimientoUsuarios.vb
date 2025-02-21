Imports Logica
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports System.Data.SqlClient
Imports Datos.Conexion
Imports DocumentFormat.OpenXml.Drawing

Public Class frmMantenimientoUsuarios

    Public tablaPersonas As DataTable
    Dim bsPersonas As New BindingSource()
    Dim nodoActual As String = String.Empty

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        cbxActivo.Enabled = False
        cbxActivo.Checked = False
        cbxActivoMG.Enabled = False
        cbxActivoMG.Checked = False

        cbxDataGreen.Enabled = True
        cbxDataGreen.Checked = False
        cbxMiniGreen.Enabled = True
        cbxMiniGreen.Checked = False

        lblDataGreen.Text = "DataGreen: NO"
        lblMiniGreen.Text = "MiniGreen: NO"
        lblDataGreen.ForeColor = Color.Red
        lblMiniGreen.ForeColor = Color.Red

        Dim usuario As New DataTable
        usuario = consultarUsuario()
        'SI EL USUARIO EXISTE
        If usuario.Rows.Count = 1 Then
            txtAPaterno.Text = usuario.Rows(0).Item(2).ToString
            txtAMaterno.Text = usuario.Rows(0).Item(3).ToString
            txtNombres.Text = usuario.Rows(0).Item(4).ToString
            txtUsuario.Text = usuario.Rows(0).Item(5).ToString
            txtClave.Text = "NO SEAS SAPO" 'usuario.Rows(0).Item(6).ToString
            btnGuardar.Enabled = True
            'EXISTE EN ERP???
            If usuario.Rows(0).Item(1).ToString <> "" Then
                'SI EXISTE
                lblERP.ForeColor = Color.Green
                lblERP.Text = "ERP: SI"
            Else
                'NO EXISTE
                lblERP.ForeColor = Color.Red
                lblERP.Text = "ERP: NO"
            End If
            'EXISTE EN DATAGREEN o MINIGREEN???
            If usuario.Rows(0).Item(0).ToString <> "" Or usuario.Rows(0).Item(9).ToString <> "" Then
                'SI EXISTE en ALGUNO
                If usuario.Rows(0).Item(0).ToString <> "" Then
                    'EXISTE EB DG
                    lblDataGreen.ForeColor = Color.Green
                    lblDataGreen.Text = "DataGreen: SI"
                    cbxActivo.Enabled = True
                    cbxActivo.Checked = If(RTrim(LTrim(usuario.Rows(0).Item(8).ToString())).Equals("1"), True, False)
                    cbxDataGreen.Enabled = False
                    cbxDataGreen.Checked = True

                    Dim aux As String = traducePermisos(usuario.Rows(0).Item(7), True)
                    cargarPermisosDeUsuarioEnArbol(aux, tviModulosPermitidos)
                End If

                If usuario.Rows(0).Item(9).ToString <> "" Then
                    'EXISTE EB MG
                    lblMiniGreen.ForeColor = Color.Green
                    lblMiniGreen.Text = "MiniGreen: SI"
                    cbxActivoMG.Enabled = True
                    cbxActivoMG.Checked = If(RTrim(LTrim(usuario.Rows(0).Item(10).ToString())).Equals("AC"), True, False)
                    cbxMiniGreen.Enabled = False
                    cbxMiniGreen.Checked = True
                    'Dim aux As String = traducePermisos(usuario.Rows(0).Item(7), True)
                    'cargarPermisosDeUsuarioEnArbol(aux, tviModulosPermitidos)
                End If

                btnCambiarClave.Enabled = True
                txtClave.PasswordChar = pwc
                txtClave.Enabled = False
                lblInfoClave.Text = ""

            Else
                'NO EXISTE EN NINGUNO
                lblDataGreen.ForeColor = Color.Red
                lblDataGreen.Text = "DataGreen: NO"
                lblMiniGreen.ForeColor = Color.Red
                lblMiniGreen.Text = "MiniGreen: NO"
                txtUsuario.Text = txtNombres.Text(0) + txtAPaterno.Text.Replace(" ", "")
                txtClave.Text = txtDni.Text
                txtClave.PasswordChar = ""
                txtClave.Enabled = True
                btnCambiarClave.Enabled = False
                lblInfoClave.Text = "* La clave por defecto es el numero de DNI."
                cbxActivo.Enabled = True
                cbxActivo.Checked = False
                cbxActivoMG.Enabled = True
                cbxActivoMG.Checked = False
                For Each nodo As TreeNode In tviModulosPermitidos.Nodes
                    descheckear(nodo)
                Next
                txtClave.Focus()
            End If


            'SI EL USUARIO NO EXISTE EN NIGUN LADO
        ElseIf usuario.Rows.Count = 0 Then
            MessageBox.Show("Usuario no existe en ERP")
            lblERP.Text = "ERP: __"
            lblDataGreen.Text = "DataGreen: __"
            txtDni.Text = ""
            txtAPaterno.Text = ""
            txtAMaterno.Text = ""
            txtNombres.Text = ""
            txtUsuario.Text = ""
            txtClave.Text = "" 'txtDni.Text
            btnCambiarClave.Enabled = False
            btnGuardar.Enabled = False
            cbxActivo.Checked = False
        ElseIf usuario.Rows.Count > 1 Then
            MessageBox.Show("Error de registro, el usuario se encuentra registrado mas de 1 vez en ERP")
        End If
    End Sub

    Private Function consultarUsuario() As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dni", txtDni.Text)
        Dim Resultado As DataTable
        Resultado = doItBaby("spConsultarUsuario", p, TipoQuery.DataTable)
        Return Resultado
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim controlDG As Boolean
        Dim controlMG As Boolean

        If cbxDataGreen.Checked Then
            If txtClave.Text.Length < 8 Then
                MessageBox.Show("La clave debe tener al menos 8 caracteres")

            Else
                Dim permisos As String = ""
                obtenerPermisosDeUsuarioDesdeArbol(permisos, tviModulosPermitidos)
                permisos = traducePermisos(permisos, False)
                If guardarUsuario(permisos) IsNot Nothing Then
                    controlDG = True
                    'MessageBox.Show("Registro guardado correctamente")
                Else
                    controlDG = False
                    'MessageBox.Show("Error al intentar guardar registro")
                End If
            End If
        End If

        If cbxMiniGreen.Checked Then
            Dim permisos As String = ""
            obtenerPermisosDeUsuarioDesdeArbol(permisos, tviModulosPermitidos)
            permisos = traducePermisos(permisos, False)
            If guardarUsuarioMiniGreen(permisos) IsNot Nothing Then
                controlMG = True
                'MessageBox.Show("Registro guardado correctamente")
            Else
                controlMG = False
                'MessageBox.Show("Error al intentar guardar registro")
            End If
        End If

        If (controlDG And controlMG) Then
            MessageBox.Show("Registro guardado correctamente en DataGreen y MiniGreen")
        ElseIf (controlDG And Not (controlMG)) Then
            MessageBox.Show("Registro guardado correctamente SOLO en DataGreen")
        ElseIf (Not (controlDG) And controlMG) Then
            MessageBox.Show("Registro guardado correctamente SOLO en DataGreen")
        Else
            MessageBox.Show("Error al intentar guardar registro")
        End If


    End Sub

    Private Function guardarUsuario(ByVal permisos As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dni", txtDni.Text)
        p.Add("@Usuario", txtUsuario.Text)
        p.Add("@Clave", hashMd5(txtClave.Text))
        p.Add("@Permisos", permisos)
        p.Add("@Estado", cbxActivo.Checked)
        Try
            Return doItBaby("spGuardarUsuario", p, TipoQuery.NonQuery)
        Catch
            Return False
        End Try
    End Function

    Private Function guardarUsuarioMiniGreen(ByVal permisos As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dni", txtDni.Text)
        p.Add("@Nombres", txtNombres.Text)
        p.Add("@Apaterno", txtAPaterno.Text)
        p.Add("@Amaterno", txtAMaterno.Text)
        p.Add("@Usuario", txtUsuario.Text)
        p.Add("@Clave", hashMd5Otra(txtUsuario.Text + txtDni.Text))
        'p.Add("@Clave", hashMd5Otra(txtUsuario.Text + txtDni.Text))
        p.Add("@Permisos", "111111")
        p.Add("@Estado", If(cbxActivoMG.Checked, "AC", "IN"))
        Try
            Return doItBaby("spGuardarUsuarioMiniGreen", p, TipoQuery.NonQuery)
        Catch
            Return False
        End Try
    End Function

    Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click
        Dim VenActual As New frmCambiarClave(txtDni.Text)
        VenActual.MdiParent = Me.MdiParent
        VenActual.txtNuevaClave.PasswordChar = pwc
        VenActual.txtConfirmarClave.PasswordChar = pwc
        VenActual.Show()
    End Sub

    Private Sub txtDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDni.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConsultar.Focus()
            btnConsultar_Click(sender, e)
        End If
    End Sub

    Private Sub frmMantenimientoUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        cargarMenusEnArbol()
        tviModulosPermitidos.ExpandAll()
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        '
        obtenerTablaPersonas()
        cargarDgvResultado()
        tlpPrincipal.Visible = True
        txtFiltro.Focus()
    End Sub

    Private Sub obtenerTablaPersonas()
        tablaPersonas = doItBaby("sp_Dg_Mantenimientos_MantenimientoUsuarios_CargarData", Nothing, TipoQuery.DataTable)
    End Sub

    'Public Function execSp_Dg_Mantenimientos_MantenimientoUsuarios_CargarData()
    '    Dim r As New DataTable
    '    Try
    '        r = doItBaby("sp_Dg_Mantenimientos_MantenimientoUsuarios_CargarData", Nothing, TipoQuery.DataTable)
    '        Return r
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function
    'Private Sub tviModulosPermitidos_BeforeCollapse(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tviModulosPermitidos.BeforeCollapse
    '    e.Cancel = True
    'End Sub

    Private Sub cargarDgvResultado()
        dgvResultado.Columns.Clear()
        dgvResultado.DataSource = Nothing
        Dim dvPersonas As New DataView(tablaPersonas)
        bsPersonas.DataSource = dvPersonas
        dgvResultado.DataSource = bsPersonas

        corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()
    End Sub

    Private Sub cargarMenusEnArbol()
        'AGREGARMENU PASO 4: AGREGAR EL MENU AQUI PARA PODER USARLO EN EL MANTENIMIENTO DE USUARIOS
        'ESTE ES EL PASO FINAL PARA AGREGAR MENUS

        'Menus
        tviModulosPermitidos.Nodes.Add("mnu1_Mantenimiento", "Mantenimiento")
        tviModulosPermitidos.Nodes.Add("mnu2_RecursosHumanos", "Recursos Humanos")
        tviModulosPermitidos.Nodes.Add("mnu3_Fitosanidad", "Fitosanidad")
        tviModulosPermitidos.Nodes.Add("mnu4_Supervision", "Supervision")
        tviModulosPermitidos.Nodes.Add("mnu5_Costos", "Costos") '16-07-2020
        tviModulosPermitidos.Nodes.Add("mnu6_Packing", "Packing") '24-07-2020
        tviModulosPermitidos.Nodes.Add("mnu7_Maquinaria", "Maquinaria") '24-07-2020
        tviModulosPermitidos.Nodes.Add("mnu8_Almacenes", "Almacenes") '27-07-2020
        tviModulosPermitidos.Nodes.Add("mnu9_Produccion", "Produccion") '29-07-2020
        tviModulosPermitidos.Nodes.Add("mnu10_Contabilidad", "Contabilidad") '27-10-2020
        tviModulosPermitidos.Nodes.Add("mnu11_Logistica", "Logistica") '28-01-2021
        tviModulosPermitidos.Nodes.Add("mnu12_Exportaciones", "Exportaciones") '2021-08-11
        tviModulosPermitidos.Nodes.Add("mnu13_Presupuestos", "Presupuestos") '2021-08-19
        'tviModulosPermitidos.Nodes.Add("mnu13_Presupuestosdssds", "sdsdsdsd") '2021-08-19

        ''Submenus
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_1_ConfigBases", "Configurar Bases")
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_2_MantenimientoUsuarios", "Mantenimiento de Usuarios")
        'tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_1_Asistencia", "Asistencia")
        tviModulosPermitidos.Nodes(2).Nodes.Add("mnu3_1_Reportes", "Reportes")
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_3_ActualizacionSistema", "Actualizacion de Sistema") '30-06-2020
        tviModulosPermitidos.Nodes(2).Nodes.Add("mnu3_2_Movimientos", "Movimientos") '2020-10-27
        'tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_2_GestioEstandares", "Gestion de Estandares") '04-07-2020
        tviModulosPermitidos.Nodes(3).Nodes.Add("mnu4_1_Movimientos", "Movimientos") '04-07-2020
        tviModulosPermitidos.Nodes(4).Nodes.Add("mnu5_1_Procesos", "Procesos") '16-07-2020
        tviModulosPermitidos.Nodes(4).Nodes.Add("mnu5_2_Tablas", "Tablas") '17-07-2020
        tviModulosPermitidos.Nodes(5).Nodes.Add("mnu6_1_Reportes", "Reportes") '24-07-2020
        tviModulosPermitidos.Nodes(6).Nodes.Add("mnu7_1_Reportes", "Reportes") '24-07-2020
        tviModulosPermitidos.Nodes(7).Nodes.Add("mnu8_1_Reportes", "Reportes") '27-07-2020
        tviModulosPermitidos.Nodes(8).Nodes.Add("mnu9_1_Reportes", "Reportes") '27-07-2020
        tviModulosPermitidos.Nodes(8).Nodes.Add("mnu9_2_Movimientos", "Movimientos") '02-08-2020
        'tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_3_CostosPersonal", "Costos de Personal")
        tviModulosPermitidos.Nodes(3).Nodes.Add("mnu4_2_Reportes", "Reportes") '24-08-2020
        tviModulosPermitidos.Nodes(5).Nodes.Add("mnu6_2_Movimientos", "Movimientos") '25-08-2020
        tviModulosPermitidos.Nodes(4).Nodes.Add("mnu5_3_Reportes", "Reportes") '30-09-2020
        'tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_4_CatalogoPersonal", "Catalogo de Personal") '07-10-2020
        tviModulosPermitidos.Nodes(9).Nodes.Add("mnu10_1_Movimientos", "Movimientos") '27-10-2020
        tviModulosPermitidos.Nodes(9).Nodes.Add("mnu10_2_Reportes", "Reportes") '27-10-2020
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_4_frmMantenimiento_AbrirCerrarDias", "Abrir Cerrar Dias") '13-11-2020
        'tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_5_Movimientos", "Movimientos") '20-11-2020
        tviModulosPermitidos.Nodes(10).Nodes.Add("mnu11_1_Indices", "Indices") '28-01-2021
        tviModulosPermitidos.Nodes(10).Nodes.Add("mnu11_2_Movimientos", "Movimientos") '2021-03-13
        tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_1_Indices", "Indices") '2021-03-29
        tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_2_Reportes", "Reportes") '2021-03-29
        tviModulosPermitidos.Nodes(1).Nodes.Add("mnu2_3_Movimientos", "Movimientos") '2021-03-29
        tviModulosPermitidos.Nodes(11).Nodes.Add("mnu12_1_Reportes", "Reportes")
        tviModulosPermitidos.Nodes(12).Nodes.Add("mnu13_1_Reportes", "Reportes") '2021-08-19

        tviModulosPermitidos.Nodes(7).Nodes.Add("mnu8_2_Movimientos", "Movimientos") '2022-02-14

        'SubSubmenus
        'tviModulosPermitidos.Nodes(1).Nodes(0).Nodes.Add("mnu2_1_1_ReporteAsistencia", "Reporte de Asistencia")
        'tviModulosPermitidos.Nodes(1).Nodes(0).Nodes.Add("mnu2_1_2_UltimoDiaAsistencia", "Ultimo Dia De Asistencia")
        'tviModulosPermitidos.Nodes(1).Nodes(0).Nodes.Add("mnu2_1_3_ReporteFaltas", "Reporte de Faltas")
        'tviModulosPermitidos.Nodes(1).Nodes(0).Nodes.Add("mnu2_1_4_ReporteAsistenciaChronos", "Reporte de Asistencia Chronos")
        'tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_1_ValidarEstandares", "Validar Estandares") '04-07-2020
        tviModulosPermitidos.Nodes(4).Nodes(0).Nodes.Add("mnu5_1_1_CierreDiario", "Cierre Diario") '04-07-2020
        tviModulosPermitidos.Nodes(4).Nodes(1).Nodes.Add("mnu5_2_1_Reglas", "Reglas") '17-07-2020
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_1_FrutaProcesada", "Fruta Procesada") '24-07-2020
        tviModulosPermitidos.Nodes(6).Nodes(0).Nodes.Add("mnu7_1_1_ResumenUsoImplementoMaquinaLabor", "Resumen De Uso De Implemento Maquina Y Labor") '24-07-2020
        tviModulosPermitidos.Nodes(6).Nodes(0).Nodes.Add("mnu7_1_2_HorasMaquinariasXLote", "Horas Maquinarias por Lote") '2023-04-20'
        tviModulosPermitidos.Nodes(6).Nodes(0).Nodes.Add("mnu7_1_3_ListadoPedidosMaquinaria", "Listado de Pedidos Maquinaria (Nisira)") '2023-09-26
        tviModulosPermitidos.Nodes(7).Nodes(0).Nodes.Add("mnu8_1_1_Ingresos", "Ingresos") '24-07-2020
        tviModulosPermitidos.Nodes(8).Nodes(0).Nodes.Add("mnu9_1_1_CosechaCampoConsolidado", "Cosecha Campo Consolidado")
        tviModulosPermitidos.Nodes(8).Nodes(1).Nodes.Add("mnu9_2_1_ActualizarDatosPallets", "Actualizar Datos de Pallets")
        'tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_1_DetalleHorasPersonaActividadConsumidor", "Detalle de Horas Persona Por Actividad y Consumidor")
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_1_FormatoTransferencia", "Formato de Transferencia")
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_2_ResumenTareos", "Resumen de Tareos")
        tviModulosPermitidos.Nodes(3).Nodes(0).Nodes.Add("mnu4_1_1_Tareos", "Tareos")
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_1_GenerarCodigosPacking", "Generar Codigos Packing") '25-08-2020
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_2_LecturaEficiencias", "Lectura de Eficiencias") '25-08-2020
        tviModulosPermitidos.Nodes(8).Nodes(0).Nodes.Add("mnu9_1_2_Costeo", "Costeo")
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_3_TareosPacking", "Tareos Packing") '08-09-2020
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_2_EficienciasEnVivo", "Eficiencias en Vivo") '29-09-2020
        tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_1_GestionCostosDetallado", "Gestion de Costos Detallado") '30-09-2020
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_3_CajasXEmpaqueNisiraVsDatagreen", "Cajas X Empaque Nisira Vs Datagreen") '05-10-2020
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_4_EficienciasPersonal", "Eficiencias de Personal") '05-10-2020
        tviModulosPermitidos.Nodes(4).Nodes(0).Nodes.Add("mnu5_1_2_AsignacionCostosModulosProcesados", "Asignacion de Costos a los Modulos Procesados") '05-10-2020
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_4_DistribuirHorasXConsumidorPacking", "Distribuir Horas X Consumidor Packing") '09-10-2020
        tviModulosPermitidos.Nodes(2).Nodes(1).Nodes.Add("mnu3_2_1_ActualizarRequerimientosProgramaSemanalDiario", "Actualizar Requerimientos Programa Semanal/Diario") ''2020-10-27
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_1_BalanceComprobacion", "Balance de Comprobacion") '2020-10-27
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_5_AlcanceEstandares", "Alcance de Estandares") '31-10-2020
        'tviModulosPermitidos.Nodes(1).Nodes(4).Nodes.Add("mnu2_5_1_RegistrarAltasMasivas", "Registrar Altas Masivas")
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_6_AlcanceEstandares", "Usabilidad de Codigos") '23-11-2020
        'tviModulosPermitidos.Nodes(1).Nodes(4).Nodes.Add("mnu2_5_2_DefinicionHorarios", "Definicion de Horarios")
        tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_2_ReporteServicios", "Reporte de Servicios") '04122020
        'tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_2_ReporteServicios", "Reporte de Servicios") '04122020
        tviModulosPermitidos.Nodes(7).Nodes(0).Nodes.Add("mnu8_1_2_RequerimientosInternos", "Requerimientos Internos") '2020-12-31
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_3_DetalleDiarioXSupuervisorGMO", "Detalle Diario X Supuervisor GMO")
        tviModulosPermitidos.Nodes(9).Nodes(0).Nodes.Add("mnu10_1_1_CierreParrones", "Cierre de Parrones") '2021-01-05
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_4_ControlHorasDiario", "Control de Horas Diario")
        tviModulosPermitidos.Nodes(8).Nodes(0).Nodes.Add("mnu9_1_3_TablaCampanasCultivos", "Tablas De Campañas y Cultivos")
        tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_3_HorasMaquinaXActividad", "Horas Maquina X Actividad") '2021-01-19
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_5_ContrasteAsistencias", "Contraste de Asistencias")
        tviModulosPermitidos.Nodes(10).Nodes(0).Nodes.Add("mnu11_1_1_Vehiculos", "Vehiculos") '2021-01-28
        tviModulosPermitidos.Nodes(4).Nodes(0).Nodes.Add("mnu5_1_3_ActualizarDataCosteo", "Actualizar Data de Costeo") '2021-02-02
        tviModulosPermitidos.Nodes(10).Nodes(0).Nodes.Add("mnu11_1_2_Conductores", "Conductores") '2021-02-09
        tviModulosPermitidos.Nodes(10).Nodes(0).Nodes.Add("mnu11_1_3_CiudadesParaderos", "Ciudades / Paraderos") '2021-02-16
        tviModulosPermitidos.Nodes(10).Nodes(0).Nodes.Add("mnu11_1_4_Rutas", "Rutas") '2021-02-16
        tviModulosPermitidos.Nodes(10).Nodes(1).Nodes.Add("mnu11_2_1_ServiciosTransporte", "Servicios de Transporte") '2021-03-13
        tviModulosPermitidos.Nodes(1).Nodes(0).Nodes.Add("mnu2_1_1_DefinicionDeHorarios", "Definicion de Horarios") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_1_ReporteAsistencia", "Reporte De Asistencia") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_2_UltimoDiaAsistencia", "Ultimo Dia Asistencia") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_3_ReporteFaltas", "Reporte De Faltas") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_4_ReporteAsistenciaChronos", "Reporte Asistencia Chronos") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_5_ValidarEstandares", "Validar Estandares") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_6_DetalleDeHorasPersonaPorActividadYConsumidor", "Detalle De Horas Persona Por Actividad Y Consumidor") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_7_CatalogoDePersonal", "Catalogo de Personal") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_1_RegistrarAltasMasivas", "Registrar Altas Masivas") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_8_ReporteDeAusentismo", "Reporte De Ausentismo") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_9_ReporteDeCeses", "Reporte De Ceses") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_10_ReporteDeConceptosXLiquidaciones", "Reporte De Conceptos X Liquidaciones") '2021-02-16
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_11_AntecedentesInternos", "Antecedentes Internos") '2021-03-30
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_2_CostosAcumulados", "Costos Acumulados") '2021-05-03
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_12_CalculoBonos", "Calculo de Bonos") '2021-05-03
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_2_ConfiguracionGruposLabores", "Configuracion De Grupos De Labores") '2021-05-06
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_3_ConfiguracionBonos", "Configuracion De Bonos") '2021-05-11
        tviModulosPermitidos.Nodes(2).Nodes(0).Nodes.Add("mnu3_1_1_ReporteAplicaciones", "Reporte De Aplicaciones") '2021-07-29
        tviModulosPermitidos.Nodes(2).Nodes(0).Nodes.Add("mnu3_1_2_ReporteEvaluaciones", "Reporte De Evaluaciones") '2021-07-29
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_5_FusionarCajasBifurcadas", "Fusionar Cajas Bifurcadas") '02-08-2021
        tviModulosPermitidos.Nodes(8).Nodes(0).Nodes.Add("mnu9_1_4_PalletsDespachados", "Pallets Despachados") '2021-08-11
        tviModulosPermitidos.Nodes(11).Nodes(0).Nodes.Add("mnu12_1_1_PackingList", "Packing List") '2021-02-09
        tviModulosPermitidos.Nodes(12).Nodes(0).Nodes.Add("mnu13_1_1_ControlPresupuestal", "Control Presupuestal") '2021-02-19
        tviModulosPermitidos.Nodes(8).Nodes(0).Nodes.Add("mnu9_1_5_CosechaYProduccion", "Cosecha Y Produccion") '2021-08-21 
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_4_AsistenciasGmo", "Asistencia Gmo") '2021-08-31
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_3_FacturacionCobranzasExportacion", "Facturacion Y Cobranzas De Exportacion") '2021-09-13
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_4_ReporteG", "Reporte G") '2021-09-28
        'tviModulosPermitidos.Nodes(9).Nodes(0).Nodes.Add("mnu10_1_2_ActualizarConfiguracionesMaquinaria", "Actualizar Configuraciones Maquinaria") '2021-09-29'
        tviModulosPermitidos.Nodes(9).Nodes(0).Nodes.Add("mnu10_1_2_Maquinaria", "Maquinaria")
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_5_ConsumosDeAlmacenVsContabilidad", "Consumos De Almacen Vs Contabilidad") '2021-09-29
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_6_IngresoBancosDetalladoFactura", "Ingreso A Bancos Detallado X Factura") '2021-10-20
        tviModulosPermitidos.Nodes(10).Nodes(1).Nodes.Add("mnu11_2_2_GenerarPedidosServicioTransporte", "Generar Pedidos de Servicios de Transporte") '2021-03-13
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_13_ResumenPlanillas", "Resumen de Planillas") '2022-01-28
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_14_PlanillaAsistencia", "Planilla De Asistencia") '2022-04-08


        tviModulosPermitidos.Nodes(2).Nodes(1).Nodes.Add("mnu3_2_1_CrearProgramasSemanales", "Crear Programas Semanales") ''2022-02-10
        tviModulosPermitidos.Nodes(7).Nodes(1).Nodes.Add("mnu8_2_1_CargarPedidosDeCompra", "Cargar Pedidos De Compra") '2022-02-14
        tviModulosPermitidos.Nodes(7).Nodes(0).Nodes.Add("mnu8_1_3_PedidosDeCompra", "Pedidos De Compra") '2022-02-15
        tviModulosPermitidos.Nodes(3).Nodes(0).Nodes.Add("mnu4_1_2_DistribucionHorasXGaritas", "Distribucion De Horas X Garitas")

        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_7_SeguimientoPlanComercial", "Seguimiento De Plan Comercial") '22-06-2022 
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_8_StockPallets", "Stock De Pallets") '22-06-2022 
        tviModulosPermitidos.Nodes(5).Nodes(0).Nodes.Add("mnu6_1_9_ConsultarCodigos", "Consultar Codigos") '22-06-2022 
        tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_3_AnalisisDeTareos", "Analisis De Tareos") '2022-09-29

        'SubSubSubMenu
        tviModulosPermitidos.Nodes(9).Nodes(0).Nodes(1).Nodes.Add("mnu10_1_2_1_ActualizarConfiguraciones", "Actualizar Configuraciones")
        tviModulosPermitidos.Nodes(9).Nodes(0).Nodes(1).Nodes.Add("mnu10_1_2_2_GenerarAsientosContables", "Generar Asientos Contables")
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_6_HorasADistribuir", "Horas A Distribuir") '2021-11-15

        tviModulosPermitidos.Nodes(12).Nodes(0).Nodes.Add("mnu13_1_2_ResumenPresupuestoGrupoSubgrupo", "Resumen De Presupuesto Por Grupo Y Subgrupo") '2022-04-26
        tviModulosPermitidos.Nodes(12).Nodes(0).Nodes.Add("mnu13_1_3_PresupuestoGeneral", "Presupuesto General") '2022-04-28
        tviModulosPermitidos.Nodes(12).Nodes(0).Nodes.Add("mnu13_1_4_SeguimientoPresupuestal", "Seguimiento Presupuestal") '2022-04-29
        tviModulosPermitidos.Nodes(12).Nodes(0).Nodes.Add("mnu13_1_5_PresupuestoX", "Presupuesto X") '2022-05-02
        tviModulosPermitidos.Nodes(5).Nodes(1).Nodes.Add("mnu6_2_7_ManteniminetoPlanesComerciales", "Mantenimiento De Planes Comerciales") '2022-06-25
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_15_IngresosPersonal", "Ingresos De Personal") '2022-11-24

        'SubMenus actuales 2023-03-30 '
        tviModulosPermitidos.Nodes(4).Nodes(2).Nodes.Add("mnu5_3_4_GestionDeCostosDetalladoIndirecto", "Gestion de Costos Indirectos Detallado")
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_16_CorrespondenciaVacacional", "Correspondencia Vacacional") '2023-04-05
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_17_ControlIntermitencia", "Control de Intermitencia") '2023-06-05
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_18_SupervisionSSO", " Supervisión de SSO") '2023-06-08
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu4_1_3_Estandares", "Estandares") '2023-06-02
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_19_VacionesGeneradas", "Vacaciones Generadas") '2023-09-15
        'tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu7_1_3_ListadoPedidosMaquinaria", "Listado de Pedidos Maquinaria (Nisira)") '26-09-2023
        tviModulosPermitidos.Nodes(7).Nodes(1).Nodes.Add("mnu8_2_2_ParteDeAcopioDeCampo", "Parte de Acopio de Campo") '13-10-2023
        tviModulosPermitidos.Nodes(10).Nodes(1).Nodes.Add("mnu11_3_2_RefrigeriosDelPersonal", "Refrigerios Del Personal") '30-10-2023
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_21_SincronizarBoletas", "Sincronizar Boletas") '30-10-2023
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_5_ObservacionesMarcacion", "Observaciones de Marcacion") '2021-08-31
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_22_Amonestaciones", "Reporte de Amonestaciones") '19-12-2023
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_23_ControlReclutamiento", "Control de Reclutamiento") '19-12-2023
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_24_ControlPersonal", "Control de Personal") '18-01-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_25_InformeDirectorio", "Informe de Directorio") '18-01-2024
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_6_ProgramacionVacaciones", "Programacion de Vacaciones") '2024-01-30
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_26_RenovacionContratos", "Renovacion de Contratos") '18-01-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_27_ImpresionFormatos", "Impresion de Formatos") '15-02-2024
        tviModulosPermitidos.Nodes(3).Nodes(1).Nodes.Add("mnu4_2_6_Rendimientos", "Rendimientos")
        tviModulosPermitidos.Nodes(9).Nodes(1).Nodes.Add("mnu10_2_7_DesviacionBC", "Desviacion BC") '2021-10-20
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_7_DistribucionHoras", "Distribucion de Horas") '2024-01-30
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_20_GeneradordeCodigodeBarras", "Generador de Codigo de Barras") '2024-01-30

        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_28_FormatoBoletas", "Boletas de Pago") '12-04-2024

        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_29_GenerarFotocheks", "Generar Fotochecks") '12-04-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_30_ReporteMarcaciones", "Reporte de Marcaciones") '12-04-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_31_ComparativaUltimosMovimientosPlanilla", "Comparativa de Ultimos Movimientos de Planilla") '11-07-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_32_CheckListCalculoPlanilla", "Check List de Calculo de Planilla") '16-07-2024
        tviModulosPermitidos.Nodes(1).Nodes(1).Nodes.Add("mnu2_2_33_ReporteDelCtaCteDelPersonal", "Reporte del Cta. Cte del Personal") '13-09-2024


        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_8_CalculoConceptosRemunerativos", "Calculo de Conceptos Remunerativos") '2024-05-07

        ' HATCH 21-11-2024
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_5_PrivilegiosUsuariosFormularios", "Privilegios de Usuario - Formularios") '21-11-2024
        tviModulosPermitidos.Nodes(0).Nodes.Add("mnu1_6_ConfiguracionLongitudCodigoGeneral", "Configuracion de Longitud de Codigo General") '21-11-2024
        ' HATCH 10-12-2024
        tviModulosPermitidos.Nodes(1).Nodes(2).Nodes.Add("mnu2_3_9_ConvertirTareosAsistencias", "Convertir Tareos a Asistencias") '10-12-2024
    End Sub

    Private Sub cargarPermisosDeUsuarioEnArbol(bitsDePermisos As String, arbol As TreeView)
        Dim i As Integer = 0
        'Dim aux As New Dictionary(Of String, Boolean)
        'RECORRE DICCIONARIO PARA SETEAR VALORES
        For Each j As KeyValuePair(Of String, Boolean) In modulosPermitidos
            'If bitsDePermisos.Count() <= i Then
            SetearValoresEnArbol(j.Key, bitsDePermisos.ElementAt(i) = "1", arbol)
            'aux.Add((j.Key), bitsDePermisos.ElementAt(i) = "1")
            i = i + 1
            'End If
        Next j
        'modulosPermitidos = aux
    End Sub

    Public Shared Sub obtenerPermisosDeUsuarioDesdeArbol(ByRef cadenaPermisos As String, arbol As TreeView)
        'Dim resultado As String = ""
        'Dim i As Integer = 0
        For Each j As KeyValuePair(Of String, Boolean) In modulosPermitidos
            'SetearValoresEnArbol(j.Key, bitsDePermisos.ElementAt(i) = "1", arbol)
            'aux.Add((j.Key), bitsDePermisos.ElementAt(i) = "1")
            cadenaPermisos = cadenaPermisos + ObtenerValoresEnArbol(j.Key, arbol)
            'i = i + 1
        Next j
        'modulosPermitidos = aux
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsPersonas.Filter = String.Format("Dni like '%{0}%' Or " +
                                                 "Usuario like '%{1}%' Or " +
                                                 "Nombres like '%{2}%' Or " +
                                                 "Paterno like '%{3}%' Or " +
                                                 "Materno like '%{4}%'",
                                                 txtFiltro.Text,
                                                 txtFiltro.Text,
                                                 txtFiltro.Text,
                                                 txtFiltro.Text,
                                                 txtFiltro.Text)

    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            txtDni.Text = dgvResultado.Rows(e.RowIndex).Cells(2).Value
            btnConsultar_Click(sender, e)
        End If
    End Sub

    Private Sub tviModulosPermitidos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tviModulosPermitidos.AfterCheck
        If e.Node.Checked Then
            If Not e.Node.Parent Is Nothing Then
                e.Node.Parent.Checked = True
            End If
        ElseIf Not e.Node.Nodes Is Nothing And nodoActual <> e.Node.Name.ToString Then
            descheckear(e.Node)
        End If
        
    End Sub

    Private Sub descheckear(treeNode As TreeNode)
        nodoActual = treeNode.Name.ToString
        treeNode.Checked = False
        For Each nodo As TreeNode In treeNode.Nodes
            descheckear(nodo)
        Next
    End Sub

    Private Sub txtNombres_TextChanged(sender As Object, e As EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub txtDni_TextChanged(sender As Object, e As EventArgs) Handles txtDni.TextChanged
        'If cbxMiniGreen.Checked Then
        '    txtUsuario.Text = txtDni.Text
        'End If

    End Sub

    Private Sub tlpPrincipal_Paint(sender As Object, e As PaintEventArgs) Handles tlpPrincipal.Paint

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDni.Enabled = True
        txtNombres.Enabled = True
        txtAPaterno.Enabled = True
        txtAMaterno.Enabled = True
        txtUsuario.Enabled = True

        txtDni.Text = ""
        txtNombres.Text = ""
        txtAPaterno.Text = ""
        txtAMaterno.Text = ""
        txtUsuario.Text = ""

        cbxDataGreen.Checked = False
        cbxDataGreen.Enabled = True

        cbxMiniGreen.Checked = False
        cbxMiniGreen.Enabled = True

        cbxActivo.Checked = False
        cbxActivoMG.Checked = False


    End Sub

    Private Sub cbxMiniGreen_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMiniGreen.CheckedChanged
        If cbxMiniGreen.Checked Then
            cbxActivoMG.Enabled = True
        End If
    End Sub

    Private Sub cbxDataGreen_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDataGreen.CheckedChanged
        If cbxDataGreen.Checked Then
            cbxActivo.Enabled = True
        End If
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged

    End Sub
End Class