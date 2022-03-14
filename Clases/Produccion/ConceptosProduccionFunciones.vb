Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesConceptosProduccion
    Inherits conexion

    Dim sconexion As String = CadenaConexion()
    Private cmd As SqlCommand
    Private funcEP As New FuncionesEquiposProduccion
    Private funcMA As New Master
    Private funcFE As New FuncionesFestivos
    Private idEstadoEquipoEspera As Integer = 0

    Dim sel0 As String = " Select CP.*, idSeccion, Nombre + ' ' + Apellidos as Persona, idEscandallo, C1.numPedido,PE.fecha as FechaPedido, PE.FechaEntrega, PE.idCliente, codCli, NombreComercial as Cliente, AR.codArticulo, AR.Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad, Estado, Bloqueado, " _
             & " (select count(idEquipo) from EquiposProduccion as EP1 left join Estados ON Estados.idEstado = EP1.idEstado  Where EP1.idProduccion = CP.idProduccion and Estados.Completo = 1) as Acabados, " _
             & " (select top 1 idEscandallo from Escandallos Where Escandallos.idArticulo = CP.idArticulo and (VersionEscandallo <= CP.VersionEscandallo OR AR.conVersiones = 0 or AR.conVersiones is null) order by VersionEscandallo DESC) AS idEscandalloVersionMasAlta " _
             & " FROM ConceptosProduccion as CP Left Join Articulos as AR ON AR.idArticulo = CP.idArticulo " _
             & " Left join Estados ON Estados.idEstado = CP.idEstado " _
             & " Left Join Personal ON Personal.idPersona = CP.idPersona " _
             & " Left Join Contactos ON Contactos.idContacto = Personal.idContacto " _
             & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
             & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
             & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
             & " left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido " _
             & " left join Pedidos as PE ON PE.numPedido = C1.numPedido " _
             & " left join Clientes ON Clientes.idCliente = PE.idCliente " _
             & " left join Escandallos as ES ON ES.idArticulo = CP.idArticulo AND ES.VersionEscandallo = CP.VersionEscandallo "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoProduccion)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By idProduccion ", " Order By " & sOrden)
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
                    If linea("idProduccion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Datos calculados
                        dts.gEquiposSecciones = funcEP.EquiposSecciones(dts.gidProduccion)

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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoProduccion
        Dim dts As New DatosConceptoProduccion
        dts.gidProduccion = linea("idProduccion")
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
        dts.gidConceptoPedido = If(linea("idConceptoPedido") Is DBNull.Value, 0, linea("idConceptoPedido"))
        dts.gPrioridad = If(linea("Prioridad") Is DBNull.Value, 3, linea("Prioridad"))
        dts.gFechaPrevista = If(linea("FechaPrevista") Is DBNull.Value, Now.Date, linea("FechaPrevista"))
        dts.gFechaFin = If(linea("FechaFin") Is DBNull.Value, Now.Date, linea("FechaFin"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
        'Datos de otras tablas
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gBloqueado = If(linea("Bloqueado") Is DBNull.Value, False, linea("Bloqueado"))
        dts.gnumPedido = If(linea("NumPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        If dts.gnumPedido = 0 Then
            'Si se trata de un pedido manual, tomamos la fecha de creación de la producción como fecha pedido
            dts.gFechaPedido = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion")).date
        Else
            dts.gFechaPedido = If(linea("FechaPedido") Is DBNull.Value, Now.Date, linea("FechaPedido"))
        End If
        dts.gFechaEntrega = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        If linea("idEscandallo") Is DBNull.Value Then
            dts.gidEscandallo = If(linea("idEscandalloVersionMasAlta") Is DBNull.Value, 0, linea("idEscandalloVersionMasAlta"))
        Else
            dts.gidEscandallo = linea("idEscandallo")
        End If

        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))
        dts.gAcabados = If(linea("Acabados") Is DBNull.Value, 0, linea("Acabados"))
        Return dts
    End Function

    Public Function BusquedaGlobal(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoProduccion)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select count(idEquipo) as cantidad, codArticulo,Articulo, TipoArticulo, case when idArticuloBase = 0 then EP.idArticulo else idArticuloBase end as iidArticulo "
            sel = sel & " from EquiposProduccion as EP "
            sel = sel & " left join ConceptosProduccion as CP ON CP.idProduccion = EP.idProduccion"
            sel = sel & " left Join Escandallos ON Escandallos.idEscandallo = EP.idEscandallo"
            sel = sel & " left join Articulos as AR ON AR.idArticulo = case when idArticuloBase = 0 then EP.idArticulo else idArticuloBase end"
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
            sel = sel & " Left join Estados ON Estados.idEstado = CP.idEstado "
            sel = sel & " left join ConceptosPedidos as C1 ON CP.idConceptoPedido = C1.idConcepto "
            sel = sel & " left join Pedidos as PE ON PE.numPedido = C1.numPedido "
            sel = sel & " left join Clientes ON Clientes.idCliente = PE.idCliente "
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
            sel = sel & " group by case when idArticuloBase = 0 then EP.idArticulo else idArticuloBase end, codArticulo,Articulo,TipoArticulo"
            sel = sel & " Order by codArticulo "
            'sel = sel & If(sOrden.Length = 0, " Order By codArticulo ", " Order By " & sOrden)
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
                    If linea("iidArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoProduccion
                      
                        dts.gidArticulo = If(linea("iidArticulo") Is DBNull.Value, 0, linea("iidArticulo"))
                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                        
                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))

                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                       

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

    Public Function Mostrar(ByVal soloNoBloqueados As Boolean) As List(Of DatosConceptoProduccion)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = sel0 & If(soloNoBloqueados, " WHERE Bloqueado = 0 ", "") & " ORDER BY numPedido ASC, Prioridad, ASC "
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
                    If linea("idProduccion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                       
                        'Datos calculados
                        dts.gEquiposSecciones = funcEP.EquiposSecciones(dts.gidProduccion)
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

    Public Function MostrarLogistica(ByVal sBusqueda As String, ByVal sBusquedaL As String, ByVal sOrden As String) As List(Of DatosConceptoProduccion)
        'sBusqueda es para los Conceptos de Produccion, sBusquedaL es para los Conceptos de Pedido
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            'La sentencia SQL tiene 2 partes, la que está en la variable sel0 es la búsqueda en Conceptos de Producción. 
            'A continuación unimos otra sentencia que busca los Conceptos de Pedido que no tienen escandallo ni producción

            'ESTO YA NO ES VÁLIDO:
            ''Buscamos pedidos con alguna linea enviada a Logística (si no es producible = no tiene escandallo) --> Estado de ConceptoPedido = ENVIADO A PRODUCCIÓN (Espera + Traspasado + no EnCurso)
            ''O que ha sido enviada a Logistica desde Gestión de Producción  --> Estado del ConceptoProduccion = PARCIAL (Automatico)
            ''O que se ha completado la producción. Estado ConceptoPedido = PRODUCIDO (Completo + No Bloqueado) (Estado ConceptoProduccion COMPLETO)

            'Ahora han de aparecer TODAS LAS LINEAS DE PEDIDO

            sel = sel0 & If(sBusqueda = "", "", " WHERE " & sBusqueda)
            sel = sel & " union ALL "
            sel = sel & " Select Distinct 0,0,AR.idArticulo,CP.Cantidad,CP.idEstado,CP.idArtCli,CP.idConcepto,PE.Prioridad,PE.FechaEntrega,PE.FechaEntrega,'',PE.idPersona,PE.idCreador,PE.Creacion,PE.idModifica,PE.Modificacion, CP.VersionEscandallo, idSeccion,Nombre + ' ' + Apellidos as Persona, idEscandallo, CP.numPedido,PE.fecha as FechaPedido, PE.FechaEntrega, PE.idCliente, codCli, NombreComercial as Cliente, AR.codArticulo, AR.Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad, Estado, Bloqueado, 0, "
            sel = sel & "(select top 1 idEscandallo from Escandallos Where Escandallos.idArticulo = CP.idArticulo and VersionEscandallo <= CP.VersionEscandallo order by VersionEscandallo DESC) AS idEscandalloVersionMasAlta  "
            sel = sel & " FROM ConceptosPedidos as CP "
            sel = sel & " left join Pedidos as PE ON PE.numPedido = CP.numPedido "
            sel = sel & " Left Join Articulos as AR ON AR.idArticulo = CP.idArticulo "
            sel = sel & " Left join Estados ON Estados.idEstado = CP.idEstado "
            sel = sel & " Left Join Personal ON Personal.idPersona = PE.idPersona "
            sel = sel & " Left Join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
            sel = sel & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo "
            sel = sel & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "
            sel = sel & " Left outer join ConceptosProduccion as CPR ON CP.idConcepto = CPR.idConceptoPedido "
            sel = sel & " left join ConceptosAlbaranes as CA ON CA.idConceptoPedido=CP.idConcepto"
            sel = sel & " left join Clientes ON Clientes.idCliente = PE.idCliente "
            sel = sel & " left join Escandallos ON Escandallos.idArticulo = CP.idArticulo and Escandallos.Activo=1 "
            sel = sel & " where CPR.idProduccion Is null " & If(sBusquedaL = "", "", " AND " & sBusquedaL)
            'De los Conceptos de Pedido, seleccionamos los que no están en producción, no tienen escandallo, en estado ENVIADO a PRODUCCIÓN
            sel = sel & If(sOrden.Length = 0, " Order By idProduccion ", " Order By " & sOrden)

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
                    If linea("idProduccion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                      
                        'Datos calculados
                        'dts.gEquiposSecciones = funcEP.EquiposSecciones(dts.gidProduccion)
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


    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla PedidosProv
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fechaPrevista As Date
            cmd = New SqlCommand("SELECT MIN(FechaPrevista) FROM ConceptosProduccion  ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                fechaPrevista = Now.Date
            Else
                If Date.TryParse(o, fechaPrevista) Then
                Else
                    fechaPrevista = Now.Date
                End If
            End If
            Dim fechaEntrega As Date
            cmd = New SqlCommand("SELECT MIN(FechaEntrega) FROM Pedidos  ", con)
            con.Open()
            o = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                fechaEntrega = Now.Date
            Else
                If Date.TryParse(o, fechaEntrega) Then
                Else
                    fechaEntrega = Now.Date
                End If
            End If
            If fechaEntrega > fechaPrevista Then
                Return fechaPrevista
            Else
                Return fechaEntrega
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fechaPrevista As Date
            cmd = New SqlCommand("SELECT MAX(FechaPrevista) FROM ConceptosProduccion  ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                fechaPrevista = Now.Date
            Else
                If Date.TryParse(o, fechaPrevista) Then
                Else
                    fechaPrevista = Now.Date
                End If
            End If
            Dim fechaEntrega As Date
            cmd = New SqlCommand("SELECT MAX(FechaEntrega) FROM Pedidos  ", con)
            con.Open()
            o = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                fechaEntrega = Now.Date
            Else
                If Date.TryParse(o, fechaEntrega) Then
                Else
                    fechaEntrega = Now.Date
                End If
            End If
            If fechaEntrega < fechaPrevista Then
                Return fechaPrevista
            Else
                Return fechaEntrega
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function CargaTrabajo(ByVal iidProduccion As Long) As Integer
        'Devuelve el número de dias de carga de trabajo para fabricar la linea de concepto de produccion indicada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " declare @DomesticosxDia int; set @DomesticosxDia = (Select DomesticosxDia from Master where numeracion = " & Now.Year & ") ;"
            sel = sel & " declare @IndustrialesxDia int; set @IndustrialesxDia = (Select IndustrialesxDia from Master where numeracion = " & Now.Year & ") ;"
            sel = sel & "select sum(case when Descuento1 = 1 then Cantidad/@DomesticosxDia else Cantidad/@IndustrialesxDia end) from ConceptosProduccion as CP left join Articulos ON Articulos.idArticulo = CP.idArticulo "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo"
            sel = sel & " Where idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return Math.Ceiling(CDbl(o)) 'Devuelve el entero mayor o igual (si salen 3,124 días, devuelve 4)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    Public Function NumsPedido(ByVal soloNoBloqueados As Boolean) As List(Of Integer)
        'Lista los numPedido que están en producción (todos o sólo los no acabados)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select distinct CO.numPedido from ConceptosProduccion as CP"
            sel = sel & " Left Join ConceptosPedidos as CO ON CO.idConcepto = CP.idConceptoPedido "
            sel = sel & " left join Estados ON Estados.idEstado = CP.idEstado "
            sel = sel & If(soloNoBloqueados, " WHERE Bloqueado = 0 ", "") & " ORDER BY numPedido ASC"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        If linea("numPedido") <> 0 Then
                            lista.Add(linea("numPedido"))
                        End If
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

   

    Public Function Mostrar1(ByVal iidProduccion As Integer) As DatosConceptoProduccion
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CP.idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoProduccion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idProduccion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Datos calculados
                        dts.gEquiposSecciones = funcEP.EquiposSecciones(dts.gidProduccion)
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

    Public Function Mostrar1CP(ByVal iidConceptoPedido As Integer) As DatosConceptoProduccion
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CP.idConceptoPedido = " & iidConceptoPedido
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoProduccion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idProduccion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Datos calculados
                        dts.gEquiposSecciones = funcEP.EquiposSecciones(dts.gidProduccion)
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


    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosProduccion where numPedido = " & inumDoc
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




    Public Function Columnas(ByVal soloNoBloqueados As Boolean) As Integer
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function CargaTrabajoN(ByVal Prioridad As Byte, ByVal I_D As Char) As Integer
        'Nº de equipos pendientes de producir con Agrupación no obtenible directamente porque no tienen subTipo
        Try
            Dim Contador As Integer = 0
            'If idEstadoEquipoEspera = 0 Then
            '    Dim funcES As New FuncionesEstados
            '    idEstadoEquipoEspera = funcES.EstadoEspera("EQUIPO").gidEstado
            'End If
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select EQ.idArticulo, Count(EQ.idArticulo) as Contador from EquiposProduccion as EQ left join Articulos as AR ON AR.idArticulo = EQ.idArticulo "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"
            sel = sel & " left join subTiposArticulo as ST ON ST.idsubTipoArticulo = AR.idSubTipoArticulo"
            sel = sel & " left join Estados as ES ON ES.idEstado = EQ.idEstado"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Pedidos as PE ON PE.numPedido = CP.numPedido"
            sel = sel & " left join Estados as EPE ON EPE.idEstado = PE.idEstado"
            sel = sel & " left join Estados as ECP ON ECP.idEstado = CP.idEstado"
            sel = sel & " where AR.idsubTipoArticulo = 0 AND CR.Prioridad <= " & Prioridad '"EQ.idEstado = " & idEstadoEquipoEspera & " AND CR.Prioridad <= " & Prioridad
            sel = sel & " AND ((PE.numPedido is null and ES.Completo = 0 ) or EPE.Anulado = 0)  AND (ECP.Traspasado = 1 or (ECP.Completo = 1 AND ECP.Bloqueado = 0) or (EPE.EnCurso is null)) and ES.Completo<>1  "
            sel = sel & " Group by EQ.idArticulo "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim ultimoIdArticulo As Integer = 0
                Dim UltimoResultado As Char = "N"

                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        If idTipoArticuloI_D(linea("idArticulo")) = I_D Then
                            Contador = Contador + If(linea("Contador") Is DBNull.Value, 0, linea("COntador"))
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            Return contador

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idsubTipoArticulo(ByVal iidArticulo As Integer) As Integer
        'Extraer el subtipoArticulo si el articulo forma parte de artículos con el subtipo definido o que su articulo base lo tiene
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select case "
            sel = sel & " when  max(AR.idsubTipoArticulo)= 0 then min(AR.idsubTipoArticulo) "
            sel = sel & " when min(AR.idsubTipoArticulo) = 0 then max(AR.idsubTipoArticulo) "
            sel = sel & " when max(AR.idsubTipoArticulo)= min(AR.idsubTipoArticulo) then min(AR.idsubTipoArticulo)"
            sel = sel & " else (select case "
            sel = sel & " when  max(AR.idsubTipoArticulo)= 0 then min(AR.idsubTipoArticulo) "
            sel = sel & " when min(AR.idsubTipoArticulo) = 0 then max(AR.idsubTipoArticulo) "
            sel = sel & " when max(AR.idsubTipoArticulo)= min(AR.idsubTipoArticulo) then min(AR.idsubTipoArticulo)"
            sel = sel & " else 0 end"
            sel = sel & " from ConceptosEscandallos as CE "
            sel = sel & " left join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo"
            sel = sel & " left join Articulos as AR on AR.idArticulo = ES.idArticulo"
            sel = sel & " where  CE.idArticulo = (select top 1 idArticuloBase from Escandallos where idArticulo = CE.idArticulo order by versionEscandallo desc))"
            sel = sel & " end as idSubtipo"
            sel = sel & " from ConceptosEscandallos as CE "
            sel = sel & " left join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo"
            sel = sel & " left join Articulos as AR on AR.idArticulo = ES.idArticulo"
            sel = sel & " where  CE.idArticulo = "
            cmd = New SqlCommand(sel & iidArticulo, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            Dim resultado As Integer
            If o Is DBNull.Value Or o Is Nothing Then
                resultado = 0
            Else
                resultado = CInt(o)
            End If
            'Buscamos partiendo del artículo base
            If resultado = 0 Then
                Dim funcES As New FuncionesEscandallos
                Dim iidArticuloBase As Integer = funcES.idArticuloBaseArticulo(iidArticulo)
                cmd = New SqlCommand(sel & iidArticuloBase, con)
                con.Open()
                o = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If

            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Private Function idTipoArticuloI_D(ByVal iidArticulo As Integer) As Char
        'Nos dice si un artículo es Industrial o Doméstico en función de que forme parte de equipos con el subtipo definido o que su articulo base lo tenga
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Descuento1,idsubTipoArticulo from TiposArticulo left join subTiposArticulo ON TiposArticulo.idTipoArticulo = subTiposArticulo.idTipoArticulo"
            sel = sel & " Where idsubTipoArticulo = (select case "
            sel = sel & " when  max(AR.idsubTipoArticulo)= 0 then min(AR.idsubTipoArticulo) " 'Miramos que todos los subtipos sean el mismo (ignorando los de valor 0)
            sel = sel & " when min(AR.idsubTipoArticulo) = 0 then max(AR.idsubTipoArticulo) "
            sel = sel & " when max(AR.idsubTipoArticulo)= min(AR.idsubTipoArticulo) then min(AR.idsubTipoArticulo)"
            sel = sel & " else (select case "
            sel = sel & " when  max(AR.idsubTipoArticulo)= 0 then min(AR.idsubTipoArticulo) "
            sel = sel & " when min(AR.idsubTipoArticulo) = 0 then max(AR.idsubTipoArticulo) "
            sel = sel & " when max(AR.idsubTipoArticulo)= min(AR.idsubTipoArticulo) then min(AR.idsubTipoArticulo)"
            sel = sel & " else 0 end"
            sel = sel & " from ConceptosEscandallos as CE "
            sel = sel & " left join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo"
            sel = sel & " left join Articulos as AR on AR.idArticulo = ES.idArticulo"
            sel = sel & " where  CE.idArticulo = (select top 1 idArticuloBase from Escandallos where idArticulo = CE.idArticulo order by versionEscandallo desc))"
            sel = sel & " end as idSubtipo"
            sel = sel & " from ConceptosEscandallos as CE "
            sel = sel & " left join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo"
            sel = sel & " left join Articulos as AR on AR.idArticulo = ES.idArticulo"
            sel = sel & " where  CE.idArticulo = " & iidArticulo & ")"
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim ultimoIdArticulo As Integer = 0
                For Each linea In dt.Rows
                    If linea("idsubTipoArticulo") Is DBNull.Value OrElse linea("idsubTipoArticulo") = 0 Then
                        Return "N"
                    Else
                        If linea("Descuento1") Is DBNull.Value Then
                            Return "I"
                        ElseIf linea("Descuento1") = True Then
                            Return "D"
                        Else
                            Return "I"
                        End If

                    End If
                Next
            Else
                con.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function





    Public Function CargaTrabajo0(ByVal Prioridad As Byte, ByVal I_D As Char) As Integer
        'Nº de equipos pendientes de producir con Agrupación obtenible directamente porque tienen subTipo
        Try
            'If idEstadoEquipoEspera = 0 Then
            '    Dim funcES As New FuncionesEstados
            '    idEstadoEquipoEspera = funcES.EstadoEspera("EQUIPO").gidEstado
            'End If
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select count(EQ.idEquipo) from EquiposProduccion as EQ left join Articulos as AR ON AR.idArticulo = EQ.idArticulo "
            sel = sel & " left join subTiposArticulo as ST ON ST.idsubTipoArticulo = AR.idSubTipoArticulo"
            sel = sel & " left join AgrupacionesArticulo as AG ON AG.idAgrupacion = ST.idAgrupacion"
            sel = sel & " left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion"

            sel = sel & " left join Estados as ES ON ES.idEstado = EQ.idEstado"
            sel = sel & " left join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido"
            sel = sel & " left join Pedidos as PE ON PE.numPedido = CP.numPedido"
            sel = sel & " left join Estados as EPE ON EPE.idEstado = PE.idEstado"
            sel = sel & " left join Estados as ECP ON ECP.idEstado = CP.idEstado"
            sel = sel & " where AR.idsubTipoArticulo > 0 AND CR.Prioridad <= " & Prioridad
            sel = sel & " AND ((PE.numPedido is null and ES.Completo = 0 ) or EPE.Anulado = 0)  AND (ECP.Traspasado = 1 or (ECP.Completo = 1 AND ECP.Bloqueado = 0) or (EPE.EnCurso is null)) and ES.Completo<>1  "
            sel = sel & If(I_D = "I", " And Agrupacion = 'INDUSTRIAL' ", " And Agrupacion <> 'INDUSTRIAL' ")
            ' sel = sel & " Group by EQ.idArticulo "

            ' sel = sel & " where AR.idsubTipoArticulo > 0  AND EQ.idEstado =  " & idEstadoEquipoEspera & " AND Prioridad <= " & Prioridad

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

    Public Function CargaTrabajo(ByVal Prioridad As Byte, ByVal I_D As Char) As Integer
        'Devuelve el número de equipos teóricos de la carga de trabajo actual según prioridades y tipo de equipo (industrial / doméstico)
        Return CargaTrabajo0(Prioridad, I_D) + CargaTrabajoN(Prioridad, I_D)

    End Function

    

    Public Function CargaTrabajo(ByVal Prioridad As Byte) As Integer
        'Devuelve el nº de días de carga de trabajo actual según la prioridad
        Dim dias As Integer
        Dim DomesticosXDia As Integer = funcMA.leerDomesticosXDia(Now.Date.Year)
        Dim IndustrialesXDia As Integer = funcMA.leerIndustrialesXDia(Now.Date.Year)
        'Dias de prioridad 1
        Dim EquiposIndustriales As Integer = CargaTrabajo(Prioridad, "I")
        Dim EquiposDomesticos As Integer = CargaTrabajo(Prioridad, "D")
        dias = If(IndustrialesXDia = 0, 0, (EquiposIndustriales / IndustrialesXDia)) + If(DomesticosXDia = 0, 0, (EquiposDomesticos / DomesticosXDia))

        Return dias
    End Function



    Public Function DiasTrabajo(ByVal Prioridad As Byte, ByVal I_D As Char, ByVal Equipos As Integer) As Integer
        'Devuelve el número de equipos teóricos de la carga de trabajo actual según prioridades y tipo de equipo (industrial / doméstico) incluyendo un nº de equipos a producir
        Dim dias As Integer = CargaTrabajo(Prioridad)
        Dim DomesticosXDia As Integer = funcMA.leerDomesticosXDia(Now.Date.Year)
        Dim IndustrialesXDia As Integer = funcMA.leerIndustrialesXDia(Now.Date.Year)
        Dim cociente As Double
        If I_D = "D" Then
            cociente = Equipos / DomesticosXDia
            If cociente > Math.Truncate(cociente) Then
                dias = dias + Math.Truncate(cociente) + 1
            Else
                dias = dias + Math.Truncate(cociente)
            End If
        Else
            cociente = Equipos / IndustrialesXDia
            If cociente > Math.Truncate(cociente) Then
                dias = dias + Math.Truncate(cociente) + 1
            Else
                dias = dias + Math.Truncate(cociente)
            End If
        End If
        Return dias
    End Function

    Public Function FechaInicioTrabajo(ByVal Prioridad As Byte) As Date
        'Devuelve la fecha de inicio del trabajo prevista desde hoy
        Dim dias As Integer = CargaTrabajo(Prioridad)
        Dim Fecha As Date = Now.Date.AddDays(1)
        Do While dias > 0
            If Not funcFE.EsFestivo(Fecha) Then dias = dias - 1
            Fecha = Fecha.AddDays(1)
        Loop
        Do While funcFE.EsFestivo(Fecha)
            Fecha = Fecha.AddDays(1)
        Loop
        Return Fecha
    End Function

    Public Function FechaFinTrabajo(ByVal Prioridad As Byte, ByVal Dias As Integer) As Date
        'Devuelve la fecha de fin del trabajo prevista desde hoy
        Dim diasF As Integer = CargaTrabajo(Prioridad) + Dias
        Dim Fecha As Date = Now.Date
        Fecha = Fecha.AddDays(1)
        Do While diasF > 0
            If Not funcFE.EsFestivo(Fecha) Then diasF = diasF - 1
            Fecha = Fecha.AddDays(1)
        Loop
        Do While funcFE.EsFestivo(Fecha)
            Fecha = Fecha.AddDays(1)
        Loop
        Return Fecha
    End Function

    Public Function Traspasada(ByVal iidProduccion As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosProduccion left join estados on Estados.idEstado = ConceptosProduccion.idEstado where idProduccion = " & iidProduccion
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


    Public Function TodosTraspasados(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idProduccion) from ConceptosProduccion left join estados on Estados.idEstado = ConceptosProduccion.idEstado where Traspasado = 0 and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function idEstado(ByVal iidProduccion As Long) As Integer

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstado from ConceptosProduccion where idProduccion = " & iidProduccion
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


    Public Function FechaPrevista(ByVal iidProduccion As Long) As Date

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select FechaPrevista from ConceptosProduccion where idProduccion = " & iidProduccion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                Return CDate(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosConceptoProduccion) As Integer 'Inserta una nueva Pedido y devuelve el nº
        If dts.gidArticulo > 0 Then
            Dim sel As String
            sel = "insert into ConceptosProduccion ( numAlbaran, idArticulo, Cantidad, idEstado, idArtCli, idConceptoPedido, Prioridad, FechaPrevista, FechaFin, Observaciones, idPersona,VersionEscandallo, idCreador, Creacion ) "
            sel = sel & " values (@numAlbaran, @idArticulo, @Cantidad, @idEstado, @idArtCli, @idConceptoPedido, @Prioridad, @FechaPrevista, @FechaFin, @Observaciones, @idPersona,@VersionEscandallo, @idCreador, @Creacion ) Select @@Identity"
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                    cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                    cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                    cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)
                    cmd.Parameters.AddWithValue("Prioridad", dts.gPrioridad)
                    cmd.Parameters.AddWithValue("FechaPrevista", dts.gFechaPrevista)
                    cmd.Parameters.AddWithValue("FechaFin", dts.gFechaFin)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    Dim t As Integer = cmd.ExecuteScalar
                    con.Close()
                    Return t
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        Else
            Return 0
        End If


    End Function

    Public Function actualizar(ByVal dts As DatosConceptoProduccion) As Boolean   '
        Dim sel As String
        sel = "update ConceptosProduccion set numAlbaran = @numAlbaran, idArticulo = @idArticulo, Cantidad = @Cantidad, idEstado = @idEstado,  "
        sel = sel & " idArtCli = @idArtCli, idConceptoPedido = @idConceptoPedido, Prioridad = @Prioridad, FechaPrevista = @FechaPrevista, FechaFin = @FechaFin, Observaciones = @Observaciones, idPersona = @idPersona,VersionEscandallo = @VersionEscandallo, idModifica = @idModifica, Modificacion = @Modificacion   "
        sel = sel & " WHERE idProduccion = @idProduccion"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProduccion", dts.gidProduccion)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)
                cmd.Parameters.AddWithValue("Prioridad", dts.gPrioridad)
                cmd.Parameters.AddWithValue("FechaPrevista", dts.gFechaPrevista)
                cmd.Parameters.AddWithValue("FechaFin", dts.gFechaFin)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
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

    Public Function CambiarEstado(ByVal iidProduccion As Long, ByVal iidEstado As Integer) As Boolean
        'Actualiza el estado si este es diferente
        If iidEstado <> idEstado(iidProduccion) Then
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Update ConceptosProduccion set idEstado = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where idProduccion = @idProduccion "
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idProduccion", iidProduccion)
                    cmd.Parameters.AddWithValue("idEstado", iidEstado)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
                    con.Open()
                    Dim t As Integer = cmd.ExecuteNonQuery()
                    con.Close()
                    Return t
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False

                End Try
            End Using
        End If
    End Function


    Public Function CambiarCantidad(ByVal iidProduccion As Long, ByVal Cantidad As Integer) As Boolean
        'Actualiza la cantidad
        Dim sel As String = "Update ConceptosProduccion set Cantidad = @Cantidad, idModifica = @idModifica, Modificacion = @Modificacion where idProduccion = @idProduccion "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProduccion", iidProduccion)
                cmd.Parameters.AddWithValue("Cantidad", Cantidad)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function CambiaridConceptoPedido(ByVal iidProduccion As Long, ByVal iidConceptoPedido As Long) As Boolean
        'Actualiza el idConceptoPedido
        Dim sel As String = "Update ConceptosProduccion set idConceptoPedido = @idConceptoPedido, idModifica = @idModifica, Modificacion = @Modificacion where idProduccion = @idProduccion "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProduccion", iidProduccion)
                cmd.Parameters.AddWithValue("idConceptoPedido", iidConceptoPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function CambiarPrioridad(ByVal iidConceptoPedido As Long, ByVal Prioridad As Byte) As Boolean
        Dim sel As String = "Update ConceptosProduccion set Prioridad = @Prioridad, idModifica = @idModifica, Modificacion = @Modificacion where idConceptoPedido = @idConceptoPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Prioridad", Prioridad)
                cmd.Parameters.AddWithValue("idConceptoPedido", iidConceptoPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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



    Public Function CambiarNumAlbaran(ByVal iidProduccion As Long, ByVal numAlbaran As Integer) As Boolean
        'Actualiza la cantidad
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosProduccion set numAlbaran = @numAlbaran, idModifica = @idModifica, Modificacion = @Modificacion where idProduccion = @idProduccion "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProduccion", iidProduccion)
                cmd.Parameters.AddWithValue("numAlbaran", numAlbaran)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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





    Public Function borrar(ByVal iidProduccion As Long) As Boolean  ' Borra una cabecera de AlbaranProv


        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosProduccion where idProduccion = " & iidProduccion
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

    Public Function CampoIdEscandallo(ByVal iidProduccion As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEscandallo from ConceptosProduccion  left join Articulos ON Articulos.idArticulo = ConceptosProduccion.idArticulo where idProduccion = " & iidProduccion
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

    Public Function IdConceptoPedido(ByVal iidProduccion As Long) As Long
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConceptoPedido from ConceptosProduccion  where idProduccion = " & iidProduccion
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function IdProduccion(ByVal iidConceptoPedido As Long) As Long
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idProduccion from ConceptosProduccion  where idConceptoPedido = " & iidConceptoPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idArticulo(ByVal iidProduccion As Long) As Integer
        If iidProduccion = 0 Then Return 0
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idArticulo from ConceptosProduccion  where idProduccion = " & iidProduccion
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


    Public Function Cantidad(ByVal iidProduccion As Long) As Long
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Cantidad from ConceptosProduccion  where idProduccion = " & iidProduccion
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function ExisteProduccion(ByVal iidConceptoPedido As Long) As Long
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idProduccion from ConceptosProduccion  where idConceptoPedido = " & iidConceptoPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function









End Class

