Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesReparaciones

    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " Select DOC.*,subCliente, Clientes.NombreComercial as Cliente,Clientes.Observaciones as ObservacionesCli,subCliente, Localidad + ', ' + Direccion as Direccion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto,Divisa,Simbolo,TiposIVA.TipoIVA, Estado, TRR.Trabajo as TrabajoARealizar, TipoReparacion, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TiposIVA.TipoRecargoEq, TiposRetencion.TipoRetencion, TiposRetencion.Nombre as NombreTipoRetencion,   C2.Nombre + ' ' + C2.Apellidos as Persona, Estatus, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosReparaciones where numReparacion = DOC.numReparacion) as Base, " _
             & " AR.codArticulo, AR.Articulo, EQ.numSerie, CF.numFactura, CA.numAlbaran, CP.numPedido, FA.Fecha as FechaFactura, AL.Fecha as FechaServido, EQ.FechaFin as FechaFabricacionEQ, TipoValorado, Cabecera,Espera,EnCurso,Bloqueado,Traspasado,Anulado,Automatico,Entregado,Completo " _
             & " from Reparaciones as DOC " _
             & " left Join TrabajosReparaciones as TRR ON TRR.numReparacion = DOC.numReparacion AND TRR.Orden = 0 " _
             & " Left Join TiposReparacion as TR ON TR.idTipoReparacion = DOC.idTipoReparacion " _
             & " Left Join EstatusReparaciones as ER ON ER.idEstatus = DOC.idEstatus" _
             & " Left join Clientes ON Clientes.idCliente = DOC.idCliente " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto " _
             & " Left Join Articulos as AR ON AR.idArticulo = DOC.idArticulo " _
             & " Left Join EquiposProduccion as EQ ON EQ.idEquipo = DOC.idEquipo " _
             & " Left Join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion " _
             & " Left Join ConceptosAlbaranes as CA ON CA.idConcepto = EQ.idConceptoAlbaran " _
             & " Left Join ConceptosPedidos as CP ON CP.idConcepto = CR.idConceptoPedido " _
             & " Left Join ConceptosFacturas as CF ON CF.idConceptoAlbaran = EQ.idConceptoAlbaran " _
             & " Left Join Facturas as FA ON FA.numFactura = CF.numFactura " _
             & " Left Join Albaranes as AL ON AL.numAlbaran = CA.numAlbaran" _
             & " Left Join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipoValorado"

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosReparacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numReparacion DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosReparacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosReparacion
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numReparacion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        If Not simplificada Then
                            Call DatosCalculados(dts)
                        End If
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

    Private Function CargarLinea(ByVal linea As DataRow)
        Dim dts As New DatosReparacion
        dts.gnumReparacion = linea("NumReparacion")
        dts.gPrecioTotalReparacion = If(linea("precioReparacion") Is DBNull.Value, -1, linea("precioReparacion"))
        dts.gReferenciaCliente = If(linea("ReferenciaCliente") Is DBNull.Value, "", linea("ReferenciaCliente"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidEstatus = If(linea("idEstatus") Is DBNull.Value, 0, linea("idEstatus"))
        dts.gRMA = If(linea("RMA") Is DBNull.Value, "", linea("RMA"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
        dts.gFechaEntrega = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))
        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
        dts.gidEquipo = If(linea("idEquipo") Is DBNull.Value, 0, linea("idEquipo"))
        dts.gidEquipoHistorico = If(linea("idEquipoHistorico") Is DBNull.Value, 0, linea("idEquipoHistorico"))
        dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, "", linea("numSerie"))
        'dts.gidTipoReparacion = If(linea("idTipoReparacion") Is DBNull.Value, 0, linea("idTipoReparacion"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gGarantia = If(linea("Garantia") Is DBNull.Value, False, linea("Garantia"))
        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
        dts.gInspeccion = If(linea("Inspeccion") Is DBNull.Value, "", linea("Inspeccion"))
        dts.gTrabajoARealizar = If(linea("TrabajoARealizar") Is DBNull.Value, "", linea("TrabajoARealizar"))
        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gCaja = If(linea("Caja") Is DBNull.Value, False, linea("Caja"))
        dts.gCelula = If(linea("Celula") Is DBNull.Value, False, linea("Celula"))
        dts.gSonda = If(linea("Sonda") Is DBNull.Value, False, linea("Sonda"))
        dts.gPlaca = If(linea("Placa") Is DBNull.Value, False, linea("Placa"))
        dts.gOtros = If(linea("Otros") Is DBNull.Value, False, linea("Otros"))
        dts.gOtrosTipos = If(linea("OtrosTipos") Is DBNull.Value, "", linea("OtrosTipos"))
        dts.gFechaFabricacionRep = If(linea("FechaFabricacion") Is DBNull.Value, Now.Date, linea("FechaFabricacion"))
        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))
        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
        dts.gnumOferta = If(linea("numOferta") Is DBNull.Value, 0, linea("numOferta"))

        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gEstatus = If(linea("Estatus") Is DBNull.Value, "", linea("Estatus"))

        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        Dim subCliente As String = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gDireccion = If(subCliente = "", dts.gDireccion, subCliente & ": " & dts.gDireccion)
        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))
        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
        'dts.gTipoReparacion = If(linea("TipoReparacion") Is DBNull.Value, "", linea("TipoReparacion"))
        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))

        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))

        dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gFechaFabricacion = If(linea("FechaFabricacionEQ") Is DBNull.Value, Now.Date, linea("FechaFabricacionEQ"))
        dts.gFechaServido = If(linea("FechaServido") Is DBNull.Value, Now.Date, linea("FechaServido"))
        dts.gFechaFactura = If(linea("FechaFactura") Is DBNull.Value, Now.Date, linea("FechaFactura"))

        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))

        If dts.gFechaFabricacionRep < dts.gFechaFabricacion Then dts.gFechaFabricacion = dts.gFechaFabricacionRep
        dts.gdtsEstado = New DatosEstado
        dts.gdtsEstado.gidEstado = dts.gidEstado
        dts.gdtsEstado.gEstado = dts.gEstado
        dts.gdtsEstado.gCabecera = If(linea("Cabecera") Is DBNull.Value, False, linea("Cabecera"))
        dts.gdtsEstado.gEspera = If(linea("Espera") Is DBNull.Value, False, linea("Espera"))
        dts.gdtsEstado.gEnCurso = If(linea("EnCurso") Is DBNull.Value, False, linea("EnCurso"))
        dts.gdtsEstado.gTraspasado = If(linea("Traspasado") Is DBNull.Value, False, linea("Traspasado"))
        dts.gdtsEstado.gAnulado = If(linea("Anulado") Is DBNull.Value, False, linea("Anulado"))
        dts.gdtsEstado.gAutomatico = If(linea("Automatico") Is DBNull.Value, False, linea("Automatico"))
        dts.gdtsEstado.gEntregado = If(linea("Entregado") Is DBNull.Value, False, linea("Entregado"))
        dts.gdtsEstado.gCompleto = If(linea("Completo") Is DBNull.Value, False, linea("Completo"))

        Return dts
    End Function

    Public Function Mostrar1(ByVal inumReparacion As Integer) As DatosReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.numReparacion = " & inumReparacion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosReparacion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numReparacion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        Call DatosCalculados(dts)
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

    Public Function DatosCalculados(ByRef dts As DatosReparacion) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, TipoIVA, TipoRecargoEq from ConceptosReparaciones as CO left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " where CO.numReparacion = " & dts.gnumReparacion
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim Base As Double = 0 'Suma de precios con todos los descuentos
            Dim TotalIVA As Double = 0
            Dim TotalRE As Double = 0
            Dim subTotal As Double = 0
            Dim subTotalPP As Double = 0
            Dim descuento As Double = 0 'Descuento de linea
            Dim sumaDescuentos As Double = 0
            Dim sumaDescuentosPP As Double = 0
            Dim precioNetoUnitario As Double = 0
            Dim PVP As Double = 0
            Dim cantidad As Double
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    'Hay que acumular los descuentos totales
                    descuento = If(linea("descuento") Is DBNull.Value, 0, linea("descuento"))
                    PVP = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
                    precioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                    cantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                    If descuento <> 0 Then
                        subTotal = cantidad * PVP * (1 - (descuento / 100))
                        sumaDescuentos = sumaDescuentos + (PVP * (descuento / 100))
                    Else
                        If precioNetoUnitario > 0 Then
                            subTotal = cantidad * precioNetoUnitario
                        Else
                            subTotal = cantidad * PVP
                        End If
                    End If
                    subTotalPP = subTotal * (1 - (dts.gProntoPago / 100))
                    Base = Base + subTotalPP
                    TotalIVA = TotalIVA + (subTotalPP * (If(linea("TipoIVA") Is DBNull.Value, 0, CDbl(linea("TipoIVA")) / 100)))  'El IVA se calcula sobre el importe neto con todos los descuentos
                    If dts.gRecargoEquivalencia Then
                        TotalRE = TotalRE + subTotalPP * (If(linea("TipoRecargoEq") Is DBNull.Value, 0, CDbl(linea("TipoRecargoEq")) / 100))
                    End If
                    sumaDescuentosPP = sumaDescuentosPP + subTotal * (dts.gProntoPago / 100)
                Next
                dts.gImporteDescuentos = sumaDescuentos
                dts.gImportePP = sumaDescuentosPP
                If dts.gPortes = "P" Or dts.gPortes = "D" Then
                    dts.gBase = Base  'Antes de descuentos generales
                    dts.gTotalIVA = TotalIVA
                    dts.gTotalRE = TotalRE
                Else
                    dts.gBase = Base + dts.gPrecioTransporte
                    dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dts.gTipoIVA / 100)
                    If dts.gRecargoEquivalencia Then
                        dts.gTotalRE = TotalRE + dts.gPrecioTransporte * (dts.gTipoRecargoEq / 100)
                    Else
                        dts.gTotalRE = TotalRE
                    End If
                End If
                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
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

    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla ReparacionesProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM Reparaciones", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                If Date.TryParse(o, fecha) Then
                    con.Close()
                    Return fecha
                Else
                    con.Close()
                    Return Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla ReparacionesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM Reparaciones", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                If Date.TryParse(o, fecha) Then
                    con.Close()
                    Return fecha
                Else
                    con.Close()
                    Return Nothing
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function buscaUltimoDoc(ByVal iidCliente As Integer) As Integer ' Busca el último documento de un cliente dado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MAX(numReparacion) FROM Reparaciones "
            Else
                sel = "SELECT MAX(numReparacion) FROM Reparaciones where idCliente = " & iidCliente
            End If
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

    Public Function UltimoPrecioTransporte(ByVal iidCliente As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim inumReparacion As Integer = buscaUltimoDoc(iidCliente)
            If inumReparacion = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Reparaciones where numReparacion = " & inumReparacion
            End If
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

    Public Function ReferenciaCliente(ByVal inumReparacion As Integer) As String ' Busca la última fecha dentro de la tabla ReparacionesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Reparaciones Where numReparacion = " & inumReparacion, con)
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

    Public Function idEstado(ByVal inumReparacion As Integer) As Integer ' Busca la última fecha dentro de la tabla ReparacionesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Reparaciones Where numReparacion = " & inumReparacion, con)
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

    Public Function numReparacionPedido(ByVal inumPedido As Integer) As Integer ' Busca la última fecha dentro de la tabla ReparacionesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT TOP 1 numReparacion FROM Reparaciones Where numPedido = " & inumPedido, con)
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

    Public Function idTipoIVA(ByVal inumReparacion As Integer) As Integer ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Reparaciones Where numReparacion = " & inumReparacion, con)
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


    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Reparaciones", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Reparaciones WHERE  " & busqueda, con)
            End If
            con.Open()
            Dim t As Integer = cmd.ExecuteScalar
            con.Close()
            Return t

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExisteNumReparacion(ByVal inumReparacion As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el Reparacion, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el Reparacion.
        Try
            If inumReparacion = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Reparaciones Where numReparacion = " & inumReparacion
                Else
                    sel = "SELECT idCliente FROM Reparaciones Where numReparacion = " & inumReparacion & " AND idCliente = " & iidCliente
                End If

                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna Reparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreFiscal, Reparaciones.idCliente from Reparaciones left Join Clientes ON Clientes.idCliente = Reparaciones.idCliente ", con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idCliente") Is DBNull.Value Or linea("NombreFiscal") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(linea("NombreFiscal"), linea("idCliente")))
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

    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de Reparaciones existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numReparacion FROM Reparaciones ORDER BY numReparacion DESC", con)
            Else
                cmd = New SqlCommand("SELECT numReparacion FROM Reparaciones WHERE YEAR(Fecha) = " & Any & " ORDER BY numReparacion DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numReparacion") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numReparacion"))
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

    Public Function InsertarLog(ByVal dts As DatosReparacion) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim sel As String = "Insert into reparacionesLog (idReparacion, fecha, idEstatus, idModificador) values (" & dts.gnumReparacion & ",getdate(), " & dts.gidEstatus & ", " & Inicio.vIdUsuario & "  )"

            Dim cmd As New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Catch ex As Exception

            con.Close()

            MsgBox("Error al generar el log", MsgBoxStyle.Critical)

        End Try

    End Function

    Public Function verEstatusReparacion(ByVal numReparacion As Integer) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            Dim sel As String = " select idEstatus from reparaciones where numReparacion = " & numReparacion

            Dim cmd As New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            Return i

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            Return 0

        End Try

    End Function

    Public Function insertar(ByVal dts As DatosReparacion) As Integer 'Inserta una nueva Reparacion y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumReparacion = gMaster.incnumReparacion(Year(dts.gFecha))
        If dts.gnumReparacion = 0 Then
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Reparaciones (numReparacion, ReferenciaCliente, idEstado,idEstatus, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, "
            sel = sel & " codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia,ProntoPago, SolicitadoVia, "
            sel = sel & " Notas, Observaciones,idPersona, PrecioTransporte, Portes,idEquipo,idEquipoHistorico,numSerie,idArticulo,Garantia, "
            sel = sel & " Descripcion,Inspeccion,idTransporte, Transporte,Caja,Celula,Sonda,Placa,Otros,OtrosTipos,FechaFabricacion, codArticuloCli,idTipoValorado, idCreador, Creacion , idrazonsocial, precioReparacion, rma) "
            sel = sel & " values (@numReparacion, @ReferenciaCliente, @idEstado, @idEstatus, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto, "
            sel = sel & " @codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@ProntoPago,@SolicitadoVia,"
            sel = sel & " @Notas,@Observaciones, @idPersona,@PrecioTransporte,@Portes,@idEquipo,@idEquipoHistorico,@numSerie,@idArticulo,@Garantia, "
            sel = sel & " @Descripcion,@Inspeccion,@idTransporte,@Transporte,@Caja,@Celula,@Sonda,@Placa,@Otros,@OtrosTipos,@FechaFabricacion, @codArticuloCli,@idTipoValorado, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1), @PrecioTotalReparacion, @RMA )"
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = CargarParamentros(sel, con, dts)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumReparacion
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If
    End Function

    Public Function insertarNumLibre(ByVal dts As DatosReparacion) As Integer 'Inserta una nueva Reparacion y devuelve el nº
      
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Reparaciones (numReparacion, ReferenciaCliente, idEstado,idEstatus, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, "
        sel = sel & " codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia,ProntoPago, SolicitadoVia, "
        sel = sel & " Notas, Observaciones,idPersona, PrecioTransporte, Portes,idEquipo,idEquipoHistorico,numSerie,idArticulo,Garantia, "
        sel = sel & " Descripcion,Inspeccion,idTransporte, Transporte,Caja,Celula,Sonda,Placa,Otros,OtrosTipos,FechaFabricacion, codArticuloCli,idTipoValorado, idCreador, Creacion, rma ) "
        sel = sel & " values (@numReparacion, @ReferenciaCliente, @idEstado, @idEstatus, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto, "
        sel = sel & " @codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@ProntoPago,@SolicitadoVia,"
        sel = sel & " @Notas,@Observaciones, @idPersona,@PrecioTransporte,@Portes,@idEquipo,@idEquipoHistorico,@numSerie,@idArticulo,@Garantia, "
        sel = sel & " @Descripcion,@Inspeccion,@idTransporte,@Transporte,@Caja,@Celula,@Sonda,@Placa,@Otros,@OtrosTipos,@FechaFabricacion, @codArticuloCli,@idTipoValorado, @idCreador,@Creacion, @RMA )"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = CargarParamentros(sel, con, dts)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Return dts.gnumReparacion
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using

    End Function

    Private Function CargarParamentros(ByVal sel As String, ByVal con As SqlConnection, ByVal dts As DatosReparacion) As SqlCommand
        Dim cmd As New SqlCommand(sel, con)
        cmd = New SqlCommand(sel, con)
        cmd.Parameters.AddWithValue("RMA", dts.gRMA)
        cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
        cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
        cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
        cmd.Parameters.AddWithValue("idEstatus", dts.gidEstatus)
        cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
        cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
        cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
        cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
        cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
        cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
        cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
        cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
        cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
        cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
        cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
        cmd.Parameters.AddWithValue("Notas", dts.gNotas)
        cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
        cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
        cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
        cmd.Parameters.AddWithValue("Portes", dts.gPortes)
        cmd.Parameters.AddWithValue("idEquipo", dts.gidEquipo)
        cmd.Parameters.AddWithValue("idEquipoHistorico", dts.gidEquipoHistorico)
        cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
        cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
        cmd.Parameters.AddWithValue("Garantia", dts.gGarantia)
        cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
        cmd.Parameters.AddWithValue("Inspeccion", dts.gInspeccion)
        cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
        cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
        cmd.Parameters.AddWithValue("Caja", dts.gCaja)
        cmd.Parameters.AddWithValue("Celula", dts.gCelula)
        cmd.Parameters.AddWithValue("Sonda", dts.gSonda)
        cmd.Parameters.AddWithValue("Placa", dts.gPlaca)
        cmd.Parameters.AddWithValue("Otros", dts.gOtros)
        cmd.Parameters.AddWithValue("OtrosTipos", dts.gOtrosTipos)
        cmd.Parameters.AddWithValue("FechaFabricacion", dts.gFechaFabricacionRep)
        cmd.Parameters.AddWithValue("codArticuloCli", dts.gcodArticuloCli)
        cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
        cmd.Parameters.AddWithValue("PrecioTotalReparacion", dts.gPrecioTotalReparacion)
        Return cmd
    End Function

    Public Function actualizar(ByVal dts As DatosReparacion) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set ReferenciaCliente = @ReferenciaCliente, idEstado = @idEstado, idEstatus = @idEstatus, Fecha = @Fecha, FechaEntrega = @FechaEntrega, "
        sel = sel & " idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, codMoneda = @codMoneda, idTipoIVA = @idTipoIVA, "
        sel = sel & " idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, "
        sel = sel & " Notas = @Notas, Observaciones = @Observaciones, idPersona = @idPersona, PrecioTransporte = @PrecioTransporte, Portes = @Portes, "
        sel = sel & " idEquipo = @idEquipo,idEquipoHistorico = @idEquipoHistorico, numSerie = @numSerie, idArticulo = @idArticulo, Garantia = @Garantia, "
        sel = sel & " Descripcion = @Descripcion, Inspeccion = @Inspeccion,idTransporte = @idTransporte, Transporte = @Transporte, Caja = @Caja, Celula = @Celula,  "
        sel = sel & " Sonda = @Sonda, Placa = @Placa, Otros = @Otros, OtrosTipos = @OtrosTipos, FechaFabricacion = @FechaFabricacion, codArticuloCli = @codArticuloCli, idTipoValorado = @idTipoValorado, idModifica = @idModifica, Modificacion = @Modificacion, precioReparacion = @PrecioTotalReparacion, rma = @RMA  "
        sel = sel & " WHERE numReparacion = @numReparacion"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = CargarParamentros(sel, con, dts)
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



    Public Function actualizaEstado(ByVal inumReparacion As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set idEstado = @idEstado where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)
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

    Public Function actualizaEstatus(ByVal inumReparacion As Integer, ByVal iidEstatus As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set idEstatus = @idEstatus where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstatus", iidEstatus)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)
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



    Public Function actualizanumOferta(ByVal inumReparacion As Integer, ByVal numOferta As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set numOferta = @numOferta where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numOferta", numOferta)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)
              
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


    Public Function actualizanumPedido(ByVal inumReparacion As Integer, ByVal numPedido As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set numPedido = @numPedido where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", numPedido)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)
              
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


    Public Function actualizaidEquipoHistorico(ByVal inumReparacion As Integer, ByVal iidEquipoHistorico As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set idEquipoHistorico = @idEquipoHistorico where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEquipoHistorico", iidEquipoHistorico)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)

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



    Public Function actualizanumProforma(ByVal inumReparacion As Integer, ByVal numProforma As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set numProforma = @numProforma where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numProforma", numProforma)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)

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



    Public Function actualizaMoneda(ByVal inumReparacion As Integer, ByVal scodMoneda As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Reparaciones set codMoneda = @codMoneda where numReparacion = @numReparacion "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numReparacion", inumReparacion)

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



    Public Function borrar(ByVal inumReparacion As Integer) As Boolean  ' Borra una cabecera de Reparacion


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Reparaciones where numReparacion = " & inumReparacion
        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                con.Open()
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
