Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class etiquetasFusibles
    Private Sub etiquetasFusibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each printer In PrinterSettings.InstalledPrinters

            cbImpresoras.Items.Add(printer)

        Next

    End Sub

    Public Function imprimir() As Boolean

        Try
            Dim ds As New Etiqueta

            Dim fila As DataRow

            Dim cr As New Fusibles

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            Dim csb As New SqlConnectionStringBuilder

            csb.ConnectionString = settings.ConnectionString

            cr.SetDatabaseLogon(csb.UserID, csb.Password)

            cr.Refresh()

            fila = ds.Tables(0).NewRow()

            fila("Valor4") = txTextoEtiqueta.Text

            ds.Tables(0).Rows.Add(fila)

            cr.SetDataSource(ds)

            cr.Refresh()

            Dim doctoprint As New System.Drawing.Printing.PrintDocument()

            doctoprint.PrinterSettings.PrinterName = cbImpresoras.Text

            cr.PrintOptions.PrinterName = cbImpresoras.Text

            cr.PrintToPrinter(If(IsNumeric(txCopias.Text), txCopias.Text, 1), False, 1, 0)

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click
        txCopias.Text = 1
        txTextoEtiqueta.Text = ""
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        If Trim(txTextoEtiqueta.Text) = "" Then
            MsgBox("El campo de texto está vacio.", MsgBoxStyle.Information)
            txTextoEtiqueta.Focus()
        Else
            imprimir()
        End If
    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        Me.Close()

    End Sub
End Class