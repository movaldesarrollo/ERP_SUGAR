Public Class datosReferencia

    Private idReferencia As Integer
    Private idComunicacion As Integer
    Private Documento As String = ""
    Private Referencia As String = ""
  




    Public Property gidComunicacion() As Integer
        Get
            Return idComunicacion
        End Get
        Set(ByVal value As Integer)
            idComunicacion = value
        End Set
    End Property

 


    Public Property gidReferencia() As Integer
        Get
            Return idReferencia
        End Get
        Set(ByVal value As Integer)
            idReferencia = value
        End Set
    End Property


    Public Property gReferencia() As String
        Get
            Return Referencia
        End Get
        Set(ByVal value As String)
            Referencia = value
        End Set
    End Property

    Public Property gDocumento() As String
        Get
            Return Documento
        End Get
        Set(ByVal value As String)
            Documento = value
        End Set
    End Property


  
    Public Overrides Function ToString() As String
        Return Documento & " " & Referencia
    End Function

End Class
