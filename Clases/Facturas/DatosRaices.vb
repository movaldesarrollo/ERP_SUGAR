Public Class DatosRaices

    Private Columna_0 As Integer
    Private Columna_1 As String

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
End Class