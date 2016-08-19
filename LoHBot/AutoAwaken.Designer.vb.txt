<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoAwaken
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
        Me.gbBaseHero = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtNectarRequired = New System.Windows.Forms.TextBox()
        Me.lblNectarRequired = New System.Windows.Forms.Label()
        Me.txtNectarOwned = New System.Windows.Forms.TextBox()
        Me.lblNectarOwned = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.gbLog = New System.Windows.Forms.GroupBox()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.udINT = New System.Windows.Forms.NumericUpDown()
        Me.udVIT = New System.Windows.Forms.NumericUpDown()
        Me.udAGI = New System.Windows.Forms.NumericUpDown()
        Me.lblStatIncValue = New System.Windows.Forms.Label()
        Me.udSTR = New System.Windows.Forms.NumericUpDown()
        Me.chkIncINT = New System.Windows.Forms.CheckBox()
        Me.chkIncVIT = New System.Windows.Forms.CheckBox()
        Me.chkIncAGI = New System.Windows.Forms.CheckBox()
        Me.chkIncSTR = New System.Windows.Forms.CheckBox()
        Me.lblStatInc = New System.Windows.Forms.Label()
        Me.chkRedINT = New System.Windows.Forms.CheckBox()
        Me.chkRedVIT = New System.Windows.Forms.CheckBox()
        Me.chkRedAGI = New System.Windows.Forms.CheckBox()
        Me.chkRedSTR = New System.Windows.Forms.CheckBox()
        Me.lblStatRed = New System.Windows.Forms.Label()
        Me.chkRing = New System.Windows.Forms.CheckBox()
        Me.txtINT = New System.Windows.Forms.TextBox()
        Me.lblINT = New System.Windows.Forms.Label()
        Me.txtVIT = New System.Windows.Forms.TextBox()
        Me.lblVIT = New System.Windows.Forms.Label()
        Me.txtAGI = New System.Windows.Forms.TextBox()
        Me.lblAGI = New System.Windows.Forms.Label()
        Me.txtSTR = New System.Windows.Forms.TextBox()
        Me.lblSTR = New System.Windows.Forms.Label()
        Me.lblBaseStats = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.picHero = New System.Windows.Forms.PictureBox()
        Me.gbBaseHero.SuspendLayout()
        Me.gbLog.SuspendLayout()
        CType(Me.udINT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udVIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSTR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbBaseHero
        '
        Me.gbBaseHero.Controls.Add(Me.btnRefresh)
        Me.gbBaseHero.Controls.Add(Me.txtNectarRequired)
        Me.gbBaseHero.Controls.Add(Me.lblNectarRequired)
        Me.gbBaseHero.Controls.Add(Me.txtNectarOwned)
        Me.gbBaseHero.Controls.Add(Me.lblNectarOwned)
        Me.gbBaseHero.Controls.Add(Me.btnStop)
        Me.gbBaseHero.Controls.Add(Me.btnStart)
        Me.gbBaseHero.Controls.Add(Me.gbLog)
        Me.gbBaseHero.Controls.Add(Me.udINT)
        Me.gbBaseHero.Controls.Add(Me.udVIT)
        Me.gbBaseHero.Controls.Add(Me.udAGI)
        Me.gbBaseHero.Controls.Add(Me.lblStatIncValue)
        Me.gbBaseHero.Controls.Add(Me.udSTR)
        Me.gbBaseHero.Controls.Add(Me.chkIncINT)
        Me.gbBaseHero.Controls.Add(Me.chkIncVIT)
        Me.gbBaseHero.Controls.Add(Me.chkIncAGI)
        Me.gbBaseHero.Controls.Add(Me.chkIncSTR)
        Me.gbBaseHero.Controls.Add(Me.lblStatInc)
        Me.gbBaseHero.Controls.Add(Me.chkRedINT)
        Me.gbBaseHero.Controls.Add(Me.chkRedVIT)
        Me.gbBaseHero.Controls.Add(Me.chkRedAGI)
        Me.gbBaseHero.Controls.Add(Me.chkRedSTR)
        Me.gbBaseHero.Controls.Add(Me.lblStatRed)
        Me.gbBaseHero.Controls.Add(Me.chkRing)
        Me.gbBaseHero.Controls.Add(Me.txtINT)
        Me.gbBaseHero.Controls.Add(Me.lblINT)
        Me.gbBaseHero.Controls.Add(Me.txtVIT)
        Me.gbBaseHero.Controls.Add(Me.lblVIT)
        Me.gbBaseHero.Controls.Add(Me.txtAGI)
        Me.gbBaseHero.Controls.Add(Me.lblAGI)
        Me.gbBaseHero.Controls.Add(Me.txtSTR)
        Me.gbBaseHero.Controls.Add(Me.lblSTR)
        Me.gbBaseHero.Controls.Add(Me.lblBaseStats)
        Me.gbBaseHero.Controls.Add(Me.txtName)
        Me.gbBaseHero.Controls.Add(Me.lblName)
        Me.gbBaseHero.Controls.Add(Me.picHero)
        Me.gbBaseHero.Location = New System.Drawing.Point(12, 12)
        Me.gbBaseHero.Name = "gbBaseHero"
        Me.gbBaseHero.Size = New System.Drawing.Size(798, 585)
        Me.gbBaseHero.TabIndex = 0
        Me.gbBaseHero.TabStop = False
        Me.gbBaseHero.Text = "Base Hero"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(252, 373)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(125, 23)
        Me.btnRefresh.TabIndex = 35
        Me.btnRefresh.Text = "Refresh Hero Info"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'txtNectarRequired
        '
        Me.txtNectarRequired.Location = New System.Drawing.Point(107, 401)
        Me.txtNectarRequired.Name = "txtNectarRequired"
        Me.txtNectarRequired.ReadOnly = True
        Me.txtNectarRequired.Size = New System.Drawing.Size(84, 20)
        Me.txtNectarRequired.TabIndex = 34
        Me.txtNectarRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNectarRequired
        '
        Me.lblNectarRequired.AutoSize = True
        Me.lblNectarRequired.Location = New System.Drawing.Point(9, 404)
        Me.lblNectarRequired.Name = "lblNectarRequired"
        Me.lblNectarRequired.Size = New System.Drawing.Size(85, 13)
        Me.lblNectarRequired.TabIndex = 33
        Me.lblNectarRequired.Text = "Required Nectar"
        '
        'txtNectarOwned
        '
        Me.txtNectarOwned.Location = New System.Drawing.Point(107, 375)
        Me.txtNectarOwned.Name = "txtNectarOwned"
        Me.txtNectarOwned.ReadOnly = True
        Me.txtNectarOwned.Size = New System.Drawing.Size(84, 20)
        Me.txtNectarOwned.TabIndex = 32
        Me.txtNectarOwned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNectarOwned
        '
        Me.lblNectarOwned.AutoSize = True
        Me.lblNectarOwned.Location = New System.Drawing.Point(9, 378)
        Me.lblNectarOwned.Name = "lblNectarOwned"
        Me.lblNectarOwned.Size = New System.Drawing.Size(76, 13)
        Me.lblNectarOwned.TabIndex = 31
        Me.lblNectarOwned.Text = "Nectar Owned"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(717, 240)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 30
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(636, 240)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 29
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'gbLog
        '
        Me.gbLog.Controls.Add(Me.txtLog)
        Me.gbLog.Location = New System.Drawing.Point(383, 269)
        Me.gbLog.Name = "gbLog"
        Me.gbLog.Size = New System.Drawing.Size(409, 310)
        Me.gbLog.TabIndex = 28
        Me.gbLog.TabStop = False
        Me.gbLog.Text = "Awaken Log"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLog.Location = New System.Drawing.Point(3, 16)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(403, 291)
        Me.txtLog.TabIndex = 1
        Me.txtLog.WordWrap = False
        '
        'udINT
        '
        Me.udINT.Enabled = False
        Me.udINT.Location = New System.Drawing.Point(707, 168)
        Me.udINT.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.udINT.Name = "udINT"
        Me.udINT.Size = New System.Drawing.Size(85, 20)
        Me.udINT.TabIndex = 27
        Me.udINT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'udVIT
        '
        Me.udVIT.Enabled = False
        Me.udVIT.Location = New System.Drawing.Point(707, 142)
        Me.udVIT.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.udVIT.Name = "udVIT"
        Me.udVIT.Size = New System.Drawing.Size(85, 20)
        Me.udVIT.TabIndex = 26
        Me.udVIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'udAGI
        '
        Me.udAGI.Enabled = False
        Me.udAGI.Location = New System.Drawing.Point(707, 114)
        Me.udAGI.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.udAGI.Name = "udAGI"
        Me.udAGI.Size = New System.Drawing.Size(85, 20)
        Me.udAGI.TabIndex = 25
        Me.udAGI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStatIncValue
        '
        Me.lblStatIncValue.Location = New System.Drawing.Point(704, 53)
        Me.lblStatIncValue.Name = "lblStatIncValue"
        Me.lblStatIncValue.Size = New System.Drawing.Size(70, 30)
        Me.lblStatIncValue.TabIndex = 24
        Me.lblStatIncValue.Text = "Min Increase Value"
        Me.lblStatIncValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'udSTR
        '
        Me.udSTR.Enabled = False
        Me.udSTR.Location = New System.Drawing.Point(707, 88)
        Me.udSTR.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.udSTR.Name = "udSTR"
        Me.udSTR.Size = New System.Drawing.Size(85, 20)
        Me.udSTR.TabIndex = 23
        Me.udSTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkIncINT
        '
        Me.chkIncINT.AutoSize = True
        Me.chkIncINT.Location = New System.Drawing.Point(645, 170)
        Me.chkIncINT.Name = "chkIncINT"
        Me.chkIncINT.Size = New System.Drawing.Size(15, 14)
        Me.chkIncINT.TabIndex = 22
        Me.chkIncINT.UseVisualStyleBackColor = True
        '
        'chkIncVIT
        '
        Me.chkIncVIT.AutoSize = True
        Me.chkIncVIT.Location = New System.Drawing.Point(645, 144)
        Me.chkIncVIT.Name = "chkIncVIT"
        Me.chkIncVIT.Size = New System.Drawing.Size(15, 14)
        Me.chkIncVIT.TabIndex = 21
        Me.chkIncVIT.UseVisualStyleBackColor = True
        '
        'chkIncAGI
        '
        Me.chkIncAGI.AutoSize = True
        Me.chkIncAGI.Location = New System.Drawing.Point(645, 118)
        Me.chkIncAGI.Name = "chkIncAGI"
        Me.chkIncAGI.Size = New System.Drawing.Size(15, 14)
        Me.chkIncAGI.TabIndex = 20
        Me.chkIncAGI.UseVisualStyleBackColor = True
        '
        'chkIncSTR
        '
        Me.chkIncSTR.AutoSize = True
        Me.chkIncSTR.Location = New System.Drawing.Point(645, 94)
        Me.chkIncSTR.Name = "chkIncSTR"
        Me.chkIncSTR.Size = New System.Drawing.Size(15, 14)
        Me.chkIncSTR.TabIndex = 19
        Me.chkIncSTR.UseVisualStyleBackColor = True
        '
        'lblStatInc
        '
        Me.lblStatInc.Location = New System.Drawing.Point(622, 53)
        Me.lblStatInc.Name = "lblStatInc"
        Me.lblStatInc.Size = New System.Drawing.Size(70, 30)
        Me.lblStatInc.TabIndex = 18
        Me.lblStatInc.Text = "Required Stat Increase"
        Me.lblStatInc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkRedINT
        '
        Me.chkRedINT.AutoSize = True
        Me.chkRedINT.Location = New System.Drawing.Point(569, 170)
        Me.chkRedINT.Name = "chkRedINT"
        Me.chkRedINT.Size = New System.Drawing.Size(15, 14)
        Me.chkRedINT.TabIndex = 17
        Me.chkRedINT.UseVisualStyleBackColor = True
        '
        'chkRedVIT
        '
        Me.chkRedVIT.AutoSize = True
        Me.chkRedVIT.Location = New System.Drawing.Point(569, 144)
        Me.chkRedVIT.Name = "chkRedVIT"
        Me.chkRedVIT.Size = New System.Drawing.Size(15, 14)
        Me.chkRedVIT.TabIndex = 16
        Me.chkRedVIT.UseVisualStyleBackColor = True
        '
        'chkRedAGI
        '
        Me.chkRedAGI.AutoSize = True
        Me.chkRedAGI.Location = New System.Drawing.Point(569, 118)
        Me.chkRedAGI.Name = "chkRedAGI"
        Me.chkRedAGI.Size = New System.Drawing.Size(15, 14)
        Me.chkRedAGI.TabIndex = 15
        Me.chkRedAGI.UseVisualStyleBackColor = True
        '
        'chkRedSTR
        '
        Me.chkRedSTR.AutoSize = True
        Me.chkRedSTR.Location = New System.Drawing.Point(569, 94)
        Me.chkRedSTR.Name = "chkRedSTR"
        Me.chkRedSTR.Size = New System.Drawing.Size(15, 14)
        Me.chkRedSTR.TabIndex = 14
        Me.chkRedSTR.UseVisualStyleBackColor = True
        '
        'lblStatRed
        '
        Me.lblStatRed.Location = New System.Drawing.Point(546, 53)
        Me.lblStatRed.Name = "lblStatRed"
        Me.lblStatRed.Size = New System.Drawing.Size(70, 30)
        Me.lblStatRed.TabIndex = 13
        Me.lblStatRed.Text = "Protect Stat Reduction"
        Me.lblStatRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkRing
        '
        Me.chkRing.AutoSize = True
        Me.chkRing.Location = New System.Drawing.Point(569, 207)
        Me.chkRing.Name = "chkRing"
        Me.chkRing.Size = New System.Drawing.Size(152, 17)
        Me.chkRing.TabIndex = 12
        Me.chkRing.Text = "Ring slot must be opened?"
        Me.chkRing.UseVisualStyleBackColor = True
        '
        'txtINT
        '
        Me.txtINT.Location = New System.Drawing.Point(455, 170)
        Me.txtINT.Name = "txtINT"
        Me.txtINT.ReadOnly = True
        Me.txtINT.Size = New System.Drawing.Size(84, 20)
        Me.txtINT.TabIndex = 11
        Me.txtINT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblINT
        '
        Me.lblINT.AutoSize = True
        Me.lblINT.Location = New System.Drawing.Point(384, 173)
        Me.lblINT.Name = "lblINT"
        Me.lblINT.Size = New System.Drawing.Size(28, 13)
        Me.lblINT.TabIndex = 10
        Me.lblINT.Text = "INT:"
        '
        'txtVIT
        '
        Me.txtVIT.Location = New System.Drawing.Point(455, 144)
        Me.txtVIT.Name = "txtVIT"
        Me.txtVIT.ReadOnly = True
        Me.txtVIT.Size = New System.Drawing.Size(84, 20)
        Me.txtVIT.TabIndex = 9
        Me.txtVIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVIT
        '
        Me.lblVIT.AutoSize = True
        Me.lblVIT.Location = New System.Drawing.Point(384, 147)
        Me.lblVIT.Name = "lblVIT"
        Me.lblVIT.Size = New System.Drawing.Size(27, 13)
        Me.lblVIT.TabIndex = 8
        Me.lblVIT.Text = "VIT:"
        '
        'txtAGI
        '
        Me.txtAGI.Location = New System.Drawing.Point(455, 118)
        Me.txtAGI.Name = "txtAGI"
        Me.txtAGI.ReadOnly = True
        Me.txtAGI.Size = New System.Drawing.Size(84, 20)
        Me.txtAGI.TabIndex = 7
        Me.txtAGI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAGI
        '
        Me.lblAGI.AutoSize = True
        Me.lblAGI.Location = New System.Drawing.Point(384, 121)
        Me.lblAGI.Name = "lblAGI"
        Me.lblAGI.Size = New System.Drawing.Size(28, 13)
        Me.lblAGI.TabIndex = 6
        Me.lblAGI.Text = "AGI:"
        '
        'txtSTR
        '
        Me.txtSTR.Location = New System.Drawing.Point(455, 92)
        Me.txtSTR.Name = "txtSTR"
        Me.txtSTR.ReadOnly = True
        Me.txtSTR.Size = New System.Drawing.Size(84, 20)
        Me.txtSTR.TabIndex = 5
        Me.txtSTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSTR
        '
        Me.lblSTR.AutoSize = True
        Me.lblSTR.Location = New System.Drawing.Point(384, 95)
        Me.lblSTR.Name = "lblSTR"
        Me.lblSTR.Size = New System.Drawing.Size(32, 13)
        Me.lblSTR.TabIndex = 4
        Me.lblSTR.Text = "STR:"
        '
        'lblBaseStats
        '
        Me.lblBaseStats.AutoSize = True
        Me.lblBaseStats.Location = New System.Drawing.Point(384, 62)
        Me.lblBaseStats.Name = "lblBaseStats"
        Me.lblBaseStats.Size = New System.Drawing.Size(61, 13)
        Me.lblBaseStats.TabIndex = 3
        Me.lblBaseStats.Text = "Base Stats:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(454, 17)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(283, 20)
        Me.txtName.TabIndex = 2
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(384, 20)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(64, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Hero Name:"
        '
        'picHero
        '
        Me.picHero.Location = New System.Drawing.Point(6, 19)
        Me.picHero.Name = "picHero"
        Me.picHero.Size = New System.Drawing.Size(371, 350)
        Me.picHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHero.TabIndex = 0
        Me.picHero.TabStop = False
        '
        'AutoAwaken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 609)
        Me.Controls.Add(Me.gbBaseHero)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AutoAwaken"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto Awaken"
        Me.gbBaseHero.ResumeLayout(False)
        Me.gbBaseHero.PerformLayout()
        Me.gbLog.ResumeLayout(False)
        Me.gbLog.PerformLayout()
        CType(Me.udINT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udVIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSTR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBaseHero As System.Windows.Forms.GroupBox
    Friend WithEvents picHero As System.Windows.Forms.PictureBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtINT As System.Windows.Forms.TextBox
    Friend WithEvents lblINT As System.Windows.Forms.Label
    Friend WithEvents txtVIT As System.Windows.Forms.TextBox
    Friend WithEvents lblVIT As System.Windows.Forms.Label
    Friend WithEvents txtAGI As System.Windows.Forms.TextBox
    Friend WithEvents lblAGI As System.Windows.Forms.Label
    Friend WithEvents txtSTR As System.Windows.Forms.TextBox
    Friend WithEvents lblSTR As System.Windows.Forms.Label
    Friend WithEvents lblBaseStats As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents chkRing As System.Windows.Forms.CheckBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents gbLog As System.Windows.Forms.GroupBox
    Friend WithEvents udINT As System.Windows.Forms.NumericUpDown
    Friend WithEvents udVIT As System.Windows.Forms.NumericUpDown
    Friend WithEvents udAGI As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStatIncValue As System.Windows.Forms.Label
    Friend WithEvents udSTR As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkIncINT As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncVIT As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncAGI As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncSTR As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatInc As System.Windows.Forms.Label
    Friend WithEvents chkRedINT As System.Windows.Forms.CheckBox
    Friend WithEvents chkRedVIT As System.Windows.Forms.CheckBox
    Friend WithEvents chkRedAGI As System.Windows.Forms.CheckBox
    Friend WithEvents chkRedSTR As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatRed As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents txtNectarRequired As System.Windows.Forms.TextBox
    Friend WithEvents lblNectarRequired As System.Windows.Forms.Label
    Friend WithEvents txtNectarOwned As System.Windows.Forms.TextBox
    Friend WithEvents lblNectarOwned As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
