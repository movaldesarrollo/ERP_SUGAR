Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesEtiquetas
    Inherits conexion
    Dim cmd As SqlCommand


    Public Function MostrarEditadas(ByVal SoloActivas As Boolean) As List(Of DatosEtiqueta) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ET.*, NombreComercial as Cliente from etiquetas as ET left join Clientes  ON Clientes.idCliente = ET.idCliente where EtiquetaEditada = 1 "
            sel = sel & " AND Nombre <> 'EtiquetaPlantilla' "
            sel = sel & If(SoloActivas, " AND (ET.Activo = 1 or ET.Activo is null)", "") & " order by Nombre ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEtiqueta)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    lista.Add(CargarLinea(linea))
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

    Public Function Mostrar(ByVal SoloActivas As Boolean) As List(Of DatosEtiqueta) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ET.*, NombreComercial as Cliente from etiquetas as ET left join Clientes  ON Clientes.idCliente = ET.idCliente "
            sel = sel & " WHERE Nombre <> 'EtiquetaPlantilla' "
            sel = sel & If(SoloActivas, " AND (ET.Activo = 1 or ET.Activo is null) ", "") & " order by Nombre ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEtiqueta)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    lista.Add(CargarLinea(linea))
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

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEtiqueta) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ET.*, case when ET.idCliente = 0 AND EtiquetaEditada = 1 then 'GENÉRICO' else NombreComercial end as Cliente from etiquetas as ET left join Clientes  ON Clientes.idCliente = ET.idCliente "
            sel = sel & " WHERE Nombre <> 'EtiquetaPlantilla' "
            sel = sel & If(sBusqueda.Length = 0, "", " AND " & sBusqueda) & If(sOrden.Length = 0, " Order By Nombre ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEtiqueta)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    lista.Add(CargarLinea(linea))
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosEtiqueta
        Dim dts As New DatosEtiqueta
        dts.gidEtiqueta = linea("idEtiqueta")
        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
        dts.gFichero = If(linea("Fichero") Is DBNull.Value, "", linea("Fichero"))
        dts.gEtiquetaEditada = If(linea("EtiquetaEditada") Is DBNull.Value, False, linea("EtiquetaEditada"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))

        Return dts
    End Function

    Public Function Mostrar1(ByVal iidEtiqueta As Integer) As DatosEtiqueta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ET.*, NombreComercial as Cliente from etiquetas as ET left join Clientes  ON Clientes.idCliente = ET.idCliente  where idEtiqueta = " & iidEtiqueta
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEtiqueta
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = CargarLinea(linea)
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


    Public Function idEtiqueta(ByVal iidCliente As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT max(idEtiqueta) FROM Etiquetas WHERE (Activo is null or Activo = 1) and idCliente = " & iidCliente
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

    Public Function Etiqueta(ByVal iidEtiqueta As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Nombre FROM Etiquetas WHERE idEtiqueta = " & iidEtiqueta
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

    Public Function ExisteEtiqueta(ByVal Nombre As String, ByVal iidEtiqueta As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Nombre = Replace(UCase(Nombre), " ", "")
            If iidEtiqueta = 0 Then
                sel = "SELECT Nombre FROM Etiquetas WHERE  Upper(Replace(Nombre,' ','')) = '" & Nombre & "' "
            Else
                sel = "SELECT Nombre FROM Etiquetas WHERE  Upper(Replace(Nombre,' ','')) = '" & Nombre & "' AND idEtiqueta <> " & iidEtiqueta
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CStr(o) = Nombre)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idEtiqueta(ByVal Nombre As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Nombre = Replace(UCase(Nombre), " ", "")

            sel = "SELECT idEtiqueta FROM Etiquetas WHERE  Upper(Replace(Nombre,' ','')) = '" & Nombre & "' "

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

    Public Function EtiquetaEditada(ByVal iidEtiqueta As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT EtiquetaEditada FROM Etiquetas WHERE idEtiqueta = " & iidEtiqueta

            cmd = New SqlCommand(sel, con)
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

    Public Function CambiarActiva(ByVal iidEtiqueta As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Etiquetas set Activo = case when Activo = 1 then 0 else 1 end, idModifica = @idModifica, Modificacion = @Modificacion WHERE idEtiqueta = @idEtiqueta "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", iidEtiqueta)
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

    Public Function CambiaridCliente(ByVal iidEtiqueta As Integer, ByVal iidCliente As Integer) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Etiquetas set  idCliente = @idCliente, idModifica = @idModifica, Modificacion = @Modificacion WHERE idEtiqueta = @idEtiqueta "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", iidEtiqueta)
                cmd.Parameters.AddWithValue("idCliente", iidCliente)
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

    Public Function insertar(ByVal dts As DatosEtiqueta) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Etiquetas (Nombre, Fichero, EtiquetaEditada, Observaciones, Activo, idCliente, idCreador, Creacion ) "
            sel = sel & "values         (@Nombre,@Fichero,@EtiquetaEditada,@Observaciones,@Activo,@idCliente,@idCreador,@Creacion) select @@Identity"
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("Fichero", dts.gFichero)
                cmd.Parameters.AddWithValue("EtiquetaEditada", dts.gEtiquetaEditada)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
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
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function





    Public Function actualizar(ByVal dts As DatosEtiqueta) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Etiquetas set Nombre = @Nombre, Fichero = @Fichero , EtiquetaEditada = @EtiquetaEditada, Observaciones = @Observaciones, Activo = @Activo, idCliente = @idCliente, idModifica = @idModifica, Modificacion = @Modificacion WHERE idEtiqueta = " & dts.gidEtiqueta

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("Fichero", dts.gFichero)
                cmd.Parameters.AddWithValue("EtiquetaEditada", dts.gEtiquetaEditada)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
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


    Public Function borrar(ByVal iidEtiqueta As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Etiquetas where idEtiqueta = " & iidEtiqueta
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function





End Class



