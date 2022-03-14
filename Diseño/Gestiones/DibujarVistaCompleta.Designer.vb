<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DibujarVistaCompleta
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
        Me.components = New System.ComponentModel.Container
        Dim AgrupacionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DibujarVistaCompleta))
        Me.AgrupacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Agrupaciones = New ERP_SUGAR.Agrupaciones
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.lbTituloPendientes = New System.Windows.Forms.Label
        Me.DR = New Microsoft.VisualBasic.PowerPacks.DataRepeater
        Me.ckCompletos = New System.Windows.Forms.CheckBox
        Me.CantidadTextBox = New System.Windows.Forms.TextBox
        Me.AgrupacionesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.AgrupacionesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.clbClientes = New System.Windows.Forms.CheckedListBox
        AgrupacionLabel = New System.Windows.Forms.Label
        CType(Me.AgrupacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Agrupaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DR.ItemTemplate.SuspendLayout()
        Me.DR.SuspendLayout()
        CType(Me.AgrupacionesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AgrupacionesBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'AgrupacionLabel
        '
        AgrupacionLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AgrupacionesBindingSource, "Agrupacion", True))
        AgrupacionLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AgrupacionLabel.ForeColor = System.Drawing.Color.DarkBlue
        AgrupacionLabel.Location = New System.Drawing.Point(1, 3)
        AgrupacionLabel.Name = "AgrupacionLabel"
        AgrupacionLabel.Size = New System.Drawing.Size(141, 17)
        AgrupacionLabel.TabIndex = 0
        AgrupacionLabel.Text = "Agrupación:"
        AgrupacionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AgrupacionesBindingSource
        '
        Me.AgrupacionesBindingSource.DataMember = "Agrupaciones"
        Me.AgrupacionesBindingSource.DataSource = Me.Agrupaciones
        '
        'Agrupaciones
        '
        Me.Agrupaciones.DataSetName = "Agrupaciones"
        Me.Agrupaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ColumnHeadersVisible = False
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv.Location = New System.Drawing.Point(2, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv.ShowEditingIcon = False
        Me.dgv.Size = New System.Drawing.Size(1220, 569)
        Me.dgv.TabIndex = 1
        '
        'lbTituloPendientes
        '
        Me.lbTituloPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTituloPendientes.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbTituloPendientes.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTituloPendientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTituloPendientes.Location = New System.Drawing.Point(-1, 596)
        Me.lbTituloPendientes.Name = "lbTituloPendientes"
        Me.lbTituloPendientes.Size = New System.Drawing.Size(88, 41)
        Me.lbTituloPendientes.TabIndex = 205
        Me.lbTituloPendientes.Text = "EQUIPOS PENDIENTES:"
        Me.lbTituloPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DR
        '
        Me.DR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DR.ItemHeaderVisible = False
        '
        'DR.ItemTemplate
        '
        Me.DR.ItemTemplate.Controls.Add(Me.CantidadTextBox)
        Me.DR.ItemTemplate.Controls.Add(AgrupacionLabel)
        Me.DR.ItemTemplate.Size = New System.Drawing.Size(216, 47)
        Me.DR.LayoutStyle = Microsoft.VisualBasic.PowerPacks.DataRepeaterLayoutStyles.Horizontal
        Me.DR.Location = New System.Drawing.Point(88, 592)
        Me.DR.Margin = New System.Windows.Forms.Padding(0)
        Me.DR.Name = "DR"
        Me.DR.Size = New System.Drawing.Size(942, 55)
        Me.DR.TabIndex = 209
        Me.DR.Text = "DataRepeater1"
        '
        'ckCompletos
        '
        Me.ckCompletos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckCompletos.AutoSize = True
        Me.ckCompletos.Location = New System.Drawing.Point(88, 572)
        Me.ckCompletos.Name = "ckCompletos"
        Me.ckCompletos.Size = New System.Drawing.Size(92, 17)
        Me.ckCompletos.TabIndex = 4
        Me.ckCompletos.Text = "COMPLETOS"
        Me.ckCompletos.UseVisualStyleBackColor = True
        '
        'CantidadTextBox
        '
        Me.CantidadTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AgrupacionesBindingSource, "Cantidad", True))
        Me.CantidadTextBox.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadTextBox.Location = New System.Drawing.Point(143, 0)
        Me.CantidadTextBox.Name = "CantidadTextBox"
        Me.CantidadTextBox.Size = New System.Drawing.Size(62, 23)
        Me.CantidadTextBox.TabIndex = 3
        Me.CantidadTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AgrupacionesBindingNavigator
        '
        Me.AgrupacionesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.AgrupacionesBindingNavigator.BindingSource = Me.AgrupacionesBindingSource
        Me.AgrupacionesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.AgrupacionesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.AgrupacionesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.AgrupacionesBindingNavigatorSaveItem})
        Me.AgrupacionesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.AgrupacionesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.AgrupacionesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.AgrupacionesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.AgrupacionesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.AgrupacionesBindingNavigator.Name = "AgrupacionesBindingNavigator"
        Me.AgrupacionesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.AgrupacionesBindingNavigator.Size = New System.Drawing.Size(1222, 25)
        Me.AgrupacionesBindingNavigator.TabIndex = 210
        Me.AgrupacionesBindingNavigator.Text = "BindingNavigator1"
        Me.AgrupacionesBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'AgrupacionesBindingNavigatorSaveItem
        '
        Me.AgrupacionesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AgrupacionesBindingNavigatorSaveItem.Enabled = False
        Me.AgrupacionesBindingNavigatorSaveItem.Image = CType(resources.GetObject("AgrupacionesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.AgrupacionesBindingNavigatorSaveItem.Name = "AgrupacionesBindingNavigatorSaveItem"
        Me.AgrupacionesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.AgrupacionesBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'clbClientes
        '
        Me.clbClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clbClientes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbClientes.FormattingEnabled = True
        Me.clbClientes.Location = New System.Drawing.Point(1033, 592)
        Me.clbClientes.Name = "clbClientes"
        Me.clbClientes.Size = New System.Drawing.Size(189, 55)
        Me.clbClientes.TabIndex = 211
        '
        'DibujarVistaCompleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1222, 647)
        Me.Controls.Add(Me.ckCompletos)
        Me.Controls.Add(Me.clbClientes)
        Me.Controls.Add(Me.AgrupacionesBindingNavigator)
        Me.Controls.Add(Me.DR)
        Me.Controls.Add(Me.lbTituloPendientes)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DibujarVistaCompleta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRODUCCIÓN TALLER"
        CType(Me.AgrupacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Agrupaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DR.ItemTemplate.ResumeLayout(False)
        Me.DR.ItemTemplate.PerformLayout()
        Me.DR.ResumeLayout(False)
        CType(Me.AgrupacionesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AgrupacionesBindingNavigator.ResumeLayout(False)
        Me.AgrupacionesBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lbTituloPendientes As System.Windows.Forms.Label
    Friend WithEvents DR As Microsoft.VisualBasic.PowerPacks.DataRepeater
    Friend WithEvents CantidadTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AgrupacionesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Agrupaciones As ERP_SUGAR.Agrupaciones
    Friend WithEvents AgrupacionesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AgrupacionesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents clbClientes As System.Windows.Forms.CheckedListBox
    Friend WithEvents ckCompletos As System.Windows.Forms.CheckBox
End Class
