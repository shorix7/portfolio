Imports System.Diagnostics.Tracing
Imports System.Reflection
Public Class frmContentEditor
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.SelectedText = "<b>" + RichTextBox1.SelectedText + "</b>"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.SelectedText = "<i>" + RichTextBox1.SelectedText + "</i>"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.SelectedText = "<u>" + RichTextBox1.SelectedText + "\</u>"
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RichTextBox1.SelectedText = "<sup>" + RichTextBox1.SelectedText + "</sup>"
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RichTextBox1.SelectedText = "<sub>" + RichTextBox1.SelectedText + "</sub>"
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.AppendText("<a href=""" + InputBox("Введите ссылку").ToString + """>" + InputBox("Введите текст") + "</а>")
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.SelectedText = "<p>" + RichTextBox1.SelectedText + "</p>"
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RichTextBox1.SelectedText = "«span»" + RichTextBox1.SelectedText + "</span>"
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RichTextBox1.SelectedText = "<div>" + RichTextBox1.SelectedText + "</div>"
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        RichTextBox1.SelectedText = "<ul>" + vbCrLf + RichTextBox1.SelectedText + vbCrLf + "</ul>"
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        RichTextBox1.SelectedText = "<ol>" + vbCrLf + RichTextBox1.SelectedText + vbCrLf + "</ol>"
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        RichTextBox1.AppendText("<img src=""" + InputBox("Введите url изображения").ToString + """/>")
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim save As New SaveFileDialog
        save.Title = "Сохранить"
        save.Filter = "файл HTML .html|*.html"
        If save.ShowDialog = DialogResult.Cancel Then Exit Sub
        Dim write As String
        write = RichTextBox1.Text
        FileOpen(1, save.FileName, OpenMode.Output)
        Print(1, write, "")
        FileClose(1)
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        RichTextBox1.Clear()
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim open As New OpenFileDialog
        open.Title = "Открыть"
        open.Filter = "Файл HTML (*.html)|*.html"
        If open.ShowDialog = DialogResult.Cancel Then Exit Sub
        Dim write As String
        write = RichTextBox1.Text
        FileOpen(1, open.FileName, OpenMode.Output)
        Print(1, write, "")
        FileClose(1)
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Not RichTextBox1.SelectedText.Equals("") Then
            Clipboard.SetText(RichTextBox1.SelectedText)
        Else
            Clipboard.SetText(RichTextBox1.Text)
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If Not RichTextBox1.SelectedText.Equals("") Then
            Clipboard.SetText(RichTextBox1.SelectedText)
            RichTextBox1.SelectedText = ""
        Else
            Clipboard.SetText(RichTextBox1.Text)
            RichTextBox1.Text = ""
        End If
    End Sub
End Class