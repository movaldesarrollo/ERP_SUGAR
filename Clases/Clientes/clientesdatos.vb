Public Class datoscliente
    Private idCliente As Integer
    Private codCli As String
    Private codContable As String
    Private nombrecomercial As String
    Private nombrefiscal As String
    Private fechaAlta As Date
    Private fechaBaja As Date
    Private Activo As Boolean
    Private nif As String
    Private web As String
    Private observaciones As String
    Private idResponsableCuenta As Integer
    Private ObservacionesProd As String
   
  
    'Otras tablas
    Private idPais As Integer 'Es el pais de la ubicación Fiscal
    Private pais As String 'Es el pais de la ubicación Fiscal
    Private codMoneda As String 'Es la moneda especificada en la tabla Facturacion
    Private ResponsableCuenta As String
    Private SubClientes As String = "" 'Cadena con los subclientes separados por coma. Sólo se usa en la búsqeda



    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
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

    Public Property gcodCli() As String
        Get
            Return UCase(codCli)
        End Get
        Set(ByVal value As String)
            codCli = UCase(value)
        End Set
    End Property

    Public Property gcodContable() As String
        Get
            Return codContable
        End Get
        Set(ByVal value As String)
            codContable = value
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

    Public Property gidResponsableCuenta() As Integer
        Get
            Return idResponsableCuenta
        End Get
        Set(ByVal value As Integer)
            idResponsableCuenta = value
        End Set
    End Property


    Public Property gObservacionesProd() As String
        Get
            Return ObservacionesProd
        End Get
        Set(ByVal value As String)
            ObservacionesProd = value
        End Set
    End Property



    Public Property gResponsableCuenta() As String
        Get
            Return Trim(UCase(ResponsableCuenta))
        End Get
        Set(ByVal value As String)
            ResponsableCuenta = Trim(UCase(value))
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
            Return UCase(pais)
        End Get
        Set(ByVal value As String)
            pais = UCase(value)
        End Set
    End Property



    Public Property gnombrecomercial() As String
        Get
            Return Trim(UCase(nombrecomercial))
        End Get
        Set(ByVal value As String)
            nombrecomercial = Trim(UCase(value))
        End Set
    End Property
    Public Property gnombrefiscal() As String
        Get
            Return Trim(UCase(nombrefiscal))
        End Get
        Set(ByVal value As String)
            nombrefiscal = Trim(UCase(value))
        End Set
    End Property
    Public Property gnif() As String
        Get
            Return Trim(UCase(nif))
        End Get
        Set(ByVal value As String)
            nif = Trim(UCase(value))
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

    Public Property gfechaAlta() As Date
        Get
            Return fechaAlta
        End Get
        Set(ByVal value As Date)
            fechaAlta = value
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

    Public Property gSubClientes() As String
        Get
            Return SubClientes
        End Get
        Set(ByVal value As String)
            SubClientes = value
        End Set
    End Property
 

End Class
