<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subPonerEnPruebas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subPonerEnPruebas))
        Me.Label6 = New System.Windows.Forms.Label
        Me.NotaPruebas = New System.Windows.Forms.TextBox
        Me.bPruebas = New System.Windows.Forms.Button
        Me.bCancelar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.EstadoTaller = New System.Windows.Forms.TextBox
        Me.EstadoElectronica = New System.Windows.Forms.TextBox
        Me.FechaInicioPruebas = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbPrueba = New System.Windows.Forms.Label
        Me.lbCerrar = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.FechaFin = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 17)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "NOTA PRUEBAS"
        '
        'NotaPruebas
        '
        Me.NotaPruebas.BackColor = System.Drawing.SystemColors.Window
        Me.NotaPruebas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotaPruebas.Location = New System.Drawing.Point(114, 183)
        Me.NotaPruebas.MaxLength = 250
        Me.NotaPruebas.Multiline = True
        Me.NotaPruebas.Name = "NotaPruebas"
        Me.NotaPruebas.Size = New System.Drawing.Size(405, 81)
        Me.NotaPruebas.TabIndex = 1
        '
        'bPruebas
        '
        Me.bPruebas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPruebas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPruebas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPruebas.Location = New System.Drawing.Point(319, 11)
        Me.bPruebas.Name = "bPruebas"
        Me.bPruebas.Size = New System.Drawing.Size(96, 50)
        Me.bPruebas.TabIndex = 2
        Me.bPruebas.Text = "MARCAR PRUEBAS"
        Me.bPruebas.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(425, 11)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(96, 50)
        Me.bCancelar.TabIndex = 3
        Me.bCancelar.Text = "CANCELAR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "TALLER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(279, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "INICIO PRUEBAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "ELECTRÓNICA"
        '
        'EstadoTaller
        '
        Me.EstadoTaller.BackColor = System.Drawing.SystemColors.Window
        Me.EstadoTaller.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstadoTaller.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstadoTaller.Location = New System.Drawing.Point(114, 118)
        Me.EstadoTaller.MaxLength = 50
        Me.EstadoTaller.Name = "EstadoTaller"
        Me.EstadoTaller.ReadOnly = True
        Me.EstadoTaller.Size = New System.Drawing.Size(167, 23)
        Me.EstadoTaller.TabIndex = 127
        '
        'EstadoElectronica
        '
        Me.EstadoElectronica.BackColor = System.Drawing.SystemColors.Window
        Me.EstadoElectronica.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstadoElectronica.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstadoElectronica.Location = New System.Drawing.Point(114, 148)
        Me.EstadoElectronica.MaxLength = 50
        Me.EstadoElectronica.Name = "EstadoElectronica"
        Me.EstadoElectronica.ReadOnly = True
        Me.EstadoElectronica.Size = New System.Drawing.Size(167, 23)
        Me.EstadoElectronica.TabIndex = 127
        '
        'FechaInicioPruebas
        '
        Me.FechaInicioPruebas.BackColor = System.Drawing.SystemColors.Window
        Me.FechaInicioPruebas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaInicioPruebas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FechaInicioPruebas.Location = New System.Drawing.Point(388, 87)
        Me.FechaInicioPruebas.MaxLength = 50
        Me.FechaInicioPruebas.Name = "FechaInicioPruebas"
        Me.FechaInicioPruebas.ReadOnly = True
        Me.FechaInicioPruebas.Size = New System.Drawing.Size(131, 23)
        Me.FechaInicioPruebas.TabIndex = 127
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 128
        Me.PictureBox1.TabStop = False
        '
        'lbPrueba
        '
        Me.lbPrueba.AutoSize = True
        Me.lbPrueba.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrueba.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbPrueba.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbPrueba.Location = New System.Drawing.Point(113, 89)
        Me.lbPrueba.Name = "lbPrueba"
        Me.lbPrueba.Size = New System.Drawing.Size(155, 18)
        Me.lbPrueba.TabIndex = 117
        Me.lbPrueba.Text = "EN FASE DE PRUEBAS"
        '
        'lbCerrar
        '
        Me.lbCerrar.AutoSize = True
        Me.lbCerrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCerrar.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCerrar.Location = New System.Drawing.Point(175, 30)
        Me.lbCerrar.Name = "lbCerrar"
        Me.lbCerrar.Size = New System.Drawing.Size(93, 16)
        Me.lbCerrar.TabIndex = 117
        Me.lbCerrar.Text = "FASE CERRAR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(299, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "FINALIZADO"
        '
        'FechaFin
        '
        Me.FechaFin.BackColor = System.Drawing.SystemColors.Window
        Me.FechaFin.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaFin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FechaFin.Location = New System.Drawing.Point(389, 148)
        Me.FechaFin.MaxLength = 50
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.ReadOnly = True
        Me.FechaFin.Size = New System.Drawing.Size(131, 23)
        Me.FechaFin.TabIndex = 127
        '
        'subPonerEnPruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(549, 282)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FechaFin)
        Me.Controls.Add(Me.FechaInicioPruebas)
        Me.Controls.Add(Me.EstadoElectronica)
        Me.Controls.Add(Me.EstadoTaller)
        Me.Controls.Add(Me.bPruebas)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NotaPruebas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbCerrar)
        Me.Controls.Add(Me.lbPrueba)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subPonerEnPruebas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADO PEDIDO"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NotaPruebas As System.Windows.Forms.TextBox
    Friend WithEvents bPruebas As System.Windows.Forms.Button
    Friend WithEvents bCancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EstadoTaller As System.Windows.Forms.TextBox
    Friend WithEvents EstadoElectronica As System.Windows.Forms.TextBox
    Friend WithEvents FechaInicioPruebas As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbPrueba As System.Windows.Forms.Label
    Friend WithEvents lbCerrar As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FechaFin As System.Windows.Forms.TextBox
End Class
