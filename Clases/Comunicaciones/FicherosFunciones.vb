Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesFicheros
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidComunicacion As Integer) As List(Of datosFichero)
        'Muestra todas los Ficheros de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select * from Ficheros where idComunicacion = " & iidComunicacion & " Order by idFichero DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosFichero)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idFichero") Is DBNull.Value Then
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

  

    Private Function CargarLinea(ByVal linea As DataRow) As datosFichero

        Dim dts As New datosFichero
        dts = New datosFichero
        dts.gidFichero = linea("idFichero")
        dts.gRuta = If(linea("Ruta") Is DBNull.Value, "", linea("Ruta"))
        dts.gFichero = If(linea("Fichero") Is DBNull.Value, "", linea("Fichero"))
        dts.gidComunicacion = If(linea("idComunicacion") Is DBNull.Value, "", linea("idComunicacion"))

        Return dts
    End Function


    Public Function mostrar1(ByVal iidFichero As Integer) As datosFichero
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select * from Ficheros where idFichero = " & iidFichero
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosFichero
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idFichero") Is DBNull.Value Then
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




    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosFichero)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from Ficheros  " & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", " Order by idFichero DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosFichero)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idFichero") Is DBNull.Value Then
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




    Public Function insertar(ByVal dts As datosFichero) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Ficheros (Ruta, Fichero, idComunicacion)  values (@Ruta,@Fichero,@idComunicacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Ruta", dts.gRuta)
                cmd.Parameters.AddWithValue("Fichero", dts.gFichero)
                cmd.Parameters.AddWithValue("idComunicacion", dts.gidComunicacion)

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

    Public Function actualizar(ByVal dts As datosFichero) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Ficheros set  Ruta = @Ruta, Fichero = @Fichero, idComunicacion = @idComunicacion  where idFichero = @idFichero "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idFichero", dts.gidFichero)
                cmd.Parameters.AddWithValue("Ruta", dts.gRuta)
                cmd.Parameters.AddWithValue("Fichero", dts.gFichero)
                cmd.Parameters.AddWithValue("idComunicacion", dts.gidComunicacion)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function




    Public Function borrarComunicacion(ByVal iidComunicacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Ficheros where idComunicacion = " & iidComunicacion
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
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




    Public Function borrar(ByVal iidFichero As Integer) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Ficheros where idFichero = " & iidFichero
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

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



End Class
