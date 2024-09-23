<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Reportes_AlcanceEstandares
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.radAlcanceEstandares = New System.Windows.Forms.RadioButton()
        Me.radDistribucionHoras = New System.Windows.Forms.RadioButton()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnConvertirTareos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
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
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvResultado, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpHasta, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportar, 9, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.radAlcanceEstandares, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radDistribucionHoras, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConvertirTareos, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDesde, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1066, 508)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDin_Resultado, 4)
        Me.lblDin_Resultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 467)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(304, 23)
        Me.lblDin_Resultado.TabIndex = 1
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvResultado, 9)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 47)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1030, 385)
        Me.dgvResultado.TabIndex = 2
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(220, 19)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(102, 20)
        Me.dtpHasta.TabIndex = 3
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Location = New System.Drawing.Point(948, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(100, 23)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 9)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 438)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1030, 23)
        Me.barProgreso.TabIndex = 6
        '
        'radAlcanceEstandares
        '
        Me.radAlcanceEstandares.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radAlcanceEstandares.AutoSize = True
        Me.radAlcanceEstandares.Checked = True
        Me.radAlcanceEstandares.Location = New System.Drawing.Point(328, 21)
        Me.radAlcanceEstandares.Name = "radAlcanceEstandares"
        Me.radAlcanceEstandares.Size = New System.Drawing.Size(135, 17)
        Me.radAlcanceEstandares.TabIndex = 9
        Me.radAlcanceEstandares.TabStop = True
        Me.radAlcanceEstandares.Text = "Alcance de Estandares"
        Me.radAlcanceEstandares.UseVisualStyleBackColor = True
        '
        'radDistribucionHoras
        '
        Me.radDistribucionHoras.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radDistribucionHoras.AutoSize = True
        Me.radDistribucionHoras.Location = New System.Drawing.Point(469, 21)
        Me.radDistribucionHoras.Name = "radDistribucionHoras"
        Me.radDistribucionHoras.Size = New System.Drawing.Size(126, 17)
        Me.radDistribucionHoras.TabIndex = 10
        Me.radDistribucionHoras.Text = "Distribucion de Horas"
        Me.radDistribucionHoras.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Location = New System.Drawing.Point(842, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 23)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnConvertirTareos
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnConvertirTareos, 2)
        Me.btnConvertirTareos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnConvertirTareos.Location = New System.Drawing.Point(842, 467)
        Me.btnConvertirTareos.Name = "btnConvertirTareos"
        Me.btnConvertirTareos.Size = New System.Drawing.Size(206, 23)
        Me.btnConvertirTareos.TabIndex = 11
        Me.btnConvertirTareos.Text = "Convertir Tareos"
        Me.btnConvertirTareos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Hasta: "
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(65, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(102, 20)
        Me.dtpDesde.TabIndex = 14
        '
        'frmPacking_Reportes_AlcanceEstandares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 508)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmPacking_Reportes_AlcanceEstandares"
        Me.Text = "Packing/Reportes   |   Alcance de Estandares"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents radAlcanceEstandares As System.Windows.Forms.RadioButton
    Friend WithEvents radDistribucionHoras As System.Windows.Forms.RadioButton
    Friend WithEvents btnConvertirTareos As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDesde As DateTimePicker
End Class
