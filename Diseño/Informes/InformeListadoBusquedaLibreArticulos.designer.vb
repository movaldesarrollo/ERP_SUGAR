<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeListadoBusquedaLibreArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CRVListadoBusquedaLibre = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVListadoBusquedaLibre
        '
        Me.CRVListadoBusquedaLibre.ActiveViewIndex = -1
        Me.CRVListadoBusquedaLibre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CRVListadoBusquedaLibre.DisplayGroupTree = False
        Me.CRVListadoBusquedaLibre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVListadoBusquedaLibre.Location = New System.Drawing.Point(0, 0)
        Me.CRVListadoBusquedaLibre.Name = "CRVListadoBusquedaLibre"
        Me.CRVListadoBusquedaLibre.SelectionFormula = ""
        Me.CRVListadoBusquedaLibre.ShowRefreshButton = False
        Me.CRVListadoBusquedaLibre.Size = New System.Drawing.Size(1020, 778)
        Me.CRVListadoBusquedaLibre.TabIndex = 0
        Me.CRVListadoBusquedaLibre.ViewTimeSelectionFormula = ""
        '
        'InformeListadoBusquedaLibreArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 778)
        Me.Controls.Add(Me.CRVListadoBusquedaLibre)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformeListadoBusquedaLibreArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LSTADO DE ARTÍCULOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVListadoBusquedaLibre As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
