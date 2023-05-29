Public Class frmSystemInfo
    Private Sub frmSystemInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = Application.StartupPath
        Label6.Text = Environ("windir")
        Label7.Text = My.Computer.Info.OSFullName
        Label8.Text = My.User.Name
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class