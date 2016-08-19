Public Class FilterSetup
    Public Settings As New FilterSettings
    Private Sub FilterSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Reload()
        Try
            With Settings
                tbHueMax.Value = .Hue.Max
                tbHueMin.Value = .Hue.Min
                tbSatMax.Value = .Sat.Max
                tbSatMin.Value = .Sat.Min
                tbValMax.Value = .Val.Max
                tbValMin.Value = .Val.Min

                chkBlur.Checked = .Blur
                chkDilate.Checked = .Dilate
                chkErode.Checked = .Erode
                chkCleanup.Checked = .MaskCleanUp

                udBlur.Value = .BlurValue
                udDilate.Value = .DilateValue
                udErode.Value = .ErodeValue

                udTargetAspectRatioMax.Value = .TargetAspectRatio.Max
                udTargetAspectRatioMin.Value = .TargetAspectRatio.Min
                udTargetSizeMax.Value = .TargetSize.Max
                udTargetSizeMin.Value = .TargetSize.Min
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Text_LostFocus(sender As Object, e As EventArgs) Handles txtHueMin.LostFocus, txtSatMin.LostFocus, txtValMin.LostFocus, txtHueMax.LostFocus, txtSatMax.LostFocus, txtValMax.LostFocus
        Dim t As TextBox = sender
        Dim v As Integer = 0
        If Not Integer.TryParse(t.Text, v) Then
            MsgBox("Invalid value [" & t.Text & "]", MsgBoxStyle.Critical)
            t.Focus()
            t.SelectAll()
        Else
            If v < 0 Then
                MsgBox("Min value is 0!", MsgBoxStyle.Critical)
                t.Focus()
                t.SelectAll()
                Return
            End If
            If v > 255 Then
                MsgBox("Max value is 255!", MsgBoxStyle.Critical)
                t.Focus()
                t.SelectAll()
                Return
            End If

            If t.Equals(txtHueMin) Then
                tbHueMin.Value = v
                Settings.Hue.Min = v
            End If
            If t.Equals(txtHueMax) Then
                tbHueMax.Value = v
                Settings.Hue.Max = v
            End If
            If t.Equals(txtSatMin) Then
                tbSatMin.Value = v
                Settings.Sat.Min = v
            End If
            If t.Equals(txtSatMax) Then
                tbSatMax.Value = v
                Settings.Sat.Max = v
            End If
            If t.Equals(txtValMin) Then
                tbValMin.Value = v
                Settings.Val.Min = v
            End If
            If t.Equals(txtValMax) Then
                tbValMax.Value = v
                Settings.Val.Max = v
            End If
        End If
    End Sub

    Private Sub chkErode_CheckedChanged(sender As Object, e As EventArgs) Handles chkErode.CheckedChanged
        udErode.Enabled = chkErode.Checked
        Settings.Erode = chkErode.Checked
    End Sub

    Private Sub chkDilate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDilate.CheckedChanged
        udDilate.Enabled = chkDilate.Checked
        Settings.Dilate = chkDilate.Checked
    End Sub

    Private Sub chkBlur_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlur.CheckedChanged
        udBlur.Enabled = chkBlur.Checked
        Settings.Blur = chkBlur.Checked
    End Sub

    Private Sub chkCleanup_CheckedChanged(sender As Object, e As EventArgs) Handles chkCleanup.CheckedChanged
        Settings.MaskCleanUp = chkCleanup.Checked
    End Sub

    Private Sub udErode_ValueChanged(sender As Object, e As EventArgs) Handles udErode.ValueChanged
        Settings.ErodeValue = udErode.Value
    End Sub

    Private Sub udDilate_ValueChanged(sender As Object, e As EventArgs) Handles udDilate.ValueChanged
        Settings.DilateValue = udDilate.Value
    End Sub

    Private Sub udBlur_ValueChanged(sender As Object, e As EventArgs) Handles udBlur.ValueChanged
        Settings.BlurValue = udBlur.Value
    End Sub

    Private Sub udTargetAspectRatioMin_ValueChanged(sender As Object, e As EventArgs) Handles udTargetAspectRatioMin.ValueChanged
        Settings.TargetAspectRatio.Min = udTargetAspectRatioMin.Value
    End Sub

    Private Sub udTargetSizeMin_ValueChanged(sender As Object, e As EventArgs) Handles udTargetSizeMin.ValueChanged
        Settings.TargetSize.Min = udTargetSizeMin.Value
    End Sub

    Private Sub udTargetAspectRatioMax_ValueChanged(sender As Object, e As EventArgs) Handles udTargetAspectRatioMax.ValueChanged
        Settings.TargetAspectRatio.Max = udTargetAspectRatioMax.Value
    End Sub

    Private Sub udTargetSizeMax_ValueChanged(sender As Object, e As EventArgs) Handles udTargetSizeMax.ValueChanged
        Settings.TargetSize.Max = udTargetSizeMax.Value
    End Sub

    Private Sub TrackBar_Changed(sender As Object, e As EventArgs) Handles tbHueMax.Scroll, tbHueMin.Scroll, tbSatMax.Scroll, tbSatMin.Scroll, tbValMax.Scroll, tbValMin.Scroll, tbHueMax.ValueChanged, tbHueMin.ValueChanged, tbSatMax.ValueChanged, tbSatMin.ValueChanged, tbValMax.ValueChanged, tbValMin.ValueChanged
        Dim tb As TrackBar = sender
        If tb.Equals(tbHueMax) Then
            Settings.Hue.Max = tb.Value
            txtHueMax.Text = tb.Value
        End If
        If tb.Equals(tbHueMin) Then
            Settings.Hue.Min = tb.Value
            txtHueMin.Text = tb.Value
        End If
        If tb.Equals(tbSatMax) Then
            Settings.Sat.Max = tb.Value
            txtSatMax.Text = tb.Value
        End If
        If tb.Equals(tbSatMin) Then
            Settings.Sat.Min = tb.Value
            txtSatMin.Text = tb.Value
        End If
        If tb.Equals(tbValMax) Then
            Settings.Val.Max = tb.Value
            txtValMax.Text = tb.Value
        End If
        If tb.Equals(tbValMin) Then
            Settings.Val.Min = tb.Value
            txtValMin.Text = tb.Value
        End If
    End Sub

    Private Sub tbSatMin_Scroll(sender As Object, e As EventArgs) Handles tbSatMin.Scroll

    End Sub

End Class