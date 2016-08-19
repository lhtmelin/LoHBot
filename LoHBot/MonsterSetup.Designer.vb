<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonsterSetup
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
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tblScreen = New System.Windows.Forms.TableLayoutPanel()
        Me.picFinal = New System.Windows.Forms.PictureBox()
        Me.picMask = New System.Windows.Forms.PictureBox()
        Me.picHSV = New System.Windows.Forms.PictureBox()
        Me.picOriginal = New System.Windows.Forms.PictureBox()
        Me.chkLiveUpdate = New System.Windows.Forms.CheckBox()
        Me.tmr_update = New System.Windows.Forms.Timer(Me.components)
        Me.tblScreen.SuspendLayout()
        CType(Me.picFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMask, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHSV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(110, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Monster Setup Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(128, 6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(408, 20)
        Me.txtName.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(542, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(623, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tblScreen
        '
        Me.tblScreen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblScreen.ColumnCount = 2
        Me.tblScreen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreen.Controls.Add(Me.picFinal, 1, 1)
        Me.tblScreen.Controls.Add(Me.picMask, 0, 1)
        Me.tblScreen.Controls.Add(Me.picHSV, 1, 0)
        Me.tblScreen.Controls.Add(Me.picOriginal, 0, 0)
        Me.tblScreen.Location = New System.Drawing.Point(12, 33)
        Me.tblScreen.Name = "tblScreen"
        Me.tblScreen.RowCount = 2
        Me.tblScreen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblScreen.Size = New System.Drawing.Size(906, 474)
        Me.tblScreen.TabIndex = 5
        '
        'picFinal
        '
        Me.picFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFinal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFinal.Location = New System.Drawing.Point(456, 240)
        Me.picFinal.Name = "picFinal"
        Me.picFinal.Size = New System.Drawing.Size(447, 231)
        Me.picFinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFinal.TabIndex = 3
        Me.picFinal.TabStop = False
        '
        'picMask
        '
        Me.picMask.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMask.Location = New System.Drawing.Point(3, 240)
        Me.picMask.Name = "picMask"
        Me.picMask.Size = New System.Drawing.Size(447, 231)
        Me.picMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMask.TabIndex = 2
        Me.picMask.TabStop = False
        '
        'picHSV
        '
        Me.picHSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picHSV.Location = New System.Drawing.Point(456, 3)
        Me.picHSV.Name = "picHSV"
        Me.picHSV.Size = New System.Drawing.Size(447, 231)
        Me.picHSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picHSV.TabIndex = 1
        Me.picHSV.TabStop = False
        '
        'picOriginal
        '
        Me.picOriginal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picOriginal.Location = New System.Drawing.Point(3, 3)
        Me.picOriginal.Name = "picOriginal"
        Me.picOriginal.Size = New System.Drawing.Size(447, 231)
        Me.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picOriginal.TabIndex = 0
        Me.picOriginal.TabStop = False
        '
        'chkLiveUpdate
        '
        Me.chkLiveUpdate.AutoSize = True
        Me.chkLiveUpdate.Checked = True
        Me.chkLiveUpdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLiveUpdate.Location = New System.Drawing.Point(834, 9)
        Me.chkLiveUpdate.Name = "chkLiveUpdate"
        Me.chkLiveUpdate.Size = New System.Drawing.Size(84, 17)
        Me.chkLiveUpdate.TabIndex = 6
        Me.chkLiveUpdate.Text = "Live Update"
        Me.chkLiveUpdate.UseVisualStyleBackColor = True
        '
        'tmr_update
        '
        Me.tmr_update.Interval = 1
        '
        'MonsterSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 519)
        Me.Controls.Add(Me.chkLiveUpdate)
        Me.Controls.Add(Me.tblScreen)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.Name = "MonsterSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monster Hunt Setup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tblScreen.ResumeLayout(False)
        CType(Me.picFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMask, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHSV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tblScreen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picFinal As System.Windows.Forms.PictureBox
    Friend WithEvents picMask As System.Windows.Forms.PictureBox
    Friend WithEvents picHSV As System.Windows.Forms.PictureBox
    Friend WithEvents picOriginal As System.Windows.Forms.PictureBox
    Friend WithEvents chkLiveUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents tmr_update As System.Windows.Forms.Timer
End Class
