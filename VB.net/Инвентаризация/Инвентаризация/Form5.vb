Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class Form5
    Private lvwColumnSorter As listviewcolumnsorter
    Dim myXL As Excel.Application, myWB As Excel.Workbook, myWS As Excel.Worksheet
    Dim DataBaseFileName As String = Application.StartupPath & "\db.mdb"
    Dim Connector As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DataBaseFileName)

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        Form5_Load(Me, New EventArgs)
    End Sub

    Private Sub ЭкспортWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортWordToolStripMenuItem.Click
        Dim Дата As String = Format(Now, "d MMMM уууу")
        Dim W = New Word.Application
        W.Visible = True
        W.Documents.Add()
        W.Selection.TypeText("Архив выдачи техники на: " & Дата & Chr(13) & Chr(10))
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
            For Y = 1 To 3
                myWS.Cells(1, Y) = ListView1.Columns(Y).Text
                myWS.Cells(z, 1) = ListView1.Items.Item(i - 1).SubItems.Item(1).Text
                myWS.Cells(z, 2) = ListView1.Items.Item(i - 1).SubItems.Item(2).Text
                myWS.Cells(z, 3) = ListView1.Items.Item(i - 1).SubItems.Item(3).Text
            Next Y
            z = z + 1
        Next i
        myWS.Columns(1).ColumnWidth = 50
        myWS.Columns(2).ColumnWidth = 100
        myWS.Columns(3).ColumnWidth = 50
        myXL = Nothing
        myWB = Nothing
        myWS = Nothing
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
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("Select * From Журнал", Connector)
        Dim Command1 As New OleDbCommand("Select * From Журнал WHERE [ФИО] = '" & ФИО & "'", Connector)
        Dim Command2 As New OleDbCommand("Select * From Журнал WHERE [История] = '" & Комп & "'", Connector)
        lvwColumnSorter = New listviewcolumnsorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID")
        ListView1. Columns. Add("ФИО")
        ListView1.Columns.Add("История")
        ListView1. Columns. Add("Дата и время")
        ListView1.Items.Clear()
        If Me.Text = "Архив выдач..." Then
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
        If Me.Text = "Отчет по: " & ФИО Then
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
        If Me.Text = "Отчет по: " & Комп Then
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
End Class