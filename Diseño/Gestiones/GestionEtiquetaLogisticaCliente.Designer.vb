<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEtiquetaLogisticaCliente
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEtiquetaLogisticaCliente))
        Me.gbImagenCliente = New System.Windows.Forms.GroupBox()
        Me.lectorPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.pbImagenCliente = New System.Windows.Forms.PictureBox()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.btnBorrarPDF = New System.Windows.Forms.Button()
        Me.btnLoadPDF = New System.Windows.Forms.Button()
        Me.tbPathPDF = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tbCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialogPDF = New System.Windows.Forms.OpenFileDialog()
        Me.menuStripLogo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AñadirLogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarLogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbImagenCliente.SuspendLayout()
        CType(Me.lectorPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagenCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbData.SuspendLayout()
        Me.menuStripLogo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbImagenCliente
        '
        Me.gbImagenCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbImagenCliente.Controls.Add(Me.lectorPDF)
        Me.gbImagenCliente.Controls.Add(Me.pbImagenCliente)
        Me.gbImagenCliente.Location = New System.Drawing.Point(12, 109)
        Me.gbImagenCliente.Name = "gbImagenCliente"
        Me.gbImagenCliente.Size = New System.Drawing.Size(1014, 594)
        Me.gbImagenCliente.TabIndex = 4
        Me.gbImagenCliente.TabStop = False
        '
        'lectorPDF
        '
        Me.lectorPDF.Enabled = True
        Me.lectorPDF.Location = New System.Drawing.Point(497, 19)
        Me.lectorPDF.Name = "lectorPDF"
        Me.lectorPDF.OcxState = CType(resources.GetObject("lectorPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lectorPDF.Size = New System.Drawing.Size(511, 576)
        Me.lectorPDF.TabIndex = 1
        '
        'pbImagenCliente
        '
        Me.pbImagenCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagenCliente.BackColor = System.Drawing.Color.White
        Me.pbImagenCliente.InitialImage = Nothing
        Me.pbImagenCliente.Location = New System.Drawing.Point(6, 19)
        Me.pbImagenCliente.Name = "pbImagenCliente"
        Me.pbImagenCliente.Padding = New System.Windows.Forms.Padding(5)
        Me.pbImagenCliente.Size = New System.Drawing.Size(485, 575)
        Me.pbImagenCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagenCliente.TabIndex = 0
        Me.pbImagenCliente.TabStop = False
        '
        'gbData
        '
        Me.gbData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbData.Controls.Add(Me.btnBorrarPDF)
        Me.gbData.Controls.Add(Me.btnLoadPDF)
        Me.gbData.Controls.Add(Me.tbPathPDF)
        Me.gbData.Controls.Add(Me.Label3)
        Me.gbData.Controls.Add(Me.btnSalir)
        Me.gbData.Controls.Add(Me.btnBorrar)
        Me.gbData.Controls.Add(Me.btnGuardar)
        Me.gbData.Controls.Add(Me.tbCliente)
        Me.gbData.Controls.Add(Me.Label1)
        Me.gbData.Location = New System.Drawing.Point(12, 13)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(1014, 90)
        Me.gbData.TabIndex = 3
        Me.gbData.TabStop = False
        '
        'btnBorrarPDF
        '
        Me.btnBorrarPDF.Location = New System.Drawing.Point(591, 52)
        Me.btnBorrarPDF.Name = "btnBorrarPDF"
        Me.btnBorrarPDF.Size = New System.Drawing.Size(40, 23)
        Me.btnBorrarPDF.TabIndex = 9
        Me.btnBorrarPDF.Text = "X"
        Me.btnBorrarPDF.UseVisualStyleBackColor = True
        '
        'btnLoadPDF
        '
        Me.btnLoadPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadPDF.Location = New System.Drawing.Point(644, 51)
        Me.btnLoadPDF.Name = "btnLoadPDF"
        Me.btnLoadPDF.Size = New System.Drawing.Size(82, 23)
        Me.btnLoadPDF.TabIndex = 8
        Me.btnLoadPDF.Text = "CARGAR"
        Me.btnLoadPDF.UseVisualStyleBackColor = True
        '
        'tbPathPDF
        '
        Me.tbPathPDF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPathPDF.Location = New System.Drawing.Point(68, 53)
        Me.tbPathPDF.Name = "tbPathPDF"
        Me.tbPathPDF.ReadOnly = True
        Me.tbPathPDF.Size = New System.Drawing.Size(524, 20)
        Me.tbPathPDF.TabIndex = 7
        Me.tbPathPDF.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "PDF"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(920, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(88, 62)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrar.Location = New System.Drawing.Point(826, 12)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(88, 62)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.Text = "BORRAR"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Location = New System.Drawing.Point(732, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(88, 62)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'tbCliente
        '
        Me.tbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCliente.Location = New System.Drawing.Point(64, 15)
        Me.tbCliente.Name = "tbCliente"
        Me.tbCliente.ReadOnly = True
        Me.tbCliente.Size = New System.Drawing.Size(662, 20)
        Me.tbCliente.TabIndex = 0
        Me.tbCliente.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CLIENTE"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialogPDF
        '
        Me.OpenFileDialogPDF.FileName = "OpenFileDialog2"
        '
        'menuStripLogo
        '
        Me.menuStripLogo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AñadirLogoToolStripMenuItem, Me.EliminarLogoToolStripMenuItem})
        Me.menuStripLogo.Name = "menuStripLogo"
        Me.menuStripLogo.Size = New System.Drawing.Size(181, 70)
        '
        'AñadirLogoToolStripMenuItem
        '
        Me.AñadirLogoToolStripMenuItem.Name = "AñadirLogoToolStripMenuItem"
        Me.AñadirLogoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AñadirLogoToolStripMenuItem.Text = "Añadir logo"
        '
        'EliminarLogoToolStripMenuItem
        '
        Me.EliminarLogoToolStripMenuItem.Name = "EliminarLogoToolStripMenuItem"
        Me.EliminarLogoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarLogoToolStripMenuItem.Text = "Eliminar logo"
        '
        'GestionEtiquetaLogisticaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 715)
        Me.Controls.Add(Me.gbImagenCliente)
        Me.Controls.Add(Me.gbData)
        Me.Name = "GestionEtiquetaLogisticaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECTOR DE LOGOS"
        Me.gbImagenCliente.ResumeLayout(False)
        CType(Me.lectorPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagenCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        Me.menuStripLogo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbImagenCliente As GroupBox
    Friend WithEvents pbImagenCliente As PictureBox
    Friend WithEvents gbData As GroupBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tbCliente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lectorPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnLoadPDF As Button
    Friend WithEvents tbPathPDF As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileDialogPDF As OpenFileDialog
    Friend WithEvents menuStripLogo As ContextMenuStrip
    Friend WithEvents btnBorrarPDF As Button
    Friend WithEvents AñadirLogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EliminarLogoToolStripMenuItem As ToolStripMenuItem
End Class
