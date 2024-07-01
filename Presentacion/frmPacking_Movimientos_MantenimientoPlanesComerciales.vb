Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion

Public Class frmPacking_Movimientos_MantenimientoPlanesComerciales
    Dim dtResultado As DataTable
    'Dim registroActual As New Dictionary(Of String, Object)
    Dim registroActual As Registro
    Dim arrayDeParametros As String = String.Empty
    Dim consultando As Boolean
    Dim columnas As String() = {"Codigo", "IdCultivo", "Cultivo", "Numero", "FechaDespacho", "AnioCampana", "IdCampana", "Campana", "Incoterm", "IdCliente", "Cliente", "IdConsignatario", "Consignatario", "SemanaProceso", "SemanaZarpe", "IdPaisDestino", "PaisDestino", "Observacion", "Estado"}
    'Dim desde As Date = Nothing, hasta As Date = Nothing

    Private Sub frmPacking_Movimientos_MantenimientoPlanesComerciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        registroActual = New Registro(columnas)
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        iniciarControles()
        aplicarTema(Me)
        actualizarData()
        'obtenerData()
        'usarData()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub iniciarControles()
        'consultando = True
        'dtpDesde.ValueChanged -= validarFechas(dtpDesde, New EventArgs)
        'dateTimePicker1.Value = dt;

        dtpDesde.Value = DateAdd(DateInterval.Day, -30, Now)
        dtpHasta.Value = Now
        'desde = dtpDesde.Value
        'hasta = dtpHasta.Value
        'dtpDesde.Value = DateAdd(DateInterval.Day, -30, Now)
        'dtpHasta.Value = Now

        'dtpDesde.ValueChanged += dateTimePicker1_ValueChanged;
        'consultando = False
    End Sub

    'Private Sub obtenerData()
    '    Try
    '        dtResultado = Nothing
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Desde", dtpDesde.Value.ToString("yyyy-MM-dd"))
    '        p.Add("@Hasta", dtpHasta.Value.ToString("yyyy-MM-dd"))
    '        dtResultado = doItBaby("sp_Packing_Movimientos_MantenimientoPlanesComerciales", p, TipoQuery.DataTable)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub usarData()
    '    corregirTabla(dtResultado)
    '    dgvResultado.DataSource = dtResultado
    '    'apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
    '    corregirCeldas(dgvResultado)
    '    formatearDataGridView(dgvResultado)
    'End Sub

    Private Async Sub actualizarData() 'Handles btnConsultar.Click
        Try
            consultando = True
            dgvResultado.DataSource = Nothing
            dtResultado = Nothing
            dgvResultado.Columns.Clear()
            Dim dgv As Task(Of DataTable)
            encenderControlesDeEspera(barProgreso, lblResultado)
            dgv = consultarAsync()
            dtResultado = Await dgv
            corregirTabla(dtResultado)
            dgvResultado.DataSource = dtResultado
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
            corregirCeldas(dgvResultado)
            formatearDataGridView(dgvResultado)
            dgvResultado.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            consultando = False
        End Try
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", dtpDesde.Value.ToString("yyyy-MM-dd"))
            p.Add("@Hasta", dtpHasta.Value.ToString("yyyy-MM-dd"))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_MantenimientoPlanesComerciales", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
    '    If dgvResultado.RowCount < 1 Then
    '        MessageBox.Show("Error, no hay registros para exportar")
    '    Else
    '        exportarExcel(dgvResultado, Me.Text, arrayDeParametros, 6)
    '        dgvResultado.ClearSelection()
    '    End If
    'End Sub

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


    'Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
    '    If dtpDesde.Value > dtpHasta.Value Then
    '        MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.")
    '        dtpDesde.Value = dtpHasta.Value
    '    Else
    '        actualizarData()
    '    End If
    'End Sub

    'Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
    '    If dtpHasta.Value < dtpDesde.Value Then
    '        MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.")
    '        dtpDesde.Value = dtpHasta.Value
    '    Else
    '        actualizarData()
    '    End If
    'End Sub

    Public Sub validarFechas(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
        If sender.Equals(dtpDesde) AndAlso Date.Parse(dtpDesde.Value.ToShortDateString) > Date.Parse(dtpHasta.Value.ToShortDateString) Then
            MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.")
            dtpDesde.Value = dtpHasta.Value
        ElseIf sender.Equals(dtpHasta) AndAlso Date.Parse(dtpHasta.Value.ToShortDateString) < Date.Parse(dtpDesde.Value.ToShortDateString) Then
            MessageBox.Show("La fecha final no puede ser menor a la fecha de inicio.")
            dtpHasta.Value = dtpDesde.Value
        ElseIf Not consultando Then
            actualizarData()
        End If
    End Sub

    Private Sub dgvResultado_Click(sender As Object, e As EventArgs) Handles dgvResultado.Click
        If dgvResultado.Rows.Count > 0 Then
            Dim i As Integer = dgvResultado.CurrentRow.Index
            If i >= 0 Then
                'registroActual = convertirFilaDiccionario(dtResultado.Rows(i))
                'registroActual = convertirFilaRegsitro(dtResultado.Rows(i))
                registroActual = convertirFilaRegsitro(dgvResultado.Rows(i))
                actualizarCabecera()
                formatearDataGridView(dgvResultado)
            End If
        End If
    End Sub

    Private Function convertirFilaRegsitro(fila As DataGridViewRow) As Registro
        Dim aux As New Registro(columnas) 'New Dictionary(Of String, Object)
        aux.addix("Codigo", fila.Cells("T_Codigo").Value)
        aux.addix("IdCultivo", fila.Cells("T_IdCultivo").Value)
        aux.addix("Cultivo", fila.Cells("T_Cultivo").Value)
        aux.addix("Numero", fila.Cells("T_Numero").Value)
        aux.addix("FechaDespacho", fila.Cells("F_FechaDespacho").Value)
        aux.addix("AnioCampana", fila.Cells("T_AnioCampana").Value)
        aux.addix("IdCampana", fila.Cells("T_IdCampana").Value)
        aux.addix("Campana", fila.Cells("T_Campana").Value)
        aux.addix("Incoterm", fila.Cells("T_Incoterm").Value)
        aux.addix("IdCliente", fila.Cells("T_IdCliente").Value)
        aux.addix("Cliente", fila.Cells("T_Cliente").Value)
        aux.addix("IdConsignatario", fila.Cells("T_IdConsignatario").Value)
        aux.addix("Consignatario", fila.Cells("T_Consignatario").Value)
        aux.addix("SemanaProceso", fila.Cells("T_SemanaProceso").Value)
        aux.addix("SemanaZarpe", fila.Cells("T_SemanaZarpe").Value)
        aux.addix("IdPaisDestino", fila.Cells("T_IdPaisDestino").Value)
        aux.addix("PaisDestino", fila.Cells("T_PaisDestino").Value)
        aux.addix("Observacion", fila.Cells("T_Observacion").Value)
        aux.addix("Estado", fila.Cells("T_Estado").Value)
        Return aux
    End Function

    Private Function convertirFilaRegsitro(fila As DataRow) As Registro
        Dim aux As New Registro(columnas) 'New Dictionary(Of String, Object)
        aux.addix("Codigo", fila.Item("T_Codigo"))
        aux.addix("IdCultivo", fila.Item("T_IdCultivo"))
        aux.addix("Cultivo", fila.Item("T_Cultivo"))
        aux.addix("Numero", fila.Item("T_Numero"))
        aux.addix("FechaDespacho", fila.Item("F_FechaDespacho"))
        aux.addix("AnioCampana", fila.Item("T_AnioCampana"))
        aux.addix("IdCampana", fila.Item("T_IdCampana"))
        aux.addix("Campana", fila.Item("T_Campana"))
        aux.addix("Incoterm", fila.Item("T_Incoterm"))
        aux.addix("IdCliente", fila.Item("T_IdCliente"))
        aux.addix("Cliente", fila.Item("T_Cliente"))
        aux.addix("IdConsignatario", fila.Item("T_IdConsignatario"))
        aux.addix("Consignatario", fila.Item("T_Consignatario"))
        aux.addix("SemanaProceso", fila.Item("T_SemanaProceso"))
        aux.addix("SemanaZarpe", fila.Item("T_SemanaZarpe"))
        aux.addix("IdPaisDestino", fila.Item("T_IdPaisDestino"))
        aux.addix("PaisDestino", fila.Item("T_PaisDestino"))
        aux.addix("Observacion", fila.Item("T_Observacion"))
        aux.addix("Estado", fila.Item("T_Estado"))
        Return aux
    End Function

    'Private Function convertirFilaDiccionario(fila As DataRow) As Dictionary(Of String, Object)
    '    Dim aux As New Dictionary(Of String, Object)
    '    aux.Add("Codigo", fila.Item("T_Codigo"))
    '    aux.Add("IdCultivo", fila.Item("T_IdCultivo"))
    '    aux.Add("Cultivo", fila.Item("T_Cultivo"))
    '    aux.Add("Numero", fila.Item("T_Numero"))
    '    aux.Add("FechaDespacho", fila.Item("F_FechaDespacho"))
    '    aux.Add("AnioCampana", fila.Item("T_AnioCampana"))
    '    aux.Add("IdCampana", fila.Item("T_IdCampana"))
    '    aux.Add("Campana", fila.Item("T_Campana"))
    '    aux.Add("Incoterm", fila.Item("T_Incoterm"))
    '    aux.Add("IdCliente", fila.Item("T_IdCliente"))
    '    aux.Add("Cliente", fila.Item("T_Cliente"))
    '    aux.Add("IdConsignatario", fila.Item("T_IdConsignatario"))
    '    aux.Add("Consignatario", fila.Item("T_Consignatario"))
    '    aux.Add("SemanaProceso", fila.Item("T_SemanaProceso"))
    '    aux.Add("SemanaZarpe", fila.Item("T_SemanaZarpe"))
    '    aux.Add("IdPaisDestino", fila.Item("T_IdPaisDestino"))
    '    aux.Add("PaisDestino", fila.Item("T_PaisDestino"))
    '    aux.Add("Observacion", fila.Item("T_Observacion"))
    '    aux.Add("Estado", fila.Item("T_Estado"))
    '    Return aux
    'End Function

    Private Function convertirFilaRegistro(fila As DataRow) As Registro 'Dictionary(Of String, Object)
        Dim aux As New Registro(columnas) 'Dictionary(Of String, Object)
        aux.addix("Codigo", fila.Item("T_Codigo"))
        aux.addix("IdCultivo", fila.Item("T_IdCultivo"))
        aux.addix("Cultivo", fila.Item("T_Cultivo"))
        aux.addix("Numero", fila.Item("T_Numero"))
        aux.addix("FechaDespacho", fila.Item("F_FechaDespacho"))
        aux.addix("AnioCampana", fila.Item("T_AnioCampana"))
        aux.addix("IdCampana", fila.Item("T_IdCampana"))
        aux.addix("Campana", fila.Item("T_Campana"))
        aux.addix("Incoterm", fila.Item("T_Incoterm"))
        aux.addix("IdCliente", fila.Item("T_IdCliente"))
        aux.addix("Cliente", fila.Item("T_Cliente"))
        aux.addix("IdConsignatario", fila.Item("T_IdConsignatario"))
        aux.addix("Consignatario", fila.Item("T_Consignatario"))
        aux.addix("SemanaProceso", fila.Item("T_SemanaProceso"))
        aux.addix("SemanaZarpe", fila.Item("T_SemanaZarpe"))
        aux.addix("IdPaisDestino", fila.Item("T_IdPaisDestino"))
        aux.addix("PaisDestino", fila.Item("T_PaisDestino"))
        aux.addix("Observacion", fila.Item("T_Observacion"))
        aux.addix("Estado", fila.Item("T_Estado"))
        Return aux
    End Function

    Private Sub actualizarCabecera()
        txtlblCodigo.Text = registroActual.Item("Codigo")
        txtlblNro.Text = registroActual.Item("Numero")
        txtlblFechaDespacho.Text = registroActual.Item("FechaDespacho")
        txtlblCampana.Text = registroActual.Item("AnioCampana")
        txtlblIdCampana.Text = registroActual.Item("IdCampana")
        txtlblNombreCampana.Text = registroActual.Item("Campana")
        txtlblIncoterm.Text = registroActual.Item("Incoterm")
        txtlblIdCliente.Text = registroActual.Item("IdCliente")
        txtlblCliente.Text = registroActual.Item("Cliente")
        txtlblIdConsignatario.Text = registroActual.Item("IdConsignatario")
        txtlblConsignatario.Text = registroActual.Item("Consignatario")
        txtlblSemanaProduccion.Text = registroActual.Item("SemanaProceso")
        txtlblSemanaZarpe.Text = registroActual.Item("SemanaZarpe")
        'txtlblPuertoDestino.Text = registroActual.Item("IdPuertoDestino")
        txtlblPaisDestino.Text = registroActual.Item("IdPaisDestino")
        txtlblObservacion.Text = registroActual.Item("Observacion")
        txtlblEstatus.Text = registroActual.Item("Estado")
    End Sub

    
    Private Sub dgvResultado_DoubleClick(sender As Object, e As EventArgs) Handles dgvResultado.DoubleClick
        Dim i As Integer = dgvResultado.CurrentRow.Index
        If i >= 0 Then
            'registroActual = convertirFilaDiccionario(dtResultado.Rows(i))
            registroActual = convertirFilaRegsitro(dtResultado.Rows(i))
            actualizarCabecera()
            formatearDataGridView(dgvResultado)
            abrirDetallePedido(registroActual)
        End If
    End Sub

    Private Sub abrirDetallePedido(pedido As Registro)
        Dim v As New frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle(pedido)
        v.MdiParent = Me.MdiParent
        v.Show()
    End Sub

    'Private Sub abrirDetallePedido(pedido As Dictionary(Of String, Object))
    '    Dim v As New frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle(pedido)
    '    v.MdiParent = Me.MdiParent
    '    v.Show()
    'End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'If dgvResultado.Rows.Count > 0 And registroActual.Count > 0 Then
        'If dgvResultado.SelectedRows.Count = 1 Then
        '    registroActual = convertirFilaRegsitro(dgvResultado.Rows(0))
        'Else
        registroActual = New Registro(columnas)
        'End If
        'registroActual.Item("Codigo") = ""
        Dim v As New frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle(registroActual)
        v.MdiParent = Me.MdiParent
        v.Show()
    End Sub

    Private Sub frmPacking_Movimientos_MantenimientoPlanesComerciales_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If dgvResultado.RowCount > 0 Then
            actualizarData()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim r As DialogResult = MessageBox.Show("Seguro que desea eliminar el registro selecciondo?", "Eliminar Registro", MessageBoxButtons.YesNo)
            If r = Windows.Forms.DialogResult.Yes Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@CodPlanComercial", registroActual.Item("Codigo"))
                Dim dtRes As DataTable = doItBaby("sp_Dg_Packing_Movimientos_MantenimientoPlanesComerciales_Eliminar", p, TipoQuery.DataTable)
                If dtRes.Rows(0).Item(0).ToString.Equals("1") Then
                    MessageBox.Show("El registro se ha eliminado correctamente.")
                    actualizarData()
                Else
                    MessageBox.Show("No se pudo eliminar el registro.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub
End Class