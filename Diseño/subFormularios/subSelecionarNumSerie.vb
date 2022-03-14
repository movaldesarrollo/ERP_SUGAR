Public Class subSelecionarNumSerie

    Private Cuantas As Integer
    Private PrimerNumSerie As Integer
    Private ep1 As New ErrorProvider
    Private Validar As Boolean
    Private funcEQ As New FuncionesEquiposProduccion

    Public Property pCuantas() As Integer
        Get
            Return Cuantas
        End Get
        Set(ByVal value As Integer)
            Cuantas = value
        End Set
    End Property

    Public Property pnumSerieDesde() As Integer
        Get
            Return NumSerieDesde.Text
        End Get
        Set(ByVal value As Integer)
            PrimerNumSerie = value
        End Set
    End Property

    Public Property pTitulo() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Private Sub subSelecionarNumSerie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Cuantas = 1 Then
            lbAsignar.Text = "ASIGNAR NÚMERO DE SERIE"
            NumSerieHasta.Visible = False
        Else
            lbAsignar.Text = "ASIGNAR " & Cuantas & " NÚMEROS DE SERIE ENTRE"
        End If

        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        NumSerieDesde.Text = PrimerNumSerie

        NumSerieHasta.Text = NumSerieDesde.Text + Cuantas - 1
        Validar = False
    End Sub




    Private Sub NumSerieDesde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumSerieDesde.TextChanged
        If NumSerieDesde.Text = "" Then NumSerieDesde.Text = 0
        NumSerieHasta.Text = NumSerieDesde.Text + Cuantas - 1
        Dim PrimerNumSerieExistente As Integer = -1
        For x As Integer = NumSerieDesde.Text To NumSerieHasta.Text
            If funcEQ.ExistenumSerie(x, 0) And PrimerNumSerieExistente = -1 Then
                PrimerNumSerieExistente = x
            End If
        Next
        If PrimerNumSerieExistente = -1 Then
            ep1.Clear()
            Validar = True
        Else
            ep1.SetError(NumSerieDesde, "Número de serie ya utilizado " & PrimerNumSerieExistente)
            Validar = False
        End If

    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If NumSerieDesde.Text = "" Then NumSerieDesde.Text = 0
        If Validar Or PrimerNumSerie = NumSerieDesde.Text Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub numSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumSerieDesde.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


End Class