'Formulario para la fabricación de celulas.

Public Class fabricacionCelulasIndustriales

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Dim indice As Integer
    Public cargaCompleta As Boolean

#End Region

#Region "CARGA Y CIERRE"

    Private Sub fabricacionCelulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bBusquedaCelula.Visible = funcCB.permisosBusqueda()

        cargarComboArticulos()

        limpiar()

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Limpia el formulario.
    Public Sub limpiar()

        cbCelulas.BackColor = SystemColors.Window

        cbCelulas.SelectedIndex = -1

        cbCelulas.Text = "SELECCIONE UNA CÉLULA."

        dtpFecha.Value = Now()

        txCode.Text = ""

        indice = 0

        llenarlv()

        txCode.Focus()

    End Sub

    'Llenar listview
    Public Sub llenarlv()

        lvCelulas.Items.Clear()

        cargaCompleta = funcCB.llenarLvCelulasIndustriales(lvCelulas, dtpFecha.Value, If(IsNumeric(cbCelulas.SelectedValue), cbCelulas.SelectedValue, 0))

        txTotalCelulas.Text = FormatNumber(lvCelulas.Items.Count, 0)

    End Sub

    Public Sub cargarComboArticulos()

        funcCB.buscarCelulasIndustriales(cbCelulas)

    End Sub

#End Region

#Region "EVENTOS"

    'Imprimir etiquetas.
    Private Sub bEtiquetas_Click(sender As Object, e As EventArgs) Handles bEtiquetas.Click

        Dim gg As New etiquetasCelulasIndustriales

        gg.ShowDialog()

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Private Sub codArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txCode.KeyDown

        If cbCelulas.SelectedIndex = -1 Then

            MsgBox("Debe seleccionar un código de artículo.", MsgBoxStyle.Information)

            sender.text = ""

        Else

            If e.KeyCode = Keys.Enter Then

                If txCode.Text.Contains("CI") Then

                    If funcCB.existeCodigoCelulaIndustrial(txCode.Text) Then

                        MsgBox("El código introducido ya está asignado a una célula.", MsgBoxStyle.Information)

                    ElseIf funcCB.codigoImpresoCelulaIndustrial(txCode.Text) Then

                        MsgBox("El código introducido no ha sido impreso.", MsgBoxStyle.Information)

                    Else

                        funcCB.insertarCelulaIndustrial(txCode.Text, cbCelulas.SelectedValue)

                        llenarlv()

                    End If

                Else

                    MsgBox("El código introducido no pertenece a una célula.", MsgBoxStyle.Information)

                End If

                txCode.Text = ""

            End If

        End If

    End Sub

    Private Sub cbCelulas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCelulas.SelectedIndexChanged

        If cbCelulas.SelectedIndex <> -1 And cargaCompleta Then

            cbCelulas.BackColor = SystemColors.Window

            llenarlv()

            txCode.Focus()

        End If

    End Sub

    Private Sub lvCelulas_DoubleClick(sender As Object, e As EventArgs) Handles lvCelulas.DoubleClick

        For Each item In lvCelulas.SelectedItems

            If item.SubItems(5).text = 0 Then

                indice = item.text

            Else

                indice = 0

            End If

            txCode.Text = item.SubItems(1).text
            cbCelulas.SelectedValue = item.SubItems(4).text
            dtpFecha.Text = item.SubItems(3).text

        Next

    End Sub

    Private Sub bBorrarCelula_Click(sender As Object, e As EventArgs) Handles bBorrarCelula.Click

        If indice <> 0 Then

            funcCB.borrarCelulasIndustriales(indice)

            limpiar()

        End If

    End Sub

    Private Sub bBusquedaCelula_Click(sender As Object, e As EventArgs) Handles bBusquedaCelula.Click

        Dim bc As New busquedaNumSerie

        bc.tipoBusqueda = "CI"

        bc.ShowDialog()

    End Sub

    'Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged

    '    llenarlv()

    'End Sub

#End Region

End Class