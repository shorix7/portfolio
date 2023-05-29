Public Class Form14
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = MDIParent1
        Prava()
        If Me.Text = "Добавление записи" Then
            TextBox2.Text = Now.ToLongDateString
            TextBox1.Text = CountForm7 + 1
            OtchetGurnal = "Загрузка данных добавления Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
        Else
            TextBox1.Text = p1
            TextBox2.Value = p2
            TextBox3.Text = p3
            TextBox5.Text = p5
            TextBox6.Text = p6
            TextBox7.Text = p7
            OtchetGurnal = "Загрузка данных редактирования Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OtchetGurnal = "Отмена Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Text = "Добавление записи" Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MessageBox.Show("Не все строки заполнены!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                p1 = TextBox1.Text
                p2 = TextBox2.Value
                p3 = TextBox3.Text
                p5 = TextBox5.Text
                p6 = TextBox6.Text
                p7 = TextBox7.Text
                Form13.Dobavlenie_zap()
                Me.Close()
                OtchetGurnal = "Передача на выполнения добавления Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
            End If
        Else
            p1 = TextBox1.Text
            p2 = TextBox2.Value
            p3 = TextBox3.Text
            p5 = TextBox5.Text
            p6 = TextBox6.Text
            p7 = TextBox7.Text
            Form13.Editor_zap()
            Me.Close()
            OtchetGurnal = "Передача на выполнения редактирования Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите изменить ключевое поле в БД которое может нарушить работу программы и целостность данных???", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                TextBox1.Enabled = True
                Button3.Visible = False
                OtchetGurnal = "Вмешательство в ключевое поле Докладные и служебные записки " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class