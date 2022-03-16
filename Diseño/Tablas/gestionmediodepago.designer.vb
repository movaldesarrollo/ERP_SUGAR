<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gestionmediodepago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestionmediodepago))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbGiro = New System.Windows.Forms.RadioButton
        Me.rbTransferencia = New System.Windows.Forms.RadioButton
        Me.lvMediosPago = New System.Windows.Forms.ListView
        Me.CODIGO = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvBanco = New System.Windows.Forms.ColumnHeader
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.descripcion = New System.Windows.Forms.TextBox
        Me.nuevo = New System.Windows.Forms.Button
        Me.borrar = New System.Windows.Forms.Button
        Me.guardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.rbSinCuenta = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbSinCuenta)
        Me.GroupBox1.Controls.Add(Me.rbGiro)
        Me.GroupBox1.Controls.Add(Me.rbTransferencia)
        Me.GroupBox1.Controls.Add(Me.lvMediosPago)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.descripcion)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 571)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'rbGiro
        '
        Me.rbGiro.AutoSize = True
        Me.rbGiro.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGiro.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbGiro.Location = New System.Drawing.Point(249, 47)
        Me.rbGiro.Name = "rbGiro"
        Me.rbGiro.Size = New System.Drawing.Size(59, 21)
        Me.rbGiro.TabIndex = 2
        Me.rbGiro.TabStop = True
        Me.rbGiro.Text = "GIRO"
        Me.rbGiro.UseVisualStyleBackColor = True
        '
        'rbTransferencia
        '
        Me.rbTransferencia.AutoSize = True
        Me.rbTransferencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTransferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbTransferencia.Location = New System.Drawing.Point(321, 47)
        Me.rbTransferencia.Name = "rbTransferencia"
        Me.rbTransferencia.Size = New System.Drawing.Size(125, 21)
        Me.rbTransferencia.TabIndex = 3
        Me.rbTransferencia.TabStop = True
        Me.rbTransferencia.Text = "TRANSFERENCIA"
        Me.rbTransferencia.UseVisualStyleBackColor = True
        '
        'lvMediosPago
        '
        Me.lvMediosPago.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvMediosPago.AllowColumnReorder = True
        Me.lvMediosPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMediosPago.AutoArrange = False
        Me.lvMediosPago.BackgroundImageTiled = True
        Me.lvMediosPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CODIGO, Me.lvdescripcion, Me.lvBanco})
        Me.lvMediosPago.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvMediosPago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMediosPago.FullRowSelect = True
        Me.lvMediosPago.GridLines = True
        Me.lvMediosPago.HideSelection = False
        Me.lvMediosPago.Location = New System.Drawing.Point(29, 76)
        Me.lvMediosPago.Name = "lvMediosPago"
        Me.lvMediosPago.Size = New System.Drawing.Size(491, 481)
        Me.lvMediosPago.TabIndex = 4
        Me.lvMediosPago.UseCompatibleStateImageBehavior = False
        Me.lvMediosPago.View = System.Windows.Forms.View.Details
        '
        'CODIGO
        '
        Me.CODIGO.Text = "CODIGO"
        Me.CODIGO.Width = 0
        '
        'lvdescripcion
        '
        Me.lvdescripcion.Text = "DESCRIPCION"
        Me.lvdescripcion.Width = 313
        '
        'lvBanco
        '
        Me.lvBanco.Text = "CUENTA"
        Me.lvBanco.Width = 136
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(70, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 17)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "DESCRIPCION"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(-90, 94)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 17)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "E-MAIL"
        '
        'descripcion
        '
        Me.descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descripcion.Location = New System.Drawing.Point(173, 18)
        Me.descripcion.MaxLength = 50
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Size = New System.Drawing.Size(274, 23)
        Me.descripcion.TabIndex = 0
        '
        'nuevo
        '
        Me.nuevo.Enabled = False
        Me.nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nuevo.Location = New System.Drawing.Point(182, 15)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(87, 50)
        Me.nuevo.TabIndex = 1
        Me.nuevo.Text = "NUEVO"
        Me.nuevo.UseVisualStyleBackColor = True
        '
        'borrar
        '
        Me.borrar.Enabled = False
        Me.borrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.borrar.Location = New System.Drawing.Point(368, 15)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(87, 50)
        Me.borrar.TabIndex = 3
        Me.borrar.Text = "BORRAR"
        Me.borrar.UseVisualStyleBackColor = True
        '
        'guardar
        '
        Me.guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.guardar.Location = New System.Drawing.Point(275, 15)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(87, 50)
        Me.guardar.TabIndex = 2
        Me.guardar.Text = "GUARDAR"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(461, 15)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(87, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 88
        Me.PictureBox1.TabStop = False
        '
        'rbSinCuenta
        '
        Me.rbSinCuenta.AutoSize = True
        Me.rbSinCuenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinCuenta.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbSinCuenta.Location = New System.Drawing.Point(73, 47)
        Me.rbSinCuenta.Name = "rbSinCuenta"
        Me.rbSinCuenta.Size = New System.Drawing.Size(164, 21)
        Me.rbSinCuenta.TabIndex = 2
        Me.rbSinCuenta.TabStop = True
        Me.rbSinCuenta.Text = "NO REQUIERE CUENTA"
        Me.rbSinCuenta.UseVisualStyleBackColor = True
        '
        'gestionmediodepago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 673)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.borrar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.nuevo)
        Me.Controls.Add(Me.guardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gestionmediodepago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE MEDIOS DE PAGO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CODIGO As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents borrar As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvMediosPago As System.Windows.Forms.ListView
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rbGiro As System.Windows.Forms.RadioButton
    Friend WithEvents rbTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinCuenta As System.Windows.Forms.RadioButton
End Class
