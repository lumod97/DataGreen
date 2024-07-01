<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen
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
        Me.dgvT1 = New System.Windows.Forms.DataGridView()
        Me.dgvT2 = New System.Windows.Forms.DataGridView()
        Me.btnRevertir = New System.Windows.Forms.Button()
        Me.btnRegistrarAsistencia = New System.Windows.Forms.Button()
        Me.dgvT3 = New System.Windows.Forms.DataGridView()
        Me.btnConsolidar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerarAsistencia = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvT1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvT2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvT3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 8
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.dgvT1, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvT2, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnRevertir, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.btnRegistrarAsistencia, 3, 7)
        Me.tlpPrincipal.Controls.Add(Me.dgvT3, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.btnConsolidar, 6, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 9)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnGenerarAsistencia, 5, 7)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpFecha, 3, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 11
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(910, 508)
        Me.tlpPrincipal.TabIndex = 1
        '
        'dgvT1
        '
        Me.dgvT1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvT1, 6)
        Me.dgvT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvT1.Location = New System.Drawing.Point(18, 47)
        Me.dgvT1.Name = "dgvT1"
        Me.dgvT1.Size = New System.Drawing.Size(874, 77)
        Me.dgvT1.TabIndex = 1
        '
        'dgvT2
        '
        Me.dgvT2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvT2, 6)
        Me.dgvT2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvT2.Location = New System.Drawing.Point(18, 150)
        Me.dgvT2.Name = "dgvT2"
        Me.dgvT2.Size = New System.Drawing.Size(874, 149)
        Me.dgvT2.TabIndex = 2
        '
        'btnRevertir
        '
        Me.btnRevertir.Location = New System.Drawing.Point(18, 417)
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(75, 23)
        Me.btnRevertir.TabIndex = 7
        Me.btnRevertir.Text = "Revertir"
        Me.btnRevertir.UseVisualStyleBackColor = True
        '
        'btnRegistrarAsistencia
        '
        Me.tlpPrincipal.SetColumnSpan(Me.btnRegistrarAsistencia, 2)
        Me.btnRegistrarAsistencia.Location = New System.Drawing.Point(606, 417)
        Me.btnRegistrarAsistencia.Name = "btnRegistrarAsistencia"
        Me.btnRegistrarAsistencia.Size = New System.Drawing.Size(140, 23)
        Me.btnRegistrarAsistencia.TabIndex = 6
        Me.btnRegistrarAsistencia.Text = "Registrar Asistencia"
        Me.btnRegistrarAsistencia.UseVisualStyleBackColor = True
        '
        'dgvT3
        '
        Me.dgvT3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvT3, 6)
        Me.dgvT3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvT3.Location = New System.Drawing.Point(18, 334)
        Me.dgvT3.Name = "dgvT3"
        Me.dgvT3.Size = New System.Drawing.Size(874, 77)
        Me.dgvT3.TabIndex = 3
        '
        'btnConsolidar
        '
        Me.btnConsolidar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnConsolidar.Location = New System.Drawing.Point(817, 305)
        Me.btnConsolidar.Name = "btnConsolidar"
        Me.btnConsolidar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsolidar.TabIndex = 4
        Me.btnConsolidar.Text = "Consolidar"
        Me.btnConsolidar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExportar.Location = New System.Drawing.Point(817, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 9
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 6)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 446)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(874, 23)
        Me.barProgreso.TabIndex = 10
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 6)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 475)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 11
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 131)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Tareos Disponibles:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 315)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Tareos Consolidados:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Resumen:"
        '
        'btnGenerarAsistencia
        '
        Me.tlpPrincipal.SetColumnSpan(Me.btnGenerarAsistencia, 2)
        Me.btnGenerarAsistencia.Location = New System.Drawing.Point(752, 417)
        Me.btnGenerarAsistencia.Name = "btnGenerarAsistencia"
        Me.btnGenerarAsistencia.Size = New System.Drawing.Size(140, 23)
        Me.btnGenerarAsistencia.TabIndex = 5
        Me.btnGenerarAsistencia.Text = "Generar Asistencia"
        Me.btnGenerarAsistencia.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.tlpPrincipal.SetColumnSpan(Me.btnConsultar, 2)
        Me.btnConsultar.Location = New System.Drawing.Point(732, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 8
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(626, 19)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 508)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Movimientos_AsistenciaDataGreenMiniGreen"
        Me.Text = "Rrhh / Movimientos / Asistencia DataGreen - MiniGreen"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvT1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvT2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvT3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents dgvT1 As DataGridView
    Friend WithEvents dgvT2 As DataGridView
    Friend WithEvents btnRevertir As Button
    Friend WithEvents btnRegistrarAsistencia As Button
    Friend WithEvents dgvT3 As DataGridView
    Friend WithEvents btnConsolidar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGenerarAsistencia As Button
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dtpFecha As DateTimePicker
End Class
