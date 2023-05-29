Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class MDIParent1
    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ToolStripStatusLabel2.Text = Now.ToLongDateString
        ToolStripStatusLabel4.Text = Now.ToLongTimeString
        Dim DataReader1 As OleDbDataReader
        Dim command1 As New OleDbCommand("SELECT * FROM Параметры", Connector)
        Connector.Open()
        DataReader1 = command1.ExecuteReader
        While DataReader1.Read() = True
            SettingsGurnal = DataReader1.GetValue(0)
            SettingsOprPolzovatelya = DataReader1.GetValue(1)
            SettingsObnovlenie = DataReader1.GetValue(2)
            SettingsIP = DataReader1.GetValue(3)
            SettingsArchivirovanie = DataReader1.GetValue(4)
            SettingsVostanovlenieRezervnoiKopii = DataReader1.GetValue(5)
            SettingsOtkatBD = DataReader1.GetValue(6)
            SettingsAutoObnovlenie = DataReader1.GetValue(7)
        End While
        DataReader1.Close()
        Connector.Close()
        Prava()
        OtchetGurnal = "Программа успешно запущена " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        OtchetGurnal = "Программа завершена " & DateString & " " & TimeString : ZapGurnal()
        Me.Close()
    End Sub

    Private Sub СтрокаСостоянияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СтрокаСостоянияToolStripMenuItem.Click
        If СтрокаСостоянияToolStripMenuItem.Checked = True Then
            Me.StatusStrip1.Visible = False
            СтрокаСостоянияToolStripMenuItem.Checked = False
        Else
            Me.StatusStrip1.Visible = True
            СтрокаСостоянияToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ИсходящиеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ИсходящиеToolStripMenuItem.Click
        Form1.Close()
        Form1.Show()
        OtchetGurnal = "Запущен книга Исходящие" & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ВходящиеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВходящиеToolStripMenuItem.Click
        Form3.Close()
        Form3.Show()
        OtchetGurnal = "Запущена книга Входящие " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ДоговорыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДоговорыToolStripMenuItem.Click
        Form5.Close()
        Form5.Show()
        OtchetGurnal = "Запущена книга Договоры " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ПриказыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПриказыToolStripMenuItem.Click
        Form7.Close()
        Form7.Show()
        OtchetGurnal = "Запущена книга Приказы " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ПриказыПоСтудентамToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПриказыПоСтудентамToolStripMenuItem.Click
        Form9.Close()
        Form9.Show()
        OtchetGurnal = "Запущена книга Приказы по студентам " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ПриказыПоАХДToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПриказыПоАХДToolStripMenuItem.Click
        Form11.Close()
        Form11.Show()
        OtchetGurnal = "Запущена книга Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ДокладныеИСлужебныеЗаписиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДокладныеИСлужебныеЗаписиToolStripMenuItem.Click
        Form13.Close()
        Form13.Show()
        OtchetGurnal = "Запущена книга Докладные и служебные записи " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub АктыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АктыToolStripMenuItem.Click
        Form15.Close()
        Form15.Show()
        OtchetGurnal = "Запущена книга Акты " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub РаспоряженияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles РаспоряженияToolStripMenuItem.Click
        Form17.Close()
        Form17.Show()
        OtchetGurnal = "Запущена книга Распоряжения " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ДоверенностиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДоверенностиToolStripMenuItem.Click
        Form19.Close()
        Form19.Show()
        OtchetGurnal = "Запущена книга Доверенности " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub КаскадомToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles КаскадомToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub СлеваНаправоToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СлеваНаправоToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub СверхуВнизToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СверхуВнизToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ЗакрытьВсеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗакрытьВсеToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()

        Next
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        MsgBox(Chr(10) & "Программа для введения учета регистрационных документов ЗФ_РАНХиГС" & Chr(13) & Chr(10) & "Версия программы 2.0", vbOKOnly + vbInformation, "Информация")
    End Sub

    Private Sub ОАвтореToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОАвтореToolStripMenuItem.Click
        MsgBox(Chr(10) & "Автор: Суворов Дмитрий Витальевич" & Chr(13) & Chr(10) & "Контакты" & Chr(13) & "E-Mail: dmitriy.suvorov.2004@mail.ru" & Chr(10) & "Почти IT программист отдела Западного Филиала Российской Академии народного хозяйства и Государственной службы при президенте Российской Федерации (РАНХиГС)" & Chr(13), vbOKOnly + vbInformation, "Информация")
    End Sub

    Private Sub ЛицензионноеСоглашениеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЛицензионноеСоглашениеToolStripMenuItem.Click
        MsgBox(Chr(10) & "Данная программа защищена законом об авторских правах и международнымисоглашениями. Незаконноевоспроизведение или распространение данной программы или любой ее части влечет гражданскую и уголовную ответственность" & Chr(13) & "Данная программа специально написана для Общего Отдела - ЗФ_РАНХиГС", vbOKOnly + vbInformation, "Информация")
    End Sub

    'Private Sub НаписатьПисьмоРазработчикуToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НаписатьПисьмоРазработчикуToolStripMenuItem.Click
    '    Try
    '        Dim Proverka As String
    '        Proverka = InputBox("Введите текст сообщения который будет автоматически отправлен...", "Отправка сообщения")
    '        If Proverka = "" Then
    '            Exit Sub
    '        Else
    '            Dim olApp As Outlook.Application
    '            olApp = CreateObject("Outlook.Application")
    '            Dim olItem As Outlook.ContactItem
    '            olItem = olApp.CreateItem(Outlook.OlItemType.olContactItem)
    '            With olItem
    '                .FullName = "Суворов Дмитрий Витальевич"
    '                .Birthday = "27.06.2004"
    '                .CompanyName = "ЗФ_РАНХиГС"
    '                .Email1Address = "dmitriy.suvorov.2004@mail.ru"
    '                .JobTitle = "Картофельный программист"
    '            End With
    '            olItem.Save()
    '            Dim olMail As Outlook.MailItem
    '            olMail = olApp.CreateItem(Outlook.OlItemType.olMailItem)
    '            olMail.To = olItem.Email1Address
    '            olMail.Subject = "Есть вопрос по программе..."
    '            olMail.Body = "Уважаемый" & olItem.FirstName & ", " & vbCrLf & vbTab & Proverka
    '            olMail.Send()
    '            MsgBox("Сообщене успешно отправлено!!!", vbMsgBoxSetForeground)
    '            olMail = Nothing
    '            olItem = Nothing
    '            olApp = Nothing
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        OtchetGurnal = "Ошибка" & ex.Message & DateString & " " & TimeString : ZapGurnal()
    '    End Try
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1
        If ToolStripProgressBar1.Value = 100 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ToolStripStatusLabel2.Text = Now.ToLongDateString
        ToolStripStatusLabel4.Text = Now.ToLongTimeString
    End Sub

    Private Sub МастерПостроенияОтчетовToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles МастерПостроенияОтчетовToolStripMenuItem.Click
        Master.Close()
        Master.Show()
        OtchetGurnal = "Открыт мастер запросов" & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ПоставитьНаКонтрольToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоставитьНаКонтрольToolStripMenuItem.Click
        Kontrol.Close()
        Kontrol.Show()
        OtchetGurnal = "Контроль открыт" & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НастройкиToolStripMenuItem.Click
        Settings.Close()
        Settings.Show()
        OtchetGurnal = "Открыты настройки" & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ЖурналСобытийToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЖурналСобытийToolStripMenuItem.Click
        Gurnal.Close()
        Gurnal.Show()
        OtchetGurnal = "Открыт журнал" & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub АвторизироватьсяToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АвторизироватьсяToolStripMenuItem.Click
        Try
            Dim Proverka As String
            Proverka = InputBox("Введите пароль для авторизации пользователя", "Запрос авторизации")
            If Proverka = "" Then
                Exit Sub
            Else
                Dim DataReader As OleDbDataReader
                Dim command As New OleDbCommand("Select Пользователи.[Код], Пользователи.[Фамилия], Пользователи.[Имя], Пользователи.[Отчество], Пользователи.[Права], Пользователи.[Пароль] FROM Пользователи WHERE (((Пользователи.[Пароль]) ='" & Proverka & "'));", Connector)
                Connector.Open()
                DataReader = Command.ExecuteReader
                While DataReader.Read() = True
                    PravaPolzovatelyaKod = DataReader.GetValue(0)
                    PravaPolzovatelyaFamiliya = DataReader.GetValue(1)
                    PravaPolzovatelyaImya = DataReader.GetValue(2)
                    PravaPolzovatelyaOtchestvo = DataReader.GetValue(3)
                    PravaPolzovatelyaPrava = DataReader.GetValue(4)
                    PravaPolzovatelyaPassword = DataReader.GetValue(5)
                End While
                If PravaPolzovatelyaKod = "" Then MessageBox.Show("Авторизация не удалась", "Не удача", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If PravaPolzovatelyaKod <> "" Then MessageBox.Show("Добро пожаловать в программу " & PravaPolzovatelyaFamiliya & " " & PravaPolzovatelyaImya & " " & PravaPolzovatelyaOtchestvo, "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ToolStripStatusLabel5.Text = "Авторизован: " & PravaPolzovatelyaFamiliya & " " & PravaPolzovatelyaImya & " " & PravaPolzovatelyaOtchestvo
                DataReader.Close()
            Connector.Close()
            Prava()
            OtchetGurnal = "Попытка авторизации в программе " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка" & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub АрхивированиеБДToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АрхивированиеБДToolStripMenuItem.Click
        Try
            Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите запустить архивирование всех данных при этом старый архив будет удален???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                ToolStripProgressBar1.Value = 25
                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next
                ToolStripProgressBar1.Value = 50
                IO.File.Delete(Application.StartupPath & "/bd - архив")
                ToolStripProgressBar1.Value = 75
                IO.File.Copy(Application.StartupPath & "/bd.mbd", Application.StartupPath & "/bd - архив")
                ToolStripProgressBar1.Value = 100
                MessageBox.Show("Архивирование успешно завершено!!!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OtchetGurnal = "Запущена архивирование БД " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка" & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ВосстановлениеРезервнойКопииБДToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВосстановлениеРезервнойКопииБДToolStripMenuItem.Click
        Try
            Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите восстановить БД из архива при этом текущие данные будут утерены???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                ToolStripProgressBar1.Value = 25
                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next
                ToolStripProgressBar1.Value = 50
                IO.File.Delete(Application.StartupPath & "/bd.mbd")
                ToolStripProgressBar1.Value = 75
                IO.File.Copy(Application.StartupPath & "/bd - архив", Application.StartupPath & "/bd.mbd")
                ToolStripProgressBar1.Value = 100
                MessageBox.Show("Восстановление из архива выполнено успешно!!!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OtchetGurnal = "Восстановление из архива БД " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка" & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ВосстановлениеВИсToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВосстановлениеВИсToolStripMenuItem.Click
        Try
            Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите БД обнулить, что приведет к потери всех данных???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                ToolStripProgressBar1.Value = 25
                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next
                ToolStripProgressBar1.Value = 50
                IO.File.Delete(Application.StartupPath & "/bd.mbd")
                ToolStripProgressBar1.Value = 75
                IO.File.Copy(Application.StartupPath & "/bd - пустая", Application.StartupPath & "/bd.mbd")
                ToolStripProgressBar1.Value = 100
                MessageBox.Show("БД возвращена в исходный вид и все записи успешно удалены!!!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OtchetGurnal = "Запущена процедура восстановления бд в исходный вид " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка" & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class