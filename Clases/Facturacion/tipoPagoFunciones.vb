Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesTiposPago
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function mostrar(ByVal SoloActivos As Boolean) As List(Of datosTipoPago)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from TiposPago " & If(SoloActivos, "Where Activo = 1 ", "") & " order by TipoPago "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosTipoPago)
                Dim dts As datosTipoPago
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosTipoPago
                    dts.gidTipoPago = linea("idTipoPago")
                    dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
                    dts.gdiapactado = If(linea("DiaPactado") Is DBNull.Value, False, linea("DiaPactado"))
                    dts.gContadorDias = If(linea("ContadorDias") Is DBNull.Value, 0, linea("ContadorDias"))
                    dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, False, linea("ProntoPago"))
                    dts.gCarencia = If(linea("Carencia") Is DBNull.Value, 0, linea("Carencia"))
                    dts.gnumPagos = If(linea("numPagos") Is DBNull.Value, 0, linea("numPagos"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function mostrar1(ByVal iidTipoPago As Integer) As datosTipoPago
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from TiposPago where idTipoPago = " & iidTipoPago & " order by TipoPago "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As New datosTipoPago
                Dim linea As DataRow
                For Each linea In dt.Rows

                    dts.gidTipoPago = linea("idTipoPago")
                    dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
                    dts.gdiapactado = If(linea("DiaPactado") Is DBNull.Value, False, linea("DiaPactado"))
                    dts.gContadorDias = If(linea("ContadorDias") Is DBNull.Value, 0, linea("ContadorDias"))
                    dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, False, linea("ProntoPago"))
                    dts.gCarencia = If(linea("Carencia") Is DBNull.Value, 0, linea("Carencia"))
                    dts.gnumPagos = If(linea("numPagos") Is DBNull.Value, 0, linea("numPagos"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                Next
                Return dts
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function




    Public Function TipoPago(ByVal iidTipoPago As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select TipoPago from TiposPago where idTipoPago = " & iidTipoPago
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

    Public Function insertar(ByVal dts As datosTipoPago) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into TiposPago (TipoPago, DiaPactado, ContadorDias, ProntoPago, Carencia, numPagos, Activo) values (@TipoPago, @DiaPactado, @ContadorDias, @ProntoPago, @Carencia, @numPagos, @Activo) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoPago", dts.gTipoPago)
                cmd.Parameters.AddWithValue("DiaPactado", dts.gdiapactado)
                cmd.Parameters.AddWithValue("ContadorDias", dts.gContadorDias)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("Carencia", dts.gCarencia)
                cmd.Parameters.AddWithValue("numPagos", dts.gnumPagos)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)

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

    Public Function actualizar(ByVal dts As datosTipoPago) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update TiposPago set TipoPago = @TipoPago, DiaPactado = @DiaPactado, ContadorDias = @ContadorDias, ProntoPago = @ProntoPago, Carencia = @Carencia, numPagos = @numPagos, Activo = @Activo where idTipoPago = @idTipoPago "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoPago", dts.gTipoPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("DiaPactado", dts.gdiapactado)
                cmd.Parameters.AddWithValue("ContadorDias", dts.gContadorDias)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("Carencia", dts.gCarencia)
                cmd.Parameters.AddWithValue("numPagos", dts.gnumPagos)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidTipoPago As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from TiposPago where idTipoPago = " & iidTipoPago

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function




    Public Function EstaEnUso(ByVal iidTipoPago As Integer) As DataTable


        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = ""
            'sel = "SELECT 'Facturas' as Tipo, count(numFactura) as Contador FROM Facturas where TipoPago = '" & sTipoPago & "' union all "
            sel = sel & "SELECT 'Albaranes' as Tipo, count(numAlbaran) as Contador FROM Albaranes where idTipoPago = " & iidTipoPago & " union all "
            sel = sel & "SELECT 'Pedidos' as Tipo, count(numPedido) as Contador FROM Pedidos where idTipoPago = " & iidTipoPago & " union all "
            sel = sel & "SELECT 'Proformas' as Tipo, count(numProforma) as Contador FROM Proformas where idTipoPago = " & iidTipoPago & " union all "
            sel = sel & "SELECT 'Ofertas' as Tipo, count(numOfertta) as Contador FROM Ofertas where idTipoPago = " & iidTipoPago & " "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Return dt
                Else
                    con.Close()
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function






End Class
