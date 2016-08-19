Public Class MotionCapture

    Private previous_image As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = Nothing
    Private current_image As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = Nothing

    Public Structure DifferenceResult
        Public Mask As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)
        Public Image As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)
    End Structure

    Public Function GetDifference(ByVal img As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)) As DifferenceResult
        Dim dr As New DifferenceResult

        current_image = BGR2GRAY(img)
        If previous_image Is Nothing Then
            previous_image = current_image

            dr.Mask = Blank(current_image.Size)
            dr.Image = img.Copy(dr.Mask)
            Return dr
        End If

        If previous_image.Size <> current_image.Size Then
            previous_image = current_image

            dr.Mask = Blank(current_image.Size)
            dr.Image = img.Copy(dr.Mask)
            Return dr
        End If

        Dim ret As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = current_image.AbsDiff(previous_image)
        previous_image.Dispose()
        previous_image = current_image.Clone

        dr.Mask = ret
        dr.Image = img.Copy(dr.Mask)
        Return dr
    End Function

    Private Function Blank(ByVal sz As Size) As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)
        Dim ret As New Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)(sz)
        ret.SetValue(New Emgu.CV.Structure.Gray(255))
        Return ret
    End Function

    Private Function BGR2GRAY(ByVal src As Emgu.CV.Image(Of Emgu.CV.Structure.Bgr, Byte)) As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)
        Return src.Convert(Of Emgu.CV.Structure.Gray, Byte)()
    End Function

End Class
