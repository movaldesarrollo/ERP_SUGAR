Public Class GestionClientes

    Private iidContacto As Integer
    Private iidUbicacion As Integer
    Private iidubicacionP As Integer
    Private iidFacturacion As Integer
    Private iidCuentaBanco As Integer
    Private indiceB As Integer
    Private icodfact As Double
    Private espUbic As Boolean = True 'Indica la ubicación es española
    Private iidUsuario As Integer
    Private vSoloLectura As Boolean = False
    Private vmes As Integer
    Private funcTC As New FuncionesTipoCompra
    Private funcCL As New funcionesclientes
    Private funcPA As New funcionesPaises
    Private funcU As New funcionesUbicaciones
    Private funcCT As New funcionesContactos
    Private funcTel As New FuncionesTelefonos
    Private funcTP As New funcionesTiposPago
    Private funcMP As New funcionesMediosPago
    Private funcMail As New FuncionesMails
    Private funcDT As New funcionesDepartamentos
    Private funcFA As New funcionesFacturacion
    Private funcBA As New FuncionesBancos
    Private funcTU As New FuncionesTiposUbicacion
    Private funcMO As New FuncionesMoneda
    Dim funcPE As New FuncionesPersonal
    Private funcID As New funcionesIdiomas
    Private funcCB As New FuncionesCuentasBancarias
    Private funcTI As New FuncionesTiposIVA
    Private funcTR As New FuncionesTiposRetencion
    Private funcPR As New funcionesProveedores
    Private funcF As New FuncionesFacturas
    Private funcP As New FuncionesPedidos
    Private funcES As New FuncionesEstados
    Private funcOF As New FuncionesOfertas
    Private funcPF As New FuncionesProformas
    Private funcAL As New FuncionesAlbaranes
    Private funcTA As New FuncionesTiposArticulo
    Private funcST As New FuncionessubTiposArticulo
    Private funcCC As New funcionesCambiosComisiones
    Private funcCM As New funcionesComisiones
    Private DI As New DatosIniciales
    Private indiceDirecciones As Integer
    Private indiceContactos As Integer
    'Private nuevo As Boolean
    Private G_AGeneral As Char
    Private G_AUbicacion As Char
    Private G_AUbicacionF As Char
    Private G_AContacto As Char
    Private G_AFacturacion As Char
    Private semaforo As Boolean
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private colorInactivo As New Color
    Private colorCabecera As Color
    Private Ancho As Integer = 1039
    Private desktopsize As Size
    Public iidCliente As Integer
    Private Clientes As List(Of Integer)
    Private IndiceL As Integer
    Private VerClientesPropios As Boolean
    Private lvwColumnSorterAV As OrdenarLV
    Private OrdenOfertas, OrdenProformas, OrdenPedidos, OrdenAlbaranes, OrdenFacturas, OrdenComisiones As String
    Private DireccionOferta, DireccionProforma, DireccionPedido, DireccionAlbaran, DireccionFactura, DireccionComisiones As String
    Private ColumnaOferta, ColumnaProforma, ColumnaPedido, ColumnaAlbaran, ColumnaFactura, ColumnaComisiones As Byte
    Private sBusquedaOferta, sBusquedaProforma, sBusquedaPedido, sBusquedaAlbaran, sBusquedaFactura, sBusquedaComisiones As String
    Private Cambios As Boolean
    Private CambiosFacturacion As Boolean
    Private CambiosDireccion As Boolean
    Private CambiosContacto As Boolean
    Private AbrirTab As Integer
    Private SumaRE As Double = 0
    Private SumaRetencion As Double = 0
    Private GestionaComisiones As Boolean
    Private sBusquedaPVendidos As String
    Dim cambioTipoDireccion As Boolean
    Public Vvercostes As Boolean

    Property pVerClientesPropios() As Boolean
        Get
            Return VerClientesPropios
        End Get
        Set(ByVal value As Boolean)
            VerClientesPropios = value
        End Set
    End Property

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pidCliente() As Integer
        Get
            Return iidCliente
        End Get
        Set(ByVal value As Integer)  'Si se recibe -1, se abrirá el buscador. Si se recibe 0, será un nuevo Cliente
            iidCliente = value
        End Set
    End Property

    Property pClientes() As List(Of Integer)
        Get
            Return Clientes
        End Get
        Set(ByVal value As List(Of Integer))
            Clientes = value
        End Set
    End Property

    Property pindice() As Integer
        Get
            Return IndiceL
        End Get
        Set(ByVal value As Integer)
            IndiceL = value
        End Set
    End Property

    Public Property pAbrirTab() As Integer
        Get
            Return AbrirTab
        End Get
        Set(ByVal value As Integer)
            AbrirTab = value
        End Set
    End Property

    Public Property pidUbicacion() As Integer
        Get
            Return iidubicacionP
        End Get
        Set(ByVal value As Integer)
            iidubicacionP = value
        End Set
    End Property

    Private Sub GestionClientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Cambios Then
            If MsgBox("Se perderán los cambios. ¿Salir de todos modos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        ElseIf CambiosFacturacion Then
            If MsgBox("Se perderán los cambios en datos de facturación. ¿Salir de todos modos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If

        ElseIf CambiosDireccion Then
            If MsgBox("Se perderán los cambios en datos de dirección. ¿Salir de todos modos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If

        ElseIf CambiosContacto Then
            If MsgBox("Se perderán los cambios en datos de contacto. ¿Salir de todos modos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub consultaClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            iidUsuario = Inicio.vIdUsuario
            desktopsize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            If desktopsize.Height < 850 Then
                Me.Height = desktopsize.Height - 50
            Else
                Me.Height = 800
            End If

            'PERMISOS 
            Dim funcPE As New FuncionesPersonal
            Vvercostes = funcPE.vercostes(iidUsuario)
            VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
            GestionaComisiones = funcPE.Permiso(iidUsuario, "AsignacionComisiones")
            If Not GestionaComisiones Then tbComisiones.Parent = Nothing
            semaforo = False
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info
            bGuardar.Enabled = Not vSoloLectura
            colorInactivo = Color.Gray
            colorCabecera = Color.Red
            ckActivoU.Checked = True
            Call introducirTiposPago()
            Call introducirMediosPago()
            Call introducirDepartamentos()
            Call IntroducirResponsables()
            Call IntroducirTiposUbicacion()
            Call introducirMonedas()
            Call introducirPaises()
            Call introducirIdiomas()
            Call introducirTransporte()
            Call introducirTiposIVA()
            Call introducirTiposRetencion()
            Call introducirBancos()
            Call introducirTiposValorado()
            Call introducirEstadosPedido()
            Call introducirEstadosOferta()
            Call introducirEstadosProforma()
            Call introducirEstadosAlbaran()
            Call introducirEstadosFactura()
            Call IntroducirTiposArticulo()
            Call IntroducirSubTiposArticulo()
            OrdenComisiones = "DOC.numFactura"
            DireccionComisiones = "DESC"
            If iidCliente = 0 Then
                Me.Text = "NUEVO CLIENTE"
                'bBuscar.Visible = False
                Call borrargeneral()
                tbcontactos.Parent = Nothing
                tbfacturacion.Parent = Nothing
                bSubir.Visible = False
                bBajar.Visible = False
                tbOFertas.Parent = Nothing
                tbProformas.Parent = Nothing
                tbPedidos.Parent = Nothing
                tbAlbaranes.Parent = Nothing
                tbFacturas.Parent = Nothing
                tbArticulosVendidos.Parent = Nothing
            Else

                If Clientes Is Nothing Then
                    bSubir.Visible = False
                    bBajar.Visible = False
                Else
                    If Clientes.Count > 0 Then
                        bSubir.Visible = True
                        bBajar.Visible = True
                    Else
                        bSubir.Visible = False
                        bBajar.Visible = False
                    End If
                End If

                Me.Text = "GESTIÓN DE CLIENTE  " & nombrecomercial.Text
            End If

            Call CargarCliente()
            If AbrirTab <> -1 Then
                tbdatos.SelectedIndex = AbrirTab
                If iidCliente > 0 Then
                    If AbrirTab = 2 Then
                        Call ValidarGeneral()
                        Call ValidarFacturacion()
                    End If
                    If AbrirTab = 1 Then
                        If iidubicacionP > 0 Then
                            Dim dtsU As datosUbicacion = funcU.mostrar1(iidubicacionP)
                            cbDirecciones.Text = dtsU.gTipoUbicacion & ": " & dtsU.glocalidad & ", " & dtsU.gdireccion
                            'cbDirecciones.Text = funcU.TextoComp(iidubicacionP)
                        End If
                    End If
                End If
            End If
            Cambios = False
            CambiosFacturacion = False
            CambiosContacto = False
            CambiosDireccion = False
            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GestionClientes_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = Ancho
        If Me.Height < 700 Then Me.Height = 700
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub CargarCliente()
        semaforo = False
        Call borrargeneral()
        'If idCliente.Text <> "" And idCliente.Text <> "0" Then
        '    ' tbdatos.Enabled = True
        'End If
        If iidCliente = 0 Or iidCliente = -1 Then
            'iidCliente = funcCL.NuevoidCliente
            codCli.Text = funcCL.NuevocodCli
        Else
            Call CargarDatosCliente()
            Call CargarContactos()
            Call CargarUbicaciones()
            Call CargarFacturacion()
            lvDirecciones.Items(0).Focused = True
            lvDirecciones.Items(0).Selected = True
        End If
        semaforo = True

        Call CargarDireccion()
        Call LimpiarBusquedaArticulo()
        Call CargarlvArtVendidos()
        Call introducirAnyosPedido()
        Call BusquedaPedidos()
        Call introducirAnyosOferta()
        Call BusquedaOfertas()
        Call introducirAnyosProforma()
        Call BusquedaProformas()
        Call introducirAnyosAlbaran()
        Call BusquedaAlbaranes()
        Call introducirAnyosFactura()
        Call BusquedaFacturas()
        If GestionaComisiones Then
            Call InicializarComisiones()
            Call BusquedaComisiones()
            Call ActualizarLVCambiosComisiones()
        End If
        Cambios = False
        CambiosFacturacion = False
        CambiosContacto = False
        CambiosDireccion = False
    End Sub

    Private Sub InicializarComisiones()
        dtpComisionesDesde.Value = CDate("1-1-" & Now.Year)
        dtpComisionesHasta.Value = funcF.buscaUltimoDia(iidCliente)
        'ckLiquidados.Checked = False
    End Sub

    Private Sub borrargeneral()
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""

        If VerClientesPropios Then
            cbResponsable.Text = funcPE.campoNombreyApellidos(iidUsuario)
        Else
            cbResponsable.Text = ""
            cbResponsable.SelectedIndex = -1
        End If

        dtpFechaAlta.Value = Now.Date
        dtpFechaBaja.Value = Now.Date
        dtpFechaBaja.Enabled = False
        ckActivo.Checked = True
        nif.Text = ""
        web.Text = ""
        observaciones.Text = ""
        ObservacionesProd.Text = ""

        G_AGeneral = "G"
        lvContactos.Items.Clear()
        Call Limpiarcontactos()
        lvBancos.Items.Clear()
        Call Limpiarfacturacion()
        Call limpiarCliente()
        lvDirecciones.Items.Clear()
        Call LimpiarDirecciones()
        ep1.Clear()
        ep2.Clear()
    End Sub

    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))

        For Each item As IDComboBox In lista
            cbResponsable.Items.Add(item)
        Next
        If VerClientesPropios Then
            cbResponsable.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbResponsable.SelectedIndex = 0
            End If
        Else
            cbResponsable.SelectedIndex = -1
        End If

    End Sub



    Private Sub limpiarCliente()
        dtpFechaAlta.Value = Now.Date
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""
        If VerClientesPropios Then
            cbResponsable.Text = funcPE.campoNombreyApellidos(iidUsuario)
        Else
            cbResponsable.Text = ""
            cbResponsable.SelectedIndex = -1
        End If
        codContable.Text = ""
        'idCliente.Text = 0
        nif.Text = ""
        web.Text = ""
        observaciones.Text = ""
        ObservacionesProd.Text = ""

        G_AGeneral = "G"


    End Sub



#End Region

#Region "DIRECCIONES"

    Private Sub LimpiarDirecciones()
        cbTipoU.Text = funcTU.PorDefectoCli()
        Direccion.Text = ""
        codPostal.Text = ""
        cbLocalidad.Text = ""
        cbProvincia.Text = ""
        cbPaisU.Text = "ESPAÑA"
        espUbic = True
        Call introducirProvincias()
        emailU.Text = ""
        TelefonoU1.Text = ""
        TelefonoU2.Text = ""
        faxU.Text = ""
        observacioneU.Text = ""
        HorarioU.Text = ""
        subCliente.Text = ""
        iidUbicacion = 0
        indiceDirecciones = -1
        ckActivoU.Enabled = True
        dtpFechaAltaU.Value = Now.Date
        dtpFechaBajaU.Value = Now.Date
        dtpFechaBajaU.Visible = False
        lbBajaU.Visible = False
        If DI.Portes = "P" Then cbPortes.Text = "PAGADOS"
        If DI.Portes = "D" Then cbPortes.Text = "DEBIDOS"
        If DI.Portes = "I" Then cbPortes.Text = "INC.FRA."
        'If DI.Portes = "P" Then
        '    rbPagados.Checked = True
        '    rbDebidos.Checked = False
        'Else
        '    rbPagados.Checked = False
        '    rbDebidos.Checked = True
        'End If
        cbIdioma.SelectedItem = DI.Idioma
        cbTransporte.Text = ""
        cbTransporte.SelectedIndex = -1
        G_AUbicacion = "G"
        CambiosDireccion = False
    End Sub

    Private Sub CargarDireccion()
        If lvDirecciones.SelectedItems.Count > 0 Then
            ep1.Clear()
            ep2.Clear()
            indiceDirecciones = lvDirecciones.SelectedIndices(0)
            iidUbicacion = lvDirecciones.Items(indiceDirecciones).Text
            Dim dts As datosUbicacion = funcU.mostrar1(iidUbicacion)
            cbTipoU.Text = dts.gTipoUbicacion
            dtpFechaAltaU.Value = dts.gfechaAlta
            ckActivoU.Checked = dts.gActivo
            dtpFechaBajaU.Value = dts.gfechaBaja
            dtpFechaBajaU.Visible = Not dts.gActivo
            lbBajaU.Visible = Not dts.gActivo
            If dts.gidTransporte > 0 Then
                cbTransporte.Text = dts.gAgenciaTransporte
            Else
                cbTransporte.Text = dts.gTransporte
            End If
            Direccion.Text = dts.gdireccion
            subCliente.Text = dts.gSubCliente
            ckNoMostrarCliente.Checked = dts.gNoMuestraCliente
            If dts.gPortes = "P" Then cbPortes.Text = "PAGADOS"
            If dts.gPortes = "D" Then cbPortes.Text = "DEBIDOS"
            If dts.gPortes = "I" Then cbPortes.Text = "INC.FRA."
            'If dts.gPortes = "P" Then
            '    rbPagados.Checked = True
            '    rbDebidos.Checked = False
            'Else
            '    rbPagados.Checked = False
            '    rbDebidos.Checked = True
            'End If
            'cbTransporte.Text = dts.gTransporte
            cbProvincia.Text = dts.gprovincia
            cbLocalidad.Text = dts.glocalidad
            cbPaisU.Text = dts.gPais
            cbIdioma.Text = dts.gIdioma
            codPostal.Text = dts.gcodpostal
            observacioneU.Text = dts.gObservaciones
            HorarioU.Text = dts.ghorario
            TelefonoU1.Text = funcTel.Mostrar1(iidUbicacion, 0, 1, 1)
            TelefonoU2.Text = funcTel.Mostrar1(iidUbicacion, 0, 1, 2)
            faxU.Text = funcTel.Mostrar1(iidUbicacion, 0, 3, 1)
            emailU.Text = funcMail.MostrarUbicacionStr(iidUbicacion, True)
            G_AUbicacion = "A"
            CambiosDireccion = False
        End If
    End Sub

    Private Sub CargarUbicaciones()
        Dim lista As List(Of datosUbicacion) = funcU.mostrarCli(iidCliente, True, 0, 1, 0, 0, 0, 0)
        Dim dts As datosUbicacion
        lvDirecciones.Items.Clear()
        For Each dts In lista
            Call NuevaLineaDirecciones(dts)
        Next

    End Sub

    Private Sub NuevaLineaDirecciones(ByVal dts As datosUbicacion)
        With lvDirecciones.Items.Add(dts.gidUbicacion)
            .SubItems.Add(dts.gSubCliente)
            .SubItems.Add(dts.gdireccion)
            .SubItems.Add(dts.gcodpostal)
            .SubItems.Add(dts.glocalidad)
            .SubItems.Add(dts.gprovincia)
            .SubItems.Add(dts.gPais)

        End With
    End Sub

    Private Sub ActualizaLineaDirecciones(ByVal dts As datosUbicacion)
        With lvDirecciones.Items(indiceDirecciones)
            .SubItems(1).Text = dts.gSubCliente
            .SubItems(2).Text = dts.gdireccion
            .SubItems(3).Text = dts.gcodpostal
            .SubItems(4).Text = dts.glocalidad
            .SubItems(5).Text = dts.gprovincia
            .SubItems(6).Text = dts.gPais '  funcPA.encuentraPais(dts.gidPais)
        End With
    End Sub

    Private Sub introducirPaises()
        Try
            Dim lista As List(Of datosPais) = funcPA.mostrar
            Dim dts As datosPais
            For Each dts In lista
                cbPaisU.Items.Add(dts) 'New IDComboBox(dts.gPais, dts.gidPais))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirProvincias()
        Try
            cbProvincia.Items.Clear()
            If cbPaisU.SelectedIndex <> -1 Then
                Dim func As New funcionesProvincia
                Dim lista As List(Of datosProvincia) = func.mostrar(cbPaisU.SelectedItem.gidPais)
                Dim dts As datosProvincia
                For Each dts In lista
                    cbProvincia.Items.Add(New IDComboBox(dts.gProvincia, dts.gidProvincia))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IntroducirTiposUbicacion()
        Try
            cbTipoU.Items.Clear()
            Dim lista As List(Of DatosTipoUbicaciones) = funcTU.MostrarTU(0, 1, 0, 0, 0, 0, 0)
            Dim dts As DatosTipoUbicaciones
            For Each dts In lista
                cbTipoU.Items.Add(New IDComboBox(dts.gTipoUbicacion, dts.gidTipoUbicacion))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirMonedas()
        Try
            cbMoneda.Items.Clear()
            Dim lista As List(Of DatosMoneda) = funcMO.Mostrar()
            For Each dts As DatosMoneda In lista
                cbMoneda.Items.Add(New IDComboBox(dts.gDIVISA, dts.gcodMoneda))
            Next
            cbMoneda.Text = funcMO.CampoDivisa("EU")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirIdiomas()
        Try
            cbIdioma.Items.Clear()
            Dim lista As List(Of datosIdioma) = funcID.mostrar()
            For Each dts As datosIdioma In lista
                cbIdioma.Items.Add(New IDComboBox(dts.gIdioma, dts.gidIdioma))
            Next
            cbIdioma.Text = DI.Idioma.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirTransporte()
        Try
            cbTransporte.Items.Clear()
            cbTransporte.Items.Add(New IDComboBox("SUS MEDIOS", -1))
            cbTransporte.Items.Add(New IDComboBox("NUESTROS MEDIOS", -2))
            Dim lista As List(Of IDComboBox) = funcPR.Transportes
            For Each t As IDComboBox In lista
                cbTransporte.Items.Add(t)
            Next
            cbPortes.Items.Clear()
            cbPortes.Items.Add("DEBIDOS")
            cbPortes.Items.Add("INC.FRA.")
            cbPortes.Items.Add("PAGADOS")
            cbPortes.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GuardarDireccion() As Boolean
        Dim validar As Boolean = True
        If Direccion.Text = "" Then
            validar = False
            'MsgBox("Se ha de introducir una dirección.")
            ep1.SetError(Direccion, "Se ha de especificar una dirección")
        End If
        If cbTipoU.SelectedIndex = -1 Then
            validar = False
            'MsgBox("Se ha de seleccionar el tipo de dirección.")
            ep1.SetError(cbTipoU, "Se ha de seleccionar un tipo de dirección")
        Else
            If G_AUbicacion = "G" Then
                If funcTU.EsFiscal(cbTipoU.SelectedItem.itemdata) Then
                    If funcU.ExisteFiscal(iidCliente, 0) Then
                        validar = False
                        ep1.SetError(cbTipoU, "Ya existe una dirección fiscal")
                    End If
                End If
            End If
        End If
        If cbPaisU.SelectedIndex = -1 Then
            validar = False
            'MsgBox("Se ha de seleccionar un país.")
            ep1.SetError(cbPaisU, "Se ha de seleccionar un país")
        End If

        If validar Then

            Dim dts As New datosUbicacion
            dts.gidUbicacion = iidUbicacion
            dts.gcodpostal = codPostal.Text
            dts.gdireccion = Direccion.Text
            dts.gSubCliente = subCliente.Text
            dts.gNoMuestraCliente = ckNoMostrarCliente.Checked
            dts.gfechaAlta = dtpFechaAltaU.Value.Date
            dts.gActivo = ckActivoU.Checked
            dts.gfechaBaja = dtpFechaBajaU.Value.Date
            dts.ghorario = HorarioU.Text
            dts.gidCliente = iidCliente
            dts.gidProveedor = 0
            dts.gidIdioma = If(cbIdioma.SelectedIndex = -1, 0, cbIdioma.SelectedItem.itemdata)
            dts.gidPais = cbPaisU.SelectedItem.gidpais
            dts.gidTipoUbicacion = cbTipoU.SelectedItem.itemdata
            dts.glocalidad = cbLocalidad.Text
            dts.gObservaciones = observacioneU.Text
            dts.gprovincia = cbProvincia.Text
            dts.gTipoUbicacion = cbTipoU.Text
            If cbTransporte.SelectedIndex = -1 Then
                'Se guarda el transporte por defecto. Si seleccionamos una empresa (proveedor) guardamos el idProveedor. Sino guardamos lo que esté escrito.
                dts.gidTransporte = 0
                dts.gTransporte = cbTransporte.Text
            Else
                If cbTransporte.SelectedItem.itemdata < 0 Then
                    dts.gidTransporte = 0
                    dts.gTransporte = cbTransporte.Text
                Else
                    dts.gidTransporte = cbTransporte.SelectedItem.itemdata
                    dts.gTransporte = ""
                End If

            End If
            'dts.gPortes = If(rbPagados.Checked, "P", "D")
            If dts.gPortes = "PAGADOS" Then
                dts.gPortes = "P"
            ElseIf cbPortes.Text = "DEBIDOS" Then
                dts.gPortes = "D"
            Else
                dts.gPortes = "I"
            End If
            If G_AUbicacion = "A" Then
                funcU.actualizar(dts)
                Call ActualizaLineaDirecciones(dts)
            Else
                iidUbicacion = funcU.insertar(dts)
                dts.gidUbicacion = iidUbicacion
                Call NuevaLineaDirecciones(dts)
            End If

            funcTel.borrarUbicacion(iidUbicacion)
            If TelefonoU1.Text <> "" Then funcTel.insertar(New DatosTelefono(0, iidCliente, iidUbicacion, 0, 1, TelefonoU1.Text, 1))
            If TelefonoU2.Text <> "" Then funcTel.insertar(New DatosTelefono(0, iidCliente, iidUbicacion, 0, 1, TelefonoU2.Text, 2))
            If faxU.Text <> "" Then funcTel.insertar(New DatosTelefono(0, iidCliente, iidUbicacion, 0, 3, faxU.Text, 1))
            funcMail.borrarUbicacion(iidUbicacion)
            If emailU.Text <> "" Then validar = funcMail.insertar(New DatosMail(0, iidCliente, iidUbicacion, 0, 0, emailU.Text, 1))

            Call LimpiarDirecciones()
            Call CargarDirecciones()
            CambiosDireccion = False
        End If
        Return validar
    End Function

    Private Sub cbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProvincia.SelectedIndexChanged
        'Al seleccionar una provincia, recargaremos la lista de poblaciones
        cbLocalidad.Items.Clear()
        If cbProvincia.SelectedIndex <> -1 Then
            Try
                Dim func As New funcionesPoblacion
                Dim linea As DataRow
                Dim dt As DataTable = func.buscaPoblaciones(cbProvincia.SelectedItem.Itemdata())
                For Each linea In dt.Rows
                    cbLocalidad.Items.Add(New IDComboBox(linea("poblacion"), linea("postal")))
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub lvDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDirecciones.Click, lvDirecciones.SelectedIndexChanged
        cambioTipoDireccion = False
        Call CargarDireccion()
    End Sub

    Private Sub bVerPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerPais.Click
        Dim pais As String = cbPaisU.Text
        Dim GG As New GestionPaises
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirPaises()
        cbPaisU.Text = pais
        If cbPaisU.SelectedIndex = -1 Then
            cbPaisU.Text = ""
        End If
    End Sub

    Private Sub cbPaisUbicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaisU.SelectedIndexChanged
        If semaforo Then
            introducirProvincias()
            espUbic = If(cbPaisU.SelectedIndex = -1, True, (cbPaisU.SelectedItem.gidPais = 1)) '(cbPaisU.Text = "ESPAÑA" Or cbPaisU.Text = "ESPANYA")
            CambiosDireccion = True
        End If
    End Sub

    Private Sub ckActivoU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckActivoU.CheckedChanged
        If semaforo Then
            If ckActivoU.Checked Then
                dtpFechaBajaU.Visible = False
                dtpFechaBajaU.Enabled = False
                lbBajaU.Visible = False
            Else
                dtpFechaBajaU.Visible = True
                dtpFechaBajaU.Enabled = True
                lbBajaU.Visible = True
            End If
            CambiosDireccion = True
        End If
    End Sub

    Private Sub cbLocalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLocalidad.SelectedIndexChanged
        'Al seleccionar una población, se escribe el código postal correspondiente a la población
        If cbLocalidad.SelectedIndex <> -1 Then

            Dim cpi As Integer = cbLocalidad.SelectedItem.itemdata()
            If cpi < 10000 Then
                codPostal.Text = "0" & cpi.ToString
            Else
                codPostal.Text = cpi.ToString
            End If
            CambiosDireccion = True
        End If

    End Sub

    Private Sub cbTipoU_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbTipoU.MouseClick
        cambioTipoDireccion = True
    End Sub

    Private Sub cbTipoU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoU.SelectedIndexChanged, TelefonoU1.TextChanged, TelefonoU2.TextChanged, faxU.TextChanged, HorarioU.TextChanged, observacioneU.TextChanged, emailU.TextChanged, codPostal.TextChanged, Direccion.TextChanged, subCliente.TextChanged, dtpFechaBajaU.ValueChanged, dtpFechaAltaU.ValueChanged, cbPortes.SelectedIndexChanged, ckNoMostrarCliente.CheckedChanged, cbIdioma.SelectedIndexChanged, cbTransporte.SelectedIndexChanged
        'Detectar cambios en la pestaña dirección
        CambiosDireccion = semaforo
        'For Each item As ListViewItem In lvDirecciones.SelectedItems
        '    item.Selected = False
        'Next
    End Sub




#End Region

#Region "CONTACTOS"

    Private Sub CargarDirecciones()
        semaforo = False
        cbDirecciones.Items.Clear()
        Dim Lista As List(Of datosUbicacion) = funcU.mostrarCli(iidCliente, 1, 0, 1, 0, 0, 0, 0)
        For Each dts As datosUbicacion In Lista
            cbDirecciones.Items.Add(New IDComboBox(dts.gTipoUbicacion & ": " & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
        Next
        If Lista.Count = 1 Then cbDirecciones.SelectedIndex = 0 'Si solo hay uno, lo ponemos
        semaforo = True
    End Sub

    Private Sub Limpiarcontactos()
        nombrecontacto.Text = ""
        apellidoscontacto.Text = ""
        cargocontacto.Text = ""
        cbDepartamento.Text = ""
        cbDepartamento.SelectedIndex = -1
        cbDirecciones.Text = ""
        cbDirecciones.SelectedIndex = -1
        emailContacto.Text = ""
        TelefonoContacto.Text = ""
        MovilContacto.Text = ""
        ObservacionesContacto.Text = ""
        iidContacto = 0
        indiceContactos = -1
        G_AContacto = "G"
        CambiosContacto = False
    End Sub

    Private Sub CargarContactos()
        lvContactos.Items.Clear()
        Dim lista As List(Of datosContacto) = funcCT.mostrarCli(iidCliente)
        Dim dts As datosContacto
        For Each dts In lista
            Call NuevaLineaContactos(dts)
        Next
    End Sub

    Private Sub introducirDepartamentos()
        Try
            cbDepartamento.Items.Clear()
            Dim lista As List(Of datosDepartamento) = funcDT.mostrar
            Dim dts As datosDepartamento
            For Each dts In lista
                cbDepartamento.Items.Add(New IDComboBox(dts.gDepartamento, dts.gidDepartamento))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GuardarContacto() As Boolean
        Try
            Dim validar As Boolean = True
            If nombrecontacto.Text = "" Then
                validar = False
                'MsgBox("Se ha de introducir un nombre de contacto.")
                ep1.SetError(nombrecontacto, "Se ha de introducir un nombre de contacto")
            End If
            If cbDirecciones.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDirecciones, "Se ha de seleccionar una dirección")
            End If
            If validar Then
                Dim dts As New datosContacto
                dts.gidContacto = iidContacto
                dts.gidUbicacion = cbDirecciones.SelectedItem.itemdata
                dts.gidCliente = iidCliente
                dts.gidProveedor = 0
                dts.gnombre = nombrecontacto.Text
                dts.gapellidos = apellidoscontacto.Text
                If cbDepartamento.SelectedIndex > -1 Then
                    dts.gidDepartamento = cbDepartamento.SelectedItem.itemdata
                    dts.gDepartamento = cbDepartamento.Text
                Else
                    dts.gidDepartamento = 0
                    dts.gDepartamento = ""
                End If
                dts.gCargo = cargocontacto.Text
                dts.gObservaciones = ObservacionesContacto.Text

                If indiceContactos = -1 Then
                    iidContacto = funcCT.insertar(dts)
                    dts.gidContacto = iidContacto
                Else
                    funcCT.actualizar(dts)
                End If

                'Guardar Mail
                funcMail.borrarContacto(iidContacto)
                If emailContacto.Text <> "" Then
                    funcMail.insertar(New DatosMail(0, iidCliente, dts.gidUbicacion, iidContacto, 0, emailContacto.Text, 1))
                End If
                'Guardar teléfonos
                funcTel.borrarContacto(iidContacto)
                funcTel.insertar(New DatosTelefono(0, iidCliente, dts.gidUbicacion, iidContacto, 1, TelefonoContacto.Text, 1))
                funcTel.insertar(New DatosTelefono(0, iidCliente, dts.gidUbicacion, iidContacto, 2, MovilContacto.Text, 2))
                If indiceContactos = -1 Then
                    NuevaLineaContactos(dts)
                Else
                    ActualizaLineaContactos(dts)
                End If
                Call Limpiarcontactos()
                CambiosContacto = False
            End If
            Return validar

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub lvContactos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvContactos.Click, lvContactos.SelectedIndexChanged
        'Pasar dato del código de ubicación
        Try
            If lvContactos.Items.Count > 0 And lvContactos.SelectedItems.Count > 0 Then
                iidContacto = lvContactos.SelectedItems.Item(0).Text
                indiceContactos = lvContactos.SelectedIndices(0)
                'Call Limpiarcontactos()
                Dim dts As datosContacto = funcCT.mostrar1(iidContacto)
                Dim dtsU As datosUbicacion = funcU.mostrar1(dts.gidUbicacion)
                cbDirecciones.Text = dtsU.gTipoUbicacion & ": " & dtsU.glocalidad & ", " & dtsU.gdireccion
                nombrecontacto.Text = dts.gnombre
                apellidoscontacto.Text = dts.gapellidos
                cbDepartamento.Text = dts.gDepartamento
                cargocontacto.Text = dts.gCargo
                ObservacionesContacto.Text = dts.gObservaciones
                TelefonoContacto.Text = funcTel.Mostrar1(0, iidContacto, 1, 1)
                MovilContacto.Text = funcTel.Mostrar1(0, iidContacto, 2, 1)
                emailContacto.Text = funcMail.MostrarContactoStr(iidContacto)
                G_AContacto = "A"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub NuevaLineaContactos(ByVal dts As datosContacto)
        With lvContactos.Items.Add(dts.gidContacto)
            .SubItems.Add(dts.gnombre)
            .SubItems.Add(dts.gapellidos)
            .SubItems.Add(funcTel.MostrarContactoStr(dts.gidContacto))
            .SubItems.Add(dts.gDepartamento)
            .SubItems.Add(dts.gCargo)
            .SubItems.Add(funcMail.MostrarContactoStr(dts.gidContacto))
        End With
    End Sub

    Private Sub ActualizaLineaContactos(ByVal dts As datosContacto)
        With lvContactos.Items(indiceContactos)
            .SubItems(1).Text = dts.gnombre
            .SubItems(2).Text = dts.gapellidos
            .SubItems(3).Text = funcTel.MostrarContactoStr(dts.gidContacto)
            .SubItems(4).Text = dts.gDepartamento
            .SubItems(5).Text = dts.gCargo
            .SubItems(6).Text = funcMail.MostrarContactoStr(dts.gidContacto)
        End With
    End Sub

    Private Sub cbDirecciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDirecciones.SelectedIndexChanged, cargocontacto.TextChanged, emailContacto.TextChanged, MovilContacto.TextChanged, TelefonoContacto.TextChanged, cbDepartamento.SelectedIndexChanged, apellidoscontacto.TextChanged, nombrecontacto.TextChanged, ObservacionesContacto.TextChanged
        CambiosContacto = semaforo
    End Sub

#End Region

#Region "FACTURACION"

    Private Sub CargarFacturacion()
        Try
            Dim dts As datosfacturacion = funcFA.mostrarCli(iidCliente)
            If dts.gidCliente = iidCliente Then 'Si se ha encontrado facturación de este Cliente, caqrgamos los datos
                ep1.Clear()
                ep2.Clear()
                iidFacturacion = dts.gidFacturacion
                cbTipoPago.Text = dts.gTipoPago
                cbMedioPago.Text = dts.gMedioPago
                cbDiaPago1.Text = dts.gDiaPago1
                cbDiaPago2.Text = dts.gDiaPago2
                'ckAlbaranValorado.Checked = dts.gAlbaranValorado
                cbValorado.Text = dts.gTipoValorado
                ckExentoPagosAgosto.Checked = dts.gExentoPagosAgosto
                cbMoneda.Text = dts.gDivisa
                ProntoPago.Text = dts.gProntoPago
                Descuento.Text = dts.gDescuento
                Descuento2.Text = dts.gDescuento2
                cbTipoIVA.Text = dts.gNombreTipoIVA & " " & dts.gTipoIVA & "%"
                ckRecargoEquivalencia.Checked = dts.gRecargoEquivalencia
                RecargoEq.Visible = ckRecargoEquivalencia.Checked
                lbRecargoEq.Visible = ckRecargoEquivalencia.Checked
                RecargoEq.Text = dts.gTipoRecargoEq
                cbRetencion.Text = dts.gNombreTipoRet & " " & dts.gTipoRetencion & "%"
                ObservacionesF.Text = dts.gObservaciones
                dts.gCuentas = funcCB.Mostrar(dts.gidFacturacion, False) 'Recargamos los bancos para que aparezcan los inactivos
                lvBancos.Items.Clear()
                For Each dtsB As DatosCuentaBancaria In dts.gCuentas
                    Call nuevaLineaBanco(dtsB)
                Next
            Else
                iidFacturacion = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub nuevaLineaBanco(ByVal dtsB As DatosCuentaBancaria)

        With lvBancos.Items.Add(dtsB.gidCuentaBanco)
            .SubItems.Add(dtsB.gBanco)
            .SubItems.Add(dtsB.gIBAN)
            .SubItems.Add(dtsB.gidBanco)
            .SubItems.Add(dtsB.gCodigoEU)
            .SubItems.Add(dtsB.gCodigoBanco)
            .SubItems.Add(dtsB.gCodigoOficina)
            .SubItems.Add(dtsB.gCodigoDC)
            .SubItems.Add(dtsB.gCodigoCuenta)
            .SubItems.Add(dtsB.gSWIFT_BIC)
            If dtsB.gActivo Then
                .ForeColor = Color.Black
            Else
                .ForeColor = colorInactivo
            End If
        End With
    End Sub

    Private Sub ActualizarLineaBanco(ByVal dtsB As DatosCuentaBancaria)
        If indiceB > -1 Then
            With lvBancos.Items(indiceB)
                .SubItems(0).Text = dtsB.gidCuentaBanco
                .SubItems(1).Text = dtsB.gBanco
                .SubItems(2).Text = dtsB.gIBAN
                .SubItems(3).Text = dtsB.gidBanco
                .SubItems(4).Text = dtsB.gCodigoEU
                .SubItems(5).Text = dtsB.gCodigoBanco
                .SubItems(6).Text = dtsB.gCodigoOficina
                .SubItems(7).Text = dtsB.gCodigoDC
                .SubItems(8).Text = dtsB.gCodigoCuenta
                .SubItems(9).Text = dtsB.gSWIFT_BIC
                If dtsB.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub

    Private Sub introducirdiapactado()
        Dim i As Integer
        For i = 1 To 31
            cbDiaPago1.Items.Add(i)
            cbDiaPago2.Items.Add(i)
        Next
    End Sub

    Private Sub introducirTiposPago()
        Try
            cbTipoPago.Items.Clear()
            Dim lista As List(Of datosTipoPago) = funcTP.mostrar(True)
            Dim dts As datosTipoPago
            For Each dts In lista
                cbTipoPago.Items.Add(New IDComboBox(dts.gTipoPago, dts.gidTipoPago))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirMediosPago()
        Try
            cbMedioPago.Items.Clear()
            Dim lista As List(Of datosMedioPago) = funcMP.mostrar
            Dim dts As datosMedioPago
            For Each dts In lista
                cbMedioPago.Items.Add(New IDComboBox(dts.gMedioPago, dts.gidMedioPago))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirTiposIVA()
        Try
            cbTipoIVA.Items.Clear()
            Dim lista As List(Of DatosTipoIVA) = funcTI.Mostrar(True)
            Dim dts As DatosTipoIVA
            For Each dts In lista
                'cbTipoIVA.Items.Add(New IDComboBox(dts.gNombre & " " & dts.gTipoIVA & "%", dts.gidTipoIVA))
                cbTipoIVA.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirTiposRetencion()
        Try
            cbRetencion.Items.Clear()
            Dim lista As List(Of DatosTipoRetencion) = funcTR.Mostrar(True)
            Dim dts As DatosTipoRetencion
            For Each dts In lista
                cbRetencion.Items.Add(New IDComboBox(dts.gNombre & " " & dts.gTipoRetencion & "%", dts.gidTipoRetencion))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirBancos()
        Try
            cbBanco.Items.Clear()
            Dim lista As List(Of DatosBanco) = funcBA.Mostrar(True)
            Dim dts As DatosBanco
            For Each dts In lista
                cbBanco.Items.Add(New IDComboBox(dts.gBanco, dts.gidBanco))
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

    Private Sub Limpiarfacturacion()
        cbTipoPago.Text = ""
        cbTipoPago.SelectedIndex = -1
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        ProntoPago.Text = 0
        Descuento.Text = 0
        Descuento2.Text = 0
        cbValorado.Text = "" 'DI.TipoValorado
        cbTipoIVA.Text = DI.TipoIVA.ToString
        cbRetencion.Text = DI.TipoRetencion.ToString
        ckRecargoEquivalencia.Checked = False
        RecargoEq.Text = 0
        RecargoEq.Visible = Not ckRecargoEquivalencia.Checked
        cbDiaPago1.Text = 0
        cbDiaPago1.SelectedIndex = -1
        cbDiaPago2.Text = 0
        cbDiaPago2.SelectedIndex = -1
        ckExentoPagosAgosto.Checked = False
        ObservacionesF.Text = ""
        iidFacturacion = 0
        Call LimpiarBanco()
        lvBancos.Items.Clear()
        CambiosFacturacion = False
    End Sub

    Private Sub LimpiarBanco()
        ep1.Clear()
        codigoEU.Text = "ES"
        cbBanco.Text = ""
        cbBanco.SelectedIndex = -1
        codigobanco.Text = ""
        codigooficina.Text = ""
        codigodc.Text = ""
        codigocuenta.Text = ""
        IBAN.Text = ""
        SWIFT_BIC.Text = ""
        iidCuentaBanco = 0
        indiceB = -1
        ckActivoB.Checked = True
    End Sub

    Private Function GuardarFacturacion() As Boolean
        Try
            If ValidarFacturacion() Then
                Dim dts As New datosfacturacion
                dts.gcodMoneda = If(cbMoneda.SelectedIndex = -1, "EU", cbMoneda.SelectedItem.itemdata)
                dts.gProntoPago = ProntoPago.Text
                dts.gDescuento = Descuento.Text
                dts.gDescuento2 = Descuento2.Text
                dts.gidMedioPago = cbMedioPago.SelectedItem.itemdata
                dts.gidTipoPago = cbTipoPago.SelectedItem.itemdata
                dts.gDiaPago1 = cbDiaPago1.Text
                dts.gDiaPago2 = cbDiaPago2.Text
                'dts.gAlbaranValorado = ckAlbaranValorado.Checked
                dts.gExentoPagosAgosto = ckExentoPagosAgosto.Checked
                dts.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
                dts.gRecargoEquivalencia = ckRecargoEquivalencia.Checked
                dts.gidTipoRetencion = If(cbRetencion.SelectedIndex = -1, 0, cbRetencion.SelectedItem.itemdata)
                dts.gidFacturacion = iidFacturacion
                dts.gObservaciones = ObservacionesF.Text
                dts.gidCliente = iidCliente
                dts.gidProveedor = 0
                dts.gidTipoValorado = cbValorado.SelectedItem.gidtipoValorado
                Dim lista As New List(Of DatosCuentaBancaria)
                Dim dtsB As DatosCuentaBancaria
                Dim Orden As Integer = 1
                For Each item As ListViewItem In lvBancos.Items
                    dtsB = New DatosCuentaBancaria
                    dtsB.gidCuentaBanco = item.SubItems(0).Text
                    dtsB.gBanco = item.SubItems(1).Text
                    dtsB.gidFacturacion = iidFacturacion
                    dtsB.gidBanco = item.SubItems(3).Text
                    dtsB.gCodigoEU = item.SubItems(4).Text
                    dtsB.gCodigoBanco = item.SubItems(5).Text
                    dtsB.gCodigoOficina = item.SubItems(6).Text
                    dtsB.gCodigoDC = item.SubItems(7).Text
                    dtsB.gCodigoCuenta = item.SubItems(8).Text
                    dtsB.gIBAN = item.SubItems(2).Text
                    dtsB.gSWIFT_BIC = item.SubItems(9).Text
                    dtsB.gActivo = (item.ForeColor = Color.Black)
                    dtsB.gOrden = Orden
                    Orden = Orden + 1
                    lista.Add(dtsB)
                Next
                dts.gCuentas = lista
                If iidFacturacion = 0 Then  'Si existe la facturación se actualiza si no, se inserta
                    iidFacturacion = funcFA.insertar(dts)
                    dts.gidFacturacion = iidFacturacion
                Else
                    funcFA.actualizar(dts)
                End If
                lvBancos.Items.Clear()
                For Each dtsBA As DatosCuentaBancaria In dts.gCuentas
                    Call nuevaLineaBanco(dtsBA)
                Next
                Call LimpiarBanco()
                CambiosFacturacion = False
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function ValidarFacturacion() As Boolean
        Dim Validar As Boolean = True
        If cbMedioPago.SelectedIndex = -1 Then
            Validar = False
            'MsgBox("Se ha de seleccionar un medio de pago.")
            ep1.SetError(cbMedioPago, "Se ha de seleccionar un medio de pago")
        Else
            If funcMP.RequiereBanco(cbMedioPago.SelectedItem.itemdata) And lvBancos.Items.Count = 0 Then
                ep2.SetError(cbBanco, "Se ha de introducir algún banco para el modo de pago " & cbMedioPago.Text)
            End If
        End If
        If cbTipoPago.SelectedIndex = -1 Then
            Validar = False
            ' MsgBox("Se ha de seleccionar un tipo de pago.")
            ep1.SetError(cbTipoPago, "Se ha de seleccionar un tipo de pago")
        End If
        If cbMoneda.SelectedIndex = -1 Then
            Validar = False
            ep1.SetError(cbMoneda, "Se ha de seleccionar una moneda")
        End If
        If cbTipoIVA.SelectedIndex = -1 Then
            Validar = False
            ep1.SetError(cbTipoIVA, "Se ha de seleccionar una tipo de IVA")
        End If
        If cbValorado.SelectedIndex = -1 Then
            Validar = False
            ep1.SetError(cbValorado, "Se ha de seleccionar la valoración del albarán")
        End If
        Return Validar
    End Function

    Private Sub bMasBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMasBanco.Click

        Dim validar As Boolean = True

        codigoEU.Text = codigoEU.Text.PadRight(4, "0")
        codigobanco.Text = codigobanco.Text.PadLeft(4, "0")
        codigooficina.Text = codigooficina.Text.PadLeft(4, "0")
        codigodc.Text = codigodc.Text.PadLeft(2, "0")
        codigocuenta.Text = codigocuenta.Text.PadLeft(10, "0")

        If IBAN.Text.Length = 0 And Microsoft.VisualBasic.Left(codigoEU.Text, 2) = "ES" And codigoEU.TextLength = 4 Then
            IBAN.Text = codigoEU.Text & codigobanco.Text & codigooficina.Text & codigodc.Text & codigocuenta.Text
        End If
        If cbBanco.SelectedIndex = -1 Then
            ep1.SetError(cbBanco, "Debe seleccionar un banco")
            validar = False
        End If
        If IBAN.Text.Length < 2 Then
            validar = False
            ep1.SetError(IBAN, "Debe introducir el IBAN")
        ElseIf Not IBANValidacion(IBAN.Text) Then
            validar = False
            ep1.SetError(IBAN, "IBAN incorrecto")
        End If

        If validar Then
            Dim dts As New DatosCuentaBancaria
            dts.gidCuentaBanco = iidCuentaBanco
            dts.gidFacturacion = iidFacturacion
            dts.gidBanco = cbBanco.SelectedItem.itemdata
            dts.gCodigoEU = codigoEU.Text
            dts.gCodigoBanco = codigobanco.Text
            dts.gCodigoOficina = codigooficina.Text
            dts.gCodigoDC = codigodc.Text
            dts.gCodigoCuenta = codigocuenta.Text
            dts.gIBAN = IBAN.Text
            dts.gSWIFT_BIC = SWIFT_BIC.Text
            dts.gOrden = If(indiceB = -1, lvBancos.Items.Count + 1, indiceB + 1)
            dts.gActivo = ckActivoB.Checked
            dts.gBanco = cbBanco.Text
            If iidCuentaBanco = 0 Then
                funcCB.insertar(dts)
                Call nuevaLineaBanco(dts)
            Else
                If indiceB > -1 Then
                    funcCB.actualizar(dts)
                    Call ActualizarLineaBanco(dts)
                End If
            End If
            Call LimpiarBanco()
            ep1.Clear()
            CambiosFacturacion = True
        End If

    End Sub

    Private Sub lvBancos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBancos.Click, lvBancos.SelectedIndexChanged
        If lvBancos.SelectedItems.Count > 0 Then
            indiceB = lvBancos.SelectedIndices(0)
            With lvBancos.Items(indiceB)
                iidCuentaBanco = .Text
                cbBanco.Text = .SubItems(1).Text
                ckActivoB.Checked = (.ForeColor = Color.Black)
                IBAN.Text = .SubItems(2).Text
                SWIFT_BIC.Text = .SubItems(9).Text
                codigoEU.Text = .SubItems(4).Text
                codigobanco.Text = .SubItems(5).Text
                codigooficina.Text = .SubItems(6).Text
                codigodc.Text = .SubItems(7).Text
                codigocuenta.Text = .SubItems(8).Text
            End With

        End If
    End Sub

    Private Sub bMenosBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMenosBancos.Click
        If indiceB > -1 Then
            If MsgBox("¿Eliminar la cuenta seleccionada de la lista?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If funcCB.EnUso(lvBancos.Items(indiceB).Text, iidCliente) Then
                    If funcCB.borrar(iidCuentaBanco, iidCliente) = True Then
                        lvBancos.Items.RemoveAt(indiceB)
                        Call LimpiarBanco()
                        CambiosFacturacion = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub bLimpiaBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiaBanco.Click
        Call LimpiarBanco()
    End Sub

    Private Sub ckRecargoEquivalencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.CheckedChanged
        If semaforo Then
            RecargoEq.Visible = ckRecargoEquivalencia.Checked
            lbRecargoEq.Visible = ckRecargoEquivalencia.Checked
            If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then RecargoEq.Text = FormatNumber(cbTipoIVA.SelectedItem.gTiporecargoEq, 2)
            CambiosFacturacion = True
        End If
    End Sub

    Private Sub cbTipoIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoIVA.SelectedIndexChanged
        If semaforo Then
            If cbTipoIVA.SelectedIndex <> -1 Then
                RecargoEq.Text = cbTipoIVA.SelectedItem.gTipoRecargoEq 'funcTI.TipoRecargoEq(cbTipoIVA.SelectedItem.itemdata)
            End If
            CambiosFacturacion = True
        End If
    End Sub

    Private Sub cbBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBanco.SelectedIndexChanged

        If semaforo Then
            ' Private Sub cbBanco_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBanco.SelectionChangeCommitted
            If cbBanco.SelectedIndex <> -1 Then
                Dim dts As DatosBanco = funcBA.Mostrar1(cbBanco.SelectedItem.itemdata)
                SWIFT_BIC.Text = dts.gSWIFT_BIC
                codigobanco.Text = dts.gcodigoBanco
                If dts.gidPais = 1 Then
                    codigoEU.Enabled = True
                    codigobanco.Enabled = True
                    codigooficina.Enabled = True
                    codigodc.Enabled = True
                    codigocuenta.Enabled = True
                Else
                    codigoEU.Enabled = False
                    codigobanco.Enabled = False
                    codigooficina.Enabled = False
                    codigodc.Enabled = False
                    codigocuenta.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If cbMedioPago.SelectedIndex <> -1 And semaforo Then
            'gbBancos.Enabled = funcMP.RequiereBanco(cbMedioPago.SelectedItem.itemdata)
            gbBancos.Enabled = True
            CambiosFacturacion = True
        End If
    End Sub

    Private Sub bMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMoneda.Click
        Dim moneda As String = cbMoneda.Text
        Dim GG As New GestionCambioMoneda
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirMonedas()
        cbMoneda.Text = moneda
        If cbMoneda.SelectedIndex = -1 Then
            cbMoneda.Text = funcMO.CampoDivisa("EU")
        End If
    End Sub

    Private Sub bMediosPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMediosPago.Click
        Dim valor As String = cbMedioPago.Text
        Dim GG As New gestionmediodepago
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirMediosPago()
        cbMedioPago.Text = valor
        If cbMedioPago.SelectedIndex = -1 Then cbMedioPago.Text = ""
    End Sub

    Private Sub bTiposIVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposIVA.Click
        Dim valor As String = cbTipoIVA.Text
        Dim GG As New GestionTiposIVA
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirTiposIVA()
        cbMedioPago.Text = valor
        If cbMedioPago.SelectedIndex = -1 Then cbMedioPago.Text = ""
    End Sub

    Private Sub bTiposPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposPago.Click
        Dim tipopago As String = cbTipoPago.Text
        Dim GG As New gestiontipopago
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirTiposPago()
        cbTipoPago.Text = tipopago
        If cbTipoPago.SelectedIndex = -1 Then cbTipoPago.Text = ""
    End Sub

    Private Sub bTiposRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposRetencion.Click
        Dim retencion As String = cbRetencion.Text
        Dim GG As New GestionTiposRetencion
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirTiposRetencion()
        cbRetencion.Text = retencion
        If cbRetencion.SelectedIndex = -1 Then cbRetencion.Text = ""
    End Sub

    Private Sub bBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBancos.Click
        Dim Banco As String = cbBanco.Text
        Dim GG As New GestionBancos
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirBancos()
        cbBanco.Text = Banco
        If cbBanco.SelectedIndex = -1 Then cbBanco.Text = ""
    End Sub

    Private Sub ObservacionesF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObservacionesF.TextChanged, cbRetencion.SelectedIndexChanged, ckExentoPagosAgosto.CheckedChanged, cbDiaPago2.SelectedIndexChanged, cbDiaPago1.SelectedIndexChanged, cbTipoPago.SelectedIndexChanged, cbValorado.SelectedIndexChanged, Descuento2.TextChanged, Descuento.TextChanged, ProntoPago.TextChanged, cbMoneda.SelectedIndexChanged
        CambiosFacturacion = semaforo
    End Sub

#End Region

#Region "ARTICULOS VENDIDOS"


    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim funcTI As New FuncionesTiposArticulo
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
        Dim funcFA As New FuncionesFamilias
        Dim listaFA As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
        For Each dtsFA As DatosFamilia In listaFA
            If cbTipoContiene(dtsFA.gFamilia) Then
            Else
                cbTipo.Items.Add(New IDComboBox(dtsFA.gFamilia, 0))
            End If
        Next
    End Sub

    Private Function cbTipoContiene(ByVal literal As String) As Boolean
        For Each item In cbTipo.Items
            If UCase(item.ToString) = UCase(literal) Then Return True
        Next
        Return False
    End Function


    Private Sub IntroducirSubTiposArticulo()
        Dim funcT As New FuncionessubTiposArticulo
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcT.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next
        Dim funcSF As New FuncionessubFamilias
        Dim listaSF As List(Of String) = funcSF.Listar(True)
        For Each item In listaSF
            If cbSubTipo.Items.Contains(item) Then
            Else
                cbSubTipo.Items.Add(item)
            End If
        Next
    End Sub



    Private Sub LimpiarBusquedaArticulo()
        semaforo = False
        dtpArticulosVendidosDesde.Value = funcF.buscaPrimerDia(iidCliente)
        dtpArticulosVendidosHasta.Value = funcF.buscaUltimoDia(iidCliente)
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        semaforo = True
    End Sub

    Private Sub CargarlvArtVendidos()
        lvArticulosVendidos.Items.Clear()
        Dim sel As String
        sel = "select distinct CP.idArticulo, codArticulo, Articulo, ArticuloCli, codArticuloCli, subTipoArticulo,PP.codMoneda, "
        sel = sel & "case when CP.idArticulo=0 then  PrecioNetoUnitario else "
        sel = sel & "(select TOP 1 PrecioNetoUnitario from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli   and Facturas.idCliente = PP.idCliente order by Facturas.numFactura DESC,idConcepto DESC) end as UltimoPrecioNeto,   "
        sel = sel & "case when CP.idArticulo=0 then  CP.numFactura else "
        sel = sel & "(select TOP 1 Facturas.numFactura from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente order by Facturas.numFactura DESC) end as UltimaFactura, "
        sel = sel & "case when CP.idArticulo=0 then  PP.Fecha else "
        sel = sel & "(select TOP 1 Facturas.Fecha from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente order by Facturas.numFactura DESC) end as UltimaFecha, "

        sel = sel & "(select Top 1 Simbolo from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura left join Monedas ON Monedas.codMoneda = Facturas.codMoneda where Facturas.numFactura = CP.numFactura) as Simbolo,  "
        sel = sel & "case when CP.idArticulo=0 then CP.Cantidad else  (select sum(Cantidad) from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura  where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente "
        sel = sel & " AND CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "'  ) end as CantidadTotal,  "
        sel = sel & "case when CP.idArticulo=0 then CP.PrecioNetoUnitario else  (select sum(Cantidad*PrecioNetoUnitario) from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura  where idArticulo<>0 and idArticulo = CP.idArticulo and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli   and Facturas.idCliente = PP.idCliente "
        sel = sel & " AND CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "'  ) end as ImporteTotal  "
        sel = sel & " from ConceptosFacturas as CP"
        sel = sel & " left Join Facturas as PP ON PP.numFactura = CP.numFactura "
        sel = sel & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo "
        sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
        sel = sel & " left join SubTiposArticulo as STA ON STA.idsubTipoArticulo = AR.idsubTipoArticulo "

        sel = sel & " left join Familias ON Familias.idFamilia = AR.idFamilia "
        sel = sel & " left join subFamilias ON SubFamilias.idSubFamilia = AR.idSubFamilia "

        sBusquedaPVendidos = " Where PP.idCliente = " & iidCliente & " AND CONVERT(datetime,CONVERT(Char(10), PP.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PP.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "'  "
       
        If cbTipo.Text <> "" And cbTipo.Text <> "TODOS" And cbTipo.Text <> "TODAS" Then
            sBusquedaPVendidos = sBusquedaPVendidos & " AND (TipoArticulo = '" & cbTipo.Text & "'  OR Familia = '" & cbTipo.Text & "' )"
        End If

        If cbSubTipo.Text <> "" And cbSubTipo.Text <> "TODOS" And cbSubTipo.Text <> "TODAS" Then
            sBusquedaPVendidos = sBusquedaPVendidos & " AND  (SubTipoArticulo = '" & cbSubTipo.Text & "' OR subFamilia = '" & cbSubTipo.Text & "' ) "
        End If

        sel = sel & sBusquedaPVendidos & " Order by Articulo ASC"

        Dim dt As DataTable = funcCL.BusquedaSQL(sel)
        lvwColumnSorterAV = New OrdenarLV()
        lvArticulosVendidos.ListViewItemSorter = lvwColumnSorterAV
        Dim SumaCantidad As Double = 0
        Dim SumaImporte As Double = 0
        Dim codMoneda As String
        Dim ImporteTotal As Double
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        For Each linea As DataRow In dt.Rows
            If linea("idArticulo") Is DBNull.Value Then
            Else
                With lvArticulosVendidos.Items.Add(linea("idArticulo"))
                    .subitems.add(If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo")))
                    .subitems.add(If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")))
                    .subitems.add(If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli")))
                    .subitems.add(If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli")))
                    .subitems.add(FormatNumber(If(linea("CantidadTotal") Is DBNull.Value, 0, linea("CantidadTotal")), 2))
                    .subitems.add(FormatNumber(If(linea("UltimoPrecioNeto") Is DBNull.Value, 0, linea("UltimoPrecioNeto")), 2) & If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo")))
                    .subitems.add(If(linea("UltimaFactura") Is DBNull.Value, "", linea("UltimaFactura")))
                    .subitems.add(If(linea("UltimaFecha") Is DBNull.Value, "", linea("UltimaFecha")))
                    codMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))

                    ImporteTotal = If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal"))
                    SumaCantidad = SumaCantidad + If(linea("CantidadTotal") Is DBNull.Value, 0, linea("CantidadTotal"))
                    If codMoneda = "EU" Then
                        SumaImporte = SumaImporte + If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal"))
                    Else
                        SumaImporte = SumaImporte + funcMO.Cambio(If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal")), codMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                End With
            End If
        Next
        lbCambioVendidos.Text = "CAMBIO " & FechaCambioG
        lbCambioVendidos.Visible = AvisoG
        ContadorVendidos.Text = lvArticulosVendidos.Items.Count
        CantidadVendidos.Text = FormatNumber(SumaCantidad, 2)
        TotalVendidos.Text = FormatNumber(SumaImporte, 2)
    End Sub


    Private Sub lvArticulosVendidos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvArticulosVendidos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorterAV.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorterAV.Order = SortOrder.Ascending) Then
                lvwColumnSorterAV.Order = SortOrder.Descending
            Else
                lvwColumnSorterAV.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorterAV.SortColumn = e.Column

            lvwColumnSorterAV.Order = SortOrder.Ascending
        End If
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        lvArticulosVendidos.Sort()

    End Sub

    Private Sub lvArticulosVendidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulosVendidos.DoubleClick
        'Al hacer doble click, abrimos una vista de la factura
        If lvArticulosVendidos.SelectedItems.Count > 0 Then
            'Dim GG As New GestionFactura
            'GG.SoloLectura = vSoloLectura
            'GG.pnumFactura = lvArticulosVendidos.SelectedItems(0).SubItems(7).Text
            'GG.ShowDialog()
            Dim iidArticulo As Integer = lvArticulosVendidos.SelectedItems(0).Text
            If iidArticulo = 0 Then
                MsgBox("La linea seleccionada no se corresponde con un artículo válido")
            Else
                Dim GG As New InformeListadoArticulosVendidos

                GG.verInforme(iidCliente, iidArticulo, dtpArticulosVendidosDesde.Value.Date, dtpArticulosVendidosHasta.Value.Date, "", "")
                GG.ShowDialog()
            End If
        End If


    End Sub

    Private Sub dtpArticulosVendidosHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpArticulosVendidosHasta.ValueChanged, dtpArticulosVendidosDesde.ValueChanged, cbTipo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged
        If semaforo Then Call CargarlvArtVendidos()
    End Sub

    Private Sub tbArticulosVendidos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbArticulosVendidos.Enter
        bListado.Enabled = True
    End Sub

#End Region

#Region "PEDIDOS"

    Private Sub introducirEstadosPedido()
        cbEstadoPedido.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("PEDIDO")
        cbEstadoPedido.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstadoPedido.Items.Add(dts)
        Next
        cbEstadoPedido.SelectedIndex = 0 'Para que indique TODOS
        OrdenPedidos = "numPedido"
        DireccionPedido = "DESC"
    End Sub

    Private Sub introducirAnyosPedido()
        cbAnyoPedido.Items.Clear()
        cbAnyoPedido.Items.Add("TODOS")
        For anyo As Integer = funcP.buscaPrimerDia.Year To Now.Year
            cbAnyoPedido.Items.Add(anyo)
        Next
        cbAnyoPedido.SelectedIndex = 0 'Para que indique TODOS
    End Sub

    Private Sub BusquedaPedidos()

        If iidCliente > 0 Then

            sBusquedaPedido = " DOC.idCliente = " & iidCliente

            If cbEstadoPedido.SelectedIndex > 0 Then
                sBusquedaPedido = sBusquedaPedido & IIf(sBusquedaPedido = "", "", " AND ")
                sBusquedaPedido = sBusquedaPedido & " DOC.idEstado = " & cbEstadoPedido.SelectedItem.gidEstado
            End If

            If cbAnyoPedido.SelectedIndex <> -1 AndAlso IsNumeric(cbAnyoPedido.SelectedItem.ToString) Then
                sBusquedaPedido = sBusquedaPedido & IIf(sBusquedaPedido = "", "", " AND ")
                sBusquedaPedido = sBusquedaPedido & " Year(Fecha) = " & cbAnyoPedido.SelectedItem.ToString
            End If
            Call ActualizarLVPedidos()
        End If
    End Sub

    Private Sub ActualizarLVPedidos()
        Try
            lvPedidos.Items.Clear()
            Dim Suma As Double = 0
            Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim Servido As Double = 0
            Dim lista As List(Of DatosPedido) = funcP.Busqueda(sBusquedaPedido, OrdenPedidos, True)
            For Each dts As DatosPedido In lista

                With lvPedidos.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gFechaEntrega)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gPrecioTransporte, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gPendienteServir, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gServido, 2) & dts.gSimbolo)
                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase '- dts.gPrecioTransporte
                        Portes = Portes + dts.gPrecioTransporte
                        Servido = Servido + dts.gServido
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        Servido = Servido + funcMO.Cambio(dts.gServido, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End With
            Next
            ContadorPedidos.Text = lvPedidos.Items.Count
            TotalPedidos.Text = FormatNumber(Suma, 2)
            lbCambioPedido.Text = "CAMBIO " & FechaCambioG
            lbCambioPedido.Visible = AvisoG
            PortesPedido.Text = FormatNumber(Portes, 2)
            TotalServido.Text = FormatNumber(Servido, 2)
            TotalPendiente.Text = FormatNumber(Suma - Servido, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lvPedidos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPedidos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaPedido Then
            If DireccionPedido = "ASC" Then
                DireccionPedido = "DESC"
            Else
                DireccionPedido = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenPedidos = "numPedido"
            Case 1
                OrdenPedidos = "ReferenciaCliente"
            Case 2
                OrdenPedidos = "Fecha"
            Case 3
                OrdenPedidos = "FechaEntrega"
            Case 4
                OrdenPedidos = "Estado"
            Case 5
                OrdenPedidos = "Base"
            Case 6
                OrdenPedidos = "PrecioTransporte"
            Case 7
                OrdenPedidos = "PendienteServir"
            Case 8
                OrdenPedidos = "Servido"
            Case Else
                OrdenPedidos = "numPedido"
        End Select


        ColumnaPedido = e.Column
        If OrdenPedidos <> "" Then
            OrdenPedidos = OrdenPedidos & " " & DireccionPedido
        End If
        Call BusquedaPedidos()

    End Sub

    Private Sub lvPedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPedidos.DoubleClick
        If lvPedidos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvPedidos.SelectedIndices(0)
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = lvPedidos.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVPedidos()
            lvPedidos.SelectedIndices.Add(indice)
            lvPedidos.EnsureVisible(indice)
        End If
    End Sub

    Private Sub cbAnyoPedido_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyoPedido.SelectionChangeCommitted, cbEstadoPedido.SelectionChangeCommitted
        Call BusquedaPedidos()
    End Sub

    Private Sub tbPedidos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPedidos.Enter
        bListado.Enabled = True
    End Sub



#End Region

#Region "OFERTAS"

    Private Sub introducirEstadosOferta()
        cbEstadoOferta.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Oferta")
        cbEstadoOferta.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstadoOferta.Items.Add(dts)
        Next
        cbEstadoOferta.SelectedIndex = 0 'Para que indique TODOS
        OrdenOfertas = "DOC.numOferta"
        DireccionOferta = "DESC"
    End Sub

    Private Sub introducirAnyosOferta()
        cbAnyoOferta.Items.Clear()
        cbAnyoOferta.Items.Add("TODOS")
        For anyo As Integer = funcP.buscaPrimerDia.Year To Now.Year
            cbAnyoOferta.Items.Add(anyo)
        Next
        cbAnyoOferta.SelectedIndex = 0 'Para que indique TODOS
    End Sub

    Private Sub BusquedaOfertas()

        If iidCliente > 0 Then

            sBusquedaOferta = " DOC.idCliente = " & iidCliente

            If cbEstadoOferta.SelectedIndex > 0 Then
                sBusquedaOferta = sBusquedaOferta & IIf(sBusquedaOferta = "", "", " AND ")
                sBusquedaOferta = sBusquedaOferta & " DOC.idEstado = " & cbEstadoOferta.SelectedItem.gidEstado
            End If

            If cbAnyoOferta.SelectedIndex <> -1 AndAlso IsNumeric(cbAnyoOferta.SelectedItem.ToString) Then
                sBusquedaOferta = sBusquedaOferta & IIf(sBusquedaOferta = "", "", " AND ")
                sBusquedaOferta = sBusquedaOferta & " Year(DOC.Fecha) = " & cbAnyoOferta.SelectedItem.ToString

            End If

            Call ActualizarLVOfertas()
        End If
    End Sub

    Private Sub ActualizarLVOfertas()
        Try
            lvOfertas.Items.Clear()
            Dim Suma As Double = 0
            'Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosOferta) = funcOF.Busqueda(sBusquedaOferta, OrdenOfertas, True)
            For Each dts As DatosOferta In lista

                With lvOfertas.Items.Add(dts.gnumOferta)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase - dts.gPrecioTransporte
                        'Portes = Portes + dts.gPrecioTransporte
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase - dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        'Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End With
            Next
            ContadorOfertas.Text = lvOfertas.Items.Count
            TotalOfertas.Text = FormatNumber(Suma, 2)
            lbCambioOferta.Text = "CAMBIO " & FechaCambioG
            lbCambioOferta.Visible = AvisoG

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lvOfertas_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvOfertas.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaOferta Then
            If DireccionOferta = "ASC" Then
                DireccionOferta = "DESC"
            Else
                DireccionOferta = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenOfertas = "DOC.numOferta"
            Case 1
                OrdenOfertas = "ReferenciaCliente"
            Case 2
                OrdenOfertas = "DOC.Fecha"
            Case 3
                OrdenOfertas = "Estado"
            Case 4
                OrdenOfertas = "Base"

        End Select


        ColumnaOferta = e.Column
        If OrdenOfertas <> "" Then
            OrdenOfertas = OrdenOfertas & " " & DireccionOferta
        End If
        Call BusquedaOfertas()

    End Sub

    Private Sub lvOfertas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOfertas.DoubleClick
        If lvOfertas.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvOfertas.SelectedIndices(0)
            Dim GG As New GestionOferta
            GG.SoloLectura = vSoloLectura
            GG.pnumOferta = lvOfertas.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVOfertas()
            lvOfertas.SelectedIndices.Add(indice)
            lvOfertas.EnsureVisible(indice)
        End If
    End Sub

    Private Sub cbAnyoOferta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyoOferta.SelectionChangeCommitted, cbEstadoOferta.SelectionChangeCommitted
        Call BusquedaOfertas()
    End Sub



    Private Sub tbOFertas_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbOFertas.Enter
        bListado.Enabled = True
    End Sub

#End Region

#Region "PROFORMAS"

    Private Sub introducirEstadosProforma()
        cbEstadoProforma.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Proforma")
        cbEstadoProforma.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstadoProforma.Items.Add(dts)
        Next
        cbEstadoProforma.SelectedIndex = 0 'Para que indique TODOS
        OrdenProformas = "DOC.numProforma"
        DireccionProforma = "DESC"
    End Sub

    Private Sub introducirAnyosProforma()
        cbAnyoProforma.Items.Clear()
        cbAnyoProforma.Items.Add("TODOS")
        For anyo As Integer = funcP.buscaPrimerDia.Year To Now.Year
            cbAnyoProforma.Items.Add(anyo)
        Next
        cbAnyoProforma.SelectedIndex = 0 'Para que indique TODOS
    End Sub

    Private Sub BusquedaProformas()

        If iidCliente > 0 Then

            sBusquedaProforma = " DOC.idCliente = " & iidCliente

            If cbEstadoProforma.SelectedIndex > 0 Then
                sBusquedaProforma = sBusquedaProforma & IIf(sBusquedaProforma = "", "", " AND ")
                sBusquedaProforma = sBusquedaProforma & " DOC.idEstado = " & cbEstadoProforma.SelectedItem.gidEstado
            End If

            If cbAnyoProforma.SelectedIndex <> -1 AndAlso IsNumeric(cbAnyoProforma.SelectedItem.ToString) Then
                sBusquedaProforma = sBusquedaProforma & IIf(sBusquedaProforma = "", "", " AND ")
                sBusquedaProforma = sBusquedaProforma & " Year(DOC.Fecha) = " & cbAnyoProforma.SelectedItem.ToString
            End If

            Call ActualizarLVProformas()
        End If
    End Sub

    Private Sub ActualizarLVProformas()
        Try
            lvProformas.Items.Clear()
            Dim Suma As Double = 0
            'Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosProforma) = funcPF.Busqueda(sBusquedaProforma, OrdenProformas, True)
            For Each dts As DatosProforma In lista

                With lvProformas.Items.Add(dts.gnumProforma)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase - dts.gPrecioTransporte
                        'Portes = Portes + dts.gPrecioTransporte
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase - dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        'Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End With
            Next
            ContadorProformas.Text = lvProformas.Items.Count
            TotalProformas.Text = FormatNumber(Suma, 2)
            lbCambioProforma.Text = "CAMBIO " & FechaCambioG
            lbCambioProforma.Visible = AvisoG

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lvProformas_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvProformas.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaProforma Then
            If DireccionProforma = "ASC" Then
                DireccionProforma = "DESC"
            Else
                DireccionProforma = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenProformas = "DOC.numProforma"
            Case 1
                OrdenProformas = "ReferenciaCliente"
            Case 2
                OrdenProformas = "DOC.Fecha"
            Case 3
                OrdenProformas = "Estado"
            Case 4
                OrdenProformas = "Base"

        End Select


        ColumnaProforma = e.Column
        If OrdenProformas <> "" Then
            OrdenProformas = OrdenProformas & " " & DireccionProforma
        End If
        Call BusquedaProformas()

    End Sub

    Private Sub lvProformas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProformas.DoubleClick
        If lvProformas.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvProformas.SelectedIndices(0)
            Dim GG As New GestionProforma
            GG.SoloLectura = vSoloLectura
            GG.pnumProforma = lvProformas.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVProformas()
            lvProformas.SelectedIndices.Add(indice)
            lvProformas.EnsureVisible(indice)
        End If
    End Sub

    Private Sub cbAnyoProforma_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyoProforma.SelectionChangeCommitted, cbEstadoProforma.SelectionChangeCommitted
        Call BusquedaProformas()
    End Sub



    Private Sub TotalProformas_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalProformas.Enter
        bListado.Enabled = True
    End Sub



#End Region

#Region "ALBARANES"

    Private Sub introducirEstadosAlbaran()
        cbEstadoAlbaran.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Albaran")
        cbEstadoAlbaran.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstadoAlbaran.Items.Add(dts)
        Next
        cbEstadoAlbaran.SelectedIndex = 0 'Para que indique TODOS
        OrdenAlbaranes = "DOC.numAlbaran"
        DireccionAlbaran = "DESC"
    End Sub

    Private Sub introducirAnyosAlbaran()
        cbAnyoAlbaran.Items.Clear()
        cbAnyoAlbaran.Items.Add("TODOS")
        For anyo As Integer = funcP.buscaPrimerDia.Year To Now.Year
            cbAnyoAlbaran.Items.Add(anyo)
        Next
        cbAnyoAlbaran.SelectedIndex = 0 'Para que indique TODOS
    End Sub

    Private Sub BusquedaAlbaranes()

        If iidCliente > 0 Then

            sBusquedaAlbaran = " DOC.idCliente = " & iidCliente

            If cbEstadoAlbaran.SelectedIndex > 0 Then
                sBusquedaAlbaran = sBusquedaAlbaran & IIf(sBusquedaAlbaran = "", "", " AND ")
                sBusquedaAlbaran = sBusquedaAlbaran & " DOC.idEstado = " & cbEstadoAlbaran.SelectedItem.gidEstado
            End If

            If cbAnyoAlbaran.SelectedIndex <> -1 AndAlso IsNumeric(cbAnyoAlbaran.SelectedItem.ToString) Then
                sBusquedaAlbaran = sBusquedaAlbaran & IIf(sBusquedaAlbaran = "", "", " AND ")
                sBusquedaAlbaran = sBusquedaAlbaran & " Year(DOC.Fecha) = " & cbAnyoAlbaran.SelectedItem.ToString
            End If


            Call ActualizarLVAlbaranes()
        End If
    End Sub

    Private Sub ActualizarLVAlbaranes()
        Try
            lvAlbaranes.Items.Clear()
            Dim Suma As Double = 0
            'Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosAlbaran) = funcAL.Busqueda(sBusquedaAlbaran, OrdenAlbaranes, True)
            For Each dts As DatosAlbaran In lista

                With lvAlbaranes.Items.Add(dts.gnumAlbaran)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase - dts.gPrecioTransporte
                        'Portes = Portes + dts.gPrecioTransporte
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase - dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        'Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End With
            Next
            ContadorAlbaranes.Text = lvAlbaranes.Items.Count
            TotalAlbaranes.Text = FormatNumber(Suma, 2)
            lbCambioAlbaran.Text = "CAMBIO " & FechaCambioG
            lbCambioAlbaran.Visible = AvisoG

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lvAlbaranes_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvAlbaranes.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaAlbaran Then
            If DireccionAlbaran = "ASC" Then
                DireccionAlbaran = "DESC"
            Else
                DireccionAlbaran = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenAlbaranes = "DOC.numAlbaran"
            Case 1
                OrdenAlbaranes = "ReferenciaCliente"
            Case 2
                OrdenAlbaranes = "DOC.Fecha"
            Case 3
                OrdenAlbaranes = "Estado"
            Case 4
                OrdenAlbaranes = "Base"

        End Select


        ColumnaAlbaran = e.Column
        If OrdenAlbaranes <> "" Then
            OrdenAlbaranes = OrdenAlbaranes & " " & DireccionAlbaran
        End If
        Call BusquedaAlbaranes()

    End Sub

    Private Sub lvAlbaranes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAlbaranes.DoubleClick
        If lvAlbaranes.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvAlbaranes.SelectedIndices(0)
            Dim GG As New GestionAlbaran
            GG.SoloLectura = vSoloLectura
            GG.pnumAlbaran = lvAlbaranes.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVAlbaranes()
            lvAlbaranes.SelectedIndices.Add(indice)
            lvAlbaranes.EnsureVisible(indice)
        End If
    End Sub

    Private Sub cbAnyoAlbaran_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyoAlbaran.SelectionChangeCommitted, cbEstadoAlbaran.SelectionChangeCommitted
        Call BusquedaAlbaranes()
    End Sub




    Private Sub tbAlbaranes_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbAlbaranes.Enter
        bListado.Enabled = True
    End Sub



#End Region

#Region "FACTURAS"

    Private Sub introducirEstadosFactura()
        cbEstadoFactura.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
        cbEstadoFactura.Items.Add("TODOS")
        For Each dts As DatosEstado In lista
            cbEstadoFactura.Items.Add(dts)
        Next
        cbEstadoFactura.SelectedIndex = 0 'Para que indique TODOS
        OrdenFacturas = "DOC.numFactura"
        DireccionFactura = "DESC"
    End Sub

    Private Sub introducirAnyosFactura()
        cbAnyoFactura.Items.Clear()
        cbAnyoFactura.Items.Add("TODOS")
        For anyo As Integer = funcP.buscaPrimerDia.Year To Now.Year
            cbAnyoFactura.Items.Add(anyo)
        Next
        cbAnyoFactura.SelectedIndex = 0 'Para que indique TODOS
    End Sub

    Private Sub BusquedaFacturas()
        If iidCliente > 0 Then

            sBusquedaFactura = " DOC.idCliente = " & iidCliente

            If cbEstadoFactura.SelectedIndex > 0 Then
                sBusquedaFactura = sBusquedaFactura & IIf(sBusquedaFactura = "", "", " AND ")
                sBusquedaFactura = sBusquedaFactura & " DOC.idEstado = " & cbEstadoFactura.SelectedItem.gidEstado
            End If


            If cbAnyoFactura.SelectedIndex <> -1 AndAlso IsNumeric(cbAnyoFactura.SelectedItem.ToString) Then
                sBusquedaFactura = sBusquedaFactura & IIf(sBusquedaFactura = "", "", " AND ")
                sBusquedaFactura = sBusquedaFactura & " Year(DOC.Fecha) = " & cbAnyoFactura.SelectedItem.ToString
            End If


            Call ActualizarLVFacturas()
        End If
    End Sub

    Private Sub ActualizarLVFacturas()
        Try
            LvFacturas.Items.Clear()
            Dim Suma As Double = 0
            Dim SumaBase As Double = 0
            Dim SumaIVA As Double = 0
            SumaRE = 0
            SumaRetencion = 0
            'Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosFactura) = funcF.Busqueda(sBusquedaFactura, OrdenFacturas, False)
            For Each dts As DatosFactura In lista

                With LvFacturas.Items.Add(dts.gnumFactura)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gTotal
                        SumaIVA = SumaIVA + dts.gTotalIVA
                        SumaRE = SumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
                        SumaRetencion = SumaRetencion + dts.gRetencion
                        SumaBase = SumaBase + dts.gBase
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaRE = SumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
                        SumaRetencion = SumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                End With
            Next
            ContadorFacturas.Text = LvFacturas.Items.Count
            TotalFacturas.Text = FormatNumber(Suma, 2)
            Base.Text = FormatNumber(SumaBase, 2)
            IVA.Text = FormatNumber(SumaIVA, 2)
            lbCambioFactura.Text = "CAMBIO " & FechaCambioG
            lbCambioFactura.Visible = AvisoG

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lvFacturas_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LvFacturas.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaFactura Then
            If DireccionFactura = "ASC" Then
                DireccionFactura = "DESC"
            Else
                DireccionFactura = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenFacturas = "DOC.numFactura"
            Case 1
                OrdenFacturas = "ReferenciaCliente"
            Case 2
                OrdenFacturas = "DOC.Fecha"
            Case 3
                OrdenFacturas = "Estado"
            Case 4
                OrdenFacturas = "Base"


        End Select


        ColumnaFactura = e.Column
        If OrdenFacturas <> "" Then
            OrdenFacturas = OrdenFacturas & " " & DireccionFactura
        End If
        Call BusquedaFacturas()

    End Sub

    Private Sub lvFacturas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LvFacturas.DoubleClick
        If LvFacturas.SelectedItems.Count > 0 Then
            Dim indice As Integer = LvFacturas.SelectedIndices(0)
            Dim GG As New GestionFactura1
            GG.SoloLectura = vSoloLectura
            GG.pnumFactura = LvFacturas.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVFacturas()
            LvFacturas.SelectedIndices.Add(indice)
            LvFacturas.EnsureVisible(indice)
        End If
    End Sub

    Private Sub cbAnyoFactura_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAnyoFactura.SelectionChangeCommitted, cbEstadoFactura.SelectionChangeCommitted
        Call BusquedaFacturas()
    End Sub



    Private Sub tbFacturas_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbFacturas.Enter
        bListado.Enabled = True
    End Sub






#End Region

#Region "COMISIONES"

    Private Sub ActualizarLVComisiones()
        lvComisiones.Items.Clear()
        TotalComisiones.Text = ""
        TotalBase.Text = ""
        Dim sumaBase As Double = 0
        Dim sumaComisiones As Double = 0
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        Dim lista As List(Of DatosFactura) = funcF.Busqueda(sBusquedaComisiones, OrdenComisiones, False)
        Dim importe As Double
        For Each dts As DatosFactura In lista
            With lvComisiones.Items.Add(dts.gnumFactura)
                .SubItems.Add(dts.gFecha)
                .SubItems.Add(dts.gBase & dts.gSimbolo)
                .SubItems.Add(dts.gPersona)
                .SubItems.Add(funcF.Comisiones(dts.gnumFactura))
                importe = funcF.ImporteComisiones(dts.gnumFactura)
                .SubItems.Add(FormatNumber(importe, 2) & dts.gSimbolo)
                If dts.gLiquidadaComision Then
                    .SubItems.Add(dts.gFechaLiquidacion)
                    .SubItems.Add(dts.gidLiquidacion)
                    .ForeColor = Color.Gray
                Else
                    .SubItems.Add(" ")
                    .SubItems.Add(" ")
                    .ForeColor = SystemColors.WindowText
                End If
                If dts.gcodMoneda = "EU" Then
                    sumaComisiones = sumaComisiones + importe
                    sumaBase = sumaBase + dts.gBase
                Else
                    sumaComisiones = sumaComisiones + funcMO.Cambio(importe, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                    sumaBase = sumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                End If
            End With
            TotalComisiones.Text = FormatNumber(sumaComisiones, 2)
            TotalBase.Text = FormatNumber(sumaBase, 2)
        Next

    End Sub

    Private Sub ActualizarLVCambiosComisiones()
        lvCambiosComisiones.Items.Clear()
        Dim lista As List(Of datosCambioComision)
        If GestionaComisiones Then
            lista = funcCC.mostrarCli(iidCliente)
        Else
            lista = funcCC.mostrarClienteComercial(iidCliente, Inicio.vIdUsuario)
        End If
        For Each dts As datosCambioComision In lista
            With lvCambiosComisiones.Items.Add(dts.gidHistoricoCambio)
                .SubItems.Add(dts.gComercial)
                .SubItems.Add(dts.gFecha)
                .SubItems.Add(FormatNumber(dts.gPorcentajeAnterior, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gPorcentaje, 2) & "%")
            End With
        Next



    End Sub


    Private Sub BusquedaComisiones()

        If iidCliente > 0 Then

            sBusquedaComisiones = " DOC.idCliente = " & iidCliente

            If ckLiquidados.Checked = False Then
                sBusquedaComisiones = sBusquedaComisiones & IIf(sBusquedaComisiones = "", "", " AND ")
                sBusquedaComisiones = sBusquedaComisiones & " (DOC.idLiquidacion is null or DOC.idLiquidacion = 0 )"
            End If

            sBusquedaComisiones = sBusquedaComisiones & IIf(sBusquedaComisiones = "", "", " AND ")
            sBusquedaComisiones = sBusquedaComisiones & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpComisionesDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpComisionesHasta.Value.Date & "' "

            Call ActualizarLVComisiones()
        End If
    End Sub


    Private Sub lvComisiones_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvComisiones.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaComisiones Then
            If DireccionComisiones = "ASC" Then
                DireccionComisiones = "DESC"
            Else
                DireccionComisiones = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                OrdenComisiones = "DOC.numFactura"
            Case 1
                OrdenComisiones = "DOC.Fecha"
            Case 2
                OrdenComisiones = "Base"
            Case 3
                OrdenComisiones = "Persona"
            Case 6
                OrdenComisiones = "FechaLiquidacion"
            Case 7
                OrdenComisiones = "DOC.idLiquidacion"

        End Select


        ColumnaComisiones = e.Column
        If OrdenComisiones <> "" Then
            OrdenComisiones = OrdenComisiones & " " & DireccionComisiones
        End If
        Call BusquedaComisiones()

    End Sub

    Private Sub dtpComisionesDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpComisionesDesde.ValueChanged, dtpComisionesHasta.ValueChanged, ckLiquidados.CheckedChanged
        If semaforo Then Call BusquedaComisiones()
    End Sub

    Private Sub lvComisiones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvComisiones.DoubleClick
        If lvComisiones.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvComisiones.SelectedIndices(0)
            Dim GG As New GestionFactura1
            GG.SoloLectura = vSoloLectura
            GG.pnumFactura = lvComisiones.SelectedItems(0).Text
            GG.ShowDialog()
            Call ActualizarLVComisiones()
            lvComisiones.SelectedIndices.Add(indice)
            lvComisiones.EnsureVisible(indice)
        End If
    End Sub

#End Region

#Region "CARGAR DATOS GENERALES"


    Private Sub CargarDatosCliente()
        Try
            semaforo = False
            Dim dts As datoscliente = funcCL.mostrar1(iidCliente)
            cbResponsable.Text = dts.gResponsableCuenta
            codCli.Text = dts.gcodCli
            codContable.Text = dts.gcodContable
            nombrecomercial.Text = dts.gnombrecomercial
            Me.Text = "GESTIÓN DE CLIENTE  " & nombrecomercial.Text
            nombrefiscal.Text = dts.gnombrefiscal
            dtpFechaAlta.Value = dts.gfechaAlta
            dtpFechaBaja.Value = dts.gfechaBaja
            ckActivo.Checked = dts.gActivo
            dtpFechaBaja.Visible = (ckActivo.CheckState = CheckState.Unchecked)
            lbBaja.Visible = dtpFechaBaja.Visible
            nif.Text = dts.gnif
            web.Text = dts.gweb
            cbResponsable.Text = dts.gResponsableCuenta
            If dts.gidResponsableCuenta = 0 Then
                Comision.Text = 0
                Comision.ReadOnly = True
            Else
                Dim dtsCM As datosComision = funcCM.mostrar1(iidCliente, dts.gidResponsableCuenta)
                Comision.Text = FormatNumber(dtsCM.gPorcentaje, 2)
                ObservacionesC.Text = dtsCM.gObservaciones

                Comision.ReadOnly = False
            End If
            observaciones.Text = dts.gobservaciones
            ObservacionesProd.Text = dts.gObservacionesProd
            'cbMoneda.Text = funcM.CampoDivisa(dts.gcodMoneda)
            If nombrecomercial.Text <> "" Then G_AGeneral = "A"
            Call CargarDirecciones()
            semaforo = True
            ' bGuardar.Text = "ACTUALIZAR"
            Cambios = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Function GuardarGeneral() As Boolean
        Try

            If ValidarGeneral() Then
                Dim dts As New datoscliente
                dts.gcodMoneda = "EU" 'cbMoneda.SelectedItem.itemdata
                dts.gcodContable = codContable.Text
                dts.gcodCli = codCli.Text
                dts.gfechaAlta = dtpFechaAlta.Value.Date
                dts.gfechaBaja = dtpFechaBaja.Value.Date
                dts.gidResponsableCuenta = If(cbResponsable.SelectedIndex = -1, 0, cbResponsable.SelectedItem.itemdata)
                dts.gnif = nif.Text
                dts.gnombrecomercial = nombrecomercial.Text
                dts.gnombrefiscal = nombrefiscal.Text
                dts.gobservaciones = observaciones.Text
                dts.gObservacionesProd = ObservacionesProd.Text
                dts.gweb = web.Text
                dts.gidCliente = iidCliente
                dts.gActivo = ckActivo.Checked

                dts.gidCliente = iidCliente

                If G_AGeneral = "A" Then
                    funcCL.actualizar(dts)
                Else
                    iidCliente = funcCL.insertar(dts)
                    G_AGeneral = "A"
                    Me.Text = "GESTIÓN DE CLIENTE  " & nombrecomercial.Text
                End If
                Cambios = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ex.Data.Add("idCliente", iidCliente)
            CorreoError(ex)
            Return False
        End Try
    End Function

    Private Function ValidarGeneral() As Boolean
        nif.Text = Replace(nif.Text, " ", "")
        nif.Text = Replace(nif.Text, "-", "")
        Dim validar As Boolean = True
        If nombrecomercial.Text = "" Then
            validar = False

            ep1.SetError(nombrecomercial, "Se ha de especificar un nombre comercial")
        End If
        If nombrefiscal.Text = "" Then
            validar = False

            ep1.SetError(nombrefiscal, "Se ha de especificar un nombre fiscal")
        End If
        If G_AGeneral = "G" Then
            iidCliente = 0
            If Direccion.Text = "" Then
                validar = False

                ep1.SetError(Direccion, "Se ha de especificar una dirección")
            End If
            If cbTipoU.SelectedIndex = -1 Then
                validar = False

                ep1.SetError(cbTipoU, "Se ha de seleccionar un tipo de dirección")
            ElseIf G_AGeneral = "G" Then
                If Not funcTU.EsFiscal(cbTipoU.SelectedItem.itemdata) Then
                    validar = False
                    ep1.SetError(cbTipoU, "Se ha de seleccionar una dirección Fiscal")
                End If
            End If
            If cbPaisU.SelectedIndex = -1 Then
                validar = False

                ep1.SetError(cbPaisU, "Se ha de seleccionar un país")
            Else
                If nif.Text = "" Then 'Permitimos dejar el NIF en blanco
                    ep2.SetError(nif, "No se ha introducido el NIF del cliente")
                Else
                    If cbPaisU.SelectedItem.gidpais = 1 Then
                        Dim sNIF As String = nif.Text
                        If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                        Else
                            validar = False
                            ep1.SetError(nif, "NIF no válido")
                        End If
                        If validar Then
                            If funcCL.NIFExiste(nif.Text, iidCliente, cbPaisU.SelectedItem.gidPais) Then
                                validar = False
                                ep1.SetError(nif, "NIF ya utilizado")
                            End If
                        End If
                    End If
                End If

            End If

        Else
            If lvDirecciones.Items.Count = 0 Then
                validar = False
                ep1.SetError(tbUbicaciones, "Se ha de introducir una dirección")
            End If
            If nif.Text = "" Then 'Permitimos dejar el NIF en blanco
                ep2.SetError(nif, "No se ha introducido el NIF del cliente")
            Else
                'Si es español, verifcamos el NIF
                If funcCL.PaisFiscal(iidCliente) = 1 Then
                    Dim sNIF As String = nif.Text
                    If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                    Else
                        validar = False
                        ep1.SetError(nif, "NIF no válido")
                    End If
                End If
                If validar Then
                    If funcCL.NIFExiste(nif.Text, iidCliente, funcCL.PaisFiscal(iidCliente)) Then
                        validar = False
                        ep1.SetError(nif, "NIF ya utilizado")
                    End If
                End If
            End If
        End If


        If codContable.Text <> "" Then
            If funcCL.codContableExiste(codContable.Text, iidCliente) Then
                validar = False
                ep1.SetError(codContable, "Código contable existente")
            End If
        End If

        If codCli.Text <> "" Then
            If funcCL.codCliExiste(codCli.Text, iidCliente) Then
                validar = False
                ep1.SetError(codCli, "Código de cliente existente")
            End If
        End If

        Return validar
    End Function

#End Region

#Region "BOTONES GENERALES"

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If cambioTipoDireccion = True Then
            If funcU.verificarFiscal(iidUbicacion, iidCliente) = False Then
                MsgBox("El cliente tiene que tener una dirección fiscal", MsgBoxStyle.Information)
            Else
                Call Guardar()
            End If
        Else
            Call Guardar()
        End If
    End Sub

    Private Sub Guardar()
        Try
            Dim correcto As Boolean = False
            ep1.Clear()
            ep2.Clear()
            If GuardarGeneral() Then  'Si se ha validado el guardar general
                correcto = True
                tbcontactos.Parent = tbdatos
                tbfacturacion.Parent = tbdatos
                If cbMedioPago.SelectedIndex <> -1 Then
                    gbBancos.Enabled = funcMP.RequiereBanco(cbMedioPago.SelectedItem.itemdata)
                End If
                Select Case tbdatos.SelectedTab.Name
                    Case tbUbicaciones.Name
                        If Direccion.Text.Length > 0 Or subCliente.Text.Length > 0 Then
                            correcto = correcto And GuardarDireccion()
                            CargarDirecciones()
                        End If
                    Case tbcontactos.Name
                        If nombrecontacto.TextLength > 0 Or apellidoscontacto.TextLength > 0 Then
                            correcto = correcto And GuardarContacto()
                        End If
                    Case tbfacturacion.Name
                        correcto = correcto And GuardarFacturacion()
                    Case tbComisiones.Name
                        If Not IsNumeric(Comision.Text) Then Comision.Text = 0
                        If Comision.Text <> 0 And cbResponsable.SelectedIndex = -1 Then
                            MsgBox("Para asignar la comisión ha de seleccionarse el responsable de cuenta")
                        End If
                        Dim dts As datosComision = funcCM.mostrar1(iidCliente, cbResponsable.SelectedItem.itemdata)
                        If dts.gPorcentaje <> Comision.Text Then
                            dts.gPorcentaje = Comision.Text
                            dts.gObservaciones = ObservacionesC.Text
                            If dts.gidComision = 0 Then
                                dts.gidComercial = cbResponsable.SelectedItem.itemdata
                                dts.gidCliente = iidCliente

                                dts.gidComision = funcCM.insertar(dts)
                            Else
                                funcCM.actualizar(dts)
                            End If
                            Call ActualizarLVCambiosComisiones()
                        End If
                    Case Else
                End Select
            End If
            If correcto Then
                MsgBox("Cliente guardado correctamente")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click

        Try
            ep1.Clear()

            If bNuevo.Text = "NUEVO" Then
                Select Case tbdatos.SelectedTab.Name
                    Case tbfacturacion.Name
                        If bGuardar.Enabled Then
                            If MsgBox("Se perderán los datos que no haya guardado", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                Call borrargeneral()
                                Me.Text = "NUEVO CLIENTE"
                                'iidCliente = funcCL.NuevoidCliente
                                codCli.Text = funcCL.NuevocodCli
                            End If
                        Else
                            Call borrargeneral()
                            Me.Text = "NUEVO CLIENTE"
                            iidCliente = 0
                            codCli.Text = funcCL.NuevocodCli
                            'bBuscar.Visible = False
                            tbcontactos.Parent = Nothing
                            tbfacturacion.Parent = Nothing
                            'Dim AP As New AltaCliente
                            'AP.pModo = "CONSULTA"
                            'AP.ShowDialog()
                            'iidCliente = AP.pidCliente
                            'If iidCliente <> 0 Then
                            '    Call CargarCliente()
                            'End If
                        End If
                    Case tbcontactos.Name
                        Call Limpiarcontactos()
                    Case tbUbicaciones.Name
                        Call LimpiarDirecciones()
                    Case tbArticulosVendidos.Name
                        Call LimpiarBusquedaArticulo()
                        Call CargarlvArtVendidos()
                End Select
            Else  'Nuevo cliente
                If MsgBox("Se perderán los datos que no haya guardado", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call borrargeneral()
                    Me.Text = "NUEVO CLIENTE"
                    'iidCliente = funcCL.NuevoidCliente
                    codCli.Text = funcCL.NuevocodCli
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        Try
            If bBorrar.Text = "BORRAR CLIENTE" Then
                If MsgBox("¿Borrar el Cliente?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    If funcCL.borrar(iidCliente) Then
                        Call borrargeneral()
                        Me.Text = "NUEVO CLIENTE"
                        tbdatos.Enabled = False
                    End If
                End If
            Else
                Select Case tbdatos.SelectedTab.Name
                    Case tbfacturacion.Name
                        If MsgBox("¿Borrar el Cliente?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            If funcCL.borrar(iidCliente) Then
                                Call borrargeneral()
                                Me.Text = "NUEVO CLIENTE"
                                tbdatos.Enabled = False
                            End If
                        End If
                    Case tbcontactos.Name
                        If lvContactos.SelectedItems.Count > 0 Then
                            If MsgBox("¿Borrar el contacto especificado?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                funcCT.borrar(iidContacto)
                                lvContactos.Items.RemoveAt(indiceContactos)
                                Call Limpiarcontactos()
                            End If
                        End If
                    Case tbUbicaciones.Name
                        If lvDirecciones.SelectedItems.Count > 0 Then
                            'Comprueba si el tipo de dirección es ENTREGA, si no es así lanza el mensaje que no se puede eliminar.
                            If funcU.verificarFiscal(iidUbicacion, iidCliente) = False Then
                                MsgBox("No se puede eliminar la dirección fiscal de un cliente.", MsgBoxStyle.Information)
                            Else
                                If MsgBox("¿Borrar la dirección especificada?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                    funcU.borrar(iidUbicacion)
                                    lvDirecciones.Items.RemoveAt(indiceDirecciones)
                                    Call LimpiarDirecciones()
                                End If
                            End If
                        End If
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Select Case tbdatos.SelectedTab.Name
            Case tbPedidos.Name
                Dim GG As New InformeListadoPedidos
                GG.pBusqueda = sBusquedaPedido
                GG.pOrden = OrdenPedidos
                GG.pTotalEU = TotalPedidos.Text
                GG.pTotalPortes = PortesPedido.Text
                'GG.verInforme(sBusquedaPedido, OrdenPedidos, TotalPedidos.Text, PortesPedido.Text)
                GG.ShowDialog()
            Case tbOFertas.Name
                Dim GG As New InformeListadoOfertas
                GG.verInforme(sBusquedaOferta, OrdenOfertas, TotalOfertas.Text)
                GG.ShowDialog()
            Case tbProformas.Name
                Dim GG As New InformeListadoProformas
                GG.verInforme(sBusquedaProforma, OrdenProformas, TotalProformas.Text)
                GG.ShowDialog()
            Case tbAlbaranes.Name
                Dim GG As New InformeListadoAlbaranes
                GG.verInforme(sBusquedaAlbaran, OrdenAlbaranes, TotalAlbaranes.Text)
                GG.ShowDialog()
            Case tbFacturas.Name
                Dim GG As New InformeListadoFacturas
                'GG.verInforme(sBusquedaFactura, OrdenFacturas, TotalFacturas.Text, Base.Text, IVA.Text, SumaRE, SumaRetencion)
                GG.verInforme()
                GG.pBusqueda = sBusquedaFactura
                GG.pOrden = OrdenFacturas
                If Vvercostes = True Then
                    GG.pTotalEU = TotalFacturas.Text
                    GG.pBaseEU = Base.Text
                    GG.pIVAEU = IVA.Text
                    GG.pReEU = SumaRE
                    GG.pRetencionEU = SumaRetencion
                Else
                    GG.pTotalEU = "0"
                    GG.pBaseEU = "0"
                    GG.pIVAEU = "0"
                    GG.pReEU = "0"
                    GG.pRetencionEU = "0"
                    GG.bTotales.Visible = False
                    GG.bDetalle.Visible = False
                End If
                GG.ShowDialog()
            Case tbArticulosVendidos.Name
                Dim GG As New InformeListadoArticulosVendidos
                Dim Tipo As String = If(cbTipo.Text <> "" And cbTipo.Text <> "TODOS" And cbTipo.Text <> "TODAS", cbTipo.Text, "")
                Dim subTipo As String = If(cbSubTipo.Text <> "" And cbSubTipo.Text <> "TODOS" And cbSubTipo.Text <> "TODAS", cbSubTipo.Text, "")

                GG.verInforme(iidCliente, 0, dtpArticulosVendidosDesde.Value.Date, dtpArticulosVendidosHasta.Value.Date, Tipo, subTipo)
                GG.ShowDialog()

            Case Else

        End Select



    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If IndiceL > 0 Then
            IndiceL = IndiceL - 1
            iidCliente = Clientes(IndiceL)
            Call CargarCliente()
        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If IndiceL < Clientes.Count - 1 Then
            IndiceL = IndiceL + 1
            iidCliente = Clientes(IndiceL)
            Call CargarCliente()
        End If
    End Sub

#End Region

#Region "EVENTOS GENERALES"

    Private Sub nombrecomercial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nombrecomercial.TextChanged
        If semaforo Then
            nombrefiscal.Text = nombrecomercial.Text
            Cambios = True
        End If
    End Sub

    Private Sub ckActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckActivo.CheckedChanged
        If semaforo Then
            If ckActivo.Checked Then
                dtpFechaBaja.Visible = False
                dtpFechaBaja.Enabled = False
                lbBaja.Visible = False
            Else
                dtpFechaBaja.Visible = True
                dtpFechaBaja.Enabled = True
                lbBaja.Visible = True
            End If
            Cambios = True
        End If
    End Sub

    Private Sub gbCabecera_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbCabecera.Enter, tbfacturacion.Enter
        bNuevo.Text = "NUEVO CLIENTE"
        bBorrar.Text = "BORRAR CLIENTE"
        bListado.Enabled = False
    End Sub

    Private Sub gbCabecera_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcontactos.Enter, tbUbicaciones.Enter 'gbCabecera.Leave
        bNuevo.Text = "NUEVO"
        bBorrar.Text = "BORRAR"
        bListado.Enabled = False
    End Sub

    Private Sub telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TelefonoU1.KeyPress, faxU.KeyPress, TelefonoContacto.KeyPress, MovilContacto.KeyPress, TelefonoU2.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumerosTelefono(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub codpostal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codPostal.KeyPress
        If espUbic Then
            Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
            KeyAscii = CShort(SoloNumeros(KeyAscii))
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub codCli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codCli.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub codigodc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codigobanco.KeyPress, codigooficina.KeyPress, codigodc.KeyPress, codigocuenta.KeyPress
        If espUbic Then
            Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
            KeyAscii = CShort(SoloNumeros(KeyAscii))
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Descuento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Descuento.Click, Descuento2.Click, ProntoPago.Click, cbDiaPago1.Click, cbDiaPago2.Click, Comision.Click
        sender.selectall()
    End Sub

    Private Sub Descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Descuento.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Descuento.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Descuento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Descuento2.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Descuento2.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub ProntoPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ProntoPago.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(ProntoPago.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub codCli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codCli.TextChanged, web.TextChanged, nif.TextChanged, nombrefiscal.TextChanged, dtpFechaBaja.ValueChanged, dtpFechaAlta.ValueChanged, codContable.TextChanged, observaciones.TextChanged, ObservacionesProd.TextChanged
        Cambios = semaforo
    End Sub

    Private Sub cbResponsable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbResponsable.SelectedIndexChanged
        If semaforo Then
            Cambios = True
            If cbResponsable.SelectedIndex = -1 Then
                Comision.ReadOnly = True
                Comision.Text = 0
            Else
                Comision.ReadOnly = False
            End If
        End If
    End Sub

#End Region

End Class