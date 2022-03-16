Public Class DatosArticulosComprados

    Dim idArticulo As Integer
    Dim codArticulo As String
    Dim codArticuloProv As String
    Dim articuloProv As String
    Dim cantidad As Double
    Dim proveedor As String
    Dim fecha As Date
    Dim año As Integer
    Dim numPedido As Integer
    Dim precio As Double

    Property gIdArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Property gCodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Property gCodArticuloProv() As String
        Get
            Return codArticuloProv
        End Get
        Set(ByVal value As String)
            codArticuloProv = value
        End Set
    End Property

    Property gArticuloProv() As String
        Get
            Return articuloProv
        End Get
        Set(ByVal value As String)
            articuloProv = value
        End Set
    End Property

    Property gCantidad() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property

    Property gproveedor() As String
        Get
            Return proveedor
        End Get
        Set(ByVal value As String)
            proveedor = value
        End Set
    End Property

    Property gFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Property gAño() As Integer
        Get
            Return año
        End Get
        Set(ByVal value As Integer)
            año = value
        End Set
    End Property

    Property gNumpedido()
        Get
            Return numPedido
        End Get
        Set(ByVal value)
            numPedido = value
        End Set
    End Property

    Property gPrecio() As Double
        Get
            Return precio
        End Get
        Set(ByVal value As Double)
            precio = value
        End Set
    End Property

End Class
