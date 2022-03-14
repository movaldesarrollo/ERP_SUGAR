Imports iTextSharp.text.pdf
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing
'Formulario para la fabricación de celulas.
Public Class fabricacionCelulas

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Dim master As New Master
    Dim indice As Integer
    Public cargaCompleta As Boolean
    Dim ancho As Integer = 50 'Ancho imagen codigo de barras.
    Dim alto As Integer = 12 'Alto imagen codigo de barras.

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

        cargaCompleta = funcCB.llenarLvCelulas(lvCelulas, dtpFecha.Value, If(IsNumeric(cbCelulas.SelectedValue), cbCelulas.SelectedValue, 0))

        txTotalCelulas.Text = FormatNumber(lvCelulas.Items.Count, 0)

    End Sub

    Public Sub cargarComboArticulos()

        funcCB.buscarCelulas(cbCelulas)

    End Sub

#End Region

#Region "EVENTOS"

    'Imprimir etiquetas.
    Private Sub bEtiquetas_Click(sender As Object, e As EventArgs) Handles bEtiquetas.Click

        Dim numSerie As String = master.leerCodigo("celNumSerie", Year(Now))

        If cbCelulas.SelectedIndex <> -1 Then

            If MsgBox("¿Confirma que quiere asignar e imprimir un nuevo equipo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If registrar(numSerie) Then

                    Dim gg As New etiquetasCelulas

                    gg.ShowDialog()

                    CrearImagenCodigo(numSerie)

                    If gg.ckCable.Checked Then

                        imprimirCodigos()

                    End If

                    funcCB.borrarImagenesCelulasCable()

                Else

                    MsgBox("Ha habido un problema al registrar el número de serie, contacte con el administrador", MsgBoxStyle.Critical)

                End If

            End If

        Else

            MsgBox("Debe seleccionar un código de artículo.", MsgBoxStyle.Information)

        End If

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Public Function registrar(ByVal numserie As String) As Boolean

        If funcCB.existeCodigoCelula(numserie) Then

            MsgBox("El código introducido ya está asignado a una célula.", MsgBoxStyle.Information)

        Else

            If funcCB.insertarCelula(numserie, cbCelulas.SelectedValue) Then

                llenarlv()

                Return True

            End If

        End If

    End Function

    'Private Sub codArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txCode.KeyDown

    '    If cbCelulas.SelectedIndex = -1 Then

    '        MsgBox("Debe seleccionar un código de artículo.", MsgBoxStyle.Information)

    '        sender.text = ""

    '    Else

    '        If e.KeyCode = Keys.Enter Then

    '            If txCode.Text.Contains("CD") Then

    '                If funcCB.existeCodigoCelula(txCode.Text) Then

    '                    MsgBox("El código introducido ya está asignado a una célula.", MsgBoxStyle.Information)

    '                ElseIf funcCB.codigoImpresoCelula(txCode.Text) Then

    '                    MsgBox("El código introducido no ha sido impreso.", MsgBoxStyle.Information)

    '                Else

    '                    If funcCB.insertarCelula(txCode.Text, cbCelulas.SelectedValue) Then

    '                        llenarlv()

    '                    End If


    '                End If

    '            Else

    '                MsgBox("El código introducido no pertenece a una célula.", MsgBoxStyle.Information)

    '            End If

    '            txCode.Text = ""

    '        End If

    '    End If

    'End Sub

    'Imprime los códigos.
    Public Function imprimirCodigos() As Boolean

        Try

            Dim cr As New EtiquetaCelulaCBCable

            Dim settings As ConnectionStringSettings

            settings = ConfigurationManager.ConnectionStrings(1)

            Dim csb As New SqlConnectionStringBuilder

            csb.ConnectionString = settings.ConnectionString

            cr.SetDatabaseLogon(csb.UserID, csb.Password)

            cr.Refresh()

            cr.PrintOptions.PrinterName = funcCB.impresorapredeterminada(3)

            cr.PrintToPrinter(1, False, 1, 0)

            imprimirCodigos = True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Function

    'Crea el codigo en la base de datos.
    Public Sub CrearImagenCodigo(ByVal numeroSerie As Double)

        funcCB.borrarImagenesCelulasCable()

        Dim texto As String = "CD" & numeroSerie

        Dim barcode As New Barcode128

        barcode.StartStopText = True

        barcode.BarHeight = alto

        barcode.Code = texto

        Dim imagen As Image = New System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White))

        funcCB.guardarImagenesCelulasCable(imagen, texto)

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

            funcCB.borrarCelulas(indice)

            limpiar()

        End If

    End Sub

    Private Sub buquedaCelula_Click(sender As Object, e As EventArgs) Handles bBusquedaCelula.Click

        Dim bc As New busquedaNumSerie

        bc.tipoBusqueda = "CD"

        bc.ShowDialog()

    End Sub

    Private Sub btnResetImp_Click(sender As Object, e As EventArgs) Handles btnSeleccionImp.Click

        If MsgBox("¿Desea eliminar las impresoras predeterminadas?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim funcCB As New funcionesCodigosBarras ' acceso a funciones datos de codigos de barras.

            funcCB.borrarImpresoraPredeterminada()

        End If

    End Sub

    Private Sub btnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click

        Dim gg As New etiquetasCelulas

        gg.ckVolverImprimir.Checked = True

        gg.ShowDialog()

        If gg.bImpreso And gg.ckCable.Checked Then


            CrearImagenCodigo(gg.numeroSerie)

            imprimirCodigos()

        End If

    End Sub

#End Region

End Class