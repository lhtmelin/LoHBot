<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedHireFuse
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
        Me.chkAnimation = New System.Windows.Forms.CheckBox()
        Me.chkExtract = New System.Windows.Forms.CheckBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'chkAnimation
        '
        Me.chkAnimation.AutoSize = True
        Me.chkAnimation.Checked = True
        Me.chkAnimation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnimation.Location = New System.Drawing.Point(12, 12)
        Me.chkAnimation.Name = "chkAnimation"
        Me.chkAnimation.Size = New System.Drawing.Size(192, 17)
        Me.chkAnimation.TabIndex = 0
        Me.chkAnimation.Text = "Activate animation bug (faster fuse)"
        Me.chkAnimation.UseVisualStyleBackColor = True
        '
        'chkExtract
        '
        Me.chkExtract.AutoSize = True
        Me.chkExtract.Checked = True
        Me.chkExtract.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExtract.Location = New System.Drawing.Point(12, 35)
        Me.chkExtract.Name = "chkExtract"
        Me.chkExtract.Size = New System.Drawing.Size(173, 17)
        Me.chkExtract.TabIndex = 1
        Me.chkExtract.Text = "Extract essence from 6* heroes"
        Me.chkExtract.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(281, 12)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(362, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(575, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLog.Location = New System.Drawing.Point(12, 58)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(638, 350)
        Me.txtLog.TabIndex = 5
        Me.txtLog.WordWrap = False
        '
        'AdvancedHireFuse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 420)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.chkExtract)
        Me.Controls.Add(Me.chkAnimation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdvancedHireFuse"
        Me.Text = "Advanced Hire & Fuse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkAnimation As CheckBox
    Friend WithEvents chkExtract As CheckBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtLog As TextBox
End Class
