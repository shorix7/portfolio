<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.bOpenFile = New System.Windows.Forms.Button()
        Me.bPrint = New System.Windows.Forms.Button()
        Me.bPreview = New System.Windows.Forms.Button()
        Me.bExit = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Имя файла"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(177, 20)
        Me.TextBox1.TabIndex = 1
        '
        'bOpenFile
        '
        Me.bOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bOpenFile.Location = New System.Drawing.Point(203, 23)
        Me.bOpenFile.Name = "bOpenFile"
        Me.bOpenFile.Size = New System.Drawing.Size(21, 20)
        Me.bOpenFile.TabIndex = 2
        Me.bOpenFile.Text = "..."
        Me.bOpenFile.UseVisualStyleBackColor = True
        '
        'bPrint
        '
        Me.bPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bPrint.Location = New System.Drawing.Point(88, 49)
        Me.bPrint.Name = "bPrint"
        Me.bPrint.Size = New System.Drawing.Size(66, 23)
        Me.bPrint.TabIndex = 3
        Me.bPrint.Text = "Печать"
        Me.bPrint.UseVisualStyleBackColor = True
        '
        'bPreview
        '
        Me.bPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bPreview.Location = New System.Drawing.Point(10, 49)
        Me.bPreview.Name = "bPreview"
        Me.bPreview.Size = New System.Drawing.Size(72, 23)
        Me.bPreview.TabIndex = 4
        Me.bPreview.Text = "Просмотр"
        Me.bPreview.UseVisualStyleBackColor = True
        '
        'bExit
        '
        Me.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bExit.Location = New System.Drawing.Point(160, 49)
        Me.bExit.Name = "bExit"
        Me.bExit.Size = New System.Drawing.Size(64, 23)
        Me.bExit.TabIndex = 5
        Me.bExit.Text = "Выход"
        Me.bExit.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'frmPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(236, 84)
        Me.Controls.Add(Me.bExit)
        Me.Controls.Add(Me.bPreview)
        Me.Controls.Add(Me.bPrint)
        Me.Controls.Add(Me.bOpenFile)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Печать файла"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents bOpenFile As Button
    Friend WithEvents bPrint As Button
    Friend WithEvents bPreview As Button
    Friend WithEvents bExit As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
