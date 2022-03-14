Public Class AsignacionComisiones

    Private funcCO As New funcionesComisiones
    Private funcCL As New funcionesclientes
    Private funcPA As New funcionesPaises
    Private funcPE As New FuncionesPersonal
    Private funcCC As New funcionesCambiosComisiones
    Private PaisPorDefecto As datosPais
    Private VerClientesPropios As Boolean
    Private sBusqueda As String
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private Orden As String
    Private Columna As Integer
    Private Direccion As String
    Private semaforo As Boolean
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Dim desktopsize As Size


    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestionComisiones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        bGuardar.Enabled = Not vSoloLectura
        'bBorrar.Enabled = Not vSoloLectura
        Call inicializar()
        Call introducirClientes()
        Call IntroducirResponsables()
        Call introducirPaises()
        Call Limpiar()

    End Sub

    Private Sub GestionComisiones_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Call Busqueda()
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub inicializar()
        ckSeleccion.Location = New Point(lvClientes.Location.X + 6, lvClientes.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        VerClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        If VerClientesPropios Or vSoloLectura Then  'Si solo ve clientes propios, no puede cambiar nada
            bGuardar.Enabled = False
            'bBorrar.Enabled = False
        End If
        PaisPorDefecto = funcPA.mostrar1(1)
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info

    End Sub

    Private Sub Limpiar()
        semaforo = False
        lvClientes.Items.Clear()
        cbProvincia.Text = ""
        cbProvincia.SelectedIndex = -1
        cbAutonomia.Text = ""
        cbAutonomia.SelectedIndex = -1
        Orden = "Cliente ASC, Comercial "
        Direccion = "ASC"
        Columna = 0
        If cbPais.SelectedIndex = -1 OrElse (cbPais.SelectedIndex = 1 And cbPais.Text = PaisPorDefecto.gPais) Then
            'Si el pais no es España, recargamos
            cbPais.Text = PaisPorDefecto.gPais
            cbAutonomia.Items.Clear()
            Call introducirAutonomias()
            cbProvincia.Items.Clear()
            Call introducirProvincias()
        End If
        If Not VerClientesPropios Then
            cbComercial.Text = ""
            cbComercial.SelectedIndex = -1
        End If
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        indice = -1
        'ObservacionesBusqueda.Text = ""
        ' ObservacionesC.Text = ""
        Comision.Text = 0
        ckSeleccion.Checked = False
        semaforo = True
    End Sub



    Private Sub introducirPaises()
        Try
            Dim lista As List(Of datosPais) = funcPA.mostrar
            Dim dts As datosPais
            For Each dts In lista
                cbPais.Items.Add(dts) 'New IDComboBox(dts.gPais, dts.gidPais))
            Next
            cbPais.Text = ""
            cbPais.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub introducirProvincias()
        Try
            cbProvincia.Items.Clear()
            If cbPais.SelectedIndex <> -1 Then
                Dim iidPais As Integer = If(cbPais.SelectedIndex = -1, 1, cbPais.SelectedItem.gidPais)
                Dim func As New funcionesProvincia
                Dim lista As List(Of datosProvincia) = func.mostrar(iidPais)
                Dim dts As datosProvincia
                For Each dts In lista
                    cbProvincia.Items.Add(dts)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirAutonomias()
        cbAutonomia.Items.Clear()
        Dim iidPais As Integer = If(cbPais.SelectedIndex = -1, 1, cbPais.SelectedItem.gidPais)
        Dim funcAU As New funcionesAutonomias
        Dim lista As List(Of datosAutonomia) = funcAU.mostrar(iidPais)
        For Each dts As datosAutonomia In lista
            cbAutonomia.Items.Add(dts)
        Next
    End Sub

    Private Sub IntroducirResponsables()

        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))
        For Each item As IDComboBox In lista
            cbComercial.Items.Add(item)
        Next
        If VerClientesPropios Then
            cbComercial.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbComercial.SelectedIndex = 0
            End If
        Else
            cbComercial.SelectedIndex = -1
        End If

    End Sub


    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next

    End Sub

#End Region


#Region "CARGAR DATOS"






#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()
        sBusqueda = ""
        If cbComercial.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CL.idResponsableCuenta = " & cbComercial.SelectedItem.itemData

        End If

        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CL.NombreComercial like '%" & cbCliente.Text & "%' "
        End If
        If cbPais.SelectedIndex <> -1 And cbPais.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Paises.idPais = " & cbPais.SelectedItem.gidpais
        End If

        If cbProvincia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.Provincia like '" & cbProvincia.Text & "%' "
        End If

        If cbAutonomia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AU.idAutonomia = " & cbAutonomia.SelectedItem.gidAutonomia
        End If
        'If ObservacionesBusqueda.Text <> "" Then
        '    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
        '    sBusqueda = sBusqueda & " CL.Observaciones like '%" & ObservacionesBusqueda.Text & "%' "
        'End If


        'If ObservacionesC.Text <> "" Then
        '    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
        '    sBusqueda = sBusqueda & " CO.Observaciones like '%" & ObservacionesC.Text & "%' "
        'End If

        If cbComercial.SelectedIndex <> -1 Then Call ActualizarLV()

    End Sub

    Private Sub ActualizarLV()
        pbCarga.Value = 0
        pbCarga.Visible = True
        lvClientes.Items.Clear()
        Dim lista As List(Of datosComision) = funcCO.BusquedaClientes(sBusqueda, Orden & " " & Direccion)
        pbCarga.Maximum = lista.Count
        For Each dts As datosComision In lista
            Call NuevaLineaLV(dts)
            pbCarga.Increment(1)
        Next
        Contador.Text = lvClientes.Items.Count
        pbCarga.Visible = False
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As datosComision)
        With lvClientes.Items.Add(" ")
            .SubItems.Add(dts.gidCliente)
            .SubItems.Add(dts.gidComision)
            .SubItems.Add(dts.gCliente)
            .SubItems.Add(dts.gPais)
            .SubItems.Add(dts.gAutonomia)
            .SubItems.Add(dts.gProvincia)
            .SubItems.Add(dts.gComercial)
            .SubItems.Add(If(dts.gPorcentaje = 0, "", FormatNumber(dts.gPorcentaje, 2) & "%"))
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As datosComision)
        If indice <> -1 Then
            With lvClientes.Items(indice)
                .SubItems(2).Text = dts.gidComision
                .SubItems(3).Text = dts.gCliente
                .SubItems(4).Text = dts.gPais
                .SubItems(5).Text = dts.gAutonomia
                .SubItems(6).Text = dts.gProvincia
                .SubItems(7).Text = dts.gComercial
                .SubItems(8).Text = If(dts.gPorcentaje = 0, "", FormatNumber(dts.gPorcentaje, 2) & "%")
            End With
        End If
    End Sub

    Private Function Guardar() As Boolean
        Dim validar As Boolean = True
        If cbComercial.SelectedIndex = -1 Then
            ep1.SetError(cbComercial, "Se ha de seleccionar un comercial")
            validar = False
        End If
        If Not IsNumeric(Comision.Text) Then
            Comision.Text = 0
        End If
        'If indice = -1 Then
        '    validar = False
        'End If
        If validar Then
            Dim iidCliente As Integer
            Dim iidComision As Integer
            Dim dts As datosComision
            For Each item As ListViewItem In lvClientes.CheckedItems
                dts = New datosComision
                iidCliente = item.SubItems(1).Text
                iidComision = item.SubItems(2).Text
                If iidComision > 0 Then
                    dts = funcCO.mostrar1(iidComision)
                    dts.gObservaciones = "" 'ObservacionesC.Text
                    dts.gPorcentaje = Comision.Text
                    funcCO.actualizar(dts)
                ElseIf iidCliente > 0 Then
                    dts = funcCO.mostrar1Cliente(iidCliente)
                    dts.gObservaciones = "" 'ObservacionesC.Text
                    dts.gPorcentaje = Comision.Text
                    dts.gidComision = funcCO.insertar(dts)
                End If

                indice = item.Index
                Call ActualizarLineaLV(dts)
            Next
            Comision.Text = ""
        End If
        Return validar

    End Function

#End Region






#Region "BOTONES GENERALES"

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        If lvClientes.CheckedItems.Count = 0 Then
            MsgBox("No se ha seleccionado ningún cliente")
        Else
            Call Guardar()
        End If


    End Sub




    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvClientes.SelectedItems.Count > 0 Then
            indice = lvClientes.SelectedIndices(0)
            Dim iidComision As Integer = lvClientes.Items(indice).SubItems(1).Text
            If MsgBox("¿Desea eliminar la comisión del cliente seleccionado?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcCO.borrar(iidComision)
            End If

        End If
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call Limpiar()
        Call Busqueda()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim iidCliente As Integer = cbCliente.SelectedItem.itemdata
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = iidCliente
            GG.ShowDialog()
            If GG.pidCliente > 0 Then
                cbCliente.Text = funcCL.campoCliente(iidCliente)
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
            For Each item As ListViewItem In lvClientes.Items
                item.Checked = ckSeleccion.Checked
            Next
            Seleccionados.Text = lvClientes.CheckedItems.Count
            semaforo = True
        End If

    End Sub


    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvClientes.ItemChecked
        If semaforo Then
            Dim cont As Integer = lvClientes.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvClientes.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
            Seleccionados.Text = lvClientes.CheckedItems.Count
        End If
    End Sub

    Private Sub lvClientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvClientes.DoubleClick
        If lvClientes.SelectedItems.Count > 0 Then
            indice = lvClientes.SelectedIndices(0)
            Dim iidCliente As Integer = lvClientes.Items(indice).SubItems(1).Text
            Dim iidComision As Integer = lvClientes.Items(indice).SubItems(2).Text
            Dim dts As datosComision = Nothing
            If iidComision = 0 Then
                dts = funcCO.mostrar1Cliente(iidCliente)
            ElseIf iidComision > 0 Then
                dts = funcCO.mostrar1(iidComision)
            End If
            If Not dts Is Nothing Then
                cbCliente.Text = dts.gCliente
                If cbPais.SelectedIndex = -1 OrElse cbPais.SelectedItem.gidPais <> dts.gidPais Then
                    'Si el pais no es el seleccionado, recargamos
                    cbPais.Text = dts.gPais
                    Call introducirAutonomias()
                    Call introducirProvincias()
                End If
                cbProvincia.Text = dts.gProvincia
                cbAutonomia.Text = dts.gAutonomia
                'ObservacionesBusqueda.Text = ""
                'ObservacionesC.Text = dts.gObservaciones
                cbComercial.Text = dts.gComercial
                Comision.Text = FormatNumber(dts.gPorcentaje, 2)
            End If

        End If

    End Sub

    Private Sub Comision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Comision.Click
        sender.selectall()
    End Sub

    Private Sub Comision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Comision.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Comision.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            'If ConceptosEditables Then Call GuardarConcepto()
        End If
    End Sub

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged, cbProvincia.SelectedIndexChanged, _
   cbAutonomia.SelectedIndexChanged, cbPais.SelectedIndexChanged, cbComercial.SelectedIndexChanged
        If semaforo Then Busqueda()
    End Sub

    Private Sub cbPais_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPais.TextChanged
        If semaforo And cbPais.Text = "" Then Busqueda()
    End Sub


    Private Sub lvClientes_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvClientes.ColumnClick

        If e.Column = Columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If
        Select Case e.Column
            Case 0, 1, 2
                Orden = "CL.idCliente"
            Case 3
                Orden = "Cliente"
            Case 4
                Orden = "Pais"
            Case 5
                Orden = "Autonomia"
            Case 6
                Orden = "Provincia"
            Case 7
                Orden = "Comercial"
            Case 8
                Orden = "Porcentaje"

        End Select

        Columna = e.Column

        Call ActualizarLV()

    End Sub

#End Region





End Class