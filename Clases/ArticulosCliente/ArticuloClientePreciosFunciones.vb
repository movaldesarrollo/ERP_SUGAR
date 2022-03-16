Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesArticuloClientePrecios
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrarArt(ByVal iidArticulo As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloClientePrecio)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloClientePrecio)
            sel = "select PP.*, Simbolo from ArticuloClientePrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE idArticulo = " & iidArticulo & If(soloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As DatosArticuloClientePrecio
                For Each linea As DataRow In dt.Rows

                    If linea("idArtCliPrecio") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloClientePrecio
                        dts.gidArtCliPrecio = linea("idArtCliPrecio")
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
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

    Public Function mostrarCli(ByVal iidCliente As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloClientePrecio)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloClientePrecio)
            sel = "select PP.*, Simbolo from ArticuloClientePrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE idCliente = " & iidCliente & If(soloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As DatosArticuloClientePrecio
                For Each linea As DataRow In dt.Rows

                    If linea("idArtCliPrecio") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloClientePrecio
                        dts.gidArtCliPrecio = linea("idArtCliPrecio")
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
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


    Public Function mostrar1(ByVal iidArtCliPrecio As Integer) As DatosArticuloClientePrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloClientePrecio
            sel = "select PP.*, Simbolo from ArticuloClientePrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE  and idArtCliPrecio = " & iidArtCliPrecio
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCliPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArtCliPrecio = linea("idArtCliPrecio")
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
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

    Public Function mostrarArtCli(ByVal iidArtCli As Integer) As DatosArticuloClientePrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloClientePrecio
            sel = "select PP.*, Simbolo from ArticuloClientePrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE Activo = 1 and idArtCli = " & iidArtCli
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCliPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArtCliPrecio = linea("idArtCliPrecio")
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
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



    Public Function insertar(ByVal dts As DatosArticuloClientePrecio) As Long
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into ArticuloClientePrecios (idArtCli, PrecioNetoUnitario, Activo, codMoneda, idCreador, Creacion) "
        sel = sel & " values (@idArtCli, @PrecioNetoUnitario, @Activo, @codMoneda, @idCreador, @Creacion) select @@identity "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim Resultado As Long = cmd.ExecuteScalar
                con.Close()
                Return Resultado

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function


    Public Function actualizar(ByVal dts As DatosArticuloClientePrecio) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ArticuloClientePrecios set idArtCli = @idArtCli,  PrecioNetoUnitario = @PrecioNetoUnitario, Activo = @Activo, codMoneda = @codMoneda  where idArtCliPrecio = @idArtCliPrecio "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idArtCliPrecio", dts.gidArtCliPrecio)
                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function Desactivar(ByVal iidArtCli As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ArticuloClientePrecios set  Activo = 0  where idArtCli = " & iidArtCli

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function borrarArtCli(ByVal iidArtCli As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        'No dejamos que se borre un rango permanente
        sel = "delete from ArticuloClientePrecios where  idArtCli = " & iidArtCli

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidArtCliPrecio As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloClientePrecios where  idArtCliPrecio = " & iidArtCliPrecio

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function


    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloClientePrecios where  idCliente = " & iidCliente

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function


    Public Function borrarArticulo(ByVal iidArticulo As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloClientePrecios where  idArticulo= " & iidArticulo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

End Class
