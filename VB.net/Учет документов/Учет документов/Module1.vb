Module Module1
    Public SettingsGurnal As String
    Public SettingsOprPolzovatelya As String
    Public SettingsObnovlenie As String
    Public SettingsIP As String
    Public SettingsArchivirovanie As String
    Public SettingsVostanovlenieRezervnoiKopii As String
    Public SettingsOtkatBD As String
    Public SettingsAutoObnovlenie As String
    Public OtchetGurnal As String
    Public DataBaseFileName As String = Application.StartupPath & "\bd.mdb"
    Public Connector As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DataBaseFileName)


    Public PravaPolzovatelyaKod As String
    Public PravaPolzovatelyaFamiliya As String
    Public PravaPolzovatelyaImya As String
    Public PravaPolzovatelyaOtchestvo As String
    Public PravaPolzovatelyaPrava As String = "Пользователь"
    Public PravaPolzovatelyaPassword As String


    Public CountForm1 As String
    Public CountForm2 As String
    Public CountForm3 As String
    Public CountForm4 As String
    Public CountForm5 As String
    Public CountForm6 As String
    Public CountForm7 As String
    Public CountForm8 As String
    Public CountForm9 As String
    Public CountForm10 As String
    Public CountFormKontrol As String

    Public p1 As String
    Public p2 As String
    Public p3 As String
    Public p4 As String
    Public p5 As String
    Public p6 As String
    Public p7 As String
    Public p8 As String
    Public p9 As String
    Public p10 As String
    Public p11 As String
    Public p12 As String

    Public lvwColumnSorter As ListViewColumnSorter

    Public Sub Prava()
        If PravaPolzovatelyaPrava = "Администратор" Then
            MDIParent1.АрхивированиеБДToolStripMenuItem.Enabled = True
            MDIParent1.ВосстановлениеВИсToolStripMenuItem.Enabled = True
            MDIParent1.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Enabled = True
            MDIParent1.ПоставитьНаКонтрольToolStripMenuItem.Enabled = True
            MDIParent1.НастройкиToolStripMenuItem.Enabled = True
            MDIParent1.ЖурналСобытийToolStripMenuItem.Enabled = True
            Form1.ToolStripButton1.Enabled = True
            Form1.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form1.ПолучитьКарточкуToolStripMenuItem.Enabled = True
            Form1.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form1.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form1.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form2.Button1.Enabled = True
            Form3.ToolStripButton1.Enabled = True
            Form3.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form3.ПолучитьКарточкуToolStripMenuItem.Enabled = True
            Form3.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form3.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form3.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form4.Button1.Enabled = True
            Form5.ToolStripButton1.Enabled = True
            Form5.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form5.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form5.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form5.ЭкспортWordToolStripMenuItem.Enabled = True
            Form6.Button1.Enabled = True
            Form7.ToolStripButton1.Enabled = True
            Form7.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form7.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form7.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form7.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form8.Button1.Enabled = True
            Form9.ToolStripButton1.Enabled = True
            Form9.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form9.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form9.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form9.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form10.Button1.Enabled = True
            Form11.ToolStripButton1.Enabled = True
            Form11.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form11.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form11.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form11.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form12.Button1.Enabled = True
            Form13.ToolStripButton1.Enabled = True
            Form13.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form13.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form13.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form13.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form14.Button1.Enabled = True
            Form15.ToolStripButton1.Enabled = True
            Form15.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form15.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form15.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form15.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form16.Button1.Enabled = True
            Form17.ToolStripButton1.Enabled = True
            Form17.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form17.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form17.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form17.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form18.Button1.Enabled = True
            Form19.ToolStripButton1.Enabled = True
            Form19.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form19.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form19.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form19.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form20.Button1.Enabled = True
            Master.Button1.Enabled = True
        End If
        If PravaPolzovatelyaPrava = "Пользователь" Then
            If SettingsArchivirovanie = "Да" Then
                MDIParent1.АрхивированиеБДToolStripMenuItem.Enabled = True
            Else

                MDIParent1.АрхивированиеБДToolStripMenuItem.Enabled = False
            End If
            If SettingsOtkatBD = "Да" Then
                MDIParent1.ВосстановлениеВИсToolStripMenuItem.Enabled = True
            Else

                MDIParent1.ВосстановлениеВИсToolStripMenuItem.Enabled = False
            End If
            If SettingsVostanovlenieRezervnoiKopii = "Да" Then
                MDIParent1.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Enabled = True
            Else

                MDIParent1.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Enabled = False
            End If
            MDIParent1.ПоставитьНаКонтрольToolStripMenuItem.Enabled = False
            MDIParent1.НастройкиToolStripMenuItem.Enabled = False
            MDIParent1.ЖурналСобытийToolStripMenuItem.Enabled = False
            Form1.ToolStripButton1.Enabled = True
            Form1.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form1.ПолучитьКарточкуToolStripMenuItem.Enabled = True
            Form1.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form1.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form1.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form2.Button1.Enabled = True
            Form3.ToolStripButton1.Enabled = True
            Form3.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form3.ПолучитьКарточкуToolStripMenuItem.Enabled = True
            Form3.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form3.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form3.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form4.Button1.Enabled = True
            Form5.ToolStripButton1.Enabled = True
            Form5.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form5.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form5.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form5.ЭкспортWordToolStripMenuItem.Enabled = True
            Form6.Button1.Enabled = True
            Form7.ToolStripButton1.Enabled = True
            Form7.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form7.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form7.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form7.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form8.Button1.Enabled = True
            Form9.ToolStripButton1.Enabled = True
            Form9.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form9.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form9.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form9.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form10.Button1.Enabled = True
            Form11.ToolStripButton1.Enabled = True
            Form11.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form11.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form11.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form11.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form12.Button1.Enabled = True
            Form13.ToolStripButton1.Enabled = True
            Form13.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form13.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form13.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form13.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form14.Button1.Enabled = True
            Form15.ToolStripButton1.Enabled = True
            Form15.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form15.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form15.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form15.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form16.Button1.Enabled = True
            Form17.ToolStripButton1.Enabled = True
            Form17.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form17.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form17.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form17.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form18.Button1.Enabled = True
            Form19.ToolStripButton1.Enabled = True
            Form19.УдалитьЗаписьToolStripMenuItem.Enabled = True
            Form19.ДобавитьЗаписьToolStripMenuItem.Enabled = True
            Form19.ЭкспортExcelToolStripMenuItem.Enabled = True
            Form19.ЭкспортWORDToolStripMenuItem.Enabled = True
            Form20.Button1.Enabled = True
            Master.Button1.Enabled = True
        End If
        If PravaPolzovatelyaPrava = "Гость" Then
            MDIParent1.ЖурналСобытийToolStripMenuItem.Enabled = False
            MDIParent1.АрхивированиеБДToolStripMenuItem.Enabled = False
            MDIParent1.ВосстановлениеВИсToolStripMenuItem.Enabled = False
            MDIParent1.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Enabled = False
            MDIParent1.ПоставитьНаКонтрольToolStripMenuItem.Enabled = False
            MDIParent1.НастройкиToolStripMenuItem.Enabled = False
            Form1.ToolStripButton1.Enabled = False
            Form1.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form1.ПолучитьКарточкуToolStripMenuItem.Enabled = False
            Form1.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form1.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form1.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form2.Button1.Enabled = False
            Form3.ToolStripButton1.Enabled = False
            Form3.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form3.ПолучитьКарточкуToolStripMenuItem.Enabled = False
            Form3.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form3.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form3.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form4.Button1.Enabled = False
            Form5.ToolStripButton1.Enabled = False
            Form5.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form5.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form5.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form5.ЭкспортWordToolStripMenuItem.Enabled = False
            Form6.Button1.Enabled = False
            Form7.ToolStripButton1.Enabled = False
            Form7.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form7.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form7.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form7.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form8.Button1.Enabled = False
            Form9.ToolStripButton1.Enabled = False
            Form9.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form9.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form9.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form9.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form10.Button1.Enabled = False
            Form11.ToolStripButton1.Enabled = False
            Form11.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form11.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form11.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form11.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form12.Button1.Enabled = False
            Form13.ToolStripButton1.Enabled = False
            Form13.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form13.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form13.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form13.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form14.Button1.Enabled = False
            Form15.ToolStripButton1.Enabled = False
            Form15.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form15.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form15.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form15.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form16.Button1.Enabled = False
            Form17.ToolStripButton1.Enabled = False
            Form17.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form17.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form17.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form17.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form18.Button1.Enabled = False
            Form19.ToolStripButton1.Enabled = False
            Form19.УдалитьЗаписьToolStripMenuItem.Enabled = False
            Form19.ДобавитьЗаписьToolStripMenuItem.Enabled = False
            Form19.ЭкспортExcelToolStripMenuItem.Enabled = False
            Form19.ЭкспортWORDToolStripMenuItem.Enabled = False
            Form20.Button1.Enabled = False
            Master.Button1.Enabled = False
        End If
        OtchetGurnal = "Получение прав в программе " & DateString & " " & TimeString : ZapGurnal()
    End Sub
End Module
