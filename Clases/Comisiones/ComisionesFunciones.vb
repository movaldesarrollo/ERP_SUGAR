Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesComisiones
    Inherits conexion
    Dim cmd As SqlCommand

    Private funcCC As New funcionesCambiosComisiones

    Dim sel0 As String = " select CO.*, CC.Nombre + ' ' + CC.Apellidos as Comercial, CL.NombreComercial as Cliente,PR.idProvincia, PR.Provincia, Paises.idPais, Pais,AU.idAutonomia, AU.Autonomia " _
    & " from Comisiones AS CO left join Clientes as CL ON CL.idCliente = CO.idCliente " _
    & " Left Join Ubicaciones as UB ON UB.idCliente = CO.idCliente " _
    & " left join TiposUbicacion as TU ON TU.idTipoUbicacion = UB.idTipoUbicacion AND TU.Fiscal = 1 " _
    & " Left Join Personal ON Personal.idPersona = CO.idComercial Left Join Contactos as CC ON CC.idContacto = Personal.idContacto " _
    & " Left Join Paises ON Paises.idPais = UB.idPais " _
    & " Left Join Provincias as PR ON PR.Provincia = UB.Provincia " _
    & " Left Join Autonomias as AU ON AU.idAutonomia = PR.idAutonomia " _
    & " WHERE TU.Fiscal = 1 "

    Dim selClientes As String = " select CL.idCliente, Personal.idPErsona as idComercial,CO.idComision, CO.Porcentaje, CO.Observaciones, CC.Nombre + ' ' + CC.Apellidos as Comercial, CL.NombreComercial as Cliente,PR.idProvincia, PR.Provincia, Paises.idPais, Pais,AU.idAutonomia,AU.Autonomia " _
    & " from Clientes as CL left join  Comisiones AS CO ON CL.idCliente = CO.idCliente " _
    & " Left Join Ubicaciones as UB ON UB.idCliente = CL.idCliente " _
    & " left join TiposUbicacion as TU ON TU.idTipoUbicacion = UB.idTipoUbicacion AND TU.Fiscal = 1 " _
    & " Left Join Personal ON Personal.idPersona = CL.idResponsableCuenta Left Join Contactos as CC ON CC.idContacto = Personal.idContacto " _
    & " Left Join Paises ON Paises.idPais = UB.idPais " _
    & " Left Join Provincias as PR ON PR.Provincia = UB.Provincia " _
    & " Left Join Autonomias as AU ON AU.idAutonomia = PR.idAutonomia " _
    & " WHERE TU.Fiscal = 1 "

    Public Function mostrarCli(ByVal iidCliente As Integer) As List(Of datosComision)
        'Muestra todas los Comisiones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " AND  CO.idCliente = " & iidCliente & " Order by NombreComercial ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComision") Is DBNull.Value Then
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

    Public Function mostrarComercial(ByVal iidComercial As Integer) As List(Of datosComision)
        'Muestra todas los Comisiones de un comercial
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " AND CO.idComercial = " & iidComercial & " Order by NombreComercial ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComision") Is DBNull.Value Then
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



    Private Function CargarLinea(ByVal linea As DataRow) As datosComision
        Dim dts As New datosComision
        dts.gidComision = If(linea("idComision") Is DBNull.Value, 0, linea("idComision"))
        dts.gidComercial = If(linea("idComercial") Is DBNull.Value, 0, linea("idComercial"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gPorcentaje = If(linea("Porcentaje") Is DBNull.Value, 0, linea("Porcentaje"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))

        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        dts.gComercial = If(linea("Comercial") Is DBNull.Value, "", linea("Comercial"))
        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
        dts.gidProvincia = If(linea("idProvincia") Is DBNull.Value, 0, linea("idProvincia"))
        dts.gProvincia = If(linea("Provincia") Is DBNull.Value, "", linea("Provincia"))
        dts.gidAutonomia = If(linea("idAutonomia") Is DBNull.Value, 0, linea("idAutonomia"))
        dts.gAutonomia = If(linea("Autonomia") Is DBNull.Value, "", linea("Autonomia"))
        Return dts
    End Function


    Public Function mostrar1(ByVal iidComision As Integer) As datosComision
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " AND idComision = " & iidComision
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosComision
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComision") Is DBNull.Value Then
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

    Public Function mostrar1(ByVal iidCliente As Integer, ByVal iidComercial As Integer) As datosComision
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " AND CO.idCliente = " & iidCliente & " AND CO.idComercial = " & iidComercial
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosComision
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComision") Is DBNull.Value Then
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


    Public Function mostrar1Cliente(ByVal iidCliente As Integer) As datosComision
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = selClientes & " AND CL.idCliente = " & iidCliente
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosComision
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCliente") Is DBNull.Value Then
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

    Public Function Porcentaje(ByVal iidCliente As Integer, ByVal iidComercial As Integer) As Double
        Try
            If iidCliente = 0 Or iidComercial = 0 Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = "Select TOP 1 Porcentaje from Comisiones where idCliente = " & iidCliente & " AND idComercial = " & iidComercial
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CDbl(o)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosComision)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda = "", "", " AND " & sBusqueda) & If(sOrden = "", " Order by Cliente ASC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idComision") Is DBNull.Value Then
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


    Public Function BusquedaClientes(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosComision)
        'Busca todos los clientes incluyendo, si existen, los datos de comisión
        'Si hay más de un comisionista por cliente, deben salir una entrada por cada uno
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = selClientes & If(sBusqueda = "", "", " AND " & sBusqueda) & If(sOrden = "", " Order by Cliente ASC, Comercial ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("Cliente") Is DBNull.Value Then
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



    Public Function insertar(ByVal dts As datosComision) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Comisiones (idComercial, idCliente, Porcentaje, Observaciones, idCreador, Creacion)"
        sel = sel & "         values (@idComercial,@idCliente,@Porcentaje,@Observaciones,@idCreador,@Creacion ) SELECT @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                If t > 0 Then
                    'Cargar el histórico de comisiones
                    Dim PorcentajeAnterior As Double = funcCC.UltimoPorcentaje(dts.gidCliente, dts.gidComercial)
                    If dts.gPorcentaje <> PorcentajeAnterior Then
                        funcCC.insertar(New datosCambioComision(dts.gidCliente, dts.gidComercial, dts.gPorcentaje, PorcentajeAnterior, Now.Date, Inicio.vIdUsuario))
                    End If
                End If

                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosComision) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Comisiones set idComercial= @idComercial, idCliente = @idCliente,Porcentaje = @Porcentaje, Observaciones = @Observaciones, idModifica = @idModifica, Modificacion = @Modificacion  where idComision = @idComision "

        Dim PorcentajeAnterior As Double = funcCC.UltimoPorcentaje(dts.gidCliente, dts.gidComercial)
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idComision", dts.gidComision)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t > 0 Then
                    'Cargar el histórico de comisiones
                    If dts.gPorcentaje <> PorcentajeAnterior Then
                        funcCC.insertar(New datosCambioComision(dts.gidCliente, dts.gidComercial, dts.gPorcentaje, PorcentajeAnterior, Now.Date, Inicio.vIdUsuario))
                    End If
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

  


    Public Function borrar(ByVal iidComision As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Comisiones where idComision = " & iidComision
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
        Dim sel As String = "delete from Comisiones where idComercial = " & iidComercial
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
            Dim sel As String = "delete from Comisiones where idCliente = " & iidCliente
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
