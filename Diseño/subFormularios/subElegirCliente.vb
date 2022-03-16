Public Class subElegirCliente

    Dim ep1 As New ErrorProvider
    Private funcCL As New funcionesclientes

    Public Property pidCliente() As Integer
        Get
            If cbCliente.SelectedIndex = -1 Then
                Return 0
            Else
                Return cbCliente.SelectedItem.itemData
            End If
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property


    Private Sub subElegirEtiqueta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        Call introducirClientes()
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        cbCliente.Items.Add("GENÉRICO")
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If cbCliente.SelectedIndex = -1 Then
            ep1.SetError(cbCliente, "Se ha de seleccionar un cliente o 'GENÉRICO'")
        Else
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub cbEtiquetas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged
        ep1.Clear()

    End Sub
End Class