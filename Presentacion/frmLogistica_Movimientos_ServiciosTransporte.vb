Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports Entidades
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Office2010.Excel

'CORREGIR QUE NO SE PUEDE ORDENAR DANDOLE CLICK A LA CABECERA DEL DATAGRIDVIEW

Public Class frmLogistica_Movimientos_ServiciosTransporte

    Dim arrayDeParametros As String = String.Empty
    Dim dtResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Dim esNuevo As Boolean = True
    Dim observaciones As String = String.Empty
    Dim bsResultado As New BindingSource()
    Dim cadena As String = String.Empty
    Dim servicioActual As New ServicioTransporte
    Dim servicioAdjuntar As New ServicioTransporte
    Dim bsFiltro As New BindingSource()

    Dim primerClick As DateTime

    Dim miPedido As PedidoServicioTransportes

    Private Sub frmLogistica_Movimientos_ServiciosTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        primerClick = Now
        aplicarTema(Me)
        'cargarDataGridViewResultado()
        dtpDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        dtpHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)

        obtenerMetaDatos()
        usarMetadatos()
        'OBTENER METADATOS DEL DETALLE
        'obtenerMetadatosDetalle()
        'cargarControlesExternos()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMetaDatos()
        Try
            dtResultado = New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@fechaini", dtpDesde.Value.ToString("yyyy-MM-dd"))
            p.Add("@fechafin", dtpHasta.Value.ToString("yyyy-MM-dd"))
            dtResultado = doItBaby("sp_Filtro_MovimientoServicio_Transporte", p, TipoQuery.DataTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub usarMetadatos()

        txtFiltro.Text = ""
        Dim dvVehiculos As New DataView(dtResultado)
        bsFiltro.DataSource = dvVehiculos
        dgvResultado.DataSource = bsFiltro
        formatearDataGridView(dgvResultado)
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub transcribirCabecera()
        lblId.Text = servicioActual.Id
        lblFecha.Text = servicioActual.Fecha
        lblEstado.Text = servicioActual.Estado
        lblUsuario.Text = servicioActual.UsuarioCrea
        lblObservaciones.Text = servicioActual.Obs
        lblNroFactura.Text = servicioActual.NroFactura
        lblRuc.Text = servicioActual.RucProveedor
        lblDniConductor.Text = servicioActual.DniConductor
        lblIdRuta.Text = servicioActual.IdRuta
        lblOrdenServicio.Text = servicioActual.IdPedidoServicio
        txtRazonSocial.Text = servicioActual.RazonSocial
        lblConductor.Text = servicioActual.Conductor
        lblRuta.Text = servicioActual.Ruta
        lblPlaca.Text = servicioActual.Placa
        lblMarca.Text = servicioActual.Marca
        lblModelo.Text = servicioActual.Modelo
        lblColor.Text = servicioActual.Color
        lblPasajeros.Text = servicioActual.Pasajeros.ToString
        lblTarifa.Text = servicioActual.Tarifa.ToString("F3")
        lblDscto.Text = servicioActual.Dscto.ToString("F3")
        lblTotal.Text = servicioActual.Total.ToString("F3")

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If servicioActual IsNot Nothing Then
            abrirDetalle(servicioActual)
        Else
            MessageBox.Show("Debe de seleccionar un registro para editarlo.")
        End If

    End Sub

    Private Sub abrirDetalle(servicio As ServicioTransporte)
        'Dim cb As New ComboBox
        Dim VenActual As New frmLogistica_Movimientos_ServiciosTransporte_Detalle(servicio)
        VenActual.servicioActual = servicio
        VenActual.MdiParent = Me.MdiParent
        VenActual.Show()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        servicioActual = New ServicioTransporte
        abrirDetalle(servicioActual)
    End Sub

    Private Sub frmLogistica_Movimientos_ServiciosTransporte_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If dgvResultado.RowCount > 0 Then
            obtenerMetaDatos()
            usarMetadatos()
        End If
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsFiltro.Filter = String.Format("T_Id like '%{0}%' Or " +
                                                "T_Id like '%{1}%' Or " +
                                                "T_NroFactura like '%{2}%' Or " +
                                                "T_Ruta like '%{4}%' Or " +
                                                "T_RucProveedor like '%{5}%' Or " +
                                                "T_Placa like '%{5}%' Or " +
                                                "T_DniConductor like '%{5}%' Or " +
                                                "T_Conductor like '%{5}%' Or " +
                                                "T_RazonSocial like '%{6}%'",
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text)
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Logistica")
        p.Add("@Dia", servicioActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede eliminar el Servicio porque el dia se encuentra cerrado.")
            Exit Sub
        End If
        If dgvResultado.SelectedRows Is Nothing Or lblId.Text = "000000000000" Then
            MessageBox.Show("Para eliminar un registro debe seleccionarlo primero.")
        ElseIf servicioActual.UsuarioCrea <> usuarioActual Then 'And usuarioActual <> "JMERA" And usuarioActual <> "NBRAVO" Then
            MessageBox.Show("No tiene permisos para eliminar este registro")
        Else
            bloquearFilas(dgvResultado)
            Dim id As String = servicioActual.Id
            Dim respuesta As DialogResult = Windows.Forms.DialogResult.No
            Dim mensaje As String
            If dgvResultado.SelectedRows.Count = 1 Then
                mensaje = String.Format("Esta seguro de eliminar el registro: {0}", servicioActual.Id)
            Else
                mensaje = String.Format("Esta seguro de eliminar {0} registros(s).", dgvResultado.SelectedRows.Count)
            End If
            respuesta = MessageBox.Show(mensaje, "Eliminar registro", MessageBoxButtons.YesNo)
            If respuesta = DialogResult.Yes Then
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        id = fila.Cells(0).Value.ToString
                        Dim parametros = New Dictionary(Of String, Object)
                        parametros.Add("@Id", id)
                        doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_EliminarServicioTransporte", parametros, Datos.Conexion.TipoQuery.NonQuery)
                    Next
                    MessageBox.Show("Registro eliminado correctamente.")
                    obtenerMetaDatos()
                    usarMetadatos()
                    'dgvResultado_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(1, 1, 1, 1, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 1, 1, 1))) '1, dgvResultado.SelectedRows(0).Index))
                Catch ex As Exception
                    MessageBox.Show("Error al tratar de eliminar registro. " + ex.Message)
                End Try
            End If
            desbloquearFilas(dgvResultado)
        End If
    End Sub

    Private Sub lblPlaca_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lblPlaca.MouseDoubleClick
        Clipboard.SetDataObject(lblPlaca.Text, False)
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            servicioActual.Valor = dgvResultado.Rows(e.RowIndex)
            transcribirCabecera()
        End If
    End Sub

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            servicioActual.Valor = dgvResultado.Rows(e.RowIndex)
            'Dim x As New DataGridViewCellMouseEventArgs(1, 1, 1, 1, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 1, 1, 1))
            transcribirCabecera()
            abrirDetalle(servicioActual)
        End If
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultaAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)

    End Sub
    Private Async Function consultaAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@fechaini", dtpDesde.Value.ToString("yyyy-MM-dd"))
            p.Add("@fechafin", dtpHasta.Value.ToString("yyyy-MM-dd"))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Filtro_MovimientoServicio_Transporte", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub abrirDetalleAdjuntar(pedido As PedidoServicioTransportes)
    '    Dim v As New frmLogistica_Movimientos_ServiciosTransporte_Detalle(pedido)
    '    v.MdiParent = Me.MdiParent
    '    v.Show()
    'End Sub


    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnMoviles.Click

        'frmLogistica_Movimientos_ServiciosTransporte_NuevoAdjuntar.Show()
        Dim VenActual As New frmLogistica_Movimientos_ServiciosTransporte_Moviles
        VenActual.MdiParent = Me.MdiParent
        VenActual.Show()
    End Sub

End Class