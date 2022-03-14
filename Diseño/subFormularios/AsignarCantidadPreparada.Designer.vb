<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignarCantidadPreparada
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
        Me.lbunidad2 = New System.Windows.Forms.Label()
        Me.lbunidad3 = New System.Windows.Forms.Label()
        Me.lbUnidad = New System.Windows.Forms.Label()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbArticulo = New System.Windows.Forms.TextBox()
        Me.tbStock = New System.Windows.Forms.TextBox()
        Me.tbCantidadPreparada = New System.Windows.Forms.TextBox()
        Me.tbCantidadPedida = New System.Windows.Forms.TextBox()
        Me.tbcodArticulo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbunidad2
        '
        Me.lbunidad2.AutoSize = True
        Me.lbunidad2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbunidad2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbunidad2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbunidad2.Location = New System.Drawing.Point(239, 151)
        Me.lbunidad2.Name = "lbunidad2"
        Me.lbunidad2.Size = New System.Drawing.Size(16, 17)
        Me.lbunidad2.TabIndex = 210
        Me.lbunidad2.Text = "U"
        '
        'lbunidad3
        '
        Me.lbunidad3.AutoSize = True
        Me.lbunidad3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbunidad3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbunidad3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbunidad3.Location = New System.Drawing.Point(598, 132)
        Me.lbunidad3.Name = "lbunidad3"
        Me.lbunidad3.Size = New System.Drawing.Size(16, 17)
        Me.lbunidad3.TabIndex = 209
        Me.lbunidad3.Text = "U"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(243, 115)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 207
        Me.lbUnidad.Text = "U"
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(431, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 195
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
        Me.bSalir.TabIndex = 196
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(12, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 17)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "CANTIDAD STOCK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(317, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 17)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "NUEVA CANTIDAD PREPARADA"
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
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "ARTÍCULO"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(12, 115)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(126, 17)
        Me.Label24.TabIndex = 202
        Me.Label24.Text = "CANTIDAD PEDIDA"
        '
        'tbArticulo
        '
        Me.tbArticulo.BackColor = System.Drawing.SystemColors.Control
        Me.tbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbArticulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbArticulo.Location = New System.Drawing.Point(246, 80)
        Me.tbArticulo.MaxLength = 15
        Me.tbArticulo.Name = "tbArticulo"
        Me.tbArticulo.ReadOnly = True
        Me.tbArticulo.Size = New System.Drawing.Size(380, 23)
        Me.tbArticulo.TabIndex = 198
        '
        'tbStock
        '
        Me.tbStock.BackColor = System.Drawing.SystemColors.Control
        Me.tbStock.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbStock.Location = New System.Drawing.Point(161, 148)
        Me.tbStock.MaxLength = 15
        Me.tbStock.Name = "tbStock"
        Me.tbStock.ReadOnly = True
        Me.tbStock.Size = New System.Drawing.Size(77, 23)
        Me.tbStock.TabIndex = 201
        Me.tbStock.Text = "0"
        Me.tbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbCantidadPreparada
        '
        Me.tbCantidadPreparada.BackColor = System.Drawing.SystemColors.Window
        Me.tbCantidadPreparada.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCantidadPreparada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbCantidadPreparada.Location = New System.Drawing.Point(520, 129)
        Me.tbCantidadPreparada.MaxLength = 15
        Me.tbCantidadPreparada.Name = "tbCantidadPreparada"
        Me.tbCantidadPreparada.Size = New System.Drawing.Size(77, 23)
        Me.tbCantidadPreparada.TabIndex = 194
        Me.tbCantidadPreparada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbCantidadPedida
        '
        Me.tbCantidadPedida.BackColor = System.Drawing.SystemColors.Control
        Me.tbCantidadPedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCantidadPedida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbCantidadPedida.Location = New System.Drawing.Point(161, 112)
        Me.tbCantidadPedida.MaxLength = 15
        Me.tbCantidadPedida.Name = "tbCantidadPedida"
        Me.tbCantidadPedida.ReadOnly = True
        Me.tbCantidadPedida.Size = New System.Drawing.Size(77, 23)
        Me.tbCantidadPedida.TabIndex = 199
        Me.tbCantidadPedida.Text = "0"
        Me.tbCantidadPedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbcodArticulo
        '
        Me.tbcodArticulo.BackColor = System.Drawing.SystemColors.Control
        Me.tbcodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcodArticulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbcodArticulo.Location = New System.Drawing.Point(87, 80)
        Me.tbcodArticulo.MaxLength = 15
        Me.tbcodArticulo.Name = "tbcodArticulo"
        Me.tbcodArticulo.ReadOnly = True
        Me.tbcodArticulo.Size = New System.Drawing.Size(151, 23)
        Me.tbcodArticulo.TabIndex = 197
        '
        'AsignarCantidadPreparada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 177)
        Me.Controls.Add(Me.lbunidad2)
        Me.Controls.Add(Me.lbunidad3)
        Me.Controls.Add(Me.lbUnidad)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.tbArticulo)
        Me.Controls.Add(Me.tbStock)
        Me.Controls.Add(Me.tbCantidadPreparada)
        Me.Controls.Add(Me.tbCantidadPedida)
        Me.Controls.Add(Me.tbcodArticulo)
        Me.Name = "AsignarCantidadPreparada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR CANTIDAD PREPARADA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbunidad2 As Label
    Friend WithEvents lbunidad3 As Label
    Friend WithEvents lbUnidad As Label
    Friend WithEvents bGuardar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents tbArticulo As TextBox
    Friend WithEvents tbStock As TextBox
    Friend WithEvents tbCantidadPreparada As TextBox
    Friend WithEvents tbCantidadPedida As TextBox
    Friend WithEvents tbcodArticulo As TextBox
End Class
