Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesPedidos
    Inherits conexion
    Dim cmd As SqlCommand
    Private sel0 As String = " Select DOC.*, Clientes.NombreComercial as Cliente,TipoValorado, Proveedores.nombreComercial as AgenciaTransporte,Clientes.Observaciones as ObservacionesCli,subCliente, Localidad + ', ' + Direccion as Direccion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo,TipoIVA, Estado, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TipoRecargoEq, TipoRetencion, TiposRetencion.Nombre as NombreTipoRetencion,  C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosPedidos where numPedido = DOC.numPedido) as Base," _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then CantidadServida * PVPUnitario * (1- (Descuento/100)) else CantidadServida * precioNetoUnitario end ) from ConceptosPedidos where numPedido = DOC.numPedido) as Servido" _
             & " from Pedidos as DOC " _
             & " Left join Clientes ON Clientes.idCliente = DOC.idCliente " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Outer Join MediosPago ON MediosPago.idMedioPago = DOC.idMedioPago " _
             & " Left Outer Join TiposPago ON TiposPago.idTipoPago = DOC.idTipoPago " _
             & " Left Outer Join CuentasBancarias as CB ON CB.idCuentaBanco = DOC.idCuentaBanco " _
             & " Left Join Bancos ON Bancos.idBanco = CB.idBanco " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left Join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipovalorado " _
             & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
             & " left outer join Proveedores ON Proveedores.idProveedor = DOC.idTransporte " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto "

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosPedido)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select *,Base - Servido as PendienteServir from (" & sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & ")X " & If(sOrden.Length = 0, " Order By numPedido DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedido)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosPedido
                da.Fill(dt)
                'Dim subCliente As String
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        If Not simplificada Then
                            Call DatosCalculados(dts, False)
                        End If
                        lista.Add(dts)
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("sOrden", sOrden)
            ex.Data.Add("Simplificada", simplificada)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function Busqueda0(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosPedido)
        'Esta búsqueda la utiliza la Gestión Logística (BusquedaPedidosProduccion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numPedido DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedido)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosPedido
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        If Not simplificada Then
                            Call DatosCalculados(dts, False)
                        End If
                        lista.Add(dts)
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("sOrden", sOrden)
            ex.Data.Add("Simplificada", simplificada)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Private Function CargarLinea(ByVal linea As DataRow) As DatosPedido
        Dim dts As New DatosPedido
        Dim subCliente As String

        dts.gnumPedido = linea("NumPedido")

        dts.gReferenciaCliente = If(linea("ReferenciaCliente") Is DBNull.Value, "", linea("ReferenciaCliente"))
        dts.gReferenciaCliente2 = If(linea("ReferenciaCliente2") Is DBNull.Value, "", linea("ReferenciaCliente2"))

        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))

        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))

        dts.gFechaEntrega = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))

        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))

        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))

        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))

        dts.gidMedioPago = If(linea("idMedioPago") Is DBNull.Value, 0, linea("idMedioPago"))

        dts.gidTipoPago = If(linea("idTipoPago") Is DBNull.Value, 0, linea("idTipoPago"))

        dts.gidCuentaBanco = If(linea("idCuentaBanco") Is DBNull.Value, 0, linea("idCuentaBanco"))

        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))

        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))

        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))

        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))

        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))

        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))

        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))

        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))

        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))

        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))

        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))

        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))

        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))

        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))

        dts.gPrioridad = If(linea("Prioridad") Is DBNull.Value, 3, linea("Prioridad"))

        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))

        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))

        dts.gEnPruebas = If(linea("EnPruebas") Is DBNull.Value, False, linea("EnPruebas"))

        dts.gAcabando = If(linea("Acabando") Is DBNull.Value, False, linea("Acabando"))

        dts.gbAnulado = If(linea("bAnulado") Is DBNull.Value, False, linea("bAnulado"))

        dts.gFechaInicioPruebas = If(linea("FechaInicioPruebas") Is DBNull.Value, CDate("1-1-1900"), linea("FechaInicioPruebas"))

        dts.gNotaPruebas = If(linea("NotaPruebas") Is DBNull.Value, "", linea("NotaPruebas"))

        dts.gSinAlbaran = If(linea("SinAlbaran") Is DBNull.Value, False, linea("SinAlbaran"))

        dts.gRecogido = If(linea("Recogido") Is DBNull.Value, False, linea("Recogido"))

        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))

        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))

        subCliente = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))

        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))

        dts.gDireccion = If(subCliente = "", dts.gDireccion, subCliente & ": " & dts.gDireccion)

        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))

        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))

        dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))

        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))

        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))

        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))

        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))

        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))

        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))

        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))

        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))

        dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))

        dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))

        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))

        dts.gAgenciaTransporte = If(linea("AgenciaTransporte") Is DBNull.Value, "", linea("AgenciaTransporte"))

        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))

        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))

        dts.gServido = If(linea("Servido") Is DBNull.Value, 0, linea("Servido"))

        dts.gPendienteServir = dts.gBase - dts.gServido
        Return dts

    End Function

    Public Function Mostrar1(ByVal inumPedido As Integer) As DatosPedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosPedido
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                'Dim subCliente As String
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)

                        Call DatosCalculados(dts, False)

                        'dts.gRetencion = dts.gBase * dts.gTipoRetencion
                        'dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function DatosCalculados(ByRef dts As DatosPedido, ByVal SoloPendientes As Boolean) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, TipoIVA, TipoRecargoEq "
            sel = sel & " from ConceptosPedidos as CO left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            'sel = sel & " left outer join ConceptosAlbaranes as C3 ON C3.idConceptoPedido = CO.idConcepto "
            'sel = sel & " left outer join ConceptosOfertas as C1 ON C1.idConcepto = CO.idConceptoOferta "
            'sel = sel & " left outer join ConceptosProformas as C2 ON C1.idConcepto = CO.idConceptoProforma "
            If SoloPendientes Then
                sel = sel & " where  CO.CantidadServida <> CO.Cantidad AND CO.numPedido = " & dts.gnumPedido
            Else
                sel = sel & " where CO.numPedido = " & dts.gnumPedido
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            Dim numSAlbaran As New List(Of Integer)
            Dim numSProduccion As New List(Of Integer)


            Dim Base As Double = 0 'Suma de precios con todos los descuentos
            Dim TotalIVA As Double = 0
            Dim TotalRE As Double = 0
            Dim subTotal As Double = 0
            Dim subTotalPP As Double = 0
            Dim descuento As Double = 0 'Descuento de linea
            'Dim descuentoG As Double = (1 - (dts.gProntoPago / 100)) * (1 - (dts.gDescuento / 100)) * (1 - (dts.gDescuento2 / 100))
            Dim DescuentoC As Double = 0

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
                    If SoloPendientes Then
                        Dim CantidadServida As Double = If(linea("CantidadServida") Is DBNull.Value, 0, linea("CantidadServida"))
                        cantidad = cantidad - CantidadServida
                    End If

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
                    'If linea("Albaran") Is DBNull.Value Then
                    'Else
                    '    Call NuevoNumeroEnLista(numSAlbaran, linea("Albaran"))
                    'End If
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

                dts.gnumSAlbaran = ListaAlbaranes(dts.gnumPedido, SoloPendientes)
                dts.gnumSProduccion = numSProduccion
                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion

                Return True
            Else
                con.Close()
                Return False
            End If

        Catch ex As Exception
            ex.Data.Add("dts.gnumpedido", dts.gnumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function ListaAlbaranes(ByVal iNumPedido As Integer, ByVal SoloPendientes As Boolean) As List(Of Integer)
        'Incorpora la lista de Albaranes que se referencian a lineas del pedido. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select distinct CA.numAlbaran  "
            sel = sel & " from ConceptosPedidos as CO "
            sel = sel & " left join ConceptosAlbaranes as CA ON CA.idConceptoPedido = CO.idConcepto "
            If SoloPendientes Then
                sel = sel & " where  CO.CantidadServida <> CO.Cantidad AND CO.numPedido = " & iNumPedido
            Else
                sel = sel & " where CO.numPedido = " & iNumPedido
            End If
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim numSAlbaran As New List(Of Integer)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim iNumAlbaran As Integer = 0
                For Each linea In dt.Rows
                    If linea("numAlbaran") Is DBNull.Value Then
                    Else
                        iNumAlbaran = linea("numAlbaran")
                        If iNumAlbaran > 0 AndAlso Not numSAlbaran.Contains(iNumAlbaran) Then numSAlbaran.Add(iNumAlbaran)
                    End If
                Next
            Else
                con.Close()
            End If
            Return numSAlbaran
        Catch ex As Exception
            ex.Data.Add("iNumpedido", iNumPedido)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Private Sub NuevoNumeroEnLista(ByRef lista As List(Of Integer), ByVal nuevoNumero As Integer)
        If nuevoNumero > 0 Then
            Dim existe As Boolean = False
            For Each n As Integer In lista
                If n = nuevoNumero Then existe = True
            Next
            If Not existe Then lista.Add(nuevoNumero)
        End If
    End Sub

    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla PedidosProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM Pedidos", con)
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
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM Pedidos", con)
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
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function buscaUltimoDoc(ByVal iidCliente As Integer) As Integer ' Busca el último documento de un cliente dado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MAX(numPedido) FROM Pedidos "
            Else
                sel = "SELECT MAX(numPedido) FROM Pedidos where idCliente = " & iidCliente
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
            ex.Data.Add("iidCliente", iidCliente)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function UltimoPrecioTransporte(ByVal iidCliente As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim inumPedido As Integer = buscaUltimoDoc(iidCliente)
            If inumPedido = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Pedidos where numPedido = " & inumPedido
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
            ex.Data.Add("iidCliente", iidCliente)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function ReferenciaCliente(ByVal inumPedido As Integer) As String ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function ExisteNumPedido(ByVal inumPedido As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el pedido, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el pedido.
        Try
            If inumPedido = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Pedidos Where numPedido = " & inumPedido
                Else
                    sel = "SELECT idCliente FROM Pedidos Where numPedido = " & inumPedido & " AND idCliente = " & iidCliente
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
            ex.Data.Add("inumPedido", inumPedido)
            ex.Data.Add("iidCliente", iidCliente)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function idEstado(ByVal inumPedido As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Pedidos Where numPedido = " & inumPedido, con)
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

    Public Function bAnulado(ByVal inumPedido As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT bAnulado FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function numReparacion(ByVal inumPedido As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT numReparacion FROM Pedidos Where numPedido = " & inumPedido, con)
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

    Public Function idTipoIVA(ByVal inumPedido As Integer) As Integer ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Pedidos Where numPedido = " & inumPedido, con)
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

    Public Function Cliente(ByVal inumPedido As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT NombreComercial FROM Pedidos left join Clientes ON Clientes.idCliente = Pedidos.idCliente  Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function idCliente(ByVal inumPedido As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idCliente FROM Pedidos  Where numPedido = " & inumPedido, con)
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

    Public Function FechaEntrega(ByVal inumPedido As Integer) As Date
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT FechaEntrega FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                Return CDate(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function FechaProduccion(ByVal inumPedido As Integer) As Date
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT fechaproduccion FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                Return CDate(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function EnPruebas(ByVal inumPedido As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT EnPruebas FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function Acabando(ByVal inumPedido As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT Acabando FROM Pedidos Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function EnCurso(ByVal inumPedido As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT EnCurso FROM Pedidos left join Estados ON Estados.idEstado = Pedidos.idEstado Where numPedido = " & inumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Pedidos", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Pedidos WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            ex.Data.Add("Busqueda", busqueda)
            CorreoError(ex)
            Return Nothing
        End Try

    End Function

    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna Pedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreComercial, Pedidos.idCliente from Pedidos left Join Clientes ON Clientes.idCliente = Pedidos.idCliente ", con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idCliente") Is DBNull.Value Or linea("NombreComercial") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(linea("NombreComercial"), linea("idCliente")))
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

    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de pedidos existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numPedido FROM Pedidos ORDER BY numPedido DESC", con)
            Else
                cmd = New SqlCommand("SELECT numPedido FROM Pedidos WHERE YEAR(Fecha) = " & Any & " ORDER BY numPedido DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numPedido"))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("Any", Any)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function listaNum(ByVal sBusqueda As String) As List(Of Integer) 'lista de números de pedidos existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If sBusqueda = "" Then
                cmd = New SqlCommand("SELECT numPedido FROM Pedidos ORDER BY numPedido DESC", con)
            Else
                cmd = New SqlCommand("SELECT numPedido FROM Pedidos WHERE " & sBusqueda & " ORDER BY numPedido DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numPedido"))
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

    Public Function insertar(ByVal dts As DatosPedido) As Integer 'Inserta una nueva Pedido y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumPedido = gMaster.incnumPedido(Year(dts.gFecha))
        If dts.gnumPedido = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Pedidos (numPedido, ReferenciaCliente, ReferenciaCliente2,idEstado, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, idMedioPago, idTipoPago, idCuentaBanco,"
            sel = sel & "  codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia, Descuento, Descuento2, ProntoPago, SolicitadoVia, Notas, Observaciones, idTipoValorado, Portes, idTransporte, "
            sel = sel & "  Transporte, Prioridad,idPersona,PrecioTransporte, EnPruebas, Acabando,bAnulado, FechaInicioPruebas, NotaPruebas, SinAlbaran, Recogido, idCreador, Creacion, idrazonsocial, fechaProduccion ) "
            sel = sel & " values (@numPedido, @ReferenciaCliente,@ReferenciaCliente2, @idEstado, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto,@idMedioPago,@idTipoPago,@idCuentaBanco,"
            sel = sel & " @codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@Descuento,@Descuento2,@ProntoPago,@SolicitadoVia,@Notas,@Observaciones,@idTipoValorado,@Portes,@idTransporte,"
            sel = sel & " @Transporte,@Prioridad,@idPersona,@PrecioTransporte,@EnPruebas,@Acabando,@bAnulado,@FechaInicioPruebas,@NotaPruebas,@SinAlbaran,@Recogido,@idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1),@fechaProduccion)"
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                    cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
                    cmd.Parameters.AddWithValue("ReferenciaCliente2", dts.gReferenciaCliente2)
                    cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                    cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                    cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                    cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                    cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                    cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                    cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                    cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                    cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                    cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                    cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                    cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                    cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                    cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                    cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                    cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                    cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                    cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                    cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                    cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                    cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("Prioridad", dts.gPrioridad)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("EnPruebas", False)
                    cmd.Parameters.AddWithValue("Acabando", False)
                    cmd.Parameters.AddWithValue("bAnulado", False)
                    cmd.Parameters.AddWithValue("FechaInicioPruebas", CDate("1-1-2015"))
                    cmd.Parameters.AddWithValue("fechaProduccion", dts.gFechaEntrega)
                    cmd.Parameters.AddWithValue("NotaPruebas", "")
                    cmd.Parameters.AddWithValue("SinAlbaran", dts.gSinAlbaran)
                    cmd.Parameters.AddWithValue("Recogido", dts.gRecogido)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumPedido
                Catch ex As Exception
                    ex.Data.Add("dts.gnumPedido", dts.gnumPedido)
                    CorreoError(ex)
                    Return Nothing
                End Try
            End Using
        End If

    End Function

    Public Function actualizar(ByVal dts As DatosPedido) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set numPedido = @numPedido, ReferenciaCliente = @ReferenciaCliente, ReferenciaCliente2 = @ReferenciaCliente2,idEstado = @idEstado, Fecha = @Fecha, FechaEntrega = @FechaEntrega,"
        sel = sel & " idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, idCuentaBanco = @idCuentaBanco,"
        sel = sel & " codMoneda = @codMoneda, idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, Descuento = @Descuento, Descuento2 = @Descuento2,idPersona =@idPersona, "
        sel = sel & " ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, Notas = @Notas, Observaciones = @Observaciones, idTipoValorado = @idTipoValorado, Portes = @Portes, idTransporte = @idTransporte,"
        sel = sel & " Transporte =@Transporte,Prioridad = @Prioridad,PrecioTransporte = @PrecioTransporte, SinAlbaran = @SinAlbaran, Recogido = @Recogido, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numPedido = @numPedido"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
                cmd.Parameters.AddWithValue("ReferenciaCliente2", dts.gReferenciaCliente2)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("Prioridad", dts.gPrioridad)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("SinAlbaran", dts.gSinAlbaran)
                cmd.Parameters.AddWithValue("Recogido", dts.gRecogido)

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
                ex.Data.Add("dts.gnumPedido", dts.gnumPedido)
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizaEstado(ByVal inumPedido As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        If iidEstado <> idEstado(inumPedido) Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update Pedidos set idEstado = @idEstado, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idEstado", iidEstado)
                    cmd.Parameters.AddWithValue("numPedido", inumPedido)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
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
                    ex.Data.Add("inumPedido", inumPedido)
                    ex.Data.Add("iidEstado", iidEstado)
                    CorreoError(ex)
                    Return False
                End Try

            End Using
        End If
    End Function

    Public Function CambiaEnPruebas(ByVal inumPedido As Integer) As Boolean   'Cambia de estado el campo EnPruebas, devuelve el estado resultante
        Dim CampoEnPruebas As Boolean = EnPruebas(inumPedido)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set EnPruebas = @EnPruebas, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("EnPruebas", Not CampoEnPruebas)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return Not CampoEnPruebas
                Else
                    Return False
                End If

            Catch ex As Exception
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function CambiaSinAlbaran(ByVal inumPedido As Integer, ByVal SinAlbaran As Boolean) As Boolean   'Cambia de estado el campo EnPruebas, devuelve el estado resultante
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set SinAlbaran = @SinAlbaran, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("SinAlbaran", SinAlbaran)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
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
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function CambiaRecogido(ByVal inumPedido As Integer, ByVal Recogido As Boolean) As Boolean   'Cambia de estado el campo EnPruebas, devuelve el estado resultante
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set Recogido = @Recogido, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Recogido", Recogido)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
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
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function CambiaFechaInicioPruebas(ByVal inumPedido As Integer, ByVal FechaInicioPruebas As Date) As Date
        Dim CampoEnPruebas As Boolean = EnPruebas(inumPedido)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set FechaInicioPruebas = @FechaInicioPruebas, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("FechaInicioPruebas", FechaInicioPruebas)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return FechaInicioPruebas
            Catch ex As Exception
                ex.Data.Add("inumPedido", inumPedido)
                ex.Data.Add("FechaInicioPruebas", FechaInicioPruebas)
                CorreoError(ex)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function CambiaNotaPruebas(ByVal inumPedido As Integer, ByVal NotaPruebas As String) As Boolean
        Dim CampoEnPruebas As Boolean = EnPruebas(inumPedido)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set NotaPruebas = @NotaPruebas, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("NotaPruebas", NotaPruebas)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return t

            Catch ex As Exception
                ex.Data.Add("inumPedido", inumPedido)
                ex.Data.Add("NotaPruebas", NotaPruebas)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function CambiaAcabando(ByVal inumPedido As Integer) As Boolean   'Cambia de estado el campo Acabando, devuelve el estado resultante
        Dim CampoAcabando As Boolean = Acabando(inumPedido)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set Acabando = @Acabando, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Acabando", Not CampoAcabando)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return Not CampoAcabando
                Else
                    Return False
                End If

            Catch ex As Exception
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function BAnular(ByVal inumPedido As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set bAnulado = @bAnulado, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("bAnulado", True)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
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
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try
        End Using
    End Function

    Public Function actualizaFechaEntrega(ByVal inumPedido As Integer, ByVal dFechaEntrega As Date) As Boolean   'Actualiza el estado
        If dFechaEntrega <> FechaEntrega(inumPedido) Then
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update Pedidos set FechaEntrega = @FechaEntrega, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("FechaEntrega", dFechaEntrega)
                    cmd.Parameters.AddWithValue("numPedido", inumPedido)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
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
                    ex.Data.Add("inumPedido", inumPedido)
                    CorreoError(ex)
                    Return False
                End Try

            End Using
        End If
    End Function

    Public Function actualizaFechaProduccion(ByVal inumPedido As Integer, ByVal dFechaEntrega As Date) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set fechaProduccion = @FechaEntrega, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("FechaEntrega", dFechaEntrega)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizaMoneda(ByVal inumPedido As Integer, ByVal scodMoneda As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Pedidos set codMoneda = @codMoneda, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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
                ex.Data.Add("inumPedido", inumPedido)
                ex.Data.Add("scodMoneda", scodMoneda)
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function borrar(ByVal inumPedido As Integer) As Boolean  ' Borra una cabecera de PedidoProv
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Pedidos where numPedido = " & inumPedido
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                ex.Data.Add("inumPedido", inumPedido)
                CorreoError(ex)
                Return 0
            End Try
        End Using

    End Function

    Public Function tieneNota(ByVal inumpedido As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "select notas from Pedidos where numPedido = " & inumpedido
        Using con As New SqlConnection(sconexion)
            Try
                Dim nota As String
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                nota = cmd.ExecuteScalar()
                con.Close()
                'MsgBox(nota)
                If nota <> "" Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function


End Class
