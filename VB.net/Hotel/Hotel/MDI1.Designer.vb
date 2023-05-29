<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDI1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ФайлToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.АвторизоватьсяToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВидToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СтрокаСостоянияToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.БДToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.АрхивированиеБДToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ИнструментыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЖурналСобытийToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЖурналыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ШахматкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КнигиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НомераToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КлиентыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ЧерныйСписокToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОкнаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.КаскадомToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СлеваНаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СверхуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗакрытьВсеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СправкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОПрограммеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОАвтореToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НаписатьПисьмоРазработчикуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ФайлToolStripMenuItem, Me.ВидToolStripMenuItem, Me.БДToolStripMenuItem, Me.ИнструментыToolStripMenuItem, Me.ЖурналыToolStripMenuItem, Me.КнигиToolStripMenuItem, Me.ОкнаToolStripMenuItem, Me.СправкаToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1089, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ФайлToolStripMenuItem
        '
        Me.ФайлToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.АвторизоватьсяToolStripMenuItem, Me.ToolStripMenuItem1, Me.ВыходToolStripMenuItem})
        Me.ФайлToolStripMenuItem.Name = "ФайлToolStripMenuItem"
        Me.ФайлToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ФайлToolStripMenuItem.Text = "&Файл"
        '
        'АвторизоватьсяToolStripMenuItem
        '
        Me.АвторизоватьсяToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.key
        Me.АвторизоватьсяToolStripMenuItem.Name = "АвторизоватьсяToolStripMenuItem"
        Me.АвторизоватьсяToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.АвторизоватьсяToolStripMenuItem.Text = "Авторизоваться..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 6)
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources._exit
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ВыходToolStripMenuItem.Text = "Выход"
        '
        'ВидToolStripMenuItem
        '
        Me.ВидToolStripMenuItem.Checked = True
        Me.ВидToolStripMenuItem.CheckOnClick = True
        Me.ВидToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ВидToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.СтрокаСостоянияToolStripMenuItem})
        Me.ВидToolStripMenuItem.Name = "ВидToolStripMenuItem"
        Me.ВидToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.ВидToolStripMenuItem.Text = "&Вид"
        '
        'СтрокаСостоянияToolStripMenuItem
        '
        Me.СтрокаСостоянияToolStripMenuItem.Checked = True
        Me.СтрокаСостоянияToolStripMenuItem.CheckOnClick = True
        Me.СтрокаСостоянияToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.СтрокаСостоянияToolStripMenuItem.Name = "СтрокаСостоянияToolStripMenuItem"
        Me.СтрокаСостоянияToolStripMenuItem.ShowShortcutKeys = False
        Me.СтрокаСостоянияToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.СтрокаСостоянияToolStripMenuItem.Text = "&Строка состояния"
        '
        'БДToolStripMenuItem
        '
        Me.БДToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.АрхивированиеБДToolStripMenuItem, Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem, Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem})
        Me.БДToolStripMenuItem.Name = "БДToolStripMenuItem"
        Me.БДToolStripMenuItem.Size = New System.Drawing.Size(34, 20)
        Me.БДToolStripMenuItem.Text = "БД"
        '
        'АрхивированиеБДToolStripMenuItem
        '
        Me.АрхивированиеБДToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.data_1
        Me.АрхивированиеБДToolStripMenuItem.Name = "АрхивированиеБДToolStripMenuItem"
        Me.АрхивированиеБДToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.АрхивированиеБДToolStripMenuItem.Text = "Архивирование БД"
        '
        'ВосстановлениеРезервнойКопииБДToolStripMenuItem
        '
        Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.data2
        Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Name = "ВосстановлениеРезервнойКопииБДToolStripMenuItem"
        Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.ВосстановлениеРезервнойКопииБДToolStripMenuItem.Text = "Восстановление резервной копии БД"
        '
        'ВосстановлениеВИсходныйВидБДToolStripMenuItem
        '
        Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.delete_1
        Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem.Name = "ВосстановлениеВИсходныйВидБДToolStripMenuItem"
        Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.ВосстановлениеВИсходныйВидБДToolStripMenuItem.Text = "Восстановление в исходный вид БД"
        '
        'ИнструментыToolStripMenuItem
        '
        Me.ИнструментыToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem, Me.ЖурналСобытийToolStripMenuItem})
        Me.ИнструментыToolStripMenuItem.Name = "ИнструментыToolStripMenuItem"
        Me.ИнструментыToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ИнструментыToolStripMenuItem.Text = "Инструменты"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources._185094
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'ЖурналСобытийToolStripMenuItem
        '
        Me.ЖурналСобытийToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.book_2
        Me.ЖурналСобытийToolStripMenuItem.Name = "ЖурналСобытийToolStripMenuItem"
        Me.ЖурналСобытийToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ЖурналСобытийToolStripMenuItem.Text = "Журнал событий..."
        '
        'ЖурналыToolStripMenuItem
        '
        Me.ЖурналыToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ШахматкаToolStripMenuItem})
        Me.ЖурналыToolStripMenuItem.Name = "ЖурналыToolStripMenuItem"
        Me.ЖурналыToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ЖурналыToolStripMenuItem.Text = "Журналы"
        '
        'ШахматкаToolStripMenuItem
        '
        Me.ШахматкаToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.Chart
        Me.ШахматкаToolStripMenuItem.Name = "ШахматкаToolStripMenuItem"
        Me.ШахматкаToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.ШахматкаToolStripMenuItem.Text = "Шахматка..."
        '
        'КнигиToolStripMenuItem
        '
        Me.КнигиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НомераToolStripMenuItem, Me.КлиентыToolStripMenuItem, Me.ToolStripMenuItem2, Me.ЧерныйСписокToolStripMenuItem})
        Me.КнигиToolStripMenuItem.Name = "КнигиToolStripMenuItem"
        Me.КнигиToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.КнигиToolStripMenuItem.Text = "Книги"
        '
        'НомераToolStripMenuItem
        '
        Me.НомераToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.hotel
        Me.НомераToolStripMenuItem.Name = "НомераToolStripMenuItem"
        Me.НомераToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.НомераToolStripMenuItem.Text = "Номера..."
        '
        'КлиентыToolStripMenuItem
        '
        Me.КлиентыToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources._friend
        Me.КлиентыToolStripMenuItem.Name = "КлиентыToolStripMenuItem"
        Me.КлиентыToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.КлиентыToolStripMenuItem.Text = "Клиенты..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(166, 6)
        '
        'ЧерныйСписокToolStripMenuItem
        '
        Me.ЧерныйСписокToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.user
        Me.ЧерныйСписокToolStripMenuItem.Name = "ЧерныйСписокToolStripMenuItem"
        Me.ЧерныйСписокToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ЧерныйСписокToolStripMenuItem.Text = "Черный список..."
        '
        'ОкнаToolStripMenuItem
        '
        Me.ОкнаToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.КаскадомToolStripMenuItem, Me.СлеваНаToolStripMenuItem, Me.СверхуToolStripMenuItem, Me.ЗакрытьВсеToolStripMenuItem})
        Me.ОкнаToolStripMenuItem.Name = "ОкнаToolStripMenuItem"
        Me.ОкнаToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ОкнаToolStripMenuItem.Text = "&Окна"
        '
        'КаскадомToolStripMenuItem
        '
        Me.КаскадомToolStripMenuItem.Name = "КаскадомToolStripMenuItem"
        Me.КаскадомToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.КаскадомToolStripMenuItem.Text = "Каскадом"
        '
        'СлеваНаToolStripMenuItem
        '
        Me.СлеваНаToolStripMenuItem.Name = "СлеваНаToolStripMenuItem"
        Me.СлеваНаToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.СлеваНаToolStripMenuItem.Text = "Слева направо"
        '
        'СверхуToolStripMenuItem
        '
        Me.СверхуToolStripMenuItem.Name = "СверхуToolStripMenuItem"
        Me.СверхуToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.СверхуToolStripMenuItem.Text = "Сверху вниз"
        '
        'ЗакрытьВсеToolStripMenuItem
        '
        Me.ЗакрытьВсеToolStripMenuItem.Name = "ЗакрытьВсеToolStripMenuItem"
        Me.ЗакрытьВсеToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ЗакрытьВсеToolStripMenuItem.Text = "Закрыть все"
        '
        'СправкаToolStripMenuItem
        '
        Me.СправкаToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОПрограммеToolStripMenuItem, Me.ОАвтореToolStripMenuItem, Me.НаписатьПисьмоРазработчикуToolStripMenuItem})
        Me.СправкаToolStripMenuItem.Name = "СправкаToolStripMenuItem"
        Me.СправкаToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.СправкаToolStripMenuItem.Text = "&Справка"
        '
        'ОПрограммеToolStripMenuItem
        '
        Me.ОПрограммеToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.info
        Me.ОПрограммеToolStripMenuItem.Name = "ОПрограммеToolStripMenuItem"
        Me.ОПрограммеToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ОПрограммеToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ОПрограммеToolStripMenuItem.Text = "О программе..."
        '
        'ОАвтореToolStripMenuItem
        '
        Me.ОАвтореToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.i1nfo
        Me.ОАвтореToolStripMenuItem.Name = "ОАвтореToolStripMenuItem"
        Me.ОАвтореToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ОАвтореToolStripMenuItem.Text = "О авторе..."
        '
        'НаписатьПисьмоРазработчикуToolStripMenuItem
        '
        Me.НаписатьПисьмоРазработчикуToolStripMenuItem.Image = Global.Hotel.My.Resources.Resources.message111s
        Me.НаписатьПисьмоРазработчикуToolStripMenuItem.Name = "НаписатьПисьмоРазработчикуToolStripMenuItem"
        Me.НаписатьПисьмоРазработчикуToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.НаписатьПисьмоРазработчикуToolStripMenuItem.Text = "Написать письмо разработчику"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1089, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(66, 17)
        Me.ToolStripStatusLabel.Text = "Состояние"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripStatusLabel1.Text = "Дата:"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel3.Text = "Время:"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(154, 17)
        Me.ToolStripStatusLabel5.Text = "Авторизованы права гостя"
        '
        'MDI1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 558)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MDI1"
        Me.Text = "Академическая гостиница"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ФайлToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents АвторизоватьсяToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВидToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents БДToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ИнструментыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЖурналыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents КнигиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОкнаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СправкаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents СтрокаСостоянияToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents АрхивированиеБДToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВосстановлениеРезервнойКопииБДToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВосстановлениеВИсходныйВидБДToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЖурналСобытийToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ШахматкаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents НомераToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents КлиентыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ЧерныйСписокToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents КаскадомToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СлеваНаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СверхуToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОПрограммеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОАвтореToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents НаписатьПисьмоРазработчикуToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВыходToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЗакрытьВсеToolStripMenuItem As ToolStripMenuItem
End Class
