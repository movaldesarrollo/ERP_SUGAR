Public Class datosMenu_ParametrosUsuario

    Dim idUsuario As Integer
    Dim idMenu As Integer
    Dim Parametro As String
    Dim Valor As Boolean
    Dim idPersona As Integer
    Dim Cuando As Date


    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
        End Set
    End Property

    Public Property gCuando() As Date
        Get
            Return Cuando
        End Get
        Set(ByVal value As Date)
            Cuando = value
        End Set
    End Property

    Public Property gidUsuario()
        Get
            Return idUsuario
        End Get
        Set(ByVal value)
            idUsuario = value
        End Set
    End Property

    Public Property gidMenu()
        Get
            Return idMenu
        End Get
        Set(ByVal value)
            idMenu = value
        End Set
    End Property

    Public Property gParametro()
        Get
            Return Parametro
        End Get
        Set(ByVal value)
            Parametro = value
        End Set
    End Property

    Public Property gValor()
        Get
            Return Valor
        End Get
        Set(ByVal value)
            Valor = value
        End Set
    End Property



End Class
