
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesAutonomias
    Inherits conexion
    Dim cmd As SqlCommand


    Public Function mostrar(ByVal iidPais As Integer) As List(Of datosAutonomia)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from Autonomias Where idPais = " & iidPais & " order by Autonomia "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosAutonomia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datosAutonomia
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosAutonomia
                    dts.gidAutonomia = linea("idAutonomia")
                    dts.gAutonomia = If(linea("Autonomia") Is DBNull.Value, "", linea("Autonomia"))
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

    Public Function Autonomia(ByVal iidAutonomia As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Autonomia from Autonomias where idAutonomia = " & iidAutonomia
            cmd = New SqlCommand(sel, con)
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

    Public Function insertar(ByVal dts As datosAutonomia) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Autonomias (Autonomia) values (@Autonomia) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("descripcion", dts.gAutonomia)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosAutonomia) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Autonomias set Autonomia = @Autonomia where idAutonomia = @idAutonomia "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Autonomia", dts.gAutonomia)
                cmd.Parameters.AddWithValue("idAutonomia", dts.gidAutonomia)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidAutonomia As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Autonomias where idAutonomia = " & iidAutonomia

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function



End Class
