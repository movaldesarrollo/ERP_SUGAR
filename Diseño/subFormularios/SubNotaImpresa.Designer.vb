<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubNotaImpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubNotaImpresa))
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbNotas = New System.Windows.Forms.GroupBox
        Me.gbEdicion = New System.Windows.Forms.GroupBox
        Me.lbFuenteDec = New System.Windows.Forms.Label
        Me.lbNegrita = New System.Windows.Forms.Label
        Me.lbSubrayado = New System.Windows.Forms.Label
        Me.lbItalica = New System.Windows.Forms.Label
        Me.lbFuenteInc = New System.Windows.Forms.Label
        Me.rtbNota = New System.Windows.Forms.RichTextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNotas.SuspendLayout()
        Me.gbEdicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(619, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 117
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(725, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 118
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(15, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 119
        Me.PictureBox1.TabStop = False
        '
        'gbNotas
        '
        Me.gbNotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbNotas.Controls.Add(Me.gbEdicion)
        Me.gbNotas.Controls.Add(Me.rtbNota)
        Me.gbNotas.Location = New System.Drawing.Point(8, 67)
        Me.gbNotas.Name = "gbNotas"
        Me.gbNotas.Size = New System.Drawing.Size(820, 324)
        Me.gbNotas.TabIndex = 120
        Me.gbNotas.TabStop = False
        '
        'gbEdicion
        '
        Me.gbEdicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEdicion.Controls.Add(Me.lbFuenteDec)
        Me.gbEdicion.Controls.Add(Me.lbNegrita)
        Me.gbEdicion.Controls.Add(Me.lbSubrayado)
        Me.gbEdicion.Controls.Add(Me.lbItalica)
        Me.gbEdicion.Controls.Add(Me.lbFuenteInc)
        Me.gbEdicion.Location = New System.Drawing.Point(661, 12)
        Me.gbEdicion.Name = "gbEdicion"
        Me.gbEdicion.Size = New System.Drawing.Size(146, 35)
        Me.gbEdicion.TabIndex = 118
        Me.gbEdicion.TabStop = False
        '
        'lbFuenteDec
        '
        Me.lbFuenteDec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFuenteDec.AutoSize = True
        Me.lbFuenteDec.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFuenteDec.ForeColor = System.Drawing.Color.Black
        Me.lbFuenteDec.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFuenteDec.Location = New System.Drawing.Point(39, 10)
        Me.lbFuenteDec.Name = "lbFuenteDec"
        Me.lbFuenteDec.Size = New System.Drawing.Size(28, 21)
        Me.lbFuenteDec.TabIndex = 1
        Me.lbFuenteDec.Text = "A-"
        '
        'lbNegrita
        '
        Me.lbNegrita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNegrita.AutoSize = True
        Me.lbNegrita.BackColor = System.Drawing.SystemColors.Control
        Me.lbNegrita.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNegrita.ForeColor = System.Drawing.Color.Black
        Me.lbNegrita.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNegrita.Location = New System.Drawing.Point(72, 11)
        Me.lbNegrita.Name = "lbNegrita"
        Me.lbNegrita.Size = New System.Drawing.Size(18, 19)
        Me.lbNegrita.TabIndex = 2
        Me.lbNegrita.Text = "B"
        '
        'lbSubrayado
        '
        Me.lbSubrayado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbSubrayado.AutoSize = True
        Me.lbSubrayado.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubrayado.ForeColor = System.Drawing.Color.Black
        Me.lbSubrayado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubrayado.Location = New System.Drawing.Point(118, 10)
        Me.lbSubrayado.Name = "lbSubrayado"
        Me.lbSubrayado.Size = New System.Drawing.Size(21, 21)
        Me.lbSubrayado.TabIndex = 3
        Me.lbSubrayado.Text = "U"
        '
        'lbItalica
        '
        Me.lbItalica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbItalica.AutoSize = True
        Me.lbItalica.Font = New System.Drawing.Font("Century Schoolbook", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbItalica.ForeColor = System.Drawing.Color.Black
        Me.lbItalica.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbItalica.Location = New System.Drawing.Point(96, 11)
        Me.lbItalica.Name = "lbItalica"
        Me.lbItalica.Size = New System.Drawing.Size(16, 19)
        Me.lbItalica.TabIndex = 9
        Me.lbItalica.Text = "I"
        '
        'lbFuenteInc
        '
        Me.lbFuenteInc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFuenteInc.AutoSize = True
        Me.lbFuenteInc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFuenteInc.ForeColor = System.Drawing.Color.Black
        Me.lbFuenteInc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFuenteInc.Location = New System.Drawing.Point(7, 10)
        Me.lbFuenteInc.Name = "lbFuenteInc"
        Me.lbFuenteInc.Size = New System.Drawing.Size(32, 21)
        Me.lbFuenteInc.TabIndex = 0
        Me.lbFuenteInc.Text = "A+"
        '
        'rtbNota
        '
        Me.rtbNota.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbNota.AutoWordSelection = True
        Me.rtbNota.Font = New System.Drawing.Font("Gill Sans MT Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbNota.Location = New System.Drawing.Point(15, 53)
        Me.rtbNota.Name = "rtbNota"
        Me.rtbNota.Size = New System.Drawing.Size(792, 250)
        Me.rtbNota.TabIndex = 117
        Me.rtbNota.Text = ""
        '
        'SubNotaImpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 418)
        Me.Controls.Add(Me.gbNotas)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SubNotaImpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NOTA IMPRESA FACTURA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNotas.ResumeLayout(False)
        Me.gbEdicion.ResumeLayout(False)
        Me.gbEdicion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbNotas As System.Windows.Forms.GroupBox
    Friend WithEvents rtbNota As System.Windows.Forms.RichTextBox
    Friend WithEvents gbEdicion As System.Windows.Forms.GroupBox
    Friend WithEvents lbFuenteDec As System.Windows.Forms.Label
    Friend WithEvents lbNegrita As System.Windows.Forms.Label
    Friend WithEvents lbSubrayado As System.Windows.Forms.Label
    Friend WithEvents lbItalica As System.Windows.Forms.Label
    Friend WithEvents lbFuenteInc As System.Windows.Forms.Label
End Class
