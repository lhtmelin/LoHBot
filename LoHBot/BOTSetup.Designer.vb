<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BOTSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tlbSetup = New System.Windows.Forms.ToolStrip()
        Me.btnLiveUpdate = New System.Windows.Forms.ToolStripButton()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.btnRestoreZoom = New System.Windows.Forms.ToolStripButton()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlblblScreenCoords = New System.Windows.Forms.ToolStripLabel()
        Me.pnlBuffer = New System.Windows.Forms.Panel()
        Me.picBuffer = New System.Windows.Forms.PictureBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.cboElement = New System.Windows.Forms.ComboBox()
        Me.tcConfig = New System.Windows.Forms.TabControl()
        Me.tpClick = New System.Windows.Forms.TabPage()
        Me.lblScreenCoords = New System.Windows.Forms.Label()
        Me.txtScreenCoords = New System.Windows.Forms.TextBox()
        Me.tpElement = New System.Windows.Forms.TabPage()
        Me.lvElements = New System.Windows.Forms.ListView()
        Me.chElement = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblSelectedElement = New System.Windows.Forms.Label()
        Me.pnlSelectedElement = New System.Windows.Forms.Panel()
        Me.picSelected = New System.Windows.Forms.PictureBox()
        Me.tpColorCheck = New System.Windows.Forms.TabPage()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.udCondition = New System.Windows.Forms.NumericUpDown()
        Me.lblReturnTRUE = New System.Windows.Forms.Label()
        Me.lblSelectedValue = New System.Windows.Forms.Label()
        Me.optAvgBrightness = New System.Windows.Forms.RadioButton()
        Me.optSumColor = New System.Windows.Forms.RadioButton()
        Me.optAvgColor = New System.Windows.Forms.RadioButton()
        Me.lblOperation = New System.Windows.Forms.Label()
        Me.lblColorSelected = New System.Windows.Forms.Label()
        Me.pnlColorSelectedElement = New System.Windows.Forms.Panel()
        Me.picColorSelected = New System.Windows.Forms.PictureBox()
        Me.tmr_liveupdate = New System.Windows.Forms.Timer(Me.components)
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblElementScreenCoords = New System.Windows.Forms.Label()
        Me.txtElementScreenCoords = New System.Windows.Forms.TextBox()
        Me.lvScreenCoords = New System.Windows.Forms.ListView()
        Me.chScreenCoords = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnElementRemoveScreenCoords = New System.Windows.Forms.Button()
        Me.btnElementAddScreenCoords = New System.Windows.Forms.Button()
        Me.tlbSetup.SuspendLayout()
        Me.pnlBuffer.SuspendLayout()
        CType(Me.picBuffer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcConfig.SuspendLayout()
        Me.tpClick.SuspendLayout()
        Me.tpElement.SuspendLayout()
        Me.pnlSelectedElement.SuspendLayout()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpColorCheck.SuspendLayout()
        CType(Me.udCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlColorSelectedElement.SuspendLayout()
        CType(Me.picColorSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbSetup
        '
        Me.tlbSetup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLiveUpdate, Me.sep1, Me.btnZoomIn, Me.btnZoomOut, Me.btnRestoreZoom, Me.sep2, Me.btnRefresh, Me.sep3, Me.tlblblScreenCoords})
        Me.tlbSetup.Location = New System.Drawing.Point(0, 0)
        Me.tlbSetup.Name = "tlbSetup"
        Me.tlbSetup.Size = New System.Drawing.Size(1384, 25)
        Me.tlbSetup.TabIndex = 18
        Me.tlbSetup.Text = "ToolStrip1"
        '
        'btnLiveUpdate
        '
        Me.btnLiveUpdate.CheckOnClick = True
        Me.btnLiveUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLiveUpdate.Image = Global.LoHBot.My.Resources.Resources.arrow_refresh
        Me.btnLiveUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLiveUpdate.Name = "btnLiveUpdate"
        Me.btnLiveUpdate.Size = New System.Drawing.Size(23, 22)
        Me.btnLiveUpdate.Text = "Live Update"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        Me.sep1.Size = New System.Drawing.Size(6, 25)
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = Global.LoHBot.My.Resources.Resources.zoom_in
        Me.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomIn.Text = "Zoom In"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = Global.LoHBot.My.Resources.Resources.zoom_out
        Me.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomOut.Text = "Zoom Out"
        '
        'btnRestoreZoom
        '
        Me.btnRestoreZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRestoreZoom.Image = Global.LoHBot.My.Resources.Resources.zoom
        Me.btnRestoreZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRestoreZoom.Name = "btnRestoreZoom"
        Me.btnRestoreZoom.Size = New System.Drawing.Size(23, 22)
        Me.btnRestoreZoom.Text = "Restore Zoom (100%)"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        Me.sep2.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefresh.Image = Global.LoHBot.My.Resources.Resources.monitor
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(23, 22)
        Me.btnRefresh.Text = "Update Screen"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        Me.sep3.Size = New System.Drawing.Size(6, 25)
        '
        'tlblblScreenCoords
        '
        Me.tlblblScreenCoords.Name = "tlblblScreenCoords"
        Me.tlblblScreenCoords.Size = New System.Drawing.Size(88, 22)
        Me.tlblblScreenCoords.Text = "ToolStripLabel1"
        '
        'pnlBuffer
        '
        Me.pnlBuffer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBuffer.AutoScroll = True
        Me.pnlBuffer.BackColor = System.Drawing.Color.Black
        Me.pnlBuffer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBuffer.Controls.Add(Me.picBuffer)
        Me.pnlBuffer.Location = New System.Drawing.Point(12, 35)
        Me.pnlBuffer.Name = "pnlBuffer"
        Me.pnlBuffer.Size = New System.Drawing.Size(1039, 604)
        Me.pnlBuffer.TabIndex = 19
        '
        'picBuffer
        '
        Me.picBuffer.Cursor = System.Windows.Forms.Cursors.Cross
        Me.picBuffer.Location = New System.Drawing.Point(0, 0)
        Me.picBuffer.Name = "picBuffer"
        Me.picBuffer.Size = New System.Drawing.Size(960, 600)
        Me.picBuffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBuffer.TabIndex = 17
        Me.picBuffer.TabStop = False
        '
        'lblCategory
        '
        Me.lblCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(1058, 37)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblCategory.TabIndex = 20
        Me.lblCategory.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Clickable Objects", "Element Detection", "Color Check"})
        Me.cboCategory.Location = New System.Drawing.Point(1114, 37)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(258, 21)
        Me.cboCategory.TabIndex = 21
        '
        'lblElement
        '
        Me.lblElement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(1058, 67)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(45, 13)
        Me.lblElement.TabIndex = 22
        Me.lblElement.Text = "Element"
        '
        'cboElement
        '
        Me.cboElement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboElement.FormattingEnabled = True
        Me.cboElement.Items.AddRange(New Object() {"Clickable Objects", "Element Detection"})
        Me.cboElement.Location = New System.Drawing.Point(1114, 64)
        Me.cboElement.Name = "cboElement"
        Me.cboElement.Size = New System.Drawing.Size(228, 21)
        Me.cboElement.Sorted = True
        Me.cboElement.TabIndex = 23
        '
        'tcConfig
        '
        Me.tcConfig.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcConfig.Controls.Add(Me.tpClick)
        Me.tcConfig.Controls.Add(Me.tpElement)
        Me.tcConfig.Controls.Add(Me.tpColorCheck)
        Me.tcConfig.Location = New System.Drawing.Point(1061, 91)
        Me.tcConfig.Name = "tcConfig"
        Me.tcConfig.SelectedIndex = 0
        Me.tcConfig.Size = New System.Drawing.Size(311, 546)
        Me.tcConfig.TabIndex = 24
        '
        'tpClick
        '
        Me.tpClick.Controls.Add(Me.lblScreenCoords)
        Me.tpClick.Controls.Add(Me.txtScreenCoords)
        Me.tpClick.Location = New System.Drawing.Point(4, 22)
        Me.tpClick.Name = "tpClick"
        Me.tpClick.Padding = New System.Windows.Forms.Padding(3)
        Me.tpClick.Size = New System.Drawing.Size(303, 520)
        Me.tpClick.TabIndex = 0
        Me.tpClick.Text = "Clickable Element"
        Me.tpClick.UseVisualStyleBackColor = True
        '
        'lblScreenCoords
        '
        Me.lblScreenCoords.AutoSize = True
        Me.lblScreenCoords.Location = New System.Drawing.Point(6, 3)
        Me.lblScreenCoords.Name = "lblScreenCoords"
        Me.lblScreenCoords.Size = New System.Drawing.Size(77, 13)
        Me.lblScreenCoords.TabIndex = 1
        Me.lblScreenCoords.Text = "Screen Coords"
        '
        'txtScreenCoords
        '
        Me.txtScreenCoords.Location = New System.Drawing.Point(9, 19)
        Me.txtScreenCoords.Name = "txtScreenCoords"
        Me.txtScreenCoords.ReadOnly = True
        Me.txtScreenCoords.Size = New System.Drawing.Size(288, 20)
        Me.txtScreenCoords.TabIndex = 0
        Me.txtScreenCoords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpElement
        '
        Me.tpElement.Controls.Add(Me.lvScreenCoords)
        Me.tpElement.Controls.Add(Me.btnElementRemoveScreenCoords)
        Me.tpElement.Controls.Add(Me.btnElementAddScreenCoords)
        Me.tpElement.Controls.Add(Me.lblElementScreenCoords)
        Me.tpElement.Controls.Add(Me.txtElementScreenCoords)
        Me.tpElement.Controls.Add(Me.lvElements)
        Me.tpElement.Controls.Add(Me.btnRemove)
        Me.tpElement.Controls.Add(Me.btnAdd)
        Me.tpElement.Controls.Add(Me.lblSelectedElement)
        Me.tpElement.Controls.Add(Me.pnlSelectedElement)
        Me.tpElement.Location = New System.Drawing.Point(4, 22)
        Me.tpElement.Name = "tpElement"
        Me.tpElement.Padding = New System.Windows.Forms.Padding(3)
        Me.tpElement.Size = New System.Drawing.Size(303, 520)
        Me.tpElement.TabIndex = 1
        Me.tpElement.Text = "Element Detection"
        Me.tpElement.UseVisualStyleBackColor = True
        '
        'lvElements
        '
        Me.lvElements.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chElement})
        Me.lvElements.FullRowSelect = True
        Me.lvElements.GridLines = True
        Me.lvElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvElements.HideSelection = False
        Me.lvElements.Location = New System.Drawing.Point(6, 185)
        Me.lvElements.Name = "lvElements"
        Me.lvElements.Size = New System.Drawing.Size(291, 136)
        Me.lvElements.TabIndex = 7
        Me.lvElements.UseCompatibleStateImageBehavior = False
        Me.lvElements.View = System.Windows.Forms.View.Details
        '
        'chElement
        '
        Me.chElement.Text = "Element"
        Me.chElement.Width = 286
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(86, 156)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(5, 156)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblSelectedElement
        '
        Me.lblSelectedElement.AutoSize = True
        Me.lblSelectedElement.Location = New System.Drawing.Point(6, 3)
        Me.lblSelectedElement.Name = "lblSelectedElement"
        Me.lblSelectedElement.Size = New System.Drawing.Size(90, 13)
        Me.lblSelectedElement.TabIndex = 4
        Me.lblSelectedElement.Text = "Selected Element"
        '
        'pnlSelectedElement
        '
        Me.pnlSelectedElement.AutoScroll = True
        Me.pnlSelectedElement.Controls.Add(Me.picSelected)
        Me.pnlSelectedElement.Location = New System.Drawing.Point(6, 31)
        Me.pnlSelectedElement.Name = "pnlSelectedElement"
        Me.pnlSelectedElement.Size = New System.Drawing.Size(291, 119)
        Me.pnlSelectedElement.TabIndex = 3
        '
        'picSelected
        '
        Me.picSelected.Location = New System.Drawing.Point(0, 0)
        Me.picSelected.Name = "picSelected"
        Me.picSelected.Size = New System.Drawing.Size(100, 50)
        Me.picSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSelected.TabIndex = 0
        Me.picSelected.TabStop = False
        '
        'tpColorCheck
        '
        Me.tpColorCheck.Controls.Add(Me.lblArea)
        Me.tpColorCheck.Controls.Add(Me.cboCondition)
        Me.tpColorCheck.Controls.Add(Me.udCondition)
        Me.tpColorCheck.Controls.Add(Me.lblReturnTRUE)
        Me.tpColorCheck.Controls.Add(Me.lblSelectedValue)
        Me.tpColorCheck.Controls.Add(Me.optAvgBrightness)
        Me.tpColorCheck.Controls.Add(Me.optSumColor)
        Me.tpColorCheck.Controls.Add(Me.optAvgColor)
        Me.tpColorCheck.Controls.Add(Me.lblOperation)
        Me.tpColorCheck.Controls.Add(Me.lblColorSelected)
        Me.tpColorCheck.Controls.Add(Me.pnlColorSelectedElement)
        Me.tpColorCheck.Location = New System.Drawing.Point(4, 22)
        Me.tpColorCheck.Name = "tpColorCheck"
        Me.tpColorCheck.Padding = New System.Windows.Forms.Padding(3)
        Me.tpColorCheck.Size = New System.Drawing.Size(303, 520)
        Me.tpColorCheck.TabIndex = 2
        Me.tpColorCheck.Text = "Color Check"
        Me.tpColorCheck.UseVisualStyleBackColor = True
        '
        'lblArea
        '
        Me.lblArea.AutoSize = True
        Me.lblArea.Location = New System.Drawing.Point(6, 454)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(35, 13)
        Me.lblArea.TabIndex = 15
        Me.lblArea.Text = "Area: "
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Items.AddRange(New Object() {">=", "<=", "="})
        Me.cboCondition.Location = New System.Drawing.Point(131, 416)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(56, 21)
        Me.cboCondition.TabIndex = 14
        '
        'udCondition
        '
        Me.udCondition.Location = New System.Drawing.Point(193, 416)
        Me.udCondition.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.udCondition.Name = "udCondition"
        Me.udCondition.Size = New System.Drawing.Size(88, 20)
        Me.udCondition.TabIndex = 13
        Me.udCondition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReturnTRUE
        '
        Me.lblReturnTRUE.AutoSize = True
        Me.lblReturnTRUE.Location = New System.Drawing.Point(6, 418)
        Me.lblReturnTRUE.Name = "lblReturnTRUE"
        Me.lblReturnTRUE.Size = New System.Drawing.Size(119, 13)
        Me.lblReturnTRUE.TabIndex = 12
        Me.lblReturnTRUE.Text = "Return TRUE if value is"
        '
        'lblSelectedValue
        '
        Me.lblSelectedValue.AutoSize = True
        Me.lblSelectedValue.Location = New System.Drawing.Point(6, 385)
        Me.lblSelectedValue.Name = "lblSelectedValue"
        Me.lblSelectedValue.Size = New System.Drawing.Size(85, 13)
        Me.lblSelectedValue.TabIndex = 11
        Me.lblSelectedValue.Text = "Selected Value: "
        '
        'optAvgBrightness
        '
        Me.optAvgBrightness.AutoSize = True
        Me.optAvgBrightness.Location = New System.Drawing.Point(182, 351)
        Me.optAvgBrightness.Name = "optAvgBrightness"
        Me.optAvgBrightness.Size = New System.Drawing.Size(99, 17)
        Me.optAvgBrightness.TabIndex = 10
        Me.optAvgBrightness.TabStop = True
        Me.optAvgBrightness.Text = "Avg. Brightness"
        Me.optAvgBrightness.UseVisualStyleBackColor = True
        '
        'optSumColor
        '
        Me.optSumColor.AutoSize = True
        Me.optSumColor.Location = New System.Drawing.Point(86, 351)
        Me.optSumColor.Name = "optSumColor"
        Me.optSumColor.Size = New System.Drawing.Size(90, 17)
        Me.optSumColor.TabIndex = 9
        Me.optSumColor.TabStop = True
        Me.optSumColor.Text = "Sum of Colors"
        Me.optSumColor.UseVisualStyleBackColor = True
        '
        'optAvgColor
        '
        Me.optAvgColor.AutoSize = True
        Me.optAvgColor.Location = New System.Drawing.Point(9, 351)
        Me.optAvgColor.Name = "optAvgColor"
        Me.optAvgColor.Size = New System.Drawing.Size(71, 17)
        Me.optAvgColor.TabIndex = 8
        Me.optAvgColor.TabStop = True
        Me.optAvgColor.Text = "Avg Color"
        Me.optAvgColor.UseVisualStyleBackColor = True
        '
        'lblOperation
        '
        Me.lblOperation.AutoSize = True
        Me.lblOperation.Location = New System.Drawing.Point(6, 334)
        Me.lblOperation.Name = "lblOperation"
        Me.lblOperation.Size = New System.Drawing.Size(53, 13)
        Me.lblOperation.TabIndex = 7
        Me.lblOperation.Text = "Operation"
        '
        'lblColorSelected
        '
        Me.lblColorSelected.AutoSize = True
        Me.lblColorSelected.Location = New System.Drawing.Point(6, 3)
        Me.lblColorSelected.Name = "lblColorSelected"
        Me.lblColorSelected.Size = New System.Drawing.Size(90, 13)
        Me.lblColorSelected.TabIndex = 6
        Me.lblColorSelected.Text = "Selected Element"
        '
        'pnlColorSelectedElement
        '
        Me.pnlColorSelectedElement.AutoScroll = True
        Me.pnlColorSelectedElement.Controls.Add(Me.picColorSelected)
        Me.pnlColorSelectedElement.Location = New System.Drawing.Point(6, 31)
        Me.pnlColorSelectedElement.Name = "pnlColorSelectedElement"
        Me.pnlColorSelectedElement.Size = New System.Drawing.Size(291, 291)
        Me.pnlColorSelectedElement.TabIndex = 5
        '
        'picColorSelected
        '
        Me.picColorSelected.Location = New System.Drawing.Point(0, 0)
        Me.picColorSelected.Name = "picColorSelected"
        Me.picColorSelected.Size = New System.Drawing.Size(100, 50)
        Me.picColorSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picColorSelected.TabIndex = 0
        Me.picColorSelected.TabStop = False
        '
        'tmr_liveupdate
        '
        Me.tmr_liveupdate.Interval = 1
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateNew.Location = New System.Drawing.Point(1348, 62)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(24, 23)
        Me.btnCreateNew.TabIndex = 25
        Me.btnCreateNew.Text = "+"
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblElementScreenCoords
        '
        Me.lblElementScreenCoords.AutoSize = True
        Me.lblElementScreenCoords.Location = New System.Drawing.Point(3, 324)
        Me.lblElementScreenCoords.Name = "lblElementScreenCoords"
        Me.lblElementScreenCoords.Size = New System.Drawing.Size(246, 13)
        Me.lblElementScreenCoords.TabIndex = 9
        Me.lblElementScreenCoords.Text = "Screen Coords (Fast Detect) - Right Click to Select"
        '
        'txtElementScreenCoords
        '
        Me.txtElementScreenCoords.Location = New System.Drawing.Point(6, 340)
        Me.txtElementScreenCoords.Name = "txtElementScreenCoords"
        Me.txtElementScreenCoords.ReadOnly = True
        Me.txtElementScreenCoords.Size = New System.Drawing.Size(288, 20)
        Me.txtElementScreenCoords.TabIndex = 8
        Me.txtElementScreenCoords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvScreenCoords
        '
        Me.lvScreenCoords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chScreenCoords})
        Me.lvScreenCoords.FullRowSelect = True
        Me.lvScreenCoords.GridLines = True
        Me.lvScreenCoords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvScreenCoords.HideSelection = False
        Me.lvScreenCoords.Location = New System.Drawing.Point(6, 395)
        Me.lvScreenCoords.Name = "lvScreenCoords"
        Me.lvScreenCoords.Size = New System.Drawing.Size(291, 119)
        Me.lvScreenCoords.TabIndex = 12
        Me.lvScreenCoords.UseCompatibleStateImageBehavior = False
        Me.lvScreenCoords.View = System.Windows.Forms.View.Details
        '
        'chScreenCoords
        '
        Me.chScreenCoords.Text = "Screen Coords"
        Me.chScreenCoords.Width = 286
        '
        'btnElementRemoveScreenCoords
        '
        Me.btnElementRemoveScreenCoords.Location = New System.Drawing.Point(87, 366)
        Me.btnElementRemoveScreenCoords.Name = "btnElementRemoveScreenCoords"
        Me.btnElementRemoveScreenCoords.Size = New System.Drawing.Size(75, 23)
        Me.btnElementRemoveScreenCoords.TabIndex = 11
        Me.btnElementRemoveScreenCoords.Text = "Remove"
        Me.btnElementRemoveScreenCoords.UseVisualStyleBackColor = True
        '
        'btnElementAddScreenCoords
        '
        Me.btnElementAddScreenCoords.Location = New System.Drawing.Point(6, 366)
        Me.btnElementAddScreenCoords.Name = "btnElementAddScreenCoords"
        Me.btnElementAddScreenCoords.Size = New System.Drawing.Size(75, 23)
        Me.btnElementAddScreenCoords.TabIndex = 10
        Me.btnElementAddScreenCoords.Text = "Add"
        Me.btnElementAddScreenCoords.UseVisualStyleBackColor = True
        '
        'BOTSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1384, 652)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Controls.Add(Me.tcConfig)
        Me.Controls.Add(Me.cboElement)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.pnlBuffer)
        Me.Controls.Add(Me.tlbSetup)
        Me.Name = "BOTSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOT Setup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlbSetup.ResumeLayout(False)
        Me.tlbSetup.PerformLayout()
        Me.pnlBuffer.ResumeLayout(False)
        CType(Me.picBuffer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcConfig.ResumeLayout(False)
        Me.tpClick.ResumeLayout(False)
        Me.tpClick.PerformLayout()
        Me.tpElement.ResumeLayout(False)
        Me.tpElement.PerformLayout()
        Me.pnlSelectedElement.ResumeLayout(False)
        Me.pnlSelectedElement.PerformLayout()
        CType(Me.picSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpColorCheck.ResumeLayout(False)
        Me.tpColorCheck.PerformLayout()
        CType(Me.udCondition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlColorSelectedElement.ResumeLayout(False)
        Me.pnlColorSelectedElement.PerformLayout()
        CType(Me.picColorSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbSetup As System.Windows.Forms.ToolStrip
    Friend WithEvents btnLiveUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRestoreZoom As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlBuffer As System.Windows.Forms.Panel
    Friend WithEvents picBuffer As System.Windows.Forms.PictureBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblElement As System.Windows.Forms.Label
    Friend WithEvents cboElement As System.Windows.Forms.ComboBox
    Friend WithEvents tcConfig As System.Windows.Forms.TabControl
    Friend WithEvents tpClick As System.Windows.Forms.TabPage
    Friend WithEvents tpElement As System.Windows.Forms.TabPage
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblSelectedElement As System.Windows.Forms.Label
    Friend WithEvents pnlSelectedElement As System.Windows.Forms.Panel
    Friend WithEvents picSelected As System.Windows.Forms.PictureBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lvElements As System.Windows.Forms.ListView
    Friend WithEvents chElement As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmr_liveupdate As System.Windows.Forms.Timer
    Friend WithEvents btnCreateNew As System.Windows.Forms.Button
    Friend WithEvents lblScreenCoords As System.Windows.Forms.Label
    Friend WithEvents txtScreenCoords As System.Windows.Forms.TextBox
    Friend WithEvents sep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlblblScreenCoords As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tpColorCheck As System.Windows.Forms.TabPage
    Friend WithEvents lblColorSelected As System.Windows.Forms.Label
    Friend WithEvents pnlColorSelectedElement As System.Windows.Forms.Panel
    Friend WithEvents picColorSelected As System.Windows.Forms.PictureBox
    Friend WithEvents lblOperation As System.Windows.Forms.Label
    Friend WithEvents optAvgBrightness As System.Windows.Forms.RadioButton
    Friend WithEvents optSumColor As System.Windows.Forms.RadioButton
    Friend WithEvents optAvgColor As System.Windows.Forms.RadioButton
    Friend WithEvents udCondition As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblReturnTRUE As System.Windows.Forms.Label
    Friend WithEvents lblSelectedValue As System.Windows.Forms.Label
    Friend WithEvents cboCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblArea As System.Windows.Forms.Label
    Friend WithEvents lvScreenCoords As System.Windows.Forms.ListView
    Friend WithEvents chScreenCoords As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnElementRemoveScreenCoords As System.Windows.Forms.Button
    Friend WithEvents btnElementAddScreenCoords As System.Windows.Forms.Button
    Friend WithEvents lblElementScreenCoords As System.Windows.Forms.Label
    Friend WithEvents txtElementScreenCoords As System.Windows.Forms.TextBox
End Class
