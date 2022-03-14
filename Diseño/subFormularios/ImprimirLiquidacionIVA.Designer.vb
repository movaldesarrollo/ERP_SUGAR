<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirLiquidacionIVA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirLiquidacionIVA))
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.ckRepercutido = New System.Windows.Forms.CheckBox
        Me.ckSoportado = New System.Windows.Forms.CheckBox
        Me.ckLiquidacion = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(146, 22)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 3
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(246, 22)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 50)
        Me.bCancelar.TabIndex = 4
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'ckRepercutido
        '
        Me.ckRepercutido.AutoSize = True
        Me.ckRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRepercutido.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRepercutido.Location = New System.Drawing.Point(13, 66)
        Me.ckRepercutido.Name = "ckRepercutido"
        Me.ckRepercutido.Size = New System.Drawing.Size(113, 21)
        Me.ckRepercutido.TabIndex = 2
        Me.ckRepercutido.Text = "REPERCUTIDO"
        Me.ckRepercutido.UseVisualStyleBackColor = True
        '
        'ckSoportado
        '
        Me.ckSoportado.AutoSize = True
        Me.ckSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSoportado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSoportado.Location = New System.Drawing.Point(13, 39)
        Me.ckSoportado.Name = "ckSoportado"
        Me.ckSoportado.Size = New System.Drawing.Size(106, 21)
        Me.ckSoportado.TabIndex = 1
        Me.ckSoportado.Text = "SOPORTADO"
        Me.ckSoportado.UseVisualStyleBackColor = True
        '
        'ckLiquidacion
        '
        Me.ckLiquidacion.AutoSize = True
        Me.ckLiquidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLiquidacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckLiquidacion.Location = New System.Drawing.Point(13, 12)
        Me.ckLiquidacion.Name = "ckLiquidacion"
        Me.ckLiquidacion.Size = New System.Drawing.Size(112, 21)
        Me.ckLiquidacion.TabIndex = 0
        Me.ckLiquidacion.Text = "LIQUIDACIÓN"
        Me.ckLiquidacion.UseVisualStyleBackColor = True
        '
        'ImprimirLiquidacionIVA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 99)
        Me.Controls.Add(Me.ckLiquidacion)
        Me.Controls.Add(Me.ckSoportado)
        Me.Controls.Add(Me.ckRepercutido)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImprimirLiquidacionIVA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IMPRIMIR LIQUIDACIÓN IVA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents ckRepercutido As System.Windows.Forms.CheckBox
    Friend WithEvents ckSoportado As System.Windows.Forms.CheckBox
    Friend WithEvents ckLiquidacion As System.Windows.Forms.CheckBox
End Class
