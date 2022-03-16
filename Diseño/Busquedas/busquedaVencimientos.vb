
Public Class busquedaVencimientos

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumFactura As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesFacturas
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private funcBA As New FuncionesBancos
    Private funcMP As New funcionesMediosPago
    Private funcVE As New FuncionesVencimientos
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    'Private Facturas As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean

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

    Property pnumFactura() As Integer
        Get
            Return inumFactura
        End Get
        Set(ByVal value As Integer)
            inumFactura = value

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

    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        colorInactivo = Color.Gray
        colorCabecera = Color.Red
        If desktopSize.Height < 900 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 850
        End If
        ckSeleccion.Location = New Point(lvVencimientos.Location.X + 6, lvVencimientos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        Call limpiar()
        direccion = "ASC"
        'Facturas = New List(Of Integer)
        Call introducirMediosPago()
        Call introducirBancos()
        Call introducirClientes()
        Call introducirNum()
        Call introducirEstados()
        semaforo = False
        Call busqueda()
        semaforo = True
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        cbnumFactura.Text = ""
        cbnumFactura.SelectedIndex = -1
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = Now.Date
        dtpHasta.Value = Now.Date
        cbBanco.Text = ""
        cbBanco.SelectedIndex = -1
        ckVerCobrados.Checked = False
        ckVerRemesados.Checked = False
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cambioFechas = False
        Orden = ""
        direccion = "ASC"
        semaforo = True
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

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirNum()
        cbnumFactura.Items.Clear()
        Dim lista As List(Of Integer) = funcOF.listaNum(0)
        For Each num As Integer In lista
            cbnumFactura.Items.Add(num)
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next

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

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()


        'instrucciones para búsqueda de Cliente
        sBusqueda = ""

        If cbnumFactura.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " VE.numFactura like '" & cbnumFactura.Text & "%' "
        End If

        If cbCliente.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idCliente = " & cbCliente.SelectedItem.itemdata
        ElseIf cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.NombreFiscal like '%" & cbCliente.Text & "%' "

        End If

        If cbMedioPago.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idMedioPago = " & cbMedioPago.SelectedItem.itemdata
        End If

        If ckVerCobrados.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (Cobrado <> 1 or Cobrado is null) "
        End If

        If ckVerRemesados.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ( Remesado <> 1 or Remesado is null)"
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cbBanco.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Bancos.idBanco = " & cbBanco.SelectedItem.itemdata
        End If

        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), Vencimiento,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Vencimiento,103))  <= '" & dtpHasta.Value.Date & "' "
        End If



        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            semaforo = False
            lvVencimientos.Items.Clear()
            'Facturas.Clear()
            'lvwColumnSorter = New OrdenarLV()
            'lvDocumentos.ListViewItemSorter = lvwColumnSorter
            Dim Suma As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambio As Date = Now.Date
            Dim FechaCambioG As Date = Now.Date
            Dim lista As List(Of DatosVencimiento) = funcVE.Busqueda(sBusqueda, Orden)
            Dim importeEU As Double
            For Each dts As DatosVencimiento In lista
                'Facturas.Add(dts.gnumFactura)
                With lvVencimientos.Items.Add(" ")
                    .SubItems.Add(dts.gidVencimiento)
                    .SubItems.Add(dts.gnumFactura)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gVencimiento)
                    If dts.gDevuelto Then
                        .SubItems.Add("DEVUELTO")
                        .ForeColor = Color.Red
                    ElseIf dts.gCobrado Then
                        .SubItems.Add("COBRADO")
                        .ForeColor = Color.Green
                    ElseIf dts.gRemesado Then
                        .SubItems.Add("REMESADO")
                    Else
                        .SubItems.Add("PENDIENTE")
                    End If
                    .SubItems.Add(FormatNumber(dts.gImporte, 2) & dts.gSimbolo)
                    If dts.gcodMoneda = "EU" Then
                        importeEU = dts.gImporte
                    Else
                        importeEU = funcMO.Cambio(dts.gImporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                    Suma = Suma + importeEU
                    .SubItems.Add(dts.gImporte) 'sin simbolo, para poder sumarlo
                    .SubItems.Add(dts.gcodMoneda)
                End With
            Next
            lbEncontrados.Text = "ENCONTRADOS"
            lbTotal.Text = "TOTAL ENCONTRADOS"
            Contador.Text = lvVencimientos.Items.Count
            Total.Text = FormatNumber(Suma, 2)
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            Dim iidVencimiento As Long = lvVencimientos.Items(indice).SubItems(1).Text
            Dim dts As DatosVencimiento = funcVE.Mostrar1(iidVencimiento)
            With lvVencimientos.Items(indice)
                .SubItems(2).Text = dts.gnumFactura
                .SubItems(3).Text = dts.gCliente
                .SubItems(4).Text = dts.gVencimiento
                If dts.gDevuelto Then
                    .SubItems(5).Text = "DEVUELTO"
                    .ForeColor = Color.Red
                ElseIf dts.gCobrado Then
                    .SubItems(5).Text = "COBRADO"
                    .ForeColor = Color.Green
                ElseIf dts.gRemesado Then
                    .SubItems(5).Text = "REMESADO"
                Else
                    .SubItems(5).Text = "PENDIENTE"
                End If
                .SubItems(6).Text = FormatNumber(dts.gImporte, 2) & dts.gSimbolo
                .SubItems(7).Text = dts.gImporte
                .SubItems(8).Text = dts.gcodMoneda
            End With
        End If


    
        
    End Sub





    Private Sub Recalcular()
        Dim suma As Double = 0
        Dim importeEU As Double = 0
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        If lvVencimientos.CheckedItems.Count > 0 Then
            For Each item As ListViewItem In lvVencimientos.CheckedItems
                If item.SubItems(8).Text = "EU" Then
                    importeEU = item.SubItems(7).Text
                Else
                    importeEU = funcMO.Cambio(item.SubItems(7).Text, item.SubItems(8).Text, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                End If
                suma = suma + importeEU
            Next
            Contador.Text = lvVencimientos.CheckedItems.Count
            lbEncontrados.Text = "SELECCIONADOS"
            lbTotal.Text = "TOTAL SELECCIONADOS"
        Else
            For Each item As ListViewItem In lvVencimientos.Items
                If item.SubItems(8).Text = "EU" Then
                    importeEU = item.SubItems(7).Text
                Else
                    importeEU = funcMO.Cambio(item.SubItems(7).Text, item.SubItems(8).Text, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                End If
                suma = suma + importeEU
            Next
            Contador.Text = lvVencimientos.Items.Count
            lbEncontrados.Text = "ENCONTRADOS"
            lbTotal.Text = "TOTAL ENCONTRADOS"
        End If

        Total.Text = FormatNumber(suma, 2)
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

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim GG As New GestionFactura1
        GG.SoloLectura = vsoloLectura
        GG.pnumFactura = 0
        GG.ShowDialog()
        If GG.pnumFactura > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim sidVencimientos As String = ""
        Dim PendientesRemesar As Boolean = False
        Dim Respuesta As MsgBoxResult = MsgBoxResult.No
        If lvVencimientos.CheckedItems.Count = 0 Then
            If MsgBox("¿Imprimir todos los vencimientos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                'Si no hay items seleccionados proponemos imprimirlos todos
                'Comprobamos si hay pendientes de remesar para avisar
                ' PendientesRemesar = False
                ' For Each item As ListViewItem In lvVencimientos.Items
                'If item.SubItems(5).Text <> "REMESADO" And item.SubItems(5).Text <> "COBRADO" And item.SubItems(5).Text <> "DEVUELTO" Then PendientesRemesar = True
                'Next
                ' Respuesta = MsgBoxResult.No
                ' If PendientesRemesar Then Respuesta = MsgBox("¿Marcar como REMESADOS los vencimientos a imprimir?", MsgBoxStyle.YesNo)
                For Each item As ListViewItem In lvVencimientos.Items
                    sidVencimientos = sidVencimientos & If(sidVencimientos = "", "", ", ") & item.SubItems(1).Text
                    '  If Respuesta = MsgBoxResult.Yes Then funcVE.Remesado(item.SubItems(1).Text)
                Next
                Dim GG As New InformeListadoVencimientos
                GG.verInforme(" idVencimiento in (" & sidVencimientos & ")", Orden, Total.Text, "", "", Now)
                GG.ShowDialog()
            End If
        Else
            'Si hay items seleccionados, los imprimimos directamente
            'Comprobamos si hay pendientes de remesar para avisar
            'PendientesRemesar = False
            'For Each item As ListViewItem In lvVencimientos.CheckedItems
            'If item.SubItems(5).Text <> "REMESADO" And item.SubItems(5).Text <> "COBRADO" And item.SubItems(5).Text <> "DEVUELTO" Then PendientesRemesar = True
            'Next
            ' Respuesta = MsgBoxResult.No
            'If PendientesRemesar Then Respuesta = MsgBox("¿Marcar como REMESADOS los vencimientos a imprimir?", MsgBoxStyle.YesNo)
            For Each item As ListViewItem In lvVencimientos.CheckedItems
                sidVencimientos = sidVencimientos & If(sidVencimientos = "", "", ", ") & item.SubItems(1).Text
                ' If Respuesta = MsgBoxResult.Yes Then funcVE.Remesado(item.SubItems(1).Text)
            Next
            Dim GG As New InformeListadoVencimientos
            GG.verInforme(" idVencimiento in (" & sidVencimientos & ")", Orden, Total.Text, "", "", Now)
            GG.ShowDialog()
        End If
        ' If Respuesta = MsgBoxResult.Yes Then
        'ckVerRemesados.Checked = True
        ' Call busqueda() 'Para que se vea la nueva situación
        'End If


    End Sub

    Private Sub bRemesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bRemesa.Click
        Dim sidVencimientos As String = ""
        Dim PendientesRemesar As Boolean = False
        Dim Respuesta As MsgBoxResult = MsgBoxResult.No
        If lvVencimientos.CheckedItems.Count = 0 Then
            If MsgBox("¿Imprimir todos los vencimientos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                'Si no hay items seleccionados proponemos imprimirlos todos
                'Comprobamos si hay pendientes de remesar para avisar
                PendientesRemesar = False
                For Each item As ListViewItem In lvVencimientos.Items
                    If item.SubItems(5).Text <> "REMESADO" And item.SubItems(5).Text <> "COBRADO" And item.SubItems(5).Text <> "DEVUELTO" Then PendientesRemesar = True
                Next
                Respuesta = MsgBoxResult.No
                If PendientesRemesar Then Respuesta = MsgBox("¿Marcar como REMESADOS los vencimientos a imprimir?", MsgBoxStyle.YesNo)
                For Each item As ListViewItem In lvVencimientos.Items
                    sidVencimientos = sidVencimientos & If(sidVencimientos = "", "", ", ") & item.SubItems(1).Text
                    If Respuesta = MsgBoxResult.Yes Then funcVE.Remesado(item.SubItems(1).Text)
                Next
                Dim SR As New subRemesa
                SR.ShowDialog()
                If SR.pBanco <> "" Then
                    Dim GG As New InformeListadoVencimientos
                    GG.verInforme(" idVencimiento in (" & sidVencimientos & ")", Orden, Total.Text, SR.pBanco, SR.pCuenta, SR.pFecha)
                    GG.ShowDialog()
                End If

            End If
        Else
            'Si hay items seleccionados, los imprimimos directamente
            'Comprobamos si hay pendientes de remesar para avisar
            PendientesRemesar = False
            For Each item As ListViewItem In lvVencimientos.CheckedItems
                If item.SubItems(5).Text <> "REMESADO" And item.SubItems(5).Text <> "COBRADO" And item.SubItems(5).Text <> "DEVUELTO" Then PendientesRemesar = True
            Next
            Respuesta = MsgBoxResult.No
            If PendientesRemesar Then Respuesta = MsgBox("¿Marcar como REMESADOS los vencimientos a imprimir?", MsgBoxStyle.YesNo)
            For Each item As ListViewItem In lvVencimientos.CheckedItems
                sidVencimientos = sidVencimientos & If(sidVencimientos = "", "", ", ") & item.SubItems(1).Text
                If Respuesta = MsgBoxResult.Yes Then funcVE.Remesado(item.SubItems(1).Text)
            Next

            Dim SR As New subRemesa
            SR.ShowDialog()
            If SR.pBanco <> "" Then
                Dim GG As New InformeListadoVencimientos
                GG.verInforme(" idVencimiento in (" & sidVencimientos & ")", Orden, Total.Text, SR.pBanco, SR.pCuenta, SR.pFecha)
                GG.ShowDialog()
            End If
        End If
        If Respuesta = MsgBoxResult.Yes Then
            ckVerRemesados.Checked = True
            Call busqueda() 'Para que se vea la nueva situación
        End If


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

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVencimientos.DoubleClick
        If lvVencimientos.SelectedItems.Count > 0 Then

            indice = lvVencimientos.SelectedIndices(0)
            Dim PrimerItem As Integer = lvVencimientos.TopItem.Index
            If modo = "B" Then
                Me.Close()
            Else
                Dim GP As New GestionFactura1
                GP.pnumFactura = lvVencimientos.SelectedItems(0).SubItems(2).Text

                'GP.pFacturas = Facturas
                GP.SoloLectura = vsoloLectura
                'GP.pIndice = indice
                GP.ShowDialog()

                Call ActualizarLV()

                If indice < lvVencimientos.Items.Count And PrimerItem < lvVencimientos.Items.Count Then
                    lvVencimientos.EnsureVisible(PrimerItem)
                    lvVencimientos.EnsureVisible(indice)
                End If

                'Call ActualizarLineaLV()  'No sirve porque los vencimientos se borran y vuelven a escribir, por lo que el idVencimiento puede cambiar

                ' Call Recalcular()

                End If


                'Call cerrarformulario()
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 835
        Me.Height = If(Me.Height < 300, 300, Me.Height)
        'lvDocumentos.Height = Me.Height - 224
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbnumFactura.SelectedIndexChanged, cbCliente.SelectedIndexChanged, cbEstado.SelectedIndexChanged, cbBanco.SelectedIndexChanged, cbMedioPago.SelectedIndexChanged, ckVerCobrados.CheckedChanged, ckVerRemesados.CheckedChanged
        Call busqueda()
    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvVencimientos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0, 1, 2
                Orden = "FA.numFactura"
            Case 3
                Orden = "NombreFiscal"
            Case 4
                Orden = "Vencimiento"
            Case 5
                Orden = "Cobrado " & If(direccion = "ASC", "DESC", "ASC") & ", Devuelto " & If(direccion = "ASC", "DESC", "ASC") & ", remesado "
            Case 6
                Orden = "Importe"

        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub cbCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbnumFactura.TextChanged, cbCliente.TextChanged, cbEstado.TextChanged
        Call busqueda()
    End Sub

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvVencimientos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If

    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvVencimientos.ItemChecked
        If semaforo Then
            Dim cont As Integer = lvVencimientos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvVencimientos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
            Call Recalcular()
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

#End Region

#End Region

End Class