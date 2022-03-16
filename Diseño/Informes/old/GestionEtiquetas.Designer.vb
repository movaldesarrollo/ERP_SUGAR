<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEtiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEtiquetas))
        Me.cbEtiquetas = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Copias = New System.Windows.Forms.TextBox
        Me.Impresiones = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Campo10 = New System.Windows.Forms.TextBox
        Me.Campo9 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Campo8 = New System.Windows.Forms.TextBox
        Me.Campo4 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Campo7 = New System.Windows.Forms.TextBox
        Me.Campo3 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Campo6 = New System.Windows.Forms.TextBox
        Me.Campo2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Campo5 = New System.Windows.Forms.TextBox
        Me.campo1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bVistaPrevia = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.cbImpresoras = New System.Windows.Forms.ComboBox
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.MargenInf = New System.Windows.Forms.TextBox
        Me.MargenSup = New System.Windows.Forms.TextBox
        Me.MargenDer = New System.Windows.Forms.TextBox
        Me.MargenIzq = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbEtiquetas
        '
        Me.cbEtiquetas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEtiquetas.FormattingEnabled = True
        Me.cbEtiquetas.Location = New System.Drawing.Point(93, 88)
        Me.cbEtiquetas.Name = "cbEtiquetas"
        Me.cbEtiquetas.Size = New System.Drawing.Size(296, 25)
        Me.cbEtiquetas.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LogoBlanco150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Copias)
        Me.GroupBox1.Controls.Add(Me.MargenIzq)
        Me.GroupBox1.Controls.Add(Me.MargenDer)
        Me.GroupBox1.Controls.Add(Me.MargenSup)
        Me.GroupBox1.Controls.Add(Me.MargenInf)
        Me.GroupBox1.Controls.Add(Me.Impresiones)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bVistaPrevia)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.cbImpresoras)
        Me.GroupBox1.Controls.Add(Me.cbEtiquetas)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 310)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Copias
        '
        Me.Copias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copias.Location = New System.Drawing.Point(93, 118)
        Me.Copias.MaxLength = 50
        Me.Copias.Name = "Copias"
        Me.Copias.Size = New System.Drawing.Size(38, 23)
        Me.Copias.TabIndex = 117
        '
        'Impresiones
        '
        Me.Impresiones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Impresiones.Location = New System.Drawing.Point(351, 118)
        Me.Impresiones.MaxLength = 50
        Me.Impresiones.Name = "Impresiones"
        Me.Impresiones.Size = New System.Drawing.Size(38, 23)
        Me.Impresiones.TabIndex = 117
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(16, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 17)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "COPIAS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Campo10)
        Me.GroupBox2.Controls.Add(Me.Campo9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Campo8)
        Me.GroupBox2.Controls.Add(Me.Campo4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Campo7)
        Me.GroupBox2.Controls.Add(Me.Campo3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Campo6)
        Me.GroupBox2.Controls.Add(Me.Campo2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Campo5)
        Me.GroupBox2.Controls.Add(Me.campo1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(781, 157)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CAMPOS EDITABLES"
        '
        'Campo10
        '
        Me.Campo10.BackColor = System.Drawing.SystemColors.Window
        Me.Campo10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo10.Location = New System.Drawing.Point(560, 126)
        Me.Campo10.MaxLength = 15
        Me.Campo10.Name = "Campo10"
        Me.Campo10.Size = New System.Drawing.Size(203, 23)
        Me.Campo10.TabIndex = 9
        Me.Campo10.TabStop = False
        '
        'Campo9
        '
        Me.Campo9.BackColor = System.Drawing.SystemColors.Window
        Me.Campo9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo9.Location = New System.Drawing.Point(560, 100)
        Me.Campo9.MaxLength = 15
        Me.Campo9.Name = "Campo9"
        Me.Campo9.Size = New System.Drawing.Size(203, 23)
        Me.Campo9.TabIndex = 8
        Me.Campo9.TabStop = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(394, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 17)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "LB10"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Campo8
        '
        Me.Campo8.BackColor = System.Drawing.SystemColors.Window
        Me.Campo8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo8.Location = New System.Drawing.Point(560, 74)
        Me.Campo8.MaxLength = 15
        Me.Campo8.Name = "Campo8"
        Me.Campo8.Size = New System.Drawing.Size(203, 23)
        Me.Campo8.TabIndex = 7
        Me.Campo8.TabStop = False
        '
        'Campo4
        '
        Me.Campo4.BackColor = System.Drawing.SystemColors.Window
        Me.Campo4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo4.Location = New System.Drawing.Point(175, 100)
        Me.Campo4.MaxLength = 15
        Me.Campo4.Name = "Campo4"
        Me.Campo4.Size = New System.Drawing.Size(203, 23)
        Me.Campo4.TabIndex = 3
        Me.Campo4.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(397, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 17)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "LB6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(48, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 17)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "LB3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(394, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(160, 17)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "LB9"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 17)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "LB5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Campo7
        '
        Me.Campo7.BackColor = System.Drawing.SystemColors.Window
        Me.Campo7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo7.Location = New System.Drawing.Point(560, 48)
        Me.Campo7.MaxLength = 15
        Me.Campo7.Name = "Campo7"
        Me.Campo7.Size = New System.Drawing.Size(203, 23)
        Me.Campo7.TabIndex = 6
        Me.Campo7.TabStop = False
        '
        'Campo3
        '
        Me.Campo3.BackColor = System.Drawing.SystemColors.Window
        Me.Campo3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo3.Location = New System.Drawing.Point(175, 74)
        Me.Campo3.MaxLength = 15
        Me.Campo3.Name = "Campo3"
        Me.Campo3.Size = New System.Drawing.Size(203, 23)
        Me.Campo3.TabIndex = 2
        Me.Campo3.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(11, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 17)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "LB4"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Campo6
        '
        Me.Campo6.BackColor = System.Drawing.SystemColors.Window
        Me.Campo6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo6.Location = New System.Drawing.Point(560, 22)
        Me.Campo6.MaxLength = 15
        Me.Campo6.Name = "Campo6"
        Me.Campo6.Size = New System.Drawing.Size(203, 23)
        Me.Campo6.TabIndex = 5
        Me.Campo6.TabStop = False
        '
        'Campo2
        '
        Me.Campo2.BackColor = System.Drawing.SystemColors.Window
        Me.Campo2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo2.Location = New System.Drawing.Point(175, 48)
        Me.Campo2.MaxLength = 15
        Me.Campo2.Name = "Campo2"
        Me.Campo2.Size = New System.Drawing.Size(203, 23)
        Me.Campo2.TabIndex = 1
        Me.Campo2.TabStop = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(394, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 17)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "LB8"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(11, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 17)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "LB2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Campo5
        '
        Me.Campo5.BackColor = System.Drawing.SystemColors.Window
        Me.Campo5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Campo5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Campo5.Location = New System.Drawing.Point(175, 126)
        Me.Campo5.MaxLength = 15
        Me.Campo5.Name = "Campo5"
        Me.Campo5.Size = New System.Drawing.Size(203, 23)
        Me.Campo5.TabIndex = 4
        Me.Campo5.TabStop = False
        '
        'campo1
        '
        Me.campo1.BackColor = System.Drawing.SystemColors.Window
        Me.campo1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.campo1.Location = New System.Drawing.Point(175, 22)
        Me.campo1.MaxLength = 15
        Me.campo1.Name = "campo1"
        Me.campo1.Size = New System.Drawing.Size(203, 23)
        Me.campo1.TabIndex = 0
        Me.campo1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(394, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(160, 17)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "LB7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 17)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "LB1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(253, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 17)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "IMPRESIONES"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(403, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "IMPRESORA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(15, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 17)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "MODELO"
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(586, 19)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 5
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bVistaPrevia
        '
        Me.bVistaPrevia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVistaPrevia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVistaPrevia.Location = New System.Drawing.Point(494, 19)
        Me.bVistaPrevia.Name = "bVistaPrevia"
        Me.bVistaPrevia.Size = New System.Drawing.Size(88, 50)
        Me.bVistaPrevia.TabIndex = 4
        Me.bVistaPrevia.Text = "VISTA PREVIA"
        Me.bVistaPrevia.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(686, 19)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'cbImpresoras
        '
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(494, 88)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(280, 25)
        Me.cbImpresoras.TabIndex = 2
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRV.DisplayGroupTree = False
        Me.CRV.Location = New System.Drawing.Point(16, 317)
        Me.CRV.Name = "CRV"
        Me.CRV.SelectionFormula = ""
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.ShowRefreshButton = False
        Me.CRV.Size = New System.Drawing.Size(780, 424)
        Me.CRV.TabIndex = 1
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'MargenInf
        '
        Me.MargenInf.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MargenInf.Location = New System.Drawing.Point(736, 118)
        Me.MargenInf.MaxLength = 50
        Me.MargenInf.Name = "MargenInf"
        Me.MargenInf.Size = New System.Drawing.Size(38, 23)
        Me.MargenInf.TabIndex = 117
        '
        'MargenSup
        '
        Me.MargenSup.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MargenSup.Location = New System.Drawing.Point(650, 118)
        Me.MargenSup.MaxLength = 50
        Me.MargenSup.Name = "MargenSup"
        Me.MargenSup.Size = New System.Drawing.Size(38, 23)
        Me.MargenSup.TabIndex = 117
        '
        'MargenDer
        '
        Me.MargenDer.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MargenDer.Location = New System.Drawing.Point(573, 118)
        Me.MargenDer.MaxLength = 50
        Me.MargenDer.Name = "MargenDer"
        Me.MargenDer.Size = New System.Drawing.Size(38, 23)
        Me.MargenDer.TabIndex = 117
        '
        'MargenIzq
        '
        Me.MargenIzq.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MargenIzq.Location = New System.Drawing.Point(494, 118)
        Me.MargenIzq.MaxLength = 50
        Me.MargenIzq.Name = "MargenIzq"
        Me.MargenIzq.Size = New System.Drawing.Size(38, 23)
        Me.MargenIzq.TabIndex = 117
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(389, 121)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 17)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "MÁRGENES  IZQ"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(537, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 17)
        Me.Label16.TabIndex = 116
        Me.Label16.Text = "DER"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(618, 121)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 17)
        Me.Label17.TabIndex = 116
        Me.Label17.Text = "SUP"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(706, 121)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 17)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "INF"
        '
        'GestionEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 741)
        Me.Controls.Add(Me.CRV)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE ETIQUETAS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbEtiquetas As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents campo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Campo4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Campo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Campo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbImpresoras As System.Windows.Forms.ComboBox
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Campo8 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Campo7 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Campo6 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Campo5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Campo10 As System.Windows.Forms.TextBox
    Friend WithEvents Campo9 As System.Windows.Forms.TextBox
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents Copias As System.Windows.Forms.TextBox
    Friend WithEvents Impresiones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MargenIzq As System.Windows.Forms.TextBox
    Friend WithEvents MargenDer As System.Windows.Forms.TextBox
    Friend WithEvents MargenSup As System.Windows.Forms.TextBox
    Friend WithEvents MargenInf As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
