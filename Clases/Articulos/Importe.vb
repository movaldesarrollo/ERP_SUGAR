Public Class Importe

    Private Valor As Double
    Private codMoneda As String
    Private Simbolo As String

    Public Property gValor() As Double
        Get
            Return Valor
        End Get
        Set(ByVal value As Double)
            Valor = value
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



End Class
