Public Class DatosEstadisticaProduccion

    Private idPersona As Integer
    Private Persona As String
    Private idArticulo As Integer
    Private Articulo As String
    Private Cantidad As Double
    Private codArticulo As String
    Private TipoUnidad As String
    Private idArticuloEquipo As Integer
    Private ArticuloEquipo As String
    Private codArticuloEquipo As String
    Private TipoUnidadEquipo As String


    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
        End Set
    End Property

    Public Property gPersona() As String
        Get
            Return Persona
        End Get
        Set(ByVal value As String)
            Persona = value
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


    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
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

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
        End Set
    End Property

    Public Property gidArticuloEquipo() As Integer
        Get
            Return idArticuloEquipo
        End Get
        Set(ByVal value As Integer)
            idArticuloEquipo = value
        End Set
    End Property

    Public Property gcodArticuloEquipo() As String
        Get
            Return codArticuloEquipo
        End Get
        Set(ByVal value As String)
            codArticuloEquipo = value
        End Set
    End Property

    Public Property gArticuloEquipo() As String
        Get
            Return ArticuloEquipo
        End Get
        Set(ByVal value As String)
            ArticuloEquipo = value
        End Set
    End Property

    Public Property gTipoUnidadEquipo() As String
        Get
            Return TipoUnidadEquipo
        End Get
        Set(ByVal value As String)
            TipoUnidadEquipo = value
        End Set
    End Property


End Class


