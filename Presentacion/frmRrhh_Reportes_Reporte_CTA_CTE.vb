Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Public Class frmRrhh_Reportes_Reporte_CTA_CTE
    Dim arrayDeParametros As String = String.Empty
    Dim dtResultado As DataTable
    Dim dsParaCombos As DataSet = New DataSet
    Dim datosParaCombos As New Dictionary(Of String, DataTable)
    Dim bsFiltro As New BindingSource()

    Private Sub frmRrhh_Reportes_Reporte_CTA_CTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        'cargarCombo(cboPlanilla, dsParaCombos.Tables(0), "", True)
        'cargarCombo(cboMoneda, dsParaCombos.Tables(1), "", True)
        cargarCombo(cboPlanilla, datosParaCombos("Planillas"), 0, 2)
        cargarCombo(cboMoneda, datosParaCombos("Monedas"), 0, 2)
        cargarCombo(cboAmbito, datosParaCombos("Ambito"), 0, 2)
        ' cargarCombo(cboPeriodoDesde, datosParaCombos("PeriodoDesde"), 0, 1)
        ' cargarCombo(cboPeriodoHasta, datosParaCombos("PeriodoHasta"), 0, 1)
        ' cargarCombo(cboPeriodoDesde, dsParaCombos.Tables(4), "", True)
        ' cargarCombo(cboPeriodoHasta, dsParaCombos.Tables(5), "", True)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        datosParaCombos.Add("Planillas", doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Monedas", doItBaby("sp_ObtenerMonedas_CTA_CTE", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Ambito", doItBaby("datagreentest..sp_ObtenerAmbito", Nothing, TipoQuery.DataTable))
        '  datosParaCombos.Add("PeriodoDesde", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
        '  datosParaCombos.Add("PeriodoHasta", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dtResultado = Await dgv
        corregirTabla(dtResultado)
        dgvResultado.DataSource = dtResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@IdTrabajador", txtTrabajador.Text)
            p.Add("@IdMoneda", cboMoneda.SelectedValue)
            p.Add("@IdAmbito", cboAmbito.SelectedValue)
            p.Add("@IdPresentacion", cboMoneda.SelectedValue)
            'p.Add("@periodoDesde", cboPeriodoDesde.SelectedValue)
            'p.Add("@periodoHasta", cboPeriodoHasta.SelectedValue)
            p.Add("@periodoDesde", txtPeriodoDesde.Text)
            p.Add("@periodoHasta", txtPeriodoHasta.Text)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("DataGreenTest..sp_Dg_Rrhh_Reporte_CTA_CTE", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class