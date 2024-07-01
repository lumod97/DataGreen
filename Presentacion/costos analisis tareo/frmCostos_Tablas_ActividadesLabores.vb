Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmCostos_Tablas_ActividadesLabores
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet

    Private Sub frmCostos_Tablas_ActividadesLabores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        tlpPrincipal.Visible = True
        'radPlanilla.Checked = True
        aplicarTema(Me)
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Sub btnConsultardatos_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub
    Public Function extraerIdDeCampo(campo As String) As String
        If campo.Length > 0 Then
            Dim resultado As String = ""
            resultado = Trim(campo.Substring(0, InStr(campo, "|", CompareMethod.Text) - 1))
            Return resultado
        Else
            Return ""
        End If
    End Function
    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", CType(dtpDesde.Value.ToString("yyyy-MM-dd"), Date))
            p.Add("@Hasta", CType(dtpHasta.Value.ToString("yyyy-MM-dd"), Date))
            p.Add("@IdPlanilla", extraerIdDeCampo(cboPlanilla.Text))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Costos_Reportes_AnalisisTareos", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
            dgvResultado.ClearSelection()
        End If
    End Sub

End Class