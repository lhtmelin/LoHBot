<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugScreen
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
        Me.components = New System.ComponentModel.Container()
        Me.lblCurrentXY = New System.Windows.Forms.Label()
        Me.txtCurrentXY = New System.Windows.Forms.TextBox()
        Me.txtClickedXY = New System.Windows.Forms.TextBox()
        Me.lblClickedXY = New System.Windows.Forms.Label()
        Me.txtCurrentColor = New System.Windows.Forms.TextBox()
        Me.lblCurrentColor = New System.Windows.Forms.Label()
        Me.txtClickedColor = New System.Windows.Forms.TextBox()
        Me.lblClickedColor = New System.Windows.Forms.Label()
        Me.picClickedColor = New System.Windows.Forms.PictureBox()
        Me.picCurrentColor = New System.Windows.Forms.PictureBox()
        Me.picBuffer = New System.Windows.Forms.PictureBox()
        Me.tmrPaint = New System.Windows.Forms.Timer(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCode = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.chkLiveBuffer = New System.Windows.Forms.CheckBox()
        CType(Me.picClickedColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCurrentColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBuffer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCurrentXY
        '
        Me.lblCurrentXY.Location = New System.Drawing.Point(975, 12)
        Me.lblCurrentXY.Name = "lblCurrentXY"
        Me.lblCurrentXY.Size = New System.Drawing.Size(236, 13)
        Me.lblCurrentXY.TabIndex = 1
        Me.lblCurrentXY.Text = "Current X,Y"
        Me.lblCurrentXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrentXY
        '
        Me.txtCurrentXY.Location = New System.Drawing.Point(978, 28)
        Me.txtCurrentXY.Name = "txtCurrentXY"
        Me.txtCurrentXY.Size = New System.Drawing.Size(233, 20)
        Me.txtCurrentXY.TabIndex = 2
        Me.txtCurrentXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtClickedXY
        '
        Me.txtClickedXY.Location = New System.Drawing.Point(978, 202)
        Me.txtClickedXY.Name = "txtClickedXY"
        Me.txtClickedXY.Size = New System.Drawing.Size(233, 20)
        Me.txtClickedXY.TabIndex = 4
        Me.txtClickedXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblClickedXY
        '
        Me.lblClickedXY.Location = New System.Drawing.Point(975, 186)
        Me.lblClickedXY.Name = "lblClickedXY"
        Me.lblClickedXY.Size = New System.Drawing.Size(236, 13)
        Me.lblClickedXY.TabIndex = 3
        Me.lblClickedXY.Text = "Clicked X,Y"
        Me.lblClickedXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCurrentColor
        '
        Me.txtCurrentColor.Location = New System.Drawing.Point(978, 67)
        Me.txtCurrentColor.Name = "txtCurrentColor"
        Me.txtCurrentColor.Size = New System.Drawing.Size(233, 20)
        Me.txtCurrentColor.TabIndex = 6
        Me.txtCurrentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCurrentColor
        '
        Me.lblCurrentColor.Location = New System.Drawing.Point(975, 51)
        Me.lblCurrentColor.Name = "lblCurrentColor"
        Me.lblCurrentColor.Size = New System.Drawing.Size(236, 13)
        Me.lblCurrentColor.TabIndex = 5
        Me.lblCurrentColor.Text = "Current Color"
        Me.lblCurrentColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClickedColor
        '
        Me.txtClickedColor.Location = New System.Drawing.Point(978, 241)
        Me.txtClickedColor.Name = "txtClickedColor"
        Me.txtClickedColor.Size = New System.Drawing.Size(233, 20)
        Me.txtClickedColor.TabIndex = 9
        Me.txtClickedColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblClickedColor
        '
        Me.lblClickedColor.Location = New System.Drawing.Point(975, 225)
        Me.lblClickedColor.Name = "lblClickedColor"
        Me.lblClickedColor.Size = New System.Drawing.Size(236, 13)
        Me.lblClickedColor.TabIndex = 8
        Me.lblClickedColor.Text = "Clicked Color"
        Me.lblClickedColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picClickedColor
        '
        Me.picClickedColor.Location = New System.Drawing.Point(978, 267)
        Me.picClickedColor.Name = "picClickedColor"
        Me.picClickedColor.Size = New System.Drawing.Size(233, 50)
        Me.picClickedColor.TabIndex = 10
        Me.picClickedColor.TabStop = False
        '
        'picCurrentColor
        '
        Me.picCurrentColor.Location = New System.Drawing.Point(978, 93)
        Me.picCurrentColor.Name = "picCurrentColor"
        Me.picCurrentColor.Size = New System.Drawing.Size(233, 50)
        Me.picCurrentColor.TabIndex = 7
        Me.picCurrentColor.TabStop = False
        '
        'picBuffer
        '
        Me.picBuffer.Location = New System.Drawing.Point(12, 12)
        Me.picBuffer.Name = "picBuffer"
        Me.picBuffer.Size = New System.Drawing.Size(960, 600)
        Me.picBuffer.TabIndex = 0
        Me.picBuffer.TabStop = False
        '
        'tmrPaint
        '
        Me.tmrPaint.Interval = 1
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(1132, 590)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCode
        '
        Me.btnCode.Location = New System.Drawing.Point(1136, 323)
        Me.btnCode.Name = "btnCode"
        Me.btnCode.Size = New System.Drawing.Size(75, 23)
        Me.btnCode.TabIndex = 12
        Me.btnCode.Text = "Add"
        Me.btnCode.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(978, 323)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(978, 352)
        Me.txtCode.Multiline = True
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCode.Size = New System.Drawing.Size(229, 232)
        Me.txtCode.TabIndex = 14
        Me.txtCode.WordWrap = False
        '
        'chkLiveBuffer
        '
        Me.chkLiveBuffer.AutoSize = True
        Me.chkLiveBuffer.Checked = True
        Me.chkLiveBuffer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLiveBuffer.Location = New System.Drawing.Point(979, 150)
        Me.chkLiveBuffer.Name = "chkLiveBuffer"
        Me.chkLiveBuffer.Size = New System.Drawing.Size(77, 17)
        Me.chkLiveBuffer.TabIndex = 15
        Me.chkLiveBuffer.Text = "Live Buffer"
        Me.chkLiveBuffer.UseVisualStyleBackColor = True
        '
        'DebugScreen
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1219, 625)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkLiveBuffer)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCode)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picClickedColor)
        Me.Controls.Add(Me.txtClickedColor)
        Me.Controls.Add(Me.lblClickedColor)
        Me.Controls.Add(Me.picCurrentColor)
        Me.Controls.Add(Me.txtCurrentColor)
        Me.Controls.Add(Me.lblCurrentColor)
        Me.Controls.Add(Me.txtClickedXY)
        Me.Controls.Add(Me.lblClickedXY)
        Me.Controls.Add(Me.txtCurrentXY)
        Me.Controls.Add(Me.lblCurrentXY)
        Me.Controls.Add(Me.picBuffer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DebugScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DebugScreen"
        CType(Me.picClickedColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCurrentColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBuffer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picBuffer As System.Windows.Forms.PictureBox
    Friend WithEvents lblCurrentXY As System.Windows.Forms.Label
    Friend WithEvents txtCurrentXY As System.Windows.Forms.TextBox
    Friend WithEvents txtClickedXY As System.Windows.Forms.TextBox
    Friend WithEvents lblClickedXY As System.Windows.Forms.Label
    Friend WithEvents txtCurrentColor As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentColor As System.Windows.Forms.Label
    Friend WithEvents picCurrentColor As System.Windows.Forms.PictureBox
    Friend WithEvents picClickedColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtClickedColor As System.Windows.Forms.TextBox
    Friend WithEvents lblClickedColor As System.Windows.Forms.Label
    Friend WithEvents tmrPaint As System.Windows.Forms.Timer
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCode As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents chkLiveBuffer As System.Windows.Forms.CheckBox
End Class
