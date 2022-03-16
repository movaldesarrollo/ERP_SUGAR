Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesArticuloProvPrecios
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrarArt(ByVal iidArticulo As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloProvPrecio)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloProvPrecio)
            sel = "select PP.*, Simbolo from ArticuloProveedorPrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE idArticulo = " & iidArticulo & If(soloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As DatosArticuloProvPrecio
                For Each linea As DataRow In dt.Rows

                    If linea("idArtProvPrecio") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloProvPrecio
                        dts.gidArtProvPrecio = linea("idArtProvPrecio")
                        dts.gidArtProv = If(linea("idArtProv") Is DBNull.Value, 0, linea("idArtProv"))
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

    Public Function mostrarProv(ByVal iidProveedor As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloProvPrecio)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloProvPrecio)
            sel = "select PP.*, Simbolo from ArticuloProveedorPrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE idProveedor = " & iidProveedor & If(soloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As DatosArticuloProvPrecio
                For Each linea As DataRow In dt.Rows

                    If linea("idArtProvPrecio") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloProvPrecio
                        dts.gidArtProvPrecio = linea("idArtProvPrecio")
                        dts.gidArtProv = If(linea("idArtProv") Is DBNull.Value, 0, linea("idArtProv"))
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


    Public Function mostrar1(ByVal iidArtProvPrecio As Integer) As DatosArticuloProvPrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloProvPrecio
            sel = "select PP.*, Simbolo from ArticuloProveedorPrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE  and idArtProvPrecio = " & iidArtProvPrecio
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idArtProvPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArtProvPrecio = linea("idArtProvPrecio")
                        dts.gidArtProv = If(linea("idArtProv") Is DBNull.Value, 0, linea("idArtProv"))
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

    Public Function mostrarArtProv(ByVal iidArtProv As Integer) As DatosArticuloProvPrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloProvPrecio
            sel = "select PP.*, Simbolo from ArticuloProveedorPrecios as PP left join Monedas ON Monedas.codMoneda = PP.codMoneda "
            sel = sel & " WHERE Activo = 1 and idArtProv = " & iidArtProv
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idArtProvPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArtProvPrecio = linea("idArtProvPrecio")
                        dts.gidArtProv = If(linea("idArtProv") Is DBNull.Value, 0, linea("idArtProv"))
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



    Public Function insertar(ByVal dts As DatosArticuloProvPrecio) As Long
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into ArticuloProveedorPrecios (idArtProv, PrecioNetoUnitario, Activo, codMoneda, idCreador, Creacion) "
        sel = sel & " values (@idArtProv, @PrecioNetoUnitario, @Activo, @codMoneda, @idCreador, @Creacion) select @@identity "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArtProv", dts.gidArtProv)
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


    Public Function actualizar(ByVal dts As DatosArticuloProvPrecio) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ArticuloProveedorPrecios set idArtProv = @idArtProv,  PrecioNetoUnitario = @PrecioNetoUnitario, Activo = @Activo, codMoneda = @codMoneda  where idArtProvPrecio = @idArtProvPrecio "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idArtProv", dts.gidArtProv)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idArtProvPrecio", dts.gidArtProvPrecio)
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

    Public Function Desactivar(ByVal iidArtProv As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ArticuloProveedorPrecios set  Activo = 0  where idArtProv = " & iidArtProv

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

    Public Function borrarArtProv(ByVal iidArtProv As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        'No dejamos que se borre un rango permanente
        sel = "delete from ArticuloProveedorPrecios where  idArtProv = " & iidArtProv

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

    Public Function borrar(ByVal iidArtProvPrecio As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloProveedorPrecios where  idArtProvPrecio = " & iidArtProvPrecio

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


    Public Function borrarProvente(ByVal iidProveedor As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloProveedorPrecios where  idProveedor = " & iidProveedor

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

        sel = "delete from ArticuloProveedorPrecios where  idArticulo= " & iidArticulo

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
