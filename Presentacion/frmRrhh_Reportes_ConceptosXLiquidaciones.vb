﻿Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Reportes_ConceptosXLiquidaciones
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet

    '[sp_Dg_ObtenerPeriodos]
    '[sp_ObtenerPlanillas]
    '[sp_Dg_ObtenerSemanas]

    Private Sub frmRrhh_Reportes_ConceptosXLiquidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        removerFila(dsDataParaCombo.Tables(0), "TODAS")
        removerFila(dsDataParaCombo.Tables(1), "TODOS")
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboPeriodo, dsDataParaCombo.Tables(1), "", False)
        aplicarTema(Me)
        lblSemanas.Text = ""
        tlpPrincipal.Visible = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Planilla", cboPlanilla.SelectedValue)
            p.Add("@Periodo", cboPeriodo.SelectedValue)
            p.Add("@Semanas", lblSemanas.Text)
           
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_ConceptosXLiquidaciones", p, TipoQuery.DataTable))
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
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
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

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cboPeriodo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPeriodo.SelectionChangeCommitted
        For i As Integer = 2 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodo.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable))
        cargarCombo(cboSemanas, dsDataParaCombo.Tables(2), "", False)
    End Sub

    Private Sub cboSemanas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSemanas.SelectionChangeCommitted
        If cboSemanas.SelectedValue <> "**" Then
            encadenar(lblSemanas.Text, cboSemanas.SelectedValue, ",")
        Else
            lblSemanas.Text = ""
            For Each item In cboSemanas.Items
                If item.item(0).ToString <> "**" Then encadenar(lblSemanas.Text, item.item(0).ToString, ",")
            Next
        End If
    End Sub
End Class