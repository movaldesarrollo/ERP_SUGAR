<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subElegirEtiqueta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subElegirEtiqueta))
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.cbEtiquetas = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(324, 21)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(105, 50)
        Me.bGuardar.TabIndex = 1
        Me.bGuardar.Text = "SELECCIONAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(443, 21)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(105, 50)
        Me.bCancelar.TabIndex = 2
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'cbEtiquetas
        '
        Me.cbEtiquetas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEtiquetas.FormattingEnabled = True
        Me.cbEtiquetas.Location = New System.Drawing.Point(12, 33)
        Me.cbEtiquetas.Name = "cbEtiquetas"
        Me.cbEtiquetas.Size = New System.Drawing.Size(298, 25)
        Me.cbEtiquetas.TabIndex = 0
        '
        'subElegirEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 96)
        Me.Controls.Add(Me.cbEtiquetas)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subElegirEtiqueta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECCIONAR MODELO PARA LA NUEVA ETIQUETA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents cbEtiquetas As System.Windows.Forms.ComboBox
End Class
