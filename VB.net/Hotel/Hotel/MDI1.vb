Imports System.Data.OleDb
Public Class MDI1
    Private Sub MDI1_Load(sender As Object, e As EventArgs) Handles Me.Load, Timer2.Tick
        ToolStripStatusLabel2.Text = Now.ToLongDateString
        ToolStripStatusLabel4.Text = Now.ToLongTimeString

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub КаскадомToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles КаскадомToolStripMenuItem.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub СтрокаСостоянияToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СтрокаСостоянияToolStripMenuItem.Click
        StatusStrip1.Visible = СтрокаСостоянияToolStripMenuItem.Checked
    End Sub

    Private Sub СлеваНаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СлеваНаToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub СверхуToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СверхуToolStripMenuItem.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ЗакрытьВсеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗакрытьВсеToolStripMenuItem.Click
        For Each ChildForm As Form In MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Value = 100
    End Sub

    Private Sub НомераToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НомераToolStripMenuItem.Click
        F2.Close()
        F2.Show()
    End Sub

    Private Sub КлиентыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles КлиентыToolStripMenuItem.Click
        InfoKlient.Close()
        InfoKlient.Show()
    End Sub

    Private Sub ЧерныйСписокToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЧерныйСписокToolStripMenuItem.Click
        BlackList.Close()
        BlackList.Show()
    End Sub

    Private Sub ШахматкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ШахматкаToolStripMenuItem.Click
        Checkerboard.Close()
        Checkerboard.Text = "График занятости мест в отеле"
        Checkerboard.Show()
    End Sub

    Private Sub АвторизоватьсяToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles АвторизоватьсяToolStripMenuItem.Click
        Try
            Dim Proverka As String = InputBox("Введите пароль для авторизации пользователя", "Запрос на авторизацию")
            If Proverka = "" Then
                Exit Sub
            Else
                Dim DataReader As OleDbDataReader
                Dim Command As New OleDbCommand("SELECT Пользователи.[Код], Пользователи.[Фамилия], Пользователи.[Имя], Пользователи.[Отчество], Пользователи.[Права], Пользователи.[Пароль] FROM Пользователи WHERE (((Пользователи.[Пароль])='" & Proverka & "'));", Connector)
                Connector.Open()
                DataReader = Command.ExecuteReader
                While DataReader.Read = True
                    PravaPolzovatelyaKod = DataReader.GetValue(0)
                    PravaPolzovatelyaFamiliya = DataReader.GetValue(1)
                    PravaPolzovatelyaImya = DataReader.GetValue(2)
                    PravaPolzovatelyaOtchestvo = DataReader.GetValue(3)
                    PravaPolzovatelyaPrava = DataReader.GetValue(4)
                    PravaPolzovatelyaPassword = DataReader.GetValue(5)
                End While
                If PravaPolzovatelyaKod = "" Then MessageBox.Show("Авторизация не удалась!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If PravaPolzovatelyaKod <> "" Then ToolStripStatusLabel5.Text = "Авторизован: " & PravaPolzovatelyaFamiliya & " " & PravaPolzovatelyaImya & " " & PravaPolzovatelyaOtchestvo
                DataReader.Close()
                Connector.Close()
            End If
        Catch ex As Exception
            Connector.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class