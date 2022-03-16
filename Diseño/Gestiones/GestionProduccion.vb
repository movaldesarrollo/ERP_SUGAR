Public Class GestionProduccion

    Private funcCP As New FuncionesConceptosProduccion
    Private funcAR As New FuncionesArticulos
    Private funcCL As New funcionesclientes
    Private funcES As New FuncionesEstados
    Private funcSE As New FuncionesSecciones
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcEC As New FuncionesEscandallos
    Private funcPE As New FuncionesPersonal
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcPD As New FuncionesPedidos
    Private funcSK As New FuncionesStock
    Private funcCEQ As New FuncionesConceptosEquiposProduccion
    Private funcCPE As New FuncionesConceptosPedidos
    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private indice As Integer
    Private iidProduccion As Long
    Private iidArticulo As Integer 'Artículo de la zona de búsqueda
    Private iidArticuloP As Integer 'Artículo de la zona de edición
    Private iidCliente As Integer
    Private sBusquedaDetalle As String
    Private sBusquedaGlobal As String
    Private semaforo As Boolean
    Private cambioFechasPedido As Boolean
    Private cambioFechasPrevistas As Boolean
    Private dtsAR As DatosArticulo 'Artículo seleccionado en la zona de Edicion
    Private dtsCP As DatosConceptoProduccion
    Private colorInactivo As Color
    Private Seccion1 As String
    Private idSeccion1 As Integer
    Private semanaActual As Byte
    Private columnaD, columnaG As Byte
    Private DireccionD, DireccionG As String
    Private OrdenD, OrdenG As String
    Private lvwColumnSorter As OrdenarLV
    'Identificadores de estado de EQUIPO:
    Private idEstadoAnulado As Integer
    Private idEstadoEnCurso As Integer
    Private idEstadoEspera As Integer
    Private idEstadoCompleto As Integer
    'Identificadores de estado de Conceptos de Producción
    Private idEstadoCPRecibido As Integer
    Private idEstadoCPParcial As Integer
    Private idEstadoCPAcabado As Integer
    Private idEstadoCPEnCurso As Integer
    Private idEstadoCPEspera As Integer
    Private idEstad
    Private ListaGlobal As List(Of DatosConceptoProduccion)
    Private menuContextual As Boolean
    Private cmParcial As ContextMenu
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property gidCliente() As Integer
        Get
            Return iidCliente
        End Get
        Set(ByVal value As Integer)
            iidCliente = value
        End Set
    End Property

    Public Property gnumPedido() As Integer
        Get
            Return numPedido.Text
        End Get
        Set(ByVal value As Integer)
            numPedido.Text = value
        End Set
    End Property

    Private Sub GestionProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Me.Height = desktopSize.Height - 50
        Me.Location = New Point(Me.Location.X, 0)
        lvConceptos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None)
        colorInactivo = Color.Gray
        'PERMISOS
        Dim funcP As New FuncionesPersonal
        bVerCliente.Enabled = funcP.Permiso(Inicio.vIdUsuario, "ConsultaCliente")
        bVerArticulo.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaSimpleArticulo") Or funcP.Permiso(Inicio.vIdUsuario, "BusquedaArticulo")
        vSoloLectura = vSoloLectura Or funcP.Parametro(Inicio.vIdUsuario, "GestionProduccion", "SOLO LECTURA")
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False
        semanaActual = DatePart(DateInterval.WeekOfYear, Now.Date)
        If semanaActual = 53 And DatePart(DateInterval.Weekday, Now.Date) < 7 Then semanaActual = 1
        semaforo = False
        'bProducir.Enabled = Not vSoloLectura
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        idSeccion1 = funcSE.idSeccion1
        Seccion1 = funcSE.Seccion(idSeccion1)
        DireccionD = "DESC"
        DireccionG = "DESC"
        columnaD = 0
        columnaG = 0
        OrdenG = "codArticulo"
        OrdenD = "numPedido DESC, IdProduccion "
        tpGlobal.Select()
        'rbGlobal.Checked = True
        Call limpiarFiltro()
        Call limpiarEdicion()
        Call IntroducirArticulos()
        'Call introducirResponsables()
        Call introducirClientes()
        Call IntroducirEstados()
        'Call IntroducirPedidos()
        Call IntroducirTipos()
        'Estados de Equipo
        idEstadoAnulado = funcES.EstadoAnulado("EQUIPO").gidEstado
        idEstadoEnCurso = funcES.EstadoEnCurso("EQUIPO").gidEstado
        idEstadoEspera = funcES.EstadoEspera("EQUIPO").gidEstado
        idEstadoCompleto = funcES.EstadoCompleto("EQUIPO").gidEstado
        'Estados de Concepto de producción
        idEstadoCPRecibido = funcES.EstadoEntregado("PRODUCCION").gidEstado
        idEstadoCPParcial = funcES.EstadoAutomatico("PRODUCCION").gidEstado
        idEstadoCPAcabado = funcES.EstadoCompleto("PRODUCCION").gidEstado
        idEstadoCPEnCurso = funcES.EstadoEnCurso("PRODUCCION").gidEstado
        idEstadoCPEspera = funcES.EstadoEspera("PRODUCCION").gidEstado
        If iidCliente <> 0 Then
            Dim dtsCL As datoscliente = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            cbCliente.Text = dtsCL.gnombrecomercial
        End If
        If iidArticulo <> 0 Then
            Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
            cbCodArticulo.Text = dts.gcodArticulo
            cbArticulo.Text = dts.gArticulo
        End If
        'If cbnumPedido.SelectedIndex <> -1 Or iidArticulo <> 0 Or iidCliente <> 0 Then

        cmParcial = New ContextMenu
        cmParcial.MenuItems.Add("Entrega parcial", New System.EventHandler(AddressOf Me.OnClickParcial))

        Call busqueda()
        'End If
        semaforo = True
    End Sub

    Protected Sub OnClickParcial(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Select Case sender.text
                Case "Entrega parcial"
                    'With lvConceptos.Items(indice)
                    Dim Acabados As Integer = lvConceptos.Items(indice).SubItems(5).Text
                    Dim Pedidos As Integer = lvConceptos.Items(indice).SubItems(4).Text
                    If Acabados = 0 Then
                        MsgBox("No hay equipos acabados")
                    Else
                        If Acabados < Pedidos Then

                            If MsgBox("¿Desea enviar a logística los equipos acabados para una entrega parcial?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                'Cambiar el estado del concepto de producción a PARCIAL
                                funcCP.CambiarEstado(lvConceptos.Items(indice).SubItems(0).Text, idEstadoCPParcial)
                                Dim dts As DatosConceptoProduccion = funcCP.Mostrar1(lvConceptos.Items(indice).SubItems(0).Text)
                                Call ActualizaLineaLV(dts)
                            End If
                        Else
                            MsgBox("Las producciones acabadas se envían automáticamente a logística.")
                        End If
                        'End With
                    End If
            End Select
        End If

    End Sub

#Region "INICIALIZACIÓN"


    Private Sub limpiarEdicion()
        cbArticuloProd.Text = ""
        cbArticuloProd.SelectedIndex = -1
        cbcodArticuloProd.Text = ""
        cbcodArticuloProd.SelectedIndex = -1
        rbProd3.Checked = True
        rbProd1.Checked = False
        rbProd2.Checked = False
        dtpFechaPrevista.Value = funcCP.FechaInicioTrabajo(3)
        Cantidad.Text = 0
      
        Observaciones.Text = ""
        iidArticuloP = 0
        iidProduccion = 0
        indice = -1
        Cantidad.ReadOnly = False
        cbVersion.Items.Clear()
        cbVersion.Text = ""
        cbVersion.SelectedIndex = -1
        dtsCP = New DatosConceptoProduccion
    End Sub

    Private Sub limpiarFiltro()
        cbCliente.SelectedIndex = -1
        cbCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        numPedido.Text = ""

        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        rbTodos.Checked = True
        rbFiltro1.Checked = False
        rbFiltro2.Checked = False
        rbFiltro3.Checked = False
        dtpFechaPedidoDesde.Value = funcPD.buscaPrimerDia
        dtpFechaPedidoHasta.Value = funcPD.buscaUltimoDia
        dtpFechaPrevistaDesde.Value = funcCP.buscaPrimerDia
        dtpFechaPrevistaHasta.Value = funcCP.buscaUltimoDia
        cambioFechasPedido = False
        cambioFechasPrevistas = False
    End Sub

    'Private Sub introducirResponsables()
    '    cbResponsable.Items.Clear()
    '    Dim lista As List(Of IDComboBox) = funcPE.ListarResponsablesProd
    '    For Each dts As IDComboBox In lista
    '        cbResponsable.Items.Add(dts)
    '    Next

    'End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub IntroducirArticulos()
        Select Case tbConceptos.SelectedTab.Name
            Case "tpGlobal"
                Call IntroducirArticulosGlobal()
            Case "tpDetalle"
                Call IntroducirArticulosDetalle()
        End Select
    End Sub

    Private Sub IntroducirArticulosDetalle()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbcodArticuloProd.Items.Clear()
        cbcodArticuloProd.Text = ""
        cbcodArticuloProd.SelectedIndex = -1
        cbArticuloProd.Items.Clear()
        cbArticuloProd.Text = ""
        cbArticuloProd.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)

        lista = funcAR.Listar("ESCANDALLO")

        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            cbArticuloProd.Items.Add(dts)
            If dts.Name1 <> "" Then
                cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
                cbcodArticuloProd.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
            End If
        Next
    End Sub

    Private Sub IntroducirArticulosGlobal()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)
        lista = funcAR.Listar("BASE")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub




    Private Sub IntroducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("PRODUCCION")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub

    'Private Sub IntroducirSecciones()
    '    cbTipo.Items.Clear()
    '    'cbSeccionProd.Items.Clear()
    '    Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(True)
    '    Dim dts As DatosSeccion
    '    For Each dts In lista
    '        cbTipo.Items.Add(dts)
    '        'cbSeccionProd.Items.Add(dts)
    '    Next
    '    'cbSeccionProd.Text = Seccion1
    'End Sub

    Private Sub IntroducirTipos()
        Dim funcT As New FuncionesTiposArticulo
        cbTipo.Items.Clear()
        Dim lista As List(Of DatosTipoArticulo) = funcT.Mostrar(0, True)
        For Each item As DatosTipoArticulo In lista
            cbTipo.Items.Add(item)
        Next
    End Sub


    'Private Sub IntroducirPedidos()
    '    cbnumPedido.Items.Clear()
    '    Dim lista As List(Of Integer) = funcCP.NumsPedido(Not ckVerInactivos.Checked)
    '    For Each item As Integer In lista
    '        cbnumPedido.Items.Add(item)
    '    Next
    'End Sub


#End Region

#Region "CARGAR DATOS"



    Private Sub CargarArticuloP()
        'Carga los datos de un artículo en la zona de edición
        If iidArticuloP > 0 Then
            dtsAR = funcAR.Mostrar1(iidArticuloP)
            cbcodArticuloProd.Text = dtsAR.gcodArticulo
            cbArticuloProd.Text = dtsAR.gArticulo
            lbUnidad.Text = dtsAR.gTipoUnidad
            'cbSeccionProd.Text = dtsAR.gSeccion
        End If
        If Cantidad.Text = "" Then Cantidad.Text = 0
        If Cantidad.Text = 0 Then Cantidad.Text = 1
    End Sub

    Private Sub CargarConcepto()
        'Carga los datos de un concepto de producción en la zona de edición
        If iidProduccion > 0 Then
            semaforo = False
            dtsCP = funcCP.Mostrar1(iidProduccion)
            dtsAR = funcAR.Mostrar1(dtsCP.gidArticulo)
            cbcodArticuloProd.Text = dtsCP.gcodArticulo
            cbArticuloProd.Text = dtsCP.gArticulo
            'cbSeccionProd.Text = dtsAR.gSeccion
            Select Case dtsCP.gPrioridad
                Case 1
                    rbProd1.Checked = True
                    rbProd2.Checked = False
                    rbProd3.Checked = False
                Case 2
                    rbProd1.Checked = False
                    rbProd2.Checked = True
                    rbProd3.Checked = False
                Case 3
                    rbProd1.Checked = False
                    rbProd2.Checked = False
                    rbProd3.Checked = True
            End Select
            If dtsCP.gnumPedido = 0 Then
                dtpFechaPrevista.Value = dtsCP.gFechaPrevista
                Cantidad.ReadOnly = False
            Else
                dtpFechaPrevista.Value = dtsCP.gFechaPrevista 'dtsCP.gFechaEntrega
                Cantidad.ReadOnly = True 'Si procede de un pedido, no podemos cambiar la cantidad
            End If
            Call CargarVersiones(dtsCP.gidArticulo)
            cbVersion.Text = dtsCP.gVersion
            Cantidad.Text = dtsCP.gCantidad
            Observaciones.Text = dtsCP.gObservaciones
            ' cbResponsable.Text = dtsCP.gPersona
        End If
        semaforo = True
    End Sub

    Private Sub CargarVersiones(ByVal iidArticulo)
        cbVersion.Items.Clear()
        If iidArticulo > 0 Then
            If funcAR.conVersiones(iidArticulo) Then
                cbVersion.Enabled = True
                Dim iidArticuloBase As Integer = funcEC.idArticuloBaseArticulo(iidArticulo)
                Dim lista As List(Of Integer)
                If iidArticuloBase > 0 Then
                    lista = funcAR.Versiones(iidArticuloBase)
                Else
                    lista = funcAR.Versiones(iidArticulo)
                End If


                For Each v As Integer In lista
                    If v > 0 Then cbVersion.Items.Add(v)
                Next
                If cbVersion.Items.Count > 0 Then
                    If cbVersion.Items.Count = 1 Then
                        cbVersion.Text = lista(0)
                    Else
                        cbVersion.Text = lista.Max()
                    End If
                End If
            Else
                cbVersion.Enabled = False
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

    Private Sub busqueda()


        Dim sBusqueda As String = ""
        sBusquedaDetalle = ""
        sBusquedaGlobal = ""

        
        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.NombreComercial like '%" & Replace(cbCliente.Text, "'", "''") & "%' "
        End If

        If cbCodCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.codCli like '" & cbCodCliente.Text & "%' "
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cambioFechasPedido Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), PE.fecha,103))  >= '" & dtpFechaPedidoDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PE.fecha,103))  <= '" & dtpFechaPedidoHasta.Value.Date & "' "
        End If

        If cambioFechasPrevistas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ((PE.numPedido >0 AND CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  >= '" & dtpFechaPrevistaDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  <= '" & dtpFechaPrevistaHasta.Value.Date & "') OR "
            sBusqueda = sBusqueda & " (PE.numPedido is null AND CONVERT(datetime,CONVERT(Char(10), CP.fechaPrevista,103))  >= '" & dtpFechaPrevistaDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), CP.fechaPrevista,103))  <= '" & dtpFechaPrevistaHasta.Value.Date & "'))  "
        End If

        If rbFiltro1.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 1 "
        End If
        If rbFiltro2.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 2 "
        End If
        If rbFiltro3.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 3 "
        End If
        If cbTipo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo
            'sBusqueda = sBusqueda & " CP.idProduccion in (select idProduccion from EquiposProduccion where idSeccion = " & cbTipo.SelectedItem.gidSeccion & ")"
        End If
        If numPedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PE.numPedido like '" & numPedido.Text & "%' "
        End If

        If ckVerInactivos.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Estados.Completo <> 1 " 'Para ver los que no están traspasados (no se han servido)
        End If

        sBusquedaDetalle = sBusqueda
        sBusquedaGlobal = sBusqueda



        If BusquedaLibre.Text <> "" Then

            sBusquedaDetalle = sBusquedaDetalle & IIf(sBusquedaDetalle = "", "", " AND ")
            sBusquedaDetalle = sBusquedaDetalle & " (AR.codArticulo like '%" & Replace(BusquedaLibre.Text, "'", "''") & "%' OR "
            sBusquedaDetalle = sBusquedaDetalle & " AR.Articulo like '%" & Replace(BusquedaLibre.Text, "'", "''") & "%' )"

            sBusquedaGlobal = sBusquedaGlobal & IIf(sBusquedaGlobal = "", "", " AND ")
            sBusquedaGlobal = sBusquedaGlobal & " (ARc.codArticulo like '%" & Replace(BusquedaLibre.Text, "'", "''") & "%' OR "
            sBusquedaGlobal = sBusquedaGlobal & " ARc.Articulo like '%" & Replace(BusquedaLibre.Text, "'", "''") & "%' )"

        End If

        If cbArticulo.SelectedIndex <> -1 Then
            sBusquedaDetalle = sBusquedaDetalle & IIf(sBusquedaDetalle = "", "", " AND ")
            sBusquedaDetalle = sBusquedaDetalle & " CP.idArticulo = " & cbArticulo.SelectedItem.itemdata

            sBusquedaGlobal = sBusquedaGlobal & IIf(sBusquedaGlobal = "", "", " AND ")
            sBusquedaGlobal = sBusquedaGlobal & " ARc.idArticulo = " & cbArticulo.SelectedItem.itemdata

        ElseIf cbArticulo.Text <> "" Then
            sBusquedaDetalle = sBusquedaDetalle & IIf(sBusquedaDetalle = "", "", " AND ")
            sBusquedaDetalle = sBusquedaDetalle & " AR.Articulo like '%" & Replace(cbArticulo.Text, "'", "''") & "%' "

            sBusquedaGlobal = sBusquedaGlobal & IIf(sBusquedaGlobal = "", "", " AND ")
            sBusquedaGlobal = sBusquedaGlobal & " ARc.Articulo like '%" & Replace(cbArticulo.Text, "'", "''") & "%' "

        End If

        If cbCodArticulo.Text <> "" And cbCodArticulo.SelectedIndex = -1 Then
            sBusquedaDetalle = sBusquedaDetalle & IIf(sBusquedaDetalle = "", "", " AND ")
            sBusquedaDetalle = sBusquedaDetalle & " AR.codArticulo like '" & cbCodArticulo.Text & "%' "

            sBusquedaGlobal = sBusquedaGlobal & IIf(sBusquedaGlobal = "", "", " AND ")
            sBusquedaGlobal = sBusquedaGlobal & " ARc.codArticulo like '" & cbCodArticulo.Text & "%' "

        End If


        Call ActualizarLV()



    End Sub

    Private Sub ActualizarLV()
        Select Case tbConceptos.SelectedTab.Name
            Case "tpGlobal"
                Call ActualizarLVGlobal()
            Case "tpDetalle"
                Call ActualizarLVDetalle()
        End Select
    End Sub

    Private Sub ActualizarLVDetalle()
        Try
            lvConceptos.Items.Clear()
            Dim lista As List(Of DatosConceptoProduccion)

            lista = funcCP.Busqueda(sBusquedaDetalle, OrdenD & " " & DireccionD) '" Prioridad, idProduccion ")
            menuContextual = False
            For Each dts As DatosConceptoProduccion In lista
                NuevaLineaLV(dts)
                If dts.gAcabados > 0 And dts.gAcabados < dts.gCantidad Then
                    menuContextual = True
                End If
            Next
            If menuContextual Then lvConceptos.ContextMenu = cmParcial
            Call CalculaTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ActualizarLVGlobal()
        Try
            lvConceptosGlobal.Items.Clear()
            lvwColumnSorter = New OrdenarLV()
            lvConceptosGlobal.ListViewItemSorter = lvwColumnSorter
            'Dim lista As List(Of DatosConceptoProduccion)
            ListaGlobal = funcEQ.MostrarProduccionSeparada(sBusquedaGlobal) 'funcCP.BusquedaGlobal(sBusqueda, " Prioridad, idProduccion ")
            Dim iidArticulo As Integer = 0
            Dim suma As Double = 0
            Dim sumaEstaSemana As Double = 0
            Dim sumaSemanaProxima As Double = 0
            Dim suma2Semanas As Double = 0
            Dim sumaMasSemanas As Double = 0
            Dim semanaPrevista As Byte
            Dim i As Integer = -1
            For Each dts As DatosConceptoProduccion In ListaGlobal
                'NuevaLineaLVGlobal(dts)

                If dts.gidArticulo = iidArticulo Then
                    semanaPrevista = DatePart(DateInterval.WeekOfYear, dts.gFechaPrevista)
                    i = EncuentraItem(dts.gidArticulo)
                    If i <> -1 Then
                        With lvConceptosGlobal.Items(i)
                            suma = .SubItems(4).Text
                            sumaEstaSemana = .SubItems(5).Text
                            sumaSemanaProxima = .SubItems(6).Text
                            suma2Semanas = .SubItems(7).Text
                            sumaMasSemanas = .SubItems(8).Text
                            suma = suma + dts.gCantidad
                            If dts.gFechaPrevista < Now.Date Or semanaPrevista <= semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                                sumaEstaSemana = sumaEstaSemana + dts.gCantidad
                            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                                sumaSemanaProxima = sumaSemanaProxima + dts.gCantidad
                            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                                suma2Semanas = suma2Semanas + dts.gCantidad
                            Else
                                sumaMasSemanas = sumaMasSemanas + dts.gCantidad
                            End If
                            .SubItems(4).Text = suma
                            .SubItems(5).Text = sumaEstaSemana
                            .SubItems(6).Text = sumaSemanaProxima
                            .SubItems(7).Text = suma2Semanas
                            .SubItems(8).Text = sumaMasSemanas
                        End With
                    End If
                Else
                    iidArticulo = dts.gidArticulo
                    With lvConceptosGlobal.Items.Add(dts.gidArticulo)
                        .SubItems.Add(dts.gTipoArticulo)
                        .SubItems.Add(dts.gcodArticulo)
                        .SubItems.Add(dts.gArticulo)
                        .SubItems.Add(dts.gCantidad)

                        sumaEstaSemana = 0
                        sumaSemanaProxima = 0
                        suma2Semanas = 0
                        sumaMasSemanas = 0
                        If dts.gFechaPrevista < Now.Date Or semanaPrevista <= semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                            sumaEstaSemana = sumaEstaSemana + dts.gCantidad
                        ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                            sumaSemanaProxima = sumaSemanaProxima + dts.gCantidad
                        ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                            suma2Semanas = suma2Semanas + dts.gCantidad
                        Else
                            sumaMasSemanas = sumaMasSemanas + dts.gCantidad
                        End If
                        .SubItems.Add(sumaEstaSemana)
                        .SubItems.Add(sumaSemanaProxima)
                        .SubItems.Add(suma2Semanas)
                        .SubItems.Add(sumaMasSemanas)

                    End With
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function EncuentraItem(ByVal Valor As Integer) As Integer
        For Each item As ListViewItem In lvConceptosGlobal.Items
            If item.Text = Valor Then Return item.Index
        Next
        Return -1
    End Function

    Private Sub CalculaTotal()
        Dim suma As Double = 0
        Dim sumaEstaSemana As Double = 0
        Dim sumaSemanaProxima As Double = 0
        Dim suma2Semanas As Double = 0
        Dim sumaMasSemanas As Double = 0
        'Dim semanaActual As Byte = DatePart(DateInterval.WeekOfYear, Now.Date)
        Dim semanaPrevista As Byte = 0
        For Each item As ListViewItem In lvConceptos.Items
            suma = suma + item.SubItems(4).Text

            semanaPrevista = DatePart(DateInterval.WeekOfYear, CDate(item.SubItems(10).Text))
            If CDate(item.SubItems(10).Text) < Now.Date Or semanaPrevista = semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                sumaEstaSemana = sumaEstaSemana + item.SubItems(4).Text
            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                sumaSemanaProxima = sumaSemanaProxima + item.SubItems(4).Text
            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                suma2Semanas = suma2Semanas + item.SubItems(4).Text
            Else
                sumaMasSemanas = sumaMasSemanas + item.SubItems(4).Text
            End If
        Next
        EstaSemana.Text = sumaEstaSemana
        SemanaProxima.Text = sumaSemanaProxima
        En2Semanas.Text = suma2Semanas
        EnMasSemanas.Text = sumaMasSemanas
        Total.Text = suma
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosConceptoProduccion)
        With lvConceptos.Items.Add(dts.gidProduccion)
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gCantidad)
            .SubItems.Add(dts.gAcabados)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(dts.gCliente)
            .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
            .SubItems.Add(dts.gFechaPedido)
            .SubItems.Add(dts.gFechaPrevista) 'If(dts.gnumPedido = 0, dts.gFechaPrevista, dts.gFechaEntrega))
            .SubItems.Add(dts.gPrioridad)
            .SubItems.Add(If(dts.gVersion = 0, "", CStr(dts.gVersion)))
            If dts.gBloqueado Then
                .ForeColor = colorInactivo
            Else
                If dts.gBloqueado Then
                    .ForeColor = colorInactivo
                Else
                    Select Case dts.gidEstado
                        Case idEstadoCPAcabado
                            .ForeColor = Color.Green
                        Case idEstadoCPParcial
                            .ForeColor = Color.Orange
                        Case idEstadoCPEspera
                            .ForeColor = Color.Black
                        Case idEstadoCPEnCurso
                            .ForeColor = Color.Orange
                    End Select
                    If dts.gPrioridad = 1 Then
                        .BackColor = Color.LightPink
                    End If

                End If


            End If
           
        End With
    End Sub

    Private Sub NuevaLineaLVGlobal(ByVal dts As DatosConceptoProduccion)
        With lvConceptosGlobal.Items.Add(dts.gidArticulo)
            .SubItems.Add(dts.gTipoArticulo)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gCantidad)
            'Obtenemos la lista de equipos no acabados de este artículo o que tengan este artículo como base.
            Dim lista As List(Of DatosEquipoProduccion) = funcEQ.Busqueda(If(sBusquedaGlobal = "", "", sBusquedaGlobal & " AND ") & "( EP.idArticulo = " & dts.gidArticulo & " OR idArticuloBase = " & dts.gidArticulo & ") AND EP.idEstado <> " & idEstadoCompleto, "", 0)
            Dim sumaEstaSemana As Double = 0
            Dim sumaSemanaProxima As Double = 0
            Dim suma2Semanas As Double = 0
            Dim sumaMasSemanas As Double = 0

            For Each dtsE As DatosEquipoProduccion In lista
                Dim semanaPrevista As Byte = DatePart(DateInterval.WeekOfYear, dtsE.gFechaPrevista)
                If dtsE.gFechaPrevista < Now.Date Or semanaPrevista <= semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                    sumaEstaSemana = sumaEstaSemana + 1
                ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                    sumaSemanaProxima = sumaSemanaProxima + 1
                ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                    suma2Semanas = suma2Semanas + 1
                Else
                    sumaMasSemanas = sumaMasSemanas + 1
                End If
            Next
            .SubItems.Add(sumaEstaSemana)
            .SubItems.Add(sumaSemanaProxima)
            .SubItems.Add(suma2Semanas)
            .SubItems.Add(sumaMasSemanas)

        End With
    End Sub



    Private Sub ActualizaLineaLV(ByVal dts As DatosConceptoProduccion)
        If indice > -1 Then
            With lvConceptos.Items(indice)
                .SubItems(0).Text = dts.gidProduccion
                .SubItems(1).Text = dts.gidArticulo
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gArticulo
                .SubItems(4).Text = dts.gCantidad
                .SubItems(5).Text = dts.gAcabados
                .SubItems(6).Text = dts.gEstado
                .SubItems(7).Text = dts.gCliente
                .SubItems(8).Text = (If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
                .SubItems(9).Text = If(dts.gnumPedido = 0, "", CStr(dts.gFechaPedido))
                .SubItems(10).Text = If(dts.gnumPedido = 0, dts.gFechaPrevista, dts.gFechaEntrega)
                .SubItems(11).Text = dts.gPrioridad
                .SubItems(12).Text = If(dts.gVersion = 0, "", CStr(dts.gVersion))
                If dts.gBloqueado Then
                    .ForeColor = colorInactivo
                Else
                    Select Case dts.gidEstado
                        Case idEstadoCPAcabado
                            .ForeColor = Color.Green
                        Case idEstadoCPParcial
                            .ForeColor = Color.Orange
                        Case idEstadoCPEspera
                            .ForeColor = Color.Black
                        Case idEstadoCPEnCurso
                            .ForeColor = Color.Orange
                    End Select
                    If dts.gPrioridad = 1 Then
                        .ForeColor = Color.LightPink
                    End If

                End If
                If dts.gAcabados > 0 And dts.gAcabados < dts.gCantidad Then
                    menuContextual = True
                    lvConceptos.ContextMenu = cmParcial
                End If

            End With
        End If
    End Sub


    Private Sub GuardarConcepto()
        Dim validar As Boolean = True
        'Verificamos que tengan escandallo creado para poder ser producidos
        Dim iidEscandallo As Integer
        iidEscandallo = funcEC.ExisteEscandallo(iidArticuloP)
        If iidEscandallo = 0 Then
            validar = False
            MsgBox("Este artículo no tienen escandallo definido, por tanto no se puede producir.")
        End If

        If cbArticuloProd.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbcodArticuloProd, "Se ha de seleccionar un artículo")
        End If
        If Not (rbProd1.Checked Or rbProd2.Checked Or rbProd3.Checked) Then
            validar = False
            ep1.SetError(rbProd3, "Se ha de indicar la prioridad")
        End If
       
        If Cantidad.Text = "" Then Cantidad.Text = 0
        If Cantidad.Text = 0 Then
            validar = False
            ep1.SetError(Cantidad, "Se ha de indicar la cantidad")
        End If
        If validar Then
            If Cantidad.Text = "" Then Cantidad.Text = 0
            dtsCP.gidProduccion = iidProduccion
            dtsCP.gidArticulo = cbArticuloProd.SelectedItem.itemdata
            dtsCP.gArticulo = cbArticuloProd.Text
            dtsCP.gcodArticulo = cbcodArticuloProd.Text
            dtsCP.gFechaPrevista = dtpFechaPrevista.Value.Date
            dtsCP.gObservaciones = Observaciones.Text
            dtsCP.gidPersona = 0 'cbResponsable.SelectedItem.itemdata
            'dtsCP.gidEscandallo = iidEscandallo
            If rbProd1.Checked Then dtsCP.gPrioridad = 1
            If rbProd2.Checked Then dtsCP.gPrioridad = 2
            If rbProd3.Checked Then dtsCP.gPrioridad = 3

            If funcAR.conVersiones(dtsCP.gidArticulo) Then
                dtsCP.gVersion = If(cbVersion.SelectedIndex = -1 Or Not IsNumeric(cbVersion.Text), 0, CInt(cbVersion.Text))
            Else
                dtsCP.gVersion = 0
            End If
            dtsCP.gidEscandallo = funcEC.ExisteEscandalloVersionUltima(dtsCP.gidArticulo, dtsCP.gVersion)

            If iidProduccion = 0 Then
                'Si se trata de una producción nueva
                dtsCP.gCantidad = Cantidad.Text
                dtsCP.gnumAlbaran = 0
                Dim dtsES As DatosEstado = funcES.EstadoEspera("PRODUCCION")
                dtsCP.gidEstado = dtsES.gidEstado
                dtsCP.gEstado = dtsES.gEstado
                dtsCP.gidCliente = 0
                dtsCP.gidArtCli = 0
                dtsCP.gidConceptoPedido = 0
                dtsCP.gFechaFin = dtsCP.gFechaPrevista
                dtsCP.gnumPedido = 0
                dtsCP.gTipoUnidad = lbUnidad.Text
                dtsCP.gFechaPedido = Now.Date

                iidProduccion = funcCP.insertar(dtsCP)

                If iidProduccion > 0 Then 'No se ha creado 
                    dtsCP.gidProduccion = iidProduccion
                    Call CrearEquipos(dtsCP)
                    Call NuevaLineaLV(dtsCP)
                End If
            Else
                'Modificamos una producción existente que puede ser manual o procedente de un pedido
                If dtsCP.gFechaFin < dtsCP.gFechaPrevista Then dtsCP.gFechaFin = dtsCP.gFechaPrevista
                If dtsCP.gCantidad < Cantidad.Text Then
                    ep2.SetError(Cantidad, "La cantidad no puede ser menor que la asignada")
                    dtsCP.gCantidad = Cantidad.Text
                End If

                funcCP.actualizar(dtsCP)
                Call CrearEquipos(dtsCP) 'Por si ha aumentado el número de equipos
                Call ActualizaLineaLV(dtsCP)

            End If
            Call CalculaTotal()
            Call limpiarEdicion()
        End If

    End Sub


    Public Sub DescuentaStock(ByVal Cant As Integer, ByVal iidEscandallo As Integer, ByVal iidProduccion As Integer)
        'Descuenta del stock los componentes del equipo, actúa de forma recursiva con los artículos que tienen escandallo
        Dim lista As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, True, 0)
        Dim dtsSK As DatosStock
        For Each dts As DatosConceptoEscandallo In lista
            If dts.gExisteEscandallo > 0 Then
                DescuentaStock(Cant * dts.gCantidad, dts.gExisteEscandallo, iidProduccion)
            Else
                dtsSK = New DatosStock
                dtsSK.gCantidad = -dts.gCantidad * Cant
                dtsSK.gcodMoneda = dtsAR.gcodMonedaC
                dtsSK.gFecha = Now
                dtsSK.gidAlmacen = 0
                dtsSK.gidArticulo = dts.gidArticulo
                dtsSK.gidArticuloProv = 0
                dtsSK.gidConceptoAlbaran = 0
                dtsSK.gidConceptoPedido = 0
                dtsSK.gidConceptoProv = 0
                dtsSK.gidLote = 0
                dtsSK.gidPersona1 = Inicio.vIdUsuario
                dtsSK.gidPersona2 = 0
                dtsSK.gidProduccion = iidProduccion
                dtsSK.gidUnidad = dts.gidTipoUnidad
                dtsSK.gMovimiento = ""
                dtsSK.gPrecio = dtsAR.gPrecioUnitarioC
                dtsSK.gidStock = funcSK.insertar(dtsSK)
            End If

        Next

    End Sub

    Private Sub CalculoFechaEntrega()
        Dim prioridad As Byte = 3
        If rbProd1.Checked Then
            prioridad = 1
        ElseIf rbProd2.Checked Then
            prioridad = 2
        End If
        If Cantidad.Text = "" Then Cantidad.Text = 0
        dtpFechaPrevista.Value = funcCP.FechaFinTrabajo(prioridad, funcCP.DiasTrabajo(prioridad, funcAR.Domestico_Industrial(iidArticuloP), Cantidad.Text))
    End Sub

    Private Sub CrearEquipos(ByVal dtsCP As DatosConceptoProduccion)
       
        Dim dtsEQ As DatosEquipoProduccion
        If Cantidad.Text = "" Then Cantidad.Text = 0
        Dim CantidadEquipos As Integer = funcEQ.Contador(dtsCP.gidProduccion)
        If Cantidad.Text - CantidadEquipos > 0 Then
            Dim texto As String = ""
            Dim tieneEscandallo As Boolean = True
            iidArticulo = dtsCP.gidArticulo
            Dim dtsAR As DatosArticulo = funcAR.Mostrar1(iidArticulo)
            If dtsAR.gEscandallo Then
                'Ahora verificaremos si tiene articulo base y en ese caso si este tiene escandallo
                Dim iidArticuloBase As Integer = funcEC.idArticuloBaseArticulo(dtsCP.gidArticulo)
                If iidArticuloBase > 0 Then
                    If funcEC.ExisteEscandalloRealmente(iidArticuloBase) Then
                    Else
                        'Tiene artículo base pero este no tiene escandallo
                        texto = "El artículo base no dispone de escandallo"
                        tieneEscandallo = False
                    End If
                Else
                    If funcEC.ExisteEscandalloRealmente(iidArticulo) Then
                    Else
                        'No existe el escandallo o no tiene componentes
                        texto = "No dispone de Escandallo"
                        tieneEscandallo = False
                    End If

                End If
            Else
                texto = "No marcado como Escandallo"
                tieneEscandallo = False
            End If

            If tieneEscandallo Then
                Dim VistaTaller As Boolean
                Dim VistaElectronica As Boolean
                If funcEC.idArticuloBase(dtsCP.gidEscandallo) = 0 Then
                    VistaTaller = funcEC.VistaTaller(dtsCP.gidArticulo)
                    VistaElectronica = funcEC.VistaElectronica(dtsCP.gidArticulo)
                Else
                    'Si el artículo tiene artículo base, lo usaremos para determinar las vistas
                    Dim iidArticuloBase As Integer = funcEC.idArticuloBase(dtsCP.gidArticulo)
                    VistaTaller = funcEC.VistaTaller(iidArticuloBase)
                    VistaElectronica = funcEC.VistaElectronica(iidArticuloBase)
                End If

                'hemos de buscar los componentes con producción separada

                Dim listaPS As List(Of DatosConceptoEquipoProduccion) = funcEQ.MostrarProduccionSeparada(dtsCP.gidArticulo, dtsCP.gVersion)

                If dtsAR.gProduccionSeparada Then
                    'En el caso de que el propio artículo ya sea de producción separada, lo añadimos a la lista para tratarlo como a los demás, incluida la generación de concepto 
                    Dim dtsPS As New DatosConceptoEquipoProduccion
                    dtsPS.gidConcepto = 0
                    dtsPS.gidEquipo = 0
                    dtsPS.gCantidad = 1
                    dtsPS.gidEstadoTaller = 0
                    dtsPS.gidEstadoElectronica = 0
                    dtsPS.gidEstado = 0
                    dtsPS.gidEtiqueta = 0
                    'Datos de otras tablas
                    dtsPS.gObservaciones = ""
                    dtsPS.gidProduccion = 0
                    dtsPS.gnumSerie = ""
                    dtsPS.gidArticulo = dtsCP.gidArticulo
                    dtsPS.gidEscandallo = 0
                    dtsPS.gcodArticulo = dtsAR.gcodArticulo
                    dtsPS.gArticulo = dtsAR.gArticulo
                    dtsPS.gEstado = ""
                    dtsPS.gEstadoTaller = ""
                    dtsPS.gEstadoElectronica = ""
                    dtsPS.gEtiqueta = ""
                    dtsPS.gVersion = dtsCP.gVersion
                    listaPS.Add(dtsPS)
                End If
                If listaPS.Count = 0 Then
                    'Si no tenemos ningún componente en la lista, lo añadiremos como equipo a producir y como concepto de Equipo
                    Dim dtsPS As New DatosConceptoEquipoProduccion
                    dtsPS.gidConcepto = 0
                    dtsPS.gidEquipo = 0
                    dtsPS.gCantidad = 1
                    dtsPS.gidEstadoTaller = 0
                    dtsPS.gidEstadoElectronica = 0
                    dtsPS.gidEstado = 0
                    dtsPS.gidEtiqueta = 0
                    'Datos de otras tablas
                    dtsPS.gObservaciones = ""
                    dtsPS.gidProduccion = 0
                    dtsPS.gnumSerie = ""
                    dtsPS.gidArticulo = dtsCP.gidArticulo
                    dtsPS.gidEscandallo = 0
                    dtsPS.gcodArticulo = dtsAR.gcodArticulo
                    dtsPS.gArticulo = dtsAR.gArticulo
                    dtsPS.gEstado = ""
                    dtsPS.gEstadoTaller = ""
                    dtsPS.gEstadoElectronica = ""
                    dtsPS.gEtiqueta = ""
                    dtsPS.gVersion = dtsCP.gVersion
                    listaPS.Add(dtsPS)
                End If


                If listaPS.Count = 0 Then
                    MsgBox("El artículo " & dtsAR.gcodArticulo & " - " & dtsAR.gArticulo & vbCrLf & "No se puede producir porque no dispone de escandallo o bien el artículo ni ninguno de sus componentes está marcado como PRODUCCIÓN SEPARADA.")
                Else
                    'Creamos los equipos
                    For x As Int16 = 1 To Cantidad.Text - CantidadEquipos
                        dtsEQ = New DatosEquipoProduccion
                        dtsEQ.gidProduccion = dtsCP.gidProduccion
                        dtsEQ.gnumSerie = 0 'funcEQ.nuevoNumSerie
                        dtsEQ.gidArticulo = dtsCP.gidArticulo
                        dtsEQ.gidEscandallo = dtsCP.gidEscandallo
                        dtsEQ.gFechaInicio = Now.Date
                        dtsEQ.gFechaFin = dtsCP.gFechaPrevista
                        dtsEQ.gidPersona = 0 'cbResponsable.SelectedItem.itemData
                        dtsEQ.gObservaciones = dtsCP.gObservaciones
                        dtsEQ.gVersion = dtsCP.gVersion
                        If VistaElectronica Then
                            dtsEQ.gidEstadoElectronica = idEstadoEspera
                        Else
                            dtsEQ.gidEstadoElectronica = idEstadoAnulado
                        End If
                        If VistaTaller Then
                            dtsEQ.gidEstadoTaller = idEstadoEspera
                        Else
                            dtsEQ.gidEstadoTaller = idEstadoAnulado
                        End If
                        If VistaElectronica Or VistaTaller Then
                            dtsEQ.gidEstado = idEstadoEspera
                        Else
                            dtsEQ.gidEstado = idEstadoAnulado
                        End If
                        'dtsEQ.gidSeccion = dtsCP.gidSeccion
                        dtsEQ.gidEquipo = funcEQ.insertar(dtsEQ)
                        Dim Vista As String
                        'Ahora creamos los componentes de producción separada
                        For Each dtsPS As DatosConceptoEquipoProduccion In listaPS
                            Vista = funcAR.Vista(dtsPS.gidArticulo)
                            If Vista = "ELECTRÓNICA" Then
                                dtsPS.gidEstadoElectronica = idEstadoEspera
                            Else
                                dtsPS.gidEstadoElectronica = idEstadoAnulado
                            End If
                            If Vista = "TALLER" Then
                                dtsPS.gidEstadoTaller = idEstadoEspera
                            Else
                                dtsPS.gidEstadoTaller = idEstadoAnulado
                            End If
                            If Vista = "ELECTRÓNICA" Or Vista = "TALLER" Then
                                dtsPS.gidEstado = idEstadoEspera
                            Else
                                dtsPS.gidEstado = idEstadoAnulado
                            End If
                            dtsPS.gidEquipo = dtsEQ.gidEquipo

                            dtsPS.gidEtiqueta = dtsEQ.gidEtiqueta  'Esto no debería ser, las etiquetas deberían venir del escandallo del artículo
                            For Cant = 1 To dtsPS.gCantidad 'Guardamos un concepto por cada unidad (aunque existe un campo Cantidad, lo ignoramos)
                                dtsPS.gidConcepto = funcCEQ.insertar(dtsPS)
                            Next

                        Next
                    Next
                    Call DescuentaStock(Cantidad.Text - CantidadEquipos, dtsCP.gidEscandallo, dtsCP.gidProduccion)
                    If dtsCP.gidEstado = funcES.EstadoEntregado("PRODUCCION").gidEstado Then
                        'Se la producción está sólo recibida y hemos creado algún equipo, pasamos al estado Espera (Preparado para producir)
                        dtsCP.gidEstado = funcES.EstadoEspera("PRODUCCION").gidEstado
                        dtsCP.gEstado = funcES.Estado(dtsCP.gidEstado)
                        funcCP.CambiarEstado(dtsCP.gidProduccion, dtsCP.gidEstado)
                    End If

                    MsgBox("Se han creado " & Cantidad.Text - CantidadEquipos & " nuevos equipos para producir")
                End If

            Else
                MsgBox(texto)
            End If
        End If

    End Sub


#End Region

#Region "BOTONES GENERALES"


    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click


        Dim GG As New busquedaCliente
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            iidCliente = GG.pidCliente
            Dim dtsCL As datoscliente = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            cbCliente.Text = dtsCL.gnombrecomercial
            cambios = True
        End If
    End Sub


    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        If cbArticulo.SelectedIndex <> -1 Then
            Dim iidArticuloP = cbArticulo.SelectedItem.itemdata
            Dim GG As New GestionArticulo
            GG.pidArticulo = iidArticuloP
            GG.pIndice = -1
            GG.ShowDialog()
            If GG.pidArticulo <> iidArticuloP Then
                iidArticuloP = GG.pidArticulo
                Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticuloP)
                cbCodArticulo.Text = dts.gcodArticulo
                cbArticulo.Text = dts.gArticulo
            End If

        End If
    End Sub

    Private Sub bBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticulo.Click
        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "ESCANDALLO"
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            Dim dts As DatosArticulo = funcAR.Mostrar1(GG.pidArticulo)
            cbCodArticulo.Text = dts.gcodArticulo
            cbArticulo.Text = dts.gArticulo
        End If
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then

            iidCliente = cbCliente.SelectedItem.itemdata
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = iidCliente
            GG.ShowDialog()
            Call introducirClientes()
            cbCliente.Text = cliente
            cbCodCliente.Text = codcli
            If cbCliente.SelectedIndex = -1 Then
                cbCliente.Text = ""
                cbCodCliente.Text = ""
            End If
        End If

    End Sub


    Private Sub bLimpiaFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiaFiltro.Click
        Call limpiarFiltro()
        Call busqueda()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Select Case tbConceptos.SelectedTab.Name
            Case "tpGlobal"
                Dim dt As New DataTable
                dt.Columns.Add("idArticulo")
                dt.Columns.Add("Tipo")
                dt.Columns.Add("codArticulo")
                dt.Columns.Add("Articulo")
                dt.Columns.Add("Cantidad")
                dt.Columns.Add("EstaSemana")
                dt.Columns.Add("SemanaProxima")
                dt.Columns.Add("En2Semanas")
                dt.Columns.Add("Mas2Semanas")

                For Each item As ListViewItem In lvConceptosGlobal.Items
                    Dim linea = dt.NewRow
                    linea(0) = item.SubItems(0).Text
                    linea(1) = item.SubItems(1).Text
                    linea(2) = item.SubItems(2).Text
                    linea(3) = item.SubItems(3).Text
                    linea(4) = item.SubItems(4).Text
                    linea(5) = item.SubItems(5).Text
                    linea(6) = item.SubItems(6).Text
                    linea(7) = item.SubItems(7).Text
                    linea(8) = item.SubItems(8).Text
                    dt.Rows.Add(linea)
                Next
                Dim GG As New InformeListadoProduccion
                GG.verInformeGlobal(dt)
                GG.ShowDialog()

            Case "tpDetalle"
                Dim GG As New InformeListadoProduccion
                GG.verInforme(sBusquedaDetalle, OrdenD & " " & DireccionD)
                GG.ShowDialog()
        End Select




    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If iidProduccion = 0 Then
            Call limpiarEdicion()
        Else
            If dtsCP.gnumPedido > 0 Then
                MsgBox("No se puede borrar porque corresponde con un pedido.")
            Else
                If funcEQ.EstaEnUso(iidProduccion) Then
                    MsgBox("No se puede eliminar porque hay equipos en producción.")
                Else
                    funcCP.borrar(iidProduccion)
                End If
            End If

        End If
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

   



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If cbArticuloProd.SelectedIndex <> -1 Then
            iidArticuloP = cbArticuloProd.SelectedItem.itemData
            Call GuardarConcepto()
        End If

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bTipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTipos.Click
        Dim Tipo As String = cbTipo.Text
        Dim GS As New gestionSecciones
        GS.SoloLectura = vSoloLectura
        GS.ShowDialog()
        Call IntroducirTipos()
        cbTipo.Text = Tipo
        If cbTipo.SelectedIndex = -1 Then cbTipo.Text = ""

    End Sub



    Private Sub bVistaTaller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVistaTaller.Click
        Dim GG As New DibujarVistaCompleta
        GG.pVista = "TALLER"
        GG.pTitulo = "VISTA TALLER"
        GG.pColumnasFijasIzquierda = 4
        GG.pFilasFijasArriba = 4
        GG.pFilasFijasAbajo = 2
        GG.pVerAgrupaciones = True
        GG.pMaximizar = True
        GG.Show()
    End Sub


    Private Sub bVistaElectronica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVistaElectronica.Click
        Dim GG As New DibujarVistaCompleta
        GG.pVista = "ELECTRÓNICA"
        GG.pTitulo = "VISTA ELECTRÓNICA"
        GG.pColumnasFijasIzquierda = 3
        GG.pFilasFijasArriba = 4
        GG.pFilasFijasAbajo = 2
        GG.pVerAgrupaciones = True
        GG.pMaximizar = True
        GG.Show()
    End Sub

#End Region

#Region "BOTONES Conceptos"


    Private Sub bBuscarArticuloProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloProd.Click
        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "ESCANDALLO"
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticuloP = GG.pidArticulo
            Call CargarArticuloP()
            Call CargarVersiones(iidArticuloP)
        End If
    End Sub


    Private Sub bVerArticuloProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloProv.Click
        If cbArticuloProd.SelectedIndex <> -1 Then
            iidArticuloP = cbArticuloProd.SelectedItem.itemdata
            Dim GG As New GestionArticulo
            GG.pidArticulo = iidArticuloP
            GG.pIndice = -1
            GG.ShowDialog()
            'If GG.pidArticulo <> iidArticuloP Then
            Call CargarArticuloP()
            'End If

        End If
    End Sub

    Private Sub bLimpiarProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiarProv.Click
        Call limpiarEdicion()
    End Sub


#End Region

#Region "EVENTOS"
    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPedido.TextChanged, cbCliente.TextChanged, BusquedaLibre.TextChanged, cbArticulo.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub cbCodArticuloProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticuloProd.SelectedIndexChanged
        If semaforo Then
            If cbcodArticuloProd.SelectedIndex <> -1 Then
                semaforo = False
                If Trim(cbcodArticuloProd.Text).Length > 0 Then
                    iidArticuloP = cbcodArticuloProd.SelectedItem.itemdata
                    cbArticuloProd.SelectedIndex = cbcodArticuloProd.SelectedIndex
                    dtsAR = funcAR.Mostrar1(iidArticuloP)
                    Call CargarVersiones(iidArticuloP)
                End If
                semaforo = True
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbArticuloProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloProd.SelectedIndexChanged
        If semaforo Then
            If cbArticuloProd.SelectedIndex <> -1 Then
                semaforo = False
                iidArticuloP = cbArticuloProd.SelectedItem.itemdata
                cbcodArticuloProd.SelectedIndex = cbArticuloProd.SelectedIndex
                dtsAR = funcAR.Mostrar1(iidArticuloP)
                Call CargarVersiones(iidArticuloP)
                semaforo = True
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbCodCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectedIndexChanged
        If semaforo Then
            semaforo = False
            If cbCodCliente.SelectedIndex <> -1 Then
                If Trim(cbCodCliente.Text).Length > 0 Then
                    iidCliente = cbCodCliente.SelectedItem.itemdata
                    cbCliente.Text = funcCL.campoCliente(iidCliente)
                End If
            Else
                cbCliente.Text = ""
                cbCodCliente.SelectedIndex = -1
            End If
            semaforo = True
            Call busqueda()
        End If

    End Sub

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged
        If semaforo Then
            If cbCliente.Text <> "" Then
                semaforo = False
                If cbCliente.SelectedIndex <> -1 Then
                    iidCliente = cbCliente.SelectedItem.itemdata
                    cbCodCliente.Text = funcCL.campoCodCli(iidCliente)
                Else
                    cbCodCliente.Text = ""
                    cbCodCliente.SelectedIndex = -1
                End If
                semaforo = True
            End If
            Call busqueda()
        End If
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedIndexChanged
        If semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                semaforo = False
                If Trim(cbCodArticulo.Text).Length > 0 Then
                    iidArticulo = cbCodArticulo.SelectedItem.itemdata
                    cbArticulo.Text = funcAR.Articulo(iidArticulo)
                End If
                Call busqueda()
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedIndexChanged
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                cbCodArticulo.Text = funcAR.codArticulo(iidArticulo)
                Call busqueda()
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        If semaforo Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)
            BuscarAhora = True
            retardo.Enabled = True
            semaforo = True
        End If

    End Sub

    Private Sub cbCodCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodCliente.TextChanged
        If semaforo Then
            semaforo = False
            cbCliente.Text = funcCL.campoCliente(cbCodCliente.Text)
            BuscarAhora = True
            retardo.Enabled = True
            semaforo = True
        End If

    End Sub

    Private Sub lvConceptos_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick
        If e.Column = columnaD Then
            If DireccionD = "ASC" Then
                DireccionD = "DESC"
            Else
                DireccionD = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 
        Select Case e.Column
            Case 0
                OrdenD = "idProduccion"
            Case 1
                OrdenD = "idArticulo"
            Case 2
                OrdenD = "codArticulo"
            Case 3
                OrdenD = "Articulo"
            Case 4
                OrdenD = "Cantidad"
            Case 5
                OrdenD = "Cantidad" 'La columna Acabados se calcula por programa, no se puede incluir en la sentencia sql
            Case 6
                OrdenD = "Estado"
            Case 7
                OrdenD = "Cliente"
            Case 8
                OrdenD = "numPedido"
            Case 9
                OrdenD = "FechaPedido"
            Case 10
                OrdenD = "case when PE.numPedido is null then FechaPrevista else FechaEntrega end"
            Case 11
                OrdenD = "Prioridad"
            Case Else
                OrdenD = "codArticulo"
        End Select
        columnaD = e.Column
        Call ActualizarLV()

    End Sub

    Private Sub lvConceptosGlobal_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptosGlobal.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = e.Column

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        lvConceptosGlobal.Sort()

    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click, lvConceptos.SelectedIndexChanged
        If lvConceptos.SelectedItems.Count > 0 Then

            indice = lvConceptos.SelectedIndices(0)
            iidProduccion = lvConceptos.Items(indice).Text
            Call CargarConcepto()

        End If

    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click
        sender.selectAll()
    End Sub

    Private Sub numPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numPedido.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Cantidad.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        'Si pulsamos INTRO, se guarda el concepto
        If KeyAscii = 13 Then Call GuardarConcepto()
    End Sub

    Private Sub cbnumPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVerInactivos.CheckedChanged, cbEstado.SelectionChangeCommitted, cbTipo.SelectedIndexChanged
        Call busqueda()
    End Sub

    Private Sub rbFiltro1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFiltro1.CheckedChanged, rbFiltro2.CheckedChanged, rbFiltro2.CheckedChanged, rbTodos.CheckedChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub tpGlobal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbConceptos.Selected
        If semaforo Then
            Dim Articulo As String = cbArticulo.Text
            Dim codArticulo As String = cbCodArticulo.Text
            Call IntroducirArticulos()
            If codArticulo = "" Then
                cbArticulo.Text = Articulo
            Else
                cbCodArticulo.Text = codArticulo
            End If
            cbCodArticulo.Text = ""
            cbCodArticulo.SelectedIndex = -1
            cbArticulo.Text = ""
            cbArticulo.SelectedIndex = -1
            Call busqueda()
        End If

    End Sub

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Dim iidProduccion As Long = lvConceptos.Items(indice).Text
            If funcCP.idEstado(iidProduccion) <> idEstadoCPRecibido Then
                Dim GG As New GestionEquiposProduccion
                GG.SoloLectura = vSoloLectura
                GG.pidArticulo = 0
                GG.pidArticuloBase = 0
                GG.pnumPedido = 0
                GG.pidProduccion = iidProduccion
                GG.ShowDialog()
                Call ActualizaLineaLV(funcCP.Mostrar1(iidProduccion))

            End If
        End If

    End Sub

    Private Sub lvConceptosGlobal_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptosGlobal.DoubleClick
        If lvConceptosGlobal.SelectedItems.Count > 0 Then
            Dim iidArticuloG As Integer = lvConceptosGlobal.SelectedItems(0).Text
            Dim lista As New List(Of Long)
            For Each dts As DatosConceptoProduccion In ListaGlobal
                'Hacemos una lista con todos los idEquipo los equipos de la lista global
                If dts.gidArticulo = iidArticuloG Then
                    lista.AddRange(funcEQ.Listar(dts.gidProduccion))
                End If
            Next
            Dim GG As New GestionEquiposProduccion
            GG.pidSEquipo = lista
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticuloG
            GG.pidArticuloBase = 0
            GG.pnumPedido = 0
            GG.pidProduccion = 0
            GG.ShowDialog()
        End If
    End Sub

    Private Sub rbPri1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbProd1.CheckedChanged, rbProd2.CheckedChanged, rbProd3.CheckedChanged
        'Cambia la prioridad, recalcular Fecha Entrega
        If semaforo Then
            Call CalculoFechaEntrega()
            cambios = True
        End If
    End Sub

    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged
        If semaforo Then
            CalculoFechaEntrega()

        End If
    End Sub

    Private Sub tpDetalle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDetalle.Enter
        bGuardar.Enabled = Not vSoloLectura
        'bProducir.Enabled = Not vSoloLectura
    End Sub

    Private Sub tpGlobal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpGlobal.Enter
        bGuardar.Enabled = False
        'bProducir.Enabled = False
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaPedidoHasta.KeyUp, dtpFechaPedidoDesde.KeyUp
        If semaforo Then
            If dtpFechaPedidoHasta.Value < dtpFechaPedidoDesde.Value Then dtpFechaPedidoHasta.Value = dtpFechaPedidoDesde.Value
            cambioFechasPedido = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaPedidoDesde.CloseUp, dtpFechaPedidoHasta.CloseUp
        If semaforo Then
            If dtpFechaPedidoHasta.Value < dtpFechaPedidoDesde.Value Then dtpFechaPedidoHasta.Value = dtpFechaPedidoDesde.Value
            cambioFechasPedido = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpHastaEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaPrevistaHasta.KeyUp, dtpFechaPrevistaDesde.KeyUp
        If semaforo Then
            If dtpFechaPrevistaHasta.Value < dtpFechaPrevistaDesde.Value Then dtpFechaPrevistaHasta.Value = dtpFechaPrevistaDesde.Value
            cambioFechasPrevistas = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesdeEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaPrevistaDesde.CloseUp, dtpFechaPrevistaHasta.CloseUp
        If semaforo Then
            If dtpFechaPrevistaHasta.Value < dtpFechaPrevistaDesde.Value Then dtpFechaPrevistaHasta.Value = dtpFechaPrevistaDesde.Value
            cambioFechasPrevistas = True
            Call busqueda()
        End If
    End Sub
#End Region

#End Region

End Class