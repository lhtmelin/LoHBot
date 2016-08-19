Public Class DebugScreen
    Public Buffer As New Bitmap(960, 600)
    Private Sub DebugScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tmrPaint.Enabled = True
    End Sub

    Private Sub tmrPaint_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPaint.Tick
        Using bs As Emulator = GetEmulator()
            Using g As Graphics = Graphics.FromImage(Buffer)
                g.DrawImage(bs.GetBuffer.Bitmap, 0, 0)
                picBuffer.Image = Buffer
            End Using
        End Using
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        tmrPaint.Enabled = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub picBuffer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBuffer.MouseMove
        txtCurrentXY.Text = e.X & ", " & e.Y
        Dim clr As Color = Buffer.GetPixel(e.X, e.Y)
        txtCurrentColor.Text = clr.ToString
        picCurrentColor.BackColor = clr
    End Sub

    Private Sub picBuffer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picBuffer.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            txtClickedXY.Text = e.X & ", " & e.Y
            Dim clr As Color = Buffer.GetPixel(e.X, e.Y)
            txtClickedColor.Text = clr.ToString
            picClickedColor.BackColor = clr
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCode.Text = ""
        txtCode.AppendText("Dim Coords As New List(Of Point)" & Environment.NewLine)
        txtCode.AppendText("Dim Colors As New List(Of Color)" & Environment.NewLine)
        txtCode.AppendText("" & Environment.NewLine)
    End Sub

    Private Sub btnCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCode.Click
        txtCode.AppendText("Coords.Add(New Point(" & txtClickedXY.Text & "))" & Environment.NewLine)
        txtCode.AppendText("Colors.Add(Color.FromArgb(" & picClickedColor.BackColor.R & "," & picClickedColor.BackColor.G & "," & picClickedColor.BackColor.B & "))" & Environment.NewLine)
        txtCode.AppendText("" & Environment.NewLine)
    End Sub

    Private Sub chkLiveBuffer_CheckedChanged(sender As Object, e As EventArgs) Handles chkLiveBuffer.CheckedChanged
        tmrPaint.Enabled = chkLiveBuffer.Checked
    End Sub
End Class