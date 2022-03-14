Public Class DatosEtiqueta


    Private idEtiqueta As Integer = 0
    Private Nombre As String
    Private Fichero As String
    Private EtiquetaEditada As Boolean = False
    Private Observaciones As String
    Private Activo As Boolean
    Private idCliente As Integer

    Private Cliente As String
   

    Public Property gidEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(ByVal value As Integer)
            idEtiqueta = value
        End Set
    End Property



    Public Property gNombre() As String
        Get
            Return UCase(Nombre)
        End Get
        Set(ByVal value As String)
            Nombre = UCase(value)
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

    Public Property gEtiquetaEditada() As Boolean
        Get
            Return EtiquetaEditada
        End Get
        Set(ByVal value As Boolean)
            EtiquetaEditada = value
        End Set
    End Property

    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
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

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
        End Set
    End Property
  
    Public Overrides Function ToString() As String
        Return Nombre
    End Function

    Public Sub New()

    End Sub

End Class
