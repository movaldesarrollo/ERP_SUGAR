<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlujoSiguiente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlujoSiguiente))
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.bAnadir = New System.Windows.Forms.Button
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvRefCliente = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvid = New System.Windows.Forms.ColumnHeader
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.lbFecha = New System.Windows.Forms.Label
        Me.lbRefCliente = New System.Windows.Forms.Label
        Me.ReferenciaCliente = New System.Windows.Forms.TextBox
        Me.gbNuevo = New System.Windows.Forms.GroupBox
        Me.lbRefCliente2 = New System.Windows.Forms.Label
        Me.RefCliente2 = New System.Windows.Forms.TextBox
        Me.lbFechaEntrega = New System.Windows.Forms.Label
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.gbAgregar = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.gbNuevo.SuspendLayout()
        Me.gbAgregar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(171, 14)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(110, 62)
        Me.bNuevo.TabIndex = 2
        Me.bNuevo.Text = "NUEVO PEDIDO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(427, 14)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(110, 62)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bAnadir
        '
        Me.bAnadir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAnadir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAnadir.Location = New System.Drawing.Point(299, 14)
        Me.bAnadir.Name = "bAnadir"
        Me.bAnadir.Size = New System.Drawing.Size(110, 62)
        Me.bAnadir.TabIndex = 3
        Me.bAnadir.Text = "AÑADIR A PRODUCCIÓN"
        Me.bAnadir.UseVisualStyleBackColor = True
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
        Me.lvConceptos.Size = New System.Drawing.Size(511, 216)
        Me.lvConceptos.TabIndex = 0
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.Text = "PEDIDO"
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
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFecha.Location = New System.Drawing.Point(13, 34)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(50, 17)
        Me.lbFecha.TabIndex = 117
        Me.lbFecha.Text = "FECHA"
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
        'ReferenciaCliente
        '
        Me.ReferenciaCliente.BackColor = System.Drawing.SystemColors.Window
        Me.ReferenciaCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferenciaCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReferenciaCliente.Location = New System.Drawing.Point(397, 31)
        Me.ReferenciaCliente.MaxLength = 20
        Me.ReferenciaCliente.Name = "ReferenciaCliente"
        Me.ReferenciaCliente.Size = New System.Drawing.Size(120, 23)
        Me.ReferenciaCliente.TabIndex = 2
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
        Me.gbNuevo.Location = New System.Drawing.Point(13, 88)
        Me.gbNuevo.Name = "gbNuevo"
        Me.gbNuevo.Size = New System.Drawing.Size(524, 108)
        Me.gbNuevo.TabIndex = 0
        Me.gbNuevo.TabStop = False
        Me.gbNuevo.Text = "NUEVO"
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
        'lbFechaEntrega
        '
        Me.lbFechaEntrega.AutoSize = True
        Me.lbFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaEntrega.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaEntrega.Location = New System.Drawing.Point(13, 66)
        Me.lbFechaEntrega.Name = "lbFechaEntrega"
        Me.lbFechaEntrega.Size = New System.Drawing.Size(111, 17)
        Me.lbFechaEntrega.TabIndex = 117
        Me.lbFechaEntrega.Text = "FECHA ENTREGA"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(148, 63)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(120, 23)
        Me.dtpFechaEntrega.TabIndex = 1
        Me.dtpFechaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
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
        Me.gbAgregar.Size = New System.Drawing.Size(525, 252)
        Me.gbAgregar.TabIndex = 1
        Me.gbAgregar.TabStop = False
        Me.gbAgregar.Text = "AGREGAR"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(10, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'FlujoSiguiente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 470)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbAgregar)
        Me.Controls.Add(Me.gbNuevo)
        Me.Controls.Add(Me.bAnadir)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FlujoSiguiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OFERTA A PEDIDO"
        Me.gbNuevo.ResumeLayout(False)
        Me.gbNuevo.PerformLayout()
        Me.gbAgregar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bAnadir As System.Windows.Forms.Button
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents lbRefCliente As System.Windows.Forms.Label
    Friend WithEvents ReferenciaCliente As System.Windows.Forms.TextBox
    Friend WithEvents gbNuevo As System.Windows.Forms.GroupBox
    Friend WithEvents gbAgregar As System.Windows.Forms.GroupBox
    Friend WithEvents lbFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvRefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbRefCliente2 As System.Windows.Forms.Label
    Friend WithEvents RefCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents lvid As System.Windows.Forms.ColumnHeader
End Class
