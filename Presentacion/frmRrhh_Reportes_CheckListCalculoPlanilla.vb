Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Public Class frmRrhh_Reportes_CheckListCalculoPlanilla
    Private Sub frmCheckListCalculoPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized


        aplicarTema(Me)
        tlpPrincipal.Visible = True
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
    End Sub
    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            'Insertar codigo


            aux = Await Task.Run(Function() doItBaby("", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub
End Class