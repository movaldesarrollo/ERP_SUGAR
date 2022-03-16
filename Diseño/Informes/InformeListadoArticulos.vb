Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoArticulos

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub
    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal StockMinimo As Boolean, ByVal VerCostes As Boolean) As Boolean

        Dim informe As New ListadoArticulos

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)


        'Pasamos los parámetros 
        informe.SetParameterValue("sParametro", If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden))
        informe.SetParameterValue("SoloMinimo", StockMinimo)
        informe.SetParameterValue("VerCostes", VerCostes)

        'informe.SetParameterValue("Detalle", Detallado)
        'Asignamos el informe al CRV


        CRVPedido.ReportSource = informe

        Return True

    End Function


  

End Class