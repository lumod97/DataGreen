Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion

Public Class frmPacking_Movimientos_TareosPackingDetalle_Nuevo


    Dim dsMetaDatos As New DataSet
    Dim dtTablaExcel As New DataTable



    Dim tareoActual As New Tareo
    Dim detalleTareoActual As DetalleTareo
    'Dim detalleTareoActual As New Dictionary(Of String, String)
    Dim dsControles As New DataSet
    Dim dtResultado As New DataTable
    Dim dtMarcasNuevas As New DataTable
    'Dim tablaPersonalJustificado As New DataTable

    Dim indicadorParaBGW As Integer = 0

    Public Sub New(ByVal tareoSeleccionado As Tareo)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        tareoActual = tareoSeleccionado
        'dataParaControles = tablas
        dgvResultado.MultiSelect = False
        'cargarControles()
    End Sub

    Private Sub frmSupervision_Movimientos_NuevoTareoPacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        dgvResultado.MultiSelect = True
        obtenerDataParaControles()
        cargarCombo(cboEstado, dsControles.Tables(0), 0, 2)
        cargarCombo(cboTurno, dsControles.Tables(1), 0, 2)
        cargarCombo(cboCultivo, dsControles.Tables(2), 0, 2)
        cargarCombo(cboPuntoControl, dsControles.Tables(3), 0, 2)
        cargarCombo(cboTerminales, dsControles.Tables(4), 0, 2)
        setearValoresIniciales()
        'combosCargados = True
        listarDetalleAsync()
        bloquearControl(cboEstado)
        DesactivarModoEdicion()
        tlpPrincipal.Visible = True
        dgvResultado.ClearSelection()
        dgvResultado.CurrentCell = Nothing
        txtLimiteaaa.Enabled = False

    End Sub

    Private Sub DesactivarModoEdicion()
        bloquearControl(btnCancelar)
        bloquearControl(btnGuardar)
        bloquearControl(btnGenerarTareo)
        bloquearControl(btnRevertirTareo)
        bloquearControl(dtpFechaInicio)
        bloquearControl(cboTurno)
        bloquearControl(cboCultivo)
        bloquearControl(cboPuntoControl)
        bloquearControl(cboTerminales)
        bloquearControl(btnDescargarMarcas)
        bloquearControl(dtpFechaFin)
        bloquearControl(btnActualizarFechaFin)
        bloquearControl(dtpHoraInicio)
        bloquearControl(btnActualizarHoraInicio)
        bloquearControl(dtpHoraFin)
        bloquearControl(btnActualizarHoraFin)
        bloquearControl(dtpTiempoRefrigerio)
        bloquearControl(btnActualizarTiempoRefrigerio)
        bloquearControl(dtpTiempoParada)
        bloquearControl(btnActualizarTiempoParada)
        bloquearControl(btnEliminar)
    End Sub

    Private Sub ActivarModoEdicion()
        If tareoActual.IdEstado = "PE" Then
            desbloquearControl(btnCancelar)
            desbloquearControl(btnGuardar)
            desbloquearControl(btnGenerarTareo)
            'desbloquearControl(btnRevertirTareo)
            desbloquearControl(dtpFechaInicio)
            desbloquearControl(cboTurno)
            desbloquearControl(cboCultivo)
            desbloquearControl(cboPuntoControl)
            desbloquearControl(cboTerminales)
            desbloquearControl(btnDescargarMarcas)
            desbloquearControl(dtpFechaFin)
            desbloquearControl(btnActualizarFechaFin)
            desbloquearControl(dtpHoraInicio)
            desbloquearControl(btnActualizarHoraInicio)
            desbloquearControl(dtpHoraFin)
            desbloquearControl(btnActualizarHoraFin)
            desbloquearControl(dtpTiempoRefrigerio)
            desbloquearControl(btnActualizarTiempoRefrigerio)
            desbloquearControl(dtpTiempoParada)
            desbloquearControl(btnActualizarTiempoParada)
            desbloquearControl(btnEliminar)
        Else
            desbloquearControl(btnRevertirTareo)
        End If
    End Sub
    Private Sub setearValoresIniciales()
        cboEstado.SelectedValue = tareoActual.IdEstado
        cboTurno.SelectedValue = tareoActual.Turno
        cboCultivo.SelectedValue = tareoActual.IdCultivo
        'cboPuntoControl.SelectedValue = 48
        dtpFechaInicio.Value = tareoActual.Fecha
    End Sub

    Private Sub obtenerDataParaControles()
        dsControles = New DataSet
        dsControles.Tables.Add(doItBaby("sp_ObtenerEstados", Nothing, TipoQuery.DataTable))
        dsControles.Tables.Add(doItBaby("sp_Dg_ObtenerTurnosTareos", Nothing, TipoQuery.DataTable))
        dsControles.Tables.Add(doItBaby("sp_Dg_ObtenerCultivos", Nothing, TipoQuery.DataTable))
        dsControles.Tables.Add(doItBaby("sp_Dg_ObtenerPuntosControl", Nothing, TipoQuery.DataTable))
        dsControles.Tables.Add(doItBaby("sp_Dg_ObtenerTerminales", Nothing, TipoQuery.DataTable))
        dsControles.Tables.Add(doItBaby("sp_ObtenerTiempoLimite", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Sub listarDetalleAsync()
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dtResultado = Await dgv
        corregirTabla(dtResultado)
        dgvResultado.DataSource = dtResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdTareo", tareoActual.Id)
            'arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarDetalle", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub obtenerMarcasAsync()
        encenderControlesDeEspera(barProgreso, lblResultado)
        Dim dgv As Task(Of DataTable)
        dgv = descargarMarcasAsync()
        dtMarcasNuevas = Await dgv
        unirTablas(dtResultado, dtMarcasNuevas)
        'corregirTabla(dtResultado)
        formatearDataGridView(dgvResultado)
        actualizarItems(dtResultado)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
    End Sub

    Private Async Function descargarMarcasAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", dtpFechaInicio.Value)
            p.Add("@IdPuntoControl", cboPuntoControl.SelectedValue)
            p.Add("@IdTerminal", cboTerminales.SelectedValue)
            'arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ObtenerMarcas", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub btnDescargarMarcas_Click(sender As Object, e As EventArgs) Handles btnDescargarMarcas.Click
        obtenerMarcasAsync()
    End Sub

    Private Sub actualizarItems(dt As DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            dt.Rows(i).Item("Item") = i + 1
        Next
    End Sub

    Private Sub unirTablas(dtPrincipal As DataTable, dtSecundaria As DataTable)
        Try
            If dtPrincipal.Columns.Count <> dtSecundaria.Columns.Count Then
                Throw New Exception("Error, las tablas tienen diferente cantidad de columnas, imposible unirlas.")
            Else
                'dtPrincipal.PrimaryKey = New DataColumn() {dtPrincipal.Columns.Item}
                'dtSecundaria.Rows.CopyTo(dtPrincipal.Rows, dtPrincipal.Rows.Count
                For Each f As DataRow In dtSecundaria.Rows
                    'Dim fAux As DataRow = dtPrincipal.Rows.Find(f.ItemArray)
                    'If fAux Is Nothing Then
                    If Not existeFilaEn(dtPrincipal, f) Then
                        dtPrincipal.ImportRow(f)
                    End If
                    'End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function existeFilaEn(dtMatriz As DataTable, filaBuscada As DataRow) As Boolean
        For Each f As DataRow In dtMatriz.Rows
            For i As Integer = 0 To f.ItemArray.Length - 1 Step 1
                If i > 0 AndAlso f.Item(i).ToString <> filaBuscada.Item(i).ToString Then
                    Exit For
                ElseIf i = f.ItemArray.Length - 1 Then
                    Return True
                End If
            Next
            'Return True
        Next
        Return False
    End Function
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If tareoActual.IdEstado = "PE" Then
            ActivarModoEdicion()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DesactivarModoEdicion()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        tareoActual.Fecha = dtpFechaInicio.Value
        For Each f As DataRow In dtResultado.Rows
            f.Item("FechaInicio") = dtpFechaInicio.Value.ToString("dd/MM/yyyy")
        Next
    End Sub

    Private Sub btnActualizarHoraInicio_Click(sender As Object, e As EventArgs) Handles btnActualizarHoraInicio.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    f2.Item("HoraInicio") = dtpHoraInicio.Value.ToString("HH:mm:ss")
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnActualizarFechaFin_Click(sender As Object, e As EventArgs) Handles btnActualizarFechaFin.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    f2.Item("FechaFin") = dtpFechaFin.Value.ToString("dd/MM/yyyy")
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnActualizarHoraFin_Click(sender As Object, e As EventArgs) Handles btnActualizarHoraFin.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    f2.Item("HoraFin") = dtpHoraFin.Value.ToString("HH:mm:ss")
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnActualizarTiempoRefrigerio_Click(sender As Object, e As EventArgs) Handles btnActualizarTiempoRefrigerio.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    f2.Item("TiempoRefrigerio") = dtpTiempoRefrigerio.Value.ToString("HH:mm:ss")
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnActualizarTiempoParada_Click(sender As Object, e As EventArgs) Handles btnActualizarTiempoParada.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    f2.Item("TiempoParada") = dtpTiempoParada.Value.ToString("HH:mm:ss")
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For Each f1 As DataGridViewRow In dgvResultado.SelectedRows
            For Each f2 As DataRow In dtResultado.Rows
                If f1.Cells("IdPuntoControl").Value.ToString = f2.Item("IdPuntoControl").ToString And f1.Cells("Dni").Value.ToString = f2.Item("Dni").ToString Then
                    dtResultado.Rows.Remove(f2)
                    Exit For
                End If
            Next
        Next
        actualizarItems(dtResultado)
        lblResultado.Text = "Resultado: " & dtResultado.Rows.Count
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdTareoPacking ", tareoActual.Id)
            p.Add("@Fecha", tareoActual.Fecha)
            p.Add("@Turno", tareoActual.Turno)
            p.Add("@IdCultivo", tareoActual.IdCultivo)
            p.Add("@DniUsuarioActualiza", usuarioActual)
            Dim t As DataTable = obtenerTablaParaSP(dtResultado)
            p.Add("@dtDetalle", t)

            Dim r As DataTable = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_GuardarDetalle", p, TipoQuery.DataTable)
            If r.Rows(0).Item("Resultado") = 1 Then
                'tareoActual.Id = r.Rows(0).Item("Id")
                'actualizarCabecera()
                listarDetalleAsync()
                MessageBox.Show(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
            ElseIf r.Rows(0).Item("Resultado") = 0 Then
                Throw New Exception(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cboTurno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTurno.SelectionChangeCommitted
        tareoActual.Turno = cboTurno.SelectedValue
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        tareoActual.IdCultivo = cboCultivo.SelectedValue
    End Sub

    Private Sub btnGenerarTareo_Click(sender As Object, e As EventArgs) Handles btnGenerarTareo.Click
        Try
            If tareoActual.IdEstado = "PE" Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdTareoPacking ", tareoActual.Id)
                p.Add("@UsuarioGenera", usuarioActual)
                Dim r As DataTable = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_GenerarTareo", p, TipoQuery.DataTable)
                If r.Rows(0).Item("Resultado") = 1 Then
                    listarDetalleAsync()
                    MessageBox.Show(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
                ElseIf r.Rows(0).Item("Resultado") = 0 Then
                    Throw New Exception(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
                End If
            Else
                Throw New Exception("El tareo ya fue generado.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRevertirTareo_Click(sender As Object, e As EventArgs) Handles btnRevertirTareo.Click
        Try
            If tareoActual.IdEstado = "GE" Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdTareoPacking ", tareoActual.Id)
                p.Add("@UsuarioRevierte", usuarioActual)
                Dim r As DataTable = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_RevertirTareo", p, TipoQuery.DataTable)
                If r.Rows(0).Item("Resultado") = 1 Then
                    listarDetalleAsync()
                    MessageBox.Show(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
                ElseIf r.Rows(0).Item("Resultado") = 0 Then
                    Throw New Exception(r.Rows(0).Item("Id") & ": " & r.Rows(0).Item("Detalle"))
                End If
            Else
                Throw New Exception("El tareo no puede ser revertido porque no esta generado.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarTablaValidada()
        Dim datoValido As Boolean
        Dim observaciones As String = String.Empty
        'esta lista continen las columnas del excel que se van a evaluar
        Dim listaColumnasAValidar As New Dictionary(Of Integer, Integer)
        listaColumnasAValidar.Add(1, 1)
        listaColumnasAValidar.Add(2, 2)
        listaColumnasAValidar.Add(3, 3)
        listaColumnasAValidar.Add(4, 4)
        listaColumnasAValidar.Add(5, 5)
        listaColumnasAValidar.Add(6, 6)
        listaColumnasAValidar.Add(7, 7)
        listaColumnasAValidar.Add(8, 8)
        listaColumnasAValidar.Add(9, 9)
        dgvResultado.DataSource = dtTablaExcel
        For i As Integer = 0 To dgvResultado.RowCount - 1 Step 1
            datoValido = False
            For j As Integer = 0 To dgvResultado.ColumnCount - 1 Step 1
                If listaColumnasAValidar.ContainsKey(j + 1) Then
                    For k As Integer = 0 To dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows.Count - 1 Step 1
                        Try
                            If dtTablaExcel.Rows(i).Item(j) = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(k).Item(0) Then
                                datoValido = True
                                Exit For
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message & "-" & dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(0).Item(1))
                        End Try
                    Next
                    If Not datoValido Then
                        dgvResultado.Rows(i).Cells(j).Style.BackColor = rosaBlanco_
                        observaciones = "Corregir"
                    Else
                        dgvResultado.Rows(i).Cells(j + 1).Value = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Compute("MAX(Descripcion)", "T_Id = '" + dtTablaExcel.Rows(i).Item(j) + "'")
                    End If
                    datoValido = False
                End If
            Next
            If observaciones = "Corregir" Then
                dgvResultado.Rows(i).Cells(14).Style.BackColor = rosaBlanco_
                dgvResultado.Rows(i).Cells(14).Value = observaciones
            Else
                dgvResultado.Rows(i).Cells(14).Style.BackColor = verderCian_
                dgvResultado.Rows(i).Cells(14).Value = "Listo!"
            End If
            observaciones = String.Empty
        Next
        dgvResultado.ClearSelection()
    End Sub

End Class