Public Class frmExportaciones_Reportes_PackingList_Detalle
    Dim idPackingList As String

    Public Sub New(idPL As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        idPackingList = idPL
    End Sub

    Private Sub frmExportaciones_Reportes_PackingList_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T1' Puede moverla o quitarla según sea necesario.
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T1, idPackingList)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T2, idPackingList)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T3, idPackingList)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T4, idPackingList)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class