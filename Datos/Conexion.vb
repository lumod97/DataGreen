Imports System.Data.SqlClient
Imports Entidades.Temporales
Imports System.Net.NetworkInformation

'Imports Entidades.Credenciales
'Imports Entidades.Consultas

Public Enum TipoProcesamiento
    NonQuery = 1
    Scalar = 2
    DataTable = 3
    DataSet = 4
End Enum

Public Class Conexion
    Public Enum TipoQuery
        NonQuery = 1
        Scalar = 2
        DataTable = 3
        DataSet = 4
    End Enum
    'Private cn As SqlConnection
    'Private da As SqlDataAdapter
    'Private dt As DataTable
    'Private cm As SqlCommand
    'Private dr As SqlDataReader
    'Public Shared parametros(20) As String

    Public Shared Function conectarBD(ByVal NombreConexion As String) As SqlConnection
        'Dim Conx As SqlConnection
        Dim cadenaconexion As String = ""
        'SELECCIONA UNA DE LAS DOS CONEXIONES DISPONIBLES
        If NombreConexion = credenciales("BLNomCon") Then
            'MODIFICACIONES HATCH 2024-06-05
            'cadenaconexion = "Data Source=" + credenciales("BLServid") +
            '                        ";Max Pool Size=10024 " +
            '                       ";Initial Catalog=" + credenciales("BLNomBas") +
            '                       ";User ID=" + credenciales("BLUsuari") +
            '                       ";Password=" + credenciales("BLPasswo")
            cadenaconexion = "Data Source= TINAJONES; Max Pool Size=10024 " +
                                   ";Initial Catalog=" + credenciales("BLNomBas") +
                                   ";User ID=" + credenciales("BLUsuari") +
                                   ";Password=" + credenciales("BLPasswo")
        ElseIf NombreConexion = credenciales("BENomCon") Then
            'cadenaconexion = "Data Source=" + credenciales("BEServid") +
            '                        ";Max Pool Size=10024 " +
            '                       ";Initial Catalog=" + credenciales("BENomBas") +
            '                       ";User ID=" + credenciales("BEUsuari") +
            '                       ";Password=" + credenciales("BEPasswo")
            cadenaconexion = "Data Source= TINAJONES ;Max Pool Size=10024 " +
                                   ";Initial Catalog=" + credenciales("BENomBas") +
                                   ";User ID=" + credenciales("BEUsuari") +
                                   ";Password=" + credenciales("BEPasswo")

        End If
        Conx = New SqlConnection(cadenaconexion)
        Try
            Conx.Open()
            'MessageBox.Show("Conectado")
        Catch ex As Exception
            'MessageBox.Show("Error de conexion")
            Return Nothing
        End Try
        Return Conx
    End Function

    Public Shared Function cerrarBD() As SqlConnection
        Conx.Close()
        Return Conx
    End Function

    Public Shared Function EjecutarConsulta(ByVal NombreConexion As String, ByVal cConsulta As String, ByVal cTipoProceso As TipoQuery, ByVal cParametros As String(), Optional ByVal bAlerta As Boolean = True) As Object
        Try
            conectarBD(NombreConexion)
            If cTipoProceso = TipoQuery.NonQuery Then
                Comd = New SqlCommand(cConsulta, Conx)
                Comd.ExecuteNonQuery()
                Return True
            ElseIf cTipoProceso = TipoQuery.Scalar Then
                Comd = New SqlCommand(cConsulta, Conx)
                Return Comd.ExecuteScalar()
            ElseIf cTipoProceso = TipoQuery.DataTable Then
                Dada = New SqlDataAdapter(cConsulta, Conx)
                Dada.SelectCommand = New SqlCommand(cConsulta, Conx)
                Dim i As Integer = 0
                '///RECORRE TODOS LOS ITEMS DEL ARRAY PARAMETROS Y LOS AGREGA A SQLCOMMAND
                Dim j = cParametros.Length
                While i < j
                    If Not String.IsNullOrEmpty(cParametros(i)) Then
                        Dada.SelectCommand.Parameters.Add("Param" + (i + 1).ToString, SqlDbType.VarChar)
                        Dada.SelectCommand.Parameters("Param" + (i + 1).ToString).Value = cParametros(i)
                    End If
                    i = i + 1
                End While
                '///LLENA EL DATAGRIDVIEW
                Dtab = New DataTable()
                Dada.Fill(Dtab)
                Return Dtab
            Else
                Throw New Exception("Tipo de procesamiento no válido")
            End If
        Catch ex As Exception
            If bAlerta = True Then
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End If
            Return Nothing
        Finally
            cerrarBD()
        End Try
    End Function

    Public Shared Function EjecutarProcedure(ByVal NombreConexion As String, ByVal cNombreProcedure As String, ByVal pParametros() As SqlParameter, ByVal cTipoProceso As TipoQuery, Optional ByVal bAlerta As Boolean = True) As Object
        Try
            conectarBD(NombreConexion)
            Dim cm As New SqlCommand
            cm = New SqlCommand(cNombreProcedure, Conx)
            cm.CommandType = CommandType.StoredProcedure
            If Not pParametros Is Nothing Then
                cm.Parameters.AddRange(pParametros)
                'cm.Parameters.
            End If
            cm.CommandTimeout = 999999
            If cTipoProceso = TipoQuery.NonQuery Then
                cm.ExecuteNonQuery()
                Return True
            ElseIf cTipoProceso = TipoQuery.Scalar Then
                Return cm.ExecuteScalar
            ElseIf cTipoProceso = TipoQuery.DataTable Then
                If cNombreProcedure <> "spLogs" Then
                    EjecutarProcedure(credenciales("BLNomCon"),
                                        "spLogs",
                                        parametrosLogs(cNombreProcedure, pParametros),
                                              3,
                                             False)
                End If
                Dada = New SqlDataAdapter(cm)
                Dtab = New DataTable()
                'If cNombreProcedure = "sp_DG_Rrhh_ValidarEstandares" Then
                '    Dim Dset As DataSet = New DataSet()
                '    Dada.Fill(Dset)
                '    Return Dset
                'Else
                Dada.Fill(Dtab)
                Return Dtab
                'End If
                'Dada.Fill(Dtab)
                'Return Dtab

                'End If
                'Return Nothing 'Dtab
            Else
                Throw New Exception("Tipo de procesamiento no válido")
            End If
        Catch ex As Exception
            If bAlerta = True Then
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End If
            Return Nothing
        Finally
            cerrarBD()
        End Try
    End Function

    Public Shared Function EjecutarProcedureMultiResultado(ByVal NombreConexion As String, ByVal cNombreProcedure As String, ByVal pParametros() As SqlParameter, ByVal cTipoProceso As TipoQuery, Optional ByVal bAlerta As Boolean = True) As Object
        Try
            conectarBD(NombreConexion)
            Dim cm As New SqlCommand
            cm = New SqlCommand(cNombreProcedure, Conx)
            cm.CommandType = CommandType.StoredProcedure
            If Not pParametros Is Nothing Then
                cm.Parameters.AddRange(pParametros)
            End If
            'cm.Parameters.AddRange(pParametros)
            cm.CommandTimeout = 999999
            If cTipoProceso = TipoQuery.NonQuery Then
                cm.ExecuteNonQuery()
                Return True
            ElseIf cTipoProceso = TipoQuery.Scalar Then
                Return cm.ExecuteScalar
            ElseIf cTipoProceso = TipoQuery.DataTable Then
                If cNombreProcedure <> "spLogs" Then
                    EjecutarProcedure(credenciales("BLNomCon"),
                                        "spLogs",
                                        parametrosLogs(cNombreProcedure, pParametros),
                                              3,
                                             False)
                End If
                Dada = New SqlDataAdapter(cm)
                Dtab = New DataTable()
                Dim Dset As DataSet = New DataSet()
                Dada.Fill(Dset)
                Return Dset
            Else
                Throw New Exception("Tipo de procesamiento no válido")
            End If
        Catch ex As Exception
            If bAlerta = True Then
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End If
            Return Nothing
        Finally
            cerrarBD()
        End Try
    End Function

    Public Shared Function parametrosLogs(nombreSP As String, p() As SqlParameter) As SqlParameter()
        Dim parametros(5) As SqlParameter
        parametros(0) = New SqlClient.SqlParameter("@Momento", SqlDbType.DateTime)
        parametros(0).Value = CType(Now.ToString, DateTime)
        parametros(1) = New SqlClient.SqlParameter("@Mac", SqlDbType.VarChar)
        parametros(1).Value = CType(getMac(), String)
        parametros(2) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
        parametros(2).Value = CType(usuarioActual, String)
        parametros(3) = New SqlClient.SqlParameter("@Aplicativo", SqlDbType.VarChar)
        parametros(3).Value = CType("DataGreen", String)
        parametros(4) = New SqlClient.SqlParameter("@Descripcion", SqlDbType.VarChar)
        parametros(4).Value = CType(nombreSP, String)
        Dim cadParametros As String = ""
        Dim i As Integer = 0
        If Not p Is Nothing Then
            For i = 0 To UBound(p) Step 1
                cadParametros = cadParametros + p(i).ParameterName.ToString + "[" + p(i).Value.ToString + "], "
            Next
        Else
            cadParametros = "Sin Parametros"
        End If
        parametros(5) = New SqlClient.SqlParameter("@Parametros", SqlDbType.VarChar)
        parametros(5).Value = CType(cadParametros, String)
        Return parametros
    End Function

    Public Shared Function getMac()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Dim mac As String = nics(0).GetPhysicalAddress.ToString
        For i = nics.Rank To 0 Step -1
            If nics(i).OperationalStatus.ToString.ToLower.Equals("up") Then
                mac = nics(0).GetPhysicalAddress.ToString
            End If
        Next
        Return mac
    End Function

    Public Shared Function EjecutarProcedimiento(ByVal NombreConexion As String, ByVal cNombreProcedure As String, ByVal parametros As Dictionary(Of String, SqlParameter), ByVal cTipoProceso As TipoQuery, Optional ByVal bAlerta As Boolean = True) As Object
        Try
            conectarBD(NombreConexion)
            Dim cm As New SqlCommand
            cm = New SqlCommand(cNombreProcedure, Conx)
            cm.CommandType = CommandType.StoredProcedure
            If Not parametros Is Nothing Then
                For Each p As KeyValuePair(Of String, SqlParameter) In parametros
                    cm.Parameters.Add(p.Value)
                Next
                'cm.Parameters.AddRange(pParametros)
                'cm.Parameters.
            End If
            cm.CommandTimeout = 999999
            If cTipoProceso = TipoQuery.NonQuery Then
                cm.ExecuteNonQuery()
                Return True
            ElseIf cTipoProceso = TipoQuery.Scalar Then
                Return cm.ExecuteScalar
            ElseIf cTipoProceso = TipoQuery.DataTable Then
                'If cNombreProcedure <> "spLogs" Then
                '    EjecutarProcedure(credenciales("BLNomCon"),
                '    "spLogs",
                '    parametrosLogs(cNombreProcedure, pParametros),
                '          3,
                '         False)
                'End If
                Dada = New SqlDataAdapter(cm)
                Dtab = New DataTable()
                'If cNombreProcedure = "sp_DG_Rrhh_ValidarEstandares" Then
                '    Dim Dset As DataSet = New DataSet()
                '    Dada.Fill(Dset)
                '    Return Dset
                'Else
                Dada.Fill(Dtab)
                Return Dtab
                'End If
                'Dada.Fill(Dtab)
                'Return Dtab

                'End If
                'Return Nothing 'Dtab
            Else
                Throw New Exception("Tipo de procesamiento no válido")
            End If
        Catch ex As Exception
            If bAlerta = True Then
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End If
            Return Nothing
        Finally
            cerrarBD()
        End Try
    End Function

    Public Shared Function ejecutar(ByVal NombreConexion As String, ByVal cNombreProcedure As String, ByVal parametros As Dictionary(Of String, SqlParameter), ByVal cTipoProceso As TipoQuery, Optional ByVal bAlerta As Boolean = True) As Object
        Try
            conectarBD(NombreConexion)
            Dim cm As New SqlCommand
            cm = New SqlCommand(cNombreProcedure, Conx)
            cm.CommandType = CommandType.StoredProcedure
            If Not parametros Is Nothing Then
                For Each p As KeyValuePair(Of String, SqlParameter) In parametros
                    cm.Parameters.Add(p.Value)
                Next
            End If
            cm.CommandTimeout = 999999
            If cNombreProcedure <> "spLogs" Then
                ejecutar(credenciales("BLNomCon"),
                                    "spLogs",
                                    encapsulaParametros(cNombreProcedure, parametros),
                                          3,
                                         False)
            End If
            If cTipoProceso = TipoQuery.NonQuery Then
                cm.ExecuteNonQuery()
                Return True
            ElseIf cTipoProceso = TipoQuery.Scalar Then
                Return cm.ExecuteScalar
            ElseIf cTipoProceso = TipoQuery.DataTable Or cTipoProceso = TipoQuery.DataSet Then
                'If cNombreProcedure <> "spLogs" Then
                '    ejecutar(credenciales("BLNomCon"),
                '                        "spLogs",
                '                        encapsulaParametros(cNombreProcedure, parametros),
                '                              3,
                '                             False)
                'End If
                If cTipoProceso = TipoQuery.DataTable Then
                    Dada = New SqlDataAdapter(cm)
                    Dtab = New DataTable()
                    Dada.Fill(Dtab)
                    Return Dtab
                ElseIf cTipoProceso = TipoQuery.DataSet Then
                    Dada = New SqlDataAdapter(cm)
                    Dtab = New DataTable()
                    Dim Dset As DataSet = New DataSet()
                    Dada.Fill(Dset)
                    Return Dset
                End If
                Return Nothing
            Else
                Throw New Exception("Tipo de procesamiento no válido")
            End If
        Catch ex As Exception
            If bAlerta = True Then
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End If
            Return Nothing
        Finally
            cerrarBD()
        End Try
    End Function

    Public Shared Function encapsulaParametros(nombreSP As String, dicParametros As Dictionary(Of String, SqlParameter)) As Dictionary(Of String, SqlParameter)
        Dim resultado As New Dictionary(Of String, SqlParameter)
        Dim parametros(5) As SqlParameter
        parametros(0) = New SqlClient.SqlParameter("@Momento", SqlDbType.DateTime)
        parametros(0).Value = CType(Now.ToString, DateTime)
        parametros(1) = New SqlClient.SqlParameter("@Mac", SqlDbType.VarChar)
        parametros(1).Value = CType(getMac(), String)
        parametros(2) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
        parametros(2).Value = CType(usuarioActual, String)
        parametros(3) = New SqlClient.SqlParameter("@Aplicativo", SqlDbType.VarChar)
        parametros(3).Value = CType("DataGreen", String)
        parametros(4) = New SqlClient.SqlParameter("@Descripcion", SqlDbType.VarChar)
        parametros(4).Value = CType(nombreSP, String)
        Dim cadParametros As String = ""
        Dim i As Integer = 0
        If Not dicParametros Is Nothing Then
            For Each p As KeyValuePair(Of String, SqlParameter) In dicParametros
                cadParametros = cadParametros + p.Value.ParameterName.ToString + "[" + p.Value.Value.ToString + "], "
            Next
        Else
            cadParametros = "Sin Parametros"
        End If
        parametros(5) = New SqlClient.SqlParameter("@Parametros", SqlDbType.VarChar)
        parametros(5).Value = CType(cadParametros, String)

        'resultado.Add(parametros(0).ParameterName, parametros(0))
        'resultado.Add(parametros(1).ParameterName, parametros(1))
        'resultado.Add(parametros(2).ParameterName, parametros(2))
        'resultado.Add(parametros(3).ParameterName, parametros(3))
        'resultado.Add(parametros(4).ParameterName, parametros(4))
        'resultado.Add(parametros(5).ParameterName, parametros(5))
        For i = 0 To UBound(parametros) Step 1
            resultado.Add(parametros(i).ParameterName, parametros(i))
            'cadParametros = cadParametros + p(i).ParameterName.ToString + "[" + p(i).Value.ToString + "], "
        Next

        Return resultado
    End Function

    'doItBaby SE CONECTA A UNA BASE Y EJECUTA UN SP
    Public Shared Function doItBaby(nombreSP As String, parametros As Dictionary(Of String, Object), t As TipoQuery) As Object
        'Try
        conectarBD(credenciales("BLNomCon"))
        Dim cm As New SqlCommand
        cm = New SqlCommand(nombreSP, Conx)
        'cm.Connection = New SqlConnection(Conx)
        cm.CommandType = CommandType.StoredProcedure
        If parametros IsNot Nothing Then
            'Dim params() As SqlParameter
            Dim aux As New SqlParameter
            'Dim i As Int'eger = 0
            Dim typeCode As New TypeCode
            For Each o As KeyValuePair(Of String, Object) In parametros
                typeCode = Type.GetTypeCode(o.Value.GetType())
                Select Case typeCode
                    Case System.TypeCode.String
                        aux = New SqlParameter(o.Key, SqlDbType.VarChar)
                        aux.Value = CType(o.Value, String)
                    Case System.TypeCode.DateTime
                        Dim f As DateTime = CType(o.Value.ToString, DateTime)
                        If f.Hour = 0 And f.Minute = 0 And f.Second = 0 Then
                            aux = New SqlParameter(o.Key, SqlDbType.Date)
                            aux.Value = CType(o.Value, Date)
                        Else
                            aux = New SqlParameter(o.Key, SqlDbType.DateTime)
                            aux.Value = CType(o.Value, DateTime)
                        End If
                    Case System.TypeCode.Boolean
                        aux = New SqlParameter(o.Key, SqlDbType.Bit)
                        aux.Value = CType(o.Value, Boolean)
                    Case System.TypeCode.Int32
                        aux = New SqlParameter(o.Key, SqlDbType.Int)
                        aux.Value = CType(o.Value, Integer)
                    Case System.TypeCode.Double
                        aux = New SqlParameter(o.Key, SqlDbType.Decimal)
                        aux.Value = CType(o.Value, Double)
                End Select
                'ARREGLO PARA RECIBIR Y TRATAR TABLAS COMO PARAMETROS
                If o.Key.Substring(0, 3) <> "@dt" Then
                    cm.Parameters.Add(aux)
                Else
                    cm.Parameters.AddWithValue(o.Key, o.Value)
                End If
            Next
        End If
        Try
            'Return ejecutar(credenciales("BLNomCon"), nombreSP, dicParametros, t, False)

            'Dim cm As New SqlCommand
            'cm = New SqlCommand(nombreSP, Conx)
            'cm.CommandType = CommandType.StoredProcedure
            'If Not parametros Is Nothing Then
            '    For Each p As KeyValuePair(Of String, SqlParameter) In parametros
            '        cm.Parameters.Add(p.Value)
            '    Next
            'End If
            cm.CommandTimeout = 999999
            If nombreSP <> "sp_CrearLog" Then
                doItBaby("sp_CrearLog", parametrosADiccionario(nombreSP, cm.Parameters), TipoQuery.NonQuery)
            End If
            If t = TipoQuery.NonQuery Then
                cm.ExecuteNonQuery()
                Return True
            ElseIf t = TipoQuery.Scalar Then
                Return cm.ExecuteScalar
            ElseIf t = TipoQuery.DataTable Then
                Dada = New SqlDataAdapter(cm)
                Dtab = New DataTable()
                Dada.Fill(Dtab)
                Return Dtab
            ElseIf t = TipoQuery.DataSet Then
                Dada = New SqlDataAdapter(cm)
                Dtab = New DataTable()
                Dim Dset As DataSet = New DataSet()
                Dada.Fill(Dset)
                Return Dset
            End If
            Return Nothing
        Catch ex As Exception
            'Throw New Exception(ex.Message)
            'PENDIENTE LANZAR EXCEPCION
            'Throw Exception
            'If bAlerta = True Then
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            If t = TipoQuery.NonQuery Then
                Return False
            ElseIf t = TipoQuery.DataTable Then
                Return New DataTable
            Else
                Return Nothing
            End If
            'Console.WriteLine(ex.GetType().FullName)
            'Console.WriteLine(ex.Message)
        Finally
            cerrarBD()
        End Try
        'Catch
        '    Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
        'End Try
        'Return Nothing
    End Function

    Public Shared Function parametrosADiccionario(nombreSP As String, colParametros As SqlParameterCollection) As Dictionary(Of String, Object)
        Dim resultado As New Dictionary(Of String, Object)

        'resultado.Add("@IdTareo", tareoActual.Id)
        'Dim aux As SqlParameter
        'Dim parametros() As SqlParameter
        'parametros(0) = New SqlClient.SqlParameter("@Momento", SqlDbType.DateTime)
        'parametros(0).Value = CType(Now.ToString, DateTime)
        'parametros(0) = New SqlClient.SqlParameter("@Mac", SqlDbType.VarChar)
        'parametros(0).Value = CType(getMac(), String)
        'aux = New SqlClient.SqlParameter("@Mac", SqlDbType.VarChar)
        'aux.Value = CType(getMac(), String)
        resultado.Add("@Mac", CType(getMac(), String))
        'aux = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
        'aux.Value = CType(usuarioActual, String)
        resultado.Add("@Usuario", CType(usuarioActual, String))
        'aux = New SqlClient.SqlParameter("@Aplicativo", SqlDbType.VarChar)
        'aux.Value = CType("DataGreen", String)
        resultado.Add("@Aplicativo", CType("DataGreen", String))
        'aux = New SqlClient.SqlParameter("@Descripcion", SqlDbType.VarChar)
        'aux.Value = CType(nombreSP, String)
        resultado.Add("@Descripcion", CType(nombreSP, String))

        'parametros(1) = New SqlClient.SqlParameter("@Usuario", SqlDbType.VarChar)
        'parametros(1).Value = CType(usuarioActual, String)
        'parametros(2) = New SqlClient.SqlParameter("@Aplicativo", SqlDbType.VarChar)
        'parametros(2).Value = CType("DataGreen", String)
        'parametros(3) = New SqlClient.SqlParameter("@Descripcion", SqlDbType.VarChar)
        'parametros(3).Value = CType(nombreSP, String)
        Dim cadParametros As String = ""
        Dim i As Integer = 0
        If colParametros.Count > 0 Then
            For Each p As SqlParameter In colParametros
                cadParametros = cadParametros + p.ParameterName.ToString + "[" + p.Value.ToString + "], "
            Next
        Else
            cadParametros = "Sin Parametros"
        End If
        'parametros(4) = New SqlClient.SqlParameter("@Parametros", SqlDbType.VarChar)
        'parametros(4).Value = CType(cadParametros, String)
        'aux = New SqlClient.SqlParameter("@Parametros", SqlDbType.VarChar)
        'aux.Value = CType(cadParametros, String)
        resultado.Add("@Parametros", CType(cadParametros, String))

        'For i = 0 To UBound(parametros) Step 1
        '    'resultado.Add(parametros(i).ParameterName, parametros(i))
        '    'cadParametros = cadParametros + p(i).ParameterName.ToString + "[" + p(i).Value.ToString + "], "
        'Next
        Return resultado
    End Function


End Class
