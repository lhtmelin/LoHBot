Public Class BOTSetup
    Public Zoom As Double = 1
    Public ScreenBuffer As Bitmap = New Bitmap(960, 600, Imaging.PixelFormat.Format24bppRgb)

    Public BitmapColorCheck As Bitmap

    Public PointA As Point = Point.Empty
    Public PointB As Point = Point.Empty
    Public IsSelecting As Boolean = False

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        If Zoom >= 5 Then Return

        Zoom += 0.1
        UpdateZoom()
    End Sub

    Private Sub btnRestoreZoom_Click(sender As Object, e As EventArgs) Handles btnRestoreZoom.Click
        Zoom = 1
        UpdateZoom()
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        If Zoom <= 0.2 Then Return

        Zoom -= 0.1
        UpdateZoom()
    End Sub
    Sub UpdateZoom()
        picBuffer.Width = 960 * Zoom
        picBuffer.Height = 600 * Zoom
    End Sub


    Private Sub BOTSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picBuffer.Image = ScreenBuffer
        tcConfig.TabPages.Clear()
        UpdateBuffer()
    End Sub

    Sub UpdateBuffer()
        Using bs As Emulator = GetEmulator()
            Using g As Graphics = Graphics.FromImage(ScreenBuffer)
                g.DrawImage(bs.GetBuffer.Bitmap, 0, 0)
            End Using
        End Using
        picBuffer.Invalidate()
    End Sub

    Private Sub btnLiveUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles btnLiveUpdate.CheckedChanged
        tmr_liveupdate.Enabled = btnLiveUpdate.Checked
        btnRefresh.Enabled = Not btnLiveUpdate.Checked
    End Sub

    Private Sub tmr_liveupdate_Tick(sender As Object, e As EventArgs) Handles tmr_liveupdate.Tick
        UpdateBuffer()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        UpdateBuffer()
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        If cboCategory.SelectedIndex = -1 Then
            MsgBox("Select a category first!", MsgBoxStyle.Critical)
            Return
        End If

        Dim Name As String = ""
        Name = InputBox("Type a element name:")
        If Name = "" Then Return

        If cboCategory.Text = "Clickable Objects" Then
            If BOTRes.ClickableResources.ContainsKey(Name) Then
                MsgBox("Already exists a resource with this name!", MsgBoxStyle.Critical)
                Return
            End If
            BOTRes.ClickableResources.Add(Name, Point.Empty)
            BOTRes.Save()
        ElseIf cboCategory.Text = "Element Detection" Then
            If BOTRes.DetectableResources.ContainsKey(Name) Then
                MsgBox("Already exists a resource with this name!", MsgBoxStyle.Critical)
                Return
            End If
            BOTRes.DetectableResources.Add(Name, New List(Of String))
            BOTRes.DetectableResourcesFast.Add(Name, New List(Of Point))
            BOTRes.Save()
        ElseIf cboCategory.Text = "Color Check" Then
            If BOTRes.ColorCheckResources.ContainsKey(Name) Then
                MsgBox("Already exists a resource with this name!", MsgBoxStyle.Critical)
                Return
            End If

            Dim cCheck As New BOTResources.ColorCheck
            With cCheck
                .Area = Rectangle.Empty
                .Condition = "="
                .ConditionValue = 0
                .Operation = BOTResources.ColorCheck.enOperation.AvgColor
                .SelectedValue = 0
            End With
            BOTRes.ColorCheckResources.Add(Name, cCheck)
            BOTRes.Save()
            cboElement_SelectedIndexChanged(Nothing, Nothing)
        End If
        RefreshElements()
        cboElement.SelectedIndex = cboElement.FindStringExact(Name)

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        RefreshElements()
    End Sub

    Sub RefreshElements()
        tcConfig.TabPages.Clear()
        cboElement.Items.Clear()
        If cboCategory.SelectedIndex = -1 Then Return

        If cboCategory.Text = "Clickable Objects" Then
            For Each n As String In BOTRes.ClickableResources.Keys
                cboElement.Items.Add(n)
            Next
            tcConfig.TabPages.Add(tpClick)
        ElseIf cboCategory.Text = "Element Detection" Then
            For Each n As String In BOTRes.DetectableResources.Keys
                cboElement.Items.Add(n)
            Next
            tcConfig.TabPages.Add(tpElement)
        ElseIf cboCategory.Text = "Color Check" Then
            For Each n As String In BOTRes.ColorCheckResources.Keys
                cboElement.Items.Add(n)
            Next
            tcConfig.TabPages.Add(tpColorCheck)
        End If
    End Sub

    Private Sub picBuffer_Invalidated(sender As Object, e As InvalidateEventArgs) Handles picBuffer.Invalidated

    End Sub

    Private Sub picBuffer_MouseMove(sender As Object, e As MouseEventArgs) Handles picBuffer.MouseMove
        Dim p As Point = ConvertPoint(New Point(e.X, e.Y))
        tlblblScreenCoords.Text = "Screen Coords: " & p.X & ", " & p.Y

        If IsSelecting Then
            If Not PointA.IsEmpty Then
                PointB = p
                picBuffer.Invalidate()
            End If
        End If
    End Sub

    Private Sub picBuffer_MouseUp(sender As Object, e As MouseEventArgs) Handles picBuffer.MouseUp
        If cboCategory.SelectedIndex = -1 Then
            MsgBox("Pick a category first!", MsgBoxStyle.Critical)
            Return
        End If

        If cboElement.SelectedIndex = -1 Then
            MsgBox("Pick a element first!", MsgBoxStyle.Critical)
            Return
        End If

        If cboCategory.Text = "Clickable Objects" Then
            Dim p As Point
            p = ConvertPoint(New Point(e.X, e.Y))

            txtScreenCoords.Text = p.ToString
            BOTRes.ClickableResources(cboElement.Text) = p
            BOTRes.Save()

            PointA = Point.Empty
            PointB = Point.Empty
        ElseIf cboCategory.Text = "Element Detection" Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If PointA.IsEmpty Then
                    IsSelecting = True
                    PointA = ConvertPoint(New Point(e.X, e.Y))
                Else
                    IsSelecting = False
                    PointB = ConvertPoint(New Point(e.X, e.Y))

                    'Cut picture, save and display

                    Dim top As Integer
                    Dim left As Integer
                    Dim right As Integer
                    Dim bottom As Integer

                    If PointA.Y < PointB.Y Then
                        top = PointA.Y
                        bottom = PointB.Y
                    Else
                        top = PointB.Y
                        bottom = PointA.Y
                    End If

                    If PointA.X < PointB.X Then
                        left = PointA.X
                        right = PointB.X
                    Else
                        left = PointB.X
                        right = PointA.X
                    End If

                    Dim Bmp As Bitmap = BitmapTools.CutImage(ScreenBuffer, Rectangle.FromLTRB(left, top, right, bottom))
                    picSelected.Image = Bmp
                    btnAdd.Enabled = True

                    PointA = Point.Empty
                    PointB = Point.Empty
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                Dim pt As New Point(e.X, e.Y)
                txtElementScreenCoords.Text = pt.ToString
                txtElementScreenCoords.Tag = pt
            End If
        ElseIf cboCategory.Text = "Color Check" Then
            If PointA.IsEmpty Then
                IsSelecting = True
                PointA = ConvertPoint(New Point(e.X, e.Y))
            Else
                IsSelecting = False
                PointB = ConvertPoint(New Point(e.X, e.Y))

                'Cut picture, save and display

                Dim top As Integer
                Dim left As Integer
                Dim right As Integer
                Dim bottom As Integer

                If PointA.Y < PointB.Y Then
                    top = PointA.Y
                    bottom = PointB.Y
                Else
                    top = PointB.Y
                    bottom = PointA.Y
                End If

                If PointA.X < PointB.X Then
                    left = PointA.X
                    right = PointB.X
                Else
                    left = PointB.X
                    right = PointA.X
                End If

                Dim Area As Rectangle = Rectangle.FromLTRB(left, top, right, bottom)
                BitmapColorCheck = BitmapTools.CutImage(ScreenBuffer, Area)
                picColorSelected.Image = BitmapColorCheck
                lblArea.Text = "Area: " & Area.Left & ", " & Area.Right & ", " & Area.Top & ", " & Area.Bottom

                BOTRes.ColorCheckResources(cboElement.Text).Area = Area
                BOTRes.Save()

                UpdateValue()

                PointA = Point.Empty
                PointB = Point.Empty
            End If

        End If
    End Sub
    Public Function ConvertPoint(p As Point) As Point
        Return New Point(p.X / Zoom, p.Y / Zoom)
    End Function

    Private Sub cboElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElement.SelectedIndexChanged
        If cboElement.SelectedIndex = -1 Then Return

        If cboCategory.Text = "Clickable Objects" Then
            txtScreenCoords.Text = BOTRes.ClickableResources(cboElement.Text).ToString
        ElseIf cboCategory.Text = "Element Detection" Then
            lvElements.Items.Clear()
            lvScreenCoords.Items.Clear()

            For Each n As String In BOTRes.DetectableResources(cboElement.Text)
                lvElements.Items.Add(n)
            Next

            txtElementScreenCoords.Text = ""
            txtElementScreenCoords.Tag = Nothing

            If BOTRes.DetectableResourcesFast.ContainsKey(cboElement.Text) Then
                For Each pt As Point In BOTRes.DetectableResourcesFast(cboElement.Text)
                    lvScreenCoords.Items.Add(pt.ToString).Tag = pt
                Next
            End If
        ElseIf cboCategory.Text = "Color Check" Then
            Dim cCheck As BOTResources.ColorCheck = BOTRes.ColorCheckResources(cboElement.Text)
            With cCheck
                Select Case .Operation
                    Case BOTResources.ColorCheck.enOperation.AvgBrightness
                        optAvgBrightness.Checked = True
                    Case BOTResources.ColorCheck.enOperation.AvgColor
                        optAvgColor.Checked = True
                    Case BOTResources.ColorCheck.enOperation.SumColor
                        optSumColor.Checked = True
                End Select
                cboCondition.SelectedIndex = cboCondition.FindStringExact(.Condition)
                lblSelectedValue.Text = "Selected Value: " & .SelectedValue
                udCondition.Value = .ConditionValue
                lblArea.Text = "Area: " & .Area.Left & ", " & .Area.Right & ", " & .Area.Top & ", " & .Area.Bottom
            End With
        End If
    End Sub

    Private Sub picBuffer_Click(sender As Object, e As EventArgs) Handles picBuffer.Click

    End Sub

    Private Sub picBuffer_Paint(sender As Object, e As PaintEventArgs) Handles picBuffer.Paint
        If Not PointA.IsEmpty AndAlso Not PointB.IsEmpty Then
            With e.Graphics
                Dim p1 As Point = New Point(PointA.X * Zoom, PointA.Y * Zoom)
                Dim p2 As Point = New Point(PointB.X * Zoom, PointB.Y * Zoom)

                Dim top As Integer
                Dim left As Integer
                Dim right As Integer
                Dim bottom As Integer

                If p1.Y < p2.Y Then
                    top = p1.Y
                    bottom = p2.Y
                Else
                    top = p2.Y
                    bottom = p1.Y
                End If

                If p1.X < p2.X Then
                    left = p1.X
                    right = p2.X
                Else
                    left = p2.X
                    right = p1.X
                End If


                Using p As New Pen(Brushes.Red, 2)
                    p.DashStyle = Drawing2D.DashStyle.Dash
                    .DrawRectangle(p, Rectangle.FromLTRB(left, top, right, bottom))
                End Using
            End With
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lvElements.SelectedItems.Count = 0 Then
            MsgBox("Select the items to remove!", MsgBoxStyle.Critical)
            Return
        End If

        For I As Integer = lvElements.Items.Count - 1 To 0 Step -1
            If lvElements.Items(I).Selected Then
                Dim FName As String = IO.Path.Combine(ResourcesPath, lvElements.Items(I).Text & ".png")
                BOTRes.RemoveFromCache(lvElements.Items(I).Text)
                Dim b As Bitmap = picSelected.Image
                picSelected.Image = Nothing
                picSelected.Refresh()
                b.Dispose()

                Try
                    If IO.File.Exists(FName) Then
                        IO.File.Delete(FName)
                    End If
                Catch ex As Exception

                End Try
                BOTRes.DetectableResources(cboElement.Text).Remove(lvElements.Items(I).Text)
                lvElements.Items.RemoveAt(I)
            End If
        Next
        BOTRes.Save()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If picSelected.Image Is Nothing Then
            MsgBox("Select an image template to add!", MsgBoxStyle.Critical)
            Return
        End If

        Dim ElementName As String = cboElement.Text & "_" & Now.ToString("ddMMyyyyHHmmss")
        Dim fName As String = IO.Path.Combine(ResourcesPath, ElementName & ".png")
        BOTRes.DetectableResources(cboElement.Text).Add(ElementName)
        BOTRes.Save()

        picSelected.Image.Save(fName, Imaging.ImageFormat.Png)
        lvElements.Items.Add(ElementName)

        picSelected.Image = Nothing
    End Sub

    Private Sub lvElements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvElements.SelectedIndexChanged
        If lvElements.SelectedItems.Count = 0 Then Return

        Dim fName As String = IO.Path.Combine(ResourcesPath, lvElements.SelectedItems(0).Text & ".png")
        If IO.File.Exists(fName) Then
            picSelected.Image = Bitmap.FromFile(fName)
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub optAvgColor_CheckedChanged(sender As Object, e As EventArgs) Handles optAvgColor.CheckedChanged
        If cboElement.SelectedIndex = -1 Then Return
        If Not BOTRes.ColorCheckResources.ContainsKey(cboElement.Text) Then Return
        If Not optAvgColor.Checked Then Return

        BOTRes.ColorCheckResources(cboElement.Text).Operation = BOTResources.ColorCheck.enOperation.AvgColor
        BOTRes.Save()

        UpdateValue()
    End Sub

    Private Sub optSumColor_CheckedChanged(sender As Object, e As EventArgs) Handles optSumColor.CheckedChanged
        If cboElement.SelectedIndex = -1 Then Return
        If Not BOTRes.ColorCheckResources.ContainsKey(cboElement.Text) Then Return
        If Not optSumColor.Checked Then Return

        BOTRes.ColorCheckResources(cboElement.Text).Operation = BOTResources.ColorCheck.enOperation.SumColor
        BOTRes.Save()

        UpdateValue()
    End Sub

    Private Sub optAvgBrightness_CheckedChanged(sender As Object, e As EventArgs) Handles optAvgBrightness.CheckedChanged
        If cboElement.SelectedIndex = -1 Then Return
        If Not BOTRes.ColorCheckResources.ContainsKey(cboElement.Text) Then Return
        If Not optAvgBrightness.Checked Then Return

        BOTRes.ColorCheckResources(cboElement.Text).Operation = BOTResources.ColorCheck.enOperation.AvgBrightness
        BOTRes.Save()

        UpdateValue()
    End Sub

    Private Sub cboCondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCondition.SelectedIndexChanged
        If cboElement.SelectedIndex = -1 Then Return
        If Not BOTRes.ColorCheckResources.ContainsKey(cboElement.Text) Then Return
        If cboCondition.SelectedIndex = -1 Then Return

        BOTRes.ColorCheckResources(cboElement.Text).Condition = cboCondition.Text
        BOTRes.Save()

    End Sub

    Private Sub udCondition_ValueChanged(sender As Object, e As EventArgs) Handles udCondition.ValueChanged
        If cboElement.SelectedIndex = -1 Then Return
        If Not BOTRes.ColorCheckResources.ContainsKey(cboElement.Text) Then Return

        BOTRes.ColorCheckResources(cboElement.Text).ConditionValue = udCondition.Value
        BOTRes.Save()
    End Sub

    Private Sub UpdateValue()
        If BitmapColorCheck Is Nothing Then Return

        Dim Val As Long = 0
        Dim Area As Rectangle = New Rectangle(0, 0, BitmapColorCheck.Width, BitmapColorCheck.Height)

        If optAvgColor.Checked Then
            Val = BitmapTools.AvgColor(BitmapColorCheck, Area)
        End If
        If optSumColor.Checked Then
            Val = BitmapTools.SumColor(BitmapColorCheck, Area)
        End If
        If optAvgBrightness.Checked Then
            Val = BitmapTools.AvgBrightness(BitmapColorCheck, Area)
        End If
        lblSelectedValue.Text = "Selected Value: " & Val
        BOTRes.ColorCheckResources(cboElement.Text).SelectedValue = Val
        BOTRes.Save()

        udCondition.Value = Val
    End Sub

    Private Sub btnElementAddScreenCoords_Click(sender As Object, e As EventArgs) Handles btnElementAddScreenCoords.Click
        If txtElementScreenCoords.Text = "" Then
            txtElementScreenCoords.Tag = Nothing
            MsgBox("Pick a coordinate first!", MsgBoxStyle.Critical)
        End If

        Dim pt As Point = txtElementScreenCoords.Tag
        lvScreenCoords.Items.Add(pt.ToString).Tag = pt
        If Not BOTRes.DetectableResourcesFast.ContainsKey(cboElement.Text) Then
            BOTRes.DetectableResourcesFast.Add(cboElement.Text, New List(Of Point))
        End If

        BOTRes.DetectableResourcesFast(cboElement.Text).Add(pt)
        BOTRes.Save()
    End Sub

    Private Sub btnElementRemoveScreenCoords_Click(sender As Object, e As EventArgs) Handles btnElementRemoveScreenCoords.Click
        If lvScreenCoords.SelectedItems.Count = 0 Then
            MsgBox("Select the items to remove!", MsgBoxStyle.Critical)
            Return
        End If

        For I As Integer = lvScreenCoords.Items.Count - 1 To 0 Step -1
            If lvScreenCoords.Items(I).Selected Then
                Dim pt As Point = lvScreenCoords.Items(I).Tag
                BOTRes.DetectableResourcesFast(cboElement.Text).Remove(pt)
                lvScreenCoords.Items.RemoveAt(I)
            End If
        Next
        BOTRes.Save()
    End Sub
End Class