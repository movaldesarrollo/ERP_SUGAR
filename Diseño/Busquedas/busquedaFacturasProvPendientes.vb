
Public Class busquedaFacturasProvPendientes

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private iidFactura As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesFacturasProv
    Private funcPE As New FuncionesPersonal
    Private funcPR As New funcionesProveedores
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private funcVE As New FuncionesVencimientosProv
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Facturas As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean

    Private EstadoParcial As DatosEstado
    Private EstadoPendiente As DatosEstado
    Private EstadoDevuelto As DatosEstado
    Dim SumaBase As Double = 0
    Dim SumaIVA As Double = 0
    Dim SumaRE As Double = 0
    Dim SumaRetencion As Double = 0
    Dim SumaTotal As Double = 0
    Dim SumaPendiente As Double = 0
    Dim Aviso As Boolean = False
    Dim AvisoG As Boolean = False
    Dim FechaCambio As Date = Now.Date
    Dim FechaCambioG As Date = Now.Date

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Property pidFactura() As Integer
        Get
            Return iidFactura
        End Get
        Set(ByVal value As Integer)
            iidFactura = value

        End Set
    End Property

    Property pModo() As String
        Get
            Return modo
        End Get
        Set(ByVal value As String)
            modo = value
        End Set
    End Property

    Private Sub busquedaFacturasProvPendientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        EstadoDevuelto = funcES.EstadoFacturaProv("DEVUELTA")
        EstadoParcial = funcES.EstadoFacturaProv("PARCIAL")
        EstadoPendiente = funcES.EstadoFacturaProv("PENDIENTE")
        colorInactivo = Color.Gray
        colorCabecera = Color.Red
        If desktopSize.Height < 1000 Then
            Me.Height = desktopSize.Height - 50
        End If

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal

        Call limpiar()
        direccion = "ASC"
        semaforo = False
        Facturas = New List(Of Integer)
        Call IntroducirResponsables()
        Call introducirProveedors()
        Call introducirEstados()
        Call IntroducirMeses()
        Call IntroducirTrimestres()
        semaforo = True
        Call busqueda()
    End Sub

#Region "INICIALIZACIÓN"



    Private Sub limpiar()
        semaforo = False

        cbResponsable.Text = ""
        cbResponsable.SelectedIndex = -1
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = funcVE.buscaPrimerDiaVencimientoPendiente(0)
        dtpHasta.Value = funcVE.buscaUltimoDiaVencimientoPendiente(0)
        Call IntroducirAños()
        ckVerSoloCaducados.Checked = False
        cbAño.Text = ""
        cbAño.SelectedIndex = -1
        cbMes.Text = ""
        cbMes.SelectedIndex = -1
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        cambioFechas = False
        Orden = ""
        direccion = "ASC"
        semaforo = True
    End Sub


    Private Sub IntroducirResponsables()
        'Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.Listar

        For Each item As IDComboBox In lista
            cbResponsable.Items.Add(item)
        Next
        cbResponsable.SelectedIndex = -1


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


    Private Sub introducirProveedors()
        cbProveedor.Items.Clear()
        Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
        For Each dts As datosProveedor In lista
            cbProveedor.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidProveedor))
        Next
    End Sub



    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("FacturaProv")
        For Each dts As DatosEstado In lista
            If dts.gEspera Or dts.gAutomatico Then 'Estados PENDIENTE, PARCIAL y DEVUELTA
                cbEstado.Items.Add(dts)
            End If
        Next

    End Sub



#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()


        sBusqueda = ""


        If cbProveedor.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.NombreFiscal like '%" & Replace(cbProveedor.Text, "'", "''") & "%' "
        End If


        If cbResponsable.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idpersona = " & cbResponsable.SelectedItem.itemdata
        End If

        If cbEstado.SelectedIndex = -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (Estados.Espera = 1 OR Estados.Automatico = 1) "
        Else
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in(select distinct idFactura from VencimientosProv where CONVERT(datetime,CONVERT(Char(10), Vencimiento,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Vencimiento,103))  <= '" & dtpHasta.Value.Date & "') "
        End If

        If IsNumeric(cbAño.Text) Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in(select  idFactura from VencimientosProv where Year(Vencimiento)= " & cbAño.Text & ") "
        End If
        If cbMes.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in(select  idFactura from VencimientosProv where Month(Vencimiento)= " & cbMes.SelectedIndex + 1 & ") "
        End If

        If cbTrimestre.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.IdFactura in(select IdFactura from VencimientosProv where Month(Vencimiento)in "
            Select Case cbTrimestre.SelectedIndex
                Case 0 '1T
                    sBusqueda = sBusqueda & " (1,2,3)) "
                Case 1 '2T
                    sBusqueda = sBusqueda & " (4,5,6)) "
                Case 2 '3T
                    sBusqueda = sBusqueda & " (7,8,9)) "
                Case 3 '4T
                    sBusqueda = sBusqueda & " (10,11,12)) "
            End Select
        End If


        If ckVerSoloCaducados.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ( select COUNT(idVencimiento) from VencimientosProv where idFactura = DOC.idFactura and  Vencimiento < GETdate() and (Pagado = 0 or Devuelto = 1))>0"
        End If


        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Facturas.Clear()
            SumaBase = 0
            SumaIVA = 0
            SumaRE = 0
            SumaRetencion = 0
            SumaTotal = 0
            SumaPendiente = 0
            Aviso = False
            AvisoG = False
            FechaCambio = Now.Date
            FechaCambioG = Now.Date
            Dim lista As List(Of DatosFacturaProv) = funcOF.Busqueda(sBusqueda, Orden)
            For Each dts As DatosFacturaProv In lista
                Facturas.Add(dts.gidFactura)
                Call NuevaLineaLV(dts)
            Next
            Contador.Text = lvDocumentos.Items.Count
            Total.Text = FormatNumber(SumaPendiente, 2)
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosFacturaProv)
        With lvDocumentos.Items.Add(dts.gnumFactura)
            .SubItems.Add(dts.gProveedor)
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gPendiente, 2) & dts.gSimbolo)
            .SubItems.Add(If(dts.gPrimerVencimientoNoPagado = CDate("1-1-1900"), "", CStr(dts.gPrimerVencimientoNoPagado)))
            .SubItems.Add(dts.gidFactura)
            Select Case dts.gidEstado
                Case EstadoDevuelto.gidEstado
                    .ForeColor = Color.Red
                Case EstadoParcial.gidEstado
                    .ForeColor = Color.DarkOrange
                Case Else
                    .ForeColor = Color.Black
            End Select
            If funcVE.VencimientosCaducados(dts.gidFactura) > 0 Then .ForeColor = Color.Red
            If dts.gcodMoneda = "EU" Then
                SumaPendiente = SumaPendiente + dts.gPendiente
                SumaTotal = SumaTotal + dts.gTotal
                SumaIVA = SumaIVA + dts.gTotalIVA
                SumaRE = SumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
                SumaRetencion = SumaRetencion + dts.gRetencion
                SumaBase = SumaBase + dts.gBase
            Else
                SumaTotal = SumaTotal + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaPendiente = SumaPendiente + funcMO.Cambio(dts.gPendiente, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaRE = SumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
                SumaRetencion = SumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
            End If
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal iidFactura As Integer)
        Dim dts As DatosFacturaProv = funcOF.Mostrar1(iidFactura)
        With lvDocumentos.Items(indice)
            .SubItems(1).Text = dts.gProveedor
            .SubItems(2).Text = dts.gFecha
            .SubItems(3).Text = dts.gEstado
            .SubItems(4).Text = FormatNumber(dts.gTotal, 2) & dts.gSimbolo
            .SubItems(5).Text = FormatNumber(dts.gPendiente, 2) & dts.gSimbolo
            .SubItems(6).Text = If(dts.gPrimerVencimientoNoPagado = CDate("1-1-1900"), "", CStr(dts.gPrimerVencimientoNoPagado))
            .SubItems(7).Text = dts.gidFactura
            Select Case dts.gidEstado
                Case EstadoDevuelto.gidEstado
                    .ForeColor = Color.Red
                Case EstadoParcial.gidEstado
                    .ForeColor = Color.DarkOrange
                Case Else
                    .ForeColor = Color.Black
            End Select
            If funcVE.VencimientosCaducados(dts.gidFactura) > 0 Then .ForeColor = Color.Red
        End With
    End Sub

    Private Sub RecalcularTotales()
        SumaBase = 0
        SumaIVA = 0
        SumaRE = 0
        SumaRetencion = 0
        SumaTotal = 0
        SumaPendiente = 0
        Aviso = False
        AvisoG = False
        FechaCambio = Now.Date
        FechaCambioG = Now.Date
        Dim lista As List(Of DatosFacturaProv) = funcOF.Busqueda(sBusqueda, Orden)
        For Each dts As DatosFacturaProv In lista
            If dts.gcodMoneda = "EU" Then
                SumaPendiente = SumaPendiente + dts.gPendiente
                SumaTotal = SumaTotal + dts.gTotal
                SumaIVA = SumaIVA + dts.gTotalIVA
                SumaRE = SumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
                SumaRetencion = SumaRetencion + dts.gRetencion
                SumaBase = SumaBase + dts.gBase
            Else
                SumaTotal = SumaTotal + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaPendiente = SumaPendiente + funcMO.Cambio(dts.gPendiente, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                SumaRE = SumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
                SumaRetencion = SumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
            End If
        Next
        Contador.Text = lvDocumentos.Items.Count
        Total.Text = FormatNumber(SumaPendiente, 2)
        lbCambio.Text = "CAMBIO " & FechaCambioG
        lbCambio.Visible = AvisoG
    End Sub


#End Region

#Region "BOTONES GENERALES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
        Call busqueda()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionFacturaProv
        GG.SoloLectura = vsoloLectura
        GG.pidFactura = 0
        GG.ShowDialog()
        If GG.pidFactura > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoFacturasProveedorPtes
        GG.verInforme(sBusqueda, Orden, SumaTotal, SumaBase, SumaIVA, SumaRE, SumaRetencion, Total.Text)
        GG.ShowDialog()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then

            indice = lvDocumentos.SelectedIndices(0)

            If modo = "B" Then
                Me.Close()
            Else
                Dim GP As New GestionFacturaProv
                GP.pidFactura = lvDocumentos.SelectedItems(0).SubItems(7).Text

                GP.pFacturas = Facturas
                GP.SoloLectura = vsoloLectura
                GP.pIndice = indice
                GP.ShowDialog()
                Call ActualizarLineaLV(GP.pidFactura)
                Call RecalcularTotales()

                'Call ActualizarLV()
                'lvDocumentos.EnsureVisible(indice)
            End If


            'Call cerrarformulario()
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 842
        Me.Height = If(Me.Height < 300, 300, Me.Height)
        'lvDocumentos.Height = Me.Height - 224
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVerSoloCaducados.CheckedChanged, cbResponsable.SelectedIndexChanged, _
    cbProveedor.SelectedIndexChanged, cbEstado.SelectedIndexChanged, cbAño.TextChanged, cbMes.SelectedIndexChanged, cbTrimestre.SelectedIndexChanged
        If semaforo Then Call busqueda()
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
            Case 0
                Orden = "DOC.idFactura"
            Case 1
                Orden = "Proveedor"
            Case 2
                Orden = "DOC.Fecha"
            Case 3
                Orden = "Estados.Estado"
            Case 4
                Orden = "Total"
            Case 5
                Orden = "Pendiente"
            Case 6
                Orden = "PrimerVencimientoNoPagado"
        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub cbProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbResponsable.TextChanged, cbProveedor.TextChanged, cbEstado.TextChanged
        Call busqueda()
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            Call busqueda()
        End If
    End Sub
#End Region

#End Region

End Class