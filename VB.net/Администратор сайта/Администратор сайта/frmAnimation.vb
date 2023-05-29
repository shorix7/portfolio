Public Class frmAnimation
    Private info As String
    Dim img As Image
    Sub Ochistka()
        PictureBox1.Image = Nothing
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Ochistka()
        Dim open As New OpenFileDialog
        open.Filter = "Gif(* .gif;*.flc;*.swf)|*.gif;*.flc;*.swf|All files (*.*)|*.*"
        If open.ShowDialog() = DialogResult.Cancel Then Exit Sub
        info = open.FileName
        img = Image.FromFile(info)
        PictureBox1.Image = img
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        TextBox1.Text = FileIO.FileSystem.GetName(info)
        Button2.Visible = True
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If Button2.Text = "Остановить" Then
            PictureBox1.Image = Nothing
            Button2.Text = "Просмотр"
        Else
            PictureBox1.Image = img
            Button2.Text = "Остановить"
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class
