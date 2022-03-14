Public Class DatosVistaProduccion

    Private numPedido As Integer
    Private Prioridad As Byte

    Private idProduccion As Long
    Private numAlbaran As Integer
    Private idArticulo As Integer
    Private Cantidad As Double
    Private Orden As Integer
    Private idEstado As Integer
    Private idArtCli As Long
    Private idConceptoPedido As Long

    Private FechaPrevista As Date 'Fecha entrega prevista para el caso de no proceder de un pedido
    Private FechaFin As Date

    'Datos de otras tablas
    Private codArticulo As String
    Private Articulo As String
    Private idTipoArticulo As Integer
    Private TipoArticulo As String
    Private idSubTipoArticulo As Integer
    Private subTipoArticulo As String
    Private idUnidad As Integer
    Private TipoUnidad As String
    Private Estado As String

    Private codCliente As Integer
    Private Cliente As String
    Private FechaPedido As Date
    Private FechaEntrega As Date 'Fecha de entrega del pedido



    Public Property gidProduccion() As Integer
        Get
            Return idProduccion
        End Get
        Set(ByVal value As Integer)
            idProduccion = value
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

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property gOrden() As Integer
        Get
            Return Orden
        End Get
        Set(ByVal value As Integer)
            Orden = value
        End Set
    End Property

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
        End Set
    End Property

    Public Property gidArtCli() As Long
        Get
            Return idArtCli
        End Get
        Set(ByVal value As Long)
            idArtCli = value
        End Set
    End Property

    Public Property gidConceptoPedido() As Long
        Get
            Return idConceptoPedido
        End Get
        Set(ByVal value As Long)
            idConceptoPedido = value
        End Set
    End Property

    Public Property gPrioridad() As Byte
        Get
            Return Prioridad
        End Get
        Set(ByVal value As Byte)
            Prioridad = value
        End Set
    End Property


    Public Property gFechaPrevista() As Date
        Get
            Return FechaPrevista
        End Get
        Set(ByVal value As Date)
            FechaPrevista = value
        End Set
    End Property

    Public Property gFechaFin() As Date
        Get
            Return FechaFin
        End Get
        Set(ByVal value As Date)
            FechaFin = value
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

    Public Property gidTipoArticulo() As Integer
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gTipoArticulo() As String
        Get
            Return TipoArticulo
        End Get
        Set(ByVal value As String)
            TipoArticulo = value
        End Set
    End Property

    Public Property gidSubTipoArticulo() As Integer
        Get
            Return idSubTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idSubTipoArticulo = value
        End Set
    End Property

    Public Property gSubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(ByVal value As String)
            subTipoArticulo = value
        End Set
    End Property

    Public Property gidUnidad() As Integer
        Get
            Return idUnidad
        End Get
        Set(ByVal value As Integer)
            idUnidad = value
        End Set
    End Property

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
        End Set
    End Property



    Public Property gEstado() As String
        Get
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = UCase(value)
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

    Public Property gcodCliente() As Integer
        Get
            Return codCliente
        End Get
        Set(ByVal value As Integer)
            codCliente = value
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

    Public Property gFechaEntrega() As Date
        Get
            Return FechaEntrega
        End Get
        Set(ByVal value As Date)
            FechaEntrega = value
        End Set
    End Property

End Class

