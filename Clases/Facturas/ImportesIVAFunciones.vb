Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesImportesIVA

    Inherits conexion
    Dim cmd As SqlCommand



  

    Private Function CargarLinea(ByVal linea As DataRow) As DatosImportesIVA
        Dim dts As New DatosImportesIVA
        dts.gidConcepto = linea("idConcepto")
        dts.gREPoSOP = If(linea("REPoSOP") Is DBNull.Value, "", linea("REPoSOP"))
        dts.gidFactura = If(linea("idFactura") Is DBNull.Value, 0, linea("idFactura"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gTipo = If(linea("Tipo") Is DBNull.Value, 0, linea("Tipo"))
        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dts.gCuota = If(linea("Cuota") Is DBNull.Value, 0, linea("Cuota"))
        dts.gIVAoRE = If(linea("IVAoRE") Is DBNull.Value, "IVA", linea("IVAoRE"))
        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, "", linea("numFactura"))
        dts.gNombreIVA = If(linea("NombreIVA") Is DBNull.Value, "", linea("NombreIVA"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "", linea("codMoneda"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "", linea("Simbolo"))

     
        Return dts
    End Function

    Public Function mostrar(ByVal iidConcepto As Integer) As DatosImportesIVA
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "Select * from ImportesIVATemp  where CP.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosImportesIVA
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
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



    Public Function insertar(ByRef dts As DatosImportesIVA) As Integer 'me devuelve el idConcepto generado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Dim resultado As Integer
        sel = "insert into ImportesIVATemp (idConcepto, REPoSOP, idFactura, idTipoIVA, Tipo,Base, Cuota, IVAoRE, numFactura, NombreIVA, codMoneda, simbolo ) "
        sel = sel & "values ( @idConcepto, @REPoSOP, @idFactura, @idTipoIVA, @Tipo,@Base, @Cuota, @IVAoRE, @numFactura, @NombreIVA, @codMoneda, @simbolo ) "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("REPoSOP", dts.gREPoSOP)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Tipo", dts.gTipo)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("Cuota", dts.gCuota)
                cmd.Parameters.AddWithValue("IVAoRE", dts.gIVAoRE)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("NombreIVA", dts.gNombreIVA)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("simbolo", dts.gSimbolo)
                con.Open()
                resultado = cmd.ExecuteScalar()
                con.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

 


    Public Function SiguienteidConcepto() As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select max(idConcepto) from ImportesIVATemp "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                Dim o As Object
                con.Open()
                o = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 1
                Else
                    Return CInt(o) + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

 

   




    Public Function borrar(ByVal iidConcepto As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ImportesIVATemp where idConcepto = " & iidConcepto

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


End Class
