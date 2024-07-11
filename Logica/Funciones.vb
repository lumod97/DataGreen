Imports Entidades.Temporales
Imports Logica.Utiles
Imports Datos.Conexion
Imports Datos.ConexionSqlite
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel.Constants
Imports Microsoft.Office.Interop
Imports Entidades
Imports ClosedXML.Excel
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

'AGREGAR REFERENCIA A MICROSOFT.OFFICE.INTEROP.EXCEL PARA QUE FUNCIONES EXCEL
'AGREGAR REFERENCIA A SYSTEM.WINDOWS.FORMS PARA QUE FUNCIONES CLIPBOARD
'Imports System.Windows.Forms

Public Class Funciones

    Public Shared Sub cargarPreferenciasDeInicio(ByRef rec_U As Boolean, ByRef u_Rec As String, ByRef p_Rec As String)
        Try
            Dim query As String = "SELECT Valor FROM SqliteConfiguracion WHERE CLAVE='RecordarUsuario'"
            rec_U = IIf(ejecutarSqlite(query, tipoProceso.Scalar) = 1, True, False)
            query = "SELECT Valor FROM SqliteConfiguracion WHERE CLAVE='UsuarioRecordado'"
            u_Rec = IIf(rec_U, ejecutarSqlite(query, tipoProceso.Scalar), "")
            query = "SELECT Valor FROM SqliteConfiguracion WHERE CLAVE='PasswordRecordada'"
            p_Rec = IIf(rec_U, ejecutarSqlite(query, tipoProceso.Scalar), "")
        Catch
        End Try
    End Sub

    Public Shared Function existeBDSqlite()
        Try
            If File.Exists(bdSqlite) Then
                Return True
                'Else
                '    Directory.CreateDirectory(rutaGeneral + rutaSqlite)
                '    crearBD(True)
            End If
            Return False
        Catch
            Return False
        End Try
    End Function

    Public Shared Sub guardarPreferenciasDeInicio(cbx As Boolean, usuario As String, password As String)
        Try
            usuario = IIf(cbx, usuario, "")
            password = IIf(cbx, password, "")
            Dim q As String = "UPDATE SqliteConfiguracion SET VALOR='" + IIf(cbx, "1", "0") + "' WHERE CLAVE='RecordarUsuario'"
            ejecutarSqlite(q, tipoProceso.NonQuery)
            q = "UPDATE SqliteConfiguracion SET VALOR='" + usuario + "' WHERE CLAVE='UsuarioRecordado'"
            ejecutarSqlite(q, tipoProceso.NonQuery)
            q = "UPDATE SqliteConfiguracion SET VALOR='" + password + "' WHERE CLAVE='PasswordRecordada'"
            ejecutarSqlite(q, tipoProceso.NonQuery)
        Catch
        End Try
    End Sub

    Public Shared Sub cargarCredenciales()
        Try
            Dim q As String = String.Empty
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BLNomCon'"
            credenciales("BLNomCon") = ejecutarSqlite(q, tipoProceso.Scalar)
            'MODIFICACIONES HATCH 2024-06-05
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BLServid'"
            credenciales("BLServid") = ejecutarSqlite(q, tipoProceso.Scalar)
            'credenciales("BLServid") = "TINAJONES"
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BLUsuari'"
            credenciales("BLUsuari") = ejecutarSqlite(q, tipoProceso.Scalar)
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BLPasswo'"
            credenciales("BLPasswo") = ejecutarSqlite(q, tipoProceso.Scalar)
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BLNomBas'"
            credenciales("BLNomBas") = ejecutarSqlite(q, tipoProceso.Scalar)

            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BENomCon'"
            credenciales("BENomCon") = ejecutarSqlite(q, tipoProceso.Scalar)
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BEServid'"
            credenciales("BEServid") = ejecutarSqlite(q, tipoProceso.Scalar)
            'credenciales("BEServid") = "TINAJONES"
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BEUsuari'"
            credenciales("BEUsuari") = ejecutarSqlite(q, tipoProceso.Scalar)
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BEPasswo'"
            credenciales("BEPasswo") = ejecutarSqlite(q, tipoProceso.Scalar)
            q = "SELECT Valor FROM SqliteConfiguracion WHERE Clave='BENomBas'"
            credenciales("BENomBas") = ejecutarSqlite(q, tipoProceso.Scalar)

        Catch
        End Try
    End Sub

    'Public Shared Function execValidarUsuario(ByVal Base, ByVal Usuario, ByVal Clave) As Boolean
    '    If Usuario = "" And Clave = "" Then
    '        Return setearPermisos("")
    '    Else
    '        'EJECUTAR STORE PROCEDURE
    '        Dim parametros(1) As SqlParameter
    '        parametros(0) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
    '        parametros(0).Value = CType(Usuario, String)
    '        parametros(1) = New SqlClient.SqlParameter("@Clave", SqlDbType.VarChar)
    '        parametros(1).Value = CType(Clave, String)
    '        Resultado = EjecutarProcedure(Base,
    '                                      "spValidarUsuario",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        If Resultado.Rows.Count = 1 Then
    '            permisosUsuario = Resultado.Rows(0).Item(0).ToString
    '            Return setearPermisos(permisosUsuario)
    '        End If
    '        Return False
    '    End If
    'End Function

    'Public Shared Function execConsultarUsuario(ByVal Base, ByVal Dni) As DataTable
    '    'EJECUTAR STORE PROCEDURE
    '    'Declara variable tipo SQLPARAMETER que se enviará para el SP
    '    Dim parametros(0) As SqlParameter
    '    'SETEA EL NOMBRE Y TIPO DE DATO DE ESTE PARAMETRO
    '    parametros(0) = New SqlClient.SqlParameter("@Dni", SqlDbType.VarChar)
    '    'ASIGNA EL VALOR Y TIPO DE DATO DEL VALOR
    '    parametros(0).Value = CType(Dni, String)
    '    Dim Resultado As DataTable
    '    'EJECUTAR FUNCION, EL VALOR INT=3 EQUIVALE AL TIPO DE PROCESAMIENTO
    '    Resultado = EjecutarProcedure(Base,
    '                                  "spConsultarUsuario",
    '                                  parametros,
    '                                  3,
    '                                  False)
    '    'If Resultado.Rows.Count = 1 Then
    '    '    permisosUsuario = Resultado.Rows(0).Item(0).ToString
    '    '    Return setearPermisos(permisosUsuario)
    '    'End If
    '    'Return New DataTable
    '    Return Resultado
    'End Function

    Public Shared Function setearPermisos(ByVal permisos As String)
        If permisos = "" Then

            'modulos.Add("Archivo", False)
            'modulos.Add("Editar", False)
            'modulos.Add("Ver", False)
            'modulos.Add("Herramientas", False)
            'modulos.Add("Ventanas", False)
            'modulos.Add("Ayuda", False)
            'modulos.Add("Mantenimiento", True)
            'For Each kvp As KeyValuePair(Of String, Boolean) In modulos
            '    'Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value)

            'Next
            Return True
        Else

            'permisos = OctaBin(permisos, True)
            permisos = traducePermisos(permisos, True)
            'modulos.Add("Archivo", permisos.ElementAt(0) = "1")
            'modulos.Add("Editar", permisos.ElementAt(1) = "1")
            'modulos.Add("Ver", permisos.ElementAt(2) = "1")
            'modulos.Add("Herramientas", permisos.ElementAt(3) = "1")
            'modulos.Add("Ventanas", permisos.ElementAt(4) = "1")
            'modulos.Add("Ayuda", permisos.ElementAt(5) = "1")
            'modulos.Add("Mantenimiento", permisos.ElementAt(6) = "1")
            Dim i As Integer = 0
            Dim aux As New Dictionary(Of String, Boolean)
            'RECORRE DICCIONARIO PARA SETEAR VALORES
            For Each j As KeyValuePair(Of String, Boolean) In modulosPermitidos
                'If permisos.Count() <= i Then
                aux.Add((j.Key), permisos.ElementAt(i) = "1")
                i = i + 1
                'End If
            Next j
            modulosPermitidos = aux
            Return True
        End If
        Return False
    End Function

    Public Shared Function hashMd5(ByVal cadena As String)
        If cadena.Length > 0 Then
            Using md5Hash As MD5 = MD5.Create()
                Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena))
                Dim sBuilder As New StringBuilder()
                Dim i As Integer
                For i = 0 To data.Length - 1
                    sBuilder.Append(data(i).ToString("x2"))
                Next i
                Return sBuilder.ToString()
            End Using
        Else
            Return ""
        End If
    End Function

    Public Shared Function hashMd5Otra(ByVal cadena As String)
        If cadena.Length > 0 Then
            Try
                Dim md As MD5 = MD5.Create()
                Dim inputBytes As Byte() = Encoding.ASCII.GetBytes(cadena)
                Dim hashBytes As Byte() = md.ComputeHash(inputBytes)
                Dim sb As StringBuilder = New StringBuilder()

                For i As Integer = 0 To hashBytes.Length - 1
                    sb.Append(hashBytes(i).ToString("X2"))
                Next

                Return sb.ToString()
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            End Try
        Else
            Return ""
        End If
    End Function

    Public Shared Function traducePermisos(ByVal cadena As String, ByVal direccion As Boolean)
        Dim aux As String = ""
        Dim largo As Integer = cadena.Length
        If direccion Then
            For i As Integer = 0 To largo - 1 Step 1
                aux = aux + htg2Bin(cadena.ElementAt(i).ToString)
            Next
            If aux.Length < modulosPermitidos.Count Then
                aux = String.Concat(aux, StrDup(modulosPermitidos.Count - aux.Length, "0"))
            End If
            Return aux
        Else
            If largo Mod 5 > 0 Then
                cadena = cadena + StrDup(5 - (largo Mod 5), "0")
            End If
            For i As Integer = 0 To (cadena.Length / 5) - 1 Step 1
                aux = aux + bin2Htg(cadena.Substring(i * 5, 5))
            Next
            Return aux
        End If
    End Function

    Public Shared Function OctaBin(ByVal cadena As String, ByVal tipo As Boolean)
        'si tipo=true convierte de octal a binario, y al reves
        Dim resultado As String = "", aux As String = ""
        Dim largo As Integer = cadena.Length
        Dim ceros As Integer = 3 - (largo Mod 3)
        If tipo Then
            'For i As Integer = 0 To largo - 1
            '    aux = cadena.ElementAt(i)
            '    resultado = resultado + Convert.ToString(Convert.ToInt32(aux, 8), 2)
            'Next
            For i As Integer = 0 To largo - 1 Step 1
                aux = aux + Dec2Bin(cadena.ElementAt(i).ToString)
            Next
            'nTotalModulos = modulosPermitidos.Count
            If aux.Length < modulosPermitidos.Count Then
                aux = String.Concat(aux, StrDup(modulosPermitidos.Count - aux.Length, "0"))
            End If
            Return aux 'Dec2Bin(Convert.ToString(cadena))
        Else
            For i As Integer = 0 To Math.Ceiling(largo / 3) - 1 Step 1
                'si la cadena es menor que 3 rellenar con ceros a la derecha
                If ceros <> 3 Then
                    For k As Integer = 1 To ceros Step 1
                        cadena = cadena + "0"
                    Next
                End If
                resultado = resultado + Bin2Dec(cadena.Substring(i * 3, 3)).ToString
            Next
            Return resultado
        End If
        Return resultado
    End Function

    'Public Shared Function validarConfiguracion()
    '    'If Not validarArchivos(rutaGeneral + rutaDataBase, archivoBDE) Then
    '    '    Return False
    '    'ElseIf Not validarArchivos(rutaGeneral + rutaDataNueva, archivoRME) Then
    '    '    Return False
    '    'ElseIf Not validarArchivos(rutaGeneral + rutaImageBase, archivoJPG) Then
    '    '    Return False
    '    If Not validarArchivos(rutaGeneral + rutaTemp) Then
    '        Return False
    '    ElseIf Not validarArchivos(rutaGeneral, archivoConf) Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function


    'Public Shared Function validarArchivos(ByVal ruta As String, Optional ByVal archivo As String = "")
    '    Try
    '        If File.Exists(ruta + archivo) Then
    '            Return True
    '        ElseIf Not Directory.Exists(ruta) Then
    '            Directory.CreateDirectory(ruta)
    '        End If
    '        If Not archivo.Equals("") Then
    '            Dim Arch As New IO.StreamWriter(ruta + archivo, False, System.Text.Encoding.Unicode)
    '            Arch.Close()
    '            'cifrar(ruta + archivo, True)

    '            'cifrar(ruta + archivo, False)
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        'mensaje = {"No se pueden crear Archivos de Registro", "error"}
    '        Return False
    '    End Try
    'End Function

    'Public Shared Function cargarConfig()
    '    Try
    '        cifrar(rutaGeneral + archivoConf, False)
    '        Dim leer As New StreamReader(rutaGeneral + archivoConf, System.Text.Encoding.Unicode)
    '        Dim c As Char
    '        Dim i As Integer = -1, j As Integer = 0
    '        Dim config = {"", "", "", "", ""}
    '        While leer.Peek() > -1
    '            c = Chr(leer.Read())
    '            If Asc(c) <> Asc("!") Then
    '                If Asc(c) <> Asc("#") Then
    '                    config(i) = config(i) + c
    '                Else
    '                    i = i + 1
    '                End If
    '            Else
    '                If j = 0 And i > 2 Then
    '                    credenciales("BLNomCon") = config(0)
    '                    credenciales("BLServid") = config(1)
    '                    credenciales("BLUsuari") = config(2)
    '                    credenciales("BLPasswo") = config(3)
    '                    credenciales("BLNomBas") = config(4)
    '                    j = 1
    '                    i = -1
    '                    config = {"", "", "", "", ""}
    '                ElseIf j = 1 Then
    '                    credenciales("BENomCon") = config(0)
    '                    credenciales("BEServid") = config(1)
    '                    credenciales("BEUsuari") = config(2)
    '                    credenciales("BEPasswo") = config(3)
    '                    credenciales("BENomBas") = config(4)
    '                    leer.Close()
    '                    cifrar(rutaGeneral + archivoConf, True)
    '                    Return True
    '                End If
    '            End If
    '            'config = {"", "", "", "", ""}
    '            'i = 0
    '            'End If
    '        End While
    '        leer.Close()
    '        'mensaje = {"Empleado no registrado", "error"}
    '        cifrar(rutaGeneral + archivoConf, True)
    '        Return False
    '    Catch ex As Exception
    '        'leer.Close()
    '        'mensaje = {"Error de lectura de archivo", "error"}
    '        cifrar(rutaGeneral + archivoConf, True)
    '        Return False
    '    End Try
    'End Function

    Public Shared Function htg2Bin(c As String) 'HexaTriGesimal A Binario
        Dim secuencia As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B",
                                 "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                                 "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Dim num As Integer = Array.IndexOf(secuencia, c)
        Dim aux As String = Convert.ToString(num, 2)
        aux = aux.PadLeft(5, "0")
        Return aux
    End Function

    Public Shared Function bin2Htg(c As String) 'Binario A HexaTriGesimal (recibe cadena de longitud 6)
        Dim n As Integer, a As Integer, x As String = ""
        Dim indice As Integer
        n = Len(c) - 1
        a = n
        Do While n > -1
            x = Mid(c, ((a + 1) - n), 1)
            indice = IIf((x = "1"), indice + (2 ^ (n)), indice)
            n = n - 1
        Loop
        Dim secuencia As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B",
                                 "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                                 "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Return secuencia(indice)
    End Function

    Public Shared Function Bin2Dec(Num As String)
        Dim n As Integer, a As Integer, x As String = ""
        Dim resultado As Integer
        n = Len(Num) - 1
        a = n
        Do While n > -1
            x = Mid(Num, ((a + 1) - n), 1)
            resultado = IIf((x = "1"), resultado + (2 ^ (n)), resultado)
            n = n - 1
        Loop
        Return resultado
    End Function

    Public Shared Function Dec2Bin(Num As Integer)
        Dim largo As Integer = Num.ToString.Length
        Dim aux As String = "", resultado As String = ""
        For i As Integer = 0 To largo - 1
            aux = Num.ToString.ElementAt(i)
            resultado = resultado + Convert.ToString(Convert.ToInt32(aux, 8), 2)
        Next
        If resultado.Length = 1 Then
            resultado = "00" + resultado
        ElseIf resultado.Length = 2 Then
            resultado = "0" + resultado
        End If
        'ARREGLO PARA NO TENER PROBLEMAS CON MODULOS FALTANTES
        Return resultado
    End Function


    'Public Shared Function execGuardarUsuario(ByVal dni As String, ByVal usuario As String, ByVal clave As String, ByVal permisos As String, ByVal estado As Boolean)
    '    'EJECUTAR STORE PROCEDURE
    '    'Declara variable tipo SQLPARAMETER que se enviará para el SP
    '    Dim parametros(4) As SqlParameter
    '    'SETEA EL NOMBRE Y TIPO DE DATO DE ESTE PARAMETRO
    '    parametros(0) = New SqlClient.SqlParameter("@Dni", SqlDbType.VarChar)
    '    parametros(0).Value = CType(dni, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
    '    parametros(1).Value = CType(usuario, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Clave", SqlDbType.VarChar)
    '    parametros(2).Value = CType(clave, String)
    '    parametros(3) = New SqlClient.SqlParameter("@Permisos", SqlDbType.VarChar)
    '    parametros(3).Value = CType(permisos, String)
    '    parametros(4) = New SqlClient.SqlParameter("@Estado", SqlDbType.Bit)
    '    parametros(4).Value = CType(estado, Boolean)

    '    'Dim Resultado As DataTable
    '    'EJECUTAR FUNCION, EL VALOR INT=3 EQUIVALE AL TIPO DE PROCESAMIENTO
    '    'Resultado =
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                  "spGuardarUsuario",
    '                                  parametros,
    '                                  3,
    '                                  False)
    '        Return True
    '    Catch
    '        Return False
    '    End Try
    'End Function

    'Public Shared Function execCambiarClave(dni As String, clave As String)
    '    Dim parametros(1) As SqlParameter
    '    'SETEA EL NOMBRE Y TIPO DE DATO DE ESTE PARAMETRO
    '    parametros(0) = New SqlClient.SqlParameter("@Dni", SqlDbType.VarChar)
    '    parametros(0).Value = CType(dni, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Clave", SqlDbType.VarChar)
    '    parametros(1).Value = CType(hashMd5(clave), String)
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                  "spCambiarClave",
    '                                  parametros,
    '                                  3,
    '                                  False)
    '        Return True
    '    Catch
    '        Return False
    '    End Try
    'End Function

    'Public Shared Function execUltimoDiaAsistencia(ByVal coddni As String, ByVal planillas As String)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@CodDni", SqlDbType.VarChar)
    '    parametros(0).Value = CType(coddni, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Planillas", SqlDbType.VarChar)
    '    parametros(1).Value = CType(planillas, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "spUltimoDiaAsistencia",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'execRrhhAsisRpteFaltas
    'Public Shared Function execRrhhAsisRpteFaltas(fuente As String, tipoReporte As String, personas As String, incJust As Boolean)
    '    '@Fuente		varchar(10), --VALORES 'TABLETS' O ' NISIRA'
    '    '@TipoReporte	varchar(21), --VALORES 'TODAS',[FECHAS] DE LONGITUD 21, O NUMERO DE DIAS
    '    '@Personas		varchar(25),  --VALORES 'TODOS', COD[CODIGO], COD[LISTA DE PLANILLAS SEPARADOS POR COMA]
    '    '@IncluirJustificaciones BIT  --VALORES 1/0
    '    Dim parametros(3) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Fuente", SqlDbType.VarChar)
    '    parametros(0).Value = CType(fuente, String)
    '    parametros(1) = New SqlClient.SqlParameter("@TipoReporte", SqlDbType.VarChar)
    '    parametros(1).Value = CType(tipoReporte, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Personas", SqlDbType.VarChar)
    '    parametros(2).Value = CType(personas, String)
    '    parametros(3) = New SqlClient.SqlParameter("@IncluirJustificaciones", SqlDbType.VarChar)
    '    parametros(3).Value = CType(incJust, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "spRrhhRpteFaltas",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    Public Shared Function obtenerCadenaParametros(p As Dictionary(Of String, Object)) As String
        Try
            Dim aux As String = "Parametros:"
            If p IsNot Nothing Then
                For Each parametro As KeyValuePair(Of String, Object) In p
                    If parametro.Key IsNot Nothing And parametro.Value IsNot Nothing Then
                        aux = aux + " " + parametro.Key.ToString + ":[" + parametro.Value.ToString + "]"
                    End If
                Next
            End If
            Return aux
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    'Public Shared Function execRrhhReporteAsistencia(desde As String, hasta As String)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Fechaini", SqlDbType.Date)
    '    parametros(0).Value = CType(desde, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Fechafin", SqlDbType.Date)
    '    parametros(1).Value = CType(hasta, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "spReporteAsistencia",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execRrhhReporteAsistenciaChronos(desde As String, hasta As String, tipo As String)
    '    Dim parametros(2) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Desde", SqlDbType.Date)
    '    parametros(0).Value = CType(desde, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Hasta", SqlDbType.Date)
    '    parametros(1).Value = CType(hasta, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Tipo", SqlDbType.VarChar)
    '    parametros(2).Value = CType(tipo, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Cns_ReporteAsistencia",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execFitosanidad_RepAplicaciones(desde As String, hasta As String, horasm As Boolean)
    '    Dim parametros(2) As SqlParameter
    '    'parametros(0) = New SqlClient.SqlParameter("@CodEmpresa", SqlDbType.VarChar)
    '    'parametros(0).Value = CType(empresa, String)
    '    parametros(0) = New SqlClient.SqlParameter("@Desde", SqlDbType.Date)
    '    parametros(0).Value = CType(desde, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Hasta", SqlDbType.Date)
    '    parametros(1).Value = CType(hasta, String)
    '    parametros(2) = New SqlClient.SqlParameter("@HorasMaquina", SqlDbType.Bit)
    '    parametros(2).Value = CType(horasm, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_FitoSanidad_ReporteAplicaciones",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'NO BORRAR AUN
    'Public Shared Function exportar(dGV As Object, titulo As String, subtitulo As String) As Boolean
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
    '    Try
    '        exLibro = exApp.Workbooks.Add
    '        exHoja = exLibro.Worksheets.Add()
    '        Dim NCol As Integer = dGV.ColumnCount
    '        Dim NRow As Integer = dGV.RowCount


    '        '#####################MODIFICAR PROCEDIMIENTOS ALMACENADOS PARA QUE DEVUELVA NOMBRE DE COLUMNA CON LETRA DEL TIPO
    '        exHoja.Cells.Font.Color = colTextoTabla
    '        '//Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '        For i As Integer = 1 To NCol
    '            'exHoja.Cells.Item(1, i + 1) = dGV.Columns(i - 1).Name.ToString

    '            exHoja.Cells.Item(1, i) = dGV.Columns(i - 1).Name.ToString
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoCabecera
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '            Dim celda As String = dGV.Columns(i - 1).Name.ToString
    '            If celda.Substring(0, 2) = "F_" Then
    '                exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '                exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            ElseIf celda.Substring(0, 2) = "T_" Then
    '                exHoja.Columns(i).NumberFormat = "@"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            End If
    '            'exHoja.Columns.Range("A:B").NumberFormat = "@"
    '        Next
    '        'exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(1, NCol)).Interior.Color = colFondoCabecera
    '        'exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(1, NCol)).Font.Color = colTextoCabecera
    '        'Fori as integer =1
    '        '//Formatea las columnas para no perder informacion que empiece en 0
    '        'exHoja.Columns.Range("A:B").NumberFormat = "@"
    '        'exHoja.Columns.Range("G:M").NumberFormat = "dd-mm-yyyy" 'MM = month, mm=minutos, SE DEBE USAR MM

    '        '//Copiar y pega toda la tabla datagridview al excel
    '        dGV.SelectAll()
    '        Dim dataObj As Object = dGV.GetClipboardContent()
    '        If Not dataObj Is Nothing Then
    '            Clipboard.SetDataObject(dataObj)
    '        End If
    '        exHoja.PasteSpecial(exHoja.Cells(2, 1).select(),
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            True)
    '        GC.Collect()
    '        'exHoja.Cells.Select()
    '        exHoja.Cells.Font.Name() = fuente1
    '        exHoja.Cells.Font.Size = 8
    '        'exHoja.Cells.Range(exHoja.Cells(2, 1), exHoja.Cells(NRow, NCol)).Font.Color = colTextoTabla
    '        'exHoja.Cells.Range("A1:M1").Interior.Color = colFondoCabecera
    '        'exHoja.Cells.Range("A1:M1").Font.Color = colTextoCabecera
    '        exHoja.Rows.Item(1).Font.Bold = 1
    '        exHoja.Rows.Item(1).HorizontalAlignment = 3
    '        exHoja.Columns.AutoFit()
    '        Dim ultFil, ultCol As Integer
    '        ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '        ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '        'alinea al centro#############################################################################
    '        'exHoja.Columns.Range("G:M").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '        exHoja.Rows.AutoFit()

    '        'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '        With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '            .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            .Color = RGB(130, 130, 130)
    '        End With
    '        With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '            .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            '.Weight = xlNone
    '            '.Color = RGB(130, 130, 130)
    '        End With

    '        'INSERTAR TITULO Y FECHA DE CONSULTA DE REPORTE:
    '        'exHoja.Cells.selectRange("1:1").Select()
    '        'exHoja.Rows.Item(1).select()
    '        'exHoja.Rows.Insert() 'Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown
    '        'ActiveCell.EntireRow.Select()
    '        'exHoja.Selection.Insert() 'Shift : xlToDown()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        'exHoja.Cells(2, 1).select()
    '        exHoja.Cells(1, 1).value = titulo
    '        exHoja.Cells(2, 1).value = subtitulo
    '        'Mostrar documento
    '        exHoja.Cells(1, 1).select()
    '        exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '        exApp.Application.Visible = True
    '        exHoja = Nothing
    '        exLibro = Nothing
    '        exApp = Nothing
    '        GC.Collect()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '        Return False
    '    End Try
    '    Return True
    'End Function


    'ULTIMA VERSION, FUNCION OK PERO SE REALIZA MEJORA PARA AGRUPAMIENTO DE CABECERAS
    'Public Shared Function exportarExcel(dGV As DataGridView, NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean
    '    Dim y As Integer = 2, x As Integer = 1
    '    dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
    '    Try
    '        exLibro = exApp.Workbooks.Add

    '        exHoja = exLibro.Sheets(1)
    '        Dim NCol As Integer = dGV.ColumnCount
    '        Dim NRow As Integer = dGV.RowCount

    '        exHoja.Cells.Font.Color = colTextoTabla
    '        'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '        Dim j As Integer = dGV.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index

    '        '#Jota-2021-06-10: agregado para exportar solo columnas visibles
    '        Dim VisColCount As Integer = 1
    '        For Each col As DataGridViewColumn In dGV.Columns
    '            If col.Visible = True Then
    '                VisColCount += 1
    '            End If
    '        Next

    '        'FORMATO GENERAL DE CELDAS
    '        exHoja.Cells.Font.Name = fuenteTablaReporte
    '        exHoja.Cells.Font.Size = 8
    '        exHoja.Cells.Font.Color = colTextoTabla
    '        exHoja.Rows.Item(1).Font.Bold = 1
    '        exHoja.Rows.Item(1).HorizontalAlignment = 3

    '        'CREAR CABECERAS SEGUN NOMBRE DE COLUMNAS DEL REPORTE
    '        For i As Integer = 1 To VisColCount - 1 'NCol
    '            Dim celda As String = dGV.Columns(j).Name.ToString
    '            'exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoCabecera
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Name = fuenteCabeceraTablaReporte
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Size = 10

    '            If celda.Substring(0, 2) = "F_" Then
    '                exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '                exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            ElseIf celda.Substring(0, 2) = "T_" Then
    '                exHoja.Columns(i).NumberFormat = "@"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '                'ElseIf celda.Substring(0, 2) = "D_" Then
    '                '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                '    exHoja.Cells(1, i) = celda.Substring(2)
    '            ElseIf celda.Substring(0, 2) = "H1" Then
    '                exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            ElseIf celda.Substring(0, 1) = "P" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                exHoja.Columns(i).NumberFormat = "0." + StrDup(ceros, "0") + "%"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            Else
    '                exHoja.Cells(1, i) = celda
    '            End If
    '            If i < NCol Then
    '                j = dGV.Columns.GetNextColumn(dGV.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '            End If
    '        Next

    '        exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders.Color = colBordeTabla
    '        exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(1, VisColCount - 1)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
    '        exHoja.Cells.Range(exHoja.Cells(2, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Interior.Color = RGB(255, 255, 255)



    '        '//Copiar y pega toda la tabla datagridview al excel
    '        'Clipboard.Clear()
    '        'dGV.SelectAll()
    '        'Dim dataObj As Object = dGV.GetClipboardContent()
    '        'If Not dataObj Is Nothing Then
    '        '    Clipboard.SetDataObject(dataObj)
    '        'End If
    '        'exHoja.PasteSpecial(exHoja.Cells(2, 1).select(),
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    True)
    '        ''otro metodo de pegado
    '        ''HojaExcel.Range("A1").Select()
    '        ''HojaExcel.ActiveSheet.Paste()
    '        'GC.Collect()

    '        'MODIFICACION PARA EXPORTAR REGISTROS COPIANDO Y PEGANDO DE A POCOS PARA REGISTROS CON FILAS MAYORES A: agrupadorFilasExcel
    '        Dim maxX As Long = dGV.Rows.Count
    '        For iY As Long = 0 To maxX - 1 Step 1
    '            dGV.ClearSelection()
    '            Clipboard.Clear()
    '            For iiY As Long = iY To iY + agrupadorFilasExcel - 1 And iiY < maxX Step 1
    '                If iiY < maxX Then
    '                    dGV.Rows(iiY).Selected = True
    '                End If
    '            Next
    '            Dim dataObj As Object = dGV.GetClipboardContent()
    '            If Not dataObj Is Nothing Then
    '                Clipboard.SetDataObject(dataObj)
    '            End If
    '            'System.Threading.Thread.Sleep(100)
    '            exHoja.PasteSpecial(exHoja.Cells(y + iY, x).select(), 'VALIDAR AQUI SUMANDO VALORES ALEATORIOS PARA ASEGURAR
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                True)
    '            GC.Collect()
    '            iY += agrupadorFilasExcel - 1
    '        Next

    '        'ESTILO GENERAL DE LA HJA
    '        'exHoja.Cells.Font.Name() = fuenteTablaReporte
    '        'exHoja.Cells.Font.Size = 8
    '        'exHoja.Rows.Item(1).Font.Bold = 1
    '        'exHoja.Rows.Item(1).HorizontalAlignment = 3
    '        'exHoja.Columns.AutoFit()
    '        Dim ultFil, ultCol As Integer
    '        ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '        ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '        'alinea al centro#############################################################################
    '        'exHoja.Rows.AutoFit()
    '        exHoja.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).EntireColumn.AutoFit()
    '        'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '        'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        '    .Color = colBordeTabla 'RGB(130, 130, 130)
    '        'End With
    '        'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        '    '.Weight = xlNone
    '        '    '.Color = RGB(130, 130, 130)
    '        'End With


    '        'Modificacion para agrupacion de campos por nombre de columna
    '        'If ColumnaAgrupada > 0 Then
    '        '    Dim alternadorColores As Boolean = False
    '        '    Dim valorCelda As String = exHoja.Cells(2, ColumnaAgrupada).Value
    '        '    Dim nuevoValorCelda As String = String.Empty
    '        '    Dim h As Integer = 2
    '        '    For i As Integer = 2 To ultFil + 1 Step 1
    '        '        nuevoValorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '        '        If valorCelda <> nuevoValorCelda Then
    '        '            If alternadorColores Then
    '        '                exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '        '            Else
    '        '                exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '        '            End If
    '        '            'With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '        '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '        '            '    .Color = RGB(89, 89, 89)
    '        '            'End With
    '        '            h = i
    '        '            valorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '        '            alternadorColores = Not alternadorColores
    '        '        End If
    '        '    Next
    '        'End If


    '        'AGREGADO PARA METADATOS DE REPORTE:
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()

    '        exHoja.Cells(1, 1).value = "Aplicativo:"
    '        exHoja.Cells(2, 1).value = "Reporte:"
    '        exHoja.Cells(3, 1).value = "Usuario:"
    '        exHoja.Cells(4, 1).value = "Consulta:"
    '        exHoja.Cells(5, 1).value = "Parametros:"

    '        'CONTINUAR AQUI:
    '        exHoja.Cells(1, 2).value = "[" + Aplicativo + "]"
    '        exHoja.Cells(2, 2).value = "[" + NombreFormulario + "]"
    '        exHoja.Cells(3, 2).value = "[" + usuarioActual + "]"
    '        exHoja.Cells(4, 2).value = "[" + Now.ToString + "]"
    '        exHoja.Cells(5, 2).value = "[" + CadenaParametros + "]"

    '        exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
    '        exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
    '        exHoja.Range("A1", "B5").Font.Bold = 1

    '        exHoja.Columns(1).EntireColumn.Insert()

    '        'Mostrar documento
    '        exHoja.Cells(1, 1).select()
    '        exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '        exApp.Application.Visible = True
    '        exHoja = Nothing
    '        exLibro = Nothing
    '        exApp = Nothing
    '        GC.Collect()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '        Return False
    '    Finally
    '        'dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        GC.Collect()
    '        Clipboard.Clear()
    '    End Try
    '    Return True
    'End Function

    'PROTOTIPO DE FUNCION DE EXPORTACION
    'Public Shared Function exportarExcel(dGV As DataGridView, NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean
    '    dGV.SelectionMode = DataGridViewSelectionMode.CellSelect
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
    '    Try
    '        exLibro = exApp.Workbooks.Add

    '        exHoja = exLibro.Sheets(1)
    '        Dim NCol As Integer = dGV.ColumnCount
    '        Dim NRow As Integer = dGV.RowCount

    '        exHoja.Cells.Font.Color = colTextoTabla
    '        'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '        Dim j As Integer = dGV.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index

    '        '#Jota-2021-06-10: agregado para exportar solo columnas visibles
    '        Dim nColVisibles As Integer = 0
    '        For Each col As DataGridViewColumn In dGV.Columns
    '            If col.Visible = True Then
    '                nColVisibles += 1
    '            End If
    '        Next

    '        'FORMATO GENERAL DE CELDAS
    '        exHoja.Cells.Font.Name = fuenteTablaReporte
    '        exHoja.Cells.Font.Size = 8
    '        exHoja.Cells.Font.Color = colTextoTabla
    '        exHoja.Rows.Item(1).Font.Bold = 1
    '        exHoja.Rows.Item(1).HorizontalAlignment = 3

    '        Dim niveles As Integer = 1, x As Integer = 1, y As Integer = 1
    '        For i As Integer = 0 To nColVisibles - 1  'NCol
    '            Dim celda As String = dGV.Columns(i).Name.ToString
    '            exHoja.Cells(y, x + i) = celda
    '            niveles = calcularMaximoNivelAgrupamiento(celda, niveles)
    '            'j = dGV.Columns.GetNextColumn(dGV.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '        Next

    '        'exHoja.Rows(0 ).EntireRow.Insert()

    '        Dim ultFil, ultCol As Integer
    '        ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '        ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column

    '        If niveles > 1 Then
    '            For i As Integer = 1 To niveles - 1 Step 1
    '                exHoja.Rows(y - 1 + i).EntireRow.Insert()
    '                'y += 1
    '            Next
    '            y += niveles - 1
    '            Dim arrayNiveles As String()
    '            For i As Integer = 1 To nColVisibles - 1  'NCol
    '                arrayNiveles = exHoja.Cells(y, i)
    '                If arrayNiveles.Count > 1 Then
    '                    Dim c As Integer = arrayNiveles.Count
    '                    For c As Integer = arrayNiveles.Count To 0 Step -1
    '                        exHoja.Cells(y, i) = arrayNiveles(c - 1)
    '                    Next
    '                End If
    '            Next
    '        End If


    '        'Clipboard.Clear()
    '        'dGV.SelectAll()
    '        'Dim dataObj As Object = dGV.GetClipboardContent()
    '        'If Not dataObj Is Nothing Then
    '        '    Clipboard.SetDataObject(dataObj)
    '        'End If
    '        'exHoja.PasteSpecial(exHoja.Cells(2, 1).select(),
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    True)
    '        'GC.Collect()


    '        ''MODIFICACION PARA AGRUPAMIENTO DE CABECERAS DE COLUMNA
    '        'Dim niveles As Integer = 1, x As Integer = 1, y As Integer = 7
    '        ''PARA EL EXCEL "X" VA EN LAS ACSISAS Y "Y" EN LAS ORDENADAS -> PROPIEDAD CELLS(Y,X)
    '        'For i As Integer = 1 To nColVisibles - 1  'NCol
    '        '    Dim celda As String = dGV.Columns(j).Name.ToString
    '        '    exHoja.Cells(y, x + i - 1) = celda
    '        '    niveles = calcularMaximoNivelAgrupamiento(celda, niveles)
    '        '    j = dGV.Columns.GetNextColumn(dGV.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '        'Next

    '        ''SI HAY MAS DE UN NIVEL PARA AGRUPAR:
    '        'If niveles > 1 Then
    '        '    For i As Integer = 1 To niveles - 1 Step 1
    '        '        exHoja.Rows(y + i - 1).EntireRow.Insert()
    '        '    Next
    '        '    Dim arrayNiveles As String()
    '        '    For i As Integer = 1 To nColVisibles - 1  'NCol
    '        '        arrayNiveles = dGV.Columns(i - 1).Name.ToString.Split("|") 'exHoja.Cells(y + niveles - 1, x + i - 1).ToString.Split("|") 'partirNiveles(exHoja.Cells(y + niveles - 1, x + i - 1))
    '        '        'If arrayNiveles.Count > 1 Then
    '        '        'arrayNiveles = arrayNiveles.Reverse
    '        '        For h As Integer = arrayNiveles.Count To 1 Step -1
    '        '            exHoja.Cells(y + arrayNiveles.Count - 1, x + i - 1) = arrayNiveles(h - 1)
    '        '        Next
    '        '        'End If
    '        '    Next
    '        '    'For h As Integer = y + niveles - 1 To y Step -1
    '        '    '    For i As Integer = 1 To nColVisibles - 1  'NCol
    '        '    '        arrayNiveles = partirNiveles(exHoja.Cells(y - h + 1, x + i - 1))
    '        '    '        exHoja.Cells(h, x + i - 1) = arrayNiveles(0)
    '        '    '        exHoja.Cells(h - 1, x + i - 1) = arrayNiveles(1)
    '        '    '    Next
    '        '    'Next
    '        'End If


    '        ''CREAR CABECERAS SEGUN NOMBRE DE COLUMNAS DEL REPORTE
    '        ''For i As Integer = 1 To nColVisibles - 1  'NCol
    '        ''    Dim celda As String = dGV.Columns(j).Name.ToString
    '        ''    'exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoCabecera
    '        ''    exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '        ''    exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Name = fuenteCabeceraTablaReporte
    '        ''    exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Size = 10

    '        ''    If celda.Substring(0, 2) = "F_" Then
    '        ''        exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '        ''        exHoja.Cells(1, i) = celda.Substring(2)
    '        ''        exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '        ''    ElseIf celda.Substring(0, 2) = "T_" Then
    '        ''        exHoja.Columns(i).NumberFormat = "@"
    '        ''        exHoja.Cells(1, i) = celda.Substring(2)
    '        ''        'ElseIf celda.Substring(0, 2) = "D_" Then
    '        ''        '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '        ''        '    exHoja.Cells(1, i) = celda.Substring(2)
    '        ''    ElseIf celda.Substring(0, 2) = "H1" Then
    '        ''        exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '        ''        exHoja.Cells(1, i) = celda.Substring(2)
    '        ''    ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '        ''        Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '        ''        exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '        ''        exHoja.Cells(1, i) = celda.Substring(2)
    '        ''    ElseIf celda.Substring(0, 1) = "P" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '        ''        Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '        ''        exHoja.Columns(i).NumberFormat = "0." + StrDup(ceros, "0") + "%"
    '        ''        exHoja.Cells(1, i) = celda.Substring(2)
    '        ''    Else
    '        ''        exHoja.Cells(1, i) = celda
    '        ''    End If
    '        ''    If i < NCol Then
    '        ''        j = dGV.Columns.GetNextColumn(dGV.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '        ''    End If
    '        ''Next

    '        ''exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        ''exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).Borders.Color = colBordeTabla
    '        ''exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        ''exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        ''exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(1, nColVisibles - 1)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
    '        ''exHoja.Cells.Range(exHoja.Cells(2, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).Interior.Color = RGB(255, 255, 255)



    '        ''//Copiar y pega toda la tabla datagridview al excel
    '        'Clipboard.Clear()
    '        'dGV.SelectAll()
    '        'Dim dataObj As Object = dGV.GetClipboardContent()
    '        'If Not dataObj Is Nothing Then
    '        '    Clipboard.SetDataObject(dataObj)
    '        'End If
    '        'exHoja.PasteSpecial(exHoja.Cells(y + niveles - 1, 1).select(),
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    Type.Missing,
    '        '                    True)
    '        ''otro metodo de pegado
    '        ''HojaExcel.Range("A1").Select()
    '        ''HojaExcel.ActiveSheet.Paste()
    '        'GC.Collect()

    '        ''ESTILO GENERAL DE LA HJA
    '        ''exHoja.Cells.Font.Name() = fuenteTablaReporte
    '        ''exHoja.Cells.Font.Size = 8
    '        ''exHoja.Rows.Item(1).Font.Bold = 1
    '        ''exHoja.Rows.Item(1).HorizontalAlignment = 3
    '        ''exHoja.Columns.AutoFit()
    '        'Dim ultFil, ultCol As Integer
    '        'ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '        'ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '        ''alinea al centro#############################################################################
    '        ''exHoja.Rows.AutoFit()
    '        'exHoja.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, nColVisibles - 1)).EntireColumn.AutoFit()
    '        ''SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '        ''With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '        ''    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        ''    .Color = colBordeTabla 'RGB(130, 130, 130)
    '        ''End With
    '        ''With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '        ''    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '        ''    '.Weight = xlNone
    '        ''    '.Color = RGB(130, 130, 130)
    '        ''End With


    '        ''Modificacion para agrupacion de campos por nombre de columna
    '        ''If ColumnaAgrupada > 0 Then
    '        ''    Dim alternadorColores As Boolean = False
    '        ''    Dim valorCelda As String = exHoja.Cells(2, ColumnaAgrupada).Value
    '        ''    Dim nuevoValorCelda As String = String.Empty
    '        ''    Dim h As Integer = 2
    '        ''    For i As Integer = 2 To ultFil + 1 Step 1
    '        ''        nuevoValorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '        ''        If valorCelda <> nuevoValorCelda Then
    '        ''            If alternadorColores Then
    '        ''                exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '        ''            Else
    '        ''                exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '        ''            End If
    '        ''            'With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '        ''            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '        ''            '    .Color = RGB(89, 89, 89)
    '        ''            'End With
    '        ''            h = i
    '        ''            valorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '        ''            alternadorColores = Not alternadorColores
    '        ''        End If
    '        ''    Next
    '        ''End If


    '        ' ''AGREGADO PARA METADATOS DE REPORTE:
    '        ''exHoja.Rows(1).EntireRow.Insert()
    '        ''exHoja.Rows(1).EntireRow.Insert()
    '        ''exHoja.Rows(1).EntireRow.Insert()
    '        ''exHoja.Rows(1).EntireRow.Insert()
    '        ''exHoja.Rows(1).EntireRow.Insert()
    '        ''exHoja.Rows(1).EntireRow.Insert()

    '        'exHoja.Cells(1, 1).value = "Aplicativo:"
    '        'exHoja.Cells(2, 1).value = "Reporte:"
    '        'exHoja.Cells(3, 1).value = "Usuario:"
    '        'exHoja.Cells(4, 1).value = "Consulta:"
    '        'exHoja.Cells(5, 1).value = "Parametros:"

    '        ''CONTINUAR AQUI:
    '        'exHoja.Cells(1, 2).value = "[" + Aplicativo + "]"
    '        'exHoja.Cells(2, 2).value = "[" + NombreFormulario + "]"
    '        'exHoja.Cells(3, 2).value = "[" + usuarioActual + "]"
    '        'exHoja.Cells(4, 2).value = "[" + Now.ToString + "]"
    '        'exHoja.Cells(5, 2).value = "[" + CadenaParametros + "]"

    '        'exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
    '        'exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
    '        'exHoja.Range("A1", "B5").Font.Bold = 1

    '        'INSERTAR COLUMNA EN BLANCO
    '        'exHoja.Columns(1).EntireColumn.Insert()

    '        'Mostrar documento
    '        exHoja.Cells(1, 1).select()
    '        exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '        exApp.Application.Visible = True
    '        exHoja = Nothing
    '        exLibro = Nothing
    '        exApp = Nothing
    '        GC.Collect()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '        Return False
    '    Finally
    '        dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        GC.Collect()
    '        Clipboard.Clear()
    '    End Try
    '    Return True
    'End Function



    'Public Shared Function exportarExcelAgrupado(dGV As DataGridView, titulo As String, subtitulo As String, columnaAgrupada As Integer) As Boolean
    '    dGV.SelectionMode = DataGridViewSelectionMode.CellSelect
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
    '    Try
    '        exLibro = exApp.Workbooks.Add
    '        'exHoja = exLibro.Worksheets.Add()
    '        exHoja = exLibro.Sheets(1)
    '        Dim NCol As Integer = dGV.ColumnCount
    '        Dim NRow As Integer = dGV.RowCount
    '        '#####################MODIFICAR PROCEDIMIENTOS ALMACENADOS PARA QUE DEVUELVA NOMBRE DE COLUMNA CON LETRA DEL TIPO
    '        exHoja.Cells.Font.Color = colTextoTabla
    '        'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '        Dim j As Integer = dGV.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
    '        For i As Integer = 1 To NCol
    '            Dim celda As String = dGV.Columns(j).Name.ToString
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoNuevaCabecera
    '            exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '            If celda.Substring(0, 2) = "F_" Then
    '                exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '                exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            ElseIf celda.Substring(0, 2) = "T_" Then
    '                exHoja.Columns(i).NumberFormat = "@"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '                'ElseIf celda.Substring(0, 2) = "D_" Then
    '                '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                '    exHoja.Cells(1, i) = celda.Substring(2)
    '            ElseIf celda.Substring(0, 2) = "H1" Then
    '                exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                exHoja.Cells(1, i) = celda.Substring(2)
    '            Else
    '                exHoja.Cells(1, i) = celda
    '            End If
    '            If i < NCol Then
    '                j = dGV.Columns.GetNextColumn(dGV.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '            End If
    '        Next
    '        '//Copiar y pega toda la tabla datagridview al excel
    '        dGV.SelectAll()
    '        Dim dataObj As Object = dGV.GetClipboardContent()
    '        If Not dataObj Is Nothing Then
    '            Clipboard.SetDataObject(dataObj)
    '        End If
    '        exHoja.PasteSpecial(exHoja.Cells(2, 1).select(),
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            Type.Missing,
    '                            True)
    '        'otro metodo de pegado
    '        'HojaExcel.Range("A1").Select()
    '        'HojaExcel.ActiveSheet.Paste()
    '        GC.Collect()
    '        exHoja.Cells.Font.Name() = fuenteTablaReporte
    '        exHoja.Cells.Font.Size = 8
    '        exHoja.Rows.Item(1).Font.Bold = 1
    '        exHoja.Rows.Item(1).HorizontalAlignment = 3
    '        exHoja.Columns.AutoFit()
    '        Dim ultFil, ultCol As Integer
    '        ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '        ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '        'alinea al centro#############################################################################
    '        exHoja.Rows.AutoFit()
    '        'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '        'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeRight And Excel.XlBordersIndex.xlEdgeBottom) '(ultFil, ultCol)).Borders()
    '        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        '    .Color = RGB(130, 130, 130)
    '        'End With
    '        With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '            .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            '.Weight = xlNone
    '            '.Color = RGB(130, 130, 130)
    '        End With

    '        'Modificacion para agrupacion de campos por nombre de columna
    '        Dim alternadorColores As Boolean = False
    '        Dim valorCelda As String = exHoja.Cells(2, columnaAgrupada).Value
    '        Dim nuevoValorCelda As String = String.Empty
    '        Dim h As Integer = 2
    '        For i As Integer = 2 To ultFil + 1 Step 1
    '            'h = i
    '            'valorCelda = exHoja.Cells(i, columnaAgrupada)
    '            nuevoValorCelda = exHoja.Cells(i, columnaAgrupada).Value
    '            If valorCelda <> nuevoValorCelda Then
    '                If alternadorColores Then
    '                    exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '                Else
    '                    exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '                End If
    '                With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '                    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '                    .Color = RGB(89, 89, 89)
    '                End With
    '                h = i
    '                valorCelda = exHoja.Cells(i, columnaAgrupada).Value
    '                alternadorColores = Not alternadorColores
    '            End If


    '        Next
    '        'FIN MODIFICACION

    '        'With exHoja.Columns.Range(exHoja.Cells(3, 1), exHoja.Cells(ultFil + 2, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeRight And Excel.XlBordersIndex.xlEdgeBottom And Excel.XlBordersIndex.xlEdgeLeft And Excel.XlBordersIndex.xlEdgeTop) '(ultFil, ultCol)).Borders()
    '        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '        '    .Color = RGB(130, 130, 130)
    '        'End With

    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Rows(1).EntireRow.Insert()
    '        exHoja.Cells(1, 1).value = titulo
    '        exHoja.Cells(2, 1).value = subtitulo
    '        'Mostrar documento
    '        exHoja.Cells(1, 1).select()
    '        exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '        exApp.Application.Visible = True
    '        exHoja = Nothing
    '        exLibro = Nothing
    '        exApp = Nothing
    '        GC.Collect()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '        Return False
    '    Finally
    '        dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function exportarVariosExcels(dDgvs As List(Of DataGridView), titulo As String, subtitulo As String) As Boolean
    '    'Try
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
    '    exLibro = exApp.Workbooks.Add
    '    Dim z As Integer = 1
    '    Dim nombreHoja As String
    '    For Each dgv As DataGridView In dDgvs
    '        Try
    '            If z <> 1 Then
    '                exLibro.Sheets.Add()
    '            End If
    '            'exHoja = exLibro.Worksheets.Add()
    '            nombreHoja = "Hoja" + z.ToString
    '            exHoja = exLibro.Sheets(nombreHoja)
    '            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
    '            Dim NCol As Integer = dgv.ColumnCount
    '            Dim NRow As Integer = dgv.RowCount
    '            '#####################MODIFICAR PROCEDIMIENTOS ALMACENADOS PARA QUE DEVUELVA NOMBRE DE COLUMNA CON LETRA DEL TIPO
    '            exHoja.Cells.Font.Color = colTextoTabla
    '            'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '            Dim j As Integer = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index
    '            For i As Integer = 1 To NCol
    '                Dim celda As String = dgv.Columns(j).Name.ToString
    '                exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoCabecera
    '                exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '                If celda.Substring(0, 2) = "F_" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '                ElseIf celda.Substring(0, 2) = "T_" Then
    '                    exHoja.Columns(i).NumberFormat = "@"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    'ElseIf celda.Substring(0, 2) = "D_" Then
    '                    '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                    '    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 2) = "H1" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                    Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                    exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                Else
    '                    exHoja.Cells(1, i) = celda
    '                End If
    '                If i < NCol Then
    '                    j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '                End If
    '            Next
    '            '//Copiar y pega toda la tabla datagridview al excel
    '            GC.Collect()
    '            dgv.SelectAll()
    '            Dim dataObj As Object = dgv.GetClipboardContent()
    '            If Not dataObj Is Nothing Then
    '                Clipboard.SetDataObject(dataObj)
    '            End If
    '            exHoja.Activate()
    '            exHoja.Range("A1").Select()
    '            exHoja.PasteSpecial(exHoja.Cells(2, 1).select(),
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                True)
    '            'otro metodo de pegado
    '            'HojaExcel.Range("A1").Select()
    '            'HojaExcel.ActiveSheet.Paste()
    '            GC.Collect()
    '            exHoja.Cells.Font.Name() = fuenteTablaReporte
    '            exHoja.Cells.Font.Size = 8
    '            exHoja.Rows.Item(1).Font.Bold = 1
    '            exHoja.Rows.Item(1).HorizontalAlignment = 3
    '            exHoja.Columns.AutoFit()
    '            Dim ultFil, ultCol As Integer
    '            ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '            ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '            'alinea al centro#############################################################################
    '            exHoja.Rows.AutoFit()
    '            'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '            With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '                .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '                .Color = RGB(130, 130, 130)
    '            End With
    '            With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '                .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '                '.Weight = xlNone
    '                '.Color = RGB(130, 130, 130)
    '            End With
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Cells(1, 1).value = titulo
    '            exHoja.Cells(2, 1).value = subtitulo
    '            'Mostrar documento
    '            exHoja.Cells(1, 1).select()

    '            exHoja = Nothing
    '            GC.Collect()
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '            Return False
    '        Finally
    '            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            z += 1
    '        End Try
    '        'Return True
    '    Next
    '    exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '    exApp.Application.Visible = True
    '    exLibro = Nothing
    '    exApp = Nothing
    '    GC.Collect()
    '    Return True
    'End Function

    '2022-10-31
    'Public Shared Function exportarVariosExcels(dDgvs As Dictionary(Of String, DataGridView), NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean
    '    'Public Shared Function exportarVariosExcels(dDgvs As Dictionary(Of String, DataGridView), titulo As String, subtitulo As String) As Boolean
    '    'Public Shared Function exportarExcel(dGV As DataGridView, NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean

    '    'Try
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
    '    exLibro = exApp.Workbooks.Add

    '    'exLibro.Sheets.Delete()
    '    'Dim z As Integer = 1
    '    Dim dgv As DataGridView = Nothing
    '    Dim nombreHoja As String
    '    For Each cv As KeyValuePair(Of String, DataGridView) In dDgvs ' dgv As DataGridView In dDgvs
    '        Try
    '            dgv = cv.Value
    '            nombreHoja = cv.Key
    '            'If z <> 1 Then
    '            'exLibro.Sheets.Add()
    '            'End If
    '            'exLibro = exApp.Workbooks.Add

    '            'exHoja = exLibro.Sheets(1)
    '            'exHoja = exLibro.Sheets(nombreHoja)
    '            'exHoja = New Microsoft.Office.Interop.Excel.Worksheet()
    '            exHoja = exLibro.Sheets(1)
    '            exHoja.Name = nombreHoja
    '            Dim NCol As Integer = dgv.ColumnCount
    '            Dim NRow As Integer = dgv.RowCount

    '            exHoja.Cells.Font.Color = colTextoTabla
    '            'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '            Dim j As Integer = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index

    '            '#Jota-2021-06-10: agregado para exportar solo columnas visibles
    '            Dim VisColCount As Integer = 1
    '            For Each col As DataGridViewColumn In dgv.Columns
    '                If col.Visible = True Then
    '                    VisColCount += 1
    '                End If
    '            Next

    '            'FORMATO GENERAL DE CELDAS
    '            exHoja.Cells.Font.Name = fuenteTablaReporte
    '            exHoja.Cells.Font.Size = 8
    '            exHoja.Cells.Font.Color = colTextoTabla
    '            exHoja.Rows.Item(1).Font.Bold = 1
    '            exHoja.Rows.Item(1).HorizontalAlignment = 3

    '            'CREAR CABECERAS SEGUN NOMBRE DE COLUMNAS DEL REPORTE
    '            For i As Integer = 1 To VisColCount - 1 'NCol
    '                Dim celda As String = dgv.Columns(j).Name.ToString
    '                'exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Interior.Color = colFondoCabecera
    '                exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Color = colTextoCabecera
    '                exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Name = fuenteCabeceraTablaReporte
    '                exHoja.Cells.Range(exHoja.Cells(1, i), exHoja.Cells(1, i)).Font.Size = 10

    '                If celda.Substring(0, 2) = "F_" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '                ElseIf celda.Substring(0, 2) = "T_" Then
    '                    exHoja.Columns(i).NumberFormat = "@"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    'ElseIf celda.Substring(0, 2) = "D_" Then
    '                    '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                    '    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 2) = "H1" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                    Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                    exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                Else
    '                    exHoja.Cells(1, i) = celda
    '                End If
    '                If i < NCol Then
    '                    j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '                End If
    '            Next

    '            exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders.Color = colBordeTabla
    '            exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(1, 1), exHoja.Cells(1, VisColCount - 1)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
    '            exHoja.Cells.Range(exHoja.Cells(2, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).Interior.Color = RGB(255, 255, 255)

    '            'AGREGADO PARA INSERTAR FILA EN TABLA VACIA:
    '            'Clipboard.Clear()
    '            'Dim dataObj As Object
    '            'If dgv.Rows.Count = 0 Then
    '            '    dgv.Rows.Insert(0, 1)
    '            '    Dim newDgv As New DataGridView
    '            '    newDgv.Columns.Add(dgv.Columns(0))
    '            '    newDgv.Rows.Insert(0, 1)
    '            '    newDgv.SelectAll()
    '            '    dataObj = newDgv.GetClipboardContent()
    '            'Else
    '            '    dgv.SelectAll()
    '            '    dataObj = dgv.GetClipboardContent()
    '            'End If

    '            ''//Copiar y pega toda la tabla datagridview al excel
    '            'Clipboard.Clear()
    '            'dgv.SelectAll()
    '            'Dim dataObj As Object = dgv.GetClipboardContent()
    '            ''dataObj = dgv.GETC
    '            ''ACA ESTA EL PROBLEMA... RESOLVER PORQUE DEBERIA DE ENTRAR AL IF PERO NO ENTRA
    '            ''dgv.ClipboardCopyMode=
    '            'If Not dataObj Is Nothing Then
    '            '    Clipboard.SetDataObject(dataObj)

    '            '    exHoja.PasteSpecial(exHoja.Cells(1, 1).select(),
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        True)
    '            'End If
    '            ''otro metodo de pegado
    '            ''HojaExcel.Range("A1").Select()
    '            ''HojaExcel.ActiveSheet.Paste()
    '            'GC.Collect()

    '            'MODIFICACION PARA EXPORTAR REGISTROS COPIANDO Y PEGANDO DE A POCOS PARA REGISTROS CON FILAS MAYORES A: agrupadorFilasExcel
    '            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            Dim maxX As Long = dgv.Rows.Count
    '            For iY As Long = 0 To maxX - 1 Step 1
    '                dgv.ClearSelection()
    '                Clipboard.Clear()
    '                For iiY As Long = iY To iY + agrupadorFilasExcel - 1 And iiY < maxX Step 1
    '                    If iiY < maxX Then
    '                        dgv.Rows(iiY).Selected = True
    '                    End If
    '                Next
    '                Dim dataObj As Object = dgv.GetClipboardContent()
    '                If Not dataObj Is Nothing Then
    '                    Clipboard.SetDataObject(dataObj)
    '                End If
    '                'System.Threading.Thread.Sleep(100)
    '                exHoja.PasteSpecial(exHoja.Cells(2 + iY, 1).select(), 'VALIDAR AQUI SUMANDO VALORES ALEATORIOS PARA ASEGURAR
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                True)
    '                GC.Collect()
    '                iY += agrupadorFilasExcel - 1
    '            Next

    '            'ESTILO GENERAL DE LA HJA
    '            'exHoja.Cells.Font.Name() = fuenteTablaReporte
    '            'exHoja.Cells.Font.Size = 8
    '            'exHoja.Rows.Item(1).Font.Bold = 1
    '            'exHoja.Rows.Item(1).HorizontalAlignment = 3
    '            'exHoja.Columns.AutoFit()
    '            Dim ultFil, ultCol As Integer

    '            ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '            ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '            'alinea al centro#############################################################################
    '            'exHoja.Rows.AutoFit()
    '            exHoja.Range(exHoja.Cells(1, 1), exHoja.Cells(NRow + 1, VisColCount - 1)).EntireColumn.AutoFit()
    '            'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            '    .Color = colBordeTabla 'RGB(130, 130, 130)
    '            'End With
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            '    '.Weight = xlNone
    '            '    '.Color = RGB(130, 130, 130)
    '            'End With


    '            'Modificacion para agrupacion de campos por nombre de columna
    '            If ColumnaAgrupada > 0 Then
    '                Dim alternadorColores As Boolean = False
    '                Dim valorCelda As String = exHoja.Cells(2, ColumnaAgrupada).Value
    '                Dim nuevoValorCelda As String = String.Empty
    '                Dim h As Integer = 2
    '                For i As Integer = 2 To ultFil + 1 Step 1
    '                    nuevoValorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '                    If valorCelda <> nuevoValorCelda Then
    '                        If alternadorColores Then
    '                            exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '                        Else
    '                            exHoja.Cells.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '                        End If
    '                        'With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '                        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '                        '    .Color = RGB(89, 89, 89)
    '                        'End With
    '                        h = i
    '                        valorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '                        alternadorColores = Not alternadorColores
    '                    End If
    '                Next
    '            End If


    '            'AGREGADO PARA METADOS DE REPORTE:
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()
    '            exHoja.Rows(1).EntireRow.Insert()

    '            exHoja.Cells(1, 1).value = "Aplicativo:"
    '            exHoja.Cells(2, 1).value = "Reporte:"
    '            exHoja.Cells(3, 1).value = "Usuario:"
    '            exHoja.Cells(4, 1).value = "Consulta:"
    '            exHoja.Cells(5, 1).value = "Parametros:"

    '            'CONTINUAR AQUI:
    '            exHoja.Cells(1, 2).value = "[" + Aplicativo + "]"
    '            exHoja.Cells(2, 2).value = "[" + NombreFormulario + "]"
    '            exHoja.Cells(3, 2).value = "[" + usuarioActual + "]"
    '            exHoja.Cells(4, 2).value = "[" + Now.ToString + "]"
    '            exHoja.Cells(5, 2).value = "[" + CadenaParametros + "]"

    '            exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
    '            exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
    '            exHoja.Range("A1", "B5").Font.Bold = 1

    '            exHoja.Columns(1).EntireColumn.Insert()
    '            exHoja.Cells(1, 1).select()
    '            exLibro.Sheets.Add(exHoja)
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '            Return False
    '        Finally
    '            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            dgv.ClearSelection()
    '            GC.Collect()
    '            Clipboard.Clear()
    '        End Try
    '        'System.Threading.Thread.Sleep(200)
    '    Next
    '    'Mostrar documento
    '    'exHoja.Cells(1, 1).select()
    '    exLibro.Sheets(1).delete()
    '    exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '    exApp.Application.Visible = True
    '    exHoja = Nothing
    '    exLibro = Nothing
    '    exApp = Nothing
    '    GC.Collect()
    '    System.Threading.Thread.Sleep(200)
    '    Return True
    'End Function


    ''NUEVA FUNCION DE EXPORTAR, AGRUPA TITULOS DE COLUMNAS - PENDIENTE DE CULMINAR->2022-06-022
    'Public Shared Function exportar(dDgvs As Dictionary(Of String, DataGridView), NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean
    '    'Try
    '    '//Variables de documento Excel
    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
    '    exLibro = exApp.Workbooks.Add

    '    Dim x As Integer = 1, y As Integer = 1
    '    Dim niveles As Integer = 0
    '    Dim separadorTitulos As Char = "/"

    '    'exLibro.Sheets.Delete()
    '    'Dim z As Integer = 1
    '    Dim dgv As DataGridView = Nothing
    '    Dim nombreHoja As String
    '    For Each cv As KeyValuePair(Of String, DataGridView) In dDgvs ' dgv As DataGridView In dDgvs
    '        Try
    '            dgv = cv.Value
    '            nombreHoja = cv.Key
    '            'If z <> 1 Then
    '            'exLibro.Sheets.Add()
    '            'End If
    '            'exLibro = exApp.Workbooks.Add

    '            'exHoja = exLibro.Sheets(1)
    '            'exHoja = exLibro.Sheets(nombreHoja)
    '            'exHoja = New Microsoft.Office.Interop.Excel.Worksheet()
    '            exHoja = exLibro.Sheets(1)
    '            exHoja.Name = nombreHoja
    '            Dim NCol As Integer = dgv.ColumnCount
    '            Dim NRow As Integer = dgv.RowCount

    '            exHoja.Cells.Font.Color = colTextoTabla
    '            'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '            Dim j As Integer = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index

    '            '#Jota-2021-06-10: agregado para exportar solo columnas visibles
    '            Dim VisColCount As Integer = 1
    '            For Each col As DataGridViewColumn In dgv.Columns
    '                If col.Visible = True Then
    '                    VisColCount += 1
    '                End If
    '            Next


    '            'FORMATO GENERAL DE CELDAS
    '            exHoja.Cells.Font.Name = fuenteTablaReporte
    '            exHoja.Cells.Font.Size = 8
    '            exHoja.Cells.Font.Color = colTextoTabla
    '            exHoja.Rows.Item(y).Font.Bold = 1
    '            exHoja.Rows.Item(y).HorizontalAlignment = 3
    '            'FORMATO DE CABECERAS
    '            exHoja.Rows.Item(y).Font.Color = colTextoCabecera
    '            exHoja.Rows.Item(y).Font.Name = fuenteCabeceraTablaReporte
    '            exHoja.Rows.Item(y).Font.Size = 10

    '            'CREAR CABECERAS SEGUN NOMBRE DE COLUMNAS DEL REPORTE
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Color = colTextoCabecera
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Name = fuenteCabeceraTablaReporte
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Size = 10

    '            For i As Integer = x To x + VisColCount - 1 'NCol
    '                Dim celda As String = dgv.Columns(j).Name.ToString

    '                Dim nC As Integer = celda.Split(separadorTitulos).Length
    '                niveles = IIf(niveles < nC, nC, niveles) 'niveles de agrupacion para la fusion de cabeceras

    '                If celda.Substring(0, 2) = "F_" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '                ElseIf celda.Substring(0, 2) = "T_" Then
    '                    exHoja.Columns(i).NumberFormat = "@"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    'ElseIf celda.Substring(0, 2) = "D_" Then
    '                    '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                    '    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 2) = "H1" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                    Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                    exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                Else
    '                    exHoja.Cells(1, i) = celda
    '                End If
    '                If i < NCol Then
    '                    j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '                End If
    '            Next

    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders.Color = colBordeTabla
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(y, x + VisColCount - 1)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Interior.Color = RGB(255, 255, 255)

    '            'AGREGADO PARA INSERTAR FILA EN TABLA VACIA:
    '            'Clipboard.Clear()
    '            'Dim dataObj As Object
    '            'If dgv.Rows.Count = 0 Then
    '            '    dgv.Rows.Insert(0, 1)
    '            '    Dim newDgv As New DataGridView
    '            '    newDgv.Columns.Add(dgv.Columns(0))
    '            '    newDgv.Rows.Insert(0, 1)
    '            '    newDgv.SelectAll()
    '            '    dataObj = newDgv.GetClipboardContent()
    '            'Else
    '            '    dgv.SelectAll()
    '            '    dataObj = dgv.GetClipboardContent()
    '            'End If

    '            '//Copiar y pega toda la tabla datagridview al excel
    '            'Clipboard.Clear()
    '            'dgv.SelectAll()
    '            ''dgv.Rows(0).Selected = True
    '            'Dim dataObj As Object = dgv.GetClipboardContent()
    '            'If Not dataObj Is Nothing Then
    '            '    Clipboard.SetDataObject(dataObj)

    '            '    exHoja.PasteSpecial(exHoja.Cells(y, x).select(),
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        Type.Missing,
    '            '                        True)
    '            'End If
    '            ''otro metodo de pegado
    '            ''HojaExcel.Range("A1").Select()
    '            ''HojaExcel.ActiveSheet.Paste()
    '            'GC.Collect()

    '            Dim maxX As Long = dgv.Rows.Count
    '            For iY As Long = 0 To maxX - 1 Step 1
    '                dgv.ClearSelection()
    '                Clipboard.Clear()
    '                For iiY As Long = iY To iY + agrupadorFilasExcel - 1 And iiY < maxX Step 1
    '                    dgv.Rows(iiY).Selected = True
    '                Next
    '                Dim dataObj As Object = dgv.GetClipboardContent()
    '                If Not dataObj Is Nothing Then
    '                    Clipboard.SetDataObject(dataObj)
    '                End If
    '                exHoja.PasteSpecial(exHoja.Cells(y + iY, x).select(), 'VALIDAR AQUI SUMANDO VALORES ALEATORIOS PARA ASEGURAR
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                Type.Missing,
    '                                True)
    '                GC.Collect()
    '                iY += agrupadorFilasExcel - 1
    '            Next


    '            'ESTILO GENERAL DE LA HJA
    '            'exHoja.Cells.Font.Name() = fuenteTablaReporte
    '            'exHoja.Cells.Font.Size = 8
    '            'exHoja.Rows.Item(1).Font.Bold = 1
    '            'exHoja.Rows.Item(1).HorizontalAlignment = 3
    '            'exHoja.Columns.AutoFit()
    '            Dim ultFil, ultCol As Integer
    '            ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '            ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '            'alinea al centro#############################################################################
    '            'exHoja.Rows.AutoFit()
    '            exHoja.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + 1 + y, VisColCount + x - 1)).EntireColumn.AutoFit()
    '            'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            '    .Color = colBordeTabla 'RGB(130, 130, 130)
    '            'End With
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            '    '.Weight = xlNone
    '            '    '.Color = RGB(130, 130, 130)
    '            'End With


    '            'Modificacion para agrupacion de campos por nombre de columna
    '            If ColumnaAgrupada > 0 Then
    '                Dim alternadorColores As Boolean = False
    '                Dim valorCelda As String = exHoja.Cells(y + 1, ColumnaAgrupada).Value
    '                Dim nuevoValorCelda As String = String.Empty
    '                Dim h As Integer = y + 1
    '                For i As Integer = h To ultFil + 1 Step 1
    '                    nuevoValorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '                    If valorCelda <> nuevoValorCelda Then
    '                        If alternadorColores Then
    '                            exHoja.Cells.Range(exHoja.Cells(h, x), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '                        Else
    '                            exHoja.Cells.Range(exHoja.Cells(h, x), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '                        End If
    '                        'With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '                        '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '                        '    .Color = RGB(89, 89, 89)
    '                        'End With
    '                        h = i
    '                        valorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '                        alternadorColores = Not alternadorColores
    '                    End If
    '                Next
    '            End If

    '            'CORTA LOS TITULOS Y LOS APILA ENCIMA DEL ANTERIOR
    '            Dim contenido As String
    '            Dim lIO As Integer
    '            For i As Integer = 1 To niveles Step 1
    '                exHoja.Rows(y).EntireRow.Insert()
    '                For iC As Integer = x To x + VisColCount - 1 Step 1 'NCol
    '                    contenido = exHoja.Cells(y + 1, iC).Value
    '                    If Not contenido Is Nothing Then
    '                        lIO = contenido.LastIndexOf(separadorTitulos) 'lio = LAST INDEX OF
    '                        If lIO > 0 Then
    '                            exHoja.Cells(y, iC) = contenido.Substring(0, lIO)
    '                            exHoja.Cells(y + 1, iC) = contenido.Substring(lIO)
    '                        End If
    '                    End If
    '                Next
    '            Next

    '            'For i As Integer = 1 To niveles - 1 Step 1
    '            '    contenido = exHoja.Cells(y, x).value
    '            '    Dim colAgrupadas As Integer = 1, colDesde As Integer = x
    '            '    For iC As Integer = x + 1 To x + VisColCount - 1 'NCol
    '            '        If Not contenido Is Nothing Then
    '            '            If contenido = exHoja.Cells(y, iC + 1).value Then
    '            '                colAgrupadas += 1
    '            '            Else
    '            '                If colAgrupadas > 1 Then
    '            '                    exHoja.Cells.Range(exHoja.Cells(y, colDesde), exHoja.Cells(y, colDesde + colAgrupadas)).Merge()
    '            '                End If
    '            '                colDesde += 1
    '            '                contenido = exHoja.Cells(y, colDesde).value
    '            '            End If
    '            '        Else
    '            '            contenido = exHoja.Cells(y, iC).value
    '            '        End If

    '            '    Next
    '            'Next

    '            'AGREGADO PARA METADOS DE REPORTE:
    '            exHoja.Rows(y).EntireRow.Insert()
    '            exHoja.Rows(y).EntireRow.Insert()
    '            exHoja.Rows(y).EntireRow.Insert()
    '            exHoja.Rows(y).EntireRow.Insert()
    '            exHoja.Rows(y).EntireRow.Insert()
    '            exHoja.Rows(y).EntireRow.Insert()

    '            exHoja.Cells(1, x).value = "Aplicativo:"
    '            exHoja.Cells(2, x).value = "Reporte:"
    '            exHoja.Cells(3, x).value = "Usuario:"
    '            exHoja.Cells(4, x).value = "Consulta:"
    '            exHoja.Cells(5, x).value = "Parametros:"

    '            'CONTINUAR AQUI:
    '            exHoja.Cells(1, x + 1).value = "[" + Aplicativo + "]"
    '            exHoja.Cells(2, x + 1).value = "[" + NombreFormulario + "]"
    '            exHoja.Cells(3, x + 1).value = "[" + usuarioActual + "]"
    '            exHoja.Cells(4, x + 1).value = "[" + Now.ToString + "]"
    '            exHoja.Cells(5, x + 1).value = "[" + CadenaParametros + "]"

    '            exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
    '            exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
    '            exHoja.Range("A1", "B5").Font.Bold = 1

    '            'exHoja.Columns(1').EntireColumn.Insert()
    '            exHoja.Cells(1, 1).select()
    '            exLibro.Sheets.Add(exHoja)
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '            Return False
    '        Finally
    '            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            dgv.ClearSelection()
    '            GC.Collect()
    '            Clipboard.Clear()
    '        End Try
    '        'System.Threading.Thread.Sleep(200)
    '    Next
    '    'Mostrar documento
    '    'exHoja.Cells(1, 1).select()
    '    exLibro.Sheets(1).delete()
    '    exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '    exApp.Application.Visible = True
    '    exHoja = Nothing
    '    exLibro = Nothing
    '    exApp = Nothing
    '    GC.Collect()
    '    System.Threading.Thread.Sleep(200)
    '    Return True
    'End Function

    'Sub exportarMultiExcel(ByVal DtReport As DataTable, ByVal Titulo As String, Optional ByVal pgbar As ProgressBar = Nothing, Optional ByVal lbl As Label = Nothing)
    '    Try
    '        Dim Iprogres As Double = 0

    '        Dim objLibroExcel As Microsoft.Office.Interop.Excel.Workbook
    '        Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet
    '        Dim m_Excel = New Microsoft.Office.Interop.Excel.Application
    '        m_Excel.Visible = False

    '        objLibroExcel = m_Excel.Workbooks.Add()
    '        objHojaExcel = objLibroExcel.Worksheets(1)
    '        objHojaExcel.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
    '        objHojaExcel.Activate()

    '' Crear el encabezado de nuestro informe
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").Merge()
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").Value = Titulo
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").Font.Bold = True
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").Font.Size = 15
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").Font.Name = "TAHOMA"
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").VerticalAlignment = Excel.Constants.xlCenter
    'objHojaExcel.Range("A1:" & RetornaLetra(DtReport.Columns.Count) & "1").HorizontalAlignment = Excel.Constants.xlCenter

    '        Dim objCelda As Excel.Range

    '        For Jx As Integer = 0 To DtReport.Columns.Count - 1
    '            objCelda = objHojaExcel.Range(RetornaLetra(Jx + 1) & "5", Type.Missing)
    '            objCelda.Value = DtReport.Columns(Jx).Caption
    '        Next


    '        Dim i As Integer = 6
    '        Dim acu As Double = 0

    '        Iprogres = 100 / (DtReport.Rows.Count - 1)
    '        If Not pgbar Is Nothing Then
    '            pgbar.Step = Iprogres
    '        End If

    '        For Ix As Integer = 0 To DtReport.Rows.Count - 1
    '            For Jx As Integer = 0 To DtReport.Columns.Count - 1
    '                objHojaExcel.Cells(i, RetornaLetra(Jx + 1)) = DtReport.Rows(Ix)(Jx)
    '            Next
    '            i += 1

    '            If Not pgbar Is Nothing Then
    '                If Not acu + Iprogres > 100 Then
    '                    acu += Iprogres
    '                End If
    '                pgbar.Value = acu
    '            End If

    '            If Not lbl Is Nothing Then
    '                lbl.Text = acu
    '            End If
    '        Next

    '        Dim objRango As Excel.Range = objHojaExcel.Range("A5:" & RetornaLetra(DtReport.Columns.Count) & DtReport.Rows.Count + 5)
    '        objRango.Select()
    '        objRango.Columns.AutoFit()
    '        objRango.AutoFilter(1, , VisibleDropDown:=True)

    '        objRango.Font.Name = "TAHOMA"
    '        objRango.Font.Size = 10
    '        objRango.Borders.LineStyle = 1

    '        '' Crear un total general
    '        objHojaExcel.Cells(DtReport.Rows.Count + 7, 1) = "Total Filas: "
    '        objHojaExcel.Cells(DtReport.Rows.Count + 7, 2) = (DtReport.Rows.Count)
    '        objHojaExcel = Nothing
    '        objLibroExcel = Nothing

    '        m_Excel.Visible = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Public Shared Function xxx()
    '    'Abro una hoja de excel

    '    Dim HojaExcel As Excel.Application
    '    Dim exBook As Excel.Workbook
    '    HojaExcel = New Excel.Application
    '    exBook = HojaExcel.Workbooks.Add
    '    HojaExcel.Visible = False

    '    'Selecciono todo el datagrid y copio su contenido al portapapeles

    '    DtGrTabla.SelectAll()
    '    Dim dataObj As DataObject = DtGrTabla.GetClipboardContent
    '    If Not IsNothing(dataObj) Then
    '        Clipboard.SetDataObject(dataObj)
    '    End If

    '    'Selecciono la celda desde la cual quiero copiar y pego

    '    HojaExcel.Range("A1").Select()
    '    HojaExcel.ActiveSheet.Paste()

    '    'Y ya sea que guardes el excel o que lo abras

    '    HojaExcel.Visible = True
    'End Function

    'Public Shared Function Intervalo(strDate1 As String, strDate2 As String) As String

    '    Dim fNeg As Boolean
    '    Dim dt1 As Date, dt2 As Date
    '    Dim ms1 As Long, ms2 As Long

    '    ' Assign earliest date to dt1...
    '    If strDate1 <= strDate2 Then
    '        dt1 = Left$(strDate1, 8)
    '        dt2 = Left$(strDate2, 8)
    '        ms1 = Right$(strDate1, 3)
    '        ms2 = Right$(strDate2, 3)
    '    Else
    '        dt1 = Left$(strDate2, 8)
    '        dt2 = Left$(strDate1, 8)
    '        ms1 = Right$(strDate2, 3)
    '        ms2 = Right$(strDate1, 3)
    '        fNeg = True
    '    End If

    '    ' If ms of starting time > ms of ending time, add a second before subtraction...
    '    Dim ms As Long
    '    If ms1 > ms2 Then
    '        dt1 = DateAdd("s", 1, dt1)
    '        ms = (1000 - ms1) + ms2
    '    Else
    '        ms = ms2 - ms1
    '    End If

    '    ' Subtract dates, get difference in seconds...
    '    Dim h As Long, m As Long, s As Long
    '    s = DateDiff("s", dt1, dt2)

    '    ' Convert seconds to H:M:S...
    '    h = s \ 3600
    '    s = s Mod 3600
    '    m = s \ 60
    '    s = s Mod 60

    '    Intervalo = IIf(fNeg, "-", "") & h & ":" & m & ":" & s & ":" & ms

    'End Function

    'Public Shared Function excelling(dDgvs As Dictionary(Of String, DataTable), NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0)
    '    Dim d As DataTable = dDgvs.First.Value
    '    Dim f As Integer = d.Rows.Count
    '    Dim c As Integer = d.Columns.Count
    '    'd.SelectionMode = DataGridViewSelectionMode.CellSelect
    '    'Dim stpw As Stopwatch = Stopwatch.StartNew 'start timing
    '    Dim inicio As DateTime
    '    Dim fin As DateTime

    '    inicio = Now
    '    For i As Integer = 0 To f - 1 Step 1
    '        For j As Integer = 0 To c - 1 Step 1
    '            'd.Rows(i).Cells(j).Selected = True
    '            'Clipboard.SetText(d.Rows(i).Item(j).ToString)
    '            'Clipboard.SetText(d.Rows(i).ItemArray.ToString)
    '            'System.Threading.Thread.Sleep(15)
    '            'd.ClearSelection()
    '        Next
    '    Next
    '    '        stpw.Stop()
    '    fin = Now

    '    'GetTimeDiff = IIf(fNeg, "-", "") & h & ":" & m & ":" & s & ":" & MS
    '    'MessageBox.Show("Copiado: " + Intervalo(inicio.ToString, fin.ToString))
    '    MessageBox.Show("Copiado: " + DateDiff(DateInterval.Second, inicio, fin).ToString)
    'End Function

    ''COMENTADA 2022-11-28
    ''NUEVA FUNCION DE EXPORTAR, AGRUPA TITULOS DE COLUMNAS - PENDIENTE DE CULMINAR->2022-10-31 
    'Public Shared Function excelling(dDgvs As Dictionary(Of String, DataGridView), NombreFormulario As String, CadenaParametros As String, Optional ColumnaAgrupada As Integer = 0) As Boolean

    '    Dim exApp As New Microsoft.Office.Interop.Excel.Application
    '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
    '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
    '    exLibro = exApp.Workbooks.Add
    '    exLibro = exApp.Workbooks.Open("")

    '    Dim x As Integer = 1, y As Integer = 1
    '    Dim niveles As Integer = 0
    '    Dim separadorTitulos As Char = "|"

    '    Dim dgv As DataGridView = Nothing
    '    Dim nombreHoja As String
    '    For Each cv As KeyValuePair(Of String, DataGridView) In dDgvs
    '        Try
    '            dgv = cv.Value
    '            nombreHoja = cv.Key
    '            exHoja = exLibro.Sheets(1)
    '            exHoja.Name = nombreHoja
    '            Dim NCol As Integer = dgv.ColumnCount
    '            Dim NRow As Integer = dgv.RowCount

    '            exHoja.Cells.Font.Color = colTextoTabla
    '            'Crear Cabeceras de columnas en el doc y formatea segun el contenido de la columna
    '            Dim j As Integer = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index

    '            '#Jota-2021-06-10: agregado para exportar solo columnas visibles
    '            Dim VisColCount As Integer = 0
    '            For Each col As DataGridViewColumn In dgv.Columns
    '                If col.Visible = True Then
    '                    VisColCount += 1
    '                End If
    '            Next
    '            'exHoja.Cells.Font.Color = colTextoTabla
    '            For i As Integer = x To x + VisColCount - 1 'NCol
    '                Dim celda As String = dgv.Columns(j).Name.ToString

    '                Dim nC As Integer = celda.Split(separadorTitulos).Length
    '                niveles = IIf(niveles < nC, nC, niveles) 'niveles de agrupacion para la fusion de cabeceras

    '                If celda.Substring(0, 2) = "F_" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy" 'POSIBLE CAUSA DE EERROR EN OTRAS COMPUTADORAS POR COMPATIBILIDAD DE IDIOMA
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '                ElseIf celda.Substring(0, 2) = "T_" Then
    '                    exHoja.Columns(i).NumberFormat = "@"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                    'ElseIf celda.Substring(0, 2) = "D_" Then
    '                    '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '                    '    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 2) = "H1" Then
    '                    exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '                    Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '                    exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '                    exHoja.Cells(1, i) = celda.Substring(2)
    '                Else
    '                    exHoja.Cells(1, i) = celda
    '                End If
    '                If i < NCol Then
    '                    j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '                End If
    '            Next

    '            'METODO DE COPIADO DIRECTO
    '            'dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
    '            'exHoja.Cells(1, 1) = dgv.Rows(1).Cells(1).Value.ToString
    '            For iFils As Integer = 0 To NRow - 1 Step 1
    '                For jCols As Integer = 0 To NCol - 1 Step 1
    '                    'If Left(dgv.Columns(jCols).Name.ToString, 2) = "F_" Then
    '                    '    'exHoja.Cells(iFils + 2, jCols + 1) = dgv.Rows(iFils).Cells(jCols).FormattedValue.ToString ' .ToString '("dd/MM/yyyy")
    '                    '    exHoja.Cells(iFils + 2, jCols + 1) = dgv.Rows(iFils).Cells(jCols).Value.ToString
    '                    'Else
    '                    '    exHoja.Cells(iFils + 2, jCols + 1) = dgv.Rows(iFils).Cells(jCols).Value.ToString
    '                    'End If
    '                    'dgv.Rows(iFils).Cells(jCols).Selected = True
    '                    exHoja.Cells(iFils + 2, jCols + 1) = dgv.Rows(iFils).Cells(jCols).Value.ToString
    '                    'dgv.Rows(iFils).Cells(jCols).Selected = False
    '                    'd.Rows(i).Cells(j).Selected = True
    '                    'Clipboard.SetText(d.Rows(i).Item(j).ToString)
    '                    'Clipboard.SetText(d.Rows(i).ItemArray.ToString)
    '                    'System.Threading.Thread.Sleep(15)
    '                    'd.ClearSelection()
    '                Next
    '            Next

    '            'For i As Integer = x To x + VisColCount - 1 'NCol
    '            '    Dim celda As String = dgv.Columns(j).Name.ToString

    '            '    Dim nC As Integer = celda.Split(separadorTitulos).Length
    '            '    niveles = IIf(niveles < nC, nC, niveles) 'niveles de agrupacion para la fusion de cabeceras

    '            '    If celda.Substring(0, 2) = "F_" Then
    '            '        exHoja.Columns(i).NumberFormat = "dd//MM/dd"
    '            '        exHoja.Cells(1, i) = celda.Substring(2)
    '            '        exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            '    ElseIf celda.Substring(0, 2) = "T_" Then
    '            '        exHoja.Columns(i).NumberFormat = "@"
    '            '        exHoja.Cells(1, i) = celda.Substring(2)
    '            '        'ElseIf celda.Substring(0, 2) = "D_" Then
    '            '        '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
    '            '        '    exHoja.Cells(1, i) = celda.Substring(2)
    '            '    ElseIf celda.Substring(0, 2) = "H1" Then
    '            '        exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
    '            '        exHoja.Cells(1, i) = celda.Substring(2)
    '            '    ElseIf celda.Substring(0, 1) = "D" And celda.Substring(1, 1) >= "0" And celda.Substring(1, 1) <= "9" Then
    '            '        Dim ceros As Integer = CInt(celda.Substring(1, 1))
    '            '        exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
    '            '        exHoja.Cells(1, i) = celda.Substring(2)
    '            '    Else
    '            '        exHoja.Cells(1, i) = celda
    '            '    End If
    '            '    If i < NCol Then
    '            '        j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
    '            '    End If
    '            'Next

    '            ''MessageBox.Show(dgv.Rows(1).Cells.ToString()) proceso de copiado
    '            'Dim dataObj As Object
    '            'Dim ClipboardBuillder As StringBuilder = New StringBuilder()
    '            'For nf As Integer = 0 To NRow - 1 Step 1
    '            '    dgv.ClearSelection()
    '            '    dgv.Rows(nf).Selected = True
    '            '    dataObj = dgv.GetClipboardContent()
    '            '    'If NRow > 3000 Then
    '            '    '    System.Threading.Thread.Sleep(25)
    '            '    'Else
    '            '    '    System.Threading.Thread.Sleep(10)
    '            '    'End If
    '            '    'System.Threading.Thread.Sleep(10)
    '            '    ClipboardBuillder.Append(dgv.Rows(nf).Cells.ToString())
    '            '    Clipboard.SetText(ClipboardBuillder.ToString())
    '            '    If Not dataObj Is Nothing Then
    '            '        Clipboard.SetData("", dataObj)
    '            '        'Clipboard.SetText(ClipboardBuillder.ToString())
    '            '        'System.Threading.Thread.Sleep(20)
    '            '    End If
    '            '    exHoja.PasteSpecial(exHoja.Cells(y + nf + 1, x).select(), 'VALIDAR AQUI SUMANDO VALORES ALEATORIOS PARA ASEGURAR
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    True)
    '            '    'If NRow > 3000 Then
    '            '    '    System.Threading.Thread.Sleep(15)
    '            '    'Else
    '            '    '    System.Threading.Thread.Sleep(5)
    '            '    'End If
    '            '    dgv.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex + 1
    '            '    GC.Collect()
    '            '    Clipboard.Clear()
    '            'Next

    '            'Dim maxX As Long = VisColCount ' dgv.Rows.Count
    '            'For iY As Long = 0 To maxX - 1 Step 1
    '            '    dgv.ClearSelection()
    '            '    'Clipboard.Clear()
    '            '    For iiY As Long = iY To iY + agrupadorFilasExcel - 1 And iiY < maxX Step 1
    '            '        'Clipboard.Clear()
    '            '        dgv.Rows(iiY).Selected = True
    '            '    Next
    '            '    Dim dataObj As Object = dgv.GetClipboardContent()
    '            '    If Not dataObj Is Nothing Then
    '            '        Clipboard.SetDataObject(dataObj)
    '            '    End If
    '            '    exHoja.PasteSpecial(exHoja.Cells(y + iY, x).select(), 'VALIDAR AQUI SUMANDO VALORES ALEATORIOS PARA ASEGURAR
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    Type.Missing,
    '            '                    True)
    '            '    GC.Collect()
    '            '    iY += agrupadorFilasExcel - 1
    '            'Next


    '            'ESTILO GENERAL DE LA HJA
    '            'exHoja.Cells.Font.Name() = fuenteTablaReporte
    '            'exHoja.Cells.Font.Size = 8
    '            'exHoja.Rows.Item(1).Font.Bold = 1
    '            'exHoja.Rows.Item(1).HorizontalAlignment = 3
    '            'exHoja.Columns.AutoFit()
    '            Dim ultFil, ultCol As Integer
    '            ultFil = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell
    '            ultCol = exHoja.Cells.SpecialCells(xlLastCell).Column
    '            'alinea al centro#############################################################################
    '            'exHoja.Rows.AutoFit()
    '            exHoja.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + 1 + y, VisColCount + x - 1)).EntireColumn.AutoFit()


    '            'FORMATO GENERAL DE CELDAS
    '            exHoja.Cells.Font.Name = fuenteTablaReporte
    '            exHoja.Cells.Font.Size = 8
    '            exHoja.Cells.Font.Color = colTextoTabla
    '            'FORMATO DE CABECERAS
    '            exHoja.Rows.Item(y).Font.Bold = 1
    '            exHoja.Rows.Item(y).HorizontalAlignment = 3
    '            exHoja.Rows.Item(y).Font.Color = colTextoCabecera
    '            exHoja.Rows.Item(y).Font.Name = fuenteCabeceraTablaReporte
    '            exHoja.Rows.Item(y).Font.Size = 10

    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders.Color = colBordeTabla
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(NRow + y, x + VisColCount - 1)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            exHoja.Cells.Range(exHoja.Cells(y, x), exHoja.Cells(y, x + VisColCount - 1)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
    '            exHoja.Cells.Range(exHoja.Cells(y + 1, x), exHoja.Cells(NRow + y + 1, x + VisColCount - 1)).Interior.Color = RGB(255, 255, 255)


    '            'CREAR CABECERAS SEGUN NOMBRE DE COLUMNAS DEL REPORTE
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Color = colTextoCabecera
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Name = fuenteCabeceraTablaReporte
    '            'exHoja.Cells.Range(exHoja.Cells(y, VisColCount - 1), exHoja.Cells(y, VisColCount - 1)).Font.Size = 10

    '            'SELECCIONAR RANGO DE ACCION PARA FORMATO DE BORDES
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders() '(ultFil, ultCol)).Borders()
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    '            '    .Color = colBordeTabla 'RGB(130, 130, 130)
    '            'End With
    '            'With exHoja.Columns.Range(exHoja.Cells(1, 1), exHoja.Cells(ultFil, ultCol)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
    '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
    '            '    '.Weight = xlNone
    '            '    '.Color = RGB(130, 130, 130)
    '            'End With


    '            ''Modificacion para agrupacion de campos por nombre de columna
    '            'If ColumnaAgrupada > 0 Then
    '            '    Dim alternadorColores As Boolean = False
    '            '    Dim valorCelda As String = exHoja.Cells(y + 1, ColumnaAgrupada).Value
    '            '    Dim nuevoValorCelda As String = String.Empty
    '            '    Dim h As Integer = y + 1
    '            '    For i As Integer = h To ultFil + 1 Step 1
    '            '        nuevoValorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '            '        If valorCelda <> nuevoValorCelda Then
    '            '            If alternadorColores Then
    '            '                exHoja.Cells.Range(exHoja.Cells(h, x), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado2 'oscuro
    '            '            Else
    '            '                exHoja.Cells.Range(exHoja.Cells(h, x), exHoja.Cells(i - 1, ultCol)).Interior.Color = colFondoAgrupado1 'claro
    '            '            End If
    '            '            'With exHoja.Columns.Range(exHoja.Cells(h, 1), exHoja.Cells(i - 1, ultCol)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '            '            '    .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDot
    '            '            '    .Color = RGB(89, 89, 89)
    '            '            'End With
    '            '            h = i
    '            '            valorCelda = exHoja.Cells(i, ColumnaAgrupada).Value
    '            '            alternadorColores = Not alternadorColores
    '            '        End If
    '            '    Next
    '            'End If

    '            ''CORTA LOS TITULOS Y LOS APILA ENCIMA DEL ANTERIOR
    '            'Dim contenido As String
    '            'Dim lIO As Integer
    '            'For i As Integer = 1 To niveles Step 1
    '            '    exHoja.Rows(y).EntireRow.Insert()
    '            '    For iC As Integer = x To x + VisColCount - 1 Step 1 'NCol
    '            '        contenido = exHoja.Cells(y + 1, iC).Value
    '            '        If Not contenido Is Nothing Then
    '            '            lIO = contenido.LastIndexOf(separadorTitulos) 'lio = LAST INDEX OF
    '            '            If lIO > 0 Then
    '            '                exHoja.Cells(y, iC) = contenido.Substring(0, lIO)
    '            '                exHoja.Cells(y + 1, iC) = contenido.Substring(lIO)
    '            '            End If
    '            '        End If
    '            '    Next
    '            'Next

    '            'For i As Integer = 1 To niveles - 1 Step 1
    '            '    contenido = exHoja.Cells(y, x).value
    '            '    Dim colAgrupadas As Integer = 1, colDesde As Integer = x
    '            '    For iC As Integer = x + 1 To x + VisColCount - 1 'NCol
    '            '        If Not contenido Is Nothing Then
    '            '            If contenido = exHoja.Cells(y, iC + 1).value Then
    '            '                colAgrupadas += 1
    '            '            Else
    '            '                If colAgrupadas > 1 Then
    '            '                    exHoja.Cells.Range(exHoja.Cells(y, colDesde), exHoja.Cells(y, colDesde + colAgrupadas)).Merge()
    '            '                End If
    '            '                colDesde += 1
    '            '                contenido = exHoja.Cells(y, colDesde).value
    '            '            End If
    '            '        Else
    '            '            contenido = exHoja.Cells(y, iC).value
    '            '        End If

    '            '    Next
    '            'Next

    '            ''AGREGADO PARA METADOS DE REPORTE:
    '            'exHoja.Rows(y).EntireRow.Insert()
    '            'exHoja.Rows(y).EntireRow.Insert()
    '            'exHoja.Rows(y).EntireRow.Insert()
    '            'exHoja.Rows(y).EntireRow.Insert()
    '            'exHoja.Rows(y).EntireRow.Insert()
    '            'exHoja.Rows(y).EntireRow.Insert()

    '            'exHoja.Cells(1, x).value = "Aplicativo:"
    '            'exHoja.Cells(2, x).value = "Reporte:"
    '            'exHoja.Cells(3, x).value = "Usuario:"
    '            'exHoja.Cells(4, x).value = "Consulta:"
    '            'exHoja.Cells(5, x).value = "Parametros:"

    '            ''CONTINUAR AQUI:
    '            'exHoja.Cells(1, x + 1).value = "[" + Aplicativo + "]"
    '            'exHoja.Cells(2, x + 1).value = "[" + NombreFormulario + "]"
    '            'exHoja.Cells(3, x + 1).value = "[" + usuarioActual + "]"
    '            'exHoja.Cells(4, x + 1).value = "[" + Now.ToString + "]"
    '            'exHoja.Cells(5, x + 1).value = "[" + CadenaParametros + "]"

    '            'exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
    '            'exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
    '            'exHoja.Range("A1", "B5").Font.Bold = 1

    '            'exHoja.Columns(1').EntireColumn.Insert()
    '            exHoja.Cells(1, 1).select()
    '            exLibro.Sheets.Add(exHoja)
    '        Catch ex As Exception
    '            exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '            exApp.Application.Visible = True
    '            exHoja = Nothing
    '            exLibro = Nothing
    '            exApp = Nothing
    '            MessageBox.Show(ex.Message)
    '            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
    '            Return False
    '        Finally

    '            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            dgv.ClearSelection()
    '            GC.Collect()
    '            Clipboard.Clear()
    '        End Try
    '        'System.Threading.Thread.Sleep(200)
    '    Next
    '    'Mostrar documento
    '    'exHoja.Cells(1, 1).select()
    '    exLibro.Sheets(1).delete()
    '    exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    '    exApp.Application.Visible = True
    '    exHoja = Nothing
    '    exLibro = Nothing
    '    exApp = Nothing
    '    GC.Collect()
    '    'System.Threading.Thread.Sleep(200)
    '    Return True
    'End Function

    Public Shared Function corregirCeldas(ByRef dgv As DataGridView)
        Try
            Dim col As Integer = dgv.Columns.Count
            Dim fil As Integer = dgv.Rows.Count
            For f As Integer = 0 To fil - 1 Step 1
                For c As Integer = 0 To col - 1 Step 1
                    'Dim nuevaCelda As String = ""
                    'nuevaCelda = RTrim(Replace(dgv.Item(c, f).Value.ToString, vbNewLine, ""))
                    'dgv.Item(c, f).Value = nuevaCelda
                    If Type.GetTypeCode(dgv.Item(c, f).Value) = TypeCode.DBNull Then ' 2=DBNULL
                        dgv.Item(c, f).Value = 0
                    Else
                        dgv.Item(c, f).Value = Trim(Replace(dgv.Item(c, f).Value.ToString, vbNewLine, ""))
                    End If
                Next
            Next
            Return True
        Catch
            Return False
        End Try
    End Function

    Public Shared Function corregirTabla(ByRef tabla As DataTable)
        Try
            Dim col As Integer = tabla.Columns.Count
            Dim fil As Integer = tabla.Rows.Count
            'Dim esVacia As Boolean
            For f As Integer = 0 To fil - 1 Step 1
                'esVacia = True
                For c As Integer = 0 To col - 1 Step 1
                    If Type.GetTypeCode(tabla.Rows(f).Item(c).GetType) = TypeCode.DBNull Then
                        tabla.Rows(f).Item(c) = ""
                    Else
                        tabla.Rows(f).Item(c) = UCase(Trim(Replace(tabla.Rows(f).Item(c).ToString, vbNewLine, "")))
                    End If
                    'If tabla.Rows(f).Item(c) <> "" Then
                    '    esVacia = False
                    'End If
                Next
                'If esVacia Then
                '    tabla.Rows.RemoveAt(f)
                '    fil -= 1
                'End If
            Next
            Return True
        Catch
            'Throw New Exception("Se encontraron filas en blanco y se intentó corregirlas.")
            Return False
        End Try
    End Function

    Public Shared Function corregirCeldasEnDataTable(ByRef dgv As DataTable)
        Dim col As Integer = dgv.Columns.Count
        Dim fil As Integer = dgv.Rows.Count
        For f As Integer = 0 To fil - 1 Step 1
            For c As Integer = 0 To col - 1 Step 1
                If dgv.Rows(f).Item(c) = vbNull Then
                    dgv.Rows(f).Item(c) = ""
                End If
                'dgv.Rows(f).Item(c) = RTrim(Replace(dgv.Rows(f).Item(c).ToString, vbNewLine, ""))
                'dgv.Item(c, f).Value = RTrim(Replace(dgv.Item(c, f).Value.ToString, vbNewLine, ""))
            Next
        Next
        Return True
    End Function

    Public Shared Sub aExcel(ds As DataSet, ls As List(Of String), nombreFormulario As String, CadenaParametros As String, Optional abreArchivo As Boolean = False)
        Using libro As XLWorkbook = New XLWorkbook
            Dim hoja As IXLWorksheet
            For i As Integer = 0 To ds.Tables.Count - 1 Step 1
                Dim nombreHoja As String = String.Empty
                If ls Is Nothing Then
                    nombreHoja = "Hoja" + (i + 1).ToString
                Else
                    nombreHoja = ls(i)
                End If
                'Dim nombreHoja As String = IIf(ls Is Nothing, "Hoja" + (i + 1).ToString, ls(i))
                hoja = libro.Worksheets.Add(nombreHoja)
                hoja.FirstCell().InsertTable(ds.Tables(i)).Theme = XLTableTheme.None
                hoja.Tables.FirstOrDefault().SetShowAutoFilter(False)

            Next

            Dim nombreArchivo As String = rutaReportes + "Dg" + Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"

            libro.SaveAs(nombreArchivo)
            'Dim inicio As Date = Date.Now
            Dim c As Double = 0
            For Each dt As DataTable In ds.Tables
                c += dt.Rows.Count * dt.Columns.Count
            Next
            If c < 600000 Then
                abreArchivo = True
                formatearExcel(nombreArchivo, nombreFormulario, CadenaParametros)
            End If
            If abreArchivo Then
                Process.Start(nombreArchivo)
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                'Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                'exLibro = exApp.Workbooks.Open(nombreArchivo)
                'exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
                'exApp.Application.Visible = True
            Else
                Shell("cmd.exe /c start """" """ & rutaReportes & """", vbNormalFocus)
            End If
            'Dim fin As Date = Date.Now
            'Dim procesos() As Process = Process.GetProcessesByName("EXCEL")
            'For Each proceso As Process In procesos
            '    If proceso.StartTime >= inicio And proceso.StartTime <= fin Then
            '        'proceso.Close()
            '        'proceso.Dispose()
            '        proceso.Kill()
            '        Exit For
            '    End If
            'Next

        End Using
    End Sub


    Public Shared Sub aExcel(dt As DataTable, ls As String, nombreFormulario As String, CadenaParametros As String, Optional abreArchivo As Boolean = False)
        'CREA LIBRO
        Using libro As XLWorkbook = New XLWorkbook
            'FUNCIONES PARA TRANSFERIR INFO A EXCEL
            Dim hoja As IXLWorksheet
            Dim nombreHoja As String = IIf(ls Is Nothing, "Reporte", ls)
            hoja = libro.Worksheets.Add(nombreHoja)
            hoja.FirstCell().InsertTable(dt).Theme = XLTableTheme.None
            hoja.Tables.FirstOrDefault().SetShowAutoFilter(False)

            'GUARDA ARCHIVO
            Dim nombreArchivo As String = rutaReportes + "Dg" + Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"
            libro.SaveAs(nombreArchivo)
            'Dim inicio As Date = Date.Now
            If dt.Rows.Count * dt.Columns.Count < 600000 Then
                abreArchivo = True
                formatearExcel(nombreArchivo, nombreFormulario, CadenaParametros)
            End If
            If abreArchivo Then
                Process.Start(nombreArchivo)
                'Dim exApp As New Microsoft.Office.Interop.Excel.Application
                'Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
                'exLibro = exApp.Workbooks.Open(nombreArchivo)
                'exApp.Application.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
                'exApp.Application.Visible = True
            Else
                Shell("cmd.exe /c start """" """ & rutaReportes & """", vbNormalFocus)
            End If
            'Dim fin As Date = Date.Now
            'Dim procesos() As Process = Process.GetProcessesByName("EXCEL")
            'For Each proceso As Process In procesos
            '    If Not abreArchivo AndAlso (proceso.StartTime >= inicio And proceso.StartTime <= fin) Then
            '        'proceso.Close()
            '        'proceso.Dispose()
            '        proceso.Kill()
            '        Exit For
            '    End If
            'Next
        End Using
    End Sub

    Public Shared Sub formatearExcel(nombreArchivo As String, nombreFormulario As String, CadenaParametros As String)
        Dim inicio As Date = Date.Now

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        'Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim separador As String = "|"
        exLibro = exApp.Workbooks.Open(nombreArchivo)
        ''exHoja = exLibro.Sheets(1)

        For Each exHoja As Microsoft.Office.Interop.Excel.Worksheet In exLibro.Sheets
            Dim c1 As Integer = 1, f1 As Integer = 1, c2 As Integer, f2 As Integer = 1
            c2 = exHoja.Cells.SpecialCells(xlLastCell).Column
            f2 = exHoja.Cells.SpecialCells(xlLastCell).Row ' 11 equivale a la constante XlLastCell

            'FORMATO GENERAL DE CELDAS
            exHoja.Cells.Font.Name = fuenteTablaReporte
            exHoja.Cells.Font.Size = 8
            exHoja.Cells.Font.Color = colTextoTabla

            'FORMATO DE CABECERA:
            exHoja.Cells.Range(exHoja.Cells(f1, c1), exHoja.Cells(f1, c2)).Interior.Color = colFondoCabecera 'RGB(255, 255, 255)
            exHoja.Rows.Item(f1).Font.Bold = 1
            exHoja.Rows.Item(f1).HorizontalAlignment = 3
            exHoja.Rows.Item(f1).Font.Color = colTextoCabecera
            exHoja.Rows.Item(f1).Font.Name = fuenteCabeceraTablaReporte
            exHoja.Rows.Item(f1).Font.Size = 10

            'FORMATEO DE COLUMNAS
            Dim n As String = ""
            Dim niveles As Integer = 1
            For i As Integer = 1 To c2 Step 1
                n = exHoja.Cells(f1, i).Value.ToString
                If n.Substring(0, 2).Equals("F_") Or
                n.Substring(0, 2).Equals("T_") Or
                n.Substring(0, 2).Equals("H1") Or
                (n.Substring(0, 1) = "D" And n.Substring(1, 1) >= "0" And n.Substring(1, 1) <= "9") Then
                    exHoja.Cells(f1, i) = n.Substring(2)
                End If
            Next

            'For i As Integer = 1 To c2 Step 1
            '    n = exHoja.Cells(f1, i).Value.ToString

            '    Dim nC As Integer = n.Split(separador).Length
            '    n = IIf(niveles < nC, nC, niveles) 'niveles de agrupacion para la fusion de cabeceras

            '    If n.Substring(0, 2) = "F_" Then
            '        exHoja.Columns(i).NumberFormat = "dd-mm-yyyy" 'POSIBLE CAUSA DE EERROR EN OTRAS COMPUTADORAS POR COMPATIBILIDAD DE IDIOMA
            '        exHoja.Cells(1, i) = n.Substring(2)
            '        exHoja.Columns(i).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            '    ElseIf n.Substring(0, 2) = "T_" Then
            '        exHoja.Columns(i).NumberFormat = "@"
            '        exHoja.Cells(1, i) = n.Substring(2)
            '        'ElseIf celda.Substring(0, 2) = "D_" Then
            '        '    exHoja.Columns(i).NumberFormat = "#,##0.000000"
            '        '    exHoja.Cells(1, i) = celda.Substring(2)
            '    ElseIf n.Substring(0, 2) = "H1" Then
            '        exHoja.Columns(i).NumberFormat = "dd-mm-yyyy HH:MM:ss"
            '        exHoja.Cells(1, i) = n.Substring(2)
            '    ElseIf n.Substring(0, 1) = "D" And n.Substring(1, 1) >= "0" And n.Substring(1, 1) <= "9" Then
            '        Dim ceros As Integer = CInt(n.Substring(1, 1))
            '        exHoja.Columns(i).NumberFormat = "#,##0." + StrDup(ceros, "0")
            '        exHoja.Cells(1, i) = n.Substring(2)
            '    Else
            '        exHoja.Cells(1, i) = n
            '    End If
            '    If i < NCol Then
            '        j = dgv.Columns.GetNextColumn(dgv.Columns(j), DataGridViewElementStates.Visible, DataGridViewElementStates.None).Index
            '    End If
            'Next

            'FORMATO DE BORDES:
            exHoja.Cells.Range(exHoja.Cells(f1, c1), exHoja.Cells(f2, c2)).Borders.Color = colBordeTabla
            exHoja.Cells.Range(exHoja.Cells(f1, c1), exHoja.Cells(f2, c2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            exHoja.Cells.Range(exHoja.Cells(f1, c1), exHoja.Cells(f2, c2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
            exHoja.Cells.Range(exHoja.Cells(f1, c1), exHoja.Cells(f2, c2)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
            exHoja.Cells.Range(exHoja.Cells(f1 + 1, c1), exHoja.Cells(f2, c2)).Interior.Color = RGB(255, 255, 255)

            exHoja.Columns.AutoFit()


            'AGREGADO PARA METADOS DE REPORTE:
            exHoja.Rows(f1).EntireRow.Insert()
            exHoja.Rows(f1).EntireRow.Insert()
            exHoja.Rows(f1).EntireRow.Insert()
            exHoja.Rows(f1).EntireRow.Insert()
            exHoja.Rows(f1).EntireRow.Insert()
            exHoja.Rows(f1).EntireRow.Insert()

            exHoja.Cells(1, c1).value = "Aplicativo:"
            exHoja.Cells(2, c1).value = "Reporte:"
            exHoja.Cells(3, c1).value = "Usuario:"
            exHoja.Cells(4, c1).value = "Consulta:"
            exHoja.Cells(5, c1).value = "Parametros:"

            'CONTINUAR AQUI:
            exHoja.Cells(1, c1 + 1).value = "[" + Aplicativo + "]"
            exHoja.Cells(2, c1 + 1).value = "[" + nombreFormulario + "]"
            exHoja.Cells(3, c1 + 1).value = "[" + usuarioActual + "]"
            exHoja.Cells(4, c1 + 1).value = "[" + Now.ToString + "]"
            exHoja.Cells(5, c1 + 1).value = "[" + CadenaParametros + "]"

            exHoja.Range("A1", "A5").HorizontalAlignment = xlRight
            exHoja.Range("A1", "B5").Font.Name = fuenteCabeceraTablaReporte
            exHoja.Range("A1", "B5").Font.Bold = 1

            'exHoja.Columns(1').EntireColumn.Insert()
            'exHoja.Cells(1, 1).select()
        Next
        exLibro.Save()

        exLibro.Close()

        exApp.Quit()
        'exApp.Hwnd
        Marshal.ReleaseComObject(exLibro)
        Marshal.ReleaseComObject(exApp)

        'Dim id As Integer = GetWindowThreadProcessId(exLibro.Hwnd, ExcelPID)

        'Dim hwd As Integer = exApp.Hwnd
        'Dim ProcIdXL As Integer = 0

        ''get the process ID
        'GetWindowThreadProcessId(hwd, ProcIdXL)

        ''get the process
        'Dim xproc As Process = Process.GetProcessById(ProcIdXL)

        'System.Runtime.InteropServices.GetWindowThreadProcessId(New IntPtr(exApp.Hwnd), processId)
        Dim fin As Date = Date.Now
        Dim procesos() As Process = Process.GetProcessesByName("EXCEL")
        For Each proceso As Process In procesos
            If proceso.StartTime >= inicio And proceso.StartTime <= fin Then
                'proceso.Close()
                'proceso.Dispose()
                proceso.Kill()
                Exit For
            End If
        Next
    End Sub

    Public Shared Sub realizarValidacionesIniciales()
        If Not System.IO.Directory.Exists(rutaReportes) Then
            My.Computer.FileSystem.CreateDirectory(rutaReportes)
        End If
        Dim dir As New DirectoryInfo(rutaReportes)
        Dim ts As TimeSpan
        For Each f In dir.GetFiles()
            ts = Now - f.CreationTime
            If ts.TotalDays > 7 Then
                'My.Computer.FileSystem.DeleteFile(rutaReportes + f.Name)
                System.IO.File.Delete(rutaReportes + f.Name)
            End If
            'MessageBox.Show(f.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"))
            'MessageBox.Show(f.Name)
            'Console.WriteLine(">> FILE-NAME: [" & f.Name & "]")
            'Console.WriteLine(">> UPDATE-DATE: " & f.LastWriteTime.ToString("yyyy-MM-dd"))
            'Console.WriteLine(">> CREATE-DATE: " & f.CreationTime.ToString("yyyy-MM-dd"))
        Next

    End Sub

    Public Shared Function ObtenerValoresEnArbol(nombreMenu As String, arbol As TreeView)
        Dim n As Integer
        Dim res As String = ""
        n = arbol.GetNodeCount(False)
        For i As Integer = 0 To n - 1 Step 1
            If nombreMenu = arbol.Nodes(i).Name Then
                If arbol.Nodes(i).Checked Then
                    Return "1"
                Else
                    Return "0"
                End If
            End If
            If arbol.Nodes(i).GetNodeCount(False) > 0 Then
                If ObtenerValoresEnRamas(nombreMenu, arbol.Nodes(i)) Then
                    Return "1"
                End If
            End If
        Next
        Return "0"
    End Function

    Public Shared Function ObtenerValoresEnRamas(nombreMenu As String, rama As TreeNode)
        Dim n As Integer
        Dim res As String = ""
        n = rama.GetNodeCount(False)
        For i As Integer = 0 To n - 1 Step 1
            If nombreMenu = rama.Nodes(i).Name Then
                If rama.Nodes(i).Checked Then
                    Return True
                Else
                    Return False
                End If
            End If
            If rama.GetNodeCount(False) > 0 Then
                If ObtenerValoresEnRamas(nombreMenu, rama.Nodes(i)) Then
                    Return True
                End If
                'Return ObtenerValoresEnRamas(nombreMenu, rama.Nodes(i))
            End If
        Next
        Return False
    End Function

    Public Shared Function SetearValoresEnArbol(nombreMenu As String, valor As Boolean, arbol As TreeView)
        Dim n As Integer
        Dim res As String = ""
        n = arbol.GetNodeCount(False)
        For i As Integer = 0 To n - 1 Step 1
            If nombreMenu = arbol.Nodes(i).Name Then
                arbol.Nodes(i).Checked = valor
                'If arbol.Nodes(i).Checked Then
                '    Return True
                'Else
                '    Return False
                'End If
                Return True
            End If
            If arbol.Nodes(i).GetNodeCount(False) > 0 Then
                If SetearValoresEnRamas(nombreMenu, valor, arbol.Nodes(i)) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Public Shared Function SetearValoresEnRamas(nombreMenu As String, valor As Boolean, rama As TreeNode)
        Dim n As Integer
        Dim res As String = ""
        n = rama.GetNodeCount(False)
        For i As Integer = 0 To n - 1 Step 1
            If nombreMenu = rama.Nodes(i).Name Then
                rama.Nodes(i).Checked = valor
                'If rama.Nodes(i).Checked Then
                '    Return True
                'Else
                '    Return False
                'End If
                Return True
            End If
            If rama.GetNodeCount(False) > 0 Then
                If SetearValoresEnRamas(nombreMenu, valor, rama.Nodes(i)) Then
                    Return True
                End If
                'Return SetearValoresEnRamas(nombreMenu, valor, rama.Nodes(i))
            End If
        Next
        Return False
    End Function

    'Public Shared Function execObtenerUltimaVersion(aplicativo As String)
    '    Dim parametros(0) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Aplicativo", SqlDbType.VarChar)
    '    parametros(0).Value = CType(aplicativo, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "spObtenerUltimaVersion",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        If Resultado.Rows.Count = 1 Then
    '            Return Resultado.Rows(0).Item(0).ToString
    '        End If
    '    Catch
    '        Return "" 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return ""
    'End Function

    'Public Shared Function execSp_DG_Rrhh_ValidarEstandares(periodo As String, semana As String, planilla As String)
    '    Dim parametros(2) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Periodo", SqlDbType.VarChar)
    '    parametros(0).Value = CType(periodo, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Semana", SqlDbType.VarChar)
    '    parametros(1).Value = CType(semana, String)
    '    parametros(2) = New SqlClient.SqlParameter("@planilla", SqlDbType.VarChar)
    '    parametros(2).Value = CType(planilla, String)
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_DG_Rrhh_ValidarEstandares",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Costos_ValidacionParaCierreDiario(dia As Date)
    '    Dim parametros(0) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Dia", SqlDbType.Date)
    '    parametros(0).Value = CType(dia, Date)
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_ValidacionParaCierreDiario",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Costos_Reglas_DataParaCombos()
    '    'Dim parametros(0) As SqlParameter
    '    'parametros(0) = New SqlClient.SqlParameter("@NoParameter", SqlDbType.VarChar)
    '    'parametros(0).Value = CType("", String)
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_DataParaCombos",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execsp_Dg_Costos_Reglas_Buscar(tipoCosto As String, codCultivo As String)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@TipoCosto", SqlDbType.VarChar)
    '    parametros(0).Value = CType(tipoCosto, String)
    '    parametros(1) = New SqlClient.SqlParameter("@CodCultivo", SqlDbType.VarChar)
    '    parametros(1).Value = CType(codCultivo, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Buscar",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Costos_Reglas_Insertar(arrayParametros() As String)
    '    Dim parametros(9) As SqlParameter
    '    Dim nombresParametros() As String = {"@TipoCosto", "@CodCultivo", "@CodActividad", "@Division", "@CGI", "@Tipo", "@CodTipoCampana", "@CodGrupo", "@CCFijo", "@CodCuenta"}
    '    Dim i As Integer = 0
    '    For Each p As String In arrayParametros
    '        parametros(i) = New SqlClient.SqlParameter(nombresParametros(i), SqlDbType.VarChar)
    '        parametros(i).Value = CType(arrayParametros(i), String)
    '        i = i + 1
    '    Next
    '    'parametros(0) = New SqlClient.SqlParameter("@TipoCosto", SqlDbType.VarChar)
    '    'parametros(0).Value = CType(tipoCosto, String)
    '    'parametros(1) = New SqlClient.SqlParameter("@CodCultivo", SqlDbType.VarChar)
    '    'parametros(1).Value = CType(codCultivo, String)
    '    'Dim Resultado As DataTable
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Insertar",
    '                                      parametros,
    '                                      1,
    '                                      True)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Costos_Reglas_Eliminar(arrayParametros() As String)
    '    Dim parametros(9) As SqlParameter
    '    Dim nombresParametros() As String = {"@TipoCosto", "@CodCultivo", "@CodActividad", "@Division", "@CGI", "@Tipo", "@CodTipoCampana", "@CodGrupo", "@CCFijo", "@CodCuenta"}
    '    Dim i As Integer = 0
    '    For Each p As String In arrayParametros
    '        parametros(i) = New SqlClient.SqlParameter(nombresParametros(i), SqlDbType.VarChar)
    '        parametros(i).Value = CType(arrayParametros(i), String)
    '        i = i + 1
    '    Next
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Eliminar",
    '                                      parametros,
    '                                      1,
    '                                      True)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Costos_CerrarDia(dia As Date, usuario As String)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Dia", SqlDbType.Date)
    '    parametros(0).Value = CType(dia, Date)
    '    parametros(1) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
    '    parametros(1).Value = CType(usuario, String)
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_CerrarDia",
    '                                      parametros,
    '                                      1,
    '                                      True)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Packing_Reportes_FurtaProcesada(desde As Date, hasta As Date)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Desde", SqlDbType.DateTime)
    '    parametros(0).Value = CType(desde, DateTime)
    '    parametros(1) = New SqlClient.SqlParameter("@Hasta", SqlDbType.DateTime)
    '    parametros(1).Value = CType(hasta, DateTime)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Packing_Reportes_FrutaProcesada",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Maquinaria_Reportes_ResumenUsoImplementoMaquinaLabor(desde As String, hasta As String, propietario As Integer, tipoReporte As Integer) As DataTable
    '    Dim parametros(3) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Desde", SqlDbType.VarChar)
    '    parametros(0).Value = CType(desde, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Hasta", SqlDbType.VarChar)
    '    parametros(1).Value = CType(hasta, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Propietario", SqlDbType.Int)
    '    parametros(2).Value = CType(propietario, Integer)
    '    parametros(3) = New SqlClient.SqlParameter("@TipoReporte", SqlDbType.Int)
    '    parametros(3).Value = CType(tipoReporte, Integer)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Maquinaria_Reportes_ResumenUsoImplementoMaquinaLabor",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_Dg_Almacenes_Reportes_Ingresos_DataParaCombos()
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "Sp_Dg_Almacenes_Reportes_Ingresos_DataParaCombos",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Almacenes_Reportes_Ingresos(IdEmp As String, IdSuc As String, IdAlm As String, Desde As String, Hasta As String, Motivo As String, IdProducto As String) As DataTable
    '    Dim parametros(6) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@IdEmp", SqlDbType.VarChar)
    '    parametros(0).Value = CType(IdEmp, String)
    '    parametros(1) = New SqlClient.SqlParameter("@IdSuc", SqlDbType.VarChar)
    '    parametros(1).Value = CType(IdSuc, String)
    '    parametros(2) = New SqlClient.SqlParameter("@IdAlm", SqlDbType.VarChar)
    '    parametros(2).Value = CType(IdAlm, String)
    '    parametros(3) = New SqlClient.SqlParameter("@Desde", SqlDbType.VarChar)
    '    parametros(3).Value = CType(Desde, String)
    '    parametros(4) = New SqlClient.SqlParameter("@Hasta", SqlDbType.VarChar)
    '    parametros(4).Value = CType(Hasta, String)
    '    parametros(5) = New SqlClient.SqlParameter("@Motivo", SqlDbType.VarChar)
    '    parametros(5).Value = CType(Motivo, String)
    '    parametros(6) = New SqlClient.SqlParameter("@IdProducto", SqlDbType.VarChar)
    '    parametros(6).Value = CType(IdProducto, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "Sp_Dg_Almacenes_Reportes_Ingresos",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_Dg_Produccion_Reportes_CosechaCampoConsolidado_DataParaCombos()
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Produccion_Reportes_CosechaCampoConsolidado_DataParaCombos",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Produccion_Reportes_CosechaCampoConsolidado(desde As String, hasta As String, cultivo As String, detalle As Boolean, detallecategorias As Boolean) As DataTable
    '    Dim parametros(4) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Desde", SqlDbType.Date)
    '    parametros(0).Value = CType(desde, Date)
    '    parametros(1) = New SqlClient.SqlParameter("@Hasta", SqlDbType.Date)
    '    parametros(1).Value = CType(hasta, Date)
    '    parametros(2) = New SqlClient.SqlParameter("@Cultivo", SqlDbType.VarChar)
    '    parametros(2).Value = CType(cultivo, String)
    '    parametros(3) = New SqlClient.SqlParameter("@Detalle", SqlDbType.Bit)
    '    parametros(3).Value = CType(detalle, Boolean)
    '    parametros(4) = New SqlClient.SqlParameter("@DetalleCategorias", SqlDbType.Bit)
    '    parametros(4).Value = CType(detallecategorias, Boolean)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Produccion_Reportes_CosechaCampoConsolidado",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_ObtenerConsultasSQLite(nombreConsulta As String, objetivo As String, Uso As String) As DataTable
    '    Dim parametros(2) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@NombreConsulta", SqlDbType.VarChar)
    '    parametros(0).Value = CType(nombreConsulta, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Objetivo", SqlDbType.VarChar)
    '    parametros(1).Value = CType(objetivo, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Uso", SqlDbType.VarChar)
    '    parametros(2).Value = CType(Uso, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_ObtenerConsultasSQLite",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_Dg_Produccion_Movimientos_ActualizarDatosPallets_CargarData()
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Produccion_Movimientos_ActualizarDatosPallets_CargarData",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Supervision_Movimientos_Tareos_CargarData()
    '    Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Supervision_Movimientos_Tareos_CargarData",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Produccion_Movimientos_ActualizarDatosPallets_DetallePallet(idRegistroPallet As String)
    '    Dim parametros(0) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@IdRegistroPallet", SqlDbType.VarChar)
    '    parametros(0).Value = CType(idRegistroPallet, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Produccion_Movimientos_ActualizarDatosPallets_DetallePallet",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Produccion_Movimientos_ActualizarDatosPallets(idRegistroPallet As String, item As String, idCliente As String, idEtiqueta As String, idCalibre As String) As Boolean
    '    Dim parametros(4) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@IdRegistroPallet", SqlDbType.VarChar)
    '    parametros(0).Value = CType(idRegistroPallet, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Items", SqlDbType.VarChar)
    '    parametros(1).Value = CType(item, String)
    '    parametros(2) = New SqlClient.SqlParameter("@IdCliente", SqlDbType.VarChar)
    '    parametros(2).Value = CType(idCliente, String)
    '    parametros(3) = New SqlClient.SqlParameter("@IdEtiqueta", SqlDbType.VarChar)
    '    parametros(3).Value = CType(idEtiqueta, String)
    '    parametros(4) = New SqlClient.SqlParameter("@IdCalibre", SqlDbType.VarChar)
    '    parametros(4).Value = CType(idCalibre, String)
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Produccion_Movimientos_ActualizarDatosPallets",
    '                                      parametros,
    '                                      Datos.TipoProcesamiento.NonQuery,
    '                                      False)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_Dg_Rrhh_Reportes_CostoPersonal_DetalleHorasPersonaActividadConsumidor(desde As DateTime, hasta As DateTime, planilla As String, detalle As Integer) As DataTable
    '    Dim parametros(3) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@Fecha_A", SqlDbType.DateTime)
    '    parametros(0).Value = CType(desde, DateTime)
    '    parametros(1) = New SqlClient.SqlParameter("@Fecha_Z", SqlDbType.DateTime)
    '    parametros(1).Value = CType(hasta, DateTime)
    '    parametros(2) = New SqlClient.SqlParameter("@CodPlanilla", SqlDbType.VarChar)
    '    parametros(2).Value = CType(planilla, String)
    '    parametros(3) = New SqlClient.SqlParameter("@Detalle_F", SqlDbType.Int)
    '    parametros(3).Value = CType(detalle, Integer)
    '    Dim Resultado As DataTable
    '    'MessageBox.Show(parametros(0).Value + "." + parametros(1).Value + "." + parametros(2).Value + "." + parametros(3).Value)
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Rrhh_Reportes_CostoPersonal_DetalleHorasPersonaActividadConsumidor",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function execSp_Dg_DescargarDataSqlite()
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_DescargarDataSqlite",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    'Public Shared Function execSp_Dg_Mantenimientos_MantenimientoUsuarios_CargarData()
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Mantenimientos_MantenimientoUsuarios_CargarData",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    Public Shared Function execSqlitePorNombre(nombreConsulta As String, parametros As DataTable, tipo As Integer)
        Dim codigoConsulta As String = String.Empty
        codigoConsulta = "SELECT CodigoConsulta FROM SqliteConsultas WHERE NombreConsulta='" + nombreConsulta + "'"
        Try
            Return ejecutarSqlite(ejecutarSqlite(codigoConsulta, tipoProceso.Scalar), tipo)
        Catch
            Return Nothing
        End Try
        'Return True
    End Function

    Public Shared Function generarNuevoId(id As String, tipo As Char) As String
        Dim nuevoId As String = String.Empty
        Dim longitud As Integer = 0
        Dim cursor As Integer = 0
        Dim caracter As Char
        Dim continuaBucle As Boolean = True
        Dim ultimoCaracterPosible As Char
        Dim aux As Char
        Dim secuencia As Char()
        longitud = id.Length
        If tipo = "A" Then
            secuencia = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Else
            secuencia = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        End If
        ultimoCaracterPosible = secuencia.Last
        cursor = longitud - 1
        While cursor >= 0 And continuaBucle
            caracter = id.Substring(cursor, 1)
            If caracter = ultimoCaracterPosible Then
                id = id.Substring(0, cursor) + "0" + id.Substring(cursor + 1)
            Else
                Dim i As Integer = 0
                For Each c As Char In secuencia
                    If c = caracter Then
                        Exit For
                    End If
                    i = i + 1
                Next
                aux = secuencia(i + 1)
                id = id.Substring(0, cursor) + aux + id.Substring(cursor + 1)
                continuaBucle = False
            End If
            cursor = cursor - 1
        End While
        Return id
    End Function

    'Public Shared Function execSP(nombreSP As String, parametros As DataTable) As Object
    '    Dim dicParametros As New Dictionary(Of String, SqlParameter)
    '    'dicParametros = Nothing
    '    For Each fila As DataRow In parametros.Rows
    '        Dim p As New SqlParameter(fila.Item(0).ToString, fila.Item(2).ToString)
    '        Select Case fila.Item(2).ToString
    '            Case "SqlDbType.VarChar"
    '                p.Value = CType(fila.Item(1), String)
    '            Case "SqlDbType.DateTime"
    '                p.Value = CType(fila.Item(1), DateTime)
    '            Case "SqlDbType.Date"
    '                p.Value = CType(fila.Item(1), Date)
    '            Case "SqlDbType.Char"
    '                p.Value = CType(fila.Item(1), Char)
    '        End Select
    '        dicParametros.Add(fila.Item(0).ToString, p)
    '    Next
    '    'Dim parametros(3) As SqlParameter
    '    'parametros(0) = New SqlClient.SqlParameter("@Fecha_A", SqlDbType.DateTime)
    '    'parametros(0).Value = CType(desde, DateTime)
    '    'parametros(1) = New SqlClient.SqlParameter("@Fecha_Z", SqlDbType.DateTime)
    '    'parametros(1).Value = CType(hasta, DateTime)
    '    'parametros(2) = New SqlClient.SqlParameter("@CodPlanilla", SqlDbType.VarChar)
    '    'parametros(2).Value = CType(planilla, String)
    '    'parametros(3) = New SqlClient.SqlParameter("@Detalle_F", SqlDbType.Int)
    '    'parametros(3).Value = CType(detalle, Integer)
    '    Dim Resultado As DataTable
    '    'MessageBox.Show(parametros(0).Value + "." + parametros(1).Value + "." + parametros(2).Value + "." + parametros(3).Value)
    '    Try
    '        Resultado = EjecutarProcedimiento(credenciales("BLNomCon"), nombreSP, dicParametros, 3, False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    'Public Shared Function exec(nombreSP As String, parametros As Dictionary(Of String, Object), t As TipoQuery) As Object
    '    Dim dicParametros As New Dictionary(Of String, SqlParameter)
    '    Dim aux As New SqlParameter
    '    Dim typeCode As New TypeCode
    '    If parametros IsNot Nothing Then
    '        For Each o As KeyValuePair(Of String, Object) In parametros
    '            typeCode = Type.GetTypeCode(o.Value.GetType())
    '            Select Case typeCode
    '                Case System.TypeCode.String
    '                    aux = New SqlParameter(o.Key, SqlDbType.VarChar)
    '                    aux.Value = CType(o.Value, String)
    '                Case System.TypeCode.DateTime
    '                    aux = New SqlParameter(o.Key, SqlDbType.DateTime)
    '                    aux.Value = CType(o.Value, Date)
    '            End Select
    '            dicParametros.Add(aux.ParameterName, aux)
    '        Next
    '    End If
    '    Try
    '        Return ejecutar(credenciales("BLNomCon"), nombreSP, dicParametros, t, False)
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    'Return Nothing
    'End Function

    Public Shared Function probarConexionDG() As Boolean
        If conectarBD(credenciales("BLNomCon")) IsNot Nothing Then
            cerrarBD()
            Return True
        End If
        Return False
    End Function

    'MicrosofT.Jet.OLEDB.4.0
    'CORRECTO
    '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaExcel + ";Extended Properties=""Excel 12.0 Xml;HDR=Yes""")
    'PRUEBA
    'Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + rutaExcel + ";Extended Properties='Excel 8.0; HDR=Yes;IMEX=1;'")
    Public Shared Function cargarExcel(rutaExcel As String) As DataTable
        Try
            Dim objEXCELCon As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + rutaExcel + ";Extended Properties='Excel 8.0; HDR=Yes;IMEX=1;'")
            objEXCELCon.Open()
            Dim objQuery As String = "SELECT * FROM [Hoja1$]"
            Dim objCMD As OleDb.OleDbCommand = New OleDb.OleDbCommand(objQuery, objEXCELCon)
            Dim objDR As OleDb.OleDbDataReader
            objDR = objCMD.ExecuteReader
            'Dim dtExcel As New DataTable
            'PENDIENTE
            Dim cols As Integer = objDR.FieldCount
            Dim aux As New DataTable
            For i As Integer = 0 To cols - 1 Step 1
                Dim tipo As String
                tipo = objDR.GetName(i).Substring(0, 2) ' dgv.Columns(i).Name.ToString.Substring(0, IIf(dgv.Columns(i).Name.ToString.Length >= 2, 2, 1))
                If tipo = "F_" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(Date))
                ElseIf tipo = "T_" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(String))
                ElseIf tipo = "H1" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(DateTime))
                ElseIf tipo.Substring(0, 1) = "D" AndAlso tipo.Substring(1, 1) >= "0" AndAlso tipo.Substring(1, 1) <= "9" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(Double))
                ElseIf tipo = "N_" Then 'tipo.Substring(0, 2) = "N_" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(Integer))
                ElseIf tipo.Substring(0, 1) = "P" AndAlso tipo.Substring(1, 1) >= "0" AndAlso tipo.Substring(1, 1) <= "9" Then
                    aux.Columns.Add(objDR.GetName(i), GetType(Double))
                Else
                    aux.Columns.Add(objDR.GetName(i))
                End If
            Next

            'OBTENER LA CANTIDAD DE COLUMNAS
            'CREAR UNA TABLA CON LA MISMA CANTIDAD DE COLUMNAS Y SUS RESPECTIVOS NOMBRES
            While objDR.Read()
                'INSERTAR CADA FILA EN LA TABLA CREADA CON EL FORMATO -> objDR.GetValue(N)
                Dim fila As DataRow = aux.NewRow
                For i As Integer = 0 To cols - 1 Step 1
                    fila.Item(i) = objDR.GetValue(i)
                Next
                aux.Rows.Add(fila)
            End While
            objDR.Close()
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Sub soloClavesUnicas(ByRef tabla As DataTable)
        Dim lista As New List(Of Integer)
        Dim i As Integer = 0
        For Each f As DataRow In tabla.Rows
            If f.Item(0).ToString.Contains("*") Then
                lista.Add(i)
            End If
            i += 1
        Next
        For Each item As Integer In lista
            tabla.Rows.RemoveAt(item)
        Next
    End Sub

    Public Shared Function buscarRegistro(texto As String, tabla As DataTable, columnaClave As Integer, columnaValor As Integer)
        For Each f As DataRow In tabla.Rows
            If f.Item(columnaClave).ToString = texto Then
                Return f.Item(columnaValor).ToString()
            End If
        Next
        Return ""
    End Function

    Public Shared Function buscarIndex(tabla As DataTable, texto As String, columnaClave As Integer)
        For i As Integer = 0 To tabla.Rows.Count - 1 Step 1
            If tabla.Rows(i).Item(columnaClave).ToString = texto Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Shared Function calcularMaximoNivelAgrupamiento(celda As String, niveles As Integer) As Integer
        Dim a As String() = celda.Split("|")
        Dim r As Integer = 0
        For Each e In a
            If Len(e) > 0 Then
                r += 1
            End If
        Next
        Return IIf(r > niveles, r, niveles)
    End Function

    'Private Shared Function partirNiveles(p1 As Object) As String()
    '    Throw New NotImplementedException
    'End Function

    Public Shared Function convertirFilaADiccionario(dgv As DataGridView, i As Integer) As Dictionary(Of String, Object)
        Dim r As New Dictionary(Of String, Object)
        If i >= 0 And dgv.Rows.Count > 0 Then
            For j As Integer = 0 To dgv.Columns.Count - 1 Step 1
                r.Add(dgv.Columns(j).Name, dgv.Rows(i).Cells(j).Value)
            Next
        End If
        Return r
    End Function

    Public Shared Function convertirFilaADiccionario(dgv As DataTable, i As Integer) As Dictionary(Of String, Object)
        Dim r As New Dictionary(Of String, Object)
        If i >= 0 And dgv.Rows.Count > 0 Then
            For j As Integer = 0 To dgv.Columns.Count - 1 Step 1
                r.Add(dgv.Columns(j).ColumnName, dgv.Rows(i).Item(j).Value)
            Next
        End If
        Return r
    End Function

    Public Shared Function convertirFilaADiccionario(f As DataRow) As Dictionary(Of String, Object)
        Dim r As New Dictionary(Of String, Object)
        For i As Integer = 0 To f.ItemArray.Count - 1 Step 1
            r.Add(f.Table.Columns(i).ColumnName, f.Item(i))
        Next
        Return r
    End Function

    Public Shared Function convertirDicionarioEnFila(d As Dictionary(Of String, Object), dt As DataTable) As DataRow
        Dim r As DataRow = dt.NewRow()
        For i As Integer = 0 To d.Count - 1 Step 1
            r.Item(i) = d.ElementAt(i).Value
        Next
        Return r
    End Function

    Public Shared Function convertirDicionarioATabla(d As Dictionary(Of String, Object)) As DataTable
        Dim r As DataTable = New DataTable
        Dim i As Integer
        For i = 0 To d.Count - 1 Step 1
            r.Columns.Add(d.ElementAt(i).Key)
        Next
        Dim f As DataRow = r.NewRow()
        For i = 0 To d.Count - 1 Step 1
            f.Item(i) = d.ElementAt(i).Value
        Next
        r.Rows.Add(f)
        Return r
    End Function

    Public Shared Function convertirRegistroATabla(d As Registro) As DataTable
        Dim r As DataTable = New DataTable
        Dim i As Integer
        For i = 0 To d.Count - 1 Step 1
            r.Columns.Add(d.ElementAt(i).Key)
        Next
        Dim f As DataRow = r.NewRow()
        For i = 0 To d.Count - 1 Step 1
            f.Item(i) = d.ElementAt(i).Value
        Next
        r.Rows.Add(f)
        Return r
    End Function

    'Public Shared Function convertirDicionarioEnFila(cv As Dictionary(Of String, Object)) As DataRow
    '    Dim r As DataRow '= dt.NewRow()
    '    For i As Integer = 0 To cv.Count - 1 Step 1
    '        r.Item(i) = cv.ElementAt(i).Value
    '    Next
    '    Return r
    'End Function

    Public Shared Function generarCorrelativo(valor As Integer, nCarateres As Integer) As String
        Return StrDup(nCarateres - valor.ToString.Length, "0") & valor.ToString
    End Function

    Public Shared Function obtenerTablaParaSP(dtAux As DataTable) As DataTable
        Dim aux As New DataTable
        For i As Integer = 1 To 20 Step 1
            'If dtAux.Columns(i).ColumnName.Substring(0, 2) = "F_" Then
            '    aux.Columns.Add("C" & i.ToString, dtAux.Columns(i).DataType)
            'Else
            '    aux.Columns.Add("C" & i.ToString)
            'End If
            If i <= dtAux.Columns.Count - 1 Then
                aux.Columns.Add("C" & i.ToString, dtAux.Columns(i - 1).DataType)
            Else
                aux.Columns.Add("C" & i.ToString)
            End If
            'aux.Columns.Add("C" & i.ToString, dtAux.Columns(i).DataType)
        Next
        For i As Integer = 0 To dtAux.Rows.Count - 1 Step 1
            Dim fAux As DataRow = aux.NewRow
            For j As Integer = 0 To dtAux.Columns.Count - 1 Step 1
                'If dtAux.Columns(j).ColumnName.Substring(0, 2) = "F_" Then
                '    fAux.Item(j) = dtAux.Rows(i).Item(j).ToString("yyyy-MM-dd")
                'Else
                '    fAux.Item(j) = dtAux.Rows(i).Item(j)
                'End If
                fAux.Item(j) = dtAux.Rows(i).Item(j)
            Next
            aux.Rows.Add(fAux)
        Next
        Return aux
    End Function

End Class
