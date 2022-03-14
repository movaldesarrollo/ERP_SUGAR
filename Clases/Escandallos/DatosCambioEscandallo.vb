Public Class DatosCambioEscandallo
    Private idArticulo As Integer
    Private CantidadAnterior As Double
    Private NuevaCantidad As Double
    Private Descripcion As String
    Private codArticulo As String
    Private Articulo As String
    Private idConceptoOrigen As Long

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gCantidadAnterior() As Double
        Get
            Return CantidadAnterior
        End Get
        Set(ByVal value As Double)
            CantidadAnterior = value
        End Set
    End Property

    Public Property gNuevaCantidad() As Double
        Get
            Return NuevaCantidad
        End Get
        Set(ByVal value As Double)
            NuevaCantidad = value
        End Set
    End Property

    Public Property gDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
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

    Public Property gDiferencia() As Double
        Get
            Return NuevaCantidad - CantidadAnterior
        End Get
        Set(ByVal value As Double)

        End Set
    End Property

    Public Property gidConceptoOrigen() As Long
        Get
            Return idConceptoOrigen
        End Get
        Set(ByVal value As Long)
            idConceptoOrigen = value
        End Set
    End Property

    Public Sub New(ByVal idArticulo As Integer, ByVal CantidadAnterior As Double, ByVal NuevaCantidad As Double, ByVal Descripcion As String, ByVal codArticulo As String, ByVal Articulo As String, ByVal idConceptoOrigen As Long)
        gidArticulo = idArticulo
        gCantidadAnterior = CantidadAnterior
        gNuevaCantidad = NuevaCantidad
        gDescripcion = Descripcion
        gcodArticulo = codArticulo
        gArticulo = Articulo
        gidConceptoOrigen = idConceptoOrigen
    End Sub

    Public Sub New()

    End Sub


End Class
