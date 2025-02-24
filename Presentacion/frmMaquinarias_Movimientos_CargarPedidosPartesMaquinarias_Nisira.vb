﻿Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmMaquinarias_Movimientos_CargarPedidosPartesMaquinarias_Nisira

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

    Private Sub frmMaquinarias_Movimientos_CargarPedidosPartesMaquinarias_Nisira_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        dtpDesde.Value = New Date(Year(Now()), Month(Now()), 1)
        dtpHasta.Value = Now()
        tlpPrincipal.Visible = True
        'btnConsultar_Click(New Object, New EventArgs)

    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", dtpDesde.Value)
            p.Add("@Hasta", dtpHasta.Value)
            p.Add("@IdUsuario", usuarioActual)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Maquinarias_Movimientos_CargarPedidosMaquinaria_Listar_Nisira", p, TipoQuery.DataTable))
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

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
            Dim l As String
            l = "Reporte"
            Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
            apagarControlesDeEspera(barProgreso, lblResultado, -1)
        End If
    End Sub

End Class