Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesAvisos
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal SoloPendientes As Boolean) As List(Of datosAviso)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Avisos.*, Nombre + ' ' + Apellidos as Creador  from Avisos left join Personal ON Personal.idersona = Avisos.idCreador "
            sel = " left join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & If(SoloPendientes, " Where enviado = 0 ", "") & " Order by idAviso DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosAviso)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As datosAviso
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idAviso") Is DBNull.Value Then
                    Else
                        dts = New datosAviso
                        dts.gidAviso = linea("idAviso")
                        dts.gTipoAviso = If(linea("TipoAviso") Is DBNull.Value, "", linea("TipoAviso"))
                        dts.gAplicacion = If(linea("Aplicacion") Is DBNull.Value, "", linea("Aplicacion"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, 0, linea("numDoc"))
                        dts.gFechaPropuesta = If(linea("FechaPropuesta") Is DBNull.Value, Now.Date, linea("FechaPropuesta"))
                        dts.gExplicacion = If(linea("Explicacion") Is DBNull.Value, "", linea("Explicacion"))
                        dts.gEnviado = If(linea("Enviado") Is DBNull.Value, False, linea("Enviado"))
                        dts.gidCreador = If(linea("idCreador") Is DBNull.Value, 0, linea("idCreador"))
                        dts.gCreador = If(linea("Creador") Is DBNull.Value, "", linea("Creador"))

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

    Public Function mostrar1(ByVal iidAviso As Integer) As datosAviso
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Avisos.*, Nombre + ' ' + Apellidos as Creador  from Avisos left join Personal ON Personal.idPersona = Avisos.idCreador "
            sel = sel & " left join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " Where idAviso = " & iidAviso
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosAviso
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idAviso") Is DBNull.Value Then
                    Else
                        dts.gidAviso = linea("idAviso")
                        dts.gTipoAviso = If(linea("TipoAviso") Is DBNull.Value, "", linea("TipoAviso"))
                        dts.gAplicacion = If(linea("Aplicacion") Is DBNull.Value, "", linea("Aplicacion"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, 0, linea("numDoc"))
                        dts.gFechaPropuesta = If(linea("FechaPropuesta") Is DBNull.Value, Now.Date, linea("FechaPropuesta"))
                        dts.gExplicacion = If(linea("Explicacion") Is DBNull.Value, "", linea("Explicacion"))
                        dts.gEnviado = If(linea("Enviado") Is DBNull.Value, False, linea("Enviado"))
                        dts.gidCreador = If(linea("idCreador") Is DBNull.Value, 0, linea("idCreador"))
                        dts.gCreador = If(linea("Creador") Is DBNull.Value, "", linea("Creador"))
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






    Public Function Explicacion(ByVal iidAviso As String) As String
        Try

            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Explicacion from Avisos where idAviso = " & iidAviso, con)

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

    Public Function insertar(ByVal dts As datosAviso) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Avisos (TipoAviso, Aplicacion, numDoc, FechaPropuesta, Explicacion, Enviado, idCreador, Creacion) values (@TipoAviso, @Aplicacion, @numDoc, @FechaPropuesta, @Explicacion, @Enviado, @idCreador, @Creacion) select @@identity "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoAviso", dts.gTipoAviso)
                cmd.Parameters.AddWithValue("Aplicacion", dts.gAplicacion)
                cmd.Parameters.AddWithValue("numDoc", dts.gnumDoc)
                cmd.Parameters.AddWithValue("FechaPropuesta", dts.gFechaPropuesta)
                cmd.Parameters.AddWithValue("Explicacion", dts.gExplicacion)
                cmd.Parameters.AddWithValue("Enviado", dts.gEnviado)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using

    End Function

    Public Function AvisoExiste(ByVal dts As datosAviso) As Integer
        'Buscamos un aviso igual que  no se haya enviado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "Select idAviso From Avisos where TipoAviso = @TipoAviso AND Aplicacion = @Aplicacion AND numDOC = @numDoc AND Enviado = 0 "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoAviso", dts.gTipoAviso)
                cmd.Parameters.AddWithValue("Aplicacion", dts.gAplicacion)
                cmd.Parameters.AddWithValue("numDoc", dts.gnumDoc)

                con.Open()
                Dim resultado As String = cmd.ExecuteScalar()
                con.Close()
                Return resultado

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function AvisoExiste(ByVal iidAviso As Integer) As Integer
        'Buscamos un aviso igual que  no se haya enviado
        Dim dts As datosAviso = mostrar1(iidAviso)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "Select idAviso From Avisos where TipoAviso = @TipoAviso AND Aplicacion = @Aplicacion AND numDOC = @numDoc AND Enviado = 0 "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoAviso", dts.gTipoAviso)
                cmd.Parameters.AddWithValue("Aplicacion", dts.gAplicacion)
                cmd.Parameters.AddWithValue("numDoc", dts.gnumDoc)

                con.Open()
                Dim resultado As String = cmd.ExecuteScalar()
                con.Close()
                Return resultado

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function


    Public Function Enviar(ByVal iidAviso As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = " update Avisos set enviado = 1 where idAviso = " & iidAviso

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function




End Class
