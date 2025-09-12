<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.cmbLanguage = New System.Windows.Forms.ComboBox()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.txtNumberToConvert = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtAllResults = New System.Windows.Forms.TextBox()
        Me.btnAutomatedTest = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 426)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblResults)
        Me.TabPage1.Controls.Add(Me.cmbCurrency)
        Me.TabPage1.Controls.Add(Me.cmbLanguage)
        Me.TabPage1.Controls.Add(Me.btnConvert)
        Me.TabPage1.Controls.Add(Me.txtNumberToConvert)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 400)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Number Conversion Tester"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblResults
        '
        Me.lblResults.BackColor = System.Drawing.Color.White
        Me.lblResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResults.Location = New System.Drawing.Point(6, 47)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(756, 339)
        Me.lblResults.TabIndex = 5
        Me.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbCurrency
        '
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Items.AddRange(New Object() {"Dollars", "Pesos"})
        Me.cmbCurrency.Location = New System.Drawing.Point(560, 22)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(121, 21)
        Me.cmbCurrency.TabIndex = 4
        Me.cmbCurrency.Text = "Dollars"
        '
        'cmbLanguage
        '
        Me.cmbLanguage.FormattingEnabled = True
        Me.cmbLanguage.Items.AddRange(New Object() {"English", "Spanish"})
        Me.cmbLanguage.Location = New System.Drawing.Point(433, 22)
        Me.cmbLanguage.Name = "cmbLanguage"
        Me.cmbLanguage.Size = New System.Drawing.Size(121, 21)
        Me.cmbLanguage.TabIndex = 3
        Me.cmbLanguage.Text = "English"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(687, 21)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 2
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'txtNumberToConvert
        '
        Me.txtNumberToConvert.Location = New System.Drawing.Point(110, 23)
        Me.txtNumberToConvert.Name = "txtNumberToConvert"
        Me.txtNumberToConvert.Size = New System.Drawing.Size(317, 20)
        Me.txtNumberToConvert.TabIndex = 1
        Me.txtNumberToConvert.Text = "12345.67"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number to convert:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAllResults)
        Me.TabPage2.Controls.Add(Me.btnAutomatedTest)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(768, 400)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Automated Tester"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAllResults
        '
        Me.txtAllResults.BackColor = System.Drawing.Color.White
        Me.txtAllResults.Location = New System.Drawing.Point(6, 35)
        Me.txtAllResults.Multiline = True
        Me.txtAllResults.Name = "txtAllResults"
        Me.txtAllResults.ReadOnly = True
        Me.txtAllResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAllResults.Size = New System.Drawing.Size(756, 353)
        Me.txtAllResults.TabIndex = 10
        '
        'btnAutomatedTest
        '
        Me.btnAutomatedTest.Location = New System.Drawing.Point(541, 6)
        Me.btnAutomatedTest.Name = "btnAutomatedTest"
        Me.btnAutomatedTest.Size = New System.Drawing.Size(204, 23)
        Me.btnAutomatedTest.TabIndex = 9
        Me.btnAutomatedTest.Text = "Test all currencies and languages"
        Me.btnAutomatedTest.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Main"
        Me.Text = "Number To Words Converter Tester - .NET Framework 4.72 or higher"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents cmbCurrency As ComboBox
    Friend WithEvents cmbLanguage As ComboBox
    Friend WithEvents btnConvert As Button
    Friend WithEvents txtNumberToConvert As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblResults As Label
    Friend WithEvents btnAutomatedTest As Button
    Friend WithEvents txtAllResults As TextBox
End Class
