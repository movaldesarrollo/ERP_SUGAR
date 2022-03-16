Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesReferencias
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidComunicacion As Integer) As List(Of datosReferencia)
        'Muestra todas los Referencias de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select * from Referencias where idComunicacion = " & iidComunicacion & " Order by idReferencia DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosReferencia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idReferencia") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("iidComunicacion", iidComunicacion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CargarLinea(ByVal linea As DataRow) As datosReferencia

        Dim dts As New datosReferencia
        dts = New datosReferencia
        dts.gidReferencia = linea("idReferencia")
        dts.gDocumento = If(linea("Documento") Is DBNull.Value, "", linea("Documento"))
        dts.gReferencia = If(linea("Referencia") Is DBNull.Value, "", linea("Referencia"))
        dts.gidComunicacion = If(linea("idComunicacion") Is DBNull.Value, "", linea("idComunicacion"))
        Return dts
    End Function

    Public Function mostrar1(ByVal iidReferencia As Integer) As datosReferencia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select * from Referencias where idReferencia = " & iidReferencia
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosReferencia
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idReferencia") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("iidReferencia", iidReferencia)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosReferencia)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from Referencias  " & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", " Order by FechaHora DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosReferencia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idReferencia") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("sOrden", sOrden)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function insertar(ByVal dts As datosReferencia) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Referencias (Documento, Referencia, idComunicacion)  values (@Documento,@Referencia,@idComunicacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Documento", dts.gDocumento)
                cmd.Parameters.AddWithValue("Referencia", dts.gReferencia)
                cmd.Parameters.AddWithValue("idComunicacion", dts.gidComunicacion)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                CorreoError(ex)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosReferencia) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Referencias set  Documento = @Documento, Referencia = @Referencia, idComunicacion = @idComunicacion  where idReferencia = @idReferencia "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idReferencia", dts.gidReferencia)
                cmd.Parameters.AddWithValue("Documento", dts.gDocumento)
                cmd.Parameters.AddWithValue("Referencia", dts.gReferencia)
                cmd.Parameters.AddWithValue("idComunicacion", dts.gidComunicacion)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function borrarComunicacion(ByVal iidComunicacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Referencias where idComunicacion = " & iidComunicacion
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
                ex.Data.Add("iidComunicacion", iidComunicacion)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function borrar(ByVal iidReferencia As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Referencias where idReferencia = " & iidReferencia
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
                ex.Data.Add("iidReferencia", iidReferencia)
                CorreoError(ex)
                Return False
            End Try
        End Using


    End Function

End Class
