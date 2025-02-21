Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Reportes_PlanillaAsistencia
    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet
    Dim dsDataParaCombo As DataSet

    Private Sub frmRrhh_Reportes_PlanillaAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvDuplicados.DataSource = Nothing
        dgvResumen.DataSource = Nothing
        dgvDescansosMedicos.DataSource = Nothing
        dgvLC.DataSource = Nothing
        dgvLS.DataSource = Nothing
        dgvLSPorHoras.DataSource = Nothing
        dgvVacaciones.DataSource = Nothing
        dgvSuspensiones.DataSource = Nothing

        dsResultado = Nothing

        dgvDuplicados.Columns.Clear()
        dgvResumen.Columns.Clear()
        dgvDescansosMedicos.Columns.Clear()
        dgvLC.Columns.Clear()
        dgvLS.Columns.Clear()
        dgvLSPorHoras.Columns.Clear()
        dgvVacaciones.Columns.Clear()
        dgvSuspensiones.Columns.Clear()

        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dsResultado = Await dgv
        corregirTabla(dsResultado.Tables(0))
        corregirTabla(dsResultado.Tables(1))
        corregirTabla(dsResultado.Tables(2))
        corregirTabla(dsResultado.Tables(3))
        corregirTabla(dsResultado.Tables(4))
        corregirTabla(dsResultado.Tables(5))
        corregirTabla(dsResultado.Tables(6))
        corregirTabla(dsResultado.Tables(7))

        dgvDuplicados.DataSource = dsResultado.Tables(0)
        dgvResumen.DataSource = dsResultado.Tables(1)
        dgvDescansosMedicos.DataSource = dsResultado.Tables(2)
        dgvLC.DataSource = dsResultado.Tables(3)
        dgvLS.DataSource = dsResultado.Tables(4)
        dgvLSPorHoras.DataSource = dsResultado.Tables(5)
        dgvVacaciones.DataSource = dsResultado.Tables(6)
        dgvSuspensiones.DataSource = dsResultado.Tables(7)

        apagarControlesDeEspera(barProgreso, lblResultado, dgvResumen.RowCount)
        corregirCeldas(dgvDuplicados)
        corregirCeldas(dgvResumen)
        corregirCeldas(dgvDescansosMedicos)
        corregirCeldas(dgvLC)
        corregirCeldas(dgvLS)
        corregirCeldas(dgvLSPorHoras)
        corregirCeldas(dgvVacaciones)
        corregirCeldas(dgvSuspensiones)

        formatearDataGridView(dgvDuplicados)
        formatearDataGridView(dgvResumen)
        formatearDataGridView(dgvDescansosMedicos)
        formatearDataGridView(dgvLC)
        formatearDataGridView(dgvLS)
        formatearDataGridView(dgvLSPorHoras)
        formatearDataGridView(dgvVacaciones)
        formatearDataGridView(dgvSuspensiones)

    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Planilla", cboPlanilla.SelectedValue)
            p.Add("@Desde", dtpDesde.Value)
            p.Add("@Hasta", dtpHasta.Value)
            p.Add("@HorasReales", cbxHorasReales.Checked)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_PlanillaAsistencia", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs)
        'If dgvResumen.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    exportarExcel(dgvResumen, Me.Text, arrayDeParametros, 6)
        '    dgvResumen.ClearSelection()
        'End If
        'Try
        '    If dgvDuplicados.RowCount < 1 Then
        '        MessageBox.Show("Error, no hay registros para exportar")
        '    Else
        '        Dim dDgvs As New Dictionary(Of String, DataGridView)
        '        dDgvs.Add("PlanillaSuspensiones", dgvSuspensiones)
        '        dDgvs.Add("PlanillaVacaciones", dgvVacaciones)
        '        dDgvs.Add("PlanillaLSPorHoras", dgvLSPorHoras)
        '        dDgvs.Add("PlanillaLS", dgvLS)
        '        dDgvs.Add("PlanillaLC", dgvLC)
        '        dDgvs.Add("PlanillaDescansosMedicos", dgvDescansosMedicos)
        '        dDgvs.Add("PlanillaResumen", dgvResumen)
        '        dDgvs.Add("RegistrosDuplicados", dgvDuplicados)
        '        'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '        excelling(dDgvs, Me.Text, arrayDeParametros)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        Try
            If dgvResumen.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("RegistrosDuplicados")
                l.Add("PlanillaResumen")
                l.Add("PlanillaDescansosMedicos")
                l.Add("PlanillaLC")
                l.Add("PlanillaLS")
                l.Add("PlanillaLSPorHoras")
                l.Add("PlanillaVacaciones")
                l.Add("PlanillaSuspensiones")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
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

    Private Sub obtenerDataParaCombos()
        Dim p As New Dictionary(Of String, Object)
        p.Add("@SeleccionMultiple", 0)
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", p, TipoQuery.DataTable))
    End Sub

    Private Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportar.Click

    End Sub
End Class