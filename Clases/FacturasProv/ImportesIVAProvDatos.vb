Public Class DatosImportesIVAProv

    Private idConcepto As Long = 0
    Private idFactura As Integer = 0
    Private idTipoIVA As Integer
    Private TipoIVA As Double
    Private TipoRecargoEq As Double
    Private Base As Double
    Private TotalIVA As Double
    Private TotalRE As Double

    'Datos otras tablas
    Private numFactura As String
    Private NombreIVA As String
    Private codMoneda As String
    Private Simbolo As String


    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property

    Public Property gidFactura() As Integer
        Get
            Return idFactura
        End Get
        Set(ByVal value As Integer)
            idFactura = value
        End Set
    End Property

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
        End Set
    End Property

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property

    Public Property gTipoRecargoEq() As Double
        Get
            Return TipoRecargoEq
        End Get
        Set(ByVal value As Double)
            TipoRecargoEq = value
        End Set
    End Property

    Public Property gBase() As Double
        Get
            Return Base
        End Get
        Set(ByVal value As Double)
            Base = value
        End Set
    End Property

    Public Property gTotalIVA() As Double
        Get
            Return TotalIVA
        End Get
        Set(ByVal value As Double)
            TotalIVA = value
        End Set
    End Property

    Public Property gTotalRE() As Double
        Get
            Return TotalRE
        End Get
        Set(ByVal value As Double)
            TotalRE = value
        End Set
    End Property



    'Datos otras tablas

    Public Property gnumFactura() As String
        Get
            Return numFactura
        End Get
        Set(ByVal value As String)
            numFactura = value
        End Set
    End Property


    Public Property gNombreIVA() As String
        Get
            Return NombreIVA
        End Get
        Set(ByVal value As String)
            NombreIVA = value
        End Set
    End Property

    Public Property gcodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
        End Set
    End Property

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(ByVal idFactura As Integer, ByVal numFactura As String, ByVal Base As Double, ByVal TipoIVA As Double, ByVal TotalIVA As Double, ByVal TipoRecargoEq As Double, ByVal TotalRE As Double)
        gidFactura = idFactura
        gnumFactura = numFactura
        gBase = Base
        gTipoIVA = TipoIVA
        gTotalIVA = TotalIVA
        gTipoRecargoEq = TipoRecargoEq
        gTotalRE = TotalRE
    End Sub

End Class