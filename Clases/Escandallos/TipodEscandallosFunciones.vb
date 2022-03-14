'Se compone de las funciones de tipo de escandallo.

Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesTiposEscandallos

    Inherits conexion

    Dim cmd As SqlCommand

    'Crea una lista con los tipos de escandallos.
    Public Function Mostrar() As List(Of DatosTipoEscandallo)

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT  * FROM TiposEscandallo Order By TipoEscandallo ASC"

            cmd = New SqlCommand(sel, con)

            Dim lista As New List(Of DatosTipoEscandallo)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim dts As DatosTipoEscandallo

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idTipoEscandallo") Is DBNull.Value Then

                    Else

                        dts = New DatosTipoEscandallo

                        dts.gidTipoEscandallo = linea("idTipoEscandallo")

                        dts.gTipoEscandallo = If(linea("TipoEscandallo") Is DBNull.Value, "", linea("TipoEscandallo"))

                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

                        dts.gComposicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))

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

    Public Function Mostrar1(ByVal iidTipoEscandallo As Integer) As DatosTipoEscandallo
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  * FROM TiposEscandallo WHERE idTipoEscandallo = " & iidTipoEscandallo & " Order By TipoEscandallo ASC"
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoEscandallo
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoEscandallo") Is DBNull.Value Then
                    Else
                        dts.gidTipoEscandallo = linea("idTipoEscandallo")
                        dts.gTipoEscandallo = If(linea("TipoEscandallo") Is DBNull.Value, "", linea("TipoEscandallo"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gComposicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))
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



    Public Function TipoEscandallo(ByVal iidTipoEscandallo As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidTipoEscandallo <> 0 Then
                Dim sel As String = " SELECT TipoEscandallo FROM TiposEscandallo WHERE  idTipoEscandallo = " & iidTipoEscandallo
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


    Public Function idTipoComposicion() As Integer
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = " SELECT max(idTipoEscandallo) FROM TiposEscandallo WHERE  composicion =  1"
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar
            con.Close()
            If ob Is DBNull.Value Then
                Return 0
            Else
                Return CInt(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function




    Public Function insertar(ByVal dts As DatosTipoEscandallo) As Integer
        'Insertar un nuevo producto, si no existe ya el código 
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into TiposEscandallo (TipoEscandallo, Descripcion, Composicion) "
                sel = sel & " values (@TipoEscandallo, @Descripcion, @Composicion) Select @@Identity "
                con.Open()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoEscandallo", dts.gTipoEscandallo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Composicion", dts.gComposicion)

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



    Public Function actualizar(ByVal dts As DatosTipoEscandallo) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiposEscandallo set TipoEscandallo = @TipoEscandallo, Descripcion = @Descripcion, Composicion = @Composicion WHERE idTipoEscandallo = @idTipoEscandallo "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoEscandallo", dts.gidTipoEscandallo)
                cmd.Parameters.AddWithValue("TipoEscandallo", dts.gTipoEscandallo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Composicion", dts.gComposicion)
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


    Public Function EnUso(ByVal iidTipoEscndallo As Integer) As Integer

        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = " SELECT  count(idEscandallo) as Contador FROM Escandallos where idTipoEscandallo = " & iidTipoEscndallo

            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function Borrar(ByVal iidTipoEscandallo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from TiposEscandallo where idTipoEscandallo = " & iidTipoEscandallo
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
