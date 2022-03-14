<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeListadoFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeListadoFacturas))
        Me.CRVFacturas = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.bDetalle = New System.Windows.Forms.Button
        Me.bTotales = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CRVFacturas
        '
        Me.CRVFacturas.ActiveViewIndex = -1
        Me.CRVFacturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CRVFacturas.DisplayGroupTree = False
        Me.CRVFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVFacturas.Location = New System.Drawing.Point(0, 0)
        Me.CRVFacturas.Name = "CRVFacturas"
        Me.CRVFacturas.SelectionFormula = ""
        Me.CRVFacturas.ShowGroupTreeButton = False
        Me.CRVFacturas.ShowRefreshButton = False
        Me.CRVFacturas.Size = New System.Drawing.Size(1020, 778)
        Me.CRVFacturas.TabIndex = 0
        Me.CRVFacturas.ViewTimeSelectionFormula = ""
        '
        'bDetalle
        '
        Me.bDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bDetalle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDetalle.ForeColor = System.Drawing.Color.Red
        Me.bDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bDetalle.Location = New System.Drawing.Point(640, 12)
        Me.bDetalle.Name = "bDetalle"
        Me.bDetalle.Size = New System.Drawing.Size(88, 30)
        Me.bDetalle.TabIndex = 2
        Me.bDetalle.Text = "DETALLE"
        Me.bDetalle.UseVisualStyleBackColor = True
        '
        'bTotales
        '
        Me.bTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bTotales.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTotales.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTotales.Location = New System.Drawing.Point(734, 12)
        Me.bTotales.Name = "bTotales"
        Me.bTotales.Size = New System.Drawing.Size(88, 30)
        Me.bTotales.TabIndex = 5
        Me.bTotales.Text = "TOTALES"
        Me.bTotales.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(828, 12)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 30)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(922, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 30)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'InformeListadoFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 778)
        Me.Controls.Add(Me.bTotales)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bDetalle)
        Me.Controls.Add(Me.CRVFacturas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformeListadoFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LSTADO DE FACTURAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVFacturas As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bDetalle As System.Windows.Forms.Button
    Friend WithEvents bTotales As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
End Class
