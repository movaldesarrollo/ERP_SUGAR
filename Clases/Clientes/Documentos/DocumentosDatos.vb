Public Class DatosDocumento
    Dim codDocumento As Integer
    Dim Nombre As String
    Dim Ruta As String
    Dim Extension As String
    Dim IdTipo As Integer

    Public Property gcodDocumento()
        Get
            Return codDocumento
        End Get
        Set(ByVal value)
            codDocumento = value
        End Set
    End Property

    Public Property gNombre()
        Get
            Return Nombre
        End Get
        Set(ByVal value)
            Nombre = value
        End Set
    End Property

    Public Property gRuta()
        Get
            Return Ruta
        End Get
        Set(ByVal value)
            Ruta = value
        End Set
    End Property


    Public Property gExtension()
        Get
            Return Extension
        End Get
        Set(ByVal value)
            Extension = value
        End Set
    End Property

    Public Property gIdTipo()
        Get
            Return IdTipo
        End Get
        Set(ByVal value)
            IdTipo = value
        End Set
    End Property




End Class
