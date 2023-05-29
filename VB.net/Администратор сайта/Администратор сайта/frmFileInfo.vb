Public Class frmFileInfo
    Public info
    Private Sub FileInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        Dim FileInfo As New IO.FileInfo(frmImageManager.info)
        Label4.Text = FileIO.FileSystem.GetName(frmImageManager.info)
        Label5.Text = FileLen(frmImageManager.info) & " Байт"
        Label6.Text = FileDateTime(frmImageManager.info)
        Select Case IO.File.GetAttributes(frmImageManager.info)
            Case IO.FileAttributes.Normal
                CheckBox1.Checked = True
            Case IO.FileAttributes.Archive
                CheckBox2.Checked = True
            Case IO.FileAttributes.System
                CheckBox3.Checked = True
            Case IO.FileAttributes.Hidden
                CheckBox4.Checked = True
            Case IO.FileAttributes.Temporary
                CheckBox5.Checked = True
            Case IO.FileAttributes.Compressed
                CheckBox6.Checked = True
            Case IO.FileAttributes.Encrypted
                CheckBox7.Checked = True
            Case IO.FileAttributes.NotContentIndexed
                CheckBox8.Checked = True
            Case IO.FileAttributes.ReadOnly
                CheckBox9.Checked = True
        End Select
        Button1.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Normal)
        End If
        If CheckBox2.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Archive)
        End If
        If CheckBox3.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.System)
        End If
        If CheckBox4.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Hidden)
        End If
        If CheckBox5.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Temporary)
        End If
        If CheckBox6.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Compressed)
        End If
        If CheckBox7.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.Encrypted)
        End If
        If CheckBox8.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.NotContentIndexed)
        End If
        If CheckBox9.Checked Then
            IO.File.SetAttributes(frmImageManager.info, IO.FileAttributes.ReadOnly)
        End If
    End Sub
    Private Sub cbNormal_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged, CheckBox6.CheckedChanged, CheckBox7.CheckedChanged, CheckBox8.CheckedChanged, CheckBox9.CheckedChanged
        Button1.Enabled = True
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class