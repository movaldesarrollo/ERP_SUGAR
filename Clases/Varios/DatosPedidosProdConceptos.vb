Public Class DatosPedidosProdConceptos

    Dim conceptoPedido As Integer 'Almacena la Id de concepto de pedido.
    Dim idArticulo As Integer 'Almacena la Id de articulo.
    Dim articulo As String 'Almacena el nombre del articulo.
    Dim cantidad As Double 'Almacena la cantidad del articulo.
    Dim recambio As String 'Almacena si es un recambio.
    Dim estado As String 'Almacena el estado del concepto.
    Dim version As String 'Almacena la version del artículo.
    Dim codArticulo As String 'Almacena el código del artículo.

    Public Property gconceptoPedido() As Integer
        Get
            Return conceptoPedido
        End Get
        Set(ByVal value As Integer)
            conceptoPedido = value
        End Set
    End Property

    Public Property gIdArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gArticulo() As String
        Get
            Return UCase(articulo)
        End Get
        Set(ByVal value As String)
            articulo = UCase(value)
        End Set
    End Property

    Public Property gEstado() As String
        Get
            Return UCase(estado)
        End Get
        Set(ByVal value As String)
            estado = UCase(value)
        End Set
    End Property

    Public Property gVersion() As String
        Get
            Return version
        End Get
        Set(ByVal value As String)
            version = value
        End Set
    End Property

    Public Property gCodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Public Property gcantidad() As Double
        Get
            Return cantidad

        End Get
        Set(ByVal value As Double)

            cantidad = value

        End Set
    End Property

    Public Property grecambio() As String
        Get
            Return recambio
        End Get
        Set(ByVal value As String)
            recambio = value
        End Set
    End Property

End Class
