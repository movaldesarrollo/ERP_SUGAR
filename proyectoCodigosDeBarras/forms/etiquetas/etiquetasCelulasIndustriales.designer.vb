<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class etiquetasCelulasIndustriales
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckVolverImprimir = New System.Windows.Forms.CheckBox()
        Me.txnumeroSerieFinal = New System.Windows.Forms.TextBox()
        Me.cbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txCopias = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNumeroSerieInicial = New System.Windows.Forms.TextBox()
        Me.txCantidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(432, 13)
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
        Me.bSalir.Location = New System.Drawing.Point(564, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(300, 13)
        Me.bImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(126, 70)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(706, 247)
        Me.Panel2.TabIndex = 153
        Me.Panel2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.impresora
        Me.PictureBox1.Location = New System.Drawing.Point(270, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(180, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(366, 128)
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
        Me.ckVolverImprimir.Location = New System.Drawing.Point(12, 90)
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
        Me.txnumeroSerieFinal.Location = New System.Drawing.Point(511, 124)
        Me.txnumeroSerieFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txnumeroSerieFinal.MaxLength = 9
        Me.txnumeroSerieFinal.Name = "txnumeroSerieFinal"
        Me.txnumeroSerieFinal.Size = New System.Drawing.Size(179, 31)
        Me.txnumeroSerieFinal.TabIndex = 2
        Me.txnumeroSerieFinal.Text = "0"
        Me.txnumeroSerieFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbImpresoras
        '
        Me.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(169, 201)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(521, 30)
        Me.cbImpresoras.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(8, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 22)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "IMPRESORA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(366, 167)
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
        Me.txCopias.Location = New System.Drawing.Point(615, 163)
        Me.txCopias.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txCopias.MaxLength = 1
        Me.txCopias.Name = "txCopias"
        Me.txCopias.Size = New System.Drawing.Size(75, 31)
        Me.txCopias.TabIndex = 4
        Me.txCopias.Text = "1"
        Me.txCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 22)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Nº SERIE INICIAL"
        '
        'txNumeroSerieInicial
        '
        Me.txNumeroSerieInicial.BackColor = System.Drawing.SystemColors.Window
        Me.txNumeroSerieInicial.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumeroSerieInicial.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txNumeroSerieInicial.Location = New System.Drawing.Point(169, 124)
        Me.txNumeroSerieInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txNumeroSerieInicial.MaxLength = 9
        Me.txNumeroSerieInicial.Name = "txNumeroSerieInicial"
        Me.txNumeroSerieInicial.ReadOnly = True
        Me.txNumeroSerieInicial.Size = New System.Drawing.Size(179, 31)
        Me.txNumeroSerieInicial.TabIndex = 1
        Me.txNumeroSerieInicial.Text = "0"
        Me.txNumeroSerieInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txCantidad
        '
        Me.txCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidad.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidad.Location = New System.Drawing.Point(273, 163)
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
        Me.Label1.Location = New System.Drawing.Point(8, 167)
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
        Me.PictureBox2.TabIndex = 166
        Me.PictureBox2.TabStop = False
        '
        'etiquetasCelulasIndustriales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 244)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ckVolverImprimir)
        Me.Controls.Add(Me.txnumeroSerieFinal)
        Me.Controls.Add(Me.cbImpresoras)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txCopias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txNumeroSerieInicial)
        Me.Controls.Add(Me.txCantidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "etiquetasCelulasIndustriales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ETIQUETAS CÉLULAS INDUSTRIALES"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bLimpiar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents bImprimir As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ckVolverImprimir As CheckBox
    Friend WithEvents txnumeroSerieFinal As TextBox
    Friend WithEvents cbImpresoras As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txCopias As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txNumeroSerieInicial As TextBox
    Friend WithEvents txCantidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
