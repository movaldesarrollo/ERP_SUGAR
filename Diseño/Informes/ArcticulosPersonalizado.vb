Public Class ArcticulosPersonalizado
    Dim funcAR As New FuncionesArticulos

    Private Sub InformeArcticulosPersonalizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If funcAR.CargarDatos() = False Then
            MsgBox("FALLO EN LA ACTUALIZACION", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bInforme.Click
        Dim GG As New InformeArticulosPersonalizados
        GG.verInforme(txSal08_2014.Text, txSal08_2015.Text, txSal08_2016.Text, txSal16_2014.Text, txSal16_2015.Text, txSal16_2016.Text, txSal22_2014.Text, txSal22_2015.Text, txSal22_2016.Text, txSal33_2014.Text, txSal33_2015.Text, txSal33_2016.Text, txHD1_2014.Text, txHD1_2015.Text, txHD1_2016.Text, txHD2_2014.Text, txHD2_2015.Text, txHD2_2016.Text, txCel08_2014.Text, txCel08_2015.Text, txCel08_2016.Text, txCel16_2014.Text, txCel16_2015.Text, txCel16_2016.Text, txCel22_2014.Text, txCel22_2015.Text, txCel22_2016.Text, txCel33_2014.Text, txCel33_2015.Text, txCel33_2016.Text)
        GG.ShowDialog()
    End Sub
End Class