Public Class DatosArticuloPrecio

    Private idArticuloPrecio As Long
    Private idArticulo As Integer
    Private Precio As Double
    Private codMoneda As String
    Private TipoPrecio As Char 'Tipo de precio: C=Coste, V=Venta, O=Opción venta accesorio
    Private FechaPrecio As Date
    Private idProveedorPrecio As Integer
    Private idClientePrecio As Integer
    Private idConcepto As Integer
    Private Descuento As Double
    Private Activo As Boolean
    Private Version As Integer

    'Otras tablas
    Private Simbolo As String


    Public Property gidProveedorPrecio() As Integer
        Get
            Return idProveedorPrecio
        End Get
        Set(ByVal value As Integer)
            idProveedorPrecio = value
        End Set
    End Property

    Public Property gidClientePrecio() As Integer
        Get
            Return idClientePrecio
        End Get
        Set(ByVal value As Integer)
            idClientePrecio = value
        End Set
    End Property

    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property

    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Public Property gidArticuloPrecio() As Long
        Get
            Return idArticuloPrecio
        End Get
        Set(ByVal value As Long)
            idArticuloPrecio = value
        End Set
    End Property

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property gPrecio() As Double
        Get
            Return Precio
        End Get
        Set(ByVal value As Double)
            Precio = value
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

    Public Property gTipoPrecio() As Char
        Get
            Return TipoPrecio
        End Get
        Set(ByVal value As Char)
            TipoPrecio = value
        End Set
    End Property

    Public Property gFechaPrecio() As Date
        Get
            Return FechaPrecio
        End Get
        Set(ByVal value As Date)
            FechaPrecio = value
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

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
        End Set
    End Property

    Public Property gVersion() As Integer
        Get
            Return Version
        End Get
        Set(ByVal value As Integer)
            Version = value
        End Set
    End Property

End Class
