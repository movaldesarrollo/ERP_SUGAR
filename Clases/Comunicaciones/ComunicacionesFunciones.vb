Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesComunicaciones
    Inherits conexion
    Dim cmd As SqlCommand

    Dim sel0 As String = " select CO.*, CT.Nombre + ' ' + CT.Apellidos as Contacto, subCliente, Localidad + ', ' + Direccion as Direccion, " _
    & "  CC.Nombre + ' ' + CC.Apellidos as Creador, CL.NombreComercial as Cliente, PR.NombreComercial as Proveedor, SolicitadoVia, Estado, CD.Nombre + ' ' + CD.Apellidos as Destinatario, " _
    & " (Select count(idComunicacion) from Comunicaciones where idComunicacionPadre = CO.idComunicacion ) as CuantosConceptos " _
    & " from Comunicaciones AS CO left join Clientes as CL ON CL.idCliente = CO.idCliente " _
    & " left join Proveedores as PR ON PR.idProveedor = CO.idProveedor " _
    & " Left Join Ubicaciones as UB ON UB.idUbicacion = CO.idUbicacion Left Join Contactos as CT ON CT.idContacto = CO.idContacto " _
    & " Left Join Personal ON Personal.idPersona = CO.idCreador LEft Join Contactos as CC ON CC.idContacto = Personal.idContacto " _
    & " Left Join SolicitadoVia ON SolicitadoVia.idSolicitadoVia = CO.idSolicitadoVia " _
    & " Left Join Personal as PD ON PD.idPersona = CO.idDestinatario LEft Join Contactos as CD ON CD.idContacto = PD.idContacto " _
    & " Left Join Estados ON Estados.idEstado = CO.idEstado "

    Public Function mostrarCli(ByVal iidCliente As Integer) As List(Of datosComunicacion)
        'Muestra todas los Comunicaciones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where idComunicacionPadre= 0 AND CO.idCliente = " & iidCliente & " Order by FechaHora DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComunicacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComunicacion") Is DBNull.Value Then
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

    Public Function mostrarPersona(ByVal iidDestinatario As Integer) As List(Of datosComunicacion)
        'Muestra todas los Comunicaciones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idDestinatario = " & iidDestinatario & " Order by FechaHora DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComunicacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComunicacion") Is DBNull.Value Then
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


    Public Function mostrarConceptos(ByVal iidComunicacion As Integer) As List(Of datosComunicacion)
        'Muestra todas los Comunicaciones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idComunicacionPadre = " & iidComunicacion & " Order by FechaHora ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComunicacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComunicacion") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As datosComunicacion
        Dim subCliente As String
        Dim dts As New datosComunicacion
        dts.gidComunicacion = linea("idComunicacion")
        dts.gidComunicacionPadre = If(linea("idComunicacionPadre") Is DBNull.Value, 0, linea("idComunicacionPadre"))
        dts.gFechaHora = If(linea("FechaHora") Is DBNull.Value, Now, linea("FechaHora"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
        dts.gidSolicitadoVia = If(linea("idSolicitadoVia") Is DBNull.Value, 0, linea("idSolicitadoVia"))
        'dts.gAsunto = If(linea("Asunto") Is DBNull.Value, "", linea("Asunto"))
        dts.gComentario = If(linea("Comentario") Is DBNull.Value, "", linea("Comentario"))
        dts.gDestacado = If(linea("Destacado") Is DBNull.Value, False, linea("Destacado"))
        dts.gidCreador = If(linea("idCreador") Is DBNull.Value, 0, linea("idCreador"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidDestinatario = If(linea("idDestinatario") Is DBNull.Value, 0, linea("idDestinatario"))

        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gCreador = If(linea("Creador") Is DBNull.Value, "", linea("Creador"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        subCliente = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gDireccion = If(subCliente = "", dts.gDireccion, subCliente & ": " & dts.gDireccion)
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gDestinatario = If(linea("Destinatario") Is DBNull.Value, "", linea("Destinatario"))
        dts.gCuantosConceptos = If(linea("CuantosConceptos") Is DBNull.Value, 0, linea("CuantosConceptos"))

        Return dts
    End Function


    Public Function mostrar1(ByVal iidComunicacion As Integer) As datosComunicacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where idComunicacion = " & iidComunicacion
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosComunicacion
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComunicacion") Is DBNull.Value Then
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




    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosComunicacion)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", " Order by FechaHora DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComunicacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComunicacion") Is DBNull.Value Then
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

  


    Public Function insertar(ByVal dts As datosComunicacion) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Comunicaciones (idComunicacionPadre, FechaHora, idCliente, idProveedor, idUbicacion, idContacto, idSolicitadoVia,  Comentario, Destacado, idEstado, idDestinatario, idCreador, Creacion)"
        sel = sel & "             values (@idComunicacionPadre,@FechaHora,@idCliente,@idProveedor,@idUbicacion,@idContacto,@idSolicitadoVia,@Comentario,@Destacado,@idEstado,@idDestinatario,@idCreador,@Creacion ) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComunicacionPadre", dts.gidComunicacionPadre)
                cmd.Parameters.AddWithValue("FechaHora", dts.gFechaHora)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idSolicitadoVia", dts.gidSolicitadoVia)
                'cmd.Parameters.AddWithValue("Asunto", dts.gAsunto)
                cmd.Parameters.AddWithValue("Comentario", dts.gComentario)
                cmd.Parameters.AddWithValue("Destacado", dts.gDestacado)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idDestinatario", dts.gidDestinatario)
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

    Public Function actualizar(ByVal dts As datosComunicacion) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Comunicaciones set idComunicacionPadre = @idComunicacionPadre, FechaHora = @FechaHora, idCliente = @idCliente,idProveedor = @idProveedor, idUbicacion = @idUbicacion, idContacto =@idContacto, idSolicitadoVia = @idSolicitadoVia,"
        sel = sel & " Comentario= @Comentario, Destacado = @Destacado, idEstado = @idEstado, idDestinatario = @idDestinatario, idModifica = @idModifica, Modificacion = @Modificacion  where idComunicacion = @idComunicacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idComunicacion", dts.gidComunicacion)
                cmd.Parameters.AddWithValue("idComunicacionPadre", dts.gidComunicacionPadre)
                cmd.Parameters.AddWithValue("FechaHora", dts.gFechaHora)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)

                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idSolicitadoVia", dts.gidSolicitadoVia)
                'cmd.Parameters.AddWithValue("Asunto", dts.gAsunto)
                cmd.Parameters.AddWithValue("Comentario", dts.gComentario)
                cmd.Parameters.AddWithValue("Destacado", dts.gDestacado)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idDestinatario", dts.gidDestinatario)
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

    Public Function CambiarEstado(ByVal iidComunicacion As Integer, ByVal iidEstado As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Comunicaciones set idEstado = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion  where idComunicacion = @idComunicacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComunicacion", iidComunicacion)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
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

    Public Function CambiarDestacado(ByVal iidComunicacion As Integer, ByVal Destacado As Boolean) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Comunicaciones set Destacado = @Destacado, idModifica = @idModifica, Modificacion = @Modificacion  where idComunicacion = @idComunicacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComunicacion", iidComunicacion)
                cmd.Parameters.AddWithValue("Destacado", Destacado)
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


    Public Function borrar(ByVal iidComunicacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Comunicaciones where idComunicacion = " & iidComunicacion
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

    Public Function borrarConceptos(ByVal iidComunicacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Comunicaciones where idComunicacionPadre = " & iidComunicacion
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
            Dim sel As String = "delete from Comunicaciones where idCliente = " & iidCliente
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

    Public Function borrarProveedor(ByVal iidPRoveedor As Integer) As Boolean

        If iidPRoveedor > 0 Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Comunicaciones where idProveedor = " & iidPRoveedor
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
