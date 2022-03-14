Public Class DatosArticuloClientePrecio

    Private idArtCliPrecio As Long
    Private idArtCli As Long
    Private PrecioNetoUnitario As Double
    Private codMoneda As String
    Private Activo As Boolean

    Private simbolo As String


    Public Property gidArtCliPrecio() As Long
        Get
            Return idArtCliPrecio
        End Get
        Set(ByVal value As Long)
            idArtCliPrecio = value
        End Set
    End Property

    Public Property gidArtCli() As Long
        Get
            Return idArtCli
        End Get
        Set(ByVal value As Long)
            idArtCli = value
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
