<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionConvertirP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionConvertirP))
        Me.bAlbaran = New System.Windows.Forms.Button
        Me.bProduccion = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'bAlbaran
        '
        Me.bAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAlbaran.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAlbaran.Location = New System.Drawing.Point(12, 12)
        Me.bAlbaran.Name = "bAlbaran"
        Me.bAlbaran.Size = New System.Drawing.Size(109, 50)
        Me.bAlbaran.TabIndex = 10
        Me.bAlbaran.Text = "ALBARÁN"
        Me.bAlbaran.UseVisualStyleBackColor = True
        '
        'bProduccion
        '
        Me.bProduccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bProduccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bProduccion.Location = New System.Drawing.Point(129, 12)
        Me.bProduccion.Name = "bProduccion"
        Me.bProduccion.Size = New System.Drawing.Size(109, 50)
        Me.bProduccion.TabIndex = 10
        Me.bProduccion.Text = "PRODUCCIÓN"
        Me.bProduccion.UseVisualStyleBackColor = True
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
        'SeleccionConvertirP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 75)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bProduccion)
        Me.Controls.Add(Me.bAlbaran)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SeleccionConvertirP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CONVERTIR PEDIDO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bAlbaran As System.Windows.Forms.Button
    Friend WithEvents bProduccion As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
End Class
