Imports Entidades
Imports Logica.Utiles
Imports Datos.Conexion


Public Class frmPacking_Movimientos_LecturaEficiencias_NuevoPallet
    'Dim dtVariedades As DataTable = Nothing
    Dim padre As frmPacking_Movimientos_LecturaEficiencias

    'Dim IdCultivoVariedadPacking As String = String.Empty

    Public Sub New(ByRef form As frmPacking_Movimientos_LecturaEficiencias)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        padre = form
        'cargarControles(padre.dsParaControles)
        'dtVariedades = tablas.Tables(2).Copy
    End Sub

    Private Sub frmPacking_Movimientos_LecturaEficiencias_NuevoPallet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTemaExagerado(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        cargarControles(padre.dsParaControles)
    End Sub

    Private Sub cargarControles(tablas As DataSet)
        Dim aux As DataTable
        aux = doItBaby("sp_ObtenerLineasPacking", Nothing, TipoQuery.DataTable)
        cargarCombo(cboLinea, aux.Copy, "", True)
        aux = doItBaby("sp_Gen_ObtenerCultivosPacking", Nothing, TipoQuery.DataTable)
        cargarCombo(cboCultivo, aux.Copy, "", True)
        cboLinea.SelectedValue = -1
        cboCultivo.SelectedValue = -1
        'cargarCombo(cboEmpaque, tablas.Tables(3))
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        'cargarCombo(cboVariedad, padre.dsParaControles.Tables(2), cboCultivo.SelectedValue)
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@TipoId", "D")
        aux = doItBaby("sp_Gen_ObtenerVariedadesPacking", p, TipoQuery.DataTable)
        cargarCombo(cboVariedad, aux.Copy, "", True)
        cboVariedad.SelectedIndex = -1
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If cboLinea.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar una linea.")
            Exit Sub
        ElseIf cboCultivo.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un cultivo.")
            Exit Sub
        ElseIf cboVariedad.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar una variedad.")
            Exit Sub
        ElseIf cboEmpaque.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un empaque.")
            Exit Sub
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Packing")
        p.Add("@Dia", dtpFecha.Value)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            'dtpFecha.Value = Now()
            MessageBox.Show("No se crear un pallet para este dia por que el dia se encuentra cerrado.")
            Exit Sub
        End If

        Dim dtResultado As DataTable
        'Dim idNuevoPallet As String = String.Empty
        'Dim p As New Dictionary(Of String, Object)
        p.Clear()
        p.Add("@IdCultivoVariedadPacking", cboVariedad.SelectedValue)
        p.Add("@IdEmpaquePacking", cboEmpaque.SelectedValue)
        p.Add("@IdLinea", cboLinea.SelectedValue)
        p.Add("@Usuario", Temporales.usuarioActual)
        p.Add("@Fecha", dtpFecha.Value.ToString("yyyy-MM-dd"))
        'p.Add("@Dia", padre.pkrDia.Value.ToString("yyyy-MM-dd"))
        'p.Add("@Dia", padre.pkrDia.Value)
        Try
            'If padre.onLine Then
            Dim n As Integer = 0
            Try
                n = CType(cboCantidad.SelectedItem, Integer)
                n = IIf(n > 0, n, 1)
            Catch ex As Exception
                n = 1
            End Try
            dtResultado = Nothing
            While n > 0 And n <= 10
                dtResultado = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_CrearPallet", p, TipoQuery.DataTable)
                n -= 1
            End While

            'idNuevoPallet = dtResultado.Rows(1).Item(0).ToString
            'Else
            ''PENDIENTE OBTENER INFO DE SQLITE
            'End If
            padre.idPalletActual = dtResultado.Rows(0).Item(0).ToString
            padre.maxCajas = dtResultado.Rows(0).Item(1).ToString
            padre.idLineaActual = cboLinea.SelectedValue
            'p = New Dictionary(Of String, Object)
            'p.Add("@IdPallet", idNuevoPallet)
            'padre.maxCajas = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_ObtenerMaxCajas", p, TipoQuery.Scalar)

            'padre.palletActual =
            '    New PknPallet(idNuevoPallet.Substring(0, 2),
            '                  cboVariedad.SelectedValue,
            '                  cboEmpaque.SelectedValue,
            '                  idNuevoPallet.Substring(6, 3),
            '                  cboLinea.SelectedValue,
            '                  Temporales.usuarioActual)
            'padre.listaPalletsPendientes.Add(padre.palletActual)
            'frmPacking_Movimientos_LecturaEficiencias.listarTodaLaData()
            'PENDIENTE TRANSFORMAR EL NUEVO PALLET A FILA Y AGREGARLO AL INICIO DE LA TABLA DE PALLETS PENDIENTES   
            'frmPacking_Movimientos_LecturaEficiencias.dsParaMostrar.Tables(0).Rows.InsertAt(
            '    frmPacking_Movimientos_LecturaEficiencias.convertirPalletAFila(
            '        frmPacking_Movimientos_LecturaEficiencias.palletActual,
            '        frmPacking_Movimientos_LecturaEficiencias.dsParaMostrar.Tables(0)),
            '    0)

            'REEMPLAZAR POR UN LISTARPALLETSPENDIENTES()
            'frmPacking_Movimientos_LecturaEficiencias.obtenerPalletsPendientes()
            'frmPacking_Movimientos_LecturaEficiencias.cargarListaPalletsPendientes()
            'frmPacking_Movimientos_LecturaEficiencias.cargarDataGridView(dgvPalletsPendientes, dsParaMostrar.Tables(0))
            'padre.sincronizarTablaSqlite("SqlitePackingPallets")
            'padre.sincronizarTablaSqlite("SqlitePackingPallets")
            padre.listarPalletsPendientes()
            padre.clickearDgvPalletsPendientes(padre.idPalletActual)
            'padre.actualizarEtiquetasPalletActual()
            'padre.dgvPalletsPendientes_CellClick(sender, e)

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub cboVariedad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboVariedad.SelectionChangeCommitted

    'End Sub

    'Private Sub frmPacking_Movimientos_LecturaEficiencias_NuevoPallet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    '    frmPacking_Movimientos_LecturaEficiencias.actualizarEtiquetasPalletActual()
    'End Sub

    Private Sub cboVariedad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboVariedad.SelectionChangeCommitted
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@IdVariedad", cboVariedad.SelectedValue)
        p.Add("@IdModulo", "")
        aux = doItBaby("sp_Gen_ObtenerEmpaquesXConsumidorPacking", p, TipoQuery.DataTable)
        cargarCombo(cboEmpaque, aux.Copy, "", True)
        cboEmpaque.SelectedIndex = -1
    End Sub

    'Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
    '    Dim p As New Dictionary(Of String, Object)
    '    p.Add("@Dia", dtpFecha.Value)
    '    'DESHACER
    '    If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
    '        'dtpFecha.Value = Now()
    '        MessageBox.Show("No se crear un pallet para este dia por que el dia se encuentra cerrado.")
    '    End If
    'End Sub
End Class