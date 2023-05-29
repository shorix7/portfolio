Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Public Class frmImageManager
    Public info
    Public img
    Public OpenFile(10) As String
    Private Sub frmImageManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        ComboBox1.Enabled = False
        GroupBox2.Enabled = False
        NumericUpDown1.Enabled = False
        CheckBox1.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        DoubleBuffered = True
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim open As New OpenFileDialog
        open.Filter = "Image Files(*.JPEG;*.JPG;*.ING)|*.JPEG;*.JPG;*.PNG|AlL files (*.*)|*.*"
        If open.ShowDialog() = DialogResult.Cancel Then Exit Sub
        info = open.FileName
        Obzor(info)
    End Sub
    Private Sub Obzor(ByVal info As String)
        If info.Equals("") Then
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            PictureBox1.Image = Nothing
            Exit Sub
        End If
        TextBox2.Text = FileIO.FileSystem.GetName(info)
        TextBox3.Text = info
        img = Image.FromFile(info)
        PictureBox1.Image = img
        CheckBox1.Enabled = True
        CheckBox1.Checked = True
        Button1.Enabled = True
        Button2.Enabled = true
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox1.Visible = True
            Label10.Text = img.Height & " x " & img.width
        Else
            PictureBox1.Visible = False
            Label10.Text = ""
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        ComboBox1.Enabled = True
        GroupBox2.Enabled = True
        NumericUpDown1.Enabled = False
        CheckBox1.Enabled = True
        TextBox2.Text = FileIO.FileSystem.GetName(info)
        TextBox3.Text = info
        TextBox4.Text = img.Width
        img = Image.FromFile(info)
        TextBox5.Text = img.Height
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FileIO.FileSystem.GetName(info) = "" Then
        Else
            TreeView1.Nodes.Add(FileIO.FileSystem.GetName(info))
            OpenFile(TreeView1.GetNodeCount(0)) = info
        End If
    End Sub
    Private Sub DataClear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MessageBox.Show("Вы действительно хотите очистить список изображений?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If TreeView1.Nodes.Count = 0 Then
                Else
                    TreeView1.Nodes.Clear()
                    Erase OpenFile
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Выберите запись для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private sub Button6_click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Label10.Text = ""
        PictureBox1.Image = Nothing
        CheckBox1.Visible = False
   End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox2.Text <> "" Then
            frmContentEditor.Show()
            frmContentEditor.RichTextBox1.SelectedText = "<img src=" & TextBox3.Text & ">"
        Else
            MessageBox.Show("Не удалось сохранить изображение. Откройте файл, который нужно сохранить.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Public ScrollHeight As Integer
    Public ScrollWidth As Integer
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim value = TrackBar1.Value \ 1
        Dim wNew = CInt(ScrollWidth * value)
        Dim hNew = CInt(ScrollHeight * value)
        Dim yLoc = PictureBox1.Location.Y + (PictureBox1.Height - hNew) / 2
        Dim xloc = PictureBox1.Location.X + (PictureBox1.Width - wNew) / 2
        PictureBox1.Location = New Point(xloc, yLoc)
        PictureBox1.Width = wNew
        PictureBox1.Height = hNew
        ScrollHeight = img.Height \ 9
        ScrollWidth = img.Width \ 9
        Label11.Text = "Масштаб " & TrackBar1.Value & "0% "
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmFileInfo.Show()
    End Sub
    Private Sub ImageWidth_TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged, TextBox4.TextChanged
        If Not IsNumeric(TextBox5.Text) Then
            ErrorProvider1.SetError(TextBox5, "Необходимо ввести числовое значение")
            Button5.Enabled = False
        Else
            ErrorProvider1.SetError(TextBox5, "")
        End If
        If Not IsNumeric(TextBox4.Text) Then
            ErrorProvider1.SetError(TextBox4, "Необходимо ввести числовое значение")
            Button5.Enabled = False
        Else
            ErrorProvider1.SetError(TextBox3, "")
        End If
        If IsNumeric(TextBox5.Text) And IsNumeric(TextBox4.Text) Then
            Button5.Enabled = True
        End If
    End Sub
End Class