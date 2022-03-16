<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionCuentasPropias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionCuentasPropias))
        Me.gbBancos = New System.Windows.Forms.GroupBox
        Me.ckActivoB = New System.Windows.Forms.CheckBox
        Me.bBancos = New System.Windows.Forms.Button
        Me.SWIFT_BIC = New System.Windows.Forms.TextBox
        Me.IBAN = New System.Windows.Forms.TextBox
        Me.Nombre = New System.Windows.Forms.TextBox
        Me.codigocuenta = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.codigodc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.codigoEU = New System.Windows.Forms.TextBox
        Me.codigobanco = New System.Windows.Forms.TextBox
        Me.codigooficina = New System.Windows.Forms.TextBox
        Me.cbBanco = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.lvBancos = New System.Windows.Forms.ListView
        Me.lvidCuentaBanco = New System.Windows.Forms.ColumnHeader
        Me.lvBanco = New System.Windows.Forms.ColumnHeader
        Me.lvIBAN = New System.Windows.Forms.ColumnHeader
        Me.lvNombre = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.gbBancos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbBancos
        '
        Me.gbBancos.Controls.Add(Me.ckActivoB)
        Me.gbBancos.Controls.Add(Me.bBancos)
        Me.gbBancos.Controls.Add(Me.SWIFT_BIC)
        Me.gbBancos.Controls.Add(Me.IBAN)
        Me.gbBancos.Controls.Add(Me.Nombre)
        Me.gbBancos.Controls.Add(Me.codigocuenta)
        Me.gbBancos.Controls.Add(Me.Label26)
        Me.gbBancos.Controls.Add(Me.Label9)
        Me.gbBancos.Controls.Add(Me.Label56)
        Me.gbBancos.Controls.Add(Me.codigodc)
        Me.gbBancos.Controls.Add(Me.Label1)
        Me.gbBancos.Controls.Add(Me.Label34)
        Me.gbBancos.Controls.Add(Me.Label57)
        Me.gbBancos.Controls.Add(Me.Label3)
        Me.gbBancos.Controls.Add(Me.Label22)
        Me.gbBancos.Controls.Add(Me.codigoEU)
        Me.gbBancos.Controls.Add(Me.codigobanco)
        Me.gbBancos.Controls.Add(Me.codigooficina)
        Me.gbBancos.Controls.Add(Me.cbBanco)
        Me.gbBancos.Controls.Add(Me.Label20)
        Me.gbBancos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBancos.Location = New System.Drawing.Point(12, 80)
        Me.gbBancos.Name = "gbBancos"
        Me.gbBancos.Size = New System.Drawing.Size(811, 118)
        Me.gbBancos.TabIndex = 0
        Me.gbBancos.TabStop = False
        '
        'ckActivoB
        '
        Me.ckActivoB.AutoSize = True
        Me.ckActivoB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoB.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoB.Location = New System.Drawing.Point(516, 85)
        Me.ckActivoB.Name = "ckActivoB"
        Me.ckActivoB.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoB.TabIndex = 10
        Me.ckActivoB.Text = "ACTIVO"
        Me.ckActivoB.UseVisualStyleBackColor = True
        '
        'bBancos
        '
        Me.bBancos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBancos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBancos.Location = New System.Drawing.Point(436, 20)
        Me.bBancos.Name = "bBancos"
        Me.bBancos.Size = New System.Drawing.Size(27, 25)
        Me.bBancos.TabIndex = 1
        Me.bBancos.Text = "...."
        Me.bBancos.UseVisualStyleBackColor = True
        '
        'SWIFT_BIC
        '
        Me.SWIFT_BIC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWIFT_BIC.Location = New System.Drawing.Point(83, 53)
        Me.SWIFT_BIC.MaxLength = 11
        Me.SWIFT_BIC.Name = "SWIFT_BIC"
        Me.SWIFT_BIC.Size = New System.Drawing.Size(118, 23)
        Me.SWIFT_BIC.TabIndex = 3
        '
        'IBAN
        '
        Me.IBAN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IBAN.Location = New System.Drawing.Point(514, 22)
        Me.IBAN.MaxLength = 34
        Me.IBAN.Name = "IBAN"
        Me.IBAN.Size = New System.Drawing.Size(276, 23)
        Me.IBAN.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(83, 83)
        Me.Nombre.MaxLength = 34
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(334, 23)
        Me.Nombre.TabIndex = 9
        '
        'codigocuenta
        '
        Me.codigocuenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigocuenta.Location = New System.Drawing.Point(693, 53)
        Me.codigocuenta.MaxLength = 10
        Me.codigocuenta.Name = "codigocuenta"
        Me.codigocuenta.Size = New System.Drawing.Size(97, 23)
        Me.codigocuenta.TabIndex = 8
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(565, 56)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 17)
        Me.Label26.TabIndex = 91
        Me.Label26.Text = "DC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(314, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "BANCO"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label56.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label56.Location = New System.Drawing.Point(12, 56)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(68, 17)
        Me.Label56.TabIndex = 90
        Me.Label56.Text = "SWIFT/BIC"
        '
        'codigodc
        '
        Me.codigodc.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigodc.Location = New System.Drawing.Point(598, 53)
        Me.codigodc.MaxLength = 2
        Me.codigodc.Name = "codigodc"
        Me.codigodc.Size = New System.Drawing.Size(29, 23)
        Me.codigodc.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(18, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "NOMBRE"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(632, 56)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 17)
        Me.Label34.TabIndex = 92
        Me.Label34.Text = "CUENTA"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(469, 25)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(37, 17)
        Me.Label57.TabIndex = 89
        Me.Label57.Text = "IBAN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(221, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "IBAN"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(452, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 17)
        Me.Label22.TabIndex = 90
        Me.Label22.Text = "OFICINA"
        '
        'codigoEU
        '
        Me.codigoEU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigoEU.Location = New System.Drawing.Point(267, 53)
        Me.codigoEU.MaxLength = 4
        Me.codigoEU.Name = "codigoEU"
        Me.codigoEU.Size = New System.Drawing.Size(45, 23)
        Me.codigoEU.TabIndex = 4
        Me.codigoEU.Text = "ES"
        '
        'codigobanco
        '
        Me.codigobanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigobanco.Location = New System.Drawing.Point(372, 53)
        Me.codigobanco.MaxLength = 4
        Me.codigobanco.Name = "codigobanco"
        Me.codigobanco.Size = New System.Drawing.Size(45, 23)
        Me.codigobanco.TabIndex = 5
        '
        'codigooficina
        '
        Me.codigooficina.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigooficina.Location = New System.Drawing.Point(514, 53)
        Me.codigooficina.MaxLength = 4
        Me.codigooficina.Name = "codigooficina"
        Me.codigooficina.Size = New System.Drawing.Size(45, 23)
        Me.codigooficina.TabIndex = 6
        '
        'cbBanco
        '
        Me.cbBanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(83, 21)
        Me.cbBanco.MaxLength = 15
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(334, 25)
        Me.cbBanco.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(22, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 17)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "BANCO"
        '
        'lvBancos
        '
        Me.lvBancos.AllowColumnReorder = True
        Me.lvBancos.AllowDrop = True
        Me.lvBancos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBancos.AutoArrange = False
        Me.lvBancos.BackgroundImageTiled = True
        Me.lvBancos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidCuentaBanco, Me.lvBanco, Me.lvIBAN, Me.lvNombre})
        Me.lvBancos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvBancos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBancos.FullRowSelect = True
        Me.lvBancos.GridLines = True
        Me.lvBancos.HideSelection = False
        Me.lvBancos.Location = New System.Drawing.Point(12, 215)
        Me.lvBancos.Name = "lvBancos"
        Me.lvBancos.ShowItemToolTips = True
        Me.lvBancos.Size = New System.Drawing.Size(811, 151)
        Me.lvBancos.TabIndex = 1
        Me.lvBancos.UseCompatibleStateImageBehavior = False
        Me.lvBancos.View = System.Windows.Forms.View.Details
        '
        'lvidCuentaBanco
        '
        Me.lvidCuentaBanco.Text = "idCuentaBanco"
        Me.lvidCuentaBanco.Width = 0
        '
        'lvBanco
        '
        Me.lvBanco.Text = "BANCO"
        Me.lvBanco.Width = 263
        '
        'lvIBAN
        '
        Me.lvIBAN.Text = "IBAN"
        Me.lvIBAN.Width = 231
        '
        'lvNombre
        '
        Me.lvNombre.Text = "NOMBRE"
        Me.lvNombre.Width = 269
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 92
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(728, 15)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(87, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(630, 15)
        Me.bBorrar.Margin = New System.Windows.Forms.Padding(4)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(87, 50)
        Me.bBorrar.TabIndex = 4
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(434, 15)
        Me.bNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(87, 50)
        Me.bNuevo.TabIndex = 2
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(532, 15)
        Me.bGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(87, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'GestionCuentasPropias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 390)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.lvBancos)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.gbBancos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionCuentasPropias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE CUENTAS PROPIAS"
        Me.gbBancos.ResumeLayout(False)
        Me.gbBancos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbBancos As System.Windows.Forms.GroupBox
    Friend WithEvents ckActivoB As System.Windows.Forms.CheckBox
    Friend WithEvents bBancos As System.Windows.Forms.Button
    Friend WithEvents IBAN As System.Windows.Forms.TextBox
    Friend WithEvents SWIFT_BIC As System.Windows.Forms.TextBox
    Friend WithEvents codigocuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents codigodc As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents codigoEU As System.Windows.Forms.TextBox
    Friend WithEvents codigobanco As System.Windows.Forms.TextBox
    Friend WithEvents codigooficina As System.Windows.Forms.TextBox
    Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lvBancos As System.Windows.Forms.ListView
    Friend WithEvents lvidCuentaBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvIBAN As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
