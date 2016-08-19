Public Class AdvancedHireFuse
    Private Property AnimationBug As Boolean = True
    Private Property ExtractEssence As Boolean = True
    Private Property SixStarCount As Integer = 0
    Private Property BugActivated As Boolean = False
    Private ThreadProcess As Threading.Thread

    Private Sub AdvancedHireFuse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not InMainScreen() Then
            MsgBox("Failed to detect main screen!", MsgBoxStyle.Critical)
            Me.Close()
            Return
        End If
    End Sub

    Sub HireLog(ByVal Msg As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New DelLog(AddressOf HireLog), Msg)
        Else
            Dim MsgFinal As String = Now.ToString("HH:mm:ss") & " - " & Msg
            txtLog.AppendText(MsgFinal & Environment.NewLine)
            txtLog.SelectionStart = BotWnd.txtLog.Text.Length
            txtLog.SelectionLength = 0
            txtLog.ScrollToCaret()
            Application.DoEvents()
        End If
    End Sub

    Public Function Hire() As Boolean
        Dim SW As Stopwatch = Stopwatch.StartNew

        LastBOTAction = Stopwatch.StartNew
        HireLog("Opening hire window")
        If Not OpenHireWindow() Then Return False

        Dim TicketPos As Point = Hire_GetTicketPosition()
        If Not TicketPos.IsEmpty Then
            HireLog("Using ticket")

            Dim X As Integer = 875
            Dim Y As Integer = TicketPos.Y
            GetEmulatorStatic.MouseLeftClick(X, Y)

            SW = Stopwatch.StartNew
            Do
                If InUseTicketWindow() Then Exit Do
                If SW.Elapsed.TotalSeconds > 5 Then
                    HireLog("Failed to use ticket, maybe slow internet!?")
                    BOTRes.DetecAndClick("CLOSE_POPUP")
                    Return False
                End If
            Loop

            Dim Coords As New Dictionary(Of String, Integer)
            Dim PT As Point = BOTRes.GetElementPoint("USE_TICKET_WINDOW_USE_BUTTON")
            If PT.IsEmpty Then
                HireLog("BOT missing configuration. Redownload BOT please")
                BOTRes.DetecAndClick("CLOSE_POPUP")
                Return False
            End If

            Coords.Add("X", PT.X)
            Coords.Add("Y", PT.Y)
            Dim THClick As New Threading.Thread(AddressOf CrazyClicks)
            THClick.Start(Coords)

            HireLog("Boosting hire!")
            Do While Not InHireWindow()
                Threading.Thread.Sleep(1000)
            Loop
            HireLog("Hire done!")
            THClick.Abort()
            BOTRes.DetecAndClick("CLOSE_POPUP")
        Else
            HireLog("No tickets available")
            BOTRes.DetecAndClick("CLOSE_POPUP")
            Return False
        End If

        Return True
    End Function

    Sub CrazyClicks(o As Object)
        Try
            Dim x As Integer = CType(o, Dictionary(Of String, Integer))("X")
            Dim y As Integer = CType(o, Dictionary(Of String, Integer))("Y")

            Do
                StaticEmulator.MouseLeftClick(x, y)
                Threading.Thread.Sleep(200)
            Loop
        Catch ex As Exception

        End Try
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

    Function Fuse() As Boolean
        HireLog("Opening fuse window")
        If Not OpenFuseWindow() Then
            HireLog("Failed to open fuse window")
            Return False
        End If

        If AnimationBug And Not ActivateFuseBug() Then
            HireLog("Failed to activate animation bug...")
            BOTRes.DetecAndClick("CLOSE_POPUP")
            Return False
        End If

        BOTRes.DetecAndClick("CLOSE_POPUP")
        Return True
    End Function

    Function ActivateFuseBug() As Boolean
        If BugActivated Then Return True
        If Not OpenFuseWindow() Then Return False


    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        StaticEmulator.SendKeys("{ESC}")

        'AnimationBug = chkAnimation.Checked
        'ExtractEssence = chkExtract.Checked

        'ThreadProcess = New Threading.Thread(AddressOf THProcess)
        'ThreadProcess.Start()
    End Sub

    Public Sub ProcessStop()
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf ProcessStop))
        Else
            btnStart.Enabled = True
            btnStop.Enabled = False
            chkAnimation.Enabled = True
            chkExtract.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub

    Public Sub ProcessStart()
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf ProcessStart))
        Else
            btnStart.Enabled = False
            btnStop.Enabled = True
            chkAnimation.Enabled = False
            chkExtract.Enabled = False
            btnClose.Enabled = False
        End If
    End Sub

    Public Sub THProcess()
        Try
            HireLog("Initializing hire/fuse process...")
            ProcessStart()
        Catch tex As Threading.ThreadAbortException
            HireLog("Process aborted")
            ProcessStop()
            Return
        Catch ex As Exception
            HireLog("Unhandled error!")
            HireLog(ex.ToString)
            ProcessStop()
            Return
        End Try

        ProcessStop()
        HireLog("Process finished")
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If Not ThreadProcess Is Nothing Then
            If ThreadProcess.IsAlive Then
                ThreadProcess.Abort()
            End If
        End If
        ProcessStop()
    End Sub
End Class