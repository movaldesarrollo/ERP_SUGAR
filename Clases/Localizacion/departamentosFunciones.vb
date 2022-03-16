Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesDepartamentos
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosDepartamento)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from Departamentos order by Departamento "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosDepartamento)
                Dim dts As datosDepartamento
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosDepartamento
                    dts.gidDepartamento = linea("idDepartamento")
                    dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Departamento(ByVal iidDepartamento As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Departamento from Departamentos where idDepartamento = " & iidDepartamento
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
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As datosDepartamento) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Departamentos (Departamento) values (@Departamento) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("descripcion", dts.gDepartamento)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosDepartamento) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Departamentos set Departamento = @Departamento where idDepartamento = @idDepartamento "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Departamento", dts.gDepartamento)
                cmd.Parameters.AddWithValue("idDepartamento", dts.gidDepartamento)

                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidDepartamento As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Departamentos where idDepartamento = " & iidDepartamento

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function



End Class
