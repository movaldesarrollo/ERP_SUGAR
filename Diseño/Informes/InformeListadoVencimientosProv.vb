Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoVencimientosProv
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub


    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal TotalEU As Double, ByVal Banco As String, ByVal Cuenta As String, ByVal Fecha As Date) As Boolean

        Dim informe As Object

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY Vencimiento ASC ", " Order BY " & sOrden)

        If Banco = "" Then
            informe = New ListadoVencimientosProv
            informe.SetParameterValue("sParametro", sBusqueda)
            informe.SetParameterValue("TotalEU", TotalEU)
            informe.SetDatabaseLogon(csb.UserID, csb.Password)

        Else
            informe = New ListadoRemesa
            informe.SetParameterValue("sParametro", sBusqueda)
            informe.SetParameterValue("TotalEU", TotalEU)
            informe.SetParameterValue("Banco", Banco)
            informe.SetParameterValue("Cuenta", Cuenta)
            informe.SetParameterValue("Fecha", Fecha)
            informe.SetDatabaseLogon(csb.UserID, csb.Password)
        End If
        CRVPedido.ReportSource = informe

        Return True

    End Function






End Class