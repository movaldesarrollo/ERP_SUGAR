Public Class busquedaReparaciones

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumReparacion As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesReparaciones
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstatusReparacion
    Private funcMO As New FuncionesMoneda
    Private funcEST As New FuncionesEstados
    Private Orden As String
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Reparaciones As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean
    Private iidCliente As Integer

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
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Property pnumReparacion() As Integer
        Get
            Return inumReparacion
        End Get
        Set(ByVal value As Integer)
            inumReparacion = value

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

    Public Property pidCliente() As Integer
        Get
            Return iidCliente
        End Get
        Set(ByVal value As Integer)
            iidCliente = value
        End Set
    End Property

    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        colorInactivo = Color.Gray
        colorCabecera = Color.Red
        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False
        Call limpiar()
        direccion = "ASC"
        Reparaciones = New List(Of Integer)
        Call IntroducirResponsables()
        Call IntroducirArticulosC()
        Call introducirClientes()
        Call introducirEstatus()
        Call introducirEstados()
        If iidCliente > 0 Then cbCliente.Text = funcCL.campoCliente(iidCliente)
        Call busqueda()
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        txRMA.Text = ""
        numDoc.Text = ""
        cbPersona.Text = ""
        cbPersona.SelectedIndex = -1
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbEstatus.Text = ""
        cbEstatus.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = "1-1-" & Now.Date.Year
        dtpHasta.Value = Now.Date
        ckCaja.Checked = False
        ckCelula.Checked = False
        ckPlaca.Checked = False
        ckSonda.Checked = False
        ckOtros.Checked = False
        OtrosTipos.Text = ""
        ckGarantia.Checked = False
        ckNoGarantia.Checked = False
        cambioFechas = True
        Orden = ""
        direccion = "ASC"
        semaforo = True
    End Sub

    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.Listar()

        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        'If VerClientesPropios Then
        '    cbPersona.Enabled = False
        '    If lista.Count = 0 Then
        '        MsgBox("No está autorizado para visualizar clientes")
        '        Me.Close()
        '    Else
        '        cbPersona.SelectedIndex = 0
        '    End If
        'Else
        '    cbPersona.SelectedIndex = -1
        'End If

    End Sub



    Private Sub IntroducirArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("VENDIBLE")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next


    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub



    Private Sub introducirEstatus()
        cbEstatus.Items.Clear()
        Dim lista As List(Of DatosEstatusReparacion) = funcES.Mostrar(True)
        For Each dts As DatosEstatusReparacion In lista
            cbEstatus.Items.Add(dts)
        Next

    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcEST.Mostrar("REPARACION")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next

    End Sub



#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"
    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call busqueda()
        End If
    End Sub
    Private Sub busqueda()
        'instrucciones para búsqueda de Cliente
        sBusqueda = " DOC.idCliente > 0 " 'Para que no presente Reparaciones de proveedor
        If VerClientesPropios Then sBusqueda = sBusqueda & " AND Clientes.idResponsableCuenta = " & Inicio.vIdUsuario
        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numReparacion like '" & numDoc.Text & "%' "
        End If
        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CLientes.NombreComercial like '%" & cbCliente.Text & "%' "
        End If
        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numReparacion in (select numReparacion from ConceptosReparaciones left join Articulos ON Articulos.idArticulo = ConceptosReparaciones.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numReparacion in (select numReparacion from ConceptosReparaciones where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
        End If
        If cbPersona.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idPersona = " & cbPersona.SelectedItem.itemdata
        End If
        If cbEstatus.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstatus = " & cbEstatus.SelectedItem.gidEstatus
        End If
        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If
        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHasta.Value.Date & "' "
        End If
        If numSerie.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numSerie like '" & numSerie.Text & "%' "
        End If
        If Descripciones.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Observaciones like '%" & Descripciones.Text & "%' OR DOC.Notas like '%" & Descripciones.Text & "%' OR DOC.Descripcion like '%" & Descripciones.Text & "%' OR DOC.Inspeccion like '%" & Descripciones.Text & "%' "
            sBusqueda = sBusqueda & " OR DOC.numReparacion in (select numReparacion from TrabajosReparaciones where Trabajo like '%" & Descripciones.Text & "%' )"
        End If
        If ckCaja.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Caja = 1 "
        End If
        If Trim(txRMA.Text) <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.RMA ='" & txRMA.Text & "'"
        End If

        If ckPlaca.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Placa = 1 "
        End If
        If ckSonda.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Sonda = 1 "
        End If
        If ckCelula.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Celula = 1 "
        End If
        If ckOtros.Checked Or OtrosTipos.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Otros = 1 and DOC.OtrosTipos like '" & OtrosTipos.Text & "%' "
        End If
        If ckGarantia.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Garantia = 1 "
        End If
        If ckNoGarantia.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Garantia = 0 "
        End If
        Call ActualizarLV()
    End Sub
    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Reparaciones.Clear()
            Dim Suma As Double = 0
            Dim suma2 As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosReparacion) = funcOF.Busqueda(sBusqueda, Orden, True)
            For Each dts As DatosReparacion In lista
                Reparaciones.Add(dts.gnumReparacion)
                With lvDocumentos.Items.Add(dts.gnumReparacion) '1
                    .SubItems.Add(dts.gnumSerie) '2
                    .SubItems.Add(dts.gCliente) '3
                    .SubItems.Add(dts.gFecha) '4
                    .SubItems.Add(dts.gEstado) '5
                    .SubItems.Add(dts.gEstatus) '6
                    .SubItems.Add(If(dts.gcodArticuloCli = "", If(dts.gcodArticulo = "", dts.gArticulo, dts.gcodArticulo), dts.gcodArticuloCli)) '7
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo) '8
                    .SubItems.Add(If(dts.gGarantia, "SI", "NO")) '9
                    .SubItems.Add(If(dts.gPrecioTotalReparacion = -1, "", dts.gPrecioTotalReparacion & "€")) '10
                    .SubItems.Add(dts.gRMA) '11
                    If dts.gdtsEstado.gAnulado Then
                        .ForeColor = Color.Gray
                    ElseIf dts.gdtsEstado.gEnCurso Or (dts.gdtsEstado.gTraspasado And Not dts.gdtsEstado.gBloqueado) Then
                        .ForeColor = Color.Orange
                    ElseIf dts.gdtsEstado.gTraspasado And dts.gEstatus <> "ENVIADA" Then
                        .ForeColor = Color.Green
                    Else
                        .ForeColor = SystemColors.WindowText
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                    suma2 = suma2 + If(dts.gPrecioTotalReparacion = -1, 0, dts.gPrecioTotalReparacion)
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count
            Total.Text = FormatNumber(Suma, 2) & "€"
            txTotatPreciosReparaciones.Text = FormatNumber(suma2, 2) & "€"
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            inumReparacion = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosReparacion = funcOF.Mostrar1(inumReparacion)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gnumSerie
                .SubItems(2).Text = dtsOF.gCliente
                .SubItems(3).Text = dtsOF.gFecha
                .SubItems(4).Text = dtsOF.gEstado
                .SubItems(5).Text = dtsOF.gEstatus
                .SubItems(6).Text = If(dtsOF.gcodArticuloCli = "", If(dtsOF.gcodArticulo = "", dtsOF.gArticulo, dtsOF.gcodArticulo), dtsOF.gcodArticuloCli)
                .SubItems(7).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
                .SubItems(8).Text = If(dtsOF.gGarantia, "SI", "NO")
                .SubItems(9).Text = If(dtsOF.gPrecioTotalReparacion = -1, "", dtsOF.gPrecioTotalReparacion & "€")
                .SubItems(10).Text = dtsOF.gRMA
                If dtsOF.gdtsEstado.gAnulado Then
                    .ForeColor = Color.Gray
                ElseIf dtsOF.gdtsEstado.gEnCurso Or (dtsOF.gdtsEstado.gTraspasado And Not dtsOF.gdtsEstado.gBloqueado) Then
                    .ForeColor = Color.Orange
                ElseIf dtsOF.gdtsEstado.gTraspasado And dtsOF.gEstatus <> "ENVIADA" Then
                    .ForeColor = Color.Green
                Else
                    .ForeColor = SystemColors.WindowText
                End If
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()
        Dim Suma As Double = 0
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambioG As Date = Now.Date
        Dim FechaCambio As Date = Now.Date
        Dim lista As List(Of DatosReparacion) = funcOF.Busqueda(sBusqueda, Orden, True)
        For Each dts As DatosReparacion In lista
            If dts.gcodMoneda = "EU" Then
                Suma = Suma + dts.gBase
            Else
                Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
            End If
        Next
        Contador.Text = lvDocumentos.Items.Count
        Total.Text = FormatNumber(Suma, 2)
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
        Dim GG As New GestionReparacion
        GG.SoloLectura = vsoloLectura
        GG.pnumReparacion = 0

        GG.ShowDialog()
        If GG.pnumReparacion > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoReparaciones
        GG.verInforme(sBusqueda, Orden, Total.Text, Contador.Text)
        GG.ShowDialog()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numReparacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
                inumReparacion = lvDocumentos.Items(indice).Text
                Me.Close()
            Else
                Dim GP As New GestionReparacion
                GP.pnumReparacion = lvDocumentos.SelectedItems(0).Text

                GP.pReparaciones = Reparaciones
                GP.SoloLectura = vsoloLectura
                GP.pIndice = indice
                GP.ShowDialog()
                Call ActualizarLineaLV()
                Call RecalcularTotalizadores()
            End If

        End If
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbCliente.TextChanged, numSerie.TextChanged, Descripciones.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If

    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPersona.SelectedIndexChanged, cbEstatus.SelectedIndexChanged, cbEstado.SelectedIndexChanged
        Call busqueda()
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If semaforo And cbCodArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)
            Call busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If semaforo And cbArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)
            Call busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        If semaforo Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)
            Call busqueda()
            semaforo = True
        End If

    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

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
                Orden = "DOC.numReparacion"
            Case 1
                Orden = "DOC.numSerie"
            Case 2
                Orden = "Cliente"
            Case 3
                Orden = "DOC.Fecha"
            Case 4
                Orden = "Estado"
            Case 5
                Orden = "Estatus"
            Case 6
                Orden = "codArticuloCli"
            Case 7
                Orden = "Base"

        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub ckCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCaja.CheckedChanged, ckCelula.CheckedChanged, ckOtros.CheckedChanged, ckPlaca.CheckedChanged, ckSonda.CheckedChanged, OtrosTipos.TextChanged, ckOtros.CheckedChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub ckNoGarantia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckNoGarantia.CheckedChanged
        If semaforo Then
            semaforo = False
            ckGarantia.Checked = Not ckNoGarantia.Checked
            semaforo = True
            Call busqueda()
        End If
    End Sub

    Private Sub ckGarantia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckGarantia.CheckedChanged
        If semaforo Then
            semaforo = False
            ckNoGarantia.Checked = Not ckGarantia.Checked
            semaforo = True
            Call busqueda()
        End If
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

    Private Sub Total_TextChanged(sender As Object, e As EventArgs) Handles Total.TextChanged

    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click

        Dim gg As New informeLog

        gg.verInforme(sBusqueda)

        gg.ShowDialog()

    End Sub


    Private Sub txRMA_KeyDown(sender As Object, e As KeyEventArgs) Handles txRMA.KeyDown
        If semaforo Then
            If e.KeyCode = Keys.Enter Then
                busqueda()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        busqueda()
    End Sub

#End Region
#End Region
End Class