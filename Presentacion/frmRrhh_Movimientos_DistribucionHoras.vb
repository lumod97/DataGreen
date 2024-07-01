Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales


Public Class frmRrhh_Movimientos_DistribucionHoras
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet

    Private Sub frmRrhh_Movimientos_DistribucionHoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        'Me.WindowState = FormWindowState.Maximized
        'Me.StartPosition = FormStartPosition.CenterParent
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataTable
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function procesarAsync() As Task(Of String)
        Try
            Dim aux As String
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@Desde", CType(pkrDesde.Value.ToString("yyyy/MM/dd"), String))
            p.Add("@Hasta", CType(pkrHasta.Value.ToString("yyyy/MM/dd"), String))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_DistribuirHoras_NuevoAlgoritmo", p, TipoQuery.Scalar))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

End Class