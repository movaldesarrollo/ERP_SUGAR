<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedaproveedor
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
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.ckBajas = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.nif = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.nombrefiscal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.codContable = New System.Windows.Forms.TextBox
        Me.codproveedor = New System.Windows.Forms.TextBox
        Me.nombrecomercial = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lvProveedores = New System.Windows.Forms.ListView
        Me.lvidProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvcodProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvcodContable = New System.Windows.Forms.ColumnHeader
        Me.lvnombrecomercial = New System.Windows.Forms.ColumnHeader
        Me.lvnombrefiscal = New System.Windows.Forms.ColumnHeader
        Me.lvNIF = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bListado = New System.Windows.Forms.Button
        Me.frdatosgenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.ckBajas)
        Me.frdatosgenerales.Controls.Add(Me.Label21)
        Me.frdatosgenerales.Controls.Add(Me.cbTipo)
        Me.frdatosgenerales.Controls.Add(Me.nif)
        Me.frdatosgenerales.Controls.Add(Me.Label5)
        Me.frdatosgenerales.Controls.Add(Me.nombrefiscal)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.Label2)
        Me.frdatosgenerales.Controls.Add(Me.codContable)
        Me.frdatosgenerales.Controls.Add(Me.codproveedor)
        Me.frdatosgenerales.Controls.Add(Me.nombrecomercial)
        Me.frdatosgenerales.Controls.Add(Me.Label1)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(12, 100)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(644, 151)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'ckBajas
        '
        Me.ckBajas.AutoSize = True
        Me.ckBajas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckBajas.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckBajas.Location = New System.Drawing.Point(9, 119)
        Me.ckBajas.Name = "ckBajas"
        Me.ckBajas.Size = New System.Drawing.Size(122, 21)
        Me.ckBajas.TabIndex = 5
        Me.ckBajas.Text = "VER INACTIVOS"
        Me.ckBajas.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(322, 121)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 17)
        Me.Label21.TabIndex = 112
        Me.Label21.Text = "TIPO PROVEEDOR"
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(449, 117)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(189, 25)
        Me.cbTipo.TabIndex = 6
        '
        'nif
        '
        Me.nif.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif.Location = New System.Drawing.Point(525, 29)
        Me.nif.MaxLength = 15
        Me.nif.Name = "nif"
        Me.nif.Size = New System.Drawing.Size(113, 23)
        Me.nif.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(459, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "NIF / CIF"
        '
        'nombrefiscal
        '
        Me.nombrefiscal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrefiscal.Location = New System.Drawing.Point(156, 88)
        Me.nombrefiscal.MaxLength = 60
        Me.nombrefiscal.Name = "nombrefiscal"
        Me.nombrefiscal.Size = New System.Drawing.Size(482, 23)
        Me.nombrefiscal.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(6, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "NOMBRE FISCAL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(239, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "CÓD.CONTABLE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "CÓDIGO PROVEEDOR"
        '
        'codContable
        '
        Me.codContable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codContable.ForeColor = System.Drawing.Color.Black
        Me.codContable.Location = New System.Drawing.Point(353, 29)
        Me.codContable.Name = "codContable"
        Me.codContable.Size = New System.Drawing.Size(90, 23)
        Me.codContable.TabIndex = 1
        '
        'codproveedor
        '
        Me.codproveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codproveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.codproveedor.Location = New System.Drawing.Point(156, 29)
        Me.codproveedor.Name = "codproveedor"
        Me.codproveedor.Size = New System.Drawing.Size(77, 23)
        Me.codproveedor.TabIndex = 0
        '
        'nombrecomercial
        '
        Me.nombrecomercial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrecomercial.Location = New System.Drawing.Point(156, 59)
        Me.nombrecomercial.MaxLength = 60
        Me.nombrecomercial.Name = "nombrecomercial"
        Me.nombrecomercial.Size = New System.Drawing.Size(482, 23)
        Me.nombrecomercial.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(6, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOMBRE COMERCIAL"
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(566, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(89, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(370, 23)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(89, 50)
        Me.bLimpiar.TabIndex = 3
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lvProveedores
        '
        Me.lvProveedores.AllowColumnReorder = True
        Me.lvProveedores.AllowDrop = True
        Me.lvProveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProveedores.AutoArrange = False
        Me.lvProveedores.BackgroundImageTiled = True
        Me.lvProveedores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidProveedor, Me.lvcodProveedor, Me.lvcodContable, Me.lvnombrecomercial, Me.lvnombrefiscal, Me.lvNIF})
        Me.lvProveedores.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvProveedores.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProveedores.FullRowSelect = True
        Me.lvProveedores.GridLines = True
        Me.lvProveedores.HideSelection = False
        Me.lvProveedores.Location = New System.Drawing.Point(12, 257)
        Me.lvProveedores.Name = "lvProveedores"
        Me.lvProveedores.Size = New System.Drawing.Size(644, 482)
        Me.lvProveedores.TabIndex = 1
        Me.lvProveedores.UseCompatibleStateImageBehavior = False
        Me.lvProveedores.View = System.Windows.Forms.View.Details
        '
        'lvidProveedor
        '
        Me.lvidProveedor.Text = "IDproveedor"
        Me.lvidProveedor.Width = 0
        '
        'lvcodProveedor
        '
        Me.lvcodProveedor.Text = "CÓDIGO"
        Me.lvcodProveedor.Width = 69
        '
        'lvcodContable
        '
        Me.lvcodContable.Text = "CÓD.CONTABLE"
        Me.lvcodContable.Width = 107
        '
        'lvnombrecomercial
        '
        Me.lvnombrecomercial.Text = "NOMBRE COMERCIAL"
        Me.lvnombrecomercial.Width = 173
        '
        'lvnombrefiscal
        '
        Me.lvnombrefiscal.Text = "NOMBRE FISCAL"
        Me.lvnombrefiscal.Width = 158
        '
        'lvNIF
        '
        Me.lvNIF.Text = "NIF / CIF"
        Me.lvNIF.Width = 105
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(595, 746)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 2
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(485, 749)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "ENCONTRADOS"
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(470, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 4
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bListado
        '
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(270, 23)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(89, 50)
        Me.bListado.TabIndex = 3
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'busquedaproveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 778)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvProveedores)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.bLimpiar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busquedaproveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE PROVEEDOR"
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents nif As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nombrefiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents codproveedor As System.Windows.Forms.TextBox
    Friend WithEvents nombrecomercial As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvProveedores As System.Windows.Forms.ListView
    Friend WithEvents lvidProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnombrecomercial As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnombrefiscal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNIF As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lvcodProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ckBajas As System.Windows.Forms.CheckBox
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents codContable As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvcodContable As System.Windows.Forms.ColumnHeader
    Friend WithEvents bListado As System.Windows.Forms.Button
End Class
