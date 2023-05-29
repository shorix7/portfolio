Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Private lvwcolumnsorter As listviewcolumnsorter
    Dim databasefilename As String = Application.StartupPath & "\db.mdb"
    Dim connector As New OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" & databasefilename)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvwcolumnsorter = New listviewcolumnsorter
        ListView1.ListViewItemSorter = lvwcolumnsorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("ID")
        ListView1.Columns.Add("Номер")
        ListView1.Columns.Add("IP")
        ListView1.Columns.Add("DNS")
        ListView1.Columns.Add("Марка")
        ListView1.Columns.Add("S/N")
        ListView1.Columns.Add("Устройство")
        ListView1.Columns.Add("Наличие")
        ListView1.Items.Clear()
        Try
            Dim datareader As oledbdatareader
            Dim command As New oledbcommand("Select * From Техника", connector)
            Dim kartinka As Integer
            kartinka = 3
            connector.open()
            datareader = command.executereader
            While datareader.read() = True
                If datareader.getvalue(6) = "Видео-фотокамера" Then kartinka = 0
                If datareader.GetValue(6) = "проектор" Then kartinka = 1
                If datareader.GetValue(6) = "телефон" Then kartinka = 2
                If datareader.getvalue(6) = "Ноутбук" Then kartinka = 3
                ListView1.Items.Add(datareader.getvalue(0), kartinka)
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(1))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(2))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(3))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(4))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(5))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(6))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(datareader.getvalue(7))
            End While
            datareader.close
            connector.close
        Catch ex As Exception
            connector.close
            MsgBox(ex.Message)

        End Try
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        For Each columnheader In Me.ListView1.Columns
            columnheader.Width = -3
        Next
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        Form1_Load(Me, New EventArgs)
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        End
    End Sub

    Private Sub БольшиеИконкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles БольшиеИконкиToolStripMenuItem.Click
        ListView1.View = View.LargeIcon
    End Sub

    Private Sub ДеталиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДеталиToolStripMenuItem.Click
        ListView1.View = View.Details
    End Sub

    Private Sub МаленькиеИконкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles МаленькиеИконкиToolStripMenuItem.Click
        ListView1.View = View.SmallIcon
    End Sub

    Private Sub СписокToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СписокToolStripMenuItem.Click
        ListView1.View = View.List
    End Sub

    Private Sub НазваниеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НазваниеToolStripMenuItem.Click
        ListView1.View = View.Tile
    End Sub
    Sub dobavlenie_zap()
        lvwcolumnsorter = New listviewcolumnsorter()
        Me.ListView1.ListViewItemSorter = lvwcolumnsorter
        Try
            Dim command As New OleDbCommand("Insert Into [Техника] ([Номер], [IP], [DNS], [Марка], [S/N], [Устройство], [Наличие]) values ('" & номер & "', '" & IP & "','" & DNS & "', '" & Марка & "', '" & SN & "', '" & Устройство & "','" & Наличие & "')", connector)
            connector.Open()
            command.ExecuteNonQuery()
            connector.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ListView1.Items.Add("Номер")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("IP")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("DNS")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Марка")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("SN")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Устройство")
        ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Наличие")
        Form1_Load(Me, New EventArgs)
        For Each columnheader In Me.ListView1.Columns
            columnheader.Width = -3
        Next

    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Dim ItemIndex As Integer
        If e.Button = MouseButtons.Right Then
            ItemIndex = ListView1.SelectedIndices.Count
            If ItemIndex = 1 Then
                ContextMenuStrip1.Show(Location.X + e.X, Location.Y + e.Y + ContextMenuStrip1.Height)
            Else
                ContextMenuStrip2.Show(Location.X + e.X, Location.Y + e.Y + ContextMenuStrip1.Height)
            End If
        End If
    End Sub
    Sub editor_zap()
        Try
            Dim command As New OleDbCommand("UPTATE Техника SET [Номер]='" & номер & "', [IP]='" & IP & "',  [DNS]='" & DNS & "', [Марка]='" & Марка & "', [S/N]='" & SN & "', [Устройство]='" & Устройство & "', [Наличие]='" & Наличие & "' WHERE ([ID] Like '" & ListView1.SelectedItems.Item(0).Text & "')", connector)
            connector.Open()
            command.ExecuteNonQuery()
            connector.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListView1.SelectedItems.Item(0).Text = номер
        ListView1.SelectedItems.Item(0).SubItems.Item(1).Text = IP
        ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = DNS
        ListView1.SelectedItems.Item(0).SubItems.Item(3).Text = Марка
        ListView1.SelectedItems.Item(0).SubItems.Item(4).Text = SN
        ListView1.SelectedItems.Item(0).SubItems.Item(5).Text = Устройство
        ListView1.SelectedItems.Item(0).SubItems.Item(6).Text = Наличие
        Form1_Load(Me, New EventArgs)
    End Sub
    Sub выдать()
        Try

            Dim дата As String = Format(Now, "d MMMM yyyy")
            Dim command As New OleDbCommand("UPDATE Техника SET [Номер]='" & номер & "', [IP]='" & IP & "',  [DNS]='" & DNS & "', [Марка]='" & Марка & "', [S/N]='" & SN & "', [Устройство]='" & Устройство & "', [Наличие]='" & Наличие & "' WHERE ([ID] Like '" & ListView1.SelectedItems.Item(0).Text & "')", connector)
            connector.Open()
            command.ExecuteNonQuery()
            connector.Close()
            ListView1.SelectedItems.Item(0).SubItems.Item(1).Text = номер
            ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = IP
            ListView1.SelectedItems.Item(0).SubItems.Item(3).Text = DNS
            ListView1.SelectedItems.Item(0).SubItems.Item(4).Text = Марка
            ListView1.SelectedItems.Item(0).SubItems.Item(5).Text = SN
            ListView1.SelectedItems.Item(0).SubItems.Item(6).Text = Устройство
            ListView1.SelectedItems.Item(0).SubItems.Item(7).Text = Наличие
            Dim command1 As New OleDbCommand("Insert into [Журнал] ([ФИО], [История], [Дата]) values ('" & Получатель & "', '" & ПК & "', '" & дата & "') ", connector)

            connector.Open()
            command1.ExecuteNonQuery()
            connector.Close()
            ListView1.Items.Add("ID")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("ФИО")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("История")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Дата")
            Dim command2 As New OleDbCommand("Insert into [Журнал выдач] ([ФИО], [История], [IDGurnal]) values ('" & Получатель & "', '" & ПК & "', '" & id & "') ", connector)
            connector.Open()
            command2.ExecuteNonQuery()
            connector.Close()
            ListView1.Items.Add("ID")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("ФИО")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("История")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("IDGurnal")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Устройство: " & Chr(13) & Chr(10) & ПК & Chr(13) & Chr(10) & "Для:" & Chr(13) & Chr(10) & Получатель & Chr(13) & Chr(10) & "Успешно выдано!!!", "Операция успешно завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        Try
            id = ListView1.SelectedItems.Item(0).Text
            номер = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            IP = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            DNS = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            Марка = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            SN = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            Устройство = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
            Наличие = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
            form2.text = "Редактирование записи"
            form2.show
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = lvwcolumnsorter.sortcolumn) Then
            If (lvwcolumnsorter.order = SortOrder.Ascending) Then
                lvwcolumnsorter.order = SortOrder.Descending
            Else
                lvwcolumnsorter.order = SortOrder.Ascending
            End If
        Else
            lvwcolumnsorter.sortcolumn = e.Column
            lvwcolumnsorter.order = SortOrder.Ascending
        End If
        Me.ListView1.Sort()
    End Sub

    Private Sub УдалитьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles УдалитьToolStripMenuItem1.Click
        Dim mbox As DialogResult = MessageBox.Show("Вы действительно хотите безвозвратно удалить устройство из базы данных?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If mbox = DialogResult.No Then Exit Sub
        If mbox = DialogResult.Yes Then
            Try
                Dim Command As New OleDbCommand("DELETE FROM Техника WHERE ID =" & ListView1.SelectedItems.Item(0).Text & "", connector)
                connector.Open()
                Command.ExecuteNonQuery()
                connector.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            ListView1.SelectedItems.Item(0).Remove()
        End If
    End Sub

    Private Sub ПолучателиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПолучателиToolStripMenuItem.Click
        form3.text = "Получатели"
        form3.show
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Form1_Load(Me, New EventArgs)
        Timer1.Enabled = False
    End Sub

    Private Sub ДобавитьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ДобавитьToolStripMenuItem1.Click
        ДобавитьToolStripMenuItem_Click_1(Me, New EventArgs)
    End Sub

    Private Sub ДобавитьToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ДобавитьToolStripMenuItem.Click
        form2.text = "Добавление записи"
        form2.show
    End Sub

    Private Sub ВыдатьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыдатьToolStripMenuItem.Click

        Try
            If ListView1.SelectedItems.Item(0).SubItems.Item(7).Text = "Да" Then
                id = ListView1.SelectedItems.Item(0).Text
                номер = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                IP = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                DNS = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                Марка = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                SN = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                Устройство = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                Наличие = "Нет"
                ПК = номер & " - " & Марка & " - " & IP & " - " & DNS & " - " & SN & " - " & Устройство
                Form3.Show()
                Form3.Text = "Выберите получателя..."
            Else
                MessageBox.Show("Данное устройство уже было успешно выдано ранее..." & Chr(13) & Chr(10) & "Смотрите журнал выдач...", "Невозможно выполнить операцию...", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ЖурналToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЖурналToolStripMenuItem.Click
        form5.text = "Архив выдач..."
        form5.show
    End Sub

    Private Sub ОтчётПоВыданнойТехникиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОтчётПоВыданнойТехникиToolStripMenuItem.Click
        form6.text = "Текущий отчет..."
        form6.show
    End Sub

    Private Sub ЖурналВыдачДанногоУстройстваToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЖурналВыдачДанногоУстройстваToolStripMenuItem.Click
        id = ListView1.SelectedItems.Item(0).Text
        номер = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
        IP = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        DNS = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        Марка = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        SN = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
        Устройство = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
        Комп = номер & " - " & Марка & " - " & IP & " - " & DNS & " - " & SN & " - " & Устройство
        form5.text = "Отчет по: " & Комп
        form5.show
    End Sub

    Private Sub ТекущийОтчетДанногоУстройстваToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ТекущийОтчетДанногоУстройстваToolStripMenuItem.Click
        id = ListView1.SelectedItems.Item(0).Text
        номер = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
        IP = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        DNS = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        Марка = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        SN = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
        Устройство = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
        Комп = номер & " - " & Марка & " - " & IP & " - " & DNS & " - " & SN & " - " & Устройство
        form6.text = "Отчет текущий по: " & Комп
        form6.show
    End Sub

    Private Sub ПерезагрузкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПерезагрузкаToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub УдалитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьToolStripMenuItem.Click
        Dim mbox As DialogResult = MessageBox.Show("Вы действительно хотите безвозвратно удалить устройство из базы данных?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If mbox = DialogResult.No Then Exit Sub
        If mbox = DialogResult.Yes Then
            Try
                Dim Command As New OleDbCommand("DELETE FROM Техника WHERE ID =" & ListView1.SelectedItems.Item(0).Text & "", connector)
                connector.Open()
                Command.ExecuteNonQuery()
                connector.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            ListView1.SelectedItems.Item(0).Remove()
        End If
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        Form7.Show()
    End Sub

    Private Sub ОАвтореToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОАвтореToolStripMenuItem.Click
        Form8.Show()
    End Sub

    Private Sub ВыдатьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ВыдатьToolStripMenuItem1.Click
        ВыдатьToolStripMenuItem_Click(Me, New EventArgs)
    End Sub

    Private Sub БольшиеИконкиToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles БольшиеИконкиToolStripMenuItem1.Click
        ListView1.View = View.LargeIcon
    End Sub

    Private Sub ДеталиToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ДеталиToolStripMenuItem1.Click
        ListView1.View = View.Details
    End Sub

    Private Sub МаленькиеИконкиToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles МаленькиеИконкиToolStripMenuItem1.Click
        ListView1.View = View.SmallIcon
    End Sub

    Private Sub СписокToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles СписокToolStripMenuItem1.Click
        ListView1.View = View.List
    End Sub

    Private Sub НазваниеToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles НазваниеToolStripMenuItem1.Click
        ListView1.View = View.Tile
    End Sub

    Private Sub ОбновитьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem1.Click
        Form1_Load(Me, New EventArgs)
    End Sub
End Class
