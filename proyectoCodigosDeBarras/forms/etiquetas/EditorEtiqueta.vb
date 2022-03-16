Imports iTextSharp.text.pdf
Imports System.Math
Public Class EditorEtiqueta

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras 'Funciones de codigo de barras
    Public idEtiqueta As Integer = 0 'Id de la etiqueta
    Public idCliente As Integer 'Id del cliente
    Public idArticulo As Integer 'Id del articulo
    Dim informe As New EtiquetaEquipoAU1 'Crystal report
    Dim impresoraPredeterminada As String 'Impresora
    Dim dtsIO As New datosEtiquetasInputOutput 'Dts de inputs iniciales
    Public imgLogoCliente As Image
    Public imgLogoIzquierda As Image
    Public imgLogoDerecha As Image

#End Region

#Region "CARGA Y CIERRE"

    'Carga el form
    Private Sub EditorEtiqueta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Desactiva los botones guardar y logos
        bGuardar.Enabled = False

        bLogosClientes.Enabled = False

        'Llena los combos para los valores de etiquetas.
        llenarCombos()

        ''Cargamos las impresoras que estan instaladas en el equipo en el combobox.
        'For Each printer In PrinterSettings.InstalledPrinters

        '    cbImpresoras.Items.Add(printer)

        'Next

        ''Seleccionamos la impresora predeterminada si la hubiera.
        'impresoraPredeterminada = funcCB.impresorapredeterminada(2)

        'For Each printer In cbImpresoras.Items

        '    If printer = impresoraPredeterminada Then

        '        cbImpresoras.Text = impresoraPredeterminada

        '    End If

        'Next

    End Sub

    'Sale del editor.
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Me.Close()

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

            If funcCB.ExisteEtiquetaOffline(dts, idArticulo, idCliente) Then

                If dts.pIdCliente = 0 Then
                Else

                    ckWeb.Checked = dts.pCampoWeb

                    idCliente = dts.pIdCliente

                    idArticulo = dts.pIdArticulo

                    txArticuloCliente.Text = Trim(dts.pArticuloCliente)

                    txInput.Text = Trim(Replace(dts.pInputText, vbTab, ""))

                    txOutPut.Text = Trim(Replace(dts.pOutputText, vbTab, ""))

                    txWeb.Text = Trim(Replace(dts.pWeb, vbTab, ""))

                    imgLogoCliente = dts.pLogoCliente

                    imgLogoIzquierda = dts.pLogoBottonLeft

                    imgLogoDerecha = dts.pLogoBottonRight


                    If dts.pIdCamposEtiquetasPedidos Then

                        txEtiqueta0.Text = dts.pEti0
                        txEtiqueta1.Text = dts.pEti1
                        txEtiqueta2.Text = dts.pEti2
                        txEtiqueta3.Text = dts.pEti3
                        txEtiqueta4.Text = dts.pEti4
                        txEtiqueta5.Text = dts.pEti5
                        txEtiqueta6.Text = dts.pEti6

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
                        txEtiqueta6.Text = ""

                        cbValor0.Text = txArticuloCliente.Text
                        cbValor1.Text = ""
                        cbValor2.Text = dts.pArticuloCliente
                        cbValor3.Text = ""
                        cbValor4.Text = txInput.Text
                        cbValor5.Text = txOutPut.Text
                    End If

                    'Datos inputs outputs

                    dtsIO.pIdArticulo = dts.pIdArticulo

                    dtsIO.pWeb = dts.pWeb

                    dtsIO.pOutputText = dts.pOutputText

                    dtsIO.pInputText = dts.pInputText

                    Return True

                End If

            Else

                Return False

            End If

        Catch ex As Exception

            MsgBox("Error (EditorEtiqueta) E117 al cargar la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

            Return False

        End Try

        Return True

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

                Case 3
                    resultado = txWeb.Text

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

            Dim fila As DataRow

            informe = New EtiquetaEquipoAU1

            fila = ds.Tables(0).NewRow()

            'Etiquetas

            fila("Etiqueta0") = txEtiqueta0.Text

            fila("Etiqueta1") = txEtiqueta1.Text

            fila("Etiqueta2") = txEtiqueta2.Text

            fila("Etiqueta3") = txEtiqueta3.Text

            fila("Etiqueta4") = txEtiqueta4.Text

            fila("Etiqueta5") = txEtiqueta5.Text

            fila("Etiqueta6") = txEtiqueta6.Text

            If ckWeb.Checked Then

                fila("Etiqueta7") = txWeb.Text

            Else

                fila("Etiqueta7") = ""

            End If


            'VALORES

            fila("Valor0") = valorCombo(cbValor0)

            fila("Valor1") = valorCombo(cbValor1)

            fila("Valor2") = valorCombo(cbValor2)

            fila("Valor3") = valorCombo(cbValor3)

            fila("Valor4") = valorCombo(cbValor4)

            fila("Valor5") = valorCombo(cbValor5)

            fila("Valor6") = 99999

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

            If Not imgLogoIzquierda Is Nothing Then

                fila("Logo2") = DirectCast(imageConverter.ConvertTo(imgLogoIzquierda, GetType(Byte())), Byte())

                'LogoIzquierdo----------------------------------------------------------------------------------------------

                x = imgLogoIzquierda.Width

                y = imgLogoIzquierda.Height

                Dim topLogo23 As Integer

                Dim LeftLogo23 As Integer

                If Trim(txEtiqueta6.Text) = "" Then

                    maxAncho = 1356

                    maxAlto = 1095

                    resto = maxAncho / maxAlto

                    diferenciaTop = 527

                Else

                    maxAncho = 1356

                    maxAlto = 568

                    resto = 2.39

                End If

                If y < x And Round(x / y, 1) >= Round(resto, 1) Then

                    y = (y * maxAncho) / x
                    x = maxAncho

                Else

                    x = (x * maxAlto) / y
                    y = maxAlto

                End If

                'Parametros del LogoIzquierdo
                LeftLogo23 = (maxAncho - x) / 2 + 226
                topLogo23 = ((maxAlto - y) / 2) + (3842 - diferenciaTop)
                TryCast(informe.Section3.ReportObjects("Logo23"), Object).width = x
                TryCast(informe.Section3.ReportObjects("Logo23"), Object).height = y
                TryCast(informe.Section3.ReportObjects("Logo23"), Object).Top = topLogo23
                TryCast(informe.Section3.ReportObjects("Logo23"), Object).left = LeftLogo23

                '-------------------------------------------------------------------------------------------------------------

            End If

            If Not imgLogoDerecha Is Nothing Then

                fila("Logo3") = DirectCast(imageConverter.ConvertTo(imgLogoDerecha, GetType(Byte())), Byte())

                'LogoDerecho----------------------------------------------------------------------------------------

                x = imgLogoDerecha.Width

                y = imgLogoDerecha.Height

                If Trim(txEtiqueta6.Text) = "" Then

                    maxAncho = 1469

                    maxAlto = 1095

                    diferenciaTop = 527

                Else

                    maxAncho = 1469

                    maxAlto = 568

                    diferenciaTop = 0

                End If

                resto = maxAncho / maxAlto

                If y < x And Round(x / y, 1) >= Round(resto, 1) Then

                    y = (y * maxAncho) / x
                    x = maxAncho

                Else

                    x = (x * maxAlto) / y
                    y = maxAlto

                End If

                'Parametros del LogoDerecho

                Dim topLogo34 As Integer = ((maxAlto - y) / 2) + (3842 - diferenciaTop)
                Dim leftLogo34 As Integer = ((maxAncho - x) / 2) + 1582
                TryCast(informe.Section3.ReportObjects("Logo34"), Object).width = x
                TryCast(informe.Section3.ReportObjects("Logo34"), Object).height = y
                TryCast(informe.Section3.ReportObjects("Logo34"), Object).Top = topLogo34
                TryCast(informe.Section3.ReportObjects("Logo34"), Object).left = leftLogo34

                '--------------------------------------------------------------------------------------------------------


            End If

            fila("numSerie") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(99999), GetType(Byte())), Byte())

            fila("barcodeReferencia") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigoReferencia(valorCombo(cbValor0)), GetType(Byte())), Byte())

            ds.Tables(0).Rows.Add(fila)

            If ckWeb.Checked Then

            Else

                TryCast(informe.Section3.ReportObjects("Etiqueta61"), Object).height = 527 + 221
                TryCast(informe.Section3.ReportObjects("Etiqueta61"), Object).top = 3060

            End If

            informe.SetDataSource(ds)

            crPrv.ReportSource = informe

        Catch ex As Exception

            MsgBox("Error (EditorEtiqueta) E175 al cargar la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

        End Try

    End Sub

    'Crea el codigo en la base de datos.
    Public Function CrearImagenCodigo(ByVal numeroSerie As Double) As Image

        Try

            Dim barcode As New Barcode128

            barcode.StartStopText = True

            barcode.BarHeight = 10

            barcode.Code = numeroSerie

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

    'Detecta cambios en los input y output.
    Public Function cambioEnInputOutput() As Boolean

        Dim cambio As Boolean

        If dtsIO.pInputText <> txInput.Text Then
            cambio = True
        End If

        If dtsIO.pOutputText <> txOutPut.Text Then
            cambio = True
        End If

        If dtsIO.pWeb <> txWeb.Text Then
            cambio = True
        End If

        Return cambio

    End Function

#End Region

#Region "EVENTOS"

    'Guarda los cambios.
    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        funcCB.guardarInputOutputOffline(Me)

        cargar()

        cargarEtiquetaCR()

    End Sub

    'Buscar logos.
    Private Sub logosClientes_Click(sender As Object, e As EventArgs) Handles bLogosClientes.Click

        Dim gg As New gestionLogosClientes

        gg.iIdCliente = idCliente

        gg.iIdArticulo = idArticulo

        gg.cbCliente.Enabled = False

        gg.ShowDialog()

        cargar()

        cargarEtiquetaCR()

    End Sub

    'Boton limpiar
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        idArticulo = 0

        idCliente = 0

        txArticulo.Text = ""

        txCliente.Text = ""

        bBuscar.Enabled = True

        bBuscarArticulo.Enabled = True

        bBuscarCliente.Enabled = True

        bGuardar.Enabled = False

        bLogosClientes.Enabled = False

        ckWeb.Checked = False

        limpiar()

    End Sub

    Public Function limpiar() As Boolean

        Try

            For Each control In gbParametros.Controls

                If TypeOf control Is TextBox Then

                    control.text = ""

                End If

            Next

            llenarCombos()

            crPrv.ReportSource = Nothing

            crPrv.RefreshReport()

            Return True


        Catch ex As Exception

            MsgBox("Error al limpiar el form", MsgBoxStyle.Information)

            Return False

        End Try

    End Function

    'Busqueda de etiquetas.
    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click
        If idCliente > 0 And idArticulo > 0 Then
            If Not funcCB.existenLogosClienteArticulo(idCliente, idArticulo) Then
                funcCB.existenLogosCliente(idCliente, idArticulo)
            End If
            If limpiar() Then

                bBuscar.Enabled = False

                bBuscarArticulo.Enabled = False

                bBuscarCliente.Enabled = False

                bGuardar.Enabled = True

                bLogosClientes.Enabled = True

                If cargar() = False Then

                    funcCB.guardarInputOutputOffline(Me)

                    cargar()

                End If

                cargarEtiquetaCR()

            End If

        Else

            MsgBox("Debe seleccionar un cliente y un articulo", MsgBoxStyle.Information)

        End If

    End Sub

    'Buscar Articulo
    Private Sub bBuscarArticulo_Click(sender As Object, e As EventArgs) Handles bBuscarArticulo.Click

        Dim art As New BusquedaSimpleArticulo

        art.pModo = "Etiquetas"

        art.ShowDialog()

        If art.iidArticulo <> 0 Then

            idArticulo = art.iidArticulo

            txArticulo.Text = art.sCodArticulo

        End If

    End Sub

    'Busca cliente.
    Private Sub bBuscarCliente_Click(sender As Object, e As EventArgs) Handles bBuscarCliente.Click

        Dim cli As New busquedaSimpleCliente

        cli.pModo = "B"

        cli.ShowDialog()

        If cli.iidCliente <> 0 Then

            idCliente = cli.iidCliente

            txCliente.Text = cli.vNombre

        End If

    End Sub

#End Region

End Class


'    'Imprime la etiqueta y guarda los cambios.
'    Public Sub ImprimirEtiquetaCR()

'        Try

'            Dim ds As New Etiqueta

'            Dim fila As DataRow

'            informe = New EtiquetaEquipoAU

'            Dim settings As ConnectionStringSettings

'            settings = ConfigurationManager.ConnectionStrings(1)

'            Dim csb As New SqlConnectionStringBuilder

'            csb.ConnectionString = settings.ConnectionString

'            informe.SetDatabaseLogon(csb.UserID, csb.Password)

'            fila = ds.Tables(0).NewRow()

'            'ETIQUETAS

'            fila("Etiqueta0") = txEtiqueta0.Text

'            fila("Etiqueta1") = txEtiqueta1.Text

'            fila("Etiqueta2") = txEtiqueta2.Text

'            fila("Etiqueta3") = txEtiqueta3.Text

'            fila("Etiqueta4") = txEtiqueta4.Text

'            fila("Etiqueta5") = txEtiqueta5.Text

'            fila("Etiqueta6") = txEtiqueta6.Text

'            fila("Etiqueta7") = txWeb.Text

'            'VALORES

'            fila("Valor0") = valorCombo(cbValor0)

'            fila("Valor1") = valorCombo(cbValor1)

'            fila("Valor2") = valorCombo(cbValor2)

'            fila("Valor3") = valorCombo(cbValor3)

'            fila("Valor4") = valorCombo(cbValor4)

'            fila("Valor5") = valorCombo(cbValor5)

'            fila("Valor6") = 99999

'            'LOGOS

'            Dim imageConverter As New ImageConverter()

'            fila("Logo1") = DirectCast(imageConverter.ConvertTo(imgLogoCliente, GetType(Byte())), Byte())

'            fila("Logo2") = DirectCast(imageConverter.ConvertTo(imgLogoIzquierda, GetType(Byte())), Byte())

'            fila("Logo3") = DirectCast(imageConverter.ConvertTo(imgLogoDerecha, GetType(Byte())), Byte())

'            fila("numSerie") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(99999), GetType(Byte())), Byte())

'            ds.Tables(0).Rows.Add(fila)

'            If Trim(txWeb.Text) = "" Then

'                TryCast(informe.Section3.ReportObjects("Etiqueta61"), Object).height = 527 + 221
'                TryCast(informe.Section3.ReportObjects("Etiqueta61"), Object).top = 3060

'            End If


'#Region "IMAGENES REDIMENSION LOGOS"

'            'IMAGENES REDIMENSION

'            'LogoCabecera-----------------------------------------------------------------------------

'            Dim x As Integer = imgLogoCliente.Width

'            Dim y As Integer = imgLogoCliente.Height

'            Dim maxAlto As Integer = 737

'            Dim maxAncho As Integer = 2635

'            Dim resto As Double = 3.6

'            If y < x And Round(x / y, 1) >= resto Then

'                y = (y * maxAncho) / x
'                x = maxAncho

'            Else

'                x = (x * maxAlto) / y
'                y = maxAlto

'            End If

'            'Parametros del LogoCabecera

'            Dim ClienteLogo1 As Integer = (3390 - x) / 2
'            TryCast(informe.Section3.ReportObjects("Logo11"), Object).width = x
'            TryCast(informe.Section3.ReportObjects("Logo11"), Object).height = y
'            TryCast(informe.Section3.ReportObjects("Logo11"), Object).left = ClienteLogo1


'            '-------------------------------------------------------------------------------------------------------------------

'            'LogoIzquierdo----------------------------------------------------------------------------------------------

'            x = imgLogoIzquierda.Width

'            y = imgLogoIzquierda.Height

'            Dim topLogo23 As Integer

'            Dim LeftLogo23 As Integer

'            Dim diferenciaTop As Integer = 0

'            If Trim(txEtiqueta6.Text) = "" Then

'                maxAncho = 1356

'                maxAlto = 1095

'                resto = maxAncho / maxAlto

'                diferenciaTop = 527

'            Else

'                maxAncho = 1356

'                maxAlto = 568

'                resto = 2.39

'            End If

'            If y < x And Round(x / y, 1) >= Round(resto, 1) Then

'                y = (y * maxAncho) / x
'                x = maxAncho

'            Else

'                x = (x * maxAlto) / y
'                y = maxAlto

'            End If

'            'Parametros del LogoIzquierdo
'            LeftLogo23 = (maxAncho - x) / 2 + 226
'            topLogo23 = ((maxAlto - y) / 2) + (3842 - diferenciaTop)
'            TryCast(informe.Section3.ReportObjects("Logo23"), Object).width = x
'            TryCast(informe.Section3.ReportObjects("Logo23"), Object).height = y
'            TryCast(informe.Section3.ReportObjects("Logo23"), Object).Top = topLogo23
'            TryCast(informe.Section3.ReportObjects("Logo23"), Object).left = leftLogo23

'            '-------------------------------------------------------------------------------------------------------------

'            'LogoDerecho----------------------------------------------------------------------------------------

'            x = imgLogoDerecha.Width

'            y = imgLogoDerecha.Height

'            If Trim(txEtiqueta6.Text) = "" Then

'                maxAncho = 1469

'                maxAlto = 1095

'                diferenciaTop = 527

'            Else

'                maxAncho = 1469

'                maxAlto = 568

'                diferenciaTop = 0

'            End If

'            resto = maxAncho / maxAlto

'            If y < x And Round(x / y, 1) >= Round(resto, 1) Then

'                y = (y * maxAncho) / x
'                x = maxAncho

'            Else

'                x = (x * maxAlto) / y
'                y = maxAlto

'            End If

'            'Parametros del LogoDerecho

'            Dim topLogo34 As Integer = ((maxAlto - y) / 2) + (3842 - diferenciaTop)
'            Dim leftLogo34 As Integer = ((maxAncho - x) / 2) + 1582
'            TryCast(informe.Section3.ReportObjects("Logo34"), Object).width = x
'            TryCast(informe.Section3.ReportObjects("Logo34"), Object).height = y
'            TryCast(informe.Section3.ReportObjects("Logo34"), Object).Top = topLogo34
'            TryCast(informe.Section3.ReportObjects("Logo34"), Object).left = leftLogo34

'            '--------------------------------------------------------------------------------------------------------

'#End Region


'            informe.SetDataSource(ds)

'            informe.Refresh()

'            informe.PrintOptions.PrinterName = cbImpresoras.Text

'            informe.PrintToPrinter(1, False, 1, 0)

'        Catch ex As Exception

'            MsgBox("Error al imprimir la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Information)

'        End Try

'    End Sub
