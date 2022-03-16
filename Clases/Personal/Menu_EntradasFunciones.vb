Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_Entradas
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosMenu_Entrada)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_Entradas where Nombre <> 'Raiz' order by Nivel ASC, Orden ASc", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_Entrada
                Dim lista As New List(Of datosMenu_Entrada)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_Entrada
                        dts.gidMenu = linea("idMenu")
                        dts.gNivel = If(linea("Nivel") Is DBNull.Value, 0, linea("Nivel"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gidMenuPadre = If(linea("idMenuPadre") Is DBNull.Value, 0, linea("idMenuPadre"))
                        dts.gEjecutar = If(linea("Ejecutar") Is DBNull.Value, "", linea("Ejecutar"))

                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar1(ByVal iidMenu As Integer) As datosMenu_Entrada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_Entradas ", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_Entrada
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gNivel = If(linea("Nivel") Is DBNull.Value, 0, linea("Nivel"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gidMenuPadre = If(linea("idMenuPadre") Is DBNull.Value, 0, linea("idMenuPadre"))
                        dts.gEjecutar = If(linea("Ejecutar") Is DBNull.Value, "", linea("Ejecutar"))
                    End If
                Next
                Return dts
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    
    Public Function EntradaMenu(ByVal iidMenu As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_Entradas ", con)
            Dim Resultado As String = ""
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_Entrada
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        Resultado = If(linea("idMenuPadre") Is DBNull.Value, "", EntradaMenu(linea("idMenuPadre")) & "/") & If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    End If
                Next

            Else
                con.Close()
                Return ""
            End If
            Return Resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    'Public Function Entradas(ByVal iidMenu As Integer) As List(Of String)
    '    Try

    '        Dim sconexion As String = CadenaConexion()
    '        Dim con As New SqlConnection(sconexion)
    '        Dim sel As String
    '        sel = "select idMenu, Nombre from Menu_Entradas where idMenuPadre = " & iidMenu
    '        cmd = New SqlCommand(sel, con)

    '        con.Open()
    '        Dim dt As New DataTable
    '        Dim da As New SqlDataAdapter(cmd)
    '        da.Fill(dt)
    '        Dim dts As New datosMenu_Entrada
    '        Dim linea As DataRow
    '        For Each linea In dt.Rows


    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return Nothing
    '    Finally
    '        desconectado()
    '    End Try
    'End Function

    Public Function Literal(ByVal iidMenu As Integer) As String
        Try
            If iidMenu = 0 Then
                Return "NO ESPECIFICADA"
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                sel = " select Nombre3 + case when Nombre3 <>'' and Nombre2 <> '' then ' | ' else '' end + Nombre2 + case when Nombre2 <> '' and Nombre1 <> '' then ' | ' else '' end + Nombre1 "
                sel = sel & " from ( select "
                sel = sel & " case when ME3.Nombre is null or ME3.Nombre = 'Raiz' then '' else ME3.Nombre end as Nombre3,"
                sel = sel & " case when ME2.Nombre = 'Raiz' then '' else ME2.Nombre end as Nombre2,"
                sel = sel & " case when ME1.Nombre = 'Raiz' or ME2.Nombre = 'Raiz' then '' else ME1.Nombre end  as Nombre1, ME3.idmenu as id3, ME2.idmenu as id2, ME1.idmenu as id1"

                sel = sel & " from Menu_Entradas as ME1 left join Menu_Entradas as ME2 on ME1.idmenupadre =ME2.idmenu left join Menu_Entradas as ME3 on ME2.idmenupadre=ME3.idmenu "
                'sel = sel & " Union select '' as Nombre3,Nombre as Nombre2,'' as Nombre3 , idMenu as id3, idMenu as id2, idMenu as id3 from Menu_Entradas where idMenuPadre=0 and Nombre <> 'Raiz' "

                sel = sel & ")X where  (Nombre1<>'' or Nombre2<>'' or Nombre3<>'') And id1 = " & iidMenu

                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return ""
                Else
                    Return CStr(o)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function Literales() As List(Of IDComboBox)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select id1 as idmenu, Nombre3 + case when Nombre3 <>'' and Nombre2 <> '' then ' | ' else '' end + Nombre2 + case when Nombre2 <> '' and Nombre1 <> '' then ' | ' else '' end + Nombre1 as literal "
            sel = sel & " from ( select "
            sel = sel & " case when ME3.Nombre is null or ME3.Nombre = 'Raiz' then '' else ME3.Nombre end as Nombre3,"
            sel = sel & " case when ME2.Nombre = 'Raiz' then '' else ME2.Nombre end as Nombre2,"
            sel = sel & " case when ME1.Nombre = 'Raiz' or ME2.Nombre = 'Raiz' then '' else ME1.Nombre end  as Nombre1, ME3.idmenu as id3, ME2.idmenu as id2, ME1.idmenu as id1"

            sel = sel & " from Menu_Entradas as ME1 left join Menu_Entradas as ME2 on ME1.idmenupadre =ME2.idmenu left join Menu_Entradas as ME3 on ME2.idmenupadre=ME3.idmenu "
            'sel = sel & " Union select '' as Nombre3,Nombre as Nombre2,'' as Nombre3 , idMenu as id3, idMenu as id2, idMenu as id3 from Menu_Entradas where idMenuPadre=0 and Nombre <> 'Raiz' "
            sel = sel & ")X where  (Nombre1<>'' or Nombre2<>'' or Nombre3<>'')  "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            Dim par As IDComboBox
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_Entrada
                Dim linea As DataRow
                For Each linea In dt.Rows
                    par = New IDComboBox
                    par.Name = If(linea("literal") Is DBNull.Value, "", linea("literal"))
                    par.ItemData = If(linea("idMenu") Is DBNull.Value, 0, linea("idMenu"))
                    lista.Add(par)
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function iidMenu(ByVal sParametro As String) As Integer
        Try

            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idMenu from Menu_Entradas where Ejecutar = '" & sParametro & "' ", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function insertar(ByVal dts As datosMenu_Entrada) As Boolean

        If EntradaExiste(dts.gidMenu, dts.gEjecutar, 0) Then
            MsgBox("Ya existe una entrada con esa ID o valor")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Menu_Entradas (idMenu, Nivel, Nombre, idMenuPadre, Ejecutar) values (@idMenu, @Nivel, @Nombre, @idMenuPadre, @Ejecutar) "

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                    cmd.Parameters.AddWithValue("Nivel", dts.gNivel)
                    cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                    cmd.Parameters.AddWithValue("idMenuPadre", dts.gidMenuPadre)
                    cmd.Parameters.AddWithValue("Ejecutar", dts.gEjecutar)
                    con.Open()

                    Return cmd.ExecuteScalar() > 0

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try

            End Using


        End If


    End Function

    Public Function EntradaExiste(ByVal iidMenu As Integer, ByVal sEjecutar As String, ByVal iidMenu0 As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "Select iidMenu From Menu_Entradas where (iidMenu = @iidMenu or Ejecutar = @Ejecutar) and iidMEnu <> @iidMenu0 "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("iidMenu", iidMenu)
                cmd.Parameters.AddWithValue("Ejecutar", sEjecutar)
                cmd.Parameters.AddWithValue("iidMenu0", iidMenu0)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (iidMenu = CInt(o))
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function TieneHijos(ByVal iidMenu As Integer) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "Select Count(idMenu) From Menu_Entradas where idMenuPadre = " & iidMenu

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

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
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosMenu_Entrada) As Boolean

        If EntradaExiste(0, dts.gEjecutar, dts.gidMenu) Then
            MsgBox("Ya existe una entrada con ese valor")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = "update Menu_Entradas set idMenu = @idMenu, Nivel = @Nivel, Nombre = @Nombre, idMenuPadre = @idMenuPadre, Ejecutar = @Ejecutar  where idMenu = @idMenu "

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)

                    'insertarcampos
                    cmd.Parameters.AddWithValue("idMEnu", dts.gidMenu)
                    cmd.Parameters.AddWithValue("Nivel", dts.gNivel)
                    cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                    cmd.Parameters.AddWithValue("idMenuPadre", dts.gidMenuPadre)
                    cmd.Parameters.AddWithValue("Ejecutar", dts.gEjecutar)

                    'abrir conexion
                    con.Open()

                    'ejecutar el sql
                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                Finally
                    desconectado()
                End Try

            End Using

        End If

    End Function


    Public Function borrar(ByVal iidMenu As String) As Boolean

        If TieneHijos(iidMenu) > 0 Then
            MsgBox("Esta entrada de menu tiene submenus")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = "delete from Menu_Entradas where idMenu = " & iidMenu

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
                    con.Open()

                    'ejecutar el sql
                    Return cmd.ExecuteNonQuery() > 0

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                Finally
                    desconectado()
                End Try

            End Using

        End If

    End Function




End Class
