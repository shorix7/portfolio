Public Class Form20
    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = MDIParent1
        Prava()
        If Me.Text = "Добавление записи" Then
            TextBox2.Text = Now.ToLongDateString
            TextBox1.Text = CountForm10 + 1
            OtchetGurnal = "Загрузка данных для добавления записи Доверенности " & DateString & " " & TimeString : ZapGurnal()
        Else
            TextBox1.Text = p1
            TextBox2.Value = p2
            TextBox3.Text = p3
            TextBox4.Text = p4
            TextBox5.Text = p5
            TextBox6.Text = p6
            OtchetGurnal = "Загрузка данных для редактирования записи Доверенности " & DateString & " " & TimeString : ZapGurnal()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
        OtchetGurnal = "Отмена добавления/редактирования записей Доверенности " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Text = "Добавление записи" Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
                MessageBox.Show("Не все строки заполнены!!!", "Уведомление", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation)
            Else
                p1 = TextBox1.Text
                p2 = TextBox2.Value
                p3 = TextBox3.Text
                p4 = TextBox4.Text
                p5 = TextBox5.Text
                p6 = TextBox6.Text
                Form19.Dobavlenie_zap()
                Me.Close()
                OtchetGurnal = "Передача на выполнение Доверенности" & DateString & " " & TimeString : ZapGurnal()
            End If
        Else
            p1 = TextBox1.Text
            p2 = TextBox2.Value
            p3 = TextBox3.Text
            p4 = TextBox4.Text
            p5 = TextBox5.Text
            p6 = TextBox6.Text
            Form19.Editor_zap()
            Me.Close()
            OtchetGurnal = "Передача на выполнение редактирования Доверенности " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите изменить ключевое поле в БД, которое может нарушить работу программы и целостность данных???", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                TextBox1.Enabled = True
                Button3.Visible = False
                OtchetGurnal = "Вмешательство в ключевое поле Доверенности " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class