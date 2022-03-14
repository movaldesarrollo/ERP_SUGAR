Public Class CeldaVista

    Private Fila As Integer
    Private Columna As Integer
    Private Contenido As String
    Private ColorLetra As Color
    Private ColorFondo As Color
    Private Fuente As Font
    Private Alineacion As DataGridViewContentAlignment
    Private Referencia As String
    Private Numero1 As Integer
    Private Numero2 As Integer
    Private Referencia2 As String

    Public Property gFila() As Integer
        Get
            Return Fila
        End Get
        Set(ByVal value As Integer)
            Fila = value
        End Set
    End Property

    Public Property gColumna() As Integer
        Get
            Return Columna
        End Get
        Set(ByVal value As Integer)
            Columna = value
        End Set
    End Property

    Public Property gContenido() As String
        Get
            Return Contenido
        End Get
        Set(ByVal value As String)
            Contenido = value
        End Set
    End Property


    Public Property gColorLetra() As Color
        Get
            Return ColorLetra
        End Get
        Set(ByVal value As Color)
            ColorLetra = value
        End Set
    End Property


    Public Property gColorFondo() As Color
        Get
            Return ColorFondo
        End Get
        Set(ByVal value As Color)
            ColorFondo = value
        End Set
    End Property

    Public Property gFuente() As Font
        Get
            Return Fuente
        End Get
        Set(ByVal value As Font)
            Fuente = value
        End Set
    End Property

    Public Property gAlineacion() As DataGridViewContentAlignment
        Get
            Return Alineacion
        End Get
        Set(ByVal value As DataGridViewContentAlignment)
            Alineacion = value
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

    Public Property gReferencia2() As String
        Get
            Return Referencia2
        End Get
        Set(ByVal value As String)
            Referencia2 = value
        End Set
    End Property

    Public Property gNum1() As Integer
        Get
            Return Numero1
        End Get
        Set(ByVal value As Integer)
            Numero1 = value
        End Set
    End Property

    Public Property gNum2() As Integer
        Get
            Return Numero2
        End Get
        Set(ByVal value As Integer)
            Numero2 = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Fila As Integer, ByVal Columna As Integer, ByVal Contenido As String)
        gFila = Fila
        gColumna = Columna
        gContenido = Contenido
    End Sub

    Public Sub New(ByVal Fila As Integer, ByVal Columna As Integer, ByVal Contenido As String, ByVal ColorLetra As Color, ByVal ColorFondo As Color, ByVal Fuente As Font, ByVal Alineacion As DataGridViewContentAlignment, ByVal Referencia As String, ByVal Referencia2 As String)
        gFila = Fila
        gColumna = Columna
        gContenido = Contenido
        gColorLetra = ColorLetra
        gColorFondo = ColorFondo
        gFuente = Fuente
        gAlineacion = Alineacion
        gReferencia = Referencia
        gReferencia2 = Referencia
    End Sub

    Public Overrides Function ToString() As String
        Return Contenido
    End Function
End Class
