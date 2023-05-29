<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ОбновитьToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьЗаписьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ПолучитьКарточкуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьЗаписьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.МенюИсходящихToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОбновитьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ФильтрToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УбратьКолонкуToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоискПоНомеруToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыключитьФильтрToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоискПоДатеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЭкспортWORDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЭкспортExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 25)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(870, 442)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripComboBox1, Me.ToolStripTextBox1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(870, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Добавить запись в БД"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Обновить таблицу"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"Дата поступления", "Регистрационный номер", "Корреспондент документа", "Исходящий номер и дата документа", "Заголовок (краткое содержание документа)", "Количество листов с приложением", "Резолюция или кому направлен документ", "Роспись исполнителя в получении", "Срок исполнения", "Отметка о постановке на контроль", "Отметка об исполнении", "Примечание"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
        Me.ToolStripComboBox1.ToolTipText = "Выбрать поля фильтра"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        Me.ToolStripTextBox1.ToolTipText = "Текст фильтра"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        Me.ToolStripButton3.ToolTipText = "Удалить фильтр"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОбновитьToolStripMenuItem1, Me.ДобавитьЗаписьToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(167, 48)
        '
        'ОбновитьToolStripMenuItem1
        '
        Me.ОбновитьToolStripMenuItem1.Image = CType(resources.GetObject("ОбновитьToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ОбновитьToolStripMenuItem1.Name = "ОбновитьToolStripMenuItem1"
        Me.ОбновитьToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.ОбновитьToolStripMenuItem1.Text = "Обновить"
        '
        'ДобавитьЗаписьToolStripMenuItem
        '
        Me.ДобавитьЗаписьToolStripMenuItem.Image = CType(resources.GetObject("ДобавитьЗаписьToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ДобавитьЗаписьToolStripMenuItem.Name = "ДобавитьЗаписьToolStripMenuItem"
        Me.ДобавитьЗаписьToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ДобавитьЗаписьToolStripMenuItem.Text = "Добавить запись"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПолучитьКарточкуToolStripMenuItem, Me.УдалитьЗаписьToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 48)
        '
        'ПолучитьКарточкуToolStripMenuItem
        '
        Me.ПолучитьКарточкуToolStripMenuItem.Image = CType(resources.GetObject("ПолучитьКарточкуToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ПолучитьКарточкуToolStripMenuItem.Name = "ПолучитьКарточкуToolStripMenuItem"
        Me.ПолучитьКарточкуToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ПолучитьКарточкуToolStripMenuItem.Text = "Получить карточку"
        '
        'УдалитьЗаписьToolStripMenuItem
        '
        Me.УдалитьЗаписьToolStripMenuItem.Image = CType(resources.GetObject("УдалитьЗаписьToolStripMenuItem.Image"), System.Drawing.Image)
        Me.УдалитьЗаписьToolStripMenuItem.Name = "УдалитьЗаписьToolStripMenuItem"
        Me.УдалитьЗаписьToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.УдалитьЗаписьToolStripMenuItem.Text = "Удалить запись..."
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.МенюИсходящихToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(311, 1)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(119, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'МенюИсходящихToolStripMenuItem
        '
        Me.МенюИсходящихToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ОбновитьToolStripMenuItem, Me.ФильтрToolStripMenuItem, Me.ЭкспортWORDToolStripMenuItem, Me.ЭкспортExcelToolStripMenuItem, Me.ToolStripMenuItem1, Me.ВыходToolStripMenuItem})
        Me.МенюИсходящихToolStripMenuItem.Name = "МенюИсходящихToolStripMenuItem"
        Me.МенюИсходящихToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
        Me.МенюИсходящихToolStripMenuItem.Text = "Меню входящих"
        '
        'ОбновитьToolStripMenuItem
        '
        Me.ОбновитьToolStripMenuItem.Name = "ОбновитьToolStripMenuItem"
        Me.ОбновитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ОбновитьToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ОбновитьToolStripMenuItem.Text = "Обновить"
        '
        'ФильтрToolStripMenuItem
        '
        Me.ФильтрToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.УбратьКолонкуToolStripMenuItem, Me.ПоискПоНомеруToolStripMenuItem, Me.ВыключитьФильтрToolStripMenuItem, Me.ПоискПоДатеToolStripMenuItem})
        Me.ФильтрToolStripMenuItem.Name = "ФильтрToolStripMenuItem"
        Me.ФильтрToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ФильтрToolStripMenuItem.Text = "Фильтр"
        '
        'УбратьКолонкуToolStripMenuItem
        '
        Me.УбратьКолонкуToolStripMenuItem.Name = "УбратьКолонкуToolStripMenuItem"
        Me.УбратьКолонкуToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.УбратьКолонкуToolStripMenuItem.Text = "Убрать колонку"
        '
        'ПоискПоНомеруToolStripMenuItem
        '
        Me.ПоискПоНомеруToolStripMenuItem.Image = CType(resources.GetObject("ПоискПоНомеруToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ПоискПоНомеруToolStripMenuItem.Name = "ПоискПоНомеруToolStripMenuItem"
        Me.ПоискПоНомеруToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ПоискПоНомеруToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ПоискПоНомеруToolStripMenuItem.Text = "Поиск по номеру"
        '
        'ВыключитьФильтрToolStripMenuItem
        '
        Me.ВыключитьФильтрToolStripMenuItem.Name = "ВыключитьФильтрToolStripMenuItem"
        Me.ВыключитьФильтрToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ВыключитьФильтрToolStripMenuItem.Text = "Выключить фильтр"
        '
        'ПоискПоДатеToolStripMenuItem
        '
        Me.ПоискПоДатеToolStripMenuItem.Name = "ПоискПоДатеToolStripMenuItem"
        Me.ПоискПоДатеToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ПоискПоДатеToolStripMenuItem.Text = "Поиск по дате"
        '
        'ЭкспортWORDToolStripMenuItem
        '
        Me.ЭкспортWORDToolStripMenuItem.Image = CType(resources.GetObject("ЭкспортWORDToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ЭкспортWORDToolStripMenuItem.Name = "ЭкспортWORDToolStripMenuItem"
        Me.ЭкспортWORDToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.ЭкспортWORDToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ЭкспортWORDToolStripMenuItem.Text = "Экспорт Word"
        '
        'ЭкспортExcelToolStripMenuItem
        '
        Me.ЭкспортExcelToolStripMenuItem.Name = "ЭкспортExcelToolStripMenuItem"
        Me.ЭкспортExcelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ЭкспортExcelToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ЭкспортExcelToolStripMenuItem.Text = "Экспорт Excel"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(193, 6)
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ВыходToolStripMenuItem.Text = "Выход"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 467)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Входящие"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ОбновитьToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ДобавитьЗаписьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ПолучитьКарточкуToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents УдалитьЗаписьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents МенюИсходящихToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ОбновитьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ФильтрToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents УбратьКолонкуToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПоискПоНомеруToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВыключитьФильтрToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПоискПоДатеToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЭкспортWORDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЭкспортExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ВыходToolStripMenuItem As ToolStripMenuItem
End Class
