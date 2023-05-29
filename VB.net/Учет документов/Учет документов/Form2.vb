Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = MDIParent1
        Prava()
        Try
            If Me.Text = "Добавление записи" Then
                Dim Proverka As String
                Proverka = InputBox("Введите тип документа и нажмите ОК для продолжения", "Запрос")
                If Proverka = "" Then
                    MessageBox.Show("Не введено число!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Form2_Load(Me, New EventArgs)
                Else
                    TextBox1.Text = "122/01-" & Proverka & "-" & CountForm1 + 1
                    TextBox2.Text = Now.ToLongDateString
                    OtchetGurnal = "Загрузка данных для добавления исходящих" & DateString & " " & TimeString : ZapGurnal()
                End If
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
                OtchetGurnal = "Загрузка данных для редактирования исходящих " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
        OtchetGurnal = "Отмена редактирования/добавления исходящих " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Text = "Добавление записи" Then
            If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
                MessageBox.Show("Не все строки заполнены!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                p1 = TextBox1.Text
                p2 = TextBox2.Value
                p3 = TextBox3.Text
                p4 = TextBox4.Text
                p5 = TextBox5.Text
                p6 = TextBox6.Text
                p7 = TextBox7.Text
                p8 = TextBox8.Text
                p9 = TextBox9.Text
                Form1.dobavlenie_zap()
                Me.Close()
                OtchetGurnal = "Передача данных для добавления исходящих " & DateString & " " & TimeString : ZapGurnal()
            End If
        Else
            p1 = TextBox1.Text
            p2 = TextBox2.Value
            p3 = TextBox3.Text
            p4 = TextBox4.Text
            p5 = TextBox5.Text
            p6 = TextBox6.Text
            p7 = TextBox7.Text
            p8 = TextBox8.Text
            p9 = TextBox9.Text
            Form1.Editor_zap()
            Me.Close()
            OtchetGurnal = "Передача данных для редактирования исходящих " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim MBox As DialogResult = MessageBox.Show("Вы уверены что хотите изменить ключевое поле в БД, которое может нарушить работу программы и целостность данных???", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                TextBox1.Enabled = True
                Button3.Visible = False
                OtchetGurnal = "Вмешательство в ключевое поле исходящих " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class