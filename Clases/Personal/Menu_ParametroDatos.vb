Public Class datosMenu_Parametro

    Dim idMenu As Integer
    Dim Parametro As String
    Dim Valor As Boolean
   


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
