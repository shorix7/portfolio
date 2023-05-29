﻿Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Public Class Form11
    Sub Dobavlenie_zap()
        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        Try
            Dim Command As New OleDbCommand("Insert Into [Приказы по АХД] ([Регистрационный номер], [Дата регистрации], [Краткое содержание], [Количество листов], [Исполнитель], [Куда передан приказ], [Отметка о помещении в дело]) values ('" & p1 & "', '" & p2 & "', '" & p3 & "', '" & p4 & "', '" & p5 & "', '" & p6 & "', '" & p7 & "')", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
            ListView1.Items.Add("[Регистрационный номер]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Дата регистрации]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Краткое содержание]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Количество листов]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Исполнитель]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Куда передан приказ]")
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add("[Отметка о помещении в дело]")
            OtchetGurnal = "Добавление записи в Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            Form11_Load(Me, New EventArgs)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
    Sub Editor_zap()
        Try
            Dim Command As New OleDbCommand("UPDATE [Приказы по АХД] SET [Регистрационный номер]='" & p1 & "', [Дата регистрации]='" & p2 & "', [Краткое содержание]='" & p3 & "', [Количество листов]='" & p4 & "', [Исполнитель]='" & p5 & "', [Куда передан приказ]='" & p6 & "', [Отметка о помещении в дело]='" & p7 & "' WHERE ([Регистрационный номер] Like '" & ListView1.SelectedItems.Item(0).Text & "')", Connector)
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
            OtchetGurnal = "Изменена запись в Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            Form11_Load(Me, New EventArgs)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
    Sub удалить()
        Dim MBox As DialogResult = MessageBox.Show("Удалить текущую запись", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Try
            If MBox = DialogResult.No Then Exit Sub
            If MBox = DialogResult.Yes Then
                Dim Command As New OleDbCommand("DELETE FROM [Приказы по АХД] WHERE [Регистрационный номер] ='" & ListView1.SelectedItems.Item(0).Text & "'", Connector)
                Connector.Open()
                Command.ExecuteNonQuery()
                Connector.Close()
                ListView1.SelectedItems.Item(0).Remove()
                Form11_Load(Me, New EventArgs)
                MessageBox.Show("Запись была успешно удалена из БД", "Операция успешна завершена", MessageBoxButtons.OK, MessageBoxIcon.Information)
                OtchetGurnal = "Удалена запись в Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = MDIParent1
        Prava()
        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Регистрационный номер")
        ListView1.Columns.Add("Дата регистрации")
        ListView1.Columns.Add("Краткое содержание")
        ListView1.Columns.Add("Количество листов")
        ListView1.Columns.Add("Исполнитель")
        ListView1.Columns.Add("Куда передан приказ")
        ListView1.Columns.Add("Отметка о помещении в дело")
        ListView1.Items.Clear()
        Try
            OtchetGurnal = "Загрузка Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            Dim Poisk As String
            If ToolStripTextBox1.Text = "" Then
                Poisk = "SELECT * FROM [Приказы по АХД] ORDER BY [Приказы по АХД].[Код] DESC"
            Else
                Poisk = "SELECT * FROM [Приказы по АХД] where (([" & ToolStripComboBox1.Text & "]) Like '%" & ToolStripTextBox1.Text & "%')"
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
                CountForm6 = ListView1.Items.Count
            End While
            DataReader.Close()
            Connector.Close()
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
            OtchetGurnal = "Загрузка завершена Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            Connector.Close()
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
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

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            p1 = ListView1.SelectedItems.Item(0).Text
            p2 = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            p3 = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            p4 = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            p5 = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            p6 = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            p7 = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
            Form12.Close()
            Form12.Text = "Редактирование записи"
            Form12.Show()
            OtchetGurnal = "Запущено редактирование записи Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
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
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        OtchetGurnal = "Запуск процедуры добавления записи в Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        ДобавитьЗаписьToolStripMenuItem_Click(Me, New EventArgs)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        OtchetGurnal = "Обновление записей в программе Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Form11_Load(Me, New EventArgs)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripTextBox1.Text = ""
        ToolStripComboBox1.Text = ToolStripComboBox1.Items(0)
        Form11_Load(Me, New EventArgs)
        OtchetGurnal = "Фильтр выключен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ToolStripComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Form11_Load(Me, New EventArgs)
            OtchetGurnal = "Фильтр включен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        End If
    End Sub

    Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ToolStripComboBox1.Text = "" Then
                MessageBox.Show("Не выбрано поле для фильтра", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                OtchetGurnal = "Фильтр включен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            Else
                Form11_Load(Me, New EventArgs)
                OtchetGurnal = "Фильтр выключен Приказы по АХД" & DateString & " " & TimeString : ZapGurnal()
            End If
        End If
    End Sub

    Private Sub ВыключитьФильтрToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыключитьФильтрToolStripMenuItem.Click
        OtchetGurnal = "Фильтр отключен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Form11_Load(Me, New EventArgs)
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        OtchetGurnal = "Закрыта таблица Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Close()
    End Sub

    Private Sub ДобавитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьЗаписьToolStripMenuItem.Click
        Form12.Close()
        Form12.Text = "Добавление записи"
        Form12.Show()
        OtchetGurnal = "Запуск процедуры добавления записи Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
    End Sub

    Private Sub ОбновитьToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem1.Click
        OtchetGurnal = "Обновление Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Form11_Load(Me, New EventArgs)
    End Sub

    Private Sub ОбновитьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОбновитьToolStripMenuItem.Click
        OtchetGurnal = "Обновление Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Form11_Load(Me, New EventArgs)
    End Sub

    Private Sub ПоискПоДатеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоискПоДатеToolStripMenuItem.Click
        Dim Nomer As String
        Try
            Nomer = InputBox("Введите дату поиска", "Запрос")
            lvwColumnSorter = New ListViewColumnSorter()
            Me.ListView1.ListViewItemSorter = lvwColumnSorter
            ListView1.Columns.Clear()
            ListView1.Columns.Add("Регистрационный номер")
            ListView1.Columns.Add("Дата регистрации")
            ListView1.Columns.Add("Краткое содержание")
            ListView1.Columns.Add("Количество листов")
            ListView1.Columns.Add("Исполнитель")
            ListView1.Columns.Add("Куда передан приказ")
            ListView1.Columns.Add("Отметка о помещении в дело")
            ListView1.Items.Clear()
            Dim DataReader As OleDbDataReader
            Dim Command As New OleDbCommand("SELECT * FROM [Приказы по студентам] WHERE ((([Дата регистрации]) Like '%" & Nomer & "%'));", Connector)
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
            End While
            DataReader.Close()
            Connector.Close()
            OtchetGurnal = "Включен фильтр по дате Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
        Catch ex As Exception
            MessageBox.Show("Следует вводить только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OtchetGurnal = "Ошибка" & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ПоискПоНомеруToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоискПоНомеруToolStripMenuItem.Click
        Dim Nomer As String
        Try
            Nomer = InputBox("Введите номер для поиска", "Запрос")
            lvwColumnSorter = New ListViewColumnSorter()
            Me.ListView1.ListViewItemSorter = lvwColumnSorter
            ListView1.Columns.Clear()
            ListView1.Columns.Add("Регистрационный номер")
            ListView1.Columns.Add("Дата регистрации")
            ListView1.Columns.Add("Краткое содержание")
            ListView1.Columns.Add("Количество листов")
            ListView1.Columns.Add("Исполнитель")
            ListView1.Columns.Add("Куда передан приказ")
            ListView1.Columns.Add("Отметка о помещении в дело")
            ListView1.Items.Clear()
            Dim DataReader As OleDbDataReader
            Dim Command As New OleDbCommand("SELECT * FROM [Приказы по студентам] WHERE ((([Регистрационный номер]) Like '%" & Nomer & "%'));", Connector)
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
            End While
            DataReader.Close()
            Connector.Close()
            OtchetGurnal = "Включен фильтр по записям Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            For Each columnheader In Me.ListView1.Columns
                columnheader.Width = -3
            Next
        Catch ex As Exception
            MessageBox.Show("Следует вводить только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub УбратьКолонкуToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УбратьКолонкуToolStripMenuItem.Click
        Dim Kolonka As Integer
        Try
            Kolonka = InputBox("Введите номер колонки которую нужно скрыть", "Запрос")
            ListView1.Columns(Kolonka - 1).Dispose()
            OtchetGurnal = "Фильтр с колонками включен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show("Следует вводить только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub УдалитьЗаписьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьЗаписьToolStripMenuItem.Click
        OtchetGurnal = "Запуск процедуры удаления записи Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        удалить()
    End Sub

    Private Sub ЭкспортExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортExcelToolStripMenuItem.Click
        Try
            Dim myXL As Excel.Application, myWB As Excel.Workbook, myWS As Excel.Worksheet
            Dim i As Integer
            Dim Y As Integer
            Dim z As Integer
            OtchetGurnal = "Запщен Экспорт в Excel Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
            myXL = New Excel.Application
            myWB = myXL.Workbooks.Add
            myWS = myWB.Worksheets(1)
            z = 2
            myXL.Visible = True
            For i = 1 To Me.ListView1.Items.Count
                For Y = 1 To 7
                    myWS.Cells(1, Y) = ListView1.Columns(Y - 1).Text
                Next Y
                myWS.Cells(z, 1) = ListView1.Items.Item(i - 1).SubItems.Item(0).Text
                myWS.Cells(z, 2) = ListView1.Items.Item(i - 1).SubItems.Item(1).Text
                myWS.Cells(z, 3) = ListView1.Items.Item(i - 1).SubItems.Item(2).Text
                myWS.Cells(z, 4) = ListView1.Items.Item(i - 1).SubItems.Item(3).Text
                myWS.Cells(z, 5) = ListView1.Items.Item(i - 1).SubItems.Item(4).Text
                myWS.Cells(z, 6) = ListView1.Items.Item(i - 1).SubItems.Item(5).Text
                myWS.Cells(z, 7) = ListView1.Items.Item(i - 1).SubItems.Item(6).Text
                z = z + 1
            Next i
            myWS.Columns(1).ColumnWidth = 20
            myWS.Columns(2).ColumnWidth = 20
            myWS.Columns(3).ColumnWidth = 50
            myWS.Columns(4).ColumnWidth = 50
            myWS.Columns(5).ColumnWidth = 20
            myWS.Columns(6).ColumnWidth = 20
            myWS.Columns(7).ColumnWidth = 20
            myXL = Nothing
            myWB = Nothing
            myWS = Nothing
            OtchetGurnal = "Экспорт в Excel завершен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub

    Private Sub ЭкспортWORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЭкспортWORDToolStripMenuItem.Click
        Try
            OtchetGurnal = "Запщен Экспорт в WORD Приказы по АХД" & DateString & " " & TimeString : ZapGurnal()
            Dim Дата As String = Format(Now, "d MMMM уууу")
            Dim W = New Word.Application
            W.Visible = True
            W.Documents.Add()
            W.Selection.TypeText("Выписка из БД: " & Дата & Chr(13) & Chr(10))
            For i As Short = 0 To ListView1.Items.Count - 1
                W.Selection.TypeText(ListView1.Items(i).SubItems.Item(0).Text & " " & ListView1.Items(i).SubItems.Item(1).Text & " " & ListView1.Items(i).SubItems.Item(2).Text & " " & ListView1.Items(i).SubItems.Item(3).Text & " " & ListView1.Items(i).SubItems.Item(4).Text & " " & ListView1.Items(i).SubItems.Item(5).Text & " " & ListView1.Items(i).SubItems.Item(6).Text & Chr(13) & Chr(10))
            Next i
            W = Nothing
            OtchetGurnal = "Экспорт в WORD завершен Приказы по АХД " & DateString & " " & TimeString : ZapGurnal()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            OtchetGurnal = "Ошибка " & DateString & " " & TimeString : ZapGurnal()
        End Try
    End Sub
End Class