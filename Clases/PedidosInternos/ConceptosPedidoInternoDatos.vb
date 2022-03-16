Public Class DatosConceptoPedidoInterno
    Private idConcepto As Long

    Private idArticulo As Integer
    Private Articulo As String
    Private codArticulo As String

    Private Cantidad As Double
    Private Observaciones As String
    Private idEstado As Integer
    Private idConceptoPedidoProv As Long
    Private idCreador As Integer
    Private Creacion As Date

    'Otras tablas
    Private Creador As String
    Private Familia As String
    Private subFamilia As String
    Private idUnidad As Integer
    Private TipoUnidad As String
    Private Estado As String

    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
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

    
    Public Property gArticulo() As String
        Get
            Return Articulo
        End Get
        Set(ByVal value As String)
            Articulo = value
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


    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
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


    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
        End Set
    End Property

    Public Property gidConceptoPedidoProv() As Long
        Get
            Return idConceptoPedidoProv
        End Get
        Set(ByVal value As Long)
            idConceptoPedidoProv = value
        End Set
    End Property

    Public Property gidCreador() As Integer
        Get
            Return idCreador
        End Get
        Set(ByVal value As Integer)
            idCreador = value
        End Set
    End Property


    Public Property gCreacion() As Date
        Get
            Return Creacion
        End Get
        Set(ByVal value As Date)
            Creacion = value
        End Set
    End Property

    Public Property gCreador() As String
        Get
            Return Creador
        End Get
        Set(ByVal value As String)
            Creador = value
        End Set
    End Property



    Public Property gFamilia() As String
        Get
            Return Familia
        End Get
        Set(ByVal value As String)
            Familia = value
        End Set
    End Property


    Public Property gsubFamilia() As String
        Get
            Return subFamilia
        End Get
        Set(ByVal value As String)
            subFamilia = value
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
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Articulo
    End Function




End Class
