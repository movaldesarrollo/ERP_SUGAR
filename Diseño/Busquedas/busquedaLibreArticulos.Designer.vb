<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedalibreArticulos
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
        Me.components = New System.ComponentModel.Container
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lvBusquedaArticulo = New System.Windows.Forms.ListView
        Me.lvExtender = New System.Windows.Forms.ColumnHeader
        Me.lvId = New System.Windows.Forms.ColumnHeader
        Me.lvCodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvDoc = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvImporte = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsExportarExpandido = New System.Windows.Forms.ToolStripMenuItem
        Me.ExpandidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BorraLineasSeleccionadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cbTipoDoc = New System.Windows.Forms.ComboBox
        Me.gbCriterios = New System.Windows.Forms.GroupBox
        Me.gbCheckbox = New System.Windows.Forms.GroupBox
        Me.ckServido = New System.Windows.Forms.CheckBox
        Me.ckProduccion = New System.Windows.Forms.CheckBox
        Me.ckProducido = New System.Windows.Forms.CheckBox
        Me.ckParcial = New System.Windows.Forms.CheckBox
        Me.ckPreparado = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txCodigo3not = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txCodigo2not = New System.Windows.Forms.TextBox
        Me.txArticulo1not = New System.Windows.Forms.TextBox
        Me.txCodigo1not = New System.Windows.Forms.TextBox
        Me.txArticulo2not = New System.Windows.Forms.TextBox
        Me.txArticulo3not = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txCodigo3 = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.txCodigo2 = New System.Windows.Forms.TextBox
        Me.txArticulo1 = New System.Windows.Forms.TextBox
        Me.txCodigo1 = New System.Windows.Forms.TextBox
        Me.txArticulo2 = New System.Windows.Forms.TextBox
        Me.txArticulo3 = New System.Windows.Forms.TextBox
        Me.txID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.bListado = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.txTotalCantidad = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txTotalEncontrados = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.bBuscar = New System.Windows.Forms.Button
        Me.txTotalImporte = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ckActivarSeleccion = New System.Windows.Forms.CheckBox
        Me.ckPendiente = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gbCriterios.SuspendLayout()
        Me.gbCheckbox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'lvBusquedaArticulo
        '
        Me.lvBusquedaArticulo.AllowColumnReorder = True
        Me.lvBusquedaArticulo.AllowDrop = True
        Me.lvBusquedaArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBusquedaArticulo.AutoArrange = False
        Me.lvBusquedaArticulo.BackgroundImageTiled = True
        Me.lvBusquedaArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvExtender, Me.lvId, Me.lvCodArticulo, Me.lvDoc, Me.lvArticulo, Me.lvCliente, Me.lvCantidad, Me.lvImporte})
        Me.lvBusquedaArticulo.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvBusquedaArticulo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvBusquedaArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBusquedaArticulo.FullRowSelect = True
        Me.lvBusquedaArticulo.GridLines = True
        Me.lvBusquedaArticulo.HideSelection = False
        Me.lvBusquedaArticulo.Location = New System.Drawing.Point(16, 245)
        Me.lvBusquedaArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.lvBusquedaArticulo.Name = "lvBusquedaArticulo"
        Me.lvBusquedaArticulo.ShowItemToolTips = True
        Me.lvBusquedaArticulo.Size = New System.Drawing.Size(1709, 600)
        Me.lvBusquedaArticulo.TabIndex = 0
        Me.lvBusquedaArticulo.UseCompatibleStateImageBehavior = False
        Me.lvBusquedaArticulo.View = System.Windows.Forms.View.Details
        '
        'lvExtender
        '
        Me.lvExtender.Text = "+"
        Me.lvExtender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvExtender.Width = 20
        '
        'lvId
        '
        Me.lvId.Text = "ID"
        Me.lvId.Width = 100
        '
        'lvCodArticulo
        '
        Me.lvCodArticulo.Text = "COD.ARTÍCULO"
        Me.lvCodArticulo.Width = 200
        '
        'lvDoc
        '
        Me.lvDoc.Text = "DOCUMENTO"
        Me.lvDoc.Width = 100
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 450
        '
        'lvCliente
        '
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 450
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 180
        '
        'lvImporte
        '
        Me.lvImporte.Text = "IMPORTE"
        Me.lvImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporte.Width = 180
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsExportarExpandido, Me.BorraLineasSeleccionadasToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(247, 48)
        '
        'TsExportarExpandido
        '
        Me.TsExportarExpandido.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpandidoToolStripMenuItem, Me.SeleccionToolStripMenuItem, Me.TodoToolStripMenuItem})
        Me.TsExportarExpandido.Name = "TsExportarExpandido"
        Me.TsExportarExpandido.ShortcutKeyDisplayString = ""
        Me.TsExportarExpandido.Size = New System.Drawing.Size(246, 22)
        Me.TsExportarExpandido.Text = "Exportar a Excel"
        '
        'ExpandidoToolStripMenuItem
        '
        Me.ExpandidoToolStripMenuItem.Name = "ExpandidoToolStripMenuItem"
        Me.ExpandidoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ExpandidoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ExpandidoToolStripMenuItem.Text = "Desplegado"
        '
        'SeleccionToolStripMenuItem
        '
        Me.SeleccionToolStripMenuItem.Name = "SeleccionToolStripMenuItem"
        Me.SeleccionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SeleccionToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SeleccionToolStripMenuItem.Text = "Seleccionado"
        '
        'TodoToolStripMenuItem
        '
        Me.TodoToolStripMenuItem.Name = "TodoToolStripMenuItem"
        Me.TodoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.TodoToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.TodoToolStripMenuItem.Text = "Todo"
        '
        'BorraLineasSeleccionadasToolStripMenuItem
        '
        Me.BorraLineasSeleccionadasToolStripMenuItem.Name = "BorraLineasSeleccionadasToolStripMenuItem"
        Me.BorraLineasSeleccionadasToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.BorraLineasSeleccionadasToolStripMenuItem.Size = New System.Drawing.Size(246, 22)
        Me.BorraLineasSeleccionadasToolStripMenuItem.Text = "Borrar líneas seleccionadas"
        '
        'cbTipoDoc
        '
        Me.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoDoc.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbTipoDoc.FormattingEnabled = True
        Me.cbTipoDoc.Items.AddRange(New Object() {"ALBARANES", "FACTURAS", "PEDIDOS"})
        Me.cbTipoDoc.Location = New System.Drawing.Point(148, 26)
        Me.cbTipoDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipoDoc.Name = "cbTipoDoc"
        Me.cbTipoDoc.Size = New System.Drawing.Size(150, 25)
        Me.cbTipoDoc.Sorted = True
        Me.cbTipoDoc.TabIndex = 0
        '
        'gbCriterios
        '
        Me.gbCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCriterios.Controls.Add(Me.gbCheckbox)
        Me.gbCriterios.Controls.Add(Me.GroupBox2)
        Me.gbCriterios.Controls.Add(Me.GroupBox1)
        Me.gbCriterios.Controls.Add(Me.txID)
        Me.gbCriterios.Controls.Add(Me.Label4)
        Me.gbCriterios.Controls.Add(Me.dtpHasta)
        Me.gbCriterios.Controls.Add(Me.Label3)
        Me.gbCriterios.Controls.Add(Me.dtpDesde)
        Me.gbCriterios.Controls.Add(Me.Label13)
        Me.gbCriterios.Controls.Add(Me.Label1)
        Me.gbCriterios.Controls.Add(Me.cbTipoDoc)
        Me.gbCriterios.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCriterios.Location = New System.Drawing.Point(16, 95)
        Me.gbCriterios.Name = "gbCriterios"
        Me.gbCriterios.Size = New System.Drawing.Size(1709, 143)
        Me.gbCriterios.TabIndex = 0
        Me.gbCriterios.TabStop = False
        Me.gbCriterios.Text = "CRITERIOS DE BÚSQUEDA"
        '
        'gbCheckbox
        '
        Me.gbCheckbox.Controls.Add(Me.ckPendiente)
        Me.gbCheckbox.Controls.Add(Me.ckServido)
        Me.gbCheckbox.Controls.Add(Me.ckProduccion)
        Me.gbCheckbox.Controls.Add(Me.ckProducido)
        Me.gbCheckbox.Controls.Add(Me.ckParcial)
        Me.gbCheckbox.Controls.Add(Me.ckPreparado)
        Me.gbCheckbox.Enabled = False
        Me.gbCheckbox.Location = New System.Drawing.Point(800, 15)
        Me.gbCheckbox.Name = "gbCheckbox"
        Me.gbCheckbox.Size = New System.Drawing.Size(626, 36)
        Me.gbCheckbox.TabIndex = 130
        Me.gbCheckbox.TabStop = False
        '
        'ckServido
        '
        Me.ckServido.AutoSize = True
        Me.ckServido.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckServido.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckServido.Location = New System.Drawing.Point(444, 12)
        Me.ckServido.Name = "ckServido"
        Me.ckServido.Size = New System.Drawing.Size(81, 21)
        Me.ckServido.TabIndex = 210
        Me.ckServido.Text = "SERVIDO"
        Me.ckServido.UseVisualStyleBackColor = True
        '
        'ckProduccion
        '
        Me.ckProduccion.AutoSize = True
        Me.ckProduccion.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckProduccion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckProduccion.Location = New System.Drawing.Point(9, 12)
        Me.ckProduccion.Name = "ckProduccion"
        Me.ckProduccion.Size = New System.Drawing.Size(118, 21)
        Me.ckProduccion.TabIndex = 130
        Me.ckProduccion.Text = "PRODUCCIÓN"
        Me.ckProduccion.UseVisualStyleBackColor = True
        '
        'ckProducido
        '
        Me.ckProducido.AutoSize = True
        Me.ckProducido.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckProducido.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckProducido.Location = New System.Drawing.Point(133, 12)
        Me.ckProducido.Name = "ckProducido"
        Me.ckProducido.Size = New System.Drawing.Size(107, 21)
        Me.ckProducido.TabIndex = 131
        Me.ckProducido.Text = "PRODUCIDO"
        Me.ckProducido.UseVisualStyleBackColor = True
        '
        'ckParcial
        '
        Me.ckParcial.AutoSize = True
        Me.ckParcial.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckParcial.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckParcial.Location = New System.Drawing.Point(357, 12)
        Me.ckParcial.Name = "ckParcial"
        Me.ckParcial.Size = New System.Drawing.Size(81, 21)
        Me.ckParcial.TabIndex = 133
        Me.ckParcial.Text = "PARCIAL"
        Me.ckParcial.UseVisualStyleBackColor = True
        '
        'ckPreparado
        '
        Me.ckPreparado.AutoSize = True
        Me.ckPreparado.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckPreparado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPreparado.Location = New System.Drawing.Point(246, 12)
        Me.ckPreparado.Name = "ckPreparado"
        Me.ckPreparado.Size = New System.Drawing.Size(105, 21)
        Me.ckPreparado.TabIndex = 132
        Me.ckPreparado.Text = "PREPARADO"
        Me.ckPreparado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txCodigo3not)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txCodigo2not)
        Me.GroupBox2.Controls.Add(Me.txArticulo1not)
        Me.GroupBox2.Controls.Add(Me.txCodigo1not)
        Me.GroupBox2.Controls.Add(Me.txArticulo2not)
        Me.GroupBox2.Controls.Add(Me.txArticulo3not)
        Me.GroupBox2.Location = New System.Drawing.Point(664, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(614, 81)
        Me.GroupBox2.TabIndex = 129
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EXCLUYE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 17)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "COD.ARTICULO"
        '
        'txCodigo3not
        '
        Me.txCodigo3not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo3not.Location = New System.Drawing.Point(448, 19)
        Me.txCodigo3not.MaxLength = 15
        Me.txCodigo3not.Name = "txCodigo3not"
        Me.txCodigo3not.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo3not.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(6, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 17)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "ARTÍCULO"
        '
        'txCodigo2not
        '
        Me.txCodigo2not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo2not.Location = New System.Drawing.Point(292, 19)
        Me.txCodigo2not.MaxLength = 15
        Me.txCodigo2not.Name = "txCodigo2not"
        Me.txCodigo2not.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo2not.TabIndex = 1
        '
        'txArticulo1not
        '
        Me.txArticulo1not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo1not.Location = New System.Drawing.Point(136, 48)
        Me.txArticulo1not.MaxLength = 15
        Me.txArticulo1not.Name = "txArticulo1not"
        Me.txArticulo1not.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo1not.TabIndex = 3
        '
        'txCodigo1not
        '
        Me.txCodigo1not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo1not.Location = New System.Drawing.Point(136, 19)
        Me.txCodigo1not.MaxLength = 15
        Me.txCodigo1not.Name = "txCodigo1not"
        Me.txCodigo1not.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo1not.TabIndex = 0
        '
        'txArticulo2not
        '
        Me.txArticulo2not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo2not.Location = New System.Drawing.Point(292, 48)
        Me.txArticulo2not.MaxLength = 15
        Me.txArticulo2not.Name = "txArticulo2not"
        Me.txArticulo2not.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo2not.TabIndex = 4
        '
        'txArticulo3not
        '
        Me.txArticulo3not.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo3not.Location = New System.Drawing.Point(448, 48)
        Me.txArticulo3not.MaxLength = 15
        Me.txArticulo3not.Name = "txArticulo3not"
        Me.txArticulo3not.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo3not.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txCodigo3)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.txCodigo2)
        Me.GroupBox1.Controls.Add(Me.txArticulo1)
        Me.GroupBox1.Controls.Add(Me.txCodigo1)
        Me.GroupBox1.Controls.Add(Me.txArticulo2)
        Me.GroupBox1.Controls.Add(Me.txArticulo3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(614, 81)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INCLUYE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "COD.ARTICULO"
        '
        'txCodigo3
        '
        Me.txCodigo3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo3.Location = New System.Drawing.Point(448, 19)
        Me.txCodigo3.MaxLength = 15
        Me.txCodigo3.Name = "txCodigo3"
        Me.txCodigo3.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo3.TabIndex = 2
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(6, 51)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(69, 17)
        Me.Label42.TabIndex = 104
        Me.Label42.Text = "ARTÍCULO"
        '
        'txCodigo2
        '
        Me.txCodigo2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo2.Location = New System.Drawing.Point(292, 19)
        Me.txCodigo2.MaxLength = 15
        Me.txCodigo2.Name = "txCodigo2"
        Me.txCodigo2.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo2.TabIndex = 1
        '
        'txArticulo1
        '
        Me.txArticulo1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo1.Location = New System.Drawing.Point(136, 48)
        Me.txArticulo1.MaxLength = 15
        Me.txArticulo1.Name = "txArticulo1"
        Me.txArticulo1.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo1.TabIndex = 3
        '
        'txCodigo1
        '
        Me.txCodigo1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodigo1.Location = New System.Drawing.Point(136, 19)
        Me.txCodigo1.MaxLength = 15
        Me.txCodigo1.Name = "txCodigo1"
        Me.txCodigo1.Size = New System.Drawing.Size(150, 23)
        Me.txCodigo1.TabIndex = 0
        '
        'txArticulo2
        '
        Me.txArticulo2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo2.Location = New System.Drawing.Point(292, 48)
        Me.txArticulo2.MaxLength = 15
        Me.txArticulo2.Name = "txArticulo2"
        Me.txArticulo2.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo2.TabIndex = 4
        '
        'txArticulo3
        '
        Me.txArticulo3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo3.Location = New System.Drawing.Point(448, 48)
        Me.txArticulo3.MaxLength = 15
        Me.txArticulo3.Name = "txArticulo3"
        Me.txArticulo3.Size = New System.Drawing.Size(150, 23)
        Me.txArticulo3.TabIndex = 5
        '
        'txID
        '
        Me.txID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txID.Location = New System.Drawing.Point(718, 27)
        Me.txID.MaxLength = 15
        Me.txID.Name = "txID"
        Me.txID.Size = New System.Drawing.Size(67, 23)
        Me.txID.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(661, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "ID ART."
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(509, 26)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(101, 23)
        Me.dtpHasta.TabIndex = 2
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(460, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "HASTA"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(355, 27)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(99, 23)
        Me.dtpDesde.TabIndex = 1
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(305, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "DESDE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(18, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 17)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "TIPO DOCUMENTO"
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(1549, 26)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 4
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(1640, 26)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(1458, 26)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 3
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'txTotalCantidad
        '
        Me.txTotalCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalCantidad.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txTotalCantidad.Location = New System.Drawing.Point(1346, 852)
        Me.txTotalCantidad.MaxLength = 15
        Me.txTotalCantidad.Name = "txTotalCantidad"
        Me.txTotalCantidad.Size = New System.Drawing.Size(125, 25)
        Me.txTotalCantidad.TabIndex = 7
        Me.txTotalCantidad.TabStop = False
        Me.txTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(1208, 855)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 18)
        Me.Label6.TabIndex = 206
        Me.Label6.Text = "TOTAL CANTIDAD"
        '
        'txTotalEncontrados
        '
        Me.txTotalEncontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalEncontrados.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txTotalEncontrados.Location = New System.Drawing.Point(1077, 852)
        Me.txTotalEncontrados.MaxLength = 15
        Me.txTotalEncontrados.Name = "txTotalEncontrados"
        Me.txTotalEncontrados.Size = New System.Drawing.Size(125, 25)
        Me.txTotalEncontrados.TabIndex = 6
        Me.txTotalEncontrados.TabStop = False
        Me.txTotalEncontrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(903, 855)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 18)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "TOTAL ENCONTRADOS"
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(1367, 26)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(85, 50)
        Me.bBuscar.TabIndex = 2
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'txTotalImporte
        '
        Me.txTotalImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalImporte.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txTotalImporte.Location = New System.Drawing.Point(1600, 852)
        Me.txTotalImporte.MaxLength = 15
        Me.txTotalImporte.Name = "txTotalImporte"
        Me.txTotalImporte.Size = New System.Drawing.Size(125, 25)
        Me.txTotalImporte.TabIndex = 8
        Me.txTotalImporte.TabStop = False
        Me.txTotalImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(1479, 855)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 18)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "TOTAL IMPORTE"
        '
        'ckActivarSeleccion
        '
        Me.ckActivarSeleccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckActivarSeleccion.AutoSize = True
        Me.ckActivarSeleccion.Location = New System.Drawing.Point(16, 852)
        Me.ckActivarSeleccion.Name = "ckActivarSeleccion"
        Me.ckActivarSeleccion.Size = New System.Drawing.Size(157, 21)
        Me.ckActivarSeleccion.TabIndex = 1
        Me.ckActivarSeleccion.Text = "ACTIVAR SELECCIÓN"
        Me.ckActivarSeleccion.UseVisualStyleBackColor = True
        Me.ckActivarSeleccion.Visible = False
        '
        'ckPendiente
        '
        Me.ckPendiente.AutoSize = True
        Me.ckPendiente.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckPendiente.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPendiente.Location = New System.Drawing.Point(531, 13)
        Me.ckPendiente.Name = "ckPendiente"
        Me.ckPendiente.Size = New System.Drawing.Size(94, 21)
        Me.ckPendiente.TabIndex = 211
        Me.ckPendiente.Text = "PENDIENTE"
        Me.ckPendiente.UseVisualStyleBackColor = True
        '
        'busquedalibreArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1743, 881)
        Me.Controls.Add(Me.ckActivarSeleccion)
        Me.Controls.Add(Me.txTotalImporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txTotalCantidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txTotalEncontrados)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.gbCriterios)
        Me.Controls.Add(Me.lvBusquedaArticulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "busquedalibreArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA LIBRE"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gbCriterios.ResumeLayout(False)
        Me.gbCriterios.PerformLayout()
        Me.gbCheckbox.ResumeLayout(False)
        Me.gbCheckbox.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvBusquedaArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvId As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents gbCriterios As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txArticulo3 As System.Windows.Forms.TextBox
    Friend WithEvents txArticulo2 As System.Windows.Forms.TextBox
    Friend WithEvents txArticulo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txCodigo3 As System.Windows.Forms.TextBox
    Friend WithEvents txCodigo2 As System.Windows.Forms.TextBox
    Friend WithEvents txCodigo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents txTotalCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txTotalEncontrados As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents lvExtender As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TsExportarExpandido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporte As System.Windows.Forms.ColumnHeader
    Friend WithEvents txTotalImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivarSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents ExpandidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txCodigo3not As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txCodigo2not As System.Windows.Forms.TextBox
    Friend WithEvents txArticulo1not As System.Windows.Forms.TextBox
    Friend WithEvents txCodigo1not As System.Windows.Forms.TextBox
    Friend WithEvents txArticulo2not As System.Windows.Forms.TextBox
    Friend WithEvents txArticulo3not As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BorraLineasSeleccionadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ckProduccion As System.Windows.Forms.CheckBox
    Friend WithEvents ckParcial As System.Windows.Forms.CheckBox
    Friend WithEvents ckPreparado As System.Windows.Forms.CheckBox
    Friend WithEvents ckProducido As System.Windows.Forms.CheckBox
    Friend WithEvents ckServido As System.Windows.Forms.CheckBox
    Friend WithEvents gbCheckbox As System.Windows.Forms.GroupBox
    Friend WithEvents ckPendiente As System.Windows.Forms.CheckBox
End Class
