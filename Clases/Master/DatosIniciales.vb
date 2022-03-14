Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class DatosIniciales
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function cambioMasivoPrecios(ByVal tipo As String, ByVal porcentaje As Double) As Boolean

        Dim Txporcentaje = Replace(1 + (porcentaje / 100), ",", ".")

        Dim con As New SqlConnection(CadenaConexion())

        Dim selInc As String = ""

        Dim cmd As New SqlCommand

        Try

            If tipo = "BBajar" Then

                selInc = "update articulos_precios  set Precio = (Precio / " & Txporcentaje & ") where TipoPrecio = 'V' or TipoPrecio = 'O'"

            ElseIf tipo = "BSubir" Then

                selInc = "update articulos_precios  set Precio = (Precio * " & Txporcentaje & ") where TipoPrecio = 'V' or TipoPrecio = 'O'"

            Else

                Return False

            End If

            cmd = New SqlCommand(selInc, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("Ha habido un error al actualizar los precios." & vbCrLf & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    Public Function ProntoPago() As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ProntoPago FROM DatosIniciales "
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

    Public Function Descuento() As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Descuento FROM DatosIniciales "
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

    Public Function Descuento2() As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Descuento2 FROM DatosIniciales "
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


    Public Function idArticuloOpcionBase() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT idArticuloOpcionBase FROM DatosIniciales "
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


    Public Function TipoIVA() As DatosTipoIVA
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DatosIniciales.idTipoIVA, Nombre, TipoIVA, TipoRecargoEq  from DatosIniciales left join TiposIVA ON TiposIVA.idTipoIVA = DatosIniciales.idTipoIVA and TiposIVA.Activo=1 "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoIVA
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoIVA") Is DBNull.Value Or linea("TipoIVA") Is DBNull.Value Then
                    Else
                        dts.gidTipoIVA = linea("idTipoIVA")
                        dts.gTipoIVA = linea("TipoIVA")
                        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
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


    Public Function TipoRetencion() As DatosTipoRetencion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DatosIniciales.idTipoRetencion, Nombre, TipoRetencion from DatosIniciales left join TiposRetencion ON TiposRetencion.idTipoRetencion = DatosIniciales.idTipoRetencion "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoRetencion
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoRetencion") Is DBNull.Value Or linea("TipoRetencion") Is DBNull.Value Then
                    Else
                        dts.gidTipoRetencion = linea("idTipoRetencion")
                        dts.gTipoRetencion = linea("TipoRetencion")
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
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

    Public Function Idioma() As IDComboBox
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DatosIniciales.idIdioma, Idioma from DatosIniciales left join Idiomas ON Idiomas.idIdioma = DatosIniciales.idIdioma "
            cmd = New SqlCommand(sel, con)
            Dim Resultado As New IDComboBox
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idIdioma") Is DBNull.Value Or linea("Idioma") Is DBNull.Value Then
                    Else
                        Resultado = New IDComboBox(linea("Idioma"), linea("idIdioma"))
                    End If
                Next
            Else
                con.Close()
            End If
            Return Resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Portes() As Char
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Portes FROM DatosIniciales "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CChar(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TipoValorado() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoValorado FROM DatosIniciales left join TiposValorado On TiposValorado.idTipoValorado = DatosIniciales.idTipoValorado "
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


    Public Function SMTPServidor() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPServidor FROM DatosIniciales  "
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

    Public Function SMTPPuerto() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPPuerto FROM DatosIniciales  "
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

    Public Function SMTPUsuario() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPUsuario FROM DatosIniciales  "
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

    Public Function SMTPPassword() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPPassword FROM DatosIniciales  "
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

    Public Function SMTPAutenticado() As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPAutenticado FROM DatosIniciales  "
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

    Public Function SMTPSSL() As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SMTPSSL FROM DatosIniciales  "
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

    Public Function DiasAviso1() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DiasAviso1 FROM DatosIniciales "
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


    Public Function DiasAviso2() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DiasAviso2 FROM DatosIniciales "
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

    Public Function DiasAviso3() As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT DiasAviso3 FROM DatosIniciales "
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



    Public Function SetProntoPago(ByVal Prontopago As Double) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update DatosIniciales set ProntoPago = @ProntoPago "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("ProntoPago", Prontopago)
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

    Public Function SetDescuento(ByVal Descuento As Double) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update DatosIniciales set Descuento = @Descuento "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Descuento", Descuento)
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

    Public Function SetDescuento2(ByVal Descuento2 As Double) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update DatosIniciales set Descuento2 = @Descuento2 "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Descuento2", Descuento2)
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

  
    Public Function Mostrar() As DatosDatosIniciales
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dts As New DatosDatosIniciales
            Dim sel As String
            sel = "SELECT DI.*, TipoIVA, TiposIVA.Nombre as NombreIVA,TipoRetencion, TiposRetencion.Nombre as NombreRetencion, Idioma, codArticulo, TipoValorado FROM DatosIniciales as DI left Join TiposIVA ON TiposIVA.idTipoIVA = DI.idTipoIVA left Join TiposRetencion ON TiposRetencion.idTipoRetencion = DI.idTipoRetencion "
            sel = sel & " left join Idiomas ON Idiomas.idIdioma = DI.idIdioma left join Articulos ON Articulos.idArticulo = DI.idArticuloOpcionBase "
            sel = sel & " left join TiposValorado ON TiposValorado.idTipoValorado = DI.idTipoValorado "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
                    dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                    dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
                    dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
                    dts.gPortes = If(linea("Portes") Is DBNull.Value, "", linea("Portes"))
                    dts.gidIdioma = If(linea("idIdioma") Is DBNull.Value, 0, linea("idIdioma"))
                    dts.gidArticuloOpcionBase = If(linea("idArticuloOpcionBase") Is DBNull.Value, 0, linea("idArticuloOpcionBase"))
                    dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))
                    dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))
                    dts.gSMTPServidor = If(linea("SMTPServidor") Is DBNull.Value, "", linea("SMTPServidor"))
                    dts.gSMTPPuerto = If(linea("SMTPPuerto") Is DBNull.Value, 0, linea("SMTPPuerto"))
                    dts.gSMTPUsuario = If(linea("SMTPUsuario") Is DBNull.Value, "", linea("SMTPUsuario"))
                    dts.gSMTPPassword = If(linea("SMTPPassword") Is DBNull.Value, "", linea("SMTPPassword"))
                    dts.gSMTPAutenticado = If(linea("SMTPAutenticado") Is DBNull.Value, False, linea("SMTPAutenticado"))
                    dts.gSMTPSSL = If(linea("SMTPSSL") Is DBNull.Value, False, linea("SMTPSSL"))
                    dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                    dts.gNombreIVA = If(linea("NombreIVA") Is DBNull.Value, "", linea("NombreIVA"))
                    dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
                    dts.gNombreRetencion = If(linea("NombreRetencion") Is DBNull.Value, "", linea("NombreRetencion"))
                    dts.gIdioma = If(linea("Idioma") Is DBNull.Value, "", linea("Idioma"))
                    dts.gArticuloOpcionBase = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                    dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
                    dts.gDiasAviso1 = If(linea("DiasAviso1") Is DBNull.Value, 0, linea("DiasAviso1"))
                    dts.gDiasAviso2 = If(linea("DiasAviso2") Is DBNull.Value, 0, linea("DiasAviso2"))
                    dts.gDiasAviso3 = If(linea("DiasAviso3") Is DBNull.Value, 0, linea("DiasAviso3"))

                    dts.gNombreIVA = dts.gNombreIVA & " " & dts.gTipoIVA & "%"
                    dts.gNombreRetencion = dts.gNombreRetencion & " " & dts.gTipoRetencion & "%"

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


    Public Function actualizar(ByVal dts As DatosDatosIniciales) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update DatosIniciales set ProntoPago = @ProntoPago, Descuento = @Descuento, Descuento2 = @Descuento2, idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, "
        sel = sel & " Portes = @Portes, idIdioma = @idIdioma, idArticuloOpcionBase = @idArticuloOpcionBase, idTipoValorado = @idTipoValorado, "
        sel = sel & " SMTPServidor = @SMTPServidor, SMTPPuerto = @SMTPPuerto, SMTPUsuario = @SMTPUsuario, SMTPPassword = @SMTPPassword, SMTPAutenticado = @SMTPAutenticado, SMTPSSL = @SMTPSSL, "
        sel = sel & " DiasAviso1 = @DiasAviso1, DiasAviso2 = @DiasAviso2, DiasAviso3 = @DiasAviso3 "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("idIdioma", dts.gidIdioma)
                cmd.Parameters.AddWithValue("idArticuloOpcionBase", dts.gidArticuloOpcionBase)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("SMTPServidor", dts.gSMTPServidor)
                cmd.Parameters.AddWithValue("SMTPPuerto", dts.gSMTPPuerto)
                cmd.Parameters.AddWithValue("SMTPUsuario", dts.gSMTPUsuario)
                cmd.Parameters.AddWithValue("SMTPPassword", dts.gSMTPPassword)
                cmd.Parameters.AddWithValue("SMTPAutenticado", dts.gSMTPAutenticado)
                cmd.Parameters.AddWithValue("SMTPSSL", dts.gSMTPSSL)
                cmd.Parameters.AddWithValue("DiasAviso1", dts.gDiasAviso1)
                cmd.Parameters.AddWithValue("DiasAviso2", dts.gDiasAviso2)
                cmd.Parameters.AddWithValue("DiasAviso3", dts.gDiasAviso3)
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


    





End Class



