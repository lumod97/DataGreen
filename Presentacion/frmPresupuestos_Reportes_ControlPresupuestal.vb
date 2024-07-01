Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPresupuestos_Reportes_ControlPresupuestal
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    'PARA EXPORTAR A INFORME
    Dim tipoReporte As String = ""
    Dim p As New Dictionary(Of String, Object)

    Private Sub frmPresupuestos_Reportes_ControlPresupuestal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombos()
        cboModulo.Enabled = False
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_Presupuestos_Reportes_Control_PorModulo_ObtenerTiposReportes", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerCultivos_G", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerEtapasCampania", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerSubareas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerTiposGasto", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables(1).Rows.RemoveAt(0) 'PARA ELIMINAR LA OPCION "TODOS" DEL COMBO DE AÑO CAMPAÑA
    End Sub

    Private Sub cargarCombos()
        cargarCombo(cboTipoReporte, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboCampana, dsDataParaCombo.Tables(1), "", False)
        cargarCombo(cboCultivo, dsDataParaCombo.Tables(2), "", True)
        cargarCombo(cboEtapa, dsDataParaCombo.Tables(3), "", True)
        cargarCombo(cboSubArea, dsDataParaCombo.Tables(4), "", True)
        cargarCombo(cboRubro, dsDataParaCombo.Tables(5), "", True)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        p.Clear()
        tipoReporte = cboTipoReporte.SelectedValue
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
        ResaltarFilas("TOTAL >>")
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            ' @Periodo_C CHAR(4), @CodCultivo CHAR(4), @CodEtapa CHAR(3), @CodTipoGasto CHAR(4), @CodSubarea CHAR(3), @Fecha DATETIME, @CodModulo CHAR(6)
            Dim aux As New DataTable
            'Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo_C", IIf(cboCampana.SelectedValue.ToString.Contains("*"), "", cboCampana.SelectedValue))
            p.Add("@CodCultivo", IIf(cboCultivo.SelectedValue.ToString.Contains("*"), "", cboCultivo.SelectedValue))
            p.Add("@CodEtapa", IIf(cboEtapa.SelectedValue.ToString.Contains("*"), "", cboEtapa.SelectedValue))
            p.Add("@CodTipoGasto", IIf(cboRubro.SelectedValue.ToString.Contains("*"), "", cboRubro.SelectedValue))
            p.Add("@CodSubarea", IIf(cboSubArea.SelectedValue.ToString.Contains("*"), "", cboSubArea.SelectedValue))
            p.Add("@Fecha", dtpFecha.Value)
            If cboTipoReporte.SelectedValue = "2" Then
                p.Add("@CodModulo", cboModulo.SelectedValue)
            End If
            arrayDeParametros = obtenerCadenaParametros(p)
            If cboTipoReporte.SelectedValue = "1" Then
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_Control_PorFundo", p, TipoQuery.DataTable))
            ElseIf cboTipoReporte.SelectedValue = "2" Then
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_Control_PorLote", p, TipoQuery.DataTable))
            ElseIf cboTipoReporte.SelectedValue = "3" Then
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_Control_PorModulo", p, TipoQuery.DataTable))
            End If

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

    'Private Sub cboModulo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboModulo.SelectionChangeCommitted
    '    If cboCampana.SelectedIndex > -1 And cboCultivo.SelectedIndex > -1 Then
    '        If dsDataParaCombo.Tables.Count = 6 Then
    '            dsDataParaCombo.Tables.RemoveAt(6)
    '        End If
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Periodo_C", cboCampana.SelectedValue)
    '        p.Add("@CodCultivo", cboCultivo.SelectedValue)
    '        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerModulos_C", p, TipoQuery.DataTable))
    '        cargarCombo(cboModulo, dsDataParaCombo.Tables(6), "", True)
    '    End If
    'End Sub

    

    Private Sub cboCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCampana.SelectionChangeCommitted
        If cboCampana.SelectedIndex > -1 And cboCultivo.SelectedIndex > -1 Then
            If dsDataParaCombo.Tables.Count > 6 Then
                dsDataParaCombo.Tables.RemoveAt(6)
            End If
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo_C", cboCampana.SelectedValue)
            p.Add("@CodCultivo", cboCultivo.SelectedValue)
            dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerModulos_C", p, TipoQuery.DataTable))
            cargarCombo(cboModulo, dsDataParaCombo.Tables(6), "", True)
        End If
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        If cboCampana.SelectedIndex > -1 And cboCultivo.SelectedIndex > -1 Then
            If dsDataParaCombo.Tables.Count > 6 Then
                dsDataParaCombo.Tables.RemoveAt(6)
            End If
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo_C", cboCampana.SelectedValue)
            p.Add("@CodCultivo", cboCultivo.SelectedValue)
            dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerModulos_C", p, TipoQuery.DataTable))
            cargarCombo(cboModulo, dsDataParaCombo.Tables(6), "", True)
        End If
    End Sub

    Private Sub cboTipoReporte_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipoReporte.SelectionChangeCommitted
        If cboTipoReporte.SelectedValue = 2 Then
            cboModulo.Enabled = True
        Else
            cboModulo.Enabled = False
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If tipoReporte = "1" Then
            abrirReporte()
        End If
    End Sub

    Private Sub abrirReporte()
        Dim VenActual As New frm_Dg_VisualizadorGenericoDeReportes("rpte_Dg_Presupuestos_ControlPresupuestal_PorLoteYSector", p)
        VenActual.MdiParent = Me.MdiParent
        VenActual.Show()
    End Sub

    Private Sub ResaltarFilas(textoIdentificador As String)
        Dim i As Integer = 0
        For Each f As DataGridViewRow In dgvResultado.Rows
            If f.Cells(0).Value.ToString = textoIdentificador Then
                dgvResultado.Rows(i).DefaultCellStyle.BackColor = grisWindows 'dgvCabeceraPallets.DefaultCellStyle.BackColor
                dgvResultado.Rows(i).DefaultCellStyle.ForeColor = blancoPuro_ 'dgvCabeceraPallets.DefaultCellStyle.BackColor
                dgvResultado.CurrentCell = Nothing
            End If
            i += 1
        Next
    End Sub

End Class