Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Module ModuleGurnal
    Public Sub ZapPolzovatel()
        Dim User = System.Security.Principal.WindowsIdentity.GetCurrent.User
        Dim UserName = User.Translate(GetType(System.Security.Principal.NTAccount)).Value
        OtchetGurnal = OtchetGurnal & ", Зарегистрированный пользователь:" & UserName
    End Sub
    Public Sub AvtorizovanPolzovatel()
        OtchetGurnal = OtchetGurnal & ", Авторизован: " & PravaPolzovatelyaFamiliya & " " & PravaPolzovatelyaImya & " " & PravaPolzovatelyaOtchestvo
    End Sub
    Public Sub ZapIP()
        Dim IPadres As String =
        System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName).GetValue(2).ToString
        OtchetGurnal = OtchetGurnal & ", IP: " & IPadres
    End Sub
    Public Sub ZapGurnal()
        Try
            If PravaPolzovatelyaKod <> "" Then
                AvtorizovanPolzovatel()
            End If
            If SettingsOprPolzovatelya = "Да" Then
                ZapPolzovatel()
            End If
            If SettingsIP = "Да" Then
                ZapIP()
            End If
            If SettingsGurnal = "Да" Then
                Dim Command As New OleDbCommand("Insert into [Журнал] ([Запись]) values ('" & OtchetGurnal & "')", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Module
