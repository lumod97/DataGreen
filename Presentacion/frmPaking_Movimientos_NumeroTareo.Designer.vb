<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupervision_Movimientos_NuevoTareoPaking
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pkrFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.btnRevertir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboPuntoControl = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pkrFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.pkrHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.pkrHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.btnFechaFin = New System.Windows.Forms.Button()
        Me.btnHoraInicio = New System.Windows.Forms.Button()
        Me.btnHoraFin = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.pkrHoraRefrigerio = New System.Windows.Forms.DateTimePicker()
        Me.btnHoraRefrige = New System.Windows.Forms.Button()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.pkrHoraP = New System.Windows.Forms.DateTimePicker()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblDin_IdTareo = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.22201!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.44466!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 0, 4)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel8, 0, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_IdTareo, 0, 0)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 6
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.733119!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.27331!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.259781!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.37089!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.58541!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1154, 606)
        Me.tlpPrincipal.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel2, 3)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.02159!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.31797!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.57757!))
        Me.TableLayoutPanel2.Controls.Add(Me.pkrFechaInicio, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboTurno, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboEstado, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCultivo, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnRevertir, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnGuardar, 3, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 19)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.72973!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.375!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.45833!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1148, 86)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'pkrFechaInicio
        '
        Me.pkrFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrFechaInicio.Location = New System.Drawing.Point(152, 3)
        Me.pkrFechaInicio.Name = "pkrFechaInicio"
        Me.pkrFechaInicio.Size = New System.Drawing.Size(212, 20)
        Me.pkrFechaInicio.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Turno:"
        '
        'cboTurno
        '
        Me.cboTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(152, 28)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(212, 21)
        Me.cboTurno.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(818, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Estado:"
        '
        'cboEstado
        '
        Me.cboEstado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(867, 3)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(278, 21)
        Me.cboEstado.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(104, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Cultivo:"
        '
        'cboCultivo
        '
        Me.cboCultivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(152, 57)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(212, 21)
        Me.cboCultivo.TabIndex = 11
        '
        'btnRevertir
        '
        Me.btnRevertir.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRevertir.Location = New System.Drawing.Point(1070, 28)
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(75, 23)
        Me.btnRevertir.TabIndex = 12
        Me.btnRevertir.Text = "Revertir"
        Me.btnRevertir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnGuardar.Location = New System.Drawing.Point(1070, 58)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel4, 3)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.73175!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.27957!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.7066!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.49616!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cboPuntoControl, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Button3, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 111)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1148, 32)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Punto Control:"
        '
        'cboPuntoControl
        '
        Me.cboPuntoControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPuntoControl.FormattingEnabled = True
        Me.cboPuntoControl.Location = New System.Drawing.Point(160, 3)
        Me.cboPuntoControl.Name = "cboPuntoControl"
        Me.cboPuntoControl.Size = New System.Drawing.Size(203, 21)
        Me.cboPuntoControl.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.Location = New System.Drawing.Point(1070, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 26)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Actualizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel5, 3)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.96!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.04762!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.74962!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0384!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.56836!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label8, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.pkrFechaFin, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.pkrHoraInicio, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.pkrHoraFin, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnFechaFin, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnHoraInicio, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnHoraFin, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label9, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label10, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel7, 4, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 149)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1148, 99)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(88, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha Fin:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(84, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Hora Inicio:"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(95, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Hora Fin:"
        '
        'pkrFechaFin
        '
        Me.pkrFechaFin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrFechaFin.Location = New System.Drawing.Point(151, 3)
        Me.pkrFechaFin.Name = "pkrFechaFin"
        Me.pkrFechaFin.Size = New System.Drawing.Size(211, 20)
        Me.pkrFechaFin.TabIndex = 3
        '
        'pkrHoraInicio
        '
        Me.pkrHoraInicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.pkrHoraInicio.Location = New System.Drawing.Point(151, 36)
        Me.pkrHoraInicio.Name = "pkrHoraInicio"
        Me.pkrHoraInicio.Size = New System.Drawing.Size(211, 20)
        Me.pkrHoraInicio.TabIndex = 4
        Me.pkrHoraInicio.Value = New Date(2023, 4, 29, 10, 42, 0, 0)
        '
        'pkrHoraFin
        '
        Me.pkrHoraFin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.pkrHoraFin.Location = New System.Drawing.Point(151, 69)
        Me.pkrHoraFin.Name = "pkrHoraFin"
        Me.pkrHoraFin.Size = New System.Drawing.Size(211, 20)
        Me.pkrHoraFin.TabIndex = 5
        '
        'btnFechaFin
        '
        Me.btnFechaFin.Location = New System.Drawing.Point(368, 3)
        Me.btnFechaFin.Name = "btnFechaFin"
        Me.btnFechaFin.Size = New System.Drawing.Size(75, 23)
        Me.btnFechaFin.TabIndex = 6
        Me.btnFechaFin.Text = "Update"
        Me.btnFechaFin.UseVisualStyleBackColor = True
        '
        'btnHoraInicio
        '
        Me.btnHoraInicio.Location = New System.Drawing.Point(368, 36)
        Me.btnHoraInicio.Name = "btnHoraInicio"
        Me.btnHoraInicio.Size = New System.Drawing.Size(75, 23)
        Me.btnHoraInicio.TabIndex = 7
        Me.btnHoraInicio.Text = "Update"
        Me.btnHoraInicio.UseVisualStyleBackColor = True
        '
        'btnHoraFin
        '
        Me.btnHoraFin.Location = New System.Drawing.Point(368, 69)
        Me.btnHoraFin.Name = "btnHoraFin"
        Me.btnHoraFin.Size = New System.Drawing.Size(75, 23)
        Me.btnHoraFin.TabIndex = 8
        Me.btnHoraFin.Text = "Update"
        Me.btnHoraFin.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(712, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Hora Refrigerio:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(753, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Hora P"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.pkrHoraRefrigerio, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnHoraRefrige, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(799, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(346, 27)
        Me.TableLayoutPanel6.TabIndex = 11
        '
        'pkrHoraRefrigerio
        '
        Me.pkrHoraRefrigerio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrHoraRefrigerio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.pkrHoraRefrigerio.Location = New System.Drawing.Point(3, 3)
        Me.pkrHoraRefrigerio.Name = "pkrHoraRefrigerio"
        Me.pkrHoraRefrigerio.Size = New System.Drawing.Size(167, 20)
        Me.pkrHoraRefrigerio.TabIndex = 0
        '
        'btnHoraRefrige
        '
        Me.btnHoraRefrige.Location = New System.Drawing.Point(176, 3)
        Me.btnHoraRefrige.Name = "btnHoraRefrige"
        Me.btnHoraRefrige.Size = New System.Drawing.Size(75, 21)
        Me.btnHoraRefrige.TabIndex = 1
        Me.btnHoraRefrige.Text = "Update"
        Me.btnHoraRefrige.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.pkrHoraP, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Button8, 1, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(799, 36)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(346, 27)
        Me.TableLayoutPanel7.TabIndex = 12
        '
        'pkrHoraP
        '
        Me.pkrHoraP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pkrHoraP.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.pkrHoraP.Location = New System.Drawing.Point(3, 3)
        Me.pkrHoraP.Name = "pkrHoraP"
        Me.pkrHoraP.Size = New System.Drawing.Size(167, 20)
        Me.pkrHoraP.TabIndex = 0
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(176, 3)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 21)
        Me.Button8.TabIndex = 1
        Me.Button8.Text = "Update"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.AllowUserToOrderColumns = True
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 3)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(3, 254)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1148, 295)
        Me.dgvResultado.TabIndex = 3
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel8, 3)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.lblDin_Resultado, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.ProgressBar1, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 555)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1148, 48)
        Me.TableLayoutPanel8.TabIndex = 4
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(3, 29)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(45, 13)
        Me.lblDin_Resultado.TabIndex = 0
        Me.lblDin_Resultado.Text = "Label11"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 3)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1142, 18)
        Me.ProgressBar1.TabIndex = 1
        '
        'lblDin_IdTareo
        '
        Me.lblDin_IdTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_IdTareo.AutoSize = True
        Me.lblDin_IdTareo.Location = New System.Drawing.Point(3, 1)
        Me.lblDin_IdTareo.Name = "lblDin_IdTareo"
        Me.lblDin_IdTareo.Size = New System.Drawing.Size(42, 13)
        Me.lblDin_IdTareo.TabIndex = 5
        Me.lblDin_IdTareo.Text = "#Tareo"
        '
        'frmSupervision_Movimientos_NuevoTareoPaking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 606)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmSupervision_Movimientos_NuevoTareoPaking"
        Me.Text = "[Supervision/Movimientos/Tareos/Nuevo Tareo Paking]"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pkrFechaInicio As DateTimePicker
    Friend WithEvents cboTurno As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents cboPuntoControl As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents pkrFechaFin As DateTimePicker
    Friend WithEvents pkrHoraInicio As DateTimePicker
    Friend WithEvents pkrHoraFin As DateTimePicker
    Friend WithEvents btnFechaFin As Button
    Friend WithEvents btnHoraInicio As Button
    Friend WithEvents btnHoraFin As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents pkrHoraRefrigerio As DateTimePicker
    Friend WithEvents btnHoraRefrige As Button
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents pkrHoraP As DateTimePicker
    Friend WithEvents Button8 As Button
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents Label12 As Label
    Friend WithEvents cboCultivo As ComboBox
    Friend WithEvents btnRevertir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblDin_IdTareo As Label
End Class
