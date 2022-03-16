Public Class DatosMaster

    Private numeracion As Integer
    Private numPedidoProv As Integer
    Private numFraProveedor As Integer
    Private numAlbaran As Integer
    Private numPedido As Integer
    Private numFactura As Integer
    Private numProforma As Integer
    Private numOferta As Integer
    Private DomesticosXDia As Double
    Private Domesticos2XDia As Double
    Private IndustrialesXDia As Double
    Private RecambiosXDia As Double
    Private SMTPServidor As String
    Private SMTPPuerto As Integer
    Private SMTPUsuario As String
    Private SMTPPassword As String
    Private SMTPAutenticado As Boolean
    Private SMTPSSL As Boolean
    Private numSerie As String
    Private numSerie2 As String
    Private numReparacion As Integer

    Public Property gSMTPSSL() As Boolean
        Get
            Return SMTPSSL
        End Get
        Set(ByVal value As Boolean)
            SMTPSSL = value
        End Set
    End Property

    Public Property gSMTPServidor() As String
        Get
            Return SMTPServidor
        End Get
        Set(ByVal value As String)
            SMTPServidor = value
        End Set
    End Property

    Public Property gSMTPPuerto() As Integer
        Get
            Return SMTPPuerto
        End Get
        Set(ByVal value As Integer)
            SMTPPuerto = value
        End Set
    End Property

    Public Property gSMTPUsuario() As String
        Get
            Return SMTPUsuario
        End Get
        Set(ByVal value As String)
            SMTPUsuario = value
        End Set
    End Property

    Public Property gSMTPPassword() As String
        Get
            Return SMTPPassword
        End Get
        Set(ByVal value As String)
            SMTPPassword = value
        End Set
    End Property

    Public Property gSMTPAutenticado() As Boolean
        Get
            Return SMTPAutenticado
        End Get
        Set(ByVal value As Boolean)
            SMTPAutenticado = value
        End Set
    End Property


    Public Property gnumFraProveedor() As Integer
        Get
            Return numFraProveedor
        End Get
        Set(ByVal value As Integer)
            numFraProveedor = value
        End Set
    End Property


    Public Property gnumPedidoProv() As Integer
        Get
            Return numPedidoProv
        End Get
        Set(ByVal value As Integer)
            numPedidoProv = value
        End Set
    End Property

    Public Property gnumOferta() As Integer
        Get
            Return numOferta
        End Get
        Set(ByVal value As Integer)
            numOferta = value
        End Set
    End Property

    Public Property gnumReparacion() As Integer
        Get
            Return numReparacion
        End Get
        Set(ByVal value As Integer)
            numReparacion = value
        End Set
    End Property


    Public Property gnumProforma() As Integer
        Get
            Return numProforma
        End Get
        Set(ByVal value As Integer)
            numProforma = value
        End Set
    End Property


    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property


    Public Property gnumAlbaran() As Integer
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As Integer)
            numAlbaran = value
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


    Public Property gDomesticosXDia() As Double
        Get
            Return DomesticosXDia
        End Get
        Set(ByVal value As Double)
            DomesticosXDia = value
        End Set
    End Property


    Public Property gIndustrialesXDia() As Double
        Get
            Return IndustrialesXDia
        End Get
        Set(ByVal value As Double)
            IndustrialesXDia = value
        End Set
    End Property


    Public Property gnumeracion() As Integer
        Get
            Return numeracion
        End Get
        Set(ByVal value As Integer)
            numeracion = value
        End Set
    End Property

    Public Property gnumSerie() As String
        Get
            Return numSerie
        End Get
        Set(ByVal value As String)
            numSerie = value
        End Set
    End Property



    Public Property gnumSerie2() As String
        Get
            Return numSerie2
        End Get
        Set(ByVal value As String)
            numSerie2 = value
        End Set
    End Property

    Public Property gDomesticos2XDia As Double
        Get
            Return Domesticos2XDia
        End Get
        Set(value As Double)
            Domesticos2XDia = value
        End Set
    End Property

    Public Property gRecambiosXDia As Double
        Get
            Return RecambiosXDia
        End Get
        Set(value As Double)
            RecambiosXDia = value
        End Set
    End Property
End Class
