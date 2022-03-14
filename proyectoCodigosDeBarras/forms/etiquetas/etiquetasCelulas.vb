Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class etiquetasCelulas

#Region "VARIABLE"

    Dim master As New Master 'acceso a funciones datos master
    Dim funcCB As New funcionesCodigosBarras ' acceso a funciones datos de codigos de barras.
    Dim ancho As Integer = 50 'Ancho imagen codigo de barras.
    Dim alto As Integer = 12 'Alto imagen codigo de barras.
    Dim numero As Integer = 0
    Dim impresoraPredeterminada As String
    Dim impresoraCablePredeterminada As String
    Public numeroSerie As String
    Public bImpreso As Boolean

#End Region

#Region "CARGA Y CIERRE"

    'Cargamos el form.
    Private Sub etiquetasCelulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Cargamos las impresoras que estan instaladas en el equipo en el combobox.
        For Each printer In PrinterSettings.InstalledPrinters

            cbImpresoras.Items.Add(printer)
            cbImpresorasCable.Items.Add(printer)

        Next

        Application.DoEvents()

        'Seleccionamos la impresora predeterminada si la hubiera.
        impresoraPredeterminada = funcCB.impresorapredeterminada(1)
        impresoraCablePredeterminada = funcCB.impresorapredeterminada(3)

        For Each printer In cbImpresoras.Items

            If printer = impresoraPredeterminada Then

                cbImpresoras.Text = impresoraPredeterminada

            End If

            If printer = impresoraCablePredeterminada Then

                cbImpresorasCable.Text = impresoraCablePredeterminada

            End If

        Next

        If ckVolverImprimir.Checked Then

            txNumeroSerieInicial.ReadOnly = False

            txNumeroSerieInicial.Text = master.leerCodigo("celNumSerie", Year(Now)) - 1

        Else

            limpiar()

            If imprimirAuto() Then

                Close()

            End If

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

        If imprimirAuto() Then

            Close()

        End If

    End Sub

    Public Function imprimirAuto()

        If cbImpresoras.SelectedIndex = -1 Or cbImpresorasCable.SelectedIndex = -1 Then

            MsgBox("Debe seleccionar una impresora.", MsgBoxStyle.Information)

            cbImpresoras.Focus()

            Return False

        End If

        If Not txCantidad.Text.Trim = "" Or Not txNumeroSerieInicial.Text.Trim = "" Or Not txCopias.Text.Trim = "" Then

            numero = txNumeroSerieInicial.Text

            For i As Integer = 1 To txCantidad.Text

                CrearImagenCodigo(numero)

                numeroSerie = numero

                numero = numero + 1

            Next

            If imprimir() Then

                bImpreso = True

                Return True

            End If

        End If

    End Function

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

        If ckVolverImprimir.Checked = False Then
            calculoEtiquetas(sender.name)
        End If

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Crea el codigo en la base de datos.
    Public Sub CrearImagenCodigo(ByVal numeroSerie As Double)

        funcCB.borrarImagenesCelulas()

        Dim texto As String = "CD" & numeroSerie

        Dim barcode As New Barcode128

        barcode.StartStopText = True

        barcode.BarHeight = alto

        barcode.Code = texto

        Dim imagen As Image = New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        For copia As Integer = 1 To txCopias.Text

            funcCB.guardarImagenesCelulas(imagen, texto)

        Next

    End Sub

    'Imprimir imagenes guardadas.
    Public Function imprimir() As Boolean

        'Imprimimos las imagenes.
        If imprimirCodigos() Then

            If ckVolverImprimir.Checked = False Then

                master.actualizarCampo("celNumSerie", numero)

            End If

            limpiar()

            If impresoraPredeterminada = "" Then

                funcCB.guardarImpresoraPredeterminada(1, cbImpresoras.Text)

            Else

                funcCB.actualizarImpresoraPredeterminada(1, cbImpresoras.Text)

            End If

            If impresoraCablePredeterminada = "" Then

                funcCB.guardarImpresoraPredeterminada(3, cbImpresorasCable.Text)

            Else

                funcCB.actualizarImpresoraPredeterminada(3, cbImpresorasCable.Text)

            End If

            imprimir = True

        Else

            MsgBox("Por favor, compruebe que tiene conexión con la impresora seleccionada y que esta tenga creado el formato 'codigoBarras' con las medidas 50mmx20mm.", MsgBoxStyle.Information)

            limpiar()

        End If

        funcCB.borrarImagenesCelulas()

    End Function

    'Imprime los códigos.
    Public Function imprimirCodigos() As Boolean

        If ckCelula.Checked = False Then
            Return True
        End If

        Try

            Dim cr As New EtiquetaCelulaCB

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
                cr.PrintOptions.PrinterName = cbImpresoras.Text

                cr.PrintToPrinter(1, False, 1, 0)

                Return True
                'Return False

            Else

                cr.PrintOptions.PrinterName = cbImpresoras.Text

                cr.PrintToPrinter(1, False, 1, 0)

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    'Limpia el form.
    Public Sub limpiar()

        txNumeroSerieInicial.ReadOnly = True

        txNumeroSerieInicial.Text = master.leerCodigo("celNumSerie", Year(Now))

        txCopias.Text = 1

        txCantidad.Text = 1

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

            If numeroSerieInicial > master.leerCodigo("celNumSerie", Year(Now)) And ckVolverImprimir.Checked = True Then

                MsgBox("No se pueden volver a imprimir etiquetas que todavía no se han impreso.")

                txNumeroSerieInicial.Text = master.leerCodigo("celNumSerie", Year(Now))

            Else

                txnumeroSerieFinal.Text = numeroSerieInicial + cantidad

            End If

        End If

        If txCantidad.Text = "0" Then

            txCantidad.Text = ""

        End If

    End Sub

    Private Sub txNumeroSerieInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNumeroSerieInicial.KeyPress

        If IsNumeric(e.KeyChar) Or e.KeyChar = vbBack Or Char.IsControl(e.KeyChar) Then

            e.Handled = False

        Else

            e.Handled = True

        End If

    End Sub

#End Region

End Class