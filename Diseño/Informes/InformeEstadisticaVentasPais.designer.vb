<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeEstadisticaVentasPaises
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeEstadisticaVentasPaises))
        Me.CRVESTADISTICAPAIS = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CRVESTADISTICAPAIS
        '
        Me.CRVESTADISTICAPAIS.ActiveViewIndex = -1
        Me.CRVESTADISTICAPAIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CRVESTADISTICAPAIS.DisplayGroupTree = False
        Me.CRVESTADISTICAPAIS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVESTADISTICAPAIS.Location = New System.Drawing.Point(0, 0)
        Me.CRVESTADISTICAPAIS.Name = "CRVESTADISTICAPAIS"
        Me.CRVESTADISTICAPAIS.SelectionFormula = ""
        Me.CRVESTADISTICAPAIS.ShowGroupTreeButton = False
        Me.CRVESTADISTICAPAIS.Size = New System.Drawing.Size(1196, 849)
        Me.CRVESTADISTICAPAIS.TabIndex = 0
        Me.CRVESTADISTICAPAIS.ViewTimeSelectionFormula = ""
        '
        'InformeEstadisticaVentasPais
        '
        Me.ClientSize = New System.Drawing.Size(1196, 849)
        Me.Controls.Add(Me.CRVESTADISTICAPAIS)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InformeEstadisticaVentasPais"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADISTICA DE VENTAS POR PAISES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVESTADISTICAPAIS As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
