<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionFestivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionFestivos))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.borrar = New System.Windows.Forms.Button
        Me.nuevo = New System.Windows.Forms.Button
        Me.guardar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.ckRepetir = New System.Windows.Forms.CheckBox
        Me.lvPaises = New System.Windows.Forms.ListView
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvFestividad = New System.Windows.Forms.ColumnHeader
        Me.lvRepetir = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(513, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(80, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'borrar
        '
        Me.borrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.borrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.borrar.Location = New System.Drawing.Point(421, 13)
        Me.borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(80, 50)
        Me.borrar.TabIndex = 3
        Me.borrar.Text = "BORRAR"
        Me.borrar.UseVisualStyleBackColor = True
        '
        'nuevo
        '
        Me.nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nuevo.Location = New System.Drawing.Point(237, 13)
        Me.nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(80, 50)
        Me.nuevo.TabIndex = 1
        Me.nuevo.Text = "NUEVO"
        Me.nuevo.UseVisualStyleBackColor = True
        '
        'guardar
        '
        Me.guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.guardar.Location = New System.Drawing.Point(329, 13)
        Me.guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(80, 50)
        Me.guardar.TabIndex = 2
        Me.guardar.Text = "GUARDAR"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.ckRepetir)
        Me.GroupBox1.Controls.Add(Me.lvPaises)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 88)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(584, 571)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(108, 22)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(115, 23)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'ckRepetir
        '
        Me.ckRepetir.AutoSize = True
        Me.ckRepetir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRepetir.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRepetir.Location = New System.Drawing.Point(473, 56)
        Me.ckRepetir.Name = "ckRepetir"
        Me.ckRepetir.Size = New System.Drawing.Size(73, 21)
        Me.ckRepetir.TabIndex = 2
        Me.ckRepetir.Text = "REPETIR"
        Me.ckRepetir.UseVisualStyleBackColor = True
        '
        'lvPaises
        '
        Me.lvPaises.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvPaises.AllowColumnReorder = True
        Me.lvPaises.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPaises.AutoArrange = False
        Me.lvPaises.BackgroundImageTiled = True
        Me.lvPaises.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFecha, Me.lvFestividad, Me.lvRepetir})
        Me.lvPaises.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPaises.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPaises.FullRowSelect = True
        Me.lvPaises.GridLines = True
        Me.lvPaises.HideSelection = False
        Me.lvPaises.Location = New System.Drawing.Point(12, 107)
        Me.lvPaises.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPaises.Name = "lvPaises"
        Me.lvPaises.ShowItemToolTips = True
        Me.lvPaises.Size = New System.Drawing.Size(560, 448)
        Me.lvPaises.TabIndex = 3
        Me.lvPaises.UseCompatibleStateImageBehavior = False
        Me.lvPaises.View = System.Windows.Forms.View.Details
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 101
        '
        'lvFestividad
        '
        Me.lvFestividad.Text = "FESTIVIDAD"
        Me.lvFestividad.Width = 359
        '
        'lvRepetir
        '
        Me.lvRepetir.Text = "REPETIR"
        Me.lvRepetir.Width = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "FECHA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(19, 56)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 17)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "FESTIVIDAD"
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
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(108, 53)
        Me.Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.Nombre.MaxLength = 40
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(345, 23)
        Me.Nombre.TabIndex = 1
        '
        'GestionFestivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 673)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.borrar)
        Me.Controls.Add(Me.nuevo)
        Me.Controls.Add(Me.guardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionFestivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE CALENDARIO LABORAL"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents borrar As System.Windows.Forms.Button
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvPaises As System.Windows.Forms.ListView
    Friend WithEvents lvFestividad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRepetir As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckRepetir As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
