Imports System.ComponentModel
Public Class Form1
    Public SERVER As Server

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SERVER = New Server(13000, "7ИС", AscW("+"))
        AddHandler SERVER.OnRead, AddressOf Me.OnRead
        AddHandler SERVER.Connect, AddressOf Me.Connect
        AddHandler SERVER.Disconnect, AddressOf Me.Disconnect
        AddHandler SERVER.Message, AddressOf Me.msg
        SERVER.start()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SERVER.Stop_Server()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub Button3_Click(byval client As Object, e As EventArgs) Handles Button3.Click
        SERVER.SendAll(TextBox2.Text & ";")
        msg("Клиент №1 " & TextBox2.Text)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        SERVER.Stop_Server()
    End Sub
    Public Sub Connect(ByVal client As Server.handleClient)
        msg("Клиент №" & client.Number & " подключен." & " IP:" & client.IP)
    End Sub
    Public Sub Disconnect(ByVal client As Server.handleClient, ByVal reson As String)
        msg("Клиент №" & client.Number & " отключен." & " Причина:" & reson)
    End Sub
    Public Sub OnRead(ByVal client As Server.handleClient, ByVal data As String)
        msg("Клиент №" & client.Number & " : " & data)
        If data = "PING TEST;" Then
            SERVER.SendUser(client, data)
        Else
        End If
    End Sub
    Public Sub msg(ByVal t As String)
        Try
            If IsHandleCreated Then Invoke(New Server.StatusInvoker(AddressOf UpdateStatus), t)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub UpdateStatus(ByVal t As String)
        Try
            TextBox1.AppendText(vbCrLf & Now & " >> " + t)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Me
            .Size = New Size(641, 417)
            .Text = "Сервер"
        End With
        With TextBox1
            .Multiline = True
            .ForeColor = Color.Lime
            .BackColor = Color.Black
            .Location = New Point(12, 12)
            .Anchor = 15
            .Size = New Size(601, 300)
        End With
        With TextBox2
            .Location = New Point(174, 318)
            .Anchor = 14
            .Size = New Size(439, 20)
        End With
        With Button1
            .Size = New Size(75, 49)
            .Location = New Point(12, 318)
            .Text = "Пуск сервера"
            .Anchor = 6
        End With
        With Button2
            .Size = New Size(75, 49)
            .Location = New Point(93, 318)
            .Text = "Стоп сервер"
            .Anchor = 6
            .Enabled = False
        End With
        With Button3
            .Size = New Size(114, 23)
            .Location = New Point(499, 344)
            .Text = "Отправить всем"
            .Anchor = 10
            .Enabled = False
        End With

    End Sub
End Class
