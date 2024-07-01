<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_Dg_Reportes = New DataGreen.ds_Dg_Reportes()
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter()
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter()
        CType(Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource
        '
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource.DataMember = "sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado"
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'ds_Dg_Reportes
        '
        Me.ds_Dg_Reportes.DataSetName = "ds_Dg_Reportes"
        Me.ds_Dg_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource
        '
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource.DataMember = "sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_Marcas"
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource.DataSource = Me.ds_Dg_Reportes
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DataGreen.rpte_Dg_Logistica_Movimientos_GenerarPedidoServicio_Consolidado.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(654, 437)
        Me.ReportViewer1.TabIndex = 0
        '
        'sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter
        '
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter.ClearBeforeFill = True
        '
        'sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter
        '
        Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter.ClearBeforeFill = True
        '
        'frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 437)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmLogistica_Movimientos_GenerarPedidoServicio_Consolidado"
        Me.Text = "frmLogistica_Movimientos_GenerarPedido_Consolidado"
        CType(Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_Dg_Reportes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_Dg_Reportes As DataGreen.ds_Dg_Reportes
    Friend WithEvents sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_ConsolidadoTableAdapter

    Friend WithEvents sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasBindingSource As BindingSource
    Friend WithEvents sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter As DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Logistica_Movimientos_GenerarPedidoServicios_Consolidado_MarcasTableAdapter
End Class
