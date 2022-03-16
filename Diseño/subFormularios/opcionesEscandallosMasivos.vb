Public Class opcionesEscandallosMasivos
    Public exportar As Boolean

    Private Sub opcionesEscandallosMasivos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If exportar Then

        Else
            If MsgBox("Cancelar la exportación", MsgBoxStyle.YesNo) = MsgBoxResult.No Then

                e.Cancel = True

            End If
        End If

    End Sub
    'CARGAR FORMULARIO
    Private Sub opcionesEscandallosMasivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Inicio.usuario.Text = "ADMON" Then
            bTabla.Visible = True
        End If
        ckCostes.Checked = False
        ckMateriasPrimas.Checked = False
        seleccionarCarpera.RootFolder = Environment.SpecialFolder.Desktop
        txRuta.Text = ""

    End Sub

    'BOTON EXPORTAR
    Private Sub bExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bExportar.Click
        If txRuta.Text = "" Then
            MsgBox("Debe seleccionar una carpeta.", MsgBoxStyle.Information)
            If seleccionarCarpera.ShowDialog() = DialogResult.OK Then

                txRuta.Text = seleccionarCarpera.SelectedPath

                exportar = True

                Me.Close()

            End If
        Else

            exportar = True

            Me.Close()

        End If
    End Sub

    'BOTON SALIR
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    'BOTON BUSCAR RUTA
    Private Sub bBuscarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarRuta.Click
        If seleccionarCarpera.ShowDialog() = DialogResult.OK Then

            txRuta.Text = seleccionarCarpera.SelectedPath

        End If
    End Sub

    Private Sub bTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTabla.Click
        txRuta.Text = ""
        ckCostes.Checked = False
        ckMateriasPrimas.Checked = False
        exportar = True
        Me.Close()
    End Sub
End Class