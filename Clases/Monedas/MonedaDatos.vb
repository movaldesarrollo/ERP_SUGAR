Public Class DatosMoneda
    Private codMoneda As String
    Private CAMBIO As Double
    Private DIVISA As String
    Private FechaCambio As Date
    Private Simbolo As String

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
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

    Public Property gCAMBIO() As Double
        Get
            Return CAMBIO
        End Get
        Set(ByVal value As Double)
            CAMBIO = value
        End Set
    End Property

    Public Property gDIVISA() As String
        Get
            Return UCase(DIVISA)
        End Get
        Set(ByVal value As String)
            DIVISA = UCase(value)
        End Set
    End Property

    Public Property gFechaCambio() As Date
        Get
            Return FechaCambio
        End Get
        Set(ByVal value As Date)
            FechaCambio = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return UCase(DIVISA)
    End Function


End Class
