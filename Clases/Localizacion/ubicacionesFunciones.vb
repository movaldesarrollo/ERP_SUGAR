Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesUbicaciones

    Inherits conexion
    Dim cmd As SqlCommand
    
    Dim sel0 As String = "select Ubicaciones.*, TipoUbicacion, Pais, NIFObligatorio, Exportacion, Idioma, Proveedores.NombreComercial as AgenciaTransporte " _
            & " from ubicaciones left Join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion " _
            & " left join Paises ON Paises.idPais = Ubicaciones.idPais " _
            & " left outer join Proveedores ON Proveedores.idProveedor = Ubicaciones.idTransporte " _
            & " left join idiomas on Idiomas.idIdioma = Ubicaciones.idIdioma "
           

    Public Function mostrarProv(ByVal iidProveedor As Integer, ByVal SoloActivos As Boolean, ByVal Fiscal As Boolean, ByVal Cliente As Boolean, ByVal Proveedor As Boolean, ByVal Postal As Boolean, ByVal Entrega As Boolean, ByVal Recogida As Boolean) As List(Of datosUbicacion)
        'Muestra todas las ubicaciones de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String
            sel = sel0 & " where Ubicaciones.idProveedor = " & iidProveedor
            sel = sel & If(SoloActivos, " AND Ubicaciones.Activo = 1 ", "") & If(Fiscal, " AND Fiscal = 1 ", "") & If(Proveedor, " AND Proveedor = 1 ", "") & If(Postal, " AND Postal = 1 ", "") & If(Entrega, " AND Entrega = 1 ", "") & If(Recogida, " AND Recogida = 1 ", "") & If(Cliente, " AND Cliente = 1 ", "")

            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosUbicacion)
                'Dim dts As datosUbicacion
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
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

    Private Function CargarLinea(ByVal linea As DataRow) As datosUbicacion
        Dim dts As New datosUbicacion
        dts.gidUbicacion = linea("idUbicacion")
        dts.gidTipoUbicacion = If(linea("idTipoUbicacion") Is DBNull.Value, 0, linea("idTipoUbicacion"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gfechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
        dts.gfechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
        dts.gdireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gSubCliente = If(linea("SubCliente") Is DBNull.Value, "", linea("SubCliente"))
        dts.gNoMuestraCliente = If(linea("NoMuestraCliente") Is DBNull.Value, False, linea("NoMuestraCliente"))
        dts.glocalidad = If(linea("Localidad") Is DBNull.Value, "", linea("Localidad"))
        dts.gcodpostal = If(linea("codPostal") Is DBNull.Value, "", linea("codPostal"))
        dts.gprovincia = If(linea("Provincia") Is DBNull.Value, "", linea("Provincia"))
        dts.ghorario = If(linea("Horario") Is DBNull.Value, "", linea("Horario"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
        dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
        dts.gidIdioma = If(linea("idIdioma") Is DBNull.Value, 0, linea("idIdioma"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))
        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gTipoUbicacion = If(linea("TipoUbicacion") Is DBNull.Value, "", linea("TipoUbicacion"))
        dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
        dts.gIdioma = If(linea("Idioma") Is DBNull.Value, "", linea("Idioma"))
        dts.gAgenciaTransporte = If(linea("AgenciaTransporte") Is DBNull.Value, "", linea("AgenciaTransporte"))
        dts.gExportacion = If(linea("Exportacion") Is DBNull.Value, False, linea("Exportacion"))
        dts.gNIFObligatorio = If(linea("NIFObligatorio") Is DBNull.Value, False, linea("NIFObligatorio"))
        Return dts
    End Function



    Public Function mostrarCliProforma(ByVal iidCliente As Integer, ByVal SoloActivos As Boolean)
        'Muestra todas las ubicaciones de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " where idCliente = " & iidCliente
            sel = sel & If(SoloActivos, " AND Ubicaciones.Activo = 1 ", "")

            sel = sel & " ORDER BY Fiscal DESC, subCliente, Localidad "
            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosUbicacion)
                'Dim dts As datosUbicacion
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrarCli(ByVal iidCliente As Integer, ByVal SoloActivos As Boolean, ByVal Fiscal As Boolean, ByVal Cliente As Boolean, ByVal Proveedor As Boolean, ByVal Postal As Boolean, ByVal Entrega As Boolean, ByVal Recogida As Boolean) As List(Of datosUbicacion)
        'Muestra todas las ubicaciones de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " where idCliente = " & iidCliente
            sel = sel & If(SoloActivos, " AND Ubicaciones.Activo = 1 ", "") & If(Fiscal, " AND Fiscal = 1 ", "") & If(Proveedor, " AND Proveedor = 1 ", "") & If(Postal, " AND Postal = 1 ", "") & If(Entrega, " AND Entrega = 1 ", "") & If(Recogida, " AND Recogida = 1 ", "") & If(Cliente, " AND Cliente = 1 ", "")
            sel = sel & " ORDER BY Fiscal DESC, subCliente, Localidad "
            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosUbicacion)
                'Dim dts As datosUbicacion
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrarPropias(ByVal SoloActivos As Boolean, ByVal Fiscal As Boolean, ByVal Cliente As Boolean, ByVal Proveedor As Boolean, ByVal Postal As Boolean) As List(Of datosUbicacion)
        'Muestra todas las ubicaciones propias
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = sel0 & " where interna =  1 "
            sel = sel & If(SoloActivos, " AND Ubicaciones.Activo = 1 ", "") & If(Fiscal, " AND Fiscal = 1 ", "") & If(Proveedor, " AND Proveedor = 1 ", "") & If(Postal, " AND Postal = 1 ", "") & If(Cliente, " AND Cliente = 1 ", "")

            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of datosUbicacion)
                'Dim dts As datosUbicacion
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function


    Public Function mostrar1(ByVal iidUbicacion As Integer) As datosUbicacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New datosUbicacion
            sel = sel0 & " where idUbicacion = " & iidUbicacion
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idUbicacion") Is DBNull.Value Then
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

    Public Function mostrar1ProvF(ByVal iidProveedor As Integer) As datosUbicacion
        'Muestra la dirección fiscal o la primera Fiscal y Recogida de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = sel0 & " where fiscal=1 and Proveedor=1 and Ubicaciones.idProveedor = " & iidProveedor & " Order By Ubicaciones.idTipoUbicacion ASC"
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosUbicacion
                Dim linea As DataRow
                If dt.Rows.Count > 0 Then
                    linea = dt.Rows.Item(0)
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                End If

                Return dts
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar1ProvR(ByVal iidProveedor As Integer) As datosUbicacion
        'Muestra la dirección Recogida o la primera Fiscal y Recogida de un proveedor
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " where Proveedor = 1 and Recogida = 1  and Ubicaciones.idProveedor = " & iidProveedor & " Order By idTipoUbicacion ASC"
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosUbicacion
                Dim linea As DataRow
                If dt.Rows.Count > 0 Then
                    linea = dt.Rows.Item(0)
                    If linea("idUbicacion") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                End If

                Return dts
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function





    Public Function subClientes(ByVal iidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = " Select distinct UPPER(subCliente) as subCliente from Ubicaciones where subCliente <> '' and idCliente = " & iidCliente & " Order By subCliente ASC "

            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim subCliente As String = ""
                Dim CadenaDeSubClientes As String = ""
                For Each linea As DataRow In dt.Rows
                    subCliente = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))
                    If subCliente <> "" Then
                        If CadenaDeSubClientes <> "" Then CadenaDeSubClientes = CadenaDeSubClientes & ", "
                        CadenaDeSubClientes = CadenaDeSubClientes & subCliente
                    End If
                Next
                Return CadenaDeSubClientes
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function mostrarCliente(ByVal scodcli As Double) As DataTable
        'devuelve la lista de direcciones de Cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If scodcli > 0 Then
                cmd = New SqlCommand("select * from ubicaciones where tipoUbicacion in ('Cliente','FISCAL Y Cliente') and codcli = " & scodcli & "", con)
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

    Public Function TextoComp(ByVal iidUbicacion As Double) As String
        'devuelve la lista de direcciones de Cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim texto As String = ""
            Dim con As New SqlConnection(sconexion)
            If iidUbicacion > 0 Then
                cmd = New SqlCommand("select * from ubicaciones where idUbicacion = " & iidUbicacion, con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim row As DataRow
                For Each row In dt.Rows
                    'texto = If(row("SubCliente") Is DBNull.Value, "", row("SubCliente"))
                    'texto = texto & IIf(texto = "", "", ": ")
                    'texto = texto & If(row("Localidad") Is DBNull.Value, "", row("Localidad"))
                    'texto = texto & IIf(texto = "", "", " - ")
                    'texto = texto & If(row("Direccion") Is DBNull.Value, "", row("Direccion"))
                    texto = TextoUbic(If(row("SubCliente") Is DBNull.Value, "", row("SubCliente")), If(row("Localidad") Is DBNull.Value, "", row("Localidad")), If(row("Direccion") Is DBNull.Value, "", row("Direccion")))

                Next
            Else
                con.Close()
            End If
            Return texto
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function TextoUbic(ByVal SubCliente As String, ByVal Localidad As String, ByVal Direccion As String) As String
        'Devuelve un string de la ubicación combinando Subcliente, localidad y dirección
        Dim texto As String = SubCliente
        texto = texto & IIf(texto = "", "", ": ")
        texto = texto & Localidad
        texto = texto & IIf(texto = "", "", " - ")
        texto = texto & Direccion
        Return texto
    End Function

    Public Function mostrarCliente0() As DataTable
        'devuelve la lista de direcciones de Cliente oropias de la propia empresa, que será la que CodCli=0
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from ubicaciones where idtipoUbicacion in (1,2) and idCliente = 0 ", con)

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


    Public Function mostrarFiscal(ByVal scodcli As Double) As DataTable
        ' devuelve la lista de direcciones fiscales
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If scodcli > 0 Then
                cmd = New SqlCommand("select * from ubicaciones where tipoUbicacion in ('FISCAL','FISCAL Y Cliente') and codcli = " & scodcli & "", con)
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

    Public Function ExisteFiscal(ByVal iidCliente As Integer, ByVal iidProveedor As Integer) As Boolean
        ' devuelve la lista de direcciones fiscales
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idUbicacion) from Ubicaciones left join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion where Activo = 1 AND Fiscal = 1 "
            If iidCliente > 0 Then
                sel = sel & " AND idCliente = " & iidCliente
            End If
            If iidProveedor > 0 Then
                sel = sel & " AND idPRoveedor = " & iidProveedor
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim Resultado As Integer = cmd.ExecuteScalar
            con.Close()
            Return (Resultado > 0)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExistePais(ByVal iidPais As Integer) As Boolean

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idUbicacion) from Ubicaciones  where idPais = " & iidPais

            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim Resultado As Integer = cmd.ExecuteScalar
            con.Close()
            Return (Resultado > 0)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function DireccionFiscal(ByVal iidCliente As Integer, ByVal iidProveedor As Integer) As Integer
        ' devuelve la id de la dirección fiscal
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idUbicacion from Ubicaciones left join TiposUbicacion ON TiposUbicacion.idTipoUbicacion = Ubicaciones.idTipoUbicacion where Activo = 1 AND Fiscal = 1 "
            If iidCliente > 0 Then
                sel = sel & " AND idCliente = " & iidCliente
            End If
            If iidProveedor > 0 Then
                sel = sel & " AND idPRoveedor = " & iidProveedor
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


    Public Function campoIdioma(ByVal vCodUbic As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idIdioma from ubicaciones WHERE idUbicacion = " & vCodUbic, con)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar()
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return 1
            Else
                Return CInt(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function campoExportacion(ByVal vCodUbic As Integer) As Integer
        'Hay exportación en los paises marcados y
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Exportacion  from ubicaciones left join Paises ON Paises.idPais = Ubicaciones.idPais WHERE idUbicacion = " & vCodUbic, con)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar()
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return False
            Else
                Return CBool(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoidPais(ByVal vCodUbic As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idPais from ubicaciones WHERE idUbicacion = " & vCodUbic, con)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar()
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return 1
            Else
                Return CInt(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function




    Public Function campoCorreo(ByVal vidUbicacion As Integer) As String  'Devuelve la dirección de mail
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select mail from Mails WHERE idUbicacion = " & vidUbicacion & " ORDER BY ORDEN", con)
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


    Public Function campoPortes(ByVal iidUbicacion As Integer) As Char
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Portes from Ubicaciones WHERE idUbicacion = " & iidUbicacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return "P"
            Else
                Return CChar(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoidTransporte(ByVal iidUbicacion As Integer) As Integer  '
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idTransporte from Ubicaciones WHERE idUbicacion = " & iidUbicacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return 0
            Else
                Return CInt(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoTransporte(ByVal iidUbicacion As Integer) As String  '
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Transporte from Ubicaciones WHERE idUbicacion = " & iidUbicacion, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return 0
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function insertar(ByVal dts As datosUbicacion) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into ubicaciones (idTipoubicacion,idCliente, idProveedor,  fechaalta, fechaBaja, direccion, subCliente, NoMuestraCliente, localidad, codpostal, provincia, horario, observaciones,  Activo, idPais, idIdioma, Portes, idTransporte, Transporte, idCreador, Creacion) "
        sel = sel & " values (@idTipoubicacion, @idCliente, @idProveedor, @fechaalta, @FechaBaja, @direccion, @subCliente, @NoMuestraCliente, @localidad, @codpostal, @provincia, @horario, @observaciones,@Activo, @idPais, @idIdioma, @Portes, @idTransporte, @Transporte, @idCreador, @Creacion ) SELECT @@Identity "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)



                cmd.Parameters.AddWithValue("idTipoubicacion", dts.gidTipoUbicacion)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("fechaAlta", dts.gfechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("direccion", dts.gdireccion)
                cmd.Parameters.AddWithValue("subCliente", dts.gSubCliente)
                cmd.Parameters.AddWithValue("NoMuestraCliente", dts.gNoMuestraCliente)
                cmd.Parameters.AddWithValue("localidad", dts.glocalidad)
                cmd.Parameters.AddWithValue("codpostal", dts.gcodpostal)
                cmd.Parameters.AddWithValue("provincia", dts.gprovincia)
                cmd.Parameters.AddWithValue("horario", dts.ghorario)
                cmd.Parameters.AddWithValue("observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPais", dts.gidPais)
                cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)


                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteScalar)
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosUbicacion) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ubicaciones set idtipoubicacion = @idtipoubicacion,  idCliente = @idCliente, idProveedor = @idProveedor, fechaalta = @fechaalta, fechaBaja = @fechaBaja,  "
        sel = sel & " direccion = @direccion, subCliente = @subCliente, NoMuestraCliente = @NoMuestraCliente, localidad = @localidad, codpostal = @codpostal, "
        sel = sel & " provincia = @provincia, horario = @horario, observaciones = @observaciones, Activo = @Activo, idPais = @idpais, idIdioma = @idIdioma, Portes = @Portes, idTransporte = @idTransporte, Transporte = @Transporte, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " where idUbicacion = @idUbicacion "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idTipoubicacion", dts.gidTipoUbicacion)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("fechaAlta", dts.gfechaAlta)
                cmd.Parameters.AddWithValue("fechaBaja", dts.gfechaBaja)
                cmd.Parameters.AddWithValue("direccion", dts.gdireccion)
                cmd.Parameters.AddWithValue("subCliente", dts.gSubCliente)
                cmd.Parameters.AddWithValue("NoMuestraCliente", dts.gNoMuestraCliente)
                cmd.Parameters.AddWithValue("localidad", dts.glocalidad)
                cmd.Parameters.AddWithValue("codpostal", dts.gcodpostal)
                cmd.Parameters.AddWithValue("provincia", dts.gprovincia)
                cmd.Parameters.AddWithValue("horario", dts.ghorario)
                cmd.Parameters.AddWithValue("observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPais", dts.gidPais)
                cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
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

    Public Function borrar(ByVal iidUbicacion As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "delete from ubicaciones where idubicacion = " & iidUbicacion
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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
    'LUIS VERIFICAR DIRECCION FISCAL
    Public Function verificarFiscal(ByVal iidubicacion As Integer, ByVal iidcliente As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select count(*)from ubicaciones where idcliente=" & iidcliente & " and (idtipoubicacion=1 or idtipoubicacion=4 or idtipoubicacion=3) and idubicacion <>" & iidubicacion

            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim Resultado As Integer = CInt(cmd.ExecuteScalar)
            con.Close()
            If Resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function borrarProveedor(ByVal iidProveedor As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "delete from ubicaciones where idProveedor = " & iidProveedor
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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

    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "delete from ubicaciones where idCliente = " & iidCliente
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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


End Class
