''Imports System.Drawing.Printing
''Imports System.IO
''Imports System.Windows.Forms
''Imports System.Drawing
''Imports RawPrint
''Imports System.Net
''Imports System.Text
''Imports Neodynamic.SDK.ZPLPrinter
''Imports Lextm.SharpSnmpLib.Objects
''Imports System.Drawing.Imaging
'''Se creo la clase para la impresion directa de Fotochecks desde DataGreen -> Agregado el 03/07/2024 Kevin Salazar - Luiggi Moretti
''Public Class FotoCheckPrinter
''    Public Sub PrintFotoCheck(PathFotoCheck As String, tipoImpresion As String)

''        Try
''            ' Configurar la impresora seleccionada (opcional, dependiendo de cómo se seleccione la impresora)
''            Dim p As New PrintDocument()
''            Dim printDialog As New PrintDialog()

''            If printDialog.ShowDialog() = DialogResult.OK Then
''                p.PrinterSettings = printDialog.PrinterSettings
''            Else
''                Exit Sub ' Salir si el usuario cancela la selección de impresora
''            End If
''            ' Carpeta donde se guardaron las imágenes
''            Dim carpeta As New DirectoryInfo(PathFotoCheck)
''            Dim files As FileInfo() = carpeta.GetFiles("*.jpg") ' Filtrar archivos JPG (puedes ajustar según el tipo de archivo)

''            If files.Length > 0 Then



''                For Each file As FileInfo In files
''                    Select Case tipoImpresion 'verificar porque no recibe el valor del cboTipoFotocheck
''                        Case 0 '0 para Impresion de FotoCheck Solo -> Agregado el 06/07/2024 Kevin Salazar FUNCIONA OK
''                            Try
''                                ImprimirFotoCheck(file.FullName)
''                            Catch ex As Exception
''                                MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''                            End Try

''                        Case 1 '1 para Impresion de FotoCheck de ambos lados -> Agregado el 06/07/2024 Kevin Salazar
''                            Dim codigo As String = file.Name.Replace("fotocheck_", "").Replace("_Front.jpg", "").Replace("_Back.jpg", "")
''                            'MessageBox.Show(codigo)
''                            Dim frontSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Front.jpg"
''                            Dim backSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Back.jpg"
''                            'codigo = codigo("_Front.jpg", "")
''                            'codigo = codigo("_Back.jpg", "")
''                            MessageBox.Show(frontSide)
''                            MessageBox.Show(backSide)

''                            ImprimirAmbosLados(frontSide, backSide)
''                            'ImprimirFotoCheck(file.Directory.ToString + "fotocheck_" + codigo + "_Front.jpg")
''                            'ImprimirFotoCheck(file.Directory.ToString + "fotocheck_" + codigo + "_Back.jpg")
''                            ' Configurar impresión dúplex si es posible
''                            'If p.PrinterSettings.CanDuplex Then
''                            '    p.PrinterSettings.Duplex = Duplex.Vertical ' Puede ser Vertical o Horizontal, dependiendo de la impresora
''                            'Else
''                            '    MessageBox.Show("La impresora seleccionada no admite impresión dúplex.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
''                            '    Exit Sub
''                            'End If
''                            'For i As Integer = 0 To files.Length - 1 Step 2
''                            '    Dim imagenFrontal As String = files(i).FullName ' Imagen frontal
''                            '    Dim imagenPosterior As String = files(i + 1).FullName ' Imagen posterior (en caso de impresión dúplex)


''                            '' Asignar el controlador de evento para la impresión
''                            'AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                            '                            ' Cargar el PDF o imagen desde el archivo
''                            '                            Using image As Image = Image.FromFile(pdfPath)
''                            '                                ' Dibujar la imagen en el área de impresión
''                            '                                e.Graphics.DrawImage(image, e.MarginBounds)
''                            '                            End Using
''                            '                        End Sub

''                            '' Iniciar la impresión
''                            '' Imprimir la imagen frontal y posterior
''                            'ImprimirFotoCheck(imagenFrontal)
''                            'ImprimirFotoCheck(imagenPosterior)

''                            '---------------------------- verificar este método con varias imagenes ----------------------------
''                            'ImprimirFotoCheckDobleCara(p, file.FullName)
''                            '---------------------------------------------------------------------------------------------------

''                            '---------------------------- verificar tambien este otro método ----------------------------
''                            ' Se espera que los archivos tengan nombres como PersonaA_1.jpg, PersonaA_2.jpg, PersonaB_1.jpg, PersonaB_2.jpg, etc.
''                            'Dim identifier = Path.GetFileNameWithoutExtension(file.Name).Split("_"c)(0) ' Obtener el identificador (PersonaA, PersonaB, etc.)
''                            'Dim filesForIdentifier = files.Where(Function(f) f.Name.StartsWith(identifier) AndAlso f.FullName <> file.FullName).ToList()

''                            '' Imprimir la imagen actual y su contraparte
''                            'ImprimirFotoCheck(file.FullName, p)
''                            'For Each fileBack As FileInfo In filesForIdentifier
''                            '    ImprimirFotoCheck(fileBack.FullName, p)
''                            'Next
''                            '---------------------------------------------------------------------------------------------------

''                            '---------------------------- verificar este método con varias imagenes ----------------------------
''                            'ImprimirAmbosLados(files) -> este llamada se hace a otra funcion
''                            ' Filtrar archivos por nombres que terminen en "_1.jpg" o "_2.jpg"
''                            'Dim filesToPrint As New List(Of FileInfo)
''                            'For Each fileD As FileInfo In files
''                            '    If fileD.Name.EndsWith("_Front.jpg") OrElse fileD.Name.EndsWith("_Back.jpg") Then
''                            '        filesToPrint.Add(fileD)
''                            '    End If
''                            'Next

''                            '' Ordenar archivos para imprimir en el orden correcto (si es necesario)
''                            'filesToPrint.Sort(Function(x, y) String.Compare(x.Name, y.Name))

''                            'For i As Integer = 0 To filesToPrint.Count - 2 Step 2
''                            '    Try
''                            '        ImprimirFotoCheck(filesToPrint(i).FullName)
''                            '        ImprimirFotoCheck(filesToPrint(i + 1).FullName)
''                            '    Catch ex As Exception
''                            '        MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''                            '    End Try
''                            'Next
''                            '---------------------------------------------------------------------------------------------------

''                            ' MessageBox.Show("Impresión de FotoCheck de ambos lados")
''                        Case Else
''                            Throw New ArgumentException("Tipo de impresión no válido.")
''                    End Select
''                Next
''                MessageBox.Show("Impresión de FotoCheck enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
''            Else
''                ' MessageBox.Show("No se encontraron archivos de imágenes en la carpeta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
''            End If
''        Catch ex As Exception
''            MessageBox.Show($"Error al imprimir FotoCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub
''    Public Sub ImprimirFotoCheck(FotoChechkFilePath As String)
''        Try
''            Dim p As New PrintDocument()
''            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                                        PrintImage(sender, e, FotoChechkFilePath)
''                                    End Sub
''            p.Print()
''            RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                                           PrintImage(sender, e, FotoChechkFilePath)
''                                       End Sub
''        Catch ex As Exception
''            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub

''    Private Sub ImprimirAmbosLados(front As String, back As String)
''        ' Filtrar archivos por nombres que terminen en "_1.jpg" o "_2.jpg"
''        'Dim filesToPrint As New List(Of FileInfo)
''        Try
''            Dim p As New PrintDocument()
''            ' Variable para controlar qué imagen se está imprimiendo
''            Dim isPrintingFront As Boolean = True

''            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                                        ' Obtener el tamaño de la página
''                                        Dim pageWidth As Integer = e.PageBounds.Width
''                                        Dim pageHeight As Integer = e.PageBounds.Height

''                                        ' Cargar las imágenes
''                                        Using frontImage As Image = Image.FromFile(front)
''                                            Using backImage As Image = Image.FromFile(back)
''                                                ' Dibujar la imagen del frente
''                                                If isPrintingFront Then
''                                                    e.Graphics.DrawImage(frontImage, 0, 0)
''                                                    e.HasMorePages = True ' Indicar que hay más páginas para imprimir
''                                                Else
''                                                    ' Dibujar la imagen de atrás
''                                                    e.Graphics.DrawImage(backImage, 0, 0)
''                                                    e.HasMorePages = False ' No hay más páginas
''                                                End If
''                                            End Using
''                                        End Using

''                                        ' Cambiar a la siguiente imagen para la próxima página
''                                        isPrintingFront = Not isPrintingFront
''                                    End Sub

''            p.Print()
''        Catch ex As Exception
''            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''        'For Each file As FileInfo In files
''        '    If file.Name.EndsWith("_Front.jpg") OrElse file.Name.EndsWith("_Back.jpg") Then
''        'filesToPrint.Add(file)
''        'End If
''        'Next
''        'filesToPrint(FileInfo)
''        ' Ordenar archivos para imprimir en el orden correcto (si es necesario)
''        'filesToPrint.Sort(Function(x, y) String.Compare(x.Name, y.Name))

''        ' Crear un documento de impresión para imprimir ambos lados de la hoja
''        'Dim p As New PrintDocument()
''        'p.PrinterSettings.Duplex = Duplex.Vertical


''        '' Contador para controlar la impresión delantera y trasera
''        'Dim contador As Integer = 0

''        '' Manejar evento para imprimir la página
''        'AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''        '                            ' Imprimir imagen delantera (si hay al menos una imagen)
''        '                            If contador < filesToPrint.Count Then
''        '                                PrintImage(sender, e, filesToPrint(contador).FullName)
''        '                                contador += 1
''        '                            End If

''        '                            ' Imprimir imagen trasera (si hay al menos una imagen adicional)
''        '                            If contador < filesToPrint.Count Then
''        '                                ' Ajusta la posición y el tamaño de acuerdo a tu diseño
''        '                                Dim rect As New RectangleF(100, 100, e.PageBounds.Width - 200, e.PageBounds.Height - 200)
''        '                                e.Graphics.DrawImage(Image.FromFile(filesToPrint(contador).FullName), rect)
''        '                                contador += 1
''        '                            End If

''        '                            ' Indicar que hay más páginas para imprimir si quedan imágenes
''        '                            e.HasMorePages = contador < filesToPrint.Count
''        '                        End Sub

''        '' Iniciar impresión
''        'p.Print()
''    End Sub

''    'Private Sub ImprimirFotoCheckDobleCara(ByVal p As PrintDocument, ByVal FotoChechkFilePath As String)
''    '    Try
''    '        AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''    '                                    PrintImage(sender, e, FotoChechkFilePath)
''    '                                End Sub
''    '        ' Primera cara (página)
''    '        p.Print()

''    '        ' Segunda cara (página)
''    '        p.Print()

''    '        RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''    '                                       PrintImage(sender, e, FotoChechkFilePath)
''    '                                   End Sub
''    '    Catch ex As Exception
''    '        MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''    '    End Try
''    'End Sub

''    Private Sub PrintImage(ByVal sender As Object, ByVal ppea As PrintPageEventArgs, ByVal filePath As String)
''        Try
''            Using image As Image = Image.FromFile(filePath)
''                ppea.Graphics.DrawImage(image, ppea.Graphics.VisibleClipBounds)
''            End Using
''        Catch ex As Exception
''            MessageBox.Show($"Error al imprimir la imagen {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub
''End Class



''************************************************* Codigo sin cambios original
''Imports System.Drawing.Printing
''Imports System.IO
''Imports System.Windows.Forms
''Imports System.Drawing
''Imports RawPrint
''Imports System.Net
''Imports System.Text
''Imports Neodynamic.SDK.ZPLPrinter
''Imports Lextm.SharpSnmpLib.Objects
''Imports System.Drawing.Imaging
'''Se creo la clase para la impresion directa de Fotochecks desde DataGreen -> Agregado el 03/07/2024 Kevin Salazar - Luiggi Moretti
''Public Class FotoCheckPrinter
''    Public Sub PrintFotoCheck(PathFotoCheck As String, tipoImpresion As String)

''        Try
''            ' Configurar la impresora seleccionada (opcional, dependiendo de cómo se seleccione la impresora)
''            Dim p As New PrintDocument()
''            Dim printDialog As New PrintDialog()

''            If printDialog.ShowDialog() = DialogResult.OK Then
''                p.PrinterSettings = printDialog.PrinterSettings
''            Else
''                Exit Sub ' Salir si el usuario cancela la selección de impresora
''            End If
''            ' Carpeta donde se guardaron las imágenes
''            Dim carpeta As New DirectoryInfo(PathFotoCheck)
''            Dim files As FileInfo() = carpeta.GetFiles("*.jpg") ' Filtrar archivos JPG (puedes ajustar según el tipo de archivo)

''            If files.Length > 0 Then
''                For Each file As FileInfo In files
''                    Select Case tipoImpresion 'verificar porque no recibe el valor del cboTipoFotocheck
''                        Case 0 '0 para Impresion de FotoCheck Solo -> Agregado el 06/07/2024 Kevin Salazar FUNCIONA OK
''                            Try
''                                'AddHandler p.PrintPage, AddressOf PrintImage
''                                'MessageBox.Show("holi")
''                                ' p.Print()
''                                ImprimirFotoCheck(file.FullName)
''                                'RemoveHandler p.PrintPage, AddressOf PrintImage
''                            Catch ex As Exception
''                                MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''                            End Try

''                        Case 1 '1 para Impresion de FotoCheck de ambos lados -> Agregado el 06/07/2024 Kevin Salazar
''                            ' Configurar impresión dúplex si es posible
''                            'If p.PrinterSettings.CanDuplex Then
''                            '    p.PrinterSettings.Duplex = Duplex.Vertical ' Puede ser Vertical o Horizontal, dependiendo de la impresora
''                            'Else
''                            '    MessageBox.Show("La impresora seleccionada no admite impresión dúplex.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
''                            '    Exit Sub
''                            'End If
''                            'For i As Integer = 0 To files.Length - 1 Step 2
''                            '    Dim imagenFrontal As String = files(i).FullName ' Imagen frontal
''                            '    Dim imagenPosterior As String = files(i + 1).FullName ' Imagen posterior (en caso de impresión dúplex)


''                            '' Asignar el controlador de evento para la impresión
''                            'AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                            '                            ' Cargar el PDF o imagen desde el archivo
''                            '                            Using image As Image = Image.FromFile(pdfPath)
''                            '                                ' Dibujar la imagen en el área de impresión
''                            '                                e.Graphics.DrawImage(image, e.MarginBounds)
''                            '                            End Using
''                            '                        End Sub

''                            '' Iniciar la impresión
''                            '' Imprimir la imagen frontal y posterior
''                            'ImprimirFotoCheck(imagenFrontal)
''                            'ImprimirFotoCheck(imagenPosterior)

''                            '---------------------------- verificar este método con varias imagenes ----------------------------
''                            'ImprimirFotoCheckDobleCara(p, file.FullName)
''                            '---------------------------------------------------------------------------------------------------

''                            '---------------------------- verificar tambien este otro método ----------------------------
''                            ' Se espera que los archivos tengan nombres como PersonaA_1.jpg, PersonaA_2.jpg, PersonaB_1.jpg, PersonaB_2.jpg, etc.
''                            'Dim identifier = Path.GetFileNameWithoutExtension(file.Name).Split("_"c)(0) ' Obtener el identificador (PersonaA, PersonaB, etc.)
''                            'Dim filesForIdentifier = files.Where(Function(f) f.Name.StartsWith(identifier) AndAlso f.FullName <> file.FullName).ToList()

''                            '' Imprimir la imagen actual y su contraparte
''                            'ImprimirFotoCheck(file.FullName, p)
''                            'For Each fileBack As FileInfo In filesForIdentifier
''                            '    ImprimirFotoCheck(fileBack.FullName, p)
''                            'Next
''                            '---------------------------------------------------------------------------------------------------
''                            MessageBox.Show("Impresión de FotoCheck de ambos lados")
''                        Case Else
''                            Throw New ArgumentException("Tipo de impresión no válido.")
''                    End Select
''                Next
''                MessageBox.Show("Impresión de FotoCheck enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
''            Else
''                ' MessageBox.Show("No se encontraron archivos de imágenes en la carpeta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
''            End If
''        Catch ex As Exception
''            MessageBox.Show($"Error al imprimir FotoCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub
''    Public Sub ImprimirFotoCheck(FotoChechkFilePath As String)
''        Try
''            Dim p As New PrintDocument()
''            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                                        PrintImage(sender, e, FotoChechkFilePath)
''                                    End Sub
''            p.Print()
''            RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''                                           PrintImage(sender, e, FotoChechkFilePath)
''                                       End Sub
''        Catch ex As Exception
''            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub

''    'Private Sub ImprimirFotoCheckDobleCara(ByVal p As PrintDocument, ByVal FotoChechkFilePath As String)
''    '    Try
''    '        AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''    '                                    PrintImage(sender, e, FotoChechkFilePath)
''    '                                End Sub
''    '        ' Primera cara (página)
''    '        p.Print()

''    '        ' Segunda cara (página)
''    '        p.Print()

''    '        RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
''    '                                       PrintImage(sender, e, FotoChechkFilePath)
''    '                                   End Sub
''    '    Catch ex As Exception
''    '        MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''    '    End Try
''    'End Sub

''    Private Sub PrintImage(ByVal sender As Object, ByVal ppea As PrintPageEventArgs, ByVal filePath As String)
''        Try
''            Using image As Image = Image.FromFile(filePath)
''                ppea.Graphics.DrawImage(image, ppea.Graphics.VisibleClipBounds)
''            End Using
''        Catch ex As Exception
''            MessageBox.Show($"Error al imprimir la imagen {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
''        End Try
''    End Sub
''End Class

''*************************
'Imports System.Drawing.Printing
'Imports System.IO
'Imports System.Windows.Forms
'Imports System.Drawing
'Imports RawPrint
'Imports System.Net
'Imports System.Text
'Imports Neodynamic.SDK.ZPLPrinter
'Imports Lextm.SharpSnmpLib.Objects
'Imports System.Drawing.Imaging
''Se creo la clase para la impresion directa de Fotochecks desde DataGreen -> Agregado el 03/07/2024 Kevin Salazar - Luiggi Moretti
'Public Class FotoCheckPrinter
'    Public Sub PrintFotoCheck(PathFotoCheck As String, tipoImpresion As String)

'        Try
'            ' Configurar la impresora seleccionada (opcional, dependiendo de cómo se seleccione la impresora)
'            Dim p As New PrintDocument()
'            Dim printDialog As New PrintDialog()


'            If printDialog.ShowDialog() = DialogResult.OK Then
'                p.PrinterSettings = printDialog.PrinterSettings
'            Else
'                Exit Sub ' Salir si el usuario cancela la selección de impresora
'            End If
'            ' Carpeta donde se guardaron las imágenes
'            Dim carpeta As New DirectoryInfo(PathFotoCheck)
'            Dim files As FileInfo() = carpeta.GetFiles("*.jpg") ' Filtrar archivos JPG (puedes ajustar según el tipo de archivo)

'            If files.Length > 0 Then
'                For Each file As FileInfo In files
'                    Select Case tipoImpresion 'verificar porque no recibe el valor del cboTipoFotocheck
'                        Case 1 '0 para Impresion de FotoCheck Solo -> Agregado el 06/07/2024 Kevin Salazar FUNCIONA OK
'                            Try
'                                'AddHandler p.PrintPage, AddressOf PrintImage
'                                'MessageBox.Show("holi")
'                                ' p.Print()
'                                ImprimirFotoCheck(file.FullName)
'                                'RemoveHandler p.PrintPage, AddressOf PrintImage
'                            Catch ex As Exception
'                                MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                            End Try

'                        Case 0 '1 para Impresion de FotoCheck de ambos lados -> Agregado el 06/07/2024 Kevin Salazar
'                            'Dim codigo As String = file.Name.Replace("fotocheck_", "").Replace("_Front.jpg", "").Replace("_Back.jpg", "")
'                            ''MessageBox.Show(codigo)
'                            'Dim frontSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Front.jpg"
'                            'Dim backSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Back.jpg"
'                            ''codigo = codigo("_Front.jpg", "")
'                            ''codigo = codigo("_Back.jpg", "")
'                            'MessageBox.Show(frontSide)
'                            'MessageBox.Show(backSide)
'                            ImprimirAmbosLados(file.FullName)

'                            'ImprimirAmbosLados(frontSide, backSide)
'                            '---------------------------------------------------------------------------------------------------
'                            MessageBox.Show("Impresión de FotoCheck de ambos lados")
'                        Case Else
'                            Throw New ArgumentException("Tipo de impresión no válido.")
'                    End Select
'                Next
'                MessageBox.Show("Impresión de FotoCheck enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Else
'                ' MessageBox.Show("No se encontraron archivos de imágenes en la carpeta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            End If
'        Catch ex As Exception
'            MessageBox.Show($"Error al imprimir FotoCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub
'    Public Sub ImprimirFotoCheck(FotoChechkFilePath As String)
'        Try
'            Dim p As New PrintDocument()
'            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
'                                        PrintImage(sender, e, FotoChechkFilePath)
'                                    End Sub
'            p.Print()
'            'RemoveHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
'            '                               PrintImage(sender, e, FotoChechkFilePath)
'            '                           End Sub
'        Catch ex As Exception
'            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Private Sub ImprimirAmbosLados(FotoChechkFilePath As String)
'        Try
'            Dim codigo As String = Path.GetFileNameWithoutExtension(FotoChechkFilePath).Replace("fotocheck_", "")
'            Dim frontSide As String = Path.Combine(Path.GetDirectoryName(FotoChechkFilePath), $"fotocheck_{codigo}.jpg")
'            Dim backSide As String = Path.Combine(Path.GetDirectoryName(FotoChechkFilePath), $"fotocheck_{codigo}.jpg")
'            'Dim codigo As String = file.Name.Replace("fotocheck_", "").Replace("_Front.jpg", "").Replace("_Back.jpg", "")
'            ''MessageBox.Show(codigo)
'            'Dim frontSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Front.jpg"
'            'Dim backSide As String = file.Directory.ToString + "\fotocheck_" + codigo + "_Back.jpg"

'            ImprimirFotoCheck(frontSide)
'            ImprimirFotoCheck(backSide)
'        Catch ex As Exception
'            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub


'    Private Sub ImprimirAmbosLados(front As String, back As String)
'        ' Filtrar archivos por nombres que terminen en "_1.jpg" o "_2.jpg"
'        'Dim filesToPrint As New List(Of FileInfo)

'        Try
'            Dim p As New PrintDocument()
'            ' Variable para controlar qué imagen se está imprimiendo
'            Dim isPrintingFront As Boolean = True

'            AddHandler p.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
'                                        ' Obtener el tamaño de la página
'                                        Dim pageWidth As Integer = e.PageBounds.Width
'                                        Dim pageHeight As Integer = e.PageBounds.Height

'                                        ' Cargar las imágenes
'                                        Using frontImage As Image = Image.FromFile(front)
'                                            Using backImage As Image = Image.FromFile(back)
'                                                ' Dibujar la imagen del frente
'                                                If isPrintingFront Then
'                                                    e.Graphics.DrawImage(frontImage, 0, 0)
'                                                    e.HasMorePages = True ' Indicar que hay más páginas para imprimir
'                                                Else
'                                                    ' Dibujar la imagen de atrás
'                                                    e.Graphics.DrawImage(backImage, 0, 0)
'                                                    e.HasMorePages = False ' No hay más páginas
'                                                End If
'                                            End Using
'                                        End Using

'                                        ' Cambiar a la siguiente imagen para la próxima página
'                                        isPrintingFront = Not isPrintingFront
'                                    End Sub

'            p.Print()
'        Catch ex As Exception
'            MessageBox.Show($"Error durante la impresión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub

'    Private Sub PrintImage(ByVal sender As Object, ByVal ppea As PrintPageEventArgs, ByVal filePath As String)
'        Try
'            Using image As Image = Image.FromFile(filePath)
'                ppea.Graphics.DrawImage(image, ppea.Graphics.VisibleClipBounds)
'            End Using
'        Catch ex As Exception
'            MessageBox.Show($"Error al imprimir la imagen {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub
'End Class
