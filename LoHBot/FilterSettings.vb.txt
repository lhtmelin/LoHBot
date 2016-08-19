Public Class FilterSettings
    Public Property Hue As New MinMaxValue(Of Integer)(0, 255)
    Public Property Sat As New MinMaxValue(Of Integer)(0, 255)
    Public Property Val As New MinMaxValue(Of Integer)(0, 255)
    Public Property Erode As Boolean = False
    Public Property ErodeValue As Integer = 1
    Public Property Dilate As Boolean = False
    Public Property DilateValue As Integer = 1
    Public Property Blur As Boolean = False
    Public Property BlurValue As Integer = 1
    Public Property MaskCleanUp As Boolean = False
    Public Property TargetAspectRatio As New MinMaxValue(Of Long)(0, 200)
    Public Property TargetSize As New MinMaxValue(Of Long)(0, 99999999)
    Public Function Clone() As FilterSettings
        Dim Ret As New FilterSettings

        Ret.Blur = Me.Blur
        Ret.BlurValue = Me.BlurValue
        Ret.Dilate = Me.Dilate
        Ret.DilateValue = Me.DilateValue
        Ret.Erode = Me.Erode
        Ret.ErodeValue = Me.ErodeValue
        Ret.MaskCleanUp = Me.MaskCleanUp

        Ret.Hue = New MinMaxValue(Of Integer)(Me.Hue.Min, Me.Hue.Max)
        Ret.Sat = New MinMaxValue(Of Integer)(Me.Sat.Min, Me.Sat.Max)
        Ret.Val = New MinMaxValue(Of Integer)(Me.Val.Min, Me.Val.Max)

        Ret.TargetAspectRatio = New MinMaxValue(Of Long)(Me.TargetAspectRatio.Min, Me.TargetAspectRatio.Max)
        Ret.TargetSize = New MinMaxValue(Of Long)(Me.TargetSize.Min, Me.TargetSize.Max)

        Return Ret
    End Function
End Class
