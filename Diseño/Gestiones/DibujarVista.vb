Public Class DibujarVista

    Private myTimer As New System.Windows.Forms.Timer()
    Private Matriz As Object
    Private Vista As Object
    Private sVista As String
    Private Titulo As String
    Private ContadorFilas As Integer
    Private ContadorColumnas As Integer

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
        End Set
    End Property

    Private Sub DibujarVista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Titulo <> "" Then Me.Text = Titulo
        Select Case sVista
            Case "VistaTallerAbreviada"
                Vista = New VistaTallerAbreviada
                Me.Text = "VISTA TALLER ABREVIADA"
            Case Else
                MsgBox("Vista no definida")
                Me.Close()
        End Select

        AddHandler myTimer.Tick, AddressOf ActualizaTabla
        myTimer.Interval = 1 * 60000 'en milisegundos
        myTimer.Enabled = True
        dgv.Rows.Clear()

        dgv.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        dgv.AutoSize = True

        Call ActualizaTabla(Nothing, Nothing)

    End Sub

    Private Sub DibujarVista_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myTimer.Enabled = False
    End Sub

    Private Sub ActualizaTabla(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        Matriz = Vista.Mostrar
        Call DibujarDGV()
    End Sub

    Private Sub DibujarDGV()
        Try
            dgv.Rows.Clear()
            ContadorFilas = Matriz.GetLength(0)
            ContadorColumnas = Matriz.GetLength(1)
            dgv.ColumnCount = ContadorColumnas
            For f As Integer = 0 To ContadorFilas - 1
                Dim fila(ContadorColumnas - 1) As CeldaVista
                For c As Integer = 0 To ContadorColumnas - 1
                    fila(c) = Matriz(f, c)
                Next
                dgv.Rows.Add(fila)
            Next


            dgv.Columns(2).Width = 220

            Dim ancho As Integer
            For c = 0 To ContadorColumnas - 1
                ancho = ancho + dgv.Columns(c).Width
            Next
            Me.Width = ancho + 40
            Dim alto As Integer
            For f = 0 To ContadorFilas - 1
                alto = alto + dgv.Rows(f).Height
            Next
            Me.Height = alto + 45
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub dgv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.ColumnIndex = 3 And e.RowIndex > 0 Then
            Dim contenido As String = dgv.Item(e.ColumnIndex, e.RowIndex).Value.gcontenido
            Vista.DobleClick(dgv.Item(e.ColumnIndex, e.RowIndex).Value)
            If contenido <> dgv.Item(e.ColumnIndex, e.RowIndex).Value.gcontenido Then
                Call ActualizaTabla(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgv_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        e.CellStyle.Font = e.Value.gFuente
        e.CellStyle.ForeColor = e.Value.gcolorLEtra
        e.CellStyle.BackColor = e.Value.gcolorfondo
    End Sub


 

  
End Class