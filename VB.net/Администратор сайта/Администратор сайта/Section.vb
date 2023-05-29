Imports System.IO
Public Class Section
    Dim intId As Integer
    Dim strTitle As String
    Dim intIdSite As Integer
    Dim strLink As String
    Dim strTip As String
    Public Property id As Integer
        Get
            Return intId
        End Get
        Set(value As Integer)
            intId = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return strTitle
        End Get
        Set(value As String)
            strTitle = value
        End Set
    End Property
    Public Property IdSite As Integer
        Get
            Return intIdSite
        End Get
        Set(value As Integer)
            intIdSite = value
        End Set
    End Property
    Public Property Link As String
        Get
            Return strLink
        End Get
        Set(value As String)
            strLink = value
        End Set
    End Property
    Public Property Tip As String
        Get
            Return strTip
        End Get
        Set(value As String)
            strTip = value
        End Set
    End Property
    Public Function NewSection(ByVal objSection As Section)
        Form1.РазделыСайтаToolStripMenuItem.DropDownItems.Clear()
        Form1.ToolStripComboBox2.Items.Clear()
        Dim read1 As StreamReader
        Dim strSection As String()
        Try
            read1 = New StreamReader(Application.StartupPath & "\Titles.txt", System.Text.Encoding.UTF8)
            While read1.EndOfStream = False
                strSection = read1.ReadLine.Split(";")
                With objSection
                    .id = strSection(0)
                    .Title = strSection(1)
                    .IdSite = strSection(2)
                    .Link = strSection(3)
                    .Tip = strSection(4)
                    If Form1.ToolStripComboBox1.SelectedIndex + 1 = .IdSite Then
                        Form1.ToolStripComboBox2.Items.Add(.Title)
                    End If
                    If .IdSite = 1 Then
                        Form1.РазделыСайтаToolStripMenuItem.DropDownItems.Add(.Title)
                    End If
                End With
            End While
            read1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function WriteFile(ByVal objSection As Section)
        Dim inputstring As String = vbCrLf & objSection.id & ";" & objSection.Title & ";" & objSection.IdSite & ";" & objSection.Link & ";" & objSection.Tip
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Titles.txt", inputstring, True)
        objSection.NewSection(objSection)
    End Function
End Class
