'PENDIENTE: EMPEZAR A USAR OBJETOS BINDINGS SOURCES PARA ENLAZAR LOS DATAGRIDVIES, EN LUGAR DE ENLAZARLOS DIRECTAMENTE CON UN DATATABLE

Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_AsistenciaGmo
    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet = New DataSet
    Dim idTareoConsolidado As String = String.Empty
    Dim idTgTareo As String = String.Empty
    Dim idTareoHoras As String = String.Empty
    Dim idTareoRendimientos As String = String.Empty
    Dim filaActual As Integer = -1

    Private Sub frmRrhh_Movimientos_AsistenciaGmo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'obtenerDataParaCombos()
        'cargarCombo(cboEtapa, dsDataParaCombo.Tables(0), "", False)
        'cargarCombo(cboDivision, dsDataParaCombo.Tables(1), "", False)
        'cargarCombo(cboParron, dsDataParaCombo, "", True)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvT1.DataSource = Nothing
        dgvT1.Columns.Clear()
        dgvT2.DataSource = Nothing
        dgvT2.Columns.Clear()
        dgvT3.DataSource = Nothing
        dgvT3.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())

        dgvT1.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvT2.DataSource = Await Task.FromResult(aux.Tables(1))
        dgvT3.DataSource = Await Task.FromResult(aux.Tables(2))

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

        corregirCeldas(dgvT1)
        corregirCeldas(dgvT2)
        corregirCeldas(dgvT3)

        formatearDataGridView(dgvT1)
        formatearDataGridView(dgvT2)
        formatearDataGridView(dgvT3)
        dgvT3.ClearSelection()
        If filaActual > -1 And dgvT3.Rows.Count > filaActual Then
            dgvT3.Rows(filaActual).Selected = True
        End If
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@Dia", dtpFecha.Value)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_AsistenciaGmo_ObenerResultados", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvT1.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("T1", dgvT1)
        '    dDgvs.Add("T2", dgvT2)
        '    dDgvs.Add("T3", dgvT3)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        Try
            If dgvT1.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Resumen")
                l.Add("TotalDisponibles")
                l.Add("TotalConsolidados")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvT1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvT1.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
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

    Private Sub dgvT2_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvT2.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
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

    Private Sub dgvT3_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvT3.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
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

    Private Async Sub btnConsolidar_Click(sender As Object, e As EventArgs) Handles btnConsolidar.Click
        Try
            'MOdificacion validacion Dia
            'VALIDAR SI EL DIA ESTA ABIERTO
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Modulo", "Supervision")
            'p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
            p.Add("Dia", dgvT2.Rows(1).Cells(1).Value)

            'Luis Benitez pidio que se quite la validacion
            'If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            '    MessageBox.Show("No se pueden crear tareos para el dia seleccionado porque se encuentra cerrado para DataGreen en la fecha: " + dgvT2.Rows(1).Cells(1).Value)
            '    Exit Sub
            'End If

            Dim r As DialogResult
            r = MessageBox.Show("Seguro que desea consolidar los tareos marcados como aprobados?", "Consolidar Tareos", MessageBoxButtons.YesNo)
            If r = Windows.Forms.DialogResult.Yes Then
                encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                Dim aux As DataTable
                aux = Await Task.Run(Function() consolidarAsync())
                If aux.Rows(0).Item(0) = "Ok" Then
                    'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
                    btnConsultar_Click(New Object, New EventArgs)
                    MessageBox.Show("Los tareos se han consolidado correctamente.")
                End If
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End Try
    End Sub

    Private Async Function consolidarAsync() As Task(Of DataTable)
        Try
            Dim r As New DataTable
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@Dia", dtpFecha.Value)
            p.Add("@Usuario", usuarioActual)
            'arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_AsistenciaGmo_ConsolidarTareos", p, TipoQuery.DataTable))
            If r.Rows(0).Item(0) <> "Ok" Then
                Throw New Exception(r.Rows(0).Item(0))
            End If
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnRevertir_Click(sender As Object, e As EventArgs) Handles btnRevertir.Click
        'Dim idTareoCons As String=
        Try
            If idTareoConsolidado.Length > 0 Then
                Dim r As DialogResult
                r = MessageBox.Show("¿Seguro que desea revertir el tareo consolidado: " & idTareoConsolidado & "?", "Revertir Tareos", MessageBoxButtons.YesNo)
                If r = Windows.Forms.DialogResult.Yes Then
                    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                    Dim aux As DataTable
                    aux = Await Task.Run(Function() revertirAsync())
                    If aux.Rows(0).Item(0) = "Ok" Then
                        'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
                        btnConsultar_Click(New Object, New EventArgs)
                        MessageBox.Show("El tareo consolidado: " & idTareoConsolidado & " se ha revertido correctamente")
                    End If
                End If
            Else
                MessageBox.Show("Debe de seleccionar un tareo consolidado.")
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End Try
    End Sub

    Private Async Function revertirAsync() As Task(Of DataTable)
        Try
            Dim r As New DataTable
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@IdTareoCons", idTareoConsolidado)
            'arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_AsistenciaGmo_RevertirConsolidacion", p, TipoQuery.DataTable))
            If r.Rows(0).Item(0) <> "Ok" Then
                Throw New Exception(r.Rows(0).Item(0))
            End If
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvT3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvT3.CellContentClick
        If e.RowIndex >= 0 Then
            idTareoConsolidado = dgvT3.Rows(e.RowIndex).Cells("T_IdConsolidado").Value
            idTgTareo = dgvT3.Rows(e.RowIndex).Cells("T_IdRegistroNisira").Value
            idTareoHoras = dgvT3.Rows(e.RowIndex).Cells("T_IdAsistenciaHoras").Value
            idTareoRendimientos = dgvT3.Rows(e.RowIndex).Cells("T_IdAsistenciaRendimiento").Value
            filaActual = e.RowIndex
        End If
    End Sub

    Private Sub dgvT3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvT3.CellClick
        If e.RowIndex >= 0 Then
            idTareoConsolidado = dgvT3.Rows(e.RowIndex).Cells("T_IdConsolidado").Value
            idTgTareo = dgvT3.Rows(e.RowIndex).Cells("T_IdRegistroNisira").Value
            idTareoHoras = dgvT3.Rows(e.RowIndex).Cells("T_IdAsistenciaHoras").Value
            idTareoRendimientos = dgvT3.Rows(e.RowIndex).Cells("T_IdAsistenciaRendimiento").Value
            filaActual = e.RowIndex
        End If
    End Sub

    Private Async Sub btnRegistrarAsistencia_Click(sender As Object, e As EventArgs) Handles btnRegistrarAsistencia.Click
        Try


            If idTareoConsolidado.Length > 0 And idTgTareo = "" Then

                'Cambiar a funcion nueva
                'VALIDAR SI EL DIA ESTA ABIERTO
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Modulo", "CIERRE_PLANILLA")
                'p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
                p.Add("Dia", dgvT3.Rows(1).Cells(1).Value)
                If doItBaby("sp_Dg_ConsultarEstadoDia_Nisira", p, TipoQuery.Scalar) = 1 Then
                    MessageBox.Show("No se pueden crear tareos para el dia seleccionado porque se encuentra cerrado para Nisira en la fecha: " + dgvT2.Rows(1).Cells(1).Value)
                    Exit Sub
                End If


                Dim r As DialogResult
                r = MessageBox.Show("¿Seguro que desea registrar en Nisira el tareo consolidado: " & idTareoConsolidado & "?", "Registrar en Nisira", MessageBoxButtons.YesNo)
                If r = Windows.Forms.DialogResult.Yes Then
                    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                    Dim aux As DataTable
                    aux = Await Task.Run(Function() registrarAsistenciaAsync())
                    If aux.Rows(0).Item(0) = "Ok" Then
                        'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
                        btnConsultar_Click(New Object, New EventArgs)
                        MessageBox.Show("El tareo consolidado: " & idTareoConsolidado & " se ha registrado en Nisira correctamente")
                        idTgTareo = dgvT3.Rows(filaActual).Cells("T_IdRegistroNisira").Value
                    End If
                End If
            ElseIf idTgTareo <> "" Then
                MessageBox.Show("El tareo seleccionado " & idTareoConsolidado & " ya ha sido registrado en Nisira.")
            Else
                MessageBox.Show("Debe de seleccionar un tareo consolidado.")
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End Try
    End Sub

    Private Async Function registrarAsistenciaAsync() As Task(Of DataTable)
        Try
            Dim r As New DataTable
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@IdTareoCons", idTareoConsolidado)
            p.Add("@IdUsuario", usuarioActual)
            p.Add("@Host", String.Concat(Environment.MachineName, " / ", getMac))
            'arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_AsistenciaGmo_RegistrarAsistencia", p, TipoQuery.DataTable))
            If r.Rows(0).Item(0) <> "Ok" Then
                Throw New Exception(r.Rows(0).Item(0))
            End If
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnGenerarAsistencia_Click(sender As Object, e As EventArgs) Handles btnGenerarAsistencia.Click
        Try

            Clipboard.SetText(idTgTareo)
            If idTareoConsolidado.Length > 0 And idTgTareo.Length > 0 And idTareoHoras = "" And idTareoRendimientos = "" Then

                'cambiar a funcion nueva
                'VALIDAR SI EL DIA ESTA ABIERTO
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Modulo", "CIERRE_PLANILLA")
                ' p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
                p.Add("Dia", dgvT3.Rows(1).Cells(1).Value)
                If doItBaby("sp_Dg_ConsultarEstadoDia_Nisira", p, TipoQuery.Scalar) = 1 Then
                    MessageBox.Show("No se pueden crear tareos para el dia seleccionado porque se encuentra cerrado para Nisira en la fecha: " + dgvT2.Rows(1).Cells(1).Value)
                    Exit Sub
                End If


                Dim r As DialogResult
                r = MessageBox.Show("¿Seguro que desea generar en Nisira el tareo consolidado: " & idTareoConsolidado & "?", "Generar Asistencia en Nisira", MessageBoxButtons.YesNo)
                If r = Windows.Forms.DialogResult.Yes Then
                    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                    Dim aux As DataTable
                    aux = Await Task.Run(Function() generarAsistenciaAsync())
                    If aux IsNot Nothing AndAlso aux.Rows(0).Item(0) = "OK" Then
                        'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
                        btnConsultar_Click(New Object, New EventArgs)
                        MessageBox.Show("El tareo consolidado: " & idTareoConsolidado & " ha generado un registro de asistencia en Nisira correctamente")
                    End If
                End If
            ElseIf idTareoHoras <> "" Or idTareoRendimientos <> "" Then
                MessageBox.Show("El tareo seleccionado: " & idTareoConsolidado & " ya ha generado las siguientes asistencias:" & idTareoHoras & " " & idTareoRendimientos)
            ElseIf idTareoConsolidado.Length > 0 And idTgTareo.Length <= 0 Then
                MessageBox.Show("Debe REGISTRAR el tareo en nisira antes de generar la asistencia.")
            Else
                MessageBox.Show("Debe de seleccionar un tareo consolidado.")
            End If

        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End Try
    End Sub

    Private Async Function generarAsistenciaAsync() As Task(Of DataTable)

        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@__idempresa", "001")
            p.Add("@__id_tareo", idTgTareo)

            'arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("AgricolaSanJuan_2020.dbo.generarasistencia_bytareo", p, TipoQuery.DataSet))
            If r.Tables(0).Rows(0).Item(0) <> "OK" Then
                Throw New Exception(r.Tables(0).Rows(0).Item(0))
            End If
            Return r.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function

    Private Function consultarEstadoDia(dia As Date) As Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Rrhh")
        p.Add("@Dia", dia)
        'If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
        '    'MessageBox.Show("No se pueden crear tareos para el dia seleccionado porque se encuentra cerrado.")

        'End If
        Return CType(doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar), Boolean)
    End Function

End Class