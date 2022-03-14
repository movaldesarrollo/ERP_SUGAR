Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesConceptosAlbaranes


    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Private funcEQ As New FuncionesEquiposProduccion

    Private sel0 As String = " Select CO.*, C1.numPedido, codArticulo, Articulo, AR.idTipoArticulo, TipoArticulo, AR.idSubTipoArticulo, SubTipoArticulo, AR.idUnidad, TipoUnidad,TipoIVA, TipoRecargoEq,  Estado, AR.idFamilia, Familia, AR.idsubFamilia, subFamilia " _
          & " FROM ConceptosAlbaranes as CO Left Join Articulos as AR ON AR.idArticulo = CO.idArticulo " _
          & " Left join Estados ON Estados.idEstado = CO.idEstado " _
          & " left outer join TiposArticulo ON TiposArticulo.idTipoArticulo = AR.idTipoArticulo " _
          & " left outer join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA " _
          & " left outer join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = AR.idsubTipoArticulo " _
          & " left outer join Familias ON Familias.idFamilia = AR.idFamilia " _
          & " left outer join subFamilias ON subFamilias.idsubFamilia = AR.idsubFamilia " _
          & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
          & " left join ConceptosPedidos as C1 ON C1.idConcepto = CO.idConceptoPedido "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoAlbaran)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numAlbaran, idConcepto ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoAlbaran)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoAlbaran
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoAlbaran
        Dim dts As New DatosConceptoAlbaran
        dts.gidConcepto = linea("idConcepto")
        dts.gnumAlbaran = If(linea("NumAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gnumDevolucion = If(linea("numDevolucion") Is DBNull.Value, 0, linea("numDevolucion"))
        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
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
        dts.gidConceptoPedido = If(linea("idConceptoPedido") Is DBNull.Value, 0, linea("idConceptoPedido"))
        dts.gnumsSerie = If(linea("numsSerie") Is DBNull.Value, "", linea("numsSerie"))
        dts.gidConceptoPedidoProv = If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))

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
        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gidSubFamilia = If(linea("idSubFamilia") Is DBNull.Value, 0, linea("idSubFamilia"))
        dts.gSubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))

        Return dts

    End Function


    Public Function Mostrar(ByVal inumAlbaran As Integer) As List(Of DatosConceptoAlbaran)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            
            sel = sel0 & " WHERE CO.numAlbaran = " & inumAlbaran & " Order By  Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoAlbaran)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosConceptoAlbaran
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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

    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoAlbaran
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
          
            sel = sel0 & " WHERE CO.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoAlbaran
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


  

   
    Public Function idEstado(ByVal iidConcepto As Long) As Integer
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstado from ConceptosAlbaranes where idConcepto = " & iidConcepto
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

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select CP.numPedido from ConceptosAlbaranes as CA left join ConceptosPedidos as CP ON CP.idConcepto = CA.idConceptoPedido where CA.idConcepto = " & iidConcepto
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

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosAlbaranes left join estados on Estados.idEstado = ConceptosAlbaranes.idEstado where idConcepto = " & iidConcepto
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

    Public Function TodosTraspasados(ByVal inumAlbaran As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosAlbaranes left join estados on Estados.idEstado = ConceptosAlbaranes.idEstado where Traspasado = 0 and numAlbaran = " & inumAlbaran
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



    Public Function insertar(ByVal dts As DatosConceptoAlbaran) As Long 'Inserta una nueva Albaran y devuelve el nº


        Dim sel As String
        sel = "insert into ConceptosAlbaranes (numAlbaran, numDevolucion, numFactura, codArticuloCli, ArticuloCli, RefCliente, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArtCli, idConceptoPedido, numsSerie, idConceptoPedidoProv, idArticuloProv ) "
        sel = sel & " values (@numAlbaran, @numDevolucion, @numFactura, @codArticuloCli, @ArticuloCli, @RefCliente, @idArticulo, @Cantidad, @PVPUnitario, @idTipoIVA, @Descuento, @PrecioNetoUnitario, @Orden, @idEstado, @idArtCli, @idConceptoPedido, @numsSerie, @idConceptoPedidoProv, @idArticuloProv ) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numDevolucion", dts.gnumDevolucion)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("codArticuloCli", If(dts.gcodArticuloCli = "", dts.gcodArticulo, dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("RefCliente", dts.gRefCliente)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gnumAlbaran) + 1) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArtCli", dts.gidArtCli)
                cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)
                cmd.Parameters.AddWithValue("numsSerie", dts.gnumsSerie)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)

                con.Open()
                Dim t As Long = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosConceptoAlbaran) As Boolean   '

        Dim sel As String
        sel = "update ConceptosAlbaranes set numAlbaran = @numAlbaran, numDevolucion = @numDevolucion, numFactura = @numFactura, codArticuloCli = @codArticuloCli, ArticuloCli = @ArticuloCli, RefCliente = @RefCliente,"
        sel = sel & "  idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario, idEstado = @idEstado, idArtCli = @idArtCli, idConceptoPedido = @idConceptoPedido, numsSerie = @numsSerie, idConceptoPedidoProv = @idConceptoPedidoProv, idArticuloProv = @idArticuloProv  "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numDevolucion", dts.gnumDevolucion)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
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
                cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)
                cmd.Parameters.AddWithValue("numsSerie", dts.gnumsSerie)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)

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


        Dim sel As String = "Update ConceptosAlbaranes set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
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


    Public Function CambiarTipoIVA(ByVal inumAlbaran As Integer, ByVal iidTipoIVA As Integer) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosAlbaranes set idTipoIVA = @idTipoIVA where numAlbaran = @numAlbaran "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numAlbaran", inumAlbaran)
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



    Public Function CambiarnumsSerie(ByVal iidConcepto As Integer, ByVal numsSerie As String) As Boolean


        Dim sel As String = "Update ConceptosAlbaranes set NumsSerie = '" & numsSerie & "' where idConcepto = " & iidConcepto
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


    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosAlbaranes set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
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
        If Aplicacion = "DEVOLUCION" Then
            sel = "Update ConceptosAlbaranes set numDevolucion = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "FACTURA" Then
            sel = "Update ConceptosAlbaranes set numFactura = " & num & " where idConcepto = " & iidConcepto
        End If
        If Aplicacion = "ALBARAN" Then
            sel = "Update ConceptosAlbaranes set numAlbaran = " & num & " where idConcepto = " & iidConcepto
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



    Public Function borrarAlbaran(ByVal inumAlbaran As Integer) As Boolean  ' Borra una cabecera de DevolucionProv



        Dim sel As String = "delete from ConceptosAlbaranes where numAlbaran = " & inumAlbaran
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

    Public Function borrar(ByVal iidConcepto As Integer, ByVal inumDoc As Integer) As Boolean  ' Borra una cabecera de DevolucionProv
        Dim sel As String = "delete from ConceptosAlbaranes where idConcepto = " & iidConcepto
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
                Return False
            End Try
        End Using

    End Function



#Region "ORDEN"

    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try
            Using con As New SqlConnection(sconexion)
                Dim sel As String
                sel = "Select max(Orden) from ConceptosAlbaranes where numAlbaran = " & inumDoc
                Dim cmd As New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            End Using
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

        Dim sel As String = "Update ConceptosAlbaranes set Orden = Orden + 1 where idConcepto = " & iidConcepto
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

        Dim sel As String = "Update ConceptosAlbaranes set Orden = Orden - 1 where idConcepto = " & iidConcepto
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
            Dim sel As String = "select (select count(idConcepto) from ConceptosAlbaranes where numAlbaran = @numAlbaran and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosAlbaranes where numAlbaran = @numAlbaran Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("numAlbaran", inumDoc)
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
        'Renumeramos según el idConcepto cuando la numeración por campo Orden no es válida
        'Si es válida renumeramos para eliminar saltos y normalizar
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConcepto from ConceptosAlbaranes where numAlbaran = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
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
        Dim sel As String = "Update ConceptosAlbaranes set ORden = @Orden where idConcepto = @idConcepto "
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

    Public Function Orden(ByVal iidConcepto As Long) As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Orden from ConceptosAlbaranes where idConcepto = " & iidConcepto
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



#End Region





End Class
