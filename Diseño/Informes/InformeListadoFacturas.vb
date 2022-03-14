Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoFacturas

    Dim informe As Object
    Dim sBusqueda As String
    Dim sOrden As String
    Dim TotalEU As Double
    Dim BaseEU As Double
    Dim IVAEU As Double
    Dim ReEU As Double
    Dim RetencionEU As Double

    Public Property pBusqueda() As String
        Get
            Return sBusqueda
        End Get
        Set(ByVal value As String)
            sBusqueda = value
        End Set
    End Property

    Public Property pOrden() As String
        Get
            Return sOrden
        End Get
        Set(ByVal value As String)
            sOrden = value
        End Set
    End Property

    Public Property pTotalEU() As Double
        Get
            Return TotalEU
        End Get
        Set(ByVal value As Double)
            TotalEU = value
        End Set
    End Property

    Public Property pBaseEU() As Double
        Get
            Return BaseEU
        End Get
        Set(ByVal value As Double)
            BaseEU = value
        End Set
    End Property

    Public Property pIVAEU() As Double
        Get
            Return IVAEU
        End Get
        Set(ByVal value As Double)
            IVAEU = value
        End Set
    End Property

    Public Property pReEU() As Double
        Get
            Return ReEU
        End Get
        Set(ByVal value As Double)
            ReEU = value
        End Set
    End Property

    Public Property pRetencionEU() As Double
        Get
            Return RetencionEU
        End Get
        Set(ByVal value As Double)
            RetencionEU = value
        End Set
    End Property

    Private Sub CRVFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVFacturas.Load
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numFactura DESC ", " Order BY " & sOrden)
        bDetalle.ForeColor = Color.Black
        bTotales.ForeColor = Color.Black
        Call verInforme()
    End Sub

    'Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal TotalEU As Double, ByVal BaseEU As Double, ByVal IVAEU As Double, ByVal ReEU As Double, ByVal RetencionEU As Double) As Boolean
    Public Function verInforme() As Boolean
        informe = New ListadoFacturasClientes
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        sBusqueda = If(sBusqueda = "", "", sBusqueda)
        'sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numFactura DESC ", " Order BY " & sOrden)

        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("TotalEU", TotalEU)
        informe.SetParameterValue("BaseEU", BaseEU)
        informe.SetParameterValue("IVAEU", IVAEU)
        informe.SetParameterValue("ReEU", ReEU)
        informe.SetParameterValue("RetencionEU", RetencionEU)
        informe.setPArameterValue("Detalle", bDetalle.ForeColor = Color.Red)
        informe.setparametervalue("Totales", bTotales.ForeColor = Color.Red)

        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVFacturas.ReportSource = informe

        Return True

    End Function

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then
            informe.PrintToPrinter(1, False, 1, 9999)
        End If
    End Sub

    Private Sub bTotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTotales.Click, bDetalle.Click
        If sender.ForeColor = Color.Red Then
            sender.ForeColor = Color.Black
        Else
            sender.ForeColor = Color.Red
        End If
        Call verInforme()
    End Sub
End Class