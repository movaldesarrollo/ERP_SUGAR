Imports System.Data.SqlClient

Public Class FuncionCambiarEquipos

#Region "VARIABLE"

    Inherits conexion

    Dim cmd As SqlCommand

    Dim da As SqlDataAdapter

    Dim con As New SqlConnection(CadenaConexion())

    Dim sel As String

#End Region

    Public Function BuscarConceptosPedido(ByVal numPedido As Integer, ByVal tipo As Boolean) As List(Of DatosCambiarEquipo)

        Dim lista As New List(Of DatosCambiarEquipo)

        Dim where As String = ""

        If tipo Then

            where = " and (eq.numSerie is not null and eq.numSerie <> 0)"

        Else

            where = " and (eq.numSerie is null or eq.numSerie = 0)"

        End If

        Try

            sel = "select cp.IdArticulo, cp.codArticuloCli, eq.numSerie
from EquiposProduccion EQ
left join  ConceptosProduccion CPR on CPR.idProduccion = EQ.idProduccion
left join ConceptosPedidos  CP on CP.idConcepto  = CPR.idConceptoPedido
where numPedido =  " & numPedido & where

            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While (reader.Read)

                Dim datos As New DatosCambiarEquipo

                datos.IdArticulo = reader("idArticulo").ToString

                datos.CodArticulo = reader("codArticuloCli").ToString

                datos.NumSerie = reader("numSerie").ToString

                lista.Add(datos)

            End While

            reader.Close()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            lista = Nothing

            con.Close()

        End Try

        Return lista

    End Function

    Public Function existsPedido(ByVal numPedido As Integer) As Boolean

        Dim exists As Boolean = False

        Try

            sel = "select count(*) from ConceptosPedidos where numPedido = " & numPedido

            cmd = New SqlCommand(sel, con)

            con.Open()

            Dim i As Integer = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                exists = True

            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            con.Close()

        End Try

        Return exists

    End Function


    Public Function getIdEquipo(ByVal idArticulo As Integer, ByVal numPedidoDestino As String) As Integer

        Dim idEquipo As Integer = 0

        Try

            sel = "select eq.idEquipo from ConceptosPedidos cp
left join ConceptosProduccion cpr on cpr.idConceptoPedido = cp.idConcepto
left join EquiposProduccion eq on eq.idProduccion = cpr.idProduccion
where numPedido = " & numPedidoDestino & " and cp.idArticulo = " & idArticulo & " and numSerie = 0 "

            cmd = New SqlCommand(sel, con)

            con.Open()

            idEquipo = cmd.ExecuteScalar

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            con.Close()

        End Try

        Return idEquipo

    End Function
    Public Function CambiarNumeroSerie(ByVal idEquipo As Integer, ByVal idArticulo As Integer, ByVal numPedidoDestino As String, ByVal numSerie As String, ByVal etiquetaImpresa As Boolean, ByVal EtiquetaFinalImpresa As Boolean) As Boolean

        Dim cambiado As Boolean = False

        Dim equiposSinNumeroSerie As Integer = 0

        Try

            sel = "Update EquiposProduccion set numSerie = 0, etiquetaImpresa =  0, EtiquetaFinalImpresa = 0, fechaPicking = null where numSerie = " & numSerie & " 
Update EquiposProduccion set numSerie = " & numSerie & ", fechaPicking = GETDATE(), Modificacion = GETDATE(), idModifica = @idModifica,
etiquetaImpresa = '" & etiquetaImpresa & "', EtiquetaFinalImpresa = '" & EtiquetaFinalImpresa & "' where idEquipo = " & idEquipo

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            cambiado = True

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical)

            con.Close()

        End Try

        Return cambiado

    End Function

End Class
