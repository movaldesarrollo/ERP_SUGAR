Public Class AsignarServir

    Private vsololectura As Boolean
    Private iidConcepto As Long
    Private dts As DatosConceptoPedido
    Private funcCP As New FuncionesConceptosPedidos
    Private funcSK As New FuncionesStock
    Private semaforo As Boolean = False
    Private CantidadPosible As Double

    Public Property sololectura() As Boolean
        Get
            Return vsololectura
        End Get
        Set(ByVal value As Boolean)
            vsololectura = value
        End Set
    End Property

    Public Property pidConcepto() As Long
        Get
            Return iidConcepto
        End Get
        Set(ByVal value As Long)
            iidConcepto = value
        End Set
    End Property

    Public Property pCantidadPreparada() As Double
        Get
            Return CantidadPreparada.Text
        End Get
        Set(ByVal value As Double)
            CantidadPreparada.Text = value
        End Set
    End Property

    Public Property pCantidadPosible() As Double
        Get
            Return CantidadPosible
        End Get
        Set(ByVal value As Double)
            CantidadPosible = value
        End Set
    End Property


    Private Sub AsignarServir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        If iidConcepto > 0 Then
            dts = funcCP.Mostrar1(iidConcepto)
            codArticulo.Text = dts.gcodArticulo
            Articulo.Text = dts.gArticulo
            CantidadPedida.Text = dts.gCantidad
            CantidadServida.Text = dts.gCantidadServida
            Stock.Text = funcSK.CantidadStock(dts.gidArticulo)
            lbUnidad.Text = dts.gTipoUnidad
            lbunidad1.Text = lbUnidad.Text
            lbunidad2.Text = lbUnidad.Text
            lbunidad3.Text = lbUnidad.Text
            If dts.gCantidad > dts.gCantidadServida Then
                CantidadPreparada.Text = dts.gCantidad - dts.gCantidadServida - CantidadPreparada.Text
            Else
                'CantidadPreparada.Text = 0
            End If
            If CantidadPreparada.Text > CantidadPosible And CantidadPosible > 0 Then
                CantidadPreparada.Text = CantidadPosible
            End If
        Else
            CantidadPreparada.Text = 0
            Me.Close()
        End If
        semaforo = True
    End Sub

    Private Sub CantidadPreparada_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CantidadPreparada.Enter
        sender.selectall()
    End Sub



    Private Sub CantidadPreparada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CantidadPreparada.TextChanged
        If semaforo Then
            If CantidadPreparada.Text <> "" Then
                If Stock.Text = "" Then Stock.Text = 0
                If (CantidadPreparada.Text > dts.gCantidad - dts.gCantidadServida) Then
                    CantidadPreparada.Text = dts.gCantidad - dts.gCantidadServida
                End If
                If CantidadPreparada.Text > CantidadPosible Then
                    CantidadPreparada.Text = CantidadPosible
                End If
                If CDbl(CantidadPreparada.Text) > CDbl(Stock.Text) Then
                    CantidadPreparada.ForeColor = Color.Red
                Else
                    CantidadPreparada.ForeColor = Color.Black
                End If
            End If
        End If

    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadPreparada.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(CantidadPreparada.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Me.Close()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        CantidadPreparada.Text = 0
        Me.Close()
    End Sub

End Class