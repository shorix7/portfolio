Imports System.Collections
Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer
    Private ColumnToSort As Integer
    Private OrderofSort As Integer
    Private ObjectCompare As CaseInsensitiveComparer
    Public Sub New()
        ColumnToSort = 0
        OrderofSort = SortOrder.None
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)
        compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
        If (OrderofSort = SortOrder.Ascending) Then
            Return compareResult
        ElseIf (OrderofSort = SortOrder.Descending) Then
            Return (-compareResult)
        Else
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
            OrderofSort = Value
        End Set
        Get
            Return OrderofSort
        End Get
    End Property
End Class
