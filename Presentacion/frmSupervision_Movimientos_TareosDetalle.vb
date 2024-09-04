Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion
Imports System.IO
Imports Microsoft.ReportingServices.Diagnostics.Internal
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Microsoft.Reporting.Map.WebForms.BingMaps

Public Class frmSupervision_Movimientos_TareosDetalle
    Dim tareoActual As New Tareo
    Dim detalleTareoActual As DetalleTareo
    'Dim detalleTareoActual As New Dictionary(Of String, String)
    Dim dataParaControles As New Dictionary(Of String, DataTable)
    Dim itemEliminar As Integer
    Dim valorItem As String = String.Empty
    Dim dscontroles As DataSet
    Dim tablaParaDgvResultado As New DataTable
    Dim tablaPersonalJustificado As New DataTable

    Dim changeActividad As Boolean = False
    Dim changeLabor As Boolean = False
    Dim changeConsumidor As Boolean = False
    Dim changeHoras As Boolean = False
    Dim changeRendimiento As Boolean = False

    Dim filaSeleccionada As Integer = -1

    Dim indicadorParaBGW As Integer = 0
    Dim showToolstrip As Boolean = False

    Public Sub New(tareoSeleccionado As Tareo)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        tareoActual = tareoSeleccionado
        'dscontroles = tablas
        'dgvResultado.MultiSelect = False
        'cargarControles()
    End Sub

    Private Sub frmSupervision_Movimientos_TareosDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(tareoActual.Id)
        aplicarTema(Me)
        detalleTareoActual = New DetalleTareo(tareoActual.Id)
        tlpPrincipal.Visible = False
        'iniciarDetalleTareo()
        inicializarDataParaDgvResultado()
        obtenerDataParaCombos()
        cargarControles()
        actualizarCabeceraDeDetalle()
        'lblDin_IdTareo.Text = tareoActual.Id
        listarDetalle()
        'cargarControles()
        'dgvResultado.DataSource = dataParaDgvResultado
        'formatearDataGridView(dgvResultado)
        'dgvResultado.Columns(0).Visible = False
        'dgvResultado.Columns(2).Visible = False

        'actualizarCabeceraDeDetalle()
        txtDni.CharacterCasing = CharacterCasing.Upper
        bloquearControl(btnActualizar)


        bloquearCabecera()
        bloquearControl(btnPuntitos)
        bloquearControl(txtRutaExcel)
        bloquearControl(btnImportar)
        tlpPrincipal.Visible = True


        'cargarControles()
        ''BLOQUEO TEMPORAL HASTA DEFINIR PROCESO DE EDICION.

        'PENDIENTE RESOLVER ESTO PARA QUE NO ESTE EN DURO
        If tareoActual.DniResponsable = usuarioActual Or usuarioActual = "JMERA" Or usuarioActual <> "JSIESQUEN" Or usuarioActual <> "JCRUZ" Then
            desbloquearControl(btnEditar)
            'desbloquearControl(btnEliminar)
            'btnEditar.Enabled = True
        Else
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
        End If
        bloquearControl(btnCancelar)
        lblDin_Resultado.Text = "Registros: " + dgvResultado.RowCount.ToString
        gboFiltrar.Visible = False
    End Sub

    Private Sub obtenerDataParaCombos()
        dataParaControles.Add("Cultivos", doItBaby("sp_Dg_ObtenerCultivos", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Actividades", doItBaby("sp_Dg_ObtenerActividades", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Consumidores", doItBaby("sp_Dg_ObtenerConsumidores", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Personas", doItBaby("sp_Dg_ObtenerPersonasActivas", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("PersonasCesadas", doItBaby("sp_Dg_ObtenerPersonasCesadas", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Horas", doItBaby("sp_Dg_ObtenerHoras", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Minutos", doItBaby("sp_Dg_ObtenerMinutos", Nothing, Datos.Conexion.TipoQuery.DataTable))
        dataParaControles.Add("Hectareas", doItBaby("sp_Dg_ObtenerHectareasConsumidores", Nothing, Datos.Conexion.TipoQuery.DataTable))

        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", "0000")
        dataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable))


    End Sub

    Private Sub actualizarCabeceraDeDetalle()
        lblDin_IdTareo.Text = detalleTareoActual.Id
        lblDin_Estado.Text = detalleTareoActual.Estado ' "Pendiente"
        lblDin_IdTransferencia.Text = "00000000000"
        lblDin_Item.Text = detalleTareoActual.Item '"0" ' dgvResultado.RowCount().ToString
        lblDin_Campana.Text = detalleTareoActual.Campana ' "0000"
        lblDin_FechaInicio.Text = tareoActual.Fecha.ToShortDateString
        If lblDin_Item.Text <> "0" Then
            txtDni.Text = String.Concat(detalleTareoActual.Trabajador, " | ", detalleTareoActual.Dni)
            txtHoras.Text = detalleTareoActual.SubTotalHoras
            txtRendimiento.Text = detalleTareoActual.SubTotalRendimiento
        End If
        'If detalleTareoActual.Cultivo IsNot Nothing AndAlso detalleTareoActual.Cultivo.Length > 0 Then
        '    cboCultivo.SelectedValue = detalleTareoActual.Cultivo
        '    cboCultivo_SelectionChangeCommitted(New Object, New System.EventArgs)
        'End If
        If detalleTareoActual.IdCultivo IsNot Nothing AndAlso detalleTareoActual.IdCultivo.Length > 0 Then
            cboCultivo.SelectedValue = detalleTareoActual.IdCultivo
            cboCultivo_SelectionChangeCommitted(New Object, New System.EventArgs)
        End If
        'If detalleTareoActual.Variedad IsNot Nothing AndAlso detalleTareoActual.Variedad.Length > 0 Then
        '    cboVariedad.SelectedValue = detalleTareoActual.Variedad
        'End If
        If detalleTareoActual.IdVariedad IsNot Nothing AndAlso detalleTareoActual.IdVariedad.Length > 0 Then
            cboVariedad.SelectedValue = detalleTareoActual.IdVariedad

        End If
        'If detalleTareoActual.Actividad IsNot Nothing AndAlso detalleTareoActual.Actividad.Length > 0 Then
        '    cboActividad.SelectedValue = detalleTareoActual.Actividad
        '    cboActividad_SelectionChangeCommitted(New Object, New System.EventArgs)
        'End If
        If detalleTareoActual.IdActividad IsNot Nothing AndAlso detalleTareoActual.IdActividad.Length > 0 Then
            cboActividad.SelectedValue = detalleTareoActual.IdActividad
            cboActividad_SelectionChangeCommitted(New Object, New System.EventArgs)
        End If
        If detalleTareoActual.IdLabor IsNot Nothing AndAlso detalleTareoActual.IdLabor.Length > 0 Then
            cboLabor.SelectedValue = detalleTareoActual.IdLabor
        End If
        If detalleTareoActual.Consumidor IsNot Nothing AndAlso detalleTareoActual.Consumidor.Length > 0 Then
            cboConsumidor.SelectedValue = detalleTareoActual.Consumidor
        End If
        If detalleTareoActual.Campana IsNot Nothing AndAlso detalleTareoActual.Campana.Length > 0 Then
            lblDin_Campana.Text = detalleTareoActual.Campana
        End If
        'If tareoActual.Estado = "N" Then
        '    bloquearControl(btnEditar)
        '    bloquearControl(btnEliminar)
        'End If
    End Sub

    'Private Sub iniciarDetalleTareo()
    '    detalleTareoActual.Add("id", "")
    '    detalleTareoActual.Add("item", "")
    '    detalleTareoActual.Add("idTransferencia", "")
    '    detalleTareoActual.Add("estado", "")
    '    detalleTareoActual.Add("dni", "")
    '    detalleTareoActual.Add("planilla", "")
    '    detalleTareoActual.Add("consumidor", "")
    '    detalleTareoActual.Add("campana", "")
    '    detalleTareoActual.Add("cultivo", "")
    '    detalleTareoActual.Add("variedad", "")
    '    detalleTareoActual.Add("actividad", "")
    '    detalleTareoActual.Add("labor", "")
    '    detalleTareoActual.Add("inicio", "")
    '    detalleTareoActual.Add("fin", "")
    '    detalleTareoActual.Add("subTotalHoras", "")
    '    detalleTareoActual.Add("subTotalRendimientos", "")
    'End Sub

    Private Sub listarDetalle()

        Dim usuario As String = Temporales.usuarioActual
        dgvResultado.DataSource = Nothing
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "TR" Then
        'OBTENER DATOS DEL DETALLE
        Dim parametros = New Dictionary(Of String, Object)
        parametros.Add("@IdTareo", tareoActual.Id)
        Dim aux As DataTable
        aux = doItBaby("sp_Dg_Supervision_Movimientos_Tareos_ListarDetalle", parametros, Datos.Conexion.TipoQuery.DataTable)
        If aux IsNot Nothing Then
            'aux.Columns.Add("Observacion")
            tablaParaDgvResultado = aux.Copy
        End If
        'ElseIf tareoActual.Estado = "L" Then
        'PENDIENTE DESDE SQLITE
        'End If


        'obtener data sqlite
        'Dim auxSqlite As DataSet = New DataSet
        'auxSqlite = execSqlitePorNombre("selectSqliteTareos", Nothing, 3)
        'dataSetInicial.Tables(3).Merge(auxSqlite.Tables(0), True, MissingSchemaAction.Ignore)
        corregirTabla(tablaParaDgvResultado)
        dgvResultado.DataSource = tablaParaDgvResultado

        'Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        'dgvColumnCheck = New DataGridViewCheckBoxColumn()
        'dgvColumnCheck.Name = "CheckSel"
        'dgvColumnCheck.HeaderText = "Sel"
        'dgvResultado.Columns.Insert(0, dgvColumnCheck)

        formatearDataGridView(dgvResultado)
        'dgvResultado.Columns(0).Visible = False
        'dgvResultado.Columns(2).Visible = False
        'corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()

        ''VISTA SIMPLIFICADA
        'If usuario = "JCRUZ" Then
        '    dgvResultado.Columns("T_IdTareo").Visible = False
        '    dgvResultado.Columns("T_IdTransferencia").Visible = False
        '    dgvResultado.Columns("T_IdPlanilla").Visible = False
        '    dgvResultado.Columns("T_Campana").Visible = False
        '    dgvResultado.Columns("T_IdCultivo").Visible = False
        '    dgvResultado.Columns("T_IdVariedad").Visible = False
        '    dgvResultado.Columns("H1Ingreso").Visible = False
        '    dgvResultado.Columns("H1Salida").Visible = False
        '    dgvResultado.Columns(0).Visible = False
        'End If


        'Dim chekMasivo As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

        'chekMasivo.HeaderText = "Total"
        'chekMasivo.Name = "chekMasivo"
        'chekMasivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'chekMasivo.FlatStyle = FlatStyle.Standard
        'chekMasivo.ThreeState = True
        'chekMasivo.CellTemplate = New DataGridViewCheckBoxCell()
        'chekMasivo.CellTemplate.Style.BackColor = Color.Beige
        'dgvResultado.Columns.Insert(0, chekMasivo)
    End Sub

    Private Sub cargarControles()
        'LLENAR TODOS LOS CONTROLES
        'cargarCombo(cboCultivo, dataParaControles.Tables(0), "", True)
        cargarCombo(cboCultivo, dataParaControles.Item("Cultivos"), 0, 2)
        'cboCultivo_Leave(New Object, New EventArgs)
        cargarCombo(cboActividad, dataParaControles.Item("Actividades"), 0, 2)
        'cboActividad_Leave(New Object, New EventArgs)
        cargarCombo(cboConsumidor, dataParaControles.Item("Consumidores"), 0, 2)
        'cboConsumidor_Leave(New Object, New EventArgs)
        cargarCombo(cboVariedad, dataParaControles.Item("Variedades"), 0, 2)

        cargarCombo(cboHhInicio, dataParaControles.Item("Horas"))
        cargarCombo(cboMmInicio, dataParaControles.Item("Minutos"))
        cargarCombo(cboHhFin, dataParaControles.Item("Horas").Copy)
        cargarCombo(cboMmFin, dataParaControles.Item("Minutos").Copy)

        'textboxTrabajadores
        Dim listaTrabajadores As New AutoCompleteStringCollection
        For Each fila As DataRow In dataParaControles.Item("Personas").Rows
            listaTrabajadores.Add(fila.Item(2).ToString)
        Next
        txtDni.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDni.AutoCompleteCustomSource = listaTrabajadores
        txtDni.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub radRango_CheckedChanged(sender As Object, e As EventArgs) Handles radRango.CheckedChanged
        If radRango.Checked Then
            'tlpRango.Enabled = True
            desbloquearRango()
            lblHoras.Enabled = False
            txtHoras.Enabled = False
        End If
    End Sub

    Private Sub radHorasFijas_CheckedChanged(sender As Object, e As EventArgs) Handles radHorasFijas.CheckedChanged
        If radHorasFijas.Checked Then
            bloquearRango()
            'tlpRango.Enabled = False
            lblHoras.Enabled = True
            txtHoras.Enabled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'CARGAR DATA DE TABLA EXCEL
        capturarDatos()
        If detalleTareoActual.SubTotalHoras <= 0 Then
            MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
            Exit Sub
        ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
            MessageBox.Show("Debe ingresar un Dni vállido.")
            Exit Sub
        End If
        'crearFila()
        'If lblDin_Item.Text = "0" Then
        '    insertarFila()
        'Else
        '    actualizarFila()
        'End If
        insertarFila()
        corregirTabla(tablaParaDgvResultado)
        formatearDataGridView(dgvResultado)
        resaltarObservaciones()
        'corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()
        lblDin_Item.Text = "0"
        desbloquearControl(btnGuardar)
        txtDni.Text = ""
        txtDni.Focus()
    End Sub

    Private Sub bloquearCabecera()
        bloquearControl(btnEliminar)
        bloquearControl(btnGuardar)
        bloquearControl(btnTransferir)
        'bloquearControl(gboDetalle)
        gboDetalle.Enabled = False
        bloquearControl(btnActualizar)
        bloquearControl(btnAgregar)

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede editar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If

        If cboCultivo.Items.Count < 1 Then
            cargarControles()
        End If
        gboDetalle.Enabled = True
        desbloquearControl(btnAgregar)
        'MODIFICACION PARA IMPORTAR EXCEL
        desbloquearControl(btnPuntitos)
        desbloquearControl(txtRutaExcel)
        desbloquearControl(btnImportar)
        'FIN MODIFICACION
        bloquearControl(btnEditar)
        desbloquearControl(btnEliminar)
        desbloquearControl(btnCancelar)
        dgvResultado.ClearSelection()
        'ESTA VARIABLE SIRVE PARA MOSTRAR EL TOOLSTRIP EN LA GRILLA DE DETALLES AL MOMENTO DE PRESIONAR
        'CLICK DERECHO
        showToolstrip = True
        'desbloquearControl(gboDetalle)
        pkrFin.Value = tareoActual.Fecha
    End Sub

    'Private Sub cboConsumidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboConsumidor.SelectedValueChanged
    '    If cboConsumidor.Items.Count > 0 Then
    '        Dim anioCampana As String = "S/C"
    '        For Each fila As DataRow In dataParaControles.Tables(5).Rows
    '            If cboConsumidor.SelectedValue IsNot Nothing Then
    '                If fila.Item(0) = cboConsumidor.SelectedValue.ToString And fila.Item(2) <= tareoActual.Fecha _
    '                And fila.Item(3) >= tareoActual.Fecha Then
    '                    anioCampana = fila.Item(1).ToString
    '                End If
    '            End If
    '        Next
    '        lblDin_Campana.Text = anioCampana
    '    End If
    'End Sub

    Private Function obtenerDni() As String
        Dim dni As String = String.Empty
        For Each ch As Char In txtDni.Text
            If Char.IsDigit(ch) Then
                dni += ch
            End If
        Next
        Return dni
    End Function

    Private Function obtenerTrabajador() As String
        Dim trabajador As String = String.Empty
        Dim aux As String = String.Empty
        Dim encontrado As Boolean = False

        For Each fila As DataRow In tablaPersonalJustificado.Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                detalleTareoActual.Observacion = "016"
            End If
        Next

        For Each fila As DataRow In dataParaControles.Item("Personas").Rows 'dataParaControles.Tables(8).Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                aux = fila.Item(2).ToString
                encontrado = True
                For Each ch As Char In aux
                    If Char.IsLetter(ch) Or ch = " " Then
                        trabajador += ch
                    End If
                Next
                Return trabajador
                Exit For
            End If
        Next

        detalleTareoActual.Observacion = "001" 'TRABAJADOR CESADO

        'BUSCA EN TABLA DE CESADOS
        For Each fila As DataRow In dataParaControles.Item("PersonasCesadas").Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                aux = fila.Item(1).ToString
                encontrado = True
                Return aux
                Exit For
            End If
        Next
        detalleTareoActual.Observacion = "002" 'TRABAJADOR DESCONOCIDO       

        Return aux
    End Function

    Private Function obtenerPlanilla() As String
        'Dim planilla As String = String.Empty
        For Each fila As DataRow In dataParaControles.Item("Personas").Rows 'dataParaControles.Tables(8).Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                Return fila.Item(3).ToString
                Exit For
            End If
        Next
        Return String.Empty
    End Function

    'Private Function obtenerCultivoOVariedad(consumidor As String, valorRequerido As Char) As String
    '    For Each fila As DataRow In dataParaControles.Tables(8).Rows
    '        If fila.Item(0).ToString = detalleTareoActual.Dni Then
    '            Return fila.Item(3).ToString
    '            Exit For
    '        End If
    '    Next
    '    Return String.Empty
    'End Function

    'Private Function obtenerVariedad(consumidor As String) As String
    '    'Dim planilla As String = String.Empty
    '    For Each fila As DataRow In dataParaControles.Tables(8).Rows
    '        If fila.Item(0).ToString = detalleTareoActual.Dni Then
    '            Return fila.Item(3).ToString
    '            Exit For
    '        End If
    '    Next
    '    Return String.Empty
    'End Function

    Private Function obtenerFechaInicio() As Date
        Dim fechaHora As DateTime = Nothing
        Dim aux As String
        Dim hh As String = "00"
        Dim mm As String = "00"
        If radRango.Checked Then
            hh = cboHhInicio.SelectedValue ' IIf(cboHhInicio.SelectedIndex >= 0, cboMmInicio.SelectedValue, "00")
            mm = cboMmInicio.SelectedValue ' IIf(cboMmInicio.SelectedIndex >= 0, cboMmInicio.SelectedValue, "00")
        End If
        aux = String.Concat(tareoActual.Fecha.ToShortDateString, " ", hh, ":", mm, ":00")
        fechaHora = CType(aux, DateTime)
        Return fechaHora
    End Function

    Private Function obtenerFechaFin() As Date
        Dim fechaHora As DateTime = Nothing
        Dim aux As String
        Dim hh As String = "00"
        Dim mm As String = "00"
        If radRango.Checked Then
            hh = cboHhFin.SelectedValue '  IIf(cboHhFin.SelectedIndex >= 0, cboHhFin.SelectedValue, "00")
            mm = cboMmFin.SelectedValue  'IIf(cboMmFin.SelectedIndex >= 0, cboMmFin.SelectedValue, "00")
        End If
        aux = String.Concat(pkrFin.Value.ToShortDateString, " ", hh, ":", mm, ":00")
        fechaHora = CType(aux, DateTime)
        Return fechaHora
    End Function

    Private Function obtenerHoras() As Double
        Dim diferencia As Integer = 0
        If radHorasFijas.Checked Then
            If txtHoras.Text <> "" Then
                Return CType(txtHoras.Text, Double)
            End If
        Else
            diferencia = DateDiff(DateInterval.Minute, detalleTareoActual.Inicio, detalleTareoActual.Fin)
        End If
        Return CType(diferencia / 60, Double)
    End Function

    Private Sub capturarDatos()
        'If lblDin_Item.Text = "0" Then 
        'If tablaParaDgvResultado.Rows.Count > 0 Then
        '    'detalleTareoActual.Item = dgvResultado.Rows.Count + 1
        '    detalleTareoActual.Item = CType(tablaParaDgvResultado.Compute("MAX(Item)", "Dni<>''"), Integer) + 1
        'Else
        'detalleTareoActual.Item += 1
        'End If
        detalleTareoActual.Observacion = ""
        detalleTareoActual.Estado = "M"
        detalleTareoActual.Dni = obtenerDni()
        detalleTareoActual.Trabajador = obtenerTrabajador()
        detalleTareoActual.Planilla = obtenerPlanilla()
        detalleTareoActual.Consumidor = validarConsumidor(cboConsumidor.SelectedValue)
        'detalleTareoActual.Campana = lblDin_Campana.Text
        detalleTareoActual.Cultivo = validarCultivo(cboCultivo.SelectedValue)
        detalleTareoActual.Variedad = validarVariedad(cboCultivo.SelectedValue, cboVariedad.SelectedValue)
        detalleTareoActual.Actividad = validarActividad(cboActividad.SelectedValue)
        detalleTareoActual.Labor = validarLabor(cboActividad.SelectedValue, cboLabor.SelectedValue)
        detalleTareoActual.Inicio = obtenerFechaInicio()
        detalleTareoActual.Fin = obtenerFechaFin()
        detalleTareoActual.SubTotalHoras = obtenerHoras()
        detalleTareoActual.SubTotalRendimiento = CType(IIf(txtRendimiento.Text = "", 0, txtRendimiento.Text), Double)

    End Sub

    Private Sub capturarDatosDesdeDataRow(fila As DataRow, i As Integer)
        'COLUMNAS EXCEL:-->   DNI-CONSUMIDOR-CULTIVO-VARIEDAD-ACTIVIDAD-LABOR-SUBTOTALHORAS
        detalleTareoActual.Item = i
        'If lblDin_Item.Text = "0" Then
        '    detalleTareoActual.Item = dgvResultado.Rows.Count + 1
        'End If
        detalleTareoActual.Observacion = ""
        detalleTareoActual.Estado = "M"
        detalleTareoActual.Dni = fila.Item(0)
        detalleTareoActual.Trabajador = obtenerTrabajador()
        detalleTareoActual.Planilla = obtenerPlanilla()
        detalleTareoActual.Consumidor = validarConsumidor(fila.Item(1).ToString)
        'detalleTareoActual.Campana = "S/C" 'lblDin_Campana.Text --esta fila se realiza de ahora en adelante con validarConsumidor()
        detalleTareoActual.Cultivo = validarCultivo(fila.Item(2).ToString) ' "0000" 'cboCultivo.SelectedValue
        detalleTareoActual.Variedad = validarVariedad(fila.Item(2).ToString, fila.Item(3).ToString) '"000" 'cboVariedad.SelectedValue
        detalleTareoActual.Actividad = validarActividad(fila.Item(4).ToString) 'cboActividad.SelectedValue
        detalleTareoActual.Labor = validarLabor(fila.Item(4).ToString, fila.Item(5).ToString) 'cboLabor.SelectedValue
        detalleTareoActual.Inicio = obtenerFechaInicio()
        detalleTareoActual.Fin = obtenerFechaFin()
        detalleTareoActual.SubTotalHoras = CType(fila.Item(6), Double) 'obtenerHoras()
        detalleTareoActual.SubTotalRendimiento = 0 'CType(IIf(txtRendimiento.Text = "", 0, txtRendimiento.Text), Double)

        'adicional
        'detalleTareoActual.observacion = fila.Item(7).ToString

    End Sub

    Private Sub insertarFila()
        'Dim fila As New DataGridViewRow
        'fila = dgvResultado.

        Dim fila As DataRow
        fila = tablaParaDgvResultado.NewRow()

        'Dim i As Integer = dgvResultado.Rows.Add()
        'dgvResultado.Rows(i).Cells

        fila.Item("T_IdTareo") = detalleTareoActual.Id
        fila.Item("Item") = dgvResultado.Rows.Count + 1
        fila.Item("T_IdTransferencia") = ""
        'fila.Item("T_Dni") = detalleTareoActual.Estado
        fila.Item("T_Dni") = detalleTareoActual.Dni
        fila.Item("T_Trabajador") = detalleTareoActual.Trabajador
        fila.Item("T_IdPlanilla") = detalleTareoActual.Planilla
        fila.Item("T_Consumidor") = detalleTareoActual.Consumidor
        fila.Item("T_Campana") = detalleTareoActual.Campana
        fila.Item("T_IdCultivo") = detalleTareoActual.Cultivo
        fila.Item("T_IdVariedad") = detalleTareoActual.Variedad
        fila.Item("T_IdActividad") = detalleTareoActual.Actividad
        fila.Item("T_IdLabor") = detalleTareoActual.Labor
        'If fila.Item("H1Ingreso") Then
        fila.Item("H1Ingreso") = detalleTareoActual.Inicio
        'End If
        'If fila.Item("H1Salida") Is Nothing Then
        fila.Item("H1Salida") = detalleTareoActual.Fin
        'End If
        fila.Item("D3Horas") = detalleTareoActual.SubTotalHoras
        fila.Item("D3Rdto") = detalleTareoActual.SubTotalRendimiento
        fila.Item("T_Observacion") = detalleTareoActual.Observacion
        'MODIFICACION 2024-05-11 HATCH
        'fila.Item("H1Ingreso") = ""
        'fila.Item("H1Salida") = ""
        tablaParaDgvResultado.Rows.Add(fila)
        'dgvResultado.Rows.Add(fila)
        lblDin_Resultado.Text = "Registros: " + dgvResultado.RowCount.ToString

    End Sub

    Private Sub inicializarDataParaDgvResultado()
        If tablaParaDgvResultado.Columns.Count = 0 Then
            tablaParaDgvResultado.Columns.Add("Id")
            tablaParaDgvResultado.Columns.Add("Item")
            tablaParaDgvResultado.Columns.Add("IdTransf")
            tablaParaDgvResultado.Columns.Add("Estado")
            tablaParaDgvResultado.Columns.Add("Dni")
            tablaParaDgvResultado.Columns.Add("Trabajador")
            tablaParaDgvResultado.Columns.Add("Planilla")
            tablaParaDgvResultado.Columns.Add("Consumidor")
            tablaParaDgvResultado.Columns.Add("Campana")
            tablaParaDgvResultado.Columns.Add("Cultivo")
            tablaParaDgvResultado.Columns.Add("Variedad")
            tablaParaDgvResultado.Columns.Add("Actividad")
            tablaParaDgvResultado.Columns.Add("Labor")
            tablaParaDgvResultado.Columns.Add("H1Inicio", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("H1Fin", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("D2Horas", Type.GetType("System.Double"))
            tablaParaDgvResultado.Columns.Add("D2Rdto", Type.GetType("System.Double"))
            tablaParaDgvResultado.Columns.Add("Observacion")
        End If
    End Sub

    Private Sub txtDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDni.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAgregar_Click(sender, e)
        End If
    End Sub

    Private Sub txtHoras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoras.KeyPress
        'If e.KeyChar = vbTab Then
        '    txtRendimiento.Focus() 
        'End If
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If

        changeHoras = True
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso gboDetalle.Enabled Then
            detalleTareoActual = obtenerDetalleDesdeFila(tablaParaDgvResultado.Rows(dgvResultado.CurrentRow.Index))

            'Dim kkkk As String = dgvResultado.Rows(e.RowIndex).Cells("Item").Value

            'Dim dsds As DataRow = tablaParaDgvResultado.Rows(e.RowIndex)


            'detalleTareoActual = obtenerDetalleDesdeFila(tablaParaDgvResultado.Rows("03F000000007"))
            actualizarCabeceraDeDetalle()
            desbloquearControl(btnActualizar)
            desbloquearControl(btnEliminar)
            bloquearControl(btnGuardar)
            bloquearControl(btnAgregar)
            bloquearControl(txtDni)
            'MsgBox("aaaa")

        End If
    End Sub

    Private Sub txtRendimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRendimiento.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If

        changeRendimiento = True
    End Sub

    Private Sub desbloquearRango()
        cboHhInicio.Enabled = True
        cboMmInicio.Enabled = True
        pkrFin.Enabled = True
        cboHhFin.Enabled = True
        cboMmFin.Enabled = True
    End Sub

    Private Sub bloquearRango()
        cboHhInicio.Enabled = False
        cboMmInicio.Enabled = False
        pkrFin.Enabled = False
        cboHhFin.Enabled = False
        cboMmFin.Enabled = False
    End Sub

    Private Sub actualizarFila()

        Dim fila As DataRow
        MessageBox.Show(fila.Item(18).ToString)
        'fila = tablaParaDgvResultado.NewRow()
        'fila.Item(0) = detalleTareoActual.Id
        'fila.Item(1) = detalleTareoActual.Item
        'fila.Item(2) = ""
        ''fila.Item(3) = detalleTareoActual.Estado
        'fila.Item(3) = detalleTareoActual.Dni
        'fila.Item(4) = detalleTareoActual.Trabajador
        'fila.Item(5) = detalleTareoActual.Planilla
        'fila.Item(6) = detalleTareoActual.Consumidor
        'fila.Item(7) = detalleTareoActual.Campana
        ''fila.Item(9) = detalleTareoActual.Cultivo
        ''fila.Item(10) = detalleTareoActual.Variedad
        'fila.Item(8) = detalleTareoActual.IdActividad
        'fila.Item(11) = detalleTareoActual.Actividad
        'fila.Item(12) = detalleTareoActual.Labor
        ''fila.Item(13) = detalleTareoActual.Inicio
        ''fila.Item(14) = detalleTareoActual.Fin
        ''MODIFICACION 2024-05-11 HATCH
        ''fila.Item(15) = detalleTareoActual.SubTotalHoras
        ''fila.Item(16) = detalleTareoActual.SubTotalRendimiento
        'fila.Item(17) = detalleTareoActual.SubTotalHoras
        'fila.Item(18) = detalleTareoActual.SubTotalRendimiento
        ''fila.Item(17) = detalleTareoActual.Observacion
        'For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
        '    If tablaParaDgvResultado.Rows(i).Item(1).ToString = detalleTareoActual.Item Then
        '        For j = 0 To tablaParaDgvResultado.Columns.Count - 1 Step 1
        '            If j <> 1 And j <> 4 And j <> 5 And j <> 6 Then
        '                tablaParaDgvResultado.Rows(i).Item(j) = fila.Item(j)
        '            End If
        '        Next
        '        Exit Sub
        '    End If
        'Next

        ''Dim i As Integer = 0
        'For Each row As DataRow In tablaParaDgvResultado.Rows
        '    If row.Item(1).ToString = detalleTareoActual.Item Then
        '        'i = row.Item(1)
        '        'Dim j As Integer = 0
        '        Dim k As Integer = tablaParaDgvResultado.Columns.Count - 1
        '        For j = 0 To k Step 1
        '            If j <> 4 And j <> 5 And j <> 6 Then
        '                tablaParaDgvResultado.Rows(i).Item(j) = fila.Item(j)
        '            End If
        '        Next
        '        'For Each it As DataGridCell In dataParaDgvResultado.Rows(i).ItemArray
        '        '    it = fila.Item(j)
        '        '    j += 1
        '        'Next
        '    End If
        '    i += 1
        'Next

        'dataParaDgvResultado.Rows.Add(fila)
        'dgvResultado.Rows.Add(fila)

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try

            ''AGREGADO
            'barProgreso.Value = 0
            'barProgreso.Maximum = dgvResultado.RowCount
            'barProgreso.Style = ProgressBarStyle.Continuous
            'FIN AGREGADO
            encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")


            'Dim j As Integer = 1
            'For Each fila As DataRow In dgvResultado.SelectedRows


            '    fila.Item("Item") = j
            '    j += 1
            'Next


            'Dim newDgv As New DataGridView()

            'newDgv.DataSource = dgvResultado.SelectedRows

            'para actualizar
            tareoActual.Detalle = New List(Of DetalleTareo)
            Dim seleccionados As New DataTable()
            seleccionados = convertToDateTable(dgvResultado.SelectedRows)

            For Each fila As DataRow In seleccionados.Rows

                detalleTareoActual = obtenerDetalleDesdeFila(fila)
                'Actualizar campos para editar

                If (changeActividad) Then detalleTareoActual.IdActividad = cboActividad.SelectedValue
                If (changeLabor) Then detalleTareoActual.IdLabor = cboLabor.SelectedValue
                If (changeConsumidor) Then detalleTareoActual.Consumidor = cboConsumidor.SelectedValue
                If (changeHoras) Then detalleTareoActual.SubTotalHoras = txtHoras.Text
                If (changeRendimiento) Then detalleTareoActual.SubTotalRendimiento = txtRendimiento.Text

                tareoActual.AgregarDetalle(detalleTareoActual)
            Next

            If tareoActual.ContarTareos > 0 Then
                'tareoActual.GuardarDetalle()
                If guardarDetalleEditar() Then
                    listarDetalle()
                    resaltarObservaciones()
                    desbloquearControl(btnEditar)
                    bloquearControl(btnGuardar)
                    bloquearControl(btnPuntitos)
                    bloquearControl(txtRutaExcel)
                    bloquearControl(btnImportar)
                    bloquearControl(btnEliminar)
                    ''bloquearControl(gboDetalle)
                    'ESTA VARIABLE SIRVE PARA DEJAR DE MOSTRAR EL TOOLTIP AL MOMENTO
                    'DE PRESIONA EL CLICK DERECHO EN LA GRILLA DE DETALLES
                    showToolstrip = False
                    gboDetalle.Enabled = False
                    bloquearControl(btnAgregar)
                    'volvems los flags a false
                    changeActividad = False
                    changeLabor = False
                    changeConsumidor = False
                    changeHoras = False
                    changeRendimiento = False

                    lblDin_Resultado.Text = "Registros: " + dgvResultado.Rows.Count.ToString
                    MessageBox.Show("Tareos Editados correctamente.")
                End If
                'MessageBox.Show("total detalles:" + tareoActual.TotalDetalles.ToString)
            Else
                MessageBox.Show("Seleccione por lo menos un tareo")
            End If

            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        'If cbxSeleccionMultiple.Checked Then


        'Else
        '    Try
        '        capturarDatos()
        '        If detalleTareoActual.SubTotalHoras <= 0 Then
        '            MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
        '            Exit Sub
        '        ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
        '            MessageBox.Show("Debe ingresar un Dni vállido.")
        '            Exit Sub
        '        End If
        '        actualizarFila()
        '        corregirTabla(tablaParaDgvResultado)
        '        formatearDataGridView(dgvResultado)
        '        resaltarObservaciones()
        '        dgvResultado.AutoResizeColumns()
        '        dgvResultado.AutoResizeRows()
        '        lblDin_Item.Text = "0"
        '        bloquearControl(btnActualizar)
        '        desbloquearControl(btnAgregar)
        '        desbloquearControl(txtDni)
        '        desbloquearControl(btnGuardar)
        '        txtDni.Text = ""
        '        txtDni.Focus()

        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try

        'End If
    End Sub

    ''Nuevo procedimiento para eliminar
    'Private Function eliminarDetalles() As Boolean 'Funcion que eliminaba 1 item seleccionado

    '    Dim p As New Dictionary(Of String, Object)


    '    ' Asegúrate de que se haya seleccionado una fila
    '    'If dgvResultado.SelectedRows.Count = 0 Then
    '    '    MessageBox.Show("No se ha seleccionado ningún ítem para eliminar.")
    '    '    Return False
    '    'End If

    '    ' Verifica que tareoActual.Id tenga un valor válido
    '    If String.IsNullOrEmpty(tareoActual.Id) Then
    '        MessageBox.Show("ID de tareo no válido.")
    '        Return False
    '    End If

    '    ' Agrega los parámetros al diccionario 
    '    p.Add("@IdTareo", tareoActual.Id)

    '    p.Add("@valorItem", valorItem)
    '    ' MessageBox.Show(valorItem)
    '    Try
    '        ' Llama al procedimiento almacenado
    '        doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
    '        Return True
    '    Catch ex As Exception
    '        ' Muestra el mensaje de error
    '        MessageBox.Show("Error al eliminar detalles: " & ex.Message)
    '        Return False
    '    End Try
    'End Function

    Private Function eliminarDetallesV2(cadenaItems As String) As Boolean 'Funcion para eliminar una lista de items seleccionados
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTareo", tareoActual.Id)
        p.Add("@valorItem", cadenaItems)

        Try
            ' Llamar al procedimiento almacenado
            doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
            Return True
        Catch ex As Exception
            ' Mostrar el mensaje de error
            MessageBox.Show("Error al eliminar detalles: " & ex.Message)
            Return False
        End Try
    End Function

    'Nueva función para guardar el detalle
    Private Function guardarDetalles() As Boolean

        Dim p As New Dictionary(Of String, Object)
        Dim cadena As String = String.Empty
        Dim formato As String = "yyyy-MM-dd HH:mm:ss.fff"

        ' Construye la cadena de parámetros para cada detalle
        For Each d As DetalleTareo In tareoActual.Detalle
            cadena = cadena + d.Id + ","
            cadena = cadena + d.Item.ToString + ","
            cadena = cadena + d.Dni + ","
            cadena = cadena + d.Planilla + ","
            cadena = cadena + d.Consumidor + ","
            cadena = cadena + d.Campana + ","
            cadena = cadena + "," ' d.Cultivo + ","
            cadena = cadena + "," ' d.Variedad + ","
            cadena = cadena + d.IdActividad + ","
            cadena = cadena + d.IdLabor + ","
            cadena = cadena + Now.ToString(formato) + "," ' d.Inicio.ToString(formato) + ","
            cadena = cadena + Now.ToString(formato) + "," ' d.Fin.ToString(formato) + ","
            cadena = cadena + d.SubTotalHoras.ToString + ","
            cadena = cadena + d.SubTotalRendimiento.ToString + ","
            cadena = cadena + d.Observacion

            p("@CadenaParametros") = cadena

            Try
                ' Llama al procedimiento almacenado para guardar los detalles
                doItBaby("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
            Catch ex As Exception
                MessageBox.Show("Error al guardar detalles: " & ex.Message)
                Return False
            End Try

            cadena = String.Empty
        Next

        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
            Try


            ' listarDetalle()
            'AGREGADO
            barProgreso.Value = 0
                barProgreso.Maximum = dgvResultado.RowCount
                barProgreso.Style = ProgressBarStyle.Continuous
                'FIN AGREGADO

                'Dim j As Integer = 1
                'For Each fila As DataRow In tablaParaDgvResultado.Rows
                '    fila.Item("Item") = j
                '    j += 1
                'Next

                tareoActual.Detalle = New List(Of DetalleTareo)
                For Each fila As DataRow In tablaParaDgvResultado.Rows
                    detalleTareoActual = obtenerDetalleDesdeFila(fila)
                    tareoActual.AgregarDetalle(detalleTareoActual)
                Next
                If tareoActual.ContarTareos > 0 Then
                ' Primero, elimina los detalles seleccionados
                ' If eliminarDetalles() Then ESTE SI FUNCIONA PARA 1 ITEM
                Dim cadenaItems As String = String.Join(",", dgvResultado.SelectedRows.Cast(Of DataGridViewRow)().Select(Function(row) row.Cells(1).Value.ToString()))

                ' Eliminar los detalles seleccionados
                If eliminarDetallesV2(cadenaItems) Then 'funcion para eliminar una lista de items seleccionados
                    'tareoActual.GuardarDetalle()
                    If guardarDetalles() Then 'La funcion anterior es GuardarDetalle()
                        listarDetalle()
                        resaltarObservaciones()
                        desbloquearControl(btnEditar)
                        bloquearControl(btnGuardar)
                        bloquearControl(btnPuntitos)
                        bloquearControl(txtRutaExcel)
                        bloquearControl(btnImportar)
                        bloquearControl(btnEliminar)
                        ''bloquearControl(gboDetalle)
                        gboDetalle.Enabled = False
                        bloquearControl(btnAgregar)
                        lblDin_Resultado.Text = "Registros: " + tablaParaDgvResultado.Rows.Count.ToString
                        MessageBox.Show("Detalle guardado correctamente.")
                    Else
                        MessageBox.Show("Error al guardar los detalles.")
                    End If
                Else
                    MessageBox.Show("Error al eliminar los detalles.")
                    End If
                    'MessageBox.Show("total detalles:" + tareoActual.TotalDetalles.ToString)
                Else
                        MessageBox.Show("No se puede guardar un tareo vacio")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    '    Dim item As String = detalleTareoActual.Item
    '    If item > 0 Then
    '        bloquearFilas(dgvResultado)
    '        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de eliminar el item: " + item, "Eliminar", MessageBoxButtons.YesNo)
    '        If respuesta = Windows.Forms.DialogResult.Yes Then
    '            For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
    '                If tablaParaDgvResultado.Rows(i).Item(1) = item Then
    '                    'tablaParaDgvResultado.Rows(i).Delete()
    '                    tablaParaDgvResultado.Rows.RemoveAt(i)
    '                    Exit For
    '                End If
    '            Next
    '            'dataParaDgvResultado.Rows(dgvResultado.CurrentRow.Index).Delete()
    '            Dim j As Integer = 0
    '            For Each fila As DataRow In tablaParaDgvResultado.Rows
    '                fila.Item(1) = j + 1
    '                'dataParaDgvResultado.Rows(j).Item(1) = j + 1
    '                j += 1
    '            Next
    '            MessageBox.Show("Item: " + item + " eliminado correctamente.")
    '        End If
    '        desbloquearFilas(dgvResultado)
    '        bloquearControl(btnActualizar)
    '        desbloquearControl(txtDni)
    '        desbloquearControl(btnAgregar)
    '        desbloquearControl(btnGuardar)
    '        txtDni.Text = ""
    '        txtDni.Focus()
    '    Else
    '        MessageBox.Show("No ha seleccionado ningun detalle.")
    '    End If
    'End Sub

    'Codigo original del btnEliminar_Click
    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    '    'If Not cbxSeleccionMultiple.Checked Then
    '    Dim item As String = detalleTareoActual.Item
    '    If item > 0 Then
    '        bloquearFilas(dgvResultado)
    '        Dim respuesta As DialogResult ' = 'MessageBox.Show("Esta seguro de eliminar el item: " + item, "Eliminar", MessageBoxButtons.YesNo)
    '        'If cbxSeleccionMultiple.Checked Then
    '        '    respuesta = MessageBox.Show("Esta seguro de eliminar el item los registros seleccionados? ", "Eliminar", MessageBoxButtons.YesNo)
    '        'Else
    '        '    respuesta = MessageBox.Show("Esta seguro de eliminar el item: " + item, "Eliminar", MessageBoxButtons.YesNo)
    '        'End If

    '        respuesta = MessageBox.Show("Esta seguro de eliminar el item los registros seleccionados? ", "Eliminar", MessageBoxButtons.YesNo)

    '        If respuesta = Windows.Forms.DialogResult.Yes Then
    '            bloquearFilas(dgvResultado)
    '            For Each detalle As DataGridViewRow In dgvResultado.SelectedRows
    '                'Dim item As String = detalle.Cells(1).Value 'detalleTareoActual.Item
    '                'If item > 0 Then
    '                '    For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
    '                '        If tablaParaDgvResultado.Rows(i).Item(1) = item Then
    '                '            'tablaParaDgvResultado.Rows(i).Delete()
    '                tablaParaDgvResultado.Rows.RemoveAt(detalle.Cells("Item").RowIndex)
    '                'Exit For
    '                '        End If
    '            Next
    '            'dataParaDgvResultado.Rows(dgvResultado.CurrentRow.Index).Delete()
    '            Dim j As Integer = 0
    '            For Each fila As DataRow In tablaParaDgvResultado.Rows
    '                fila.Item("Item") = j + 1
    '                'dataParaDgvResultado.Rows(j).Item(1) = j + 1
    '                j += 1
    '            Next
    '            'Next

    '            '--------------------------
    '            '    For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
    '            '        If tablaParaDgvResultado.Rows(i).Item(1) = item Then
    '            '            'tablaParaDgvResultado.Rows(i).Delete()
    '            '            tablaParaDgvResultado.Rows.RemoveAt(i)
    '            '            Exit For
    '            '        End If
    '            '    Next
    '            '    'dataParaDgvResultado.Rows(dgvResultado.CurrentRow.Index).Delete()
    '            '    Dim j As Integer = 0
    '            '    For Each fila As DataRow In tablaParaDgvResultado.Rows
    '            '        fila.Item(1) = j + 1
    '            '        'dataParaDgvResultado.Rows(j).Item(1) = j + 1
    '            '        j += 1
    '            '    Next
    '            '    MessageBox.Show("Item: " + item + " eliminado correctamente.")
    '        End If
    '        desbloquearFilas(dgvResultado)
    '        bloquearControl(btnActualizar)
    '        desbloquearControl(txtDni)
    '        desbloquearControl(btnAgregar)
    '        desbloquearControl(btnGuardar)
    '        txtDni.Text = ""
    '        txtDni.Focus()
    '        lblDin_Resultado.Text = "Registros: " + tablaParaDgvResultado.Rows.Count.ToString
    '    Else
    '        MessageBox.Show("No ha seleccionado ningun detalle.")
    '    End If
    '    'Else
    '    'Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de eliminar los registros seleccionados", "Eliminar", MessageBoxButtons.YesNo)
    '    'If respuesta = Windows.Forms.DialogResult.Yes Then
    '    '    bloquearFilas(dgvResultado)
    '    '    For Each detalle As DataGridViewRow In dgvResultado.SelectedRows
    '    '        Dim item As String = detalle.Cells(1).Value 'detalleTareoActual.Item
    '    '        If item > 0 Then
    '    '            For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
    '    '                If tablaParaDgvResultado.Rows(i).Item(1) = item Then
    '    '                    'tablaParaDgvResultado.Rows(i).Delete()
    '    '                    tablaParaDgvResultado.Rows.RemoveAt(i)
    '    '                    Exit For
    '    '                End If
    '    '            Next
    '    '            'dataParaDgvResultado.Rows(dgvResultado.CurrentRow.Index).Delete()
    '    '            Dim j As Integer = 0
    '    '            For Each fila As DataRow In tablaParaDgvResultado.Rows
    '    '                fila.Item(1) = j + 1
    '    '                'dataParaDgvResultado.Rows(j).Item(1) = j + 1
    '    '                j += 1
    '    '            Next

    '    '        Else
    '    '            MessageBox.Show("No ha seleccionado ningun detalle.")
    '    '        End If
    '    '    Next
    '    '    desbloquearFilas(dgvResultado)
    '    '    bloquearControl(btnActualizar)
    '    '    desbloquearControl(txtDni)
    '    '    desbloquearControl(btnAgregar)
    '    '    desbloquearControl(btnGuardar)
    '    '    txtDni.Text = ""
    '    '    txtDni.Focus()
    '    '    lblDin_Resultado.Text = "Registros: " + tablaParaDgvResultado.Rows.Count.ToString
    '    '    MessageBox.Show("Detalles eliminados correctamente.")
    '    'End If
    '    'End If

    'End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click ' funcion modificada del boton eliminar_click
        ' Verificar que se haya seleccionado al menos una fila
        If dgvResultado.SelectedRows.Count = 0 Then
            MessageBox.Show("No se ha seleccionado ningún ítem para eliminar.")
            Return
        End If

        ' Verificar que tareoActual.Id tenga un valor válido
        If String.IsNullOrEmpty(tareoActual.Id) Then
            MessageBox.Show("ID de tareo no válido.")
            Return
        End If

        ' Construir la cadena de ítems separados por comas
        Dim cadenaItems As String = String.Join(",", dgvResultado.SelectedRows.Cast(Of DataGridViewRow)().Select(Function(row) row.Cells(1).Value.ToString()))

        ' Confirmar eliminación
        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de eliminar los registros seleccionados?", "Eliminar", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.Yes Then
            ' Bloquear filas para evitar cambios mientras se eliminan
            bloquearFilas(dgvResultado)

            ' Llamar a la función para eliminar detalles
            If eliminarDetallesV2(cadenaItems) Then
                ' Si la eliminación es exitosa, eliminar las filas del DataGridView
                For Each detalle As DataGridViewRow In dgvResultado.SelectedRows.Cast(Of DataGridViewRow)().ToList()
                    tablaParaDgvResultado.Rows.RemoveAt(detalle.Index)
                Next

                ' Actualizar la interfaz
                lblDin_Resultado.Text = "Registros: " + tablaParaDgvResultado.Rows.Count.ToString()
            Else
                MessageBox.Show("Error al eliminar los detalles.")
            End If

            ' Restablecer controles
            desbloquearFilas(dgvResultado)
            bloquearControl(btnActualizar)
            desbloquearControl(txtDni)
            desbloquearControl(btnAgregar)
            desbloquearControl(btnGuardar)

            txtDni.Text = ""
            txtDni.Focus()
        End If
    End Sub

    Private Function obtenerDetalleDesdeFila(fila As DataRow) As DetalleTareo
        'fila.Item("T_IdTareo") = detalleTareoActual.Id
        'fila.Item("Item") = dgvResultado.Rows.Count + 1
        'fila.Item("T_IdTransferencia") = ""
        ''fila.Item("T_Dni") = detalleTareoActual.Estado
        'fila.Item("T_Dni") = detalleTareoActual.Dni
        'fila.Item("T_Trabajador") = detalleTareoActual.Trabajador
        'fila.Item("T_IdPlanilla") = detalleTareoActual.Planilla
        'fila.Item("T_Consumidor") = detalleTareoActual.Consumidor
        'fila.Item("T_Campana") = detalleTareoActual.Campana
        ''fila.Item(9) = detalleTareoActual.Cultivo
        ''fila.Item(10) = detalleTareoActual.Variedad
        'fila.Item("T_IdActividad") = detalleTareoActual.Actividad
        'fila.Item("T_IdLabor") = detalleTareoActual.Labor
        ''fila.Item("H1Inicio") = detalleTareoActual.Inicio
        ''fila.Item("H1Fin") = detalleTareoActual.Fin
        'fila.Item("D3Horas") = detalleTareoActual.SubTotalHoras
        'fila.Item("D3Rdto") = detalleTareoActual.SubTotalRendimiento
        'fila.Item("T_Observacion") = detalleTareoActual.Observacion
        ''-----------------------------------------------------
        Dim aux As New DetalleTareo
        'Dim f As Integer = dgvResultado.CurrentRow.Index
        aux.Id = tareoActual.Id
        aux.Item = fila.Item("Item") 'dgvResultado.Rows(f).Cells(1).Value
        'aux.Estado = "M"
        aux.Dni = fila.Item("T_Dni") 'dgvResultado.Rows(f).Cells(4).Value
        aux.Trabajador = fila.Item("T_Trabajador") 'dgvResultado.Rows(f).Cells(5).Value
        aux.Planilla = fila.Item("T_IdPlanilla") 'dgvResultado.Rows(f).Cells(6).Value
        aux.Consumidor = fila.Item("T_Consumidor") 'dgvResultado.Rows(f).Cells(7).Value
        aux.Campana = fila.Item("T_Campana") 'dgvResultado.Rows(f).Cells(8).Value
        'aux.Cultivo = fila.Item(9) 'dgvResultado.Rows(f).Cells(9).Value
        'aux.Variedad = fila.Item(10) 'dgvResultado.Rows(f).Cells(10).Value


        aux.IdCultivo = fila.Item("T_IdCultivo")
        aux.IdVariedad = fila.Item("T_IdVariedad")
        aux.IdActividad = fila.Item("T_IdActividad")
        'aux.Actividad = fila.Item("T_Actividad")
        'aux.Actividad = fila.Item("") 'dgvResultado.Rows(f).Cells(11).Value
        aux.IdLabor = fila.Item("T_IdLabor")
        'aux.Labor = fila.Item("T_Labor") 'dgvResultado.Rows(f).Cells(12).Value
        'aux.Labor = fila.Item("") 'dgvResultado.Rows(f).Cells(12).Value
        'aux.Inicio = fila.Item(13) 'dgvResultado.Rows(f).Cells(13).Value
        'aux.Fin = fila.Item(14) 'dgvResultado.Rows(f).Cells(14).Value
        aux.SubTotalHoras = fila.Item("D3Horas") 'dgvResultado.Rows(f).Cells(15).Value
        aux.SubTotalRendimiento = fila.Item("D3Rdto") 'dgvResultado.Rows(f).Cells(16).Value
        aux.Observacion = fila.Item("T_Observacion")
        'MODIFICACION 2024-05-11 HATCH
        aux.Ingreso = ""
        aux.Salida = ""
        Return aux
    End Function

    Private Function guardarDetalle() As Boolean
        'If Microsoft.VisualBasic.Left(tareoActual.Id, 3) <> "000" Then
        Dim p As New Dictionary(Of String, Object)
        Dim item As String = dgvResultado.Rows(filaSeleccionada).Cells(1).Value
        Dim itemsParaEliminar As New List(Of String)()

        p.Add("@IdTareo", tareoActual.Id)
        p.Add("@Item", valorItem)
        'doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)

        Dim cadena As String = String.Empty
        'Dim p As New Dictionary(Of String, Object)
        '00000000002L,4,80370233,EMA,611,S/C,0002,043,U01,002,2020-08-19 00:08:00.000,2020-08-19 00:00:00.000,12,83'
        p = New Dictionary(Of String, Object)
        p.Add("@CadenaParametros", String.Empty)
        Dim formato As String = "yyyy-MM-dd HH:mm:ss.fff"
        For Each d As DetalleTareo In tareoActual.Detalle
            cadena = cadena + d.Id + ","
            cadena = cadena + d.Item.ToString + ","
            cadena = cadena + d.Dni + ","
            cadena = cadena + d.Planilla + ","
            cadena = cadena + d.Consumidor + ","
            cadena = cadena + d.Campana + ","
            cadena = cadena + "," 'd.Cultivo + ","
            cadena = cadena + "," ' d.Variedad + ","
            cadena = cadena + d.IdActividad + ","
            'cadena = cadena + d.Actividad + ","
            cadena = cadena + d.IdLabor + ","
            'cadena = cadena + d.Labor + ","
            cadena = cadena + Now.ToString(formato) + "," 'd.Inicio.ToString(formato) + ","
            cadena = cadena + Now.ToString(formato) + "," 'd.Fin.ToString(formato) + ","
            cadena = cadena + d.SubTotalHoras.ToString + ","
            cadena = cadena + d.SubTotalRendimiento.ToString + ","
            cadena = cadena + d.Observacion
            'MessageBox.Show(cadena)
            'txtDni.Text = cadena
            p("@CadenaParametros") = cadena
            Try
                'If tareoActual.Estado = "D" Then
                doItBaby("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value += 1
                barProgreso.Refresh()
                'Else
                'PENDIENTE EJECUATAR GUARDADO EN SQLITE
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cadena = String.Empty
        Next
        Return True
        'Else

        'End If
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "M" Then
        '    exec("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        'ElseIf tareoActual.Estado = "L" Then
        '    'PENDIENTE GUARDAR EN SQLITE
        'End If
    End Function

    Private Function guardarDetalleEditar() As Boolean
        'If Microsoft.VisualBasic.Left(tareoActual.Id, 3) <> "000" Then
        Dim p As New Dictionary(Of String, Object)
        'p.Add("@Id", tareoActual.Id)
        'doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        Dim cadena As String = String.Empty
        'Dim p As New Dictionary(Of String, Object)
        '00000000002L,4,80370233,EMA,611,S/C,0002,043,U01,002,2020-08-19 00:08:00.000,2020-08-19 00:00:00.000,12,83'
        p = New Dictionary(Of String, Object)
        p.Add("@CadenaParametros", String.Empty)
        Dim formato As String = "yyyy-MM-dd HH:mm:ss.fff"
        barProgreso.Value = 0
        For Each d As DetalleTareo In tareoActual.Detalle
            cadena = cadena + d.Id + ","
            cadena = cadena + d.Item.ToString + ","
            cadena = cadena + d.Dni + ","
            cadena = cadena + d.Planilla + ","
            cadena = cadena + d.Consumidor + ","
            cadena = cadena + d.Campana + ","
            cadena = cadena + d.IdCultivo + ","
            cadena = cadena + d.IdVariedad + ","
            cadena = cadena + d.IdActividad + ","
            'cadena = cadena + d.Actividad + ","
            cadena = cadena + d.IdLabor + ","
            'cadena = cadena + d.Labor + ","
            cadena = cadena + Now.ToString(formato) + "," 'd.Inicio.ToString(formato) + ","
            cadena = cadena + Now.ToString(formato) + "," 'd.Fin.ToString(formato) + ","
            cadena = cadena + d.SubTotalHoras.ToString + ","
            cadena = cadena + d.SubTotalRendimiento.ToString + ","
            cadena = cadena + d.Observacion
            'MessageBox.Show(cadena)
            'txtDni.Text = cadena
            p("@CadenaParametros") = cadena
            Try
                'If tareoActual.Estado = "D" Then
                doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EditarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value += 1
                barProgreso.Refresh()
                'Else
                'PENDIENTE EJECUATAR GUARDADO EN SQLITE
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cadena = String.Empty
        Next
        Return True
        'Else

        'End If
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "M" Then
        '    exec("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        'ElseIf tareoActual.Estado = "L" Then
        '    'PENDIENTE GUARDAR EN SQLITE
        'End If
    End Function

    'Private Sub cboCultivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCultivo.SelectedValueChanged
    '    cargarCombo(cboVariedad, dataParaControles.Tables(1), cboCultivo.SelectedValue.ToString, True)
    '    'cboCultivo_Leave(sender, e)
    'End Sub

    'Private Sub cboActividad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboActividad.SelectedValueChanged
    '    cargarCombo(cboLabor, dataParaControles.Tables(3), cboActividad.SelectedValue.ToString, True)
    'End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        'dataParaControles.Remove("Variedades")
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        'dataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable))
        cargarCombo(cboVariedad, doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable), 0, 2)
    End Sub

    Private Sub cboActividad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActividad.SelectionChangeCommitted
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdActividad", cboActividad.SelectedValue)
        'dataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable))
        cargarCombo(cboLabor, doItBaby("sp_Dg_ObtenerLabores", p, Datos.Conexion.TipoQuery.DataTable), 0, 2)
        'cargarCombo(cboLabor, dataParaControles.Tables(3), cboActividad.SelectedValue.ToString, True)
        'cargarCombo(cboLabor, dataParaControles.Tables(3), 0, 2)
        'cboLabor.Focus()
        'cboActividad_Leave(sender, e)
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            Dim dtTablaExcel As New DataTable
            dtTablaExcel = cargarExcel(txtRutaExcel.Text) 'PENDIENTE CAMBIAR LA FUNCION CARGAREXCEL POR UN PROCESO EN MOTOR SQL
            corregirTabla(dtTablaExcel)
            If cbxDistribucionAutomatica.Checked Then
                distribuirHoras(dtTablaExcel)
                'If Not tablaParaDgvResultado.Columns.Contains("Observacion") Then
                '    tablaParaDgvResultado.Columns.Add("Observacion")
                'End If
            End If
            'dgvResultado.DataSource = dtTablaExcel
            'AGREGADO
            barProgreso.Value = 0
            barProgreso.Maximum = dtTablaExcel.Rows.Count
            barProgreso.Style = ProgressBarStyle.Continuous

            'FIN AGREGADO
            'dgvResultado.Rows.Clear()
            'Dim i As Integer = 1
            For Each fila As DataRow In dtTablaExcel.Rows()
                capturarDatosDesdeDataRow(fila, dgvResultado.Rows.Count + 1)
                'i += 1
                If detalleTareoActual.SubTotalHoras <= 0 Then
                    MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
                    'Exit Sub
                ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
                    MessageBox.Show("Debe ingresar un Dni vállido.")
                    'Exit Sub
                End If
                insertarFila()
                'If dtTablaExcel.Rows.Count < 100 Then
                '    formatearDataGridView(dgvResultado)
                'End If

                barProgreso.Value += 1
                barProgreso.Refresh()
                'AGREGADO
                'CheckForIllegalCrossThreadCalls = False
                'If Not BackgroundWorker1.IsBusy Then
                '    'indicadorParaBGW = dtTablaExcel.Rows.Count
                '    BackgroundWorker1.RunWorkerAsync()
                'End If
                'FIN AGREGADO

                'corregirCeldas(dgvResultado)
                'dgvResultado.AutoResizeColumns()
                'dgvResultado.AutoResizeRows()
                'lblDin_Item.Text = "0"            
            Next
            'corregirTabla(tablaParaDgvResultado)
            dgvResultado.DataSource = tablaParaDgvResultado

            'desbloquearControl(btnGuardar)
            'barProgreso.Style = ProgressBarStyle.Continuous
            'barProgreso.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            formatearDataGridView(dgvResultado)
            resaltarObservaciones()
            txtDni.Text = ""
            txtDni.Focus()
            desbloquearControl(btnGuardar)
        End Try
    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    'barProgreso.Value = 0
    '    'barProgreso.Maximum = indicadorParaBGW
    '    'barProgreso.Style = ProgressBarStyle.Blocks
    '    'For i As Integer = 0 To 99 Step 1
    '    barProgreso.Value = barProgreso.Value + 1
    '    barProgreso.Refresh()
    '    BackgroundWorker1.CancelAsync()
    '    'Next
    'End Sub

    'Private Sub cboConsumidor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboConsumidor.SelectionChangeCommitted
    '    If cboConsumidor.Items.Count > 0 Then
    '        Dim anioCampana As String = "S/C"
    '        For Each fila As DataRow In dataParaControles.Tables(5).Rows
    '            If cboConsumidor.SelectedValue IsNot Nothing Then
    '                If fila.Item(0) = cboConsumidor.SelectedValue.ToString AndAlso fila.Item(2) <= tareoActual.Fecha _
    '                AndAlso fila.Item(3) >= tareoActual.Fecha Then
    '                    anioCampana = fila.Item(1).ToString
    '                End If
    '            End If
    '        Next
    '        lblDin_Campana.Text = anioCampana
    '    End If
    'End Sub



    'Private Sub cboCultivo_Leave(sender As Object, e As EventArgs) Handles cboCultivo.Leave
    '    Try
    '        If InStr(cboCultivo.Text, "|", CompareMethod.Text) > 0 Then
    '            cboCultivo.SelectedValue = cboCultivo.Text.ToString.Substring(0, InStr(cboCultivo.Text, "|", CompareMethod.Text) - 2)
    '            'cboCultivo_SelectionChangeCommitted(sender, e)
    '            cargarCombo(cboVariedad, dataParaControles.Tables(1), cboCultivo.SelectedValue.ToString, True)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cboVariedad_Leave(sender As Object, e As EventArgs) Handles cboVariedad.Leave
    '    Try
    '        cboVariedad.SelectedValue = cboVariedad.Text.ToString.Substring(0, InStr(cboVariedad.Text, "|", CompareMethod.Text) - 2)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cboActividad_Leave(sender As Object, e As EventArgs) Handles cboActividad.Leave
    '    Try
    '        If InStr(cboActividad.Text, "|", CompareMethod.Text) > 0 Then
    '            cboActividad.SelectedValue = cboActividad.Text.ToString.Substring(0, InStr(cboActividad.Text, "|", CompareMethod.Text) - 2)
    '            'cboActividad_SelectionChangeCommitted(sender, e)
    '            cargarCombo(cboLabor, dataParaControles.Tables(3), cboActividad.SelectedValue.ToString, True)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cboLabor_Leave(sender As Object, e As EventArgs) Handles cboLabor.Leave
    '    Try
    '        cboLabor.SelectedValue = cboLabor.Text.ToString.Substring(0, InStr(cboLabor.Text, "|", CompareMethod.Text) - 2)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cboConsumidor_Leave(sender As Object, e As EventArgs) Handles cboConsumidor.Leave
    '    Try
    '        If InStr(cboConsumidor.Text, "|", CompareMethod.Text) Then
    '            cboConsumidor.SelectedValue = cboConsumidor.Text.ToString.Substring(0, InStr(cboConsumidor.Text, "|", CompareMethod.Text) - 2)
    '            cboConsumidor_SelectionChangeCommitted(sender, e)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    'Private Sub cbxSeleccionMultiple_CheckStateChanged(sender As Object, e As EventArgs)
    '    If cbxSeleccionMultiple.Checked Then
    '        'btnActualizar.Enabled = True
    '        dgvResultado.MultiSelect = True
    '        'dgvResultado.SelectionMod
    '    Else
    '        dgvResultado.MultiSelect = False
    '    End If

    'End Sub

    Private Sub distribuirHoras(ByRef tablaExcel As DataTable)
        'dataParaControles.Tables(9)
        tablaExcel.Columns.Add("Observacion")
        tablaExcel.Columns.Add("Hectareas")
        'tablaExcel.Columns.Add("HectareasTotales")
        'tablaExcel.Columns.Add("PromedioHoras")

        llenarColumnaHectareas(tablaExcel)

        Dim dniActual As String = String.Empty
        Dim nuevasHoras As Double = 0, hectareasConsumidor As Double = 0, totalHectareas As Double = 0, totalHoras As Double = 0, n As Double = 0
        Dim dnis As New Dictionary(Of String, Double()) '{HECTAREASTOTALES, HORAS, N}

        'LISTA DNIS DIFERENTES SIN IMPORTAR EL ORDEN
        For Each fila As DataRow In tablaExcel.Rows
            If Not dnis.ContainsKey(fila.Item(0)) And fila.Item(0).Length > 0 Then dnis.Add(fila.Item(0), {0, 0, 0})
        Next

        'RECORRE LA LISTA DE LOS DNIS PARA SUBTOTALIZAR VALORES
        For Each dni As KeyValuePair(Of String, Double()) In dnis
            'Dim nuevasHoras As Double, totalHectareas As Double, totalHoras As Double, nDni As Integer
            For Each fila As DataRow In tablaExcel.Rows
                If fila.Item(0) = dni.Key Then
                    dni.Value(0) += fila.Item(tablaExcel.Columns.IndexOf("Hectareas"))
                    dni.Value(1) += fila.Item(tablaExcel.Columns.IndexOf("Horas"))
                    dni.Value(2) += 1
                End If
            Next
        Next
        'REVISAR CASO DE PAOLA
        'RECORRE LA TABLA PARA SETEAR VALORES SUBTOTALIZADOS
        For Each fila As DataRow In tablaExcel.Rows
            If fila.Item(0).Length > 0 Then
                hectareasConsumidor = fila.Item(tablaExcel.Columns.IndexOf("Hectareas"))
                totalHectareas = dnis(fila(0))(0)
                totalHoras = dnis(fila(0))(1)
                n = dnis(fila(0))(2)
                nuevasHoras = (hectareasConsumidor / IIf(totalHectareas = 0, 1, totalHectareas)) * (totalHoras / n)
                fila.Item(tablaExcel.Columns.IndexOf("Horas")) = Math.Round(nuevasHoras, 2)
            End If
        Next

        Dim validacion As New Dictionary(Of String, Double)

        For Each fila As DataRow In tablaExcel.Rows
            If Not validacion.ContainsKey(fila.Item(0)) Then
                validacion.Add(fila.Item(0), fila.Item(tablaExcel.Columns.IndexOf("Horas")))
            Else
                validacion.Item(fila.Item(0)) = validacion.Item(fila.Item(0)) + fila.Item(tablaExcel.Columns.IndexOf("Horas"))
            End If
        Next

        Dim primerTotal As Double = 0
        Dim diferencias As New Dictionary(Of String, Double)
        For Each Persona As KeyValuePair(Of String, Double) In validacion
            primerTotal = dnis(Persona.Key)(1) / dnis(Persona.Key)(2)
            If primerTotal <> Persona.Value Then
                diferencias.Add(Persona.Key, primerTotal - Persona.Value)
            End If
        Next

        For Each dif As KeyValuePair(Of String, Double) In diferencias
            For Each fila As DataRow In tablaExcel.Rows
                If fila.Item(0) = dif.Key Then
                    fila.Item(tablaExcel.Columns.IndexOf("Horas")) = fila.Item(tablaExcel.Columns.IndexOf("Horas")) + dif.Value
                    Exit For
                End If
            Next
        Next

        tablaExcel.Columns.Remove("Hectareas")
    End Sub

    Private Sub llenarColumnaHectareas(ByRef tablaExcel As DataTable)
        Dim encontrado As Boolean
        For Each fila As DataRow In tablaExcel.Rows
            encontrado = False
            For Each filita As DataRow In dataParaControles.Item("Hectareas").Rows
                If fila.Item(tablaExcel.Columns.IndexOf("IdConsumidor")) = filita.Item(0) Then
                    fila.Item(tablaExcel.Columns.IndexOf("Hectareas")) = filita.Item(1)
                    If filita.Item(2) = "Inactivo" Then
                        fila.Item(tablaExcel.Columns.IndexOf("Observacion")) = "El consumidor no se encuentra activo"
                    End If
                    If filita.Item(1) = 0 Then
                        fila.Item(tablaExcel.Columns.IndexOf("Observacion")) = "El consumidor no tiene area"
                    End If
                    encontrado = True
                    Exit For
                End If
            Next
            If Not encontrado Then
                fila.Item(tablaExcel.Columns.IndexOf("Hectareas")) = 0
                fila.Item(tablaExcel.Columns.IndexOf("Observacion")) = "El consumidor no existe"
            End If
        Next
    End Sub

    Private Function validarConsumidor(idConsumidor As String) As String
        If detalleTareoActual.Observacion.Length <= 0 Then
            idConsumidor = Trim(UCase(idConsumidor))
            Dim encontrado As Boolean = False
            For Each fila As DataRow In dataParaControles.Item("Hectareas").Rows
                If fila.Item(0).ToString = idConsumidor Then
                    encontrado = True
                    If fila.Item(5).ToString = "0" Then
                        detalleTareoActual.Observacion = "005" 'CONSUMIDOR DE BAJA
                        detalleTareoActual.Campana = "S/C"
                    ElseIf fila.Item(2).ToString = "1" AndAlso fila.Item(3).ToString = "0" Then
                        detalleTareoActual.Observacion = "003" 'CONSUMIDOR SIN CAMPAÑA
                        detalleTareoActual.Campana = "S/C"
                    ElseIf cbxDistribucionAutomatica.Checked AndAlso CType(fila.Item(1), Double) = 0.0 Then
                        detalleTareoActual.Observacion = "004" 'CONSUMIDOR SIN AREA
                        detalleTareoActual.Campana = "S/C"
                    Else
                        detalleTareoActual.Campana = fila.Item(4).ToString 'OBTIENE EL AÑO DE CAMPAÑA
                    End If
                    Return idConsumidor
                    Exit Function
                End If
            Next
            detalleTareoActual.Observacion = "006" ' CONSUMIDOR INEXISTENTE
        End If
        Return idConsumidor
    End Function

    Private Function validarCultivo(idCultivo As String) As String
        If detalleTareoActual.Observacion.Length <= 0 Then
            idCultivo = Trim(UCase(idCultivo))
            Dim encontrado As Boolean = False
            For Each fila As DataRow In dataParaControles.Item("Cultivos").Rows
                If fila.Item(0).ToString = idCultivo Then
                    encontrado = True
                    'If fila.Item(1).ToString = "0" Then
                    '    detalleTareoActual.Observacion = "012" ' CULTIVO DE BAJA
                    'End If
                    Return idCultivo
                End If
            Next
            detalleTareoActual.Observacion = "012" ' CULTIVO DE BAJA
            'detalleTareoActual.Observacion = "013" ' CULTIVO INEXISTENTE
        End If
        Return idCultivo
    End Function

    Private Function validarVariedad(idCultivo As String, idVariedad As String) As String
        If detalleTareoActual.Observacion.Length <= 0 Then
            idCultivo = Trim(UCase(idCultivo))
            idVariedad = Trim(UCase(idVariedad))
            Dim encontrado As Boolean = False
            For Each fila As DataRow In dataParaControles.Item("Variedades").Rows
                If fila.Item(0).ToString = idCultivo AndAlso fila.Item(1).ToString = idVariedad Then
                    encontrado = True
                    If fila.Item(2).ToString = "0" Then
                        detalleTareoActual.Observacion = "014" ' VARIEDAD DE BAJA
                    End If
                    Return idVariedad
                End If
            Next
            detalleTareoActual.Observacion = "015" ' VARIEDAD INEXISTENTE
        End If
        Return idVariedad
    End Function

    Private Function validarActividad(idActividad As String) As String
        If detalleTareoActual.Observacion.Length <= 0 Then
            idActividad = Trim(UCase(idActividad))
            Dim encontrado As Boolean = False
            For Each fila As DataRow In dataParaControles.Item("Actividades").Rows
                If fila.Item(0).ToString = idActividad Then
                    encontrado = True
                    If fila.Item(1).ToString = "0" Then
                        detalleTareoActual.Observacion = "007" ' ACTIVIDAD DE BAJA
                    End If
                    Return idActividad
                End If
            Next
            detalleTareoActual.Observacion = "008" ' ACTIVIDAD INEXISTENTE
        End If
        Return idActividad
    End Function

    Private Function validarLabor(idActividad As String, idLabor As String) As String
        If detalleTareoActual.Observacion.Length <= 0 Then
            idActividad = Trim(UCase(idActividad))
            idLabor = Trim(UCase(idLabor))
            Dim encontrado As Boolean = False
            For Each fila As DataRow In dataParaControles.Item("Labores").Rows
                If fila.Item(0).ToString = idActividad AndAlso fila.Item(1).ToString = idLabor Then
                    encontrado = True
                    If fila.Item(2).ToString = "0" Then
                        detalleTareoActual.Observacion = "009" ' LABOR DE BAJA
                    End If
                    Return idLabor
                End If
            Next
            detalleTareoActual.Observacion = "010" ' LABOR INEXISTENTE
        End If
        Return idLabor
    End Function


    Private Sub cboConsumidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboConsumidor.SelectedValueChanged
        'If cboConsumidor.Items.Count > 0 Then
        '    Dim anioCampana As String = "S/C"
        '    For Each fila As DataRow In dataParaControles.Tables(5).Rows
        '        If cboConsumidor.SelectedValue IsNot Nothing Then
        '            If fila.Item(0) = cboConsumidor.SelectedValue.ToString AndAlso fila.Item(2) <= tareoActual.Fecha _
        '            AndAlso fila.Item(3) >= tareoActual.Fecha Then
        '                anioCampana = fila.Item(1).ToString
        '            End If
        '        End If
        '    Next
        '    lblDin_Campana.Text = anioCampana
        'End If
    End Sub

    Private Sub resaltarObservaciones()
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If fila.Cells("T_Observacion").Value.ToString.Length > 0 Then
                fila.Cells("T_Trabajador").Style.BackColor = rojoAmarath
                fila.Cells("T_Trabajador").Style.ForeColor = blancoPuro_
            Else
                fila.Cells("T_Trabajador").Style.BackColor = blancoPuro_
                fila.Cells("T_Trabajador").Style.ForeColor = grisOnyx___
            End If
        Next
        dgvResultado.ClearSelection()
        dgvResultado.CurrentCell = Nothing
    End Sub

    Private Sub obtenerTablaPersonalJustificado(Fecha As Date)
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", Fecha)
            tablaPersonalJustificado = doItBaby("sp_Dg_PersonalJustificado", p, Datos.Conexion.TipoQuery.DataTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmSupervision_Movimientos_TareosDetalle_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        resaltarObservaciones()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        desbloquearControl(btnEditar)
        bloquearControl(btnGuardar)
        bloquearControl(btnPuntitos)
        bloquearControl(txtRutaExcel)
        bloquearControl(btnImportar)
        bloquearControl(btnEliminar)
        bloquearControl(btnCancelar)
        showToolstrip = False
        ''bloquearControl(gboDetalle)
        gboDetalle.Enabled = False
        bloquearControl(btnAgregar)
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede aprobar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If

        If usuarioActual <> "JMERA" And usuarioActual <> "JSIESQUEN" And usuarioActual <> "JCRUZ" Then
            MessageBox.Show("No tiene permisos para aprobar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = tareoActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            mensaje = String.Format("Esta seguro de aprobar el tareo: {0}", tareoActual.Id)
            respuesta = MessageBox.Show(mensaje, "Aprobar Tareo", MessageBoxButtons.YesNo)

            If respuesta = DialogResult.Yes Then
                Try
                    Dim parametros = New Dictionary(Of String, Object)
                    parametros.Add("@IdTareo", id)
                    If tareoActual.Estado = "PE" Then
                        doItBaby("sp_Dg_Supervision_Movimientos_Tareos_AprobarTareo", parametros, Datos.Conexion.TipoQuery.NonQuery)
                    Else
                        MessageBox.Show("El tareo actual no cuenta con estado PENDIENTE para poder aprobar.")
                    End If
                    MessageBox.Show("Tareo aprobado correctamente.")
                    dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, dgvResultado.SelectedRows(0).Index))
                Catch
                    MessageBox.Show("Error al tratar de aprobar tareo.")
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub

    Private Sub cboVariedad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboVariedad.SelectionChangeCommitted

        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdVariedad", cboVariedad.SelectedValue)

        'cargarCombo(cboVariedad, doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable), 0, 2)
    End Sub

    'Private Sub cbxSeleccionMultiple_CheckedChanged(sender As Object, e As EventArgs)
    '    If cbxSeleccionMultiple.Checked Then
    '        'btnActualizar.Enabled = True
    '        dgvResultado.MultiSelect = True
    '        'dgvResultado.SelectionMod
    '    Else
    '        dgvResultado.MultiSelect = False
    '    End If
    'End Sub

    Private Function convertToDateTable(data As DataGridViewSelectedRowCollection) As DataTable
        'Creating DataTable.
        Dim dt As New DataTable()

        'Adding the Columns.
        dt.Columns.Add("IdTareo")
        dt.Columns.Add("Item")
        dt.Columns.Add("IdTransferencia")
        dt.Columns.Add("T_Dni")
        dt.Columns.Add("T_Trabajador")
        dt.Columns.Add("T_IdPlanilla")
        dt.Columns.Add("T_Consumidor")
        dt.Columns.Add("T_Campana")
        dt.Columns.Add("T_IdCultivo")
        dt.Columns.Add("T_IdVariedad")
        dt.Columns.Add("T_IdActividad")
        dt.Columns.Add("T_Actividad")
        dt.Columns.Add("T_IdLabor")
        dt.Columns.Add("T_Labor")
        'HATCH
        'dt.Columns.Add("H1Ingreso")
        'dt.Columns.Add("H1Salida")
        dt.Columns.Add("D3Horas")
        dt.Columns.Add("D3Rdto")
        dt.Columns.Add("T_Observacion")
        'MODIFICACION 2024-05-11 HATCH

        Try
            Dim filaNueva As DataRow
            Dim numCols As Integer

            numCols = dt.Columns.Count

            ' Rellenamos los valores del DataTable nuevo con los valores de las celdas del DataGridView
            For Each filaDatos As DataGridViewRow In data
                Dim j = 0

                filaNueva = dt.NewRow()
                For i As Integer = 0 To numCols + 1
                    'MessageBox.Show(filaDatos.Cells(i).Value)
                    If i <> 14 AndAlso i <> 15 Then
                        filaNueva(j) = filaDatos.Cells(i).Value
                        j += 1
                    End If
                Next
                dt.Rows.Add(filaNueva)
            Next

            Return dt

        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    'Private Sub cboActividad_TextChanged(sender As Object, e As EventArgs) Handles cboActividad.TextChanged
    '    MessageBox.Show(cboActividad.Text)
    'End Sub
    Private Sub cboActividad_TextChanged(sender As Object, e As EventArgs) Handles cboActividad.TextChanged
        ' FilterComboBox(cboActividad.Text)
    End Sub

    Private Sub cboLabor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboLabor.SelectionChangeCommitted
        changeLabor = True
    End Sub

    Private Sub cboLabor_Click(sender As Object, e As EventArgs) Handles cboLabor.Click
        changeActividad = True
    End Sub

    Private Sub cboConsumidor_Click(sender As Object, e As EventArgs) Handles cboConsumidor.Click
        changeConsumidor = True
    End Sub

    Private Sub cboActividad_KeyUp(sender As Object, e As KeyEventArgs) Handles cboActividad.KeyUp
        Try
            cargarComboConFiltrado(cboActividad, dataParaControles.Item("Actividades"), 0, 2)
        Catch ex As Exception

        End Try
        'cargarComboConFiltrado(cboActividad, dataParaControles.Item("Actividades"), 0, 2)
        'Dim strText As String

        'strText = cboActividad.Text


        'If cboActividad.Text = "" Then
        '    Me.cboActividad.DataSource = Me.dataParaControles.Item("Actividades")
        '    Me.cboActividad.ValueMember = Me.dataParaControles.Item("Actividades").Columns(0).ColumnName
        '    Me.cboActividad.DisplayMember = Me.dataParaControles.Item("Actividades").Columns(2).ColumnName
        '    cboActividad.SelectedIndex = -1
        '    cboActividad.DroppedDown = False
        'End If

        'If Len(strText) >= 2 Then

        '    'cboActividad.DataSource = dataParaControles.Item("Actividades").Select("Concatenado LIKE '%" & strText & "%'")

        '    Dim dt As New DataTable()
        '    dt.Columns.Add("Clave")
        '    dt.Columns.Add("Valor")
        '    dt.Columns.Add("Concatenado")

        '    For Each fila As DataRow In dataParaControles.Item("Actividades").Select("Concatenado LIKE '%" & strText & "%'")
        '        dt.Rows.Add(fila.ItemArray)
        '    Next

        '    Me.cboActividad.DataSource = dt
        '    Me.cboActividad.ValueMember = dt.Columns(0).ColumnName
        '    Me.cboActividad.DisplayMember = dt.Columns(2).ColumnName

        '    If cboActividad.Items.Count <> 0 Then
        '        cboActividad.DroppedDown = True
        '        cboActividad.SelectedIndex = -1
        '        cboActividad.Text = ""
        '        cboActividad.SelectedText = strText
        '        strText = ""
        '        Cursor.Current = Cursors.Default
        '    Else
        '        Me.cboActividad.DataSource = dt
        '        Me.cboActividad.ValueMember = dt.Columns(0).ColumnName
        '        Me.cboActividad.DisplayMember = dt.Columns(2).ColumnName
        '        cboActividad.SelectedIndex = -1
        '        cboActividad.Text = ""
        '        cboActividad.SelectedText = strText
        '        strText = ""
        '        cboActividad.DroppedDown = False
        '    End If

        'End If
    End Sub

    Private Sub cboLabor_KeyUp(sender As Object, e As KeyEventArgs) Handles cboLabor.KeyUp
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdActividad", cboActividad.SelectedValue)
            'dataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, Datos.Conexion.TipoQuery.DataTable))
            cargarComboConFiltrado(cboLabor, doItBaby("sp_Dg_ObtenerLabores", p, Datos.Conexion.TipoQuery.DataTable), 0, 2)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboConsumidor_KeyUp(sender As Object, e As KeyEventArgs) Handles cboConsumidor.KeyUp
        Try
            cargarComboConFiltrado(cboConsumidor, dataParaControles.Item("Consumidores"), 0, 2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvResultado_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvResultado.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = dgvResultado.HitTest(e.X, e.Y)
            If showToolstrip Then
                ' Obtén la celda o fila en la que se hizo clic
                If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
                    ' Opcional: Selecciona la celda en la que se hizo clic
                    dgvResultado.CurrentCell = dgvResultado.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
                    filaSeleccionada = hit.RowIndex
                    ' Muestra el menú contextual en la posición del mouse
                    tsMenudgvDetalles.Show(dgvResultado, e.Location)
                End If
            End If
        End If
    End Sub

    Private Sub tsMenuItemEditarDNI_Click(sender As Object, e As EventArgs) Handles tsMenuItemEditarDNI.Click
        Dim tareoSeleccionado As String = dgvResultado.Rows(filaSeleccionada).Cells(0).Value.ToString
        Dim itemSeleccionado As Integer = dgvResultado.Rows(filaSeleccionada).Cells(1).Value
        Dim dniSeleccionado As String = dgvResultado.Rows(filaSeleccionada).Cells(3).Value.ToString
        Dim nombreSeleccionado As String = dgvResultado.Rows(filaSeleccionada).Cells(4).Value.ToString
        'MessageBox.Show(dniSeleccionado)
        Dim dialogEditarDNI As New frmSupervision_Movimientos_TareosDetalle_DialogEditarDNI(dniSeleccionado, nombreSeleccionado)
        dialogEditarDNI.StartPosition = FormStartPosition.CenterScreen
        If dialogEditarDNI.ShowDialog() = DialogResult.OK Then
            Dim dniActualizado As String = dialogEditarDNI.txtDni.Text.ToString
            Dim p As New Dictionary(Of String, Object)
            'MessageBox.Show(tareoSeleccionado)
            p.Add("@idTareo", tareoSeleccionado)
            p.Add("@item", itemSeleccionado)
            p.Add("@dni", dniActualizado)
            p.Add("@idUsuario", Temporales.usuarioActual)
            Dim response As DataTable = doItBaby("sp_Tareos_Detalle_Editar_DNI", p, Datos.Conexion.TipoQuery.DataTable)
            Dim filaResponse As DataRow = response.Rows(0)
            Dim linea As String = ""
            Dim mensaje As String = ""
            Dim procedimiento As String = ""
            If filaResponse.Item("code") = 1 Then
                linea = filaResponse.Item("linea")
                mensaje = filaResponse.Item("mensaje")
                procedimiento = filaResponse.Item("procedimiento")
                MessageBox.Show(Me, mensaje, procedimiento)
            ElseIf filaResponse.Item("code") = -1 Then
                linea = filaResponse.Item("linea")
                mensaje = filaResponse.Item("mensaje")
                procedimiento = filaResponse.Item("procedimiento")
                MessageBox.Show(Me, "procedimiento: " + procedimiento + " N°linea:" + linea + ":" + mensaje, "Error")
            Else
                MessageBox.Show("Ha ocurrido un error inesperado en el procedimiento sp_Tareos_Detalle_Editar_DNI.")
            End If
            listarDetalle()
            filaSeleccionada = -1
        End If
    End Sub



    'Private Sub FilterComboBox(filterText As String)
    '    cboActividad.Items.Clear() ' Limpiar elementos previos en el ComboBox
    '    If filterText.Trim() = "" Then
    '        ' Si el cuadro de texto está vacío, mostrar todos los elementos originales
    '        cboActividad.Items.AddRange(dataParaControles.Item("Actividades").Rows.Item)
    '        Return
    '    End If

    '    ' Filtrar los elementos que contienen el texto especificado en cualquier parte del elemento
    '    For Each item As String In Items
    '        If item.ToLower().Contains(filterText.ToLower()) Then
    '            cboActividad.Items.Add(item)
    '        End If
    '    Next
    'End Sub


    'Public Shared Widening Operator CType(v As frmSupervision_Movimientos_TareosDetalle) As frmSupervision_Movimientos_TareosDetalle
    '    Throw New NotImplementedException()
    'End Operator

    'Private Sub cboActividad_KeyDown(sender As Object, e As KeyEventArgs) Handles cboActividad.KeyDown
    '    If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down) And cboActividad.Text.Length > 0 Then
    '        MessageBox.Show($"You selected {cboActividad.Text}")
    '        Dim valor As String = Microsoft.VisualBasic.Left(cboActividad.Text, 3)
    '        cboActividad.SelectedValue = valor
    '        cboActividad_SelectionChangeCommitted(sender, e)
    '    End If
    'End Sub

    'Private Sub cboActividad_Leave(sender As Object, e As EventArgs) Handles cboActividad.Leave
    '    Dim valor As String = Microsoft.VisualBasic.Left(cboActividad.Text, 3)
    '    cboActividad.SelectedValue = valor
    '    cboActividad_SelectionChangeCommitted(sender, e)
    'End Sub

    'Private Sub cboCultivo_Leave(sender As Object, e As EventArgs) Handles cboCultivo.Leave
    '    Dim valor As String = Microsoft.VisualBasic.Left(cboCultivo.Text, 4)
    '    cboCultivo.SelectedValue = valor
    '    'cboCultivo_SelectionChangeCommitted(sender, e)
    '    cargarCombo(cboVariedad, dataParaControles.Tables(1), cboCultivo.SelectedValue.ToString, True)
    'End Sub
End Class

