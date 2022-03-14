Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosPedidos

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Private sel0 As String = " Select CO.*, C1.numOferta, C2.numProforma, codArticulo, Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad,TipoIVA, TipoRecargoEq,  Estado, " _
             & " case when AR.Escandallo = 1 then (Select count(idEquipo) From EquiposProduccion as EQ left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion Where EQ.idArticulo = AR.idArticulo and idConceptoPedido = 0 ) " _
             & " else AR.Stock end as CantidadStock " _
             & " FROM ConceptosPedidos as CO Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo " _
             & " Left join Estados ON Estados.idEstado = CO.idEstado " _
             & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
             & " left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA " _
             & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
             & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
             & " left outer join ConceptosOfertas as C1 ON C1.idConcepto = CO.idConceptoOferta " _
             & " left outer join ConceptosProformas as C2 ON C2.idConcepto = CO.idConceptoProforma "

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoPedido)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numPedido, idConcepto ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoPedido)
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoPedido

        Dim dts As New DatosConceptoPedido
        dts.gidConcepto = linea("idConcepto")
        dts.gnumPedido = If(linea("NumPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gnumProduccion = If(linea("numProduccion") Is DBNull.Value, 0, linea("numProduccion"))
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
        dts.gEstadoProduccion = If(linea("EstadoProduccion") Is DBNull.Value, "PENDIENTE", linea("EstadoProduccion"))
        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
        dts.gidConceptoOferta = If(linea("idConceptoOferta") Is DBNull.Value, 0, linea("idConceptoOferta"))
        dts.gidConceptoProforma = If(linea("idConceptoProforma") Is DBNull.Value, 0, linea("idConceptoProforma"))
        dts.gCantidadServida = If(linea("CantidadServida") Is DBNull.Value, 0, linea("CantidadServida"))
        dts.gCantidadPreparada = If(linea("CantidadPreparada") Is DBNull.Value, 0, linea("CantidadPreparada"))
        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        'Comprueba estado de la reparacion
        Dim estado As String
        estado = estadoReparacion(If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli")), If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli")), dts.gnumPedido)
        If estado = "" Then
            dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        Else
            dts.gEstado = estado
        End If
        dts.gnumOferta = If(linea("numOferta") Is DBNull.Value, 0, linea("numOferta"))
        dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
        dts.gCantidadStock = If(linea("CantidadStock") Is DBNull.Value, 0, linea("CantidadStock"))

        Return dts
    End Function

    'Actualizar estado produccion
    Public Function actualizarEstadoProduccion(ByVal estadoProduccion As String, ByVal idConcepto As Integer) As Boolean

        Dim con As New SqlConnection(sconexion)

        Try

            Dim query As String = "update ConceptosPedidos set estadoProduccion = '" & estadoProduccion & "' where idconcepto = " & idConcepto

            cmd = New SqlCommand(query, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Catch ex As Exception

            con.Close()

            Return False

        End Try

        Return True

    End Function

    Public Function estadoReparacion(ByVal ArticuloCli As String, ByVal codArticuloCli As String, ByVal numpedido As Integer) As String
        'Devuelve el artículo del concepto
        ArticuloCli = ArticuloCli.Replace("'", "''")
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select ES.Estatus  from ConceptosReparaciones as CR "
            sel = sel & " left join  Reparaciones as RE on RE.numReparacion = CR.numReparacion "
            sel = sel & " left join EstatusReparaciones as ES on ES.idEstatus = RE.idEstatus "
            sel = sel & " where CR.ArticuloCli = '" & ArticuloCli & "' and CR.codArticuloCli = '" & codArticuloCli & "' "
            sel = sel & "and ((select COUNT(*) from ConceptosProformas as CPRO where CPRO.numPedido = " & numpedido & " ) >= 1 or CR.numpedido = " & numpedido & ")"
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As String = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return o
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar(ByVal inumPedido As Integer) As List(Of DatosConceptoPedido)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.numPedido = " & inumPedido & " Order By  Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoPedido)
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
    Public Function MostrarPendientes(ByVal inumPedido As Integer) As List(Of DatosConceptoPedido)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.CantidadServida<>CO.Cantidad AND CO.numPedido = " & inumPedido & " Order By  Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoPedido)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosConceptoPedido
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        dts.gCantidad = dts.gCantidad - dts.gCantidadServida
                        dts.gCantidadServida = 0
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

    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoPedido
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoPedido
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

    Public Function Traspasada(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where idConcepto = " & iidConcepto
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

    Public Function Entregado(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Entregado from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where idConcepto = " & iidConcepto
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

    Public Function Creado(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea está en estado CREADO
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select case when Espera = 1 and Traspasado = 0 then 1 else 0 end as Creado from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where idConcepto = " & iidConcepto
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

    Public Function Escandallo(ByVal iidConcepto As Long) As Boolean
        'Informa si el artículo de la linea tiene escandallo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Articulos.Escandallo from ConceptosPedidos left join Articulos on Articulos.idArticulo = ConceptosPedidos.idArticulo"
            sel = sel & " left join Escandallos ON Escandallos.idArticulo = Articulos.idArticulo where Escandallos.Activo = 1 and idEscandallo is not null and idConcepto = " & iidConcepto
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

    Public Function idEstado(ByVal iidConcepto As Long) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstado from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function numPedido(ByVal iidConcepto As Long) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numPedido from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function numReparacion(ByVal iidConcepto As Long) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numReparacion from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function numPedidoDelAlbaran(ByVal numAlbaran As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numPedido from ConceptosPedidos  where numAlbaran = " & numAlbaran
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

    Public Function numAlbaran(ByVal iidConcepto As Long) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select numAlbaran from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function idArticulo(ByVal iidConcepto As Long) As Integer
        'Devuelve el artículo del concepto
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idArticulo from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function idArtCli(ByVal iidConcepto As Long) As Integer
        'Devuelve el artículo del concepto
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idArtCli from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function Cantidad(ByVal iidConcepto As Long) As Double
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Cantidad from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function CantidadPreparada(ByVal iidConcepto As Long) As Double
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select CantidadPreparada from ConceptosPedidos  where idConcepto = " & iidConcepto
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

    Public Function CantidadPreparadaRealmente(ByVal iidConcepto As Long) As Double
        'Calculada como: Si el artículo no tiene escandallo, ConceptosPedidos.CantidadPreparada, Si tiene escandallo, se cuentan los equipos con el bit Asignado menos los servidos
        'Finalmente, si la cantidad resultante es negativa, devolvemos 0
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select case When AR.Escandallo=0 then CantidadPreparada else"
            sel = sel & " (select count(idEquipo) from EquiposProduccion as EQ where idProduccion = CR.idProduccion AND Asignado = 1) - CantidadServida end "
            sel = sel & " from ConceptosPedidos as CP left join ConceptosProduccion as CR ON CP.idConcepto = CR.idConceptoPEdido"
            sel = sel & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo"
            sel = sel & " where CP.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            ElseIf CDbl(o) < 0 Then
                Return 0
            Else
                Return CDbl(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CantidadServida(ByVal iidConcepto As Long) As Double
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select CantidadServida from ConceptosPedidos  where idConcepto = " & iidConcepto

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

    Public Function CantidadServidaEnOtrosConceptosAlbaran(ByVal iidConceptoPedido As Long, ByVal iidConceptoAlbaran As Long) As Double
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "Select sum(CA.Cantidad) from ConceptosAlbaranes as CA left Join  ConceptosPedidos as CP ON CP.idConcepto = CA.idConceptoPedido where CA.idConceptoPedido = " & iidConceptoPedido & " AND CA.idConcepto <> " & iidConceptoAlbaran

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

    Public Function TodosTraspasados(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where Entregado = 0 and numPedido = " & inumPedido
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

    Public Function AlgunoTraspasado(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna  linea ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where Entregado = 1 and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoCREADO(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea está en estado CREADO
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where Espera = 1 and Traspasado = 0 and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoPreparado(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea está en estado PREPARADO
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where Completo = 1 and Bloqueado = 1 and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgoPreparado(ByVal inumPedido As Integer) As Boolean
        'Informa si HAY ALGO PREPARADO PARA SERVIR
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos WHERE cantidadPreparada > 0 AND numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TodoPreparado(ByVal inumPedido As Integer) As Boolean
        'Informa si está todo preparado.
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select sum(Cantidad ) - sum(CantidadPreparada) from ConceptosPedidos WHERE numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o = 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function AlgunoenProduccion(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea está en estado ENVIADO A LOGISTICA, RECIBIDO EN PRODUCCIÓN, EN PRODUCCION, PRODUCIDO o PREPARADO  Bits de estado: Traspasado o Completo 
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where (Completo = 1 or Traspasado = 1) and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoEmpezado(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene la producción PARCIAL , ACABADO o EN CURSO
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado where (entregado=1 or Completo=1 or (Traspasado=1 and EnCurso=1 and Espera=0) OR (Espera = 1 and Traspasado = 1 and EnCurso = 0))  and numPedido = " & inumPedido
            'sel = "Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado where (entregado=1 or Completo=1 )  and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoAcabado(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene la producción PARCIAL , ACABADO o EN CURSO
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = "Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado where (entregado=1 or Completo=1 or (Traspasado=1 and EnCurso=1))  and numPedido = " & inumPedido
            sel = "Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado where (entregado=1 or Completo=1 )  and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoProducible(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene un artículo con Escandallo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP left join Articulos ON Articulos.idArticulo = CP.idArticulo WHERE Articulos.Escandallo = 1 and numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ConceptoProducible(ByVal idConcepto As Integer) As Boolean
        'Informa si alguna linea tiene un artículo con Escandallo
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select COUNT(*) from ConceptosProduccion where idConceptoPedido = " & idConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function AlgunoProducibleEmpezado(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene un artículo con Escandallo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP left join Articulos ON Articulos.idArticulo = CP.idArticulo left join Estados ON Estados.idEstado = CP.idEstado "
            sel = sel & " WHERE (entregado=1 or Completo=1 or (Traspasado=1 and EnCurso=1)) AND Articulos.Escandallo = 1 And numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgunoPARCIAL(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene un artículo parcialmente servido
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP  WHERE CantidadServida < Cantidad  and CantidadServida > 0 AND numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function AlgoSERVIDO(ByVal inumPedido As Integer) As Boolean
        'Informa si alguna linea tiene algo servido o la referencia de un albarán
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP  WHERE (numAlbaran <> 0 OR CantidadServida > 0) AND numPedido = " & inumPedido
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TodosCompletos(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where Completo = 0 and numPedido = " & inumPedido
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

    Public Function TodosProduciblesProducidos(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas producibles de un pedido se han producido totalmente
        'Contamos las lineas que teniendo escandallo, el estado no es PRODUCIDO, PREPARADO ni SERVIDO
        'Si no hay ninguna es que o bien todo está producido o bien ninguna es producible --> Devuelve True
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos as CP left join estados on Estados.idEstado = CP.idEstado "
            sel = sel & " left join Articulos ON Articulos.idArticulo = CP.idArticulo "
            sel = sel & " left join ConceptosProduccion as CR ON CR.idConceptoPedido = CP.idConcepto "
            sel = sel & " where CR.idPRoduccion is not null and Articulos.Escandallo = 1 AND Completo = 0 AND Entregado = 0 and numPedido = " & inumPedido

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

    Public Function TodosPreparadosLogistica(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas de un pedido se han preparado en logística
        'Contamos las lineas en que CantidadPedida > CantidadPreparada. Si sale 0 es que está todo preparado para servir.
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos "
            sel = sel & " where Cantidad > CantidadPreparada and numPedido = " & inumPedido
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

    Public Function TodosPreparados(ByVal inumPedido As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosPedidos left join estados on Estados.idEstado = ConceptosPedidos.idEstado where (Completo = 0 or Bloqueado = 0) and numPedido = " & inumPedido
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

    Public Function CargaTrabajo(ByVal inumPedido As Integer) As Integer
        'Devuelve el número de dias de carga de trabajo para fabricar el pedido completo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " declare @DomesticosxDia int; set @DomesticosxDia = (Select DomesticosxDia from Master where numeracion = " & Now.Year & ") ;"
            sel = sel & " declare @IndustrialesxDia int; set @IndustrialesxDia = (Select IndustrialesxDia from Master where numeracion = " & Now.Year & ") ;"
            sel = sel & " select sum(case when Articulos.idTipoArticulo = 3 and idSubTipoArticulo = 34 then Cantidad/@DomesticosxDia else 0 end) + sum(case when Articulos.idTipoArticulo = 4 and idSubTipoArticulo = 36 then Cantidad/@IndustrialesxDia else 0 end) "
            sel = sel & " from ConceptosPedidos as CP left join Articulos ON Articulos.idArticulo = CP.idArticulo "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo"
            sel = sel & " Where numPedido = " & inumPedido
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

    Public Function calculadoraEquipos(ByVal d As Integer, ByVal i As Integer, ByVal d2 As Integer, ByVal r As Integer) As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "declare @d int;
declare @i int;
declare @d2 int;
declare @r int;
set @d = " & d & ";
set @i =" & i & ";
set @d2 = " & d2 & ";
set @r = " & r & ";
create table dias(
tipo varchar(200),
nDias int
);
insert into dias  (tipo, ndias) values 
('domestico ',(select @d/DomesticosXDia from master where numeracion = " & Year(Now()) & ")) ,
('domestico2 ',(select @d2/Domesticos2XDia from master where numeracion = " & Year(Now()) & ")),
('insdustriales ',(select @i/industrialesXDia from master where numeracion = " & Year(Now()) & ")),
('domestico2 ',(select @r/recambiosXDia from master where numeracion = " & Year(Now()) & ")) 
select top(1)ndias from dias order by ndias desc;
drop table dias;"
            '            sel = "select  
            'case when ( " & d & "/DomesticosXDia) >= (  " & i & "/IndustrialesXDia) and ( " & d & "/DomesticosXDia) >= (  " & d2 & "/Domesticos2XDia) then round ((convert(decimal(6,2)," & d & " )/DomesticosXDia), 0)
            'when ( " & d2 & "/Domesticos2XDia) >= (  " & i & "/IndustrialesXDia) and ( " & d2 & "/Domesticos2XDia) >= ( " & d & "/DomesticosXDia)  then round ((convert(decimal(6,2), " & d2 & " )/Domesticos2XDia) , 0)
            'else  round ((convert(decimal(6,2),  " & i & ")/IndustrialesXDia), 0) end
            'from master where numeracion = " & Year(Now())
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

        End Try

        Return 0
    End Function

    Public Function maxIndustrialesDia() As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select IndustrialesXDia from master where numeracion = " & Year(Now())
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return Math.Ceiling(CDbl(o))
            End If

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function maxDomesticosDia() As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select DomesticosXDia  from master where numeracion = " & Year(Now())
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else

                Return Math.Ceiling(CDbl(o))

            End If

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function maxDomesticos2Dia() As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Domesticos2XDia  from master where numeracion = " & Year(Now())
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else

                Return Math.Ceiling(CDbl(o))

            End If

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function maxRecambiosXDia() As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select RecambiosXDia from master where numeracion = " & Year(Now())
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()

            If o Is DBNull.Value Or o Is Nothing Then

                Return 0
            Else

                Return Math.Ceiling(CDbl(o))

            End If

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Public Function insertar(ByVal dts As DatosConceptoPedido) As Integer 'Inserta una nueva Pedido y devuelve el nº

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ConceptosPedidos (numPedido, numAlbaran, numProduccion, codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli, idConceptoOferta, idConceptoProforma, CantidadServida, CantidadPreparada, VersionEscandallo ) "
        sel = sel & " values (@numPedido, @numAlbaran, @numProduccion, @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli, @idConceptoOferta, @idConceptoProforma, @CantidadServida, @CantidadPreparada, @VersionEscandallo ) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numProduccion", dts.gnumProduccion)
                cmd.Parameters.AddWithValue("codArticuloCli", If(dts.gcodArticuloCli = "", dts.gcodArticulo, dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("RefCliente", dts.gRefCliente)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gnumPedido) + 1) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("idConceptoOferta", dts.gidConceptoOferta)
                cmd.Parameters.AddWithValue("idConceptoProforma", dts.gidConceptoProforma)
                cmd.Parameters.AddWithValue("CantidadServida", dts.gCantidadServida)
                cmd.Parameters.AddWithValue("CantidadPreparada", dts.gCantidadPreparada)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)

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

    Public Function actualizar(ByVal dts As DatosConceptoPedido) As Boolean

        Dim sel As String
        sel = "update ConceptosPedidos set numPedido = @numPedido, numAlbaran = @numAlbaran, numProduccion = @numProduccion, codArticuloCli = @codArticuloCli, ArticuloCli = @ArticuloCli, RefCliente = @RefCliente,"
        sel = sel & "  idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario, idEstado = @idEstado, idArtCli = @idArtCli, VersionEscandallo = @VersionEscandallo "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numProduccion", dts.gnumProduccion)
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
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)



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

    Public Function CambiarCantidad(ByVal iidConcepto As Integer, ByVal Cantidad As Double) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidos set Cantidad = " & Cantidad & " where idConcepto = " & iidConcepto
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

    Public Function CambiarCantidadServida(ByVal iidConcepto As Integer, ByVal CantidadServida As Double) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidos set CantidadServida = " & CantidadServida & " where idConcepto = " & iidConcepto
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

    Public Function CambiarCantidadPreparada(ByVal iidConcepto As Long, ByVal CantidadPreparada As Double) As Boolean

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidos set CantidadPreparada = " & CantidadPreparada & " where idConcepto = " & iidConcepto
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

    Public Function Renumerar(ByVal inumPedido As Integer) As Boolean
        'Renumera los conceptos si hay nº de orden repetido, estos queda correlativos
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConcepto, Orden from conceptosPedidos WHERE numPedido = " & inumPedido & " Order By  Orden,idConcepto "
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
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        CambiarOrden(linea("idConcepto"), Orden)
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

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean
        If iidEstado <> idEstado(iidConcepto) Then
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Update ConceptosPedidos set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
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
        End If
    End Function

    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidos set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
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

    Public Function CambiarTipoIVA(ByVal inumPedido As Integer, ByVal iidTipoIVA As Integer) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidos set idTipoIVA = @idTipoIVA where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idTipoIVA", iidTipoIVA)
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
        If Aplicacion = "ALBARAN" Then
            sel = "Update ConceptosPedidos set numAlbaran = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "PRODUCCION" Then
            sel = "Update ConceptosPedidos set numProduccion = " & num & " where idConcepto = " & iidConcepto
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

    Public Function EliminarItem(ByVal iidProduccion As Long) As Boolean
        'Eliminar 1 unidad de concepto de produccion, y el correspondiente equipo y regularizar stock

        If iidProduccion = 0 Then Return False

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = ""
        sel = sel & " declare @idEquipo as bigint;"
        sel = sel & " set @idEquipo = (select MAX(idEquipo) from EquiposProduccion as EQ left join Estados ON Estados.idEstado = EQ.idEstado  where Completo = 0 and idProduccion = " & iidProduccion & ");"
        sel = sel & " delete ConceptosEquiposProduccion where idEquipo = @idEquipo"
        sel = sel & " delete EquiposProduccion where idEquipo = @idEquipo"
        sel = sel & " update ConceptosProduccion set Cantidad = Cantidad -1 where  idProduccion = " & iidProduccion

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t > 1 Then
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

    Public Function borrarPedido(ByVal inumPedido As Integer) As Boolean  ' Borra una cabecera de AlbaranProv

        Dim sel As String = "delete from ConceptosPedidos where numPedido = " & inumPedido

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

    Public Function borrar(ByVal iidConcepto As Integer, ByVal inumDoc As Integer) As Boolean

        Dim sel As String = "delete from ConceptosPedidos where idConcepto = " & iidConcepto

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

    Public Function numProforma(ByVal idconceptopedido As Integer) As Boolean

        Dim sel As String = "select PRF.numproforma from ConceptosPedidos as CP left join conceptosproformas as PRF on PRF.idconcepto=CP.idconceptoproforma where CP.idConcepto = " & idconceptopedido

        Using con As New SqlConnection(sconexion)

            Try

                Dim dr As SqlDataReader

                Dim proforma As Integer

                cmd = New SqlCommand(sel, con)

                con.Open()

                dr = cmd.ExecuteReader

                If dr.HasRows Then

                    Do While dr.Read()

                        proforma = dr.GetInt32(0)

                    Loop

                End If

                con.Close()

                MsgBox("NºPROFORMA: " & proforma, MsgBoxStyle.Information)

                Return True

            Catch ex As Exception

                MsgBox("Este concepto de pedido no pertenece a ninguna proforma.", MsgBoxStyle.Information)

            End Try

        End Using

    End Function

    'MostrarCalculadora
    Public Function MostrarCalculadora() As DataTable

        Dim con As New SqlConnection(sconexion)

        Dim sel As String

        Dim dt As New DataTable

        Try
            sel = "select   PE.numPedido as 'P.PRODUCCION' ,PE.fechaProduccion as 'F.PRODUCCION' ,  
(select sum(Cpe.Cantidad )
from ConceptosPedidos as Cpe 
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo 
left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%'
and Cpe.numPedido = PE.numPedido 
and TA.TipoArticulo = 'DOMESTICO'  
and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) 
and (cpe.domesticos2 = 0 or cpe.domesticos2 is null)
and (ar2.domesticos2 = 0 or ar2.domesticos2 is null))
-
(select count(*) from EquiposProduccion as ep
left join ConceptosProduccion as cp on cp.idProduccion = ep.idProduccion
left join ConceptosPedidos as cpe on cpe.idConcepto = cp.idConceptoPedido
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo
left join TiposArticulo as TA  on TA.idTipoArticulo = AR2.idTipoArticulo
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%' 
	and Cpe.numPedido = PE.numPedido 
	and TA.TipoArticulo = 'DOMESTICO'  
	and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')  
	and (AR2.recambio = 0 or AR2.recambio is null)
	and (cpe.domesticos2 = 0 or cpe.domesticos2 is null) 
	and (ar2.domesticos2 = 0 or ar2.domesticos2 is null)
	and ep.EtiquetaFinalImpresa = 1) as 'DOMESTICO',

(select sum(Cpe.Cantidad )
from ConceptosPedidos as Cpe 
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo 
left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%'
and Cpe.numPedido = PE.numPedido 
and TA.TipoArticulo = 'DOMESTICO'  
and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) 
and (cpe.domesticos2 = 1
or ar2.domesticos2 = 1))
-
(select count(*) from EquiposProduccion as ep
left join ConceptosProduccion as cp on cp.idProduccion = ep.idProduccion
left join ConceptosPedidos as cpe on cpe.idConcepto = cp.idConceptoPedido
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo
left join TiposArticulo as TA  on TA.idTipoArticulo = AR2.idTipoArticulo
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%' 
	and Cpe.numPedido = PE.numPedido 
	and TA.TipoArticulo = 'DOMESTICO'  
	and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')  
	and (AR2.recambio = 0 or AR2.recambio is null)
	and (cpe.domesticos2 = 1
	or ar2.domesticos2 = 1)
	and ep.EtiquetaFinalImpresa = 1)as 'DOMESTICOS 2',

(select sum(Cpe.Cantidad )
from ConceptosPedidos as Cpe 
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo 
left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%'
and Cpe.numPedido = PE.numPedido 
and TA.TipoArticulo = 'INDUSTRIAL'  
and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) )
-
(select count(*) from EquiposProduccion as ep
left join ConceptosProduccion as cp on cp.idProduccion = ep.idProduccion
left join ConceptosPedidos as cpe on cpe.idConcepto = cp.idConceptoPedido
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo
left join TiposArticulo as TA  on TA.idTipoArticulo = AR2.idTipoArticulo
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%' 
	and Cpe.numPedido = PE.numPedido 
	and TA.TipoArticulo = 'INDUSTRIAL'  
	and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')  
	and (AR2.recambio = 0 or AR2.recambio is null)
	and ep.EtiquetaFinalImpresa = 1)as 'INDUSTRIAL',
(select sum(Cpe.Cantidad )
from ConceptosPedidos as Cpe 
left join Articulos as AR2 on AR2.idArticulo = Cpe.idArticulo 
left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where  AR2.Articulo not like 'CELULA%' and Cpe.numPedido = PE.numPedido and AR2.recambio = 1) as 'RECAMBIOS'

from pedidos as PE LEFT JOIN ConceptosPedidos as CP on CP.numPedido = PE.numPedido  
LEFT JOIN Clientes as CLI on CLI.idCliente = PE.idCliente  where   PE.idEstado in (65,6,58,21 ) and  PE.Banulado = 0  and  
(select COUNT(*) from ConceptosPedidos as CP2  left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo    
left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo   where CP2.numPedido = PE.numpedido and (ART2.codArticulo = 'REPARACION' or ART2.codArticulo is null))
<   (select COUNT(*) from  ConceptosPedidos as CP2   left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo   
left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo where CP2.numPedido = PE.numpedido )  and  ((select sum(C.Cantidad )from ConceptosPedidos as C 
left join Articulos as AR2 on AR2.idArticulo = C.idArticulo left join TiposArticulo as TA   on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'DOMESTICO'  
    and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')  
    and (AR2.recambio = 0 or AR2.recambio is null) )IS NOT NULL or  
    (select sum(C.Cantidad )from ConceptosPedidos as C 
    left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
    left join TiposArticulo as TA  on TA.idTipoArticulo = AR2.idTipoArticulo 
    left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
    where AR2.Articulo not like 'CELULA%' 
        and C.numPedido = PE.numPedido 
        and TA.TipoArticulo = 'INDUSTRIAL' 
        and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')  
        and (AR2.recambio = 0 or AR2.recambio is null) ) IS NOT NULL) 
    group by PE.fechaProduccion , PE.numPedido  order by PE.fechaProduccion  asc "

            cmd = New SqlCommand(sel, con)

            con.Open()

            If cmd.ExecuteNonQuery Then

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

            End If

            con.Close()

            Return dt

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

    Public Function buscarConcepto(ByVal idConcepto As Integer) As Boolean

        Dim sel As String = "select (case when domesticos2 is null then 0 else domesticos2 end) as domesticos2 from ConceptosPedidos where idConcepto = " & idConcepto

        Dim con As New SqlConnection(sconexion)

        Try
            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim t As Integer = Convert.ToInt16(cmd.ExecuteScalar())

            con.Close()

            If t = 1 Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            Return False

        End Try

    End Function

    Public Function comprobarRecambios(ByVal idConcepto As Integer) As Boolean

        Dim sel As String = "select sum(C.Cantidad )as 'RECAMBIOS' from ConceptosPedidos as C 
left join Articulos as AR2 on AR2.idArticulo = C.idArticulo where AR2.Articulo not like 'CELULA%' 
and C.idConcepto = " & idConcepto & "  and AR2.recambio = 1"

        Dim con As New SqlConnection(sconexion)

        Try
            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim t As Integer = Convert.ToInt16(cmd.ExecuteScalar())

            con.Close()

            If t > 0 Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            con.Close()

            'MsgBox(ex.Message, MsgBoxStyle.Critical)

            Return False

        End Try


    End Function

    Public Function RecambiosHechos(ByVal idConcepto As Integer) As Integer

        Dim sel As String = "select sum(C.CantidadPreparada )as 'RECAMBIOS' from ConceptosPedidos as C 
left join Articulos as AR2 on AR2.idArticulo = C.idArticulo where AR2.Articulo not like 'CELULA%' 
and C.idConcepto = " & idConcepto & "  and AR2.recambio = 1"

        Dim con As New SqlConnection(sconexion)

        Try
            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim t As Integer = Convert.ToInt16(cmd.ExecuteScalar())

            con.Close()

            If t > 0 Then

                Return t

            Else

                Return t

            End If

        Catch ex As Exception

            con.Close()

            Return 0

        End Try

    End Function

    'RAMOS
    Public Function actualizarConcepto(ByVal found As Boolean, ByVal idConcepto As Integer) As Boolean

        Dim sel As String

        Dim dom As Integer

        If found Then

            dom = 0

        Else

            dom = 1

        End If

        sel = "update ConceptosPedidos set domesticos2 = " & dom & " WHERE idConcepto = " & idConcepto

        Using con As New SqlConnection(sconexion)

            Try
                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())

                con.Close()

                If t = 1 Then

                    Return True

                Else

                    Return False

                End If

            Catch ex As Exception

                con.Close()

                MsgBox(ex.Message)

                Return False

            End Try

        End Using

    End Function

#Region "ORDEN"
    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer

        Try

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "Select max(Orden) from ConceptosPedidos where numPedido = " & inumDoc

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

        Dim sel As String = "Update ConceptosPedidos set Orden = Orden + 1 where idConcepto = " & iidConcepto

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

        Dim sel As String = "Update ConceptosPedidos set Orden = Orden - 1 where idConcepto = " & iidConcepto

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

            Dim sel As String = "select (select count(idConcepto) from ConceptosPedidos where numPedido = @numPedido and Orden = 0) + "

            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosPedidos where numPedido = @numPedido Group by Orden order by count(idConcepto) desc)"

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.AddWithValue("numPedido", inumDoc)

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

            sel = "Select idConcepto from ConceptosPedidos where numPedido = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)

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

        Dim sel As String = "Update ConceptosPedidos set ORden = @Orden where idConcepto = @idConcepto "

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

#Region "EXPORTAR VISTA SIMPLE"

    Public Function conceptosPedidosDesglose(ByVal lvExportacion As ListView, ByVal numPedido As Integer, ByVal numPedidoAx As String,
                                             ByVal fechaPrevista As Date, ByVal fechaProduccion As Date, ByVal Cliente As String)

        Dim con As New SqlConnection(CadenaConexion)

        Try

            Dim selConceptos As String = "Select '" & numPedidoAx & "' PEDIDO_AX,AR.codArticulo 'ARTÍCULO', '" & Format(fechaPrevista, "MM-dd-yyyy") & "' FECHA_PREVISTA, '" & Format(fechaProduccion, "MM-dd-yyyy") & "' FECHA_PRODUCCIÓN,
            '" & Cliente & "' CLIENTE,convert (varchar(20),(CO.Cantidad -
 case when (select count(*) from equiposProduccion where idProduccion in (select idProduccion from conceptosProduccion CPR 
 left join conceptosPedidos CP on CP.idConcepto = CPR.idConceptoPedido
 left join Articulos AR on AR.idArticulo = CP.idArticulo
 where CP.idConcepto = CO.idConcepto and AR.recambio=0)) = 0 then CO.CantidadPreparada else 
(select count(*) from equiposProduccion where idProduccion in (select idProduccion from conceptosProduccion CPR 
 left join conceptosPedidos CP on CP.idConcepto = CPR.idConceptoPedido
 left join Articulos AR on AR.idArticulo = CP.idArticulo
 where CP.idConcepto = CO.idConcepto and AR.recambio = 0 and fechaPicking is not null)) end))
CANTIDAD_PENDIENTE FROM ConceptosPedidos as CO 
Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo  
Left join Estados ON Estados.idEstado = CO.idEstado  
left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo  
left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA  
left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo  
left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad  
left outer join ConceptosOfertas as C1 ON C1.idConcepto = CO.idConceptoOferta  
left outer join ConceptosProformas as C2 ON C2.idConcepto = CO.idConceptoProforma  
WHERE CO.numPedido = " & numPedido & "  Order By  CO.Orden ASC "

            Dim da As New SqlDataAdapter(selConceptos, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                If lvExportacion.Columns.Count = 0 Then

                    For Each columna In dt.Columns

                        lvExportacion.Columns.Add(columna.ToString)

                    Next

                End If

                For Each row In dt.Rows

                    With lvExportacion.Items.Add(row(0))

                        For i = 1 To dt.Columns.Count - 1

                            .subItems.Add(If(row(i) Is DBNull.Value, "", row(i)))

                        Next

                    End With

                Next

            End If

            Return True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        Return False

    End Function

#End Region

End Class

'CONCEPTOS PEDIDOS SEL
'            Dim selConceptos As String = "Select '" & row(1) & "' PEDIDO_AX, '" & row(2) & "' FECHA_PREVISTA, '" & row(3) & "' FECHA_PRODUCCIÓN,
' '" & row(4) & "' CLIENTE , AR.codArticulo 'CÓDIGO ARTÍCULO', AR.Articulo 'ARTÍCULO',
'CONVERT (VARCHAR(10), CONVERT(INT ,CO.CantidadPreparada )) + ' / ' +CONVERT (VARCHAR(10), CONVERT(INT ,CO.Cantidad)) 'CANTIDAD',
'CASE WHEN
'(CO.CantidadPreparada < CO.Cantidad and CO.CantidadPreparada > 0)
' and
'(((CO.domesticos2 = 1 OR AR.domesticos2 = 1 )  and (select COUNT(*) from preparacionPedido 
'LEFT JOIN lineasProduccion LP ON LP.idLinea = preparacionPedido .idlinea 
'where preparacionPedido.activo = 1 AND preparacionPedido.idlinea = 4 and numpedido = " & row(0) & ") = 0)
'or
'(((CO.domesticos2 = 0 OR CO.domesticos2 IS NULL ) and (AR.domesticos2 = 0 OR AR.domesticos2 IS NULL)) and  
'(select COUNT(*) from preparacionPedido 
'LEFT JOIN lineasProduccion LP ON LP.idLinea = preparacionPedido .idlinea 
'where preparacionPedido.activo = 1 AND preparacionPedido.idlinea <> 4 and numpedido = " & row(0) & ") = 0))
'then 'PARCIAL' 
'WHEN 
'((select idproduccion from ConceptosProduccion where idConceptoPedido = CO.idConcepto ) > 0 )
'AND
'(((CO.domesticos2 = 1 OR AR.domesticos2 = 1 ) and (select COUNT(*) from preparacionPedido 
'LEFT JOIN lineasProduccion LP ON LP.idLinea = preparacionPedido .idlinea 
'where preparacionPedido.activo = 1 AND preparacionPedido.idlinea = 4 and numpedido = " & row(0) & ") > 0 )
'or
'(((CO.domesticos2 = 0 OR CO.domesticos2 IS NULL ) and (AR.domesticos2 = 0 OR AR.domesticos2 IS NULL)) and  
'(select COUNT(*) from preparacionPedido 
'LEFT JOIN lineasProduccion LP ON LP.idLinea = preparacionPedido .idlinea 
'where preparacionPedido.activo = 1 AND preparacionPedido.idlinea <> 4 and numpedido = " & row(0) & ") > 0))
'AND CO.CantidadPreparada <> CO.Cantidad
'then 'PRODUCCIÓN'
'WHEN CO.CantidadPreparada = CO.Cantidad THEN 'PRODUCIDO'
'ELSE
''PENDIENTE' end 'ESTADO PRODUCCIÓN',
'CASE WHEN CO.domesticos2 = 1 Or AR.domesticos2 = 1 THEN 'SÍ' ELSE '' END 'DOMÉSTICOS 2'
'FROM ConceptosPedidos as CO 
'Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo  
'Left join Estados ON Estados.idEstado = CO.idEstado  
'left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo  
'left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA  
'left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo  
'left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad  
'left outer join ConceptosOfertas as C1 ON C1.idConcepto = CO.idConceptoOferta  
'left outer join ConceptosProformas as C2 ON C2.idConcepto = CO.idConceptoProforma  
'WHERE CO.numPedido = " & row(0) & " Order By  CO.Orden ASC "


'            Dim sePedidosl As String = "select
'PE.numPedido as 'NÚM. PEDIDO',  -- NÚMERO PEDIDO SUGAR
'CONVERT ( VARCHAR(10),PE.Fecha, 103) as 'FECHA PEDIDO', -- FECHA PEDIDO
'PE.referenciaCliente 'PEDIDO AX', -- PEDIDO AX
'case when PE.RoturaStock IS null then '' else 'SÍ' end  'ROTURA DE STOCK', -- TIENE ROTURA DE STOCK
'CONVERT ( VARCHAR(10),PE.FechaEntrega, 103) as 'FECHA PREVISTA',  --FECHA PREVISTA DE ENTREGA
'CONVERT ( VARCHAR(10),PE.fechaProduccion, 103) as 'FECHA PRODUCCIÓN',  --FECHA DE PRODUCCIÓN
'CLI.NombreComercial as 'CLIENTE', 
'PE.Notas 'NOTA', 
'CASE WHEN (select Estado from Estados where idEstado = PE.idEstado) = 'PREPARADO' THEN 'PRODUCCIÓN' ELSE (select Estado from Estados where idEstado = PE.idEstado) END as 'ESTADO', 

'--CELULAS
'convert(varchar (10),(select  count(*)
'from ConceptosPedidos as C 
'left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
'left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
'left join Articulos as AR2 on AR2.idArticulo = cp.idArticulo 
'left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
'where (AR2.Articulo like 'CELULA%' or STA.SubTipoArticulo = 'EQUIPO') and C.numPedido = PE.numPedido  and ep.EtiquetaFinalImpresa = 1))
'+ ' / ' +
'convert(varchar (10),(select convert(int, sum(C.Cantidad )) from ConceptosPedidos as C 
'left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
'Left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
'where (AR2.Articulo like 'CELULA%' or STA.SubTipoArticulo = 'EQUIPO') 
'and C.numPedido = PE.numPedido))
' as 'CÉLULAS',

'-- DOMESTICO
'convert(varchar (10),(select COUNT(*) from conceptospedidos DOC
'left join Articulos art on art.idArticulo = doc.idArticulo
'left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
'LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
'left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
'left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
'where numPedido = PE.numPedido and CP.idProduccion is not null and EP.numSerie <> 0 and ep.EtiquetaFinalImpresa = 1 and (doc.domesticos2 = 0 or doc.domesticos2 is null) and ta.TipoArticulo = 'DOMESTICO' ))
'+ ' / ' +
'convert(varchar (10),(select convert(int, sum(C.Cantidad ))
'from ConceptosPedidos as C 
'left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
'left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
'left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
'where AR2.Articulo not like 'CELULA%' 
'and C.numPedido = PE.numPedido 
'and TA.TipoArticulo = 'DOMESTICO'  
'and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
'and (AR2.recambio = 0 or AR2.recambio is null) 
'and (c.domesticos2=0 or c.domesticos2 is null)))
' as 'DOMÉSTICOS',

'--DOMÉSTICOS 2

'convert(varchar (10),(select count (*) from conceptospedidos DOC
'left join Articulos art on art.idArticulo = doc.idArticulo
'left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
'LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
'left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
'left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
'where numPedido = PE.numPedido  and CP.idProduccion is not null and EP.numSerie <> 0 and ep.EtiquetaFinalImpresa = 1 and doc.domesticos2 = 1 and ta.TipoArticulo = 'DOMESTICO'))
'+ ' / ' +
'convert(varchar (10),(convert (varchar(10),(select convert(int, sum(C.Cantidad ))
'from ConceptosPedidos as C 
'left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
'left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
'left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
'where AR2.Articulo not like 'CELULA%' 
'and C.numPedido = PE.numPedido 
'and TA.TipoArticulo = 'DOMESTICO'  
'and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
'and (AR2.recambio = 0 or AR2.recambio is null) and C.domesticos2 = 1))))
' as 'DOMÉSTICOS 2',

'--INDUSTRIALES 
'convert(varchar (10),(select count(*)
'from ConceptosPedidos as C 
' left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
' left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
' left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
' left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
' left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
' where AR2.Articulo not like 'CELULA%' 
' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'INDUSTRIAL' 
' and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
' and (AR2.recambio = 0 or AR2.recambio is null) and ep.EtiquetaFinalImpresa = 1 ))
'+ ' / ' +
'convert(varchar (10),(select  convert(int, sum(C.Cantidad )) from ConceptosPedidos as C 
'left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
'left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
'left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
'where AR2.Articulo not like 'CELULA%' 
'and C.numPedido = PE.numPedido 
'and TA.TipoArticulo = 'INDUSTRIAL' 
'and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
'and (AR2.recambio = 0 or AR2.recambio is null) ))
' as 'INDUSTRIAL',

'--REPARACIONES
'case when (select COUNT(*) 
'from ConceptosPedidos  as CP 
'left join ConceptosProformas as CPF on CPF.idConcepto = CP.idConceptoProforma 
'where CP.numpedido = PE.numpedido 
'and ((select COUNT(*) from Reparaciones as REP where REP.numPedido = PE.numpedido) > 0 or 
'(Select COUNT(*) From conceptosPedidos 
'left join ConceptosProformas on conceptosProformas.idConcepto = ConceptosPedidos.idConceptoProforma  
'where ConceptosPedidos.numPedido = PE.numpedido 
'and (select COUNT(*) from Reparaciones where Reparaciones.numProforma  = ConceptosProformas.numProforma ) > 0 ) > 0)) = 0 then '' else 'SÍ' end as 'REPARACIÓN',

'--RECAMBIOS
'(select convert(int, sum(C.Cantidad )) from ConceptosPedidos as C 
'left join Articulos as AR2 on AR2.idArticulo = C.idArticulo where AR2.Articulo not like 'CELULA%' 
'and C.numPedido = PE.numPedido and AR2.recambio = 1) as 'RECAMBIOS'


' from pedidos as PE 
'LEFT JOIN ConceptosPedidos as CP on CP.numPedido = PE.numPedido 
'LEFT JOIN Clientes as CLI on CLI.idCliente = PE.idCliente 
'where  PE.idEstado in (65,6,58,21 ) and  PE.Banulado = 0  
'and (select COUNT(*) from ConceptosPedidos as CP2 
'left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo   
'left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo 
' where CP2.numPedido = PE.numpedido and (ART2.codArticulo = 'REPARACION' or ART2.codArticulo is null)) < 
' (select COUNT(*) from  ConceptosPedidos as CP2 
' left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo  
' left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo   
' where CP2.numPedido = PE.numpedido )
' group by PE.numPedido, PE.FechaEntrega, PE.Fecha, CLI.NombreComercial, PE.Notas, PE.Prioridad, PE.idEstado, PE.fechaProduccion, PE.RoturaStock, PE.referenciaCliente 
' order by  PE.Prioridad asc , PE.FechaEntrega asc  "

'    Public Function exportarVistaSimple(ByVal lvExportacion As ListView)

'        lvExportacion.Font = New Font("CENTURY GOTHIC", 10, FontStyle.Bold)

'        Dim con As New SqlConnection(CadenaConexion)

'        Try

'#Region "Consulta pedidos vista simple"

'            Dim selPedidos As String = "select
'PE.numPedido as 'NUM. PEDIDO',  -- NÚMERO PEDIDO SUGAR
'PE.referenciaCliente 'PEDIDO AX', -- PEDIDO AX
'CONVERT ( VARCHAR(10),PE.FechaEntrega, 103) as 'FECHA PREVISTA',  --FECHA PREVISTA DE ENTREGA
'CONVERT ( VARCHAR(10),PE.fechaProduccion, 103) as 'FECHA PRODUCCIÓN',  --FECHA DE PRODUCCIÓN
'CLI.NombreComercial as 'CLIENTE'
'from pedidos as PE 
'LEFT JOIN ConceptosPedidos as CP on CP.numPedido = PE.numPedido 
'LEFT JOIN Clientes as CLI on CLI.idCliente = PE.idCliente 
'where  PE.idEstado in (65,6,58,21 ) and  PE.Banulado = 0  
'and (select COUNT(*) from ConceptosPedidos as CP2 
'left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo   
'left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo 
' where CP2.numPedido = PE.numpedido and (ART2.codArticulo = 'REPARACION' or ART2.codArticulo is null)) < 
' (select COUNT(*) from  ConceptosPedidos as CP2 
' left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo  
' left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo   
' where CP2.numPedido = PE.numpedido )
' group by PE.numPedido, PE.FechaEntrega, PE.Fecha, CLI.NombreComercial, PE.Notas, PE.Prioridad, PE.idEstado, PE.fechaProduccion, PE.RoturaStock, PE.referenciaCliente 
' order by  PE.Prioridad asc , PE.FechaEntrega asc 
'"

'#End Region

'            Dim da As New SqlDataAdapter(selPedidos, con)

'            Dim dtPedido As New DataTable

'            da.Fill(dtPedido)

'            If dtPedido.Rows.Count > 0 Then

'                For Each row In dtPedido.Rows

'                    conceptosPedidosDesglose(lvExportacion, row)

'                Next

'            End If

'            Return True

'        Catch ex As Exception

'            MsgBox(ex.Message & vbCrLf & "NO SE HA PODIDO EXPORTAR LA VISTA SIMPLE, CONTACTE CON EL ADMINISTRADOR.", MsgBoxStyle.Critical)

'        End Try

'        Return False

'    End Function

