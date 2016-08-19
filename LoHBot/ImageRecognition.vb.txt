Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Features2D
Imports Emgu.CV.Structure
Imports Emgu.CV.Util

Public Class ImageRecognition
    Public Structure SearchResult
        Public Position As Rectangle
        Public Similariy As Single
        Sub New(ByVal pPosition As Rectangle, ByVal pSimilarity As Single)
            Position = pPosition
            Similariy = pSimilarity
        End Sub
        Public Shared Function Empty() As SearchResult
            Return New SearchResult(Rectangle.Empty, 0)
        End Function
    End Structure

    Public Shared Function Search(ByVal Fullimage As Bitmap, ByVal TemplateImage As Bitmap, Optional ByVal MinSimilarity As Single = 0.85) As Rectangle()

        Dim Ret As New List(Of Rectangle)
        Dim RetEx() As SearchResult = SearchEx(Fullimage, TemplateImage, MinSimilarity)

        If RetEx.Length > 0 Then
            For Each se As SearchResult In RetEx
                Ret.Add(se.Position)
            Next
        End If

        Return Ret.ToArray
    End Function

    Public Shared Function Search(ByVal Fullimage As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte), ByVal TemplateImage As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte), Optional ByVal MinSimilarity As Single = 0.85) As Rectangle()

        Dim Ret As New List(Of Rectangle)
        Dim RetEx() As SearchResult = SearchEx(Fullimage, TemplateImage, MinSimilarity)

        If RetEx.Length > 0 Then
            For Each se As SearchResult In RetEx
                Ret.Add(se.Position)
            Next
        End If

        Return Ret.ToArray
    End Function

    Public Shared Function SearchEx(ByVal Fullimage As Bitmap, ByVal TemplateImage As Bitmap, Optional ByVal MinSimilarity As Single = 0.85) As SearchResult()
        On Error Resume Next
        Dim Ret As New List(Of SearchResult)

        If Fullimage.PixelFormat <> Imaging.PixelFormat.Format24bppRgb Then
            Fullimage = BitmapTools.ChangePixelFormat(Fullimage, Imaging.PixelFormat.Format24bppRgb)
        End If

        If TemplateImage.PixelFormat <> Imaging.PixelFormat.Format24bppRgb Then
            TemplateImage = BitmapTools.ChangePixelFormat(TemplateImage, Imaging.PixelFormat.Format24bppRgb)
        End If

        Dim source As New Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)(Fullimage)
        Dim template As New Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)(TemplateImage)

        Return SearchEx(source, template, MinSimilarity)
    End Function

    Public Shared Function SearchEx(ByVal Fullimage As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte), ByVal TemplateImage As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte), Optional ByVal MinSimilarity As Single = 0.85) As SearchResult()
        On Error Resume Next
        Dim Ret As New List(Of SearchResult)

        Dim source As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte) = Fullimage
        Dim template As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte) = TemplateImage

        Using result As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Single) = source.MatchTemplate(template, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED)
            Dim minValues As Double() = {0}, maxValues As Double() = {0}
            Dim minLocations As Point() = {Point.Empty}, maxLocations As Point() = {Point.Empty}

            result.MinMax(minValues, maxValues, minLocations, maxLocations)

            For i As Integer = 0 To maxValues.Length - 1
                If maxValues(i) > MinSimilarity Then
                    Ret.Add(New SearchResult(New Rectangle(maxLocations(i), template.Size), maxValues(i)))
                End If
            Next
        End Using

        Return Ret.ToArray
    End Function

End Class
