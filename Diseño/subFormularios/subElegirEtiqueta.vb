Public Class subElegirEtiqueta

    Dim ep1 As New ErrorProvider

    Public Property pidEtiqueta() As Integer
        Get
            If cbEtiquetas.SelectedIndex = -1 Then
                Return 0
            Else
                Return cbEtiquetas.SelectedItem.gidEtiqueta
            End If
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property


    Private Sub subElegirEtiqueta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        Call CargarEtiquetas()
    End Sub

    Private Sub CargarEtiquetas()
        cbEtiquetas.Items.Clear()
        Dim funcET As New FuncionesEtiquetas
        Dim lista As List(Of DatosEtiqueta) = funcET.MostrarEditadas(False)
        For Each dts As DatosEtiqueta In lista

            cbEtiquetas.Items.Add(dts)

        Next

    End Sub


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If cbEtiquetas.SelectedIndex = -1 Then
            ep1.SetError(cbEtiquetas, "Se ha de seleccionar una etiqueta")
        Else
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub cbEtiquetas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEtiquetas.SelectedIndexChanged
        ep1.Clear()

    End Sub
End Class