Public Class DatosPersonal

    Private idPersona As Integer
    Private codPersonal As String
    Private idContacto As Integer
    Private Usuario As String
    Private Contrasena As String
    Private Activo As Boolean
    Private idDepartamento As Integer
    Private idPerfil As Integer
    Private mail As String
    Private ValidaPedidosProv As Boolean
    Private ResponsableCuenta As Boolean
    Private ResponsableProd As Boolean
    Private RecibeAvisos As Boolean

    Private Persona As String
    Private Departamento As String
    Private Nombre As String
    Private Apellidos As String
    Private Perfil As String


    Dim SoloLectura As Boolean


    Public Property gRecibeAvisos() As Boolean
        Get
            Return RecibeAvisos
        End Get
        Set(ByVal value As Boolean)
            RecibeAvisos = value
        End Set
    End Property


    Public Property gResponsableCuenta() As Boolean
        Get
            Return ResponsableCuenta
        End Get
        Set(ByVal value As Boolean)
            ResponsableCuenta = value
        End Set
    End Property

    Public Property gResponsableProd() As Boolean
        Get
            Return ResponsableProd
        End Get
        Set(ByVal value As Boolean)
            ResponsableProd = value
        End Set
    End Property

    Public Property gPersona() As String
        Get
            Return Trim(UCase(Nombre)) & " " & Trim(UCase(Apellidos))
        End Get
        Set(ByVal value As String)
            Persona = value
        End Set
    End Property

    Public Property gcodPersonal() As String
        Get
            Return UCase(codPersonal)
        End Get
        Set(ByVal value As String)
            codPersonal = UCase(value)
        End Set
    End Property

    Public Property gPerfil() As String
        Get
            Return UCase(Perfil)
        End Get
        Set(ByVal value As String)
            Perfil = UCase(value)
        End Set
    End Property

    Public Property gSoloLectura() As Boolean
        Get
            Return SoloLectura
        End Get
        Set(ByVal value As Boolean)
            SoloLectura = value
        End Set
    End Property

    Public Property gidContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            idContacto = value
        End Set
    End Property

    Public Property gDepartamento() As String
        Get
            Return UCase(Departamento)
        End Get
        Set(ByVal value As String)
            Departamento = UCase(value)
        End Set
    End Property

    Public Property gValidaPedidosProv() As Boolean
        Get
            Return ValidaPedidosProv
        End Get
        Set(ByVal value As Boolean)
            ValidaPedidosProv = value
        End Set
    End Property

    Public Property gmail() As String
        Get
            Return LCase(mail)
        End Get
        Set(ByVal value As String)
            mail = LCase(value)
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

    Public Property gidPerfil() As Integer
        Get
            Return idPerfil
        End Get
        Set(ByVal value As Integer)
            idPerfil = value
        End Set
    End Property

    Public Property gUsuario() As String
        Get
            Return UCase(Usuario)
        End Get
        Set(ByVal value As String)
            Usuario = UCase(value)
        End Set
    End Property

    Public Property gContrasena() As String
        Get
            Return Contrasena
        End Get
        Set(ByVal value As String)
            Contrasena = value
        End Set
    End Property

    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
        End Set
    End Property

    Public Property gNombre() As String
        Get
            Return UCase(Nombre)
        End Get
        Set(ByVal value As String)
            Nombre = UCase(value)
        End Set
    End Property

    Public Property gApellidos() As String
        Get
            Return UCase(Apellidos)
        End Get
        Set(ByVal value As String)
            Apellidos = UCase(value)
        End Set
    End Property

    Public Property gidDepartamento() As Integer
        Get
            Return idDepartamento
        End Get
        Set(ByVal value As Integer)
            idDepartamento = value
        End Set
    End Property


End Class
