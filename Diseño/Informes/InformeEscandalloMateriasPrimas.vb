Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeEscandalloMateriasPrimas

    Dim dsMP As materiasPrimasEscandallos
    Public exportar As Boolean
    Public ruta As String
    Public idEscandallo As String
    Public tituloInforme As String
    Public ocultarCostes As Boolean

    Public Function verInforme(ByVal ds As materiasPrimasEscandallos) As Boolean

        Me.Text = tituloInforme

        dsMP = ds

        Dim informe As New EscandallosMateriasPrimas

        'Tomamos el usuario y la contraseña de la base de datos del la cadena de conexión de la aplicación
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetDatabaseLogon(csb.UserID, csb.Password)

        informe.SetDataSource(ds)
        informe.SetParameterValue("verCostes", If(ocultarCostes, True, False))
        informe.SetParameterValue("tituloInforme", tituloInforme)

        If exportar Then
            Try
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New  _
                DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New ExcelFormatOptions
                CrDiskFileDestinationOptions.DiskFileName = _
                                            ruta & "\" & idEscandallo & ".xls"
                CrExportOptions = informe.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.Excel
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With
                informe.Export()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            CRVEscandalloMP.ReportSource = informe
        End If

        Return True

    End Function

    Private Sub ckCostes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCostes.CheckedChanged

        ocultarCostes = ckCostes.Checked

        verInforme(dsMP)

    End Sub

End Class