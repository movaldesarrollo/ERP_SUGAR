Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeArticulosPersonalizados
    Dim informe As Object

    Private Sub CRV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRV.Load
        Copias.Text = 1
    End Sub
    Public Function verInforme(ByVal sal82014 As String, ByVal sal82015 As String, ByVal sal82016 As String, ByVal sal162014 As String, ByVal sal162015 As String, ByVal sal162016 As String, ByVal sal222014 As String, ByVal sal222015 As String, ByVal sal222016 As String, ByVal sal332014 As String, ByVal sal332015 As String, ByVal sal332016 As String, ByVal hd12014 As String, ByVal hd12015 As String, ByVal hd12016 As String, ByVal hd22014 As String, ByVal hd22015 As String, ByVal hd22016 As String, ByVal cel82014 As String, ByVal cel82015 As String, ByVal cel82016 As String, ByVal cel162014 As String, ByVal cel162015 As String, ByVal cel162016 As String, ByVal cel222014 As String, ByVal cel222015 As String, ByVal cel222016 As String, ByVal cel332014 As String, ByVal cel332015 As String, ByVal cel332016 As String) As Boolean
        informe = New unidadesArticulosPer
        informe.SetParameterValue("sal82014", sal82014)
        informe.SetParameterValue("sal82015", sal82015)
        informe.SetParameterValue("sal82016", sal82016)
        informe.SetParameterValue("sal162014", sal162014)
        informe.SetParameterValue("sal162015", sal162015)
        informe.SetParameterValue("sal162016", sal162016)
        informe.SetParameterValue("sal222014", sal222014)
        informe.SetParameterValue("sal222015", sal222015)
        informe.SetParameterValue("sal222016", sal222016)
        informe.SetParameterValue("sal332014", sal332014)
        informe.SetParameterValue("sal332015", sal332015)
        informe.SetParameterValue("sal332016", sal332016)
        informe.SetParameterValue("hd12014", hd12014)
        informe.SetParameterValue("hd12015", hd12015)
        informe.SetParameterValue("hd12016", hd12016)
        informe.SetParameterValue("hd22014", hd22014)
        informe.SetParameterValue("hd22015", hd22015)
        informe.SetParameterValue("hd22016", hd22016)
        informe.SetParameterValue("cel82014", cel82014)
        informe.SetParameterValue("cel82015", cel82015)
        informe.SetParameterValue("cel82016", cel82016)
        informe.SetParameterValue("cel162014", cel162014)
        informe.SetParameterValue("cel162015", cel162015)
        informe.SetParameterValue("cel162016", cel162016)
        informe.SetParameterValue("cel222014", cel222014)
        informe.SetParameterValue("cel222015", cel222015)
        informe.SetParameterValue("cel222016", cel222016)
        informe.SetParameterValue("cel332014", cel332014)
        informe.SetParameterValue("cel332015", cel332015)
        informe.SetParameterValue("cel332016", cel332016)
        CRV.ReportSource = informe
        Return True
    End Function

    Private Sub Copias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Copias.Click
        sender.selectall()
    End Sub

    Private Sub Copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Copias.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then
            If Copias.Text = "" Or Copias.Text = "0" Then Copias.Text = 1
            informe.PrintToPrinter(Copias.Text, False, 1, 999)
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()

    End Sub
End Class