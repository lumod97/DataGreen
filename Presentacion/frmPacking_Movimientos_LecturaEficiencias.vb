Imports Logica.Utiles
Imports Entidades.Temporales
Imports Logica.Funciones
Imports Datos.Conexion
Imports Datos.ConexionSqlite
Imports Entidades

Public Class frmPacking_Movimientos_LecturaEficiencias

    Public dtCajas As DataTable
    Public stCodigo As String
    'Public drCajaActual As DataRow
    Public iCajas As Integer = 0
    Public nCajaActual As Integer = 0
    Public maxCajas As Integer = 0
    Public idPalletActual As String
    Public idLineaActual As String
    Public descripcionPalletActual As String = "No hay pallet seleccionado"

    Public onLine As Boolean = True
    Public dsParaControles As DataSet
    'Public Shared dsParaMostrar As DataSet = New DataSet

    Dim dtPalletsPendientes As DataTable = Nothing
    Dim dtPalletsCerrados As DataTable = Nothing
    Dim dtResumen As DataTable = Nothing

    'Public palletActual As PknPallet = Nothing
    'Public listaPalletsPendientes As List(Of PknPallet) = New List(Of PknPallet)
    'Dim palletsCerrados As List(Of PknPallet) = New List(Of PknPallet)
    Dim codigosHoy As List(Of String) = New List(Of String)
    'Dim cajaActual As PknCaja = Nothing
    'Dim codigoLeido As PknCodigo = Nothing
    Dim dtCajasDelPalletActual As DataTable = Nothing

    Public Enum DireccionSincronizacion
        Ida
        Vuelta
        IdaYVuelta
        VueltaEIda
    End Enum

    Dim codSel As String = String.Empty
    Dim codPes As String = String.Empty
    Dim codEmp As String = String.Empty

    Private Sub frmPacking_Movimientos_LecturaEficiencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.MdiParent = Nothing
        Me.WindowState = FormWindowState.Maximized
        'Me.TopMost = False

        tlpPrincipal.Visible = False
        maquillar()


        ''MEJORA
        'iniciarTablaDeCajas()

        'tlpTotalGeneral.BackColor = rojoAmarath 'verderCian_
        '        lblTotalGeneral.ForeColor = rojoAmarath
        'formatearMensaje()
        determinarModoTrabajo()
        'iniciarTablasSqlite()
        'obtenerDataParaControles()
        'cargarCombo(cboLinea, dsParaControles.Tables(0))

        'PENDIENTE MEJORAR ESTE PROCESO INTERNO
        'sincronizarTablaSqlite("SqlitePackingCodigosHoy")
        'sincronizarTablaSqlite("SqlitePackingCajas")
        'sincronizarTablaSqlite("SqlitePackingPallets")

        ''MEJORA
        'iniciarTablaDeCajas()

        obtenerCodigosHoy()
        listarPalletsPendientes()
        listarPalletsCerrados()
        listarResumen()
        'actualizarEtiquetas()

        'cargarListaPalletsPendientes()
        'cargarListaPalletsCerrados()

        'listarTodaLaData()

        txtCodigo.Enabled = False
        'bloquearControl(dgvPalletActual)
        'bloquearControl(dgvPalletsCerrados)
        'formatearLabelsResaltantes()
        tlpPrincipal.Visible = True
        'txtCodigo.Focus()


    End Sub

    Private Sub maquillar()
        aplicarTemaExagerado(Me)
        tlpCajaActual.BackColor = verderCian_
        tlpCajaAnterior.BackColor = verderCian_

        lblTotalPallets.Font = fuenteGrande
        lblTotalCajas.Font = fuenteGrande
        lblTotalCodigosValidos.Font = fuenteGrande
        lblTotalCodigosFaltantes.Font = fuenteGrande

        lblTGPallets.Font = fuenteGrandeEtiquetasExagerada
        lblTGPallets.BackColor = temaClaroRubi
        lblTGPallets.ForeColor = blancoPuro_

        lblTGCajas.Font = fuenteGrandeEtiquetasExagerada
        lblTGCajas.BackColor = temaClaroRubi
        lblTGCajas.ForeColor = blancoPuro_

        lblTGCodigosValidos.Font = fuenteGrandeEtiquetasExagerada
        lblTGCodigosValidos.BackColor = temaClaroRubi
        lblTGCodigosValidos.ForeColor = blancoPuro_

        lblTGCodigosFaltantes.Font = fuenteGrandeEtiquetasExagerada
        lblTGCodigosFaltantes.BackColor = temaClaroRubi
        lblTGCodigosFaltantes.ForeColor = blancoPuro_

        lblDescripcionPalletActual.Font = fuenteGrandeEtiquetasExagerada
        lblDescripcionPalletActual.BackColor = temaClaroRubi
        lblDescripcionPalletActual.ForeColor = blancoPuro_
    End Sub

    'Private Sub iniciarTablasSqlite()
    '    'ejecutarSqlite("packingLimpiarTablas")
    '    sincronizarTablaSqlite("SqlitePackingCodigosHoy")
    '    obtenerCodigosHoy()

    '    sincronizarTablaSqlite("SqlitePackingCajas")
    '    'actualizarTablaEnMemoria(dtCajasDelPalletActual, "packingObtenerPalletsPendientes")

    '    sincronizarTablaSqlite("SqlitePackingPallets")
    '    'actualizarTablaEnMemoria(dtPalletsPendientes, "packingObtenerPalletsPendientes")
    '    'cargarDataGridView(dgvPalletsPendientes, dtPalletsPendientes)

    '    'ejecutarSqlite("packingLimpiarTablas")
    '    'cargarTablaSqlite("SqlitePackingCodigosHoy", True)
    '    'cargarTablaSqlite("SqlitePackingCajas", True)
    '    'cargarTablaSqlite("SqlitePackingPallets", True)
    'End Sub

    Private Sub btnNuevoPallet_Click(sender As Object, e As EventArgs) Handles btnNuevoPallet.Click

        Dim VenActual As New frmPacking_Movimientos_LecturaEficiencias_NuevoPallet(Me)
        'VenActual.Parent = Me
        VenActual.Show()
        'MessageBox.Show("fin")
    End Sub

    Private Sub determinarModoTrabajo()
        Try
            If probarConexionDG() Then
                onLine = True
            Else
                onLine = False
                MessageBox.Show("Modo de trabajo OFFLINE activado. La data se almacerá temporalmente en la BASE LOCAL.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub obtenerDataParaControles()
    '    Try
    '        Dim aux As DataSet = New DataSet
    '        If onLine Then
    '            aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_ObtenerDataParaControles", Nothing, TipoQuery.DataSet)
    '            dsParaControles = New DataSet
    '            dsParaControles.Tables.Add(aux.Tables(0).Copy)
    '            dsParaControles.Tables.Add(aux.Tables(1).Copy)
    '            dsParaControles.Tables.Add(aux.Tables(2).Copy)
    '            dsParaControles.Tables.Add(aux.Tables(3).Copy)
    '        Else
    '            'PENDIENTEcargarDatasetdesdesqlite
    '            'nio muevan
    '        End If
    '        'obtener data sqlite
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub obtenerCodigosHoy()
        'COMENTADO TEMPORALMENTE, QUEDA PENDIENTE MEJORAR
        'Dim aux As DataTable = New DataTable
        'aux = ejecutarSqlite("packingListarCodigosHoy")
        'For Each fila As DataRow In aux.Rows
        '    codigosHoy.Add(fila.Item(0).ToString)
        'Next

        'COMENTADO TEMPORAL PARA PROBAR MEJORA
        If onLine Then
            Dim aux As DataTable = New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
            aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_CodigosHoy", p, TipoQuery.DataTable)
            For Each fila As DataRow In aux.Rows
                codigosHoy.Add(fila.Item(0).ToString)
            Next
        Else

            'PENDIENTE OBTENER INFO DE SQLITE
        End If
    End Sub

    'Public Sub listarTodaLaData()
    '    dsParaMostrar = New DataSet
    '    obtenerPalletsPendientes()
    '    obtenerPalletsCerrados()
    '    obtenerResumen()
    '    'obtenerDataParaDGVs()

    '    'dgvPalletActual.Columns.Clear()
    '    'dgvPalletsPendientes.Columns.Clear()
    '    'dgvPalletsCerrados.Columns.Clear()
    '    'dgvResumen.Columns.Clear()

    '    'corregirTabla(dataSetParaMostrar.Tables(0))
    '    'corregirTabla(dataSetParaMostrar.Tables(1))
    '    'corregirTabla(dataSetParaMostrar.Tables(2))
    '    'corregirTabla(dataSetParaMostrar.Tables(3))

    '    'dgvPalletActual.DataSource = dataSetParaMostrar.Tables(0)
    '    'dgvPalletsPendientes.DataSource = dataSetParaMostrar.Tables(1)
    '    'dgvPalletsCerrados.DataSource = dataSetParaMostrar.Tables(2)
    '    'dgvResumen.DataSource = dataSetParaMostrar.Tables(3)

    '    'formatearDataGridView(dgvPalletActual)
    '    'formatearDataGridView(dgvPalletsPendientes)
    '    'formatearDataGridView(dgvPalletsCerrados)
    '    'formatearDataGridView(dgvResumen)

    '    'PENDIENTE IMPLEMENTAR METODO CARGARDATAGRIDVIEW EN LOS DEMAS FORMS
    '    cargarDataGridView(dgvPalletsPendientes, dsParaMostrar.Tables(0))
    '    cargarDataGridView(dgvPalletsCerrados, dsParaMostrar.Tables(1))
    '    cargarDataGridView(dgvResumen, dsParaMostrar.Tables(2))

    'End Sub

    'Private Sub obtenerDataParaDGVs() '=>OBTENER DATA PARA DATA GRID VIEWS
    '    Try
    '        obtenerPalletsPendientes()
    '        obtenerPalletsCerrados()
    '        obtenerResumen()
    '        'dsParaMostrar = New DataSet
    '        'Dim aux As DataTable = New DataTable
    '        'If onLine Then
    '        '    aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_PalletsPendientes", Nothing,
    '        '                   Datos.Conexion.TipoQuery.DataTable)
    '        '    dsParaMostrar.Tables.Add(aux.Copy)

    '        '    aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_PalletsCerrados", Nothing,
    '        '                   Datos.Conexion.TipoQuery.DataTable)
    '        '    dsParaMostrar.Tables.Add(aux.Copy)
    '        '    aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_Resumen", Nothing,
    '        '                   Datos.Conexion.TipoQuery.DataTable)
    '        '    dsParaMostrar.Tables.Add(aux.Copy)
    '        'End If

    '        'MODO OFFLINE DESHABILITADO TEMPORALMENTE
    '        'Dim auxSqlite As DataSet = New DataSet
    '        'auxSqlite = execSqlitePorNombre("selectSqliteTareos", Nothing, 3)
    '        'tablaTareos.Merge(auxSqlite.Tables(0), True, MissingSchemaAction.Ignore)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub obtenerPalletsPendientes()
        Try
            'dtPalletsPendientes = ejecutarSqlite("packingListarPalletsPendientes")

            'COMENTADO TEMPORALMENTE PARA PROBAR MEJORA
            If onLine Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Usuario", usuarioActual)
                p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
                dtPalletsPendientes = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_PalletsPendientes", p, TipoQuery.DataTable)
            Else
                'PENDIENTE OBTENER INFO DE SQLITE
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub obtenerPalletsCerrados()
        Try
            'Dim aux As DataTable = New DataTable
            If onLine Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
                dtPalletsCerrados = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_PalletsCerrados", p,
                               TipoQuery.DataTable)
            Else
                'PENDIENTE OBTENER INFO DE SQLITE
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub obtenerResumen()
        Try
            If onLine Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
                dtResumen = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_Resumen", p,
                               Datos.Conexion.TipoQuery.DataTable)
            Else
                'PENDIENTE OBTENER INFO DE SQLITE
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub cargarDataGridView(ByRef dgv As DataGridView, ByRef tabla As DataTable)
        dgv.Columns.Clear()
        corregirTabla(tabla)
        dgv.DataSource = tabla
        formatearDataGridView(dgv)
    End Sub

    Public Sub dgvPalletsPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPalletsPendientes.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            'Dim filaSeleccionada As Integer = e.RowIndex
            listarPalletsPendientes()
            Dim fila As DataRow = dtPalletsPendientes.Rows(e.RowIndex)

            'ACTUALIZAR CONTROLES
            idPalletActual = fila.Item(1)
            idLineaActual = fila.Item(0)
            iCajas = CType(fila.Item(6), Integer)
            nCajaActual = iCajas + 1

            'Dim p As New Dictionary(Of String, Object)
            'p.Add("@IdPallet", idPalletActual)
            'Dim aux As String = String.Empty
            'maxCajas = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_ObtenerMaxCajas", p, TipoQuery.Scalar)
            maxCajas = fila.Item(7)
            'maxCajas = CType(aux, Integer)
            actualizarEtiquetasPalletActual()
            descripcionPalletActual = "L:" + idLineaActual + "|" + idPalletActual + "|" + maxCajas.ToString + "|" + fila.Item(3).ToString + "|" + fila.Item(4).ToString + "|" + fila.Item(5).ToString
            lblDescripcionPalletActual.Text = descripcionPalletActual
            listarCajasPalletsActual()
            'dgvPalletsPendientes ACTUALIZAR TAMBIEN CUANDO SE CREE PALLET NUEVO 
            If Not txtCodigo.Enabled Then
                txtCodigo.Enabled = True
            End If
            dgvPalletsPendientes.ClearSelection()
            dgvPalletsPendientes.Rows(e.RowIndex).Selected = True
            txtCodigo.Focus()
        End If

    End Sub

    'Public Sub cargarListaPalletsPendientes()
    '    For Each fila As DataRow In dsParaMostrar.Tables(0).Rows
    '        'convertirFilaAPallet(palletsPendientes, fila)
    '        palletsPendientes.Add(convertirFilaAPallet(fila))
    '    Next
    'End Sub

    'Private Function convertirFilaAPallet(fila As DataRow) As PknPallet
    '    Dim aux As PknPallet =
    '    New PknPallet(fila.Item(10), fila.Item(11), fila.Item(12), fila.Item(13), fila.Item(0), fila.Item(8))
    '    aux.NroCajas = fila(6)
    '    aux.NroCajasMax = fila(7)
    '    Return aux
    'End Function

    'Public Function convertirPalletAFila(pallet As PknPallet, tabla As DataTable) As DataRow
    '    Dim aux As DataRow = tabla.NewRow()
    '    aux.Item(0) = pallet.IdPallet
    '    Return aux
    'End Function

    'Private Sub cargarListaPalletsCerrados()
    '    For Each fila As DataRow In dsParaMostrar.Tables(1).Rows
    '        palletsCerrados.Add(convertirFilaAPallet(fila))
    '    Next
    'End Sub

    Public Sub actualizarEtiquetasPalletActual()
        If idPalletActual <> "" Then
            lblPalletActual.Text = "Pallet Actual: " + idPalletActual
            'obtenerCajasDelPalletActual()
            'dgvPalletActual.DataSource = dtCajasDelPalletActual
            'formatearDataGridView(dgvPalletActual)
        End If
    End Sub

    Private Sub actualizarEtiquetas()
        lblPallet_CajAnt.Text = lblPallet_CajAct.Text
        lblPallet_CajAct.Text = idPalletActual '""
        lblNroCaja_CajAnt.Text = lblNroCaja_CajAct.Text
        lblNroCaja_CajAct.Text = ""
        lblSel_CajAnt.Text = lblSel_CajAct.Text
        lblSel_CajAct.Text = ""
        lblPes_CajAnt.Text = lblPes_CajAct.Text
        lblPes_CajAct.Text = ""
        lblEmp_CajAnt.Text = lblEmp_CajAct.Text
        lblEmp_CajAct.Text = ""
        'Actualizar totales generales
        If dtResumen.Rows.Count > 0 Then
            lblTGPallets.Text = dtResumen.Compute("Sum(TotPall)", "Origen <> ''")
            lblTGCajas.Text = dtResumen.Compute("Sum(TotCajas)", "Origen <> ''")
            lblTGCodigosValidos.Text = dtResumen.Compute("Sum(TotCodValidos)", "Origen <> ''")
            lblTGCodigosFaltantes.Text = dtResumen.Compute("Sum(TotCodFalt)", "Origen <> ''")
        End If
    End Sub

    Private Sub obtenerCajasDelPalletActual()
        Try
            If idPalletActual <> "" Then
                'packingObtenerCajasDelPalletActual

                'comentado temporalmente
                'Dim pSqlt As New List(Of Object)
                'pSqlt.Add(palletActual.IdPallet)
                'dtCajasDelPalletActual = ejecutarSqlite("packingObtenerCajasDelPalletActual", pSqlt)

                'COMENTADO TEMPORALMENTE PARA PROBAR MEJORA
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdPallet", idPalletActual)
                If onLine Then
                    dtCajasDelPalletActual = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_ObtenerCajasDelPalletActual",
                                                      p,
                                                      Datos.Conexion.TipoQuery.DataTable)
                Else
                    'PENDIENTE OBTENER INFO DE SQLITE
                End If
                ''MODO OFFLINE DESHABILITADO TEMPORALMENTE
                ''Dim auxSqlite As DataSet = New DataSet
                ''auxSqlite = execSqlitePorNombre("selectSqliteTareos", Nothing, 3)
                ''tablaTareos.Merge(auxSqlite.Tables(0), True, MissingSchemaAction.Ignore)
            Else
                dtCajasDelPalletActual = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Sub formatearLabelsResaltantes()
    '    'lblResumen.Font = fuenteGrande
    '    'lblTotalGeneral.Font = fuenteGrande
    '    lblTotalPallets.Font = fuenteGrande
    '    lblTotalCajas.Font = fuenteGrande
    '    lblTotalCodigosValidos.Font = fuenteGrande
    '    lblTotalCodigosFaltantes.Font = fuenteGrande

    '    lblTGPallets.Font = fuenteGrandeEtiquetasExagerada
    '    lblTGPallets.BackColor = temaClaroRubi
    '    lblTGPallets.ForeColor = blancoPuro_

    '    lblTGCajas.Font = fuenteGrandeEtiquetasExagerada
    '    lblTGCajas.BackColor = temaClaroRubi
    '    lblTGCajas.ForeColor = blancoPuro_

    '    lblTGCodigosValidos.Font = fuenteGrandeEtiquetasExagerada
    '    lblTGCodigosValidos.BackColor = temaClaroRubi
    '    lblTGCodigosValidos.ForeColor = blancoPuro_

    '    lblTGCodigosFaltantes.Font = fuenteGrandeEtiquetasExagerada
    '    lblTGCodigosFaltantes.BackColor = temaClaroRubi
    '    lblTGCodigosFaltantes.ForeColor = blancoPuro_

    '    lblDescripcionPalletActual.Font = fuenteGrandeEtiquetasExagerada
    '    lblDescripcionPalletActual.BackColor = temaClaroRubi
    '    lblDescripcionPalletActual.ForeColor = blancoPuro_

    'End Sub

    Private Sub dgvResumen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResumen.CellClick
        txtCodigo.Focus()
    End Sub

    Private Sub dgvPalletsCerrados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPalletsCerrados.CellClick
        txtCodigo.Focus()
    End Sub

    Private Sub dgvPalletActual_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPalletActual.CellClick
        txtCodigo.Focus()
    End Sub

    'Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If codigosHoy.IndexOf(txtCodigo.Text) < 0 AndAlso txtCodigo.Text.Length = 10 Then
    '            txtCodigo.Text = UCase(txtCodigo.Text)
    '            Dim labor As Char = determinarLabor(txtCodigo.Text)
    '            Dim linea As Char = determinarLinea(txtCodigo.Text)
    '            If labor = "0" And linea = "0" Then
    '                If palletActual.CajaActual Is Nothing Then
    '                    MessageBox.Show("No se puede vincular un codigo faltante a una caja vacía.")
    '                    Exit Sub
    '                Else
    '                    'linea = palletActual.CajaActual.IdLinea
    '                    labor = IIf(palletActual.CajaActual.CodSel Is Nothing, "S", IIf(palletActual.CajaActual.CodPes Is Nothing, "P", "E"))
    '                End If
    '            End If
    '            codigoLeido = New PknCodigo(txtCodigo.Text, labor, palletActual.IdLinea, linea, Now.ToString("yyyy-MM-dd hh:mm:ss"),
    '                                        palletActual.Usuario)

    '            Select Case labor
    '                Case "S"
    '                    lblSel_CajAct.Text = codigoLeido.Codigo
    '                Case "P"
    '                    lblPes_CajAct.Text = codigoLeido.Codigo
    '                Case "E"
    '                    lblEmp_CajAct.Text = codigoLeido.Codigo
    '            End Select
    '            'INSERTAR CODIGO EN CAJA ACTUAL//EVALUAR LA POSIBILIDAR DE ELIMINAR ESTA LINEA DEBIDO A QUE NO TIENE TRASCENDENCIA
    '            insertarCodigoEnCajaActual()
    '            lblPallet_CajAct.Text = palletActual.CajaActual.IdPallet
    '            lblNroCaja_CajAct.Text = palletActual.CajaActual.NroCaja

    '            'GRABAR EN BASE DE DATOS
    '            grabarCodigoEnTablaDeLecturas()
    '            '
    '            'grabarCodigoEnTablaDeCajas()
    '            SincronizarLecturas("SqlitePackingLecturas", "Dg_Pkn_LecturasPacking", DireccionSincronizacion.Ida)

    '            'INSERTAR EN LISTA CODIGOS HOY
    '            If labor <> "0" And linea <> "0" Then
    '                codigosHoy.Add(codigoLeido.Codigo)
    '            End If
    '            If palletActual.CajaActual.Items = 3 Then
    '                palletActual.CajaActual = Nothing
    '                sincronizarTablaSqlite("SqlitePackingPallets")
    '                listarPalletsPendientes()
    '                listarPalletsCerrados()
    '                listarResumen()
    '                If palletActual.NroCajas = palletActual.NroCajasMax Then
    '                    'listarPalletsCerrados()
    '                    palletActual = Nothing
    '                    txtCodigo.Enabled = False
    '                    MessageBox.Show("El pallet " + lblPallet_CajAct.Text + " se ha completado, defina o elija un nuevo pallet para continuar leyendo códigos.")

    '                    'txtCodigo.Focus()
    '                End If
    '                'PENDIENTE DE ACTUALIZAR DTRESUMEN

    '                'Inicia BackGorundWorker
    '                'If Not bgwSincronizaLecturas.IsBusy Then
    '                '    bgwSincronizaLecturas.RunWorkerAsync()
    '                'End If

    '                'listarResumen()
    '                ''obtenerResumen()
    '                actualizarEtiquetas()
    '                ''lblPallet_CajAnt.Text = lblPallet_CajAct.Text
    '                ''lblPallet_CajAct.Text = ""
    '                ''lblNroCaja_CajAnt.Text = lblNroCaja_CajAct.Text
    '                ''lblNroCaja_CajAct.Text = ""
    '                ''lblSel_CajAnt.Text = lblSel_CajAct.Text
    '                ''lblSel_CajAct.Text = ""
    '                ''lblPes_CajAnt.Text = lblPes_CajAct.Text
    '                ''lblPes_CajAct.Text = ""
    '                ''lblEmp_CajAnt.Text = lblEmp_CajAct.Text
    '                ''lblEmp_CajAct.Text = ""
    '                ''actualizarEtiquetas()
    '                'listarPalletsPendientes()
    '            End If
    '            listarCajasPalletsActual()
    '        End If
    '        txtCodigo.Text = ""
    '        txtCodigo.Focus()
    '    End If
    'End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            stCodigo = UCase(txtCodigo.Text)
            'validar no haya sido leido hoy
            'validar longitud (formato)
            'validar labor
            If stCodigo.Length <> 10 Then
                MessageBox.Show("El codigo " + stCodigo + " no es un codigo válido.")
                '@Jota: 2022-10-28
                'ElseIf codigosHoy.IndexOf(stCodigo) >= 0 Then
                '    Dim detalle As String
                '    Dim p As New Dictionary(Of String, Object)
                '    p.Add("@Codigo", stCodigo)
                '    detalle = doItBaby("sp_Dg_Packing_Movimientos_LecturasEficiencias_ConsultarCodigo", p, TipoQuery.Scalar)
                '    txtCodigo.Text = ""
                '    My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                '    MessageBox.Show("El codigo " + stCodigo + " ya ha sido leido anteriormente." + vbNewLine + detalle)
            Else
                'If codigosHoy.IndexOf(stCodigo) < 0 Then
                'If stCodigo.Length = 10 Then
                'stCodigo = UCase(txtCodigo.Text)
                Dim labor As Char = determinarLabor(txtCodigo.Text)
                Dim linea As Char = determinarLinea(txtCodigo.Text)
                If labor = "0" And linea = "0" Then
                    If codSel = "" And codPes = "" And codEmp = "" Then
                        My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                        MessageBox.Show("No se puede vincular un codigo faltante a una caja vacía.")
                        Exit Sub
                    Else
                        'linea = palletActual.CajaActual.IdLinea
                        labor = IIf(codSel = "", "S", IIf(codPes = "", "P", "E"))
                    End If
                End If

                'codigoLeido = New PknCodigo(txtCodigo.Text, labor, palletActual.IdLinea, linea, Now.ToString("yyyy-MM-dd hh:mm:ss"),
                'palletActual.Usuario)

                'If iCajas = 0 Then
                '    iCajas = 1
                'End If
                If codSel = "" And codPes = "" And codEmp = "" Then
                    'iCajas += 1
                    'drCajaActual = dtCajas.NewRow()
                    'drCajaActual.Item(0) = idPalletActual
                    'drCajaActual.Item(1) = iCajas
                    'drCajaActual.Item(2) = ""
                    'drCajaActual.Item(3) = ""
                    'drCajaActual.Item(4) = ""
                    'drCajaActual.Item(5) = Now.ToString("yyyy-MM-dd hh:mm:ss")
                    'drCajaActual.Item(6) = idLineaActual
                    'drCajaActual.Item(7) = usuarioActual
                    lblNroCaja_CajAct.Text = nCajaActual.ToString
                    'lblPallet_CajAct.Text = idPalletActual
                End If

                'If labor = "S" Then
                '    codSel = stCodigo
                'ElseIf labor = "P" Then
                '    codPes = stCodigo
                'ElseIf labor = "E" Then
                '    codEmp = stCodigo
                'End If

                lblPallet_CajAct.Text = idPalletActual
                Select Case labor
                    Case "S"
                        If codSel = String.Empty Then 'If drCajaActual.Item(2) = "" Then
                            codSel = stCodigo
                            lblSel_CajAct.Text = stCodigo
                        Else
                            My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                            MessageBox.Show("Cierre la caja actual antes de pasar a la siguiente caja.")
                        End If
                    Case "P"
                        If codPes = String.Empty Then 'If drCajaActual.Item(3) = "" Then
                            codPes = stCodigo
                            lblPes_CajAct.Text = stCodigo
                        Else
                            My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                            MessageBox.Show("Cierre la caja actual antes de pasar a la siguiente caja.")
                        End If
                    Case "E"
                        If codEmp = String.Empty Then 'If drCajaActual.Item(4) = "" Then
                            codEmp = stCodigo
                            lblEmp_CajAct.Text = stCodigo
                        Else
                            My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                            MessageBox.Show("Cierre la caja actual antes de pasar a la siguiente caja.")
                        End If
                End Select
                'INSERTAR EN LISTA CODIGOS HOY
                'If labor <> "0" And linea <> "0" Then
                '    codigosHoy.Add(stCodigo)
                'End If
                'If drCajaActual.Item(2) <> "" AndAlso drCajaActual.Item(3) <> "" AndAlso drCajaActual.Item(4) <> "" Then
                If codSel <> "" AndAlso codPes <> "" AndAlso codEmp <> "" Then
                    actualizarEtiquetas()
                    grabarCodigosEnBD()
                    My.Computer.Audio.Play(My.Resources.Notificacion, AudioPlayMode.Background)
                    listarCajasPalletsActual()
                    'listarPalletsPendientes()
                    'listarPalletsCerrados()
                    'listarResumen()
                    'codSel = String.Empty
                    'codPes = String.Empty
                    'codEmp = String.Empty
                    If iCajas >= maxCajas Then
                        cerrarPallet()
                        txtCodigo.Enabled = False
                        'MessageBox.Show("El pallet " + idPalletActual + " se ha completado, defina o elija un nuevo pallet para continuar leyendo códigos.")
                        ''pendiente encapsular estos procesos en algo tipo "cerrarPallet"
                        'iCajas = 0
                        'maxCajas = 0
                        'idPalletActual = String.Empty
                        'idLineaActual = String.Empty
                        Exit Sub
                    End If
                End If


                'INSERTAR CODIGO EN CAJA ACTUAL//EVALUAR LA POSIBILIDAR DE ELIMINAR ESTA LINEA DEBIDO A QUE NO TIENE TRASCENDENCIA
                'insertarCodigoEnCajaActual()
                'lblPallet_CajAct.Text = palletActual.CajaActual.IdPallet


                'GRABAR EN BASE DE DATOS
                'grabarCodigoEnTablaDeLecturas()
                '
                'grabarCodigoEnTablaDeCajas()
                'SincronizarLecturas("SqlitePackingLecturas", "Dg_Pkn_LecturasPacking", DireccionSincronizacion.Ida)



                'If palletActual.CajaActual.Items = 3 Then
                '    palletActual.CajaActual = Nothing
                '    sincronizarTablaSqlite("SqlitePackingPallets")
                '    listarPalletsPendientes()
                '    listarPalletsCerrados()
                '    listarResumen()
                '    If palletActual.NroCajas = palletActual.NroCajasMax Then
                '        'listarPalletsCerrados()
                '        palletActual = Nothing
                '        txtCodigo.Enabled = False
                '        MessageBox.Show("El pallet " + lblPallet_CajAct.Text + " se ha completado, defina o elija un nuevo pallet para continuar leyendo códigos.")

                '        'txtCodigo.Focus()
                '    End If
                'PENDIENTE DE ACTUALIZAR DTRESUMEN

                'Inicia BackGorundWorker
                'If Not bgwSincronizaLecturas.IsBusy Then
                '    bgwSincronizaLecturas.RunWorkerAsync()
                'End If

                'listarResumen()
                ''obtenerResumen()

                ''lblPallet_CajAnt.Text = lblPallet_CajAct.Text
                ''lblPallet_CajAct.Text = ""
                ''lblNroCaja_CajAnt.Text = lblNroCaja_CajAct.Text
                ''lblNroCaja_CajAct.Text = ""
                ''lblSel_CajAnt.Text = lblSel_CajAct.Text
                ''lblSel_CajAct.Text = ""
                ''lblPes_CajAnt.Text = lblPes_CajAct.Text
                ''lblPes_CajAct.Text = ""
                ''lblEmp_CajAnt.Text = lblEmp_CajAct.Text
                ''lblEmp_CajAct.Text = ""
                ''actualizarEtiquetas()
                'listarPalletsPendientes()
                'End If
                ''                    listarCajasPalletsActual()
                'Else
                '    MessageBox.Show("El codigo " + stCodigo + " no es un codigo válido.")
                'End If
                'Else
                '    Dim detalle As String
                '    Dim p As New Dictionary(Of String, Object)
                '    p.Add("@Codigo", stCodigo)
                '    detalle = doItBaby("sp_Dg_Packing_Movimientos_LecturasEficiencias_ConsultarCodigo", p, TipoQuery.Scalar)
                '    MessageBox.Show("El codigo " + stCodigo + " ya ha sido leido anteriormente." + vbNewLine + detalle)
                'End If
                txtCodigo.Text = ""
                stCodigo = String.Empty
                'txtCodigo.Text = ""
                txtCodigo.Focus()
            End If
        End If
    End Sub

    Private Function determinarLabor(codigo As String) As Char
        If codigo <> "0000000000" Then
            Select Case codigo.Substring(2, 1).ToString
                Case "0", "1", "2", "3", "C"
                    Return "S"
                Case "4", "5", "6", "7", "D"
                    Return "P"
                Case "8", "9", "A", "B", "E"
                    Return "E"
            End Select
        End If
        Return "0"
    End Function

    Private Function determinarLinea(codigo As String) As Char
        If codigo <> "0000000000" Then
            Select Case codigo.Substring(2, 1).ToString
                Case "0", "4", "8"
                    Return "1"
                Case "1", "5", "9"
                    Return "2"
                Case "2", "6", "A"
                    Return "3"
                Case "3", "7", "B"
                    Return "4"
                Case "C", "D", "E"
                    Return "5"
            End Select
        End If
        Return "0"
    End Function

    'Private Sub insertarCodigoEnCajaActual()
    '    'codigoLeido = New PknCodigo(codigo, labor, linea, Now.ToString("yyyy-MM-dd hh:mm:ss.fff"), palletActual.Usuario)
    '    If palletActual.CajaActual Is Nothing Then
    '        palletActual.CajaActual = New PknCaja(palletActual.IdPallet, palletActual.NroCajas + 1, Nothing, Nothing, Nothing,
    '                                 palletActual.IdLinea, palletActual.Usuario)
    '        palletActual.Cajas.Add(palletActual.CajaActual)
    '        palletActual.NroCajas += 1
    '    End If
    '    If codigoLeido.IdLabor = "S" And palletActual.CajaActual.CodSel Is Nothing Then
    '        palletActual.CajaActual.CodSel = codigoLeido
    '    ElseIf codigoLeido.IdLabor = "P" And palletActual.CajaActual.CodPes Is Nothing Then
    '        palletActual.CajaActual.CodPes = codigoLeido
    '    ElseIf codigoLeido.IdLabor = "E" And palletActual.CajaActual.CodEmp Is Nothing Then
    '        palletActual.CajaActual.CodEmp = codigoLeido
    '    End If
    '    palletActual.CajaActual.Items = palletActual.CajaActual.Items + 1
    'End Sub

    'Private Sub grabarCodigoEnTablaDeLecturas()
    '    Try
    '        Dim pSqlt As New List(Of Object)
    '        pSqlt.Add(palletActual.CajaActual.IdPallet)
    '        pSqlt.Add(palletActual.NroCajas)
    '        pSqlt.Add(palletActual.CajaActual.Items)
    '        pSqlt.Add(codigoLeido.Codigo)
    '        'pSqlt.Add(Now.ToString("yyyy-MM-dd hh:mm:ss.fff"))
    '        pSqlt.Add(codigoLeido.FechaHoraLectura)
    '        pSqlt.Add(codigoLeido.IdLinea)
    '        pSqlt.Add(codigoLeido.IdLineaOri)
    '        pSqlt.Add(codigoLeido.Usuario)
    '        pSqlt.Add(codigoLeido.IdLabor)
    '        ejecutarSqlite("packingLecturasInsertarCodigo", pSqlt)

    '        'COMENTADO TEMPORALMENTE PARA PROBAR MEJORA
    '        'Dim cadenaParametros As String = String.Empty
    '        ''@CadenaParametros= idpallet,nrocaja,item,codigo,fechahora,idlinea,usuario
    '        'cadenaParametros = palletActual.CajaActual.IdPallet + "," + palletActual.NroCajas.ToString + "," + palletActual.CajaActual.Items.ToString + ","
    '        'cadenaParametros = cadenaParametros + codigoLeido.Codigo + ","
    '        ''Dim fechaHora As String = codigoLeido.FechaHoraLectura.ToString("yyyy-MM-dd hh:mm:ss.fff", c)
    '        'cadenaParametros = cadenaParametros + codigoLeido.FechaHoraLectura + "," 'PENDIENTE FORMATEAR FECHAHORALECTURA
    '        'cadenaParametros = cadenaParametros + codigoLeido.IdLinea + "," + codigoLeido.Usuario + "," + codigoLeido.IdLabor
    '        'Dim p As New Dictionary(Of String, Object)
    '        'p.Add("@CadenaParametros", cadenaParametros)
    '        'If onLine Then
    '        '    doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_InsertarCodigo", p, TipoQuery.NonQuery)
    '        'Else
    '        '    'PENDIENTE OBTENER INFO DE SQLITE
    '        'End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub grabarCodigoEnTablaDeCajas()
    '    Try
    '        Dim pSqlt As New List(Of Object)
    '        pSqlt.Add(palletActual.CajaActual.IdPallet)
    '        pSqlt.Add(palletActual.NroCajas)
    '        pSqlt.Add(palletActual.IdLinea)
    '        pSqlt.Add(usuarioActual)
    '        pSqlt.Add(palletActual.CajaActual.IdPallet)
    '        pSqlt.Add(palletActual.CajaActual.IdPallet)
    '        If palletActual.CajaActual.Items = 1 Then
    '            ejecutarSqlite("packingCrearCaja", pSqlt)
    '        End If
    '        pSqlt = New List(Of Object)
    '        pSqlt.Add(codigoLeido.Codigo)
    '        pSqlt.Add(palletActual.IdPallet)
    '        pSqlt.Add(palletActual.CajaActual.NroCaja)
    '        If codigoLeido.IdLabor = "S" Then
    '            ejecutarSqlite("packingCajaInsertarSeleccion", pSqlt)
    '        ElseIf codigoLeido.IdLabor = "P" Then
    '            ejecutarSqlite("packingCajaInsertarPesado", pSqlt)
    '        ElseIf codigoLeido.IdLabor = "E" Then
    '            ejecutarSqlite("packingCajaInsertarEmpaque", pSqlt)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Public Sub listarCajasPalletsActual()
        obtenerCajasDelPalletActual()
        cargarDataGridView(dgvPalletActual, dtCajasDelPalletActual)
    End Sub

    Public Sub listarPalletsPendientes()
        obtenerPalletsPendientes()
        'Dim pSqlite As New List(Of Object)
        'pSqlite.Add(usuarioActual)
        'dtPalletsPendientes = ejecutarSqlite("packingObtenerPalletsPendientes", pSqlite)
        cargarDataGridView(dgvPalletsPendientes, dtPalletsPendientes)
    End Sub

    Private Sub listarPalletsCerrados()
        obtenerPalletsCerrados()
        cargarDataGridView(dgvPalletsCerrados, dtPalletsCerrados)
    End Sub

    Private Sub listarResumen()
        obtenerResumen()
        cargarDataGridView(dgvResumen, dtResumen)
    End Sub

    'NO BORRAR
    'Public Sub sincronizarTablaSqlite(nombreTabla As String)
    '    Try
    '        If onLine Then
    '            'Dim aux As New DataTable
    '            'aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_PalletsPendientes", Nothing,
    '            '              TipoQuery.DataTable)
    '            'cargarTablaSqlite(aux, "SqlitePackingPallets", True)

    '            'PENDIENTE MANDAR TODA LA DATA ACTUAL EN LOCAL HACIA LA BASE DATAGREEN
    '            'Dim aux As DataTable = New DataTable
    '            'aux = ejecutarSqlite("")
    '            cargarTablaSqliteDesdeBd(nombreTabla, True)
    '            'cargarDataGridView(dgvPalletsPendientes, dtPalletsPendientes)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub actualizarTablaEnMemoria(ByRef tabla As DataTable, nombreConsultaSqlite As String)
    '    Dim pSqlt As New List(Of Object)
    '    pSqlt.Add(usuarioActual)
    '    tabla = ejecutarSqlite(nombreConsultaSqlite, pSqlt)
    'End Sub

    'NO BORRAR
    'Private Sub SincronizarLecturas(nombreTablaSqlite As String, nombreTablaEnBD As String, direccion As DireccionSincronizacion)
    '    Try
    '        Select Case direccion
    '            Case DireccionSincronizacion.Ida
    '                Dim aux As New DataTable
    '                Dim pSqlite As New List(Of Object)
    '                'pSqlite.Add(nombreTablaSqlite)
    '                'aux = ejecutarSqlite("sincronizarObtenerFilasLocales", pSqlite) 'no devuelve nada
    '                Dim query As String = "SELECT * FROM " + nombreTablaSqlite + " WHERE Ubicacion='L'"
    '                aux = ejecutarSqlite(query, tipoProceso.DataTable)
    '                Dim p As New Dictionary(Of String, Object)
    '                Dim cadenaParametros As String = String.Empty
    '                For Each fila As DataRow In aux.Rows
    '                    'pSqlite = New List(Of Object)
    '                    Dim i As Integer = 0
    '                    For Each item In fila.ItemArray
    '                        If i = 4 Then
    '                            Dim fechaHora As String = CType(item, DateTime).ToString("yyyy-MM-dd hh:mm:ss")
    '                            cadenaParametros = cadenaParametros + IIf(cadenaParametros.Length = 0, "", ",") + fechaHora
    '                        Else
    '                            cadenaParametros = cadenaParametros + IIf(cadenaParametros.Length = 0, "", ",") + item.ToString
    '                        End If
    '                        'pSqlite.Add(item)
    '                        i += 1
    '                    Next
    '                    cadenaParametros = cadenaParametros + "'"
    '                    p = New Dictionary(Of String, Object)
    '                    p.Add("@CadenaParametros", cadenaParametros)
    '                    p.Add("@TablaDestino", nombreTablaEnBD)
    '                    If doItBaby("sp_SincronizarTablaDesdeSqlite", p, TipoQuery.NonQuery) Then
    '                        'PENDIENTE DE ACTUALIZAR ESTADO INDIVIDUALMENTE FILA POR FILA
    '                    End If
    '                    cadenaParametros = String.Empty
    '                Next
    '                'pSqlite = New List(Of Object)
    '                'pSqlite.Add(nombreTablaSqlite)
    '                ejecutarSqlite("sincronizarActualizarEstadosSincronizados")
    '            Case DireccionSincronizacion.Vuelta
    '                cargarTablaSqliteDesdeBd(nombreTablaSqlite, False)
    '            Case DireccionSincronizacion.IdaYVuelta
    '                Throw New NotImplementedException
    '            Case DireccionSincronizacion.VueltaEIda
    '                Throw New NotImplementedException
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub bgwSincronizaLecturas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSincronizaLecturas.DoWork
    '    CheckForIllegalCrossThreadCalls = False
    '    SincronizarLecturas("SqlitePackingLecturas", "Dg_Pkn_LecturasPacking", DireccionSincronizacion.Ida)
    '    listarResumen()
    '    actualizarEtiquetas()
    '    listarPalletsPendientes()
    'End Sub

    'Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
    '    SincronizarLecturas("SqlitePackingLecturas", "Dg_Pkn_LecturasPacking", DireccionSincronizacion.Ida)
    '    sincronizarTablaSqlite("SqlitePackingPallets")
    '    listarPalletsPendientes()
    '    listarPalletsCerrados()
    '    listarResumen()
    '    txtCodigo.Focus()
    'End Sub

    'Private Sub iniciarTablaDeCajas()
    '    dtCajas = New DataTable
    '    dtCajas.Columns.Add("IdPallet")
    '    dtCajas.Columns.Add("NroCaja")
    '    dtCajas.Columns.Add("CodSel")
    '    dtCajas.Columns.Add("CodPes")
    '    dtCajas.Columns.Add("CodEmp")
    '    dtCajas.Columns.Add("Fecha")
    '    dtCajas.Columns.Add("IdLinea")
    '    dtCajas.Columns.Add("Usuario")
    'End Sub

    Private Sub grabarCodigosEnBD()
        'IDPALLET,NROCAJA,ITEM, CODIGO, FECHAHORA,IDLINEA,USUARIO,LABOR
        Dim r As String = String.Empty
        Try
            Dim p As New Dictionary(Of String, Object)
            Dim cadenaParametros As String = String.Empty

            'INICIO
            'cadenaParametros = idPalletActual + "," + iCajas.ToString + ",1," + codSel + "," + Now.ToString("yyyy-MM-dd hh:mm:ss") + "," + idLineaActual + "," + usuarioActual + ",S"
            'p.Add("@CadenaParametros", cadenaParametros)
            'nroCajas = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_InsertarCodigo", p, TipoQuery.Scalar)
            'If nroCajas > 0 Then
            '    If codSel <> "0000000000" Then
            '        codigosHoy.Add(codSel)
            '    End If
            'Else
            '    MessageBox.Show("Error de red, no se pudo guardar el codigo " + codSel)
            'End If

            'cadenaParametros = String.Empty
            'p = New Dictionary(Of String, Object)
            'cadenaParametros = idPalletActual + "," + iCajas.ToString + ",2," + codPes + "," + Now.ToString("yyyy-MM-dd hh:mm:ss") + "," + idLineaActual + "," + usuarioActual + ",P"
            'p.Add("@CadenaParametros", cadenaParametros)
            'nroCajas = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_InsertarCodigo", p, TipoQuery.Scalar)
            'If nroCajas > 0 Then
            '    If codPes <> "0000000000" Then
            '        codigosHoy.Add(codPes)
            '    End If
            'Else
            '    MessageBox.Show("Error de red, no se pudo guardar el codigo " + codPes)
            'End If

            'cadenaParametros = String.Empty
            'p = New Dictionary(Of String, Object)
            'cadenaParametros = idPalletActual + "," + iCajas.ToString + ",3," + codEmp + "," + Now.ToString("yyyy-MM-dd hh:mm:ss") + "," + idLineaActual + "," + usuarioActual + ",E"
            'p.Add("@CadenaParametros", cadenaParametros)
            'nroCajas = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_InsertarCodigo", p, TipoQuery.Scalar)
            'If nroCajas > 0 Then
            '    If codEmp <> "0000000000" Then
            '        codigosHoy.Add(codEmp)
            '    End If
            '    iCajas = nroCajas
            'Else
            '    MessageBox.Show("Error de red, no se pudo guardar el codigo " + codEmp)
            'End If
            'FIN

            cadenaParametros = idPalletActual + "," + nCajaActual.ToString + "," + codSel + "," + codPes + "," + codEmp + "," + Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "," + idLineaActual + "," + usuarioActual
            p.Add("@CadenaParametros", cadenaParametros)
            r = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_InsertarCodigo_V3", p, TipoQuery.Scalar)
            '@Jota: 2022-10-28
            'If CType(r, Integer) > 0 Then
            '    If codSel <> "0000000000" Then
            '        codigosHoy.Add(codSel)
            '    End If
            '    If codPes <> "0000000000" Then
            '        codigosHoy.Add(codPes)
            '    End If
            '    If codEmp <> "0000000000" Then
            '        codigosHoy.Add(codEmp)
            '    End If
            '    iCajas = CType(r, Integer)
            '    nCajaActual = iCajas + 1
            'End If
            If r.Length > 3 Then
                My.Computer.Audio.Play(My.Resources.Alerta, AudioPlayMode.Background)
                Throw New Exception(r)
            Else
                iCajas = CType(r, Integer)
                nCajaActual = iCajas + 1
            End If
        Catch ex As Exception
            MessageBox.Show(r & ex.Message)
        Finally
            codSel = String.Empty
            codPes = String.Empty
            codEmp = String.Empty
        End Try
    End Sub


    Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        'obtenerCodigosHoy()
        listarPalletsPendientes()
        listarPalletsCerrados()
        listarResumen()
        actualizarEtiquetas()
        txtCodigo.Focus()
    End Sub

    Private Sub btnCerrarPallet_Click(sender As Object, e As EventArgs) Handles btnCerrarPallet.Click
        If idPalletActual <> "" And dgvPalletsPendientes.SelectedRows.Count = 1 Then
            Dim respuesta As New DialogResult
            respuesta = MessageBox.Show("Esta seguro que desea cerrar el pallet: " + descripcionPalletActual + "?", "Cerrar Pallet", MessageBoxButtons.YesNo)
            If respuesta = Windows.Forms.DialogResult.Yes Then
                cerrarPallet()
            End If
        ElseIf dgvPalletsPendientes.SelectedRows.Count > 1 Then
            Dim respuesta As New DialogResult
            respuesta = MessageBox.Show("Esta seguro que desea cerrar " + dgvPalletsPendientes.SelectedRows.Count.ToString + " pallets pendientes?", "Cerrar Pallet", MessageBoxButtons.YesNo)
            If respuesta = Windows.Forms.DialogResult.Yes Then
                cerrarPallet(dgvPalletsPendientes.SelectedRows)
            End If
        Else
            MessageBox.Show("Debe seleccionar un pallet para cerrarlo.")
        End If
    End Sub

    Private Sub cerrarPallet()
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdPallet", idPalletActual)
        If doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_CerrarPallet", p, TipoQuery.NonQuery) Then
            listarPalletsPendientes()
            listarPalletsCerrados()
            listarResumen()
            MessageBox.Show("El pallet " + descripcionPalletActual + " se ha cerrado, defina o elija un nuevo pallet para continuar leyendo códigos.")
            iCajas = 0
            nCajaActual = 1
            maxCajas = 0
            idPalletActual = String.Empty
            idLineaActual = String.Empty
            descripcionPalletActual = "No hay pallet seleccionado."
            lblDescripcionPalletActual.Text = descripcionPalletActual
            dtCajasDelPalletActual = Nothing
            'tCodigo.Enabled = False
        End If
    End Sub

    Private Sub cerrarPallet(filas As DataGridViewSelectedRowCollection)
        Try
            For Each f As DataGridViewRow In filas
                idPalletActual = f.Cells(1).Value
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdPallet", idPalletActual)
                If Not doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_CerrarPallet", p, TipoQuery.NonQuery) Then
                    Throw New Exception("No se pudo cerrar el pallet: " + idPalletActual)
                End If
            Next
            listarPalletsPendientes()
            listarPalletsCerrados()
            listarResumen()
            MessageBox.Show("Se han cerrado los pallets seleccionados, defina o elija un nuevo pallet para continuar leyendo códigos.")
            iCajas = 0
            nCajaActual = 1
            maxCajas = 0
            idPalletActual = String.Empty
            idLineaActual = String.Empty
            descripcionPalletActual = "No hay pallet seleccionado."
            lblDescripcionPalletActual.Text = descripcionPalletActual
            dtCajasDelPalletActual = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub pkrDia_ValueChanged(sender As Object, e As EventArgs) Handles pkrDia.ValueChanged
        obtenerCodigosHoy()
        listarPalletsPendientes()
        listarPalletsCerrados()
        listarResumen()
        actualizarEtiquetas()
        txtCodigo.Focus()
    End Sub

    Sub clickearDgvPalletsPendientes(idPallet As String)
        For i As Integer = 0 To dgvPalletsPendientes.Rows.Count - 1 Step 1
            If dgvPalletsPendientes.Rows(i).Cells(1).Value = idPallet Then
                dgvPalletsPendientes_CellClick(New Object, New DataGridViewCellEventArgs(1, i))
                Exit For
            End If
        Next
    End Sub

    Private Sub btnLimpiarVariables_Click(sender As Object, e As EventArgs) Handles btnLimpiarVariables.Click
        txtCodigo.Text = ""
        lblSel_CajAct.Text = ""
        lblPes_CajAct.Text = ""
        lblEmp_CajAct.Text = ""
        codSel = ""
        codPes = ""
        codEmp = ""
        txtCodigo.Focus()
    End Sub

End Class