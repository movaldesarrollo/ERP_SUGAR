Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesEstados
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal Aplicacion As String) As List(Of DatosEstado) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Aplicacion = '" & Aplicacion & "' order by Estado ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEstado)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                'Dim dts As DatosEstado
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosEstado
        Dim dts As New DatosEstado
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
        Return dts
    End Function


    Public Function Mostrar1(ByVal iidEstado As Integer) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados where idEstado = " & iidEstado
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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




    Public Function Estado(ByVal iidEstado As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Estado FROM Estados WHERE idEstado = " & iidEstado
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

    Public Function Cabecera(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Cabecera FROM Estados WHERE idEstado = " & iidEstado
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

    Public Function EstadoCabecera(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Cabecera = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoAutomatico(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Automatico = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function Anulado(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Anulado FROM Estados WHERE idEstado = " & iidEstado
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

    

    Public Function EstadoAnulado(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Anulado = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoEnCurso(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE EnCurso = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoTraspasado(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Traspasado = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoCPedido(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CREADO"
                    selx = " AND Espera = 1 AND Traspasado = 0 "
                Case "ENVIADO PRODUCCION" 'Enviado a LOGISTICA
                    selx = " AND Espera = 1 AND Traspasado = 1 AND EnCurso = 0 "
                Case "RECIBIDO PRODUCCION"
                    selx = " AND Espera = 1 AND Traspasado = 1 AND EnCurso = 1 "
                Case "EN PRODUCCION"
                    selx = " AND Espera = 0 AND Traspasado = 1 AND EnCurso = 1 "
                Case "PRODUCIDO"
                    selx = " AND Completo = 1 AND Traspasado = 0 And Bloqueado = 0 "
                Case "PREPARADO"
                    selx = " AND Completo = 1 AND Traspasado = 0 And Bloqueado = 1 "
                Case "SERVIDO"
                    selx = " AND  Entregado = 1 "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'C.PEDIDO' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoCPedidoProv(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "ESPERA"
                    selx = " AND Espera = 1 "
                Case "RECIBIDO"
                    selx = " AND Entregado = 1 AND Completo = 1 "
                Case "RECIBIDO PARCIAL"
                    selx = " AND Entregado = 1 AND Completo = 0 "
                
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'C.PEDIDOPROV' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoPedido(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
                Case "PENDIENTE"
                    selx = " AND Espera = 0 AND EnCurso = 1 and Entregado = 0 "
                Case "ANULADO"
                    selx = " AND Anulado = 1 and Bloqueado = 1 "
                Case "SERVIDO"
                    selx = " AND Traspasado = 1 AND bloqueado = 1 "
                Case "PRODUCIDO"
                    selx = " AND  Espera = 1 AND EnCurso = 0 "
                Case "PRODUCCION"
                    selx = " AND EnCurso = 1 AND Espera = 1 and Entregado = 0 "
                Case "PREPARADO"
                    selx = " AND Completo = 1 AND Traspasado = 0 "
                Case "PARCIAL"
                    selx = " AND Entregado = 1  "

            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'PEDIDO' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoReparacion(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "NUEVO"
                    selx = " AND Espera = 1 "
                Case "EN CURSO"
                    selx = " AND EnCurso = 1 "
                Case "TRASPASADO"
                    selx = " AND Traspasado = 1 and Bloqueado = 1 "
                Case "ANULADO"
                    selx = " AND Anulado = 1 "
                Case "NO TRASPASAR"
                    selx = " AND  Completo = 1 "
                Case "PARCIAL"
                    selx = " AND Traspasado = 1 AND Bloqueado = 0 "
               

            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'REPARACION' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoPedidoProv(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
                Case "EN CURSO"
                    selx = " AND Espera = 0 AND EnCurso = 1 "
                Case "ANULADO"
                    selx = " AND Anulado = 1 AND Bloqueado = 1 "
                Case "FINALIZADO"
                    selx = " AND EnCurso = 0 AND Espera = 1 "
                Case "VALIDADO"
                    selx = " AND EnCurso = 1 AND Espera = 1 "
                Case "REALIZADO"
                    selx = " AND Traspasado = 1 "
                Case "STOCK"
                    selx = " AND Entregado = 1 And Completo = 1 and Bloqueado = 1 "
                Case "STOCK PARCIAL"
                    selx = " AND Entregado = 1 And Completo = 0 and Bloqueado = 0 "
                Case "CERRADO"
                    selx = " AND Bloqueado = 1 And Anulado = 0 and Completo = 0 "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'PEDIDOPROV' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoAlbaranProv(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
                Case "RECIBIDO"
                    selx = " AND Entregado = 1 And Completo = 1 "
                Case "RECIBIDO PARCIAL"
                    selx = " AND Entregado = 1 And Completo = 0 "
                Case "RECHAZADO"
                    selx = " AND Automatico = 1 "
                Case "FACTURADO"
                    selx = " AND Traspasado = 1  "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'ALBARANPROV' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoCPedidoINT(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "NUEVO"
                    selx = " AND Cabecera = 1 "
                Case "LEIDO"
                    selx = " AND  EnCurso = 1 "
                Case "ANULADO"
                    selx = " AND Anulado = 1  "
                Case "PROCESADO"
                    selx = " AND Traspasado = 1 "
                Case "RECIBIDO"
                    selx = " AND Entregado = 1 AND Completo = 1 "
                Case "PARCIAL"
                    selx = " AND Entregado = 1 AND Completo = 0 "

            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'C.PEDIDO_INT' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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


    Public Function EstadoOferta(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
                Case "ACTIVA"
                    selx = " AND Espera = 1 AND EnCurso = 1 "
                Case "RECHAZADA"
                    selx = " AND Bloqueado = 1 AND Anulado = 0 AND Traspasado = 0 "
                Case "ACEPTADA"
                    selx = " AND Traspasado = 1  "
                Case "ANULADA"
                    selx = " AND Anulado = 1  "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'OFERTA' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoFactura(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
                Case "PENDIENTE"
                    selx = " AND Espera = 1 AND EnCurso = 0 "
                Case "PARCIAL"
                    selx = " AND Espera = 1 AND EnCurso = 1  "
                Case "COBRADA"
                    selx = " AND Completo = 1  "
                Case "ANULADA"
                    selx = " AND Anulado = 1  "
                Case "DEVUELTA"
                    selx = " AND Espera = 0 AND Automatico = 1 "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'FACTURA' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoFacturaProv(ByVal sEstado As String) As DatosEstado
        'Devuelve el estado correspondiente de la tabla de estados ´para ConceptosPedidos según la descripción indicada
        Try
            sEstado = UCase(sEstado)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim selx As String = ""
            Select Case sEstado
              
                Case "PENDIENTE"
                    selx = " AND Espera = 1 AND EnCurso = 0 "
                Case "PARCIAL"
                    selx = " AND Espera = 1 AND EnCurso = 1  "
                Case "PAGADA"
                    selx = " AND Completo = 1  "
                Case "ANULADA"
                    selx = " AND Anulado = 1  "
                Case "DEVUELTA"
                    selx = " AND Espera = 0 AND Automatico = 1 "
                Case "CABECERA"
                    selx = " AND Cabecera = 1 "
            End Select
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE  Aplicacion = 'FACTURAPROV' " & selx
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoEspera(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Espera = 1 and traspasado=0 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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

    Public Function EstadoCompleto(ByVal Aplicacion As String) As DatosEstado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Completo = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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



    Public Function EstadoEntregado(ByVal Aplicacion As String) As DatosEstado
        'Se usa para recibido o entregado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Estados WHERE Entregado = 1 and Aplicacion = '" & Aplicacion & "' "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstado
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEstado") Is DBNull.Value Then
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
    Public Function Bloqueado(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Bloqueado FROM Estados WHERE idEstado = " & iidEstado
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


    Public Function Automatico(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Automatico FROM Estados WHERE idEstado = " & iidEstado
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


    Public Function Espera(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Espera FROM Estados WHERE idEstado = " & iidEstado
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




    Public Function EnCurso(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT EnCurso FROM Estados WHERE idEstado = " & iidEstado
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

    Public Function Traspasado(ByVal iidEstado As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Traspasado FROM Estados WHERE idEstado = " & iidEstado
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

    Public Function Estado(ByVal Aplicacion As String, ByVal Orden As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Estado FROM Estados WHERE Aplicacion = '" & Aplicacion & "' AND Orden = " & Orden
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

   



    Public Function insertar(ByVal dts As DatosEstado) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Estados (Estado, Descripcion, Orden, Cabecera, Espera, EnCurso, Bloqueado, Traspasado, Anulado,Automatico,Entregado,Completo ) values (@Estado, @Descripcion, @Orden, @Cabecera, @Espera, @EnCurso, @Bloqueado, @Traspasado, @Anulado, @Automatico,@,Entregado,@Completo  ) select @@Identity"
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Estado", dts.gEstado)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Cabecera", dts.gCabecera)
                cmd.Parameters.AddWithValue("Espera", dts.gEspera)
                cmd.Parameters.AddWithValue("EnCurso", dts.gEnCurso)
                cmd.Parameters.AddWithValue("Bloqueado", dts.gBloqueado)
                cmd.Parameters.AddWithValue("Traspasado", dts.gTraspasado)
                cmd.Parameters.AddWithValue("Anulado", dts.gAnulado)
                cmd.Parameters.AddWithValue("Automatico", dts.gAutomatico)
                cmd.Parameters.AddWithValue("Entregado", dts.gEntregado)
                cmd.Parameters.AddWithValue("Completo", dts.gCompleto)


                con.Open()

                Dim o As Object = cmd.ExecuteNonQuery()
                con.Close()
                If o Is Nothing Then
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


    Public Function actualizar(ByVal dts As DatosEstado) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Estados set Estado = @Estado, Descripcion = @Descripcion, Orden =@Orden, Cabecera = @Cabecera, Espera = @Espera, EnCurso = @EnCurso, Bloqueado = @Bloqueado, Traspasado = @Traspasado, Anulado = @Anulado, Automatico =@Automatico,Entregado = @Entregado,Completo = @Completo  WHERE idEstado = @idEstado "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("Estado", dts.gEstado)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Cabecera", dts.gCabecera)
                cmd.Parameters.AddWithValue("Espera", dts.gEspera)
                cmd.Parameters.AddWithValue("EnCurso", dts.gEnCurso)
                cmd.Parameters.AddWithValue("Bloqueado", dts.gBloqueado)
                cmd.Parameters.AddWithValue("Traspasado", dts.gTraspasado)
                cmd.Parameters.AddWithValue("Anulado", dts.gAnulado)
                cmd.Parameters.AddWithValue("Automatico", dts.gAutomatico)
                cmd.Parameters.AddWithValue("Entregado", dts.gEntregado)
                cmd.Parameters.AddWithValue("Completo", dts.gCompleto)


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


    Public Function borrar(ByVal iidEstado As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Estados where idEstado = " & iidEstado
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Clonar(ByVal dts As DatosEstado) As DatosEstado
        Dim dtsN As New DatosEstado
        dtsN.gAnulado = dts.gAnulado
        dtsN.gAplicacion = dts.gAplicacion
        dtsN.gAutomatico = dts.gAutomatico
        dtsN.gBloqueado = dts.gBloqueado
        dtsN.gCabecera = dts.gCabecera
        dtsN.gCompleto = dts.gCompleto
        dtsN.gDescripcion = dts.gDescripcion
        dtsN.gEnCurso = dts.gEnCurso
        dtsN.gEntregado = dts.gEntregado
        dtsN.gEspera = dts.gEspera
        dtsN.gEstado = dts.gEstado
        dtsN.gidEstado = dts.gidEstado
        dtsN.gOrden = dts.gOrden
        dtsN.gTraspasado = dts.gTraspasado
        Return dtsN
    End Function




End Class



