Imports System.Data
Imports System.Data.OleDb
Public Class Form3
    Private lvwColumnSorter As listviewcolumnsorter
    Dim DataBaseFileName As String = Application.StartupPath & "\db.mdb"
    Dim Connector As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DataBaseFileName)
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lvwColumnSorter = New listviewcolumnsorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID")
        ListView1.Columns.Add("Фамилия")
        ListView1.Columns.Add("Имя")
        ListView1.Columns.Add("Отчество")
        ListView1.Items.Clear()
        Try
            Dim DataReader As OleDbDataReader
            Dim Command As New OleDbCommand("Select * From Получатели", Connector)
            Connector.Open()
            DataReader = Command.ExecuteReader
            While DataReader.Read() = True
                ListView1.Items.Add(DataReader.GetValue(0), 0)
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
            End While
            DataReader.Close()
            Connector.Close()
        Catch ex As Exception
            Connector.Close()
            MessageBox.Show(ex.Message)
        End Try
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        For Each columnheader In Me.ListView1.Columns
            columnheader.width = -3
        Next
    End Sub
    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = lvwColumnSorter.sortcolumn) Then
            If (lvwColumnSorter.order = SortOrder.Ascending) Then
                lvwColumnSorter.order = SortOrder.Descending
            Else
                lvwColumnSorter.order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.sortcolumn = e.Column
            lvwColumnSorter.order = SortOrder.Ascending
        End If
        Me.ListView1.Sort()
    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Dim ItemIndex As Integer
        If e.Button = MouseButtons.Right Then
            ItemIndex = ListView1.SelectedIndices.Count
            If ItemIndex = 1 Then
                ContextMenuStrip2.Show(Me.Location.X + e.X, Me.Location.Y + e.Y + ContextMenuStrip2.Height)
            Else
                ContextMenuStrip1.Show(Me.Location.X + e.X, Me.Location.Y + e.Y + ContextMenuStrip1.Height)
            End If
        End If
    End Sub
    Sub Dobavlenie_zap()
        lvwColumnSorter = New listviewcolumnsorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        Try
            Dim Command As New OleDbCommand("Insert Into Получатели ([Фамилия], [Имя], [Отчество]) values ('" & Фамилия & "', '" & Имя & "' , '" & Отчество & "')", Connector)
            Connector. Open()
Command. ExecuteNonQuery()
Connector. Close()
Catch ex As Exception
MessageBox. Show(ex. Message)
End Try
ListView1. Items. Add("Фамилия")
ListView1. Items. Item(ListView1. Items. Count - 1). SubItems. Add("Имя")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Отчество")
        Form3_Load(Me, New EventArgs)
        For Each columnheader In Me.ListView1.Columns
            columnheader.Width = -3
        Next
    End Sub
    Sub Editor_zap()
        Try
            Dim Command As New OleDbCommand("UPDATE Получатели SET [Фамилия]='" & Фамилия & "', [Имя] = '" & Имя & "', [Отчество] = '" & Отчество & "' WHERE ([ID] Like'" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ListView1.SelectedItems.Item(0).Text = Фамилия
        ListView1.SelectedItems.Item(0).SubItems.Item(1).Text = Имя
        ListView1.SelectedItems.Item(0).SubItems. Item(2). Text = Отчество
        Form3_Load(Me, New EventArgs)
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        Form3_Load(Me, New EventArgs)
    End Sub

    Private Sub ДобавитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьToolStripMenuItem.Click
        Form4.Text = "Добавление записи"
        Form4.Show()
    End Sub

    Private Sub ЖурналToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЖурналToolStripMenuItem.Click
        ФИО = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text & " " & ListView1.SelectedItems.Item(0).SubItems.Item(2).Text & " " & ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        Form5.Text = "Отчет по: " & ФИО
        Form5.Show()
    End Sub

    Private Sub ТекущееСостояниеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ТекущееСостояниеToolStripMenuItem.Click
        ФИО = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text & " " & ListView1.SelectedItems.Item(0).SubItems.Item(2).Text & " " & ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        Form6.Text = "Отчет текущий по " & ФИО
        Form6.Show()
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.Text = "Получатели" Then
            Try
                id = ListView1.SelectedItems.Item(0).Text
                Фамилия = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                Имя = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                Отчество = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                Form4.Text = "Редактирование записи"
                Form4.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Получатель = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text & " " &
            ListView1.SelectedItems.Item(0).SubItems.Item(2).Text & " " &
            ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            Form1.выдать()
            Close()
        End If
    End Sub

    Private Sub УдалитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьToolStripMenuItem.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы действительно хотите без возвратно удалить получателя из базы данных?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If MBox = DialogResult.No Then Exit Sub
        If MBox = DialogResult.Yes Then
                Try
                Dim Command As New OleDbCommand("DELETE FROM Получатели WHERE ID =" & ListView1.SelectedItems.Item(0).Text & "", Connector)
                Connector.Open()
                    Command.ExecuteNonQuery()
                    Connector.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ListView1.SelectedItems.Item(0).Remove()
            Form3_Load(Me, New EventArgs)
            End If
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Close()
    End Sub
End Class