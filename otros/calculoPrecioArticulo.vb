Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class calculoPrecioArticulo

    Dim funC As New conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = funC.CadenaConexion()
    Dim mensaje As String
    Dim comboEscandallos As New ComboBox

    Private Sub calculoPrecioArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Function calcular() As Double

        Dim idescandalloPadre As Integer

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select idEscandallo from escandallos where idArticulo = " & txIdArticulo.Text & " and Activo = 1"
            cmd = New SqlCommand(sel, con)
            con.Open()
            idescandalloPadre = cmd.ExecuteScalar()
            con.Close()
            mensaje = "ID ARTICULO: " & txIdArticulo.Text & vbCrLf & "ID ESCANDALLO: " & idescandalloPadre

            If idescandalloPadre > 0 Then


            End If

            Return True


        Catch ex As Exception

            MsgBox("Existen varias versiones de escandallo activas.", MsgBoxStyle.Information)

            Return Nothing

        End Try

    End Function
    Public Function buscarMateriasPrimas() As Double

        Return 0

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim funES As New escandallosCompletos

        If IsNumeric(Trim(txIdArticulo.Text)) Then

            funES.calcularCosteArticulo(Trim(txIdArticulo.Text))

            MsgBox(funES.totalCoste, MsgBoxStyle.Information)

        End If


    End Sub

End Class