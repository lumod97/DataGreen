<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPacking_Movimientos_TareosPackingDetalle_Nuevo
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRevertirTareo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGenerarTareo = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpTiempoParada = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnActualizarTiempoParada = New System.Windows.Forms.Button()
        Me.dtpTiempoRefrigerio = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizarTiempoRefrigerio = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpHoraInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizarHoraInicio = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnActualizarFechaFin = New System.Windows.Forms.Button()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.btnActualizarHoraFin = New System.Windows.Forms.Button()
        Me.txtLimiteaaa = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblIdTareo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblUsuarioCrea = New System.Windows.Forms.Label()
        Me.lblFechaHoraCreacion = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboPuntoControl = New System.Windows.Forms.ComboBox()
        Me.btnDescargarMarcas = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboTerminales = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 6
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel3, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel4, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel5, 1, 4)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 10
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1081, 542)
        Me.tlpPrincipal.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel1, 4)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btnRevertirTareo, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEditar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGenerarTareo, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1045, 29)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'btnRevertirTareo
        '
        Me.btnRevertirTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnRevertirTareo.AutoSize = True
        Me.btnRevertirTareo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRevertirTareo.Location = New System.Drawing.Point(957, 3)
        Me.btnRevertirTareo.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnRevertirTareo.Name = "btnRevertirTareo"
        Me.btnRevertirTareo.Size = New System.Drawing.Size(85, 23)
        Me.btnRevertirTareo.TabIndex = 20
        Me.btnRevertirTareo.Text = "Revertir Tareo"
        Me.btnRevertirTareo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar.AutoSize = True
        Me.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEditar.Location = New System.Drawing.Point(3, 3)
        Me.btnEditar.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(44, 23)
        Me.btnEditar.TabIndex = 21
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnGenerarTareo
        '
        Me.btnGenerarTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGenerarTareo.AutoSize = True
        Me.btnGenerarTareo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenerarTareo.Location = New System.Drawing.Point(865, 3)
        Me.btnGenerarTareo.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnGenerarTareo.Name = "btnGenerarTareo"
        Me.btnGenerarTareo.Size = New System.Drawing.Size(86, 23)
        Me.btnGenerarTareo.TabIndex = 22
        Me.btnGenerarTareo.Text = "Generar Tareo"
        Me.btnGenerarTareo.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.AutoSize = True
        Me.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancelar.Location = New System.Drawing.Point(53, 3)
        Me.btnCancelar.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(59, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.AutoSize = True
        Me.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGuardar.Location = New System.Drawing.Point(118, 3)
        Me.btnGuardar.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(55, 23)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 4)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 204)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1045, 278)
        Me.dgvResultado.TabIndex = 5
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResultado, 2)
        Me.lblResultado.Location = New System.Drawing.Point(18, 514)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 23
        Me.lblResultado.Text = "Listo!"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 4)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 488)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1045, 23)
        Me.barProgreso.TabIndex = 24
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dtpFechaInicio, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboTurno, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboCultivo, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cboEstado, 8, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(18, 72)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1045, 27)
        Me.TableLayoutPanel2.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha Inicio:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(77, 3)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaInicio.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(163, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Turno:"
        '
        'cboTurno
        '
        Me.cboTurno.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(207, 3)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(120, 21)
        Me.cboTurno.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(333, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Cultivo:"
        '
        'cboCultivo
        '
        Me.cboCultivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(381, 3)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(150, 21)
        Me.cboCultivo.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(873, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estado."
        '
        'cboEstado
        '
        Me.cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(922, 3)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(120, 21)
        Me.cboEstado.TabIndex = 8
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 12
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel3, 4)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.Label14, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 9, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpTiempoParada, 10, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 9, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarTiempoParada, 11, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpTiempoRefrigerio, 10, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarTiempoRefrigerio, 11, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpHoraInicio, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarHoraInicio, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpFechaFin, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarFechaFin, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpHoraFin, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarHoraFin, 5, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtLimiteaaa, 7, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(18, 140)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1045, 58)
        Me.TableLayoutPanel3.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(443, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Tiempo Limite:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(776, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Tiempo de Parada:"
        '
        'dtpTiempoParada
        '
        Me.dtpTiempoParada.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpTiempoParada.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTiempoParada.Location = New System.Drawing.Point(893, 33)
        Me.dtpTiempoParada.Name = "dtpTiempoParada"
        Me.dtpTiempoParada.ShowUpDown = True
        Me.dtpTiempoParada.Size = New System.Drawing.Size(80, 20)
        Me.dtpTiempoParada.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(776, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Tiempo  de Refrigerio:"
        '
        'btnActualizarTiempoParada
        '
        Me.btnActualizarTiempoParada.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnActualizarTiempoParada.AutoSize = True
        Me.btnActualizarTiempoParada.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActualizarTiempoParada.Location = New System.Drawing.Point(979, 32)
        Me.btnActualizarTiempoParada.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnActualizarTiempoParada.Name = "btnActualizarTiempoParada"
        Me.btnActualizarTiempoParada.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarTiempoParada.TabIndex = 9
        Me.btnActualizarTiempoParada.Text = "Actualizar"
        Me.btnActualizarTiempoParada.UseVisualStyleBackColor = True
        '
        'dtpTiempoRefrigerio
        '
        Me.dtpTiempoRefrigerio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpTiempoRefrigerio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTiempoRefrigerio.Location = New System.Drawing.Point(893, 4)
        Me.dtpTiempoRefrigerio.Name = "dtpTiempoRefrigerio"
        Me.dtpTiempoRefrigerio.ShowUpDown = True
        Me.dtpTiempoRefrigerio.Size = New System.Drawing.Size(80, 20)
        Me.dtpTiempoRefrigerio.TabIndex = 18
        '
        'btnActualizarTiempoRefrigerio
        '
        Me.btnActualizarTiempoRefrigerio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnActualizarTiempoRefrigerio.AutoSize = True
        Me.btnActualizarTiempoRefrigerio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActualizarTiempoRefrigerio.Location = New System.Drawing.Point(979, 3)
        Me.btnActualizarTiempoRefrigerio.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnActualizarTiempoRefrigerio.Name = "btnActualizarTiempoRefrigerio"
        Me.btnActualizarTiempoRefrigerio.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarTiempoRefrigerio.TabIndex = 10
        Me.btnActualizarTiempoRefrigerio.Text = "Actualizar"
        Me.btnActualizarTiempoRefrigerio.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Hora Inicio:"
        '
        'dtpHoraInicio
        '
        Me.dtpHoraInicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraInicio.Location = New System.Drawing.Point(70, 4)
        Me.dtpHoraInicio.Name = "dtpHoraInicio"
        Me.dtpHoraInicio.ShowUpDown = True
        Me.dtpHoraInicio.Size = New System.Drawing.Size(80, 20)
        Me.dtpHoraInicio.TabIndex = 16
        '
        'btnActualizarHoraInicio
        '
        Me.btnActualizarHoraInicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnActualizarHoraInicio.AutoSize = True
        Me.btnActualizarHoraInicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActualizarHoraInicio.Location = New System.Drawing.Point(156, 3)
        Me.btnActualizarHoraInicio.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnActualizarHoraInicio.Name = "btnActualizarHoraInicio"
        Me.btnActualizarHoraInicio.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarHoraInicio.TabIndex = 7
        Me.btnActualizarHoraInicio.Text = "Actualizar"
        Me.btnActualizarHoraInicio.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(225, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha Fin:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(288, 4)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaFin.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(225, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Hora Fin:"
        '
        'btnActualizarFechaFin
        '
        Me.btnActualizarFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnActualizarFechaFin.AutoSize = True
        Me.btnActualizarFechaFin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActualizarFechaFin.Location = New System.Drawing.Point(374, 3)
        Me.btnActualizarFechaFin.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnActualizarFechaFin.Name = "btnActualizarFechaFin"
        Me.btnActualizarFechaFin.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarFechaFin.TabIndex = 8
        Me.btnActualizarFechaFin.Text = "Actualizar"
        Me.btnActualizarFechaFin.UseVisualStyleBackColor = True
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(288, 33)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.ShowUpDown = True
        Me.dtpHoraFin.Size = New System.Drawing.Size(80, 20)
        Me.dtpHoraFin.TabIndex = 17
        '
        'btnActualizarHoraFin
        '
        Me.btnActualizarHoraFin.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnActualizarHoraFin.AutoSize = True
        Me.btnActualizarHoraFin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnActualizarHoraFin.Location = New System.Drawing.Point(374, 32)
        Me.btnActualizarHoraFin.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnActualizarHoraFin.Name = "btnActualizarHoraFin"
        Me.btnActualizarHoraFin.Size = New System.Drawing.Size(63, 23)
        Me.btnActualizarHoraFin.TabIndex = 6
        Me.btnActualizarHoraFin.Text = "Actualizar"
        Me.btnActualizarHoraFin.UseVisualStyleBackColor = True
        '
        'txtLimiteaaa
        '
        Me.txtLimiteaaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimiteaaa.Location = New System.Drawing.Point(524, 3)
        Me.txtLimiteaaa.Name = "txtLimiteaaa"
        Me.txtLimiteaaa.Size = New System.Drawing.Size(101, 20)
        Me.txtLimiteaaa.TabIndex = 21
        Me.txtLimiteaaa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel4, 4)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.lblIdTareo, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblUsuarioCrea, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblFechaHoraCreacion, 5, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(18, 53)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1045, 13)
        Me.TableLayoutPanel4.TabIndex = 27
        '
        'lblIdTareo
        '
        Me.lblIdTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIdTareo.AutoSize = True
        Me.lblIdTareo.Location = New System.Drawing.Point(3, 0)
        Me.lblIdTareo.Name = "lblIdTareo"
        Me.lblIdTareo.Size = New System.Drawing.Size(45, 13)
        Me.lblIdTareo.TabIndex = 0
        Me.lblIdTareo.Text = "# Tareo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(813, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Hora Creacion:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(655, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Usuario Crea:"
        '
        'lblUsuarioCrea
        '
        Me.lblUsuarioCrea.AutoSize = True
        Me.lblUsuarioCrea.Location = New System.Drawing.Point(732, 0)
        Me.lblUsuarioCrea.Name = "lblUsuarioCrea"
        Me.lblUsuarioCrea.Size = New System.Drawing.Size(75, 13)
        Me.lblUsuarioCrea.TabIndex = 3
        Me.lblUsuarioCrea.Text = "lblUsuarioCrea"
        '
        'lblFechaHoraCreacion
        '
        Me.lblFechaHoraCreacion.AutoSize = True
        Me.lblFechaHoraCreacion.Location = New System.Drawing.Point(930, 0)
        Me.lblFechaHoraCreacion.Name = "lblFechaHoraCreacion"
        Me.lblFechaHoraCreacion.Size = New System.Drawing.Size(112, 13)
        Me.lblFechaHoraCreacion.TabIndex = 4
        Me.lblFechaHoraCreacion.Text = "lblFechaHoraCreacion"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel5.ColumnCount = 7
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel5, 4)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.cboPuntoControl, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnDescargarMarcas, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboTerminales, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnEliminar, 6, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(18, 105)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1045, 29)
        Me.TableLayoutPanel5.TabIndex = 28
        '
        'cboPuntoControl
        '
        Me.cboPuntoControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPuntoControl.FormattingEnabled = True
        Me.cboPuntoControl.Location = New System.Drawing.Point(98, 3)
        Me.cboPuntoControl.Name = "cboPuntoControl"
        Me.cboPuntoControl.Size = New System.Drawing.Size(509, 21)
        Me.cboPuntoControl.TabIndex = 11
        '
        'btnDescargarMarcas
        '
        Me.btnDescargarMarcas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDescargarMarcas.AutoSize = True
        Me.btnDescargarMarcas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDescargarMarcas.Location = New System.Drawing.Point(825, 3)
        Me.btnDescargarMarcas.Name = "btnDescargarMarcas"
        Me.btnDescargarMarcas.Size = New System.Drawing.Size(104, 23)
        Me.btnDescargarMarcas.TabIndex = 21
        Me.btnDescargarMarcas.Text = "Descargar Marcas"
        Me.btnDescargarMarcas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Punto de Control:"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(613, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Terminal:"
        '
        'cboTerminales
        '
        Me.cboTerminales.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTerminales.FormattingEnabled = True
        Me.cboTerminales.Location = New System.Drawing.Point(669, 4)
        Me.cboTerminales.Name = "cboTerminales"
        Me.cboTerminales.Size = New System.Drawing.Size(150, 21)
        Me.cboTerminales.TabIndex = 23
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(967, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 24
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmPacking_Movimientos_TareosPackingDetalle_Nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 542)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_TareosPackingDetalle_Nuevo"
        Me.Text = "[Supervision/Movimientos/Tareos/Nuevo Tareo Packing]"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents lblIdTareo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnActualizarHoraFin As Button
    Friend WithEvents btnActualizarHoraInicio As Button
    Friend WithEvents btnActualizarFechaFin As Button
    Friend WithEvents btnActualizarTiempoParada As Button
    Friend WithEvents btnActualizarTiempoRefrigerio As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents cboTurno As ComboBox
    Friend WithEvents cboCultivo As ComboBox
    Friend WithEvents cboPuntoControl As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpHoraInicio As DateTimePicker
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents dtpTiempoParada As DateTimePicker
    Friend WithEvents btnRevertirTareo As Button
    Friend WithEvents btnDescargarMarcas As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGenerarTareo As Button
    Friend WithEvents lblResultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblUsuarioCrea As Label
    Friend WithEvents lblFechaHoraCreacion As Label
    Friend WithEvents dtpTiempoRefrigerio As DateTimePicker
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents cboTerminales As ComboBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents txtLimiteaaa As TextBox
End Class
