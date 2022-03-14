Public Class recuperarEquiposBorrados

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras

#End Region

#Region "EVENTOS"

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        lvEquipos.Items.Clear()

        txCodigoBarras.Clear()

        txTotal.Clear()

    End Sub

    Private Sub bEjecutar_Click(sender As Object, e As EventArgs) Handles bEjecutar.Click

        If lvEquipos.Items.Count > 0 Then

            Dim bolErrores As Boolean

            ProgressBar1.Maximum = lvEquipos.Items.Count

            ProgressBar1.Value = 0

            ProgressBar1.Visible = True

            If MsgBox("Se van a restaurar los números de serie que aparecen en la lista, ¿Está seguro que quiere continuar?.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For Each item In lvEquipos.Items

                    ProgressBar1.Value = ProgressBar1.Value + 1

                    Dim queryInsert As String = ""

                    Select Case item.SubItems(4).text.substring(0, 2)

                        Case "CD"
                            queryInsert = "Insert into celulas (numserie, idArticulo, fechaFabricacion, idCreador, celNumserie) 
values (0," & item.text & ", '" & item.SubItems(2).text & "'," & item.SubItems(3).text & ",  '" & item.SubItems(4).text & "')"
                        Case "ED"
                            queryInsert = "Insert into Equipos (numserie, idArticulo, fechaFabricacion, idCreador, EquNumserie) 
values (0," & item.text & ", '" & item.SubItems(2).text & "'," & item.SubItems(3).text & ",  '" & item.SubItems(4).text & "')"
                        Case "CI"
                            queryInsert = "Insert into celulasIndustriales (numserie, idArticulo, fechaFabricacion, idCreador, CelIndNumserie) 
values (0," & item.text & ", '" & item.SubItems(2).text & "'," & item.SubItems(3).text & ",  '" & item.SubItems(4).text & "')"
                        Case "EI"
                            queryInsert = "Insert into equiposIndustriales (numserie, idArticulo, fechaFabricacion, idCreador, equIndNumserie) 
values (0," & item.text & ", '" & item.SubItems(2).text & "'," & item.SubItems(3).text & ",  '" & item.SubItems(4).text & "')"
                    End Select

                    If funcCB.RestaurarNúmSerie(queryInsert) Then

                        If funcCB.BorrarNumSerieFueraInventario(item.SubItems(4).text) Then

                            item.remove()

                            Application.DoEvents()

                        End If

                    Else

                        bolErrores = True

                    End If

                Next

                ProgressBar1.Visible = False

                If bolErrores Then

                    MsgBox("No se han podido restaurar todos los números de serie.", MsgBoxStyle.Information)

                Else

                    MsgBox("Los números de serie se han restaurado correctamente.", MsgBoxStyle.Information)

                End If

            End If

        End If

    End Sub

    Private Sub txCodigoBarras_KeyDown(sender As Object, e As KeyEventArgs) Handles txCodigoBarras.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim bolEsProducto As Boolean = True

            Dim query As String = ""

            Select Case txCodigoBarras.Text.Substring(0, 2)

                Case "CD"
                    query = "select count(*) from celulas where celNumSerie = '" & txCodigoBarras.Text & "'"
                Case "ED"
                    query = "select count(*) from equipos where EquNumSerie = '" & txCodigoBarras.Text & "'"
                Case "CI"
                    query = "select count(*) from celulasIndustriales where celIndNumSerie = '" & txCodigoBarras.Text & "'"
                Case "EI"
                    query = "select count(*) from equiposIndustriales where EquIndNumSerie = '" & txCodigoBarras.Text & "'"
                Case Else
                    bolEsProducto = False
            End Select

            If bolEsProducto Then

                If comprobarNumSerieExisteEnLVEquipos() Then

                    MsgBox("El numero introducido ya está en la lista.", MsgBoxStyle.Information)

                Else

                    If funcCB.comprobarNumSerieStock(query) Then

                        If funcCB.comprobarNumSerieOutStock(Me) = False Then

                            MsgBox("Este número de serie no existe en los productos eliminados de stock.", MsgBoxStyle.Information)

                        End If

                    Else

                        MsgBox("Este número de serie ya existe en el stock.", MsgBoxStyle.Information)

                    End If

                End If

            Else

                MsgBox("El código introducido no corresponde a ningún número de serie válido.", MsgBoxStyle.Information)

            End If

            txCodigoBarras.Clear()

            txCodigoBarras.Focus()

        End If

    End Sub


#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Public Function comprobarNumSerieExisteEnLVEquipos() As Boolean

        For Each item In lvEquipos.Items

            If item.SubItems(4).text = txCodigoBarras.Text Then

                Return True

            End If

        Next

    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ckActivarFecha.CheckedChanged

        If sender.checked Then

            dtpFechaInventario.Visible = True

            txCodigoBarras.Enabled = False

            funcCB.llenarLvEquiposEliminados(Me)

        Else

            lvEquipos.Items.Clear()

            txCodigoBarras.Clear()

            dtpFechaInventario.Visible = False

            txCodigoBarras.Enabled = True

        End If

    End Sub

    Private Sub dtpFechaInventario_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInventario.ValueChanged

        funcCB.llenarLvEquiposEliminados(Me)

    End Sub

#End Region

End Class