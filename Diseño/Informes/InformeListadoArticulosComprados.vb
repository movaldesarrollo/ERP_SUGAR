Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient



Public Class InformeListadoArticulosComprados

    Private iidProveedor As Integer
    Private iidArticulo As Integer
    Private Desde, Hasta As Date
    Private informe As Object



    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub

    Public Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property

    Public Property pDesde() As Date
        Get
            Return Desde
        End Get
        Set(ByVal value As Date)
            Desde = value
        End Set
    End Property

    Public Property pHasta() As Date
        Get
            Return Hasta
        End Get
        Set(ByVal value As Date)
            Hasta = value
        End Set
    End Property

    Public Property pDetalle() As Boolean
        Get
            Return bDetalle.ForeColor = Color.Red
        End Get
        Set(ByVal value As Boolean)
            If value Then
                bDetalle.ForeColor = Color.Red
            Else
                bDetalle.ForeColor = Color.Black
            End If

        End Set
    End Property


    Public Function verInforme() As Boolean

        If bDetalle.ForeColor = Color.Red Then
            informe = New EstadisticaCompraArticulo
        Else
            informe = New EstdisticaCompraArticuloSinDetalle
        End If

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
        informe.SetParameterValue("Desde", Desde)
        informe.SetParameterValue("Hasta", Hasta)
        informe.setParameterValue("VerTotal", iidArticulo = 0)
        informe.SetParameterValue("idProveedor", iidProveedor)
        informe.SetParameterValue("sParametro", sbusqueda)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True

    End Function

    Private Sub bTotales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDetalle.Click
        If sender.ForeColor = Color.Red Then
            sender.ForeColor = Color.Black
        Else
            sender.ForeColor = Color.Red
        End If
        Call verInforme()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then
            informe.PrintToPrinter(1, False, 1, 9999)
        End If

    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

  
End Class