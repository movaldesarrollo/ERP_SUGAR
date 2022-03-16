<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mostrarNumeroSerie
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
        Me.txtNumerosSerie = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtNumerosSerie
        '
        Me.txtNumerosSerie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumerosSerie.Location = New System.Drawing.Point(12, 12)
        Me.txtNumerosSerie.Multiline = True
        Me.txtNumerosSerie.Name = "txtNumerosSerie"
        Me.txtNumerosSerie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNumerosSerie.Size = New System.Drawing.Size(696, 760)
        Me.txtNumerosSerie.TabIndex = 0
        '
        'mostrarNumeroSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 784)
        Me.Controls.Add(Me.txtNumerosSerie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "mostrarNumeroSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mostrarNumeroSerie"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNumerosSerie As TextBox
End Class
