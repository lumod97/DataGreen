Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPacking_Reportes_AlcanceEstandares

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

    Private Sub frmPacking_Reportes_AlcanceEstandares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
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
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            If radAlcanceEstandares.Checked Then
                p.Add("@Desde", CType(dtpFecha.Value.ToString("yyyy-MM-dd"), DateTime))
                p.Add("@Hasta", CType(dtpFecha.Value.ToString("yyyy-MM-dd"), DateTime))
                p.Add("@TipoResultado", "T")
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Reportes_AlcanceEstandares", p, TipoQuery.DataTable))
            ElseIf radDistribucionHoras.Checked Then
                p.Add("@Dia", CType(dtpFecha.Value.ToString("yyyy-MM-dd"), DateTime))
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_DistribuirHoras", p, TipoQuery.DataTable))
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


    Private Sub btnConvertirTareos_Click(sender As Object, e As EventArgs) Handles btnConvertirTareos.Click

        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para Convertir Tareos")
        Else
            Dim rpta As DialogResult
            Dim s As String = "Desea convertir las eficiencias del dia " & dtpFecha.Value.ToString("yyyy-MM-dd")
            rpta = MessageBox.Show(s, "Convertir en Tareo", MessageBoxButtons.YesNo)
            If rpta = DialogResult.Yes Then
                Dim p As New Dictionary(Of String, Object)
                Dim r As DataTable
                Try
                    p.Add("@Dia", CType(dtpFecha.Value.ToString("yyyy-MM-dd"), DateTime))
                    p.Add("@IdUsuario", usuarioActual)
                    r = doItBaby("sp_Dg_Packing_Reportes_AlcanceEstandares_ConvertirATareo", p, TipoQuery.DataTable)
                    If r.Rows(0).Item(0).ToString.Equals("1") Then
                        MessageBox.Show(r.Rows(0).Item(1).ToString)
                    Else
                        MessageBox.Show(r.Rows(0).Item(1).ToString)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
End Class
