Public Class ParSeccionUnidades
    Private idSeccion As Integer
    Private Unidades As Integer


    Public Sub New()
        gidSeccion = 0
        gUnidades = 0
    End Sub



    Public Sub New(ByVal idSeccion As Integer, ByVal Unidades As Integer)
        gidSeccion = idSeccion
        gUnidades = Unidades
    End Sub



    Public Property gidSeccion() As Integer
        Get
            Return idSeccion
        End Get
        Set(ByVal sValue As Integer)
            idSeccion = sValue
        End Set
    End Property



    Public Property gUnidades() As Integer
        Get
            Return Unidades
        End Get
        Set(ByVal iValue As Integer)
            Unidades = iValue
        End Set
    End Property


End Class
