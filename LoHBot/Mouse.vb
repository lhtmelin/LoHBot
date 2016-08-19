Module Mouse
    'Public Function MouseLeftDown(ByVal x As Integer, ByVal y As Integer) As Integer
    '    Dim handle As IntPtr = GetBluestacksWindow()
    '    Dim lParam As IntPtr = ((x And &HFFFF) Or ((y And &HFFFF) << 16))
    '    Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)

    '    Return leftMouseDown.ToInt32
    'End Function

    'Public Function MouseLeftDown(ByVal pt As Point) As Integer
    '    Return MouseLeftDown(pt.X, pt.Y)
    'End Function

    'Public Function MouseLeftUp(ByVal x As Integer, ByVal y As Integer) As Integer
    '    Dim handle As IntPtr = GetBluestacksWindow()
    '    Dim lParam As IntPtr = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '    Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

    '    Return leftMouseUp.ToInt32
    'End Function

    'Public Function MouseDeltaWheel(ByVal x As Integer, ByVal y As Integer, ByVal Delta As Integer) As Integer
    '    Dim handle As IntPtr = GetBluestacksWindow()
    '    Dim lParam As IntPtr = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '    Dim lDelta As IntPtr = ((Delta << 16))

    '    Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H20A, lDelta, lParam)

    '    Return leftMouseUp.ToInt32
    'End Function

    'Public Function MouseLeftUp(ByVal pt As Point) As Integer
    '    Return MouseLeftUp(pt.X, pt.Y)
    'End Function

    'Public Function MouseLeftClick(ByVal x As Integer, ByVal y As Integer) As Integer
    '    Dim handle As IntPtr = GetBluestacksWindow()
    '    Dim lParam As IntPtr = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '    Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
    '    Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

    '    Return leftMouseDown.ToInt32 And leftMouseUp.ToInt32
    'End Function

    'Public Function MouseLeftClick(ByVal pt As Point) As Integer
    '    Return MouseLeftClick(pt.X, pt.Y)
    'End Function

    'Public Function MouseLeftDrag(ByVal x_start As Integer, ByVal y_start As Integer, ByVal x_end As Integer, ByVal y_end As Integer, Optional ByVal WaitDropTime As Integer = 0) As Integer
    '    Dim abs_delta_x As Integer = Math.Abs(x_end - x_start)
    '    Dim abs_delta_y As Integer = Math.Abs(y_end - y_start)
    '    Dim step_direction As Integer = 0

    '    Dim handle As IntPtr = GetBluestacksWindow()
    '    Dim lParam As IntPtr

    '    Dim delta_z As Single = 0
    '    If abs_delta_x > abs_delta_y Then

    '        delta_z = Convert.ToSingle(abs_delta_y) / Convert.ToSingle(abs_delta_x)

    '        Dim stp As Integer = (abs_delta_x / 100)
    '        If stp < 1 Then stp = 1

    '        If x_start > x_end Then
    '            step_direction = stp * -1
    '        Else
    '            step_direction = stp * 1
    '        End If

    '        Dim i As Integer = 0
    '        Dim y As Integer = 0
    '        Dim x As Integer = 0
    '        For x = x_start To x_end Step step_direction
    '            If y_start > y_end Then
    '                y = y_start - (i * delta_z)
    '            Else
    '                y = y_start + (i * delta_z)
    '            End If

    '            lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '            Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
    '            Threading.Thread.Sleep(15)

    '            i += 1

    '            Application.DoEvents()
    '        Next

    '        If WaitDropTime <> 0 Then
    '            Threading.Thread.Sleep(WaitDropTime * 1000)
    '        End If
    '        lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '        Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

    '    Else
    '        delta_z = Convert.ToSingle(abs_delta_x) / Convert.ToSingle(abs_delta_y)

    '        Dim stp As Integer = (abs_delta_y / 100)
    '        If stp < 1 Then stp = 1

    '        If y_start > y_end Then
    '            step_direction = stp * -1
    '        Else
    '            step_direction = stp * 1
    '        End If

    '        Dim i As Integer = 0
    '        Dim x As Integer = 0
    '        Dim y As Integer = 0
    '        For y = y_start To y_end Step step_direction
    '            If x_start > x_end Then
    '                x = x_start - (i * delta_z)
    '            Else
    '                x = x_start + (i * delta_z)
    '            End If

    '            lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '            Dim leftMouseDown As IntPtr = User32.SendMessage(handle, &H201, IntPtr.Zero, lParam)
    '            Threading.Thread.Sleep(15)

    '            i += 1
    '            Application.DoEvents()
    '        Next

    '        If WaitDropTime <> 0 Then
    '            Threading.Thread.Sleep(WaitDropTime * 1000)
    '        End If
    '        lParam = (((x) And &HFFFF) Or (((y) And &HFFFF) << 16))
    '        Dim leftMouseUp As IntPtr = User32.SendMessage(handle, &H202, IntPtr.Zero, lParam)

    '    End If

    'End Function
    'Public Function MouseLeftDrag(ByVal start As Point, ByVal [end] As Point, Optional ByVal WaitDropTime As Integer = 0) As Integer
    '    Return MouseLeftDrag(start.X, start.Y, [end].X, [end].Y, WaitDropTime)
    'End Function
End Module
