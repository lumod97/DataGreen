Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Reportes_InformeDirectorio
    Dim dsParaCombos As DataSet = New DataSet
    'Dim dtResultado As DataTable
    Dim arrayDeParametros As String
    Dim dsResultado As DataSet
    Private Sub frmRrhh_Reportes_InformeDirectorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsParaCombos.Tables(0), 0, 2)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsParaCombos = New DataSet
        dsParaCombos.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub tlpPrincipal_Paint(sender As Object, e As PaintEventArgs) Handles tlpPrincipal.Paint

    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvCuadro1.DataSource = Nothing
        dgvCuadro2.DataSource = Nothing
        dgvCuadro3.DataSource = Nothing
        dgvCuadro4.DataSource = Nothing
        dgvCuadro5.DataSource = Nothing
        dgvCuadro6.DataSource = Nothing
        'dgvCuadro7.DataSource = Nothing
        'dgvCuadro8.DataSource = Nothing

        dsResultado = Nothing

        dgvCuadro1.Columns.Clear()
        dgvCuadro2.Columns.Clear()
        dgvCuadro3.Columns.Clear()
        dgvCuadro4.Columns.Clear()
        dgvCuadro5.Columns.Clear()
        dgvCuadro6.Columns.Clear()
        'dgvCuadro7.Columns.Clear()
        'dgvCuadro8.Columns.Clear()

        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dsResultado = Await dgv
        corregirTabla(dsResultado.Tables(0))
        corregirTabla(dsResultado.Tables(1))
        corregirTabla(dsResultado.Tables(2))
        corregirTabla(dsResultado.Tables(3))
        corregirTabla(dsResultado.Tables(4))
        corregirTabla(dsResultado.Tables(5))
        'corregirTabla(dsResultado.Tables(6))
        'corregirTabla(dsResultado.Tables(7))

        dgvCuadro1.DataSource = dsResultado.Tables(0)
        dgvCuadro2.DataSource = dsResultado.Tables(1)
        dgvCuadro3.DataSource = dsResultado.Tables(2)
        dgvCuadro4.DataSource = dsResultado.Tables(3)
        dgvCuadro5.DataSource = dsResultado.Tables(4)
        dgvCuadro6.DataSource = dsResultado.Tables(5)
        'dgvCuadro7.DataSource = dsResultado.Tables(6)
        'dgvCuadro8.DataSource = dsResultado.Tables(7)

        apagarControlesDeEspera(barProgreso, lblResultado, dgvCuadro6.RowCount)
        corregirCeldas(dgvCuadro1)
        corregirCeldas(dgvCuadro2)
        corregirCeldas(dgvCuadro3)
        corregirCeldas(dgvCuadro4)
        corregirCeldas(dgvCuadro5)
        corregirCeldas(dgvCuadro6)
        'corregirCeldas(dgvCuadro7)
        'corregirCeldas(dgvCuadro8)


        formatearDataGridView(dgvCuadro1)
        formatearDataGridView(dgvCuadro2)
        formatearDataGridView(dgvCuadro3)
        formatearDataGridView(dgvCuadro4)
        formatearDataGridView(dgvCuadro5)
        formatearDataGridView(dgvCuadro6)
        'formatearDataGridView(dgvCuadro7)
        'formatearDataGridView(dgvCuadro8)

    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@INDICE", 1)
            p.Add("@CODPLANILLA", cboPlanilla.SelectedValue)
            p.Add("@PERIODO_A", txtPeriodoIni.Text)
            p.Add("@SEMANA_A", TxtSemanaIni.Text)
            p.Add("@PERIODO_Z", TxtPeriodoFin.Text)
            p.Add("@SEMANA_Z", txtSemanaFin.Text)

            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_InformeDirectorio", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvCuadro6.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Cuadro1")
                l.Add("Cuadro2")
                l.Add("Cuadro3")
                l.Add("Cuadro4")
                l.Add("Cuadro5")
                l.Add("Cuadro6")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class