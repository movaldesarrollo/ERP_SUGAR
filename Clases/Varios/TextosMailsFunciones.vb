Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesTextosMails
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar() As List(Of DatosTextoMail)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TextosMails as TM left join Idiomas ON Idiomas.idIdioma = TM.idIdioma order by Documento ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTextoMail)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTexto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosTextoMail
        Dim dts As New DatosTextoMail
        dts.gidTexto = linea("idTexto")
        dts.gDocumento = If(linea("Documento") Is DBNull.Value, "", linea("Documento"))
        dts.gidIdioma = If(linea("idIdioma") Is DBNull.Value, 0, linea("idIdioma"))
        dts.gTexto = If(linea("Texto") Is DBNull.Value, "", linea("Texto"))
        dts.gAsunto = If(linea("Asunto") Is DBNull.Value, "", linea("Asunto"))
        dts.gIdioma = If(linea("Idioma") Is DBNull.Value, "", linea("Idioma"))

        Return dts
    End Function


    Public Function Mostrar1(ByVal iidTexto As Integer) As DatosTextoMail
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TextosMails as TM left join Idiomas ON Idiomas.idIdioma = TM.idIdioma  where idTexto = " & iidTexto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTextoMail
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTexto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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


    Public Function TextoExiste(ByVal dts As DatosTextoMail) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT idTexto FROM TextosMails where Documento = @Documento and idIdioma = @idIdioma "
            cmd = New SqlCommand(sel, con)
            'cmd.Parameters.AddWithValue("idTexto", dts.gidTexto)
            cmd.Parameters.AddWithValue("Documento", dts.gDocumento)
            cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
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
   
    Public Function Mostrar1(ByVal Documento As String, ByVal iidIdioma As Integer) As DatosTextoMail
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TextosMails as TM left join Idiomas ON Idiomas.idIdioma = TM.idIdioma  where Documento = @Documento and TM.idIdioma = @idIdioma "
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("Documento", Documento)
            cmd.Parameters.AddWithValue("idIdioma", iidIdioma)
            Dim dts As New DatosTextoMail
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTexto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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
  
 



    Public Function insertar(ByVal dts As DatosTextoMail) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into TextosMails (Documento, idIdioma, Texto, Asunto ) values (@Documento, @idIdioma, @Texto, @Asunto ) select @@Identity"
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Documento", dts.gDocumento)
                cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
                cmd.Parameters.AddWithValue("Texto", dts.gTexto)
                cmd.Parameters.AddWithValue("Asunto", dts.gAsunto)
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


    Public Function actualizar(ByVal dts As DatosTextoMail) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TextosMails set Documento = @Documento, idIdioma = @idIdioma, Texto =@Texto, Asunto = @Asunto  WHERE idTexto = @idTexto "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTexto", dts.gidTexto)
                cmd.Parameters.AddWithValue("Documento", dts.gDocumento)
                cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
                cmd.Parameters.AddWithValue("Texto", dts.gTexto)
                cmd.Parameters.AddWithValue("Asunto", dts.gAsunto)
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


    Public Function borrar(ByVal iidTexto As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TextosMails where idTexto = " & iidTexto
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
    End Function



End Class



