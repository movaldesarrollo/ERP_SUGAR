Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesEtiquetasImpresoras
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar1(ByVal iidEtiquetaImp As Integer) As DatosEtiquetaImpresora
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT *  FROM EtiquetasImpresoras  where idEtiquetaImp = " & iidEtiquetaImp
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEtiquetaImpresora
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New DatosEtiquetaImpresora
                    dts.gidEtiquetaImp = linea("idEtiquetaimp")
                    dts.gidEtiqueta = If(linea("idEtiqueta") Is DBNull.Value, 0, linea("idEtiqueta"))
                    dts.gImpresora = If(linea("Impresora") Is DBNull.Value, "", linea("Impresora"))
                    dts.gMargenIzq = If(linea("MargenIzq") Is DBNull.Value, 0, linea("MargenIzq"))
                    dts.gMargenDer = If(linea("MargenDer") Is DBNull.Value, 0, linea("MargenDer"))
                    dts.gMargenSup = If(linea("MargenSup") Is DBNull.Value, 0, linea("MargenSup"))
                    dts.gMargenInf = If(linea("MargenInf") Is DBNull.Value, 0, linea("MargenInf"))
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
  


    Public Function Mostrar1(ByVal iidEtiqueta As Integer, ByVal impresora As String) As DatosEtiquetaImpresora
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If impresora = "" Then
                sel = "SELECT Top 1 *  FROM EtiquetasImpresoras  where idEtiqueta = " & iidEtiqueta
            Else
                sel = "SELECT *  FROM EtiquetasImpresoras  where idEtiqueta = " & iidEtiqueta & " AND impresora = '" & Left(Trim(impresora), 50) & "' "
            End If

            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEtiquetaImpresora
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New DatosEtiquetaImpresora
                    dts.gidEtiquetaImp = linea("idEtiquetaimp")
                    dts.gidEtiqueta = If(linea("idEtiqueta") Is DBNull.Value, 0, linea("idEtiqueta"))
                    dts.gImpresora = If(linea("Impresora") Is DBNull.Value, "", linea("Impresora"))
                    dts.gMargenIzq = If(linea("MargenIzq") Is DBNull.Value, 0, linea("MargenIzq"))
                    dts.gMargenDer = If(linea("MargenDer") Is DBNull.Value, 0, linea("MargenDer"))
                    dts.gMargenSup = If(linea("MargenSup") Is DBNull.Value, 0, linea("MargenSup"))
                    dts.gMargenInf = If(linea("MargenInf") Is DBNull.Value, 0, linea("MargenInf"))
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



    Public Function insertar(ByVal dts As DatosEtiquetaImpresora) As Integer
        'Insertar una nuevo 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into EtiquetasImpresoras (idEtiqueta, Impresora, MargenIzq, MargenDer, MargenSup, MargenInf ) values (@idEtiqueta, @Impresora, @MargenIzq, @MargenDer, @MargenSup, @MargenInf) select @@identity"
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("Impresora", dts.gImpresora)
                cmd.Parameters.AddWithValue("MargenIzq", dts.gMargenIzq)
                cmd.Parameters.AddWithValue("MargenDer", dts.gMargenDer)
                cmd.Parameters.AddWithValue("MargenSup", dts.gMargenSup)
                cmd.Parameters.AddWithValue("MargenInf", dts.gMargenInf)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
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


    Public Function actualizar(ByVal dts As DatosEtiquetaImpresora) As Boolean   'Actualiza un registro de la
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update EtiquetasImpresoras set idEtiqueta = @idEtiqueta, Impresora = @Impresora, MargenIzq = @MargenIzq, MargenDer = @MargenDer, MargenSup =@MargenSup, MargenInf = @MargenInf  Where idEtiquetaImp = @idEtiquetaImp "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiquetaImp", dts.gidEtiquetaImp)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("Impresora", dts.gImpresora)
                cmd.Parameters.AddWithValue("MargenIzq", dts.gMargenIzq)
                cmd.Parameters.AddWithValue("MargenDer", dts.gMargenDer)
                cmd.Parameters.AddWithValue("MargenSup", dts.gMargenSup)
                cmd.Parameters.AddWithValue("MargenInf", dts.gMargenInf)
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


    Public Function borrar(ByVal iidEtiqueta As Integer, ByVal impresora As String) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EtiquetasImpresoras where idEtiqueta = " & iidEtiqueta & " AND impresora = '" & Left(Trim(impresora), 50) & "' "
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


    Public Function borrar(ByVal iidEtiquetaImp As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EtiquetasImpresoras where idEtiquetaImp = " & iidEtiquetaImp
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



