Public Class DatosImportesIVA

    Private idConcepto As Long = 0
    Private REPoSOP As String
    Private idFactura As Integer = 0
    Private idTipoIVA As Integer
    Private Tipo As Double
    Private Base As Double
    Private Cuota As Double
    Private IVAoRE As string
    'Datos otras tablas
    Private numFactura As String
    Private NombreIVA As String
    Private codMoneda As String
    Private Simbolo As String


    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property


    Public Property gREPoSOP() As String
        Get
            Return REPoSOP
        End Get
        Set(ByVal value As String)
            REPoSOP = value
        End Set
    End Property

    Public Property gidFactura() As Integer
        Get
            Return idFactura
        End Get
        Set(ByVal value As Integer)
            idFactura = value
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

    Public Property gTipo() As Double
        Get
            Return Tipo
        End Get
        Set(ByVal value As Double)
            Tipo = value
        End Set
    End Property


    Public Property gBase() As Double
        Get
            Return Base
        End Get
        Set(ByVal value As Double)
            Base = value
        End Set
    End Property

    Public Property gCuota() As Double
        Get
            Return Cuota
        End Get
        Set(ByVal value As Double)
            Cuota = value
        End Set
    End Property

    Public Property gIVAoRE() As String
        Get
            Return IVAoRE
        End Get
        Set(ByVal value As String)
            IVAoRE = value
        End Set
    End Property


    'Datos otras tablas

    Public Property gnumFactura() As String
        Get
            Return numFactura
        End Get
        Set(ByVal value As String)
            numFactura = value
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

    Public Property gcodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
        End Set
    End Property

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
        End Set
    End Property


    Public Sub New()

    End Sub

  
End Class