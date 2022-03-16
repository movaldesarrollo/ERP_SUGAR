Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesParametrosServir

    Inherits conexion
    Dim cmd As SqlCommand

   

    Public Function Mostrar(ByVal inumPedido As Integer) As DatosParametrosServir
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select Top 1 * from ParametrosServir where numpedido = " & inumPedido
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosParametrosServir
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        dts.gnumPedido = linea("NumPedido")
                        dts.gBultos = If(linea("Bultos") Is DBNull.Value, 0, linea("Bultos"))
                        dts.gKilosBrutos = If(linea("KilosBrutos") Is DBNull.Value, 0, linea("KilosBrutos"))
                        dts.gKilosNetos = If(linea("KilosNetos") Is DBNull.Value, 0, linea("KilosNetos"))
                        dts.gVolumen = If(linea("Volumen") Is DBNull.Value, 0, linea("Volumen"))
                        dts.gMedidas = If(linea("Medidas") Is DBNull.Value, "", linea("Medidas"))
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






    Public Function insertar(ByVal dts As DatosParametrosServir) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ParametrosServir (numPedido, Bultos, KilosBrutos, KilosNetos, Volumen, medidas ) "
        sel = sel & " values (@numPedido, @Bultos,@KilosBrutos,@KilosNetos,@Volumen,@medidas )"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                cmd.Parameters.AddWithValue("Medidas", dts.gMedidas)
                con.Open()
                Dim resultado As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return resultado > 0
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosParametrosServir) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ParametrosServir set numPedido = @numPedido, Bultos = @Bultos, KilosBrutos = @KilosBrutos, KilosNetos = @KilosNetos, Volumen =@Volumen, medidas = @medidas  "
        sel = sel & " WHERE numAlbaran = @numAlbaran"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
                cmd.Parameters.AddWithValue("KilosBrutos", dts.gKilosBrutos)
                cmd.Parameters.AddWithValue("KilosNetos", dts.gKilosNetos)
                cmd.Parameters.AddWithValue("Volumen", dts.gVolumen)
                cmd.Parameters.AddWithValue("Medidas", dts.gMedidas)
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



   


    Public Function borrar(ByVal inumPedido As Integer) As Boolean  ' Borra una cabecera de AlbaranProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ParametrosServir where numPedido = " & inumPedido
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                desconectado()
            End Try
        End Using

    End Function






End Class
