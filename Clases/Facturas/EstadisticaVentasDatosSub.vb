Public Class DatosEstadisticaVentasSub

    Private Columna_0 As Integer
    Private Columna_1 As String
    Private Cantidad As Double
    Private Base As Double
    Private codMoneda As String
    Private Simbolo As String
    Private coste As String

    Public Property gColumna_0() As Integer
        Get
            Return Columna_0
        End Get
        Set(ByVal value As Integer)
            Columna_0 = value
        End Set
    End Property

    Public Property gColumna_1() As String
        Get
            Return Columna_1
        End Get
        Set(ByVal value As String)
            Columna_1 = value
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

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
        End Set
    End Property

    Public Property gCoste() As String
        Get
            Return coste
        End Get
        Set(ByVal value As String)
            coste = value
        End Set
    End Property

    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property gBase() As Double
        Get
            Return Base
        End Get
        Set(ByVal value As Double)
            Base = value
        End Set
    End Property

End Class