<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedaPedidosProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busquedaPedidosProduccion))
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.RefCliente = New System.Windows.Forms.TextBox
        Me.dtpHastaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpHastaPedido = New System.Windows.Forms.DateTimePicker
        Me.dtpDesdeEntrega = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpDesdePedido = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvEntrega = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvRefCliente = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.bListadoDetallado = New System.Windows.Forms.Button
        Me.bListado = New System.Windows.Forms.Button
        Me.frdatosgenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.Label57)
        Me.frdatosgenerales.Controls.Add(Me.cbEstado)
        Me.frdatosgenerales.Controls.Add(Me.Label8)
        Me.frdatosgenerales.Controls.Add(Me.numPedido)
        Me.frdatosgenerales.Controls.Add(Me.RefCliente)
        Me.frdatosgenerales.Controls.Add(Me.dtpHastaEntrega)
        Me.frdatosgenerales.Controls.Add(Me.dtpHastaPedido)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesdeEntrega)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesdePedido)
        Me.frdatosgenerales.Controls.Add(Me.Label12)
        Me.frdatosgenerales.Controls.Add(Me.Label11)
        Me.frdatosgenerales.Controls.Add(Me.Label13)
        Me.frdatosgenerales.Controls.Add(Me.Label2)
        Me.frdatosgenerales.Controls.Add(Me.cbCliente)
        Me.frdatosgenerales.Controls.Add(Me.Label42)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 97)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(833, 127)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(539, 95)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(56, 17)
        Me.Label57.TabIndex = 192
        Me.Label57.Text = "ESTADO"
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(604, 91)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(187, 25)
        Me.cbEstado.Sorted = True
        Me.cbEstado.TabIndex = 191
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(318, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 17)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "PEDIDO CLIENTE"
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numPedido.Location = New System.Drawing.Point(111, 33)
        Me.numPedido.MaxLength = 20
        Me.numPedido.Name = "numPedido"
        Me.numPedido.Size = New System.Drawing.Size(107, 23)
        Me.numPedido.TabIndex = 0
        '
        'RefCliente
        '
        Me.RefCliente.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente.Location = New System.Drawing.Point(432, 33)
        Me.RefCliente.MaxLength = 20
        Me.RefCliente.Name = "RefCliente"
        Me.RefCliente.Size = New System.Drawing.Size(107, 23)
        Me.RefCliente.TabIndex = 1
        '
        'dtpHastaEntrega
        '
        Me.dtpHastaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaEntrega.Location = New System.Drawing.Point(702, 62)
        Me.dtpHastaEntrega.Name = "dtpHastaEntrega"
        Me.dtpHastaEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaEntrega.TabIndex = 6
        Me.dtpHastaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpHastaPedido
        '
        Me.dtpHastaPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaPedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaPedido.Location = New System.Drawing.Point(604, 62)
        Me.dtpHastaPedido.Name = "dtpHastaPedido"
        Me.dtpHastaPedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaPedido.TabIndex = 5
        Me.dtpHastaPedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpDesdeEntrega
        '
        Me.dtpDesdeEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdeEntrega.Location = New System.Drawing.Point(702, 33)
        Me.dtpDesdeEntrega.Name = "dtpDesdeEntrega"
        Me.dtpDesdeEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdeEntrega.TabIndex = 3
        Me.dtpDesdeEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(546, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'dtpDesdePedido
        '
        Me.dtpDesdePedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdePedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdePedido.Location = New System.Drawing.Point(604, 33)
        Me.dtpDesdePedido.Name = "dtpDesdePedido"
        Me.dtpDesdePedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdePedido.TabIndex = 2
        Me.dtpDesdePedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(713, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 17)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "ENTREGA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(619, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 17)
        Me.Label11.TabIndex = 117
        Me.Label11.Text = "PEDIDO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(546, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(9, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "CLIENTE"
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(111, 62)
        Me.cbCliente.MaxLength = 15
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(428, 25)
        Me.cbCliente.TabIndex = 4
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(9, 36)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(94, 17)
        Me.Label42.TabIndex = 102
        Me.Label42.Text = "NÚM. PEDIDO"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(613, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(90, 50)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(510, 23)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(90, 50)
        Me.bLimpiar.TabIndex = 4
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lvDocumentos
        '
        Me.lvDocumentos.AllowColumnReorder = True
        Me.lvDocumentos.AllowDrop = True
        Me.lvDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDocumentos.AutoArrange = False
        Me.lvDocumentos.BackgroundImageTiled = True
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvCliente, Me.lvFecha, Me.lvEntrega, Me.lvEstado, Me.lvRefCliente})
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(11, 230)
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(692, 501)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.DisplayIndex = 1
        Me.lvnum.Text = "NÚM.PEDIDO"
        Me.lvnum.Width = 89
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 3
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 270
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 0
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 107
        '
        'lvEntrega
        '
        Me.lvEntrega.DisplayIndex = 4
        Me.lvEntrega.Text = "ENTREGA"
        Me.lvEntrega.Width = 107
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 5
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 100
        '
        'lvRefCliente
        '
        Me.lvRefCliente.DisplayIndex = 2
        Me.lvRefCliente.Text = "PED. CLIENTE"
        Me.lvRefCliente.Width = 118
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(643, 740)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 2
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(533, 743)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 190
        Me.Label6.Text = "ENCONTRADOS"
        '
        'bListadoDetallado
        '
        Me.bListadoDetallado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListadoDetallado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListadoDetallado.Location = New System.Drawing.Point(548, 23)
        Me.bListadoDetallado.Name = "bListadoDetallado"
        Me.bListadoDetallado.Size = New System.Drawing.Size(90, 50)
        Me.bListadoDetallado.TabIndex = 191
        Me.bListadoDetallado.Text = "LISTADO DETALLADO"
        Me.bListadoDetallado.UseVisualStyleBackColor = True
        '
        'bListado
        '
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(445, 23)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(90, 50)
        Me.bListado.TabIndex = 191
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'busquedaPedidosProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 778)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.bListadoDetallado)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busquedaPedidosProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN LOGÍSTICA"
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDesdePedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpHastaPedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvRefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RefCliente As System.Windows.Forms.TextBox
    Friend WithEvents dtpHastaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesdeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvEntrega As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents bListadoDetallado As System.Windows.Forms.Button
    Friend WithEvents bListado As System.Windows.Forms.Button
End Class
