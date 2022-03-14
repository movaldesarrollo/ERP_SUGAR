Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeEstadisticaProduccion

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVPedido.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height > 1000 Then
            Me.Height = 950
        Else
            Me.Height = desktopSize.Height - 50
        End If
        Me.Location = New Point(Me.Location.X, 0)
    End Sub

    Public Function verInforme(ByVal sBusqueda As String, ByVal sOrden As String, ByVal Titulo As String) As Boolean

        Dim informe As New ListadoEstadisticaProduccion

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)


        'Pasamos los parámetros 
        informe.SetParameterValue("sBusqueda", If(sBusqueda = "", "", " WHERE " & sBusqueda))
        informe.SetParameterValue("sOrden", If(sOrden = "", " Order By Persona ASC ", " ORDER BY " & sOrden))
        informe.SetParameterValue("Titulo", Titulo)

        'Asignamos el informe al CRV

        CRVPedido.ReportSource = informe

        Return True

    End Function




End Class