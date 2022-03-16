Imports System.Data.SqlClient

Public Class funcionesArticulosAX

    Inherits conexion

    Dim con As New SqlConnection(CadenaConexion)

    Dim sel As String

    Dim cmd As New SqlCommand

    Dim da As New SqlDataAdapter

    Public Function cargarArticulosAX(ByVal form As GestionAriculosAX) As Boolean

        Try

            With form

                sel = "Select * from articulosAX as AX 
left join articulos as ART on ART.idArticuloAX = AX.idArticuloAX"

                Dim dt As New DataTable

                da = New SqlDataAdapter(sel, con)

                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    For Each rows In dt.Rows

                        With .lvArticulosAX.Items

                            With .Add(rows("idArticuloAx"))

                                .subItems.add(If(rows("idArticulo") Is DBNull.Value, 0, rows("idArticulo")))

                                .subItems.add(rows("nombre"))

                                .subItems.add(If(rows("codArticulo") Is DBNull.Value, "", rows("CodArticulo")))

                                .subItems.add(If(rows("descripcion") Is DBNull.Value, "", rows("descripcion")))

                            End With

                        End With

                    Next

                End If

            End With

            Return True

        Catch ex As Exception

            MsgBox("Error al cargar los artículos AX." & vbCrLf & ex.Message, MsgBoxStyle.Critical)

        End Try

        Return False

    End Function

End Class
