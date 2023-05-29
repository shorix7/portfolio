Imports System.Data.OleDb
Public Class Zaselenie
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InfoKlient.Close()
        InfoKlient.Text = "Заселение гостя"
        InfoKlient.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Width < 850 Then
            Width = Width + 10
        Else
            Button1.Location = New Point(780, 58)
            TextBox2.Visible = True
            TextBox3.Visible = True
            TextBox4.Visible = True
            Button2.Visible = True
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Zaselenie_Load(sender As Object, e As EventArgs) Handles Me.Load
        MdiParent = MDI1
        Width = 300
        Button1.Location = New Point(200, 58)
        If Koordinati = 1 Then TextBox1.Text = F2.Label1.Text
        If Koordinati = 2 Then TextBox1.Text = F2.Label2.Text
        If Koordinati = 3 Then TextBox1.Text = F2.Label3.Text
        If Koordinati = 4 Then TextBox1.Text = F2.Label4.Text
        If Koordinati = 5 Then TextBox1.Text = F2.Label5.Text
        If Koordinati = 6 Then TextBox1.Text = F2.Label6.Text
        If Koordinati = 7 Then TextBox1.Text = F2.Label7.Text
        If Koordinati = 8 Then TextBox1.Text = F2.Label8.Text
        If Koordinati = 9 Then TextBox1.Text = F2.Label9.Text
        If Koordinati = 10 Then TextBox1.Text = F2.Label10.Text


    End Sub
    Sub Prime()
        TextBox2.Text = InfoKlientAdd1
        TextBox3.Text = InfoKlientAdd2
        TextBox4.Text = InfoKlientAdd3
        Timer1.Enabled = True
    End Sub
    Sub NomerZap()
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Статус] = 'Занято' WHERE ([Номер] Like '" & TextBox1.Text & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        Call Registration()
    End Sub
    Sub Registration()
        Dim Command As New OleDbCommand("Insert Into [Заселение] ([Код гостя], [Номер комнаты]) values ('" & InfoKlientAdd4 & "', '" & TextBox1.Text & "') ", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
        MessageBox.Show("Заселение произведено!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call F2.Status()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ProverkaCout As Integer = 0
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Count([Заселение]![Код гостя]) AS Выражение1 FROM Заселение WHERE ((Заселение.[Код гостя])=" & InfoKlientAdd4 & ");", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read = True
            ProverkaCout = DataReader.GetValue(0)
        End While
        DataReader.Close()
        Connector.Close()
        If ProverkaCout > 0 Then
            MessageBox.Show("Текущий гость проижвает, более подробную информацию можно посмотреть в справочнике Клиенты", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Call NomerZap()
        End If
    End Sub

End Class