Public Class subRemesa

    Private funcBA As New FuncionesBancos
    Private Titulo As String

    Public Property pFecha() As Date
        Get
            Return dtpFecha.Value.Date
        End Get
        Set(ByVal value As Date)
            dtpFecha.Value = value
        End Set
    End Property

    Public Property pBanco() As String
        Get
            Return cbBanco.Text
        End Get
        Set(ByVal value As String)
            cbBanco.Text = value
        End Set
    End Property

    Public Property pCuenta() As String
        Get
            Return IBAN.Text
        End Get
        Set(ByVal value As String)
            IBAN.Text = value
        End Set
    End Property

    'Public Property pTitulo() As String
    '    Get
    '        Return Titulo
    '    End Get
    '    Set(ByVal value As String)
    '        Titulo = value
    '    End Set
    'End Property

    Private Sub subRemesa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call introducirBancos()
        dtpFecha.Value = Now.Date
    End Sub
    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        IBAN.Text = Replace(IBAN.Text, " ", "")
        IBAN.Text = Microsoft.VisualBasic.Left(IBAN.Text, 4) & " " & Microsoft.VisualBasic.Mid(IBAN.Text, 5, 4) & " " & Microsoft.VisualBasic.Mid(IBAN.Text, 9, 4) & " " & Microsoft.VisualBasic.Mid(IBAN.Text, 13, 4) & " " & Microsoft.VisualBasic.Mid(IBAN.Text, 17, 4) & " " & Microsoft.VisualBasic.Right(IBAN.Text, 4)
        'Titulo = cbBanco.Text & " - " & IBAN.Text
        Me.Close()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        cbBanco.Text = ""
        Me.Close()
    End Sub

    Private Sub introducirBancos()
        Try
            cbBanco.Items.Clear()
            Dim lista As List(Of DatosBanco) = funcBA.Mostrar(True)
            Dim dts As DatosBanco
            For Each dts In lista
                cbBanco.Items.Add(New IDComboBox(dts.gBanco, dts.gidBanco))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class