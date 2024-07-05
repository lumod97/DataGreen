Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports RawPrint
Imports Zebra.Sdk.Card.Printer
Imports Zebra.Sdk.Card.Containers.Job
Imports Zebra.Sdk.Card.Containers.Template.Graphics
Imports Zebra.Sdk.Card.Graphics
Imports Zebra.Sdk.Card.JobOptions
Imports Zebra.Sdk.Card.Graphics.Converters
Imports Zebra.Sdk.Comm
Imports Zebra.Sdk.Printer.Discovery
Imports Zebra.Sdk.Printer
Imports Zebra.Sdk.Card.Enumerations
Imports System.Text


'Public Class pdfprinter

'    Private printerip As String = "56.20.1.243"
'    Private printername As String = "Zebra ZC300 Network Card Printer" 'zebra zc300 network card printer /imp_contabilidad

'    Public Sub printpdf(pdfpath As String)
'        Try
'            ' verifica si el archivo existe
'            If Not File.Exists(pdfpath) Then
'                Throw New FileNotFoundException("el archivo pdf no se encontró.")
'            End If

'            ' configura la impresora
'            Dim rawprinter As New Printer()
'            rawprinter.PrintRawFile(printername, pdfpath, True) 'el valor true significa que la impresion esta en pausa, false significa que va a imprimir

'            MessageBox.Show("impresión realizada con éxito", "impresión pdf", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        Catch ex As Exception
'            MessageBox.Show("error al imprimir el pdf: " & ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Public Async Function DescargarArchivo(url As String, rutaDestino As String) As Task
'        Try
'            Using client As New WebClient()
'                Await client.DownloadFileTaskAsync(New Uri(url), rutaDestino)
'            End Using
'        Catch ex As Exception
'            Throw New Exception("Error al descargar el archivo: " & ex.Message)
'        End Try
'    End Function


'End Class
Public Class PDFPrinter

    Private printerName As String = "Zebra ZC300 Network Card Printer"

    Public Sub PrintPDF(pdfPath As String)
        Try
            ' Verifica si el archivo existe
            'If Not File.Exists(pdfPath) Then
            '    Throw New FileNotFoundException("El archivo PDF no se encontró.")
            'End If

            ' Configura la impresora
            Dim rawPrinter As New Printer()
            rawPrinter.PrintRawFile(printerName, pdfPath, True)

            MessageBox.Show("Impresión realizada con éxito", "Impresión PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al imprimir el PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Async Function DescargarArchivo(url As String, rutaDestino As String) As Task
        Try
            Using client As New WebClient()
                Await client.DownloadFileTaskAsync(New Uri(url), rutaDestino)
            End Using
        Catch ex As Exception
            Throw New Exception("Error al descargar el archivo: " & ex.Message)
        End Try
    End Function


    'Private printerIpAddress As String = "56.20.1.243" ' Dirección IP de la impresora Zebra ZC300

    'Public Sub PrintPDF(zplCommands As String)
    '    Try
    '        ' Configura la conexión con la impresora
    '        Dim printerUri As New Uri($"http://{printerIpAddress}/")
    '        Dim request As WebRequest = WebRequest.Create(printerUri)
    '        request.Method = "POST"
    '        request.ContentType = "application/x-www-form-urlencoded"

    '        ' Codifica los comandos ZPL en UTF-8
    '        Dim zplData As Byte() = Encoding.UTF8.GetBytes(zplCommands)

    '        ' Configura la longitud de los datos a enviar
    '        request.ContentLength = zplData.Length

    '        ' Escribe los datos ZPL en el cuerpo de la solicitud
    '        Using requestStream As Stream = request.GetRequestStream()
    '            requestStream.Write(zplData, 0, zplData.Length)
    '        End Using

    '        ' Envía la solicitud a la impresora
    '        Using response As WebResponse = request.GetResponse()
    '            ' Si necesitas leer la respuesta de la impresora, puedes hacerlo así:
    '            ' Dim responseStream As Stream = response.GetResponseStream()
    '            ' ...
    '        End Using

    '        MessageBox.Show("Impresión ZPL enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show($"Error al imprimir con ZPL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


End Class


