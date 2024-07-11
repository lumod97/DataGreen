<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_ImpresionFormatos
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.cboTablas = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pkrDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pkrHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.wbrImprimible = New System.Windows.Forms.WebBrowser()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblDin_Resultado, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFiltro, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTablas, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPlanilla, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrDesde, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrHasta, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 10, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGenerar, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1178, 531)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDin_Resultado, 8)
        Me.lblDin_Resultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 500)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(797, 13)
        Me.lblDin_Resultado.TabIndex = 11
        Me.lblDin_Resultado.Text = "Listo"
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 11)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 479)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1142, 15)
        Me.barProgreso.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Busqueda:"
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtFiltro, 5)
        Me.txtFiltro.Location = New System.Drawing.Point(82, 50)
        Me.txtFiltro.MinimumSize = New System.Drawing.Size(150, 4)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(355, 20)
        Me.txtFiltro.TabIndex = 21
        '
        'cboTablas
        '
        Me.cboTablas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTablas.FormattingEnabled = True
        Me.cboTablas.Location = New System.Drawing.Point(82, 20)
        Me.cboTablas.Name = "cboTablas"
        Me.cboTablas.Size = New System.Drawing.Size(199, 21)
        Me.cboTablas.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(287, 24)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Planilla:"
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(336, 20)
        Me.cboPlanilla.MaximumSize = New System.Drawing.Size(150, 0)
        Me.cboPlanilla.MinimumSize = New System.Drawing.Size(150, 0)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(150, 21)
        Me.cboPlanilla.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Formato:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(492, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Desde:"
        '
        'pkrDesde
        '
        Me.pkrDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(539, 21)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(113, 20)
        Me.pkrDesde.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(658, 24)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Hasta:"
        '
        'pkrHasta
        '
        Me.pkrHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrHasta.Location = New System.Drawing.Point(702, 21)
        Me.pkrHasta.Name = "pkrHasta"
        Me.pkrHasta.Size = New System.Drawing.Size(113, 20)
        Me.pkrHasta.TabIndex = 19
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.Location = New System.Drawing.Point(966, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(94, 26)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGenerar.Location = New System.Drawing.Point(1066, 18)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(94, 26)
        Me.btnGenerar.TabIndex = 14
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 11)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.wbrImprimible, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dgvResultado, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(18, 76)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1142, 397)
        Me.TableLayoutPanel2.TabIndex = 26
        '
        'wbrImprimible
        '
        Me.wbrImprimible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbrImprimible.Location = New System.Drawing.Point(688, 3)
        Me.wbrImprimible.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrImprimible.Name = "wbrImprimible"
        Me.wbrImprimible.Size = New System.Drawing.Size(451, 391)
        Me.wbrImprimible.TabIndex = 12
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(3, 3)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(679, 391)
        Me.dgvResultado.TabIndex = 10
        '
        'frmRrhh_Reportes_ImpresionFormatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 531)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmRrhh_Reportes_ImpresionFormatos"
        Me.Text = "Rrhh / Reportes / Impresion de Formatos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents cboTablas As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents pkrHasta As DateTimePicker
    Friend WithEvents btnConsultar As Button
    Friend WithEvents pkrDesde As DateTimePicker
    Friend WithEvents btnGenerar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents wbrImprimible As WebBrowser
End Class
