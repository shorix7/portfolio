Imports System.Data.OleDb
Public Class InfoKlient
    Private Sub InfoKlient_Load(sender As Object, e As EventArgs) Handles Me.Load
        MdiParent = MDI1
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Ключ")
        ListView1.Columns.Add("Фамилия")
        ListView1.Columns.Add("Имя")
        ListView1.Columns.Add("Отчество")
        ListView1.Columns.Add("Пол")
        ListView1.Columns.Add("Дата рождения")
        ListView1.Items.Clear()
        ListView1.Columns.Item(0).Width = 70
        ListView1.Columns.Item(1).Width = 150
        ListView1.Columns.Item(2).Width = 150
        ListView1.Columns.Item(3).Width = 150
        ListView1.Columns.Item(4).Width = 50
        ListView1.Columns.Item(5).Width = 100
        Call Read()
    End Sub
    Sub Read()
        Dim Poisk As String = ""
        ListView1.Items.Clear()
        If ToolStripTextBox1.Text = "" Or ToolStripComboBox1.Text = "" Then
            Poisk = "SELECT Клиенты.[Код клиента], Клиенты.[Фамилия], Клиенты.[Имя], Клиенты.[Отчество], Клиенты.[Пол], Клиенты.[Дата рождения] FROM Клиенты;"
        Else
            Poisk = "SELECT Клиенты.[Код клиента], Клиенты.[Фамилия], Клиенты.[Имя], Клиенты.[Отчество], Клиенты.[Пол], Клиенты.[Дата рождения] FROM Клиенты WHERE (((Клиенты.[" & ToolStripComboBox1.Text & "]) Like '%" & ToolStripTextBox1.Text & "%'));"

        End If
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand(Poisk, Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read = True
            ListView1.Items.Add(DataReader.GetValue(0), 0)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(5))
        End While
        DataReader.Close()
        Connector.Close()
        Call CHRead()

    End Sub
    Sub CHRead()
        Dim Poisk As String = ""
        If ToolStripTextBox1.Text = "" Or ToolStripComboBox1.Text = "" Then
            Poisk = "SELECT [Черный список клиентов].[Код ЧС], [Черный список клиентов].[Фамилия], [Черный список клиентов].[Имя], [Черный список клиентов].[Отчество], [Черный список клиентов].[Пол], [Черный список клиентов].[Дата рождения] FROM [Черный список клиентов];"
        Else
            Poisk = "SELECT [Черный список клиентов].[Код ЧС], [Черный список клиентов].[Фамилия], [Черный список клиентов].[Имя], [Черный список клиентов].[Отчество], [Черный список клиентов].[Пол], [Черный список клиентов].[Дата рождения] FROM [Черный список клиентов] WHERE ((([Черный список клиентов].[" & ToolStripComboBox1.Text & "]) Like '%" & ToolStripTextBox1.Text & "%'));"
        End If
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand(Poisk, Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read = True
            ListView1.Items.Add(DataReader.GetValue(0), 1)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(5))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call Read()

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripTextBox1.Text = ""
        Call Read()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        InfoKlientAdd.Close()
        InfoKlientAdd.Text = "Добавление записи"
        InfoKlientAdd.Show()
    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Dim ItemI As Integer
        If e.Button = MouseButtons.Right Then
            ItemI = ListView1.SelectedIndices.Count
            If ItemI = 1 Then ContextMenuStrip1.Show(Location.X + e.X, Location.Y + e.Y + 100)

        End If
    End Sub

    Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ToolStripComboBox1.Text = "" Then
                MessageBox.Show("Не выбрано поле для фильтра", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Call Read()
            End If
        End If
    End Sub

    Private Sub УдалитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьЗаписьToolStripMenuItem.Click
        Call DeleteItem()
    End Sub
    Sub DeleteItem()
        If ListView1.SelectedItems(0).ImageIndex = 0 Then
            Dim MBox As DialogResult = MessageBox.Show("Вы уверены в удалении клиента???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim Command As New OleDbCommand("DELETE FROM [Клиенты] WHERE [Код клиента] =" & ListView1.SelectedItems(0).Text & "", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                Call Read()
                MessageBox.Show("Клиент успешно удален из БД", "Операция успешно завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Клиент в черном списке, для удаления необходимо клиента убрать из ЧС!!!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems(0).ImageIndex = 0 Then
            If Text = "Заселение гостя" Then
                InfoKlientAdd1 = ListView1.SelectedItems.Item(0).SubItems(1).Text
                InfoKlientAdd2 = ListView1.SelectedItems.Item(0).SubItems(2).Text
                InfoKlientAdd3 = ListView1.SelectedItems.Item(0).SubItems(3).Text
                InfoKlientAdd4 = ListView1.SelectedItems.Item(0).SubItems(0).Text
                Call Zaselenie.Prime()
                Close()
            Else
                InfoKlientAdd1 = ListView1.SelectedItems.Item(0).SubItems(1).Text
                InfoKlientAdd2 = ListView1.SelectedItems.Item(0).SubItems(2).Text
                InfoKlientAdd3 = ListView1.SelectedItems.Item(0).SubItems(3).Text
                InfoKlientAdd4 = ListView1.SelectedItems.Item(0).SubItems(4).Text
                InfoKlientAdd5 = ListView1.SelectedItems.Item(0).SubItems(5).Text
                InfoKlientAdd.Close()
                InfoKlientAdd.Text = "Редактировние записи"
                InfoKlientAdd.Show()
            End If
        Else
            MessageBox.Show("Клиент в черном спимке, для удаления необходимо клиента убрать из ЧC Либо перейти в таблицу ЧС!!!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Sub Edit()
        Dim Command As New OleDbCommand("UPDATE [Клиенты] SET [Фамилия] = '" & InfoKlientAdd1 & "',[Имя] = '" & InfoKlientAdd2 & "',[Отчество] = '" & InfoKlientAdd3 & "',[Пол] = '" & InfoKlientAdd4 & "',[Дата рождения] = '" & InfoKlientAdd5 & "' WHERE ([Код клиента] Like '" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Read()

    End Sub
    Sub Add()
        Dim Command As New OleDbCommand("Insert Into [Клиенты] ([Фамилия], [Имя], [Отчество], [Пол], [Дата рождения]) values ('" & InfoKlientAdd1 & "', '" & InfoKlientAdd2 & "', '" & InfoKlientAdd3 & "', '" & InfoKlientAdd4 & "', '" & InfoKlientAdd5 & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Read()
    End Sub

    Private Sub ДобавитьВЧСКлиентаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьВЧСКлиентаToolStripMenuItem.Click
        If ListView1.SelectedItems(0).ImageIndex = 0 Then
            Dim MBox As DialogResult = MessageBox.Show("Вы уверены что данного клиента стоит поместить в черный список?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim a As String = InputBox("Напишите причину помещения данного клиента в черный список", "Комментарий для нарушителя")
                If a = "" Then a = "Комментарий не был добавлен!"


                BlackList.Show()




                Dim Command As New OleDbCommand("Insert Into [Черный список клиентов] ([Код ЧС],[Фамилия], [Имя], [Отчество], [Пол], [Дата рождения], [Причина], [Дата]) values ('" & ("CHS-" & KolvoCHS + 1) & "','" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(4).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(5).Text & "', '" & a & "', '" & DateString & "') ", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                Call CHS()
                ListView1.SelectedItems(0).ImageIndex = 1
                MessageBox.Show("Клиент помещен в черный список", "Операция успешно завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Read()

            End If
        Else
            MessageBox.Show("Текущий клиент уже находится в ЧС!!!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Sub CHS()
        Dim Command As New OleDbCommand("DELETE FROM [Клиенты] WHERE ([Код клиента] = " & ListView1.SelectedItems.Item(0).Text & ")", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub
End Class