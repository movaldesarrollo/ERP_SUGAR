Public Class datosProveedor

    Private idProveedor As Integer
    Private codProveedor As String
    Private nombrecomercial As String
    Private nombrefiscal As String
    Private nif As String
    Private fechaAlta As Date
    Private fechaBaja As Date
    Private horario As String
    Private observaciones As String
    Private Activo As Boolean
    Private IdTipoCompra As Integer
    Private web As String
    Private TipoCompra As String
    Private codContable As Integer
    Private suCliente As String
    'Otras tablas
    Private idPais As Integer 'Es el pais de la ubicación Fiscal
    Private pais As String 'Es el pais de la ubicación Fiscal
    Private codMoneda As String 'Es la moneda especificada en la tabla Facturacion

    Public Property gPais() As String
        Get
            Return UCase(Pais)
        End Get
        Set(ByVal value As String)
            Pais = UCase(value)
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

    Public Property gcodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
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

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gIdTipoCompra() As Integer
        Get
            Return IdTipoCompra
        End Get
        Set(ByVal value As Integer)
            IdTipoCompra = value
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

    Public Property gcodProveedor() As String
        Get
            Return UCase(codProveedor)
        End Get
        Set(ByVal value As String)
            codProveedor = UCase(value)
        End Set
    End Property

    Public Property gnombrecomercial() As String
        Get
            Return UCase(nombrecomercial)
        End Get
        Set(ByVal value As String)
            nombrecomercial = UCase(value)
        End Set
    End Property

    Public Property gnombrefiscal() As String
        Get
            Return UCase(nombrefiscal)
        End Get
        Set(ByVal value As String)
            nombrefiscal = UCase(value)
        End Set
    End Property

    Public Property gnif() As String
        Get
            Return UCase(nif)
        End Get
        Set(ByVal value As String)
            nif = UCase(value)
        End Set
    End Property

    Public Property gweb() As String
        Get
            Return web
        End Get
        Set(ByVal value As String)
            web = value
        End Set
    End Property

    Public Property gfechaBaja() As Date
        Get
            Return fechaBaja
        End Get
        Set(ByVal value As Date)
            fechaBaja = value
        End Set
    End Property

    Public Property gobservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

    Public Property gFechaAlta() As Date
        Get
            Return fechaAlta
        End Get
        Set(ByVal value As Date)
            fechaAlta = value
        End Set
    End Property
 
    Public Property ghorario() As String
        Get
            Return UCase(horario)
        End Get
        Set(ByVal value As String)
            horario = UCase(value)
        End Set
    End Property
  
    Public Property gcodContable() As Integer
        Get
            Return codContable
        End Get
        Set(ByVal value As Integer)
            codContable = value
        End Set
    End Property

    Public Property gSuCliente() As String
        Get
            Return suCliente
        End Get
        Set(ByVal value As String)
            suCliente = value
        End Set
    End Property

End Class
