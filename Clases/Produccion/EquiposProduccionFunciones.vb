Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesEquiposProduccion

    Inherits conexion
    Dim cmd As SqlCommand
    Private funcES As New FuncionesEstados
    Dim sconexion As String = CadenaConexion()
    Dim funcCR As FuncionesConceptosProduccion


    Dim sel0 As String = "  case when isnumeric(numserie + '.e0')=1 then cast(numSerie as int) else 0 end as numSerieNumerico, EP.*,cast(EP.fechafin as date)as Fechafin_date, EP.idArticulo as idArticuloCEP, Etiquetas.nombre as Etiqueta, C1.numPedido, CP.FechaPrevista, CP.Prioridad,CP.idConceptoPedido, case when PE.FechaEntrega is null then cast(EP.fechafin as date) else PE.FechaEntrega end as FechaEntrega,case when AR.codArticulo is null then EP.modelo_old else AR.codArticulo end as codArticulo,case when AR.Articulo is null then EP.modelo_old else AR.Articulo end as Articulo , esTA.Estado as EstadoTaller, " _
             & " AR.idTipoArticulo, AR.idsubTipoArticulo,AR.ConVersiones, TipoArticulo, subTipoArticulo, esEL.Estado as EstadoElectronica, Estados.Estado as Estado, PE.idCliente,case when PE.numPedido is null then FechaInicio else PE.fecha end as FechaPedido, CP.Creacion as FechaProduccion, Clientes.codCli, Clientes.NombreComercial as Cliente, Albaranes.FechaEntrega as FechaAlbaran, Facturas.Fecha as FechaFactura, " _
             & " Facturas.numFactura, cast(Albaranes.numAlbaran as nvarchar(50)) as numAlbaran, CL.idCliente as idClienteAlb, CL.codCli as codCliAlb, CL.NombreComercial as ClienteAlb, AR.conNumSerie,AR.conNumSerie2,EP.Observaciones, " _
             & " esTA.Anulado as esTAanulado, esTA.EnCurso as esTAEnCurso, esTA.Espera as esTAEspera, esTA.Completo as esTACompleto, esEL.Anulado as esELanulado, esEL.EnCurso as esELEnCurso, esEL.Espera as esELEspera,  esEL.Completo as esELCompleto, CP.Cantidad, " _
             & " esTA.idEstado as idEsTA, esEL.idEstado as idEsEL, CP.Observaciones as ObservacionesCP, Agrupacion, 0 as idEquipoHistorico, " _
             & " case when EP.idestado is null then 'SIN ESTADO' else (case when (select Entregado from Estados where idEstado = C1.idEstado) = 1 then 'SERVIDO'" _
             & " when Estados.Completo = 1 then 'PRODUCIDO' " _
             & " when Estados.Encurso = 1 or Estados.Espera = 1 then 'PRODUCCIÓN' " _
             & " else Estados.Estado end)end as EstadoBusqueda, EP.VersionEscandallo as VersionEscandalloCEP " _
             & " FROM EquiposProduccion as EP Left Join Articulos as AR ON AR.idArticulo = EP.idArticulo " _
             & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
             & " left join subTiposArticulo ON SubTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
             & " left join AgrupacionesArticulo as AA ON AA.idAgrupacion = SubTiposArticulo.idAgrupacion " _
             & " left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion " _
             & " Left join Estados ON Estados.idEstado = EP.idEstado " _
             & " Left join Estados as esTA ON esTA.idEstado = EP.idEstadoTaller " _
             & " Left join Estados as esEL ON esEL.idEstado = EP.idEstadoElectronica " _
             & " left join Escandallos ON Escandallos.idEscandallo = EP.idEscandallo " _
             & " left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido " _
             & " left join Estados as E1 ON E1.idEstado = C1.idEstado " _
             & " left join Pedidos as PE ON PE.numPedido = C1.numPedido " _
             & " left join Estados as EPE ON EPE.idEstado = PE.idEstado " _
             & " left join Clientes ON Clientes.idCliente = PE.idCliente" _
             & " left join Etiquetas ON Etiquetas.idEtiqueta = EP.idEtiqueta" _
             & " left outer join ConceptosAlbaranes AS CA ON CA.idConcepto = EP.idConceptoAlbaran" _
             & " left outer join Albaranes ON Albaranes.numAlbaran = CA.numAlbaran " _
             & " left outer join Facturas ON Facturas.numFactura = CA.numFactura" _
             & " left outer join Clientes as CL ON CL.idCliente = Albaranes.idCliente "

    'Búsqueda que presente los componenentes separados
    Dim sel1 As String = "  EP.*, CEP.idArticulo as idArticuloCEP, Etiquetas.nombre as Etiqueta, C1.numPedido, CP.FechaPrevista, CP.Prioridad,CP.idConceptoPedido, PE.FechaEntrega, AR.codArticulo, AR.Articulo, esTA.Estado as EstadoTaller, " _
         & " AR.idTipoArticulo, AR.idsubTipoArticulo,AR.conVersiones, TipoArticulo, subTipoArticulo, esEL.Estado as EstadoElectronica, Estados.Estado as Estado, PE.idCliente, case when PE.numPedido is null then FechaInicio else PE.fecha end as FechaPedido, CP.Creacion as FechaProduccion, Clientes.codCli, Clientes.NombreComercial as Cliente, Albaranes.Fecha as FechaAlbaran, Facturas.Fecha as FechaFactura, " _
         & " Facturas.numFactura, cast(Albaranes.numAlbaran as nvarchar(50)) as numAlbaran, CL.idCliente as idClienteAlb, CL.codCli as codCliAlb, CL.NombreComercial as ClienteAlb, AR.conNumSerie,AR.conNumSerie2,EP.Observaciones, " _
         & " esTA.Anulado as esTAanulado, esTA.EnCurso as esTAEnCurso, esTA.Espera as esTAEspera, esTA.Completo as esTACompleto, esEL.Anulado as esELanulado, esEL.EnCurso as esELEnCurso, esEL.Espera as esELEspera,  esEL.Completo as esELCompleto, CP.Cantidad, " _
         & " esTA.idEstado as idEsTA, esEL.idEstado as idEsEL, CP.Observaciones as ObservacionesCP, Agrupacion, 0 as idEquipoHistorico, " _
         & " case when (select Entregado from Estados where idEstado = C1.idEstado) = 1 then 'SERVIDO'" _
         & " when Estados.Completo = 1 then 'PRODUCIDO' " _
         & " when Estados.Encurso = 1 or Estados.Espera = 1 then 'PRODUCCIÓN' " _
         & " else Estados.Estado end as EstadoBusqueda, CEP.VersionEscandallo as VersionEscandalloCEP " _
         & " FROM ConceptosEquiposProduccion as CEP Left Join Articulos as AR ON AR.idArticulo = CEP.idArticulo " _
         & " left join EquiposProduccion as EP ON EP.idEquipo = CEP.idEquipo " _
         & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
         & " left join subTiposArticulo ON SubTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
         & " left join AgrupacionesArticulo as AA ON AA.idAgrupacion = SubTiposArticulo.idAgrupacion " _
         & " left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion " _
         & " Left join Estados ON Estados.idEstado = EP.idEstado " _
         & " Left join Estados as esTA ON esTA.idEstado = CEP.idEstadoTaller " _
         & " Left join Estados as esEL ON esEL.idEstado = CEP.idEstadoElectronica " _
         & " left join Escandallos ON Escandallos.idEscandallo = EP.idEscandallo " _
         & " left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido " _
         & " left join Estados as E1 ON E1.idEstado = C1.idEstado " _
         & " left join Pedidos as PE ON PE.numPedido = C1.numPedido " _
         & " left join Estados as EPE ON EPE.idEstado = PE.idEstado " _
         & " left join Clientes ON Clientes.idCliente = PE.idCliente" _
         & " left join Etiquetas ON Etiquetas.idEtiqueta = EP.idEtiqueta" _
         & " left outer join ConceptosAlbaranes AS CA ON CA.idConcepto = EP.idConceptoAlbaran" _
         & " left outer join Albaranes ON Albaranes.numAlbaran = CA.numAlbaran " _
         & " left outer join Facturas ON Facturas.numFactura = CA.numFactura" _
         & " left outer join Clientes as CL ON CL.idCliente = Albaranes.idCliente "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal Max As Integer) As List(Of DatosEquipoProduccion)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = If(Max = 0, "Select ", "Select Top " & Max) & sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numserie DESC, idEquipo DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEquipoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
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
            ex.Data.Add("Max", Max)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function BusquedaLista(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of Long)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select EP.idEquipo " _
             & " FROM EquiposProduccion as EP Left Join Articulos as AR ON AR.idArticulo = EP.idArticulo " _
             & " left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion " _
             & " Left join Estados ON Estados.idEstado = EP.idEstado " _
             & " Left join Estados as esTA ON esTA.idEstado = EP.idEstadoTaller " _
             & " Left join Estados as esEL ON esEL.idEstado = EP.idEstadoElectronica " _
             & " left join Escandallos ON Escandallos.idEscandallo = EP.idEscandallo " _
             & " left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido " _
             & " left join Estados as E1 ON E1.idEstado = C1.idEstado " _
             & " left join Pedidos as PE ON PE.numPedido = C1.numPedido " _
             & " left join Estados as EPE ON EPE.idEstado = PE.idEstado "

            sel = sel & " WHERE " & sBusqueda & If(sOrden.Length = 0, " Order By numserie DESC, idEquipo DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Long)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                'Dim dts As DatosEquipoProduccion
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idEquipo"))
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosEquipoProduccion
        Try
            Dim dts As New DatosEquipoProduccion
            dts.gidEquipo = linea("idEquipo")
            dts.gcliente_old = If(linea("Cliente_old") Is DBNull.Value, 0, linea("Cliente_old"))
            dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))
            dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, "", linea("numSerie"))
            dts.gidArticulo = If(linea("idArticuloCEP") Is DBNull.Value, 0, linea("idArticuloCEP"))
            dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
            dts.gFechaInicio = If(linea("FechaInicio") Is DBNull.Value, Now.Date, linea("FechaInicio"))
            dts.gFechaFin = If(linea("FechaFin") Is DBNull.Value, Now.Date, linea("FechaFin"))
            dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
            dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
            dts.gidEstadoTaller = If(linea("idEstadoTaller") Is DBNull.Value, 0, linea("idEstadoTaller"))
            dts.gidEstadoElectronica = If(linea("idEstadoElectronica") Is DBNull.Value, 0, linea("idEstadoElectronica"))
            dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
            If dts.gObservaciones = "" Then dts.gObservaciones = If(linea("ObservacionesCP") Is DBNull.Value, "", linea("ObservacionesCP"))
            dts.gidEtiqueta = If(linea("idEtiqueta") Is DBNull.Value, 0, linea("idEtiqueta"))
            dts.gidConceptoAlbaran = If(linea("idConceptoAlbaran") Is DBNull.Value, 0, linea("idConceptoAlbaran"))
            dts.gCreacion = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion"))
            dts.gVersion = If(linea("VersionEscandalloCEP") Is DBNull.Value, 0, linea("VersionEscandalloCEP"))
            dts.gAsignado = If(linea("Asignado") Is DBNull.Value, False, linea("Asignado"))
            dts.gfechaentrega = If(linea("FechaEntrega") Is DBNull.Value, CDate("1-1-1900"), linea("FechaEntrega"))
            'Datos de otras tablas
            dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
            dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
            dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
            dts.gEstadoTaller = If(linea("EstadoTaller") Is DBNull.Value, "", linea("EstadoTaller"))
            dts.gEstadoElectronica = If(linea("EstadoElectronica") Is DBNull.Value, "", linea("EstadoElectronica"))
            dts.gPrioridad = If(linea("Prioridad") Is DBNull.Value, 3, linea("Prioridad"))
            dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
            dts.gidCliente = If(linea("idClienteAlb") Is DBNull.Value, 0, linea("idClienteAlb"))
            If dts.gidCliente = 0 Then 'Tomamos el cliente del albarán si existe, sino lo cogemos del pedido
                dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
            Else
                '----------
                dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                '----------
                dts.gcodCli = If(linea("codCliAlb") Is DBNull.Value, "", linea("codCliAlb"))
                dts.gCliente = If(linea("ClienteAlb") Is DBNull.Value, "", linea("ClienteAlb"))
            End If
            dts.gEtiqueta = If(linea("Etiqueta") Is DBNull.Value, "", linea("Etiqueta"))
            dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
            dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
            dts.gFechaAlbaran = If(linea("FechaAlbaran") Is DBNull.Value, Now.Date, linea("FechaAlbaran"))
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
            dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
            dts.gconNumSerie = If(linea("conNumSerie") Is DBNull.Value, False, linea("conNumSerie"))
            dts.gconNumSerie2 = If(linea("conNumSerie2") Is DBNull.Value, False, linea("conNumSerie2"))
            dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
            dts.gidEquipoHistorico = If(linea("idEquipoHistorico") Is DBNull.Value, 0, linea("idEquipoHistorico"))
            dts.gEstadoBusqueda = If(linea("EstadoBusqueda") Is DBNull.Value, "", linea("EstadoBusqueda"))
            dts.gConVersiones = If(linea("ConVersiones") Is DBNull.Value, False, linea("ConVersiones"))
            If Not dts.gConVersiones Then
                dts.gVersion = 0
            End If
            Return dts
        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function BusquedaConHistorico(ByVal sBusqueda As String, ByVal sBusquedaH As String, ByVal sOrden As String) As List(Of DatosEquipoProduccion)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim vinicioEquipos As String = ""
            Dim sel As String

            sel = "Select " & sel0 & If(sBusqueda.Length = 0, "WHERE numSerie > 0", " WHERE " & sBusqueda)
            sel = sel & " order by " & sOrden
            sOrden = ""

            '-------------------------ELIMINADO LUIS------------------------------------
            'sel = sel & " UNION ALL "
            'sel = sel & " select case when isnumeric(numserie + '.e0')=1 then cast(numSerie as int) else 0 end as numSerieNumerico,0 as idEquipo, 0 as idProduccion, EP.numSerie, EP.idArticulo, idEscandallo, FechaFab as FechaInicio, FechaFab as FechaFin, 0 as idPErsona, 0 as idEstadoElectronica, 0 as idEstado,"
            'sel = sel & " EP.Observaciones,0 as idCreador, Null as Creacion,0 as idModifica, Null as Modificacion, 0 as idEtiqueta, 0 as idConceptoAlbaran, 0 as idEstadoTaller, "
            'sel = sel & " case when year(EP.FechaFab)=1900 then year(EP.FechaSal) else year(EP.FechaFab) end as VersionEscandallo,1, "
            'sel = sel & " EP.idArticulo as idArticuloCEP, '' as Etiqueta, EP.numPedido, EP.FechaSal as FechaPrevista,0 as Prioridad, 0 as idConceptoPedido, "
            'sel = sel & " FechaSal as FechaEntrega,case when EP.idArticulo = 0 then EP.Modelo else AR.codArticulo end as codArticulo,case when EP.idArticulo = 0 then EP.Modelo else AR.Articulo end as Articulo, '' as EstadoTaller,  AR.idTipoArticulo, AR.idsubTipoArticulo,AR.conVersiones, TipoArticulo, subTipoArticulo, "
            'sel = sel & " '' as EstadoElectronica, '' as Estado, EP.idCliente, PE.fecha as FechaPedido, EP.fechafab as FechaProduccion, Clientes.codCli, "
            'sel = sel & " Clientes.NombreComercial as Cliente, Albaranes.Fecha as FechaAlbaran, Facturas.Fecha as FechaFactura,  EP.numFactura, case when EP.numAlbaran is null or EP.numAlbaran=0 then NAlbaran else  cast(EP.numAlbaran as nvarchar(50)) end as numAlbaran, "
            'sel = sel & " CL.idCliente as idClienteAlb, CL.codCli as codCliAlb, CL.NombreComercial as ClienteAlb, AR.conNumSerie,AR.conNumSerie2,'' as observaciones,  0 as esTAanulado, "
            'sel = sel & " 0 as esTAEnCurso, 0 as esTAEspera, 1 as esTACompleto, 0 as esELanulado, 0 as esELEnCurso, "
            'sel = sel & " 0 as esELEspera,  1 as esELCompleto, 0 as Cantidad,  0 as idEsTA, 0 as idEsEL, '' as ObservacionesCP, '' Agrupacion, EP.idEquipoHistorico, "
            'sel = sel & " case when NAlbaran is not null AND NAlbaran <>'' then 'SERVIDO' else 'PRODUCIDO'  end as EstadoBusqueda, "
            'sel = sel & "  case when year(EP.FechaFab)=1900 then year(EP.FechaSal) else year(EP.FechaFab) end as VersionEscandalloCEP "
            'sel = sel & " FROM EquiposHistorico as EP "
            'sel = sel & " Left Join Articulos as AR ON AR.idArticulo = EP.idArticulo  "
            'sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo  "
            'sel = sel & " left join subTiposArticulo ON SubTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo  "
            'sel = sel & " left join AgrupacionesArticulo as AA ON AA.idAgrupacion = SubTiposArticulo.idAgrupacion "
            'sel = sel & " left join Escandallos ON Escandallos.idArticulo = EP.idArticulo "
            'sel = sel & " left join Clientes ON Clientes.idCliente = EP.idCliente "
            'sel = sel & " left outer join Albaranes ON Albaranes.numAlbaran = EP.numAlbaran  "
            'sel = sel & " left outer join Facturas ON Facturas.numFactura = EP.numFactura "
            'sel = sel & " left outer join Pedidos as PE ON PE.numPEdido = EP.numPEdido"
            'sel = sel & " left outer join Clientes as CL ON CL.idCliente = Albaranes.idCliente  "
            'sel = sel & If(sBusquedaH.Length = 0, "", " WHERE " & sBusquedaH)
            'sel = sel & If(sOrden.Length = 0, " Order By numserie DESC, idEquipo DESC ", " Order By " & sOrden)
            '-------------------------ELIMINADO LUIS------------------------------------

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEquipoProduccion)
            Dim linea As DataRow

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
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
            ex.Data.Add("sBusquedaH", sBusquedaH)
            ex.Data.Add("sOrden", sOrden)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function




    Public Function ContadorPedidosBusqueda(ByVal sBusqueda As String, ByVal Max As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " count(numPedido) from ( select distinct PE.numPedido " _
                     & " FROM EquiposProduccion as EP Left Join Articulos as AR ON AR.idArticulo = EP.idArticulo " _
                     & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
                     & " left join subTiposArticulo ON SubTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
                     & " left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion " _
                     & " Left join Estados ON Estados.idEstado = EP.idEstado " _
                     & " Left join Estados as esTA ON esTA.idEstado = EP.idEstadoTaller " _
                     & " Left join Estados as esEL ON esEL.idEstado = EP.idEstadoElectronica " _
                     & " left join Escandallos ON Escandallos.idEscandallo = EP.idEscandallo " _
                     & " left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido " _
                     & " left join Estados as E1 ON E1.idEstado = C1.idEstado " _
                     & " left join Pedidos as PE ON PE.numPedido = C1.numPedido " _
                     & " left join Estados as EPE ON EPE.idEstado = PE.idEstado " _
                     & " left join Clientes ON Clientes.idCliente = PE.idCliente" _
                     & " left join Etiquetas ON Etiquetas.idEtiqueta = EP.idEtiqueta" _
                     & " left outer join ConceptosAlbaranes AS CA ON CA.idConcepto = EP.idConceptoAlbaran" _
                     & " left outer join Albaranes ON Albaranes.numAlbaran = CA.numAlbaran " _
                     & " left outer join Facturas ON Facturas.numFactura = CA.numFactura" _
                     & " left outer join Clientes as CL ON CL.idCliente = Albaranes.idCliente "

            sel = If(Max = 0, "Select ", "Select Top " & Max) & sel & If(sBusqueda.Length = 0, "", "  WHERE " & sBusqueda) & ")X "
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
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("Max", Max)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function MostrarProduccionSeparada(ByVal iidArticulo As Integer, ByVal Version As Integer) As List(Of DatosConceptoEquipoProduccion)
        'Muestra los componentes con Producción separada de un artículo
        Try

            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = " With DirectReports(idArticulo, codArticulo, Articulo, Level, ProduccionSeparada, Cantidad,idEscandallo,VersionEscandallo) AS ("
            ' Anchor member definition
            sel = sel & " SELECT CE.idArticulo,AR.codArticulo, AR.Articulo,0 AS Level,AR.ProduccionSeparada,CE.Cantidad,ESc.idEscandallo,ESc.VersionEscandallo"
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " LEFT JOIN Escandallos AS ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " left join Articulos as AR ON AR.idArticulo = CE.idArticulo "
            sel = sel & " LEFT JOIN Escandallos AS ESc ON ESc.idArticulo = AR.idArticulo  "
            sel = sel & " where ES.idArticulo = " & iidArticulo
            sel = sel & " UNION ALL "
            ' Recursive member definition
            sel = sel & " SELECT  CE.idArticulo, AR.codArticulo, AR.Articulo,Level + 1,AR.ProduccionSeparada, CE.Cantidad,ESc.idEscandallo,ESc.VersionEscandallo"
            sel = sel & " FROM ConceptosEscandallos AS CE "
            sel = sel & " inner JOIN Escandallos AS ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " inner join Articulos as AR ON AR.idArticulo = CE.idArticulo "
            sel = sel & " inner Join Escandallos as ESc ON ESc.idArticulo = AR.idArticulo "
            sel = sel & " INNER JOIN DirectReports AS d"
            'sel = sel & " ON ES.idArticulo = d.idArticulo where ES.idArticulo = " & iidArticulo & ")"
            sel = sel & " ON ES.idArticulo = d.idArticulo )" 'ERROR: Se agotó la recursividad máxima (100)
            ' Statement that executes the CTE
            sel = sel & " SELECT DISTINCT idArticulo, codArticulo, Articulo, Level, ProduccionSeparada, Cantidad, idEscandallo, VersionEscandallo"
            sel = sel & " FROM DirectReports "

            sel = sel & " where ProduccionSeparada = 1 "
            'sel = sel & "  AND ( VersionEscandallo is null or VersionEscandallo = 0 OR VersionEscandallo = " & Version & ")"
            sel = sel & " Order By idArticulo, VersionEscandallo ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoEquipoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoEquipoProduccion
                da.Fill(dt)
                Dim iidArticuloAnterior As Integer = 0
                Dim iidArticuloActual As Integer = 0
                Dim VersionAnterior As Integer = 0
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoEquipoProduccion
                        dts.gidConcepto = 0
                        dts.gidEquipo = 0
                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                        dts.gidEstadoTaller = 0
                        dts.gidEstadoElectronica = 0
                        dts.gidEstado = 0
                        dts.gidEtiqueta = 0
                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
                        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))

                        'Datos de otras tablas
                        dts.gObservaciones = ""
                        dts.gidProduccion = 0
                        dts.gnumSerie = ""
                        iidArticuloActual = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidArticulo = iidArticuloActual

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gEstado = ""
                        dts.gEstadoTaller = ""
                        dts.gEstadoElectronica = ""
                        dts.gEtiqueta = ""
                        'Tomamos todos los componentes de todas las versiones, pero sólo lo añadimos en la primera aparicición y después lo sustituimos por versiones más actuales hasta llegar (si existe) a la versión solicitada
                        If iidArticuloActual = iidArticuloAnterior Then
                            If dts.gVersion = Version Or (dts.gVersion < Version And dts.gVersion > VersionAnterior) Then
                                If lista.Count > 0 Then lista.RemoveAt(lista.Count - 1)
                                lista.Add(dts)
                            End If
                        Else
                            lista.Add(dts)
                        End If
                        iidArticuloAnterior = iidArticuloActual
                        VersionAnterior = dts.gVersion
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            ex.Data.Add("iidArticulo", iidArticulo)
            ex.Data.Add("Version", Version)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function MostrarProduccionSeparada0() As List(Of DatosConceptoProduccion)
        'Muestra los componentes con Producción separada de no completados
        Try

            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = " With DirectReports(idArticulo, codArticulo, Articulo, Level, ProduccionSeparada, Cantidad, FechaPrevista, idProduccion) AS ("
            ' Anchor member definition
            sel = sel & " SELECT CE.idArticulo,AR.codArticulo, AR.Articulo,0 AS Level,AR.ProduccionSeparada,CE.Cantidad, case when idConceptoPedido =0 or idConceptoPedido is null then FechaPrevista else FechaEntrega end, EQ.idProduccion "
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " LEFT JOIN Escandallos AS ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " left join Articulos as AR ON AR.idArticulo = CE.idArticulo "
            sel = sel & " left join EquiposProduccion as EQ ON EQ.idArticulo = ES.idArticulo left join Estados ON Estados.idEstado = EQ.idEstado "
            sel = sel & " left join ConceptosProduccion as CP ON CP.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CO ON CO.idConcepto = CP.idConceptoPedido"
            sel = sel & " left join Pedidos ON Pedidos.numPedido = CO.numPedido"
            sel = sel & " where  completo<>1 "
            sel = sel & " UNION ALL "
            ' Recursive member definition
            sel = sel & " SELECT CE.idArticulo, AR.codArticulo, AR.Articulo,Level + 1,AR.ProduccionSeparada, CE.Cantidad, FechaPrevista, idProduccion "
            sel = sel & " FROM ConceptosEscandallos AS CE "
            sel = sel & " inner JOIN Escandallos AS ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " inner join Articulos as AR ON AR.idArticulo = CE.idArticulo"
            sel = sel & " INNER JOIN DirectReports AS d"
            sel = sel & " ON ES.idArticulo = d.idArticulo )"
            ' Statement that executes the CTE
            sel = sel & " SELECT idArticulo, codArticulo, Articulo, sum(Cantidad) as Cantidad, FechaPrevista, idProduccion "
            sel = sel & " FROM DirectReports "

            sel = sel & " where ProduccionSeparada = 1  group by idArticulo, codArticulo, Articulo, FechaPrevista, idProduccion order by Articulo ASC "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoProduccion
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoProduccion
                        dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))

                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))

                        dts.gidEstado = 0
                        dts.gFechaPrevista = If(linea("FechaPrevista") Is DBNull.Value, Now.Date, linea("FechaPrevista"))

                        'Datos de otras tablas
                        dts.gObservaciones = ""


                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidEscandallo = 0
                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gEstado = ""

                        lista.Add(dts)

                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function MostrarProduccionSeparada(ByVal sBusqueda As String) As List(Of DatosConceptoProduccion)
        'Muestra los componentes con Producción separada de no completados
        Try

            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select sum(CE.Cantidad) as Cantidad, ARc.codArticulo, ARc.Articulo, EQ.idProduccion,ARc.idArticulo, TA.TipoArticulo, FA.Familia,"
            sel = sel & " case when idConceptoPedido = 0 or idConceptoPedido is null then FechaPrevista else FechaEntrega end as FechaPrevista "
            sel = sel & " from ConceptosEquiposProduccion as CE "
            sel = sel & " left join Articulos as ARc ON ARc.idArticulo = CE.idArticulo"
            sel = sel & " left join TiposArticulo as TA ON TA.idTipoArticulo = ARc.idTipoArticulo "
            sel = sel & " left join Familias as FA ON FA.idFamilia = ARc.idFamilia "
            sel = sel & " left join EquiposProduccion as EQ ON EQ.idEquipo = CE.idEquipo "
            sel = sel & " left join Articulos as AR ON AR.idArticulo = EQ.idArticulo"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstado"
            sel = sel & " left join ConceptosProduccion as CP ON CP.idProduccion = EQ.idProduccion "
            sel = sel & " left join ConceptosPedidos as CO ON CO.idConcepto = CP.idConceptoPedido "
            sel = sel & " left join Pedidos as PE ON PE.numPedido = CO.numPedido "
            sel = sel & " left join Clientes ON Clientes.idCliente = PE.idCliente "
            sel = sel & " where(Completo <> 1)" & If(sBusqueda = "", "", " AND " & sBusqueda)
            sel = sel & " group by TA.TipoArticulo,FA.Familia, ARc.idArticulo, ARc.codArticulo, ARc.Articulo, FechaPrevista, EQ.idProduccion, idConceptoPedido,PE.FechaEntrega order by ARc.Articulo ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoProduccion
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoProduccion
                        dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))

                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))

                        dts.gidEstado = 0
                        dts.gFechaPrevista = If(linea("FechaPrevista") Is DBNull.Value, Now.Date, linea("FechaPrevista"))

                        'Datos de otras tablas
                        dts.gObservaciones = ""

                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        If dts.gTipoArticulo = "" Then dts.gTipoArticulo = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))

                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidEscandallo = 0
                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gEstado = ""

                        lista.Add(dts)

                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar(ByVal Vista As String) As List(Of DatosEquipoProduccion)
        Return Mostrar(Vista, 0)
    End Function

    Public Function ListaidArticuloAgrupacion(ByVal listaClientes As List(Of ClienteSeleccion)) As List(Of IDComboBox3)
        Dim iidClientes As String = ""

        For Each iidcliente As ClienteSeleccion In listaClientes
            If iidcliente.gSeleccionado Then
                If iidClientes <> "" Then iidClientes = iidClientes & ", "
                iidClientes = iidClientes & iidcliente.gidCliente
            End If
        Next
        If funcCR Is Nothing Then funcCR = New FuncionesConceptosProduccion
        Dim con As New SqlConnection(sconexion)
        Dim sel As String
        sel = " select EQ.idArticulo, count(EQ.idEquipo) as Contador, Agrupacion "
        sel = sel & " from EquiposProduccion as EQ left join Articulos as AR ON AR.idArticulo = EQ.idArticulo "
        sel = sel & " left join subTiposArticulo as ST ON ST.idsubTipoArticulo = AR.idSubTipoArticulo"
        sel = sel & " left join AgrupacionesArticulo as AG ON AG.idAgrupacion = ST.idAgrupacion"
        sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
        sel = sel & " left join Estados as ES ON ES.idEstado = EQ.idEstado"
        sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
        sel = sel & " left join Pedidos as PE ON PE.numPedido = CP.numPedido"
        sel = sel & " left join Estados as EPE ON EPE.idEstado = PE.idEstado"
        sel = sel & " left join Estados as ECP ON ECP.idEstado = CP.idEstado"
        sel = sel & " where ((PE.numPedido is null and ES.Completo = 0 ) or EPE.Anulado = 0)  AND (ECP.Traspasado = 1 or (ECP.Completo = 1 AND ECP.Bloqueado = 0) or (EPE.EnCurso is null)) and ES.Completo<>1  "
        sel = sel & If(iidClientes = "", "", " AND PE.idCliente in(" & iidClientes & ") ")
        sel = sel & " group by EQ.idArticulo,Agrupacion"
        Dim lista As New List(Of IDComboBox3)
        cmd = New SqlCommand(sel, con)
        con.Open()
        If cmd.ExecuteNonQuery Then
            con.Close()
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            For Each linea As DataRow In dt.Rows
                If linea("idArticulo") Is DBNull.Value Then
                Else
                    lista.Add(New IDComboBox3(If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion")), If(linea("Contador") Is DBNull.Value, 0, linea("Contador")), linea("idArticulo")))
                End If
            Next
        Else
            con.Close()
        End If
        Return lista
    End Function

    Public Function Mostrar(ByVal Vista As String, ByVal inumPedido As Integer) As List(Of DatosEquipoProduccion)
        Return Mostrar(Vista, inumPedido, "")
    End Function

    Public Function Mostrar(ByVal Vista As String, ByVal inumPedido As Integer, ByVal ListaidClientes As String) As List(Of DatosEquipoProduccion)
        'Muestra los equipos o partes de equipo en producción en las secciones de la vista indicada
        'Estados Pedido: PENDIENTE, PRODUCCIÓN, PARCIAL, PREPARADO, PRODUCIDO (o bien producción manual, equipo no acabado)
        'Estados ConceptoPedido: ENVIADO, RECIBIDO, EN PRODUCCION, PRODUCIDO
        'Estados EQUIPO 
        Try
            Dim lista As New List(Of DatosEquipoProduccion)
            If Vista = "TALLER" Or Vista = "ELECTRÓNICA" Or Vista = "TODAS" Then
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = ""
                If Vista = "TALLER" Then '           pedidos manuales deja de verse si está producido          
                    sel = "Select " & sel1 & " WHERE  CEP.idArticulo <> (case when EP.idArticulo = 320 then  318 else '' end) and ((PE.numPedido is null  ) or EPE.Anulado = 0) and esTA.anulado = 0 and (E1.Traspasado = 1 or (E1.Completo = 1 AND E1.Bloqueado = 0) or (EPE.EnCurso is null and Estados.Completo<>1))  " 'utiliza sal1
                    sel = sel & If(inumPedido = 0, "", "AND PE.NumPedido = " & inumPedido) & If(ListaidClientes = "", "", " AND PE.idCliente in(" & ListaidClientes & ") ")
                    sel = sel & " Order By  prioridad,FechaPedido ASC, numPedido ASC,  FechaEntrega ASC,  CEP.idArticulo asc,VersionEscandallo ASC, CP.idProduccion"
                End If
                If Vista = "ELECTRÓNICA" Then
                    sel = "Select " & sel0 & " WHERE ((PE.numPedido is null and Estados.Completo = 0 ) or EPE.Anulado = 0) and esEL.anulado = 0 and (E1.Traspasado = 1 or (E1.Completo = 1 AND E1.Bloqueado = 0) or (EPE.EnCurso is null and Estados.Completo<>1))  "  'utiliza sal0
                    sel = sel & If(inumPedido = 0, "", "AND PE.NumPedido = " & inumPedido) & If(ListaidClientes = "", "", " AND PE.idCliente in(" & ListaidClientes & ") ")
                    sel = sel & " Order By prioridad, FechaPedido ASC,numPedido ASC,  FechaEntrega ASC,  EP.idArticulo asc,VersionEscandallo ASC, CP.idProduccion"
                End If
                If Vista = "TODAS" Then
                    'sel = "Select " & sel0 & " WHERE (esTA.Espera = 1 or esTA.EnCurso = 1 or esEL.Espera = 1 or esEL.EnCurso = 1)"
                    sel = "Select " & sel0 & " WHERE ((PE.numPedido is null and Estados.Completo = 0 ) or EPE.Anulado = 0)  AND (E1.Traspasado = 1 or (E1.Completo = 1 AND E1.Bloqueado = 0) or (EPE.EnCurso is null)) and Estados.Completo<>1  "  'utiliza sal0
                    sel = sel & If(inumPedido = 0, "", "AND PE.NumPedido = " & inumPedido) & If(ListaidClientes = "", "", " AND PE.idCliente in(" & ListaidClientes & ") ")
                    sel = sel & "  Order By prioridad,FechaPedido ASC, numPedido ASC,  FechaEntrega ASC, EP.idArticulo asc, VersionEscandallo ASC ,  CP.idProduccion"
                End If

                cmd = New SqlCommand(sel, con)

                Dim linea As DataRow
                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    For Each linea In dt.Rows
                        If linea("idEquipo") Is DBNull.Value Then
                        Else
                            lista.Add(CargarLinea(linea))
                        End If
                    Next
                Else
                    con.Close()
                End If
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("Vista", Vista)
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function Listar(ByVal iidProduccion As Long) As List(Of Long)
        'Equipos de una produccion
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            sel = " Select idEquipo From EquiposProduccion as EP left join Estados ON Estados.idEstado = EP.idEstado where idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Long)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idEquipo"))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function




    Public Function MostrarP(ByVal inumPedido As Integer, ByVal iidArticulo As Integer, ByVal iidArticuloBase As Integer) As List(Of DatosEquipoProduccion)
        'Equipos de un pedido
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidArticulo = 0 And iidArticuloBase = 0 Then
                sel = "Select " & sel0 & " WHERE C1.numPedido = " & inumPedido
            ElseIf iidArticuloBase = 0 Then
                sel = "Select " & sel0 & " WHERE C1.numPedido = " & inumPedido & " AND EP.idArticulo = " & iidArticulo
            Else
                sel = "Select " & sel0 & " WHERE C1.numPedido = " & inumPedido & " AND (EP.idArticulo in (" & iidArticulo & ", " & iidArticuloBase & ") or idArticuloBase = " & iidArticuloBase & ") "
            End If
            sel = sel & " Order By idEquipo"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEquipoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            ex.Data.Add("iidArticulo", iidArticulo)
            ex.Data.Add("iidArticuloBase", iidArticuloBase)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function




    Public Function Mostrar1(ByVal iidEquipo As Long) As DatosEquipoProduccion
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select " & sel0 & " WHERE EP.idEquipo = " & iidEquipo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEquipoProduccion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                'Dim esTAAnulado As Boolean = False
                'Dim esTAEnCurso As Boolean = False
                'Dim esTAEspera As Boolean = False
                'Dim esTACompleto As Boolean = False
                'Dim esESAnulado As Boolean = False
                'Dim esESEnCurso As Boolean = False
                'Dim esESEspera As Boolean = False
                'Dim esESCompleto As Boolean = False

                For Each linea In dt.Rows
                    If linea("idEquipo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function numsSerieAlbaran(ByVal iidConcepto As Long) As String
        'Devuelve un string con los nº de serie del concepto de albarán indicado, agrupando los que sean correlativos (los suponemos numéricos)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numSerie from EquiposProduccion as EP where idConceptoAlbaran = " & iidConcepto & " Order by numSerie ASC "
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim resultado As String = ""
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim ns As Integer = -1
                Dim nsa As Integer = -1
                For Each linea In dt.Rows
                    If linea("numSerie") Is DBNull.Value Then
                    Else
                        If IsNumeric(linea("numSerie")) And linea("numSerie") <> "0" Then
                            ns = linea("numSerie")
                            If ns = nsa + 1 Then
                                If Microsoft.VisualBasic.Right(resultado, 3) <> " - " Then
                                    resultado = resultado & " - "
                                End If
                            Else
                                If Microsoft.VisualBasic.Right(resultado, 3) = " - " Then
                                    resultado = resultado & nsa
                                End If
                                resultado = resultado & If(resultado = "", "", ", ") & ns
                            End If
                            nsa = ns
                        Else
                            resultado = If(resultado = "", "", ", ") & linea("numSerie")
                        End If
                    End If
                Next
                If Microsoft.VisualBasic.Right(resultado, 3) = " - " Then
                    resultado = resultado & ns
                End If
            End If
            If resultado <> "" Then resultado = "N/S: " & resultado
            If resultado.Length > 299 Then
                Dim func As New FuncionesConceptosAlbaranes
                Dim Orden As Integer = func.Orden(iidConcepto)
                resultado = Microsoft.VisualBasic.Left(resultado, 299)
                MsgBox("La linea de números de serie correspondiente al concepto " & Orden & "º, ha resultado demasiado larga y ha sido recortada. Por favor, reviselo en la Gestión de Albarán.")
            End If
            Return resultado
        Catch ex As Exception
            ex.Data.Add("iidConcepto", iidConcepto)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function


    Public Function numsSeriePedido(ByVal iidConcepto As Long) As String
        'Devuelve un string con los nº de serie del concepto de pedido indicado, agrupando los que sean correlativos (los suponemos numéricos)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numSerie from EquiposProduccion as EP left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion where idConceptoPedido = " & iidConcepto & " Order by numSerie ASC "
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim resultado As String = ""
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim ns As Integer = -1
                Dim nsa As Integer = -1
                For Each linea In dt.Rows
                    If linea("numSerie") Is DBNull.Value Then
                    Else
                        If IsNumeric(linea("numSerie")) Then
                            If linea("numSerie") > 0 Then
                                ns = linea("numSerie")
                                If ns = nsa + 1 Then
                                    If Microsoft.VisualBasic.Right(resultado, 3) <> " - " Then
                                        resultado = resultado & " - "
                                    End If
                                Else
                                    If Microsoft.VisualBasic.Right(resultado, 3) = " - " Then
                                        resultado = resultado & nsa
                                    End If
                                    resultado = resultado & If(resultado = "", "", ", ") & ns
                                End If
                                nsa = ns
                            Else
                                resultado = If(resultado = "", "", ", ") & linea("numSerie")
                            End If
                        End If
                    End If
                Next
                If Microsoft.VisualBasic.Right(resultado, 3) = " - " Then
                    resultado = resultado & ns
                End If
            End If
            Return resultado
        Catch ex As Exception
            ex.Data.Add("iidConcepto", iidConcepto)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function


    Public Function Columnas(ByVal SoloInacabados As Boolean) As Integer
        'Devuelve el número de numPedidos/prioridad diferentes (serán las columnas de la vistaProduccion)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select  count(numPedido) from ConceptosProduccion as CP  left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido group by numPedido,Prioridad"
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
            ex.Data.Add("SoloInacabados", SoloInacabados)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function EquiposSecciones(ByVal iidProduccion As Long) As List(Of ParSeccionUnidades)
        'Cuenta los equipos en producción correspondientes a un Concepto de producción en cada seccion 
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select idSeccion,(select sum(idEquipo) from EquiposProduccion where idProduccion = " & iidProduccion & " AND idSeccion = SE.idSeccion) as Unidades "
            sel = sel & " from secciones as SE "
            Dim lista As New List(Of ParSeccionUnidades)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim par As ParSeccionUnidades
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idSeccion") Is DBNull.Value Then
                    Else
                        par = New ParSeccionUnidades
                        par.gidSeccion = linea("idSeccion")
                        par.gUnidades = If(linea("Unidades") Is DBNull.Value, 0, linea("Unidades"))
                        lista.Add(par)
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function EstaEnUso(ByVal iidProduccion As Long) As Boolean
        'Indica si hay equipos en una producción
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select Count(idEquipo) from EquiposProduccion where idProduccion = " & iidProduccion

            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function





    Public Function CodArticuloPedido(ByVal iidEquipo As Long) As String
        'Devuelve el código del artículo original pedido de este equipo (que puede ser un componente)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select CodArticulo from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion As CR ON CR.idProduccion = EQ.idProduccion "
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido "
            sel = sel & " left join Articulos ON Articulos.idArticulo = CP.idArticulo Where EQ.idEquipo = " & iidEquipo

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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function ArticuloPedido(ByVal iidEquipo As Long) As String
        'Devuelve el código del artículo original pedido de este equipo (que puede ser un componente)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select Articulos.Articulo from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion As CR ON CR.idProduccion = EQ.idProduccion "
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido "
            sel = sel & " left join Articulos ON Articulos.idArticulo = CP.idArticulo Where EQ.idEquipo = " & iidEquipo

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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function idArticuloPedido(ByVal iidEquipo As Long) As Integer
        'Devuelve el id del artículo original pedido de este equipo (que puede ser un componente)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select CP.idArticulo from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion As CR ON CR.idProduccion = EQ.idProduccion "
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido "
            sel = sel & " left join Articulos ON Articulos.idArticulo = CP.idArticulo Where EQ.idEquipo = " & iidEquipo

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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function idArticuloEquipo(ByVal iidEquipo As Long) As Integer
        'Devuelve el id del artículo original pedido de este equipo (que puede ser un componente)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select idArticulo from EquiposProduccion   Where idEquipo = " & iidEquipo

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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function nuevoNumSerie() As String
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select max(case when isnumeric(numSerie)=1 then CAST(numSerie as bigint) else 0 end) from EquiposProduccion"
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CLng(o) + 1
            End If
        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function ExistenumSerie(ByVal numSerie As String, ByVal iidEquipo As Long) As Boolean
        'Indica si existe algún equipo diferente del indicado con el número de serie 
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select numSerie from EquiposProduccion where idEquipo <> " & iidEquipo & " AND numSerie = '" & numSerie & "' "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CStr(o) = numSerie)
            End If
        Catch ex As Exception
            ex.Data.Add("iidEquipo", iidEquipo)
            ex.Data.Add("numSerie", numSerie)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function CantidadAcabadaElectronica(ByVal iidArticulo As Integer)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select count(idEquipo) from EquiposProduccion as EQ left join Estados as EE ON EE.idEstado = EQ.idEstadoElectronica "
            sel = sel & " left join Estados as ET ON ET.idEstado = EQ.idEstadoTaller  "
            sel = sel & "where EE.Completo = 1 and ET.Completo = 0 and ET.Anulado = 0 AND "
            sel = sel & " idEquipo in(select idEquipo from ConceptosEquiposProduccion where idArticulo = " & iidArticulo & ") "

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
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function


    Public Function StockBase(ByVal iidArticuloBase As Integer) As Integer
        'Devuelve el número de equipos liberados a stock basados en un artículo Base
        If iidArticuloBase = 0 Then Return 0
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select  count(distinct idEquipo) From EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion "
            sel = sel & " left join Escandallos ON (Escandallos.idArticuloBase = EQ.idArticulo OR Escandallos.idArticulo = EQ.idArticulo)"
            sel = sel & " Where idConceptoPedido = 0 AND (Escandallos.idArticuloBase = " & iidArticuloBase & " OR Escandallos.idArticulo = " & iidArticuloBase & ") "

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
            ex.Data.Add("iidArticuloBase", iidArticuloBase)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function




    Public Function Contador(ByVal iidProduccion As Long) As Integer
        'Indica el nº de equipos asociados a una producción
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select count(idEquipo) from EquiposProduccion  where idProduccion = " & iidProduccion
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
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function idProduccion(ByVal iidEquipo As Long) As Long
        'Indica el nº de produccion de un equipo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select idProduccion from EquiposProduccion  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function idEquipo(ByVal numSerie As String) As Long
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            numSerie = Trim(numSerie)
            sel = " select idEquipo from EquiposProduccion  where numSerie = '" & numSerie & "' "
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



    Public Function ProduccionCompletada(ByVal iidProduccion As Long) As Boolean
        'Informa si la linea ya ha sido completada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select min(cast(Completo as tinyint)) from EquiposProduccion left join estados on Estados.idEstado = EquiposProduccion.idEstado where idProduccion = " & iidProduccion
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
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function




    Public Function TodosTraspasados(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idProduccion) from EquiposProduccion left join estados on Estados.idEstado = EquiposProduccion.idEstado where Traspasado = 0 and numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return True
            Else
                Return (CInt(o) = 0)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function TodosAcabados(ByVal iidProduccion As Integer) As Boolean
        'Informa si todos los equipos del concepto de producción se han acabado
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idProduccion) from EquiposProduccion as EQ left join estados on Estados.idEstado = EQ.idEstado where Completo = 0 and idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return True
            Else
                Return (CInt(o) = 0)
            End If

        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoAcabado(ByVal iidProduccion As Integer) As Boolean
        'Informa si algún  equipo del concepto de producción se ha acabado
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idProduccion) from EquiposProduccion left join estados on Estados.idEstado = EquiposProduccion.idEstado where Completo = 1 and idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CInt(o) > 0)
            End If

        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoEnCurso(ByVal iidProduccion As Integer) As Boolean
        'Informa si algún  equipo del concepto de producción está en curso 
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idProduccion) from EquiposProduccion left join estados on Estados.idEstado = EquiposProduccion.idEstado where EnCurso = 1 and idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CInt(o) > 0)
            End If

        Catch ex As Exception
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function





    Public Function CampoIdEscandallo(ByVal iidEquipo As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEscandallo from EquiposProduccion  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function idEstado(ByVal iidEquipo As Long) As Integer

        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstado from EquiposProduccion  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function conNumSerie(ByVal iidEquipo As Long) As Boolean
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select conNumSerie from EquiposProduccion left join Articulos ON Articulos.idArticulo = EquiposProduccion.idArticulo  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function conNumSerie2(ByVal iidEquipo As Long) As Boolean
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select conNumSerie2 from EquiposProduccion left join Articulos ON Articulos.idArticulo = EquiposProduccion.idArticulo  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function idEstadoTaller(ByVal iidEquipo As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstadoTaller from EquiposProduccion  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function idEstadoElectronica(ByVal iidEquipo As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstadoElectronica from EquiposProduccion  where idEquipo = " & iidEquipo
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
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function TodosPedidoAcabados(ByVal inumPedido As Integer) As Boolean
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select  count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstado "
            sel = sel & " where Estados.Completo = 0 and Estados.Anulado = 0 AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) = 0
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function TodosAcabadosTaller(ByVal inumPedido As Integer) As Boolean
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select  count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoTaller "
            sel = sel & " where Estados.Completo = 0 and Estados.Anulado = 0 AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) = 0
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function TodosAcabadosElectronica(ByVal inumPedido As Integer) As Boolean
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select  count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoElectronica "
            sel = sel & " where Estados.Completo = 0 AND Estados.Anulado = 0 AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) = 0
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosEquiposElectronica(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select  count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoElectronica "
            sel = sel & " where  Estados.Anulado = 0 AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosEquiposTaller(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select  count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoTaller "
            sel = sel & " where  Estados.Anulado = 0 AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Public Function CuantosAcabados(ByVal iidProduccion As Long) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstado "
            sel = sel & " where Estados.Completo = 1  AND idProduccion = " & iidProduccion
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
            ex.Data.Add("iidProduccion", iidProduccion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosAcabadosElectronica(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoElectronica "
            sel = sel & " where Estados.Completo = 1  AND numPedido = " & inumPedido
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
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosAcabadosTaller(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoTaller "
            sel = sel & " where Estados.Completo = 1  AND numPedido = " & inumPedido
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
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosEnCursoTaller(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoTaller "
            sel = sel & " where Estados.EnCurso = 1  AND numPedido = " & inumPedido
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
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function CuantosEnCursoElectronica(ByVal inumPedido As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select count(idEquipo) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstadoElectronica "
            sel = sel & " where Estados.EnCurso = 1  AND numPedido = " & inumPedido
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
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function FechaAcabado(ByVal inumPedido As Integer) As Date
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " select max(EQ.FechaFin) from EquiposProduccion as EQ "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Estados ON Estados.idEstado = EQ.idEstado "
            sel = sel & " where Estados.Completo = 1  AND numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return CDate("1-1-1900")
            Else
                Return CDate(o)
            End If
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosEquipoProduccion) As Integer

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into EquiposProduccion (idProduccion, numSerie, idArticulo, idEscandallo, FechaInicio, FechaFin, idPersona,idEstado, idEstadoElectronica, idEstadoTaller, Observaciones, idEtiqueta,VersionEscandallo, idCreador, Creacion ) "
        sel = sel & " values (@idProduccion, @numSerie, @idArticulo, @idEscandallo, @FechaInicio, @FechaFin, @idPersona,@idEstado, @idEstadoElectronica, @idEstadoTaller, @Observaciones, @idEtiqueta, @VersionEscandallo, @idCreador, @Creacion) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProduccion", dts.gidProduccion)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("FechaInicio", dts.gFechaInicio)
                cmd.Parameters.AddWithValue("FechaFin", dts.gFechaFin)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idEstadoElectronica", dts.gidEstadoElectronica)
                cmd.Parameters.AddWithValue("idEstadoTaller", dts.gidEstadoTaller)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)

                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)

                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("dts.gidProduccion", dts.gidProduccion)
                CorreoError(ex)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosEquipoProduccion) As Boolean   '
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update EquiposProduccion set idProduccion = @idProduccion, numSerie = @numSerie, idArticulo = @idArticulo, idEscandallo = @idEscandallo,FechaInicio = @FechaInicio, FechaFin = @FechaFin,  "
        sel = sel & " idPersona = @idPersona, idEstado = @idEstado, idEstadoElectronica = @idEstadoElectronica, idEstadoTaller = @idEstadoTaller, Observaciones = @Observaciones, idEtiqueta = @idEtiqueta, VersionEscandallo = @VersionEscandallo, idModifica = @idModifica, Modificacion = @Modificacion   "
        sel = sel & " WHERE idEquipo = @idEquipo"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", dts.gidEquipo)
                cmd.Parameters.AddWithValue("idProduccion", dts.gidProduccion)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("FechaInicio", dts.gFechaInicio)
                cmd.Parameters.AddWithValue("FechaFin", dts.gFechaFin)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idEstadoElectronica", dts.gidEstadoElectronica)
                cmd.Parameters.AddWithValue("idEstadoTaller", dts.gidEstadoTaller)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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
                ex.Data.Add("dts.gidEquipo", dts.gidEquipo)
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function CambiarEstado(ByVal iidEquipo As Long, ByVal iidEstado As Integer) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idEstado = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("dts.gidEstado", iidEstado)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function

    Public Function CambiarIdProduccion(ByVal iidEquipo As Long, ByVal iidProduccion As Long) As Boolean
        Dim sel As String = "Update EquiposProduccion set idProduccion = @idProduccion, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idProduccion", iidProduccion)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("iidProduccion", iidProduccion)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function




    Public Function CambiarIdArticulo(ByVal iidEquipo As Long, ByVal iidArticulo As Long, ByVal iidEscandallo As Integer) As Boolean

        'Dim sconexion As String = CadenaConexion()

        Dim sel As String = ""
        If iidEscandallo = 0 Then
            sel = "Update EquiposProduccion set idArticulo = @idArticulo, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Else
            sel = "Update EquiposProduccion set idArticulo = @idArticulo, idEscandallo = @idEscandallo,  idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        End If

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idArticulo", iidArticulo)
                cmd.Parameters.AddWithValue("idEscandallo", iidEscandallo)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("dts.gidEquipo", iidEquipo)
                ex.Data.Add("iidArticulo", iidArticulo)
                ex.Data.Add("iidEscandallo", iidEscandallo)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function


    Public Function CambiaridConceptoAlbaran(ByVal iidEquipo As Long, ByVal iidConceptoAlbaran As Long) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idConceptoAlbaran = @idConceptoAlbaran, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", iidConceptoAlbaran)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("iidConceptoAlbaran", iidConceptoAlbaran)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function

    Public Function CambiarFechaFin(ByVal iidEquipo As Long, ByVal FechaFin As Date) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set FechaFin = @FechaFin, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("FechaFin", FechaFin)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("FechaFin", FechaFin)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function




    Public Function CambiarEstadoTaller(ByVal iidEquipo As Long, ByVal iidEstado As Integer) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idEstadoTaller = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("iidEstado", iidEstado)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function




    Public Function CambiarEstadoElectronica(ByVal iidEquipo As Long, ByVal iidEstado As Integer) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idEstadoElectronica = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where idEquipo = @idEquipo"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("iidEstado", iidEstado)
                CorreoError(ex)
                Return False

            End Try
        End Using
    End Function

    Public Function CalculaEstado(ByVal iidEquipo As Long) As Integer
        'Calcula y actualiza el estado segun los estados de taller y electrónica

        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select esTA.Anulado as esTAAnulado, esTA.EnCurso as esTAEnCurso, esTA.Espera as esTAEspera, esTA.Completo as esTACompleto, "
            sel = sel & " esEL.Anulado as esELAnulado, esEL.EnCurso as esELEnCurso, esEL.Espera as esELEspera, esEL.Completo as esELCompleto, EP.idEstado "
            sel = sel & " from EquiposProduccion as EP left Join Estados as esTA on esTA.idEstado = EP.idEstadoTaller "
            sel = sel & " left join Estados as esEL on esEL.idEstado = EP.idEstadoElectronica where idEquipo = " & iidEquipo
            cmd = New SqlCommand(sel, con)
            Dim idEstado As Integer
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim esTAAnulado, esTAEnCurso, esTAEspera, esTACompleto As Boolean
                Dim esELAnulado, esELEnCurso, esELEspera, esELCompleto As Boolean
                For Each linea In dt.Rows
                    esTAAnulado = If(linea("esTAAnulado") Is DBNull.Value, False, linea("esTAAnulado"))
                    esTAEnCurso = If(linea("esTAEnCurso") Is DBNull.Value, False, linea("esTAEnCurso"))
                    esTAEspera = If(linea("esTAEspera") Is DBNull.Value, False, linea("esTAEspera"))
                    esTACompleto = If(linea("esTACompleto") Is DBNull.Value, False, linea("esTACompleto"))
                    esELAnulado = If(linea("esELAnulado") Is DBNull.Value, False, linea("esELAnulado"))
                    esELEnCurso = If(linea("esELEnCurso") Is DBNull.Value, False, linea("esELEnCurso"))
                    esELEspera = If(linea("esELEspera") Is DBNull.Value, False, linea("esELEspera"))
                    esELCompleto = If(linea("esELCompleto") Is DBNull.Value, False, linea("esELCompleto"))
                    If esTAAnulado And esELEspera Or esTAEspera And esELAnulado Or esTAEspera Or esELEspera Then
                        idEstado = funcES.EstadoEspera("EQUIPO").gidEstado
                    ElseIf esTAEspera And esELCompleto Or esTACompleto And esELEspera Then
                        idEstado = funcES.EstadoEnCurso("EQUIPO").gidEstado
                    ElseIf esTAAnulado And esELCompleto Or esTACompleto And esTAAnulado Or esTACompleto And esTACompleto Then
                        idEstado = funcES.EstadoCompleto("EQUIPO").gidEstado
                    Else
                        idEstado = funcES.EstadoAnulado("EQUIPO").gidEstado
                    End If
                    If linea("idEstado") Is DBNull.Value Then
                        CambiarEstado(iidEquipo, idEstado)
                    Else
                        If idEstado <> linea("idEstado") Then
                            CambiarEstado(iidEquipo, idEstado)
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            Return idEstado
        Catch ex As Exception
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function


    Public Function CalculaEstadosConceptos(ByVal iidEquipo As Long) As Integer
        'Calcula y actualiza el estado del equipo segun los estados de los conceptos. Devuelve el estado actual
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select CEP.*, Estados.Completo from ConceptosEquiposProduccion as CEP left Join Estados ON Estados.idEstado = CEP.idEstado "
            sel = sel & " where idEquipo = " & iidEquipo
            cmd = New SqlCommand(sel, con)
            Dim iidEstado As Integer
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim esCompleto As Boolean = True
                For Each linea In dt.Rows
                    esCompleto = esCompleto And If(linea("esELCompleto") Is DBNull.Value, False, linea("esELCompleto"))
                Next
                'Si este equipo tiene conceptos y todos están acabados, damos por acabado el equipo
                If dt.Rows.Count > 0 Then
                    If esCompleto Then
                        iidEstado = funcES.EstadoCompleto("EQUIPO").gidEstado
                        CambiarEstado(iidEquipo, iidEstado)
                    End If
                Else
                    iidEstado = idEstado(iidEquipo)
                End If
            Else
                con.Close()
            End If
            Return iidEstado
        Catch ex As Exception
            ex.Data.Add("iidEquipo", iidEquipo)
            CorreoError(ex)
            Return Nothing
        End Try


    End Function

    Public Function AsignarnumSerie(ByVal iidEquipo As Long, ByVal numSerie As String) As Boolean
        'If numSerie = "0" Then
        '    Return False
        'End If
        If numSerie <> "0" AndAlso ExistenumSerie(numSerie, iidEquipo) Then
            Return False
        Else
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Update EquiposProduccion set numSerie = @numserie, Asignado = 1, idModifica = @idModifica, Modificacion = @Modificacion   where idEquipo = @idEquipo "
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
                    cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                    cmd.Parameters.AddWithValue("numSerie", numSerie)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
                    con.Open()
                    Dim t As Integer = cmd.ExecuteNonQuery()
                    con.Close()
                    Return t
                Catch ex As Exception
                    ex.Data.Add("iidEquipo", iidEquipo)
                    ex.Data.Add("numSerie", numSerie)
                    CorreoError(ex)
                    Return False
                End Try
            End Using
        End If

    End Function

    Public Function AsignarAlbaran(ByVal iidEquipo As Long, ByVal iidConceptoAlbaran As Long) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idConceptoAlbaran = @idConceptoAlbaran, idModifica = @idModifica, Modificacion = @Modificacion   where idEquipo = @idEquipo "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", iidConceptoAlbaran)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                ex.Data.Add("iidConceptoAlbaran", iidConceptoAlbaran)
                CorreoError(ex)
                Return False

            End Try
        End Using

    End Function


    Public Function AsignarAlbaranPedido(ByVal iidConceptoPedido As Integer, ByVal iidConceptoAlbaran As Long) As Boolean
        'Asigna el Concepto de albarán a los equipos del concepto pedido indicado que estén acababados
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update EquiposProduccion set idConceptoAlbaran = @idConceptoAlbaran, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " where idEstado = (select idEstado From Estados Where Completo = 1 AND Estados.Aplicacion = 'EQUIPO') AND idProduccion in(select idProduccion from ConceptosProduccion Where idConceptoPedido = @idConceptoPedido) "
        sel = sel & " AND (idConceptoAlbaran is null or idConceptoAlbaran = 0) AND (numSerie = 'SIN N/S' OR CAST(numSerie as int)> 0)    "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConceptoPedido", iidConceptoPedido)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", iidConceptoAlbaran)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t > 0
            Catch ex As Exception
                ex.Data.Add("iidConceptoPedido", iidConceptoPedido)
                ex.Data.Add("iidConceptoAlbaran", iidConceptoAlbaran)
                CorreoError(ex)
                Return False
            End Try
        End Using

    End Function


    Public Function IntercambiarIdProduccion(ByVal iidEquipo1 As Integer, ByVal iidEquipo2 As Integer) As Boolean
        'Intercambiamos los idProduccion entre dos equipos
        Dim iidProduccion1 As Long = idProduccion(iidEquipo1)
        Dim iidProduccion2 As Long = idProduccion(iidEquipo2)
        'Dim sconexion As String = CadenaConexion()

        Dim sel As String = "Update EquiposProduccion set idProduccion = @idProduccion, idModifica = @idModifica, Modificacion = @Modificacion   where idEquipo = @idEquipo "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo1)
                cmd.Parameters.AddWithValue("idProduccion", iidProduccion2)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                If t > 0 Then
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idEquipo", iidEquipo2)
                    cmd.Parameters.AddWithValue("idProduccion", iidProduccion1)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
                    con.Open()
                    t = cmd.ExecuteNonQuery()
                    con.Close()
                End If
                Return t
            Catch ex As Exception
                ex.Data.Add("iidEquipo1", iidEquipo1)
                ex.Data.Add("iidEquipo2", iidEquipo2)
                CorreoError(ex)
                Return False

            End Try
        End Using

    End Function


    Public Function borrarProduccion(ByVal iidProduccion As Long) As Boolean  ' Borra una cabecera de AlbaranProv


        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from EquiposProduccion where idProduccion = " & iidProduccion
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                ex.Data.Add("iidProduccion", iidProduccion)
                CorreoError(ex)
                Return 0

            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidEquipo As Long) As Boolean  ' Borra una cabecera de AlbaranProv


        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from EquiposProduccion where idEquipo = " & iidEquipo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                ex.Data.Add("iidEquipo", iidEquipo)
                CorreoError(ex)
                Return 0
            End Try
        End Using

    End Function

    Public Function actualizarObservaciones(ByVal idequipo As String, ByVal texto As String) As Boolean
        Dim resultado As String = ""
        Dim sel As String = "update EquiposProduccion set Observaciones = '" & texto & "' where idequipo = " & idequipo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using
    End Function

End Class
