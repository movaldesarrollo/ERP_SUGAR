<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionComposicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionComposicion))
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCantidadE = New System.Windows.Forms.ColumnHeader
        Me.lvPVPOpcion = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bVerArticuloBase = New System.Windows.Forms.Button
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbMonedaComp = New System.Windows.Forms.Label
        Me.lbMoneda = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DescripcionEN = New System.Windows.Forms.TextBox
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.ArticuloBase = New System.Windows.Forms.TextBox
        Me.codArticuloBase = New System.Windows.Forms.TextBox
        Me.PVPComp = New System.Windows.Forms.TextBox
        Me.PVP = New System.Windows.Forms.TextBox
        Me.codArticuloComp = New System.Windows.Forms.TextBox
        Me.ArticuloEN = New System.Windows.Forms.TextBox
        Me.ArticuloComp = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bBuscarOpcion = New System.Windows.Forms.Button
        Me.cbCodArticuloC = New System.Windows.Forms.ComboBox
        Me.lbOpciones = New System.Windows.Forms.Label
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbArticuloC = New System.Windows.Forms.ComboBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bMenosOpcion = New System.Windows.Forms.Button
        Me.bVerArticuloOpcion = New System.Windows.Forms.Button
        Me.bLimpiaOpcion = New System.Windows.Forms.Button
        Me.bMasOpcion = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.Version = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidConcepto, Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCantidadE, Me.lvPVPOpcion, Me.lvCantidad})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.Location = New System.Drawing.Point(5, 55)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.Size = New System.Drawing.Size(921, 261)
        Me.lvConceptos.TabIndex = 8
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 118
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 609
        '
        'lvCantidadE
        '
        Me.lvCantidadE.Text = "CANTIDAD"
        Me.lvCantidadE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidadE.Width = 78
        '
        'lvPVPOpcion
        '
        Me.lvPVPOpcion.Text = "PRECIO"
        Me.lvPVPOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPVPOpcion.Width = 73
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "Cantidad"
        Me.lvCantidad.Width = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bVerArticuloBase)
        Me.GroupBox1.Controls.Add(Me.bVerArticulo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbMonedaComp)
        Me.GroupBox1.Controls.Add(Me.lbMoneda)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DescripcionEN)
        Me.GroupBox1.Controls.Add(Me.Descripcion)
        Me.GroupBox1.Controls.Add(Me.ArticuloBase)
        Me.GroupBox1.Controls.Add(Me.codArticuloBase)
        Me.GroupBox1.Controls.Add(Me.PVPComp)
        Me.GroupBox1.Controls.Add(Me.Version)
        Me.GroupBox1.Controls.Add(Me.PVP)
        Me.GroupBox1.Controls.Add(Me.codArticuloComp)
        Me.GroupBox1.Controls.Add(Me.ArticuloEN)
        Me.GroupBox1.Controls.Add(Me.ArticuloComp)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(933, 306)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'bVerArticuloBase
        '
        Me.bVerArticuloBase.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloBase.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloBase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloBase.Location = New System.Drawing.Point(310, 17)
        Me.bVerArticuloBase.Name = "bVerArticuloBase"
        Me.bVerArticuloBase.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloBase.TabIndex = 1
        Me.bVerArticuloBase.UseVisualStyleBackColor = True
        '
        'bVerArticulo
        '
        Me.bVerArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticulo.Location = New System.Drawing.Point(310, 45)
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticulo.TabIndex = 5
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(3, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 17)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "ARTÍCULO BASE"
        '
        'lbMonedaComp
        '
        Me.lbMonedaComp.AutoSize = True
        Me.lbMonedaComp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMonedaComp.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaComp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaComp.Location = New System.Drawing.Point(897, 49)
        Me.lbMonedaComp.Name = "lbMonedaComp"
        Me.lbMonedaComp.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaComp.TabIndex = 112
        Me.lbMonedaComp.Text = "€"
        '
        'lbMoneda
        '
        Me.lbMoneda.AutoSize = True
        Me.lbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda.Location = New System.Drawing.Point(897, 21)
        Me.lbMoneda.Name = "lbMoneda"
        Me.lbMoneda.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda.TabIndex = 112
        Me.lbMoneda.Text = "€"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(676, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 17)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "PVP ARTÍCULO COMP."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(788, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "PVP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 17)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "ARTÍCULO COMP."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(3, 238)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "DESCRIPTION"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(3, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "NAME COMP."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(3, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "DESCRIPCIÓN"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(3, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "NOMBRE COMP."
        '
        'DescripcionEN
        '
        Me.DescripcionEN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionEN.Location = New System.Drawing.Point(121, 234)
        Me.DescripcionEN.MaxLength = 400
        Me.DescripcionEN.Multiline = True
        Me.DescripcionEN.Name = "DescripcionEN"
        Me.DescripcionEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DescripcionEN.Size = New System.Drawing.Size(806, 60)
        Me.DescripcionEN.TabIndex = 11
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(121, 168)
        Me.Descripcion.MaxLength = 400
        Me.Descripcion.Multiline = True
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Descripcion.Size = New System.Drawing.Size(806, 60)
        Me.Descripcion.TabIndex = 10
        '
        'ArticuloBase
        '
        Me.ArticuloBase.BackColor = System.Drawing.SystemColors.Window
        Me.ArticuloBase.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloBase.Location = New System.Drawing.Point(340, 18)
        Me.ArticuloBase.MaxLength = 30
        Me.ArticuloBase.Name = "ArticuloBase"
        Me.ArticuloBase.ReadOnly = True
        Me.ArticuloBase.Size = New System.Drawing.Size(442, 23)
        Me.ArticuloBase.TabIndex = 2
        '
        'codArticuloBase
        '
        Me.codArticuloBase.BackColor = System.Drawing.SystemColors.Window
        Me.codArticuloBase.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloBase.Location = New System.Drawing.Point(121, 18)
        Me.codArticuloBase.MaxLength = 30
        Me.codArticuloBase.Name = "codArticuloBase"
        Me.codArticuloBase.ReadOnly = True
        Me.codArticuloBase.Size = New System.Drawing.Size(175, 23)
        Me.codArticuloBase.TabIndex = 0
        '
        'PVPComp
        '
        Me.PVPComp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PVPComp.Location = New System.Drawing.Point(824, 46)
        Me.PVPComp.MaxLength = 30
        Me.PVPComp.Name = "PVPComp"
        Me.PVPComp.Size = New System.Drawing.Size(70, 23)
        Me.PVPComp.TabIndex = 7
        Me.PVPComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PVP
        '
        Me.PVP.BackColor = System.Drawing.SystemColors.Window
        Me.PVP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PVP.Location = New System.Drawing.Point(824, 18)
        Me.PVP.MaxLength = 30
        Me.PVP.Name = "PVP"
        Me.PVP.ReadOnly = True
        Me.PVP.Size = New System.Drawing.Size(70, 23)
        Me.PVP.TabIndex = 3
        Me.PVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'codArticuloComp
        '
        Me.codArticuloComp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloComp.Location = New System.Drawing.Point(121, 46)
        Me.codArticuloComp.MaxLength = 30
        Me.codArticuloComp.Name = "codArticuloComp"
        Me.codArticuloComp.Size = New System.Drawing.Size(175, 23)
        Me.codArticuloComp.TabIndex = 4
        '
        'ArticuloEN
        '
        Me.ArticuloEN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloEN.Location = New System.Drawing.Point(121, 122)
        Me.ArticuloEN.MaxLength = 300
        Me.ArticuloEN.Multiline = True
        Me.ArticuloEN.Name = "ArticuloEN"
        Me.ArticuloEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ArticuloEN.Size = New System.Drawing.Size(806, 40)
        Me.ArticuloEN.TabIndex = 9
        '
        'ArticuloComp
        '
        Me.ArticuloComp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloComp.Location = New System.Drawing.Point(121, 76)
        Me.ArticuloComp.MaxLength = 300
        Me.ArticuloComp.Multiline = True
        Me.ArticuloComp.Name = "ArticuloComp"
        Me.ArticuloComp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ArticuloComp.Size = New System.Drawing.Size(806, 40)
        Me.ArticuloComp.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(8, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 177
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(860, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(664, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 2
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bBuscarOpcion
        '
        Me.bBuscarOpcion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarOpcion.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarOpcion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarOpcion.Location = New System.Drawing.Point(269, 19)
        Me.bBuscarOpcion.Name = "bBuscarOpcion"
        Me.bBuscarOpcion.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarOpcion.TabIndex = 1
        Me.bBuscarOpcion.UseVisualStyleBackColor = True
        '
        'cbCodArticuloC
        '
        Me.cbCodArticuloC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticuloC.FormattingEnabled = True
        Me.cbCodArticuloC.Location = New System.Drawing.Point(121, 19)
        Me.cbCodArticuloC.MaxLength = 15
        Me.cbCodArticuloC.Name = "cbCodArticuloC"
        Me.cbCodArticuloC.Size = New System.Drawing.Size(142, 25)
        Me.cbCodArticuloC.TabIndex = 0
        '
        'lbOpciones
        '
        Me.lbOpciones.AutoSize = True
        Me.lbOpciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOpciones.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbOpciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbOpciones.Location = New System.Drawing.Point(31, 23)
        Me.lbOpciones.Name = "lbOpciones"
        Me.lbOpciones.Size = New System.Drawing.Size(62, 17)
        Me.lbOpciones.TabIndex = 192
        Me.lbOpciones.Text = "OPCIÓN"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(814, 23)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(20, 17)
        Me.lbUnidad.TabIndex = 191
        Me.lbUnidad.Text = "u."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(694, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 17)
        Me.Label7.TabIndex = 190
        Me.Label7.Text = "CANTIDAD"
        '
        'cbArticuloC
        '
        Me.cbArticuloC.DropDownWidth = 530
        Me.cbArticuloC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticuloC.FormattingEnabled = True
        Me.cbArticuloC.Location = New System.Drawing.Point(304, 19)
        Me.cbArticuloC.MaxLength = 200
        Me.cbArticuloC.Name = "cbArticuloC"
        Me.cbArticuloC.Size = New System.Drawing.Size(354, 25)
        Me.cbArticuloC.TabIndex = 2
        '
        'Cantidad
        '
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.Color.DarkRed
        Me.Cantidad.Location = New System.Drawing.Point(770, 20)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(43, 23)
        Me.Cantidad.TabIndex = 4
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.bMenosOpcion)
        Me.GroupBox2.Controls.Add(Me.bVerArticuloOpcion)
        Me.GroupBox2.Controls.Add(Me.bLimpiaOpcion)
        Me.GroupBox2.Controls.Add(Me.bMasOpcion)
        Me.GroupBox2.Controls.Add(Me.lvConceptos)
        Me.GroupBox2.Controls.Add(Me.Cantidad)
        Me.GroupBox2.Controls.Add(Me.bBuscarOpcion)
        Me.GroupBox2.Controls.Add(Me.cbArticuloC)
        Me.GroupBox2.Controls.Add(Me.cbCodArticuloC)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lbOpciones)
        Me.GroupBox2.Controls.Add(Me.lbUnidad)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 381)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(933, 322)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPCIONES"
        '
        'bMenosOpcion
        '
        Me.bMenosOpcion.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMenosOpcion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMenosOpcion.Location = New System.Drawing.Point(872, 19)
        Me.bMenosOpcion.Name = "bMenosOpcion"
        Me.bMenosOpcion.Size = New System.Drawing.Size(25, 25)
        Me.bMenosOpcion.TabIndex = 6
        Me.bMenosOpcion.Text = "-"
        Me.bMenosOpcion.UseVisualStyleBackColor = True
        '
        'bVerArticuloOpcion
        '
        Me.bVerArticuloOpcion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloOpcion.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloOpcion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloOpcion.Location = New System.Drawing.Point(664, 19)
        Me.bVerArticuloOpcion.Name = "bVerArticuloOpcion"
        Me.bVerArticuloOpcion.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloOpcion.TabIndex = 3
        Me.bVerArticuloOpcion.UseVisualStyleBackColor = True
        '
        'bLimpiaOpcion
        '
        Me.bLimpiaOpcion.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiaOpcion.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiaOpcion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiaOpcion.Location = New System.Drawing.Point(900, 19)
        Me.bLimpiaOpcion.Name = "bLimpiaOpcion"
        Me.bLimpiaOpcion.Size = New System.Drawing.Size(25, 25)
        Me.bLimpiaOpcion.TabIndex = 7
        Me.bLimpiaOpcion.UseVisualStyleBackColor = True
        '
        'bMasOpcion
        '
        Me.bMasOpcion.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMasOpcion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMasOpcion.Location = New System.Drawing.Point(844, 19)
        Me.bMasOpcion.Name = "bMasOpcion"
        Me.bMasOpcion.Size = New System.Drawing.Size(25, 25)
        Me.bMasOpcion.TabIndex = 5
        Me.bMasOpcion.Text = "+"
        Me.bMasOpcion.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(762, 12)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 3
        Me.bBorrar.Text = "LIMPIAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.BackColor = System.Drawing.SystemColors.Window
        Me.Version.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.Location = New System.Drawing.Point(604, 46)
        Me.Version.MaxLength = 30
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.Size = New System.Drawing.Size(54, 23)
        Me.Version.TabIndex = 6
        Me.Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(538, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 17)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "VERSIÓN"
        '
        'GestionComposicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 715)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionComposicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESCANDALLO DE ARTÍCULO CON OPCIONES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidadE As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents codArticuloComp As System.Windows.Forms.TextBox
    Friend WithEvents ArticuloComp As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionEN As System.Windows.Forms.TextBox
    Friend WithEvents ArticuloEN As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bBuscarOpcion As System.Windows.Forms.Button
    Friend WithEvents cbCodArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents lbOpciones As System.Windows.Forms.Label
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbArticuloC As System.Windows.Forms.ComboBox
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ArticuloBase As System.Windows.Forms.TextBox
    Friend WithEvents codArticuloBase As System.Windows.Forms.TextBox
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bVerArticuloBase As System.Windows.Forms.Button
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bMenosOpcion As System.Windows.Forms.Button
    Friend WithEvents bLimpiaOpcion As System.Windows.Forms.Button
    Friend WithEvents bMasOpcion As System.Windows.Forms.Button
    Friend WithEvents lvPVPOpcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMoneda As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PVP As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaComp As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PVPComp As System.Windows.Forms.TextBox
    Friend WithEvents bVerArticuloOpcion As System.Windows.Forms.Button
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.TextBox
End Class
