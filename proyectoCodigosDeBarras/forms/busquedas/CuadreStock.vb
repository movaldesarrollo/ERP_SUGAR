
Public Class CuadreStock

#Region "VARIABLES"

    Dim funcCuadreStock As New FuncionesCuadreStock

    Dim index As String

    Dim hora() As String = {"06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00"}

#End Region

#Region "CARGA Y CIERRE"
    Private Sub CuadreStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFechaHasta.Visible = False

        lbFechaHasta.Visible = False

        lbHora.Location = New Point(553, 66)

        cbHora.Location = New Point(641, 61)

        lbArticulo.Location = New Point(553, 93)

        cbArticulo.Location = New Point(641, 88)

        limpiar()

        llenarHoras()

        cargarComboHora()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        buscar()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If lvCuadreStock.Items.Count > 0 Then

            prbCargaExcel.Value = 0

            prbCargaExcel.Visible = True

            funcCuadreStock.crearExcel(lvCuadreStock, dtFechaDesde.Value, cbHora.SelectedItem, prbCargaExcel)

        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        limpiar()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub cbHora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHora.SelectedIndexChanged, dtFechaDesde.ValueChanged, dtpFechaHasta.ValueChanged, rbCelDomestico.CheckedChanged, rbCelInsdustriales.CheckedChanged, rbEqDomestico.CheckedChanged, rbEqIndustriales.CheckedChanged, chbDomesticos.CheckedChanged, chbIndustriales.CheckedChanged

        cargarComboHora()

    End Sub

    Private Sub chbIndustriales_Click(sender As Object, e As EventArgs) Handles chbIndustriales.Click, chbDomesticos.Click

        rbCelDomestico.Checked = False

        rbCelInsdustriales.Checked = False

        rbEqDomestico.Checked = False

        rbEqIndustriales.Checked = False

    End Sub

    Private Sub rbEqDomestico_Click(sender As Object, e As EventArgs) Handles rbEqDomestico.Click, rbEqIndustriales.Click, rbCelDomestico.Click, rbCelInsdustriales.Click

        chbDomesticos.Checked = False

        chbIndustriales.Checked = False

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Public Sub llenarHoras()

        For Each index In hora

            cbHora.Items.Add(index)

        Next

    End Sub

    Public Sub cargarComboHora()

        If rbEqDomestico.Checked Or rbCelDomestico.Checked Or rbEqIndustriales.Checked Or rbCelInsdustriales.Checked Then

            If cbHora.SelectedItem = "22:00" Then

                funcCuadreStock.llenarCombo(cbArticulo, dtFechaDesde.Value, cbHora.SelectedItem, "23:00", rbEqDomestico.Checked, rbCelDomestico.Checked, rbEqIndustriales.Checked, rbCelInsdustriales.Checked)

            Else

                funcCuadreStock.llenarCombo(cbArticulo, dtFechaDesde.Value, cbHora.SelectedItem, hora(cbHora.SelectedIndex + 1), rbEqDomestico.Checked, rbCelDomestico.Checked, rbEqIndustriales.Checked, rbCelInsdustriales.Checked)

            End If

        End If

        If chbDomesticos.Checked Or chbIndustriales.Checked Then

            If cbHora.SelectedItem = "22:00" Then

                funcCuadreStock.llenarComboLogistica(cbArticulo, dtFechaDesde.Value, cbHora.SelectedItem, "23:00", chbDomesticos.Checked, chbIndustriales.Checked)

            Else

                funcCuadreStock.llenarComboLogistica(cbArticulo, dtFechaDesde.Value, cbHora.SelectedItem, hora(cbHora.SelectedIndex + 1), chbDomesticos.Checked, chbIndustriales.Checked)

            End If


        End If

    End Sub

    Public Sub buscar()

        If rbEqDomestico.Checked Or rbCelDomestico.Checked Or rbEqIndustriales.Checked Or rbCelInsdustriales.Checked Then

            If cbHora.SelectedItem = "22:00" Then

                lvCuadreStock.Items.Clear()

                funcCuadreStock.llenarLv(lvCuadreStock, dtFechaDesde.Value, dtpFechaHasta.Value, cbHora.SelectedItem, "23:00", cbArticulo.SelectedValue, rbEqDomestico.Checked, rbCelDomestico.Checked, rbEqIndustriales.Checked, rbCelInsdustriales.Checked, cbRangoFecha.Checked)

                txTotal.Text = lvCuadreStock.Items.Count

            Else

                lvCuadreStock.Items.Clear()

                funcCuadreStock.llenarLv(lvCuadreStock, dtFechaDesde.Value, dtpFechaHasta.Value, cbHora.SelectedItem, hora(cbHora.SelectedIndex + 1), cbArticulo.SelectedValue, rbEqDomestico.Checked, rbCelDomestico.Checked, rbEqIndustriales.Checked, rbCelInsdustriales.Checked, cbRangoFecha.Checked)

                txTotal.Text = lvCuadreStock.Items.Count

            End If

            If lvCuadreStock.Columns.Count = 6 Then

                lvCuadreStock.Columns.RemoveAt(5)

            End If

        End If

        If chbDomesticos.Checked Or chbIndustriales.Checked Then

            lvCuadreStock.Items.Clear()

            If lvCuadreStock.Columns.Count < 6 Then

                lvCuadreStock.Columns.Add("Fecha Picking").Width = 150

            End If

            If cbHora.SelectedItem = "22:00" Then

                funcCuadreStock.llenarLvLogistica(lvCuadreStock, dtFechaDesde.Value, dtpFechaHasta.Value, cbHora.SelectedItem, "23:00", cbArticulo.SelectedValue, chbDomesticos.Checked, chbIndustriales.Checked, cbRangoFecha.Checked)

            Else

                funcCuadreStock.llenarLvLogistica(lvCuadreStock, dtFechaDesde.Value, dtpFechaHasta.Value, cbHora.SelectedItem, hora(cbHora.SelectedIndex + 1), cbArticulo.SelectedValue, chbDomesticos.Checked, chbIndustriales.Checked, cbRangoFecha.Checked)

            End If

            txTotal.Text = lvCuadreStock.Items.Count

        End If

    End Sub

    Public Sub limpiar()

        lvCuadreStock.Items.Clear()

        cbHora.SelectedIndex = -1

        cbArticulo.SelectedIndex = -1

        txTotal.Text = ""

        dtFechaDesde.Value = Now

        dtpFechaHasta.Value = Now

        rbCelDomestico.Checked = False

        rbCelInsdustriales.Checked = False

        rbEqDomestico.Checked = False

        rbEqIndustriales.Checked = False

        chbDomesticos.Checked = False

        chbIndustriales.Checked = False

        If lvCuadreStock.Columns.Count = 6 Then

            lvCuadreStock.Columns.RemoveAt(5)

        End If

    End Sub

    Private Sub cbRangoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles cbRangoFecha.CheckedChanged

        If cbRangoFecha.Checked Then

            dtpFechaHasta.Visible = True

            lbFechaHasta.Visible = True

            lbHora.Visible = False

            cbHora.Visible = False

            lbArticulo.Location = New Point(553, 93)

            cbArticulo.Location = New Point(641, 88)

        Else
            dtpFechaHasta.Visible = False

            lbFechaHasta.Visible = False

            lbHora.Visible = True

            cbHora.Visible = True

            lbHora.Location = New Point(553, 66)

            cbHora.Location = New Point(641, 61)

            lbArticulo.Location = New Point(553, 93)

            cbArticulo.Location = New Point(641, 88)



        End If

        limpiar()

    End Sub

#End Region

End Class