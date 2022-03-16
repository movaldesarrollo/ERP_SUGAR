Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoBusquedaLibreArticulos
    Public Function verInforme(ByVal sParametro As String, ByVal sWhere As String) As Boolean

        Dim informe As New ListadoBusquedaLibre

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        'Pasamos los parámetros 
        informe.SetParameterValue("sParametro", sParametro)
        informe.SetParameterValue("sWhere", sWhere)

        CRVListadoBusquedaLibre.ReportSource = informe

        Return True
    End Function

End Class