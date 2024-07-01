
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen

    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet = New DataSet
    Dim idTareoConsolidado As String = String.Empty
    Dim idTgTareo As String = String.Empty
    Dim idTareoHoras As String = String.Empty
    Dim idTareoRendimientos As String = String.Empty
    Dim filaActual As Integer = -1

    Private Sub frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_AsistenciaDataGreenMiniGreen_ObenerResultados", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

End Class