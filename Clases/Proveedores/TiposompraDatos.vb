Public Class DatosTipoCompra

    Private IdTipoCompra As Integer
    Private TipoCompra As String
    Private Observaciones As String
    Private Validacion As Boolean
    Private Transporte As Boolean




    Public Property gIdTipoCompra() As Integer
        Get
            Return IdTipoCompra
        End Get
        Set(ByVal value As Integer)
            IdTipoCompra = value
        End Set
    End Property

    Public Property gTipoCompra() As String
        Get
            Return UCase(TipoCompra)
        End Get
        Set(ByVal value As String)
            TipoCompra = UCase(value)
        End Set
    End Property


    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property

    Public Property gValidacion() As Boolean
        Get
            Return Validacion
        End Get
        Set(ByVal value As Boolean)
            Validacion = value
        End Set
    End Property

    Public Property gTransporte() As Boolean
        Get
            Return Transporte
        End Get
        Set(ByVal value As Boolean)
            Transporte = value
        End Set
    End Property
   


End Class
