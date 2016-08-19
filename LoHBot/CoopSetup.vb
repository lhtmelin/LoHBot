Public Class CoopSetup
    Private Sub CoopSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CFG.AutoTower_Floor = 0 Then CFG.AutoTower_Floor = 1
        If CFG.AutoTower_SubFloor = 0 Then CFG.AutoTower_SubFloor = 1

        cboFloor.SelectedIndex = cboFloor.FindStringExact(CFG.AutoTower_Floor.ToString)
        cboSubfloor.SelectedIndex = cboSubfloor.FindStringExact(CFG.AutoTower_SubFloor.ToString)

        optActive.Checked = CFG.AutoTower_CoopActive
        optPassive.Checked = CFG.AutoTower_CoopPassive

        optAnyone.Checked = CFG.AutoTower_CoopAnyonePartner
        optSpecific.Checked = CFG.AutoTower_CoopSpecificPartner

        For Each s As String In CFG.AutoTower_CoopPartners
            lstPlayers.Items.Add(s)
        Next
    End Sub

    Private Sub optSpecific_CheckedChanged(sender As Object, e As EventArgs) Handles optSpecific.CheckedChanged
        gbPlayers.Enabled = optSpecific.Checked
        CFG.AutoTower_CoopSpecificPartner = optSpecific.Checked
        CFG.AutoTower_CoopAnyonePartner = optAnyone.Checked
        CFG.Save()
    End Sub

    Private Sub optAnyone_CheckedChanged(sender As Object, e As EventArgs) Handles optAnyone.CheckedChanged
        gbPlayers.Enabled = optSpecific.Checked
        CFG.AutoTower_CoopSpecificPartner = optSpecific.Checked
        CFG.AutoTower_CoopAnyonePartner = optAnyone.Checked
        CFG.Save()
    End Sub

    Private Sub cboFloor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFloor.SelectedIndexChanged
        If cboFloor.SelectedIndex = -1 Then Return
        CFG.AutoTower_Floor = Integer.Parse(cboFloor.Text)
        CFG.Save()
    End Sub

    Private Sub cboSubfloor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubfloor.SelectedIndexChanged
        If cboSubfloor.SelectedIndex = -1 Then Return
        CFG.AutoTower_SubFloor = Integer.Parse(cboSubfloor.Text)
        CFG.Save()
    End Sub

    Private Sub optActive_CheckedChanged(sender As Object, e As EventArgs) Handles optActive.CheckedChanged
        CFG.AutoTower_CoopActive = optActive.Checked
        CFG.AutoTower_CoopPassive = optPassive.Checked
        CFG.Save()
    End Sub

    Private Sub optPassive_CheckedChanged(sender As Object, e As EventArgs) Handles optPassive.CheckedChanged
        CFG.AutoTower_CoopActive = optActive.Checked
        CFG.AutoTower_CoopPassive = optPassive.Checked
        CFG.Save()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtPlayer.Text.Trim = "" Then Return
        If lstPlayers.Items.Contains(txtPlayer.Text) Then Return
        lstPlayers.Items.Add(txtPlayer.Text.Trim)
        CFG.AutoTower_CoopPartners.Clear()
        For Each s As String In lstPlayers.Items
            CFG.AutoTower_CoopPartners.Add(s)
        Next

        CFG.Save()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lstPlayers.ClearSelected()
        CFG.AutoTower_CoopPartners.Clear()
        For Each s As String In lstPlayers.Items
            CFG.AutoTower_CoopPartners.Add(s)
        Next
        CFG.Save()
    End Sub
End Class