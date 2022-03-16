Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoClientesArticulo

    Public Function verInforme(ByVal iidCliente As Integer, ByVal iidArticulo As Integer, ByVal Desde As Date, ByVal Hasta As Date, ByVal iidComercial As Integer) As Boolean
        Dim informe As Object = New EstadisticasVentasClientes
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        Dim sbusqueda As String
        If iidCliente = 0 Then
            sbusqueda = ""
        Else
            sbusqueda = " AND FA.idCliente = " & iidCliente
        End If
        If iidComercial > 0 Then
            sbusqueda = sbusqueda & " AND FA.idPersona = " & iidComercial
        End If
        informe.SetParameterValue("Desde", Desde)
        informe.SetParameterValue("Hasta", Hasta)
        informe.setParameterValue("VerTotal", iidCliente = 0)
        informe.SetParameterValue("iidArticulo", iidArticulo)
        informe.SetParameterValue("sParametro", sbusqueda)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function
End Class