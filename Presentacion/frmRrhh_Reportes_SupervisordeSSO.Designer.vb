<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_SupervisordeSSO
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
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.pkrDesde = New System.Windows.Forms.DateTimePicker()
        Me.pkrHasta = New System.Windows.Forms.DateTimePicker()
        Me.lbl_DinResultado = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 10
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.pkrDesde, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.pkrHasta, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.lbl_DinResultado, 1, 7)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 9
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(904, 435)
        Me.tlpPrincipal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.Location = New System.Drawing.Point(710, 17)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnExportar.Location = New System.Drawing.Point(791, 17)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 8)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(17, 46)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(864, 299)
        Me.dgvResultado.TabIndex = 6
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 8)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(17, 365)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(864, 21)
        Me.barProgreso.TabIndex = 7
        '
        'pkrDesde
        '
        Me.pkrDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(64, 18)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(180, 20)
        Me.pkrDesde.TabIndex = 11
        '
        'pkrHasta
        '
        Me.pkrHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrHasta.Location = New System.Drawing.Point(294, 18)
        Me.pkrHasta.Name = "pkrHasta"
        Me.pkrHasta.Size = New System.Drawing.Size(180, 20)
        Me.pkrHasta.TabIndex = 12
        '
        'lbl_DinResultado
        '
        Me.lbl_DinResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lbl_DinResultado, 2)
        Me.lbl_DinResultado.Location = New System.Drawing.Point(17, 389)
        Me.lbl_DinResultado.Name = "lbl_DinResultado"
        Me.lbl_DinResultado.Size = New System.Drawing.Size(32, 13)
        Me.lbl_DinResultado.TabIndex = 8
        Me.lbl_DinResultado.Text = "Listo!"
        '
        'frmRrhh_Reportes_SupervisordeSSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 435)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_SupervisordeSSO"
        Me.Text = "frmRrhh_Reportes_SupervisordeSSO"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnConsultar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents lbl_DinResultado As Label
    Friend WithEvents pkrDesde As DateTimePicker
    Friend WithEvents pkrHasta As DateTimePicker
End Class
