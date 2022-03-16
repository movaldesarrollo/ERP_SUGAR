Imports System.Data.SqlClient
Imports System.Data.Sql

    Public Class funcionesPoblacion
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As DataTable

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select idpoblacion, idprovincia, poblacion, postal from poblaciones", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function

    Public Function mostrar(ByVal iidProvincia As Integer) As List(Of datospoblacion)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim Lista As New List(Of datospoblacion)
            cmd = New SqlCommand("select idpoblacion, idprovincia, poblacion, postal from poblaciones where idProvincia = " & iidProvincia, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datospoblacion
                For Each linea As DataRow In dt.Rows
                    If linea("idPoblacion") Is DBNull.Value Then
                    Else
                        dts = New datospoblacion
                        dts.gidPoblacion = linea("idPoblacion")
                        dts.gidProvincia = If(linea("idProvincia") Is DBNull.Value, 0, linea("idProvincia"))
                        dts.gPoblacion = If(linea("Poblacion") Is DBNull.Value, "", linea("Poblacion"))
                        dts.gPostal = If(linea("Postal") Is DBNull.Value, 0, linea("Postal"))
                        Lista.Add(dts)
                    End If
                Next
            Else
                con.Close()
            End If
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function

    Public Function mostrar1(ByVal iidPoblacion As Integer) As datospoblacion

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dts As New datospoblacion
            cmd = New SqlCommand("select idpoblacion, idprovincia, poblacion, postal from poblaciones where idPoblacion = " & iidPoblacion, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea As DataRow In dt.Rows
                    If linea("idPoblacion") Is DBNull.Value Then
                    Else
                        dts.gidPoblacion = linea("idPoblacion")
                        dts.gidProvincia = If(linea("idProvincia") Is DBNull.Value, 0, linea("idProvincia"))
                        dts.gPoblacion = If(linea("Poblacion") Is DBNull.Value, "", linea("Poblacion"))
                        dts.gPostal = If(linea("Postal") Is DBNull.Value, 0, linea("Postal"))
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function

    Public Function buscaPoblaciones(ByVal id As Integer) As DataTable  'Devuelve las poblaciones de la provincia 

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select idpoblacion, poblacion, postal from poblaciones where idprovincia = " & id & " order by poblacion", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function

    Public Function encuentrapoblacion(ByVal id As Integer) As String

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim resultado As String = ""
            cmd = New SqlCommand("select poblacion from poblaciones where idpoblacion = " & id, con)
            con.Open()

            Return cmd.ExecuteScalar()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try

    End Function






    End Class
