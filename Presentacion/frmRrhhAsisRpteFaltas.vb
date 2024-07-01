Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhhAsisRpteFaltas
    'Globales de parametros
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmRrhhAsisRpteFaltas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        radFuenteTablets.Checked = True
        radRpteConsecutivas.Checked = True
        radPersonasTodos.Checked = True
        aplicarTema(Me)
    End Sub

    'Private Sub radRpteTodasFaltas_CheckedChanged(sender As Object, e As EventArgs) Handles radRpteTodasFaltas.CheckedChanged
    '    If radRpteTodasFaltas.Checked = True Then
    '        floRpteConsecutivas.Enabled = False
    '        floRpteRango.Enabled = False
    '        radPersonasTodos.Enabled = False
    '        radPersonasPlanillas.Enabled = False
    '        radPersonasCodigo.Enabled = True
    '        txtPersonasCodigo.Enabled = True
    '        radPersonasCodigo.Checked = True
    '        floPersonasPlanillas.Enabled = False
    '    End If
    'End Sub

    'Private Sub radRpteConsecutivas_CheckedChanged(sender As Object, e As EventArgs) Handles radRpteConsecutivas.CheckedChanged
    '    If radRpteConsecutivas.Checked = True Then
    '        floRpteConsecutivas.Enabled = True
    '        floRpteRango.Enabled = False
    '        radPersonasCodigo.Enabled = False
    '        txtPersonasCodigo.Enabled = False
    '        txtRpteFaltasConsecutivas.Focus()
    '        radPersonasTodos.Enabled = True
    '        radPersonasTodos.Checked = True
    '        radPersonasPlanillas.Enabled = True
    '    End If
    'End Sub

    'Private Sub radRpteRango_CheckedChanged(sender As Object, e As EventArgs) Handles radRpteRango.CheckedChanged
    '    If radRpteRango.Checked = True Then
    '        floRpteRango.Enabled = True
    '        floRpteConsecutivas.Enabled = False
    '        radPersonasTodos.Enabled = False
    '        radPersonasPlanillas.Enabled = True
    '        floPersonasPlanillas.Enabled = False
    '        radPersonasCodigo.Enabled = True
    '        radPersonasCodigo.Checked = True
    '    End If
    'End Sub

    'Private Sub radPersonasTodos_CheckedChanged(sender As Object, e As EventArgs) Handles radPersonasTodos.CheckedChanged
    '    If radPersonasTodos.Checked = True Then
    '        txtPersonasCodigo.Enabled = False
    '        floPersonasPlanillas.Enabled = False
    '    End If
    'End Sub

    'Private Sub radPersonasPlanillas_CheckedChanged(sender As Object, e As EventArgs) Handles radPersonasPlanillas.CheckedChanged
    '    If radPersonasPlanillas.Checked = True Then
    '        txtPersonasCodigo.Enabled = False
    '        floPersonasPlanillas.Enabled = True
    '    End If
    'End Sub

    'Private Sub radPersonasCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles radPersonasCodigo.CheckedChanged
    '    If radPersonasCodigo.Checked = True Then
    '        txtPersonasCodigo.Enabled = True
    '        floPersonasPlanillas.Enabled = False
    '        txtPersonasCodigo.Focus()
    '    End If
    'End Sub

    'Private Sub txtRpteFaltasConsecutivas_Leave(sender As Object, e As EventArgs) Handles txtRpteFaltasConsecutivas.Leave
    '    If txtRpteFaltasConsecutivas.Text = "" Then
    '        txtRpteFaltasConsecutivas.Text = "3"
    '    End If
    'End Sub

    'Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
    '    dgvResultado.DataSource = Nothing
    '    dgvResultado.Columns.Clear()
    '    Dim dgv As Task(Of DataTable)
    '    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
    '    dgv = consultarAsync()
    '    dgvResultado.DataSource = Await dgv
    '    apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    '    corregirCeldas(dgvResultado)
    '    formatearDataGridView(dgvResultado)
    'End Sub

    'Private Async Function consultarAsync() As Task(Of DataTable)
    '    Try
    '        Dim p As New Dictionary(Of String, Object)
    '        'Dim dgvResultado2 As New DataTable
    '        Dim aux As New DataTable
    '        Dim rango As String = "", planillas As String = ""
    '        Dim fuente As String, tipoReporte As String, personas As String
    '        Dim incluyeJustificaciones As Boolean
    '        fuente = IIf(radFuenteNisira.Checked, "NISIRA", IIf(radFuenteTablets.Checked, "TABLETS", "ERROR"))
    '        If radRpteConsecutivas.Checked And Not IsNumeric(txtRpteFaltasConsecutivas.Text) Then
    '            MessageBox.Show("Error, debe registrar un numero de dias válido usando sólo numero")
    '            Return Nothing
    '            'Exit Function
    '        End If
    '        rango = String.Concat(pkrRpteDesde.Value.ToString("yyyy-MM-dd"), ",", pkrRpteHasta.Value.ToString("yyyy-MM-dd"))
    '        tipoReporte = IIf(radRpteTodasFaltas.Checked, "TODAS",
    '                          IIf(radRpteConsecutivas.Checked, txtRpteFaltasConsecutivas.Text,
    '                              IIf(radRpteRango.Checked, rango, "ERROR")))
    '        If radPersonasPlanillas.Checked Then
    '            If cbxPersonasEma.Checked Or cbxPersonasEmp.Checked Or cbxPersonasFma.Checked Or cbxPersonasObm.Checked Or cbxPersonasPas.Checked Or cbxPersonasPra.Checked Then
    '                planillas = If(cbxPersonasEma.Checked, "PLAEMA", "")
    '                planillas = planillas + If(cbxPersonasEmp.Checked, If(planillas.Length > 0, ",EMP", "PLAEMP"), "")
    '                planillas = planillas + If(cbxPersonasFma.Checked, If(planillas.Length > 0, ",FMA", "PLAFMA"), "")
    '                planillas = planillas + If(cbxPersonasObm.Checked, If(planillas.Length > 0, ",OBM", "PLAOBM"), "")
    '                planillas = planillas + If(cbxPersonasPas.Checked, If(planillas.Length > 0, ",PAS", "PLAPAS"), "")
    '                planillas = planillas + If(cbxPersonasPra.Checked, If(planillas.Length > 0, ",PRA", "PLAPRA"), "")
    '            Else
    '                MessageBox.Show("Debe seleccionar al menos una planilla")
    '                'Exit Function
    '                Return Nothing
    '            End If
    '        End If
    '        If radPersonasCodigo.Checked And (txtPersonasCodigo.Text.Length <> 5 And txtPersonasCodigo.Text.Length <> 8) Then
    '            MessageBox.Show("Error, debe escribir un codigo o dni validos")
    '            'Exit Function
    '            Return Nothing
    '        End If
    '        personas = IIf(radPersonasTodos.Checked, "TODOS", IIf(radPersonasCodigo.Checked, "COD" + txtPersonasCodigo.Text,
    '        incluyeJustificaciones = cbxExcluirJustificaciones.Checked))
    '        p.Add("@Fuente", fuente)
    '        p.Add("@TipoReporte", tipoReporte)
    '        p.Add("@Personas", personas)
    '        p.Add("@IncluirJustificaciones", incluyeJustificaciones)
    '        aux = Await Task.Run(Function() doItBaby("spRrhhRpteFaltas", p, TipoQuery.DataTable))
    '        Return aux
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    'Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
    '    'If dgvResultado.RowCount < 1 Then
    '    '     MessageBox.Show("Error, no hay registros para exportar")
    '    ' Else
    '    '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
    '    '     Dim dDgvs As New Dictionary(Of String, DataGridView)
    '    '     dDgvs.Add("Reporte", dgvResultado)
    '    '     excelling(dDgvs, Me.Text, arrayDeParametros)
    '    ' End If
    '    'Try
    '    '    If dgvResultado.RowCount < 1 Then
    '    '        MessageBox.Show("Error, no hay registros para exportar")
    '    '    Else
    '    '        encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
    '    '        Dim l As String
    '    '        l = "Reporte"
    '    '        Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
    '    '        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
    '    '    End If
    '    'Catch ex As Exception
    '    '    MessageBox.Show(ex.Message)
    '    'End Try
    'End Sub

    Private Function radFuenteTablets() As Object
        Throw New NotImplementedException
    End Function

End Class