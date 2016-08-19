<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tcBot = New System.Windows.Forms.TabControl()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.llForum = New System.Windows.Forms.LinkLabel()
        Me.llPage = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkFastPixel = New System.Windows.Forms.CheckBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lblGold = New System.Windows.Forms.Label()
        Me.lblGameAccountName = New System.Windows.Forms.Label()
        Me.lblBluestacksVersion = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.picMain = New System.Windows.Forms.PictureBox()
        Me.tpAttack = New System.Windows.Forms.TabPage()
        Me.chkAutoTowerMonsterHunt = New System.Windows.Forms.CheckBox()
        Me.chkColiBattle = New System.Windows.Forms.CheckBox()
        Me.gbMineDeploy = New System.Windows.Forms.GroupBox()
        Me.udMinRuneMine = New System.Windows.Forms.NumericUpDown()
        Me.udMinGoldMine = New System.Windows.Forms.NumericUpDown()
        Me.udMaxTroopsMine = New System.Windows.Forms.NumericUpDown()
        Me.lblMaxTroopsMine = New System.Windows.Forms.Label()
        Me.lblMinRuneMine = New System.Windows.Forms.Label()
        Me.lblMinGoldMine = New System.Windows.Forms.Label()
        Me.chkRuneMine = New System.Windows.Forms.CheckBox()
        Me.chkGoldMine = New System.Windows.Forms.CheckBox()
        Me.chkMineDeploy = New System.Windows.Forms.CheckBox()
        Me.chkInfiniteBattle = New System.Windows.Forms.CheckBox()
        Me.gbMonsterHunt = New System.Windows.Forms.GroupBox()
        Me.btnEditMonsterSetup = New System.Windows.Forms.Button()
        Me.cboMonsterSetup = New System.Windows.Forms.ComboBox()
        Me.lblActiveMonsterSetup = New System.Windows.Forms.Label()
        Me.btnBasicMonsterHuntSetup = New System.Windows.Forms.Button()
        Me.optMonsterHunt = New System.Windows.Forms.RadioButton()
        Me.gbTower = New System.Windows.Forms.GroupBox()
        Me.chkTowerClimb = New System.Windows.Forms.CheckBox()
        Me.optHardTower = New System.Windows.Forms.RadioButton()
        Me.optRegularTower = New System.Windows.Forms.RadioButton()
        Me.btnCoopConfig = New System.Windows.Forms.Button()
        Me.chkCoop = New System.Windows.Forms.CheckBox()
        Me.chkQuickBattle = New System.Windows.Forms.CheckBox()
        Me.optTower = New System.Windows.Forms.RadioButton()
        Me.tpMisc = New System.Windows.Forms.TabPage()
        Me.chkAutoBuyRuneEssence = New System.Windows.Forms.CheckBox()
        Me.gbAutoSell = New System.Windows.Forms.GroupBox()
        Me.lblSellFilter = New System.Windows.Forms.Label()
        Me.txtSellFilter = New System.Windows.Forms.TextBox()
        Me.optSellFilter = New System.Windows.Forms.RadioButton()
        Me.optSellEverything = New System.Windows.Forms.RadioButton()
        Me.gbTimeout = New System.Windows.Forms.GroupBox()
        Me.lblObsInfBattle = New System.Windows.Forms.Label()
        Me.udInfBattle = New System.Windows.Forms.NumericUpDown()
        Me.lblInfBattle = New System.Windows.Forms.Label()
        Me.lblObsColi = New System.Windows.Forms.Label()
        Me.udAutoColi = New System.Windows.Forms.NumericUpDown()
        Me.lblColi = New System.Windows.Forms.Label()
        Me.lblObsAutoSell = New System.Windows.Forms.Label()
        Me.udAutoSell = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoSell = New System.Windows.Forms.Label()
        Me.lblObsGameFreeze = New System.Windows.Forms.Label()
        Me.udGameFreeze = New System.Windows.Forms.NumericUpDown()
        Me.lblGameFreeze = New System.Windows.Forms.Label()
        Me.chkFodderEquip = New System.Windows.Forms.CheckBox()
        Me.cboFodderPosition = New System.Windows.Forms.ComboBox()
        Me.lblFodderPosition = New System.Windows.Forms.Label()
        Me.chkAutoFodderSwap = New System.Windows.Forms.CheckBox()
        Me.chkAutoReadMessage = New System.Windows.Forms.CheckBox()
        Me.chkAutoMineClaim = New System.Windows.Forms.CheckBox()
        Me.chkAutoSell = New System.Windows.Forms.CheckBox()
        Me.tpTools = New System.Windows.Forms.TabPage()
        Me.btnAbortHireFuse = New System.Windows.Forms.Button()
        Me.btnAwaken = New System.Windows.Forms.Button()
        Me.btmBotSetup = New System.Windows.Forms.Button()
        Me.btnFuseHire = New System.Windows.Forms.Button()
        Me.tpStats = New System.Windows.Forms.TabPage()
        Me.lblFightsHour = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grExp = New LoHBot.Graph()
        Me.lblStatsTotalExpMinute = New System.Windows.Forms.Label()
        Me.lblStatsTotalExp = New System.Windows.Forms.Label()
        Me.lblFights = New System.Windows.Forms.Label()
        Me.lblStatBotTime = New System.Windows.Forms.Label()
        Me.gbStatsGold = New System.Windows.Forms.GroupBox()
        Me.grGold = New LoHBot.Graph()
        Me.lblStatsGoldBalanceHour = New System.Windows.Forms.Label()
        Me.lblStatsGoldBalance = New System.Windows.Forms.Label()
        Me.lblStatsCurrentGold = New System.Windows.Forms.Label()
        Me.lblStatsStartGold = New System.Windows.Forms.Label()
        Me.tpLog = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblAdvancedHireFuse = New System.Windows.Forms.Label()
        Me.tcBot.SuspendLayout()
        Me.tpMain.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAttack.SuspendLayout()
        Me.gbMineDeploy.SuspendLayout()
        CType(Me.udMinRuneMine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udMinGoldMine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udMaxTroopsMine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMonsterHunt.SuspendLayout()
        Me.gbTower.SuspendLayout()
        Me.tpMisc.SuspendLayout()
        Me.gbAutoSell.SuspendLayout()
        Me.gbTimeout.SuspendLayout()
        CType(Me.udInfBattle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAutoColi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAutoSell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udGameFreeze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTools.SuspendLayout()
        Me.tpStats.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbStatsGold.SuspendLayout()
        Me.tpLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcBot
        '
        Me.tcBot.Controls.Add(Me.tpMain)
        Me.tcBot.Controls.Add(Me.tpAttack)
        Me.tcBot.Controls.Add(Me.tpMisc)
        Me.tcBot.Controls.Add(Me.tpTools)
        Me.tcBot.Controls.Add(Me.tpStats)
        Me.tcBot.Controls.Add(Me.tpLog)
        Me.tcBot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcBot.Location = New System.Drawing.Point(0, 0)
        Me.tcBot.Name = "tcBot"
        Me.tcBot.SelectedIndex = 0
        Me.tcBot.Size = New System.Drawing.Size(687, 571)
        Me.tcBot.TabIndex = 0
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.Button1)
        Me.tpMain.Controls.Add(Me.llForum)
        Me.tpMain.Controls.Add(Me.llPage)
        Me.tpMain.Controls.Add(Me.PictureBox1)
        Me.tpMain.Controls.Add(Me.chkFastPixel)
        Me.tpMain.Controls.Add(Me.btnStop)
        Me.tpMain.Controls.Add(Me.lblGold)
        Me.tpMain.Controls.Add(Me.lblGameAccountName)
        Me.tpMain.Controls.Add(Me.lblBluestacksVersion)
        Me.tpMain.Controls.Add(Me.btnStart)
        Me.tpMain.Controls.Add(Me.lblVersion)
        Me.tpMain.Controls.Add(Me.picMain)
        Me.tpMain.Location = New System.Drawing.Point(4, 22)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(679, 545)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(572, 369)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'llForum
        '
        Me.llForum.AutoSize = True
        Me.llForum.Cursor = System.Windows.Forms.Cursors.Hand
        Me.llForum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llForum.Location = New System.Drawing.Point(395, 408)
        Me.llForum.Name = "llForum"
        Me.llForum.Size = New System.Drawing.Size(261, 13)
        Me.llForum.TabIndex = 13
        Me.llForum.TabStop = True
        Me.llForum.Text = "If you need help, click here to visit our Forum"
        '
        'llPage
        '
        Me.llPage.AutoSize = True
        Me.llPage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.llPage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llPage.Location = New System.Drawing.Point(8, 408)
        Me.llPage.Name = "llPage"
        Me.llPage.Size = New System.Drawing.Size(157, 13)
        Me.llPage.TabIndex = 12
        Me.llPage.TabStop = True
        Me.llPage.Text = "Click here to visit our page"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 424)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(648, 113)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'chkFastPixel
        '
        Me.chkFastPixel.AutoSize = True
        Me.chkFastPixel.Location = New System.Drawing.Point(190, 369)
        Me.chkFastPixel.Name = "chkFastPixel"
        Me.chkFastPixel.Size = New System.Drawing.Size(354, 17)
        Me.chkFastPixel.TabIndex = 10
        Me.chkFastPixel.Text = "Use fast pixel check (if BOT dont work properly, uncheck this option)"
        Me.chkFastPixel.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(92, 365)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 7
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lblGold
        '
        Me.lblGold.AutoSize = True
        Me.lblGold.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGold.ForeColor = System.Drawing.Color.White
        Me.lblGold.Location = New System.Drawing.Point(20, 93)
        Me.lblGold.Name = "lblGold"
        Me.lblGold.Size = New System.Drawing.Size(110, 16)
        Me.lblGold.TabIndex = 6
        Me.lblGold.Text = "Game Account: "
        '
        'lblGameAccountName
        '
        Me.lblGameAccountName.AutoSize = True
        Me.lblGameAccountName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameAccountName.ForeColor = System.Drawing.Color.White
        Me.lblGameAccountName.Location = New System.Drawing.Point(20, 66)
        Me.lblGameAccountName.Name = "lblGameAccountName"
        Me.lblGameAccountName.Size = New System.Drawing.Size(110, 16)
        Me.lblGameAccountName.TabIndex = 5
        Me.lblGameAccountName.Text = "Game Account: "
        '
        'lblBluestacksVersion
        '
        Me.lblBluestacksVersion.AutoSize = True
        Me.lblBluestacksVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBluestacksVersion.ForeColor = System.Drawing.Color.White
        Me.lblBluestacksVersion.Location = New System.Drawing.Point(20, 12)
        Me.lblBluestacksVersion.Name = "lblBluestacksVersion"
        Me.lblBluestacksVersion.Size = New System.Drawing.Size(139, 16)
        Me.lblBluestacksVersion.TabIndex = 4
        Me.lblBluestacksVersion.Text = "Bluestacks Version: "
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(11, 365)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(20, 39)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(66, 16)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Version: "
        '
        'picMain
        '
        Me.picMain.Image = Global.LoHBot.My.Resources.Resources.LoHBot
        Me.picMain.Location = New System.Drawing.Point(0, 0)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(677, 359)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMain.TabIndex = 1
        Me.picMain.TabStop = False
        '
        'tpAttack
        '
        Me.tpAttack.Controls.Add(Me.chkAutoTowerMonsterHunt)
        Me.tpAttack.Controls.Add(Me.chkColiBattle)
        Me.tpAttack.Controls.Add(Me.gbMineDeploy)
        Me.tpAttack.Controls.Add(Me.chkMineDeploy)
        Me.tpAttack.Controls.Add(Me.chkInfiniteBattle)
        Me.tpAttack.Controls.Add(Me.gbMonsterHunt)
        Me.tpAttack.Controls.Add(Me.optMonsterHunt)
        Me.tpAttack.Controls.Add(Me.gbTower)
        Me.tpAttack.Controls.Add(Me.optTower)
        Me.tpAttack.Location = New System.Drawing.Point(4, 22)
        Me.tpAttack.Name = "tpAttack"
        Me.tpAttack.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAttack.Size = New System.Drawing.Size(679, 545)
        Me.tpAttack.TabIndex = 1
        Me.tpAttack.Text = "Attack"
        Me.tpAttack.UseVisualStyleBackColor = True
        '
        'chkAutoTowerMonsterHunt
        '
        Me.chkAutoTowerMonsterHunt.AutoSize = True
        Me.chkAutoTowerMonsterHunt.Location = New System.Drawing.Point(8, 6)
        Me.chkAutoTowerMonsterHunt.Name = "chkAutoTowerMonsterHunt"
        Me.chkAutoTowerMonsterHunt.Size = New System.Drawing.Size(198, 17)
        Me.chkAutoTowerMonsterHunt.TabIndex = 8
        Me.chkAutoTowerMonsterHunt.Text = "Enable Auto Tower or Monster Hunt"
        Me.chkAutoTowerMonsterHunt.UseVisualStyleBackColor = True
        '
        'chkColiBattle
        '
        Me.chkColiBattle.AutoSize = True
        Me.chkColiBattle.Enabled = False
        Me.chkColiBattle.Location = New System.Drawing.Point(505, 241)
        Me.chkColiBattle.Name = "chkColiBattle"
        Me.chkColiBattle.Size = New System.Drawing.Size(166, 17)
        Me.chkColiBattle.TabIndex = 7
        Me.chkColiBattle.Text = "Coli Battle (only against CPU)"
        Me.chkColiBattle.UseVisualStyleBackColor = True
        '
        'gbMineDeploy
        '
        Me.gbMineDeploy.Controls.Add(Me.udMinRuneMine)
        Me.gbMineDeploy.Controls.Add(Me.udMinGoldMine)
        Me.gbMineDeploy.Controls.Add(Me.udMaxTroopsMine)
        Me.gbMineDeploy.Controls.Add(Me.lblMaxTroopsMine)
        Me.gbMineDeploy.Controls.Add(Me.lblMinRuneMine)
        Me.gbMineDeploy.Controls.Add(Me.lblMinGoldMine)
        Me.gbMineDeploy.Controls.Add(Me.chkRuneMine)
        Me.gbMineDeploy.Controls.Add(Me.chkGoldMine)
        Me.gbMineDeploy.Enabled = False
        Me.gbMineDeploy.Location = New System.Drawing.Point(8, 283)
        Me.gbMineDeploy.Name = "gbMineDeploy"
        Me.gbMineDeploy.Size = New System.Drawing.Size(663, 113)
        Me.gbMineDeploy.TabIndex = 6
        Me.gbMineDeploy.TabStop = False
        Me.gbMineDeploy.Text = "Guild mines settings"
        '
        'udMinRuneMine
        '
        Me.udMinRuneMine.Enabled = False
        Me.udMinRuneMine.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.udMinRuneMine.Location = New System.Drawing.Point(230, 84)
        Me.udMinRuneMine.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udMinRuneMine.Name = "udMinRuneMine"
        Me.udMinRuneMine.Size = New System.Drawing.Size(86, 21)
        Me.udMinRuneMine.TabIndex = 9
        Me.udMinRuneMine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udMinRuneMine.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udMinGoldMine
        '
        Me.udMinGoldMine.Enabled = False
        Me.udMinGoldMine.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.udMinGoldMine.Location = New System.Drawing.Point(230, 57)
        Me.udMinGoldMine.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udMinGoldMine.Name = "udMinGoldMine"
        Me.udMinGoldMine.Size = New System.Drawing.Size(86, 21)
        Me.udMinGoldMine.TabIndex = 8
        Me.udMinGoldMine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udMinGoldMine.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'udMaxTroopsMine
        '
        Me.udMaxTroopsMine.Location = New System.Drawing.Point(110, 24)
        Me.udMaxTroopsMine.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.udMaxTroopsMine.Name = "udMaxTroopsMine"
        Me.udMaxTroopsMine.Size = New System.Drawing.Size(86, 21)
        Me.udMaxTroopsMine.TabIndex = 7
        Me.udMaxTroopsMine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udMaxTroopsMine.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'lblMaxTroopsMine
        '
        Me.lblMaxTroopsMine.AutoSize = True
        Me.lblMaxTroopsMine.Location = New System.Drawing.Point(7, 26)
        Me.lblMaxTroopsMine.Name = "lblMaxTroopsMine"
        Me.lblMaxTroopsMine.Size = New System.Drawing.Size(97, 13)
        Me.lblMaxTroopsMine.TabIndex = 6
        Me.lblMaxTroopsMine.Text = "Max troops in mine"
        '
        'lblMinRuneMine
        '
        Me.lblMinRuneMine.AutoSize = True
        Me.lblMinRuneMine.Enabled = False
        Me.lblMinRuneMine.Location = New System.Drawing.Point(103, 86)
        Me.lblMinRuneMine.Name = "lblMinRuneMine"
        Me.lblMinRuneMine.Size = New System.Drawing.Size(123, 13)
        Me.lblMinRuneMine.TabIndex = 3
        Me.lblMinRuneMine.Text = "Min rune amount in mine"
        '
        'lblMinGoldMine
        '
        Me.lblMinGoldMine.AutoSize = True
        Me.lblMinGoldMine.Enabled = False
        Me.lblMinGoldMine.Location = New System.Drawing.Point(103, 59)
        Me.lblMinGoldMine.Name = "lblMinGoldMine"
        Me.lblMinGoldMine.Size = New System.Drawing.Size(121, 13)
        Me.lblMinGoldMine.TabIndex = 2
        Me.lblMinGoldMine.Text = "Min gold amount in mine"
        '
        'chkRuneMine
        '
        Me.chkRuneMine.AutoSize = True
        Me.chkRuneMine.Location = New System.Drawing.Point(10, 85)
        Me.chkRuneMine.Name = "chkRuneMine"
        Me.chkRuneMine.Size = New System.Drawing.Size(87, 17)
        Me.chkRuneMine.TabIndex = 1
        Me.chkRuneMine.Text = "Rune minues"
        Me.chkRuneMine.UseVisualStyleBackColor = True
        '
        'chkGoldMine
        '
        Me.chkGoldMine.AutoSize = True
        Me.chkGoldMine.Location = New System.Drawing.Point(10, 58)
        Me.chkGoldMine.Name = "chkGoldMine"
        Me.chkGoldMine.Size = New System.Drawing.Size(77, 17)
        Me.chkGoldMine.TabIndex = 0
        Me.chkGoldMine.Text = "Gold mines"
        Me.chkGoldMine.UseVisualStyleBackColor = True
        '
        'chkMineDeploy
        '
        Me.chkMineDeploy.AutoSize = True
        Me.chkMineDeploy.Enabled = False
        Me.chkMineDeploy.Location = New System.Drawing.Point(8, 264)
        Me.chkMineDeploy.Name = "chkMineDeploy"
        Me.chkMineDeploy.Size = New System.Drawing.Size(114, 17)
        Me.chkMineDeploy.TabIndex = 5
        Me.chkMineDeploy.Text = "Guild mines deploy"
        Me.chkMineDeploy.UseVisualStyleBackColor = True
        '
        'chkInfiniteBattle
        '
        Me.chkInfiniteBattle.AutoSize = True
        Me.chkInfiniteBattle.Location = New System.Drawing.Point(8, 241)
        Me.chkInfiniteBattle.Name = "chkInfiniteBattle"
        Me.chkInfiniteBattle.Size = New System.Drawing.Size(213, 17)
        Me.chkInfiniteBattle.TabIndex = 4
        Me.chkInfiniteBattle.Text = "Infinite Battle (using default formation)"
        Me.chkInfiniteBattle.UseVisualStyleBackColor = True
        '
        'gbMonsterHunt
        '
        Me.gbMonsterHunt.Controls.Add(Me.btnEditMonsterSetup)
        Me.gbMonsterHunt.Controls.Add(Me.cboMonsterSetup)
        Me.gbMonsterHunt.Controls.Add(Me.lblActiveMonsterSetup)
        Me.gbMonsterHunt.Controls.Add(Me.btnBasicMonsterHuntSetup)
        Me.gbMonsterHunt.Enabled = False
        Me.gbMonsterHunt.Location = New System.Drawing.Point(8, 166)
        Me.gbMonsterHunt.Name = "gbMonsterHunt"
        Me.gbMonsterHunt.Size = New System.Drawing.Size(663, 54)
        Me.gbMonsterHunt.TabIndex = 3
        Me.gbMonsterHunt.TabStop = False
        Me.gbMonsterHunt.Text = "Monster hunt settings"
        '
        'btnEditMonsterSetup
        '
        Me.btnEditMonsterSetup.Location = New System.Drawing.Point(607, 20)
        Me.btnEditMonsterSetup.Name = "btnEditMonsterSetup"
        Me.btnEditMonsterSetup.Size = New System.Drawing.Size(50, 23)
        Me.btnEditMonsterSetup.TabIndex = 3
        Me.btnEditMonsterSetup.Text = "Edit"
        Me.btnEditMonsterSetup.UseVisualStyleBackColor = True
        '
        'cboMonsterSetup
        '
        Me.cboMonsterSetup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonsterSetup.FormattingEnabled = True
        Me.cboMonsterSetup.Location = New System.Drawing.Point(206, 22)
        Me.cboMonsterSetup.Name = "cboMonsterSetup"
        Me.cboMonsterSetup.Size = New System.Drawing.Size(395, 21)
        Me.cboMonsterSetup.Sorted = True
        Me.cboMonsterSetup.TabIndex = 2
        '
        'lblActiveMonsterSetup
        '
        Me.lblActiveMonsterSetup.AutoSize = True
        Me.lblActiveMonsterSetup.Location = New System.Drawing.Point(90, 25)
        Me.lblActiveMonsterSetup.Name = "lblActiveMonsterSetup"
        Me.lblActiveMonsterSetup.Size = New System.Drawing.Size(110, 13)
        Me.lblActiveMonsterSetup.TabIndex = 1
        Me.lblActiveMonsterSetup.Text = "Active Monster Setup"
        '
        'btnBasicMonsterHuntSetup
        '
        Me.btnBasicMonsterHuntSetup.Location = New System.Drawing.Point(9, 20)
        Me.btnBasicMonsterHuntSetup.Name = "btnBasicMonsterHuntSetup"
        Me.btnBasicMonsterHuntSetup.Size = New System.Drawing.Size(75, 23)
        Me.btnBasicMonsterHuntSetup.TabIndex = 0
        Me.btnBasicMonsterHuntSetup.Text = "New Setup"
        Me.btnBasicMonsterHuntSetup.UseVisualStyleBackColor = True
        '
        'optMonsterHunt
        '
        Me.optMonsterHunt.AutoSize = True
        Me.optMonsterHunt.Enabled = False
        Me.optMonsterHunt.Location = New System.Drawing.Point(8, 143)
        Me.optMonsterHunt.Name = "optMonsterHunt"
        Me.optMonsterHunt.Size = New System.Drawing.Size(90, 17)
        Me.optMonsterHunt.TabIndex = 2
        Me.optMonsterHunt.Text = "Monster Hunt"
        Me.optMonsterHunt.UseVisualStyleBackColor = True
        '
        'gbTower
        '
        Me.gbTower.Controls.Add(Me.chkTowerClimb)
        Me.gbTower.Controls.Add(Me.optHardTower)
        Me.gbTower.Controls.Add(Me.optRegularTower)
        Me.gbTower.Controls.Add(Me.btnCoopConfig)
        Me.gbTower.Controls.Add(Me.chkCoop)
        Me.gbTower.Controls.Add(Me.chkQuickBattle)
        Me.gbTower.Enabled = False
        Me.gbTower.Location = New System.Drawing.Point(8, 67)
        Me.gbTower.Name = "gbTower"
        Me.gbTower.Size = New System.Drawing.Size(663, 70)
        Me.gbTower.TabIndex = 1
        Me.gbTower.TabStop = False
        Me.gbTower.Text = "Tower settings"
        '
        'chkTowerClimb
        '
        Me.chkTowerClimb.AutoSize = True
        Me.chkTowerClimb.Location = New System.Drawing.Point(158, 43)
        Me.chkTowerClimb.Name = "chkTowerClimb"
        Me.chkTowerClimb.Size = New System.Drawing.Size(113, 17)
        Me.chkTowerClimb.TabIndex = 5
        Me.chkTowerClimb.Text = "Tower Climb Mode"
        Me.chkTowerClimb.UseVisualStyleBackColor = True
        '
        'optHardTower
        '
        Me.optHardTower.AutoSize = True
        Me.optHardTower.Location = New System.Drawing.Point(158, 20)
        Me.optHardTower.Name = "optHardTower"
        Me.optHardTower.Size = New System.Drawing.Size(81, 17)
        Me.optHardTower.TabIndex = 4
        Me.optHardTower.Text = "Hard Tower"
        Me.optHardTower.UseVisualStyleBackColor = True
        '
        'optRegularTower
        '
        Me.optRegularTower.AutoSize = True
        Me.optRegularTower.Location = New System.Drawing.Point(10, 20)
        Me.optRegularTower.Name = "optRegularTower"
        Me.optRegularTower.Size = New System.Drawing.Size(95, 17)
        Me.optRegularTower.TabIndex = 3
        Me.optRegularTower.Text = "Regular Tower"
        Me.optRegularTower.UseVisualStyleBackColor = True
        '
        'btnCoopConfig
        '
        Me.btnCoopConfig.Location = New System.Drawing.Point(511, 20)
        Me.btnCoopConfig.Name = "btnCoopConfig"
        Me.btnCoopConfig.Size = New System.Drawing.Size(146, 23)
        Me.btnCoopConfig.TabIndex = 2
        Me.btnCoopConfig.Text = "Configure Coop Mode"
        Me.btnCoopConfig.UseVisualStyleBackColor = True
        Me.btnCoopConfig.Visible = False
        '
        'chkCoop
        '
        Me.chkCoop.AutoSize = True
        Me.chkCoop.Location = New System.Drawing.Point(425, 24)
        Me.chkCoop.Name = "chkCoop"
        Me.chkCoop.Size = New System.Drawing.Size(80, 17)
        Me.chkCoop.TabIndex = 1
        Me.chkCoop.Text = "Coop Mode"
        Me.chkCoop.UseVisualStyleBackColor = True
        Me.chkCoop.Visible = False
        '
        'chkQuickBattle
        '
        Me.chkQuickBattle.AutoSize = True
        Me.chkQuickBattle.Location = New System.Drawing.Point(315, 24)
        Me.chkQuickBattle.Name = "chkQuickBattle"
        Me.chkQuickBattle.Size = New System.Drawing.Size(104, 17)
        Me.chkQuickBattle.TabIndex = 0
        Me.chkQuickBattle.Text = "Use Quick Battle"
        Me.chkQuickBattle.UseVisualStyleBackColor = True
        '
        'optTower
        '
        Me.optTower.AutoSize = True
        Me.optTower.Checked = True
        Me.optTower.Enabled = False
        Me.optTower.Location = New System.Drawing.Point(8, 44)
        Me.optTower.Name = "optTower"
        Me.optTower.Size = New System.Drawing.Size(55, 17)
        Me.optTower.TabIndex = 0
        Me.optTower.TabStop = True
        Me.optTower.Text = "Tower"
        Me.optTower.UseVisualStyleBackColor = True
        '
        'tpMisc
        '
        Me.tpMisc.Controls.Add(Me.chkAutoBuyRuneEssence)
        Me.tpMisc.Controls.Add(Me.gbAutoSell)
        Me.tpMisc.Controls.Add(Me.gbTimeout)
        Me.tpMisc.Controls.Add(Me.chkFodderEquip)
        Me.tpMisc.Controls.Add(Me.cboFodderPosition)
        Me.tpMisc.Controls.Add(Me.lblFodderPosition)
        Me.tpMisc.Controls.Add(Me.chkAutoFodderSwap)
        Me.tpMisc.Controls.Add(Me.chkAutoReadMessage)
        Me.tpMisc.Controls.Add(Me.chkAutoMineClaim)
        Me.tpMisc.Controls.Add(Me.chkAutoSell)
        Me.tpMisc.Location = New System.Drawing.Point(4, 22)
        Me.tpMisc.Name = "tpMisc"
        Me.tpMisc.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMisc.Size = New System.Drawing.Size(679, 545)
        Me.tpMisc.TabIndex = 2
        Me.tpMisc.Text = "Misc"
        Me.tpMisc.UseVisualStyleBackColor = True
        '
        'chkAutoBuyRuneEssence
        '
        Me.chkAutoBuyRuneEssence.AutoSize = True
        Me.chkAutoBuyRuneEssence.Location = New System.Drawing.Point(178, 29)
        Me.chkAutoBuyRuneEssence.Name = "chkAutoBuyRuneEssence"
        Me.chkAutoBuyRuneEssence.Size = New System.Drawing.Size(232, 17)
        Me.chkAutoBuyRuneEssence.TabIndex = 22
        Me.chkAutoBuyRuneEssence.Text = "Auto buy Rune Essence from Chrono Store"
        Me.chkAutoBuyRuneEssence.UseVisualStyleBackColor = True
        '
        'gbAutoSell
        '
        Me.gbAutoSell.Controls.Add(Me.lblSellFilter)
        Me.gbAutoSell.Controls.Add(Me.txtSellFilter)
        Me.gbAutoSell.Controls.Add(Me.optSellFilter)
        Me.gbAutoSell.Controls.Add(Me.optSellEverything)
        Me.gbAutoSell.Enabled = False
        Me.gbAutoSell.Location = New System.Drawing.Point(6, 52)
        Me.gbAutoSell.Name = "gbAutoSell"
        Me.gbAutoSell.Size = New System.Drawing.Size(663, 107)
        Me.gbAutoSell.TabIndex = 21
        Me.gbAutoSell.TabStop = False
        Me.gbAutoSell.Text = "Auto sell options"
        '
        'lblSellFilter
        '
        Me.lblSellFilter.Enabled = False
        Me.lblSellFilter.Location = New System.Drawing.Point(313, 20)
        Me.lblSellFilter.Name = "lblSellFilter"
        Me.lblSellFilter.Size = New System.Drawing.Size(136, 81)
        Me.lblSellFilter.TabIndex = 3
        Me.lblSellFilter.Text = "Type the item name at textbox, items not listed wont be sold. Type one item per l" &
    "ine or items separated by "";"" (semicolon)"
        '
        'txtSellFilter
        '
        Me.txtSellFilter.Enabled = False
        Me.txtSellFilter.Location = New System.Drawing.Point(455, 20)
        Me.txtSellFilter.Multiline = True
        Me.txtSellFilter.Name = "txtSellFilter"
        Me.txtSellFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSellFilter.Size = New System.Drawing.Size(202, 81)
        Me.txtSellFilter.TabIndex = 2
        Me.txtSellFilter.Text = "Adventure;Militia;Warlord;Gladiator;Golden;War God;Judgment;Ascended;Demigod;Ragn" &
    "arok"
        '
        'optSellFilter
        '
        Me.optSellFilter.AutoSize = True
        Me.optSellFilter.Location = New System.Drawing.Point(178, 20)
        Me.optSellFilter.Name = "optSellFilter"
        Me.optSellFilter.Size = New System.Drawing.Size(129, 17)
        Me.optSellFilter.TabIndex = 1
        Me.optSellFilter.TabStop = True
        Me.optSellFilter.Text = "Sell only filtered items"
        Me.optSellFilter.UseVisualStyleBackColor = True
        '
        'optSellEverything
        '
        Me.optSellEverything.AutoSize = True
        Me.optSellEverything.Location = New System.Drawing.Point(9, 20)
        Me.optSellEverything.Name = "optSellEverything"
        Me.optSellEverything.Size = New System.Drawing.Size(96, 17)
        Me.optSellEverything.TabIndex = 0
        Me.optSellEverything.TabStop = True
        Me.optSellEverything.Text = "Sell everything"
        Me.optSellEverything.UseVisualStyleBackColor = True
        '
        'gbTimeout
        '
        Me.gbTimeout.Controls.Add(Me.lblObsInfBattle)
        Me.gbTimeout.Controls.Add(Me.udInfBattle)
        Me.gbTimeout.Controls.Add(Me.lblInfBattle)
        Me.gbTimeout.Controls.Add(Me.lblObsColi)
        Me.gbTimeout.Controls.Add(Me.udAutoColi)
        Me.gbTimeout.Controls.Add(Me.lblColi)
        Me.gbTimeout.Controls.Add(Me.lblObsAutoSell)
        Me.gbTimeout.Controls.Add(Me.udAutoSell)
        Me.gbTimeout.Controls.Add(Me.lblAutoSell)
        Me.gbTimeout.Controls.Add(Me.lblObsGameFreeze)
        Me.gbTimeout.Controls.Add(Me.udGameFreeze)
        Me.gbTimeout.Controls.Add(Me.lblGameFreeze)
        Me.gbTimeout.Location = New System.Drawing.Point(6, 165)
        Me.gbTimeout.Name = "gbTimeout"
        Me.gbTimeout.Size = New System.Drawing.Size(663, 143)
        Me.gbTimeout.TabIndex = 20
        Me.gbTimeout.TabStop = False
        Me.gbTimeout.Text = "Timeouts"
        '
        'lblObsInfBattle
        '
        Me.lblObsInfBattle.AutoSize = True
        Me.lblObsInfBattle.Location = New System.Drawing.Point(206, 109)
        Me.lblObsInfBattle.Name = "lblObsInfBattle"
        Me.lblObsInfBattle.Size = New System.Drawing.Size(243, 13)
        Me.lblObsInfBattle.TabIndex = 11
        Me.lblObsInfBattle.Text = "(start infinite battle after this amount of minutes)"
        '
        'udInfBattle
        '
        Me.udInfBattle.Location = New System.Drawing.Point(114, 107)
        Me.udInfBattle.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udInfBattle.Name = "udInfBattle"
        Me.udInfBattle.Size = New System.Drawing.Size(86, 21)
        Me.udInfBattle.TabIndex = 10
        Me.udInfBattle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udInfBattle.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblInfBattle
        '
        Me.lblInfBattle.AutoSize = True
        Me.lblInfBattle.Location = New System.Drawing.Point(6, 109)
        Me.lblInfBattle.Name = "lblInfBattle"
        Me.lblInfBattle.Size = New System.Drawing.Size(82, 13)
        Me.lblInfBattle.TabIndex = 9
        Me.lblInfBattle.Text = "Auto Inf. Battle"
        '
        'lblObsColi
        '
        Me.lblObsColi.AutoSize = True
        Me.lblObsColi.Location = New System.Drawing.Point(206, 82)
        Me.lblObsColi.Name = "lblObsColi"
        Me.lblObsColi.Size = New System.Drawing.Size(220, 13)
        Me.lblObsColi.TabIndex = 8
        Me.lblObsColi.Text = "(start coli fight after this amount of minutes)"
        '
        'udAutoColi
        '
        Me.udAutoColi.Location = New System.Drawing.Point(114, 80)
        Me.udAutoColi.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udAutoColi.Name = "udAutoColi"
        Me.udAutoColi.Size = New System.Drawing.Size(86, 21)
        Me.udAutoColi.TabIndex = 7
        Me.udAutoColi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udAutoColi.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblColi
        '
        Me.lblColi.AutoSize = True
        Me.lblColi.Location = New System.Drawing.Point(6, 82)
        Me.lblColi.Name = "lblColi"
        Me.lblColi.Size = New System.Drawing.Size(50, 13)
        Me.lblColi.TabIndex = 6
        Me.lblColi.Text = "Auto Coli"
        '
        'lblObsAutoSell
        '
        Me.lblObsAutoSell.AutoSize = True
        Me.lblObsAutoSell.Location = New System.Drawing.Point(206, 55)
        Me.lblObsAutoSell.Name = "lblObsAutoSell"
        Me.lblObsAutoSell.Size = New System.Drawing.Size(255, 13)
        Me.lblObsAutoSell.TabIndex = 5
        Me.lblObsAutoSell.Text = "(sell all unlocked items after this amount of minutes)"
        '
        'udAutoSell
        '
        Me.udAutoSell.Location = New System.Drawing.Point(114, 53)
        Me.udAutoSell.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udAutoSell.Name = "udAutoSell"
        Me.udAutoSell.Size = New System.Drawing.Size(86, 21)
        Me.udAutoSell.TabIndex = 4
        Me.udAutoSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udAutoSell.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblAutoSell
        '
        Me.lblAutoSell.AutoSize = True
        Me.lblAutoSell.Location = New System.Drawing.Point(6, 55)
        Me.lblAutoSell.Name = "lblAutoSell"
        Me.lblAutoSell.Size = New System.Drawing.Size(48, 13)
        Me.lblAutoSell.TabIndex = 3
        Me.lblAutoSell.Text = "Auto sell"
        '
        'lblObsGameFreeze
        '
        Me.lblObsGameFreeze.AutoSize = True
        Me.lblObsGameFreeze.Location = New System.Drawing.Point(206, 28)
        Me.lblObsGameFreeze.Name = "lblObsGameFreeze"
        Me.lblObsGameFreeze.Size = New System.Drawing.Size(316, 13)
        Me.lblObsGameFreeze.TabIndex = 2
        Me.lblObsGameFreeze.Text = "(restart Bluestacks after the amount of minutes without activity)"
        '
        'udGameFreeze
        '
        Me.udGameFreeze.Location = New System.Drawing.Point(114, 26)
        Me.udGameFreeze.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.udGameFreeze.Name = "udGameFreeze"
        Me.udGameFreeze.Size = New System.Drawing.Size(86, 21)
        Me.udGameFreeze.TabIndex = 1
        Me.udGameFreeze.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.udGameFreeze.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblGameFreeze
        '
        Me.lblGameFreeze.AutoSize = True
        Me.lblGameFreeze.Location = New System.Drawing.Point(6, 28)
        Me.lblGameFreeze.Name = "lblGameFreeze"
        Me.lblGameFreeze.Size = New System.Drawing.Size(68, 13)
        Me.lblGameFreeze.TabIndex = 0
        Me.lblGameFreeze.Text = "Game freeze"
        '
        'chkFodderEquip
        '
        Me.chkFodderEquip.AutoSize = True
        Me.chkFodderEquip.Enabled = False
        Me.chkFodderEquip.Location = New System.Drawing.Point(353, 465)
        Me.chkFodderEquip.Name = "chkFodderEquip"
        Me.chkFodderEquip.Size = New System.Drawing.Size(87, 17)
        Me.chkFodderEquip.TabIndex = 15
        Me.chkFodderEquip.Text = "Equip fodder"
        Me.chkFodderEquip.UseVisualStyleBackColor = True
        Me.chkFodderEquip.Visible = False
        '
        'cboFodderPosition
        '
        Me.cboFodderPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFodderPosition.Enabled = False
        Me.cboFodderPosition.FormattingEnabled = True
        Me.cboFodderPosition.Items.AddRange(New Object() {"2", "3", "4", "5", "6"})
        Me.cboFodderPosition.Location = New System.Drawing.Point(289, 463)
        Me.cboFodderPosition.Name = "cboFodderPosition"
        Me.cboFodderPosition.Size = New System.Drawing.Size(58, 21)
        Me.cboFodderPosition.TabIndex = 14
        Me.cboFodderPosition.Visible = False
        '
        'lblFodderPosition
        '
        Me.lblFodderPosition.AutoSize = True
        Me.lblFodderPosition.Enabled = False
        Me.lblFodderPosition.Location = New System.Drawing.Point(129, 467)
        Me.lblFodderPosition.Name = "lblFodderPosition"
        Me.lblFodderPosition.Size = New System.Drawing.Size(154, 13)
        Me.lblFodderPosition.TabIndex = 13
        Me.lblFodderPosition.Text = "Fodder position in deploy team"
        Me.lblFodderPosition.Visible = False
        '
        'chkAutoFodderSwap
        '
        Me.chkAutoFodderSwap.AutoSize = True
        Me.chkAutoFodderSwap.Location = New System.Drawing.Point(7, 465)
        Me.chkAutoFodderSwap.Name = "chkAutoFodderSwap"
        Me.chkAutoFodderSwap.Size = New System.Drawing.Size(115, 17)
        Me.chkAutoFodderSwap.TabIndex = 12
        Me.chkAutoFodderSwap.Text = "Auto Fodder Swap"
        Me.chkAutoFodderSwap.UseVisualStyleBackColor = True
        Me.chkAutoFodderSwap.Visible = False
        '
        'chkAutoReadMessage
        '
        Me.chkAutoReadMessage.AutoSize = True
        Me.chkAutoReadMessage.Enabled = False
        Me.chkAutoReadMessage.Location = New System.Drawing.Point(178, 6)
        Me.chkAutoReadMessage.Name = "chkAutoReadMessage"
        Me.chkAutoReadMessage.Size = New System.Drawing.Size(124, 17)
        Me.chkAutoReadMessage.TabIndex = 11
        Me.chkAutoReadMessage.Text = "Auto read messages"
        Me.chkAutoReadMessage.UseVisualStyleBackColor = True
        '
        'chkAutoMineClaim
        '
        Me.chkAutoMineClaim.AutoSize = True
        Me.chkAutoMineClaim.Location = New System.Drawing.Point(8, 6)
        Me.chkAutoMineClaim.Name = "chkAutoMineClaim"
        Me.chkAutoMineClaim.Size = New System.Drawing.Size(100, 17)
        Me.chkAutoMineClaim.TabIndex = 10
        Me.chkAutoMineClaim.Text = "Auto mine claim"
        Me.chkAutoMineClaim.UseVisualStyleBackColor = True
        '
        'chkAutoSell
        '
        Me.chkAutoSell.AutoSize = True
        Me.chkAutoSell.Location = New System.Drawing.Point(8, 29)
        Me.chkAutoSell.Name = "chkAutoSell"
        Me.chkAutoSell.Size = New System.Drawing.Size(67, 17)
        Me.chkAutoSell.TabIndex = 9
        Me.chkAutoSell.Text = "Auto sell"
        Me.chkAutoSell.UseVisualStyleBackColor = True
        '
        'tpTools
        '
        Me.tpTools.Controls.Add(Me.lblAdvancedHireFuse)
        Me.tpTools.Controls.Add(Me.btnAbortHireFuse)
        Me.tpTools.Controls.Add(Me.btnAwaken)
        Me.tpTools.Controls.Add(Me.btmBotSetup)
        Me.tpTools.Controls.Add(Me.btnFuseHire)
        Me.tpTools.Location = New System.Drawing.Point(4, 22)
        Me.tpTools.Name = "tpTools"
        Me.tpTools.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTools.Size = New System.Drawing.Size(679, 545)
        Me.tpTools.TabIndex = 4
        Me.tpTools.Text = "Tools"
        Me.tpTools.UseVisualStyleBackColor = True
        '
        'btnAbortHireFuse
        '
        Me.btnAbortHireFuse.Location = New System.Drawing.Point(148, 6)
        Me.btnAbortHireFuse.Name = "btnAbortHireFuse"
        Me.btnAbortHireFuse.Size = New System.Drawing.Size(133, 23)
        Me.btnAbortHireFuse.TabIndex = 7
        Me.btnAbortHireFuse.Text = "Abort Hire and Fuse!"
        Me.btnAbortHireFuse.UseVisualStyleBackColor = True
        Me.btnAbortHireFuse.Visible = False
        '
        'btnAwaken
        '
        Me.btnAwaken.Location = New System.Drawing.Point(6, 35)
        Me.btnAwaken.Name = "btnAwaken"
        Me.btnAwaken.Size = New System.Drawing.Size(133, 23)
        Me.btnAwaken.TabIndex = 6
        Me.btnAwaken.Text = "Auto Awaken Hero"
        Me.btnAwaken.UseVisualStyleBackColor = True
        '
        'btmBotSetup
        '
        Me.btmBotSetup.Location = New System.Drawing.Point(8, 514)
        Me.btmBotSetup.Name = "btmBotSetup"
        Me.btmBotSetup.Size = New System.Drawing.Size(133, 23)
        Me.btmBotSetup.TabIndex = 5
        Me.btmBotSetup.Text = "BOT Setup"
        Me.btmBotSetup.UseVisualStyleBackColor = True
        '
        'btnFuseHire
        '
        Me.btnFuseHire.Location = New System.Drawing.Point(6, 6)
        Me.btnFuseHire.Name = "btnFuseHire"
        Me.btnFuseHire.Size = New System.Drawing.Size(133, 23)
        Me.btnFuseHire.TabIndex = 4
        Me.btnFuseHire.Text = "Auto Hire and Fuse"
        Me.btnFuseHire.UseVisualStyleBackColor = True
        '
        'tpStats
        '
        Me.tpStats.Controls.Add(Me.lblFightsHour)
        Me.tpStats.Controls.Add(Me.GroupBox1)
        Me.tpStats.Controls.Add(Me.lblFights)
        Me.tpStats.Controls.Add(Me.lblStatBotTime)
        Me.tpStats.Controls.Add(Me.gbStatsGold)
        Me.tpStats.Location = New System.Drawing.Point(4, 22)
        Me.tpStats.Name = "tpStats"
        Me.tpStats.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStats.Size = New System.Drawing.Size(679, 545)
        Me.tpStats.TabIndex = 5
        Me.tpStats.Text = "Stats"
        Me.tpStats.UseVisualStyleBackColor = True
        '
        'lblFightsHour
        '
        Me.lblFightsHour.AutoSize = True
        Me.lblFightsHour.Location = New System.Drawing.Point(311, 12)
        Me.lblFightsHour.Name = "lblFightsHour"
        Me.lblFightsHour.Size = New System.Drawing.Size(76, 13)
        Me.lblFightsHour.TabIndex = 5
        Me.lblFightsHour.Text = "Fights/Hour: 0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grExp)
        Me.GroupBox1.Controls.Add(Me.lblStatsTotalExpMinute)
        Me.GroupBox1.Controls.Add(Me.lblStatsTotalExp)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 318)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(663, 219)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Experience"
        '
        'grExp
        '
        Me.grExp.Color = System.Drawing.Color.SeaGreen
        Me.grExp.Location = New System.Drawing.Point(6, 33)
        Me.grExp.Name = "grExp"
        Me.grExp.Size = New System.Drawing.Size(648, 180)
        Me.grExp.TabIndex = 8
        '
        'lblStatsTotalExpMinute
        '
        Me.lblStatsTotalExpMinute.AutoSize = True
        Me.lblStatsTotalExpMinute.Location = New System.Drawing.Point(190, 17)
        Me.lblStatsTotalExpMinute.Name = "lblStatsTotalExpMinute"
        Me.lblStatsTotalExpMinute.Size = New System.Drawing.Size(101, 13)
        Me.lblStatsTotalExpMinute.TabIndex = 6
        Me.lblStatsTotalExpMinute.Text = "Total Exp/Minute: 0"
        '
        'lblStatsTotalExp
        '
        Me.lblStatsTotalExp.AutoSize = True
        Me.lblStatsTotalExp.Location = New System.Drawing.Point(6, 17)
        Me.lblStatsTotalExp.Name = "lblStatsTotalExp"
        Me.lblStatsTotalExp.Size = New System.Drawing.Size(100, 13)
        Me.lblStatsTotalExp.TabIndex = 5
        Me.lblStatsTotalExp.Text = "Total Experience: 0"
        '
        'lblFights
        '
        Me.lblFights.AutoSize = True
        Me.lblFights.Location = New System.Drawing.Point(178, 12)
        Me.lblFights.Name = "lblFights"
        Me.lblFights.Size = New System.Drawing.Size(49, 13)
        Me.lblFights.TabIndex = 3
        Me.lblFights.Text = "Fights: 0"
        '
        'lblStatBotTime
        '
        Me.lblStatBotTime.AutoSize = True
        Me.lblStatBotTime.Location = New System.Drawing.Point(8, 12)
        Me.lblStatBotTime.Name = "lblStatBotTime"
        Me.lblStatBotTime.Size = New System.Drawing.Size(99, 13)
        Me.lblStatBotTime.TabIndex = 2
        Me.lblStatBotTime.Text = "Bot Time: 00:00:00"
        '
        'gbStatsGold
        '
        Me.gbStatsGold.Controls.Add(Me.grGold)
        Me.gbStatsGold.Controls.Add(Me.lblStatsGoldBalanceHour)
        Me.gbStatsGold.Controls.Add(Me.lblStatsGoldBalance)
        Me.gbStatsGold.Controls.Add(Me.lblStatsCurrentGold)
        Me.gbStatsGold.Controls.Add(Me.lblStatsStartGold)
        Me.gbStatsGold.Location = New System.Drawing.Point(8, 93)
        Me.gbStatsGold.Name = "gbStatsGold"
        Me.gbStatsGold.Size = New System.Drawing.Size(663, 219)
        Me.gbStatsGold.TabIndex = 0
        Me.gbStatsGold.TabStop = False
        Me.gbStatsGold.Text = "Gold"
        '
        'grGold
        '
        Me.grGold.Color = System.Drawing.Color.DarkGoldenrod
        Me.grGold.Location = New System.Drawing.Point(9, 33)
        Me.grGold.Name = "grGold"
        Me.grGold.Size = New System.Drawing.Size(648, 180)
        Me.grGold.TabIndex = 7
        '
        'lblStatsGoldBalanceHour
        '
        Me.lblStatsGoldBalanceHour.AutoSize = True
        Me.lblStatsGoldBalanceHour.Location = New System.Drawing.Point(488, 17)
        Me.lblStatsGoldBalanceHour.Name = "lblStatsGoldBalanceHour"
        Me.lblStatsGoldBalanceHour.Size = New System.Drawing.Size(108, 13)
        Me.lblStatsGoldBalanceHour.TabIndex = 6
        Me.lblStatsGoldBalanceHour.Text = "Gold Balance/Hour: 0"
        '
        'lblStatsGoldBalance
        '
        Me.lblStatsGoldBalance.AutoSize = True
        Me.lblStatsGoldBalance.Location = New System.Drawing.Point(323, 17)
        Me.lblStatsGoldBalance.Name = "lblStatsGoldBalance"
        Me.lblStatsGoldBalance.Size = New System.Drawing.Size(81, 13)
        Me.lblStatsGoldBalance.TabIndex = 5
        Me.lblStatsGoldBalance.Text = "Gold Balance: 0"
        '
        'lblStatsCurrentGold
        '
        Me.lblStatsCurrentGold.AutoSize = True
        Me.lblStatsCurrentGold.Location = New System.Drawing.Point(158, 17)
        Me.lblStatsCurrentGold.Name = "lblStatsCurrentGold"
        Me.lblStatsCurrentGold.Size = New System.Drawing.Size(81, 13)
        Me.lblStatsCurrentGold.TabIndex = 4
        Me.lblStatsCurrentGold.Text = "Current Gold: 0"
        '
        'lblStatsStartGold
        '
        Me.lblStatsStartGold.AutoSize = True
        Me.lblStatsStartGold.Location = New System.Drawing.Point(6, 17)
        Me.lblStatsStartGold.Name = "lblStatsStartGold"
        Me.lblStatsStartGold.Size = New System.Drawing.Size(68, 13)
        Me.lblStatsStartGold.TabIndex = 3
        Me.lblStatsStartGold.Text = "Start Gold: 0"
        '
        'tpLog
        '
        Me.tpLog.Controls.Add(Me.txtLog)
        Me.tpLog.Location = New System.Drawing.Point(4, 22)
        Me.tpLog.Name = "tpLog"
        Me.tpLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLog.Size = New System.Drawing.Size(679, 545)
        Me.tpLog.TabIndex = 6
        Me.tpLog.Text = "Log"
        Me.tpLog.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLog.Location = New System.Drawing.Point(3, 3)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(673, 539)
        Me.txtLog.TabIndex = 0
        Me.txtLog.WordWrap = False
        '
        'lblAdvancedHireFuse
        '
        Me.lblAdvancedHireFuse.AutoSize = True
        Me.lblAdvancedHireFuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAdvancedHireFuse.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvancedHireFuse.ForeColor = System.Drawing.Color.Blue
        Me.lblAdvancedHireFuse.Location = New System.Drawing.Point(8, 87)
        Me.lblAdvancedHireFuse.Name = "lblAdvancedHireFuse"
        Me.lblAdvancedHireFuse.Size = New System.Drawing.Size(124, 13)
        Me.lblAdvancedHireFuse.TabIndex = 8
        Me.lblAdvancedHireFuse.Text = "Advanced Hire and Fuse"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 571)
        Me.Controls.Add(Me.tcBot)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "LoHBot"
        Me.tcBot.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpMain.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAttack.ResumeLayout(False)
        Me.tpAttack.PerformLayout()
        Me.gbMineDeploy.ResumeLayout(False)
        Me.gbMineDeploy.PerformLayout()
        CType(Me.udMinRuneMine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udMinGoldMine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udMaxTroopsMine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMonsterHunt.ResumeLayout(False)
        Me.gbMonsterHunt.PerformLayout()
        Me.gbTower.ResumeLayout(False)
        Me.gbTower.PerformLayout()
        Me.tpMisc.ResumeLayout(False)
        Me.tpMisc.PerformLayout()
        Me.gbAutoSell.ResumeLayout(False)
        Me.gbAutoSell.PerformLayout()
        Me.gbTimeout.ResumeLayout(False)
        Me.gbTimeout.PerformLayout()
        CType(Me.udInfBattle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAutoColi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAutoSell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udGameFreeze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTools.ResumeLayout(False)
        Me.tpTools.PerformLayout()
        Me.tpStats.ResumeLayout(False)
        Me.tpStats.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbStatsGold.ResumeLayout(False)
        Me.gbStatsGold.PerformLayout()
        Me.tpLog.ResumeLayout(False)
        Me.tpLog.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcBot As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents picMain As System.Windows.Forms.PictureBox
    Friend WithEvents tpAttack As System.Windows.Forms.TabPage
    Friend WithEvents tpMisc As System.Windows.Forms.TabPage
    Friend WithEvents tpTools As System.Windows.Forms.TabPage
    Friend WithEvents tpStats As System.Windows.Forms.TabPage
    Friend WithEvents tpLog As System.Windows.Forms.TabPage
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents gbTower As System.Windows.Forms.GroupBox
    Friend WithEvents optTower As System.Windows.Forms.RadioButton
    Friend WithEvents chkQuickBattle As System.Windows.Forms.CheckBox
    Friend WithEvents gbMonsterHunt As System.Windows.Forms.GroupBox
    Friend WithEvents optMonsterHunt As System.Windows.Forms.RadioButton
    Friend WithEvents btnBasicMonsterHuntSetup As System.Windows.Forms.Button
    Friend WithEvents chkInfiniteBattle As System.Windows.Forms.CheckBox
    Friend WithEvents gbMineDeploy As System.Windows.Forms.GroupBox
    Friend WithEvents chkMineDeploy As System.Windows.Forms.CheckBox
    Friend WithEvents lblMinRuneMine As System.Windows.Forms.Label
    Friend WithEvents lblMinGoldMine As System.Windows.Forms.Label
    Friend WithEvents chkRuneMine As System.Windows.Forms.CheckBox
    Friend WithEvents chkGoldMine As System.Windows.Forms.CheckBox
    Friend WithEvents chkColiBattle As System.Windows.Forms.CheckBox
    Friend WithEvents lblMaxTroopsMine As System.Windows.Forms.Label
    Friend WithEvents chkAutoTowerMonsterHunt As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoReadMessage As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoMineClaim As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSell As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoFodderSwap As System.Windows.Forms.CheckBox
    Friend WithEvents cboFodderPosition As System.Windows.Forms.ComboBox
    Friend WithEvents lblFodderPosition As System.Windows.Forms.Label
    Friend WithEvents chkFodderEquip As System.Windows.Forms.CheckBox
    Friend WithEvents gbTimeout As System.Windows.Forms.GroupBox
    Friend WithEvents lblObsInfBattle As System.Windows.Forms.Label
    Friend WithEvents udInfBattle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblInfBattle As System.Windows.Forms.Label
    Friend WithEvents lblObsColi As System.Windows.Forms.Label
    Friend WithEvents udAutoColi As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblColi As System.Windows.Forms.Label
    Friend WithEvents lblObsAutoSell As System.Windows.Forms.Label
    Friend WithEvents udAutoSell As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAutoSell As System.Windows.Forms.Label
    Friend WithEvents lblObsGameFreeze As System.Windows.Forms.Label
    Friend WithEvents udGameFreeze As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblGameFreeze As System.Windows.Forms.Label
    Friend WithEvents udMaxTroopsMine As System.Windows.Forms.NumericUpDown
    Friend WithEvents udMinRuneMine As System.Windows.Forms.NumericUpDown
    Friend WithEvents udMinGoldMine As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblBluestacksVersion As System.Windows.Forms.Label
    Friend WithEvents lblGameAccountName As System.Windows.Forms.Label
    Friend WithEvents lblGold As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnFuseHire As System.Windows.Forms.Button
    Friend WithEvents gbStatsGold As System.Windows.Forms.GroupBox
    Friend WithEvents lblFightsHour As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFights As System.Windows.Forms.Label
    Friend WithEvents lblStatBotTime As System.Windows.Forms.Label
    Friend WithEvents lblStatsGoldBalanceHour As System.Windows.Forms.Label
    Friend WithEvents lblStatsGoldBalance As System.Windows.Forms.Label
    Friend WithEvents lblStatsCurrentGold As System.Windows.Forms.Label
    Friend WithEvents lblStatsStartGold As System.Windows.Forms.Label
    Friend WithEvents lblStatsTotalExpMinute As System.Windows.Forms.Label
    Friend WithEvents lblStatsTotalExp As System.Windows.Forms.Label
    Friend WithEvents lblActiveMonsterSetup As System.Windows.Forms.Label
    Friend WithEvents cboMonsterSetup As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditMonsterSetup As System.Windows.Forms.Button
    Friend WithEvents btmBotSetup As System.Windows.Forms.Button
    Friend WithEvents grGold As LoHBot.Graph
    Friend WithEvents grExp As LoHBot.Graph
    Friend WithEvents btnAwaken As System.Windows.Forms.Button
    Friend WithEvents chkFastPixel As System.Windows.Forms.CheckBox
    Friend WithEvents btnAbortHireFuse As System.Windows.Forms.Button
    Friend WithEvents btnCoopConfig As System.Windows.Forms.Button
    Friend WithEvents chkCoop As System.Windows.Forms.CheckBox
    Friend WithEvents gbAutoSell As System.Windows.Forms.GroupBox
    Friend WithEvents lblSellFilter As System.Windows.Forms.Label
    Friend WithEvents txtSellFilter As System.Windows.Forms.TextBox
    Friend WithEvents optSellFilter As System.Windows.Forms.RadioButton
    Friend WithEvents optSellEverything As System.Windows.Forms.RadioButton
    Friend WithEvents optHardTower As System.Windows.Forms.RadioButton
    Friend WithEvents optRegularTower As System.Windows.Forms.RadioButton
    Friend WithEvents chkAutoBuyRuneEssence As System.Windows.Forms.CheckBox
    Friend WithEvents llForum As LinkLabel
    Friend WithEvents llPage As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents chkTowerClimb As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lblAdvancedHireFuse As Label
End Class
