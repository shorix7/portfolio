Imports System.Data.OleDb
Public Class InfoNomer
    Dim Tab1 As String

    Private Sub InfoNomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        MdiParent = MDI1
        Text = "Подробная информация о номере"
        Label1.Text = "Подробно о " & ZaprosNomera & "номере!"
        Call InfoNomerLoad()
        Call Bron()
        Call UslugiLoad()
        Call Malfunctions()
        If Tab1 = "Свободен" Then Panel1.BackColor = Color.Lime
        If Tab1 = "Занято" Then Panel1.BackColor = Color.Red
        If Tab1 = "Не заселять" Then Panel1.BackColor = Color.White
        If TekMonth = 31 Then Button38.Visible = True : Button37.Visible = True : Button36.Visible = True : Button35.Visible = True
        If TekMonth = 30 Then Button37.Visible = True : Button36.Visible = True : Button35.Visible = True
        If TekMonth = 29 Then Button36.Visible = True : Button35.Visible = True
        If TekMonth = 28 Then Button35.Visible = True
        Call CalendarLoad()
    End Sub
    Sub InfoNomerLoad()
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Номера.[Этаж], Номера.[Категория], Номера.[Количество мест], Номера.[Дополнительная информация], Номера.[Стоимость в сутки], Номера.[статус], Номера.[Номер] FROM Номера WHERE (((Номера.[Номер])='" & ZaprosNomera & "'));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ComboBox1.Text = DataReader.GetValue(0)
            ComboBox3.Text = DataReader.GetValue(1)
            TextBox2.Text = DataReader.GetValue(2)
            TextBox4.Text = DataReader.GetValue(3)
            TextBox3.Text = DataReader.GetValue(4)
            Tab1 = DataReader.GetValue(5)
            TextBox1.Text = DataReader.GetValue(6)
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub Bron()
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Забронирование ДО")
        ListView1.Columns.Add("Время")
        ListView1.Columns.Add("Дата бронирования")
        ListView1.Columns.Add("На кого забронированно")
        ListView1.Columns.Add("Примечание")
        ListView1.Items.Clear()
        ListView1.Columns.Item(0).Width = 100
        ListView1.Columns.Item(1).Width = 100
        ListView1.Columns.Item(2).Width = 100
        ListView1.Columns.Item(3).Width = 300
        ListView1.Columns.Item(4).Width = 500
        Call BronInfo()
    End Sub
    Sub BronInfo()
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT Бронирование.[Дата до], Бронирование.[Время до], Бронирование.[Текущая дата], Бронирование.[На кого], Бронирование.[Примечание] FROM Бронирование WHERE (((Бронирование.[Номер])= " & ZaprosNomera & "));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView1.Items.Add(DataReader.GetValue(0))
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
            ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub UslugiLoad()
        ListView2.Columns.Clear()
        ListView2.Columns.Add("Дата регистрации услуги")
        ListView2.Columns.Add("Название услуги")
        ListView2.Items.Clear()
        ListView2.Columns.Item(0).Width = 100
        ListView2.Columns.Item(1).Width = 100
        Call UslugiLoad2()
    End Sub
    Sub UslugiLoad2()
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Текущие услуги].[Дата], [Текущие услуги].[Услуга] FROM [Текущие услуги] WHERE ((([Текущие услуги].[Номер])= " & ZaprosNomera & "));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView2.Items.Add(DataReader.GetValue(0))
            ListView2.Items.Item(ListView2.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub Malfunctions()
        ListView3.Columns.Clear()
        ListView3.Columns.Add("№")
        ListView3.Columns.Add("Дата отметки")
        ListView3.Columns.Add("Неисправность")
        ListView3.Items.Clear()
        ListView3.Columns.Item(0).Width = 50
        ListView3.Columns.Item(1).Width = 100
        ListView3.Columns.Item(2).Width = 500
        Call MalfunctionLoad()
    End Sub
    Sub MalfunctionLoad()
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Неисправность номера].[Код неисправности], [Неисправность номера].[Дата отметки], [Неисправность номера].[неисправность] FROM [Неисправность номера] WHERE ((([Неисправность номера].[Номер])= " & ZaprosNomera & "));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView3.Items.Add(DataReader.GetValue(0))
            ListView3.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView3.Items.Item(ListView1.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub CalendarLoad()
        Dim sop As Integer
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Занятость номера].[День] FROM [Занятость номера] WHERE ((([Занятость номера].[Номер])='" & ZaprosNomera & "') AND (([Занятость номера].[Месяц])='" & Date.Now.Month & "') AND (([Занятость номера].[Год])='" & Date.Now.Year & "'));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        ' While DataReader.Read() = True
        ' sop = DataReader.GetValue(0) + 7
        'Controls("Button" & DataReader.GetValue(0) + 7).backcolor = Color.Red
        'End While
        DataReader.Close()
        Connector.Close()
    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            Dim r As Rectangle = e.Bounds
            Dim TitleBrush As Brush = New SolidBrush(Color.Blue)
            Dim BackBrush As Brush = New SolidBrush(Color.Transparent)
            Dim F As Font = Font
            Dim Title As String = TabControl1.TabPages(e.Index).Text
            e.Graphics.FillRectangle(BackBrush, r)
            e.Graphics.DrawString(Title, F, TitleBrush, New PointF(r.X + 2, r.Y + 3))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then TextBox1.Text = "-"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Номер] = '" & TextBox1.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox2.Text = "" Then ComboBox2.Text = "1"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Этаж] = '" & ComboBox1.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox3.Text = "" Then ComboBox3.Text = "Одноместный"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Категория] = '" & ComboBox3.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then TextBox2.Text = "-"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Количество мест] = '" & TextBox2.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox3.Text = "" Then TextBox3.Text = "-"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Стоимость в сутки] = '" & TextBox3.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = "" Then TextBox4.Text = "-"
        Dim Command As New OleDbCommand("UPDATE [Номера] SET [Дополнительная информация] = '" & TextBox4.Text & "' WHERE ([Номер] Like '" & ZaprosNomera & "')", Connector)
        Connector.Open()
        Command.ExecuteNonQuery()
        Connector.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Close()

    End Sub
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
        AddHandler TabControl1.DrawItem, AddressOf TabControl1_DrawItem
        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then Call History1() ' Архив заселения
        If ComboBox2.SelectedIndex = 1 Then Call History2() ' Архив бронирования
        If ComboBox2.SelectedIndex = 2 Then Call History3() ' Архив услуг
        If ComboBox2.SelectedIndex = 3 Then Call History4() ' Архив неисправности номера
    End Sub
    Sub History1()
        ListView4.Columns.Clear()
        ListView4.Columns.Add("№")
        ListView4.Columns.Add("ФИО постояльца")
        ListView4.Columns.Add("Комментарй")
        ListView4.Items.Clear()
        ListView4.Columns.Item(0).Width = 50
        ListView4.Columns.Item(1).Width = 200
        ListView4.Columns.Item(2).Width = 300
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Архив заселения].[Код архива заселения], [Архив заселения].Проживал, [Архив заселения].Коментарий FROM [Архив заселения] WHERE ((([Архив заселения].Номер)='" & ZaprosNomera & "'));", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView4.Items.Add(DataReader.GetValue(0))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub History2()
        ListView4.Columns.Clear()
        ListView4.Columns.Add("№")
        ListView4.Columns.Add("На какую дату")
        ListView4.Columns.Add("На какое время")
        ListView4.Columns.Add("Дата бронирования")
        ListView4.Columns.Add("На кого забронированно ФИО")
        ListView4.Columns.Add("Примечание")
        ListView4.Items.Clear()
        ListView4.Columns.Item(0).Width = 50
        ListView4.Columns.Item(1).Width = 100
        ListView4.Columns.Item(2).Width = 100
        ListView4.Columns.Item(3).Width = 100
        ListView4.Columns.Item(4).Width = 300
        ListView4.Columns.Item(5).Width = 300
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Архив Бронирования].[Код архива бронирования], [Архив Бронирования].[Дата до], [Архив Бронирования].[Время до], [Архив Бронирования].[Текущая дата], [Архив Бронирования].[На кого], [Архив Бронирования].[Примечание] FROM [Архив Бронирования] WHERE ((([Архив Бронирования].[Номер])='" & ZaprosNomera & "')); ", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView4.Items.Add(DataReader.GetValue(0))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(3))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(4))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(5))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub History3()
        ListView4.Columns.Clear()
        ListView4.Columns.Add("№")
        ListView4.Columns.Add("Дата")
        ListView4.Columns.Add("Услуга")
        ListView4.Items.Clear()
        ListView4.Columns.Item(0).Width = 50
        ListView4.Columns.Item(1).Width = 100
        ListView4.Columns.Item(2).Width = 200
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Архив услуг].[Код архива услуги], [Архив услуг].[Дата], [Архив услуг].[Услуга] FROM [Архив услуг] WHERE ((([Архив услуг].[Номер])= '" & ZaprosNomera & "')); ", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView4.Items.Add(DataReader.GetValue(0))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub
    Sub History4()
        ListView4.Columns.Clear()
        ListView4.Columns.Add("№")
        ListView4.Columns.Add("Дата")
        ListView4.Columns.Add("Неисправность")
        ListView4.Items.Clear()
        ListView4.Columns.Item(0).Width = 50
        ListView4.Columns.Item(1).Width = 100
        ListView4.Columns.Item(2).Width = 200
        Dim DataReader As OleDbDataReader
        Dim Command As New OleDbCommand("SELECT [Архив неисправность номера].[Код неисправности], [Архив неисправность номера].[Дата отметки], [Архив неисправность номера].[Неисправность] FROM [Архив неисправность номера] WHERE ((([Архив неисправность номера].[Номер])='" & ZaprosNomera & "')); ", Connector)
        Connector.Open()
        DataReader = Command.ExecuteReader
        While DataReader.Read() = True
            ListView4.Items.Add(DataReader.GetValue(0))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(1))
            ListView4.Items.Item(ListView4.Items.Count - 1).SubItems.Add(DataReader.GetValue(2))
        End While
        DataReader.Close()
        Connector.Close()
    End Sub

    Private Sub ListView3_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView3.MouseUp
        Dim ItemIndex As Integer
        If e.Button = MouseButtons.Right Then
            ItemIndex = ListView3.SelectedIndices.Count
            If ItemIndex = 1 Then ContextMenuStrip1.Show(Location.X + e.X, Location.Y + e.Y + 150)
        End If
    End Sub

    Private Sub ОтметитьКакИсполненноеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОтметитьКакИсполненноеToolStripMenuItem.Click
        Dim MBox As DialogResult = MessageBox.Show("Отметить как выполненное", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If MBox = DialogResult.No Then Exit Sub
        If MBox = DialogResult.Yes Then
            Dim Command As New OleDbCommand("DELETE FROM [Неисправность номера] WHERE ([Код неисправности] = " & ListView3.SelectedItems.Item(0).Text & ")", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
            ListView3.SelectedItems.Item(0).Remove()
            MessageBox.Show("Сохраненно", "Операция успешно завершнена", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonCalendar_Click(sender As Object, e As EventArgs) Handles Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click
        Dim b As Button = DirectCast(sender, Button)
        If b.BackColor = Color.Lime Then
            b.BackColor = Color.Red
            Dim Command As New OleDbCommand("Insert Into [Занятость номера] ([Номер], [День], [Месяц], [Год]) values ('" & ZaprosNomera & "', '" & b.Text & "', '" & Date.Now.Month & "', '" & Date.Now.Year & "') ", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
        Else
            b.BackColor = Color.Lime
            Dim Command As New OleDbCommand("DELETE FROM [Занятость номера] WHERE ([Занятость номера].[Номер] = '" & ZaprosNomera & "') and ([Занятость номера].[День] = '" & b.Text & "') and ([Занятость номера].[Месяц] = '" & Date.Now.Month & "') and ([Занятость номера].[Год] = '" & Date.Now.Year & "')", Connector)
            Connector.Open()
            Command.ExecuteNonQuery()
            Connector.Close()
        End If
    End Sub
End Class