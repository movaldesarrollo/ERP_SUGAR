Public Class DatosInventario

    Private idArticulo As Integer
    Private codArticulo As String
    Private Articulo As String
    Private Activo As Boolean
    Private idTipoCompra As Integer
    Private precioActual As Double
    Private valor As Double
    Private stock As Double
    Private Almacen As String
    Private unidad As String
    Private seccion As String
    Private suprimir As String
    

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gcodArticulo() As String
        Get
            Return UCase(codArticulo)
        End Get
        Set(ByVal value As String)
            codArticulo = UCase(value)
        End Set
    End Property

    Public Property gSeccion() As String
        Get
            Return seccion
        End Get
        Set(ByVal value As String)
            seccion = value
        End Set
    End Property

    Public Property gSuprimir() As String
        Get
            Return suprimir
        End Get
        Set(ByVal value As String)
            suprimir = value
        End Set
    End Property

    Public Property gArticulo() As String
        Get
            Return UCase(Articulo)
        End Get
        Set(ByVal value As String)
            Articulo = UCase(value)
        End Set
    End Property

    Public Property gAlmacen() As String
        Get
            Return UCase(Almacen)
        End Get
        Set(ByVal value As String)
            Almacen = UCase(value)
        End Set
    End Property

    Public Property gUnidad() As String
        Get
            Return UCase(unidad)
        End Get
        Set(ByVal value As String)
            unidad = UCase(value)
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


    Public Property gidTipoCompra() As Integer
        Get
            Return idTipoCompra
        End Get
        Set(ByVal value As Integer)
            idTipoCompra = value
        End Set
    End Property

    Public Property gStock() As Double
        Get
            Return stock
        End Get
        Set(ByVal value As Double)
            stock = value
        End Set
    End Property

    Public Property gPrecioActual() As Double
        Get
            Return precioActual
        End Get
        Set(ByVal value As Double)
            precioActual = value
        End Set
    End Property

    Public Property gValor() As Double
        Get
            Return valor
        End Get
        Set(ByVal value As Double)
            valor = value
        End Set
    End Property


End Class
