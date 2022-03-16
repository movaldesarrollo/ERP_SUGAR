Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class etiquetasCelulasIndustriales

#Region "VARIABLE"

    Dim master As New Master 'acceso a funciones datos master
    Dim funcCB As New funcionesCodigosBarras ' acceso a funciones datos de codigos de barras.
    Dim ancho As Integer = 50 'Ancho imagen codigo de barras.
    Dim alto As Integer = 12 'Alto imagen codigo de barras.
    Public numero As String
    Dim impresoraPredeterminada As String

#End Region

#Region "CARGA Y CIERRE"

    'Cargamos el form.
    Private Sub etiquetasCelulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        If ckVolverImprimir.Checked Then

            txNumeroSerieInicial.ReadOnly = False

            txNumeroSerieInicial.Text = master.leerCodigo("celIndNumSerie", Year(Now)) - 1

        Else

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

    'Activar el check para volver a imprimir etiquetas
    Private Sub ckVolverImprimir_CheckedChanged(sender As Object, e As EventArgs) Handles ckVolverImprimir.CheckedChanged

        If sender.Checked = True Then

            txNumeroSerieInicial.ReadOnly = False

        Else

            limpiar()

        End If

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Function imprimirAuto()

        If cbImpresoras.SelectedIndex = -1 Then

            MsgBox("Debe seleccionar una impresora.", MsgBoxStyle.Information)

            cbImpresoras.Focus()

            Return False

        End If

        If Not txCantidad.Text.Trim = "" Or Not txNumeroSerieInicial.Text.Trim = "" Or txCopias.Text.Trim = "" _
            Or cbImpresoras.SelectedIndex <> -1 Then

            numero = txNumeroSerieInicial.Text

            For i As Integer = 1 To txCantidad.Text

                CrearImagenCodigo(numero)

                numero = numero + 1

            Next

            If imprimir() Then

                Return True

            End If

        End If

        Return False

    End Function

    'Crea el codigo en la base de datos.
    Public Sub CrearImagenCodigo(ByVal numeroSerie As Double)

        Dim texto As String = "CI" & numeroSerie

        Dim barcode As New Barcode128

        barcode.StartStopText = True

        barcode.BarHeight = alto

        barcode.Code = texto

        Dim imagen As Image = New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        For copia As Integer = 1 To txCopias.Text

            funcCB.guardarImagenesCelulasIndustriales(imagen, texto)

        Next

    End Sub

    'Imprimir imagenes guardadas.
    Public Function imprimir()

        'Imprimimos las imagenes.
        If imprimirCodigos() Then

            If ckVolverImprimir.Checked = False Then

                master.actualizarCampo("celIndNumSerie", numero)

            End If

            If impresoraPredeterminada = "" Then

                funcCB.guardarImpresoraPredeterminada(1, cbImpresoras.Text)

            Else

                funcCB.actualizarImpresoraPredeterminada(1, cbImpresoras.Text)

            End If

            imprimir = True

        Else

            MsgBox("Por favor, compruebe que tiene conexión con la impresora seleccionada y que esta tenga creado el formato 'codigoBarras' con las medidas 50mmx20mm.", MsgBoxStyle.Information)

        End If

        'Borramos las imagenes, si las hubiera.
        funcCB.borrarImagenesCelulasIndustriales()

    End Function

    'Imprime los códigos.
    Public Function imprimirCodigos() As Boolean

        Try

            Dim cr As New EtiquetaCelulaIndustrialCB

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            Dim csb As New SqlConnectionStringBuilder

            csb.ConnectionString = settings.ConnectionString

            cr.SetDatabaseLogon(csb.UserID, csb.Password)

            cr.Refresh()

            cr.PrintOptions.PrinterName = cbImpresoras.Text

            cr.PrintToPrinter(1, False, 1, 0)

            Return True

        Catch ex As Exception

        End Try

    End Function

    'Limpia el form.
    Public Sub limpiar()

        txNumeroSerieInicial.ReadOnly = True

        txNumeroSerieInicial.Text = master.leerCodigo("celIndNumSerie", Year(Now))

        txCopias.Text = 1

        txCantidad.Text = 1

    End Sub

#End Region

End Class