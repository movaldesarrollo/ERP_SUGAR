
Imports System.IO

Public Class GestionFactura


    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider 'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Facturas As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesFacturas
    Private funcCO As New FuncionesConceptosFacturas
    Private funcTP As New funcionesTiposPago
    Private funcMP As New funcionesMediosPago
    Private funcTR As New FuncionesTiposRetencion
    Private funcTI As New FuncionesTiposIVA
    Private funcAR As New FuncionesArticulos
    Private funcTA As New FuncionesTiposArticulo
    Private funcST As New FuncionessubTiposArticulo
    Private funcCL As New funcionesclientes
    Private funcUB As New funcionesUbicaciones
    Private funcFA As New funcionesFacturacion
    Private funcCT As New funcionesContactos
    Private funcES As New FuncionesEstados
    Private funcMA As New Master
    Private funcPE As New FuncionesPersonal
    Private funcSV As New FuncionesSolicitadoVia
    Private funcRu As New FuncionesRutas
    Private funcAC As New funcionesArticuloCliente
    Private funcACP As New funcionesArticuloClientePrecios
    Private funcVE As New FuncionesVencimientos
    Private funcPA As New funcionesPaises
    Private funcCM As New funcionesComisiones
    Private funcCB As New FuncionesCuentasBancarias
    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private dtsOF As DatosFactura
    Private dtsCL As datoscliente
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoFactura
    Private dtsAR As DatosArticulo
    Private listaC As List(Of DatosConceptoFactura)
    Private semaforo As Boolean
    Private iidTipoArticulo As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidCliente As Integer
    Private localizacion As Point
    Private EstadoInicial As DatosEstado
    Private Exportacion As Boolean
    Private dtsUB As datosUbicacion
    Private avisadoCliente As Boolean
    Private ClienteAvisado As Integer
    Private AvisadoFacturacion As Boolean
    Private ClienteSoloLectura As Boolean
    Private ConceptosEditables As Boolean
    Private GestionaComisiones As Boolean

    Public Property pnumFactura() As Integer
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

    Property pFacturas() As List(Of Integer)
        Get
            Return Facturas
        End Get
        Set(ByVal value As List(Of Integer))
            Facturas = value
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

    Private Sub GestionFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        Exportacion = False
        If localizacion.X <> 0 Then Me.Location = localizacion
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 950 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 900
        End If

        'PERMISOS 
        iidUsuario = Inicio.vIdUsuario
        GestionaComisiones = funcPE.Permiso(iidUsuario, "AsignacionComisiones")
        ComisionGeneral.Visible = GestionaComisiones
        ComisionLinea.Visible = GestionaComisiones
        lbComision1.Visible = GestionaComisiones
        lbComision2.Visible = GestionaComisiones
        lbComision3.Visible = GestionaComisiones
        lbComision4.Visible = GestionaComisiones

        avisadoCliente = False
        AvisadoFacturacion = False
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        Dim tt As New ToolTip
        tt.InitialDelay = 0
        tt.SetToolTip(bLimpiar, "Limpiar zona de edición")
        tt.SetToolTip(bArticuloCliente, "Gestión Artículo-Cliente")
        tt.SetToolTip(bVerArticuloC, "Ver ficha del artículo")
        tt.SetToolTip(bVerCliente, "Ver ficha del cliente")
        tt.SetToolTip(bBuscarArticuloC, "Búsqueda del artículo")
        tt.SetToolTip(bBuscarCliente, "Búsqueda del cliente")
        tt.SetToolTip(bNuevoCliente, "Dar de alta un nuevo cliente")
        tt.SetToolTip(bVencimientos, "Edición de vencimientos")
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        cbCodArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbCodArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        cbArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        ClienteSoloLectura = False
        ConceptosEditables = True

        Call introducirMediosPago()
        Call introducirMonedas()
        Call IntroducirTiposArticulo()
        Call introducirTiposIVA()
        Call introducirTiposPago()
        Call introducirTiposRetencion()
        Call introducirSolicitadoVia()
        Call InicializarGeneral()
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text = 0 Then
            Call introducirClientes()
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR FACTURA"
            gbConceptos.Enabled = True
            If Facturas Is Nothing Then
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                If Facturas.Count > 0 Then
                    bSubir.Visible = True
                    bBajar.Visible = True
                Else
                    bSubir.Visible = False
                    bBajar.Visible = False
                End If
            End If
            semaforo = False
            Call CargarFactura()
            'G_AGeneral = "A"
        End If
        semaforo = True

    End Sub

    Private Sub GestionFactura_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        Else
            e.Cancel = False
        End If
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub Nuevo()
        Me.Text = "NUEVA FACTURA"
        ClienteSoloLectura = False
        cbCliente.Enabled = True
        cbCodCliente.Enabled = True
        bBuscarCliente.Enabled = True
        dtsOF = New DatosFactura
        gbConceptos.Enabled = False
        numDoc.Text = funcMA.leernumFactura(Now.Year) + 1
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumFactura(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        EstadoInicial = funcES.EstadoCabecera("Factura")
        cbEstado.Items.Clear()
        cbEstado.Items.Add(EstadoInicial)
        cbEstado.Text = EstadoInicial.ToString

        iidCliente = 0
    End Sub

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()
        ckSeleccion.Checked = False
        ckSeleccion.Visible = True
        lvConceptos.Items.Clear()
        lvConceptos.CheckBoxes = True
        RefCliente.Text = ""
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        numDoc1.Text = ""
        Call introducirComerciales()
        Call LimpiarCabecera()
        rtbNota.Clear()
        Observaciones.Text = ""
        SumaDescuentos.Text = 0
        BaseImponible.Text = 0
        TotalIVA.Text = 0
        TotalRE.Text = 0
        Retencion.Text = 0
        Total.Text = 0
        DiaPago1.Text = ""
        DiaPago2.Text = ""
        Call LimpiarEdicion()
        lvVencimientos.Items.Clear()
        cambios = False
    End Sub

    Private Sub LimpiarCabecera()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()
        dtpFecha.Value = Now.Date
        'dtpFechaPrevista.Value = Now.Date
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbSolicitadoVia.Text = ""
        cbSolicitadoVia.SelectedIndex = -1
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cbTipoPago.Text = ""
        cbTipoPago.SelectedIndex = -1
        cbCuenta.Text = ""
        cbCuenta.SelectedIndex = -1
        cbCuenta.Items.Clear()
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        codMonedaI = "EU"
        cbTipoIVA.Text = DI.TipoIVA.ToString
        cbRetencion.SelectedItem = DI.TipoRetencion
        PrecioTransporte.Text = 0
    End Sub

    Private Sub LimpiarEdicion()
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        PVP.Text = 0
        PrecioNeto.Text = 0
        DescuentoC.Text = 0
        Cantidad.Text = 0
        codArticuloCli.Text = ""
        subTotal.Text = 0
        indice = -1
        iidArticulo = 0
        iidTipoArticulo = 0
    
        cbArticulo.Items.Clear()
        cbCodArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        numsSerie.Text = "N/S:"
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        ComisionLinea.Text = ComisionGeneral.Text

    End Sub


    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTA.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(dts)
        Next
    End Sub


    Private Sub IntroducirSubTiposArticulo()
        If iidTipoArticulo > 0 Then
            cbSubTipo.Text = ""
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Items.Clear()
            Dim lista As List(Of DatosSubTipoArticulo) = funcST.Mostrar(iidTipoArticulo, 0, True)
            Dim dts As DatosSubTipoArticulo
            For Each dts In lista
                cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
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

    Private Sub introducirTiposPago()
        Try
            cbTipoPago.Items.Clear()
            Dim lista As List(Of datosTipoPago) = funcTP.mostrar(True)
            Dim dts As datosTipoPago
            For Each dts In lista
                cbTipoPago.Items.Add(dts)
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
                cbMedioPago.Items.Add(dts)
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
                cbRetencion.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        cbCodCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
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

    Private Sub introducirComerciales()
        cbPersona.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(0)
        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        'Cargamos el usuario que ha hecho login, si no está en la lista lo deja en blanco.
        cbPersona.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbPersona.SelectedIndex = -1 Then cbPersona.Text = ""
    End Sub


#End Region

#Region "CARGAR DATOS"

    Private Sub CargarFactura()
        Try
            ep1.Clear()
            ep2.Clear()
            G_AGeneral = "A"
            dtsOF = funcOF.Mostrar1(numDoc.Text)
       

            If dtsOF.gnumFactura = 0 Then
                MsgBox("La factura " & numDoc.Text & " no existe.")
                Me.Close()
            Else
                iidCliente = dtsOF.gidCliente
                dtsCL = funcCL.mostrar1(dtsOF.gidCliente)

                EstadoInicial = funcES.Mostrar1(dtsOF.gidEstado)

                If EstadoInicial Is Nothing Then
                    MsgBox("Error de estado")
                End If
                If EstadoInicial.gCabecera Then
                    Call introducirClientes()
                    ClienteSoloLectura = False
                    bBuscarCliente.Enabled = True
                Else
                    cbCliente.Items.Clear()
                    cbCodCliente.Items.Clear()
                    cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
                    cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrefiscal, dtsCL.gidCliente))
                    ClienteSoloLectura = True
                    bBuscarCliente.Enabled = False
                End If
                cbCliente.Text = dtsOF.gCliente
                cbCodCliente.Text = dtsCL.gcodCli

                Call CargarDatosFacturacionCliente()
                Call CargarCombosCliente()
                Call PresentarAvisoCliente()

                RefCliente.Text = dtsOF.gReferenciaCliente
                cbPersona.Text = dtsOF.gPersona
                If dtsOF.gidPersona > 0 Then
                    ComisionGeneral.Text = FormatNumber(funcCM.Porcentaje(dtsOF.gidCliente, dtsOF.gidPersona), 2)
                Else
                    ComisionGeneral.Text = 0
                End If


                Select Case dtsOF.gnumsAlbaran.Count
                    Case 0
                        numDoc1.Text = ""
                    Case 1
                        numDoc1.Text = dtsOF.gnumsAlbaran(0)
                    Case Else
                        numDoc1.Text = "VARIOS"
                End Select


                cbMoneda.Text = dtsOF.gDivisa
                lbMoneda1.Text = dtsOF.gSimbolo
                codMonedaI = dtsOF.gcodMoneda
                dtpFecha.Value = dtsOF.gFecha

                cbDireccion.Text = dtsOF.gDireccion
                dtsUB = funcUB.mostrar1(dtsOF.gidUbicacion)

                cbContacto.Text = dtsOF.gContacto
                cbMedioPago.Text = dtsOF.gMedioPago
                cbTipoPago.Text = dtsOF.gTipoPago

                cbTipoIVA.Items.Clear()
                cbTipoIVA.Items.Add(dtsOF.gNombreTipoIVA & " " & dtsOF.gTipoIVA & "%")
                cbTipoIVA.SelectedIndex = 0


                ckRecargoEquivalencia.Checked = dtsOF.gRecargoEquivalencia

                If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
                    TipoRecargoEq.Enabled = True
                    TipoRecargoEq.Text = dtsOF.gTipoRecargoEq
                Else
                    TipoRecargoEq.Enabled = False
                    TipoRecargoEq.Text = 0
                End If

                cbRetencion.Items.Clear()
                cbRetencion.Items.Add(dtsOF.gNombreTipoRetencion & " " & dtsOF.gTipoRetencion & "%")
                cbRetencion.SelectedIndex = 0

                ProntoPago.Text = FormatNumber(dtsOF.gProntoPago, 2)

                If dtsOF.gidCuentaBanco > 0 Then
                    Dim funcCB As New FuncionesCuentasBancarias
                    cbCuenta.Text = funcCB.NombreCompleto(dtsOF.gidCuentaBanco)
                Else
                    cbCuenta.Text = ""
                End If
                Observaciones.Text = dtsOF.gObservaciones


                rtbNota.Rtf = dtsOF.gNotas
                cbSolicitadoVia.Text = dtsOF.gSolicitadoVia
                PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
                cbEstado.Items.Clear()
                'Cargar el estado que tenga y los que falten

                If EstadoInicial.gCabecera Then
                    cbEstado.Items.Add(funcES.EstadoCabecera("Factura"))

                    bGuardar.Enabled = Not vSoloLectura
                End If
                If EstadoInicial.gAnulado Then
                    cbEstado.Items.Add(funcES.EstadoEspera("Factura"))

                    ConceptosEditables = False

                    bGuardar.Enabled = False
                    bBorrar.Enabled = False
                End If
                If EstadoInicial.gEnCurso And EstadoInicial.gEspera Then 'cobrado Parcial
                    cbEstado.Items.Add(funcES.EstadoFactura("PARCIAL"))


                    ConceptosEditables = True
                    bGuardar.Enabled = Not vSoloLectura
                    bBorrar.Enabled = False
                End If
                If EstadoInicial.gEspera And Not EstadoInicial.gEnCurso Then  'PENDIENTE
                    cbEstado.Items.Add(funcES.EstadoFactura("PENDIENTE"))

                    ConceptosEditables = True
                    bGuardar.Enabled = Not vSoloLectura
                    bBorrar.Enabled = Not vSoloLectura
                End If
                If EstadoInicial.gCompleto Then 'Cobrada
                    cbEstado.Items.Add(funcES.EstadoFactura("COBRADA"))

                    ConceptosEditables = False
                    bGuardar.Enabled = Not vSoloLectura
                    bBorrar.Enabled = False
                End If
                If EstadoInicial.gAutomatico Then 'devuelta
                    cbEstado.Items.Add(funcES.EstadoFactura("DEVUELTA"))

                    ConceptosEditables = True
                    bGuardar.Enabled = Not vSoloLectura
                    bBorrar.Enabled = False
                End If

                cbEstado.Text = EstadoInicial.ToString


                Call CargarlvVencimientos(dtsOF.gVencimientos)
                Call CargarConceptos()
                SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
                BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
                TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
                TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
                Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
                Total.Text = FormatNumber(dtsOF.gTotal, 2)
                cambios = False
            End If

        Catch ex As Exception
            ex.Data.Add("numDoc.Text", numDoc.Text)
            CorreoError(ex)
        End Try

    End Sub

    Private Sub CargarConceptos()
        listaC = funcCO.Mostrar(numDoc.Text)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoFactura In listaC
            nuevaLineaLV(dts)
        Next
        cbArticulo.Focus()
    End Sub


    Private Sub CargarContactos()
        If cbCliente.SelectedIndex <> -1 Then
            Dim Contacto As String = cbContacto.Text
            cbContacto.Text = ""
            cbContacto.Items.Clear()
            Dim lista As List(Of datosContacto) = funcCT.mostrarCli(cbCliente.SelectedItem.itemdata)
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
        If cbCliente.SelectedIndex <> -1 Then
            Dim direccion As String = cbDireccion.Text
            cbDireccion.Items.Clear()
            Dim lista As List(Of datosUbicacion) = funcUB.mostrarCli(cbCliente.SelectedItem.itemdata, True, 1, 1, 0, 0, 0, 0)
            For Each dts As datosUbicacion In lista
                cbDireccion.Items.Add(New IDComboBox(If(dts.gSubCliente = "", "", dts.gSubCliente & ": ") & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
            Next
            If direccion.Length > 0 Then
                cbDireccion.Text = direccion
            End If
            If cbDireccion.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    dtsUB = lista(0)
                    cbDireccion.SelectedIndex = 0
                    
                  
                Else
                    cbDireccion.Text = ""
                End If
            Else

            End If


        End If
    End Sub

   


    
    Private Sub CargarCuentas()
        If Not dtsFA.gCuentas Is Nothing Then
            Dim cuentaActual As String = cbCuenta.Text
            cbCuenta.Items.Clear()
            If dtsFA.gCuentas.Count > 0 Then
                For Each dts As DatosCuentaBancaria In dtsFA.gCuentas
                    cbCuenta.Items.Add(New IDComboBox(dts.gNombreCompleto, dts.gidCuentaBanco))
                Next
            End If
            If cuentaActual.Length > 0 Then
                'Si habiamos guardado la cuenta, la volvemos a poner
                cbCuenta.Text = cuentaActual
                'Si no coincide con ninguna, la borramos
                If cbCuenta.SelectedIndex = -1 Then
                    cbCuenta.Text = ""
                End If
            End If
            'Si solo hay una y no es válido lo escrito, la ponemos directamente
            If cbCuenta.Text = "" And dtsFA.gCuentas.Count = 1 Then
                cbCuenta.Text = dtsFA.gCuentas(0).gNombreCompleto
            End If
        End If
    End Sub


 

    Private Sub CargarDatosFacturacionCliente()
        Dim semaforo0 As Boolean = semaforo
        dtsFA = funcFA.mostrarCli(iidCliente)
        Call PresentarAvisoFacturacion()
        If G_AGeneral = "G" Then
            Call CargarDatosClienteEditables()
        End If
    End Sub




    Private Sub CargarDatosClienteEditables()
        Dim semaforo0 As Boolean = semaforo
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
        cbMedioPago.Text = dtsFA.gMedioPago
        cbTipoPago.Text = dtsFA.gTipoPago
        cbPersona.Text = dtsCL.gResponsableCuenta
        If dtsCL.gidResponsableCuenta > 0 Then
            ComisionGeneral.Text = FormatNumber(funcCM.Porcentaje(dtsCL.gidCliente, dtsCL.gidResponsableCuenta), 2)
        Else
            ComisionGeneral.Text = 0
        End If
        ProntoPago.Text = FormatNumber(dtsFA.gProntoPago, 2)

    End Sub


    Private Sub CargarDatosClienteNoEditables()
        If Not dtsFA Is Nothing Then
            cbTipoIVA.Items.Clear()
            cbTipoIVA.Items.Add(funcTI.Mostrar1(dtsFA.gidTipoIVA))
            cbTipoIVA.SelectedIndex = 0

            ckRecargoEquivalencia.Checked = dtsFA.gRecargoEquivalencia

            If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
                TipoRecargoEq.Enabled = True
                TipoRecargoEq.Text = dtsFA.gTipoRecargoEq
            Else
                TipoRecargoEq.Enabled = False
                TipoRecargoEq.Text = 0
            End If

            cbRetencion.Items.Clear()
            cbRetencion.Items.Add(funcTR.Mostrar1(dtsFA.gidTipoRetencion))
            cbRetencion.SelectedIndex = 0
            DiaPago1.Text = If(dtsFA.gDiaPago1 = 0, "", CStr(dtsFA.gDiaPago1))
            DiaPago2.Text = If(dtsFA.gDiaPago2 = 0, "", CStr(dtsFA.gDiaPago2))


        End If

    End Sub


    Private Sub PresentarAvisoCliente()
        If Trim(dtsCL.gobservaciones).Length > 0 And Not avisadoCliente And ClienteAvisado <> dtsCL.gidCliente Then

            MsgBox(dtsCL.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsCL.gnombrefiscal)
            Call PresentarAvisoFacturacion()
            ClienteAvisado = dtsCL.gidCliente
            avisadoCliente = True
        End If
    End Sub


    Private Sub PresentarAvisoFacturacion()
        If Not dtsFA Is Nothing AndAlso (Trim(dtsFA.gObservaciones).Length > 0 And Not AvisadoFacturacion And ClienteAvisado <> dtsFA.gidCliente) Then
            MsgBox(dtsFA.gObservaciones, MsgBoxStyle.OkOnly, "AVISO FACTURACIÓN " & dtsCL.gnombrefiscal)
            AvisadoFacturacion = True
        End If

    End Sub


    Private Sub AsignarDOCDatosClienteNoEditables()
        dtsOF.gTipoIVA = dtsFA.gTipoIVA
        dtsOF.gidTipoIVA = dtsFA.gidTipoIVA
        dtsOF.gRecargoEquivalencia = dtsFA.gRecargoEquivalencia
        dtsOF.gTipoRecargoEq = dtsFA.gTipoRecargoEq
        dtsOF.gTipoRetencion = dtsFA.gTipoRetencion
        dtsOF.gidTipoRetencion = dtsFA.gidTipoRetencion
    End Sub

    Private Sub CargarCombosCliente()
        Call CargarContactos()
        Call CargarDirecciones()
        Call CargarCuentas()
    End Sub

    Private Sub CargarTiposNoEditables()
        'Asignamos datos de IVA y retención que se guardan en la factura independientemente de los tipos vigentes.
        dtsOF.gTipoIVAFac = dtsOF.gTipoIVA
        dtsOF.gTipoRecargoEqFac = dtsOF.gTipoRecargoEq
        dtsOF.gTipoRetencionFac = dtsOF.gTipoRetencion
    End Sub


    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)
        If cbCliente.SelectedIndex = -1 Then
            'Si no hay cliente seleccionado, buscamos en Articulis directamente
            lista = funcAR.Buscar(" AND Vendible = 1 " & If(cbTipo.SelectedIndex = -1, "", " AND idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo) _
                                                & If(cbSubTipo.SelectedIndex = -1, "", " AND idsubTipoArticulo = " & cbSubTipo.SelectedItem.itemdata), "")
        Else
            'Si tenemos el cliente, el nombre del artículo será el específico si existe
            lista = funcAR.BuscarAC(" AND Vendible = 1 " & If(cbTipo.SelectedIndex = -1, "", " AND idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo) _
                                                & If(cbSubTipo.SelectedIndex = -1, "", " AND idsubTipoArticulo = " & cbSubTipo.SelectedItem.itemdata), cbCliente.SelectedItem.itemdata, "", dtsUB.gidIdioma)

        End If
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoFactura)
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

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoFactura)
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
            Call Recalcular()
            Call CalcularVencimientos()
        End If
    End Sub


    Private Sub Recalcular()
        funcOF.DatosCalculados(dtsOF) 'Recargamos el dtsOF por referencia
        SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)

    End Sub


    Private Function GuardarGeneral()
        Try
            Dim validar As Boolean = True
            Dim soloEstado As Boolean = False
            If cbEstado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
            End If
            If cbCliente.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbCliente, "Debe seleccionar un cliente")
            End If
            If cbDireccion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDireccion, "Debe seleccionar una dirección")
            Else
                Dim iidPais As Integer = funcUB.campoidPais(cbDireccion.SelectedItem.itemData)
                Dim sNIF As String = dtsCL.gnif
                If iidPais = 1 Then
                    'Si es español, verifcamos el NIF
                    If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                    Else
                        validar = False
                        ep1.SetError(bVerCliente, "NIF no válido. Debe corregirlo en la ficha de cliente.")
                    End If
                ElseIf funcPA.NIFObligatorio(iidPais) Then
                    If sNIF = "" Then
                        validar = False
                        ep1.SetError(bVerCliente, "No se ha especificado el NIF. Debe corregirlo en la ficha del cliente.")
                    End If


                End If
            End If
            If cbMoneda.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMoneda, "Debe seleccionar una moneda")
            End If
            If cbMedioPago.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMedioPago, "Se ha de seleccionar un medio de pago")
            Else
                If cbCuenta.Enabled Then
                    If cbCuenta.SelectedIndex = -1 Then
                        ep2.SetError(cbCuenta, "No ha seleccinado una cuenta bancaria")
                    End If
                End If
            End If
            If cbTipoPago.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbTipoPago, "Se ha de seleccionar un tipo de pago")
            End If
            If cbTipoIVA.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbTipoIVA, "Se ha de seleccionar un tipo de IVA")
            End If
            If cbRetencion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbRetencion, "Se ha de seleccionar un tipo de Retención")
            End If

            If cbPersona.SelectedIndex = -1 Then

                ep2.SetError(cbPersona, "No se ha seleccionado un comercial")
            End If

            If validar Then
                dtsOF.gnumFactura = numDoc.Text
                dtsOF.gReferenciaCliente = RefCliente.Text
                dtsOF.gEstado = cbEstado.Text
                dtsOF.gFecha = dtpFecha.Value.Date
                dtsOF.gFechaEntrega = dtpFecha.Value.Date 'dtpFechaPrevista.Value
                dtsOF.gidCliente = cbCliente.SelectedItem.itemdata
                dtsOF.gidUbicacion = cbDireccion.SelectedItem.itemdata
                dtsOF.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
                dtsOF.gidMedioPago = If(cbMedioPago.SelectedIndex = -1, 0, cbMedioPago.SelectedItem.gidMEdioPago)
                dtsOF.gidTipoPago = If(cbTipoPago.SelectedIndex = -1, 0, cbTipoPago.SelectedItem.gidTipoPago)
                dtsOF.gidCuentaBanco = If(cbCuenta.SelectedIndex = -1, 0, cbCuenta.SelectedItem.itemdata)
                dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda

                dtsOF.gDescuento = 0 'If(Descuento.Text = "", 0, CDbl(Descuento.Text))
                dtsOF.gDescuento2 = 0 'If(Descuento2.Text = "", 0, CDbl(Descuento2.Text))
                dtsOF.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
                dtsOF.gSolicitadoVia = cbSolicitadoVia.Text
                dtsOF.gNotas = rtbNota.Rtf 'Nota.Text
                dtsOF.gObservaciones = Observaciones.Text
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
                dtsOF.gPersona = cbPersona.Text
                'Datos de liquidación de comisión, solo se añaden al insertar
                dtsOF.gLiquidadaComision = False
                dtsOF.gFechaLiquidacion = Now.Date
                Call AsignarDOCDatosClienteNoEditables()


                If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
                dtsOF.gPrecioTransporte = PrecioTransporte.Text

                If G_AGeneral = "G" Then


                    Call CargarTiposNoEditables()

                    numDoc.Text = funcOF.insertar(dtsOF)
                    dtsOF.gnumFactura = numDoc.Text
                    G_AGeneral = "A"
                    MsgBox("Creada la Factura " & numDoc.Text & ". Ya puede introducir los conceptos.")
                    gbConceptos.Enabled = True

                    'Debe seguir en estado cabecera
                Else

                    funcOF.actualizar(dtsOF)


                    If Total.Text = "" Then Total.Text = 0
                    Dim totalFactura As Double = Total.Text
                    Dim totalVencimientos As Double = 0
                    If Not dtsOF.gVencimientos Is Nothing Then
                        For Each dtsV As DatosVencimiento In dtsOF.gVencimientos
                            totalVencimientos = totalVencimientos + dtsV.gImporte
                        Next
                    End If
                    Call Recalcular()
                    Dim diferencia As Double = Math.Abs(Total.Text - totalVencimientos)

                    If diferencia > 0.01 Then Call CalcularVencimientos()

                    funcOF.actualizarVencimientos(dtsOF)
                    Call CargarlvVencimientos(dtsOF.gVencimientos)
                    EstadoInicial = cbEstado.SelectedItem
                    Dim texto As String = ""

                    If EstadoInicial.gEspera And EstadoInicial.gEnCurso Then
                        texto = "Factura actualizada correctamente"
                        'texto = texto & vbCrLf & " No se modificarán conceptos porque la factura está en estado " & EstadoInicial.gEstado
                        'ConceptosEditables = False
                    Else
                        If cbArticulo.Text = "" Then texto = "Factura actualizada correctamente"
                    End If


                    If texto <> "" Then MsgBox(texto)
                End If
                cambios = False
                ep1.Clear()
                ep2.Clear()
            End If

            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarGeneral")
            ex.Data.Add("numDoc.Text", numDoc.Text)
            CorreoError(ex)
            Return False
        End Try
    End Function

    Private Sub PropagarIVAConceptos(ByVal iidTipoIVAAnterior As Integer, ByVal TipoIVAAnterior As Double, ByVal TipoRecargoEqAnterior As Double)
        'Si ha cambiado el tipo o el idTipo de IVA
        If iidTipoIVAAnterior <> dtsOF.gidTipoIVA Or TipoIVAAnterior <> dtsOF.gTipoIVAFac Or TipoRecargoEqAnterior <> dtsOF.gTipoRecargoEq Then
            funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA, dtsOF.gTipoIVAFac, dtsOF.gTipoRecargoEqFac)
        End If
    End Sub

    Private Function GuardarConcepto() As Boolean
        Dim iidconcepto As Long = 0
        Try
            Dim validar As Boolean = False
            If cbArticulo.Text <> "" Then
                validar = True
                Dim dts As New DatosConceptoFactura
                dts.gidConcepto = 0
                dts.gnumAbono = 0
                If indice <> -1 Then
                    'si existe, precargamos el concepto
                    iidconcepto = lvConceptos.Items(indice).SubItems(1).Text
                    If iidconcepto > 0 Then
                        dts = funcCO.Mostrar1(iidconcepto)
                    End If
                End If
                dts.gnumFactura = numDoc.Text

                If indice = -1 And codArticuloCli.Text = "" And cbCodArticulo.Text <> "" Then
                    dts.gcodArticuloCli = cbCodArticulo.Text 'Asignar el codArticuloCli como el codArticulo
                Else
                    dts.gcodArticuloCli = codArticuloCli.Text
                End If
                dts.gcodArticulo = cbCodArticulo.Text
                dts.gArticuloCli = cbArticulo.Text
                dts.gRefCliente = ""

                If Cantidad.Text = "" Or Cantidad.Text = "-" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0
                dts.gCantidad = Cantidad.Text
                dts.gPVPUnitario = If(PVP.Text = "", 0, CDbl(PVP.Text))
                dts.gidTipoIVA = dtsOF.gidTipoIVA
                dts.gDescuento = If(DescuentoC.Text = "", 0, CDbl(DescuentoC.Text))
                dts.gPrecioNetoUnitario = PrecioNeto.Text
                dts.gOrden = indice + 1
                dts.gTipoIVA = dtsOF.gTipoIVA
                dts.gTipoRecargoEq = dtsOF.gTipoRecargoEq
                dts.gTipoIVAFac = dtsOF.gTipoIVAFac
                dts.gTipoRecargoEqFac = dts.gTipoRecargoEqFac
                dts.gNumsSerie = numsSerie.Text
                If dts.gNumsSerie = "N/S:" Then dts.gNumsSerie = ""

                dts.gPorcentajeComision = If(IsNumeric(ComisionLinea.Text), CDbl(ComisionLinea.Text), 0)
                dts.gImporteComision = dts.gCantidad * dts.gPrecioNetoUnitario * dts.gPorcentajeComision / 100


                Dim iidArtCli As Integer = 0

                Dim dtsAC As New DatosArticuloCliente
                Dim dtsACP As DatosArticuloClientePrecio
                If iidArticulo = 0 Then
                    dts.gidArticulo = 0
                    iidArticulo = 0
                Else
                    'iidArticulo = cbArticulo.SelectedItem.itemdata
                    dts.gidArticulo = iidArticulo
                    dtsAC.gidArticulo = iidArticulo
                    dtsAC.gidCliente = cbCliente.SelectedItem.itemdata
                    dtsAC.gArticuloCli = dts.gArticuloCli
                    dtsAC.gcodArticulo = dts.gcodArticulo
                    dtsAC.gcodArticuloCli = dts.gcodArticuloCli
                    dtsAC.gDescuento = dts.gDescuento
                    dtsAC.gFechaAlta = Now.Date
                    dtsAC.gFechaBaja = Now.Date
                    dtsAC.gActivo = True
                    dtsAC.gnumDoc = numDoc.Text
                    dtsAC.gtipoDoc = "FACTURA"
                    dtsAC.gPrecioNetoUnitario = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                End If
                Dim SoloReferenciaDoc As Boolean = False
                If indice = -1 Then
                    'Hemos de guardar un nuevo concepto
                    dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
                    Dim estado As DatosEstado = funcES.EstadoEspera("C.FACTURA")
                    dts.gidEstado = estado.gidEstado
                    dts.gEstado = estado.gEstado
                    'Si ha habido cambio, hemos de guardar los cambios en ArticuloCliente
                    If dts.gidArticulo > 0 Then 'Siempre que hayamos seleccionado un artículo
                        iidArtCli = funcAC.Existe(iidArticulo, iidCliente)
                        If iidArtCli > 0 Then
                            dtsAC.gIdArtCli = iidArtCli
                            SoloReferenciaDoc = CompruebaACCambio(dtsAC)
                            funcAC.actualizar(dtsAC, SoloReferenciaDoc)
                        Else
                            If CompruebaACigual() Then
                                iidArtCli = funcAC.insertar(dtsAC)
                            End If
                        End If

                    End If
                    dts.gidArtCli = iidArtCli

                    dts.gidConcepto = funcCO.insertar(dts)
                    iidconcepto = dts.gidConcepto
                    Call nuevaLineaLV(dts)
                    If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar el estado de la factura
                        Me.Text = "EDITAR FACTURA"
                        'cbEstado.Items.Clear()
                        'cbEstado.Items.Add(funcES.EstadoAnulado("Factura"))
                        cbEstado.SelectedIndex = -1
                        cbEstado.Text = ""
                        Dim x As Integer = cbEstado.FindString(funcES.EstadoCabecera("FACTURA").gEstado)
                        If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera

                        Dim dtsES As DatosEstado = funcES.EstadoFactura("PENDIENTE")
                        If cbEstado.FindString(dtsES.gEstado) = -1 Then cbEstado.Items.Add(dtsES)
                        cbEstado.Text = dtsES.ToString
                        funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    End If
                Else
                    'actualizar concepto
                    dts.gTipoUnidad = dtsCO.gTipoUnidad
                    dts.gidConcepto = lvConceptos.Items(indice).SubItems(1).Text
                    If dts.gidArticulo = 0 Then
                        iidArtCli = 0
                    Else
                        iidArtCli = funcAC.Existe(iidArticulo, iidCliente)
                        If iidArtCli > 0 Then
                            dtsAC.gIdArtCli = iidArtCli
                            SoloReferenciaDoc = CompruebaACCambio(dtsAC)
                            funcAC.actualizar(dtsAC, SoloReferenciaDoc)
                        Else
                            If CompruebaACigual() Then
                                iidArtCli = funcAC.insertar(dtsAC)
                            End If
                        End If
                    End If
                    dts.gidArtCli = iidArtCli
                    funcCO.actualizar(dts)
                    Call ActualizarLineaLV(dts)
                End If
                'Guardar el precio específico si ha cambiado
                If Not SoloReferenciaDoc And iidArtCli > 0 Then
                    dtsACP = funcACP.mostrarArtCli(iidArtCli)
                    Dim precioNetoUnitario As Double = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                    If dtsACP.gidArtCli = iidArtCli And dtsACP.gPrecioNetoUnitario = precioNetoUnitario And dtsACP.gcodMoneda = dtsOF.gcodMoneda Then
                    Else
                        dtsACP.gidArtCli = iidArtCli
                        dtsACP.gPrecioNetoUnitario = precioNetoUnitario
                        dtsACP.gActivo = True
                        dtsACP.gcodMoneda = dtsOF.gcodMoneda

                        funcACP.Desactivar(iidArtCli)
                        If precioNetoUnitario <> 0 Then
                            'Si el precio es 0 no lo guardamos
                            funcACP.insertar(dtsACP)
                        End If

                    End If
                End If

                Call Recalcular()
                Call CalcularVencimientos()
                Call LimpiarEdicion()
                funcOF.actualizarVencimientos(dtsOF)
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarConcepto")
            ex.Data.Add("numDoc.Text", numDoc.Text)
            ex.Data.Add("iidConcepto", iidconcepto)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
            Return False
        End Try
    End Function


    Private Function CompruebaACCambio(ByVal dts As DatosArticuloCliente) As Boolean
        Dim SoloReferenciaDoc As Boolean = False
        Dim dtsAC As DatosArticuloCliente = funcAC.mostrar1(dts.gIdArtCli)
        Dim texto As String = ""
        If dts.gDescuento <> dtsAC.gDescuento Then texto = "Descuento"
        If dts.gPrecioNetoUnitario <> dtsAC.gPrecioNetoUnitario Then texto = texto & If(texto = "", "", ", ") & "Precio Neto"
        If dts.gcodArticuloCli <> dtsAC.gcodArticuloCli Then texto = texto & If(texto = "", "", ", ") & "Código Artículo/Cliente"
        If dts.gArticuloCli <> dtsAC.gArticuloCli Then texto = texto & If(texto = "", "", ", ") & "Descripción"
        If texto = "" Then
            SoloReferenciaDoc = True
        Else
            texto = "Se han detectado cambios de las especificaciones del artículo para el cliente en los campos: " & texto & "." & vbCrLf & "¿Desea guardar los cambios en Artículo-Cliente?"
            If MsgBox(texto, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SoloReferenciaDoc = False
            Else
                SoloReferenciaDoc = True
            End If
        End If
        Return SoloReferenciaDoc
    End Function




    Private Function CompruebaACigual() As Boolean
        'Comprobamos si los datos de personalización del artículo para el cliente son identicos a los del artículo genérico
        'Devuelve True cuando los datos son diferentes y se ha de guardar
        If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
        If PrecioNeto.Text > 0 Then
            Return True
        Else
            If dtsAR Is Nothing OrElse dtsAR.gidArticulo <> iidArticulo Then dtsAR = funcAR.Mostrar1(iidArticulo)

            If codArticuloCli.Text = dtsAR.gcodArticulo And cbArticulo.Text = dtsAR.gArticulo Then
                If (dtsAR.gDescuento1 And DescuentoC.Text = dtsFA.gDescuento) Or (dtsAR.gDescuento2 And DescuentoC.Text = dtsFA.gDescuento2) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        End If

    End Function



    Private Sub CargarEdicion()
        'Carga el concepto en la zona de edición
        If indice <> -1 Then
            semaforo = False
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            dtsCO = funcCO.Mostrar1(iidConcepto)
            iidArticulo = dtsCO.gidArticulo
            cbTipo.Text = dtsCO.gTipoArticulo
            Call IntroducirSubTiposArticulo()
            cbSubTipo.Text = dtsCO.gSubTipoArticulo
            Call CargarArticulosC()
            cbCodArticulo.Text = dtsCO.gcodArticulo
            cbArticulo.Text = dtsCO.gArticuloCli
            codArticuloCli.Text = dtsCO.gcodArticuloCli
            lbUnidad.Text = dtsCO.gTipoUnidad
            PVP.Text = FormatNumber(dtsCO.gPVPUnitario, 2)
            Cantidad.Text = dtsCO.gCantidad
            DescuentoC.Text = dtsCO.gDescuento
            PrecioNeto.Text = FormatNumber(dtsCO.gPrecioNetoUnitario, 2)
            subTotal.Text = FormatNumber(dtsCO.gSubTotal, 2)
            numsSerie.Text = dtsCO.gNumsSerie
            ComisionLinea.Text = FormatNumber(dtsCO.gPorcentajeComision, 2)

            semaforo = True
        End If
    End Sub


    Private Sub CargarArticuloC()
        'Carga los datos de un artículo en la zona de edición
        If iidArticulo > 0 And cbCliente.SelectedIndex <> -1 Then
            semaforo = False
            ep2.Clear()
            dtsAR = funcAR.Mostrar1V(iidArticulo, cbCliente.SelectedItem.itemdata, dtsUB.gidIdioma)
            cbTipo.Text = dtsAR.gTipoArticulo
            Call IntroducirSubTiposArticulo()
            cbSubTipo.Text = dtsAR.gSubTipoArticulo
            Call CargarArticulosC()
            cbCodArticulo.Text = dtsAR.gcodArticulo
            cbArticulo.Text = dtsAR.gArticuloCli
            codArticuloCli.Text = dtsAR.gCodArticuloCli
            lbUnidad.Text = dtsAR.gTipoUnidad

            If dtsAR.gPrecioArtCli = -1 Then
                'Si no hay precio neto específico, puede haber descuento
                PrecioNeto.Text = 0
                If dtsAR.gDescuento > 0 Then
                    'Si hay descuento específico
                    DescuentoC.Text = FormatNumber(dtsAR.gDescuento, 2)
                Else
                    'Si no, tomamos el descuento del cliente doméstico o industrial según el tipo de artículo
                    DescuentoC.Text = FormatNumber(If(dtsAR.gDescuento1, dtsFA.gDescuento, dtsFA.gDescuento2))
                End If
            Else
                'Si hay precio neto específico, lo ponemos, comprobando que la moneda sea la seleccionada en el documento
                If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
                    PrecioNeto.Text = FormatNumber(dtsAR.gPrecioArtCli, 2)
                Else
                    Dim aviso As Boolean
                    Dim FechaCambio As Date
                    PrecioNeto.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioArtCli, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
                    If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                    'lbCambio.Text = "CAMBIO " & FechaCambio
                    'lbCambio.Visible = aviso
                End If
                DescuentoC.Text = 0
            End If


            If cbMoneda.SelectedIndex = -1 Then
                PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            Else
                If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
                    PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
                Else
                    Dim aviso As Boolean
                    Dim FechaCambio As Date
                    PVP.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioUnitarioV, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
                    If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                    'lbCambio.Text = "CAMBIO " & FechaCambio
                    'lbCambio.Visible = aviso
                End If

            End If
            If Cantidad.Text = "" Then Cantidad.Text = 0
            If DescuentoC.Text = "" Then DescuentoC.Text = 0
            If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
            If PVP.Text = "" Then PVP.Text = 0
            If Cantidad.Text = 0 Then Cantidad.Text = 1
            If DescuentoC.Text <> 0 Then  'Si hay descuento, ignoramos el precio neto
                PrecioNeto.Text = FormatNumber((1 - DescuentoC.Text / 100) * PVP.Text, 2)
            Else
                If PrecioNeto.Text = 0 Then PrecioNeto.Text = PVP.Text 'Si el precio neto=0, ponemos el PVP
            End If
            subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
            semaforo = True
        End If
    End Sub

    Private Sub CalcularVencimientos()
        If Total.Text = "" Then Total.Text = 0
        If cbTipoPago.SelectedIndex <> -1 And cbCliente.SelectedIndex <> -1 And Not EstadoInicial.gBloqueado And Not (EstadoInicial.gEspera And EstadoInicial.gEnCurso) Then
            If Total.Text = 0 Then
                dtsOF.gVencimientos = Nothing
            Else
                Dim fecha As Date = dtpFecha.Value
                Dim dias As Integer = 0
                Dim Vencimiento As Date = dtpFecha.Value
                Dim numPagos As Integer = cbTipoPago.SelectedItem.gnumPagos
                If numPagos > 0 Then
                    Dim importe As Double = Total.Text / numPagos
                    Dim FechaI As Date
                    Dim FechaF As Date
                    If dtsFA.gExentoPagosAgosto Then
                        FechaI = CDate("1-8-" & Year(fecha))
                        FechaF = CDate("31-8-" & Year(fecha))
                    Else
                        'Si no está exento de pago ponemos una franja qua acaba antes de empezar
                        FechaI = Now.Date.AddDays(1)
                        FechaF = Now.Date
                    End If
                    Dim lista As New List(Of DatosVencimiento)
                    Dim dts As DatosVencimiento
                    For p = 1 To numPagos
                        If p = 1 And numPagos > 1 Then
                            dias = cbTipoPago.SelectedItem.gCarencia
                        Else
                            dias = dias + cbTipoPago.SelectedItem.gContadorDias
                        End If
                        Vencimiento = CalculaVencimiento(fecha, If(DiaPago1.Text = "", 0, CInt(DiaPago1.Text)), If(DiaPago2.Text = "", 0, CInt(DiaPago2.Text)), dias, FechaI, FechaF)
                        dts = New DatosVencimiento
                        dts.gnumFactura = numDoc.Text
                        dts.gVencimiento = Vencimiento
                        dts.gImporte = importe
                        dts.gCobrado = False
                        lista.Add(dts)
                    Next
                    lista.Sort(Function(y, x) x.gVencimiento.CompareTo(y.gVencimiento))
                    dtsOF.gVencimientos = lista
                End If
                Call CargarlvVencimientos(dtsOF.gVencimientos)
            End If

        End If

    End Sub

    Private Function listakey(ByVal dts As DatosVencimiento) As Date
        Return dts.gVencimiento
    End Function


    Private Sub CargarlvVencimientos(ByVal Vtos As List(Of DatosVencimiento))
        lvVencimientos.Items.Clear()
        Dim Cobrados As Integer = 0
        Dim Devueltos As Integer = 0
        'Dim funcVE As New FuncionesVencimientos
        'Dim Vtos As List(Of DatosVencimiento) = funcVE.Mostrar(numDoc.Text)

        If Not Vtos Is Nothing Then
            For Each dts As DatosVencimiento In Vtos
                With lvVencimientos.Items.Add(dts.gVencimiento)
                    .SubItems.Add(FormatNumber(dts.gImporte, 2) & dtsOF.gSimbolo)

                    If dts.gDevuelto Then
                        .ForeColor = Color.Red
                        Devueltos = Devueltos + 1
                    ElseIf dts.gCobrado Then
                        .ForeColor = Color.Green
                        Cobrados = Cobrados + 1
                    Else
                        .ForeColor = Color.Black
                    End If
                End With
            Next
        End If

        If lvConceptos.Items.Count > 0 Then
            If Devueltos > 0 Then
                Dim dtsES As DatosEstado = funcES.EstadoFactura("DEVUELTA")
                If cbEstado.FindString(dtsES.gEstado) = -1 Then
                    cbEstado.Items.Add(dtsES)
                End If
                cbEstado.Text = dtsES.gEstado
            Else


                If Cobrados = 0 Then
                    If cbEstado.SelectedIndex = -1 Then
                        Dim dtsES As DatosEstado = funcES.EstadoFactura("PENDIENTE")
                        If cbEstado.FindString(dtsES.gEstado) = -1 Then
                            cbEstado.Items.Add(dtsES)
                        End If
                        cbEstado.Text = dtsES.gEstado
                    Else
                        If cbEstado.SelectedItem.gAnulado Then
                        Else
                            Dim dtsES As DatosEstado = funcES.EstadoFactura("PENDIENTE")
                            If cbEstado.FindString(dtsES.gEstado) = -1 Then
                                cbEstado.Items.Add(dtsES)
                            End If
                            cbEstado.Text = dtsES.gEstado
                        End If
                    End If

                ElseIf Cobrados = dtsOF.gVencimientos.Count Then
                    Dim dtsES As DatosEstado = funcES.EstadoFactura("COBRADA")
                    If cbEstado.FindString(dtsES.gEstado) = -1 Then
                        cbEstado.Items.Add(dtsES)
                    End If
                    cbEstado.Text = dtsES.gEstado

                    ConceptosEditables = False
                Else
                    Dim dtsES As DatosEstado = funcES.EstadoFactura("PARCIAL")
                    If cbEstado.FindString(dtsES.gEstado) = -1 Then
                        cbEstado.Items.Add(dtsES)
                    End If
                    cbEstado.Text = dtsES.gEstado

                    ConceptosEditables = False
                End If

            End If
        End If
    End Sub


    Private Function CalculaVencimiento(ByVal FechaFactura As Date, ByVal DiaPago1 As Byte, ByVal DiaPago2 As Byte, ByVal Dias As Integer, ByVal VacacionesI As Date, ByVal VacacionesF As Date) As Date
        'Ver  http://comunidadnexus.com/2009/09/30/el-calculo-de-vencimientos-en-nexus/
        Dim Vencimiento As Date
        If Dias Mod 30 = 0 Then
            'Si es múltiplo de 30 añadimos meses
            Vencimiento = FechaFactura.AddMonths(Dias \ 30)
        Else
            'Si no es multiplo de 30 añadimos diás
            Vencimiento = FechaFactura.AddDays(Dias)
        End If


        'While FechaFactura.Day <> Vencimiento.Day
        'Vencimiento = Vencimiento.AddDays(1)
        'End While
        Dim Vencimiento2 As Date = Vencimiento
        'Aplicar los dias de pago
        Dim diaPagoMes As Integer
        If DiaPago1 > 0 Then
            diaPagoMes = CalculaDiaPagoMes(DiaPago1, Vencimiento)
            While Vencimiento.Day <> diaPagoMes
                Vencimiento = Vencimiento.AddDays(1)
            End While
            While Vencimiento >= VacacionesI And Vencimiento <= VacacionesF 'Si cae dentro de las vacaciones
                Vencimiento = Vencimiento.AddDays(1)
            End While
            diaPagoMes = CalculaDiaPagoMes(DiaPago1, Vencimiento)
            While Vencimiento.Day <> diaPagoMes
                Vencimiento = Vencimiento.AddDays(1)
            End While

        End If

        If DiaPago2 > 0 Then
            diaPagoMes = CalculaDiaPagoMes(DiaPago2, Vencimiento2)
            While Vencimiento2.Day <> diaPagoMes
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While
            While Vencimiento2 >= VacacionesI And Vencimiento2 <= VacacionesF 'Si cae dentro de las vacaciones
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While
            diaPagoMes = CalculaDiaPagoMes(DiaPago2, Vencimiento2)
            While Vencimiento2.Day <> diaPagoMes
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While

        End If
        'Seleccionar el vencimiento más próximo
        If DiaPago2 = 0 Then
            Return Vencimiento
        ElseIf DiaPago1 = 0 Then
            Return Vencimiento2
        Else
            If Date.Compare(Vencimiento, Vencimiento2) > 0 Then
                Return Vencimiento2
            Else
                Return Vencimiento
            End If
        End If



    End Function

    Private Function CalculaDiaPagoMes(ByVal dia As Byte, ByVal Vencimiento As Date) As Byte
        Dim fecha As Date = CDate("28-" & Vencimiento.Month & "-" & Vencimiento.Year)
        Select Case dia
            Case Is <= 28
                Return dia
            Case 29
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                Else
                    Return 29
                End If
            Case 30
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                ElseIf Vencimiento.Month <> fecha.AddDays(2).Month Then
                    Return 29
                Else
                    Return 30
                End If
            Case 31
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                ElseIf Vencimiento.Month <> fecha.AddDays(2).Month Then
                    Return 29
                ElseIf Vencimiento.Month <> fecha.AddDays(3).Month Then
                    Return 30
                Else
                    Return 31
                End If
        End Select

    End Function

    Private Sub NotaExportacion()
        'Rellenar la Nota con los datos de exportación

        'Dim Notas As String
        'Notas = "DELIVERY CONDITION: EXFACTORY" & vbCrLf
        'Notas = Notas & "ADRESS DELIVERY:" & vbCrLf
        'Notas = Notas & "BULTOS: " & vbCrLf
        'Notas = Notas & "PESO BRUTO: " & vbCrLf
        'Notas = Notas & "CURRENCY: " & Total.Text & lbMoneda1.Text & vbCrLf
        'Notas = Notas & "INVOICE: " & cbMoneda.Text & vbCrLf
        'Notas = Notas & "PARTIDA ESTADISTICA: XXXXXX" & vbCrLf
        'Notas = Notas & "NOMENCLATOR NUMBER: XXXXXXXXXX" & vbCrLf
        'Notas = Notas & "ALL MATERIAL ORIGINARY FROM SPAIN (CEE)" & vbCrLf
        'Notas = Notas & "EXPORTER: SUGAR VALLEY S.L." & vbCrLf
        'Notas = Notas & "EXPORTER CONDITION: MANUFACTURER"

        'If Notas.Length > 499 Then
        '    Nota.Text = Microsoft.VisualBasic.Left(Notas, 499)
        '    MsgBox("Se ha excedido el tamaño de las Notas impresas.")
        'Else
        '    Nota.Text = Notas
        'End If

    End Sub

#End Region




#Region "BOTONES GENERALES"



    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    numDoc.Text = Facturas(indiceL)
                    Call CargarFactura()
                    Call PresentarAvisoFacturacion()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Facturas(indiceL)
                Call CargarFactura()
                Call PresentarAvisoFacturacion()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Facturas.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Facturas(indiceL)
                    Call CargarFactura()
                    Call PresentarAvisoFacturacion()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Facturas(indiceL)
                Call CargarFactura()
                Call PresentarAvisoFacturacion()
            End If


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




    Private Sub bTiposIVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valor As String = cbTipoIVA.Text
        Dim GG As New GestionTiposIVA
        GG.SoloLectura = True
        GG.ShowDialog()
        Call introducirTiposIVA()
        cbMedioPago.Text = valor
        If cbMedioPago.SelectedIndex = -1 Then cbMedioPago.Text = ""
    End Sub

    'Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
    '    If cbCliente.SelectedIndex <> -1 Then
    '        Dim cliente As String = cbCliente.Text
    '        Dim codcli As Integer = cbCodCliente.Text
    '        Dim GG As New GestionClientes
    '        GG.SoloLectura = vSoloLectura
    '        GG.pidCliente = cbCliente.SelectedItem.itemdata
    '        GG.ShowDialog()
    '        Call introducirClientes()
    '        cbCliente.Text = cliente
    '        cbCodCliente.Text = codcli
    '        If cbCliente.SelectedIndex = -1 Then
    '            cbCliente.Text = ""
    '            cbCodCliente.Text = ""
    '        Else
    '            iidCliente = cbCodCliente.SelectedItem.itemdata
    '            'Call CargarDatosCliente()

    '            Call CargarDatosFacturacionCliente()
    '            Call CargarDatosClienteNoEditables()
    '            Call AsignarDOCDatosClienteNoEditables()
    '            Call PropagarIVAConceptos(funcOF.idTipoIVA(numDoc.Text), funcOF.TipoIVA(numDoc.Text), funcOF.TipoRecargoEq(numDoc.Text))
    '            Call Recalcular()
    '            Call CargarCombosCliente()

    '        End If
    '    End If

    'End Sub


    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim iidTipoIVAAnterior As Integer = 0
            Dim dTipoIVAAnterior As Double = 0
            Dim dTipoRecargoEqAnterior As Double = 0
            Dim idiaPago1 As Integer = If(DiaPago1.Text = "", 0, CInt(DiaPago1.Text))
            Dim idiaPago2 As Integer = If(DiaPago2.Text = "", 0, CInt(DiaPago2.Text))
            If G_AGeneral = "A" Then
                iidTipoIVAAnterior = funcOF.idTipoIVA(numDoc.Text)
                dTipoIVAAnterior = funcOF.TipoIVA(numDoc.Text)
                dTipoRecargoEqAnterior = funcOF.TipoRecargoEq(numDoc.Text)
            End If
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura

            GG.pidCliente = iidCliente
            GG.ShowDialog()

            If GG.pidCliente = iidCliente Then
                dtsCL = funcCL.mostrar1(iidCliente)
            End If
            If ClienteSoloLectura Then
                cbCliente.Items.Clear()
                cbCodCliente.Items.Clear()
                cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
                cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrefiscal, dtsCL.gidCliente))
                cbCliente.SelectedIndex = 0
            Else


                Call introducirClientes()
                cbCliente.Text = dtsCL.gnombrefiscal
                cbCodCliente.Text = dtsCL.gcodCli
                If cbCliente.SelectedIndex = -1 Then
                    cbCliente.Text = ""
                    cbCodCliente.Text = ""
                End If
            End If

            Call CargarDatosFacturacionCliente()

            If G_AGeneral = "A" Then
                If iidTipoIVAAnterior <> dtsFA.gidTipoIVA Or dTipoIVAAnterior <> dtsFA.gTipoIVA Or dTipoRecargoEqAnterior <> dtsFA.gTipoRecargoEq Or dtsFA.gRecargoEquivalencia <> ckRecargoEquivalencia.Checked Or idiaPago1 <> dtsFA.gDiaPago1 Or idiaPago2 <> dtsFA.gDiaPago2 Then

                    If MsgBox("¿Propagar los cambios de facturación del cliente a la factura?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Call CargarDatosClienteNoEditables()
                        Call AsignarDOCDatosClienteNoEditables()
                        Call CargarTiposNoEditables()
                        funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA, dtsOF.gTipoIVAFac, dtsOF.gTipoRecargoEqFac)
                        funcOF.actualizarIVA(dtsOF)
                    End If

                    'Call PropagarIVAConceptos(funcOF.idTipoIVA(numDoc.Text), funcOF.TipoIVA(numDoc.Text), funcOF.TipoRecargoEq(numDoc.Text))
                End If
            Else
                Call CargarDatosClienteNoEditables()
                Call AsignarDOCDatosClienteNoEditables()
                Call CargarTiposNoEditables()
            End If

            Call Recalcular()
            Call CalcularVencimientos()
            Call CargarCombosCliente()

        End If

    End Sub

    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click
        Dim GG As New busquedaCliente
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            dtsCL = funcCL.mostrar1(GG.pidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            cbCliente.Text = dtsCL.gnombrefiscal
            iidCliente = GG.pidCliente
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True

        End If

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

    Private Sub bTiposRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim retencion As String = cbRetencion.Text
        Dim GG As New GestionTiposRetencion
        GG.SoloLectura = True
        GG.ShowDialog()
        Call introducirTiposRetencion()
        cbRetencion.Text = retencion
        If cbRetencion.SelectedIndex = -1 Then cbRetencion.Text = ""
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        'Hay que detectar si borramos el documento o la linea
        If indice = -1 Then
            'Borrar Factura
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Factura, es como pulsar nuevo
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
                MsgBox("No es posible borrar una Factura existente.")
                'If MsgBox("No es posible borrar una Factura existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                '    Dim dtsES As DatosEstado = funcES.EstadoAnulado("Factura")
                '    cbEstado.Text = dtsES.ToString
                '    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                '    bGuardar.Enabled = False
                'End If
            End If
        Else
            'Borrar concepto
            If cbArticulo.Text <> "" Then
                If cbArticulo.Text <> "" And ConceptosEditables Then
                    If MsgBox("¿Desea borrar el concepto seleccionado? (No se puede deshacer)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
                        If iidConcepto > 0 Then
                            funcCO.borrar(iidConcepto, numDoc.Text)
                            lvConceptos.Items.RemoveAt(indice)
                            Call LimpiarEdicion()
                            If lvConceptos.Items.Count = 0 Then
                                cbEstado.Items.Clear()
                                'cbEstado.Items.Add(funcES.EstadoAnulado("Factura"))
                                Dim dtsES As DatosEstado = funcES.EstadoCabecera("Factura")
                                cbEstado.Items.Add(dtsES)
                                cbEstado.Text = dtsES.ToString
                                funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                            End If
                            Call Recalcular()
                            Call CalcularVencimientos()
                        End If
                    End If
                Else
                    MsgBox("Conceptos no editables en estado " & cbEstado.Text)


                End If
            End If
        End If
    End Sub



    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else

            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará una nueva factura. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    ClienteAvisado = 0
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará una nueva factura. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    ClienteAvisado = 0
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            End If
        End If

    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim iidTipoIVAAnterior As Integer = 0
        Dim dTipoIVAAnterior As Double = 0
        Dim dTipoRecargoEqAnterior As Double = 0
        If G_AGeneral = "A" Then
            iidTipoIVAAnterior = funcOF.idTipoIVA(numDoc.Text)
            dTipoIVAAnterior = funcOF.TipoIVA(numDoc.Text)
            dTipoRecargoEqAnterior = funcOF.TipoRecargoEq(numDoc.Text)
        End If
        If GuardarGeneral() Then
            If dtsOF.gidEstado = funcES.EstadoFactura("CABECERA").gidEstado Or dtsOF.gidEstado = funcES.EstadoFactura("PENDIENTE").gidEstado Then
                ConceptosEditables = True
            Else
                ConceptosEditables = False
            End If
            If cbArticulo.Text <> "" Then
                If ConceptosEditables Then
                    Dim indice0 As Integer = -1
                    If lvConceptos.SelectedItems.Count > 0 Then
                        indice0 = lvConceptos.SelectedIndices(0)
                    End If

                    Call GuardarConcepto()
                    indice = indice0
                    Call GuardarComision()
                Else
                    If GuardarComision() = False Then MsgBox("Conceptos no editables en estado " & cbEstado.Text)
                End If
            End If
        End If
    End Sub


    Private Function GuardarComision() As Boolean
        Dim Resultado As Boolean = True
        If GestionaComisiones And indice <> -1 AndAlso IsNumeric(ComisionLinea.Text) Then
            Dim iidConcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
            Dim dts As DatosConceptoFactura = funcCO.Mostrar1(iidConcepto)
            If funcCO.PorcentajeComision(iidConcepto) = ComisionLinea.Text Then
                'MsgBox("Conceptos no editables en estado " & cbEstado.Text)
                Resultado = False
            Else
                If funcOF.LiquidadaComision(numDoc.Text) Then
                    MsgBox("Comisión no modificable porque ya ha sido liquidada")
                Else
                    dts.gPorcentajeComision = If(IsNumeric(ComisionLinea.Text), CDbl(ComisionLinea.Text), 0)
                    dts.gImporteComision = dts.gCantidad * dts.gPrecioNetoUnitario * dts.gPorcentajeComision / 100
                    funcCO.actualizarLiquidacion(dts)
                    MsgBox("Comisión actualizada correctamente")
                    Call LimpiarEdicion()

                End If
            End If
        Else
            Resultado = False
        End If
        Return Resultado
    End Function

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bTraspasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim N As Integer = lvConceptos.CheckedItems.Count
        If ckSeleccion.Visible And N > 0 Then
            Dim Conceptos As New List(Of Long)

            Dim iidConcepto As Integer
            For Each item As ListViewItem In lvConceptos.CheckedItems
                iidConcepto = item.SubItems(1).Text
                'Verificamos que la linea no haya sido ya traspasada
                If funcCO.Traspasada(iidConcepto) Then
                    item.Checked = False
                Else
                    Conceptos.Add(iidConcepto)
                End If
            Next
            N = N - lvConceptos.CheckedItems.Count
            If N = 1 Then
                MsgBox("Se ha desactivado un concepto que ya ha sido convertido previamente.")
            End If
            If N > 1 Then
                MsgBox("Se han desactivado " & N & " conceptos que ya han sido convertidos previamente.")
            End If
            If Conceptos.Count = 0 Then
                If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
            Else
                Dim SC As New SeleccionConvertirP
                SC.ShowDialog()
                If SC.pProduccion Then
                    Dim GG As New FlujoSiguiente
                    GG.SoloLectura = vSoloLectura
                    GG.pDesde = "Factura"
                    GG.pHasta = "PRODUCCION"
                    GG.pnumDesde = numDoc.Text
                    GG.pConceptos = Conceptos
                    GG.pLocalizacion = Me.Location
                    GG.ShowDialog()
                End If
                If SC.pAlbaran Then
                    Dim GG As New FlujoSiguiente
                    GG.SoloLectura = vSoloLectura
                    GG.pDesde = "Factura"
                    GG.pHasta = "ALBARAN"
                    GG.pnumDesde = numDoc.Text
                    GG.pConceptos = Conceptos
                    GG.pLocalizacion = Me.Location
                    GG.ShowDialog()
                End If
                Call CargarFactura()

            End If
        Else
            If MsgBox("Seleccione los conceptos que se han de convertir en Factura o Proforma ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ckSeleccion.Visible = True
                lvConceptos.CheckBoxes = True
            End If
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
            lbMoneda1.Text = funcMO.CampoSimbolo("EU")
        End If
    End Sub


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la factura")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        Else
            If Not dtsUB Is Nothing Then
                Exportacion = dtsUB.gExportacion Or dtsUB.gidPais = 1 And dtsOF.gTipoIVA = 0 'Extracomunitario o IVA =0 en España
            End If
            If Exportacion And dtsOF.gNotas.Length = 0 Then
                MsgBox("No se ha creado la Nota de Exportación")
                ep1.SetError(bVerNota, "No se ha creado la Nota de Exportación")
            Else
                InformeFactura.verInforme(numDoc.Text, dtsUB.gidIdioma, PrecioTransporte.Text, rtbNota.Text)
                InformeFactura.ShowDialog()
            End If

        End If

    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la factura")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Factura SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeFactura.GeneraPDF(numDoc.Text, dtsUB.gidIdioma, sfd.FileName, "", PrecioTransporte.Text, rtbNota.Text)
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If
    End Sub



    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la factura")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Factura SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            InformeFactura.GeneraPDF(numDoc.Text, dtsUB.gidIdioma, fichero, camino, PrecioTransporte.Text, rtbNota.Text)
            Dim texto As String = " Buenos días,"
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If
            'texto = texto & "<br/><br/> Adjuntamos la factura " & numDoc.Text & ". "
            'Se envía un correo outlook a la dirección de la ubicación
            CorreoOutlook("FACTURA CLIENTE", funcPE.campoCorreo(Inicio.vIdUsuario), Destinatario, camino & fichero, cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFecha.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemData))
            'CorreoOutlook("Factura SUGAR VALLEY", texto, funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero)

        End If
    End Sub




    Private Sub bVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVencimientos.Click
        If G_AGeneral = "A" Then
            If EstadoInicial.gCompleto Then
                MsgBox("Factura en estado COBRADA")
            End If

            Dim GG As New subVencimientos
            GG.SoloLectura = vSoloLectura
            GG.pVencimientos = dtsOF.gVencimientos
            GG.pSimbolo = lbMoneda1.Text
            GG.pnumFactura = numDoc.Text
            GG.pTotal = Total.Text
            GG.ShowDialog()
            If Not GG.pCancelado Then
                dtsOF.gVencimientos = GG.pVencimientos
                Call CargarlvVencimientos(dtsOF.gVencimientos)
                cambios = True
            End If

        End If
    End Sub

    Private Sub bVerNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerNota.Click
        If G_AGeneral <> "G" Then
            ep1.Clear()
            Dim GG As New SubDatosExportacion
            GG.pnumFactura = numDoc.Text
            GG.ShowDialog()
            rtbNota.Rtf = GG.pNota
            dtsOF.gNotas = GG.pNota
        End If
    End Sub



#End Region


#Region "BOTONES CONCEPTOS"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call LimpiarEdicion()
    End Sub


    Private Sub bArticuloCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bArticuloCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim GG As New GestionArticuloCliente
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = cbCliente.SelectedItem.itemdata
            GG.pidArticulo = iidArticulo
            GG.pcodArticuloCli = codArticuloCli.Text
            GG.pArticuloCli = cbArticulo.Text
            GG.pModo = "DOC"
            GG.ShowDialog()
            If GG.pidArticulo > 0 Then
                iidArticulo = GG.pidArticulo
                Call CargarArticuloC()
            ElseIf iidArticulo > 0 Then
                Call CargarArticuloC()
            End If
        End If

    End Sub


    Private Sub bTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposArticulo.Click
        Dim tipo As String = cbTipo.Text
        Dim subtipo As String = cbSubTipo.Text
        Dim GG As New GestionTiposArticulo
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirTiposArticulo()
        cbTipo.Text = tipo
        If cbTipo.SelectedIndex = -1 Then
            cbTipo.Text = ""
        Else
            Call IntroducirSubTiposArticulo()
            cbSubTipo.Text = subtipo
            If cbSubTipo.SelectedIndex = -1 Then cbSubTipo.Text = ""
        End If
    End Sub

    Private Sub bBuscarArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloC.Click

        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "CONCEPTO"
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

#End Region



#Region "EVENTOS"

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Call CargarEdicion()
        End If
    End Sub



    Private Sub cbCodCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectionChangeCommitted
        If cbCodCliente.SelectedIndex <> -1 Then
            iidCliente = cbCodCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCliente.Text = dtsCL.gnombrefiscal
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True
        End If
    End Sub


    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            avisadoCliente = False
            AvisadoFacturacion = False
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()

            cambios = True
        End If
    End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If cbMedioPago.SelectedIndex <> -1 Then
            If cbMedioPago.SelectedItem.gBanco Then
                cbCuenta.Enabled = True
                If Not dtsFA Is Nothing Then
                    If cbMedioPago.SelectedItem.gTransferencia Then
                        dtsFA.gCuentas = funcCB.Mostrar(0, True) 'Cuentas propias
                    ElseIf cbMedioPago.SelectedItem.gGiro Then
                        dtsFA.gCuentas = funcCB.Mostrar(dtsFA.gidFacturacion, True) 'Cuentas del cliente
                    End If
                    Call CargarCuentas()
                End If

            Else
                cbCuenta.Enabled = False
                cbCuenta.Items.Clear()
                cbCuenta.Text = ""
                cbCuenta.SelectedIndex = -1
            End If
        End If
        cambios = True
    End Sub

    Private Sub cbTipoPago_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoPago.SelectedIndexChanged
        If cbTipoPago.SelectedIndex <> -1 Then
            If cbTipoPago.SelectedItem.gProntoPago Then
                ProntoPago.Enabled = True
                ProntoPago.Text = If(dtsFA Is Nothing, 0, dtsFA.gProntoPago)
            Else
                ProntoPago.Enabled = False
                ProntoPago.Text = 0
            End If
            If cbTipoPago.SelectedItem.gnumPagos = 1 Then

            Else

            End If
            If semaforo Then Call CalcularVencimientos()
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
            End If
        End If
    End Sub


    Private Sub lbMoneda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMoneda1.TextChanged
        lbMoneda2.Text = lbMoneda1.Text
        lbMoneda3.Text = lbMoneda1.Text
        lbMoneda4.Text = lbMoneda1.Text
        lbMoneda5.Text = lbMoneda1.Text
        lbMoneda6.Text = lbMoneda1.Text
        lbmonedaC.Text = lbMoneda1.Text
        lbMonedaS.Text = lbMoneda1.Text
        lbMonedaN.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
    End Sub

   


    Private Sub cbMoneda_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then
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
                        For Each dts As DatosConceptoFactura In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, funcMO.Cambio(dts.gPVPUnitario, codMonedaI, codMonedaActual, True, Now.Date), funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular()
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

    Private Sub ckRecargoEquivalencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.Click
        If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
            TipoRecargoEq.Enabled = True
            TipoRecargoEq.Text = cbTipoIVA.SelectedItem.gTipoRecargoEq
        Else
            TipoRecargoEq.Enabled = False
            TipoRecargoEq.Text = 0
        End If
        cambios = True
    End Sub


    Private Sub cbTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipo.SelectionChangeCommitted
        If cbTipo.SelectedIndex <> -1 Then
            iidTipoArticulo = cbTipo.SelectedItem.gidTipoArticulo
            DescuentoC.Text = FormatNumber(If(cbTipo.SelectedItem.gDescuento1, dtsFA.gDescuento, dtsFA.gDescuento2))
            Call IntroducirSubTiposArticulo()
            Call CargarArticulosC()
        End If
    End Sub

    Private Sub cbSubTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubTipo.SelectionChangeCommitted
        If cbSubTipo.SelectedIndex <> -1 And iidTipoArticulo > 0 Then
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



    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DescuentoC.Click, ProntoPago.Click, PrecioNeto.Click, PrecioTransporte.Click, ComisionLinea.Click, ComisionGeneral.Click
        sender.selectall()
    End Sub


    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged, DescuentoC.TextChanged, PrecioNeto.TextChanged, PVP.TextChanged, ComisionLinea.TextChanged, ComisionGeneral.TextChanged
        If semaforo Then
            If Cantidad.Text = "-" Then
            Else
                semaforo = False
                If Cantidad.Text = "" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0
                If DescuentoC.Text = "" Then DescuentoC.Text = 0
                If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
                If PVP.Text = "" Then PVP.Text = 0
                If DescuentoC.Text <> 0 Then  'Si hay descuento, ignoramos el precio neto
                    PrecioNeto.Text = FormatNumber((1 - DescuentoC.Text / 100) * PVP.Text, 2)
                Else
                    If PrecioNeto.Text = 0 Then PrecioNeto.Text = PVP.Text 'Si el precio neto=0, ponemos el PVP
                End If
                subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
                semaforo = True
            End If
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

    Private Sub ComisionLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComisionLinea.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(ComisionLinea.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter AndAlso GestionaComisiones Then
            If GuardarComision() = False Then MsgBox("Conceptos no editables en estado " & cbEstado.Text)
        End If
    End Sub


    Private Sub DescuentoC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DescuentoC.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(DescuentoC.Text, ",") Then
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


    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Cantidad.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Or Cantidad.Text = "0" Then
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

    Private Sub cbTipoIVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipoIVA.KeyPress, cbRetencion.KeyPress
        'emula el READ ONLY
        e.Handled = True
    End Sub

    Private Sub cbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCliente.KeyPress, cbCodCliente.KeyPress
        'emula el READ ONLY
        If ClienteSoloLectura Then e.Handled = True
    End Sub


    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Observaciones.TextChanged, RefCliente.TextChanged, cbRetencion.SelectedIndexChanged, cbCuenta.SelectedIndexChanged, cbContacto.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, ckRecargoEquivalencia.CheckedChanged
        cambios = True
    End Sub

    Private Sub TipoIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoIVA.SelectedIndexChanged
       
        cambios = True
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged, DiaPago1.TextChanged, DiaPago2.TextChanged, ProntoPago.TextChanged, PrecioTransporte.TextChanged
        If semaforo Then
            Call CalcularVencimientos()
            cambios = True
        End If
    End Sub

    Private Sub numDoc1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If numDoc1.Text <> "" And numDoc1.Text <> "VARIOS" Then
            Dim GG As New GestionAlbaran
            GG.SoloLectura = vSoloLectura
            GG.pnumAlbaran = numDoc1.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If

    End Sub

    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
         
        End If
    End Sub

    Private Sub cbPersona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPersona.SelectedIndexChanged
        If semaforo Then
            If iidCliente = 0 Or cbPersona.SelectedIndex = -1 Then
                ComisionGeneral.Text = 0
            Else
                ComisionGeneral.Text = FormatNumber(funcCM.Porcentaje(iidCliente, cbPersona.SelectedItem.itemdata))
            End If
            ComisionLinea.Text = ComisionGeneral.Text
        End If
    End Sub


#End Region





End Class