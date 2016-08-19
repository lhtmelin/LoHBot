Public Class MonsterSetup
    Public Property CurrentSettings As MonsterSettings
    Public MHunt As New MonsterHunt

    Public Property NewSettings As MonsterSettings
    Private FilterWnd As FilterSetup

    Private Original As New Bitmap(960, 600, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
    Private HSV As New Bitmap(960, 600, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
    Private Mask As New Bitmap(960, 600, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
    Private Final As New Bitmap(960, 600, System.Drawing.Imaging.PixelFormat.Format24bppRgb)

    Private Sub MonsterSetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        tmr_update.Enabled = False
    End Sub

    Private Sub MonsterSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewSettings = CurrentSettings.Clone

        FilterWnd = New FilterSetup
        FilterWnd.Settings = NewSettings.Settings
        FilterWnd.Reload()
        FilterWnd.Show(Me)        

        txtName.Text = NewSettings.Name

        picOriginal.Image = Original
        picHSV.Image = HSV
        picMask.Image = Mask
        picFinal.Image = Final

        MHunt.Filter = NewSettings.Settings

        tmr_update.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text.Trim = "" Then
            MsgBox("Please inform the settings name!", MsgBoxStyle.Critical)
            Me.DialogResult = Windows.Forms.DialogResult.None
            Return
        End If

        NewSettings.Name = txtName.Text.Trim
        Dim s As MonsterSettings = Nothing
        If CFG.AutoHuntSettings.ContainsKey(txtName.Text.Trim) Then
            CFG.AutoHuntSettings(txtName.Text.Trim) = NewSettings
        Else
            CFG.AutoHuntSettings.Add(txtName.Text.Trim, NewSettings)
        End If
        CFG.Save()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub chkLiveUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles chkLiveUpdate.CheckedChanged
        tmr_update.Enabled = chkLiveUpdate.Checked
    End Sub

    Sub UpdateScreen()
        picOriginal.Invalidate()
        picHSV.Invalidate()
        picMask.Invalidate()
        picFinal.Invalidate()
    End Sub

    Private Sub tmr_update_Tick(sender As Object, e As EventArgs) Handles tmr_update.Tick
        MHunt.Update()
        Using g As Graphics = Graphics.FromImage(Original)
            g.DrawImage(MHunt.GetOriginal.Bitmap, 0, 0)
        End Using
        Using g As Graphics = Graphics.FromImage(HSV)
            g.DrawImage(MHunt.GetHSV.Bitmap, 0, 0)
        End Using
        Using g As Graphics = Graphics.FromImage(Mask)
            g.DrawImage(MHunt.GetMask.Bitmap, 0, 0)
        End Using

        Using g As Graphics = Graphics.FromImage(Final)
            g.DrawImage(MHunt.GetFinalFrame.Bitmap, 0, 0)

            Dim rect As List(Of Rectangle) = MHunt.GetTargets()
            Using fnt As New Font("Tahoma", 8)
                Using b_text As New SolidBrush(Color.Green)
                    Using p_geometry As New Pen(Color.Red, 2)
                        For Each r As Rectangle In rect
                            Dim half_sz As Integer = r.Width * 0.2
                            If half_sz < 5 Then half_sz = 5

                            Dim center As Point = BitmapTools.GetCentroid(r)
                            Dim left As Integer = center.X - half_sz
                            Dim right As Integer = center.X + half_sz
                            Dim top As Integer = center.Y - half_sz
                            Dim bottom As Integer = center.Y + half_sz

                            Dim rect_circle As Rectangle = Rectangle.FromLTRB(left, top, right, bottom)

                            g.DrawRectangle(p_geometry, r)
                            g.DrawEllipse(p_geometry, rect_circle)
                            g.DrawLine(p_geometry, center.X, rect_circle.Top, center.X, rect_circle.Bottom)
                            g.DrawLine(p_geometry, rect_circle.Left, center.Y, rect_circle.Right, center.Y)

                            Dim sz As Long = MHunt.GetArea(r)
                            Dim aspect_ratio As Long = MHunt.GetAspectRatio(r)

                            Dim txt As String = "Size = " & sz & Environment.NewLine & "A. Ratio = " & aspect_ratio
                            Dim layout As Rectangle = Rectangle.FromLTRB(r.Left - 100, r.Top - 24, r.Right + 100, r.Top)
                            Using fmt As New StringFormat
                                fmt.Alignment = StringAlignment.Center
                                fmt.LineAlignment = StringAlignment.Center

                                g.DrawString(txt, fnt, b_text, layout, fmt)
                            End Using
                        Next
                    End Using
                End Using
            End Using
        End Using

        UpdateScreen()
    End Sub
End Class