Public Class GestionPeticionInternaMaterial

    Private funcCI As New FuncionesConceptosPedidosInternos
    Private funcAR As New FuncionesArticulos
    Private funcFA As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcES As New FuncionesEstados
    Private vSoloLectura As Boolean
    Private dtsAR As DatosArticulo
    Private Orden As String
    Private Direccion As String
    Private iidFamilia As Integer
    Private Columna As Integer
    Private sBusquedaArticulos As String
    Private sBusquedaConceptos As String
    Private AtiendePeticiones As Boolean
    Private EstadoNuevo As DatosEstado
    Private EstadoLeido As DatosEstado
    Private EstadoProcesado As DatosEstado
    Private EstadoAnulado As DatosEstado
    Private EstadoRecibido As DatosEstado
    Private EstadoParcial As DatosEstado
    Private ep1 As New ErrorProvider
    Private dtsCI As DatosConceptoPedidoInterno
    Private iidConcepto As Long
    Private AvisoLeido As Boolean
    Private Cambios As Boolean
    Private IDsConceptos As List(Of Long)
    Private indice As Integer

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Public Property pidConcepto()
        Get
            Return iidConcepto
        End Get
        Set(ByVal value)
            iidConcepto = value
        End Set
    End Property

    Public Property pIDsConceptos() As List(Of Long)
        Get
            Return IDsConceptos
        End Get
        Set(ByVal value As List(Of Long))
            IDsConceptos = value
        End Set
    End Property



    Public Property pIndice() As Integer
        Get
            Return indice
        End Get
        Set(ByVal value As Integer)
            indice = value
        End Set
    End Property



    Private Sub GestionPeticionInternaMaterial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AvisoLeido And AtiendePeticiones And dtsCI.gidEstado = EstadoNuevo.gidEstado And DialogResult <> Windows.Forms.DialogResult.Abort Then
            If MsgBox("¿Dar por leida la petición?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call MarcarLeido()
            End If
        ElseIf Cambios Then
            If MsgBox("Se perderán los cambios introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub PeticionInternaMaterial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        'PERMISOS
        Dim funcPE As New FuncionesPersonal
        AtiendePeticiones = funcPE.Parametro(Inicio.vIdUsuario, "PeticionesInternasMaterial", "ATENDER PETICION")
        If AtiendePeticiones Then
            bPedido.Visible = True
        Else
            bPedido.Visible = False
            bSubir.Location = New Point(bPedido.Location.X, bSubir.Location.Y)
            bBajar.Location = New Point(bPedido.Location.X, bBajar.Location.Y)
        End If
        bGuardar.Enabled = Not vSoloLectura
        Direccion = "ASC"
        Orden = " Articulo "
        Columna = 0
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        EstadoNuevo = funcES.EstadoEspera("C.PEDIDO_INT")
        EstadoLeido = funcES.EstadoEnCurso("C.PEDIDO_INT")
        EstadoProcesado = funcES.EstadoTraspasado("C.PEDIDO_INT")
        EstadoAnulado = funcES.EstadoAnulado("C.PEDIDO_INT")
        EstadoRecibido = funcES.EstadoCPedidoINT("RECIBIDO")
        EstadoParcial = funcES.EstadoCPedidoINT("PARCIAL")
        Call introducirFamilias()

        If IDsConceptos.Count > 0 And indice <> -1 Then
            Call CargarConcepto()
        Else
            bSubir.Visible = False
            bBajar.Visible = False
            dtsCI = New DatosConceptoPedidoInterno
            dtsCI.gidEstado = EstadoNuevo.gidEstado
            dtsCI.gidCreador = Inicio.vIdUsuario
            Call LimpiarEdicion()
            AvisoLeido = False
        End If
    End Sub




    Private Sub CargarConcepto()
        iidConcepto = IDsConceptos(indice)
        dtsCI = funcCI.mostrar1(iidConcepto)
        dtsAR = funcAR.Mostrar1(dtsCI.gidArticulo)
        cbFamilia.Text = dtsCI.gFamilia
        cbSubFamilia.Text = dtsCI.gsubFamilia
        cbCodArticulo.Text = dtsCI.gcodArticulo
        cbArticulo.Text = dtsCI.gArticulo
        Estado.Text = dtsCI.gEstado
        Cantidad.Text = FormatNumber(dtsCI.gCantidad, 2)
        Observaciones.Text = dtsCI.gObservaciones
        lbUnidad.Text = dtsAR.gTipoUnidad
        Cambios = False
        AvisoLeido = True
    End Sub





#Region "INICIALIZACIÓN"

    Public Sub LimpiarEdicion()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        dtsAR = New DatosArticulo
        Observaciones.Text = ""
        Cantidad.Text = 0
        sBusquedaArticulos = ""
        sBusquedaConceptos = ""
        cbFamilia.Text = ""
        cbFamilia.SelectedIndex = -1
        cbSubFamilia.Items.Clear()
        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1
        Estado.Text = EstadoNuevo.gEstado
        ep1.Clear()
    End Sub

    Private Sub introducirFamilias()
        Try
            cbFamilia.Items.Clear()
            iidFamilia = 0
            Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
            Dim dts As DatosFamilia
            For Each dts In lista
                cbFamilia.Items.Add(dts)
            Next
            iidFamilia = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirSubFamilias()
        Try
            cbSubFamilia.Items.Clear()
            cbSubFamilia.Text = ""
            If iidFamilia > 0 Then
                Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
                Dim dts As DatosSubFamilia
                For Each dts In lista
                    cbSubFamilia.Items.Add(dts)
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




#End Region


#Region "CARGAR DATOS"


    Private Sub IntroducirArticulos()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        Dim lista As List(Of IDComboBox3) = funcAR.Buscar(sBusquedaArticulos, Orden & Direccion)
        For Each dts In lista
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
            cbArticulo.Items.Add(dts)
        Next
    End Sub



#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub MarcarLeido()
        If dtsCI.gidConcepto > 0 And AtiendePeticiones Then
            funcCI.actualizarEstado(dtsCI.gidConcepto, EstadoLeido.gidEstado)
            dtsCI.gidEstado = EstadoLeido.gidEstado
            Estado.Text = EstadoLeido.gEstado
        End If
    End Sub

    Private Sub BusquedaArticulos()

        sBusquedaArticulos = " AND Comprable = 1 "

        If cbSubFamilia.SelectedIndex <> -1 Then
            sBusquedaArticulos = sBusquedaArticulos & IIf(sBusquedaArticulos = "", "", " AND ")
            sBusquedaArticulos = sBusquedaArticulos & " Articulos.idsubFamilia = " & cbSubFamilia.SelectedItem.gidsubFamilia
        ElseIf cbFamilia.SelectedIndex <> -1 Then
            sBusquedaArticulos = sBusquedaArticulos & IIf(sBusquedaArticulos = "", "", " AND ")
            sBusquedaArticulos = sBusquedaArticulos & " Articulos.idFamilia = " & cbFamilia.SelectedItem.gidFamilia
        End If

        Call IntroducirArticulos()
    End Sub


    Private Sub GuardarConcepto()
        Dim validar As Boolean = True
        ep1.Clear()
        If Cantidad.Text = "" Or Cantidad.Text = "-" Or Cantidad.Text = "." Or Cantidad.Text = "," Then Cantidad.Text = 0

        If AtiendePeticiones And (dtsCI.gidEstado = EstadoRecibido.gidEstado Or dtsCI.gidEstado = EstadoParcial.gidEstado) Then
            validar = False
            MsgBox("No se puede modificar si ya se ha recibido el pedido a proveedor")
        End If
        If Not AtiendePeticiones And dtsCI.gidEstado <> 0 And (dtsCI.gidEstado <> EstadoNuevo.gidEstado Or (dtsCI.gidEstado = EstadoNuevo.gidEstado And dtsCI.gidCreador <> Inicio.vIdUsuario)) Then
            validar = False
            MsgBox("No se puede modificar una petición ya atendida o generada por otro usuario")
        End If
        If cbArticulo.Text = "" Then
            validar = False
            ep1.SetError(cbArticulo, "Se ha de especificar un artículo")
        End If

        If validar Then

            dtsCI.gArticulo = cbArticulo.Text
            dtsCI.gCantidad = Cantidad.Text
            dtsCI.gcodArticulo = cbCodArticulo.Text
            dtsCI.gFamilia = cbFamilia.Text
            dtsCI.gidArticulo = dtsAR.gidArticulo
            dtsCI.gidUnidad = dtsAR.gidUnidad
            dtsCI.gObservaciones = Observaciones.Text
            dtsCI.gsubFamilia = cbSubFamilia.Text
            dtsCI.gTipoUnidad = dtsAR.gTipoUnidad
            If dtsCI.gidConcepto > 0 Then
                'Actualizar
                If dtsCI.gidEstado = EstadoRecibido.gidEstado Or dtsCI.gidEstado = EstadoParcial.gidEstado Then
                    MsgBox("No se puede modificar una linea recibida")
                Else
                    funcCI.actualizar(dtsCI)
                End If
            Else
                'Guardar
                dtsCI.gidConceptoPedidoProv = 0
                dtsCI.gidEstado = EstadoNuevo.gidEstado
                Estado.Text = EstadoNuevo.gEstado
                dtsCI.gidConcepto = funcCI.insertar(dtsCI)
            End If
            Call LimpiarEdicion()


        End If
    End Sub







#End Region




#Region "BOTONES GENERALES"

    Private Sub bPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPedido.Click
        Dim validar As Boolean = True
        If dtsCI.gidConcepto = 0 Then
            validar = False
            MsgBox("No se ha seleccionado una petición")
        End If
        If dtsCI.gidEstado = EstadoProcesado.gidEstado Then
            validar = False
            ep1.SetError(Estado, "Ya se ha procesado el pedido a proveedor de esta petición")
        End If
        If dtsCI.gidEstado = EstadoRecibido.gidEstado Then
            validar = False
            ep1.SetError(Estado, "Ya se ha recibido el pedido a proveedor de esta petición")
        End If
        If dtsCI.gidArticulo = 0 Then
            validar = False
            ep1.SetError(cbArticulo, "Artículo no definido")
        End If
        If validar Then
            Dim GG As New subPedidoProvDirecto
            GG.pidArticulo = dtsCI.gidArticulo
            GG.pidProveedor = 0
            GG.SoloLectura = vSoloLectura
            GG.pCantidad = dtsCI.gCantidad
            GG.ShowDialog()
            If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                funcCI.actualizaidConceptoPedidoProv(dtsCI.gidConcepto, GG.pidConceptoPedidoProv)
                funcCI.actualizarEstado(dtsCI.gidConcepto, EstadoProcesado.gidEstado)
                Estado.Text = EstadoProcesado.gEstado
                AvisoLeido = False
            End If
        End If
    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Call GuardarConcepto()
        DialogResult = Windows.Forms.DialogResult.OK
        Cambios = False
        MsgBox("Petición realizada correctamente")
        Me.Close()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        dtsCI = New DatosConceptoPedidoInterno
        Call LimpiarEdicion()

    End Sub

    Private Sub bBuscarArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloC.Click
        Dim GG As New BusquedaSimpleArticulo
        GG.pModo = "MPCOMPRABLE"
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()

        If GG.pidArticulo > 0 Then

            dtsAR = funcAR.Mostrar1(GG.pidArticulo)
            cbArticulo.Text = dtsAR.gArticulo
            cbCodArticulo.Text = dtsAR.gcodArticulo
            cbFamilia.Text = dtsAR.gFamilia
            iidFamilia = dtsAR.gidFamilia
            Call introducirSubFamilias()
            cbSubFamilia.Text = dtsAR.gSubFamilia
            lbUnidad.Text = dtsAR.gTipoUnidad

        End If

    End Sub



    Private Sub bBorrarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarConcepto.Click
        If dtsCI.gidConcepto > 0 Then
            Call BorrarConcepto()
        End If
    End Sub

    Private Sub BorrarConcepto()
        If AtiendePeticiones And dtsCI.gidConcepto > 0 Then
            If dtsCI.gidEstado = EstadoRecibido.gidEstado Or dtsCI.gidEstado = EstadoParcial.gidEstado Then
                MsgBox("No se puede borrar una petición ya recibida")
            Else
                funcCI.borrar(dtsCI.gidConcepto)
                Call LimpiarEdicion()
                DialogResult = Windows.Forms.DialogResult.Abort
                Cambios = False
                Me.Close()
            End If
        Else
            If dtsCI.gidEstado <> EstadoNuevo.gidEstado Or (dtsCI.gidEstado = EstadoNuevo.gidEstado And dtsCI.gidCreador <> Inicio.vIdUsuario) Then
                MsgBox("No se puede borrar una petición ya atendida o generada por otro usuario")
            Else
                funcCI.borrar(dtsCI.gidConcepto)
                Call LimpiarEdicion()
                DialogResult = Windows.Forms.DialogResult.Abort
                Cambios = False
                Me.Close()
            End If
        End If

    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indice > 0 Then
            indice = indice - 1
            Call CargarConcepto()
        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indice < IDsConceptos.Count - 1 Then
            indice = indice + 1
            Call CargarConcepto()
        End If
    End Sub


#End Region


#Region "EVENTOS"



    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted

        If cbFamilia.SelectedIndex > -1 Then
            iidFamilia = cbFamilia.SelectedItem.gidFamilia
            Call introducirSubFamilias()
            Call BusquedaArticulos()
            Cambios = True
        End If

    End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex > -1 Then
            Call BusquedaArticulos()
            Cambios = True
        End If
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If cbCodArticulo.SelectedIndex <> -1 Then
            dtsAR = funcAR.Mostrar1(cbCodArticulo.SelectedItem.itemdata)
            cbArticulo.Text = dtsAR.gArticulo
            cbFamilia.Text = dtsAR.gFamilia
            iidFamilia = dtsAR.gidFamilia
            Call introducirSubFamilias()
            cbSubFamilia.Text = dtsAR.gSubFamilia
            lbUnidad.Text = dtsAR.gTipoUnidad
        End If
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If cbArticulo.SelectedIndex <> -1 Then
            dtsAR = funcAR.Mostrar1(cbArticulo.SelectedItem.itemdata)
            cbCodArticulo.Text = dtsAR.gcodArticulo
            cbFamilia.Text = dtsAR.gFamilia
            iidFamilia = dtsAR.gidFamilia
            Call introducirSubFamilias()
            cbSubFamilia.Text = dtsAR.gSubFamilia
            lbUnidad.Text = dtsAR.gTipoUnidad
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, Estado.Click
        sender.selectall()
    End Sub



    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress, Estado.KeyPress

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
        If KeyAscii = Keys.Enter Then
            Call GuardarConcepto()
        End If
    End Sub

    Private Sub Observaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Observaciones.TextChanged, Cantidad.TextChanged, cbCodArticulo.TextChanged, cbArticulo.TextChanged
        Cambios = True
    End Sub

#End Region









End Class