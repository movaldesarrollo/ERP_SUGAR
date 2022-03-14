Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesConceptosOfertas


    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()



    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoOferta)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, codArticulo, Articulo, idTipoArticulo, TipoArticulo, idSubTipoArticulo, SubTipoArticulo, idUnidad, TipoUnidad, codMoneda, Divisa, Simbolo, Estado "
            sel = sel & " FROM ConceptosOfertas as CO Left Join Articulos ON Articulos.idArticulo = CO.idArticulo "
            sel = sel & " Left join Estados ON Estados.idEstado = CO.idEstado "
            sel = sel & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo "
            sel = sel & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad "
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numOferta, idConcepto ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoOferta)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoOferta
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoOferta
                        dts.gidConcepto = linea("idConcepto")
                        dts.gnumOferta = If(linea("NumOferta") Is DBNull.Value, 0, linea("numOferta"))
                        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
                        dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
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
                        dts.gnumReparacion = If(linea("numReparacion") Is DBNull.Value, 0, linea("numReparacion"))

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
                        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))

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




    Public Function Mostrar(ByVal inumOferta As Integer) As List(Of DatosConceptoOferta)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, codArticulo, Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad,TipoIVA, TipoRecargoEq,  Estado "
            sel = sel & " FROM ConceptosOfertas as CO Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo "
            sel = sel & " Left join Estados ON Estados.idEstado = CO.idEstado "
            sel = sel & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
            sel = sel & " left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo "
            sel = sel & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "
            sel = sel & " WHERE numOFerta = " & inumOferta & " Order By Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoOferta)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoOferta
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = New DatosConceptoOferta
                        dts.gidConcepto = linea("idConcepto")
                        dts.gnumOferta = If(linea("NumOferta") Is DBNull.Value, 0, linea("numOferta"))
                        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
                        dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
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
                        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gnumReparacion = If(linea("numReparacion") Is DBNull.Value, 0, linea("numReparacion"))

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
                        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
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





    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoOferta
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, codArticulo, Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad,TipoIVA, TipoRecargoEq,  Estado "
            sel = sel & " FROM ConceptosOfertas as CO Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo "
            sel = sel & " Left join Estados ON Estados.idEstado = CO.idEstado "
            sel = sel & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo "
            sel = sel & " left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo "
            sel = sel & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "
            sel = sel & " WHERE idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoOferta
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
                        dts.gidConcepto = linea("idConcepto")
                        dts.gnumOferta = If(linea("NumOferta") Is DBNull.Value, 0, linea("numOferta"))
                        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
                        dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
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
                        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gnumReparacion = If(linea("numReparacion") Is DBNull.Value, 0, linea("numReparacion"))

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
                        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
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




    Public Function insertar(ByVal dts As DatosConceptoOferta) As Integer 'Inserta una nueva Oferta y devuelve el nº

        Dim sel As String
        sel = "insert into ConceptosOfertas (numOferta, numPedido, numProforma, codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli, numReparacion ) "
        sel = sel & " values (@numOferta, @numPedido, @numProforma, @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli, @numReparacion ) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
                cmd.Parameters.AddWithValue("codArticuloCli", If(dts.gcodArticuloCli = "", If(dts.gidArtCli = 0, dts.gcodArticulo, ""), dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("RefCliente", dts.gRefCliente)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gnumOferta + 1)) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
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

    Public Function actualizar(ByVal dts As DatosConceptoOferta) As Boolean   '

        Dim sel As String
        sel = "update ConceptosOfertas set numOferta = @numOferta, numPedido = @numPedido, numProforma = @numProforma, codArticuloCli = @codArticuloCli, ArticuloCli = @ArticuloCli, RefCliente = @RefCliente,"
        sel = sel & "  idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario, idEstado = @idEstado, idArtCli = @idArtCli, numReparacion = @numReparacion  "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
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
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
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
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


    Public Function Traspasada(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosOfertas left join estados on Estados.idEstado = ConceptosOfertas.idEstado where idConcepto = " & iidConcepto
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

    Public Function TodosTraspasados(ByVal inumOferta As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosOfertas left join estados on Estados.idEstado = ConceptosOfertas.idEstado where Traspasado = 0 and numOferta = " & inumOferta
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

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sel As String = "Update ConceptosOfertas set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
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

    Public Function CambiarTipoIVA(ByVal inumOferta As Integer, ByVal iidTipoIVA As Integer) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosOfertas set idTipoIVA = @idTipoIVA where numOferta = @numOferta "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numOferta", inumOferta)
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


    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosOfertas set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
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


        Dim sel As String = ""
        If Aplicacion = "PEDIDO" Then
            sel = "Update ConceptosOfertas set numPedido = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "PROFORMA" Then
            sel = "Update ConceptosOfertas set numProforma = " & num & " where idConcepto = " & iidConcepto
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





    Public Function borrarOferta(ByVal inumOferta As Integer) As Boolean  ' Borra una cabecera de PedidoProv

        Dim sel As String = "delete from ConceptosOfertas where numOferta = " & inumOferta
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

    Public Function borrar(ByVal iidConcepto As Integer, ByVal inumDoc As Integer) As Boolean  ' Borra una cabecera de PedidoProv

        Dim sel As String = "delete from ConceptosOfertas where idConcepto = " & iidConcepto
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



#Region "ORDEN"
    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosOfertas where numOferta = " & inumDoc
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

        Dim sel As String = "Update ConceptosOfertas set Orden = Orden + 1 where idConcepto = " & iidConcepto
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

        Dim sel As String = "Update ConceptosOfertas set Orden = Orden - 1 where idConcepto = " & iidConcepto
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
            Dim sel As String = "select (select count(idConcepto) from ConceptosOFertas where numOferta = @numOFerta and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosOfertas where numOferta = @numOferta Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("numOferta", inumDoc)
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
            sel = "Select idConcepto from ConceptosOfertas where numOferta = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
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
        Dim sel As String = "Update ConceptosOfertas set ORden = @Orden where idConcepto = @idConcepto "
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
