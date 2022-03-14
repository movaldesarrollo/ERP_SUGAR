<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subServirAlbaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subServirAlbaran))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.dtpFechaPrevista = New System.Windows.Forms.DateTimePicker
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RefCliente2 = New System.Windows.Forms.TextBox
        Me.lbNumDoc = New System.Windows.Forms.Label
        Me.numDoc = New System.Windows.Forms.TextBox
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbTransporte = New System.Windows.Forms.ComboBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(389, 17)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(493, 17)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'dtpFechaPrevista
        '
        Me.dtpFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevista.Location = New System.Drawing.Point(133, 161)
        Me.dtpFechaPrevista.Name = "dtpFechaPrevista"
        Me.dtpFechaPrevista.Size = New System.Drawing.Size(106, 23)
        Me.dtpFechaPrevista.TabIndex = 0
        Me.dtpFechaPrevista.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(248, 164)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(105, 17)
        Me.Label45.TabIndex = 125
        Me.Label45.Text = "Nº EXPEDICIÓN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(24, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "FECHA SALIDA"
        '
        'RefCliente2
        '
        Me.RefCliente2.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente2.Location = New System.Drawing.Point(360, 161)
        Me.RefCliente2.MaxLength = 50
        Me.RefCliente2.Name = "RefCliente2"
        Me.RefCliente2.Size = New System.Drawing.Size(221, 23)
        Me.RefCliente2.TabIndex = 1
        '
        'lbNumDoc
        '
        Me.lbNumDoc.AutoSize = True
        Me.lbNumDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc.Location = New System.Drawing.Point(23, 91)
        Me.lbNumDoc.Name = "lbNumDoc"
        Me.lbNumDoc.Size = New System.Drawing.Size(104, 19)
        Me.lbNumDoc.TabIndex = 128
        Me.lbNumDoc.Text = "Nº ALBARÁN"
        '
        'numDoc
        '
        Me.numDoc.BackColor = System.Drawing.SystemColors.Control
        Me.numDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numDoc.Location = New System.Drawing.Point(133, 88)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.ReadOnly = True
        Me.numDoc.Size = New System.Drawing.Size(106, 27)
        Me.numDoc.TabIndex = 5
        Me.numDoc.TabStop = False
        Me.numDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Cliente
        '
        Me.Cliente.BackColor = System.Drawing.SystemColors.Control
        Me.Cliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cliente.Location = New System.Drawing.Point(133, 125)
        Me.Cliente.MaxLength = 20
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Size = New System.Drawing.Size(448, 23)
        Me.Cliente.TabIndex = 6
        Me.Cliente.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(49, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "CLIENTE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(248, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 17)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "TRANSPORTE"
        '
        'cbTransporte
        '
        Me.cbTransporte.DropDownWidth = 225
        Me.cbTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Location = New System.Drawing.Point(360, 197)
        Me.cbTransporte.MaxLength = 50
        Me.cbTransporte.Name = "cbTransporte"
        Me.cbTransporte.Size = New System.Drawing.Size(221, 25)
        Me.cbTransporte.TabIndex = 2
        '
        'subServirAlbaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 244)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbTransporte)
        Me.Controls.Add(Me.lbNumDoc)
        Me.Controls.Add(Me.numDoc)
        Me.Controls.Add(Me.dtpFechaPrevista)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.RefCliente2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subServirAlbaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SERVIR ALBARÁN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents dtpFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RefCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents lbNumDoc As System.Windows.Forms.Label
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents Cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
End Class
