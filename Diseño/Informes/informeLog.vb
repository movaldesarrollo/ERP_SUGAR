Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class informeLog

    Private informe As Object

    Private Sub informeLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tamaño As Size = My.Computer.Screen.Bounds.Size

        Height = tamaño.Height - 50
        Top = 10

    End Sub

    Public Function verInforme(ByVal busqueda As String) As Boolean

        Try

            'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
            Dim settings As ConnectionStringSettings
            settings = ConfigurationManager.ConnectionStrings(1)
            Dim csb As New SqlConnectionStringBuilder
            csb.ConnectionString = settings.ConnectionString

            informe = New logReparaciones
            informe.SetDatabaseLogon(csb.UserID, csb.Password)
            informe.SetParameterValue("busqueda", busqueda)
            CRV.ReportSource = informe

            Return True

        Catch ex As Exception

            MsgBox("Error al mostrar el informe.", MsgBoxStyle.Critical)

            Return False

        End Try

    End Function

End Class