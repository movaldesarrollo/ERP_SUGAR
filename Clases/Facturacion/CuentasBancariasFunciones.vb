Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO

Public Class FuncionesCuentasBancarias
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal iidFacturacion As Integer, ByVal SoloActivos As Boolean, Optional ByVal verificarActivo As String = "") As List(Of DatosCuentaBancaria)
        'Lista de cuentas de un cliente o proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT CuentasBancarias.*, Bancos.SWIFT_BIC as BICBanco, Banco, Bancos.idPais, Pais FROM CuentasBancarias "
            sel = sel & " left join Bancos ON Bancos.idBanco = CuentasBancarias.idBanco "
            sel = sel & " left join Paises ON Paises.idPais = Bancos.idPais "
            'sel = sel & "WHERE  idFacturacion = " & iidFacturacion & If(SoloActivos, " AND CuentasBancarias.Activo = 1 ", "") & " order by Orden ASC "
            sel = sel & "WHERE  idFacturacion = " & iidFacturacion & verificarActivo & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosCuentaBancaria)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCuentaBanco") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosCuentaBancaria
        Dim dts As New DatosCuentaBancaria
        dts.gidCuentaBanco = If(linea("idCuentaBanco") Is DBNull.Value, 0, linea("idCuentaBanco"))
        dts.gidFacturacion = If(linea("idFacturacion") Is DBNull.Value, 0, linea("idFacturacion"))
        dts.gidBanco = If(linea("idBanco") Is DBNull.Value, 0, linea("idBanco"))
        dts.gCodigoEU = If(linea("CodigoEU") Is DBNull.Value, "", linea("CodigoEU"))
        dts.gCodigoBanco = If(linea("codigoBanco") Is DBNull.Value, "0000", linea("codigoBanco"))
        dts.gCodigoOficina = If(linea("CodigoOficina") Is DBNull.Value, "0000", linea("CodigoOficina"))
        dts.gCodigoDC = If(linea("CodigoDC") Is DBNull.Value, "00", linea("CodigoDC"))
        dts.gCodigoCuenta = If(linea("CodigoCuenta") Is DBNull.Value, "0000000000", linea("CodigoCuenta"))
        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
        'Si no está guardado eo IBAN, lo componemos 
        If dts.gIBAN = "" Then dts.gIBAN = dts.gCodigoEU & dts.gCodigoBanco & dts.gCodigoOficina & dts.gCodigoDC & dts.gCodigoCuenta
        dts.gSWIFT_BIC = If(linea("SWIFT_BIC") Is DBNull.Value, "", linea("SWIFT_BIC"))
        'Si no se especifica el BIC, se coge del banco
        If dts.gSWIFT_BIC = "" Then dts.gSWIFT_BIC = If(linea("BICBanco") Is DBNull.Value, "", linea("BICBanco"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
        Return dts
    End Function

    Public Function Mostrar1(ByVal iidCuentaBanco As Integer) As DatosCuentaBancaria
        'Lista de cuentas de un cliente o proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT CuentasBancarias.*, Bancos.SWIFT_BIC as BICBanco, Banco, Bancos.idPais, Pais FROM CuentasBancarias "
            sel = sel & " left join Bancos ON Bancos.idBanco = CuentasBancarias.idBanco "
            sel = sel & " left join Paises ON Paises.idPais = Bancos.idPais "
            sel = sel & " WHERE idCuentaBanco = " & iidCuentaBanco
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosCuentaBancaria
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idCuentaBanco") Is DBNull.Value Then
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

    Public Function insertar(ByRef dts As DatosCuentaBancaria) As Integer
        'Pasamos el dts por Referencia para poder recargar los datos de bancos al retornar
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into CuentasBancarias (idFacturacion, idBanco, codigoEU, codigoBanco, codigoOficina, codigoDC, codigoCuenta, IBAN, SWIFT_BIC, Orden, Activo,Nombre, idCreador, Creacion) "
            sel = sel & "values ( @idFacturacion,@idBanco, @codigoEU, @codigoBanco, @codigoOficina, @codigoDC, @codigoCuenta, @IBAN, @SWIFT_BIC, @Orden, @Activo,@Nombre, @idCreador, @Creacion) select @@Identity "
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFacturacion", dts.gidFacturacion)
                cmd.Parameters.AddWithValue("idBanco", dts.gidBanco)
                cmd.Parameters.AddWithValue("codigoEU", dts.gCodigoEU)
                cmd.Parameters.AddWithValue("codigoBanco", dts.gCodigoBanco)
                cmd.Parameters.AddWithValue("codigoOficina", dts.gCodigoOficina)
                cmd.Parameters.AddWithValue("codigoDC", dts.gCodigoDC)
                cmd.Parameters.AddWithValue("codigoCuenta", dts.gCodigoCuenta)
                cmd.Parameters.AddWithValue("IBAN", dts.gIBAN)
                cmd.Parameters.AddWithValue("SWIFT_BIC", dts.gSWIFT_BIC)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
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

    Public Function actualizar(ByRef dts As DatosCuentaBancaria) As Boolean
        'Pasamos el dts por Referencia para poder recargar los datos de bancos al retornar
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update CuentasBancarias set  idFacturacion = @idFacturacion, idBanco = @idBanco, codigoEU = @codigoEU, codigoBanco = @codigoBanco, "
        sel = sel & " codigoOficina = @codigoOficina, codigoDC = @codigoDC, codigoCuenta = @codigoCuenta, IBAN = @IBAN, SWIFT_BIC = @SWIFT_BIC, Orden = @Orden, "
        sel = sel & " Activo = @Activo, Nombre = @Nombre, idModifica = @idModifica, Modificacion = @Modificacion WHERE idCuentaBanco = " & dts.gidCuentaBanco

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                cmd.Parameters.AddWithValue("idFacturacion", dts.gidFacturacion)
                cmd.Parameters.AddWithValue("idBanco", dts.gidBanco)
                cmd.Parameters.AddWithValue("codigoEU", dts.gCodigoEU)
                cmd.Parameters.AddWithValue("codigoBanco", dts.gCodigoBanco)
                cmd.Parameters.AddWithValue("codigoOficina", dts.gCodigoOficina)
                cmd.Parameters.AddWithValue("codigoDC", dts.gCodigoDC)
                cmd.Parameters.AddWithValue("codigoCuenta", dts.gCodigoCuenta)
                cmd.Parameters.AddWithValue("IBAN", dts.gIBAN)
                cmd.Parameters.AddWithValue("SWIFT_BIC", dts.gSWIFT_BIC)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function Inactivar(ByVal iidCuentaBanco As Integer) As Boolean
        'Pasamos el dts por Referencia para poder recargar los datos de bancos al retornar
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update CuentasBancarias set  Activo = 0, idModifica = @idModifica, Modificacion = @Modificacion WHERE idCuentaBanco = " & iidCuentaBanco

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idCuentaBanco", iidCuentaBanco)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Function ExisteCuenta(ByVal iidFacturacion As Integer, ByVal iidCuentaBanco As Integer) As Boolean
        'Comprobar si existe la cuenta 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select idCuentaBanco from CuentasBancarias where idCuentaBanco = " & iidCuentaBanco & " and idFacturacion = " & iidFacturacion
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CInt(o) = iidCuentaBanco)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function comprobarExisteIBAN(ByVal nIBAN As String, ByVal nBanco As String, ByVal nOficina As String, ByVal nDC As String, ByVal nCuenta As String, ByVal activado As Boolean) As Boolean
        Try
            Dim activo As Integer
            If activado = True Then
                activo = 1
            Else
                activo = 0
            End If
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select idCuentaBanco from CuentasBancarias where codigoEU = '" & nIBAN & "' and  codigoBanco = " & nBanco & " and codigooficina = " & nOficina & " and codigodc = " & nDC & " and  codigocuenta = '" & nCuenta & "' and activo=" & activo
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return True
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function ExisteNombreCuenta(ByVal iidFacturacion As Integer, ByVal Nombre As String, ByVal iidCuentaBanco As Integer) As Boolean
        'Identifica si existe un nombre repetido para el mismo cliente o proveedor. Si idFacturacion=0 son cuentas propias
        Try
            Nombre = UCase(Trim(Nombre))
            If Nombre = "" Then Return False
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select idCuentaBanco from CuentasBancarias where upper(Nombre) = '" & Nombre & "' and idFacturacion = " & iidFacturacion & " AND idCuentaBanco <> " & iidCuentaBanco
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CInt(o) <> iidCuentaBanco)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function EnUso(ByVal iidCuentaBanco As Integer, ByVal id As Integer) As Boolean
        'Verificamos si se usa la cuenta en alguna factura u otro documento
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select (Select count(idCuentaBanco) from Facturas where idCuentaBanco = " & iidCuentaBanco & " and idcliente=" & id & ") + "
            sel = sel & " (Select count(idCuentaBanco) from FacturasProv where idCuentaBanco = " & iidCuentaBanco & "and idproveedor=" & id & ") + "
            sel = sel & " (Select count(idCuentaBanco) from Albaranes where idCuentaBanco = " & iidCuentaBanco & " and idcliente=" & id & ") + "
            sel = sel & " (Select count(idCuentaBanco) from Pedidos where idCuentaBanco = " & iidCuentaBanco & " and idcliente=" & id & ") + "
            sel = sel & " (Select count(idCuentaBanco) from Proformas where idCuentaBanco = " & iidCuentaBanco & " and idcliente=" & id & ")  "
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CInt(o) > 0)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function ExisteBanco(ByVal iidBanco As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select idBanco from CuentasBancarias where idBanco = " & iidBanco
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CInt(o) = iidBanco)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function NombreCompleto(ByVal iidCuentaBanco As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "Select case when Nombre is null then IBAN when Nombre = '' then IBAN else Nombre + ': ' + IBAN end from CuentasBancarias where idCuentaBanco = " & iidCuentaBanco
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return ""
                Else
                    Return CStr(o)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    'Elimina o inactiva las cuentas
    Public Function borrar(ByVal iidCuentaBanco As Integer, ByVal IBAN As String, ByVal id As Integer) As Boolean
        'Borramos si no está en uso, en otro caso inactivamos
        Try
            If EnUso(iidCuentaBanco, id) Then
                Call Inactivar(iidCuentaBanco)
                MsgBox("La cuenta " & IBAN & " está en uso en alguna factura, se ha inactivado")
            Else
                Dim sconexion As String = CadenaConexion()
                Dim sel As String = "delete from CuentasBancarias where idCuentaBanco = " & iidCuentaBanco
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrar(ByVal iidCuentaBanco As Integer, ByVal idcliente As Integer) As Boolean
        'Borramos si no está en uso, en otro caso inactivamos
        Try
            If EnUso(iidCuentaBanco, idcliente) Then
                Call Inactivar(iidCuentaBanco)
                MsgBox("La cuenta indicada no se puede borrar porque está en uso. Alternativamente puede desactivarla.")
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim sel As String = "delete from CuentasBancarias where idCuentaBanco = " & iidCuentaBanco
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
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarFacturacion(ByVal iidFacturacion As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from CuentasBancarias where idFacturacion = " & iidFacturacion
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
End Class