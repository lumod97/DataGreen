<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_CorrespondenciaVacacional
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvDuplicados = New System.Windows.Forms.DataGridView()
        Me.txtCodigoDni = New System.Windows.Forms.TextBox()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox()
        Me.radPlanilla = New System.Windows.Forms.RadioButton()
        Me.radCodigoDni = New System.Windows.Forms.RadioButton()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.tlpPrincipal.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDuplicados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 12
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label3, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.TabControl1, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtCodigoDni, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPeriodo, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.radPlanilla, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.radCodigoDni, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 2, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 6
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1088, 502)
        Me.tlpPrincipal.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(581, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Periodo Anual:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(914, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 6
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(995, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 10)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(19, 448)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1051, 23)
        Me.barProgreso.TabIndex = 9
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResultado, 2)
        Me.lblResultado.Location = New System.Drawing.Point(19, 474)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 10
        Me.lblResultado.Text = "Listo!"
        '
        'TabControl1
        '
        Me.tlpPrincipal.SetColumnSpan(Me.TabControl1, 10)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(19, 47)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1051, 395)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvResumen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1043, 369)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Planilla Resumen"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResumen.Location = New System.Drawing.Point(3, 3)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.Size = New System.Drawing.Size(1037, 363)
        Me.dgvResumen.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDuplicados)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1043, 369)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registros Detallados"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvDuplicados
        '
        Me.dgvDuplicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDuplicados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDuplicados.Location = New System.Drawing.Point(3, 3)
        Me.dgvDuplicados.Name = "dgvDuplicados"
        Me.dgvDuplicados.Size = New System.Drawing.Size(1037, 363)
        Me.dgvDuplicados.TabIndex = 8
        '
        'txtCodigoDni
        '
        Me.txtCodigoDni.Location = New System.Drawing.Point(475, 18)
        Me.txtCodigoDni.Name = "txtCodigoDni"
        Me.txtCodigoDni.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoDni.TabIndex = 14
        '
        'cboPeriodo
        '
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(663, 18)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(168, 21)
        Me.cboPeriodo.TabIndex = 15
        '
        'radPlanilla
        '
        Me.radPlanilla.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.radPlanilla.AutoSize = True
        Me.radPlanilla.Location = New System.Drawing.Point(19, 21)
        Me.radPlanilla.Name = "radPlanilla"
        Me.radPlanilla.Size = New System.Drawing.Size(80, 17)
        Me.radPlanilla.TabIndex = 16
        Me.radPlanilla.TabStop = True
        Me.radPlanilla.Text = "Por Planilla:"
        Me.radPlanilla.UseVisualStyleBackColor = True
        '
        'radCodigoDni
        '
        Me.radCodigoDni.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.radCodigoDni.AutoSize = True
        Me.radCodigoDni.Location = New System.Drawing.Point(361, 21)
        Me.radCodigoDni.Name = "radCodigoDni"
        Me.radCodigoDni.Size = New System.Drawing.Size(108, 17)
        Me.radCodigoDni.TabIndex = 17
        Me.radCodigoDni.TabStop = True
        Me.radCodigoDni.Text = "Por Codigo o Dni:"
        Me.radCodigoDni.UseVisualStyleBackColor = True
        '
        'cboPlanilla
        '
        Me.cboPlanilla.DropDownWidth = 200
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(105, 18)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(250, 21)
        Me.cboPlanilla.TabIndex = 18
        '
        'frmRrhh_Reportes_CorrespondenciaVacacional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 502)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_CorrespondenciaVacacional"
        Me.Text = "frmRrhh_Reportes_CorrespondenciaVacacional"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvDuplicados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnConsultar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents lblResultado As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvDuplicados As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvResumen As DataGridView
    Friend WithEvents txtCodigoDni As TextBox
    Friend WithEvents cboPeriodo As ComboBox
    Friend WithEvents radPlanilla As RadioButton
    Friend WithEvents radCodigoDni As RadioButton
    Friend WithEvents cboPlanilla As ComboBox
End Class
