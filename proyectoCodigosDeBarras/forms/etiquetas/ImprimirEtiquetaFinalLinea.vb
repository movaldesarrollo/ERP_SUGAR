Imports System.Configuration
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Math
Imports ERP_SUGAR
Imports System.IO

Public Class ImprimirEtiquetaFinalLinea

#Region "Variables y propiedades"

    Dim numSerie As String
    Dim referencia As String
    Dim idCliente As Integer = 0
    Dim idEtiquetaFinal As Integer = 0
    Dim idEtiquetaCliente As Integer = 0
    Dim codArticulo As String = ""
    Dim funcEFL As New FuncionesEtiquetaFinalLinea
    Dim impresoraPredeterminada As String  'Impresora
    Dim funcCB As New funcionesCodigosBarras 'Funciones de codigo de barras.
    Dim funEC As New FuncionesEtiquetaCliente
    Dim dec As New DatosEtiquetaLogisticaCliente
    Dim informeFinal As New EtiquetaFinalLinea_80_100 'EtiquetaFinalLine_80_60
    Dim gestEtiqueta As New GestionEtiquetaLogisticaCliente
    Dim showCE, showCMIN, showEAC, showUKCA, showLPX3, showUL, showWEEE, showMadeInSpain As Boolean
    Dim loaded As Boolean


    Public Property gNumSerie As String
        Get
            Return numSerie
        End Get
        Set(value As String)
            numSerie = value
        End Set
    End Property

    Public Property gReferencia As String
        Get
            Return referencia
        End Get
        Set(value As String)
            referencia = value
        End Set
    End Property

#End Region

#Region "Carga y cierre"
    Private Sub imprimirEtiquetaFinalLinea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarImpresoras()
        cargarEtiqueta()
        loaded = True
    End Sub
#End Region

#Region "Funciones"
    'Carga las impresoras
    Private Sub cargarImpresoras()
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
    End Sub
    'Carga la etiqueta.
    Private Sub cargarEtiqueta()
        informeFinal = New EtiquetaFinalLinea_80_100
        Dim etiFL As New CamposEtiquetaFinalLinea
        Dim dtDatosEtiqueta As New DataTable
        Dim dtDatosInfo As New DataTable
        If Not File.Exists(My.Application.Info.DirectoryPath() & "\ej.pdf") Then
            File.Create(My.Application.Info.DirectoryPath() & "\ej.pdf")
        End If
        dtDatosEtiqueta = funcEFL.obtenerDatosEtiquetaFL(numSerie)
        If dtDatosEtiqueta.Rows.Count > 0 Then
            dtDatosInfo = funcEFL.GetDataInfoExists(numSerie)
            LoadFieldExists(dtDatosInfo)
            etiFL = LoadDataExists(dtDatosEtiqueta)
            dec = funEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
            If dec IsNot Nothing Then
                idEtiquetaCliente = dec.IdEtiqueta1
            End If
            mostrarLogosVariables(etiFL)
            cargarEtiquetaCR(etiFL)
        Else
            dtDatosInfo = funcEFL.GetDataInfo(numSerie)
            LoadField(dtDatosInfo)
            dec = funEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
            etiFL = LoadData(dtDatosInfo)
            mostrarLogosVariables(etiFL)
            If dec IsNot Nothing Then
                idEtiquetaCliente = dec.IdEtiqueta1
            End If
            cargarEtiquetaCR(etiFL)
        End If
    End Sub
    Private Sub preLoadCustomerTag()
        dec = funEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
        If dec IsNot Nothing Then
            idEtiquetaCliente = dec.IdEtiqueta1
        Else
            idEtiquetaCliente = 0
        End If
        'LoadCustomerTag()
        Dim gec As New GestionEtiquetaLogisticaCliente With {
            .idCliente = idCliente,
            .idEtiquetaFinal = idEtiquetaFinal,
            .codArticulo = codArticulo
        }
        gec.preLoadEtiqCliente()
    End Sub
    Private Sub LoadField(datos As DataTable)
        For Each row In datos.Rows
            txCliente.Text = row(0).ToString
            txArticulo.Text = row(1).ToString
            txArticuloCliente.Text = row(1).ToString
            txNumSerie.Text = row(2).ToString
            txPedidoVenta.Text = row(3).ToString
            idCliente = row(4).ToString
            codArticulo = row(1).ToString
            tbEAN13.Text = ""
        Next
    End Sub
    Private Sub LoadFieldExists(datos As DataTable)
        For Each row In datos.Rows
            txCliente.Text = row(0).ToString
            txArticulo.Text = row(1).ToString
            txNumSerie.Text = row(2).ToString
            txPedidoVenta.Text = row(3).ToString
            idCliente = row(4)
            idEtiquetaFinal = row(5)
            codArticulo = row(1).ToString
            txArticuloCliente.Text = row(6).ToString
            tbEAN13.Text = row(7).ToString
        Next
    End Sub
    Private Function LoadData(datos As DataTable) As CamposEtiquetaFinalLinea
        Dim obj As New CamposEtiquetaFinalLinea
        Try
            For Each row In datos.Rows
                With obj
                    .gRefCliente = row(1)
                    .gNumSerie = row(2)
                    .gCantidad = 1
                    .gPV = row(3)
                    .gCustomerPartNumber = row(1)
                    .gEAN13 = tbEAN13.Text
                    .gLogoCE = cbCE.Checked
                    .gLogoCMIN = cbCMIN.Checked
                    .gLogoEAC = cbEAC.Checked
                    .gLogoUKCA = cbUKCA.Checked
                    .gLogoLPX3 = cbLPX3.Checked
                    .gLogoUL = cbUL.Checked
                    .gLogoWEEE = cbWEEEE.Checked
                    .gLogoMADEINSPAIN = cbMadeInSpain.Checked
                End With
            Next
        Catch ex As Exception

        End Try

        Return obj
    End Function
    Private Function LoadDataExists(datos As DataTable) As CamposEtiquetaFinalLinea
        Dim obj As New CamposEtiquetaFinalLinea
        For Each row In datos.Rows
            With obj
                .gRefCliente = row("refCliente")
                .gNumSerie = row("numSerie")
                .gCantidad = row("cantidad")
                .gPV = row("PV")
                .gLogoCE = row("logoCE")
                .gLogoCMIN = row("logoCMIN")
                .gLogoEAC = row("logoEAC")
                .gLogoUKCA = row("logoUKCA")
                .gLogoLPX3 = row("logoLPX3")
                .gLogoUL = row("logoUL")
                .gLogoWEEE = row("logoWEEE")
                .gLogoMADEINSPAIN = row("logoMADEINSPAIN")
                .gCustomerPartNumber = row("customerPartNumber")
                .gEAN13 = row("EAN13")
            End With
        Next
        Return obj
    End Function
    Private Sub cargarEtiquetaCR(etiFL As CamposEtiquetaFinalLinea)
        informeFinal = LoadDataReportLabel(etiFL)
    End Sub
    Private Sub LoadCustomerTag()
        If idEtiquetaCliente > 0 Then
            Dim informeCliente As New EtiquetaCliente_80_100
            informeCliente = LoadDataReportClient()
        End If
    End Sub
    Private Function LoadDataReportLabel(etiFL As CamposEtiquetaFinalLinea) As EtiquetaFinalLinea_80_100
        'Dim informe As New EtiquetaFinalLine_80_60
        dec = funEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
        Dim imageConverter As New ImageConverter()
        Dim ds As New EtiquetaFinalLinea
        Dim fila As DataRow
        fila = ds.Tables(0).NewRow
        fila("textefCliente") = etiFL.gRefCliente
        fila("textNumSerie") = etiFL.gNumSerie
        fila("textCantidad") = etiFL.gCantidad
        fila("textCustomerPartNumber") = etiFL.gCustomerPartNumber
        fila("textEAN13") = etiFL.gEAN13
        fila("PV") = etiFL.gPV
        fila("codRefCliente") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gRefCliente), GetType(Byte())), Byte())
        fila("codNumSerie") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gNumSerie), GetType(Byte())), Byte())
        fila("codCantidad") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gCantidad), GetType(Byte())), Byte())
        fila("codEAN13") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gEAN13), GetType(Byte())), Byte())
        fila("codPV") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gPV), GetType(Byte())), Byte())
        fila("codCustomerPartNumber") = DirectCast(imageConverter.ConvertTo(CrearImagenCodigo(etiFL.gCustomerPartNumber), GetType(Byte())), Byte())
        If dec IsNot Nothing Then
            If Not dec.Imagen1 Is Nothing Then
                Dim maxAlto As Integer
                Dim maxAncho As Integer
                Dim resto As Double
                Dim x As Integer
                Dim y As Integer
                Dim diferenciaTop As Integer = 0
                Dim ms As New IO.MemoryStream(CType(dec.Imagen1, Byte()))
                Dim imgLogoCliente As Image = Image.FromStream(ms)
                fila("etiquetaCliente") = DirectCast(imageConverter.ConvertTo(imgLogoCliente, GetType(Byte())), Byte())
                x = dec.Width1
                y = dec.Height1
                maxAlto = TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).height
                maxAncho = TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).width
                'Los lados iguales
                If y - x = 0 Then
                    x = maxAlto
                    y = maxAlto
                Else
                    'alto es mayo que ancho
                    If y > x Then
                        x = (x * maxAlto) / y
                        y = maxAlto
                    Else
                        Dim proporcionMax As Integer = maxAncho / maxAlto
                        Dim proporcionReal As Integer = x / y
                        If proporcionMax > proporcionReal Then
                            y = maxAlto
                            x = y * proporcionReal
                        Else
                            x = (x * maxAlto) / y
                            y = maxAlto
                        End If
                    End If
                    If y < x Then
                        y = (x / maxAncho) * y
                        x = maxAncho
                    End If
                End If
                'Parametros del LogoCabecera
                Dim clienteLogoTop As Integer = (maxAlto - y) / 2
                Dim ClienteLogoLeft As Integer = (5670 - x) / 2
                TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).width = x
                TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).height = y
                TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).left = ClienteLogoLeft
                TryCast(informeFinal.Section3.ReportObjects("etiquetaCliente1"), Object).Top = clienteLogoTop
            Else
                fila("etiquetaCliente") = Nothing
            End If
        Else
            fila("etiquetaCliente") = Nothing
        End If
        ds.Tables(0).Rows.Add(fila)
        SizeInforme(informeFinal)
        informeFinal.SetDataSource(ds)
        crViewer.ReportSource = informeFinal
        Return informeFinal
    End Function
    Private Function LoadDataReportClient() As EtiquetaCliente_80_100
        Dim IsPDF As Boolean
        IsPDF = funcEFL.CheckFileType(idEtiquetaCliente)
        Dim dsEtiquetaCliente As New EtiquetaCliente
        Dim imageConverter As New ImageConverter()
        Dim informe As New EtiquetaCliente_80_100
        informe.SetDataSource(dsEtiquetaCliente)
        If IsPDF = False Then
            Dim fila As DataRow
            dec = funEC.GetCustomerTag(idCliente, idEtiquetaFinal, codArticulo)
            fila = dsEtiquetaCliente.Tables(0).NewRow
            If dec IsNot Nothing Then
                fila("imagen") = dec.Imagen1
            Else
                fila("imagen") = Nothing
            End If
            dsEtiquetaCliente.Tables(0).Rows.Add(fila)
            informe.Section3.ReportObjects("Picture2").Width = 0
            informe.Section3.ReportObjects("Picture2").Height = 0
            informe.SetDataSource(dsEtiquetaCliente)
        End If
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        informe.Refresh()
        Return informe
    End Function
    Private Sub SizeInforme(informe As EtiquetaFinalLinea_80_100)
        Dim heightLabel As Integer = 360
        Dim widthLabel As Integer = 480
        With informe.Section3
            .ReportObjects("imgCE").Width = IIf(showCE, widthLabel, 0)
            .ReportObjects("imgCE").Height = IIf(showCE, heightLabel, 0)
            .ReportObjects("imgEAC").Width = IIf(showEAC, widthLabel, 0)
            .ReportObjects("imgEAC").Height = IIf(showEAC, heightLabel, 0)
            .ReportObjects("imgUKCA").Width = IIf(showUKCA, widthLabel, 0)
            .ReportObjects("imgUKCA").Height = IIf(showUKCA, heightLabel, 0)
            .ReportObjects("imgIPX3").Width = IIf(showLPX3, widthLabel, 0)
            .ReportObjects("imgIPX3").Height = IIf(showLPX3, heightLabel, 0)
            .ReportObjects("imgWEEE").Width = IIf(showWEEE, widthLabel, 0)
            .ReportObjects("imgWEEE").Height = IIf(showWEEE, heightLabel, 0)
            .ReportObjects("imgUL").Width = IIf(showUL, widthLabel, 0)
            .ReportObjects("imgUL").Height = IIf(showUL, heightLabel, 0)
            .ReportObjects("imgCMIN").Width = IIf(showCMIN, widthLabel, 0)
            .ReportObjects("imgCMIN").Height = IIf(showCMIN, heightLabel, 0)
            .ReportObjects("txtMadeInSpain").Width = IIf(showMadeInSpain, 1680, 0)
            .ReportObjects("txtMadeInSpain").Height = IIf(showMadeInSpain, 240, 0)
        End With
    End Sub
    Private Sub mostrarLogosVariables(dts As CamposEtiquetaFinalLinea)
        showCE = IIf(dts.gLogoCE, True, False)
        cbCE.Checked = IIf(dts.gLogoCE, True, False)
        showEAC = IIf(dts.gLogoEAC, True, False)
        cbEAC.Checked = IIf(dts.gLogoEAC, True, False)
        showUKCA = IIf(dts.gLogoUKCA, True, False)
        cbUKCA.Checked = IIf(dts.gLogoUKCA, True, False)
        showLPX3 = IIf(dts.gLogoLPX3, True, False)
        cbLPX3.Checked = IIf(dts.gLogoLPX3, True, False)
        showUL = IIf(dts.gLogoUL, True, False)
        cbUL.Checked = IIf(dts.gLogoUL, True, False)
        showWEEE = IIf(dts.gLogoWEEE, True, False)
        cbWEEEE.Checked = IIf(dts.gLogoWEEE, True, False)
        showCMIN = IIf(dts.gLogoCMIN, True, False)
        cbCMIN.Checked = IIf(dts.gLogoCMIN, True, False)
        showMadeInSpain = IIf(dts.gLogoMADEINSPAIN, True, False)
        cbMadeInSpain.Checked = IIf(dts.gLogoMADEINSPAIN, True, False)
    End Sub
    'Crea el codigo de barras con el texto que le pases.
    Public Function CrearImagenCodigo(ByVal texto As String) As Image
        Try
            Dim barcode As New Barcode128
            barcode.StartStopText = True
            barcode.BarHeight = 10
            barcode.Code = texto
            Return New Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))
        Catch ex As Exception
            MsgBox("Error al crear el código del campo" & texto & vbCrLf & ex.Message, MsgBoxStyle.Information)
        End Try
        Return Nothing
    End Function
    'Guarda la etiqueta.
    Private Function SaveOrUpdateLabel() As Boolean
        Dim res As Boolean = False
        If Not tbEAN13.Text.Trim.Equals("") Then
            If verifyEAN13(tbEAN13.Text) Then
                Dim dataEtiquetaFinal As New CamposEtiquetaFinalLinea
                dataEtiquetaFinal = llenarObjetoDatosEtiqueta()
                Dim result As Boolean = False
                If funcEFL.ExistsLabel(numSerie) Then
                    result = funcEFL.updateValuesLogos(dataEtiquetaFinal)
                Else
                    result = funcEFL.InsertValuesLogos(dataEtiquetaFinal)
                End If
                If result Then
                    cargarEtiqueta()
                Else
                    MsgBox("Error al cargar los datos en la etiqueta.", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("El código EAN13 no tiene un formato válido", MsgBoxStyle.Information)
                Return False
            End If
            res = True
        Else
            MsgBox("El código EAN13 está vacío, debe rellenarlo para continuar.", MsgBoxStyle.Information)
            tbEAN13.Focus()
            res = False
        End If
        Return res
    End Function
    'Llena los campos de etiqueta.
    Private Function llenarObjetoDatosEtiqueta() As CamposEtiquetaFinalLinea
        Dim dataEF As New CamposEtiquetaFinalLinea
        Try
            dataEF.gLogoCE = cbCE.Checked
            dataEF.gLogoCMIN = cbCMIN.Checked
            dataEF.gLogoEAC = cbEAC.Checked
            dataEF.gLogoLPX3 = cbLPX3.Checked
            dataEF.gLogoUL = cbUL.Checked
            dataEF.gLogoWEEE = cbWEEEE.Checked
            dataEF.gLogoUKCA = cbUKCA.Checked
            dataEF.gLogoMADEINSPAIN = cbMadeInSpain.Checked
            dataEF.gNumSerie = numSerie
            dataEF.gCantidad = 1
            dataEF.gPV = txPedidoVenta.Text
            dataEF.gRefCliente = txArticulo.Text
            dataEF.gEAN13 = tbEAN13.Text
            dataEF.gCustomerPartNumber = txArticuloCliente.Text
            Return dataEF
        Catch ex As Exception
            MsgBox("llenarObjetoDatosEtiqueta: " & ex.ToString, MsgBoxStyle.Critical)
        End Try
        Return dataEF
    End Function
    'Imprime la etiqueta.
    Private Sub PrintLabel()
        Try
            informeFinal.PrintOptions.PrinterName = cbImpresoras.Text
            informeFinal.PrintToPrinter(1, False, 1, 0)
            informeFinal.Close()
            funcCB.guardarImpresoraPredeterminada(2, cbImpresoras.Text)
        Catch ex As Exception
            MsgBox("Error al imprimir la etiqueta." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Verifica el EAN13
    Private Function verifyEAN13(ByVal codigo As String) As Boolean
        'Variables a utilizar
        Dim X As Integer
        Dim SumaPar As Integer
        Dim SumaImpar As Integer
        Dim Resto As Integer
        Dim Control As Integer
        'Comprobar que el código tiene 13 dígitos. De no ser así, no es correcto.
        If Len(tbEAN13.Text) <> 13 Then
            verifyEAN13 = False
            Exit Function
        End If
        'Sumar los dígitos de lugares pares por un lado y los de los impares por otro, pero sin incuir el último dígito.
        For X = 1 To 12
            If X Mod 2 = 0 Then
                SumaPar = SumaPar + CInt(Mid(tbEAN13.Text, X, 1))
            Else
                SumaImpar = SumaImpar + CInt(Mid(codigo, X, 1))
            End If
        Next X
        'multiplicar la suma de los pares por 3.
        SumaPar = SumaPar * 3

        'Sumar el resultado de los pares y el de los impares y hallar el resto de la división por 10.
        Resto = (SumaPar + SumaImpar) Mod 10

        'Realizar la operación 10 menos ese resto y ese es el dígito de control
        Control = 10 - Resto

        'Si como resultado sale 10, entenderemos que el dígito de control es 0.
        If Control = 10 Then
            If CInt(Strings.Right(codigo, 1)) = 0 Then
                verifyEAN13 = True
                Exit Function
            Else
                verifyEAN13 = False
                Exit Function
            End If
        End If
        'Comprobar que el dígito de control que hemos calculado y el último dígito del código EAN coinciden
        If CInt(Strings.Right(codigo, 1)) = Control Then
            verifyEAN13 = True
            Exit Function
        Else
            verifyEAN13 = False
            Exit Function
        End If
    End Function

#End Region

#Region "Eventos"
    'Abre la configuración de logos.
    Private Sub bLogosClientes_Click(sender As Object, e As EventArgs) Handles bLogosClientes.Click
        If SaveOrUpdateLabel() Then
            Dim gec As New GestionEtiquetaLogisticaCliente With {
               .idCliente = idCliente,
               .idEtiquetaFinal = idEtiquetaFinal,
               .codArticulo = codArticulo,
               .idArticulo = getIdArticle(codArticulo)
            }
            gec.ShowDialog()
            preLoadCustomerTag()
            LoadCustomerTag()
            cargarEtiqueta()
        End If
    End Sub
    'Guarda la configuración y actualiza la etiqueta.
    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        SaveOrUpdateLabel()
    End Sub
    'Guarda la configuración y actualiza la etiqueta al cambiar los checks de estado.
    Private Sub cbEAC_CheckedChanged(sender As Object, e As EventArgs) Handles cbEAC.CheckedChanged, cbCE.CheckedChanged, cbCMIN.CheckedChanged _
, cbWEEEE.CheckedChanged, cbUKCA.CheckedChanged, cbLPX3.CheckedChanged, cbMadeInSpain.CheckedChanged, cbUL.CheckedChanged
        If loaded = False Then
            SaveOrUpdateLabel()
        End If
    End Sub
    'Cierra y libera memoria.
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click
        LiberarMemoria()
        Close()
    End Sub
    'Guarda e imprime la etiqueta.
    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click
        If SaveOrUpdateLabel() Then
            PrintLabel()
        Else
            MsgBox("Error al guardar los cambios en la etiqueta.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If idEtiquetaCliente > 0 Then
            If Not dec.gPathPDF.Equals("") Then
                If File.Exists(dec.gPathPDF) Then
                    printPDFCliente()
                End If
            End If
        End If
    End Sub
    'Imprime la etiqueta del cliente.
    Private Sub printPDFCliente()
        Dim informePDFCliente As New EtiquetaCliente_80_100
        Try
            If actualizarPDFImpresion() Then
                informePDFCliente.Refresh()
                informePDFCliente.PrintOptions.PrinterName = cbImpresoras.Text
                informePDFCliente.PrintToPrinter(1, False, 1, 0)
                informePDFCliente.Close()
            End If
        Catch ex As Exception
            MsgBox("Error al imprimir la etiqueta del cliente. Contacte con un administrador.", vbCritical)
        End Try
    End Sub
    'Actualiza el PDF.
    Private Function actualizarPDFImpresion() As Boolean
        Dim result As Boolean = False
        Dim rutaInicio As String = My.Application.Info.DirectoryPath() & "\ej.pdf"
        File.Copy(My.Application.Info.DirectoryPath() & "\PDFS_LOGOS_CLIENTES" & "\" & idCliente & "\" & "PDF_" & idCliente & "_LOGO.pdf", rutaInicio, True)
        Console.WriteLine(idCliente)
        result = True
        Return result
    End Function
    'Busca la id de articulo en la tabla de articulocliente.
    Private Function getIdArticle(codArticulo As String) As Integer
        Return funcEFL.getIdArticle(codArticulo)
    End Function
#End Region
End Class