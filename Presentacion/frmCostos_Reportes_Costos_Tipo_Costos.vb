Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class frmCostos_Reportes_Costos_Tipo_Costos

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultados As DataTable
    Dim dsDataParaCombos As DataSet

    Private Sub frmCostos_Reportes_Costos_Tipo_Costos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = False
        ObtenerDataParaComboConsumidor()
        cargarCombo(cboCultivo, dsDataParaCombos.Tables(0))
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub ObtenerDataParaComboConsumidor()


        Try
            dsDataParaCombos = New DataSet
            dsDataParaCombos = doItBaby("sp_Dg_Costos_Reportes_JerarquiaConsumidores_ObtenerDataParaCombos", Nothing, TipoQuery.DataSet)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Dim aux As DataTable
        'Dim p As New Dictionary(Of String, Object)
        'p.Add("@IdCultivo", cboCultivo.SelectedValue)
        'p.Add("@IdVariedad", cboVariedad.SelectedValue)
        'p.Add("@IdModulo", cboModulo.SelectedValue)
        'aux = doItBaby("sp_Gen_ObtenerEmpaquesXConsumidorPacking", p, TipoQuery.DataTable)
        'cargarCombo(cboEmpaque, aux.Copy)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultados = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable) = Nothing
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        tablaResultados = Await dgv
        corregirTabla(tablaResultados)
        dgvResultado.DataSource = tablaResultados
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function ConsultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@CodEmpresa", "001")
            p.Add("@C_DESDE", CType(dtpDesde.Value.ToString("dd/MM/yyyy"), String))
            p.Add("@C_HASTA", CType(dtpHasta.Value.ToString("dd/MM/yyyy"), String))
            p.Add("@idcultivo", cboCultivo.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("OBJREPORTE_COSTOSXTIPOCOSTO", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultados, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
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
End Class