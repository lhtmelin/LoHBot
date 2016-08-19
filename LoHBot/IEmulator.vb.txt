Public Interface IEmulator
    Enum enEmulatorType As Integer
        Bluestacks0 = 0
        Bluestacks2 = 1
    End Enum

    ReadOnly Property Version As Version
    Function GetBuffer() As Image(Of Bgr, Byte)
    Function GetEmulatorResolution() As Point
    Function IsEmulatorResolutionCorrect() As Boolean
    Function IsEmulatorRunning() As Boolean
    Function IsGameRunning() As Boolean
    Function StopEmulator() As Boolean
    Function StartEmulator() As Boolean
    Function RunADB(Command As String, ByRef ReturnData As String) As Boolean
    Function GetHWnd() As IntPtr
    Sub BringToFront()
    Sub SendKeys(keys As String)

    Function StopGame() As Boolean
    Function StartGame() As Boolean

    Sub FixEmulatorResolution()
    Sub MouseLeftClick(x As Integer, y As Integer)
    Sub MouseLeftClick(pt As Point)

    Sub MouseLeftDrag(ByVal x_start As Integer, ByVal y_start As Integer, ByVal x_end As Integer, ByVal y_end As Integer, Optional ByVal WaitDropTime As Integer = 0)
    Sub MouseLeftDrag(ByVal start As Point, ByVal [end] As Point, Optional ByVal WaitDropTime As Integer = 0)
    Sub Dispose()
    Function Clone() As IEmulator
    Function ToString() As String

End Interface
