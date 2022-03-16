Public Class imagenesRegistradas

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Public imagenSeleccionada As Image
    Dim imagenSubida As Boolean
    Public idImagen As Integer

#End Region

#Region "CARGA Y CIERRE"

    Private Sub imagenesRegistradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        funcCB.llenarImagenes(panelImagenes)

        txTotalImagenes.Text = FormatNumber(funcCB.pTotalImagenes, 0)

    End Sub

    Private Sub imagenesRegistradas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If imagenSubida = False Then

            idImagen = funcCB.pIdImage

        End If

    End Sub

    Private Sub bSubirImagen_Click(sender As Object, e As EventArgs) Handles bSubirImagen.Click


        ofSubirImagen.Filter = "Imagen (*.bmp,*.png)|*.bmp;*.png;"

            ofSubirImagen.FilterIndex = 1

            ofSubirImagen.RestoreDirectory = True

            If ofSubirImagen.ShowDialog = DialogResult.OK Then

                If ofSubirImagen.FileName <> Nothing Then

                    Dim fs As System.IO.FileStream
                    fs = New System.IO.FileStream(ofSubirImagen.FileName, System.IO.FileMode.Open)
                imagenSeleccionada = Image.FromStream(fs)

                If funcCB.guardarLogo(imagenSeleccionada) Then

                    funcCB.llenarImagenes(panelImagenes)

                End If

                fs.Close()

                End If

            End If

        If imagenSeleccionada Is Nothing Then

            imagenSubida = False

        Else

            imagenSubida = True

        End If

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    Private Sub bBorrarImagen_Click(sender As Object, e As EventArgs) Handles bBorrarImagen.Click

        For Each control In panelImagenes.Controls

            If control.backcolor = Color.Green Then

                If funcCB.borrarLogo(control.name) Then

                    funcCB.llenarImagenes(panelImagenes)

                    txTotalImagenes.Text = FormatNumber(funcCB.pTotalImagenes, 0)

                Else

                    MsgBox("No es posible borrar este logo de la base de datos.", MsgBoxStyle.Information)

                End If



            End If

        Next

    End Sub

    Private Sub bSustituirImagen_Click(sender As Object, e As EventArgs) Handles bSustituirImagen.Click

        Dim nameControl As String = ""

        For Each control In panelImagenes.Controls

            If control.backColor = Color.Green Then

                ofSubirImagen.Filter = "Imagen (*.bmp,*.png)|*.bmp;*.png;"

                ofSubirImagen.FilterIndex = 1

                ofSubirImagen.RestoreDirectory = True

                If ofSubirImagen.ShowDialog = DialogResult.OK Then

                    If ofSubirImagen.FileName <> Nothing Then

                        Dim fs As System.IO.FileStream
                        fs = New System.IO.FileStream(ofSubirImagen.FileName, System.IO.FileMode.Open)
                        imagenSeleccionada = Image.FromStream(fs)

                        If funcCB.ActualizarLogo(imagenSeleccionada, control.name) Then

                            nameControl = control.name

                            funcCB.llenarImagenes(panelImagenes)

                        End If

                        fs.Close()

                    End If

                End If

                imagenSubida = False

            End If

        Next

        For Each control In panelImagenes.Controls

            If nameControl = control.name Then

                control.backcolor = Color.Green

            End If

        Next

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        For Each control In panelImagenes.Controls

            If control.backColor = Color.Green Then

                control.backColor = Color.Black

                idImagen = 0

                imagenSubida = True

            End If

        Next

    End Sub

#End Region

End Class