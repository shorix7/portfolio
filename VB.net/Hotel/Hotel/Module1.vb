Module Module1
    Public Connector As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\bd")
    Public PravaPolzovatelyaKod As String
    Public PravaPolzovatelyaFamiliya As String
    Public PravaPolzovatelyaImya As String
    Public PravaPolzovatelyaOtchestvo As String
    Public PravaPolzovatelyaPrava As String = "Пользователь"
    Public PravaPolzovatelyaPassword As String
    Public PictureBoxList As New List(Of PictureBox)
    Public LabelList As New List(Of Label)
    Public Status1 As String
    Public Koordinati As Integer
    Public ZaprosNomera As String
    Public NomerClear As String
    Public HelpAdd As String

    Public BookingNomer As String
    Public BookingDataDo As String
    Public BookingTimeDo As String
    Public BookingCurrenData As String
    Public BookingWho As String
    Public BookingNote As String
    Public FIOClear As String

    Public InfoKlientAdd1 As String
    Public InfoKlientAdd2 As String
    Public InfoKlientAdd3 As String
    Public InfoKlientAdd4 As String
    Public InfoKlientAdd5 As String
    Public TekMonth As Integer = Date.DaysInMonth(Now.Year, Now.Month)

    Public KolvoCHS As Integer

End Module
