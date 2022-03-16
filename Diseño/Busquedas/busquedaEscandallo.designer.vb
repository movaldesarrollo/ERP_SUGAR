<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaEscandallo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaEscandallo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.ckBajas = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.cbVersion = New System.Windows.Forms.ComboBox
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbcodArticuloC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbArticuloC = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbTipoEscandallo = New System.Windows.Forms.ComboBox
        Me.lbTipo = New System.Windows.Forms.Label
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.lvEscandallos = New System.Windows.Forms.ListView
        Me.lvCheck = New System.Windows.Forms.ColumnHeader
        Me.lvidEscandallo = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvNombre = New System.Windows.Forms.ColumnHeader
        Me.lvCoste = New System.Windows.Forms.ColumnHeader
        Me.lvContador = New System.Windows.Forms.ColumnHeader
        Me.lvVersion = New System.Windows.Forms.ColumnHeader
        Me.lvVersionBase = New System.Windows.Forms.ColumnHeader
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pbCargando = New System.Windows.Forms.ProgressBar
        Me.bBuscar = New System.Windows.Forms.Button
        Me.ckTodos = New System.Windows.Forms.CheckBox
        Me.bExcel = New System.Windows.Forms.Button
        Me.seleccionarCarpera = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSubTipo)
        Me.GroupBox1.Controls.Add(Me.ckBajas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbSubTipo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.codArticulo)
        Me.GroupBox1.Controls.Add(Me.cbVersion)
        Me.GroupBox1.Controls.Add(Me.cbTipo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbcodArticuloC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbArticuloC)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbTipoEscandallo)
        Me.GroupBox1.Controls.Add(Me.lbTipo)
        Me.GroupBox1.Controls.Add(Me.Articulo)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(835, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(636, 51)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(190, 25)
        Me.cbSubTipo.Sorted = True
        Me.cbSubTipo.TabIndex = 5
        '
        'ckBajas
        '
        Me.ckBajas.AutoSize = True
        Me.ckBajas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckBajas.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckBajas.Location = New System.Drawing.Point(704, 140)
        Me.ckBajas.Name = "ckBajas"
        Me.ckBajas.Size = New System.Drawing.Size(122, 21)
        Me.ckBajas.TabIndex = 8
        Me.ckBajas.Text = "VER INACTIVOS"
        Me.ckBajas.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(7, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "NOMBRE"
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(509, 55)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(109, 17)
        Me.lbSubTipo.TabIndex = 139
        Me.lbSubTipo.Text = "SUBTIPO/FAMILIA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(7, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "CÓDIGO"
        '
        'codArticulo
        '
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(109, 24)
        Me.codArticulo.MaxLength = 50
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.Size = New System.Drawing.Size(127, 23)
        Me.codArticulo.TabIndex = 0
        '
        'cbVersion
        '
        Me.cbVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVersion.FormattingEnabled = True
        Me.cbVersion.Location = New System.Drawing.Point(109, 79)
        Me.cbVersion.Name = "cbVersion"
        Me.cbVersion.Size = New System.Drawing.Size(127, 25)
        Me.cbVersion.Sorted = True
        Me.cbVersion.TabIndex = 2
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(636, 22)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(190, 25)
        Me.cbTipo.Sorted = True
        Me.cbTipo.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(509, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "TIPO/FAMILIA"
        '
        'cbcodArticuloC
        '
        Me.cbcodArticuloC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticuloC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbcodArticuloC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodArticuloC.FormattingEnabled = True
        Me.cbcodArticuloC.Location = New System.Drawing.Point(109, 109)
        Me.cbcodArticuloC.Name = "cbcodArticuloC"
        Me.cbcodArticuloC.Size = New System.Drawing.Size(127, 25)
        Me.cbcodArticuloC.Sorted = True
        Me.cbcodArticuloC.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(7, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "VERSIÓN"
        '
        'cbArticuloC
        '
        Me.cbArticuloC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbArticuloC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbArticuloC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticuloC.FormattingEnabled = True
        Me.cbArticuloC.Location = New System.Drawing.Point(242, 109)
        Me.cbArticuloC.Name = "cbArticuloC"
        Me.cbArticuloC.Size = New System.Drawing.Size(584, 25)
        Me.cbArticuloC.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(7, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "COMPONENTE"
        '
        'cbTipoEscandallo
        '
        Me.cbTipoEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoEscandallo.FormattingEnabled = True
        Me.cbTipoEscandallo.Location = New System.Drawing.Point(636, 79)
        Me.cbTipoEscandallo.Name = "cbTipoEscandallo"
        Me.cbTipoEscandallo.Size = New System.Drawing.Size(190, 25)
        Me.cbTipoEscandallo.TabIndex = 6
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(509, 83)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(124, 17)
        Me.lbTipo.TabIndex = 129
        Me.lbTipo.Text = "TIPO ESCANDALLO"
        '
        'Articulo
        '
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(109, 52)
        Me.Articulo.MaxLength = 300
        Me.Articulo.Name = "Articulo"
        Me.Articulo.Size = New System.Drawing.Size(376, 23)
        Me.Articulo.TabIndex = 1
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(752, 27)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(476, 27)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 3
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(660, 27)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'lvEscandallos
        '
        Me.lvEscandallos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEscandallos.CheckBoxes = True
        Me.lvEscandallos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCheck, Me.lvidEscandallo, Me.lvidArticulo, Me.lvcodArticulo, Me.lvNombre, Me.lvCoste, Me.lvContador, Me.lvVersion, Me.lvVersionBase})
        Me.lvEscandallos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEscandallos.FullRowSelect = True
        Me.lvEscandallos.GridLines = True
        Me.lvEscandallos.Location = New System.Drawing.Point(11, 277)
        Me.lvEscandallos.MultiSelect = False
        Me.lvEscandallos.Name = "lvEscandallos"
        Me.lvEscandallos.ShowItemToolTips = True
        Me.lvEscandallos.Size = New System.Drawing.Size(835, 546)
        Me.lvEscandallos.TabIndex = 1
        Me.lvEscandallos.UseCompatibleStateImageBehavior = False
        Me.lvEscandallos.View = System.Windows.Forms.View.Details
        '
        'lvCheck
        '
        Me.lvCheck.Text = ""
        Me.lvCheck.Width = 20
        '
        'lvidEscandallo
        '
        Me.lvidEscandallo.Text = "idEscandallo"
        Me.lvidEscandallo.Width = 0
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "ID "
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CODIGO"
        Me.lvcodArticulo.Width = 138
        '
        'lvNombre
        '
        Me.lvNombre.Text = "ARTÍCULO"
        Me.lvNombre.Width = 431
        '
        'lvCoste
        '
        Me.lvCoste.Text = "COSTE"
        Me.lvCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCoste.Width = 100
        '
        'lvContador
        '
        Me.lvContador.Text = "COMP."
        Me.lvContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvContador.Width = 52
        '
        'lvVersion
        '
        Me.lvVersion.Text = "VERSIÓN"
        Me.lvVersion.Width = 65
        '
        'lvVersionBase
        '
        Me.lvVersionBase.Text = "VERSIÓN BASE"
        Me.lvVersionBase.Width = 0
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(568, 27)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 4
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(686, 829)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 6
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(574, 832)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "ENCONTRADOS"
        '
        'pbCargando
        '
        Me.pbCargando.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbCargando.Enabled = False
        Me.pbCargando.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbCargando.Location = New System.Drawing.Point(61, 828)
        Me.pbCargando.MarqueeAnimationSpeed = 1
        Me.pbCargando.Maximum = 1000
        Me.pbCargando.Name = "pbCargando"
        Me.pbCargando.Size = New System.Drawing.Size(100, 23)
        Me.pbCargando.Step = 0
        Me.pbCargando.TabIndex = 192
        Me.pbCargando.Visible = False
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(294, 27)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(85, 50)
        Me.bBuscar.TabIndex = 2
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'ckTodos
        '
        Me.ckTodos.AutoSize = True
        Me.ckTodos.Location = New System.Drawing.Point(17, 284)
        Me.ckTodos.Name = "ckTodos"
        Me.ckTodos.Size = New System.Drawing.Size(15, 14)
        Me.ckTodos.TabIndex = 193
        Me.ckTodos.UseVisualStyleBackColor = True
        Me.ckTodos.Visible = False
        '
        'bExcel
        '
        Me.bExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bExcel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bExcel.Image = Global.ERP_SUGAR.My.Resources.Resources.Excel_icon
        Me.bExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bExcel.Location = New System.Drawing.Point(385, 27)
        Me.bExcel.Name = "bExcel"
        Me.bExcel.Size = New System.Drawing.Size(85, 50)
        Me.bExcel.TabIndex = 194
        Me.bExcel.UseVisualStyleBackColor = True
        '
        'BusquedaEscandallo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 862)
        Me.Controls.Add(Me.bExcel)
        Me.Controls.Add(Me.ckTodos)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.pbCargando)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvEscandallos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(309, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaEscandallo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE ESCANDALLOS DE ARTÍCULOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipoEscandallo As System.Windows.Forms.ComboBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lvEscandallos As System.Windows.Forms.ListView
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCoste As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ckBajas As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbcodArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents lvCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvContador As System.Windows.Forms.ColumnHeader
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents cbVersion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pbCargando As System.Windows.Forms.ProgressBar
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents lvVersionBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckTodos As System.Windows.Forms.CheckBox
    Friend WithEvents bExcel As System.Windows.Forms.Button
    Friend WithEvents seleccionarCarpera As System.Windows.Forms.FolderBrowserDialog
End Class
