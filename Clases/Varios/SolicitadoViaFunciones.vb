Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesSolicitadoVia
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar() As List(Of DatosSolicitadoVia) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM SolicitadoVia Order By SolicitadoVia ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosSolicitadoVia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosSolicitadoVia
                For Each linea In dt.Rows
                    dts = New DatosSolicitadoVia
                    dts.gidSolicitadoVia = linea("idSolicitadoVia")
                    dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
                  
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


    Public Function Mostrar1(ByVal iidSolicitadoVia As Integer) As DatosSolicitadoVia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM SolicitadoVia where idSolicitadoVia = " & iidSolicitadoVia
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosSolicitadoVia
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New DatosSolicitadoVia
                    dts.gidSolicitadoVia = linea("idSolicitadoVia")
                    dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
                  
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




    Public Function SolicitadoVia(ByVal iidSolicitadoVia As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SolicitadoVia FROM SolicitadoVia WHERE idSolicitadoVia = " & iidSolicitadoVia
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


 

  


    Public Function insertar(ByVal dts As DatosSolicitadoVia) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into SolicitadoVia (SolicitadoVia ) values (@SolicitadoVia ) select @@Identity"
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
               
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


    Public Function actualizar(ByVal dts As DatosSolicitadoVia) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update SolicitadoVia set SolicitadoVia = @SolicitadoVia WHERE idSolicitadoVia = @idSolicitadoVia "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idSolicitadoVia", dts.gidSolicitadoVia)
                cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
            


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


    Public Function borrar(ByVal iidSolicitadoVia As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from SolicitadoVia where idSolicitadoVia = " & iidSolicitadoVia
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



