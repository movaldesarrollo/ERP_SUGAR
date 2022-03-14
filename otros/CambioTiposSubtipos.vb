Imports System.Data.SqlClient
Imports System.Data
'Esta formulario muestra todos los articulos con tipo o subtipo no asignado.
'También editar el tipo y subtipo de los articulos.
Public Class CambioTiposSubtipos
    Dim funCon As New conexion
    Dim cnt As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim idarticulo As String
    Dim cargaok As Boolean = False
    Dim listviewok As Boolean = False
    Dim ee As Boolean

    Private Sub CambioTiposSubtipos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        cnt.Close()
        Inicio.Close()
    End Sub

    'Cargamos el formulario, llenamos el Listview y el combobox de tipos.
    Private Sub CambioTiposSubtipos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarLsvTiposSubtiposVacios()
        llenarComboboxTipo()
        ComboBox1.SelectedValue = 0
    End Sub

#Region "LISTVIEW" 'Codigo del Listview
    'Edita alguna propiedades del Listview y ejecuta la carga.
    Public Sub llenarLsvTiposSubtiposVacios()
        With lsvAddTiposSubtipos
            .Columns.Clear()
            .Items.Clear()
            .View = View.Details
            .GridLines = True
            .FullRowSelect = False
            .Scrollable = True
            .HideSelection = False
            '.CheckBoxes = True
            .Columns.Add("", 20, HorizontalAlignment.Left)
            .Columns.Add("ARTICULO", 400, HorizontalAlignment.Left)
            .Columns.Add("DESCRICION", 400, HorizontalAlignment.Left)
            .Columns.Add("TIPO", 200, HorizontalAlignment.Left)
            .Columns.Add("SUBTIPO", 200, HorizontalAlignment.Left)
        End With
        cargarTiposSubtiposLsv()
    End Sub
    'Consulta en la base de datos y captura todos los articulos que tienen idtipoarticulo y idsubtipoarticulo =0.
    Public Sub cargarTiposSubtiposLsv()
        ds.Clear()
        Dim sconexion As String = funCon.CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        cnt = New SqlConnection("Data Source=SRVSUGAR\SQLSUGAR;Initial Catalog=ERP_SUGAR;Persist Security Info=True;User ID=sugar;Password=sugar")
        If ckTodos.Checked = True Then
            cmd = New SqlCommand("Select *, tipoarticulo, subtipoarticulo  from articulos left join TiposArticulo on articulos.idtipoarticulo = TiposArticulo.idtipoarticulo left join subtiposarticulo on articulos.idsubtipoarticulo = subtiposarticulo.idsubtipoarticulo where vendible=1 order by articulo", con)
        Else
            cmd = New SqlCommand("Select *, tipoarticulo, subtipoarticulo  from articulos left join TiposArticulo on articulos.idtipoarticulo = TiposArticulo.idtipoarticulo left join subtiposarticulo on articulos.idsubtipoarticulo = subtiposarticulo.idsubtipoarticulo where (articulos.idtipoarticulo = 0 or articulos.idsubtipoarticulo = 0) and vendible=1  order by articulo", con)
        End If
        da = New SqlDataAdapter
        da.SelectCommand = cmd
        cnt.Open()
        da.Fill(ds, "articulos")
        cnt.Close()
        cargarlsv()
    End Sub
    'Carga los datos en el Listview
    Public Sub cargarlsv()
        Dim objListItem As New ListViewItem
        Dim cant As Double = 0
        Me.lsvAddTiposSubtipos.Items.Clear()
        listviewok = False
        For Each drw As DataRow In ds.Tables("articulos").Rows
            objListItem = lsvAddTiposSubtipos.Items.Add(drw.Item("idarticulo").ToString, 0)
            objListItem.SubItems.Add(drw.Item("Articulo").ToString)
            objListItem.SubItems.Add(drw.Item("Descripcion").ToString)
            objListItem.SubItems.Add(drw.Item("tipoarticulo").ToString)
            objListItem.SubItems.Add(drw.Item("SubTipoArticulo").ToString)
            cant = cant + 1
        Next
        listviewok = True
        ElementosEncontrados.Text = cant
    End Sub
#End Region
#Region "COMBOBOX" 'Codigo Combobox
    'carga los tipos en el combobox 1
    Public Sub llenarComboboxTipo()
        dt.Clear()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select idtipoarticulo, tipoarticulo from tiposarticulo order by tipoarticulo"
        cmd.Connection = (cnt)
        cnt.Open()
        da.Fill(dt)
        cnt.Close()
        With ComboBox1
            .DataSource = dt
            .DisplayMember = "tipoarticulo"
            .ValueMember = "idtipoarticulo"
        End With
        cargaok = True
    End Sub
    'Si el valor del combobox1 cambia y si la carga del combobox1 a finalizado, entonces llena el combobox2
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If cargaok = True And ComboBox1.Text <> "" Then
            llenarComboboxSubTipo()
        End If
    End Sub
    'carga los subtipos en el combobox 2
    Public Sub llenarComboboxSubTipo()
        dt1.Clear()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select idsubtipoarticulo, subtipoarticulo from subtiposarticulo where idtipoarticulo = " & ComboBox1.SelectedValue & ""
        cmd.Connection = (cnt)
        cnt.Close()
        cnt.Open()
        da.Fill(dt1)
        cnt.Close()
        With ComboBox2
            .DataSource = dt1
            .DisplayMember = "subtipoarticulo"
            .ValueMember = "idsubtipoarticulo"
        End With
    End Sub
#End Region

#Region "BOTONES"
    'Este boton actualiza los articulos seleccionados en el listview si se ha selecionado un tipo o subtipo en los combobox1 y 2
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        checkedos()
        If ee = False Then
            MsgBox("Seleccione al menos un articulo antes de guardar.")
        Else
            If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
                MsgBox("Es necesario seleccionar tipo y subtipo antes de actualizar", MsgBoxStyle.Information)
            Else
                Try
                    For i As Int16 = 0 To lsvAddTiposSubtipos.CheckedIndices.Count - 1
                        idarticulo = lsvAddTiposSubtipos.CheckedItems.Item(i).Text
                        fmodificar()
                    Next
                    MsgBox("Actualizado", MsgBoxStyle.Information)

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                fclear()
            End If
            ee = False
        End If
    End Sub
    'Este boton vacia los combobox y actualiza el listview
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fclear()
    End Sub
#End Region

#Region "FUNCIONES"
    'Vacia actualiza el listview
    Public Sub fclear()
        cargarTiposSubtiposLsv()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox2.DataSource = Nothing
        ComboBox2.Items.Clear()
        CheckBox1.Checked = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        'llenarLsvTiposSubtiposVacios()
    End Sub
    'Modifica los articulos seleccionados en Listview con los datos de los combobox
    Public Sub fmodificar()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update articulos set idtipoarticulo =" & ComboBox1.SelectedValue & ", idsubtipoarticulo = " & ComboBox2.SelectedValue & " where idarticulo = " & idarticulo
        cmd.Connection = (cnt)
        cnt.Open()
        cmd.ExecuteNonQuery()
        cnt.Close()
    End Sub
#End Region

#Region "CHECKBOX" 'Codigo checkbox
    'Cambia el estado de todos los checkbox. 
    Private Sub CheckBox1_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.Checked = CheckState.Indeterminate Then
        Else
            listviewok = False
            For Each item As ListViewItem In lsvAddTiposSubtipos.Items
                item.Checked = CheckBox1.Checked
            Next
            listviewok = True
            Call comprobarcombos()
        End If
    End Sub
    'Si no hay ningun Item seleccionado devuelve valor falso.
    Public Sub checkedos()
        For Each item As ListViewItem In lsvAddTiposSubtipos.Items
            If item.Checked = True Then
                ee = True
            End If
        Next
    End Sub

    Private Sub ckTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckTodos.CheckedChanged
        fclear()
    End Sub
#End Region

    Private Sub lsvAddTiposSubtipos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lsvAddTiposSubtipos.ItemChecked
        Call comprobarcombos()
    End Sub

    Private Sub comprobarcombos()
        If listviewok = True Then
            If lsvAddTiposSubtipos.Items.Count > 0 Then
                Dim variable As Integer
                variable = 0
                For i = 1 To lsvAddTiposSubtipos.Items.Count
                    If lsvAddTiposSubtipos.Items(i - 1).Checked = True Then
                        variable = 1
                    End If
                Next
                If variable = 1 Then
                    ComboBox1.Enabled = True
                    ComboBox2.Enabled = True
                Else
                    ComboBox1.Enabled = False
                    ComboBox2.Enabled = False
                    ComboBox1.Text = ""
                    ComboBox2.Text = ""
                    ComboBox2.DataSource = Nothing
                    ComboBox2.Items.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        e.Handled = True
    End Sub
End Class