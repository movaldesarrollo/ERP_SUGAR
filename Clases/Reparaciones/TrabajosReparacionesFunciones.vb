Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesTrabajosReparaciones


    Inherits conexion
    Dim cmd As SqlCommand


    Dim sel0 As String = " Select TR.*, Nombre + ' ' + Apellidos as Persona " _
            & " FROM TrabajosReparaciones as TR Left Join Personal as PE ON PE.idPersona = TR.idPersona " _
            & " Left join Contactos ON Contactos.idContacto = PE.idContacto "
         
    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosTrabajoReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numReparacion, idTrabajo ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTrabajoReparacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                'Dim dts As DatosTrabajoReparacion
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idTrabajo") Is DBNull.Value Then
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


    Private Function CargarLinea(ByVal linea As DataRow)
        Dim dts As New DatosTrabajoReparacion
        dts.gidTrabajo = linea("idTrabajo")
        dts.gnumReparacion = If(linea("NumReparacion") Is DBNull.Value, 0, linea("numReparacion"))
        dts.gTrabajo = If(linea("Trabajo") Is DBNull.Value, "", linea("Trabajo"))
        dts.gHoras = If(linea("Horas") Is DBNull.Value, 0, linea("Horas"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gFechaTrabajo = If(linea("FechaTrabajo") Is DBNull.Value, Now.Date, linea("FechaTrabajo"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        Return dts
    End Function

    Public Function Mostrar(ByVal inumReparacion As Integer) As List(Of DatosTrabajoReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE TR.numReparacion = " & inumReparacion & " Order By  idTrabajo "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTrabajoReparacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idTrabajo") Is DBNull.Value Then
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

    Public Function MostrarRealizados(ByVal inumReparacion As Integer) As List(Of DatosTrabajoReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE TR.Orden >0 AND TR.numReparacion = " & inumReparacion & " Order By  idTrabajo "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTrabajoReparacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idTrabajo") Is DBNull.Value Then
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





    Public Function Mostrar1(ByVal iidTrabajo As Integer) As DatosTrabajoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE TR.idTrabajo = " & iidTrabajo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTrabajoReparacion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idTrabajo") Is DBNull.Value Then
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


    Public Function UltimoOrden(ByVal iNumReparacion As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from TrabajosReparaciones where numReparacion = " & iNumReparacion
            cmd = New SqlCommand(sel, con)
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



    Public Function TrabajoARealizar(ByVal iNumReparacion As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select TOP 1 Trabajo from TrabajosReparaciones where Orden = 0 AND numReparacion = " & iNumReparacion
            cmd = New SqlCommand(sel, con)
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

    Public Function ExisteTrabajoARealizar(ByVal iNumReparacion As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idTrabajo from TrabajosReparaciones where Orden = 0 AND numReparacion = " & iNumReparacion
            cmd = New SqlCommand(sel, con)
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




    Public Function insertar(ByVal dts As DatosTrabajoReparacion) As Integer 'Inserta una nueva Reparacion y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into TrabajosReparaciones (numReparacion, Trabajo,  Horas, idPersona, FechaTrabajo, Orden) "
        sel = sel & " values (@numReparacion, @Trabajo, @Horas, @idPersona, @FechaTrabajo, @Orden ) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
                cmd.Parameters.AddWithValue("Trabajo", dts.gTrabajo)
                cmd.Parameters.AddWithValue("Horas", dts.gHoras)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("FechaTrabajo", dts.gFechaTrabajo)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
               
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosTrabajoReparacion) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TrabajosReparaciones set numReparacion = @numReparacion, Trabajo = @Trabajo, Horas = @Horas, idPersona = @idPersona, FechaTrabajo = @FechaTrabajo, Orden = @Orden "
        sel = sel & " WHERE idTrabajo = @idTrabajo"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTrabajo", dts.gidTrabajo)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
                cmd.Parameters.AddWithValue("Trabajo", dts.gTrabajo)
                cmd.Parameters.AddWithValue("Horas", dts.gHoras)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("FechaTrabajo", dts.gFechaTrabajo)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)

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

    Public Function CambiarEstado(ByVal iidTrabajo As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update TrabajosReparaciones set idEstado = " & iidEstado & " where idTrabajo = " & iidTrabajo
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

   




    Public Function borrarReparacion(ByVal inumReparacion As Integer) As Boolean  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from TrabajosReparaciones where numReparacion = " & inumReparacion
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidTrabajo As Integer) As Boolean  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from TrabajosReparaciones where idTrabajo = " & iidTrabajo
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function






End Class
