Public Class datosArticulosAx

#Region "VARIABLES"

    Dim iIdArticuloAX As Integer
    Dim iIdArticulo As Integer
    Dim nombreAX As String
    Dim Articulo As String
    Dim Descripcion As String
    Dim activo As Boolean

#End Region

    Public Property pIdArticuloAX() As Integer
        Get
            Return iIdArticuloAX
        End Get
        Set(value As Integer)
            iIdArticuloAX = value
        End Set
    End Property

    Public Property pIdArticulo() As Integer
        Get
            Return iIdArticulo
        End Get
        Set(value As Integer)
            iIdArticulo = value
        End Set
    End Property

    Public Property pNombreAX() As String
        Get
            Return nombreAX
        End Get
        Set(value As String)
            nombreAX = value
        End Set
    End Property

    Public Property pArticulo() As String
        Get
            Return Articulo
        End Get
        Set(value As String)
            Articulo = value
        End Set
    End Property

    Public Property pDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property pActivo() As String
        Get
            Return activo
        End Get
        Set(value As String)
            activo = value
        End Set
    End Property

End Class
