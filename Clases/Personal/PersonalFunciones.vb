Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesPersonal
    Inherits conexion
    Dim cmd As SqlCommand
    Dim funcMA As New FuncionesMails

    Public Function MostrarPerfil(ByVal iidPerfil As Integer) As DataTable 'Devuelve la lista de personal
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Personal.*,ltrim(rtrim(Nombre)) + ' ' + ltrim(rtrim(Apellidos)) as NombreC , departamentos.Departamento  FROM Personal "
            sel = sel & " LEFT JOIN Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " LEFT JOIN departamentos ON departamentos.idDepartamento = Contactos.idDepartamento Where idPerfil = " & iidPerfil & " Order By Nombre ASC "
            cmd = New SqlCommand(sel, con)

            con.Open()
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
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExistePerfil(ByVal iidPerfil As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT count(*) FROM Personal  Where idPerfil = " & iidPerfil, con)

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
        Finally
            desconectado()
        End Try
    End Function

    Public Function Permiso(ByVal iidUsuario As Integer, ByVal sEjecutar As String) As Boolean
        'Nos devuelve si el usuario tiene permiso para acceder a la entrade de menu especificada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(idUsuario) from Menu_EntradasUsuario as MPU left join Menu_Entradas On Menu_Entradas.idMenu = MPU.idMenu where Ejecutar = '" & sEjecutar & "' AND idUsuario = " & iidUsuario, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then 'Si no lo encuentra devuelve el parámetro del perfil
                Dim func As New funcionesMenu_EntradasPerfil
                Return func.Permiso(campoidPerfil(iidUsuario), sEjecutar)
            Else
                Return CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Parametro(ByVal iidUsuario As Integer, ByVal sEjecutar As String, ByVal bParametro As String) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Valor from Menu_ParametrosUsuario as MPU left join Menu_Entradas On Menu_Entradas.idMenu = MPU.idMenu where Ejecutar = '" & sEjecutar & "' AND idUsuario = " & iidUsuario & " and Parametro ='" & bParametro & "' ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then 'Si no lo encuentra devuelve el parámetro del perfil
                Dim func As New funcionesMenu_ParametrosPerfil
                Return func.Parametro(campoidPerfil(iidUsuario), sEjecutar, bParametro)
            Else
                Return CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
      
    End Function

    Public Function campoidPerfil(ByVal vidPersona As Integer) As Integer  'Devuelve el nombre completo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idPerfil  from Personal WHERE idPersona = " & vidPersona, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return 0
            Else
                Return CInt(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function actualizarPerfil(ByVal iidPersona As Integer, ByVal iidPerfil As Integer) As Boolean
        'Actualiza un registro de la tabla con el dato del perfil
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Personal set  idPerfil = @idPerfil  WHERE idPersona = " & iidPersona

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idPerfil", iidPerfil)

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
    End Function

    Public Function verStock(idUsuario As Integer) As Boolean 'Nos dice si el usuario puede ver el stock del menu producción
        Dim show As Boolean = False
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Count(*) from Menu_EntradasUsuario where idMenu = 129 and idUsuario = " & idUsuario, con)

            con.Open()
            Dim o As Integer = cmd.ExecuteScalar
            con.Close()
            If o > 0 Then
                show = True
            End If
            Return show
        Catch ex As Exception
            MsgBox(ex.Message)
            Return show
        End Try
    End Function

    Public Function InactivaId(ByVal iidPersona As Integer) As Boolean
        'Cambia el campo Activo a Inactivo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Personal set  Activo = 0  WHERE idPersona = " & iidPersona

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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
            Finally
                desconectado()
            End Try
        End Using
    End Function

    Public Function Mostrar() As List(Of DatosPersonal) 'Devuelve la lista de personal
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Personal.*, departamentos.departamento, departamentos.idDepartamento, Contactos.Nombre, Contactos.Apellidos, Perfiles.SoloLectura, Perfiles.Perfil  FROM Personal LEFT JOIN Perfiles ON Perfiles.idPerfil = Personal.idPerfil "
            sel = sel & " LEFT JOIN Contactos on Contactos.idContacto = Personal.idContacto left Join departamentos ON departamentos.idDepartamento = Contactos.idDepartamento  Order By Nombre ASC "
            Dim lista As New List(Of DatosPersonal)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosPersonal
                For Each linea In dt.Rows
                    If linea("idPersona") Is DBNull.Value Then
                    Else
                        dts = New DatosPersonal
                        dts.gidPersona = linea("idPersona")
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gApellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                        dts.gContrasena = If(linea("Contrasena") Is DBNull.Value, "", linea("Contrasena"))
                        Dim encriptador As New Simple3Des
                        dts.gContrasena = encriptador.DecryptData(dts.gContrasena)
                        dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
                        dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        dts.gmail = funcMA.MostrarContactoStr(dts.gidContacto) 'If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gUsuario = If(linea("Usuario") Is DBNull.Value, "", linea("Usuario"))
                        dts.gValidaPedidosProv = If(linea("ValidaPedidosProv") Is DBNull.Value, False, linea("ValidaPedidosProv"))
                        dts.gSoloLectura = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
                        dts.gPerfil = If(linea("Perfil") Is DBNull.Value, "", linea("Perfil"))
                        dts.gcodPersonal = If(linea("codPersonal") Is DBNull.Value, "", linea("codPersonal"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, False, linea("ResponsableCuenta"))
                        dts.gResponsableProd = If(linea("ResponsableProd") Is DBNull.Value, False, linea("ResponsableProd"))
                        dts.gRecibeAvisos = If(linea("RecibeAvisos") Is DBNull.Value, False, linea("RecibeAvisos"))
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

    Public Function Busqueda(ByVal parametro As String, ByVal Orden As String) As List(Of DatosPersonal) 'Devuelve la lista de personal
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Personal.*, departamentos.departamento, departamentos.idDepartamento, Contactos.Nombre, Contactos.Apellidos, Perfiles.SoloLectura, Perfiles.Perfil  FROM Personal LEFT JOIN Perfiles ON Perfiles.idPerfil = Personal.idPerfil "
            sel = sel & " LEFT JOIN Contactos on Contactos.idContacto = Personal.idContacto left Join departamentos ON departamentos.idDepartamento = Contactos.idDepartamento "
            sel = sel & If(parametro = "", "", " WHERE " & parametro)
            sel = sel & If(Orden = "", " Order By Nombre ASC ", " Order By " & Orden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPersonal)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosPersonal
                For Each linea In dt.Rows
                    If linea("idPersona") Is DBNull.Value Then
                    Else
                        dts = New DatosPersonal
                        dts.gidPersona = linea("idPersona")
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gApellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                        dts.gContrasena = If(linea("Contrasena") Is DBNull.Value, "", linea("Contrasena"))
                        Dim encriptador As New Simple3Des
                        dts.gContrasena = encriptador.DecryptData(dts.gContrasena)
                        dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
                        dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        dts.gmail = funcMA.MostrarContactoStr(dts.gidContacto) 'If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gUsuario = If(linea("Usuario") Is DBNull.Value, "", linea("Usuario"))
                        dts.gValidaPedidosProv = If(linea("ValidaPedidosProv") Is DBNull.Value, False, linea("ValidaPedidosProv"))
                        dts.gSoloLectura = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
                        dts.gPerfil = If(linea("Perfil") Is DBNull.Value, "", linea("Perfil"))
                        dts.gcodPersonal = If(linea("codPersonal") Is DBNull.Value, "", linea("codPersonal"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, False, linea("ResponsableCuenta"))
                        dts.gResponsableProd = If(linea("ResponsableProd") Is DBNull.Value, False, linea("ResponsableProd"))
                        dts.gRecibeAvisos = If(linea("RecibeAvisos") Is DBNull.Value, False, linea("RecibeAvisos"))
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

    Public Function Mostrar1(ByVal iidPersona As Integer) As DatosPersonal 'Devuelve los datos de una persona
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Personal.*, departamentos.departamento, departamentos.idDepartamento, Contactos.Nombre, Contactos.Apellidos,  Perfiles.SoloLectura, Perfiles.Perfil  FROM Personal LEFT JOIN Perfiles ON Perfiles.idPerfil = Personal.idPerfil "
            sel = sel & " LEFT JOIN Contactos on Contactos.idContacto = Personal.idContacto left Join departamentos ON departamentos.idDepartamento = Contactos.idDepartamento WHERE idPersona = " & iidPersona & " Order By Nombre ASC "

            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosPersonal
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idPersona") Is DBNull.Value Then
                    Else
                        dts.gidPersona = linea("idPersona")
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gApellidos = If(linea("Apellidos") Is DBNull.Value, "", linea("Apellidos"))
                        dts.gContrasena = If(linea("Contrasena") Is DBNull.Value, "", linea("Contrasena"))
                        Dim encriptador As New Simple3Des
                        dts.gContrasena = encriptador.DecryptData(dts.gContrasena)
                        dts.gDepartamento = If(linea("Departamento") Is DBNull.Value, "", linea("Departamento"))
                        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
                        dts.gidDepartamento = If(linea("idDepartamento") Is DBNull.Value, 0, linea("idDepartamento"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        dts.gmail = funcMA.MostrarContactoStr(dts.gidContacto) 'If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gUsuario = If(linea("Usuario") Is DBNull.Value, "", linea("Usuario"))
                        dts.gValidaPedidosProv = If(linea("ValidaPedidosProv") Is DBNull.Value, False, linea("ValidaPedidosProv"))
                        dts.gSoloLectura = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
                        dts.gPerfil = If(linea("Perfil") Is DBNull.Value, "", linea("Perfil"))
                        dts.gcodPersonal = If(linea("codPersonal") Is DBNull.Value, "", linea("codPersonal"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, False, linea("ResponsableCuenta"))
                        dts.gResponsableProd = If(linea("ResponsableProd") Is DBNull.Value, False, linea("ResponsableProd"))
                        dts.gRecibeAvisos = If(linea("RecibeAvisos") Is DBNull.Value, False, linea("RecibeAvisos"))

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

    Public Function EsSoloLectura(ByVal iidPersona As Integer) As Boolean 'Nos dice si el usuario es de solo lectura
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT SoloLectura FROM Perfiles LEFT JOIN Personal ON Personal.idPerfil = Perfiles.idPerfil WHERE idPersona = " & iidPersona, con)

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

    Public Function ListarResponsables(ByVal iidPersona As Integer) As List(Of IDComboBox) 'Devuelve la lista de responsables de cuenta
        'Lista los responsables de cuenta, si indicamos una persona, sólo devuelve esta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            'Dim sel As String = "SELECT Nombre + ' ' + Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            'sel = sel & " where ResponsableCuenta = 1 and Personal.Activo=1 "
            Dim sel As String = "SELECT Nombre + ' ' + Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            sel = sel & " where  Personal.Activo=1 and (ResponsableCuenta = 1 or idPerfil = 6)"

            If iidPersona > 0 Then
                sel = sel & " AND idPersona = " & iidPersona
            End If
            sel = sel & " Order by Nombre, Apellidos"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("NombreC") Is DBNull.Value Or linea("idPersona") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(Trim(UCase(linea("NombreC"))), linea("idPersona")))
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

    Public Function ListarResponsablesProd() As List(Of IDComboBox) 'Devuelve la lista de responsables de cuenta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Nombre + ' ' + Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            sel = sel & " where ResponsableProd = 1 and Personal.Activo=1 Order by Nombre, Apellidos"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("NombreC") Is DBNull.Value Or linea("idPersona") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(Trim(UCase(linea("NombreC"))), linea("idPersona")))
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

    Public Function ListarComerciales() As List(Of IDComboBox) 'Devuelve la lista de personal del departamento COMERCIAL
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Nombre + ' ' +Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            sel = sel & " left join departamentos on Contactos.idDepartamento = departamentos.idDepartamento "

            sel = sel & "WHERE departamentos.Departamento like '%COMERCIAL%' AND Activo = 1"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("NombreC") Is DBNull.Value Or linea("idPersona") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(Trim(UCase(linea("NombreC"))), linea("idPersona")))
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

    Public Function ListarTecnicos() As List(Of IDComboBox) 'Devuelve la lista de personal del departamento COMERCIAL
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Nombre + ' ' +Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            sel = sel & " left join departamentos on Contactos.idDepartamento = departamentos.idDepartamento "

            sel = sel & "WHERE (departamentos.Departamento like '%TECNICO%' or  departamentos.Departamento like '%TÉCNICO%') AND Activo = 1"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("NombreC") Is DBNull.Value Or linea("idPersona") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(Trim(UCase(linea("NombreC"))), linea("idPersona")))
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

    Public Function Listar() As List(Of IDComboBox)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT Nombre + ' ' +Apellidos as NombreC, Personal.idPersona FROM Personal left join Contactos ON Contactos.idContacto = Personal.idContacto  "
            sel = sel & "WHERE  Activo = 1 ORDER By Nombre,Apellidos"

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("NombreC") Is DBNull.Value Or linea("idPersona") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(Trim(UCase(linea("NombreC"))), linea("idPersona")))
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

    Public Function InicioSesion(ByVal vUsuario As String, ByVal vContrasena As String) As Integer 'Devuelve el ID de usuario, -1 si no existe
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim encriptador As New Simple3Des
            cmd = New SqlCommand("SELECT idPersona FROM Personal WHERE Activo = 1 AND Usuario = '" & vUsuario & "'", con)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                MsgBox("Usuario no existe", MsgBoxStyle.Critical)
                Inicio.vIntentos = 0
                Inicio.usuario.Focus()
                Return -1
            Else
                con.Open()
                cmd = New SqlCommand("SELECT idPersona FROM Personal WHERE Activo = 1 AND Usuario = '" & vUsuario & "' AND Contrasena = '" & encriptador.EncryptData(vContrasena) & "' ", con)
                O = cmd.ExecuteScalar
                con.Close()
                If O Is DBNull.Value Or O Is Nothing Then
                    MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)
                    Inicio.contrasena.Focus()
                    Return -1
                Else
                    Return CInt(O)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExisteUsuario(ByVal vUsuario As String, ByVal iidPersona As Integer) As Boolean 'Nos dice si existe el usuario 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Usuario FROM Personal WHERE Usuario = '" & vUsuario & "' and idPersona <> " & iidPersona, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return False
            Else
                Return vUsuario = CStr(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExistecodPersonal(ByVal scodPersonal As String, ByVal iidPersona As Integer) As Boolean 'Nos dice si existe el usuario 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT codPersonal FROM Personal WHERE codPersonal = '" & scodPersonal & "' and idPersona <> " & iidPersona, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return False
            Else

                Return scodPersonal = CStr(O)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Campo(ByVal vCampo As String, ByVal iidPersona As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM Personal WHERE idPersona = " & iidPersona, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return Nothing
            Else
                Return O
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoNombreyApellidos(ByVal iidPersona As Integer) As String  'Devuelve el nombre completo
        Try
            If iidPersona = 0 Then
                Return ""
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select lTrim(rTrim(Nombre)) + ' ' + lTrim(rTrim(Apellidos)) from Contactos left join Personal ON Personal.idContacto = Contactos.idContacto WHERE idPersona = " & iidPersona, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar()
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoNombre(ByVal iidPersona As Integer) As String  'Devuelve el nombre completo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select lTrim(rTrim(Nombre)) from Contactos left join Personal ON Personal.idContacto = Contactos.idContacto WHERE idPersona = " & iidPersona, con)

            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoCorreo(ByVal iidPersona As Integer) As String
        Try
            If iidPersona = 0 Then
                Return ""
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select mail from Mails left join Contactos ON Contactos.idContacto = Mails.idContacto left join Personal ON Personal.idContacto = Contactos.idContacto WHERE idPersona = " & iidPersona, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar()
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CorreoAvisos() As String
        Try
           
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select mail from Mails left join Contactos ON Contactos.idContacto = Mails.idContacto left join Personal ON Personal.idContacto = Contactos.idContacto WHERE RecibeAvisos = 1 ", con)
            Dim Destinatarios As String = ""
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("mail") Is DBNull.Value Then
                    Else
                        If Destinatarios <> "" Then Destinatarios = Destinatarios & "; "
                        Destinatarios = Destinatarios & linea("mail")
                    End If
                Next
            Else
                con.Close()
            End If
            Return Destinatarios
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoResponsableCuenta(ByVal iidPersona As Integer) As Boolean  'Devuelve si es sin envase
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select ResponsableCuenta from Personal WHERE idPersona = " & iidPersona, con)
            con.Open()
            Dim resultado As Boolean = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoValidaPedidosProv(ByVal iidPersona As Integer) As Boolean  'Devuelve si es sin envase
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select ValidaPedidosProv from Personal WHERE idPersona = " & iidPersona, con)
            con.Open()
            Dim resultado As Boolean = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoDepartamento(ByVal iidPersona As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Departamento from Departamentos left Join Contactos ON Contactos.idDepartamento = Departamentos.idDepartamento left join Personal ON Personal.idContacto = Contactos.idContacto WHERE idPersona = " & iidPersona, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function campoidContacto(ByVal iidPersona As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idContacto from  Personal  WHERE idPersona = " & iidPersona, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function insertar(ByVal dts As DatosPersonal) As Integer
        'Insertar una nuevo tipo de caducidad
        'If ExistecodPersonal(dts.gcodPersonal, dts.gidPersona) Then
        '    MsgBox("Ya existe una persona con este código")
        '    Return -1
        'Else
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Personal ( idContacto, Usuario, Contrasena, Activo, idPerfil, codPersonal, ValidaPedidosProv, ResponsableCuenta, ResponsableProd, RecibeAvisos) values ( @idContacto, @Usuario, @Contrasena, @Activo, @idPerfil, @codPersonal, @ValidaPedidosProv, @ResponsableCuenta, @ResponsableProd, @RecibeAvisos ) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("Usuario", dts.gUsuario)
                Dim encriptador As New Simple3Des
                cmd.Parameters.AddWithValue("Contrasena", encriptador.EncryptData(dts.gContrasena))
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
                cmd.Parameters.AddWithValue("codPersonal", dts.gcodPersonal)
                cmd.Parameters.AddWithValue("ValidaPedidosProv", dts.gValidaPedidosProv)
                'cmd.Parameters.AddWithValue("GestionaPersonal", dts.gGestionaPersonal)
                cmd.Parameters.AddWithValue("ResponsableCuenta", dts.gResponsableCuenta)
                cmd.Parameters.AddWithValue("ResponsableProd", dts.gResponsableProd)
                cmd.Parameters.AddWithValue("RecibeAvisos", dts.gRecibeAvisos)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
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

        End Using

        ' End If


    End Function

    Public Function actualizar(ByVal dts As DatosPersonal) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo

        'If ExistecodPersonal(dts.gcodPersonal, dts.gidPersona) Then
        '    MsgBox("Ya existe una persona con este código")
        '    Return -1
        'Else
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Personal set idContacto = @idContacto, Usuario = @Usuario, Contrasena = @Contrasena,Activo = @Activo, idPerfil = @idPerfil,  codPersonal = @codPersonal, ValidaPedidosProv = @ValidaPedidosProv, ResponsableCuenta = @ResponsableCuenta, ResponsableProd = @ResponsableProd, RecibeAvisos = @RecibeAvisos  WHERE idPersona = @idPersona "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("Usuario", dts.gUsuario)
                Dim encriptador As New Simple3Des
                cmd.Parameters.AddWithValue("Contrasena", encriptador.EncryptData(dts.gContrasena))
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
                cmd.Parameters.AddWithValue("codPersonal", dts.gcodPersonal)
                cmd.Parameters.AddWithValue("ValidaPedidosProv", dts.gValidaPedidosProv)
                ' cmd.Parameters.AddWithValue("GestionaPersonal", dts.gGestionaPersonal)
                cmd.Parameters.AddWithValue("ResponsableCuenta", dts.gResponsableCuenta)
                cmd.Parameters.AddWithValue("ResponsableProd", dts.gResponsableProd)
                cmd.Parameters.AddWithValue("RecibeAvisos", dts.gRecibeAvisos)
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

        ' End If
    End Function

    Public Function actualizarContrasena(ByVal iidPersona As Integer, ByVal vContrasena As String) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Personal set  Contrasena = @Contrasena  WHERE idPersona = " & iidPersona

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                Dim encriptador As New Simple3Des
                cmd.Parameters.AddWithValue("Contrasena", encriptador.EncryptData(vContrasena))
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
    End Function

    Public Function Inactiva(ByVal vUsuario As String) As Boolean
        'Cambia el campo Activo a Inactivo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Personal set  Activo = 0  WHERE Usuario = '" & vUsuario & "' "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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
    End Function

    Public Function borrar(ByVal iidPersona As Integer) As Boolean
        'Borrar contacto
        Dim func As New funcionesContactos
        func.borrar(campoidContacto(iidPersona))
        'Borrar persona
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Personal where idPersona = " & iidPersona
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
        ' End If

    End Function

    Public Function vercostes(ByVal iidusuario As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select * from Menu_entradasusuario where idusuario =" & iidusuario & " and idmenu= 119", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then 'Si no lo encuentra devuelve el parámetro del perfil
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class



