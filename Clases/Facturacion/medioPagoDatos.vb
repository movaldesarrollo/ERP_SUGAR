Public Class datosMedioPago

    Private idMedioPago As String
    Private MedioPago As String
    Private SinCuenta As Boolean
    Private Transferencia As Boolean
    Private Giro As Boolean

    Public Property gidMedioPago()
        Get
            Return idMedioPago
        End Get
        Set(ByVal value)
            idMedioPago = value
        End Set
    End Property

    Public Property gMedioPago()
        Get
            Return MedioPago
        End Get
        Set(ByVal value)
            MedioPago = value
        End Set
    End Property

    Public Property gSinCuenta() As Boolean
        Get
            Return SinCuenta
        End Get
        Set(ByVal value As Boolean)
            SinCuenta = value
        End Set
    End Property

    Public Property gBanco() As Boolean
        Get
            Return Not SinCuenta
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property gTransferencia() As Boolean
        Get
            Return Transferencia
        End Get
        Set(ByVal value As Boolean)
            Transferencia = value
        End Set
    End Property

    Public Property gGiro() As Boolean
        Get
            Return Giro
        End Get
        Set(ByVal value As Boolean)
            Giro = value
        End Set
    End Property

    Public Sub New(ByVal MedioPago As String, ByVal SinCuenta As Boolean)
        gMedioPago = MedioPago
        gSinCuenta = SinCuenta
    End Sub



    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return MedioPago
    End Function

End Class
