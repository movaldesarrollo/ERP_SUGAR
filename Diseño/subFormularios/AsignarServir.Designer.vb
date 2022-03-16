<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignarServir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignarServir))
        Me.Label24 = New System.Windows.Forms.Label()
        Me.codArticulo = New System.Windows.Forms.TextBox()
        Me.Articulo = New System.Windows.Forms.TextBox()
        Me.CantidadPedida = New System.Windows.Forms.TextBox()
        Me.CantidadPreparada = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CantidadServida = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbUnidad = New System.Windows.Forms.Label()
        Me.lbunidad1 = New System.Windows.Forms.Label()
        Me.lbunidad3 = New System.Windows.Forms.Label()
        Me.Stock = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbunidad2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(12, 111)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(126, 17)
        Me.Label24.TabIndex = 181
        Me.Label24.Text = "CANTIDAD PEDIDA"
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Control
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codArticulo.Location = New System.Drawing.Point(87, 80)
        Me.codArticulo.MaxLength = 15
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(151, 23)
        Me.codArticulo.TabIndex = 3
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Control
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Articulo.Location = New System.Drawing.Point(246, 80)
        Me.Articulo.MaxLength = 15
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(380, 23)
        Me.Articulo.TabIndex = 4
        '
        'CantidadPedida
        '
        Me.CantidadPedida.BackColor = System.Drawing.SystemColors.Control
        Me.CantidadPedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadPedida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadPedida.Location = New System.Drawing.Point(161, 108)
        Me.CantidadPedida.MaxLength = 15
        Me.CantidadPedida.Name = "CantidadPedida"
        Me.CantidadPedida.ReadOnly = True
        Me.CantidadPedida.Size = New System.Drawing.Size(77, 23)
        Me.CantidadPedida.TabIndex = 5
        Me.CantidadPedida.Text = "0"
        Me.CantidadPedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CantidadPreparada
        '
        Me.CantidadPreparada.BackColor = System.Drawing.SystemColors.Window
        Me.CantidadPreparada.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadPreparada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadPreparada.Location = New System.Drawing.Point(526, 138)
        Me.CantidadPreparada.MaxLength = 15
        Me.CantidadPreparada.Name = "CantidadPreparada"
        Me.CantidadPreparada.Size = New System.Drawing.Size(77, 23)
        Me.CantidadPreparada.TabIndex = 0
        Me.CantidadPreparada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(323, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 17)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "NUEVA CANTIDAD PREPARADA"
        '
        'CantidadServida
        '
        Me.CantidadServida.BackColor = System.Drawing.SystemColors.Control
        Me.CantidadServida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadServida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadServida.Location = New System.Drawing.Point(161, 138)
        Me.CantidadServida.MaxLength = 15
        Me.CantidadServida.Name = "CantidadServida"
        Me.CantidadServida.ReadOnly = True
        Me.CantidadServida.Size = New System.Drawing.Size(77, 23)
        Me.CantidadServida.TabIndex = 6
        Me.CantidadServida.Text = "0"
        Me.CantidadServida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 17)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "CANTIDAD SERVIDA"
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(431, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 1
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(538, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 2
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "ARTÍCULO"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(243, 111)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 193
        Me.lbUnidad.Text = "U"
        '
        'lbunidad1
        '
        Me.lbunidad1.AutoSize = True
        Me.lbunidad1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbunidad1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbunidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbunidad1.Location = New System.Drawing.Point(243, 141)
        Me.lbunidad1.Name = "lbunidad1"
        Me.lbunidad1.Size = New System.Drawing.Size(16, 17)
        Me.lbunidad1.TabIndex = 193
        Me.lbunidad1.Text = "U"
        '
        'lbunidad3
        '
        Me.lbunidad3.AutoSize = True
        Me.lbunidad3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbunidad3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbunidad3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbunidad3.Location = New System.Drawing.Point(604, 141)
        Me.lbunidad3.Name = "lbunidad3"
        Me.lbunidad3.Size = New System.Drawing.Size(16, 17)
        Me.lbunidad3.TabIndex = 193
        Me.lbunidad3.Text = "U"
        '
        'Stock
        '
        Me.Stock.BackColor = System.Drawing.SystemColors.Control
        Me.Stock.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Stock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Stock.Location = New System.Drawing.Point(526, 108)
        Me.Stock.MaxLength = 15
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Size = New System.Drawing.Size(77, 23)
        Me.Stock.TabIndex = 7
        Me.Stock.Text = "0"
        Me.Stock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(325, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 17)
        Me.Label7.TabIndex = 181
        Me.Label7.Text = "CANTIDAD STOCK"
        '
        'lbunidad2
        '
        Me.lbunidad2.AutoSize = True
        Me.lbunidad2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbunidad2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbunidad2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbunidad2.Location = New System.Drawing.Point(604, 111)
        Me.lbunidad2.Name = "lbunidad2"
        Me.lbunidad2.Size = New System.Drawing.Size(16, 17)
        Me.lbunidad2.TabIndex = 193
        Me.lbunidad2.Text = "U"
        '
        'AsignarServir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 177)
        Me.Controls.Add(Me.lbunidad2)
        Me.Controls.Add(Me.lbunidad3)
        Me.Controls.Add(Me.lbunidad1)
        Me.Controls.Add(Me.lbUnidad)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Articulo)
        Me.Controls.Add(Me.Stock)
        Me.Controls.Add(Me.CantidadPreparada)
        Me.Controls.Add(Me.CantidadServida)
        Me.Controls.Add(Me.CantidadPedida)
        Me.Controls.Add(Me.codArticulo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AsignarServir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR CANTIDAD A SERVIR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents CantidadPedida As System.Windows.Forms.TextBox
    Friend WithEvents CantidadPreparada As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents lbunidad3 As System.Windows.Forms.Label
    Friend WithEvents Stock As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbunidad2 As System.Windows.Forms.Label
    Public WithEvents Label2 As Label
    Public WithEvents CantidadServida As TextBox
    Public WithEvents lbunidad1 As Label
End Class
