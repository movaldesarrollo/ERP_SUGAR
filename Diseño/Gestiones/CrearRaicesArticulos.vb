Public Class CrearRaicesArticulos

#Region "VARIABLES"
    Private funcCF As New FuncionesConceptosFacturas
#End Region
    Private Sub bAñadir_clic(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAñadir.Click
        Call introducirraiz()
    End Sub
    Private Sub introducirraiz()
        If Trim(txRaiz.Text) <> "" Then
            If funcCF.comprobarExisteRaiz(txRaiz.Text) Then
                MsgBox("Esta raíz ya existe.", MsgBoxStyle.Information)
            Else
                If funcCF.crearRaiz(txRaiz.Text) Then
                    MsgBox("Raíz creada correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("No se ha podido crear la raíz debido a un error.", MsgBoxStyle.Critical)
                End If
                Me.Close()
            End If
        Else
            MsgBox("No ha introducido ningún valor en el campo de texto.", MsgBoxStyle.Information)
        End If
    End Sub
    
End Class