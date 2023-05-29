Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class Form1
    Sub dobavlenie_zap()
        lvwColumnSorter = New ListViewColumnSorter
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        Try
            Dim command As New OleDbCommand("INSERT INTO Исходящая ([Регистрационный номер], [Дата], [Адресат документа], [Заголовок (краткое содержание документа)], [Количество листов с приложением], [Исполнитель], [Куда помещен документ (№ дела)], [Отметка об исполнении], [Примечание]) values ('" & p1 & "', '" & p2 & "', '" & p3 & "', '" & p4 & "', '" & p5 & "', '" & p6 & "', '" & p7 & "', '" & p8 & "', '" & p9 & "')", Connector)
            Connector.Open()
            command.ExecuteNonQuery()
            Connector.Close()
            ListView1.Items.Add("[Регистрационный номер]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Дата")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Адресат документа]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Заголовок (краткое содержание документа)]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Количество лиcтов с приложением]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Исполнитель")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Куда помещен документ (№ дела)]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Отметка об исполнении]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("Примечание")
            Form1_Load(Me, New EventArgs)
            For Each columnheader In Me.ListView1.Columns
                columnheader.width = -3
            Next
            OtchetGurnal = "Добавление записи в исходящие " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MsgBox(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
    Sub Editor_zap()
        Try
            Dim Command As New OleDbCommand("UPDATE [Исходящая] SET [Регистрационный номер]='" & p1 & "', [Дата] ='" & p2 & "', [Адресат документа]='" & p3 & "', [Заголовок (краткое содержание документа)]='" & p4 & "', [Количество листов с приложением]='" & p5 & "', [Исполнитель]='" & p6 & "', [Куда помещен документ (№ дела)]='" & p7 & "', [Отметка об исполнении]='" & p8 & "', [Примечание]='" & p9 & "' WHERE ([Регистрационный номер] Like '" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
            ListView1.SelectedItems.Item(0).Text = p1
            ListView1.SelectedItems.Item(0).SubItems.Item(1).Text = p2
            ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = p3
            ListView1.SelectedItems.Item(0).SubItems.Item(3).Text = p4
            ListView1.SelectedItems.Item(0).SubItems.Item(4).Text = p5
            ListView1.SelectedItems.Item(0).SubItems.Item(5).Text = p6
            ListView1.SelectedItems.Item(0).SubItems.Item(6).Text = p7
            ListView1.SelectedItems.Item(0).SubItems.Item(7).Text = p8
            ListView1.SelectedItems.Item(0).SubItems.Item(8).Text = p9
            Form1_Load(Me, New EventArgs)
            OtchetGurnal = "Редактирование записи в исходящих " & DateString & TimeString : ZapGurnal()
        Catch ex As Exception
            Connector.Close()
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Sub Удалить()
        Dim MBox As DialogResult = MessageBox.Show("Удалить текущую запись", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim Command As New OleDbCommand("DELETE FROM [Исходящая] WHERE [Регистрационный номер] ='" & ListView1.SelectedItems.Item(0).Text & "'", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                ListView1.SelectedItems.Item(0).Remove()
                Form1_Load(Me, New EventArgs)
                MessageBox.Show("Запись была успешна удалена из БД", "Операция успешно завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            OtchetGurnal = "Удаление записи в исходящих " & DateString & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        OtchetGurnal = "Закрыта книга исходящие " & DateString & TimeString : ZapGurnal()
        Close()
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        Form1_Load(Me, New EventArgs)
        OtchetGurnal = "Обновление книги исходящие " & DateString & TimeString : ZapGurnal()
    End Sub

    Private Sub ЭкспортWORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортWORDToolStripMenuItem.Click
        Try
            Dim Дата As String = Format(Now, "d MMMM уууу")
            Dim W = New Word.Application
            W.Visible = True
            W.Documents.Add()
            W.Selection.TypeText("Выписка из БД: " & Дата & Chr(13) & Chr(10))
            For i As Short = 0 To ListView1.Items.Count - 1
                W.Selection.TypeText(ListView1.Items(i).SubItems.Item(0).Text & " " & ListView1.Items(i).SubItems.Item(1).Text & " " & ListView1.Items(i).SubItems.Item(2).Text & " " & ListView1.Items(i).SubItems.Item(3).Text & " " & ListView1.Items(i).SubItems.Item(4).Text & " " & ListView1.Items(i).SubItems.Item(5).Text & " " & ListView1.Items(i).SubItems.Item(6).Text & " " & ListView1.Items(i).SubItems.Item(7).Text & " " & ListView1.Items(i).SubItems.Item(8).Text & Chr(13) & Chr(10))
            Next i
            W = Nothing
            OtchetGurnal = "Экспорт исходящих в WORD " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ЭкспортExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортExcelToolStripMenuItem.Click
        Try
            Dim myXL As Excel.Application, myWB As Excel.Workbook, myWS As Excel.Worksheet
            Dim i As Integer
            Dim Y As Integer
            Dim z As Integer
            myXL = New Excel.Application
            myWB = myXL.Workbooks.Add
            myWS = myWB.Worksheets(1)
            z = 2
            myXL.Visible = True
            For i = 1 To Me.ListView1.Items.Count
                For Y = 1 To 9
                    myWS.Cells(1, Y) = ListView1.Columns(Y - 1).Text
                Next Y
                myWS.Cells(z, 1) = ListView1.Items.Item(i - 1).SubItems.Item(0).Text
                myWS.Cells(z, 2) = ListView1.Items.Item(i - 1).SubItems.Item(1).Text
                myWS.Cells(z, 3) = ListView1.Items.Item(i - 1).SubItems.Item(2).Text
                myWS.Cells(z, 4) = ListView1.Items.Item(i - 1).SubItems.Item(3).Text
                myWS.Cells(z, 5) = ListView1.Items.Item(i - 1).SubItems.Item(4).Text
                myWS.Cells(z, 6) = ListView1.Items.Item(i - 1).SubItems.Item(5).Text
                myWS.Cells(z, 7) = ListView1.Items.Item(i - 1).SubItems.Item(6).Text
                myWS.Cells(z, 8) = ListView1.Items.Item(i - 1).SubItems.Item(7).Text
                myWS.Cells(z, 9) = ListView1.Items.Item(i - 1).SubItems.Item(8).Text
                z = z + 1
            Next i
            myWS.Columns(1).ColumnWidth = 20
            myWS.Columns(2).ColumnWidth = 20
            myWS.Columns(3).ColumnWidth = 20
            myWS.Columns(4).ColumnWidth = 50
            myWS.Columns(5).ColumnWidth = 20
            myWS.Columns(6).ColumnWidth = 20
            myWS.Columns(7).ColumnWidth = 20
            myWS.Columns(8).Columnwidth = 20
            myWS.Columns(9).ColumnWidth = 20
            myXL = Nothing
            myWB = Nothing
            myWS = Nothing
            OtchetGurnal = "Экспорт исходящих в Excel " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub УбратьКолонкуToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УбратьКолонкуToolStripMenuItem.Click
        Dim Kolonka As Integer
        Try
            Kolonka = InputBox("Введите номер колонки которую нужно скрыть", "Запрос")
            ListView1.Columns(Kolonka - 1).Dispose()
            OtchetGurnal = "Включен фильтр с колонками в исходящих " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show("Следует вводить только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ПоискПоНомеруToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоискПоНомеруToolStripMenuItem.Click
        Dim Nomer As String
        Try
            Nomer = InputBox("Введите регистрационный номер для поиска", "Запрос")
            lvwColumnSorter = New ListViewColumnSorter()
            Me.ListView1.ListViewItemSorter = lvwColumnSorter
            ListView1.Columns.Clear()
            ListView1.Columns.Add("Регистрационный номер")
            ListView1.Columns.Add("Дата")
            ListView1.Columns.Add("Адресат документа")
            ListView1.Columns.Add("Заголовок (краткое содержание документа)")
            ListView1.Columns.Add("Количество листов с приложением")
            ListView1.Columns.Add("Исполнитель")
            ListView1.Columns.Add("Куда помещен документ (№ дела)")
            ListView1.Columns.Add("Отметка об исполнении")
            ListView1.Columns.Add("Примечание")
            ListView1.Items.Clear()
            Dim DataReader As OleDbDataReader
            Dim Command As New OleDbCommand("Select * FROM Исходящая WHERE ((([Регистрационный номер]) Like '%" & Nomer & "%'))", Connector)
            Connector.Open()
            DataReader = Command.ExecuteReader
            While DataReader.Read() = True
                ListView1.Items.Add(DataReader.GetValue(0))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(5))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(6))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(7))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(8))
            End While
            DataReader.Close()
            Connector.Close()
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
            OtchetGurnal = "Включена фильтрация по номеру в исходящих " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            Connector.Close()
            Form1_Load(Me, New EventArgs)
            MessageBox.Show("Следует вводить только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ВыключитьФильтрToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыключитьФильтрToolStripMenuItem.Click
        Form1_Load(Me, New EventArgs)
        OtchetGurnal = "Фильтр отключен " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        OtchetGurnal = "Запущена процедура добавления исходящих " & DateString & " " & TimeString : ZapGurnal()
        ДобавитьЗаписьToolStripMenuItem_Click(Me, New EventArgs)
    End Sub
    Private Sub ToolStripComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Form1_Load(Me, New EventArgs)
            OtchetGurnal = "Обновление книги исходящих и включение фильтра " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ToolStripComboBox1.Text = "" Then
                MessageBox.Show("Не выбрано поле для фильтра", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Form1_Load(Me, New EventArgs)
                OtchetGurnal = "Обновление книги исходящие и включение фильтра " & DateString & " " & TimeString : ZapGurnal()
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripTextBox1.Text = ""
        ToolStripComboBox1.Text = ToolStripComboBox1.Items(0)
        Form1_Load(Me, New EventArgs)
        OtchetGurnal = "Отключение фильтра книги исходящих " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ПолучитьКарточкуToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПолучитьКарточкуToolStripMenuItem.Click
        Try
            Dim W = New Word.Application
            W.Visible = True
            W.Documents.Add()
            With W.ActiveWindow.Selection
                .Font.Color = Word.WdColor.wdColorBlack
                .Font.Name = "Times New Roman"
                .Font.Bold = False
                .Font.Size = 12
                .Tables.Add(W.Selection.Range, 8, 2, Word.WdDefaultTableBehavior.wdWord9TableBehavior,
                Word.WdAutoFitBehavior.wdAutoFitContent)
                .Tables(1).Cell(Row:=1, Column:=1).Range.InsertAfter("Общий отдел" & Chr(13) & Chr(10) & "(внутренний документ)")
                .Tables(1).Cell(Row:=1, Column:=2).Range.InsertAfter("КОНТРОЛЬНО-РЕГИСТРАЦИОННАЯ КАРТОЧКА")
                .Tables(1).Cell(Row:=2, Column:=1).Range.InsertAfter("Наименование вида документа")
                .Tables(1).Cell(Row:=2, Column:=2).Range.InsertAfter(ListView1.SelectedItems.Item(0).Text)
                .Tables(1).Cell(Row:=3, Column:=1).Range.InsertAfter("Краткое содержание")
                .Tables(1).Cell(Row:=3, Column:=2).Range.InsertAfter(ListView1.SelectedItems.Item(0).SubItems.Item(3).Text)
                .Tables(1).Cell(Row:=4, Column:=1).Range.InsertAfter("Адресат документа")
                .Tables(1).Cell(Row:=4, Column:=2).Range.InsertAfter(ListView1.SelectedItems.Item(0).SubItems.Item(2).Text)
                .Tables(1).Cell(Row:=5, Column:=1).Range.InsertAfter("Количество листов")
                .Tables(1).Cell(Row:=5, Column:=2).Range.InsertAfter(ListView1.SelectedItems.Item(0).SubItems.Item(4).Text)
                .Tables(1).Cell(Row:=6, Column:=1).Range.InsertAfter("Дата получения документа" & Chr(13) & Chr(10) & ListView1.SelectedItems.Item(0).SubItems.Item(1).Text)
                .Tables(1).Cell(Row:=6, Column:=2).Range.InsertAfter("Исполнитель " & ListView1.SelectedItems.Item(0).SubItems.Item(5).Text)
                .Tables(1).Cell(Row:=7, Column:=2).Range.InsertAfter("Подпись")
                .Tables(1).Cell(Row:=8, Column:=2).Range.InsertAfter("Примечание " & ListView1.SelectedItems.Item(0).SubItems.Item(8).Text)
                .Tables(1).Cell(Row:=1, Column:=1).Range.ParagraphFormat.Alignment = 1
                .Tables(1).Cell(Row:=1, Column:=2).Range.ParagraphFormat.Alignment = 1
                .Tables(1).Cell(Row:=1, Column:=1).Range.Font.Bold = True
                .Tables(1).Cell(Row:=1, Column:=2).Range.Font.Bold = True
                .Tables(1).Cell(Row:=1, Column:=1).Range.Font.Color = Word.WdColor.wdColorBlue
                .Tables(1).Cell(Row:=1, Column:=2).Range.Font.Color = Word.WdColor.wdColorRed
                OtchetGurnal = "Получение карточки исходящих " & DateString & TimeString : ZapGurnal()
            End With
            W = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub УдалитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьЗаписьToolStripMenuItem.Click
        OtchetGurnal = "Запущено удаление записи в исходящих " & DateString & TimeString : ZapGurnal()
        Удалить()
    End Sub

    Private Sub ОбновитьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem1.Click
        ToolStripButton2_Click(Me, New EventArgs)
    End Sub

    Private Sub ДобавитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьЗаписьToolStripMenuItem.Click
        Form2.Close()
        Form2.Text = "Добавление записи"
        Form2.Show()
        Form2.Focus()
        OtchetGurnal = "Запущено добавление в исходящие " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = lvwColumnSorter.SortColumn) Then
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If
        Me.ListView1.Sort()
    End Sub

    Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
        Dim ItemIndex As Integer
        If e.Button = MouseButtons.Right Then
            ItemIndex = ListView1.SelectedIndices.Count
            If ItemIndex = 1 Then
                ContextMenuStrip1.Show(Location.X + e.X, Location.Y + e.Y + ContextMenuStrip1.Height)
            Else
                ContextMenuStrip2.Show(Location.X + e.X, Location.Y + e.Y + ContextMenuStrip1.Height)
            End If
        End If
        OtchetGurnal = "Hажатие правой кнопки в исходящих " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            p1 = ListView1.SelectedItems.Item(0).Text
            p2 = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            p3 = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            p4 = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            p5 = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            p6 = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            p7 = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
            p8 = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
            p9 = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
            Form2.Close()
            Form2.Text = "Редактирование записи"
            Form2.Show()
            Form2.Focus()
            OtchetGurnal = "Запущено редактирование исходящих " & DateString & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        OtchetGurnal = "Обновление книги исходящих " & DateString & " " & TimeString : ZapGurnal()
        Form1_Load(Me, New EventArgs)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent1
        Prava()
        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Регистрационный номер")
        ListView1.Columns.Add("Дата")
        ListView1.Columns.Add("Адресат документа")
        ListView1.Columns.Add("Заголовок (краткое содержание документа)")
        ListView1.Columns.Add("Количество листов с приложением")
        ListView1.Columns.Add("Исполнитель")
        ListView1.Columns.Add("Куда помещен документ (№ дела)")
        ListView1.Columns.Add("Отметка об исполнении")
        ListView1.Columns.Add("Примечание")
        ListView1.Items.Clear()
        Try
            Dim Poisk As String
            If ToolStripTextBox1.Text = "" Then
                Poisk = "SELECT * FROM Исходящая ORDER BY Исходящая.[Код] DESC"
            Else
                Poisk = "SELECT * FROM Исходящая where (([" & ToolStripComboBox1.Text & "]) Like '%" & ToolStripTextBox1.Text & "%')"
            End If
            Dim DataReader As OleDbDataReader
            Dim Command As New OleDbCommand(Poisk, Connector)
            Connector.Open()
            DataReader = Command.ExecuteReader
            While DataReader.Read() = True
                ListView1.Items.Add(DataReader.GetValue(0))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(5))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(6))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(7))
                ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(8))
                CountForm1 = ListView1.Items.Count
            End While
            DataReader.Close()
            Connector.Close()
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
            OtchetGurnal = "Открыта книга исходящие " & DateString & TimeString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            Connector.Close()
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & ex.Message & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class
