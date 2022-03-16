Public Class DatosAlbaranesDePedidosProv

    Dim idalbaran As Integer
    Dim numAlbaran As String
    Dim numFactura As String
    Dim fecha As Date
    Dim Referencia As String
    Dim observaciones As String
    Dim Notas As String
    Dim estado As String
    Dim cantidad As String

    Property gIdAlbaran() As Integer
        Get
            Return idalbaran
        End Get
        Set(ByVal value As Integer)
            idalbaran = value
        End Set
    End Property

    Property gNumAlbaran() As String
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As String)
            numAlbaran = value
        End Set
    End Property

    Property gNumFactura() As String
        Get
            Return numFactura
        End Get
        Set(ByVal value As String)
            numFactura = value
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

    Property gReferencia() As String
        Get
            Return Referencia
        End Get
        Set(ByVal value As String)
            Referencia = value
        End Set
    End Property

    Property gNotas() As String
        Get
            Return Notas
        End Get
        Set(ByVal value As String)
            Notas = value
        End Set
    End Property

    Property gObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

    Property gEstado() As String
        Get
            Return estado
        End Get
        Set(ByVal value As String)
            estado = value
        End Set
    End Property

    Property gCantidad() As String
        Get
            Return cantidad
        End Get
        Set(ByVal value As String)
            cantidad = value
        End Set
    End Property

End Class
