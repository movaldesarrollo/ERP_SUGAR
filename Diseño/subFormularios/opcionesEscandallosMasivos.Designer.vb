<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opcionesEscandallosMasivos
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
        Me.bBuscarRuta = New System.Windows.Forms.Button
        Me.txRuta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckMateriasPrimas = New System.Windows.Forms.CheckBox
        Me.ckCostes = New System.Windows.Forms.CheckBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bExportar = New System.Windows.Forms.Button
        Me.seleccionarCarpera = New System.Windows.Forms.FolderBrowserDialog
        Me.bTabla = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'bBuscarRuta
        '
        Me.bBuscarRuta.Image = Global.ERP_SUGAR.My.Resources.Resources.EXPLORER
        Me.bBuscarRuta.Location = New System.Drawing.Point(428, 90)
        Me.bBuscarRuta.Name = "bBuscarRuta"
        Me.bBuscarRuta.Size = New System.Drawing.Size(29, 23)
        Me.bBuscarRuta.TabIndex = 1
        Me.bBuscarRuta.UseVisualStyleBackColor = True
        '
        'txRuta
        '
        Me.txRuta.Location = New System.Drawing.Point(15, 90)
        Me.txRuta.Name = "txRuta"
        Me.txRuta.ReadOnly = True
        Me.txRuta.Size = New System.Drawing.Size(407, 23)
        Me.txRuta.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(12, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CARPETA DE EXPORTACIÓN"
        '
        'ckMateriasPrimas
        '
        Me.ckMateriasPrimas.AutoSize = True
        Me.ckMateriasPrimas.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckMateriasPrimas.Location = New System.Drawing.Point(15, 119)
        Me.ckMateriasPrimas.Name = "ckMateriasPrimas"
        Me.ckMateriasPrimas.Size = New System.Drawing.Size(240, 21)
        Me.ckMateriasPrimas.TabIndex = 2
        Me.ckMateriasPrimas.Text = "EXPORTAR SOLO MATERIAS PRIMAS"
        Me.ckMateriasPrimas.UseVisualStyleBackColor = True
        '
        'ckCostes
        '
        Me.ckCostes.AutoSize = True
        Me.ckCostes.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCostes.Location = New System.Drawing.Point(280, 119)
        Me.ckCostes.Name = "ckCostes"
        Me.ckCostes.Size = New System.Drawing.Size(164, 21)
        Me.ckCostes.TabIndex = 3
        Me.ckCostes.Text = "EXPORTAR SIN COSTES"
        Me.ckCostes.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(372, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bExportar
        '
        Me.bExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bExportar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bExportar.Location = New System.Drawing.Point(281, 12)
        Me.bExportar.Name = "bExportar"
        Me.bExportar.Size = New System.Drawing.Size(85, 50)
        Me.bExportar.TabIndex = 4
        Me.bExportar.Text = "EXPORTAR"
        Me.bExportar.UseVisualStyleBackColor = True
        '
        'bTabla
        '
        Me.bTabla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bTabla.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTabla.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTabla.Location = New System.Drawing.Point(190, 12)
        Me.bTabla.Name = "bTabla"
        Me.bTabla.Size = New System.Drawing.Size(85, 50)
        Me.bTabla.TabIndex = 6
        Me.bTabla.Text = "EXPORTAR TABLA"
        Me.bTabla.UseVisualStyleBackColor = True
        Me.bTabla.Visible = False
        '
        'opcionesEscandallosMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 157)
        Me.Controls.Add(Me.bTabla)
        Me.Controls.Add(Me.bExportar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.ckCostes)
        Me.Controls.Add(Me.ckMateriasPrimas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txRuta)
        Me.Controls.Add(Me.bBuscarRuta)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "opcionesEscandallosMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OPCIONES EXPORTACIÓN"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bBuscarRuta As System.Windows.Forms.Button
    Friend WithEvents txRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckMateriasPrimas As System.Windows.Forms.CheckBox
    Friend WithEvents ckCostes As System.Windows.Forms.CheckBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bExportar As System.Windows.Forms.Button
    Friend WithEvents seleccionarCarpera As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents bTabla As System.Windows.Forms.Button
End Class
