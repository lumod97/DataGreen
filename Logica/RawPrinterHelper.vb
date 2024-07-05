Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports RawPrint


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

End Class