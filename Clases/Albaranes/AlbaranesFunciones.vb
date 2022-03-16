Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesAlbaranes

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sel0 As String = " Select DOC.*, subCliente, Clientes.NombreComercial as Cliente, TipoValorado, PRT.nombreComercial as AgenciaTransporte,Clientes.Observaciones as ObservacionesCli, Localidad + ', ' + Direccion as Direccion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo,TipoIVA, Estado, PR.NombreComercial as Proveedor, PR.Observaciones as ObservacionesProv, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TipoRecargoEq, TipoRetencion, TiposRetencion.Nombre as NombreTipoRetencion, C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosAlbaranes where numAlbaran = DOC.numAlbaran) as Base" _
             & " from Albaranes as DOC " _
             & " Left join Clientes ON Clientes.idCliente = DOC.idCliente " _
             & " left join Proveedores as PR ON PR.idProveedor = DOC.idProveedor " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Outer Join MediosPago ON MediosPago.idMedioPago = DOC.idMedioPago " _
             & " Left Outer Join TiposPago ON TiposPago.idTipoPago = DOC.idTipoPago " _
             & " Left Outer Join CuentasBancarias as CB ON CB.idCuentaBanco = DOC.idCuentaBanco " _
             & " Left Join Bancos ON Bancos.idBanco = CB.idBanco " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
             & " Left Join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipovalorado " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
             & " left outer join Proveedores as PRT ON PRT.idProveedor = DOC.idTransporte " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto "

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosAlbaran)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numAlbaran DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosAlbaran)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosAlbaran
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("numAlbaran") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'If Not simplificada Then 'Si no necesitamos los datos calculados, no llamamos a DatosCalculados
                        'Call DatosCalculados(dts)
                        'End If
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosAlbaran
        Dim dts As New DatosAlbaran
        Dim subCliente As String
        dts.gnumAlbaran = linea("NumAlbaran")
        dts.gReferenciaCliente = If(linea("ReferenciaCliente") Is DBNull.Value, "", linea("ReferenciaCliente"))
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
        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, "", linea("RecargoEquivalencia"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))
        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))
        dts.gBultos = If(linea("Bultos") Is DBNull.Value, 0, linea("Bultos"))
        dts.gKilosBrutos = If(linea("KilosBrutos") Is DBNull.Value, 0, linea("KilosBrutos"))
        dts.gKilosNetos = If(linea("KilosNetos") Is DBNull.Value, 0, linea("KilosNetos"))
        dts.gVolumen = If(linea("Volumen") Is DBNull.Value, 0, linea("Volumen"))
        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gReferenciaCliente2 = If(linea("ReferenciaCliente2") Is DBNull.Value, "", linea("ReferenciaCliente2"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
        dts.gMedidas = If(linea("Medidas") Is DBNull.Value, "", linea("Medidas"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gRecogido = If(linea("Recogido") Is DBNull.Value, False, linea("Recogido"))
        dts.gCreacion = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion"))
        'Datos de otras tablas
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        If dts.gidCliente > 0 Then
            dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
            dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))
        Else
            dts.gCliente = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
            dts.gObservacionesCli = If(linea("ObservacionesProv") Is DBNull.Value, "", linea("ObservacionesProv"))
        End If
        subCliente = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gDireccion = If(subCliente = "", dts.gDireccion, subCliente & ": " & dts.gDireccion)
        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))
        dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
        dts.gDivisa = UCase(If(linea("Divisa") Is DBNull.Value, "", linea("Divisa")))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
        dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))
        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dts.gAgenciaTransporte = If(linea("AgenciaTransporte") Is DBNull.Value, "", linea("AgenciaTransporte"))
        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gTotal = dts.gTotal
        Return dts

    End Function

    Public Function Mostrar1(ByVal inumAlbaran As Integer) As DatosAlbaran
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.numAlbaran = " & inumAlbaran
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosAlbaran
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("numAlbaran") Is DBNull.Value Then
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

    Public Function DatosCalculados(ByRef dts As DatosAlbaran) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, AR.KilosBrutos, AR.KilosNetos, AR.Bultos, AR.Volumen, TipoIVA, C1.numPedido, TipoRecargoEq from ConceptosAlbaranes as CO left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & "left join Articulos as AR ON AR.idArticulo = CO.idArticulo "
            sel = sel & " left outer join ConceptosPedidos as C1 ON C1.idConcepto= CO.idConceptoPedido "
            sel = sel & " where CO.numAlbaran = " & dts.gnumAlbaran
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim numSFactura As New List(Of Integer)
            Dim numSDevolucion As New List(Of Integer)
            Dim numSPedido As New List(Of Integer)
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
            Dim sumaKilosBrutos As Double = 0
            Dim sumaKilosNetos As Double = 0
            Dim sumaVolumen As Double = 0
            Dim sumaBultos As Double = 0
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

                    Dim numero As Integer = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))

                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSFactura, linea("numFactura"))
                        ' If linea("numFactura") <> 0 Then numSFactura.Add(linea("numFactura"))
                    End If


                    If linea("numDevolucion") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSDevolucion, linea("numDevolucion"))
                        'If linea("numDevolucion") <> 0 Then numSDevolucion.Add(linea("numDevolucion"))
                    End If

                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSPedido, linea("numPedido"))
                        'If linea("numPedido") <> 0 Then numSPedido.Add(linea("numPedido"))
                    End If
                    sumaKilosBrutos = sumaKilosBrutos + cantidad * If(linea("KilosBrutos") Is DBNull.Value, 0, linea("KilosBrutos"))
                    sumaKilosNetos = sumaKilosNetos + cantidad * If(linea("KilosNetos") Is DBNull.Value, 0, linea("KilosNetos"))
                    sumaBultos = sumaBultos + cantidad * If(linea("Bultos") Is DBNull.Value, 0, linea("Bultos"))
                    sumaVolumen = sumaVolumen + cantidad * If(linea("Volumen") Is DBNull.Value, 0, linea("Volumen"))
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
                dts.gnumSFactura = numSFactura
                dts.gnumSDevolucion = numSDevolucion
                dts.gnumSPedido = numSPedido
                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
                dts.gsumaKilosBrutos = sumaKilosBrutos
                dts.gsumaKilosNetos = sumaKilosNetos
                dts.gsumaBultos = sumaBultos
                dts.gsumaVolumen = sumaVolumen
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

    Private Sub NuevoNumeroEnLista(ByRef lista As List(Of Integer), ByVal nuevoNumero As Integer)
        If nuevoNumero > 0 Then
            Dim existe As Boolean = False
            For Each n As Integer In lista
                If n = nuevoNumero Then existe = True
            Next
            If Not existe Then lista.Add(nuevoNumero)
        End If
    End Sub

    Private Function Clonar(ByVal dts As DatosAlbaran) As DatosAlbaran
        Dim dtsN As New DatosAlbaran
        dtsN.gFecha = dts.gFecha
        dtsN.gFechaEntrega = dts.gFechaEntrega
        dtsN.gIBAN = dts.gIBAN
        dtsN.gidCliente = dts.gidCliente
        dtsN.gidContacto = dts.gidContacto
        dtsN.gidCuentaBanco = dts.gidCuentaBanco
        dtsN.gidEstado = dts.gidEstado
        dtsN.gidMedioPago = dts.gidMedioPago
        dtsN.gidPersona = dts.gidPersona
        dtsN.gidProveedor = dts.gidProveedor
        dtsN.gidTipoIVA = dts.gidTipoIVA
        dtsN.gidTipoPago = dts.gidTipoPago
        dtsN.gidTipoRetencion = dts.gidTipoRetencion
        dtsN.gidTipoValorado = dts.gidTipoValorado
        dtsN.gidTransporte = dts.gidTransporte
        dtsN.gidUbicacion = dts.gidUbicacion
        dtsN.gImporteDescuentos = dts.gImporteDescuentos
        dtsN.gImportePP = dts.gImportePP
        dtsN.gKilosBrutos = dts.gKilosBrutos
        dtsN.gKilosNetos = dts.gKilosNetos
        dtsN.gMedidas = dts.gMedidas
        dtsN.gMedioPago = dts.gMedioPago
        dtsN.gNombreTipoIVA = dts.gNombreTipoIVA
        dtsN.gNombreTipoRetencion = dts.gNombreTipoRetencion
        dtsN.gNotas = dts.gNotas
        dtsN.gnumAlbaran = dts.gnumAlbaran
        dtsN.gnumSDevolucion = dts.gnumSDevolucion
        dtsN.gnumSFactura = dts.gnumSFactura
        dtsN.gnumSPedido = dts.gnumSPedido
        dtsN.gObservaciones = dts.gObservaciones
        dtsN.gObservacionesCli = dts.gObservacionesCli
        dtsN.gPersona = dts.gPersona
        dtsN.gPortes = dts.gPortes
        dtsN.gPrecioTransporte = dts.gPrecioTransporte
        dtsN.gProntoPago = dts.gProntoPago
        dtsN.gProveedor = dts.gProveedor
        dtsN.gRecargoEquivalencia = dts.gRecargoEquivalencia
        dtsN.gReferenciaCliente = dts.gReferenciaCliente
        dtsN.gReferenciaCliente2 = dts.gReferenciaCliente2
        dtsN.gRetencion = dts.gRetencion
        dtsN.gSimbolo = dts.gSimbolo
        dtsN.gSolicitadoVia = dts.gSolicitadoVia
        dtsN.gsumaBultos = dts.gsumaBultos
        dtsN.gsumaKilosBrutos = dts.gsumaKilosBrutos
        dtsN.gsumaKilosNetos = dts.gsumaKilosNetos
        dtsN.gsumaVolumen = dts.gsumaVolumen
        dtsN.gTipoIVA = dts.gTipoIVA
        dtsN.gTipoPago = dts.gTipoPago
        dtsN.gTipoRecargoEq = dts.gTipoRecargoEq
        dtsN.gTipoRetencion = dts.gTipoRetencion
        dtsN.gTipoValorado = dts.gTipoValorado
        dtsN.gTotal = dts.gTotal
        dtsN.gTotalIVA = dts.gTotalIVA
        dtsN.gTotalRE = dts.gTotalRE
        dtsN.gTransporte = dts.gTransporte
        dtsN.gVolumen = dts.gVolumen
        Return dts
    End Function

    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla AlbaranesProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM Albaranes", con)
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

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla AlbaranesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM Albaranes", con)
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
                sel = "SELECT MAX(numAlbaran FROM Albaranes "
            Else
                sel = "SELECT MAX(numAlbaran) FROM Albaranes where idCliente = " & iidCliente
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

    Public Function idCliente(ByVal inumAlbaran As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT idCliente FROM Albaranes where numAlbaran = " & inumAlbaran

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

    Public Function idUbicacion(ByVal inumAlbaran As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT idUbicacion FROM Albaranes where numAlbaran = " & inumAlbaran

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
            Dim inumAlbaran As Integer = buscaUltimoDoc(iidCliente)
            If inumAlbaran = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Albaranes where numAlbaran = " & inumAlbaran
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

    Public Function ReferenciaCliente(ByVal inumAlbaran As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Albaranes Where numAlbaran = " & inumAlbaran, con)
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

    Public Function ExistenumAlbaranCli(ByVal inumAlbaran As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el albarán, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el albarán.
        Try
            If inumAlbaran = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Albaranes Where numAlbaran = " & inumAlbaran
                Else
                    sel = "SELECT idCliente FROM Albaranes Where numAlbaran = " & inumAlbaran & " AND idCliente = " & iidCliente
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

    Public Function ExistenumAlbaranProv(ByVal inumAlbaran As Integer, ByVal iidProveedor As Integer) As Integer
        'Nos dice si existe el albarán, devolviendo el idProveedor.
        'Si indicamos el idProveedor, devuelve el idProveedor si existe el albarán.
        Try
            If inumAlbaran = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidProveedor = 0 Then
                    sel = "SELECT idProveedor FROM Albaranes Where numAlbaran = " & inumAlbaran
                Else
                    sel = "SELECT idProveedor FROM Albaranes Where numAlbaran = " & inumAlbaran & " AND idProveedor = " & iidProveedor
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

    Public Function idEstado(ByVal inumAlbaran As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Albaranes Where numAlbaran = " & inumAlbaran, con)
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

    Public Function codMoneda(ByVal inumAlbaran As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT codMoneda FROM Albaranes Where numAlbaran = " & inumAlbaran, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function idTipoIVA(ByVal inumAlbaran As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Albaranes Where numAlbaran = " & inumAlbaran, con)
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
                cmd = New SqlCommand("SELECT COUNT(*) FROM Albaranes", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Albaranes WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna Albaran
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreComercial, Albaranes.idCliente from Albaranes left Join Clientes ON Clientes.idCliente = Albaranes.idCliente ", con)
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de Albaranes existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numAlbaran FROM Albaranes ORDER BY numAlbaran DESC", con)
            Else
                cmd = New SqlCommand("SELECT numAlbaran FROM Albaranes WHERE YEAR(Fecha) = " & Any & " ORDER BY numAlbaran DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numAlbaran") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numAlbaran"))
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

    Public Function NumsPedido(ByVal inumAlbaran As Integer) As List(Of Integer) ' Busca el pedido que corresponde a un albarán
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select distinct numPedido from ConceptosPedidos where numAlbaran = " & inumAlbaran
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
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
                        lista.Add(linea("numPedido"))
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

    Public Function NumsFactura(ByVal inumAlbaran As Integer) As List(Of Integer) ' Busca el pedido que corresponde a un albarán
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select distinct CF.numFactura from ConceptosFacturas as CF left join ConceptosAlbaranes as CA ON CA.idConcepto = CF.idConceptoAlbaran  where CA.numAlbaran = " & inumAlbaran
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                'Dim subCliente As String
                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numFactura"))
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

    Public Function insertar(ByVal dts As DatosAlbaran) As Integer 'Inserta una nueva Albaran y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumAlbaran = gMaster.incnumAlbaran(Year(dts.gFecha))
        If dts.gnumAlbaran = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Albaranes (numAlbaran, ReferenciaCliente, idEstado, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, idMedioPago, idTipoPago, "
            sel = sel & " idCuentaBanco, codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia, Descuento, Descuento2, ProntoPago, SolicitadoVia, Notas, Observaciones, "
            sel = sel & " idTipoValorado, Portes, Bultos, KilosBrutos, KilosNetos, Volumen, idTransporte, Transporte,ReferenciaCliente2,idPersona,PrecioTransporte, medidas, idProveedor,Recogido, idCreador, Creacion, idrazonsocial) "
            sel = sel & " values (@numAlbaran, @ReferenciaCliente, @idEstado, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto,@idMedioPago,@idTipoPago, "
            sel = sel & " @idCuentaBanco,@codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@Descuento,@Descuento2,@ProntoPago,@SolicitadoVia,@Notas,@Observaciones, "
            sel = sel & " @idTipoValorado,@Portes,@Bultos,@KilosBrutos,@KilosNetos,@Volumen,@idTransporte, @Transporte,@ReferenciaCliente2, @idPersona,@PrecioTransporte, @medidas,  @idProveedor,@Recogido, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1) )"
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                    cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
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
                    cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                    cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                    cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                    cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                    cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                    cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                    cmd.Parameters.AddWithValue("ReferenciaCliente2", dts.gReferenciaCliente2)
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("Medidas", dts.gMedidas)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("Recogido", dts.gRecogido)
                    'cmd.Parameters.AddWithValue("FechaPreparado", dts.gFechaPreparado)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumAlbaran
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If
    End Function

    Public Function actualizar(ByVal dts As DatosAlbaran) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Albaranes set numAlbaran = @numAlbaran, ReferenciaCliente = @ReferenciaCliente, idEstado = @idEstado, Fecha = @Fecha, FechaEntrega = @FechaEntrega, "
        sel = sel & " idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, idCuentaBanco = @idCuentaBanco, "
        sel = sel & " codMoneda = @codMoneda, idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, Descuento = @Descuento, "
        sel = sel & " Descuento2 = @Descuento2, ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, Notas = @Notas, Observaciones = @Observaciones,idTipoValorado = @idTipoValorado,idPersona = @idPersona, "
        sel = sel & " Portes = @Portes, Bultos = @Bultos, KilosBrutos = @KilosBrutos, KilosNetos = @KilosNetos, Volumen =@Volumen, idTransporte = @idTransporte, Transporte =@Transporte,ReferenciaCliente2 = @ReferenciaCliente2, "
        sel = sel & " PrecioTransporte = @PrecioTransporte, medidas = @medidas, idProveedor = @idProveedor ,Recogido = @Recogido, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numAlbaran = @numAlbaran"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
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
                cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("ReferenciaCliente2", dts.gReferenciaCliente2)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("Medidas", dts.gMedidas)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("Recogido", dts.gRecogido)
                'cmd.Parameters.AddWithValue("FechaPreparado", dts.gFechaPreparado)

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
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizaEstado(ByVal inumAlbaran As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Albaranes set idEstado = @idEstado where numAlbaran = @numAlbaran "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numAlbaran", inumAlbaran)
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

    Public Function ServirAlbaran(ByVal inumAlbaran As Integer, ByVal ReferenciaCliente2 As String, ByVal FechaEntrega As Date, ByVal iidEstado As Integer, ByVal iidTransporte As Integer, ByVal Transporte As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Albaranes set ReferenciaCliente2 = @ReferenciaCliente2, FechaEntrega = @FechaEntrega, idEstado = @idEstado, idTransporte = @idTransporte, Transporte = @Transporte, Recogido = @Recogido where numAlbaran = @numAlbaran "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("ReferenciaCliente2", ReferenciaCliente2)
                cmd.Parameters.AddWithValue("FechaEntrega", FechaEntrega)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numAlbaran", inumAlbaran)
                cmd.Parameters.AddWithValue("idTransporte", iidTransporte)
                cmd.Parameters.AddWithValue("Transporte", Transporte)
                cmd.Parameters.AddWithValue("Recogido", True)
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

    Public Function actualizaMoneda(ByVal inumAlbaran As Integer, ByVal scodMoneda As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Albaranes set codMoneda = @codMoneda where numAlbaran = @numAlbaran "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numAlbaran", inumAlbaran)
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

    Public Function borrar(ByVal inumAlbaran As Integer) As Boolean  ' Borra una cabecera de AlbaranProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Albaranes where numAlbaran = " & inumAlbaran
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
            Finally
                desconectado()
            End Try
        End Using

    End Function

End Class