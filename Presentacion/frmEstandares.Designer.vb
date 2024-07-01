<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEstandares
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
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.grpBuscar = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboAnio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSemana = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pkrFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pkrFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.grpGestionar = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.grpEditar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel13 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboActividad = New System.Windows.Forms.ComboBox()
        Me.cboConsumidor = New System.Windows.Forms.ComboBox()
        Me.lblCultivo = New System.Windows.Forms.Label()
        Me.cboLabor = New System.Windows.Forms.ComboBox()
        Me.lblTipoCampana = New System.Windows.Forms.Label()
        Me.cboTipoCampana = New System.Windows.Forms.ComboBox()
        Me.lblTipoCosto = New System.Windows.Forms.Label()
        Me.lblActividad = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.txtTarea = New System.Windows.Forms.TextBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBuscar.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.grpGestionar.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.grpEditar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 4
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.39642!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.60358!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.grpBuscar, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.grpGestionar, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.grpEditar, 1, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Font = New System.Drawing.Font("mononoki", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1370, 749)
        Me.tlpPrincipal.TabIndex = 1
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 2)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 156)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResultado.Size = New System.Drawing.Size(1323, 536)
        Me.dgvResultado.TabIndex = 19
        '
        'grpBuscar
        '
        Me.grpBuscar.AutoSize = True
        Me.grpBuscar.Controls.Add(Me.FlowLayoutPanel1)
        Me.grpBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBuscar.Location = New System.Drawing.Point(18, 23)
        Me.grpBuscar.Name = "grpBuscar"
        Me.grpBuscar.Size = New System.Drawing.Size(717, 48)
        Me.grpBuscar.TabIndex = 1
        Me.grpBuscar.TabStop = False
        Me.grpBuscar.Text = "Buscar"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboAnio)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboSemana)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.pkrFechaDesde)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.pkrFechaHasta)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(711, 29)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Año:"
        '
        'cboAnio
        '
        Me.cboAnio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboAnio.FormattingEnabled = True
        Me.cboAnio.Location = New System.Drawing.Point(40, 3)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(121, 21)
        Me.cboAnio.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(167, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Semana:"
        '
        'cboSemana
        '
        Me.cboSemana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSemana.FormattingEnabled = True
        Me.cboSemana.Location = New System.Drawing.Point(222, 3)
        Me.cboSemana.Name = "cboSemana"
        Me.cboSemana.Size = New System.Drawing.Size(118, 21)
        Me.cboSemana.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(346, 7)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Desde:"
        '
        'pkrFechaDesde
        '
        Me.pkrFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrFechaDesde.Location = New System.Drawing.Point(395, 3)
        Me.pkrFechaDesde.Name = "pkrFechaDesde"
        Me.pkrFechaDesde.Size = New System.Drawing.Size(116, 20)
        Me.pkrFechaDesde.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(517, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta:"
        '
        'pkrFechaHasta
        '
        Me.pkrFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrFechaHasta.Location = New System.Drawing.Point(566, 3)
        Me.pkrFechaHasta.Name = "pkrFechaHasta"
        Me.pkrFechaHasta.Size = New System.Drawing.Size(108, 20)
        Me.pkrFechaHasta.TabIndex = 6
        '
        'grpGestionar
        '
        Me.grpGestionar.AutoSize = True
        Me.grpGestionar.Controls.Add(Me.FlowLayoutPanel2)
        Me.grpGestionar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGestionar.Location = New System.Drawing.Point(741, 23)
        Me.grpGestionar.Name = "grpGestionar"
        Me.grpGestionar.Size = New System.Drawing.Size(600, 48)
        Me.grpGestionar.TabIndex = 3
        Me.grpGestionar.TabStop = False
        Me.grpGestionar.Text = "Gestionar"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnNuevo)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnGuardar)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnCancelar)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnEliminar)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(594, 29)
        Me.FlowLayoutPanel2.TabIndex = 0
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Location = New System.Drawing.Point(84, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.Location = New System.Drawing.Point(165, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Consultar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(246, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 2)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 717)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1323, 14)
        Me.barProgreso.TabIndex = 6
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(18, 698)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(43, 13)
        Me.lblResultado.TabIndex = 7
        Me.lblResultado.Text = "Listo!"
        '
        'grpEditar
        '
        Me.grpEditar.AutoSize = True
        Me.grpEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPrincipal.SetColumnSpan(Me.grpEditar, 2)
        Me.grpEditar.Controls.Add(Me.TableLayoutPanel1)
        Me.grpEditar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpEditar.Location = New System.Drawing.Point(18, 77)
        Me.grpEditar.Name = "grpEditar"
        Me.grpEditar.Size = New System.Drawing.Size(1323, 73)
        Me.grpEditar.TabIndex = 8
        Me.grpEditar.TabStop = False
        Me.grpEditar.Text = "Editar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.9661!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.27684!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.637773!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.98379!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel13, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboActividad, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboConsumidor, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCultivo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLabor, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipoCampana, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoCampana, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipoCosto, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblActividad, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGrupo, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTarea, 5, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1317, 54)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel13
        '
        Me.FlowLayoutPanel13.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel13, 6)
        Me.FlowLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel13.Location = New System.Drawing.Point(936, 54)
        Me.FlowLayoutPanel13.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.FlowLayoutPanel13.Name = "FlowLayoutPanel13"
        Me.FlowLayoutPanel13.Size = New System.Drawing.Size(378, 1)
        Me.FlowLayoutPanel13.TabIndex = 20
        '
        'cboActividad
        '
        Me.cboActividad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboActividad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboActividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboActividad.FormattingEnabled = True
        Me.cboActividad.Location = New System.Drawing.Point(642, 3)
        Me.cboActividad.Name = "cboActividad"
        Me.cboActividad.Size = New System.Drawing.Size(288, 21)
        Me.cboActividad.TabIndex = 9
        '
        'cboConsumidor
        '
        Me.cboConsumidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboConsumidor.FormattingEnabled = True
        Me.cboConsumidor.Location = New System.Drawing.Point(359, 3)
        Me.cboConsumidor.Name = "cboConsumidor"
        Me.cboConsumidor.Size = New System.Drawing.Size(204, 21)
        Me.cboConsumidor.TabIndex = 8
        '
        'lblCultivo
        '
        Me.lblCultivo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCultivo.AutoSize = True
        Me.lblCultivo.Location = New System.Drawing.Point(280, 7)
        Me.lblCultivo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCultivo.Name = "lblCultivo"
        Me.lblCultivo.Size = New System.Drawing.Size(73, 13)
        Me.lblCultivo.TabIndex = 0
        Me.lblCultivo.Text = "Consumidor:"
        '
        'cboLabor
        '
        Me.cboLabor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLabor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboLabor, 3)
        Me.cboLabor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLabor.FormattingEnabled = True
        Me.cboLabor.Location = New System.Drawing.Point(112, 30)
        Me.cboLabor.Name = "cboLabor"
        Me.cboLabor.Size = New System.Drawing.Size(451, 21)
        Me.cboLabor.TabIndex = 13
        '
        'lblTipoCampana
        '
        Me.lblTipoCampana.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTipoCampana.AutoSize = True
        Me.lblTipoCampana.Location = New System.Drawing.Point(63, 34)
        Me.lblTipoCampana.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTipoCampana.Name = "lblTipoCampana"
        Me.lblTipoCampana.Size = New System.Drawing.Size(43, 13)
        Me.lblTipoCampana.TabIndex = 0
        Me.lblTipoCampana.Text = "Labor:"
        '
        'cboTipoCampana
        '
        Me.cboTipoCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipoCampana.FormattingEnabled = True
        Me.cboTipoCampana.Location = New System.Drawing.Point(112, 3)
        Me.cboTipoCampana.Name = "cboTipoCampana"
        Me.cboTipoCampana.Size = New System.Drawing.Size(162, 21)
        Me.cboTipoCampana.TabIndex = 7
        '
        'lblTipoCosto
        '
        Me.lblTipoCosto.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTipoCosto.AutoSize = True
        Me.lblTipoCosto.Location = New System.Drawing.Point(3, 7)
        Me.lblTipoCosto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTipoCosto.Name = "lblTipoCosto"
        Me.lblTipoCosto.Size = New System.Drawing.Size(103, 13)
        Me.lblTipoCosto.TabIndex = 0
        Me.lblTipoCosto.Text = "Tipo de Campaña:"
        '
        'lblActividad
        '
        Me.lblActividad.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblActividad.AutoSize = True
        Me.lblActividad.Location = New System.Drawing.Point(569, 7)
        Me.lblActividad.Margin = New System.Windows.Forms.Padding(3)
        Me.lblActividad.Name = "lblActividad"
        Me.lblActividad.Size = New System.Drawing.Size(67, 13)
        Me.lblActividad.TabIndex = 0
        Me.lblActividad.Text = "Actividad:"
        '
        'lblGrupo
        '
        Me.lblGrupo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(593, 34)
        Me.lblGrupo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(43, 13)
        Me.lblGrupo.TabIndex = 0
        Me.lblGrupo.Text = "Tarea:"
        '
        'txtTarea
        '
        Me.txtTarea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTarea.Location = New System.Drawing.Point(642, 30)
        Me.txtTarea.Name = "txtTarea"
        Me.txtTarea.Size = New System.Drawing.Size(288, 20)
        Me.txtTarea.TabIndex = 21
        '
        'frmEstandares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmEstandares"
        Me.Text = "frmEstandares"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBuscar.ResumeLayout(False)
        Me.grpBuscar.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.grpGestionar.ResumeLayout(False)
        Me.grpGestionar.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.grpEditar.ResumeLayout(False)
        Me.grpEditar.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents grpBuscar As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSemana As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents grpGestionar As GroupBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents lblResultado As Label
    Friend WithEvents grpEditar As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel13 As FlowLayoutPanel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cboActividad As ComboBox
    Friend WithEvents cboConsumidor As ComboBox
    Friend WithEvents lblCultivo As Label
    Friend WithEvents cboLabor As ComboBox
    Friend WithEvents lblTipoCampana As Label
    Friend WithEvents cboTipoCampana As ComboBox
    Friend WithEvents lblTipoCosto As Label
    Friend WithEvents lblActividad As Label
    Friend WithEvents lblGrupo As Label
    Friend WithEvents pkrFechaDesde As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents pkrFechaHasta As DateTimePicker
    Friend WithEvents txtTarea As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboAnio As ComboBox
End Class
