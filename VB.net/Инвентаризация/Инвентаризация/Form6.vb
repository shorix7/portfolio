Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class Form6
    Private lvwColumnSorter As listviewcolumnsorter
    Dim DataBaseFileName As String = Application.StartupPath & "\db.mdb"
    Dim Connector As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" &
DataBaseFileName)
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("Select * From [Журнал выдач]", Connector)
        Dim Command1 As New OleDbCommand("Select * From [Журнал выдач] WHERE (([Журнал выдач].ФИО) = '" & ФИО & "')", Connector)
        Dim Command2 As New OleDbCommand("Select * From [Журнал выдач] WHERE [Журнал выдач].[История] = '" & Комп & "'", Connector)
        lvwColumnSorter = New listviewcolumnsorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID")
        ListView1.Columns.Add("ФИО")
        ListView1.Columns.Add("История")
        ListView1.Columns.Add("IDGurnal")
        ListView1.Items.Clear()
        If Me.Text = "Текущий отчет..." Then
            Try
                Connector.Open()
                DataReader = Command.ExecuteReader
                While DataReader.Read() = True
                    ListView1.Items.Add(DataReader.GetValue(0))
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
        End If
        If Me.Text = "Отчет текущий по " & ФИО Then
            Try
                Connector.Open()
                DataReader = Command1.ExecuteReader
                While DataReader.Read() = True
                    ListView1.Items.Add(DataReader.GetValue(0))
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
        End If
        If Me.Text = "Отчет текущий по: " & Комп Then
                Try
                    Connector.Open()
                    DataReader = Command2.ExecuteReader
                    While DataReader.Read() = True
                        ListView1.Items.Add(DataReader.GetValue(0))
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
            End If
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
                For Each columnheader In Me.ListView1.Columns
                    columnheader.Width = -3
                Next
    End Sub

    Private Sub ЭкспортWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортWordToolStripMenuItem.Click
        Dim Дата As String = Format(Now, "d MMMM уууу")
        Dim W = New Word.Application
        W.Visible = True
        W.Documents.Add()
        W.Selection.TypeText("Текущий отчет на: " & Дата & Chr(13) & Chr(10))
        For i As Short = 0 To ListView1.Items.Count - 1
            W.Selection.TypeText(ListView1.Items(i).SubItems.Item(0).Text & " " & ListView1.Items(i).SubItems.Item(1).Text & " " & ListView1.Items(i).SubItems.Item(2).Text & Chr(13) & Chr(10) & " " & ListView1.Items(i).SubItems.Item(3).Text & Chr(13) & Chr(10))
        Next i
    End Sub

    Private Sub ЭкспортExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортExcelToolStripMenuItem.Click
        Dim myXL As Excel.Application, myWB As Excel.Workbook, myWS As Excel.Worksheet
        Dim i As Integer
        Dim Y As Integer
        Dim z As Integer
        myXL = New Excel.Application
        myWB = myXL.Workbooks.Add
        myWS = myWB.Worksheets(1)
        z = 2
        myXL.Visible = True
        For i = 1 To Me.ListView1.Items.Count
            For Y = 1 To 2
                myWS.Cells(1, Y) = ListView1.Columns(Y).Text
            Next y
            myWS.Cells(z, 1) = ListView1.Items.Item(i - 1).SubItems.Item(1).Text
            myWS.Cells(z, 2) = ListView1.Items.Item(i - 1).SubItems.Item(2).Text
        Next i
        z = z + 1
        myWS.Columns(1).ColumnWidth = 50
        myWS.Columns(2).ColumnWidth = 100
        myXL = Nothing
        myWB = Nothing
        myWS = Nothing
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        Form6_Load(Me, New EventArgs)
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim MBox As DialogResult = MessageBox.Show("Выполнить возврат", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim Command As New OleDbCommand("DELETE FROM [Журнал выдач] WHERE ID =" & ListView1.SelectedItems.Item(0).Text & "", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                Dim Command1 As New OleDbCommand("UPDATE Техника SET [Наличие]='Да' WHERE ([ID] Like '" & ListView1.SelectedItems.Item(0).SubItems.Item(3).Text & "')", Connector)
                Connector.Open()
                Command1.ExecuteNonQuery()
                Connector.Close()
                ListView1.SelectedItems.Item(0).Remove()
                Form6_Load(Me, New EventArgs)
                Form1.Timer1.Enabled = True
                MessageBox.Show("Успешно выполнен возврат", "Операция успешна завершина",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        ToolStripMenuItem2_Click(Me, New EventArgs)
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

    Private Sub ВНаличииToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВНаличииToolStripMenuItem.Click
        Try
            Dim MBox As DialogResult = MessageBox.Show("Выполнить возврат", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim Command As New OleDbCommand("DELETE FROM [Журнал выдач] WHERE ID =" & ListView1.SelectedItems.Item(0).Text & "", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                Dim Command1 As New OleDbCommand("UPDATE Техника SET [Наличие]='Да' WHERE ([ID] Like '" & ListView1.SelectedItems.Item(0).SubItems.Item(3).Text & "')", Connector)
                Connector.Open()
                Command1.ExecuteNonQuery()
                Connector.Close()
                ListView1.SelectedItems.Item(0).Remove()
                Form6_Load(Me, New EventArgs)
                Form1.Timer1.Enabled = True
                MessageBox.Show("Успешно выполнен возврат", "Операция успешна завершина",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class