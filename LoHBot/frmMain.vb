Public Class frmMain
    Private Loading As Boolean = True
    Private THBot As Threading.Thread
    Private THFuse As Threading.Thread

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            StopBOT()
            Do While IsRunning
                Threading.Thread.Sleep(100)
            Loop
            Application.Exit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llPage.Links.Add(0, llPage.Text.Length, "http://www.thebotbay.com/blogs/")
        llForum.Links.Add(0, llForum.Text.Length, "http://www.thebotbay.com/forums/")

        If Environment.GetEnvironmentVariables.Contains("TESSDATA_PREFIX") Then
            MsgBox("Please, remove your environment variable named [TESSDATA_PREFIX]. It cause conflict with OCR engine used in BOT!", MsgBoxStyle.Critical)
            End
        End If

        If Not IsAdmin() Then
            MsgBox("LohBot must be executed as Administrator!", MsgBoxStyle.Critical)
            End
        End If

        If Not System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64") Then
            MsgBox("BOT only work at 64bit environment!", MsgBoxStyle.Critical)
            End
        End If

        ResourcesPath = IO.Path.Combine(My.Application.Info.DirectoryPath, "Resources")
        Try
            If Not IO.Directory.Exists(ResourcesPath) Then
                MsgBox("You dont have resources path! Download the full version of BOT.", MsgBoxStyle.Exclamation)
                IO.Directory.CreateDirectory(ResourcesPath)
            End If
        Catch ex As Exception
            MsgBox("Cant create resources path at [" & ResourcesPath & "]!" & Environment.NewLine & Environment.NewLine & ex.ToString, MsgBoxStyle.Critical)
            End
        End Try

        Me.Enabled = False
        BOTRes.Load()

        BotWnd = Me
        Me.Visible = True
        tcBot.SelectedTab = tpLog

        Application.DoEvents()

        lblVersion.Parent = picMain
        lblBluestacksVersion.Parent = picMain
        lblGameAccountName.Parent = picMain
        lblGold.Parent = picMain

        Dim BSVersion As Version = GetBluestacksVersion()
        lblBluestacksVersion.Text = "Bluestacks Version: " & BSVersion.ToString
        If BSVersion.Major = 0 Then
            StaticEmulator = New Emulator(New Bluestacks0)
            Log("Using Bluestacks version " & StaticEmulator.Version.ToString)
        ElseIf BSVersion.Major = 2 Then
            StaticEmulator = New Emulator(New Bluestacks2)
            Log("Using Bluestacks version " & StaticEmulator.Version.ToString)
        Else
            MsgBox("Bot is not compatible with Bluestacks Version " & BSVersion.ToString)
        End If

        lblVersion.Text = "BOT Version: " & My.Application.Info.Version.ToString
        Me.Text = "LoHBot - Version: " & My.Application.Info.Version.ToString
        Me.Height += Me.Size.Height - Me.ClientSize.Height
        Me.Top = 0
        Me.Left = 0

        Log("LoHBot Version: " & My.Application.Info.Version.ToString)
        Log("Running As Administrator...")
        Log("Searching for Bluestacks...")

        CheckNewVersion()
        If Not StaticEmulator.IsEmulatorRunning Then
            Log(StaticEmulator.ToString & " is not running... Loading BS and LOH, please wait!")
            If Not StaticEmulator.StartGame Then
                Log("Something went wrong loading LOH, please try manually... Closing BOT")
                End
            Else
                If Not StaticEmulator.IsEmulatorResolutionCorrect Then
                    Log(StaticEmulator.ToString & " not running at correct resolution, fixing it")
                    StaticEmulator.FixEmulatorResolution()
                    Log("Restarting " & StaticEmulator.ToString & "... Please wait")
                    StaticEmulator.StopGame()
                    StaticEmulator.StopEmulator()

                    If Not StaticEmulator.StartGame Then
                        Log("Something went wrong loading LOH, please try manually... Closing BOT")
                        End
                    End If
                    If Not StaticEmulator.IsEmulatorResolutionCorrect Then
                        Log("Cant fix emulator resolution, ask for help on our forum: http://www.thebotbay.com/forums/")
                        End
                    End If
                End If
            End If
        Else
            Log(StaticEmulator.ToString & " running...")
            Log("Checking " & StaticEmulator.ToString & " resolution...")
            If Not StaticEmulator.IsEmulatorResolutionCorrect Then
                If StaticEmulator.ToString = "MEmu" Then
                    MsgBox("BOT cant fix manually MEmu resolution. Do it at emulator settings. Custom Resolution: Width = 960, Height = 552 and DPI = 192", MsgBoxStyle.Critical)
                    End
                End If

                If MsgBox("Want BOT fix " & StaticEmulator.ToString & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    Log(StaticEmulator.ToString & " not running at correct resolution, fixing it")
                    StaticEmulator.FixEmulatorResolution()
                    Log("Restarting " & StaticEmulator.ToString & "... Please wait")
                    StaticEmulator.StopGame()
                    StaticEmulator.StopEmulator()

                    If Not StaticEmulator.StartGame Then
                        Log("Something went wrong loading LOH, please try manually... Closing BOT")
                        End
                    End If
                    If Not StaticEmulator.IsEmulatorResolutionCorrect Then
                        Log("Cant fix emulator resolution, ask for help on our forum: http://www.thebotbay.com/forums/")
                        End
                    End If
                End If
            Else
                Log(StaticEmulator.ToString & " resolution is correct...")
            End If

            Log("Check if LOH is running...")
            If StaticEmulator.IsGameRunning Then
                Log("Game is running")
            Else
                Log("Starting LOH...")
                StaticEmulator.StartGame()
            End If
        End If

        CFG = New BOTSettings
        CFG.Load()

        If Not InMainScreen(False) Then
            Log("Waiting for game main screen...")
            Dim SW As Stopwatch = Stopwatch.StartNew
            Dim LAST_LOG As Stopwatch = Stopwatch.StartNew
            Do While Not InMainScreen(False)
                Threading.Thread.Sleep(1000)
                If LAST_LOG.Elapsed.TotalSeconds > 10 Then
                    Log("Waiting for game main screen...:" & CInt(SW.Elapsed.TotalSeconds) & " seconds elapsed")
                    LAST_LOG = Stopwatch.StartNew
                End If
                If SW.Elapsed.TotalMinutes >= 5 Then
                    Log("Game main screen timeout... Closing BOT")
                    End
                End If
            Loop
        End If

        ClosePopup()

        Dim BSHWnd As IntPtr = StaticEmulator.GetHWnd
        Dim RectAPI As User32.RECT
        User32.GetWindowRect(BSHWnd, RectAPI)
        User32.MoveWindow(BSHWnd, Me.Left + Me.Width, Me.Top, RectAPI.right - RectAPI.left, RectAPI.bottom - RectAPI.top, True)
        User32.SetForegroundWindow(BSHWnd)

        Me.Visible = True
        Me.tcBot.SelectedTab = tpLog

        With CFG
            chkAutoTowerMonsterHunt.Checked = .AutoTowerHunt
            optTower.Checked = .AutoTower
            optRegularTower.Checked = .AutoTowerRegular
            optHardTower.Checked = .AutoTowerHard
            chkTowerClimb.Checked = .AutoTowerHard_ClimbMode

            chkAutoBuyRuneEssence.Checked = .AutoBuyRuneEssence

            chkQuickBattle.Checked = .AutoTower_QuickBattle
            chkCoop.Checked = .AutoTower_Coop

            optMonsterHunt.Checked = .AutoHunt
            chkInfiniteBattle.Checked = .InfiniteBattle
            chkColiBattle.Checked = .ColiBattle
            chkMineDeploy.Checked = .GuildMineDeploy
            udMaxTroopsMine.Value = .GuildMineDeploy_MaxTroops
            chkGoldMine.Checked = .GuildMineDeploy_Gold
            chkRuneMine.Checked = .GuildMineDeploy_Rune
            udMinGoldMine.Value = .GuildMineDeploy_GoldMin
            udMinRuneMine.Value = .GuildMineDeploy_RuneMin

            chkAutoSell.Checked = .AutoSell
            optSellEverything.Checked = .AutoSellEverything
            optSellFilter.Checked = .AutoSellFilter
            txtSellFilter.Text = .AutoSellFilterItems

            chkAutoMineClaim.Checked = .AutoMineClaim
            chkAutoReadMessage.Checked = .AutoReadMessage
            chkAutoFodderSwap.Checked = .FodderSwap
            cboFodderPosition.SelectedIndex = cboFodderPosition.FindStringExact(.FodderSwapPosition.ToString)
            chkFodderEquip.Checked = .FodderSwapGear

            udGameFreeze.Value = .TimeoutFreeze
            udAutoSell.Value = .TimeoutSell
            udAutoColi.Value = .TimeoutColi
            udInfBattle.Value = .TimeoutInfBattle

            If .AutoHuntSettings Is Nothing Then
                .AutoHuntSettings = New Dictionary(Of String, MonsterSettings)
            End If

            chkFastPixel.Checked = .EnableFastImageDetection

        End With
        UpdateMonsterSetting()

        Try
            Log("Initializing OCR Engine...")
            OCREngine = New Tesseract.TesseractEngine("tessdata", "eng", Tesseract.EngineMode.Default)
            Log("OCR Engine loaded! Using Tessaract Version: " & OCREngine.Version)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            End
        End Try

        Log("Computer Resolution: " & My.Computer.Screen.Bounds.Width & "x" & My.Computer.Screen.Bounds.Height & " (" & My.Computer.Screen.BitsPerPixel & "bpp)")
        If My.Computer.Screen.BitsPerPixel <> 32 Then
            MsgBox("Your computer is configured as " & My.Computer.Screen.BitsPerPixel & "bpp (bits per pixel). To BOT work properly, its must be configured as 32bpp!", MsgBoxStyle.Critical)
            End
        End If

        If Not InMainScreen(True) Then
            Log("Cant detect game, ensure the game is running before open the BOT or the BOT is properly configured!")
            Loading = False
            Me.Enabled = True
            Return
        End If


        If Not Debugger.IsAttached Then
            lblGameAccountName.Text = "Game Account: " & GetAccountName()
            Dim Gold As Long = GetGold()
            If Gold >= 0 Then
                StartGold = Gold
                CurrentGold = Gold
            Else
                CurrentGold = -1
                StartGold = -1
            End If

            BackToMainScreen()

            lblGold.Text = "Staring Gold: " & StartGold.ToString("#,##0")

            Try
                Dim UpdateFile As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "lohbot_update.rar")
                Dim UpdateScript As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "update.bat")
                If IO.File.Exists(UpdateFile) Then
                    IO.File.Delete(UpdateFile)
                End If
                If IO.File.Exists(UpdateScript) Then
                    IO.File.Delete(UpdateScript)
                End If
            Catch ex As Exception

            End Try
        End If

        Loading = False
        Me.Enabled = True
        tcBot.SelectedTab = tpMain

        ClosePopup()
    End Sub

    Sub DoResolutionCheck()
        Dim BSHWnd As IntPtr = GetBluestacksWindow()
        Dim RectAPI As User32.RECT
        User32.GetClientRect(BSHWnd, RectAPI)
        Dim Rect As Rectangle = Rectangle.FromLTRB(RectAPI.left, RectAPI.top, RectAPI.right, RectAPI.bottom)
        Dim BSVer As Version = GetBluestacksVersion()
        Log("Bluestacks version: " & BSVer.ToString)

        If Rect.Width <> 960 Or Rect.Height <> 600 Then
            MsgBox("Bluestacks dont have a valid resolution! Is using " & Rect.Width & "x" & Rect.Height & " but should be 960x600!", MsgBoxStyle.Critical)
            If MsgBox("Do you want fix resolution?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                MsgBox("Bot cant continue!", MsgBoxStyle.Critical)
                'End
            End If

            If SetBluestacksResolution() Then
                KillBluestacks()
                If Not StartBluestacks() Then
                    MsgBox("Cant restart Bluestacks!", MsgBoxStyle.Critical)
                    End
                End If

                BSHWnd = GetBluestacksWindow()
                User32.GetClientRect(BSHWnd, RectAPI)
                Rect = Rectangle.FromLTRB(RectAPI.left, RectAPI.top, RectAPI.right, RectAPI.bottom)
                If Rect.Width <> 960 Or Rect.Height <> 600 Then
                    MsgBox("Seems that my efforts to adjust the resolution had no effect. Sorry, try to fix it manually.", MsgBoxStyle.Critical)
                    'End
                Else
                    Log("Pefect! Bluestacks running with resolution 960x600... Ready to go!")
                End If
            Else
                MsgBox("Cant fix Bluestacks resolution!", MsgBoxStyle.Critical)
                'End
            End If
        Else
            Log("Bluestacks running with perfect resolution 960x600... Ready to go!")
        End If
    End Sub

    Private Sub lblVersion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblVersion.DoubleClick
        Using d As New DebugScreen
            d.ShowDialog()
        End Using
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        LastBOTAction = Stopwatch.StartNew

        tcBot.SelectedTab = tpLog
        StartBOT()
        btnStart.Enabled = False
        btnStop.Enabled = True
    End Sub

    Private Sub chkAutoTowerMonsterHunt_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoTowerMonsterHunt.CheckedChanged

        optTower.Enabled = chkAutoTowerMonsterHunt.Checked
        optMonsterHunt.Enabled = chkAutoTowerMonsterHunt.Checked
        gbMonsterHunt.Enabled = optMonsterHunt.Checked
        gbTower.Enabled = optTower.Checked

        If Loading Then Return
        CFG.AutoTowerHunt = chkAutoTowerMonsterHunt.Checked
        CFG.Save()
    End Sub

    Private Sub optTower_CheckedChanged(sender As Object, e As EventArgs) Handles optTower.CheckedChanged

        gbTower.Enabled = optTower.Checked

        If Loading Then Return
        CFG.AutoTower = optTower.Checked
        CFG.Save()
    End Sub

    Private Sub optMonsterHunt_CheckedChanged(sender As Object, e As EventArgs) Handles optMonsterHunt.CheckedChanged

        gbMonsterHunt.Enabled = optMonsterHunt.Checked

        If Loading Then Return
        CFG.AutoHunt = optMonsterHunt.Checked
        CFG.Save()

    End Sub

    Private Sub chkMineDeploy_CheckedChanged(sender As Object, e As EventArgs) Handles chkMineDeploy.CheckedChanged
        gbMineDeploy.Enabled = chkMineDeploy.Checked

        If Loading Then Return
        CFG.GuildMineDeploy = chkMineDeploy.Checked
        CFG.Save()
    End Sub

    Private Sub picDonate_Click(sender As Object, e As EventArgs)
        Try
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E2E3BUAYDY576")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FuseHireThread()
        Dim SW As Stopwatch

        Do
            Try
                LongLoopsDenny()

                'Hire
                If OpenHireWindow() Then
                    LastBOTAction = Stopwatch.StartNew

                    Dim TicketPos As Point = Hire_GetTicketPosition()
                    If Not TicketPos.IsEmpty Then
                        Dim X As Integer = 875
                        Dim Y As Integer = TicketPos.Y
                        GetEmulatorStatic.MouseLeftClick(X, Y)

                        'Multiple hire process
                        Do
                            LastBOTAction = Stopwatch.StartNew

                            SW = Stopwatch.StartNew
                            Do
                                If InUseTicketWindow() Then Exit Do
                                If SW.Elapsed.TotalSeconds > 2 Then Exit Do
                            Loop

                            If InUseTicketWindow() Then
                                BOTRes.ClickElement("USE_TICKET_WINDOW_USE_BUTTON")
                                Threading.Thread.Sleep(3000)
                                If InUseTicketWindow() Then
                                    GetEmulatorStatic.MouseLeftClick(564, 369)
                                End If

                                SW = Stopwatch.StartNew
                                Do
                                    If InUseTicketResultWindow() Then Exit Do
                                    If SW.Elapsed.TotalSeconds > 15 Then Exit Do
                                Loop
                                If InUseTicketResultWindow() Then
                                    Do While InUseTicketResultWindow()
                                        GetEmulatorStatic.MouseLeftClick(5, 5)
                                        Threading.Thread.Sleep(500)
                                    Loop
                                End If

                                If InHireWindow() Then Exit Do
                            End If

                            LongLoopsDenny()
                            If InHireWindow() Then Exit Do
                            If Not InHireWindow() AndAlso Not InUseTicketWindow() AndAlso Not InUseTicketResultWindow() Then
                                GetEmulatorStatic.MouseLeftClick(5, 5)
                            End If
                            If InUseTicketResultWindow() Then
                                GetEmulatorStatic.MouseLeftClick(5, 5)
                            End If
                        Loop

                    Else
                        Exit Do
                    End If
                End If

                'Fuse heroes
                BackToMainScreen()
                If OpenFuseWindow() Then
                    LastBOTAction = Stopwatch.StartNew

                    Do
                        LastBOTAction = Stopwatch.StartNew

                        'Click Suggest
                        BOTRes.ClickElement("FUSE_SUGGEST_BUTTON")
                        SW = Stopwatch.StartNew
                        Do
                            If Not Fuse_SuggestEmpty() Then Exit Do
                            If SW.Elapsed.TotalSeconds > 5 Then Exit Do
                        Loop
                        If Fuse_SuggestEmpty() Then Exit Do

                        BOTRes.ClickElement("FUSE_FUSE_BUTTON")
                        SW = Stopwatch.StartNew
                        Do
                            If InFuseConfirmWindow() Then Exit Do
                            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                        Loop

                        If Not InFuseConfirmWindow() Then Exit Do

                        BOTRes.ClickElement("FUSE_FUSE_CONFIRM_BUTTON")
                        Threading.Thread.Sleep(500)

                        Do While InFuseConfirmWindow()
                            BOTRes.ClickElement("FUSE_FUSE_CONFIRM_BUTTON")
                        Loop

                        If Not BOTRes.DetecWaitAndClick("FUSE_RESULT", 30) Then Exit Do
                        Threading.Thread.Sleep(1000)
                        If Not InFuseWindow() Then
                            If Not BOTRes.DetecAndClick("FUSE_RESULT") Then Exit Do
                        End If

                        SW = Stopwatch.StartNew
                        Do
                            If InFuseWindow() Then Exit Do
                            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                        Loop
                        If Not InFuseWindow() Then Exit Do
                    Loop
                    BackToMainScreen()
                End If
            Catch thex As Threading.ThreadAbortException
                Exit Do
            Catch ex As Exception
                Exit Do
            End Try
        Loop
    End Sub

    Private Sub btnFuseHire_Click(sender As Object, e As EventArgs) Handles btnFuseHire.Click
        If IsRunning Then
            MsgBox("Cant use this function while BOT is running!", MsgBoxStyle.Critical)
            Return
        End If

        If MsgBox("BOT will hire (Silver, Gold and Plat tickets of any season) and fuse them all using Suggest button. Do you want continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        LastBOTAction = Stopwatch.StartNew

        THFuse = New Threading.Thread(AddressOf FuseHireThread)
        THFuse.Start()

        Do While Not THFuse.IsAlive
            Threading.Thread.Sleep(500)
        Loop
        btnFuseHire.Enabled = False
        btnAbortHireFuse.Enabled = True
        btnAbortHireFuse.Visible = True
        lblAdvancedHireFuse.Enabled = False

        Do While THFuse.IsAlive
            Application.DoEvents()
            Threading.Thread.Sleep(500)
        Loop

        btnAbortHireFuse.Visible = False
        btnFuseHire.Enabled = True
        lblAdvancedHireFuse.Enabled = True

        MsgBox("Finished Hire and Fuse!", MsgBoxStyle.Information)
    End Sub

    Function Hire_GetTicketPosition() As Point
        Dim Ret As Point = Point.Empty
        Dim rect As Rectangle = Rectangle.Empty

        rect = BOTRes.DetectPosition("GOLDEN_TICKET")
        If rect.IsEmpty Then
            rect = BOTRes.DetectPosition("SILVER_TICKET")
        End If
        If rect.IsEmpty Then
            rect = BOTRes.DetectPosition("PLATINUM_TICKET")
        End If

        If Not rect.IsEmpty Then
            Ret = New Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2))
        End If

        Return Ret
    End Function

    Function Fuse_SuggestEmpty() As Boolean
        Return BOTRes.DetectColor("FUSE_SUGGEST_EMPTY")
    End Function

    Function InFuseConfirmWindow() As Boolean
        Return BOTRes.Detect("FUSE_CONFIRM")
    End Function

    Function InFuseResultWindow() As Boolean
        Return BOTRes.Detect("FUSE_RESULT")
    End Function

    Private ReadOnly Property IsRunning As Boolean
        Get
            If THBot Is Nothing Then Return False
            Return THBot.IsAlive
        End Get
    End Property

    Private Sub StartBOT()
        If IsRunning Then
            StopBOT()
        End If
        THBot = New Threading.Thread(AddressOf BOTThread)
        THBot.Start()
    End Sub
    Private Sub StopBOT()
        Try
            If IsRunning Then
                Log("Stopping BOT...")
                THBot.Abort()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BOTThread()
        BOTStartTime = Now
        NumFights = 0
        GoldEarnList.Clear()
        ExpEarnList.Clear()

        Log("Starting BOT...")
        Dim SWMine As Stopwatch = Nothing
        Do
            Try
                LongLoopsDenny()
                If InMainScreen(True) Then
                    DoAutoBuyRuneEssence()
                    DoInfiniteBattle()
                    SendMineTroops()
                    AutoSell()
                    ClaimHeartFragments()
                    ClaimMine()
                    ProcessManualAttack()

                    If CFG.AutoTowerHunt Then
                        If CFG.AutoTower Then
                            If CFG.AutoTowerHard_ClimbMode Then
                                DoAutoTower_ClimbMode()
                            Else
                                DoAutoTower()
                            End If
                        End If
                        If CFG.AutoHunt Then
                            DoAutoHunt()
                        End If
                    End If
                End If
            Catch ex As Threading.ThreadAbortException
                Log("...BOT Stoped")
                Exit Do
            Catch ex As Exception

            End Try
        Loop
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        LastBOTAction = Stopwatch.StartNew

        StopBOT()
        btnStop.Enabled = False
        btnStart.Enabled = True
    End Sub

    Private Sub btnAdvancedMonsterHuntSetup_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBasicMonsterHuntSetup_Click(sender As Object, e As EventArgs) Handles btnBasicMonsterHuntSetup.Click
        Using f As New MonsterSetup
            f.CurrentSettings = New MonsterSettings
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                UpdateMonsterSetting()
            End If
        End Using
    End Sub

    Private Sub btmBotSetup_Click(sender As Object, e As EventArgs) Handles btmBotSetup.Click
        If IsRunning Then
            MsgBox("Cant use this function while BOT is running!", MsgBoxStyle.Critical)
            Return
        End If

        Using s As New BOTSetup
            s.ShowDialog()
        End Using
    End Sub

    Private Sub chkQuickBattle_CheckedChanged(sender As Object, e As EventArgs) Handles chkQuickBattle.CheckedChanged
        If Loading Then Return

        CFG.AutoTower_QuickBattle = chkQuickBattle.Checked
        CFG.Save()
    End Sub

    Private Sub cboMonsterSetup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonsterSetup.SelectedIndexChanged
        If Loading Then Return
        If cboMonsterSetup.SelectedIndex = -1 Then Return

        CFG.AutoHuntSelected = cboMonsterSetup.SelectedItem
        CFG.Save()
    End Sub

    Private Sub chkInfiniteBattle_CheckedChanged(sender As Object, e As EventArgs) Handles chkInfiniteBattle.CheckedChanged
        If Loading Then Return

        CFG.InfiniteBattle = chkInfiniteBattle.Checked
        CFG.Save()
    End Sub

    Private Sub chkColiBattle_CheckedChanged(sender As Object, e As EventArgs) Handles chkColiBattle.CheckedChanged
        If Loading Then Return

        CFG.ColiBattle = chkColiBattle.Checked
        CFG.Save()
    End Sub

    Private Sub udMaxTroopsMine_ValueChanged(sender As Object, e As EventArgs) Handles udMaxTroopsMine.ValueChanged
        If Loading Then Return

        CFG.GuildMineDeploy_MaxTroops = udMaxTroopsMine.Value
        CFG.Save()
    End Sub

    Private Sub chkGoldMine_CheckedChanged(sender As Object, e As EventArgs) Handles chkGoldMine.CheckedChanged
        lblMinGoldMine.Enabled = chkGoldMine.Checked
        udMinGoldMine.Enabled = chkGoldMine.Checked

        If Loading Then Return

        CFG.GuildMineDeploy_Gold = chkGoldMine.Checked
        CFG.Save()
    End Sub

    Private Sub chkRuneMine_CheckedChanged(sender As Object, e As EventArgs) Handles chkRuneMine.CheckedChanged
        lblMinRuneMine.Enabled = chkRuneMine.Checked
        udMinRuneMine.Enabled = chkRuneMine.Checked

        If Loading Then Return

        CFG.GuildMineDeploy_Rune = chkRuneMine.Checked
        CFG.Save()
    End Sub

    Private Sub udMinGoldMine_ValueChanged(sender As Object, e As EventArgs) Handles udMinGoldMine.ValueChanged
        If Loading Then Return

        CFG.GuildMineDeploy_GoldMin = udMinGoldMine.Value
        CFG.Save()
    End Sub

    Private Sub udMinRuneMine_ValueChanged(sender As Object, e As EventArgs) Handles udMinRuneMine.ValueChanged
        If Loading Then Return

        CFG.GuildMineDeploy_RuneMin = udMinRuneMine.Value
        CFG.Save()
    End Sub

    Private Sub chkAutoSell_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoSell.CheckedChanged
        gbAutoSell.Enabled = chkAutoSell.Checked
        If Loading Then Return

        CFG.AutoSell = chkAutoSell.Checked
        CFG.Save()
    End Sub

    Private Sub chkAutoMineClaim_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoMineClaim.CheckedChanged
        If Loading Then Return

        CFG.AutoMineClaim = chkAutoMineClaim.Checked
        CFG.Save()
    End Sub

    Private Sub chkAutoReadMessage_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoReadMessage.CheckedChanged
        If Loading Then Return

        CFG.AutoReadMessage = chkAutoReadMessage.Checked
        CFG.Save()
    End Sub

    Private Sub chkAutoFodderSwap_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoFodderSwap.CheckedChanged
        lblFodderPosition.Enabled = chkAutoFodderSwap.Checked
        cboFodderPosition.Enabled = chkAutoFodderSwap.Checked
        chkFodderEquip.Enabled = chkAutoFodderSwap.Checked

        If Loading Then Return

        CFG.FodderSwap = chkAutoFodderSwap.Checked
        CFG.Save()
    End Sub

    Private Sub chkFodderEquip_CheckedChanged(sender As Object, e As EventArgs) Handles chkFodderEquip.CheckedChanged
        If Loading Then Return

        CFG.FodderSwapGear = chkFodderEquip.Checked
        CFG.Save()
    End Sub

    Private Sub cboFodderPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFodderPosition.SelectedIndexChanged
        If Loading Then Return
        If cboFodderPosition.SelectedIndex = -1 Then Return

        CFG.FodderSwapPosition = cboFodderPosition.Text
        CFG.Save()
    End Sub

    Private Sub udGameFreeze_ValueChanged(sender As Object, e As EventArgs) Handles udGameFreeze.ValueChanged
        If Loading Then Return

        CFG.TimeoutFreeze = udGameFreeze.Value
        CFG.Save()
    End Sub

    Private Sub udAutoSell_ValueChanged(sender As Object, e As EventArgs) Handles udAutoSell.ValueChanged
        If Loading Then Return

        CFG.TimeoutSell = udAutoSell.Value
        CFG.Save()
    End Sub

    Private Sub udAutoColi_ValueChanged(sender As Object, e As EventArgs) Handles udAutoColi.ValueChanged
        If Loading Then Return

        CFG.TimeoutColi = udAutoColi.Value
        CFG.Save()
    End Sub

    Private Sub udInfBattle_ValueChanged(sender As Object, e As EventArgs) Handles udInfBattle.ValueChanged
        If Loading Then Return

        CFG.TimeoutInfBattle = udInfBattle.Value
        CFG.Save()
    End Sub

    Sub UpdateMonsterSetting()
        Dim mName As String = ""
        If cboMonsterSetup.SelectedIndex <> -1 Then
            mName = cboMonsterSetup.Text
        Else
            If Not CFG.AutoHuntSelected Is Nothing Then
                mName = CFG.AutoHuntSelected.Name
            End If
        End If

        cboMonsterSetup.Items.Clear()
        For Each s As String In CFG.AutoHuntSettings.Keys
            cboMonsterSetup.Items.Add(CFG.AutoHuntSettings(s))
        Next

        If mName <> "" Then
            cboMonsterSetup.SelectedIndex = cboMonsterSetup.FindStringExact(mName)
        End If
    End Sub

    Private Sub btnEditMonsterSetup_Click(sender As Object, e As EventArgs) Handles btnEditMonsterSetup.Click
        If cboMonsterSetup.SelectedIndex = -1 Then
            MsgBox("Select an monster setup before edit!", MsgBoxStyle.Critical)
            Return
        End If

        Using f As New MonsterSetup
            f.CurrentSettings = cboMonsterSetup.SelectedItem
            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                UpdateMonsterSetting()
            End If
        End Using
    End Sub

    Private Sub btnAwaken_Click(sender As Object, e As EventArgs) Handles btnAwaken.Click
        If IsRunning Then
            MsgBox("Cant use this function while BOT is running!", MsgBoxStyle.Critical)
            Return
        End If

        Using f As New AutoAwaken
            f.ShowDialog()
        End Using
    End Sub

    Private Sub chkFastPixel_CheckedChanged(sender As Object, e As EventArgs) Handles chkFastPixel.CheckedChanged
        If Loading Then Return
        CFG.EnableFastImageDetection = chkFastPixel.Checked
        CFG.Save()
    End Sub

    Private Sub btnAbortHireFuse_Click(sender As Object, e As EventArgs) Handles btnAbortHireFuse.Click
        Try
            THFuse.Abort()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkCoop_CheckedChanged(sender As Object, e As EventArgs) Handles chkCoop.CheckedChanged
        If Loading Then Return
        btnCoopConfig.Enabled = chkCoop.Checked
        CFG.AutoTower_Coop = chkCoop.Checked
        CFG.Save()
    End Sub

    Private Sub btnCoopConfig_Click(sender As Object, e As EventArgs) Handles btnCoopConfig.Click
        Using coop_cfg As New CoopSetup
            coop_cfg.ShowDialog()
        End Using
    End Sub

    Private Sub optSellEverything_CheckedChanged(sender As Object, e As EventArgs) Handles optSellEverything.CheckedChanged
        If Loading Then Return
        CFG.AutoSellEverything = optSellEverything.Checked
        CFG.Save()
    End Sub

    Private Sub optSellFilter_CheckedChanged(sender As Object, e As EventArgs) Handles optSellFilter.CheckedChanged
        lblSellFilter.Enabled = optSellFilter.Checked
        txtSellFilter.Enabled = optSellFilter.Checked

        If Loading Then Return
        CFG.AutoSellFilter = optSellFilter.Checked
        CFG.Save()
    End Sub

    Private Sub txtSellFilter_LostFocus(sender As Object, e As EventArgs) Handles txtSellFilter.LostFocus
        If Loading Then Return
        CFG.AutoSellFilterItems = txtSellFilter.Text
        CFG.Save()
    End Sub

    Private Sub chkAutoBuyRunePowder_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoBuyRuneEssence.CheckedChanged
        If Loading Then Return
        CFG.AutoBuyRuneEssence = chkAutoBuyRuneEssence.Checked
        CFG.Save()
    End Sub

    Private Sub optRegularTower_CheckedChanged(sender As Object, e As EventArgs) Handles optRegularTower.CheckedChanged
        If Loading Then Return
        CFG.AutoTowerRegular = optRegularTower.Checked
        CFG.Save()
    End Sub

    Private Sub optHardTower_CheckedChanged(sender As Object, e As EventArgs) Handles optHardTower.CheckedChanged
        If Loading Then Return
        CFG.AutoTowerHard = optHardTower.Checked
        CFG.Save()
    End Sub

    Private Sub llPage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPage.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub llForum_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llForum.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("http://www.thebotbay.com/blogs/")
    End Sub

    Private Sub chkTowerClimb_CheckedChanged(sender As Object, e As EventArgs) Handles chkTowerClimb.CheckedChanged
        If Loading Then Return
        CFG.AutoTowerHard_ClimbMode = chkTowerClimb.Checked
        CFG.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DoAutoTower_ClimbMode()
    End Sub

    Private Sub lblAdvancedHireFuse_Click(sender As Object, e As EventArgs) Handles lblAdvancedHireFuse.Click
        If IsRunning Then
            MsgBox("Cant use this function while BOT is running!", MsgBoxStyle.Critical)
            Return
        End If

        With New AdvancedHireFuse
            .ShowDialog()
        End With
    End Sub
End Class
