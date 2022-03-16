Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesPedidosProv


    Inherits conexion
    Dim cmd As SqlCommand

    Dim sel0 As String = " Select DOC.*, Proveedores.NombreComercial as Proveedor, Proveedores.codProveedor,Proveedores.Observaciones as ObservacionesProv, Localidad + ', ' + Direccion as Direccion, " _
                & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, Divisa, Simbolo, TiposIVA.TipoIVA as TipoIVATabla, Estado, AT.nombreComercial as AgenciaTransporte, " _
                & " TiposIVA.Nombre as NombreTipoIVA, TipoRecargoEq as TipoRecargoEqTabla, TiposRetencion.TipoRetencion as TipoRetencionTabla, C2.Nombre + ' ' + C2.Apellidos as Persona, TipoValorado " _
                & " from PedidosProv as DOC " _
                & " Left join Proveedores ON Proveedores.idProveedor = DOC.idProveedor " _
                & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
                & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
                & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
                & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
                & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
                & " Left Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
                & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
                & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto " _
                & " Left join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipoValorado" _
                & " left outer join Proveedores AS AT ON AT.idProveedor = DOC.idTransporte "
    '& " (select sum( Cantidad * precioNetoUnitario * (1- (Descuento/100)))  from ConceptosPedidosProv where numPedido = DOC.numPedido) as Base" _
    'El campo PrecioNetoUnitario se usa como campo de precio sobre el que se aplica el descuento. el PVPUnitario no se usa

    Public Function Mostrar() As List(Of DatosPedidoProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " Order By numPedido DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosPedidoProv
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Calculados
                        ' If simplificada Then
                        'dts.gBase = dts.gBase * (1 - (dts.gDescuento / 100))
                        'Else
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
    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosPedidoProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numPedido DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosPedidoProv
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Calculados
                        If simplificada Then
                            'dts.gBase = dts.gBase * (1 - (dts.gDescuento / 100))
                        Else
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
    Private Function CargarLinea(ByVal linea As DataRow) As DatosPedidoProv
        Dim dts As New DatosPedidoProv
        dts.gnumPedido = linea("NumPedido")
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gPedidoProveedor = If(linea("PedidoProveedor") Is DBNull.Value, "", linea("PedidoProveedor"))
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gFechaPedido = If(linea("FechaPedido") Is DBNull.Value, Now.Date, linea("FechaPedido"))
        dts.gFechaEntrega = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))
        dts.gidTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
        dts.gHorarioEntrega = If(linea("HorarioEntrega") Is DBNull.Value, "", linea("HorarioEntrega"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gPagado = If(linea("Pagado") Is DBNull.Value, False, linea("Pagado"))
        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))
        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gTipoIVAFac = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
        dts.gTipoRetencionFac = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))

        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dts.gTotalIVA = If(linea("TotalIVA") Is DBNull.Value, 0, linea("TotalIVA"))
        dts.gRetencion = If(linea("Retencion") Is DBNull.Value, 0, linea("Retencion"))
        dts.gTotal = If(linea("Total") Is DBNull.Value, 0, linea("Total"))
        'Otras tablas
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gcodProveedor = If(linea("codProveedor") Is DBNull.Value, "", linea("codProveedor"))
        dts.gTipoIVA = If(linea("TipoIVATabla") Is DBNull.Value, 0, linea("TipoIVATabla"))
        dts.gTipoRetencion = If(linea("TipoRetencionTabla") Is DBNull.Value, 0, linea("TipoRetencionTabla"))
        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gObservacionesProv = If(linea("ObservacionesProv") Is DBNull.Value, "", linea("ObservacionesProv"))
        dts.gAgenciaTransporte = If(linea("AgenciaTransporte") Is DBNull.Value, "", linea("AgenciaTransporte"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))

        Return dts
    End Function
    Public Function Mostrar1(ByVal inumPedido As Integer) As DatosPedidoProv  'Búsqueda genérica partir de una cadena SQL
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE numPedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosPedidoProv
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        'Calculados
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
    Public Function DatosCalculados(ByRef dts As DatosPedidoProv) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.* from ConceptosPedidosProv as CO  "

            sel = sel & " where CO.numPedido = " & dts.gnumPedido
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            Dim numSAlbaran As New List(Of Integer)
            Dim numSProduccion As New List(Of Integer)

            Dim listaIVAs As New List(Of DatosImportesIVAProv)
            Dim Base As Double = 0 'Suma de precios con todos los descuentos
            Dim TotalIVA As Double = 0
            Dim TotalRE As Double = 0
            Dim subTotal As Double = 0
            Dim subTotalPP As Double = 0
            Dim descuento As Double = 0 'Descuento de linea
            Dim DescuentoC As Double = 0

            Dim sumaDescuentos As Double = 0
            Dim sumaDescuentosPP As Double = 0
            Dim precioNetoUnitario As Double = 0
            Dim TipoIVAlinea As Double = 0
            Dim TipoIVA As Double = 0
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

                    precioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                    PVP = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
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
                    subTotalPP = subTotal * (1 - (dts.gDescuento / 100))
                    Base = Base + subTotalPP
                    TotalIVA = TotalIVA + (subTotalPP * (If(linea("TipoIVA") Is DBNull.Value, 0, CDbl(linea("TipoIVA")) / 100)))  'El IVA se calcula sobre el importe neto con todos los descuentos
                  
                    sumaDescuentosPP = sumaDescuentosPP + subTotal * (dts.gDescuento / 100)
                    TipoIVAlinea = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))

                   

                Next
                dts.gImporteDescuentos = sumaDescuentos
                dts.gImporteDescuentoGeneral = sumaDescuentosPP
              
                If dts.gPortes = "P" Or dts.gPortes = "D" Then
                    dts.gBase = Base  'Antes de descuentos generales
                    dts.gTotalIVA = TotalIVA
                Else 'Portes en factura
                    dts.gBase = Base + dts.gPrecioTransporte
                    dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dts.gTipoIVA / 100)
                End If

                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA - dts.gRetencion '+ dts.gTotalRE 
                Call actualizarTotales(dts)
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

    Private Function ContieneEn(ByVal lista As List(Of DatosImportesIVAProv), ByVal TipoIVA As Double) As Integer
        If lista Is Nothing Then
            Return -1
        End If
        Dim Resultado As Boolean = False
        For i As Integer = 0 To lista.Count - 1
            If lista(i).gTipoIVA = TipoIVA Then Return i
        Next
    End Function



    Public Function ListaEstados() As List(Of DatosEstado) 'Estados usados en algún pedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Distinct ES.* from PedidosProv as PP left join Estados as ES ON PP.idEstado = ES.idEstado Order by Estado"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEstado)
            Dim dts As DatosEstado
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    dts = New DatosEstado
                    dts.gidEstado = linea("idEstado")
                    dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
                    dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
                    dts.gAplicacion = If(linea("Aplicacion") Is DBNull.Value, 0, linea("Aplicacion"))
                    dts.gCabecera = If(linea("Cabecera") Is DBNull.Value, False, linea("Cabecera"))
                    dts.gEspera = If(linea("Espera") Is DBNull.Value, False, linea("Espera"))
                    dts.gEnCurso = If(linea("EnCurso") Is DBNull.Value, False, linea("EnCurso"))
                    dts.gBloqueado = If(linea("Bloqueado") Is DBNull.Value, False, linea("Bloqueado"))
                    dts.gTraspasado = If(linea("Traspasado") Is DBNull.Value, False, linea("Traspasado"))
                    dts.gAnulado = If(linea("Anulado") Is DBNull.Value, False, linea("Anulado"))
                    dts.gAutomatico = If(linea("Automatico") Is DBNull.Value, False, linea("Automatico"))
                    dts.gEntregado = If(linea("Entregado") Is DBNull.Value, False, linea("Entregado"))
                    dts.gCompleto = If(linea("Completo") Is DBNull.Value, False, linea("Completo"))
                    lista.Add(dts)
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

  
    Public Function ExisteNumPedidoProv(ByVal inumPedidoProv As Integer, ByVal iidProveedor As Integer) As Integer
        'Nos dice si existe el PedidoProv, devolviendo el idProveedor.
        'Si indicamos el idProveedor, devuelve el idProveedor si existe el PedidoProv.
        Try
            If inumPedidoProv = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidProveedor = 0 Then
                    sel = "SELECT idProveedor FROM PedidosProv Where numPedidoProv = " & inumPedidoProv
                Else
                    sel = "SELECT idProveedor FROM PedidosProv Where numPedidoProv = " & inumPedidoProv & " AND idProveedor = " & iidProveedor
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




    Public Function idIdioma(ByVal iinumPedido As Integer) As Integer  'Nos dice el idioma de un pedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("Select idIdioma FROM PedidosProv left join Ubicaciones ON Ubicaciones.idUbicacion = PedidosProv.idUbicacion WHERE numPedido  = " & iinumPedido, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function buscaPrimerDia(ByVal iidProveedor As Integer) As Date  ' Busca la primera fecha dentro de la tabla PedidosProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidProveedor = 0 Then
                sel = "SELECT MIN(FechaPedido) FROM PedidosProv"
            Else
                sel = "SELECT MIN(FechaPedido) FROM PedidosProv WHERE idProveedor = " & iidProveedor
            End If
            cmd = New SqlCommand(sel, con)
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

    Public Function buscaUltimoDia(ByVal iidProveedor As Integer) As Date ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidProveedor = 0 Then
                sel = "SELECT MAX(FechaPedido) FROM PedidosProv"
            Else
                sel = "SELECT MAX(FechaPedido) FROM PedidosProv WHERE idProveedor = " & iidProveedor
            End If
            cmd = New SqlCommand(sel, con)
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

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM PedidosProv", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM PedidosProv WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


   

    Public Function buscaUltimoDoc(ByVal iidProveedor As Integer) As Integer ' Busca el último documento de un Proveedor dado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidProveedor = 0 Then
                sel = "SELECT MAX(numPedido) FROM PedidosProv "
            Else
                sel = "SELECT MAX(numPedido) FROM PedidosProv where idProveedor = " & iidProveedor
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

    Public Function UltimoPrecioTransporte(ByVal iidProveedor As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim inumPedido As Integer = buscaUltimoDoc(iidProveedor)
            If inumPedido = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM PedidosProv where numPedido = " & inumPedido
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



    Public Function listaProveedores() As DataTable 'lista de proveedores con algún pedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT Proveedores.nombreComercial, Proveedores.idProveedor, PedidosProv.idProveedor, Proveedores.NIF FROM Proveedores   RIGHT JOIN  PedidosProv  ON  PedidosProv.idProveedor = Proveedores.idProveedor ORDER BY Proveedores.nombreComercial ", con)
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



    Public Function listaProveedores(ByVal vTipo As Integer) As DataTable 'lista de proveedores con algún pedido
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT Proveedores.nombreComercial, Proveedores.idProveedor,PedidosProv.idProveedor, Proveedores.NIF FROM Proveedores  left join TiposCompra ON TiposCompra.IdTipoCompra = Proveedores.IdTipoCompra RIGHT JOIN  PedidosProv  ON  PedidosProv.idProveedor = Proveedores.idProveedor WHERE Proveedores.idTipoCompra = " & vTipo & " ORDER BY Proveedores.nombreComercial ", con)
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



    Public Function listaNumPedidos(ByVal vTipo As Integer) As DataTable 'lista de números de pedidos existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If vTipo = -1 Then
                cmd = New SqlCommand("SELECT PedidosProv.numPedido FROM PedidosProv ORDER BY PedidosProv.numPedido DESC", con)
            Else
                cmd = New SqlCommand("SELECT PedidosProv.numPedido FROM PedidosProv left join Proveedores on Proveedores.idProveedor = PedidosProv.idProveedor WHERE Proveedores.idTipoCompra= " & vTipo & " ORDER BY PedidosProv.numPedido DESC", con)
            End If
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


    Public Function listaPedidoProveedor(ByVal vTipo As Integer) As DataTable 'lista de números de pedidos existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If vTipo = -1 Then
                cmd = New SqlCommand("SELECT PedidosProv.PedidoProveedor FROM PedidosProv ORDER BY PedidosProv.numPedido DESC", con)
            Else
                cmd = New SqlCommand("SELECT PedidosProv.PedidoProveedor FROM PedidosProv left join Proveedores on Proveedores.idProveedor = PedidosProv.idProveedor WHERE Proveedores.idTipoCompra= " & vTipo & " ORDER BY PedidosProv.numPedido DESC", con)
            End If
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

    Public Function insertar(ByVal dts As DatosPedidoProv) As Integer 'Inserta un nuevo pedido en la tabla PedidosProv y devuelve el numAlbaran generado

        Dim gMaster As New Master()

        dts.gnumPedido = gMaster.incnumPedidoProv(Year(dts.gFechaPedido))
        If dts.gnumPedido = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into PedidosProv (numPedido, idProveedor,PedidoProveedor,  SolicitadoVia, idUbicacion, idTipoIVA, Observaciones, FechaPedido, FechaEntrega, idTipoCompra, HorarioEntrega, codMoneda, idPersona, idContacto, idTransporte, Transporte, Portes,Descuento, Pagado,idTipoValorado, Notas, idEstado, TipoIVA, PrecioTransporte,idTipoRetencion, TipoRetencion, idCreador, Creacion, idrazonsocial ) "
            sel = sel & " values (@numPedido, @idProveedor,@PedidoProveedor,  @SolicitadoVia, @idUbicacion, @idTipoIVA, @Observaciones, @FechaPedido, @FechaEntrega, @idTipoCompra, @HorarioEntrega, @codMoneda, @idPersona,@idContacto,@idTransporte,@Transporte,@Portes,@Descuento,@Pagado,@idTipoValorado,@Notas, @idEstado,@TipoIVA, @PrecioTransporte,@idTipoRetencion, @TipoRetencion, @idCreador, @Creacion, (select idrazonsocial from razonsocial where activa= 1))"
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("PedidoProveedor", dts.gPedidoProveedor)
                    cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                    cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                    cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                    cmd.Parameters.AddWithValue("observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("FechaPedido", dts.gFechaPedido)
                    cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                    cmd.Parameters.AddWithValue("idTipoCompra", dts.gidTipoCompra)
                    cmd.Parameters.AddWithValue("HorarioEntrega", dts.gHorarioEntrega)
                    cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                    cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                    cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                    cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                    cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                    cmd.Parameters.AddWithValue("Pagado", dts.gPagado)
                    cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                    cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                    cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                    cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                    cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                    cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumPedido
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If

    End Function

    Public Function actualizar(ByVal dts As DatosPedidoProv) As Boolean   'Actualiza un registro de la tabla PedidosProv
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update PedidosProv set idProveedor = @idProveedor, PedidoProveedor = @PedidoProveedor, SolicitadoVia = @SolicitadoVia,  idUbicacion = @idUbicacion, "
        sel = sel & " idTipoIVA = @idTipoIVA, observaciones = @observaciones,FechaPedido = @FechaPedido, FechaEntrega = @FechaEntrega,  idTipoCompra = @idTipoCompra,"
        sel = sel & " HorarioEntrega = @HorarioEntrega, codMoneda = @codMoneda, idPersona = @idPersona, idContacto = @idContacto,idTransporte = @idTransporte, "
        sel = sel & " Transporte = @Transporte, Portes = @Portes, Descuento = @Descuento, Pagado = @Pagado, idTipoValorado = @idTipoValorado, Notas = @Notas, "
        sel = sel & " idEstado = @idEstado, TipoIVA = @TipoIVA, PrecioTransporte = @PrecioTransporte, TipoRetencion = @TipoRetencion, idTipoRetencion = @idTipoRetencion, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("PedidoProveedor", dts.gPedidoProveedor)
                cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("FechaPedido", dts.gFechaPedido)
                cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                cmd.Parameters.AddWithValue("idTipoCompra", dts.gidTipoCompra)
                cmd.Parameters.AddWithValue("HorarioEntrega", dts.gHorarioEntrega)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Pagado", dts.gPagado)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
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

    Public Function actualizarTotales(ByVal dts As DatosPedidoProv) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update PedidosProv set Base = @Base, TotalIVA = @TotalIVA, Retencion = @Retencion, Total = @Total where numPedido = @numPedido "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("Retencion", dts.gRetencion)
                cmd.Parameters.AddWithValue("Total", dts.gTotal)

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

    Public Function actualizaEstado(ByVal inumPedido As Integer, ByVal idEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update PedidosProv set idEstado = @idEstado where numPedido = @numPedido "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", idEstado)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
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


    Public Function actualizaMoneda(ByVal inumPedido As Integer, ByVal scodMoneda As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update PedidosProv set codMoneda = @codMoneda, idModifica = @idModifica, Modificacion = @Modificacion where numPedido = @numPedido "

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
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function borrar(ByVal numPedidoProv As Integer) As Integer  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from PedidosProv where numPedido = " & numPedidoProv
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
