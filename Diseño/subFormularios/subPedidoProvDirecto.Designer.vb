<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subPedidoProvDirecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subPedidoProvDirecto))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbAgregar = New System.Windows.Forms.GroupBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvRefProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.gbNuevo = New System.Windows.Forms.GroupBox
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.cbCodProveedor = New System.Windows.Forms.ComboBox
        Me.bBuscarProveedor = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.lbRefCliente = New System.Windows.Forms.Label
        Me.RefProveedor = New System.Windows.Forms.TextBox
        Me.lbFechaEntrega = New System.Windows.Forms.Label
        Me.lbFecha = New System.Windows.Forms.Label
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.bAnadir = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.Precio = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregar.SuspendLayout()
        Me.gbNuevo.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(10, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 128
        Me.PictureBox1.TabStop = False
        '
        'gbAgregar
        '
        Me.gbAgregar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAgregar.Controls.Add(Me.lvConceptos)
        Me.gbAgregar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAgregar.Location = New System.Drawing.Point(13, 203)
        Me.gbAgregar.Name = "gbAgregar"
        Me.gbAgregar.Size = New System.Drawing.Size(647, 254)
        Me.gbAgregar.TabIndex = 1
        Me.gbAgregar.TabStop = False
        Me.gbAgregar.Text = "AGREGAR"
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvProveedor, Me.lvnum, Me.lvRefProveedor, Me.lvFecha, Me.lvEstado})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.Location = New System.Drawing.Point(8, 25)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.Size = New System.Drawing.Size(633, 218)
        Me.lvConceptos.TabIndex = 0
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 144
        '
        'lvnum
        '
        Me.lvnum.Text = "PEDIDO"
        Me.lvnum.Width = 87
        '
        'lvRefProveedor
        '
        Me.lvRefProveedor.Text = "REF.PROVEEDOR"
        Me.lvRefProveedor.Width = 125
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 96
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 142
        '
        'gbNuevo
        '
        Me.gbNuevo.Controls.Add(Me.lbMoneda1)
        Me.gbNuevo.Controls.Add(Me.Precio)
        Me.gbNuevo.Controls.Add(Me.Label14)
        Me.gbNuevo.Controls.Add(Me.lbUnidad)
        Me.gbNuevo.Controls.Add(Me.Label26)
        Me.gbNuevo.Controls.Add(Me.Cantidad)
        Me.gbNuevo.Controls.Add(Me.RefProveedor)
        Me.gbNuevo.Controls.Add(Me.lbRefCliente)
        Me.gbNuevo.Controls.Add(Me.cbCodProveedor)
        Me.gbNuevo.Controls.Add(Me.bBuscarProveedor)
        Me.gbNuevo.Controls.Add(Me.Label22)
        Me.gbNuevo.Controls.Add(Me.cbProveedor)
        Me.gbNuevo.Controls.Add(Me.lbFechaEntrega)
        Me.gbNuevo.Controls.Add(Me.lbFecha)
        Me.gbNuevo.Controls.Add(Me.dtpFechaEntrega)
        Me.gbNuevo.Controls.Add(Me.dtpFecha)
        Me.gbNuevo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNuevo.Location = New System.Drawing.Point(13, 82)
        Me.gbNuevo.Name = "gbNuevo"
        Me.gbNuevo.Size = New System.Drawing.Size(647, 112)
        Me.gbNuevo.TabIndex = 0
        Me.gbNuevo.TabStop = False
        Me.gbNuevo.Text = "NUEVO"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(375, 83)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 177
        Me.lbUnidad.Text = "U"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(217, 83)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 17)
        Me.Label26.TabIndex = 175
        Me.Label26.Text = "CANTIDAD"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cantidad
        '
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Cantidad.Location = New System.Drawing.Point(287, 80)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(87, 22)
        Me.Cantidad.TabIndex = 6
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbCodProveedor
        '
        Me.cbCodProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbCodProveedor.FormattingEnabled = True
        Me.cbCodProveedor.Location = New System.Drawing.Point(121, 23)
        Me.cbCodProveedor.Name = "cbCodProveedor"
        Me.cbCodProveedor.Size = New System.Drawing.Size(90, 25)
        Me.cbCodProveedor.Sorted = True
        Me.cbCodProveedor.TabIndex = 0
        '
        'bBuscarProveedor
        '
        Me.bBuscarProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bBuscarProveedor.Image = CType(resources.GetObject("bBuscarProveedor.Image"), System.Drawing.Image)
        Me.bBuscarProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarProveedor.Location = New System.Drawing.Point(610, 23)
        Me.bBuscarProveedor.Name = "bBuscarProveedor"
        Me.bBuscarProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarProveedor.TabIndex = 2
        Me.bBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(8, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 17)
        Me.Label22.TabIndex = 122
        Me.Label22.Text = "PROVEEDOR"
        '
        'cbProveedor
        '
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(217, 23)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(376, 25)
        Me.cbProveedor.TabIndex = 1
        '
        'lbRefCliente
        '
        Me.lbRefCliente.AutoSize = True
        Me.lbRefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRefCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbRefCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbRefCliente.Location = New System.Drawing.Point(351, 57)
        Me.lbRefCliente.Name = "lbRefCliente"
        Me.lbRefCliente.Size = New System.Drawing.Size(116, 17)
        Me.lbRefCliente.TabIndex = 119
        Me.lbRefCliente.Text = "REF. PROVEEDOR"
        '
        'RefProveedor
        '
        Me.RefProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.RefProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefProveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefProveedor.Location = New System.Drawing.Point(473, 53)
        Me.RefProveedor.MaxLength = 20
        Me.RefProveedor.Name = "RefProveedor"
        Me.RefProveedor.Size = New System.Drawing.Size(120, 23)
        Me.RefProveedor.TabIndex = 4
        '
        'lbFechaEntrega
        '
        Me.lbFechaEntrega.AutoSize = True
        Me.lbFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaEntrega.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaEntrega.Location = New System.Drawing.Point(8, 83)
        Me.lbFechaEntrega.Name = "lbFechaEntrega"
        Me.lbFechaEntrega.Size = New System.Drawing.Size(111, 17)
        Me.lbFechaEntrega.TabIndex = 117
        Me.lbFechaEntrega.Text = "FECHA ENTREGA"
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFecha.Location = New System.Drawing.Point(8, 56)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(103, 17)
        Me.lbFecha.TabIndex = 117
        Me.lbFecha.Text = "FECHA PEDIDO"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(121, 80)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(91, 23)
        Me.dtpFechaEntrega.TabIndex = 5
        Me.dtpFechaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(121, 53)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(91, 23)
        Me.dtpFecha.TabIndex = 3
        Me.dtpFecha.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'bAnadir
        '
        Me.bAnadir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAnadir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAnadir.Location = New System.Drawing.Point(436, 14)
        Me.bAnadir.Name = "bAnadir"
        Me.bAnadir.Size = New System.Drawing.Size(100, 50)
        Me.bAnadir.TabIndex = 3
        Me.bAnadir.Text = "AÑADIR A PEDIDO"
        Me.bAnadir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(315, 14)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(100, 50)
        Me.bNuevo.TabIndex = 2
        Me.bNuevo.Text = "NUEVO PEDIDO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(557, 14)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(100, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'lbMoneda1
        '
        Me.lbMoneda1.AutoSize = True
        Me.lbMoneda1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda1.Location = New System.Drawing.Point(592, 83)
        Me.lbMoneda1.Name = "lbMoneda1"
        Me.lbMoneda1.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda1.TabIndex = 180
        Me.lbMoneda1.Text = "€"
        '
        'Precio
        '
        Me.Precio.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Precio.ForeColor = System.Drawing.Color.Black
        Me.Precio.Location = New System.Drawing.Point(473, 80)
        Me.Precio.Name = "Precio"
        Me.Precio.Size = New System.Drawing.Size(118, 22)
        Me.Precio.TabIndex = 7
        Me.Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(413, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 17)
        Me.Label14.TabIndex = 178
        Me.Label14.Text = "PRECIO "
        '
        'subPedidoProvDirecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 470)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbAgregar)
        Me.Controls.Add(Me.gbNuevo)
        Me.Controls.Add(Me.bAnadir)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subPedidoProvDirecto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PEDIDO A PROVEEDOR"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregar.ResumeLayout(False)
        Me.gbNuevo.ResumeLayout(False)
        Me.gbNuevo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbAgregar As System.Windows.Forms.GroupBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbNuevo As System.Windows.Forms.GroupBox
    Friend WithEvents lbRefCliente As System.Windows.Forms.Label
    Friend WithEvents RefProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents bAnadir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents Precio As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
