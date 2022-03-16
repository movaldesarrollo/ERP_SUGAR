Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeEscandallo

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load

    End Sub
    Public Function verInforme(ByVal IDSEscandallo As String, ByVal Costes As Boolean, ByVal Paginado As Boolean, ByVal Tiempos As Boolean, ByVal Orden As String, ByVal interno As Boolean) As Boolean

        Dim informe As New Escandallos

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        If IDSEscandallo.Length > 0 Then
            IDSEscandallo = "(" & IDSEscandallo & ")"
        End If
        If interno = False Then
            'Pasamos los parámetros 
            informe.SetParameterValue("IDSescandallo", IDSEscandallo)
            informe.SetParameterValue("Costes", Costes)
            informe.SetParameterValue("Paginado", Paginado)
            informe.SetParameterValue("Tiempos", Tiempos)
            informe.SetParameterValue("Orden", Orden)
            informe.SetParameterValue("Interno", interno)
            ' informe.SetParameterValue("Total", Total)
            'Asignamos el informe al CRV
        Else
            'Pasamos los parámetros 
            informe.SetParameterValue("IDSescandallo", IDSEscandallo)
            informe.SetParameterValue("Costes", False)
            informe.SetParameterValue("Paginado", Paginado)
            informe.SetParameterValue("Tiempos", Tiempos)
            informe.SetParameterValue("Orden", Orden)
            informe.SetParameterValue("Interno", interno)
            ' informe.SetParameterValue("Total", Total)
            'Asignamos el informe al CRV
        End If
        

        CRVPedido.ReportSource = informe

        Return True

    End Function


    Public Function GeneraPDF(ByVal vnumPedido As Integer, ByVal Fichero As String, ByVal Camino As String) As Boolean

        Try

            'Dim informe As New PedidoProveedor
            ''Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
            'Dim settings As ConnectionStringSettings
            'settings = ConfigurationManager.ConnectionStrings(1)
            'Dim csb As New SqlConnectionStringBuilder
            'csb.ConnectionString = settings.ConnectionString
            'informe.SetDatabaseLogon(csb.UserID, csb.Password)

            ''Pasamos los parámetros 
            'informe.SetParameterValue("vNumPedido", vnumPedido)
            'informe.SetParameterValue("conLogo", True)
            'informe.ExportToDisk(ExportFormatType.PortableDocFormat, Camino & Fichero)




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

End Class