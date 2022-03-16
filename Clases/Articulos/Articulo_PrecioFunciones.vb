Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class FuncionesArticuloPrecio
    Inherits conexion
    Dim cmd As SqlCommand
    Public Function Mostrar(ByVal iidArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosArticuloPrecio) 'Devuelve los datos de una ArticuloPrecio como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT AP.*, Simbolo FROM Articulos_Precios as AP left join Monedas ON Monedas.codMoneda = AP.codMoneda "
            sel = sel & " WHERE idArticulo = " & iidArticulo & If(SoloActivos, " AND Activo = 1 ", "")
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosArticuloPrecio)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosArticuloPrecio
                For Each linea In dt.Rows
                    If linea("idArticuloPrecio") Is DBNull.Value Then
                    Else
                        dts = New DatosArticuloPrecio
                        dts.gidArticuloPrecio = linea("idArticuloPrecio")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gTipoPrecio = If(linea("TipoPrecio") Is DBNull.Value, "V", linea("TipoPrecio"))
                        dts.gFechaPrecio = If(linea("FechaPrecio") Is DBNull.Value, Now.Date, linea("FechaPrecio"))
                        dts.gidProveedorPrecio = If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConcepto = If(linea("idConcepto") Is DBNull.Value, 0, linea("idConcepto"))
                        dts.gidClientePrecio = If(linea("idClientePrecio") Is DBNull.Value, 0, linea("idClientePrecio"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
                        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
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

    Public Function Precio(ByVal iidArticulo As Integer, ByVal TipoPrecio As Char) As DatosArticuloPrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT Top 1 AP.*, Simbolo FROM Articulos_Precios as AP left join Monedas ON Monedas.codMoneda = AP.codMoneda "
            sel = sel & " WHERE Activo = 1 AND idArticulo = " & iidArticulo & " AND TipoPrecio = '" & TipoPrecio & "' Order by VersionEscandallo DESC "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosArticuloPrecio
            dts.gcodMoneda = "EU"
            dts.gSimbolo = "€"
            dts.gFechaPrecio = Now.Date
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArticuloPrecio = linea("idArticuloPrecio")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gTipoPrecio = If(linea("TipoPrecio") Is DBNull.Value, "V", linea("TipoPrecio"))
                        dts.gFechaPrecio = If(linea("FechaPrecio") Is DBNull.Value, Now.Date, linea("FechaPrecio"))
                        dts.gidProveedorPrecio = If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConcepto = If(linea("idConcepto") Is DBNull.Value, 0, linea("idConcepto"))
                        dts.gidClientePrecio = If(linea("idClientePrecio") Is DBNull.Value, 0, linea("idClientePrecio"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
                        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
                        If dts.gcodMoneda = "" Then
                            dts.gcodMoneda = "EU"
                            dts.gSimbolo = "€"
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

    'Comprueba si el precio de la Opcion es = 0
    Public Function Precio0(ByVal iidArticulo As Integer, ByVal TipoPrecio As Char) As Boolean

        Try
            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT Top 1 AP.Precio FROM Articulos_Precios as AP left join Monedas ON Monedas.codMoneda = AP.codMoneda "

            sel = sel & " WHERE Activo = 1 AND idArticulo = " & iidArticulo & " AND TipoPrecio = '" & TipoPrecio & "' Order by VersionEscandallo DESC "

            cmd = New SqlCommand(sel, con)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("Precio") Is DBNull.Value Or linea("Precio") = 0 Then

                        Return False

                    Else

                        Return True


                    End If

                Next

            Else

                Return False

                con.Close()

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    Public Function Precio(ByVal iidArticulo As Integer, ByVal TipoPrecio As Char, ByVal Version As Integer) As DatosArticuloPrecio
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT Top 1 AP.*, Simbolo FROM Articulos_Precios as AP left join Monedas ON Monedas.codMoneda = AP.codMoneda "
            sel = sel & " WHERE Activo = 1 AND idArticulo = " & iidArticulo & " AND TipoPrecio = '" & TipoPrecio & "' " & " AND VersionEscandallo = " & Version & " Order by VersionEscandallo DESC "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosArticuloPrecio
            dts.gcodMoneda = "EU"
            dts.gSimbolo = "€"
            dts.gFechaPrecio = Now.Date
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloPrecio") Is DBNull.Value Then
                    Else
                        dts.gidArticuloPrecio = linea("idArticuloPrecio")
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gTipoPrecio = If(linea("TipoPrecio") Is DBNull.Value, "V", linea("TipoPrecio"))
                        dts.gFechaPrecio = If(linea("FechaPrecio") Is DBNull.Value, Now.Date, linea("FechaPrecio"))
                        dts.gidProveedorPrecio = If(linea("idProveedorPrecio") Is DBNull.Value, 0, linea("idProveedorPrecio"))
                        dts.gidConcepto = If(linea("idConcepto") Is DBNull.Value, 0, linea("idConcepto"))
                        dts.gidClientePrecio = If(linea("idClientePrecio") Is DBNull.Value, 0, linea("idClientePrecio"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, dts.gcodMoneda, linea("simbolo"))
                        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
                        If dts.gcodMoneda = "" Then
                            dts.gcodMoneda = "EU"
                            dts.gSimbolo = "€"
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

    Public Function insertar(ByVal dts As DatosArticuloPrecio) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Articulos_Precios ( idArticulo, Precio, codMoneda, TipoPrecio, FechaPrecio, idProveedorPrecio, idConcepto, idClientePrecio, Descuento, Activo,VersionEscandallo, idCreador, Creacion) "
        sel = sel & " values ( @idArticulo, @Precio, @codMoneda, @TipoPrecio, @FechaPrecio, @idProveedorPrecio, @idConcepto, @idClientePrecio, @Descuento, @Activo,@VersionEscandallo, @idCreador, @Creacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'cmd.Parameters.AddWithValue("idArticuloPrecio", dts.gidArticuloPrecio)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("TipoPrecio", dts.gTipoPrecio)
                cmd.Parameters.AddWithValue("FechaPrecio", dts.gFechaPrecio)
                cmd.Parameters.AddWithValue("idProveedorPrecio", dts.gidProveedorPrecio)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idClientePrecio", dts.gidClientePrecio)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
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

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
          
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosArticuloPrecio) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos_Precios set  idArticulo = @idArticulo,  = @Precio, codMoneda = @codMoneda, TipoPrecio = @TipoPrecio, FechaPrecio = @FechaPrecio, "
        sel = sel & "idProveedorPrecio = @idProveedorPrecio, idConcepto = @idConcepto, idClientePrecio = @idClientePrecio, Descuento = @Descuento, Activo = @Activo, VersionEscandallo = @VersionEscandallo, idModifica = @idModifica, Modificacion = @Modificacion  WHERE idArticuloPrecio = " & dts.gidArticuloPrecio

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idArticuloPrecio", dts.gidArticuloPrecio)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("TipoPrecio", dts.gTipoPrecio)
                cmd.Parameters.AddWithValue("FechaPrecio", dts.gFechaPrecio)
                cmd.Parameters.AddWithValue("idProveedorPrecio", dts.gidProveedorPrecio)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idClientePrecio", dts.gidClientePrecio)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
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

    Public Function Inactiva(ByVal iidArticuloPrecio As Long) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        If iidArticuloPrecio = 0 Then Return False
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "update Articulos_Precios set  Activo = 0, idModifica = @idModifica, Modificacion = @Modificacion  WHERE idArticuloPrecio = " & iidArticuloPrecio
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
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

    Public Function ActualizarH(ByVal dts As DatosArticuloPrecio) As Boolean
        'Actualizar o añade histórico si hay cambio
        Dim dtsP As DatosArticuloPrecio
        If dts.gVersion > 0 Then
            dtsP = Precio(dts.gidArticulo, dts.gTipoPrecio, dts.gVersion)
        Else
            dtsP = Precio(dts.gidArticulo, dts.gTipoPrecio)
        End If
        If Math.Abs(dtsP.gPrecio - dts.gPrecio) > 0.0000009 Or dtsP.gcodMoneda <> dts.gcodMoneda Then
            Call Inactiva(dtsP.gidArticuloPrecio)
            Call insertar(dts)
        End If
    End Function

    Public Function borrar(ByVal iidArticuloPrecio As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Articulos_Precios where idArticuloPrecio = " & iidArticuloPrecio
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
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

    Public Function borrarArticulo(ByVal iidArticulo As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Articulos_Precios where idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
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
End Class



