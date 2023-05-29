Public Class frmAudioVideo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With OpenFileDialog1
            .FileName = ""
            .Title = "Mедиа-файл"
            .Filter = "Видеофайлы mp4|*.avi|Аудиофайлы MP3|*.mp3|All Files|*.*"
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            If CheckBox1.Checked = True Then
                ListBox1.Items.Add(OpenFileDialog1.FileName)
                ListBox1.SelectedIndex = 0
            Else
                ListBox1.Items.Add(OpenFileDialog1.FileName)
            End If

        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If CheckBox1.Checked = True Then
            AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
        End If
    End Sub

    Sub Check()
        If CheckBox1.Checked = True Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Check()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Enabled = True
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            CheckBox2.Checked = False
            CheckBox2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = ""
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        ListBox1.SelectedItem = 0
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        AxWindowsMediaPlayer1.currentPlaylist.clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub AxWindowsMediaPlayer1_StatusChange(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.StatusChange
        Try
            If AxWindowsMediaPlayer1.playState = 8 Then
                ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
                AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
                AxWindowsMediaPlayer1.Ctlcontrols.play()
            End If
        Catch ex As Exception
            MessageBox.Show("Конец плейлиста", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AxWindowsMediaPlayer1.URL = ""
        End Try
    End Sub
    Private Sub VideoPlayListAdd_Button_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        ToolTip1.Show("Данная кнопка добавляет видео/аудио в список воспроизведения", Button1)
    End Sub
    Private Sub VideoPlayListDel_Button_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        ToolTip1.Show("Данная кнопка удаляет выделенное видео/аудио из списка воспроизведения", Button2)
    End Sub
    Private Sub VideoPlayListClear_Button_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        ToolTip1.Show("Данная кнопка очищает список", Button3)
    End Sub
    Private Sub Exit_Button_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        ToolTip1.Show("Закрытие окна", Button4)
    End Sub
End Class