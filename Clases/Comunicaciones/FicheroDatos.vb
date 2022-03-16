Public Class datosFichero

    Private idFichero As Integer
    Private idComunicacion As Integer
    Private Ruta As String = ""
    Private Fichero As String = ""
    Private Extension As String = ""

    Public Property gidComunicacion() As Integer
        Get
            Return idComunicacion
        End Get
        Set(ByVal value As Integer)
            idComunicacion = value
        End Set
    End Property




    Public Property gidFichero() As Integer
        Get
            Return idFichero
        End Get
        Set(ByVal value As Integer)
            idFichero = value
        End Set
    End Property


    Public Property gFichero() As String
        Get
            Return Fichero
        End Get
        Set(ByVal value As String)
            Fichero = value
        End Set
    End Property

    Public Property gRuta() As String
        Get
            Return Ruta
        End Get
        Set(ByVal value As String)
            Ruta = value
        End Set
    End Property

    Private Property gExtension() As String
        Get
            If InStr(Fichero, ".") <> 0 Then
                Return Microsoft.VisualBasic.Right(Fichero, Len(Fichero) - InStrRev(Fichero, "."))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            Extension = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Fichero
    End Function

End Class
