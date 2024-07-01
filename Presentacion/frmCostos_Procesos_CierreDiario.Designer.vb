<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostos_Procesos_CierreDiario
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
        Me.lblDinResultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.dgvEstadoDias = New System.Windows.Forms.DataGridView()
        Me.tabResultado = New System.Windows.Forms.TabControl()
        Me.pagInsumos = New System.Windows.Forms.TabPage()
        Me.dgvInsumos = New System.Windows.Forms.DataGridView()
        Me.pagManoObra = New System.Windows.Forms.TabPage()
        Me.dgvManoObra = New System.Windows.Forms.DataGridView()
        Me.pagGastos = New System.Windows.Forms.TabPage()
        Me.dgvGastos = New System.Windows.Forms.DataGridView()
        Me.pagMaquinaria = New System.Windows.Forms.TabPage()
        Me.dgvMaquinaria = New System.Windows.Forms.DataGridView()
        Me.pagOtros = New System.Windows.Forms.TabPage()
        Me.dgvOtros = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEnviarInconsistencias = New System.Windows.Forms.Button()
        Me.btnCerrarDia = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.pkrDia = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvEstadoDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabResultado.SuspendLayout()
        Me.pagInsumos.SuspendLayout()
        CType(Me.dgvInsumos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pagManoObra.SuspendLayout()
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pagGastos.SuspendLayout()
        CType(Me.dgvGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pagMaquinaria.SuspendLayout()
        CType(Me.dgvMaquinaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pagOtros.SuspendLayout()
        CType(Me.dgvOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblDinResultado, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvEstadoDias, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tabResultado, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(973, 513)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblDinResultado
        '
        Me.lblDinResultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDinResultado, 2)
        Me.lblDinResultado.Location = New System.Drawing.Point(18, 462)
        Me.lblDinResultado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblDinResultado.Name = "lblDinResultado"
        Me.lblDinResultado.Size = New System.Drawing.Size(59, 12)
        Me.lblDinResultado.TabIndex = 10
        Me.lblDinResultado.Text = "Preparado."
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 2)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 482)
        Me.barProgreso.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(937, 12)
        Me.barProgreso.TabIndex = 9
        '
        'dgvEstadoDias
        '
        Me.dgvEstadoDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEstadoDias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEstadoDias.Location = New System.Drawing.Point(18, 47)
        Me.dgvEstadoDias.Name = "dgvEstadoDias"
        Me.dgvEstadoDias.Size = New System.Drawing.Size(144, 408)
        Me.dgvEstadoDias.TabIndex = 0
        '
        'tabResultado
        '
        Me.tabResultado.Controls.Add(Me.pagInsumos)
        Me.tabResultado.Controls.Add(Me.pagManoObra)
        Me.tabResultado.Controls.Add(Me.pagGastos)
        Me.tabResultado.Controls.Add(Me.pagMaquinaria)
        Me.tabResultado.Controls.Add(Me.pagOtros)
        Me.tabResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabResultado.Location = New System.Drawing.Point(168, 47)
        Me.tabResultado.Name = "tabResultado"
        Me.tabResultado.SelectedIndex = 0
        Me.tabResultado.Size = New System.Drawing.Size(787, 408)
        Me.tabResultado.TabIndex = 2
        '
        'pagInsumos
        '
        Me.pagInsumos.Controls.Add(Me.dgvInsumos)
        Me.pagInsumos.Location = New System.Drawing.Point(4, 22)
        Me.pagInsumos.Name = "pagInsumos"
        Me.pagInsumos.Padding = New System.Windows.Forms.Padding(3)
        Me.pagInsumos.Size = New System.Drawing.Size(779, 382)
        Me.pagInsumos.TabIndex = 0
        Me.pagInsumos.Text = "Insumos"
        Me.pagInsumos.UseVisualStyleBackColor = True
        '
        'dgvInsumos
        '
        Me.dgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInsumos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsumos.Location = New System.Drawing.Point(3, 3)
        Me.dgvInsumos.Name = "dgvInsumos"
        Me.dgvInsumos.Size = New System.Drawing.Size(773, 376)
        Me.dgvInsumos.TabIndex = 0
        '
        'pagManoObra
        '
        Me.pagManoObra.Controls.Add(Me.dgvManoObra)
        Me.pagManoObra.Location = New System.Drawing.Point(4, 22)
        Me.pagManoObra.Name = "pagManoObra"
        Me.pagManoObra.Padding = New System.Windows.Forms.Padding(3)
        Me.pagManoObra.Size = New System.Drawing.Size(779, 382)
        Me.pagManoObra.TabIndex = 1
        Me.pagManoObra.Text = "Mano de Obra"
        Me.pagManoObra.UseVisualStyleBackColor = True
        '
        'dgvManoObra
        '
        Me.dgvManoObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManoObra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvManoObra.Location = New System.Drawing.Point(3, 3)
        Me.dgvManoObra.Name = "dgvManoObra"
        Me.dgvManoObra.Size = New System.Drawing.Size(773, 376)
        Me.dgvManoObra.TabIndex = 0
        '
        'pagGastos
        '
        Me.pagGastos.Controls.Add(Me.dgvGastos)
        Me.pagGastos.Location = New System.Drawing.Point(4, 22)
        Me.pagGastos.Name = "pagGastos"
        Me.pagGastos.Padding = New System.Windows.Forms.Padding(3)
        Me.pagGastos.Size = New System.Drawing.Size(779, 382)
        Me.pagGastos.TabIndex = 2
        Me.pagGastos.Text = "Gastos"
        Me.pagGastos.UseVisualStyleBackColor = True
        '
        'dgvGastos
        '
        Me.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGastos.Location = New System.Drawing.Point(3, 3)
        Me.dgvGastos.Name = "dgvGastos"
        Me.dgvGastos.Size = New System.Drawing.Size(773, 376)
        Me.dgvGastos.TabIndex = 0
        '
        'pagMaquinaria
        '
        Me.pagMaquinaria.Controls.Add(Me.dgvMaquinaria)
        Me.pagMaquinaria.Location = New System.Drawing.Point(4, 22)
        Me.pagMaquinaria.Name = "pagMaquinaria"
        Me.pagMaquinaria.Padding = New System.Windows.Forms.Padding(3)
        Me.pagMaquinaria.Size = New System.Drawing.Size(779, 382)
        Me.pagMaquinaria.TabIndex = 4
        Me.pagMaquinaria.Text = "Maquinaria"
        Me.pagMaquinaria.UseVisualStyleBackColor = True
        '
        'dgvMaquinaria
        '
        Me.dgvMaquinaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaquinaria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaquinaria.Location = New System.Drawing.Point(3, 3)
        Me.dgvMaquinaria.Name = "dgvMaquinaria"
        Me.dgvMaquinaria.Size = New System.Drawing.Size(773, 376)
        Me.dgvMaquinaria.TabIndex = 1
        '
        'pagOtros
        '
        Me.pagOtros.Controls.Add(Me.dgvOtros)
        Me.pagOtros.Location = New System.Drawing.Point(4, 22)
        Me.pagOtros.Name = "pagOtros"
        Me.pagOtros.Padding = New System.Windows.Forms.Padding(3)
        Me.pagOtros.Size = New System.Drawing.Size(779, 382)
        Me.pagOtros.TabIndex = 3
        Me.pagOtros.Text = "Otros"
        Me.pagOtros.UseVisualStyleBackColor = True
        '
        'dgvOtros
        '
        Me.dgvOtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOtros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOtros.Location = New System.Drawing.Point(3, 3)
        Me.dgvOtros.Name = "dgvOtros"
        Me.dgvOtros.Size = New System.Drawing.Size(773, 376)
        Me.dgvOtros.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.btnEnviarInconsistencias, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCerrarDia, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExportar, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnConsultar, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pkrDia, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(15, 15)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(943, 29)
        Me.TableLayoutPanel3.TabIndex = 11
        '
        'btnEnviarInconsistencias
        '
        Me.btnEnviarInconsistencias.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEnviarInconsistencias.Location = New System.Drawing.Point(724, 3)
        Me.btnEnviarInconsistencias.Name = "btnEnviarInconsistencias"
        Me.btnEnviarInconsistencias.Size = New System.Drawing.Size(130, 23)
        Me.btnEnviarInconsistencias.TabIndex = 3
        Me.btnEnviarInconsistencias.Text = "Enviar Inconsistencias"
        Me.btnEnviarInconsistencias.UseVisualStyleBackColor = True
        '
        'btnCerrarDia
        '
        Me.btnCerrarDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCerrarDia.Location = New System.Drawing.Point(860, 3)
        Me.btnCerrarDia.Name = "btnCerrarDia"
        Me.btnCerrarDia.Size = New System.Drawing.Size(80, 23)
        Me.btnCerrarDia.TabIndex = 2
        Me.btnCerrarDia.Text = "Cerrar Dia"
        Me.btnCerrarDia.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(380, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.Location = New System.Drawing.Point(299, 3)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'pkrDia
        '
        Me.pkrDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrDia.Location = New System.Drawing.Point(35, 4)
        Me.pkrDia.Name = "pkrDia"
        Me.pkrDia.Size = New System.Drawing.Size(258, 20)
        Me.pkrDia.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dia:"
        '
        'frmCostos_Procesos_CierreDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 513)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmCostos_Procesos_CierreDiario"
        Me.Text = "Costos/Procesos - CierreDiario"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvEstadoDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabResultado.ResumeLayout(False)
        Me.pagInsumos.ResumeLayout(False)
        CType(Me.dgvInsumos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pagManoObra.ResumeLayout(False)
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pagGastos.ResumeLayout(False)
        CType(Me.dgvGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pagMaquinaria.ResumeLayout(False)
        CType(Me.dgvMaquinaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pagOtros.ResumeLayout(False)
        CType(Me.dgvOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvEstadoDias As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrarDia As System.Windows.Forms.Button
    Friend WithEvents btnEnviarInconsistencias As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pkrDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDinResultado As System.Windows.Forms.Label
    Friend WithEvents tabResultado As System.Windows.Forms.TabControl
    Friend WithEvents pagInsumos As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsumos As System.Windows.Forms.DataGridView
    Friend WithEvents pagManoObra As System.Windows.Forms.TabPage
    Friend WithEvents dgvManoObra As System.Windows.Forms.DataGridView
    Friend WithEvents pagGastos As System.Windows.Forms.TabPage
    Friend WithEvents dgvGastos As System.Windows.Forms.DataGridView
    Friend WithEvents pagMaquinaria As System.Windows.Forms.TabPage
    Friend WithEvents dgvMaquinaria As System.Windows.Forms.DataGridView
    Friend WithEvents pagOtros As System.Windows.Forms.TabPage
    Friend WithEvents dgvOtros As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
End Class
