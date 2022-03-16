Public Class datosContacto

    Private idContacto As Integer
    Private idProveedor As Integer
    Private idUbicacion As Integer
    Private idCliente As Integer
    Private nombre As String
    Private apellidos As String
    Private idDepartamento As Integer
    Private Cargo As String
    Private Observaciones As String
    Private Departamento As String


    Public Property gDepartamento() As String
        Get
            Return UCase(Departamento)
        End Get
        Set(ByVal value As String)
            Departamento = UCase(value)
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

    Public Property gnombre() As String
        Get
            Return UCase(nombre)
        End Get
        Set(ByVal value As String)
            nombre = UCase(value)
        End Set
    End Property

    Public Property gapellidos() As String
        Get
            Return UCase(apellidos)
        End Get
        Set(ByVal value As String)
            apellidos = UCase(value)
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
  
    Public Property gidUbicacion() As Integer
        Get
            Return idUbicacion
        End Get
        Set(ByVal value As Integer)
            idUbicacion = value
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

 

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gCargo() As String
        Get
            Return UCase(Cargo)
        End Get
        Set(ByVal value As String)
            Cargo = UCase(value)
        End Set
    End Property


    Public Sub New(ByVal idProveedor As Integer, ByVal idUbicacion As Integer, ByVal idCliente As Integer, ByVal nombre As String, ByVal apellidos As String, ByVal idDepartamento As Integer, ByVal Cargo As String, ByVal Observaciones As String)

        gidProveedor = idProveedor
        gidUbicacion = idUbicacion
        gidCliente = idCliente
        gnombre = nombre
        gapellidos = apellidos
        gidDepartamento = idDepartamento
        gCargo = Cargo
        gObservaciones = Observaciones


    End Sub

    Public Sub New()

    End Sub


    Public Overrides Function ToString() As String
        Return nombre & " " & apellidos
    End Function

End Class
