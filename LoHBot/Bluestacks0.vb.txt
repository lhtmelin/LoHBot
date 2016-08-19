Imports LoHBot

Public Class Bluestacks0
    Implements IEmulator, IDisposable

    Dim BaseBitmap As Bitmap = Nothing
    Dim BaseManagedBitmap As Image(Of Bgr, Byte) = Nothing
    Private Sub Release()
        If Not BaseBitmap Is Nothing Then
            BaseBitmap.Dispose()
            BaseBitmap = Nothing

            BaseManagedBitmap.Dispose()
            BaseManagedBitmap = Nothing
        End If
    End Sub

    'Kill LOH = hd-adb shell am force-stop com.nexonm.loh.usios
    'Check LOH = hd-adb shell dumpsys window windows| findstr com.nexonm.loh.usios
    'Start LOH = hd-adb shell am start -n com.nexonm.loh.usios/com.nexonm.loh.usios.AndroidAPI
    'Android status = hd-adb shell dumpsys power
    'error: device not found

    Public ReadOnly Property Version As Version Implements IEmulator.Version
        Get

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

            Return Ret
        End Get
    End Property

    Public Sub FixEmulatorResolution() Implements IEmulator.FixEmulatorResolution
        Try
            Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\Guests\Android\FrameBuffer\0\", True)
                K.SetValue("WindowWidth", 960, Microsoft.Win32.RegistryValueKind.DWord)
                K.SetValue("GuestWidth", 960, Microsoft.Win32.RegistryValueKind.DWord)

                K.SetValue("WindowHeight", 600, Microsoft.Win32.RegistryValueKind.DWord)
                K.SetValue("GuestHeight", 600, Microsoft.Win32.RegistryValueKind.DWord)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub MouseLeftClick(pt As Point) Implements IEmulator.MouseLeftClick
        Me.MouseLeftClick(pt.X, pt.Y)
    End Sub

    Public Sub MouseLeftClick(x As Integer, y As Integer) Implements IEmulator.MouseLeftClick
        Dim handle As IntPtr = Me.GetBluestacksWindow()
        Dim lParam As IntPtr = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
        Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
        Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)
    End Sub

    Public Sub MouseLeftDrag(start As Point, [end] As Point, Optional WaitDropTime As Integer = 0) Implements IEmulator.MouseLeftDrag
        MouseLeftDrag(start.X, start.Y, [end].X, [end].Y, WaitDropTime)
    End Sub

    Public Sub MouseLeftDrag(x_start As Integer, y_start As Integer, x_end As Integer, y_end As Integer, Optional WaitDropTime As Integer = 0) Implements IEmulator.MouseLeftDrag
        Dim abs_delta_x As Integer = Math.Abs(x_end - x_start)
        Dim abs_delta_y As Integer = Math.Abs(y_end - y_start)
        Dim step_direction As Integer = 0

        Dim handle As IntPtr = Me.GetBluestacksWindow()
        Dim lParam As IntPtr

        Dim delta_z As Single = 0
        If abs_delta_x > abs_delta_y Then

            delta_z = Convert.ToSingle(abs_delta_y) / Convert.ToSingle(abs_delta_x)

            Dim stp As Integer = (abs_delta_x / 100)
            If stp < 1 Then stp = 1

            If x_start > x_end Then
                step_direction = stp * -1
            Else
                step_direction = stp * 1
            End If

            Dim i As Integer = 0
            Dim y As Integer = 0
            Dim x As Integer = 0
            For x = x_start To x_end Step step_direction
                If y_start > y_end Then
                    y = y_start - (i * delta_z)
                Else
                    y = y_start + (i * delta_z)
                End If

                lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
                Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
                Threading.Thread.Sleep(15)

                i += 1

                Application.DoEvents()
            Next

            If WaitDropTime <> 0 Then
                Threading.Thread.Sleep(WaitDropTime * 1000)
            End If
            lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
            Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

        Else
            delta_z = Convert.ToSingle(abs_delta_x) / Convert.ToSingle(abs_delta_y)

            Dim stp As Integer = (abs_delta_y / 100)
            If stp < 1 Then stp = 1

            If y_start > y_end Then
                step_direction = stp * -1
            Else
                step_direction = stp * 1
            End If

            Dim i As Integer = 0
            Dim x As Integer = 0
            Dim y As Integer = 0
            For y = y_start To y_end Step step_direction
                If x_start > x_end Then
                    x = x_start - (i * delta_z)
                Else
                    x = x_start + (i * delta_z)
                End If

                lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
                Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
                Threading.Thread.Sleep(15)

                i += 1
                Application.DoEvents()
            Next

            If WaitDropTime <> 0 Then
                Threading.Thread.Sleep(WaitDropTime * 1000)
            End If
            lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
            Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

        End If
    End Sub

    Public Function GetBuffer() As Image(Of Bgr, Byte) Implements IEmulator.GetBuffer

        If Not BaseManagedBitmap Is Nothing Then Return BaseManagedBitmap
        Dim handle As IntPtr = GetBluestacksWindow()

        Try
            Dim MustEnableComp As Boolean = False

            If DWM.DwmIsCompositionEnabled Then
                MustEnableComp = True
                DWM.DwmEnableComposition(DWM.CompositionAction.DWM_EC_DISABLECOMPOSITION)
            End If

            Dim hdcSrc As IntPtr = User32.GetWindowDC(handle)
            Dim windowRect As New User32.RECT()
            Dim clientRect As New User32.RECT

            User32.GetWindowRect(handle, windowRect)
            User32.GetClientRect(handle, clientRect)

            Dim wr As Rectangle = Rectangle.FromLTRB(windowRect.left, windowRect.top, windowRect.right, windowRect.bottom)
            Dim cr As Rectangle = Rectangle.FromLTRB(clientRect.left, clientRect.top, clientRect.right, clientRect.bottom)

            Dim border As Integer = (wr.Width - cr.Width) / 2
            Dim caption As Integer = (wr.Height - cr.Height) - (border * 2)

            Dim cl As New Rectangle(border, caption + border, cr.Width, cr.Height)

            Dim width As Integer = cl.Width 'windowRect.right - windowRect.left
            Dim height As Integer = cl.Height 'windowRect.bottom - windowRect.top
            Dim hdcDest As IntPtr = GDI32.CreateCompatibleDC(hdcSrc)
            Dim hBitmap As IntPtr = GDI32.CreateCompatibleBitmap(hdcSrc, width, height)
            Dim hOld As IntPtr = GDI32.SelectObject(hdcDest, hBitmap)
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, cl.X, cl.Y, GDI32.SRCCOPY)
            GDI32.SelectObject(hdcDest, hOld)
            GDI32.DeleteDC(hdcDest)
            User32.ReleaseDC(handle, hdcSrc)

            BaseBitmap = Image.FromHbitmap(hBitmap)
            GDI32.DeleteObject(hBitmap)

            If MustEnableComp Then
                DWM.DwmEnableComposition(DWM.CompositionAction.DWM_EC_ENABLECOMPOSITION)
            End If

            If BaseBitmap.PixelFormat <> Imaging.PixelFormat.Format24bppRgb Then
                Dim TmpBitmap As New Bitmap(BaseBitmap.Width, BaseBitmap.Height, Imaging.PixelFormat.Format24bppRgb)
                Using g As Graphics = Graphics.FromImage(TmpBitmap)
                    g.DrawImage(BaseBitmap, 0, 0)
                End Using
                BaseBitmap.Dispose()
                BaseBitmap = Nothing
                BaseBitmap = TmpBitmap
            End If

            BaseManagedBitmap = New Image(Of Bgr, Byte)(BaseBitmap)
            Return BaseManagedBitmap
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function GetEmulatorResolution() As Point Implements IEmulator.GetEmulatorResolution
        Dim BSHWnd As IntPtr = Me.GetBluestacksWindow()
        Dim RectAPI As User32.RECT
        User32.GetClientRect(BSHWnd, RectAPI)
        Dim Rect As Rectangle = Rectangle.FromLTRB(RectAPI.left, RectAPI.top, RectAPI.right, RectAPI.bottom)

        Return New Point(Rect.Width, Rect.Height)
    End Function

    Public Function IsEmulatorResolutionCorrect() As Boolean Implements IEmulator.IsEmulatorResolutionCorrect
        Dim EmuRest As Point = Me.GetEmulatorResolution()
        Return (EmuRest.X = 960 And EmuRest.Y = 600)
    End Function

    Public Function IsEmulatorRunning() As Boolean Implements IEmulator.IsEmulatorRunning
        If (Me.GetBluestacksWindow() = 0) Then
            Return False
        End If
        Dim Data As String = ""
        If RunADB("shell dumpsys power", Data) Then
            Return Data.Contains("mScreenOn=true")
        Else
            Return False
        End If
    End Function

    Public Function IsGameRunning() As Boolean Implements IEmulator.IsGameRunning
        If Not IsEmulatorRunning() Then Return False
        Dim Data As String = ""
        If RunADB("shell dumpsys activity", Data) Then
            If Data.Contains("ACTIVITY MANAGER RUNNING PROCESSES (dumpsys activity processes)") Then
                Dim Linhas As New List(Of String)
                Linhas.AddRange(Data.Split(vbCrLf))

                Dim Process As Boolean = False
                For Each l As String In Linhas
                    If l.Contains("ACTIVITY MANAGER RUNNING PROCESSES (dumpsys activity processes)") Then Process = True

                    If Process Then
                        If l.Contains("fore") And l.Contains("Proc") And l.Contains("com.nexonm.loh.usios") Then
                            Return True
                        End If
                    End If
                Next
            End If
        End If
        Return False

    End Function

    Public Function StartEmulator() As Boolean Implements IEmulator.StartEmulator
        If IsEmulatorRunning() Then Return True

        Try
            Dim BSPath As String = ""
            Dim BSBin As String = ""

            Try
                Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\")
                    BSPath = K.GetValue("DataDir", "")
                    BSBin = K.GetValue("InstallDir", "")
                End Using

                BSPath = IO.Path.Combine(BSPath, "UserData\Library\My Apps\Legion of Heroes.lnk")
                BSBin = IO.Path.Combine(BSBin, "HD-StartLauncher.exe")
                If IO.File.Exists(BSBin) Then
                    Dim p As Process = Process.Start(BSBin)

                    Dim SW As Stopwatch = Stopwatch.StartNew
                    Do While Me.GetBluestacksWindow() = 0
                        Threading.Thread.Sleep(1000)
                        If SW.Elapsed.TotalSeconds > 30 Then Return False
                    Loop

                    If (Me.GetBluestacksWindow() = 0) Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function StartGame() As Boolean Implements IEmulator.StartGame
        If Not IsEmulatorRunning() Then
            StartEmulator()
        End If

        If IsGameRunning() Then Return True

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do While Not IsEmulatorRunning()
            Threading.Thread.Sleep(1000)
            If SW.Elapsed.TotalMinutes > 5 Then Return False
        Loop
        Threading.Thread.Sleep(2000)

        Dim Data As String = ""
        If RunADB("shell am start -n com.nexonm.loh.usios/com.nexonm.loh.usios.AndroidAPI", Data) Then
            If Not IsGameRunning() Then
                Threading.Thread.Sleep(5000)
                RunADB("shell am start -n com.nexonm.loh.usios/com.nexonm.loh.usios.AndroidAPI", Data)
                Return IsGameRunning()
            Else
                Return True
            End If
        End If
        Return False
    End Function

    Public Function StopEmulator() As Boolean Implements IEmulator.StopEmulator
        KillProcessbyName("HD-Adb")
        KillProcessbyName("HD-Agent")
        KillProcessbyName("HD-BlockDevice")
        KillProcessbyName("HD-FrontEnd")
        KillProcessbyName("HD-Network")
        KillProcessbyName("HD-Service")
        KillProcessbyName("HD-SharedFolder")
        KillProcessbyName("HD-UpdaterService")
        KillProcessbyName("HD-LogRotatorService")
    End Function

    Public Function StopGame() As Boolean Implements IEmulator.StopGame
        Dim Data As String = ""
        Return RunADB("shell am force-stop com.nexonm.loh.usios", Data)
    End Function

    Private Sub KillProcessbyName(ByVal ProcName As String)
        On Error Resume Next
        Dim pKill As New List(Of Process)
        For Each p As Process In Process.GetProcesses
            If p.ProcessName.ToUpper = ProcName.ToUpper Then
                pKill.Add(p)
            End If
        Next

        For Each p As Process In pKill
            p.Kill()
        Next
    End Sub

    Private Function GetBluestacksWindow() As IntPtr
        Return User32.FindWindowByCaption(0, "BlueStacks App Player")
    End Function

    Public Function RunADB(Command As String, ByRef ReturnData As String) As Boolean Implements IEmulator.RunADB
        Dim BSBin As String = ""
        Dim SecondTry As Boolean = ReturnData.Contains("error: device not found")
        Try

            Using K As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\BlueStacks\")
                BSBin = K.GetValue("InstallDir", "")
            End Using

            If IO.File.Exists(IO.Path.Combine(BSBin, "HD-Adb.exe")) Then

                Dim p As Process = New Process

                p.StartInfo.FileName = IO.Path.Combine(BSBin, "HD-Adb.exe")
                p.StartInfo.WorkingDirectory = BSBin

                p.StartInfo.Arguments = Command
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.CreateNoWindow = True

                p.StartInfo.UseShellExecute = False
                p.StartInfo.RedirectStandardOutput = True
                p.Start()
                ReturnData = p.StandardOutput.ReadToEnd
                p.WaitForExit(60000)

                If ReturnData.Contains("error: device not found") Or ReturnData.Trim = "" Then
                    If SecondTry Then Return False
                    KillProcessbyName("HD-Adb")
                    Return RunADB(Command, ReturnData)
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private disposedValue As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Release()
            End If
            Release()
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose, IEmulator.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function GetHWnd() As IntPtr Implements IEmulator.GetHWnd
        Return User32.FindWindowByCaption(0, "BlueStacks App Player")
    End Function

    Public Function Clone() As IEmulator Implements IEmulator.Clone
        Return New Bluestacks0
    End Function

    Public Overrides Function ToString() As String Implements IEmulator.ToString
        Return "Bluestacks0"
    End Function

    Public Sub BringToFront() Implements IEmulator.BringToFront
        Dim BSWnd As IntPtr = GetHWnd()
        User32.ShowWindow(BSWnd, User32.SW_SHOWDEFAULT)
        User32.SetForegroundWindow(BSWnd)
    End Sub

    Public Sub SendKeys(keys As String) Implements IEmulator.SendKeys
        Me.BringToFront()
        Threading.Thread.Sleep(300)
        My.Computer.Keyboard.SendKeys(keys, True)
    End Sub
End Class
