Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.ComponentModel

Public Class GestionEtiquetaLogisticaCliente

#Region "VARIABLES"
    Public idCliente As Integer = 0
    Public idEtiquetaFinal As Integer = 0
    Public codArticulo As String = ""
    Public idArticulo As Integer = 0
    Private funGEC As New FuncionesEtiquetaCliente
    Private idEtiquetaCliente As Integer = 0
    Dim img As Image = Nothing
    Dim rutaPDF As String = ""
    Dim pdfModificado As Boolean = False
#End Region

#Region "EVENTOS"

    Private Sub GestionEtiquetaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbCliente.Text = funGEC.GetTradename(idCliente)
        preLoadEtiqCliente()
        pbImagenCliente.ContextMenuStrip = Me.menuStripLogo
    End Sub

    Friend Sub preLoadEtiqCliente()
        Dim dataEtiqCliente As DatosEtiquetaLogisticaCliente = funGEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
        If dataEtiqCliente IsNot Nothing Then
            LoadDataCustomerTag(dataEtiqCliente)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        preLoadEtiqCliente()
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

    Private Function pdfEquals() As Boolean
        Dim result As Boolean = False
        If pdfModificado = False Then
            Return True
        End If
        If tbPathPDF.Text.Trim.Equals("") Then
            result = True
            Return result
        Else

            Dim ruta As String = My.Application.Info.DirectoryPath() & "\PDFS_LOGOS_CLIENTES" & "\" & idCliente & "\" & "PDF_" & idCliente & "_LOGO.pdf"
            If File.Exists(ruta) Then
                result = FileCompare(tbPathPDF.Text, ruta)
            End If
        End If
        If result = True Then
            MsgBox("El PDF que quieres substituir es el que se está utilizando actualmente.", MsgBoxStyle.Information)
        End If
        Return result
    End Function

    Private Function FileCompare(file1 As String, file2 As String) As Boolean
        Dim fs1 As FileStream
        Dim fs2 As FileStream

        Try
            Dim file1byte As Integer
            Dim file2byte As Integer

            ' Determine if the same file was referenced two times.
            If (file1 = file2) Then
                'Return true to indicate that the files are the same.
                Return True
            End If

            ' Open the two files.
            fs1 = New FileStream(file1, FileMode.Open)
            fs2 = New FileStream(file2, FileMode.Open)

            ' Check the file sizes. If they are Not the same, the files
            ' are Not the same.
            If (fs1.Length <> fs2.Length) Then
                ' Close the file
                fs1.Close()
                fs2.Close()
                ' Return false to indicate files are different
                Return False
            End If

            ' Read And compare a byte from each file until either a
            ' non-matching set of bytes Is found Or until the end of
            ' file1 Is reached.
            Do

                ' Read one byte from each file.
                file1byte = fs1.ReadByte()
                file2byte = fs2.ReadByte()

            Loop Until ((file1byte = file2byte) And (file1byte <> -1))

            ' Close the files.
            fs1.Close()
            fs2.Close()

            ' Return the success of the comparison. "file1byte" Is
            ' equal to "file2byte" at this point only if the files are
            ' the same.
            Return ((file1byte - file2byte) = 0)
        Catch ex As Exception
            fs1.Close()
            fs2.Close()
        End Try

    End Function

    Private Sub LoadDataCustomerTag(data As DatosEtiquetaLogisticaCliente)
        With data

            idEtiquetaCliente = .IdEtiqueta1
            idCliente = .IdCliente1
            idEtiquetaFinal = .IdEtiquetaFinal1
            codArticulo = .CodArticulo1
            tbPathPDF.Text = .gPathPDF
            Try
                lectorPDF.src = .gPathPDF
                If Not .gPathPDF.Equals("") Then
                    lectorPDF.Visible = True
                End If
                pbImagenCliente.Visible = True
                If .Imagen1 IsNot Nothing Then
                    Dim ms As New MemoryStream(.Imagen1)
                    pbImagenCliente.Image = Image.FromStream(ms)
                End If
            Catch ex As ArgumentException
                MsgBox("LoadDataCustomerTag" & ex.ToString, MsgBoxStyle.Critical)
            End Try
        End With
        btnGuardar.Text = "MODIFICAR"
    End Sub

    Private Sub SaveCustomerTag()

        Dim dec As New DatosEtiquetaLogisticaCliente
        If pbImagenCliente.Image IsNot Nothing Then
            Dim imgClient As Byte() = ConvertImgToByte()
            With dec
                .Imagen1 = imgClient
                .Width1 = img.Width
                .Height1 = img.Height
                .gPathPDF = ""

            End With
        End If
        If Not tbPathPDF.Text.Trim.Equals("") Then
            Dim pathPDFCloned As String = existsPDF()
            If pathPDFCloned <> "" Then
                dec.gPathPDF = pathPDFCloned
            End If
        End If
        dec.gIdArticulo = idArticulo
        dec.CodArticulo1 = codArticulo
        dec.IdCliente1 = idCliente
        dec.IdEtiquetaFinal1 = idEtiquetaFinal
        idEtiquetaCliente = funGEC.InsertCustomerTag(dec)
        If idEtiquetaCliente > 0 Then
            MsgBox("Se ha registrado la etiqueta correctamente.", MsgBoxStyle.Information)
            'tbPath.Text = ""
            btnGuardar.Text = "MODIFICAR"
        End If
    End Sub

    Private Function existsPDF() As String

        Dim pathPDF As String = ""
        If tbPathPDF.Text.Trim <> "" Then
            pathPDF = clonePDF()
            If pathPDF <> "" Then
                MsgBox("PDF clonado correctamente.", MsgBoxStyle.Information)
            Else
                MsgBox("No se ha podido clonar el PDF.", MsgBoxStyle.Critical)
            End If
        Else
            Return pathPDF
        End If
        Return pathPDF
    End Function

    Friend Function clonePDF() As String
        Dim result As String = ""
        Try
            Dim rutaDestino = My.Application.Info.DirectoryPath() & "\PDFS_LOGOS_CLIENTES"
            If Not Directory.Exists(rutaDestino) Then
                Directory.CreateDirectory(rutaDestino)
            End If

            If Not Directory.Exists(rutaDestino & "\" & idCliente & "\") Then
                Directory.CreateDirectory(rutaDestino & "\" & idCliente & "\")
            End If

            rutaDestino = rutaDestino & "\" & idCliente & "\" & "PDF_" & idCliente & "_LOGO.pdf"
            If Not tbPathPDF.Text.Equals(rutaDestino) Then
                If Not tbPathPDF.Text.Equals("") Then
                    File.Copy(tbPathPDF.Text, rutaDestino, True)
                End If
            End If
            rutaDestino = "\PDFS_LOGOS_CLIENTES" & "\" & idCliente & "\" & "PDF_" & idCliente & "_LOGO.pdf"
            result = rutaDestino
            'tbPathPDF.Text = rutaDestino
        Catch ex As Exception
            MsgBox("ERROR AL COPIAR EL PDF." & ex.ToString, MsgBoxStyle.Critical)
            result = ""
        End Try
        Return result
    End Function

    Private Sub UpdateCustomerTag()
        Dim updated As Boolean
        Dim widthImgCliente As Integer = 0
        Dim heightImgCliente As Integer = 0
        Dim dataEtiqCliente As New DatosEtiquetaLogisticaCliente
        Dim imgClient As Byte()
        If pbImagenCliente.Image IsNot Nothing Then
            imgClient = ConvertImgToByte()
            widthImgCliente = pbImagenCliente.Image.Width
            heightImgCliente = pbImagenCliente.Image.Height
        End If

        Try
            dataEtiqCliente = funGEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
            Dim rutaPDF As String = clonePDF()
            funGEC.updatePathPDF(rutaPDF, idEtiquetaCliente)
            updated = funGEC.UpdateCustomerTag(imgClient, idEtiquetaCliente, widthImgCliente, heightImgCliente, tbPathPDF.Text)
            If Not tbPathPDF.Text.Trim.Equals("") And pdfModificado Then
                clonePDF()
            End If
            'CleanPDFFromPath()
        Catch ex As Exception
            MsgBox("UpdateCustomerTag  " & ex.ToString, MsgBoxStyle.Critical)
        End Try
        If updated Then
            MsgBox("Se ha modificado la etiqueta correctamente.", MsgBoxStyle.Information)
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

    Private Sub GestionEtiquetaLogisticaCliente_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        preLoadEtiqCliente()
    End Sub

    Private Function ConvertImgToByte() As Byte()
        Dim ms As New MemoryStream()
        If pbImagenCliente.Visible = False Then
            Dim aBytFichero() As Byte = lF_FicheroToByteArray(rutaPDF)
            Return aBytFichero
        Else

            pbImagenCliente.Image.Save(ms, pbImagenCliente.Image.RawFormat)
        End If
        Return ms.GetBuffer()
    End Function

    Private Function lF_FicheroToByteArray(ByVal vsFichero As String) As Byte()
        ' abrir el archivo con un objeto stream
        Dim oFileStream As FileStream = New FileStream(vsFichero, FileMode.Open)
        ' crear un array byte que tenga el tamaño del archivo
        Dim aBytImagen() As Byte = New Byte(CInt(oFileStream.Length - 1)) {}
        ' leer con el stream el contenido del archivo y volcarlo al array
        oFileStream.Read(aBytImagen, 0, CInt(oFileStream.Length - 1))
        oFileStream.Close()
        Return aBytImagen
    End Function

    Private Sub btnLoadPDF_Click(sender As Object, e As EventArgs) Handles btnLoadPDF.Click
        seleccionarRutaPDF()
    End Sub

    Private Sub seleccionarRutaPDF()
        Dim fileName As String = ""
        OpenFileDialogPDF.Filter = "PDFs (*.pdf)|*.pdf"
        OpenFileDialogPDF.FileName = fileName
        If OpenFileDialogPDF.ShowDialog() = DialogResult.OK Then
            fileName = OpenFileDialogPDF.FileName
            tbPathPDF.Text = fileName
            lectorPDF.src = fileName
            pdfModificado = True
            lectorPDF.Visible = True
        End If
    End Sub

    Private Sub btnBorrarPDF_Click(sender As Object, e As EventArgs) Handles btnBorrarPDF.Click
        tbPathPDF.Clear()
        lectorPDF.Visible = False
    End Sub

    Private Sub AñadirLogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirLogoToolStripMenuItem.Click
        Dim fileName As String = ""
        OpenFileDialog1.Filter = "imágenes (*.jpg,*.png,)|*.jpg;*.png;"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            fileName = OpenFileDialog1.FileName
            pbImagenCliente.Visible = True
            img = Image.FromFile(fileName)
            pbImagenCliente.Image = Image.FromFile(fileName)
        End If
    End Sub

    Private Sub EliminarLogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarLogoToolStripMenuItem.Click
        If MsgBox("¿Está seguro que desea eliminar el logo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            pbImagenCliente.Image = Nothing
        End If
    End Sub
#End Region
End Class
''' <summary>
''' Borra el PDF que existe en la ruta de aplicación, este PDF es el que carga en el visor de la etiqueta final.
''' Se borra para que no se cargue nada más se abra otro num.serie
''' </summary>
'Private Sub CleanPDFFromPath()
'    If idEtiquetaCliente <> 0 Then
'        'If File.Exists(Application.StartupPath() & "\PDF1.pdf") Then
'        '    File.Delete(Application.StartupPath() & "\PDF1.pdf")
'        'End If
'        If File.Exists("C:\Test\PDF1.pdf") Then
'            File.Delete("C:\Test\PDF1.pdf")
'        End If
'    End If
'End Sub