Imports System.IO
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    Public SiteID As Integer = 2
    Public int As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        With frmContentEditor
            .MdiParent = Me
        End With
        With frmImageManager
            .MdiParent = Me
        End With
        With frmOptions
            .MdiParent = Me
        End With
        With frmFileInfo
            .MdiParent = Me
        End With
        With frmNewItem
            .MdiParent = Me
        End With
        With frmSystemInfo
            .MdiParent = Me
        End With
        With frmAnimation
            .MdiParent = Me
        End With
        With frmGraphEditor
            .MdiParent = Me
        End With
        With frmAudioVideo
            .MdiParent = Me
        End With
        With frmSites
            .MdiParent = Me
        End With
        With frmPartitions
            .MdiParent = Me
        End With
        With frmPrint
            .MdiParent = Me
        End With
        With frmAbout
            .MdiParent = Me
        End With
        With frmReportViewer
            .MdiParent = Me
        End With
        ToolStripProgressBar1.Value = 100
        ToolStripStatusLabel2.Text = Now.ToLongDateString
        ToolStripStatusLabel4.Text = Now.ToLongTimeString
    End Sub
    Private Sub РедакторКонтентаСайтаToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmContentEditor.Show()
        Zagryzka()
    End Sub
    Private Sub МенеджерИзображенийToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        frmImageManager.Show()
        Zagryzka()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Increment(20)
        ToolStripStatusLabel1.Text = "Открытие..."
        If ToolStripProgressBar1.Value = 100 Then
            Timer1.Stop()
            ToolStripStatusLabel1.Text = "Готово"
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ToolStripStatusLabel2.Text = Now.ToLongDateString
        ToolStripStatusLabel4.Text = Now.ToLongTimeString
    End Sub
    Public Sub Zagryzka()
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = ""
        Timer1.Start()
    End Sub
    Private Sub ОткрытьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОткрытьToolStripMenuItem.Click, ToolStripButton1.Click
        With New OpenFileDialog
            .Title = "Выберите файл"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
        End With
        Zagryzka()
    End Sub
    Private Sub СохранитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СохранитьToolStripMenuItem.Click, ToolStripButton2.Click
        With New SaveFileDialog
            .Title = "Сохранить"
            .FileName = ""
            .ShowDialog()
        End With
        Zagryzka()
    End Sub
    Private Sub ШрифтToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ШрифтToolStripMenuItem.Click
        With FontDialog1
            .ShowColor = True
        End With
        If FontDialog1.ShowDialog = DialogResult.OK Then
            Me.Font = FontDialog1.Font
            MenuStrip1.Font = FontDialog1.Font
            MenuStrip1.ForeColor = FontDialog1.Color
        End If
        Zagryzka()
    End Sub
    Private Sub ЦветоваяПалитраToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЦветоваяПалитраToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
        End If
        Zagryzka()
    End Sub
    Private Sub РедакторHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles РедакторHTMLToolStripMenuItem.Click
        Zagryzka()
        frmContentEditor.Show()
    End Sub
    Private Sub МенеджерИзображенийToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles МенеджерИзображенийToolStripMenuItem.Click
        Zagryzka()
        frmImageManager.Show()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
    End Sub
    Private Sub ПараметрыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПараметрыToolStripMenuItem.Click
        frmOptions.Show()
        Zagryzka()
    End Sub
    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        With frmContentEditor
            If Not .RichTextBox1.SelectedText.Equals("") Then
                Clipboard.SetText(.RichTextBox1.SelectedText)
            Else
                Clipboard.SetText(.RichTextBox1.Text)
            End If
        End With
    End Sub
    Private Sub ОбАвтореToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбАвтореToolStripMenuItem.Click
        Zagryzka()
        frmAbout.Show()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        With frmContentEditor
            If .RichTextBox1.SelectionLength > 0 Then
                .RichTextBox1.Copy()
            End If
        End With
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        With frmContentEditor
            Try
                .RichTextBox1.Paste()
            Catch ex As Exception
            End Try
        End With
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        With frmContentEditor
            If .RichTextBox1.SelectionLength > 0 Then
                .RichTextBox1.Cut()
            End If
        End With
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        With frmContentEditor
            If .RichTextBox1.SelectionLength > 0 Then
                .RichTextBox1.Copy()
            End If
        End With
    End Sub
    Private Sub ИнформацияОСистемеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ИнформацияОСистемеToolStripMenuItem.Click
        frmSystemInfo.Show()
        Zagryzka()
    End Sub
    Private Sub ПечатьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПечатьToolStripMenuItem.Click
        frmPrint.Show()
        Zagryzka()
    End Sub
    Private Sub АнимацияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АнимацияToolStripMenuItem.Click
        frmAnimation.Show()
        Zagryzka()
    End Sub
    Private Sub ГрафическийРедакторToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ГрафическийРедакторToolStripMenuItem.Click
        frmGraphEditor.Show()
        Zagryzka()
    End Sub
    Private Sub АудиоИВидеоToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АудиоИВидеоToolStripMenuItem.Click
        frmAudioVideo.Show()
        Zagryzka()
    End Sub
    Private Sub ОПрограммеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem.Click, СправкаToolStripMenuItem.Click
        Help.ShowHelp(Me, helpFileName)
    End Sub
    Private Sub ИнтеренетобозревательToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ИнтеренетобозревательToolStripMenuItem.Click
        frmBrowser.Show()
        Zagryzka()
    End Sub
    Private Sub ПерваяHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПерваяHTMLToolStripMenuItem.Click
        Zagryzka()
        frmBrowser.Show()
        frmBrowser.Navigate(Application.StartupPath & "\html\html_1\Zadanie_3.html")
    End Sub
    Private Sub ВтораяHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВтораяHTMLToolStripMenuItem.Click
        Zagryzka()
        frmBrowser.Show()
        frmBrowser.Navigate(Application.StartupPath & "\html\html_2\index.html")
    End Sub
    Private Sub ТретьяHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ТретьяHTMLToolStripMenuItem.Click
        Zagryzka()
        frmBrowser.Show()
        frmBrowser.Navigate(Application.StartupPath & "\html\html_3\sixth.html")
    End Sub
    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLToolStripMenuItem.Click
        Zagryzka()
        frmBrowser.Show()
        frmBrowser.Navigate(Application.StartupPath & "\html\XML.html")
    End Sub
    Private Sub СписокПроцессовToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СписокПроцессовToolStripMenuItem.Click
        SP.Main()

    End Sub
    Private Sub СистемнаяИнформацияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СистемнаяИнформацияToolStripMenuItem.Click
        CI.Main()
    End Sub

    Private Sub ДобавитьСайтToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьСайтToolStripMenuItem.Click

    End Sub

    Private Sub АдминистрированиеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АдминистрированиеToolStripMenuItem.Click

    End Sub

    Private Sub СобытияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СобытияToolStripMenuItem.Click

    End Sub

    'PRIVATE SUB ДОБАВИТЬСАЙТTOOLSTRIPMENUITEM_CLICK(SENDER AS OBJECT, E AS EVENTARGS)
    '    FRMNEWITEM.SHOW()
    'END SUB
    'PRIVATE SUB ДОБАВИТЬРАЗДЕЛTOOLSTRIPMENUITEM_CLICK(SENDER AS OBJECT, E AS EVENTARGS) HANDLES ДОБАВИТЬРАЗДЕЛTOOLSTRIPMENUITEM.CLICK
    '    MODE = "SECTION"
    '    FRMNEWITEM.SHOW()
    'END SUB
    'PRIVATE SUB ДОБАВИТЬСАЙТTOOLSTRIPMENUITEM1_CLICK(SENDER AS OBJECT, E AS EVENTARGS) HANDLES ДОБАВИТЬСАЙТTOOLSTRIPMENUITEM.CLICK
    '    MODE = "SITE"
    '    FRMNEWITEM.SHOW()
    'END SUB
    'PRIVATE SUB ВСЕСАЙТЫTOOLSTRIPMENUITEM_CLICK(SENDER AS OBJECT, E AS EVENTARGS)
    '    FRMSITES.SHOW()
    '    ZAGRYZKA()
    'END SUB
    'PRIVATE SUB ВСЕРАЗДЕЛЫTOOLSTRIPMENUITEM_CLICK(SENDER AS OBJECT, E AS EVENTARGS) HANDLES ВСЕРАЗДЕЛЫTOOLSTRIPMENUITEM.CLICK
    '    FRMPARTITIONS.SHOW()
    '    ZAGRYZKA()
    'END SUB
End Class
