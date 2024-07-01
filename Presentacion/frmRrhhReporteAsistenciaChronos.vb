Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhhReporteAsistenciaChronos

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombos As DataSet

    Private Sub frmRrhhReporteAsistenciaChronos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombosTerminales()
        cargarCombo(cboTerminales, dsDataParaCombos.Tables(0), "", True)
        obtenerDataParaCombosPlanilla()
        cargarCombo(cboPlanilla, dsDataParaCombos.Tables(0), 0, 2)
        aplicarTema(Me)
        'If Not (usuarioActual = "JMERA" Or usuarioActual = "AROJAS" Or usuarioActual = "JDELVALLE" Or usuarioActual = "JSUYON") Then
        '    radRepExtendido.Enabled = False
        '    radRepStandard.Enabled = False
        'End If
    End Sub

    Private Sub obtenerDataParaCombosTerminales()
        dsDataParaCombos = New DataSet
        dsDataParaCombos.Tables.Add(doItBaby("sp_Dg_ObtenerTerminales", Nothing, TipoQuery.DataTable))
        soloClavesUnicas(dsDataParaCombos.Tables(0))
    End Sub

    Private Sub obtenerDataParaCombosPlanilla()
        dsDataParaCombos = New DataSet
        dsDataParaCombos.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        soloClavesUnicas(dsDataParaCombos.Tables(0))
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        btnConsultar.Enabled = False
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)

        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)

        'corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
        btnConsultar.Enabled = True
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            'SE REALIZA LA CONSULTA DE LOS REFRIGERIOS
            If radRefrigerio.Checked Then
                p.Add("@Dia", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
                p.Add("@Usuario", usuarioActual)
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_RefrigeriosDelPersonal", p, TipoQuery.DataTable))
            ElseIf Not radPaking.Checked Then
                p.Add("@Desde", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
                p.Add("@Hasta", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
                p.Add("@Tipo", IIf(radRepStandard.Checked, "DH", "RE"))
                p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
                p.Add("@CodEmpleado", txtCodigo.Text)
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("sp_Cns_ReporteAsistencia", p, TipoQuery.DataTable))
            ElseIf radPaking.Checked Then
                p.Add("@Fecha", CType(pkrDesde.Value.ToString("dd/MM/yyyy"), DateTime))
                p.Add("@IdTerminal", cboTerminales.SelectedValue)
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("Sp_Dg_Rrhh_Reportes_AsistenciaChronosPacking", p, TipoQuery.DataTable))
            End If
            corregirTabla(aux)
            tablaResultado = aux
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

    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs)
        Try
            If dgvResultado.RowCount > 0 Then
                Dim siOno As DialogResult
                siOno = MessageBox.Show("Seguro desea procesar las marcaciones del dia seleccionado hacia Nisira?", "Procesar Marcas a Nisira", MessageBoxButtons.YesNo)
                If siOno = Windows.Forms.DialogResult.Yes Then
                    Dim rAsync As Task(Of DataTable)
                    Dim r As DataTable
                    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                    rAsync = procesarAsync()
                    'dgvResultado.DataSource = Await r
                    r = Await rAsync
                    apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
                    'If Await rAsync.Result.Rows(0).Item(0) = "1" Then
                    If r.Rows(0).Item(0) = "1" Then
                        MessageBox.Show("Marcas Procesadas con exito.")
                    Else
                        MessageBox.Show("Error: " & rAsync.Result.Rows(0).Item(1).ToString)
                    End If
                End If
            Else
                MessageBox.Show("No hay filas para procesar.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function procesarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDesde.Value)
            p.Add("@Usuario", usuarioActual)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Cns_ProcesarAsistenciaANisira", p, TipoQuery.DataTable))
            'corregirTabla(aux)
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Function consultarAsyncRefrigerios() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDesde.Value)
            p.Add("@Usuario", usuarioActual)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_RefrigeriosDelPersonal", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function


    Private Sub radPaking_CheckedChanged(sender As Object, e As EventArgs) Handles radPaking.CheckedChanged
        '    If radPaking.Checked Then
        '        cboTerminales.Enabled = True
        '        radRepExtendido.Enabled = False
        '        radRepStandard.Enabled = False
        '    End If
    End Sub

    Private Async Sub btnRefrigerios_Click(sender As Object, e As EventArgs)

        btnConsultar.Enabled = False
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)

        dgv = consultarAsyncRefrigerios()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        'corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
        btnConsultar.Enabled = True
    End Sub
End Class