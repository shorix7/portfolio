Imports System.Data.OleDb
Public Class BlackList
    Private Sub BlackList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = MDI1
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Код ЧС")
        ListView1.Columns.Add("Фамилия")
        ListView1.Columns.Add("Имя")
        ListView1.Columns.Add("Отчество")
        ListView1.Columns.Add("Пол")
        ListView1.Columns.Add("Дата рождения")
        ListView1.Columns.Add("Причина")
        ListView1.Columns.Add("Дата")
        ListView1.Items.Clear()
        ListView1.Columns.Item(0).Width = 70
        ListView1.Columns.Item(1).Width = 150
        ListView1.Columns.Item(2).Width = 150
        ListView1.Columns.Item(3).Width = 150
        ListView1.Columns.Item(4).Width = 50
        ListView1.Columns.Item(5).Width = 100
        ListView1.Columns.Item(6).Width = 100
        ListView1.Columns.Item(7).Width = 100
        Call CHRead()
    End Sub
    Sub CHRead()
        Dim Poisk As String = ""
        ListView1.Items.Clear()
        If ToolStripTextBox1.Text = "" Or ToolStripComboBox1.Text = "" Then
            Poisk = "SELECT [Черный список клиентов].[Код ЧС], [Черный список клиентов].[Фамилия], [Черный список клиентов].[Имя], [Черный список клиентов].[Отчество], [Черный список клиентов].[Пол], [Черный список клиентов].[Дата рождения], [Черный список клиентов].[Причина], [Черный список клиентов].[Дата] FROM [Черный список клиентов];"
        Else
            Poisk = "SELECT [Черный список клиентов].[Код ЧС], [Черный список клиентов].[Фамилия], [Черный список клиентов].[Имя], [Черный список клиентов].[Отчество], [Черный список клиентов].[Пол], [Черный список клиентов].[Дата рождения], [Черный список клиентов].[Причина], [Черный список клиентов].[Дата] FROM [Черный список клиентов] WHERE ((([Черный список клиентов].[" & ToolStripComboBox1.Text & "]) Like '%" & ToolStripTextBox1.Text & "%'));"
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
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(6))
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(7))
        End While
        DataReader.Close()
        Connector.Close()
        Call Podchet()
    End Sub

    Private Sub Podchet()
        Dim k As Integer = ListView1.Items.Count
        KolvoCHS = k
    End Sub

    Private Sub ВернутьИзЧсToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВернутьИзЧсToolStripMenuItem.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы уверены что данного клиента стоит вернуть из ЧС??", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If MBox = DialogResult.No Then Exit Sub
        If MBox = DialogResult.Yes Then

            Dim Command As New OleDbCommand("Insert Into [Клиенты] ([Фамилия], [Имя], [Отчество], [Пол], [Дата рождения]) values ('" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(4).Text & "', '" & ListView1.SelectedItems.Item(0).SubItems(5).Text & "') ", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
            Call izCHS()
            Call CHRead()
        End If
    End Sub

    Sub izCHS()
        Dim Command As New OleDbCommand("DELETE FROM [Черный список клиентов] WHERE ([Код ЧС] = '" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call CHRead()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripTextBox1.Text = ""
        Call CHRead()
    End Sub

    Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ToolStripComboBox1.Text = "" Then
                MessageBox.Show("Не выбрано поле для фильтра", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Call CHRead()
            End If
        End If
    End Sub
    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Dim ItemI As Integer
        If e.Button = MouseButtons.Right Then
            ItemI = ListView1.SelectedIndices.Count
            If ItemI = 1 Then ContextMenuStrip1.Show(Location.X + e.X, Location.Y + e.Y + 115)

        End If
    End Sub
    Sub EditCHS()
        Dim Command As New OleDbCommand("UPDATE [Черный список клиентов] SET [Фамилия] = '" & InfoKlientAdd1 & "',[Имя] = '" & InfoKlientAdd2 & "',[Отчество] = '" & InfoKlientAdd3 & "',[Пол] = '" & InfoKlientAdd4 & "',[Дата рождения] = '" & InfoKlientAdd5 & "' WHERE ([Код ЧС] Like '" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call CHRead()

    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        InfoKlientAdd1 = ListView1.SelectedItems.Item(0).SubItems(1).Text
        InfoKlientAdd2 = ListView1.SelectedItems.Item(0).SubItems(2).Text
        InfoKlientAdd3 = ListView1.SelectedItems.Item(0).SubItems(3).Text
        InfoKlientAdd4 = ListView1.SelectedItems.Item(0).SubItems(4).Text
        InfoKlientAdd5 = ListView1.SelectedItems.Item(0).SubItems(5).Text
        InfoKlientAdd.Close()
        InfoKlientAdd.Text = "Редактирование ЧС"
        InfoKlientAdd.Show()
    End Sub
End Class