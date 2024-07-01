Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmContabilidad_Movimientos_Maquinaria_ActualizarConfiguraciones
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet

    Private Sub frmContabilidad_Procecos_Maquinaria_ActualizarConfiguraciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        'Me.WindowState = FormWindowState.Maximized
        'Me.StartPosition = FormStartPosition.CenterParent
        obtenerDataParaCombos()
        cargarCombo(cboBaseDatos, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboCampana, dsDataParaCombo.Tables(1), "", False)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim p As New Dictionary(Of String, Object)
        p.Add("@MostrarOpcionTodos", 0)
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerBasesDatos", p, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanas", p, TipoQuery.DataTable))
    End Sub

    Private Sub cboCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCampana.SelectionChangeCommitted
        For i As Integer = 2 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboCampana.SelectedValue)
        p.Add("@MostrarOpcionTodos", 0)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPeriodosXAnioCampana", p, TipoQuery.DataTable))
        cargarCombo(cboPeriodo, dsDataParaCombo.Tables(2), "", True)
    End Sub

    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@BaseDatos", cboBaseDatos.SelectedValue)
            p.Add("@Columna", "CIERRE_CONTABLE")
            p.Add("@Periodo", cboPeriodo.SelectedValue)
            Dim estadoPeriodo As String = doItBaby("sp_Dg_ConsultarEstadoPeriodo", p, TipoQuery.Scalar)
            If estadoPeriodo = "1" Then
                Dim res As String
                Dim r As Task(Of String)
                encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                r = procesarAsync()
                res = Await r
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, 0)
                If res = "Ok" Then
                    MessageBox.Show("Proceso realizado con exito.")
                Else
                    MessageBox.Show(res)
                End If
            ElseIf estadoPeriodo = "0" Then
                MessageBox.Show("El periodo se encuentra cerrado, imposible procesar.")
                Exit Sub
            Else
                MessageBox.Show(estadoPeriodo)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Async Function procesarAsync() As Task(Of String)
        Try
            Dim aux As String
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo", cboPeriodo.SelectedValue)
            p.Add("@Base_N", cboBaseDatos.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Contabilidad_Procecos_Maquinaria_ActualizarConfiguraciones", p, TipoQuery.Scalar))
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

    'Private Sub dgvDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
    '    'MessageBox.Show("Error happened " & e.Context.ToString())
    '    If (e.Context = DataGridViewDataErrorContexts.Commit) Then
    '        'MessageBox.Show("Commit error")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
    '        MessageBox.Show("Cell change")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
    '        MessageBox.Show("parsing error")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
    '        MessageBox.Show("leave control error")
    '    End If
    '    If (TypeOf (e.Exception) Is ConstraintException) Then
    '        Dim view As DataGridView = CType(sender, DataGridView)
    '        view.Rows(e.RowIndex).ErrorText = "an error"
    '        view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
    '        e.ThrowException = False
    '    End If
    'End Sub
End Class