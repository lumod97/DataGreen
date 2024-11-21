Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmMantenimiento_ConfiguracionLongitudCodigoGeneral
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet

    Dim idParametro As String = "LONCODTRAB"
    Dim dtResultado As DataTable = New DataTable()
    Dim valorActualParametro As String = ""

    Private Sub frmRrhh_Movimientos_ConfiguracionLongitudCodigoGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        obtenerDataParaCombos()
        cargarCombo(cboLongitudCodigoGeneral, dsDataParaCombo.Tables(0), 0, 2)
        obtenerValorActualDeParametro(idParametro)
        cboLongitudCodigoGeneral.SelectedValue = IIf(valorActualParametro.Length > 0, valorActualParametro, "")
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerValorActualDeParametro(idParametro As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdParametro", idParametro)
        dtResultado = doItBaby("sp_Dg_ObtenerValorParametroNisira", p, TipoQuery.DataTable)
        If dtResultado.Rows.Item(0).Item("Resultado").ToString.Equals("0") Then
            MessageBox.Show(dtResultado.Rows.Item(0).Item("Detalle").ToString)
            Exit Sub
        End If
        valorActualParametro = dtResultado.Rows.Item(0).Item("Id").ToString
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Gen_ObtenerOpcionesLogitudCodigoGeneral", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdParametro", idParametro)
        p.Add("@Valor", cboLongitudCodigoGeneral.SelectedValue)
        dtResultado = doItBaby("sp_Dg_GuardarValorParametroNisira", p, TipoQuery.DataTable)
        MessageBox.Show(dtResultado.Rows.Item(0).Item("Detalle").ToString)
        If Me.MdiParent IsNot Nothing Then
            Dim mdiPrincipal As mdiPrincipal = CType(Me.MdiParent, mdiPrincipal)
            mdiPrincipal.stdEstado.Text = "Usuario: " + usuarioActual + "           -         Parámetro Codigo General: " + obtenerParametroLongitud()
        End If
    End Sub
End Class