<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterSetup
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
        Me.txtValMin = New System.Windows.Forms.TextBox()
        Me.txtSatMin = New System.Windows.Forms.TextBox()
        Me.txtHueMin = New System.Windows.Forms.TextBox()
        Me.tbValMin = New System.Windows.Forms.TrackBar()
        Me.lblVal = New System.Windows.Forms.Label()
        Me.tbSatMin = New System.Windows.Forms.TrackBar()
        Me.lblSat = New System.Windows.Forms.Label()
        Me.tbHueMin = New System.Windows.Forms.TrackBar()
        Me.lblHue = New System.Windows.Forms.Label()
        Me.lblMinValue = New System.Windows.Forms.Label()
        Me.lblMaxValue = New System.Windows.Forms.Label()
        Me.txtValMax = New System.Windows.Forms.TextBox()
        Me.txtSatMax = New System.Windows.Forms.TextBox()
        Me.txtHueMax = New System.Windows.Forms.TextBox()
        Me.tbValMax = New System.Windows.Forms.TrackBar()
        Me.tbSatMax = New System.Windows.Forms.TrackBar()
        Me.tbHueMax = New System.Windows.Forms.TrackBar()
        Me.gbTarget = New System.Windows.Forms.GroupBox()
        Me.lblTargetMax = New System.Windows.Forms.Label()
        Me.lblTargetMin = New System.Windows.Forms.Label()
        Me.udTargetSizeMax = New System.Windows.Forms.NumericUpDown()
        Me.udTargetAspectRatioMax = New System.Windows.Forms.NumericUpDown()
        Me.udTargetSizeMin = New System.Windows.Forms.NumericUpDown()
        Me.udTargetAspectRatioMin = New System.Windows.Forms.NumericUpDown()
        Me.lblTargetAspectRatio = New System.Windows.Forms.Label()
        Me.lblTargetAspectSize = New System.Windows.Forms.Label()
        Me.udBlur = New System.Windows.Forms.NumericUpDown()
        Me.udDilate = New System.Windows.Forms.NumericUpDown()
        Me.udErode = New System.Windows.Forms.NumericUpDown()
        Me.chkCleanup = New System.Windows.Forms.CheckBox()
        Me.chkErode = New System.Windows.Forms.CheckBox()
        Me.chkDilate = New System.Windows.Forms.CheckBox()
        Me.chkBlur = New System.Windows.Forms.CheckBox()
        CType(Me.tbValMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSatMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHueMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbValMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSatMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHueMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTarget.SuspendLayout()
        CType(Me.udTargetSizeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTargetAspectRatioMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTargetSizeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTargetAspectRatioMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udBlur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udDilate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udErode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtValMin
        '
        Me.txtValMin.Location = New System.Drawing.Point(209, 89)
        Me.txtValMin.Name = "txtValMin"
        Me.txtValMin.Size = New System.Drawing.Size(47, 20)
        Me.txtValMin.TabIndex = 17
        Me.txtValMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSatMin
        '
        Me.txtSatMin.Location = New System.Drawing.Point(209, 60)
        Me.txtSatMin.Name = "txtSatMin"
        Me.txtSatMin.Size = New System.Drawing.Size(47, 20)
        Me.txtSatMin.TabIndex = 16
        Me.txtSatMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHueMin
        '
        Me.txtHueMin.Location = New System.Drawing.Point(209, 31)
        Me.txtHueMin.Name = "txtHueMin"
        Me.txtHueMin.Size = New System.Drawing.Size(47, 20)
        Me.txtHueMin.TabIndex = 15
        Me.txtHueMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbValMin
        '
        Me.tbValMin.AutoSize = False
        Me.tbValMin.Location = New System.Drawing.Point(45, 87)
        Me.tbValMin.Maximum = 255
        Me.tbValMin.Name = "tbValMin"
        Me.tbValMin.Size = New System.Drawing.Size(158, 23)
        Me.tbValMin.TabIndex = 14
        Me.tbValMin.TickFrequency = 10
        '
        'lblVal
        '
        Me.lblVal.AutoSize = True
        Me.lblVal.Location = New System.Drawing.Point(12, 92)
        Me.lblVal.Name = "lblVal"
        Me.lblVal.Size = New System.Drawing.Size(22, 13)
        Me.lblVal.TabIndex = 13
        Me.lblVal.Text = "Val"
        '
        'tbSatMin
        '
        Me.tbSatMin.AutoSize = False
        Me.tbSatMin.Location = New System.Drawing.Point(45, 58)
        Me.tbSatMin.Maximum = 255
        Me.tbSatMin.Name = "tbSatMin"
        Me.tbSatMin.Size = New System.Drawing.Size(158, 23)
        Me.tbSatMin.TabIndex = 12
        Me.tbSatMin.TickFrequency = 10
        '
        'lblSat
        '
        Me.lblSat.AutoSize = True
        Me.lblSat.Location = New System.Drawing.Point(12, 63)
        Me.lblSat.Name = "lblSat"
        Me.lblSat.Size = New System.Drawing.Size(23, 13)
        Me.lblSat.TabIndex = 11
        Me.lblSat.Text = "Sat"
        '
        'tbHueMin
        '
        Me.tbHueMin.AutoSize = False
        Me.tbHueMin.Location = New System.Drawing.Point(45, 29)
        Me.tbHueMin.Maximum = 255
        Me.tbHueMin.Name = "tbHueMin"
        Me.tbHueMin.Size = New System.Drawing.Size(158, 23)
        Me.tbHueMin.TabIndex = 10
        Me.tbHueMin.TickFrequency = 10
        '
        'lblHue
        '
        Me.lblHue.AutoSize = True
        Me.lblHue.Location = New System.Drawing.Point(12, 34)
        Me.lblHue.Name = "lblHue"
        Me.lblHue.Size = New System.Drawing.Size(27, 13)
        Me.lblHue.TabIndex = 9
        Me.lblHue.Text = "Hue"
        '
        'lblMinValue
        '
        Me.lblMinValue.Location = New System.Drawing.Point(45, 9)
        Me.lblMinValue.Name = "lblMinValue"
        Me.lblMinValue.Size = New System.Drawing.Size(211, 17)
        Me.lblMinValue.TabIndex = 18
        Me.lblMinValue.Text = "Minimum Value"
        Me.lblMinValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaxValue
        '
        Me.lblMaxValue.Location = New System.Drawing.Point(291, 9)
        Me.lblMaxValue.Name = "lblMaxValue"
        Me.lblMaxValue.Size = New System.Drawing.Size(211, 17)
        Me.lblMaxValue.TabIndex = 25
        Me.lblMaxValue.Text = "Maximum Value"
        Me.lblMaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValMax
        '
        Me.txtValMax.Location = New System.Drawing.Point(455, 89)
        Me.txtValMax.Name = "txtValMax"
        Me.txtValMax.Size = New System.Drawing.Size(47, 20)
        Me.txtValMax.TabIndex = 24
        Me.txtValMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSatMax
        '
        Me.txtSatMax.Location = New System.Drawing.Point(455, 60)
        Me.txtSatMax.Name = "txtSatMax"
        Me.txtSatMax.Size = New System.Drawing.Size(47, 20)
        Me.txtSatMax.TabIndex = 23
        Me.txtSatMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHueMax
        '
        Me.txtHueMax.Location = New System.Drawing.Point(455, 31)
        Me.txtHueMax.Name = "txtHueMax"
        Me.txtHueMax.Size = New System.Drawing.Size(47, 20)
        Me.txtHueMax.TabIndex = 22
        Me.txtHueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbValMax
        '
        Me.tbValMax.AutoSize = False
        Me.tbValMax.Location = New System.Drawing.Point(291, 87)
        Me.tbValMax.Maximum = 255
        Me.tbValMax.Name = "tbValMax"
        Me.tbValMax.Size = New System.Drawing.Size(158, 23)
        Me.tbValMax.TabIndex = 21
        Me.tbValMax.TickFrequency = 10
        '
        'tbSatMax
        '
        Me.tbSatMax.AutoSize = False
        Me.tbSatMax.Location = New System.Drawing.Point(291, 58)
        Me.tbSatMax.Maximum = 255
        Me.tbSatMax.Name = "tbSatMax"
        Me.tbSatMax.Size = New System.Drawing.Size(158, 23)
        Me.tbSatMax.TabIndex = 20
        Me.tbSatMax.TickFrequency = 10
        '
        'tbHueMax
        '
        Me.tbHueMax.AutoSize = False
        Me.tbHueMax.Location = New System.Drawing.Point(291, 29)
        Me.tbHueMax.Maximum = 255
        Me.tbHueMax.Name = "tbHueMax"
        Me.tbHueMax.Size = New System.Drawing.Size(158, 23)
        Me.tbHueMax.TabIndex = 19
        Me.tbHueMax.TickFrequency = 10
        '
        'gbTarget
        '
        Me.gbTarget.Controls.Add(Me.lblTargetMax)
        Me.gbTarget.Controls.Add(Me.lblTargetMin)
        Me.gbTarget.Controls.Add(Me.udTargetSizeMax)
        Me.gbTarget.Controls.Add(Me.udTargetAspectRatioMax)
        Me.gbTarget.Controls.Add(Me.udTargetSizeMin)
        Me.gbTarget.Controls.Add(Me.udTargetAspectRatioMin)
        Me.gbTarget.Controls.Add(Me.lblTargetAspectRatio)
        Me.gbTarget.Controls.Add(Me.lblTargetAspectSize)
        Me.gbTarget.Location = New System.Drawing.Point(137, 133)
        Me.gbTarget.Name = "gbTarget"
        Me.gbTarget.Size = New System.Drawing.Size(365, 101)
        Me.gbTarget.TabIndex = 26
        Me.gbTarget.TabStop = False
        Me.gbTarget.Text = "Target Filter"
        '
        'lblTargetMax
        '
        Me.lblTargetMax.Location = New System.Drawing.Point(249, 16)
        Me.lblTargetMax.Name = "lblTargetMax"
        Me.lblTargetMax.Size = New System.Drawing.Size(99, 15)
        Me.lblTargetMax.TabIndex = 23
        Me.lblTargetMax.Text = "Max"
        Me.lblTargetMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTargetMin
        '
        Me.lblTargetMin.Location = New System.Drawing.Point(123, 16)
        Me.lblTargetMin.Name = "lblTargetMin"
        Me.lblTargetMin.Size = New System.Drawing.Size(99, 15)
        Me.lblTargetMin.TabIndex = 22
        Me.lblTargetMin.Text = "Min"
        Me.lblTargetMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'udTargetSizeMax
        '
        Me.udTargetSizeMax.Location = New System.Drawing.Point(252, 61)
        Me.udTargetSizeMax.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.udTargetSizeMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udTargetSizeMax.Name = "udTargetSizeMax"
        Me.udTargetSizeMax.Size = New System.Drawing.Size(96, 20)
        Me.udTargetSizeMax.TabIndex = 21
        Me.udTargetSizeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udTargetSizeMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udTargetAspectRatioMax
        '
        Me.udTargetAspectRatioMax.Location = New System.Drawing.Point(252, 34)
        Me.udTargetAspectRatioMax.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.udTargetAspectRatioMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udTargetAspectRatioMax.Name = "udTargetAspectRatioMax"
        Me.udTargetAspectRatioMax.Size = New System.Drawing.Size(96, 20)
        Me.udTargetAspectRatioMax.TabIndex = 20
        Me.udTargetAspectRatioMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udTargetAspectRatioMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udTargetSizeMin
        '
        Me.udTargetSizeMin.Location = New System.Drawing.Point(126, 61)
        Me.udTargetSizeMin.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.udTargetSizeMin.Name = "udTargetSizeMin"
        Me.udTargetSizeMin.Size = New System.Drawing.Size(96, 20)
        Me.udTargetSizeMin.TabIndex = 19
        Me.udTargetSizeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udTargetSizeMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udTargetAspectRatioMin
        '
        Me.udTargetAspectRatioMin.Location = New System.Drawing.Point(126, 34)
        Me.udTargetAspectRatioMin.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.udTargetAspectRatioMin.Name = "udTargetAspectRatioMin"
        Me.udTargetAspectRatioMin.Size = New System.Drawing.Size(96, 20)
        Me.udTargetAspectRatioMin.TabIndex = 18
        Me.udTargetAspectRatioMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udTargetAspectRatioMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblTargetAspectRatio
        '
        Me.lblTargetAspectRatio.AutoSize = True
        Me.lblTargetAspectRatio.Location = New System.Drawing.Point(6, 34)
        Me.lblTargetAspectRatio.Name = "lblTargetAspectRatio"
        Me.lblTargetAspectRatio.Size = New System.Drawing.Size(96, 13)
        Me.lblTargetAspectRatio.TabIndex = 16
        Me.lblTargetAspectRatio.Text = "Target aspect ratio"
        '
        'lblTargetAspectSize
        '
        Me.lblTargetAspectSize.AutoSize = True
        Me.lblTargetAspectSize.Location = New System.Drawing.Point(6, 63)
        Me.lblTargetAspectSize.Name = "lblTargetAspectSize"
        Me.lblTargetAspectSize.Size = New System.Drawing.Size(59, 13)
        Me.lblTargetAspectSize.TabIndex = 17
        Me.lblTargetAspectSize.Text = "Target size"
        '
        'udBlur
        '
        Me.udBlur.Location = New System.Drawing.Point(82, 191)
        Me.udBlur.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udBlur.Name = "udBlur"
        Me.udBlur.Size = New System.Drawing.Size(43, 20)
        Me.udBlur.TabIndex = 32
        Me.udBlur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udBlur.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udDilate
        '
        Me.udDilate.Location = New System.Drawing.Point(82, 164)
        Me.udDilate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udDilate.Name = "udDilate"
        Me.udDilate.Size = New System.Drawing.Size(43, 20)
        Me.udDilate.TabIndex = 31
        Me.udDilate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udDilate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udErode
        '
        Me.udErode.Location = New System.Drawing.Point(82, 138)
        Me.udErode.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.udErode.Name = "udErode"
        Me.udErode.Size = New System.Drawing.Size(43, 20)
        Me.udErode.TabIndex = 30
        Me.udErode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udErode.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkCleanup
        '
        Me.chkCleanup.AutoSize = True
        Me.chkCleanup.Location = New System.Drawing.Point(11, 217)
        Me.chkCleanup.Name = "chkCleanup"
        Me.chkCleanup.Size = New System.Drawing.Size(120, 17)
        Me.chkCleanup.TabIndex = 33
        Me.chkCleanup.Text = "Final mask clean up"
        Me.chkCleanup.UseVisualStyleBackColor = True
        '
        'chkErode
        '
        Me.chkErode.AutoSize = True
        Me.chkErode.Location = New System.Drawing.Point(11, 139)
        Me.chkErode.Name = "chkErode"
        Me.chkErode.Size = New System.Drawing.Size(54, 17)
        Me.chkErode.TabIndex = 34
        Me.chkErode.Text = "Erode"
        Me.chkErode.UseVisualStyleBackColor = True
        '
        'chkDilate
        '
        Me.chkDilate.AutoSize = True
        Me.chkDilate.Location = New System.Drawing.Point(12, 166)
        Me.chkDilate.Name = "chkDilate"
        Me.chkDilate.Size = New System.Drawing.Size(53, 17)
        Me.chkDilate.TabIndex = 35
        Me.chkDilate.Text = "Dilate"
        Me.chkDilate.UseVisualStyleBackColor = True
        '
        'chkBlur
        '
        Me.chkBlur.AutoSize = True
        Me.chkBlur.Location = New System.Drawing.Point(12, 192)
        Me.chkBlur.Name = "chkBlur"
        Me.chkBlur.Size = New System.Drawing.Size(44, 17)
        Me.chkBlur.TabIndex = 36
        Me.chkBlur.Text = "Blur"
        Me.chkBlur.UseVisualStyleBackColor = True
        '
        'FilterSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkBlur)
        Me.Controls.Add(Me.chkDilate)
        Me.Controls.Add(Me.chkErode)
        Me.Controls.Add(Me.chkCleanup)
        Me.Controls.Add(Me.udBlur)
        Me.Controls.Add(Me.udDilate)
        Me.Controls.Add(Me.udErode)
        Me.Controls.Add(Me.gbTarget)
        Me.Controls.Add(Me.lblMaxValue)
        Me.Controls.Add(Me.txtValMax)
        Me.Controls.Add(Me.txtSatMax)
        Me.Controls.Add(Me.txtHueMax)
        Me.Controls.Add(Me.tbValMax)
        Me.Controls.Add(Me.tbSatMax)
        Me.Controls.Add(Me.tbHueMax)
        Me.Controls.Add(Me.lblMinValue)
        Me.Controls.Add(Me.txtValMin)
        Me.Controls.Add(Me.txtSatMin)
        Me.Controls.Add(Me.txtHueMin)
        Me.Controls.Add(Me.tbValMin)
        Me.Controls.Add(Me.lblVal)
        Me.Controls.Add(Me.tbSatMin)
        Me.Controls.Add(Me.lblSat)
        Me.Controls.Add(Me.tbHueMin)
        Me.Controls.Add(Me.lblHue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(30, 30)
        Me.Name = "FilterSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Filter Settings"
        CType(Me.tbValMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSatMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHueMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbValMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSatMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHueMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTarget.ResumeLayout(False)
        Me.gbTarget.PerformLayout()
        CType(Me.udTargetSizeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTargetAspectRatioMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTargetSizeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTargetAspectRatioMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udBlur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udDilate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udErode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValMin As System.Windows.Forms.TextBox
    Friend WithEvents txtSatMin As System.Windows.Forms.TextBox
    Friend WithEvents txtHueMin As System.Windows.Forms.TextBox
    Friend WithEvents tbValMin As System.Windows.Forms.TrackBar
    Friend WithEvents lblVal As System.Windows.Forms.Label
    Friend WithEvents tbSatMin As System.Windows.Forms.TrackBar
    Friend WithEvents lblSat As System.Windows.Forms.Label
    Friend WithEvents tbHueMin As System.Windows.Forms.TrackBar
    Friend WithEvents lblHue As System.Windows.Forms.Label
    Friend WithEvents lblMinValue As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue As System.Windows.Forms.Label
    Friend WithEvents txtValMax As System.Windows.Forms.TextBox
    Friend WithEvents txtSatMax As System.Windows.Forms.TextBox
    Friend WithEvents txtHueMax As System.Windows.Forms.TextBox
    Friend WithEvents tbValMax As System.Windows.Forms.TrackBar
    Friend WithEvents tbSatMax As System.Windows.Forms.TrackBar
    Friend WithEvents tbHueMax As System.Windows.Forms.TrackBar
    Friend WithEvents gbTarget As System.Windows.Forms.GroupBox
    Friend WithEvents lblTargetMax As System.Windows.Forms.Label
    Friend WithEvents lblTargetMin As System.Windows.Forms.Label
    Friend WithEvents udTargetSizeMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents udTargetAspectRatioMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents udTargetSizeMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents udTargetAspectRatioMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTargetAspectRatio As System.Windows.Forms.Label
    Friend WithEvents lblTargetAspectSize As System.Windows.Forms.Label
    Friend WithEvents udBlur As System.Windows.Forms.NumericUpDown
    Friend WithEvents udDilate As System.Windows.Forms.NumericUpDown
    Friend WithEvents udErode As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkCleanup As System.Windows.Forms.CheckBox
    Friend WithEvents chkErode As System.Windows.Forms.CheckBox
    Friend WithEvents chkDilate As System.Windows.Forms.CheckBox
    Friend WithEvents chkBlur As System.Windows.Forms.CheckBox
End Class
