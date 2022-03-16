<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionFamilias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionFamilias))
        Me.Label6 = New System.Windows.Forms.Label
        Me.Familia = New System.Windows.Forms.TextBox
        Me.gbFamilias = New System.Windows.Forms.GroupBox
        Me.ckValidacion = New System.Windows.Forms.CheckBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lvFamilias = New System.Windows.Forms.ListView
        Me.lvcodFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvValidacion = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcion = New System.Windows.Forms.ColumnHeader
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.gbSubFamilias = New System.Windows.Forms.GroupBox
        Me.ckValidacionSF = New System.Windows.Forms.CheckBox
        Me.ckActivoSF = New System.Windows.Forms.CheckBox
        Me.DescripcionSF = New System.Windows.Forms.TextBox
        Me.SubFamilia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lvSubFamilias = New System.Windows.Forms.ListView
        Me.lvidSubFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvValidarSF = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcionSF = New System.Windows.Forms.ColumnHeader
        Me.bBorrarSF = New System.Windows.Forms.Button
        Me.bGuardarSF = New System.Windows.Forms.Button
        Me.bNuevoSF = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbFamilias.SuspendLayout()
        Me.gbSubFamilias.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "FAMILIA"
        '
        'Familia
        '
        Me.Familia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Familia.Location = New System.Drawing.Point(109, 21)
        Me.Familia.MaxLength = 20
        Me.Familia.Name = "Familia"
        Me.Familia.Size = New System.Drawing.Size(234, 23)
        Me.Familia.TabIndex = 1
        '
        'gbFamilias
        '
        Me.gbFamilias.Controls.Add(Me.ckValidacion)
        Me.gbFamilias.Controls.Add(Me.ckActivo)
        Me.gbFamilias.Controls.Add(Me.Descripcion)
        Me.gbFamilias.Controls.Add(Me.Familia)
        Me.gbFamilias.Controls.Add(Me.Label2)
        Me.gbFamilias.Controls.Add(Me.Label6)
        Me.gbFamilias.Controls.Add(Me.lvFamilias)
        Me.gbFamilias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFamilias.Location = New System.Drawing.Point(12, 84)
        Me.gbFamilias.Name = "gbFamilias"
        Me.gbFamilias.Size = New System.Drawing.Size(634, 319)
        Me.gbFamilias.TabIndex = 1
        Me.gbFamilias.TabStop = False
        Me.gbFamilias.Text = "FAMILIAS"
        '
        'ckValidacion
        '
        Me.ckValidacion.AutoSize = True
        Me.ckValidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValidacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValidacion.Location = New System.Drawing.Point(479, 23)
        Me.ckValidacion.Name = "ckValidacion"
        Me.ckValidacion.Size = New System.Drawing.Size(144, 21)
        Me.ckValidacion.TabIndex = 3
        Me.ckValidacion.Text = "REQUIERE VALIDAR"
        Me.ckValidacion.UseVisualStyleBackColor = True
        Me.ckValidacion.Visible = False
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(359, 23)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(73, 21)
        Me.ckActivo.TabIndex = 2
        Me.ckActivo.Text = "ACTIVA"
        Me.ckActivo.UseVisualStyleBackColor = True
        Me.ckActivo.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(107, 58)
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
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "DESCRIPCIÓN"
        '
        'lvFamilias
        '
        Me.lvFamilias.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lvFamilias.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvcodFamilia, Me.lvFamilia, Me.lvValidacion, Me.lvDescripcion})
        Me.lvFamilias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFamilias.FullRowSelect = True
        Me.lvFamilias.GridLines = True
        Me.lvFamilias.Location = New System.Drawing.Point(13, 117)
        Me.lvFamilias.MultiSelect = False
        Me.lvFamilias.Name = "lvFamilias"
        Me.lvFamilias.Size = New System.Drawing.Size(610, 196)
        Me.lvFamilias.TabIndex = 5
        Me.lvFamilias.UseCompatibleStateImageBehavior = False
        Me.lvFamilias.View = System.Windows.Forms.View.Details
        '
        'lvcodFamilia
        '
        Me.lvcodFamilia.Text = "CodFamilia"
        Me.lvcodFamilia.Width = 0
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "FAMILIA "
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
        Me.lvDescripcion.Width = 419
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bBorrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrar.Enabled = False
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(447, 12)
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
        Me.bNuevo.Location = New System.Drawing.Point(257, 12)
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
        Me.bGuardar.Location = New System.Drawing.Point(354, 12)
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
        Me.bSalir.Location = New System.Drawing.Point(540, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 9
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'gbSubFamilias
        '
        Me.gbSubFamilias.Controls.Add(Me.ckValidacionSF)
        Me.gbSubFamilias.Controls.Add(Me.ckActivoSF)
        Me.gbSubFamilias.Controls.Add(Me.DescripcionSF)
        Me.gbSubFamilias.Controls.Add(Me.SubFamilia)
        Me.gbSubFamilias.Controls.Add(Me.Label1)
        Me.gbSubFamilias.Controls.Add(Me.Label3)
        Me.gbSubFamilias.Controls.Add(Me.lvSubFamilias)
        Me.gbSubFamilias.Controls.Add(Me.bBorrarSF)
        Me.gbSubFamilias.Controls.Add(Me.bGuardarSF)
        Me.gbSubFamilias.Controls.Add(Me.bNuevoSF)
        Me.gbSubFamilias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSubFamilias.Location = New System.Drawing.Point(12, 407)
        Me.gbSubFamilias.Name = "gbSubFamilias"
        Me.gbSubFamilias.Size = New System.Drawing.Size(634, 339)
        Me.gbSubFamilias.TabIndex = 2
        Me.gbSubFamilias.TabStop = False
        Me.gbSubFamilias.Text = "SUBFAMILIAS"
        '
        'ckValidacionSF
        '
        Me.ckValidacionSF.AutoSize = True
        Me.ckValidacionSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValidacionSF.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValidacionSF.Location = New System.Drawing.Point(107, 22)
        Me.ckValidacionSF.Name = "ckValidacionSF"
        Me.ckValidacionSF.Size = New System.Drawing.Size(144, 21)
        Me.ckValidacionSF.TabIndex = 0
        Me.ckValidacionSF.Text = "REQUIERE VALIDAR"
        Me.ckValidacionSF.UseVisualStyleBackColor = True
        Me.ckValidacionSF.Visible = False
        '
        'ckActivoSF
        '
        Me.ckActivoSF.AutoSize = True
        Me.ckActivoSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoSF.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoSF.Location = New System.Drawing.Point(257, 22)
        Me.ckActivoSF.Name = "ckActivoSF"
        Me.ckActivoSF.Size = New System.Drawing.Size(73, 21)
        Me.ckActivoSF.TabIndex = 1
        Me.ckActivoSF.Text = "ACTIVA"
        Me.ckActivoSF.UseVisualStyleBackColor = True
        Me.ckActivoSF.Visible = False
        '
        'DescripcionSF
        '
        Me.DescripcionSF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionSF.Location = New System.Drawing.Point(107, 87)
        Me.DescripcionSF.MaxLength = 100
        Me.DescripcionSF.Multiline = True
        Me.DescripcionSF.Name = "DescripcionSF"
        Me.DescripcionSF.Size = New System.Drawing.Size(516, 45)
        Me.DescripcionSF.TabIndex = 3
        Me.DescripcionSF.UseSystemPasswordChar = True
        '
        'SubFamilia
        '
        Me.SubFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubFamilia.Location = New System.Drawing.Point(107, 52)
        Me.SubFamilia.MaxLength = 30
        Me.SubFamilia.Name = "SubFamilia"
        Me.SubFamilia.Size = New System.Drawing.Size(223, 23)
        Me.SubFamilia.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 90)
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
        Me.Label3.Location = New System.Drawing.Point(11, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "SUBFAMILIA"
        '
        'lvSubFamilias
        '
        Me.lvSubFamilias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSubFamilias.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidSubFamilia, Me.lvSubFamilia, Me.lvValidarSF, Me.lvDescripcionSF})
        Me.lvSubFamilias.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSubFamilias.FullRowSelect = True
        Me.lvSubFamilias.GridLines = True
        Me.lvSubFamilias.Location = New System.Drawing.Point(8, 138)
        Me.lvSubFamilias.MultiSelect = False
        Me.lvSubFamilias.Name = "lvSubFamilias"
        Me.lvSubFamilias.Size = New System.Drawing.Size(615, 188)
        Me.lvSubFamilias.TabIndex = 7
        Me.lvSubFamilias.UseCompatibleStateImageBehavior = False
        Me.lvSubFamilias.View = System.Windows.Forms.View.Details
        '
        'lvidSubFamilia
        '
        Me.lvidSubFamilia.Text = "idSubFamilia"
        Me.lvidSubFamilia.Width = 0
        '
        'lvSubFamilia
        '
        Me.lvSubFamilia.Text = "SUBFAMILIA "
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
        Me.bBorrarSF.Location = New System.Drawing.Point(528, 22)
        Me.bBorrarSF.Name = "bBorrarSF"
        Me.bBorrarSF.Size = New System.Drawing.Size(85, 50)
        Me.bBorrarSF.TabIndex = 6
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
        Me.bGuardarSF.Location = New System.Drawing.Point(435, 22)
        Me.bGuardarSF.Name = "bGuardarSF"
        Me.bGuardarSF.Size = New System.Drawing.Size(85, 50)
        Me.bGuardarSF.TabIndex = 5
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
        Me.bNuevoSF.Location = New System.Drawing.Point(342, 22)
        Me.bNuevoSF.Name = "bNuevoSF"
        Me.bNuevoSF.Size = New System.Drawing.Size(85, 50)
        Me.bNuevoSF.TabIndex = 4
        Me.bNuevoSF.TabStop = False
        Me.bNuevoSF.Text = "NUEVO"
        Me.bNuevoSF.UseVisualStyleBackColor = True
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
        'GestionFamilias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 758)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbSubFamilias)
        Me.Controls.Add(Me.gbFamilias)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bBorrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionFamilias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAMILIAS Y SUBFAMILIAS DE MATERIAS PRIMAS"
        Me.gbFamilias.ResumeLayout(False)
        Me.gbFamilias.PerformLayout()
        Me.gbSubFamilias.ResumeLayout(False)
        Me.gbSubFamilias.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Familia As System.Windows.Forms.TextBox
    Friend WithEvents gbFamilias As System.Windows.Forms.GroupBox
    Friend WithEvents lvFamilias As System.Windows.Forms.ListView
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
    Friend WithEvents gbSubFamilias As System.Windows.Forms.GroupBox
    Friend WithEvents ckValidacionSF As System.Windows.Forms.CheckBox
    Friend WithEvents ckActivoSF As System.Windows.Forms.CheckBox
    Friend WithEvents DescripcionSF As System.Windows.Forms.TextBox
    Friend WithEvents SubFamilia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvSubFamilias As System.Windows.Forms.ListView
    Friend WithEvents lvidSubFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvValidarSF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcionSF As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBorrarSF As System.Windows.Forms.Button
    Friend WithEvents bNuevoSF As System.Windows.Forms.Button
    Friend WithEvents bGuardarSF As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
