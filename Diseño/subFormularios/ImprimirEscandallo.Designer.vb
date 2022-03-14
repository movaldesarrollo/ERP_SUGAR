<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirEscandallos
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
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.ckCoste = New System.Windows.Forms.CheckBox
        Me.ckPaginado = New System.Windows.Forms.CheckBox
        Me.ckTiempos = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(132, 16)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 10
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(232, 16)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 50)
        Me.bCancelar.TabIndex = 10
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'ckCoste
        '
        Me.ckCoste.AutoSize = True
        Me.ckCoste.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCoste.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCoste.Location = New System.Drawing.Point(12, 17)
        Me.ckCoste.Name = "ckCoste"
        Me.ckCoste.Size = New System.Drawing.Size(67, 21)
        Me.ckCoste.TabIndex = 11
        Me.ckCoste.Text = "COSTE"
        Me.ckCoste.UseVisualStyleBackColor = True
        '
        'ckPaginado
        '
        Me.ckPaginado.AutoSize = True
        Me.ckPaginado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPaginado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPaginado.Location = New System.Drawing.Point(12, 44)
        Me.ckPaginado.Name = "ckPaginado"
        Me.ckPaginado.Size = New System.Drawing.Size(98, 21)
        Me.ckPaginado.TabIndex = 11
        Me.ckPaginado.Text = "PAGINADO"
        Me.ckPaginado.UseVisualStyleBackColor = True
        '
        'ckTiempos
        '
        Me.ckTiempos.AutoSize = True
        Me.ckTiempos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTiempos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckTiempos.Location = New System.Drawing.Point(12, 71)
        Me.ckTiempos.Name = "ckTiempos"
        Me.ckTiempos.Size = New System.Drawing.Size(78, 21)
        Me.ckTiempos.TabIndex = 11
        Me.ckTiempos.Text = "TIEMPOS"
        Me.ckTiempos.UseVisualStyleBackColor = True
        '
        'ImprimirEscandallos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 99)
        Me.Controls.Add(Me.ckTiempos)
        Me.Controls.Add(Me.ckPaginado)
        Me.Controls.Add(Me.ckCoste)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bImprimir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImprimirEscandallos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "IMPRIMIR ESCANDALLOS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents ckCoste As System.Windows.Forms.CheckBox
    Friend WithEvents ckPaginado As System.Windows.Forms.CheckBox
    Friend WithEvents ckTiempos As System.Windows.Forms.CheckBox
End Class
