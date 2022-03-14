Public Class datosMenu_EntradasPerfil

    Dim idPerfil As Integer
    Dim idMenu As Integer
    Dim idPersona As Integer
    Dim Cuando As Date
    Dim Nivel As Integer
    Dim Nombre As String
    Dim idMenuPadre As Integer
    Dim Ejecutar As String
    'Dim SoloLectura As Boolean
    'Dim Parametro1 As String
    'Dim Valor1 As Boolean
    'Dim Parametro2 As String
    'Dim Valor2 As Boolean
    'Dim Parametro3 As String
    'Dim Valor3 As Boolean
    'Dim Parametro4 As String
    'Dim Valor4 As Boolean

    Property gidPerfil() As Integer
        Get
            Return idPerfil
        End Get
        Set(ByVal value As Integer)
            idPerfil = value
        End Set
    End Property

    Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
        End Set
    End Property


    Property gCuando() As Date
        Get
            Return Cuando
        End Get
        Set(ByVal value As Date)
            Cuando = value
        End Set
    End Property



    'Property gSoloLectura() As Boolean
    '    Get
    '        Return SoloLectura
    '    End Get
    '    Set(ByVal value As Boolean)
    '        SoloLectura = value
    '    End Set
    'End Property

    'Property gParametro1() As String
    '    Get
    '        Return Parametro1
    '    End Get
    '    Set(ByVal value As String)
    '        Parametro1 = value
    '    End Set
    'End Property

    'Property gValor1() As String
    '    Get
    '        Return Valor1
    '    End Get
    '    Set(ByVal value As String)
    '        Valor1 = value
    '    End Set
    'End Property

    'Property gParametro2() As String
    '    Get
    '        Return Parametro2
    '    End Get
    '    Set(ByVal value As String)
    '        Parametro2 = value
    '    End Set
    'End Property

    'Property gValor2() As String
    '    Get
    '        Return Valor2
    '    End Get
    '    Set(ByVal value As String)
    '        Valor2 = value
    '    End Set
    'End Property

    'Property gParametro3() As String
    '    Get
    '        Return Parametro3
    '    End Get
    '    Set(ByVal value As String)
    '        Parametro3 = value
    '    End Set
    'End Property

    'Property gValor3() As String
    '    Get
    '        Return Valor3
    '    End Get
    '    Set(ByVal value As String)
    '        Valor3 = value
    '    End Set
    'End Property

    'Property gParametro4() As String
    '    Get
    '        Return Parametro4
    '    End Get
    '    Set(ByVal value As String)
    '        Parametro4 = value
    '    End Set
    'End Property

    'Property gValor4() As String
    '    Get
    '        Return Valor4
    '    End Get
    '    Set(ByVal value As String)
    '        Valor4 = value
    '    End Set
    'End Property




    Public Property gidMenu()
        Get
            Return idMenu
        End Get
        Set(ByVal value)
            idMenu = value
        End Set
    End Property

    Public Property gNivel()
        Get
            Return Nivel
        End Get
        Set(ByVal value)
            Nivel = value
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

    Public Property gidMenuPadre()
        Get
            Return idMenuPadre
        End Get
        Set(ByVal value)
            idMenuPadre = value
        End Set
    End Property

    Public Property gEjecutar() As String
        Get
            Return Ejecutar
        End Get
        Set(ByVal value As String)
            Ejecutar = value
        End Set
    End Property


End Class
