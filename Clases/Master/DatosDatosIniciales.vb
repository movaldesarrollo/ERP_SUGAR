Public Class DatosDatosIniciales
    Private ProntoPago As Double
    Private Descuento As Double
    Private idTipoIVA As Integer
    Private idTipoRetencion As Integer
    Private Portes As Char
    Private idIdioma As Byte
    Private idArticuloOpcionBase As Integer
    Private Descuento2 As Double
    Private idTipoValorado As Integer
    Private SMTPServdor As String
    Private SMTPPuerto As Integer
    Private SMTPUsuario As String
    Private SMTPPassword As String
    Private SMTPAutenticado As Boolean
    Private SMTPSSL As Boolean
    Private DiasAviso1 As Integer
    Private DiasAviso2 As Integer
    Private DiasAviso3 As Integer
    'Otras tablas
    Private TipoIVA As Double
    Private NombreIVA As String
    Private TipoRetencion As Double
    Private NombreRetencion As String
    Private NombrePortes As String
    Private Idioma As String
    Private ArticuloOpcionBase As String
    Private TipoValorado As String

    Public Property gProntoPago() As Double
        Get
            Return ProntoPago
        End Get
        Set(ByVal value As Double)
            ProntoPago = value
        End Set
    End Property


    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
        End Set
    End Property

    Public Property gidTipoRetencion() As Integer
        Get
            Return idTipoRetencion
        End Get
        Set(ByVal value As Integer)
            idTipoRetencion = value
        End Set
    End Property

    Public Property gPortes() As Char
        Get
            Return Portes
        End Get
        Set(ByVal value As Char)
            Portes = value
        End Set
    End Property

    Public Property gidIdioma() As Byte
        Get
            Return idIdioma
        End Get
        Set(ByVal value As Byte)
            idIdioma = value
        End Set
    End Property

    Public Property gidArticuloOpcionBase() As Integer
        Get
            Return idArticuloOpcionBase
        End Get
        Set(ByVal value As Integer)
            idArticuloOpcionBase = value
        End Set
    End Property

    Public Property gDescuento2() As Double
        Get
            Return Descuento2
        End Get
        Set(ByVal value As Double)
            Descuento2 = value
        End Set
    End Property

    Public Property gidTipoValorado() As Integer
        Get
            Return idTipoValorado
        End Get
        Set(ByVal value As Integer)
            idTipoValorado = value
        End Set
    End Property

    Public Property gSMTPServidor() As String
        Get
            Return SMTPServdor
        End Get
        Set(ByVal value As String)
            SMTPServdor = value
        End Set
    End Property

    Public Property gSMTPPuerto() As Integer
        Get
            Return SMTPPuerto
        End Get
        Set(ByVal value As Integer)
            SMTPPuerto = value
        End Set
    End Property

    Public Property gSMTPUsuario() As String
        Get
            Return SMTPUsuario
        End Get
        Set(ByVal value As String)
            SMTPUsuario = value
        End Set
    End Property

    Public Property gSMTPPassword() As String
        Get
            Return SMTPPassword
        End Get
        Set(ByVal value As String)
            SMTPPassword = value
        End Set
    End Property

    Public Property gSMTPAutenticado() As Boolean
        Get
            Return SMTPAutenticado
        End Get
        Set(ByVal value As Boolean)
            SMTPAutenticado = value
        End Set
    End Property

    Public Property gSMTPSSL() As Boolean
        Get
            Return SMTPSSL
        End Get
        Set(ByVal value As Boolean)
            SMTPSSL = value
        End Set
    End Property

    Public Property gDiasAviso1() As Integer
        Get
            Return DiasAviso1
        End Get
        Set(ByVal value As Integer)
            DiasAviso1 = value
        End Set
    End Property

    Public Property gDiasAviso2() As Integer
        Get
            Return DiasAviso2
        End Get
        Set(ByVal value As Integer)
            DiasAviso2 = value
        End Set
    End Property

    Public Property gDiasAviso3() As Integer
        Get
            Return DiasAviso3
        End Get
        Set(ByVal value As Integer)
            DiasAviso3 = value
        End Set
    End Property



    'Otras tablas

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property


    Public Property gNombreIVA() As String
        Get
            Return NombreIVA
        End Get
        Set(ByVal value As String)
            NombreIVA = value
        End Set
    End Property

    Public Property gTipoRetencion() As Double
        Get
            Return TipoRetencion
        End Get
        Set(ByVal value As Double)
            TipoRetencion = value
        End Set
    End Property


    Public Property gNombreRetencion() As String
        Get
            Return NombreRetencion
        End Get
        Set(ByVal value As String)
            NombreRetencion = value
        End Set
    End Property

    Public Property gNombrePortes() As String
        Get
            If Portes = "D" Then
                Return "DEBIDOS"
            Else
                Return "PAGADOS"
            End If
        End Get
        Set(ByVal value As String)
            NombrePortes = value
        End Set
    End Property

    Public Property gIdioma() As String
        Get
            Return Idioma
        End Get
        Set(ByVal value As String)
            Idioma = value
        End Set
    End Property

    Public Property gArticuloOpcionBase() As String
        Get
            Return ArticuloOpcionBase
        End Get
        Set(ByVal value As String)
            ArticuloOpcionBase = value
        End Set
    End Property


    Public Property gTipoValorado() As String
        Get
            Return TipoValorado
        End Get
        Set(ByVal value As String)
            TipoValorado = value
        End Set
    End Property

End Class
