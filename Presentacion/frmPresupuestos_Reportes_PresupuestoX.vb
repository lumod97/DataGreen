Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPresupuestos_Reportes_PresupuestoX
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataSet
    Dim tablaDetalle As DataSet
    Dim dsDataParaCombo As DataSet
    Dim idArea, idSubArea, idGrupo, idSubGrupo, idProducto As String
    Dim bsRes As New BindingSource()

    Private Sub frmPresupuestos_Reportes_PresupuestoX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboAnio, dsDataParaCombo.Tables(0), "", False)
        cargarCombo(cboMoneda, dsDataParaCombo.Tables(1), "", False)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerAniosPresupuestos", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Gen_ObtenerMonedas", Nothing, TipoQuery.DataTable))
    End Sub

    'Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
    '    If dsDataParaCombo.Tables.Count = 3 Then
    '        dsDataParaCombo.Tables.RemoveAt(2)
    '    End If
    '    Dim p As New Dictionary(Of String, Object)
    '    p.Add("@Anio", cboAnio.SelectedValue)
    '    dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPresupuestos", p, TipoQuery.DataTable))
    '    cargarCombo(cboPresupuesto, dsDataParaCombo.Tables(2), False)
    'End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        txtFiltro.Text = ""
        dgvResultado.DataSource = Nothing
        dgvAreaSubArea.DataSource = Nothing
        dgvGrupoSubGrupo.DataSource = Nothing
        dgvProducto.DataSource = Nothing

        tablaResultado = Nothing
        tablaDetalle = Nothing

        dgvResultado.Columns.Clear()
        dgvAreaSubArea.Columns.Clear()
        dgvGrupoSubGrupo.Columns.Clear()
        dgvProducto.Columns.Clear()

        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResultado = Await dgv
        corregirTabla(tablaResultado.Tables(0))

        Dim dvRes As New DataView(tablaResultado.Tables(0))
        bsRes.DataSource = dvRes
        dgvResultado.DataSource = bsRes

        'dgvResultado.DataSource = tablaResultado.Tables(0)

        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)

        formatearDataGridView(dgvResultado)

    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet) 'Task(Of DataTable)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Anio", cboAnio.SelectedValue)
            p.Add("@IdMoneda", cboMoneda.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_PresupuestoX", p, TipoQuery.DataSet))
            Return aux
            'Dim aux As New DataTable
            'Dim p As New Dictionary(Of String, Object)
            'p.Add("@CodigoPresupuesto", cboPresupuesto.SelectedValue)
            'p.Add("@IdMoneda", cboMoneda.SelectedValue)
            'arrayDeParametros = obtenerCadenaParametros(p)
            'aux = doItBaby("sp_Dg_Presupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo", p, TipoQuery.DataTable)
            'Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub dgvResultado_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvResultado.CellMouseClick
        Try
            idArea = dgvResultado.Rows(e.RowIndex).Cells("T_IdArea").Value.ToString
            idSubArea = dgvResultado.Rows(e.RowIndex).Cells("T_IdSubArea").Value.ToString
            idGrupo = dgvResultado.Rows(e.RowIndex).Cells("T_IdGrupo").Value.ToString
            idSubGrupo = dgvResultado.Rows(e.RowIndex).Cells("T_IdSubGrupo").Value.ToString
            idProducto = dgvResultado.Rows(e.RowIndex).Cells("T_IdProducto").Value.ToString

            dgvAreaSubArea.DataSource = Nothing
            dgvGrupoSubGrupo.DataSource = Nothing
            dgvProducto.DataSource = Nothing

            tablaDetalle = Nothing

            dgvAreaSubArea.Columns.Clear()
            dgvGrupoSubGrupo.Columns.Clear()
            dgvProducto.Columns.Clear()

            Dim dgv As Task(Of DataSet)
            encenderControlesDeEspera(barProgreso, lblResultado)
            dgv = consultarDetalleAsync()
            tablaDetalle = Await dgv

            corregirTabla(tablaDetalle.Tables(0))
            corregirTabla(tablaDetalle.Tables(1))
            corregirTabla(tablaDetalle.Tables(2))

            dgvAreaSubArea.DataSource = tablaDetalle.Tables(0)
            dgvGrupoSubGrupo.DataSource = tablaDetalle.Tables(1)
            dgvProducto.DataSource = tablaDetalle.Tables(2)

            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)

            corregirCeldas(dgvAreaSubArea)
            corregirCeldas(dgvGrupoSubGrupo)
            corregirCeldas(dgvProducto)

            formatearDataGridView(dgvAreaSubArea)
            formatearDataGridView(dgvGrupoSubGrupo)
            formatearDataGridView(dgvProducto)

            dgvAreaSubArea.Columns("T_Anio").Frozen = True
            dgvGrupoSubGrupo.Columns("T_Anio").Frozen = True
            dgvProducto.Columns("T_Anio").Frozen = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function consultarDetalleAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            'p.Add("@Anio", cboAnio.SelectedValue)
            p.Add("@IdMoneda", cboMoneda.SelectedValue)
            p.Add("@IdArea ", idArea)
            p.Add("@IdSubArea", idSubArea)
            p.Add("@IdGrupo ", idGrupo)
            p.Add("@IdSubGrupo", idSubGrupo)
            p.Add("@IdProducto", idProducto)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_PresupuestoX_Detalles", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

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

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsRes.Filter = String.Format("T_Area like '%{0}%' Or " +
                                                "T_SubArea like '%{1}%' Or " +
                                                "T_Grupo like '%{2}%' Or " +
                                                "T_SubGrupo like '%{3}%' Or " +
                                                "T_Producto like '%{4}%'",
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text)
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    exportarExcel(dgvResultado, Me.Text, arrayDeParametros, 6)
        '    dgvResultado.ClearSelection()
        'End If


        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    If dgvProducto.Rows.Count > 0 Then
        '        dDgvs.Add("Producto", dgvProducto)
        '    End If
        '    If dgvGrupoSubGrupo.Rows.Count > 0 Then
        '        dDgvs.Add("Grupo Sub Grupo", dgvGrupoSubGrupo)
        '    End If
        '    If dgvAreaSubArea.Rows.Count > 0 Then
        '        dDgvs.Add("Area Sub Area", dgvAreaSubArea)
        '    End If
        '    dDgvs.Add("General", dgvResultado)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    'exportar(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If

        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("General")
                l.Add("Area Sub Area")
                l.Add("Grupo Sub Grupo")
                l.Add("Producto")
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class