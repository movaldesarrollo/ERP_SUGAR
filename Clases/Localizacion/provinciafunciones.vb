
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesProvincia
    Inherits conexion
    Dim cmd As SqlCommand


    Public Function mostrar(ByVal iidPais As Integer, Optional ByVal autonomia As String = "x") As List(Of datosProvincia)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If autonomia = "x" Then
                sel = " Select * from Provincias Where idPais = " & iidPais & " order by Provincia "
            Else
                sel = "select AU.autonomia, PR.* from provincias as PR left join autonomias as AU on AU.idautonomia = PR.idautonomia where AU.autonomia='" & autonomia & "'"
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosProvincia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datosProvincia
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosProvincia
                    dts.gidProvincia = linea("idProvincia")
                    dts.gProvincia = If(linea("Provincia") Is DBNull.Value, "", linea("Provincia"))
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

    Public Function Provincia(ByVal iidProvincia As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Provincia from Provincias where idProvincia = " & iidProvincia
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

    Public Function insertar(ByVal dts As datosProvincia) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Provincias (Provincia) values (@Provincia) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("descripcion", dts.gProvincia)
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

    Public Function actualizar(ByVal dts As datosProvincia) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Provincias set Provincia = @Provincia where idProvincia = @idProvincia "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Provincia", dts.gProvincia)
                cmd.Parameters.AddWithValue("idProvincia", dts.gidProvincia)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidProvincia As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Provincias where idProvincia = " & iidProvincia

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
