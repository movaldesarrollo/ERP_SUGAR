Public Class CamposEtiquetaFinalLinea
    Dim idEtiqueta As Integer
    Dim refCliente As String
    Dim customerPartNumber As String
    Dim EAN13 As String
    Dim numSerie As Integer
    Dim cantidad As Integer
    Dim PV As Integer 'pedido de venta
    Dim logoCE As Integer
    Dim logoCMIN As Integer
    Dim logoEAC As Integer
    Dim logoUKCA As Integer
    Dim logoLPX3 As Integer
    Dim logoUL As Integer
    Dim logoWEEE As Integer
    Dim logoMADEINSPAIN As Integer

    Public Property gIdEtiqueta As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
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

    Public Property gNumSerie As Integer
        Get
            Return numSerie
        End Get
        Set(value As Integer)
            numSerie = value
        End Set
    End Property

    Public Property gCantidad As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
        End Set
    End Property

    Public Property gPV As Integer
        Get
            Return PV
        End Get
        Set(value As Integer)
            PV = value
        End Set
    End Property

    Public Property gLogoCE As Integer
        Get
            Return logoCE
        End Get
        Set(value As Integer)
            logoCE = value
        End Set
    End Property

    Public Property gLogoCMIN As Integer
        Get
            Return logoCMIN
        End Get
        Set(value As Integer)
            logoCMIN = value
        End Set
    End Property

    Public Property gLogoEAC As Integer
        Get
            Return logoEAC
        End Get
        Set(value As Integer)
            logoEAC = value
        End Set
    End Property

    Public Property gLogoUKCA As Integer
        Get
            Return logoUKCA
        End Get
        Set(value As Integer)
            logoUKCA = value
        End Set
    End Property

    Public Property gLogoLPX3 As Integer
        Get
            Return logoLPX3
        End Get
        Set(value As Integer)
            logoLPX3 = value
        End Set
    End Property

    Public Property gLogoUL As Integer
        Get
            Return logoUL
        End Get
        Set(value As Integer)
            logoUL = value
        End Set
    End Property

    Public Property gLogoWEEE As Integer
        Get
            Return logoWEEE
        End Get
        Set(value As Integer)
            logoWEEE = value
        End Set
    End Property

    Public Property gLogoMADEINSPAIN As Integer
        Get
            Return logoMADEINSPAIN
        End Get
        Set(value As Integer)
            logoMADEINSPAIN = value
        End Set
    End Property

    Public Property gCustomerPartNumber As String
        Get
            Return customerPartNumber
        End Get
        Set(value As String)
            customerPartNumber = value
        End Set
    End Property

    Public Property gEAN13 As String
        Get
            Return EAN13
        End Get
        Set(value As String)
            EAN13 = value
        End Set
    End Property

End Class
