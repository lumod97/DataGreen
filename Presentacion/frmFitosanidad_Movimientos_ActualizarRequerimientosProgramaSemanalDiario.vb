Imports Logica.Utiles
Imports Datos.Conexion

Public Class frmFitosanidad_Movimientos_ActualizarRequerimientosProgramaSemanalDiario

    Private Sub frmFitosanidad_Movimientos_ActualizarRequerimientosProgramaSemanalDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        calDia.SelectionRange.Start = DateAdd(DateInterval.Day, -1, calDia.SelectionRange.Start)
        aplicarTema(Me)
    End Sub


    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        'Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        'dgvResultado.DataSource = Nothing
        'tablaResultado = Nothing
        'dgvResultado.Columns.Clear()
        Dim ok As Boolean = False
        Dim dgv As Task(Of Boolean)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        ok = Await dgv
        'dgvResultado.DataSource = Await dgv
        'tablaResultado = Await dgv
        'corregirTabla(tablaResultado)
        'dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado)
        If ok Then
            lblDin_Resultado.Text = "Correcto."
        Else
            lblDin_Resultado.Text = "Error."
        End If
        'corregirCeldas(dgvResultado)
        'formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of Boolean)
        Try
            Dim aux As New Boolean
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", calDia.SelectionRange.Start)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Fitosanidad_Movimientos_ActualizarRequerimientosProgramaSemanalDiario", p, TipoQuery.NonQuery))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function


End Class