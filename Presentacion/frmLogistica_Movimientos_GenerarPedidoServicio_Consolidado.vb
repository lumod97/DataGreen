﻿Imports Entidades.Temporales

Public Class frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado

    Dim idPedidoServicio As String
    Dim mantenerAbierto As Boolean = True

    Public Sub New(idPS As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        idPedidoServicio = idPS
    End Sub
    Private Sub frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado_Load_Created(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not mantenerAbierto Then
            Me.Close()
        End If
    End Sub
    Private Sub frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'ds_Dg_Reportes.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado' Puede moverla o quitarla según sea necesario.

        Try
            Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado, idPedidoServicio, usuarioActual)
            mantenerAbierto = True
            Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_Marcas, idPedidoServicio, usuarioActual)

            Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter.Adapter.SelectCommand.CommandTimeout = 999999
            Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter.Adapter.SelectCommand.CommandTimeout = 999999
            Me.ReportViewer1.RefreshReport()
        Catch ex As System.Data.ConstraintException
            mantenerAbierto = False
            MessageBox.Show("Existe un servicio de transporte duplicado en la tabla ServiciosTransporteVsPedidosServicio, por favor comuniquelo al área de Sistemas")
            'Me.ReportViewer1.RefreshReport()
            Me.ReportViewer1.Dispose()
        End Try
    End Sub

End Class