<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignarNS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignarNS))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bEtiquetas = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.Cliente = New System.Windows.Forms.TextBox
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvCK = New System.Windows.Forms.ColumnHeader
        Me.lvidEquipo = New System.Windows.Forms.ColumnHeader
        Me.lvFechaFin = New System.Windows.Forms.ColumnHeader
        Me.lvnumSerie = New System.Windows.Forms.ColumnHeader
        Me.lvnumSeriePropuestos = New System.Windows.Forms.ColumnHeader
        Me.Preparados = New System.Windows.Forms.TextBox
        Me.numSerie = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbArticulo = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.bEtiquetas)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.Cliente)
        Me.GroupBox1.Controls.Add(Me.Articulo)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.numPedido)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.codArticulo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbArticulo)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(508, 657)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'bEtiquetas
        '
        Me.bEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEtiquetas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEtiquetas.Location = New System.Drawing.Point(199, 23)
        Me.bEtiquetas.Name = "bEtiquetas"
        Me.bEtiquetas.Size = New System.Drawing.Size(88, 50)
        Me.bEtiquetas.TabIndex = 190
        Me.bEtiquetas.Text = "ETIQUETAS"
        Me.bEtiquetas.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(300, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 190
        Me.bGuardar.Text = "ASIGNAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.BackColor = System.Drawing.SystemColors.Control
        Me.Cliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cliente.Location = New System.Drawing.Point(91, 155)
        Me.Cliente.MaxLength = 150
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Size = New System.Drawing.Size(398, 23)
        Me.Cliente.TabIndex = 181
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Control
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(91, 124)
        Me.Articulo.MaxLength = 150
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(398, 23)
        Me.Articulo.TabIndex = 181
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ckSeleccion)
        Me.GroupBox3.Controls.Add(Me.lvConceptos)
        Me.GroupBox3.Controls.Add(Me.Preparados)
        Me.GroupBox3.Controls.Add(Me.numSerie)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(489, 465)
        Me.GroupBox3.TabIndex = 188
        Me.GroupBox3.TabStop = False
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(17, 25)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 185
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.CheckBoxes = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCK, Me.lvidEquipo, Me.lvFechaFin, Me.lvnumSerie, Me.lvnumSeriePropuestos})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(11, 19)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(466, 437)
        Me.lvConceptos.TabIndex = 13
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvCK
        '
        Me.lvCK.Text = ""
        Me.lvCK.Width = 22
        '
        'lvidEquipo
        '
        Me.lvidEquipo.Text = "ID"
        Me.lvidEquipo.Width = 110
        '
        'lvFechaFin
        '
        Me.lvFechaFin.Text = "FECHA FIN"
        Me.lvFechaFin.Width = 133
        '
        'lvnumSerie
        '
        Me.lvnumSerie.Text = "Nº SERIE"
        Me.lvnumSerie.Width = 150
        '
        'lvnumSeriePropuestos
        '
        Me.lvnumSeriePropuestos.Text = "PROPUESTOS"
        Me.lvnumSeriePropuestos.Width = 0
        '
        'Preparados
        '
        Me.Preparados.BackColor = System.Drawing.SystemColors.Window
        Me.Preparados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preparados.Location = New System.Drawing.Point(504, 66)
        Me.Preparados.MaxLength = 150
        Me.Preparados.Name = "Preparados"
        Me.Preparados.ReadOnly = True
        Me.Preparados.Size = New System.Drawing.Size(69, 23)
        Me.Preparados.TabIndex = 182
        '
        'numSerie
        '
        Me.numSerie.BackColor = System.Drawing.SystemColors.Window
        Me.numSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie.Location = New System.Drawing.Point(389, 19)
        Me.numSerie.MaxLength = 150
        Me.numSerie.Name = "numSerie"
        Me.numSerie.Size = New System.Drawing.Size(88, 23)
        Me.numSerie.TabIndex = 182
        Me.numSerie.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(320, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Nº SERIE"
        Me.Label1.Visible = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(401, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Control
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.Location = New System.Drawing.Point(401, 93)
        Me.numPedido.MaxLength = 150
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        Me.numPedido.Size = New System.Drawing.Size(88, 23)
        Me.numPedido.TabIndex = 180
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(13, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "CLIENTE"
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Control
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(91, 93)
        Me.codArticulo.MaxLength = 150
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(196, 23)
        Me.codArticulo.TabIndex = 180
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(333, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "PEDIDO"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "CÓDIGO"
        '
        'lbArticulo
        '
        Me.lbArticulo.AutoSize = True
        Me.lbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArticulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbArticulo.Location = New System.Drawing.Point(13, 128)
        Me.lbArticulo.Name = "lbArticulo"
        Me.lbArticulo.Size = New System.Drawing.Size(69, 17)
        Me.lbArticulo.TabIndex = 183
        Me.lbArticulo.Text = "ARTÍCULO"
        '
        'AsignarNS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 659)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AsignarNS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR NÚMEROS DE SERIE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidEquipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaFin As System.Windows.Forms.ColumnHeader
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents Preparados As System.Windows.Forms.TextBox
    Friend WithEvents numSerie As System.Windows.Forms.TextBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbArticulo As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvCK As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cliente As System.Windows.Forms.TextBox
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvnumSeriePropuestos As System.Windows.Forms.ColumnHeader
    Friend WithEvents bEtiquetas As System.Windows.Forms.Button
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
End Class
