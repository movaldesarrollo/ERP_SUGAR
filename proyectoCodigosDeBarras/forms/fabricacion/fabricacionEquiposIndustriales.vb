'Formulario para la fabricación de equipos.

Public Class fabricacionEquiposIndustriales

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Dim indice As Integer
    Public cargaCompleta As Boolean

#End Region

#Region "CARGA Y CIERRE"

    Private Sub fabricacionEquipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bBusquedaEquipo.Visible = funcCB.permisosBusqueda()

        cargarComboArticulos()

        limpiar()

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Limpia el formulario.
    Public Sub limpiar()

        cbEquipos.BackColor = SystemColors.Window

        cbEquipos.SelectedIndex = -1

        cbEquipos.Text = "SELECCIONE UN EQUIPO."

        dtpFecha.Value = Now()

        txCode.Text = ""

        indice = 0

        llenarlv()

        txCode.Focus()

    End Sub

    'Llenar listview
    Public Sub llenarlv()

        lvEquipos.Items.Clear()

        cargaCompleta = funcCB.llenarLvEquiposIndustriales(lvEquipos, dtpFecha.Value, If(IsNumeric(cbEquipos.SelectedValue), cbEquipos.SelectedValue, 0))

        txTotalEquipos.text = FormatNumber(lvEquipos.Items.Count, 0)

    End Sub

    Public Sub cargarComboArticulos()

        funcCB.buscarEquiposIndustriales(cbEquipos)

    End Sub

#End Region

#Region "EVENTOS"

    'Imprimir etiquetas.
    Private Sub bEtiquetas_Click(sender As Object, e As EventArgs) Handles bEtiquetas.Click

        Dim gg As New etiquetasEquiposIndustriales

        gg.ShowDialog()

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Private Sub codArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txCode.KeyDown

        If cbEquipos.SelectedIndex = -1 Then

            MsgBox("Debe seleccionar un código de artículo.", MsgBoxStyle.Information)

            sender.text = ""

        Else

            If e.KeyCode = Keys.Enter Then

                If txCode.Text.Contains("EI") Then

                    If funcCB.existeCodigoEquipoIndustrial(txCode.Text) Then

                        MsgBox("El código introducido ya está asignado a un equipo.", MsgBoxStyle.Information)

                    ElseIf funcCB.codigoImpresoEquipoIndustrial(txCode.Text) Then

                        MsgBox("El código introducido no ha sido impreso.", MsgBoxStyle.Information)

                    Else

                        funcCB.insertarEquipoIndustrial(txCode.Text, cbEquipos.SelectedValue)

                        llenarlv()

                    End If

                Else

                    MsgBox("El código introducido no pertenece a un equipo.", MsgBoxStyle.Information)

                End If

                txCode.Text = ""

            End If

        End If



    End Sub

    Private Sub cbCelulas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEquipos.SelectedIndexChanged

        If cbEquipos.SelectedIndex <> -1 And cargaCompleta Then

            cbEquipos.BackColor = SystemColors.Window

            llenarlv()

            txCode.Focus()

        End If

    End Sub

    Private Sub lvequipos_DoubleClick(sender As Object, e As EventArgs) Handles lvEquipos.DoubleClick

        For Each item In lvEquipos.SelectedItems

            If item.SubItems(5).text = 0 Then

                indice = item.text

            Else

                indice = 0

            End If

            txCode.Text = item.SubItems(1).text

            cbEquipos.SelectedValue = item.SubItems(4).text

            dtpFecha.Text = item.SubItems(3).text

        Next

    End Sub

    Private Sub bBorrarEquipo_Click(sender As Object, e As EventArgs) Handles bBorrarEquipo.Click

        If indice <> 0 Then

            funcCB.borrarEquipoIndustrial(indice)

            limpiar()

        End If

    End Sub

    Private Sub bBusquedaEquipo_Click(sender As Object, e As EventArgs) Handles bBusquedaEquipo.Click

        Dim bc As New busquedaNumSerie

        bc.tipoBusqueda = "EI"

        bc.ShowDialog()

    End Sub

    'Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged

    '    llenarlv()

    'End Sub

#End Region

End Class