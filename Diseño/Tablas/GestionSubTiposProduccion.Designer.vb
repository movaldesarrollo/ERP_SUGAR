<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionSubTiposProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionSubTiposProduccion))
        Me.gbSubTiposArticulo = New System.Windows.Forms.GroupBox
        Me.subTipo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbAgrupaciones = New System.Windows.Forms.ComboBox
        Me.lvSubTiposArticulo = New System.Windows.Forms.ListView
        Me.lvidSubTipo = New System.Windows.Forms.ColumnHeader
        Me.lvsubTipo = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcionST = New System.Windows.Forms.ColumnHeader
        Me.lvAgrupacionST = New System.Windows.Forms.ColumnHeader
        Me.lvidAgrupacionST = New System.Windows.Forms.ColumnHeader
        Me.gbFamilias = New System.Windows.Forms.GroupBox
        Me.lvTiposArticulo = New System.Windows.Forms.ListView
        Me.lvidTipo = New System.Windows.Forms.ColumnHeader
        Me.lvTipo = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcion = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bAgrupacion = New System.Windows.Forms.Button
        Me.gbSubTiposArticulo.SuspendLayout()
        Me.gbFamilias.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSubTiposArticulo
        '
        Me.gbSubTiposArticulo.Controls.Add(Me.bAgrupacion)
        Me.gbSubTiposArticulo.Controls.Add(Me.subTipo)
        Me.gbSubTiposArticulo.Controls.Add(Me.Label6)
        Me.gbSubTiposArticulo.Controls.Add(Me.Label2)
        Me.gbSubTiposArticulo.Controls.Add(Me.cbAgrupaciones)
        Me.gbSubTiposArticulo.Controls.Add(Me.lvSubTiposArticulo)
        Me.gbSubTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSubTiposArticulo.Location = New System.Drawing.Point(21, 273)
        Me.gbSubTiposArticulo.Name = "gbSubTiposArticulo"
        Me.gbSubTiposArticulo.Size = New System.Drawing.Size(634, 439)
        Me.gbSubTiposArticulo.TabIndex = 1
        Me.gbSubTiposArticulo.TabStop = False
        Me.gbSubTiposArticulo.Text = "SUBTIPOS"
        '
        'subTipo
        '
        Me.subTipo.BackColor = System.Drawing.SystemColors.Window
        Me.subTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subTipo.Location = New System.Drawing.Point(73, 29)
        Me.subTipo.MaxLength = 20
        Me.subTipo.Name = "subTipo"
        Me.subTipo.ReadOnly = True
        Me.subTipo.Size = New System.Drawing.Size(145, 23)
        Me.subTipo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(17, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "SUBTIPO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(222, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "AGRUPACIÓN"
        '
        'cbAgrupaciones
        '
        Me.cbAgrupaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAgrupaciones.FormattingEnabled = True
        Me.cbAgrupaciones.Location = New System.Drawing.Point(323, 28)
        Me.cbAgrupaciones.MaxLength = 6
        Me.cbAgrupaciones.Name = "cbAgrupaciones"
        Me.cbAgrupaciones.Size = New System.Drawing.Size(254, 25)
        Me.cbAgrupaciones.TabIndex = 1
        '
        'lvSubTiposArticulo
        '
        Me.lvSubTiposArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSubTiposArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidSubTipo, Me.lvsubTipo, Me.lvDescripcionST, Me.lvAgrupacionST, Me.lvidAgrupacionST})
        Me.lvSubTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSubTiposArticulo.FullRowSelect = True
        Me.lvSubTiposArticulo.GridLines = True
        Me.lvSubTiposArticulo.HideSelection = False
        Me.lvSubTiposArticulo.Location = New System.Drawing.Point(13, 65)
        Me.lvSubTiposArticulo.MultiSelect = False
        Me.lvSubTiposArticulo.Name = "lvSubTiposArticulo"
        Me.lvSubTiposArticulo.Size = New System.Drawing.Size(610, 364)
        Me.lvSubTiposArticulo.TabIndex = 2
        Me.lvSubTiposArticulo.UseCompatibleStateImageBehavior = False
        Me.lvSubTiposArticulo.View = System.Windows.Forms.View.Details
        '
        'lvidSubTipo
        '
        Me.lvidSubTipo.Text = "idSubTipo"
        Me.lvidSubTipo.Width = 0
        '
        'lvsubTipo
        '
        Me.lvsubTipo.Text = "SUBTIPO"
        Me.lvsubTipo.Width = 151
        '
        'lvDescripcionST
        '
        Me.lvDescripcionST.Text = "DESCRIPCIÓN"
        Me.lvDescripcionST.Width = 228
        '
        'lvAgrupacionST
        '
        Me.lvAgrupacionST.Text = "AGRUPACIÓN"
        Me.lvAgrupacionST.Width = 186
        '
        'lvidAgrupacionST
        '
        Me.lvidAgrupacionST.Text = "idAgrupacion"
        Me.lvidAgrupacionST.Width = 0
        '
        'gbFamilias
        '
        Me.gbFamilias.Controls.Add(Me.lvTiposArticulo)
        Me.gbFamilias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFamilias.Location = New System.Drawing.Point(21, 81)
        Me.gbFamilias.Name = "gbFamilias"
        Me.gbFamilias.Size = New System.Drawing.Size(634, 186)
        Me.gbFamilias.TabIndex = 0
        Me.gbFamilias.TabStop = False
        Me.gbFamilias.Text = "TIPOS DE ARTÍCULO"
        '
        'lvTiposArticulo
        '
        Me.lvTiposArticulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lvTiposArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidTipo, Me.lvTipo, Me.lvDescripcion})
        Me.lvTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTiposArticulo.FullRowSelect = True
        Me.lvTiposArticulo.GridLines = True
        Me.lvTiposArticulo.HideSelection = False
        Me.lvTiposArticulo.Location = New System.Drawing.Point(13, 22)
        Me.lvTiposArticulo.MultiSelect = False
        Me.lvTiposArticulo.Name = "lvTiposArticulo"
        Me.lvTiposArticulo.Size = New System.Drawing.Size(610, 152)
        Me.lvTiposArticulo.TabIndex = 5
        Me.lvTiposArticulo.UseCompatibleStateImageBehavior = False
        Me.lvTiposArticulo.View = System.Windows.Forms.View.Details
        '
        'lvidTipo
        '
        Me.lvidTipo.Text = "idTipo"
        Me.lvidTipo.Width = 0
        '
        'lvTipo
        '
        Me.lvTipo.Text = "TIPO"
        Me.lvTipo.Width = 150
        '
        'lvDescripcion
        '
        Me.lvDescripcion.Text = "DESCRIPCIÓN"
        Me.lvDescripcion.Width = 420
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(559, 16)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(457, 16)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(352, 16)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.TabStop = False
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bAgrupacion
        '
        Me.bAgrupacion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAgrupacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAgrupacion.Location = New System.Drawing.Point(596, 27)
        Me.bAgrupacion.Name = "bAgrupacion"
        Me.bAgrupacion.Size = New System.Drawing.Size(27, 25)
        Me.bAgrupacion.TabIndex = 104
        Me.bAgrupacion.Text = "...."
        Me.bAgrupacion.UseVisualStyleBackColor = True
        '
        'GestionSubTiposProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 724)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbSubTiposArticulo)
        Me.Controls.Add(Me.gbFamilias)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionSubTiposProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SUBTIPOS DE ARTÍCULOS EN PRODUCCIÓN"
        Me.gbSubTiposArticulo.ResumeLayout(False)
        Me.gbSubTiposArticulo.PerformLayout()
        Me.gbFamilias.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSubTiposArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents lvSubTiposArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvidSubTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvsubTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcionST As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbFamilias As System.Windows.Forms.GroupBox
    Friend WithEvents lvTiposArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvidTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lvAgrupacionST As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidAgrupacionST As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbAgrupaciones As System.Windows.Forms.ComboBox
    Friend WithEvents subTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bAgrupacion As System.Windows.Forms.Button
End Class
