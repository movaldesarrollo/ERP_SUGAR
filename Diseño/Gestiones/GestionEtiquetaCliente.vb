Imports System.Data.SqlClient
Imports System.IO

Public Class GestionEtiquetaCliente

#Region "VARIABLES"
    Public idCliente As Integer = 0
    Public idEtiquetaFinal As Integer = 0
    Private funGEC As New FuncionesEtiquetaCliente
    Private idEtiquetaCliente As Integer = 0
    Dim img As Image
#End Region

#Region "EVENTOS"

    Private Sub GestionEtiquetaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbCliente.Text = funGEC.GetTradename(idCliente)
        Dim dataEtiqCliente As DatosEtiquetaCliente = funGEC.GetCustomerTag(idCliente, idEtiquetaFinal)
        If dataEtiqCliente IsNot Nothing Then
            LoadDataCustomerTag(dataEtiqCliente)
        End If
    End Sub

    Private Sub btnLoadImg_Click(sender As Object, e As EventArgs) Handles btnLoadImg.Click
        Dim fileName As String = ""

        OpenFileDialog1.Filter = "imagenes (*.jpg,*.png)|*.jpg;*.png"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            fileName = OpenFileDialog1.FileName
            tbPath.Text = fileName
            img = Image.FromFile(fileName)
            pbImagenCliente.Image = Image.FromFile(fileName)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If idEtiquetaCliente = 0 Then
            SaveCustomerTag()
        Else
            UpdateCustomerTag()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        DeleteCustomerTag()
    End Sub

#End Region

#Region "FUNCIONES"

    Private Sub LoadDataCustomerTag(data As DatosEtiquetaCliente)
        With data
            Dim ms As New MemoryStream(.Imagen1)
            idEtiquetaCliente = .IdEtiqueta1
            idCliente = .IdCliente1
            idEtiquetaFinal = .IdEtiquetaFinal1
            pbImagenCliente.Image = Image.FromStream(ms)
        End With
        btnGuardar.Text = "MODIFICAR"
    End Sub

    Private Sub SaveCustomerTag()
        Dim dec As New DatosEtiquetaCliente
        If pbImagenCliente.Image IsNot Nothing Then
            Dim imgClient As Byte() = ConvertImgToByte()
            With dec
                .IdCliente1 = idCliente
                .IdEtiquetaFinal1 = idEtiquetaFinal
                .Imagen1 = imgClient
                .Width1 = img.Width
                .Height1 = img.Height
            End With
            idEtiquetaCliente = funGEC.InsertCustomerTag(dec)
            If idEtiquetaCliente > 0 Then
                MsgBox("Se ha registrado la etiqueta correctamente.")
                tbPath.Text = ""
                btnGuardar.Text = "MODIFICAR"
            End If
        End If
    End Sub

    Private Sub UpdateCustomerTag()
        Dim imgClient As Byte() = ConvertImgToByte()
        Dim updated As Boolean = funGEC.UpdateCustomerTag(imgClient, idEtiquetaCliente, img.Width, img.Height)
        If updated Then
            MsgBox("Se ha modificado la etiqueta correctamente.")
        End If
    End Sub

    Private Sub DeleteCustomerTag()
        Dim deleted As Boolean = funGEC.DeleteCustomerTag(idEtiquetaCliente)
        If deleted Then
            MsgBox("Se ha borrado la etiqueta correctamente.")
            btnGuardar.Text = "GUARDAR"
            pbImagenCliente.Image = Nothing
            idEtiquetaCliente = 0
        End If
    End Sub

    Private Function ConvertImgToByte() As Byte()
        Dim ms As New MemoryStream()
        pbImagenCliente.Image.Save(ms, pbImagenCliente.Image.RawFormat)
        Return ms.GetBuffer()
    End Function
#End Region

End Class