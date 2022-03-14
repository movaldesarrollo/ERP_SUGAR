Imports System.IO

Public Class GestionAlbaranAProv

    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Albaranes As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesAlbaranes
    Private funcCO As New FuncionesConceptosAlbaranes
  
 
    Private funcAR As New FuncionesArticulos
    Private funcTA As New FuncionesFamilias
    Private funcST As New FuncionessubFamilias
    'Private funcCL As New funcionesclientes
    Private funcUB As New funcionesUbicaciones
    Private funcFA As New funcionesFacturacion
    Private funcCT As New funcionesContactos
    Private funcES As New FuncionesEstados
    Private funcMA As New Master
    Private funcPE As New FuncionesPersonal
    Private funcSV As New FuncionesSolicitadoVia
    Private funcRu As New FuncionesRutas
    Private funcAC As New FuncionesArticulosProv
    'Private funcACP As New funcionesArticuloProvPrecios
    Private funcPR As New funcionesProveedores
    Private funcSK As New FuncionesStock


    Private funcPD As New FuncionesPedidos
    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private dtsOF As DatosAlbaran
    Private dtsPR As datosProveedor
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoAlbaran
    Private dtsAR As DatosArticulo
    Private dtsUB As datosUbicacion
    Private listaC As List(Of DatosConceptoAlbaran)
    Private semaforo As Boolean
    Private iidFamilia As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidProveedor As Integer
    Private localizacion As Point
    Private AvisadoCliente As Boolean
    Private ClienteSoloLectura As Boolean
    Private ConceptosEditables As Boolean


    Public Property pnumAlbaran() As Integer
        Get
            Return numDoc.Text
        End Get
        Set(ByVal value As Integer)
            numDoc.Text = value
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


    Property pAlbaranes() As List(Of Integer)
        Get
            Return Albaranes
        End Get
        Set(ByVal value As List(Of Integer))
            Albaranes = value
        End Set
    End Property

    Property pIndice() As Integer
        Get
            Return indiceL
        End Get
        Set(ByVal value As Integer)
            indiceL = value
        End Set
    End Property

    Property pLocation() As Point
        Get
            Return localizacion
        End Get
        Set(ByVal value As Point)
            localizacion = value
        End Set
    End Property


    Private Sub GestionAlbaran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = True
        If localizacion.X <> 0 Then Me.Location = localizacion
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

        If desktopSize.Height < 1000 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 950
        End If
        AvisadoCliente = False
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        Dim tt As New ToolTip
        tt.InitialDelay = 0
        tt.SetToolTip(bLimpiar, "Limpiar zona de edición")
        tt.SetToolTip(bArticuloProveedor, "Gestión Artículo-Proveedor")
        tt.SetToolTip(bVerArticuloC, "Ver ficha del artículo")
        tt.SetToolTip(bVerProveedor, "Ver ficha del cliente")
        tt.SetToolTip(bBuscarArticuloC, "Búsqueda del artículo")
        tt.SetToolTip(bBuscarProveedor, "Búsqueda del cliente")

        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        cbCodArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbCodArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        cbArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        ClienteSoloLectura = False
        ConceptosEditables = True
        iidUsuario = Inicio.vIdUsuario

        Call introducirMonedas()
        Call IntroducirFamilias()


        Call introducirSolicitadoVia()
        Call introducirTransporte()
        Call introducirTiposValorado()

        Call InicializarGeneral()
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text = 0 Then
            Call introducirProveedores()
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR ALBARÁN A PROVEEDOR"
            gbConceptos.Enabled = True
            If Albaranes Is Nothing Then
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                If Albaranes.Count > 0 Then
                    bSubir.Visible = True
                    bBajar.Visible = True
                Else
                    bSubir.Visible = False
                    bBajar.Visible = False
                End If
            End If

            Call CargarAlbaran()
            'G_AGeneral = "A"
        End If


    End Sub


    Private Sub GestionAlbaran_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
    End Sub


#Region "INICIALIZACIÓN"

    Private Sub Nuevo()
        Me.Text = "NUEVO ALBARÁN A PROVEEDOR"
        ClienteSoloLectura = False
        cbProveedor.Enabled = True
        cbCodProveedor.Enabled = True
        bBuscarProveedor.Enabled = True
        dtsOF = New DatosAlbaran
        gbConceptos.Enabled = False
        numDoc.Text = funcMA.leernumAlbaran(Now.Year) + 1
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumPedido(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        Dim dtsES As DatosEstado = funcES.EstadoCabecera("Albaran")
        cbEstado.Items.Clear()
        cbEstado.Items.Add(dtsES)
        cbEstado.Text = dtsES.ToString
       
        iidProveedor = 0
    End Sub

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()
        ckSeleccion.Checked = False
        ckSeleccion.Visible = True
        lvConceptos.Items.Clear()
        lvConceptos.CheckBoxes = True
        RefCliente.Text = ""
        RefCliente2.Text = ""
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbCodProveedor.Text = ""
        cbCodProveedor.SelectedIndex = -1

        Call introducirPersonal()
        Call LimpiarCabecera()
        Nota.Text = ""
        Observaciones.Text = ""

        Total.Text = 0
        Volumen.Text = ""
        PesoBruto.Text = ""
        PesoNeto.Text = ""
        Medidas.Text = ""
        Bultos.Text = 0
        Call LimpiarEdicion()
        cambios = False
    End Sub

    Private Sub LimpiarCabecera()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()

        dtpFecha.Value = Now.Date
        dtpFechaPrevista.Value = Now.Date

        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbSolicitadoVia.Text = ""
        cbSolicitadoVia.SelectedIndex = -1

        cbMoneda.Text = funcMO.CampoDivisa("EU")
        codMonedaI = "EU"


        cbPortes.Text = ""
        PrecioTransporte.Text = 0
        PrecioTransporte.Enabled = False
    End Sub

    Private Sub LimpiarEdicion()
        cbFamilia.Text = ""
        cbFamilia.SelectedIndex = -1
        cbSubFamilia.Items.Clear()
        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1

        PrecioNeto.Text = 0

        Cantidad.Text = 0
        codArticuloProv.Text = ""
        subTotal.Text = 0
        indice = -1
        iidArticulo = 0
        iidFamilia = 0

        cbArticulo.Items.Clear()
        cbCodArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        numsSerie.Text = ""
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados

    End Sub


    Private Sub IntroducirFamilias()
        cbFamilia.Items.Clear()
        cbSubFamilia.Items.Clear()
        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1
        Dim lista As List(Of DatosFamilia) = funcTA.Mostrar(0, True)
        Dim dts As DatosFamilia
        For Each dts In lista
            cbFamilia.Items.Add(dts)
        Next
    End Sub


    Private Sub IntroducirSubFamilias()
        If iidFamilia > 0 Then
            cbSubFamilia.Text = ""
            cbSubFamilia.SelectedIndex = -1
            cbSubFamilia.Items.Clear()
            Dim lista As List(Of DatosSubFamilia) = funcST.Mostrar(iidFamilia, 0, True)
            Dim dts As DatosSubFamilia
            For Each dts In lista
                cbSubFamilia.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
            Next
        End If
    End Sub

    Private Sub introducirMonedas()
        Try
            cbMoneda.Items.Clear()
            Dim lista As List(Of DatosMoneda) = funcMO.Mostrar()
            For Each dts As DatosMoneda In lista
                cbMoneda.Items.Add(dts)
            Next
            cbMoneda.Text = funcMO.CampoDivisa("EU")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            cbProveedor.Text = ""

            Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
            Dim dts As datosProveedor
            For Each dts In lista
                cbCodProveedor.Items.Add(New IDComboBox(dts.gcodProveedor, dts.gidProveedor))
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Albaran")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next

    End Sub

    Private Sub introducirSolicitadoVia()
        cbSolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbSolicitadoVia.Items.Add(dts)
        Next
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

    Private Sub introducirPersonal()
        cbPersona.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.Listar()
        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        'Cargamos el usuario que ha hecho login, si no está en la lista lo deja en blanco.
        cbPersona.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbPersona.SelectedIndex = -1 Then cbPersona.Text = ""
    End Sub

#End Region


#Region "CARGAR DATOS"

    Private Sub CargarAlbaran()
        ep1.Clear()
        ep2.Clear()
        G_AGeneral = "A"
        dtsOF = funcOF.Mostrar1(numDoc.Text)
        iidProveedor = dtsOF.gidProveedor
        dtsPR = funcPR.mostrar1(dtsOF.gidProveedor)

        Dim dtsES As DatosEstado = funcES.Mostrar1(dtsOF.gidEstado)
        If dtsES.gBloqueado Then
            cbProveedor.Items.Clear()
            cbCodProveedor.Items.Clear()
            cbCodProveedor.Items.Add(New IDComboBox(dtsPR.gcodProveedor, dtsPR.gidProveedor))
            cbProveedor.Items.Add(New IDComboBox(dtsPR.gnombrecomercial, dtsPR.gidProveedor))
            ClienteSoloLectura = True
            bBuscarProveedor.Enabled = False
        Else
            Call introducirProveedores()
            ClienteSoloLectura = False
            bBuscarProveedor.Enabled = True
        End If
        cbProveedor.Text = dtsOF.gProveedor
        cbCodProveedor.Text = dtsPR.gcodProveedor

        Call CargarDatosFacturacionProveedor()
        Call CargarCombosProveedor()
        Call PresentarAvisoProveedor()

        RefCliente.Text = dtsOF.gReferenciaCliente
        RefCliente2.Text = dtsOF.gReferenciaCliente2
        cbPersona.Text = dtsOF.gPersona




        cbMoneda.Text = dtsOF.gDivisa
        lbMoneda1.Text = dtsOF.gSimbolo
        codMonedaI = dtsOF.gcodMoneda
        dtpFecha.Value = dtsOF.gFecha
        dtpFechaPrevista.Value = dtsOF.gFechaEntrega

        cbDireccion.Text = dtsOF.gDireccion
        If cbDireccion.SelectedIndex = -1 Then
            ep2.SetError(cbDireccion, "Dirección no válida")
        Else
            dtsUB = funcUB.mostrar1(dtsOF.gidUbicacion)
        End If


        If dtsOF.gidTransporte = 0 Then
            cbTransporte.Text = dtsOF.gTransporte
        Else
            cbTransporte.Text = dtsOF.gAgenciaTransporte
        End If


        cbContacto.Text = dtsOF.gContacto

        Observaciones.Text = dtsOF.gObservaciones
        Nota.Text = dtsOF.gNotas
        cbSolicitadoVia.Text = dtsOF.gSolicitadoVia
        cbValorado.Text = dtsOF.gTipoValorado
        If dtsOF.gPortes = "P" Then
            cbPortes.Text = "PAGADOS"
            PrecioTransporte.Text = 0
        End If
        If dtsOF.gPortes = "D" Then
            cbPortes.Text = "DEBIDOS"
            PrecioTransporte.Text = 0
        End If
        If dtsOF.gPortes = "I" Then
            cbPortes.Text = "INC.FRA."
            PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
        End If

        If dtsOF.gidTransporte = 0 Then
            cbTransporte.Text = dtsOF.gTransporte
        Else
            cbTransporte.Text = dtsOF.gAgenciaTransporte
        End If

        RefCliente2.Text = dtsOF.gReferenciaCliente2
        Medidas.Text = dtsOF.gMedidas
        cbEstado.Items.Clear()
        'Cargar el estado que tenga y los que falten

        If dtsES.gCabecera Then
            cbEstado.Items.Add(funcES.EstadoCabecera("Albaran"))
            cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
        End If
        If dtsES.gAnulado Then
            cbEstado.Items.Add(funcES.EstadoEnCurso("Albaran"))
            cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
        End If
        If dtsES.gEnCurso Then
            cbEstado.Items.Add(funcES.EstadoEnCurso("Albaran"))
            cbEstado.Items.Add(funcES.EstadoEntregado("Albaran"))
            cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
        End If
        If dtsES.gEntregado Then
            cbEstado.Items.Add(funcES.EstadoEntregado("Albaran"))
        End If
        If dtsES.gTraspasado Then
            cbEstado.Items.Add(funcES.EstadoTraspasado("Albaran"))
        End If
        cbEstado.Text = dtsES.ToString
        If dtsES.gBloqueado Then
            'gbConceptos.Enabled = False
            ConceptosEditables = False
            bGuardar.Enabled = False
        Else
            'gbConceptos.Enabled = True
            ConceptosEditables = True
            bGuardar.Enabled = Not vSoloLectura
        End If

        Call CargarConceptos()

        Total.Text = FormatNumber(dtsOF.gTotal, 2)

        Volumen.Text = FormatNumber(If(dtsOF.gVolumen = 0, dtsOF.gsumaVolumen, dtsOF.gVolumen), 2)
        PesoBruto.Text = FormatNumber(If(dtsOF.gKilosBrutos = 0, dtsOF.gsumaKilosBrutos, dtsOF.gKilosBrutos), 2)
        PesoNeto.Text = FormatNumber(If(dtsOF.gKilosNetos = 0, dtsOF.gsumaKilosNetos, dtsOF.gKilosNetos), 2)
        Bultos.Text = If(dtsOF.gBultos = 0, dtsOF.gsumaBultos, dtsOF.gBultos)

        cambios = False
    End Sub

    Private Sub CargarConceptos()
        listaC = funcCO.Mostrar(numDoc.Text)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoAlbaran In listaC
            nuevaLineaLV(dts)
        Next
        cbArticulo.Focus()
    End Sub

    Private Sub CargarContactos()
        If cbProveedor.SelectedIndex <> -1 Then
            Dim Contacto As String = cbContacto.Text
            cbContacto.Text = ""
            cbContacto.Items.Clear()
            Dim lista As List(Of datosContacto) = funcCT.mostrarCli(cbProveedor.SelectedItem.itemdata)
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


    Private Sub CargarDirecciones()
        If cbProveedor.SelectedIndex <> -1 Then
            Dim direccion As String = cbDireccion.Text
            cbDireccion.Items.Clear()
            Dim lista As List(Of datosUbicacion) = funcUB.mostrarProv(cbProveedor.SelectedItem.itemdata, True, 0, 0, 1, 0, 0, 1)
            For Each dts As datosUbicacion In lista
                cbDireccion.Items.Add(New IDComboBox(If(dts.gSubCliente = "", "", dts.gSubCliente & ": ") & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
            Next
            If direccion.Length > 0 Then
                cbDireccion.Text = direccion
            End If
            If cbDireccion.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbDireccion.SelectedIndex = 0
                    Call DatosDireccion()
                    'dtsUB = funcUB.mostrar1(cbDireccion.Items(0).itemdata)
                    'If dtsUB.gPortes = "P" Then
                    '    cbPortes.Text = "PAGADOS"
                    'Else
                    '    cbPortes.Text = "DEBIDOS"
                    'End If
                Else
                    cbDireccion.Text = ""
                End If

            End If


        End If
    End Sub







    Private Sub CargarDatosFacturacionProveedor()
        Dim semaforo0 As Boolean = semaforo
        dtsFA = funcFA.mostrarCli(iidProveedor)
        If G_AGeneral = "G" Then
            semaforo = False
            Call LimpiarCabecera()
            semaforo = semaforo0
            If dtsFA.gcodMoneda = "" Then
                cbMoneda.Text = funcMO.CampoDivisa("EU")
                lbMoneda1.Text = funcMO.CampoSimbolo("EU")
            Else
                cbMoneda.Text = dtsFA.gDivisa
                codMonedaI = dtsFA.gcodMoneda
                lbMoneda1.Text = dtsFA.gSimbolo
            End If

            cbValorado.Text = dtsFA.gTipoValorado
        End If

    End Sub


    Private Sub PresentarAvisoProveedor()
        If Trim(dtsPR.gobservaciones).Length > 0 And Not AvisadoCliente Then
            MsgBox(dtsPR.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsPR.gnombrecomercial)
            AvisadoCliente = True
        End If
    End Sub





    Private Sub CargarCombosProveedor()
        Call CargarContactos()
        Call CargarDirecciones()

    End Sub


    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)
        If cbProveedor.SelectedIndex = -1 Then
            'Si no hay proveedor seleccionado, buscamos en Articulos directamente
            lista = funcAR.Buscar(" AND Comprable = 1 " & If(cbFamilia.SelectedIndex = -1, "", " AND idFamilia = " & cbFamilia.SelectedItem.gidFamilia) _
                                                & If(cbSubFamilia.SelectedIndex = -1, "", " AND idsubFamilia = " & cbSubFamilia.SelectedItem.itemdata), "")
        Else
            'Si tenemos el proveedor, el nombre del artículo será el específico si existe

            lista = funcAR.BuscarAP(" AND Comprable = 1 " & If(cbFamilia.SelectedIndex = -1, "", " AND idFamilia = " & cbFamilia.SelectedItem.gidFamilia) _
                                                & If(cbSubFamilia.SelectedIndex = -1, "", " AND idsubFamilia = " & cbSubFamilia.SelectedItem.itemdata), cbProveedor.SelectedItem.itemdata, "", dtsUB.gidIdioma)

        End If
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoAlbaran)
        With lvConceptos.Items.Add(" ")
            .SubItems.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gcodArticuloCli)
            .SubItems.Add(dts.gArticuloCli)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%")
            .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo)
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoAlbaran)
        'Actualizar a partir del índice actual
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gcodArticuloCli
                .SubItems(4).Text = dts.gArticuloCli
                .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
                .SubItems(6).Text = FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo
                .SubItems(7).Text = FormatNumber(dts.gDescuento, 2) & "%"
                .SubItems(8).Text = FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo
                .SubItems(9).Text = FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo
            End With
            Call Recalcular(True)
        End If
    End Sub


    Private Sub Recalcular(ByVal CambiaPesos As Boolean)

        funcOF.DatosCalculados(dtsOF) 'Recargamos el dtsOF por referencia

        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
        If CambiaPesos Then 'Hay que saber si recalculamos o no por si hemos puesto datos a mano
            Volumen.Text = FormatNumber(dtsOF.gsumaVolumen, 2)
            PesoBruto.Text = FormatNumber(dtsOF.gsumaKilosBrutos, 2)
            PesoNeto.Text = FormatNumber(dtsOF.gsumaKilosNetos, 2)
            Bultos.Text = dtsOF.gsumaBultos
        End If
    End Sub


    Private Function GuardarGeneral()
        Dim validar As Boolean = True
        If cbProveedor.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbProveedor, "Debe seleccionar un proveedor")
        End If
        If cbDireccion.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbDireccion, "Debe seleccionar una dirección")
        End If
        If cbMoneda.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbMoneda, "Debe seleccionar una moneda")
        End If


        If cbEstado.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
        End If
        If cbValorado.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbValorado, "Se ha de seleccionar como está valorado el albarán")
        End If
        If cbPersona.SelectedIndex = -1 Then
            ' validar = False
            ep2.SetError(cbPersona, "No se ha seleccionado un comercial")
        End If
        If validar Then
            dtsOF.gnumAlbaran = numDoc.Text
            dtsOF.gReferenciaCliente = RefCliente.Text
            dtsOF.gReferenciaCliente2 = RefCliente2.Text
            dtsOF.gEstado = cbEstado.Text
            dtsOF.gFecha = dtpFecha.Value.Date
            dtsOF.gFechaEntrega = dtpFechaPrevista.Value
            dtsOF.gidCliente = 0
            dtsOF.gidProveedor = cbProveedor.SelectedItem.itemdata
            dtsOF.gidUbicacion = cbDireccion.SelectedItem.itemdata
            dtsOF.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)

            dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda

            dtsOF.gDescuento = 0
            dtsOF.gDescuento2 = 0

            dtsOF.gSolicitadoVia = cbSolicitadoVia.Text
            dtsOF.gNotas = Nota.Text
            dtsOF.gObservaciones = Observaciones.Text
            dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
            dtsOF.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
            dtsOF.gTipoValorado = cbValorado.Text
            dtsOF.gVolumen = If(Volumen.Text = "", 0, CDbl(Volumen.Text))
            dtsOF.gKilosBrutos = If(PesoBruto.Text = "", 0, CDbl(PesoBruto.Text))
            dtsOF.gKilosNetos = If(PesoNeto.Text = "", 0, CDbl(PesoNeto.Text))
            dtsOF.gBultos = If(Bultos.Text = "", 0, CInt(Bultos.Text))
            dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
            dtsOF.gPersona = cbPersona.Text
            dtsOF.gMedidas = Medidas.Text
            dtsOF.gRecogido = False

            If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
            If cbPortes.Text = "PAGADOS" Then
                dtsOF.gPortes = "P"
                dtsOF.gPrecioTransporte = 0
            ElseIf cbPortes.Text = "DEBIDOS" Then
                dtsOF.gPortes = "D"
                dtsOF.gPrecioTransporte = 0
            Else
                dtsOF.gPortes = "I"
                dtsOF.gPrecioTransporte = PrecioTransporte.Text
            End If
            If cbTransporte.SelectedIndex = -1 Then
                dtsOF.gidTransporte = 0
                dtsOF.gTransporte = cbTransporte.Text
            Else
                If cbTransporte.SelectedItem.itemdata < 1 Then
                    dtsOF.gidTransporte = 0
                    dtsOF.gTransporte = cbTransporte.Text
                Else
                    dtsOF.gidTransporte = cbTransporte.SelectedItem.itemData
                    dtsOF.gTransporte = ""
                End If
            End If
            If G_AGeneral = "G" Then
                numDoc.Text = funcOF.insertar(dtsOF)
                dtsOF.gnumAlbaran = numDoc.Text
                G_AGeneral = "A"
                MsgBox("Creado el Albaran " & numDoc.Text & ". Ya puede introducir los conceptos.")
                gbConceptos.Enabled = True
                cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                'Debe seguir en estado cabecera
            Else
                funcOF.actualizar(dtsOF)
                Call Recalcular(False)
                If cbArticulo.Text = "" Then MsgBox("Albarán actualizado correctamente")

            End If
            cambios = False
            ep1.Clear()
            ep2.Clear()
        End If
        Return validar
    End Function

    Private Sub PropagarIVAConceptos(ByVal iidTipoIVAAnterior As Integer)
        If iidTipoIVAAnterior <> dtsOF.gidTipoIVA Then
            funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA)
        End If
    End Sub


    Private Function GuardarConcepto() As Boolean
        Dim validar As Boolean = True
        If indice <> -1 Then
            If funcCO.Traspasada(lvConceptos.Items(indice).SubItems(1).Text) Then
                MsgBox("Esta linea ya ha sido traspasada. No se puede modificar.")
                validar = False
            End If
        End If
        If cbEstado.SelectedIndex <> -1 Then
            Dim estado As DatosEstado = funcES.Mostrar1(cbEstado.SelectedItem.gidestado)
            If estado.gEntregado Then
                MsgBox("Este albarán ya ha sido servido. No se pueden modificar los conceptos.")
                validar = False
            End If
        End If
        If cbArticulo.Text = "" Then
            validar = False
        End If
        If validar Then
            Dim dts As New DatosConceptoAlbaran
            dts.gidConcepto = 0
            dts.gnumFactura = 0
            If indice <> -1 Then
                'si existe, precargamos el concepto
                Dim iidconcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
                If iidconcepto > 0 Then dts = funcCO.Mostrar1(iidconcepto)
            End If
            dts.gnumAlbaran = numDoc.Text
            dts.gnumPedido = 0
            If indice = -1 And codArticuloProv.Text = "" And cbCodArticulo.Text <> "" Then
                dts.gcodArticuloCli = cbCodArticulo.Text 'Asignar el codArticuloCli como el codArticulo
            Else
                dts.gcodArticuloCli = codArticuloProv.Text
            End If
            dts.gcodArticulo = cbCodArticulo.Text
            dts.gArticuloCli = cbArticulo.Text
            dts.gRefCliente = ""

            If Cantidad.Text = "" Or Cantidad.Text = "-" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0
            dts.gCantidad = Cantidad.Text
            dts.gPVPUnitario = 0
            dts.gidTipoIVA = dtsOF.gidTipoIVA
            dts.gDescuento = 0
            dts.gPrecioNetoUnitario = PrecioNeto.Text
            dts.gnumsSerie = numsSerie.Text 'Observaciones 
            If dts.gnumsSerie = "N/S:" Then dts.gnumsSerie = ""
            dts.gOrden = indice + 1
            Dim iidArticuloProv As Integer = 0

            Dim dtsAC As New DatosArticuloProveedor

            If iidArticulo = 0 Then
                dts.gidArticulo = 0
                iidArticulo = 0
            Else
                'iidArticulo = cbArticulo.SelectedItem.itemdata
                dts.gidArticulo = iidArticulo
                dtsAC.gidArticulo = iidArticulo
                dtsAC.gidProveedor = cbProveedor.SelectedItem.itemdata
                dtsAC.gNombre = dts.gArticuloCli
                dtsAC.gcodArticulo = dts.gcodArticulo
                dtsAC.gcodArticuloProv = dts.gcodArticuloCli
                dtsAC.gFechaPrecio = Now.Date
                dtsAC.gActivo = True
                dtsAC.gPrecioUnitario = dts.gPrecioNetoUnitario
                dtsAC.gcodMoneda = dtsOF.gcodMoneda
            End If
            Dim SoloReferenciaDoc As Boolean = False
            If indice = -1 Then
                'Hemos de guardar un nuevo concepto
                dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
                Dim estado As DatosEstado = funcES.EstadoEspera("C.ALBARAN")
                dts.gidEstado = estado.gidEstado
                dts.gEstado = estado.gEstado

                iidArticuloProv = funcAC.Guardar(dtsAC)

                dts.gidArticuloProv = iidArticuloProv
                dts.gidConcepto = funcCO.insertar(dts)
                Call nuevaLineaLV(dts)
                'Ahora hemos de descontar del stock
                dtsCO = dts
                Call RevisarStock(dts.gidConcepto)
                If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar el estado del albarán
                    Me.Text = "EDITAR ALBARÁN A PROVEEDOR"
                   
                    cbEstado.SelectedIndex = -1
                    cbEstado.Text = ""
                    Dim x As Integer = cbEstado.FindString(funcES.EstadoCabecera("ALBARAN").gEstado)
                    If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera

                    Dim dtsES As DatosEstado = funcES.EstadoEnCurso("Albaran")
                    If cbEstado.FindString(dtsES.gEstado) = -1 Then cbEstado.Items.Add(dtsES)
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                End If
            Else

                'actualizar concepto
                dts.gTipoUnidad = dtsCO.gTipoUnidad
                dts.gidConcepto = lvConceptos.Items(indice).SubItems(1).Text
                'iidArticuloProv = funcAC.ArticuloExiste(iidArticulo, iidProveedor)
                If dts.gidArticulo = 0 Then
                    iidArticuloProv = 0
                Else
                    'If iidArticuloProv > 0 Then
                    '    dtsAC.gidArticuloProv = iidArticuloProv
                    'Else
                    'If CompruebaACigual() Then
                    iidArticuloProv = funcAC.Guardar(dtsAC)
                    'End If
                    'End If
                End If
                dts.gidArticuloProv = iidArticuloProv
                funcCO.actualizar(dts)
                Call ActualizarLineaLV(dts)
                'Ahora hemos de revisar stock (si ha cambiado la cantidad, generará un movimiento)
                If iidArticulo > 0 Then Call RevisarStock(dts.gidConcepto)



            End If
            Call Recalcular(True)
            Call LimpiarEdicion()
        End If
            Return validar
    End Function


  





    Private Sub CargarEdicion()
        'Carga el concepto en la zona de edición
        If indice <> -1 Then
            semaforo = False
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            dtsCO = funcCO.Mostrar1(iidConcepto)
            iidArticulo = dtsCO.gidArticulo
            cbFamilia.Text = dtsCO.gFamilia
            Call IntroducirSubFamilias()
            cbSubFamilia.Text = dtsCO.gSubFamilia
            Call CargarArticulosC()
            cbCodArticulo.Text = dtsCO.gcodArticulo
            cbArticulo.Text = dtsCO.gArticuloCli
            codArticuloProv.Text = dtsCO.gcodArticuloCli
            lbUnidad.Text = dtsCO.gTipoUnidad

            Cantidad.Text = dtsCO.gCantidad

            PrecioNeto.Text = FormatNumber(dtsCO.gPrecioNetoUnitario, 2)
            subTotal.Text = FormatNumber(dtsCO.gSubTotal, 2)
            numsSerie.Text = dtsCO.gnumsSerie

            semaforo = True
        End If
    End Sub


    Private Sub CargarArticuloC()
        'Carga los datos de un artículo en la zona de edición
        If iidArticulo > 0 And cbProveedor.SelectedIndex <> -1 Then
            semaforo = False
            ep2.Clear()
            dtsAR = funcAR.Mostrar1V(iidArticulo, cbProveedor.SelectedItem.itemdata, dtsUB.gidIdioma)
            cbFamilia.Text = dtsAR.gFamilia
            Call IntroducirSubFamilias()
            cbSubFamilia.Text = dtsAR.gSubFamilia
            Call CargarArticulosC()
            cbCodArticulo.Text = dtsAR.gcodArticulo
            cbArticulo.Text = dtsAR.gArticuloCli
            codArticuloProv.Text = dtsAR.gCodArticuloCli
            lbUnidad.Text = dtsAR.gTipoUnidad

            'If dtsAR.gPrecioArtCli = -1 Then
            '    'Si no hay precio neto específico, puede haber descuento
            '    PrecioNeto.Text = 0
            '    'If dtsAR.gDescuento > 0 Then
            '    '    'Si hay descuento específico
            '    '    DescuentoC.Text = FormatNumber(dtsAR.gDescuento, 2)
            '    'Else
            '    '    'Si no, tomamos el descuento del cliente doméstico o industrial según el tipo de artículo
            '    '    DescuentoC.Text = FormatNumber(If(dtsAR.gDescuento1, dtsFA.gDescuento, dtsFA.gDescuento2))
            '    'End If
            'Else
            '    'Si hay precio neto específico, lo ponemos, comprobando que la moneda sea la seleccionada en el documento
            '    If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
            '        PrecioNeto.Text = FormatNumber(dtsAR.gPrecioArtCli, 2)
            '    Else
            '        Dim aviso As Boolean
            '        Dim FechaCambio As Date
            '        PrecioNeto.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioArtCli, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
            '        If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
            '        'lbCambio.Text = "CAMBIO " & FechaCambio
            '        'lbCambio.Visible = aviso
            '    End If

            'End If


            'If cbMoneda.SelectedIndex = -1 Then
            '    'PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            'Else
            '    If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
            '        'PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            '    Else
            '        Dim aviso As Boolean
            '        Dim FechaCambio As Date
            '        ' PVP.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioUnitarioV, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
            '        If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
            '        'lbCambio.Text = "CAMBIO " & FechaCambio
            '        'lbCambio.Visible = aviso
            '    End If

            'End If
            If Cantidad.Text = "" Then Cantidad.Text = 0

            If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
            'If PVP.Text = "" Then PVP.Text = 0
            If Cantidad.Text = 0 Then Cantidad.Text = 1
            'If DescuentoC.Text <> 0 Then  'Si hay descuento, ignoramos el precio neto
            '    PrecioNeto.Text = FormatNumber((1 - DescuentoC.Text / 100) * PVP.Text, 2)
            'Else
            '    If PrecioNeto.Text = 0 Then PrecioNeto.Text = PVP.Text 'Si el precio neto=0, ponemos el PVP
            'End If
            subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
            semaforo = True
        End If
    End Sub

    Private Sub DatosDireccion()
        dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
        PrecioTransporte.Enabled = False
        If dtsUB.gPortes = "P" Then cbPortes.Text = "PAGADOS"
        If dtsUB.gPortes = "D" Then cbPortes.Text = "DEBIDOS"
        If dtsUB.gPortes = "I" Then
            cbPortes.Text = "INC.FRA."
            'Cargar el importe del último documento
            'PrecioTransporte.Text = FormatNumber(funcOF.UltimoPrecioTransporte(iidProveedor), 2)
            PrecioTransporte.Enabled = True
        End If
        If dtsUB.gidTransporte = 0 Then
            cbTransporte.Text = dtsUB.gTransporte
        Else
            cbTransporte.Text = dtsUB.gAgenciaTransporte
        End If
    End Sub


#End Region




#Region "BOTONES GENERALES"



    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    numDoc.Text = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Albaranes(indiceL)
                Call CargarAlbaran()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Albaranes.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Albaranes(indiceL)
                Call CargarAlbaran()
            End If


        End If
    End Sub



    Private Sub bVerProvedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerProveedor.Click
        If cbProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbProveedor.SelectedItem.itemdata
            Dim Proveedor As String = cbProveedor.Text
            Dim codProv As Integer = cbCodProveedor.Text
            Dim GG As New GestionProveedores
            GG.SoloLectura = vSoloLectura
            GG.pidProveedor = iidProveedor
            GG.ShowDialog()
            If GG.pidProveedor = iidProveedor Then
                dtsPR = funcPR.mostrar1(iidProveedor)
            End If
            If ClienteSoloLectura Then
                cbProveedor.Items.Clear()
                cbCodProveedor.Items.Clear()
                cbCodProveedor.Items.Add(New IDComboBox(dtsPR.gcodProveedor, dtsPR.gidProveedor))
                cbProveedor.Items.Add(New IDComboBox(dtsPR.gnombrecomercial, dtsPR.gidProveedor))
                cbProveedor.SelectedIndex = 0
            Else
                Call introducirProveedores()
                cbProveedor.Text = dtsPR.gnombrecomercial
                cbCodProveedor.Text = dtsPR.gcodProveedor
                If cbProveedor.SelectedIndex = -1 Then
                    cbProveedor.Text = ""
                    cbCodProveedor.Text = ""
                End If
            End If

            Call CargarDatosFacturacionProveedor()
            'Call CargarDatosClienteNoEditables()
            'Call AsignarDOCDatosClienteNoEditables()
            'Call PropagarIVAConceptos(funcOF.idTipoIVA(numDoc.Text))
            Call Recalcular(False)
            Call CargarCombosProveedor()

        End If

    End Sub

    Private Sub bBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarProveedor.Click
        Dim GG As New busquedaproveedor
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidproveedor > 0 Then
            dtsPR = funcPR.mostrar1(GG.pidproveedor)
            cbCodProveedor.Text = dtsPR.gcodProveedor
            cbProveedor.Text = dtsPR.gnombrecomercial
            iidProveedor = GG.pidproveedor
            Call PresentarAvisoProveedor()
            Call CargarDatosFacturacionProveedor()
            'Call CargarDatosClienteNoEditables()
            Call CargarCombosProveedor()
            cambios = True

        End If

    End Sub




    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        'Hay que detectar si borramos el documento o la linea
        If indice = -1 Then
            'Borrar Albaran
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Albaran, es como pulsar nuevo
                If cambios Then
                    If MsgBox("Se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Call InicializarGeneral()
                        Call Nuevo()
                    End If
                Else
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            Else
                If MsgBox("No es posible borrar una Albaran existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim dtsES As DatosEstado = funcES.EstadoAnulado("Albaran")
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    bGuardar.Enabled = False
                    bBorrar.Enabled = False
                End If
            End If
        Else
            'Borrar concepto
            If ConceptosEditables Then
                Dim validar = True
                If cbEstado.SelectedIndex <> -1 Then
                    Dim estado As DatosEstado = funcES.Mostrar1(cbEstado.SelectedItem.gidestado)
                    If estado.gEntregado Then
                        MsgBox("Este albarán ya ha sido servido. No se pueden modificar los conceptos.")
                        validar = False
                    End If
                End If
                If validar Then
                    Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
                    If iidConcepto > 0 Then
                        If funcCO.Traspasada(iidConcepto) Then
                            MsgBox("La linea indicada ya ha sido traspasada. No se puede borrar.")
                        Else
                            funcCO.borrar(iidConcepto, numDoc.Text)
                            lvConceptos.Items.RemoveAt(indice)
                            Call LimpiarEdicion()
                            If lvConceptos.Items.Count = 0 Then
                                cbEstado.Items.Clear()
                                cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                                Dim dtsES As DatosEstado = funcES.EstadoCabecera("Albaran")
                                cbEstado.Items.Add(dtsES)
                                cbEstado.Text = dtsES.ToString
                                funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                            End If
                            Call Recalcular(True)
                        End If
                    End If
                End If

            End If
        End If
    End Sub



    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará un nuevo albarán. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirProveedores()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará una nuevo albarán. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirProveedores()
                    Call Nuevo()
                End If
            End If
        End If

    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If GuardarGeneral() Then
            If ConceptosEditables Then
                If cbArticulo.Text <> "" Then Call GuardarConcepto()
            End If
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
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
            lbMoneda1.Text = funcMO.CampoSimbolo("EU")
        End If
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            InformeAlbaranProv.verInforme(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion))
            InformeAlbaranProv.ShowDialog()
        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Albaran SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeAlbaranProv.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If
    End Sub



    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Albaran SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            InformeAlbaranProv.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), fichero, camino)
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If
            'Dim texto As String = " Buenos días,"
            'texto = texto & "<br/><br/> Adjuntamos el albarán " & numDoc.Text & ". "
            'Se envía un correo outlook a la dirección de la ubicación
            'CorreoOutlook("Albarán SUGAR VALLEY", texto, funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero)
            CorreoOutlook("ALBARÁN A PROVEEDOR", funcPE.campoCorreo(Inicio.vIdUsuario), Destinatario, camino & fichero, cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFechaPrevista.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemData))

        End If
    End Sub





#End Region


#Region "BOTONES CONCEPTOS"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call LimpiarEdicion()
    End Sub


    Private Sub bArticuloProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bArticuloProveedor.Click
        If cbProveedor.SelectedIndex <> -1 Then
            Dim GG As New GestionArticulosProv
            GG.SoloLectura = vSoloLectura
            GG.pidProveedor = cbProveedor.SelectedItem.itemdata
            GG.pidArticulo = iidArticulo

            GG.ShowDialog()
            If GG.pidArticulo > 0 Then
                iidArticulo = GG.pidArticulo
                If GG.pidArticuloProv > 0 Then
                    PrecioNeto.Text = funcAC.Precio(GG.pidArticuloProv)
                End If
                Call CargarArticuloC()
            ElseIf iidArticulo > 0 Then
                Call CargarArticuloC()
            End If
        End If


    End Sub

    Private Sub bTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposArticulo.Click
        Dim tipo As String = cbFamilia.Text
        Dim subtipo As String = cbSubFamilia.Text
        Dim GG As New GestionTiposArticulo
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirFamilias()
        cbFamilia.Text = tipo
        If cbFamilia.SelectedIndex = -1 Then
            cbFamilia.Text = ""
        Else
            Call IntroducirSubFamilias()
            cbSubFamilia.Text = subtipo
            If cbSubFamilia.SelectedIndex = -1 Then cbSubFamilia.Text = ""
        End If
    End Sub

    Private Sub bBuscarArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloC.Click

        Dim GG As New lbBusquedaArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "ALB.PROVEEDOR"
        GG.pidProveedor = iidProveedor
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticulo = GG.pidArticulo

            Call CargarArticulosC()
            Call CargarArticuloC()
        End If

    End Sub


    Private Sub bVerArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloC.Click
        If iidArticulo > 0 Then
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.pModo = "DOC"
            GG.ShowDialog()
            If GG.pidArticulo <> iidArticulo Then
                iidArticulo = GG.pidArticulo
                Call CargarArticulosC()
            End If
            Call CargarArticuloC()
        Else
            If cbArticulo.Text <> "" Then
                MsgBox("El concepto no se corresponde con un artículo existente.")
            End If

        End If

    End Sub

    Private Sub bBajarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajarC.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            If indice < lvConceptos.Items.Count - 1 Then
                Dim indiceActual As Integer = indice
                Dim indiceInferior As Integer = indice + 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoInferior As Long = lvConceptos.Items(indiceInferior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemInferior As ListViewItem = lvConceptos.Items(indiceInferior).Clone
                If funcCO.MoverConceptos(iidConceptoInferior, iidConceptoActual) Then
                    lvConceptos.Items(indiceActual) = itemInferior
                    lvConceptos.Items(indiceInferior) = itemActual
                    lvConceptos.SelectedItems.Clear()
                    lvConceptos.Items(indiceInferior).Selected = True
                    lvConceptos.EnsureVisible(indiceInferior)
                End If
            End If
        End If
    End Sub


    Private Sub bSubirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubirC.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            If indice > 0 Then
                Dim indiceActual As Integer = indice
                Dim indiceSuperior As Integer = indice - 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoSuperior As Long = lvConceptos.Items(indiceSuperior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemSuperior As ListViewItem = lvConceptos.Items(indiceSuperior).Clone
                If funcCO.MoverConceptos(iidConceptoActual, iidConceptoSuperior) Then
                    lvConceptos.Items(indiceActual) = itemSuperior
                    lvConceptos.Items(indiceSuperior) = itemActual
                    lvConceptos.SelectedItems.Clear()
                    lvConceptos.Items(indiceSuperior).Selected = True
                    lvConceptos.EnsureVisible(indiceSuperior)
                End If
            End If
        End If
    End Sub




#End Region



#Region "EVENTOS"

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)

            Call CargarEdicion()
        End If
    End Sub


    Private Sub cbcodProveedorente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodProveedor.SelectionChangeCommitted
        If cbCodProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbCodProveedor.SelectedItem.itemdata
            dtsPR = funcPR.mostrar1(iidProveedor)
            cbProveedor.Text = dtsPR.gnombrecomercial
            Call PresentarAvisoProveedor()
            Call CargarDatosFacturacionProveedor()
            'Call CargarDatosClienteNoEditables()
            Call CargarCombosProveedor()
            cambios = True
        End If
    End Sub


    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If cbProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbProveedor.SelectedItem.itemdata
            dtsPR = funcPR.mostrar1(iidProveedor)
            cbCodProveedor.Text = dtsPR.gcodProveedor

            Call PresentarAvisoProveedor()
            Call CargarDatosFacturacionProveedor()
            'Call CargarDatosClienteNoEditables()
            Call CargarCombosProveedor()
            cambios = True
        End If
    End Sub


    Private Sub cbEstado_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.SelectionChangeCommitted
        If cbEstado.SelectedIndex <> -1 Then
            If cbEstado.SelectedItem.gAutomatico Then
                MsgBox("El estado " & cbEstado.Text & " es automático, no se puede seleccionar manualmente.")
                cbEstado.Text = dtsOF.gEstado
            Else
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gEstado = cbEstado.SelectedItem.gEstado
                cambios = True
                If Not cbEstado.SelectedItem.gBloqueado Then
                    For Each item As ListViewItem In lvConceptos.Items
                        Call RevisarStock(item.SubItems(1).Text)
                    Next
                End If
            End If
        End If
    End Sub


    Private Sub RevisarStock(ByVal iidConcepto As Integer)
        'Comprobamos si todas las cantidades de los conceptos están ya en el stock, si no es así, se crean los movimientos
        Dim CS As Double = funcSK.CantidadConceptoAlbaran(iidConcepto)
        Dim dtsCA As DatosConceptoAlbaran = funcCO.Mostrar1(iidConcepto)
        If dtsCO Is Nothing Then dtsCO = funcCO.Mostrar1(iidConcepto)
        If Math.Abs(dtsCA.gCantidad + CS) > 0.00001 Then 'A veces las cantidades tipo double pueden descuadrar un poco debido a redondeos
            Dim dtsSK As New DatosStock
            dtsSK.gidArticulo = dtsCA.gidArticulo
            dtsSK.gidAlmacen = 0
            dtsSK.gCantidad = -CS + CDbl(dtsCA.gCantidad)
            dtsSK.gidUnidad = dtsCO.gidUnidad
            dtsSK.gidLote = 0
            dtsSK.gidArticuloProv = 0
            dtsSK.gidPersona1 = iidUsuario
            dtsSK.gidPersona2 = 0
            dtsSK.gMovimiento = ""
            dtsSK.gFecha = Now
            dtsSK.gPrecio = dtsCO.gPrecioNetoUnitario
            dtsSK.gcodMoneda = dtsOF.gcodMoneda
            dtsSK.gidConceptoProv = 0
            dtsSK.gidConceptoAlbaran = dtsCO.gidConcepto
            dtsSK.gidProduccion = 0
            funcSK.insertar(dtsSK)
        End If



    End Sub

    Private Sub lbMoneda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMoneda1.TextChanged

        lbMonedaS.Text = lbMoneda1.Text
        lbMonedaN.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
    End Sub



    Private Sub cbMoneda_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then
            'lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.SelectedItem.ToString
            If codMonedaI <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        funcOF.actualizaMoneda(numDoc.Text, codMonedaActual)
                        dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsOF.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsOF.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        listaC = funcCO.Mostrar(numDoc.Text)
                        For Each dts As DatosConceptoAlbaran In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, funcMO.Cambio(dts.gPVPUnitario, codMonedaI, codMonedaActual, True, Now.Date), funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular(False)
                    Else
                        cbMoneda.Text = dtsOF.gDivisa
                        ep2.Clear()
                    End If

                Else
                    cbMoneda.Text = moneda
                End If
            End If
            lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            cambios = True
        End If
    End Sub





    Private Sub cbTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted
        If cbFamilia.SelectedIndex <> -1 Then
            iidFamilia = cbFamilia.SelectedItem.gidFamilia
            Call IntroducirSubFamilias()
            Call CargarArticulosC()
        End If
    End Sub

    Private Sub cbSubTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex <> -1 And iidFamilia > 0 Then
            Call CargarArticulosC()
        End If
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedValueChanged 'cbCodArticulo.SelectionChangeCommitted
        If semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbCodArticulo.SelectedItem.itemdata
                Call CargarArticuloC()
                If Cantidad.Text = "0" Then Cantidad.Text = 1
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedValueChanged 'cbArticulo.SelectionChangeCommitted
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                Call CargarArticuloC()
                If Cantidad.Text = "0" Then Cantidad.Text = 1
                semaforo = True
            End If
        End If
    End Sub



    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, PrecioNeto.Click, Bultos.Click, Volumen.Click, PesoBruto.Click, PesoNeto.Click, PrecioTransporte.Click, Medidas.Click
        sender.selectall()
    End Sub


    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged, PrecioNeto.TextChanged
        If semaforo Then
            If Cantidad.Text = "-" Then
            Else
                semaforo = False
                If Cantidad.Text = "" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0

                If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
              
                subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
                semaforo = True
            End If
        End If
    End Sub






    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Cantidad.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Or Cantidad.Text = "0" Or (KeyAscii = Asc("-") And Cantidad.TextLength = 1) Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Cantidad.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If KeyAscii = Keys.Enter Then
            If ConceptosEditables Then Call GuardarConcepto()
        End If
    End Sub



    Private Sub PrecioTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioTransporte.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioTransporte.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub



    Private Sub PrecioNeto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioNeto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioNeto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            If ConceptosEditables Then Call GuardarConcepto()
        End If
    End Sub




    Private Sub Volumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Volumen.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Volumen.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub PesoBruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoBruto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoBruto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub PesoNeto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoNeto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoNeto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Bultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Bultos.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvConceptos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If

    End Sub



    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If semaforo Then
            Dim cont As Integer = lvConceptos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvConceptos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub

    Private Sub cbTipoIVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'emula el READ ONLY
        e.Handled = True
    End Sub

    Private Sub cbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbProveedor.KeyPress, cbCodProveedor.KeyPress
        'emula el READ ONLY
        If ClienteSoloLectura Then e.Handled = True
    End Sub

    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nota.TextChanged, Observaciones.TextChanged, dtpFecha.ValueChanged, dtpFechaPrevista.ValueChanged, RefCliente.TextChanged, cbContacto.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, Bultos.TextChanged, Volumen.TextChanged, cbTransporte.SelectedIndexChanged, PesoBruto.TextChanged, PesoNeto.TextChanged, cbValorado.SelectedIndexChanged, RefCliente2.TextChanged, PrecioTransporte.TextChanged, cbPersona.SelectionChangeCommitted, Medidas.TextChanged
        cambios = True
    End Sub

    Private Sub cbPortes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPortes.SelectedIndexChanged
        If cbPortes.Text = "PAGADOS" Or cbPortes.Text = "DEBIDOS" Then
            PrecioTransporte.Enabled = False
            PrecioTransporte.Text = 0
        Else
            PrecioTransporte.Enabled = True
        End If
        cambios = True
    End Sub






    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            Call DatosDireccion()
            cambios = True
        End If
    End Sub



#End Region



  
End Class