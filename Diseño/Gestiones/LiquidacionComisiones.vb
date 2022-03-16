Public Class LiquidacionComisiones

    Private funcFA As New FuncionesFacturas
    Private funcCF As New FuncionesConceptosFacturas
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private funcLQ As New funcionesLiquidaciones
    Private sBusqueda As String
    Private Orden As String
    Private Direccion As String
    Private CambioFechas As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Private indice As Integer
    Private GestionaComisiones As Boolean
    Private columna As Integer
    Dim desktopsize As Size
    Private ep1 As New ErrorProvider
    Private vsoloLectura As Boolean

    Public Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Private Sub LiquidacionComisiones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        ckSeleccion.Location = New Point(lvDocumentos.Location.X + 6, lvDocumentos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        'PERMISOS 
        bLiquidar.Enabled = Not vsoloLectura
        VerClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        GestionaComisiones = funcPE.Permiso(Inicio.vIdUsuario, "AsignacionComisiones")
        bLiquidar.Visible = GestionaComisiones
        VerClientesPropios = VerClientesPropios Or Not GestionaComisiones 'No verá otros comerciales si no gestiona comisiones o ve sólo clientes propios
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink

        Call limpiar()
        Call IntroducirAños()
        Call IntroducirMeses()
        Call IntroducirTrimestres()
        Call IntroducirResponsables()
        Call introducirEstados()
        Call introducirClientes()
        Call Busqueda()
    End Sub

#Region "INICIALIZACIÓN"


    Private Sub limpiar()
        semaforo = False
        indice = -1
        If GestionaComisiones Then
            cbResponsable.Text = ""
            cbResponsable.SelectedIndex = -1
        End If
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = funcFA.buscaPrimerDia(0)
        dtpHasta.Value = Now.Date
        ckVerLiquidadas.Checked = False
        cbAño.Text = ""
        cbAño.SelectedIndex = -1
        cbMes.Text = ""
        cbMes.SelectedIndex = -1
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        CambioFechas = False
        Orden = ""
        Direccion = "ASC"
        For Each item As ListViewItem In lvDocumentos.SelectedItems
            item.Checked = False
        Next
        ckSeleccion.Checked = False
        Seleccionados.Text = ""
        TotalPendiente.Text = 0
        TotalSeleccionado.Text = ""
        Contador.Text = ""
        id.Text = ""
        ep1.Clear()
        semaforo = True
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


    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = dtpDesde.Value.Year To dtpHasta.Value.Year
            cbAño.Items.Add(Año)
        Next
    End Sub

    Private Sub IntroducirTrimestres()
        cbTrimestre.Items.Clear()
        cbTrimestre.Items.Add("TRIMESTRE 1")
        cbTrimestre.Items.Add("TRIMESTRE 2")
        cbTrimestre.Items.Add("TRIMESTRE 3")
        cbTrimestre.Items.Add("TRIMESTRE 4")
        cbTrimestre.SelectedIndex = -1

    End Sub

    Private Sub IntroducirMeses()
        cbMes.Items.Clear()
        For Mes = 1 To 12
            cbMes.Items.Add(UCase(MonthName(Mes)))
        Next
        cbMes.SelectedIndex = -1
    End Sub


    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
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



#End Region

#Region "CARGAR DATOS"




#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()

        sBusqueda = ""

        If id.Text <> "" Then
            If GestionaComisiones Then
                sBusqueda = sBusqueda & " DOC.idLiquidacion = " & id.Text
            ElseIf cbResponsable.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & " DOC.idLiquidacion = " & id.Text

                sBusqueda = sBusqueda & " AND DOC.idPersona = " & cbResponsable.SelectedItem.itemdata
            End If
        Else
            If cbCliente.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " Clientes.NombreComercial like '%" & Replace(cbCliente.Text, "'", "''") & "%' "
            End If

            If cbResponsable.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " DOC.idPersona = " & cbResponsable.SelectedItem.itemdata
            End If

            If cbEstado.SelectedIndex = -1 Then
                'sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                'sBusqueda = sBusqueda & " (Estados.Espera = 1 OR Estados.Automatico = 1) "
            Else
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
            End If

            If CambioFechas Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.Fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.Fecha,103))  <= '" & dtpHasta.Value.Date & "' "
            End If

            If IsNumeric(cbAño.Text) Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " Year(DOC.Fecha)= " & cbAño.Text
            End If
            If cbMes.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " Month(DOC.Fecha)= " & cbMes.SelectedIndex + 1
            End If

            If cbTrimestre.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  Month(DOC.Fecha)in "
                Select Case cbTrimestre.SelectedIndex
                    Case 0 '1T
                        sBusqueda = sBusqueda & " (1,2,3) "
                    Case 1 '2T
                        sBusqueda = sBusqueda & " (4,5,6) "
                    Case 2 '3T
                        sBusqueda = sBusqueda & " (7,8,9) "
                    Case 3 '4T
                        sBusqueda = sBusqueda & " (10,11,12) "
                End Select
            End If

            If ckVerLiquidadas.Checked = False Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ( DOC.idLiquidacion is null or DOC.idLiquidacion = 0 )"
            End If
        End If

        Call ActualizarLV()



    End Sub

    Private Sub ActualizarLV()
        semaforo = False
        Dim lista As List(Of datosFacturaComision) = funcFA.BusquedaLiquidacion(sBusqueda, Orden)
        Dim sumaPendiente As Double
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        Dim sumaBase As Double = 0
        lvDocumentos.Items.Clear()
        For Each dts As datosFacturaComision In lista
            Call NuevaLineaLV(dts)
            If dts.gLiquidada = False Then
                If dts.gcodMoneda = "EU" Then
                    sumaPendiente = sumaPendiente + dts.gImporteComision
                    sumaBase = sumaBase + dts.gBase
                Else
                    sumaPendiente = sumaPendiente + funcMO.Cambio(dts.gImporteComision, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    sumaBase = sumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                End If
            End If
        Next
        TotalPendiente.Text = FormatNumber(sumaPendiente, 2)
        lbCambio.Text = "CAMBIO " & FechaCambioG
        lbCambio.Visible = AvisoG
        Contador.Text = lvDocumentos.Items.Count
        TotalSeleccionado.Text = ""
        Seleccionados.Text = ""
        BaseSeleccionado.Text = ""
        TotalBase.Text = FormatNumber(sumaBase, 2)
        semaforo = True
    End Sub


    Private Sub NuevaLineaLV(ByVal dts As datosFacturaComision)
        With lvDocumentos.Items.Add(" ")
            .SubItems.Add(dts.gnumFactura)
            .SubItems.Add(dts.gFechaFactura)
            .SubItems.Add(dts.gCliente)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
            .SubItems.Add(dts.gComercial)
            .SubItems.Add(dts.gComisiones)
            If dts.gImporteComision = 0 And Not dts.gLiquidada Then
                .SubItems.Add("")
            Else
                .SubItems.Add(FormatNumber(dts.gImporteComision, 2) & dts.gSimbolo)
            End If

            If dts.gLiquidada Then
                .SubItems.Add(dts.gFechaLiquidacion)
                .SubItems.Add(dts.gidLiquidacion)
                .ForeColor = Color.Gray
            Else
                .SubItems.Add("")
                .SubItems.Add("")
                .ForeColor = SystemColors.WindowText
            End If

        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As datosFacturaComision)
        semaforo = False
        With lvDocumentos.Items(indice)
            .SubItems(1).Text = dts.gnumFactura
            .SubItems(2).Text = dts.gFechaFactura
            .SubItems(3).Text = dts.gCliente
            .SubItems(4).Text = dts.gEstado
            .SubItems(5).Text = FormatNumber(dts.gBase, 2) & dts.gSimbolo
            .SubItems(6).Text = dts.gComercial
            .SubItems(7).Text = dts.gComisiones
            If dts.gImporteComision = 0 And Not dts.gLiquidada Then
                .SubItems(8).Text = ""
            Else
                .SubItems(8).Text = FormatNumber(dts.gImporteComision, 2) & dts.gSimbolo
            End If
            If dts.gLiquidada Then
                .SubItems(9).Text = dts.gFechaLiquidacion
                .SubItems(10).Text = dts.gidLiquidacion

                .ForeColor = Color.Gray
            Else
                .SubItems(9).Text = ""
                .SubItems(10).Text = ""
                .ForeColor = SystemColors.WindowText
            End If

        End With
        semaforo = True
    End Sub




    Private Function Liquidar() As Integer
        Dim inumFactura As Integer
        If Not IsNumeric(TotalSeleccionado.Text) Then TotalSeleccionado.Text = 0
        Dim iidLiquidacion As Integer = funcLQ.insertar(New DatosLiquidacion(Now.Date, cbResponsable.SelectedItem.itemdata, TotalSeleccionado.Text))
        Dim dts As datosFacturaComision
        For Each item As ListViewItem In lvDocumentos.CheckedItems
            inumFactura = item.SubItems(1).Text
            funcFA.LiquidarComisiones(inumFactura, iidLiquidacion)
            dts = funcFA.Mostrar1FacturaComision(inumFactura)
            indice = item.Index
            Call ActualizarLineaLV(dts)
        Next
        Return iidLiquidacion
    End Function


    Private Sub CalcularTotales()
        Try

      
            semaforo = False
            Dim dts As datosFacturaComision
            Dim sumaPendiente As Double
            Dim sumaSeleccionado As Double
            Dim sumaBase As Double = 0
            Dim sumaBaseSeleccionado As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambio As Date = Now.Date
            Dim FechaCambioG As Date = Now.Date
            For Each item As ListViewItem In lvDocumentos.Items
                dts = funcFA.Mostrar1FacturaComision(item.SubItems(1).Text)

                If dts.gcodMoneda = "EU" Then
                    If Not dts.gLiquidada Then sumaPendiente = sumaPendiente + dts.gImporteComision
                    sumaBase = sumaBase + dts.gBase
                    If item.Checked Then
                        sumaSeleccionado = sumaSeleccionado + dts.gImporteComision
                        sumaBaseSeleccionado = sumaBaseSeleccionado + dts.gBase
                    End If

                Else
                    If Not dts.gLiquidada Then sumaPendiente = sumaPendiente + funcMO.Cambio(dts.gImporteComision, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    sumaBase = sumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                    If item.Checked Then
                        sumaSeleccionado = sumaSeleccionado + funcMO.Cambio(dts.gImporteComision, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        sumaBaseSeleccionado = sumaBaseSeleccionado + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End If

            Next
            TotalPendiente.Text = FormatNumber(sumaPendiente, 2)
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
            Contador.Text = lvDocumentos.Items.Count
            Seleccionados.Text = lvDocumentos.CheckedItems.Count
            TotalSeleccionado.Text = FormatNumber(sumaSeleccionado, 2)
            TotalBase.Text = FormatNumber(sumaBase, 2)
            BaseSeleccionado.Text = FormatNumber(sumaBaseSeleccionado, 2)
            semaforo = True
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub


#End Region

#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
        Call Busqueda()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If id.Text = "" Then
            Dim GG As New InformeListadoComisiones
            GG.verInforme(sBusqueda, Orden, TotalPendiente.Text, TotalBase.Text)
            GG.ShowDialog()
        Else
            Dim GG As New InformeListadoLiquidacionComisiones

            For Each item As ListViewItem In lvDocumentos.Items

            Next
            GG.verInforme(id.Text, TotalBase.Text)
            GG.ShowDialog()
        End If


    End Sub

    Private Sub bLiquidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLiquidar.Click
        ep1.Clear()
        Dim validar = True
        If lvDocumentos.CheckedItems.Count = 0 Then
            validar = False
            MsgBox("No se ha seleccionado ninguna factura para liquidar")
        End If
        If cbResponsable.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbResponsable, "Se ha de seleccionar el comercial")
        End If

        If validar Then
          
            If MsgBox("¿Liquidar las comisiones de las " & Seleccionados.Text & " facturas seleccionadas?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim iidLiquidacion As Integer = Liquidar()
                Call CalcularTotales()
                If MsgBox("¿Imprimir listado de liquidación?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim GG As New InformeListadoLiquidacionComisiones
                    GG.verInforme(iidLiquidacion, BaseSeleccionado.Text)
                    GG.ShowDialog()
                End If
            End If

        End If
    End Sub



#End Region

#Region "EVENTOS"

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvDocumentos.Items
                item.Checked = ckSeleccion.Checked And item.SubItems(9).Text = ""
            Next
            'Seleccionados.Text = lvDocumentos.CheckedItems.Count
            Seleccionados.Text = ""
            TotalSeleccionado.Text = ""
            Application.DoEvents()
            Call CalcularTotales()
            semaforo = True
        End If

    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvDocumentos.ItemChecked
        If semaforo Then
            If e.Item.SubItems(9).Text <> "" Then 'No liquidada
                e.Item.Checked = False
            Else
                'Añadir o restar el importe de la linea seleccionada al totalizador
                Dim Aviso As Boolean = False
                Dim FechaCambio As Date = Now.Date
                ' Dim importe As Double = funcFA.ImporteComisiones(e.Item.SubItems(1).Text)
                Dim dts As datosFacturaComision = funcFA.Mostrar1FacturaComision(e.Item.SubItems(1).Text)
                'Dim codMoneda As String = funcFA.codMoneda(e.Item.SubItems(1).Text)
                Dim Importe As Double = dts.gImporteComision
                Dim Base As Double = dts.gBase
                If dts.gcodMoneda <> "EU" Then
                    Importe = funcMO.Cambio(Importe, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    Base = funcMO.Cambio(Base, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                End If
                If TotalSeleccionado.Text = "" Then TotalSeleccionado.Text = 0
                If BaseSeleccionado.Text = "" Then BaseSeleccionado.Text = 0
                If e.Item.Checked Then
                    TotalSeleccionado.Text = FormatNumber(TotalSeleccionado.Text + Importe, 2)
                    BaseSeleccionado.Text = FormatNumber(BaseSeleccionado.Text + dts.gBase, 2)
                Else
                    TotalSeleccionado.Text = FormatNumber(TotalSeleccionado.Text - Importe, 2)
                    BaseSeleccionado.Text = FormatNumber(BaseSeleccionado.Text - Base, 2)
                End If
                lbCambio.Text = "CAMBIO " & FechaCambio
                lbCambio.Visible = Aviso
            End If
            Dim cont As Integer = lvDocumentos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvDocumentos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
            Seleccionados.Text = lvDocumentos.CheckedItems.Count
        End If

    End Sub

    Private Sub Cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVerLiquidadas.CheckedChanged, cbResponsable.SelectedIndexChanged, _
   cbCliente.SelectedIndexChanged, cbEstado.SelectedIndexChanged, cbAño.TextChanged, cbMes.SelectedIndexChanged, cbTrimestre.SelectedIndexChanged, id.TextChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub lvDocumentos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0, 1
                Orden = "DOC.numFactura"
            Case 2
                Orden = "DOC.Fecha"
            Case 3
                Orden = "Cliente"
            Case 4
                Orden = "Estados.Estado"
            Case 5
                Orden = "Base"
            Case 6
                Orden = "Comercial"
            Case 8
                Orden = "ImporteComision"
            Case 9
                Orden = "FechaLiquidacion"
            Case 10
                Orden = "DOC.idLiquidacion"
            Case Else

                Orden = ""
        End Select
        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Dim GP As New GestionFactura1
            GP.pnumFactura = lvDocumentos.Items(indice).SubItems(1).Text

            GP.SoloLectura = vsoloLectura
            GP.pIndice = 0
            GP.ShowDialog()
            If GP.pnumFactura > 0 Then
                Dim dts As datosFacturaComision = funcFA.Mostrar1FacturaComision(GP.pnumFactura)
                Call ActualizarLineaLV(dts)
                
                Call CalcularTotales()

            End If
            lvDocumentos.EnsureVisible(indice)
        End If
    End Sub

    Private Sub id_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles id.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub
#End Region

#End Region

End Class