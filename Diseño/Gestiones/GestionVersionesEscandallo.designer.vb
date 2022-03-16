<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionVersionesEscandallo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionVersionesEscandallo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.ckBajas = New System.Windows.Forms.CheckBox
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.cbVersion = New System.Windows.Forms.ComboBox
        Me.cbcodArticuloC = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbArticuloC = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbTipoEscandallo = New System.Windows.Forms.ComboBox
        Me.lbTipo = New System.Windows.Forms.Label
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.NuevaVersion = New System.Windows.Forms.TextBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bCrearVersion = New System.Windows.Forms.Button
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
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bCambioMasivo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSubTipo)
        Me.GroupBox1.Controls.Add(Me.ckBajas)
        Me.GroupBox1.Controls.Add(Me.lbSubTipo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbTipo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.codArticulo)
        Me.GroupBox1.Controls.Add(Me.cbVersion)
        Me.GroupBox1.Controls.Add(Me.cbcodArticuloC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbArticuloC)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbTipoEscandallo)
        Me.GroupBox1.Controls.Add(Me.lbTipo)
        Me.GroupBox1.Controls.Add(Me.Articulo)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(740, 164)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(529, 50)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(200, 25)
        Me.cbSubTipo.Sorted = True
        Me.cbSubTipo.TabIndex = 3
        '
        'ckBajas
        '
        Me.ckBajas.AutoSize = True
        Me.ckBajas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckBajas.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckBajas.Location = New System.Drawing.Point(448, 138)
        Me.ckBajas.Name = "ckBajas"
        Me.ckBajas.Size = New System.Drawing.Size(282, 21)
        Me.ckBajas.TabIndex = 8
        Me.ckBajas.Text = "VER INACTIVOS Y VERSIONES ANTERIORES"
        Me.ckBajas.UseVisualStyleBackColor = True
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(419, 54)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(109, 17)
        Me.lbSubTipo.TabIndex = 139
        Me.lbSubTipo.Text = "SUBTIPO/FAMILIA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(8, 54)
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
        Me.Label3.Location = New System.Drawing.Point(8, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "CÓDIGO"
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(529, 22)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(200, 25)
        Me.cbTipo.Sorted = True
        Me.cbTipo.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(419, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "TIPO/FAMILIA"
        '
        'codArticulo
        '
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(109, 24)
        Me.codArticulo.MaxLength = 15
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
        Me.cbVersion.Location = New System.Drawing.Point(109, 78)
        Me.cbVersion.Name = "cbVersion"
        Me.cbVersion.Size = New System.Drawing.Size(127, 25)
        Me.cbVersion.Sorted = True
        Me.cbVersion.TabIndex = 4
        '
        'cbcodArticuloC
        '
        Me.cbcodArticuloC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticuloC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbcodArticuloC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodArticuloC.FormattingEnabled = True
        Me.cbcodArticuloC.Location = New System.Drawing.Point(109, 107)
        Me.cbcodArticuloC.Name = "cbcodArticuloC"
        Me.cbcodArticuloC.Size = New System.Drawing.Size(127, 25)
        Me.cbcodArticuloC.Sorted = True
        Me.cbcodArticuloC.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 82)
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
        Me.cbArticuloC.Location = New System.Drawing.Point(242, 107)
        Me.cbArticuloC.Name = "cbArticuloC"
        Me.cbArticuloC.Size = New System.Drawing.Size(487, 25)
        Me.cbArticuloC.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(8, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "COMPONENTE"
        '
        'cbTipoEscandallo
        '
        Me.cbTipoEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoEscandallo.FormattingEnabled = True
        Me.cbTipoEscandallo.Location = New System.Drawing.Point(529, 78)
        Me.cbTipoEscandallo.Name = "cbTipoEscandallo"
        Me.cbTipoEscandallo.Size = New System.Drawing.Size(200, 25)
        Me.cbTipoEscandallo.TabIndex = 5
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(395, 82)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(124, 17)
        Me.lbTipo.TabIndex = 129
        Me.lbTipo.Text = "TIPO ESCANDALLO"
        '
        'Articulo
        '
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(109, 51)
        Me.Articulo.MaxLength = 15
        Me.Articulo.Name = "Articulo"
        Me.Articulo.Size = New System.Drawing.Size(304, 23)
        Me.Articulo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(14, 283)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 130
        Me.Label4.Text = "NUEVA VERSIÓN"
        '
        'NuevaVersion
        '
        Me.NuevaVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuevaVersion.Location = New System.Drawing.Point(125, 280)
        Me.NuevaVersion.MaxLength = 15
        Me.NuevaVersion.Name = "NuevaVersion"
        Me.NuevaVersion.Size = New System.Drawing.Size(122, 23)
        Me.NuevaVersion.TabIndex = 2
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(669, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bCrearVersion
        '
        Me.bCrearVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCrearVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCrearVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCrearVersion.Location = New System.Drawing.Point(301, 23)
        Me.bCrearVersion.Name = "bCrearVersion"
        Me.bCrearVersion.Size = New System.Drawing.Size(85, 50)
        Me.bCrearVersion.TabIndex = 4
        Me.bCrearVersion.Text = "CREAR VERSIÓN"
        Me.bCrearVersion.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(577, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 6
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'lvEscandallos
        '
        Me.lvEscandallos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEscandallos.CheckBoxes = True
        Me.lvEscandallos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCheck, Me.lvidEscandallo, Me.lvidArticulo, Me.lvcodArticulo, Me.lvNombre, Me.lvCoste, Me.lvContador, Me.lvVersion})
        Me.lvEscandallos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEscandallos.FullRowSelect = True
        Me.lvEscandallos.GridLines = True
        Me.lvEscandallos.Location = New System.Drawing.Point(11, 317)
        Me.lvEscandallos.MultiSelect = False
        Me.lvEscandallos.Name = "lvEscandallos"
        Me.lvEscandallos.ShowItemToolTips = True
        Me.lvEscandallos.Size = New System.Drawing.Size(740, 422)
        Me.lvEscandallos.TabIndex = 0
        Me.lvEscandallos.UseCompatibleStateImageBehavior = False
        Me.lvEscandallos.View = System.Windows.Forms.View.Details
        '
        'lvCheck
        '
        Me.lvCheck.Text = ""
        Me.lvCheck.Width = 29
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
        Me.lvcodArticulo.Width = 121
        '
        'lvNombre
        '
        Me.lvNombre.Text = "ARTÍCULO"
        Me.lvNombre.Width = 347
        '
        'lvCoste
        '
        Me.lvCoste.Text = "COSTE"
        Me.lvCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCoste.Width = 93
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
        Me.lvVersion.Width = 67
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(485, 23)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 5
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
        Me.Contador.Location = New System.Drawing.Point(691, 747)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 187
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
        Me.Label6.Location = New System.Drawing.Point(581, 750)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 190
        Me.Label6.Text = "ENCONTRADOS"
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(19, 322)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 3
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bCambioMasivo
        '
        Me.bCambioMasivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCambioMasivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCambioMasivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCambioMasivo.Location = New System.Drawing.Point(393, 23)
        Me.bCambioMasivo.Name = "bCambioMasivo"
        Me.bCambioMasivo.Size = New System.Drawing.Size(85, 50)
        Me.bCambioMasivo.TabIndex = 4
        Me.bCambioMasivo.Text = "CAMBIO MASIVO"
        Me.bCambioMasivo.UseVisualStyleBackColor = True
        '
        'GestionVersionesEscandallo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 778)
        Me.Controls.Add(Me.ckSeleccion)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvEscandallos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bCambioMasivo)
        Me.Controls.Add(Me.bCrearVersion)
        Me.Controls.Add(Me.NuevaVersion)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(309, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionVersionesEscandallo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE VERSIONES DE ESCANDALLOS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bCrearVersion As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lvEscandallos As System.Windows.Forms.ListView
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCoste As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvContador As System.Windows.Forms.ColumnHeader
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbVersion As System.Windows.Forms.ComboBox
    Friend WithEvents cbcodArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbTipoEscandallo As System.Windows.Forms.ComboBox
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents ckBajas As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NuevaVersion As System.Windows.Forms.TextBox
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bCambioMasivo As System.Windows.Forms.Button
End Class
