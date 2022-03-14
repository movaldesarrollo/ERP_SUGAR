Imports System.IO

Public Class subCantidadAcabadaTaller

    Private iidArticulo As Integer
    Private funcCA As New FuncionesMovimientosEquiposAcabados
    Private funcAR As New FuncionesArticulos



    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property



    Private Sub subCantidadAcabadaTaller_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "NUEVAS UNIDADES ACABADAS DE " & Microsoft.VisualBasic.Left(funcAR.Articulo(iidArticulo), 50)

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Call Guardar()
    End Sub

    Private Sub Guardar()
        If Cantidad.Text = "" Or Cantidad.Text = "-" Or Cantidad.Text = "." Or Cantidad.Text = "," Then Cantidad.Text = 0
        If Cantidad.Text <> 0 Then
            Dim dts As New DatosMovimientoEquiposAcabados
            dts.gidArticulo = iidArticulo
            dts.gCantidad = Cantidad.Text
            ' dts.gTraspasado = False
            funcCA.insertar(dts)
        End If

        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc("-") And Len(Cantidad.Text) = 1 And Cantidad.Text <> "-" Then
        Else
            If KeyAscii = Asc(".") Then
                e.KeyChar = ","
            End If
            If Cantidad.Text = "-" Then
                KeyAscii = CShort(SoloNumeros(KeyAscii))
            Else
                If Cantidad.Text = "" Then
                    KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
                Else
                    If InStr(Cantidad.Text, ",") Then
                        KeyAscii = CShort(SoloNumeros(KeyAscii))
                    Else
                        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                    End If
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
       
    End Sub

End Class