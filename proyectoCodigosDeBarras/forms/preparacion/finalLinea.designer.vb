<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class finalLinea
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.txNumSerieEquipo = New System.Windows.Forms.TextBox()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txSubEquipo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ckSinCelula = New System.Windows.Forms.CheckBox()
        Me.txEquipo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 169
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1220, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 3
        Me.bSalir.TabStop = False
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 21)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Nº SERIE EQUIPO"
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1088, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(126, 70)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.TabStop = False
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'txNumSerieEquipo
        '
        Me.txNumSerieEquipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumSerieEquipo.Location = New System.Drawing.Point(153, 97)
        Me.txNumSerieEquipo.Name = "txNumSerieEquipo"
        Me.txNumSerieEquipo.Size = New System.Drawing.Size(142, 27)
        Me.txNumSerieEquipo.TabIndex = 0
        Me.txNumSerieEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(956, 13)
        Me.bImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(126, 70)
        Me.bImprimir.TabIndex = 187
        Me.bImprimir.TabStop = False
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(12, 169)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1334, 589)
        Me.Panel1.TabIndex = 188
        '
        'txSubEquipo
        '
        Me.txSubEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txSubEquipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txSubEquipo.Location = New System.Drawing.Point(478, 97)
        Me.txSubEquipo.Name = "txSubEquipo"
        Me.txSubEquipo.Size = New System.Drawing.Size(231, 27)
        Me.txSubEquipo.TabIndex = 189
        Me.txSubEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(301, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 21)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "Nº SERIE SUB EQUIPO"
        '
        'ckSinCelula
        '
        Me.ckSinCelula.AutoSize = True
        Me.ckSinCelula.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSinCelula.Location = New System.Drawing.Point(715, 132)
        Me.ckSinCelula.Name = "ckSinCelula"
        Me.ckSinCelula.Size = New System.Drawing.Size(118, 25)
        Me.ckSinCelula.TabIndex = 191
        Me.ckSinCelula.Text = "SIN CÉLULA"
        Me.ckSinCelula.UseVisualStyleBackColor = True
        '
        'txEquipo
        '
        Me.txEquipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txEquipo.Location = New System.Drawing.Point(153, 130)
        Me.txEquipo.Name = "txEquipo"
        Me.txEquipo.ReadOnly = True
        Me.txEquipo.Size = New System.Drawing.Size(556, 27)
        Me.txEquipo.TabIndex = 192
        Me.txEquipo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 21)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "EQUIPO"
        '
        'finalLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 745)
        Me.Controls.Add(Me.txEquipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ckSinCelula)
        Me.Controls.Add(Me.txSubEquipo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.txNumSerieEquipo)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "finalLinea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FINAL LÍNEA "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents bSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bLimpiar As Button
    Friend WithEvents txNumSerieEquipo As TextBox
    Friend WithEvents bImprimir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txSubEquipo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ckSinCelula As CheckBox
    Friend WithEvents txEquipo As TextBox
    Friend WithEvents Label3 As Label
End Class
