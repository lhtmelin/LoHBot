Imports LoHBot

Public Class Emulator
    Implements IEmulator, IDisposable

    Private Sub Release()
        If Not BaseEmu Is Nothing Then
            BaseEmu.Dispose()
        End If
    End Sub

    Public Sub New(Base As IEmulator)
        BaseEmu = Base
    End Sub

    Private BaseEmu As IEmulator = Nothing
    Public ReadOnly Property Version As Version Implements IEmulator.Version
        Get
            Return BaseEmu.Version
        End Get
    End Property

    Public Sub FixEmulatorResolution() Implements IEmulator.FixEmulatorResolution
        BaseEmu.FixEmulatorResolution()
    End Sub

    Public Sub MouseLeftClick(pt As Point) Implements IEmulator.MouseLeftClick
        BaseEmu.MouseLeftClick(pt)
    End Sub

    Public Sub MouseLeftClick(x As Integer, y As Integer) Implements IEmulator.MouseLeftClick
        BaseEmu.MouseLeftClick(x, y)
    End Sub

    Public Sub MouseLeftDrag(start As Point, [end] As Point, Optional WaitDropTime As Integer = 0) Implements IEmulator.MouseLeftDrag
        BaseEmu.MouseLeftDrag(start, [end], WaitDropTime)
    End Sub

    Public Sub MouseLeftDrag(x_start As Integer, y_start As Integer, x_end As Integer, y_end As Integer, Optional WaitDropTime As Integer = 0) Implements IEmulator.MouseLeftDrag
        BaseEmu.MouseLeftDrag(x_start, y_start, x_end, y_end, WaitDropTime)
    End Sub

    Public Function GetBuffer() As Image(Of Bgr, Byte) Implements IEmulator.GetBuffer
        Return BaseEmu.GetBuffer
    End Function

    Public Function GetEmulatorResolution() As Point Implements IEmulator.GetEmulatorResolution
        Return BaseEmu.GetEmulatorResolution
    End Function

    Public Function IsEmulatorResolutionCorrect() As Boolean Implements IEmulator.IsEmulatorResolutionCorrect
        Return BaseEmu.IsEmulatorResolutionCorrect
    End Function

    Public Function IsEmulatorRunning() As Boolean Implements IEmulator.IsEmulatorRunning
        Return BaseEmu.IsEmulatorRunning
    End Function

    Public Function IsGameRunning() As Boolean Implements IEmulator.IsGameRunning
        Return BaseEmu.IsGameRunning
    End Function

    Public Function RunADB(Command As String, ByRef ReturnData As String) As Boolean Implements IEmulator.RunADB
        Return BaseEmu.RunADB(Command, ReturnData)
    End Function

    Public Function StartEmulator() As Boolean Implements IEmulator.StartEmulator
        Return BaseEmu.StartEmulator
    End Function

    Public Function StartGame() As Boolean Implements IEmulator.StartGame
        Return BaseEmu.StartGame
    End Function

    Public Function StopEmulator() As Boolean Implements IEmulator.StopEmulator
        Return BaseEmu.StopEmulator
    End Function

    Public Function StopGame() As Boolean Implements IEmulator.StopGame
        Return BaseEmu.StopGame
    End Function

    Private disposedValue As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                Release()
            End If
            Release()
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose, IEmulator.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function GetHWnd() As IntPtr Implements IEmulator.GetHWnd
        Return BaseEmu.GetHWnd
    End Function
    Public Function Clone() As IEmulator Implements IEmulator.Clone
        Return New Emulator(BaseEmu.Clone)
    End Function
    Public Overrides Function ToString() As String Implements IEmulator.ToString
        Return BaseEmu.ToString
    End Function

    Public Sub BringToFront() Implements IEmulator.BringToFront
        BaseEmu.BringToFront()
    End Sub

    Public Sub SendKeys(keys As String) Implements IEmulator.SendKeys
        BaseEmu.SendKeys(keys)
    End Sub
End Class
