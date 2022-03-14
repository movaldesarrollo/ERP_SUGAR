Public Class DatosArticuloCliente

    Private IdArtCli As Long
    Private idArticulo As Integer
    Private idCliente As Integer
    Private ArticuloCli As String
    Private codArticuloCli As String
    Private Descuento As Double
    Private FechaAlta As Date
    Private FechaBaja As Date
    Private Activo As Boolean
    Private numDoc As Integer
    Private TipoDoc As String

    'Otras tablas
    Private PrecioNetoUnitario As Double
    Private codMoneda As String
    Private simbolo As String
    Private codArticulo As String
    Private Articulo As String
    Private codCli As Integer
    Private Cliente As String
    Private TipoArticulo As String
    Private subTipoArticulo As String


    Public Property gIdArtCli()
        Get
            Return IdArtCli
        End Get
        Set(ByVal value)
            IdArtCli = value
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


    Public Property gArticuloCli() As String
        Get
            Return ArticuloCli
        End Get
        Set(ByVal value As String)
            ArticuloCli = value
        End Set
    End Property



    Public Property gcodArticuloCli() As String
        Get
            Return UCase(codArticuloCli)
        End Get
        Set(ByVal value As String)
            codArticuloCli = UCase(value)
        End Set
    End Property

    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Public Property gFechaAlta() As Date
        Get
            Return FechaAlta
        End Get
        Set(ByVal value As Date)
            FechaAlta = value
        End Set
    End Property
    Public Property gFechaBaja() As Date
        Get
            Return FechaBaja
        End Get
        Set(ByVal value As Date)
            FechaBaja = value
        End Set
    End Property

    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property gnumDoc() As Integer
        Get
            Return numDoc
        End Get
        Set(ByVal value As Integer)
            numDoc = value
        End Set
    End Property

    Public Property gtipoDoc() As String
        Get
            Return TipoDoc
        End Get
        Set(ByVal value As String)
            TipoDoc = value
        End Set
    End Property


    Public Property gPrecioNetoUnitario() As Double
        Get
            Return PrecioNetoUnitario
        End Get
        Set(ByVal value As Double)
            PrecioNetoUnitario = value
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
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property

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

    Public Property gcodCli() As Integer
        Get
            Return codCli
        End Get
        Set(ByVal value As Integer)
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

    Public Property gTipoArticulo() As String
        Get
            Return TipoArticulo
        End Get
        Set(ByVal value As String)
            TipoArticulo = value
        End Set
    End Property

    Public Property gsubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(ByVal value As String)
            subTipoArticulo = value
        End Set
    End Property


End Class
