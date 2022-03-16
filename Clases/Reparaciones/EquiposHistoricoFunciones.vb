Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesEquiposHistorico

    Inherits conexion
    Dim cmd As SqlCommand
    Private funcES As New FuncionesEstados


    Dim sel0 As String = " Select EQ.*, NombreComercial as Cliente, codCli,codArticulo, Articulo, Albaranes.Fecha as FechaAlbaran, Pedidos.Fecha as FechaPedido, Facturas,Fecha AS FechaFactura " _
    & " from EquiposHistorico as EQ  " _
    & " left Join Clientes as CL ON CL.idCliente = EQ.idCliente " _
    & " left join Articulos as AR ON AR.idArticulo =EQ.idArticulo " _
    & " left join Albaranes ON Albaranes.numAlbaran = EQ.numAlbaran " _
    & " left join Pedidos ON Pedidos.numPedido = EQ.numPedido" _
    & " left join Facturas ON Facturas.numFactura = EQ.numFactura"




    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEquipoHistorico)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE " & sBusqueda & If(sOrden.Length = 0, " Order By numserie DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEquipoHistorico)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipoHistorico") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("sOrden", sOrden)

            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function buscaPrimerDia(ByVal iidCliente As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MIN(FechaSal) FROM EquiposHistorico where FechaSal <> '1-1-1900' "
            Else
                sel = "SELECT MIN(FechaSal) FROM EquiposHistorico where FechaSal <> '1-1-1900' AND idCliente = " & iidCliente
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                If Date.TryParse(o, fecha) Then
                    Return fecha
                Else
                    Return Nothing
                End If
            End If
        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try
    End Function




    Private Function CargarLinea(ByVal linea As DataRow) As DatosEquipoHistorico
        Dim dts As New DatosEquipoHistorico
        dts.gidEquipoHistorico = linea("idEquipoHistorico")

        dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, "", linea("numSerie"))
        dts.gModelo = If(linea("Modelo") Is DBNull.Value, "", linea("Modelo"))
        dts.gFechaFab = If(linea("FechaFab") Is DBNull.Value, CDate("1-1-1900"), linea("FechaFab"))
        dts.gNombreCliente = If(linea("NombreCliente") Is DBNull.Value, "", linea("NombreCliente"))
        dts.gFechaSal = If(linea("FechaSal") Is DBNull.Value, CDate("1-1-1900"), linea("FechaSal"))
        dts.gBomba = If(linea("Bomba") Is DBNull.Value, "", linea("Bomba"))
        dts.gNAlbaran = If(linea("NAlbaran") Is DBNull.Value, "", linea("NAlbaran"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))

        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))

        'Datos de otras tablas
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))

        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))

        dts.gFechaPedido = If(linea("FechaPedido") Is DBNull.Value, Now.Date, linea("FechaPedido"))
        dts.gFechaAlbaran = If(linea("FechaAlbaran") Is DBNull.Value, Now.Date, linea("FechaAlbaran"))
        dts.gFechaFactura = If(linea("FechaFactura") Is DBNull.Value, Now.Date, linea("FechaFactura"))
        Return dts

    End Function








    Public Function Mostrar1(ByVal iidEquipoHistorico As Long) As DatosEquipoHistorico
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select " & sel0 & " WHERE EP.idEquipoHistorico = " & iidEquipoHistorico
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEquipoHistorico
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idEquipoHistorico") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("iidEquipoHistorico", iidEquipoHistorico)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function Mostrar1Produccion(ByVal iidEquipoHistorico As Long) As DatosEquipoProduccion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select 0 as idEquipo, 0 as idProduccion, EP.*, idEscandallo, FechaFab as FechaInicio, FechaFab as FechaFin, 0 as idPErsona, 0 as idEstadoElectronica, 0 as idEstado,"
            sel = sel & " 0 as idCreador, Null as Creacion,0 as idModifica, Null as Modificacion, 0 as idEtiqueta, 0 as idConceptoAlbaran, 0 as idEstadoTaller, "
            sel = sel & " EP.idArticulo as idArticuloCEP, '' as Etiqueta, EP.FechaSal as FechaPrevista,0 as Prioridad, 0 as idConceptoPedido, "
            sel = sel & " FechaSal as FechaEntrega, AR.codArticulo, AR.Articulo, '' as EstadoTaller,  AR.idTipoArticulo, AR.idsubTipoArticulo, TipoArticulo, subTipoArticulo, "
            sel = sel & " '' as EstadoElectronica, '' as Estado,  PE.fecha as FechaPedido, EP.fechafab as FechaProduccion, Clientes.codCli, "
            sel = sel & " Clientes.NombreComercial as Cliente, Albaranes.Fecha as FechaAlbaran, Facturas.Fecha as FechaFactura,  case when EP.numAlbaran is null then NAlbaran else EP.numAlbaran end as numAlbaran, "
            sel = sel & " CL.idCliente as idClienteAlb, CL.codCli as codCliAlb, CL.NombreComercial as ClienteAlb, AR.conNumSerie,AR.conNumSerie2, "
            sel = sel & " Agrupacion "
            sel = sel & " FROM EquiposHistorico as EP "
            sel = sel & " Left Join Articulos as AR ON AR.idArticulo = EP.idArticulo  "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo  "
            sel = sel & " left join subTiposArticulo ON SubTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo  "
            sel = sel & " left join AgrupacionesArticulo as AA ON AA.idAgrupacion = SubTiposArticulo.idAgrupacion "
            sel = sel & " left join Escandallos ON Escandallos.idArticulo = EP.idArticulo "
            sel = sel & " left join Clientes ON Clientes.idCliente = EP.idCliente "
            sel = sel & " left outer join Albaranes ON Albaranes.numAlbaran = EP.numAlbaran  "
            sel = sel & " left outer join Facturas ON Facturas.numFactura = EP.numFactura "
            sel = sel & " left outer join Pedidos as PE ON PE.numPEdido = EP.numPEdido"
            sel = sel & " left outer join Clientes as CL ON CL.idCliente = Albaranes.idCliente  "

            sel = sel & " WHERE EP.idEquipoHistorico = " & iidEquipoHistorico
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEquipoProduccion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idEquipoHistorico") Is DBNull.Value Then
                    Else
                        dts.gidEquipoHistorico = linea("idEquipoHistorico")
                        dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))
                        dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, "", linea("numSerie"))
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
                        dts.gFechaInicio = If(linea("FechaInicio") Is DBNull.Value, Now.Date, linea("FechaInicio"))
                        Dim FechaFab As Date = If(linea("FechaFab") Is DBNull.Value, Now.Date, linea("FechaFab"))
                        dts.gFechaFin = If(linea("FechaFin") Is DBNull.Value, FechaFab, linea("FechaFin"))
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
                        dts.gidEstadoTaller = If(linea("idEstadoTaller") Is DBNull.Value, 0, linea("idEstadoTaller"))
                        dts.gidEstadoElectronica = If(linea("idEstadoElectronica") Is DBNull.Value, 0, linea("idEstadoElectronica"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.gidEtiqueta = If(linea("idEtiqueta") Is DBNull.Value, 0, linea("idEtiqueta"))
                        dts.gidConceptoAlbaran = If(linea("idConceptoAlbaran") Is DBNull.Value, 0, linea("idConceptoAlbaran"))
                        dts.gCreacion = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion"))

                        'Datos de otras tablas
                        If dts.gidArticulo = 0 Then
                            dts.gcodArticulo = ""
                            dts.gArticulo = If(linea("Modelo") Is DBNull.Value, "", linea("Modelo"))
                        Else
                            dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                            dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        End If

                        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
                        dts.gEstadoTaller = If(linea("EstadoTaller") Is DBNull.Value, "", linea("EstadoTaller"))
                        dts.gEstadoElectronica = If(linea("EstadoElectronica") Is DBNull.Value, "", linea("EstadoElectronica"))
                        dts.gPrioridad = If(linea("Prioridad") Is DBNull.Value, 3, linea("Prioridad"))
                        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
                        dts.gidCliente = If(linea("idClienteAlb") Is DBNull.Value, 0, linea("idClienteAlb"))
                        If dts.gidCliente = 0 Then 'Tomamos el cliente del albarán si existe, sino lo cogemos del pedido
                            dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                            dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                            dts.gCliente = If(linea("NombreCliente") Is DBNull.Value, "", linea("NombreCliente"))
                        Else
                            dts.gcodCli = If(linea("codCliAlb") Is DBNull.Value, "", linea("codCliAlb"))
                            dts.gCliente = If(linea("ClienteAlb") Is DBNull.Value, "", linea("ClienteAlb"))
                        End If

                        dts.gEtiqueta = If(linea("Etiqueta") Is DBNull.Value, "", linea("Etiqueta"))
                        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, "", linea("numAlbaran"))
                        If dts.gnumAlbaran = "" Or dts.gnumAlbaran = "0" Then dts.gnumAlbaran = If(linea("nAlbaran") Is DBNull.Value, "", linea("nAlbaran"))
                        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
                        Dim FechaSal As Date = If(linea("FechaSal") Is DBNull.Value, FechaFab, linea("FechaSal")) 'Si no tenemos albarán, ponemos la FechaSal
                        dts.gFechaAlbaran = If(linea("FechaAlbaran") Is DBNull.Value, FechaSal, linea("FechaAlbaran"))
                        If dts.gFechaFin = CDate("1-1-1900") Then dts.gFechaFin = dts.gFechaAlbaran
                        dts.gFechaFactura = If(linea("FechaFactura") Is DBNull.Value, Now.Date, linea("FechaFactura"))
                        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
                        dts.gidsubTipoArticulo = If(linea("idsubTipoArticulo") Is DBNull.Value, 0, linea("idsubTipoArticulo"))
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
                        dts.gidConceptoPedido = If(linea("idConceptoPedido") Is DBNull.Value, 0, linea("idConceptoPedido"))
                        If dts.gnumPedido = 0 Then 'Si la fabricación procede de un pedido, manda la fecha del pedido
                            dts.gFechaPrevista = If(linea("FechaPrevista") Is DBNull.Value, Now.Date, linea("FechaPrevista"))
                            dts.gFechaPedido = If(linea("FechaProduccion") Is DBNull.Value, Now.Date, linea("FechaProduccion").date)
                        Else
                            dts.gFechaPrevista = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))
                            dts.gFechaPedido = If(linea("FechaPedido") Is DBNull.Value, Now.Date, linea("FechaPedido"))
                        End If
                        dts.gCantidad = 1
                        dts.gconNumSerie = If(linea("conNumSerie") Is DBNull.Value, False, linea("conNumSerie"))
                        dts.gconNumSerie2 = If(linea("conNumSerie2") Is DBNull.Value, False, linea("conNumSerie2"))
                        dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
                        dts.gidEquipo = If(linea("idEquipo") Is DBNull.Value, 0, linea("idEquipo"))
                        Dim Bomba As String = If(linea("Bomba") Is DBNull.Value, "", linea("Bomba"))
                        If Bomba <> "" Then
                            dts.gObservaciones = dts.gObservaciones & vbCrLf & "BOMBA: " & Bomba
                        End If

                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("iidEquipoHistorico", iidEquipoHistorico)
            CorreoError(ex)
            Return Nothing
        End Try


    End Function


    Public Function idEquipoHistorico(ByVal numSerie As String) As Long
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            numSerie = Trim(numSerie)
            sel = " select idEquipoHistorico from EquiposHistorico  where numSerie = '" & numSerie & "' "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CLng(o)
            End If
        Catch ex As Exception
            ex.Data.Add("numSerie", numSerie)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function





    Public Function insertar(ByVal dts As DatosEquipoHistorico) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into EquiposHistorico ( numSerie,Modelo,FechaFab, NombreCliente, FechaSal, Bomba, NAlbaran, Transporte, Observaciones, idArticulo, idCliente, numPedido, numAlbaran, numFactura)"
        sel = sel & " values (              @numSerie,@Modelo,@FechaFab,@NombreCliente,@FechaSal,@Bomba,@NAlbaran,@Transporte,@Observaciones,@idArticulo,@idCliente,@numPedido,@numAlbaran,@numFactura) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("Modelo", dts.gModelo)
                cmd.Parameters.AddWithValue("FechaFab", dts.gFechaFab)
                cmd.Parameters.AddWithValue("NombreCliente", dts.gNombreCliente)
                cmd.Parameters.AddWithValue("FechaSal", dts.gFechaSal)
                cmd.Parameters.AddWithValue("Bomba", dts.gBomba)
                cmd.Parameters.AddWithValue("NAlbaran", dts.gNAlbaran)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                CorreoError(ex)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosEquipoHistorico) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update EquiposHistorico set  numSerie = @numSerie, Modelo = @Modelo, FechaFab = @FechaFab, Cliente = @Cliente, FechaSal = @FechaSal, Bomba = @Bomba,   "
        sel = sel & " NAlbaran = @NAlbaran, Transporte = @Transporte, Observaciones = @Observaciones, idArticulo = @idArticulo, idCliente = @idCliente, numPedido = @numPedido, numAlbaran = @numAlbaran, numFactura = @numFactura  "
        sel = sel & " WHERE idEquipoHistorico = @idEquipoHistorico"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipoHistorico", dts.gidEquipoHistorico)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("Modelo", dts.gModelo)
                cmd.Parameters.AddWithValue("FechaFab", dts.gFechaFab)
                cmd.Parameters.AddWithValue("Cliente", dts.gCliente)
                cmd.Parameters.AddWithValue("FechaSal", dts.gFechaSal)
                cmd.Parameters.AddWithValue("Bomba", dts.gBomba)
                cmd.Parameters.AddWithValue("NAlbaran", dts.gNAlbaran)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function




    Public Function borrar(ByVal iidEquipoHistorico As Long) As Boolean  ' Borra una cabecera de AlbaranProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from EquiposHistorico where idEquipoHistorico = " & iidEquipoHistorico
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
                ex.Data.Add("iidEquipoHistorico", iidEquipoHistorico)
                CorreoError(ex)
                Return 0

            End Try
        End Using

    End Function





End Class
