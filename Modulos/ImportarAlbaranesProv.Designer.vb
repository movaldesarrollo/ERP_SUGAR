<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarAlbaranesProv
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
        Me.bGuardar = New System.Windows.Forms.Button
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(556, 33)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(92, 50)
        Me.bGuardar.TabIndex = 30
        Me.bGuardar.Text = "IMPORTAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'Observaciones
        '
        Me.Observaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(12, 112)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(636, 118)
        Me.Observaciones.TabIndex = 31
        '
        'ImportarAlbaranesProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 262)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.Observaciones)
        Me.Name = "ImportarAlbaranesProv"
        Me.Text = "ImportarAlbaranesProv"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
End Class
