Public Class AutoAwaken
    Private THAwake As Threading.Thread
    Private Delegate Sub DelAwakeLog(txt As String)

    Private HeroName As String
    Private STR As Integer
    Private AGI As Integer
    Private VIT As Integer
    Private INT As Integer

    Private STRExtra As Integer
    Private AGIExtra As Integer
    Private VITExtra As Integer
    Private INTExtra As Integer

    Private NectarReq As Integer
    Private NectarOwn As Integer

    Private HeroPic As Bitmap

    Private ProtSTR As Boolean
    Private ProtAGI As Boolean
    Private ProtVIT As Boolean
    Private ProtINT As Boolean

    Private STRVal As Integer
    Private AGIVal As Integer
    Private VITVal As Integer
    Private INTVal As Integer

    Private RingReq As Boolean

    Private ReadOnly Property IsRunning As Boolean
        Get
            If THAwake Is Nothing Then Return False
            Return THAwake.IsAlive
        End Get
    End Property

    Private Sub AutoAwaken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnRefresh.PerformClick()
    End Sub

    Sub UpdateFormData()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateFormData))
        Else
            Dim LastHeroName As String = txtName.Text

            txtName.Text = HeroName
            picHero.Image = HeroPic
            picHero.Refresh()

            If STRExtra <> 0 Then
                txtSTR.Text = STR & "(" & STRExtra & ")"
            Else
                txtSTR.Text = STR
            End If

            If AGIExtra <> 0 Then
                txtAGI.Text = AGI & "(" & AGIExtra & ")"
            Else
                txtAGI.Text = AGI
            End If

            If VITExtra <> 0 Then
                txtVIT.Text = VIT & "(" & VITExtra & ")"
            Else
                txtVIT.Text = VIT
            End If

            If INTExtra <> 0 Then
                txtINT.Text = INT & "(" & INTExtra & ")"
            Else
                txtINT.Text = INT
            End If

            txtNectarOwned.Text = NectarOwn
            txtNectarRequired.Text = NectarReq

            If LastHeroName <> txtName.Text Then
                chkRedSTR.Checked = False
                chkRedAGI.Checked = False
                chkRedVIT.Checked = True
                chkRedINT.Checked = False

                chkIncVIT.Checked = True
                udVIT.Value = 1000

                chkRing.Checked = True

                If INT <> 0 And STR <> 0 And VIT <> 0 And AGI <> 0 Then
                    If INT > STR AndAlso INT > VIT AndAlso INT > AGI Then
                        'Base INT hero
                        chkRedINT.Checked = True
                        chkIncINT.Checked = True
                        udINT.Value = 1000
                    End If

                    If AGI > STR AndAlso AGI > VIT AndAlso AGI > INT Then
                        'Base AGI hero
                        chkRedAGI.Checked = True
                        chkIncAGI.Checked = True
                        udAGI.Value = 1000
                    End If

                    If STR > INT AndAlso STR > VIT AndAlso STR > AGI Then
                        'Base STR hero
                        chkRedSTR.Checked = True
                        chkIncSTR.Checked = True
                        udSTR.Value = 1000
                    End If
                End If
            End If

            If HeroName <> "" Then btnStart.Enabled = True Else btnStart.Enabled = False

        End If
    End Sub

    Sub AwakeLog(txt As String)
        If Me.InvokeRequired Then
            Me.Invoke(New DelAwakeLog(AddressOf AwakeLog), txt)
        Else
            txtLog.AppendText(txt & Environment.NewLine)
            txtLog.SelectionStart = txtLog.Text.Length
            txtLog.SelectionLength = 0
            txtLog.ScrollToCaret()
            Application.DoEvents()
        End If
    End Sub

    Private Sub chkIncSTR_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncSTR.CheckedChanged
        udSTR.Enabled = chkIncSTR.Checked
    End Sub

    Private Sub chkIncAGI_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncAGI.CheckedChanged
        udAGI.Enabled = chkIncAGI.Checked
    End Sub

    Private Sub chkIncVIT_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncVIT.CheckedChanged
        udVIT.Enabled = chkIncVIT.Checked
    End Sub

    Private Sub chkIncINT_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncINT.CheckedChanged
        udINT.Enabled = chkIncINT.Checked
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        UpdateData()
    End Sub

    Sub UpdateData()
        Using bs As Emulator = GetEmulator()
            Dim tmp As String = ""
            Dim val1 As Integer = 0
            Dim val2 As Integer = 0
            HeroName = ""
            STR = 0
            AGI = 0
            VIT = 0
            INT = 0

            STRExtra = 0
            AGIExtra = 0
            VITExtra = 0
            INTExtra = 0

            NectarReq = 0
            NectarOwn = 0

            tmp = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(24, 77, 331, 105))
            If tmp <> "" Then
                If tmp = "Hero to Awaken" Then
                    MsgBox("Please, choose your hero and click [Refresh Hero Info] button!", MsgBoxStyle.Exclamation)
                Else
                    HeroName = tmp.Split("(")(0)
                End If

                tmp = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(300, 376, 398, 395))
                If tmp <> "" Then
                    If tmp.Contains("(") Then
                        'have extra stats
                        Dim part1 As String = tmp.Split("(")(0)
                        Dim part2 As String = tmp.Split("(")(1).Replace(")", "").Replace("+", "")

                        If Integer.TryParse(part1, val1) Then
                            STR = val1
                        End If
                        If Integer.TryParse(part2, val1) Then
                            STRExtra = val1
                        End If
                    Else
                        If Integer.TryParse(tmp, val1) Then
                            STR = val1
                        End If
                    End If
                Else
                    MsgBox("Cant read base STR. Is possible this hero is already awakened!", MsgBoxStyle.Information)
                End If

                tmp = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(300, 400, 398, 422))
                If tmp <> "" Then
                    If tmp.Contains("(") Then
                        'have extra stats
                        Dim part1 As String = tmp.Split("(")(0)
                        Dim part2 As String = tmp.Split("(")(1).Replace(")", "").Replace("+", "")

                        If Integer.TryParse(part1, val1) Then
                            AGI = val1
                        End If
                        If Integer.TryParse(part2, val1) Then
                            AGIExtra = val1
                        End If
                    Else
                        If Integer.TryParse(tmp, val1) Then
                            AGI = val1
                        End If
                    End If
                Else
                    MsgBox("Cant read base AGI. Is possible this hero is already awakened!", MsgBoxStyle.Information)
                End If

                tmp = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(300, 425, 398, 450))
                If tmp <> "" Then
                    If tmp.Contains("(") Then
                        'have extra stats
                        Dim part1 As String = tmp.Split("(")(0)
                        Dim part2 As String = tmp.Split("(")(1).Replace(")", "").Replace("+", "")

                        If Integer.TryParse(part1, val1) Then
                            VIT = val1
                        End If
                        If Integer.TryParse(part2, val1) Then
                            VITExtra = val1
                        End If
                    Else
                        If Integer.TryParse(tmp, val1) Then
                            VIT = val1
                        End If
                    End If
                Else
                    MsgBox("Cant read base VIT. Is possible this hero is already awakened!", MsgBoxStyle.Information)
                End If

                tmp = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(300, 452, 398, 470))
                If tmp <> "" Then
                    If tmp.Contains("(") Then
                        'have extra stats
                        Dim part1 As String = tmp.Split("(")(0)
                        Dim part2 As String = tmp.Split("(")(1).Replace(")", "").Replace("+", "")

                        If Integer.TryParse(part1, val1) Then
                            INT = val1
                        End If
                        If Integer.TryParse(part2, val1) Then
                            INTExtra = val1
                        End If
                    Else
                        If Integer.TryParse(tmp, val1) Then
                            INT = val1
                        End If
                    End If
                Else
                    MsgBox("Cant read base INT. Is possible this hero is already awakened!", MsgBoxStyle.Information)
                End If

                val1 = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(185, 508, 289, 528))
                If val1 <> -1 Then
                    NectarOwn = val1
                End If

                val1 = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(492, 508, 595, 528))
                If val1 <> -1 Then
                    NectarReq = val1
                End If

            Else
                MsgBox("Cant detect hero stats!", MsgBoxStyle.Critical)
            End If

            HeroPic = BitmapTools.CutImage(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(28, 120, 399, 470))

            UpdateFormData()
        End Using
    End Sub

    Sub Awake()
        AwakeLog("Starting Awake: " & HeroName)

        Dim Cond As New List(Of String)
        Dim Prot As New List(Of String)
        If STRVal <> 0 Then Cond.Add("STR >= " & STRVal)
        If AGIVal <> 0 Then Cond.Add("INT >= " & AGIVal)
        If VITVal <> 0 Then Cond.Add("VIT >= " & VITVal)
        If INTVal <> 0 Then Cond.Add("INT >= " & INTVal)

        If ProtSTR Then Prot.Add("Protect STR")
        If ProtAGI Then Prot.Add("Protect AGI")
        If ProtVIT Then Prot.Add("Protect VIT")
        If ProtINT Then Prot.Add("Protect INT")

        Dim Str As String = "(" & String.Join(" OR ", Cond.ToArray) & ")"
        If Prot.Count > 0 Then
            Str = Str & " AND (" & String.Join(" OR ", Prot.ToArray) & ")"
        End If
        AwakeLog("Stop constraint: " & Str)
        Dim Cnt As Integer = 0

        Dim ReqCnt As Integer = 0

        If STRVal <> 0 Then ReqCnt += 1
        If AGIVal <> 0 Then ReqCnt += 1
        If VITVal <> 0 Then ReqCnt += 1
        If INTVal <> 0 Then ReqCnt += 1

        Do
            Try
                Dim STRAwake As Integer = 0
                Dim AGIAwake As Integer = 0
                Dim VITAwake As Integer = 0
                Dim INTAwake As Integer = 0
                Dim RingAwake As Boolean = False

                Dim Repeat As Boolean = False
                If GetStats(STRAwake, AGIAwake, VITAwake, INTAwake, RingAwake) Then
                    Dim AwakeOKCnt As Integer = 0
                    Dim StrLog As String = ""

                    If STRAwake <> 0 Then
                        If StrLog = "" Then
                            StrLog = "STR = " & STRAwake
                        Else
                            StrLog = StrLog & ", STR = " & STRAwake
                        End If
                    End If
                    If AGIAwake <> 0 Then
                        If StrLog = "" Then
                            StrLog = "AGI = " & AGIAwake
                        Else
                            StrLog = StrLog & ", AGI = " & AGIAwake
                        End If
                    End If
                    If VITAwake <> 0 Then
                        If StrLog = "" Then
                            StrLog = "VIT = " & VITAwake
                        Else
                            StrLog = StrLog & ", VIT = " & VITAwake
                        End If
                    End If
                    If INTAwake <> 0 Then
                        If StrLog = "" Then
                            StrLog = "INT = " & INTAwake
                        Else
                            StrLog = StrLog & ", INT = " & INTAwake
                        End If
                    End If

                    If StrLog = "" Then
                        StrLog = "RING = " & RingAwake.ToString
                    Else
                        StrLog = StrLog & ", RING = " & RingAwake.ToString
                    End If
                    AwakeLog(StrLog)

                    If ProtSTR AndAlso STRAwake < 0 Then Repeat = True
                    If ProtAGI AndAlso AGIAwake < 0 Then Repeat = True
                    If ProtVIT AndAlso VITAwake < 0 Then Repeat = True
                    If ProtINT AndAlso INTAwake < 0 Then Repeat = True
                    If RingReq AndAlso Not RingAwake Then Repeat = True

                    If STRVal <> 0 AndAlso STRAwake >= STRVal Then AwakeOKCnt += 1
                    If AGIVal <> 0 AndAlso AGIAwake >= AGIVal Then AwakeOKCnt += 1
                    If VITVal <> 0 AndAlso VITAwake >= VITVal Then AwakeOKCnt += 1
                    If INTVal <> 0 AndAlso INTAwake >= INTVal Then AwakeOKCnt += 1

                    If ReqCnt <> 0 AndAlso AwakeOKCnt = 0 Then Repeat = True
                Else
                    Repeat = True
                End If

                If Not Repeat Then
                    AwakeLog("Condition success!")
                    Exit Do
                End If

                Cnt += 1
                AwakeLog("Awaken (" & Cnt & "): " & HeroName)
                BOTRes.ClickElement("AWAKEN_BUTTON")
                Threading.Thread.Sleep(4000)
            Catch thex As Threading.ThreadAbortException
                AwakeLog("Awak stop!")
                Exit Do
            Catch ex As Exception

            End Try
        Loop

        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf Backnormal))
        Else
            Me.Invoke(New MethodInvoker(AddressOf Backnormal))
        End If
    End Sub

    Function RingOpen() As Boolean
        Dim SW As Stopwatch = Stopwatch.StartNew
        Dim Ret As Boolean = False
        Do
            If SW.Elapsed.TotalSeconds > 30 Then Exit Do
            Using bs As Emulator = GetEmulator()
                Dim tmp As String = BitmapTools.OCRText(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(518, 360, 846, 381))
                If tmp <> "" Then
                    Ret = Not tmp.Trim.ToUpper.Contains("FAILED")
                    Exit Do
                End If
            End Using
        Loop
        Return Ret
    End Function

    Function GetStats(ByRef aSTR As Integer, ByRef aAGI As Integer, ByRef aVIT As Integer, ByRef aINT As Integer, ByRef aRing As Boolean) As Boolean
        Dim STRAwake As Integer = 0
        Dim AGIAwake As Integer = 0
        Dim VITAwake As Integer = 0
        Dim INTAwake As Integer = 0

        Dim Ret As Boolean = False

        aSTR = 0
        aAGI = 0
        aVIT = 0
        aINT = 0
        aRing = False



        Using bs As Emulator = GetEmulator()
            Dim tmp As Integer = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(821, 114, 917, 136))
            If tmp <> -1 Then STRAwake = tmp

            tmp = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(821, 175, 917, 198))
            If tmp <> -1 Then AGIAwake = tmp

            tmp = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(821, 236, 917, 257))
            If tmp <> -1 Then VITAwake = tmp

            tmp = BitmapTools.OCRNumeric(bs.GetBuffer.Bitmap, Rectangle.FromLTRB(821, 300, 917, 319))
            If tmp <> -1 Then INTAwake = tmp

            If STRAwake = 0 AndAlso AGIAwake = 0 AndAlso VITAwake = 0 AndAlso INTAwake = 0 Then
                Ret = False
            Else
                Ret = True
                aRing = RingOpen()

                aSTR = STRAwake
                aAGI = AGIAwake
                aVIT = VITAwake
                aINT = INTAwake
            End If
        End Using

        Return Ret
    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If Not chkIncAGI.Checked AndAlso Not chkIncINT.Checked AndAlso Not chkIncSTR.Checked AndAlso Not chkIncVIT.Checked Then
            MsgBox("Select the stat you want boost!", MsgBoxStyle.Critical)
            Return
        End If

        INTVal = 0
        STRVal = 0
        AGIVal = 0
        VITVal = 0

        ProtSTR = False
        ProtAGI = False
        ProtVIT = False
        ProtINT = False

        If chkIncAGI.Checked Then
            If udAGI.Value = 0 Then
                MsgBox("Specify then value of AGI!", MsgBoxStyle.Critical)
                Return
            Else
                AGIVal = udAGI.Value
            End If
        End If

        If chkIncSTR.Checked Then
            If udSTR.Value = 0 Then
                MsgBox("Specify then value of STR!", MsgBoxStyle.Critical)
                Return
            Else
                STRVal = udSTR.Value
            End If
        End If

        If chkIncVIT.Checked Then
            If udVIT.Value = 0 Then
                MsgBox("Specify then value of VIT!", MsgBoxStyle.Critical)
                Return
            Else
                VITVal = udVIT.Value
            End If
        End If

        If chkIncINT.Checked Then
            If udINT.Value = 0 Then
                MsgBox("Specify then value of INT!", MsgBoxStyle.Critical)
                Return
            Else
                INTVal = udINT.Value
            End If
        End If

        ProtAGI = chkRedAGI.Checked
        ProtSTR = chkRedSTR.Checked
        ProtVIT = chkRedVIT.Checked
        ProtINT = chkRedINT.Checked
        RingReq = chkRing.Checked

        Habilita(False)
        btnStart.Enabled = False
        btnStop.Enabled = True

        THAwake = New Threading.Thread(AddressOf Awake)
        THAwake.Start()

        btnStart.Enabled = False
        btnStop.Enabled = True
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Backnormal()
    End Sub

    Sub Backnormal()
        On Error Resume Next
        THAwake.Abort()
        Habilita(True)
        btnStop.Enabled = False
        btnStart.Enabled = True
    End Sub

    Sub Habilita(param As Boolean)
        For Each c As Control In gbBaseHero.Controls
            If TypeOf c Is GroupBox Then
                c.Enabled = True
            Else
                c.Enabled = param
            End If
        Next
        If param Then
            chkIncSTR_CheckedChanged(Nothing, Nothing)
            chkIncAGI_CheckedChanged(Nothing, Nothing)
            chkIncVIT_CheckedChanged(Nothing, Nothing)
            chkIncINT_CheckedChanged(Nothing, Nothing)
        End If
    End Sub
End Class