Public Class GestionAriculosAX

#Region "VARIABLES"

    Dim dtsActual As New datosArticulosAx 'Datos ultima carga.
    Dim iIdArticuloAX As Integer = 0 'Almacena la ID del articulo actual.
    Dim funcAX As New funcionesArticulosAX

#End Region

#Region "CARGA Y CIERRE"

    Private Sub GestionAriculosAX_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If funcAX.cargarArticulosAX(Me) Then



        Else

            MsgBox("Error al cargar los artículos.", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub GestionAriculosAX_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If cambios() Then

            If MsgBox("Hay cambios sin guardar, si continua se perderan. ¿Desea continuar?") = MsgBoxResult.Yes Then

                e.Cancel = True

            End If

        End If

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"
    'Comprueba si ha habido cambios.
    Public Function cambios() As Boolean

        'Si se ha cargado un articulo.
        If iIdArticuloAX > 0 Then



        End If

        Return False

    End Function

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

    End Sub

#End Region

#Region "EVENTOS"



#End Region

End Class