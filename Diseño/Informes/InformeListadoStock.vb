Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoStock
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub
    Public Function verInformeFecha(ByVal sBusqueda As String, ByVal sOrden As String, ByVal Titulo As String) As Boolean

        Dim informe As Object
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY idStock ASC ", " Order BY " & sOrden)

        informe = New ListadoStockFecha
        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("Titulo", Titulo)

        informe.SetDatabaseLogon(csb.UserID, csb.Password)


        CRVPedido.ReportSource = informe

        Return True

    End Function

    Public Function verInformeArticulo(ByVal sBusqueda As String, ByVal sOrden As String) As Boolean

        Dim informe As Object
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY idStock ASC ", " Order BY " & sOrden)
        informe = New ListadoStock
        informe.SetParameterValue("sParametro", sBusqueda)


        informe.SetDatabaseLogon(csb.UserID, csb.Password)


        CRVPedido.ReportSource = informe

        Return True

    End Function


    Public Function GeneraPDF(ByVal vnumPedido As Integer, ByVal Fichero As String, ByVal Camino As String) As Boolean

        Try

            Dim informe As New PedidoProveedor1
            'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
            Dim settings As ConnectionStringSettings
            settings = ConfigurationManager.ConnectionStrings(1)
            Dim csb As New SqlConnectionStringBuilder
            csb.ConnectionString = settings.ConnectionString
            informe.SetDatabaseLogon(csb.UserID, csb.Password)

            'Pasamos los parámetros 
            informe.SetParameterValue("vNumPedido", vnumPedido)

            informe.ExportToDisk(ExportFormatType.PortableDocFormat, Camino & Fichero)




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function



End Class