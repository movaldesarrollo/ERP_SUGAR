Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoAlbaranes
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub


    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal TotalEU As Double) As Boolean

        Dim informe As Object = New ListadoAlbaranes

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numAlbaran DESC ", " Order BY " & sOrden)

        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("TotalEU", TotalEU)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVPedido.ReportSource = informe

        Return True

    End Function






End Class