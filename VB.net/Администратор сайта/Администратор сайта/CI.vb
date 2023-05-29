Imports Microsoft.Office.Interop
Module CI
    Sub Main()
        Dim app As New Word.Application
        Dim doc = app.Documents.Open(Application.StartupPath & "\Report.docx")
        doc.Bookmarks("COMPUTER").Range.Text = Environment.MachineName
        doc.Bookmarks("OS").Range.Text = Environment.OSVersion.ToString
        doc.Bookmarks("USER").Range.Text = Environment.UserName
        app.Visible = True
    End Sub
End Module
