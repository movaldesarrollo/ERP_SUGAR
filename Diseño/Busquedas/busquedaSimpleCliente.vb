Public Class busquedaSimpleCliente

#Region "VARIABLE"

    Private desktopSize As Size
    Private vcodCli As String
    Public vNombre As String = ""
    Public iidCliente As Integer
    Private vsoloLectura As Boolean
    Private funcCL As New funcionesclientes
    Private funcPE As New FuncionesPersonal
    Private Orden As String
    Private colorInactivo As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Clientes As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private VerClientesPropios As Boolean

#End Region

#Region "PROPIEDADES"

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

#End Region

    Private Sub busquedaSimpleCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

        Clientes = New List(Of Integer)

        nombrecomercial.Focus()

        'Call busqueda()

    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Call cerrarformulario()

    End Sub

    Private Sub cerrarformulario()

        lvClientes.Items.Clear()

        CodCli.Text = ""

        nombrecomercial.Text = ""

        Orden = ""

        Me.Close()

    End Sub

    Private Sub busqueda()

        'instrucciones para búsqueda de Cliente
        sBusqueda = ""

        If CodCli.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " codCli like '" & CodCli.Text & "%'"
        End If

        If nombrecomercial.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nombrecomercial like '%" & Replace(nombrecomercial.Text, "'", "''") & "%'"
        End If

        Call ActualizarLV()

    End Sub

    Private Sub ActualizarLV()
        Try
            lvClientes.Items.Clear()

            Clientes.Clear()

            Dim lista As List(Of datoscliente) = funcCL.BusquedaSimple(sBusqueda, Orden)

            For Each dts As datoscliente In lista

                Clientes.Add(dts.gidCliente)
                With lvClientes.Items.Add(dts.gidCliente)
                    .SubItems.Add(dts.gcodCli)
                    .SubItems.Add(dts.gnombrecomercial)
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
                .SubItems(2).Text = dtsCL.gnombrecomercial
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

    Private Sub nif_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CodCli.KeyPress, nombrecomercial.KeyPress
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
            vNombre = lvClientes.Items(indice).SubItems(2).Text
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

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nombrecomercial.TextChanged, CodCli.TextChanged
        Call busqueda()
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        CodCli.Text = ""

        nombrecomercial.Text = ""

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
                Orden = "NombreComercial"
        End Select
        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

End Class