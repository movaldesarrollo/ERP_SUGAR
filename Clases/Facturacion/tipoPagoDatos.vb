Public Class datosTipoPago


    Private idTipoPago As Integer
    Private TipoPago As String
    Private diaPactado As Boolean
    Private ContadorDias As Integer
    Private ProntoPago As Boolean
    Private Carencia As Integer
    Private numPagos As Integer
    Private Activo As Integer


    Public Property gProntoPago() As Boolean
        Get
            Return ProntoPago
        End Get
        Set(ByVal value As Boolean)
            ProntoPago = value
        End Set
    End Property


    Public Property gidTipoPago()
        Get
            Return idTipoPago
        End Get
        Set(ByVal value)
            idTipoPago = value
        End Set
    End Property


    Public Property gTipoPago()
        Get
            Return TipoPago
        End Get
        Set(ByVal value)
            TipoPago = value
        End Set
    End Property



    Public Property gdiapactado() As Boolean
        Get
            Return diaPactado
        End Get
        Set(ByVal value As Boolean)
            diaPactado = value
        End Set
    End Property

    Public Property gContadorDias()
        Get
            Return ContadorDias
        End Get
        Set(ByVal value)
            ContadorDias = value
        End Set
    End Property


    Public Property gCarencia() As Integer
        Get
            Return Carencia
        End Get
        Set(ByVal value As Integer)
            Carencia = value
        End Set
    End Property

    Public Property gnumPagos() As Integer
        Get
            Return numPagos
        End Get
        Set(ByVal value As Integer)
            numPagos = value
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

    'Public Sub New(ByVal TipoPago As String, ByVal diapactado As Integer, ByVal ContadorDias As Integer)
    '    gTipoPago = TipoPago
    '    gdiapactado = diapactado
    '    gContadorDias = ContadorDias
    'End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return TipoPago
    End Function

End Class
