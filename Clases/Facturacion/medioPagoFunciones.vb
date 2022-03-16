Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMediosPago
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosMedioPago)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from MediosPago order by MedioPago "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosMedioPago)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    lista.Add(CargarLinea(linea))
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

    Private Function CargarLinea(ByVal linea As DataRow) As datosMedioPago
        Dim dts As New datosMedioPago
        dts.gidMedioPago = linea("idMedioPago")
        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))
        dts.gSinCuenta = If(linea("SinCuenta") Is DBNull.Value, False, linea("SinCuenta"))
        dts.gTransferencia = If(linea("Transferencia") Is DBNull.Value, False, linea("Transferencia"))
        dts.gGiro = If(linea("Giro") Is DBNull.Value, False, linea("Giro"))
        Return dts
    End Function

    Public Function mostrar1(ByVal iidMedioPago As Integer) As datosMedioPago
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select * from MediosPago where idMedioPago = " & iidMedioPago & " order by MedioPago "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As New datosMedioPago
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = CargarLinea(linea)
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

    Public Function MedioPago(ByVal iidMedioPago As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select MedioPago from MediosPago where idMedioPago = " & iidMedioPago
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

    Public Function RequiereBanco(ByVal iidMedioPago As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select SinCuenta from MediosPago where idMedioPago = " & iidMedioPago
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return Not CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TipoGiro(ByVal iidMedioPago As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Giro from MediosPago where idMedioPago = " & iidMedioPago
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TipoTransferencia(ByVal iidMedioPago As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Transferencia from MediosPago where idMedioPago = " & iidMedioPago
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function insertar(ByVal dts As datosMedioPago) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into MediosPago (MedioPago, SinCuenta,Transferencia, Giro) values (@MedioPago, @SinCuenta, @Transferencia, @Giro) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("MedioPago", dts.gMedioPago)
                cmd.Parameters.AddWithValue("SinCuenta", dts.gSinCuenta)
                cmd.Parameters.AddWithValue("Transferencia", dts.gTransferencia)
                cmd.Parameters.AddWithValue("Giro", dts.gGiro)
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

    Public Function actualizar(ByVal dts As datosMedioPago) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update MediosPago set MedioPago = @MedioPago, SinCuenta = @SinCuenta, Transferencia = @Transferencia, Giro = @Giro where idMedioPago = @idMedioPago "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("MedioPago", dts.gMedioPago)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("Banco", dts.gSinCuenta)
                cmd.Parameters.AddWithValue("Transferencia", dts.gTransferencia)
                cmd.Parameters.AddWithValue("Giro", dts.gGiro)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidMedioPago As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from MediosPago where idMedioPago = " & iidMedioPago

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Function EstaEnUso(ByVal sCondicionesPago As String) As DataTable
        Return New DataTable
        'Dim sconexion As String = CadenaConexion()
        'Dim sel As String
        'sel = "SELECT 'Facturas' as Tipo, count(numFactura) as Contador FROM Facturas where condicionesPago = '" & sCondicionesPago & "' union all "
        'sel = sel & "SELECT 'Albaranes' as Tipo, count(numAlbaran) as Contador FROM Albaranes where condicionesPago = '" & sCondicionesPago & "' union all "
        'sel = sel & "SELECT 'Proformas' as Tipo, count(numProforma) as Contador FROM Proformas where condicionesPago = '" & sCondicionesPago & "' "
        'Using con As New SqlConnection(sconexion)
        '    Try
        '        'conectado()
        '        cmd = New SqlCommand(sel, con)
        '        'abrir conexion
        '        con.Open()
        '        'ejecutar el sql
        '        If cmd.ExecuteNonQuery Then
        '            Dim dt As New DataTable
        '            Dim da As New SqlDataAdapter(cmd)
        '            da.Fill(dt)
        '            Return dt
        '        Else
        '            Return Nothing
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        Return Nothing
        '    Finally
        '        desconectado()
        '    End Try
        'End Using
    End Function

End Class
