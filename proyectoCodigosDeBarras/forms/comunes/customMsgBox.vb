Public Class customMsgBox

    Public numSerie As Integer

    Private Sub bVistaSimple_Click(sender As Object, e As EventArgs) Handles bVistaSimple.Click

        Dim gg As New imprimirEtiqueta

        gg.iNumserie = numSerie

        gg.ShowDialog()

        gg.Dispose()

        Close()

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    Private Sub customMsgBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class