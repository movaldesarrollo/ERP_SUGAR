Public Class CAMBIAREQUIPOS

    '#Region "VARIABLES"

    '    Dim funcCE As New funcionesCambiarEquipos

    '#End Region

    '#Region "EVENTOS"

    '    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click

    '        busqueda()

    '    End Sub

    '    Private Sub bCambiar_Click(sender As Object, e As EventArgs) Handles bCambiar.Click

    '        cambiar()

    '    End Sub



    '    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

    '        limpiar()

    '    End Sub

    '    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

    '        Close()

    '    End Sub

    '#End Region

    '#Region "FUNCIONES Y PROCEDIMIENTOS"

    '    Private Sub cambiar()

    '        If busqueda() Then

    '            If IsNumeric(txNumPedido.Text) Then

    '                Dim res = MsgBox("Esta seguro que quiere efectuar este proceso?." + vbLf + "Si acepta los cambios serán irreversibles", MsgBoxStyle.YesNo, "ADVERTENCIA")

    '                If res = MsgBoxResult.Yes Then

    '                    If funcCE.cambiarEquipo(lvPedidos, txNumPedido.Text) Then

    '                        busqueda()

    '                        MsgBox("Cambio realizado con éxito.", MsgBoxStyle.Information)

    '                        limpiarTextBox()

    '                    Else

    '                        MsgBox("Error al cambiar el equipo", MsgBoxStyle.Critical)

    '                    End If

    '                End If

    '            Else

    '                MsgBox("Seleccione un número de pedido válido.", MsgBoxStyle.Information)

    '            End If

    '        End If

    '    End Sub


    '    Public Function busqueda()

    '        Try

    '            Dim busquedaBetween As Boolean

    '            Dim ejecutarbusqueda As Boolean

    '            If IsNumeric(txNumserie.Text) Then

    '                If IsNumeric(txNumSerieHasta.Text) Then

    '                    If txNumSerieHasta.Text > txNumserie.Text Then

    '                        busquedaBetween = True

    '                    End If

    '                End If

    '                ejecutarbusqueda = True

    '            Else

    '                ejecutarbusqueda = False

    '            End If

    '            If ejecutarbusqueda Then

    '                If busquedaBetween Then

    '                    funcCE.buscarNumserie(lvPedidos, txNumserie.Text, txNumSerieHasta.Text)

    '                Else

    '                    funcCE.buscarNumserie(lvPedidos, txNumserie.Text, 0)

    '                End If
    '            Else

    '                MsgBox("El número de serie no es correcto.", MsgBoxStyle.Information)

    '            End If

    '            txContador.Text = FormatNumber(lvPedidos.Items.Count, 0)

    '            Return True

    '        Catch ex As Exception

    '            MsgBox(ex.Message)

    '            Return False

    '        End Try

    '    End Function

    '    Sub limpiar()

    '        For Each control In Controls

    '            If TypeOf control Is TextBox Then

    '                control.text = ""

    '            End If

    '        Next

    '        lvPedidos.Items.Clear()

    '        txNumserie.Focus()

    '    End Sub

    '    Sub limpiarTextBox()

    '        For Each control In Controls

    '            If TypeOf control Is TextBox Then

    '                control.text = ""

    '            End If

    '        Next

    '        txContador.Text = FormatNumber(lvPedidos.Items.Count, 0)
    '        txNumserie.Focus()

    '    End Sub

    '#End Region



End Class