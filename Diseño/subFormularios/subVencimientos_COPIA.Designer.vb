<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subVencimientos1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subVencimientos1))
        Me.lvVencimientos = New System.Windows.Forms.ListView
        Me.lvidVencimiento = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvImprte = New System.Windows.Forms.ColumnHeader
        Me.lvImportex = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.Label13 = New System.Windows.Forms.Label
        Me.Importe = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpVencimiento = New System.Windows.Forms.DateTimePicker
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ckCobrado = New System.Windows.Forms.CheckBox
        Me.Restante = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TotalFactura = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.lbMoneda3 = New System.Windows.Forms.Label
        Me.lbMoneda2 = New System.Windows.Forms.Label
        Me.bGuardar = New System.Windows.Forms.Button
        Me.ckDevuelto = New System.Windows.Forms.CheckBox
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvVencimientos
        '
        Me.lvVencimientos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvVencimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidVencimiento, Me.lvFecha, Me.lvImprte, Me.lvImportex, Me.lvEstado})
        Me.lvVencimientos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvVencimientos.FullRowSelect = True
        Me.lvVencimientos.GridLines = True
        Me.lvVencimientos.Location = New System.Drawing.Point(14, 126)
        Me.lvVencimientos.MultiSelect = False
        Me.lvVencimientos.Name = "lvVencimientos"
        Me.lvVencimientos.Size = New System.Drawing.Size(567, 420)
        Me.lvVencimientos.TabIndex = 4
        Me.lvVencimientos.UseCompatibleStateImageBehavior = False
        Me.lvVencimientos.View = System.Windows.Forms.View.Details
        '
        'lvidVencimiento
        '
        Me.lvidVencimiento.Text = "idVencimiento"
        Me.lvidVencimiento.Width = 0
        '
        'lvFecha
        '
        Me.lvFecha.Text = "VENCIMIENTO"
        Me.lvFecha.Width = 184
        '
        'lvImprte
        '
        Me.lvImprte.DisplayIndex = 3
        Me.lvImprte.Text = "IMPORTE"
        Me.lvImprte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImprte.Width = 195
        '
        'lvImportex
        '
        Me.lvImportex.DisplayIndex = 4
        Me.lvImportex.Text = "IMPORTE"
        Me.lvImportex.Width = 0
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 2
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 181
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(13, 94)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 17)
        Me.Label13.TabIndex = 192
        Me.Label13.Text = "VENCIMIENTO"
        '
        'Importe
        '
        Me.Importe.BackColor = System.Drawing.SystemColors.Window
        Me.Importe.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Importe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Importe.Location = New System.Drawing.Point(274, 90)
        Me.Importe.MaxLength = 15
        Me.Importe.Name = "Importe"
        Me.Importe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Importe.Size = New System.Drawing.Size(90, 23)
        Me.Importe.TabIndex = 1
        Me.Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(207, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "IMPORTE"
        '
        'dtpVencimiento
        '
        Me.dtpVencimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimiento.Location = New System.Drawing.Point(111, 91)
        Me.dtpVencimiento.Name = "dtpVencimiento"
        Me.dtpVencimiento.Size = New System.Drawing.Size(90, 23)
        Me.dtpVencimiento.TabIndex = 0
        Me.dtpVencimiento.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(9, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 194
        Me.PictureBox1.TabStop = False
        '
        'ckCobrado
        '
        Me.ckCobrado.AutoSize = True
        Me.ckCobrado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCobrado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCobrado.Location = New System.Drawing.Point(487, 92)
        Me.ckCobrado.Name = "ckCobrado"
        Me.ckCobrado.Size = New System.Drawing.Size(94, 21)
        Me.ckCobrado.TabIndex = 2
        Me.ckCobrado.Text = "COBRADO"
        Me.ckCobrado.UseVisualStyleBackColor = True
        '
        'Restante
        '
        Me.Restante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Restante.BackColor = System.Drawing.SystemColors.Window
        Me.Restante.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Restante.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Restante.Location = New System.Drawing.Point(113, 557)
        Me.Restante.MaxLength = 15
        Me.Restante.Multiline = True
        Me.Restante.Name = "Restante"
        Me.Restante.ReadOnly = True
        Me.Restante.Size = New System.Drawing.Size(120, 27)
        Me.Restante.TabIndex = 5
        Me.Restante.TabStop = False
        Me.Restante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 560)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 21)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "PENDIENTE"
        '
        'TotalFactura
        '
        Me.TotalFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalFactura.BackColor = System.Drawing.SystemColors.Window
        Me.TotalFactura.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.TotalFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalFactura.Location = New System.Drawing.Point(436, 557)
        Me.TotalFactura.MaxLength = 15
        Me.TotalFactura.Name = "TotalFactura"
        Me.TotalFactura.ReadOnly = True
        Me.TotalFactura.Size = New System.Drawing.Size(120, 27)
        Me.TotalFactura.TabIndex = 6
        Me.TotalFactura.TabStop = False
        Me.TotalFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(290, 560)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 21)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "TOTAL FACTURA"
        '
        'lbMoneda1
        '
        Me.lbMoneda1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda1.AutoSize = True
        Me.lbMoneda1.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda1.Location = New System.Drawing.Point(562, 560)
        Me.lbMoneda1.Name = "lbMoneda1"
        Me.lbMoneda1.Size = New System.Drawing.Size(19, 21)
        Me.lbMoneda1.TabIndex = 199
        Me.lbMoneda1.Text = "€"
        '
        'lbMoneda3
        '
        Me.lbMoneda3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda3.AutoSize = True
        Me.lbMoneda3.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda3.Location = New System.Drawing.Point(239, 560)
        Me.lbMoneda3.Name = "lbMoneda3"
        Me.lbMoneda3.Size = New System.Drawing.Size(19, 21)
        Me.lbMoneda3.TabIndex = 199
        Me.lbMoneda3.Text = "€"
        '
        'lbMoneda2
        '
        Me.lbMoneda2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda2.AutoSize = True
        Me.lbMoneda2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda2.Location = New System.Drawing.Point(370, 94)
        Me.lbMoneda2.Name = "lbMoneda2"
        Me.lbMoneda2.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda2.TabIndex = 199
        Me.lbMoneda2.Text = "€"
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(203, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(91, 50)
        Me.bGuardar.TabIndex = 7
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'ckDevuelto
        '
        Me.ckDevuelto.AutoSize = True
        Me.ckDevuelto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDevuelto.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckDevuelto.Location = New System.Drawing.Point(391, 92)
        Me.ckDevuelto.Name = "ckDevuelto"
        Me.ckDevuelto.Size = New System.Drawing.Size(90, 21)
        Me.ckDevuelto.TabIndex = 3
        Me.ckDevuelto.Text = "DEVUELTO"
        Me.ckDevuelto.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(396, 12)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(88, 50)
        Me.bBorrar.TabIndex = 9
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(301, 12)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 50)
        Me.bLimpiar.TabIndex = 8
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(493, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 10
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'subVencimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 594)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.lbMoneda3)
        Me.Controls.Add(Me.lbMoneda2)
        Me.Controls.Add(Me.lbMoneda1)
        Me.Controls.Add(Me.ckDevuelto)
        Me.Controls.Add(Me.ckCobrado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TotalFactura)
        Me.Controls.Add(Me.Restante)
        Me.Controls.Add(Me.Importe)
        Me.Controls.Add(Me.dtpVencimiento)
        Me.Controls.Add(Me.lvVencimientos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subVencimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENCIMIENTOS FACTURA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvVencimientos As System.Windows.Forms.ListView
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImprte As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Importe As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ckCobrado As System.Windows.Forms.CheckBox
    Friend WithEvents lvidVencimiento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImportex As System.Windows.Forms.ColumnHeader
    Friend WithEvents Restante As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TotalFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents ckDevuelto As System.Windows.Forms.CheckBox
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
End Class
