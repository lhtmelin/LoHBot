Public Class Graph
    Private _Data As New List(Of Double)

    Private _Color As Color = Color.FromKnownColor(KnownColor.SeaGreen)
    Public Property Color As Color
        Get
            Return _Color
        End Get
        Set(value As Color)
            _Color = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub AddData(Value As Double)

        If _Data.Count > 0 Then
            If _Data(_Data.Count - 1) = Value Then Return
        End If

        If _Data.Count > 25 Then
            Do
                If _Data.Count < 25 Then Exit Do
                _Data.RemoveAt(0)
            Loop
        End If
        _Data.Add(Value)
        Me.Invalidate()
    End Sub

    Private Sub Graph_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim MaxPoints As Integer = Me.Width / 64
        Dim GridSize As Integer = 32
        Dim GridColor As Color = ControlPaint.LightLight(ControlPaint.LightLight(ControlPaint.LightLight(Me.Color)))
        Dim LineColor As Color = Me.Color
        Dim FillColor As Color = ControlPaint.Light(ControlPaint.Light(Me.Color))

        FillColor = System.Drawing.Color.FromArgb(127, FillColor)

        Dim MinVal As Double = Double.MaxValue
        Dim MaxVal As Double = Double.MinValue

        For Each v As Double In _Data
            If v < MinVal Then MinVal = v
            If v > MaxVal Then MaxVal = v
        Next

        MaxVal = MaxVal * 1.1
        MinVal = MinVal * 0.9

        Dim Pts As New List(Of Point)
        Dim px As Integer = 0

        For i As Integer = 0 To _Data.Count - 1
            Dim v As Double = _Data(i)
            Dim PercentY As Double = 0

            If (MaxVal - MinVal) = 0 Then PercentY = 0 Else PercentY = 1 - ((v - MinVal) / (MaxVal - MinVal))

            Pts.Add(New Point(px, Me.ClientSize.Height * PercentY))

            If (_Data.Count - 1) = 0 Then
                px += (Me.ClientSize.Width - 1) / 1
            Else
                px += (Me.ClientSize.Width - 1) / (_Data.Count - 1)
            End If
        Next
        Pts.Add(New Point(Me.ClientSize.Width - 1, Me.ClientSize.Height - 1))
        Pts.Add(New Point(0, Me.ClientSize.Height - 1))

        With e.Graphics
            .Clear(System.Drawing.Color.White)
            Using p As New Pen(GridColor)
                For x As Integer = 0 To Me.Width Step GridSize
                    For y As Integer = 0 To Me.Height Step GridSize
                        .DrawRectangle(p, New Rectangle(x, y, GridSize, GridSize))
                    Next
                Next
            End Using

            Using b As New SolidBrush(FillColor)
                .FillPolygon(b, Pts.ToArray)
            End Using

            Using p As New Pen(Me.Color)
                .DrawLines(p, Pts.ToArray)
                .DrawRectangle(p, New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1))
            End Using
        End With

    End Sub
End Class
