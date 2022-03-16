Public Class preparacionPedidos

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras 'Carga la clase de funciones de código de barras.
    Public linea As String 'Nombre de la linea
    Public lineaTitulo As String 'Título de la linea.
    Public cargaCompleta As Boolean 'Devuelve true si la carga del formulario está completa.
    Public formPadre As Boolean
    Public actualizar As New Timer

#End Region

#Region "CARGA Y CIERRE"

    'Carga del formulario.
    Private Sub preparacionPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()

        Timer1.Interval = 2000

        Text = Text & " - " & lineaTitulo 'Cambia el título según la línea.

        cargar() 'Carga los equipos del pedido.

        llenarComboArticulos() 'Llena los combos del formulario.

    End Sub

    'Cierre del formulario.
    Private Sub preparacionPedidos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'Si formPadre es true pregunta si quiere cerrar el programa, esto es para cuando no se muestra la pantalla principal del programa.
        If formPadre Then

            If MsgBox("¿Salir del programa?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then

                e.Cancel = True

            End If

        End If

    End Sub

#End Region

#Region "EVENTOS"

    'Hacer clic en boton salir.
    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    'Hacer clic en boton recargar.
    Private Sub bRecargar_Click(sender As Object, e As EventArgs) Handles bRecargar.Click
        Dim where As String = ""

        If cbArticulos.SelectedIndex <> -1 Then

            where = " and ART.idArticulo = " & cbArticulos.SelectedValue

        End If

        funcCB.actualizarBotonesEquipos(funcCB.EquipoProduccionPedido(lbNumpedido.Text, where, linea), Panel, txTotalizador)

    End Sub

    ' Hacer seleccionar un articulo filtra sobre su id los equipos si la carga ha sido completada..
    Private Sub cbArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArticulos.SelectedIndexChanged

        If cargaCompleta Then

            cargar()

        End If

    End Sub

    'Limpia el formulario.
    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        cbArticulos.SelectedIndex = -1

    End Sub

    'RAMOS
    Private Sub btnDesvincular_Click(sender As Object, e As EventArgs) Handles btnDesvincular.Click

        desvincular()

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim where As String = ""

        If cbArticulos.SelectedIndex <> -1 Then

            where = " and ART.idArticulo = " & cbArticulos.SelectedValue

        End If

        funcCB.actualizarBotonesEquipos(funcCB.EquipoProduccionPedido(lbNumpedido.Text, where, linea), Panel, txTotalizador)

    End Sub


#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    'Llena los combos con los articulos del pedido.
    Public Sub llenarComboArticulos()

        Try
            cargaCompleta = funcCB.llenarComboArticulos(cbArticulos, lbNumpedido.Text, linea)

        Catch ex As Exception

            MsgBox("ERROR AL CARGAR EL COMBOBOX ARTÍCULOS. 1001", MsgBoxStyle.Critical)

        End Try

    End Sub

    'Carga los equipos del pedido.
    Public Function cargar() As Boolean

        Try

            'Crea una lista con los datos del pedido.
            Dim lista As New List(Of datosPreparacionPedidos)

            'Busca el pedido activo de la línea seleccionada.
            lbNumpedido.Text = funcCB.numpedidoActivo(linea)

            'Variable que almacenará los datos de busqueda del SQL.
            Dim where As String = ""



            'Si hay algo seleccionado crea una búsqueda en la variable WHERE
            If cbArticulos.SelectedIndex <> -1 And IsNumeric(cbArticulos.SelectedValue) Then

                where = " and ART.idArticulo = " & cbArticulos.SelectedValue

            End If

            'Llena la listas con los datos del pedido.
            lista = funcCB.EquipoProduccionPedido(lbNumpedido.Text, where, linea)

            Dim totalAsignados As Integer = 0

            Dim totalEquipos As Integer = 0

            If lista.Count > 0 Then

                funcCB.crearBotonesEquipos(lista, Panel)

                Dim totalPreparados As Integer

                Dim totales As Integer

                For Each control In Panel.Controls

                    If control.backcolor = Color.Blue Or control.backcolor = Color.Green Then

                        totalPreparados = totalPreparados + 1

                    End If

                    totales = totales + 1

                Next

                txTotalizador.Text = totalPreparados & " / " & totales

            Else

                txTotalizador.Text = "0 / 0"

            End If

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CARGAR EL PEDIDO. 1002", MsgBoxStyle.Critical)

        End Try

        Return False

    End Function

    'RAMOS - Desvincula el pedido de la linea
    Public Sub desvincular()

        lineaTitulo = funcCB.TextoSinAcentos(lineaTitulo)

        Dim numPedido As String = lbNumpedido.Text

        Dim res As DialogResult = MessageBox.Show("Estas seguro que quieres desvincular el pedido de esta línea?", "ADVERTENCIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)

        If res = DialogResult.OK Then

            funcCB.desvincularPedido(numPedido, lineaTitulo)

            funcCB.borrarBotones(Panel)


            cbArticulos.DataSource = Nothing

            cargar()

            MessageBox.Show("Se desvinculo correctamente")

        End If

    End Sub

#End Region

End Class
