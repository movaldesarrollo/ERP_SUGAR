Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient



Public Class InformeListadoPedidosProv1


    Private informe As Object
    Private sBusqueda As String
    Private sOrden As String
    Private TotalEU As Double
    Private TotalPortes As Double

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

    'Public Property pTotalPortes() As Double
    '    Get
    '        Return TotalPortes
    '    End Get
    '    Set(ByVal value As Double)
    '        TotalPortes = value
    '    End Set
    'End Property


    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load
        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        sBusqueda = sBusqueda & If(sOrden = "", " ORDER BY DOC.numPedido DESC ", " Order BY " & sOrden & ", CP.Orden ASC ")
        bDetalle.ForeColor = Color.Black
        bTotales.ForeColor = Color.Black
        Call verInforme()
    End Sub



    Public Function verInforme() As Boolean
        informe = New ListadoPedidosProv
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString

        informe.SetParameterValue("sParametro", sBusqueda)
        informe.SetParameterValue("TotalEU", TotalEU)

        informe.setPArameterValue("Detalle", bDetalle.ForeColor = Color.Red)
        informe.setparametervalue("conImportes", bTotales.ForeColor = Color.Red)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        CRVPedido.ReportSource = informe

        Return True

    End Function


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then
            informe.PrintToPrinter(1, False, 1, 9999)
        End If

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
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