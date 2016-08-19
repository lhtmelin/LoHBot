Public Class MinMaxValue(Of T)
    Public Property Max As T
    Public Property Min As T
    Public Sub New()
    End Sub
    Public Sub New(pMin As T, pMax As T)
        Me.Min = pMin
        Me.Max = pMax
    End Sub
End Class
