<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEtiquetaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEtiquetaCliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLoadImg = New System.Windows.Forms.Button()
        Me.tbPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCliente = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbImagenCliente = New System.Windows.Forms.GroupBox()
        Me.pbImagenCliente = New System.Windows.Forms.PictureBox()
        Me.gbData.SuspendLayout()
        Me.gbImagenCliente.SuspendLayout()
        CType(Me.pbImagenCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENTE"
        '
        'gbData
        '
        Me.gbData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbData.Controls.Add(Me.btnSalir)
        Me.gbData.Controls.Add(Me.btnBorrar)
        Me.gbData.Controls.Add(Me.btnGuardar)
        Me.gbData.Controls.Add(Me.btnLoadImg)
        Me.gbData.Controls.Add(Me.tbPath)
        Me.gbData.Controls.Add(Me.Label2)
        Me.gbData.Controls.Add(Me.tbCliente)
        Me.gbData.Controls.Add(Me.Label1)
        Me.gbData.Location = New System.Drawing.Point(12, 13)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(752, 83)
        Me.gbData.TabIndex = 1
        Me.gbData.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(658, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(88, 62)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrar.Location = New System.Drawing.Point(564, 12)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(88, 62)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.Text = "BORRAR"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(470, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(88, 62)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnLoadImg
        '
        Me.btnLoadImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadImg.Location = New System.Drawing.Point(382, 51)
        Me.btnLoadImg.Name = "btnLoadImg"
        Me.btnLoadImg.Size = New System.Drawing.Size(82, 23)
        Me.btnLoadImg.TabIndex = 1
        Me.btnLoadImg.Text = "CARGAR"
        Me.btnLoadImg.UseVisualStyleBackColor = True
        '
        'tbPath
        '
        Me.tbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPath.Location = New System.Drawing.Point(68, 51)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.ReadOnly = True
        Me.tbPath.Size = New System.Drawing.Size(312, 22)
        Me.tbPath.TabIndex = 2
        Me.tbPath.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "IMAGEN"
        '
        'tbCliente
        '
        Me.tbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCliente.Location = New System.Drawing.Point(64, 15)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.ReadOnly = True
        Me.tbCliente.Size = New System.Drawing.Size(400, 22)
        Me.tbCliente.TabIndex = 0
        Me.tbCliente.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'gbImagenCliente
        '
        Me.gbImagenCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbImagenCliente.Controls.Add(Me.pbImagenCliente)
        Me.gbImagenCliente.Location = New System.Drawing.Point(12, 102)
        Me.gbImagenCliente.Name = "gbImagenCliente"
        Me.gbImagenCliente.Size = New System.Drawing.Size(752, 410)
        Me.gbImagenCliente.TabIndex = 2
        Me.gbImagenCliente.TabStop = False
        '
        'pbImagenCliente
        '
        Me.pbImagenCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagenCliente.BackColor = System.Drawing.Color.White
        Me.pbImagenCliente.InitialImage = Nothing
        Me.pbImagenCliente.Location = New System.Drawing.Point(6, 21)
        Me.pbImagenCliente.Name = "pbImagenCliente"
        Me.pbImagenCliente.Padding = New System.Windows.Forms.Padding(5)
        Me.pbImagenCliente.Size = New System.Drawing.Size(728, 383)
        Me.pbImagenCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagenCliente.TabIndex = 0
        Me.pbImagenCliente.TabStop = False
        '
        'GestionEtiquetaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 524)
        Me.Controls.Add(Me.gbImagenCliente)
        Me.Controls.Add(Me.gbData)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionEtiquetaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN ETIQUETA CLIENTE"
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        Me.gbImagenCliente.ResumeLayout(False)
        CType(Me.pbImagenCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents gbData As GroupBox
    Friend WithEvents btnLoadImg As Button
    Friend WithEvents tbPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbCliente As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents gbImagenCliente As GroupBox
    Friend WithEvents pbImagenCliente As PictureBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnGuardar As Button
End Class
