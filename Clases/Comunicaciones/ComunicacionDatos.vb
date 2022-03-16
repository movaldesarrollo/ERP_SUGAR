Public Class datosComunicacion

    Private idComunicacion As Integer
    Private idComunicacionPadre As Integer = 0
    Private FechaHora As DateTime
    Private idCliente As Integer
    Private idProveedor As Integer
    Private idUbicacion As Integer
    Private idContacto As Integer
    Private idSolicitadoVia As Integer
    Private Asunto As String
    Private Comentario As String
    Private Destacado As Boolean
    Private idCreador As Integer
    Private idEstado As Integer
    Private idDestinatario As Integer

    Private Contacto As String
    Private Creador As String
    Private Cliente As String
    Private Proveedor As String
    Private Direccion As String
    Private SolicitadoVia As String
    Private Estado As String
    Private CuantosConceptos As Integer
    Private Destinatario As String
    Private Documento As String
    Private Referencia As String
    Private Ruta As String
    Private fichero As String





    Public Property gidComunicacion() As Integer
        Get
            Return idComunicacion
        End Get
        Set(ByVal value As Integer)
            idComunicacion = value
        End Set
    End Property

    Public Property gidComunicacionPadre() As Integer
        Get
            Return idComunicacionPadre
        End Get
        Set(ByVal value As Integer)
            idComunicacionPadre = value
        End Set
    End Property

    Public Property gFechaHora() As DateTime
        Get
            Return FechaHora
        End Get
        Set(ByVal value As DateTime)
            FechaHora = value
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

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gidUbicacion() As Integer
        Get
            Return idUbicacion
        End Get
        Set(ByVal value As Integer)
            idUbicacion = value
        End Set
    End Property

    Public Property gidContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            idContacto = value
        End Set
    End Property

    Public Property gidSolicitadoVia() As Integer
        Get
            Return idSolicitadoVia
        End Get
        Set(ByVal value As Integer)
            idSolicitadoVia = value
        End Set
    End Property

    Public Property gAsunto() As String
        Get
            Return UCase(Asunto)
        End Get
        Set(ByVal value As String)
            Asunto = UCase(value)
        End Set
    End Property


    Public Property gComentario() As String
        Get
            Return Comentario
        End Get
        Set(ByVal value As String)
            Comentario = value
        End Set
    End Property

    Public Property gDestacado() As Boolean
        Get
            Return Destacado
        End Get
        Set(ByVal value As Boolean)
            Destacado = value
        End Set
    End Property


    Public Property gContacto() As String
        Get
            Return Contacto
        End Get
        Set(ByVal value As String)
            Contacto = value
        End Set
    End Property

    Public Property gidCreador() As Integer
        Get
            Return idCreador

        End Get
        Set(ByVal value As Integer)
            idCreador = value
        End Set
    End Property


    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
        End Set
    End Property

    Public Property gidDestinatario() As Integer
        Get
            Return idDestinatario
        End Get
        Set(ByVal value As Integer)
            idDestinatario = value
        End Set
    End Property


    Public Property gCreador() As String
        Get
            Return Creador
        End Get
        Set(ByVal value As String)
            Creador = value
        End Set
    End Property

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
        End Set
    End Property

    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property

    Public Property gDireccion() As String
        Get
            Return Direccion
        End Get
        Set(ByVal value As String)
            Direccion = value
        End Set
    End Property

    Public Property gSolicitadoVia() As String
        Get
            Return SolicitadoVia
        End Get
        Set(ByVal value As String)
            SolicitadoVia = value
        End Set
    End Property

    Public Property gEstado() As String
        Get
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = UCase(value)
        End Set
    End Property

    Public Property gCuantosConceptos() As Integer
        Get
            Return CuantosConceptos
        End Get
        Set(ByVal value As Integer)
            CuantosConceptos = value
        End Set
    End Property

    Public Property gDestinatario() As String
        Get
            Return Destinatario
        End Get
        Set(ByVal value As String)
            Destinatario = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Asunto
    End Function

End Class
