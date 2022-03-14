Public Class subResumenReparacion

    Private inumReparacion As Integer


    Public Property pCodigo() As String
        Get
            Return Codigo.Text
        End Get
        Set(ByVal value As String)
            Codigo.Text = value
        End Set
    End Property

    Public Property pResumenEditable() As String
        Get
            Return ResumenEditable.Text
        End Get
        Set(ByVal value As String)
            ResumenEditable.Text = value
        End Set
    End Property

    Public Property pResumenFijo() As String
        Get
            Return ResumenFijo.Text
        End Get
        Set(ByVal value As String)
            ResumenFijo.Text = value
        End Set
    End Property

    Public Property pImporte() As Double
        Get
            Return Importe.Text
        End Get
        Set(ByVal value As Double)
            Importe.Text = value
        End Set
    End Property

    Public Property pSimbolo() As String
        Get
            Return lbmonedaC.Text
        End Get
        Set(ByVal value As String)
            lbmonedaC.Text = value
        End Set
    End Property

    Public Property pnumReparacion() As Integer
        Get
            Return inumReparacion
        End Get
        Set(ByVal value As Integer)
            inumReparacion = value
        End Set
    End Property



    Private Sub subResumenReparacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If inumReparacion > 0 Then Me.Text = Me.Text & " " & inumReparacion
    End Sub

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub bConvertirResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bConvertirResumen.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bConvertirConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bConvertirConceptos.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Importe.Click
        sender.selectAll()
    End Sub


    Private Sub importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Importe.KeyPress, Codigo.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Importe.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Importe.Text = "" Or Importe.Text = "0" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Importe.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

End Class