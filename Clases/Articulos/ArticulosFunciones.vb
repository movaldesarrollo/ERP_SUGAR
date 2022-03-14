Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesArticulos

    Inherits conexion
    Dim cmd As SqlCommand
    'Private funcAP As New FuncionesArticuloPrecio
    Private funcMo As New FuncionesMoneda

    Private sel0 As String = "SELECT  Articulos.*, TA.TipoArticulo,TA.Descuento1, TA.DEscuento2, SubTipoArticulo, Familia, subFamilia, Seccion, TipoCompra, Almacen, NombreComercial as Proveedor, TipoUnidad, " _
             & " case when Escandallo = 1 then (Select count(idEquipo) From EquiposProduccion as EQ left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion Where EQ.idArticulo = ARticulos.idArticulo and idConceptoPedido = 0 ) " _
             & " else (Select sum(Cantidad) From Stock Where Stock.idArticulo = Articulos.idArticulo) end as CantidadStock, AP.idArticuloProv, AP.codArticuloProv, recambio  " _
             & " FROM Articulos " _
             & " LEFT JOIN TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad " _
             & " LEFT outer JOIN TiposArticulo AS TA ON TA.idTipoArticulo = Articulos.idTipoArticulo " _
             & " LEFT outer join SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo " _
             & " LEFT outer JOIN Familias ON Familias.idFamilia = Articulos.idFamilia " _
             & " LEFT outer join SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia " _
             & " LEFT Outer JOIN Secciones ON Secciones.idSeccion = Articulos.idSeccion " _
             & " LEFT outer JOIN Proveedores ON Proveedores.idProveedor = Articulos.idProveedor " _
             & " LEFT outer JOIN Almacenes ON Almacenes.idAlmacen = Articulos.idAlmacen " _
             & " LEFT OUTER JOIN Articulos_Proveedor as AP ON AP.idArticulo = Articulos.idArticulo and AP.idProveedor = Articulos.idProveedor And AP.Activo = 1 " _
             & " LEFT OUTER JOIN TiposCompra ON TiposCompra.idTipoCompra = Articulos.idTipoCompra "

#Region "CONSULTA"

    Public Function Mostrar(ByVal SoloActivos As Boolean, Optional ByVal idarticulo As Integer = 0) As List(Of DatosArticulo)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            If idarticulo <> 0 Then

                sel = sel0 & If(SoloActivos, " WHERE Articulos.Activo = 1 and Articulos.idArticulo = " & idarticulo & " ", "") & " Order By Articulos.articulo "

            Else

                sel = sel0 & If(SoloActivos, " WHERE Articulos.Activo = 1 ", "") & " Order By Articulos.Articulo "

            End If

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosArticulo
                Dim lista As New List(Of DatosArticulo)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)

                        'Los precios los extraemos de la tabla Articulos_Precios
                        dts.gPrecioUnitarioC = 0 'If(linea("PrecioUnitarioC") Is DBNull.Value, 0, linea("PrecioUnitarioC"))
                        dts.gcodMonedaC = "EU" 'If(linea("codMonedaC") Is DBNull.Value, "EU", linea("codMonedaC"))
                        dts.gFechaPrecioC = Now.Date 'If(linea("FechaPrecioC") Is DBNull.Value, Now.Date, linea("FechaPrecioC"))
                        dts.gidProveedorPrecio = 0 'If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConceptoPedidoProv = 0 'If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
                        dts.gPrecioUnitarioV = 0 'If(linea("PrecioUnitarioV") Is DBNull.Value, 0, linea("PrecioUnitarioV"))
                        dts.gPrecioOpcion = 0 'If(linea("PrecioOpcion") Is DBNull.Value, 0, linea("PrecioOpcion"))
                        dts.gcodMonedaV = "EU" 'If(linea("codMonedaV") Is DBNull.Value, "EU", linea("codMonedaV"))
                        dts.gFechaPrecioV = Now.Date 'If(linea("FechaPrecioV") Is DBNull.Value, Now.Date, linea("FechaPrecioV"))
                        dts.gSimboloC = "€" 'If(linea("SimboloC") Is DBNull.Value, "€", linea("SimboloC"))
                        dts.gSimboloV = "€" 'If(linea("SimboloV") Is DBNull.Value, "€", linea("SimboloV"))


                        Dim funcAP As New FuncionesArticuloPrecio
                        Dim listaP As List(Of DatosArticuloPrecio) = funcAP.Mostrar(dts.gidArticulo, True)
                        For Each dtsP As DatosArticuloPrecio In listaP
                            Select Case dtsP.gTipoPrecio
                                Case "C"
                                    dts.gPrecioUnitarioC = dtsP.gPrecio
                                    dts.gFechaPrecioC = dtsP.gFechaPrecio
                                    dts.gcodMonedaC = dtsP.gcodMoneda
                                    dts.gSimboloC = dtsP.gSimbolo
                                    dts.gidProveedorPrecio = dtsP.gidProveedorPrecio
                                    dts.gidConceptoPedidoProv = dtsP.gidConcepto
                                Case "V"
                                    dts.gPrecioUnitarioV = dtsP.gPrecio
                                    dts.gFechaPrecioV = dtsP.gFechaPrecio
                                    dts.gcodMonedaV = dtsP.gcodMoneda
                                    dts.gSimboloV = dtsP.gSimbolo
                                Case "O"
                                    dts.gPrecioOpcion = dtsP.gPrecio
                            End Select
                        Next


                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Private Function CargarLinea(ByVal linea As DataRow) As DatosArticulo
        Dim dts As New DatosArticulo
        dts.gidArticulo = linea("idArticulo")
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gArticuloEN = If(linea("ArticuloEN") Is DBNull.Value, "", linea("ArticuloEN"))
        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
        dts.gDescripcionEN = If(linea("DescripcionEN") Is DBNull.Value, "", linea("DescripcionEN"))
        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))
        dts.gidSubFamilia = If(linea("idSubFamilia") Is DBNull.Value, 0, linea("idSubFamilia"))
        dts.gidTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gStockMinimo = If(linea("StockMinimo") Is DBNull.Value, 0, linea("StockMinimo"))
        dts.gComprable = If(linea("Comprable") Is DBNull.Value, False, linea("Comprable"))
        dts.gVendible = If(linea("Vendible") Is DBNull.Value, False, linea("Vendible"))
        dts.gDomesticos2 = If(linea("Domesticos2") Is DBNull.Value, False, linea("Domesticos2")) 'RAMOS
        dts.gMateriaPrima = If(linea("MateriaPrima") Is DBNull.Value, False, linea("MateriaPrima"))
        dts.gsubEnsamblado = If(linea("subEnsamblado") Is DBNull.Value, False, linea("subEnsamblado"))
        dts.gOpcion = If(linea("Opcion") Is DBNull.Value, False, linea("Opcion"))
        dts.gEscandallo = If(linea("Escandallo") Is DBNull.Value, False, linea("Escandallo"))
        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))
        dts.gidAlmacen = If(linea("idAlmacen") Is DBNull.Value, 0, linea("idAlmacen"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gKilosBrutos = If(linea("KilosBrutos") Is DBNull.Value, 0, linea("KilosBrutos"))
        dts.gKilosNetos = If(linea("KilosNetos") Is DBNull.Value, 0, linea("KilosNetos"))
        dts.gBultos = If(linea("Bultos") Is DBNull.Value, 0, linea("Bultos"))
        dts.gAlto = If(linea("Alto") Is DBNull.Value, 0, linea("Alto"))
        dts.gAncho = If(linea("Ancho") Is DBNull.Value, 0, linea("Ancho"))
        dts.gFondo = If(linea("Fondo") Is DBNull.Value, 0, linea("Fondo"))
        dts.gVolumen = If(linea("Volumen") Is DBNull.Value, 0, linea("Volumen"))
        dts.gProduccionSeparada = If(linea("ProduccionSeparada") Is DBNull.Value, False, linea("ProduccionSeparada"))
        dts.gConNumSerie = If(linea("ConNumSerie") Is DBNull.Value, False, linea("ConNumSerie"))
        dts.gConNumSerie2 = If(linea("ConNumSerie2") Is DBNull.Value, False, linea("ConNumSerie2"))
        dts.gConVersiones = If(linea("ConVersiones") Is DBNull.Value, False, linea("ConVersiones"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gSubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))
        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))
        dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))
        dts.gcodArticuloProv = If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv"))
        dts.gCantidadStock = If(linea("CantidadStock") Is DBNull.Value, 0, linea("CantidadStock"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gAlmacen = If(linea("Almacen") Is DBNull.Value, "", linea("Almacen"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gDescuento1 = If(linea("Descuento1") Is DBNull.Value, False, linea("Descuento1"))
        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, True, linea("Descuento2"))
        dts.gRecambio = If(linea("recambio") Is DBNull.Value, True, linea("recambio"))

        Return dts

    End Function

    Public Function Mostrar(ByVal iidTipoArticulo As Integer, ByVal iidSubTipoArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosArticulo)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticulo)
            Dim parametro As String = ""
            If iidTipoArticulo <> 0 Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.idTipoArticulo = " & iidTipoArticulo
            End If
            If iidSubTipoArticulo <> 0 Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.idsubTipoArticulo = " & iidSubTipoArticulo
            End If
            If SoloActivos Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.Activo = 1 "
            End If
            sel = sel0 & If(parametro = "", "", " WHERE " & parametro) & " Order By Articulo "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosArticulo

                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)

                        'Los precios los extraemos de la tabla Articulos_Precios
                        dts.gPrecioUnitarioC = 0 'If(linea("PrecioUnitarioC") Is DBNull.Value, 0, linea("PrecioUnitarioC"))
                        dts.gcodMonedaC = "EU" 'If(linea("codMonedaC") Is DBNull.Value, "EU", linea("codMonedaC"))
                        dts.gFechaPrecioC = Now.Date 'If(linea("FechaPrecioC") Is DBNull.Value, Now.Date, linea("FechaPrecioC"))
                        dts.gidProveedorPrecio = 0 'If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConceptoPedidoProv = 0 'If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
                        dts.gPrecioUnitarioV = 0 'If(linea("PrecioUnitarioV") Is DBNull.Value, 0, linea("PrecioUnitarioV"))
                        dts.gPrecioOpcion = 0 'If(linea("PrecioOpcion") Is DBNull.Value, 0, linea("PrecioOpcion"))
                        dts.gcodMonedaV = "EU" 'If(linea("codMonedaV") Is DBNull.Value, "EU", linea("codMonedaV"))
                        dts.gFechaPrecioV = Now.Date 'If(linea("FechaPrecioV") Is DBNull.Value, Now.Date, linea("FechaPrecioV"))
                        dts.gSimboloC = "€" 'If(linea("SimboloC") Is DBNull.Value, "€", linea("SimboloC"))
                        dts.gSimboloV = "€" 'If(linea("SimboloV") Is DBNull.Value, "€", linea("SimboloV"))

                        Dim funcAP As New FuncionesArticuloPrecio
                        Dim listaP As List(Of DatosArticuloPrecio) = funcAP.Mostrar(dts.gidArticulo, True)
                        For Each dtsP As DatosArticuloPrecio In listaP
                            Select Case dtsP.gTipoPrecio
                                Case "C"
                                    dts.gPrecioUnitarioC = dtsP.gPrecio
                                    dts.gFechaPrecioC = dtsP.gFechaPrecio
                                    dts.gcodMonedaC = dtsP.gcodMoneda
                                    dts.gSimboloC = dtsP.gSimbolo
                                    dts.gidProveedorPrecio = dtsP.gidProveedorPrecio
                                    dts.gidConceptoPedidoProv = dtsP.gidConcepto
                                Case "V"
                                    dts.gPrecioUnitarioV = dtsP.gPrecio
                                    dts.gFechaPrecioV = dtsP.gFechaPrecio
                                    dts.gcodMonedaV = dtsP.gcodMoneda
                                    dts.gSimboloV = dtsP.gSimbolo
                                Case "O"
                                    dts.gPrecioOpcion = dtsP.gPrecio
                            End Select
                        Next
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

    Public Function Mostrar1(ByVal iidArticulo As Integer) As DatosArticulo
        'Devuelve el registro del Artículo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = sel0 & " WHERE Articulos.idArticulo = " & iidArticulo

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New DatosArticulo
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Los precios los extraemos de la tabla Articulos_Precios
                        dts.gPrecioUnitarioC = 0 'If(linea("PrecioUnitarioC") Is DBNull.Value, 0, linea("PrecioUnitarioC"))
                        dts.gcodMonedaC = "EU" 'If(linea("codMonedaC") Is DBNull.Value, "EU", linea("codMonedaC"))
                        dts.gFechaPrecioC = Now.Date 'If(linea("FechaPrecioC") Is DBNull.Value, Now.Date, linea("FechaPrecioC"))
                        dts.gidProveedorPrecio = 0 'If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConceptoPedidoProv = 0 'If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
                        dts.gPrecioUnitarioV = 0 'If(linea("PrecioUnitarioV") Is DBNull.Value, 0, linea("PrecioUnitarioV"))
                        dts.gPrecioOpcion = 0 'If(linea("PrecioOpcion") Is DBNull.Value, 0, linea("PrecioOpcion"))
                        dts.gcodMonedaV = "EU" 'If(linea("codMonedaV") Is DBNull.Value, "EU", linea("codMonedaV"))
                        dts.gFechaPrecioV = Now.Date 'If(linea("FechaPrecioV") Is DBNull.Value, Now.Date, linea("FechaPrecioV"))
                        dts.gSimboloC = "€" 'If(linea("SimboloC") Is DBNull.Value, "€", linea("SimboloC"))
                        dts.gSimboloV = "€" 'If(linea("SimboloV") Is DBNull.Value, "€", linea("SimboloV"))

                        Dim funcAP As New FuncionesArticuloPrecio
                        Dim listaP As List(Of DatosArticuloPrecio) = funcAP.Mostrar(dts.gidArticulo, True)
                        For Each dtsP As DatosArticuloPrecio In listaP
                            Select Case dtsP.gTipoPrecio
                                Case "C"
                                    dts.gPrecioUnitarioC = dtsP.gPrecio
                                    dts.gFechaPrecioC = dtsP.gFechaPrecio
                                    dts.gcodMonedaC = dtsP.gcodMoneda
                                    dts.gSimboloC = dtsP.gSimbolo
                                    dts.gidProveedorPrecio = dtsP.gidProveedorPrecio
                                    dts.gidConceptoPedidoProv = dtsP.gidConcepto
                                Case "V"
                                    dts.gPrecioUnitarioV = dtsP.gPrecio
                                    dts.gFechaPrecioV = dtsP.gFechaPrecio
                                    dts.gcodMonedaV = dtsP.gcodMoneda
                                    dts.gSimboloV = dtsP.gSimbolo
                                Case "O"
                                    dts.gPrecioOpcion = dtsP.gPrecio
                            End Select
                        Next
                    End If

                Next
                Return dts
            Else
                con.Close()
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function Mostrar1V(ByVal iidArticulo As Integer, ByVal iidCliente As Integer, ByVal iidIdioma As Integer) As DatosArticulo
        'Devuelve el registro del Artículo, preparado para la venta a un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'Este sel es especial
            sel = "SELECT  Articulos.*, TA.TipoArticulo,TA.Descuento1,TA.Descuento2, SubTipoArticulo, Familia, subFamilia, Seccion, TipoCompra, Almacen, NombreComercial as Proveedor, "
            sel = sel & " TipoUnidad, AP.idArticuloProv, AP.codArticuloProv, "
            sel = sel & " case when Escandallo = 1 then (select count(idEquipo) from EquiposProduccion left join ConceptosProduccion ON ConceptosProduccion.idProduccion = EquiposProduccion.idProduccion "
            sel = sel & " where EquiposProduccion.idArticulo = Articulos.idArticulo and idConceptoPedido = 0 ) "
            sel = sel & " else (Select sum(Cantidad) From Stock Where Stock.idArticulo = Articulos.idArticulo) end as CantidadStock,"
            sel = sel & " AC.codArticuloCli, AC.ArticuloCli, AC.Descuento, ACP.PrecioNetoUnitario, ACP.codMoneda as codMonedaC, APR.Descuento as DescuentoA, APR.Precio as PVP, APR.codMoneda as codMonedaA, "
            sel = sel & " APR.FechaPrecio as FechaPRecioA, ACP.Creacion as FechaPRecioC, AC.idArtCli "
            sel = sel & " FROM Articulos "
            sel = sel & " LEFT JOIN TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad "
            sel = sel & " LEFT OUTER JOIN ArticuloCliente as AC ON AC.idArticulo =Articulos.idArticulo AND AC.Activo = 1 AND AC.idCliente = " & iidCliente
            sel = sel & " LEFT OUTER JOIN ArticuloClientePrecios as ACP ON ACP.idArtCli = AC.idArtCli AND ACP.Activo = 1 "
            sel = sel & " LEFT outer JOIN TiposArticulo as TA ON TA.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " LEFT outer join SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo "
            sel = sel & " LEFT outer Join Articulos_Precios as APR ON APR.idArticulo = Articulos.idArticulo AND APR.Activo=1 AND TipoPrecio = 'V' "
            sel = sel & " LEFT outer JOIN Familias ON Familias.idFamilia = Articulos.idFamilia "
            sel = sel & " LEFT outer join SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia "
            sel = sel & " LEFT Outer JOIN Secciones ON Secciones.idSeccion = Articulos.idSeccion "
            sel = sel & " LEFT outer JOIN Proveedores ON Proveedores.idProveedor = Articulos.idProveedor "
            sel = sel & " LEFT outer JOIN Almacenes ON Almacenes.idAlmacen = Articulos.idAlmacen "
            sel = sel & " LEFT OUTER JOIN Articulos_Proveedor as AP ON AP.idArticulo = Articulos.idArticulo and AP.idProveedor = Articulos.idProveedor And AP.Activo = 1 "
            sel = sel & " LEFT OUTER JOIN TiposCompra ON TiposCompra.idTipoCompra = Articulos.idTipoCompra "
            sel = sel & " WHERE Articulos.idArticulo = " & iidArticulo

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim PVP As Double = 0
                Dim precioCliente As Double = 0
                Dim codMonedaA As String = "EU"
                Dim codMonedaC As String = "EU"
                Dim fechaPrecioA As Date
                Dim fechaPrecioC As Date
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New DatosArticulo
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)

                        PVP = If(linea("PVP") Is DBNull.Value, 0, linea("PVP"))
                        precioCliente = If(linea("PrecioNetoUnitario") Is DBNull.Value, -1, linea("PrecioNetoUnitario"))
                        codMonedaA = If(linea("codMonedaA") Is DBNull.Value, "EU", linea("codMonedaA"))
                        codMonedaC = If(linea("codMonedaC") Is DBNull.Value, "EU", linea("codMonedaC"))
                        fechaPrecioA = If(linea("fechaPrecioA") Is DBNull.Value, Now.Date, linea("fechaPrecioA"))
                        fechaPrecioC = If(linea("fechaPrecioC") Is DBNull.Value, Now.Date, linea("fechaPrecioC"))
                        dts.gPrecioArtCli = precioCliente 'If(precioCliente = -1, PVP, precioCliente)
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gcodMonedaV = If(precioCliente = -1, codMonedaA, codMonedaC)
                        dts.gFechaPrecioV = If(precioCliente = -1, fechaPrecioA, fechaPrecioC)
                        dts.gSimboloV = funcMo.CampoSimbolo(dts.gcodMonedaV)
                        dts.gPrecioUnitarioV = PVP
                        dts.gidArtCli = If(linea("idArtCli") Is DBNull.Value, 0, linea("idArtCli"))
                        dts.gCodArticuloCli = If(linea("CodArticuloCli") Is DBNull.Value, "", linea("CodArticuloCli"))
                        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        'Asignamos el nombre del artículo en función del idioma, aunque tiene prioridad el nombre personalizado
                        If iidIdioma = 1 Then
                            If dts.gArticuloCli = "" Then dts.gArticuloCli = dts.gArticulo
                        Else
                            If dts.gArticuloEN = "" Then
                                If dts.gArticuloCli = "" Then dts.gArticuloCli = dts.gArticulo
                            Else
                                If dts.gArticuloCli = "" Then dts.gArticuloCli = dts.gArticuloEN
                            End If
                        End If
                    End If
                Next
                Return dts
            Else
                con.Close()
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosArticulo)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'Aqui el select es especial, incluye subconsultas para los precios
            sel = "SELECT  Articulos.*, TA.TipoArticulo,TA.Descuento1,TA.Descuento2, SubTipoArticulo, Familia, subFamilia, Seccion, TipoCompra, Almacen, NombreComercial as Proveedor, TipoUnidad,"

            ''Sustituir la cantidadStock
            'sel = sel & " case when Escandallo = 1 then (select count(idEquipo) from EquiposProduccion left join ConceptosProduccion ON ConceptosProduccion.idProduccion = EquiposProduccion.idProduccion "
            'sel = sel & " where EquiposProduccion.idArticulo = Articulos.idArticulo and idConceptoPedido = 0 ) "
            'sel = sel & " else Stock  end  as CantidadStock, "
            sel = sel & "case when Escandallo = 1 then (select count(idEquipo) from EquiposProduccion "
            sel = sel & "left join ConceptosProduccion ON ConceptosProduccion.idProduccion = EquiposProduccion.idProduccion "
            sel = sel & "where EquiposProduccion.idArticulo = Articulos.idArticulo and idConceptoPedido = 0 )  else "
            sel = sel & "(select SUM (Stock.Cantidad ) from Stock where Stock.idArticulo = articulos.idArticulo group by stock .idArticulo  )"
            sel = sel & "end  as CantidadStock, "


            ' (Select sum(Cantidad) From Stock Where Stock.idArticulo = Articulos.idArticulo) end as CantidadStock, "
            ''/ELIMINAR PARA QUE VAYA MÁS RÁPIDO.
            'sel = sel & " case when Comprable = 1 then (select Top 1 AR.codMoneda from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'C') else 'EU' end as codMonedaC , "
            'sel = sel & " case when Comprable = 1 then (select Top 1 Simbolo from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'C') else '€' end as SimboloC , "
            'sel = sel & " case when Vendible = 1 then (select Top 1 AR.codMoneda  from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'V')else 'EU' end as codMonedaV , "
            'sel = sel & " case when Vendible = 1 then (select Top 1 Simbolo from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'V') else '€' end as SimboloV,  "
            ''/ELIMINAR PARA QUE VAYA MÁS RÁPIDO.
            'sel = sel & " case when Vendible = 1 then (select Top 1 Precio  from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'V' order by FechaPrecio DESC) else 0 end as PrecioV , "
            'sel = sel & " case when Comprable = 1 then (select Top 1 Precio from Articulos_Precios as AR left join Monedas ON Monedas.codMoneda = AR.codMoneda Where Activo = 1 and idArticulo = Articulos.idArticulo and TipoPrecio = 'C' order by FechaPrecio DESC ) else 0 end as PrecioC, "


            sel = sel & "  0 as idArticuloProv,'' as codArticuloProv"
            sel = sel & " FROM Articulos  "
            sel = sel & " LEFT JOIN TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad "
            sel = sel & " LEFT outer JOIN TiposArticulo as TA ON TA.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " LEFT outer join SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo "
            sel = sel & " LEFT outer JOIN Familias ON Familias.idFamilia = Articulos.idFamilia "
            sel = sel & " LEFT outer join SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia "
            sel = sel & " LEFT Outer JOIN Secciones ON Secciones.idSeccion = Articulos.idSeccion "
            sel = sel & " LEFT outer JOIN Proveedores ON Proveedores.idProveedor = Articulos.idProveedor "
            sel = sel & " LEFT outer JOIN Almacenes ON Almacenes.idAlmacen = Articulos.idAlmacen "
            sel = sel & " LEFT OUTER JOIN TiposCompra ON TiposCompra.idTipoCompra = Articulos.idTipoCompra "
            sel = sel & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden)

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosArticulo
                Dim lista As New List(Of DatosArticulo)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'dts.gPrecioUnitarioC = If(linea("PrecioC") Is DBNull.Value, 0, linea("PrecioC")) 'PRECIO DE COMPRA
                        'dts.gPrecioUnitarioV = If(linea("PrecioV") Is DBNull.Value, 0, linea("PrecioV")) 'PRECIO DE VENTA
                        dts.gidProveedorPrecio = 0 'If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConceptoPedidoProv = 0 'If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
                        dts.gPrecioOpcion = 0 'If(linea("PrecioO") Is DBNull.Value, 0, linea("PrecioO"))


                        'dts.gcodMonedaV = If(linea("codMonedaV") Is DBNull.Value, "EU", linea("codMonedaV"))
                        'dts.gFechaPrecioV = Now.Date 'If(linea("FechaPrecioV") Is DBNull.Value, Now.Date, linea("FechaPrecioV"))
                        'dts.gSimboloV = If(linea("SimboloV") Is DBNull.Value, If(dts.gcodMonedaV = "EU", "€", dts.gcodMonedaV), linea("SimboloV"))

                        ' ''/ELIMINAR PARA QUE VAYA MÁS RÁPIDO.
                        'dts.gSimboloC = If(linea("SimboloC") Is DBNull.Value, If(dts.gcodMonedaC = "EU", "€", dts.gcodMonedaC), linea("SimboloC"))
                        'dts.gcodMonedaC = If(linea("codMonedaC") Is DBNull.Value, "EU", linea("codMonedaC"))
                        'dts.gFechaPrecioC = Now.Date 'If(linea("FechaPrecioC") Is DBNull.Value, Now.Date, linea("FechaPrecioC"))
                        ' ''/ELIMINAR PARA QUE VAYA MÁS RÁPIDO.
                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Versiones(ByVal iidArticulo) As List(Of Integer)
        'Devuelve la lista de versiones de escandallo un artículo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select VersionEscandallo from Articulos as AR left Join Escandallos as ES ON ES.idArticulo = AR.idArticulo where AR.idArticulo = " & iidArticulo & " order by VersionEscandallo DESC"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("VersionEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("VersionEscandallo"))
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

    Public Function Listar(ByVal Seleccion As String) As List(Of IDComboBox3)
        'Devuelve la lista de valores del campo de una determinada TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo from Articulos Where Activo = 1"
            Dim lista As New List(Of IDComboBox3)
            Select Case Seleccion
                Case "ESCANDALLO"
                    sel = sel & " AND (select count(*) from ConceptosEscandallos  AS CE where CE.idArticulo = articulos.idArticulo ) > 0 " 'AND (select count(idEscandallo) from Escandallos Where idArticulo = Articulos.idArticulo and Activo = 1)>0 "
                    sel = sel & " Order by Articulo ASC "
                Case "MATERIAPRIMA"
                    sel = sel & " AND MateriaPrima = 1 "
                    sel = sel & " Order by Articulo ASC "
                Case "OPCION"
                    sel = sel & " AND Opcion = 1 "
                    sel = sel & " Order by Articulo ASC "
                Case "NUEVOESC"
                    sel = sel & " AND Escandallo =1 And idArticulo not in (select idArticulo from Escandallos Where Activo=1) "
                    sel = sel & " Order by Articulo ASC "
                Case "VENDIBLE"
                    sel = sel & " AND Vendible = 1 "
                    sel = sel & " Order by Articulo ASC "
                Case "BASE"
                    sel = "Select distinct AR.idArticulo, codArticulo, Articulo from Escandallos as ES  left join Articulos as AR ON ES.idArticulo = AR.idArticulo "
                    sel = sel & " Where AR.Activo = 1 AND ES.Activo = 1  AND idArticuloBase=0 "
                    sel = sel & " Order by Articulo ASC "
                Case "COMPRABLE"
                    sel = sel & " AND Comprable = 1 "
                    sel = sel & " Order by Articulo ASC "
                Case "TODOS"
                    sel = sel & " Order by Articulo ASC "
                Case Is <> ""
                    If IsNumeric(Seleccion) Then
                        sel = sel & " AND idArticulo = " & Seleccion
                    Else
                        Return lista
                    End If
                Case Else
                    Return lista
            End Select

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
                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", Trim(linea("codArticulo"))), If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")), linea("idArticulo")))
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

    Public Function ListarCompuestos(ByVal iidArticuloBase As Integer) As List(Of IDComboBox3)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo from Articulos Where Activo = 1 "
            sel = sel & " AND idArticulo in (select distinct idArticulo from Escandallos where idArticuloBase = " & iidArticuloBase & ")"
            sel = sel & " Order By Articulo ASC "
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
                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", Trim(linea("codArticulo"))), If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")), linea("idArticulo")))
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

    Public Function ListarArticulosQueContienen(ByVal iidArticulo As Integer) As List(Of IDComboBox3)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo from Articulos Where Activo = 1 "
            sel = sel & " AND idArticulo in (select distinct ES.idArticulo from Escandallos as ES left join ConceptosEscandallos as CE ON ES.idEscandallo = CE.idEscandallo where CE.idArticulo = " & iidArticulo & ")"
            sel = sel & " Order By Articulo ASC "
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
                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", Trim(linea("codArticulo"))), If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")), linea("idArticulo")))
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

    Public Function Buscar(ByVal Busqueda As String, ByVal Orden As String) As List(Of IDComboBox3)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo from Articulos left join subFamilias ON SubFamilias.idsubFamilia = Articulos.idsubFamilia "

            sel = sel & " Where Articulos.Activo = 1 " & Busqueda & If(Orden = "", " Order By Articulo ", " Order By " & Orden)

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
                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo")), If(linea("Articulo") Is DBNull.Value, "", linea("Articulo")), linea("idArticulo")))
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

    Public Function BuscarAC(ByVal Busqueda As String, ByVal iidCliente As Integer, ByVal Orden As String, ByVal idIdioma As String) As List(Of IDComboBox3)
        'Devuelve la lista de artículos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo,ArticuloEN, (Select Top 1 ArticuloCli from ArticuloCliente Where Activo = 1 and idArticulo = Articulos.idArticulo and idCliente = " & iidCliente & ") as ArticuloCli from Articulos "

            sel = sel & " Where Activo = 1 " & Busqueda & If(Orden = "", " Order By ArticuloCli ", " Order By " & Orden)

            Dim lista As New List(Of IDComboBox3)

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim Articulo As String
                For Each linea As DataRow In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        'Selecionamos el nombre personalizado del cliente para el artículo,si no tiene, seleccionamos el nombre genérico
                        Articulo = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        If Articulo = "" Then
                            Articulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                            If idIdioma = 1 Then 'Castellano
                            Else
                                'Si el idioma es inglés tomamos el nombre en inglés si existe, si no el castellano
                                If linea("ArticuloEN") Is DBNull.Value Then
                                Else
                                    Articulo = If(linea("ArticuloEN") = "", Articulo, linea("ArticuloEN"))
                                End If

                            End If
                        End If

                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo")), Articulo, linea("idArticulo")))
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

    Public Function BuscarAP(ByVal Busqueda As String, ByVal iidProveedor As Integer, ByVal Orden As String, ByVal idIdioma As String) As List(Of IDComboBox3)
        'Devuelve la lista de artículos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select idArticulo, codArticulo, Articulo,ArticuloEN, (Select Top 1 Nombre from Articulos_Proveedor Where Activo = 1 and idArticulo = Articulos.idArticulo and idProveedor = " & iidProveedor & ") as ArticuloProv from Articulos "

            sel = sel & " Where Activo = 1 " & Busqueda & If(Orden = "", " Order By ArticuloProv ", " Order By " & Orden)

            Dim lista As New List(Of IDComboBox3)

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim Articulo As String
                For Each linea As DataRow In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        'Selecionamos el nombre personalizado del cliente para el artículo,si no tiene, seleccionamos el nombre genérico
                        Articulo = If(linea("ArticuloProv") Is DBNull.Value, "", linea("ArticuloProv"))
                        If Articulo = "" Then
                            Articulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                            If idIdioma = 1 Then 'Castellano
                            Else
                                'Si el idioma es inglés tomamos el nombre en inglés si existe, si no el castellano
                                If linea("ArticuloEN") Is DBNull.Value Then
                                Else
                                    Articulo = If(linea("ArticuloEN") = "", Articulo, linea("ArticuloEN"))
                                End If

                            End If
                        End If

                        lista.Add(New IDComboBox3(If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo")), Articulo, linea("idArticulo")))
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

    Public Function ListarxTipoArticulo(ByVal iidTipoArticulo As Integer, ByVal iidSubTipoArticulo As Integer) As DataTable
        'Devuelve la lista de valores del campo de una determinada TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidTipoArticulo = 0 And iidSubTipoArticulo = 0 Then
                sel = "SELECT idArticulo, codArticulo, Articulo FROM Articulos where Activo=1  ORDER BY Articulo "
            End If

            If iidTipoArticulo <> 0 And iidSubTipoArticulo = 0 Then
                sel = "SELECT idArticulo, codArticulo, Articulo FROM Articulos  WHERE idTipoArticulo = " & iidTipoArticulo & " AND Activo = 1 ORDER BY Articulo "
            End If

            If iidTipoArticulo = 0 And iidTipoArticulo <> 0 Then
                sel = "SELECT idArticulo, codArticulo, Articulo FROM Articulos  WHERE idSubTipoArticulo = " & iidSubTipoArticulo & "  AND Activo = 1 ORDER BY Articulo "
            End If

            If iidTipoArticulo <> 0 And iidTipoArticulo <> 0 Then
                sel = "SELECT idArticulo, codArticulo, Articulo FROM Articulos  WHERE idTipoArticulo = " & iidTipoArticulo & "  AND Activo = 1 AND idSubTipoArticulo = " & iidSubTipoArticulo & " ORDER BY Articulo "
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function NuevoidArticulo() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim cmd As SqlCommand = New SqlCommand("SELECT max(idArticulo) FROM Articulos", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 1
            Else
                Return 1 + CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try


    End Function

    Public Function TipoArticulo(ByVal iidArticulo As Integer) As String
        'Devuelve la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT TipoArticulo FROM Articulos LEFT JOIN TiposArticulo ON Articulos.idTipoArticulo = TiposArticulo.idTipoArticulo WHERE  Activo = 1 AND idArticulo = " & iidArticulo, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Then
                Return ""
            Else
                Return resultado
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SubTipoArticulo(ByVal iidArticulo As Integer) As String
        'Devuelve la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT SubTipoArticulo FROM Articulos LEFT JOIN SubTiposArticulo ON Articulos.idSubTipoArticulo = SubTiposArticulo.idSubTipoArticulo WHERE   Activo = 1 AND idArticulo = " & iidArticulo, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Then
                Return ""
            Else
                Return resultado
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idTipoUnidad(ByVal iidArticulo As Integer) As Integer
        'Devuelve la Tipo de unidad
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT idUnidad FROM Articulos  WHERE  idArticulo = " & iidArticulo, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Then
                Return 0
            Else
                Return CInt(resultado)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TipoUnidad(ByVal iidArticulo As Integer) As String
        'Devuelve la Tipo de unidad
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT TipoUnidad FROM Articulos LEFT JOIN TiposUnidad ON Articulos.idUnidad = TiposUnidad.idTipoUnidad WHERE  idArticulo = " & iidArticulo, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Then
                Return ""
            Else
                Return resultado
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Articulo(ByVal iidArticulo As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT Articulo FROM Articulos WHERE  idArticulo = " & iidArticulo & " AND Activo = 1 "
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Articulo(ByVal codArticulo As String) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If codArticulo = "" Then
                Return ""
            Else
                Dim sel As String = " SELECT Articulo FROM Articulos WHERE  codArticulo = '" & codArticulo & "' AND Activo = 1 "
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(ob)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function conNumSerie(ByVal iidArticulo As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT conNumSerie FROM Articulos WHERE  idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return False
                Else
                    Return CBool(ob)
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Nombre(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidArticulo <> 0 Then
                If iidProveedor > 0 Then
                    sel = " SELECT Nombre FROM Articulos_Proveedor WHERE  idArticulo = " & iidArticulo & " AND idProveedor = " & iidProveedor & "  and Activo = 1 "
                Else
                    sel = " SELECT Articulo FROM Articulos WHERE  idArticulo = " & iidArticulo & " and Activo = 1 "

                End If
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function codArticulo(ByVal iidArticulo As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidArticulo <> 0 Then
                sel = " SELECT codArticulo FROM Articulos WHERE  idArticulo = " & iidArticulo & " and Activo = 1 "
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function idArticulo(ByVal codArticulo As String) As Integer
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If codArticulo = "" Then
                Return 0
            Else
                codArticulo = UCase(Replace(codArticulo, " ", ""))
                sel = " SELECT Top 1 idArticulo FROM Articulos WHERE  upper(Replace(codArticulo,' ','')) like '" & codArticulo & "' "
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CInt(ob)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Domestico_Industrial(ByVal iidArticulo As Integer) As Char
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidArticulo <> 0 Then
                sel = " SELECT Case when Descuento2 = 1 Or Descuento1 Is null then 'I' else 'D' end as D_I FROM Articulos left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo WHERE  idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return "D"
                Else
                    Return CChar(ob)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Domestico_Industrial_Nada(ByVal iidArticulo As Integer) As Char
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidArticulo <> 0 Then
                sel = " declare @suma int; set suma@ = ("
                sel = sel & " select count(idArticulo) from Articulos as AR "
                sel = sel & " left join Escandallos ON Escandallos.idArticulo = AR.idArticulo"
                sel = sel & " left join ConceptosEscandallos as CE ON CE.idEscandallo = Escandallos.idEscandallo"
                sel = sel & " left join Articulos as AE ON AE.idArticulo = CE.idArticulo "
                sel = sel & " where AE.ProduccionSeparada=1 and AR.MateriaPRima =0 and  AR.idArticulo = " & iidArticulo & "); "
                sel = sel & " set @suma = @suma + ("
                sel = sel & " select distinct AR.idArticulo from Articulos as AR "
                sel = sel & " left join Escandallos as ES ON ES.idArticulo = AR.idArticulo"
                sel = sel & " where ES.idArticuloBase in("
                sel = sel & " select distinct AR0.idArticulo from Articulos as AR0 "
                sel = sel & " left join Escandallos ON Escandallos.idArticulo = AR0.idArticulo"
                sel = sel & " left join ConceptosEscandallos as CE ON CE.idEscandallo = Escandallos.idEscandallo"
                sel = sel & " left join Articulos as AE ON AE.idArticulo = CE.idArticulo where AE.ProduccionSeparada=1 and AR0.MateriaPRima =0) and  AR.idArticulo = " & iidArticulo & "); "
                sel = sel & " select case when @suma = 0 then 'N' else"
                sel = sel & "(SELECT Case when Descuento2 = 1 Or Descuento1 Is null then 'I' else 'D' end as D_I FROM Articulos left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo WHERE  idArticulo = " & iidArticulo & ") end;"

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return "N"
                Else
                    Return CChar(ob)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function idSeccion(ByVal iidArticulo As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idSeccion from Articulos where idArticulo = " & iidArticulo
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

    Public Function Seccion(ByVal iidArticulo As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Seccion from Articulos left join Secciones On Secciones.idSeccion = Articulos.idSeccion where idArticulo = " & iidArticulo
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Escandallo(ByVal iidArticulo As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Escandallo from Articulos where idArticulo = " & iidArticulo
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

    Public Function conVersiones(ByVal iidArticulo As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select conVersiones from Articulos where idArticulo = " & iidArticulo
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

    Public Function Vista(ByVal iidArticulo As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Vista from Articulos left join Secciones On Secciones.idSeccion = Articulos.idSeccion where idArticulo = " & iidArticulo
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function EnUso(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si el artículo está en uso en cualquier documento de compra, venta, escandallo, concepto de escandallo, articulobase de escandallo, stock, ArticuloCliente y ArtículoPRoveedor.
        'En el caso del stock sólo detectaremos movimientos de cantidad<>0 porque al menos existirá el alta.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "declare @idArticulo int;"
            sel = sel & "set @idArticulo = " & iidArticulo & ";"
            sel = sel & " select (select count(idArticulo) from ConceptosOfertas where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ConceptosProformas where idArticulo = @idArticulo) + "
            sel = sel & " (select count(idArticulo) from ConceptosPedidos where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ConceptosAlbaranes where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ConceptosFacturas where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ConceptosPedidosProv where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ConceptosEscandallos where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from Stock where Cantidad <> 0 and idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from Escandallos where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticuloBase) from Escandallos where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from ArticuloCliente where idArticulo = @idArticulo) +"
            sel = sel & " (select count(idArticulo) from Articulos_Proveedor where idArticulo = @idArticulo)"
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Proveedor(ByVal iidArticulo As Integer) As String
        'Devuelve el proveedor del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT nombreComercial FROM Proveedores Left JOIN Articulos ON Articulos.idProveedor = Proveedores.idProveedor WHERE   Articulos.Activo = 1 AND idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function idProveedor(ByVal iidArticulo As Integer) As Integer
        'Devuelve el proveedor del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT idProveedor FROM Articulos  WHERE   idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CInt(ob)
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function PrecioCoste(ByVal iidArticulo As Integer) As Double
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT Precio FROM Articulos_Precios  WHERE  Activo = 1 AND TipoPrecio = 'C' AND idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return 0
                Else
                    Return CDbl(ob)
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function PrecioVenta(ByVal iidArticulo As Integer) As Double
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> 0 Then
                Dim sel As String = " SELECT Precio FROM Articulos_Precios  WHERE  Activo = 1 AND TipoPrecio = 'V' AND idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return 0
                Else
                    Return CDbl(ob)
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function PrecioOpcion(ByVal iidArticulo As Integer) As Double
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo <> "" Then
                Dim sel As String = " SELECT Precio FROM Articulos_Precios  WHERE  Activo = 1 AND TipoPrecio = 'O' AND idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return PrecioVenta(iidArticulo)
                Else
                    If CDbl(ob) = 0 Then
                        Return PrecioVenta(iidArticulo)
                    Else
                        Return CDbl(ob)
                    End If
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Articulos", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM Articulos WHERE  " & busqueda, con)

            End If
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

    Public Function ProductoExiste(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Articulos con ese código
        If iidArticulo = 0 Then
            Return False
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = " SELECT idArticulo FROM Articulos WHERE idArticulo = " & iidArticulo
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Dim resultado As String = cmd.ExecuteScalar
                    con.Close()
                    Return (resultado = iidArticulo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                Finally
                    desconectado()
                End Try

            End Using

        End If

    End Function

    Public Function codArticuloExiste(ByVal iidArticulo As Integer, ByVal scodArticulo As String) As Boolean
        'Nos dice si existe una entrada activa el la tabla Articulos con ese código
        If scodArticulo = "" Then
            Return False
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = " SELECT idArticulo FROM Articulos WHERE Activo = 1 and codArticulo ='" & scodArticulo & If(iidArticulo = 0, "' ", "' and idArticulo <> " & iidArticulo)
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Dim o As Object = cmd.ExecuteScalar
                    con.Close()
                    If o Is DBNull.Value Or o Is Nothing Then
                        Return False
                    Else
                        Return True
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                Finally
                    desconectado()
                End Try
            End Using
        End If

    End Function

    Public Function PrimerAño() As Integer
        'Devuelve el valor del primer año de las Articulos
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Articulos ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return 0
            Else
                Return Year(Resultado)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PrimeraFecha() As Date
        'Devuelve el valor del primer año de las Articulos
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Articulos ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return Nothing
            Else
                Return Resultado
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Documentos(ByVal iidArticulo As Integer) As DataTable
        'Devuelve la lista de documentos asociados a la idArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT Prod_Documentos.codDocumento, Documentos.*, TiposDocumento.TipoDoc FROM (Prod_Documentos LEFT JOIN Documentos ON Documentos.codDocumento = Prod_Documentos.codDocumento) LEFT JOIN TiposDocumento ON TiposDocumento.IDTipo = Documentos.IdTipo WHERE idArticulo =  '" & iidArticulo, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                con.Close()
                Return dt
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function DocExiste(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Boolean
        ' Indica si existe la relación 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select codDocumento FROM Prod_Documentos WHERE (idArticulo = " & iidArticulo & "' AND codDocumento = " & vcodDocumento & ")"

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteScalar = 0 Then
                con.Close()
                Return False
            Else
                con.Close()
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Existe(ByVal codigoArticulo As String) As Boolean
        ' Indica si existe la relación 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select count(*) FROM articulos WHERE idArticulo = '" & codigoArticulo & "'"

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteScalar = 0 Then
                con.Close()
                Return False
            Else
                con.Close()
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function CargarDatos() As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        Dim sel As String
        Dim dr As SqlDataReader
        Try
            'Sal08 + bio08-2014----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL08%' or AR.codarticulo like 'BIO 08%') and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal08_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal08_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal08_2014.Text = 0
            End If
            con.Close()

            'Sal08 + bio08-2015----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL08%' or AR.codarticulo like 'BIO 08%') and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal08_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal08_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal08_2015.Text = 0
            End If
            con.Close()
            'Sal08 + bio08-2016----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL08%' or AR.codarticulo like 'BIO 08%') and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal08_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal08_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal08_2016.Text = 0
            End If
            con.Close()

            'Sal16-2014----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL16%' or AR.codArticulo like 'BIO 16%')and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal16_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal16_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal16_2014.Text = 0
            End If
            con.Close()

            'Sal16-2015----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL16%' or AR.codArticulo like 'BIO 16%')and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal16_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal16_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal16_2015.Text = 0
            End If
            con.Close()

            'Sal16-2016----------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL16%' or AR.codArticulo like 'BIO 16%')and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal16_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal16_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal16_2016.Text = 0
            End If
            con.Close()

            'Sal22-2014---------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL22%' or AR.codArticulo like 'BIO 22%')and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal22_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal22_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal22_2014.Text = 0
            End If
            con.Close()

            'Sal22-2015---------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL22%' or AR.codArticulo like 'BIO 22%')and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal22_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal22_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal22_2015.Text = 0
            End If
            con.Close()

            'Sal22-2016---------------------------------------------------------------------
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL22%' or AR.codArticulo like 'BIO 22%')and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal22_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal22_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal22_2016.Text = 0
            End If
            con.Close()

            'Sal33-2014----------------------------------------------------------------
            sel = "select sum(CF.cantidad)from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL33%' or AR.codArticulo like 'BIO 33%') and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal33_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal33_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal33_2014.Text = 0
            End If
            con.Close()

            'Sal33-2015----------------------------------------------------------------
            sel = "select sum(CF.cantidad)from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL33%' or AR.codArticulo like 'BIO 33%') and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal33_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal33_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal33_2015.Text = 0
            End If
            con.Close()

            'Sal33-2016----------------------------------------------------------------
            sel = "select sum(CF.cantidad)from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'SAL33%' or AR.codArticulo like 'BIO 33%') and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txSal33_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txSal33_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txSal33_2016.Text = 0
            End If
            con.Close()

            'HD1-2014
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD1%' or  AR.codArticulo like 'OX 1%') and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD1_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD1_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD1_2014.Text = 0
            End If
            con.Close()

            'HD1-2015
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD1%' or  AR.codArticulo like 'OX 1%') and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD1_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD1_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD1_2015.Text = 0
            End If
            con.Close()

            'HD1-2016
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD1%' or  AR.codArticulo like 'OX 1%') and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD1_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD1_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD1_2016.Text = 0
            End If
            con.Close()

            'HD2-2014
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD2%' or AR.codArticulo like 'OX 2%' ) and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD2_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD2_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD2_2014.Text = 0
            End If
            con.Close()
            'HD2-2015
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD2%' or AR.codArticulo like 'OX 2%' ) and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD2_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD2_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD2_2015.Text = 0
            End If
            con.Close()
            'HD2-2016
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where (AR.codArticulo like 'HD2%' or AR.codArticulo like 'OX 2%' ) and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txHD2_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txHD2_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txHD2_2016.Text = 0
            End If
            con.Close()

            'CEL08
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC08%' and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel08_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel08_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel08_2014.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC08%' and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel08_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel08_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel08_2015.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC08%' and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel08_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel08_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel08_2016.Text = 0
            End If
            con.Close()

            'CEL16
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC16%' and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel16_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel16_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel08_2016.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC16%' and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel16_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel16_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel16_2015.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC16%' and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel16_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel16_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel16_2016.Text = 0
            End If
            con.Close()

            'CEL22
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC22%' and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel22_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel22_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel22_2016.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC22%' and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel22_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel22_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel22_2015.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC22%' and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel22_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel22_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel22_2016.Text = 0
            End If
            con.Close()

            'CEL33
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC33%' and year(fecha)=2014 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel33_2014.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel33_2014.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel33_2016.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC33%' and year(fecha)=2015 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel33_2015.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel33_2015.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel33_2015.Text = 0
            End If
            con.Close()
            sel = "select sum(CF.cantidad) from articulos as AR " & _
                    "left join conceptosfacturas as CF on CF.idarticulo = AR.idarticulo " & _
                    "left join facturas as PE on PE.numfactura = CF.numfactura" & _
                    " where AR.codArticulo like 'RC33%' and year(fecha)=2016 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                Do While dr.Read()
                    If Not IsDBNull(dr(0)) Then
                        ArcticulosPersonalizado.txCel33_2016.Text = FormatNumber(dr(0), 0)
                    Else
                        ArcticulosPersonalizado.txCel33_2016.Text = 0
                    End If
                Loop
            Else
                ArcticulosPersonalizado.txCel33_2016.Text = 0
            End If
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            Return False
        End Try
    End Function

#End Region

#Region "INSERTAR"

    Public Function insertar(ByVal dts As DatosArticulo) As Integer
        If codArticuloExiste(dts.gidArticulo, dts.gcodArticulo) Then
            MsgBox("Ya existe un artículo con las mismas opciones con el código " & dts.gcodArticulo)
        Else
            dts.gidArticulo = NuevoidArticulo()
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            Using con As New SqlConnection(sconexion)
                Try
                    sel = "insert into Articulos ( idArticulo, codArticulo, Articulo, ArticuloEN, Descripcion, DescripcionEN, FechaAlta, FechaBaja, Activo, idTipoArticulo, idSubTipoArticulo, idFamilia, idsubFamilia, idTipoCompra, idUnidad, Observaciones, StockMinimo, Comprable, Vendible, MateriaPrima, subEnsamblado, Opcion, Escandallo, idSeccion, idAlmacen, idProveedor, KilosNetos, KilosBrutos, Bultos, Alto, Ancho, Fondo, Volumen, ProduccionSeparada, ConNumSerie, ConNumSerie2, ConVersiones, idCreador, Creacion, recambio, domesticos2) "
                    sel = sel & " values (@idArticulo, @codArticulo, @Articulo, @ArticuloEN, @Descripcion, @DescripcionEN, @FechaAlta, @FechaBaja, @Activo,@idTipoArticulo,@idSubTipoArticulo,@idFamilia,@idsubFamilia,@idTipoCompra,@idUnidad,@Observaciones,@StockMinimo,@Comprable,@Vendible,@MateriaPrima,@subEnsamblado,@Opcion,@Escandallo,@idSeccion,@idAlmacen,@idProveedor,@KilosNetos,@KilosBrutos,@Bultos,@Alto,@Ancho,@Fondo,@Volumen,@ProduccionSeparada,@ConNumSerie,@ConNumSerie2,@ConVersiones,@idCreador,@Creacion, @recambio, @domesticos2) select @@identity "

                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("codArticulo", dts.gcodArticulo)
                    cmd.Parameters.AddWithValue("Articulo", dts.gArticulo)
                    cmd.Parameters.AddWithValue("ArticuloEN", dts.gArticuloEN)
                    cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                    cmd.Parameters.AddWithValue("DescripcionEN", dts.gDescripcionEN)
                    cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                    cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("idTipoArticulo", dts.gidTipoArticulo)
                    cmd.Parameters.AddWithValue("idSubTipoArticulo", dts.gidSubTipoArticulo)
                    cmd.Parameters.AddWithValue("idFamilia", dts.gidFamilia)
                    cmd.Parameters.AddWithValue("idSubFamilia", dts.gidSubFamilia)
                    cmd.Parameters.AddWithValue("idTipoCompra", dts.gidTipoCompra)
                    cmd.Parameters.AddWithValue("idUnidad", dts.gidUnidad)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("StockMinimo", dts.gStockMinimo)
                    cmd.Parameters.AddWithValue("Comprable", dts.gComprable)
                    cmd.Parameters.AddWithValue("Vendible", dts.gVendible)
                    cmd.Parameters.AddWithValue("MateriaPrima", dts.gMateriaPrima)
                    cmd.Parameters.AddWithValue("subEnsamblado", dts.gsubEnsamblado)
                    cmd.Parameters.AddWithValue("Opcion", dts.gOpcion)
                    cmd.Parameters.AddWithValue("Escandallo", dts.gEscandallo)
                    cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                    cmd.Parameters.AddWithValue("idAlmacen", dts.gidAlmacen)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                    cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                    cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                    cmd.Parameters.AddWithValue("Alto", dts.gAlto)
                    cmd.Parameters.AddWithValue("Ancho", dts.gAncho)
                    cmd.Parameters.AddWithValue("Fondo", dts.gFondo)
                    cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                    cmd.Parameters.AddWithValue("ProduccionSeparada", dts.gProduccionSeparada)
                    cmd.Parameters.AddWithValue("ConNumSerie", dts.gConNumSerie)
                    cmd.Parameters.AddWithValue("ConNumSerie2", dts.gConNumSerie2)
                    cmd.Parameters.AddWithValue("ConVersiones", dts.gConVersiones)
                    cmd.Parameters.AddWithValue("recambio", dts.gRecambio)
                    cmd.Parameters.AddWithValue("domesticos2", dts.gDomesticos2)

                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    Dim t As Integer = cmd.ExecuteNonQuery
                    con.Close()
                    If t = 1 Then
                        Dim funcAP As New FuncionesArticuloPrecio
                        Dim dtsP As New DatosArticuloPrecio
                        dtsP.gidArticuloPrecio = 0
                        dtsP.gidArticulo = dts.gidArticulo
                        If dts.gComprable Or dts.gPrecioUnitarioC <> 0 Then
                            dtsP.gPrecio = dts.gPrecioUnitarioC
                            dtsP.gFechaPrecio = dts.gFechaPrecioC
                            dtsP.gcodMoneda = dts.gcodMonedaC
                            dtsP.gTipoPrecio = "C"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = dts.gidProveedorPrecio
                            dtsP.gidConcepto = dts.gidConceptoPedidoProv
                            dtsP.gidClientePrecio = 0
                            dtsP.gVersion = 0
                            funcAP.insertar(dtsP)
                        End If
                        If dts.gVendible Or dts.gPrecioUnitarioV <> 0 Then
                            dtsP.gPrecio = dts.gPrecioUnitarioV
                            dtsP.gFechaPrecio = dts.gFechaPrecioV
                            dtsP.gcodMoneda = dts.gcodMonedaV
                            dtsP.gTipoPrecio = "V"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = 0
                            dtsP.gidConcepto = 0
                            dtsP.gidClientePrecio = 0
                            dtsP.gVersion = 0
                            funcAP.insertar(dtsP)
                        End If
                        If dts.gOpcion Or dts.gPrecioOpcion <> 0 Then
                            dtsP.gPrecio = dts.gPrecioOpcion
                            dtsP.gFechaPrecio = dts.gFechaPrecioV
                            dtsP.gcodMoneda = dts.gcodMonedaV
                            dtsP.gTipoPrecio = "O"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = 0
                            dtsP.gidConcepto = 0
                            dtsP.gidClientePrecio = 0
                            dtsP.gVersion = 0
                            funcAP.insertar(dtsP)
                        End If
                        Return dts.gidArticulo
                    Else
                        Return 0
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                Finally
                    desconectado()
                End Try
            End Using
        End If
    End Function

    Public Function NuevoDoc(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Integer
        ' Añadir una entrada a la tabla de relación Prod_Documento si no existia ya
        Try
            If DocExiste(iidArticulo, vcodDocumento) Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("INSERT INTO Prod_Documentos (codDocumento,idArticulo) Values (@codDocumento, @idArticulo)", con)
                cmd.Parameters.AddWithValue("codDocumento", vcodDocumento)
                cmd.Parameters.AddWithValue("idArticulo", iidArticulo)
                con.Open()
                Return cmd.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Clonar(ByVal dts As DatosArticulo) As DatosArticulo
        Dim dtsN As New DatosArticulo
        dtsN.gActivo = dts.gActivo
        dtsN.gAlmacen = dts.gAlmacen
        dtsN.gAlto = dts.gAlto
        dtsN.gAncho = dts.gAncho
        dtsN.gArticulo = dts.gArticulo
        dtsN.gArticuloCli = dts.gArticuloCli
        dtsN.gArticuloEN = dts.gArticuloEN
        dtsN.gBultos = dts.gBultos
        dtsN.gCantidadStock = dts.gCantidadStock
        dtsN.gcodArticulo = dts.gcodArticulo
        dtsN.gCodArticuloCli = dts.gCodArticuloCli
        dtsN.gcodArticuloProv = dts.gcodArticuloProv
        dtsN.gcodMonedaC = dts.gcodMonedaC
        dtsN.gcodMonedaV = dts.gcodMonedaV
        dtsN.gComprable = dts.gComprable
        dtsN.gDescripcion = dts.gDescripcion
        dtsN.gDescripcionEN = dts.gDescripcionEN
        dtsN.gDescuento = dts.gDescuento
        dtsN.gDescuento1 = dts.gDescuento1
        dtsN.gDescuento2 = dts.gDescuento2
        dtsN.gEscandallo = dts.gEscandallo
        dtsN.gFamilia = dts.gFamilia
        dtsN.gFechaAlta = dts.gFechaAlta
        dtsN.gFechaBaja = dts.gFechaBaja
        dtsN.gFechaPrecioC = dts.gFechaPrecioC
        dtsN.gFechaPrecioV = dts.gFechaPrecioV
        dtsN.gFondo = dts.gFondo
        dtsN.gidAlmacen = dts.gidAlmacen
        dtsN.gidArtCli = dts.gidArtCli
        dtsN.gidArticulo = dts.gidArticulo
        dtsN.gidArticuloProv = dts.gidArticuloProv
        dtsN.gidConceptoPedidoProv = dts.gidConceptoPedidoProv
        dtsN.gidFamilia = dts.gidFamilia
        dtsN.gidProveedor = dts.gidProveedor
        dtsN.gidProveedorPrecio = dts.gidProveedorPrecio
        dtsN.gidSeccion = dts.gidSeccion
        dtsN.gidSubFamilia = dts.gidSubFamilia
        dtsN.gidSubTipoArticulo = dts.gidSubTipoArticulo
        dtsN.gidTipoArticulo = dts.gidTipoArticulo
        dtsN.gidTipoCompra = dts.gidTipoCompra
        dtsN.gidUnidad = dts.gidUnidad
        dtsN.gKilosBrutos = dts.gKilosBrutos
        dtsN.gKilosNetos = dts.gKilosNetos
        dtsN.gMateriaPrima = dts.gMateriaPrima
        dtsN.gObservaciones = dts.gObservaciones
        dtsN.gOpcion = dts.gOpcion
        dtsN.gPrecioArtCli = dts.gPrecioArtCli
        dtsN.gPrecioOpcion = dts.gPrecioOpcion
        dtsN.gPrecioUnitarioC = dts.gPrecioUnitarioC
        dtsN.gPrecioUnitarioV = dts.gPrecioUnitarioV
        dtsN.gProveedor = dts.gProveedor
        dtsN.gSeccion = dts.gSeccion
        dtsN.gSimboloC = dts.gSimboloC
        dtsN.gSimboloV = dts.gSimboloV
        dtsN.gStockMinimo = dts.gStockMinimo
        dtsN.gsubEnsamblado = dts.gsubEnsamblado
        dtsN.gSubFamilia = dts.gSubFamilia
        dtsN.gSubTipoArticulo = dts.gSubTipoArticulo
        dtsN.gTipoArticulo = dts.gTipoArticulo
        dtsN.gTipoCompra = dts.gTipoCompra
        dtsN.gTipoUnidad = dts.gTipoUnidad
        dtsN.gVendible = dts.gVendible
        dtsN.gVolumen = dts.gVolumen
        dtsN.gProduccionSeparada = dts.gProduccionSeparada
        dtsN.gConNumSerie = dts.gConNumSerie
        Return dtsN
    End Function

#End Region

#Region "UPDATE"

    Public Function actualizar(ByVal dts As DatosArticulo) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        If codArticuloExiste(dts.gidArticulo, dts.gcodArticulo) Then
            MsgBox("Ya existe una producto con el código " & dts.gcodArticulo)
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update Articulos set  codArticulo = @codArticulo, Articulo = @Articulo, ArticuloEN = @ArticuloEN, Descripcion = @Descripcion, DescripcionEN = @DescripcionEN, domesticos2 = @domesticos2 "
            sel = sel & " , FechaAlta = @FechaAlta, FechaBaja = @FechaBaja, Activo = @Activo, idTipoArticulo = @idTipoArticulo, idSubTipoArticulo = @idSubTipoArticulo, "
            sel = sel & " idFamilia = @idFamilia, idSubFamilia = @idsubFamilia,  idTipoCompra = @idTipoCompra, idUnidad = @idUnidad, Observaciones = @Observaciones, "
            sel = sel & " StockMinimo = @StockMinimo, Comprable = @Comprable, Vendible = @Vendible, MateriaPrima = @MateriaPrima, subEnsamblado = @subEnsamblado,  Opcion = @Opcion,  "
            sel = sel & " Escandallo = @Escandallo, idSeccion = @idSeccion, idAlmacen = @idAlmacen, idProveedor = @idProveedor, idModifica = @idModifica, Modificacion = @Modificacion, "
            sel = sel & " KilosBrutos = @KilosBrutos, KilosNetos = @KilosNetos, Bultos = @Bultos, Alto = @Alto, Ancho = @Ancho, Fondo = @Fondo, Volumen = @Volumen, "
            sel = sel & " ProduccionSeparada = @ProduccionSeparada, ConNumSerie = @ConNumSerie, ConNumSerie2 = @ConNumSerie2, ConVersiones = @ConVersiones, recambio = @recambio "
            sel = sel & " WHERE idArticulo = @idArticulo "
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)

                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("codArticulo", dts.gcodArticulo)
                    cmd.Parameters.AddWithValue("Articulo", dts.gArticulo)
                    cmd.Parameters.AddWithValue("ArticuloEN", dts.gArticuloEN)
                    cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                    cmd.Parameters.AddWithValue("DescripcionEN", dts.gDescripcionEN)
                    cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                    cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("idTipoArticulo", dts.gidTipoArticulo)
                    cmd.Parameters.AddWithValue("idSubTipoArticulo", dts.gidSubTipoArticulo)
                    cmd.Parameters.AddWithValue("idFamilia", dts.gidFamilia)
                    cmd.Parameters.AddWithValue("idSubFamilia", dts.gidSubFamilia)
                    cmd.Parameters.AddWithValue("idTipoCompra", dts.gidTipoCompra)
                    cmd.Parameters.AddWithValue("idUnidad", dts.gidUnidad)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("StockMinimo", dts.gStockMinimo)
                    cmd.Parameters.AddWithValue("Comprable", dts.gComprable)
                    cmd.Parameters.AddWithValue("Vendible", dts.gVendible)
                    cmd.Parameters.AddWithValue("MateriaPrima", dts.gMateriaPrima)
                    cmd.Parameters.AddWithValue("subEnsamblado", dts.gsubEnsamblado)
                    cmd.Parameters.AddWithValue("Opcion", dts.gOpcion)
                    cmd.Parameters.AddWithValue("Escandallo", dts.gEscandallo)
                    cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                    cmd.Parameters.AddWithValue("idAlmacen", dts.gidAlmacen)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                    cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                    cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                    cmd.Parameters.AddWithValue("Alto", dts.gAlto)
                    cmd.Parameters.AddWithValue("Ancho", dts.gAncho)
                    cmd.Parameters.AddWithValue("Fondo", dts.gFondo)
                    cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                    cmd.Parameters.AddWithValue("ProduccionSeparada", dts.gProduccionSeparada)
                    cmd.Parameters.AddWithValue("ConNumSerie", dts.gConNumSerie)
                    cmd.Parameters.AddWithValue("ConNumSerie2", dts.gConNumSerie2)
                    cmd.Parameters.AddWithValue("ConVersiones", dts.gConVersiones)
                    cmd.Parameters.AddWithValue("recambio", dts.gRecambio)
                    cmd.Parameters.AddWithValue("domesticos2", dts.gDomesticos2)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
                    con.Open()

                    Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                    con.Close()
                    If t = 1 Then
                        'Actualizar los precios
                        Dim funcAP As New FuncionesArticuloPrecio
                        Dim dtsP As New DatosArticuloPrecio
                        dtsP.gidArticuloPrecio = 0
                        dtsP.gidArticulo = dts.gidArticulo
                        If dts.gComprable Or dts.gPrecioUnitarioC <> 0 Then
                            dtsP.gPrecio = dts.gPrecioUnitarioC
                            dtsP.gFechaPrecio = dts.gFechaPrecioC
                            dtsP.gcodMoneda = dts.gcodMonedaC
                            dtsP.gTipoPrecio = "C"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = dts.gidProveedorPrecio
                            dtsP.gidConcepto = dts.gidConceptoPedidoProv
                            dtsP.gidClientePrecio = 0
                            funcAP.ActualizarH(dtsP)
                        End If
                        If dts.gVendible Or dts.gPrecioUnitarioV <> 0 Then
                            dtsP.gPrecio = dts.gPrecioUnitarioV
                            dtsP.gFechaPrecio = dts.gFechaPrecioV
                            dtsP.gcodMoneda = dts.gcodMonedaV
                            dtsP.gTipoPrecio = "V"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = 0
                            dtsP.gidConcepto = 0
                            dtsP.gidClientePrecio = 0
                            funcAP.ActualizarH(dtsP)
                        End If
                        If dts.gOpcion Or dts.gPrecioOpcion <> 0 Then
                            dtsP.gPrecio = dts.gPrecioOpcion
                            dtsP.gFechaPrecio = dts.gFechaPrecioV
                            dtsP.gcodMoneda = dts.gcodMonedaV
                            dtsP.gTipoPrecio = "O"
                            dtsP.gActivo = dts.gActivo
                            dtsP.gidProveedorPrecio = 0
                            dtsP.gidConcepto = 0
                            dtsP.gidClientePrecio = 0
                            funcAP.ActualizarH(dtsP)
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
        End If
    End Function

    Public Function actualizarProveedor(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos set  idProveedor = @idProveedor , idModifica = @idModifica, Modificacion = @Modificacion WHERE idArticulo = @idArticulo"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArticulo", iidArticulo)
                cmd.Parameters.AddWithValue("idProveedor", iidProveedor)
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

    Public Function Baja(ByVal iidArticulo As Integer) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos set   Activo = 0  WHERE idArticulo = " & iidArticulo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos

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
            Finally
                desconectado()
            End Try

        End Using

    End Function

#End Region

#Region "BORRAR"

    Public Function BorrarDoc(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Boolean
        'Borra la relación de la Producto con un documento y si no quedan relaciones, borra el documento de la tabla Documentos
        Try
            Dim resultado As Boolean
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            If vcodDocumento = 0 Then
                sel = "delete from Prod_Documentos WHERE idArticulo = " & iidArticulo & "' "
            Else
                sel = "delete from Prod_Documentos WHERE (idArticulo = " & iidArticulo & "' AND codDocumento = " & vcodDocumento & ")"
            End If

            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    resultado = True
                Else
                    resultado = False
                End If

            End Using

            'Si no existen más relaciones de este documento, se borrará de la tabla de documentos

            'Dim func As New FuncionesDocumentos
            'func.borrar(vcodDocumento)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function

    Public Function Borrar(ByVal iidArticulo As Integer) As Boolean
        'Borrar un Producto

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            Using con As New SqlConnection(sconexion)
                con.Open()
                sel = "delete from Articulos where idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function

#End Region

End Class


'#Region "INVENTARIO"

'    Public Function MostrarInventario() As List(Of DatosInventario)
'        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
'        Try
'            Dim sconexion As String = CadenaConexion()
'            Dim con As New SqlConnection(sconexion)
'            Dim sel As String

'            sel = "SELECT articulos.idArticulo AS 'ID' , codArticulo AS 'CÓDIGO', Articulo AS 'ARTÍCULO',"
'            sel = sel & "case when SUM(cantidad) IS null then 0 else SUM(cantidad) end AS 'STOCK', "
'            sel = sel & "case when (select precio from Articulos_Precios where Articulos_Precios.idArticulo = articulos.idArticulo and TipoPrecio ='C' and Modificacion is null) is null then 0 else "
'            sel = sel & "(select precio from Articulos_Precios where Articulos_Precios.idArticulo = articulos.idArticulo and TipoPrecio ='C' and Modificacion is null) end as 'PRECIO_ACTUAL', "
'            sel = sel & "case when SUM(cantidad) IS null then 0 else SUM(cantidad) end *case when (select precio from Articulos_Precios where Articulos_Precios.idArticulo = articulos.idArticulo and TipoPrecio ='C' and Modificacion is null) is null then 0 else "
'            sel = sel & "(select precio from Articulos_Precios where Articulos_Precios.idArticulo = articulos.idArticulo and TipoPrecio ='C' and Modificacion is null) end as 'VALOR' "
'            sel = sel & " from Articulos  "
'            sel = sel & " left join Stock as STK on STK.idArticulo = articulos.idArticulo "
'            sel = sel & " group by articulo , articulos.idArticulo, codArticulo "
'            sel = sel & " ORDER BY ARTÍCULO ASC "

'            cmd = New SqlCommand(sel, con)
'            con.Open()
'            If cmd.ExecuteNonQuery Then
'                con.Close()
'                Dim dt As New DataTable
'                Dim da As New SqlDataAdapter(cmd)
'                da.Fill(dt)
'                Dim dts As DatosInventario
'                Dim lista As New List(Of DatosInventario)
'                Dim linea As DataRow
'                For Each linea In dt.Rows
'                    If linea("ID") Is DBNull.Value Then
'                    Else
'                        dts = CargarLineaInventario(linea)
'                        lista.Add(dts)
'                        gestionInventarios.ProgressBar1.Value = gestionInventarios.ProgressBar1.Value + 1
'                        Application.DoEvents()
'                    End If
'                Next
'                Return lista
'            Else
'                con.Close()
'                Return Nothing
'            End If

'        Catch ex As Exception
'            MsgBox(ex.Message)
'            Return Nothing
'        Finally
'            desconectado()
'        End Try
'    End Function

'    Private Function CargarLineaInventario(ByVal linea As DataRow) As DatosInventario
'        Dim dts As New DatosInventario

'        dts.gidArticulo = linea("ID")
'        dts.gcodArticulo = If(linea("CÓDIGO") Is DBNull.Value, "", linea("CÓDIGO"))
'        dts.gArticulo = If(linea("ARTÍCULO") Is DBNull.Value, "", linea("ARTÍCULO"))
'        'dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
'        'dts.gidTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
'        dts.gPrecioActual = If(linea("PRECIO_ACTUAL") Is DBNull.Value, 0, linea("PRECIO_ACTUAL"))
'        dts.gValor = If(linea("VALOR") Is DBNull.Value, "", linea("VALOR"))
'        dts.gStock = If(linea("STOCK") Is DBNull.Value, 0, linea("STOCK"))

'        Return dts

'    End Function

'#End Region