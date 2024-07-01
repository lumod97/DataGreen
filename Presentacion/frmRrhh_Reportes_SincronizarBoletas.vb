Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion
Imports DocumentFormat.OpenXml.Wordprocessing
Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml.Drawing.Charts
Imports System.Globalization
Imports System.Net.WebRequestMethods

Public Class frmRrhh_Reportes_SincronizarBoletas
    Dim dsMetaDatosPlanilla As New DataSet
    Dim dsMetaDatosMes1 As New DataSet
    Dim dsMetaDatosPeriodo1 As New DataSet
    Dim dsMetaDatosMes2 As New DataSet
    Dim dsMetaDatosPeriodo2 As New DataSet
    Dim dsMetaDatosSemana1 As New DataSet
    Dim dsMetaDatosSemana2 As New DataSet
    Dim dsMetaDatosInicioSemana As New DataSet
    Dim dsMetaDatosFinSemana As New DataSet
    Dim dsTipoPlanilla As New DataSet
    Dim dtTablaExcel As New DataTable
    Dim dsLabel1 As New DataSet
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmRrhh_Reportes_SincronizarBoletas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerMetaDatos()
        cargarCombo(CboPlanilla, dsMetaDatosPlanilla.Tables(0), "", False)
        cargarCombo(CboMes1, dsMetaDatosMes1.Tables(0), "", False)
        cargarCombo(CboMes2, dsMetaDatosMes2.Tables(0), "", False)
        cargarCombo(CboPeriodo1, dsMetaDatosPeriodo1.Tables(0), "", False)
        cargarCombo(CboPeriodo2, dsMetaDatosPeriodo2.Tables(0), "", False)
        cargarCombo(CboTipoPlanilla, dsTipoPlanilla.Tables(0), "", False)
        aplicarTema(Me)
    End Sub
    Private Sub obtenerMetaDatos()
        dsMetaDatosPlanilla = doItBaby("Sp_Dg_ObtenerPlanilla", Nothing, TipoQuery.DataSet)
        dsMetaDatosMes1 = doItBaby("Sp_Dg_ObtenerMeses", Nothing, TipoQuery.DataSet)
        dsMetaDatosMes2 = doItBaby("Sp_Dg_ObtenerMeses", Nothing, TipoQuery.DataSet)
        dsMetaDatosPeriodo1 = doItBaby("Sp_Dg_ObtenerPeriodo", Nothing, TipoQuery.DataSet)
        dsMetaDatosPeriodo2 = doItBaby("Sp_Dg_ObtenerPeriodo", Nothing, TipoQuery.DataSet)
        dsTipoPlanilla = doItBaby("sp_ObtenerTipoPlanillaSincronizacionBoletas", Nothing, TipoQuery.DataSet)
    End Sub
    Private Sub CboPeriodo1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboPeriodo1.SelectionChangeCommitted
        obtenerSemanas("1")
    End Sub
    Private Sub CboMes1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboMes1.SelectionChangeCommitted
        obtenerSemanas("1")
    End Sub
    Private Sub CboPeriodo2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboPeriodo2.SelectionChangeCommitted
        obtenerSemanas("2")
    End Sub
    Private Sub CboMes2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboMes2.SelectionChangeCommitted
        obtenerSemanas("2")
    End Sub
    Private Sub CboSemana2_SelectionChangeCommited(sender As Object, e As EventArgs) Handles CboSemana2.SelectionChangeCommitted
        'Dim fechaFinal As String
    End Sub
    Private Sub obtenerSemanas(rowSelected As String)
        Dim p As New Dictionary(Of String, Object)
        If (CboPeriodo1.IsDisposed) Then
        Else
            If (rowSelected.Equals("1")) Then
                p.Add("@Periodo", CboPeriodo1.SelectedValue.ToString + "" + CboMes1.SelectedValue.ToString)
                dsMetaDatosSemana1 = doItBaby("Sp_Dg_ObtenerSemanas", p, TipoQuery.DataSet)
                ''MsgBox(CboPeriodo1.SelectedValue.ToString + "" + CboMes1.SelectedValue.ToString)
                cargarCombo(CboSemana1, dsMetaDatosSemana1.Tables(0), "", False)
            ElseIf (rowSelected.Equals("2")) Then
                p.Add("@Periodo", CboPeriodo2.SelectedValue.ToString + "" + CboMes2.SelectedValue.ToString)
                dsMetaDatosSemana2 = doItBaby("Sp_Dg_ObtenerSemanas", p, TipoQuery.DataSet)
                ''MsgBox(CboPeriodo2.SelectedValue.ToString + "" + CboMes2.SelectedValue.ToString)
                cargarCombo(CboSemana2, dsMetaDatosSemana2.Tables(0), "", False)
            End If
        End If
        p.Clear()
    End Sub
    Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        Dim semanaDesde, semanaHasta As String
        If (CboTipoPlanilla.SelectedValue <> "PAS") Then
            semanaDesde = ""
            semanaHasta = ""
        Else
            semanaDesde = CboSemana1.SelectedValue
            semanaHasta = CboSemana2.SelectedValue
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@pbpp_id_empresa", "001")
        p.Add("@pbpp_id_planilla", CboPlanilla.SelectedValue)
        p.Add("@pbpp_id_tipo_planilla", CboTipoPlanilla.SelectedValue)
        p.Add("@pbpp_periodo_desde", CboPeriodo1.SelectedValue.ToString + "" + CboMes1.SelectedValue.ToString)
        p.Add("@pbpp_semana_desde", semanaDesde)
        p.Add("@pbpp_periodo_hasta", CboPeriodo2.SelectedValue.ToString + "" + CboMes2.SelectedValue.ToString)
        p.Add("@pbpp_semana_hasta", semanaHasta)
        p.Add("@pdssj_fecha_desde", LblInicio.Text)
        p.Add("@pdssj_fecha_hasta", LblFinal.Text)
        doItBaby("sp_SincronizarBoletasPago", p, TipoQuery.DataSet)
        MessageBox.Show(CboSemana1.SelectedValue)
    End Sub
    Private Sub CboPlanilla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPlanilla.SelectedIndexChanged
        If (CboPlanilla.SelectedValue <> "PAS") Then
            CboSemana1.Visible = False
            CboSemana2.Visible = False
            LblSemana1.Visible = False
            LblSemana2.Visible = False
        Else
            CboSemana1.Visible = True
            CboSemana2.Visible = True
            LblSemana1.Visible = True
            LblSemana2.Visible = True
        End If
    End Sub
    Private Function consultarLabel() As DataSet
        Dim p As New Dictionary(Of String, Object)

        Dim semanaDesde, semanaHasta As String
        If (CboPlanilla.SelectedValue <> "PAS") Then
            semanaDesde = ""
            semanaHasta = ""
        Else
            semanaDesde = CboSemana1.SelectedValue
            semanaHasta = CboSemana2.SelectedValue
        End If
        p.Add("@Periodo1", CboPeriodo1.SelectedValue.ToString + "" + CboMes1.SelectedValue.ToString)
        p.Add("@Semana1", semanaDesde)
        p.Add("@Periodo2", CboPeriodo2.SelectedValue.ToString + "" + CboMes2.SelectedValue.ToString)
        p.Add("@Semana2", semanaHasta)
        Dim Resultado As DataSet
        Resultado = doItBaby("Sp_Dg_ObtenerFechasEnLabel", p, TipoQuery.DataSet)
        Return Resultado
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As New DataSet
        usuario = consultarLabel()
        LblInicio.Text = usuario.Tables(0).Rows(0).Item(0)
        LblFinal.Text = usuario.Tables(0).Rows(0).Item(1)
        'Dim dtFecha As DateTime = DateTime.Now
        'Dim valor As Date
        'valor = dtFecha.ToString("yyyy-MM-dd")
        'MsgBox(valor)
    End Sub
End Class