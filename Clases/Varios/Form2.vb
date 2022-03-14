Public Class Form2



    Private funcAR As New FuncionesArticulos

    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("ESCANDALLO")

        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
            ComboBox1.Items.Add(dts)
            ComboBox3.Items.Add(dts)
        Next

    End Sub


    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarArticulosC()
    End Sub


End Class