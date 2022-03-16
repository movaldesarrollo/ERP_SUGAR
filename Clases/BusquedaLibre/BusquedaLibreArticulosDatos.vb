Public Class BusquedaLibreDatos

    Public id As Integer
    Public codArticulo As String
    Public articulo As String
    Public Cantidad As Integer
    Public Importe As Double


    Public Property gid() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
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

    Public Property garticulo() As String
        Get
            Return articulo
        End Get
        Set(ByVal value As String)
            articulo = value
        End Set
    End Property

    Public Property gCantidad() As Integer
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Integer)
            Cantidad = value
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
End Class

