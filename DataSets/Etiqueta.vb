

Partial Public Class Etiqueta
    Partial Class EtiquetaDataTable
        Private Sub EtiquetaDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.BarcodeReferenciaColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
