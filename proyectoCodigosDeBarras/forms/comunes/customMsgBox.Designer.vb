<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class customMsgBox
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
        Me.lbTexto = New System.Windows.Forms.Label()
        Me.bVistaSimple = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbTexto
        '
        Me.lbTexto.AutoSize = True
        Me.lbTexto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTexto.Location = New System.Drawing.Point(10, 31)
        Me.lbTexto.Name = "lbTexto"
        Me.lbTexto.Size = New System.Drawing.Size(532, 19)
        Me.lbTexto.TabIndex = 0
        Me.lbTexto.Text = "¿Desea imprimir la etiqueta del equipo con número de serie 00000?"
        '
        'bVistaSimple
        '
        Me.bVistaSimple.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bVistaSimple.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVistaSimple.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVistaSimple.Location = New System.Drawing.Point(131, 90)
        Me.bVistaSimple.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bVistaSimple.Name = "bVistaSimple"
        Me.bVistaSimple.Size = New System.Drawing.Size(150, 71)
        Me.bVistaSimple.TabIndex = 6
        Me.bVistaSimple.Text = "Sí"
        Me.bVistaSimple.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(287, 91)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 70)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "No"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'customMsgBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 194)
        Me.Controls.Add(Me.bVistaSimple)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.lbTexto)
        Me.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "customMsgBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR ETIQUETA DE EQUIPO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbTexto As Label
    Friend WithEvents bVistaSimple As Button
    Friend WithEvents bSalir As Button
End Class
