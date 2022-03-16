Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoLiquidacionIVA
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRV.Load

    End Sub


    Public Function verInforme(ByVal Periodo As String, ByVal ParametroR As String, ByVal OrdenR As String, ByVal ParametroS As String, ByVal OrdenS As String, ByVal verLiquidacion As Boolean, ByVal verRepercutido As Boolean, ByVal verSoportado As Boolean, ByVal iidConcepto As Integer, ByVal sumaBaseR As Double, ByVal sumaCuotaIVAR As Double, ByVal sumaCuotaRER As Double, ByVal sumaRetencionR As Double, ByVal sumaTotalR As Double, ByVal sumaBaseS As Double, ByVal sumaCuotaIVAS As Double, ByVal sumaCuotaRES As Double, ByVal sumaRetencionS As Double, ByVal sumaTotalS As Double) As Boolean

        Dim informe As Object = New ListadoLiquidacionIVA

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        If ParametroR.Length > 0 Then ParametroR = " WHERE " & ParametroR
        If ParametroS.Length > 0 Then ParametroS = " WHERE " & ParametroS
        If OrdenR.Length = 0 Then
            ParametroR = ParametroR & " Order By DOC.Fecha ASC, DOC.numFactura ASC "
        Else
            ParametroR = ParametroR & " Order By " & OrdenR
        End If
        If OrdenS.Length = 0 Then
            ParametroS = ParametroS & " Order By DOC.Fecha ASC, DOC.numFactura ASC "
        Else
            ParametroS = ParametroS & " Order By " & OrdenS
        End If

        informe.SetParameterValue("Periodo", Periodo)
        informe.SetParameterValue("ParametroR", ParametroR)
        informe.SetParameterValue("ParametroS", ParametroS)
        informe.SetParameterValue("verLiquidacion", verLiquidacion)
        informe.SetParameterValue("verRepercutido", verRepercutido)
        informe.SetParameterValue("verSoportado", verSoportado)
        informe.setParameterValue("iidConcepto", iidConcepto)

        informe.SetParameterValue("sumaBaseRepercutido", sumaBaseR)
        informe.SetParameterValue("sumaCuotaIVARepercutido", sumaCuotaIVAR)
        informe.SetParameterValue("sumaCuotaRERepercutido", sumaCuotaRER)
        informe.SetParameterValue("sumaRetencionRepercutido", sumaRetencionR)
        informe.SetParameterValue("TotalRepercutido", sumaTotalR)

        informe.SetParameterValue("sumaBaseSoportado", sumaBaseS)
        informe.SetParameterValue("sumaCuotaIVASoportado", sumaCuotaIVAS)
        informe.SetParameterValue("sumaCuotaRESoportado", sumaCuotaRES)
        informe.SetParameterValue("sumaRetencionSoportado", sumaRetencionS)
        informe.SetParameterValue("TotalSoportado", sumaTotalS)

        informe.SetDatabaseLogon(csb.UserID, csb.Password)


        CRV.ReportSource = informe

        Return True

    End Function






End Class