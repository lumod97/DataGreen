Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports Entidades

Public Class frmEstandares

    Dim dsDataParaCombos As DataSet
    Dim bsResultado As New BindingSource()
    Dim dtPersonasSeleccionadas As DataTable
    Dim dtDataPersonas As DataTable
    Dim dvResultado As DataView 'New DataView(tablaParaDgv)
    Dim vieneDeDgv As Boolean = False


    Dim bsDisponibles As New BindingSource
    Dim dvDisponibles As New DataView
    Dim dsDataParaCombo As DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim anio, mes As Integer
    Dim ultimoDiaMes As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Today))
    Private Sub frmEstandares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboAnio, dsDataParaCombo.Tables(0), "", False)
        cargarCombo(cboTipoCampana, dsDataParaCombo.Tables(1), "", False)
        pkrFechaDesde.Value = "2023-05-01" 'New Date(Year(Now()), Month(Now()), 1)
        'pkrFechaHasta.Value = Now()
        listarEstandaresSeleccionadas()
        tlpPrincipal.Visible = True
        'btnCancelar_Click(New Object, New EventArgs)
    End Sub
    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasSemanaXFechasXanio", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerEtapasCampania", Nothing, TipoQuery.DataTable))

    End Sub

    Private Sub cboTipoCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipoCampana.SelectionChangeCommitted

        For i As Integer = 1 To dsDataParaCombo.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombo.Tables.RemoveAt(1)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTipoCampana", cboTipoCampana.SelectedValue)  'IIf(cboEtapa.SelectedIndex >= 0, cboEtapa.SelectedValue, ""))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasXTipoConsumidor", p, TipoQuery.DataTable))
        cargarCombo(cboConsumidor, dsDataParaCombo.Tables(1), "", False)

    End Sub

    Private Sub cboConsumidor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboConsumidor.SelectionChangeCommitted
        For i As Integer = 2 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IDConsumidor", cboConsumidor.SelectedValue)  'IIf(cboEtapa.SelectedIndex >= 0, cboEtapa.SelectedValue, ""))
        ''p.Add("@IdActividad", cboConsumidor.SelectedValue) 'IIf(cboDivision.SelectedIndex >= 0, cboDivision.SelectedValue, ""))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasXTipoConsumidorActividad", p, TipoQuery.DataTable))
        cargarCombo(cboActividad, dsDataParaCombo.Tables(2), "", True)
    End Sub

    Private Sub cboActividad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActividad.SelectionChangeCommitted
        For i As Integer = 3 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(3)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IDConsumidor", cboConsumidor.SelectedValue)
        p.Add("@IdActividad", cboActividad.SelectedValue)
        'p.Add("@IdCultivo", cboActividad.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasXTipoConsumidorActividadXLabor", p, TipoQuery.DataTable))
        cargarCombo(cboLabor, dsDataParaCombo.Tables(3), "", True)
    End Sub

    Private Sub validarSeleccion()
        If cboSemana.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Tipo de Costo valido.")
            Exit Sub
        ElseIf cboTipoCampana.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Cultivo valido.")
            Exit Sub
        ElseIf cboConsumidor.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar una Actividad valida.")
            Exit Sub
        ElseIf cboActividad.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar una Division valida.")
            Exit Sub
        ElseIf cboLabor.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un CGI valido.")
            Exit Sub
        End If
    End Sub
    '    @anio varchar(5),
    '@Semana varchar(10),
    '@FechaDesde date,
    '@Fechahasta date,
    '@IdTipoCampana varchar(3),
    '@IdConsumidor VARCHAR(12),
    '@IdActividad VARCHAR(3),
    '@IdLabor VARCHAR(6),
    '@Tarea varchar(25)
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@anio", cboAnio.SelectedValue)
            p.Add("@Semana", cboSemana.SelectedValue)
            p.Add("@FechaDesde", pkrFechaDesde.Value)
            p.Add("@Fechahasta", pkrFechaHasta.Value)
            p.Add("@IdTipoCampana", cboTipoCampana.SelectedValue)
            p.Add("@IdConsumidor", cboConsumidor.SelectedValue)
            p.Add("@IdActividad", cboActividad.SelectedValue)
            p.Add("@IdLabor", cboLabor.SelectedValue)
            p.Add("@Tarea", txtTarea.Text)
            'p.Add("@Tarea", miPedido.Fecha)
            'Dim t As DataTable = obtenerTablaParaSP(dtConsolidados, "0")

            ' p.Add("@dtTabla", t)
            Dim r As DataTable = doItBaby("sp_Dg_Supervision_Movimientos_Estandares", p, TipoQuery.DataTable)
            'If r.Rows(0).Item("Resultado") = 1 Then
            '    miPedido.Id = r.Rows(0).Item("Detalle")
            '    'actualizarCabecera()
            MessageBox.Show(" guardado con exito.")
            listarEstandaresSeleccionadas()
            'ElseIf r.Rows(0).Item("Resultado") = 0 Then
            'Throw New Exception(r.Rows(0).Item("Detalle"))
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub limpiarFila(ByRef fila() As String)
        fila = {"", "", "", "", "", "", "", "", ""}
        Dim i As Integer = 0
        For Each e As String In fila
            fila(i) = String.Empty
            i = i + 1
        Next
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim v As New frmEstandares
        v.MdiParent = Me.MdiParent
        v.Show()
    End Sub

    Private Sub actualizarFiltro()
        Dim filtro As String = String.Empty
        'filtro = String.Format("F_Dia >= '{0:yyyy-MM-dd}' And " +
        '                                   "F_Dia <= '{1:yyyy-MM-dd}'",
        '                                    pkrFechaDesde.Value,
        '                                    pkrFechaHasta.Value
        '                                    )
        If cboTipoCampana.SelectedValue <> "T" Then
            filtro = filtro + String.Format(" And T_TipoCampana = '{0}'",
                                            cboTipoCampana.SelectedValue.ToString
                                            )
        End If
        If cboConsumidor.SelectedValue <> "T" Then
            filtro = filtro + String.Format(" And T_Consumidor = '{0}'",
                                            cboConsumidor.SelectedValue.ToString
                                            )
        End If
        'If cboActividad.SelectedValue <> "T" Then
        '    filtro = filtro + String.Format(" And T_Actividad = '{0}'",
        '                                    cboActividad.SelectedValue.ToString
        '                                    )
        'End If
        'If cboLabor.SelectedValue <> "T" Then
        '    filtro = filtro + String.Format(" And T_Labor = '{0}'",
        '                                    cboLabor.SelectedValue.ToString
        '                                    )
        'End If
        bsResultado.Filter = filtro

        '' lblDin_Resultado.Text = "Coincicidencias: " + bsResultado.Count.ToString
        'filasSeleccionadas = 0
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        Dim aux As Date
        anio = CType(cboAnio.SelectedValue.ToString.Substring(0, 4), Integer)
        ' mes = CType(cboSemana.SelectedValue.ToString.Substring(0, 1), Integer)
        aux = DateSerial(anio, mes, 1)
        aux = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, aux))
        'dia = aux.Day
        ultimoDiaMes = aux
        pkrFechaDesde.Value = ultimoDiaMes
        pkrFechaHasta.Value = ultimoDiaMes


        For i As Integer = 1 To dsDataParaCombo.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombo.Tables.RemoveAt(1)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@anio", cboTipoCampana.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasSemanaXFechasXanioSemana", p, TipoQuery.DataTable))
        cargarCombo(cboSemana, dsDataParaCombo.Tables(1), "", False)
    End Sub

    Private Sub cboSemana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSemana.SelectionChangeCommitted

        Dim aux As Date
        ''  anio = CType(cboAnio.SelectedValue.ToString.Substring(0, 4), Integer)
        mes = CType(cboSemana.SelectedValue.ToString.Substring(0, 2), Integer)
        aux = DateSerial(anio, mes, 1)
        aux = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, aux))
        'dia = aux.Day
        ultimoDiaMes = aux
        pkrFechaDesde.Value = ultimoDiaMes
        ' pkrFechaHasta.Value = ultimoDiaMes

    End Sub
    'Public Function BuscarFechas()

    'End Function

    Private Async Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    'Public Function buscarTipoCampana(tipocampana As String) As String
    '    For Each fila As DataRow In dtDataPersonas.Rows
    '        If fila.Item(0) = tipocampana Then
    '            Return fila.Item(4)
    '        End If
    '    Next
    '    Return "CAMPAÑA DESCONOCIDO"
    'End Function

    'Private Sub cboTipoCampana_KeyUp(sender As Object, e As KeyEventArgs) Handles cboTipoCampana.KeyUp
    '    If vieneDeDgv Then
    '        vieneDeDgv = False
    '        Exit Sub
    '    End If
    '    If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And dgvResultado.RowCount > 0 Then
    '        dgvResultado.Focus()
    '    ElseIf e.KeyCode = Keys.Down And dgvResultado.RowCount <= 0 Then
    '        cboTipoCampana.SelectAll()
    '    ElseIf e.KeyCode = Keys.Enter And dgvResultado.RowCount <= 0 Then

    '        ''actualizarSumatorias()
    '        cboTipoCampana.Text = ""
    '        e.SuppressKeyPress = True
    '        Exit Sub
    '    Else
    '        bsResultado.Filter = String.Format("T_TipoCampana like '%{4}%' Or " + cboTipoCampana.Text)
    '    End If
    'End Sub
    'Private Function buscarIndiceEstandares(TipoCampana As String, Consumidor As String, Actividad As String, Labor As String) As Integer
    '    Dim f As Integer = 0
    '    For f = 0 To dtPersonasSeleccionadas.Rows.Count - 1 Step 1
    '        If dtPersonasSeleccionadas.Rows(f).Item(4) = TipoCampana AndAlso dtPersonasSeleccionadas.Rows(f).Item(9) = Consumidor AndAlso dtPersonasSeleccionadas.Rows(f).Item(10) = Actividad AndAlso dtPersonasSeleccionadas.Rows(f).Item(11) = Labor Then
    '            Return f
    '            Exit For
    '        End If
    '    Next
    '    Return -1
    ''End Function
    'Private Sub dgvResultado_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvResultado.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        ' agregarDniParaCodigo(dgvResultado.Rows(dgvResultado.CurrentRow.Index).Cells(0).Value, dgvResultado.CurrentRow) 'dgvPersonas.CurrentRow.Cells(0).Value)
    '        'actualizarSumatorias()
    '        e.Handled = True
    '        vieneDeDgv = True
    '    ElseIf e.KeyCode = Keys.Back Then
    '        cboTipoCampana.Focus()
    '    End If
    'End Sub
    'Public Function buscarConsumidor(Consumidor As String) As String
    '    For Each fila As DataRow In dtDataPersonas.Rows
    '        If fila.Item(0) = Consumidor Then
    '            Return fila.Item(9)
    '        End If
    '    Next
    '    Return "CONSUMIDOR DESCONOCIDO"
    'End Function
    'Private Sub cboConsumidor_KeyUp(sender As Object, e As KeyEventArgs) Handles cboConsumidor.KeyUp
    '    If vieneDeDgv Then
    '        vieneDeDgv = False
    '        Exit Sub
    '    End If
    '    If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And dgvResultado.RowCount > 0 Then
    '        dgvResultado.Focus()
    '    ElseIf e.KeyCode = Keys.Down And dgvResultado.RowCount <= 0 Then
    '        cboConsumidor.SelectAll()
    '    ElseIf e.KeyCode = Keys.Enter And dgvResultado.RowCount <= 0 Then

    '        ''actualizarSumatorias()
    '        cboConsumidor.Text = ""
    '        e.SuppressKeyPress = True
    '        Exit Sub
    '    Else
    '        bsResultado.Filter = String.Format("T_Consumidor like '%{09}%' Or " + cboConsumidor.SelectedValue)
    '    End If
    'End Sub

    'Public Function buscarLabor(Labor As String) As String
    '    For Each fila As DataRow In dtDataPersonas.Rows
    '        If fila.Item(0) = Labor Then
    '            Return fila.Item(11)
    '        End If
    '    Next
    '    Return "LABOR DESCONOCIDO"
    'End Function
    'Private Sub cboLabor_KeyUp(sender As Object, e As KeyEventArgs) Handles cboLabor.KeyUp
    '    If vieneDeDgv Then
    '        vieneDeDgv = False
    '        Exit Sub
    '    End If
    '    If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And dgvResultado.RowCount > 0 Then
    '        dgvResultado.Focus()
    '    ElseIf e.KeyCode = Keys.Down And dgvResultado.RowCount <= 0 Then
    '        cboLabor.SelectAll()
    '    ElseIf e.KeyCode = Keys.Enter And dgvResultado.RowCount <= 0 Then

    '        ''actualizarSumatorias()
    '        cboLabor.Text = ""
    '        e.SuppressKeyPress = True
    '        Exit Sub
    '    Else
    '        bsResultado.Filter = String.Format("T_Labor like '%{11}%' Or " + cboLabor.SelectedValue)

    '    End If
    'End Sub


    'Public Function buscarActividad(Actividad As String) As String
    '    For Each fila As DataRow In dtDataPersonas.Rows
    '        If fila.Item(0) = Actividad Then
    '            Return fila.Item(10)
    '        End If
    '    Next
    '    Return "ACTIVIDAD DESCONOCIDO"
    'End Function
    'Private Sub cboActividad_KeyUp(sender As Object, e As KeyEventArgs) Handles cboActividad.KeyUp
    '    If vieneDeDgv Then
    '        vieneDeDgv = False
    '        Exit Sub
    '    End If
    '    If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And dgvResultado.RowCount > 0 Then
    '        dgvResultado.Focus()
    '    ElseIf e.KeyCode = Keys.Down And dgvResultado.RowCount <= 0 Then
    '        cboActividad.SelectAll()
    '    ElseIf e.KeyCode = Keys.Enter And dgvResultado.RowCount <= 0 Then

    '        ''actualizarSumatorias()
    '        cboActividad.Text = ""
    '        e.SuppressKeyPress = True
    '        Exit Sub
    '    Else
    '        bsResultado.Filter = String.Format("T_Actividad like '%{10}%' Or " + cboActividad.SelectedText)

    '    End If
    'End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)

            p.Add("@FechaDesde", CType(pkrFechaDesde.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@FechaHasta", CType(pkrFechaHasta.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@IdTipoCampana", cboTipoCampana.SelectedValue)
            p.Add("@idconsumidor", cboConsumidor.SelectedValue)
            p.Add("@idactividad", cboActividad.SelectedValue)
            p.Add("@idlabor", cboLabor.SelectedValue)

            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_ObtenerListaEstandares_XConsumidorXActividad", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub cboTipoCampana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCampana.SelectedIndexChanged
        If tlpPrincipal.Visible = True Then
            actualizarFiltro()
        End If
    End Sub

    Private Sub cboConsumidor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboConsumidor.SelectedIndexChanged
        If tlpPrincipal.Visible = True Then
            actualizarFiltro()
        End If
    End Sub

    Private Sub cboActividad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActividad.SelectedIndexChanged
        If tlpPrincipal.Visible = True Then
            actualizarFiltro()
        End If
    End Sub

    Private Sub cboLabor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLabor.SelectedIndexChanged
        If tlpPrincipal.Visible = True Then
            actualizarFiltro()
        End If
    End Sub

    Private Sub listarEstandaresSeleccionadas()
        'Dim aux As New DataTable
        'Dim p As New Dictionary(Of String, Object)

        'p.Add("@FechaDesde", CType(pkrFechaDesde.Value.ToString("dd/MM/yyyy"), DateTime))
        'p.Add("@FechaHasta", CType(pkrFechaHasta.Value.ToString("dd/MM/yyyy"), DateTime))
        'arrayDeParametros = obtenerCadenaParametros(p)
        dtPersonasSeleccionadas = doItBaby("sp_Dg_ObtenerListaEstandares", Nothing, TipoQuery.DataTable)
        corregirTabla(dtPersonasSeleccionadas)
        dgvResultado.DataSource = dtPersonasSeleccionadas
        formatearDataGridView(dgvResultado, True)
        ''actualizarSumatorias()
        '''

    End Sub

End Class