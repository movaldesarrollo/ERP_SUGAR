<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionPaises
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionPaises))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.borrar = New System.Windows.Forms.Button
        Me.nuevo = New System.Windows.Forms.Button
        Me.guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bMoneda = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.ckNIFObligatorio = New System.Windows.Forms.CheckBox
        Me.ckExportacion = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lvPaises = New System.Windows.Forms.ListView
        Me.lvidPais = New System.Windows.Forms.ColumnHeader
        Me.lvcodPais = New System.Windows.Forms.ColumnHeader
        Me.lvPais = New System.Windows.Forms.ColumnHeader
        Me.lvMoneda = New System.Windows.Forms.ColumnHeader
        Me.lvExportacion = New System.Windows.Forms.ColumnHeader
        Me.lvNIF = New System.Windows.Forms.ColumnHeader
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.codPais = New System.Windows.Forms.TextBox
        Me.Nombre = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(498, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(87, 50)
        Me.bSalir.TabIndex = 86
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'borrar
        '
        Me.borrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.borrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.borrar.Location = New System.Drawing.Point(406, 13)
        Me.borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(87, 50)
        Me.borrar.TabIndex = 85
        Me.borrar.Text = "BORRAR"
        Me.borrar.UseVisualStyleBackColor = True
        '
        'nuevo
        '
        Me.nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nuevo.Location = New System.Drawing.Point(222, 13)
        Me.nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(87, 50)
        Me.nuevo.TabIndex = 83
        Me.nuevo.Text = "NUEVO"
        Me.nuevo.UseVisualStyleBackColor = True
        '
        'guardar
        '
        Me.guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.guardar.Location = New System.Drawing.Point(314, 13)
        Me.guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(87, 50)
        Me.guardar.TabIndex = 84
        Me.guardar.Text = "GUARDAR"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.bMoneda)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbMoneda)
        Me.GroupBox1.Controls.Add(Me.ckNIFObligatorio)
        Me.GroupBox1.Controls.Add(Me.ckExportacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lvPaises)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.codPais)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 88)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(584, 571)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'bMoneda
        '
        Me.bMoneda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMoneda.Location = New System.Drawing.Point(314, 53)
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.Size = New System.Drawing.Size(27, 25)
        Me.bMoneda.TabIndex = 146
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "MONEDA"
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(108, 53)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(189, 25)
        Me.cbMoneda.TabIndex = 144
        '
        'ckNIFObligatorio
        '
        Me.ckNIFObligatorio.AutoSize = True
        Me.ckNIFObligatorio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckNIFObligatorio.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckNIFObligatorio.Location = New System.Drawing.Point(444, 79)
        Me.ckNIFObligatorio.Name = "ckNIFObligatorio"
        Me.ckNIFObligatorio.Size = New System.Drawing.Size(135, 21)
        Me.ckNIFObligatorio.TabIndex = 35
        Me.ckNIFObligatorio.Text = "NIF OBLIGATORIO"
        Me.ckNIFObligatorio.UseVisualStyleBackColor = True
        '
        'ckExportacion
        '
        Me.ckExportacion.AutoSize = True
        Me.ckExportacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckExportacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckExportacion.Location = New System.Drawing.Point(444, 56)
        Me.ckExportacion.Name = "ckExportacion"
        Me.ckExportacion.Size = New System.Drawing.Size(118, 21)
        Me.ckExportacion.TabIndex = 35
        Me.ckExportacion.Text = "EXPORTACIÓN"
        Me.ckExportacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(453, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "CÓDIGO"
        '
        'lvPaises
        '
        Me.lvPaises.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvPaises.AllowColumnReorder = True
        Me.lvPaises.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPaises.AutoArrange = False
        Me.lvPaises.BackgroundImageTiled = True
        Me.lvPaises.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidPais, Me.lvcodPais, Me.lvPais, Me.lvMoneda, Me.lvExportacion, Me.lvNIF})
        Me.lvPaises.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPaises.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPaises.FullRowSelect = True
        Me.lvPaises.GridLines = True
        Me.lvPaises.HideSelection = False
        Me.lvPaises.Location = New System.Drawing.Point(12, 107)
        Me.lvPaises.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPaises.Name = "lvPaises"
        Me.lvPaises.ShowItemToolTips = True
        Me.lvPaises.Size = New System.Drawing.Size(560, 448)
        Me.lvPaises.TabIndex = 3
        Me.lvPaises.UseCompatibleStateImageBehavior = False
        Me.lvPaises.View = System.Windows.Forms.View.Details
        '
        'lvidPais
        '
        Me.lvidPais.Text = "idPais"
        Me.lvidPais.Width = 0
        '
        'lvcodPais
        '
        Me.lvcodPais.Text = "COD."
        Me.lvcodPais.Width = 45
        '
        'lvPais
        '
        Me.lvPais.Text = "PAÍS"
        Me.lvPais.Width = 233
        '
        'lvMoneda
        '
        Me.lvMoneda.Text = "MONEDA"
        Me.lvMoneda.Width = 123
        '
        'lvExportacion
        '
        Me.lvExportacion.Text = "EXP."
        '
        'lvNIF
        '
        Me.lvNIF.Text = "NIF"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(9, 25)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 17)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "NOMBRE"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(-120, 123)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 17)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "E-MAIL"
        '
        'codPais
        '
        Me.codPais.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codPais.Location = New System.Drawing.Point(525, 22)
        Me.codPais.Margin = New System.Windows.Forms.Padding(4)
        Me.codPais.MaxLength = 3
        Me.codPais.Name = "codPais"
        Me.codPais.Size = New System.Drawing.Size(43, 23)
        Me.codPais.TabIndex = 1
        '
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(108, 22)
        Me.Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.Nombre.MaxLength = 50
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(314, 23)
        Me.Nombre.TabIndex = 1
        '
        'GestionPaises
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 673)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.borrar)
        Me.Controls.Add(Me.nuevo)
        Me.Controls.Add(Me.guardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionPaises"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE PAISES"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents borrar As System.Windows.Forms.Button
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvPaises As System.Windows.Forms.ListView
    Friend WithEvents lvidPais As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPais As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents lvcodPais As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckExportacion As System.Windows.Forms.CheckBox
    Friend WithEvents codPais As System.Windows.Forms.TextBox
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents ckNIFObligatorio As System.Windows.Forms.CheckBox
    Friend WithEvents lvExportacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNIF As System.Windows.Forms.ColumnHeader
End Class
