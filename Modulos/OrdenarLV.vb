Imports System.Collections
Imports System.Windows.Forms

Public Class OrdenarLV
    Implements System.Collections.IComparer
    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ' Inicializar la columna a '0'. 
        ColumnToSort = 0

        ' Inicializar el tipo de orden en 'ninguno'. 
        OrderOfSort = SortOrder.None

        ' Inicializar el objeto CaseInsensitiveComparer. 
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Convertir el tipo de los objetos para compararlos con los objetos ListViewItem. 
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)
        Dim lvDateX As DateTime
        Dim lvDateY As DateTime
        Dim lvDoubleX As Double
        Dim lvDoubleY As Double
        Dim lvIntX As Integer
        Dim lvIntY As Integer
        Dim lvTextX As String = listviewX.SubItems(ColumnToSort).Text
        Dim lvTextY As String = listviewY.SubItems(ColumnToSort).Text

        Dim caracter As Char
        Dim texto As String = ""
        'Si se trata de un formato de moneda, eliminamos los puntos y el signo €
        If Microsoft.VisualBasic.Right(lvTextX, 1) = "€" Or Microsoft.VisualBasic.Right(lvTextX, 1) = "%" Then
            For Each caracter In lvTextX
                If InStr("1234567890,", caracter) Then
                    texto = texto & caracter
                End If
            Next
            lvTextX = texto
        End If
        texto = ""
        If Microsoft.VisualBasic.Right(lvTextY, 1) = "€" Or Microsoft.VisualBasic.Right(lvTextY, 1) = "%" Then
            For Each caracter In lvTextY
                If InStr("1234567890,", caracter) Then
                    texto = texto & caracter
                End If
            Next
            lvTextY = texto
        End If

        ' Comparar los dos elementos. Según el tipo
        If DateTime.TryParse(lvTextX, lvDateX) And DateTime.TryParse(lvTextY, lvDateY) Then
            compareResult = ObjectCompare.Compare(lvDateX, lvDateY)
        Else
            If Integer.TryParse(lvTextX, lvIntX) And Integer.TryParse(lvTextY, lvIntY) Then
                compareResult = ObjectCompare.Compare(lvIntX, lvIntY)
            Else
                If Double.TryParse(lvTextX, lvDoubleX) And Double.TryParse(lvTextY, lvDoubleY) Then
                    compareResult = ObjectCompare.Compare(lvDoubleX, lvDoubleY)
                    'compareResult = If(lvDoubleX = lvDoubleY, 0, If(lvDoubleX > lvDoubleY, 1, -1))
                Else
                    compareResult = (ObjectCompare.Compare(lvTextX, lvTextY))
                End If
            End If
        End If
        ' Calcular el valor devuelto correcto según la comparación del objeto. 
        If (OrderOfSort = SortOrder.Ascending) Then ' Se selecciona el orden ascendente, y se devuelve el 'resultado típico de la operación de ' comparación. 
            Return compareResult

        ElseIf (OrderOfSort = SortOrder.Descending) Then ' Se selecciona el orden descendente, y se devuelve el resultado negativo de ' la operación de comparación. 
            Return (-compareResult)
        Else ' Return '0' para indicar que son iguales. 
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property

End Class




