<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Movimientos_FusionarCajasBifurcadas
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cbxSoloCajasBifurcadas = New System.Windows.Forms.CheckBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.btnFusionar = New System.Windows.Forms.Button()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.tlpMatch = New DataGreen.ExTableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblLineaA = New System.Windows.Forms.Label()
        Me.lblLineaB = New System.Windows.Forms.Label()
        Me.lblIdPalletA = New System.Windows.Forms.Label()
        Me.lblIdPalletB = New System.Windows.Forms.Label()
        Me.lblNroCajaA = New System.Windows.Forms.Label()
        Me.lblNroCajaB = New System.Windows.Forms.Label()
        Me.lblSeleccionA = New System.Windows.Forms.Label()
        Me.lblSeleccionB = New System.Windows.Forms.Label()
        Me.lblPesadoA = New System.Windows.Forms.Label()
        Me.lblPesadoB = New System.Windows.Forms.Label()
        Me.lblEmpaqueA = New System.Windows.Forms.Label()
        Me.lblEmpaqueB = New System.Windows.Forms.Label()
        Me.lblCultivoA = New System.Windows.Forms.Label()
        Me.lblCultivoB = New System.Windows.Forms.Label()
        Me.lblVariedadA = New System.Windows.Forms.Label()
        Me.lblVariedadB = New System.Windows.Forms.Label()
        Me.lblFormatoA = New System.Windows.Forms.Label()
        Me.lblFormatoB = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblFactLinea = New System.Windows.Forms.Label()
        Me.lblFactIdPallet = New System.Windows.Forms.Label()
        Me.lblFactNroCaja = New System.Windows.Forms.Label()
        Me.lblFactSeleccion = New System.Windows.Forms.Label()
        Me.lblFactPesado = New System.Windows.Forms.Label()
        Me.lblFactEmpaque = New System.Windows.Forms.Label()
        Me.lblFactCultivo = New System.Windows.Forms.Label()
        Me.lblFactVariedad = New System.Windows.Forms.Label()
        Me.lblFactFormato = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMatch.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 8
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpFecha, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.cbxSoloCajasBifurcadas, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.tlpMatch, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnFusionar, 6, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(868, 414)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(64, 19)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'cbxSoloCajasBifurcadas
        '
        Me.cbxSoloCajasBifurcadas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxSoloCajasBifurcadas.AutoSize = True
        Me.cbxSoloCajasBifurcadas.Location = New System.Drawing.Point(170, 21)
        Me.cbxSoloCajasBifurcadas.Name = "cbxSoloCajasBifurcadas"
        Me.cbxSoloCajasBifurcadas.Size = New System.Drawing.Size(129, 17)
        Me.cbxSoloCajasBifurcadas.TabIndex = 3
        Me.cbxSoloCajasBifurcadas.Text = "Solo Cajas Bifurcadas"
        Me.cbxSoloCajasBifurcadas.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnExportar.Location = New System.Drawing.Point(775, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.Location = New System.Drawing.Point(694, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 6)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 163)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(832, 185)
        Me.dgvResultado.TabIndex = 6
        '
        'btnFusionar
        '
        Me.btnFusionar.Location = New System.Drawing.Point(775, 134)
        Me.btnFusionar.Name = "btnFusionar"
        Me.btnFusionar.Size = New System.Drawing.Size(75, 23)
        Me.btnFusionar.TabIndex = 7
        Me.btnFusionar.Text = "Fusionar"
        Me.btnFusionar.UseVisualStyleBackColor = True
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 383)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 8
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 6)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 354)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(832, 23)
        Me.barProgreso.TabIndex = 9
        '
        'tlpMatch
        '
        Me.tlpMatch.AutoSize = True
        Me.tlpMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMatch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpMatch.ColumnCount = 10
        Me.tlpPrincipal.SetColumnSpan(Me.tlpMatch, 6)
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMatch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMatch.Controls.Add(Me.Label2, 0, 1)
        Me.tlpMatch.Controls.Add(Me.Label3, 0, 2)
        Me.tlpMatch.Controls.Add(Me.Label4, 1, 0)
        Me.tlpMatch.Controls.Add(Me.Label5, 2, 0)
        Me.tlpMatch.Controls.Add(Me.Label6, 3, 0)
        Me.tlpMatch.Controls.Add(Me.Label7, 4, 0)
        Me.tlpMatch.Controls.Add(Me.Label8, 5, 0)
        Me.tlpMatch.Controls.Add(Me.Label9, 6, 0)
        Me.tlpMatch.Controls.Add(Me.Label10, 7, 0)
        Me.tlpMatch.Controls.Add(Me.Label11, 8, 0)
        Me.tlpMatch.Controls.Add(Me.Label12, 9, 0)
        Me.tlpMatch.Controls.Add(Me.lblLineaA, 1, 1)
        Me.tlpMatch.Controls.Add(Me.lblLineaB, 1, 2)
        Me.tlpMatch.Controls.Add(Me.lblIdPalletA, 2, 1)
        Me.tlpMatch.Controls.Add(Me.lblIdPalletB, 2, 2)
        Me.tlpMatch.Controls.Add(Me.lblNroCajaA, 3, 1)
        Me.tlpMatch.Controls.Add(Me.lblNroCajaB, 3, 2)
        Me.tlpMatch.Controls.Add(Me.lblSeleccionA, 4, 1)
        Me.tlpMatch.Controls.Add(Me.lblSeleccionB, 4, 2)
        Me.tlpMatch.Controls.Add(Me.lblPesadoA, 5, 1)
        Me.tlpMatch.Controls.Add(Me.lblPesadoB, 5, 2)
        Me.tlpMatch.Controls.Add(Me.lblEmpaqueA, 6, 1)
        Me.tlpMatch.Controls.Add(Me.lblEmpaqueB, 6, 2)
        Me.tlpMatch.Controls.Add(Me.lblCultivoA, 7, 1)
        Me.tlpMatch.Controls.Add(Me.lblCultivoB, 7, 2)
        Me.tlpMatch.Controls.Add(Me.lblVariedadA, 8, 1)
        Me.tlpMatch.Controls.Add(Me.lblVariedadB, 8, 2)
        Me.tlpMatch.Controls.Add(Me.lblFormatoA, 9, 1)
        Me.tlpMatch.Controls.Add(Me.lblFormatoB, 9, 2)
        Me.tlpMatch.Controls.Add(Me.Label13, 0, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactLinea, 1, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactIdPallet, 2, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactNroCaja, 3, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactSeleccion, 4, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactPesado, 5, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactEmpaque, 6, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactCultivo, 7, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactVariedad, 8, 3)
        Me.tlpMatch.Controls.Add(Me.lblFactFormato, 9, 3)
        Me.tlpMatch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMatch.Location = New System.Drawing.Point(18, 47)
        Me.tlpMatch.Name = "tlpMatch"
        Me.tlpMatch.RowCount = 4
        Me.tlpMatch.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMatch.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMatch.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMatch.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMatch.Size = New System.Drawing.Size(832, 81)
        Me.tlpMatch.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Caja A:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 44)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Caja B:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Linea"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(98, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "IdPallet"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(166, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "# Caja"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(211, 4)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Seleccion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(285, 4)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Pesado"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(359, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Empaque"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(433, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Cultivo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(567, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Variedad"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(701, 4)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Formato"
        '
        'lblLineaA
        '
        Me.lblLineaA.AutoSize = True
        Me.lblLineaA.Location = New System.Drawing.Point(58, 24)
        Me.lblLineaA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblLineaA.Name = "lblLineaA"
        Me.lblLineaA.Size = New System.Drawing.Size(13, 13)
        Me.lblLineaA.TabIndex = 11
        Me.lblLineaA.Text = "0"
        '
        'lblLineaB
        '
        Me.lblLineaB.AutoSize = True
        Me.lblLineaB.Location = New System.Drawing.Point(58, 44)
        Me.lblLineaB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblLineaB.Name = "lblLineaB"
        Me.lblLineaB.Size = New System.Drawing.Size(13, 13)
        Me.lblLineaB.TabIndex = 12
        Me.lblLineaB.Text = "0"
        '
        'lblIdPalletA
        '
        Me.lblIdPalletA.AutoSize = True
        Me.lblIdPalletA.Location = New System.Drawing.Point(98, 24)
        Me.lblIdPalletA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdPalletA.Name = "lblIdPalletA"
        Me.lblIdPalletA.Size = New System.Drawing.Size(61, 13)
        Me.lblIdPalletA.TabIndex = 13
        Me.lblIdPalletA.Text = "000000000"
        '
        'lblIdPalletB
        '
        Me.lblIdPalletB.AutoSize = True
        Me.lblIdPalletB.Location = New System.Drawing.Point(98, 44)
        Me.lblIdPalletB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdPalletB.Name = "lblIdPalletB"
        Me.lblIdPalletB.Size = New System.Drawing.Size(61, 13)
        Me.lblIdPalletB.TabIndex = 14
        Me.lblIdPalletB.Text = "000000000"
        '
        'lblNroCajaA
        '
        Me.lblNroCajaA.AutoSize = True
        Me.lblNroCajaA.Location = New System.Drawing.Point(166, 24)
        Me.lblNroCajaA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroCajaA.Name = "lblNroCajaA"
        Me.lblNroCajaA.Size = New System.Drawing.Size(25, 13)
        Me.lblNroCajaA.TabIndex = 15
        Me.lblNroCajaA.Text = "000"
        '
        'lblNroCajaB
        '
        Me.lblNroCajaB.AutoSize = True
        Me.lblNroCajaB.Location = New System.Drawing.Point(166, 44)
        Me.lblNroCajaB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroCajaB.Name = "lblNroCajaB"
        Me.lblNroCajaB.Size = New System.Drawing.Size(25, 13)
        Me.lblNroCajaB.TabIndex = 16
        Me.lblNroCajaB.Text = "000"
        '
        'lblSeleccionA
        '
        Me.lblSeleccionA.AutoSize = True
        Me.lblSeleccionA.Location = New System.Drawing.Point(211, 24)
        Me.lblSeleccionA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSeleccionA.Name = "lblSeleccionA"
        Me.lblSeleccionA.Size = New System.Drawing.Size(67, 13)
        Me.lblSeleccionA.TabIndex = 17
        Me.lblSeleccionA.Text = "0000000000"
        '
        'lblSeleccionB
        '
        Me.lblSeleccionB.AutoSize = True
        Me.lblSeleccionB.Location = New System.Drawing.Point(211, 44)
        Me.lblSeleccionB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSeleccionB.Name = "lblSeleccionB"
        Me.lblSeleccionB.Size = New System.Drawing.Size(67, 13)
        Me.lblSeleccionB.TabIndex = 18
        Me.lblSeleccionB.Text = "0000000000"
        '
        'lblPesadoA
        '
        Me.lblPesadoA.AutoSize = True
        Me.lblPesadoA.Location = New System.Drawing.Point(285, 24)
        Me.lblPesadoA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPesadoA.Name = "lblPesadoA"
        Me.lblPesadoA.Size = New System.Drawing.Size(67, 13)
        Me.lblPesadoA.TabIndex = 19
        Me.lblPesadoA.Text = "0000000000"
        '
        'lblPesadoB
        '
        Me.lblPesadoB.AutoSize = True
        Me.lblPesadoB.Location = New System.Drawing.Point(285, 44)
        Me.lblPesadoB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPesadoB.Name = "lblPesadoB"
        Me.lblPesadoB.Size = New System.Drawing.Size(67, 13)
        Me.lblPesadoB.TabIndex = 20
        Me.lblPesadoB.Text = "0000000000"
        '
        'lblEmpaqueA
        '
        Me.lblEmpaqueA.AutoSize = True
        Me.lblEmpaqueA.Location = New System.Drawing.Point(359, 24)
        Me.lblEmpaqueA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblEmpaqueA.Name = "lblEmpaqueA"
        Me.lblEmpaqueA.Size = New System.Drawing.Size(67, 13)
        Me.lblEmpaqueA.TabIndex = 21
        Me.lblEmpaqueA.Text = "0000000000"
        '
        'lblEmpaqueB
        '
        Me.lblEmpaqueB.AutoSize = True
        Me.lblEmpaqueB.Location = New System.Drawing.Point(359, 44)
        Me.lblEmpaqueB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblEmpaqueB.Name = "lblEmpaqueB"
        Me.lblEmpaqueB.Size = New System.Drawing.Size(67, 13)
        Me.lblEmpaqueB.TabIndex = 22
        Me.lblEmpaqueB.Text = "0000000000"
        '
        'lblCultivoA
        '
        Me.lblCultivoA.AutoSize = True
        Me.lblCultivoA.Location = New System.Drawing.Point(433, 24)
        Me.lblCultivoA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCultivoA.Name = "lblCultivoA"
        Me.lblCultivoA.Size = New System.Drawing.Size(13, 13)
        Me.lblCultivoA.TabIndex = 23
        Me.lblCultivoA.Text = "0"
        '
        'lblCultivoB
        '
        Me.lblCultivoB.AutoSize = True
        Me.lblCultivoB.Location = New System.Drawing.Point(433, 44)
        Me.lblCultivoB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCultivoB.Name = "lblCultivoB"
        Me.lblCultivoB.Size = New System.Drawing.Size(13, 13)
        Me.lblCultivoB.TabIndex = 24
        Me.lblCultivoB.Text = "0"
        '
        'lblVariedadA
        '
        Me.lblVariedadA.AutoSize = True
        Me.lblVariedadA.Location = New System.Drawing.Point(567, 24)
        Me.lblVariedadA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblVariedadA.Name = "lblVariedadA"
        Me.lblVariedadA.Size = New System.Drawing.Size(13, 13)
        Me.lblVariedadA.TabIndex = 25
        Me.lblVariedadA.Text = "0"
        '
        'lblVariedadB
        '
        Me.lblVariedadB.AutoSize = True
        Me.lblVariedadB.Location = New System.Drawing.Point(567, 44)
        Me.lblVariedadB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblVariedadB.Name = "lblVariedadB"
        Me.lblVariedadB.Size = New System.Drawing.Size(13, 13)
        Me.lblVariedadB.TabIndex = 26
        Me.lblVariedadB.Text = "0"
        '
        'lblFormatoA
        '
        Me.lblFormatoA.AutoSize = True
        Me.lblFormatoA.Location = New System.Drawing.Point(701, 24)
        Me.lblFormatoA.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFormatoA.Name = "lblFormatoA"
        Me.lblFormatoA.Size = New System.Drawing.Size(13, 13)
        Me.lblFormatoA.TabIndex = 27
        Me.lblFormatoA.Text = "0"
        '
        'lblFormatoB
        '
        Me.lblFormatoB.AutoSize = True
        Me.lblFormatoB.Location = New System.Drawing.Point(701, 44)
        Me.lblFormatoB.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFormatoB.Name = "lblFormatoB"
        Me.lblFormatoB.Size = New System.Drawing.Size(13, 13)
        Me.lblFormatoB.TabIndex = 28
        Me.lblFormatoB.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 64)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Factible:"
        '
        'lblFactLinea
        '
        Me.lblFactLinea.AutoSize = True
        Me.lblFactLinea.Location = New System.Drawing.Point(58, 64)
        Me.lblFactLinea.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactLinea.Name = "lblFactLinea"
        Me.lblFactLinea.Size = New System.Drawing.Size(21, 13)
        Me.lblFactLinea.TabIndex = 30
        Me.lblFactLinea.Text = "Ok"
        '
        'lblFactIdPallet
        '
        Me.lblFactIdPallet.AutoSize = True
        Me.lblFactIdPallet.Location = New System.Drawing.Point(98, 64)
        Me.lblFactIdPallet.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactIdPallet.Name = "lblFactIdPallet"
        Me.lblFactIdPallet.Size = New System.Drawing.Size(21, 13)
        Me.lblFactIdPallet.TabIndex = 31
        Me.lblFactIdPallet.Text = "Ok"
        '
        'lblFactNroCaja
        '
        Me.lblFactNroCaja.AutoSize = True
        Me.lblFactNroCaja.Location = New System.Drawing.Point(166, 64)
        Me.lblFactNroCaja.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactNroCaja.Name = "lblFactNroCaja"
        Me.lblFactNroCaja.Size = New System.Drawing.Size(21, 13)
        Me.lblFactNroCaja.TabIndex = 32
        Me.lblFactNroCaja.Text = "Ok"
        '
        'lblFactSeleccion
        '
        Me.lblFactSeleccion.AutoSize = True
        Me.lblFactSeleccion.Location = New System.Drawing.Point(211, 64)
        Me.lblFactSeleccion.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactSeleccion.Name = "lblFactSeleccion"
        Me.lblFactSeleccion.Size = New System.Drawing.Size(21, 13)
        Me.lblFactSeleccion.TabIndex = 33
        Me.lblFactSeleccion.Text = "Ok"
        '
        'lblFactPesado
        '
        Me.lblFactPesado.AutoSize = True
        Me.lblFactPesado.Location = New System.Drawing.Point(285, 64)
        Me.lblFactPesado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactPesado.Name = "lblFactPesado"
        Me.lblFactPesado.Size = New System.Drawing.Size(21, 13)
        Me.lblFactPesado.TabIndex = 34
        Me.lblFactPesado.Text = "Ok"
        '
        'lblFactEmpaque
        '
        Me.lblFactEmpaque.AutoSize = True
        Me.lblFactEmpaque.Location = New System.Drawing.Point(359, 64)
        Me.lblFactEmpaque.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactEmpaque.Name = "lblFactEmpaque"
        Me.lblFactEmpaque.Size = New System.Drawing.Size(21, 13)
        Me.lblFactEmpaque.TabIndex = 35
        Me.lblFactEmpaque.Text = "Ok"
        '
        'lblFactCultivo
        '
        Me.lblFactCultivo.AutoSize = True
        Me.lblFactCultivo.Location = New System.Drawing.Point(433, 64)
        Me.lblFactCultivo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactCultivo.Name = "lblFactCultivo"
        Me.lblFactCultivo.Size = New System.Drawing.Size(21, 13)
        Me.lblFactCultivo.TabIndex = 36
        Me.lblFactCultivo.Text = "Ok"
        '
        'lblFactVariedad
        '
        Me.lblFactVariedad.AutoSize = True
        Me.lblFactVariedad.Location = New System.Drawing.Point(567, 64)
        Me.lblFactVariedad.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactVariedad.Name = "lblFactVariedad"
        Me.lblFactVariedad.Size = New System.Drawing.Size(21, 13)
        Me.lblFactVariedad.TabIndex = 37
        Me.lblFactVariedad.Text = "Ok"
        '
        'lblFactFormato
        '
        Me.lblFactFormato.AutoSize = True
        Me.lblFactFormato.Location = New System.Drawing.Point(701, 64)
        Me.lblFactFormato.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFactFormato.Name = "lblFactFormato"
        Me.lblFactFormato.Size = New System.Drawing.Size(21, 13)
        Me.lblFactFormato.TabIndex = 38
        Me.lblFactFormato.Text = "Ok"
        '
        'frmPacking_Movimientos_FusionarCajasBifurcadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 414)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_FusionarCajasBifurcadas"
        Me.Text = "Packing / Movimientos / Fusionar Cajas Bifurcadas"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMatch.ResumeLayout(False)
        Me.tlpMatch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxSoloCajasBifurcadas As System.Windows.Forms.CheckBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents tlpMatch As ExTableLayoutPanel 'System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblLineaA As System.Windows.Forms.Label
    Friend WithEvents lblLineaB As System.Windows.Forms.Label
    Friend WithEvents lblIdPalletA As System.Windows.Forms.Label
    Friend WithEvents lblIdPalletB As System.Windows.Forms.Label
    Friend WithEvents lblNroCajaA As System.Windows.Forms.Label
    Friend WithEvents lblNroCajaB As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionA As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionB As System.Windows.Forms.Label
    Friend WithEvents lblPesadoA As System.Windows.Forms.Label
    Friend WithEvents lblPesadoB As System.Windows.Forms.Label
    Friend WithEvents lblEmpaqueA As System.Windows.Forms.Label
    Friend WithEvents lblEmpaqueB As System.Windows.Forms.Label
    Friend WithEvents lblCultivoA As System.Windows.Forms.Label
    Friend WithEvents lblCultivoB As System.Windows.Forms.Label
    Friend WithEvents lblVariedadA As System.Windows.Forms.Label
    Friend WithEvents lblVariedadB As System.Windows.Forms.Label
    Friend WithEvents lblFormatoA As System.Windows.Forms.Label
    Friend WithEvents lblFormatoB As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblFactLinea As System.Windows.Forms.Label
    Friend WithEvents lblFactIdPallet As System.Windows.Forms.Label
    Friend WithEvents lblFactNroCaja As System.Windows.Forms.Label
    Friend WithEvents lblFactSeleccion As System.Windows.Forms.Label
    Friend WithEvents lblFactPesado As System.Windows.Forms.Label
    Friend WithEvents lblFactEmpaque As System.Windows.Forms.Label
    Friend WithEvents lblFactCultivo As System.Windows.Forms.Label
    Friend WithEvents lblFactVariedad As System.Windows.Forms.Label
    Friend WithEvents lblFactFormato As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents btnFusionar As System.Windows.Forms.Button
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
End Class
