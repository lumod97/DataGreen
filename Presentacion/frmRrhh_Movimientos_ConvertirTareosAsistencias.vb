Imports Datos.Conexion
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Logica.Funciones


Public Class frmRrhh_Movimientos_ConvertirTareosAsistencias
    Dim dsParaCombos As DataSet = New DataSet
    Dim dtResultado As DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim sumaCabecera As Double = 0.000
    Dim sumaDetalles As Double = 0.000


    Private Sub frmRrhh_Movimientos_ConvertirTareosAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsParaCombos.Tables(0), 0, 2)
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataTable
        aux = doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
    End Sub

    Public Function ConvertirDataTableAXml(ByVal dt As DataTable) As String
        Using sw As New System.IO.StringWriter()
            dt.WriteXml(sw, XmlWriteMode.IgnoreSchema)
            Return sw.ToString()
        End Using
    End Function

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@FechaProcesamiento", dtpFechaProcesar.Value)
            p.Add("@PlanillaProcesamiento", cboPlanilla.SelectedValue)
            p.Add("@IdUsuario", "NTINOCO")
            'p.Add("@IdUsuario", usuarioActual)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_ProcesarAsistenciasANISIRA", p, TipoQuery.DataSet))
            dtResultado = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Async Function insertarAsistenciasAsync() As Task
        Dim results As DataTable
        Dim results1 As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@XmlDataCabecera", ConvertirDataTableAXml(dgvResultadoCabecera.DataSource))
        p.Add("@XmlDataDetalles", ConvertirDataTableAXml(dgvResultadoDetalles.DataSource))
        p.Add("@usuario", usuarioActual)
        results = Await Task.Run(Function() doItBaby("sp_insertarAsistenciasEnNISIRA", p, TipoQuery.DataTable))
        results1 = results
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        rtbAvisos.Clear()
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim comparativoCabecera = Math.Round(sumaCabecera, 3)
        Dim comparativoDetalles = Math.Round(sumaDetalles, 3)
        If comparativoCabecera <> comparativoDetalles Then
            MessageBox.Show("Las horas de la cabecera y los detalles no concuerdan, verificar.")
        ElseIf dgvResultadoCabecera.RowCount > 0 Then
            encenderControlesDeEspera(pbStatus, lblStatus, "Insertando información a NISIRA...")
            rtbAvisos.AppendText(vbCrLf & "Se ha insertado la información a NISIRA, verificar." & vbCrLf)
            Await insertarAsistenciasAsync()
            rtbAvisos.AppendText(vbCrLf & "Identificadores insertados: " & vbCrLf)
            For index As Integer = 0 To dgvResultadoCabecera.RowCount() - 1
                rtbAvisos.AppendText(vbCrLf & dgvResultadoCabecera.Item(1, index).Value.ToString())
            Next
            apagarControlesDeEspera(pbStatus, lblStatus, -1)
        Else
            MessageBox.Show("No existen datos para procesar")
        End If
    End Sub

    Private Async Function Button1_ClickAsync(sender As Object, e As EventArgs) As Task Handles Button1.Click
        If cboPlanilla.Text.Equals("") Then
            MessageBox.Show("Seleccione una planilla antes de continuar")
        ElseIf cboPlanilla.Text.Equals("") Then
            MessageBox.Show("Seleccione una planilla antes de continuar")
        Else
            encenderControlesDeEspera(pbStatus, lblStatus)
            Dim results As DataSet = Await consultarAsync()

            If results.Tables.Count = 1 Then
                MessageBox.Show(results.Tables(0).Rows(0).Item("mensaje").ToString)
            Else
                Dim dtCabeceras As DataTable = results.Tables(0)
                Dim dtDetalles As DataTable = results.Tables(1)
                corregirTabla(dtCabeceras)
                corregirTabla(dtDetalles)
                dgvResultadoCabecera.DataSource = dtCabeceras
                dgvResultadoDetalles.DataSource = dtDetalles
                apagarControlesDeEspera(pbStatus, lblStatus, dgvResultadoCabecera.RowCount)
                Clipboard.SetText(ConvertirDataTableAXml(dtDetalles))
                corregirCeldas(dgvResultadoCabecera)
                formatearDataGridView(dgvResultadoCabecera)

                For i As Integer = 0 To dtCabeceras.Rows.Count - 1
                    sumaCabecera = dtCabeceras.Rows.Item(i).Item("THORAS") + sumaCabecera
                Next

                For i As Integer = 0 To dtDetalles.Rows.Count - 1
                    If dtDetalles.Rows.Item(i).Item("horas_en_rendimiento") > 0.000 Then
                        sumaDetalles = dtDetalles.Rows.Item(i).Item("horas_en_rendimiento") + sumaDetalles
                    Else
                        sumaDetalles = dtDetalles.Rows.Item(i).Item("TOTAL_HORAS") + sumaDetalles
                    End If
                Next

                lblCantidadHorasCabecera.Text = "Cantidad de Horas: " & sumaCabecera
                lblCantidadHorasDetalles.Text = "Cantidad de Horas: " & sumaDetalles

                rtbAvisos.AppendText(vbCrLf & "Se ha procesado la información de la planilla " & cboPlanilla.SelectedValue.ToString() &
                         " para la fecha " & dtpFechaProcesar.Value.ToString("dd-MM-yyyy") & vbCrLf)
            End If
            apagarControlesDeEspera(pbStatus, lblStatus, dgvResultadoCabecera.RowCount)
        End If
    End Function

    Private Async Function Button2_ClickAsync(sender As Object, e As EventArgs) As Task Handles Button2.Click
        Try
            If dgvResultadoCabecera.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar.")
            Else
                encenderControlesDeEspera(pbStatus, lblStatus, "Exportando...")
                Dim l As New List(Of String) ' Inicializa la lista con New
                l.Add("Cabecera")
                l.Add("Detalles")
                Await Task.Run(Sub() aExcel(dtResultado, l, Me.Text, arrayDeParametros))

                apagarControlesDeEspera(pbStatus, lblStatus, -1)

                rtbAvisos.AppendText(vbCrLf & "Se ha exportado información a un archivo de excel" & vbCrLf)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

End Class