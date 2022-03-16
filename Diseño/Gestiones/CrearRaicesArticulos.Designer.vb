<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrearRaicesArticulos
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
        Me.bAñadir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txRaiz = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'bAñadir
        '
        Me.bAñadir.Location = New System.Drawing.Point(147, 12)
        Me.bAñadir.Name = "bAñadir"
        Me.bAñadir.Size = New System.Drawing.Size(85, 50)
        Me.bAñadir.TabIndex = 1
        Me.bAñadir.Text = "AÑADIR"
        Me.bAñadir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NOMBRE DE RAIZ"
        '
        'txRaiz
        '
        Me.txRaiz.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txRaiz.Location = New System.Drawing.Point(12, 39)
        Me.txRaiz.Name = "txRaiz"
        Me.txRaiz.Size = New System.Drawing.Size(123, 20)
        Me.txRaiz.TabIndex = 0
        '
        'CrearRaicesArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 80)
        Me.Controls.Add(Me.txRaiz)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bAñadir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CrearRaicesArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AÑADIR RAIZ DE ARTICULO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bAñadir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txRaiz As System.Windows.Forms.TextBox
End Class
