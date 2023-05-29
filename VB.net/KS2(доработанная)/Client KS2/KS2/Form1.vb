Imports System.ComponentModel

Public Class Form1
    Public CLIENT As Class_Client
    Dim st As New Stopwatch

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        CLIENT.Disconnect()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Me
            .Size = New Size(641, 417)
            .Text = "Клиент"
        End With
        With TextBox1
            .Multiline = True
            .ForeColor = Color.PaleTurquoise
            .BackColor = Color.Black
            .Location = New Point(12, 12)
            .Anchor = 15
            .Size = New Size(601, 300)
        End With
        With TextBox2
            .Location = New Point(12, 347)
            .Anchor = 14
            .Size = New Size(520, 20)
        End With
        With TextBox3
            .Location = New Point(12, 321)
            .Anchor = 6
            .Size = New Size(134, 20)
        End With
        With Button1
            .Location = New Point(152, 318)
            .Anchor = 6
            .Size = New Size(93, 23)
            .Text = "Подключиться"
        End With
        With Button2
            .Location = New Point(251, 318)
            .Anchor = 6
            .Size = New Size(93, 23)
            .Text = "Отключиться"
            .Enabled = False
        End With
        With Button3
            .Location = New Point(538, 344)
            .Anchor = 10
            .Size = New Size(80, 23)
            .Text = "Отправить"
            .Enabled = False
        End With
        With Button4
            .Location = New Point(538, 315)
            .Anchor = 10
            .Size = New Size(80, 23)
            .Text = "Пинг"
            .Enabled = False
        End With
        CLIENT = New Class_Client
    End Sub
    Private Sub Disconnect(ByVal reson As String)
        msg("Подключение разорвано: " & reson)
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub
    Private Sub Disconnect_Invoke(ByVal t As String)
        Try
            If IsHandleCreated Then Invoke(New Class_Client.StatusInvoker(AddressOf Disconnect), t)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub msg(ByVal t As String)
        TextBox1.AppendText(vbCrLf & Now & " >> " + t)
    End Sub
    Private Sub MSG_Invoke(ByVal t As String)
        Try
            If IsHandleCreated Then Invoke(New Class_Client.StatusInvoker(AddressOf msg), t)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnRead(ByVal Data As String)
        Dim d() As String
        d = Split(Data, ";")
        For x = 0 To d.Length - 1
            If d(x) <> "" Then
                If Mid(d(x), 1, 9) = "PING TEST" Then
                    st.Stop()
                    msg("Пинг: " & st.ElapsedMilliseconds)
 Else
                    msg("Сервер: " & d(x))
                End If
            End If
        Next
    End Sub
    Private Sub OnRead_Invoke(ByVal t As String)
        Try
            If IsHandleCreated Then Invoke(New Class_Client.StatusInvoker(AddressOf OnRead), t)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CLIENT = New Class_Client
        AddHandler CLIENT.OnRead, AddressOf OnRead_Invoke
        AddHandler CLIENT.Disconnected, AddressOf Disconnect_Invoke
        AddHandler CLIENT.Message, AddressOf MSG_Invoke
        If CLIENT.Connect(TextBox3.Text, 13000, AscW("+")) Then
            msg("Подключение установлено!")
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
        Else
            msg("Не удалось установить подключение!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CLIENT.Disconnect()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CLIENT.Send(TextBox2.Text & ";") Then msg("Клиент: " & TextBox2.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        st.Reset()
        st.Start()
        CLIENT.Send("PING TEST;")
    End Sub
End Class