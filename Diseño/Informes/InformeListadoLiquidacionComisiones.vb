Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoLiquidacionComisiones
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height > 1000 Then
            Me.Height = 950
        Else
            Me.Height = desktopSize.Height - 50
        End If
        Me.Location = New Point(Me.Location.X, 0)
    End Sub


    Public Function verInforme(ByVal iidLiquidacion As Integer, ByVal TotalBaseEU As Double) As Boolean

        Dim informe As Object = New ListadoLiquidacionComisiones

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString

        informe.SetParameterValue("iidLiquidacion", iidLiquidacion)
        'informe.SetParameterValue("TotalEU", TotalEU)
        informe.SetParameterValue("TotalBaseEU", TotalBaseEU)



        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVPedido.ReportSource = informe

        Return True

    End Function







End Class