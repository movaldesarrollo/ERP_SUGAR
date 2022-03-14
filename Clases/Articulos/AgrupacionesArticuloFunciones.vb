Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesAgrupacionesArticulo
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal iidAgrupacion As Integer) As List(Of DatosAgrupacionArticulo) 'Devuelve los datos de una Agrupacion como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidAgrupacion = 0 Then
                sel = "SELECT * FROM AgrupacionesArticulo " & " ORDER BY idAgrupacion ASC "
            Else
                sel = "SELECT * FROM AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosAgrupacionArticulo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosAgrupacionArticulo

                For Each linea In dt.Rows
                    If linea("idAgrupacion") Is DBNull.Value Then
                    Else
                        dts = New DatosAgrupacionArticulo
                        dts.gidAgrupacion = linea("idAgrupacion")
                        dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

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

    Public Function Mostrardt(ByVal iidAgrupacion As Integer) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidAgrupacion = 0 Then
                'Ordenados, dejando para el final los industriales y el último OTROS
                sel = "SELECT *,0 as Cantidad FROM AgrupacionesArticulo " & " ORDER BY case when Agrupacion like 'OTR%' then 'zz' + Agrupacion when Agrupacion like '%Industrial%' then 'zy' + Agrupacion else Agrupacion end ASC "
            Else
                sel = "SELECT *, 0 as Cantidad FROM AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion
            End If
            cmd = New SqlCommand(sel, con)
            Dim dt As New DataTable
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                con.Close()
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar1(ByVal iidAgrupacion As Integer) As DatosAgrupacionArticulo 'Devuelve los datos de una Agrupacion como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
           
            sel = "SELECT * FROM AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosAgrupacionArticulo
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idAgrupacion") Is DBNull.Value Then
                    Else
                        dts.gidAgrupacion = linea("idAgrupacion")
                        dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
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

    Public Function Campo(ByVal vCampo As String, ByVal iidAgrupacion As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Then
                Return Nothing
            Else
                Return O
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Agrupacion(ByVal iidAgrupacion As Integer) As String  'Devuelve el nombre de la Agrupacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Agrupacion from AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function AgrupacionidsubTipo(ByVal iidsubTipo As Integer) As String  'Devuelve el nombre de la Agrupacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Agrupacion from AgrupacionesArticulo As AA "
            sel = sel & " left join subTiposArticulo as ST ON ST.idAgrupacion = AA.idAgrupacion"
            sel = sel & " WHERE idsubTipoArticulo = " & iidsubTipo
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function AgrupacionidArticulo(ByVal iidArticulo As Integer) As String  'Devuelve el nombre de la Agrupacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Agrupacion from Articulos left join subTiposArticulo as ST ON Articulos.idsubTipoArticulo = ST.idsubTipoArticulo "
            sel = sel & " left join AgrupacionesArticulo As AA ON ST.idAgrupacion = AA.idAgrupacion"
            sel = sel & " WHERE idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function



    Public Function idAgrupacion(ByVal Agrupacion As String) As Integer  'Devuelve el id de la Agrupacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idAgrupacion from AgrupacionesArticulo WHERE Agrupacion = '" & Agrupacion & "' ", con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return 0
            Else
                Return CInt(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function





    Public Function Descripcion(ByVal iidAgrupacion As Integer) As String  'Devuelve el nombre de la Agrupacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Borrable(ByVal iidAgrupacion As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Borrable from AgrupacionesArticulo WHERE idAgrupacion = " & iidAgrupacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return True
            Else
                Return CBool(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function insertar(ByVal dts As DatosAgrupacionArticulo) As Integer
        'Insertar una nuevo Agrupacion de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into AgrupacionesArticulo ( Agrupacion, Descripcion) values ( @Agrupacion, @Descripcion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Agrupacion", dts.gAgrupacion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)

                con.Open()

                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosAgrupacionArticulo) As Boolean
        'Actualiza un registro de la tabla MP_Agrupaciones con IDAgrupacion
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update AgrupacionesArticulo set  Agrupacion = @Agrupacion, Descripcion = @Descripcion  WHERE idAgrupacion = " & dts.gidAgrupacion

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("Agrupacion", dts.gAgrupacion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)

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

    Public Function borrar(ByVal iidAgrupacion As Integer) As Boolean
        'Borramos la Agrupacion si no hay ningun producto que lo tenga

        If Borrable(iidAgrupacion) Then

            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from AgrupacionesArticulo where idAgrupacion = " & iidAgrupacion
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
        Else
            MsgBox("Esta Agrupacion no es borrable.")
        End If

    End Function


End Class



