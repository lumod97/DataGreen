<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Dg_VisualizadorGenericoDeReportes
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
        Me.rvVisualizador = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvVisualizador
        '
        Me.rvVisualizador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvVisualizador.Location = New System.Drawing.Point(0, 0)
        Me.rvVisualizador.Name = "rvVisualizador"
        Me.rvVisualizador.Size = New System.Drawing.Size(771, 362)
        Me.rvVisualizador.TabIndex = 0
        '
        'frm_Dg_VisualizadorGenericoDeReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 362)
        Me.Controls.Add(Me.rvVisualizador)
        Me.Name = "frm_Dg_VisualizadorGenericoDeReportes"
        Me.Text = "frm_Dg_VisualizadorGenericoDeReportes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvVisualizador As Microsoft.Reporting.WinForms.ReportViewer
End Class
