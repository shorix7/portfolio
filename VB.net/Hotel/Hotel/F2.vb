Imports System.Data.OleDb
Public Class F2
    Private Sub F2_Load(sender As Object, e As EventArgs) Handles Me.Load
        MdiParent = MDI1
        PictureBoxList.Clear()
        LabelList.Clear()
        PictureBoxList.Add(PictureBox1)
        PictureBoxList.Add(PictureBox2)
        PictureBoxList.Add(PictureBox3)
        PictureBoxList.Add(PictureBox4)
        PictureBoxList.Add(PictureBox5)
        PictureBoxList.Add(PictureBox6)
        PictureBoxList.Add(PictureBox7)
        PictureBoxList.Add(PictureBox8)
        PictureBoxList.Add(PictureBox9)
        PictureBoxList.Add(PictureBox10)
        LabelList.Add(Label1)
        LabelList.Add(Label2)
        LabelList.Add(Label3)
        LabelList.Add(Label4)
        LabelList.Add(Label5)
        LabelList.Add(Label6)
        LabelList.Add(Label7)
        LabelList.Add(Label8)
        LabelList.Add(Label9)
        LabelList.Add(Label10)
        Call Status()
    End Sub
    Sub Status()
        Dim k As Integer
        Dim Etag As String
        If Label1.Text = 101 Then
            Etag = 10
        Else
            Etag = Mid(Label1.Text, 1, 1)
        End If
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Номера.[Номер], Номера.[Этаж], Номера.[статус] FROM Номера WHERE (((Номера.[Этаж])='" & Etag & "')); ", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        k = 0
        While DataReader.Read() = True
            Status1 = DataReader.GetValue(2)
            If Status1 = "Свободен" Then PictureBoxList(k).BackColor = Color.Lime
            If Status1 = "Занято" Then PictureBoxList(k).BackColor = Color.Red
            If Status1 = "Не заселять" Then PictureBoxList(k).BackColor = Color.White
            k = k + 1
        End While
        DataReader.Close()
        Connector.Close()
        Call LoadBooking()
    End Sub
    Sub LoadBooking()
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Бронирование.[Номер] FROM Бронирование;", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            If Label1.Text = DataReader.GetValue(0) And PictureBox1.BackColor <> Color.Red Then PictureBox1.BackColor = Color.Blue
            If Label2.Text = DataReader.GetValue(0) And PictureBox2.BackColor <> Color.Red Then PictureBox2.BackColor = Color.Blue
            If Label3.Text = DataReader.GetValue(0) And PictureBox3.BackColor <> Color.Red Then PictureBox3.BackColor = Color.Blue
            If Label4.Text = DataReader.GetValue(0) And PictureBox4.BackColor <> Color.Red Then PictureBox4.BackColor = Color.Blue
            If Label5.Text = DataReader.GetValue(0) And PictureBox5.BackColor <> Color.Red Then PictureBox5.BackColor = Color.Blue
            If Label6.Text = DataReader.GetValue(0) And PictureBox6.BackColor <> Color.Red Then PictureBox6.BackColor = Color.Blue
            If Label7.Text = DataReader.GetValue(0) And PictureBox7.BackColor <> Color.Red Then PictureBox7.BackColor = Color.Blue
            If Label8.Text = DataReader.GetValue(0) And PictureBox8.BackColor <> Color.Red Then PictureBox8.BackColor = Color.Blue
            If Label9.Text = DataReader.GetValue(0) And PictureBox9.BackColor <> Color.Red Then PictureBox9.BackColor = Color.Blue
            If Label10.Text = DataReader.GetValue(0) And PictureBox10.BackColor <> Color.Red Then PictureBox10.BackColor = Color.Blue
        End While
        DataReader.Close()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = "201"
        Label2.Text = "202"
        Label3.Text = "203"
        Label4.Text = "204"
        Label5.Text = "205"
        Label6.Text = "206"
        Label7.Text = "207"
        Label8.Text = "208"
        Label9.Text = "209"
        Label10.Text = "210"
        Call Status()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label1.Text = "301"
        Label2.Text = "302"
        Label3.Text = "303"
        Label4.Text = "304"
        Label5.Text = "305"
        Label6.Text = "306"
        Label7.Text = "307"
        Label8.Text = "308"
        Label9.Text = "309"
        Label10.Text = "310"
        Call Status()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Label1.Text = "401"
        Label2.Text = "402"
        Label3.Text = "403"
        Label4.Text = "404"
        Label5.Text = "405"
        Label6.Text = "406"
        Label7.Text = "407"
        Label8.Text = "408"
        Label9.Text = "409"
        Label10.Text = "410"
        Call Status()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label1.Text = "501"
        Label2.Text = "502"
        Label3.Text = "503"
        Label4.Text = "504"
        Label5.Text = "505"
        Label6.Text = "506"
        Label7.Text = "507"
        Label8.Text = "508"
        Label9.Text = "509"
        Label10.Text = "510"
        Call Status()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = "601"
        Label2.Text = "602"
        Label3.Text = "603"
        Label4.Text = "604"
        Label5.Text = "605"
        Label6.Text = "606"
        Label7.Text = "607"
        Label8.Text = "608"
        Label9.Text = "609"
        Label10.Text = "610"
        Call Status()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label1.Text = "701"
        Label2.Text = "702"
        Label3.Text = "703"
        Label4.Text = "704"
        Label5.Text = "705"
        Label6.Text = "706"
        Label7.Text = "707"
        Label8.Text = "708"
        Label9.Text = "709"
        Label10.Text = "710"
        Call Status()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label1.Text = "801"
        Label2.Text = "802"
        Label3.Text = "803"
        Label4.Text = "804"
        Label5.Text = "805"
        Label6.Text = "806"
        Label7.Text = "807"
        Label8.Text = "808"
        Label9.Text = "809"
        Label10.Text = "810"
        Call Status()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Label1.Text = "901"
        Label2.Text = "902"
        Label3.Text = "903"
        Label4.Text = "904"
        Label5.Text = "905"
        Label6.Text = "906"
        Label7.Text = "907"
        Label8.Text = "908"
        Label9.Text = "909"
        Label10.Text = "910"
        Call Status()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Label1.Text = "101"
        Label2.Text = "102"
        Label3.Text = "103"
        Label4.Text = "104"
        Label5.Text = "105"
        Label6.Text = "106"
        Label7.Text = "107"
        Label8.Text = "108"
        Label9.Text = "109"
        Label10.Text = "110"
        Call Status()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Sub ProverkaMaus()
        If PictureBoxList(Koordinati - 1).BackColor = Color.Blue Then СнятьБроньToolStripMenuItem.Visible = True Else СнятьБроньToolStripMenuItem.Visible = False
        If PictureBoxList(Koordinati - 1).BackColor = Color.Blue Then ПросмотретьСостояниеНомераToolStripMenuItem.Visible = False Else ПросмотретьСостояниеНомераToolStripMenuItem.Visible = True
        If PictureBoxList(Koordinati - 1).BackColor = Color.Red Then ОсвободитьНомерToolStripMenuItem.Visible = True Else ОсвободитьНомерToolStripMenuItem.Visible = False
        If PictureBoxList(Koordinati - 1).BackColor = Color.White Then ВвестиНомерВЭксплуатациюToolStripMenuItem.Visible = True Else ВвестиНомерВЭксплуатациюToolStripMenuItem.Visible = False
        If PictureBoxList(Koordinati - 1).BackColor = Color.Lime Then ПометитьНомерКакНеЗаселяемыйToolStripMenuItem.Visible = True Else ПометитьНомерКакНеЗаселяемыйToolStripMenuItem.Visible = False
        If PictureBoxList(Koordinati - 1).BackColor = Color.Red Then ЗаселитьНомерToolStripMenuItem.Visible = False Else ЗаселитьНомерToolStripMenuItem.Visible = True
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Koordinati = 1
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox2_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp
        Koordinati = 2
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox3_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseUp
        Koordinati = 3
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox4_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseUp
        Koordinati = 4
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox5_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox5.MouseUp
        Koordinati = 5
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox6_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseUp
        Koordinati = 6
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox7_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox7.MouseUp
        Koordinati = 7
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox8_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox8.MouseUp
        Koordinati = 8
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox9_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox9.MouseUp
        Koordinati = 9
        Call ProverkaMaus()
    End Sub

    Private Sub PictureBox10_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox10.MouseUp
        Koordinati = 10
        Call ProverkaMaus()
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Koordinati = 1
        Call ProverkaMaus()
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        Koordinati = 2
        Call ProverkaMaus()
    End Sub

    Private Sub Label3_MouseUp(sender As Object, e As MouseEventArgs) Handles Label3.MouseUp
        Koordinati = 3
        Call ProverkaMaus()
    End Sub

    Private Sub Label4_MouseUp(sender As Object, e As MouseEventArgs) Handles Label4.MouseUp
        Koordinati = 4
        Call ProverkaMaus()
    End Sub

    Private Sub Label5_MouseUp(sender As Object, e As MouseEventArgs) Handles Label5.MouseUp
        Koordinati = 5
        Call ProverkaMaus()
    End Sub

    Private Sub Label6_MouseUp(sender As Object, e As MouseEventArgs) Handles Label6.MouseUp
        Koordinati = 6
        Call ProverkaMaus()
    End Sub

    Private Sub Label7_MouseUp(sender As Object, e As MouseEventArgs) Handles Label7.MouseUp
        Koordinati = 7
        Call ProverkaMaus()
    End Sub

    Private Sub Label8_MouseUp(sender As Object, e As MouseEventArgs) Handles Label8.MouseUp
        Koordinati = 8
        Call ProverkaMaus()
    End Sub

    Private Sub Label9_MouseUp(sender As Object, e As MouseEventArgs) Handles Label9.MouseUp
        Koordinati = 9
        Call ProverkaMaus()
    End Sub

    Private Sub Label10_MouseUp(sender As Object, e As MouseEventArgs) Handles Label10.MouseUp
        Koordinati = 10
        Call ProverkaMaus()
    End Sub
    Sub Stage1()
        ZaprosNomera = Label1.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage2()
        ZaprosNomera = Label2.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage3()
        ZaprosNomera = Label3.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage4()
        ZaprosNomera = Label4.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage5()
        ZaprosNomera = Label5.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage6()
        ZaprosNomera = Label6.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage7()
        ZaprosNomera = Label7.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage8()
        ZaprosNomera = Label8.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage9()
        ZaprosNomera = Label9.Text
        InfoNomer.Close()
        InfoNomer.Show()

    End Sub
    Sub Stage10()
        ZaprosNomera = Label10.Text
        InfoNomer.Close()
        InfoNomer.Show()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick, Label1.DoubleClick
        Stage1()
    End Sub

    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick, Label2.DoubleClick
        Stage2()
    End Sub

    Private Sub PictureBox3_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick, Label3.DoubleClick
        Stage3()
    End Sub

    Private Sub PictureBox4_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox4.DoubleClick, Label4.DoubleClick
        Stage4()
    End Sub

    Private Sub PictureBox5_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox5.DoubleClick, Label5.DoubleClick
        Stage5()
    End Sub

    Private Sub PictureBox6_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox6.DoubleClick, Label6.DoubleClick
        Stage6()
    End Sub

    Private Sub PictureBox7_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox7.DoubleClick, Label7.DoubleClick
        Stage7()
    End Sub

    Private Sub PictureBox8_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox8.DoubleClick, Label8.DoubleClick
        Stage8()
    End Sub

    Private Sub PictureBox9_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox9.DoubleClick, Label9.DoubleClick
        Stage9()
    End Sub

    Private Sub PictureBox10_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox10.DoubleClick, Label10.DoubleClick
        Stage10()
    End Sub

    Private Sub ПросмотретьСостояниеНомераToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПросмотретьСостояниеНомераToolStripMenuItem.Click
        If Koordinati = 1 Then Stage1()
        If Koordinati = 2 Then Stage2()
        If Koordinati = 3 Then Stage3()
        If Koordinati = 4 Then Stage4()
        If Koordinati = 5 Then Stage5()
        If Koordinati = 6 Then Stage6()
        If Koordinati = 7 Then Stage7()
        If Koordinati = 8 Then Stage8()
        If Koordinati = 9 Then Stage9()
        If Koordinati = 10 Then Stage10()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If PictureBox1.BackColor = Color.Lime Then
            Label1.BackColor = Color.Lime
        ElseIf PictureBox1.BackColor = Color.Red Then
            Label1.BackColor = Color.Red
        Else
            Label1.BackColor = Color.White
        End If
        If PictureBox2.BackColor = Color.Lime Then
            Label2.BackColor = Color.Lime
        ElseIf PictureBox1.BackColor = Color.Red Then
            Label2.BackColor = Color.Red
        Else
            Label2.BackColor = Color.White
        End If
        If PictureBox3.BackColor = Color.Lime Then
            Label3.BackColor = Color.Lime
        ElseIf PictureBox1.BackColor = Color.Red Then
            Label3.BackColor = Color.Red
        Else
            Label3.BackColor = Color.White
        End If
        If PictureBox4.BackColor = Color.Lime Then
            Label4.BackColor = Color.Lime
        ElseIf PictureBox4.BackColor = Color.Red Then
            Label4.BackColor = Color.Red
        Else
            Label4.BackColor = Color.White
        End If
        If PictureBox5.BackColor = Color.Lime Then
            Label5.BackColor = Color.Lime
        ElseIf PictureBox5.BackColor = Color.Red Then
            Label5.BackColor = Color.Red
        Else
            Label5.BackColor = Color.White
        End If
        If PictureBox6.BackColor = Color.Lime Then
            Label6.BackColor = Color.Lime
        ElseIf PictureBox6.BackColor = Color.Red Then
            Label6.BackColor = Color.Red
        Else
            Label6.BackColor = Color.White
        End If
        If PictureBox7.BackColor = Color.Lime Then
            Label7.BackColor = Color.Lime
        ElseIf PictureBox7.BackColor = Color.Red Then
            Label7.BackColor = Color.Red
        Else
            Label7.BackColor = Color.White
        End If
        If PictureBox8.BackColor = Color.Lime Then
            Label8.BackColor = Color.Lime
        ElseIf PictureBox8.BackColor = Color.Red Then
            Label8.BackColor = Color.Red
        Else
            Label8.BackColor = Color.White
        End If
        If PictureBox9.BackColor = Color.Lime Then
            Label9.BackColor = Color.Lime
        ElseIf PictureBox9.BackColor = Color.Red Then
            Label9.BackColor = Color.Red
        Else
            Label9.BackColor = Color.White
        End If
        If PictureBox10.BackColor = Color.Lime Then
            Label10.BackColor = Color.Lime
        ElseIf PictureBox10.BackColor = Color.Red Then
            Label10.BackColor = Color.Red
        Else
            Label10.BackColor = Color.White
        End If

    End Sub

    Private Sub НомерПользуетсяДополнительнымиУслугамиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НомерПользуетсяДополнительнымиУслугамиToolStripMenuItem.Click
        Service.Close()
        Service.Text = "Статус услуги"
        Service.Show()
    End Sub

    Private Sub ВвестиНомерВЭксплуатациюToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВвестиНомерВЭксплуатациюToolStripMenuItem.Click
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Статус] = 'Свободен' WHERE ([Номер] Like '" & LabelList(Koordinati - 1).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Status()
    End Sub

    Private Sub ПометитьНомерКакНеЗаселяемыйToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПометитьНомерКакНеЗаселяемыйToolStripMenuItem.Click
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Статус] = 'Не заселять' WHERE ([Номер] Like '" & LabelList(Koordinati - 1).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Status()
    End Sub

    Private Sub СоздатьБроньНомераToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СоздатьБроньНомераToolStripMenuItem.Click
        If PictureBoxList(Koordinati - 1).BackColor = Color.Blue Then
            Dim MBox As DialogResult = MessageBox.Show("Текущий номер был забронирован ранее, для перебронирования нужно снять бронь!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Call Loca()
            Booking.Close()
            Booking.Text = "Бронирование номера"
            Booking.Show()
        End If
    End Sub
    Sub Loca()
        If Koordinati = 1 Then NomerClear = Label1.Text
        If Koordinati = 2 Then NomerClear = Label2.Text
        If Koordinati = 3 Then NomerClear = Label3.Text
        If Koordinati = 4 Then NomerClear = Label4.Text
        If Koordinati = 5 Then NomerClear = Label5.Text
        If Koordinati = 6 Then NomerClear = Label6.Text
        If Koordinati = 7 Then NomerClear = Label7.Text
        If Koordinati = 8 Then NomerClear = Label8.Text
        If Koordinati = 9 Then NomerClear = Label9.Text
        If Koordinati = 10 Then NomerClear = Label10.Text
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub

    Private Sub СтатусБрониToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СтатусБрониToolStripMenuItem.Click
        Call Loca()
        Booking.Close()
        Booking.Text = "Статус бронирования"
        Booking.Show()
    End Sub

    Private Sub ОтметитьВНомереТехническуюНеисправностьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОтметитьВНомереТехническуюНеисправностьToolStripMenuItem.Click
        Call Loca()
        Help.Close()
        Help.Text = "Сделать отметку о техническое не исправности"
        Help.Show()
    End Sub

    Private Sub СнятьБроньToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СнятьБроньToolStripMenuItem.Click
        Dim Command As New OleDbCommand("DELETE FROM [Бронирование] WHERE ([Номер] Like '" & LabelList(Koordinati - 1).Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Status()
    End Sub

    Private Sub ЗаселитьНомерToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗаселитьНомерToolStripMenuItem.Click
        If PictureBoxList(Koordinati - 1).BackColor = Color.Red Then
            MsgBox("Данный номер заселен", 48 + 0, "Уведомление")
            Exit Sub
        Else
            If PictureBoxList(Koordinati - 1).BackColor = Color.White Then
                MsgBox("Данный номер отмечен как не жилой", 48 + 0, "Уведомление")
                Exit Sub
            Else
                If PictureBoxList(Koordinati - 1).BackColor = Color.Blue Then
                    Dim MBox As DialogResult = MessageBox.Show("Заселить забронированный номер???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If MBox = DialogResult.No Then Exit Sub
                    If MBox = DialogResult.Yes Then
                        Zaselenie.Close()
                        Zaselenie.Text = "Заселение гостя"
                        Zaselenie.Show()
                    End If
                Else
                    Zaselenie.Close()
                    Zaselenie.Text = "Заселение гостя"
                    Zaselenie.label1.Text = "Заселение гостя"
                    Zaselenie.Show()
                End If
            End If
        End If
    End Sub

    Sub HelpService()
        MDI1.ToolStripProgressBar1.Value = 100
        Dim Command As New OleDbCommand("Insert Into [Неисправность номера] ([Дата отметки], [Номер], [Неисправность]) values ('" & DateString & "', '" & NomerClear & "', '" & HelpAdd & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call ArchiveHelpService()
    End Sub
    Sub ArchiveHelpService()
        Dim Command As New OleDbCommand("Insert Into [Архив неисправность номера] ([Дата отметки], [Номер], [Неисправность]) values ('" & DateString & "', '" & NomerClear & "', '" & HelpAdd & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub
    Sub BookingProcess()
        Dim Command As New OleDbCommand("Insert Into [Бронирование] ([Номер], [Дата до ], [Время до], [Текущая дата], [На кого], [Примечание]) values ('" & BookingNomer & "', '" & BookingDataDo & "', '" & BookingTimeDo & "', '" & BookingCurrenData & "', '" & BookingWho & "', '" & BookingNote & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call ArchivBookingProcess()
    End Sub
    Sub ArchivBookingProcess()
        MDI1.ToolStripProgressBar1.Value = 100
        Dim Command As New OleDbCommand("Insert Into [Бронирование] ([Номер], [Дата до ], [Время до], [Текущая дата], [На кого], [Примечание]) values ('" & BookingNomer & "', '" & BookingDataDo & "', '" & BookingTimeDo & "', '" & BookingCurrenData & "', '" & BookingWho & "', '" & BookingNote & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Status()
    End Sub
    Sub FreeInfo()
        MDI1.ToolStripProgressBar1.Value = 0
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Заселение.[Номер комнаты], [Клиенты]![Фамилия] & ' ' & [Клиенты]![Имя] & ' ' & [Клиенты]![Отчество] AS FIO FROM Клиенты INNER JOIN Заселение ON Клиенты.[Код клиента] = Заселение.[Код гостя] WHERE (((Заселение.[Номер комнаты])=" & NomerClear & "));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            FIOClear = DataReader.GetValue(1)
        End While
        DataReader.Close()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub

    Sub FreeCopy()
        MDI1.ToolStripProgressBar1.Value = 0
        Dim a As String = InputBox("Введите комментарий о данном выселении или о проживании при необходимости")
        If a = "" Then a = "-"
        Dim Command As New OleDbCommand("Insert Into [Архив заселения] ([Номер], [Проживал], [Коментарий]) values ('" & NomerClear & "', '" & FIOClear & "', '" & a & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub
    Sub FreeDel()
        MDI1.ToolStripProgressBar1.Value = 0
        Dim Command As New OleDbCommand("DELETE FROM [Заселение] WHERE ([Номер комнаты] Like '" & NomerClear & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub
    Sub FreeOpen()
        MDI1.ToolStripProgressBar1.Value = 0
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Статус] = 'Свободен' WHERE ([Номер] Like '" & NomerClear & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub
    Sub UslugiDelAll()
        MDI1.ToolStripProgressBar1.Value = 0
        Dim Command As New OleDbCommand("DELETE [Текущие услуги].[Номер], [Текущие услуги].[Дата], [Текущие услуги].[Услуга] FROM [Текущие услуги]  WHERE ([Текущие услуги].[Номер]= " & NomerClear & ")", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MDI1.ToolStripProgressBar1.Value = 100
    End Sub

    Private Sub ОсвободитьНомерToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОсвободитьНомерToolStripMenuItem.Click
        Dim MBox As DialogResult = MessageBox.Show("Освободить номер???", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If MBox = DialogResult.No Then Exit Sub
        If MBox = DialogResult.Yes Then
            Call Loca()
            Call FreeInfo()
            Call FreeCopy()
            Call FreeDel()
            Call FreeOpen()
            Call UslugiDelAll()
            Call Status()
        End If
    End Sub
End Class