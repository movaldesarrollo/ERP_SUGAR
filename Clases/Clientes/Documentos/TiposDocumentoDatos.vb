Public Class DatosTiposDocumento
    Dim IDTipo As Integer
    Dim TipoDoc As String
    Dim Activo As Boolean
    Dim Observaciones As String

    Public Property gIDTipo()
        Get
            Return IDTipo
        End Get
        Set(ByVal value)
            IDTipo = value
        End Set
    End Property

    Public Property gTipoDoc()
        Get
            Return TipoDoc
        End Get
        Set(ByVal value)
            TipoDoc = value
        End Set
    End Property


    Public Property gActivo()
        Get
            Return Activo
        End Get
        Set(ByVal value)
            Activo = value
        End Set
    End Property


    Public Property gObservaciones()
        Get
            Return Observaciones
        End Get
        Set(ByVal value)
            Observaciones = value
        End Set
    End Property



End Class
