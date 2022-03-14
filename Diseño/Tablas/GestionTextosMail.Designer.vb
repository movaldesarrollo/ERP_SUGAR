<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionTextosMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionTextosMail))
        Me.bSalir = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cbDocumento = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Asunto = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.bIncrustarFecha = New System.Windows.Forms.Button
        Me.bIncrustarFechaEntrega = New System.Windows.Forms.Button
        Me.bIncrustarContacto = New System.Windows.Forms.Button
        Me.bIncrustarDocumento = New System.Windows.Forms.Button
        Me.Texto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.cbIdioma = New System.Windows.Forms.ComboBox
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.lvidTexto = New System.Windows.Forms.ColumnHeader
        Me.lvDocumento = New System.Windows.Forms.ColumnHeader
        Me.lvIdioma = New System.Windows.Forms.ColumnHeader
        Me.lvAsunto = New System.Windows.Forms.ColumnHeader
        Me.lvTexto = New System.Windows.Forms.ColumnHeader
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(814, 16)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(514, 16)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 2
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'cbDocumento
        '
        Me.cbDocumento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDocumento.FormattingEnabled = True
        Me.cbDocumento.Location = New System.Drawing.Point(117, 20)
        Me.cbDocumento.MaxLength = 30
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.Size = New System.Drawing.Size(215, 25)
        Me.cbDocumento.Sorted = True
        Me.cbDocumento.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(22, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 17)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "DOCUMENTO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Asunto)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.bIncrustarFecha)
        Me.GroupBox1.Controls.Add(Me.bIncrustarFechaEntrega)
        Me.GroupBox1.Controls.Add(Me.bIncrustarContacto)
        Me.GroupBox1.Controls.Add(Me.bIncrustarDocumento)
        Me.GroupBox1.Controls.Add(Me.Texto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.cbIdioma)
        Me.GroupBox1.Controls.Add(Me.cbDocumento)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(887, 161)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Asunto
        '
        Me.Asunto.BackColor = System.Drawing.SystemColors.Window
        Me.Asunto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Asunto.Location = New System.Drawing.Point(117, 48)
        Me.Asunto.MaxLength = 100
        Me.Asunto.Name = "Asunto"
        Me.Asunto.Size = New System.Drawing.Size(612, 23)
        Me.Asunto.TabIndex = 2
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label48.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(22, 49)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(57, 17)
        Me.Label48.TabIndex = 207
        Me.Label48.Text = "ASUNTO"
        '
        'bIncrustarFecha
        '
        Me.bIncrustarFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIncrustarFecha.Image = Global.ERP_SUGAR.My.Resources.Resources.AttachmentHS
        Me.bIncrustarFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bIncrustarFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bIncrustarFecha.Location = New System.Drawing.Point(744, 89)
        Me.bIncrustarFecha.Name = "bIncrustarFecha"
        Me.bIncrustarFecha.Size = New System.Drawing.Size(137, 28)
        Me.bIncrustarFecha.TabIndex = 6
        Me.bIncrustarFecha.Text = "FECHA "
        Me.bIncrustarFecha.UseVisualStyleBackColor = True
        '
        'bIncrustarFechaEntrega
        '
        Me.bIncrustarFechaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIncrustarFechaEntrega.Image = Global.ERP_SUGAR.My.Resources.Resources.AttachmentHS
        Me.bIncrustarFechaEntrega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bIncrustarFechaEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bIncrustarFechaEntrega.Location = New System.Drawing.Point(744, 124)
        Me.bIncrustarFechaEntrega.Name = "bIncrustarFechaEntrega"
        Me.bIncrustarFechaEntrega.Size = New System.Drawing.Size(137, 28)
        Me.bIncrustarFechaEntrega.TabIndex = 7
        Me.bIncrustarFechaEntrega.Text = "FECHA ENTREGA"
        Me.bIncrustarFechaEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bIncrustarFechaEntrega.UseVisualStyleBackColor = True
        '
        'bIncrustarContacto
        '
        Me.bIncrustarContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIncrustarContacto.Image = Global.ERP_SUGAR.My.Resources.Resources.AttachmentHS
        Me.bIncrustarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bIncrustarContacto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bIncrustarContacto.Location = New System.Drawing.Point(744, 54)
        Me.bIncrustarContacto.Name = "bIncrustarContacto"
        Me.bIncrustarContacto.Size = New System.Drawing.Size(137, 28)
        Me.bIncrustarContacto.TabIndex = 5
        Me.bIncrustarContacto.Text = "CONTACTO"
        Me.bIncrustarContacto.UseVisualStyleBackColor = True
        '
        'bIncrustarDocumento
        '
        Me.bIncrustarDocumento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIncrustarDocumento.Image = Global.ERP_SUGAR.My.Resources.Resources.AttachmentHS
        Me.bIncrustarDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bIncrustarDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bIncrustarDocumento.Location = New System.Drawing.Point(744, 19)
        Me.bIncrustarDocumento.Name = "bIncrustarDocumento"
        Me.bIncrustarDocumento.Size = New System.Drawing.Size(137, 28)
        Me.bIncrustarDocumento.TabIndex = 4
        Me.bIncrustarDocumento.Text = "DOCUMENTO"
        Me.bIncrustarDocumento.UseVisualStyleBackColor = True
        '
        'Texto
        '
        Me.Texto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Texto.Location = New System.Drawing.Point(117, 74)
        Me.Texto.Multiline = True
        Me.Texto.Name = "Texto"
        Me.Texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Texto.Size = New System.Drawing.Size(612, 81)
        Me.Texto.TabIndex = 3
        Me.Texto.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(22, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 17)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "TEXTO"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(513, 24)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 17)
        Me.Label38.TabIndex = 203
        Me.Label38.Text = "IDIOMA"
        '
        'cbIdioma
        '
        Me.cbIdioma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIdioma.FormattingEnabled = True
        Me.cbIdioma.Location = New System.Drawing.Point(592, 20)
        Me.cbIdioma.Name = "cbIdioma"
        Me.cbIdioma.Size = New System.Drawing.Size(137, 25)
        Me.cbIdioma.TabIndex = 1
        '
        'lvDocumentos
        '
        Me.lvDocumentos.AllowColumnReorder = True
        Me.lvDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDocumentos.AutoArrange = False
        Me.lvDocumentos.BackgroundImageTiled = True
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidTexto, Me.lvDocumento, Me.lvIdioma, Me.lvAsunto, Me.lvTexto})
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(12, 250)
        Me.lvDocumentos.MultiSelect = False
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(887, 312)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'lvidTexto
        '
        Me.lvidTexto.Text = "idUbicacion"
        Me.lvidTexto.Width = 0
        '
        'lvDocumento
        '
        Me.lvDocumento.Text = "DOCUMENTO"
        Me.lvDocumento.Width = 117
        '
        'lvIdioma
        '
        Me.lvIdioma.Text = "IDIOMA"
        Me.lvIdioma.Width = 101
        '
        'lvAsunto
        '
        Me.lvAsunto.Text = "ASUNTO"
        Me.lvAsunto.Width = 237
        '
        'lvTexto
        '
        Me.lvTexto.Text = "TEXTO"
        Me.lvTexto.Width = 403
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(614, 16)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 3
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(714, 16)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 4
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'GestionTextosMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 574)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionTextosMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE TEXTOS PARA MAIL"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents cbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cbIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents Texto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bIncrustarDocumento As System.Windows.Forms.Button
    Friend WithEvents bIncrustarContacto As System.Windows.Forms.Button
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents lvidTexto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvIdioma As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTexto As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents Asunto As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents lvAsunto As System.Windows.Forms.ColumnHeader
    Friend WithEvents bIncrustarFecha As System.Windows.Forms.Button
    Friend WithEvents bIncrustarFechaEntrega As System.Windows.Forms.Button
End Class
