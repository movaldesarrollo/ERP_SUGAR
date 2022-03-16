<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class imagenesRegistradas
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
        Me.panelImagenes = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bSubirImagen = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ofSubirImagen = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txTotalImagenes = New System.Windows.Forms.TextBox()
        Me.bBorrarImagen = New System.Windows.Forms.Button()
        Me.bSustituirImagen = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelImagenes
        '
        Me.panelImagenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelImagenes.AutoScroll = True
        Me.panelImagenes.BackColor = System.Drawing.Color.White
        Me.panelImagenes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelImagenes.ForeColor = System.Drawing.Color.Black
        Me.panelImagenes.Location = New System.Drawing.Point(12, 129)
        Me.panelImagenes.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.panelImagenes.Name = "panelImagenes"
        Me.panelImagenes.Size = New System.Drawing.Size(1158, 534)
        Me.panelImagenes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IMAGENES REGISTRADAS EN LA BASE DE DATOS"
        '
        'bSubirImagen
        '
        Me.bSubirImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSubirImagen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSubirImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubirImagen.Location = New System.Drawing.Point(552, 13)
        Me.bSubirImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSubirImagen.Name = "bSubirImagen"
        Me.bSubirImagen.Size = New System.Drawing.Size(150, 71)
        Me.bSubirImagen.TabIndex = 4
        Me.bSubirImagen.TabStop = False
        Me.bSubirImagen.Text = "SUBIR IMAGEN"
        Me.bSubirImagen.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1020, 12)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 71)
        Me.bSalir.TabIndex = 5
        Me.bSalir.TabStop = False
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 195
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(916, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 19)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "TOTAL IMÁGENES"
        '
        'txTotalImagenes
        '
        Me.txTotalImagenes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalImagenes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txTotalImagenes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalImagenes.Location = New System.Drawing.Point(1060, 94)
        Me.txTotalImagenes.Name = "txTotalImagenes"
        Me.txTotalImagenes.Size = New System.Drawing.Size(110, 27)
        Me.txTotalImagenes.TabIndex = 196
        Me.txTotalImagenes.TabStop = False
        Me.txTotalImagenes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bBorrarImagen
        '
        Me.bBorrarImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrarImagen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrarImagen.Location = New System.Drawing.Point(708, 12)
        Me.bBorrarImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBorrarImagen.Name = "bBorrarImagen"
        Me.bBorrarImagen.Size = New System.Drawing.Size(150, 71)
        Me.bBorrarImagen.TabIndex = 198
        Me.bBorrarImagen.TabStop = False
        Me.bBorrarImagen.Text = "BORRAR IMAGEN"
        Me.bBorrarImagen.UseVisualStyleBackColor = True
        '
        'bSustituirImagen
        '
        Me.bSustituirImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSustituirImagen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSustituirImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSustituirImagen.Location = New System.Drawing.Point(396, 13)
        Me.bSustituirImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSustituirImagen.Name = "bSustituirImagen"
        Me.bSustituirImagen.Size = New System.Drawing.Size(150, 71)
        Me.bSustituirImagen.TabIndex = 199
        Me.bSustituirImagen.TabStop = False
        Me.bSustituirImagen.Text = "SUSTITUIR IMAGEN"
        Me.bSustituirImagen.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(864, 12)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.bLimpiar.TabIndex = 200
        Me.bLimpiar.TabStop = False
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'imagenesRegistradas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 677)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSustituirImagen)
        Me.Controls.Add(Me.bBorrarImagen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txTotalImagenes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSubirImagen)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panelImagenes)
        Me.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MinimizeBox = False
        Me.Name = "imagenesRegistradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMAGENES "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelImagenes As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents bSubirImagen As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ofSubirImagen As OpenFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents txTotalImagenes As TextBox
    Friend WithEvents bBorrarImagen As Button
    Friend WithEvents bSustituirImagen As Button
    Friend WithEvents bLimpiar As Button
End Class
