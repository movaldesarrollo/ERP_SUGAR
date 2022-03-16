<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gestiontipopago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestiontipopago))
        Me.nuevo = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.ckProntoPago = New System.Windows.Forms.CheckBox
        Me.ckDias = New System.Windows.Forms.CheckBox
        Me.lvTiposPago = New System.Windows.Forms.ListView
        Me.CODIGO = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvnumPagos = New System.Windows.Forms.ColumnHeader
        Me.lvCarencia = New System.Windows.Forms.ColumnHeader
        Me.lvDiaPago = New System.Windows.Forms.ColumnHeader
        Me.lvProntoPAgo = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.numPagos = New System.Windows.Forms.TextBox
        Me.Carencia = New System.Windows.Forms.TextBox
        Me.Dias = New System.Windows.Forms.TextBox
        Me.descripcion = New System.Windows.Forms.TextBox
        Me.borrar = New System.Windows.Forms.Button
        Me.guardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nuevo
        '
        Me.nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevo.Enabled = False
        Me.nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nuevo.Location = New System.Drawing.Point(340, 17)
        Me.nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(87, 50)
        Me.nuevo.TabIndex = 1
        Me.nuevo.Text = "NUEVO"
        Me.nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ckActivo)
        Me.GroupBox1.Controls.Add(Me.ckProntoPago)
        Me.GroupBox1.Controls.Add(Me.ckDias)
        Me.GroupBox1.Controls.Add(Me.lvTiposPago)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.numPagos)
        Me.GroupBox1.Controls.Add(Me.Carencia)
        Me.GroupBox1.Controls.Add(Me.Dias)
        Me.GroupBox1.Controls.Add(Me.descripcion)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 75)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(720, 588)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(633, 33)
        Me.ckActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 1
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'ckProntoPago
        '
        Me.ckProntoPago.AutoSize = True
        Me.ckProntoPago.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProntoPago.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckProntoPago.Location = New System.Drawing.Point(585, 62)
        Me.ckProntoPago.Margin = New System.Windows.Forms.Padding(4)
        Me.ckProntoPago.Name = "ckProntoPago"
        Me.ckProntoPago.Size = New System.Drawing.Size(123, 21)
        Me.ckProntoPago.TabIndex = 6
        Me.ckProntoPago.Text = "PRONTO PAGO"
        Me.ckProntoPago.UseVisualStyleBackColor = True
        '
        'ckDias
        '
        Me.ckDias.AutoSize = True
        Me.ckDias.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckDias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDias.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckDias.Location = New System.Drawing.Point(378, 63)
        Me.ckDias.Margin = New System.Windows.Forms.Padding(4)
        Me.ckDias.Name = "ckDias"
        Me.ckDias.Size = New System.Drawing.Size(128, 21)
        Me.ckDias.TabIndex = 4
        Me.ckDias.Text = "DIAS PACTADOS"
        Me.ckDias.UseVisualStyleBackColor = True
        '
        'lvTiposPago
        '
        Me.lvTiposPago.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvTiposPago.AllowColumnReorder = True
        Me.lvTiposPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTiposPago.AutoArrange = False
        Me.lvTiposPago.BackgroundImageTiled = True
        Me.lvTiposPago.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CODIGO, Me.lvdescripcion, Me.lvnumPagos, Me.lvCarencia, Me.lvDiaPago, Me.lvProntoPAgo})
        Me.lvTiposPago.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvTiposPago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTiposPago.FullRowSelect = True
        Me.lvTiposPago.GridLines = True
        Me.lvTiposPago.HideSelection = False
        Me.lvTiposPago.Location = New System.Drawing.Point(8, 93)
        Me.lvTiposPago.Margin = New System.Windows.Forms.Padding(4)
        Me.lvTiposPago.Name = "lvTiposPago"
        Me.lvTiposPago.Size = New System.Drawing.Size(700, 487)
        Me.lvTiposPago.TabIndex = 7
        Me.lvTiposPago.UseCompatibleStateImageBehavior = False
        Me.lvTiposPago.View = System.Windows.Forms.View.Details
        '
        'CODIGO
        '
        Me.CODIGO.Text = "CODIGO"
        Me.CODIGO.Width = 0
        '
        'lvdescripcion
        '
        Me.lvdescripcion.Text = "DESCRIPCION"
        Me.lvdescripcion.Width = 330
        '
        'lvnumPagos
        '
        Me.lvnumPagos.Text = "NUM.PAGOS"
        Me.lvnumPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvnumPagos.Width = 87
        '
        'lvCarencia
        '
        Me.lvCarencia.Text = "CARENCIA"
        Me.lvCarencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvCarencia.Width = 78
        '
        'lvDiaPago
        '
        Me.lvDiaPago.Text = "DIAS PACTADOS"
        Me.lvDiaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvDiaPago.Width = 113
        '
        'lvProntoPAgo
        '
        Me.lvProntoPAgo.Text = "P.PAGO"
        Me.lvProntoPAgo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvProntoPAgo.Width = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(14, 64)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "NUM. PAGOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(217, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "CARENCIA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(14, 34)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
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
        Me.Label18.Location = New System.Drawing.Point(-120, 123)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 17)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "E-MAIL"
        '
        'numPagos
        '
        Me.numPagos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPagos.Location = New System.Drawing.Point(113, 61)
        Me.numPagos.Margin = New System.Windows.Forms.Padding(4)
        Me.numPagos.MaxLength = 70
        Me.numPagos.Name = "numPagos"
        Me.numPagos.Size = New System.Drawing.Size(53, 23)
        Me.numPagos.TabIndex = 2
        Me.numPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Carencia
        '
        Me.Carencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Carencia.Location = New System.Drawing.Point(298, 61)
        Me.Carencia.Margin = New System.Windows.Forms.Padding(4)
        Me.Carencia.MaxLength = 70
        Me.Carencia.Name = "Carencia"
        Me.Carencia.Size = New System.Drawing.Size(53, 23)
        Me.Carencia.TabIndex = 3
        Me.Carencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dias
        '
        Me.Dias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dias.Location = New System.Drawing.Point(509, 61)
        Me.Dias.Margin = New System.Windows.Forms.Padding(4)
        Me.Dias.MaxLength = 70
        Me.Dias.Name = "Dias"
        Me.Dias.Size = New System.Drawing.Size(53, 23)
        Me.Dias.TabIndex = 5
        Me.Dias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'descripcion
        '
        Me.descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descripcion.Location = New System.Drawing.Point(113, 31)
        Me.descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.descripcion.MaxLength = 70
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Size = New System.Drawing.Size(449, 23)
        Me.descripcion.TabIndex = 0
        '
        'borrar
        '
        Me.borrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.borrar.Enabled = False
        Me.borrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.borrar.Location = New System.Drawing.Point(538, 17)
        Me.borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(87, 50)
        Me.borrar.TabIndex = 3
        Me.borrar.Text = "BORRAR"
        Me.borrar.UseVisualStyleBackColor = True
        '
        'guardar
        '
        Me.guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.guardar.Location = New System.Drawing.Point(439, 17)
        Me.guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(87, 50)
        Me.guardar.TabIndex = 2
        Me.guardar.Text = "GUARDAR"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(637, 17)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
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
        'gestiontipopago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 673)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.borrar)
        Me.Controls.Add(Me.nuevo)
        Me.Controls.Add(Me.guardar)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gestiontipopago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE TIPOS DE PAGO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents borrar As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents lvTiposPago As System.Windows.Forms.ListView
    Friend WithEvents CODIGO As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents ckDias As System.Windows.Forms.CheckBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvDiaPago As System.Windows.Forms.ColumnHeader
    Friend WithEvents Dias As System.Windows.Forms.TextBox
    Friend WithEvents ckProntoPago As System.Windows.Forms.CheckBox
    Friend WithEvents lvProntoPAgo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numPagos As System.Windows.Forms.TextBox
    Friend WithEvents Carencia As System.Windows.Forms.TextBox
    Friend WithEvents lvnumPagos As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCarencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
