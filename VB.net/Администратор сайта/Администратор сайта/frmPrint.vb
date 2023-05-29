Imports System.Drawing.Printing
Imports System.IO
Public Class frmPrint
    Private filetoprint As StreamReader
    Private printfont As New Font("Courier New", 10)
    Dim pathtofile As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bOpenFile.Click
        With OpenFileDialog1
            .Title = "Выберите документ"
            .Filter = "Документы| *.txt;*.rtf;*.log;*.csv |Все файлы| *.*"
            .FileName = ""
            .InitialDirectory = "C:\"
            .Multiselect = False
        End With
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            If OpenFileDialog1.FileName <> Nothing Then
                pathtofile = OpenFileDialog1.FileName
                TextBox1.Text = pathtofile
                PrintDocument1.DocumentName = TextBox1.Text
            End If
        End If
    End Sub
    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = Form1
    End Sub
    Private Sub bPreview_Click(sender As Object, e As EventArgs) Handles bPreview.Click
        Try
            filetoprint = New StreamReader(TextBox1.Text)
            PrintPreviewDialog1.ShowDialog()
            filetoprint.Close()
        Catch ex As Exception
            MessageBox.Show("Не указано имя файла")
        End Try
    End Sub
    Private Sub bPrint_Click(sender As Object, e As EventArgs) Handles bPrint.Click
        If Not (TextBox1.Text Is Nothing) Then
            If (PrintDialog1.ShowDialog() = DialogResult.OK) Then
                Printing()
            End If
        Else
            MessageBox.Show("Не указано имя файла")
        End If
    End Sub
    Private Sub Printing()
        If Not (TextBox1.Text Is Nothing) Then
            filetoprint = New StreamReader(TextBox1.Text)
            Try
                PrintDocument1.DefaultPageSettings.Margins = New Margins(150, 150, 150, 150)
                PrintDocument1.DefaultPageSettings.Landscape = False
                PrintDocument1.PrinterSettings.Copies = 2
                If (PrintDocument1.PrinterSettings.CanDuplex) Then
                    PrintDocument1.PrinterSettings.Duplex() = Duplex.Horizontal
                End If
                PrintDocument1.Print()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Не указано имя файла")
        End If
        filetoprint.Close()
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim y As Single = e.MarginBounds.Top
        Dim line As String = Nothing
        While y < e.MarginBounds.Bottom
            line = filetoprint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            y += printfont.Height
            e.Graphics.DrawString(line, printfont, Brushes.Black, e.MarginBounds.Left, y)
        End While
        If Not (line Is Nothing) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub
    Private Sub bExit_Click(sender As Object, e As EventArgs) Handles bExit.Click
        Me.Close()
    End Sub
End Class

