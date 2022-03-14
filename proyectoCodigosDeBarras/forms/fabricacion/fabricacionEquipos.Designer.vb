<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fabricacionEquipos
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
        Me.bBorrarEquipo = New System.Windows.Forms.Button()
        Me.lvEquipos = New System.Windows.Forms.ListView()
        Me.colIDEquipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerieCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEquipos = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txCode = New System.Windows.Forms.TextBox()
        Me.bEtiquetas = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txTotalEquipos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.bBusquedaEquipo = New System.Windows.Forms.Button()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.btnSeleccionImp = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bBorrarEquipo
        '
        Me.bBorrarEquipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrarEquipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarEquipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrarEquipo.Location = New System.Drawing.Point(851, 13)
        Me.bBorrarEquipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBorrarEquipo.Name = "bBorrarEquipo"
        Me.bBorrarEquipo.Size = New System.Drawing.Size(150, 71)
        Me.bBorrarEquipo.TabIndex = 5
        Me.bBorrarEquipo.Text = "BORRAR EQUIPO"
        Me.bBorrarEquipo.UseVisualStyleBackColor = True
        '
        'lvEquipos
        '
        Me.lvEquipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEquipos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDEquipo, Me.colNumSerieCelula, Me.colArticulo, Me.colFecha})
        Me.lvEquipos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEquipos.FullRowSelect = True
        Me.lvEquipos.GridLines = True
        Me.lvEquipos.HideSelection = False
        Me.lvEquipos.Location = New System.Drawing.Point(12, 168)
        Me.lvEquipos.Name = "lvEquipos"
        Me.lvEquipos.Size = New System.Drawing.Size(1301, 462)
        Me.lvEquipos.TabIndex = 2
        Me.lvEquipos.UseCompatibleStateImageBehavior = False
        Me.lvEquipos.View = System.Windows.Forms.View.Details
        '
        'colIDEquipo
        '
        Me.colIDEquipo.Text = "ID EQUIPO"
        Me.colIDEquipo.Width = 0
        '
        'colNumSerieCelula
        '
        Me.colNumSerieCelula.Text = "NºSERIE EQUIPO"
        Me.colNumSerieCelula.Width = 298
        '
        'colArticulo
        '
        Me.colArticulo.DisplayIndex = 3
        Me.colArticulo.Text = "CÓDIGO - ARTÍCULO"
        Me.colArticulo.Width = 667
        '
        'colFecha
        '
        Me.colFecha.DisplayIndex = 2
        Me.colFecha.Text = "FECHA FABRICACIÓN"
        Me.colFecha.Width = 254
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 162
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbEquipos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1301, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES FABRICACIÓN DE EQUIPOS"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(962, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "FECHA FABRICACIÓN"
        Me.Label3.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(1151, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(142, 27)
        Me.dtpFecha.TabIndex = 2
        Me.dtpFecha.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CÓDIGO - ARTÍCULO"
        '
        'cbEquipos
        '
        Me.cbEquipos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEquipos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEquipos.FormattingEnabled = True
        Me.cbEquipos.Location = New System.Drawing.Point(188, 25)
        Me.cbEquipos.Name = "cbEquipos"
        Me.cbEquipos.Size = New System.Drawing.Size(1105, 29)
        Me.cbEquipos.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NºSERIE EQUIPO"
        Me.Label1.Visible = False
        '
        'txCode
        '
        Me.txCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCode.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCode.Location = New System.Drawing.Point(147, 26)
        Me.txCode.Name = "txCode"
        Me.txCode.Size = New System.Drawing.Size(121, 27)
        Me.txCode.TabIndex = 0
        Me.txCode.Visible = False
        '
        'bEtiquetas
        '
        Me.bEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEtiquetas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEtiquetas.Location = New System.Drawing.Point(383, 13)
        Me.bEtiquetas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bEtiquetas.Name = "bEtiquetas"
        Me.bEtiquetas.Size = New System.Drawing.Size(150, 71)
        Me.bEtiquetas.TabIndex = 2
        Me.bEtiquetas.Text = "IMPRIMIR ETIQUETAS"
        Me.bEtiquetas.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1007, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.bLimpiar.TabIndex = 6
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1163, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 71)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1063, 637)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 21)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "TOTAL EQUIPOS"
        '
        'txTotalEquipos
        '
        Me.txTotalEquipos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalEquipos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txTotalEquipos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalEquipos.Location = New System.Drawing.Point(1203, 634)
        Me.txTotalEquipos.Name = "txTotalEquipos"
        Me.txTotalEquipos.Size = New System.Drawing.Size(110, 27)
        Me.txTotalEquipos.TabIndex = 164
        Me.txTotalEquipos.TabStop = False
        Me.txTotalEquipos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 633)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(453, 19)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "EQUIPOS ASIGNADOS A UN PEDIDO, NO SE PUEDEN BORRAR"
        '
        'bBusquedaEquipo
        '
        Me.bBusquedaEquipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBusquedaEquipo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBusquedaEquipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBusquedaEquipo.Location = New System.Drawing.Point(229, 13)
        Me.bBusquedaEquipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBusquedaEquipo.Name = "bBusquedaEquipo"
        Me.bBusquedaEquipo.Size = New System.Drawing.Size(150, 71)
        Me.bBusquedaEquipo.TabIndex = 1
        Me.bBusquedaEquipo.Text = "BÚSQUEDA EQUIPO"
        Me.bBusquedaEquipo.UseVisualStyleBackColor = True
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReimprimir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReimprimir.Location = New System.Drawing.Point(539, 13)
        Me.btnReimprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(150, 71)
        Me.btnReimprimir.TabIndex = 3
        Me.btnReimprimir.Text = "REIMPRIMIR ETIQUETAS"
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'btnSeleccionImp
        '
        Me.btnSeleccionImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSeleccionImp.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionImp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSeleccionImp.Location = New System.Drawing.Point(695, 13)
        Me.btnSeleccionImp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSeleccionImp.Name = "btnSeleccionImp"
        Me.btnSeleccionImp.Size = New System.Drawing.Size(150, 71)
        Me.btnSeleccionImp.TabIndex = 4
        Me.btnSeleccionImp.Text = "RESET IMPRESORAS"
        Me.btnSeleccionImp.UseVisualStyleBackColor = True
        '
        'fabricacionEquipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 677)
        Me.Controls.Add(Me.btnReimprimir)
        Me.Controls.Add(Me.btnSeleccionImp)
        Me.Controls.Add(Me.bBusquedaEquipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txTotalEquipos)
        Me.Controls.Add(Me.bBorrarEquipo)
        Me.Controls.Add(Me.lvEquipos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bEtiquetas)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "fabricacionEquipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FABRICACIÓN EQUIPOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bBorrarEquipo As Button
    Friend WithEvents lvEquipos As ListView
    Friend WithEvents colIDEquipo As ColumnHeader
    Friend WithEvents colNumSerieCelula As ColumnHeader
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents colFecha As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cbEquipos As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txCode As TextBox
    Friend WithEvents bEtiquetas As Button
    Friend WithEvents bLimpiar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txTotalEquipos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents bBusquedaEquipo As Button
    Friend WithEvents btnReimprimir As Button
    Friend WithEvents btnSeleccionImp As Button
End Class
