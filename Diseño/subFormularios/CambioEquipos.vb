Imports System.IO
Public Class CambioEquipos

#Region "VARIABLES"

    Dim func As New FuncionCambiarEquipos

    Dim listaDatos As List(Of DatosCambiarEquipo)

    Dim tipo As Boolean

#End Region

#Region "CARGA Y CIERRE"

    Private Sub CambioEquipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dimensionamos el form.
        Dim desktopSize As Size
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 65
        Me.Location = New Point(Me.Location.X, 50)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Close()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Limpiar()

    End Sub

    Private Sub btnBuscarPedidoOrigen_Click(sender As Object, e As EventArgs) Handles btnBuscarPedidoOrigen.Click

        BuscarPedidoOrigen()

    End Sub

    Private Sub btnBuscarPedidoDestino_Click(sender As Object, e As EventArgs) Handles btnBuscarPedidoDestino.Click

        BuscarPedidoDestino()

    End Sub

    Private Sub txPedidoOrigen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txPedidoOrigen.KeyPress, txPedidoDestino.KeyPress

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then

            e.Handled = True

        End If

    End Sub

    Private Sub btnTraspasar_Click(sender As Object, e As EventArgs) Handles btnTraspasar.Click

        traspasar()

    End Sub

#End Region

#Region "FUNCIONES"

    Public Sub BuscarPedidoOrigen()

        dgwPedidoOrigen.DataSource = Nothing

        dgwPedidoOrigen.Columns.Clear()

        If Trim(txPedidoOrigen.Text) <> "" Then

            If func.existsPedido(txPedidoOrigen.Text) Then

                tipo = True

                listaDatos = func.BuscarConceptosPedido(txPedidoOrigen.Text, tipo)

                Dim dgvColumnCheck As New DataGridViewCheckBoxColumn

                dgvColumnCheck.Name = ""

                dgvColumnCheck.HeaderText = ""

                dgwPedidoOrigen.Columns.Add(dgvColumnCheck)

                dgwPedidoOrigen.DataSource = listaDatos

                propiedadesDgv(dgwPedidoOrigen)

            Else

                mensaje("El número de Pedido no existe.")

            End If

        Else

            mensaje("No hay nada que buscar")

        End If

    End Sub

    Public Sub BuscarPedidoDestino()

        dgwPedidoDestino.DataSource = Nothing

        dgwPedidoDestino.Columns.Clear()

        If Trim(txPedidoDestino.Text) <> "" Then

            If func.existsPedido(txPedidoDestino.Text) Then

                tipo = False

                listaDatos = func.BuscarConceptosPedido(txPedidoDestino.Text, tipo)

                Dim dgvColumnCheck As New DataGridViewCheckBoxColumn

                Dim dgvColumnCombo As New DataGridViewComboBoxColumn

                dgvColumnCheck.Name = ""

                dgvColumnCheck.HeaderText = ""

                dgwPedidoDestino.Columns.Add(dgvColumnCheck)

                dgwPedidoDestino.DataSource = listaDatos

                dgvColumnCombo.Name = ""

                dgvColumnCombo.HeaderText = "Artículo Alternativo"

                dgwPedidoDestino.Columns.Add(dgvColumnCombo)

                propiedadesDgv(dgwPedidoDestino)

                dgwPedidoDestino.Columns(6).Visible = False


            Else

                mensaje("El número de Pedido no existe.")

            End If

        Else

            mensaje("No hay nada que buscar")

        End If

    End Sub

    Public Sub propiedadesDgv(ByVal dgv As DataGridView)

        dgv.AllowUserToResizeRows = False

        dgv.AllowUserToResizeColumns = False

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        dgv.RowHeadersVisible = False

        dgv.Columns(1).Visible = False

        dgv.Columns(4).Visible = False

        dgv.Columns(5).Visible = False

    End Sub

    Public Sub mensaje(ByVal msg As String)

        MessageBox.Show(msg, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End Sub

    Public Sub Limpiar()

        dgwPedidoOrigen.DataSource = Nothing

        dgwPedidoDestino.DataSource = Nothing

        dgwPedidoDestino.Columns.Clear()

        dgwPedidoOrigen.Columns.Clear()

        txPedidoOrigen.Text = ""

        txPedidoDestino.Text = ""

    End Sub

    Public Function getSelectRowDgv(ByVal dgv As DataGridView) As List(Of DatosCambiarEquipo)

        Dim lista As New List(Of DatosCambiarEquipo)

        For Each row As DataGridViewRow In dgv.Rows

            If Convert.ToBoolean(row.Cells("").Value) Then

                lista.Add(New DatosCambiarEquipo(row.Cells("IdArticulo").Value.ToString, row.Cells("CodArticulo").Value.ToString, row.Cells("NumSerie").Value.ToString, row.Cells("etiquetaImpresa").Value.ToString, row.Cells("EtiquetaImpresaFinal").Value.ToString))

                dgv.EndEdit()

            End If

        Next

        Return lista

    End Function

    Public Sub traspasar()

        Dim listaOrigen As New List(Of DatosCambiarEquipo)

        Dim listaDestino As New List(Of DatosCambiarEquipo)

        listaOrigen = getSelectRowDgv(dgwPedidoOrigen)

        listaDestino = getSelectRowDgv(dgwPedidoDestino)

        Dim cadenaLog As String = ""

        For i As Integer = 0 To listaDestino.Count - 1

            If listaOrigen.Item(i).IdArticulo.Equals(listaDestino.Item(i).IdArticulo) Then

                Dim idEquipo As Integer = func.getIdEquipo(listaOrigen.Item(i).IdArticulo, txPedidoDestino.Text)

                Dim ok As Boolean = False

                ok = func.CambiarNumeroSerie(idEquipo, listaOrigen.Item(i).IdArticulo, txPedidoDestino.Text, listaOrigen.Item(i).NumSerie, listaOrigen.Item(i).EtiquetaImpresa, listaOrigen.Item(i).EtiquetaImpresaFinal)

                If ok Then

                    cadenaLog = cadenaLog & "Se ha traspasado el número de serie  " & listaOrigen.Item(i).NumSerie & " del pedido origen " & txPedidoOrigen.Text & "  al pedido de destino " & txPedidoDestino.Text & vbCrLf

                Else

                    cadenaLog = cadenaLog & "Error No se ha podido traspasar el número de serie " & listaOrigen.Item(i).NumSerie & "  del pedido origen " & txPedidoOrigen.Text & "  al pedido de destino " & txPedidoDestino.Text & vbCrLf

                End If

            Else

                cadenaLog = cadenaLog & "El articulo del número de serie " & listaOrigen.Item(i).NumSerie & " no corresponde a ningún artículo del pedido de destino, por lo tanto no se puede de traspasar el número de serie" & vbCrLf

            End If

        Next

        crearLog(cadenaLog)

        mensaje(cadenaLog)

        Limpiar()

    End Sub

    Public Sub crearLog(ByVal cadenas As String)

        Dim ubicacion As String = Application.StartupPath & "\Log"

        Try

            If Not Directory.Exists(ubicacion) Then

                Directory.CreateDirectory(ubicacion)

            End If

            Dim ruta As String = ubicacion & "\" & Format(Now, "ddMMyyyyhhmmss") & ".txt"

            Dim escritor As StreamWriter

            escritor = File.AppendText(ruta)

            escritor.Write(cadenas)

            escritor.Flush()

            escritor.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txPedidoOrigen_KeyDown(sender As Object, e As KeyEventArgs) Handles txPedidoOrigen.KeyDown

        If e.KeyCode = Keys.Enter Then

            BuscarPedidoOrigen()

        End If

    End Sub

    Private Sub txPedidoDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles txPedidoDestino.KeyDown

        If e.KeyCode = Keys.Enter Then

            BuscarPedidoDestino()

        End If

    End Sub

#End Region

End Class