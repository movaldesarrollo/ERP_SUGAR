<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subUltimoPedidoArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subUltimoPedidoArticulo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bCancelar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbUnidadMedida = New System.Windows.Forms.Label
        Me.lbMoneda = New System.Windows.Forms.Label
        Me.bVerPedidoProveedor = New System.Windows.Forms.Button
        Me.Precio = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Fecha = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Proveedor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.bPedido = New System.Windows.Forms.Button
        Me.lbEstado = New System.Windows.Forms.Label
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
        Me.PictureBox1.TabIndex = 126
        Me.PictureBox1.TabStop = False
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(430, 15)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 50)
        Me.bCancelar.TabIndex = 4
        Me.bCancelar.Text = "SALIR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(27, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "CÓDIGO"
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.ForeColor = System.Drawing.Color.Black
        Me.codArticulo.Location = New System.Drawing.Point(114, 78)
        Me.codArticulo.MaxLength = 30
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(404, 23)
        Me.codArticulo.TabIndex = 0
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Window
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.ForeColor = System.Drawing.Color.Black
        Me.Articulo.Location = New System.Drawing.Point(114, 107)
        Me.Articulo.MaxLength = 30
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(404, 23)
        Me.Articulo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(27, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "ARTÍCULO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbUnidadMedida)
        Me.GroupBox1.Controls.Add(Me.lbMoneda)
        Me.GroupBox1.Controls.Add(Me.bVerPedidoProveedor)
        Me.GroupBox1.Controls.Add(Me.Precio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Cantidad)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.numPedido)
        Me.GroupBox1.Controls.Add(Me.lbEstado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Fecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Proveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 150)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 126)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ÚLTIMO PEDIDO"
        '
        'lbUnidadMedida
        '
        Me.lbUnidadMedida.AutoSize = True
        Me.lbUnidadMedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida.Location = New System.Drawing.Point(195, 83)
        Me.lbUnidadMedida.Name = "lbUnidadMedida"
        Me.lbUnidadMedida.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida.TabIndex = 172
        Me.lbUnidadMedida.Text = "U"
        '
        'lbMoneda
        '
        Me.lbMoneda.AutoSize = True
        Me.lbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMoneda.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda.Location = New System.Drawing.Point(380, 83)
        Me.lbMoneda.Name = "lbMoneda"
        Me.lbMoneda.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda.TabIndex = 171
        Me.lbMoneda.Text = "€"
        '
        'bVerPedidoProveedor
        '
        Me.bVerPedidoProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerPedidoProveedor.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerPedidoProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerPedidoProveedor.Location = New System.Drawing.Point(386, 49)
        Me.bVerPedidoProveedor.Name = "bVerPedidoProveedor"
        Me.bVerPedidoProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bVerPedidoProveedor.TabIndex = 3
        Me.bVerPedidoProveedor.UseVisualStyleBackColor = True
        '
        'Precio
        '
        Me.Precio.BackColor = System.Drawing.SystemColors.Window
        Me.Precio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Precio.ForeColor = System.Drawing.Color.Black
        Me.Precio.Location = New System.Drawing.Point(282, 80)
        Me.Precio.MaxLength = 30
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Size = New System.Drawing.Size(98, 23)
        Me.Precio.TabIndex = 5
        Me.Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(220, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 17)
        Me.Label7.TabIndex = 128
        Me.Label7.Text = "PRECIO"
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Cantidad.Location = New System.Drawing.Point(98, 80)
        Me.Cantidad.MaxLength = 30
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Size = New System.Drawing.Size(97, 23)
        Me.Cantidad.TabIndex = 4
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(7, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CANTIDAD"
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.Color.Black
        Me.numPedido.Location = New System.Drawing.Point(282, 51)
        Me.numPedido.MaxLength = 30
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        Me.numPedido.Size = New System.Drawing.Size(98, 23)
        Me.numPedido.TabIndex = 2
        Me.numPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(221, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 17)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "PEDIDO"
        '
        'Fecha
        '
        Me.Fecha.BackColor = System.Drawing.SystemColors.Window
        Me.Fecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.ForeColor = System.Drawing.Color.Black
        Me.Fecha.Location = New System.Drawing.Point(98, 54)
        Me.Fecha.MaxLength = 30
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Size = New System.Drawing.Size(98, 23)
        Me.Fecha.TabIndex = 1
        Me.Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "FECHA"
        '
        'Proveedor
        '
        Me.Proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Proveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Proveedor.ForeColor = System.Drawing.Color.Black
        Me.Proveedor.Location = New System.Drawing.Point(98, 25)
        Me.Proveedor.MaxLength = 30
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Size = New System.Drawing.Size(404, 23)
        Me.Proveedor.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(7, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "PROVEEDOR"
        '
        'bPedido
        '
        Me.bPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPedido.Location = New System.Drawing.Point(317, 15)
        Me.bPedido.Name = "bPedido"
        Me.bPedido.Size = New System.Drawing.Size(88, 50)
        Me.bPedido.TabIndex = 3
        Me.bPedido.Text = "PEDIDO"
        Me.bPedido.UseVisualStyleBackColor = True
        '
        'lbEstado
        '
        Me.lbEstado.AutoSize = True
        Me.lbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbEstado.Location = New System.Drawing.Point(418, 54)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(57, 17)
        Me.lbEstado.TabIndex = 128
        Me.lbEstado.Text = "PEDIDO"
        '
        'subUltimoPedidoArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 286)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Articulo)
        Me.Controls.Add(Me.codArticulo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bPedido)
        Me.Controls.Add(Me.bCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subUltimoPedidoArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ÚLTIMO PEDIDO"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Precio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bVerPedidoProveedor As System.Windows.Forms.Button
    Friend WithEvents bPedido As System.Windows.Forms.Button
    Friend WithEvents lbMoneda As System.Windows.Forms.Label
    Friend WithEvents lbUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents lbEstado As System.Windows.Forms.Label
End Class
