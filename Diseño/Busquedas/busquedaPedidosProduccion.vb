Public Class busquedaPedidosProduccion

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumPedido As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesPedidos
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private funcCR As New FuncionesConceptosProduccion
    Private funcCP As New FuncionesConceptosPedidos
    Private Orden As String
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Pedidos As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private cambioFechasE As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean

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

    Property pnumPedido() As Integer
        Get
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value

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
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        colorInactivo = Color.Gray
        colorCabecera = Color.Red

        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        Call limpiar()
        direccion = "ASC"
        Pedidos = New List(Of Integer)
        Call introducirClientes()
        Call introducirEstados()
        Call busqueda()
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        numPedido.Text = ""


        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1

        dtpDesdePedido.Value = funcOF.buscaPrimerDia.Date
        dtpHastaPedido.Value = funcOF.buscaUltimoDia.Date
        dtpDesdeEntrega.Value = funcCR.buscaPrimerDia.Date
        dtpHastaEntrega.Value = funcCR.buscaUltimoDia.Date
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        RefCliente.Text = ""
        cambioFechas = False
        cambioFechasE = False
        Orden = ""
        direccion = "ASC"
        semaforo = True
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    'Private Sub introducirNum()
    '    cbnumPedido.Items.Clear()
    '    Dim lista As List(Of Integer) = funcOF.listaNum(0)
    '    For Each num As Integer In lista
    '        cbnumPedido.Items.Add(num)
    '    Next
    'End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        cbEstado.Items.Add("PRODUCCIÓN")
        cbEstado.Items.Add("PRODUCIDO")
        cbEstado.Items.Add("PARCIAL")
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

        sBusqueda = ""

        If numPedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numPedido like '" & numPedido.Text & "%' "
        End If

        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.NombreComercial like '%" & Replace(cbCliente.Text, "'", "''") & "%' "
        End If


        sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

        sBusqueda = sBusqueda & " (select count(idConcepto) from ConceptosPedidos AS CP left join Estados as EC ON EC.idEstado = CP.idEstado "
        sBusqueda = sBusqueda & " where numPedido = DOC.numPedido AND Estados.Anulado = 0 AND ( Completo = 1 or Traspasado = 1 ))>0 "

        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesdePedido.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHastaPedido.Value.Date & "' "
        End If

        If cambioFechasE Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  >= '" & dtpDesdeEntrega.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  <= '" & dtpHastaEntrega.Value.Date & "' "
        End If

        If RefCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.ReferenciaCliente like '" & RefCliente.Text & "%' "
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            Select Case cbEstado.Text
                Case "PARCIAL" 'Algo del pedido se ha servido
                    sBusqueda = sBusqueda & " (Select sum(CantidadServida) from ConceptosPedidos as CP  where  CP.numPedido = DOC.numPedido)>0 "

                Case "PRODUCIDO" 'Todo lo producible producido
                    sBusqueda = sBusqueda & _
                    " (Select sum(CantidadServida) from ConceptosPedidos as CP  where  CP.numPedido = DOC.numPedido) = 0 AND " & _
                    " (Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado " & _
                    " left join ConceptosProduccion as CR ON CR.idConceptoPedido = CP.idConcepto " & _
                    " left join Articulos ON Articulos.idArticulo = CP.idArticulo " & _
                    " where Articulos.Escandallo = 1 AND idProduccion is not null and  Completo = 0 AND Entregado = 0 and numPedido = DOC.numPedido) = 0 "

                Case "PRODUCCIÓN" 'Alguno producible
                    sBusqueda = sBusqueda & _
                    " (Select sum(CantidadServida) from ConceptosPedidos as CP  where  CP.numPedido = DOC.numPedido) = 0 AND " & _
                    " (Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado " & _
                    " left join ConceptosProduccion as CR ON CR.idConceptoPedido = CP.idConcepto " & _
                    " left join Articulos ON Articulos.idArticulo = CP.idArticulo " & _
                    " where Articulos.Escandallo = 1 AND idProduccion is not null and  Completo = 0 AND Entregado = 0 and numPedido = DOC.numPedido) > 0 " 'No esté en estado PRODUCIDO

            End Select

        End If

        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Pedidos.Clear()

            Dim lista As List(Of DatosPedido) = funcOF.Busqueda0(sBusqueda, Orden, True)
            For Each dts As DatosPedido In lista
                Pedidos.Add(dts.gnumPedido)
                With lvDocumentos.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gFechaEntrega)
                    If funcCP.AlgoSERVIDO(dts.gnumPedido) Then
                        .SubItems.Add("PARCIAL")
                        If funcCP.TodosProduciblesProducidos(dts.gnumPedido) Then
                            .ForeColor = Color.Green
                        Else
                            .ForeColor = Color.Orange
                        End If

                    ElseIf funcCP.TodosProduciblesProducidos(dts.gnumPedido) Then
                        .SubItems.Add("PRODUCIDO")
                        .ForeColor = Color.Green
                    ElseIf funcCP.AlgunoProducible(dts.gnumPedido) Then
                        .SubItems.Add("PRODUCCIÓN")
                        If funcCP.AlgunoEmpezado(dts.gnumPedido) Then
                            .ForeColor = Color.Orange
                        Else
                            .ForeColor = Color.Black
                        End If
                    Else
                        .SubItems.Add("PRODUCIDO")
                        .ForeColor = Color.Green
                    End If
                    .SubItems.Add(dts.gReferenciaCliente)
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            inumPedido = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosPedido = funcOF.Mostrar1(inumPedido)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gCliente
                .SubItems(2).Text = dtsOF.gFecha
                .SubItems(3).Text = dtsOF.gFechaEntrega
                If funcCP.AlgoSERVIDO(dtsOF.gnumPedido) Then
                    .SubItems(4).Text = "PARCIAL"
                    If funcCP.TodosProduciblesProducidos(dtsOF.gnumPedido) Then
                        .ForeColor = Color.Green
                    Else
                        .ForeColor = Color.Orange
                    End If
                ElseIf funcCP.TodosProduciblesProducidos(dtsOF.gnumPedido) Then
                    .SubItems(4).Text = "PRODUCIDO"
                    .ForeColor = Color.Green
                ElseIf funcCP.AlgunoProducible(dtsOF.gnumPedido) Then
                    .SubItems(4).Text = "PRODUCCIÓN"
                    If funcCP.AlgunoEmpezado(dtsOF.gnumPedido) Then
                        .ForeColor = Color.Orange
                    Else
                        .ForeColor = Color.Black
                    End If
                Else
                    .ForeColor = Color.Black
                End If
                .SubItems(5).Text = dtsOF.gReferenciaCliente
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()

        Contador.Text = lvDocumentos.Items.Count

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
        Dim GG As New GestionPedido
        GG.SoloLectura = vsoloLectura
        GG.pnumPedido = 0
        GG.ShowDialog()
        If GG.pnumPedido > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListadoDetallado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListadoDetallado.Click
        Dim GG As New InformeListadoLogisitca
        GG.verInforme(sBusqueda, Orden, True)
        GG.ShowDialog()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoLogisitca
        GG.verInforme(sBusqueda, Orden, False)
        GG.ShowDialog()
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numPedido.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPedido.TextChanged, cbCliente.TextChanged, RefCliente.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Dim GG As New GestionLogistica
            GG.pnumPedido = lvDocumentos.Items(indice).SubItems(0).Text
            GG.SoloLectura = vsoloLectura
            GG.ShowDialog()
            Call ActualizarLineaLV()
            Call RecalcularTotalizadores()
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.Width = 873
        Me.Height = If(Me.Height < 300, 300, Me.Height)
        'lvDocumentos.Height = Me.Height - 224
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged ', cbCliente.TextChanged, RefCliente.TextChanged, numPedido.TextChanged
        Call busqueda()
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
                Orden = "numPedido"
            Case 1
                Orden = "Cliente"
            Case 2
                Orden = "Fecha"
            Case 3
                Orden = "FechaEntrega"
            Case 4
                Orden = " case when (Select sum(CantidadServida) from ConceptosPedidos as CP  where  CP.numPedido = DOC.numPedido)>0 then 1 " & _
                    " when (Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado " & _
                    " left join ConceptosProduccion as CR ON CR.idConceptoPedido = CP.idConcepto " & _
                    " left join Articulos ON Articulos.idArticulo = CP.idArticulo " & _
                    " where Articulos.Escandallo = 1 AND idProduccion is not null and  Completo = 0 AND Entregado = 0 and numPedido = DOC.numPedido) = 0 then 2 else 3 end "
            Case 5
                Orden = "ReferenciaCliente"
        End Select
        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()
    End Sub

#Region "CAMBIO DE FECHAS"
    Private Sub dtpHastaEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaEntrega.KeyUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesdeEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDesdeEntrega.KeyUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesdeEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHastaEntrega.CloseUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpHastaEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdeEntrega.CloseUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpHastaPedido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaPedido.KeyUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesdePedido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDesdePedido.KeyUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpDesdePedido_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHastaPedido.CloseUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub

    Private Sub dtpHastaPedido_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdePedido.CloseUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechasE = True
            Call busqueda()
        End If
    End Sub
#End Region

    Private Sub cbCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.TextChanged
        Call busqueda()
    End Sub

#End Region

End Class