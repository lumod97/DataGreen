Imports Logica.Utiles
Imports Datos.Conexion
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades

Public Class frmLogistica_Movimientos_GenerarPedidoServicio_Detalle
    Dim dsMetadatos As DataSet
    Dim dtConsolidados, dtDisponibles As DataTable
    Dim bsDisponibles As New BindingSource
    Dim dvDisponibles As New DataView

    'OBJETOS ABSTRACTOS
    'Dim dgvResultado As DataGridView = New DataGridView()
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
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

    Public Sub New(pedido As PedidoServicioTransportes)
        InitializeComponent()
        miPedido = pedido
    End Sub

    Private Sub frmLogistica_Movimientos_GenerarPedidosServicio_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerMetaDatos()
        usarMetadatos()
        actualizarCabecera()
        actualizarTotales()

        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMetaDatos()
        dsMetadatos = New DataSet
        'Dim dtAux As New DataTable
        'dtAux = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_Detalle_ObtenerProveedores", Nothing, TipoQuery.DataTable)
        dsMetadatos.Tables.Add(doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_Detalle_ObtenerProveedores", Nothing, TipoQuery.DataTable))
        dsMetadatos.Tables(0).TableName = "Proveedores"
        dsMetadatos.Tables.Add(doItBaby("sp_Gen_ObtenerSucursales", Nothing, TipoQuery.DataTable))
        dsMetadatos.Tables(1).TableName = "Sucursales"
        dsMetadatos.Tables.Add(doItBaby("sp_Gen_ObtenerAlmacenes", Nothing, TipoQuery.DataTable))
        dsMetadatos.Tables(2).TableName = "Almacenes"
        dsMetadatos.Tables.Add(doItBaby("sp_Gen_ObtenerAreas", Nothing, TipoQuery.DataTable))
        dsMetadatos.Tables(3).TableName = "Areas"
        dsMetadatos.Tables.Add(doItBaby("sp_Gen_ObtenerMonedas", Nothing, TipoQuery.DataTable))
        dsMetadatos.Tables(4).TableName = "Monedas"
        'dsMetadatos.Tables.Add(doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_Detalle_ObtenerServiciosDisponibles", Nothing, TipoQuery.DataTable))
        'dsMetadatos.Tables(5).TableName = "Disponibles"
        dtDisponibles = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_Detalle_ObtenerServiciosDisponibles", Nothing, TipoQuery.DataTable)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdPedido", miPedido.Id)
        dtConsolidados = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicioTransporte_Detalle_ObtenerServiciosConsolidados", p, TipoQuery.DataTable)
        'dtConsolidados = dtDisponibles.Clone 'dsMetadatos.Tables(5).Clone
    End Sub

    Private Sub usarMetadatos()
        cargarCombo(cboRuc, dsMetadatos.Tables("Proveedores"), 0, 0)
        cargarCombo(cboRazonSocial, dsMetadatos.Tables("Proveedores"), 0, 1)
        cargarCombo(cboSucursal, dsMetadatos.Tables("Sucursales"), 0, 2)
        cargarCombo(cboArea, dsMetadatos.Tables("Areas"), 0, 2)
        cargarCombo(cboMoneda, dsMetadatos.Tables("Monedas"), 0, 1)
        Try
            dvDisponibles = New DataView(dtDisponibles)
            bsDisponibles.DataSource = dvDisponibles
            dgvDisponibles.DataSource = bsDisponibles
            formatearDataGridView(dgvDisponibles)
            bsDisponibles.Filter = String.Empty 'String.Format("T_Ruc = ''")
        Catch ex As Exception
            MessageBox.Show("Ningun registro valido.")
        End Try
        'dgvDisponibles.DataSource = dtDisponibles 'dsMetadatos.Tables(5)

        dgvConsolidados.DataSource = dtConsolidados
        formatearDataGridView(dgvDisponibles)
        formatearDataGridView(dgvConsolidados)
    End Sub

    Private Sub cboRuc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRuc.SelectionChangeCommitted
        cboRazonSocial.SelectedValue = cboRuc.SelectedValue
        bsDisponibles.Filter = String.Format("T_Ruc = '" & cboRuc.SelectedValue & "'")
        miPedido.Ruc = cboRuc.SelectedValue
    End Sub

    Private Sub cboRazonSocial_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRazonSocial.SelectionChangeCommitted
        cboRuc.SelectedValue = cboRazonSocial.SelectedValue
        bsDisponibles.Filter = String.Format("T_Ruc = '" & cboRuc.SelectedValue & "'")
    End Sub

    Private Sub cboRazonSocial_Leave(sender As Object, e As EventArgs) Handles cboRazonSocial.Leave
        If Len(cboRazonSocial.Text) > 0 Then
            cboRazonSocial.SelectedValue = buscarRegistro(cboRazonSocial.Text, dsMetadatos.Tables("Proveedores"), 1, 0)
            'servicioActual.RucProveedor = cboRazonSocial.SelectedValue
            cboRuc.SelectedValue = cboRazonSocial.SelectedValue 'servicioActual.RucProveedor
            bsDisponibles.Filter = String.Format("T_Ruc = '" & cboRuc.SelectedValue & "'")
            miPedido.Ruc = cboRazonSocial.SelectedValue
        End If
    End Sub

    Private Sub cboSucursal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSucursal.SelectionChangeCommitted
        Dim dt As New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdSucursal", cboSucursal.SelectedValue)
        dt = doItBaby("sp_Gen_ObtenerAlmacenes", p, TipoQuery.DataTable)
        'dsMetadatos.Tables(2).Clear() ' = doItBaby("sp_Gen_ObtenerSucursales", Nothing, TipoQuery.DataTable)
        'dsMetadatos.Tables.Item(2) = New DataTable
        dsMetadatos.Tables.Remove("Almacenes")
        dt.TableName = "Almacenes"
        dsMetadatos.Tables.Add(dt)
        cargarCombo(cboAlmacen, dsMetadatos.Tables("Almacenes"), 0, 2)
        'cboAlmacen.DataSource = dsMetadatos.Tables("Almacenes")
        miPedido.IdSucursal = cboSucursal.SelectedValue
    End Sub

    Private Sub dgvDisponibles_DoubleClick(sender As Object, e As EventArgs) Handles dgvDisponibles.DoubleClick
        Dim i As Integer = dgvDisponibles.CurrentRow.Index
        If i >= 0 Then
            'pasarFilaALaDerecha(i)
            btnPasarALaDerecha_Click(New Object, New EventArgs)
        End If
    End Sub

    Private Sub pasarFilaALaDerecha(i As Integer)
        Dim f As DataRow = dtDisponibles.NewRow
        f = dtDisponibles.Rows(i)
        'f = dgvDisponibles.Rows(i).DataBoundItem.Row
        dtConsolidados.ImportRow(f)
        miPedido.Total += f.Item("D2Total")
        'dtDisponibles.Rows.Remove(f)
        'dgvDisponibles.ClearSelection()
        'If dgvDisponibles.Rows.Count > 0 Then

        '    dgvDisponibles.CurrentCell = dgvDisponibles.Rows(0).Cells(0)
        '    dgvDisponibles.Rows(0).Selected = True
        'End If
        'actualizarCabecera()
        actualizarTotales()
    End Sub

    Private Sub pasarFilaALaIzquierda(i As Integer)
        Dim f As DataRow
        f = dgvConsolidados.Rows(i).DataBoundItem.Row
        dtDisponibles.ImportRow(f)
        miPedido.Total -= f.Item("D2Total")
        'dtConsolidados.Rows.Remove(f)
        ''dgvConsolidados.ClearSelection()
        'If dtConsolidados.Rows.Count > 0 Then
        '    dgvConsolidados.CurrentCell = dgvConsolidados.Rows(0).Cells(0)
        '    dgvConsolidados.Rows(0).Selected = True
        'End If
        'actualizarCabecera()
        actualizarTotales()
    End Sub

    Private Sub dgvConsolidados_DoubleClick(sender As Object, e As EventArgs) Handles dgvConsolidados.DoubleClick
        Dim i As Integer = dgvConsolidados.CurrentRow.Index
        If i >= 0 Then
            'pasarFilaALaIzquierda(i)
            btnPasarALaIzquierda_Click(New Object, New EventArgs)
        End If
    End Sub

    Private Sub btnPasarALaDerecha_Click(sender As Object, e As EventArgs) Handles btnPasarALaDerecha.Click
        Try
            Dim i As Integer = dgvDisponibles.CurrentRow.Index
            Dim idServicio As String
            Dim indice As Integer
            If i >= 0 AndAlso dgvDisponibles.SelectedRows.Count > 0 Then
                For Each f As DataGridViewRow In dgvDisponibles.SelectedRows
                    idServicio = f.Cells("T_IdServicio").Value.ToString 'dgvDisponibles.CurrentRow.Cells("T_IdServicio").Value.ToString
                    indice = obtenerIndex(dtDisponibles, "T_IdServicio", idServicio)
                    pasarFilaALaDerecha(indice)
                    miPedido.Servicios.Add(idServicio)
                Next
                For Each item As String In miPedido.Servicios
                    indice = obtenerIndex(dtDisponibles, "T_IdServicio", item)
                    If indice >= 0 AndAlso indice < dtDisponibles.Rows.Count Then
                        dtDisponibles.Rows.RemoveAt(obtenerIndex(dtDisponibles, "T_IdServicio", item))
                    End If
                Next
                dgvDisponibles.ClearSelection()
                If dgvDisponibles.Rows.Count > 0 Then

                    dgvDisponibles.CurrentCell = dgvDisponibles.Rows(0).Cells(0)
                    dgvDisponibles.Rows(0).Selected = True
                End If
            Else
                MessageBox.Show("Debe de seleccionar una fila de la grilla DISPONIBLES.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPasarALaIzquierda_Click(sender As Object, e As EventArgs) Handles btnPasarALaIzquierda.Click
        Try
            Dim i As Integer = dgvConsolidados.CurrentRow.Index
            Dim idServicio As String
            Dim indice As Integer
            Dim l As New List(Of String)
            If i >= 0 AndAlso dgvConsolidados.SelectedRows.Count > 0 Then
                For Each f As DataGridViewRow In dgvConsolidados.SelectedRows
                    idServicio = f.Cells("T_IdServicio").Value.ToString 'dgvDisponibles.CurrentRow.Cells("T_IdServicio").Value.ToString
                    indice = obtenerIndex(dtConsolidados, "T_IdServicio", idServicio)
                    pasarFilaALaIzquierda(indice)
                    'miPedido.Servicios.Remove(idServicio)
                    l.Add(idServicio)
                Next
                For Each item As String In l
                    indice = obtenerIndex(dtConsolidados, "T_IdServicio", item)
                    If indice >= 0 AndAlso indice < dtConsolidados.Rows.Count Then
                        dtConsolidados.Rows.RemoveAt(obtenerIndex(dtConsolidados, "T_IdServicio", item))
                    End If
                Next
                dgvConsolidados.ClearSelection()
                If dtConsolidados.Rows.Count > 0 Then
                    dgvConsolidados.CurrentCell = dgvConsolidados.Rows(0).Cells(0)
                    dgvConsolidados.Rows(0).Selected = True
                End If
            Else
                MessageBox.Show("Debe de seleccionar una fila de la grilla DISPONIBLES.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Dim i As Integer = dgvConsolidados.CurrentRow.Index
        'Dim idServicio As String
        'If i >= 0 Then
        '    For Each f As DataGridViewRow In dgvConsolidados.SelectedRows
        '        idServicio = dgvConsolidados.CurrentRow.Cells("T_IdServicio").Value.ToString
        '        pasarFilaALaIzquierda(obtenerIndex(dtConsolidados, "T_IdServicio", idServicio))
        '        miPedido.Servicios.Remove(idServicio)
        '    Next
        '    'For Each f As DataGridViewRow In dgvConsolidados.SelectedRows
        '    '    'pasarFilaALaIzquierda(i)
        '    '    miPedido.Servicios.Remove(dtConsolidados.Rows(i).Item("T_IdServicio"))
        '    'Next
        'Else
        '    MessageBox.Show("Debe de seleccionar una fila de la grilla CONSOLIDADOS.")
        'End If
    End Sub

    Private Function obtenerIndex(dtSource As DataTable, nombreCelda As String, valorBuscado As String) As Integer
        'Dim s As String = nombreCelda & " = '" & valorBuscado & "'"
        Dim i As Integer = 0 ' dtSource.Rows.IndexOf(dtSource.Select(s)(0))
        For Each f As DataRow In dtSource.Rows
            If f.Item(nombreCelda).ToString = valorBuscado Then
                Return i
            Else
                i += 1
            End If
        Next
        Return -1
    End Function

    Private Sub actualizarCabecera()
        lblIdPedido.Text = miPedido.Id
        lblIdDocumento.Text = miPedido.IdDocumento
        lblSerie.Text = miPedido.Serie
        lblNumero.Text = miPedido.Numero
        lblEstado.Text = miPedido.IdEstado
        cboRuc.SelectedValue = miPedido.Ruc
        cboRazonSocial.SelectedValue = miPedido.Ruc
        lblResponsable.Text = miPedido.Responsable
        cboSucursal.SelectedValue = miPedido.IdSucursal
        If miPedido.IdSucursal <> String.Empty Then
            cboSucursal_SelectionChangeCommitted(New Object, New System.EventArgs)
        End If
        cboAlmacen.SelectedValue = miPedido.IdSucursal
        cboArea.SelectedValue = miPedido.IdArea
        cboMoneda.SelectedValue = miPedido.IdMoneda
        lblTotal.Text = miPedido.Total.ToString("F2")
        txtNota.Text = miPedido.Nota
        txtNroFactura.Text = miPedido.NroFactura
    End Sub

    Private Sub actualizarTotales()
        'lblIdPedido.Text = miPedido.Id
        'lblIdDocumento.Text = miPedido.IdDocumento
        'lblSerie.Text = miPedido.Serie
        'lblNumero.Text = miPedido.Numero
        'lblEstado.Text = miPedido.IdEstado
        'cboRuc.SelectedValue = miPedido.Ruc
        'cboRazonSocial.SelectedValue = miPedido.Ruc
        'lblResponsable.Text = miPedido.Responsable
        'cboSucursal.SelectedValue = miPedido.IdSucursal
        'If miPedido.IdSucursal <> String.Empty Then
        '    cboSucursal_SelectionChangeCommitted(New Object, New System.EventArgs)
        'End If
        'cboAlmacen.SelectedValue = miPedido.IdSucursal
        'cboArea.SelectedValue = miPedido.IdArea
        'cboMoneda.SelectedValue = miPedido.IdMoneda
        lblTotal.Text = miPedido.Total.ToString("F2")
        'txtNota.Text = miPedido.Nota
        'txtNroFactura.Text = miPedido.NroFactura
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim p As New Dictionary(Of String, Object)

            p.Add("@IdPedido", miPedido.Id)
            p.Add("@IdArea", miPedido.IdArea)
            p.Add("@IdSucursal", miPedido.IdSucursal)
            p.Add("@IdAlmacen", miPedido.IdAlmacen)
            p.Add("@Fecha", miPedido.Fecha)
            p.Add("@IdResponsable", usuarioActual) 'miPedido.Responsable)
            p.Add("@Glosa", miPedido.Nota)
            p.Add("@IdMoneda", miPedido.IdMoneda)
            p.Add("@Total", miPedido.Total)
            p.Add("@Ruc", miPedido.Ruc)
            p.Add("@NroFactura", miPedido.NroFactura)
            Dim t As DataTable = obtenerTablaParaSP(dtConsolidados, "0")

            p.Add("@dtTabla", t)
            Dim r As DataTable = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicio_Detalle_GuardarActualizarPedido", p, TipoQuery.DataTable)
            If r.Rows(0).Item("Resultado") = 1 Then
                miPedido.Id = r.Rows(0).Item("Detalle")
                actualizarCabecera()
                MessageBox.Show("Pedido guardado con exito.")
            ElseIf r.Rows(0).Item("Resultado") = 0 Then
                Throw New Exception(r.Rows(0).Item("Detalle"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function obtenerTablaParaSP(dtConsolidados As DataTable, columnas As String) As DataTable
        Dim aux As New DataTable
        For i As Integer = 1 To 20 Step 1
            aux.Columns.Add("C" & i.ToString)
        Next
        Dim cols As New List(Of Integer)
        Dim colsS As New List(Of String)
        colsS = columnas.Split(",").ToList
        For Each s As String In colsS
            cols.Add(CType(s, Integer))
        Next

        For Each f1 As DataRow In dtConsolidados.Rows
            Dim fA As DataRow = aux.NewRow
            Dim v As Integer = IIf(cols.Count >= 20, 20, cols.Count) - 1
            'For iA As Integer = 0 To aux.Columns.Count - 1 Step 1
            For iA As Integer = 0 To v Step 1
                fA.Item(iA) = f1.Item(cols.Item(iA))
                '    For i1 As Integer = 0 To dtConsolidados.Columns.Count Step 1
                '        If cols.Contains(i1) And iA = i1 Then
                '            fA.Item(iA) = f1.Item(i1)
                '        End If
                '    Next
            Next
            aux.Rows.Add(fA)
        Next
        Return aux
    End Function

    Private Sub cboAlmacen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAlmacen.SelectionChangeCommitted
        miPedido.IdAlmacen = cboAlmacen.SelectedValue
    End Sub

    Private Sub cboArea_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboArea.SelectionChangeCommitted
        miPedido.IdArea = cboArea.SelectedValue
    End Sub

    Private Sub cboMoneda_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMoneda.SelectionChangeCommitted
        miPedido.IdMoneda = cboMoneda.SelectedValue
    End Sub

    Private Sub txtNota_Leave(sender As Object, e As EventArgs) Handles txtNota.Leave
        miPedido.Nota = txtNota.Text
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim r As DialogResult
            r = MessageBox.Show("Esta seguro de eliminar el Pedido De Servicio N°:" & miPedido.Numero & "?", "Eliminar Pedido", MessageBoxButtons.YesNo)
            If r = Windows.Forms.DialogResult.Yes Then
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdPedido", miPedido.Id)
                Dim dtR As DataTable = doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidosServicio_Detalle_EliminararPedido", p, TipoQuery.DataTable)
                If dtR.Rows.Count > 0 Then
                    MessageBox.Show(dtR.Rows(0).Item("Detalle"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub dgvDisponibles_Click(sender As Object, e As EventArgs) Handles dgvDisponibles.Click
    '    MessageBox.Show(dgvDisponibles.CurrentRow.Index)
    'End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        miPedido.Fecha = dtpFecha.Value
    End Sub

    'Private Sub cboSucursal_Leave(sender As Object, e As EventArgs) Handles cboSucursal.Leave
    '    If Len(cboSucursal.Text) > 0 Then
    '        cboSucursal.SelectedValue = cboSucursal.Text
    '        'cboRazonSocial.SelectedValue = cboRuc.SelectedValue 'buscarRegistro(cboRuc.Text, dsMetadatos.Tables(1), 0, 0)
    '        'bsDisponibles.Filter = String.Format("T_Ruc = '" & cboRuc.SelectedValue & "'")
    '        'servicioActual.RucProveedor = cboRuc.SelectedValue
    '        'servicioActual.RazonSocial = buscarRegistro(cboRuc.Text, dsMetadatos.Tables(1), 0, 0)
    '        'cboRuc.SelectedValue = servicioActual.RucProveedor
    '    End If
    'End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim VenActual As New frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado(miPedido.Id)
        VenActual.MdiParent = Me.MdiParent
        VenActual.Show()
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        CheckForIllegalCrossThreadCalls = False 'ALERTA, PODRIA PRODUCIR ERROR DE MULTIHILO #ADVERTENCIA 1
        'Dim tarea1 As Task = btnConsultar_Click(New Object, New EventArgs)
        'Await tarea1
        'dgvResultado.DataSource = tablaResultado
        'MessageBox.Show(dgvResultado.RowCount)
        'Task.Delay(500)
        Dim tarea2 As Task = btnExportarAsyncClick()
        Await tarea2
        'Await Task.Run(Sub() btnConsultar_Click(New Object, New EventArgs))
        'Await Task.Run(Sub() btnExportarAsyncClick())

    End Sub

    Private Async Function btnExportarAsyncClick() As Task

        encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
        Dim aux As New DataTable
        Dim p As New Dictionary(Of String, Object)

        p.Add("@IdPedidoServicio", lblIdPedido.Text)
        p.Add("@Usuario", usuarioActual)

        arrayDeParametros = obtenerCadenaParametros(p)
        aux = Await Task.Run(Function() doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_Marcas", p, TipoQuery.DataTable))
        dgvResultado.DataSource = aux
        MessageBox.Show(dgvResultado.RowCount)
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                'encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                'Await Task.Run(Sub() btnConsultar_Click(New Object, New EventArgs))
                Await Task.Run(Sub() aExcel(aux, l, Me.Text, arrayDeParametros))
                'apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblResultado, -1)
        End Try
    End Function

    Private Async Function btnConsultar_Click(sender As Object, e As EventArgs) As Task
        dgvResultado = New DataGridView()
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResultado = Await dgv

        'corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        'dgvResultado.DataSource = Await dgv
        'MessageBox.Show(dgvResultado.RowCount)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        'corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Function

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)

            p.Add("@IdPedidoServicio", lblIdPedido.Text)
            p.Add("@Usuario", usuarioActual)

            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_Marcas", p, TipoQuery.DataTable))
            'dgvResultado.DataSource = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub cboRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRazonSocial.SelectedIndexChanged

    End Sub

    Private Sub dgvConsolidados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsolidados.CellContentClick

    End Sub

    Private Sub txtNroFactura_Leave(sender As Object, e As EventArgs) Handles txtNroFactura.Leave
        miPedido.NroFactura = txtNroFactura.Text
    End Sub
End Class