<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionPermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionPermisos))
        Me.bSalir = New System.Windows.Forms.Button
        Me.gbUsuario = New System.Windows.Forms.GroupBox
        Me.lbInforma = New System.Windows.Forms.Label
        Me.lvPersonal = New System.Windows.Forms.ListView
        Me.lvidUsuario = New System.Windows.Forms.ColumnHeader
        Me.lvNombreC = New System.Windows.Forms.ColumnHeader
        Me.lvDepartamento = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.tvMenUsuario = New System.Windows.Forms.TreeView
        Me.bCopiarPerfil = New System.Windows.Forms.Button
        Me.bGuardarUsuario = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bGuardarPerfil = New System.Windows.Forms.Button
        Me.tvMenuPerfil = New System.Windows.Forms.TreeView
        Me.lvPerfiles = New System.Windows.Forms.ListView
        Me.lvidPerfil = New System.Windows.Forms.ColumnHeader
        Me.lvPerfil = New System.Windows.Forms.ColumnHeader
        Me.lvDescripcion = New System.Windows.Forms.ColumnHeader
        Me.gbPerfiles = New System.Windows.Forms.GroupBox
        Me.gbUsuario.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPerfiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(861, 25)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(95, 53)
        Me.bSalir.TabIndex = 155
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'gbUsuario
        '
        Me.gbUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbUsuario.Controls.Add(Me.tvMenUsuario)
        Me.gbUsuario.Controls.Add(Me.lbInforma)
        Me.gbUsuario.Controls.Add(Me.lvPersonal)
        Me.gbUsuario.Controls.Add(Me.bCopiarPerfil)
        Me.gbUsuario.Controls.Add(Me.bGuardarUsuario)
        Me.gbUsuario.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbUsuario.Location = New System.Drawing.Point(500, 93)
        Me.gbUsuario.Name = "gbUsuario"
        Me.gbUsuario.Size = New System.Drawing.Size(472, 676)
        Me.gbUsuario.TabIndex = 162
        Me.gbUsuario.TabStop = False
        Me.gbUsuario.Text = "USUARIOS"
        '
        'lbInforma
        '
        Me.lbInforma.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbInforma.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbInforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbInforma.Location = New System.Drawing.Point(22, 629)
        Me.lbInforma.Name = "lbInforma"
        Me.lbInforma.Size = New System.Drawing.Size(267, 29)
        Me.lbInforma.TabIndex = 159
        Me.lbInforma.Text = "PERMISOS DEL PERFIL"
        Me.lbInforma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvPersonal
        '
        Me.lvPersonal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPersonal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidUsuario, Me.lvNombreC, Me.lvDepartamento, Me.ColumnHeader4})
        Me.lvPersonal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPersonal.FullRowSelect = True
        Me.lvPersonal.GridLines = True
        Me.lvPersonal.HideSelection = False
        Me.lvPersonal.Location = New System.Drawing.Point(14, 27)
        Me.lvPersonal.MultiSelect = False
        Me.lvPersonal.Name = "lvPersonal"
        Me.lvPersonal.Size = New System.Drawing.Size(442, 135)
        Me.lvPersonal.TabIndex = 158
        Me.lvPersonal.UseCompatibleStateImageBehavior = False
        Me.lvPersonal.View = System.Windows.Forms.View.Details
        '
        'lvidUsuario
        '
        Me.lvidUsuario.Text = "idUsuario"
        Me.lvidUsuario.Width = 0
        '
        'lvNombreC
        '
        Me.lvNombreC.Text = "NOMBRE"
        Me.lvNombreC.Width = 231
        '
        'lvDepartamento
        '
        Me.lvDepartamento.Text = "DEPARTAMENTO"
        Me.lvDepartamento.Width = 174
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "PANTALLA"
        Me.ColumnHeader4.Width = 0
        '
        'tvMenUsuario
        '
        Me.tvMenUsuario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMenUsuario.CheckBoxes = True
        Me.tvMenUsuario.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMenUsuario.FullRowSelect = True
        Me.tvMenUsuario.HideSelection = False
        Me.tvMenUsuario.Location = New System.Drawing.Point(14, 172)
        Me.tvMenUsuario.Name = "tvMenUsuario"
        Me.tvMenUsuario.Size = New System.Drawing.Size(442, 498)
        Me.tvMenUsuario.TabIndex = 0
        '
        'bCopiarPerfil
        '
        Me.bCopiarPerfil.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCopiarPerfil.Cursor = System.Windows.Forms.Cursors.Default
        Me.bCopiarPerfil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCopiarPerfil.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCopiarPerfil.Location = New System.Drawing.Point(361, 617)
        Me.bCopiarPerfil.Name = "bCopiarPerfil"
        Me.bCopiarPerfil.Size = New System.Drawing.Size(95, 53)
        Me.bCopiarPerfil.TabIndex = 153
        Me.bCopiarPerfil.Text = "HEREDAR DEL PERFIL"
        Me.bCopiarPerfil.UseVisualStyleBackColor = True
        '
        'bGuardarUsuario
        '
        Me.bGuardarUsuario.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarUsuario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarUsuario.Location = New System.Drawing.Point(355, 677)
        Me.bGuardarUsuario.Name = "bGuardarUsuario"
        Me.bGuardarUsuario.Size = New System.Drawing.Size(95, 53)
        Me.bGuardarUsuario.TabIndex = 153
        Me.bGuardarUsuario.Text = "GUARDAR"
        Me.bGuardarUsuario.UseVisualStyleBackColor = True
        Me.bGuardarUsuario.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 163
        Me.PictureBox1.TabStop = False
        '
        'bGuardarPerfil
        '
        Me.bGuardarPerfil.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarPerfil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarPerfil.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarPerfil.Location = New System.Drawing.Point(371, 679)
        Me.bGuardarPerfil.Name = "bGuardarPerfil"
        Me.bGuardarPerfil.Size = New System.Drawing.Size(95, 53)
        Me.bGuardarPerfil.TabIndex = 153
        Me.bGuardarPerfil.Text = "GUARDAR"
        Me.bGuardarPerfil.UseVisualStyleBackColor = True
        Me.bGuardarPerfil.Visible = False
        '
        'tvMenuPerfil
        '
        Me.tvMenuPerfil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvMenuPerfil.CheckBoxes = True
        Me.tvMenuPerfil.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMenuPerfil.FullRowSelect = True
        Me.tvMenuPerfil.HideSelection = False
        Me.tvMenuPerfil.Location = New System.Drawing.Point(15, 172)
        Me.tvMenuPerfil.Name = "tvMenuPerfil"
        Me.tvMenuPerfil.Size = New System.Drawing.Size(442, 498)
        Me.tvMenuPerfil.TabIndex = 0
        '
        'lvPerfiles
        '
        Me.lvPerfiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidPerfil, Me.lvPerfil, Me.lvDescripcion})
        Me.lvPerfiles.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPerfiles.FullRowSelect = True
        Me.lvPerfiles.GridLines = True
        Me.lvPerfiles.HideSelection = False
        Me.lvPerfiles.Location = New System.Drawing.Point(15, 27)
        Me.lvPerfiles.MultiSelect = False
        Me.lvPerfiles.Name = "lvPerfiles"
        Me.lvPerfiles.Size = New System.Drawing.Size(442, 135)
        Me.lvPerfiles.TabIndex = 158
        Me.lvPerfiles.UseCompatibleStateImageBehavior = False
        Me.lvPerfiles.View = System.Windows.Forms.View.Details
        '
        'lvidPerfil
        '
        Me.lvidPerfil.Text = "idPerfil"
        Me.lvidPerfil.Width = 0
        '
        'lvPerfil
        '
        Me.lvPerfil.Text = "PERFIL"
        Me.lvPerfil.Width = 143
        '
        'lvDescripcion
        '
        Me.lvDescripcion.Text = "DESCRIPCIÓN"
        Me.lvDescripcion.Width = 277
        '
        'gbPerfiles
        '
        Me.gbPerfiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPerfiles.Controls.Add(Me.lvPerfiles)
        Me.gbPerfiles.Controls.Add(Me.tvMenuPerfil)
        Me.gbPerfiles.Controls.Add(Me.bGuardarPerfil)
        Me.gbPerfiles.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPerfiles.Location = New System.Drawing.Point(12, 93)
        Me.gbPerfiles.Name = "gbPerfiles"
        Me.gbPerfiles.Size = New System.Drawing.Size(472, 676)
        Me.gbPerfiles.TabIndex = 161
        Me.gbPerfiles.TabStop = False
        Me.gbPerfiles.Text = "PERFILES"
        '
        'GestionPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 778)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbUsuario)
        Me.Controls.Add(Me.gbPerfiles)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE PERMISOS DE PERFILES Y USUARIOS"
        Me.gbUsuario.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPerfiles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents gbUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents lvPersonal As System.Windows.Forms.ListView
    Friend WithEvents lvidUsuario As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNombreC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDepartamento As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tvMenUsuario As System.Windows.Forms.TreeView
    Friend WithEvents bGuardarUsuario As System.Windows.Forms.Button
    Friend WithEvents lbInforma As System.Windows.Forms.Label
    Friend WithEvents bCopiarPerfil As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bGuardarPerfil As System.Windows.Forms.Button
    Friend WithEvents tvMenuPerfil As System.Windows.Forms.TreeView
    Friend WithEvents lvPerfiles As System.Windows.Forms.ListView
    Friend WithEvents lvidPerfil As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPerfil As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbPerfiles As System.Windows.Forms.GroupBox
End Class
