Public Class GestionMensaje

    Private funcCO As New funcionesComunicaciones
    Private funcCL As New funcionesclientes
    Private funcCT As New funcionesContactos
    Private funcUB As New funcionesUbicaciones
    Private funcPE As New FuncionesPersonal
    Private funcES As New FuncionesEstados
    Private funcPR As New funcionesProveedores
    Private funcRE As New funcionesReferencias
    Private funcFI As New funcionesFicheros
    Private funcAP As New FuncionesAlbaranesProv
    Private funcAL As New FuncionesAlbaranes
    Private funcFA As New FuncionesFacturas
    Private funcFP As New FuncionesFacturasProv
    Private funcPC As New FuncionesPedidos
    Private funcPP As New FuncionesPedidosProv
    Private funcREP As New FuncionesReparaciones
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcEH As New FuncionesEquiposHistorico
    Private funcOF As New FuncionesOfertas
    Private funcPF As New FuncionesProformas
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private ep3 As New ErrorProvider 'Para avisar de que el documento no existe
    Private ep4 As New ErrorProvider 'documento correcto
    Private iidComunicacion As Integer
    Private iidComunicacionPadre As Integer
    Private dtsM As datosComunicacion
    Private dtsFM As New datosFichero
    Private dtsRM As New datosReferencia
    Private dtsF As New datosFichero
    Private dtsR As New datosReferencia
    Private dtsRE As datosComunicacion
    Private vSoloLectura As Boolean
    Private indice As Integer
    Private Cambios As Boolean
    Private Temporizador As New Timer
    Private semaforo As Boolean
    Private EstadoRecibido As DatosEstado
    Private EstadoRespondido As DatosEstado
    Private EstadoArchivado As DatosEstado

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pidComunicacion() As Integer
        Get
            Return iidComunicacionPadre
        End Get
        Set(ByVal value As Integer)
            iidComunicacionPadre = value
        End Set
    End Property

    Private Sub GestionMensaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        'Permisos
        Call Inicializar()
        Call Limpiar()
        Call IntroducirDocumentos()
        Call CargarIconos()
        Call introducirEstados()
        If iidComunicacionPadre > 0 Then
            Call CargarMensajePadre()
            Call CargarRespuestas()
        End If
        semaforo = True
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Cambios Then
            If indice = -1 Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
        If Not e.Cancel Then Temporizador.Stop()
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub Inicializar()
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        ep3.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep3.Icon = My.Resources.eventlogWarn
        ep4.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep4.Icon = My.Resources.accept1
        dtpFechaHora.Format = DateTimePickerFormat.Custom
        dtpFechaHora.CustomFormat = "dd/MM/yyyy   HH:mm"
        'EstadoArchivado = funcES.EstadoTraspasado("COMUNICACION")
        'EstadoRecibido = funcES.EstadoEspera("COMUNICACION")
        'EstadoRespondido = funcES.EstadoEnCurso("COMUNICACION")
        Temporizador.Interval = 30000
        AddHandler Temporizador.Tick, AddressOf ActualizarHora
        Temporizador.Start()
    End Sub

    Private Sub Limpiar()
        semaforo = False
        indice = -1
        Respuesta.Text = ""
        cbDocumento.Text = ""
        cbDocumento.SelectedIndex = -1
        Referencia.Text = ""
        dtpFechaHora.Value = Now
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        dtsF = New datosFichero
        dtsR = New datosReferencia
        lvComunicaciones.SelectedItems.Clear()
        fichero.Text = ""
        ep1.Clear()
        ep2.Clear()
        ep3.Clear()
        ep4.Clear()
        semaforo = True
    End Sub

    Private Sub IntroducirDocumentos()
        cbDocumento.Items.Clear()
        cbDocumento.Text = ""
        cbDocumento.Items.Add("PEDIDO CLIENTE")
        cbDocumento.Items.Add("PEDIDO PROVEEDOR")
        cbDocumento.Items.Add("ALBARÁN DE PROVEEDOR")
        cbDocumento.Items.Add("ALBARÁN A PROVEEDOR")
        cbDocumento.Items.Add("ALBARÁN CLIENTE")
        cbDocumento.Items.Add("FACTURA CLIENTE")
        cbDocumento.Items.Add("FACTURA PROVEEDOR")
        cbDocumento.Items.Add("OFERTA CLIENTE")
        cbDocumento.Items.Add("PROFORMA CLIENTE")
        cbDocumento.Items.Add("REPARACIÓN")
        cbDocumento.Items.Add("N/S EQUIPO")
    End Sub

    Private Sub CargarIconos()
        Dim listaIconos As New ImageList
        listaIconos.Images.Add(My.Resources.Resources.AttachmentHS)
        lvComunicaciones.SmallImageList = listaIconos
    End Sub

    'Private Sub introducirPersonal()
    '    cbContacto.Items.Clear()
    '    Dim lista As List(Of IDComboBox) = funcPE.Listar
    '    For Each item As IDComboBox In lista
    '        cbContacto.Items.Add(item)
    '    Next
    'End Sub

    Private Sub ActualizarHora()
        If lvComunicaciones.SelectedItems.Count = 0 Then
            dtpFechaHora.Value = Now
        End If

    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("COMUNICACION")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
        EstadoArchivado = funcES.EstadoTraspasado("COMUNICACION")
        EstadoRecibido = funcES.EstadoEspera("COMUNICACION")
        EstadoRespondido = funcES.EstadoEnCurso("COMUNICACION")
    End Sub


#End Region

#Region "CARGAR DATOS"

    Private Sub CargarMensajePadre()
        semaforo = False
        dtsM = funcCO.mostrar1(iidComunicacionPadre)
        Dim Titulo As String = "MENSAJE "
        If dtsM.gidCliente > 0 Then
            Titulo = Titulo & "CLIENTE"
            Nombre.Text = dtsM.gCliente
        ElseIf dtsM.gidProveedor > 0 Then
            Titulo = Titulo & "PROVEEDOR"
            Nombre.Text = dtsM.gProveedor
        End If
        Titulo = Titulo & " - " & Format(dtsM.gFechaHora, "dd/MM/yyyy HH:mm")
        gbMensaje.Text = Titulo
        Direccion.Text = dtsM.gDireccion
        ContactoM.Text = dtsM.gContacto
        Asunto.Text = dtsM.gComentario
        'Estado.Text = dtsM.gEstado
        cbEstado.Text = dtsM.gEstado
        Select Case dtsM.gidEstado
            Case EstadoArchivado.gidEstado
                cbEstado.ForeColor = Color.DarkGray
            Case EstadoRespondido.gidEstado
                cbEstado.ForeColor = Color.Orange
            Case Else
                cbEstado.ForeColor = SystemColors.WindowText
        End Select
        ckDestacado.Checked = dtsM.gDestacado
        If ckDestacado.Checked Then
            gbMensaje.ForeColor = Color.Red
        Else
            gbMensaje.ForeColor = SystemColors.WindowText
        End If
        dtsFM = funcFI.mostrar(iidComunicacionPadre).FirstOrDefault
        If dtsFM Is Nothing Then dtsFM = New datosFichero
        dtsRM = funcRE.mostrar(iidComunicacionPadre).FirstOrDefault
        If dtsRM Is Nothing Then dtsRM = New datosReferencia
        DocumentoM.Text = dtsRM.gDocumento
        ReferenciaM.Text = dtsRM.gReferencia
        FicheroM.Text = dtsFM.gFichero
        Call CargarContactos()
        semaforo = True
    End Sub

    Private Sub CargarContactos()
        cbContacto.Text = ""
        cbContacto.Items.Clear()
        Dim lista As New List(Of datosContacto)
        If dtsM.gidCliente > 0 Then
            lista = funcCT.mostrarCli(dtsM.gidCliente)
        ElseIf dtsM.gidProveedor > 0 Then

            lista = funcCT.mostrarProv(dtsM.gidProveedor)
        End If
        For Each dts As datosContacto In lista
            cbContacto.Items.Add(New IDComboBox(dts.gnombre + " " + dts.gapellidos, dts.gidContacto))
        Next
        If cbContacto.SelectedIndex = -1 Then
            If lista.Count = 1 Then
                cbContacto.SelectedIndex = 0
            Else
                cbContacto.Text = ""
            End If
        End If

    End Sub

#Region "LISTVIEW"""
    Private Sub CargarRespuestas()
        lvComunicaciones.Items.Clear()
        Dim lista As List(Of datosComunicacion) = funcCO.mostrarConceptos(iidComunicacionPadre)
        For Each dts As datosComunicacion In lista
            dtsF = funcFI.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsF Is Nothing Then dtsF = New datosFichero
            dtsR = funcRE.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsR Is Nothing Then dtsR = New datosReferencia
            Call NuevaLineaLV(dts)
        Next
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As datosComunicacion)
        With lvComunicaciones.Items.Add(" ")
            .SubItems.Add(dts.gidComunicacion)
            .SubItems.Add(Format(dts.gFechaHora, "dd/MM/yyyy HH:mm"))
            .SubItems.Add(dts.gContacto)
            .SubItems.Add(dts.gCreador)
            .SubItems.Add(dts.gComentario)
            If (Not dtsF Is Nothing AndAlso dtsF.gidFichero > 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia > 0) Then
                .ImageIndex = 0
            Else
                .ImageIndex = -1
            End If
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As datosComunicacion)
        With lvComunicaciones.Items(indice)
            .SubItems(2).Text = Format(dts.gFechaHora, "dd/MM/yyyy HH:mm")
            .SubItems(3).Text = dts.gContacto
            .SubItems(4).Text = dts.gCreador
            .SubItems(5).Text = dts.gComentario

            If (Not dtsF Is Nothing AndAlso dtsF.gidFichero > 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia > 0) Then
                .ImageIndex = 0
            Else
                .ImageIndex = -1
            End If
        End With
    End Sub

#End Region
    
#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub PresentarRespuesta()
        If indice <> -1 Then
            iidComunicacion = lvComunicaciones.Items(indice).SubItems(1).Text
            dtsRE = funcCO.mostrar1(iidComunicacion)
            Respuesta.Text = dtsRE.gComentario

            dtsF = funcFI.mostrar(iidComunicacion).FirstOrDefault
            If dtsF Is Nothing Then dtsF = New datosFichero
            dtsR = funcRE.mostrar(iidComunicacion).FirstOrDefault
            If dtsR Is Nothing Then dtsR = New datosReferencia
            cbDocumento.Text = dtsR.gDocumento
            Referencia.Text = dtsR.gReferencia
            fichero.Text = dtsF.gFichero
        End If
    End Sub

    Private Sub VerCliente(ByVal modo As String)

        Dim GG As New GestionClientes
        GG.SoloLectura = vSoloLectura
        GG.pidCliente = dtsM.gidCliente

        GG.ShowDialog()
        dtsM.gCliente = funcCL.campoCliente(dtsM.gidCliente)
        Nombre.Text = dtsM.gCliente

    End Sub

    Private Sub VerProveedor(ByVal modo As String)

        Dim GG As New GestionProveedores
        GG.SoloLectura = vSoloLectura
        GG.pidProveedor = dtsM.gidProveedor
        GG.ShowDialog()
        dtsM.gProveedor = funcPR.campoProveedor(dtsM.gidProveedor)
        Nombre.Text = dtsM.gProveedor
    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If cbEstado.SelectedItem.gidestado <> EstadoArchivado.gidEstado Then
            Call Guardar()
        Else
            MsgBox("Mensaje archivado, no modificable.")
        End If


    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoComunicaciones
        GG.verInforme(" CO.idComunicacion = " & iidComunicacionPadre, "", True)
        GG.ShowDialog()
    End Sub

    Private Function Guardar() As Boolean

        Dim validar As Boolean = True
        If Respuesta.Text = "" Then
            ep1.SetError(Respuesta, "Se ha de escribir una respuesta")
            validar = False
        End If
        If validar Then
            If dtsRE Is Nothing Then dtsRE = New datosComunicacion
            dtsRE.gidComunicacionPadre = dtsM.gidComunicacion
            dtsRE.gComentario = Respuesta.Text
            dtsRE.gidDestinatario = dtsM.gidDestinatario
            dtsRE.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
            dtsRE.gContacto = cbContacto.Text
            dtsRE.gFechaHora = dtpFechaHora.Value
            If lvComunicaciones.SelectedItems.Count > 0 Then
                indice = lvComunicaciones.SelectedIndices(0)
                dtsRE.gidComunicacion = lvComunicaciones.Items(indice).SubItems(1).Text
                funcCO.actualizar(dtsRE)
                funcRE.borrarComunicacion(dtsRE.gidComunicacion)
                funcFI.borrarComunicacion(dtsRE.gidComunicacion)
            Else
                dtsRE.gidComunicacion = funcCO.insertar(dtsRE)
            End If
            If Referencia.Text <> "" Then
                dtsR = New datosReferencia
                dtsR.gReferencia = Referencia.Text
                dtsR.gDocumento = cbDocumento.Text
                dtsR.gidComunicacion = dtsRE.gidComunicacion
                dtsR.gidReferencia = funcRE.insertar(dtsR)
            End If
            If fichero.Text <> "" And Not dtsF Is Nothing Then
                dtsF.gidComunicacion = dtsRE.gidComunicacion
                dtsF.gidFichero = funcFI.insertar(dtsF)
            End If
            If lvComunicaciones.SelectedItems.Count > 0 Then
                Call ActualizarLineaLV(dtsRE)
            Else
                If dtsRE.gidComunicacion > 0 And lvComunicaciones.Items.Count = 0 Then
                    Call CambiarEstadoPadreRespondido()
                    Call PantallaGeneral.CargarComunicaciones()
                End If
                Call NuevaLineaLV(dtsRE)
                'If dtsM.gidDestinatario > 0 Then
                '    Dim Asunto As String = If(dtsM.gComentario.Length > 50, Microsoft.VisualBasic.Left(dtsM.gComentario, 50) & "...", dtsM.gComentario)
                '    correo("Respuesta: " & Asunto, dtsRE.gComentario, Inicio.vIdUsuario, dtsRE.gidDestinatario, "")
                'End If
            End If
            Call Limpiar()
        End If
        Return validar
    End Function

    Private Sub CambiarEstadoPadreRespondido()
        If iidComunicacionPadre > 0 Then
            funcCO.CambiarEstado(iidComunicacionPadre, EstadoRespondido.gidEstado)
            cbEstado.Text = EstadoRespondido.gEstado
            cbEstado.ForeColor = Color.Orange
        End If
    End Sub

    Private Sub CambiarEstadoPadreRecibido()
        If iidComunicacionPadre > 0 Then
            funcCO.CambiarEstado(iidComunicacionPadre, EstadoRecibido.gidEstado)
            cbEstado.Text = EstadoRecibido.gEstado
            cbEstado.ForeColor = SystemColors.WindowText
        End If
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call Limpiar()
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvComunicaciones.SelectedItems.Count > 0 Then
            indice = lvComunicaciones.SelectedIndices(0)
            Dim iidComunicacion As Integer = lvComunicaciones.Items(indice).SubItems(1).Text
            If MsgBox("¿Borrar la respuesta seleccionada?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcFI.borrarComunicacion(iidComunicacion)
                funcRE.borrarComunicacion(iidComunicacion)
                funcCO.borrarConceptos(iidComunicacion)
                funcCO.borrar(iidComunicacion)
                lvComunicaciones.Items.RemoveAt(indice)
                If lvComunicaciones.Items.Count = 0 Then
                    Call CambiarEstadoPadreRecibido()
                End If
                Call Limpiar()
            End If
        End If
    End Sub

    Private Sub bFichero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bFichero.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        If dtsF Is Nothing Then dtsF = New datosFichero
        Dim texto As String = ofd.FileName
        If InStr(texto, "\") <> 0 Then
            dtsF.gFichero = Microsoft.VisualBasic.Right(texto, Len(texto) - InStrRev(texto, "\"))
            dtsF.gRuta = Microsoft.VisualBasic.Left(texto, InStrRev(texto, "\"))
        End If
        fichero.Text = dtsF.gFichero
    End Sub

    Private Sub bVerDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerDocumento.Click
        If Referencia.Text <> "" Then
            Call AbrirDocumento(cbDocumento.Text, Referencia.Text)
        End If
    End Sub

    Private Sub bVerDocumentoM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerDocumentoM.Click
        If ReferenciaM.Text <> "" Then
            Call AbrirDocumento(DocumentoM.Text, ReferenciaM.Text)
        End If
    End Sub

    Private Sub bBuscarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarDocumento.Click
        Dim ReferenciaNumerica As Integer = If(IsNumeric(Referencia.Text), CLng(Referencia.Text), 0)
        Select Case cbDocumento.Text
            Case "PEDIDO CLIENTE"
                Dim GG As New busquedaPedidos
                GG.SoloLectura = vSoloLectura
                GG.pnumPedido = ReferenciaNumerica
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumPedido
            Case "PEDIDO PROVEEDOR"
                Dim GG As New BusquedaPedidoProveedor
                GG.SoloLectura = vSoloLectura
                GG.pnumPedido = ReferenciaNumerica
                If dtsM.gidProveedor > 0 Then GG.pidProveedor = dtsM.gidProveedor
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumPedido
            Case "ALBARÁN A PROVEEDOR"
                Dim GG As New busquedaAlbaranesAProv
                GG.SoloLectura = vSoloLectura
                GG.pnumAlbaran = ReferenciaNumerica
                If dtsM.gidProveedor > 0 Then GG.pidProveedor = dtsM.gidProveedor
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran
            Case "ALBARÁN CLIENTE"
                Dim GG As New busquedaAlbaranes
                GG.SoloLectura = vSoloLectura
                GG.pnumAlbaran = ReferenciaNumerica
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran
            Case "FACTURA CLIENTE"
                Dim GG As New busquedaFacturas
                GG.SoloLectura = vSoloLectura
                GG.pnumFactura = ReferenciaNumerica
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumFactura
            Case "OFERTA CLIENTE"
                Dim GG As New busquedaOfertas
                GG.SoloLectura = vSoloLectura
                GG.pnumOferta = ReferenciaNumerica
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumOferta

            Case "PROFORMA CLIENTE"
                Dim GG As New busquedaProformas
                GG.SoloLectura = vSoloLectura
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pnumProforma = ReferenciaNumerica
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumProforma
            Case "REPARACIÓN"
                Dim GG As New busquedaReparaciones
                GG.SoloLectura = vSoloLectura
                GG.pnumReparacion = ReferenciaNumerica
                If dtsM.gidCliente > 0 Then GG.pidCliente = dtsM.gidCliente
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumReparacion
            Case "N/S EQUIPO"
                Dim GG As New BusquedaEquipos
                GG.SoloLectura = vSoloLectura
                GG.pNumSerie = Referencia.Text
                GG.ShowDialog()
                Referencia.Text = GG.pNumSerie
            Case "ALBARÁN DE PROVEEDOR"
                Dim GG As New busquedaAlbaranesDeProv
                GG.SoloLectura = vSoloLectura
                GG.pnumAlbaran = Referencia.Text
                If dtsM.gidProveedor > 0 Then GG.pidProveedor = dtsM.gidProveedor
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran

            Case "FACTURA PROVEEDOR"
                Dim GG As New busquedaFacturasProv
                GG.SoloLectura = vSoloLectura
                GG.pnumFactura = Referencia.Text
                If dtsM.gidProveedor > 0 Then GG.pidProveedor = dtsM.gidProveedor
                GG.ShowDialog()
                Referencia.Text = GG.pnumFactura


        End Select
    End Sub

    Private Sub AbrirDocumento(ByVal Documento As String, ByVal ValorReferencia As String)
        If IsNumeric(ValorReferencia) Then
            Select Case Documento
                Case "PEDIDO CLIENTE"
                    Dim GG As New GestionPedido
                    GG.SoloLectura = vSoloLectura
                    GG.pnumPedido = ValorReferencia
                    GG.ShowDialog()
                Case "PEDIDO PROVEEDOR"
                    Dim GG As New GestionPedidoProveedor
                    GG.SoloLectura = vSoloLectura
                    GG.pNumPedido = ValorReferencia
                    GG.ShowDialog()
                Case "ALBARÁN A PROVEEDOR"
                    Dim GG As New GestionAlbaranAProv
                    GG.SoloLectura = vSoloLectura
                    GG.pnumAlbaran = ValorReferencia
                    GG.ShowDialog()
                Case "ALBARÁN CLIENTE"
                    Dim GG As New GestionAlbaran
                    GG.SoloLectura = vSoloLectura
                    GG.pnumAlbaran = ValorReferencia
                    GG.ShowDialog()
                Case "FACTURA CLIENTE"
                    Dim GG As New GestionFactura1
                    GG.SoloLectura = vSoloLectura
                    GG.pnumFactura = ValorReferencia
                    GG.ShowDialog()
                Case "OFERTA CLIENTE"
                    Dim GG As New GestionOferta
                    GG.SoloLectura = vSoloLectura
                    GG.pnumOferta = ValorReferencia
                    GG.ShowDialog()

                Case "PROFORMA CLIENTE"
                    Dim GG As New GestionProforma
                    GG.SoloLectura = vSoloLectura
                    GG.pnumProforma = ValorReferencia
                    GG.ShowDialog()

                Case "REPARACIÓN"
                    Dim GG As New GestionReparacion
                    GG.SoloLectura = vSoloLectura
                    GG.pnumReparacion = ValorReferencia
                    GG.ShowDialog()

                Case "N/S EQUIPO"
                    Dim GG As New BusquedaEquipos
                    GG.SoloLectura = vSoloLectura
                    GG.pNumSerie = ValorReferencia
                    GG.ShowDialog()
                Case "ALBARÁN DE PROVEEDOR"
                    Call VerAlbaranProveedor(ValorReferencia)

                Case "FACTURA PROVEEDOR"
                    Call VerFacturaProv(ValorReferencia)

            End Select
        Else
            Select Case cbDocumento.Text
                Case "ALBARÁN DE PROVEEDOR"
                    Call VerAlbaranProveedor(ValorReferencia)
                Case "FACTURA PROVEEDOR"
                    Call VerFacturaProv(ValorReferencia)
            End Select
        End If

    End Sub

    Private Sub VerAlbaranProveedor(ByVal ValorReferencia As String)
        If Not dtsM Is Nothing AndAlso dtsM.gidProveedor > 0 Then
            Dim iidAlbaran As Integer = funcAP.idAlbaran(ValorReferencia, dtsM.gidProveedor)
            If iidAlbaran > 0 Then
                Dim GG As New GestionAlbaranDeProv
                GG.SoloLectura = vSoloLectura
                GG.pidAlbaran = iidAlbaran
                GG.ShowDialog()
            End If
        End If
    End Sub

    Private Sub VerFacturaProv(ByVal ValorReferencia As String)
        If Not dtsM Is Nothing AndAlso dtsM.gidProveedor > 0 Then
            Dim iidFactura As Integer = funcFP.idFactura(ValorReferencia, dtsM.gidProveedor)
            If iidFactura > 0 Then
                Dim GG As New GestionFacturaProv
                GG.SoloLectura = vSoloLectura
                GG.pidFactura = iidFactura
                GG.ShowDialog()
            End If
        End If

    End Sub

    Private Sub bVerFichero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerFichero.Click
        If fichero.Text <> "" Then
            Process.Start(dtsF.gRuta & dtsF.gFichero)
        End If
    End Sub

    Private Sub bVerFicheroM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerFicheroM.Click
        If FicheroM.Text <> "" Then
            Process.Start(dtsFM.gRuta & dtsFM.gFichero)
        End If
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If Not dtsM Is Nothing Then
            If dtsM.gidCliente > 0 Then
                Call VerCliente(sender.name)
            ElseIf dtsM.gidProveedor > 0 Then
                Call VerProveedor(sender.name)
            End If
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub Referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Referencia.TextChanged, cbDocumento.SelectedIndexChanged
        If semaforo AndAlso (cbDocumento.SelectedIndex <> -1 And Referencia.Text <> "") Then
            ep3.Clear()
            ep4.Clear()
            If cbDocumento.SelectedIndex = -1 Then
                ep2.SetError(cbDocumento, "No ha seleccionado el tipo de documento")
            Else
                Dim iidCliente As Integer = dtsM.gidCliente
                Dim iidProveedor As Integer = dtsM.gidProveedor
                If IsNumeric(Referencia.Text) AndAlso Referencia.Text > 0 Then
                    Select Case cbDocumento.Text
                        Case "PEDIDO CLIENTE"
                            Dim iidClienteDoc As Integer = funcPC.ExisteNumPedido(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Pedido existente")
                            Else
                                ep3.SetError(Referencia, "no existe un pedido con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If
                        Case "PEDIDO PROVEEDOR"
                            Dim iidProveedorDoc As Integer = funcPP.ExisteNumPedidoProv(Referencia.Text, iidProveedor)
                            If iidProveedorDoc > 0 Then
                                ep4.SetError(Referencia, "Pedido existente")
                            Else
                                ep3.SetError(Referencia, "no existe un pedido con este número" & If(iidProveedor = 0, "", " para el proveedor seleccionado"))
                            End If
                        Case "ALBARÁN A PROVEEDOR"
                            Dim iidProveedorDoc As Integer = funcAL.ExistenumAlbaranProv(Referencia.Text, iidProveedor)
                            If iidProveedorDoc > 0 Then
                                ep4.SetError(Referencia, "Albarán existente")
                            Else
                                ep3.SetError(Referencia, "no existe un albarán con este número" & If(iidProveedor = 0, "", " para el proveedor seleccionado"))
                            End If

                        Case "ALBARÁN CLIENTE"
                            Dim iidClienteDoc As Integer = funcAL.ExistenumAlbaranCli(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Albarán existente")
                            Else
                                ep3.SetError(Referencia, "no existe un albarán con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If
                        Case "FACTURA CLIENTE"
                            Dim iidClienteDoc As Integer = funcFA.ExisteNumFactura(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Factura existente")
                            Else
                                ep3.SetError(Referencia, "no existe una factura con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "OFERTA CLIENTE"
                            Dim iidClienteDoc As Integer = funcOF.ExisteNumOferta(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Oferta existente")
                            Else
                                ep3.SetError(Referencia, "no existe una oferta con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "PROFORMA CLIENTE"
                            Dim iidClienteDoc As Integer = funcPF.ExisteNumProforma(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Proforma existente")
                            Else
                                ep3.SetError(Referencia, "no existe una proforma con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If


                        Case "REPARACIÓN"
                            Dim iidClienteDoc As Integer = funcREP.ExisteNumReparacion(Referencia.Text, iidCliente)
                            If iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Reparación existente")
                            Else
                                ep3.SetError(Referencia, "no existe una reparación con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "N/S EQUIPO"
                            If funcEQ.ExistenumSerie(Referencia.Text, 0) Then
                                ep4.SetError(Referencia, "Equipo existente")
                            ElseIf funcEH.idEquipoHistorico(Referencia.Text) > 0 Then
                                ep4.SetError(Referencia, "Equipo histórico existente")
                            Else
                                ep3.SetError(Referencia, "no existe un equipo con este número de serie")
                            End If

                        Case "ALBARÁN DE PROVEEDOR"
                            Call CambiosAlbaranProveedor()
                        Case "FACTURA PROVEEDOR"
                            Call CambiosFacturaProv()
                    End Select
                Else
                    Select Case cbDocumento.Text
                        Case "ALBARÁN DE PROVEEDOR"
                            Call CambiosAlbaranProveedor()
                        Case "FACTURA PROVEEDOR"
                            Call CambiosFacturaProv()

                    End Select
                End If


            End If

        End If
    End Sub

    Private Sub CambiosAlbaranProveedor()
        Dim iidAlbaran As Integer = funcAP.idAlbaran(Referencia.Text, dtsM.gidProveedor)
        If iidAlbaran = 0 Then
            ep3.SetError(Referencia, "no existe un albarán con este número de este proveedor")
        Else
            ep4.SetError(Referencia, "Albarán existente")
        End If
    End Sub

    Private Sub CambiosFacturaProv()
        Dim iidFactura As Integer = funcFP.idFactura(Referencia.Text, dtsM.gidProveedor)
        If iidFactura = 0 Then
            ep3.SetError(Referencia, "no existe una factura con este número de este proveedor")
        Else
            ep4.SetError(Referencia, "Factura existente")
        End If
    End Sub

    Private Sub lvComunicaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvComunicaciones.Click, lvComunicaciones.SelectedIndexChanged
        If lvComunicaciones.SelectedItems.Count > 0 Then
            indice = lvComunicaciones.SelectedIndices(0)
            Call PresentarRespuesta()
        End If
    End Sub

    Private Sub cbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged
        If semaforo AndAlso cbEstado.SelectedIndex <> -1 Then
            Select Case cbEstado.SelectedItem.gidEstado
                Case EstadoArchivado.gidEstado
                    cbEstado.ForeColor = Color.DarkGray
                Case EstadoRespondido.gidEstado
                    cbEstado.ForeColor = Color.Orange
                Case Else
                    cbEstado.ForeColor = SystemColors.WindowText
            End Select
            If Not dtsM Is Nothing AndAlso cbEstado.SelectedItem.gidEstado <> dtsM.gidEstado Then
                funcCO.CambiarEstado(iidComunicacionPadre, cbEstado.SelectedItem.gidEstado)
                dtsM.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsM.gEstado = cbEstado.SelectedItem.gEstado
            End If
        End If
    End Sub

    Private Sub ckDestacado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDestacado.CheckedChanged
        If semaforo Then
            If dtsM.gDestacado <> ckDestacado.Checked Then
                funcCO.CambiarDestacado(iidComunicacionPadre, ckDestacado.Checked)
                Call PantallaGeneral.CargarComunicaciones()
                dtsM.gDestacado = ckDestacado.Checked
            End If
            If ckDestacado.Checked Then
                gbMensaje.ForeColor = Color.Red
            Else
                gbMensaje.ForeColor = SystemColors.WindowText
            End If
        End If
    End Sub

#End Region

End Class