Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesConceptosReparaciones


    Inherits conexion
    Dim cmd As SqlCommand


    Dim sel0 As String = " Select CO.*,codArticulo, Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad,TipoIVA, Estado " _
            & " FROM ConceptosReparaciones as CO Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo " _
            & " Left join Estados ON Estados.idEstado = CO.idEstado " _
            & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
            & " left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA " _
            & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numReparacion, idConcepto ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoReparacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                'Dim dts As DatosConceptoReparacion
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


    Private Function CargarLinea(ByVal linea As DataRow)
        Dim dts As New DatosConceptoReparacion
        dts.gidConcepto = linea("idConcepto")
        dts.gnumReparacion = If(linea("NumReparacion") Is DBNull.Value, 0, linea("numReparacion"))
        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
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
        dts.gnumOferta = If(linea("numOferta") Is DBNull.Value, 0, linea("numOferta"))

        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        Return dts
    End Function

    Public Function Mostrar(ByVal inumReparacion As Integer) As List(Of DatosConceptoReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.numReparacion = " & inumReparacion & " Order By  idConcepto "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoReparacion)
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





    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE CO.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoReparacion
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


    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosReparaciones where numReparacion = " & inumDoc
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


    Public Function Traspasada(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosReparaciones left join estados on Estados.idEstado = ConceptosReparaciones.idEstado where idConcepto = " & iidConcepto
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

    Public Function TodosTraspasados(ByVal inumReparacion As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosReparaciones left join estados on Estados.idEstado = ConceptosReparaciones.idEstado where Traspasado = 0 and numReparacion = " & inumReparacion
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




    Public Function insertar(ByVal dts As DatosConceptoReparacion) As Integer 'Inserta una nueva Reparacion y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ConceptosReparaciones (numReparacion, numPedido, numProforma, codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli, numOferta ) "
        sel = sel & " values (@numReparacion, @numPedido,@numProforma,  @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli, @numOferta ) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
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
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
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

    Public Function actualizar(ByVal dts As DatosConceptoReparacion) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosReparaciones set numReparacion = @numReparacion, numPedido = @numPedido, numProforma = @numProforma, codArticuloCli = @codArticuloCli, ArticuloCli = @ArticuloCli, RefCliente = @RefCliente,"
        sel = sel & "  idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario, Orden = @Orden, idEstado = @idEstado, idArtCli = @idArtCli, numOferta = @numOferta "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
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
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
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

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosReparaciones set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
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

    Public Function CambiarTipoIVA(ByVal inumReparacion As Integer, ByVal iidTipoIVA As Integer) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosReparaciones set idTipoIVA = @idTipoIVA where numReparacion = @numReparacion "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)
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
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosReparaciones set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
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

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = ""
        If Aplicacion = "PEDIDO" Then
            sel = "Update ConceptosReparaciones set numPedido = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "PROFORMA" Then
            sel = "Update ConceptosReparaciones set numProforma = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "OFERTA" Then
            sel = "Update ConceptosReparaciones set numOferta = " & num & " where idConcepto = " & iidConcepto
        End If

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



    Public Function borrarReparacion(ByVal inumReparacion As Integer) As Boolean  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosReparaciones where numReparacion = " & inumReparacion
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

    Public Function borrar(ByVal iidConcepto As Integer) As Boolean  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosReparaciones where idConcepto = " & iidConcepto
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
