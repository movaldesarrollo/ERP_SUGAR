'Contiene el código de conexión.

Imports System.Data.SqlClient
Imports System.Configuration

Public Class conexion

    Public cnn As New SqlConnection

    Public Function conectado()

        Try

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            cnn = New SqlConnection(settings.ConnectionString)

            cnn.Open()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    Public Function desconectado()

        Try

            If cnn.State = ConnectionState.Open Then

                cnn.Close()

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    Public Function CadenaConexion() As String

        Dim csb As New SqlConnectionStringBuilder

        csb.IntegratedSecurity = True

        Dim settings As ConnectionStringSettings

        settings = ConfigurationManager.ConnectionStrings(1)

        Return settings.ConnectionString
        ' Return "Data Source=PCPROGRAMACION3\DESARROLLO;Initial Catalog=ERP_SUGAR;Persist Security Info=True;User ID=jeison;Password=jeison"

    End Function

End Class
