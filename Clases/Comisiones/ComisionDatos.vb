Public Class datosComision

    Private idComision As Integer
    Private idComercial As Integer
    Private idCliente As Integer
    Private Porcentaje As Double
    Private Observaciones As String

    Private Cliente As String
    Private Comercial As String
    Private idPais As Integer
    Private Pais As String
    Private idProvincia As Integer
    Private Provincia As String
    Private idAutonomia As Integer
    Private Autonomia As String


    Public Property gidComision() As Integer
        Get
            Return idComision
        End Get
        Set(ByVal value As Integer)
            idComision = value
        End Set
    End Property

    Public Property gidComercial() As Integer
        Get
            Return idComercial
        End Get
        Set(ByVal value As Integer)
            idComercial = value
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

    Public Property gPorcentaje() As Double
        Get
            Return Porcentaje
        End Get
        Set(ByVal value As Double)
            Porcentaje = value
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




    Public Property gCliente() As String
        Get
            Return UCase(Cliente)
        End Get
        Set(ByVal value As String)
            Cliente = UCase(value)
        End Set
    End Property

    Public Property gComercial() As String
        Get
            Return UCase(Comercial)
        End Get
        Set(ByVal value As String)
            Comercial = UCase(value)
        End Set
    End Property

    Public Property gidPais() As Integer
        Get
            Return idPais
        End Get
        Set(ByVal value As Integer)
            idPais = value
        End Set
    End Property


    Public Property gPais() As String
        Get
            Return UCase(Pais)
        End Get
        Set(ByVal value As String)
            Pais = UCase(value)
        End Set
    End Property

    Public Property gidProvincia() As Integer
        Get
            Return idProvincia
        End Get
        Set(ByVal value As Integer)
            idProvincia = value
        End Set
    End Property

    Public Property gProvincia() As String
        Get
            Return UCase(Provincia)
        End Get
        Set(ByVal value As String)
            Provincia = UCase(value)
        End Set
    End Property

    Public Property gidAutonomia() As Integer
        Get
            Return idAutonomia
        End Get
        Set(ByVal value As Integer)
            idAutonomia = value
        End Set
    End Property

    Public Property gAutonomia() As String
        Get
            Return UCase(Autonomia)
        End Get
        Set(ByVal value As String)
            Autonomia = UCase(value)
        End Set
    End Property

End Class
