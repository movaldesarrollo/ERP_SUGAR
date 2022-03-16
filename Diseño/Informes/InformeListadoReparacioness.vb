Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoReparaciones
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub


    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal TotalEU As Double, ByVal Contador As Double) As Boolean

        Dim informe As Object = New ListadoReparaciones

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numReparacion DESC ", " Order BY " & sOrden)

        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("TotalEU", TotalEU)
        informe.SetParameterValue("totalElementos", Contador)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True

    End Function

End Class