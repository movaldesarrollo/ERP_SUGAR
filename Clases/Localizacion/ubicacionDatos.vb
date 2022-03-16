Public Class datosUbicacion

    Private idUbicacion As Integer
    Private idTipoUbicacion As Integer
    Private idCliente As Integer
    Private idProveedor As Integer
    Private FechaAlta As Date
    Private FechaBaja As Date
    Private Direccion As String
    Private SubCliente As String
    Private NoMuestraCliente As Boolean
    Private Localidad As String
    Private codPostal As String
    Private Provincia As String
    Private Horario As String
    Private Observaciones As String
    Private Activo As Boolean
    Private idPais As Integer = 1
    Private idIdioma As Integer = 1
    Private Portes As Char
    Private idTransporte As Integer
    Private Transporte As String


    'Datos de otras tablas

    Private TipoUbicacion As String
    Private Pais As String
    Private Idioma As String
    Private AgenciaTransporte As String
    Private Exportacion As Boolean
    Private NIFObligatorio As Boolean

    Public Property gidUbicacion() As Integer
        Get
            Return idUbicacion
        End Get
        Set(ByVal value As Integer)
            idUbicacion = value
        End Set
    End Property

    Public Property gidTipoUbicacion() As Integer
        Get
            Return idTipoUbicacion
        End Get
        Set(ByVal value As Integer)
            idTipoUbicacion = value
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


    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gfechaAlta() As Date
        Get
            Return FechaAlta
        End Get
        Set(ByVal value As Date)
            FechaAlta = value
        End Set
    End Property

    Public Property gfechaBaja() As Date
        Get
            Return FechaBaja
        End Get
        Set(ByVal value As Date)
            FechaBaja = value
        End Set
    End Property

    Public Property gdireccion() As String
        Get
            Return UCase(Direccion)
        End Get
        Set(ByVal value As String)
            Direccion = UCase(value)
        End Set
    End Property

    Public Property gSubCliente() As String
        Get
            Return UCase(SubCliente)
        End Get
        Set(ByVal value As String)
            SubCliente = UCase(value)
        End Set
    End Property


    Public Property gNoMuestraCliente() As Boolean
        Get
            Return NoMuestraCliente
        End Get
        Set(ByVal value As Boolean)
            NoMuestraCliente = value
        End Set
    End Property




    Public Property glocalidad() As String
        Get
            Return UCase(Localidad)
        End Get
        Set(ByVal value As String)
            Localidad = UCase(value)
        End Set
    End Property

    Public Property gcodpostal() As String
        Get
            Return codPostal
        End Get
        Set(ByVal value As String)
            codPostal = value
        End Set
    End Property



    Public Property gprovincia() As String
        Get
            Return UCase(Provincia)
        End Get
        Set(ByVal value As String)
            Provincia = UCase(value)
        End Set
    End Property


    Public Property ghorario() As String
        Get
            Return UCase(Horario)
        End Get
        Set(ByVal value As String)
            Horario = UCase(value)
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


    Public Property gActivo()
        Get
            Return Activo
        End Get
        Set(ByVal value)
            Activo = value
        End Set
    End Property

    Public Property gidPais()
        Get
            Return idPais
        End Get
        Set(ByVal value)
            idPais = value
        End Set
    End Property

    Public Property gidIdioma() As Integer
        Get
            Return idIdioma
        End Get
        Set(ByVal value As Integer)
            idIdioma = value
        End Set
    End Property


    Public Property gPortes() As Char
        Get
            Return Portes
        End Get
        Set(ByVal value As Char)
            Portes = value
        End Set
    End Property

    Public Property gidTransporte() As Integer
        Get
            Return idTransporte
        End Get
        Set(ByVal value As Integer)
            idTransporte = value
        End Set
    End Property

    Public Property gTransporte() As String
        Get
            Return Transporte
        End Get
        Set(ByVal value As String)
            Transporte = value
        End Set
    End Property




    Public Property gTipoUbicacion() As String
        Get
            Return UCase(TipoUbicacion)
        End Get
        Set(ByVal value As String)
            TipoUbicacion = UCase(value)
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

    Public Property gIdioma() As String
        Get
            Return Idioma
        End Get
        Set(ByVal value As String)
            Idioma = value
        End Set
    End Property

    Public Property gAgenciaTransporte() As String
        Get
            Return AgenciaTransporte
        End Get
        Set(ByVal value As String)
            AgenciaTransporte = value
        End Set
    End Property

    Public Property gExportacion() As Boolean
        Get
            Return Exportacion
        End Get
        Set(ByVal value As Boolean)
            Exportacion = value
        End Set
    End Property

    Public Property gNIFObligatorio() As Boolean
        Get
            Return NIFObligatorio
        End Get
        Set(ByVal value As Boolean)
            NIFObligatorio = value
        End Set
    End Property


End Class
