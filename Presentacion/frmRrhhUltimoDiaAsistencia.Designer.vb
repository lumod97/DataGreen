<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRrhhUltimoDiaAsistencia
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cbxEma = New System.Windows.Forms.CheckBox()
        Me.cbxEmp = New System.Windows.Forms.CheckBox()
        Me.cbxFma = New System.Windows.Forms.CheckBox()
        Me.cbxObm = New System.Windows.Forms.CheckBox()
        Me.cbxPas = New System.Windows.Forms.CheckBox()
        Me.cbxPra = New System.Windows.Forms.CheckBox()
        Me.lblTodos = New System.Windows.Forms.Label()
        Me.radTodos = New System.Windows.Forms.RadioButton()
        Me.radCodigo = New System.Windows.Forms.RadioButton()
        Me.radPlanilla = New System.Windows.Forms.RadioButton()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblPlanilla = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 12
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvResultado, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodigo, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTodos, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radTodos, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radCodigo, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radPlanilla, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCodigo, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlanilla, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportar, 10, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblResultado, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 361)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvResultado, 10)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 67)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(747, 237)
        Me.dgvResultado.TabIndex = 1
        '
        'txtCodigo
        '
        Me.txtCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtCodigo.Location = New System.Drawing.Point(101, 41)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(135, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxEma)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxEmp)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxFma)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxObm)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxPas)
        Me.FlowLayoutPanel1.Controls.Add(Me.cbxPra)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(259, 41)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(327, 23)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'cbxEma
        '
        Me.cbxEma.AutoSize = True
        Me.cbxEma.Location = New System.Drawing.Point(3, 3)
        Me.cbxEma.Name = "cbxEma"
        Me.cbxEma.Size = New System.Drawing.Size(49, 17)
        Me.cbxEma.TabIndex = 0
        Me.cbxEma.Text = "EMA"
        Me.cbxEma.UseVisualStyleBackColor = True
        '
        'cbxEmp
        '
        Me.cbxEmp.AutoSize = True
        Me.cbxEmp.Location = New System.Drawing.Point(58, 3)
        Me.cbxEmp.Name = "cbxEmp"
        Me.cbxEmp.Size = New System.Drawing.Size(49, 17)
        Me.cbxEmp.TabIndex = 1
        Me.cbxEmp.Text = "EMP"
        Me.cbxEmp.UseVisualStyleBackColor = True
        '
        'cbxFma
        '
        Me.cbxFma.AutoSize = True
        Me.cbxFma.Location = New System.Drawing.Point(113, 3)
        Me.cbxFma.Name = "cbxFma"
        Me.cbxFma.Size = New System.Drawing.Size(48, 17)
        Me.cbxFma.TabIndex = 2
        Me.cbxFma.Text = "FMA"
        Me.cbxFma.UseVisualStyleBackColor = True
        '
        'cbxObm
        '
        Me.cbxObm.AutoSize = True
        Me.cbxObm.Location = New System.Drawing.Point(167, 3)
        Me.cbxObm.Name = "cbxObm"
        Me.cbxObm.Size = New System.Drawing.Size(50, 17)
        Me.cbxObm.TabIndex = 3
        Me.cbxObm.Text = "OBM"
        Me.cbxObm.UseVisualStyleBackColor = True
        '
        'cbxPas
        '
        Me.cbxPas.AutoSize = True
        Me.cbxPas.Location = New System.Drawing.Point(223, 3)
        Me.cbxPas.Name = "cbxPas"
        Me.cbxPas.Size = New System.Drawing.Size(47, 17)
        Me.cbxPas.TabIndex = 4
        Me.cbxPas.Text = "PAS"
        Me.cbxPas.UseVisualStyleBackColor = True
        '
        'cbxPra
        '
        Me.cbxPra.AutoSize = True
        Me.cbxPra.Location = New System.Drawing.Point(276, 3)
        Me.cbxPra.Name = "cbxPra"
        Me.cbxPra.Size = New System.Drawing.Size(48, 17)
        Me.cbxPra.TabIndex = 5
        Me.cbxPra.Text = "PRA"
        Me.cbxPra.UseVisualStyleBackColor = True
        '
        'lblTodos
        '
        Me.lblTodos.AutoSize = True
        Me.lblTodos.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTodos.Location = New System.Drawing.Point(38, 18)
        Me.lblTodos.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTodos.Name = "lblTodos"
        Me.lblTodos.Size = New System.Drawing.Size(37, 13)
        Me.lblTodos.TabIndex = 4
        Me.lblTodos.Text = "Todos"
        '
        'radTodos
        '
        Me.radTodos.AutoSize = True
        Me.radTodos.Checked = True
        Me.radTodos.Location = New System.Drawing.Point(18, 18)
        Me.radTodos.Name = "radTodos"
        Me.radTodos.Size = New System.Drawing.Size(14, 13)
        Me.radTodos.TabIndex = 5
        Me.radTodos.TabStop = True
        Me.radTodos.UseVisualStyleBackColor = True
        '
        'radCodigo
        '
        Me.radCodigo.AutoSize = True
        Me.radCodigo.Location = New System.Drawing.Point(81, 18)
        Me.radCodigo.Name = "radCodigo"
        Me.radCodigo.Size = New System.Drawing.Size(14, 13)
        Me.radCodigo.TabIndex = 6
        Me.radCodigo.TabStop = True
        Me.radCodigo.UseVisualStyleBackColor = True
        '
        'radPlanilla
        '
        Me.radPlanilla.AutoSize = True
        Me.radPlanilla.Location = New System.Drawing.Point(242, 18)
        Me.radPlanilla.Name = "radPlanilla"
        Me.radPlanilla.Size = New System.Drawing.Size(14, 13)
        Me.radPlanilla.TabIndex = 7
        Me.radPlanilla.TabStop = True
        Me.radPlanilla.UseVisualStyleBackColor = True
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCodigo.Location = New System.Drawing.Point(101, 18)
        Me.lblCodigo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(135, 13)
        Me.lblCodigo.TabIndex = 8
        Me.lblCodigo.Text = "Codigo o Dni"
        '
        'lblPlanilla
        '
        Me.lblPlanilla.AutoSize = True
        Me.lblPlanilla.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPlanilla.Location = New System.Drawing.Point(262, 18)
        Me.lblPlanilla.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPlanilla.Name = "lblPlanilla"
        Me.lblPlanilla.Size = New System.Drawing.Size(323, 13)
        Me.lblPlanilla.TabIndex = 9
        Me.lblPlanilla.Text = "Planilla"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(603, 15)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 10
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(693, 15)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblResultado, 4)
        Me.lblResultado.Location = New System.Drawing.Point(18, 330)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(67, 13)
        Me.lblResultado.TabIndex = 13
        Me.lblResultado.Text = "Resultado: 0"
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 10)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Top
        Me.barProgreso.Location = New System.Drawing.Point(18, 310)
        Me.barProgreso.MarqueeAnimationSpeed = 0
        Me.barProgreso.Maximum = 1000
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(747, 14)
        Me.barProgreso.Step = 5
        Me.barProgreso.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.barProgreso.TabIndex = 16
        '
        'frmRrhhUltimoDiaAsistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.Name = "frmRrhhUltimoDiaAsistencia"
        Me.Text = "Ultimo Dia de Asistencia"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cbxEma As System.Windows.Forms.CheckBox
    Friend WithEvents cbxEmp As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFma As System.Windows.Forms.CheckBox
    Friend WithEvents cbxObm As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPas As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPra As System.Windows.Forms.CheckBox
    Friend WithEvents lblTodos As System.Windows.Forms.Label
    Friend WithEvents radTodos As System.Windows.Forms.RadioButton
    Friend WithEvents radCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents radPlanilla As System.Windows.Forms.RadioButton
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblPlanilla As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
End Class
