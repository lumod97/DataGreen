Imports Datos.Conexion
Imports Logica.Funciones
Imports Logica.Utiles
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports AxAcroPDFLib
Imports System.CodeDom
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Web
Imports RawPrint
Imports System.Drawing.Printing
Imports System.IO.Compression
Imports Logica
Imports System.Net.Http
Imports System.Drawing
Public Class frmRrhh_Reportes_GenerarFotocheck

    Dim dtResultado As New DataTable
    Dim dtSeleccionados As New DataTable
    Dim dvResultado, dvSeleccionados As DataView
    Dim arrayDeParametros As String = String.Empty
    Dim bsFiltro As New BindingSource()
    Dim bsFiltroSeleccionados As New BindingSource()
    Dim filasAfectasResultadoGeneral, filasAfectasCodigosSeleccionado As List(Of Integer)
    Dim dtTablaExcel As New DataTable
    Dim dsParaCombos As DataSet = New DataSet
    Private generarFotoCheckExitoso As Boolean = False
    Private rutaFotocheck As String
    Private imagenes As List(Of Image) ' Lista para almacenar todas las imágenes encontradas
    Private indiceActual As Integer ' Índice de la imagen actualmente mostrada

    Private Sub frmRrhh_Reportes_GenerarFotocheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaComboTipoFotocheck() 'Funcion para obtener la data del combobox -> Agregado el 05/07/2024 Kevin Salazar
        obtenerDataGeneral()
        cargarCombo(cboTipoFotocheck, dsParaCombos.Tables(0), 0, 2) 'Funcion para cargar el combobox -> Agregado el 05/07/2024 Kevin Salazar
        aplicarTema(Me)
    End Sub

    'Funcion para generar el combobox desde la BD (sp)-> Agregado el 05/07/2024 Kevin Salazar
    Private Sub obtenerDataParaComboTipoFotocheck()
        Dim aux As New DataTable
        aux = doItBaby("sp_ObtenerTipoFotocheck", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
    End Sub
    Private Sub cargarDataGeneral()
        dvResultado = New DataView(dtResultado)
        bsFiltro.DataSource = dvResultado
        dgvResultado.DataSource = bsFiltro
        dvSeleccionados = New DataView(dtSeleccionados)
        bsFiltroSeleccionados.DataSource = dvSeleccionados
        dgvSeleccionados.DataSource = bsFiltroSeleccionados
    End Sub

    Private Async Sub obtenerDataGeneral()
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        dgv = consultarAsync()
        dtResultado = Await dgv
        dtSeleccionados = dtResultado.Clone
        cargarDataGeneral()
        formatearDataGridView(dgvResultado)
        formatearDataGridView(dgvSeleccionados)
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    End Sub

    Private Async Sub obtenerDataRefresh()
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        dgv = consultarAsync()
        dtResultado = Await dgv
        dvResultado = New DataView(dtResultado)
        bsFiltro.DataSource = dvResultado
        dgvResultado.DataSource = bsFiltro
        formatearDataGridView(dgvResultado)
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            arrayDeParametros = obtenerCadenaParametros(Nothing)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_GenerarFotochecks_ObtenerDataGeneral", Nothing, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        rutaFotocheck = ""
        If cboTipoFotocheck.SelectedIndex <> -1 Then
            Try
                encenderControlesDeEspera(barProgreso, lblDin_Resultado)
                Dim seleccionados As New DataTable()
                Dim codigos As New List(Of Object)
                'obtenemos los codigos
                For Each fila As DataRow In dtSeleccionados.Rows
                    Dim codigo As String
                    Dim dni As String

                    codigo = fila.Item("T_IdCodigoGeneral")
                    dni = fila.Item("T_Dni")

                    Dim movimientos As New Dictionary(Of String, String)()

                    movimientos.Add("codigo", codigo)
                    movimientos.Add("encriptado", EncriptarCodigo(dni))
                    codigos.Add(movimientos)
                Next

                generarFotoCheck(codigos)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Debe seleccionar un tipo de fotocheck antes de Generar los FotoCheck.")
        End If

    End Sub

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex >= 0 Then
            filasAfectasResultadoGeneral = New List(Of Integer)
            For Each f As DataGridViewRow In dgvResultado.SelectedRows
                filasAfectasResultadoGeneral.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasResultadoGeneral
                dtSeleccionados.ImportRow(dtResultado.Rows(i - 1))
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub
    Private Async Function generarFotoCheck(codigos As List(Of Object)) As Task 'Se modifico la funcionalidad para generarPDF a los fotocheck que llaman a otras funciones -> Agregado el 10/07/2024 Kevin Salazar
        Dim apiUrl As String
        Dim parametros As New Dictionary(Of String, Object)()
        Dim tipoImpresionIndex As String = cboTipoFotocheck.SelectedIndex

        parametros.Add("codigos", codigos)
        parametros.Add("vista", "vista_pdf")

        If cbTipoEmpleado.Checked Then
            apiUrl = "http://192.168.30.94:8080/api/get_pdf_test"
            parametros("vista") += "_emp"
        Else
            apiUrl = "http://192.168.30.94:8080/api/get_pdf_barras_cu"
        End If

        Dim jsonData As String = JsonConvert.SerializeObject(parametros)

        Try
            ' Descargar el ZIP de imágenes
            Dim zipFilePath As String = Await DescargarArchivoAsync(apiUrl, jsonData) 'Llamado a la funcion que recibe la URL de la api y la data en formato Json
            Dim extractPath As String = zipFilePath.Replace("Fotocheck_Comprimidos", "Fotocheck") 'Funcion que cambia la ruta del archivo descomprimido hacia la ruta de las imagenes y lo guarda en una variable local
            ' Verificar si se descargó correctamente el ZIP
            If Not String.IsNullOrEmpty(zipFilePath) Then
                ' Carpeta local donde se guardarán los archivos descomprimidos
                Dim numImages As Integer = DescomprimirZIP(rutaFotocheck + ".zip", extractPath) '
                ' Mostrar las imágenes en un PictureBox o cualquier otro control adecuado
                MostrarImagenesDescargadas(extractPath) 'Funcion que deberia mostrar las imagenes extraidas en un PictureBox -> Se debe mejorar porque no lo hace
                generarFotoCheckExitoso = True 'Variable global que indica que generacion del fotocheck fue exitosa
            Else
                generarFotoCheckExitoso = False 'Variable global que indica que generacion del fotocheck fue erronea
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al obtener respuesta desde API: {ex.Message}")
            generarFotoCheckExitoso = False
        Finally
            ' Realizar cualquier limpieza necesaria aquí
            apagarControlesDeEspera(barProgreso, lblDin_Resultado)
        End Try
    End Function
    Private Sub MostrarImagenesDescargadas(extractPath As String) 'Se agrego la funcionalidad para mostrar las imagenes en un PictureBox (Falta arreglar) -> Agregado el 10/07/2024 Kevin Salazar
        'Se debe mejorar esta funcion porque no muestra las imagenes
        Try
            Dim files As String() = Directory.GetFiles(extractPath, "*.jpg")

            If files.Length > 0 Then
                ' Inicializar la lista de imágenes
                imagenes = New List(Of Image)()
                ' Iterar sobre cada archivo encontrado
                For Each filePath As String In files
                    ' Cargar la imagen desde el archivo
                    Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                        Dim img As Image = Image.FromStream(fs)
                        imagenes.Add(img)
                    End Using
                Next
                ' Verificar si se encontraron imágenes
                If imagenes.Count > 0 Then
                    ' Mostrar la primera imagen
                    indiceActual = 0
                Else
                    MessageBox.Show("No se encontraron imágenes en el directorio especificado.")
                End If
            Else
                MessageBox.Show("No se encontraron imágenes en el directorio especificado.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al mostrar imágenes: {ex.Message}")
        End Try
    End Sub

    Private Async Function DescargarArchivoAsync(apiUrl As String, jsonData As String) As Task(Of String) 'Se agrego la funcionalidad para descargar -> Agregado el 10/07/2024 Kevin Salazar
        Try
            Dim folderId = Guid.NewGuid().ToString() 'Identificador único para la carpeta en cada descarga de archivos
            rutaFotocheck = "D:\Fotocheck_Comprimidos\" + folderId 'Ruta del archivo zip
            Dim rutafotocheckImagenes As String = "D:\Fotocheck\" + folderId 'Ruta de los archivos donde se van a descomprimir

            Using client As New HttpClient()
                Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")
                ' Realizar la solicitud POST
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                response.EnsureSuccessStatusCode() ' Verificar que la solicitud fue exitosa
                ' Leer y guardar el archivo ZIP, si no existe la unidad D, se descarga el zip en Documentos de la unidad C
                If Directory.Exists("D:\") Then 'Validacion en caso no exista el directorio D:\
                    If Not Directory.Exists(rutaFotocheck) Then
                        Directory.CreateDirectory(rutaFotocheck)
                    End If
                    If Not Directory.Exists(rutafotocheckImagenes) Then
                        Directory.CreateDirectory(rutafotocheckImagenes)
                    End If
                Else 'Caso contrario se crea directorio C:\Usuario\Documentos
                    If Not Directory.Exists(rutaFotocheck) Then
                        Directory.CreateDirectory(rutaFotocheck)
                    End If
                    If Not Directory.Exists(rutafotocheckImagenes) Then
                        Directory.CreateDirectory(rutafotocheckImagenes)
                    End If
                End If
                Using fileStream As FileStream = File.Create(rutaFotocheck + ".zip")
                    Await response.Content.CopyToAsync(fileStream)
                End Using
                Return rutaFotocheck ' Devolver la ruta del archivo descargado
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al descargar archivo: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Private Function DescomprimirZIP(zipFilePath As String, extractPath As String) As Integer 'Se agrego la funcionalidad para descomprimir y guardar las imagenes en un directorio local -> Agregado el 10/07/2024 Kevin Salazar
        Dim numImages As Integer = 0
        Try
            ' Crear directorio si no existe
            If Not Directory.Exists(extractPath) Then
                Directory.CreateDirectory(extractPath)
            End If
            ' Descomprimir el archivo ZIP
            Using archive As ZipArchive = ZipFile.OpenRead(zipFilePath)
                For Each entry As ZipArchiveEntry In archive.Entries
                    If Not entry.FullName.EndsWith("/") Then ' Evitar directorios en el nivel superior
                        Dim fullPath As String = Path.Combine(extractPath, entry.FullName)
                        entry.ExtractToFile(fullPath, True)
                        ' Contar archivos de imagen descomprimidos
                        If fullPath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) OrElse
                       fullPath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) OrElse
                       fullPath.EndsWith(".png", StringComparison.OrdinalIgnoreCase) OrElse
                       fullPath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) Then
                            numImages += 1
                        End If
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al descomprimir archivo ZIP: {ex.Message}")
        Finally
            File.Delete(zipFilePath)
        End Try
        Return numImages
    End Function

    Private Async Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click 'Se agrego la funcionalidad de evento para el btnClickImprimir  -> Agregado el 06/07/2024 Kevin Salazar
        Try
            ' Carpeta donde se guardaron las imágenes
            Dim fotochechkPrinter As New FotoCheckPrinter()
            Dim tipoImpresionIndex As String = cboTipoFotocheck.SelectedIndex
            Dim rutaImagenes As String = rutaFotocheck.Replace("Fotocheck_Comprimidos", "FotoCheck")
            ' Validar si se seleccionó un ítem en el ComboBox  
            If tipoImpresionIndex >= 0 Then 'Validacion de que se haya seleccionado al menos un tipo de impresion en el ComboBox
                Dim tipoImpresion As String = tipoImpresionIndex.ToString() 'Variable que obtiene el indice del comboBox
                If generarFotoCheckExitoso Then 'Validacion ee la variable global para ver si la generación del Fotocheck fue exitosa antes de imprimir
                    ' Imprimir las imágenes
                    fotochechkPrinter.PrintFotoCheck(rutaImagenes, tipoImpresion) 'Llamado a la clase FotoCheckPrinter() que se envia como parametros la ruta de imagenes descomprimidas y el tipo de impresion del comboBox
                Else
                    MessageBox.Show("Debe generar el FotoCheck correctamente antes de imprimir.")
                End If
            Else
                MessageBox.Show("Debe seleccionar el tipo de FotoCheck que desea generar .")

            End If

            rutaFotocheck = ""

        Catch ex As Exception
            MessageBox.Show($"Error al imprimir documentos: {ex.Message}")
        End Try
    End Sub

    Private Function EncriptarCodigo(cadenaACifrar As String) As String
        'PASO 0: CREACION DE VARIABLES

        Dim logintudOriginal As Integer = cadenaACifrar.Length - 1
        If logintudOriginal <> 7 Then
            Throw New Exception("La cadena no tiene la longitud necesario (8)")
        End If
        'PASO 1: INDIZAR CADENA, SE PASA A ARRAY DE CHAR
        Dim aCadena(logintudOriginal) As Integer
        For i As Integer = 0 To logintudOriginal Step 1
            aCadena(i) = Integer.Parse(cadenaACifrar(i))
        Next
        Dim sumaA As Integer = 0
        'PASO 2: OBTENER SUMA DE DIGITOS
        For Each c As Integer In aCadena
            sumaA += c
        Next
        'PASO 3: OBTENER CLAVE A (ULTIMO DIGITO DE LA SUMA)
        Dim claveA As Integer = sumaA Mod 10
        'PASO 4: DETERMINAR SI LA CLAVE A ES PAR 
        Dim claveAEsPar As Boolean = IIf(claveA Mod 2 <> 0, False, True)
        'PASO 5: OPERAR SUMA DE LA CLAVE A SOBRE ALGUNOS DIGITOS, SI LA CLAVE A ES PAR SOBRE LOS DIGITOS PARES, Y VICEVERSA
        For i As Integer = 1 To logintudOriginal Step 1
            If claveAEsPar And i Mod 2 = 0 Then
                aCadena(i) = aCadena(i) + claveA
            ElseIf Not claveAEsPar And i Mod 2 <> 0 Then
                aCadena(i) = aCadena(i) + claveA
            End If
        Next
        'PASO 6: SI ALGUN DIGITO RESULTANTE ES MAYOR O IGUAL QUE 10 SE REDUCE A 1 DIGITO RESTANDOLE 10
        For i As Integer = 0 To logintudOriginal Step 1
            If aCadena(i) > 9 Then
                aCadena(i) = aCadena(i) - 10
            End If
        Next
        'PASO 7: HALLAR EL COMPLEMENTO A DECENA DE CADA DIGITO Y REEMPLAZAR LOS DIGITOS ORIGINALES POR LOS COMPLEMENTOS
        For i As Integer = 0 To logintudOriginal Step 1
            If aCadena(i) <> 0 Then
                aCadena(i) = 10 - aCadena(i)
            End If
        Next
        'PASO 8: OBTENER 2 SUBCADENAS USANDO COMO PIVOTE EL DIGITO EN LA POSICION N DONDE N ES LA CLAVE A SIEMPRE QUE CLAVE A SEA MENOR O IGUAL QUE
        'LA LONGITUD DE LA CADENA ORIGINAL -1, DE LO CONTRARIO N ES CLAVE A - LONGITUD DE LA CADENA ORIGINAL - 1
        Dim pivote As Integer = IIf(claveA <= logintudOriginal, claveA, claveA - logintudOriginal)
        Dim cadenaIzquierda As String = String.Empty, cadenaDerecha As String = String.Empty
        For i As Integer = 0 To logintudOriginal Step 1
            If i < pivote Then
                cadenaIzquierda &= aCadena(i).ToString
            Else
                cadenaDerecha &= aCadena(i).ToString
            End If
        Next
        Dim cadenaFinal As String = cadenaDerecha & cadenaIzquierda
        Dim sumaB As Integer = 0
        For Each c As Char In cadenaFinal.ToCharArray
            sumaB += Integer.Parse(c)
        Next
        Dim claveB As Integer = sumaB Mod 10
        cadenaFinal &= claveA.ToString & claveB.ToString
        Return cadenaFinal
    End Function


    'Private Function DesencriptarCodigo(cadenaCifrada As String) As String
    '    ' PASO 0: CREACIÓN DE VARIABLES
    '    Dim longitudCifrada As Integer = cadenaCifrada.Length - 1
    '    If longitudCifrada <> 9 Then
    '        Throw New Exception("La cadena cifrada no tiene la longitud necesaria (10)")
    '    End If

    '    ' Extraer claveA y claveB del final de la cadena cifrada
    '    Dim claveA As Integer = Integer.Parse(cadenaCifrada(longitudCifrada - 1).ToString())
    '    Dim claveB As Integer = Integer.Parse(cadenaCifrada(longitudCifrada).ToString())

    '    ' Obtener la cadena final sin las claves
    '    Dim cadenaFinal As String = cadenaCifrada.Substring(0, longitudCifrada - 1)

    '    ' PASO 1: Hallar el pivote
    '    Dim logintudOriginal As Integer = longitudCifrada - 2
    '    Dim pivote As Integer = If(claveA <= logintudOriginal, claveA, claveA - logintudOriginal)

    '    ' Dividir la cadena en dos partes según el pivote
    '    Dim cadenaDerecha As String = cadenaFinal.Substring(0, pivote)
    '    Dim cadenaIzquierda As String = cadenaFinal.Substring(pivote)

    '    ' Concatenar las partes en el orden inverso al cifrado
    '    Dim cadenaDescifrada As String = cadenaIzquierda & cadenaDerecha

    '    ' Convertir la cadena descifrada a un array de dígitos
    '    Dim aCadena(logintudOriginal) As Integer
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        aCadena(i) = Integer.Parse(cadenaDescifrada(i).ToString())
    '    Next

    '    ' PASO 2: Hallar el complemento a decena y revertir
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        If aCadena(i) <> 0 Then
    '            aCadena(i) = 10 - aCadena(i)
    '        End If
    '    Next

    '    ' PASO 3: Revertir las operaciones sobre los dígitos según claveAEsPar
    '    Dim claveAEsPar As Boolean = (claveA Mod 2 = 0)

    '    For i As Integer = 1 To logintudOriginal Step 1
    '        If claveAEsPar And i Mod 2 = 0 Then
    '            aCadena(i) = aCadena(i) - claveA
    '        ElseIf Not claveAEsPar And i Mod 2 <> 0 Then
    '            aCadena(i) = aCadena(i) - claveA
    '        End If

    '        ' Asegurarse de que los dígitos están en el rango [0,9]
    '        If aCadena(i) < 0 Then
    '            aCadena(i) += 10
    '        End If
    '    Next

    '    ' Convertir los dígitos a caracteres y concatenar
    '    Dim cadenaDescifradaFinal As String = String.Empty
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        cadenaDescifradaFinal &= aCadena(i).ToString()
    '    Next

    '    Return cadenaDescifradaFinal
    'End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If dgvResultado.SelectedRows.Count > 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvResultado.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                dtSeleccionados.ImportRow(dtResultado.Rows(i - 1))
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvSeleccionados.SelectedRows.Count > 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvSeleccionados.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                For j As Integer = 0 To dtSeleccionados.Rows.Count - 1 Step 1
                    If dtSeleccionados.Rows(j).Item(0).ToString.Equals(i.ToString) Then
                        dtSeleccionados.Rows.RemoveAt(j)
                    End If
                    If j >= dtSeleccionados.Rows.Count - 1 Then
                        Exit For
                    End If
                Next
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        obtenerDataRefresh()
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaArchivo.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnCargarArchivo_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click
        Try
            dtTablaExcel = cargarExcel(txtRutaArchivo.Text) 'PENDIENTE CAMBIAR LA FUNCION CARGAREXCEL POR UN PROCESO EN MOTOR SQL
            corregirTabla(dtTablaExcel)
            barProgreso.Value = 0
            barProgreso.Maximum = dtTablaExcel.Rows.Count
            barProgreso.Style = ProgressBarStyle.Continuous

            'armando el dt con los dni de dtTablaExcel
            Dim listaDNI = New List(Of Integer)
            If dtTablaExcel.Rows.Count > 0 Then
                listaDNI = New List(Of Integer)
                For Each f As DataRow In dtTablaExcel.Rows
                    listaDNI.Add(f("T_Dni").ToString())
                Next
                For Each i As Integer In listaDNI
                    For Each j As DataRow In dtResultado.Rows
                        If (j("T_Dni").Equals(i.ToString())) Then
                            dtSeleccionados.ImportRow(dtResultado.Rows(j("T_Fila") - 1))
                        End If
                    Next

                    'dtSeleccionados.ImportRow(dtResultado.Rows())
                Next
                formatearDataGridView(dgvSeleccionados)
            End If

            lblDin_Resultado.Text = "Registros: " + dtTablaExcel.Rows.Count().ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            formatearDataGridView(dgvResultado)

        End Try
    End Sub

    Private Sub dgvSeleccionados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeleccionados.CellContentClick

    End Sub

    Private Sub wbrImprimible_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub txtFiltroSeleccionados_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroSeleccionados.TextChanged

    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub



    'Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir_Click
    'ver la forma de incluir la impresion de fotochecks con el dispositivo Zebra ZC300

    'Try
    ' Abrir el archivo PDF
    'Using pdfFileStream As New FileStream(pdfFilePath, FileMode.Open, FileAccess.Read)
    ' Leer el contenido del PDF
    'Dim pdfBytes(pdfFileStream.Length - 1) As Byte
    'pdfFileStream.Read(pdfBytes, 0, pdfBytes.Length)
    'pdfFileStream.Close()

    ' Enviar los bytes del PDF a la impresora Zebra ZC300
    'RawPrinterHelper.SendBytesToPrinter("IMP_CONTABILIDAD", pdfBytes)
    'End Using
    'Catch ex As Exception
    'MessageBox.Show($"Error al imprimir fotocheck: {ex.Message}")
    'End Try
    'End Sub

    Private Sub dgvSeleccionados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeleccionados.CellDoubleClick
        If e.RowIndex >= 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvSeleccionados.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                For j As Integer = 0 To dtSeleccionados.Rows.Count - 1 Step 1
                    If dtSeleccionados.Rows(j).Item(0).ToString.Equals(i.ToString) Then
                        dtSeleccionados.Rows.RemoveAt(j)
                    End If
                    If j >= dtSeleccionados.Rows.Count - 1 Then
                        Exit For
                    End If
                Next
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsFiltro.Filter = String.Format(
                                        "T_IdPlanilla like '%{0}%' Or " +
                                        "T_IdCodigoGeneral like '%{1}%' Or " +
                                        "T_Dni like '%{2}%' Or " +
                                        "T_Trabajador like '%{3}%' Or " +
                                        "T_IdCargo like '%{4}%' Or " +
                                        "T_Cargo like '%{5}%' Or " +
                                        "T_IdArea like '%{6}%' Or " +
                                        "T_Area like '%{7}%'",
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text)
    End Sub
    Private Sub cboTipoFotocheck_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoFotocheck.SelectedIndexChanged

    End Sub
End Class