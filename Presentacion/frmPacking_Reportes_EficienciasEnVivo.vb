Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports System.Windows.Threading

Public Class frmPacking_Reportes_EficienciasEnVivo
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim flag As Boolean = False
    Dim dt As DispatcherTimer = New DispatcherTimer()

    Private Sub frmPacking_Reportes_EficienciasEnVivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        Dim s As Integer = 5 'Para Actualizar cada N segundos
        AddHandler dt.Tick, AddressOf dispatcherTimer_Tick
        dt.Interval = New TimeSpan(0, 0, s)
    End Sub

    Private Sub btnPlayStop_Click(sender As Object, e As EventArgs) Handles btnPlayStop.Click
        If btnPlayStop.Text = "Play" Then
            btnPlayStop.Text = "Stop"
            dt.Start()
        Else
            btnPlayStop.Text = "Play"
            dt.Stop()
        End If

        'dt.Start()

        'If flag Then
        '    flag = False
        'Else
        '    flag = True
        'End If
        'If Not bgwConsultor.IsBusy Then
        '    bgwConsultor.RunWorkerAsync(sender)
        '    btnPlayStop.Text = "Stop"
        '    flag = True
        'ElseIf bgwConsultor.IsBusy Then
        '    If bgwConsultor.WorkerSupportsCancellation Then
        '        bgwConsultor.CancelAsync()
        '        btnPlayStop.Text = "Play"
        '        flag = False
        '    End If
        'End If
        'clickEnBoton(sender, e)
        'dgvResultado.DataSource = Nothing


        'tablaResultado = Nothing
        'dgvResultado.Columns.Clear()
        'Dim dgv As Task(Of DataTable)
        'dgv = consultarAsync()
        ''dgvResultado.DataSource = Await dgv
        'tablaResultado = Await dgv
        'corregirTabla(tablaResultado)
        ''dgvResultado.DataSource = Nothing
        'dgvResultado.DataSource = tablaResultado
        'corregirCeldas(dgvResultado)
        'formatearDataGridView(dgvResultado)
        ''Threading.Thread.Sleep(5000)
    End Sub

    Public Async Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        tablaResultado = Nothing
        Dim dgv As Task(Of DataTable)
        'dgvResultado.Columns.Clear()
        dgv = consultarAsync()
        tablaResultado = Await dgv
        'corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        'corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)

        'btnExportar.Text = TimeOfDay.ToString("mm:ss")
    End Sub

    'Private Async Sub clickEnBoton(sender As Object, e As EventArgs) Handles btnPlayStop.Click
    '    CheckForIllegalCrossThreadCalls = False
    '    Dim dgv As Task(Of DataTable)
    '    dgv = consultarAsync()
    '    'dgvResultado.DataSource = Await dgv
    '    tablaResultado = Await dgv
    '    Threading.Thread.Sleep(1000)
    '    'tablaResultado = Nothing
    '    'corregirTabla(tablaResultado)
    '    dgvResultado.Columns.Clear()
    '    'dgvResultado.DataSource = Nothing
    '    dgvResultado.DataSource = tablaResultado
    '    'corregirCeldas(dgvResultado)
    '    formatearDataGridView(dgvResultado)
    'End Sub

    'Private Async Function consultarAsync() As Task(Of DataTable)
    '    Try
    '        Dim aux As New DataTable
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Desde", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
    '        p.Add("@Hasta", CType(pkrHasta.Value.ToString("dd/MM/yyyy"), DateTime))
    '        p.Add("@HorasMaquina", cbxMostrarHorasMaquina.Checked)
    '        arrayDeParametros = obtenerCadenaParametros(p)
    '        aux = Await Task.Run(Function() doItBaby("sp_FitoSanidad_ReporteAplicaciones", p, TipoQuery.DataTable))
    '        Return aux
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    'Private Sub btnPlayStop_Click(sender As Object, e As EventArgs) Handles btnPlayStop.Click

    '    If Not bgwConsultor.IsBusy Then
    '        bgwConsultor.RunWorkerAsync()
    '        btnPlayStop.Text = "Stop"
    '        flag = True
    '    ElseIf bgwConsultor.IsBusy Then
    '        If bgwConsultor.WorkerSupportsCancellation Then
    '            bgwConsultor.CancelAsync()
    '            btnPlayStop.Text = "Play"
    '            flag = False
    '        End If
    '    End If
    'End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", dtpFecha.Value)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Reportes_EficienciasEnVivo", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                'encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    'Private Async Sub iniciaConsulta()
    '    CheckForIllegalCrossThreadCalls = False
    '    dgvResultado.DataSource = Nothing
    '    tablaResultado = Nothing
    '    dgvResultado.Columns.Clear()
    '    Dim dgv As Task(Of DataTable)
    '    dgv = consultarAsync()
    '    'dgvResultado.DataSource = Await dgv
    '    tablaResultado = Await dgv
    '    corregirTabla(tablaResultado)
    '    dgvResultado.DataSource = tablaResultado
    '    'formatearDataGridView(dgvResultado)
    'End Sub

    'Private Sub bgwConsultor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwConsultor.DoWork
    '    While flag
    '        'iniciaConsulta()
    '        Threading.Thread.Sleep(5000)
    '        clickEnBoton(sender, e)
    '    End While
    'End Sub

    Private Sub frmPacking_Reportes_EficienciasEnVivo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btnPlayStop.Text = "Stop" Then
            btnPlayStop.Text = "Play"
            dt.Stop()
        End If
    End Sub

    Private Sub frmPacking_Reportes_EficienciasEnVivo_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If btnPlayStop.Text = "Stop" Then
            btnPlayStop.Text = "Play"
            dt.Stop()
        End If
    End Sub

    Private Sub frmPacking_Reportes_EficienciasEnVivo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If btnPlayStop.Text = "Play" Then
            btnPlayStop.Text = "Stop"
            dt.Start()
        End If
    End Sub
End Class