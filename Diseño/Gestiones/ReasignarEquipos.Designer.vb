<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReasignarEquipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReasignarEquipos))
        Me.bSalir = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bverPedidoActual = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbPedidoActual = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ClienteActual = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbAsignarPedido = New System.Windows.Forms.GroupBox
        Me.nuevoCliente = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbNuevoPedido = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.bVerPedidoNuevo = New System.Windows.Forms.Button
        Me.lvEquipos = New System.Windows.Forms.ListView
        Me.lvck = New System.Windows.Forms.ColumnHeader
        Me.lviEquipo = New System.Windows.Forms.ColumnHeader
        Me.lvnumSerie = New System.Windows.Forms.ColumnHeader
        Me.lvcoArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.Encontrados = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.rbPedido = New System.Windows.Forms.RadioButton
        Me.rbStock = New System.Windows.Forms.RadioButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbAsignarPedido.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(518, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(407, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 7
        Me.bGuardar.Text = "ASIGNAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'bverPedidoActual
        '
        Me.bverPedidoActual.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bverPedidoActual.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bverPedidoActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bverPedidoActual.Location = New System.Drawing.Point(180, 25)
        Me.bverPedidoActual.Name = "bverPedidoActual"
        Me.bverPedidoActual.Size = New System.Drawing.Size(27, 25)
        Me.bverPedidoActual.TabIndex = 1
        Me.bverPedidoActual.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(14, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "PEDIDO"
        '
        'cbPedidoActual
        '
        Me.cbPedidoActual.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPedidoActual.FormattingEnabled = True
        Me.cbPedidoActual.Location = New System.Drawing.Point(73, 25)
        Me.cbPedidoActual.Name = "cbPedidoActual"
        Me.cbPedidoActual.Size = New System.Drawing.Size(90, 25)
        Me.cbPedidoActual.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ClienteActual)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbPedidoActual)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.bverPedidoActual)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PEDIDO ACTUAL"
        '
        'ClienteActual
        '
        Me.ClienteActual.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClienteActual.Location = New System.Drawing.Point(271, 26)
        Me.ClienteActual.MaxLength = 15
        Me.ClienteActual.Name = "ClienteActual"
        Me.ClienteActual.ReadOnly = True
        Me.ClienteActual.Size = New System.Drawing.Size(307, 23)
        Me.ClienteActual.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(212, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "CLIENTE"
        '
        'gbAsignarPedido
        '
        Me.gbAsignarPedido.Controls.Add(Me.nuevoCliente)
        Me.gbAsignarPedido.Controls.Add(Me.Label1)
        Me.gbAsignarPedido.Controls.Add(Me.cbNuevoPedido)
        Me.gbAsignarPedido.Controls.Add(Me.Label2)
        Me.gbAsignarPedido.Controls.Add(Me.bVerPedidoNuevo)
        Me.gbAsignarPedido.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAsignarPedido.Location = New System.Drawing.Point(12, 185)
        Me.gbAsignarPedido.Name = "gbAsignarPedido"
        Me.gbAsignarPedido.Size = New System.Drawing.Size(591, 65)
        Me.gbAsignarPedido.TabIndex = 3
        Me.gbAsignarPedido.TabStop = False
        Me.gbAsignarPedido.Text = "ASIGNAR A PEDIDO"
        '
        'nuevoCliente
        '
        Me.nuevoCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuevoCliente.Location = New System.Drawing.Point(271, 25)
        Me.nuevoCliente.MaxLength = 15
        Me.nuevoCliente.Name = "nuevoCliente"
        Me.nuevoCliente.ReadOnly = True
        Me.nuevoCliente.Size = New System.Drawing.Size(307, 23)
        Me.nuevoCliente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(212, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "CLIENTE"
        '
        'cbNuevoPedido
        '
        Me.cbNuevoPedido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbNuevoPedido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbNuevoPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNuevoPedido.FormattingEnabled = True
        Me.cbNuevoPedido.Location = New System.Drawing.Point(73, 24)
        Me.cbNuevoPedido.Name = "cbNuevoPedido"
        Me.cbNuevoPedido.Size = New System.Drawing.Size(90, 25)
        Me.cbNuevoPedido.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(14, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "PEDIDO"
        '
        'bVerPedidoNuevo
        '
        Me.bVerPedidoNuevo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerPedidoNuevo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerPedidoNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerPedidoNuevo.Location = New System.Drawing.Point(180, 24)
        Me.bVerPedidoNuevo.Name = "bVerPedidoNuevo"
        Me.bVerPedidoNuevo.Size = New System.Drawing.Size(27, 25)
        Me.bVerPedidoNuevo.TabIndex = 1
        Me.bVerPedidoNuevo.UseVisualStyleBackColor = True
        '
        'lvEquipos
        '
        Me.lvEquipos.AllowColumnReorder = True
        Me.lvEquipos.AllowDrop = True
        Me.lvEquipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEquipos.AutoArrange = False
        Me.lvEquipos.BackgroundImageTiled = True
        Me.lvEquipos.CheckBoxes = True
        Me.lvEquipos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvck, Me.lviEquipo, Me.lvnumSerie, Me.lvcoArticulo, Me.lvArticulo, Me.lvEstado})
        Me.lvEquipos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvEquipos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEquipos.FullRowSelect = True
        Me.lvEquipos.GridLines = True
        Me.lvEquipos.HideSelection = False
        Me.lvEquipos.Location = New System.Drawing.Point(12, 265)
        Me.lvEquipos.Name = "lvEquipos"
        Me.lvEquipos.ShowItemToolTips = True
        Me.lvEquipos.Size = New System.Drawing.Size(591, 300)
        Me.lvEquipos.TabIndex = 5
        Me.lvEquipos.UseCompatibleStateImageBehavior = False
        Me.lvEquipos.View = System.Windows.Forms.View.Details
        '
        'lvck
        '
        Me.lvck.Text = ""
        Me.lvck.Width = 22
        '
        'lviEquipo
        '
        Me.lviEquipo.Text = "ID"
        Me.lviEquipo.Width = 50
        '
        'lvnumSerie
        '
        Me.lvnumSerie.Text = "Nº SERIE"
        Me.lvnumSerie.Width = 72
        '
        'lvcoArticulo
        '
        Me.lvcoArticulo.Text = "CÓDIGO"
        Me.lvcoArticulo.Width = 102
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 191
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 113
        '
        'Encontrados
        '
        Me.Encontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Encontrados.BackColor = System.Drawing.SystemColors.Window
        Me.Encontrados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encontrados.ForeColor = System.Drawing.Color.DarkRed
        Me.Encontrados.Location = New System.Drawing.Point(544, 571)
        Me.Encontrados.Name = "Encontrados"
        Me.Encontrados.ReadOnly = True
        Me.Encontrados.Size = New System.Drawing.Size(60, 23)
        Me.Encontrados.TabIndex = 6
        Me.Encontrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(434, 574)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 17)
        Me.Label9.TabIndex = 168
        Me.Label9.Text = "ENCONTRADOS"
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(17, 272)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 4
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'rbPedido
        '
        Me.rbPedido.AutoSize = True
        Me.rbPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPedido.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbPedido.Location = New System.Drawing.Point(200, 164)
        Me.rbPedido.Name = "rbPedido"
        Me.rbPedido.Size = New System.Drawing.Size(148, 21)
        Me.rbPedido.TabIndex = 1
        Me.rbPedido.TabStop = True
        Me.rbPedido.Text = "ASIGNAR A PEDIDO"
        Me.rbPedido.UseVisualStyleBackColor = True
        '
        'rbStock
        '
        Me.rbStock.AutoSize = True
        Me.rbStock.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbStock.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbStock.Location = New System.Drawing.Point(397, 164)
        Me.rbStock.Name = "rbStock"
        Me.rbStock.Size = New System.Drawing.Size(132, 21)
        Me.rbStock.TabIndex = 2
        Me.rbStock.TabStop = True
        Me.rbStock.Text = "LIBERAR A STOCK"
        Me.rbStock.UseVisualStyleBackColor = True
        '
        'ReasignarEquipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 602)
        Me.Controls.Add(Me.rbStock)
        Me.Controls.Add(Me.rbPedido)
        Me.Controls.Add(Me.ckSeleccion)
        Me.Controls.Add(Me.Encontrados)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lvEquipos)
        Me.Controls.Add(Me.gbAsignarPedido)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReasignarEquipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REASIGNACIÓN DE EQUIPOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbAsignarPedido.ResumeLayout(False)
        Me.gbAsignarPedido.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bverPedidoActual As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbPedidoActual As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbAsignarPedido As System.Windows.Forms.GroupBox
    Friend WithEvents cbNuevoPedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bVerPedidoNuevo As System.Windows.Forms.Button
    Friend WithEvents ClienteActual As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nuevoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvEquipos As System.Windows.Forms.ListView
    Friend WithEvents lvck As System.Windows.Forms.ColumnHeader
    Friend WithEvents lviEquipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcoArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents Encontrados As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents rbPedido As System.Windows.Forms.RadioButton
    Friend WithEvents rbStock As System.Windows.Forms.RadioButton
End Class
