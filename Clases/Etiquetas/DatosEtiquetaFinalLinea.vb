Public Class DatosEtiquetaFinalLinea
    Dim cbCE As Boolean
    Dim cbCMIN As Boolean
    Dim cbEAC As Boolean
    Dim cbLPX3 As Boolean
    Dim cbUL As Boolean
    Dim cbWEEEE As Boolean
    Dim cbUKCA As Boolean
    Dim cbMadeInSpain As Boolean
    Dim numserie As String
    Dim refCliente As String
    Dim cantidad As Integer
    Dim pv As Integer
    Dim articuloCliente As String
    Dim EAN13 As Integer


    Public Property gCbCE As Boolean
        Get
            Return cbCE
        End Get
        Set(value As Boolean)
            cbCE = value
        End Set
    End Property

    Public Property gCbCMIN As Boolean
        Get
            Return cbCMIN
        End Get
        Set(value As Boolean)
            cbCMIN = value
        End Set
    End Property

    Public Property gCbEAC As Boolean
        Get
            Return cbEAC
        End Get
        Set(value As Boolean)
            cbEAC = value
        End Set
    End Property

    Public Property gCbLPX3 As Boolean
        Get
            Return cbLPX3
        End Get
        Set(value As Boolean)
            cbLPX3 = value
        End Set
    End Property

    Public Property gCbUL As Boolean
        Get
            Return cbUL
        End Get
        Set(value As Boolean)
            cbUL = value
        End Set
    End Property

    Public Property gCbWEEEE As Boolean
        Get
            Return cbWEEEE
        End Get
        Set(value As Boolean)
            cbWEEEE = value
        End Set
    End Property

    Public Property gCbUKCA As Boolean
        Get
            Return cbUKCA
        End Get
        Set(value As Boolean)
            cbUKCA = value
        End Set
    End Property

    Public Property gCbMadeInSpain As Boolean
        Get
            Return cbMadeInSpain
        End Get
        Set(value As Boolean)
            cbMadeInSpain = value
        End Set
    End Property

    Public Property gNumserie As String
        Get
            Return numserie
        End Get
        Set(value As String)
            numserie = value
        End Set
    End Property

    Public Property gRefCliente As String
        Get
            Return refCliente
        End Get
        Set(value As String)
            refCliente = value
        End Set
    End Property

    Public Property gCantidad1 As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
        End Set
    End Property

    Public Property gPv As Integer
        Get
            Return pv
        End Get
        Set(value As Integer)
            pv = value
        End Set
    End Property

    Public Property gArticuloCliente As String
        Get
            Return articuloCliente
        End Get
        Set(value As String)
            articuloCliente = value
        End Set
    End Property

    Public Property gEAN13 As Integer
        Get
            Return EAN13
        End Get
        Set(value As Integer)
            EAN13 = value
        End Set
    End Property
End Class
