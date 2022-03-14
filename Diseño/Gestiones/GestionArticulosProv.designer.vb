<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionArticulosProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionArticulosProv))
        Me.bSalir = New System.Windows.Forms.Button
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.bverArticulo = New System.Windows.Forms.Button
        Me.lbMoneda = New System.Windows.Forms.Label
        Me.NombreProv = New System.Windows.Forms.TextBox
        Me.Precio = New System.Windows.Forms.TextBox
        Me.codArticuloProv = New System.Windows.Forms.TextBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcionProv = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvPrecio = New System.Windows.Forms.ColumnHeader
        Me.BBuscarProducto = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbSubFamilia = New System.Windows.Forms.ComboBox
        Me.cbFamilia = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbNombre = New System.Windows.Forms.ComboBox
        Me.cbcodArticulo = New System.Windows.Forms.ComboBox
        Me.bBorrarConcepto = New System.Windows.Forms.Button
        Me.bNuevoConcepto = New System.Windows.Forms.Button
        Me.bGuardarConcepto = New System.Windows.Forms.Button
        Me.BusquedaLibre = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.bImprimir = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.observacionesProv = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbAño = New System.Windows.Forms.Label
        Me.txAño = New System.Windows.Forms.TextBox
        Me.gbConceptos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1172, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'gbConceptos
        '
        Me.gbConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbConceptos.Controls.Add(Me.bverArticulo)
        Me.gbConceptos.Controls.Add(Me.lbMoneda)
        Me.gbConceptos.Controls.Add(Me.NombreProv)
        Me.gbConceptos.Controls.Add(Me.Precio)
        Me.gbConceptos.Controls.Add(Me.codArticuloProv)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.BBuscarProducto)
        Me.gbConceptos.Controls.Add(Me.Label2)
        Me.gbConceptos.Controls.Add(Me.Label1)
        Me.gbConceptos.Controls.Add(Me.Label34)
        Me.gbConceptos.Controls.Add(Me.Label13)
        Me.gbConceptos.Controls.Add(Me.cbSubFamilia)
        Me.gbConceptos.Controls.Add(Me.cbFamilia)
        Me.gbConceptos.Controls.Add(Me.Label9)
        Me.gbConceptos.Controls.Add(Me.Label8)
        Me.gbConceptos.Controls.Add(Me.Label12)
        Me.gbConceptos.Controls.Add(Me.cbNombre)
        Me.gbConceptos.Controls.Add(Me.cbcodArticulo)
        Me.gbConceptos.Location = New System.Drawing.Point(12, 177)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.Size = New System.Drawing.Size(1256, 590)
        Me.gbConceptos.TabIndex = 154
        Me.gbConceptos.TabStop = False
        '
        'bverArticulo
        '
        Me.bverArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bverArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bverArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bverArticulo.Location = New System.Drawing.Point(665, 46)
        Me.bverArticulo.Name = "bverArticulo"
        Me.bverArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bverArticulo.TabIndex = 163
        Me.bverArticulo.UseVisualStyleBackColor = True
        '
        'lbMoneda
        '
        Me.lbMoneda.AutoSize = True
        Me.lbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda.Location = New System.Drawing.Point(1209, 50)
        Me.lbMoneda.Name = "lbMoneda"
        Me.lbMoneda.Size = New System.Drawing.Size(15, 16)
        Me.lbMoneda.TabIndex = 162
        Me.lbMoneda.Text = "€"
        '
        'NombreProv
        '
        Me.NombreProv.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.NombreProv.Location = New System.Drawing.Point(799, 47)
        Me.NombreProv.MaxLength = 300
        Me.NombreProv.Name = "NombreProv"
        Me.NombreProv.Size = New System.Drawing.Size(328, 22)
        Me.NombreProv.TabIndex = 11
        '
        'Precio
        '
        Me.Precio.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Precio.Location = New System.Drawing.Point(1133, 47)
        Me.Precio.MaxLength = 50
        Me.Precio.Name = "Precio"
        Me.Precio.Size = New System.Drawing.Size(73, 22)
        Me.Precio.TabIndex = 12
        Me.Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'codArticuloProv
        '
        Me.codArticuloProv.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.codArticuloProv.Location = New System.Drawing.Point(700, 47)
        Me.codArticuloProv.MaxLength = 30
        Me.codArticuloProv.Name = "codArticuloProv"
        Me.codArticuloProv.Size = New System.Drawing.Size(93, 22)
        Me.codArticuloProv.TabIndex = 10
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticuloProv, Me.lvFamilia, Me.lvSubFamilia, Me.lvcodArticulo, Me.lvdescripcion, Me.lvcodArticuloProv, Me.lvDescripcionProv, Me.lvidArticulo, Me.lvPrecio})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(11, 85)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.Size = New System.Drawing.Size(1239, 487)
        Me.lvConceptos.TabIndex = 20
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidArticuloProv
        '
        Me.lvidArticuloProv.Text = "idArticuloProv"
        Me.lvidArticuloProv.Width = 0
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "FAMILIA"
        Me.lvFamilia.Width = 92
        '
        'lvSubFamilia
        '
        Me.lvSubFamilia.Text = "SUBFAMILIA"
        Me.lvSubFamilia.Width = 110
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CODIGO"
        Me.lvcodArticulo.Width = 101
        '
        'lvdescripcion
        '
        Me.lvdescripcion.Text = "DESCRIPCIÓN GENÉRICA"
        Me.lvdescripcion.Width = 345
        '
        'lvcodArticuloProv
        '
        Me.lvcodArticuloProv.Text = "COD. PROVEEDOR"
        Me.lvcodArticuloProv.Width = 124
        '
        'lvDescripcionProv
        '
        Me.lvDescripcionProv.Text = "DESCRIPCIÓN"
        Me.lvDescripcionProv.Width = 340
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvPrecio
        '
        Me.lvPrecio.Text = "PRECIO"
        Me.lvPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecio.Width = 82
        '
        'BBuscarProducto
        '
        Me.BBuscarProducto.Cursor = System.Windows.Forms.Cursors.Default
        Me.BBuscarProducto.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.BBuscarProducto.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.BBuscarProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BBuscarProducto.Location = New System.Drawing.Point(628, 46)
        Me.BBuscarProducto.Name = "BBuscarProducto"
        Me.BBuscarProducto.Size = New System.Drawing.Size(27, 25)
        Me.BBuscarProducto.TabIndex = 5
        Me.BBuscarProducto.TabStop = False
        Me.BBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(1136, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "PRECIO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(800, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "DESCRIPCIÓN"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(337, 23)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(149, 17)
        Me.Label34.TabIndex = 49
        Me.Label34.Text = "DESCRIPCIÓN GENÉRICA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(117, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 17)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "SUBFAMILIA"
        '
        'cbSubFamilia
        '
        Me.cbSubFamilia.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.cbSubFamilia.FormattingEnabled = True
        Me.cbSubFamilia.Location = New System.Drawing.Point(118, 46)
        Me.cbSubFamilia.Name = "cbSubFamilia"
        Me.cbSubFamilia.Size = New System.Drawing.Size(120, 25)
        Me.cbSubFamilia.TabIndex = 7
        '
        'cbFamilia
        '
        Me.cbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbFamilia.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.cbFamilia.FormattingEnabled = True
        Me.cbFamilia.Location = New System.Drawing.Point(14, 46)
        Me.cbFamilia.Name = "cbFamilia"
        Me.cbFamilia.Size = New System.Drawing.Size(98, 25)
        Me.cbFamilia.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(689, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 17)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "COD.PROVEEDOR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(243, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 17)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "CÓDIGO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(14, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 17)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "FAMILIA"
        '
        'cbNombre
        '
        Me.cbNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbNombre.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.cbNombre.FormattingEnabled = True
        Me.cbNombre.Location = New System.Drawing.Point(337, 46)
        Me.cbNombre.Name = "cbNombre"
        Me.cbNombre.Size = New System.Drawing.Size(285, 25)
        Me.cbNombre.TabIndex = 9
        '
        'cbcodArticulo
        '
        Me.cbcodArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbcodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.cbcodArticulo.FormattingEnabled = True
        Me.cbcodArticulo.Location = New System.Drawing.Point(244, 46)
        Me.cbcodArticulo.Name = "cbcodArticulo"
        Me.cbcodArticulo.Size = New System.Drawing.Size(87, 25)
        Me.cbcodArticulo.TabIndex = 8
        '
        'bBorrarConcepto
        '
        Me.bBorrarConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrarConcepto.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrarConcepto.Enabled = False
        Me.bBorrarConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarConcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrarConcepto.Location = New System.Drawing.Point(1069, 23)
        Me.bBorrarConcepto.Name = "bBorrarConcepto"
        Me.bBorrarConcepto.Size = New System.Drawing.Size(85, 50)
        Me.bBorrarConcepto.TabIndex = 17
        Me.bBorrarConcepto.TabStop = False
        Me.bBorrarConcepto.Text = "BORRAR"
        Me.bBorrarConcepto.UseVisualStyleBackColor = True
        '
        'bNuevoConcepto
        '
        Me.bNuevoConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevoConcepto.Cursor = System.Windows.Forms.Cursors.Default
        Me.bNuevoConcepto.Enabled = False
        Me.bNuevoConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoConcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoConcepto.Location = New System.Drawing.Point(863, 23)
        Me.bNuevoConcepto.Name = "bNuevoConcepto"
        Me.bNuevoConcepto.Size = New System.Drawing.Size(85, 50)
        Me.bNuevoConcepto.TabIndex = 16
        Me.bNuevoConcepto.TabStop = False
        Me.bNuevoConcepto.Text = "NUEVO"
        Me.bNuevoConcepto.UseVisualStyleBackColor = True
        '
        'bGuardarConcepto
        '
        Me.bGuardarConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardarConcepto.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarConcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarConcepto.Location = New System.Drawing.Point(760, 23)
        Me.bGuardarConcepto.Name = "bGuardarConcepto"
        Me.bGuardarConcepto.Size = New System.Drawing.Size(85, 50)
        Me.bGuardarConcepto.TabIndex = 15
        Me.bGuardarConcepto.Text = "GUARDAR"
        Me.bGuardarConcepto.UseVisualStyleBackColor = True
        '
        'BusquedaLibre
        '
        Me.BusquedaLibre.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.BusquedaLibre.Location = New System.Drawing.Point(138, 148)
        Me.BusquedaLibre.MaxLength = 50
        Me.BusquedaLibre.Name = "BusquedaLibre"
        Me.BusquedaLibre.Size = New System.Drawing.Size(189, 22)
        Me.BusquedaLibre.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(30, 117)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 18)
        Me.Label22.TabIndex = 157
        Me.Label22.Text = "PROVEEDOR"
        '
        'cbProveedor
        '
        Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(138, 114)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(405, 26)
        Me.cbProveedor.TabIndex = 1
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(966, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 4
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(580, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 17)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "OBSERVACIONES"
        '
        'observacionesProv
        '
        Me.observacionesProv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.observacionesProv.BackColor = System.Drawing.SystemColors.Window
        Me.observacionesProv.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.observacionesProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.observacionesProv.Location = New System.Drawing.Point(705, 114)
        Me.observacionesProv.MaxLength = 200
        Me.observacionesProv.Multiline = True
        Me.observacionesProv.Name = "observacionesProv"
        Me.observacionesProv.ReadOnly = True
        Me.observacionesProv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observacionesProv.Size = New System.Drawing.Size(556, 56)
        Me.observacionesProv.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(30, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 17)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "BÚSQUEDA"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 188
        Me.PictureBox1.TabStop = False
        '
        'lbAño
        '
        Me.lbAño.AutoSize = True
        Me.lbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAño.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbAño.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbAño.Location = New System.Drawing.Point(333, 150)
        Me.lbAño.Name = "lbAño"
        Me.lbAño.Size = New System.Drawing.Size(38, 17)
        Me.lbAño.TabIndex = 189
        Me.lbAño.Text = "AÑO"
        '
        'txAño
        '
        Me.txAño.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.txAño.Location = New System.Drawing.Point(377, 147)
        Me.txAño.MaxLength = 50
        Me.txAño.Name = "txAño"
        Me.txAño.Size = New System.Drawing.Size(166, 22)
        Me.txAño.TabIndex = 190
        '
        'GestionArticulosProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 778)
        Me.Controls.Add(Me.txAño)
        Me.Controls.Add(Me.lbAño)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bBorrarConcepto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bNuevoConcepto)
        Me.Controls.Add(Me.observacionesProv)
        Me.Controls.Add(Me.bGuardarConcepto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cbProveedor)
        Me.Controls.Add(Me.gbConceptos)
        Me.Controls.Add(Me.BusquedaLibre)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionArticulosProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNACIÓN DE ARTÍCULOS A PROVEEDOR"
        Me.gbConceptos.ResumeLayout(False)
        Me.gbConceptos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents gbConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents BBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbNombre As System.Windows.Forms.ComboBox
    Friend WithEvents cbcodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcionProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents NombreProv As System.Windows.Forms.TextBox
    Friend WithEvents codArticuloProv As System.Windows.Forms.TextBox
    Friend WithEvents bBorrarConcepto As System.Windows.Forms.Button
    Friend WithEvents bNuevoConcepto As System.Windows.Forms.Button
    Friend WithEvents bGuardarConcepto As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents observacionesProv As System.Windows.Forms.TextBox
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Precio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda As System.Windows.Forms.Label
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents BusquedaLibre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bverArticulo As System.Windows.Forms.Button
    Friend WithEvents lbAño As System.Windows.Forms.Label
    Friend WithEvents txAño As System.Windows.Forms.TextBox
End Class
