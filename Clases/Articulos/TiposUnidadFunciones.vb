Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesTiposUnidad
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar() As List(Of DatosTipoUnidad) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposUnidad  order by TipoUnidad ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTipoUnidad
                Dim lista As New List(Of DatosTipoUnidad)
                For Each linea In dt.Rows
                    If linea("idTipoUnidad") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoUnidad
                        dts.gidTipoUnidad = linea("idTipoUnidad")
                        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
                        lista.Add(dts)
                    End If

                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function






    Public Function TipoUnidad(ByVal iidTipoUnidad As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoUnidad FROM TiposUnidad WHERE idTipoUnidad = " & iidTipoUnidad
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function idTipoUnidad(ByVal TipoUnidad As String) As Integer 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT idTipoUnidad FROM TiposUnidad WHERE TipoUnidad = '" & TipoUnidad & "' "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idTipoUnidadUnidad() As Integer 'Devuelve la id del tipo "u."
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Min(idTipoUnidad) FROM TiposUnidad WHERE TipoUnidad like 'U*' "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function insertar(ByVal dts As DatosTipoUnidad) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into TiposUnidad (TipoUnidad) values (  @TipoUnidad) "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoUnidad", dts.gTipoUnidad)

                con.Open()
                Dim o As Object = cmd.ExecuteNonQuery()
                con.Close()
                If o Is Nothing Then
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

    Public Function Actualizar(ByVal dts As DatosTipoUnidad) As Integer

        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "Update TiposUnidad set TipoUnidad= @TipoUnidad  where idTipoUnidad = @idTipoUnidad "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoUnidad", dts.gTipoUnidad)
                cmd.Parameters.AddWithValue("idTipoUnidad", dts.gidTipoUnidad)
                con.Open()
                Dim o As Object = cmd.ExecuteNonQuery()
                con.Close()
                If o Is Nothing Then
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


    Public Function EnUso(ByVal iidTipoUnidad As Integer) As Integer

        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "declare @Contador int;"
            sel = sel & " set @Contador = (SELECT  count(idConcepto) as Contador FROM ConceptosEscandallos where idTipoUnidad = " & iidTipoUnidad & ") + "
            sel = sel & " (SELECT  count(idArticulo) as Contador FROM Articulos where idTipoUnidad = " & iidTipoUnidad & ") Select @Contador "
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

    Public Function borrar(ByVal iidTipoUnidad As Integer) As Boolean
        'Borramos 

        ' If EnUso(iidTipoUnidad) > 0 Then
        'MsgBox("Esta unidad está en uso. No se puede borrar.")
        'Else
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TiposUnidad where idTipoUnidad = " & iidTipoUnidad
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        'End If
    End Function





End Class



