<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionImprimirP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionImprimirP))
        Me.bInterno = New System.Windows.Forms.Button
        Me.bCliente = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'bInterno
        '
        Me.bInterno.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bInterno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bInterno.Location = New System.Drawing.Point(12, 12)
        Me.bInterno.Name = "bInterno"
        Me.bInterno.Size = New System.Drawing.Size(109, 50)
        Me.bInterno.TabIndex = 10
        Me.bInterno.Text = "INTERNO"
        Me.bInterno.UseVisualStyleBackColor = True
        '
        'bCliente
        '
        Me.bCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCliente.Location = New System.Drawing.Point(129, 12)
        Me.bCliente.Name = "bCliente"
        Me.bCliente.Size = New System.Drawing.Size(109, 50)
        Me.bCliente.TabIndex = 10
        Me.bCliente.Text = "CLIENTE"
        Me.bCliente.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(246, 12)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(109, 50)
        Me.bCancelar.TabIndex = 10
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'SeleccionImprimirP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 75)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bCliente)
        Me.Controls.Add(Me.bInterno)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SeleccionImprimirP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TIPO  DOCUMENTO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bInterno As System.Windows.Forms.Button
    Friend WithEvents bCliente As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
End Class
