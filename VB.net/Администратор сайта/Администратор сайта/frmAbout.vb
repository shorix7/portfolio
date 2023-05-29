Public Class frmAbout
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = "Данную программу написал студент группы 7ИС " & vbCrLf & "Суворов Дмитрий Витальеивич. " & vbCrLf & "По методическим рекомендациям преподавателя " & vbCrLf & "Мотолянца Александра Николаевича." & vbCrLf & "Программа имеет удобный и легкий интерфейс, так как она имеет все необходимое для этого." & vbCrLf & "Язык, который использовался для написания программы - Visual Basic."
    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub HelpButton_Click()
        If HelpButton Then

        End If
    End Sub
End Class