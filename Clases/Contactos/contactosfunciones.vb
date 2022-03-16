Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesContactos
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function mostrarProv(ByVal iidProveedor As Integer) As List(Of datosContacto)
        'Muestra todas los contactos de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select Contactos.*, Departamentos.Departamento from Contactos LEFT JOIN Departamentos ON Departamentos.idDepartamento = Contactos.idDepartamento where idProveedor = " & iidProveedor & " Order by Apellidos, Nombre "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosContacto)
                Dim dts As datosContacto
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosContacto
                    dts.gidContacto = linea("idContacto")
                    dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
                    dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
                    dts.gnombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gapellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                    dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                    dts.gCargo = If(linea("Cargo") Is DBNull.Value, "", linea("Cargo"))
                    dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                    dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrarCli(ByVal iidCliente As Integer) As List(Of datosContacto)
        'Muestra todas los contactos de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select Contactos.*, Departamentos.Departamento from Contactos LEFT JOIN Departamentos ON Departamentos.idDepartamento = Contactos.idDepartamento where idCliente = " & iidCliente & " Order by Apellidos, Nombre "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosContacto)
                Dim dts As datosContacto
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosContacto
                    dts.gidContacto = linea("idContacto")
                    dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
                    dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                    dts.gnombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gapellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                    dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                    dts.gCargo = If(linea("Cargo") Is DBNull.Value, "", linea("Cargo"))
                    dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                    dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrar1(ByVal iidContacto As Integer) As datosContacto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select Contactos.*, Departamentos.Departamento from Contactos LEFT JOIN Departamentos ON Departamentos.idDepartamento = Contactos.idDepartamento where idContacto = " & iidContacto
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosContacto
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts.gidContacto = linea("idContacto")
                    dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
                    dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
                    dts.gnombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gapellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                    dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                    dts.gCargo = If(linea("Cargo") Is DBNull.Value, "", linea("Cargo"))
                    dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                    dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                Next
                Return dts
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function










    Public Function mostrar(ByVal sidCliente As Integer, ByVal icontacto As Integer, ByVal iproveedor As Integer) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If sidCliente > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.Departamento from CONTACTOS left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where idCliente = " & sidCliente & "", con)
            End If
            If icontacto > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.Departamento from CONTACTOS left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where idContacto = " & icontacto & "", con)
            End If
            If iproveedor > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.Departamento from CONTACTOS left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where idProveedor = " & iproveedor & "", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrarP(ByVal scodProsp As Integer, ByVal icontacto As Integer, ByVal iproveedor As Integer) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If scodProsp > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.descripcion as Departamento from CONTACTOS  left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where codProsp = " & scodProsp & "", con)
            End If
            If icontacto > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.descripcion as Departamento from CONTACTOS   left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where idContacto = " & icontacto & "", con)
            End If
            If iproveedor > 0 Then
                cmd = New SqlCommand("select *,nombre + ' ' + apellidos as NombreC, departamentos.descripcion as Departamento  from CONTACTOS left join departamentos on departamentos.idDepartamento = Contactos.idDepartamento where idProveedor = " & iproveedor & "", con)

            End If

            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As datosContacto) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into contactos (idProveedor, idUbicacion, idCliente, nombre, apellidos, idDepartamento, cargo, Observaciones) values (@idProveedor, @idUbicacion, @idcliente, @nombre, @apellidos, @idDepartamento, @cargo, @Observaciones ) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idproveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("nombre", dts.gnombre)
                cmd.Parameters.AddWithValue("apellidos", dts.gapellidos)
                cmd.Parameters.AddWithValue("idDepartamento", dts.gidDepartamento)
                cmd.Parameters.AddWithValue("cargo", dts.gCargo)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                con.Open()
                'cmd.ExecuteNonQuery()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteScalar())
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

    Public Function actualizar(ByVal dts As datosContacto) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update contactos set idProveedor = @idProveedor, idUbicacion = @idUbicacion, nombre = @nombre, apellidos = @apellidos, idDepartamento = @idDepartamento, cargo = @cargo, Observaciones = @Observaciones where idcontacto = @idContacto "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idproveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("nombre", dts.gnombre)
                cmd.Parameters.AddWithValue("apellidos", dts.gapellidos)
                cmd.Parameters.AddWithValue("idDepartamento", dts.gidDepartamento)
                cmd.Parameters.AddWithValue("cargo", dts.gCargo)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)

                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function NuevoCliente(ByVal icodProsp As Integer, ByVal iidCliente As Integer) As Boolean
        'Añadir el código de cliente a un contacto de un prospect
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update contactos set idCliente = @idCliente where codProsp = @codProsp "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'insertarcampos
                cmd.Parameters.AddWithValue("idCliente", iidCliente)
                cmd.Parameters.AddWithValue("codProsp", icodProsp)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try
        End Using
    End Function


    Public Function borrar(ByVal iidContacto As Integer) As Boolean
        'Borrar Mails
        Dim func As New FuncionesMails
        func.borrarContacto(iidContacto)
        'Borrar teléfonos
        Dim funcT As New FuncionesTelefonos
        func.borrarContacto(iidContacto)
        'Borrar contacto
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Contactos where idContacto = " & iidContacto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try
        End Using
    End Function


    Public Function borrarProveedor(ByVal iidProveedor As Integer) As Boolean
        ' Borra un documento de la tabla 
        If iidProveedor > 0 Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Contactos where idProveedor = " & iidProveedor
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
                    con.Open()

                    'ejecutar el sql
                    Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                    If t = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                Finally
                    desconectado()
                End Try
            End Using
        End If

    End Function

    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        ' Borra un documento de la tabla 
        If iidCliente > 0 Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Contactos where idCliente = " & iidCliente
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
                    con.Open()

                    'ejecutar el sql
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
