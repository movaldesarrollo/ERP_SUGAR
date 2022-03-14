Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesMovimientosEquiposAcabados


    Inherits conexion
    Dim cmd As SqlCommand
    Private funcES As New FuncionesEstados


    Dim sel0 As String = " select * from MovimientosEquiposAcabados "

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosMovimientoEquiposAcabados)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By idArticulo ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosMovimientoEquiposAcabados)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idMovimiento") Is DBNull.Value Then
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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosMovimientoEquiposAcabados
        Dim dts As New DatosMovimientoEquiposAcabados
        dts.gidMovimiento = linea("idMovimiento")
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        'dts.gTraspasado = If(linea("Traspasado") Is DBNull.Value, False, linea("Traspasado"))
        dts.gidFinalizador = If(linea("idFinalizador") Is DBNull.Value, 0, linea("idFinalizador"))

        'Datos de otras tablas
        dts.gFinalizador = If(linea("Finalizador") Is DBNull.Value, 0, linea("Finalizador"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        Return dts
    End Function





    Public Function Mostrar(ByVal iidArticulo As Integer, ByVal soloNoTraspasados As Boolean) As List(Of DatosMovimientoEquiposAcabados)
        'Equipos de una o varias secciones
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE EP.idArticulo = " & iidArticulo
            sel = sel & If(soloNoTraspasados, " AND Traspasado = 0 ", "")
            sel = sel & " Order By Articulo "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosMovimientoEquiposAcabados)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

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


    Public Function Estadistica(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEstadisticaProduccion)
        'Estadística de producción
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select count(idConcepto) as Cantidad,CE.idFinalizador as idPersona,CE.idArticulo, AR.codArticulo,TU.TipoUnidad, AR.Articulo, Nombre + ' ' + Apellidos as Persona "
            sel = sel & " from MovimientosEquiposAcabados as CE "
            sel = sel & " left join Articulos as AR on AR.idArticulo = CE.idArticulo"
            sel = sel & " left join TiposUnidad as TU ON TU.idTipoUnidad = AR.idUnidad"
            sel = sel & " left join EquiposProduccion as EQ ON EQ.idEquipo = CE.idEquipo"

            sel = sel & " left join Personal ON Personal.idPersona = CE.idFinalizador"
            sel = sel & " left join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
            sel = sel & " group by CE.idFinalizador,CE.idArticulo,AR.Articulo,AR.codArticulo,TU.TipoUnidad,Nombre,Apellidos"
            sel = sel & If(sOrden.Length = 0, " Order By Persona ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEstadisticaProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosEstadisticaProduccion
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idPersona") Is DBNull.Value Then
                    Else
                        dts = New DatosEstadisticaProduccion
                        dts.gidPersona = linea("idPersona")
                        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))

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



    Public Function CantidadAcabado(ByVal iidArticulo As Integer) As Double
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select sum(Cantidad) from MovimientosEquiposAcabados where  idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CDbl(o)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using
    End Function



    Public Function insertar(ByVal dts As DatosMovimientoEquiposAcabados) As Integer 'Inserta una nueva Pedido y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into MovimientosEquiposAcabados (idArticulo, Cantidad, idFinalizador,Finalizacion) "
        sel = sel & " values ( @idArticulo,@Cantidad, @idFinalizador, @Finalizacion) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                ' cmd.Parameters.AddWithValue("Traspasado", dts.gTraspasado)
                cmd.Parameters.AddWithValue("idFinalizador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Finalizacion", Now)


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


    Public Function borrarArticulo(ByVal iidArticulo As Long) As Boolean  ' Borra un equipo


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from MovimientosEquiposAcabados where idArticulo = " & iidArticulo
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

    Public Function borrar(ByVal iidMovimiento As Long) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from MovimientosEquiposAcabados where idMovimiento = " & iidMovimiento
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
