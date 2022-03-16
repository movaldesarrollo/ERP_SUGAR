<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionTiposCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionTiposCompra))
        Me.Label6 = New System.Windows.Forms.Label
        Me.TipoCompra = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Grvalidacion = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbMails = New System.Windows.Forms.ListBox
        Me.Mail = New System.Windows.Forms.TextBox
        Me.bBorrarMail = New System.Windows.Forms.Button
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.bNuevoMail = New System.Windows.Forms.Button
        Me.ckTransporte = New System.Windows.Forms.CheckBox
        Me.ckValidacion = New System.Windows.Forms.CheckBox
        Me.lvTiposCompra = New System.Windows.Forms.ListView
        Me.lvIDTipo = New System.Windows.Forms.ColumnHeader
        Me.lvTipoCompra = New System.Windows.Forms.ColumnHeader
        Me.lvTransporte = New System.Windows.Forms.ColumnHeader
        Me.lvValidacion = New System.Windows.Forms.ColumnHeader
        Me.lvAviso = New System.Windows.Forms.ColumnHeader
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grvalidacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "TIPO PROVEEDOR"
        '
        'TipoCompra
        '
        Me.TipoCompra.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoCompra.Location = New System.Drawing.Point(131, 22)
        Me.TipoCompra.MaxLength = 40
        Me.TipoCompra.Name = "TipoCompra"
        Me.TipoCompra.Size = New System.Drawing.Size(238, 23)
        Me.TipoCompra.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Grvalidacion)
        Me.GroupBox1.Controls.Add(Me.TipoCompra)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ckTransporte)
        Me.GroupBox1.Controls.Add(Me.ckValidacion)
        Me.GroupBox1.Controls.Add(Me.lvTiposCompra)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 659)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'Grvalidacion
        '
        Me.Grvalidacion.Controls.Add(Me.Label5)
        Me.Grvalidacion.Controls.Add(Me.Label2)
        Me.Grvalidacion.Controls.Add(Me.lbMails)
        Me.Grvalidacion.Controls.Add(Me.Mail)
        Me.Grvalidacion.Controls.Add(Me.bBorrarMail)
        Me.Grvalidacion.Controls.Add(Me.Observaciones)
        Me.Grvalidacion.Controls.Add(Me.bNuevoMail)
        Me.Grvalidacion.Enabled = False
        Me.Grvalidacion.Location = New System.Drawing.Point(6, 60)
        Me.Grvalidacion.Name = "Grvalidacion"
        Me.Grvalidacion.Size = New System.Drawing.Size(664, 150)
        Me.Grvalidacion.TabIndex = 3
        Me.Grvalidacion.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(368, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 17)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "EMAILS VALIDACIÓN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(1, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "OBSERVACIONES"
        '
        'lbMails
        '
        Me.lbMails.BackColor = System.Drawing.Color.White
        Me.lbMails.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMails.FormattingEnabled = True
        Me.lbMails.ItemHeight = 17
        Me.lbMails.Location = New System.Drawing.Point(369, 63)
        Me.lbMails.Name = "lbMails"
        Me.lbMails.Size = New System.Drawing.Size(289, 72)
        Me.lbMails.Sorted = True
        Me.lbMails.TabIndex = 4
        '
        'Mail
        '
        Me.Mail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mail.Location = New System.Drawing.Point(369, 36)
        Me.Mail.MaxLength = 50
        Me.Mail.Name = "Mail"
        Me.Mail.Size = New System.Drawing.Size(289, 23)
        Me.Mail.TabIndex = 1
        '
        'bBorrarMail
        '
        Me.bBorrarMail.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.bBorrarMail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bBorrarMail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarMail.Location = New System.Drawing.Point(525, 13)
        Me.bBorrarMail.Name = "bBorrarMail"
        Me.bBorrarMail.Size = New System.Drawing.Size(20, 20)
        Me.bBorrarMail.TabIndex = 3
        Me.bBorrarMail.Text = "-"
        Me.bBorrarMail.UseCompatibleTextRendering = True
        Me.bBorrarMail.UseVisualStyleBackColor = False
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(4, 36)
        Me.Observaciones.MaxLength = 100
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(359, 99)
        Me.Observaciones.TabIndex = 0
        '
        'bNuevoMail
        '
        Me.bNuevoMail.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.bNuevoMail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.bNuevoMail.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoMail.Location = New System.Drawing.Point(503, 13)
        Me.bNuevoMail.Name = "bNuevoMail"
        Me.bNuevoMail.Size = New System.Drawing.Size(20, 20)
        Me.bNuevoMail.TabIndex = 2
        Me.bNuevoMail.Text = "+"
        Me.bNuevoMail.UseCompatibleTextRendering = True
        Me.bNuevoMail.UseVisualStyleBackColor = False
        '
        'ckTransporte
        '
        Me.ckTransporte.AutoSize = True
        Me.ckTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTransporte.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckTransporte.Location = New System.Drawing.Point(559, 23)
        Me.ckTransporte.Name = "ckTransporte"
        Me.ckTransporte.Size = New System.Drawing.Size(104, 21)
        Me.ckTransporte.TabIndex = 2
        Me.ckTransporte.Text = "TRANSPORTE"
        Me.ckTransporte.UseVisualStyleBackColor = True
        '
        'ckValidacion
        '
        Me.ckValidacion.AutoSize = True
        Me.ckValidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValidacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValidacion.Location = New System.Drawing.Point(402, 23)
        Me.ckValidacion.Name = "ckValidacion"
        Me.ckValidacion.Size = New System.Drawing.Size(144, 21)
        Me.ckValidacion.TabIndex = 1
        Me.ckValidacion.Text = "REQUIERE VALIDAR"
        Me.ckValidacion.UseVisualStyleBackColor = True
        '
        'lvTiposCompra
        '
        Me.lvTiposCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTiposCompra.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvIDTipo, Me.lvTipoCompra, Me.lvTransporte, Me.lvValidacion, Me.lvAviso})
        Me.lvTiposCompra.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTiposCompra.FullRowSelect = True
        Me.lvTiposCompra.GridLines = True
        Me.lvTiposCompra.Location = New System.Drawing.Point(6, 216)
        Me.lvTiposCompra.MultiSelect = False
        Me.lvTiposCompra.Name = "lvTiposCompra"
        Me.lvTiposCompra.ShowItemToolTips = True
        Me.lvTiposCompra.Size = New System.Drawing.Size(664, 431)
        Me.lvTiposCompra.TabIndex = 4
        Me.lvTiposCompra.UseCompatibleStateImageBehavior = False
        Me.lvTiposCompra.View = System.Windows.Forms.View.Details
        '
        'lvIDTipo
        '
        Me.lvIDTipo.Text = "IDTipo"
        Me.lvIDTipo.Width = 0
        '
        'lvTipoCompra
        '
        Me.lvTipoCompra.Text = "DESCRIPCION"
        Me.lvTipoCompra.Width = 212
        '
        'lvTransporte
        '
        Me.lvTransporte.Text = "TRANSPORTE"
        Me.lvTransporte.Width = 87
        '
        'lvValidacion
        '
        Me.lvValidacion.Text = "VALIDAR"
        Me.lvValidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvValidacion.Width = 75
        '
        'lvAviso
        '
        Me.lvAviso.Text = "EMAILS VALIDACIÓN"
        Me.lvAviso.Width = 250
        '
        'bBorrar
        '
        Me.bBorrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrar.Enabled = False
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(477, 13)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 7
        Me.bBorrar.TabStop = False
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.bNuevo.Enabled = False
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(265, 13)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.TabStop = False
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(371, 13)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 6
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(583, 13)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'GestionTiposCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 730)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bBorrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionTiposCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIPOS DE PROVEEDORES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grvalidacion.ResumeLayout(False)
        Me.Grvalidacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TipoCompra As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvTiposCompra As System.Windows.Forms.ListView
    Friend WithEvents lvTipoCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvValidacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents lvIDTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckValidacion As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvAviso As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMails As System.Windows.Forms.ListBox
    Friend WithEvents bBorrarMail As System.Windows.Forms.Button
    Friend WithEvents bNuevoMail As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Mail As System.Windows.Forms.TextBox
    Friend WithEvents Grvalidacion As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ckTransporte As System.Windows.Forms.CheckBox
    Friend WithEvents lvTransporte As System.Windows.Forms.ColumnHeader
End Class
