Public Class inventario

#Region "VARIABLES"

    Dim funcGE As New funcionesGenerales
    Dim funcCB As New funcionesCodigosBarras
    Dim llenandoListview As Boolean

#End Region

#Region "CARGAR Y CIERRE"
    Private Sub inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        funcGE.redimension(Me)

        cbProductos.Enabled = False

        limpiar()

    End Sub

    Private Sub inventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If lvProductoInventariado.Items.Count > 0 Then


            If MsgBox("Si cierra el formulario se perderán los datos inventariados. ¿Salir de todos modos?. ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Else

                e.Cancel = True

            End If


        End If

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click

        If cbProductos.SelectedIndex <> -1 Then

            llenarlv(cbProductos.SelectedValue)

        Else

            llenarlv()

        End If

    End Sub

    Private Sub txCodigoBarras_KeyDown(sender As Object, e As KeyEventArgs) Handles txCodigoBarras.KeyDown

        If e.KeyCode = Keys.Enter Then

            If cbTipoProductos.SelectedIndex <> -1 Then

                If Trim(sender.text) <> "" Then

                    buscarProducto(sender.text)

                    sender.clear()

                End If

            Else

                sender.clear()

                MsgBox("Debe seleccionar un tipo de producto.", MsgBoxStyle.Information)

                cbTipoProductos.Focus()

            End If

        End If

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Public Function buscarProducto(ByVal codigoBarras As String) As Boolean

        Dim prefijo As String = ""

        Select Case cbTipoProductos.Text
            Case "CELULAS"
                prefijo = "CD"

            Case "CELULAS INDUSTRIALES"
                prefijo = "CI"

            Case "EQUIPOS"
                prefijo = "ED"

            Case "EQUIPOS INDUSTRIALES"
                prefijo = "EI"

        End Select

        If codigoBarras.Substring(0, 2) = prefijo Then

            For Each item In lvProductos.Items

                If item.Subitems(4).text = codigoBarras Then

                    If yaInventariado(codigoBarras) = False Then

                        item.backcolor = Color.Yellow

                        lvProductoInventariado.Items.Add(item.CLONE)

                        txTotalInventariado.Text = FormatNumber(lvProductoInventariado.Items.Count, 0)

                        Return True

                    End If

                End If

            Next

            MsgBox("No se ha encontrado ningun producto con este número de serie.", MsgBoxStyle.Information)

        Else

            MsgBox("Este código no pertenece al tipo de producto seleccionado.", MsgBoxStyle.Information)

        End If

        Return False

    End Function

    Public Function yaInventariado(ByVal codigoBarras As String) As Boolean

        For Each item In lvProductoInventariado.Items

            If item.Subitems(4).text = codigoBarras Then

                Return True

            End If

        Next

        Return False

    End Function

    Public Sub limpiar()

        For Each control In Controls

            If TypeOf control Is TextBox Then

                control.clear()

            End If

            If TypeOf control Is ListView Then

                control.items.clear

            End If

        Next

        For Each control In GroupBox1.Controls

            If TypeOf control Is TextBox Then

                control.clear()

            End If

            If TypeOf control Is ComboBox Then

                control.SelectedIndex = -1

            End If

        Next

        cbTipoProductos.Focus()

    End Sub

    Public Function llenarlv(Optional ByVal idArticulo As Integer = 0) As Boolean

        Try

            If cbTipoProductos.SelectedIndex <> -1 Then

                lvProductos.Items.Clear()

                Dim lista As New List(Of datosProductosStock)

                lista = funcCB.buscarStock(cbTipoProductos.Text, idArticulo)

                If lista Is Nothing Then

                Else

                    If lista.Count > 0 Then

                        For Each dts As datosProductosStock In lista

                            With lvProductos.Items.Add(dts.pIdProducto)

                                .SubItems.Add(dts.pIdArticulo)
                                .SubItems.Add(dts.pCodProducto)
                                .SubItems.Add(dts.pProducto)
                                .SubItems.Add(dts.pnumserie)
                                .SubItems.Add(Format(dts.pFecha, "dd/MM/yyyy"))

                                .Font = New Font("century gothic", 10, FontStyle.Regular)

                            End With

                        Next

                    End If

                End If

                Application.DoEvents()

                txTotalBaseDatos.Text = FormatNumber(lvProductos.Items.Count, 0)

                txTotalInventariado.Text = FormatNumber(lvProductoInventariado.Items.Count, 0)

                Return True

            Else

                MsgBox("Debe seleccionar un tipo de producto.", MsgBoxStyle.Information)

                cbTipoProductos.Focus()

            End If

        Catch ex As Exception

            MsgBox("Error al llenar la lista de productos." & vbCrLf & ex.Message, MsgBoxStyle.Critical)

        End Try

        Return False


    End Function

    Private Sub cbTipoProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoProductos.SelectedIndexChanged


        If cbTipoProductos.SelectedIndex <> -1 Then

            cbProductos.Enabled = True

            llenandoListview = llenarlv()

            funcCB.llenarCombox(cbTipoProductos.Text, cbProductos)

            llenandoListview = False

        Else

            cbProductos.Enabled = False

        End If

    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged

        If IsNumeric(cbProductos.SelectedValue) And llenandoListview = False Then

            llenarlv(cbProductos.SelectedValue)

        End If

    End Sub

    Private Sub pbBaseDatos_Click(sender As Object, e As EventArgs) Handles pbBaseDatos.Click

        If lvProductos.Items.Count > 0 Then

            pbrBasedatos.Maximum = lvProductos.Items.Count + 1

            pbrBasedatos.Value = 0

            pbrBasedatos.Visible = True

            funcCB.ExportarListviewAExcel(lvProductos, "BASE DE DATOS " & cbTipoProductos.Text & " - " & cbProductos.Text & " " & Format(Now, "dd/MM/yyyy"), pbrBasedatos)

        End If

    End Sub

    Private Sub pbInventariado_Click(sender As Object, e As EventArgs) Handles pbInventariado.Click

        If lvProductoInventariado.Items.Count > 0 Then

            pbrInventario.Maximum = lvProductoInventariado.Items.Count + 1

            pbrInventario.Value = 0

            pbrInventario.Visible = True

            funcCB.ExportarListviewAExcel(lvProductoInventariado, "INVENTARIADO " & cbTipoProductos.Text & " - " & cbProductos.Text & " " & Format(Now, "dd/MM/yyyy"), pbrInventario)

        End If

    End Sub

    Private Sub bActualizar_Click(sender As Object, e As EventArgs) Handles bActualizar.Click

        If lvProductos.Items.Count > 0 Then

            If MsgBox("Si continua los productos no seleccionados en amarillo se desvincularan del stock. ¿Desea continuar de todos modos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For Each item In lvProductos.Items

                    If item.backColor <> Color.Yellow Then

                        If funcCB.copiarNoInventariado(item) Then

                            If funcCB.borrarNoInventariado(item.subitems(4).text) Then

                                lvProductos.Items.Remove(item)

                            End If

                        End If

                    End If

                Next

            End If

        End If

        txTotalBaseDatos.Text = FormatNumber(lvProductos.Items.Count, 0)

    End Sub

    Private Sub bRestaurar_Click(sender As Object, e As EventArgs) Handles bRestaurar.Click

        Dim GG As New recuperarEquiposBorrados

        GG.ShowDialog()

    End Sub

#End Region

End Class