Public Class datosCambioComision

    Private idHistoricoCambio As Integer
    Private idComercial As Integer
    Private idCliente As Integer
    Private Porcentaje As Double
    Private PorcentajeAnterior As Double
    Private Fecha As Date
    Private idPersona As Integer

    Private Comercial As String



    Public Property gidHistoricoCambio() As Integer
        Get
            Return idHistoricoCambio
        End Get
        Set(ByVal value As Integer)
            idHistoricoCambio = value
        End Set
    End Property

    Public Property gidComercial() As Integer
        Get
            Return idComercial
        End Get
        Set(ByVal value As Integer)
            idComercial = value
        End Set
    End Property

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gPorcentaje() As Double
        Get
            Return Porcentaje
        End Get
        Set(ByVal value As Double)
            Porcentaje = value
        End Set
    End Property

    Public Property gPorcentajeAnterior() As Double
        Get
            Return PorcentajeAnterior
        End Get
        Set(ByVal value As Double)
            PorcentajeAnterior = value
        End Set
    End Property


    Public Property gFecha() As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
        End Set
    End Property

    Public Property gComercial() As String
        Get
            Return Comercial
        End Get
        Set(ByVal value As String)
            Comercial = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(ByVal idCliente As Integer, ByVal idComercial As Integer, ByVal Porcentaje As Double, ByVal PorcentajeAnterior As Double, ByVal Fecha As Date, ByVal idPersona As Integer)
        gidCliente = idCliente
        gidComercial = idComercial
        gPorcentaje = Porcentaje
        gPorcentajeAnterior = PorcentajeAnterior
        gFecha = Fecha
        gidPersona = idPersona
    End Sub



End Class
