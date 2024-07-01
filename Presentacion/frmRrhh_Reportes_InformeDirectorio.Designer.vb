<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_InformeDirectorio
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
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro2 = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro3 = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro4 = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro5 = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.dgvCuadro6 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPeriodoIni = New System.Windows.Forms.TextBox()
        Me.TxtSemanaIni = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.TxtPeriodoFin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSemanaFin = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCuadro1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvCuadro2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvCuadro3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvCuadro4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvCuadro5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvCuadro6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 19
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.TabControl1, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtPeriodoIni, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.TxtSemanaIni, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 17, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 16, 1)
        Me.tlpPrincipal.Controls.Add(Me.TxtPeriodoFin, 11, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtSemanaFin, 14, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 13, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 6
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1200, 636)
        Me.tlpPrincipal.TabIndex = 3
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(62, 12)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(194, 21)
        Me.cboPlanilla.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Planilla:"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 17)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(13, 582)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1176, 23)
        Me.barProgreso.TabIndex = 9
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResultado, 2)
        Me.lblResultado.Location = New System.Drawing.Point(13, 608)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 10
        Me.lblResultado.Text = "Listo!"
        '
        'TabControl1
        '
        Me.tlpPrincipal.SetColumnSpan(Me.TabControl1, 17)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(13, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1176, 536)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCuadro1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cuadro 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCuadro1
        '
        Me.dgvCuadro1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro1.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro1.Name = "dgvCuadro1"
        Me.dgvCuadro1.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro1.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvCuadro2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cuadro 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvCuadro2
        '
        Me.dgvCuadro2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro2.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro2.Name = "dgvCuadro2"
        Me.dgvCuadro2.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro2.TabIndex = 12
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvCuadro3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuadro 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvCuadro3
        '
        Me.dgvCuadro3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro3.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro3.Name = "dgvCuadro3"
        Me.dgvCuadro3.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro3.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvCuadro4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cuadro 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvCuadro4
        '
        Me.dgvCuadro4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro4.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro4.Name = "dgvCuadro4"
        Me.dgvCuadro4.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro4.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvCuadro5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Cuadro 5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvCuadro5
        '
        Me.dgvCuadro5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro5.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro5.Name = "dgvCuadro5"
        Me.dgvCuadro5.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro5.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.dgvCuadro6)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1168, 510)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Cuadro 6"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'dgvCuadro6
        '
        Me.dgvCuadro6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuadro6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuadro6.Location = New System.Drawing.Point(3, 3)
        Me.dgvCuadro6.Name = "dgvCuadro6"
        Me.dgvCuadro6.Size = New System.Drawing.Size(1162, 504)
        Me.dgvCuadro6.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Periodo Inicial:"
        '
        'txtPeriodoIni
        '
        Me.txtPeriodoIni.Location = New System.Drawing.Point(391, 11)
        Me.txtPeriodoIni.Name = "txtPeriodoIni"
        Me.txtPeriodoIni.Size = New System.Drawing.Size(44, 20)
        Me.txtPeriodoIni.TabIndex = 1
        '
        'TxtSemanaIni
        '
        Me.TxtSemanaIni.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtSemanaIni.Location = New System.Drawing.Point(573, 12)
        Me.TxtSemanaIni.Name = "TxtSemanaIni"
        Me.TxtSemanaIni.Size = New System.Drawing.Size(44, 20)
        Me.TxtSemanaIni.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(488, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Semana Inicial:"
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnExportar.Location = New System.Drawing.Point(1105, 11)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(84, 23)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.Location = New System.Drawing.Point(1024, 11)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 5
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'TxtPeriodoFin
        '
        Me.TxtPeriodoFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPeriodoFin.Location = New System.Drawing.Point(747, 12)
        Me.TxtPeriodoFin.Name = "TxtPeriodoFin"
        Me.TxtPeriodoFin.Size = New System.Drawing.Size(44, 20)
        Me.TxtPeriodoFin.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(670, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Periodo Final:"
        '
        'txtSemanaFin
        '
        Me.txtSemanaFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSemanaFin.Location = New System.Drawing.Point(924, 12)
        Me.txtSemanaFin.Name = "txtSemanaFin"
        Me.txtSemanaFin.Size = New System.Drawing.Size(44, 20)
        Me.txtSemanaFin.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(844, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Semana Final:"
        '
        'frmRrhh_Reportes_InformeDirectorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 636)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_InformeDirectorio"
        Me.Text = "Rrhh / Reportes / Informe Directorio"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCuadro1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvCuadro2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvCuadro3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvCuadro4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvCuadro5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dgvCuadro6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents lblResultado As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtSemanaIni As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPeriodoFin As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPeriodoIni As TextBox
    Friend WithEvents txtSemanaFin As TextBox
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnConsultar As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvCuadro1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvCuadro2 As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvCuadro3 As DataGridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgvCuadro4 As DataGridView
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents dgvCuadro5 As DataGridView
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents dgvCuadro6 As DataGridView
End Class
