Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosPedidosInternos

    Inherits conexion
    Dim cmd As SqlCommand

    Dim sel0 As String = "select CP.*, TipoUnidad, Familia, SubFamilia, AR.idUnidad, TipoUnidad, Nombre + ' ' + Apellidos as Creador, Estado " _
            & " from ConceptosPedidosInternos AS CP " _
            & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
            & " left join Familias ON Familias.idFamilia = AR.idFamilia " _
            & " left outer JOIN SubFamilias ON SubFamilias.idSubFamilia = AR.idSubFamilia " _
            & " left join Personal On Personal.idPErsona = CP.idCreador" _
            & " left join Contactos ON Contactos.idContacto = Personal.idContacto " _
            & " left join Estados ON Estados.idEstado = CP.idEstado"





    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoPedidoInterno)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By idConcepto DESC ", " Order By " & sOrden)

            Dim lista As New List(Of DatosConceptoPedidoInterno)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoPedidoInterno
        Dim dts As New DatosConceptoPedidoInterno
        dts.gidConcepto = linea("idConcepto")
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidConceptoPedidoProv = If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
        dts.gidCreador = If(linea("idCreador") Is DBNull.Value, 0, linea("idCreador"))
        dts.gCreacion = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion"))

        dts.gCreador = If(linea("Creador") Is DBNull.Value, "", linea("Creador"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gsubFamilia = If(linea("SubFamilia") Is DBNull.Value, "", linea("SubFamilia"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        Return dts
    End Function

    Public Function mostrar1(ByVal iidConcepto As Integer) As DatosConceptoPedidoInterno
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CP.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoPedidoInterno
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
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



    Public Function insertar(ByRef dts As DatosConceptoPedidoInterno) As Integer 'me devuelve el idConcepto generado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Dim resultado As Integer
        sel = "insert into ConceptosPedidosInternos (idArticulo,Articulo, codArticulo, Cantidad, Observaciones,idEstado, idConceptoPedidoProv, idCreador, Creacion, idrazonsocial) "
        sel = sel & "values ( @idArticulo, @Articulo, @codArticulo, @Cantidad, @Observaciones,@idEstado, @idConceptoPedidoProv, @idCreador, @Creacion, (select idrazonsocial from razonsocial where activa= 1)) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Articulo", dts.gArticulo)
                cmd.Parameters.AddWithValue("codArticulo", dts.gcodArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                dts.gCreacion = Now
                cmd.Parameters.AddWithValue("Creacion", dts.gCreacion)
                con.Open()
                resultado = cmd.ExecuteScalar()
                con.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosConceptoPedidoInterno) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosInternos set idArticulo = @idArticulo,Articulo = @Articulo,codArticulo = @codArticulo, Cantidad = @Cantidad,  "
        sel = sel & "   Observaciones = @Observaciones,  idModifica = @idModifica, Modificacion = @Modificacion where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Articulo", dts.gArticulo)
                cmd.Parameters.AddWithValue("codArticulo", dts.gcodArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                'cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                'cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
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


    Public Function CampoidEstado(ByVal iidConcepto As Long) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idEstado from ConceptosPedidosInternos where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                Dim o As Object
                con.Open()
                o = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function CampoidArticulo(ByVal iidConcepto As Long) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idArticulo from ConceptosPedidosInternos where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                Dim o As Object
                con.Open()
                o = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            End Try

        End Using
    End Function

    Public Function ExisteidConceptoPedidoProv(ByVal iidConceptoPedidoProv As Long) As Long
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idConcepto from ConceptosPedidosInternos where idConceptoPedidoProv = " & iidConceptoPedidoProv
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                Dim o As Object
                con.Open()
                o = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CLng(o)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            End Try

        End Using
    End Function


    Public Function actualizarEstado(ByVal iidConcepto As Long, ByVal iidEstado As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosInternos set  idEstado = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
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

    Public Function actualizaidConceptoPedidoProv(ByVal iidConcepto As Long, ByVal iidConceptoPedidoProv As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosInternos set  idConceptoPedidoProv = @idConceptoPedidoProv, idModifica = @idModifica, Modificacion = @Modificacion where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", iidConceptoPedidoProv)
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



    Public Function borrar(ByVal iidConcepto As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ConceptosPedidosInternos where idConcepto = " & iidConcepto

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

  
End Class
