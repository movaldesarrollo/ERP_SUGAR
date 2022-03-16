<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionConvertirR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionConvertirR))
        Me.bProforma = New System.Windows.Forms.Button
        Me.bPedido = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.bOferta = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'bProforma
        '
        Me.bProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bProforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bProforma.Location = New System.Drawing.Point(113, 12)
        Me.bProforma.Name = "bProforma"
        Me.bProforma.Size = New System.Drawing.Size(88, 50)
        Me.bProforma.TabIndex = 1
        Me.bProforma.Text = "PROFORMA"
        Me.bProforma.UseVisualStyleBackColor = True
        '
        'bPedido
        '
        Me.bPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPedido.Location = New System.Drawing.Point(214, 12)
        Me.bPedido.Name = "bPedido"
        Me.bPedido.Size = New System.Drawing.Size(88, 50)
        Me.bPedido.TabIndex = 2
        Me.bPedido.Text = "PEDIDO"
        Me.bPedido.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(315, 12)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 50)
        Me.bCancelar.TabIndex = 3
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'bOferta
        '
        Me.bOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bOferta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bOferta.Location = New System.Drawing.Point(12, 12)
        Me.bOferta.Name = "bOferta"
        Me.bOferta.Size = New System.Drawing.Size(88, 50)
        Me.bOferta.TabIndex = 0
        Me.bOferta.Text = "OFERTA"
        Me.bOferta.UseVisualStyleBackColor = True
        '
        'SeleccionConvertirR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 75)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bPedido)
        Me.Controls.Add(Me.bOferta)
        Me.Controls.Add(Me.bProforma)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SeleccionConvertirR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CONVERTIR REPARACIÓN"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bProforma As System.Windows.Forms.Button
    Friend WithEvents bPedido As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents bOferta As System.Windows.Forms.Button
End Class
