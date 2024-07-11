Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO

Public Class Temporales
    Public Shared Aplicativo As String = "DataGreen" '2021-07-28
    Public Shared versionActual As String = "6.0.4" '2024-07-11
    Public Shared versionDisponible As String = ""
    Public Shared modulosPermitidos As New Dictionary(Of String, Boolean)
    Public Shared nTotalModulos As Integer = 0
    Public Shared agrupadorFilasExcel As Integer = 1000
    'Public Shared credenciales As New Dictionary(Of String, String)
    Public Shared credenciales As New Dictionary(Of String, String)
    Public Shared unidadPrincipal As String = Path.GetPathRoot(Environment.SystemDirectory)
    Public Shared rutaGeneral As String = unidadPrincipal + "DataGreen\"
    Public Shared rutaSqlite As String = "Sqlite\"
    Public Shared rutaTemp As String = "Temp\"
    Public Shared rutaReportes As String = rutaGeneral + "Reportes\"
    Public Shared archivoConf As String = "Conf.cnf" 'CNF= configuracion
    Public Shared archivoTemp As String = "Temp.txt" 'CNF= configuracion
    Public Shared llave As Integer = 8 'cifrado simple, no mover este valor
    Public Shared permisosUsuario As String = "0"
    Public Shared pwc = "0" 'password character
    'Public Shared dniParaCambio As String = ""
    Public Shared usuarioActual As String = ""
    Public Shared Conx As SqlConnection
    Public Shared Comd As SqlCommand
    Public Shared Dada As SqlDataAdapter
    Public Shared Dtab As DataTable
    Public Shared bdSqlite As String = rutaGeneral + rutaSqlite + "SqliteDataGreen.db"
    Public Shared cadenaConexionSqlite As String = "Data Source=" + bdSqlite + ";Version=3;"

    '------
    Public Shared fuenteCabeceraTablaReporte As String = "Flexo"
    Public Shared fuenteTablaReporte As String = "Ubuntu Mono"
    Public Shared colTextoTabla As Integer = RGB(89, 89, 89)
    Public Shared colTextoCabecera As Integer = RGB(255, 255, 255)
    'Public Shared colFondoCabecera As Integer = RGB(0, 170, 170) 'RGB(118, 184, 178)
    Public Shared colFondoCabecera As Integer = RGB(104, 200, 210) 'RGB(118, 184, 178) Color Inspirado en reporte de gloria
    Public Shared colBordeTabla As Integer = RGB(104, 200, 210) 'RGB(130, 130, 130)
    Public Shared colorAlerta As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFFF9090")
    Public Shared colFondoNuevaCabecera As Integer = RGB(118, 184, 178)
    Public Shared colFondoAgrupado1 As Integer = RGB(255, 255, 255)
    Public Shared colFondoAgrupado2 As Integer = RGB(235, 235, 235)


    'PARA TEMAS
    Public Shared tipografiaMonoespaciada As String = "Mononoki"
    Public Shared tipografiaRegular As String = "Ubuntu"
    Public Shared tipografiaEspecial As String = "Flexo Light"
    Public Shared fuenteMonoespaciada As New Font(tipografiaMonoespaciada, 9, FontStyle.Regular)

    Public Shared fuenteRegular As New Font(tipografiaRegular, 9, FontStyle.Regular)
    Public Shared fuenteEspecial As New Font(tipografiaEspecial, 9, FontStyle.Regular)
    'Public Shared fuenteDePrueba As New Font("Mononoki", 9, FontStyle.Regular)
    '
    Public Shared tipografiaBotones As String = "FlexoW01-Bold"
    'Public Shared fuenteBotones As New Font(tipografiaEspecial, 10, FontStyle.Bold)
    Public Shared fuenteBotones As New Font("Hack", 8) '9.75
    Public Shared fuenteGrande As New Font("Hack", 14, FontStyle.Bold) '9.75
    Public Shared fuenteEtiquetas As New Font(tipografiaEspecial, 10, FontStyle.Bold)
    'TIPOGRAFIA PARA BARRA DE MENSAJE
    Public Shared fuenteBarraMensaje As New Font(tipografiaMonoespaciada, 20, FontStyle.Regular)


    'Tipografia para interfaz exagerada
    Public Shared fuenteMonoespaciadaExagerada As New Font(tipografiaMonoespaciada, 12, FontStyle.Bold)
    Public Shared fuenteExagerada As New Font(tipografiaMonoespaciada, 12, FontStyle.Bold)
    Public Shared fuenteBotonesExagerada As New Font(tipografiaMonoespaciada, 12, FontStyle.Bold)
    Public Shared fuenteEtiquetasExagerada As New Font(tipografiaMonoespaciada, 11, FontStyle.Bold)
    Public Shared fuenteGrandeEtiquetasExagerada As New Font(tipografiaMonoespaciada, 16, FontStyle.Bold)
    Public Shared fuenteComboBoxExagerada As New Font(tipografiaMonoespaciada, 16, FontStyle.Bold)



    Public Shared temaSeleccionado As String = ""
    'USADO PARA FONDOS DE CONTROLES
    Public Shared temaClaroBlanco As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFFFFFFF") 'blanco
    'USADO PARA RESALTAR ELEMENTO SELECCIONADO EN DGV
    Public Shared temaClaroBlancoHumo As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFE6E6E6") 'blanco humo
    'USADO PARA TEXTO FUERA DE FOCO O SECUNDARIO
    Public Shared temaClaroGrisClaro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFA0A0A0") 'gris claro
    'USADO PARA TEXTO FUERA DE FOCO O SECUNDARIO
    Public Shared temaClaroGrisOscuro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF808080") 'gris oscuro
    'USADO PARA TEXTO PRINCIPAL
    Public Shared temaClaroGrisMuyOscuro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF3C3C3C") 'gris muy oscruo
    'USADO PARA FONDO DE BOTONES
    Public Shared temaClaroVerde As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF8AFF8A") 'verde
    'USADO PARA FONDO DE BOTONES
    Public Shared temaClaroCasiNegro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF404040")
    Public Shared temaClaroNegro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF050505")
    Public Shared temaClaroLiliOscuro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFA0C8C8")
    Public Shared temaClaroVerdeWindows As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF00B7C3")
    'Public Shared temaClaroCelesteClaro As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFDCFCFC") 
    Public Shared temaClaroLili As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFB9FFFA")
    Public Shared temaClaroRubi As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFFF637D")
    'NUEVOS COLORES
    Public Shared blancoPuro_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFFFFFFF")
    Public Shared negroPuro__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF000000")
    Public Shared negroMate__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF1E1E1E")
    Public Shared grisOnyx___ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF363C3E")
    Public Shared grisSilver_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFA0A0A0")
    Public Shared grisBebe___ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFF0F0F0")
    Public Shared grisBebe2__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFE0E0E0")
    Public Shared verdeMenta_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF00CCCC") ' 3AB795")
    Public Shared verdeNoche_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF093A3E")
    Public Shared verderCian_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFA5E8E8") '95E0E0'85D9D9'85E9E9'D1F0E8
    Public Shared rojoAmarath As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFDA3E52")
    Public Shared rojoCandy__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFE57685")
    '#E57685
    Public Shared rosaBlanco_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFFFD6E0")
    Public Shared azulNoche__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF02394A")
    Public Shared azulSafiro_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF046B8B")
    Public Shared grisWindows As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF808080")
    '
    Public Shared negroVerde_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF14191E")
    Public Shared violetaClar As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF6A3967")
    Public Shared violetaNuev As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF1F0916")
    Public Shared negroVisual As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF2D2D30")
    Public Shared negroVisua2 As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF3B3B3F")

    Public Shared verdeMentaT As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#5500CCCC")
    Public Shared azulCielo__ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF00BFFF")
    Public Shared grisNoventa As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF5A5A5A")
    Public Shared gris30_____ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF1E1E1E")
    Public Shared verdeTitulo As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF00B7C3")

    Public Shared grisOscuro_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF404040")
    Public Shared celesteRepo As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF47DDFF")
    Public Shared verdeClaro_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFB1FCBE")
    Public Shared grisLobo___ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFD3D2C7")
    Public Shared blancoHumo_ As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFF7F7F7")
    Public Shared amarilloRes As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FFD6F1FF")

    'D3D2C7

    'Public Shared coolor As System.Drawing.Color = Drawing.ColorTranslator.FromHtml("#FF89FB9E") verdesmpatico





    'PENDIENTE DEFINIR UN ESTANDAR DE NOMBRES DE FORMULARIOS
    'PENDIENTE DEFINIR UN ESTANDAR DE TITULO DE FOMRULARIO
    'PENDIENTE EN MODULO COSTOS_CERRAR DIA LIMPIAR TODOS LOS DATAGRIDSVIEW PARA CADA CONSULTA NUEVA SIN CERRAR EL FORM
    'PENDIENTE EN MODULO COSTOS_CERRAR DIA ENVIAR COMO PARAMETRO EL USUARIO QUE HACE EL CIERRE
End Class
