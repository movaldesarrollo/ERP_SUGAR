<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subSelecionarNumSerie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subSelecionarNumSerie))
        Me.NumSerieDesde = New System.Windows.Forms.TextBox
        Me.lbAsignar = New System.Windows.Forms.Label
        Me.NumSerieHasta = New System.Windows.Forms.TextBox
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'NumSerieDesde
        '
        Me.NumSerieDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumSerieDesde.Location = New System.Drawing.Point(21, 53)
        Me.NumSerieDesde.Name = "NumSerieDesde"
        Me.NumSerieDesde.Size = New System.Drawing.Size(100, 23)
        Me.NumSerieDesde.TabIndex = 0
        '
        'lbAsignar
        '
        Me.lbAsignar.AutoSize = True
        Me.lbAsignar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAsignar.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbAsignar.Location = New System.Drawing.Point(16, 20)
        Me.lbAsignar.Name = "lbAsignar"
        Me.lbAsignar.Size = New System.Drawing.Size(226, 17)
        Me.lbAsignar.TabIndex = 124
        Me.lbAsignar.Text = "ASIGNAR NÚMEROS DE SERIE ENTRE"
        '
        'NumSerieHasta
        '
        Me.NumSerieHasta.BackColor = System.Drawing.SystemColors.Window
        Me.NumSerieHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumSerieHasta.Location = New System.Drawing.Point(144, 53)
        Me.NumSerieHasta.Name = "NumSerieHasta"
        Me.NumSerieHasta.ReadOnly = True
        Me.NumSerieHasta.Size = New System.Drawing.Size(100, 23)
        Me.NumSerieHasta.TabIndex = 1
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(293, 32)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 2
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(394, 32)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 3
        Me.bSalir.Text = "CANCELAR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'subSelecionarNumSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 112)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.lbAsignar)
        Me.Controls.Add(Me.NumSerieHasta)
        Me.Controls.Add(Me.NumSerieDesde)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subSelecionarNumSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NÚMEROS DE SERIE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NumSerieDesde As System.Windows.Forms.TextBox
    Friend WithEvents lbAsignar As System.Windows.Forms.Label
    Friend WithEvents NumSerieHasta As System.Windows.Forms.TextBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
End Class
