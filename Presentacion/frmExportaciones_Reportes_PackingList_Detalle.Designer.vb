<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportaciones_Reportes_PackingList_Detalle
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_Dg_Reportes = New DataGreen.ds_Dg_Reportes()
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter()
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter()
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter()
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "cd_Exportaciones_PackingList_T1"
        ReportDataSource1.Value = Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource
        ReportDataSource2.Name = "cd_Exportaciones_PackingList_T2"
        ReportDataSource2.Value = Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource
        ReportDataSource3.Name = "cd_Exportaciones_PackingList_T3"
        ReportDataSource3.Value = Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource
        ReportDataSource4.Name = "cd_Exportaciones_PackingList_T4"
        ReportDataSource4.Value = Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DataGreen.rpte_Dg_Exportaciones_PackingList.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(739, 406)
        Me.ReportViewer1.TabIndex = 0
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource.DataMember = "sp_Dg_Exportaciones_Reportes_PackingList_T1"
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'ds_Dg_Reportes
        '
        Me.ds_Dg_Reportes.DataSetName = "ds_Dg_Reportes"
        Me.ds_Dg_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource.DataMember = "sp_Dg_Exportaciones_Reportes_PackingList_T2"
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource.DataMember = "sp_Dg_Exportaciones_Reportes_PackingList_T3"
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource.DataMember = "sp_Dg_Exportaciones_Reportes_PackingList_T4"
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter.ClearBeforeFill = True
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter.ClearBeforeFill = True
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter.ClearBeforeFill = True
        '
        'sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter
        '
        Me.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter.ClearBeforeFill = True
        '
        'frmExportaciones_Reportes_PackingList_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 406)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmExportaciones_Reportes_PackingList_Detalle"
        Me.Text = "frmExportaciones_Reportes_PackingList_Detalle"
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_Dg_Reportes As DataGreen.ds_Dg_Reportes
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T3BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T2TableAdapter
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T3TableAdapter
    Friend WithEvents sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T4TableAdapter
End Class
