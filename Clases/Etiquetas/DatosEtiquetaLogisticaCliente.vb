Public Class DatosEtiquetaLogisticaCliente
    Private idEtiqueta As Integer
    Private idCliente As Integer
    Private idEtiquetaFinal As Integer
    Private imagen As Byte()
    Private width As Integer
    Private height As Integer
    Private codArticulo As String
    Private isPDF As Boolean
    Private pathPDF As String
    Private idArticulo As Integer

    Public Sub New()
    End Sub

    Public Sub New(idEtiqueta1 As Integer, idCliente1 As Integer, idEtiquetaFinal1 As Integer, imagen1() As Byte, width1 As Integer, height1 As Integer, codArticulo1 As String)
        Me.IdEtiqueta1 = idEtiqueta1
        Me.IdCliente1 = idCliente1
        Me.IdEtiquetaFinal1 = idEtiquetaFinal1
        Me.Imagen1 = imagen1
        Me.Width1 = width1
        Me.Height1 = height1
        Me.CodArticulo1 = codArticulo1
    End Sub

    Public Sub New(idEtiqueta1 As Integer, idCliente1 As Integer, idEtiquetaFinal1 As Integer, imagen1() As Byte, width1 As Integer, height1 As Integer, codArticulo1 As String, gPathPDF As String, gIdArticulo As Integer)
        Me.IdEtiqueta1 = idEtiqueta1
        Me.IdCliente1 = idCliente1
        Me.IdEtiquetaFinal1 = idEtiquetaFinal1
        Me.Imagen1 = imagen1
        Me.Width1 = width1
        Me.Height1 = height1
        Me.CodArticulo1 = codArticulo1
        Me.gPathPDF = gPathPDF
        Me.gIdArticulo = gIdArticulo
    End Sub

    Public Property IdEtiqueta1 As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
        End Set
    End Property

    Public Property IdCliente1 As Integer
        Get
            Return idCliente
        End Get
        Set(value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property IdEtiquetaFinal1 As Integer
        Get
            Return idEtiquetaFinal
        End Get
        Set(value As Integer)
            idEtiquetaFinal = value
        End Set
    End Property

    Public Property Imagen1 As Byte()
        Get
            Return imagen
        End Get
        Set(value As Byte())
            imagen = value
        End Set
    End Property

    Public Property Width1 As Integer
        Get
            Return width
        End Get
        Set(value As Integer)
            width = value
        End Set
    End Property

    Public Property Height1 As Integer
        Get
            Return height
        End Get
        Set(value As Integer)
            height = value
        End Set
    End Property

    Public Property CodArticulo1 As String
        Get
            Return codArticulo
        End Get
        Set(value As String)
            codArticulo = value
        End Set
    End Property

    Public Property gIsPDF As Boolean
        Get
            Return isPDF
        End Get
        Set(value As Boolean)
            isPDF = value
        End Set
    End Property

    Public Property gPathPDF As String
        Get
            Return pathPDF
        End Get
        Set(value As String)
            pathPDF = value
        End Set
    End Property

    Public Property gIdArticulo As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property
End Class
