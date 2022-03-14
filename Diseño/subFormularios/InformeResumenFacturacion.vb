Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class InformeResumenFacturacion

    Private informe As Object
    Private funcFA As New FuncionesFacturas
    Private funcPE As New FuncionesPersonal
    Private Fichero As String

    Private Sub CRV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRV.Load
        For A = funcFA.buscaPrimerDia(0).Year To funcFA.buscaUltimoDia(0).Year
            cbAnyo.Items.Add(A)
        Next
        For A = 1 To 12
            cbMes.Items.Add(UCase(MonthName(A)))
        Next
        If Now.Month = 1 Then
            cbMes.Text = UCase(MonthName(12))
            cbAnyo.Text = Now.Year - 1
        Else
            cbMes.Text = UCase(MonthName(Now.Month - 1))
            cbAnyo.Text = Now.Year
        End If
        If cbAnyo.SelectedIndex <> -1 And cbMes.SelectedIndex <> -1 Then
            Call verInforme()
        End If

    End Sub


    Public Function verInforme() As Boolean

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString

        informe = New ListadoVencimientosResumido
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        informe.SetParameterValue("mesInforme", cbMes.SelectedIndex + 1)
        informe.SetParameterValue("AnyoInforme", cbAnyo.Text)
        CRV.ReportSource = informe

        Return True

    End Function


    Public Function GeneraPDF() As Boolean

        Try
            Dim settings As ConnectionStringSettings
            settings = ConfigurationManager.ConnectionStrings(1)
            Dim csb As New SqlConnectionStringBuilder
            csb.ConnectionString = settings.ConnectionString
            informe = New ListadoVencimientosResumido
            informe.SetDatabaseLogon(csb.UserID, csb.Password)
            informe.SetParameterValue("mesInforme", cbMes.SelectedIndex + 1)
            informe.SetParameterValue("AnyoInforme", cbAnyo.Text)
            CRV.ReportSource = informe

            informe.ExportToDisk(ExportFormatType.PortableDocFormat, Fichero)


            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Private Sub Copias_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.selectall()
    End Sub


    Private Sub Copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then

            informe.PrintToPrinter(1, False, 1, 999)
        End If

    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub cbAnyo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyo.SelectionChangeCommitted, cbMes.SelectionChangeCommitted
        Call verInforme()
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        Fichero = "ResumenFacturacion " & cbMes.Text & " " & cbAnyo.Text & ".pdf"
        Dim sfd As New SaveFileDialog
        sfd.FileName = Fichero
        sfd.ShowDialog()
        Fichero = sfd.FileName
        Call GeneraPDF()

        If My.Computer.FileSystem.FileExists(sfd.FileName) Then
            Process.Start(sfd.FileName)
        End If


    End Sub

    Private Sub bMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMail.Click
        Fichero = "ResumenFacturacion " & cbMes.Text & " " & cbAnyo.Text & ".pdf"
        Dim camino As String = Path.GetTempPath()
        Fichero = camino & Fichero
        GeneraPDF()
        Dim Destinatario As String = ""
        
        Dim texto As String = " Buenos días,"
        texto = texto & "<br/><br/> Adjuntamos el informe resumen de facturación correspondiente al mes de " & cbMes.Text & " de " & cbAnyo.Text & ". "
        'Se envía un correo outlook a la dirección de la ubicación
        CorreoOutlook("Informe facturación SUGAR VALLEY", texto, funcPE.campoCorreo(Inicio.vIdUsuario), Destinatario, Fichero)
    End Sub


End Class