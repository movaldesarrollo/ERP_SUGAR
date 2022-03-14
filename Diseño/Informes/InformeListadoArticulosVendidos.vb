Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoArticulosVendidos
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub


    Public Function verInforme(ByVal iidCliente As Integer, ByVal iidArticulo As Integer, ByVal Desde As Date, ByVal Hasta As Date, ByVal Tipo As String, ByVal subTipo As String) As Boolean

        Dim informe As Object = New EstadisticaVentaArticulo

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        Dim sbusqueda As String
        If iidArticulo = 0 Then
            sbusqueda = ""
        Else
            sbusqueda = " AND CF.idArticulo = " & iidArticulo
        End If
        If Tipo <> "" Then
            sbusqueda = sbusqueda & " AND (TipoArticulo = '" & Tipo & "'  OR Familia = '" & Tipo & "' )"
        End If
        If subTipo <> "" Then
            sbusqueda = sbusqueda & " AND (subTipoArticulo = '" & subTipo & "'  OR subFamilia = '" & subTipo & "' )"
        End If
        informe.SetParameterValue("Desde", Desde)
        informe.SetParameterValue("Hasta", Hasta)
        informe.setParameterValue("VerTotal", iidArticulo = 0)
        informe.SetParameterValue("idCliente", iidCliente)
        informe.SetParameterValue("sParametro", sbusqueda)


        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVPedido.ReportSource = informe

        Return True

    End Function






End Class