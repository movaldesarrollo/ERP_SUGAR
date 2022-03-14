Public Class DatosTipoIVA


    Private idTipoIVA As Integer
    Private TipoIVA As Double
    Private Nombre As String
    Private Descripcion As String
    Private TipoRecargoEq As Double
    Private Activo As Boolean



    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
        End Set
    End Property

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property



    Public Property gNombre() As String
        Get
            Return UCase(Nombre)
        End Get
        Set(ByVal value As String)
            Nombre = UCase(value)
        End Set
    End Property


    Public Property gDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property gTipoRecargoEq() As Double
        Get
            Return TipoRecargoEq
        End Get
        Set(ByVal value As Double)
            TipoRecargoEq = value
        End Set
    End Property

    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Sub New(ByVal idTipoIVA As Integer, ByVal TipoIVA As Double, ByVal TipoRecargoEq As Double, ByVal Nombre As String, ByVal Descripcion As String, ByVal Activo As Boolean)

        gidTipoIVA = idTipoIVA
        gTipoIVA = TipoIVA
        gTipoRecargoEq = TipoRecargoEq
        gNombre = Nombre
        gDescripcion = Descripcion
        gActivo = Activo
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Nombre & " " & TipoIVA & "%"
    End Function


End Class
