Public Class DatosEquipoHistorico

    Private idEquipoHistorico As Long
    Private numSerie As String
    Private Modelo As String
    Private FechaFab As Date
    Private NombreCliente As String
    Private FechaSal As Date
    Private Bomba As String
    Private NAlbaran As String
    Private Transporte As String
    Private Observaciones As String
    Private idArticulo As Integer
    Private idCliente As Integer
    Private numPedido As Integer
    Private numAlbaran As Integer
    Private numFactura As Integer

    'Datos de otras tablas
    Private codArticulo As String
    Private Articulo As String

    Private FechaPedido As Date
    Private FechaAlbaran As Date
    Private FechaFactura As Date

    Private codCli As String
    Private Cliente As String


    Public Property gidEquipoHistorico() As Long
        Get
            Return idEquipoHistorico
        End Get
        Set(ByVal value As Long)
            idEquipoHistorico = value
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


    Public Property gModelo() As String
        Get
            Return Modelo
        End Get
        Set(ByVal value As String)
            Modelo = value
        End Set
    End Property

    Public Property gFechaFab() As Date
        Get
            Return FechaFab
        End Get
        Set(ByVal value As Date)
            FechaFab = value
        End Set
    End Property


    Public Property gNombreCliente() As String
        Get
            Return NombreCliente
        End Get
        Set(ByVal value As String)
            NombreCliente = value
        End Set
    End Property

    Public Property gFechaSal() As Date
        Get
            Return FechaSal
        End Get
        Set(ByVal value As Date)
            FechaSal = value
        End Set
    End Property


    Public Property gBomba() As String
        Get
            Return Bomba
        End Get
        Set(ByVal value As String)
            Bomba = value
        End Set
    End Property

    Public Property gNAlbaran() As String
        Get
            Return NAlbaran
        End Get
        Set(ByVal value As String)
            NAlbaran = value
        End Set
    End Property


    Public Property gTransporte() As String
        Get
            Return Transporte
        End Get
        Set(ByVal value As String)
            Transporte = value
        End Set
    End Property


    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property


    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
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


    'Otras tablas

    Public Property gcodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Public Property gArticulo() As String
        Get
            Return Articulo
        End Get
        Set(ByVal value As String)
            Articulo = value
        End Set
    End Property





    Public Property gFechaPedido() As Date
        Get
            Return FechaPedido
        End Get
        Set(ByVal value As Date)
            FechaPedido = value
        End Set
    End Property


    Public Property gFechaAlbaran() As Date
        Get
            Return FechaAlbaran
        End Get
        Set(ByVal value As Date)
            FechaAlbaran = value
        End Set
    End Property

    Public Property gFechaFactura() As Date
        Get
            Return FechaFactura
        End Get
        Set(ByVal value As Date)
            FechaFactura = value
        End Set
    End Property






    Public Property gcodCli() As String
        Get
            Return codCli
        End Get
        Set(ByVal value As String)
            codCli = value
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




End Class


