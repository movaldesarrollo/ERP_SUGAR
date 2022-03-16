Imports ERP_SUGAR

Public Class DatosEtiquetaCliente
    Private idEtiqueta As Integer
    Private idCliente As Integer
    Private idEtiquetaFinal As Integer
    Private imagen As Byte()
    Private width As Integer
    Private height As Integer

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

End Class
