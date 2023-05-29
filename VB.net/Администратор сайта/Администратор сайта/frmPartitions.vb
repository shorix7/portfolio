Imports System.Data.OleDb
Imports System.Reflection.Emit


Public Class frmPartitions
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    End Sub
    'Private Sub frmPartitions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    MdiParent = Form1
    '    FillDataFromDataBase()
    'End Sub
    'Sub FillDataFromDataBase()
    '    TreeView1.Nodes.Clear()
    '    PartitionsCount = 0
    '    Try
    '        Dim i As Integer = 0
    '        Dim DataReader1 As OleDbDataReader
    '        Dim Command1 As New OleDbCommand("SELECT * FROM Sites", ConnectToDataBase)
    '        ConnectToDataBase.Open()
    '        DataReader1 = Command1.ExecuteReader
    '        While DataReader1.Read() = True
    '            TreeView1.Nodes.Add(DataReader1.GetValue(1))
    '            TreeView1.Nodes(i).Tag = DataReader1.GetValue(0)
    '            Console.WriteLine("Index of Partitions: " & TreeView1.Nodes(i).Tag)
    '            i = i + 1
    '        End While
    '        i = 0
    '        DataReader1.Close()
    '        ConnectToDataBase.Close()
    '    Catch ex As Exception
    '        ConnectToDataBase.Close()
    '        Console.WriteLine(vbCrLf & ex.Message & " " & Now.ToLongTimeString & vbCrLf)
    '    End Try
    '    Try
    '        Dim i As Integer = 0
    '        Dim DataReader2 As OleDbDataReader
    '        Dim Command2 As New OleDbCommand("SELECT * FROM Partitions", ConnectToDataBase)
    '        ConnectToDataBase.Open()
    '        DataReader2 = Command2.ExecuteReader
    '        While DataReader2.Read() = True
    '            For i = 0 To TreeView1.Nodes.Count - 1
    '                If DataReader2.GetValue(2) = TreeView1.Nodes(i).Tag Then
    '                    TreeView1.Nodes(i).Nodes.Add(DataReader2.GetValue(1))
    '                    PartitionsCount = PartitionsCount + 1
    '                End If
    '            Next
    '        End While
    '        Label1.Text = "Количество сайтов: " & TreeView1.Nodes.Count
    '        Label2.Text = "Количество разделов: " & PartitionsCount
    '        DataReader2.Close()
    '        ConnectToDataBase.Close()
    '    Catch ex As Exception
    '        ConnectToDataBase.Close()
    '        Console.WriteLine(vbCrLf & ex.Message & " " & Now.ToLongTimeString & vbCrLf)
    '    End Try
    'End Sub
    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    '    Try
    '        If TreeView1.SelectedNode.Tag <> Nothing Then
    '            mode = "Partitions"
    '            frmNewItem.Show()
    '            Console.WriteLine(vbCrLf & "Partitions count: " & PartitionsCount & vbCrLf)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
    '    If TreeView1.SelectedNode.Tag = Nothing Then
    '        Try
    '            With objPartitions
    '                .Title = TreeView1.SelectedNode.Text
    '                .IdSite = TreeView1.SelectedNode.Parent.Tag
    '            End With
    '            TreeView1.SelectedNode.Remove()
    '            objPartitions.DeleteNote(objPartitions)
    '            Console.WriteLine(vbCrLf & "Delete field values (partitions editing) | ID: " & objPartitions.id & " | Title: " & objPartitions.Title & " | ID_Site: " & objPartitions.IdSite & vbCrLf)
    '        Catch ex As Exception
    '            Console.WriteLine(ex.Message & " " & Now.ToLongTimeString)
    '        End Try
    '    End If
    'End Sub
    'Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    '    If TreeView1.SelectedNode.Tag = Nothing Then
    '        mode = "Partitions"
    '        frmEdit.Show()
    '    End If
    'End Sub
    'Sub Reboot()
    '    frmPartitions_Load(Me, New EventArgs)
    'End Sub
End Class

