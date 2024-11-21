<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimiento_ConfiguracionLongitudCodigoGeneral
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
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboLongitudCodigoGeneral = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 4
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboLongitudCodigoGeneral, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardar, 2, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 4
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(434, 101)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Longitud de Codigo General:"
        '
        'cboLongitudCodigoGeneral
        '
        Me.cboLongitudCodigoGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLongitudCodigoGeneral.FormattingEnabled = True
        Me.cboLongitudCodigoGeneral.Location = New System.Drawing.Point(216, 25)
        Me.cboLongitudCodigoGeneral.Name = "cboLongitudCodigoGeneral"
        Me.cboLongitudCodigoGeneral.Size = New System.Drawing.Size(150, 21)
        Me.cboLongitudCodigoGeneral.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGuardar.Location = New System.Drawing.Point(216, 52)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 23)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmMantenimiento_ConfiguracionLongitudCodigoGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 101)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.MaximumSize = New System.Drawing.Size(450, 140)
        Me.MinimumSize = New System.Drawing.Size(450, 140)
        Me.Name = "frmMantenimiento_ConfiguracionLongitudCodigoGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento / Configuracion de Longitud de Codigo General"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cboLongitudCodigoGeneral As ComboBox
    Friend WithEvents btnGuardar As Button
End Class
