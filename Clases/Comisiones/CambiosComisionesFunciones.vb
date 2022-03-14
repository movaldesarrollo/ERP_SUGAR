Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesCambiosComisiones
    Inherits conexion
    Dim cmd As SqlCommand



    Dim sel0 As String = "Select CC.*, Nombre + ' ' + Apellidos as Comercial from ComisionesCambios as CC " _
                     & " left join Personal ON Personal.idPersona = CC.idComercial  Left join Contactos ON Contactos.idContacto = Personal.idContacto"

    Public Function mostrarCli(ByVal iidCliente As Integer) As List(Of datosCambioComision)
        'Muestra todas los Comisiones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CC.idCliente = " & iidCliente & " Order by CC.Fecha DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosCambioComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idHistoricoCambio") Is DBNull.Value Then
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

    Public Function mostrarComercial(ByVal iidComercial As Integer) As List(Of datosCambioComision)
        'Muestra todas los Comisiones de un comercial
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idComercial = " & iidComercial & " Order by Fecha DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosCambioComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idHistoricoCambio") Is DBNull.Value Then
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

    Public Function mostrarClienteComercial(ByVal iidComercial As Integer, ByVal iidCliente As Integer) As List(Of datosCambioComision)
        'Muestra todas los Comisiones de un comercial
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idComercial = " & iidComercial & " AND CO.idCLiente = " & iidCliente & " Order by Fecha DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosCambioComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idHistoricoCambio") Is DBNull.Value Then
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



    Private Function CargarLinea(ByVal linea As DataRow) As datosCambioComision
        Dim dts As New datosCambioComision
        dts.gidHistoricoCambio = If(linea("idHistoricoCambio") Is DBNull.Value, 0, linea("idHistoricoCambio"))
        dts.gidComercial = If(linea("idComercial") Is DBNull.Value, 0, linea("idComercial"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gPorcentaje = If(linea("Porcentaje") Is DBNull.Value, 0, linea("Porcentaje"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, 0, linea("Fecha"))
        dts.gPorcentajeAnterior = If(linea("PorcentajeAnterior") Is DBNull.Value, 0, linea("PorcentajeAnterior"))
        dts.gComercial = If(linea("Comercial") Is DBNull.Value, "", linea("Comercial"))
        Return dts
    End Function


    Public Function mostrar1(ByVal iidHistoricoCambio As Integer) As datosCambioComision
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where idHistoricoCambio = " & iidHistoricoCambio
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosCambioComision
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idHistoricoCambio") Is DBNull.Value Then
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


    Public Function UltimoPorcentaje(ByVal iidCliente As Integer, ByVal iidComercial As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select TOP 1 Porcentaje from ComisionesCambios where idCliente = " & iidCliente & " AND idComercial = " & iidComercial & " ORDER BY Fecha DESC "
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosCambioComision
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CDbl(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosCambioComision)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda = "", "", " AND " & sBusqueda) & If(sOrden = "", " Order by Fecha DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosCambioComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idHistoricoCambio") Is DBNull.Value Then
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





    Public Function insertar(ByVal dts As datosCambioComision) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        dts.gPorcentajeAnterior = UltimoPorcentaje(dts.gidCliente, dts.gidComercial) 'Se carga el porcentaje de comisión (mismo comercial y cliente) anterior
        sel = "insert into ComisionesCambios (idComercial, idCliente, Porcentaje,PorcentajeAnterior, Fecha, idPersona)"
        sel = sel & "         values (@idComercial,@idCliente,@Porcentaje, @PorcentajeAnterior, @Fecha,@idPersona ) SELECT @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("PorcentajeAnterior", dts.gPorcentajeAnterior)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idPersona", Inicio.vIdUsuario)
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

    Public Function actualizar(ByVal dts As datosCambioComision) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ComisionesCambios set idComercial= @idComercial, idCliente = @idCliente,Porcentaje = @Porcentaje, Fecha = @Fecha, idPersona = @idPersona  where idHistoricoCambio = @idHistoricoCambio "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idHistoricoCambio", dts.gidHistoricoCambio)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idPersona", Inicio.vIdUsuario)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


   

    Public Function borrar(ByVal iidHistoricoCambio As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ComisionesCambios where idHistoricoCambio = " & iidHistoricoCambio
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
        Dim sel As String = "delete from ComisionesCambios where idComercial = " & iidComercial
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


    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean

        If iidCliente > 0 Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from ComisionesCambios where idCliente = " & iidCliente
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
        End If

    End Function




End Class
