Public Class SeleccionConvertirP

    Private Albaran As Boolean = False
    Private Produccion As Boolean = False
    Private cerrar As Boolean
    Public vVistaSimple As Boolean
    Public vGestionPedidos As Boolean

    Public Property pAlbaran() As Boolean
        Get
            Return Albaran
        End Get
        Set(ByVal value As Boolean)
            Albaran = value
        End Set
    End Property

    Public Property pProduccion() As Boolean
        Get
            Return Produccion
        End Get
        Set(ByVal value As Boolean)
            Produccion = value
        End Set
    End Property

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        cerrar = False
        Me.Close()
    End Sub
    Private Sub bAlbaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAlbaran.Click
        cerrar = True
        Albaran = True
        Produccion = False
        Me.Close()
    End Sub

    Private Sub bProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bProduccion.Click
        cerrar = True
        Produccion = True
        Albaran = False
        Me.Close()
    End Sub

    Private Sub SeleccionConvertirP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cerrar Then
        Else
            Albaran = False
            Produccion = False
        End If
    End Sub

    Private Sub SeleccionConvertirP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If vGestionPedidos Then
            bProduccion.Enabled = False
        Else
            bProduccion.Enabled = Produccion
        End If
        If vVistaSimple Then
            bAlbaran.Enabled = False
        Else
            bAlbaran.Enabled = Albaran
        End If

    End Sub
End Class