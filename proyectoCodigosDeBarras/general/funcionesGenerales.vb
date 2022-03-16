Public Class funcionesGenerales

    Public Function redimension(ByVal formulario As Form) As Boolean

        With formulario

            .Height = Screen.PrimaryScreen.Bounds.Height - 50

            .Top = 10

        End With

    End Function

End Class
