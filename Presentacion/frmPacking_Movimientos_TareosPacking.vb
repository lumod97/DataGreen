Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion

Public Class frmPacking_Movimientos_TareosPacking

    Dim tareoActual As New Tareo
    Dim dataSetParaControles As DataSet
    'Dim dataSetParaControlesDetalle As DataSet
    Dim bsResultado As New BindingSource()
    Dim filasSeleccionadas As Integer = 0
    'Dim onLine As Boolean = True
    Dim tablaTareos As DataTable
    Dim arrayDeParametros As String = String.Empty
    Dim cambioManualDtpDesde As Boolean = False
    Dim cambioManualDtpHasta As Boolean = False
    Dim combosCargados As Boolean = False

    Private Sub frmSupervision_Movimientos_Tareos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        'determinarModoTrabajo()
        obtenerDataParaControles()
        setearValoresIniciales()

        cargarCombo(cboTurno, dataSetParaControles.Tables(0), 0, 2)
        cargarCombo(cboResponsable, dataSetParaControles.Tables(1), 0, 2)
        cargarCombo(cboEstado, dataSetParaControles.Tables(2), 0, 2)
        cargarCombo(cboCultivo, dataSetParaControles.Tables(3), 0, 2)
        combosCargados = True
        listarTareosAsync()

        bloquearControl(tlpNuevoTareo)
        'bloquearControl(btnTransferir)
        'bloquearControl(cboTurno)
        'bloquearControl(pkrDia)
        'bloquearControl(btnCancelar)
        'bloquearControl(btnGuardar)
        tlpPrincipal.Visible = True
        dgvResultado.ClearSelection()
        dgvResultado.CurrentCell = Nothing
    End Sub

    Private Sub setearValoresIniciales()
        pkrDesde.Value = New Date(Now.Year, Now.Month, 1)
        pkrHasta.Value = Now
    End Sub


    'Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
    '    comboBox.DataSource = Nothing
    '    Dim i As Integer = 0
    '    If dataTable.Columns.Count = 3 Then
    '        comboBox.DataSource = dataTable
    '        comboBox.ValueMember = "Clave"
    '        If dataTable.Rows.Count < 10 Then
    '            comboBox.DisplayMember = "Valor"
    '        Else
    '            comboBox.DisplayMember = "Concatenado"
    '        End If
    '    Else
    '        For Each fila As DataRow In dataTable.Rows
    '            If fila.Item(0).ToString = condicion Then
    '                Dim dt As DataTable = dataTable
    '                Dim dataView As DataView = dt.DefaultView
    '                dataView.RowFilter = "Condicion = '" & condicion & "'"
    '                comboBox.DataSource = dataView
    '                comboBox.ValueMember = "Clave"
    '                If dataView.Count < 10 Then
    '                    comboBox.DisplayMember = "Valor"
    '                Else
    '                    comboBox.DisplayMember = "Concatenado"
    '                End If
    '            End If
    '            i = i + 1
    '        Next
    '    End If
    '    comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
    'End Sub


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

    'Private Sub actualizarFiltro()
    '    Dim filtro As String = String.Empty
    '    filtro = String.Format("F_Dia >= '{0:yyyy-MM-dd}' And " +
    '                                       "F_Dia <= '{1:yyyy-MM-dd}'",
    '                                        pkrDesde.Value,
    '                                        pkrHasta.Value
    '                                        )
    '    If cboResponsable.SelectedValue <> "T" Then
    '        filtro = filtro + String.Format(" And DniResponsable = '{0}'",
    '                                        cboResponsable.SelectedValue.ToString
    '                                        )
    '    End If
    '    If cboEstado.SelectedValue <> "T" Then
    '        filtro = filtro + String.Format(" And Estado = '{0}'",
    '                                        cboEstado.SelectedValue.ToString
    '                                        )
    '    End If

    '    bsResultado.Filter = filtro

    '    lbl_Resultado.Text = "Coincicidencias: " + bsResultado.Count.ToString
    '    filasSeleccionadas = 0
    'End Sub

    'Private Sub cboResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResponsable.SelectedIndexChanged
    '    'If tlpPrincipal.Visible = True Then
    '    '    actualizarFiltro()
    '    'End If
    '    listarTareosAsync()
    'End Sub

    'Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
    '    'If tlpPrincipal.Visible = True Then
    '    '    actualizarFiltro()
    '    'End If
    '    listarTareosAsync()
    'End Sub

    Private Sub pkrDesde_ValueChanged(sender As Object, e As EventArgs) Handles pkrDesde.ValueChanged
        'actualizarFiltro()
        If cambioManualDtpDesde Then
            If pkrDesde.Value > pkrHasta.Value Then
                pkrHasta.Value = pkrDesde.Value
            End If
            listarTareosAsync()
        End If
    End Sub

    Private Sub pkrHasta_ValueChanged(sender As Object, e As EventArgs) Handles pkrHasta.ValueChanged
        If cambioManualDtpHasta Then
            If pkrHasta.Value < pkrDesde.Value Then
                pkrDesde.Value = pkrHasta.Value
            End If
            listarTareosAsync()
        End If
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            tareoActual.Id = dgvResultado.Rows(e.RowIndex).Cells("IdTareoPacking").Value
            tareoActual.IdEstado = dgvResultado.Rows(e.RowIndex).Cells("IdEstado").Value
            'tareoActual.Estado = dgvResultado.Rows(e.RowIndex).Cells(4).Value
            tareoActual.DniResponsable = dgvResultado.Rows(e.RowIndex).Cells("DniResponsable").Value
            tareoActual.IdResponsable = dgvResultado.Rows(e.RowIndex).Cells("IdResponsable").Value
            tareoActual.Turno = dgvResultado.Rows(e.RowIndex).Cells("Turno").Value
            tareoActual.Fecha = dgvResultado.Rows(e.RowIndex).Cells("Fecha").Value
            tareoActual.IdCultivo = dgvResultado.Rows(e.RowIndex).Cells("IdCultivo").Value
            actualizarControles(tareoActual)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para editar un registro debe seleccionarlo primero.")
        ElseIf lblDin_Responsable.Text <> usuarioActual Then
            MessageBox.Show("No tiene permisos para editar este registro")
        Else
            bloquearControl(btnNuevo)
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
            bloquearControl(gbxFiltrar)
            'bloquearControl(dgvResultado)
            bloquearFilas(dgvResultado)
            'desbloquearControl(gbxTareo) 'esto resetea los combobox internos

            desbloquearControl(tlpNuevoTareo)
            'desbloquearControl(cboTurno)
            'desbloquearControl(pkrDia)
            'desbloquearControl(btnCancelar)
            'desbloquearControl(btnGuardar)
            'gbxTareo.Enabled = True
            'MessageBox.Show(generarNuevoId("1ZD50Z", "A"))
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboTurno.SelectedIndex = 1
        tareoActual = New Tareo
        'If tablaTareos.Rows.Count > 0 Then
        '    tareoActual.Id = generarNuevoId(tablaTareos.Compute("MAX(IdTareoPacking)", "IdTareoPacking<>''"), "A")
        'Else
        '    tareoActual.Id = "000000000001"
        'End If
        tareoActual.Id = "000000000000"
        'tareoActual.Id = IIf(tablaTareos.Rows.Count > 0, generarNuevoId(tablaTareos.Compute("MAX(IdTareo)", "IdTareo<>''"), "A"), "0")
        'tareoActual.DniResponsable = usuarioActual
        tareoActual.IdResponsable = usuarioActual
        tareoActual.Estado = "PE"
        tareoActual.IdCultivo = cboCultivo.SelectedValue
        'tareoActual("turno") = cboTurno.SelectedValue
        'tareoActual("dia") = pkrDia.Value.ToString("yyyy-MM-dd")
        lblDin_IdTareo.Text = tareoActual.Id
        'lblDin_Anio.Text = "0000"
        'lblDin_NroTareo.Text = "00000"
        lblDin_Responsable.Text = tareoActual.IdResponsable

        'lblDin_Periodo.Text = "000000"
        'lblDin_Semana.Text = "00"

        'gbxTareo.Enabled = True
        'gbxFiltrar.Enabled = False
        'dgvResultado.Enabled = False

        bloquearControl(btnNuevo)
        bloquearControl(btnEditar)
        bloquearControl(btnEliminar)
        bloquearControl(gbxFiltrar)
        bloquearControl(dgvResultado)
        'desbloquearControl(gbxTareo)
        desbloquearControl(tlpNuevoTareo)
        'desbloquearControl(cboTurno)
        'desbloquearControl(pkrDia)
        'desbloquearControl(btnCancelar)
        'desbloquearControl(btnGuardar)
        pkrDia.Value = Now()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'tareoActual = Nothing
        'gbxTareo.Enabled = False
        'gbxFiltrar.Enabled = True
        'dgvResultado.Enabled = True
        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
        desbloquearControl(btnEliminar)
        desbloquearControl(gbxFiltrar)
        desbloquearControl(dgvResultado)
        'bloquearControl(gbxTareo)

        bloquearControl(tlpNuevoTareo)
        'bloquearControl(cboTurno)
        'bloquearControl(pkrDia)
        'bloquearControl(btnCancelar)
        'bloquearControl(btnGuardar)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        tareoActual.Turno = cboTurno.SelectedValue
        tareoActual.Fecha = pkrDia.Value.ToString("yyyy-MM-dd")
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Id", tareoActual.Id)
        p.Add("@IdResponsable", tareoActual.IdResponsable)
        p.Add("@Turno", tareoActual.Turno)
        p.Add("@Fecha", tareoActual.Fecha)
        p.Add("@IdCultivo", tareoActual.IdCultivo)

        Dim idTareoGuardado As String = String.Empty

        idTareoGuardado = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_CrealizarTareo", p, Datos.Conexion.TipoQuery.Scalar)
        If idTareoGuardado IsNot String.Empty Then
            tareoActual.Id = idTareoGuardado
            tareoActual.IdEstado = "PE"
        Else
            MessageBox.Show("Algo salió mal en el intento.")
        End If
        abrirDetalleTareo(tareoActual)

        'AGREGADO PARA EVITAR EL FORMCLOSED
        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
        desbloquearControl(btnEliminar)
        desbloquearControl(gbxFiltrar)
        'bloquearControl(dgvResultado)
        desbloquearFilas(dgvResultado)
        'bloquearControl(gbxTareo)
        bloquearControl(cboTurno)
        bloquearControl(pkrDia)
        bloquearControl(btnCancelar)
        bloquearControl(btnGuardar)
        'gbxTareo.Enabled = False
    End Sub

    Private Sub abrirDetalleTareo(tareo As Tareo)
        Dim VenActual As New frmPacking_Movimientos_TareosPackingDetalle_Nuevo(tareo)
        'VenActual.Parent = Me
        'Me.Parent
        VenActual.MdiParent = Me.MdiParent
        'VenDetalle = New frmSupervision_Movimientos_TareosDetalle(tareoActual, dataSetParaControlesDetalle)
        'VenDetalle.MdiParent = Me.MdiParent
        VenActual.Show()

    End Sub

    'Private Sub determinarModoTrabajo()
    '    If probarConexionDG() Then
    '        onLine = True
    '    Else
    '        onLine = False
    '        MessageBox.Show("Modo de trabajo OFFLINE activado. La data se almacerá temporalmente en la base LOCAL.")
    '    End If
    'End Sub

    Private Sub actualizarControles(tareo As Tareo)
        lblDin_IdTareo.Text = tareoActual.Id
        'lblDin_Anio.Text = tareoActual.Anio
        'lblDin_NroTareo.Text = tareoActual.NroTareo
        lblDin_Responsable.Text = tareoActual.IdResponsable
        cboTurno.SelectedValue = tareoActual.Turno
        pkrDia.Value = tareoActual.Fecha
        'lblDin_Periodo.Text = tareoActual.Periodo
        'lblDin_Semana.Text = tareoActual.Semana
        If tareoActual.Estado = "N" Then
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
        End If
    End Sub

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            tareoActual.Id = dgvResultado.Rows(e.RowIndex).Cells("IdTareoPacking").Value
            tareoActual.IdEstado = dgvResultado.Rows(e.RowIndex).Cells("IdEstado").Value
            'tareoActual.Estado = dgvResultado.Rows(e.RowIndex).Cells(4).Value
            tareoActual.DniResponsable = dgvResultado.Rows(e.RowIndex).Cells("DniResponsable").Value
            tareoActual.Turno = dgvResultado.Rows(e.RowIndex).Cells("Turno").Value
            tareoActual.Fecha = dgvResultado.Rows(e.RowIndex).Cells("Fecha").Value
            tareoActual.IdCultivo = dgvResultado.Rows(e.RowIndex).Cells("IdCultivo").Value
            actualizarControles(tareoActual)
            abrirDetalleTareo(tareoActual)
        End If
    End Sub

    Private Sub obtenerDataParaControles()
        dataSetParaControles = New DataSet
        'dataSetParaControles.Tables.Add(aux.Tables(0).Copy)
        dataSetParaControles.Tables.Add(doItBaby("sp_Dg_ObtenerTurnosTareos", Nothing, TipoQuery.DataTable))
        dataSetParaControles.Tables.Add(doItBaby("sp_ObtenerResponsablesTareosPacking", Nothing, TipoQuery.DataTable))
        dataSetParaControles.Tables.Add(doItBaby("sp_ObtenerEstados", Nothing, TipoQuery.DataTable))
        dataSetParaControles.Tables.Add(doItBaby("sp_Dg_ObtenerCultivos", Nothing, TipoQuery.DataTable))

        'If onLine Then
        '    aux = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_CargarData", Nothing, TipoQuery.DataSet)
        '    'aux = execSp_Dg_Supervision_Movimientos_Tareos_CargarData()
        '    dataSetParaControles = New DataSet
        '    dataSetParaControles.Tables.Add(aux.Tables(0).Copy)
        '    dataSetParaControles.Tables.Add(aux.Tables(1).Copy)
        '    dataSetParaControles.Tables.Add(aux.Tables(2).Copy)
        '    dataSetParaControlesDetalle = New DataSet
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(3).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(4).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(5).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(6).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(7).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(8).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(9).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(10).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(11).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(12).Copy)
        '    dataSetParaControlesDetalle.Tables.Add(aux.Tables(13).Copy)
        '    'dataSetParaControles.Tables.Add(aux.Tables(3).Copy) 'DATA PARA DGVRESULTADO
        'Else
        '    'PENDIENTEcargarDatasetdesdesqlite
        'End If
        ''obtener data sqlite
    End Sub

    Private Async Sub listarTareosAsync()
        dgvResultado.DataSource = Nothing
        tablaTareos = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lbl_Resultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaTareos = Await dgv
        corregirTabla(tablaTareos)
        dgvResultado.DataSource = tablaTareos
        apagarControlesDeEspera(barProgreso, lbl_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)

            p.Add("@Desde", CType(pkrDesde.Value.ToString("yyyy-MM-dd"), Date))
            p.Add("@Hasta", CType(pkrHasta.Value.ToString("yyyy-MM-dd"), Date))
            p.Add("@DniResponsable", cboResponsable.SelectedValue)
            p.Add("@IdEstado", cboEstado.SelectedValue)

            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarTareosPacking", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub listarTareos()
    '    tablaTareos = Nothing

    '    tablaTareos = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarTareosPacking", Nothing, Datos.Conexion.TipoQuery.DataTable)

    '    dgvResultado.Columns.Clear()
    '    dgvResultado.DataSource = Nothing

    '    corregirCeldas(dgvResultado)
    '    dgvResultado.AutoResizeColumns()
    '    dgvResultado.AutoResizeRows()

    '    Dim filas As Integer = dgvResultado.RowCount
    '    lbl_Resultado.Text = filas.ToString
    '    formatearDataGridView(dgvResultado)
    'End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim resultado As DataTable = New DataTable
        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para editar un registro debe seleccionarlo primero.")
        ElseIf tareoActual.IdResponsable <> usuarioActual Then
            MessageBox.Show("No tiene permisos para elminiar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = tareoActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            If dgvResultado.SelectedRows.Count = 1 Then
                mensaje = String.Format("Esta seguro de eliminar el tareo: {0}", tareoActual.Id)
                respuesta = MessageBox.Show(mensaje, "Eliminar Tareo", MessageBoxButtons.YesNo)
            Else
                mensaje = String.Format("Esta seguro de eliminar {0} tareo(s).", dgvResultado.SelectedRows.Count)
                respuesta = MessageBox.Show(mensaje, "Eliminar Tareo", MessageBoxButtons.YesNo)
            End If
            If respuesta = DialogResult.Yes Then
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        id = fila.Cells("IdTareoPacking").Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@IdTareoPacking", id)
                        If tareoActual.IdEstado = "PE" Then
                            resultado = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_EliminarTareoPacking", parametros, Datos.Conexion.TipoQuery.DataTable)
                        Else
                            MessageBox.Show("El estado del documento impide eliminarlo.")
                        End If
                    Next
                    If resultado.Rows(0).Item(0).ToString.Equals("1") Then
                        MessageBox.Show("Tareo(s) eliminado(s) correctamente.")
                    Else
                        Throw New Exception(resultado.Rows(0).Item(1).ToString.Equals("1"))
                    End If
                    'MessageBox.Show("Tareo eliminado correctamente.")
                    listarTareosAsync()
                    'dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, 1))
                Catch ex As Exception
                    'MessageBox.Show("Error al tratar de eliminar tareo.")
                    MessageBox.Show(ex.Message)
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub frmSupervision_Movimientos_Tareos_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If dgvResultado.RowCount > 0 Then
            listarTareosAsync()
        End If
    End Sub

    Private Sub cboResponsable_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboResponsable.SelectionChangeCommitted
        If combosCargados Then
            listarTareosAsync()
        End If
    End Sub

    Private Sub cboEstado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboEstado.SelectionChangeCommitted
        If combosCargados Then
            listarTareosAsync()
        End If
    End Sub

    Private Sub pkrDesde_DropDown(sender As Object, e As EventArgs) Handles pkrDesde.DropDown
        cambioManualDtpDesde = True
    End Sub

    Private Sub pkrDesde_CloseUp(sender As Object, e As EventArgs) Handles pkrDesde.CloseUp
        cambioManualDtpDesde = False
    End Sub

    Private Sub pkrHasta_CloseUp(sender As Object, e As EventArgs) Handles pkrHasta.CloseUp
        cambioManualDtpHasta = False
    End Sub

    Private Sub pkrHasta_DropDown(sender As Object, e As EventArgs) Handles pkrHasta.DropDown
        cambioManualDtpHasta = True
    End Sub

    Private Sub cboTurno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTurno.SelectionChangeCommitted
        tareoActual.Turno = cboTurno.SelectedValue
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        tareoActual.IdCultivo = cboCultivo.SelectedValue
    End Sub

    Private Sub btnGenerarTareo_Click(sender As Object, e As EventArgs) Handles btnGenerarTareo.Click
        Dim resultado As DataTable = New DataTable
        Dim aux As DataTable = New DataTable
        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Debe seleccionarlo al menos 1 registro.")
        ElseIf usuarioActual <> "JMOROCHO" Or usuarioActual <> "JMERA" Then
            MessageBox.Show("No tiene permisos para elminiar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = tareoActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            mensaje = String.Format("Esta seguro de procesar el(los) tareo(s) seleccionado(s)")
            respuesta = MessageBox.Show(mensaje, "Generar Tareo", MessageBoxButtons.YesNo)
            If respuesta = DialogResult.Yes Then
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        id = fila.Cells("IdTareoPacking").Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@IdTareoPacking", id)
                        If tareoActual.IdEstado = "PE" Then
                            aux = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_GenerarTareo", parametros, Datos.Conexion.TipoQuery.DataTable)
                            resultado.Rows.Add(aux.Rows(0))
                        Else
                            MessageBox.Show("No se puede procesar el documento {0} porque no tiene esta PENDIENTE.", id)
                        End If
                    Next
                    Dim concatenado As String = "El proceso finalizó con los siguientes resultado:" & vbNewLine
                    For Each f As DataRow In resultado.Rows
                        concatenado = concatenado & f.Item(1) & " " & IIf(f.Item(0).ToString.Equals("0"), "Error:", "Ok") & IIf(f.Item(0).ToString.Equals("0"), f.Item(2).ToString, "") & vbNewLine
                    Next
                    MessageBox.Show(concatenado)

                    'MessageBox.Show("Tareo eliminado correctamente.")
                    listarTareosAsync()
                    'dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, 1))
                Catch ex As Exception
                    'MessageBox.Show("Error al tratar de eliminar tareo.")
                    MessageBox.Show(ex.Message)
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub
End Class