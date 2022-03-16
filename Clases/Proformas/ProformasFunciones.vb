Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesProformas


    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " Select DOC.*, Clientes.NombreFiscal as Cliente,Clientes.Observaciones as ObservacionesCli,subCliente, Localidad + ', ' + Direccion as Direccion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo,TipoIVA, Estado, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TipoRecargoEq, TipoRetencion, TiposRetencion.Nombre as NombreTipoRetencion,   C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosProformas where numProforma = DOC.numProforma) as Base" _
             & " from Proformas as DOC " _
             & " Left join Clientes ON Clientes.idCliente = DOC.idCliente " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Outer Join MediosPago ON MediosPago.idMedioPago = DOC.idMedioPago " _
             & " Left Outer Join TiposPago ON TiposPago.idTipoPago = DOC.idTipoPago " _
             & " Left Outer Join CuentasBancarias as CB ON CB.idCuentaBanco = DOC.idCuentaBanco " _
             & " Left Join Bancos ON Bancos.idBanco = CB.idBanco " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosProforma)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numProforma DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosProforma)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosProforma
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numProforma") Is DBNull.Value Then
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
        Dim dts As New DatosProforma
        dts.gnumProforma = linea("NumProforma")
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
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))

        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
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
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        Return dts
    End Function



    Public Function Mostrar1(ByVal inumProforma As Integer) As DatosProforma
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.numProforma = " & inumProforma
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosProforma
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numProforma") Is DBNull.Value Then
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


    Public Function DatosCalculados(ByRef dts As DatosProforma) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, numOferta, TipoIVA, TipoRecargoEq from ConceptosProformas as CO left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " LEFT outer join ConceptosOfertas ON ConceptosOfertas.idConcepto = CO.idConceptoOferta "
            sel = sel & " where CO.numProforma = " & dts.gnumProforma
            cmd = New SqlCommand(sel, con)
            'Dim lista As New List(Of DatosProformaProv)
            Dim linea As DataRow
            Dim numSPedido As New List(Of Integer)
            'Dim numSProduccion As New List(Of Integer)
            Dim numSOferta As New List(Of Integer)

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


                    'If linea("numPedido") Is DBNull.Value Then
                    'Else
                    '    If linea("numPedido") <> 0 Then numSPedido.Add(linea("numPedido"))
                    'End If
                    'If linea("numOferta") Is DBNull.Value Then
                    'Else
                    '    If linea("numOferta") <> 0 Then numSOferta.Add(linea("numOferta"))
                    'End If

                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSPedido, linea("numPedido"))
                    End If

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
                dts.gnumSPedido = numSPedido
                'dts.gnumSProduccion = numSProduccion
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





    Private Sub NuevoNumeroEnLista(ByRef lista As List(Of Integer), ByVal nuevoNumero As Integer)
        If nuevoNumero > 0 Then
            Dim existe As Boolean = False
            For Each n As Integer In lista
                If n = nuevoNumero Then existe = True
            Next
            If Not existe Then lista.Add(nuevoNumero)
        End If
    End Sub


    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla ProformasProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM Proformas", con)
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

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla ProformasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM Proformas", con)
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
                sel = "SELECT MAX(numProforma) FROM Proformas "
            Else
                sel = "SELECT MAX(numProforma) FROM Proformas where idCliente = " & iidCliente
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
            Dim inumProforma As Integer = buscaUltimoDoc(iidCliente)
            If inumProforma = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Proformas where numProforma = " & inumProforma
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

    Public Function ReferenciaCliente(ByVal inumProforma As Integer) As String ' Busca la última fecha dentro de la tabla ProformasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Proformas Where numProforma = " & inumProforma, con)
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

    Public Function idEstado(ByVal inumProforma As Integer) As Integer ' Busca la última fecha dentro de la tabla ProformasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Proformas Where numProforma = " & inumProforma, con)
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


    Public Function idTipoIVA(ByVal inumProforma As Integer) As Integer ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Proformas Where numProforma = " & inumProforma, con)
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
                cmd = New SqlCommand("SELECT COUNT(*) FROM Proformas", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Proformas WHERE  " & busqueda, con)
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


    Public Function ExisteNumProforma(ByVal inumProforma As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el Proforma, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el Proforma.
        Try
            If inumProforma = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Proformas Where numProforma = " & inumProforma
                Else
                    sel = "SELECT idCliente FROM Proformas Where numProforma = " & inumProforma & " AND idCliente = " & iidCliente
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

    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna Proforma
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreFiscal, Proformas.idCliente from Proformas left Join Clientes ON Clientes.idCliente = Proformas.idCliente ", con)
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





    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de Proformas existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numProforma FROM Proformas ORDER BY numProforma DESC", con)
            Else
                cmd = New SqlCommand("SELECT numProforma FROM Proformas WHERE YEAR(Fecha) = " & Any & " ORDER BY numProforma DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numProforma") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numProforma"))
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







    Public Function insertar(ByVal dts As DatosProforma) As Integer 'Inserta una nueva Proforma y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumProforma = gMaster.incnumProforma(Year(dts.gFecha))
        If dts.gnumProforma = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Proformas (numProforma, ReferenciaCliente, idEstado, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, idMedioPago, idTipoPago, idCuentaBanco, codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia, Descuento, Descuento2, ProntoPago, SolicitadoVia, Notas, Observaciones,idPersona, Portes, PrecioTransporte, idCreador, Creacion, idrazonsocial ) "
            sel = sel & " values (@numProforma, @ReferenciaCliente, @idEstado, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto,@idMedioPago,@idTipoPago,@idCuentaBanco,@codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@Descuento,@Descuento2,@ProntoPago,@SolicitadoVia,@Notas,@Observaciones, @idPersona,@Portes, @PrecioTransporte, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1)  )"
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
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
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumProforma
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If

    End Function

    Public Function actualizar(ByVal dts As DatosProforma) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Proformas set numProforma = @numProforma, ReferenciaCliente = @ReferenciaCliente, idEstado = @idEstado, Fecha = @Fecha, FechaEntrega = @FechaEntrega, idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, idCuentaBanco = @idCuentaBanco, codMoneda = @codMoneda, "
        sel = sel & " idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, Descuento = @Descuento, Descuento2 = @Descuento2, ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, Notas = @Notas, Observaciones = @Observaciones, idPersona = @idPersona,Portes = @Portes, PrecioTransporte = @PrecioTransporte, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numProforma = @numProforma"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
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
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
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



    Public Function actualizaEstado(ByVal inumProforma As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Proformas set idEstado = @idEstado where numProforma = @numProforma "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numProforma", inumProforma)
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

    Public Function actualizaMoneda(ByVal inumProforma As Integer, ByVal scodMoneda As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Proformas set codMoneda = @codMoneda where numProforma = @numProforma "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numProforma", inumProforma)
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



    Public Function borrar(ByVal inumProforma As Integer) As Boolean  ' Borra una cabecera de ProformaProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Proformas where numProforma = " & inumProforma
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
