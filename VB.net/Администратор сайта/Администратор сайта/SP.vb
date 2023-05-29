Imports Microsoft.Office.Interop
Module SP
    Sub Main()
        Dim app As New Excel.Application
        Dim wb = app.Workbooks.Open(Application.StartupPath & "\Report.xlsx")
        Dim ws As Excel.Worksheet = wb.Worksheets(1)
        Dim nameCell = wb.Names.Item(Nothing, "NAME", Nothing)
        Dim baseRowNum = nameCell.Row
        Dim rowNum = 1
        For Each p As Process In Process.GetProcesses()
            Try
                Dim fname = p.MainModule.FileName, id = p.Id, st = p.StartTime
                Dim rs = nameCell.EntireRow
                Dim newRowNum = baseRowNum + rowNum
                rs.Copy(ws.Range("A" & newRowNum).EntireRow)
                rowNum += 1
                ws.Range("A" & newRowNum).Value = fname
                ws.Range("B" & newRowNum).Value = id
                ws.Range("C" & newRowNum).Value = st
            Catch ex As Exception
            End Try
        Next
        nameCell.EntireRow.Delete()
        app.Visible = True
    End Sub
End Module
