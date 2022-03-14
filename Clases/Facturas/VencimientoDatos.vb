Public Class DatosVencimiento

    Private idVencimiento As Long
    Private numFactura As Integer
    Private Vencimiento As Date
    Private Importe As Double
    Private Cobrado As Boolean
    Private Remesado As Boolean
    Private Devuelto As Boolean

    'Datos otras tablas
    Private idCliente As Boolean
    Private Cliente As String 'Nombre fiscal
    Private idBanco As Integer
    Private Banco As String
    Private IBAN As String
    Private codMoneda As String
    Private Simbolo As String
    Private idUsuario As String

    Public Property gidVencimiento() As Long
        Get
            Return idVencimiento
        End Get
        Set(ByVal value As Long)
            idVencimiento = value
        End Set
    End Property

    Public Property gidUsuario() As Integer
        Get
            Return idUsuario
        End Get
        Set(ByVal value As Integer)
            idUsuario = value
        End Set
    End Property

    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
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

    Public Property gCobrado() As Boolean
        Get
            Return Cobrado
        End Get
        Set(ByVal value As Boolean)
            Cobrado = value
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

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
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


    Public Overrides Function ToString() As String
        Return Vencimiento.ToString
    End Function




End Class