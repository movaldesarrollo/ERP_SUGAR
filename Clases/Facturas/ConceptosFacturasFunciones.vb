Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosFacturas

#Region "VARIABLES"

    Inherits conexion
    Dim cmd As SqlCommand
    Dim AñoColumna As String
    Dim vSeleccionBusqueda As String
    Dim sconexion As String = CadenaConexion()
    Private sel0 As String = " Select CO.*, C1.numAlbaran, codArticulo, Articulo, Articulos.idTipoArticulo, TipoArticulo, Articulos.idSubTipoArticulo, SubTipoArticulo, idUnidad, TipoUnidad, " _
            & " Estado, TiposIVA.TipoIVA as TipoIVATabla, TiposIVA.TipoRecargoEq as TipoRecargoEqTabla " _
            & " FROM ConceptosFacturas as CO Left Join Articulos ON Articulos.idArticulo = CO.idArticulo " _
            & " Left join Estados ON Estados.idEstado = CO.idEstado " _
            & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo " _
            & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad " _
            & " Left Join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA " _
            & " left outer join ConceptosAlbaranes as C1 ON C1.idConcepto = CO.idConceptoAlbaran "

    Private sel1 As String = " FA.codMoneda, Simbolo, sum(CF.Cantidad) as Cantidad, sum(PrecioNetoUnitario*Cantidad) as Base,SUM(CF.precioCoste*Cantidad) as 'coste' " _
        & " from ConceptosFacturas as CF left join Facturas as FA ON FA.numFactura = CF.numFactura" _
        & " left join Personal as PER on PER.idpersona = FA.idpersona" _
        & " left join contactos as CON on CON.idcontacto = PER.idcontacto" _
        & " left join Clientes as CL ON CL.idCliente = FA.idCliente" _
        & " left join Ubicaciones as UB ON UB.idUbicacion = FA.idUbicacion" _
        & " left join Paises ON Paises.idPais = UB.idPais" _
        & " left join Provincias as PR ON UB.Provincia = PR.Provincia COLLATE SQL_LATIN1_GENERAL_CP1_CI_AI" _
        & " left join Autonomias as AU ON AU.idAutonomia = PR.idAutonomia" _
        & " left join Articulos as AR ON AR.idArticulo = CF.idArticulo" _
        & " left join Monedas as MO ON MO.codMoneda =FA.codMoneda" _
        & " left join TiposArticulo AS TA ON TA.idTipoArticulo = AR.idTipoArticulo " _
        & "left join subTiposArticulo AS ST ON ST.idsubTipoArticulo = AR.idsubTipoArticulo "

#End Region

#Region "BUSQUEDA"

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoFactura)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numFactura, idConcepto ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoFactura)
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoFactura
        Dim dts As New DatosConceptoFactura
        dts.gidConcepto = linea("idConcepto")
        dts.gnumFactura = If(linea("NumFactura") Is DBNull.Value, 0, linea("numFactura"))
        dts.gnumAbono = If(linea("numAbono") Is DBNull.Value, 0, linea("numAbono"))
        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
        dts.gRefCliente = If(linea("RefCliente") Is DBNull.Value, "", linea("RefCliente"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gPVPUnitario = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
        dts.gTipoIVAFac = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gTipoRecargoEqFac = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        dts.gidConceptoAlbaran = If(linea("idConceptoAlbaran") Is DBNull.Value, 0, linea("idConceptoAlbaran"))
        dts.gNumsSerie = If(linea("numsSerie") Is DBNull.Value, "", linea("numsSerie"))
        dts.gPorcentajeComision = If(linea("PorcentajeComision") Is DBNull.Value, 0, linea("PorcentajeComision"))
        dts.gImporteComision = If(linea("ImporteComision") Is DBNull.Value, 0, linea("ImporteComision"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gTipoIVA = If(linea("TipoIVATabla") Is DBNull.Value, 0, linea("TipoIVATabla"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEqTabla") Is DBNull.Value, 0, linea("TipoRecargoEqTabla"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        Return dts
    End Function

#End Region

#Region "BUSQUEDA LIBRE"

    Public Function BusquedaLibre(ByVal sBusqueda As String, ByVal sOrden As String, Optional ByVal vIDLinea As String = "", Optional ByVal vAño As String = "0") As List(Of DatosEstadisticaVentas)
        Try
            vSeleccionBusqueda = vIDLinea
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""

            If vAño = "" Then
                vAño = "0"
            End If
            AñoColumna = vAño
            vAño = "sum(case when year(FA.fecha)='" & vAño & "' then PrecioNetoUnitario*Cantidad else 0 end) as '" & vAño & "',"

            Select Case vIDLinea
                Case "idcliente"
                    sel = "select   FA.idCliente,NombreComercial as Cliente, " & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by FA.idCliente,NombreComercial, FA.codMoneda, Simbolo "
                    sel = sel & If(sOrden = "", " Order By Cliente ASC ", " Order By " & sOrden)
                Case "idpais"
                    sel = "select   paises.idpais, paises.pais, " & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by pais, paises.idpais, FA.codMoneda, Simbolo "
                    sel = sel & If(sOrden = "", " Order By pais ASC ", " Order By " & sOrden)
                Case "idpersona"
                    sel = "select   FA.idpersona, case when CON.nombre is null then 'DESCONOCIDO' else (CON.nombre + ' ' + CON.apellidos) end as 'usuario', " & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by FA.idPersona, PER.usuario, CON.nombre, CON.apellidos, FA.codMoneda , Simbolo "
                    sel = sel & If(sOrden = "", " Order By usuario ASC ", " Order By " & sOrden)
                Case "idtipoarticulo"
                    sel = "select  TA.idtipoarticulo, TA.tipoarticulo," & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by TA.idtipoarticulo, TA.tipoarticulo, FA.codMoneda, Simbolo "
                    sel = sel & If(sOrden = "", " Order By tipoarticulo ASC ", " Order By " & sOrden)
                Case "idarticulo"
                    sel = "select  AR.idarticulo, AR.codarticulo," & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by AR.idarticulo, AR.codarticulo, FA.codMoneda, Simbolo "
                    sel = sel & If(sOrden = "", " Order By codarticulo ASC ", " Order By " & sOrden)
                Case "PorAñosCliente"
                    sel = "select   FA.idCliente,NombreComercial as Cliente, " & vAño & sel1
                    sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
                    sel = sel & " group by FA.idCliente,NombreComercial, FA.codMoneda, Simbolo "
                    sel = sel & If(sOrden = "", " Order By Cliente ASC ", " Order By " & sOrden)
            End Select
            cmd = New SqlCommand(sel, con)
            Dim dt As New DataTable
            Dim lista As New List(Of DatosEstadisticaVentas)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    'If linea(vIDLinea) Is DBNull.Value Then
                    'Else
                    lista.Add(CargarLineaEstadistica(linea))
                    'End If
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

    Private Function CargarLineaEstadistica(ByVal linea As DataRow) As DatosEstadisticaVentas
        Dim dts As New DatosEstadisticaVentas
        Select Case vSeleccionBusqueda
            Case "idcliente"
                dts.gColumna_0 = If(linea("idCliente") Is DBNull.Value, "", linea("idCliente"))
                dts.gColumna_1 = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
            Case "idpais"
                dts.gColumna_0 = If(linea("idpais") Is DBNull.Value, "", linea("idpais"))
                dts.gColumna_1 = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
            Case "idpersona"
                dts.gColumna_0 = If(linea("idpersona") Is DBNull.Value, "", linea("idpersona"))
                dts.gColumna_1 = If(linea("usuario") Is DBNull.Value, "", linea("usuario"))
            Case "idtipoarticulo"
                dts.gColumna_0 = If(linea("idtipoarticulo") Is DBNull.Value, "0", linea("idtipoarticulo"))
                dts.gColumna_1 = If(linea("tipoarticulo") Is DBNull.Value, "SIN TIPO", linea("tipoarticulo"))
            Case "idarticulo"
                dts.gColumna_0 = If(linea("idarticulo") Is DBNull.Value, "", linea("idarticulo"))
                dts.gColumna_1 = If(linea("codarticulo") Is DBNull.Value, "", linea("codarticulo"))
        End Select
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gCoste = If(linea("coste") Is DBNull.Value, "0", linea("coste"))

        If AñoColumna <> "0" Then
            dts.gBaseAño = If(linea(AñoColumna) Is DBNull.Value, 0, linea(AñoColumna))
        End If
        Return dts
    End Function

#End Region

#Region "BUSQUEDA LIBRE SUB"

    Public Function BusquedaLibreSub(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEstadisticaVentasSub)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            sel = "select  ST.idsubtipoarticulo, ST.subtipoarticulo, TA.tipoarticulo, " & sel1
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
            sel = sel & " group by ST.idsubtipoarticulo, ST.subtipoarticulo, TA.tipoarticulo, FA.codMoneda, Simbolo "
            sel = sel & If(sOrden = "", " Order By subtipoarticulo ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim dt As New DataTable
            Dim lista As New List(Of DatosEstadisticaVentasSub)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idsubtipoarticulo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLineaEstadisticaSub(linea))
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

    Private Function CargarLineaEstadisticaSub(ByVal linea As DataRow) As DatosEstadisticaVentasSub
        Dim dtsSub As New DatosEstadisticaVentasSub
        dtsSub.gColumna_0 = If(linea("idsubtipoarticulo") Is DBNull.Value, "S/N", linea("idsubtipoarticulo"))
        dtsSub.gColumna_1 = If(linea("subtipoarticulo") Is DBNull.Value, "SIN DEFINIR", linea("subtipoarticulo"))
        dtsSub.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dtsSub.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dtsSub.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dtsSub.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dtsSub.gCoste = If(linea("coste") Is DBNull.Value, "0", linea("coste"))
        Return dtsSub

    End Function

#End Region

#Region "RAICES"

    Public Function busquedaRaices() As List(Of DatosRaices)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select * from raizarticulos order by raiz"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosRaices)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idraiz") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLineaRaices(linea))
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

    Public Function comprobarExisteRaiz(ByVal nombre As String) As Boolean
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim i As Integer
            sel = "select count(raiz) from raizarticulos where raiz='" & nombre & "'"
            cmd = New SqlCommand(sel, con)
            con.Open()
            i = cmd.ExecuteScalar
            If i > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function crearRaiz(ByVal nombre As String) As Boolean
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "insert into raizarticulos (raiz) values ('" & nombre & "')"
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function borrarRaiz(ByVal raiz As String) As Boolean
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "delete raizarticulos where (raiz = '" & raiz & "')"
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function CargarLineaRaices(ByVal linea As DataRow) As DatosRaices
        Dim dts As New DatosRaices
        dts.gColumna_0 = linea("idraiz")
        dts.gColumna_1 = If(linea("raiz") Is DBNull.Value, 0, linea("raiz"))
        Return dts
    End Function

    Public Function CargarDatosRaizCantidad(ByVal año As String, ByVal raiz As String, ByVal sqlwhere As String) As Double
        Dim numero As Double
        Dim sconexion As String = CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        Dim sel As String = ""
        Dim dr As SqlDataReader
        Try

            sel = "select sum(CF.cantidad) from articulos as AR " & _
                                "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                                "left join facturas as PE on PE.numfactura = CF.numfactura " & _
                                "left join clientes as CL on CL.idcliente = PE.idcliente" & _
                                " where (AR.codArticulo like '" & raiz & "%') and year(fecha)= " & año & sqlwhere

            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        numero = FormatNumber(dr(0), 0)
                    Else
                        numero = 0
                    End If
                Loop
            Else
                Return 0
            End If
            con.Close()
            Return numero
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            Return 0
        End Try
    End Function

    Public Function CargarDatosRaizBase(ByVal año As String, ByVal raiz As String, ByVal sqlwhere As String) As Double
        Dim numero As Double
        Dim sconexion As String = CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        Dim sel As String
        Dim dr As SqlDataReader
        Try
            sel = "select sum(cantidad * precionetounitario) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura " & _
                    "left join clientes as CL on CL.idcliente = PE.idcliente" & _
                    " where (AR.codArticulo like '" & raiz & "%') and year(fecha)= " & año & sqlwhere
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        numero = FormatNumber(dr(0), 0)
                    Else
                        numero = 0
                    End If
                Loop
            Else
                Return 0
            End If
            con.Close()
            Return numero
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            Return 0
        End Try
    End Function

#End Region

#Region "MOSTRAR"

    Public Function Mostrar(ByVal inumFactura As Integer) As List(Of DatosConceptoFactura)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.numFactura = " & inumFactura & " Order By  Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoFactura)
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

    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoFactura
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoFactura
            If iidConcepto = 0 Then Return dts
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

#End Region

#Region "CONSULTAS"

    Public Function Traspasada(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosFacturas left join estados on Estados.idEstado = ConceptosFacturas.idEstado where idConcepto = " & iidConcepto
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

    Public Function PorcentajeComision(ByVal iidConcepto As Long) As Double
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select PorcentajeComision from ConceptosFacturas where idConcepto = " & iidConcepto
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
    End Function

    Public Function TodosTraspasados(ByVal inumFactura As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosFacturas left join estados on Estados.idEstado = ConceptosFacturas.idEstado where Traspasado = 0 and numFactura = " & inumFactura
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

#End Region

#Region "INSERTAR"

    Public Function insertar(ByVal dts As DatosConceptoFactura) As Integer 'Inserta una nueva Factura y devuelve el nº

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ConceptosFacturas (numFactura, numAbono,  codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli,TipoIVA, TipoRecargoEq, idConceptoAlbaran, numsSerie, PorcentajeComision, ImporteComision, precioCoste) "
        sel = sel & " values (@numFactura, @numAbono,  @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli,@TipoIVA, @TipoRecargoEq,@idConceptoAlbaran,@numsSerie,@PorcentajeComision,@ImporteComision," _
        & "(select top(1)Precio from Articulos_Precios where TipoPrecio = 'C' and Activo = 1 and idArticulo = @idArticulo)) Select @@Identity"

        'sel = "insert into ConceptosFacturas (numFactura, numAbono,  codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli,TipoIVA, TipoRecargoEq, idConceptoAlbaran, numsSerie, PorcentajeComision, ImporteComision) "
        'sel = sel & " values (@numFactura, @numAbono,  @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli,@TipoIVA, @TipoRecargoEq,@idConceptoAlbaran,@numsSerie,@PorcentajeComision,@ImporteComision) Select @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("numAbono", dts.gnumAbono)
                cmd.Parameters.AddWithValue("codArticuloCli", If(dts.gcodArticuloCli = "", dts.gcodArticulo, dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("RefCliente", dts.gRefCliente)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gnumFactura) + 1) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", dts.gidConceptoAlbaran)
                cmd.Parameters.AddWithValue("numsSerie", dts.gNumsSerie)
                cmd.Parameters.AddWithValue("PorcentajeComision", dts.gPorcentajeComision)
                cmd.Parameters.AddWithValue("ImporteComision", dts.gImporteComision)
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

#End Region

#Region "ACTUALIZAR"

    Public Function actualizar(ByVal dts As DatosConceptoFactura) As Boolean   '
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosFacturas set numFactura = @numFactura, numAbono = @numAbono,  codArticuloCli = @codArticuloCli, ArticuloCli = @ArticuloCli, "
        sel = sel & " RefCliente = @RefCliente, idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, idTipoIVA = @idTipoIVA, Descuento = @Descuento, "
        sel = sel & " PrecioNetoUnitario = @PrecioNetoUnitario, idEstado = @idEstado, idArtCli = @idArtCli, TipoIVA = @TipoIVA, TipoRecargoEq = @TipoRecargoEq, idConceptoAlbaran = @idConceptoAlbaran, "
        sel = sel & " numsSerie = @numsSerie, PorcentajeComision = @PorcentajeComision, ImporteComision = @ImporteComision "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("numAbono", dts.gnumAbono)
                cmd.Parameters.AddWithValue("codArticuloCli", If(dts.gcodArticuloCli = "", dts.gcodArticulo, dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("RefCliente", dts.gRefCliente)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                'cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", dts.gidConceptoAlbaran)
                cmd.Parameters.AddWithValue("numsSerie", dts.gNumsSerie)
                cmd.Parameters.AddWithValue("PorcentajeComision", dts.gPorcentajeComision)
                cmd.Parameters.AddWithValue("ImporteComision", dts.gImporteComision)
                'cmd.Parameters.AddWithValue("LiquidadaComision", dts.gLiquidadaComision)
                'cmd.Parameters.AddWithValue("FechaLiquidacion", dts.gFechaLiquidacion)
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

    Public Function actualizarLiquidacion(ByVal dts As DatosConceptoFactura) As Boolean   '
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosFacturas set  PorcentajeComision = @PorcentajeComision, ImporteComision = @ImporteComision"
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("PorcentajeComision", dts.gPorcentajeComision)
                cmd.Parameters.AddWithValue("ImporteComision", dts.gImporteComision)
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

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosFacturas set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
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

    Public Function CambiarTipoIVA(ByVal inumFactura As Integer, ByVal iidTipoIVA As Integer, ByVal dTipoIVA As Double, ByVal dTipoRecargoEq As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosFacturas set idTipoIVA = @idTipoIVA, TipoIVA = @TipoIVA, TipoRecargoEQ = @TipoRecargoEQ where numFactura = @numFactura "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", inumFactura)
                cmd.Parameters.AddWithValue("idTipoIVA", iidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dTipoIVA)
                cmd.Parameters.AddWithValue("TipoRecargoEQ", dTipoRecargoEq)

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

    Public Function CambiarIVA(ByVal dts As DatosFactura) As Boolean
        'Actualizar los datos de iva en los conceptos igual que la cabecera
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosFacturas set idTipoIVA = @idTipoIVA, TipoIVA = @TipoIVA, TipoRecargoEq = @TipoRecargoEq  where numFactura = @numFactura"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEq)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
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

    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosFacturas set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("PVPUnitario", PVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", PrecioNetoUnitario)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)

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

    Public Function CambiarNum(ByVal iidConcepto As Integer, ByVal num As Integer, ByVal Aplicacion As String) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = ""
        If Aplicacion = "ABONO" Then
            sel = "Update ConceptosFacturas set numAbono = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "PRODUCCION" Then
            sel = "Update ConceptosFacturas set numProduccion = " & num & " where idConcepto = " & iidConcepto
        End If


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

#End Region

#Region "BORRAR"

    Public Function borrarFactura(ByVal inumFactura As Integer) As Boolean  ' Borra una cabecera de AbonoProv

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosFacturas where numFactura = " & inumFactura
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

    Public Function borrar(ByVal iidConcepto As Integer, ByVal inumDoc As Integer) As Boolean  ' Borra una cabecera de AbonoProv

        Dim sel As String = "delete from ConceptosFacturas where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t > 0 Then
                    If OrdenacionErronea(inumDoc) Then
                        RenumerarConceptos(inumDoc, "")
                    Else
                        RenumerarConceptos(inumDoc, "Orden ASC")
                    End If
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function
#End Region

#Region "ORDEN"

    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosFacturas where numFactura = " & inumDoc
            Dim cmd As New SqlCommand(sel, con)
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

    Public Function MoverConceptos(ByVal iidConceptoSube As Long, ByVal iidConceptoBaja As Long) As Boolean
        If DisminuirOrden(iidConceptoSube) Then
            Return AumentarOrden(iidConceptoBaja)
        End If
    End Function

    Public Function AumentarOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosFacturas set Orden = Orden + 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
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

    Public Function DisminuirOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosFacturas set Orden = Orden - 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
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

    Public Sub RenumerarSiEsNecesario(ByVal inumDoc As Integer)
        If OrdenacionErronea(inumDoc) Then RenumerarConceptos(inumDoc, "")
    End Sub

    Private Function OrdenacionErronea(ByVal inumDoc As Integer) As Boolean
        'Detecta Orden = 0 y repeticiones de Orden
        Try
            Dim sel As String = "select (select count(idConcepto) from ConceptosFacturas where numFactura = @numFactura and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosFacturas where numFactura = @numFactura Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("numFactura", inumDoc)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub RenumerarConceptos(ByVal inumDoc As Integer, ByVal Orden As String)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConcepto from ConceptosFacturas where numFactura = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim NOrden As Short = 1
                For Each linea As DataRow In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        CambiarOrden(linea("idConcepto"), NOrden)
                        NOrden = NOrden + 1
                    End If
                Next
            Else
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function CambiarOrden(ByVal iidConcepto As Long, ByVal Orden As Short) As Boolean
        Dim sel As String = "Update ConceptosFacturas set ORden = @Orden where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Orden", Orden)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
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

#End Region

End Class
