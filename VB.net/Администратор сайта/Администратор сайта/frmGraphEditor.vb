Imports System.Drawing.Drawing2D
Public Class frmGraphEditor
    Dim pencolor As Color = Color.Red
    Dim brushcolor As Color = Color.Red
    Dim freedom As Boolean = False
    Dim ris As Boolean = False
    Dim index1 As Integer
    Dim graph As Graphics
    Dim flag As Bitmap
    Private Sub frmGraphEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flag = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        MdiParent = Form1
        Me.DoubleBuffered = True
        ToolStripButton8.BackColor = pencolor
        ToolStripButton8.Visible = False
    End Sub
    Sub DrawLineExample(ByVal index As Integer)
        index1 = index
        ToolStripButton8.Visible = False
        graph = Graphics.FromImage(flag)
        Dim penl As New Pen(brushcolor, 5)
        Dim brushl As New SolidBrush(brushcolor)
        graph.Clear(Color.FromArgb(255, 255, 255))
        Select Case index
            Case 0
                graph.DrawLine(penl, 50, 50, 500, 500)
            Case 1
                graph.PageUnit = GraphicsUnit.Millimeter
                graph.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                graph.DrawLine(penl, 20, 20, 90, 20)
                graph.DrawArc(penl, 80, 20, 20, 20, 270, 90)
                graph.DrawLine(penl, 100, 30, 100, 40)
                graph.DrawArc(penl, 80, 30, 20, 20, 0, 90)
                graph.DrawLine(penl, 20, 50, 90, 50)
                graph.DrawArc(penl, 10, 30, 20, 20, 90, 90)
                graph.DrawLine(penl, 10, 30, 10, 40)
                graph.DrawArc(penl, 10, 20, 20, 20, 180, 90)
            Case 2
                graph.FillEllipse(brushl, 50, 50, 150, 150)
            Case 3
                Dim points(21) As Point
                For i As Integer = 0 To 20 Step 2
                    points(i) = New Point(20 + 10 * i, 25 + 5 * i)
                    points(i + 1) = New Point(40 + 10 * i, 20 - 5 * i)
                Next
                graph.DrawLines(penl, points)
            Case 4
                penl.EndCap() = LineCap.RoundAnchor
                penl.StartCap() = LineCap.RoundAnchor
                graph.DrawLine(penl, 50, 50, 200, 50)
                graph.FillEllipse(brushl, 50, 50, 150, 150)
            Case 5
                Dim linGrBrush As LinearGradientBrush = New LinearGradientBrush(
                New Point(30, 150),
                New Point(150, 30),
                brushcolor,
                Color.FromArgb(0, 0, 0, 0))
                linGrBrush.WrapMode = WrapMode.TileFlipX
                graph.FillEllipse(linGrBrush, 50, 50, 150, 150)
            Case 6
                graph.FillPie(brushl, 20, 50, 150, 150, 0, 45)
        End Select
        PictureBox1.Image = flag
        freedom = False
    End Sub
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)
        DrawLineExample(0)
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        DrawLineExample(1)
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        DrawLineExample(2)
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        DrawLineExample(3)
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        DrawLineExample(4)
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        DrawLineExample(5)
    End Sub
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        EnablePen()
    End Sub
    Sub EnablePen()
        freedom = True
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            If ColorDialog1.Color <> Nothing Then
                pencolor = ColorDialog1.Color
                ToolStripButton8.Visible = True
                ToolStripButton8.BackColor = pencolor
            End If
        Else
            pencolor = Color.Red
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        ris = True
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If ris = True And freedom = True Then
            graph = Graphics.FromImage(flag)
            graph.FillRectangle(New SolidBrush(pencolor), e.X, e.Y, NumericUpDown1.Value, NumericUpDown1.Value)
            PictureBox1.Image = flag
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        ris = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        flag = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = flag
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            If ColorDialog1.Color <> Nothing Then
                brushcolor = ColorDialog1.Color
                PictureBox1.Refresh()
                DrawLineExample(index1)
            End If
        Else
            brushcolor = Color.Red
        End If
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value > 1 Then
            Exit Sub
        Else
            NumericUpDown1.Value = 1
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With SaveFileDialog1
            .Title = "Сохранить картинку как..."
            .OverwritePrompt = True
            .CheckPathExists = True
            .Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*"
            .ShowHelp = True
        End With
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SaveFileDialog1.FileName)
            Catch ex As Exception
                MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        EnablePen()
    End Sub
End Class