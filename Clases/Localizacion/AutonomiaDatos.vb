Public Class datosAutonomia
    Private idAutonomia As Integer
    Private Autonomia As String
   

    Public Property gidAutonomia() As Integer
        Get
            Return idAutonomia
        End Get
        Set(ByVal value As Integer)
            idAutonomia = value
        End Set
    End Property

    Public Property gAutonomia() As String
        Get
            Return Trim(UCase(Autonomia))
        End Get
        Set(ByVal value As String)
            Autonomia = Trim(UCase(value))
        End Set
    End Property

    Public Sub New(ByVal idAutonomia As Integer, ByVal Autonomia As String)
        gidAutonomia = idAutonomia
        gAutonomia = Autonomia
       
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return UCase(Autonomia)
    End Function

End Class
