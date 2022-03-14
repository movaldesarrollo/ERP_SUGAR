Imports Microsoft.Office.Interop
Imports System.Net.Mail
Public Class GestionMaster
    Private vSoloLectura As Boolean
    Private DI As New DatosIniciales
    Private MA As New Master
    Private ep1 As New ErrorProvider
    Private semaforo As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            semaforo = False
            bGuardar.Enabled = Not vSoloLectura
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            numFactura.Text = 0
            numSerie.Text = 0
            numSerie2.Text = 0
            numAlbaran.Text = 0
            numPedido.Text = 0
            numPedidoProv.Text = 0
            numOferta.Text = 0
            numReparacion.Text = 0
            numProforma.Text = 0
            SMTPPuerto.Text = 25
            ckAutenticado.Checked = False
            ckSSL.Checked = False
            cbPortes.Items.Clear()
            cbPortes.Items.Add("PAGADOS")
            cbPortes.Items.Add("DEBIDOS")
            Call introducirIdiomas()
            Call introducirOpciones()
            Call introducirTiposIVA()
            Call introducirTiposRetencion()
            Call introducirTiposValorado()
            Call IntroducirAños()
            If cbAño.SelectedIndex > -1 Then
                Call cargarDatosAnuales()
                Call cargarDatosNoAnuales()
            End If
            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        Dim func As New Master()
        Dim dt As DataTable = func.listaAños()
        Dim linea As DataRow
        For Each linea In dt.Rows
            If linea("numeracion") Is DBNull.Value Then
            Else
                If linea("numeracion") <> 0 Then cbAño.Items.Add(linea("numeracion"))
            End If
        Next
        cbAño.Text = dt.Rows(dt.Rows.Count - 1).Item(0).ToString
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Try

            If MsgBox("¿Guardar los datos introducidos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ep1.Clear()
                Dim validar As Boolean = True
                If cbTipoIVA.SelectedIndex = -1 Then
                    validar = False
                    ep1.SetError(cbTipoIVA, "Se ha de especificar el tipo de IVA por defecto")
                End If
                If cbRetencion.SelectedIndex = -1 Then
                    validar = False
                    ep1.SetError(cbRetencion, "Se ha de especificar el tipo de retención por defecto")
                End If
                If cbIdioma.SelectedIndex = -1 Then
                    validar = False
                    ep1.SetError(cbIdioma, "Se ha de especifacar un idioma de la lista")
                End If
                If cbOpcion.SelectedIndex = -1 Then
                    validar = False
                    ep1.SetError(cbOpcion, "Se ha de especificar el artículo Opción base")
                End If
                If Not IsNumeric(cbAño.Text) Then
                    validar = False
                    ep1.SetError(cbAño, "Se ha de indicar un año válido")
                Else
                    If numPedido.Text = "" Then numPedido.Text = 0
                    If MA.busquedaMaximos("pedidos", "numPedido") > numPedido.Text Then
                        ep1.SetError(numPedido, "Numero de pedido no válido")
                        validar = False
                    End If
                    If numAlbaran.Text = "" Then numAlbaran.Text = 0
                    If MA.busquedaMaximos("albaranes", "numAlbaran") > numAlbaran.Text Then
                        ep1.SetError(numAlbaran, "Numero de albarán no válido")
                        validar = False
                    End If
                    If numOferta.Text = "" Then numOferta.Text = 0
                    If MA.busquedaMaximos("ofertas", "numOferta") > numOferta.Text Then
                        ep1.SetError(numOferta, "Numero de oferta no válido")
                        validar = False
                    End If
                    If numReparacion.Text = "" Then numReparacion.Text = 0
                    If MA.busquedaMaximos("Reparaciones", "numReparacion") > numReparacion.Text Then
                        ep1.SetError(numReparacion, "Numero de reparación no válido")
                        validar = False
                    End If
                    If numFactura.Text = "" Then numFactura.Text = 0
                    If MA.busquedaMaximos("facturas", "numFactura") > numFactura.Text Then
                        ep1.SetError(numFactura, "Numero de factura no válido")
                        validar = False
                    End If

                    If numSerie.Text = "" Then numSerie.Text = 0
                    If CInt(MA.busquedaMaximos("EquiposProduccion as EQ left join Articulos ON Articulos.idArticulo = EQ.idArticulo Where ConNumSerie = 0 ", "numSerie")) > CInt(numSerie.Text) Then
                        ep1.SetError(numSerie, "Numero de serie no válido")
                        validar = False
                    End If
                    If numSerie2.Text = "" Then numSerie2.Text = 0
                    If numPedidoProv.Text = "" Then numPedidoProv.Text = 0
                    If MA.busquedaMaximos("PedidosProv", "numPedido") > numPedidoProv.Text Then
                        ep1.SetError(numPedidoProv, "Numero de pedido a proveedor no válido")
                        validar = False
                    End If
                    If numProforma.Text = "" Then numProforma.Text = 0
                    If MA.busquedaMaximos("Proformas", "numProforma") > numProforma.Text Then
                        ep1.SetError(numProforma, "Numero de proforma no válido")
                        validar = False
                    End If
                End If
                If EquiposDomesticos.Text = "" Then EquiposDomesticos.Text = 0
                If EquiposIndustriales.Text = "" Then EquiposIndustriales.Text = 0
                If tbDomesticos2.Text = "" Then tbDomesticos2.Text = 0

                If validar Then
                    Dim dtsDI As New DatosDatosIniciales
                    dtsDI.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
                    dtsDI.gDescuento = If(Descuento1.Text = "", 0, CDbl(Descuento1.Text))
                    dtsDI.gDescuento2 = If(Descuento2.Text = "", 0, CDbl(Descuento2.Text))
                    dtsDI.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
                    dtsDI.gidTipoRetencion = cbRetencion.SelectedItem.gidTipoRetencion
                    dtsDI.gPortes = If(cbPortes.Text = "PAGADOS", "P", "D")
                    dtsDI.gidIdioma = cbIdioma.SelectedItem.gidIdioma
                    dtsDI.gidArticuloOpcionBase = cbOpcion.SelectedItem.itemData
                    dtsDI.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
                    dtsDI.gSMTPServidor = SMTPServidor.Text
                    dtsDI.gSMTPPuerto = SMTPPuerto.Text
                    dtsDI.gSMTPUsuario = SMTPUsuario.Text
                    dtsDI.gSMTPPassword = SMTPPassword.Text
                    dtsDI.gSMTPAutenticado = ckAutenticado.Checked
                    dtsDI.gSMTPSSL = ckSSL.Checked
                    dtsDI.gDiasAviso1 = If(IsNumeric(DiasAviso1.Text), CInt(DiasAviso1.Text), 0)
                    dtsDI.gDiasAviso2 = If(IsNumeric(DiasAviso2.Text), CInt(DiasAviso2.Text), 0)
                    dtsDI.gDiasAviso3 = If(IsNumeric(DiasAviso3.Text), CInt(DiasAviso3.Text), 0)
                    DI.actualizar(dtsDI)
                    Dim dtsMA As New DatosMaster
                    dtsMA.gnumeracion = cbAño.Text
                    dtsMA.gnumPedido = CInt(numPedido.Text) - 1
                    dtsMA.gnumAlbaran = CInt(numAlbaran.Text) - 1
                    dtsMA.gnumFactura = CInt(numFactura.Text) - 1
                    dtsMA.gnumSerie = CInt(numSerie.Text) - 1
                    dtsMA.gnumSerie2 = CInt(numSerie2.Text) - 1
                    dtsMA.gnumOferta = CInt(numOferta.Text) - 1
                    dtsMA.gnumReparacion = CInt(numReparacion.Text) - 1
                    dtsMA.gnumProforma = CInt(numProforma.Text) - 1
                    dtsMA.gnumPedidoProv = CInt(numPedidoProv.Text) - 1
                    dtsMA.gDomesticosXDia = CDbl(EquiposDomesticos.Text)
                    dtsMA.gIndustrialesXDia = CDbl(EquiposIndustriales.Text)
                    dtsMA.gDomesticos2XDia = CDbl(tbDomesticos2.Text)
                    dtsMA.gRecambiosXDia = CDbl(tbRecambios.Text)
                    If MA.ExisteNumeracion(dtsMA.gnumeracion) Then
                        MA.actualizar(dtsMA)
                    Else
                        MA.insertar(dtsMA)
                    End If
                    semaforo = False
                    Call IntroducirAños()
                    semaforo = True
                    Call cargarDatosAnuales()
                    Call cargarDatosNoAnuales()
                    If dtsMA.gnumeracion > Now.Year Then
                        MA.CrearFestivos(dtsMA.gnumeracion)
                    End If
                    MsgBox("Datos guardados correctamente")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub bGuardarAnuales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Dim func As New Master

            Dim dt As New DataTable

            Dim dts As New DatosMaster

            Dim validar As Boolean = True

            dts.gnumeracion = cbAño.Text

            dts.gnumPedidoProv = CInt(numPedidoProv.Text) - 1

            dts.gSMTPServidor = SMTPServidor.Text

            dts.gSMTPPuerto = SMTPPuerto.Text

            dts.gSMTPUsuario = SMTPUsuario.Text

            dts.gSMTPPassword = SMTPPassword.Text

            dts.gSMTPAutenticado = ckAutenticado.Checked

            dts.gSMTPSSL = ckSSL.Checked

            dt = func.mostrar(cbAño.Text)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub bNuevoAño_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoAño.Click

        Try

            If cbAño.Text = Now.Year And Now.Month > 7 Then  'Si intentamos crear un nuevo año antes de que acabe el anterior

                MsgBox("Debe escribir en el campo Año el nuevo año que desea crear.")

            Else

                Dim x As Integer

                If cbAño.Text <> "" Then

                    x = (CInt(cbAño.Text) * 10000) + 1

                End If

                'Inicializa los contadores de documentos con el año y 000
                numPedido.Text = x

                numAlbaran.Text = x
                'numFactura.Text = x

                numOferta.Text = x
                'numReparacion.Text = x
                numPedidoProv.Text = x

                numProforma.Text = x

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub


    Private Sub numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAño.KeyPress, numPedido.KeyPress, numOferta.KeyPress, numAlbaran.KeyPress, numFactura.KeyPress, numPedidoProv.KeyPress, numProforma.KeyPress, SMTPPuerto.KeyPress, numSerie.KeyPress, numSerie2.KeyPress, numReparacion.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        KeyAscii = CShort(SoloNumeros(KeyAscii))

        If KeyAscii = 0 Then

            e.Handled = True

        End If

    End Sub


    Private Sub EquiposDomesticos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EquiposDomesticos.KeyPress, EquiposIndustriales.KeyPress, tbDomesticos2.KeyPress, ProntoPago.KeyPress, Descuento2.KeyPress, Descuento1.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        If KeyAscii = Asc(".") Then

            e.KeyChar = ","

        End If

        If InStr(sender.Text, ",") Then

            KeyAscii = CShort(SoloNumeros(KeyAscii))

        Else

            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))

        End If

        If KeyAscii = 0 Then

            e.Handled = True

        End If

    End Sub

    Private Sub cargarDatosAnuales()

        Dim func As New Master

        Dim dt As DataTable

        dt = func.mostrar(cbAño.Text)

        For Each linea In dt.Rows

            If linea("numOferta") Is DBNull.Value Then
            Else
                numOferta.Text = CInt(linea("numOferta")) + 1
            End If
            If linea("numReparacion") Is DBNull.Value Then
            Else
                numReparacion.Text = CInt(linea("numReparacion")) + 1
            End If
            If linea("numPedido") Is DBNull.Value Then
            Else
                numPedido.Text = CInt(linea("numPedido")) + 1
            End If

            If linea("numAlbaran") Is DBNull.Value Then
            Else
                numAlbaran.Text = CInt(linea("numAlbaran")) + 1
            End If

            If linea("numFactura") Is DBNull.Value Then
            Else
                numFactura.Text = CInt(linea("numFactura")) + 1
            End If

            If linea("numSerie") Is DBNull.Value Then
            Else
                numSerie.Text = CInt(linea("numSerie")) + 1
            End If

            If linea("numSerie2") Is DBNull.Value Then
            Else
                numSerie2.Text = CInt(linea("numSerie2")) + 1
            End If

            If linea("numProforma") Is DBNull.Value Then
            Else
                numProforma.Text = CInt(linea("numProforma")) + 1
            End If

            If linea("numPedidoProv") Is DBNull.Value Then
            Else
                numPedidoProv.Text = CInt(linea("numPedidoProv")) + 1
            End If

            EquiposDomesticos.Text = If(linea("DomesticosXDia") Is DBNull.Value, 0, linea("DomesticosXDia"))

            EquiposIndustriales.Text = If(linea("IndustrialesXDia") Is DBNull.Value, 0, linea("IndustrialesXDia"))

            tbDomesticos2.Text = If(linea("Domesticos2XDia") Is DBNull.Value, 0, linea("Domesticos2XDia"))

            tbRecambios.Text = If(linea("RecambiosXDia") Is DBNull.Value, 0, linea("RecambiosXDia"))

        Next

    End Sub


    Private Sub cargarDatosNoAnuales()
        Dim dts As DatosDatosIniciales = DI.Mostrar
        ProntoPago.Text = dts.gProntoPago
        Descuento1.Text = dts.gDescuento
        Descuento2.Text = dts.gDescuento2
        cbTipoIVA.Text = dts.gNombreIVA
        cbRetencion.Text = dts.gNombreRetencion
        cbPortes.Text = dts.gNombrePortes
        cbIdioma.Text = dts.gIdioma
        cbOpcion.Text = dts.gArticuloOpcionBase
        cbValorado.Text = dts.gTipoValorado
        SMTPServidor.Text = dts.gSMTPServidor
        SMTPPuerto.Text = dts.gSMTPPuerto
        SMTPUsuario.Text = dts.gSMTPUsuario
        SMTPPassword.Text = dts.gSMTPPassword
        ckAutenticado.Checked = dts.gSMTPAutenticado
        ckSSL.Checked = dts.gSMTPSSL
        DiasAviso1.Text = dts.gDiasAviso1
        DiasAviso2.Text = dts.gDiasAviso2
        DiasAviso3.Text = dts.gDiasAviso3
    End Sub

    Private Sub cbAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAño.SelectedIndexChanged
        If semaforo Then Call cargarDatosAnuales()
    End Sub

    Private Sub bPrueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPrueba.Click
        'Generar un mensaje de prueba
        Try
            If SMTPServidor.Text <> "" And SMTPPuerto.Text <> "" And (ckAutenticado.Checked = False Or (ckAutenticado.Checked = True And (SMTPUsuario.Text <> "" And SMTPPassword.Text <> ""))) Then
                Dim Destinatario As String = InputBox("Introducir destinstario para la prueba.")
                If correo("Mensaje de prueba", "Mensaje de prueba.", "desarrollo@movalnet.es", Destinatario, "") Then
                    MsgBox("Se ha enviado el mensaje de prueba. Comprueba que se recibe correctamente en la dirección indicada.")
                End If
            Else
                MsgBox("Introducir todos los datos SMTP.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Function correo(ByVal Asunto As String, ByVal Texto As String, ByVal Remitente As String, ByVal Destinatario As String, ByVal Adjunto As String) As Boolean
        Try
            If InStr(Destinatario, "@") = 0 Then  'Mínima comprobación del correo: que tenga @ y "."
                MsgBox("Dirección de e-mail incorrecta")
                Return False
            Else
                If InStr(Destinatario, ".") = 0 Then
                    MsgBox("Dirección de e-mail incorrecta")
                    Return False
                Else
                    Dim coma As Integer
                    Dim DestinatarioAdd As String
                    Dim func As New Master
                    Dim mm As New Net.Mail.MailMessage

                    Texto = Texto & vbCrLf & vbCrLf & vbCrLf & "Este mensaje se ha generado automáticamente desde la aplicación ERP_SUGAR."

                    mm.IsBodyHtml = False
                    mm.Body = Texto
                    mm.Subject = Asunto
                    mm.From = New Net.Mail.MailAddress(SMTPUsuario.Text)
                    While Len(Destinatario) > 0
                        coma = InStr(Destinatario, ";")
                        If coma = 0 Then
                            mm.To.Add(Trim(Destinatario))
                            Destinatario = ""
                        Else
                            DestinatarioAdd = Microsoft.VisualBasic.Left(Destinatario, coma - 1)
                            mm.To.Add(Trim(DestinatarioAdd))
                            Destinatario = Microsoft.VisualBasic.Right(Destinatario, Len(Destinatario) - coma)
                        End If

                    End While
                    If SMTPPuerto.Text = "" Then SMTPPuerto.Text = 0
                    Dim client As New Net.Mail.SmtpClient(SMTPServidor.Text, SMTPPuerto.Text)
                    client.UseDefaultCredentials = Not ckAutenticado.Checked
                    client.Credentials = New Net.NetworkCredential(SMTPUsuario.Text, SMTPPassword.Text)
                    client.EnableSsl = ckSSL.Checked
                    If Adjunto <> "" Then
                        mm.Attachments.Add(New Net.Mail.Attachment(Adjunto))
                    End If
                    client.Send(mm)
                    Return True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


    Private Sub introducirTiposIVA()
        Dim funcTI As New FuncionesTiposIVA
        Try
            cbTipoIVA.Items.Clear()
            Dim lista As List(Of DatosTipoIVA) = funcTI.Mostrar(True)
            Dim dts As DatosTipoIVA
            For Each dts In lista
                cbTipoIVA.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirTiposRetencion()
        Dim funcTR As New FuncionesTiposRetencion
        Try
            cbRetencion.Items.Clear()
            Dim lista As List(Of DatosTipoRetencion) = funcTR.Mostrar(True)
            Dim dts As DatosTipoRetencion
            For Each dts In lista
                cbRetencion.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirIdiomas()
        Dim funcID As New funcionesIdiomas
        Try
            cbIdioma.Items.Clear()
            Dim lista As List(Of datosIdioma) = funcID.mostrar()
            For Each dts As datosIdioma In lista
                cbIdioma.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirOpciones()
        Dim funcAR As New FuncionesArticulos
        Try
            cbOpcion.Items.Clear()
            Dim lista As List(Of IDComboBox3) = funcAR.Listar("OPCION")
            For Each item As IDComboBox3 In lista
                cbOpcion.Items.Add(New IDComboBox(item.Name1, item.ItemData))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirTiposValorado()
        Try
            cbValorado.Items.Clear()
            Dim funcVA As New FuncionesTiposValorado
            Dim lista As List(Of DatosTipoValorado) = funcVA.Mostrar()
            Dim dts As DatosTipoValorado
            For Each dts In lista
                cbValorado.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DiasAviso1.KeyPress, DiasAviso2.KeyPress, DiasAviso3.KeyPress
        'Admite números negativos 
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If Microsoft.VisualBasic.Left(sender.text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If sender.Text = "" Or sender.Text = "0" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                KeyAscii = CShort(SoloNumeros(KeyAscii))
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub BSubir_Click(sender As Object, e As EventArgs) Handles BSubir.Click, BBajar.Click

        If IsNumeric(TxPorcentaje.Text) Then

            If MsgBox("¿Esta seguro que quiere " & LCase(sender.text) & " el P.V.P de todos los artículo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If DI.cambioMasivoPrecios(sender.name, TxPorcentaje.Text) Then

                    If sender.text = "SUBIR" Then

                        MsgBox("Los precios se han actualizado con una subida del  " & TxPorcentaje.Text & "%", MsgBoxStyle.Information)

                    Else

                        MsgBox("Los precios se han actualizado con una bajada del  " & TxPorcentaje.Text & "%", MsgBoxStyle.Information)

                    End If

                    TxPorcentaje.Clear()

                End If

            End If

        Else

            MsgBox("El datos introducido no es válidio.", MsgBoxStyle.Information)

            TxPorcentaje.Clear()

        End If

    End Sub

End Class