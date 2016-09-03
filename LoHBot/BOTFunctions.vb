Imports System.Security
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports Newtonsoft.Json


'floor type 1 (inicio impar: ex 1 a 5)


'floor type 1 (inicio par: ex 16 a 20)
'1 = 671,346
'2 = 411,304
'3 = 259,188
'4 = 431,97
'5 = 655,112


'Sub floor
'1 = 415,367
'2 = 281,278
'3 = 627,207
'4 = 464,154
'5 = 286,112

Module BOTFunctions
    Public MAINSCREEN_MODE As String = ""
    Public BotWnd As frmMain
    Public EmulatorVersion As Version
    Public CFG As BOTSettings
    Public AccountName As String
    Public OCREngine As Tesseract.TesseractEngine
    Public StartGold As Long = 0
    Public CurrentGold As Long = 0
    Public NumFights As Long = 0
    Public LastBOTAction As Stopwatch = Stopwatch.StartNew

    Public AbortMine As Boolean = False

    Public UsedElixirs As Integer = 0

    Public ExpEarned As Long = 0
    Public SWRunningTime As Stopwatch = Nothing

    Public SWLastRuneEssenceBuy As Stopwatch = Nothing
    Public SWLastSell As Stopwatch = Nothing
    Public SWLastAction As Stopwatch = Nothing
    Public SWLastColi As Stopwatch = Nothing
    Public SWLastInfBattle As Stopwatch = Nothing
    Public BOTStartTime As Date = Date.MinValue
    Public NextSendMines As Date = Now
    Public StaticEmulator As Emulator

    Public Delegate Sub DelLog(Msg As String)

    Public GoldEarnList As New Dictionary(Of Date, Long)
    Public ExpEarnList As New Dictionary(Of Date, Long)

    Public ResourcesPath As String

    Public BOTRes As New BOTResources

    Public Function GetEmulator() As Emulator
        Return StaticEmulator.Clone()
    End Function
    Public Function GetEmulatorStatic() As Emulator
        Return StaticEmulator
    End Function

    Public Function IsAdmin() As Boolean
        Return (New Security.Principal.WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Sub Log(ByVal Msg As String)
        If BotWnd.InvokeRequired Then
            BotWnd.BeginInvoke(New DelLog(AddressOf Log), Msg)
        Else
            Dim MsgFinal As String = Now.ToString("HH:mm:ss") & " - " & Msg
            BotWnd.txtLog.AppendText(MsgFinal & Environment.NewLine)
            BotWnd.txtLog.SelectionStart = BotWnd.txtLog.Text.Length
            BotWnd.txtLog.SelectionLength = 0
            BotWnd.txtLog.ScrollToCaret()
            Application.DoEvents()
        End If
    End Sub

    Function StartBluestacks() As Boolean
        Dim BSPath As String = ""
        Dim BSBin As String = ""

        Try
            Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\")
                BSPath = K.GetValue("DataDir", "")
                BSBin = K.GetValue("InstallDir", "")
            End Using
        Catch ex As Exception
            Return False
        End Try

        Try
            BSPath = IO.Path.Combine(BSPath, "UserData\Library\My Apps\Legion of Heroes.lnk")
            BSBin = IO.Path.Combine(BSBin, "HD-RunApp.exe")
            If IO.File.Exists(BSPath) Then
                Log("LoH link found installed at [" & BSPath & "]")
                Log("Starting Bluestacks with LoH")
                Dim p As Process = Process.Start(BSPath)

                Dim SW As Stopwatch = Stopwatch.StartNew
                Do While GetBluestacksWindow() = 0
                    Threading.Thread.Sleep(1000)
                    If SW.Elapsed.TotalSeconds > 5 Then Return False
                Loop

                Return Not (GetBluestacksWindow() = 0)
            Else
                Log("Trying to start Bluestacks with LoH")

                Dim p As Process = Process.Start(BSBin, "-p com.nexonm.loh.usios -a com.nexonm.loh.usios.AndroidAPI")

                Dim SW As Stopwatch = Stopwatch.StartNew
                Do While GetBluestacksWindow() = 0
                    Threading.Thread.Sleep(1000)
                    If SW.Elapsed.TotalSeconds > 5 Then Return False
                Loop

                Return Not (GetBluestacksWindow() = 0)
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetBluestacksWindow() As IntPtr
        Return User32.FindWindowByCaption(0, "BlueStacks App Player")


        'Dim Ret As IntPtr = 0

        'Dim Proc() As Process = Process.GetProcessesByName("HD-Frontend")
        'If Proc.Length <> 0 Then
        '    Ret = Proc(0).MainWindowHandle
        '    EmuWnd = Ret
        'End If

        'Return Ret
    End Function

    Public Function GetBluestacksVersion() As Version
        Dim Ret As New Version(0, 0, 0, 0)

        Try
            Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\")
                Dim Major As Integer = K.GetValue("VersionMajor", 0)
                Dim Minor As Integer = K.GetValue("VersionMinor", 0)
                Dim Patch As Integer = K.GetValue("VersionPatch", 0)
                Dim Build As Integer = K.GetValue("VersionBuild", 0)

                Ret = New Version(Major, Minor, Patch, Build)
            End Using
        Catch ex As Exception
        End Try

        EmulatorVersion = Ret
        Return Ret
    End Function

    Public Function SetBluestacksResolution() As Boolean
        Try
            Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\Guests\Android\FrameBuffer\0\", True)
                K.SetValue("WindowWidth", 960, Microsoft.Win32.RegistryValueKind.DWord)
                K.SetValue("GuestWidth", 960, Microsoft.Win32.RegistryValueKind.DWord)

                K.SetValue("WindowHeight", 600, Microsoft.Win32.RegistryValueKind.DWord)
                K.SetValue("GuestHeight", 600, Microsoft.Win32.RegistryValueKind.DWord)
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub KillBluestacks()
        KillProcessbyName("HD-Agent")
        KillProcessbyName("HD-BlockDevice")
        KillProcessbyName("HD-FrontEnd")
        KillProcessbyName("HD-Network")
        KillProcessbyName("HD-Service")
        KillProcessbyName("HD-SharedFolder")
        KillProcessbyName("HD-UpdaterService")
        KillProcessbyName("HD-LogRotatorService")
    End Sub
    Public Sub KillProcessbyName(ByVal ProcName As String)
        On Error Resume Next
        Dim Proc() As Process = Process.GetProcessesByName(ProcName)
        For Each p As Process In Proc
            p.Kill()
        Next
    End Sub

    Function OpenInventory() As Boolean
        If InInventory() Then Return True
        If Not InMainScreen(True) Then Return False

        If MAINSCREEN_MODE = "LEGACY" Then
            BOTRes.ClickElement("TOOLBAR_INVENTORY")
        Else
            BOTRes.ClickElement("INVENTORY_LOBBY")
        End If

        Return BOTRes.DetectWait("INVENTORY", 10)
    End Function

    Function InBattle() As Boolean
        Return BOTRes.Detect("BATTLE")
    End Function

    Function OpenInfiniteBattle() As Boolean
        If Not OpenBattle() Then Return False
        BOTRes.ClickElement("BATTLE_INFINITE")
        Return BOTRes.DetectWait("INF_BATTLE_WINDOW", 10)
    End Function

    Function OpenBattle() As Boolean
        If InBattle() Then Return True
        If Not InMainScreen(True) Then Return False

        BOTRes.ClickElement("TOOLBAR_BATTLE")
        Return BOTRes.DetectWait("BATTLE", 10)
    End Function

    Function OpenAdventure() As Boolean
        If InAdventure() Then Return True
        If Not InMainScreen(True) Then Return False

        BOTRes.ClickElement("TOOLBAR_ADVENTURE")
        Return BOTRes.DetectWait("ADVENTURE", 10)
    End Function


    Function OpenTower() As Boolean
        If InPreTower() Then Return True

        If InMainScreen() Then
            If MAINSCREEN_MODE = "LOBBY" Then
                BOTRes.ClickElement("TOWER_LOBBY")
            Else
                If Not OpenAdventure() Then Return False
                If Not InAdventure() Then Return False

                BOTRes.ClickElement("ADVENTURE_TOWER")
            End If
        Else
            Return False
        End If

        Log("Waiting for Tower screen...")
        If Not BOTRes.DetectWait("ADVENTURE_TOWER", 30) Then
            Log("Cant detect tower screen")
            Return False
        End If
        Log("...Tower screen found")

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If CFG.AutoTowerHard Then
                Log("Trying to open hard tower...")
                BOTRes.ClickElement("ADVENTURE_TOWER_HARD")
            ElseIf CFG.AutoTowerRegular Then
                Log("Trying to open normal tower...")
                BOTRes.ClickElement("ADVENTURE_TOWER_NORMAL")
            End If

            If SW.Elapsed.TotalSeconds > 30 Then
                Log("Cant enter tower, sorry...")
                Return False
            End If

            Threading.Thread.Sleep(1000)

            If Not BOTRes.Detect("ADVENTURE_TOWER") Then Exit Do
        Loop

        Dim Ret As Boolean = BOTRes.DetectWait("TOWER", 30)
        If Not Ret Then
            Log("Something went wrong with tower detection...")
        Else
            Log("Tower detected!")
        End If

        Return Ret
    End Function

    Function InMainScreen(Optional ByVal ForceBackToMainScreen As Boolean = False) As Boolean
        Dim Ret As Boolean = False
        If ForceBackToMainScreen Then
            If Not InMainScreen(False) Then
                BackToMainScreen()
            End If
        End If

        Dim RectInv As Rectangle = BOTRes.DetectPosition("TOOLBAR_INVENTORY")
        If BOTRes.Detect("WORLD_LOBBY_BUTTON") AndAlso Not RectInv.IsEmpty Then
            Ret = True
            If RectInv.Left > 700 Then
                If ForceBackToMainScreen Then Log("In main screen, parked at old legacy world scene")
                MAINSCREEN_MODE = "LEGACY"
            Else
                If ForceBackToMainScreen Then Log("In main screen, parked at new lobby window...")
                MAINSCREEN_MODE = "LOBBY"
            End If
        Else
            If BOTRes.Detect("CHRONO_STORE_BUTTON") Then
                Ret = True
                If ForceBackToMainScreen Then Log("In main screen, parked at guild hideout")
                MAINSCREEN_MODE = "LEGACY"
            End If
        End If

        Return Ret
    End Function

    Sub EnsureToolbarVisible()
        If Not BOTRes.Detect("TOOLBAR_VISIBLE") Then
            BOTRes.ClickElement("TOOLBAR_VISIBLE")
        End If
    End Sub

    Function InInventory() As Boolean
        Return BOTRes.Detect("INVENTORY")
    End Function

    Function InPreTower() As Boolean
        Return BOTRes.Detect("TOWER")
    End Function

    Function InTowerRepeatWindow() As Boolean
        Return BOTRes.DetectWait("TOWER_REPEAT", 10)
    End Function

    Function InTowerAutoSell() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(283, 61))
        Colors.Add(Color.FromArgb(57, 15, 15))

        Coords.Add(New Point(440, 457))
        Colors.Add(Color.FromArgb(126, 53, 21))

        Coords.Add(New Point(466, 463))
        Colors.Add(Color.FromArgb(255, 255, 255))
        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function IsTowerRepeatFinish() As Boolean
        Return BOTRes.Detect("TOWER_AUTO_FINISH")
    End Function

    Function InAdventure() As Boolean
        Return BOTRes.Detect("ADVENTURE")
    End Function

    Function HaveHeartFragFromFriends() As Boolean
        Dim Ret As Boolean = BOTRes.Detect("FRIENDS_HAVEFRAGMENT")
        If Not Ret Then
            Ret = BOTRes.Detect("FRIENDS_HAVEFRAGMENT_LOBBY")
        End If
        Return Ret
    End Function

    Function OpenGuildScreen() As Boolean
        If InGuildScreen() Then Return True
        If Not InMainScreen(True) Then Return False

        BOTRes.ClickElement("TOOLBAR_GUILD")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InGuildScreen() Then Exit Do
        Loop

        Return InGuildScreen()
    End Function
    Function InGuildScreen() As Boolean
        Return BOTRes.Detect("GUILD")
    End Function

    Function OpenMineScreen() As Boolean
        If InMineScreen() Then Return True
        If Not OpenGuildScreen() Then Return False

        BOTRes.ClickElement("GUILD_MINE")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InMineScreen() Then Exit Do
        Loop

        Return InMineScreen()
    End Function

    Function InMineScreen() As Boolean
        Return BOTRes.Detect("MINE")
    End Function

    Function InFriendScreen() As Boolean
        Return BOTRes.Detect("FRIENDS")
    End Function

    Sub DoAutoHunt()
        If Not InMainScreen(True) Then Return

        If CFG.AutoHuntSelected Is Nothing Then
            Log("ERROR: Auto Hunt settings not selected!")
        End If

        Dim MHunt As New MonsterHunt
        MHunt.Filter = CFG.AutoHuntSelected.Settings


        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            Log("Searching for monsters...")
            LongLoopsDenny()
            MHunt.Update()

            Dim Targets As List(Of Rectangle) = MHunt.GetTargets
            If Targets.Count > 0 Then
                Dim Idx As Integer = BitmapTools.RandomRange(0, Targets.Count - 1)
                If Idx > (Targets.Count - 1) Then
                    Idx = 0
                End If

                Dim Hit As Point = BitmapTools.GetCentroid(Targets(Idx))

                Log("Found [" & Targets.Count & "] possible targets")
                Log("Trying hit target at [" & Hit.ToString & "]")

                GetEmulatorStatic.MouseLeftClick(Hit)
                Dim SWWait As Stopwatch = Stopwatch.StartNew
                Do
                    If SWWait.Elapsed.TotalSeconds > 5 Then Exit Do
                    If Not InMainScreen() Then Exit Do
                Loop

                If InMainScreen(True) Then
                    Log("Monster is false positive, searching again...")
                    LookAround()
                    'Rotate screen
                    Dim SWRefresh As Stopwatch = Stopwatch.StartNew
                    Do
                        MHunt.Update()
                        If SWRefresh.Elapsed.TotalSeconds > 2 Then Exit Do
                    Loop
                Else
                    Log("Waiting for battle start...")
                    If BOTRes.DetectWait("IN_BATTLE", 60) Then
                        Log("...Battle started")
                        ProcessManualAttack()

                        If SWLastSell Is Nothing Then
                            Return
                        Else
                            If SWLastSell.Elapsed.TotalMinutes >= CFG.TimeoutSell Then
                                Return
                            End If
                        End If

                        Continue Do
                    Else
                        Log("Something was wrong with game, cant detect battle start...")
                    End If
                End If
            Else
                Log("No monsters found, searching again...")
                LookAround()
                'Rotate screen
                Dim SWRefresh As Stopwatch = Stopwatch.StartNew
                Do
                    MHunt.Update()
                    If SWRefresh.Elapsed.TotalSeconds > 2 Then Exit Do
                Loop
                If Not InMainScreen(True) Then Return

            End If

            ProcessManualAttack()
            'If SW.Elapsed.TotalMinutes > 5 Then
            '    Return
            'End If

            If SWLastSell Is Nothing Then
                Return
            Else
                If SWLastSell.Elapsed.TotalMinutes >= CFG.TimeoutSell Then
                    Return
                End If
            End If

        Loop
    End Sub

    Sub LookAround()
        GetEmulatorStatic.MouseLeftDrag(0, 305, 200, 305)
    End Sub

    Sub ProcessManualAttack()
        Dim GetHelp As Boolean = False

        If Not BOTRes.Detect("IN_BATTLE") Then Return

        Log("Attacking monsters!")
        Do
            If BOTRes.Detect("IN_BATTLE") Then
                If BOTRes.Detect("BATTLE_AUTO_OFF", 0.95) Then
                    Log("Auto attack is off, turning on")
                    BOTRes.DetecAndClick("BATTLE_AUTO_OFF", 0.95)
                End If
            End If

            If Not GetHelp Then
                GetHelp = AutoHunt_GetHelp()
            End If

            Threading.Thread.Sleep(1000)
            ProcessCardPickup()
            Threading.Thread.Sleep(1000)
            ProcessEndBattle()
            Threading.Thread.Sleep(1000)
            LongLoopsDenny()

            If InMainScreen() Then Exit Do
        Loop
    End Sub

    Function ProcessCardPickup() As Boolean
        If Not BOTRes.Detect("BONUS_REWARD_CARDS") Then Return False

        Log("Bonus reward! Picking then 4th card")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            BOTRes.ClickElement("BONUS_REWARD_PICKUP")
            Threading.Thread.Sleep(1000)
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If Not BOTRes.Detect("BONUS_REWARD_CARDS") Then Exit Do
        Loop

        Return Not BOTRes.Detect("BONUS_REWARD_CARDS")
    End Function

    Function ProcessEndBattle() As Boolean
        Dim Exp As Long = 0

        If IsVictory(Exp) Then
            If Exp <> -1 Then
                LastBOTAction = Stopwatch.StartNew
                NumFights += 1
                Log("Victory! Exp earned = " & Exp)
                ExpEarned += Exp
                Exp = 0

                If BOTRes.DetecWaitAndClick("END_BATTLE_EXIT", 30) Then
                    BackToMainScreen()
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else

            If IsDefeat(Exp) Then
                If Exp <> -1 Then
                    LastBOTAction = Stopwatch.StartNew
                    NumFights += 1
                    Log("Defeat! Exp earned = " & Exp)
                    ExpEarned += Exp
                    Exp = 0

                    If BOTRes.DetecWaitAndClick("END_BATTLE_EXIT", 30) Then
                        BackToMainScreen()
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If

        End If

        Return False
    End Function

    Sub DoAutoTower()
        If CFG.AutoTower_Coop Then
            If CFG.AutoTower_CoopPassive Then Return
            If CFG.AutoTower_CoopActive Then
                'Invite players
                Return
            End If
        End If

        BackToMainScreen()

        If Not OpenTower() Then Return

        Log("Starting new auto tower session...")

        BOTRes.ClickElement("TOWER_REPEAT")
        If Not InTowerRepeatWindow() Then Return
        Threading.Thread.Sleep(1000)

        If CFG.AutoTower_QuickBattle Then
            Log("Using quick battle coupons")
            BOTRes.ClickElement("TOWER_REPEAT_QUICKBATTLE")
            Threading.Thread.Sleep(1000)
            BOTRes.ClickElement("TOWER_REPEAT_OK")
            Threading.Thread.Sleep(1000)
            BOTRes.ClickElement("TOWER_REPEAT_AUTOSELL_SAVE")
        Else
            BOTRes.ClickElement("TOWER_REPEAT_OK")
        End If

        If BOTRes.DetectWait("IN_BATTLE", 60) Then
            Log("Battle started!")
        Else
            Log("Battle failed to start... Game may be bugged or your internet connection is weak")
            Return
        End If

        Dim LastExpRead As Stopwatch = Stopwatch.StartNew
        Dim Exp As Long = 0
        Do
            If IsTowerRepeatFinish() Then Exit Do
            Threading.Thread.Sleep(100)
            LongLoopsDenny()

            If LastExpRead.Elapsed.TotalSeconds > 30 Then
                If IsVictory(Exp) Then
                    LastBOTAction = Stopwatch.StartNew
                    If Exp <> -1 Then
                        NumFights += 1
                        Log("Victory! Exp earned = " & Exp)
                        ExpEarned += Exp
                        Exp = 0
                        LastExpRead = Stopwatch.StartNew
                        Threading.Thread.Sleep(5000)
                    End If
                End If
            End If
            If InMainScreen() Then Return
            Threading.Thread.Sleep(250)
        Loop

        Threading.Thread.Sleep(1000)

        'Click ok for repeat battle result
        BOTRes.ClickElement("TOWER_AUTO_FINISH_OK")
        Log("Auto tower session finished...")

        BackToMainScreen()
        Dim Gold As Long = GetGold()
        If Gold >= 0 Then
            If StartGold = -1 Then
                StartGold = Gold
            End If
            CurrentGold = Gold

            Log("Gold earned since BOT start = " & (CurrentGold - StartGold))
            Log("Exp earned since BOT start = " & ExpEarned)
        End If
        BackToMainScreen()

    End Sub

    Sub ClaimHeartFragments()
        If Not InMainScreen(True) Then Return
        If Not HaveHeartFragFromFriends() Then Return

        'Open friends windows

        If MAINSCREEN_MODE = "LEGACY" Then
            BOTRes.ClickElement("TOOLBAR_FRIENDS")
        Else
            BOTRes.ClickElement("FRIENDS_LOBBY")
        End If

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InFriendScreen() Then Exit Do
        Loop
        If Not InFriendScreen() Then Return

        'Get all hearts
        Threading.Thread.Sleep(1000)
        BOTRes.ClickElement("FRIENDS_GETALL")

        Log("Heart fragment claimed")

        SW = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InMainScreen() Then Exit Do
        Loop
    End Sub

    Sub BackToMainScreen()
        Dim SW As Stopwatch = Stopwatch.StartNew
        If InMainScreen() Then Return

        Log("Back to main game screen...")
        Do
            LongLoopsDenny()

            If InMainScreen() Then Exit Do

            BOTRes.DetecAndClick("CLOSE_POPUP")
            BOTRes.DetecAndClick("CLOSE_CLAIM_SELL_EQUIPMENT")
            If SW.Elapsed.TotalSeconds > 10 Then Exit Sub

            ProcessManualAttack()
            ProcessCardPickup()
            ProcessEndBattle()
        Loop
    End Sub

    Function CheckColor(ByVal Coords() As Point, ByVal Colors() As Color) As Boolean
        If Coords.Length <> Colors.Length Then Return False

        Dim Ret As Boolean = False

        Dim ok_cnt As Integer = 0
        Using bs As Emulator = GetEmulator()
            Ret = CheckColor(bs.GetBuffer, Coords, Colors)
        End Using
        Return Ret
    End Function

    Function CheckColor(Pic As Image(Of Bgr, Byte), ByVal Coords() As Point, ByVal Colors() As Color) As Boolean
        If Coords.Length <> Colors.Length Then Return False

        Dim ok_cnt As Integer = 0

        With Pic
            For i As Integer = 0 To Coords.Length - 1
                Try
                    For x As Integer = Coords(i).X - 1 To Coords(i).X + 1
                        For y As Integer = Coords(i).Y - 1 To Coords(i).Y + 1
                            Dim lx As Integer = 0
                            Dim ly As Integer = 0
                            If x < 0 Then lx = 0
                            If x > .Size.Width - 1 Then lx = .Size.Width - 1

                            If y < 0 Then ly = 0
                            If y > .Size.Height - 1 Then lx = .Size.Height - 1

                            Dim percent As Single = 0.95
                            For p As Integer = 1 To 3
                                Dim r As Integer = Colors(i).R * percent
                                Dim g As Integer = Colors(i).G * percent
                                Dim b As Integer = Colors(i).B * percent

                                If r > 255 Then r = 255
                                If g > 255 Then g = 255
                                If b > 255 Then b = 255

                                Dim clr As Color = Color.FromArgb(r, g, b)
                                percent += 0.05

                                With .Item(y, x)
                                    If .Red = clr.R AndAlso .Green = clr.G AndAlso .Blue = clr.B Then
                                        ok_cnt += 1
                                        Exit Try
                                    End If
                                End With
                            Next
                        Next
                    Next
                Catch ex As Exception
                    Return False
                End Try
            Next
        End With

        Return (ok_cnt >= Coords.Length)
    End Function

    Function SerializeObject(ByVal o As Object) As String
        Return JsonConvert.SerializeObject(o, Formatting.Indented)
    End Function

    Function DeserializeObject(ByVal s As String, Optional ByVal t As Type = Nothing) As Object
        If t Is Nothing Then
            Return JsonConvert.DeserializeObject(s)
        Else
            Return JsonConvert.DeserializeObject(s, t)
        End If
    End Function

    Public Function GetAccountName() As String
        If AccountName = "" Then
            If Not InMainScreen(True) Then
                MsgBox("Cant read your character name! Please inform on next dialog.", MsgBoxStyle.Exclamation)
                Dim Ret As String = InputBox("Type your character name:")
                AccountName = Ret
                InMainScreen(True)
                Return Ret
            Else
                If Not OpenHeroesWindow() Then
                    MsgBox("Cant read your character name! Please inform on next dialog.", MsgBoxStyle.Exclamation)
                    Dim Ret As String = InputBox("Type your character name:")
                    AccountName = Ret
                    InMainScreen(True)
                    Return Ret
                Else
                    Using bs As Emulator = GetEmulator()
                        Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(487, 60, 670, 83))

                            Dim Ret As String = BitmapTools.OCRText(b)
                            If Ret = "" Then
                                MsgBox("Sorry, cant read your character name! Please inform on next dialog.", MsgBoxStyle.Exclamation)
                                Ret = InputBox("Type your character name:")
                            End If

                            AccountName = Ret
                            Log("Account name: " & AccountName)
                            InMainScreen(True)
                            Return Ret

                        End Using
                    End Using
                End If
            End If
        End If

        InMainScreen(True)
        Return AccountName
    End Function

    Function InHeroWindow() As Boolean
        Return BOTRes.Detect("HERO")
    End Function

    Function InHeroesWindow() As Boolean
        Return BOTRes.Detect("HEROES")
    End Function

    Function InHireWindow() As Boolean
        Return BOTRes.Detect("HIRE")
    End Function

    Function InFuseWindow() As Boolean
        Return BOTRes.Detect("FUSE")
    End Function

    Function InUseTicketWindow() As Boolean
        Return BOTRes.Detect("USE_TICKET_WINDOW")
    End Function

    Function InUseTicketResultWindow() As Boolean
        Return BOTRes.Detect("USE_TICKET_RESULT")
    End Function

    Function OpenHireWindow() As Boolean
        If InHireWindow() Then Return True
        If Not OpenHeroWindow() Then Return False

        BOTRes.ClickElement("HERO_HIRE")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InHireWindow() Then Exit Do
            LongLoopsDenny()
        Loop
        Return InHireWindow()
    End Function

    Function OpenFuseWindow() As Boolean
        If InFuseWindow() Then Return True
        If Not OpenHeroWindow() Then Return False

        GetEmulatorStatic.MouseLeftClick(496, 264)
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InFuseWindow() Then Exit Do
            LongLoopsDenny()
        Loop
        Return InFuseWindow()
    End Function

    Function OpenHeroWindow() As Boolean
        If InHeroWindow() Then Return True
        If Not InMainScreen(True) Then Return False

        If MAINSCREEN_MODE = "LEGACY" Then
            BOTRes.ClickElement("TOOLBAR_HERO")
        Else
            BOTRes.ClickElement("TOOLBAR_HERO_LOBBY")
        End If

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InHeroWindow() Then Exit Do
            LongLoopsDenny()
        Loop
        Return InHeroWindow()
    End Function

    Function OpenHeroesWindow() As Boolean
        If InHeroesWindow() Then Return True
        If Not OpenHeroWindow() Then Return False

        BOTRes.ClickElement("HERO_HEROES")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If InHeroesWindow() Then Exit Do
            LongLoopsDenny()
        Loop
        Return InHeroesWindow()
    End Function

    Function IsInviteTower() As Boolean
        Return BOTRes.Detect("INVITATION")
    End Function
    Sub CancelInviteTower()
        BOTRes.ClickElement("INVITATION_CANCEL")
    End Sub
    Sub AcceptInviteTower()
        BOTRes.ClickElement("INVITATION_ACCEPT")
    End Sub

    Sub ClosePopup()
        BOTRes.DetecAndClick("POPUP_CLOSE_01")
        BOTRes.DetecAndClick("POPUP_CLOSE_02")

        If BOTRes.Detect("INVALID_DEVICE_POPUP") Then
            BOTRes.ClickElement("INVALID_DEVICE_BUTTON")
        End If
    End Sub

    Sub CheckLOHFreeze()
        If LastBOTAction.Elapsed.TotalMinutes >= CFG.TimeoutFreeze Then
            Log("BOT was stucked by " & LastBOTAction.Elapsed.ToString & "... Initializing anti-freeze routine")
            Log("Stopping LOH...")
            StaticEmulator.StopGame()
            Threading.Thread.Sleep(5000)
            StaticEmulator.StartGame()
            Threading.Thread.Sleep(5000)
            Log("Waiting LOH start...")
            Dim SW As Stopwatch = Stopwatch.StartNew
            Do While Not StaticEmulator.IsGameRunning
                Threading.Thread.Sleep(1000)
                If SW.Elapsed.TotalMinutes >= 5 Then
                    Log("Game didnt start...")
                    Return
                End If
            Loop

            Log("Game started, waiting for main screen")
            SW = Stopwatch.StartNew
            Do While Not InMainScreen()
                Threading.Thread.Sleep(1000)
                If SW.Elapsed.TotalMinutes >= 5 Then
                    Log("Cant detect main screen...")
                    Return
                End If
            Loop
            Log("Game back to normal after " & Math.Round(SW.Elapsed.TotalSeconds, 0) & " seconds, happy botting again...")

            LastBOTAction = Stopwatch.StartNew
        End If
    End Sub
    Sub LongLoopsDenny()
        Application.DoEvents()
        If IsInviteTower() Then
            If Not CFG.AutoTower_Coop Then
                CancelInviteTower()
            Else
                CheckCoopInvitation()
            End If
        End If
        If InMimiEggDialog() Then
            CloseMimiEggDialog()
        End If
        CheckLOHFreeze()
        ClosePopup()
    End Sub

    Function InviteTowerText() As String
        Dim Ret As String = ""

        Using bs As Emulator = GetEmulator()
            Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(277, 195, 684, 350))
                Ret = BitmapTools.OCRText(b)
            End Using
        End Using


        Return Ret
    End Function

    Function SellAll() As Boolean
        If Not OpenInventory() Then Return False
        Dim lIniGold As Long = GetGold()
        SellArmor()
        SellMelee()
        SellRanged()
        SellMagic()
        Threading.Thread.Sleep(1000)
        Log("Gold earned after selling = " & GetGold() - lIniGold)
        BackToMainScreen()
    End Function
    Sub SellArmor()
        Log("Selling armor...")
        BOTRes.ClickElement("INVENTORY_ARMOR")
        Threading.Thread.Sleep(500)
        If CFG.AutoSellEverything Then
            SellAllCurrentTab()
        ElseIf CFG.AutoSellFilter Then
            SellAllFiltered()
        End If
    End Sub
    Sub SellMelee()
        Log("Selling melee...")
        BOTRes.ClickElement("INVENTORY_MELEE")
        Threading.Thread.Sleep(500)
        If CFG.AutoSellEverything Then
            SellAllCurrentTab()
        ElseIf CFG.AutoSellFilter Then
            SellAllFiltered()
        End If
    End Sub
    Sub SellRanged()
        Log("Selling ranged...")
        BOTRes.ClickElement("INVENTORY_RANGED")
        Threading.Thread.Sleep(500)
        If CFG.AutoSellEverything Then
            SellAllCurrentTab()
        ElseIf CFG.AutoSellFilter Then
            SellAllFiltered()
        End If
    End Sub
    Sub SellMagic()
        Log("Selling magic...")
        BOTRes.ClickElement("INVENTORY_MAGIC")
        Threading.Thread.Sleep(500)
        If CFG.AutoSellEverything Then
            SellAllCurrentTab()
        ElseIf CFG.AutoSellFilter Then
            SellAllFiltered()
        End If
    End Sub

    Sub SellAllFiltered()
        Dim ListItem As New List(Of String)

        Dim TmpItem As String = CFG.AutoSellFilterItems
        TmpItem = TmpItem.Replace(Environment.NewLine, ";")
        TmpItem = TmpItem.Replace(vbCr, ";")
        TmpItem = TmpItem.Replace(vbLf, ";")
        TmpItem = TmpItem.Replace(";;", ";")
        TmpItem = TmpItem.Replace(";;", ";")
        TmpItem = TmpItem.Replace(";;", ";")

        ListItem.AddRange(TmpItem.Split(";"))

        Threading.Thread.Sleep(1000)
        Dim Slots As List(Of Point) = GetUsedInventorySlots()
        If Slots.Count = 0 Then
            Log("Current inventory tab is empty")
        Else
            Log("Found [" & Slots.Count & "] used inventory slots, checking items to sell")
            For Each p As Point In Slots
                GetEmulatorStatic.MouseLeftClick(p)

                Dim rect_pos As Rectangle = Rectangle.Empty
                Dim idx As Integer = BOTRes.DetectMultipleWait(New String() {"SELL_ITEM_BUTTON", "DISASSEMBLE_ITEM_BUTTON"}, 3, rect_pos)

                If idx = 0 Then
                    Using bs As Emulator = GetEmulator()
                        Dim ItemName As String = BitmapTools.OCRText(bs.GetBuffer.ToBitmap, Rectangle.FromLTRB(332, 17, 700, 44))
                        Dim SellIt As Boolean = False
                        For Each li As String In ListItem
                            If ItemName.ToUpper.Contains(li.ToUpper.Trim) Then
                                SellIt = True
                                Exit For
                            End If
                        Next

                        If SellIt Then
                            Log(ItemName & " = Selling")
                            Dim pos As Rectangle = rect_pos 'BOTRes.DetectPosition("SELL_ITEM_BUTTON")
                            If pos <> Rectangle.Empty Then
                                Dim pt As New Point(pos.Left + 60, pos.Top + (pos.Height / 2))
                                GetEmulatorStatic.MouseLeftClick(pt)
                                Threading.Thread.Sleep(500)
                                GetEmulatorStatic.MouseLeftClick(484, 404)
                                Threading.Thread.Sleep(500)
                            End If
                            GetEmulatorStatic.MouseLeftClick(20, 520)
                            Threading.Thread.Sleep(500)
                        Else
                            Log(ItemName & " = Dont sell, bot will keep it")
                            GetEmulatorStatic.MouseLeftClick(20, 520)
                            Threading.Thread.Sleep(500)
                        End If
                    End Using
                ElseIf idx = 1 Then
                    Log("Item cant be sold, just disassembled. Keeping it")
                    GetEmulatorStatic.MouseLeftClick(20, 520)
                    Threading.Thread.Sleep(500)
                Else
                    Log("Unable to identify this item. Keeping it")
                    GetEmulatorStatic.MouseLeftClick(20, 520)
                    Threading.Thread.Sleep(500)
                End If
            Next
        End If
    End Sub

    Sub SellAllCurrentTab()
        Dim SW As Stopwatch = Stopwatch.StartNew
        If SellAllCheckBoxCheck() Then
            BOTRes.ClickElement("INVENTORY_SELLALL")
            SW = Stopwatch.StartNew
            Do
                If Not SellAllCheckBoxStatus() Then Exit Do
                If SellEquipmentDialogOpened() Then Exit Do
                If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            Loop
            Threading.Thread.Sleep(1000)
            If Not SellEquipmentDialogOpened() Then Return
            LastBOTAction = Stopwatch.StartNew
            BOTRes.ClickElement("SELL_EQUIP_CONFIRM")
            Threading.Thread.Sleep(1000)

            If SellEquipmentAPlusDialogOpened() Then
                Log("A+ equipment detected")
                SW = Stopwatch.StartNew
                Do While SellEquipmentAPlusDialogOpened()
                    BOTRes.ClickElement("SELL_EQUIP_APLUS_OK")
                    Threading.Thread.Sleep(1000)
                    If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                Loop
            End If
        End If
    End Sub

    Function SellEquipmentDialogOpened() As Boolean
        Return BOTRes.Detect("SELL_EQUIP_CONFIRM")
    End Function
    Function SellEquipmentAPlusDialogOpened() As Boolean
        Return BOTRes.Detect("SELL_EQUIP_APLUS_CONFIRM")
    End Function

    Function SellAllCheckBoxStatus() As Boolean
        Return BOTRes.Detect("INVENTORY_SELECTALL_ON")
    End Function

    Function SellAllCheckBoxCheck() As Boolean
        If SellAllCheckBoxStatus() Then Return False
        BOTRes.ClickElement("INVENTORY_SELECTALL")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SellAllCheckBoxStatus() Then Return True
            If SW.Elapsed.TotalSeconds > 10 Then Return False
        Loop
        Return False
    End Function

    Public Sub Tick(ByRef swObj As Stopwatch)
        swObj = Stopwatch.StartNew
    End Sub

    Public Function GetGold() As Long
        Log("Checking current gold...")
        If Not InInventory() Then
            If Not OpenInventory() Then
                Return -1
            End If
        End If
        If Not InInventory() Then Return -1

        '109, 504,260, 527
        Using bs As Emulator = GetEmulator()
            Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(109, 504, 260, 527))

                Dim Ret As Long = BitmapTools.OCRNumeric(b)
                Log("Gold = " & Ret)

                Dim Dt As Date = Now
                If Not GoldEarnList.ContainsKey(Dt) Then
                    GoldEarnList.Add(Dt, Ret)
                    UpdateStats()
                End If

                Return Ret
            End Using
        End Using

    End Function

    Public Function IsMoraleEmpty() As Boolean

    End Function

    Public Sub CloseInvalidDevicePopup()
        If InInvalidDevicePopup() Then
            GetEmulatorStatic.MouseLeftClick(477, 371)
            Threading.Thread.Sleep(1000)
        End If
    End Sub


    Public Function InInvalidDevicePopup() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(367, 179))
        Colors.Add(Color.FromArgb(37, 11, 10))

        Coords.Add(New Point(620, 237))
        Colors.Add(Color.FromArgb(22, 15, 15))

        Coords.Add(New Point(533, 359))
        Colors.Add(Color.FromArgb(160, 82, 13))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Public Function InMimiEggDialog() As Boolean
        Return BOTRes.Detect("MIMI_POPUP")
    End Function
    Sub CloseMimiEggDialog()
        If Not InMimiEggDialog() Then Return
        BOTRes.ClickElement("MIMI_CANCEL")
    End Sub
    Function InMoraleWindow() As Boolean
        Return BOTRes.Detect("ADD_MORALE_WINDOW")
    End Function
    Function OpenMoraleWindow() As Boolean
        If InMoraleWindow() Then Return True
        If Not InMainScreen() Then Return False

        BOTRes.ClickElement("ADD_MORALE")
        Return BOTRes.DetectWait("ADD_MORALE_WINDOW", 10)
    End Function
    Function GetMoraleCost(Optional ForceOpenMoraleWindow As Boolean = True) As Long
        If ForceOpenMoraleWindow Then
            If Not OpenMoraleWindow() Then Return -1
        End If

        Using bs As Emulator = GetEmulator()
            Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(388, 80, 593, 114))

                Dim Ret As String = BitmapTools.OCRText(b).ToUpper.Replace("GOLD", "").Replace("USE", "").Replace(" ", "").Replace(",", "")
                Ret = Ret.Replace("l", "1")
                Ret = Ret.Replace("i", "1")
                Ret = Ret.Replace("I", "1")
                Ret = Ret.Replace("j", "1")
                Ret = Ret.Replace("J", "1")
                Ret = Ret.Replace("o", "0")
                Ret = Ret.Replace("O", "0")
                Ret = Ret.Replace("q", "0")
                Ret = Ret.Replace("Q", "0")
                Ret = Ret.Replace("S", "5")
                Ret = Ret.Replace("s", "5")
                Ret = Ret.Replace("b", "3")
                Ret = Ret.Replace("B", "3")
                Ret = Ret.Replace("z", "2")
                Ret = Ret.Replace("Z", "2")
                Ret = Ret.Replace("T", "7")
                Ret = Ret.Replace("t", "7")

                Ret = Ret.Replace(".", "")
                Ret = Ret.Replace(",", "")
                Ret = Ret.Replace(" ", "")
                Ret = Ret.Replace("/", "")
                Ret = Ret.Replace("+", "")
                Ret = Ret.Replace("[", "")
                Ret = Ret.Replace("]", "")
                Ret = Ret.Replace("(", "")
                Ret = Ret.Replace(")", "")
                Ret = Ret.Replace("{", "")
                Ret = Ret.Replace("}", "")
                Ret = Ret.Replace("$", "")
                Ret = Ret.Replace("%", "")
                Ret = Ret.Replace("#", "")
                Ret = Ret.Replace("=", "")
                Dim rgx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[^0-9]")
                Ret = rgx.Replace(Ret, "")

                Dim RetLng As Long = 0
                If Long.TryParse(Ret, RetLng) Then
                    If RetLng < 10000 Then RetLng = RetLng * 10
                    Log("Morale cost = " & RetLng)
                    Return RetLng
                Else
                    Log("Fail to read morale cost [" & Ret & "]")
                    Return -1
                End If

            End Using
        End Using
    End Function

    Function RefillMoraleGold(Optional ForceOpenMoraleWindow As Boolean = True) As Boolean
        If ForceOpenMoraleWindow Then
            If Not OpenMoraleWindow() Then Return False
        End If

        BOTRes.ClickElement("ADD_MORALE_ONE_GOLD")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If Not InMoraleWindow() Then Exit Do
        Loop
        Return (Not InMoraleWindow())
    End Function

    Function IsFighting() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(415, 492))
        Colors.Add(Color.FromArgb(116, 52, 51))

        Coords.Add(New Point(746, 463))
        Colors.Add(Color.FromArgb(106, 104, 105))

        Coords.Add(New Point(921, 398))
        Colors.Add(Color.FromArgb(37, 23, 4))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function IsAutoFightActivated() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(676, 492))
        Colors.Add(Color.FromArgb(255, 24, 21))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function ActivateAutoFight() As Boolean
        If IsAutoFightActivated() Then Return True
        GetEmulatorStatic.MouseLeftClick(693, 511)
        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            If IsAutoFightActivated() Then Exit Do
        Loop
        Return IsAutoFightActivated()
    End Function

    Function IsVictory(ByRef ReadExpEarned As Long) As Boolean
        Dim Ret As Boolean = False

        ReadExpEarned = -1

        Using bs As Emulator = GetEmulator()
            Ret = BOTRes.Detect("BATTLE_VICTORY", bs)
            If Ret Then
                Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(796, 182, 921, 210))
                    ReadExpEarned = BitmapTools.OCRNumeric(b)

                    Dim Dt As Date = Now
                    If Not ExpEarnList.ContainsKey(Dt) Then
                        ExpEarnList.Add(Dt, ReadExpEarned)
                        UpdateStats()
                    End If
                End Using
            End If
        End Using
        Return Ret
    End Function

    Function IsDefeat(ByRef ReadExpEarned As Long) As Boolean
        Dim Ret As Boolean = False

        ReadExpEarned = -1

        Using bs As Emulator = GetEmulator()
            Ret = BOTRes.Detect("BATTLE_DEFEAT", bs)
            If Ret Then
                Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(746, 130, 915, 159))
                    ReadExpEarned = BitmapTools.OCRNumeric(b)

                    Dim Dt As Date = Now
                    If Not ExpEarnList.ContainsKey(Dt) Then
                        ExpEarnList.Add(Dt, ReadExpEarned)
                        UpdateStats()
                    End If
                End Using
            End If
        End Using
        Return Ret
    End Function

    Sub SendMineTroops()
        If Not CFG.GuildMineDeploy Then Return
        If NextSendMines > Now Then Return

        AbortMine = False

        If Not OpenMineScreen() Then Return

        Dim SearchPage As Integer = 0
        Dim ExpRemain As Integer = 0
        Dim ExpTotal As Integer = 0
        Dim RechargeDate As Date = Date.MinValue
        Dim CurrPage As Integer = 0
        Dim TotalPage As Integer = 0
        Dim MineOK As Integer = -1
        Dim NextRecharge As TimeSpan = TimeSpan.MinValue

        If Not GetMineProperties(ExpRemain, ExpTotal, RechargeDate, CurrPage, TotalPage, NextRecharge) Then Return
        If ExpRemain = 0 Then
            NextSendMines = Now.Add(NextRecharge)
            Log("No remain expeditions to send, next time to send troops is [" & NextSendMines.ToString("HH:mm:ss") & "]")
            Return
        End If

        SearchPage = TotalPage

        Do
            If Not GoToMinePage(SearchPage) Then
                Log("Cant reach mine page [" & SearchPage & "]... OCR may failed, will try again later")
                Return
            Else
                Dim SentMine As Boolean = False

                If Not AbortMine AndAlso Not SentMine AndAlso MineCanSendExpedition(4) Then
                    Log("Trying to send troops to mine [" & 4 & "] in page [" & SearchPage & "]")
                    If Not SendMineTroops(4) Then
                        Threading.Thread.Sleep(4000)
                        SentMine = False
                    Else
                        Threading.Thread.Sleep(4000)
                        SentMine = True
                    End If
                End If

                If Not AbortMine AndAlso Not SentMine AndAlso MineCanSendExpedition(3) Then
                    Log("Trying to send troops to mine [" & 3 & "] in page [" & SearchPage & "]")
                    If Not SendMineTroops(3) Then
                        Threading.Thread.Sleep(4000)
                        SentMine = False
                    Else
                        Threading.Thread.Sleep(4000)
                        SentMine = True
                    End If
                End If

                If Not AbortMine AndAlso Not SentMine AndAlso MineCanSendExpedition(2) Then
                    Log("Trying to send troops to mine [" & 2 & "] in page [" & SearchPage & "]")
                    If Not SendMineTroops(2) Then
                        Threading.Thread.Sleep(4000)
                        SentMine = False
                    Else
                        Threading.Thread.Sleep(4000)
                        SentMine = True
                    End If
                End If

                If Not AbortMine AndAlso Not SentMine AndAlso MineCanSendExpedition(1) Then
                    Log("Trying to send troops to mine [" & 1 & "] in page [" & SearchPage & "]")
                    If Not SendMineTroops(1) Then
                        Threading.Thread.Sleep(4000)
                        SentMine = False
                    Else
                        Threading.Thread.Sleep(4000)
                        SentMine = True
                    End If
                End If

                If Not SentMine Then
                    If AbortMine Then
                        NextSendMines = Now.AddHours(1)
                        Log("Bot must hold before send more troops, next time is [" & NextSendMines.ToString("HH:mm:ss") & "]")
                        BackToMainScreen()
                        Exit Do
                    End If
                    If SearchPage = 1 Then Exit Do
                    SearchPage -= 1
                Else
                    SearchPage -= 1
                    If Not GetMineProperties(ExpRemain, ExpTotal, RechargeDate, CurrPage, TotalPage, NextRecharge) Then Return
                    If ExpRemain = 0 Then
                        NextSendMines = Now.Add(NextRecharge)
                        Log("No remain expeditions to send, next time to send troops is [" & NextSendMines.ToString("HH:mm:ss") & "]")
                        Exit Do
                    End If

                End If

            End If
        Loop
        Threading.Thread.Sleep(2000)
        BackToMainScreen()

    End Sub

    Function SendMineTroops(MineID As Integer) As Boolean
        If Not InMineScreen() Then Return False

        LastBOTAction = Stopwatch.StartNew

        Dim Coords As New Dictionary(Of Integer, Point)
        Select Case MineID
            Case 1
                If Not Mine1CanSendExpedition() Then Return False
            Case 2
                If Not Mine2CanSendExpedition() Then Return False
            Case 3
                If Not Mine3CanSendExpedition() Then Return False
            Case 4
                If Not Mine4CanSendExpedition() Then Return False
            Case Else
                Return False
        End Select

        BOTRes.ClickElement("MINE_SEND_EXPEDITION_" & MineID)

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            If InMinePreSendScreen() Then Exit Do
            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
            LongLoopsDenny()
        Loop
        If Not InMinePreSendScreen() Then Return False

        If IsGoldMine() Then
            If Not CFG.GuildMineDeploy_Gold Then
                BOTRes.DetecAndClick("CLOSE_POPUP")
                Return False
            Else
                Dim Mineral As Integer = MineGetMinerals()
                If Mineral <> -1 AndAlso Mineral < CFG.GuildMineDeploy_GoldMin Then
                    BOTRes.DetecAndClick("CLOSE_POPUP")
                    Return False
                End If
            End If
        ElseIf IsRuneMine() Then
            If Not CFG.GuildMineDeploy_Rune Then
                BOTRes.DetecAndClick("CLOSE_POPUP")
                Return False
            Else
                Dim Mineral As Integer = MineGetMinerals()
                If Mineral <> -1 AndAlso Mineral < CFG.GuildMineDeploy_RuneMin Then
                    BOTRes.DetecAndClick("CLOSE_POPUP")
                    Return False
                End If
            End If
        End If

        'Send expedition
        BOTRes.ClickElement("MINE_SENDEXPEDITION")
        SW = Stopwatch.StartNew
        Do
            If InMineSendScreen() Then Exit Do
            If SW.Elapsed.TotalSeconds > 30 Then Exit Do
        Loop
        If Not InMineSendScreen() Then Return False

        'Auto formation
        BOTRes.ClickElement("MINE_AUTOFORM")
        Threading.Thread.Sleep(2000)
        BOTRes.ClickElement("MINE_SENDEXPEDITION_FINAL")

        SW = Stopwatch.StartNew
        Do
            If InMineSendConfirmationScreen() Then Exit Do
            If SW.Elapsed.TotalSeconds > 30 Then Exit Do
        Loop
        If Not InMineSendConfirmationScreen() Then
            AbortMine = True
            Return False
        End If
        BOTRes.ClickElement("MINE_SENDEXPEDITION_CONFIRM_OK")

        Return True
    End Function

    Function InMineSendConfirmationScreen() As Boolean
        Return BOTRes.Detect("MINE_SENDEXPEDITION_CONFIRM")
    End Function

    Function InMineSendScreen() As Boolean
        Return BOTRes.Detect("MINE_SENDSCREEN")
    End Function

    Function InMinePreSendScreen() As Boolean
        Return BOTRes.Detect("MINE_PRESEND_SCREEN")
    End Function

    Function IsGoldMine() As Boolean
        Return BOTRes.Detect("MINE_GOLD")
    End Function
    Function IsRuneMine() As Boolean
        Return BOTRes.Detect("MINE_RUNE")
    End Function

    Function MineGetMinerals() As Integer
        Dim Ret As Integer = -1
        Using bs As Emulator = GetEmulator()
            Ret = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(680, 451, 742, 474))
        End Using
        Return Ret
    End Function

    Function IsMineUnclaimed(MineID As Integer) As Boolean
        Dim Ret As Boolean = False
        Dim Coords As New Dictionary(Of Integer, Rectangle)
        Coords.Add(1, Rectangle.FromLTRB(706, 163, 834, 184))
        Coords.Add(2, Rectangle.FromLTRB(706, 251, 834, 273))
        Coords.Add(3, Rectangle.FromLTRB(706, 339, 834, 361))
        Coords.Add(4, Rectangle.FromLTRB(706, 427, 834, 448))

        Using bs As Emulator = GetEmulator()
            Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Coords(MineID))
                Dim MineType As String = BitmapTools.OCRText(b)
                If MineType.Contains(" Mine") Then Ret = True
                If MineType.Contains("Unclaim") Then Ret = True
                If MineType.Contains("med min") Then Ret = True
                If MineType.Contains("Unclaimed") Then Ret = True
            End Using
        End Using

        Return Ret
    End Function

    Function GetMineMembers(MineID As Integer) As Integer
        Dim Ret As Integer = -1
        Dim CoordsUnc As New Dictionary(Of Integer, Rectangle)
        Dim CoordsOwn As New Dictionary(Of Integer, Rectangle)
        CoordsUnc.Add(1, Rectangle.FromLTRB(115, 175, 175, 204))
        CoordsUnc.Add(2, Rectangle.FromLTRB(115, 260, 175, 292))
        CoordsUnc.Add(3, Rectangle.FromLTRB(115, 351, 175, 379))
        CoordsUnc.Add(4, Rectangle.FromLTRB(115, 440, 175, 469))

        CoordsOwn.Add(1, Rectangle.FromLTRB(775, 185, 835, 210))
        CoordsOwn.Add(2, Rectangle.FromLTRB(775, 273, 835, 298))
        CoordsOwn.Add(3, Rectangle.FromLTRB(775, 362, 835, 385))
        CoordsOwn.Add(4, Rectangle.FromLTRB(775, 448, 835, 473))

        If IsMineUnclaimed(MineID) Then
            Using bs As Emulator = GetEmulator()
                Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, CoordsUnc(MineID))
                    Dim Members As String = BitmapTools.OCRText(b)
                    Members = Members.Replace("(", "")
                    Members = Members.Replace(")", "")
                    If Members.Contains("/") Then
                        Ret = BitmapTools.OCRNumeric(Members.Split("/")(0))
                    End If
                End Using
            End Using
        Else
            Using bs As Emulator = GetEmulator()
                Using b As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, CoordsOwn(MineID))
                    Dim Members As String = BitmapTools.OCRText(b)
                    Members = Members.Replace("(", "")
                    Members = Members.Replace(")", "")
                    If Members.Contains("/") Then
                        Ret = BitmapTools.OCRNumeric(Members.Split("/")(0))
                    End If
                End Using
            End Using
        End If

        Return Ret
    End Function

    Function MineCanSendExpedition(MineID As Integer) As Boolean
        Select Case MineID
            Case 1
                Return Mine1CanSendExpedition()
            Case 2
                Return Mine2CanSendExpedition()
            Case 3
                Return Mine3CanSendExpedition()
            Case 4
                Return Mine4CanSendExpedition()
            Case Else
                Return False
        End Select
    End Function

    Function Mine1CanSendExpedition() As Boolean
        Dim Ret As Boolean = True

        Ret = BOTRes.DetectColor("MINE_SEND_EXPEDITION_1")
        If Ret Then
            Dim Members As Integer = GetMineMembers(1)
            If Members > CFG.GuildMineDeploy_MaxTroops Then
                Ret = False
            End If
        End If

        Return Ret
    End Function
    Function Mine2CanSendExpedition() As Boolean
        Dim Ret As Boolean = True

        Ret = BOTRes.DetectColor("MINE_SEND_EXPEDITION_2")
        If Ret Then
            Dim Members As Integer = GetMineMembers(2)
            If Members > CFG.GuildMineDeploy_MaxTroops Then
                Ret = False
            End If
        End If

        Return Ret
    End Function
    Function Mine3CanSendExpedition() As Boolean
        Dim Ret As Boolean = True

        Ret = BOTRes.DetectColor("MINE_SEND_EXPEDITION_3")
        If Ret Then
            Dim Members As Integer = GetMineMembers(3)
            If Members > CFG.GuildMineDeploy_MaxTroops Then
                Ret = False
            End If
        End If

        Return Ret
    End Function
    Function Mine4CanSendExpedition() As Boolean
        Dim Ret As Boolean = True

        Ret = BOTRes.DetectColor("MINE_SEND_EXPEDITION_4")
        If Ret Then
            Dim Members As Integer = GetMineMembers(4)
            If Members > CFG.GuildMineDeploy_MaxTroops Then
                Ret = False
            End If
        End If

        Return Ret
    End Function

    Function GoToMinePage(Page As Integer) As Boolean
        Dim TryCnt As Integer = 0
        Dim ExpRemain As Integer = 0
        Dim ExpTotal As Integer = 0
        Dim RechargeDate As Date = Date.MinValue
        Dim CurrPage As Integer = 0
        Dim TotalPage As Integer = 0
        Dim NextRecharge As TimeSpan = TimeSpan.MinValue

        Do
            TryCnt += 1
            If GetMineProperties(ExpRemain, ExpTotal, RechargeDate, CurrPage, TotalPage, NextRecharge) Then
                If CurrPage = Page Then Exit Do

                Dim CurrPageBeforeChange As Integer = CurrPage
                If CurrPage > Page Then
                    If CurrPage = 1 Then Exit Do
                    'Previous page
                    BOTRes.ClickElement("MINE_PREVIOUS_PAGE")
                    Log("Moving to mine page [" & CurrPage - 1 & "]")
                Else
                    If CurrPage = TotalPage Then Exit Do
                    'Next page
                    BOTRes.ClickElement("MINE_NEXT_PAGE")
                    Log("Moving to mine page [" & CurrPage + 1 & "]")
                End If
                Dim SW As Stopwatch = Stopwatch.StartNew
                Do
                    If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                    If GetMineProperties(ExpRemain, ExpTotal, RechargeDate, CurrPage, TotalPage, NextRecharge) Then
                        If CurrPage <> CurrPageBeforeChange Then Exit Do
                    End If
                Loop
            End If
            If TryCnt > (Page * 2) Then Return False
        Loop

        Return True
    End Function

    Function GetMineProperties(ByRef ExpeditionsRemain As Integer, ByRef ExpeditionsTotal As Integer, ByRef RechargeDate As Date, ByRef CurrentPage As Integer, ByRef TotalPages As Integer, ByRef NextRecharge As TimeSpan) As Boolean
        If Not InMineScreen() Then Return False
        Using bs As Emulator = GetEmulator()
            Dim strRecharge As String = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(584, 54, 726, 75))
            If strRecharge.Contains(":") Then
                Dim parts() As String = strRecharge.Split(":")
                If parts.Length = 3 Then
                    Dim h As Integer = 0
                    Dim m As Integer = 0
                    Dim s As Integer = 0

                    If Integer.TryParse(BitmapTools.OCRNumeric(parts(0).Trim), h) Then
                        Integer.TryParse(BitmapTools.OCRNumeric(parts(0).Trim), m)
                        Integer.TryParse(BitmapTools.OCRNumeric(parts(0).Trim), s)
                    Else
                        h = 1
                    End If
                    NextRecharge = New TimeSpan(h, m + 1, 0)
                Else
                    NextRecharge = New TimeSpan(1, 0, 0)
                End If
            End If


            Using bs_Expeditions As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(860, 53, 931, 73))
                Dim str_Expeditions As String = BitmapTools.OCRText(bs_Expeditions)
                If str_Expeditions.Contains("/") Then
                    Dim parts() As String = str_Expeditions.Split("/")
                    If parts.Length >= 2 Then
                        Dim expr As Integer = 0
                        Dim expt As Integer = 0
                        If Integer.TryParse(BitmapTools.OCRNumeric(parts(0)), expr) Then
                            ExpeditionsRemain = expr
                        End If
                        If Integer.TryParse(BitmapTools.OCRNumeric(parts(1)), expt) Then
                            ExpeditionsTotal = expt
                        End If
                    End If
                Else
                    ExpeditionsRemain = -1
                    ExpeditionsTotal = -1
                End If
            End Using

            Using bs_RefillTime As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(600, 52, 702, 74))
                Dim str_RefillTime As String = BitmapTools.OCRText(bs_RefillTime)
                If str_RefillTime.Contains(":") Then

                    Dim parts() As String = str_RefillTime.Split(":")
                    If parts.Length >= 3 Then
                        Dim rt_hr As Integer = 0
                        Dim rt_mn As Integer = 0
                        Dim rt_sg As Integer = 0

                        Integer.TryParse(BitmapTools.OCRNumeric(parts(0)), rt_hr)
                        Integer.TryParse(BitmapTools.OCRNumeric(parts(1)), rt_mn)
                        Integer.TryParse(BitmapTools.OCRNumeric(parts(2)), rt_sg)

                        RechargeDate = Now.Add(New TimeSpan(rt_hr, rt_mn, rt_sg))

                    End If
                Else
                    RechargeDate = Date.MinValue
                End If
            End Using

            Using bs_Pages As Bitmap = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(441, 506, 494, 526))
                Dim str_Pages As String = BitmapTools.OCRText(bs_Pages)
                If str_Pages.Contains("/") Then

                    Dim parts() As String = str_Pages.Split("/")
                    If parts.Length >= 2 Then
                        Dim pg_cur As Integer = 0
                        Dim pg_tt As Integer = 0

                        If Integer.TryParse(BitmapTools.OCRNumeric(parts(0)), pg_cur) Then
                            CurrentPage = pg_cur
                        Else
                            CurrentPage = -1
                        End If

                        If Integer.TryParse(BitmapTools.OCRNumeric(parts(1)), pg_tt) Then
                            TotalPages = pg_tt
                        Else
                            TotalPages = -1
                        End If

                    End If
                Else
                    CurrentPage = -1
                    TotalPages = -1
                End If
            End Using
        End Using
        Return True
    End Function

    Function HaveMessage() As Boolean
        Dim RetFn As Boolean = False
        'Using bs As Emulator = GetEmulator()
        '    Dim ret() As Rectangle = ImageRecognition.Search(bs.GetBuffer.Bitmap, My.Resources.BUTTON_MESSAGE)
        '    If ret.Length > 0 Then
        '        RetFn = True
        '    End If
        'End Using
        Return RetFn
    End Function

    Function OpenMessageWindow() As Boolean
        If InMessageWindow() Then Return True
        If Not InMainScreen(True) Then Return False

        'Using bs As Emulator = GetEmulator()
        '    Dim ret() As Rectangle = ImageRecognition.Search(bs.GetBuffer.Bitmap, My.Resources.BUTTON_MESSAGE)
        '    If ret.Length > 0 Then
        '        MouseLeftClick(ret(0).Left + (ret(0).Width / 2), ret(0).Top + (ret(0).Height / 2))
        '        Dim SW As Stopwatch = Stopwatch.StartNew
        '        Do
        '            If InMessageWindow() Then Exit Do
        '            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
        '            LongLoopsDenny()
        '        Loop
        '        If InMessageWindow() Then Return True
        '    End If
        'End Using

        Return False
    End Function

    Sub ReadMessages()
        If Not HaveMessage() Then Return
        If Not OpenMessageWindow() Then Return

        Do
            If HaveUnreadMessage() Then Exit Do
            LongLoopsDenny()
        Loop

        Do
            If InMessageWindow() Then
                If Not HaveUnreadMessage() And Not HaveMessageSelected() Then Exit Do
                If Not HaveMessageSelected() Then
                    GetEmulatorStatic.MouseLeftClick(539, 186)
                    Dim SW As Stopwatch = Stopwatch.StartNew
                    Do
                        LongLoopsDenny()
                        If InReadingMessageWindow() Then Exit Do
                        If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                    Loop
                    If InReadingMessageWindow() Then
                        GetEmulatorStatic.MouseLeftClick(583, 520)
                        Threading.Thread.Sleep(1000)
                        SW = Stopwatch.StartNew
                        Do
                            If HaveUnreadMessage() Then Exit Do
                            If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                        Loop
                    End If
                End If
            End If
            LongLoopsDenny()
        Loop
        BackToMainScreen()
    End Sub

    Function InReadingMessageWindow() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(295, 14))
        Colors.Add(Color.FromArgb(56, 15, 15))

        Coords.Add(New Point(331, 504))
        Colors.Add(Color.FromArgb(167, 77, 25))

        Coords.Add(New Point(626, 535))
        Colors.Add(Color.FromArgb(41, 25, 21))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function HaveUnreadMessage() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(543, 183))
        Colors.Add(Color.FromArgb(54, 38, 38))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function HaveMessageSelected() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(510, 154))
        Colors.Add(Color.FromArgb(103, 53, 35))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Function InMessageWindow() As Boolean
        Dim Coords As New List(Of Point)
        Dim Colors As New List(Of Color)

        Coords.Add(New Point(322, 10))
        Colors.Add(Color.FromArgb(128, 12, 14))

        Coords.Add(New Point(161, 109))
        Colors.Add(Color.FromArgb(69, 18, 17))

        Coords.Add(New Point(871, 127))
        Colors.Add(Color.FromArgb(32, 3, 3))

        Coords.Add(New Point(384, 515))
        Colors.Add(Color.FromArgb(196, 168, 109))

        Coords.Add(New Point(573, 514))
        Colors.Add(Color.FromArgb(205, 178, 115))

        Return CheckColor(Coords.ToArray, Colors.ToArray)
    End Function

    Sub UpdateStats()
        Try
            If BotWnd.InvokeRequired Then
                BotWnd.BeginInvoke(New MethodInvoker(AddressOf UpdateStats))
            Else
                Dim lStartGold As Long = 0
                Dim lEndGold As Long = 0
                Dim lGoldBalance As Long = 0
                Dim lGoldBalanceHour As Long = 0

                Dim lTotalExp As Long = 0
                Dim lExpMin As Long = 0

                Dim LastGold As Long = 0
                Dim LastExp As Long = 0

                Dim ks() As Date = Array.CreateInstance(GetType(Date), GoldEarnList.Count)
                GoldEarnList.Keys.CopyTo(ks, 0)

                If ks.Length > 0 Then
                    If ks.Length = 1 Then
                        lStartGold = GoldEarnList(ks(0))
                        lEndGold = lStartGold
                        lGoldBalance = 0
                        lGoldBalanceHour = 0
                    Else
                        lStartGold = GoldEarnList(ks(0))
                        lEndGold = GoldEarnList(ks(ks.Length - 1))
                        lGoldBalance = lEndGold - lStartGold
                        Dim Hours As TimeSpan = ks(ks.Length - 1).Subtract(ks(0))
                        If Hours.TotalHours = 0 Then
                            lGoldBalanceHour = lGoldBalance
                        Else
                            lGoldBalanceHour = lGoldBalance / Hours.TotalHours
                        End If
                    End If
                End If

                For i As Integer = ks.Length - 1 To 0 Step -1
                    If GoldEarnList(ks(i)) <> 0 Then
                        LastGold = GoldEarnList(ks(i))
                        Exit For
                    End If
                Next

                ks = Array.CreateInstance(GetType(Date), ExpEarnList.Count)
                ExpEarnList.Keys.CopyTo(ks, 0)

                If ks.Length > 0 Then
                    Dim StartTime As Date = ks(ks.Length - 1)
                    Dim EndTime As Date = ks(ks.Length - 1)
                    Dim TTExp As Long = 0
                    For i As Integer = ks.Length - 1 To 0 Step -1
                        EndTime = ks(i)
                        TTExp += ExpEarnList(ks(i))
                        If StartTime.Subtract(ks(i)).TotalHours >= 1 Then Exit For
                    Next

                    For i As Integer = ks.Length - 1 To 0 Step -1
                        lTotalExp += ExpEarnList(ks(i))
                    Next

                    Dim MinExp As TimeSpan = StartTime.Subtract(EndTime)
                    If MinExp.TotalMinutes = 0 Then
                        lExpMin = TTExp
                    Else
                        lExpMin = TTExp / MinExp.TotalMinutes
                    End If
                End If

                For i As Integer = ks.Length - 1 To 0 Step -1
                    If ExpEarnList(ks(i)) <> 0 Then
                        LastExp = ExpEarnList(ks(i))
                        Exit For
                    End If
                Next

                With BotWnd
                    .lblFights.Text = "Fights: " & NumFights

                    .lblStatsStartGold.Text = "Start Gold: " & lStartGold.ToString("#,##0")
                    .lblStatsCurrentGold.Text = "Current Gold: " & lEndGold.ToString("#,##0")
                    .lblStatsGoldBalance.Text = "Gold Balance: " & lGoldBalance.ToString("#,##0")
                    .lblStatsGoldBalanceHour.Text = "Gold Balance/Hour: " & lGoldBalanceHour.ToString("#,##0")

                    If LastGold <> 0 Then
                        .grGold.AddData(LastGold)
                    End If

                    If lExpMin <> 0 Then
                        .grExp.AddData(lExpMin)
                    End If

                    .lblStatsTotalExp.Text = "Total Experience: " & lTotalExp
                    .lblStatsTotalExpMinute.Text = "Total Exp/Minute: " & lExpMin

                    If BOTStartTime = Date.MinValue Then
                        .lblStatBotTime.Text = "Bot Time: 00:00:00"
                    Else
                        Dim TS As TimeSpan = Now.Subtract(BOTStartTime)
                        If TS.TotalHours = 0 Then
                            .lblFightsHour.Text = "Fights/Hour: 0"
                        Else
                            .lblFightsHour.Text = "Fights/Hour: " & (NumFights / TS.TotalHours).ToString("#,##0")
                        End If

                        Dim TSFMT As String = TS.ToString
                        If TSFMT.Contains(".") Then
                            Dim Parts() As String = TSFMT.Split(".")
                            TSFMT = ""
                            For i As Integer = 0 To Parts.Length - 1
                                If Parts(i).Contains(":") Then
                                    TSFMT = TSFMT & Parts(i)
                                    Exit For
                                Else
                                    If i = 0 Then
                                        TSFMT = TSFMT & Parts(i)
                                    End If
                                End If
                            Next
                        End If


                        .lblStatBotTime.Text = "Bot Time: " & TSFMT
                    End If
                End With

            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub ClaimMine()
        If Not CFG.AutoMineClaim Then Return

        Do While BOTRes.DetecWaitAndClick("CLAIM_MINE", 2)
            Log("Claiming from mine...")
            If Not BOTRes.DetecWaitAndClick("CLAIM_CLAIM_BUTTON", 2) Then
                StaticEmulator.MouseLeftClick(925, 40)
            End If
        Loop

        If BOTRes.DetecWaitAndClick("CLAIM_MINE_FINISH", 2) Then
            Log("Claiming finished mines")
            If BOTRes.DetectWait("CLAIM_MINE_FINISH_WINDOW", 10) Then
                Dim SW As Stopwatch = Stopwatch.StartNew
                Do
                    If SW.Elapsed.TotalSeconds > 10 Then Exit Do
                    If BOTRes.DetectColor("BATTLE_RECORD_LISTED") Then Exit Do
                Loop

                If BOTRes.DetectColor("BATTLE_RECORD_LISTED") Then
                    Threading.Thread.Sleep(2000)
                    BOTRes.ClickElement("CLAIM_MINE_FINISH_GETALL")
                    Threading.Thread.Sleep(2000)
                End If

                BackToMainScreen()
            End If
        End If
    End Sub
    Sub AutoSell()
        If Not CFG.AutoSell Then Return

        If SWLastSell Is Nothing Then
            SellAll()
            SWLastSell = Stopwatch.StartNew
        Else
            If SWLastSell.Elapsed.TotalMinutes >= CFG.TimeoutSell Then
                SellAll()
                SWLastSell = Stopwatch.StartNew
            End If
        End If
    End Sub

    Public Function GetTowerFloors() As Dictionary(Of Integer, Point)
        Dim Ret As New Dictionary(Of Integer, Point)

        Dim TT1 As New List(Of Rectangle)
        Dim PT1 As New List(Of Point)

        Dim TT2 As New List(Of Rectangle)
        Dim PT2 As New List(Of Point)

        TT1.Add(Rectangle.FromLTRB(643, 409, 703, 439))
        TT1.Add(Rectangle.FromLTRB(384, 370, 435, 400))
        TT1.Add(Rectangle.FromLTRB(229, 252, 289, 282))
        TT1.Add(Rectangle.FromLTRB(405, 161, 465, 191))
        TT1.Add(Rectangle.FromLTRB(626, 178, 686, 208))
        PT1.Add(New Point(674, 371))
        PT1.Add(New Point(410, 332))
        PT1.Add(New Point(259, 218))
        PT1.Add(New Point(432, 122))
        PT1.Add(New Point(656, 135))

        TT2.Add(Rectangle.FromLTRB(607, 390, 667, 420))
        TT2.Add(Rectangle.FromLTRB(169, 236, 229, 266))
        TT2.Add(Rectangle.FromLTRB(287, 208, 347, 238))
        TT2.Add(Rectangle.FromLTRB(586, 216, 646, 246))
        TT2.Add(Rectangle.FromLTRB(685, 121, 745, 151))
        PT2.Add(New Point(641, 347))
        PT2.Add(New Point(197, 195))
        PT2.Add(New Point(313, 173))
        PT2.Add(New Point(613, 181))
        PT2.Add(New Point(713, 87))

        Dim Floor As Integer = 0
        Dim FloorPage As Integer = 0
        Dim FloorPageType As Integer = 2

        Do
            Floor += 1
            If Floor > 100 Then Exit Do

            FloorPage += 1
            If FloorPage > 5 Then
                FloorPage = 1
                If FloorPageType = 2 Then FloorPageType = 1 Else FloorPageType = 2
            End If

            If FloorPageType = 2 Then
                Ret.Add(Floor, PT2(FloorPage - 1))
            Else
                Ret.Add(Floor, PT1(FloorPage - 1))
            End If
        Loop

        Return Ret
    End Function

    Public Function GetCurrentMorale() As Integer
        Using bs As Emulator = GetEmulator()
            Dim Ret As String = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(50, 9, 92, 25))
            If Ret.Contains("/") Then
                Dim parts() As String = Ret.Split("/")
                Dim CurMorale As Integer = 0
                Dim part As String = BitmapTools.OCRNumeric(parts(0).Trim)
                If Integer.TryParse(part, CurMorale) Then
                    Return CurMorale
                Else
                    Return -1
                End If
            Else
                Return -1
            End If
        End Using
    End Function

    Function GetGoldBalance() As Long
        If GoldEarnList.Count <= 1 Then
            Return 0
        End If

        Dim ks() As Date = Array.CreateInstance(GetType(Date), GoldEarnList.Count)
        Dim ult_data As Date = ks(ks.Length - 1)
        Dim cur_data As Date = Date.MinValue

        Dim tt_gold As Long = GoldEarnList(ks(ks.Length - 1))
        Dim cnt As Integer = 1
        For i As Integer = ks.Length - 2 To 0 Step -1
            If GoldEarnList(ks(i)) <> 0 Then
                cnt += 1
                tt_gold += GoldEarnList(ks(i))
                cur_data = ks(i)

                If ult_data.Subtract(cur_data).TotalMinutes >= 30 Then Exit For
            End If
        Next

        If cur_data = Date.MinValue Then
            Return 0
        Else
            If ult_data.Subtract(cur_data).TotalHours = 0 Then
                Return 0
            Else
                Return tt_gold / (ult_data.Subtract(cur_data).TotalHours)
            End If
        End If
    End Function

    Sub UpdateBOTVersion()
        Dim RarEXE As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "rar.exe")
        Dim UpdateFile As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "lohbot_update.rar")
        Dim UpdateScript As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "update.bat")
        Try
            If Not IO.File.Exists(RarEXE) Then
                Log("Downloading unpacker tool (rar.exe)...")
                Using wc As New Net.WebClient
                    wc.DownloadFile("http://www.thebotbay.com/blogs/files/rar.exe", RarEXE)
                End Using

                If IO.File.Exists(RarEXE) Then
                    Log("...Unpacker tool (rar.exe) downloaded!")
                Else
                    Log("Cant download unpacker tool! Update cancelled")
                    Exit Try
                End If
            End If

            If IO.File.Exists(UpdateFile) Then
                IO.File.Delete(UpdateFile)
            End If

            Log("Downloading update package data...")
            Using wc As New Net.WebClient
                wc.DownloadFile("http://www.thebotbay.com/blogs/files/lohbot_update.rar", UpdateFile)
            End Using

            If Not IO.File.Exists(UpdateFile) Then
                Log("Cant download update package data... Cancelled!")
                Exit Try
            End If

            If IO.File.Exists(UpdateScript) Then
                IO.File.Delete(UpdateScript)
            End If

            Dim SB As New System.Text.StringBuilder
            SB.AppendLine("@echo off")
            SB.AppendLine("echo Closing LoHBoT instances...")
            SB.AppendLine("cd """ & My.Application.Info.DirectoryPath & """")
            SB.AppendLine("taskkill /f /t /im ""LoHBoT.exe""")
            SB.AppendLine("echo Waiting for update...")
            SB.AppendLine("ping 127.0.0.1 -n 6 > nul")
            SB.AppendLine("echo Updating BOT...")
            SB.AppendLine("rar x -o+ -inul lohbot_update.rar")
            SB.AppendLine("echo LoHBot updated, starting BOT, please wait...")
            SB.AppendLine("ping 127.0.0.1 -n 2 > nul")
            SB.AppendLine("start LoHBot.exe")
            IO.File.WriteAllText(UpdateScript, SB.ToString)
            Process.Start(UpdateScript)
            End
        Catch ex As Exception
            Log("Failed to update BOT version...")
            Log(ex.ToString)
        End Try
    End Sub

    Sub CheckNewVersion()
        Log("Checking for new BOT version...")
        Try
            Using wc As New Net.WebClient
                Dim data As String = wc.DownloadString("http://www.thebotbay.com/blogs/files/version.txt")
                If data = "" Then
                    Log("No version information available")
                Else
                    data = data.Replace(Environment.NewLine, vbCr)

                    Dim lines As New List(Of String)
                    lines.AddRange(data.Split(vbCr))
                    Dim ver As String = lines(0)
                    If ver <> My.Application.Info.Version.ToString Then
                        Dim sb As New System.Text.StringBuilder
                        lines.RemoveAt(0)
                        For Each s As String In lines
                            sb.AppendLine(s)
                        Next
                        Log("New version found [" & ver & "]")
                        Log("Version details: " & Environment.NewLine & sb.ToString)

                        MsgBox("New version available: [" & ver & "]" & Environment.NewLine & Environment.NewLine & "Check the version details:" & Environment.NewLine & sb.ToString & Environment.NewLine & Environment.NewLine & "Press OK to start update!", MsgBoxStyle.Information)

                        UpdateBOTVersion()
                    Else
                        Log("You have the latest BOT version!")
                    End If
                End If
            End Using
        Catch ex As Exception
            Log("Erro while checking BOT newer versions...")
            Log(ex.ToString)
        End Try
    End Sub

    Public Function AutoHunt_GetHelp() As Boolean
        Log("Looking for Help...")
        BOTRes.ClickElement("GETHELP")
        If Not BOTRes.DetectWait("GETHELP_WINDOW", 3) Then
            BOTRes.DetecAndClick("CLOSE_POPUP")
            Return False
        End If

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do While Not BOTRes.DetectColor("GETHELP_SELECTED")
            BOTRes.ClickElement("GETHELP_PICKHERO")
            Threading.Thread.Sleep(200)
            If SW.Elapsed.TotalSeconds > 5 Then
                BOTRes.DetecWaitAndClick("CLOSE_POPUP", 5)
                Return False
            End If

            If BOTRes.DetectColor("GETHELP_EMPTY") Then
                Log("Used all friend assits...")
                BOTRes.DetecWaitAndClick("CLOSE_POPUP", 5)
                Return True
            End If
        Loop

        Threading.Thread.Sleep(500)
        Log("Friend Assist Selected...")

        Log("Backing to fight...")
        SW = Stopwatch.StartNew
        Do While Not BOTRes.Detect("IN_BATTLE")
            BOTRes.ClickElement("GETHELP_GETHELP")
            Threading.Thread.Sleep(200)
            If SW.Elapsed.TotalSeconds > 5 Then
                BOTRes.DetecWaitAndClick("CLOSE_POPUP", 5)
                Return True
            End If
        Loop

        Log("...Fighting!")

        Return True
    End Function

    Public Sub DoInfiniteBattle()
        If Not CFG.InfiniteBattle Then Return
        If Not SWLastInfBattle Is Nothing Then
            If SWLastInfBattle.Elapsed.TotalMinutes < CFG.TimeoutInfBattle Then Return
        End If

        Log("Starting infinite battle...")
        If Not OpenInfiniteBattle() Then Return

        BOTRes.ClickElement("INF_BATTLE_FIND_TARGET")
        Log("Waiting for opponent...")
        If Not BOTRes.DetectWait("INF_BATTLE_PRESTART", 120) Then
            Log("Game seems to be bugged, no opponent after 2 minutes...")
            Return
        End If

        Log("Opponent found!")
        Dim OpponentName As String = ""
        Using bs As Emulator = GetEmulator()
            OpponentName = BitmapTools.OCRText(bs.GetBuffer.ToBitmap, Rectangle.FromLTRB(758, 49, 945, 73))
        End Using
        If OpponentName <> "" Then
            Log("Fighting against [" & OpponentName & "]")
        End If

        Do While BOTRes.Detect("INF_BATTLE_PRESTART")
            BOTRes.ClickElement("INF_BATTLE_START_ATTACK")
            Threading.Thread.Sleep(1000)
        Loop

        Log("Waiting for battle result...")
        Dim SW As Stopwatch = Stopwatch.StartNew
        Threading.Thread.Sleep(60000)
        Do While Not BOTRes.Detect("INF_BATTLE_FINISH_BATTLE")
            Threading.Thread.Sleep(1000)
            If BOTRes.Detect("INF_BATTLE_WINDOW") Then Exit Do
            Threading.Thread.Sleep(1000)
            If SW.Elapsed.TotalMinutes >= 10 Then
                Log("Game seems to be bugged, no fight result after 10 minutes...")
                Return
            End If
            If InMainScreen() Then
                SWLastInfBattle = Stopwatch.StartNew
                Return
            End If
        Loop
        BOTRes.ClickElement("INF_BATTLE_FINISH_OK")
        Log("Battle finished")
        BackToMainScreen()
        SWLastInfBattle = Stopwatch.StartNew
    End Sub

    Sub CheckCoopInvitation()
        If CFG.AutoTower_CoopActive Then
            CancelInviteTower()
            Return
        End If

        If CFG.AutoTower_CoopSpecificPartner Then
            Dim InviteText As String = InviteTowerText()
            Dim Parts() As String = InviteText.Split(" ")
            Dim PlayerName As String = Parts(0).Replace("[", "").Replace("]", "").Trim

            If CFG.AutoTower_CoopPartners.Contains(PlayerName) Then
                Log("Accept invitation from [" & PlayerName & "]")
                AcceptInviteTower()
                DoCoopTowerAsGuest()
            Else
                Log("Reject invitation from [" & PlayerName & "]")
                CancelInviteTower()
            End If
        End If
    End Sub

    Sub DoCoopTowerAsGuest()

    End Sub

    Sub DoAutoBuyRuneEssence()
        If Not CFG.AutoBuyRuneEssence Then Return
        If Not SWLastRuneEssenceBuy Is Nothing AndAlso SWLastRuneEssenceBuy.Elapsed.TotalHours < 3 Then Return
        If Not InMainScreen(True) Then Return
        Log("Checking Chrono store for rune essence")
        If BOTRes.DetecAndClick("CHRONO_STORE_BUTTON") Then
            If BOTRes.DetectWait("CHRONO_STORE", 10) Then
                Threading.Thread.Sleep(3000)
                Dim pos As Rectangle = BOTRes.DetectPosition("RUNE_ESSENCE")

                SWLastRuneEssenceBuy = Stopwatch.StartNew

                If pos = Rectangle.Empty Then
                    Log("No rune essence to buy, will check again in 3 hours")
                Else
                    Log("Rune essence found! Trying to buy!")
                    Dim BtnPos As New Point(pos.Left + (pos.Width / 2), 455)
                    GetEmulatorStatic.MouseLeftClick(BtnPos)
                    Threading.Thread.Sleep(2000)
                    Using bs As Emulator = GetEmulator()
                        Dim Msg As String = BitmapTools.OCRText(bs.GetBuffer.ToBitmap, Rectangle.FromLTRB(272, 233, 690, 307))
                        If Msg.ToUpper.Contains("ENOUGH") Or Msg.ToUpper.Contains("HEART") Then
                            Log("You dont have enough hearts to purchase this rune essence item, sorry... will check again in 3 hours")
                            GetEmulatorStatic.MouseLeftClick(589, 422)
                        Else
                            Log("Purchasing rune essence...")
                            GetEmulatorStatic.MouseLeftClick(376, 420)
                        End If
                        Threading.Thread.Sleep(1000)
                    End Using
                End If
            Else
                Log("Failed to open chrono store...")
            End If
        Else
            Log("Cant find chrono store button...")
        End If
        BackToMainScreen()
    End Sub

    Function GetUsedInventorySlots() As List(Of Point)
        Dim Ret As New List(Of Point)

        Dim Inventory As New List(Of Rectangle)
        Inventory.Add(Rectangle.FromLTRB(27, 158, 96, 227))
        Inventory.Add(Rectangle.FromLTRB(121, 158, 190, 227))
        Inventory.Add(Rectangle.FromLTRB(215, 158, 281, 227))
        Inventory.Add(Rectangle.FromLTRB(307, 158, 374, 227))
        Inventory.Add(Rectangle.FromLTRB(399, 158, 467, 227))
        Inventory.Add(Rectangle.FromLTRB(493, 158, 560, 227))
        Inventory.Add(Rectangle.FromLTRB(585, 158, 653, 227))
        Inventory.Add(Rectangle.FromLTRB(678, 158, 745, 227))
        Inventory.Add(Rectangle.FromLTRB(770, 158, 838, 227))
        Inventory.Add(Rectangle.FromLTRB(864, 158, 931, 227))

        Inventory.Add(Rectangle.FromLTRB(27, 253, 96, 322))
        Inventory.Add(Rectangle.FromLTRB(121, 253, 190, 322))
        Inventory.Add(Rectangle.FromLTRB(215, 253, 281, 322))
        Inventory.Add(Rectangle.FromLTRB(307, 253, 374, 322))
        Inventory.Add(Rectangle.FromLTRB(399, 253, 467, 322))
        Inventory.Add(Rectangle.FromLTRB(493, 253, 560, 322))
        Inventory.Add(Rectangle.FromLTRB(585, 253, 653, 322))
        Inventory.Add(Rectangle.FromLTRB(678, 253, 745, 322))
        Inventory.Add(Rectangle.FromLTRB(770, 253, 838, 322))
        Inventory.Add(Rectangle.FromLTRB(864, 253, 931, 322))

        Inventory.Add(Rectangle.FromLTRB(27, 348, 96, 417))
        Inventory.Add(Rectangle.FromLTRB(121, 348, 190, 417))
        Inventory.Add(Rectangle.FromLTRB(215, 348, 281, 417))
        Inventory.Add(Rectangle.FromLTRB(307, 348, 374, 417))
        Inventory.Add(Rectangle.FromLTRB(399, 348, 467, 417))
        Inventory.Add(Rectangle.FromLTRB(493, 348, 560, 417))
        Inventory.Add(Rectangle.FromLTRB(585, 348, 653, 417))
        Inventory.Add(Rectangle.FromLTRB(678, 348, 745, 417))
        Inventory.Add(Rectangle.FromLTRB(770, 348, 838, 417))
        Inventory.Add(Rectangle.FromLTRB(864, 348, 931, 417))

        Using bs As Emulator = GetEmulator()
            For Each r As Rectangle In Inventory
                If BitmapTools.AvgBrightness(bs.GetBuffer.ToBitmap, r) > 50 Then
                    Ret.Add(New Point(r.Left + (r.Width / 2), r.Top + (r.Height / 2)))
                End If
            Next
        End Using


        Return Ret
    End Function


    Sub DoAutoTower_ClimbMode()
        If Not OpenTower() Then Return
        '407,8,550,35 tower title
        Dim FloorPos As Point = Point.Empty
        If CFG.NextPlayedFloorType = "" Then
            Log("First time playing Tower Climb mode, detecting the floor type...")
            CFG.NextPlayedFloorType = GetCurrentFloorType(FloorPos)
            If CFG.NextPlayedFloorType = "" Then
                Log("Fail to detect tower floor")
                BackToMainScreen()
                Return
            End If

            Log("Game parked on Tower Floor Type [" & CFG.NextPlayedFloorType & "]")
            Log("1st time BOT play tower climb, starting at bottom floor")
            CFG.NextPlayedFloorTypeIndex = 1
            CFG.NextPlayedSubFloor = 1

            BOTRes.ClickElement(String.Format("HARDTOWER_TYPE{0}_FLOOR{1}", CFG.NextPlayedFloorType, CFG.NextPlayedFloorTypeIndex))
            If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
                Dim NewFloorTtype As String = ""
                If CFG.NextPlayedFloorType = "A" Then NewFloorTtype = "B" Else NewFloorTtype = "A"
                Log("Cant get inside tower floor, maybe is not parked at floor type [" & CFG.NextPlayedFloorType & "], trying swap to [" & CFG.NextPlayedFloorType & "]")
                CFG.NextPlayedFloorType = NewFloorTtype
                BOTRes.ClickElement(String.Format("HARDTOWER_TYPE{0}_FLOOR{1}", CFG.NextPlayedFloorType, CFG.NextPlayedFloorTypeIndex))
                If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
                    Log("Cant get inside any floor type... Check if your game is not bugged or ask for help on BOT forum.")
                    CFG.NextPlayedFloorType = ""
                    CFG.Save()
                    BackToMainScreen()
                    Return
                End If
            End If
        Else
            Log(String.Format("Playing Tower Clim: Floor type = [{0}], Floor index = [{1}], Sub floor = [{2}]", CFG.NextPlayedFloorType, CFG.NextPlayedFloorTypeIndex, CFG.NextPlayedSubFloor))
            If CFG.LastPlayedFloorTypeIndex = 5 AndAlso CFG.LastPlayedSubFloor = 5 Then
                Log("Last round was played the last floor, bot will now scroll up to search next floor...")
                'Scroll up floors
                Using bs As Emulator = GetEmulator()
                    bs.MouseLeftDrag(480, 75, 480, 490)
                End Using
                Threading.Thread.Sleep(1000)

                CFG.NextPlayedFloorType = GetCurrentFloorType(FloorPos)
                If CFG.NextPlayedFloorType = "" Then
                    Log("Fail to detect tower floor")
                    CFG.NextPlayedFloorType = ""
                    CFG.Save()
                    BackToMainScreen()
                    Return
                End If

                Log("Next floor detected as [" & CFG.NextPlayedFloorType & "]")
                Using bs As Emulator = GetEmulator()
                    bs.MouseLeftClick(FloorPos)
                End Using
                Threading.Thread.Sleep(1000)

                If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
                    Log("Cant get inside tower floor, something went wrong while scrolling screen.")
                    CFG.NextPlayedFloorType = ""
                    CFG.Save()
                    BackToMainScreen()
                    Return
                End If

            Else
                'Just climb up
                BOTRes.ClickElement(String.Format("HARDTOWER_TYPE{0}_FLOOR{1}", CFG.NextPlayedFloorType, CFG.NextPlayedFloorTypeIndex))
                If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
                    Dim NewFloorTtype As String = ""
                    If CFG.NextPlayedFloorType = "A" Then NewFloorTtype = "B" Else NewFloorTtype = "A"
                    Log("Cant get inside tower floor, maybe is not parked at floor type [" & CFG.NextPlayedFloorType & "], trying swap to [" & CFG.NextPlayedFloorType & "]")
                    CFG.NextPlayedFloorType = NewFloorTtype
                    BOTRes.ClickElement(String.Format("HARDTOWER_TYPE{0}_FLOOR{1}", CFG.NextPlayedFloorType, CFG.NextPlayedFloorTypeIndex))
                    If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
                        Log("Cant get inside any floor type... Check if your game is not bugged or ask for help on BOT forum. Reset floor cache, next round will start from bottom floor.")
                        CFG.NextPlayedFloorType = ""
                        CFG.Save()
                        BackToMainScreen()
                        Return
                    End If
                End If

            End If
        End If

        If Not BOTRes.DetectWait("HARD_TOWER_INSIDE_FLOOR", 5) Then
            Log("BOT is not inside tower, something went very wrong, sorry.")
            CFG.NextPlayedFloorType = ""
            CFG.Save()
            BackToMainScreen()
            Return
        End If

        Dim FloorText As String = ""
        Using bs As Emulator = GetEmulator()
            FloorText = BitmapTools.OCRText(bs.GetBuffer.ToBitmap, Rectangle.FromLTRB(407, 8, 550, 35))
        End Using
        Log("Inside Floor: " & FloorText)
        Log("Playing sub-floor: " & CFG.NextPlayedSubFloor)
        BOTRes.ClickElement("HARD_TOWER_SUBFLOOR_" & CFG.NextPlayedSubFloor)
        Threading.Thread.Sleep(1000)

        BOTRes.ClickElement("TOWER_REPEAT_INSIDE")
        If Not InTowerRepeatWindow() Then Return
        Threading.Thread.Sleep(1000)

        If CFG.AutoTower_QuickBattle Then
            Log("Using quick battle coupons")
            BOTRes.ClickElement("TOWER_REPEAT_QUICKBATTLE")
            Threading.Thread.Sleep(1000)
            BOTRes.ClickElement("TOWER_REPEAT_OK")
            Threading.Thread.Sleep(1000)
            BOTRes.ClickElement("TOWER_REPEAT_AUTOSELL_SAVE")
        Else
            BOTRes.ClickElement("TOWER_REPEAT_OK")
        End If

        If BOTRes.DetectWait("IN_BATTLE", 60) Then
            Log("Battle started!")
        Else
            Log("Battle failed to start... Game may be bugged or your internet connection is weak")
            Return
        End If

        CFG.LastPlayedFloor = CFG.NextPlayedFloor
        CFG.LastPlayedFloorType = CFG.NextPlayedFloorType
        CFG.LastPlayedFloorTypeIndex = CFG.NextPlayedFloorTypeIndex
        CFG.LastPlayedSubFloor = CFG.NextPlayedSubFloor

        If CFG.NextPlayedSubFloor = 5 Then
            CFG.NextPlayedSubFloor = 1
            If CFG.NextPlayedFloorTypeIndex = 5 Then
                CFG.NextPlayedFloorTypeIndex = 1
                If CFG.NextPlayedFloorType = "A" Then
                    CFG.NextPlayedFloorType = "B"
                Else
                    CFG.NextPlayedFloorType = "A"
                End If
            Else
                CFG.NextPlayedFloorTypeIndex += 1
            End If
        Else
            CFG.NextPlayedSubFloor += 1
        End If
        CFG.Save()

        Dim LastExpRead As Stopwatch = Stopwatch.StartNew
        Dim Exp As Long = 0
        Do
            If IsTowerRepeatFinish() Then Exit Do
            Threading.Thread.Sleep(100)
            LongLoopsDenny()

            If LastExpRead.Elapsed.TotalSeconds > 30 Then
                If IsVictory(Exp) Then
                    If Exp <> -1 Then
                        LastBOTAction = Stopwatch.StartNew
                        NumFights += 1
                        Log("Victory! Exp earned = " & Exp)
                        ExpEarned += Exp
                        Exp = 0
                        LastExpRead = Stopwatch.StartNew
                        Threading.Thread.Sleep(5000)
                    End If
                End If
            End If
            If InMainScreen() Then Return
            Threading.Thread.Sleep(250)
        Loop

        Threading.Thread.Sleep(1000)

        'Click ok for repeat battle result
        BOTRes.ClickElement("TOWER_AUTO_FINISH_OK")
        Log("Auto tower session finished...")

        BackToMainScreen()
        Dim Gold As Long = GetGold()
        If Gold >= 0 Then
            If StartGold = -1 Then
                StartGold = Gold
            End If
            CurrentGold = Gold

            Log("Gold earned since BOT start = " & (CurrentGold - StartGold))
            Log("Exp earned since BOT start = " & ExpEarned)
        End If
        BackToMainScreen()

    End Sub

    Function GetCurrentFloorType(ByRef FloorPos As Point) As String
        Dim Pos As Rectangle = Rectangle.Empty
        Dim fPos As Point = Point.Empty
        Dim Idx As Integer = BOTRes.DetectMultipleWait(New String() {"HARD_TOWER_MARKUP_00", "HARD_TOWER_MARKUP_01"}, 20, Pos)
        If Idx = -1 Then
            FloorPos = fPos
            Return ""
        End If

        If Idx = 0 Then
            fPos = New Point(Pos.Left + Pos.Width + 30, Pos.Top + (Pos.Height / 2))
            FloorPos = fPos
            Return "B"
        ElseIf Idx = 1 Then
            fPos = New Point(Pos.Left + Pos.Width + 30, Pos.Top + (Pos.Height / 2))
            FloorPos = fPos
            Return "A"
        End If

        FloorPos = fPos
        Return ""
    End Function
End Module
