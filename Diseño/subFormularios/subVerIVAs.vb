Public Class subVerIVAs

    Private ListaIVA As List(Of DatosImportesIVAProv)
    Private RecargoEquivalencia As Boolean

    Public Property pListaIVA() As List(Of DatosImportesIVAProv)
        Get
            Return ListaIVA
        End Get
        Set(ByVal value As List(Of DatosImportesIVAProv))
            ListaIVA = value
        End Set
    End Property

    Public Property pRecargoEquivalencia() As Boolean
        Get
            Return RecargoEquivalencia
        End Get
        Set(ByVal value As Boolean)
            RecargoEquivalencia = value
        End Set
    End Property


    Private Sub subVerIVAs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lvIVAs.Items.Clear()
        For Each dts As DatosImportesIVAProv In ListaIVA
            With lvIVAs.Items.Add(dts.gidConcepto)
                .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
                .SubItems.Add(FormatNumber(dts.gTipoIVA, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
                If RecargoEquivalencia Then
                    .SubItems.Add(FormatNumber(dts.gTipoRecargoEq, 2) & "%")
                    .SubItems.Add(FormatNumber(dts.gTotalRE, 2) & dts.gSimbolo)
                Else
                    .SubItems.Add("")
                    .SubItems.Add("")
                End If

            End With
        Next
    End Sub


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub

End Class