Public Class DatosEtiquetaImpresora

    Private idEtiquetaImp As Integer
    Private idEtiqueta As Integer
    Private Impresora As String
    Private MargenIzq As Integer
    Private MargenDer As Integer
    Private MargenSup As Integer
    Private MargenInf As Integer


    Public Property gidEtiquetaImp() As Integer
        Get
            Return idEtiquetaImp
        End Get
        Set(ByVal value As Integer)
            idEtiquetaImp = value
        End Set
    End Property


    Public Property gidEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(ByVal value As Integer)
            idEtiqueta = value
        End Set
    End Property

    Public Property gImpresora() As String
        Get
            Return Impresora
        End Get
        Set(ByVal value As String)
            Impresora = value
        End Set
    End Property

    Public Property gMargenDer() As Integer
        Get
            Return MargenDer
        End Get
        Set(ByVal value As Integer)
            MargenDer = value
        End Set
    End Property


    Public Property gMargenIzq() As Integer
        Get
            Return MargenIzq
        End Get
        Set(ByVal value As Integer)
            MargenIzq = value
        End Set
    End Property

    Public Property gMargenSup() As Integer
        Get
            Return MargenSup
        End Get
        Set(ByVal value As Integer)
            MargenSup = value
        End Set
    End Property


    Public Property gMargenInf() As Integer
        Get
            Return MargenInf
        End Get
        Set(ByVal value As Integer)
            MargenInf = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return Impresora
    End Function



    Public Sub New()

    End Sub

    Public Sub New(ByVal idEtiqueta As Integer, ByVal Impresora As String, ByVal MargenIzq As Integer, ByVal MargenDer As Integer, ByVal MargenSup As Integer, ByVal MargenInf As Integer)
        gidEtiqueta = idEtiqueta
        gMargenInf = MargenInf
        gMargenSup = MargenSup
        gMargenIzq = MargenIzq
        gMargenDer = MargenDer
    End Sub

End Class
