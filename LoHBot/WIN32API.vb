Imports System.Runtime.InteropServices

Public Class GDI32
    Public Const SRCCOPY As Integer = &HCC0020
    <DllImport("gdi32.dll")> _
    Public Shared Function BitBlt(ByVal hObject As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hObjectSource As IntPtr, _
    ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Integer) As Boolean
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function CreateCompatibleBitmap(ByVal hDC As IntPtr, ByVal nWidth As Integer, ByVal nHeight As Integer) As IntPtr
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function DeleteDC(ByVal hDC As IntPtr) As Boolean
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
    End Function
    <DllImport("gdi32.dll")> _
    Public Shared Function SelectObject(ByVal hDC As IntPtr, ByVal hObject As IntPtr) As IntPtr
    End Function
End Class

Public Class DWM
    <DllImport("dwmapi.dll")> _
    Public Shared Function DwmEnableComposition(ByVal uCompositionAction As CompositionAction) As UInteger
    End Function

    <DllImport("dwmapi.dll", PreserveSig:=False)> _
    Public Shared Function DwmIsCompositionEnabled() As Boolean
    End Function

    Public Enum CompositionAction As UInteger
        DWM_EC_DISABLECOMPOSITION = 0
        DWM_EC_ENABLECOMPOSITION = 1
    End Enum

End Class

Public Class User32
    Public Const SW_SHOWDEFAULT As System.Int32 = 10

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    <DllImport("user32.dll")>
    Public Shared Function ShowWindow(<System.Runtime.InteropServices.In()> ByVal hWnd As System.IntPtr, <System.Runtime.InteropServices.In()> ByVal nCmdShow As System.Int32) As System.Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function FindWindowEx(ByVal parentHandle As IntPtr,
                      ByVal childAfter As IntPtr,
                      ByVal lclassName As String,
                      ByVal windowTitle As String) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function FindWindowByCaption(
     ByVal zero As IntPtr,
     ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Int32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Int32, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetClassName(ByVal hWnd As System.IntPtr, ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowText")>
    Public Shared Function GetWindowText(ByVal hwnd As Integer, ByVal lpString As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll")>
    Public Shared Function GetDesktopWindow() As IntPtr
    End Function
    <DllImport("user32.dll")>
    Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rect As RECT) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetClientRect(ByVal hWnd As IntPtr, ByRef rect As RECT) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function PrintWindow(ByVal hwnd As IntPtr, ByVal hDC As IntPtr, ByVal nFlags As UInteger) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function SetLayeredWindowAttributes(ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal Alpha As Byte, ByVal dwFlags As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> ByVal nIndex As WindowLongFlags, ByVal dwNewLong As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> ByVal nIndex As WindowLongFlags) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
    End Function

    Public Enum WindowLongFlags As Integer
        GWL_EXSTYLE = -20
        GWLP_HINSTANCE = -6
        GWLP_HWNDPARENT = -8
        GWL_ID = -12
        GWL_STYLE = -16
        GWL_USERDATA = -21
        GWL_WNDPROC = -4
        DWLP_USER = &H8
        DWLP_MSGRESULT = &H0
        DWLP_DLGPROC = &H4
    End Enum

    Public Declare Auto Function SetCursorPos Lib "User32.dll" (ByVal X As Integer, ByVal Y As Integer) As Integer
    Public Declare Auto Function GetCursorPos Lib "User32.dll" (ByRef lpPoint As Point) As Integer
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Public Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Public Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    Public Const MOUSEEVENTF_MIDDLEDOWN = &H20 ' middle button down
    Public Const MOUSEEVENTF_MIDDLEUP = &H40 ' middle button up
    Public Const MOUSEEVENTF_RIGHTDOWN = &H8 ' right button down
    Public Const MOUSEEVENTF_RIGHTUP = &H10 ' right button up

    Public Const GWL_EXSTYLE As Integer = -20
    Public Const WS_EX_LAYERED As Integer = &H80000
    Public Const LWA_ALPHA As Integer = &H2
    Public Const LWA_COLORKEY As Integer = &H1

End Class

Public Class Kernel32
    Private is64BitProcess As Boolean = (IntPtr.Size = 8)
    Private is64BitOperatingSystem As Boolean = is64BitProcess OrElse InternalCheckIsWow64()

    <DllImport("Kernel32.dll", SetLastError:=True, CallingConvention:=CallingConvention.Winapi)> _
    Public Shared Function IsWow64Process(ByVal hProcess As IntPtr, ByRef wow64Process As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Shared Function InternalCheckIsWow64() As Boolean
        If (Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor >= 1) OrElse Environment.OSVersion.Version.Major >= 6 Then
            Using p As Process = Process.GetCurrentProcess()
                Dim retVal As Boolean
                If Not IsWow64Process(p.Handle, retVal) Then
                    Return False
                End If
                Return retVal
            End Using
        Else
            Return False
        End If
    End Function
End Class