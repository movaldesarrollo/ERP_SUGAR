Public Class FilaVista
    Private NumPedido As Integer
    Private FechaPrevista As Date
    Private FechaPedido As Date
    Private CeldaFechaPrevista As String
    Private CeldaFechaPedido As String
    Private NumPedidoAbrev As String
    Private idProduccion As Integer
    Private Dias As String
    'Private Totales As String
    'Private TotalesBarra As String
    Private idCliente As Integer
    Private Cliente As String
    Private Prioridad As Byte
    Private CeldaCliente As String
    Private nota As Boolean

    Public Property gNumPedido() As Integer
        Get
            Return NumPedido
        End Get
        Set(ByVal value As Integer)
            NumPedido = value
        End Set
    End Property

    Public Property gFechaPrevista() As Date
        Get
            Return FechaPrevista
        End Get
        Set(ByVal value As Date)
            FechaPrevista = value
        End Set
    End Property

    Public Property gFechaPedido() As Date
        Get
            Return FechaPedido
        End Get
        Set(ByVal value As Date)
            FechaPedido = value
        End Set
    End Property

    Public Property gNumPedidoAbrev() As String
        Get
            Return NumPedidoAbrev
        End Get
        Set(ByVal value As String)
            NumPedidoAbrev = value
        End Set
    End Property

    Public Property gCeldaFechaPrevista() As String
        Get
            Return CeldaFechaPrevista
        End Get
        Set(ByVal value As String)
            CeldaFechaPrevista = value
        End Set
    End Property

    Public Property gCeldaFechaPedido() As String
        Get
            Return CeldaFechaPedido
        End Get
        Set(ByVal value As String)
            CeldaFechaPedido = value
        End Set
    End Property

    Public Property gidProduccion() As Integer
        Get
            Return idProduccion
        End Get
        Set(ByVal value As Integer)
            idProduccion = value
        End Set
    End Property

    Public Property gDias() As String
        Get
            Return Dias
        End Get
        Set(ByVal value As String)
            Dias = value
        End Set
    End Property


    'Public Property gTotales() As String
    '    Get
    '        Return Totales
    '    End Get
    '    Set(ByVal value As String)
    '        Totales = value
    '    End Set
    'End Property

    'Public Property gTotalesBarra() As String
    '    Get
    '        Return TotalesBarra
    '    End Get
    '    Set(ByVal value As String)
    '        TotalesBarra = value
    '    End Set
    'End Property

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
        End Set
    End Property

    Public Property gPrioridad() As Byte
        Get
            Return Prioridad
        End Get
        Set(ByVal value As Byte)
            Prioridad = value
        End Set
    End Property

    Public Property gCeldaCliente() As String
        Get
            Return CeldaCliente
        End Get
        Set(ByVal value As String)
            CeldaCliente = value
        End Set
    End Property

    Public Property gNota() As Boolean
        Get
            Return nota
        End Get
        Set(ByVal value As Boolean)
            nota = value
        End Set
    End Property

End Class
