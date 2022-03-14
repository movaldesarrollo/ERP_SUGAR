<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarReparaciones
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
        Me.datos = New System.Windows.Forms.TextBox
        Me.bImportarReparacionesCliente0 = New System.Windows.Forms.Button
        Me.bImportarEquipos = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(556, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(92, 80)
        Me.bGuardar.TabIndex = 28
        Me.bGuardar.Text = "IMPORTAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'Observaciones
        '
        Me.Observaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(12, 180)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(636, 263)
        Me.Observaciones.TabIndex = 29
        '
        'datos
        '
        Me.datos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datos.Location = New System.Drawing.Point(12, 98)
        Me.datos.MaxLength = 300
        Me.datos.Name = "datos"
        Me.datos.Size = New System.Drawing.Size(636, 23)
        Me.datos.TabIndex = 30
        '
        'bImportarReparacionesCliente0
        '
        Me.bImportarReparacionesCliente0.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImportarReparacionesCliente0.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImportarReparacionesCliente0.Location = New System.Drawing.Point(383, 12)
        Me.bImportarReparacionesCliente0.Name = "bImportarReparacionesCliente0"
        Me.bImportarReparacionesCliente0.Size = New System.Drawing.Size(128, 80)
        Me.bImportarReparacionesCliente0.TabIndex = 28
        Me.bImportarReparacionesCliente0.Text = "IMPORTAR REPARACIONES NO IDENTIFICADAS"
        Me.bImportarReparacionesCliente0.UseVisualStyleBackColor = True
        '
        'bImportarEquipos
        '
        Me.bImportarEquipos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImportarEquipos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImportarEquipos.Location = New System.Drawing.Point(207, 12)
        Me.bImportarEquipos.Name = "bImportarEquipos"
        Me.bImportarEquipos.Size = New System.Drawing.Size(128, 80)
        Me.bImportarEquipos.TabIndex = 28
        Me.bImportarEquipos.Text = "IMPORTAR EQUIPOS"
        Me.bImportarEquipos.UseVisualStyleBackColor = True
        '
        'ImportarReparaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 473)
        Me.Controls.Add(Me.datos)
        Me.Controls.Add(Me.bImportarEquipos)
        Me.Controls.Add(Me.bImportarReparacionesCliente0)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.Observaciones)
        Me.Name = "ImportarReparaciones"
        Me.Text = "ImportarReparaciones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents datos As System.Windows.Forms.TextBox
    Friend WithEvents bImportarReparacionesCliente0 As System.Windows.Forms.Button
    Friend WithEvents bImportarEquipos As System.Windows.Forms.Button
End Class
