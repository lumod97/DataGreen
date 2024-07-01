Imports Logica.Utiles
Imports Datos.Conexion
Imports Entidades

Public Class frmLogistica_Movimientos_GenerarPedidoServicio
    '¿Dim dsMetadatos As DataSet
    Dim dtPedidos, dtPedidosDetalle As DataTable
    Dim bsPedidoDetalle As New BindingSource
    Dim arrayDeParametros As String = String.Empty

    'Structure PedidoServicio
    '    Public Id As String
    '    Public Fecha As Date
    '    Public IdDocumento As String
    '    Public Serie As String
    '    Public Numero As String
    '    Public IdEstado As String
    '    Public Estado As String
    '    Public Ruc As String
    '    Public RazonSocial As String
    '    Public Responsable As String
    '    Public IdSucursal As String
    '    Public Sucursal As String
    '    Public IdAlmacen As String
    '    Public Almacen As String
    '    Public IdArea As String
    '    Public Area As String
    '    Public IdMoneda As String
    '    Public Moneda As String
    '    Public Total As Double
    '    Public Nota As String
    'End Structure

    Dim miPedido As PedidoServicioTransportes

    Private Sub frmLogistica_Movimientos_GenerarPedidoServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        dtpDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        dtpHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)
        'obtenerMetaDatos()
        usarMetadatos()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMetaDatos()
        ' dsMetadatos = New DataSet
        dtPedidosDetalle = Nothing
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Desde", dtpDesde.Value.ToString("yyyy-MM-dd"))
        p.Add("@Hasta", dtpHasta.Value.ToString("yyyy-MM-dd"))

        'p.Add("@Desde", CType(dtpDesde.Value.ToString("dd/MM/yyyy"), DateTime))
        'p.Add("@Hasta", CType(dtpHasta.Value.ToString("dd/MM/yyyy"), DateTime))

        dtPedidos = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_ObtenerPedidos", p, TipoQuery.DataTable)
        dtPedidosDetalle = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_ObtenerPedidos_Detalle", p, TipoQuery.DataTable)
    End Sub

    Private Sub usarMetadatos()
        dgvResultado.DataSource = dtPedidos
        formatearDataGridView(dgvResultado)
        'dgvResultadoDetalle.DataSource = dtPedidosDetalle
        Dim dvPedidoDetalle As New DataView
        Try
            dvPedidoDetalle = New DataView(dtPedidosDetalle)
            bsPedidoDetalle.DataSource = dvPedidoDetalle
            dgvResultadoDetalle.DataSource = bsPedidoDetalle
            formatearDataGridView(dgvResultadoDetalle)
            bsPedidoDetalle.Filter = String.Format("T_IdPedido = ''")
        Catch ex As Exception
            MessageBox.Show("Ningun registro valido.")
        End Try
    End Sub

    Private Sub dgvResultado_Click(sender As Object, e As EventArgs) Handles dgvResultado.Click
        Dim i As Integer = dgvResultado.CurrentRow.Index
        If i >= 0 Then
            miPedido = convertirFilaEnPedido(dtPedidos.Rows(i))
            bsPedidoDetalle.Filter = String.Format("T_IdPedido = '" & miPedido.Id & "'")
            actualizarCabecera()
            formatearDataGridView(dgvResultadoDetalle)
        End If
    End Sub

    Private Function convertirFilaEnPedido(fila As DataRow) As PedidoServicioTransportes
        Dim aux As New PedidoServicioTransportes
        aux.Id = fila.Item("T_IdPedido")
        aux.Fecha = fila.Item("F_Fecha")
        aux.IdDocumento = fila.Item("T_IdDocumento")
        aux.Serie = fila.Item("T_Serie")
        aux.Numero = fila.Item("T_Numero")
        aux.IdEstado = fila.Item("T_IdEstado")
        aux.Ruc = fila.Item("T_Ruc")
        aux.RazonSocial = fila.Item("T_RazonSocial")
        aux.Responsable = fila.Item("T_Responsable")
        aux.IdSucursal = fila.Item("T_IdSucursal")
        aux.Sucursal = fila.Item("T_Sucursal")
        aux.IdAlmacen = fila.Item("T_IdAlmacen")
        aux.Almacen = fila.Item("T_Almacen")
        aux.IdArea = fila.Item("T_IdArea")
        aux.Area = fila.Item("T_Area")
        aux.IdMoneda = fila.Item("T_IdMoneda")
        aux.Moneda = fila.Item("T_Moneda")
        aux.Total = fila.Item("D2Total")
        aux.Nota = fila.Item("T_Nota")
        aux.NroFactura = fila.Item("T_NroFactura")
        Return aux
    End Function

    Private Sub actualizarCabecera()
        lblIdPedido.Text = miPedido.Id
        lblIdDocumento.Text = miPedido.IdDocumento
        lblSerie.Text = miPedido.Serie
        lblNumero.Text = miPedido.Numero
        lblEstado.Text = miPedido.IdEstado
        lblFecha.Text = miPedido.Fecha.ToString("yyyy-MM-dd")
        lblRuc.Text = miPedido.Ruc
        lblRazonSocial.Text = miPedido.RazonSocial
        lblResponsable.Text = miPedido.Responsable
        lblSucursal.Text = miPedido.Sucursal
        lblArea.Text = miPedido.Area
        lblAlmacen.Text = miPedido.Almacen
        lblMomenda.Text = miPedido.Moneda
        lblTotal.Text = miPedido.Total.ToString("F2")
        lblNroFactura.Text = miPedido.NroFactura
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        miPedido = New PedidoServicioTransportes
        abrirDetallePedido(miPedido)
    End Sub

    Private Sub abrirDetallePedido(pedido As PedidoServicioTransportes)
        Dim v As New frmLogistica_Movimientos_GenerarPedidoServicio_Detalle(pedido)
        v.MdiParent = Me.MdiParent
        v.Show()
    End Sub

    Private Sub dgvResultado_DoubleClick(sender As Object, e As EventArgs) Handles dgvResultado.DoubleClick
        'miPedido = New PedidoServicioTransportes
        Dim i As Integer = dgvResultado.CurrentRow.Index
        If i >= 0 Then
            miPedido = convertirFilaEnPedido(dtPedidos.Rows(i))
            bsPedidoDetalle.Filter = String.Format("T_IdPedido = '" & miPedido.Id & "'")
            actualizarCabecera()
            abrirDetallePedido(miPedido)
        End If
    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged, dtpDesde.ValueChanged
        obtenerMetaDatos()
        usarMetadatos()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

        obtenerMetaDatos()
        usarMetadatos()

    End Sub

    Private Sub frmLogistica_Movimientos_GenerarPedidoServicio_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        obtenerMetaDatos()
        usarMetadatos()
    End Sub
End Class