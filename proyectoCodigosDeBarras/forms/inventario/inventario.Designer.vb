<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inventario
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
        Me.txTotalInventariado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.cbTipoProductos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProductos = New System.Windows.Forms.ComboBox()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.bActualizar = New System.Windows.Forms.Button()
        Me.lvProductos = New System.Windows.Forms.ListView()
        Me.colIDProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCodArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFechaFabricacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProductoInventariado = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txTotalBaseDatos = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbBaseDatos = New System.Windows.Forms.PictureBox()
        Me.pbInventariado = New System.Windows.Forms.PictureBox()
        Me.pbrBasedatos = New System.Windows.Forms.ProgressBar()
        Me.pbrInventario = New System.Windows.Forms.ProgressBar()
        Me.bRestaurar = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbBaseDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbInventariado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txTotalInventariado
        '
        Me.txTotalInventariado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalInventariado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalInventariado.Location = New System.Drawing.Point(1148, 756)
        Me.txTotalInventariado.Name = "txTotalInventariado"
        Me.txTotalInventariado.Size = New System.Drawing.Size(100, 23)
        Me.txTotalInventariado.TabIndex = 1
        Me.txTotalInventariado.TabStop = False
        Me.txTotalInventariado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(999, 758)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "TOTAL INVENTARIADO"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 169
        Me.PictureBox2.TabStop = False
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(990, 12)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(126, 70)
        Me.bLimpiar.TabIndex = 4
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1122, 12)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'cbTipoProductos
        '
        Me.cbTipoProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoProductos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoProductos.FormattingEnabled = True
        Me.cbTipoProductos.Items.AddRange(New Object() {"CELULAS", "CELULAS INDUSTRIALES", "EQUIPOS", "EQUIPOS INDUSTRIALES"})
        Me.cbTipoProductos.Location = New System.Drawing.Point(142, 31)
        Me.cbTipoProductos.Name = "cbTipoProductos"
        Me.cbTipoProductos.Size = New System.Drawing.Size(309, 25)
        Me.cbTipoProductos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 17)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "TIPO DE PRODUCTO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(457, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "PRODUCTO"
        '
        'cbProductos
        '
        Me.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProductos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProductos.FormattingEnabled = True
        Me.cbProductos.Location = New System.Drawing.Point(537, 31)
        Me.cbProductos.Name = "cbProductos"
        Me.cbProductos.Size = New System.Drawing.Size(309, 25)
        Me.cbProductos.TabIndex = 1
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(594, 13)
        Me.bBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(126, 70)
        Me.bBuscar.TabIndex = 1
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'bActualizar
        '
        Me.bActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bActualizar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bActualizar.Location = New System.Drawing.Point(726, 13)
        Me.bActualizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bActualizar.Name = "bActualizar"
        Me.bActualizar.Size = New System.Drawing.Size(126, 70)
        Me.bActualizar.TabIndex = 2
        Me.bActualizar.Text = "ACTUALIZAR"
        Me.bActualizar.UseVisualStyleBackColor = True
        '
        'lvProductos
        '
        Me.lvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDProducto, Me.colIdArticulo, Me.colCodArticulo, Me.colProducto, Me.colNumSerie, Me.colFechaFabricacion})
        Me.lvProductos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProductos.FullRowSelect = True
        Me.lvProductos.GridLines = True
        Me.lvProductos.Location = New System.Drawing.Point(15, 220)
        Me.lvProductos.MultiSelect = False
        Me.lvProductos.Name = "lvProductos"
        Me.lvProductos.Size = New System.Drawing.Size(601, 530)
        Me.lvProductos.TabIndex = 177
        Me.lvProductos.TabStop = False
        Me.lvProductos.UseCompatibleStateImageBehavior = False
        Me.lvProductos.View = System.Windows.Forms.View.Details
        '
        'colIDProducto
        '
        Me.colIDProducto.Text = "ID"
        Me.colIDProducto.Width = 0
        '
        'colIdArticulo
        '
        Me.colIdArticulo.Text = "ID ARTICULO"
        Me.colIdArticulo.Width = 0
        '
        'colCodArticulo
        '
        Me.colCodArticulo.Text = "CÓDIGO ART."
        Me.colCodArticulo.Width = 110
        '
        'colProducto
        '
        Me.colProducto.Text = "PRODUCTO"
        Me.colProducto.Width = 197
        '
        'colNumSerie
        '
        Me.colNumSerie.Text = "Nº SERIE PRODUCTO"
        Me.colNumSerie.Width = 141
        '
        'colFechaFabricacion
        '
        Me.colFechaFabricacion.Text = "FECHA FAB."
        Me.colFechaFabricacion.Width = 116
        '
        'lvProductoInventariado
        '
        Me.lvProductoInventariado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProductoInventariado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvProductoInventariado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProductoInventariado.FullRowSelect = True
        Me.lvProductoInventariado.GridLines = True
        Me.lvProductoInventariado.Location = New System.Drawing.Point(647, 220)
        Me.lvProductoInventariado.MultiSelect = False
        Me.lvProductoInventariado.Name = "lvProductoInventariado"
        Me.lvProductoInventariado.Size = New System.Drawing.Size(601, 530)
        Me.lvProductoInventariado.TabIndex = 178
        Me.lvProductoInventariado.TabStop = False
        Me.lvProductoInventariado.UseCompatibleStateImageBehavior = False
        Me.lvProductoInventariado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID ARTICULO"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "CÓDIGO ART."
        Me.ColumnHeader3.Width = 110
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "PRODUCTO"
        Me.ColumnHeader4.Width = 197
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Nº SERIE PRODUCTO"
        Me.ColumnHeader5.Width = 141
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "FECHA FAB."
        Me.ColumnHeader6.Width = 116
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(367, 758)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 17)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "TOTAL BASE DE DATOS"
        '
        'txTotalBaseDatos
        '
        Me.txTotalBaseDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalBaseDatos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalBaseDatos.Location = New System.Drawing.Point(516, 756)
        Me.txTotalBaseDatos.Name = "txTotalBaseDatos"
        Me.txTotalBaseDatos.Size = New System.Drawing.Size(100, 23)
        Me.txTotalBaseDatos.TabIndex = 179
        Me.txTotalBaseDatos.TabStop = False
        Me.txTotalBaseDatos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txCodigoBarras)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbTipoProductos)
        Me.GroupBox1.Controls.Add(Me.cbProductos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1233, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'txCodigoBarras
        '
        Me.txCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCodigoBarras.Location = New System.Drawing.Point(934, 30)
        Me.txCodigoBarras.Name = "txCodigoBarras"
        Me.txCodigoBarras.Size = New System.Drawing.Size(293, 27)
        Me.txCodigoBarras.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(852, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "NÚM. SERIE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 19)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "BASE DE DATOS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(643, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 19)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "INVENTARIADO"
        '
        'pbBaseDatos
        '
        Me.pbBaseDatos.Image = Global.ERP_SUGAR.My.Resources.Resources.Excel_icon
        Me.pbBaseDatos.Location = New System.Drawing.Point(584, 182)
        Me.pbBaseDatos.Name = "pbBaseDatos"
        Me.pbBaseDatos.Size = New System.Drawing.Size(32, 32)
        Me.pbBaseDatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbBaseDatos.TabIndex = 184
        Me.pbBaseDatos.TabStop = False
        '
        'pbInventariado
        '
        Me.pbInventariado.Image = Global.ERP_SUGAR.My.Resources.Resources.Excel_icon
        Me.pbInventariado.Location = New System.Drawing.Point(1216, 182)
        Me.pbInventariado.Name = "pbInventariado"
        Me.pbInventariado.Size = New System.Drawing.Size(32, 32)
        Me.pbInventariado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbInventariado.TabIndex = 185
        Me.pbInventariado.TabStop = False
        '
        'pbrBasedatos
        '
        Me.pbrBasedatos.Location = New System.Drawing.Point(322, 189)
        Me.pbrBasedatos.Name = "pbrBasedatos"
        Me.pbrBasedatos.Size = New System.Drawing.Size(253, 23)
        Me.pbrBasedatos.TabIndex = 186
        Me.pbrBasedatos.Visible = False
        '
        'pbrInventario
        '
        Me.pbrInventario.Location = New System.Drawing.Point(957, 189)
        Me.pbrInventario.Name = "pbrInventario"
        Me.pbrInventario.Size = New System.Drawing.Size(253, 23)
        Me.pbrInventario.TabIndex = 187
        Me.pbrInventario.Visible = False
        '
        'bRestaurar
        '
        Me.bRestaurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bRestaurar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRestaurar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bRestaurar.Location = New System.Drawing.Point(858, 12)
        Me.bRestaurar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bRestaurar.Name = "bRestaurar"
        Me.bRestaurar.Size = New System.Drawing.Size(126, 70)
        Me.bRestaurar.TabIndex = 188
        Me.bRestaurar.Text = "RESTAURAR"
        Me.bRestaurar.UseVisualStyleBackColor = True
        '
        'inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 789)
        Me.Controls.Add(Me.bRestaurar)
        Me.Controls.Add(Me.pbrInventario)
        Me.Controls.Add(Me.pbrBasedatos)
        Me.Controls.Add(Me.pbInventariado)
        Me.Controls.Add(Me.pbBaseDatos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txTotalBaseDatos)
        Me.Controls.Add(Me.lvProductoInventariado)
        Me.Controls.Add(Me.lvProductos)
        Me.Controls.Add(Me.bActualizar)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txTotalInventariado)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTARIO FABRICACIÓN HAYWARD"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbBaseDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbInventariado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txTotalInventariado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents bLimpiar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents cbTipoProductos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbProductos As ComboBox
    Friend WithEvents bBuscar As Button
    Friend WithEvents bActualizar As Button
    Friend WithEvents lvProductos As ListView
    Friend WithEvents colIDProducto As ColumnHeader
    Friend WithEvents colIdArticulo As ColumnHeader
    Friend WithEvents colCodArticulo As ColumnHeader
    Friend WithEvents colProducto As ColumnHeader
    Friend WithEvents colNumSerie As ColumnHeader
    Friend WithEvents colFechaFabricacion As ColumnHeader
    Friend WithEvents lvProductoInventariado As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents txTotalBaseDatos As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txCodigoBarras As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pbBaseDatos As PictureBox
    Friend WithEvents pbInventariado As PictureBox
    Friend WithEvents pbrBasedatos As ProgressBar
    Friend WithEvents pbrInventario As ProgressBar
    Friend WithEvents bRestaurar As Button
End Class
