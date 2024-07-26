'CODIGO QUE SATISFACE ORDEN Y EFICIENCIA EN CONSULTAS ASINCRONAS, REPLICAR ESTRUCTURA EN LOS DEMAS FORMS (JORGE MERA 04092020)

Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Public Class frmFitosanidad_RepAplicaciones
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    'PENDIENTE CREAR UNA TABLA DE RESULTADO PARA TODAS LAS DEMAS CONSULTAS, ESTA TABLA PERMITE USAR LA FUNCION
    '"CORREGITABLA", LA CUAL ELIMINA LOS SALTOS DE LINEA INNECESARIOS EN LOS REGISTROS QUE HACEN LOS USUARIOS Y QUE ALTERAN
    'LAS FILAS EN LA EXPORTACION A EXCEL

    Private Sub frmFitosanidad_RepAplicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboEtapa, dsDataParaCombo.Tables(0), "", False)
        'cargarCombo(cboDivision, dsDataParaCombo.Tables(1), "", False)
        'cargarCombo(cboParron, dsDataParaCombo, "", True)
        aplicarTema(Me)
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
            p.Add("@Desde", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@Hasta", CType(pkrHasta.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@HorasMaquina", cbxMostrarHorasMaquina.Checked)
            'p.Add("@IdEtapa", IIf(cboEtapa.SelectedIndex >= 0, cboEtapa.SelectedValue, ""))
            'p.Add("@IdModulo", IIf(cboDivision.SelectedIndex >= 0, cboDivision.SelectedValue, ""))
            'p.Add("@Parron", cboConsumidor.SelectedValue)
            p.Add("@IdTipoCampana", cboEtapa.SelectedValue)
            p.Add("@AnioCampana", cboCampana.SelectedValue)
            p.Add("@IdCultivo", cboCultivo.SelectedValue)
            p.Add("@Division", cboDivision.SelectedValue)
            p.Add("@Consumidor", cboConsumidor.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_FitoSanidad_Reportes_Aplicaciones", p, TipoQuery.DataTable))
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
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros, 6)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros, 6)
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

    'Private Sub cbxMostrarHorasMaquina_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMostrarHorasMaquina.CheckedChanged
    '    If cbxMostrarHorasMaquina.Checked Then
    '        cboConsumidor.Enabled = False
    '    Else
    '        cboConsumidor.Enabled = True
    '    End If
    'End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerEtapasCampania", Nothing, TipoQuery.DataTable))
        'dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerModulosCampo", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cboEtapa_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboEtapa.SelectionChangeCommitted
        For i As Integer = 1 To dsDataParaCombo.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombo.Tables.RemoveAt(1)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTipoCampana", cboEtapa.SelectedValue)  'IIf(cboEtapa.SelectedIndex >= 0, cboEtapa.SelectedValue, ""))
        'p.Add("@IdModulo", IIf(cboDivision.SelectedIndex >= 0, cboDivision.SelectedValue, ""))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanasXTipoCampana", p, TipoQuery.DataTable))
        cargarCombo(cboCampana, dsDataParaCombo.Tables(1), "", False)
    End Sub

    Private Sub cboCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCampana.SelectionChangeCommitted
        For i As Integer = 2 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTipoCampana", cboEtapa.SelectedValue)  'IIf(cboEtapa.SelectedIndex >= 0, cboEtapa.SelectedValue, ""))
        p.Add("@AnioCampana", cboCampana.SelectedValue) 'IIf(cboDivision.SelectedIndex >= 0, cboDivision.SelectedValue, ""))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCultivosXTipoCampanaYAnioCampana", p, TipoQuery.DataTable))
        cargarCombo(cboCultivo, dsDataParaCombo.Tables(2), "", True)
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        For i As Integer = 3 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(3)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTipoCampana", cboEtapa.SelectedValue)
        p.Add("@AnioCampana", cboCampana.SelectedValue)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerDivisionesXTipoCampanaYAnioCampanaYCultivo", p, TipoQuery.DataTable))
        cargarCombo(cboDivision, dsDataParaCombo.Tables(3), "", True)
    End Sub

    Private Sub cboDivision_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDivision.SelectionChangeCommitted
        For i As Integer = 4 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(4)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdTipoCampana", cboEtapa.SelectedValue)
        p.Add("@AnioCampana", cboCampana.SelectedValue)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@Division", cboDivision.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerConsumidoresXTipoCampanaYAnioCampanaYCultivoYDivision", p, TipoQuery.DataTable))
        cargarCombo(cboConsumidor, dsDataParaCombo.Tables(4), "", True)
    End Sub


End Class
