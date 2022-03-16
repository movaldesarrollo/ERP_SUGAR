

Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesMoneda
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar(ByVal vMONEDA As String) As DataTable 'Devuelve la lista de monedas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If vMONEDA = "" Then
                cmd = New SqlCommand("SELECT  * FROM Monedas", con)
            Else
                cmd = New SqlCommand("SELECT  * FROM Monedas WHERE codMONEDA = '" & vMONEDA & "'", con)
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

    Public Function Mostrar() As List(Of DatosMoneda) 'Devuelve la lista de monedas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT  * FROM Monedas ORDER BY Divisa ASC", con)

            con.Open()
            Dim lista As New List(Of DatosMoneda)
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosMoneda
                For Each linea As DataRow In dt.Rows
                    dts = New DatosMoneda
                    dts.gCAMBIO = If(linea("Cambio") Is DBNull.Value, 1, CDbl(linea("Cambio")))
                    dts.gDIVISA = If(linea("Divisa") Is DBNull.Value, "EURO", linea("Divisa"))
                    dts.gFechaCambio = If(linea("FechaCambio") Is DBNull.Value, Now.Date, linea("FechaCambio"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                    dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
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

    Public Function Mostrar1(ByVal scodMoneda As String) As DatosMoneda
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT  * FROM Monedas WHERE codMoneda = '" & scodMoneda & "' ", con)

            con.Open()
            Dim dts As New DatosMoneda
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    dts.gCAMBIO = If(linea("Cambio") Is DBNull.Value, 1, CDbl(linea("Cambio")))
                    dts.gDIVISA = If(linea("Divisa") Is DBNull.Value, "EURO", linea("Divisa"))
                    dts.gFechaCambio = If(linea("FechaCambio") Is DBNull.Value, Now.Date, linea("FechaCambio"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                    dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
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



    Public Function Existe(ByVal scodMoneda As String) As Boolean 'Nos dice si existe una moneda
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT  codMoneda FROM Monedas WHERE codMoneda = '" & scodMoneda & "'", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (UCase(CStr(o)) = UCase(scodMoneda))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CampoDivisa(ByVal scodMoneda As String) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT  DIVISA FROM Monedas WHERE codMoneda = '" & scodMoneda & "'", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return UCase(CStr(o))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CampoFecha(ByVal scodMoneda As String) As Date
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT FechaCambio FROM Monedas WHERE codMoneda = '" & scodMoneda & "'", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return CDate("1-1-1900")
            Else
                Return CDate(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CampoSimbolo(ByVal scodMoneda As String) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT  Simbolo FROM Monedas WHERE codMONEDA = '" & scodMoneda & "'", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return scodMoneda
            Else
                Return If(CStr(o) = "", scodMoneda, CStr(o))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Cambio(ByVal valor As Double, ByVal vMONEDA1 As String, ByVal vMONEDA2 As String, ByRef Aviso As Boolean, ByRef FechaCambio As Date) As Double 'Devuelve el valor en otra moneda
        Try
            If vMONEDA1 = "" Or vMONEDA2 = "" Then
                Return valor
            Else
                Dim dt As DataTable = Mostrar(vMONEDA1)
                Dim linea As DataRow
                Dim cambio1 As Double
                Dim FechaCambio2 As Date
                Aviso = False
                For Each linea In dt.Rows
                    cambio1 = If(linea("CAMBIO") Is DBNull.Value, 0, linea("CAMBIO"))
                    FechaCambio = If(linea("FechaCambio") Is DBNull.Value, Now.Date, linea("FechaCambio"))
                    Aviso = (If(linea("FechaCambio") Is DBNull.Value, Now.Date, linea("FechaCambio")) <> Now.Date)
                Next
                Dim cambio2 As Double
                dt = Mostrar(vMONEDA2)
                For Each linea In dt.Rows
                    cambio2 = If(linea("CAMBIO") Is DBNull.Value, 0, linea("CAMBIO"))
                    FechaCambio2 = If(linea("FechaCambio") Is DBNull.Value, Now.Date, linea("FechaCambio"))
                    Aviso = Aviso Or FechaCambio2 <> Now.Date
                Next
                If FechaCambio > FechaCambio2 Then 'Devolvemos por referencia la fecha más antigua
                    FechaCambio = FechaCambio2
                End If
                Return valor * cambio2 / cambio1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function insertar(ByVal scodMoneda As String, ByVal vCambio As Double, ByVal vDivisa As String) As Integer
        'Insertar un nuevo precio de coste
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Monedas (codMoneda, CAMBIO, DIVISA) values (@codMoneda,@CAMBIO, @DIVISA) WHERE codMONEDA = '" & scodMoneda & "'"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("CAMBIO", vCambio)
                cmd.Parameters.AddWithValue("DIVISA", vDivisa)

                con.Open()
                Return cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function insertar(ByVal dts As DatosMoneda) As Integer
        'Insertar un nuevo precio de coste
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Monedas (codMoneda, CAMBIO, DIVISA, FechaCambio, Simbolo) values (@codMoneda,@CAMBIO, @DIVISA, @FechaCambio, @Simbolo) "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("CAMBIO", dts.gCAMBIO)
                cmd.Parameters.AddWithValue("DIVISA", dts.gDIVISA)
                cmd.Parameters.AddWithValue("FechaCambio", dts.gFechaCambio)
                cmd.Parameters.AddWithValue("Simbolo", dts.gSimbolo)

                con.Open()
                Return cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal scodMoneda As String, ByVal vCambio As Double, ByVal vDivisa As String) As Boolean
        'Actualiza un registro de la tabla de precios de coste con los nuevo valores. 
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Monedas set  CAMBIO = @CAMBIO, DIVISA = @DIVISA  WHERE codMoneda = '" & scodMoneda & "'"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("CAMBIO", vCambio)
                cmd.Parameters.AddWithValue("DIVISA", vDivisa)

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
            Finally
                desconectado()
            End Try
        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosMoneda) As Boolean
        'Actualiza un registro de la tabla de precios de coste con los nuevo valores. 
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        If dts.gDIVISA = "" And dts.gSimbolo = "" Then 'Si no hemos puesto la divisa, no la cambiamos
            sel = "update Monedas set  CAMBIO = @CAMBIO,  FechaCambio = @FechaCambio  WHERE codMoneda = @codMoneda "
        Else
            sel = "update Monedas set  CAMBIO = @CAMBIO, DIVISA = @DIVISA, FechaCambio = @FechaCambio, Simbolo = @Simbolo  WHERE codMoneda = @codMoneda "
        End If

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("CAMBIO", dts.gCAMBIO)
                cmd.Parameters.AddWithValue("DIVISA", dts.gDIVISA)
                cmd.Parameters.AddWithValue("FechaCambio", dts.gFechaCambio)
                cmd.Parameters.AddWithValue("Simbolo", dts.gSimbolo)

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
            Finally
                desconectado()
            End Try
        End Using
    End Function

    Public Function borrar(ByVal scodMoneda As String) As Boolean
        'Borra una propiedad
        Dim sel As String
        Dim sconexion As String = CadenaConexion()
        Dim func As New FuncionesDocumentos

        sel = "DELETE FROM Monedas WHERE codMoneda = '" & scodMoneda & "'"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

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
            Finally
                desconectado()
            End Try
        End Using
    End Function


    Public Function EnUso(ByVal scodMoneda As String) As Boolean 'Nos indica si la moneda en cuestión está en uso.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "SELECT   MONEDA FROM Productos WHERE MONEDA = @MONEDA UNION "
            sel = sel & "SELECT MONEDA_PC FROM Productos WHERE MONEDA_PC = @MONEDA UNION "
            sel = sel & "SELECT Moneda FROM PROD_PreciosCoste WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM PROD_PreciosVenta WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Clientes WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Prospects WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Proformas WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Pedidos WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Ofertas WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Albaranes WHERE Moneda = @MONEDA UNION  "
            sel = sel & "SELECT Moneda FROM Facturas WHERE Moneda = @MONEDA "

            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("MONEDA", scodMoneda)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CStr(o) = scodMoneda)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    
End Class
