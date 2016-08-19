Imports Emgu.CV
Imports Emgu.CV.Structure

Public Class BitmapTools
    Public Shared Function BlendImages(ByVal ImgSrc As Bitmap, ByVal ImgToBlend As Bitmap, ByVal BlendPos As Point) As Bitmap
        If ImgSrc Is Nothing Then Return ImgToBlend
        If BlendPos.IsEmpty Then
            BlendPos = New Point(0, 0)
        End If

        Using g As Graphics = Graphics.FromImage(ImgSrc)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(ImgToBlend, BlendPos)
        End Using

        Return ImgSrc
    End Function

    Public Shared Function BlendImages(ByVal ImgSrc As Bitmap, ByVal ImgToBlend As Bitmap) As Bitmap
        Return BlendImages(ImgSrc, ImgToBlend, Point.Empty)
    End Function

    Public Shared Function Resize(ByVal ImgSrc As Bitmap, ByVal PercentSize As Single) As Bitmap
        Dim new_width As Integer = ImgSrc.Width * PercentSize
        Dim new_height As Integer = ImgSrc.Height * PercentSize
        Return Resize(ImgSrc, New Size(new_width, new_height))
    End Function

    Public Shared Function Resize(ByVal ImgSrc As Bitmap, ByVal new_size As Integer, ByVal is_width As Boolean) As Bitmap
        Dim new_width As Integer = 0
        Dim new_height As Integer = 0

        If is_width Then
            new_width = new_size
            new_height = (new_size / ImgSrc.Width) * ImgSrc.Height
        Else
            new_width = (new_size / ImgSrc.Height) * ImgSrc.Width
            new_height = new_size
        End If
        Return Resize(ImgSrc, New Size(new_width, new_height))
    End Function

    Public Shared Function Resize(ByVal ImgSrc As Bitmap, ByVal Size As Size) As Bitmap
        Dim new_width As Integer = Size.Width
        Dim new_height As Integer = Size.Height

        Dim ret As New Bitmap(new_width, new_height, ImgSrc.PixelFormat)
        Using g As Graphics = Graphics.FromImage(ret)
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.DrawImage(ImgSrc, 0, 0, new_width, new_height)
        End Using
        Return ret
    End Function

    Public Shared Function ChangePixelFormat(ByVal ImgSrc As Bitmap, ByVal newFormat As System.Drawing.Imaging.PixelFormat) As Bitmap
        Return (ImgSrc.Clone(New Rectangle(0, 0, ImgSrc.Width, ImgSrc.Height), newFormat))
    End Function

    Public Shared Function CutImage(ByVal ImgSrc As Bitmap, ByVal Area As Rectangle) As Bitmap
        Return CutImage(ImgSrc, Area, ImgSrc.PixelFormat)
    End Function
    Public Shared Function CutImage(ByVal ImgSrc As Bitmap, ByVal Area As Rectangle, ByVal imageformat As System.Drawing.Imaging.PixelFormat) As Bitmap
        Dim ret As New Bitmap(Area.Width, Area.Height, imageformat)
        Using g As Graphics = Graphics.FromImage(ret)
            g.DrawImage(ImgSrc, New Rectangle(0, 0, ret.Width, ret.Height), Area, GraphicsUnit.Pixel)
        End Using
        Return ret
    End Function
    Public Shared Function ToBinary(ByVal src As Bitmap) As Bitmap
        Using img_src As New Image(Of Bgr, Byte)(src)
            Dim ret As Image(Of Gray, Byte)
            ret = img_src.Convert(Of Gray, Byte)().ThresholdBinaryInv(New Gray(127), New Gray(255))
            Return ret.ToBitmap
        End Using
    End Function

    Public Shared Function PrepareImageForOCR(ByVal img As Bitmap) As Bitmap
        Dim Ret As Bitmap = Nothing
        Using img2 As New Image(Of Bgr, Byte)(img)
            Using im3 As Image(Of Bgr, Byte) = img2.Resize(10, CvEnum.INTER.CV_INTER_LINEAR)
                Ret = BitmapTools.ToBinary(im3.Bitmap)
            End Using
        End Using
        Return Ret
    End Function

    'Public Shared Function PrepareImageForOCR(ByVal img As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)) As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)

    '    Return UpScaleImage(img, 10, True)

    '    'Dim ret As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = Nothing
    '    'Dim imgbig As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = img.Resize(10, CvEnum.INTER.CV_INTER_LINEAR)
    '    'For i As Integer = 1 To 2
    '    '    imgbig = ImageSharp(imgbig)
    '    'Next
    '    'ret = imgbig.Resize(0.5, CvEnum.INTER.CV_INTER_LINEAR)
    '    'imgbig.Dispose()
    '    'Return ret
    'End Function

    'Public Shared Function UpScaleImage(img As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte), factor As Double, borderize As Boolean) As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)
    '    Dim ret As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = Nothing

    '    Using imgbig As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = img.Resize(factor, CvEnum.INTER.CV_INTER_LINEAR)
    '        ret = imgbig.Clone
    '        'ret.SetValue(New Emgu.CV.Structure.Gray(255))

    '        'If borderize Then
    '        '    Dim contours As Emgu.CV.Contour(Of System.Drawing.Point) = imgbig.FindContours(CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, CvEnum.RETR_TYPE.CV_RETR_TREE)

    '        '    Do While Not contours Is Nothing
    '        '        Dim currentContour As Emgu.CV.Contour(Of Point) = contours.ApproxPoly(contours.Perimeter * 0.015)
    '        '        Emgu.CV.CvInvoke.cvFillConvexPoly(ret, contours.ToArray, contours.ToArray.Length, New Emgu.CV.Structure.MCvScalar(255), Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, 0)
    '        '        contours = contours.HNext
    '        '    Loop

    '        'End If
    '    End Using

    '    'ret.Bitmap.Save("c:\temp\ocr.png")

    '    Return ret
    'End Function

    Public Shared Function ImageSharp(ByVal img As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)) As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)
        Using img3 As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = img.SmoothGaussian(0, 0, 3, 3)
            img = img.AddWeighted(img3, 1.5, -0.5, 0)
        End Using
        Return img
    End Function

    Public Shared Function OCRText(img As Bitmap, rect As Rectangle, Optional ConfidenceLimit As Single = 0.5) As String
        Dim Ret As String = ""
        Using b As Bitmap = BitmapTools.CutImage(img, rect)
            Ret = OCRText(b, ConfidenceLimit)
        End Using
        Return Ret
    End Function


    Public Shared Function OCRText(img As Bitmap, Optional ConfidenceLimit As Single = 0.5) As String

        Using bb As Bitmap = BitmapTools.PrepareImageForOCR(img)
            Using p As Tesseract.Page = OCREngine.Process(bb)
                If p.GetMeanConfidence < ConfidenceLimit Then
                    Return ""
                Else
                    Dim Ret As String = p.GetText.Trim
                    Dim rgx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 ()+-/:|[]]")
                    Ret = rgx.Replace(Ret, "")

                    Return Ret
                End If
            End Using
        End Using

    End Function

    Public Shared Function OCRNumeric(txt As String) As Long
        Dim Ret As String = txt.Trim

        Ret = Ret.Replace("|", "1")
        Ret = Ret.Replace("]", "1")
        Ret = Ret.Replace(")", "1")
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
        Dim rgx As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("[^0-9-/]")
        Ret = rgx.Replace(Ret, "")

        Dim RetLng As Long = 0
        If Long.TryParse(Ret, RetLng) Then
            Return RetLng
        Else
            Return -1
        End If

    End Function

    Public Shared Function OCRNumeric(img As Bitmap, Optional ConfidenceLimit As Single = 0.5) As Long
        Dim Ret As String = OCRText(img, ConfidenceLimit)
        If Ret = "" Then Return -1

        Return OCRNumeric(Ret)
    End Function

    Public Shared Function OCRNumeric(img As Bitmap, rect As Rectangle, Optional ConfidenceLimit As Single = 0.5) As Long
        Dim Ret As String = ""
        Using b As Bitmap = BitmapTools.CutImage(img, rect)
            Ret = OCRText(b, ConfidenceLimit)
            If Ret = "" Then Return -1
        End Using

        Return OCRNumeric(Ret)
    End Function

    Public Shared Function GetRectangleFromPoly(pts() As Point) As Rectangle
        Dim minx As Integer = Integer.MaxValue
        Dim miny As Integer = Integer.MaxValue
        Dim maxx As Integer = Integer.MinValue
        Dim maxy As Integer = Integer.MinValue

        For Each p As Point In pts
            If p.X > maxx Then maxx = p.X
            If p.X < minx Then minx = p.X
            If p.Y > maxy Then maxy = p.Y
            If p.Y < miny Then miny = p.Y
        Next

        Return Rectangle.FromLTRB(minx, miny, maxx, maxy)
    End Function

    Public Shared Function NormalizePoly(pts() As Point) As Point()
        Dim Ret As New List(Of Point)
        Dim Rect As Rectangle = GetRectangleFromPoly(pts)

        For Each p As Point In pts
            Dim p2 As New Point(p.X - Rect.Left, p.Y - Rect.Top)
            Ret.Add(p2)
        Next
        Return Ret.ToArray
    End Function

    Public Shared Function MaskByColor(Img As Image(Of Bgr, Byte), Colors As Dictionary(Of Color, Long)) As Image(Of Gray, Byte)
        Dim Ret As New Image(Of Gray, Byte)(Img.Width, Img.Height)
        Ret.SetValue(New Gray(0))

        For x As Integer = 0 To Img.Width - 1
            For y As Integer = 0 To Img.Height - 1
                Dim bgr As Bgr = Img.Item(y, x)
                Dim clr As Color = System.Drawing.Color.FromArgb(bgr.Red, bgr.Green, bgr.Blue)
                If Colors.ContainsKey(clr) Then
                    Ret.Item(y, x) = New Gray(255)
                End If
            Next
        Next

        Return Ret
    End Function


    Public Shared Function SumColor(ByVal Pic As Bitmap, ByVal Rect As Rectangle) As Long
        Using img As New Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)(BitmapTools.CutImage(Pic, Rect))
            Dim s As Emgu.CV.Structure.Bgr = img.GetSum()
            Return (s.Red + s.Green + s.Blue) / 3
        End Using
    End Function

    Public Shared Function AvgColor(ByVal Pic As Bitmap, ByVal Rect As Rectangle) As Long
        Using img As New Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)(BitmapTools.CutImage(Pic, Rect))
            Dim s As Emgu.CV.Structure.Bgr = img.GetAverage()
            Return (s.Red + s.Green + s.Blue) / 3
        End Using
    End Function

    Public Shared Function AvgBrightness(ByVal Pic As Bitmap, ByVal Area As Rectangle) As Double
        If Pic Is Nothing Then Return 0

        Dim Y_TT As Double = 0
        Dim I_TT As Double = 0

        Using img As New Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)(BitmapTools.CutImage(Pic, Area))

            For x As Integer = 0 To img.Width - 1
                For y As Integer = 0 To img.Height - 1
                    I_TT += 1

                    Dim R As Integer = img.Item(y, x).Red
                    Dim G As Integer = img.Item(y, x).Green
                    Dim B As Integer = img.Item(y, x).Blue

                    Y_TT += (0.299 * R + 0.587 * G + 0.144 * B)
                Next
            Next
        End Using

        If I_TT = 0 Then Return 0
        Return Y_TT / I_TT
    End Function

    Public Shared Function GetRectanglesFromMask(ByVal msk As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte), Optional ByVal FilterSimilarRectangles As Boolean = False, Optional ByVal RETR_TYPE As Emgu.CV.CvEnum.RETR_TYPE = Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_CCOMP) As Rectangle()
        Dim Ret As New List(Of Rectangle)
        Dim contours As Emgu.CV.Contour(Of Point) = msk.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, RETR_TYPE)
        Do While Not contours Is Nothing
            Dim currentContour As Emgu.CV.Contour(Of Point) = contours.ApproxPoly(contours.Perimeter * 0.015)
            If currentContour.BoundingRectangle.Width > 20 Then
                Dim rect As Rectangle = PolyToRect(contours.ToArray)
                If rect <> Rectangle.Empty Then
                    Ret.Add(rect)
                End If
            End If
            contours = contours.HNext
        Loop

        If Not FilterSimilarRectangles Then
            Return Ret.ToArray
        Else
            Return GetSimilarRectangles(Ret.ToArray)
        End If
    End Function

    Public Shared Function GetCentroid(rect As Rectangle) As Point
        Return New Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2))
    End Function

    Public Shared Function GetSimilarRectangles(ByVal rect() As Rectangle) As Rectangle()
        Dim Ret As New List(Of Rectangle)
        Dim Ratios As New List(Of Double)
        Dim Areas As New List(Of Double)
        Ret.AddRange(rect)

        For i As Integer = 0 To Ret.Count - 1
            If AreaRectangle(Ret(i)) > 0 Then
                Ratios.Add(CDbl(Ret(i).Width) / CDbl(Ret(i).Height))
                Areas.Add(AreaRectangle(Ret(i)))
            End If
        Next

        Dim MdRatio As Double = Median(Ratios.ToArray)
        Dim MdArea As Double = Median(Areas.ToArray)

        Dim MinRatio As Double = MdRatio * 0.9
        Dim MaxRatio As Double = MdRatio * 1.1

        Dim MinArea As Double = MdArea * 0.9
        Dim MaxArea As Double = MdArea * 1.1

        For i As Integer = Ret.Count - 1 To 0 Step -1
            If AreaRectangle(Ret(i)) > 0 Then
                Dim Ratio As Double = CDbl(Ret(i).Width) / CDbl(Ret(i).Height)
                Dim Area As Double = AreaRectangle(Ret(i))

                If Ratio < MinRatio Or Ratio > MaxRatio Then
                    Ret.RemoveAt(i)
                Else
                    If Area < MinArea Or Area > MaxArea Then
                        Ret.RemoveAt(i)
                    End If
                End If
            Else
                Ret.RemoveAt(i)
            End If
        Next

        Return Ret.ToArray
    End Function

    Public Shared Function PolyToRect(ByVal p() As Point) As Rectangle
        Dim minx As Integer = Integer.MaxValue, miny As Integer = Integer.MaxValue
        Dim maxx As Integer = Integer.MinValue, maxy As Integer = Integer.MinValue

        For Each pt As Point In p
            If pt.X > maxx Then
                maxx = pt.X
            End If
            If pt.X < minx Then
                minx = pt.X
            End If

            If pt.Y > maxy Then
                maxy = pt.Y
            End If
            If pt.Y < miny Then
                miny = pt.Y
            End If
        Next

        Return Rectangle.FromLTRB(minx, miny, maxx, maxy)
    End Function

    Public Shared Function AgregateRectangles(ByVal rects() As Rectangle) As Rectangle
        Dim pts As New List(Of Point)
        For Each rect As Rectangle In rects
            pts.Add(New Point(rect.Left, rect.Top))
            pts.Add(New Point(rect.Left, rect.Bottom))
            pts.Add(New Point(rect.Right, rect.Top))
            pts.Add(New Point(rect.Right, rect.Bottom))
        Next
        Return PolyToRect(pts.ToArray)
    End Function

    Public Shared Function AreaRectangle(ByVal rect As Rectangle) As Integer
        Return rect.Height * rect.Width
    End Function

    Public Shared Function Average(ByVal values() As Double) As Double
        If values.Length = 0 Then Return 0
        Return Sum(values) / values.Length
    End Function

    Public Shared Function STDDev(ByVal values() As Double) As Double
        Dim M As Double = 0.0
        Dim S As Double = 0.0
        Dim k As Integer = 1
        For Each v As Double In values
            Dim tmpM As Double = M
            M += (v - tmpM) / k
            S += (v - tmpM) * (v - M)
            k += 1
        Next
        Return Math.Sqrt(S / (k - 2))
    End Function

    Public Shared Function Median(ByVal values() As Double) As Double
        If values.Length = 0 Then Return 0
        If values.Length = 1 Then Return values(0)


        Dim Tmp As New List(Of Double)
        Tmp.AddRange(values)
        Tmp.Sort()
        Dim i As Integer = Tmp.Count / 2
        If i Mod 2 = 0 Then
            Dim i2 As Integer = i + 1
            If i2 > values.Length - 1 Then
                Return values(i)
            Else
                Return (values(i) + values(i2)) / 2
            End If
        Else
            Return Tmp(i)
        End If
    End Function

    Public Shared Function Sum(ByVal values() As Double) As Double
        Dim ret As Double = 0
        For Each v As Double In values
            ret += v
        Next
        Return ret
    End Function

    Public Shared Function RandomRange(min As Integer, max As Integer) As Integer
        Randomize(Now.ToOADate)
        Return CInt(Math.Floor((max - min + 1) * Rnd())) + min
    End Function
End Class
