Imports System.IO
Public Class Site
    Public intId As Integer
    Public strTitle As String
    Public strLink As String
    Public strRem As String
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
    Public Property Link As String
        Get
            Return strLink
        End Get
        Set(value As String)
            strLink = value
        End Set
    End Property
    Public Property Remain As String
        Get
            Return strRem
        End Get
        Set(value As String)
            strRem = value
        End Set
    End Property
    Public Function NewSite(ByVal objSite As Site)
        Form1.ToolStripComboBox1.Items.Clear()
        Dim read1 As StreamReader
        Dim strSite As String()
        Try
            read1 = New StreamReader(Application.StartupPath & "\Sites.txt", System.Text.Encoding.UTF8)
            While read1.EndOfStream = False
                strSite = read1.ReadLine.Split(";")
                With objSite
                    .id = strSite(0)
                    .Title = strSite(1)
                    .Link = strSite(2)
                    .Remain = strSite(3)
                    Form1.ToolStripComboBox1.Items.Add(.Title)
                End With
            End While
            read1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Public Function WriteFile(ByVal objSite As Site)
        Dim inputstring As String = vbCrLf & objSite.id & ";" & objSite.Title & ";" & objSite.Link & ";" & objSite.Remain
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Sites.txt", inputstring, True)
        objSite.NewSite(objSite)
    End Function
End Class
