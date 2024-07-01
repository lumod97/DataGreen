Imports System.Threading
Imports System.IO.Ports
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports System.Resources
Imports MSCommLib

Public Class frmPesaje
    Dim nombre_puerto As String
    'Private system.IO.Ports.serialPort BasculaCom = New System.IO.Ports.Serie
    'Puerto conectado a la balanza
    Private WithEvents miSerialPort As SerialPort

    Private Sub frmPesaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized

        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub captura_puerto2()
        Dim num_puerto As Integer
        Dim returnStr As String = ""
        On Error GoTo fallo
        num_puerto = 1
        nombre_puerto = "COM" & num_puerto
        Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(nombre_puerto)
            com1.DataBits = 8
            com1.ReadTimeout = 9600
            Dim Incoming As String = com1.ReadLine()
            returnStr = Incoming
            Thread.Sleep(100)
            Incoming = com1.ReadLine()
            com1.Close()
        End Using
        Exit Sub
fallo:
        MsgBox(Err.Description, vbCritical)

    End Sub

    Private Function fp_captura_peso() As Double
        Dim lnLen As Long
        Dim lnCRpos As Object
        Dim InBuffer As Object
        Dim InMiddle, InDistinct As Object
        Dim peso_final As Object = 0
        Dim n As Long
        On Error GoTo fallo
        Dim lcEntrada = " "
        fp_captura_peso = 0

        Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(nombre_puerto)
            Dim Incoming As String = com1.ReadLine()
            Thread.Sleep(100)
            Incoming = com1.ReadLine()
            lcEntrada = Incoming
        End Using

        If Len(Trim(lcEntrada)) > 10 Then
            Dim subStrings() As String
            Dim TestArray() As String = Split(lcEntrada, ",")

            For i As Integer = 0 To TestArray.Length - 1
                If TestArray(i) <> "" Then
                    If Char.IsNumber(Trim(TestArray(i))) = True Then
                        peso_final = TestArray(i)
                    End If
                End If
            Next

            If IsNumeric(peso_final) Then
                If peso_final >= 0 Then
                    fp_captura_peso = Format(CDbl(peso_final), "###,##0.0000")
                    Exit Function
                End If
            Else
                fp_captura_peso = 0
            End If
        Else
            MsgBox("No se ha detectado peso, intente nuevamente...", vbCritical)
        End If
        Exit Function
fallo:
        MsgBox(Err.Description)
    End Function

    Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
        miSerialPort = New SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
        miSerialPort.ReadTimeout = 3600
        miSerialPort.WriteTimeout = 3600
        miSerialPort.ReceivedBytesThreshold = 8
        'miSerialPort.ReceivedBytesThreshold = 9
        miSerialPort.Handshake = IO.Ports.Handshake.None
        miSerialPort.Encoding = System.Text.Encoding.Default
        miSerialPort.Open()
    End Sub
    Private Sub miSerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles miSerialPort.DataReceived
        Dim InString As String = miSerialPort.ReadExisting
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        'hago el invoke a mi hilo anterior
        Me.txtPesoBalanza.Text = miSerialPort.ReadExisting
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If DataGridView1.CurrentCell.ColumnIndex = 1 Then 'Columna que se captura el peso 

            DataGridView1.CurrentCell.Value = fp_captura_peso()

        End If

    End Sub
End Class