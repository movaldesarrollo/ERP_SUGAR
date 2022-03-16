Public Class datosPerfiles

    Dim Perfil As String
    Dim descripcion As String
    Dim soloLectura As Boolean
    Dim idPerfil As Integer


    Public Property gidPerfil() As Integer
        Get
            Return idPerfil
        End Get
        Set(ByVal value As Integer)
            idPerfil = value
        End Set
    End Property


    Public Property gdescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Public Property gPerfil() As String
        Get
            Return Perfil
        End Get
        Set(ByVal value As String)
            Perfil = value
        End Set
    End Property

   
    Public Property gSoloLectura()
        Get
            Return soloLectura
        End Get
        Set(ByVal value)
            soloLectura = value
        End Set
    End Property
   
    Public Sub New()

    End Sub

End Class
