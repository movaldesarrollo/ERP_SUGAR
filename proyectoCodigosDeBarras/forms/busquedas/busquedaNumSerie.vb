Public Class busquedaNumSerie

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Dim funBN As New FuncionesBusquedaNumSerie 'Funciones de busqueda de numero de serie.
    Public iIdProducto As Integer 'Id del producto seleccionado mediante numero de serie de fabricación
    Public tipoBusqueda As String 'Es el tipo de producto a buscar, CD = celula domestica, CI = celula industrial, ED= Equipo domestico y EI = equipo industrial.
    Public numSerie As String = "0"
    Public codigo As String = ""

#End Region

#Region "CARGA Y CIERRE"

    'Carga el form.
    Private Sub busquedaNumSerie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmsDesvincular.Visible = funcCB.permisosBusqueda()

        funBN.LlenarCombo(Me)

        funBN.llenarComboMeses(Me)

        If tipoBusqueda = "CD" Or tipoBusqueda = "CI" Then

            funBN.llenarComboAños(Me, "celulas")

        Else

            funBN.llenarComboAños(Me, "equipos")

        End If

        limpiar()

    End Sub

#End Region

#Region "EVENTOS"

    'Sale del form.
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    'Limpia el form.
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Al presionar la tecla entes busca el codigo.
    Private Sub txCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txCode.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Trim(txCode.Text) = "" Then

                funBN.llenarLV(Me, "bBuscar")

            Else

                funBN.llenarLV(Me, sender.name)

            End If

        End If

    End Sub

    'Al presionar la tecla enter busca.
    Private Sub controles_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHasta.KeyDown, dtpDesde.KeyDown,
        cbMeses.KeyDown, cbAños.KeyDown, cbProducto.KeyDown, rbAmbos.KeyDown, rbAsignados.KeyDown, rbNoAsignados.KeyDown

        If e.KeyCode = Keys.Enter Then

            funBN.llenarLV(Me, "bBuscar")

        End If

    End Sub

    'Al presionar el boton buscar llena el listview
    Private Sub bBuscar_Click(sender As Object, e As EventArgs) Handles bBuscar.Click

        funBN.llenarLV(Me, sender.name)

    End Sub

    'Cambio de busqueda de lapso de tiempo entre fechas o mes y año.
    Private Sub rbEntreFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rbEntreFechas.CheckedChanged, rbMesAño.CheckedChanged

        If sender.name = "rbEntreFechas" Then

            If sender.checked Then

                dtpHasta.Enabled = True

                dtpDesde.Enabled = True

                cbAños.Enabled = False

                cbMeses.Enabled = False

            Else

                dtpHasta.Enabled = False

                dtpDesde.Enabled = False

                cbAños.Enabled = True

                cbMeses.Enabled = True

            End If

        End If

    End Sub

    'Si la fecha desde es mayo que la fecha de hasta las igual a la del dtp modificado.
    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged

        If dtpDesde.Value > dtpHasta.Value Then

            dtpDesde.Value = sender.Value

            dtpHasta.Value = sender.Value

        End If

    End Sub

    'Guardar o actualizar
    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        If iIdProducto <> 0 Then

            If numSerie = "0" Then

                If MsgBox("Está seguro que quiere modificar el código " & codigo, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    If funBN.guardar(Me) Then

                        MsgBox("Se ha guardado correctamente.", MsgBoxStyle.Information)

                        limpiar()

                    Else

                        MsgBox("Error al guardar los cambios.", MsgBoxStyle.Critical)

                        limpiar()

                    End If

                End If

            Else

                MsgBox("Este artículo  está vinculado a un pedido y no se puede modificar.", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    'Borrar el item seleccionados.
    Private Sub bBorrar_Click(sender As Object, e As EventArgs) Handles bBorrar.Click

        If iIdProducto <> 0 Then

            If numSerie = "0" Then

                If MsgBox("Está seguro que quiere borrar el código " & codigo, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    If funBN.borrar(Me) Then

                        MsgBox("Se ha borrado correctamente.", MsgBoxStyle.Information)

                        limpiar()

                    Else

                        MsgBox("Error al borrar el producto.", MsgBoxStyle.Critical)

                        limpiar()

                    End If

                End If

            Else

                    MsgBox("Este artículo está vinculado a un pedido y no se puede modificar.", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    'Al hacer doble clic en un item sube los valores de item a los campos y registran la ID
    Private Sub lvProductos_DoubleClick(sender As Object, e As EventArgs) Handles lvProductos.DoubleClick

        For Each item In lvProductos.SelectedItems

            iIdProducto = item.Text
            txCode.Text = item.SubItems(1).Text
            codigo = item.SubItems(1).Text
            cbAños.Text = Year(item.SubItems(2).Text)
            cbMeses.Text = MonthName(Month(item.SubItems(2).Text))
            dtpDesde.Value = item.SubItems(2).Text
            dtpHasta.Value = item.SubItems(2).Text
            cbProducto.Text = item.SubItems(3).Text
            numSerie = item.SubItems(4).Text

        Next

    End Sub

    'Desasignar Pedido
    Private Sub DESVINCULARToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DESVINCULARToolStripMenuItem.Click

        For Each item In lvProductos.SelectedItems

            If MsgBox("¿Está seguro que quiere desvincular este producto de su pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If funcCB.desvicularDePedidos(item.text, item.Subitems(1).text) Then

                    MsgBox("El producto se ha desvinculado correctamente.", MsgBoxStyle.Information)

                Else

                    MsgBox("Error al desvincular el producto", MsgBoxStyle.Critical)

                End If

            End If

        Next

        limpiar()

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Limpia el formulario.
    Public Sub limpiar()

        'Reseteamos el lapso de tiempo.
        rbMesAño.Checked = True
        rbAmbos.Checked = True

        'Llena los combos.
        cbProducto.SelectedIndex = -1
        cbAños.SelectedIndex = -1
        cbMeses.SelectedIndex = -1

        'Limpia los campos de texto.
        txCode.Clear()
        txTotal.Clear()

        'Limpiar los items del listview.
        lvProductos.Items.Clear()

        'Seleccionamos el foco.
        txCode.Focus()

        'Vaciamos la id del producto
        iIdProducto = 0
        numSerie = "0"
        codigo = ""

    End Sub

#End Region

End Class