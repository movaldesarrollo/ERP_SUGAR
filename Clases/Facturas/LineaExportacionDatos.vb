Public Class DatosLineaExportacion


    Private idLinea As Long
    Private numFactura As Integer
    Private Titulo As String
    Private Texto As String
   


    Public Property gidLinea() As Integer
        Get
            Return idLinea
        End Get
        Set(ByVal value As Integer)
            idLinea = value
        End Set
    End Property



    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
        End Set
    End Property

  

    Public Property gTitulo() As String
        Get
            Return Titulo
        End Get
        Set(ByVal value As String)
            Titulo = value
        End Set
    End Property

    Public Property gTexto() As String
        Get
            Return Texto
        End Get
        Set(ByVal value As String)
            Texto = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal numFactura As Integer, ByVal Titulo As String, ByVal Texto As String)
        gnumFactura = numFactura
        gTitulo = Titulo
        gTexto = Texto
    End Sub


End Class

