Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class Master

    Inherits conexion
    Dim cmd As SqlCommand


    Dim codigo As Integer = 0
    Dim coderror As Integer = 0
    Private funcFE As New FuncionesFestivos


    Public Function leerCodigo(ByVal campo As String, ByVal numeracion As Integer) As Integer

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & campo & " from Master where numeracion='" & numeracion & "'", con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If CStr(ob) = "" Then
                Return -1
            Else
                Return CInt(ob)
            End If


        Catch ex As Exception
            ex.Data.Add("Campo", campo)
            ex.Data.Add("Numeracion", numeracion)
            CorreoError(ex)
            Return -1
        End Try

    End Function

    Public Function NuevoAño() As Integer
        Try
            Dim Nuevo As Integer = Now.Year
            If ExisteAño(Nuevo) Then
                Return -1
            Else
                Dim x As Integer
                x = (Nuevo * 10000)
                Dim viejo As Integer = Nuevo - 1
                If ExisteAño(viejo) Then
                    Dim dts As DatosMaster = mostrar1(viejo)
                    dts.gnumeracion = Nuevo
                    dts.gnumPedidoProv = x
                    dts.gnumPedido = x
                    dts.gnumOferta = x
                    'dts.gnumReparacion = x
                    dts.gnumProforma = x
                    dts.gnumAlbaran = x
                    'dts.gnumFactura = x
                    dts.gnumFraProveedor = x
                    Call insertar(dts)
                    Return Nuevo
                Else
                    Dim dts As New DatosMaster
                    'Inicializa los contadores de documentos con el año y 0000
                    dts.gnumPedido = x
                    dts.gnumOferta = x
                    dts.gnumReparacion = x
                    dts.gnumProforma = x
                    dts.gnumAlbaran = x
                    dts.gnumFactura = x
                    dts.gnumSerie = x
                    dts.gnumSerie2 = x
                    dts.gDomesticosXDia = 30
                    dts.gIndustrialesXDia = 2
                    dts.gnumeracion = Nuevo
                    dts.gnumFraProveedor = x
                    dts.gnumPedidoProv = x
                    Call insertar(dts)
                    Return Nuevo
                End If
            End If
            Call CrearFestivos(Nuevo)

        Catch ex As Exception
            ex.Data.Add("Nuevo", Now.Year)
            CorreoError(ex)

        End Try

    End Function


    Public Sub CrearFestivos(ByVal Anyo As Integer)
        Dim lista As List(Of DatosFestivo) = funcFE.Busqueda(" year(Fecha) = " & Anyo - 1 & " AND Repetir = 1 ")
        For Each dts As DatosFestivo In lista
            dts.gFecha = CDate(dts.gFecha.Day & "-" & dts.gFecha.Month & "-" & dts.gFecha.Year + 1)
            If Not funcFE.EsFestividad(dts.gFecha) Then
                funcFE.insertar(dts)
            End If
        Next
    End Sub

    Private Function ExisteAño(ByVal any As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select numeracion from Master where numeracion=" & any, con)

            con.Open()

            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return False
            Else
                Return (any = CInt(ob))
            End If

        Catch ex As Exception
            CorreoError(ex)
            Return False

        End Try


    End Function


    Private Function leerCodigoDec(ByVal campo As String, ByVal numeracion As Integer) As Double

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & campo & " from Master where numeracion='" & numeracion & "'", con)

            con.Open()

            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If CStr(ob) = "" Then
                Return -1
            Else
                Return CDbl(ob)
            End If

        Catch ex As Exception
            CorreoError(ex)
            Return -1

        End Try

    End Function

    Private Function leerCadena(ByVal campo As String, ByVal numeracion As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & campo & " from Master where numeracion='" & numeracion & "'", con)

            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If
        Catch ex As Exception
            ex.Data.Add("Campo", campo)
            ex.Data.Add("Numeracion", numeracion)
            CorreoError(ex)
            Return ""

        End Try
    End Function

    Private Function leerBinario(ByVal campo As String, ByVal numeracion As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & campo & " from Master where numeracion='" & numeracion & "'", con)

            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return False
            Else
                Return CBool(ob)
            End If
        Catch ex As Exception
            ex.Data.Add("Campo", campo)
            ex.Data.Add("Numeracion", numeracion)
            CorreoError(ex)
            Return False

        End Try
    End Function


    Private Function incrementaCodigo(ByVal campo As String, ByVal numeracion As Integer) As Integer
        'codigo = leerCodigo(campo, numeracion)
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        'codigo = codigo + 1
        'sel = "update Master set " & campo & " = " & codigo & " where numeracion = " & numeracion
        sel = "update Master set " & campo & " = " & campo & " + 1 where numeracion = " & numeracion

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()

                Return leerCodigo(campo, numeracion)

            Catch ex As Exception
                ex.Data.Add("Campo", campo)
                ex.Data.Add("Numeracion", numeracion)
                CorreoError(ex)
                Return -1
            End Try

        End Using

    End Function
    Public Function incnumPedido(ByVal any As Integer) As Integer
        Return incrementaCodigo("numPedido", any)
    End Function

    Public Function incnumAlbaran(ByVal any As Integer) As Integer
        Return incrementaCodigo("numAlbaran", any)
    End Function

    Public Function incnumFactura(ByVal any As Integer) As Integer
        Return incrementaCodigo("numFactura", Now.Year) 'Trataremos el dato com no anualizado
    End Function

    Public Function incnumSerie(ByVal any As Integer) As Integer
        Return incrementaCodigo("numSerie", Now.Year) 'Trataremos el dato com no anualizado
    End Function

    Public Function incnumSerie2(ByVal any As Integer) As Integer
        Return incrementaCodigo("numSerie2", Now.Year) 'Trataremos el dato com no anualizado
    End Function
    Public Function incnumConceptoPedido(ByVal any As Integer) As Integer
        Return incrementaCodigo("numConceptoPedido", any)
    End Function

    Public Function incnumConceptoAlbaran(ByVal any As Integer) As Integer
        Return incrementaCodigo("numConceptoAlbaran", any)
    End Function

    Public Function incnumConceptoFactura(ByVal any As Integer) As Integer
        Return incrementaCodigo("numConceptoFactura", any)
    End Function

    Public Function inccodCli(ByVal any As Integer) As Integer
        Return incrementaCodigo("codCli", any)
    End Function
    Public Function incnumOferta(ByVal any As Integer) As Integer
        Return incrementaCodigo("numOferta", any)
    End Function
    Public Function incnumReparacion(ByVal any As Integer) As Integer
        Return incrementaCodigo("numReparacion", any)
    End Function


    Public Function incnumProforma(ByVal any As Integer) As Integer
        Return incrementaCodigo("numProforma", any)
    End Function
    Public Function incnumFraProveedor(ByVal any As Integer) As Integer
        Return incrementaCodigo("numFraProveedor", any)
    End Function

    Public Function incnumPedidoProv(ByVal any As Integer) As Integer
        Return incrementaCodigo("numPedidoProv", any)
    End Function

   

   

    Public Function incNumTicket(ByVal any As Integer) As Integer
        Return incrementaCodigo("NumTicket", any)
    End Function



  
    Public Function leernumAlbaran(ByVal any As Integer) As Integer
        Return leerCodigo("numAlbaran", any)
    End Function

    Public Function leernumPedido(ByVal any As Integer) As Integer
        Return leerCodigo("numPedido", any)
    End Function

    Public Function leernumFactura(ByVal any As Integer) As Integer
        Return leerCodigo("numFactura", Now.Year) 'Trataremos como no anualizado
    End Function

    Public Function leernumSerie(ByVal any As Integer) As Integer
        Return leerCodigo("numSerie", Now.Year) 'Trataremos como no anualizado
    End Function
    Public Function leernumSerie2(ByVal any As Integer) As Integer
        Return leerCodigo("numSerie2", Now.Year) 'Trataremos como no anualizado
    End Function

 
    Public Function leernumOferta(ByVal any As Integer) As Integer
        Return leerCodigo("numOferta", any)
    End Function

    Public Function leernumReparacion(ByVal any As Integer) As Integer
        Return leerCodigo("numReparacion", any)
    End Function

    Public Function leernumProforma(ByVal any As Integer) As Integer
        Return leerCodigo("numProforma", any)
    End Function

    Public Function leernumFraProveedor(ByVal any As Integer) As Integer
        Return leerCodigo("numFraProveedor", any)
    End Function
  

  

    Public Function leernumPedidoProv(ByVal any As Integer) As Integer
        Return leerCodigo("numPedidoProv", any)
    End Function

   

    Public Function leerDomesticosXDia(ByVal any As Integer) As Double
        Return leerCodigo("DomesticosXDia", any)
    End Function

    Public Function leerIndustrialesXDia(ByVal any As Integer) As Double
        Return leerCodigo("IndustrialesXDia", any)
    End Function




    Public Function listaAños() As DataTable
        'Lista los años de numeración que hay en Master

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select numeracion from Master order by numeracion asc", con)

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
            CorreoError(ex)
            Return Nothing
        End Try

    End Function


    Public Function mostrar(ByVal variable As String) As DataTable  'Búsqueda genérica a partir de una cadena SQL
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If variable = 0 Then
                cmd = New SqlCommand("SELECT * FROM master ", con)
            Else
                cmd = New SqlCommand("SELECT * FROM master WHERE numeracion =  " & variable, con)
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
            ex.Data.Add("Variable", variable)
            CorreoError(ex)
            Return Nothing
    
        End Try
    End Function

    Public Function ExisteNumeracion(ByVal Numeracion As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
           
            cmd = New SqlCommand("SELECT numeracion FROM master WHERE numeracion = " & Numeracion, con)
          
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CInt(o) = Numeracion)
            End If

        Catch ex As Exception
            ex.Data.Add("Numeracion", Numeracion)
            CorreoError(ex)
            Return Nothing

        End Try
    End Function

    Public Function mostrar1(ByVal iNumeracion As Integer) As DatosMaster
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT * FROM master WHERE numeracion =  " & iNumeracion, con)
            Dim dts As New DatosMaster
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts.gnumeracion = iNumeracion
                    dts.gnumPedidoProv = If(linea("numPedidoProv") Is DBNull.Value, 0, linea("numPedidoProv"))
                    dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
                    dts.gnumOferta = If(linea("numOferta") Is DBNull.Value, 0, linea("numOferta"))
                    dts.gnumReparacion = If(linea("numReparacion") Is DBNull.Value, 0, linea("numReparacion"))
                    dts.gnumProforma = If(linea("numProforma") Is DBNull.Value, 0, linea("numProforma"))
                    dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
                    dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
                    dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, 0, linea("numSerie"))
                    dts.gnumSerie2 = If(linea("numSerie2") Is DBNull.Value, 0, linea("numSerie2"))
                    dts.gDomesticosXDia = If(linea("DomesticosXDia") Is DBNull.Value, 0, linea("DomesticosXDia"))
                    dts.gIndustrialesXDia = If(linea("IndustrialesXDia") Is DBNull.Value, 0, linea("IndustrialesXDia"))
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception

            ex.Data.Add("iNumeracion", iNumeracion)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosMaster) As Integer 'Inserta una nueva serie en la tabla master


        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into master ( numeracion,  numPedidoProv, numPedido, numOferta,numReparacion, numProforma, numAlbaran, numFactura, numSerie,numSerie2, DomesticosXDia, IndustrialesXDia, Domesticos2XDia, RecambiosXDia)	"
        sel = sel & " values (@numeracion,  @numPedidoProv,@numPedido, @numOferta,@numReparacion, @numProforma, @numAlbaran, @numFactura, @numSerie,@numSerie2, @DomesticosXDia, @IndustrialesXDia, @Domesticos2XDia, @RecambiosXDia)"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numeracion", dts.gnumeracion)
                ' cmd.Parameters.AddWithValue("numFraProveedor", dts.gnumFraProveedor)
                cmd.Parameters.AddWithValue("numPedidoProv", dts.gnumPedidoProv)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
                cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("numSerie2", dts.gnumSerie2)
                cmd.Parameters.AddWithValue("DomesticosXDia", dts.gDomesticosXDia)
                cmd.Parameters.AddWithValue("IndustrialesXDia", dts.gIndustrialesXDia)
                cmd.Parameters.AddWithValue("Domesticos2XDia", dts.gDomesticos2XDia)
                cmd.Parameters.AddWithValue("RecambiosXDia", dts.gDomesticos2XDia)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                If t = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                ex.Data.Add("dts.gNumeracion", dts.gnumeracion)
                CorreoError(ex)
                Return Nothing
           
            End Try

        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosMaster) As Boolean   'Actualiza un registro de la tabla master
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update master set  
numOferta = @numOferta, numReparacion = @numReparacion, numPedido = @numPedido, numProforma = @numProforma, 
numAlbaran = @numAlbaran, numFactura = @numFactura,  numPedidoProv = @numPedidoProv, numSerie = @numSerie,  
numSerie2 = @numSerie2,  DomesticosXDia = @DomesticosXDia, IndustrialesXDia = @IndustrialesXDia, Domesticos2XDia = @Domesticos2XDia, RecambiosXDia = @RecambiosXDia
where numeracion = @numeracion "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos

                cmd.Parameters.AddWithValue("numeracion", dts.gnumeracion)

                cmd.Parameters.AddWithValue("numPedidoProv", dts.gnumPedidoProv)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
                cmd.Parameters.AddWithValue("numReparacion", dts.gnumReparacion)
                cmd.Parameters.AddWithValue("numProforma", dts.gnumProforma)
                cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("numSerie", dts.gnumSerie)
                cmd.Parameters.AddWithValue("numSerie2", dts.gnumSerie2)
                cmd.Parameters.AddWithValue("DomesticosXDia", dts.gDomesticosXDia)
                cmd.Parameters.AddWithValue("IndustrialesXDia", dts.gIndustrialesXDia)
                cmd.Parameters.AddWithValue("Domesticos2XDia", dts.gDomesticos2XDia)
                cmd.Parameters.AddWithValue("RecambiosXDia", dts.gDomesticos2XDia)

                'abrir conexion
                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                ex.Data.Add("dts.gNumeracion", dts.gnumeracion)
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizarCampo(ByVal campo As String, ByVal valor As Integer) As Boolean   'Actualiza un registro de la tabla master
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update master set  " & campo & " = " & valor & " where numeracion = " & Year(Now)

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function

    Public Function busquedaMaximos(ByVal tabla As String, ByVal campo As String) As String  'Búsqueda genérica de valores máximos
        Dim sel As String = " SELECT MAX(" & campo & ") FROM " & tabla
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
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
            ex.Data.Add("tabla", tabla)
            CorreoError(ex)
            Return Nothing
     
        End Try
    End Function



End Class
