Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports System.Web.Services.Description

Public Class frmSupervision_Movimientos_Tareos
    Dim tareoActual As New Tareo
    Dim dataSetParaControles As DataSet
    Dim dataSetParaControlesDetalle As DataSet
    Dim bsResultado As New BindingSource()
    Dim filasSeleccionadas As Integer = 0
    Dim onLine As Boolean = True
    Dim tablaTareos As DataTable

    Private Sub frmSupervision_Movimientos_Tareos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        determinarModoTrabajo()
        obtenerDataParaControles()
        pkrDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        pkrHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)
        'listarTareos()
        llenarCombo(cboTurno, dataSetParaControles.Tables(0))
        llenarCombo(cboResponsable, dataSetParaControles.Tables(1))
        llenarCombo(cboEstado, dataSetParaControles.Tables(2))
        bloquearControl(btnTransferir)
        bloquearControl(cboTurno)
        bloquearControl(pkrDia)
        bloquearControl(btnCancelar)
        bloquearControl(btnGuardar)
        tlpPrincipal.Visible = True
        dgvResultado.ClearSelection()
        dgvResultado.CurrentCell = Nothing

    End Sub

    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
        comboBox.DataSource = Nothing
        Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            comboBox.DataSource = dataTable
            comboBox.ValueMember = "Clave"
            If dataTable.Rows.Count < 10 Then
                comboBox.DisplayMember = "Valor"
            Else
                comboBox.DisplayMember = "Concatenado"
            End If
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    comboBox.DataSource = dataView
                    comboBox.ValueMember = "Clave"
                    If dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                End If
                i = i + 1
            Next
        End If
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub


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
        If (e.Context =
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

    Private Sub actualizarFiltro()
        Dim filtro As String = String.Empty
        filtro = String.Format("F_Dia >= '{0:yyyy-MM-dd}' And " +
                                           "F_Dia <= '{1:yyyy-MM-dd}'",
                                            pkrDesde.Value,
                                            pkrHasta.Value
                                            )
        If cboResponsable.SelectedValue <> "T" Then
            filtro = filtro + String.Format(" And T_DniResponsable = '{0}'",
                                            cboResponsable.SelectedValue.ToString
                                            )
        End If
        If cboEstado.SelectedValue <> "T" Then
            filtro = filtro + String.Format(" And Estado = '{0}'",
                                            cboEstado.SelectedValue.ToString
                                            )
        End If

        bsResultado.Filter = filtro

        lblDin_Resultado.Text = "Coincicidencias: " + bsResultado.Count.ToString
        filasSeleccionadas = 0
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboResponsable.SelectedIndexChanged
        'If tlpPrincipal.Visible = True Then
        '    actualizarFiltro()
        'End If
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        'If tlpPrincipal.Visible = True Then
        '    actualizarFiltro()
        'End If
    End Sub
    Private Sub pkrDesde_ValueChanged(sender As Object, e As EventArgs) Handles pkrDesde.ValueChanged
        'actualizarFiltro()
        ''listarTareos()
    End Sub
    Private Sub pkrHasta_ValueChanged(sender As Object, e As EventArgs) Handles pkrHasta.ValueChanged
        'actualizarFiltro()
        ''listarTareos()
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            tareoActual.Id = dgvResultado.Rows(e.RowIndex).Cells("T_IdTareo").Value
            tareoActual.Anio = dgvResultado.Rows(e.RowIndex).Cells("T_Anio").Value
            tareoActual.NroTareo = dgvResultado.Rows(e.RowIndex).Cells("T_NroTareo").Value
            tareoActual.Estado = dgvResultado.Rows(e.RowIndex).Cells("T_IdEstado").Value
            tareoActual.DniResponsable = dgvResultado.Rows(e.RowIndex).Cells("T_DniResponsable").Value
            tareoActual.IdResponsable = dgvResultado.Rows(e.RowIndex).Cells("T_IdResponsable").Value
            tareoActual.Turno = dgvResultado.Rows(e.RowIndex).Cells("T_IdTurno").Value
            tareoActual.Fecha = dgvResultado.Rows(e.RowIndex).Cells("F_Dia").Value
            tareoActual.Periodo = dgvResultado.Rows(e.RowIndex).Cells("T_Periodo").Value
            tareoActual.Semana = dgvResultado.Rows(e.RowIndex).Cells("T_Semana").Value
            'ACTUALIZAR CONTROLES
            actualizarControles(tareoActual)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede editar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If

        ''HATCH
        'DEFINIMOS UNA LISTA DE USUARIOS QUE PUEDAN APROBAR TAREOS
        'Dim usuariosPermitidos As String() = {"JMERA", "JSIESQUEN", "JCRUZ", "JMOROCHO"}
        'Dim usuariosPermitidos As String() = doItBaby("obtenerUsuariosConPermisosTareos", Nothing, TipoQuery.Scalar)
        Dim usuariosPermitidos As DataTable = doItBaby("obtenerUsuariosConPermisosTareos", Nothing, TipoQuery.DataTable)
        Dim filasUsuariosPermitidos() As DataRow = usuariosPermitidos.Select("ALLOW_UPDATE =" & 1)

        Dim supervisorTareador As DataTable = doItBaby("obtenerRelacionSupervisorTareadorEditar", Nothing, TipoQuery.DataTable)
        'Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO_TAREADOR = '" & tareoActual.IdResponsable & "' AND IDUSUARIO = '" & usuarioActual & "'")
        Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO = '" & usuarioActual & "'")

        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para editar un registro debe seleccionarlo primero.")

            'ElseIf tareoActual.IdResponsable <> usuarioActual And usuarioActual <> "JMERA" And usuarioActual <> "JSIESQUEN" And usuarioActual <> "JCRUZ" Then
        ElseIf tareoActual.IdResponsable <> usuarioActual AndAlso filassupervisorTareador.Length = 0 Then
            'ElseIf tareoActual.IdResponsable <> usuarioActual AndAlso Not usuariosPermitidos.Contains(usuarioActual) Then

            MessageBox.Show("No tiene permisos para editar este registro")
        Else
            bloquearControl(btnNuevo)
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
            bloquearControl(gbxFiltrar)
            'bloquearControl(dgvResultado)
            bloquearFilas(dgvResultado)
            'desbloquearControl(gbxTareo) 'esto resetea los combobox internos
            desbloquearControl(cboTurno)
            desbloquearControl(pkrDia)
            desbloquearControl(btnCancelar)
            desbloquearControl(btnGuardar)
            'gbxTareo.Enabled = True
            'MessageBox.Show(generarNuevoId("1ZD50Z", "A"))
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        tareoActual = New Tareo
        tareoActual.Id = "000000000000" 'generarNuevoId(tablaTareos.Compute("MAX(IdTareo)", "IdTareo<>''"), "A")
        tareoActual.DniResponsable = usuarioActual
        tareoActual.Estado = "M"
        'tareoActual("turno") = cboTurno.SelectedValue
        'tareoActual("dia") = pkrDia.Value.ToString("yyyy-MM-dd")
        lblDin_IdTareo.Text = tareoActual.Id
        lblDin_Anio.Text = "0000"
        lblDin_NroTareo.Text = "00000"
        lblDin_Responsable.Text = tareoActual.DniResponsable
        lblDin_Periodo.Text = "000000"
        lblDin_Semana.Text = "00"

        'gbxTareo.Enabled = True
        'gbxFiltrar.Enabled = False
        'dgvResultado.Enabled = False

        bloquearControl(btnNuevo)
        bloquearControl(btnEditar)
        bloquearControl(btnEliminar)
        bloquearControl(gbxFiltrar)
        bloquearControl(dgvResultado)
        'desbloquearControl(gbxTareo)
        desbloquearControl(cboTurno)
        desbloquearControl(pkrDia)
        desbloquearControl(btnCancelar)
        desbloquearControl(btnGuardar)
        pkrDia.Value = DateAdd(DateInterval.Day, -1, Now)
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
        bloquearControl(cboTurno)
        bloquearControl(pkrDia)
        bloquearControl(btnCancelar)
        bloquearControl(btnGuardar)
    End Sub

    'Private Sub pkrDia_ValueChanged(sender As Object, e As EventArgs) Handles pkrDia.ValueChanged
    '    tareoActual("dia") = pkrDia.Value.ToString("yyyy-MM-dd")
    '    'MessageBox.Show(tareoActual("id") + tareoActual("responsable") + tareoActual("dia"))
    'End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'VALIDAR SI EL DIA ESTA ABIERTO
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se pueden crear tareos para el dia seleccionado porque se encuentra cerrado.")
            Exit Sub
        End If

        tareoActual.Turno = cboTurno.SelectedValue
        tareoActual.Fecha = pkrDia.Value.ToString("yyyy-MM-dd")
        p.Clear()
        p.Add("@Id", tareoActual.Id)
        p.Add("@Responsable", tareoActual.DniResponsable)
        p.Add("@Turno", tareoActual.Turno)
        p.Add("@Dia", tareoActual.Fecha)

        'Dim parametros As DataTable = New DataTable
        'tareoActual("turno") = cboTurno.SelectedValue
        'tareoActual("dia") = pkrDia.Value.ToString("yyyy-MM-dd")
        ''Columnas
        'parametros.Columns.Add("nombre")
        'parametros.Columns.Add("valor")
        'parametros.Columns.Add("tipoDatoSql")
        ''Filas correspondientes a la cantidad de parametros a usar
        'parametros.Rows.Add("@Id", tareoActual.Item("id"), "SqlDbType.VarChar")
        'parametros.Rows.Add("@Responsable", tareoActual.Item("responsable"), "SqlDbType.VarChar")
        'parametros.Rows.Add("@Turno", tareoActual.Item("turno"), "SqlDbType.Char")
        'parametros.Rows.Add("@Dia", tareoActual.Item("dia"), "SqlDbType.Date")
        Dim idTareoGuardado As String = String.Empty
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "M" Then
        If onLine Then
            idTareoGuardado = doItBaby("sp_Dg_Supervision_Movimientos_Tareos_CrealizarTareo", p, Datos.Conexion.TipoQuery.Scalar)
            If idTareoGuardado IsNot String.Empty Then
                tareoActual.Id = idTareoGuardado
                tareoActual.Estado = "D"
            Else
                MessageBox.Show("Algo salió mal en el intento.")
            End If
            abrirDetalleTareo(tareoActual)
        ElseIf tareoActual.Estado = "L" Then
            'PENDIENTE GUARDAR EN SQLITE
        End If
        'If Not execSP("sp_Dg_Supervision_Movimientos_Tareos_CrearTareo", parametros) Is Nothing Then
        '    ''MessageBox.Show("Correcto")
        '    obtenerDataInicial()
        '    tareoActual("id") = dataSetInicial.Tables(3).Compute("MAX(IdTareo)", "IdTareo<>''")
        '    tareoActual("estado") = "D"
        '    abrirDetalleTareo(tareoActual)

        '    'obtenerDataInicial()
        '    listarTareos()
        'Else
        '    MessageBox.Show("error")
        'End If

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
        Dim VenActual As New frmSupervision_Movimientos_TareosDetalle(tareo)
        'VenActual.Parent = Me
        'Me.Parent
        VenActual.MdiParent = Me.MdiParent
        'VenDetalle = New frmSupervision_Movimientos_TareosDetalle(tareoActual, dataSetParaControlesDetalle)
        'VenDetalle.MdiParent = Me.MdiParent
        VenActual.Show()

    End Sub
    Private Sub determinarModoTrabajo()
        If probarConexionDG() Then
            onLine = True
        Else
            onLine = False
            MessageBox.Show("Modo de trabajo OFFLINE activado. La data se almacerá temporalmente en la base LOCAL.")
        End If
    End Sub

    Private Sub actualizarControles(tareo As Tareo)
        lblDin_IdTareo.Text = tareoActual.Id
        lblDin_Anio.Text = tareoActual.Anio
        lblDin_NroTareo.Text = tareoActual.NroTareo
        lblDin_Responsable.Text = tareoActual.DniResponsable
        cboTurno.SelectedValue = tareoActual.Turno
        pkrDia.Value = tareoActual.Fecha
        lblDin_Periodo.Text = tareoActual.Periodo
        lblDin_Semana.Text = tareoActual.Semana
        If tareoActual.Estado = "N" Then
            bloquearControl(btnEditar)
            bloquearControl(btnEliminar)
        End If
    End Sub

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            tareoActual.Id = dgvResultado.Rows(e.RowIndex).Cells("T_IdTareo").Value
            tareoActual.Anio = dgvResultado.Rows(e.RowIndex).Cells("T_Anio").Value
            tareoActual.NroTareo = dgvResultado.Rows(e.RowIndex).Cells("T_NroTareo").Value
            tareoActual.Estado = dgvResultado.Rows(e.RowIndex).Cells("T_IdEstado").Value
            tareoActual.DniResponsable = dgvResultado.Rows(e.RowIndex).Cells("T_IdResponsable").Value
            tareoActual.Turno = dgvResultado.Rows(e.RowIndex).Cells("T_IdTurno").Value
            tareoActual.Fecha = dgvResultado.Rows(e.RowIndex).Cells("F_Dia").Value
            tareoActual.Periodo = dgvResultado.Rows(e.RowIndex).Cells("T_Periodo").Value
            tareoActual.Semana = dgvResultado.Rows(e.RowIndex).Cells("T_Semana").Value
            actualizarControles(tareoActual)
            abrirDetalleTareo(tareoActual)
        End If
    End Sub

    Private Sub obtenerDataParaControles()
        Dim aux As DataSet = New DataSet
        If onLine Then
            aux = doItBaby("sp_Dg_Supervision_Movimientos_Tareos_CargarData", Nothing, TipoQuery.DataSet)
            'aux = execSp_Dg_Supervision_Movimientos_Tareos_CargarData()
            dataSetParaControles = New DataSet
            dataSetParaControles.Tables.Add(aux.Tables(0).Copy)
            dataSetParaControles.Tables.Add(aux.Tables(1).Copy)
            dataSetParaControles.Tables.Add(aux.Tables(2).Copy)
            dataSetParaControlesDetalle = New DataSet
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(3).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(4).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(5).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(6).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(7).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(8).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(9).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(10).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(11).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(12).Copy) 'TABLAS NUEVAS
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(13).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(14).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(15).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(16).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(17).Copy)

            'dataSetParaControles.Tables.Add(aux.Tables(3).Copy) 'DATA PARA DGVRESULTADO
        Else
            'PENDIENTEcargarDatasetdesdesqlite
        End If
        'obtener data sqlite
    End Sub

    Private Sub listarTareos()
        'dgvResultado.Columns.Clear()
        tablaTareos = Nothing
        If onLine Then
            'tablaTareos = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarTareosPacking",
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", pkrDesde.Value.ToString("yyyy-MM-dd"))
            p.Add("@Hasta", pkrHasta.Value.ToString("yyyy-MM-dd"))
            p.Add("@TareosEscritorio", cbxEscritorio.Checked)
            p.Add("@TareosMoviles", cbxMoviles.Checked)
            tablaTareos = doItBaby("sp_Dg_Supervision_Movimientos_Tareos_ListarTareos", p, Datos.Conexion.TipoQuery.DataTable)
        End If

        dgvResultado.Columns.Clear()

        dgvResultado.DataSource = Nothing
        Dim dvResultado As New DataView(tablaTareos)
        'Dim dvResultado As New DataView(dataParaDgvResultado)
        bsResultado.DataSource = dvResultado
        dgvResultado.DataSource = dvResultado

        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        dgvColumnCheck = New DataGridViewCheckBoxColumn()
        dgvColumnCheck.Name = "CheckSel"
        dgvColumnCheck.HeaderText = "Sel"
        dgvResultado.Columns.Insert(0, dgvColumnCheck)

        'corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()

        ''Dim filas As Integer = dgvResultado.RowCount
        ''lblDin_Resultado.Text = filas.ToString
        'lblCoincidencias.Text = "Coincidencias: " + filas.ToString

        dgvResultado.Columns("T_DniResponsable").Visible = False
        dgvResultado.Columns(0).Visible = False

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)


        formatearDataGridView(dgvResultado)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede eliminar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If

        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para Eliminar un registro debe seleccionarlo primero.")
            'ElseIf tareoActual.IdResponsable <> usuarioActual And usuarioActual <> "JMERA" And usuarioActual <> "JSIESQUEN" And usuarioActual <> "JCRUZ" Then
            '    MessageBox.Show("No tiene permisos para elmininar este registro")
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
                        id = fila.Cells(1).Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@IdTareo", id)
                        If tareoActual.Estado = "PE" Or tareoActual.Estado = "D" Then
                            doItBaby("sp_Dg_Supervision_Movimientos_Tareos_EliminarTareo", parametros, Datos.Conexion.TipoQuery.NonQuery)
                        Else
                            MessageBox.Show("El tareo no cuenta con el estado PENDIENTE para eliminar.")
                        End If
                    Next
                    MessageBox.Show("Tareo eliminado correctamente.")
                    'listarTareos()
                    dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, dgvResultado.SelectedRows(0).Index))
                Catch
                    MessageBox.Show("Error al tratar de eliminar tareo.")
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub frmSupervision_Movimientos_Tareos_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If dgvResultado.RowCount > 0 Then
            ''listarTareos()
        End If
    End Sub

    Private Sub cbxMoviles_CheckStateChanged(sender As Object, e As EventArgs) Handles cbxMoviles.CheckStateChanged
        ''listarTareos()
    End Sub

    Private Sub cbxEscritorio_CheckStateChanged(sender As Object, e As EventArgs) Handles cbxEscritorio.CheckStateChanged
        ''listarTareos()
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER.
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede aprobar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If

        Dim usuariosPermitidos As DataTable = doItBaby("obtenerUsuariosConPermisosTareos", Nothing, TipoQuery.DataTable)
        Dim filasUsuariosPermitidos() As DataRow = usuariosPermitidos.Select("ALLOW_UPDATE =" & 1)

        Dim supervisorTareador As DataTable = doItBaby("obtenerRelacionSupervisorTareadorAprobar", Nothing, TipoQuery.DataTable)
        'Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO_TAREADOR = '" & tareoActual.IdResponsable & "' AND IDUSUARIO = '" & usuarioActual & "'")
        Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO = '" & usuarioActual & "'")
        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para Aprobar un registro debe seleccionarlo primero.")
            'ElseIf usuarioActual <> "JMERA" And usuarioActual <> "JSIESQUEN" And usuarioActual <> "JCRUZ" Then
        ElseIf tareoActual.IdResponsable <> usuarioActual AndAlso filassupervisorTareador.Length = 0 Then

            MessageBox.Show("No tiene permisos para aprobar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = tareoActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            If dgvResultado.SelectedRows.Count = 1 Then
                mensaje = String.Format("Esta seguro de aprobar el tareo: {0}", tareoActual.Id)
                respuesta = MessageBox.Show(mensaje, "Aprobar Tareo", MessageBoxButtons.YesNo)
            Else
                mensaje = String.Format("Esta seguro de aprobar {0} tareo(s).", dgvResultado.SelectedRows.Count)
                respuesta = MessageBox.Show(mensaje, "Aprobar Tareo", MessageBoxButtons.YesNo)
            End If
            If respuesta = DialogResult.Yes Then
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        '
                        tareoActual.Id = fila.Cells("T_IdTareo").Value
                        tareoActual.Anio = fila.Cells("T_Anio").Value
                        tareoActual.NroTareo = fila.Cells("T_NroTareo").Value
                        tareoActual.Estado = fila.Cells("T_IdEstado").Value
                        tareoActual.DniResponsable = fila.Cells("T_DniResponsable").Value
                        tareoActual.IdResponsable = fila.Cells("T_IdResponsable").Value
                        tareoActual.Turno = fila.Cells("T_IdTurno").Value
                        tareoActual.Fecha = fila.Cells("F_Dia").Value
                        tareoActual.Periodo = fila.Cells("T_Periodo").Value
                        tareoActual.Semana = fila.Cells("T_Semana").Value
                        '
                        'id = fila.Cells(1).Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@IdTareo", tareoActual.Id)
                        If tareoActual.Estado = "PE" Then
                            doItBaby("sp_Dg_Supervision_Movimientos_Tareos_AprobarTareo", parametros, Datos.Conexion.TipoQuery.NonQuery)
                            'MessageBox.Show("Tareo aprobado correctamente.")
                        Else
                            MessageBox.Show("El tareo {0} no cuenta con estado PENDIENTE para poder ser aprobado.", tareoActual.Id)
                        End If
                    Next
                    MessageBox.Show("Tareos aprobado correctamente.")
                    listarTareos()
                    dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, dgvResultado.SelectedRows(0).Index))
                Catch
                    MessageBox.Show("Error al tratar de aprobar tareo.")
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub btnDesaprobar_Click(sender As Object, e As EventArgs) Handles btnDesaprobar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Supervision")
        p.Add("@Dia", tareoActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede desaprobar el tareo porque el dia se encuentra cerrado.")
            Exit Sub
        End If
        Dim usuariosPermitidos As DataTable = doItBaby("obtenerUsuariosConPermisosTareos", Nothing, TipoQuery.DataTable)
        Dim filasUsuariosPermitidos() As DataRow = usuariosPermitidos.Select("ALLOW_UPDATE =" & 1)

        Dim supervisorTareador As DataTable = doItBaby("obtenerRelacionSupervisorTareadorAprobar", Nothing, TipoQuery.DataTable)
        'Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO_TAREADOR = '" & tareoActual.IdResponsable & "' AND IDUSUARIO = '" & usuarioActual & "'")
        Dim filassupervisorTareador() As DataRow = supervisorTareador.Select("IDUSUARIO = '" & usuarioActual & "'")

        If dgvResultado.SelectedRows Is Nothing Or lblDin_IdTareo.Text = "000000000000" Then
            MessageBox.Show("Para Desaprobar un registro debe seleccionarlo primero.")
            'ElseIf usuarioActual <> "JMERA" And usuarioActual <> "JSIESQUEN" And usuarioActual <> "JCRUZ" Then
        ElseIf tareoActual.IdResponsable <> usuarioActual AndAlso filassupervisorTareador.Length = 0 Then

            MessageBox.Show("No tiene permisos para desaprobar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = tareoActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            If dgvResultado.SelectedRows.Count = 1 Then
                mensaje = String.Format("Esta seguro de desaprobar el tareo: {0}", tareoActual.Id)
                respuesta = MessageBox.Show(mensaje, "Desaprobar Tareo", MessageBoxButtons.YesNo)
            Else
                mensaje = String.Format("Esta seguro de desprobar {0} tareo(s).", dgvResultado.SelectedRows.Count)
                respuesta = MessageBox.Show(mensaje, "Desaprobar Tareo", MessageBoxButtons.YesNo)
            End If
            If respuesta = DialogResult.Yes Then
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        id = fila.Cells(1).Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@IdTareo", id)
                        If tareoActual.Estado = "AP" Then
                            doItBaby("sp_Dg_Supervision_Movimientos_Tareos_DesaprobarTareo", parametros, Datos.Conexion.TipoQuery.NonQuery)
                            MessageBox.Show("Tareo desaprobado correctamente.")
                        Else
                            MessageBox.Show("El tareo actual no cuenta con estado APROBADO para poder desaprobar.")
                        End If
                    Next
                    listarTareos()
                    dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(1, dgvResultado.SelectedRows(0).Index))
                Catch
                    MessageBox.Show("Error al tratar de desaprobar tareo.")
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub dgvResultado_SelectionChanged(sender As Object, e As EventArgs) Handles dgvResultado.SelectionChanged
        If dgvResultado.SelectedRows.Count > 0 Then
            tareoActual.Id = dgvResultado.SelectedRows.Item(0).Cells("T_IdTareo").Value
            tareoActual.Anio = dgvResultado.SelectedRows.Item(0).Cells("T_Anio").Value
            tareoActual.NroTareo = dgvResultado.SelectedRows.Item(0).Cells("T_NroTareo").Value
            tareoActual.Estado = dgvResultado.SelectedRows.Item(0).Cells("T_IdEstado").Value
            tareoActual.DniResponsable = dgvResultado.SelectedRows.Item(0).Cells("T_DniResponsable").Value
            tareoActual.IdResponsable = dgvResultado.SelectedRows.Item(0).Cells("T_IdResponsable").Value
            tareoActual.Turno = dgvResultado.SelectedRows.Item(0).Cells("T_IdTurno").Value
            tareoActual.Fecha = dgvResultado.SelectedRows.Item(0).Cells("F_Dia").Value
            tareoActual.Periodo = dgvResultado.SelectedRows.Item(0).Cells("T_Periodo").Value
            tareoActual.Semana = dgvResultado.SelectedRows.Item(0).Cells("T_Semana").Value
            'ACTUALIZAR CONTROLES
            actualizarControles(tareoActual)
        End If
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click

        If cbxEscritorio.Checked = False And cbxMoviles.Checked = False Then
            MsgBox("Seleccionar Opción Escritorio y/o Moviles", 48, "Mensaje")
        End If
        actualizarFiltro()
        listarTareos()
    End Sub

    Private Sub cbVistaSimplificada_CheckedChanged(sender As Object, e As EventArgs) Handles cbVistaSimplificada.CheckedChanged
        'Dim usuario As String = Temporales.usuarioActual
        Dim isChecked As Boolean = CType(sender, CheckBox).Checked
        Dim usuariosPermitidos As String() = {"JCRUZ"}
        AlternarVista(Not isChecked)
    End Sub

    Private Sub AlternarVista(checkboxValue As Boolean)
        dgvResultado.Columns("T_anio").Visible = checkboxValue
        dgvResultado.Columns("T_DniResponsable").Visible = checkboxValue
        dgvResultado.Columns("T_IdResponsable").Visible = checkboxValue
        dgvResultado.Columns("T_Periodo").Visible = checkboxValue
        dgvResultado.Columns("T_Semana").Visible = checkboxValue
    End Sub
End Class