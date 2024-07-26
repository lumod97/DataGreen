Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports RawPrint
Imports System.Net
Imports System.Text
Imports Lextm.SharpSnmpLib.Objects
Imports System.Drawing.Imaging
'Se creo la clase para la impresion directa de Fotochecks desde DataGreen -> Agregado el 03/07/2024 Kevin Salazar - Luiggi Moretti
Public Class FotoCheckPrinter

    Private printerIP As String = ""
    Private alreadyPrintedSuccessMessage As Boolean = False ' Variable para controlar el mensaje de éxito
    Private printedCodes As HashSet(Of String) = New HashSet(Of String)() ' HashSet para almacenar códigos impresos
    Public Sub New() 'Funcion inicial que realiza la configuración de la impresora a utilizar -> 16/07/2024 Luiggi  Kevin Salazar
        Me.printerIP = GetPrinterName()
    End Sub
    Public Sub PrintFotoCheck(PathFotoCheck As String, tipoImpresion As String)

        Try
            ' Carpeta donde se guardaron las imágenes
            Dim carpeta As New DirectoryInfo(PathFotoCheck)
            Dim p As New PrintDocument()
            'Dim printDialog As New PrintDialog()
            Dim files As FileInfo() = carpeta.GetFiles("*.jpg") ' Filtrar archivos JPG (puedes ajustar según el tipo de archivo)


            If files.Length > 0 Then

                Dim arrayTest As List(Of String) = New List(Of String)

                If tipoImpresion = 0 Then
                    arrayTest.Add("00000000") 'Solucion temporal, se debe revisar para que no repita la impresion por cada archivo
                ElseIf tipoImpresion = 1 Then

                    For Each file As FileInfo In files
                        Dim codigo As String = file.Name.Replace("fotocheck_", "").Replace("_Front.jpg", "").Replace("_Back.jpg", "") 'Variable que extrae solo el codigo de la persona

                        If Not arrayTest.Contains(codigo) Then
                            arrayTest.Add(codigo) 'Lista que contendrá el codigo por persona una sola vez
                        End If

                    Next
                End If
                'MessageBox.Show(arrayTest.Count)
                For Each code As String In arrayTest
                    If Not printedCodes.Contains(code) Then

                        Dim frontSide As String = carpeta.FullName + "\fotocheck_" + code + "_Front.jpg" 'Variable que contendrá la imagen frontal del fotocheck cuando termine en _Front
                        Dim backSide As String = carpeta.FullName + "\fotocheck_" + code + "_Back.jpg" 'Variable que contendrá la imagen posterior del fotocheck cuando termine en _Backt

                        Select Case tipoImpresion
                            Case 0 ' Impresión de FotoCheck Solo

                                'MessageBox.Show(code)
                                If Not alreadyPrintedSuccessMessage Then
                                    alreadyPrintedSuccessMessage = True ' Marcar que se mostró el mensaje
                                End If

                                For Each imagen As FileInfo In files
                                    'MessageBox.Show(imagen.FullName)
                                    ImprimirFotoCheck(imagen.FullName, p) ' Imprimir cada foto
                                Next
                            Case 1 ' Impresión de FotoCheck de ambos lados
                                If Not alreadyPrintedSuccessMessage Then
                                    alreadyPrintedSuccessMessage = True ' Marcar que se mostró el mensaje
                                End If
                                ImprimirAmbosLados(frontSide, backSide, p)
                            Case Else
                                Throw New ArgumentException("Tipo de impresión no válido.")
                        End Select
                        printedCodes.Add(code) ' Agregar el código al HashSet después de imprimir
                    End If
                Next
                If alreadyPrintedSuccessMessage Then 'Condicion que solo imprimira una vez el mensaje independientemente de la cantidad de imagenes en el bucle
                    MessageBox.Show("Impresión de FotoCheck enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No se encontraron archivos de imágenes en la carpeta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al imprimir FotoCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ImprimirFotoCheck(FotoChechkFilePath As String, p As PrintDocument)
        Try

            p.PrinterSettings.PrinterName = printerIP
            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                        PrintImage(sender, e, FotoChechkFilePath)
                                    End Sub
            p.Print()

        Catch ex As Exception
            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintImage(ByVal sender As Object, ByVal ppea As PrintPageEventArgs, ByVal filePath As String)
        Try
            Using image As Image = Image.FromFile(filePath)
                ppea.Graphics.DrawImage(image, ppea.Graphics.VisibleClipBounds)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al imprimir la imagen {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ImprimirAmbosLados(frontSideFile As String, backSideFile As String, p As PrintDocument)
        Try
            p.PrinterSettings.Duplex = Duplex.Vertical
            p.PrinterSettings.PrinterName = printerIP
            Dim printedFront As Boolean = False ' Variable para controlar si ya se imprimió el lado frontal

            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                        If Not printedFront Then
                                            PrintImage(sender, e, frontSideFile)
                                            printedFront = True ' Marcar que se imprimió el lado frontal
                                            e.HasMorePages = True ' Indicar que hay más páginas por imprimir
                                        Else
                                            PrintImage(sender, e, backSideFile)
                                            e.HasMorePages = False ' Indicar que no hay más páginas por imprimir
                                        End If
                                    End Sub
            p.Print()
        Catch ex As Exception
            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetPrinterName() As String 'función que permite configurar la impresora -> 16/07/2024 Luiggi Moretti - Kevin Salazar

        Dim nombreImpresora As String = ""
        Dim impresoras As PrinterSettings.StringCollection = PrinterSettings.InstalledPrinters
        Dim textoExtraido As String = "ZC300" 'ZC300 / IMP_CONTABILIDAD /Variable que se usa para comparar las coincidencias con todas las impresoras instaladas

        For Each impresora As String In impresoras

            If impresora.Contains(textoExtraido) Then 'Condicion para comparar el nombre de todas las impresoras y la del textoExtradido (impresora que se desea utilizar)
                nombreImpresora = impresora 'Cuando la variable coincide se guarda el nombre de la impresora
            End If

        Next
        Return nombreImpresora
    End Function
End Class
