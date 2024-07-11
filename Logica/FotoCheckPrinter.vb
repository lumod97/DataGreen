Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports RawPrint
Imports System.Net
Imports System.Text
Imports Neodynamic.SDK.ZPLPrinter
Imports Lextm.SharpSnmpLib.Objects
Imports System.Drawing.Imaging
'Se creo la clase para la impresion directa de Fotochecks desde DataGreen -> Agregado el 03/07/2024 Kevin Salazar - Luiggi Moretti
Public Class FotoCheckPrinter
    Public Sub PrintFotoCheck(PathFotoCheck As String, tipoImpresion As String)

        Try
            ' Configurar la impresora seleccionada (opcional, dependiendo de cómo se seleccione la impresora)
            Dim p As New PrintDocument()
            Dim printDialog As New PrintDialog()

            If printDialog.ShowDialog() = DialogResult.OK Then
                p.PrinterSettings = printDialog.PrinterSettings
            Else
                Exit Sub ' Salir si el usuario cancela la selección de impresora
            End If
            ' Carpeta donde se guardaron las imágenes
            Dim carpeta As New DirectoryInfo(PathFotoCheck)
            Dim files As FileInfo() = carpeta.GetFiles("*.jpg") ' Filtrar archivos JPG (puedes ajustar según el tipo de archivo)

            If files.Length > 0 Then
                For Each file As FileInfo In files
                    Select Case tipoImpresion 'verificar porque no recibe el valor del cboTipoFotocheck
                        Case 0 '0 para Impresion de FotoCheck Solo -> Agregado el 06/07/2024 Kevin Salazar FUNCIONA OK
                            Try
                                'AddHandler p.PrintPage, AddressOf PrintImage
                                'MessageBox.Show("holi")
                                ' p.Print()
                                ImprimirFotoCheck(file.FullName)
                                'RemoveHandler p.PrintPage, AddressOf PrintImage
                            Catch ex As Exception
                                MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                        Case 1 '1 para Impresion de FotoCheck de ambos lados -> Agregado el 06/07/2024 Kevin Salazar
                            ' Configurar impresión dúplex si es posible
                            'If p.PrinterSettings.CanDuplex Then
                            '    p.PrinterSettings.Duplex = Duplex.Vertical ' Puede ser Vertical o Horizontal, dependiendo de la impresora
                            'Else
                            '    MessageBox.Show("La impresora seleccionada no admite impresión dúplex.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '    Exit Sub
                            'End If
                            'For i As Integer = 0 To files.Length - 1 Step 2
                            '    Dim imagenFrontal As String = files(i).FullName ' Imagen frontal
                            '    Dim imagenPosterior As String = files(i + 1).FullName ' Imagen posterior (en caso de impresión dúplex)


                            '' Asignar el controlador de evento para la impresión
                            'AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                            '                            ' Cargar el PDF o imagen desde el archivo
                            '                            Using image As Image = Image.FromFile(pdfPath)
                            '                                ' Dibujar la imagen en el área de impresión
                            '                                e.Graphics.DrawImage(image, e.MarginBounds)
                            '                            End Using
                            '                        End Sub

                            '' Iniciar la impresión
                            '' Imprimir la imagen frontal y posterior
                            'ImprimirFotoCheck(imagenFrontal)
                            'ImprimirFotoCheck(imagenPosterior)

                            MessageBox.Show("Impresión de FotoCheck de ambos lados")
                        Case Else
                            Throw New ArgumentException("Tipo de impresión no válido.")
                    End Select
                Next
                MessageBox.Show("Impresión de FotoCheck enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' MessageBox.Show("No se encontraron archivos de imágenes en la carpeta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al imprimir FotoCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ImprimirFotoCheck(FotoChechkFilePath As String)
        Try
            Dim p As New PrintDocument()
            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                        PrintImage(sender, e, FotoChechkFilePath)
                                    End Sub
            p.Print()
            RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                           PrintImage(sender, e, FotoChechkFilePath)
                                       End Sub
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
End Class
