
Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesTiemposEscandallos


    Inherits conexion
    Dim cmd As SqlCommand
    Private funcAP As New FuncionesArticuloPrecio


    Public Function Mostrar(ByVal idEscandallo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosTiempoEscandallo)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TE.*, Seccion from TiemposEscandallos as TE "
            sel = sel & " LEFT JOIN Secciones ON Secciones.idSeccion = TE.idSeccion"
            sel = sel & " WHERE idEscandallo = " & idEscandallo & If(SoloActivos, " AND TE.Activo = 1 ", "") & "ORDER By Secciones.Orden ASC"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTiempoEscandallo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTiempoEscandallo
                For Each linea In dt.Rows
                    If linea("idTiempo") Is DBNull.Value Then
                    Else
                        dts = New DatosTiempoEscandallo
                        dts.gidTiempo = linea("idTiempo")
                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
                        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))
                        dts.gHoras = If(linea("Horas") Is DBNull.Value, 0, linea("Horas"))
                        dts.gPrecioHora = If(linea("PrecioHora") Is DBNull.Value, 0, linea("PrecioHora"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))
                        dts.gcodMoneda = "EU"
                        dts.gsimbolo = "€"
                        lista.Add(dts)
                    End If
                Next
            Else
                con.Close()
            End If
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function




    Public Function Mostrar1(ByVal iidTiempo As Integer) As DatosTiempoEscandallo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TE.*, Seccion from TiemposEscandallos as TE "
            sel = sel & " LEFT JOIN Secciones ON Secciones.idSeccion = TE.idSeccion"
            sel = sel & " WHERE idTiempo = " & iidTiempo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTiempoEscandallo
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTiempo") Is DBNull.Value Then
                    Else
                        dts.gidTiempo = linea("idTiempo")
                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
                        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))
                        dts.gHoras = If(linea("Horas") Is DBNull.Value, 0, linea("Horas"))
                        dts.gPrecioHora = If(linea("PrecioHora") Is DBNull.Value, 0, linea("PrecioHora"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))
                        dts.gcodMoneda = "EU"
                        dts.gsimbolo = "€"

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





    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM TiemposEscandallos", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM TiemposEscandallos WHERE  " & busqueda, con)

            End If
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

    Public Function TotalCoste(ByVal iidEscandallo As Integer, ByVal SoloActivos As Boolean) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            
            Dim sel As String = "Select sum(Horas * PrecioHora) as total from TiemposEscandallos where idEscandallo = " & iidEscandallo & If(SoloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)

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


    Public Function VistaTaller(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si un artículo tiene en su desglose de tiempo secciones de la vista taller
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "Select count(idTiempo) from TiemposEscandallos left join Escandallos ON Escandallos.idEscandallo = TiemposEscandallos.idEscandallo "
            sel = sel & " left join Secciones ON TiemposEscandallos.idSeccion =Secciones.idSeccion where Vista = 'TALLER' AND idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function VistaElectronica(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si un artículo tiene en su desglose de tiempo secciones de la vista taller
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "Select count(idTiempo) from TiemposEscandallos left join Escandallos ON Escandallos.idEscandallo = TiemposEscandallos.idEscandallo "
            sel = sel & " left join Secciones ON TiemposEscandallos.idSeccion =Secciones.idSeccion where Vista = 'ELECTRÓNICA' AND idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    Public Function insertar(ByVal dts As DatosTiempoEscandallo) As Integer
        'Insertar un nuevo producto, si no existe ya el código 

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into TiemposEscandallos (idEscandallo, idSeccion, Horas, PrecioHora, Observaciones, Activo, Orden, idCreador, Creacion) "
                sel = sel & " values (@idEscandallo, @idSeccion, @Horas, @PrecioHora, @Observaciones, @Activo, @Orden, @idCreador, @Creacion) Select @@Identity "

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("Horas", dts.gHoras)
                cmd.Parameters.AddWithValue("PrecioHora", dts.gPrecioHora)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try
        End Using



    End Function



    Public Function actualizar(ByVal dts As DatosTiempoEscandallo) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiemposEscandallos set idEscandallo = @idEscandallo,idSeccion = @idSeccion, Horas = @Horas, PrecioHora = @PrecioHora, Observaciones = @Observaciones, Activo = @Activo, Orden = @Orden, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " WHERE idTiempo = @idTiempo "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTiempo", dts.gidTiempo)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("Horas", dts.gHoras)
                cmd.Parameters.AddWithValue("PrecioHora", dts.gPrecioHora)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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





    Public Function Borrar(ByVal iidTiempo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from TiemposEscandallos where idTiempo = " & iidTiempo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function


    Public Function BorrarEscandallo(ByVal iidEscandallo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from TiemposEscandallos where idEscandallo = " & iidEscandallo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function

  


End Class
