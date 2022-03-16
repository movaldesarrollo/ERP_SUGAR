Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesclientes
    Inherits conexion
    Dim cmd As SqlCommand
    Dim funcMA As New FuncionesMails
    Dim funcTE As New FuncionesTelefonos
    Dim funcPE As New FuncionesPersonal

    Public Function mostrar(ByVal SoloActivos As Boolean) As List(Of datoscliente)
        Try
            Dim VerClientesPropios As Boolean = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Clientes.*, Ubicaciones.idPais, Contactos.Nombre + ' ' + Contactos.Apellidos as ResponsableCuenta, Paises.Pais, Monedas.codMoneda "
            sel = sel & " from Clientes Left Join Ubicaciones ON Ubicaciones.idCliente = Clientes.idCliente "
            sel = sel & " LEFT JOIN Facturacion ON Facturacion.idCliente = Clientes.idCliente "
            sel = sel & " left Outer Join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion"
            sel = sel & " Left Join Personal ON Personal.idPersona = Clientes.idResponsableCuenta "
            sel = sel & " Left Join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " left join Paises ON Paises.idPais = Ubicaciones.idPais "
            sel = sel & " left join Monedas ON Monedas.codMoneda = Facturacion.codMoneda"
            sel = sel & " left join TiposRetencion ON TiposRetencion.idTipoRetencion = Facturacion.idTipoRetencion"
            sel = sel & " Where TiposUbicacion.Fiscal = 1 "
            sel = sel & If(VerClientesPropios, " AND idResponsableCuenta = " & Inicio.vIdUsuario, "")
            sel = sel & If(SoloActivos, " AND Clientes.Activo = 1 ", "") & " ORDER By NombreComercial "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim lista As New List(Of datoscliente)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datoscliente
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCliente") Is DBNull.Value Then
                    Else
                        dts = New datoscliente
                        dts.gidCliente = linea("idCliente")
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                        dts.gcodContable = If(linea("codContable") Is DBNull.Value, "", linea("codContable"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                        dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                        dts.gfechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                        dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                        dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                        dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                        dts.gidResponsableCuenta = If(linea("idResponsableCuenta") Is DBNull.Value, 0, linea("idResponsableCuenta"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, "", linea("ResponsableCuenta"))
                        dts.gObservacionesProd = If(linea("ObservacionesProd") Is DBNull.Value, "", linea("ObservacionesProd"))
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


    Public Function mostrar1(ByVal iidCliente As Integer) As datoscliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Clientes.*, Ubicaciones.idPais, Contactos.Nombre + ' ' + Contactos.Apellidos as ResponsableCuenta, Paises.Pais, Monedas.codMoneda "
            sel = sel & " from Clientes Left Join Ubicaciones ON Ubicaciones.idCliente = Clientes.idCliente "
            sel = sel & " LEFT JOIN Facturacion ON Facturacion.idCliente = Clientes.idCliente "
            sel = sel & " left Outer Join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion"
            sel = sel & " Left Join Personal ON Personal.idPersona = Clientes.idResponsableCuenta "
            sel = sel & " Left Join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " left join Paises ON Paises.idPais = Ubicaciones.idPais   "
            sel = sel & " left join Monedas ON Monedas.codMoneda = Facturacion.codMoneda"
            sel = sel & " left join TiposRetencion ON TiposRetencion.idTipoRetencion = Facturacion.idTipoRetencion"
            sel = sel & " Where TiposUbicacion.Fiscal=1 "
            sel = sel & " AND Clientes.idCliente = " & iidCliente
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim dts As New datoscliente
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCliente") Is DBNull.Value Then
                    Else
                        dts.gidCliente = linea("idCliente")
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                        dts.gcodContable = If(linea("codContable") Is DBNull.Value, "", linea("codContable"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                        dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                        dts.gfechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                        dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                        dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                        dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                        dts.gidResponsableCuenta = If(linea("idResponsableCuenta") Is DBNull.Value, 0, linea("idResponsableCuenta"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, "", linea("ResponsableCuenta"))
                        dts.gObservacionesProd = If(linea("ObservacionesProd") Is DBNull.Value, "", linea("ObservacionesProd"))


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


    Public Function Busqueda(ByVal sparametrosql As String, ByVal Orden As String) As List(Of datoscliente)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Clientes.*, Ubicaciones.idPais, Contactos.Nombre + ' ' + Contactos.Apellidos as ResponsableCuenta, Paises.Pais, Monedas.codMoneda "
            sel = sel & " from Clientes Left Join Ubicaciones ON Ubicaciones.idCliente = Clientes.idCliente "
            sel = sel & " LEFT JOIN Facturacion ON Facturacion.idCliente = Clientes.idCliente "
            sel = sel & " left Outer Join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion"
            sel = sel & " Left Join Personal ON Personal.idPersona = Clientes.idResponsableCuenta "
            sel = sel & " Left Join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & " left join Paises ON Paises.idPais = Ubicaciones.idPais   "
            sel = sel & " left join Monedas ON Monedas.codMoneda = Facturacion.codMoneda"
            sel = sel & " left join TiposRetencion ON TiposRetencion.idTipoRetencion = Facturacion.idTipoRetencion"
            sel = sel & " Where TiposUbicacion.Fiscal=1 "
            sel = sel & If(sparametrosql = "", "", " AND " & sparametrosql)
            sel = sel & If(Orden = "", " ORDER By NombreComercial ", " ORDER BY " & Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim lista As New List(Of datoscliente)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datoscliente
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCliente") Is DBNull.Value Then
                    Else
                        dts = New datoscliente
                        dts.gidCliente = linea("idCliente")
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                        dts.gcodContable = If(linea("codContable") Is DBNull.Value, "", linea("codContable"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                        dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                        dts.gfechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                        dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                        dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                        dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
                        dts.gidResponsableCuenta = If(linea("idResponsableCuenta") Is DBNull.Value, 0, linea("idResponsableCuenta"))
                        dts.gResponsableCuenta = If(linea("ResponsableCuenta") Is DBNull.Value, "", linea("ResponsableCuenta"))
                        dts.gObservacionesProd = If(linea("ObservacionesProd") Is DBNull.Value, "", linea("ObservacionesProd"))
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

    Public Function BusquedaRapida(ByVal sparametrosql As String, ByVal Orden As String) As List(Of datoscliente)
        Try
            Dim funcUB As New funcionesUbicaciones
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select Clientes.*, (select count(idUbicacion) from Ubicaciones Where idCliente = Clientes.idCliente AND subCliente<>'') as ContadorSubClientes from Clientes "
            sel = sel & If(sparametrosql = "", "", " WHERE " & sparametrosql)
            sel = sel & If(Orden = "", " ORDER By NombreComercial ", " ORDER BY " & Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim lista As New List(Of datoscliente)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim dts As datoscliente
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCliente") Is DBNull.Value Then
                    Else
                        dts = New datoscliente
                        dts.gidCliente = linea("idCliente")
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                        dts.gcodContable = If(linea("codContable") Is DBNull.Value, "", linea("codContable"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gnombrefiscal = If(linea("nombrefiscal") Is DBNull.Value, "", linea("nombrefiscal"))
                        dts.gnif = If(linea("nif") Is DBNull.Value, "", linea("nif"))
                        dts.gfechaAlta = If(linea("fechaAlta") Is DBNull.Value, Now.Date, linea("fechaAlta"))
                        dts.gfechaBaja = If(linea("fechaBaja") Is DBNull.Value, Now.Date, linea("fechaBaja"))
                        dts.gobservaciones = If(linea("observaciones") Is DBNull.Value, "", linea("observaciones"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gweb = If(linea("web") Is DBNull.Value, "", linea("web"))
                        dts.gidResponsableCuenta = If(linea("idResponsableCuenta") Is DBNull.Value, 0, linea("idResponsableCuenta"))
                        dts.gObservacionesProd = If(linea("ObservacionesProd") Is DBNull.Value, "", linea("ObservacionesProd"))
                        If If(linea("ContadorSubClientes") Is DBNull.Value, 0, linea("ContadorSubClientes")) > 0 Then
                            dts.gSubClientes = funcUB.subClientes(dts.gidCliente)
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

    Public Function BusquedaSimple(ByVal sparametrosql As String, ByVal Orden As String) As List(Of datoscliente)
        Try
            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "select * from Clientes "

            sel = sel & If(sparametrosql = "", "", " WHERE " & sparametrosql)

            sel = sel & If(Orden = "", " ORDER By NombreComercial ", " ORDER BY " & Orden)

            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim lista As New List(Of datoscliente)

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim dts As datoscliente

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idCliente") Is DBNull.Value Then
                    Else
                        dts = New datoscliente
                        dts.gidCliente = linea("idCliente")
                        dts.gcodCli = If(linea("codCli") Is DBNull.Value, "", linea("codCli"))
                        dts.gnombrecomercial = If(linea("nombrecomercial") Is DBNull.Value, "", linea("nombrecomercial"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
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


   
    Public Function UltimoNumero() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select codcli from clientes order by codCli DESC", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            If o Is DBNull.Value Or o Is Nothing Then
                Return -1
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function NuevocodCli() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim cmd As SqlCommand = New SqlCommand("SELECT max(codCli) FROM Clientes", con)
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

  



    Public Function busquedaNIFpais(ByVal sNIF As String, ByVal sPais As String) As Integer
        'Realiza una búsqueda de la combinación NIF - País y devuelve el número de coincidencias. 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(codcli) from clientes WHERE nif like '" & sNIF & "' AND pais LIKE '" & sPais & "'", con)
            con.Open()

            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function



    Public Function busquedaNIFpais(ByVal sNIF As String, ByVal sPais As String, ByVal icodCli As Integer) As Integer
        'Realiza una búsqueda de la combinación NIF - País que no sean del cliente indicado y devuelve el número de coincidencias. 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(codcli) from clientes WHERE codcli <> " & icodCli & " AND nif like '" & sNIF & "' AND pais LIKE '" & sPais & "'", con)
            con.Open()

            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function campoNIF(ByVal iidCliente As Integer) As String

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select NIF from clientes WHERE idCliente = " & iidCliente, con)
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


    Public Function PaisFiscal(ByVal iidCliente As Integer) As Integer
        'Dice si se trata de un cliente español
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select Min(idPais) from Ubicaciones left Join Clientes ON Clientes.idCliente = Ubicaciones.idCliente left join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion WHERE Fiscal = 1 AND Clientes.idCliente = " & iidCliente
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is Nothing Or o Is DBNull.Value Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function busquedacliente(ByVal sparametrosql As String) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select * from clientes " & sparametrosql, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
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

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Clientes", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Clientes WHERE  " & busqueda, con)
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

    Public Function codCliExiste(ByVal scodCli As String, ByVal iidCliente As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Clientes con ese código en un Cliente diferente
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT codCli FROM Clientes WHERE codCli = '" & scodCli & "' AND idCliente <> " & iidCliente
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CStr(o) = scodCli)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using

    End Function

    Public Function NIFExiste(ByVal NIF As String, ByVal iidCliente As Integer, ByVal iidPais As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Clientes con ese NIF en un Cliente diferente
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT TOP 1 NIF FROM Clientes left join ubicaciones ON Ubicaciones.idCliente = Clientes.idCliente left join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion WHERE Fiscal=1 and Ubicaciones.Activo= 1 and NIF = '" & NIF & "' AND Clientes.idCliente <> " & iidCliente & " AND idPais = " & iidPais
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()

                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return (CStr(o) = NIF)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
           
            End Try

        End Using

    End Function

    Public Function codContableExiste(ByVal scodContable As String, ByVal iidCliente As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Clientes con ese código en un Cliente diferente
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT codContable FROM Clientes WHERE codContable = '" & scodContable & "' AND idCliente <> " & iidCliente
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
            Finally
                desconectado()
            End Try

        End Using

    End Function




    Public Function insertar(ByVal dts As datoscliente) As Integer
        Dim sconexion As String = CadenaConexion()

        'dts.gidCliente = NuevoidCliente()
        Dim sel As String
        sel = "insert into clientes ( codCli,codContable, NombreComercial, NombreFiscal, FechaAlta, FechaBaja, Activo, idResponsableCuenta, Web, observaciones, Nif,ObservacionesProd, idCreador, Creacion) values"
        sel = sel & " ( @codCli, @codContable, @NombreComercial, @NombreFiscal, @FechaAlta, @FechaBaja, @Activo, @idResponsableCuenta, @Web, @observaciones, @Nif,@ObservacionesProd, @idCreador, @Creacion) Select @@Identity "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'cmd = New SqlCommand("insertar")
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.Connection = cnn
                'cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("codCli", dts.gcodCli)
                cmd.Parameters.AddWithValue("codContable", dts.gcodContable)
                cmd.Parameters.AddWithValue("nombrecomercial", dts.gnombrecomercial)
                cmd.Parameters.AddWithValue("nombrefiscal", dts.gnombrefiscal)
                cmd.Parameters.AddWithValue("fechaAlta", dts.gfechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idResponsableCuenta", dts.gidResponsableCuenta)
                cmd.Parameters.AddWithValue("web", dts.gweb)
                cmd.Parameters.AddWithValue("observaciones", dts.gobservaciones)
                cmd.Parameters.AddWithValue("nif", dts.gnif)
                cmd.Parameters.AddWithValue("ObservacionesProd", dts.gObservacionesProd)

                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datoscliente) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update clientes set codCli = @codCli, codContable = @codContable, nombrecomercial = @nombrecomercial,  nombrefiscal = @nombrefiscal, fechaalta = @fechaalta, fechaBaja = @fechaBaja, "
        sel = sel & " Activo = @Activo, idResponsableCuenta = @idResponsableCuenta, web = @web, observaciones = @observaciones, nif = @nif,ObservacionesProd = @ObservacionesProd, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " where idCliente = @idCliente "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("codCli", dts.gcodCli)
                cmd.Parameters.AddWithValue("codContable", dts.gcodContable)
                cmd.Parameters.AddWithValue("nombrecomercial", dts.gnombrecomercial)
                cmd.Parameters.AddWithValue("nombrefiscal", dts.gnombrefiscal)
                cmd.Parameters.AddWithValue("fechaAlta", dts.gfechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idResponsableCuenta", dts.gidResponsableCuenta)
                cmd.Parameters.AddWithValue("web", dts.gweb)
                cmd.Parameters.AddWithValue("observaciones", dts.gobservaciones)
                cmd.Parameters.AddWithValue("nif", dts.gnif)
                cmd.Parameters.AddWithValue("ObservacionesProd", dts.gObservacionesProd)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function


    Public Function actualizarResponsable(ByVal iidCliente As Integer, ByVal iidComercial As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update clientes set idResponsableCuenta = @idResponsableCuenta, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " where idCliente = @idCliente "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idCliente", iidCliente)
                cmd.Parameters.AddWithValue("idResponsableCuenta", iidComercial)
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


    Public Function campoCliente(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select nombreComercial from clientes WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim resultado As String = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function



    Public Function campoCliente(ByVal codCli As String) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select nombreComercial from clientes WHERE codCli = '" & codCli & "' ", con)
            con.Open()
            Dim resultado As String = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function campoCodCli(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select codCli from clientes WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim resultado As String = cmd.ExecuteScalar()
            con.Close()
            Return resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoMoneda(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select codMoneda from Facturacion  WHERE idCliente = " & iidCliente, con)
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

    Public Function campoResponsable(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Nombre + ' ' + Apellidos FROM Clientes LEFT JOIN Personal ON Personal.idPersona = Clientes.idResponsableCuenta  WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Or resultado Is Nothing Then
                Return ""
            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function campoObservaciones(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Observaciones FROM Clientes  WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Or resultado Is Nothing Then
                Return ""
            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function campoidCliente(ByVal sCliente As String) As Integer
        Try
            sCliente = Trim(sCliente)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            sCliente = UCase(Trim(sCliente))
            sCliente = Replace(sCliente, ".", "")
            cmd = New SqlCommand("select idCliente FROM Clientes  WHERE Replace(Upper(NombreComercial),'.','') like '" & sCliente & "%' ", con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Or resultado Is Nothing Then
                Return 0
            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoidCliente2(ByVal sCliente As String) As Integer
        Try
            sCliente = Trim(sCliente)
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            sCliente = UCase(Trim(sCliente))
            Dim n As Integer = Len(sCliente)
            Dim n0 As Integer = n - 2
            If n0 < 11 Then n0 = 11
            sCliente = Microsoft.VisualBasic.Left(sCliente, n0)
            sCliente = Replace(sCliente, ".", "")
            sCliente = Replace(sCliente, ",", "")
            cmd = New SqlCommand("select idCliente FROM Clientes  WHERE len(NombreComercial)<= " & n + 2 & " AND Replace(Replace(Upper(substring(NombreComercial,1," & n0 & ")),'.',''),',','') = '" & sCliente & "' ", con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Or resultado Is Nothing Then
                Return 0
            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function




    Public Function ObservacionesProd(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select ObservacionesProd FROM Clientes  WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim resultado As Object = cmd.ExecuteScalar()
            con.Close()
            If resultado Is DBNull.Value Or resultado Is Nothing Then
                Return ""
            Else
                Return resultado
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function



    Public Function ClientenUso(ByVal iidCliente As Integer) As Boolean
        'Nos dice si el Cliente está en uso en Fabricación, Facturas de Clientes, Materias PRimas, PEdidos a Cliente, Previsiones y Productos
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Select idCliente from Pedidos  where idCliente = @idCliente union "
        sel = " Select idCliente from Proformas  where idCliente = @idCliente union "
        sel = sel & "Select idCliente from Albaranes  where idCliente = @idCliente union "
        sel = sel & "Select idCliente from Facturas  where idCliente = @idCliente union "
        sel = sel & "Select idCliente from Ofertas  where idCliente = @idCliente union "
        sel = sel & "Select idCliente from ArticuloCliente  where idCliente = @idCliente  "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idCliente", iidCliente)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o) = iidCliente
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function borrar(ByVal iidCliente As Integer) As Boolean
        If iidCliente > 0 Then
            If ClientenUso(iidCliente) Then
                MsgBox("Este Cliente está en uso. No se puede borrar.")
                Return False
            Else
                'Borrar Mails
                Dim funcMA As New FuncionesMails
                funcMA.borrarCliente(iidCliente)
                'Borrar Telefonos
                Dim funcTE As New FuncionesTelefonos
                funcTE.borrarCliente(iidCliente)
                'Borrar los contactos
                Dim funcC As New funcionesContactos
                funcC.borrarCliente(iidCliente)
                'Borrar la Facturacion
                Dim funcFA As New funcionesFacturacion
                funcFA.borrarCliente(iidCliente)
                'Borrar las ubicaciones
                Dim funcU As New funcionesUbicaciones
                funcU.borrarCliente(iidCliente)
                'Borrar el cliente
                Dim sconexion As String = CadenaConexion()
                Dim sel As String

                sel = "delete from Clientes where idCliente = " & iidCliente

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
                   
                    End Try

                End Using
            End If
        End If


    End Function





    Public Function Documentos(ByVal vcodCli As String) As DataTable
        'Devuelve la lista de documentos asociados al cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT CLI_Documentos.codDocumento, Documentos.*, TiposDocumento.TipoDoc FROM (CLI_Documentos LEFT JOIN Documentos ON Documentos.codDocumento = CLI_Documentos.codDocumento) LEFT JOIN TiposDocumento ON TiposDocumento.IDTipo = Documentos.IdTipo WHERE codCli =  '" & vcodCli & "'", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function DocExiste(ByVal vCodCli As String, ByVal vcodDocumento As Integer) As Boolean
        ' Indica si existe la relación 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select codDocumento FROM CLI_Documentos WHERE (codCli = '" & vCodCli & "' AND codDocumento = " & vcodDocumento & ")"

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteScalar = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function BorrarDoc(ByVal vcodCli As String, ByVal vcodDocumento As Integer) As Boolean
        'Borra la relación de el cliente con un documento y si no quedan relaciones, borra el documento de la tabla Documentos
        Try
            Dim resultado As Boolean
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from CLI_Documentos WHERE (codCli = '" & vcodCli & "' AND codDocumento = " & vcodDocumento & ")"
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                If t = 1 Then
                    resultado = True
                Else
                    resultado = False
                End If

            End Using

            'Si no existen más relaciones de este documento, se borrará de la tabla de documentos

            Dim func As New FuncionesDocumentos
            func.borrar(vcodDocumento)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function

    Public Function NuevoDoc(ByVal vcodCli As String, ByVal vcodDocumento As Integer) As Integer
        ' Añadir una entrada a la tabla de relación Prod_Documento si no existia ya
        Try
            If DocExiste(vcodCli, vcodDocumento) Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("INSERT INTO CLI_Documentos (codDocumento,codCli) Values (@codDocumento, @codCli)", con)
                cmd.Parameters.AddWithValue("codDocumento", vcodDocumento)
                cmd.Parameters.AddWithValue("codCli", vcodCli)
                con.Open()
                Return cmd.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function





End Class
