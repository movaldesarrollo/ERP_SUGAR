Imports System.Data.SqlClient

Public Class AsignarCantidadPreparada

    Dim conexiones As New conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = conexiones.CadenaConexion()
    Private vsololectura As Boolean
    Private dts As DatosConceptoPedido
    Private funcCP As New FuncionesConceptosPedidos
    Private funcSK As New FuncionesStock
    Private funGP As New GestionPedidoVistaSimple
    Private semaforo As Boolean = False
    Private CantidadPosible As Double
    Private idConcepto As Integer

    Public Sub New(idConcepto As Integer)
        InitializeComponent()
        Me.idConcepto = idConcepto
    End Sub

    Public Property sololectura() As Boolean
        Get
            Return vsololectura
        End Get
        Set(ByVal value As Boolean)
            vsololectura = value
        End Set
    End Property

    Public Property pCantidadPreparada() As Double
        Get
            Return tbCantidadPreparada.Text
        End Get
        Set(ByVal value As Double)
            tbCantidadPreparada.Text = value
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

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click

        Dim CantidadPedida As Double = tbCantidadPedida.Text

        Dim CantidadPreparada As Double = tbCantidadPreparada.Text

        If CantidadPedida < CantidadPreparada Then

            MsgBox("La cantidad introducida es superior a la pedida.", MsgBoxStyle.Information)

            tbCantidadPreparada.Focus()

        Else

            Dim actualizar As Boolean = funGP.actualizarCantidadPreparada(idConcepto, tbCantidadPreparada.Text)

            If actualizar Then

                MessageBox.Show("Se asigno correctamente la cantidad preparada", "ADVERTENCIA")

                Me.Close()

            Else

                MessageBox.Show("No se ha podido asignar la cantidad preparada")

                'Me.Close()

            End If

        End If

    End Sub

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        tbCantidadPreparada.Text = 0

        Me.Close()

    End Sub

    Private Sub tbCantidadPreparada_TextChanged(sender As Object, e As EventArgs) Handles tbCantidadPreparada.TextChanged

        If semaforo Then
            If tbCantidadPreparada.Text <> "" Then
                If tbStock.Text = "" Then tbStock.Text = 0
                If (tbCantidadPreparada.Text > dts.gCantidad - dts.gCantidadServida) Then
                    tbCantidadPreparada.Text = dts.gCantidad - dts.gCantidadServida
                End If
                If tbCantidadPreparada.Text > CantidadPosible Then
                    tbCantidadPreparada.Text = CantidadPosible
                End If
                If CDbl(tbCantidadPreparada.Text) > CDbl(tbStock.Text) Then
                    tbCantidadPreparada.ForeColor = Color.Red
                Else
                    tbCantidadPreparada.ForeColor = Color.Black
                End If
            End If
        End If

    End Sub

    Private Sub AsignarCantidadPreparada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarDatos()

    End Sub

    Public Sub cargarDatos()

        If idConcepto > 0 Then

            dts = funcCP.Mostrar1(idConcepto)

            tbcodArticulo.Text = dts.gcodArticulo

            tbArticulo.Text = dts.gArticulo

            tbCantidadPedida.Text = dts.gCantidad

            tbStock.Text = funcSK.CantidadStock(idConcepto)

            tbCantidadPreparada.Text = dts.gCantidadPreparada

        Else

            tbCantidadPreparada.Text = 0

            Me.Close()

        End If

    End Sub

End Class