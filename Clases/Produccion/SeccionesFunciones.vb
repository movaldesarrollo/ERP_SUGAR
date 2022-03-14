'Se compone de las funciones de secciones.

Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesSecciones

    Inherits conexion

    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosSeccion) 'Devuelve los datos de una Seccion como Lista

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT * FROM Secciones " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER BY Seccion ASC "

            Dim lista As New List(Of DatosSeccion)

            cmd = New SqlCommand(sel, con)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                Dim dts As DatosSeccion

                For Each linea In dt.Rows

                    If linea("idSeccion") Is DBNull.Value Then

                    Else

                        dts = New DatosSeccion

                        dts.gidSeccion = linea("idSeccion")

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))

                        dts.gPrecioHora = If(linea("PrecioHora") Is DBNull.Value, 0, linea("PrecioHora"))

                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gVista = If(linea("Vista") Is DBNull.Value, "", linea("Vista"))

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

    Public Function Mostrar1(ByVal iidSeccion As Integer) As DatosSeccion 'Devuelve los datos de una Seccion como Lista

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT * FROM Secciones WHERE idSeccion = " & iidSeccion

            cmd = New SqlCommand(sel, con)

            Dim dts As New DatosSeccion

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idSeccion") Is DBNull.Value Then

                    Else

                        dts.gidSeccion = linea("idSeccion")

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))

                        dts.gPrecioHora = If(linea("PrecioHora") Is DBNull.Value, 0, linea("PrecioHora"))

                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gVista = If(linea("Vista") Is DBNull.Value, "", linea("Vista"))

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

    Public Function Secciones(ByVal sVista As String) As List(Of Integer) 'Devuelve los idSección de una vista

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT idSeccion FROM Secciones WHERE Vista = '" & sVista & "' "

            Dim Resultado As New List(Of Integer)

            cmd = New SqlCommand(sel, con)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idSeccion") Is DBNull.Value Then

                    Else

                        Resultado.Add(linea("idSeccion"))

                    End If

                Next

            Else

                con.Close()

            End If

            Return Resultado

        Catch ex As Exception

            MsgBox(ex.Message)

            Return Nothing

        End Try

    End Function

    Public Function CambiarOrden(ByVal iidSeccion As Integer, ByVal Orden As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()

        Dim sel As String = "Update Secciones set Orden = " & Orden & " where idSeccion = " & iidSeccion

        Using con As New SqlConnection(sconexion)

            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'abrir conexion
                con.Open()

                Dim t As Integer = cmd.ExecuteNonQuery()

                con.Close()

                Return t

            Catch ex As Exception

                MsgBox(ex.Message)

                Return False

            End Try

        End Using

    End Function

    Public Function Renumerar() As Boolean

        'Renumera las secciones si hay nº de orden repetido, pone primero el mas nuevo
        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "Select idSeccion, Orden from Secciones  Order By  Orden ASC, Modificacion DESC"

            cmd = New SqlCommand(sel, con)

            Dim lista As New List(Of DatosConceptoPedido)

            Dim linea As DataRow

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim Orden As Integer = 1

                For Each linea In dt.Rows

                    If linea("idSeccion") Is DBNull.Value Then

                    Else

                        CambiarOrden(linea("idSeccion"), Orden)

                        Orden = Orden + 1

                    End If

                Next

                Return True

            Else

                con.Close()

                Return False

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return Nothing

        End Try

    End Function

    Public Function Campo(ByVal vCampo As String, ByVal iidSeccion As Integer) As Boolean 'Devuelve el valor de un campo booleano 

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT " & vCampo & " FROM Secciones WHERE idSeccion = " & iidSeccion, con)

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

    Public Function Seccion(ByVal iidSeccion As Integer) As String  'Devuelve el nombre de la Seccion

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Seccion from Secciones WHERE idSeccion = " & iidSeccion, con)

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

    Public Function idSeccion(ByVal Seccion As String) As Integer  'Devuelve el id de la Seccion

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select idSeccion from Secciones WHERE Seccion = '" & Seccion & "' ", con)

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

    Public Function idSeccion1() As Integer  'Devuelve el id de la Seccion

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Top 1 idSeccion from Secciones Order by Orden ASC ", con)

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

    Public Function Descripcion(ByVal iidSeccion As Integer) As String  'Devuelve el nombre de la Seccion

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Descripcion from Secciones WHERE idSeccion = " & iidSeccion, con)

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

    Public Function Activo(ByVal iidSeccion As Integer) As Boolean  'Devuelve el nombre de la Seccion

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Activo from Secciones WHERE idSeccion = " & iidSeccion, con)

            con.Open()

            Dim o As Object = cmd.ExecuteScalar()

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

    Public Function EstaEnUso(ByVal iidSeccion As Integer) As Integer

        Try

            Dim sconexion As String = CadenaConexion()

            Dim sel As String

            sel = "declare @Contador int;"

            sel = sel & " set @Contador = (SELECT  count(idConcepto) as Contador FROM ConceptosEscandallos where idSeccion = " & iidSeccion & ") + "

            sel = sel & " (SELECT  count(idArticulo) as Contador FROM Articulos where idSeccion = " & iidSeccion & ") Select @Contador "

            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim o As Object = cmd.ExecuteScalar

                con.Close()

                If o Is DBNull.Value Or o Is Nothing Then

                    Return 0

                Else

                    Return CInt(o)

                End If

            End Using

        Catch ex As Exception

            MsgBox(ex.Message)

            Return Nothing

        End Try

    End Function

    Public Function insertar(ByVal dts As DatosSeccion) As Integer

        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()

        Dim sel As String

        sel = "insert into Secciones ( Seccion, Descripcion, Activo,PrecioHora, Orden,Vista, idCreador, Creacion) values ( @Seccion, @Descripcion, @Activo, @PrecioHora, @Orden, @Vista,@idCreador, @Creacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)

            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Seccion", dts.gSeccion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("PrecioHora", dts.gPrecioHora)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Vista", dts.gVista)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
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

    Public Function actualizar(ByVal dts As DatosSeccion) As Boolean

        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()

        Dim sel As String

        sel = "update Secciones set  Seccion = @Seccion, Descripcion = @Descripcion, Activo = @Activo, PrecioHora = @PrecioHora, Orden = @Orden, Vista = @Vista, idModifica = @idModifica, Modificacion = @Modificacion  WHERE idSeccion = " & dts.gidSeccion

        Using con As New SqlConnection(sconexion)

            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("Seccion", dts.gSeccion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("PrecioHora", dts.gPrecioHora)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Vista", dts.gVista)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function borrar(ByVal iidSeccion As Integer) As Boolean

        'Borramos la Seccion si no hay ningun producto que lo tenga
        Dim func As New FuncionesArticulos

        Dim contador As Integer = func.Contador(" idSeccion = " & iidSeccion)

        If contador > 0 Then

            MsgBox("Existen " & contador & " Materias Primas de esta Seccion, por tanto no se puede borrar. En su lugar puede cambiar el nombre de la Seccion.")

        Else

            Dim sconexion As String = CadenaConexion()

            Dim sel As String = "delete from Secciones where idSeccion = " & iidSeccion

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



