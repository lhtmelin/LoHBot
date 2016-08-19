Public Class BOTSettings
    Public Property AutoTowerHunt As Boolean = False
    Public Property AutoTower As Boolean = False
    Public Property AutoTowerRegular As Boolean = False
    Public Property AutoTowerHard As Boolean = False
    Public Property AutoTowerHard_ClimbMode As Boolean = False
    Public Property AutoTower_QuickBattle As Boolean = False
    Public Property AutoTower_Floor As Integer = 1
    Public Property AutoTower_SubFloor As Integer = 1
    Public Property AutoTower_Coop As Boolean = False
    Public Property AutoTower_CoopActive As Boolean = False
    Public Property AutoTower_CoopPassive As Boolean = False
    Public Property AutoTower_CoopAnyonePartner As Boolean = False
    Public Property AutoTower_CoopSpecificPartner As Boolean = False
    Public Property AutoTower_CoopPartners As New List(Of String)

    Public Property AutoHunt As Boolean = False
    Public Property AutoHuntSettings As New Dictionary(Of String, MonsterSettings)
    Public Property AutoHuntSelected As MonsterSettings

    Public Property InfiniteBattle As Boolean = False
    Public Property ColiBattle As Boolean = False
    Public Property GuildMineDeploy As Boolean = False
    Public Property GuildMineDeploy_MaxTroops As Integer = 8
    Public Property GuildMineDeploy_Gold As Boolean = False
    Public Property GuildMineDeploy_GoldMin As Integer = 2500
    Public Property GuildMineDeploy_Rune As Boolean = False
    Public Property GuildMineDeploy_RuneMin As Integer = 1500

    Public Property AutoSell As Boolean = False
    Public Property AutoSellEverything As Boolean = True
    Public Property AutoSellFilter As Boolean = False
    Public Property AutoSellFilterItems As String = "Adventure;Militia;Warlord;Gladiator;Golden;War God;Judgment;Ascended;Demigod;Ragnarok"
    Public Property AutoBuyRuneEssence As Boolean = False
    Public Property AutoMineClaim As Boolean = False
    Public Property AutoReadMessage As Boolean = False

    Public Property FodderSwap As Boolean = False
    Public Property FodderSwapPosition As Integer = 6
    Public Property FodderSwapGear As Boolean = True

    Public Property TimeoutFreeze As Integer = 30
    Public Property TimeoutSell As Integer = 10
    Public Property TimeoutColi As Integer = 30
    Public Property TimeoutInfBattle As Integer = 30

    Public Property EnableFastImageDetection As Boolean = False

    Public Property NextPlayedFloor As Integer = 0
    Public Property NextPlayedSubFloor As Integer = 0
    Public Property NextPlayedFloorTypeIndex As Integer = 0
    Public Property NextPlayedFloorType As String = ""

    Public Property LastPlayedFloor As Integer = 0
    Public Property LastPlayedSubFloor As Integer = 0
    Public Property LastPlayedFloorTypeIndex As Integer = 0
    Public Property LastPlayedFloorType As String = ""

    Public Sub Save(Filename As String)
        IO.File.WriteAllText(Filename, Newtonsoft.Json.JsonConvert.SerializeObject(Me, Newtonsoft.Json.Formatting.Indented), System.Text.Encoding.UTF8)
    End Sub
    Public Sub Save()
        Dim Filename As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "lohbot.conf")
        Save(Filename)
    End Sub

    Public Sub Load()
        Dim Filename As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "lohbot.conf")
        Load(Filename)
    End Sub
    Public Sub Load(Filename As String)
        If Not IO.File.Exists(Filename) Then Return
        Dim o As BOTSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(IO.File.ReadAllText(Filename, System.Text.Encoding.UTF8), GetType(BOTSettings))

        Dim t As Type = GetType(BOTSettings)
        For Each p As System.Reflection.FieldInfo In t.GetFields(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Public Or System.Reflection.BindingFlags.Instance)
            p.SetValue(Me, p.GetValue(o))
        Next
    End Sub

End Class
