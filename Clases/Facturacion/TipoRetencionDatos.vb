Public Class DatosTipoRetencion


    Private idTipoRetencion As Integer
    Private TipoRetencion As Double
    Private Nombre As String
    Private Descripcion As String
    Private Activo As Boolean





    Public Property gidTipoRetencion() As Integer
        Get
            Return idTipoRetencion
        End Get
        Set(ByVal value As Integer)
            idTipoRetencion = value
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

    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Sub New(ByVal idTipoRetencion As Integer, ByVal TipoRetencion As Double, ByVal Nombre As String, ByVal Descripcion As String, ByVal Activo As Boolean)

        gidTipoRetencion = idTipoRetencion
        gTipoRetencion = TipoRetencion
        gNombre = Nombre
        gDescripcion = Descripcion
        gActivo = Activo

    End Sub


    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Nombre & " " & TipoRetencion & "%"
    End Function

End Class
