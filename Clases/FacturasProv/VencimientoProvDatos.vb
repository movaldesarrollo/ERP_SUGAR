Public Class DatosVencimientoProv

    Private idVencimiento As Long
    Private idFactura As Integer
    Private Vencimiento As Date
    Private Importe As Double
    Private Pagado As Boolean
    Private Remesado As Boolean
    Private Devuelto As Boolean

    'Datos otras tablas
    Private idProveedor As Boolean
    Private Proveedor As String 'Nombre fiscal
    Private idBanco As Integer
    Private Banco As String
    Private IBAN As String
    Private codMoneda As String
    Private Simbolo As String
    Private numFactura As String


    Public Property gidVencimiento() As Long
        Get
            Return idVencimiento
        End Get
        Set(ByVal value As Long)
            idVencimiento = value
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

    Public Property gVencimiento() As Date
        Get
            Return Vencimiento
        End Get
        Set(ByVal value As Date)
            Vencimiento = value
        End Set
    End Property

    Public Property gImporte() As Double
        Get
            Return Importe
        End Get
        Set(ByVal value As Double)
            Importe = value
        End Set
    End Property

    Public Property gPagado() As Boolean
        Get
            Return Pagado
        End Get
        Set(ByVal value As Boolean)
            Pagado = value
        End Set
    End Property

    Public Property gRemesado() As Boolean
        Get
            Return Remesado
        End Get
        Set(ByVal value As Boolean)
            Remesado = value
        End Set
    End Property

    Public Property gDevuelto() As Boolean
        Get
            Return Devuelto
        End Get
        Set(ByVal value As Boolean)
            Devuelto = value
        End Set
    End Property


    'Datos otras tablas

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property

    Public Property gidBanco() As Integer
        Get
            Return idBanco
        End Get
        Set(ByVal value As Integer)
            idBanco = value
        End Set
    End Property

    Public Property gBanco() As String
        Get
            Return Banco
        End Get
        Set(ByVal value As String)
            Banco = value
        End Set
    End Property

    Public Property gIBAN() As String
        Get
            Return IBAN
        End Get
        Set(ByVal value As String)
            IBAN = value
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

    Public Property gnumFactura() As String
        Get
            Return numFactura
        End Get
        Set(ByVal value As String)
            numFactura = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Vencimiento.ToString
    End Function




End Class