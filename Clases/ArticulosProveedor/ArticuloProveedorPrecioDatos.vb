Public Class DatosArticuloProvPrecio

    Private idArtProvPrecio As Long
    Private idArtProv As Long
    Private PrecioNetoUnitario As Double
    Private codMoneda As String
    Private Activo As Boolean

    Private simbolo As String


    Public Property gidArtProvPrecio() As Long
        Get
            Return idArtProvPrecio
        End Get
        Set(ByVal value As Long)
            idArtProvPrecio = value
        End Set
    End Property

    Public Property gidArtProv() As Long
        Get
            Return idArtProv
        End Get
        Set(ByVal value As Long)
            idArtProv = value
        End Set
    End Property



    Public Property gPrecioNetoUnitario() As Double
        Get
            Return PrecioNetoUnitario
        End Get
        Set(ByVal value As Double)
            PrecioNetoUnitario = value
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


    Public Property gSimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property




End Class
