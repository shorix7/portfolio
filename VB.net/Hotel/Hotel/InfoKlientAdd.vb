Public Class InfoKlientAdd
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub InfoKlientAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        MdiParent = MDI1
        If Text = "Добавление записи" Then
            Exit Sub
        Else
            TextBox8.Text = InfoKlientAdd1
            TextBox9.Text = InfoKlientAdd2
            TextBox10.Text = InfoKlientAdd3
            ComboBox1.Text = InfoKlientAdd4
            DateTimePicker1.Value = InfoKlientAdd5
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Text = "Добавление записи" Then
            If TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or ComboBox1.Text = "" Or DateTimePicker1.Text = "" Then
                MessageBox.Show("Не все строки заполнены", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                InfoKlientAdd1 = TextBox8.Text
                InfoKlientAdd2 = TextBox9.Text
                InfoKlientAdd3 = TextBox10.Text
                InfoKlientAdd4 = ComboBox1.Text
                InfoKlientAdd5 = DateTimePicker1.Value
                Call InfoKlient.Add()
                Close()

            End If
        ElseIf Text = "Редактирование ЧС" Then
            InfoKlientAdd1 = TextBox8.Text
            InfoKlientAdd2 = TextBox9.Text
            InfoKlientAdd3 = TextBox10.Text
            InfoKlientAdd4 = ComboBox1.Text
            InfoKlientAdd5 = DateTimePicker1.Value
            Call BlackList.EditCHS()
            Close()
        Else
            InfoKlientAdd1 = TextBox8.Text
            InfoKlientAdd2 = TextBox9.Text
            InfoKlientAdd3 = TextBox10.Text
            InfoKlientAdd4 = ComboBox1.Text
            InfoKlientAdd5 = DateTimePicker1.Value
            Call InfoKlient.Edit()
            Close()
        End If
    End Sub
End Class