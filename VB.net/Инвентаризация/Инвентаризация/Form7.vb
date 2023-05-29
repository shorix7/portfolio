Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Программа 'Инвентаризация' " & vbCrLf & "Версия 0.1.1" & vbCrLf & "Выполненная на <Microsoft Visual Studio> - Версии 4.8.04" & vbCrLf & vbCrLf &
            "Студентом группы 7ИС :" & vbCrLf & vbCrLf & "© Западный филлиал РАНХиГС . Артилирийская.18" & vbCrLf & vbCrLf & "Работа написана по методичке преподавателя IT'сферы :" & vbCrLf & "Черкасов Владимир Игоревич"
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form8.Show()
    End Sub
End Class