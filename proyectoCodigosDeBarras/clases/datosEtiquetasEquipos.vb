Public Class datosEtiquetasEquipos

#Region "VARIABLES"

    Dim idEtiqueta As Integer
    Dim idCliente As Integer
    Dim cliente As String
    Dim idArticulo As Integer
    Dim articulo As String
    Dim articuloCliente As String
    Dim logoCliente As Image
    Dim inputText As String
    Dim outputText As String
    Dim web As String
    Dim logoBottonLeft As Image
    Dim logoBottonRight As Image
    Dim imagenAltoLogoCliente As Integer
    Dim imagenAnchoLogoCliente As Integer
    Dim imagenAltoLogoDerecha As Integer
    Dim imagenAnchoLogoDerecha As Integer
    Dim imagenAltoLogoIzquierda As Integer
    Dim imagenAnchoLogoIzquierda As Integer
    Dim idCamposEtiquetasPedidos As Boolean
    Dim campoWeb As Boolean
    Dim logoCE As Boolean
    Dim logoCMIN As Boolean
    Dim logoEAC As Boolean
    Dim logoUKCA As Boolean
    Dim logoLPX3 As Boolean
    Dim logoUL As Boolean
    Dim logoWEEEE As Boolean
    Dim madeInSpain As Boolean
    Dim monosku As String
    Dim eti0 As String
    Dim val0 As String
    Dim id0 As Integer
    Dim eti1 As String
    Dim val1 As String
    Dim id1 As Integer
    Dim eti2 As String
    Dim val2 As String
    Dim id2 As Integer
    Dim eti3 As String
    Dim val3 As String
    Dim id3 As Integer
    Dim eti4 As String
    Dim val4 As String
    Dim id4 As Integer
    Dim eti5 As String
    Dim val5 As String
    Dim id5 As Integer
    Dim eti6 As String

#End Region

#Region "PROPIEDADES"

    Property pIdCamposEtiquetasPedidos As Boolean
        Get
            Return idCamposEtiquetasPedidos
        End Get
        Set(value As Boolean)
            idCamposEtiquetasPedidos = value
        End Set
    End Property

    Property pImagenAltoLogoIzquierda As Integer
        Get
            Return imagenAltoLogoIzquierda
        End Get
        Set(value As Integer)
            imagenAltoLogoIzquierda = value
        End Set
    End Property

    Property pImagenAnchoLogoIzquierda As Integer
        Get
            Return imagenAnchoLogoIzquierda
        End Get
        Set(value As Integer)
            imagenAnchoLogoIzquierda = value
        End Set
    End Property

    Property pImagenAltoLogoDerecha As Integer
        Get
            Return imagenAltoLogoDerecha
        End Get
        Set(value As Integer)
            imagenAltoLogoDerecha = value
        End Set
    End Property

    Property pImagenAnchoLogoDerecha As Integer
        Get
            Return imagenAnchoLogoDerecha
        End Get
        Set(value As Integer)
            imagenAnchoLogoDerecha = value
        End Set
    End Property

    Property pImagenAltoLogoCliente As Integer
        Get
            Return imagenAltoLogoCliente
        End Get
        Set(value As Integer)
            imagenAltoLogoCliente = value
        End Set
    End Property

    Property pImagenAnchoLogoCliente As Integer
        Get
            Return imagenAnchoLogoCliente
        End Get
        Set(value As Integer)
            imagenAnchoLogoCliente = value
        End Set
    End Property

    Property pCliente() String
        Get
            Return cliente
        End Get
        Set(value)
            cliente = value
        End Set
    End Property

    Property pArticuloCliente() String
        Get
            Return articuloCliente
        End Get
        Set(value)
            articuloCliente = value
        End Set
    End Property

    Property pArticulo() String
        Get
            Return articulo
        End Get
        Set(value)
            articulo = value
        End Set
    End Property

    Property pLogoBottonRight() As Image
        Get
            Return logoBottonRight
        End Get
        Set(value As Image)
            logoBottonRight = value
        End Set
    End Property

    Property pLogoBottonLeft() As Image
        Get
            Return logoBottonLeft
        End Get
        Set(value As Image)
            logoBottonLeft = value
        End Set
    End Property

    Property pWeb() As String
        Get
            Return web
        End Get
        Set(value As String)
            web = value
        End Set
    End Property

    Property pCampoWeb() As Boolean
        Get
            Return campoWeb
        End Get
        Set(value As Boolean)
            campoWeb = value
        End Set
    End Property

    Property pOutputText() As String
        Get
            Return outputText
        End Get
        Set(value As String)
            outputText = value
        End Set
    End Property

    Property pInputText() As String
        Get
            Return inputText
        End Get
        Set(value As String)
            inputText = value
        End Set
    End Property

    Property pLogoCliente() As Image
        Get
            Return logoCliente
        End Get
        Set(value As Image)
            logoCliente = value
        End Set
    End Property

    Property pIdArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property

    Property pIdCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(value As Integer)
            idCliente = value
        End Set
    End Property

    Property pIdEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(value As Integer)
            idEtiqueta = value
        End Set
    End Property

    Property pEti0 As String
        Get
            Return eti0
        End Get
        Set(value As String)
            eti0 = value
        End Set
    End Property
    Property pEti1 As String
        Get
            Return eti1
        End Get
        Set(value As String)
            eti1 = value
        End Set
    End Property
    Property pEti2 As String
        Get
            Return eti2
        End Get
        Set(value As String)
            eti2 = value
        End Set
    End Property

    Property pEti3 As String
        Get
            Return eti3
        End Get
        Set(value As String)
            eti3 = value
        End Set
    End Property
    Property pEti4 As String
        Get
            Return eti4
        End Get
        Set(value As String)
            eti4 = value
        End Set
    End Property

    Property pEti5 As String
        Get
            Return eti5
        End Get
        Set(value As String)
            eti5 = value
        End Set
    End Property

    Property pEti6 As String
        Get
            Return eti6
        End Get
        Set(value As String)
            eti6 = value
        End Set
    End Property

    Property pVal0 As String
        Get
            Return val0
        End Get
        Set(value As String)
            val0 = value
        End Set
    End Property
    Property pVal1 As String
        Get
            Return val1
        End Get
        Set(value As String)
            val1 = value
        End Set
    End Property
    Property pVal2 As String
        Get
            Return val2
        End Get
        Set(value As String)
            val2 = value
        End Set
    End Property
    Property pVal3 As String
        Get
            Return val3
        End Get
        Set(value As String)
            val3 = value
        End Set
    End Property

    Property pVal4 As String
        Get
            Return val4
        End Get
        Set(value As String)
            val4 = value
        End Set
    End Property

    Property pVal5 As String
        Get
            Return val5
        End Get
        Set(value As String)
            val5 = value
        End Set
    End Property

    Property pId0 As Integer
        Get
            Return id0
        End Get
        Set(value As Integer)
            id0 = value
        End Set
    End Property

    Property pId1 As Integer
        Get
            Return id1
        End Get
        Set(value As Integer)
            id1 = value
        End Set
    End Property

    Property pId2 As Integer
        Get
            Return id2
        End Get
        Set(value As Integer)
            id2 = value
        End Set
    End Property
    Property pId3 As Integer
        Get
            Return id3
        End Get
        Set(value As Integer)
            id3 = value
        End Set
    End Property

    Property pId4 As Integer
        Get
            Return id4
        End Get
        Set(value As Integer)
            id4 = value
        End Set
    End Property

    Property pId5 As Integer
        Get
            Return id5
        End Get
        Set(value As Integer)
            id5 = value
        End Set
    End Property

    Public Property pLogoCE As Boolean
        Get
            Return logoCE
        End Get
        Set(value As Boolean)
            logoCE = value
        End Set
    End Property

    Public Property pLogoCMIN As Boolean
        Get
            Return logoCMIN
        End Get
        Set(value As Boolean)
            logoCMIN = value
        End Set
    End Property

    Public Property pLogoEAC As Boolean
        Get
            Return logoEAC
        End Get
        Set(value As Boolean)
            logoEAC = value
        End Set
    End Property

    Public Property pLogoUKCA As Boolean
        Get
            Return logoUKCA
        End Get
        Set(value As Boolean)
            logoUKCA = value
        End Set
    End Property

    Public Property pLogoLPX3 As Boolean
        Get
            Return logoLPX3
        End Get
        Set(value As Boolean)
            logoLPX3 = value
        End Set
    End Property

    Public Property pLogoUL As Boolean
        Get
            Return logoUL
        End Get
        Set(value As Boolean)
            logoUL = value
        End Set
    End Property

    Public Property pLogoWEEEE As Boolean
        Get
            Return logoWEEEE
        End Get
        Set(value As Boolean)
            logoWEEEE = value
        End Set
    End Property

    Public Property pMadeInSpain As Boolean
        Get
            Return madeInSpain
        End Get
        Set(value As Boolean)
            madeInSpain = value
        End Set
    End Property

    Public Property Monosku1 As String
        Get
            Return monosku
        End Get
        Set(value As String)
            monosku = value
        End Set
    End Property

#End Region

End Class
