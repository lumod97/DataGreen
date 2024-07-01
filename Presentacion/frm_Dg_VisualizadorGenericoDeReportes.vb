Public Class frm_Dg_VisualizadorGenericoDeReportes
    Friend WithEvents ds_Dg_Reportes As DataGreen.ds_Dg_Reportes
    'Todos los TableAdapters 
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter

    Friend WithEvents sp_Dg_Presupuestos_Reportes_Control_PorFundo_T1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents sp_Dg_Presupuestos_Reportes_Control_PorFundo_T1TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Presupuestos_Reportes_Control_PorFundoTableAdapter

    Dim nombreReporte As String 'Nombre del reporte sin extension
    Dim p As New Dictionary(Of String, Object) 'Diccionario de parametros

    'Private components As System.ComponentModel.IContainer

    Public Sub New(reporte As String, parametros As Dictionary(Of String, Object))
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        nombreReporte = reporte
        p = parametros
    End Sub

    Private Sub frm_Dg_VisualizadorGenericoDeReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'rvVisualizador.LocalReport.ReportEmbeddedResource = "DataGreen." + nombreReporte + ".rdlc"  '"DataGreen.rpte_Dg_Presupuestos_ControlPresupuestal_PorLoteYSector.rdlc"
        'CODIGO DE PRUEBA
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ds_Dg_Reportes = New DataGreen.ds_Dg_Reportes()

        Select Case nombreReporte
            Case "rpte_Dg_Presupuestos_ControlPresupuestal_PorLoteYSector"
                sp_Dg_Presupuestos_Reportes_Control_PorFundo_T1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
                sp_Dg_Presupuestos_Reportes_Control_PorFundo_T1TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Presupuestos_Reportes_Control_PorFundoTableAdapter

                'Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
                'Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter()
                CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).BeginInit()

                CType(sp_Dg_Presupuestos_Reportes_Control_PorFundo_T1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
                'CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()

                Me.SuspendLayout()

                ReportDataSource1.Name = "cd_Exportaciones_PackingList_T1"
                ReportDataSource1.Value = Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource
                Me.rvVisualizador.LocalReport.DataSources.Add(ReportDataSource1)
                Me.rvVisualizador.LocalReport.ReportEmbeddedResource = "DataGreen." + nombreReporte + ".rdlc" '"DataGreen.rpte_Dg_Exportaciones_PackingList.rdlc"
                Me.ds_Dg_Reportes.DataSetName = "ds_Dg_Reportes"
                Me.ds_Dg_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
                Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource.DataMember = "sp_Dg_Exportaciones_Reportes_PackingList_T1"
                Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource.DataSource = Me.ds_Dg_Reportes
                Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter.ClearBeforeFill = True
                CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).EndInit()
                CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
                Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter.Fill(Me.ds_Dg_Reportes.sp_Dg_Exportaciones_Reportes_PackingList_T1, p.Values(0))
        End Select
        'sp_Dg_Presupuestos_Reportes_Control_PorFundo
        'FIN CODIGO DE PRUEBA

        

        Me.rvVisualizador.RefreshReport()
    End Sub
    
    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource As System.Windows.Forms.BindingSource

    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter
    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter
    'Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter
End Class