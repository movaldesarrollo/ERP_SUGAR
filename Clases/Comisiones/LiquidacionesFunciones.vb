Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesLiquidaciones
    Inherits conexion
    Dim cmd As SqlCommand



    Dim sel0 As String = "Select LQ.*, Nombre + ' ' + Apellidos as Comercial from Liquidaciones as LQ " _
                     & " left join Personal ON Personal.idPersona = LQ.idComercial  Left join Contactos ON Contactos.idContacto = Personal.idContacto"

    Public Function mostrar() As List(Of DatosLiquidacion)
        'Muestra todas los Comisiones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosLiquidacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idLiquidacion") Is DBNull.Value Then
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

  

    



    Private Function CargarLinea(ByVal linea As DataRow) As DatosLiquidacion
        Dim dts As New DatosLiquidacion
        dts.gidLiquidacion = If(linea("idLiquidacion") Is DBNull.Value, 0, linea("idLiquidacion"))
        dts.gidComercial = If(linea("idComercial") Is DBNull.Value, 0, linea("idComercial"))
        dts.gFechaLiquidacion = If(linea("FechaLiquidacion") Is DBNull.Value, 0, linea("FechaLiquidacion"))
        dts.gComercial = If(linea("Comercial") Is DBNull.Value, "", linea("Comercial"))
        dts.gImporte = If(linea("Importe") Is DBNull.Value, 0, linea("Importe"))

        Return dts
    End Function


    Public Function mostrar1(ByVal iidLiquidacion As Integer) As DatosLiquidacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where idLiquidacion = " & iidLiquidacion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosLiquidacion
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idLiquidacion") Is DBNull.Value Then
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


  


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosLiquidacion)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", " Order by FechaLiquidacion DESC, idLiquidacion DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosLiquidacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idLiquidacion") Is DBNull.Value Then
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





    Public Function insertar(ByVal dts As DatosLiquidacion) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Liquidaciones (idComercial, FechaLiquidacion,importe, idCreador, Creacion)"
        sel = sel & "         values (@idComercial, @FechaLiquidacion,@importe,@idCreador,@Creacion ) SELECT @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("FechaLiquidacion", dts.gFechaLiquidacion)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)

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

    Public Function actualizar(ByVal dts As DatosLiquidacion) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Liquidaciones set idComercial= @idComercial, FechaLiquidacion = @FechaLiquidacion,importe = @importe, idModifica = @idModifica, Modificacion = @Modificacion   where idLiquidacion = @idLiquidacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idLiquidacion", dts.gidLiquidacion)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("FechaLiquidacion", dts.gFechaLiquidacion)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function




    Public Function borrar(ByVal iidLiquidacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Liquidaciones where idLiquidacion = " & iidLiquidacion
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

    Public Function borrarComercial(ByVal iidComercial As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Liquidaciones where idComercial = " & iidComercial
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
