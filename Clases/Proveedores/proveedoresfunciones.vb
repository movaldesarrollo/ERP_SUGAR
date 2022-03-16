Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesProveedores
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal SoloActivos As Boolean) As List(Of datosProveedor)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Proveedores.*, Pais, TipoCompra from proveedores LEFT JOIN Paises ON Paises.idPais = Proveedores.idPais LEFT JOIN TiposCompra on TiposCompra.idTipoCompra = Proveedores.idTipoCompra " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER By NombreComercial "
            'sel = "select * from proveedores ORDER By NombreComercial"
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosProveedor)
                Dim dts As datosProveedor
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosProveedor
                    dts.gidProveedor = linea("idProveedor")
                    dts.gcodProveedor = If(linea("codProveedor") Is DBNull.Value, "", linea("codProveedor"))
                    dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                    dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                    dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                    dts.gFechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                    dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                    dts.ghorario = If(linea("Horario") Is DBNull.Value, "", linea("Horario"))
                    dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    dts.gIdTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
                    dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                    dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                    dts.gcodContable = If(linea("codContable") Is DBNull.Value, 0, linea("codContable"))
                    dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                    dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
                    dts.gSuCliente = If(linea("SuCliente") Is DBNull.Value, "", linea("SuCliente"))
                    lista.Add(dts)
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

    Public Function mostrar1(ByVal iidProveedor As Integer) As datosProveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            If iidProveedor > 0 Then
                sel = "select Proveedores.*, Pais, TipoCompra from proveedores LEFT JOIN Paises ON Paises.idPais = Proveedores.idPais LEFT JOIN TiposCompra on TiposCompra.idTipoCompra = Proveedores.idTipoCompra where idProveedor = " & iidProveedor
                cmd = New SqlCommand(sel, con)
                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Dim dts As New datosProveedor
                    Dim linea As DataRow
                    For Each linea In dt.Rows
                        dts.gidProveedor = linea("idProveedor")
                        dts.gcodProveedor = If(linea("codProveedor") Is DBNull.Value, "", linea("codProveedor"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                        dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                        dts.gFechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                        dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                        dts.ghorario = If(linea("Horario") Is DBNull.Value, "", linea("Horario"))
                        dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gIdTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
                        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                        dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                        dts.gcodContable = If(linea("codContable") Is DBNull.Value, 0, linea("codContable"))
                        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                        dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
                        dts.gSuCliente = If(linea("SuCliente") Is DBNull.Value, "", linea("SuCliente"))
                    Next
                    Return dts
                Else
                    con.Close()
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Transportes() As List(Of IDComboBox)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Proveedores.nombreComercial as Transporte, Proveedores.idPRoveedor from proveedores LEFT JOIN  TiposCompra on TiposCompra.idTipoCompra = Proveedores.idTipoCompra where Activo = 1 AND TiposCompra.Transporte = 1 ORDER By NombreComercial "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idproveedor") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(If(linea("Transporte") Is DBNull.Value, "", linea("Transporte")), linea("idProveedor")))
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

    Public Function Busqueda(ByVal sparametrosql As String, ByVal Orden As String) As List(Of datosProveedor)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Proveedores.*, Pais, TipoCompra from proveedores LEFT JOIN Paises ON Paises.idPais = Proveedores.idPais LEFT JOIN TiposCompra on TiposCompra.idTipoCompra = Proveedores.idTipoCompra "
            sel = sel & sparametrosql
            sel = sel & If(Orden = "", " ORDER By NombreComercial ", " ORDER BY " & Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosProveedor)
                Dim dts As datosProveedor
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosProveedor
                    dts.gidProveedor = linea("idProveedor")
                    dts.gcodProveedor = If(linea("codProveedor") Is DBNull.Value, "", linea("codProveedor"))
                    dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                    dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                    dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                    dts.gFechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                    dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                    dts.ghorario = If(linea("Horario") Is DBNull.Value, "", linea("Horario"))
                    dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    dts.gIdTipoCompra = If(linea("idTipoCompra") Is DBNull.Value, 0, linea("idTipoCompra"))
                    dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                    dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                    dts.gcodContable = If(linea("codContable") Is DBNull.Value, 0, linea("codContable"))
                    dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                    dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
                    dts.gSuCliente = If(linea("SuCliente") Is DBNull.Value, "", linea("SuCliente"))
                    lista.Add(dts)
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

    Public Function busquedaproveedor(ByVal sparametrosql As String) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select * from proveedores " & sparametrosql, con)
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

    Public Function busquedaproveedorNombre(ByVal ParteNombre As String) As Integer
        Try
            If Len(ParteNombre) < 2 Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select idProveedor from proveedores WHERE NombreComercial like '" & ParteNombre & "%' ", con)
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

    Public Function BusquedaSQL(ByVal SentenciaSQL As String) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dt As New DataTable
            cmd = New SqlCommand(SentenciaSQL, con)
            con.Open()
            Dim lista As New List(Of datoscliente)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                con.Close()
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoMoneda(ByVal vidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select codMoneda from Facturacion  WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return "EU"
            Else
                Return CStr(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
      
        End Try
    End Function

    Public Function campoNIF(ByVal vidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select NIF from Proveedores  WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function validarNIF(ByVal nif As String, ByVal idproveedor As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            'cmd = New SqlCommand("select count(*) from Proveedores  WHERE nif = '" & nif & "' and idproveedor <> " & idproveedor, con)
            cmd = New SqlCommand("select count(*) from Proveedores  WHERE nif = '" & nif & "' and (select count(*) from Proveedores  WHERE nif = '" & nif & "' and idproveedor = " & idproveedor & " )= 0", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Or o = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return True
        End Try
    End Function

    Public Function campoProveedor(ByVal vidProveedor As Integer) As String  'Devuelve el nombre del proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select nombreComercial from Proveedores WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim resultado As String = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
     
        End Try
    End Function

    Public Function campocodProveedor(ByVal vidProveedor As Integer) As String  'Devuelve el nombre del proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select codProveedor from Proveedores WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim resultado As String = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function SiguienteidProveedor() As Integer  'Devuelve el siguiente código de proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select max(idProveedor) +1 from Proveedores ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 1
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function NuevocodProveedor() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select max(cast(case when isNumeric(codProveedor)=1 then codProveedor else 0 end as int)) from Proveedores"
            Dim cmd As SqlCommand = New SqlCommand(sel, con)
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

    Public Function campoTipo(ByVal vidProveedor As Integer) As Integer  'Devuelve el tipo de Compra
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select IdTipoCompra from Proveedores WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return -1
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function campoMP(ByVal vidProveedor As Integer) As Boolean  'Devuelve el tipo de Compra
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select MateriaPrima from Proveedores left Join TiposCompra ON  Proveedores.IdTipoCompra = TiposCompra.IdTipoCompra WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function TipoCompra(ByVal vidProveedor As Integer) As String  'Devuelve el tipo de Compra
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoCompra from Proveedores left Join TiposCompra ON  Proveedores.IdTipoCompra = TiposCompra.IdTipoCompra WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function campoObservaciones(ByVal vidProveedor As Integer) As String  'Devuelve el tipo de Compra
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Observaciones from Proveedores  WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function campoCorreo(ByVal vidProveedor As Integer) As String  'Devuelve el nombre completo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select email from Mails WHERE idProveedor = " & vidProveedor & " ORDER BY Orden", con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
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
                cmd = New SqlCommand("SELECT COUNT(*) FROM Proveedores", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Proveedores WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function NuevoidProveedor() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim cmd As SqlCommand = New SqlCommand("SELECT max(idProveedor) FROM Proveedores", con)
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

    Public Function insertar(ByVal dts As datosProveedor) As Integer
        Dim sconexion As String = CadenaConexion()
        'Dim con As New SqlConnection(sconexion)
        dts.gidProveedor = NuevoidProveedor()
        Dim sel As String

        sel = "insert into proveedores ( codProveedor, nombrecomercial, nombrefiscal, nif, fechaalta, fechaBaja,horario, observaciones,  Activo, IdTipoCompra,  web, codContable, SuCliente)	"
        sel = sel & " values ( @codProveedor, @nombrecomercial, @nombrefiscal, @nif, @fechaalta, @fechaBaja, @horario, @observaciones,  @Activo, @IdTipoCompra, @web, @codContable, @SuCliente) select @@Identity "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                dts.gidProveedor = NuevoidProveedor()
                'cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("codProveedor", dts.gcodProveedor)
                cmd.Parameters.AddWithValue("nombrecomercial", dts.gnombrecomercial)
                cmd.Parameters.AddWithValue("nombrefiscal", dts.gnombrefiscal)
                cmd.Parameters.AddWithValue("nif", dts.gnif)
                cmd.Parameters.AddWithValue("fechaalta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("horario", dts.ghorario)
                cmd.Parameters.AddWithValue("observaciones", dts.gobservaciones)
                'cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("IdTipoCompra", dts.gIdTipoCompra)
                'cmd.Parameters.AddWithValue("idPais", dts.gidPais)
                cmd.Parameters.AddWithValue("web", dts.gweb)
                cmd.Parameters.AddWithValue("codContable", dts.gcodContable)
                cmd.Parameters.AddWithValue("SuCliente", dts.gSuCliente)


                con.Open()
               
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function idProveedorExiste(ByVal iidProveedor As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Proveedores con ese código
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT idProveedor FROM Proveedores WHERE idProveedor = " & iidProveedor
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o) = iidProveedor
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
          
            End Try

        End Using

    End Function

    Public Function codProveedorExiste(ByVal scodProveedor As String, ByVal iidProveedor As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Proveedores con ese código en un proveedor diferente
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT codProveedor FROM Proveedores WHERE codProveedor = '" & scodProveedor & "' AND idProveedor <> " & iidProveedor
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CStr(o) = scodProveedor)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
           
            End Try

        End Using

    End Function

    Public Function codContableExiste(ByVal scodContable As String, ByVal iidProveedor As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Clientes con ese código en un Cliente diferente
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT codContable FROM Proveedores WHERE codContable = '" & scodContable & "' AND idProveedor <> " & iidProveedor
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CStr(o) = scodContable)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
         
            End Try

        End Using

    End Function

    Public Function actualizar(ByVal dts As datosProveedor) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update proveedores set codProveedor = @codProveedor, nombrecomercial = @nombrecomercial, nombrefiscal = @nombrefiscal, nif = @nif,fechaalta = @fechaalta, fechaBaja = @fechaBaja,  horario = @horario, observaciones = @observaciones,  "
        sel = sel & "  Activo = @Activo, IdTipoCompra = @IdTipoCompra, web = @web, codContable = @codContable, SuCliente = @SuCliente where idProveedor = @idProveedor "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("codProveedor", dts.gcodProveedor)
                cmd.Parameters.AddWithValue("nombrecomercial", dts.gnombrecomercial)
                cmd.Parameters.AddWithValue("nombrefiscal", dts.gnombrefiscal)
                cmd.Parameters.AddWithValue("nif", dts.gnif)
                cmd.Parameters.AddWithValue("fechaalta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("horario", dts.ghorario)
                cmd.Parameters.AddWithValue("observaciones", dts.gobservaciones)
                'cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("IdTipoCompra", dts.gIdTipoCompra)
                'cmd.Parameters.AddWithValue("idPais", dts.gidPais)
                cmd.Parameters.AddWithValue("web", dts.gweb)
                cmd.Parameters.AddWithValue("codContable", dts.gcodContable)
                cmd.Parameters.AddWithValue("SuCliente", dts.gSuCliente)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function Validar(ByVal dts As datosProveedor, ByVal Aviso As Boolean) As Boolean
        Dim valido As Boolean = True

        If codProveedorExiste(dts.gcodProveedor, dts.gidProveedor) Then
            MsgBox("El código proveedor ya está en uso")
            Validar = False
        End If

        If Validar And dts.gnombrecomercial = "" Then
            MsgBox("Se ha de introducir un nombre para el proveedor")
            Validar = False
        End If
        If Validar And dts.gIdTipoCompra = -1 Then
            MsgBox("Se ha de seleccionar un tipo de proveedor")
            Validar = False
        End If
        Return valido
    End Function

    Public Function ProveedorEnUso(ByVal iidProveedor As Integer) As Boolean
        'Nos dice si el proveedor está en uso en Fabricación, Facturas de proveedores, Materias PRimas, PEdidos a Proveedor, Previsiones y Productos
        Dim sconexion As String = CadenaConexion()
        Dim sel As String '= "Select idProveedor from Fabricacion  where idProveedor = @idProveedor union "
        sel = "Select idProveedor from PedidosProv  where idProveedor = @idProveedor  "
        'sel = sel & "Select idProveedor from FacturasProveedores  where idProveedor = @idProveedor union "
        'sel = sel & "Select idProveedor from MateriasPrimas  where idProveedor = @idProveedor union "

        'sel = sel & "Select idProveedor from Previsiones  where idProveedor = @idProveedor union "
        'sel = sel & "Select idProveedor from Productos  where idProveedor = @idProveedor  "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                cmd.Parameters.AddWithValue("idProveedor", iidProveedor)

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o) = iidProveedor
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using

    End Function

    Public Function borrar(ByVal iidProveedor As Integer) As Boolean
        If iidProveedor > 0 Then
            If ProveedorEnUso(iidProveedor) Then
                MsgBox("Este proveedor está en uso. No se puede borrar.")
                Return False
            Else
                'Borrar Mails
                Dim funcMA As New FuncionesMails
                funcMA.borrarProveedor(iidProveedor)
                'Borrar Telefonos
                Dim funcTE As New FuncionesTelefonos
                funcTE.borrarProveedor(iidProveedor)
                'Borrar los contactos
                Dim funcC As New funcionesContactos
                funcC.borrarProveedor(iidProveedor)
                'Borrar las ubicaciones
                Dim funcU As New funcionesUbicaciones
                funcU.borrarProveedor(iidProveedor)
                'Borrar el proveedor

                Dim sconexion As String = CadenaConexion()
                Dim sel As String

                sel = "delete from Proveedores where idProveedor = " & iidProveedor

                Using con As New SqlConnection(sconexion)
                    Try

                        cmd = New SqlCommand(sel, con)
                        con.Open()
                        Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                        con.Close()
                       
                        Return True

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Return False
                    Finally
                        desconectado()
                    End Try

                End Using
            End If
        End If
    End Function
End Class
