Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoFacturasProveedorPtes

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height > 1000 Then
            Me.Height = 950
        Else
            Me.Height = desktopSize.Height - 50
        End If
        Me.Location = New Point(Me.Location.X, 0)
    End Sub


    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal TotalEU As Double, ByVal BaseEU As Double, ByVal IVAEU As Double, ByVal ReEU As Double, ByVal RetencionEU As Double, ByVal PendienteEU As Double) As Boolean

        Dim informe As Object = New ListadoFacturasProveedorPtes1

        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numFactura DESC ", " Order BY " & sOrden)

        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("TotalEU", TotalEU)
        informe.SetParameterValue("BaseEU", BaseEU)
        informe.SetParameterValue("IVAEU", IVAEU)
        informe.SetParameterValue("ReEU", ReEU)
        informe.SetParameterValue("RetencionEU", RetencionEU)
        informe.SetParameterValue("PendienteEU", PendienteEU)



        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVPedido.ReportSource = informe

        Return True

    End Function





End Class