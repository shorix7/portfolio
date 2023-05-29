Imports System.Data.OleDb
Imports System.IO


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub

    Private Sub TextBoxNumberOfRows_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxNumberOfRows.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "+") Then
            MessageBox.Show("Только цифры для ввода!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonCreateData_Click(sender As Object, e As EventArgs) Handles ButtonCreateData.Click
        If TextBoxNumberOfRows.Text = "" Then
            MessageBox.Show("Номер строки не может быть пустым !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ButtonCreateData.Text = "Загрузка..."
        ButtonCreateData.Enabled = False

        For i As Integer = 1 To TextBoxNumberOfRows.Text
            With DataGridView1.Rows
                .Add(i, i & "-ИС", "РАНХиГС", "Калининград") ' в данный цикл какимим данными будут заполняться поля, в соотвестивии, того чего мы создали в DATAGRIDVIEV
            End With
        Next

        ButtonCreateData.Text = "Задать значения"
        ButtonCreateData.Enabled = True
    End Sub

    Private Sub ButtonExportToExcel_Click(sender As Object, e As EventArgs) Handles ButtonExportToExcel.Click
        Try
            ButtonExportToExcel.Text = "Загрузка..."
            ButtonExportToExcel.Enabled = False

            SaveFileDialog1.Filter = "Excel Document (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("лист1")

                For i = 0 To DataGridView1.RowCount - 2
                    For j = 0 To DataGridView1.ColumnCount - 1
                        For k As Integer = 1 To DataGridView1.Columns.Count
                            xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                MsgBox("Сохранено успешно" & vbCrLf & "Файл сохранён в : " & SaveFileDialog1.FileName, MsgBoxStyle.Information, "Информация")

                ButtonExportToExcel.Text = "Экспорт"
                ButtonExportToExcel.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to save !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ButtonClearDGV_Click(sender As Object, e As EventArgs) Handles ButtonClearDGV.Click
        DataGridView1.Columns.Clear()
        If DataGridView1.Columns.Count = 0 Then
            With DataGridView1 'Снизу перечислены поля которые будут появляться после Нажатия на кнопку Очистки. Данные поля можно изменять в зависимости от ТЗ
                .Columns.Clear()
                .Columns.Add("No", "No")
                .Columns.Add("Стундент_группы", "Студент_группы")
                .Columns.Add("Колледж", "Колледж")
                .Columns.Add("Город", "Город")
            End With
        End If
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub ButtonImportFromExcel_Click(sender As Object, e As EventArgs) Handles ButtonImportFromExcel.Click
        Dim conn As OleDbConnection
        Dim dta As OleDbDataAdapter
        Dim dts As DataSet
        Dim excel As String
        Dim OpenFileDialog As New OpenFileDialog

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog1.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

        If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            DataGridView1.Columns.Clear()

            Dim fi As New FileInfo(OpenFileDialog1.FileName)
            Dim FileName As String = OpenFileDialog1.FileName

            excel = fi.FullName
            conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
            dta = New OleDbDataAdapter("Select * From [Лист1$]", conn)
            dts = New DataSet
            dta.Fill(dts, "[Лист1$]")
            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "[Лист1$]"
            conn.Close()
        End If
    End Sub
End Class
