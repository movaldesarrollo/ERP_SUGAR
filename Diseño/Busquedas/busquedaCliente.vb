
Public Class busquedaCliente

    Private desktopSize As Size
    Private vcodCli As String
    Public vNombre As String = ""
    Public iidCliente As Integer
    Private vsoloLectura As Boolean
    Private funcCL As New funcionesclientes
    Private funcPE As New FuncionesPersonal
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Clientes As List(Of Integer)
    Private indice As Integer
    Private modo As String
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

    Property pidCliente() As Integer
        Get
            Return iidCliente
        End Get
        Set(ByVal value As Integer)
            iidCliente = value

        End Set
    End Property

    Property pcodCli() As Integer
        Get
            Return vcodCli
        End Get
        Set(ByVal value As Integer)
            vcodCli = value

        End Set
    End Property


    Property pNombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
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

        Orden = ""
        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        direccion = "ASC"
        codContable.Focus()
        Clientes = New List(Of Integer)
        Call IntroducirResponsables()
        Call introducirPaises()
        Call busqueda()
    End Sub


    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call cerrarformulario()
    End Sub

    Private Sub cerrarformulario()
        lvClientes.Items.Clear()
        CodCli.Text = ""
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""
        nif.Text = ""
        Orden = ""
        codContable.Text = ""

        Me.Close()
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

    Private Sub introducirPaises()
        Try
            Dim funcPA As New funcionesPaises
            Dim lista As List(Of datosPais) = funcPA.mostrar
            Dim dts As datosPais
            For Each dts In lista
                cbPaisU.Items.Add(dts) 'New IDComboBox(dts.gPais, dts.gidPais))
            Next
            cbPaisU.Text = ""
            cbPaisU.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirProvincias()
        Try
            cbProvincia.Items.Clear()
            If cbPaisU.SelectedIndex <> -1 Then
                Dim func As New funcionesProvincia
                Dim lista As List(Of datosProvincia) = func.mostrar(cbPaisU.SelectedItem.gidPais)
                Dim dts As datosProvincia
                For Each dts In lista
                    cbProvincia.Items.Add(New IDComboBox(dts.gProvincia, dts.gidProvincia))
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub busqueda()


        'instrucciones para búsqueda de Cliente
        sBusqueda = ""
        If codContable.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " codContable like '" & codContable.Text & "%'"
        End If

        If CodCli.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " codCli like '" & CodCli.Text & "%'"
        End If

        If nif.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nif like '" & nif.Text & "%'"
        End If

        If nombrecomercial.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nombrecomercial like '%" & Replace(nombrecomercial.Text, "'", "''") & "%'"
        End If
        If nombrefiscal.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nombrefiscal like '%" & Replace(nombrefiscal.Text, "'", "''") & "%'"
        End If
        If cbResponsable.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.idResponsableCuenta = " & cbResponsable.SelectedItem.itemdata
        End If

        If ckBajas.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.Activo = 1 "
        Else
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.Activo = 0 "
        End If
        If cbPaisU.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ( Select count(idUbicacion) from Ubicaciones where idCliente = Clientes.idCliente and idPais = " & cbPaisU.SelectedItem.gidPais & ") > 0 "
        End If
        If cbProvincia.Text <> "" Then 'Permitiremos búsquedas por texto y por índice
            If cbProvincia.SelectedIndex = -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ( Select count(idUbicacion) from Ubicaciones where idCliente = Clientes.idCliente and Provincia like '" & cbProvincia.Text & "%' ) > 0 "
            Else
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ( Select count(idUbicacion) from Ubicaciones where idCliente = Clientes.idCliente and Provincia = '" & cbProvincia.Text & "') > 0 "

            End If
        End If
        If subCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ( Select count(idUbicacion) from Ubicaciones where idCliente = Clientes.idCliente and SubCliente like '%" & subCliente.Text & "%') > 0 "
        End If
        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            lvClientes.Items.Clear()
            Clientes.Clear()
            'lvwColumnSorter = New OrdenarLV()
            'lvClientes.ListViewItemSorter = lvwColumnSorter
            Dim lista As List(Of datoscliente) = funcCL.BusquedaRapida(sBusqueda, Orden)
            For Each dts As datoscliente In lista
                Clientes.Add(dts.gidCliente)
                With lvClientes.Items.Add(dts.gidCliente)
                    .SubItems.Add(dts.gcodCli)
                    .SubItems.Add(dts.gcodContable)
                    .SubItems.Add(dts.gnombrecomercial)
                    .SubItems.Add(dts.gnombrefiscal)
                    .SubItems.Add(dts.gnif)
                    .SubItems.Add(dts.gSubClientes)
                    If dts.gActivo Then
                        .ForeColor = Color.Black
                    Else
                        .ForeColor = colorInactivo
                    End If
                End With
            Next
            Contador.Text = lvClientes.Items.Count
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            iidCliente = lvClientes.Items(indice).Text
            Dim dtsCL As datoscliente = funcCL.mostrar1(iidCliente)
            With lvClientes.Items(indice)
                .SubItems(1).Text = dtsCL.gcodCli
                .SubItems(2).Text = dtsCL.gcodContable
                .SubItems(3).Text = dtsCL.gnombrecomercial
                .SubItems(4).Text = dtsCL.gnombrefiscal
                .SubItems(5).Text = dtsCL.gnif
                .SubItems(6).Text = dtsCL.gSubClientes
                If dtsCL.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()
        Contador.Text = lvClientes.Items.Count
    End Sub



    Private Sub idCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codContable.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub



    Private Sub nif_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nif.KeyPress, CodCli.KeyPress, nombrecomercial.KeyPress, nombrefiscal.KeyPress, subCliente.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub




    Private Sub lvClientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvClientes.DoubleClick

        If lvClientes.Items.Count > 0 Then

            indice = lvClientes.SelectedIndices(0)
            iidCliente = lvClientes.Items(indice).Text
            vcodCli = lvClientes.Items(indice).SubItems(1).Text
            vNombre = lvClientes.Items(indice).SubItems(3).Text
            If modo = "B" Then
                Me.Close()
            Else
                Dim GP As New GestionClientes
                GP.pidCliente = lvClientes.SelectedItems(0).Text
                GP.pClientes = Clientes
                GP.SoloLectura = vsoloLectura
                GP.pindice = indice
                GP.ShowDialog()

                Call ActualizarLineaLV()
                Call RecalcularTotalizadores()
            End If
        End If

    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 813
        Me.Height = If(Me.Height < 300, 300, Me.Height)
        'lvClientes.Height = Me.Height - 224
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nif.TextChanged, nombrecomercial.TextChanged, nombrefiscal.TextChanged, CodCli.TextChanged, cbResponsable.SelectedIndexChanged, codContable.TextChanged, ckBajas.CheckedChanged, subCliente.TextChanged
        Call busqueda()
    End Sub


    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoClientes
        GG.verInforme(sBusqueda, Orden)
        GG.ShowDialog()

    End Sub
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        If Not VerClientesPropios Then
            cbResponsable.Text = ""
            cbResponsable.SelectedIndex = -1
        End If
        nombrefiscal.Text = ""
        nif.Text = ""
        CodCli.Text = ""
        nombrecomercial.Text = ""
        codContable.Text = ""
        cbPaisU.Text = ""
        cbPaisU.SelectedIndex = -1
        cbProvincia.Text = ""
        cbProvincia.SelectedIndex = -1
        ckBajas.Checked = False
        subCliente.Text = ""
        Call busqueda()
    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvClientes.ColumnClick

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
                Orden = "idCliente"
            Case 1
                Orden = "codCli"
            Case 2
                Orden = "codContable"
            Case 3
                Orden = "NombreComercial"
            Case 4
                Orden = "NombreFiscal"
            Case 5
                Orden = "NIF"
            Case 6
                Orden = "(Select TOP 1 UPPER(subCliente) as subCliente from Ubicaciones where subCliente <> '' and idCliente = Clientes.idCliente Order By subCliente ASC) "

        End Select
        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionClientes
        GG.pidCliente = 0
        GG.SoloLectura = vsoloLectura
        GG.ShowDialog()
        Call ActualizarLV()

    End Sub

    Private Sub cbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPaisU.SelectionChangeCommitted
        introducirProvincias()
        Call busqueda()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cbProvincia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProvincia.TextChanged
        Call busqueda()
    End Sub

    Private Sub lvClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvClientes.SelectedIndexChanged

    End Sub
End Class