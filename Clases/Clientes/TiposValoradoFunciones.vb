
Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesTiposValorado

    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar() As List(Of DatosTipoValorado)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  * FROM TiposValorado Order By TipoValorado ASC"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTipoValorado)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosTipoValorado
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoValorado") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoValorado
                        dts.gidTipoValorado = linea("idTipoValorado")
                        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
                        lista.Add(dts)
                    End If
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




    Public Function Mostrar1(ByVal iidTipoValorado As Integer) As DatosTipoValorado
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  * FROM TiposValorado WHERE idTipoValorado = " & iidTipoValorado & " Order By TipoValorado ASC"
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoValorado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idValorado") Is DBNull.Value Then
                    Else
                        dts.gidTipoValorado = linea("idTipoValorado")
                        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function




    Public Function TipoValorado(ByVal iidTipoValorado As Integer) As String
        'Devuelve el tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidTipoValorado <> 0 Then
                Dim sel As String = " SELECT TipoValorado FROM TiposValorado WHERE  idTipoValorado = " & iidTipoValorado
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(ob)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    Public Function insertar(ByVal dts As DatosTipoValorado) As Integer
        'Insertar un nuevo producto, si no existe ya el código 
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into TiposValorado (TipoValorado) "
                sel = sel & " values (@TipoValorado) Select @@Identity "
                con.Open()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoValorado", dts.gTipoValorado)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function



    Public Function actualizar(ByVal dts As DatosTipoValorado) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TipoValorado = @TipoValorado WHERE idTipoValorado = @idTipoValorado "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("TipoValorado", dts.gTipoValorado)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using

    End Function





    Public Function Borrar(ByVal iidTipoValorado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from TiposValorado where idTipoValorado = " & iidTipoValorado
                cmd = New SqlCommand(sel, con)
                con.Open()
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function




End Class
