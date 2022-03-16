Public Class IvasFactura

    Dim funcII As New FuncionesImportesIVAProv
    Dim funcTI As New FuncionesTiposIVA
    Dim dt As DataTable

    Public TieneRecargoEquivalencia As Boolean

    Public Function Mostrar(ByVal iidFactura As Integer) As DataTable
        Try
            dt = MostrarVacio()
            Dim dtFactura As DataTable = funcII.MostrarDT(iidFactura)
            For Each lineaF As DataRow In dtFactura.Rows
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("idTipoIVA") = lineaF("idTipoIVA") Then
                        dt.Rows(i)("TipoIVA") = lineaF("TipoIVA")
                        dt.Rows(i)("Base") = lineaF("Base")
                        dt.Rows(i)("TotalIVA") = lineaF("TotalIVA")
                        dt.Rows(i)("TipoRecargoEq") = lineaF("TipoRecargoEq")
                        dt.Rows(i)("TotalRE") = lineaF("TotalRE")
                    End If
                Next
            Next
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TotalIVA() As Double
        If dt Is Nothing Then
            Return 0
        Else
            Dim Total As Double = 0
            For Each linea As DataRow In dt.Rows
                Total = Total + If(linea("TotalIVA") Is DBNull.Value, 0, linea("TotalIVA"))
            Next
        End If
    End Function

    Public Function TotalRE() As Double
        If dt Is Nothing Then
            Return 0
        Else
            Dim Total As Double = 0
            For Each linea As DataRow In dt.Rows
                Total = Total + If(linea("TotalRE") Is DBNull.Value, 0, linea("TotalRE"))
            Next
        End If
    End Function



    Public Function MostrarVacio() As DataTable
        dt = funcTI.Mostrardt(True)
        dt.Columns.Remove("Descripcion")
        dt.Columns.Remove("Activo")
        dt.Columns.Add("idConcepto")
        dt.Columns.Add("idFactura")
        dt.Columns.Add("Base")
        dt.Columns.Add("TotalIVA")
        dt.Columns.Add("TotalRE")
        dt.Columns.Add("RecargoEquivalencia", GetType(Boolean))
        For Each linea As DataRow In dt.Rows
            linea.Item("RecargoEquivalencia") = TieneRecargoEquivalencia
        Next
        Return dt
    End Function


    Public Function Actualizar(ByVal iidFactura As Integer, ByVal dt As DataTable)
        Dim dts As DatosImportesIVAProv
        funcII.borrarFactura(iidFactura)
        Dim resultado As Boolean = False
        For Each linea As DataRow In dt.Rows
            dts = CargarLinea(linea)
            resultado = resultado Or funcII.insertar(dts) > 0
        Next
        Return resultado
    End Function



    Private Function CargarLinea(ByVal Linea As DataRow) As DatosImportesIVAProv
        Dim dts As New DatosImportesIVAProv
        dts.gidConcepto = Linea("idConcepto")
        dts.gidFactura = If(Linea("idFactura") Is DBNull.Value, 0, Linea("idFactura"))
        dts.gidTipoIVA = If(Linea("idTipoIVA") Is DBNull.Value, 0, Linea("idTipoIVA"))
        dts.gTipoIVA = If(Linea("TipoIVA") Is DBNull.Value, 0, Linea("TipoIVA"))
        dts.gTipoRecargoEq = If(Linea("TipoRecargoEq") Is DBNull.Value, 0, Linea("TipoRecargoEq"))
        dts.gBase = If(Linea("Base") Is DBNull.Value, 0, Linea("Base"))
        dts.gTotalIVA = If(Linea("TotalIVA") Is DBNull.Value, 0, Linea("TotalIVA"))
        If TieneRecargoEquivalencia Then
            dts.gTipoRecargoEq = If(Linea("TipoRecargoEq") Is DBNull.Value, 0, Linea("TipoRecargoEq"))
            dts.gTotalRE = If(Linea("TotalRE") Is DBNull.Value, 0, Linea("TotalRE"))
        Else
            dts.gTipoRecargoEq = 0
            dts.gTotalRE = 0
        End If
        dts.gnumFactura = If(Linea("numFactura") Is DBNull.Value, "", Linea("numFactura"))
        dts.gNombreIVA = If(Linea("Nombre") Is DBNull.Value, "", Linea("Nombre"))
        dts.gcodMoneda = If(Linea("codMoneda") Is DBNull.Value, "EU", Linea("codMoneda"))
        dts.gSimbolo = If(Linea("Simbolo") Is DBNull.Value, "€", Linea("Simbolo"))
        Return dts
    End Function


End Class
