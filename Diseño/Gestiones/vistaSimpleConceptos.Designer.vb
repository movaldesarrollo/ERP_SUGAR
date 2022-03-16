<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vistaSimpleConceptos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vistaSimpleConceptos))
        Me.lvproduccionConceptos = New System.Windows.Forms.ListView
        Me.lvColIdCP = New System.Windows.Forms.ColumnHeader
        Me.lvColIdArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvColCod = New System.Windows.Forms.ColumnHeader
        Me.lvColArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvColVersion = New System.Windows.Forms.ColumnHeader
        Me.lvColEstado = New System.Windows.Forms.ColumnHeader
        Me.lvColCantidad = New System.Windows.Forms.ColumnHeader
        Me.lbTotalConceptos = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ESTADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.bBuscar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvproduccionConceptos
        '
        Me.lvproduccionConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvproduccionConceptos.CheckBoxes = True
        Me.lvproduccionConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvColIdCP, Me.lvColIdArticulo, Me.lvColCod, Me.lvColArticulo, Me.lvColVersion, Me.lvColEstado, Me.lvColCantidad})
        Me.lvproduccionConceptos.Font = New System.Drawing.Font("Century Gothic", 14.0!)
        Me.lvproduccionConceptos.FullRowSelect = True
        Me.lvproduccionConceptos.GridLines = True
        Me.lvproduccionConceptos.Location = New System.Drawing.Point(12, 89)
        Me.lvproduccionConceptos.MultiSelect = False
        Me.lvproduccionConceptos.Name = "lvproduccionConceptos"
        Me.lvproduccionConceptos.Size = New System.Drawing.Size(1529, 321)
        Me.lvproduccionConceptos.TabIndex = 147
        Me.lvproduccionConceptos.UseCompatibleStateImageBehavior = False
        Me.lvproduccionConceptos.View = System.Windows.Forms.View.Details
        '
        'lvColIdCP
        '
        Me.lvColIdCP.Text = ""
        Me.lvColIdCP.Width = 22
        '
        'lvColIdArticulo
        '
        Me.lvColIdArticulo.Text = "AID"
        Me.lvColIdArticulo.Width = 100
        '
        'lvColCod
        '
        Me.lvColCod.Text = "CÓDIGO ARTÍCULO"
        Me.lvColCod.Width = 200
        '
        'lvColArticulo
        '
        Me.lvColArticulo.Text = "ARTÍCULO"
        Me.lvColArticulo.Width = 875
        '
        'lvColVersion
        '
        Me.lvColVersion.Text = "VER."
        Me.lvColVersion.Width = 68
        '
        'lvColEstado
        '
        Me.lvColEstado.Text = "ESTADO"
        Me.lvColEstado.Width = 145
        '
        'lvColCantidad
        '
        Me.lvColCantidad.Text = "QTY"
        Me.lvColCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColCantidad.Width = 100
        '
        'lbTotalConceptos
        '
        Me.lbTotalConceptos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTotalConceptos.AutoSize = True
        Me.lbTotalConceptos.Font = New System.Drawing.Font("Century Gothic", 14.0!)
        Me.lbTotalConceptos.Location = New System.Drawing.Point(12, 413)
        Me.lbTotalConceptos.Name = "lbTotalConceptos"
        Me.lbTotalConceptos.Size = New System.Drawing.Size(162, 22)
        Me.lbTotalConceptos.TabIndex = 148
        Me.lbTotalConceptos.Text = "TOTAL PEDIDOS: "
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 14.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(1379, 413)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 22)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "RECAMBIOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ESTADOToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(132, 26)
        '
        'ESTADOToolStripMenuItem
        '
        Me.ESTADOToolStripMenuItem.Name = "ESTADOToolStripMenuItem"
        Me.ESTADOToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.ESTADOToolStripMenuItem.Text = "PRODUCIR"
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(1365, 22)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(85, 50)
        Me.bBuscar.TabIndex = 152
        Me.bBuscar.Text = "PRODUCIR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1456, 22)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 151
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 153
        Me.PictureBox1.TabStop = False
        '
        'vistaSimpleConceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1553, 444)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbTotalConceptos)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.lvproduccionConceptos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "vistaSimpleConceptos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONCEPTOS DEL PEDIDO "
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvproduccionConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvColIdArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCod As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColIdCP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbTotalConceptos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ESTADOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
