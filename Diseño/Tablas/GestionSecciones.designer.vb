<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gestionSecciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestionSecciones))
        Me.nuevo = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbVista = New System.Windows.Forms.ComboBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.lvSecciones = New System.Windows.Forms.ListView
        Me.lvidSeccion = New System.Windows.Forms.ColumnHeader
        Me.lvSeccion = New System.Windows.Forms.ColumnHeader
        Me.lvPrecioHora = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvOrden = New System.Windows.Forms.ColumnHeader
        Me.lvVista = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Orden = New System.Windows.Forms.TextBox
        Me.PrecioHora = New System.Windows.Forms.TextBox
        Me.Seccion = New System.Windows.Forms.TextBox
        Me.descripcion = New System.Windows.Forms.TextBox
        Me.borrar = New System.Windows.Forms.Button
        Me.guardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nuevo
        '
        Me.nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nuevo.Location = New System.Drawing.Point(351, 23)
        Me.nuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.nuevo.Name = "nuevo"
        Me.nuevo.Size = New System.Drawing.Size(87, 50)
        Me.nuevo.TabIndex = 4
        Me.nuevo.Text = "NUEVO"
        Me.nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cbVista)
        Me.GroupBox1.Controls.Add(Me.ckActivo)
        Me.GroupBox1.Controls.Add(Me.lvSecciones)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Orden)
        Me.GroupBox1.Controls.Add(Me.PrecioHora)
        Me.GroupBox1.Controls.Add(Me.Seccion)
        Me.GroupBox1.Controls.Add(Me.descripcion)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 97)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(730, 595)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(397, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 17)
        Me.Label16.TabIndex = 181
        Me.Label16.Text = "VISTA"
        '
        'cbVista
        '
        Me.cbVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVista.FormattingEnabled = True
        Me.cbVista.Location = New System.Drawing.Point(447, 97)
        Me.cbVista.Name = "cbVista"
        Me.cbVista.Size = New System.Drawing.Size(179, 25)
        Me.cbVista.TabIndex = 4
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(643, 99)
        Me.ckActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 5
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'lvSecciones
        '
        Me.lvSecciones.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvSecciones.AllowColumnReorder = True
        Me.lvSecciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSecciones.AutoArrange = False
        Me.lvSecciones.BackgroundImageTiled = True
        Me.lvSecciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidSeccion, Me.lvSeccion, Me.lvPrecioHora, Me.lvdescripcion, Me.lvOrden, Me.lvVista})
        Me.lvSecciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvSecciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSecciones.FullRowSelect = True
        Me.lvSecciones.GridLines = True
        Me.lvSecciones.HideSelection = False
        Me.lvSecciones.Location = New System.Drawing.Point(12, 131)
        Me.lvSecciones.Margin = New System.Windows.Forms.Padding(4)
        Me.lvSecciones.Name = "lvSecciones"
        Me.lvSecciones.ShowItemToolTips = True
        Me.lvSecciones.Size = New System.Drawing.Size(706, 448)
        Me.lvSecciones.TabIndex = 6
        Me.lvSecciones.UseCompatibleStateImageBehavior = False
        Me.lvSecciones.View = System.Windows.Forms.View.Details
        '
        'lvidSeccion
        '
        Me.lvidSeccion.Text = "idSeccion"
        Me.lvidSeccion.Width = 0
        '
        'lvSeccion
        '
        Me.lvSeccion.DisplayIndex = 2
        Me.lvSeccion.Text = "SECCIÓN"
        Me.lvSeccion.Width = 220
        '
        'lvPrecioHora
        '
        Me.lvPrecioHora.DisplayIndex = 3
        Me.lvPrecioHora.Text = "PRECIO/HORA"
        Me.lvPrecioHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioHora.Width = 97
        '
        'lvdescripcion
        '
        Me.lvdescripcion.DisplayIndex = 5
        Me.lvdescripcion.Text = "DESCRIPCIÓN"
        Me.lvdescripcion.Width = 180
        '
        'lvOrden
        '
        Me.lvOrden.DisplayIndex = 1
        Me.lvOrden.Text = "ORDEN"
        Me.lvOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvVista
        '
        Me.lvVista.DisplayIndex = 4
        Me.lvVista.Text = "VISTA"
        Me.lvVista.Width = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "DESCRIPCION"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(199, 101)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "€"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(242, 101)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "ORDEN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 101)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "PRECIO/HORA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(9, 26)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 17)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "SECCIÓN"
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
        'Orden
        '
        Me.Orden.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Orden.Location = New System.Drawing.Point(301, 98)
        Me.Orden.Margin = New System.Windows.Forms.Padding(4)
        Me.Orden.MaxLength = 50
        Me.Orden.Name = "Orden"
        Me.Orden.Size = New System.Drawing.Size(36, 23)
        Me.Orden.TabIndex = 3
        Me.Orden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrecioHora
        '
        Me.PrecioHora.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioHora.Location = New System.Drawing.Point(109, 98)
        Me.PrecioHora.Margin = New System.Windows.Forms.Padding(4)
        Me.PrecioHora.MaxLength = 50
        Me.PrecioHora.Name = "PrecioHora"
        Me.PrecioHora.Size = New System.Drawing.Size(88, 23)
        Me.PrecioHora.TabIndex = 2
        Me.PrecioHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Seccion
        '
        Me.Seccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seccion.Location = New System.Drawing.Point(110, 23)
        Me.Seccion.Margin = New System.Windows.Forms.Padding(4)
        Me.Seccion.MaxLength = 50
        Me.Seccion.Name = "Seccion"
        Me.Seccion.Size = New System.Drawing.Size(608, 23)
        Me.Seccion.TabIndex = 0
        '
        'descripcion
        '
        Me.descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descripcion.Location = New System.Drawing.Point(109, 52)
        Me.descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.descripcion.MaxLength = 150
        Me.descripcion.Multiline = True
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.descripcion.Size = New System.Drawing.Size(609, 40)
        Me.descripcion.TabIndex = 1
        '
        'borrar
        '
        Me.borrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.borrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.borrar.Location = New System.Drawing.Point(545, 23)
        Me.borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(87, 50)
        Me.borrar.TabIndex = 6
        Me.borrar.Text = "BORRAR"
        Me.borrar.UseVisualStyleBackColor = True
        '
        'guardar
        '
        Me.guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.guardar.Location = New System.Drawing.Point(448, 23)
        Me.guardar.Margin = New System.Windows.Forms.Padding(4)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(87, 50)
        Me.guardar.TabIndex = 5
        Me.guardar.Text = "GUARDAR"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(642, 23)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(87, 50)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'gestionSecciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 697)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.borrar)
        Me.Controls.Add(Me.nuevo)
        Me.Controls.Add(Me.guardar)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gestionSecciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE SECCIONES DE PRODUCCIÓN"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents borrar As System.Windows.Forms.Button
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents lvSecciones As System.Windows.Forms.ListView
    Friend WithEvents lvSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.TextBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Seccion As System.Windows.Forms.TextBox
    Friend WithEvents lvidSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrecioHora As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvPrecioHora As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Orden As System.Windows.Forms.TextBox
    Friend WithEvents lvOrden As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvVista As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbVista As System.Windows.Forms.ComboBox
End Class
