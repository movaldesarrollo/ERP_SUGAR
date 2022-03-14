'Contiene los datos de tipo de escandallo.

Public Class DatosTipoEscandallo

    Private idTipoEscandallo As Integer 'Id tipo de escandallo.
    Private TipoEscandallo As String 'Tipo de escandallo.
    Private Descripcion As String 'Descripcion de tipo de escandallo.
    Private Composicion As Boolean 'Si tiene composición.


    Public Property gidTipoEscandallo() As Integer

        Get

            Return idTipoEscandallo

        End Get

        Set(ByVal value As Integer)

            idTipoEscandallo = value

        End Set

    End Property

    Public Property gTipoEscandallo() As String

        Get

            Return UCase(TipoEscandallo)

        End Get

        Set(ByVal value As String)

            TipoEscandallo = UCase(value)

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

    Public Property gComposicion() As Boolean

        Get

            Return Composicion

        End Get

        Set(ByVal value As Boolean)

            Composicion = value

        End Set

    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idTipoEscandallo As Integer, ByVal TipoEscandallo As String, ByVal Descripci0 As String, ByVal Composicion As Boolean)

        gidTipoEscandallo = idTipoEscandallo

        gTipoEscandallo = TipoEscandallo

        gDescripcion = Descripcion

        gComposicion = Composicion

    End Sub


End Class
