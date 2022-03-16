<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionComisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignacionComisiones))
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.lvClientes = New System.Windows.Forms.ListView
        Me.lvCheck = New System.Windows.Forms.ColumnHeader
        Me.lvidCliente = New System.Windows.Forms.ColumnHeader
        Me.lvidComision = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvPais = New System.Windows.Forms.ColumnHeader
        Me.lvAutonomia = New System.Windows.Forms.ColumnHeader
        Me.lvProvincia = New System.Windows.Forms.ColumnHeader
        Me.lvComercial = New System.Windows.Forms.ColumnHeader
        Me.lvComision = New System.Windows.Forms.ColumnHeader
        Me.Label8 = New System.Windows.Forms.Label
        Me.Comision = New System.Windows.Forms.TextBox
        Me.cbComercial = New System.Windows.Forms.ComboBox
        Me.lbcomercial = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.cbAutonomia = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.cbProvincia = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbPais = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Seleccionados = New System.Windows.Forms.TextBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.pbCarga = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bGuardar.Location = New System.Drawing.Point(673, 13)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 6
        Me.bGuardar.Text = "ASIGNAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(773, 13)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 7
        Me.bNuevo.Text = "LIMPIAR"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 117
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(873, 13)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 9
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'lvClientes
        '
        Me.lvClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvClientes.CheckBoxes = True
        Me.lvClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCheck, Me.lvidCliente, Me.lvidComision, Me.lvCliente, Me.lvPais, Me.lvAutonomia, Me.lvProvincia, Me.lvComercial, Me.lvComision})
        Me.lvClientes.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvClientes.FullRowSelect = True
        Me.lvClientes.GridLines = True
        Me.lvClientes.Location = New System.Drawing.Point(12, 239)
        Me.lvClientes.MultiSelect = False
        Me.lvClientes.Name = "lvClientes"
        Me.lvClientes.ShowItemToolTips = True
        Me.lvClientes.Size = New System.Drawing.Size(948, 408)
        Me.lvClientes.TabIndex = 3
        Me.lvClientes.UseCompatibleStateImageBehavior = False
        Me.lvClientes.View = System.Windows.Forms.View.Details
        '
        'lvCheck
        '
        Me.lvCheck.Text = ""
        Me.lvCheck.Width = 22
        '
        'lvidCliente
        '
        Me.lvidCliente.Text = "ID "
        Me.lvidCliente.Width = 0
        '
        'lvidComision
        '
        Me.lvidComision.Text = "idComision"
        Me.lvidComision.Width = 0
        '
        'lvCliente
        '
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 316
        '
        'lvPais
        '
        Me.lvPais.Text = "PAÍS"
        Me.lvPais.Width = 95
        '
        'lvAutonomia
        '
        Me.lvAutonomia.Text = "C.AUTÓNOMA"
        Me.lvAutonomia.Width = 145
        '
        'lvProvincia
        '
        Me.lvProvincia.Text = "PROVINCIA"
        Me.lvProvincia.Width = 113
        '
        'lvComercial
        '
        Me.lvComercial.Text = "COMERCIAL"
        Me.lvComercial.Width = 150
        '
        'lvComision
        '
        Me.lvComision.Text = "COMISIÓN"
        Me.lvComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvComision.Width = 75
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(351, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 171
        Me.Label8.Text = "COMISIÓN"
        '
        'Comision
        '
        Me.Comision.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comision.Location = New System.Drawing.Point(450, 30)
        Me.Comision.MaxLength = 100
        Me.Comision.Name = "Comision"
        Me.Comision.Size = New System.Drawing.Size(49, 23)
        Me.Comision.TabIndex = 1
        '
        'cbComercial
        '
        Me.cbComercial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComercial.FormattingEnabled = True
        Me.cbComercial.Location = New System.Drawing.Point(123, 29)
        Me.cbComercial.Name = "cbComercial"
        Me.cbComercial.Size = New System.Drawing.Size(201, 25)
        Me.cbComercial.TabIndex = 0
        '
        'lbcomercial
        '
        Me.lbcomercial.AutoSize = True
        Me.lbcomercial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcomercial.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbcomercial.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbcomercial.Location = New System.Drawing.Point(8, 33)
        Me.lbcomercial.Name = "lbcomercial"
        Me.lbcomercial.Size = New System.Drawing.Size(85, 17)
        Me.lbcomercial.TabIndex = 173
        Me.lbcomercial.Text = "COMERCIAL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(505, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 17)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "%"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbComercial)
        Me.GroupBox3.Controls.Add(Me.bVerCliente)
        Me.GroupBox3.Controls.Add(Me.lbcomercial)
        Me.GroupBox3.Controls.Add(Me.cbAutonomia)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Comision)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbCliente)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.cbProvincia)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cbPais)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(948, 134)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "PARÁMETROS DE SELECCIÓN"
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(742, 57)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 3
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'cbAutonomia
        '
        Me.cbAutonomia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutonomia.FormattingEnabled = True
        Me.cbAutonomia.Location = New System.Drawing.Point(450, 88)
        Me.cbAutonomia.Name = "cbAutonomia"
        Me.cbAutonomia.Size = New System.Drawing.Size(208, 25)
        Me.cbAutonomia.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(351, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 17)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "C.AUTÓNOMA"
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(123, 57)
        Me.cbCliente.MaxLength = 100
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(583, 25)
        Me.cbCliente.TabIndex = 2
        '
        'cbProvincia
        '
        Me.cbProvincia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProvincia.FormattingEnabled = True
        Me.cbProvincia.Location = New System.Drawing.Point(123, 88)
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(201, 25)
        Me.cbProvincia.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(8, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "PROVINCIA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(705, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 17)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "PAIS"
        '
        'cbPais
        '
        Me.cbPais.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPais.FormattingEnabled = True
        Me.cbPais.Location = New System.Drawing.Point(742, 88)
        Me.cbPais.Name = "cbPais"
        Me.cbPais.Size = New System.Drawing.Size(187, 25)
        Me.cbPais.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(8, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "CLIENTE"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(837, 655)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 17)
        Me.Label10.TabIndex = 171
        Me.Label10.Text = "CLIENTES"
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.Location = New System.Drawing.Point(911, 652)
        Me.Contador.MaxLength = 100
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(49, 23)
        Me.Contador.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(587, 655)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 17)
        Me.Label11.TabIndex = 171
        Me.Label11.Text = "SELECCIONADOS"
        '
        'Seleccionados
        '
        Me.Seleccionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Seleccionados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seleccionados.Location = New System.Drawing.Point(708, 652)
        Me.Seleccionados.MaxLength = 100
        Me.Seleccionados.Name = "Seleccionados"
        Me.Seleccionados.Size = New System.Drawing.Size(49, 23)
        Me.Seleccionados.TabIndex = 4
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(16, 245)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 2
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'pbCarga
        '
        Me.pbCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbCarga.Location = New System.Drawing.Point(96, 660)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(118, 15)
        Me.pbCarga.TabIndex = 197
        '
        'AsignacionComisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 686)
        Me.Controls.Add(Me.pbCarga)
        Me.Controls.Add(Me.ckSeleccion)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Seleccionados)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lvClientes)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AsignacionComisiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASIGNACIÓN DE COMISIONES A COMERCIALES"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvClientes As System.Windows.Forms.ListView
    Friend WithEvents lvidCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComision As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComercial As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Comision As System.Windows.Forms.TextBox
    Friend WithEvents cbComercial As System.Windows.Forms.ComboBox
    Friend WithEvents lbcomercial As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Seleccionados As System.Windows.Forms.TextBox
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents cbAutonomia As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents lvProvincia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPais As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAutonomia As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents pbCarga As System.Windows.Forms.ProgressBar
    Friend WithEvents lvidComision As System.Windows.Forms.ColumnHeader
End Class
