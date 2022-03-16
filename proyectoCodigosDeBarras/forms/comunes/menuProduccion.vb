Public Class menuProduccion

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Public formPadre As Boolean
    Private vidUsuario As Integer
    Private showStock As Boolean

#End Region

#Region "EVENTOS"

    Private Sub menuProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vidUsuario = Inicio.vIdUsuario
        Dim func As New FuncionesPersonal
        showStock = func.verStock(vidUsuario)
    End Sub

    'Salir form
    Private Sub menuProduccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If formPadre Then

            Inicio.Close()

        End If

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

        Dispose()

    End Sub

    'Produccion Equipos
    Private Sub bProduccionEquipos_Click(sender As Object, e As EventArgs) Handles bProduccionEquipos.Click

        Dim gg As New fabricacionEquipos

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    'Produccion celulas
    Private Sub bProduccionCelulas_Click(sender As Object, e As EventArgs) Handles bProduccionCelulas.Click

        Dim gg As New fabricacionCelulas

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    'Produccion celulas industriales
    Private Sub bCelulasIndustriales_Click(sender As Object, e As EventArgs) Handles bCelulasIndustriales.Click

        Dim gg As New fabricacionCelulasIndustriales

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    'Produccion equipos industriales
    Private Sub bEquiposIndustriales_Click(sender As Object, e As EventArgs) Handles bEquiposIndustriales.Click

        Dim gg As New fabricacionEquiposIndustriales

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    'Preparacion lineas.
    Private Sub botonesPreparacion_Click(sender As Object, e As EventArgs) Handles DOMÉSTICO.Click, INDIVIDUAL.Click, INDUSTRIAL.Click, DOMÉSTICO2.Click

        Dim gg As New preparacionPedidos

        gg.lineaTitulo = sender.name

        gg.linea = funcCB.TextoSinAcentos(sender.name)

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    'Vista Simple
    Private Sub bVistaSimple_Click_1(sender As Object, e As EventArgs) Handles bVistaSimple.Click

        Dim gg As New vistaSimple

        gg.Show()

        'gg.Dispose()

    End Sub

    'Final Línea
    Private Sub FINAL_LÍNEA_Click(sender As Object, e As EventArgs) Handles FINAL_LÍNEA.Click

        Dim gg As New finalLinea

        gg.lineaTitulo = Replace(sender.name, "FINAL_", "")

        gg.linea = funcCB.TextoSinAcentos(gg.lineaTitulo)

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    Private Sub Fusibles_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim gg As New etiquetasFusibles

        gg.ShowDialog()

        gg.Dispose()

    End Sub

    Private Sub Inventario_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim GG As New inventario

        GG.ShowDialog()

        GG.Dispose()

    End Sub

    Private Sub btnCuadreStock_Click(sender As Object, e As EventArgs) Handles btnCuadreStock.Click

        If showStock Then

            Dim stock As New CuadreStock

            stock.Show()

            'stock.Dispose()
        Else
            MsgBox("No tienes permisos para ver esta pantalla")
        End If

    End Sub

    Private Sub btnCalculadora_Click(sender As Object, e As EventArgs) Handles btnCalculadora.Click

        Dim calcular As New calculadorFechaPrevista

        calcular.ShowDialog()

        calcular.Dispose()

    End Sub



#End Region

End Class