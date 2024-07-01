Imports Logica.Utiles
Imports Logica.Funciones
Imports Datos.Conexion
Imports Entidades
Imports Entidades.Temporales
'Imports DocumentFormat.OpenXml.Wordprocessing
Public Class frmLogistica_Movimientos_ServiciosTransporte_Moviles

    Dim dtPedidos, dtPedidosDetalle As DataTable
    Dim tablaResultado As DataTable
    Dim tablaResultadoDetalle As DataTable
    Dim miPedido As PedidoServicioTransportes
    Dim arrayDeParametros As String = String.Empty
    Dim cadena As String = String.Empty
    Public servicioActual As New ServicioTransporte
    Dim observaciones As String = String.Empty

    Private Sub frmLogistica_Movimientos_ServiciosTransporte_NuevoAdjuntar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        dtpDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        dtpHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True

    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", CType(dtpDesde.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@Hasta", CType(dtpHasta.Value.ToString("dd/MM/yyyy"), DateTime))
            'p.Add("@Busqueda", CType(PlacaVeh.Text.ToString(), String))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("ConectarMovil", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    Private Async Function consultardetalleAsync(idserviciotransporte As String) As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim q As New Dictionary(Of String, Object)
            q.Add("@Idserviciotransporte", idserviciotransporte)
            arrayDeParametros = obtenerCadenaParametros(q)
            aux = Await Task.Run(Function() doItBaby("ConectarMovil_Detalle", q, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
        If e.RowIndex >= 0 Then
            dgvResultadoDetalle.DataSource = Nothing
            tablaResultadoDetalle = Nothing
            dgvResultadoDetalle.Columns.Clear()
            Dim dgv As Task(Of DataTable)
            encenderControlesDeEspera(barProgreso, lblResultado)
            dgv = consultardetalleAsync(dgvResultado.Rows(e.RowIndex).Cells(1).Value)
            'dgvResultado.DataSource = Await dgv
            tablaResultadoDetalle = Await dgv
            corregirTabla(tablaResultadoDetalle)
            dgvResultadoDetalle.DataSource = tablaResultadoDetalle
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultadoDetalle.RowCount)
            corregirCeldas(dgvResultadoDetalle)
            formatearDataGridView(dgvResultadoDetalle)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim r As New Dictionary(Of String, Object)
        r.Add("@Modulo", "Logistica")
        r.Add("@Dia", dgvResultado.SelectedRows(0).Cells(2).Value)
        If doItBaby("sp_Dg_ConsultarEstadoDia", r, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede eliminar el Servicio porque el dia se encuentra cerrado.")
            Exit Sub
        End If
        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para confirmar")
        Else
            Dim a As Integer
            a = MsgBox("Desea realizar la eliminación de los registro(s) seleccionados", 36, "Mensaje del Sistema")
            If a = 6 Then
                Dim p As New Dictionary(Of String, Object)
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        p.Add("@Id", fila.Cells(1).Value)
                        ''p.Add("@IdUsuario", usuarioActual)
                        doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_Moviles_EliminarServicioTransporte", p, TipoQuery.DataTable)
                        p.Clear()
                    Next
                    btnAprobar.Enabled = False
                    MessageBox.Show("Registro eliminado(s) correctamente.")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                Return
            End If
        End If

    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click

        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para confirmar")
        Else
            Dim a As Integer
            a = MsgBox("Desea realizar la confirmación de los registro(s) seleccionados", 36, "Mensaje del Sistema")
            If a = 6 Then
                Dim p As New Dictionary(Of String, Object)
                Try
                    For Each fila As DataGridViewRow In dgvResultado.SelectedRows
                        p.Add("@Idserviciotransporte", fila.Cells(1).Value)
                        p.Add("@IdUsuario", usuarioActual)
                        doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_Moviles", p, TipoQuery.DataTable)
                        p.Clear()
                    Next
                    btnAprobar.Enabled = False
                    MessageBox.Show("Registros guardados correctamente.")
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                Return
            End If
        End If

    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
        btnAprobar.Enabled = True
    End Sub

End Class
