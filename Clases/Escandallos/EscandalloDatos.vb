Public Class DatosEscandallo

    Private idEscandallo As Integer
    Private codEscandallo As String
    Private idTipoEscandallo As Integer
    Private idArticulo As Integer
    Private Escandallo As String
    Private Observaciones As String
    Private FechaAlta As Date
    Private FechaBaja As Date
    Private Activo As Boolean
    Private VersionEscandallo As Integer
    Private VersionBase As Integer

    'Datos calculados
    Private Coste As Double
    Private numComponentes As Integer

    'Datos de otras tablas
    Private codArticulo As String
    Private Articulo As String
    Private TipoEscandallo As String
    Private Cantidad As Double 'Usado para pasar la cantidad de una materia prima dada dentro de este escandallo
    Private idArticuloBase As Integer 'En caso de escandallo tipo Composición, la id del artículo base (único)
    Private Composicion As Boolean
    Private idTipoArticulo As Integer
    Private TipoArticulo As String
    Private idSubTipoArticulo As Integer
    Private subTipoArticulo As String
    Public level As Integer
    Public seccion As String
    Public familia As String
    Public subfamilia As String
    Public simbolo As String
    Public TipoUnidad As String

    Public Property gLevel() As Integer
        Get
            Return level
        End Get
        Set(ByVal value As Integer)
            level = value
        End Set
    End Property

    Public Property gidEscandallo() As Integer
        Get
            Return idEscandallo
        End Get
        Set(ByVal value As Integer)
            idEscandallo = value
        End Set
    End Property

    Public Property gcodEscandallo() As String
        Get
            Return UCase(codEscandallo)
        End Get
        Set(ByVal value As String)
            codEscandallo = UCase(value)
        End Set
    End Property

    Public Property gidTipoEscandallo() As String
        Get
            Return idTipoEscandallo
        End Get
        Set(ByVal value As String)
            idTipoEscandallo = value
        End Set
    End Property

    Public Property gseccion() As String
        Get
            Return seccion
        End Get
        Set(ByVal value As String)
            seccion = value
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

    Public Property gSimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property

    Public Property gFamilia() As String
        Get
            Return familia
        End Get
        Set(ByVal value As String)
            familia = value
        End Set
    End Property

    Public Property gSubfamilia() As String
        Get
            Return subfamilia
        End Get
        Set(ByVal value As String)
            subfamilia = value
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

    Public Property gEscandallo() As String
        Get
            Return Escandallo
        End Get
        Set(ByVal value As String)
            Escandallo = value
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

    Public Property gVersionEscandallo() As Integer
        Get
            Return VersionEscandallo
        End Get
        Set(ByVal value As Integer)
            VersionEscandallo = value
        End Set
    End Property

    Public Property gVersionBase() As Integer
        Get
            Return VersionBase
        End Get
        Set(ByVal value As Integer)
            VersionBase = value
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

    Public Property gArticulo()
        Get
            Return UCase(Articulo)
        End Get
        Set(ByVal value)
            Articulo = UCase(value)
        End Set
    End Property

    Public Property gnumComponentes() As Integer
        Get
            Return numComponentes
        End Get
        Set(ByVal value As Integer)
            numComponentes = value
        End Set
    End Property

    Public Property gTipoEscandallo() As String
        Get
            Return TipoEscandallo
        End Get
        Set(ByVal value As String)
            TipoEscandallo = value
        End Set
    End Property

    Public Property gCoste() As Double
        Get
            Return Coste
        End Get
        Set(ByVal value As Double)
            Coste = value
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

    Public Property gidArticuloBase() As Integer
        Get
            Return idArticuloBase
        End Get
        Set(ByVal value As Integer)
            idArticuloBase = value
        End Set
    End Property

    Public Property gComposicion() As Boolean
        Get
            Return Composicion
        End Get
        Set(ByVal value As Boolean)
            Composicion = value
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
End Class
