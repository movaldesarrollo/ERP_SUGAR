Public Class DibujarVistaCompleta

    Private myTimer As New System.Windows.Forms.Timer()
    Private Matriz(,) As CeldaVista
    Private Vista As Object
    Private sVista As String
    Private Titulo As String
    Private ContadorFilas As Integer
    Private ContadorColumnas As Integer
    Private iAgrupaciones As New Agrupaciones
    Private verAgrupaciones As Boolean
    Private ColumnasFijasIzquierda As Integer '= 3
    Private FilasFijasArriba As Integer '= 4
    Private FilasFijasAbajo As Integer '= 2
    'Private listaClientes As List(Of ClienteSeleccion)
    Private clbClienteUbicacionAbierto, clbClienteUbicacionNormal As Point
    Private ActualizaAhora As Boolean = False

    Public Property pTitulo() As String
        Get
            Return Titulo
        End Get
        Set(ByVal value As String)
            Titulo = value
        End Set
    End Property

    Public Property pVista() As String
        Get
            Return sVista
        End Get
        Set(ByVal value As String)
            sVista = value
            'If sVista = "TALLER" Then ColumnasFijasIzquierda = 4
            'If sVista = "VistaTallerAbreviada" Then
            '    ColumnasFijasIzquierda = 0
            '    FilasFijasArriba = 1
            'End If

        End Set
    End Property

    Public Property pColumnasFijasIzquierda() As Integer
        Get
            Return ColumnasFijasIzquierda
        End Get
        Set(ByVal value As Integer)
            ColumnasFijasIzquierda = value
        End Set
    End Property

    Public Property pFilasFijasArriba() As Integer
        Get
            Return FilasFijasArriba
        End Get
        Set(ByVal value As Integer)
            FilasFijasArriba = value
        End Set
    End Property

    Public Property pFilasFijasAbajo() As Integer
        Get
            Return FilasFijasAbajo
        End Get
        Set(ByVal value As Integer)
            FilasFijasAbajo = value
        End Set
    End Property

    Public Property pVerAgrupaciones() As Boolean
        Get
            Return verAgrupaciones
        End Get
        Set(ByVal value As Boolean)
            verAgrupaciones = value
        End Set
    End Property

    Public Property pMaximizar() As Boolean
        Get
            Return Me.WindowState = FormWindowState.Maximized
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.WindowState = FormWindowState.Maximized
            End If

        End Set
    End Property

    Private Sub DibujarVista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Titulo <> "" Then Me.Text = Titulo
        'Me.WindowState = FormWindowState.Maximized
        clbClienteUbicacionNormal = clbClientes.Location
        clbClienteUbicacionAbierto = New Point(clbClienteUbicacionNormal.X, clbClienteUbicacionNormal.Y - 527)

        If verAgrupaciones Then
            DR.Visible = True
            lbTituloPendientes.Visible = True
            clbClientes.Visible = True
        Else
            DR.Visible = False
            lbTituloPendientes.Visible = False
            clbClientes.Visible = False
            dgv.Height = dgv.Height + DR.Height
        End If
        Select Case sVista
            Case "VistaTallerAbreviada"
                Vista = New VistaTallerAbreviada
                Me.Text = "VISTA TALLER ABREVIADA"
            Case "TALLER"
                Vista = New VistaProduccion2
                Vista.pVista = "TALLER"
            Case "ELECTRÓNICA"
                Vista = New VistaProduccion2
                Vista.pVista = "ELECTRÓNICA"
            Case Else
                MsgBox("Vista no definida")
                Me.Close()
        End Select
        AddHandler myTimer.Tick, AddressOf ActualizaTabla
        myTimer.Interval = 120 * 60000 'en milisegundos ''''LUIIIIIIIIIIIIIIIIIIIIIIIIIIISSSSSSSSSSSS
        myTimer.Enabled = True
        dgv.Rows.Clear()
        dgv.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.AutoSize = True
        dgv.MultiSelect = False
        Call ActualizaTabla(Nothing, Nothing)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub DibujarVista_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myTimer.Enabled = False
    End Sub

    Private Sub ActualizaTabla(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        Call ActualizaTabla()
    End Sub

    Private Sub ActualizaTabla()
        Dim PosicionScrollVertical As Integer = dgv.FirstDisplayedScrollingRowIndex
        Dim PosicionScrollHorizontal As Integer = dgv.FirstDisplayedScrollingColumnIndex
        Dim celdaSeleccionada As CeldaVista
        If dgv.SelectedCells.Count = 0 Then
            celdaSeleccionada = Nothing
        Else
            celdaSeleccionada = New CeldaVista
            celdaSeleccionada.gFila = dgv.SelectedCells(0).RowIndex
            celdaSeleccionada.gColumna = dgv.SelectedCells(0).ColumnIndex
        End If
        Matriz = Vista.Mostrar
        Call DibujarDGV()
        'listaClientes = Vista.pListaClientes
        Call CargarClientes()

        If verAgrupaciones Then Call ActualizarAgrupaciones()
        If PosicionScrollHorizontal > dgv.ColumnCount - 1 Then
            PosicionScrollHorizontal = ColumnasFijasIzquierda
            celdaSeleccionada = Nothing
        End If

        If PosicionScrollVertical > dgv.RowCount - 1 Then
            PosicionScrollVertical = FilasFijasArriba
            celdaSeleccionada = Nothing
        End If

        If PosicionScrollVertical > -1 Then dgv.FirstDisplayedScrollingRowIndex = PosicionScrollVertical
        If PosicionScrollHorizontal > -1 Then dgv.FirstDisplayedScrollingColumnIndex = PosicionScrollHorizontal
        If Not celdaSeleccionada Is Nothing AndAlso (celdaSeleccionada.gFila < dgv.Rows.Count And celdaSeleccionada.gColumna < dgv.ColumnCount) Then
            'Si es posible, volvemos a seleccionar una celda seleccionada
            dgv.Rows(celdaSeleccionada.gFila).Cells(celdaSeleccionada.gColumna).Selected = True
        End If
        If Me.WindowState <> FormWindowState.Maximized Then
            Dim Ancho As Integer = 0
            Dim Alto As Integer = 0

            For c = 0 To ContadorColumnas - 1
                Ancho = Ancho + dgv.Columns(c).Width
            Next
            Ancho = Ancho + 40
            For f = 0 To ContadorFilas - 1
                Alto = Alto + dgv.Rows(f).Height
            Next
            Alto = Alto + 50

            Me.Size = New Size(Ancho, Alto + If(DR.Visible, DR.Height, 0))

        End If
    End Sub
   
    Private Sub DibujarDGV()
        Try
            dgv.Rows.Clear()
            ContadorFilas = Matriz.GetLength(0)
            ContadorColumnas = Matriz.GetLength(1) - 1
            dgv.ColumnCount = ContadorColumnas
            dgv.ScrollBars = ScrollBars.Both
            For f As Integer = 0 To ContadorFilas - 1
                Dim fila(ContadorColumnas - 1) As CeldaVista
                For c As Integer = 0 To ContadorColumnas - 1
                    fila(c) = Matriz(f, c)
                Next
                dgv.Rows.Add(fila)
            Next

            For f = 0 To FilasFijasArriba - 1
                dgv.Rows(f).Frozen = True
            Next


            For c = 0 To ColumnasFijasIzquierda - 1
                dgv.Columns(c).Frozen = True
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.ColumnIndex = 0 And e.RowIndex = 0 Then
            Call ActualizaTabla(Nothing, Nothing)
        Else
            If Vista.DobleClick(dgv.Item(e.ColumnIndex, e.RowIndex).Value) Then Call ActualizaTabla(Nothing, Nothing)


        End If
    End Sub

    Private Sub dgv_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        If e.ColumnIndex = 0 And e.RowIndex = 0 Then
            e.Graphics.DrawImage(ERP_SUGAR.My.Resources.Resources.update, e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Right - 6, e.CellBounds.Bottom - 6)
            e.PaintContent(e.ClipBounds)
            e.Handled = True
        Else
            e.CellStyle.Font = e.Value.gFuente
            e.CellStyle.ForeColor = e.Value.gcolorLetra
            e.CellStyle.BackColor = e.Value.gcolorfondo
            e.CellStyle.Alignment = e.Value.gAlineacion
            If (e.ColumnIndex = 1 And e.RowIndex >= FilasFijasArriba) Or (e.ColumnIndex >= ColumnasFijasIzquierda And (e.RowIndex = 3 Or e.RowIndex = 0)) Then
                dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = e.Value.gReferencia2
            End If
        End If

    End Sub

    Private Sub dgv_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick
        'Detectamos botón derecho sobre una celda
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            Dim celda As CeldaVista = dgv.Item(e.ColumnIndex, e.RowIndex).Value
            Vista.BotonDerecho(dgv.Item(e.ColumnIndex, e.RowIndex).Value)
            dgv.CurrentCell.Selected = False
        End If
    End Sub

    Private Sub ActualizarAgrupaciones()
        Dim dtAgrupaciones As DataTable = iAgrupaciones.Mostrar(Vista.pListaClientes)
        DR.DataSource = dtAgrupaciones
    End Sub

    Private Sub CargarClientes()
        clbClientes.Items.Clear()
        For i = 0 To Vista.pListaClientes.Count - 1
            clbClientes.Items.Add(Vista.pListaClientes(i))
            clbClientes.SetItemChecked(i, Vista.pListaClientes(i).gSeleccionado)
        Next

    End Sub

    Private Sub clbClientes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clbClientes.ItemCheck
        Vista.pListaClientes(e.Index).gSeleccionado = e.NewValue
        ActualizaAhora = True
    End Sub

    Private Sub clbClientes_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbClientes.MouseHover
        clbClientes.BringToFront()
        Dim cantidad As Integer = clbClientes.Items.Count
        clbClientes.Location = New Point(clbClienteUbicacionNormal.X, clbClienteUbicacionNormal.Y - (If(cantidad > 3, cantidad - 3, 3) * 17))
        'clbClienteUbicacionAbierto
        clbClientes.Height = 21 + cantidad * 17 '582

        'clbClientes.Width = 277

    End Sub

    Private Sub clbClientes_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbClientes.MouseLeave
        clbClientes.Location = clbClienteUbicacionNormal
        clbClientes.Height = 55
        If ActualizaAhora Then
            Call ActualizaTabla()
            ActualizaAhora = False
        End If

        'clbClientes.Width = 177
    End Sub

    Private Sub DibujarVistaCompleta_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        clbClienteUbicacionNormal = clbClientes.Location
        clbClienteUbicacionAbierto = New Point(clbClienteUbicacionNormal.X, clbClienteUbicacionNormal.Y - 527)
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class