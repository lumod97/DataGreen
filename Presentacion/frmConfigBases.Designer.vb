<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigBases
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBSQLiteNombreBase = New System.Windows.Forms.TextBox()
        Me.txtBSQLiteRuta = New System.Windows.Forms.TextBox()
        Me.btnBSQLiteCrearBD = New System.Windows.Forms.Button()
        Me.btnBSQLiteResetearBD = New System.Windows.Forms.Button()
        Me.btnBSQLiteCrearTablas = New System.Windows.Forms.Button()
        Me.btnBSQLiteDescargarData = New System.Windows.Forms.Button()
        Me.btnBSQLiteProbarConexion = New System.Windows.Forms.Button()
        Me.cboTablasSqlite = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnBEProbarConexion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBENombreBase = New System.Windows.Forms.TextBox()
        Me.txtBEPassword = New System.Windows.Forms.TextBox()
        Me.txtBEUsuario = New System.Windows.Forms.TextBox()
        Me.txtBEServidor = New System.Windows.Forms.TextBox()
        Me.txtBENombreConexion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnBLProbarConexion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBLNombreBase = New System.Windows.Forms.TextBox()
        Me.txtBLPassword = New System.Windows.Forms.TextBox()
        Me.txtBLUsuario = New System.Windows.Forms.TextBox()
        Me.txtBLServidor = New System.Windows.Forms.TextBox()
        Me.txtBLNombreConexion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 7
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.GroupBox3, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.GroupBox2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.GroupBox1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnCancelar, 3, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardar, 5, 5)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 3)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(912, 431)
        Me.tlpPrincipal.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSize = True
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(615, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(277, 317)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Base SQLite"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.txtBSQLiteNombreBase, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.txtBSQLiteRuta, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnBSQLiteCrearBD, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.btnBSQLiteResetearBD, 0, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.btnBSQLiteCrearTablas, 0, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.btnBSQLiteDescargarData, 0, 9)
        Me.TableLayoutPanel4.Controls.Add(Me.btnBSQLiteProbarConexion, 0, 11)
        Me.TableLayoutPanel4.Controls.Add(Me.cboTablasSqlite, 0, 8)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 12
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(271, 298)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ruta:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Nombre de Base:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBSQLiteNombreBase
        '
        Me.txtBSQLiteNombreBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBSQLiteNombreBase.Location = New System.Drawing.Point(95, 60)
        Me.txtBSQLiteNombreBase.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBSQLiteNombreBase.Name = "txtBSQLiteNombreBase"
        Me.txtBSQLiteNombreBase.Size = New System.Drawing.Size(176, 20)
        Me.txtBSQLiteNombreBase.TabIndex = 8
        '
        'txtBSQLiteRuta
        '
        Me.txtBSQLiteRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBSQLiteRuta.Location = New System.Drawing.Point(95, 20)
        Me.txtBSQLiteRuta.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBSQLiteRuta.Name = "txtBSQLiteRuta"
        Me.txtBSQLiteRuta.Size = New System.Drawing.Size(176, 20)
        Me.txtBSQLiteRuta.TabIndex = 7
        '
        'btnBSQLiteCrearBD
        '
        Me.btnBSQLiteCrearBD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.btnBSQLiteCrearBD, 2)
        Me.btnBSQLiteCrearBD.Location = New System.Drawing.Point(85, 103)
        Me.btnBSQLiteCrearBD.Name = "btnBSQLiteCrearBD"
        Me.btnBSQLiteCrearBD.Size = New System.Drawing.Size(100, 25)
        Me.btnBSQLiteCrearBD.TabIndex = 9
        Me.btnBSQLiteCrearBD.Text = "Crear BD"
        Me.btnBSQLiteCrearBD.UseVisualStyleBackColor = True
        '
        'btnBSQLiteResetearBD
        '
        Me.btnBSQLiteResetearBD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.btnBSQLiteResetearBD, 2)
        Me.btnBSQLiteResetearBD.Location = New System.Drawing.Point(85, 134)
        Me.btnBSQLiteResetearBD.Name = "btnBSQLiteResetearBD"
        Me.btnBSQLiteResetearBD.Size = New System.Drawing.Size(100, 25)
        Me.btnBSQLiteResetearBD.TabIndex = 10
        Me.btnBSQLiteResetearBD.Text = "Resetear BD"
        Me.btnBSQLiteResetearBD.UseVisualStyleBackColor = True
        '
        'btnBSQLiteCrearTablas
        '
        Me.btnBSQLiteCrearTablas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.btnBSQLiteCrearTablas, 2)
        Me.btnBSQLiteCrearTablas.Location = New System.Drawing.Point(85, 165)
        Me.btnBSQLiteCrearTablas.Name = "btnBSQLiteCrearTablas"
        Me.btnBSQLiteCrearTablas.Size = New System.Drawing.Size(100, 25)
        Me.btnBSQLiteCrearTablas.TabIndex = 11
        Me.btnBSQLiteCrearTablas.Text = "Crear Tablas"
        Me.btnBSQLiteCrearTablas.UseVisualStyleBackColor = True
        '
        'btnBSQLiteDescargarData
        '
        Me.btnBSQLiteDescargarData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.btnBSQLiteDescargarData, 2)
        Me.btnBSQLiteDescargarData.Location = New System.Drawing.Point(85, 223)
        Me.btnBSQLiteDescargarData.Name = "btnBSQLiteDescargarData"
        Me.btnBSQLiteDescargarData.Size = New System.Drawing.Size(100, 25)
        Me.btnBSQLiteDescargarData.TabIndex = 12
        Me.btnBSQLiteDescargarData.Text = "Descargar Data"
        Me.btnBSQLiteDescargarData.UseVisualStyleBackColor = True
        '
        'btnBSQLiteProbarConexion
        '
        Me.btnBSQLiteProbarConexion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnBSQLiteProbarConexion.AutoSize = True
        Me.btnBSQLiteProbarConexion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.SetColumnSpan(Me.btnBSQLiteProbarConexion, 2)
        Me.btnBSQLiteProbarConexion.Location = New System.Drawing.Point(88, 275)
        Me.btnBSQLiteProbarConexion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBSQLiteProbarConexion.Name = "btnBSQLiteProbarConexion"
        Me.btnBSQLiteProbarConexion.Size = New System.Drawing.Size(95, 23)
        Me.btnBSQLiteProbarConexion.TabIndex = 13
        Me.btnBSQLiteProbarConexion.Text = "Probar Conexion"
        Me.btnBSQLiteProbarConexion.UseVisualStyleBackColor = True
        '
        'cboTablasSqlite
        '
        Me.cboTablasSqlite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.SetColumnSpan(Me.cboTablasSqlite, 2)
        Me.cboTablasSqlite.FormattingEnabled = True
        Me.cboTablasSqlite.Location = New System.Drawing.Point(45, 196)
        Me.cboTablasSqlite.Name = "cboTablasSqlite"
        Me.cboTablasSqlite.Size = New System.Drawing.Size(180, 21)
        Me.cboTablasSqlite.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(316, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 317)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Base ERP"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnBEProbarConexion, 0, 11)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBENombreBase, 1, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBEPassword, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBEUsuario, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBEServidor, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBENombreConexion, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 5)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 12
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(272, 298)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'btnBEProbarConexion
        '
        Me.btnBEProbarConexion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnBEProbarConexion.AutoSize = True
        Me.btnBEProbarConexion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.SetColumnSpan(Me.btnBEProbarConexion, 2)
        Me.btnBEProbarConexion.Location = New System.Drawing.Point(88, 275)
        Me.btnBEProbarConexion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBEProbarConexion.Name = "btnBEProbarConexion"
        Me.btnBEProbarConexion.Size = New System.Drawing.Size(95, 23)
        Me.btnBEProbarConexion.TabIndex = 17
        Me.btnBEProbarConexion.Text = "Probar Conexion"
        Me.btnBEProbarConexion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre de Conexion:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Servidor:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBENombreBase
        '
        Me.txtBENombreBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBENombreBase.Location = New System.Drawing.Point(115, 180)
        Me.txtBENombreBase.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBENombreBase.Name = "txtBENombreBase"
        Me.txtBENombreBase.Size = New System.Drawing.Size(157, 20)
        Me.txtBENombreBase.TabIndex = 16
        Me.txtBENombreBase.Text = "AgricolaSanJuan_2020"
        '
        'txtBEPassword
        '
        Me.txtBEPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBEPassword.Location = New System.Drawing.Point(115, 140)
        Me.txtBEPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBEPassword.Name = "txtBEPassword"
        Me.txtBEPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtBEPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtBEPassword.TabIndex = 15
        Me.txtBEPassword.Text = "A20200211sj"
        '
        'txtBEUsuario
        '
        Me.txtBEUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBEUsuario.Location = New System.Drawing.Point(115, 100)
        Me.txtBEUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBEUsuario.Name = "txtBEUsuario"
        Me.txtBEUsuario.Size = New System.Drawing.Size(157, 20)
        Me.txtBEUsuario.TabIndex = 14
        Me.txtBEUsuario.Text = "sa"
        '
        'txtBEServidor
        '
        Me.txtBEServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBEServidor.Location = New System.Drawing.Point(115, 60)
        Me.txtBEServidor.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBEServidor.Name = "txtBEServidor"
        Me.txtBEServidor.Size = New System.Drawing.Size(157, 20)
        Me.txtBEServidor.TabIndex = 13
        'Me.txtBEServidor.Text = "192.168.30.99\MSSQLSERVER17"
        '<!--MODIFICACION HATCH 2024-06-03-->
        Me.txtBEServidor.Text = "TINAJONES"
        '
        'txtBENombreConexion
        '
        Me.txtBENombreConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBENombreConexion.Location = New System.Drawing.Point(115, 20)
        Me.txtBENombreConexion.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBENombreConexion.Name = "txtBENombreConexion"
        Me.txtBENombreConexion.Size = New System.Drawing.Size(157, 20)
        Me.txtBENombreConexion.TabIndex = 12
        Me.txtBENombreConexion.Text = "Nisira"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Nombre de Base:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(56, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Password:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(66, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Usuario:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 317)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base Local"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnBLProbarConexion, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBLNombreBase, 1, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBLPassword, 1, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBLUsuario, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBLServidor, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtBLNombreConexion, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 12
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(271, 298)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnBLProbarConexion
        '
        Me.btnBLProbarConexion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnBLProbarConexion.AutoSize = True
        Me.btnBLProbarConexion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnBLProbarConexion, 2)
        Me.btnBLProbarConexion.Location = New System.Drawing.Point(88, 275)
        Me.btnBLProbarConexion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnBLProbarConexion.Name = "btnBLProbarConexion"
        Me.btnBLProbarConexion.Size = New System.Drawing.Size(95, 23)
        Me.btnBLProbarConexion.TabIndex = 14
        Me.btnBLProbarConexion.Text = "Probar Conexion"
        Me.btnBLProbarConexion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre de Conexion:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Servidor:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBLNombreBase
        '
        Me.txtBLNombreBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBLNombreBase.Location = New System.Drawing.Point(115, 180)
        Me.txtBLNombreBase.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBLNombreBase.Name = "txtBLNombreBase"
        Me.txtBLNombreBase.Size = New System.Drawing.Size(156, 20)
        Me.txtBLNombreBase.TabIndex = 11
        Me.txtBLNombreBase.Text = "DataGreen"
        '
        'txtBLPassword
        '
        Me.txtBLPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBLPassword.Location = New System.Drawing.Point(115, 140)
        Me.txtBLPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBLPassword.Name = "txtBLPassword"
        Me.txtBLPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.txtBLPassword.Size = New System.Drawing.Size(156, 20)
        Me.txtBLPassword.TabIndex = 10
        Me.txtBLPassword.Text = "A20200211sj"
        '
        'txtBLUsuario
        '
        Me.txtBLUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBLUsuario.Location = New System.Drawing.Point(115, 100)
        Me.txtBLUsuario.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBLUsuario.Name = "txtBLUsuario"
        Me.txtBLUsuario.Size = New System.Drawing.Size(156, 20)
        Me.txtBLUsuario.TabIndex = 9
        Me.txtBLUsuario.Text = "sa"
        '
        'txtBLServidor
        '
        Me.txtBLServidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBLServidor.Location = New System.Drawing.Point(115, 60)
        Me.txtBLServidor.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBLServidor.Name = "txtBLServidor"
        Me.txtBLServidor.Size = New System.Drawing.Size(156, 20)
        Me.txtBLServidor.TabIndex = 8
        '<!--MODIFICACION HATCH 2024-06-03-->
        'Me.txtBLServidor.Text = "192.168.30.99\MSSQLSERVER17"
        Me.txtBLServidor.Text = "TINAJONES"
        '
        'txtBLNombreConexion
        '
        Me.txtBLNombreConexion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBLNombreConexion.Location = New System.Drawing.Point(115, 20)
        Me.txtBLNombreConexion.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBLNombreConexion.Name = "txtBLNombreConexion"
        Me.txtBLNombreConexion.Size = New System.Drawing.Size(156, 20)
        Me.txtBLNombreConexion.TabIndex = 7
        Me.txtBLNombreConexion.Text = "Local"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nombre de Base:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Password:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(66, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Usuario:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCancelar.Location = New System.Drawing.Point(405, 393)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(703, 393)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(100, 23)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 5)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 341)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(874, 9)
        Me.barProgreso.TabIndex = 22
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResultado, 5)
        Me.lblResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblResultado.Location = New System.Drawing.Point(18, 356)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(874, 14)
        Me.lblResultado.TabIndex = 23
        Me.lblResultado.Text = "Progreso..."
        '
        'frmConfigBases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 431)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmConfigBases"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuracion Bases"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBLNombreConexion As System.Windows.Forms.TextBox
    Friend WithEvents txtBLServidor As System.Windows.Forms.TextBox
    Friend WithEvents txtBLUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtBLPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtBLNombreBase As System.Windows.Forms.TextBox
    Friend WithEvents txtBENombreConexion As System.Windows.Forms.TextBox
    Friend WithEvents txtBEServidor As System.Windows.Forms.TextBox
    Friend WithEvents txtBEUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtBEPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtBENombreBase As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBSQLiteNombreBase As System.Windows.Forms.TextBox
    Friend WithEvents txtBSQLiteRuta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBSQLiteCrearBD As System.Windows.Forms.Button
    Friend WithEvents btnBSQLiteResetearBD As System.Windows.Forms.Button
    Friend WithEvents btnBSQLiteCrearTablas As System.Windows.Forms.Button
    Friend WithEvents btnBSQLiteDescargarData As System.Windows.Forms.Button
    Friend WithEvents btnBSQLiteProbarConexion As System.Windows.Forms.Button
    Friend WithEvents btnBEProbarConexion As System.Windows.Forms.Button
    Friend WithEvents btnBLProbarConexion As System.Windows.Forms.Button
    Public WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Public WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents cboTablasSqlite As System.Windows.Forms.ComboBox
End Class
