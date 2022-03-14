Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Math
Imports MessagingToolkit.QRCode.Codec
Public Class imprimirEtiqueta

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras 'Funciones de codigo de barras.
    Public iNumserie As Integer = 0 'numero de serie del equipo.
    Public idEtiqueta As Integer = 0 'Id de la etiqueta.
    Public idCliente As Integer  'Id del cliente.
    Public idArticulo As Integer  'Id del articulo.
    Public referencia As String ' referencia del equipo
    Dim impresoraPredeterminada As String  'Impresora
    Dim dtsIO As New datosEtiquetasInputOutput 'Dts de inputs iniciales
    Public inicioPreparacion As Boolean
    Public imgLogoCliente As Image
    Public imgLogoIzquierda As Image
    Public imgLogoDerecha As Image
    Public informe As New Object
    Public fila As DataRow
    Public filaQR As DataRow
    Public colorBoton As Color = SystemColors.Control
    Public BbarcodeReferencia As Boolean
    Public qrConverter As New ImageConverter()
    Public QR_generator As New QRCodeEncoder
    Public image As Image
    Public madeInSpain As Boolean
    Dim monosku As String
    Dim showCE, showCMIN, showEAC, showUKCA, showLPX3, showUL, showWEEE, showMadeInSpain As Boolean

#End Region

#Region "CARGA Y CIERRE"

    Private Sub imprimirEtiqueta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If BbarcodeReferencia Then

            informe = New EtiquetaEquipoAU ' viene de las 4 lineas

        Else

            informe = New EtiquetaEquipoAU1 ' final de linea

        End If

        'Para el timer de pantalla general.
        PantallaGeneral.myTimer.Stop()

        'Cambia el texto a imprimir etiqueta.
        Text = "IMPRIMIR ETIQUETA"

        'Llena los combos para los valores de etiquetas.
        llenarCombos()

        'Cargamos las impresoras que estan instaladas en el equipo en el combobox.
        For Each printer In PrinterSettings.InstalledPrinters

            cbImpresoras.Items.Add(printer)

        Next

        'Seleccionamos la impresora predeterminada si la hubiera.
        impresoraPredeterminada = funcCB.impresorapredeterminada(2)

        For Each printer In cbImpresoras.Items

            If printer = impresoraPredeterminada Then

                cbImpresoras.Text = impresoraPredeterminada

            End If

        Next

        'Carga de la etiqueta.
        cargar()

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        LiberarMemoria()

        Close()

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Llena los combos
    Public Sub llenarCombos()

        Dim ds As New DataSet

        With ds.Tables.Add("TablaCombos0")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor0
            .DataSource = ds.Tables("TablaCombos0")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

        With ds.Tables.Add("TablaCombos1")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor1
            .DataSource = ds.Tables("TablaCombos1")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

        With ds.Tables.Add("TablaCombos2")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor2
            .DataSource = ds.Tables("TablaCombos2")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

        With ds.Tables.Add("TablaCombos3")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor3
            .DataSource = ds.Tables("TablaCombos3")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

        With ds.Tables.Add("TablaCombos4")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor4
            .DataSource = ds.Tables("TablaCombos4")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

        With ds.Tables.Add("TablaCombos5")
            .Columns.Add("Value")
            .Columns.Add("Display")
            .Rows.Add(1, "ARTICULO")
            .Rows.Add(2, "ARTICULO CLIENTE")
            .Rows.Add(3, "WEB")
            .Rows.Add(4, "FECHA")
            .Rows.Add(5, "INPUT")
            .Rows.Add(6, "OUTPUT")
        End With

        With cbValor5
            .DataSource = ds.Tables("TablaCombos5")
            .ValueMember = "Value"
            .DisplayMember = "Display"
            .SelectedIndex = -1
        End With

    End Sub

    'Cargar la última configuración de la base de datos.
    Public Function cargar() As Boolean

        Try

            Dim dts As New datosEtiquetasEquipos
            funcCB.ExisteEtiqueta(dts, iNumserie)
            monosku = funcCB.recuperarMonoSku(iNumserie)
            funcCB.ExisteEtiquetaOffline(dts, dts.pIdArticulo, dts.pIdCliente)

            If (dts.pLogoCE) Then
                showCE = True
                cbCE.Checked = True
            Else
                showCE = False
                cbCE.Checked = False
            End If
            If (dts.pLogoEAC) Then
                showEAC = True
                cbEAC.Checked = True
            Else
                showEAC = False
                cbEAC.Checked = False
            End If
            If (dts.pLogoUKCA) Then
                showUKCA = True
                cbUKCA.Checked = True
            Else
                showUKCA = False
                cbUKCA.Checked = False
            End If
            If (dts.pLogoLPX3) Then
                showLPX3 = True
                cbLPX3.Checked = True
            Else
                showLPX3 = False
                cbLPX3.Checked = False
            End If
            If (dts.pLogoUL) Then
                showUL = True
                cbUL.Checked = True
            Else
                showUL = False
                cbUL.Checked = False
            End If
            If (dts.pLogoWEEEE) Then
                showWEEE = True
                cbWEEEE.Checked = True
            Else
                showWEEE = False
                cbWEEEE.Checked = False
            End If
            If (dts.pLogoCMIN) Then
                showCMIN = True
                cbCMIN.Checked = True
            Else
                showCMIN = False
                cbCMIN.Checked = False
            End If
            If (dts.pMadeInSpain) Then
                showMadeInSpain = True
                cbMadeInSpain.Checked = True
            Else
                showMadeInSpain = False
                cbMadeInSpain.Checked = False
            End If
            If dts.pIdCliente = 0 Then

                Return False

            Else

                'Llena los datos del articulo segun el cliente.

                ' ckWeb.Checked = dts.pCampoWeb

                idCliente = dts.pIdCliente

                idArticulo = dts.pIdArticulo

                txArticuloCliente.Text = Trim(dts.pArticuloCliente)

                txArticulo.Text = Trim(dts.pArticulo)

                txCliente.Text = Trim(dts.pCliente)

                txInput.Text = Trim(Replace(dts.pInputText, vbTab, ""))

                txOutPut.Text = Trim(Replace(dts.pOutputText, vbTab, ""))

                ' txWeb.Text = Trim(Replace(dts.pWeb, vbTab, ""))

                imgLogoCliente = dts.pLogoCliente

                imgLogoIzquierda = Nothing

                imgLogoDerecha = Nothing

                If dts.pIdCamposEtiquetasPedidos Then

                    txEtiqueta0.Text = dts.pEti0
                    txEtiqueta1.Text = dts.pEti1
                    txEtiqueta2.Text = dts.pEti2
                    txEtiqueta3.Text = dts.pEti3
                    txEtiqueta4.Text = dts.pEti4
                    txEtiqueta5.Text = dts.pEti5
                    'txEtiqueta6.Text = dts.pEti6

                    If dts.pId0 = 0 Then
                        cbValor0.Text = dts.pVal0
                    Else
                        cbValor0.SelectedValue = dts.pId0
                    End If

                    If dts.pId1 = 0 Then
                        cbValor1.Text = dts.pVal1
                    Else
                        cbValor1.SelectedValue = dts.pId1
                    End If

                    If dts.pId2 = 0 Then
                        cbValor2.Text = dts.pVal2
                    Else
                        cbValor2.SelectedValue = dts.pId2
                    End If

                    If dts.pId3 = 0 Then
                        cbValor3.Text = dts.pVal3
                    Else
                        cbValor3.SelectedValue = dts.pId3
                    End If

                    If dts.pId4 = 0 Then
                        cbValor4.Text = dts.pVal4
                    Else
                        cbValor4.SelectedValue = dts.pId4
                    End If

                    If dts.pId5 = 0 Then
                        cbValor5.Text = dts.pVal5
                    Else
                        cbValor5.SelectedValue = dts.pId5
                    End If

                Else

                    txEtiqueta0.Text = "REF."
                    txEtiqueta1.Text = ""
                    txEtiqueta2.Text = "ARTÍCULO"
                    txEtiqueta3.Text = ""
                    txEtiqueta4.Text = "INPUT"
                    txEtiqueta5.Text = "OUTPUT"
                    'txEtiqueta6.Text = ""
                    cbValor0.Text = txArticuloCliente.Text
                    cbValor1.Text = ""
                    cbValor2.Text = txArticulo.Text
                    cbValor3.Text = ""
                    cbValor4.Text = txInput.Text
                    cbValor5.Text = txOutPut.Text

                End If

                'Datos inputs outputs

                dtsIO.pIdArticulo = dts.pIdArticulo

                dtsIO.pWeb = dts.pWeb

                dtsIO.pOutputText = dts.pOutputText

                dtsIO.pInputText = dts.pInputText

                cargarEtiquetaCR()

                bImprimir.Focus()

                Return True

            End If

        Catch ex As Exception

            MsgBox("Error (imprimirEtiqueta) E117 al cargar la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

            Return False

        End Try

    End Function

    Public Function textoIDCombo(ByVal id As Integer, ByVal combo As ComboBox) As String
        MsgBox(combo.SelectedValue(1).Text)

        Return ""

    End Function

    Public Function valorCombo(ByVal combo As ComboBox) As String

        Dim resultado As String = ""

        If combo.SelectedIndex > -1 Then

            Select Case combo.SelectedValue

                Case 1
                    resultado = txArticulo.Text

                Case 2
                    resultado = txArticuloCliente.Text

                Case 4
                    resultado = Format(Now, "dd/MM/yyyy")

                Case 5
                    resultado = txInput.Text

                Case 6
                    resultado = txOutPut.Text

            End Select

        Else

            resultado = combo.Text

        End If

        Return resultado

    End Function

    'Muestra los cambios en el preview
    Public Sub cargarEtiquetaCR()

        Try

            Dim ds As New Etiqueta

            fila = ds.Tables(0).NewRow()

            'Etiquetas

            fila("Etiqueta0") = txEtiqueta0.Text

            fila("Etiqueta1") = txEtiqueta1.Text

            fila("Etiqueta2") = txEtiqueta2.Text

            fila("Etiqueta3") = txEtiqueta3.Text

            fila("Etiqueta4") = txEtiqueta4.Text

            fila("Etiqueta5") = txEtiqueta5.Text

            fila("monoSKUtxt") = monosku

            'VALORES

            fila("Valor0") = valorCombo(cbValor0)

            fila("Valor1") = valorCombo(cbValor1)

            fila("Valor2") = valorCombo(cbValor2)

            fila("Valor3") = valorCombo(cbValor3)

            fila("Valor4") = valorCombo(cbValor4)

            fila("Valor5") = valorCombo(cbValor5)

            fila("Valor6") = "C" & iNumserie

            'LOGOS

            Dim maxAlto As Integer

            Dim maxAncho As Integer

            Dim resto As Double

            Dim x As Integer

            Dim y As Integer

            Dim diferenciaTop As Integer = 0

            Dim imageConverter As New ImageConverter()

            If Not imgLogoCliente Is Nothing Then

                fila("Logo1") = DirectCast(imageConverter.ConvertTo(imgLogoCliente, GetType(Byte())), Byte())

                'LogoCabecera-----------------------------------------------------------------------------

                x = imgLogoCliente.Width

                y = imgLogoCliente.Height

                maxAlto = 737

                maxAncho = 2635

                resto = 3.6

                If y < x And Round(x / y, 1) >= resto Then

                    y = (y * maxAncho) / x
                    x = maxAncho

                Else

                    x = (x * maxAlto) / y
                    y = maxAlto

                End If

                'Parametros del LogoCabecera

                Dim ClienteLogo1 As Integer = (3390 - x) / 2
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).width = x
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).height = y
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).left = ClienteLogo1

                '-------------------------------------------------------------------------------------------------------------------
            End If

            fila("numSerie") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(iNumserie), GetType(Byte())), Byte())
            'fila("monoSKUimg") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(monosku), GetType(Byte())), Byte()) ' cambiar por monosku
            fila("BarcodeReferencia") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigoReferencia(valorCombo(cbValor0)), GetType(Byte())), Byte())
            ds.Tables(0).Rows.Add(fila)

            If Not showCE Then
                informe.Section3.ReportObjects("imgCE").Width = 0
                informe.Section3.ReportObjects("imgCE").Height = 0
            Else
                informe.Section3.ReportObjects("imgCE").Width = 620
                informe.Section3.ReportObjects("imgCE").Height = 510
            End If
            If Not showEAC Then
                informe.Section3.ReportObjects("imgEAC").Width = 0
                informe.Section3.ReportObjects("imgEAC").Height = 0
            Else
                informe.Section3.ReportObjects("imgEAC").Width = 620
                informe.Section3.ReportObjects("imgEAC").Height = 510
            End If
            If Not showUKCA Then
                informe.Section3.ReportObjects("imgUKCA").Width = 0
                informe.Section3.ReportObjects("imgUKCA").Height = 0
            Else
                informe.Section3.ReportObjects("imgUKCA").Width = 620
                informe.Section3.ReportObjects("imgUKCA").Height = 510
            End If

            If Not showLPX3 Then
                informe.Section3.ReportObjects("imgIPX3").Width = 0
                informe.Section3.ReportObjects("imgIPX3").Height = 0
            Else
                informe.Section3.ReportObjects("imgIPX3").Width = 620
                informe.Section3.ReportObjects("imgIPX3").Height = 510
            End If

            If Not showWEEE Then
                informe.Section3.ReportObjects("imgWEEE").Width = 0
                informe.Section3.ReportObjects("imgWEEE").Height = 0
            Else
                informe.Section3.ReportObjects("imgWEEE").Width = 620
                informe.Section3.ReportObjects("imgWEEE").Height = 510
            End If

            If Not showUL Then
                informe.Section3.ReportObjects("imgUL").Width = 0
                informe.Section3.ReportObjects("imgUL").Height = 0
            Else
                informe.Section3.ReportObjects("imgUL").Width = 620
                informe.Section3.ReportObjects("imgUL").Height = 510
            End If

            If Not showCMIN Then
                informe.Section3.ReportObjects("imgCMIN").Width = 0
                informe.Section3.ReportObjects("imgCMIN").Height = 0
            Else
                informe.Section3.ReportObjects("imgCMIN").Width = 620
                informe.Section3.ReportObjects("imgCMIN").Height = 510
            End If

            If Not showMadeInSpain Then
                informe.Section3.ReportObjects("txtMadeInSpain").Width = 0
                informe.Section3.ReportObjects("txtMadeInSpain").Height = 0
            Else
                informe.Section3.ReportObjects("txtMadeInSpain").Width = 2720
                informe.Section3.ReportObjects("txtMadeInSpain").Height = 255

            End If
            informe.SetDataSource(ds)
            crPrv.ReportSource = informe
            informe.refresh()

        Catch ex As Exception

            MsgBox("Error (imprimirEtiqueta) E175 al cargar la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

        End Try

    End Sub

    'Imprime la etiqueta y guarda los cambios.
    Public Sub ImprimirEtiquetaCR()

        Try

            Dim ds As New Etiqueta

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            Dim csb As New SqlConnectionStringBuilder

            csb.ConnectionString = settings.ConnectionString

            informe.SetDatabaseLogon(csb.UserID, csb.Password)

            fila = ds.Tables(0).NewRow()

            'ETIQUETAS

            fila("Etiqueta0") = txEtiqueta0.Text

            fila("Etiqueta1") = txEtiqueta1.Text

            fila("Etiqueta2") = txEtiqueta2.Text

            fila("Etiqueta3") = txEtiqueta3.Text

            fila("Etiqueta4") = txEtiqueta4.Text

            fila("Etiqueta5") = txEtiqueta5.Text

            ' fila("Etiqueta6") = txEtiqueta6.Text

            'If ckWeb.Checked Then

            '    fila("Etiqueta7") = txWeb.Text

            'Else

            '    fila("Etiqueta7") = ""

            'End If

            'VALORES

            fila("Valor0") = valorCombo(cbValor0)

            fila("Valor1") = valorCombo(cbValor1)

            fila("Valor2") = valorCombo(cbValor2)

            fila("Valor3") = valorCombo(cbValor3)

            fila("Valor4") = valorCombo(cbValor4)

            fila("Valor5") = valorCombo(cbValor5)

            fila("Valor6") = "C" & iNumserie

            'LOGOS

            Dim maxAlto As Integer

            Dim maxAncho As Integer

            Dim resto As Double

            Dim x As Integer

            Dim y As Integer

            Dim diferenciaTop As Integer = 0

            Dim imageConverter As New ImageConverter()

            If Not imgLogoCliente Is Nothing Then

                fila("Logo1") = DirectCast(imageConverter.ConvertTo(imgLogoCliente, GetType(Byte())), Byte())

                'LogoCabecera-----------------------------------------------------------------------------

                x = imgLogoCliente.Width

                y = imgLogoCliente.Height

                maxAlto = 737

                maxAncho = 2635

                resto = 3.6

                If y < x And Round(x / y, 1) >= resto Then

                    y = (y * maxAncho) / x
                    x = maxAncho

                Else

                    x = (x * maxAlto) / y
                    y = maxAlto

                End If

                'Parametros del LogoCabecera

                Dim ClienteLogo1 As Integer = (3390 - x) / 2
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).width = x
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).height = y
                TryCast(informe.Section3.ReportObjects("Logo11"), Object).left = ClienteLogo1

                '-------------------------------------------------------------------------------------------------------------------

            End If

            fila("numSerie") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(iNumserie), GetType(Byte())), Byte())
            ' fila("monoSKUimg") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(monosku), GetType(Byte())), Byte()) ' cambiar por monosku
            fila("monoSKUtxt") = monosku
            fila("BarcodeReferencia") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigoReferencia(valorCombo(cbValor0)), GetType(Byte())), Byte())

            informe.SetDataSource(ds)
            If Not showCE Then
                informe.Section3.ReportObjects("imgCE").Width = 0
                informe.Section3.ReportObjects("imgCE").Height = 0
            Else
                informe.Section3.ReportObjects("imgCE").Width = 620
                informe.Section3.ReportObjects("imgCE").Height = 510
            End If
            If Not showEAC Then
                informe.Section3.ReportObjects("imgEAC").Width = 0
                informe.Section3.ReportObjects("imgEAC").Height = 0
            Else
                informe.Section3.ReportObjects("imgEAC").Width = 620
                informe.Section3.ReportObjects("imgEAC").Height = 510
            End If
            If Not showUKCA Then
                informe.Section3.ReportObjects("imgUKCA").Width = 0
                informe.Section3.ReportObjects("imgUKCA").Height = 0
            Else
                informe.Section3.ReportObjects("imgUKCA").Width = 620
                informe.Section3.ReportObjects("imgUKCA").Height = 510
            End If

            If Not showLPX3 Then
                informe.Section3.ReportObjects("imgIPX3").Width = 0
                informe.Section3.ReportObjects("imgIPX3").Height = 0
            Else
                informe.Section3.ReportObjects("imgIPX3").Width = 620
                informe.Section3.ReportObjects("imgIPX3").Height = 510
            End If

            If Not showWEEE Then
                informe.Section3.ReportObjects("imgWEEE").Width = 0
                informe.Section3.ReportObjects("imgWEEE").Height = 0
            Else
                informe.Section3.ReportObjects("imgWEEE").Width = 620
                informe.Section3.ReportObjects("imgWEEE").Height = 510
            End If

            If Not showUL Then
                informe.Section3.ReportObjects("imgUL").Width = 0
                informe.Section3.ReportObjects("imgUL").Height = 0
            Else
                informe.Section3.ReportObjects("imgUL").Width = 620
                informe.Section3.ReportObjects("imgUL").Height = 510
            End If

            If Not showCMIN Then
                informe.Section3.ReportObjects("imgCMIN").Width = 0
                informe.Section3.ReportObjects("imgCMIN").Height = 0
            Else
                informe.Section3.ReportObjects("imgCMIN").Width = 620
                informe.Section3.ReportObjects("imgCMIN").Height = 510
            End If

            If Not showMadeInSpain Then
                informe.Section3.ReportObjects("txtMadeInSpain").Width = 0
                informe.Section3.ReportObjects("txtMadeInSpain").Height = 0
            Else
                informe.Section3.ReportObjects("txtMadeInSpain").Width = 2720
                informe.Section3.ReportObjects("txtMadeInSpain").Height = 255

            End If
            ds.Tables(0).Rows.Add(fila)

            informe.Refresh()

            informe.PrintOptions.PrinterName = cbImpresoras.Text

            informe.PrintToPrinter(1, False, 1, 0)
            informe.close
        Catch ex As Exception

            MsgBox("Error al imprimir la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

        End Try

    End Sub
    ' Imprimir codigo qr de la etiqueta, contiene el numSerie
    'Private Sub ImprimirQR(iNumserie As Integer)

    '    Try
    '        Dim dsQR As New QR
    '        Dim imageConverter As New ImageConverter()
    '        Dim QR_generator As New QRCodeEncoder
    '        Dim informeQR As New QRPrueba
    '        Dim x, y As Integer
    '        Dim maxHeight As Integer = 1800
    '        Dim maxWidth As Integer = 1800
    '        Dim image As Image = QR_generator.Encode(iNumserie, System.Text.Encoding.UTF8) ' se crea el qr y se mete en una imagen
    '        x = image.Width
    '        y = image.Height

    '        Dim resto As Double
    '        resto = 2

    '        If y < x And Round(x / y, 1) >= resto Then

    '            y = (y * maxHeight) / x
    '            x = maxWidth

    '        Else

    '            x = (x * maxHeight) / y
    '            y = maxHeight

    '        End If

    '        TryCast(informeQR.Section3.ReportObjects("logo3"), Object).width = x
    '        TryCast(informeQR.Section3.ReportObjects("logo3"), Object).height = y

    '        QR_generator.QRCodeVersion = 0
    '        filaQR = dsQR.Tables(0).NewRow()
    '        dsQR.Tables(0).Rows.Add(filaQR)

    '        filaQR("logo") = DirectCast(imageConverter.ConvertTo(image, GetType(Byte())), Byte())

    '        informeQR.SetDataSource(dsQR)
    '        informeQR.PrintOptions.PrinterName = cbImpresoras.Text
    '        informeQR.PrintToPrinter(1, False, 1, 0)

    '    Catch ex As Exception
    '        MsgBox("Error al imprimir el codigo QR" + vbCrLf + ex.Message, MsgBoxStyle.Information)
    '    End Try

    'End Sub

    'Crea el codigo en la base de datos.
    Public Function CrearImagenCodigo(ByVal numeroSerie As Double) As Image

        Try

            Dim barcode As New Barcode128

            barcode.StartStopText = True

            barcode.BarHeight = 10

            barcode.Code = "C" & numeroSerie

            Return New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        Catch ex As Exception

            MsgBox("Error al crear el código de la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

        End Try

        Return Nothing

    End Function

    'Crea el codigo en la base de datos.
    Public Function CrearImagenCodigoReferencia(ByVal referencia As String) As Image

        Try

            Dim barcode As New Barcode128

            barcode.StartStopText = True

            barcode.BarHeight = 10

            barcode.Code = referencia

            Return New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        Catch ex As Exception

            MsgBox("Error al crear el código de la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

        End Try

        Return Nothing

    End Function

    Public Function cambioEnInputOutput() As Boolean

        Dim cambio As Boolean

        If dtsIO.pInputText <> txInput.Text Then
            cambio = True
        End If

        If dtsIO.pOutputText <> txOutPut.Text Then
            cambio = True
        End If

        'If dtsIO.pWeb <> txWeb.Text Then
        '    cambio = True
        'End If

        Return cambio

    End Function

#End Region

#Region "EVENTOS"

    Private Sub bReload_Click(sender As Object, e As EventArgs) Handles bRecargar.Click
        funcCB.guardarInputOutput(Me)
        reloadValuesCombosLogos()
        cargarEtiquetaCR()
    End Sub

    Private Sub reloadValuesCombosLogos()
        showCE = cbCE.Checked
        showCMIN = cbCMIN.Checked
        showEAC = cbEAC.Checked
        showUKCA = cbUKCA.Checked
        showLPX3 = cbLPX3.Checked
        showUL = cbUL.Checked
        showWEEE = cbWEEEE.Checked
        showMadeInSpain = cbMadeInSpain.Checked
    End Sub

    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        'cargarEtiquetaCR()
        If cbImpresoras.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una impresora.", MsgBoxStyle.Information)
        Else
            funcCB.guardarInputOutput(Me)
            ImprimirEtiquetaCR()
            If inicioPreparacion Then
                funcCB.etiquetaImpresa(iNumserie)
                colorBoton = Color.Blue
            Else
                funcCB.etiquetaFinalImpresa(iNumserie)
                colorBoton = Color.Green
            End If
            If impresoraPredeterminada = "" Then
                funcCB.guardarImpresoraPredeterminada(2, cbImpresoras.Text)
            Else
                funcCB.actualizarImpresoraPredeterminada(2, cbImpresoras.Text)
            End If
        End If
    End Sub

    Private Sub logosClientes_Click(sender As Object, e As EventArgs) Handles bLogosClientes.Click

        Dim gg As New gestionLogosClientes
        gg.iIdArticulo = idArticulo
        gg.iIdCliente = idCliente
        gg.cbCliente.Enabled = False
        gg.ShowDialog()
        cargar()
    End Sub

    Private Sub imprimirEtiqueta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'PantallaGeneral.myTimer.Start()
    End Sub

#End Region
End Class
