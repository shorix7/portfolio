Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = MDIParent1
        Prava()
        If Me.Text = "Добавление записи" Then
            TextBox2.Text = Now.ToLongDateString
            TextBox1.Text = CountForm3 + 1
        Else
            TextBox1.Text = p1
            TextBox2.Text = p2
            TextBox3.Text = p3
            TextBox4.Text = p4
            TextBox5.Text = p5
            TextBox6.Text = p6
            TextBox7.Text = p7
            TextBox8.Text = p8
            TextBox9.Text = p9
            TextBox10.Text = p10
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Text = "Добавление записи" Then
            If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Then
                MessageBox.Show("Не все строки заполнены!!!", "Уведомление", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
            Else
                p1 = TextBox1.Text
                p2 = TextBox2.Text
                p3 = TextBox3.Text
                p4 = TextBox4.Text
                p5 = TextBox5.Text
                p6 = TextBox6.Text
                p7 = TextBox7.Text
                p8 = TextBox8.Text
                p9 = TextBox9.Text
                p10 = TextBox10.Text
                Form5.Dobavlenie_zap()
                Me.Close()
            End If
        Else
            p1 = TextBox1.Text
            p2 = TextBox2.Text
            p3 = TextBox3.Text
            p4 = TextBox4.Text
            p5 = TextBox5.Text
            p6 = TextBox6.Text
            p7 = TextBox7.Text
            p8 = TextBox8.Text
            p9 = TextBox9.Text
            p10 = TextBox10.Text
            Form5.Editor_zap()
            Me.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите изменить ключевое поле в БД, которое может нарушить работу программы и целостность данных???", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                TextBox1.Enabled = True
                Button3.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class