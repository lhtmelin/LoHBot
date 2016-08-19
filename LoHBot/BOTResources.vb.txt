Imports System.Threading

Public Class BOTResources
    Public Property ClickableResources As New Dictionary(Of String, Point)
    Public Property DetectableResources As New Dictionary(Of String, List(Of String))
    Public Property DetectableResourcesFast As New Dictionary(Of String, List(Of Point))
    Public Property ColorCheckResources As New Dictionary(Of String, ColorCheck)

    Private DetectableResourcesFastColor As New Dictionary(Of String, List(Of Color))

    Private Class MultiProcDetect
        Public Property Fullimage As Image(Of Bgr, Byte)
        Public Property TemplateImage As Image(Of Bgr, Byte)
        Public Property DetectResult As Boolean
        Public Property Similarity As Single
        Public Property ThreadEvent As ManualResetEvent
    End Class

    Public Class ColorCheck
        Public Enum enOperation
            AvgColor = 1
            SumColor = 2
            AvgBrightness = 3
        End Enum
        Public Property SelectedValue As Long
        Public Property Operation As enOperation
        Public Property Condition As String
        Public Property ConditionValue As Long
        Public Property Area As Rectangle
    End Class

    Private Class SuccessRate
        Public Property TryCnt As Long
        Public Property SuccessCnt As Long
        Public Property SuccessRate As Single
    End Class

    Private Cache As New Dictionary(Of String, Image(Of Bgr, Byte))
    Private SuccessCheck As New Dictionary(Of String, SuccessRate)

    Public Sub Save(Filename As String)
        IO.File.WriteAllText(Filename, Newtonsoft.Json.JsonConvert.SerializeObject(Me, Newtonsoft.Json.Formatting.Indented), System.Text.Encoding.UTF8)
    End Sub
    Public Sub Save()
        Dim Filename As String = IO.Path.Combine(ResourcesPath, "Resources.conf")
        Save(Filename)
    End Sub

    Public Sub Load()
        Dim Filename As String = IO.Path.Combine(ResourcesPath, "Resources.conf")
        Load(Filename)
    End Sub
    Public Sub Load(Filename As String)
        If Not IO.File.Exists(Filename) Then Return
        Dim o As BOTResources = Newtonsoft.Json.JsonConvert.DeserializeObject(IO.File.ReadAllText(Filename, System.Text.Encoding.UTF8), GetType(BOTResources))

        Dim t As Type = GetType(BOTResources)
        For Each p As System.Reflection.FieldInfo In t.GetFields(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.Instance)
            p.SetValue(Me, p.GetValue(o))
        Next
    End Sub

    Public Function DetectColor(Name As String) As Boolean
        If Not ColorCheckResources.ContainsKey(Name) Then Return False
        Dim c As ColorCheck = ColorCheckResources(Name)
        Dim Ret As Boolean = False

        Using bs As Emulator = GetEmulator()
            Dim v As Long
            If c.Operation = ColorCheck.enOperation.AvgColor Then v = BitmapTools.AvgColor(bs.GetBuffer.Bitmap, c.Area)
            If c.Operation = ColorCheck.enOperation.SumColor Then v = BitmapTools.SumColor(bs.GetBuffer.Bitmap, c.Area)
            If c.Operation = ColorCheck.enOperation.AvgBrightness Then v = BitmapTools.AvgBrightness(bs.GetBuffer.Bitmap, c.Area)

            Select Case c.Condition
                Case ">="
                    Ret = (v >= c.ConditionValue)
                Case "<="
                    Ret = (v <= c.ConditionValue)
                Case "="
                    Ret = (v >= c.ConditionValue * 0.95) And (v <= c.ConditionValue * 1.05)
            End Select
        End Using

        Return Ret
    End Function

    Public Function ClickElement(Name As String) As Boolean
        If Not ClickableResources.ContainsKey(Name) Then Return False
        GetEmulatorStatic.MouseLeftClick(ClickableResources(Name))
    End Function

    Public Function GetElementPoint(Name As String) As Point
        If Not ClickableResources.ContainsKey(Name) Then Return Point.Empty
        Return ClickableResources(Name)
    End Function

    Public Function DetectPosition(Name As String, Optional Similarity As Single = 0.85) As Rectangle
        If Not DetectableResources.ContainsKey(Name) Then Return Rectangle.Empty
        If DetectableResources(Name).Count = 0 Then Return Rectangle.Empty

        Dim Ret As Rectangle = Rectangle.Empty

        Using bs As Emulator = GetEmulator()
            Ret = DetectPosition(Name, bs, Similarity)
        End Using

        Return Ret
    End Function

    Public Function DetectPosition(Name As String, bs As Emulator, Optional Similarity As Single = 0.85) As Rectangle
        If Not DetectableResources.ContainsKey(Name) Then Return Rectangle.Empty
        If DetectableResources(Name).Count = 0 Then Return Rectangle.Empty

        Dim Ret As Rectangle = Rectangle.Empty

        For Each elem As String In DetectableResources(Name)
            Dim fName As String = IO.Path.Combine(ResourcesPath, elem & ".png")
            If IO.File.Exists(fName) Then
                Dim img As Image(Of Bgr, Byte) = GetBitmap(elem)

                Dim rect() As Rectangle = ImageRecognition.Search(bs.GetBuffer, img, Similarity)
                If rect.Length > 0 Then
                    Ret = rect(0)
                    Exit For
                End If
            End If
        Next

        Return Ret
    End Function


    Public Function Detect(Name As String, Optional Similarity As Single = 0.85) As Boolean
        If Not DetectableResources.ContainsKey(Name) Then Return False
        If DetectableResources(Name).Count = 0 Then Return False

        Dim Ret As Boolean = True

        Using bs As Emulator = GetEmulator()
            bs.GetBuffer()
            Ret = Detect(Name, bs, Similarity)
        End Using

        Return Ret
    End Function

    Public Function DetectMultiple(Name() As String, Optional Similarity As Single = 0.85) As Integer
        For Each n As String In Name
            If Not DetectableResources.ContainsKey(n) Then Return False
            If DetectableResources(n).Count = 0 Then Return False
        Next

        Dim Ret As Integer = -1

        Using bs As Emulator = GetEmulator()
            bs.GetBuffer()
            For i As Integer = 0 To Name.Length - 1
                If Detect(Name(i), bs, Similarity) Then
                    Ret = i
                    Exit For
                End If
            Next
        End Using

        Return Ret
    End Function

    Public Function DetectMultipleWait(Name() As String, TimeoutSeconds As Integer, ByRef Position As Rectangle, Optional Similarity As Single = 0.85) As Integer
        For Each n As String In Name
            If Not DetectableResources.ContainsKey(n) Then Return False
            If DetectableResources(n).Count = 0 Then Return False
        Next

        Dim Ret As Integer = -1

        Dim SW As Stopwatch = Stopwatch.StartNew

        Do While SW.Elapsed.TotalSeconds < TimeoutSeconds And Ret = -1
            Using bs As Emulator = GetEmulator()
                bs.GetBuffer()
                For i As Integer = 0 To Name.Length - 1
                    Dim Rect As Rectangle = DetectPosition(Name(i), bs, Similarity)
                    If Rect <> Rectangle.Empty Then
                        Position = Rect
                        Ret = i
                        Exit For
                    End If
                Next
            End Using
        Loop

        Return Ret
    End Function


    Private Sub DetectThreadCallback(context As Object)
        Dim mp As MultiProcDetect = context

        Dim rect() As Rectangle = ImageRecognition.Search(mp.Fullimage, mp.TemplateImage, mp.Similarity)
        mp.DetectResult = (rect.Length > 0)

        mp.ThreadEvent.Set()
    End Sub

    Public Function Detect(Name As String, bs As IEmulator, Optional Similarity As Single = 0.85) As Boolean
        If Not DetectableResources.ContainsKey(Name) Then Return False
        If DetectableResources(Name).Count = 0 Then Return False

        Dim Ret As Boolean = True

        bs.GetBuffer()

        If CFG.EnableFastImageDetection AndAlso SuccessCheck.ContainsKey(Name) AndAlso SuccessCheck(Name).TryCnt >= 10 AndAlso SuccessCheck(Name).SuccessRate = 1 Then
            Ret = DoFastCheck(Name, bs)
        Else
            If DetectableResources(Name).Count = 1 Then
                'Do single detect
                For Each elem As String In DetectableResources(Name)
                    Dim fName As String = IO.Path.Combine(ResourcesPath, elem & ".png")
                    If Not IO.File.Exists(fName) Then
                        Ret = False
                    Else
                        Dim img As Image(Of Bgr, Byte) = GetBitmap(elem)

                        Dim rect() As Rectangle = ImageRecognition.Search(bs.GetBuffer, img, Similarity)
                        If rect.Length = 0 Then Ret = False

                    End If

                    If Ret = False Then Exit For
                Next
            Else
                'Do multitask detect
                Dim doneEvents As New List(Of ManualResetEvent)
                Dim multiProc As New List(Of MultiProcDetect)
                For Each elem As String In DetectableResources(Name)
                    Dim mp As New MultiProcDetect
                    Dim mre As New ManualResetEvent(False)

                    mp.Fullimage = bs.GetBuffer
                    mp.TemplateImage = GetBitmap(elem)
                    mp.DetectResult = False
                    mp.ThreadEvent = mre
                    mp.Similarity = Similarity

                    multiProc.Add(mp)
                    doneEvents.Add(mre)

                    ThreadPool.QueueUserWorkItem(AddressOf DetectThreadCallback, mp)
                Next

                For Each e As ManualResetEvent In doneEvents
                    e.WaitOne()
                Next

                Ret = True
                For Each mp As MultiProcDetect In multiProc
                    If mp.DetectResult = False Then
                        Ret = False
                        Exit For
                    End If
                Next
            End If

            If CFG.EnableFastImageDetection AndAlso Ret Then
                Dim RetFast As Boolean = DoFastCheck(Name, bs)
                If Not SuccessCheck.ContainsKey(Name) Then
                    SuccessCheck.Add(Name, New SuccessRate)
                    SuccessCheck(Name).TryCnt = 0
                    SuccessCheck(Name).SuccessRate = 0
                    SuccessCheck(Name).SuccessCnt = 0
                End If

                If RetFast Then
                    SuccessCheck(Name).TryCnt += 1
                    SuccessCheck(Name).SuccessCnt += 1
                    SuccessCheck(Name).SuccessRate = SuccessCheck(Name).SuccessCnt / SuccessCheck(Name).TryCnt
                Else
                    SuccessCheck(Name).TryCnt += 1
                    SuccessCheck(Name).SuccessCnt += 0
                    SuccessCheck(Name).SuccessRate = SuccessCheck(Name).SuccessCnt / SuccessCheck(Name).TryCnt
                End If
            End If
        End If

        Return Ret
    End Function

    Private Function DoFastCheck(Name As String, bs As IEmulator) As Boolean
        If Not DetectableResourcesFast.ContainsKey(Name) Then Return False
        If DetectableResourcesFast(Name) Is Nothing Then Return False
        If DetectableResourcesFast(Name).Count = 0 Then Return False

        Dim clrs As New List(Of Color)

        For i As Integer = 0 To DetectableResourcesFast(Name).Count - 1
            Dim pt As Point = DetectableResourcesFast(Name)(i)
            Dim clr As Color = Color.FromArgb(bs.GetBuffer.Item(pt.Y, pt.X).Red, bs.GetBuffer.Item(pt.Y, pt.X).Green, bs.GetBuffer.Item(pt.Y, pt.X).Blue)
            clrs.Add(clr)

            If Not DetectableResourcesFastColor.ContainsKey(Name) Then
                DetectableResourcesFastColor.Add(Name, New List(Of Color))
            End If
        Next

        If clrs.Count <> DetectableResourcesFastColor(Name).Count Then
            DetectableResourcesFastColor(Name).Clear()
            DetectableResourcesFastColor(Name).AddRange(clrs)
        End If

        Return CheckColor(bs.GetBuffer, DetectableResourcesFast(Name).ToArray, DetectableResourcesFastColor(Name).ToArray)
    End Function


    Private Function CheckColor(ByVal Coords() As Point, ByVal Colors() As Color) As Boolean
        If Coords.Length <> Colors.Length Then Return False

        Dim Ret As Boolean = False

        Dim ok_cnt As Integer = 0
        Using bs As Emulator = GetEmulator()
            Ret = CheckColor(bs.GetBuffer, Coords, Colors)
        End Using
        Return Ret
    End Function

    Private Function CheckColor(Pic As Image(Of Bgr, Byte), ByVal Coords() As Point, ByVal Colors() As Color) As Boolean
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

    Public Function DetectWait(Name As String, TimeoutSeconds As Integer, Optional Similarity As Single = 0.85) As Boolean
        Dim SW As Stopwatch = Stopwatch.StartNew
        Dim Ret As Boolean = False
        Do
            If Detect(Name, Similarity) Then
                Ret = True
                Exit Do
            End If
            If SW.Elapsed.TotalSeconds > TimeoutSeconds Then Exit Do
        Loop
        Return Ret
    End Function

    Public Function DetecAndClick(Name As String, Optional Similarity As Single = 0.85) As Boolean
        If Not DetectableResources.ContainsKey(Name) Then Return False
        If DetectableResources(Name).Count = 0 Then Return False

        Dim Ret As Boolean = True
        Dim PtClick As Point = Point.Empty

        Using bs As Emulator = GetEmulator()
            For Each elem As String In DetectableResources(Name)
                Dim fName As String = IO.Path.Combine(ResourcesPath, elem & ".png")
                If Not IO.File.Exists(fName) Then
                    Ret = False
                Else
                    Dim img As Image(Of Bgr, Byte) = GetBitmap(elem)

                    Dim rect() As Rectangle = ImageRecognition.Search(bs.GetBuffer, img, Similarity)
                    If rect.Length = 0 Then
                        Ret = False
                    Else
                        PtClick = New Point(rect(0).Left + (rect(0).Width / 2), rect(0).Top + (rect(0).Height / 2))
                        Ret = True
                    End If

                End If

                If Ret = False Then Exit For
            Next
        End Using

        If Ret AndAlso Not PtClick.IsEmpty Then
            GetEmulatorStatic.MouseLeftClick(PtClick)
        End If

        Return Ret
    End Function

    Public Function DetecWaitAndClick(Name As String, TimeoutSeconds As Integer, Optional Similarity As Single = 0.85) As Boolean
        If Not DetectableResources.ContainsKey(Name) Then Return False
        If DetectableResources(Name).Count = 0 Then Return False

        Dim Ret As Boolean = True
        Dim PtClick As Point = Point.Empty

        Dim SW As Stopwatch = Stopwatch.StartNew
        Do
            Using bs As Emulator = GetEmulator()
                For Each elem As String In DetectableResources(Name)
                    Dim fName As String = IO.Path.Combine(ResourcesPath, elem & ".png")
                    If Not IO.File.Exists(fName) Then
                        Ret = False
                    Else
                        Dim img As Image(Of Bgr, Byte) = GetBitmap(elem)

                        Dim rect() As Rectangle = ImageRecognition.Search(bs.GetBuffer, img, Similarity)
                        If rect.Length = 0 Then
                            Ret = False
                        Else
                            PtClick = New Point(rect(0).Left + (rect(0).Width / 2), rect(0).Top + (rect(0).Height / 2))
                            Ret = True
                        End If

                    End If

                    If Ret = False Then Exit For
                Next
            End Using

            If SW.Elapsed.TotalSeconds > TimeoutSeconds Then
                Ret = False
                Exit Do
            End If

            If Ret Then Exit Do
        Loop

        If Ret AndAlso Not PtClick.IsEmpty Then
            GetEmulatorStatic.MouseLeftClick(PtClick)
        End If

        Return Ret
    End Function

    Public Function GetBitmap(ElemName As String) As Image(Of Bgr, Byte)
        If Cache.ContainsKey(ElemName) Then
            Return Cache(ElemName)
        Else
            Dim fName As String = IO.Path.Combine(ResourcesPath, ElemName & ".png")
            Cache.Add(ElemName, New Image(Of Bgr, Byte)(fName))
            Return Cache(ElemName)
        End If
    End Function

    Public Sub RemoveFromCache(ElemName As String)
        If Cache.ContainsKey(ElemName) Then
            Cache(ElemName).Dispose()
            Cache.Remove(ElemName)
        End If
    End Sub

End Class
