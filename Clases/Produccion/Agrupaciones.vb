Public Class Agrupaciones

    Private funcEQ As New FuncionesEquiposProduccion
    Private funcAG As New FuncionesAgrupacionesArticulo
    Private funcCR As New FuncionesConceptosProduccion
    Private dt As DataTable
    Private indiceAgrupacionOtros As Integer = -1

    Public Function Mostrar(ByVal listaClientes As List(Of ClienteSeleccion)) As DataTable
        dt = funcAG.Mostrardt(0)
        Call ObtenerIndiceAgrupacionOtros()
        Call TotalesAgrupaciones(listaClientes)
        Return dt
    End Function

    Private Sub TotalesAgrupaciones(ByVal listaClientes As List(Of ClienteSeleccion))
        Try
            'Dim listaEquipos As List(Of DatosEquipoProduccion) = funcEQ.Mostrar("TODAS")
            Dim lista As List(Of IDComboBox3) = funcEQ.ListaidArticuloAgrupacion(listaClientes)

            'For Each dts As DatosEquipoProduccion In listaEquipos
            For Each dts As IDComboBox3 In lista
                If dts.Name1 = "" Then
                    dts.Name1 = funcAG.AgrupacionidsubTipo(funcCR.idsubTipoArticulo(dts.ItemData))
                End If
                Dim indice As Integer = lineaEn(dts.Name1)
                If indice = -1 Then
                    dt.Rows(indiceAgrupacionOtros).Item("Cantidad") = dt.Rows(indiceAgrupacionOtros).Item("Cantidad") + CInt(dts.Name2)
                Else
                    dt.Rows(indice).Item("Cantidad") = dt.Rows(indice).Item("Cantidad") + CInt(dts.Name2)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TotalesAgrupacioneskk()
        Try
            Dim listaEquipos As List(Of DatosEquipoProduccion) = funcEQ.Mostrar("TODAS")


            For Each dts As DatosEquipoProduccion In listaEquipos

                Dim indice As Integer = lineaEn(dts.gAgrupacion)
                If indice = -1 Then
                    dt.Rows(indiceAgrupacionOtros).Item("Cantidad") = dt.Rows(indiceAgrupacionOtros).Item("Cantidad") + 1
                Else
                    dt.Rows(indice).Item("Cantidad") = dt.Rows(indice).Item("Cantidad") + 1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function lineaEn(ByVal sAgrupacion As String) As Integer
        Dim i As Integer = 0
        For Each linea As DataRow In dt.Rows
            If linea("Agrupacion") = sAgrupacion Then Return i
            i = i + 1
        Next
        Return -1
    End Function

    Private Sub ObtenerIndiceAgrupacionOtros()
        Dim i As Integer = 0
        indiceAgrupacionOtros = -1
        For Each linea As DataRow In dt.Rows
            If Not linea("Otros") Is DBNull.Value AndAlso linea("Otros") = True Then indiceAgrupacionOtros = i
            i = i + 1
        Next
    End Sub


End Class
