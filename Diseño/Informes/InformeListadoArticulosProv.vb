Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoArticulosProv

    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal año As Integer) As Boolean
        If sBusqueda = "AP.idProveedor > 0" Then
            sBusqueda = ""
            Dim informe As New ListadoArticulosProvTodos
            'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
            Dim settings As ConnectionStringSettings
            settings = ConfigurationManager.ConnectionStrings(1)
            Dim csb As New SqlConnectionStringBuilder
            csb.ConnectionString = settings.ConnectionString
            informe.SetDatabaseLogon(csb.UserID, csb.Password)
            'Pasamos los parámetros 
            informe.SetParameterValue("sParametro", If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden))
            informe.SetParameterValue("año", año)
            'Asignamos el informe al CRV
            CRVPedido.ReportSource = informe
            Return True
        Else
            Dim informe As New ListadoArticulosProv
            'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
            Dim settings As ConnectionStringSettings
            settings = ConfigurationManager.ConnectionStrings(1)
            Dim csb As New SqlConnectionStringBuilder
            csb.ConnectionString = settings.ConnectionString
            informe.SetDatabaseLogon(csb.UserID, csb.Password)
            'Pasamos los parámetros 
            informe.SetParameterValue("sParametro", If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden))
            'Asignamos el informe al CRV
            CRVPedido.ReportSource = informe
            Return True
        End If

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