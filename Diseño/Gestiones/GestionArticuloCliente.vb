Public Class GestionArticuloCliente

    Private funcAR As New FuncionesArticulos
    Private funcCL As New funcionesclientes
    Private funcAC As New funcionesArticuloCliente
    Private funcFA As New funcionesFacturacion
    Private funcACP As New funcionesArticuloClientePrecios
    Private funcMO As New FuncionesMoneda
    Private vSoloLectura As Boolean
    Private colorInactivo As Color = Color.Gray
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private iidArticulo As Integer
    Private iidCliente As Integer
    Private G_AGeneral As Char
    Private iidUsuario As Integer
    Private indice As Integer
    Private cambios As Integer
    Private desktopsize As Size
    Private Ancho As Integer = 994
    Private Semaforo As Boolean
    Private dtsCL As datoscliente
    Private dtsAR As DatosArticulo
    Private dtsAC As DatosArticuloCliente
    Private dtsFA As datosfacturacion
    Private listaAC As List(Of DatosArticuloCliente) 'Mantiene la lista actualizada de ArticuloCliente
    Private lvwColumnSorter As OrdenarLV
    Private Modo As String

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
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

    Public Property pcodArticuloCli() As String
        Get
            Return CodArticuloCli.Text
        End Get
        Set(ByVal value As String)
            CodArticuloCli.Text = value
        End Set
    End Property

    Public Property pArticuloCli() As String
        Get
            Return ArticuloCli.Text
        End Get
        Set(ByVal value As String)
            ArticuloCli.Text = value
        End Set
    End Property

    Public Property pModo() As String
        Get
            Return Modo
        End Get
        Set(ByVal value As String)
            Modo = value
        End Set
    End Property

    Private Sub GestionArticuloCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
        End If

    End Sub

    Private Sub GestionArticuloCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopsize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopsize.Height < 850 Then
            Me.Height = desktopsize.Height - 50
        Else
            Me.Height = 800
        End If
        lvwColumnSorter = New OrdenarLV()
        Me.lvProductos.ListViewItemSorter = lvwColumnSorter
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        iidUsuario = Inicio.vIdUsuario
        Semaforo = False

        Call InicializarGeneral()
        Call IntroducirArticulos()
        Call introducirClientes()
        'Posibilidades: Nos pasan el cliente o el artículo y el cliente (no se contempla el caso de que pasen el artículo y no en cliente)
        If iidCliente > 0 Then
            cbCliente.Enabled = False
            cbcodCliente.Enabled = False
            bBuscarCliente.Enabled = False
            Call CargarDatosCliente()
            Call CargarArticuloCli()
            If iidArticulo > 0 Then
                cbCodArticulo.Enabled = False
                cbArticulo.Enabled = False
                bBuscarArticulo.Enabled = False
                indice = BuscaIndice() 'listaAC.FindIndex(AddressOf BuscaIdArticulo)
                Call CargarDatosArticulo()
            Else
                cbCodArticulo.Enabled = True
                cbArticulo.Enabled = True
                bBuscarArticulo.Enabled = True
            End If
        Else
            'Si no se pasa cliente, lo inicializamos en blanco. Se puede buscar cliente y artículo
            cbCliente.Enabled = True
            cbcodCliente.Enabled = True
            bBuscarCliente.Enabled = True
            cbCodArticulo.Enabled = True
            cbArticulo.Enabled = True
            bBuscarArticulo.Enabled = True
            cambios = False
        End If
        Semaforo = True


    End Sub

#Region "INICIALIZACIÓN"

    Private Sub InicializarGeneral()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbcodCliente.Text = ""
        cbcodCliente.SelectedIndex = -1
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        Descuento.Text = 0
        'ArticuloCli.Text = ""
        'CodArticuloCli.Text = ""
        ckHistorico.Checked = False
        Descuento.Text = 0
        PrecioNeto.Text = 0
        Tipo.Text = ""
        subTipo.Text = ""
        dtpFechaAlta.Value = Now.Date
        dtpFechaBaja.Value = Now.Date
        ckActivo.Checked = True
        indice = -1
        cambios = False
    End Sub

    Private Sub limpiar()

        dtpFechaAlta.Value = Now.Date
        dtpFechaBaja.Value = Now.Date
        ckActivo.Checked = True
        dtpFechaBaja.Visible = False
        lbFechaBaja.Visible = False
        indice = -1
        Descuento.Text = 0
        PrecioNeto.Text = 0
        ' ArticuloCli.Text = ""
        'CodArticuloCli.Text = ""
        cambios = False
        If cbArticulo.Enabled Then
            cbArticulo.SelectedIndex = -1
            cbArticulo.Text = ""
            cbCodArticulo.SelectedIndex = -1
            cbCodArticulo.Text = ""

            Descuento.Text = 0
            PrecioNeto.Text = 0
            PVP.Text = 0
            Tipo.Text = ""
            subTipo.Text = ""
            iidArticulo = 0
            indice = -1
            lvProductos.SelectedIndices.Clear()
        End If

    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbcodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub IntroducirArticulos()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("VENDIBLE")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub

    Private Sub CargarDatosCliente()
        ep1.Clear()
        ep2.Clear()
        dtsCL = funcCL.mostrar1(iidCliente)
        cbcodCliente.Text = dtsCL.gcodCli
        cbCliente.Text = dtsCL.gnombrecomercial
        dtsFA = funcFA.mostrarCli(iidCliente)
    End Sub

    Private Sub CargarDatosArticulo()
        'Dim lista As List(Of DatosArticuloCliente) = funcAC.mostrar(iidArticulo, iidCliente, False, True, False, Not ckHistorico.Checked)
        'Carga los datos del artículo de la tabla ArticuloCliente si existe y si no de la tabla Articulos
        Semaforo = False
        ep1.Clear()
        ep2.Clear()
        dtsAR = funcAR.Mostrar1(iidArticulo)
        If indice <> -1 Then
            'Si el artículo seleccionado no es el que estamos tratando lo deseleccionamos
            If iidArticulo <> lvProductos.Items(indice).SubItems(1).Text Then
                indice = -1
            End If
        End If

        If indice = -1 Then
            cbCodArticulo.Text = dtsAR.gcodArticulo
            cbArticulo.Text = dtsAR.gArticulo
            Tipo.Text = dtsAR.gTipoArticulo
            subTipo.Text = dtsAR.gSubTipoArticulo
            If CodArticuloCli.Text = "" Then CodArticuloCli.Text = dtsAR.gcodArticulo
            If ArticuloCli.Text = "" Then ArticuloCli.Text = dtsAR.gArticulo
            PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            PrecioNeto.Text = 0
            ckActivo.Checked = True
            'lbMoneda.Text = dtsAR.gSimboloV
            'lbMoneda2.Text = dtsAR.gSimboloV

            'Ponemos el descuento por defecto del cliente según el tipo
            If cbCliente.SelectedIndex <> -1 Then
                If dtsAR.gDescuento1 Then
                    Descuento.Text = FormatNumber(dtsFA.gDescuento, 2)
                End If
                If dtsAR.gDescuento2 Then
                    Descuento.Text = FormatNumber(dtsFA.gDescuento2, 2)
                End If
            End If
        Else
            dtsAC = funcAC.mostrar1(lvProductos.Items(indice).Text) 'listaAC(indice)
            cbCodArticulo.Text = dtsAC.gcodArticulo
            cbArticulo.Text = dtsAC.gArticulo
            Tipo.Text = dtsAC.gTipoArticulo
            subTipo.Text = dtsAC.gsubTipoArticulo
            CodArticuloCli.Text = dtsAC.gcodArticuloCli
            ArticuloCli.Text = dtsAC.gArticuloCli
            PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            Descuento.Text = FormatNumber(dtsAC.gDescuento, 2)
            ckActivo.Checked = dtsAR.gActivo
            If dtsAC.gcodMoneda <> dtsFA.gcodMoneda Then
                'Si la moneda del cliente es distinta de la del artículo
                Dim aviso As Boolean
                Dim FechaCambio As Date
                dtsAC.gPrecioNetoUnitario = funcMO.Cambio(dtsAC.gPrecioNetoUnitario, dtsAC.gcodMoneda, dtsFA.gcodMoneda, aviso, FechaCambio)
                lbCambio.Text = "CAMBIO " & FechaCambio
                lbCambio.Visible = aviso
            End If

            PrecioNeto.Text = FormatNumber(dtsAC.gPrecioNetoUnitario, 2)

            lbMoneda.Text = dtsAC.gSimbolo
            'como el articulo está en el listview, lo seleccionamos
            lvProductos.Items(indice).Selected = True
            lvProductos.Items(indice).EnsureVisible()

        End If
        Semaforo = True
    End Sub

    Private Function BuscaIdArticulo(ByVal dts As DatosArticuloCliente) As Boolean
        'Devuelve el índice que contiene un artículo en la lista, que tambíen sirve para el listview
        'A partir de la variable iidArticulo
        If dts.gidArticulo = iidArticulo Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function BuscaIndice() As Integer
        'Buscar un artículo en el listview, devuelve el índice
        For Each item As ListViewItem In lvProductos.Items
            If item.SubItems(1).Text = iidArticulo Then Return item.Index
        Next
        Return -1
    End Function



#End Region

#Region "CARGAR DATOS"

    Private Sub CargarArticuloCli()
        lvProductos.Items.Clear()
        listaAC = funcAC.mostrar(0, iidCliente, False, True, False, Not ckHistorico.Checked)
        For Each dts As DatosArticuloCliente In listaAC
            Call NuevaLineaLV(dts)
        Next
        Encontrados.Text = lvProductos.Items.Count
    End Sub





#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"


    Private Sub NuevaLineaLV(ByVal dts As DatosArticuloCliente)
        lvwColumnSorter = New OrdenarLV()
        Me.lvProductos.ListViewItemSorter = lvwColumnSorter
        With lvProductos.Items.Add(dts.gIdArtCli)
            .subitems.add(dts.gidArticulo)
            .subitems.add(dts.gcodArticulo)
            .subitems.add(dts.gArticulo)
            .subitems.add(dts.gcodArticuloCli)
            .subitems.add(dts.gArticuloCli)
            .subitems.add(FormatNumber(dts.gDescuento, 2) & "%")
            .subitems.add(FormatNumber(dts.gPrecioNetoUnitario, 2) & dts.gSimbolo)
            .subitems.add(If(dts.gtipoDoc = "", "", UCase(dts.gtipoDoc) & " " & If(dts.gnumDoc = 0, "", CStr(dts.gnumDoc))))
            If dts.gActivo Then
                .ForeColor = Color.Black
            Else
                .ForeColor = colorInactivo
            End If
        End With

    End Sub


    Private Sub ActualizarLineaLV(ByVal dts As DatosArticuloCliente)
        'Actualiza la linea del índice
        If indice <> -1 Then
            lvwColumnSorter = New OrdenarLV()
            Me.lvProductos.ListViewItemSorter = lvwColumnSorter
            With lvProductos.Items(indice)
                .SubItems(1).Text = dts.gidArticulo
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gArticulo
                .SubItems(4).Text = dts.gcodArticuloCli
                .SubItems(5).Text = dts.gArticuloCli
                .SubItems(6).Text = FormatNumber(dts.gDescuento, 2) & "%"
                .SubItems(7).Text = FormatNumber(dts.gPrecioNetoUnitario, 2) & dts.gSimbolo
                .SubItems(8).Text = If(dts.gtipoDoc = "", "", UCase(dts.gtipoDoc) & " " & If(dts.gnumDoc = 0, "", CStr(dts.gnumDoc)))
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If

            End With

        End If

    End Sub


    Private Function CompruebaACigual() As Boolean
        'Comprobamos si los datos de personalización del artículo para el cliente son identicos a los del artículo genérico
        'Devuelve True cuando los datos son diferentes y se ha de guardar
        If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
        If PrecioNeto.Text > 0 Then
            Return True
        Else
            dtsAR = funcAR.Mostrar1(iidArticulo)
            If CodArticuloCli.Text = dtsAR.gcodArticulo And ArticuloCli.Text = dtsAR.gArticulo Then
                If (dtsAR.gDescuento1 And Descuento.Text = dtsFA.gDescuento) Or (dtsAR.gDescuento2 And Descuento.Text = dtsFA.gDescuento2) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        End If

    End Function


#End Region

#Region "BOTONES GENERALES"

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Dim validar As Boolean = True
        If iidArticulo = 0 Then
            validar = False
            ep1.SetError(cbArticulo, "Se ha de seleccionar un artículo")
        End If

        If validar Then
            If Descuento.Text = "" Then Descuento.Text = 0
            If Descuento.Text <> 0 Then PrecioNeto.Text = 0

            dtsAC = New DatosArticuloCliente
            dtsAC.gidArticulo = iidArticulo
            dtsAC.gidCliente = iidCliente
            dtsAC.gArticuloCli = ArticuloCli.Text
            dtsAC.gcodArticuloCli = CodArticuloCli.Text
            dtsAC.gDescuento = Descuento.Text
            dtsAC.gFechaAlta = dtpFechaAlta.Value.Date
            dtsAC.gFechaBaja = dtpFechaBaja.Value.Date
            dtsAC.gActivo = ckActivo.Checked
            dtsAC.gnumDoc = 0
            dtsAC.gtipoDoc = "MANUAL"
            dtsAC.gPrecioNetoUnitario = PrecioNeto.Text
            dtsAC.gcodArticulo = dtsAR.gcodArticulo

            dtsAC.gArticulo = dtsAR.gArticulo
            dtsAC.gSimbolo = dtsAR.gSimboloV
            dtsAC.gcodMoneda = dtsAR.gcodMonedaC


            Dim dtsACP As New DatosArticuloClientePrecio
            dtsACP.gidArtCliPrecio = 0
            dtsACP.gidArtCli = 0
            dtsACP.gPrecioNetoUnitario = PrecioNeto.Text
            dtsACP.gActivo = dtsAC.gActivo
            dtsACP.gcodMoneda = dtsFA.gcodMoneda
            If indice <> -1 Then
                'Si el artículo seleccionado no es el que estamos tratando lo deseleccionamos
                If iidArticulo <> lvProductos.Items(indice).SubItems(1).Text Then
                    indice = -1
                End If
            End If

            If indice = -1 Then
                'Nuevo
                If CompruebaACigual() Then
                    dtsAC.gIdArtCli = funcAC.insertar(dtsAC) 'Inserta articulo-cliente
                    dtsACP.gidArtCli = dtsAC.gIdArtCli 'Inserta precio
                    dtsACP.gidArtCliPrecio = funcACP.insertar(dtsACP)

                    Call NuevaLineaLV(dtsAC)
                    Encontrados.Text = lvProductos.Items.Count
                    Call limpiar()
                    CodArticuloCli.Text = ""
                    ArticuloCli.Text = ""
                Else
                    MsgBox("Los datos indicados son idénticos a los genéricos. No se añadirá el artículo a la lista personalizada del cliente.")
                End If

            Else
                'Actualizar
                'En dtsAC debemos tener los datos
                Dim iidArtCli As Integer = lvProductos.Items(indice).Text
                dtsAC.gIdArtCli = iidArtCli
                dtsACP.gidArtCli = iidArtCli
                If CompruebaACigual() Then
                    funcAC.actualizar(dtsAC, False)
                    Call ActualizarLineaLV(dtsAC)
                    'Comporbar si hemos cambiado el precio
                    Dim dtsACP2 As DatosArticuloClientePrecio = funcACP.mostrarArtCli(iidArtCli)
                    
                    If Math.Abs(dtsACP2.gPrecioNetoUnitario - dtsACP.gPrecioNetoUnitario) < 0.001 And dtsACP2.gcodMoneda = dtsACP.gcodMoneda Then
                        'No tocamos el precio
                    Else
                        'Desactivar precio anterior e insertar el nuevo
                        funcACP.Desactivar(iidArtCli)
                        If dtsACP.gPrecioNetoUnitario <> 0 Then
                            funcACP.insertar(dtsACP)
                        End If
                    End If
                    Call limpiar()
                    CodArticuloCli.Text = ""
                    ArticuloCli.Text = ""
                Else
                    If MsgBox("Los datos indicados son idénticos a los genéricos. Se eliminará el artículo de la lista personalizada del cliente.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        funcAC.borrar(listaAC(indice).gIdArtCli)
                        lvProductos.Items.RemoveAt(indice)
                        Call limpiar()
                        CodArticuloCli.Text = ""
                        ArticuloCli.Text = ""
                    End If
                End If
            End If
            cambios = False
        End If

    End Sub

   

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvProductos.SelectedItems.Count > 0 Then
            indice = lvProductos.SelectedIndices(0)
            Dim iidArtCli As Integer = lvProductos.Items(indice).Text
            If funcAC.EnUso(iidArtCli) Then
                MsgBox("La asignación artículo - cliente está en uso, por tanto no se puede borrar. Alternativamente puede desactivarla.")
            Else
                funcACP.borrarArtCli(iidArtCli)
                funcAC.borrar(iidArtCli)
                lvwColumnSorter = New OrdenarLV()
                Me.lvProductos.ListViewItemSorter = lvwColumnSorter
                lvProductos.Items.RemoveAt(indice)
                Call limpiar()
                CodArticuloCli.Text = ""
                ArticuloCli.Text = ""
                Encontrados.Text = lvProductos.Items.Count
            End If
        End If
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Semaforo = False
        Call limpiar()
        CodArticuloCli.Text = ""
        ArticuloCli.Text = ""
        Semaforo = True
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = cbCliente.SelectedItem.itemdata
            GG.ShowDialog()
            Call introducirClientes()
            cbCliente.Text = cliente
            cbCodCliente.Text = codcli
            If cbCliente.SelectedIndex = -1 Then
                cbCliente.Text = ""
                cbcodCliente.Text = ""
            Else
                Call CargarDatosCliente()
            End If
        End If

    End Sub

    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click
        Dim GG As New busquedaCliente
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            'dtsCL = funcCL.mostrar1(GG.pidCliente)
            'cbCodCliente.Text = dtsCL.gcodCli
            'cbCliente.Text = dtsCL.gnombrecomercial
            iidCliente = GG.pidCliente
            Call CargarDatosCliente()
            Call CargarArticuloCli()
            ' cambios = True

        End If

    End Sub

    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bverArticulo.Click
        If iidArticulo > 0 Then
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.ShowDialog()
            Call CargarDatosArticulo()
        End If

    End Sub

    Private Sub bBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticulo.Click

        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "CONCEPTO"
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticulo = GG.pidArticulo
            Call CargarDatosArticulo()
        End If

    End Sub

#End Region

#Region "EVENTOS"
    Private Sub cbCodCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcodCliente.SelectionChangeCommitted
        If cbcodCliente.SelectedIndex <> -1 Then
            iidCliente = cbcodCliente.SelectedItem.itemdata
            Call CargarDatosCliente()
            Call CargarArticuloCli()
            'If cbArticulo.SelectedIndex <> -1 Then
            '    Call CargarDatosArticulo()
            'End If
            'cambios = True
        End If
    End Sub

    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            Call CargarDatosCliente()
            Call CargarArticuloCli()
            'If cbArticulo.SelectedIndex <> -1 Then
            '    Call CargarDatosArticulo()
            'End If
            'cambios = True
        End If
    End Sub

    Private Sub cbCodArticulo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedValueChanged
        If Semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                Semaforo = False
                iidArticulo = cbCodArticulo.SelectedItem.itemdata
                indice = BuscaIndice() ' listaAC.FindIndex(AddressOf BuscaIdArticulo)
                Call CargarDatosArticulo()
                cambios = True
                Semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticulo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedValueChanged
        If Semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                Semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                indice = BuscaIndice() ' listaAC.FindIndex(AddressOf BuscaIdArticulo)
                Call CargarDatosArticulo()
                cambios = True
                Semaforo = True
            End If
        End If
    End Sub

    Private Sub PrecioNeto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrecioNeto.Click, Descuento.Click
        sender.selectall()
    End Sub

    Private Sub Descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Descuento.KeyPress, PrecioNeto.KeyPress, PVP.KeyPress

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

    Private Sub ckActivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckActivo.CheckedChanged
        If Semaforo Then
            cambios = True
            dtpFechaBaja.Visible = (Not ckActivo.Checked)
            lbFechaBaja.Visible = (Not ckActivo.Checked)
        End If
    End Sub

    Private Sub PrecioNeto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrecioNeto.TextChanged
        'O precio neto o descuento
        If Semaforo Then
            cambios = True
            If PrecioNeto.Text <> "" Then
                If PrecioNeto.Text > 0 Then
                    Descuento.Text = 0
                End If
            End If
        End If
    End Sub

    Private Sub Descuento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Descuento.TextChanged
        'O precio neto o descuento
        If Semaforo Then
            cambios = True
            If Descuento.Text <> "" Then
                If Descuento.Text > 0 Then
                    PrecioNeto.Text = 0
                End If
            End If
        End If
    End Sub

    Private Sub lvProductos_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvProductos.ColumnClick
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
        Me.lvProductos.Sort()
        If indice <> -1 Then
            If lvProductos.SelectedItems.Count > 0 Then indice = lvProductos.SelectedIndices(0)
        End If
    End Sub

    Private Sub lvProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProductos.Click, lvProductos.SelectedIndexChanged
        If Semaforo Then
            If lvProductos.SelectedIndices.Count > 0 Then
                indice = lvProductos.SelectedIndices(0)
                iidArticulo = lvProductos.Items(indice).SubItems(1).Text
                Call CargarDatosArticulo()
            End If
        End If
    End Sub

    Private Sub ckHistorico_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckHistorico.CheckedChanged
        If iidCliente > 0 Then
            Call CargarArticuloCli()
        End If
    End Sub

    Private Sub lvProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProductos.DoubleClick
        If Modo = "DOC" Then
            Me.Close()
        End If
    End Sub

    Private Sub dtpFechaAlta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaAlta.ValueChanged, dtpFechaBaja.ValueChanged, ArticuloCli.TextChanged, CodArticuloCli.TextChanged, cbArticulo.SelectedIndexChanged, cbCodArticulo.SelectedIndexChanged
        cambios = Semaforo
    End Sub

#End Region

End Class