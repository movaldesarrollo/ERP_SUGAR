Public Class MiniCRM

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

    Private iidCliente As Integer
    Private iidProveedor As Integer
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private ep3 As New ErrorProvider 'Para avisar de que el documento no existe
    Private ep4 As New ErrorProvider 'documento correcto
    Private vSoloLectura As Boolean
    Private indice As Integer
    Private semaforo As Boolean
    Private Cambios As Boolean
    Private EstadoRecibido As DatosEstado
    Private EstadoRespondido As DatosEstado
    Private EstadoArchivado As DatosEstado
    Private Temporizador As New Timer
    Private FuenteNegrita As Font
    Private FuenteNormal As Font
    'Private idComunicacionPadre As Integer
    Private dtsM As datosComunicacion
    Private dtsF As New datosFichero
    Private dtsR As New datosReferencia
    Private sBusqueda As String
    Private BuscarAhora As Boolean
    Private retardo As New Timer
    Private verClientesPropios As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub MiniCRM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        FuenteNormal = New Font(cbNombre.Font, FontStyle.Regular)
        FuenteNegrita = New Font(cbNombre.Font, FontStyle.Bold)
        'Permisos
        rbProveedor.Enabled = funcPE.Permiso(Inicio.vIdUsuario, "ConsultaProveedor")
        verClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False
        Call Inicializar()
        Call introducirClientes()
        Call introducirSolicitadoVia()
        Call introducirEstados()
        Call introducirPersonal()
        Call Limpiar()
        Call introducirClientes()
        Call IntroducirDocumentos()
        Call CargarIconos()
        Call Busqueda()
    End Sub


    Private Sub MiniCRM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        Temporizador.Interval = 30000
        AddHandler Temporizador.Tick, AddressOf ActualizarHora
        Temporizador.Start()

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

    Private Sub ActualizarHora()
        If lvComunicaciones.SelectedItems.Count = 0 Then
            dtpFechaHora.Value = Now
        End If

    End Sub


    Private Sub Limpiar()
        semaforo = False
        ep1.Clear()
        ep2.Clear()
        ep3.Clear()
        ep4.Clear()
        cbNombre.Text = ""
        cbNombre.SelectedIndex = -1
        cbDireccion.Items.Clear()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbSolicitadoVia.Text = ""
        cbSolicitadoVia.SelectedIndex = -1
        ckDestacado.Checked = False
        Comentario.Text = ""
        indice = -1
        iidCliente = 0
        iidProveedor = 0
        cbEstado.Text = ""
        dtpFechaHora.Value = Now
        lvComunicaciones.Items.Clear()
        cbDocumento.Text = ""
        Referencia.Text = ""
        fichero.Text = ""
        cbDestinatario.Text = ""
        cbDestinatario.SelectedIndex = -1
        Cambios = False
        semaforo = True
    End Sub

    Private Sub LimpiaManteniendoCliente()
        semaforo = False
        ep1.Clear()
        ep2.Clear()
        If cbDireccion.Items.Count = 1 Then
            cbDireccion.SelectedIndex = 0
        Else
            cbDireccion.Text = ""
        End If
        If cbContacto.Items.Count = 1 Then
            cbContacto.SelectedItem = 0
        Else
            cbContacto.Text = ""
        End If
        ckDestacado.Checked = False
        Comentario.Text = ""
        dtpFechaHora.Value = Now
        indice = -1
        cbDocumento.Text = ""
        Referencia.Text = ""
        fichero.Text = ""
        cbDestinatario.Text = ""
        cbDestinatario.SelectedIndex = -1
        cbEstado.Text = ""
        cbSolicitadoVia.Text = ""
        cbSolicitadoVia.SelectedIndex = -1
        Cambios = False
        semaforo = True
    End Sub


    Private Sub introducirClientes()
        Call LimpiarAlCambiarCliente()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbNombre.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirProveedores()
        Call LimpiarAlCambiarCliente()
        Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
        Dim dts As datosProveedor
        For Each dts In lista
            cbNombre.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
        Next
    End Sub

    Private Sub LimpiarAlCambiarCliente()
        cbNombre.Items.Clear()
        cbNombre.Text = ""
        cbDireccion.Items.Clear()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
    End Sub

    Private Sub introducirSolicitadoVia()
        Dim funcSV As New FuncionesSolicitadoVia
        cbSolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbSolicitadoVia.Items.Add(dts)
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("COMUNICACION")
        cbEstado.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
        EstadoArchivado = funcES.EstadoTraspasado("COMUNICACION")
        EstadoRecibido = funcES.EstadoEspera("COMUNICACION")
        EstadoRespondido = funcES.EstadoEnCurso("COMUNICACION")
    End Sub

    Private Sub introducirPersonal()
        cbDestinatario.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.Listar
        For Each item As IDComboBox In lista
            cbDestinatario.Items.Add(item)
        Next
    End Sub


#End Region

#Region "CARGAR DATOS"

    Private Sub CargarDirecciones()
        If cbNombre.SelectedIndex <> -1 Then

            Dim direccion As String = cbDireccion.Text
            cbDireccion.Items.Clear()
            Dim lista As New List(Of datosUbicacion)
            If rbCliente.Checked Then
                iidCliente = cbNombre.SelectedItem.itemdata
                iidProveedor = 0
                lista = funcUB.mostrarCli(iidCliente, True, 0, 1, 0, 0, 1, 0)
            ElseIf rbProveedor.Checked Then
                iidCliente = 0
                iidProveedor = cbNombre.SelectedItem.itemdata
                lista = funcUB.mostrarProv(iidProveedor, True, 0, 0, 1, 0, 0, 1)
            End If
            For Each dts As datosUbicacion In lista
                cbDireccion.Items.Add(New IDComboBox(If(dts.gSubCliente = "", "", dts.gSubCliente & ": ") & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
            Next
            If direccion.Length > 0 Then
                cbDireccion.Text = direccion
            End If
            If cbDireccion.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbDireccion.SelectedIndex = 0
                Else
                    cbDireccion.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub CargarContactos()
        If cbNombre.SelectedIndex <> -1 Then
            Dim Contacto As String = cbContacto.Text
            cbContacto.Text = ""
            cbContacto.Items.Clear()
            Dim lista As New List(Of datosContacto)
            If rbCliente.Checked Then
                iidCliente = cbNombre.SelectedItem.itemdata
                iidProveedor = 0
                lista = funcCT.mostrarCli(iidCliente)
            ElseIf rbProveedor.Checked Then
                iidCliente = 0
                iidProveedor = cbNombre.SelectedItem.itemdata
                lista = funcCT.mostrarProv(iidProveedor)
            End If
            For Each dts As datosContacto In lista
                cbContacto.Items.Add(New IDComboBox(dts.gnombre + " " + dts.gapellidos, dts.gidContacto))
            Next
            If Contacto.Length > 0 Then
                cbContacto.Text = Contacto
            End If
            If cbContacto.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbContacto.SelectedIndex = 0
                Else
                    cbContacto.Text = ""
                End If
            End If
        End If
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call Busqueda()
        End If
    End Sub

    Private Sub Busqueda()
        If lvComunicaciones.SelectedItems.Count = 0 Then
            sBusqueda = " idComunicacionPadre = 0 "
            If verClientesPropios Then
                sBusqueda = sBusqueda & " AND CL.idResponsableCuenta = " & Inicio.vIdUsuario
            End If
            If cbNombre.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                If rbCliente.Checked Then
                    sBusqueda = sBusqueda & " CL.NombreComercial like '%" & cbNombre.Text & "%' "
                Else
                    sBusqueda = sBusqueda & " PR.NombreComercial like '%" & cbNombre.Text & "%' "
                End If
            End If
            If cbDireccion.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.idUbicacion = " & cbDireccion.SelectedItem.itemdata
            End If
            If cbContacto.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.idContacto = " & cbContacto.SelectedItem.itemdata
            End If
            If cbEstado.Text = "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " (CO.idEstado = " & EstadoRecibido.gidEstado & " OR CO.idEstado = " & EstadoRespondido.gidEstado & ") "
            ElseIf cbEstado.SelectedIndex <> -1 And cbEstado.Text <> "TODOS" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.idEstado = " & cbEstado.SelectedItem.gidEstado
            End If
            If cbSolicitadoVia.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.idSolicitadoVia = " & cbSolicitadoVia.SelectedItem.gidSolicitadoVia
            End If
            If ckDestacado.Checked Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.Destacado = 1 "
            End If
            If Comentario.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CO.Comentario like '%" & Comentario.Text & "%' "
            End If
            If Referencia.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " idComunicacion in (Select distinct idComunicacion from Referencias where Referencia like '%" & Referencia.Text & "%' ) "
            End If
            If fichero.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " idComunicacion in (Select distinct idComunicacion from Ficheros where Fichero like '%" & fichero.Text & "%' ) "
            End If
            Call ActualizarLV()
        End If
    End Sub

    Private Sub ActualizarLV()
        lvComunicaciones.Items.Clear()
        Dim lista As List(Of datosComunicacion) = funcCO.Busqueda(sBusqueda, "")
        For Each dts As datosComunicacion In lista
            dtsF = funcFI.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsF Is Nothing Then dtsF = New datosFichero
            dtsR = funcRE.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsR Is Nothing Then dtsR = New datosReferencia
            NuevaLineaLV(dts)
        Next
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As datosComunicacion)
        With lvComunicaciones.Items(indice)
            .SubItems(2).Text = dts.gidComunicacionPadre
            If dts.gidCliente > 0 Then
                .SubItems(3).Text = dts.gCliente
            ElseIf dts.gidProveedor > 0 Then
                .SubItems(3).Text = dts.gProveedor
            Else
                .SubItems(3).Text = ""
            End If
            .SubItems(4).Text = Format(dts.gFechaHora, "dd/MM/yyyy HH:mm")

            If dts.gidComunicacionPadre = 0 Then
                .SubItems(5).Text = dts.gContacto
                .SubItems(6).Text = dts.gComentario

                .SubItems(7).Text = dts.gEstado
                '.Font = FuenteNegrita
                If dts.gCuantosConceptos > 0 Then
                    .SubItems(8).Text = dts.gCuantosConceptos
                    .SubItems(9).Text = "+"
                Else
                    .SubItems(8).Text = ""
                    .SubItems(9).Text = ""
                End If
                .SubItems(10).Text = dts.gDestinatario
            Else
                .SubItems(5).Text = dts.gCreador
                .SubItems(6).Text = dts.gComentario
                .SubItems(7).Text = ""
                .SubItems(8).Text = ""
                .SubItems(9).Text = ""
                .SubItems(10).Text = ""

            End If
            If dts.gDestacado Then
                .ForeColor = Color.Red
            Else
                .ForeColor = SystemColors.WindowText
            End If
            Select Case dts.gidEstado
                Case EstadoArchivado.gidEstado
                    .ForeColor = Color.Gray
                Case EstadoRespondido.gidEstado
                    .ForeColor = Color.Orange
            End Select
            If (Not dtsF Is Nothing AndAlso dtsF.gidFichero <> 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia <> 0) Then
                .ImageIndex = 0
            Else
                .ImageIndex = -1
            End If
        End With
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As datosComunicacion)

        With lvComunicaciones.Items.Add(" ")
            .SubItems.Add(dts.gidComunicacion)
            .SubItems.Add(dts.gidComunicacionPadre)
            If dts.gidCliente > 0 Then
                .SubItems.Add(dts.gCliente)
            ElseIf dts.gidProveedor > 0 Then
                .SubItems.Add(dts.gProveedor)
            Else
                .SubItems.Add("")
            End If
            .SubItems.Add(Format(dts.gFechaHora, "dd/MM/yyyy HH:mm"))

            If dts.gidComunicacionPadre = 0 Then
                .SubItems.Add(dts.gContacto)
                .SubItems.Add(dts.gComentario)
                .SubItems.Add(dts.gEstado)

                '.Font = FuenteNegrita
                If dts.gCuantosConceptos > 0 Then
                    .SubItems.Add(dts.gCuantosConceptos)
                    .SubItems.Add("+")
                Else
                    .SubItems.Add("")
                    .SubItems.Add("")
                End If
                .SubItems.Add(dts.gDestinatario)
            Else
                .SubItems.Add(dts.gCreador)
                .SubItems.Add(dts.gComentario)
                .SubItems.Add("")
                .SubItems.Add("")
                .SubItems.Add("")
                .SubItems.Add("")
            End If
            If dts.gDestacado Then
                .ForeColor = Color.Red
            Else
                .ForeColor = SystemColors.WindowText
            End If
            Select Case dts.gidEstado
                Case EstadoArchivado.gidEstado
                    .ForeColor = Color.Gray
                Case EstadoRespondido.gidEstado
                    .ForeColor = Color.Orange
            End Select
            If (Not dtsF Is Nothing AndAlso dtsF.gidFichero <> 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia <> 0) Then
                .ImageIndex = 0
            Else
                .ImageIndex = -1
            End If
        End With

    End Sub

    Private Function CrearItemLV(ByVal dts As datosComunicacion) As ListViewItem
        Dim item As New ListViewItem
        With item
            .Text = " "
            .SubItems.Add(dts.gidComunicacion)
            .SubItems.Add(dts.gidComunicacionPadre)
            If dts.gidComunicacionPadre = 0 Then
                If dts.gidCliente > 0 Then
                    .SubItems.Add(dts.gCliente)
                ElseIf dts.gidProveedor > 0 Then
                    .SubItems.Add(dts.gProveedor)
                Else
                    .SubItems.Add("")
                End If
            Else
                .SubItems.Add("")
            End If

            .SubItems.Add(Format(dts.gFechaHora, "dd/MM/yyyy HH:mm"))

            If dts.gidComunicacionPadre = 0 Then
                .SubItems.Add(dts.gContacto)
                .SubItems.Add(dts.gComentario)
                .SubItems.Add(dts.gEstado)

                '.Font = FuenteNegrita
                If dts.gCuantosConceptos > 0 Then
                    .SubItems.Add(dts.gCuantosConceptos)
                    .SubItems.Add("+")
                Else
                    .SubItems.Add("")
                    .SubItems.Add("")
                End If
            Else
                .SubItems.Add(dts.gCreador)
                .SubItems.Add(dts.gComentario)
                .SubItems.Add("")
                .SubItems.Add("")
            End If
            If dts.gDestacado Then
                .ForeColor = Color.Red
            Else
                .ForeColor = SystemColors.WindowText
            End If
            Select Case dts.gidEstado
                Case EstadoArchivado.gidEstado
                    .ForeColor = Color.Gray
                Case EstadoRespondido.gidEstado
                    .ForeColor = Color.Orange
            End Select
            If (Not dtsF Is Nothing AndAlso dtsF.gidFichero <> 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia <> 0) Then
                .ImageIndex = 0
            Else
                .ImageIndex = -1
            End If
        End With
        Return item
    End Function

    Private Function Guardar() As Boolean
        ep1.Clear()
        ep2.Clear()
        Dim validar As Boolean = True
        If cbNombre.SelectedIndex = -1 Then
            ep1.SetError(cbNombre, "Se ha de seleccionar un cliente.")
            validar = False
        End If
        If cbEstado.Text = "TODOS" Then
            cbEstado.Text = EstadoRecibido.gEstado
        End If
        If cbEstado.SelectedIndex = -1 Then
            ep1.SetError(cbEstado, "Se ha de seleccionar un estado válido")
            validar = False
        End If

        If cbContacto.SelectedIndex = -1 Then
            ep2.SetError(cbContacto, "No se ha seleccionado un contacto válido")
        End If
        If cbSolicitadoVia.SelectedIndex = -1 Then
            ep2.SetError(cbSolicitadoVia, "No se ha seleccionado la vía de comunicación")
        End If
        If cbDestinatario.SelectedIndex = -1 Then
            ep2.SetError(cbSolicitadoVia, "No se ha seleccionado el destinatario de la comunicación")
        End If
       
        If validar Then
            If dtsM Is Nothing Then dtsM = New datosComunicacion
            If rbCliente.Checked Then
                dtsM.gidCliente = cbNombre.SelectedItem.itemData
                dtsM.gCliente = cbNombre.Text
                dtsM.gidProveedor = 0
                dtsM.gProveedor = ""
            Else
                dtsM.gidCliente = 0
                dtsM.gCliente = ""
                dtsM.gidProveedor = cbNombre.SelectedItem.itemData
                dtsM.gProveedor = cbNombre.Text
            End If
            dtsM.gComentario = Comentario.Text
            dtsM.gContacto = If(cbContacto.SelectedIndex = -1, "", cbContacto.Text)
            dtsM.gCreador = funcPE.campoNombreyApellidos(Inicio.vIdUsuario)
            dtsM.gDestacado = ckDestacado.Checked
            dtsM.gDireccion = cbDireccion.Text
            dtsM.gFechaHora = dtpFechaHora.Value

            If cbContacto.SelectedIndex = -1 Then
                dtsM.gidContacto = 0
                dtsM.gContacto = ""
            Else
                dtsM.gidContacto = cbContacto.SelectedItem.itemData
                dtsM.gContacto = cbContacto.SelectedItem.ToString
            End If
            If cbSolicitadoVia.SelectedIndex = -1 Then
                dtsM.gidSolicitadoVia = 0
                dtsM.gSolicitadoVia = ""
            Else
                dtsM.gidSolicitadoVia = cbSolicitadoVia.SelectedItem.gidSolicitadoVia
                dtsM.gSolicitadoVia = cbSolicitadoVia.SelectedItem.gSolicitadoVia
            End If
            dtsM.gidUbicacion = If(cbDireccion.SelectedIndex = -1, 0, cbDireccion.SelectedItem.ItemData)

            dtsM.gSolicitadoVia = cbSolicitadoVia.Text
            dtsM.gidEstado = cbEstado.SelectedItem.gidEstado
            dtsM.gEstado = cbEstado.Text
            If cbDestinatario.SelectedIndex = -1 Then
                dtsM.gidDestinatario = 0
                dtsM.gDestinatario = ""
            Else
                dtsM.gidDestinatario = cbDestinatario.SelectedItem.itemdata
                dtsM.gDestinatario = cbDestinatario.Text
            End If

            If lvComunicaciones.SelectedItems.Count > 0 Then
                indice = lvComunicaciones.SelectedIndices(0)
                dtsM.gidComunicacion = lvComunicaciones.Items(indice).SubItems(1).Text
                dtsM.gidComunicacionPadre = 0
                funcCO.actualizar(dtsM)
                funcRE.borrarComunicacion(dtsM.gidComunicacion)
                funcFI.borrarComunicacion(dtsM.gidComunicacion)
            Else
                dtsM.gidComunicacionPadre = 0
                dtsM.gidComunicacion = funcCO.insertar(dtsM)
            End If
            If Referencia.Text <> "" Then
                dtsR = New datosReferencia
                dtsR.gReferencia = Referencia.Text
                dtsR.gDocumento = cbDocumento.Text
                dtsR.gidComunicacion = dtsM.gidComunicacion
                dtsR.gidReferencia = funcRE.insertar(dtsR)
            End If
            If fichero.Text <> "" And Not dtsF Is Nothing Then
                dtsF.gidComunicacion = dtsM.gidComunicacion
                dtsF.gidFichero = funcFI.insertar(dtsF)
            End If
            If lvComunicaciones.SelectedItems.Count > 0 Then
                Call ActualizarLineaLV(dtsM)
            Else
                Call ActualizarLV()
            End If
        End If
        Return validar
    End Function

    Private Sub EnviarCorreo()
        If dtsM.gidDestinatario > 0 Then
            Dim Asunto As String = ""
            If rbCliente.Checked Then
                If dtsM.gDestacado Then
                    Asunto = "**MENSAJE DESTACADO DEL CLIENTE  " & dtsM.gCliente
                Else
                    Asunto = "Nuevo mensaje del cliente " & dtsM.gCliente
                End If
            ElseIf rbProveedor.Checked Then
                If dtsM.gDestacado Then
                    Asunto = "**MENSAJE DESTACADO DEL PROVEEDOR  " & dtsM.gProveedor
                Else
                    Asunto = "Nuevo mensaje del proveedor " & dtsM.gProveedor
                End If

            End If
            Dim texto As String = vbCrLf & dtsM.gCreador & " ha recibido un mensaje del "

            If dtsM.gCliente <> "" Then
                texto = texto & "cliente " & dtsM.gCliente
            ElseIf dtsM.gProveedor <> "" Then
                texto = texto & "proveedor " & dtsM.gProveedor
            End If

            texto = texto & vbCrLf & vbCrLf & "Fecha y hora: " & Format(dtsM.gFechaHora, "dd/MM/yyyy HH:mm") & vbCrLf & vbCrLf
            If dtsM.gidSolicitadoVia <> 0 Then
                texto = texto & "Modo de recepción: " & dtsM.gSolicitadoVia & vbCrLf & vbCrLf
            End If

            texto = texto & If(dtsM.gContacto = "", "", "Persona de contacto: " & dtsM.gContacto & vbCrLf & vbCrLf)
            texto = texto & If(dtsM.gDestinatario = "", "", "Destinatario: " & dtsM.gDestinatario & vbCrLf & vbCrLf)

            If Not dtsF Is Nothing AndAlso dtsF.gFichero <> "" Then
                texto = texto & "Se hace referencia al fichero: " & dtsF.gFichero & vbCrLf & vbCrLf
            End If
            If Not dtsR Is Nothing AndAlso dtsR.gReferencia <> "" Then
                texto = texto & "El mensaje se refiere a: " & dtsR.gDocumento & " " & dtsR.gReferencia & vbCrLf & vbCrLf
            End If
            texto = texto & "MENSAJE:" & vbCrLf & dtsM.gComentario

            correo(Asunto, texto, funcPE.campoCorreo(Inicio.vIdUsuario), funcPE.campoCorreo(dtsM.gidDestinatario), "")
        End If
    End Sub

    Private Sub PresentarComunicacion(ByVal dts As datosComunicacion)
        semaforo = False
        ' idComunicacionPadre = If(dts.gidComunicacionPadre = 0, dts.gidComunicacion, dts.gidComunicacionPadre)
        If dts.gidEstado = EstadoArchivado.gidEstado Then
            cbNombre.Enabled = False
            cbDireccion.Enabled = False
            cbContacto.Enabled = False
        Else
            cbNombre.Enabled = True
            cbDireccion.Enabled = True
            cbContacto.Enabled = True
        End If
        If dts.gidCliente > 0 Then
            If rbCliente.Checked = False Then
                rbCliente.Checked = True
                Call introducirClientes()
            End If
            cbNombre.Text = dts.gCliente
        ElseIf dts.gidProveedor > 0 Then
            If rbProveedor.Checked = False Then
                rbProveedor.Checked = True
                Call introducirProveedores()
            End If
            cbNombre.Text = dts.gProveedor
        End If

        cbDireccion.Text = dts.gDireccion
        cbSolicitadoVia.Text = dts.gSolicitadoVia
        cbContacto.Text = dts.gContacto
        ckDestacado.Checked = dts.gDestacado
        cbEstado.Text = dts.gEstado
        Comentario.Text = dts.gComentario
      
        dtsF = funcFI.mostrar(dts.gidComunicacion).FirstOrDefault
        If dtsF Is Nothing Then dtsF = New datosFichero
        dtsR = funcRE.mostrar(dts.gidComunicacion).FirstOrDefault
        If dtsR Is Nothing Then dtsR = New datosReferencia
       
        cbDocumento.Text = dtsR.gDocumento
        Referencia.Text = dtsR.gReferencia
        fichero.Text = dtsF.gFichero

        semaforo = True
    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call Limpiar()
        Call Busqueda()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoComunicaciones
        GG.verInforme(sBusqueda, "", False)
        GG.ShowDialog()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If Guardar() Then
            Call EnviarCorreo()
            Call Limpiar()
            Call Busqueda()
        End If
    End Sub

    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click
        If rbCliente.Checked Then
            Call BuscarCliente()
        ElseIf rbProveedor.Checked Then
            Call BuscarProveedor()
        End If
    End Sub

    Private Sub BuscarCliente()
        Dim GG As New busquedaCliente
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            iidCliente = GG.pidCliente
            cbNombre.Text = funcCL.campoCliente(iidCliente)
            Call CargarDirecciones()
            Call CargarContactos()
            Call LimpiaManteniendoCliente()
        End If
    End Sub

    Private Sub BuscarProveedor()
        Dim GG As New busquedaproveedor
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidproveedor > 0 Then
            iidProveedor = GG.pidproveedor
            cbNombre.Text = funcPR.campoProveedor(iidProveedor)
            Call CargarDirecciones()
            Call CargarContactos()
            Call LimpiaManteniendoCliente()
        End If
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbNombre.SelectedIndex <> -1 Then
            If rbCliente.Checked Then
                Call VerCliente(sender.name)
            ElseIf rbProveedor.Checked Then
                Call VerProveedor(sender.name)
            End If
            Call CargarDirecciones()
            Call CargarContactos()
        End If
    End Sub

    Private Sub bNuevoContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoContacto.Click
        If cbNombre.SelectedIndex <> -1 Then
            Dim direccionExistente As String = cbDireccion.Text
            If rbCliente.Checked Then
                Call VerCliente(sender.name)
            ElseIf rbProveedor.Checked Then
                Call VerProveedor(sender.name)
            End If
            Call CargarDirecciones()
            Call CargarContactos()
            cbDireccion.Text = direccionExistente
            If cbDireccion.SelectedIndex = -1 Then
                cbDireccion.Text = 0
            End If
        End If
    End Sub

    Private Sub VerCliente(ByVal modo As String)
        iidCliente = cbNombre.SelectedItem.itemdata
        Dim cliente As String = cbNombre.Text
        Dim GG As New GestionClientes
        GG.SoloLectura = vSoloLectura
        GG.pidCliente = iidCliente
        If modo = "bNuevoContacto" Then
            GG.pAbrirTab = 1
            GG.pidUbicacion = If(cbDireccion.SelectedIndex = -1, 0, cbDireccion.SelectedItem.itemdata)
        End If
        GG.ShowDialog()
        If GG.pidCliente = iidCliente Then
            Call introducirClientes()
            cbNombre.Text = funcCL.campoCliente(iidCliente)
            If cbNombre.SelectedIndex = -1 Then
                cbNombre.Text = ""
            End If
        End If
    End Sub

    Private Sub VerProveedor(ByVal modo As String)
        iidProveedor = cbNombre.SelectedItem.itemdata
        Dim Proveedor As String = cbNombre.Text
        Dim GG As New GestionProveedores
        GG.SoloLectura = vSoloLectura
        GG.pidProveedor = iidProveedor
        If modo = "bNuevoContacto" Then
            GG.pAbrirTab = 1
            GG.pidUbicacion = If(cbDireccion.SelectedIndex = -1, 0, cbDireccion.SelectedItem.itemdata)
        End If
        GG.ShowDialog()
        If GG.pidProveedor = iidProveedor Then
            Call introducirProveedores()
            cbNombre.Text = funcPR.campoProveedor(iidProveedor)
            If cbNombre.SelectedIndex = -1 Then
                cbNombre.Text = ""
            End If
        End If
    End Sub

    Private Sub bNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoCliente.Click
        If rbCliente.Checked Then
            Call NuevoCliente()
        ElseIf rbProveedor.Checked Then
            Call NuevoProveedor()
        End If
    End Sub

    Private Sub NuevoCliente()
        Dim GG As New GestionClientes
        GG.pidCliente = 0
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            iidCliente = GG.pidCliente
            Call introducirClientes()
            cbNombre.Text = funcCL.campoCliente(iidCliente)
            Call CargarDirecciones()
            Call CargarContactos()
            Call LimpiaManteniendoCliente()
        End If
    End Sub

    Private Sub NuevoProveedor()
        Dim GG As New GestionProveedores
        GG.pidProveedor = 0
        GG.ShowDialog()
        If GG.pidProveedor > 0 Then
            iidProveedor = GG.pidProveedor
            Call introducirProveedores()
            cbNombre.Text = funcPR.campoProveedor(iidProveedor)
            Call CargarDirecciones()
            Call CargarContactos()
            Call LimpiaManteniendoCliente()
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
            If IsNumeric(Referencia.Text) Then
                Select Case cbDocumento.Text
                    Case "PEDIDO CLIENTE"
                        Dim GG As New GestionPedido
                        GG.SoloLectura = vSoloLectura
                        GG.pnumPedido = Referencia.Text
                        GG.ShowDialog()
                    Case "PEDIDO PROVEEDOR"
                        Dim GG As New GestionPedidoProveedor
                        GG.SoloLectura = vSoloLectura
                        GG.pNumPedido = Referencia.Text
                        GG.ShowDialog()
                    Case "ALBARÁN A PROVEEDOR"
                        Dim GG As New GestionAlbaranAProv
                        GG.SoloLectura = vSoloLectura
                        GG.pnumAlbaran = Referencia.Text
                        GG.ShowDialog()
                    Case "ALBARÁN CLIENTE"
                        Dim GG As New GestionAlbaran
                        GG.SoloLectura = vSoloLectura
                        GG.pnumAlbaran = Referencia.Text
                        GG.ShowDialog()
                    Case "FACTURA CLIENTE"
                        Dim GG As New GestionFactura1
                        GG.SoloLectura = vSoloLectura
                        GG.pnumFactura = Referencia.Text
                        GG.ShowDialog()
                    Case "OFERTA CLIENTE"
                        Dim GG As New GestionOferta
                        GG.SoloLectura = vSoloLectura
                        GG.pnumOferta = Referencia.Text
                        GG.ShowDialog()

                    Case "PROFORMA CLIENTE"
                        Dim GG As New GestionProforma
                        GG.SoloLectura = vSoloLectura
                        GG.pnumProforma = Referencia.Text
                        GG.ShowDialog()

                    Case "REPARACIÓN"
                        Dim GG As New GestionReparacion
                        GG.SoloLectura = vSoloLectura
                        GG.pnumReparacion = Referencia.Text
                        GG.ShowDialog()

                    Case "N/S EQUIPO"
                        Dim GG As New BusquedaEquipos
                        GG.SoloLectura = vSoloLectura
                        GG.pNumSerie = Referencia.Text
                        GG.ShowDialog()
                    Case "ALBARÁN DE PROVEEDOR"
                        Call VerAlbaranProveedor()

                    Case "FACTURA PROVEEDOR"
                        Call VerFacturaProv()

                End Select
            Else
                Select Case cbDocumento.Text
                    Case "ALBARÁN DE PROVEEDOR"
                        Call VerAlbaranProveedor()
                    Case "FACTURA PROVEEDOR"
                        Call VerFacturaProv()
                End Select
            End If

        End If
    End Sub

    Private Sub VerAlbaranProveedor()
        If rbProveedor.Checked AndAlso cbNombre.SelectedIndex <> -1 Then
            iidProveedor = cbNombre.SelectedItem.itemdata
            Dim iidAlbaran As Integer = funcAP.idAlbaran(Referencia.Text, iidProveedor)
            If iidAlbaran > 0 Then
                Dim GG As New GestionAlbaranDeProv
                GG.SoloLectura = vSoloLectura
                GG.pidAlbaran = iidAlbaran
                GG.ShowDialog()
            End If
        End If
    End Sub

    Private Sub VerFacturaProv()
        If rbProveedor.Checked AndAlso cbNombre.SelectedIndex <> -1 Then
            iidProveedor = cbNombre.SelectedItem.itemdata
            Dim iidFactura As Integer = funcFP.idFactura(Referencia.Text, iidProveedor)
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

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvComunicaciones.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvComunicaciones.SelectedIndices(0)
            Dim iidComunicacion As Integer = lvComunicaciones.Items(indice).SubItems(1).Text
            If MsgBox("¿Borrar el mensaje y todas sus respuestas?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcFI.borrarComunicacion(iidComunicacion)
                funcRE.borrarComunicacion(iidComunicacion)
                funcCO.borrarConceptos(iidComunicacion)
                funcCO.borrar(iidComunicacion)
                If lvComunicaciones.Items(indice).SubItems(9).Text = "-" Then
                    For Each item As ListViewItem In lvComunicaciones.Items
                        'Buscar todos los items cuyo idPadre sea el que queremos cerrar
                        If IsNumeric(item.SubItems(2).Text) AndAlso item.SubItems(2).Text = iidComunicacion Then
                            item.Remove()
                        End If
                    Next
                End If
                lvComunicaciones.Items.RemoveAt(indice)
            End If

        End If
    End Sub

    Private Sub bBuscarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarDocumento.Click
        Dim ReferenciaNumerica As Integer = If(IsNumeric(Referencia.Text), CLng(Referencia.Text), 0)
        Select Case cbDocumento.Text
            Case "PEDIDO CLIENTE"
                Dim GG As New busquedaPedidos
                GG.SoloLectura = vSoloLectura
                GG.pnumPedido = ReferenciaNumerica
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumPedido
            Case "PEDIDO PROVEEDOR"
                Dim GG As New BusquedaPedidoProveedor
                GG.SoloLectura = vSoloLectura
                GG.pnumPedido = ReferenciaNumerica
                If rbProveedor.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidProveedor = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumPedido
            Case "ALBARÁN A PROVEEDOR"
                Dim GG As New busquedaAlbaranesAProv
                GG.SoloLectura = vSoloLectura
                GG.pnumAlbaran = ReferenciaNumerica
                If rbProveedor.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidProveedor = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran
            Case "ALBARÁN CLIENTE"
                Dim GG As New busquedaAlbaranes
                GG.SoloLectura = vSoloLectura
                GG.pnumAlbaran = ReferenciaNumerica
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran
            Case "FACTURA CLIENTE"
                Dim GG As New busquedaFacturas
                GG.SoloLectura = vSoloLectura
                GG.pnumFactura = ReferenciaNumerica
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumFactura
            Case "OFERTA CLIENTE"
                Dim GG As New busquedaOfertas
                GG.SoloLectura = vSoloLectura
                GG.pnumOferta = ReferenciaNumerica
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumOferta

            Case "PROFORMA CLIENTE"
                Dim GG As New busquedaProformas
                GG.SoloLectura = vSoloLectura
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
                GG.pnumProforma = ReferenciaNumerica
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumProforma
            Case "REPARACIÓN"
                Dim GG As New busquedaReparaciones
                GG.SoloLectura = vSoloLectura
                GG.pnumReparacion = ReferenciaNumerica
                If rbCliente.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidCliente = cbNombre.SelectedItem.itemdata
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
                If rbProveedor.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidProveedor = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumAlbaran

            Case "FACTURA PROVEEDOR"
                Dim GG As New busquedaFacturasProv
                GG.SoloLectura = vSoloLectura
                GG.pnumFactura = Referencia.Text
                If rbProveedor.Checked And cbNombre.SelectedIndex <> -1 Then GG.pidProveedor = cbNombre.SelectedItem.itemdata
                GG.pModo = "B"
                GG.ShowDialog()
                Referencia.Text = GG.pnumFactura


        End Select
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.SelectionChangeCommitted
        Call CargarDatosClienteProv()
    End Sub

    Private Sub CargarDatosClienteProv()
        If cbNombre.SelectedIndex <> -1 Then
            Call CargarDirecciones()
            Call CargarContactos()
            Call ActualizarLV()
            Cambios = True
        End If
    End Sub

    Private Sub cbDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted, _
    cbContacto.SelectionChangeCommitted, Comentario.TextChanged, ckDestacado.CheckedChanged, cbSolicitadoVia.SelectionChangeCommitted
        Cambios = semaforo
    End Sub

    Private Sub lvComunicaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvComunicaciones.Click
        If lvComunicaciones.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvComunicaciones.SelectedIndices(0)
            If lvComunicaciones.Items(indice).SubItems(2).Text = 0 Then 'idComunicacionPadre
                Dim iidComunicacion As Integer = lvComunicaciones.Items(indice).SubItems(1).Text
                If lvComunicaciones.Items(indice).SubItems(9).Text = "+" Then
                    Call ExpandirMensaje(indice)
                ElseIf lvComunicaciones.Items(indice).SubItems(9).Text = "-" Then
                    lvComunicaciones.Items(indice).SubItems(9).Text = "+"
                    For Each item As ListViewItem In lvComunicaciones.Items
                        'Buscar todos los items cuyo idPadre sea el que queremos cerrar
                        If IsNumeric(item.SubItems(2).Text) AndAlso item.SubItems(2).Text = iidComunicacion Then
                            item.Remove()
                        End If
                    Next
                End If
                Call PresentarComunicacion(funcCO.mostrar1(iidComunicacion))
            End If
        End If
    End Sub

    Private Sub ExpandirMensaje(ByVal indice As Integer)
        Dim iidComunicacion As Integer = lvComunicaciones.Items(indice).SubItems(1).Text
        Dim lista As List(Of datosComunicacion) = funcCO.mostrarConceptos(iidComunicacion)
        For Each dts As datosComunicacion In lista
            dtsF = funcFI.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsF Is Nothing Then dtsF = New datosFichero
            dtsR = funcRE.mostrar(dts.gidComunicacion).FirstOrDefault
            If dtsR Is Nothing Then dtsR = New datosReferencia
            lvComunicaciones.Items.Insert(indice + 1, CrearItemLV(dts))
        Next
        If lista.Count > 0 Then lvComunicaciones.Items(indice).SubItems(9).Text = "-"
    End Sub

    Private Sub lvComunicaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvComunicaciones.DoubleClick
        If lvComunicaciones.SelectedItems.Count > 0 Then
            indice = lvComunicaciones.SelectedIndices(0)
            Dim iidComunicacion As Integer = lvComunicaciones.Items(indice).SubItems(2).Text 'iidComunicacionPadre
            If iidComunicacion = 0 Then
                iidComunicacion = lvComunicaciones.Items(indice).SubItems(1).Text
            End If

            Dim GG As New GestionMensaje
            GG.pidComunicacion = iidComunicacion
            GG.ShowDialog()

            Call ActualizarLineaLV(funcCO.mostrar1(iidComunicacion))
            For Each item As ListViewItem In lvComunicaciones.Items
                'Buscar todos los items cuyo idPadre sea el que queremos cerrar
                If IsNumeric(item.SubItems(2).Text) AndAlso item.SubItems(2).Text = iidComunicacion Then
                    item.Remove()
                End If
            Next
            For Each item As ListViewItem In lvComunicaciones.Items
                'Buscar el indice raiz del mensaje
                If item.SubItems(1).Text = iidComunicacion Then
                    indice = item.Index
                End If
            Next
            ExpandirMensaje(indice)
        End If

    End Sub

    Private Sub rbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCliente.CheckedChanged, rbProveedor.CheckedChanged
        If semaforo Then
            Call Limpiar()
            If rbCliente.Checked Then
                Call introducirClientes()
            ElseIf rbProveedor.Checked Then
                Call introducirProveedores()
            End If
            Call Busqueda()
        End If
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.TextChanged, Comentario.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub cbDireccion_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.SelectedIndexChanged, cbDireccion.SelectedIndexChanged, _
        cbDestinatario.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, dtpFechaHora.ValueChanged, cbContacto.SelectedIndexChanged, _
        cbEstado.SelectedIndexChanged, fichero.TextChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub cbEstado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.TextChanged
        If semaforo And cbEstado.Text = "" Then Busqueda()
    End Sub

    Private Sub Referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Referencia.TextChanged, cbDocumento.SelectedIndexChanged
        If semaforo AndAlso (cbDocumento.SelectedIndex <> -1 And Referencia.Text <> "") Then
            ep3.Clear()
            ep4.Clear()
            If rbCliente.Checked Then
                iidCliente = If(cbNombre.SelectedIndex = -1, 0, cbNombre.SelectedItem.itemdata)
                iidProveedor = 0
            ElseIf rbProveedor.Checked Then
                iidCliente = 0
                iidProveedor = If(cbNombre.SelectedIndex = -1, 0, cbNombre.SelectedItem.itemdata)
            Else
                iidCliente = 0
                iidProveedor = 0
            End If
            If cbDocumento.SelectedIndex = -1 Then
                ep2.SetError(cbDocumento, "No ha seleccionado el tipo de documento")
            Else
                If IsNumeric(Referencia.Text) AndAlso Referencia.Text > 0 Then
                    Select Case cbDocumento.Text
                        Case "PEDIDO CLIENTE"

                            Dim iidClienteDoc As Integer = funcPC.ExisteNumPedido(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Pedido existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
                                ep4.SetError(Referencia, "Pedido existente")
                            Else
                                ep3.SetError(Referencia, "no existe un pedido con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "PEDIDO PROVEEDOR"
                            Dim iidProveedorDoc As Integer = funcPP.ExisteNumPedidoProv(Referencia.Text, iidProveedor)
                            If iidProveedor = 0 And iidProveedorDoc > 0 Then
                                ep4.SetError(Referencia, "Pedido existente")
                                iidProveedor = iidProveedorDoc
                                cbNombre.Text = funcPR.campoProveedor(iidProveedor)
                                Call CargarDatosClienteProv()
                            ElseIf iidProveedor > 0 And iidProveedor = iidProveedorDoc Then
                                ep4.SetError(Referencia, "Pedido existente")
                            Else
                                ep3.SetError(Referencia, "no existe un pedido con este número" & If(iidProveedor = 0, "", " para el proveedor seleccionado"))
                            End If
                        Case "ALBARÁN A PROVEEDOR"

                            Dim iidProveedorDoc As Integer = funcAL.ExistenumAlbaranProv(Referencia.Text, iidProveedor)
                            If iidProveedor = 0 And iidProveedorDoc > 0 Then
                                ep4.SetError(Referencia, "Albarán existente")
                                iidProveedor = iidProveedorDoc
                                cbNombre.Text = funcPR.campoProveedor(iidProveedor)
                                Call CargarDatosClienteProv()
                            ElseIf iidProveedor > 0 And iidProveedor = iidProveedorDoc Then
                                ep4.SetError(Referencia, "Albarán existente")
                            Else
                                ep3.SetError(Referencia, "no existe un albarán con este número" & If(iidProveedor = 0, "", " para el proveedor seleccionado"))
                            End If

                        Case "ALBARÁN CLIENTE"
                            Dim iidClienteDoc As Integer = funcAL.ExistenumAlbaranCli(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Albarán existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
                                ep4.SetError(Referencia, "Albarán existente")
                            Else
                                ep3.SetError(Referencia, "no existe un albarán con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If
                        Case "FACTURA CLIENTE"

                            Dim iidClienteDoc As Integer = funcFA.ExistenumfACTURA(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Factura existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
                                ep4.SetError(Referencia, "Factura existente")
                            Else
                                ep3.SetError(Referencia, "no existe una factura con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "OFERTA CLIENTE"
                            Dim iidClienteDoc As Integer = funcOF.ExisteNumOferta(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Oferta existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
                                ep4.SetError(Referencia, "Oferta existente")
                            Else
                                ep3.SetError(Referencia, "no existe una oferta con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If

                        Case "PROFORMA CLIENTE"
                            Dim iidClienteDoc As Integer = funcPF.ExisteNumProforma(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Proforma existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
                                ep4.SetError(Referencia, "Proforma existente")
                            Else
                                ep3.SetError(Referencia, "no existe una proforma con este número" & If(iidCliente = 0, "", " para el cliente seleccionado"))
                            End If


                        Case "REPARACIÓN"
                            Dim iidClienteDoc As Integer = funcREP.ExisteNumReparacion(Referencia.Text, iidCliente)
                            If iidCliente = 0 And iidClienteDoc > 0 Then
                                ep4.SetError(Referencia, "Reparación existente")
                                iidCliente = iidClienteDoc
                                cbNombre.Text = funcCL.campoCliente(iidCliente)
                                Call CargarDatosClienteProv()
                            ElseIf iidCliente > 0 And iidCliente = iidClienteDoc Then
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
        Dim iidAlbaran As Integer = funcAP.idAlbaran(Referencia.Text, iidProveedor)
        If iidAlbaran = 0 Then
            ep3.SetError(Referencia, "no existe un albarán con este número de este proveedor")
        Else
            ep4.SetError(Referencia, "Albarán existente")
        End If
    End Sub

    Private Sub CambiosFacturaProv()
        Dim iidFactura As Integer = funcFP.idFactura(Referencia.Text, iidProveedor)
        If iidFactura = 0 Then
            ep3.SetError(Referencia, "no existe una factura con este número de este proveedor")
        Else
            ep4.SetError(Referencia, "Factura existente")
        End If
    End Sub

#End Region

End Class