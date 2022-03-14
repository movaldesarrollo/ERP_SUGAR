<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subPedidoStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subPedidoStock))
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvStock = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvDeStock = New System.Windows.Forms.ColumnHeader
        Me.lvProducir = New System.Windows.Forms.ColumnHeader
        Me.lvUnidades = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridad = New System.Windows.Forms.ColumnHeader
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.bProduccion = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbProd3 = New System.Windows.Forms.RadioButton
        Me.rbProd2 = New System.Windows.Forms.RadioButton
        Me.rbProd1 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.DeStock = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbUnidad2 = New System.Windows.Forms.Label
        Me.pbCarga = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidConcepto, Me.lvcodArticulo, Me.lvArticulo, Me.lvStock, Me.lvCantidad, Me.lvDeStock, Me.lvProducir, Me.lvUnidades, Me.lvPrioridad})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(17, 48)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(707, 197)
        Me.lvConceptos.TabIndex = 4
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 105
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTICULO"
        Me.lvArticulo.Width = 192
        '
        'lvStock
        '
        Me.lvStock.Text = "STOCK"
        Me.lvStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvStock.Width = 69
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 75
        '
        'lvDeStock
        '
        Me.lvDeStock.Text = "USAR STOCK"
        Me.lvDeStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvDeStock.Width = 87
        '
        'lvProducir
        '
        Me.lvProducir.Text = "PRODUCIR"
        Me.lvProducir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvProducir.Width = 81
        '
        'lvUnidades
        '
        Me.lvUnidades.Text = "u."
        Me.lvUnidades.Width = 31
        '
        'lvPrioridad
        '
        Me.lvPrioridad.Text = "PR."
        Me.lvPrioridad.Width = 31
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(632, 22)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 177
        Me.lbUnidad.Text = "U"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(508, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "PRODUCIR"
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(585, 19)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(44, 23)
        Me.Cantidad.TabIndex = 3
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(11, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 180
        Me.PictureBox1.TabStop = False
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(377, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(110, 50)
        Me.bGuardar.TabIndex = 1
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(623, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(110, 50)
        Me.bSalir.TabIndex = 3
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bProduccion
        '
        Me.bProduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bProduccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bProduccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bProduccion.Location = New System.Drawing.Point(500, 12)
        Me.bProduccion.Name = "bProduccion"
        Me.bProduccion.Size = New System.Drawing.Size(110, 50)
        Me.bProduccion.TabIndex = 2
        Me.bProduccion.Text = "PRODUCCIÓN"
        Me.bProduccion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbProd3)
        Me.GroupBox1.Controls.Add(Me.rbProd2)
        Me.GroupBox1.Controls.Add(Me.rbProd1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lvConceptos)
        Me.GroupBox1.Controls.Add(Me.DeStock)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Cantidad)
        Me.GroupBox1.Controls.Add(Me.lbUnidad2)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.lbUnidad)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(736, 251)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbProd3
        '
        Me.rbProd3.AutoSize = True
        Me.rbProd3.BackColor = System.Drawing.Color.LightGreen
        Me.rbProd3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd3.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd3.Location = New System.Drawing.Point(268, 20)
        Me.rbProd3.Name = "rbProd3"
        Me.rbProd3.Size = New System.Drawing.Size(33, 21)
        Me.rbProd3.TabIndex = 2
        Me.rbProd3.TabStop = True
        Me.rbProd3.Text = "3"
        Me.rbProd3.UseVisualStyleBackColor = False
        '
        'rbProd2
        '
        Me.rbProd2.AutoSize = True
        Me.rbProd2.BackColor = System.Drawing.Color.NavajoWhite
        Me.rbProd2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd2.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd2.Location = New System.Drawing.Point(235, 20)
        Me.rbProd2.Name = "rbProd2"
        Me.rbProd2.Size = New System.Drawing.Size(33, 21)
        Me.rbProd2.TabIndex = 1
        Me.rbProd2.TabStop = True
        Me.rbProd2.Text = "2"
        Me.rbProd2.UseVisualStyleBackColor = False
        '
        'rbProd1
        '
        Me.rbProd1.AutoSize = True
        Me.rbProd1.BackColor = System.Drawing.Color.Pink
        Me.rbProd1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd1.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd1.Location = New System.Drawing.Point(205, 20)
        Me.rbProd1.Name = "rbProd1"
        Me.rbProd1.Size = New System.Drawing.Size(33, 21)
        Me.rbProd1.TabIndex = 0
        Me.rbProd1.TabStop = True
        Me.rbProd1.Text = "1"
        Me.rbProd1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(126, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "PRIORIDAD"
        '
        'DeStock
        '
        Me.DeStock.BackColor = System.Drawing.SystemColors.Window
        Me.DeStock.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeStock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DeStock.Location = New System.Drawing.Point(415, 19)
        Me.DeStock.MaxLength = 15
        Me.DeStock.Name = "DeStock"
        Me.DeStock.Size = New System.Drawing.Size(44, 23)
        Me.DeStock.TabIndex = 3
        Me.DeStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(328, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "USAR STOCK"
        '
        'lbUnidad2
        '
        Me.lbUnidad2.AutoSize = True
        Me.lbUnidad2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad2.Location = New System.Drawing.Point(462, 22)
        Me.lbUnidad2.Name = "lbUnidad2"
        Me.lbUnidad2.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad2.TabIndex = 177
        Me.lbUnidad2.Text = "U"
        '
        'pbCarga
        '
        Me.pbCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCarga.Location = New System.Drawing.Point(31, 332)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(106, 15)
        Me.pbCarga.TabIndex = 197
        Me.pbCarga.Visible = False
        '
        'subPedidoStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 352)
        Me.Controls.Add(Me.pbCarga)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bProduccion)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subPedidoStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNAR CONCEPTOS DE PEDIDO A FABRICACIÓN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProducir As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bProduccion As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvPrioridad As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbProd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbProd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbProd1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvUnidades As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDeStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeStock As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbUnidad2 As System.Windows.Forms.Label
    Friend WithEvents pbCarga As System.Windows.Forms.ProgressBar
End Class
