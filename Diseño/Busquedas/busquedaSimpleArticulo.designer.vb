<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaSimpleArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaSimpleArticulo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckInactivos = New System.Windows.Forms.CheckBox
        Me.lbBuscando = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.ckEscandallo = New System.Windows.Forms.CheckBox
        Me.ckOpcion = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ckVendible = New System.Windows.Forms.CheckBox
        Me.ckSubEnsamblado = New System.Windows.Forms.CheckBox
        Me.ckComprable = New System.Windows.Forms.CheckBox
        Me.ckMateriaPrima = New System.Windows.Forms.CheckBox
        Me.cbAlmacen = New System.Windows.Forms.ComboBox
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbSeccion = New System.Windows.Forms.ComboBox
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.lbTipo = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.lvArticulos = New System.Windows.Forms.ListView
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvSeccion = New System.Windows.Forms.ColumnHeader
        Me.lvTipoCompra = New System.Windows.Forms.ColumnHeader
        Me.lvTipo = New System.Windows.Forms.ColumnHeader
        Me.lvSubTipo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvPVP = New System.Windows.Forms.ColumnHeader
        Me.lvStock = New System.Windows.Forms.ColumnHeader
        Me.lvidArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvObservaciones = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubfamilia = New System.Windows.Forms.ColumnHeader
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bBuscar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckInactivos)
        Me.GroupBox1.Controls.Add(Me.lbBuscando)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Descripcion)
        Me.GroupBox1.Controls.Add(Me.ckEscandallo)
        Me.GroupBox1.Controls.Add(Me.ckOpcion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ckVendible)
        Me.GroupBox1.Controls.Add(Me.ckSubEnsamblado)
        Me.GroupBox1.Controls.Add(Me.ckComprable)
        Me.GroupBox1.Controls.Add(Me.ckMateriaPrima)
        Me.GroupBox1.Controls.Add(Me.cbAlmacen)
        Me.GroupBox1.Controls.Add(Me.Observaciones)
        Me.GroupBox1.Controls.Add(Me.Articulo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbSeccion)
        Me.GroupBox1.Controls.Add(Me.cbSubTipo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbSubTipo)
        Me.GroupBox1.Controls.Add(Me.codArticulo)
        Me.GroupBox1.Controls.Add(Me.cbTipo)
        Me.GroupBox1.Controls.Add(Me.lbTipo)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1299, 137)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'ckInactivos
        '
        Me.ckInactivos.AutoSize = True
        Me.ckInactivos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInactivos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckInactivos.Location = New System.Drawing.Point(963, 113)
        Me.ckInactivos.Name = "ckInactivos"
        Me.ckInactivos.Size = New System.Drawing.Size(94, 21)
        Me.ckInactivos.TabIndex = 165
        Me.ckInactivos.Text = "INACTIVOS"
        Me.ckInactivos.UseVisualStyleBackColor = True
        '
        'lbBuscando
        '
        Me.lbBuscando.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBuscando.ForeColor = System.Drawing.Color.Red
        Me.lbBuscando.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbBuscando.Location = New System.Drawing.Point(1010, 113)
        Me.lbBuscando.Name = "lbBuscando"
        Me.lbBuscando.Size = New System.Drawing.Size(283, 17)
        Me.lbBuscando.TabIndex = 164
        Me.lbBuscando.Text = "BUSCANDO, ESPERA POR FAVOR"
        Me.lbBuscando.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lbBuscando.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(6, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "DESCRIPCIÓN"
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(125, 82)
        Me.Descripcion.MaxLength = 100
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(443, 23)
        Me.Descripcion.TabIndex = 7
        '
        'ckEscandallo
        '
        Me.ckEscandallo.AutoSize = True
        Me.ckEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckEscandallo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckEscandallo.Location = New System.Drawing.Point(591, 54)
        Me.ckEscandallo.Name = "ckEscandallo"
        Me.ckEscandallo.Size = New System.Drawing.Size(112, 21)
        Me.ckEscandallo.TabIndex = 5
        Me.ckEscandallo.Text = "ESCANDALLO"
        Me.ckEscandallo.UseVisualStyleBackColor = True
        '
        'ckOpcion
        '
        Me.ckOpcion.AutoSize = True
        Me.ckOpcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckOpcion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckOpcion.Location = New System.Drawing.Point(591, 113)
        Me.ckOpcion.Name = "ckOpcion"
        Me.ckOpcion.Size = New System.Drawing.Size(81, 21)
        Me.ckOpcion.TabIndex = 11
        Me.ckOpcion.Text = "OPCIÓN"
        Me.ckOpcion.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(278, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "ALMACÉN"
        '
        'ckVendible
        '
        Me.ckVendible.AutoSize = True
        Me.ckVendible.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVendible.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVendible.Location = New System.Drawing.Point(871, 112)
        Me.ckVendible.Name = "ckVendible"
        Me.ckVendible.Size = New System.Drawing.Size(86, 21)
        Me.ckVendible.TabIndex = 13
        Me.ckVendible.Text = "VENDIBLE"
        Me.ckVendible.UseVisualStyleBackColor = True
        '
        'ckSubEnsamblado
        '
        Me.ckSubEnsamblado.AutoSize = True
        Me.ckSubEnsamblado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSubEnsamblado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSubEnsamblado.Location = New System.Drawing.Point(591, 83)
        Me.ckSubEnsamblado.Name = "ckSubEnsamblado"
        Me.ckSubEnsamblado.Size = New System.Drawing.Size(107, 21)
        Me.ckSubEnsamblado.TabIndex = 8
        Me.ckSubEnsamblado.Text = "SUBMONTAJE"
        Me.ckSubEnsamblado.UseVisualStyleBackColor = True
        '
        'ckComprable
        '
        Me.ckComprable.AutoSize = True
        Me.ckComprable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckComprable.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckComprable.Location = New System.Drawing.Point(743, 112)
        Me.ckComprable.Name = "ckComprable"
        Me.ckComprable.Size = New System.Drawing.Size(105, 21)
        Me.ckComprable.TabIndex = 12
        Me.ckComprable.Text = "COMPRABLE"
        Me.ckComprable.UseVisualStyleBackColor = True
        '
        'ckMateriaPrima
        '
        Me.ckMateriaPrima.AutoSize = True
        Me.ckMateriaPrima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckMateriaPrima.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckMateriaPrima.Location = New System.Drawing.Point(591, 25)
        Me.ckMateriaPrima.Name = "ckMateriaPrima"
        Me.ckMateriaPrima.Size = New System.Drawing.Size(122, 21)
        Me.ckMateriaPrima.TabIndex = 1
        Me.ckMateriaPrima.Text = "MATERIA PRIMA"
        Me.ckMateriaPrima.UseVisualStyleBackColor = True
        '
        'cbAlmacen
        '
        Me.cbAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(354, 51)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(213, 25)
        Me.cbAlmacen.TabIndex = 4
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(125, 111)
        Me.Observaciones.MaxLength = 100
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(442, 23)
        Me.Observaciones.TabIndex = 10
        '
        'Articulo
        '
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(125, 23)
        Me.Articulo.MaxLength = 100
        Me.Articulo.Name = "Articulo"
        Me.Articulo.Size = New System.Drawing.Size(442, 23)
        Me.Articulo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "OBSERVACIONES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "NOMBRE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "CÓDIGO"
        '
        'cbSeccion
        '
        Me.cbSeccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeccion.FormattingEnabled = True
        Me.cbSeccion.Location = New System.Drawing.Point(871, 81)
        Me.cbSeccion.Name = "cbSeccion"
        Me.cbSeccion.Size = New System.Drawing.Size(171, 25)
        Me.cbSeccion.TabIndex = 9
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(871, 52)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(171, 25)
        Me.cbSubTipo.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(743, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "SECCIÓN"
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(743, 55)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(56, 17)
        Me.lbSubTipo.TabIndex = 5
        Me.lbSubTipo.Text = "SUBTIPO"
        '
        'codArticulo
        '
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(125, 52)
        Me.codArticulo.MaxLength = 50
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.Size = New System.Drawing.Size(147, 23)
        Me.codArticulo.TabIndex = 3
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(871, 23)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(171, 25)
        Me.cbTipo.TabIndex = 2
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(743, 26)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 129
        Me.lbTipo.Text = "TIPO"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1223, 32)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(1132, 32)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 3
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'lvArticulos
        '
        Me.lvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvArticulos.CheckBoxes = True
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticulo, Me.lvcodArticulo, Me.lvSeccion, Me.lvTipoCompra, Me.lvTipo, Me.lvSubTipo, Me.lvArticulo, Me.lvPVP, Me.lvStock, Me.lvidArticuloProv, Me.lvcodArticuloProv, Me.lvObservaciones, Me.lvFamilia, Me.lvSubfamilia})
        Me.lvArticulos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.Location = New System.Drawing.Point(11, 249)
        Me.lvArticulos.MultiSelect = False
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.ShowItemToolTips = True
        Me.lvArticulos.Size = New System.Drawing.Size(1299, 489)
        Me.lvArticulos.TabIndex = 1
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "ID "
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 78
        '
        'lvSeccion
        '
        Me.lvSeccion.Text = "SECCIÓN"
        Me.lvSeccion.Width = 92
        '
        'lvTipoCompra
        '
        Me.lvTipoCompra.Text = "TIPO"
        Me.lvTipoCompra.Width = 0
        '
        'lvTipo
        '
        Me.lvTipo.Text = "TIPO"
        Me.lvTipo.Width = 128
        '
        'lvSubTipo
        '
        Me.lvSubTipo.Text = "SUBTIPO"
        Me.lvSubTipo.Width = 126
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 300
        '
        'lvPVP
        '
        Me.lvPVP.Text = "PVP"
        Me.lvPVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPVP.Width = 0
        '
        'lvStock
        '
        Me.lvStock.Text = "STOCK"
        Me.lvStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvStock.Width = 95
        '
        'lvidArticuloProv
        '
        Me.lvidArticuloProv.Text = "idArticuloProv"
        Me.lvidArticuloProv.Width = 0
        '
        'lvcodArticuloProv
        '
        Me.lvcodArticuloProv.Text = "COD.PROV"
        Me.lvcodArticuloProv.Width = 0
        '
        'lvObservaciones
        '
        Me.lvObservaciones.Text = "OBSERVACIONES"
        Me.lvObservaciones.Width = 150
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "FAMILIA"
        Me.lvFamilia.Width = 150
        '
        'lvSubfamilia
        '
        Me.lvSubfamilia.Text = "SUBFAMILIA"
        Me.lvSubfamilia.Width = 150
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1041, 32)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(28, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(1251, 744)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 107
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1141, 747)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "ENCONTRADOS"
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(950, 32)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(85, 50)
        Me.bBuscar.TabIndex = 139
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'BusquedaSimpleArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 774)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvArticulos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(309, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaSimpleArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE ARTÍCULOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lvArticulos As System.Windows.Forms.ListView
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipoCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvPVP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents ckMateriaPrima As System.Windows.Forms.CheckBox
    Friend WithEvents cbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckOpcion As System.Windows.Forms.CheckBox
    Friend WithEvents ckEscandallo As System.Windows.Forms.CheckBox
    Friend WithEvents ckSubEnsamblado As System.Windows.Forms.CheckBox
    Friend WithEvents ckComprable As System.Windows.Forms.CheckBox
    Friend WithEvents ckVendible As System.Windows.Forms.CheckBox
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents lvFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubfamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents lbBuscando As System.Windows.Forms.Label
    Friend WithEvents ckInactivos As System.Windows.Forms.CheckBox
End Class
