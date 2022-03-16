<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TraspasarConceptoAlbaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TraspasarConceptoAlbaran))
        Me.gbAgregar = New System.Windows.Forms.GroupBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvRefCliente = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvid = New System.Windows.Forms.ColumnHeader
        Me.gbNuevo = New System.Windows.Forms.GroupBox
        Me.lbRefCliente2 = New System.Windows.Forms.Label
        Me.lbRefCliente = New System.Windows.Forms.Label
        Me.RefCliente2 = New System.Windows.Forms.TextBox
        Me.ReferenciaCliente = New System.Windows.Forms.TextBox
        Me.lbFechaEntrega = New System.Windows.Forms.Label
        Me.lbFecha = New System.Windows.Forms.Label
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bAnadir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.gbAgregar.SuspendLayout()
        Me.gbNuevo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAgregar
        '
        Me.gbAgregar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAgregar.Controls.Add(Me.lvConceptos)
        Me.gbAgregar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAgregar.Location = New System.Drawing.Point(13, 293)
        Me.gbAgregar.Name = "gbAgregar"
        Me.gbAgregar.Size = New System.Drawing.Size(525, 213)
        Me.gbAgregar.TabIndex = 2
        Me.gbAgregar.TabStop = False
        Me.gbAgregar.Text = "AGREGAR A ALBARÁN"
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvRefCliente, Me.lvFecha, Me.lvEstado, Me.lvid})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.Location = New System.Drawing.Point(8, 25)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.Size = New System.Drawing.Size(511, 177)
        Me.lvConceptos.TabIndex = 0
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.Text = "ALBARÁN"
        Me.lvnum.Width = 87
        '
        'lvRefCliente
        '
        Me.lvRefCliente.Text = "REFERENCIA"
        Me.lvRefCliente.Width = 125
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
        'lvid
        '
        Me.lvid.Text = "id"
        Me.lvid.Width = 0
        '
        'gbNuevo
        '
        Me.gbNuevo.Controls.Add(Me.lbRefCliente2)
        Me.gbNuevo.Controls.Add(Me.lbRefCliente)
        Me.gbNuevo.Controls.Add(Me.RefCliente2)
        Me.gbNuevo.Controls.Add(Me.ReferenciaCliente)
        Me.gbNuevo.Controls.Add(Me.lbFechaEntrega)
        Me.gbNuevo.Controls.Add(Me.lbFecha)
        Me.gbNuevo.Controls.Add(Me.dtpFechaEntrega)
        Me.gbNuevo.Controls.Add(Me.dtpFecha)
        Me.gbNuevo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNuevo.Location = New System.Drawing.Point(13, 178)
        Me.gbNuevo.Name = "gbNuevo"
        Me.gbNuevo.Size = New System.Drawing.Size(524, 108)
        Me.gbNuevo.TabIndex = 1
        Me.gbNuevo.TabStop = False
        Me.gbNuevo.Text = "NUEVO ALBARÁN"
        '
        'lbRefCliente2
        '
        Me.lbRefCliente2.AutoSize = True
        Me.lbRefCliente2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRefCliente2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbRefCliente2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbRefCliente2.Location = New System.Drawing.Point(282, 66)
        Me.lbRefCliente2.Name = "lbRefCliente2"
        Me.lbRefCliente2.Size = New System.Drawing.Size(97, 17)
        Me.lbRefCliente2.TabIndex = 119
        Me.lbRefCliente2.Text = "REF. CLIENTE 2"
        '
        'lbRefCliente
        '
        Me.lbRefCliente.AutoSize = True
        Me.lbRefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRefCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbRefCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbRefCliente.Location = New System.Drawing.Point(282, 34)
        Me.lbRefCliente.Name = "lbRefCliente"
        Me.lbRefCliente.Size = New System.Drawing.Size(86, 17)
        Me.lbRefCliente.TabIndex = 119
        Me.lbRefCliente.Text = "REF. CLIENTE"
        '
        'RefCliente2
        '
        Me.RefCliente2.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente2.Location = New System.Drawing.Point(397, 63)
        Me.RefCliente2.MaxLength = 20
        Me.RefCliente2.Name = "RefCliente2"
        Me.RefCliente2.Size = New System.Drawing.Size(120, 23)
        Me.RefCliente2.TabIndex = 3
        '
        'ReferenciaCliente
        '
        Me.ReferenciaCliente.BackColor = System.Drawing.SystemColors.Window
        Me.ReferenciaCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferenciaCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReferenciaCliente.Location = New System.Drawing.Point(397, 31)
        Me.ReferenciaCliente.MaxLength = 20
        Me.ReferenciaCliente.Name = "ReferenciaCliente"
        Me.ReferenciaCliente.Size = New System.Drawing.Size(120, 23)
        Me.ReferenciaCliente.TabIndex = 1
        '
        'lbFechaEntrega
        '
        Me.lbFechaEntrega.AutoSize = True
        Me.lbFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaEntrega.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaEntrega.Location = New System.Drawing.Point(34, 66)
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
        Me.lbFecha.Location = New System.Drawing.Point(34, 34)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(50, 17)
        Me.lbFecha.TabIndex = 117
        Me.lbFecha.Text = "FECHA"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(148, 63)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(120, 23)
        Me.dtpFechaEntrega.TabIndex = 2
        Me.dtpFechaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(148, 31)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(120, 23)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(171, 15)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(110, 62)
        Me.bNuevo.TabIndex = 3
        Me.bNuevo.Text = "NUEVO ALBARÁN"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(427, 15)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(110, 62)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 123
        Me.PictureBox1.TabStop = False
        '
        'bAnadir
        '
        Me.bAnadir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAnadir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAnadir.Location = New System.Drawing.Point(298, 15)
        Me.bAnadir.Name = "bAnadir"
        Me.bAnadir.Size = New System.Drawing.Size(110, 62)
        Me.bAnadir.TabIndex = 4
        Me.bAnadir.Text = "AÑADIR A ALBARÁN"
        Me.bAnadir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbUnidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Cantidad)
        Me.GroupBox1.Controls.Add(Me.Articulo)
        Me.GroupBox1.Controls.Add(Me.codArticulo)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CONCEPTO"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(195, 52)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 177
        Me.lbUnidad.Text = "U"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(34, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "ARTÍCULO"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(34, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 176
        Me.Label20.Text = "CANTIDAD"
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(148, 49)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(45, 23)
        Me.Cantidad.TabIndex = 2
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Window
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Articulo.Location = New System.Drawing.Point(285, 20)
        Me.Articulo.MaxLength = 20
        Me.Articulo.Multiline = True
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(232, 49)
        Me.Articulo.TabIndex = 1
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codArticulo.Location = New System.Drawing.Point(148, 20)
        Me.codArticulo.MaxLength = 20
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(120, 23)
        Me.codArticulo.TabIndex = 0
        '
        'TraspasarConceptoAlbaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 518)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bAnadir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbAgregar)
        Me.Controls.Add(Me.gbNuevo)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TraspasarConceptoAlbaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TRASPASAR CONCEPTO DE ALBARÁN"
        Me.gbAgregar.ResumeLayout(False)
        Me.gbNuevo.ResumeLayout(False)
        Me.gbNuevo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbAgregar As System.Windows.Forms.GroupBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvid As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbNuevo As System.Windows.Forms.GroupBox
    Friend WithEvents lbRefCliente2 As System.Windows.Forms.Label
    Friend WithEvents lbRefCliente As System.Windows.Forms.Label
    Friend WithEvents RefCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents ReferenciaCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bAnadir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
End Class
