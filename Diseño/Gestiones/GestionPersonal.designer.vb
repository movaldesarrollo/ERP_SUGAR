<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionPersonal))
        Me.Label6 = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbPerfil = New System.Windows.Forms.ComboBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.Usuario = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Contrasena2 = New System.Windows.Forms.TextBox
        Me.Contrasena1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ckRecibeAvisos = New System.Windows.Forms.CheckBox
        Me.ckResponsablePR = New System.Windows.Forms.CheckBox
        Me.ckResponsable = New System.Windows.Forms.CheckBox
        Me.ckValida = New System.Windows.Forms.CheckBox
        Me.cbDepartamento = New System.Windows.Forms.ComboBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Mail = New System.Windows.Forms.TextBox
        Me.Apellidos = New System.Windows.Forms.TextBox
        Me.lbcorreo = New System.Windows.Forms.Label
        Me.codPersonal = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lvPersonas = New System.Windows.Forms.ListView
        Me.lvidPersona = New System.Windows.Forms.ColumnHeader
        Me.lvcodPersonal = New System.Windows.Forms.ColumnHeader
        Me.lvNombre = New System.Windows.Forms.ColumnHeader
        Me.lvApellidos = New System.Windows.Forms.ColumnHeader
        Me.lvDepartamento = New System.Windows.Forms.ColumnHeader
        Me.lvValida = New System.Windows.Forms.ColumnHeader
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(16, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "NOMBRE"
        '
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(126, 20)
        Me.Nombre.MaxLength = 50
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(213, 23)
        Me.Nombre.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.ckRecibeAvisos)
        Me.GroupBox1.Controls.Add(Me.ckResponsablePR)
        Me.GroupBox1.Controls.Add(Me.ckResponsable)
        Me.GroupBox1.Controls.Add(Me.ckValida)
        Me.GroupBox1.Controls.Add(Me.cbDepartamento)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Mail)
        Me.GroupBox1.Controls.Add(Me.Apellidos)
        Me.GroupBox1.Controls.Add(Me.lbcorreo)
        Me.GroupBox1.Controls.Add(Me.codPersonal)
        Me.GroupBox1.Controls.Add(Me.Nombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lvPersonas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(702, 579)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbPerfil)
        Me.GroupBox2.Controls.Add(Me.ckActivo)
        Me.GroupBox2.Controls.Add(Me.Usuario)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Contrasena2)
        Me.GroupBox2.Controls.Add(Me.Contrasena1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(675, 112)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS SESIÓN"
        '
        'cbPerfil
        '
        Me.cbPerfil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPerfil.FormattingEnabled = True
        Me.cbPerfil.Location = New System.Drawing.Point(488, 19)
        Me.cbPerfil.MaxLength = 15
        Me.cbPerfil.Name = "cbPerfil"
        Me.cbPerfil.Size = New System.Drawing.Size(170, 25)
        Me.cbPerfil.TabIndex = 4
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(347, 56)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 3
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'Usuario
        '
        Me.Usuario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Usuario.Location = New System.Drawing.Point(119, 20)
        Me.Usuario.MaxLength = 15
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Size = New System.Drawing.Size(213, 23)
        Me.Usuario.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(436, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "PERFIL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "USUARIO"
        '
        'Contrasena2
        '
        Me.Contrasena2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contrasena2.Location = New System.Drawing.Point(119, 79)
        Me.Contrasena2.MaxLength = 15
        Me.Contrasena2.Name = "Contrasena2"
        Me.Contrasena2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Contrasena2.Size = New System.Drawing.Size(213, 23)
        Me.Contrasena2.TabIndex = 2
        '
        'Contrasena1
        '
        Me.Contrasena1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contrasena1.Location = New System.Drawing.Point(119, 53)
        Me.Contrasena1.MaxLength = 15
        Me.Contrasena1.Name = "Contrasena1"
        Me.Contrasena1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Contrasena1.Size = New System.Drawing.Size(213, 23)
        Me.Contrasena1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CONTRASEÑA"
        '
        'ckRecibeAvisos
        '
        Me.ckRecibeAvisos.AutoSize = True
        Me.ckRecibeAvisos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRecibeAvisos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRecibeAvisos.Location = New System.Drawing.Point(565, 109)
        Me.ckRecibeAvisos.Name = "ckRecibeAvisos"
        Me.ckRecibeAvisos.Size = New System.Drawing.Size(118, 21)
        Me.ckRecibeAvisos.TabIndex = 7
        Me.ckRecibeAvisos.Text = "RECIBE AVISOS"
        Me.ckRecibeAvisos.UseVisualStyleBackColor = True
        '
        'ckResponsablePR
        '
        Me.ckResponsablePR.AutoSize = True
        Me.ckResponsablePR.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckResponsablePR.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckResponsablePR.Location = New System.Drawing.Point(355, 109)
        Me.ckResponsablePR.Name = "ckResponsablePR"
        Me.ckResponsablePR.Size = New System.Drawing.Size(207, 21)
        Me.ckResponsablePR.TabIndex = 6
        Me.ckResponsablePR.Text = "RESPONSABLE PRODUCCIÓN"
        Me.ckResponsablePR.UseVisualStyleBackColor = True
        '
        'ckResponsable
        '
        Me.ckResponsable.AutoSize = True
        Me.ckResponsable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckResponsable.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckResponsable.Location = New System.Drawing.Point(355, 85)
        Me.ckResponsable.Name = "ckResponsable"
        Me.ckResponsable.Size = New System.Drawing.Size(166, 21)
        Me.ckResponsable.TabIndex = 4
        Me.ckResponsable.Text = "RESPONSABLE CUENTA"
        Me.ckResponsable.UseVisualStyleBackColor = True
        '
        'ckValida
        '
        Me.ckValida.AutoSize = True
        Me.ckValida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckValida.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckValida.Location = New System.Drawing.Point(565, 84)
        Me.ckValida.Name = "ckValida"
        Me.ckValida.Size = New System.Drawing.Size(132, 21)
        Me.ckValida.TabIndex = 5
        Me.ckValida.Text = "VALIDA PEDIDOS"
        Me.ckValida.UseVisualStyleBackColor = True
        '
        'cbDepartamento
        '
        Me.cbDepartamento.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(126, 81)
        Me.cbDepartamento.MaxLength = 15
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(213, 25)
        Me.cbDepartamento.TabIndex = 3
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(16, 85)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 17)
        Me.Label39.TabIndex = 66
        Me.Label39.Text = "DEPARTAMENTO"
        '
        'Mail
        '
        Me.Mail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mail.Location = New System.Drawing.Point(126, 134)
        Me.Mail.MaxLength = 200
        Me.Mail.Name = "Mail"
        Me.Mail.Size = New System.Drawing.Size(540, 23)
        Me.Mail.TabIndex = 8
        '
        'Apellidos
        '
        Me.Apellidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Apellidos.Location = New System.Drawing.Point(126, 51)
        Me.Apellidos.MaxLength = 60
        Me.Apellidos.Name = "Apellidos"
        Me.Apellidos.Size = New System.Drawing.Size(540, 23)
        Me.Apellidos.TabIndex = 2
        '
        'lbcorreo
        '
        Me.lbcorreo.AutoSize = True
        Me.lbcorreo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbcorreo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbcorreo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbcorreo.Location = New System.Drawing.Point(16, 137)
        Me.lbcorreo.Name = "lbcorreo"
        Me.lbcorreo.Size = New System.Drawing.Size(44, 17)
        Me.lbcorreo.TabIndex = 10
        Me.lbcorreo.Text = "EMAIL"
        '
        'codPersonal
        '
        Me.codPersonal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codPersonal.Location = New System.Drawing.Point(496, 19)
        Me.codPersonal.MaxLength = 50
        Me.codPersonal.Name = "codPersonal"
        Me.codPersonal.Size = New System.Drawing.Size(170, 23)
        Me.codPersonal.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(16, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "APELLIDOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(416, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "CÓDIGO"
        '
        'lvPersonas
        '
        Me.lvPersonas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPersonas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidPersona, Me.lvcodPersonal, Me.lvNombre, Me.lvApellidos, Me.lvDepartamento, Me.lvValida})
        Me.lvPersonas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPersonas.FullRowSelect = True
        Me.lvPersonas.GridLines = True
        Me.lvPersonas.Location = New System.Drawing.Point(8, 287)
        Me.lvPersonas.MultiSelect = False
        Me.lvPersonas.Name = "lvPersonas"
        Me.lvPersonas.Size = New System.Drawing.Size(675, 280)
        Me.lvPersonas.TabIndex = 9
        Me.lvPersonas.UseCompatibleStateImageBehavior = False
        Me.lvPersonas.View = System.Windows.Forms.View.Details
        '
        'lvidPersona
        '
        Me.lvidPersona.Text = "idPersona"
        Me.lvidPersona.Width = 0
        '
        'lvcodPersonal
        '
        Me.lvcodPersonal.Text = "CÓDIGO"
        Me.lvcodPersonal.Width = 71
        '
        'lvNombre
        '
        Me.lvNombre.Text = "NOMBRE"
        Me.lvNombre.Width = 142
        '
        'lvApellidos
        '
        Me.lvApellidos.Text = "APELLIDOS"
        Me.lvApellidos.Width = 210
        '
        'lvDepartamento
        '
        Me.lvDepartamento.Text = "DEPARTAMENTO"
        Me.lvDepartamento.Width = 124
        '
        'lvValida
        '
        Me.lvValida.Text = "VALIDA PED."
        Me.lvValida.Width = 96
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(507, 20)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(90, 50)
        Me.bBorrar.TabIndex = 4
        Me.bBorrar.TabStop = False
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(287, 20)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(90, 50)
        Me.bNuevo.TabIndex = 2
        Me.bNuevo.TabStop = False
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(397, 20)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(90, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(617, 20)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(90, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(11, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'GestionPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 662)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE PERSONAL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvPersonas As System.Windows.Forms.ListView
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDepartamento As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Apellidos As System.Windows.Forms.TextBox
    Friend WithEvents lvidPersona As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lvApellidos As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Contrasena1 As System.Windows.Forms.TextBox
    Friend WithEvents Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Contrasena2 As System.Windows.Forms.TextBox
    Friend WithEvents Mail As System.Windows.Forms.TextBox
    Friend WithEvents lbcorreo As System.Windows.Forms.Label
    Friend WithEvents ckValida As System.Windows.Forms.CheckBox
    Friend WithEvents lvValida As System.Windows.Forms.ColumnHeader
    Friend WithEvents codPersonal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvcodPersonal As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ckResponsable As System.Windows.Forms.CheckBox
    Friend WithEvents ckResponsablePR As System.Windows.Forms.CheckBox
    Friend WithEvents ckRecibeAvisos As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
