<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subResumenReparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subResumenReparacion))
        Me.Label24 = New System.Windows.Forms.Label
        Me.ResumenEditable = New System.Windows.Forms.TextBox
        Me.Importe = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ResumenFijo = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bConvertirResumen = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.bConvertirConceptos = New System.Windows.Forms.Button
        Me.lbmonedaC = New System.Windows.Forms.Label
        Me.Codigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(15, 126)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 17)
        Me.Label24.TabIndex = 181
        Me.Label24.Text = "ARTÍCULO"
        '
        'ResumenEditable
        '
        Me.ResumenEditable.BackColor = System.Drawing.SystemColors.Window
        Me.ResumenEditable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResumenEditable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ResumenEditable.Location = New System.Drawing.Point(100, 123)
        Me.ResumenEditable.MaxLength = 200
        Me.ResumenEditable.Name = "ResumenEditable"
        Me.ResumenEditable.Size = New System.Drawing.Size(522, 23)
        Me.ResumenEditable.TabIndex = 0
        Me.ResumenEditable.TabStop = False
        '
        'Importe
        '
        Me.Importe.BackColor = System.Drawing.SystemColors.Window
        Me.Importe.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Importe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Importe.Location = New System.Drawing.Point(528, 91)
        Me.Importe.MaxLength = 15
        Me.Importe.Name = "Importe"
        Me.Importe.Size = New System.Drawing.Size(71, 23)
        Me.Importe.TabIndex = 2
        Me.Importe.TabStop = False
        Me.Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(460, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "IMPORTE"
        '
        'ResumenFijo
        '
        Me.ResumenFijo.BackColor = System.Drawing.SystemColors.Window
        Me.ResumenFijo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResumenFijo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ResumenFijo.Location = New System.Drawing.Point(100, 154)
        Me.ResumenFijo.MaxLength = 100
        Me.ResumenFijo.Name = "ResumenFijo"
        Me.ResumenFijo.ReadOnly = True
        Me.ResumenFijo.Size = New System.Drawing.Size(522, 23)
        Me.ResumenFijo.TabIndex = 1
        Me.ResumenFijo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 184
        Me.PictureBox1.TabStop = False
        '
        'bConvertirResumen
        '
        Me.bConvertirResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bConvertirResumen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConvertirResumen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bConvertirResumen.Location = New System.Drawing.Point(421, 12)
        Me.bConvertirResumen.Name = "bConvertirResumen"
        Me.bConvertirResumen.Size = New System.Drawing.Size(96, 50)
        Me.bConvertirResumen.TabIndex = 4
        Me.bConvertirResumen.Text = "CONVERTIR RESUMEN"
        Me.bConvertirResumen.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(528, 12)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(96, 50)
        Me.bCancelar.TabIndex = 5
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'bConvertirConceptos
        '
        Me.bConvertirConceptos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bConvertirConceptos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConvertirConceptos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bConvertirConceptos.Location = New System.Drawing.Point(314, 12)
        Me.bConvertirConceptos.Name = "bConvertirConceptos"
        Me.bConvertirConceptos.Size = New System.Drawing.Size(96, 50)
        Me.bConvertirConceptos.TabIndex = 3
        Me.bConvertirConceptos.Text = "CONVERTIR CONCEPTOS"
        Me.bConvertirConceptos.UseVisualStyleBackColor = True
        '
        'lbmonedaC
        '
        Me.lbmonedaC.AutoSize = True
        Me.lbmonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaC.Location = New System.Drawing.Point(601, 94)
        Me.lbmonedaC.Name = "lbmonedaC"
        Me.lbmonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaC.TabIndex = 185
        Me.lbmonedaC.Text = "€"
        '
        'Codigo
        '
        Me.Codigo.BackColor = System.Drawing.SystemColors.Window
        Me.Codigo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Codigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Codigo.Location = New System.Drawing.Point(100, 94)
        Me.Codigo.MaxLength = 15
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Size = New System.Drawing.Size(197, 23)
        Me.Codigo.TabIndex = 2
        Me.Codigo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(15, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "CÓDIGO"
        '
        'subResumenReparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 196)
        Me.Controls.Add(Me.lbmonedaC)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bConvertirConceptos)
        Me.Controls.Add(Me.bConvertirResumen)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Codigo)
        Me.Controls.Add(Me.Importe)
        Me.Controls.Add(Me.ResumenFijo)
        Me.Controls.Add(Me.ResumenEditable)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subResumenReparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RESUMEN REPARACIÓN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ResumenEditable As System.Windows.Forms.TextBox
    Friend WithEvents Importe As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ResumenFijo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bConvertirResumen As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents bConvertirConceptos As System.Windows.Forms.Button
    Friend WithEvents lbmonedaC As System.Windows.Forms.Label
    Friend WithEvents Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
