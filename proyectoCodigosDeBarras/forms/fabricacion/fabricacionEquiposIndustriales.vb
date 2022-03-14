'Formulario para la fabricación de equipos.

Public Class fabricacionEquiposIndustriales

#Region "VARIABLES"

    Dim master As New Master
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

        Dim numSerie As String = master.leerCodigo("EquIndNumSerie", Year(Now))

        If cbEquipos.SelectedIndex <> -1 Then

            If MsgBox("¿Confirma que quiere asignar e imprimir un nuevo equipo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If registrar(numSerie) Then

                    Dim gg As New etiquetasEquiposIndustriales

                    gg.ShowDialog()

                Else

                    MsgBox("Ha habido un problema al registrar el número de serie, contacte con el administrador", MsgBoxStyle.Critical)

                End If

            End If

        Else

            MsgBox("Debe seleccionar un código de artículo.", MsgBoxStyle.Information)

        End If


    End Sub

    Public Function registrar(ByVal numserie As String) As Boolean

        If funcCB.existeCodigoEquipoIndustrial(numserie) Then

            MsgBox("El código introducido ya está asignado a un equipo.", MsgBoxStyle.Information)

        Else

            If funcCB.insertarEquipoIndustrial(numserie, cbEquipos.SelectedValue) Then

                llenarlv()

                Return True

            End If

        End If

    End Function

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

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

    Private Sub btnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click

        Dim gg As New etiquetasEquiposIndustriales

        gg.ckVolverImprimir.Checked = True

        gg.ShowDialog()

    End Sub

    Private Sub btnSeleccionImp_Click(sender As Object, e As EventArgs) Handles btnSeleccionImp.Click

        If MsgBox("¿Desea eliminar las impresoras predeterminadas?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim funcCB As New funcionesCodigosBarras ' acceso a funciones datos de codigos de barras.

            funcCB.borrarImpresoraPredeterminada()

        End If

    End Sub


#End Region

End Class