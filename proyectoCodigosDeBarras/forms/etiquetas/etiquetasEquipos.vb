Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class etiquetasEquipos

#Region "VARIABLE"

    Dim master As New Master 'acceso a funciones datos master
    Dim funcCB As New funcionesCodigosBarras ' acceso a funciones datos de codigos de barras.
    Dim ancho As Integer = 50 'Ancho imagen codigo de barras.
    Dim alto As Integer = 12 'Alto imagen codigo de barras.
    Dim numero As Integer = 0
    Dim impresoraPredeterminada As String

#End Region

#Region "CARGA Y CIERRE"

    'Cargamos el form.
    Private Sub etiquetasEquipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Cargamos las impresoras que estan instaladas en el equipo en el combobox.
        For Each printer In PrinterSettings.InstalledPrinters

            cbImpresoras.Items.Add(printer)

        Next

        'Seleccionamos la impresora predeterminada si la hubiera.
        impresoraPredeterminada = funcCB.impresorapredeterminada(1)

        For Each printer In cbImpresoras.Items

            If printer = impresoraPredeterminada Then

                cbImpresoras.Text = impresoraPredeterminada

            End If

        Next

        limpiar()

    End Sub

    Private Sub etiquetasEquipos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Panel2.Visible Then

            e.Cancel = True

        End If

    End Sub

#End Region

#Region "EVENTOS"

    'Salir del form
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Imprimir
    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click

        If cbImpresoras.SelectedIndex = -1 Then

            MsgBox("Debe seleccionar una impresora.", MsgBoxStyle.Information)

            cbImpresoras.Focus()

        End If

        If txCantidad.Text = "" Or txNumeroSerieInicial.Text = "" Or txCopias.Text = "" _
            Or cbImpresoras.SelectedIndex = -1 Then

        Else

            numero = txNumeroSerieInicial.Text

            For i As Integer = 1 To txCantidad.Text

                CrearImagenCodigo(numero)

                numero = numero + 1

            Next

            imprimir()

        End If

    End Sub

    'Limpia el form.
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Activar el check para volver a imprimir etiquetas
    Private Sub ckVolverImprimir_CheckedChanged(sender As Object, e As EventArgs) Handles ckVolverImprimir.CheckedChanged

        If sender.Checked = True Then

            txNumeroSerieInicial.ReadOnly = False

        Else

            limpiar()

        End If

    End Sub

    'Cuando cambia el texto recalcula las etiquetas.
    Private Sub txCantidad_TextChanged(sender As Object, e As EventArgs) Handles txCantidad.TextChanged, txnumeroSerieFinal.TextChanged, txNumeroSerieInicial.TextChanged

        calculoEtiquetas(sender.name)

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Crea el codigo en la base de datos.
    Public Sub CrearImagenCodigo(ByVal numeroSerie As Double)

        Dim texto As String = "ED" & numeroSerie

        Dim barcode As New Barcode128

        barcode.StartStopText = True

        barcode.BarHeight = alto

        barcode.Code = texto

        Dim imagen As Image = New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        For copia As Integer = 1 To txCopias.Text

            funcCB.guardarImagenesEquipos(imagen, texto)

        Next

    End Sub

    'Imprimir imagenes guardadas.
    Public Sub imprimir()

        Panel2.Visible = True

        Panel2.BringToFront()

        'Imprimimos las imagenes.
        If imprimirCodigos() Then

            If ckVolverImprimir.Checked = False Or numero > master.leerCodigo("EquNumSerie", Year(Now)) Then

                master.actualizarCampo("EquNumSerie", numero)

            End If

            limpiar()

            Panel2.Visible = False

            Panel2.SendToBack()

        Else

            MsgBox("Por favor, compruebe que tiene conexión con la impresora seleccionada y que esta tenga creado el formato 'codigoBarras' con las medidas 50mmx20mm.", MsgBoxStyle.Information)

            limpiar()

            Panel2.Visible = False

            Panel2.SendToBack()

        End If

        'Borramos las imagenes, si las hubiera.
        funcCB.borrarImagenesEquipos()


    End Sub

    'Imprime los códigos.
    Public Function imprimirCodigos() As Boolean

        Dim cr As New EtiquetaEquipoCB

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            Dim csb As New SqlConnectionStringBuilder

            csb.ConnectionString = settings.ConnectionString

            cr.SetDatabaseLogon(csb.UserID, csb.Password)

            cr.Refresh()

            Dim doctoprint As New System.Drawing.Printing.PrintDocument()

            doctoprint.PrinterSettings.PrinterName = cbImpresoras.Text

            Dim formatos As Integer

        For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "codigoBarras" Then
                formatos = 1
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                cr.PrintOptions.PaperSize = rawKind
                Exit For
            End If
        Next

        If formatos = 0 Then

                Return False

            Else

                cr.PrintOptions.PrinterName = cbImpresoras.Text

                cr.PrintToPrinter(1, False, 1, 0)

                Return True

            End If


    End Function

    'Limpia el form.
    Public Sub limpiar()

        txNumeroSerieInicial.ReadOnly = True

        txNumeroSerieInicial.Text = master.leerCodigo("EquNumSerie", Year(Now))

        txCopias.Text = 1

        txCantidad.Text = 1

        calculoEtiquetas("Limpiar")

        For Each control In Controls

            If TypeOf control Is CheckBox Then

                control.Checked = False

            End If

        Next

        txCantidad.Focus()

    End Sub

    'Calculo de etiquetas segun campo introducido.
    Public Sub calculoEtiquetas(ByVal sender As String)

        Dim cantidad As Integer = If(txCantidad.Text = "", 0, txCantidad.Text)

        Dim numeroSerieFinal As Integer = If(txnumeroSerieFinal.Text = "", 0, txnumeroSerieFinal.Text)

        Dim numeroSerieInicial As Integer = If(txNumeroSerieInicial.Text = "", 0, txNumeroSerieInicial.Text) - 1

        If sender = "txCantidad" Or sender = "Limpiar" Then

            txnumeroSerieFinal.Text = numeroSerieInicial + cantidad

        ElseIf sender = "txnumeroSerieFinal" Then

            If numeroSerieFinal > numeroSerieInicial Then

                txCantidad.Text = numeroSerieFinal - numeroSerieInicial

            End If

        ElseIf sender = "txNumeroSerieInicial" Then

            If numeroSerieInicial > master.leerCodigo("EquNumSerie", Year(Now)) And ckVolverImprimir.Checked = True Then

                MsgBox("No se pueden volver a imprimir etiquetas que todavía no se han impreso.")

                txNumeroSerieInicial.Text = master.leerCodigo("EquNumSerie", Year(Now))

            Else

                txnumeroSerieFinal.Text = numeroSerieInicial + cantidad

            End If

        End If

        If txCantidad.Text = "0" Then

            txCantidad.Text = ""

        End If

    End Sub

#End Region

End Class