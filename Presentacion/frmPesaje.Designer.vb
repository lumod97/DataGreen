<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesaje
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtticket = New System.Windows.Forms.TextBox()
        Me.txtpesoingreso = New System.Windows.Forms.TextBox()
        Me.txtpesosalida = New System.Windows.Forms.TextBox()
        Me.txtpesobruto = New System.Windows.Forms.TextBox()
        Me.txtpesotara = New System.Windows.Forms.TextBox()
        Me.txtpesoNeto = New System.Windows.Forms.TextBox()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraIngreso = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraSalida = New System.Windows.Forms.DateTimePicker()
        Me.txtPesoBalanza = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 9
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.85345!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.13187!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.46154!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.769231!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.71429!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.7033!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 0, 0)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 0, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 0, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label6, 0, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 0, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label8, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label9, 2, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label10, 2, 5)
        Me.tlpPrincipal.Controls.Add(Me.txtticket, 1, 0)
        Me.tlpPrincipal.Controls.Add(Me.txtpesoingreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.txtpesosalida, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtpesobruto, 3, 3)
        Me.tlpPrincipal.Controls.Add(Me.txtpesotara, 3, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtpesoNeto, 3, 5)
        Me.tlpPrincipal.Controls.Add(Me.dtpFechaIngreso, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpFechaSalida, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.dtpHoraIngreso, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpHoraSalida, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtPesoBalanza, 5, 0)
        Me.tlpPrincipal.Controls.Add(Me.RadioButton1, 2, 0)
        Me.tlpPrincipal.Controls.Add(Me.RadioButton2, 3, 0)
        Me.tlpPrincipal.Controls.Add(Me.btnSincronizar, 6, 0)
        Me.tlpPrincipal.Controls.Add(Me.btnImportar, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.DataGridView1, 7, 7)
        Me.tlpPrincipal.Controls.Add(Me.btnImprimir, 6, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 9
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.861949!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.137802!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.89785!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.360215!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.763441!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.763441!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.435484!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.73118!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.58064!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1008, 744)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nro Ticket:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha de Ingreso:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de Salida:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(247, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hora de Ingreso:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Hora de Salida:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Peso de Ingreso:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Peso de Salida:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(271, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Peso Bruto:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(274, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Peso Tara:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(273, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Peso Neto:"
        '
        'txtticket
        '
        Me.txtticket.Location = New System.Drawing.Point(111, 3)
        Me.txtticket.Name = "txtticket"
        Me.txtticket.Size = New System.Drawing.Size(100, 20)
        Me.txtticket.TabIndex = 10
        '
        'txtpesoingreso
        '
        Me.txtpesoingreso.Location = New System.Drawing.Point(111, 90)
        Me.txtpesoingreso.Name = "txtpesoingreso"
        Me.txtpesoingreso.Size = New System.Drawing.Size(100, 20)
        Me.txtpesoingreso.TabIndex = 11
        '
        'txtpesosalida
        '
        Me.txtpesosalida.Location = New System.Drawing.Point(111, 115)
        Me.txtpesosalida.Name = "txtpesosalida"
        Me.txtpesosalida.Size = New System.Drawing.Size(100, 20)
        Me.txtpesosalida.TabIndex = 12
        '
        'txtpesobruto
        '
        Me.txtpesobruto.Location = New System.Drawing.Point(339, 90)
        Me.txtpesobruto.Name = "txtpesobruto"
        Me.txtpesobruto.Size = New System.Drawing.Size(100, 20)
        Me.txtpesobruto.TabIndex = 13
        '
        'txtpesotara
        '
        Me.txtpesotara.Location = New System.Drawing.Point(339, 115)
        Me.txtpesotara.Name = "txtpesotara"
        Me.txtpesotara.Size = New System.Drawing.Size(100, 20)
        Me.txtpesotara.TabIndex = 14
        '
        'txtpesoNeto
        '
        Me.txtpesoNeto.Location = New System.Drawing.Point(339, 143)
        Me.txtpesoNeto.Name = "txtpesoNeto"
        Me.txtpesoNeto.Size = New System.Drawing.Size(100, 20)
        Me.txtpesoNeto.TabIndex = 15
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(111, 31)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaIngreso.TabIndex = 16
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSalida.Location = New System.Drawing.Point(111, 61)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaSalida.TabIndex = 17
        '
        'dtpHoraIngreso
        '
        Me.dtpHoraIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraIngreso.Location = New System.Drawing.Point(339, 31)
        Me.dtpHoraIngreso.Name = "dtpHoraIngreso"
        Me.dtpHoraIngreso.Size = New System.Drawing.Size(105, 20)
        Me.dtpHoraIngreso.TabIndex = 18
        '
        'dtpHoraSalida
        '
        Me.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraSalida.Location = New System.Drawing.Point(339, 61)
        Me.dtpHoraSalida.Name = "dtpHoraSalida"
        Me.dtpHoraSalida.Size = New System.Drawing.Size(105, 20)
        Me.dtpHoraSalida.TabIndex = 19
        '
        'txtPesoBalanza
        '
        Me.txtPesoBalanza.Enabled = False
        Me.txtPesoBalanza.Location = New System.Drawing.Point(491, 3)
        Me.txtPesoBalanza.Name = "txtPesoBalanza"
        Me.txtPesoBalanza.Size = New System.Drawing.Size(71, 20)
        Me.txtPesoBalanza.TabIndex = 20
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(257, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(60, 17)
        Me.RadioButton1.TabIndex = 21
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Ingreso"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(364, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton2.TabIndex = 22
        Me.RadioButton2.Text = "Salida"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSincronizar.Location = New System.Drawing.Point(568, 3)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(151, 22)
        Me.btnSincronizar.TabIndex = 23
        Me.btnSincronizar.Text = "Sincronizar Peso Balanza"
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(568, 31)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 24
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(725, 204)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(217, 364)
        Me.DataGridView1.TabIndex = 25
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(568, 61)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 26
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'frmPesaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 744)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPesaje"
        Me.Text = "frmPesaje"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtticket As TextBox
    Friend WithEvents txtpesoingreso As TextBox
    Friend WithEvents txtpesosalida As TextBox
    Friend WithEvents txtpesobruto As TextBox
    Friend WithEvents txtpesotara As TextBox
    Friend WithEvents txtpesoNeto As TextBox
    Friend WithEvents dtpFechaIngreso As DateTimePicker
    Friend WithEvents dtpFechaSalida As DateTimePicker
    Friend WithEvents dtpHoraIngreso As DateTimePicker
    Friend WithEvents dtpHoraSalida As DateTimePicker
    Friend WithEvents txtPesoBalanza As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents btnSincronizar As Button
    Friend WithEvents btnImportar As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnImprimir As Button
End Class
