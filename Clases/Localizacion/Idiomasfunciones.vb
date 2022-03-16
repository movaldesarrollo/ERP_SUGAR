

Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesIdiomas
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosIdioma)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of datosIdioma)
            cmd = New SqlCommand("select * from Idiomas ", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datosIdioma
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosIdioma
                    dts.gidIdioma = linea("idIdioma")
                    dts.gIdioma = If(linea("Idioma") Is DBNull.Value, "", linea("Idioma"))

                    lista.Add(dts)
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function Idioma(ByVal iidIdioma As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of datosIdioma)
            cmd = New SqlCommand("select Idioma from Idiomas where idIdioma =" & iidIdioma, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CStr(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class
