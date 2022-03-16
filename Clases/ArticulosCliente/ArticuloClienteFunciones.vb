Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesArticuloCliente
    Inherits conexion
    Dim cmd As SqlCommand

    'Private funcACP As New funcionesArticuloClientePrecios
    Private funcFA As New funcionesFacturacion

    Public Function mostrarCliente(ByVal iidCliente As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloCliente)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloCliente)
            sel = "select PC.*, Articulo, TipoArticulo, subTipoArticulo, codArticulo, codCli, NombreComercial as Cliente from ArticuloCliente as PC "
            sel = sel & " left join Articulos on Articulos.idArticulo = PC.idArticulo "
            sel = sel & " left join Clientes ON Clientes.idCliente = PC.idCliente "
            'sel = sel & " left outer join ArticuloClientePrecios as ACP on ACP.idArtCli = PC.idArtCli and ACP.Activo = 1 "
            'sel = sel & " left join Monedas on Monedas.codMoneda = ACP.codMoneda "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " left join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo "
            sel = sel & " where idCliente = " & iidCliente & If(soloActivos, " AND Activo = 1 ", "")

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim funcACP As New funcionesArticuloClientePrecios
                Dim dts As DatosArticuloCliente
                Dim dtsACP As DatosArticuloClientePrecio
                Dim dtsFA As datosfacturacion
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCli") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloCliente
                        dts.gIdArtCli = linea("idArtCli")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, "", linea("numDoc"))
                        dts.gtipoDoc = If(linea("TipoDoc") Is DBNull.Value, "", linea("TipoDoc"))



                        'dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        'dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        'dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, 0, linea("codCli"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gsubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))

                        dtsACP = funcACP.mostrarArtCli(dts.gIdArtCli)
                        If dtsACP.gidArtCliPrecio = 0 Then
                            dtsFA = funcFA.mostrarCli(dts.gidCliente)
                            dts.gPrecioNetoUnitario = 0
                            dts.gcodMoneda = dtsFA.gcodMoneda
                            dts.gSimbolo = dtsFA.gSimbolo
                        Else
                            dts.gPrecioNetoUnitario = dtsACP.gPrecioNetoUnitario
                            dts.gcodMoneda = dtsACP.gcodMoneda
                            dts.gSimbolo = dtsACP.gSimbolo
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


    Public Function mostrarArticulo(ByVal iidArticulo As Integer, ByVal soloActivos As Boolean) As List(Of DatosArticuloCliente)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosArticuloCliente)
            sel = "select PC.*, Articulo, TipoArticulo, subTipoArticulo, codArticulo, codCli, NombreComercial as Cliente from ArticuloCliente as PC "
            sel = sel & " left join Articulos on Articulos.idArticulo = PC.idArticulo "
            sel = sel & " left join Clientes ON Clientes.idCliente = PC.idCliente "
            'sel = sel & " left outer join ArticuloClientePrecios as ACP on ACP.idArtCli = PC.idArtCli and ACP.Activo = 1 "
            'sel = sel & " left join Monedas on Monedas.codMoneda = ACP.codMoneda "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " left join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo "
            sel = sel & " where idArticulo = " & iidArticulo & If(soloActivos, " AND Activo = 1 ", "")

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dtsACP As DatosArticuloClientePrecio
                Dim dtsFA As datosfacturacion
                Dim dts As DatosArticuloCliente
                Dim funcACP As New funcionesArticuloClientePrecios
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCli") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloCliente
                        dts.gIdArtCli = linea("idArtCli")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, "", linea("numDoc"))
                        dts.gtipoDoc = If(linea("TipoDoc") Is DBNull.Value, "", linea("TipoDoc"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, 0, linea("codCli"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gsubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))

                        dtsACP = funcACP.mostrarArtCli(dts.gIdArtCli)
                        If dtsACP.gidArtCliPrecio = 0 Then
                            dtsFA = funcFA.mostrarCli(dts.gidCliente)
                            dts.gPrecioNetoUnitario = 0
                            dts.gcodMoneda = dtsFA.gcodMoneda
                            dts.gSimbolo = dtsFA.gSimbolo
                        Else
                            dts.gPrecioNetoUnitario = dtsACP.gPrecioNetoUnitario
                            dts.gcodMoneda = dtsACP.gcodMoneda
                            dts.gSimbolo = dtsACP.gSimbolo
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


    Public Function mostrar1(ByVal iidArtCli As Long) As DatosArticuloCliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloCliente
            sel = "select PC.*,  Articulo, TipoArticulo, subTipoArticulo, codArticulo, codCli, NombreComercial as Cliente from ArticuloCliente as PC "
            sel = sel & " left join Articulos on Articulos.idArticulo = PC.idArticulo "
            sel = sel & " left join Clientes ON Clientes.idCliente = PC.idCliente "
            'sel = sel & " left outer join ArticuloClientePrecios as ACP on ACP.idArtCli = PC.idArtCli and ACP.Activo = 1 "
            'sel = sel & " left join Monedas on Monedas.codMoneda = ACP.codMoneda "
            sel = sel & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " left join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo "

            sel = sel & " where PC.idArtCli = " & iidArtCli

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dtsFA As datosfacturacion
                Dim dtsACP As DatosArticuloClientePrecio
                da.Fill(dt)
                Dim funcACP As New funcionesArticuloClientePrecios
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCli") Is DBNull.Value Then
                    Else
                        dts.gIdArtCli = linea("idArtCli")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, "", linea("numDoc"))
                        dts.gtipoDoc = If(linea("TipoDoc") Is DBNull.Value, "", linea("TipoDoc"))

                        'dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        'dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        'dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, 0, linea("codCli"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gsubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))

                        dtsACP = funcACP.mostrarArtCli(dts.gIdArtCli)
                        If dtsACP.gidArtCliPrecio = 0 Then
                            dtsFA = funcFA.mostrarCli(dts.gidCliente)
                            dts.gPrecioNetoUnitario = 0
                            dts.gcodMoneda = dtsFA.gcodMoneda
                            dts.gSimbolo = dtsFA.gSimbolo
                        Else
                            dts.gPrecioNetoUnitario = dtsACP.gPrecioNetoUnitario
                            dts.gcodMoneda = dtsACP.gcodMoneda
                            dts.gSimbolo = dtsACP.gSimbolo
                        End If


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





    Public Function mostrar(ByVal iidArticulo As Integer, ByVal iidCliente As Integer, ByVal Vendidos As Boolean, ByVal Todos As Boolean, ByVal Ofertados As Boolean, ByVal SoloActivos As Boolean) As List(Of DatosArticuloCliente)
        'Muestra las combinaciones ArticuloCliente o todos los de un cliente/prospect o todos los de un producto que sean activos o todos
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of DatosArticuloCliente)
            Dim sel As String = ""
            Dim sel0 As String
            sel0 = "select PC.*,  Articulo, TipoArticulo, subTipoArticulo, codArticulo, codCli, NombreComercial as Cliente from ArticuloCliente as PC "
            sel0 = sel0 & " left join Articulos on Articulos.idArticulo = PC.idArticulo "
            sel0 = sel0 & " left join Clientes ON Clientes.idCliente = PC.idCliente "
            'sel0 = sel0 & " left outer join ArticuloClientePrecios as ACP on ACP.idArtCli = PC.idArtCli and ACP.Activo = 1 "
            'sel0 = sel0 & " left join Monedas on Monedas.codMoneda = ACP.codMoneda "
            sel0 = sel0 & " left join TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel0 = sel0 & " left join subTiposArticulo ON subTiposArticulo.idsubTipoArticulo = Articulos.idsubTipoArticulo "

            If iidArticulo <> 0 Then
                sel = sel & " PC.idArticulo = " & iidArticulo
            End If

            If iidCliente <> 0 Then
                sel = sel & If(sel = "", "", " AND ")
                sel = sel & " PC.idCliente = " & iidCliente
            End If


            If SoloActivos Then
                sel = sel & If(sel = "", "", " AND ")
                sel = sel & "  PC.Activo = 1 "
            End If

            If Not Todos Then
                If Vendidos Then
                    sel = sel & IIf(sel = "", "", " AND ")
                    sel = sel & " ( (select count(numConcepto) from conceptosProformas as CC left join Proformas on Proformas.numProforma = CC.numPRoforma where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)>0 "
                    sel = sel & " or (select count(numConcepto) from conceptosPedidos as CC left join Pedidos on Pedidos.numPedido = CC.numPedido where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)>0 "
                    sel = sel & " or (select count(numConcepto) from conceptosAlbaranes as CC left join Albaranes on Albaranes.numAlbaran = CC.numAlbaran where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)>0 "
                    sel = sel & " or (select count(numConcepto) from conceptosFacturas as CC left join Facturas on Facturas.numFactura = CC.numFactura where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)>0 )"
                End If

                If Not Vendidos Then
                    sel = sel & IIf(sel = "", "", " AND ")
                    sel = sel & " ( (select count(numConcepto) from conceptosProformas as CC left join Proformas on Proformas.numProforma = CC.numPRoforma where idCliente = PC.idCliente and idArticulo =  PC.idArticulo=0 "
                    sel = sel & " and (select count(numConcepto) from conceptosPedidos AS CC left join Pedidos on Pedidos.numPedido = CC.numPedido where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)=0 "
                    sel = sel & " and (select count(numConcepto) from conceptosAlbaranes AS CC left join Albaranes on Albaranes.numAlbaran = CC.numAlbaran where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)=0 "
                    sel = sel & " and (select count(numConcepto) from conceptosFacturas as CC left join Facturas on Facturas.numFactura = CC.numFactura where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)=0 )"
                End If

                If Ofertados Then
                    sel = sel & If(sel = "", "", " AND ")

                    sel = sel & " (select count(numConcepto) from conceptosOfertas as CC left join Ofertas on Ofertas.numOferta = CC.numOferta where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)>0  "

                End If
                If Not Ofertados Then
                    sel = sel & If(sel = "", "", " AND ")

                    sel = sel & " (select count(numConcepto) from conceptosOfertas left join Ofertas on Ofertas.numOferta = ConceptosOfertas.numOferta where idCliente = PC.idCliente and idArticulo =  PC.idArticulo)=0  "

                End If
            End If
            sel = If(sel = "", "", " WHERE ") & sel
            sel = sel0 & sel

            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim dts As DatosArticuloCliente
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dtsFA As datosfacturacion
                Dim dtsACP As DatosArticuloClientePrecio
                Dim funcACP As New funcionesArticuloClientePrecios
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idArtCli") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloCliente
                        dts.gIdArtCli = linea("idArtCli")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gArticuloCli = If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli"))
                        dts.gcodArticuloCli = If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gnumDoc = If(linea("numDoc") Is DBNull.Value, "", linea("numDoc"))
                        dts.gtipoDoc = If(linea("TipoDoc") Is DBNull.Value, "", linea("TipoDoc"))

                        'dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                        'dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        'dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, 0, linea("codCli"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gsubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))

                        dtsACP = funcACP.mostrarArtCli(dts.gIdArtCli)
                        If dtsACP.gidArtCliPrecio = 0 Then
                            dtsFA = funcFA.mostrarCli(dts.gidCliente)
                            dts.gPrecioNetoUnitario = 0
                            dts.gcodMoneda = dtsFA.gcodMoneda
                            dts.gSimbolo = dtsFA.gSimbolo
                        Else
                            dts.gPrecioNetoUnitario = dtsACP.gPrecioNetoUnitario
                            dts.gcodMoneda = dtsACP.gcodMoneda
                            dts.gSimbolo = dtsACP.gSimbolo
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



    Public Function ArticuloCli(ByVal iidArticulo As Integer, ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select ArticuloCli from ArticuloCliente  where Activo = 1 and idArticulo = " & iidArticulo & " AND idCliente = " & iidCliente
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




    Public Function Existe(ByVal iidArticulo As Integer, ByVal iidCliente As Integer) As Long
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select idArtcli from ArticuloCliente  where Activo = 1 and idArticulo = " & iidArticulo & " AND idCliente = " & iidCliente
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CLng(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function EnUso(ByVal iidArtCli As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Count(idConcepto) from "
            sel = sel & "( Select idConcepto From ConceptosOfertas where idArtCli = " & iidArtCli & " union all "
            sel = sel & " Select idConcepto From ConceptosPedidos where idArtCli = " & iidArtCli & ")X"





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





    Public Function insertar(ByVal dts As DatosArticuloCliente) As Long
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into ArticuloCliente (idArticulo, idCliente,  ArticuloCli,  CodArticuloCli, Descuento, FechaAlta, FechaBaja, Activo, numDoc, TipoDoc, idCreador, Creacion) "
        sel = sel & " values (@idArticulo, @idCliente, @ArticuloCli,  @CodArticuloCli, @Descuento, @FechaAlta, @FechaBaja, @Activo, @numDoc, @tipoDoc, @idCreador, @Creacion) select @@identity "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("CodArticuloCli", dts.gcodArticuloCli)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("numDoc", dts.gnumDoc)
                cmd.Parameters.AddWithValue("tipoDoc", dts.gtipoDoc)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    dts.gIdArtCli = CLng(o)
                    If dts.gActivo Then Call DesactivarLasOtras(dts)
                    Return dts.gIdArtCli
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using



    End Function


    Public Function actualizar(ByVal dts As DatosArticuloCliente, ByVal SoloReferenciaDoc As Boolean) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        If SoloReferenciaDoc Then 'Si llega aqui es que no queremos guardar los cambios. Sólo se guarda la referencia del último documento.
            sel = "update ArticuloCliente set  numDoc = @numDoc, tipoDoc = @tipoDoc,  idModifica = @idModifica, Modificacion = @Modificacion where idArtCli = @idArtCli"
        Else
            sel = "update ArticuloCliente set idArticulo = @idArticulo, idCliente = @idCliente, ArticuloCli = @ArticuloCli, codArticuloCli = @codArticuloCli, Descuento = @Descuento, "
            sel = sel & " numDoc = @numDoc, tipoDoc = @tipoDoc, FechaAlta = @FechaAlta, FechaBaja = @FechaBaja, Activo = @Activo, idModifica = @idModifica, Modificacion = @Modificacion where idArtCli = @idArtCli"
        End If

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idArtCli", dts.gIdArtCli)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("ArticuloCli", dts.gArticuloCli)
                cmd.Parameters.AddWithValue("CodArticuloCli", If(dts.gcodArticuloCli = "", dts.gcodArticulo, dts.gcodArticuloCli))
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("numDoc", dts.gnumDoc)
                cmd.Parameters.AddWithValue("tipoDoc", dts.gtipoDoc)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using

    End Function




    Public Function DesactivarLasOtras(ByVal dts As DatosArticuloCliente) As Boolean
        'Desactivar los ArticuloPrecio anteriores
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ArticuloCliente set  Activo = 0, FechaBaja = @FechaBaja, idModifica = @idModifica, Modificacion = @Modificacion where idArtCli <> @idArtCli and idCliente = @idCliente and idArticulo = @idArticulo"


        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idArtCli", dts.gIdArtCli)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
           
                cmd.Parameters.AddWithValue("FechaBaja", Now.Date)
           
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using

    End Function



    Public Function borrar(ByVal iidArtCli As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloCliente where idArtCli = " & iidArtCli

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
          
            End Try

        End Using
    End Function


    Public Function borrarArticulo(ByVal iidArticulo As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ArticuloCliente where idArticulo = " & iidArticulo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                Dim Resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return Resultado > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        If iidCliente <> 0 Then
            sel = "delete from ArticuloCliente where idCliente = " & iidCliente

            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
                    con.Open()

                    'ejecutar el sql
                    Dim Resultado As Integer = cmd.ExecuteNonQuery()
                    con.Close()
                    Return Resultado > 0

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try

            End Using
        End If

    End Function


End Class

