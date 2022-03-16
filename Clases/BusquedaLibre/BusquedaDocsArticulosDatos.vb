Public Class BusquedaDocsArticulosDatos

    Public id As Integer
    Public numDoc As Integer
    Public cliente As String
    Public Cantidad As Integer
    Public importe As Double

    Public Property gid() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
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

    Public Property gcliente() As String
        Get
            Return cliente
        End Get
        Set(ByVal value As String)
            cliente = value
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

    Public Property gimporte() As double
        Get
            Return importe
        End Get
        Set(ByVal value As Double)
            importe = value
        End Set
    End Property
End Class

