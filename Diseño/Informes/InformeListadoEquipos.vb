Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeListadoEquipos

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRV.Load

    End Sub

    Public Function verInforme(ByVal sBusqueda As String, ByVal sBusquedaH As String, ByVal sOrden As String, ByVal TotalEquipos As Integer, ByVal TotalPedidos As Integer) As Boolean

        Dim informe As New ListadoEquipos

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        Dim sel As String


        If sBusquedaH = "NO BUSCAR HISTORICO" Then
            sel = If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numserie DESC, idEquipo DESC ", " Order By " & sOrden)
        Else
            sel = If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)

            '------------------------------ELIMINADO POR LUIS----------------------------------------

            'sel = sel & " UNION ALL "
            'sel = sel & " select case when isnumeric(numserie + '.e0')=1 then cast(numSerie as int) else 0 end as numSerieNumerico,0 as idEquipo, 0 as idProduccion, EP.numSerie, EP.idArticulo, idEscandallo, FechaFab as FechaInicio, FechaFab as FechaFin, 0 as idPErsona, 0 as idEstadoElectronica, 0 as idEstado,"
            'sel = sel & " EP.Observaciones,0 as idCreador, Null as Creacion,0 as idModifica, Null as Modificacion, 0 as idEtiqueta, 0 as idConceptoAlbaran, 0 as idEstadoTaller, "
            'sel = sel & " case when year(EP.FechaFab)=1900 then year(EP.FechaSal) else year(EP.FechaFab) end as VersionEscandallo,1, "
            'sel = sel & " EP.idArticulo as idArticuloCEP, '' as Etiqueta, EP.numPedido, EP.FechaSal as FechaPrevista,0 as Prioridad, 0 as idConceptoPedido, "
            'sel = sel & " FechaSal as FechaEntrega,case when EP.idArticulo = 0 then EP.Modelo else AR.codArticulo end as codArticulo,case when EP.idArticulo = 0 then EP.Modelo else AR.Articulo end as Articulo, '' as EstadoTaller,  AR.idTipoArticulo, AR.idsubTipoArticulo,AR.conVersiones, TipoArticulo, subTipoArticulo, "
            'sel = sel & " '' as EstadoElectronica, '' as Estado, EP.idCliente, PE.fecha as FechaPedido, EP.fechafab as FechaProduccion, Clientes.codCli, "
            'sel = sel & " Clientes.NombreComercial as Cliente, Albaranes.Fecha as FechaAlbaran, Facturas.Fecha as FechaFactura,  EP.numFactura, case when EP.numAlbaran is null or EP.numAlbaran=0 then NAlbaran else  cast(EP.numAlbaran as nvarchar(50)) end as numAlbaran, "
            'sel = sel & " CL.idCliente as idClienteAlb, CL.codCli as codCliAlb, CL.NombreComercial as ClienteAlb, AR.conNumSerie,AR.conNumSerie2,  0 as esTAanulado, "
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


            '------------------------------ELIMINADO POR LUIS----------------------------------------


            sel = sel & If(sOrden.Length = 0, " Order By numserie DESC, idEquipo DESC ", " Order By " & sOrden)


        End If
        informe.SetParameterValue("sParametro", sel)
        informe.SetParameterValue("TotalPedidos", TotalPedidos)
        informe.SetParameterValue("TotalEquipos", TotalEquipos)
        CRV.ReportSource = informe

        Return True

    End Function




End Class