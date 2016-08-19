Public Class MonsterSettings
    Public Property Name As String = "DefaultSettings"
    Public Property Settings As New FilterSettings
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
    Public Function Clone() As MonsterSettings
        Dim Ret As New MonsterSettings
        Ret.Name = Me.Name
        Ret.Settings = Me.Settings.Clone

        Return Ret
    End Function
End Class
