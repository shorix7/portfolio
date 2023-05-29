<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.ButtonCreateData = New System.Windows.Forms.Button()
        Me.ButtonClearDGV = New System.Windows.Forms.Button()
        Me.ButtonExportToExcel = New System.Windows.Forms.Button()
        Me.ButtonImportFromExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNumberOfRows = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonCreateData
        '
        Me.ButtonCreateData.Location = New System.Drawing.Point(12, 12)
        Me.ButtonCreateData.Name = "ButtonCreateData"
        Me.ButtonCreateData.Size = New System.Drawing.Size(105, 23)
        Me.ButtonCreateData.TabIndex = 0
        Me.ButtonCreateData.Text = "Задать значения"
        Me.ButtonCreateData.UseVisualStyleBackColor = True
        '
        'ButtonClearDGV
        '
        Me.ButtonClearDGV.Location = New System.Drawing.Point(318, 11)
        Me.ButtonClearDGV.Name = "ButtonClearDGV"
        Me.ButtonClearDGV.Size = New System.Drawing.Size(180, 23)
        Me.ButtonClearDGV.TabIndex = 1
        Me.ButtonClearDGV.Text = "Очистить и привести к шаблону"
        Me.ButtonClearDGV.UseVisualStyleBackColor = True
        '
        'ButtonExportToExcel
        '
        Me.ButtonExportToExcel.Location = New System.Drawing.Point(504, 11)
        Me.ButtonExportToExcel.Name = "ButtonExportToExcel"
        Me.ButtonExportToExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportToExcel.TabIndex = 2
        Me.ButtonExportToExcel.Text = "Экспорт"
        Me.ButtonExportToExcel.UseVisualStyleBackColor = True
        '
        'ButtonImportFromExcel
        '
        Me.ButtonImportFromExcel.Location = New System.Drawing.Point(585, 11)
        Me.ButtonImportFromExcel.Name = "ButtonImportFromExcel"
        Me.ButtonImportFromExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImportFromExcel.TabIndex = 3
        Me.ButtonImportFromExcel.Text = "Импорт"
        Me.ButtonImportFromExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Количество строк :"
        '
        'TextBoxNumberOfRows
        '
        Me.TextBoxNumberOfRows.Location = New System.Drawing.Point(233, 14)
        Me.TextBoxNumberOfRows.Name = "TextBoxNumberOfRows"
        Me.TextBoxNumberOfRows.Size = New System.Drawing.Size(79, 20)
        Me.TextBoxNumberOfRows.TabIndex = 5
        Me.TextBoxNumberOfRows.Text = "10"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(648, 424)
        Me.DataGridView1.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 477)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBoxNumberOfRows)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonImportFromExcel)
        Me.Controls.Add(Me.ButtonExportToExcel)
        Me.Controls.Add(Me.ButtonClearDGV)
        Me.Controls.Add(Me.ButtonCreateData)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCreateData As Button
    Friend WithEvents ButtonClearDGV As Button
    Friend WithEvents ButtonExportToExcel As Button
    Friend WithEvents ButtonImportFromExcel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNumberOfRows As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
