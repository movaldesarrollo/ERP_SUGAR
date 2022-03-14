<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeEscandalloMateriasPrimas
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
        Me.CRVEscandalloMP = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ckCostes = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'CRVEscandalloMP
        '
        Me.CRVEscandalloMP.ActiveViewIndex = -1
        Me.CRVEscandalloMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CRVEscandalloMP.DisplayGroupTree = False
        Me.CRVEscandalloMP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVEscandalloMP.Location = New System.Drawing.Point(0, 0)
        Me.CRVEscandalloMP.Name = "CRVEscandalloMP"
        Me.CRVEscandalloMP.SelectionFormula = ""
        Me.CRVEscandalloMP.ShowGroupTreeButton = False
        Me.CRVEscandalloMP.ShowRefreshButton = False
        Me.CRVEscandalloMP.Size = New System.Drawing.Size(1020, 778)
        Me.CRVEscandalloMP.TabIndex = 0
        Me.CRVEscandalloMP.ViewTimeSelectionFormula = ""
        '
        'ckCostes
        '
        Me.ckCostes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckCostes.AutoSize = True
        Me.ckCostes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCostes.Location = New System.Drawing.Point(845, 12)
        Me.ckCostes.Name = "ckCostes"
        Me.ckCostes.Size = New System.Drawing.Size(163, 20)
        Me.ckCostes.TabIndex = 1
        Me.ckCostes.Text = "OCULTAR COSTES"
        Me.ckCostes.UseVisualStyleBackColor = True
        '
        'InformeEscandalloMateriasPrimas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 778)
        Me.Controls.Add(Me.ckCostes)
        Me.Controls.Add(Me.CRVEscandalloMP)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformeEscandalloMateriasPrimas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISTADO MATERIAS PRIMAS DE ESCANDALLO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRVEscandalloMP As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ckCostes As System.Windows.Forms.CheckBox
End Class
