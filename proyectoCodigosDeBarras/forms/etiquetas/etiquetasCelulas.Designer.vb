<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class etiquetasCelulas
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
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckVolverImprimir = New System.Windows.Forms.CheckBox()
        Me.txnumeroSerieFinal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txCopias = New System.Windows.Forms.TextBox()
        Me.txCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txNumeroSerieInicial = New System.Windows.Forms.TextBox()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cbImpresorasCable = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ckCelula = New System.Windows.Forms.CheckBox()
        Me.ckCable = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(564, 387)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(126, 70)
        Me.bLimpiar.TabIndex = 7
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(565, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(234, 411)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 22)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "Nº SERIE FINAL"
        '
        'ckVolverImprimir
        '
        Me.ckVolverImprimir.AutoSize = True
        Me.ckVolverImprimir.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVolverImprimir.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVolverImprimir.Location = New System.Drawing.Point(12, 374)
        Me.ckVolverImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckVolverImprimir.Name = "ckVolverImprimir"
        Me.ckVolverImprimir.Size = New System.Drawing.Size(388, 26)
        Me.ckVolverImprimir.TabIndex = 0
        Me.ckVolverImprimir.Text = "VOLVER A IMPRIMIR Nº SERIE IMPRESOS"
        Me.ckVolverImprimir.UseVisualStyleBackColor = True
        '
        'txnumeroSerieFinal
        '
        Me.txnumeroSerieFinal.BackColor = System.Drawing.SystemColors.Window
        Me.txnumeroSerieFinal.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnumeroSerieFinal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txnumeroSerieFinal.Location = New System.Drawing.Point(379, 408)
        Me.txnumeroSerieFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txnumeroSerieFinal.MaxLength = 9
        Me.txnumeroSerieFinal.Name = "txnumeroSerieFinal"
        Me.txnumeroSerieFinal.Size = New System.Drawing.Size(179, 31)
        Me.txnumeroSerieFinal.TabIndex = 2
        Me.txnumeroSerieFinal.Text = "0"
        Me.txnumeroSerieFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(286, 468)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(230, 22)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Nº COPIAS POR Nº SERIE"
        '
        'txCopias
        '
        Me.txCopias.BackColor = System.Drawing.SystemColors.Window
        Me.txCopias.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCopias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCopias.Location = New System.Drawing.Point(522, 465)
        Me.txCopias.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txCopias.MaxLength = 1
        Me.txCopias.Name = "txCopias"
        Me.txCopias.Size = New System.Drawing.Size(75, 31)
        Me.txCopias.TabIndex = 4
        Me.txCopias.Text = "1"
        Me.txCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txCantidad
        '
        Me.txCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidad.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidad.Location = New System.Drawing.Point(205, 465)
        Me.txCantidad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txCantidad.MaxLength = 4
        Me.txCantidad.Name = "txCantidad"
        Me.txCantidad.Size = New System.Drawing.Size(75, 31)
        Me.txCantidad.TabIndex = 3
        Me.txCantidad.Text = "1"
        Me.txCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 468)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 22)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "CANTIDAD Nº SERIE"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 165
        Me.PictureBox2.TabStop = False
        '
        'cbImpresoras
        '
        Me.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(207, 139)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(437, 30)
        Me.cbImpresoras.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(8, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(193, 22)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "IMPRESORA CÉLULA"
        '
        'txNumeroSerieInicial
        '
        Me.txNumeroSerieInicial.BackColor = System.Drawing.SystemColors.Window
        Me.txNumeroSerieInicial.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumeroSerieInicial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txNumeroSerieInicial.Location = New System.Drawing.Point(207, 101)
        Me.txNumeroSerieInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txNumeroSerieInicial.MaxLength = 9
        Me.txNumeroSerieInicial.Name = "txNumeroSerieInicial"
        Me.txNumeroSerieInicial.ReadOnly = True
        Me.txNumeroSerieInicial.Size = New System.Drawing.Size(476, 31)
        Me.txNumeroSerieInicial.TabIndex = 1
        Me.txNumeroSerieInicial.Text = "0"
        Me.txNumeroSerieInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(433, 13)
        Me.bImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(126, 70)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 22)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Nº SERIE INICIAL"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.impresora
        Me.PictureBox1.Location = New System.Drawing.Point(256, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cbImpresorasCable
        '
        Me.cbImpresorasCable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresorasCable.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresorasCable.FormattingEnabled = True
        Me.cbImpresorasCable.Location = New System.Drawing.Point(207, 175)
        Me.cbImpresorasCable.Name = "cbImpresorasCable"
        Me.cbImpresorasCable.Size = New System.Drawing.Size(437, 30)
        Me.cbImpresorasCable.TabIndex = 163
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(8, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 22)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "IMPRESORA CABLE"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ckCable)
        Me.Panel2.Controls.Add(Me.ckCelula)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cbImpresorasCable)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.bImprimir)
        Me.Panel2.Controls.Add(Me.txNumeroSerieInicial)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.bSalir)
        Me.Panel2.Controls.Add(Me.cbImpresoras)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(704, 226)
        Me.Panel2.TabIndex = 153
        '
        'ckCelula
        '
        Me.ckCelula.AutoSize = True
        Me.ckCelula.Checked = True
        Me.ckCelula.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckCelula.Location = New System.Drawing.Point(668, 149)
        Me.ckCelula.Name = "ckCelula"
        Me.ckCelula.Size = New System.Drawing.Size(15, 14)
        Me.ckCelula.TabIndex = 166
        Me.ckCelula.UseVisualStyleBackColor = True
        '
        'ckCable
        '
        Me.ckCable.AutoSize = True
        Me.ckCable.Checked = True
        Me.ckCable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckCable.Location = New System.Drawing.Point(668, 185)
        Me.ckCable.Name = "ckCable"
        Me.ckCable.Size = New System.Drawing.Size(15, 14)
        Me.ckCable.TabIndex = 167
        Me.ckCable.UseVisualStyleBackColor = True
        '
        'etiquetasCelulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 226)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ckVolverImprimir)
        Me.Controls.Add(Me.txnumeroSerieFinal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txCopias)
        Me.Controls.Add(Me.txCantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "etiquetasCelulas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ETIQUETAS CÉLULAS"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bLimpiar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ckVolverImprimir As CheckBox
    Friend WithEvents txnumeroSerieFinal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txCopias As TextBox
    Friend WithEvents txCantidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents cbImpresoras As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txNumeroSerieInicial As TextBox
    Friend WithEvents bImprimir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cbImpresorasCable As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ckCable As CheckBox
    Friend WithEvents ckCelula As CheckBox
End Class
