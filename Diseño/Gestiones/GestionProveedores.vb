'Esta clase permite gestionar los proveedores.
Public Class GestionProveedores

#Region "VARIABLES"
    'VARIABLES INTEGER
    Dim Activado As Boolean
    Dim idCuentaBanco As String
    Private iidContacto As Integer
    Private iidUbicacion As Integer
    Private iidubicacionP As Integer
    Private iidFacturacion As Integer
    Private iidCuentaBanco As Integer
    Private vmes As Integer
    Private vidUsuario As Integer
    Private indiceDirecciones As Integer
    Private indiceContactos As Integer
    Private indiceB As Integer
    Private Ancho As Integer = 1039
    Private iidProveedor As Integer
    Private IndiceL As Integer
    Private AbrirTab As Integer
    Private iidArticulo As Integer
    'VARIABLES DOUBLE
    Private icodfact As Double
    'VARIABLES BOOLEAN
    Private espUbic As Boolean = True 'Indica la ubicación es española
    Private vSoloLectura As Boolean = False
    Private nuevo As Boolean
    Private semaforo As Boolean
    'VARIABLES CHAR
    Private G_AGeneral As Char
    Private G_AUbicacion As Char
    Private G_AUbicacionF As Char
    Private G_AContacto As Char
    Private G_AFacturacion As Char
    'VARIABLES STRING
    Private Orden As String
    Private Dir As String
    'OTRAS VARIABLES 
    Private lvwColumnSorterAC As OrdenarLV
    Private DI As New DatosIniciales
    Private Proveedores As List(Of Integer)
    Private desktopsize As Size
    Private ep1 As New ErrorProvider    'Muestra un Icono de campo requerido.
    Private ep2 As New ErrorProvider    'Muestra un Icono de campo requerido.
    Private ep1B As New ErrorProvider   'Muestra un Icono de campo requerido.
    Private ep2B As New ErrorProvider   'Muestra un Icono de campo requerido.
    Dim blankContextMenu = New ContextMenuStrip()
    Private colorInactivo As New Color
    'VARIABLES DE FUNCION
    Private funcTC As New FuncionesTipoCompra
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
    Private funcPE As New FuncionesPersonal
    Private funcID As New funcionesIdiomas
    Private funcCB As New FuncionesCuentasBancarias
    Private funcTI As New FuncionesTiposIVA
    Private funcTR As New FuncionesTiposRetencion
    Private funcPR As New funcionesProveedores
    Private funcAP As New FuncionesArticulosProv
    Private funcPP As New FuncionesPedidosProv
    Private funcAR As New FuncionesArticulos
    Dim dtsDF As datosfacturacion
#End Region

#Region "PROPIEDADES"
    'Esta propiedad devuelve el valor booleano del usuario actual 'Permiso sololectura'.
    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property
    'Esta propiedad devuelve el valor booleano ?
    Property pNuevo() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            nuevo = value
        End Set
    End Property
    'Esta propiedad devuelve el valor de un entero con la ID del proveedor.
    Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)  'Si se recibe -1, se abrirá el buscador. Si se recibe 0, será un nuevo Cliente
            iidProveedor = value
        End Set
    End Property
    'Esta propiedad devuelve el valor de Lista con los datos de los proveedores.
    Property pProveedores() As List(Of Integer)
        Get
            Return Proveedores
        End Get
        Set(ByVal value As List(Of Integer))
            Proveedores = value
        End Set
    End Property
    'Esta propiedad devuelve el valor de un entero con el indice del item seleccionado.
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
    'Esta propiedad devuelve el valor de un entero con la ID del artículo.
    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property
    'Esta propiedad devuelve el valor de un entero con la ID de la ubicación.
    Public Property pidUbicacion() As Integer
        Get
            Return iidubicacionP
        End Get
        Set(ByVal value As Integer)
            iidubicacionP = value
        End Set
    End Property
    'Región de la inicialización de la clase.
#End Region

#Region "INICIALIZACIÓN"

    Private Sub consultaProveedores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            vidUsuario = Inicio.vIdUsuario 'Carga la variable de usuario.
            semaforo = False
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info
            ep1B.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2B.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2B.Icon = My.Resources.Resources.info
            bGuardar.Enabled = Not vSoloLectura
            colorInactivo = Color.Gray
            codProveedor.ContextMenuStrip = blankContextMenu
            'carga de datos
            Call introducirTiposPago()
            Call introducirMediosPago()
            Call introducirDepartamentos()
            Call IntroducirTiposCompra()
            Call IntroducirTiposUbicacion()
            Call introducirMonedas()
            Call introducirPaises()
            Call introducirIdiomas()
            Call introducirTransporte()
            Call introducirTiposIVA()
            Call introducirTiposRetencion()
            Call introducirBancos()
            Call IntroducirTiposArticulo()
            Call IntroducirSubTiposArticulo()

            Dim cmArticuloProv As New ContextMenu
            Dim HacePedidosProv As Boolean = funcPE.Permiso(Inicio.vIdUsuario, "NuevoPedidoProv")
            cmArticuloProv.MenuItems.Add("Ver ficha del artículo", New System.EventHandler(AddressOf Me.OnClickArticulo))
            cmArticuloProv.MenuItems.Add("Ver estadísticas del artículo-proveedor", New System.EventHandler(AddressOf Me.lvArticulosComprados_DoubleClick))
            If HacePedidosProv Then cmArticuloProv.MenuItems.Add("Pedido a proveedor del artículo", New System.EventHandler(AddressOf Me.OnClickPedidoProv))
            lvArticulosComprados.ContextMenu = cmArticuloProv

            If iidProveedor = 0 Then
                Me.Text = "NUEVO PROVEEDOR"
                tbcontactos.Parent = Nothing
                tbfacturacion.Parent = Nothing
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                bSubir.Visible = True
                bBajar.Visible = True
                Me.Text = "GESTIÓN DE PROVEEDOR  " & nombrecomercial.Text
            End If
            Call CargarProveedor()
            If AbrirTab <> -1 Then
                tbdatos.SelectedIndex = AbrirTab
                If iidProveedor > 0 Then
                    'Call ValidarGeneral()
                    If AbrirTab = 2 Then Call ValidarFacturacion()
                    If AbrirTab = 1 Then
                        If iidubicacionP > 0 Then
                            Dim dtsU As datosUbicacion = funcU.mostrar1(iidubicacionP)
                            cbDirecciones.Text = dtsU.gTipoUbicacion & ": " & dtsU.glocalidad & ", " & dtsU.gdireccion
                        End If
                    End If
                End If
                If iidArticulo > 0 Then
                    lvArticulosComprados.Focus()
                    For Each item As ListViewItem In lvArticulosComprados.Items
                        If item.Text = iidArticulo Then
                            item.Selected = True
                            item.Focused = True
                        End If
                        lvArticulosComprados.Focus()
                    Next
                End If
            End If
            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarProveedor()
        semaforo = False
        Call borrargeneral()
        If iidProveedor = 0 Or iidProveedor = -1 Then
            codProveedor.Text = funcPR.NuevocodProveedor
        Else
            Call CargardatosProveedor()
            Call CargarContactos()
            Call CargarUbicaciones()
            Call CargarFacturacion()
            Call LimpiarBusquedaArticulo()
            Call CargarlvArtComprados()
        End If
        semaforo = True
    End Sub

    Private Sub borrargeneral()
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""
        dtpFechaAlta.Value = Now.Date
        dtpFechaBaja.Value = Now.Date
        dtpFechaBaja.Enabled = False
        ckActivo.Checked = True
        nif.Text = ""
        web.Text = ""
        observaciones.Text = ""
        G_AGeneral = "G"
        lvContactos.Items.Clear()
        Call Limpiarcontactos()
        lvBancos.Items.Clear()
        Call Limpiarfacturacion()
        Call limpiarProveedor()
        lvDirecciones.Items.Clear()
        Call LimpiarDirecciones()

    End Sub

    Private Sub limpiarProveedor()
        dtpFechaAlta.Value = Now.Date
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""
        codContable.Text = ""
        nif.Text = ""
        web.Text = ""
        observaciones.Text = ""
        G_AGeneral = "G"
        cbTipoProveedor.Text = ""
        cbTipoProveedor.SelectedIndex = -1

    End Sub

    Private Sub IntroducirTiposCompra()
        Try
            cbTipoProveedor.Items.Clear()
            Dim lista As List(Of DatosTipoCompra) = funcTC.Mostrar
            Dim dts As DatosTipoCompra
            For Each dts In lista
                cbTipoProveedor.Items.Add(New IDComboBox(dts.gTipoCompra, dts.gIdTipoCompra))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

#End Region

#Region "DIRECCIONES"

    Private Sub LimpiarDirecciones()
        cbTipoU.Text = funcTU.PorDefectoProv()
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

    End Sub

    Private Sub CargarUbicaciones()
        Dim lista As List(Of datosUbicacion) = funcU.mostrarProv(iidProveedor, True, 0, 0, 1, 0, 0, 0)
        Dim dts As datosUbicacion
        lvDirecciones.Items.Clear()
        For Each dts In lista
            Call NuevaLineaDirecciones(dts)
        Next
    End Sub

    Private Sub NuevaLineaDirecciones(ByVal dts As datosUbicacion)
        With lvDirecciones.Items.Add(dts.gidUbicacion)
            .SubItems.Add(dts.gTipoUbicacion)
            .SubItems.Add(dts.gdireccion)
            .SubItems.Add(dts.gcodpostal)
            .SubItems.Add(dts.glocalidad)
            .SubItems.Add(dts.gprovincia)
            .SubItems.Add(dts.gPais)
        End With
    End Sub

    Private Sub ActualizaLineaDirecciones(ByVal dts As datosUbicacion)
        With lvDirecciones.Items(indiceDirecciones)
            .SubItems(1).Text = dts.gTipoUbicacion 'funcTU.TipoUbicacion(dts.gidUbicacion)
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
                cbPaisU.Items.Add(New IDComboBox(dts.gPais, dts.gidPais))
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
                Dim lista As List(Of datosProvincia) = func.mostrar(cbPaisU.SelectedItem.itemdata)
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
            Dim lista As List(Of DatosTipoUbicaciones) = funcTU.MostrarTU(0, 0, 1, 0, 0, 0, 0)
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
                    If funcU.ExisteFiscal(0, iidProveedor) Then
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

            dts.gfechaAlta = dtpFechaAltaU.Value.Date
            dts.gActivo = ckActivo.Checked
            dts.gfechaBaja = dtpFechaBajaU.Value.Date
            dts.ghorario = HorarioU.Text
            dts.gidCliente = 0
            dts.gidProveedor = iidProveedor
            dts.gidIdioma = If(cbIdioma.SelectedIndex = -1, 0, cbIdioma.SelectedItem.itemdata)
            dts.gidPais = cbPaisU.SelectedItem.itemdata
            dts.gidTipoUbicacion = cbTipoU.SelectedItem.itemdata
            dts.glocalidad = cbLocalidad.Text
            dts.gObservaciones = observacioneU.Text
            dts.gprovincia = cbProvincia.Text
            dts.gTipoUbicacion = cbTipoU.Text
            dts.gSubCliente = ""
            If cbTransporte.SelectedIndex = -1 Then
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
            If TelefonoU1.Text <> "" Then funcTel.insertar(New DatosTelefono(iidProveedor, 0, iidUbicacion, 0, 1, TelefonoU1.Text, 1))
            If TelefonoU2.Text <> "" Then funcTel.insertar(New DatosTelefono(iidProveedor, 0, iidUbicacion, 0, 1, TelefonoU2.Text, 2))
            If faxU.Text <> "" Then funcTel.insertar(New DatosTelefono(iidProveedor, 0, iidUbicacion, 0, 3, faxU.Text, 1))
            funcMail.borrarUbicacion(iidUbicacion)
            If emailU.Text <> "" Then validar = funcMail.insertar(New DatosMail(iidProveedor, 0, iidUbicacion, 0, 0, emailU.Text, 1))

            Call LimpiarDirecciones()
            Call CargarDirecciones()
            Return validar
        End If
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

    Private Sub lvDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDirecciones.Click
        If lvDirecciones.SelectedItems.Count > 0 Then
            indiceDirecciones = lvDirecciones.SelectedIndices(0)
            iidUbicacion = lvDirecciones.Items(indiceDirecciones).Text
            Dim dts As datosUbicacion = funcU.mostrar1(iidUbicacion)
            cbTipoU.Text = dts.gTipoUbicacion
            dtpFechaAltaU.Value = dts.gfechaAlta
            ckActivoU.Checked = dts.gActivo
            dtpFechaBajaU.Value = dts.gfechaBaja
            dtpFechaBajaU.Visible = Not dts.gActivo
            lbBajaU.Visible = Not dts.gActivo
            Direccion.Text = dts.gdireccion
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
            If dts.gidTransporte = 0 Then
                cbTransporte.Text = dts.gTransporte
            Else
                cbTransporte.Text = dts.gAgenciaTransporte
            End If
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
        End If
    End Sub

    Private Sub cbPaisUbicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaisU.SelectedIndexChanged, cbMoneda.SelectedIndexChanged, cbIdioma.SelectedIndexChanged, cbTransporte.SelectedIndexChanged
        If semaforo Then
            introducirProvincias()
            espUbic = (cbPaisU.Text = "ESPAÑA" Or cbPaisU.Text = "ESPANYA")
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

        End If

    End Sub

#End Region

#Region "CONTACTOS"

    Private Sub CargarDirecciones()
        cbDirecciones.Items.Clear()
        Dim Lista As List(Of datosUbicacion) = funcU.mostrarProv(iidProveedor, 1, 0, 0, 1, 0, 0, 0)
        For Each dts As datosUbicacion In Lista
            cbDirecciones.Items.Add(New IDComboBox(dts.gTipoUbicacion & ": " & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
        Next
        If Lista.Count = 1 Then cbDirecciones.SelectedIndex = 0 'Si solo hay uno, lo ponemos

    End Sub

    Private Sub Limpiarcontactos()
        nombrecontacto.Text = ""
        apellidoscontacto.Text = ""
        cargocontacto.Text = ""
        cbDepartamento.Text = ""
        cbDepartamento.SelectedIndex = -1
        emailContacto.Text = ""
        TelefonoContacto.Text = ""
        MovilContacto.Text = ""
        ObservacionesContacto.Text = ""
        iidContacto = 0
        indiceContactos = -1
        G_AContacto = "G"

    End Sub

    Private Sub CargarContactos()
        lvContactos.Items.Clear()
        Dim lista As List(Of datosContacto) = funcCT.mostrarProv(iidProveedor)
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
                dts.gidCliente = 0
                dts.gidProveedor = iidProveedor
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
                    funcMail.insertar(New DatosMail(iidProveedor, 0, dts.gidUbicacion, iidContacto, 0, emailContacto.Text, 1))
                End If
                'Guardar teléfonos
                funcTel.borrarContacto(iidContacto)
                funcTel.insertar(New DatosTelefono(iidProveedor, 0, dts.gidUbicacion, iidContacto, 1, TelefonoContacto.Text, 1))
                funcTel.insertar(New DatosTelefono(iidProveedor, 0, dts.gidUbicacion, iidContacto, 2, MovilContacto.Text, 2))
                If indiceContactos = -1 Then
                    NuevaLineaContactos(dts)
                Else
                    ActualizaLineaContactos(dts)
                End If
                Call Limpiarcontactos()
            End If
            Return validar

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub lvContactos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvContactos.Click
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

#End Region

#Region "FACTURACION"

    Private Sub CargarFacturacion()
        Try
            dtsDF = funcFA.mostrarProv(iidProveedor)
            If dtsDF.gidProveedor = iidProveedor Then 'Si se ha encontrado facturación de este Proveedor, caqrgamos los datos
                iidFacturacion = dtsDF.gidFacturacion
                cbTipoPago.Text = dtsDF.gTipoPago
                cbMedioPago.Text = dtsDF.gMedioPago
                cbDiaPago1.Text = dtsDF.gDiaPago1
                cbDiaPago2.Text = dtsDF.gDiaPago2
                'ckAlbaranValorado.Checked = dtsDF.gAlbaranValorado
                ckExentoPagosAgosto.Checked = dtsDF.gExentoPagosAgosto
                cbMoneda.Text = dtsDF.gDivisa
                ProntoPago.Text = dtsDF.gProntoPago
                Descuento.Text = dtsDF.gDescuento
                'Descuento2.Text = dts.gDescuento2
                cbTipoIVA.Text = dtsDF.gNombreTipoIVA & " " & dtsDF.gTipoIVA & "%"
                ckRecargoEquivalencia.Checked = dtsDF.gRecargoEquivalencia
                RecargoEq.Visible = ckRecargoEquivalencia.Checked
                lbRecargoEq.Visible = ckRecargoEquivalencia.Checked
                RecargoEq.Text = dtsDF.gTipoRecargoEq
                cbRetencion.Text = dtsDF.gNombreTipoRet & " " & dtsDF.gTipoRetencion & "%"
                ObservacionesF.Text = dtsDF.gObservaciones

                llenarBancos()
            Else
                iidFacturacion = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub llenarBancos()
        lvBancos.Items.Clear()
        Select Case cbMedioPago.Text
            Case "TRANSFERENCIA"
                If dtsDF.gCuentas Is Nothing Then
                Else
                    For Each dtsB As DatosCuentaBancaria In dtsDF.gCuentas
                        Call nuevaLineaBanco(dtsB)
                    Next
                End If
        End Select
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
                '.ForeColor = colorInactivo
                .ForeColor = Color.Gray
            End If
        End With
    End Sub

    Public Sub insertaCuentas(ByVal dtsB As DatosCuentaBancaria)
        If funcCB.comprobarExisteIBAN(codigoEU.Text, codigobanco.Text, codigooficina.Text, codigodc.Text, codigocuenta.Text, ckActivoB.Checked) = True Then
            MsgBox("Esta cuenta ya existe en otro proveedor.", MsgBoxStyle.Information)
            CargarFacturacion()
        Else
            funcCB.insertar(dtsB)
            CargarFacturacion()
        End If
    End Sub

    Private Sub ActualizarLineaBanco(ByVal dtsB As DatosCuentaBancaria)
        funcCB.actualizar(dtsB)
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
                cbTipoIVA.Items.Add(New IDComboBox(dts.gNombre & " " & dts.gTipoIVA & "%", dts.gidTipoIVA))
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

    Private Sub Limpiarfacturacion()
        ep1.Clear()
        ep1B.Clear()
        ep2.Clear()
        ep2B.Clear()
        cbTipoPago.Text = ""
        cbTipoPago.SelectedIndex = -1
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        ProntoPago.Text = 0
        Descuento.Text = 0
        'Descuento2.Text = 0
        'ckAlbaranValorado.Checked = False
        cbTipoIVA.SelectedItem = DI.TipoIVA
        cbRetencion.SelectedItem = DI.TipoRetencion
        ckRecargoEquivalencia.Checked = False
        RecargoEq.Text = 0
        cbDiaPago1.Text = 0
        cbDiaPago1.SelectedIndex = -1
        cbDiaPago2.Text = 0
        cbDiaPago2.SelectedIndex = -1
        ckExentoPagosAgosto.Checked = False
        ObservacionesF.Text = ""
        iidFacturacion = 0
        Call LimpiarBanco()
        lvBancos.Items.Clear()
    End Sub

    Private Sub LimpiarBanco()
        ep1B.Clear()
        ep2B.Clear()
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
                dts.gDescuento2 = 0 'Descuento2.Text
                dts.gidMedioPago = cbMedioPago.SelectedItem.itemdata
                dts.gidTipoPago = cbTipoPago.SelectedItem.itemdata
                dts.gDiaPago1 = cbDiaPago1.Text
                dts.gDiaPago2 = cbDiaPago2.Text
                'dts.gAlbaranValorado = True
                dts.gidTipoValorado = 1
                dts.gExentoPagosAgosto = ckExentoPagosAgosto.Checked
                dts.gidTipoIVA = cbTipoIVA.SelectedItem.itemdata
                dts.gRecargoEquivalencia = ckRecargoEquivalencia.Checked
                dts.gidTipoRetencion = If(cbRetencion.SelectedIndex = -1, 0, cbRetencion.SelectedItem.itemdata)
                dts.gidFacturacion = iidFacturacion
                dts.gObservaciones = ObservacionesF.Text
                dts.gidCliente = 0
                dts.gidProveedor = iidProveedor
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
                Call CargarProveedor()
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
        Return Validar
    End Function

    Private Sub bMasBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMasBanco.Click
        Dim i As Integer = 0
        Dim validar As Boolean = True
        'If codigoEU.TextLength <> 4 Then
        'End If
        ep1B.Clear()
        ep2B.Clear()
        codigoEU.Text = codigoEU.Text.PadRight(4, "0")
        codigobanco.Text = codigobanco.Text.PadLeft(4, "0")
        codigooficina.Text = codigooficina.Text.PadLeft(4, "0")
        codigodc.Text = codigodc.Text.PadLeft(2, "0")
        codigocuenta.Text = codigocuenta.Text.PadLeft(10, "0")

        If IBAN.Text.Length = 0 And Microsoft.VisualBasic.Left(codigoEU.Text, 2) = "ES" And codigoEU.TextLength = 4 Then
            IBAN.Text = codigoEU.Text & codigobanco.Text & codigooficina.Text & codigodc.Text & codigocuenta.Text
        End If
        If cbBanco.SelectedIndex = -1 Then
            ep1B.SetError(cbBanco, "Debe seleccionar un banco")
            validar = False
        End If
        If IBAN.Text.Length < 2 Then
            validar = False
            ep1B.SetError(IBAN, "Debe introducir el IBAN")
        ElseIf cbBanco.SelectedIndex <> -1 Then
            If funcBA.VerificarIBAN(cbBanco.SelectedItem.ItemData) Then 'Si es un pais de exportación o donde el NIF no es obligatorio,solo avisamos
                If Not IBANValidacion(IBAN.Text) Then
                    validar = False
                    ep1B.SetError(IBAN, "IBAN incorrecto")
                End If
            Else
                If Not IBANValidacion(IBAN.Text) Then
                    MsgBox("El IBAN indicado se ha guardado, por tratarse de un país marcado como EXPORTACIÓN o sin NIF obligatorio, aunque no parece correcto.")
                    ep2B.SetError(IBAN, "IBAN aparentemente incorrecto")
                End If
            End If
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
            If lvBancos.Items.Count > 0 Then
                Dim item As ListViewItem
                For Each item In lvBancos.SelectedItems
                    i = i + 1
                Next
            End If
            If i <= 1 Then
                If i < 1 Then
                    Call insertaCuentas(dts)
                Else
                    Call ActualizarLineaBanco(dts)
                End If
            Else
                MsgBox("Solo es posible actualizar una cuenta.", MsgBoxStyle.Information, "ACTUALIZAR CUENTA")
            End If

            'If i = 1 Then
            '    i = indiceB + 1
            '    If i < 1 Then
            '        Call insertaCuentas(dts)
            '    Else
            '        Call ActualizarLineaBanco(dts)
            '    End If
            'Else
            '    MsgBox("Solo es posible actualizar una cuenta.", MsgBoxStyle.Information, "ACTUALIZAR CUENTA")
            'End If
                Call LimpiarBanco()
            ep1.Clear()
            i = 0
            End If
    End Sub

    Private Sub bMenosBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMenosBancos.Click
        If indiceB > -1 Then
            idCuentaBanco = 0
            idCuentaBanco = lvBancos.Items.Item(indiceB).SubItems(0).Text
            If MsgBox("¿Eliminar la cuenta seleccionada?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                lvBancos.Items.RemoveAt(indiceB)
                funcCB.borrar(idCuentaBanco, iidProveedor)
                Call LimpiarBanco()
            End If
        End If
    End Sub

    Private Sub lvBancos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBancos.Click
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

    Private Sub bLimpiaBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiaBanco.Click
        Call LimpiarBanco()
    End Sub

    Private Sub ckRecargoEquivalencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.CheckedChanged
        RecargoEq.Visible = ckRecargoEquivalencia.Checked
        lbRecargoEq.Visible = ckRecargoEquivalencia.Checked
    End Sub

    Private Sub cbTipoIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoIVA.SelectedIndexChanged
        If semaforo Then
            If cbTipoIVA.SelectedIndex <> -1 Then
                RecargoEq.Text = funcTI.TipoRecargoEq(cbTipoIVA.SelectedItem.itemdata)
            End If
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
        If cbMedioPago.SelectedIndex <> -1 Then
            Select Case cbMedioPago.Text
                Case "TRANSFERENCIA"
                    gbBancos.Visible = True
                    gbBancos.Enabled = funcMP.RequiereBanco(cbMedioPago.SelectedItem.itemdata)
                    llenarBancos()
                Case Else
                    gbBancos.Visible = False
            End Select
        End If

    End Sub

#End Region

#Region "CARGAR DATOS GENERALES"


    Private Sub CargardatosProveedor()
        Try
            semaforo = False
            Dim dts As datosProveedor = funcPR.mostrar1(iidProveedor)

            codProveedor.Text = dts.gcodProveedor
            codContable.Text = If(dts.gcodContable = 0, "", CStr(dts.gcodContable))
            suCliente.Text = dts.gSuCliente
            nombrecomercial.Text = dts.gnombrecomercial
            Me.Text = "GESTIÓN DE PROVEEDOR  " & nombrecomercial.Text
            nombrefiscal.Text = dts.gnombrefiscal
            dtpFechaAlta.Value = dts.gFechaAlta
            dtpFechaBaja.Value = dts.gfechaBaja
            ckActivo.Checked = dts.gActivo
            dtpFechaBaja.Visible = (ckActivo.CheckState = CheckState.Unchecked)
            lbBaja.Visible = dtpFechaBaja.Visible
            nif.Text = dts.gnif
            web.Text = dts.gweb
            cbTipoProveedor.Text = dts.gTipoCompra
            observaciones.Text = dts.gobservaciones
            'cbMoneda.Text = funcM.CampoDivisa(dts.gcodMoneda)
            If nombrecomercial.Text <> "" Then G_AGeneral = "A"
            Call CargarDirecciones()
            semaforo = True
            ' bGuardar.Text = "ACTUALIZAR"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




#End Region

#Region "ARTICULOS Comprados"

    Private Sub LimpiarBusquedaArticulo()
        semaforo = False
        dtpArticulosCompradosDesde.Value = funcPP.buscaPrimerDia(iidProveedor)
        dtpArticulosCompradosHasta.Value = funcPP.buscaUltimoDia(iidProveedor)
        cbTipo.Text = ""
        cbSubTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.SelectedIndex = -1
        semaforo = True
    End Sub

    Private Sub CargarlvArtComprados()
        lvArticulosComprados.Items.Clear()
        Dim sel As String
        sel = "select distinct CP.idArticulo, codArticulo, Articulo,ArticuloProv, codArticuloProv, PP.codMoneda, TipoArticulo, subTipoArticulo, Familia, subFamilia, "
        sel = sel & "case when CP.idArticulo=0 then  PrecioNetoUnitario else "
        sel = sel & "(select TOP 1 PrecioNetoUnitario from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC,idConcepto DESC) end as UltimoPrecioNeto,   "
        sel = sel & "case when CP.idArticulo=0 then  CP.numPedido else "
        sel = sel & "(select TOP 1 PedidosProv.numPedido from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as UltimoPedido, "
        sel = sel & "case when CP.idArticulo=0 then  PP.FechaPedido else "
        sel = sel & "(select TOP 1 PedidosProv.FechaPedido from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as UltimaFecha, "
        sel = sel & "(select Top 1 Simbolo from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido left join Monedas ON Monedas.codMoneda = PedidosProv.codMoneda where PedidosProv.numPedido = CP.numPedido) as Simbolo,  "
        sel = sel & "case when CP.idArticulo=0 then CP.Cantidad else  (select sum(Cantidad) from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido  where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor) end as CantidadTotal,  "

        sel = sel & "case when CP.idArticulo=0 then CP.PrecioNetoUnitario else  (select sum(Cantidad*PrecioNetoUnitario) from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido  where idArticulo<>0 and idArticulo = CP.idArticulo and codArticuloProv = CP.codArticuloProv and ArticuloProv = CP.ArticuloProv  and PedidosProv.idProveedor = PP.idProveedor "
        sel = sel & " AND CONVERT(datetime,CONVERT(Char(10), PedidosProv.fechaPedido,103))  >= '" & dtpArticulosCompradosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PedidosProv.fechaPedido,103))  <= '" & dtpArticulosCompradosHasta.Value.Date & "'  ) end as ImporteTotal  "

        sel = sel & " from ConceptosPedidosProv as CP"
        sel = sel & " left Join PedidosProv as PP ON PP.numPedido = CP.numPedido "
        sel = sel & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo "
        sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
        sel = sel & " left join subTiposArticulo ON subTiposArticulo.idSubTipoArticulo = AR.idSubTipoArticulo "
        sel = sel & " left join Familias ON Familias.idFamilia = AR.idFamilia "
        sel = sel & " left join subFamilias ON SubFamilias.idSubFamilia = AR.idSubFamilia "

        sel = sel & " Where PP.idProveedor = " & iidProveedor & " AND CONVERT(datetime,CONVERT(Char(10), PP.fechaPedido,103))  >= '" & dtpArticulosCompradosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PP.fechaPedido,103))  <= '" & dtpArticulosCompradosHasta.Value.Date & "'"
        'sel = sel & " Where PP.idProveedor = " & iidProveedor & " AND CONVERT(datetime,CONVERT(Char(10), PP.fechaPedido,103))  >= '" & dtpArticulosCompradosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PP.fechaPedido,103))  <= '" & dtpArticulosCompradosHasta.Value.Date & "'"

        If cbTipo.Text <> "" And cbTipo.Text <> "TODOS" And cbTipo.Text <> "TODAS" Then sel = sel & " AND (TipoArticulo = '" & cbTipo.Text & "'  OR Familia = '" & cbTipo.Text & "' )"
        If cbSubTipo.Text <> "" And cbSubTipo.Text <> "TODOS" And cbSubTipo.Text <> "TODAS" Then sel = sel & " AND  (SubTipoArticulo = '" & cbSubTipo.Text & "' OR subFamilia = '" & cbSubTipo.Text & "'   ) "
        If cbArticuloComprados.Text <> "" Then sel = sel & " and CP.ArticuloProv = '" & cbArticuloComprados.Text & "' "
        sel = sel & " Order by Articulo ASC"

        Dim dt As DataTable = funcPR.BusquedaSQL(sel)
        Dim SumaCantidad As Double = 0
        Dim SumaImporte As Double = 0
        Dim codMoneda As String
        Dim ImporteTotal As Double
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        lvwColumnSorterAC = New OrdenarLV()
        lvArticulosComprados.ListViewItemSorter = lvwColumnSorterAC
        For Each linea As DataRow In dt.Rows
            If linea("idArticulo") Is DBNull.Value Then
            Else
                With lvArticulosComprados.Items.Add(linea("idArticulo"))
                    .subitems.add(If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo")))
                    .subitems.add(If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")))
                    .subitems.add(If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv")))
                    .subitems.add(If(linea("ArticuloProv") Is DBNull.Value, "", linea("ArticuloProv")))
                    .subitems.add(FormatNumber(If(linea("CantidadTotal") Is DBNull.Value, 0, linea("CantidadTotal")), 2))
                    .subitems.add(FormatNumber(If(linea("UltimoPrecioNeto") Is DBNull.Value, 0, linea("UltimoPrecioNeto")), 2) & If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo")))
                    .subitems.add(If(linea("UltimoPedido") Is DBNull.Value, "", linea("UltimoPedido")))
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

        IntroducirArticulosComprados()

        lbCambioVendidos.Text = "CAMBIO " & FechaCambioG
        lbCambioVendidos.Visible = AvisoG
        ContadorVendidos.Text = lvArticulosComprados.Items.Count
        CantidadVendidos.Text = FormatNumber(SumaCantidad, 2)
        TotalVendidos.Text = FormatNumber(SumaImporte, 2)
    End Sub

    Private Sub lvArticulosComprados_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvArticulosComprados.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorterAC.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorterAC.Order = SortOrder.Ascending) Then
                lvwColumnSorterAC.Order = SortOrder.Descending
            Else
                lvwColumnSorterAC.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorterAC.SortColumn = e.Column

            lvwColumnSorterAC.Order = SortOrder.Ascending
        End If
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        lvArticulosComprados.Sort()

    End Sub

    Private Sub lvArticulosComprados_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulosComprados.DoubleClick
        'Al hacer doble click, 
        If lvArticulosComprados.SelectedItems.Count > 0 Then
            Dim iidArticulo As Integer = lvArticulosComprados.SelectedItems(0).Text
            If iidArticulo = 0 Then
                MsgBox("La linea seleccionada no se corresponde con un artículo válido")
            Else
                Dim GG As New InformeListadoArticulosComprados
                GG.pidArticulo = iidArticulo
                GG.pidProveedor = iidProveedor
                GG.pDesde = dtpArticulosCompradosDesde.Value.Date
                GG.pHasta = dtpArticulosCompradosHasta.Value.Date
                GG.pDetalle = True
                GG.verInforme()
                GG.ShowDialog()
            End If

        End If
    End Sub

    Private Sub IntroducirArticulosComprados()

        If cbArticuloComprados.Items.Count > 0 Then

        Else

            cbArticuloComprados.Items.Clear()

            cbArticuloComprados.Text = ""

            If lvArticulosComprados.Items.Count > 0 Then

                For Each item In lvArticulosComprados.Items

                    Dim i As Integer = 0

                    If cbArticuloComprados.Items.Count > 0 Then

                        For Each itemCb In cbArticuloComprados.Items

                            If itemCb = item.SubItems(4).Text Then

                                i = 1

                            End If

                        Next

                        If i <> 1 Then

                            cbArticuloComprados.Items.Add(item.SubItems(4).Text)

                        End If
                    Else

                        cbArticuloComprados.Items.Add(item.SubItems(4).Text)

                    End If

                Next

            End If

        End If

       

    End Sub


    Private Sub dtpArticulosCompradosHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpArticulosCompradosHasta.ValueChanged, dtpArticulosCompradosDesde.ValueChanged, cbTipo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged
        If semaforo Then Call CargarlvArtComprados()
    End Sub

    Protected Sub OnClickPedidoProv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvArticulosComprados.SelectedItems.Count <> 0 Then
            iidArticulo = lvArticulosComprados.SelectedItems(0).Text
            If iidArticulo = 0 Then
                MsgBox("La linea seleccionada no se corresponde con un artículo válido")
            Else
                Dim GG As New subUltimoPedidoArticulo
                GG.pidArticulo = iidArticulo
                GG.pidProveedor = iidProveedor
                GG.SoloLectura = vSoloLectura
                GG.VerBotonPedido = True
                GG.ShowDialog()
                If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                    Call CargarlvArtComprados()
                End If
            End If
        End If
    End Sub

    Protected Sub OnClickArticulo(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If lvArticulosComprados.SelectedItems.Count <> 0 Then
            Dim indice As Integer = lvArticulosComprados.SelectedIndices(0)
            iidArticulo = lvArticulosComprados.Items(indice).Text
            Dim GG As New GestionArticulo
            GG.pidArticulo = iidArticulo
            GG.SoloLectura = vSoloLectura
            GG.ShowDialog()
            'Por si hemos cambiado algo de la ficha del artículo
            lvArticulosComprados.Items(indice).SubItems(1).Text = funcAR.codArticulo(iidArticulo)
            lvArticulosComprados.Items(indice).SubItems(2).Text = funcAR.Articulo(iidArticulo)
        End If
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Function GuardarGeneral() As Boolean
        Try
            If ValidarGeneral() Then
                Dim dts As New datosProveedor
                dts.gcodMoneda = "EU" 'cbMoneda.SelectedItem.itemdata
                dts.gcodContable = If(IsNumeric(codContable.Text), CInt(codContable.Text), 0)
                dts.gcodProveedor = codProveedor.Text
                dts.gFechaAlta = dtpFechaAlta.Value.Date
                dts.gfechaBaja = dtpFechaBaja.Value.Date
                dts.gnif = nif.Text
                dts.gnombrecomercial = nombrecomercial.Text
                dts.gnombrefiscal = nombrefiscal.Text
                dts.gobservaciones = observaciones.Text
                dts.gweb = web.Text
                dts.gidProveedor = iidProveedor
                dts.gActivo = ckActivo.Checked
                dts.gIdTipoCompra = cbTipoProveedor.SelectedItem.itemdata
                dts.gSuCliente = suCliente.Text
                If G_AGeneral = "A" Then
                    funcPR.actualizar(dts)
                Else
                    iidProveedor = funcPR.insertar(dts)
                    G_AGeneral = "A"
                    Me.Text = "GESTIÓN DE PROVEEDOR  " & nombrecomercial.Text
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function ValidarGeneral() As Boolean

        Dim validar As Boolean = True
        'Quitamos los espacios en los textbox para que no esten en blanco
        nombrecomercial.Text = nombrecomercial.Text.Trim()
        nombrefiscal.Text = nombrefiscal.Text.Trim()
        Direccion.Text = Direccion.Text.Trim()

        'Iniciamos validación de campos.
        If nombrecomercial.Text = "" Then
            validar = False
            ep1.SetError(nombrecomercial, "Se ha de especificar un nombre comercial")
        End If
        If nombrefiscal.Text = "" Then
            validar = False
            ep1.SetError(nombrefiscal, "Se ha de especificar un nombre fiscal")
        End If
        If G_AGeneral = "G" Then
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
            End If
        End If
        If codContable.Text <> "" Then
            If funcPR.codContableExiste(codContable.Text, iidProveedor) Then
                validar = False
                ep1.SetError(codContable, "Código contable existente")
            End If
        End If

        If codProveedor.Text <> "" Then
            If funcPR.codProveedorExiste(codProveedor.Text, iidProveedor) Then
                validar = False
                ep1.SetError(codProveedor, "Código de proveedor existente")
            End If
        End If
        If cbTipoProveedor.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbTipoProveedor, "Se ha de seleccionar un tipo de proveedor")
        End If

        If funcPR.validarNIF(nif.Text, iidProveedor) Then
            If MsgBox("Este NIF ya está siendo utilizado por otro proveedor, ¿Desea continuar de todos modos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Else
                validar = False
                ep1.SetError(nif, "Este NIF ya está siendo utilizado por otro proveedor")
            End If
        End If

        Return validar
    End Function

#End Region

#Region "BOTONES GENERALES"

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Call Guardar()

    End Sub

    Private Sub Guardar()
        Try
            Dim correcto As Boolean = False
            ep1.Clear()
            If GuardarGeneral() Then  'Si se ha validado el guardar general
                correcto = True
                tbcontactos.Parent = tbdatos
                tbfacturacion.Parent = tbdatos
                If cbMedioPago.SelectedIndex <> -1 Then
                    gbBancos.Enabled = funcMP.RequiereBanco(cbMedioPago.SelectedItem.itemdata)
                End If
                Select Case tbdatos.SelectedTab.Name
                    Case tbUbicaciones.Name
                        If Direccion.Text.Length > 0 Then
                            correcto = correcto And GuardarDireccion()
                            'CargarDirecciones()
                        End If

                    Case tbcontactos.Name
                        If nombrecontacto.TextLength > 0 Or apellidoscontacto.TextLength > 0 Then
                            correcto = correcto And GuardarContacto()
                        End If
                    Case tbfacturacion.Name
                        correcto = correcto And GuardarFacturacion()
                    Case Else
                End Select
            End If
            If correcto Then MsgBox("Proveedor guardado correctamente")

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
                                Me.Text = "NUEVO PROVEEDOR"
                                codProveedor.Text = funcPR.NuevocodProveedor
                            End If
                        Else
                            Call borrargeneral()
                            Me.Text = "NUEVO PROVEEDOR"
                            iidProveedor = 0
                            codProveedor.Text = funcPR.NuevocodProveedor
                            tbcontactos.Parent = Nothing
                            tbfacturacion.Parent = Nothing

                        End If
                    Case tbcontactos.Name
                        Call Limpiarcontactos()
                    Case tbUbicaciones.Name
                        Call LimpiarDirecciones()
                    Case tbArticulos.Name
                        Call LimpiarBusquedaArticulo()
                        Call CargarlvArtComprados()
                End Select
            Else  'Nuevo PROVEEDOR
                If MsgBox("Se perderán los datos que no haya guardado", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call borrargeneral()
                    Me.Text = "NUEVO PROVEEDOR"
                    codProveedor.Text = funcPR.NuevocodProveedor
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Select Case tbdatos.SelectedTab.Name

            Case tbArticulos.Name
                Dim GG As New InformeListadoArticulosComprados
                GG.pidArticulo = 0
                GG.pidProveedor = iidProveedor
                GG.pDesde = dtpArticulosCompradosDesde.Value.Date
                GG.pHasta = dtpArticulosCompradosHasta.Value.Date
                GG.pDetalle = False
                GG.verInforme()
                GG.ShowDialog()

            Case Else

        End Select



    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        Try
            Select Case tbdatos.SelectedTab.Name
                Case tbfacturacion.Name
                    If MsgBox("¿Borrar el Proveedor?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        If funcPR.borrar(iidProveedor) Then
                            Call borrargeneral()
                            Me.Text = "NUEVO PROVEEDOR"
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
                        If MsgBox("¿Borrar la dirección especificada?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            funcU.borrar(iidUbicacion)
                            lvDirecciones.Items.RemoveAt(indiceDirecciones)
                            Call LimpiarDirecciones()
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If Not Proveedores Is Nothing Then
            If IndiceL > 0 Then
                IndiceL = IndiceL - 1
                iidProveedor = Proveedores(IndiceL)
                cbArticuloComprados.Items.Clear()
                Call CargarProveedor()
            End If
        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If Not Proveedores Is Nothing Then
            If IndiceL < Proveedores.Count - 1 Then
                IndiceL = IndiceL + 1
                iidProveedor = Proveedores(IndiceL)
                cbArticuloComprados.Items.Clear()
                Call CargarProveedor()
            End If
        End If
    End Sub

    Private Sub bTiposProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposProveedor.Click
        Dim GG As New GestionTiposCompra
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirTiposCompra()
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

#End Region

#Region "EVENTOS GENERALES"

    Private Sub nombrecomercial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nombrecomercial.TextChanged
        If semaforo Then
            nombrefiscal.Text = nombrecomercial.Text
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
        End If
    End Sub

    Private Sub gbCabecera_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbCabecera.Enter, tbfacturacion.Enter
        bNuevo.Text = "NUEVO PROVEEDOR"
        bBorrar.Text = "BORRAR PROVEEDOR"
    End Sub

    Private Sub gbCabecera_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcontactos.Enter, tbUbicaciones.Enter 'gbCabecera.Leave
        bNuevo.Text = "NUEVO"
        bBorrar.Text = "BORRAR"
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
    'Con esto bloqueamos el campo de texto CodProveedor para que no sea editable.
    Dim n As Integer
    Private Sub codProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codProveedor.KeyPress
        If Not IsNumeric(e.KeyChar) Or IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub codProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles codProveedor.KeyDown
        e.SuppressKeyPress = (e.KeyData = Keys.Delete)
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

    Private Sub Descuento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Descuento.Click, ProntoPago.Click, cbDiaPago1.Click, cbDiaPago2.Click
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

#End Region

#Region "CODIGO DESCARTADO RAFA"
    'Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If lvConceptos.SelectedItems.Count > 0 Then
    '        Dim numPedidoProv As String = lvConceptos.SelectedItems(0).SubItems(7).Text
    '        If numPedidoProv <> "" And numPedidoProv <> "0" Then
    '            Dim GG As New InformePedidoProv
    '            Dim funcPP As New FuncionesPedidosProv
    '            GG.verInforme(numPedidoProv, funcPP.idIdioma(numPedidoProv))
    '            GG.ShowDialog()
    '        End If
    '    End If
    'End Sub
    'Private Sub Descuento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = Asc(".") Then
    '        e.KeyChar = ","
    '    End If
    '    If InStr(Descuento2.Text, ",") Then
    '        KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    Else
    '        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
    '    End If
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub GestionProveedores_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    Me.Width = Ancho
    '    If Me.Height < 700 Then Me.Height = 700
    'End Sub

    'DENTRO DE "Sub consultaProveedores_Load" 
    'Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
    'If desktopSize.Height < 850 Then
    '    Me.Height = desktopSize.Height - 50
    'Else
    '    Me.Height = 800
    'End If
#End Region


    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloComprados.SelectedIndexChanged, cbArticuloComprados.TextChanged

        If semaforo Then Call CargarlvArtComprados()

    End Sub

End Class