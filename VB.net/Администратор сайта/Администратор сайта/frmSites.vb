Imports System.ComponentModel
Public Class frmSites
    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    'End Sub
    Public mode
    Dim objSites As New Site()
    Private Sub frmSite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        FillDataFromDataBase()
    End Sub
    Sub FillDataFromDataBase()
        With DataGridView1
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .Columns.Clear()
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Add("1", "ID")
            .Columns.Add("2", "Title")
            .Columns.Add("3", "Link")
            'DataGridView1.Sort(DataGridView1.Columns("ID"), ListSortDirection.Ascending)
        End With
        Try
            objSites.NewSite(objSites)
            Label1.Text = "Количество сайтов: " & DataGridView1.Rows.Count - 1
        Catch ex As Exception
            Console.WriteLine(ex.Message & " " & Now.ToLongTimeString)
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        mode = "Site"
        frmNewItem.Show()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            With objSites
                .id = DataGridView1.SelectedCells(0).Value
            End With
            'objSites.Delete(objSites)
        Catch ex As Exception
            Console.WriteLine(ex.Message & " " & Now.ToLongTimeString)
        End Try
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.SelectedRows.Count <> Nothing Then
            mode = "Site"
            frmEdit.Show()
        End If
    End Sub
    Sub Reboot()
        frmSite_Load(Me, New EventArgs)
    End Sub
End Class
