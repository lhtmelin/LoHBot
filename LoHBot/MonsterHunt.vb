Public Class MonsterHunt
    Private MOCAP As New MotionCapture

    Public Property Filter As FilterSettings
    Public Property InvalidAreas As New List(Of Rectangle)

    Private OriginalFrame As Image(Of Bgr, Byte)
    Private HSVFrame As Image(Of Bgr, Byte)
    Private MaskFrame As Image(Of Gray, Byte)
    Private FinalFrame As Image(Of Bgr, Byte)
    Private FinalMask As Image(Of Gray, Byte)

    Private Targets As New List(Of Rectangle)

    Private ForbiddenAreas As New List(Of Rectangle)

    Public Sub Update()
        Using bs As Emulator = GetEmulator()
            If Not OriginalFrame Is Nothing Then OriginalFrame.Dispose()
            OriginalFrame = bs.GetBuffer.Copy
        End Using

        If Not HSVFrame Is Nothing Then HSVFrame.Dispose()
        HSVFrame = New Image(Of Bgr, Byte)(OriginalFrame.Width, OriginalFrame.Height)
        CvInvoke.cvCvtColor(OriginalFrame, HSVFrame, CvEnum.COLOR_CONVERSION.BGR2HSV_FULL)

        If Not MaskFrame Is Nothing Then MaskFrame.Dispose()
        MaskFrame = HSVFrame.InRange(New Bgr(Filter.Hue.Min, Filter.Sat.Min, Filter.Val.Min), New Bgr(Filter.Hue.Max, Filter.Sat.Max, Filter.Val.Max))

        If Filter.Dilate Then
            MaskFrame._Dilate(Filter.DilateValue)
        End If
        If Filter.Erode Then
            MaskFrame._Erode(Filter.ErodeValue)
        End If
        If Filter.Blur Then
            If Filter.BlurValue >= 2 Then
                If Filter.BlurValue Mod 2 = 0 Then
                    MaskFrame._SmoothGaussian(Filter.BlurValue + 1)
                Else
                    MaskFrame._SmoothGaussian(Filter.BlurValue)
                End If
            End If
        End If
        If Filter.MaskCleanUp Then
            Dim TmpMask As Image(Of Gray, Byte) = MaskFrame.Resize(10, CvEnum.INTER.CV_INTER_LINEAR)
            MaskFrame.Dispose()

            TmpMask._ThresholdBinary(New Gray(127), New Gray(255))
            MaskFrame = TmpMask.Resize(OriginalFrame.Width, OriginalFrame.Height, CvEnum.INTER.CV_INTER_LINEAR)
            TmpMask.Dispose()
        End If

        With MOCAP.GetDifference(OriginalFrame.Copy(MaskFrame))
            FinalFrame = .Image
            FinalMask = .Mask

            Dim rect_mask() As Rectangle = BitmapTools.GetRectanglesFromMask(FinalMask)
            Targets.Clear()

            If rect_mask.Length > 0 Then
                For Each rect As Rectangle In rect_mask
                    Dim sz As Long = BitmapTools.AreaRectangle(rect)
                    Dim aspect_ratio As Long = GetAspectRatio(rect)
                    Dim cent As Point = BitmapTools.GetCentroid(rect)

                    Dim InForbidden As Boolean = False
                    For Each f As Rectangle In ForbiddenAreas
                        If f.Contains(cent) Then
                            InForbidden = True
                            Exit For
                        End If
                    Next

                    If Not InForbidden AndAlso (sz >= Filter.TargetSize.Min And sz <= Filter.TargetSize.Max) AndAlso (aspect_ratio >= Filter.TargetAspectRatio.Min And aspect_ratio <= Filter.TargetAspectRatio.Max) Then
                        Targets.Add(rect)
                    End If
                Next
            End If
        End With
    End Sub

    Public Function GetTargets() As List(Of Rectangle)
        Return Targets
    End Function

    Public Function GetOriginal() As Image(Of Bgr, Byte)
        Return OriginalFrame
    End Function
    Public Function GetHSV() As Image(Of Bgr, Byte)
        Return HSVFrame
    End Function
    Public Function GetMask() As Image(Of Gray, Byte)
        Return MaskFrame
    End Function
    Public Function GetFinalFrame() As Image(Of Bgr, Byte)
        Return FinalFrame
    End Function
    Public Function GetFinalMask() As Image(Of Gray, Byte)
        Return FinalMask
    End Function
    Public Function GetHitPoint(rect As Rectangle) As Point
        Return New Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2))
    End Function
    Public Function GetArea(rect As Rectangle) As Long
        Return rect.Width * rect.Height
    End Function
    Public Function GetAspectRatio(rect As Rectangle) As Long
        If rect.Height = 0 Then Return 0
        Return (rect.Width / rect.Height) * 100
    End Function

    Public Sub New()
        ForbiddenAreas.Add(Rectangle.FromLTRB(0, 0, 565, 48))
        ForbiddenAreas.Add(Rectangle.FromLTRB(0, 0, 248, 142))
        ForbiddenAreas.Add(Rectangle.FromLTRB(0, 0, 78, 320))
        ForbiddenAreas.Add(Rectangle.FromLTRB(76, 301, 182, 405))
        ForbiddenAreas.Add(Rectangle.FromLTRB(0, 460, 960, 600))
        ForbiddenAreas.Add(Rectangle.FromLTRB(873, 0, 960, 600))
        'ForbiddenAreas.Add(Rectangle.FromLTRB(373, 181, 636, 600)) 'Self char
    End Sub
End Class
