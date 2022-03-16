<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class textListadoPedidosAX
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(textListadoPedidosAX))
        Me.txListado = New System.Windows.Forms.TextBox()
        Me.bCopiar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txListado
        '
        Me.txListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txListado.Location = New System.Drawing.Point(12, 13)
        Me.txListado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txListado.Multiline = True
        Me.txListado.Name = "txListado"
        Me.txListado.ReadOnly = True
        Me.txListado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txListado.Size = New System.Drawing.Size(436, 408)
        Me.txListado.TabIndex = 0
        '
        'bCopiar
        '
        Me.bCopiar.Location = New System.Drawing.Point(12, 428)
        Me.bCopiar.Name = "bCopiar"
        Me.bCopiar.Size = New System.Drawing.Size(436, 23)
        Me.bCopiar.TabIndex = 1
        Me.bCopiar.Text = "COPIAR TODO"
        Me.bCopiar.UseVisualStyleBackColor = True
        '
        'textListadoPedidosAX
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(460, 464)
        Me.Controls.Add(Me.bCopiar)
        Me.Controls.Add(Me.txListado)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "textListadoPedidosAX"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LISTADO PEDIDOS AX Y FECHA DE PRODUCCIÓN"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txListado As TextBox
    Friend WithEvents bCopiar As Button
End Class
