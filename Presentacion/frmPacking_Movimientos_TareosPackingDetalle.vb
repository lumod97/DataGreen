Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion


Public Class frmPacking_Movimientos_TareosPackingDetalle
    Dim tareoActual As New Tareo
    Dim detalleTareoActual As DetalleTareo
    'Dim laborPackingActual As String
    'Dim lineaActual As String
    'Dim detalleTareoActual As New Dictionary(Of String, String)
    Dim dataParaControles As New DataSet
    Dim tablaParaDgvResultado As New DataTable

    'AGREGADO PARA ACTIVIDADES PACKING
    Dim actividadPackingActual As New DataTable ' Char() = {"", ""}
    Dim actividadPackingActualDetalle As DataRow

    Public Sub New(ByVal tareoSeleccionado As Tareo, tablas As DataSet)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        tareoActual = tareoSeleccionado
        dataParaControles = tablas
        dgvResultado.MultiSelect = False
        'actividadPackingActual = New DataTable
        actividadPackingActual.Columns.Add("LaborPacking")
        actividadPackingActual.Columns.Add("Linea")
        actividadPackingActualDetalle = actividadPackingActual.NewRow()
        'cargarControles()
    End Sub

    Private Sub frmSupervision_Movimientos_TareosDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        MessageBox.Show(tareoActual.Id)
        aplicarTema(Me)
        detalleTareoActual = New DetalleTareo(tareoActual.Id)
        tlpPrincipal.Visible = False
        'iniciarDetalleTareo()
        inicializarDataParaDgvResultado()
        listarDetalle()
        'cargarControles()
        'dgvResultado.DataSource = dataParaDgvResultado
        'formatearDataGridView(dgvResultado)
        'dgvResultado.Columns(0).Visible = False
        'dgvResultado.Columns(2).Visible = False

        actualizarCabeceraDeDetalle()
        txtDni.CharacterCasing = CharacterCasing.Upper
        bloquearControl(btnActualizar)


        bloquearCabecera()
        bloquearControl(btnPuntitos)
        bloquearControl(txtRutaExcel)
        bloquearControl(btnImportar)
        tlpPrincipal.Visible = True
        'cargarControles()
        ''BLOQUEO TEMPORAL HASTA DEFINIR PROCESO DE EDICION
        If tareoActual.DniResponsable = usuarioActual Then
            desbloquearControl(btnEditar)
            desbloquearControl(btnEliminar)
            'btnEditar.Enabled = True
        Else
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
        End If
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
        cboCultivo.SelectedValue = detalleTareoActual.Cultivo
        cboVariedad.SelectedValue = detalleTareoActual.Variedad
        cboActividad.SelectedValue = detalleTareoActual.Actividad
        cboLabor.SelectedValue = detalleTareoActual.Labor
        cboConsumidor.SelectedValue = detalleTareoActual.Consumidor
        lblDin_Campana.Text = detalleTareoActual.Campana

        'AGREGADO PARA ACTIVIDADES PACKING
        cboLaborPacking.SelectedValue = actividadPackingActualDetalle.Item(0)
        cboLinea.SelectedValue = actividadPackingActualDetalle.Item(1)

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
    '    detalleTareoActual.Add("subTotalRendimientos",
    '    dealletTareoActual.Add("ASD|)

    'End Sub

    Private Sub listarDetalle()
        'Dim dicObjetos As Dictionary(Of String, Object)

        'Dim resultado As DataSet = New DataSet
        'dataSetGeneral = execSP("sp_Dg_Supervision_Movimientos_Tareos_Detalle_CargarData", Nothing)
        ''dataSetGeneral.Tables.Add(resultado.Tables(0).Copy)
        'obtenerDataParaControles()
        dgvResultado.DataSource = Nothing
        If tareoActual.Estado = "D" Then
            'OBTENER DATOS DEL DETALLE
            Dim p = New Dictionary(Of String, Object)
            p.Add("@IdTareo", tareoActual.Id)
            Dim aux As DataTable
            aux = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarDetalle", p, Datos.Conexion.TipoQuery.DataTable)
            If aux IsNot Nothing Then
                tablaParaDgvResultado = aux.Copy
            End If
        ElseIf tareoActual.Estado = "L" Then
            'PENDIENTE DESDE SQLITE
        End If


        'obtener data sqlite
        'Dim auxSqlite As DataSet = New DataSet
        'auxSqlite = execSqlitePorNombre("selectSqliteTareos", Nothing, 3)
        'dataSetInicial.Tables(3).Merge(auxSqlite.Tables(0), True, MissingSchemaAction.Ignore)

        dgvResultado.DataSource = tablaParaDgvResultado
        formatearDataGridView(dgvResultado)
        dgvResultado.Columns(0).Visible = False
        dgvResultado.Columns(2).Visible = False

        corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()
    End Sub

    Private Sub cargarControles()
        'LLENAR TODOS LOS CONTROLES
        cargarCombo(cboCultivo, dataParaControles.Tables(0))
        cargarCombo(cboActividad, dataParaControles.Tables(2))
        cargarCombo(cboConsumidor, dataParaControles.Tables(4))
        cargarCombo(cboHhInicio, dataParaControles.Tables(6))
        cargarCombo(cboMmInicio, dataParaControles.Tables(7))
        cargarCombo(cboHhFin, dataParaControles.Tables(6).Copy)
        cargarCombo(cboMmFin, dataParaControles.Tables(7).Copy)
        'AGREGADO PARA LABORES PACKING
        cargarCombo(cboLaborPacking, dataParaControles.Tables(9))
        cargarCombo(cboLinea, dataParaControles.Tables(10))

        'textboxTrabajadores
        Dim listaTrabajadores As New AutoCompleteStringCollection
        For Each fila As DataRow In dataParaControles.Tables(8).Rows
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
        If cboLaborPacking.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar una labor packing valida.")
            Exit Sub
        ElseIf cboLinea.SelectedIndex < 0 Then
        MessageBox.Show("Debe seleccionar una linea valida.")
            Exit Sub
        End If
        capturarDatos()
        If detalleTareoActual.SubTotalHoras <= 0 Then
            MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
            Exit Sub
        ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
            MessageBox.Show("Debe ingresar un Dni vállido.")
            Exit Sub
            'ElseIf cboLaborPacking.SelectedIndex < 0 Then
            '    MessageBox.Show("Debe seleccionar una labor packing valida.")
            '    Exit Sub
            'ElseIf cboLinea.SelectedIndex < 0 Then
            '    MessageBox.Show("Debe seleccionar una linea valida.")
            '    Exit Sub
        End If
        'crearFila()
        'If lblDin_Item.Text = "0" Then
        '    insertarFila()
        'Else
        '    actualizarFila()
        'End If
        insertarFila()
        formatearDataGridView(dgvResultado)
        corregirCeldas(dgvResultado)
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
        'bloquearControl(cboLabor)
        'AGREGADO PARA ACTIVIDAD PACKING
        bloquearControl(cboLinea)
        bloquearControl(cboLaborPacking)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If cboCultivo.Items.Count < 1 Then
            cargarControles()
        End If
        gboDetalle.Enabled = True
        desbloquearControl(btnAgregar)
        bloquearControl(btnEditar)
        desbloquearControl(btnEliminar)

        desbloquearControl(btnPuntitos)
        desbloquearControl(txtRutaExcel)
        desbloquearControl(btnImportar)
        'desbloquearControl(cboLabor)
        'AGREGADO PARA ACTIVIDAD PACKING
        desbloquearControl(cboLinea)
        desbloquearControl(cboLaborPacking)
        'desbloquearControl(gboDetalle)
        pkrFin.Value = tareoActual.Fecha
    End Sub

    Private Sub cboConsumidor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboConsumidor.SelectedValueChanged
        If cboConsumidor.Items.Count > 0 Then
            Dim anioCampana As String = "S/C"
            For Each fila As DataRow In dataParaControles.Tables(5).Rows
                If cboConsumidor.SelectedValue IsNot Nothing Then
                    If fila.Item(0) = cboConsumidor.SelectedValue.ToString And fila.Item(2) <= tareoActual.Fecha _
                    And fila.Item(3) >= tareoActual.Fecha Then
                        anioCampana = fila.Item(1).ToString
                    End If
                End If
            Next
            lblDin_Campana.Text = anioCampana
        End If
    End Sub

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
        For Each fila As DataRow In dataParaControles.Tables(8).Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                aux = fila.Item(2).ToString
                Exit For
            End If
        Next
        For Each ch As Char In aux
            If Char.IsLetter(ch) Or ch = " " Then
                trabajador += ch
            End If
        Next
        Return trabajador
    End Function

    Private Function obtenerPlanilla() As String
        'Dim planilla As String = String.Empty
        For Each fila As DataRow In dataParaControles.Tables(8).Rows
            If fila.Item(0).ToString = detalleTareoActual.Dni Then
                Return fila.Item(3).ToString
                Exit For
            End If
        Next
        Return String.Empty
    End Function

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
        If lblDin_Item.Text = "0" Then
            detalleTareoActual.Item = dgvResultado.Rows.Count + 1
        End If
        detalleTareoActual.Estado = "M"
        detalleTareoActual.Dni = obtenerDni()
        detalleTareoActual.Trabajador = obtenerTrabajador()
        detalleTareoActual.Planilla = obtenerPlanilla()
        detalleTareoActual.Consumidor = cboConsumidor.SelectedValue
        detalleTareoActual.Campana = lblDin_Campana.Text
        detalleTareoActual.Cultivo = cboCultivo.SelectedValue
        detalleTareoActual.Variedad = cboVariedad.SelectedValue
        detalleTareoActual.Actividad = cboActividad.SelectedValue
        detalleTareoActual.Labor = cboLabor.SelectedValue
        detalleTareoActual.Inicio = obtenerFechaInicio()
        detalleTareoActual.Fin = obtenerFechaFin()
        detalleTareoActual.SubTotalHoras = obtenerHoras()
        detalleTareoActual.SubTotalRendimiento = CType(IIf(txtRendimiento.Text = "", 0, txtRendimiento.Text), Double)
        'ADICION PARA ACTIVIDADES PACKING
        actividadPackingActualDetalle.Item(0) = cboLaborPacking.SelectedValue
        actividadPackingActualDetalle.Item(1) = cboLinea.SelectedValue
    End Sub

    Private Sub capturarDatosDesdeDataRow(fila As DataRow)
        'COLUMNAS EXCEL:-->   DNI-CONSUMIDOR-CULTIVO-VARIEDAD-ACTIVIDAD-LABOR-SUBTOTALHORAS
        If lblDin_Item.Text = "0" Then
            detalleTareoActual.Item = dgvResultado.Rows.Count + 1
        End If
        detalleTareoActual.Estado = "M"
        detalleTareoActual.Dni = fila.Item(0)
        detalleTareoActual.Trabajador = obtenerTrabajador()
        detalleTareoActual.Planilla = obtenerPlanilla()
        detalleTareoActual.Consumidor = fila.Item(1)
        detalleTareoActual.Campana = "S/C" 'lblDin_Campana.Text
        detalleTareoActual.Cultivo = fila.Item(2) ' "0000" 'cboCultivo.SelectedValue
        detalleTareoActual.Variedad = fila.Item(3) '"000" 'cboVariedad.SelectedValue
        detalleTareoActual.Actividad = fila.Item(4) 'cboActividad.SelectedValue
        detalleTareoActual.Labor = fila.Item(5) 'cboLabor.SelectedValue
        detalleTareoActual.Inicio = obtenerFechaInicio()
        detalleTareoActual.Fin = obtenerFechaFin()
        detalleTareoActual.SubTotalHoras = CType(fila.Item(8), Double) 'obtenerHoras()
        detalleTareoActual.SubTotalRendimiento = 0 'CType(IIf(txtRendimiento.Text = "", 0, txtRendimiento.Text), Double)
        'ADICION PARA ACTIVIDADES PACKING
        actividadPackingActualDetalle.Item(0) = fila.Item(6)
        actividadPackingActualDetalle.Item(1) = fila.Item(7)
    End Sub

    Private Sub insertarFila()
        'Dim fila As New DataGridViewRow
        'fila = dgvResultado.

        Dim fila As DataRow
        fila = tablaParaDgvResultado.NewRow()

        'Dim i As Integer = dgvResultado.Rows.Add()
        'dgvResultado.Rows(i).Cells
        fila.Item(0) = detalleTareoActual.Id
        fila.Item(1) = detalleTareoActual.Item
        fila.Item(2) = ""
        fila.Item(3) = detalleTareoActual.Estado
        'AGREGADO PARA ACTIVIDADES PACKING
        fila.Item(4) = actividadPackingActualDetalle(0)
        fila.Item(5) = actividadPackingActualDetalle(1)

        fila.Item(6) = detalleTareoActual.Dni
        fila.Item(7) = detalleTareoActual.Trabajador
        fila.Item(8) = detalleTareoActual.Planilla
        fila.Item(9) = detalleTareoActual.Consumidor
        fila.Item(10) = detalleTareoActual.Campana
        fila.Item(11) = detalleTareoActual.Cultivo
        fila.Item(12) = detalleTareoActual.Variedad
        fila.Item(13) = detalleTareoActual.Actividad
        fila.Item(14) = detalleTareoActual.Labor
        fila.Item(15) = detalleTareoActual.Inicio
        fila.Item(16) = detalleTareoActual.Fin
        fila.Item(17) = detalleTareoActual.SubTotalHoras
        fila.Item(18) = detalleTareoActual.SubTotalRendimiento
        tablaParaDgvResultado.Rows.Add(fila)
        'dgvResultado.Rows.Add(fila)

    End Sub

    Private Sub inicializarDataParaDgvResultado()
        If tablaParaDgvResultado.Columns.Count = 0 Then
            tablaParaDgvResultado.Columns.Add("Id")
            tablaParaDgvResultado.Columns.Add("Item")
            tablaParaDgvResultado.Columns.Add("IdTransf")
            tablaParaDgvResultado.Columns.Add("Estado")
            'AGREGADO PARA ACTIVIDADES PACKING
            tablaParaDgvResultado.Columns.Add("L_P")
            tablaParaDgvResultado.Columns.Add("Linea")

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
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso gboDetalle.Enabled Then
            detalleTareoActual = obtenerDetalleDesdeFila(tablaParaDgvResultado.Rows(dgvResultado.CurrentRow.Index))
            actividadPackingActualDetalle.Item(0) = dgvResultado.Rows(dgvResultado.CurrentRow.Index).Cells(4).Value
            actividadPackingActualDetalle.Item(1) = dgvResultado.Rows(dgvResultado.CurrentRow.Index).Cells(5).Value
            actualizarCabeceraDeDetalle()
            If Not btnActualizar.Enabled Then
                desbloquearControl(btnActualizar)
                desbloquearControl(btnEliminar)
                bloquearControl(btnGuardar)
                bloquearControl(btnAgregar)
                bloquearControl(txtDni)
            End If
        End If
    End Sub
    Private Sub txtRendimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRendimiento.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
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
        fila = tablaParaDgvResultado.NewRow()
        fila.Item(0) = detalleTareoActual.Id
        fila.Item(1) = detalleTareoActual.Item
        fila.Item(2) = ""
        fila.Item(3) = detalleTareoActual.Estado
        'AGREGADO PARA ACTIVIDADES PACKING
        fila.Item(4) = actividadPackingActualDetalle(0)
        fila.Item(5) = actividadPackingActualDetalle(1)

        fila.Item(6) = detalleTareoActual.Dni
        fila.Item(7) = detalleTareoActual.Trabajador
        fila.Item(8) = detalleTareoActual.Planilla
        fila.Item(9) = detalleTareoActual.Consumidor
        fila.Item(10) = detalleTareoActual.Campana
        fila.Item(11) = detalleTareoActual.Cultivo
        fila.Item(12) = detalleTareoActual.Variedad
        fila.Item(13) = detalleTareoActual.Actividad
        fila.Item(14) = detalleTareoActual.Labor
        fila.Item(15) = detalleTareoActual.Inicio
        fila.Item(16) = detalleTareoActual.Fin
        fila.Item(17) = detalleTareoActual.SubTotalHoras
        fila.Item(18) = detalleTareoActual.SubTotalRendimiento
        Dim i As Integer = 0
        For Each row As DataRow In tablaParaDgvResultado.Rows
            If row.Item(1).ToString = detalleTareoActual.Item Then
                'i = row.Item(1)
                'Dim j As Integer = 0
                Dim k As Integer = tablaParaDgvResultado.Columns.Count - 1
                For j = 0 To k Step 1
                    If j <> 6 Then
                        tablaParaDgvResultado.Rows(i).Item(j) = fila.Item(j)
                    End If
                Next
                'For Each it As DataGridCell In dataParaDgvResultado.Rows(i).ItemArray
                '    it = fila.Item(j)
                '    j += 1
                'Next
            End If
            i += 1
        Next

        'dataParaDgvResultado.Rows.Add(fila)
        'dgvResultado.Rows.Add(fila)
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        capturarDatos()
        If detalleTareoActual.SubTotalHoras <= 0 Then
            MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
            Exit Sub
        ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
            MessageBox.Show("Debe ingresar un Dni vállido.")
            Exit Sub
        End If
        capturarDatos()
        actualizarFila()
        formatearDataGridView(dgvResultado)
        corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()
        lblDin_Item.Text = "0"
        bloquearControl(btnActualizar)
        desbloquearControl(btnAgregar)
        desbloquearControl(txtDni)
        desbloquearControl(btnGuardar)
        txtDni.Text = ""
        txtDni.Focus()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        tareoActual.Detalle = New List(Of DetalleTareo)
        For Each fila As DataRow In tablaParaDgvResultado.Rows
            detalleTareoActual = obtenerDetalleDesdeFila(fila)
            tareoActual.AgregarDetalle(detalleTareoActual)
            actividadPackingActualDetalle.Item(0) = fila.Item(4)
            actividadPackingActualDetalle.Item(1) = fila.Item(5)
            Dim filaAux As DataRow = actividadPackingActualDetalle
            actividadPackingActual.Rows.Add(filaAux.ItemArray)
        Next
        If tareoActual.ContarTareos > 0 Then
            'tareoActual.GuardarDetalle()
            If guardarDetalle() Then
                listarDetalle()
                desbloquearControl(btnEditar)
                bloquearControl(btnGuardar)
                bloquearControl(btnPuntitos)
                bloquearControl(txtRutaExcel)
                bloquearControl(btnImportar)
                ''bloquearControl(gboDetalle)
                gboDetalle.Enabled = False
                bloquearControl(btnAgregar)
                MessageBox.Show("Detalle guardado correctamente.")
            End If
            'MessageBox.Show("total detalles:" + tareoActual.TotalDetalles.ToString)
        Else
            MessageBox.Show("No se puede guardar un tareo vacio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        bloquearFilas(dgvResultado)
        Dim item As String = detalleTareoActual.Item
        Dim respuesta As DialogResult = MessageBox.Show("Esta seguro de eliminar el item: " + item, "Eliminar", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.Yes Then
            For i As Integer = 0 To tablaParaDgvResultado.Rows.Count - 1 Step 1
                If tablaParaDgvResultado.Rows(i).Item(1) = item Then
                    'tablaParaDgvResultado.Rows(i).Delete()
                    tablaParaDgvResultado.Rows.RemoveAt(i)
                    Exit For
                End If
            Next
            'dataParaDgvResultado.Rows(dgvResultado.CurrentRow.Index).Delete()
            Dim j As Integer = 0
            For Each fila As DataRow In tablaParaDgvResultado.Rows
                fila.Item(1) = j + 1
                'dataParaDgvResultado.Rows(j).Item(1) = j + 1
                j += 1
            Next
            MessageBox.Show("Item: " + item + " eliminado correctamente.")
        End If
        desbloquearFilas(dgvResultado)
        bloquearControl(btnActualizar)
        desbloquearControl(txtDni)
        desbloquearControl(btnAgregar)
        desbloquearControl(btnGuardar)
        txtDni.Text = ""
        txtDni.Focus()
    End Sub
    Private Function obtenerDetalleDesdeFila(fila As DataRow) As DetalleTareo
        Dim aux As New DetalleTareo
        'Dim f As Integer = dgvResultado.CurrentRow.Index
        aux.Id = tareoActual.Id
        aux.Item = fila.Item(1) 'dgvResultado.Rows(f).Cells(1).Value
        aux.Estado = "M"
        aux.Dni = fila.Item(6) 'dgvResultado.Rows(f).Cells(4).Value
        aux.Trabajador = fila.Item(7) 'dgvResultado.Rows(f).Cells(5).Value
        aux.Planilla = fila.Item(8) 'dgvResultado.Rows(f).Cells(6).Value
        aux.Consumidor = fila.Item(9) 'dgvResultado.Rows(f).Cells(7).Value
        aux.Campana = fila.Item(10) 'dgvResultado.Rows(f).Cells(8).Value
        aux.Cultivo = fila.Item(11) 'dgvResultado.Rows(f).Cells(9).Value
        aux.Variedad = fila.Item(12) 'dgvResultado.Rows(f).Cells(10).Value
        aux.Actividad = fila.Item(13) 'dgvResultado.Rows(f).Cells(11).Value
        aux.Labor = fila.Item(14) 'dgvResultado.Rows(f).Cells(12).Value
        aux.Inicio = fila.Item(15) 'dgvResultado.Rows(f).Cells(13).Value
        aux.Fin = fila.Item(16) 'dgvResultado.Rows(f).Cells(14).Value
        aux.SubTotalHoras = fila.Item(17) 'dgvResultado.Rows(f).Cells(15).Value
        aux.SubTotalRendimiento = fila.Item(18) 'dgvResultado.Rows(f).Cells(16).Value
        Return aux
    End Function

    Private Function guardarDetalle() As Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Id", tareoActual.Id)
        'modificacion
        doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        Dim cadena As String = String.Empty
        'Dim p As New Dictionary(Of String, Object)
        p = New Dictionary(Of String, Object)
        p.Add("@CadenaParametros", String.Empty)
        Dim formato As String = "yyyy-MM-dd HH:mm:ss.fff"
        Dim i As Integer = 0
        For Each d As DetalleTareo In tareoActual.Detalle
            cadena = cadena + d.Id + ","
            cadena = cadena + d.Item.ToString + ","
            cadena = cadena + d.Dni + ","
            cadena = cadena + d.Planilla + ","
            cadena = cadena + d.Consumidor + ","
            cadena = cadena + d.Campana + ","
            cadena = cadena + d.Cultivo + ","
            cadena = cadena + d.Variedad + ","
            cadena = cadena + d.Actividad + ","
            cadena = cadena + d.Labor + ","
            cadena = cadena + d.Inicio.ToString(formato) + ","
            cadena = cadena + d.Fin.ToString(formato) + ","
            cadena = cadena + d.SubTotalHoras.ToString + ","
            cadena = cadena + d.SubTotalRendimiento.ToString + ","
            'CONCATENAR EN LA CADENA LA LINEA Y LA LABOR
            'cadena = cadena + cboLaborPacking.SelectedValue.ToString
            'cadena = cadena + cboLinea.SelectedValue.ToString
            'MessageBox.Show(cadena)
            cadena = cadena + actividadPackingActual.Rows(i).Item(0) + ","
            cadena = cadena + actividadPackingActual.Rows(i).Item(1)
            i += 1
            p("@CadenaParametros") = cadena
            Try
                If tareoActual.Estado = "D" Then
                    doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
                Else
                    'PENDIENTE EJECUATAR GUARDADO EN SQLITE
                End If
            Catch
                Return False
            End Try
            cadena = String.Empty
        Next
        Return True
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "M" Then
        '    exec("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        'ElseIf tareoActual.Estado = "L" Then
        '    'PENDIENTE GUARDAR EN SQLITE
        'End If
    End Function

    'Private Sub cboCultivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCultivo.SelectedValueChanged
    '    cargarCombo(cboVariedad, dataParaControles.Tables(1), cboCultivo.SelectedValue.ToString)
    'End Sub

    'Private Sub cboActividad_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboActividad.SelectedValueChanged
    '    cargarCombo(cboLabor, dataParaControles.Tables(3), cboActividad.SelectedValue.ToString)
    'End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim dtTablaExcel As New DataTable
        dtTablaExcel = cargarExcel(txtRutaExcel.Text)
        For Each fila As DataRow In dtTablaExcel.Rows()
            capturarDatosDesdeDataRow(fila)
            If detalleTareoActual.SubTotalHoras <= 0 Then
                MessageBox.Show("El recuento de horas no puede ser menor o igual a cero.")
                Exit Sub
            ElseIf detalleTareoActual.Dni.Length <> 8 And lblDin_Item.Text = "0" Then
                MessageBox.Show("Debe ingresar un Dni vállido.")
                Exit Sub
            End If
            insertarFila()
            formatearDataGridView(dgvResultado)
            'corregirCeldas(dgvResultado)
            'dgvResultado.AutoResizeColumns()
            'dgvResultado.AutoResizeRows()
            'lblDin_Item.Text = "0"            
        Next
        txtDni.Text = ""
        txtDni.Focus()
        desbloquearControl(btnGuardar)
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        cargarCombo(cboVariedad, dataParaControles.Tables(1), cboCultivo.SelectedValue.ToString)
    End Sub

    Private Sub cboActividad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActividad.SelectionChangeCommitted
        cargarCombo(cboLabor, dataParaControles.Tables(3), cboActividad.SelectedValue.ToString)
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub
End Class
