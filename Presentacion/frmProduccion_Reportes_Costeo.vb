Imports Logica.Utiles
Imports Logica.Funciones
Imports Datos.Conexion
Imports Entidades.Temporales

Public Class frmProduccion_Reportes_Costeo
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

    Private Sub frmProduccion_Reportes_Costeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo", txtPeriodo.Text)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_DG_Produccion_Reportes_Costeo", p, TipoQuery.DataTable))
            tablaResultado = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
    '    dgvResultado.DataSource = Nothing
    '    dgvResultado.Columns.Clear()
    '    manejarEtiquetaAsync(lblDin_Resultado, -1)
    '    barProgreso.MarqueeAnimationSpeed = 1
    '    barProgreso.Style = ProgressBarStyle.Marquee
    '    barProgreso.Value = 0
    '    consultarAsync()
    'End Sub


    'Private Async Sub consultarAsync()
    '    Dim p As New Dictionary(Of String, Object)
    '    Try
    '        p.Add("@Periodo", txtPeriodo.Text)
    '        tablaParaDgvResultado = Nothing
    '        tablaParaDgvResultado = preQueryBuscar(p)
    '        dgvResultado.DataSource = Await tablaParaDgvResultado
    '        corregirCeldas(dgvResultado)
    '        formatearDataGridView(dgvResultado)
    '        manejarEtiquetaAsync(lblDin_Resultado, dgvResultado.RowCount)
    '        barProgreso.Style = ProgressBarStyle.Continuous
    '        barProgreso.MarqueeAnimationSpeed = 0
    '        barProgreso.Value = barProgreso.Maximum
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Async Function preQueryBuscar(p As Dictionary(Of String, Object)) As Task(Of DataTable)
    '    Dim auxDataTable As New DataTable
    '    Try
    '        auxDataTable = Await Task.Run(Function() doItBaby(
    '                                          "sp_DG_Produccion_Reportes_Costeo",
    '                                          p,
    '                                          Datos.Conexion.TipoQuery.DataTable))
    '        Return auxDataTable
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


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

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, arrayDeParametros)
        ' End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConsultar_Click(sender, e)
        End If
    End Sub

End Class