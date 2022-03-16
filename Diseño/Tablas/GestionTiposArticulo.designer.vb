<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionTiposArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionTiposArticulo))
        Me.Label6 = New System.Windows.Forms.Label
        Me.TipoArticulo = New System.Windows.Forms.TextBox
        Me.gbFamilias = New System.Windows.Forms.GroupBox
        Me.rbIndustrial = New System.Windows.Forms.RadioButton
        Me.rbDomestico = New System.Windows.Forms.RadioButton
        Me.ckValidacion = New System.Windows.Forms.CheckBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lvTiposArticulo = New System.Windows.Forms.ListView
        Me.lvcodFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvValidacion = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvcaracter = New System.Windows.Forms.ColumnHeader
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.gbSubTiposArticulo = New System.Windows.Forms.GroupBox
        Me.ckValidacionSF = New System.Windows.Forms.CheckBox
        Me.ckActivoSF = New System.Windows.Forms.CheckBox
        Me.DescripcionSF = New System.Windows.Forms.TextBox
        Me.SubTipoArticulo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lvSubTiposArticulo = New System.Windows.Forms.ListView
        Me.lvidSubFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvValidarSF = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcionSF = New System.Windows.Forms.ColumnHeader
        Me.bBorrarSF = New System.Windows.Forms.Button
        Me.bGuardarSF = New System.Windows.Forms.Button
        Me.bNuevoSF = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbFamilias.SuspendLayout()
        Me.gbSubTiposArticulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(11, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "TIPO"
        '
        'TipoArticulo
        '
        Me.TipoArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoArticulo.Location = New System.Drawing.Point(107, 52)
        Me.TipoArticulo.MaxLength = 20
        Me.TipoArticulo.Name = "TipoArticulo"
        Me.TipoArticulo.Size = New System.Drawing.Size(234, 23)
        Me.TipoArticulo.TabIndex = 1
        '
        'gbFamilias
        '
        Me.gbFamilias.Controls.Add(Me.rbIndustrial)
        Me.gbFamilias.Controls.Add(Me.rbDomestico)
        Me.gbFamilias.Controls.Add(Me.ckValidacion)
        Me.gbFamilias.Controls.Add(Me.ckActivo)
        Me.gbFamilias.Controls.Add(Me.Descripcion)
        Me.gbFamilias.Controls.Add(Me.TipoArticulo)
        Me.gbFamilias.Controls.Add(Me.Label2)
        Me.gbFamilias.Controls.Add(Me.Label6)
        Me.gbFamilias.Controls.Add(Me.lvTiposArticulo)
        Me.gbFamilias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFamilias.Location = New System.Drawing.Point(12, 84)
        Me.gbFamilias.Name = "gbFamilias"
        Me.gbFamilias.Size = New System.Drawing.Size(634, 319)
        Me.gbFamilias.TabIndex = 1
        Me.gbFamilias.TabStop = False
        Me.gbFamilias.Text = "TIPOS DE ARTÍCULO"
        '
        'rbIndustrial
        '
        Me.rbIndustrial.AutoSize = True
        Me.rbIndustrial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIndustrial.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbIndustrial.Location = New System.Drawing.Point(519, 22)
        Me.rbIndustrial.Name = "rbIndustrial"
        Me.rbIndustrial.Size = New System.Drawing.Size(94, 21)
        Me.rbIndustrial.TabIndex = 11
        Me.rbIndustrial.TabStop = True
        Me.rbIndustrial.Text = "INDUSTRIAL"
        Me.rbIndustrial.UseVisualStyleBackColor = True
        '
        'rbDomestico
        '
        Me.rbDomestico.AutoSize = True
        Me.rbDomestico.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDomestico.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbDomestico.Location = New System.Drawing.Point(396, 22)
        Me.rbDomestico.Name = "rbDomestico"
        Me.rbDomestico.Size = New System.Drawing.Size(101, 21)
        Me.rbDomestico.TabIndex = 11
        Me.rbDomestico.TabStop = True
        Me.rbDomestico.Text = "DOMÉSTICO"
        Me.rbDomestico.UseVisualStyleBackColor = True
        '
        'ckValidacion
        '
        Me.ckValidacion.AutoSize = True
        Me.ckValidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValidacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValidacion.Location = New System.Drawing.Point(110, 22)
        Me.ckValidacion.Name = "ckValidacion"
        Me.ckValidacion.Size = New System.Drawing.Size(144, 21)
        Me.ckValidacion.TabIndex = 3
        Me.ckValidacion.Text = "REQUIERE VALIDAR"
        Me.ckValidacion.UseVisualStyleBackColor = True
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(269, 22)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 2
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(107, 82)
        Me.Descripcion.MaxLength = 100
        Me.Descripcion.Multiline = True
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(516, 45)
        Me.Descripcion.TabIndex = 4
        Me.Descripcion.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "DESCRIPCIÓN"
        '
        'lvTiposArticulo
        '
        Me.lvTiposArticulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lvTiposArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcodFamilia, Me.lvFamilia, Me.lvValidacion, Me.lvDescripcion, Me.lvcaracter})
        Me.lvTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTiposArticulo.FullRowSelect = True
        Me.lvTiposArticulo.GridLines = True
        Me.lvTiposArticulo.Location = New System.Drawing.Point(13, 138)
        Me.lvTiposArticulo.MultiSelect = False
        Me.lvTiposArticulo.Name = "lvTiposArticulo"
        Me.lvTiposArticulo.Size = New System.Drawing.Size(610, 175)
        Me.lvTiposArticulo.TabIndex = 5
        Me.lvTiposArticulo.UseCompatibleStateImageBehavior = False
        Me.lvTiposArticulo.View = System.Windows.Forms.View.Details
        '
        'lvcodFamilia
        '
        Me.lvcodFamilia.Text = "CodFamilia"
        Me.lvcodFamilia.Width = 0
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "TIPO"
        Me.lvFamilia.Width = 151
        '
        'lvValidacion
        '
        Me.lvValidacion.Text = "VALIDAR"
        Me.lvValidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvValidacion.Width = 0
        '
        'lvDescripcion
        '
        Me.lvDescripcion.Text = "DESCRIPCIÓN"
        Me.lvDescripcion.Width = 323
        '
        'lvcaracter
        '
        Me.lvcaracter.Text = "DESCUENTO"
        Me.lvcaracter.Width = 95
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bBorrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrar.Enabled = False
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(456, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 8
        Me.bBorrar.TabStop = False
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.bNuevo.Enabled = False
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(270, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 6
        Me.bNuevo.TabStop = False
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(363, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 7
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(549, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 9
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'gbSubTiposArticulo
        '
        Me.gbSubTiposArticulo.Controls.Add(Me.ckValidacionSF)
        Me.gbSubTiposArticulo.Controls.Add(Me.ckActivoSF)
        Me.gbSubTiposArticulo.Controls.Add(Me.DescripcionSF)
        Me.gbSubTiposArticulo.Controls.Add(Me.SubTipoArticulo)
        Me.gbSubTiposArticulo.Controls.Add(Me.Label1)
        Me.gbSubTiposArticulo.Controls.Add(Me.Label3)
        Me.gbSubTiposArticulo.Controls.Add(Me.lvSubTiposArticulo)
        Me.gbSubTiposArticulo.Controls.Add(Me.bBorrarSF)
        Me.gbSubTiposArticulo.Controls.Add(Me.bGuardarSF)
        Me.gbSubTiposArticulo.Controls.Add(Me.bNuevoSF)
        Me.gbSubTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSubTiposArticulo.Location = New System.Drawing.Point(12, 407)
        Me.gbSubTiposArticulo.Name = "gbSubTiposArticulo"
        Me.gbSubTiposArticulo.Size = New System.Drawing.Size(634, 339)
        Me.gbSubTiposArticulo.TabIndex = 2
        Me.gbSubTiposArticulo.TabStop = False
        Me.gbSubTiposArticulo.Text = "SUBTIPOS"
        '
        'ckValidacionSF
        '
        Me.ckValidacionSF.AutoSize = True
        Me.ckValidacionSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValidacionSF.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValidacionSF.Location = New System.Drawing.Point(109, 23)
        Me.ckValidacionSF.Name = "ckValidacionSF"
        Me.ckValidacionSF.Size = New System.Drawing.Size(144, 21)
        Me.ckValidacionSF.TabIndex = 10
        Me.ckValidacionSF.Text = "REQUIERE VALIDAR"
        Me.ckValidacionSF.UseVisualStyleBackColor = True
        '
        'ckActivoSF
        '
        Me.ckActivoSF.AutoSize = True
        Me.ckActivoSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoSF.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoSF.Location = New System.Drawing.Point(259, 23)
        Me.ckActivoSF.Name = "ckActivoSF"
        Me.ckActivoSF.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoSF.TabIndex = 11
        Me.ckActivoSF.Text = "ACTIVO"
        Me.ckActivoSF.UseVisualStyleBackColor = True
        '
        'DescripcionSF
        '
        Me.DescripcionSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionSF.Location = New System.Drawing.Point(107, 82)
        Me.DescripcionSF.MaxLength = 100
        Me.DescripcionSF.Multiline = True
        Me.DescripcionSF.Name = "DescripcionSF"
        Me.DescripcionSF.Size = New System.Drawing.Size(516, 45)
        Me.DescripcionSF.TabIndex = 13
        Me.DescripcionSF.UseSystemPasswordChar = True
        '
        'SubTipoArticulo
        '
        Me.SubTipoArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubTipoArticulo.Location = New System.Drawing.Point(107, 52)
        Me.SubTipoArticulo.MaxLength = 30
        Me.SubTipoArticulo.Name = "SubTipoArticulo"
        Me.SubTipoArticulo.Size = New System.Drawing.Size(223, 23)
        Me.SubTipoArticulo.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "DESCRIPCIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "SUBTIPO"
        '
        'lvSubTiposArticulo
        '
        Me.lvSubTiposArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSubTiposArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidSubFamilia, Me.lvSubFamilia, Me.lvValidarSF, Me.lvDescripcionSF})
        Me.lvSubTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSubTiposArticulo.FullRowSelect = True
        Me.lvSubTiposArticulo.GridLines = True
        Me.lvSubTiposArticulo.Location = New System.Drawing.Point(8, 138)
        Me.lvSubTiposArticulo.MultiSelect = False
        Me.lvSubTiposArticulo.Name = "lvSubTiposArticulo"
        Me.lvSubTiposArticulo.Size = New System.Drawing.Size(615, 188)
        Me.lvSubTiposArticulo.TabIndex = 17
        Me.lvSubTiposArticulo.UseCompatibleStateImageBehavior = False
        Me.lvSubTiposArticulo.View = System.Windows.Forms.View.Details
        '
        'lvidSubFamilia
        '
        Me.lvidSubFamilia.Text = "idSubFamilia"
        Me.lvidSubFamilia.Width = 0
        '
        'lvSubFamilia
        '
        Me.lvSubFamilia.Text = "SUBTIPO"
        Me.lvSubFamilia.Width = 151
        '
        'lvValidarSF
        '
        Me.lvValidarSF.Text = "VALIDAR"
        Me.lvValidarSF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvValidarSF.Width = 0
        '
        'lvDescripcionSF
        '
        Me.lvDescripcionSF.Text = "DESCRIPCIÓN"
        Me.lvDescripcionSF.Width = 427
        '
        'bBorrarSF
        '
        Me.bBorrarSF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrarSF.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrarSF.Enabled = False
        Me.bBorrarSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarSF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrarSF.Location = New System.Drawing.Point(537, 23)
        Me.bBorrarSF.Name = "bBorrarSF"
        Me.bBorrarSF.Size = New System.Drawing.Size(85, 50)
        Me.bBorrarSF.TabIndex = 16
        Me.bBorrarSF.TabStop = False
        Me.bBorrarSF.Text = "BORRAR"
        Me.bBorrarSF.UseVisualStyleBackColor = True
        '
        'bGuardarSF
        '
        Me.bGuardarSF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardarSF.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarSF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarSF.Location = New System.Drawing.Point(444, 23)
        Me.bGuardarSF.Name = "bGuardarSF"
        Me.bGuardarSF.Size = New System.Drawing.Size(85, 50)
        Me.bGuardarSF.TabIndex = 15
        Me.bGuardarSF.Text = "GUARDAR"
        Me.bGuardarSF.UseVisualStyleBackColor = True
        '
        'bNuevoSF
        '
        Me.bNuevoSF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevoSF.Cursor = System.Windows.Forms.Cursors.Default
        Me.bNuevoSF.Enabled = False
        Me.bNuevoSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoSF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoSF.Location = New System.Drawing.Point(351, 23)
        Me.bNuevoSF.Name = "bNuevoSF"
        Me.bNuevoSF.Size = New System.Drawing.Size(85, 50)
        Me.bNuevoSF.TabIndex = 14
        Me.bNuevoSF.TabStop = False
        Me.bNuevoSF.Text = "NUEVO"
        Me.bNuevoSF.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'GestionTiposArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 758)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbSubTiposArticulo)
        Me.Controls.Add(Me.gbFamilias)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bBorrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionTiposArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPOS Y SUBTIPOS DE ARTÍCULOS"
        Me.gbFamilias.ResumeLayout(False)
        Me.gbFamilias.PerformLayout()
        Me.gbSubTiposArticulo.ResumeLayout(False)
        Me.gbSubTiposArticulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TipoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents gbFamilias As System.Windows.Forms.GroupBox
    Friend WithEvents lvTiposArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvValidacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents lvDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lvcodFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckValidacion As System.Windows.Forms.CheckBox
    Friend WithEvents gbSubTiposArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents ckValidacionSF As System.Windows.Forms.CheckBox
    Friend WithEvents ckActivoSF As System.Windows.Forms.CheckBox
    Friend WithEvents DescripcionSF As System.Windows.Forms.TextBox
    Friend WithEvents SubTipoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvSubTiposArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvidSubFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvValidarSF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcionSF As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBorrarSF As System.Windows.Forms.Button
    Friend WithEvents bNuevoSF As System.Windows.Forms.Button
    Friend WithEvents bGuardarSF As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rbDomestico As System.Windows.Forms.RadioButton
    Friend WithEvents rbIndustrial As System.Windows.Forms.RadioButton
    Friend WithEvents lvcaracter As System.Windows.Forms.ColumnHeader
End Class
