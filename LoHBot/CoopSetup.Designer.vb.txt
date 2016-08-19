<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoopSetup
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
        Me.lblFloor = New System.Windows.Forms.Label()
        Me.cboSubfloor = New System.Windows.Forms.ComboBox()
        Me.cboFloor = New System.Windows.Forms.ComboBox()
        Me.lblText = New System.Windows.Forms.Label()
        Me.optActive = New System.Windows.Forms.RadioButton()
        Me.optPassive = New System.Windows.Forms.RadioButton()
        Me.gbPartners = New System.Windows.Forms.GroupBox()
        Me.gbPlayers = New System.Windows.Forms.GroupBox()
        Me.optSpecific = New System.Windows.Forms.RadioButton()
        Me.optAnyone = New System.Windows.Forms.RadioButton()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.txtPlayer = New System.Windows.Forms.TextBox()
        Me.lstPlayers = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.gbPartners.SuspendLayout()
        Me.gbPlayers.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFloor
        '
        Me.lblFloor.AutoSize = True
        Me.lblFloor.Location = New System.Drawing.Point(12, 9)
        Me.lblFloor.Name = "lblFloor"
        Me.lblFloor.Size = New System.Drawing.Size(126, 13)
        Me.lblFloor.TabIndex = 0
        Me.lblFloor.Text = "Tower Floor and Subfloor"
        '
        'cboSubfloor
        '
        Me.cboSubfloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubfloor.FormattingEnabled = True
        Me.cboSubfloor.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cboSubfloor.Location = New System.Drawing.Point(215, 6)
        Me.cboSubfloor.Name = "cboSubfloor"
        Me.cboSubfloor.Size = New System.Drawing.Size(65, 21)
        Me.cboSubfloor.TabIndex = 1
        '
        'cboFloor
        '
        Me.cboFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFloor.FormattingEnabled = True
        Me.cboFloor.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cboFloor.Location = New System.Drawing.Point(144, 6)
        Me.cboFloor.Name = "cboFloor"
        Me.cboFloor.Size = New System.Drawing.Size(65, 21)
        Me.cboFloor.TabIndex = 2
        '
        'lblText
        '
        Me.lblText.AutoSize = True
        Me.lblText.Location = New System.Drawing.Point(287, 8)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(222, 13)
        Me.lblText.TabIndex = 3
        Me.lblText.Text = "Play manually this floor before use coop mode"
        '
        'optActive
        '
        Me.optActive.AutoSize = True
        Me.optActive.Location = New System.Drawing.Point(15, 38)
        Me.optActive.Name = "optActive"
        Me.optActive.Size = New System.Drawing.Size(130, 17)
        Me.optActive.TabIndex = 4
        Me.optActive.TabStop = True
        Me.optActive.Text = "Active (invite partners)"
        Me.optActive.UseVisualStyleBackColor = True
        '
        'optPassive
        '
        Me.optPassive.AutoSize = True
        Me.optPassive.Location = New System.Drawing.Point(176, 38)
        Me.optPassive.Name = "optPassive"
        Me.optPassive.Size = New System.Drawing.Size(186, 17)
        Me.optPassive.TabIndex = 5
        Me.optPassive.TabStop = True
        Me.optPassive.Text = "Passive (wait for partner invitation)"
        Me.optPassive.UseVisualStyleBackColor = True
        '
        'gbPartners
        '
        Me.gbPartners.Controls.Add(Me.optSpecific)
        Me.gbPartners.Controls.Add(Me.optAnyone)
        Me.gbPartners.Controls.Add(Me.gbPlayers)
        Me.gbPartners.Location = New System.Drawing.Point(12, 61)
        Me.gbPartners.Name = "gbPartners"
        Me.gbPartners.Size = New System.Drawing.Size(537, 214)
        Me.gbPartners.TabIndex = 6
        Me.gbPartners.TabStop = False
        Me.gbPartners.Text = "Partner settings"
        '
        'gbPlayers
        '
        Me.gbPlayers.Controls.Add(Me.btnDelete)
        Me.gbPlayers.Controls.Add(Me.btnAdd)
        Me.gbPlayers.Controls.Add(Me.lstPlayers)
        Me.gbPlayers.Controls.Add(Me.txtPlayer)
        Me.gbPlayers.Controls.Add(Me.lblPlayer)
        Me.gbPlayers.Location = New System.Drawing.Point(194, 19)
        Me.gbPlayers.Name = "gbPlayers"
        Me.gbPlayers.Size = New System.Drawing.Size(333, 189)
        Me.gbPlayers.TabIndex = 2
        Me.gbPlayers.TabStop = False
        '
        'optSpecific
        '
        Me.optSpecific.AutoSize = True
        Me.optSpecific.Location = New System.Drawing.Point(89, 19)
        Me.optSpecific.Name = "optSpecific"
        Me.optSpecific.Size = New System.Drawing.Size(99, 17)
        Me.optSpecific.TabIndex = 7
        Me.optSpecific.TabStop = True
        Me.optSpecific.Text = "Specific players"
        Me.optSpecific.UseVisualStyleBackColor = True
        '
        'optAnyone
        '
        Me.optAnyone.AutoSize = True
        Me.optAnyone.Location = New System.Drawing.Point(9, 19)
        Me.optAnyone.Name = "optAnyone"
        Me.optAnyone.Size = New System.Drawing.Size(61, 17)
        Me.optAnyone.TabIndex = 6
        Me.optAnyone.TabStop = True
        Me.optAnyone.Text = "Anyone"
        Me.optAnyone.UseVisualStyleBackColor = True
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Location = New System.Drawing.Point(6, 16)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(65, 13)
        Me.lblPlayer.TabIndex = 0
        Me.lblPlayer.Text = "Player name"
        '
        'txtPlayer
        '
        Me.txtPlayer.Location = New System.Drawing.Point(77, 13)
        Me.txtPlayer.Name = "txtPlayer"
        Me.txtPlayer.Size = New System.Drawing.Size(185, 20)
        Me.txtPlayer.TabIndex = 1
        '
        'lstPlayers
        '
        Me.lstPlayers.FormattingEnabled = True
        Me.lstPlayers.Location = New System.Drawing.Point(77, 39)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstPlayers.Size = New System.Drawing.Size(185, 134)
        Me.lstPlayers.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(268, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(53, 20)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(268, 39)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(53, 20)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'CoopSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 288)
        Me.Controls.Add(Me.gbPartners)
        Me.Controls.Add(Me.optPassive)
        Me.Controls.Add(Me.optActive)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.cboFloor)
        Me.Controls.Add(Me.cboSubfloor)
        Me.Controls.Add(Me.lblFloor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CoopSetup"
        Me.Text = "Tower Coop Setup"
        Me.gbPartners.ResumeLayout(False)
        Me.gbPartners.PerformLayout()
        Me.gbPlayers.ResumeLayout(False)
        Me.gbPlayers.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFloor As System.Windows.Forms.Label
    Friend WithEvents cboSubfloor As System.Windows.Forms.ComboBox
    Friend WithEvents cboFloor As System.Windows.Forms.ComboBox
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents optActive As System.Windows.Forms.RadioButton
    Friend WithEvents optPassive As System.Windows.Forms.RadioButton
    Friend WithEvents gbPartners As System.Windows.Forms.GroupBox
    Friend WithEvents optSpecific As System.Windows.Forms.RadioButton
    Friend WithEvents optAnyone As System.Windows.Forms.RadioButton
    Friend WithEvents gbPlayers As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstPlayers As System.Windows.Forms.ListBox
    Friend WithEvents txtPlayer As System.Windows.Forms.TextBox
    Friend WithEvents lblPlayer As System.Windows.Forms.Label
End Class
