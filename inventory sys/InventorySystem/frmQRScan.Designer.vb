<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQRScan
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
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlSidebar = New Panel()
        btnSettings = New Button()
        btnQRScan = New Button()
        btnReports = New Button()
        btnInventory = New Button()
        btnDashboard = New Button()
        pnlMain = New Panel()
        pnlHeader = New Panel()
        picQRHeader = New PictureBox()
        lblHeaderUser = New Label()
        lblHeaderTime = New Label()
        lblHeaderDate = New Label()
        lblQRSubtitle = New Label()
        lblQRTitle = New Label()
        pnlFoundItems = New Panel()
        dgvFoundItems = New DataGridView()
        btnDeleteFoundItem = New Button()
        btnOpenFoundItem = New Button()
        btnRefreshFoundItems = New Button()
        txtSearchFoundItems = New TextBox()
        lblFoundItemsTitle = New Label()
        pnlInventoryCount = New Panel()
        btnResetCount = New Button()
        btnStartCount = New Button()
        cmbClassification = New ComboBox()
        lblClassification = New Label()
        cmbEndUser = New ComboBox()
        lblEndUser = New Label()
        cmbLocation = New ComboBox()
        lblLocation = New Label()
        cmbInventoryYear = New ComboBox()
        lblInventoryYear = New Label()
        lblInventoryCountTitle = New Label()
        pnlCountProgress = New Panel()
        lblProgressCount = New Label()
        progressInventory = New ProgressBar()
        pnlProgress = New Panel()
        lblProgressValue = New Label()
        lblProgressTitle = New Label()
        pnlRemaining = New Panel()
        lblRemainingCount = New Label()
        lblRemainingTitle = New Label()
        pnlScanned = New Panel()
        lblScannedCount = New Label()
        lblScannedTitle = New Label()
        pnlExpected = New Panel()
        lblExpectedCount = New Label()
        lblExpectedTitle = New Label()
        lblCountProgressTitle = New Label()
        pnlScanProperty = New Panel()
        btnRegisterFoundItem = New Button()
        pnlQRScanArea = New Panel()
        picQRScan = New PictureBox()
        txtBarcodeInput = New TextBox()
        rdoBarcode = New RadioButton()
        rdoQRCode = New RadioButton()
        lblScanInstruction = New Label()
        lblScanQRHere = New Label()
        pnlManualMode = New Panel()
        btnSearchProperty = New Button()
        txtManualPropertyNo = New TextBox()
        lblManualPropertyNo = New Label()
        btnManualSearch = New Button()
        btnScanQRCode = New Button()
        lblScanPropertyTitle = New Label()
        pnlCurrentItem = New Panel()
        lblItemPhotoTitle = New Label()
        picCurrentItem = New PictureBox()
        btnOpenInventory = New Button()
        btnMarkAccounted = New Button()
        lblCurrentUnitCostValue = New Label()
        lblCurrentUnitCost = New Label()
        lblCurrentEndUserValue = New Label()
        lblCurrentEndUser = New Label()
        lblCurrentConditionValue = New Label()
        lblCurrentCondition = New Label()
        lblCurrentDateAcquiredValue = New Label()
        lblCurrentDateAcquired = New Label()
        lblCurrentLocationValue = New Label()
        lblCurrentLocation = New Label()
        lblCurrentDescriptionValue = New Label()
        lblCurrentDescription = New Label()
        lblCurrentPropertyNoValue = New Label()
        lblCurrentPropertyNo = New Label()
        lblCurrentItemTitle = New Label()
        pnlScannedItems = New Panel()
        lblScannedRecordCount = New Label()
        txtSearchScanned = New TextBox()
        dgvScannedItems = New DataGridView()
        colScannedNo = New DataGridViewTextBoxColumn()
        colScannedDateTime = New DataGridViewTextBoxColumn()
        colScannedPropertyNo = New DataGridViewTextBoxColumn()
        colScannedDescription = New DataGridViewTextBoxColumn()
        colScannedEndUser = New DataGridViewTextBoxColumn()
        colScannedLocation = New DataGridViewTextBoxColumn()
        colScannedStatus = New DataGridViewTextBoxColumn()
        lblScannedItemsTitle = New Label()
        pnlRemainingItems = New Panel()
        txtSearchRemaining = New TextBox()
        dgvRemainingItems = New DataGridView()
        colRemainingPropertyNo = New DataGridViewTextBoxColumn()
        colRemainingDescription = New DataGridViewTextBoxColumn()
        colRemainingEndUser = New DataGridViewTextBoxColumn()
        colRemainingLocation = New DataGridViewTextBoxColumn()
        lblRemainingItemsTitle = New Label()
        pnlSidebar.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(picQRHeader, ComponentModel.ISupportInitialize).BeginInit()
        pnlFoundItems.SuspendLayout()
        CType(dgvFoundItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlInventoryCount.SuspendLayout()
        pnlCountProgress.SuspendLayout()
        pnlProgress.SuspendLayout()
        pnlRemaining.SuspendLayout()
        pnlScanned.SuspendLayout()
        pnlExpected.SuspendLayout()
        pnlScanProperty.SuspendLayout()
        pnlQRScanArea.SuspendLayout()
        CType(picQRScan, ComponentModel.ISupportInitialize).BeginInit()
        pnlManualMode.SuspendLayout()
        pnlCurrentItem.SuspendLayout()
        CType(picCurrentItem, ComponentModel.ISupportInitialize).BeginInit()
        pnlScannedItems.SuspendLayout()
        CType(dgvScannedItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlRemainingItems.SuspendLayout()
        CType(dgvRemainingItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        pnlSidebar.Controls.Add(btnSettings)
        pnlSidebar.Controls.Add(btnQRScan)
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(btnInventory)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(180, 1170)
        pnlSidebar.TabIndex = 0
        pnlSidebar.Visible = False
        ' 
        ' btnSettings
        ' 
        btnSettings.Dock = DockStyle.Top
        btnSettings.Location = New Point(0, 220)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(180, 55)
        btnSettings.TabIndex = 4
        btnSettings.Text = "Settings"
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' btnQRScan
        ' 
        btnQRScan.Dock = DockStyle.Top
        btnQRScan.Location = New Point(0, 165)
        btnQRScan.Name = "btnQRScan"
        btnQRScan.Size = New Size(180, 55)
        btnQRScan.TabIndex = 3
        btnQRScan.Text = "QR Scan"
        btnQRScan.UseVisualStyleBackColor = True
        ' 
        ' btnReports
        ' 
        btnReports.Dock = DockStyle.Top
        btnReports.Location = New Point(0, 110)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(180, 55)
        btnReports.TabIndex = 2
        btnReports.Text = "Reports"
        btnReports.UseVisualStyleBackColor = True
        ' 
        ' btnInventory
        ' 
        btnInventory.Dock = DockStyle.Top
        btnInventory.Location = New Point(0, 55)
        btnInventory.Name = "btnInventory"
        btnInventory.Size = New Size(180, 55)
        btnInventory.TabIndex = 1
        btnInventory.Text = "Inventory"
        btnInventory.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.Location = New Point(0, 0)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(180, 55)
        btnDashboard.TabIndex = 0
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' pnlMain
        ' 
        pnlMain.AutoScroll = True
        pnlMain.BackgroundImageLayout = ImageLayout.None
        pnlMain.Controls.Add(pnlHeader)
        pnlMain.Controls.Add(pnlFoundItems)
        pnlMain.Controls.Add(pnlInventoryCount)
        pnlMain.Controls.Add(pnlCountProgress)
        pnlMain.Controls.Add(pnlScanProperty)
        pnlMain.Controls.Add(pnlCurrentItem)
        pnlMain.Controls.Add(pnlScannedItems)
        pnlMain.Controls.Add(pnlRemainingItems)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        pnlMain.ImeMode = ImeMode.On
        pnlMain.Location = New Point(180, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(1716, 1170)
        pnlMain.TabIndex = 1
        ' 
        ' pnlHeader
        ' 
        pnlHeader.Controls.Add(picQRHeader)
        pnlHeader.Controls.Add(lblHeaderUser)
        pnlHeader.Controls.Add(lblHeaderTime)
        pnlHeader.Controls.Add(lblHeaderDate)
        pnlHeader.Controls.Add(lblQRSubtitle)
        pnlHeader.Controls.Add(lblQRTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1700, 30)
        pnlHeader.TabIndex = 0
        ' 
        ' picQRHeader
        ' 
        picQRHeader.BackColor = Color.Transparent
        picQRHeader.Location = New Point(15, 20)
        picQRHeader.Name = "picQRHeader"
        picQRHeader.Size = New Size(45, 45)
        picQRHeader.SizeMode = PictureBoxSizeMode.Zoom
        picQRHeader.TabIndex = 5
        picQRHeader.TabStop = False
        picQRHeader.Visible = False
        ' 
        ' lblHeaderUser
        ' 
        lblHeaderUser.AutoSize = True
        lblHeaderUser.Font = New Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderUser.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblHeaderUser.Location = New Point(1600, 5)
        lblHeaderUser.Name = "lblHeaderUser"
        lblHeaderUser.Size = New Size(57, 24)
        lblHeaderUser.TabIndex = 4
        lblHeaderUser.Text = "Admin"
        ' 
        ' lblHeaderTime
        ' 
        lblHeaderTime.AutoSize = True
        lblHeaderTime.Font = New Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderTime.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblHeaderTime.Location = New Point(1500, 5)
        lblHeaderTime.Name = "lblHeaderTime"
        lblHeaderTime.Size = New Size(82, 24)
        lblHeaderTime.TabIndex = 3
        lblHeaderTime.Text = "10:30 AM"
        ' 
        ' lblHeaderDate
        ' 
        lblHeaderDate.AutoSize = True
        lblHeaderDate.Font = New Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderDate.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblHeaderDate.Location = New Point(1380, 5)
        lblHeaderDate.Name = "lblHeaderDate"
        lblHeaderDate.Size = New Size(112, 24)
        lblHeaderDate.TabIndex = 2
        lblHeaderDate.Text = "May 16, 2026"
        ' 
        ' lblQRSubtitle
        ' 
        lblQRSubtitle.AutoSize = True
        lblQRSubtitle.Font = New Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblQRSubtitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblQRSubtitle.Location = New Point(60, 60)
        lblQRSubtitle.Name = "lblQRSubtitle"
        lblQRSubtitle.Size = New Size(400, 24)
        lblQRSubtitle.TabIndex = 1
        lblQRSubtitle.Text = "Scan QR codes to account and verify inventory items"
        ' 
        ' lblQRTitle
        ' 
        lblQRTitle.AutoSize = True
        lblQRTitle.Font = New Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQRTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblQRTitle.Location = New Point(60, 10)
        lblQRTitle.Name = "lblQRTitle"
        lblQRTitle.Size = New Size(548, 50)
        lblQRTitle.TabIndex = 0
        lblQRTitle.Text = "QR Scan / Physical Inventory"
        lblQRTitle.Visible = False
        ' 
        ' pnlFoundItems
        ' 
        pnlFoundItems.BackColor = Color.White
        pnlFoundItems.BorderStyle = BorderStyle.FixedSingle
        pnlFoundItems.Controls.Add(dgvFoundItems)
        pnlFoundItems.Controls.Add(btnDeleteFoundItem)
        pnlFoundItems.Controls.Add(btnOpenFoundItem)
        pnlFoundItems.Controls.Add(btnRefreshFoundItems)
        pnlFoundItems.Controls.Add(txtSearchFoundItems)
        pnlFoundItems.Controls.Add(lblFoundItemsTitle)
        pnlFoundItems.Location = New Point(15, 1080)
        pnlFoundItems.Name = "pnlFoundItems"
        pnlFoundItems.Size = New Size(1680, 230)
        pnlFoundItems.TabIndex = 7
        ' 
        ' dgvFoundItems
        ' 
        dgvFoundItems.AllowUserToAddRows = False
        dgvFoundItems.AllowUserToDeleteRows = False
        dgvFoundItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvFoundItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvFoundItems.BackgroundColor = Color.White
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Control
        DataGridViewCellStyle9.Font = New Font("Arial", 10F)
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvFoundItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvFoundItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Arial", 10F)
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        dgvFoundItems.DefaultCellStyle = DataGridViewCellStyle10
        dgvFoundItems.Location = New Point(10, 50)
        dgvFoundItems.MultiSelect = False
        dgvFoundItems.Name = "dgvFoundItems"
        dgvFoundItems.ReadOnly = True
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Control
        DataGridViewCellStyle11.Font = New Font("Arial", 10F)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        dgvFoundItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        dgvFoundItems.RowHeadersVisible = False
        dgvFoundItems.RowHeadersWidth = 62
        dgvFoundItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvFoundItems.Size = New Size(1635, 170)
        dgvFoundItems.TabIndex = 9
        ' 
        ' btnDeleteFoundItem
        ' 
        btnDeleteFoundItem.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteFoundItem.Location = New Point(1210, 8)
        btnDeleteFoundItem.Name = "btnDeleteFoundItem"
        btnDeleteFoundItem.Size = New Size(90, 32)
        btnDeleteFoundItem.TabIndex = 8
        btnDeleteFoundItem.Text = "Delete"
        btnDeleteFoundItem.UseVisualStyleBackColor = True
        ' 
        ' btnOpenFoundItem
        ' 
        btnOpenFoundItem.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenFoundItem.Location = New Point(1110, 8)
        btnOpenFoundItem.Name = "btnOpenFoundItem"
        btnOpenFoundItem.Size = New Size(90, 32)
        btnOpenFoundItem.TabIndex = 7
        btnOpenFoundItem.Text = "Open"
        btnOpenFoundItem.UseVisualStyleBackColor = True
        ' 
        ' btnRefreshFoundItems
        ' 
        btnRefreshFoundItems.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefreshFoundItems.Location = New Point(1000, 8)
        btnRefreshFoundItems.Name = "btnRefreshFoundItems"
        btnRefreshFoundItems.Size = New Size(100, 32)
        btnRefreshFoundItems.TabIndex = 6
        btnRefreshFoundItems.Text = "Refresh"
        btnRefreshFoundItems.UseVisualStyleBackColor = True
        ' 
        ' txtSearchFoundItems
        ' 
        txtSearchFoundItems.BorderStyle = BorderStyle.FixedSingle
        txtSearchFoundItems.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchFoundItems.Location = New Point(600, 10)
        txtSearchFoundItems.Name = "txtSearchFoundItems"
        txtSearchFoundItems.PlaceholderText = "Search found items..."
        txtSearchFoundItems.Size = New Size(380, 28)
        txtSearchFoundItems.TabIndex = 5
        ' 
        ' lblFoundItemsTitle
        ' 
        lblFoundItemsTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFoundItemsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblFoundItemsTitle.Location = New Point(15, 10)
        lblFoundItemsTitle.Name = "lblFoundItemsTitle"
        lblFoundItemsTitle.Size = New Size(350, 30)
        lblFoundItemsTitle.TabIndex = 0
        lblFoundItemsTitle.Text = "7. Found Items / Pending Review"
        lblFoundItemsTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlInventoryCount
        ' 
        pnlInventoryCount.BackColor = Color.White
        pnlInventoryCount.BorderStyle = BorderStyle.FixedSingle
        pnlInventoryCount.Controls.Add(btnResetCount)
        pnlInventoryCount.Controls.Add(btnStartCount)
        pnlInventoryCount.Controls.Add(cmbClassification)
        pnlInventoryCount.Controls.Add(lblClassification)
        pnlInventoryCount.Controls.Add(cmbEndUser)
        pnlInventoryCount.Controls.Add(lblEndUser)
        pnlInventoryCount.Controls.Add(cmbLocation)
        pnlInventoryCount.Controls.Add(lblLocation)
        pnlInventoryCount.Controls.Add(cmbInventoryYear)
        pnlInventoryCount.Controls.Add(lblInventoryYear)
        pnlInventoryCount.Controls.Add(lblInventoryCountTitle)
        pnlInventoryCount.Location = New Point(15, 50)
        pnlInventoryCount.Margin = New Padding(5)
        pnlInventoryCount.Name = "pnlInventoryCount"
        pnlInventoryCount.Size = New Size(850, 250)
        pnlInventoryCount.TabIndex = 1
        ' 
        ' btnResetCount
        ' 
        btnResetCount.AutoSize = True
        btnResetCount.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnResetCount.Location = New Point(530, 105)
        btnResetCount.Name = "btnResetCount"
        btnResetCount.Size = New Size(300, 45)
        btnResetCount.TabIndex = 10
        btnResetCount.Text = "🗘 Reset Count"
        btnResetCount.UseVisualStyleBackColor = True
        ' 
        ' btnStartCount
        ' 
        btnStartCount.AutoSize = True
        btnStartCount.BackColor = Color.FromArgb(CByte(13), CByte(110), CByte(253))
        btnStartCount.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStartCount.ForeColor = Color.White
        btnStartCount.Location = New Point(530, 50)
        btnStartCount.Name = "btnStartCount"
        btnStartCount.Size = New Size(300, 45)
        btnStartCount.TabIndex = 9
        btnStartCount.Text = "▶︎ Start Inventory Count"
        btnStartCount.UseVisualStyleBackColor = False
        ' 
        ' cmbClassification
        ' 
        cmbClassification.DropDownStyle = ComboBoxStyle.DropDownList
        cmbClassification.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbClassification.FormattingEnabled = True
        cmbClassification.Location = New Point(180, 200)
        cmbClassification.Name = "cmbClassification"
        cmbClassification.Size = New Size(320, 33)
        cmbClassification.TabIndex = 8
        ' 
        ' lblClassification
        ' 
        lblClassification.AutoSize = True
        lblClassification.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClassification.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblClassification.Location = New Point(20, 205)
        lblClassification.Name = "lblClassification"
        lblClassification.Size = New Size(137, 24)
        lblClassification.TabIndex = 7
        lblClassification.Text = "Classification"
        ' 
        ' cmbEndUser
        ' 
        cmbEndUser.DropDownStyle = ComboBoxStyle.DropDownList
        cmbEndUser.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbEndUser.FormattingEnabled = True
        cmbEndUser.Location = New Point(180, 150)
        cmbEndUser.Name = "cmbEndUser"
        cmbEndUser.Size = New Size(320, 33)
        cmbEndUser.TabIndex = 6
        ' 
        ' lblEndUser
        ' 
        lblEndUser.AutoSize = True
        lblEndUser.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEndUser.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblEndUser.Location = New Point(20, 155)
        lblEndUser.Name = "lblEndUser"
        lblEndUser.Size = New Size(97, 24)
        lblEndUser.TabIndex = 5
        lblEndUser.Text = "End User"
        ' 
        ' cmbLocation
        ' 
        cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLocation.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbLocation.FormattingEnabled = True
        cmbLocation.Location = New Point(180, 100)
        cmbLocation.Name = "cmbLocation"
        cmbLocation.Size = New Size(320, 33)
        cmbLocation.TabIndex = 4
        ' 
        ' lblLocation
        ' 
        lblLocation.AutoSize = True
        lblLocation.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLocation.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblLocation.Location = New Point(20, 105)
        lblLocation.Name = "lblLocation"
        lblLocation.Size = New Size(92, 24)
        lblLocation.TabIndex = 3
        lblLocation.Text = "Location"
        ' 
        ' cmbInventoryYear
        ' 
        cmbInventoryYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbInventoryYear.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbInventoryYear.FormattingEnabled = True
        cmbInventoryYear.Location = New Point(180, 50)
        cmbInventoryYear.Name = "cmbInventoryYear"
        cmbInventoryYear.Size = New Size(320, 33)
        cmbInventoryYear.TabIndex = 2
        ' 
        ' lblInventoryYear
        ' 
        lblInventoryYear.AutoSize = True
        lblInventoryYear.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInventoryYear.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblInventoryYear.Location = New Point(20, 55)
        lblInventoryYear.Name = "lblInventoryYear"
        lblInventoryYear.Size = New Size(147, 24)
        lblInventoryYear.TabIndex = 1
        lblInventoryYear.Text = "Inventory Year"
        ' 
        ' lblInventoryCountTitle
        ' 
        lblInventoryCountTitle.AutoSize = True
        lblInventoryCountTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInventoryCountTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblInventoryCountTitle.Location = New Point(10, 8)
        lblInventoryCountTitle.Name = "lblInventoryCountTitle"
        lblInventoryCountTitle.Size = New Size(367, 29)
        lblInventoryCountTitle.TabIndex = 0
        lblInventoryCountTitle.Text = "1. Select Location for Inventory Count"
        ' 
        ' pnlCountProgress
        ' 
        pnlCountProgress.AutoScroll = True
        pnlCountProgress.BackColor = Color.White
        pnlCountProgress.BorderStyle = BorderStyle.FixedSingle
        pnlCountProgress.Controls.Add(lblProgressCount)
        pnlCountProgress.Controls.Add(progressInventory)
        pnlCountProgress.Controls.Add(pnlProgress)
        pnlCountProgress.Controls.Add(pnlRemaining)
        pnlCountProgress.Controls.Add(pnlScanned)
        pnlCountProgress.Controls.Add(pnlExpected)
        pnlCountProgress.Controls.Add(lblCountProgressTitle)
        pnlCountProgress.Location = New Point(870, 50)
        pnlCountProgress.Margin = New Padding(5)
        pnlCountProgress.Name = "pnlCountProgress"
        pnlCountProgress.Size = New Size(830, 250)
        pnlCountProgress.TabIndex = 2
        ' 
        ' lblProgressCount
        ' 
        lblProgressCount.AutoSize = True
        lblProgressCount.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProgressCount.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblProgressCount.Location = New Point(750, 215)
        lblProgressCount.Name = "lblProgressCount"
        lblProgressCount.Size = New Size(50, 29)
        lblProgressCount.TabIndex = 7
        lblProgressCount.Text = "0 / 0"
        ' 
        ' progressInventory
        ' 
        progressInventory.Location = New Point(15, 215)
        progressInventory.Name = "progressInventory"
        progressInventory.Size = New Size(730, 25)
        progressInventory.Style = ProgressBarStyle.Continuous
        progressInventory.TabIndex = 6
        ' 
        ' pnlProgress
        ' 
        pnlProgress.BackColor = Color.FromArgb(CByte(245), CByte(250), CByte(255))
        pnlProgress.BorderStyle = BorderStyle.FixedSingle
        pnlProgress.Controls.Add(lblProgressValue)
        pnlProgress.Controls.Add(lblProgressTitle)
        pnlProgress.Location = New Point(615, 45)
        pnlProgress.Name = "pnlProgress"
        pnlProgress.Size = New Size(190, 160)
        pnlProgress.TabIndex = 5
        ' 
        ' lblProgressValue
        ' 
        lblProgressValue.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProgressValue.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        lblProgressValue.Location = New Point(5, 50)
        lblProgressValue.Name = "lblProgressValue"
        lblProgressValue.Size = New Size(100, 50)
        lblProgressValue.TabIndex = 6
        lblProgressValue.Text = "0%"
        lblProgressValue.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblProgressTitle
        ' 
        lblProgressTitle.Font = New Font("Arial Narrow", 8F, FontStyle.Bold)
        lblProgressTitle.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblProgressTitle.Location = New Point(5, 10)
        lblProgressTitle.Name = "lblProgressTitle"
        lblProgressTitle.Size = New Size(80, 35)
        lblProgressTitle.TabIndex = 5
        lblProgressTitle.Text = "Progress"
        lblProgressTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlRemaining
        ' 
        pnlRemaining.BackColor = Color.FromArgb(CByte(245), CByte(250), CByte(255))
        pnlRemaining.BorderStyle = BorderStyle.FixedSingle
        pnlRemaining.Controls.Add(lblRemainingCount)
        pnlRemaining.Controls.Add(lblRemainingTitle)
        pnlRemaining.Location = New Point(415, 45)
        pnlRemaining.Name = "pnlRemaining"
        pnlRemaining.Size = New Size(190, 160)
        pnlRemaining.TabIndex = 4
        ' 
        ' lblRemainingCount
        ' 
        lblRemainingCount.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRemainingCount.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        lblRemainingCount.Location = New Point(5, 50)
        lblRemainingCount.Name = "lblRemainingCount"
        lblRemainingCount.Size = New Size(80, 50)
        lblRemainingCount.TabIndex = 5
        lblRemainingCount.Text = "0"
        lblRemainingCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblRemainingTitle
        ' 
        lblRemainingTitle.Font = New Font("Arial Narrow", 8F, FontStyle.Bold)
        lblRemainingTitle.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblRemainingTitle.Location = New Point(5, 10)
        lblRemainingTitle.Name = "lblRemainingTitle"
        lblRemainingTitle.Size = New Size(80, 45)
        lblRemainingTitle.TabIndex = 4
        lblRemainingTitle.Text = "Remaining"
        lblRemainingTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlScanned
        ' 
        pnlScanned.BackColor = Color.FromArgb(CByte(245), CByte(250), CByte(255))
        pnlScanned.BorderStyle = BorderStyle.FixedSingle
        pnlScanned.Controls.Add(lblScannedCount)
        pnlScanned.Controls.Add(lblScannedTitle)
        pnlScanned.Location = New Point(215, 45)
        pnlScanned.Name = "pnlScanned"
        pnlScanned.Size = New Size(190, 160)
        pnlScanned.TabIndex = 3
        ' 
        ' lblScannedCount
        ' 
        lblScannedCount.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScannedCount.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        lblScannedCount.Location = New Point(5, 50)
        lblScannedCount.Name = "lblScannedCount"
        lblScannedCount.Size = New Size(80, 50)
        lblScannedCount.TabIndex = 4
        lblScannedCount.Text = "0"
        lblScannedCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblScannedTitle
        ' 
        lblScannedTitle.Font = New Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScannedTitle.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblScannedTitle.Location = New Point(5, 5)
        lblScannedTitle.Name = "lblScannedTitle"
        lblScannedTitle.Size = New Size(80, 45)
        lblScannedTitle.TabIndex = 3
        lblScannedTitle.Text = "Scanned/Verified"
        lblScannedTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlExpected
        ' 
        pnlExpected.BackColor = Color.FromArgb(CByte(245), CByte(250), CByte(255))
        pnlExpected.BorderStyle = BorderStyle.FixedSingle
        pnlExpected.Controls.Add(lblExpectedCount)
        pnlExpected.Controls.Add(lblExpectedTitle)
        pnlExpected.Location = New Point(15, 45)
        pnlExpected.Name = "pnlExpected"
        pnlExpected.Size = New Size(190, 160)
        pnlExpected.TabIndex = 2
        ' 
        ' lblExpectedCount
        ' 
        lblExpectedCount.Font = New Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblExpectedCount.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        lblExpectedCount.Location = New Point(5, 50)
        lblExpectedCount.Name = "lblExpectedCount"
        lblExpectedCount.Size = New Size(80, 50)
        lblExpectedCount.TabIndex = 3
        lblExpectedCount.Text = "0"
        lblExpectedCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblExpectedTitle
        ' 
        lblExpectedTitle.Font = New Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblExpectedTitle.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblExpectedTitle.Location = New Point(5, 15)
        lblExpectedTitle.Name = "lblExpectedTitle"
        lblExpectedTitle.Size = New Size(80, 30)
        lblExpectedTitle.TabIndex = 2
        lblExpectedTitle.Text = "Expected"
        lblExpectedTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblCountProgressTitle
        ' 
        lblCountProgressTitle.AutoSize = True
        lblCountProgressTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCountProgressTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCountProgressTitle.Location = New Point(10, 8)
        lblCountProgressTitle.Name = "lblCountProgressTitle"
        lblCountProgressTitle.Size = New Size(182, 29)
        lblCountProgressTitle.TabIndex = 1
        lblCountProgressTitle.Text = "2. Count Progress"
        ' 
        ' pnlScanProperty
        ' 
        pnlScanProperty.BackColor = Color.White
        pnlScanProperty.BorderStyle = BorderStyle.FixedSingle
        pnlScanProperty.Controls.Add(btnRegisterFoundItem)
        pnlScanProperty.Controls.Add(pnlQRScanArea)
        pnlScanProperty.Controls.Add(pnlManualMode)
        pnlScanProperty.Controls.Add(btnManualSearch)
        pnlScanProperty.Controls.Add(btnScanQRCode)
        pnlScanProperty.Controls.Add(lblScanPropertyTitle)
        pnlScanProperty.Location = New Point(13, 310)
        pnlScanProperty.Name = "pnlScanProperty"
        pnlScanProperty.Size = New Size(430, 400)
        pnlScanProperty.TabIndex = 3
        ' 
        ' btnRegisterFoundItem
        ' 
        btnRegisterFoundItem.BackColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        btnRegisterFoundItem.Font = New Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterFoundItem.ForeColor = Color.White
        btnRegisterFoundItem.Location = New Point(70, 345)
        btnRegisterFoundItem.Name = "btnRegisterFoundItem"
        btnRegisterFoundItem.Size = New Size(300, 42)
        btnRegisterFoundItem.TabIndex = 7
        btnRegisterFoundItem.Text = "Register Found Item"
        btnRegisterFoundItem.UseVisualStyleBackColor = False
        ' 
        ' pnlQRScanArea
        ' 
        pnlQRScanArea.BorderStyle = BorderStyle.FixedSingle
        pnlQRScanArea.Controls.Add(picQRScan)
        pnlQRScanArea.Controls.Add(txtBarcodeInput)
        pnlQRScanArea.Controls.Add(rdoBarcode)
        pnlQRScanArea.Controls.Add(rdoQRCode)
        pnlQRScanArea.Controls.Add(lblScanInstruction)
        pnlQRScanArea.Controls.Add(lblScanQRHere)
        pnlQRScanArea.Location = New Point(15, 100)
        pnlQRScanArea.Name = "pnlQRScanArea"
        pnlQRScanArea.Size = New Size(400, 230)
        pnlQRScanArea.TabIndex = 4
        ' 
        ' picQRScan
        ' 
        picQRScan.BackColor = Color.Transparent
        picQRScan.Location = New Point(140, 50)
        picQRScan.Name = "picQRScan"
        picQRScan.Size = New Size(80, 80)
        picQRScan.SizeMode = PictureBoxSizeMode.Zoom
        picQRScan.TabIndex = 0
        picQRScan.TabStop = False
        ' 
        ' txtBarcodeInput
        ' 
        txtBarcodeInput.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtBarcodeInput.Location = New Point(36, 70)
        txtBarcodeInput.Name = "txtBarcodeInput"
        txtBarcodeInput.Size = New Size(330, 34)
        txtBarcodeInput.TabIndex = 8
        txtBarcodeInput.Visible = False
        ' 
        ' rdoBarcode
        ' 
        rdoBarcode.AutoSize = True
        rdoBarcode.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rdoBarcode.Location = New Point(200, 10)
        rdoBarcode.Name = "rdoBarcode"
        rdoBarcode.Size = New Size(100, 28)
        rdoBarcode.TabIndex = 7
        rdoBarcode.Text = "Barcode"
        rdoBarcode.UseVisualStyleBackColor = True
        ' 
        ' rdoQRCode
        ' 
        rdoQRCode.AutoSize = True
        rdoQRCode.Checked = True
        rdoQRCode.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rdoQRCode.Location = New Point(20, 10)
        rdoQRCode.Name = "rdoQRCode"
        rdoQRCode.Size = New Size(106, 28)
        rdoQRCode.TabIndex = 6
        rdoQRCode.TabStop = True
        rdoQRCode.Text = "QR Code"
        rdoQRCode.UseVisualStyleBackColor = True
        ' 
        ' lblScanInstruction
        ' 
        lblScanInstruction.Font = New Font("Arial Narrow", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScanInstruction.ForeColor = Color.FromArgb(CByte(107), CByte(124), CByte(154))
        lblScanInstruction.Location = New Point(0, 170)
        lblScanInstruction.Name = "lblScanInstruction"
        lblScanInstruction.Size = New Size(400, 50)
        lblScanInstruction.TabIndex = 5
        lblScanInstruction.Text = "Place the cursor on the box and scan the code using your scanner."
        lblScanInstruction.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblScanQRHere
        ' 
        lblScanQRHere.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScanQRHere.ForeColor = Color.FromArgb(CByte(107), CByte(124), CByte(154))
        lblScanQRHere.Location = New Point(85, 135)
        lblScanQRHere.Name = "lblScanQRHere"
        lblScanQRHere.Size = New Size(215, 30)
        lblScanQRHere.TabIndex = 2
        lblScanQRHere.Text = "Scan QR code here..."
        lblScanQRHere.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlManualMode
        ' 
        pnlManualMode.BorderStyle = BorderStyle.FixedSingle
        pnlManualMode.Controls.Add(btnSearchProperty)
        pnlManualMode.Controls.Add(txtManualPropertyNo)
        pnlManualMode.Controls.Add(lblManualPropertyNo)
        pnlManualMode.Location = New Point(15, 100)
        pnlManualMode.Name = "pnlManualMode"
        pnlManualMode.Size = New Size(400, 230)
        pnlManualMode.TabIndex = 6
        pnlManualMode.Visible = False
        ' 
        ' btnSearchProperty
        ' 
        btnSearchProperty.BackColor = Color.FromArgb(CByte(13), CByte(110), CByte(253))
        btnSearchProperty.FlatStyle = FlatStyle.Flat
        btnSearchProperty.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearchProperty.ForeColor = Color.White
        btnSearchProperty.Location = New Point(130, 115)
        btnSearchProperty.Name = "btnSearchProperty"
        btnSearchProperty.Size = New Size(112, 34)
        btnSearchProperty.TabIndex = 5
        btnSearchProperty.Text = "Search"
        btnSearchProperty.UseVisualStyleBackColor = False
        ' 
        ' txtManualPropertyNo
        ' 
        txtManualPropertyNo.BorderStyle = BorderStyle.FixedSingle
        txtManualPropertyNo.Font = New Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtManualPropertyNo.Location = New Point(20, 65)
        txtManualPropertyNo.Name = "txtManualPropertyNo"
        txtManualPropertyNo.PlaceholderText = "Enter Property Number"
        txtManualPropertyNo.Size = New Size(345, 30)
        txtManualPropertyNo.TabIndex = 9
        ' 
        ' lblManualPropertyNo
        ' 
        lblManualPropertyNo.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblManualPropertyNo.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        lblManualPropertyNo.Location = New Point(20, 35)
        lblManualPropertyNo.Name = "lblManualPropertyNo"
        lblManualPropertyNo.Size = New Size(345, 25)
        lblManualPropertyNo.TabIndex = 8
        lblManualPropertyNo.Text = "Property Number"
        ' 
        ' btnManualSearch
        ' 
        btnManualSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnManualSearch.BackColor = Color.FromArgb(CByte(232), CByte(241), CByte(251))
        btnManualSearch.FlatStyle = FlatStyle.Flat
        btnManualSearch.Font = New Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnManualSearch.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        btnManualSearch.Location = New Point(215, 45)
        btnManualSearch.Name = "btnManualSearch"
        btnManualSearch.Size = New Size(190, 45)
        btnManualSearch.TabIndex = 3
        btnManualSearch.Text = "Manual Search"
        btnManualSearch.UseVisualStyleBackColor = False
        ' 
        ' btnScanQRCode
        ' 
        btnScanQRCode.BackColor = Color.FromArgb(CByte(13), CByte(110), CByte(253))
        btnScanQRCode.FlatStyle = FlatStyle.Flat
        btnScanQRCode.Font = New Font("Arial Narrow", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnScanQRCode.ForeColor = Color.White
        btnScanQRCode.Location = New Point(25, 45)
        btnScanQRCode.Name = "btnScanQRCode"
        btnScanQRCode.Size = New Size(190, 45)
        btnScanQRCode.TabIndex = 2
        btnScanQRCode.Text = "Scan Code"
        btnScanQRCode.UseVisualStyleBackColor = False
        ' 
        ' lblScanPropertyTitle
        ' 
        lblScanPropertyTitle.AutoSize = True
        lblScanPropertyTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScanPropertyTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblScanPropertyTitle.Location = New Point(10, 8)
        lblScanPropertyTitle.Name = "lblScanPropertyTitle"
        lblScanPropertyTitle.Size = New Size(168, 29)
        lblScanPropertyTitle.TabIndex = 1
        lblScanPropertyTitle.Text = "3. Scan Property"
        ' 
        ' pnlCurrentItem
        ' 
        pnlCurrentItem.BackColor = Color.White
        pnlCurrentItem.BorderStyle = BorderStyle.FixedSingle
        pnlCurrentItem.Controls.Add(lblItemPhotoTitle)
        pnlCurrentItem.Controls.Add(picCurrentItem)
        pnlCurrentItem.Controls.Add(btnOpenInventory)
        pnlCurrentItem.Controls.Add(btnMarkAccounted)
        pnlCurrentItem.Controls.Add(lblCurrentUnitCostValue)
        pnlCurrentItem.Controls.Add(lblCurrentUnitCost)
        pnlCurrentItem.Controls.Add(lblCurrentEndUserValue)
        pnlCurrentItem.Controls.Add(lblCurrentEndUser)
        pnlCurrentItem.Controls.Add(lblCurrentConditionValue)
        pnlCurrentItem.Controls.Add(lblCurrentCondition)
        pnlCurrentItem.Controls.Add(lblCurrentDateAcquiredValue)
        pnlCurrentItem.Controls.Add(lblCurrentDateAcquired)
        pnlCurrentItem.Controls.Add(lblCurrentLocationValue)
        pnlCurrentItem.Controls.Add(lblCurrentLocation)
        pnlCurrentItem.Controls.Add(lblCurrentDescriptionValue)
        pnlCurrentItem.Controls.Add(lblCurrentDescription)
        pnlCurrentItem.Controls.Add(lblCurrentPropertyNoValue)
        pnlCurrentItem.Controls.Add(lblCurrentPropertyNo)
        pnlCurrentItem.Controls.Add(lblCurrentItemTitle)
        pnlCurrentItem.Location = New Point(450, 310)
        pnlCurrentItem.Name = "pnlCurrentItem"
        pnlCurrentItem.Size = New Size(1250, 400)
        pnlCurrentItem.TabIndex = 4
        ' 
        ' lblItemPhotoTitle
        ' 
        lblItemPhotoTitle.AutoSize = True
        lblItemPhotoTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemPhotoTitle.Location = New Point(800, 15)
        lblItemPhotoTitle.Name = "lblItemPhotoTitle"
        lblItemPhotoTitle.Size = New Size(117, 28)
        lblItemPhotoTitle.TabIndex = 20
        lblItemPhotoTitle.Text = "Item Photo"
        ' 
        ' picCurrentItem
        ' 
        picCurrentItem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        picCurrentItem.BorderStyle = BorderStyle.FixedSingle
        picCurrentItem.Location = New Point(800, 45)
        picCurrentItem.Name = "picCurrentItem"
        picCurrentItem.Size = New Size(400, 325)
        picCurrentItem.SizeMode = PictureBoxSizeMode.Zoom
        picCurrentItem.TabIndex = 19
        picCurrentItem.TabStop = False
        ' 
        ' btnOpenInventory
        ' 
        btnOpenInventory.BackColor = Color.FromArgb(CByte(232), CByte(241), CByte(251))
        btnOpenInventory.FlatStyle = FlatStyle.Flat
        btnOpenInventory.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenInventory.ForeColor = Color.FromArgb(CByte(23), CByte(54), CByte(93))
        btnOpenInventory.Location = New Point(400, 350)
        btnOpenInventory.Name = "btnOpenInventory"
        btnOpenInventory.Size = New Size(350, 40)
        btnOpenInventory.TabIndex = 18
        btnOpenInventory.Text = "Open in Inventory"
        btnOpenInventory.UseVisualStyleBackColor = False
        ' 
        ' btnMarkAccounted
        ' 
        btnMarkAccounted.BackColor = Color.FromArgb(CByte(25), CByte(135), CByte(84))
        btnMarkAccounted.FlatStyle = FlatStyle.Flat
        btnMarkAccounted.Font = New Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMarkAccounted.ForeColor = Color.White
        btnMarkAccounted.Location = New Point(400, 305)
        btnMarkAccounted.Name = "btnMarkAccounted"
        btnMarkAccounted.Size = New Size(350, 40)
        btnMarkAccounted.TabIndex = 17
        btnMarkAccounted.Text = "Mark as Accounted"
        btnMarkAccounted.UseVisualStyleBackColor = False
        ' 
        ' lblCurrentUnitCostValue
        ' 
        lblCurrentUnitCostValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentUnitCostValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentUnitCostValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentUnitCostValue.Location = New Point(400, 260)
        lblCurrentUnitCostValue.Name = "lblCurrentUnitCostValue"
        lblCurrentUnitCostValue.Size = New Size(350, 40)
        lblCurrentUnitCostValue.TabIndex = 16
        lblCurrentUnitCostValue.Text = "-"
        lblCurrentUnitCostValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentUnitCost
        ' 
        lblCurrentUnitCost.AutoSize = True
        lblCurrentUnitCost.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentUnitCost.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentUnitCost.Location = New Point(400, 225)
        lblCurrentUnitCost.Name = "lblCurrentUnitCost"
        lblCurrentUnitCost.Size = New Size(90, 21)
        lblCurrentUnitCost.TabIndex = 15
        lblCurrentUnitCost.Text = "Unit Cost"
        ' 
        ' lblCurrentEndUserValue
        ' 
        lblCurrentEndUserValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentEndUserValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentEndUserValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentEndUserValue.Location = New Point(20, 345)
        lblCurrentEndUserValue.Name = "lblCurrentEndUserValue"
        lblCurrentEndUserValue.Size = New Size(350, 40)
        lblCurrentEndUserValue.TabIndex = 14
        lblCurrentEndUserValue.Text = "-"
        lblCurrentEndUserValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentEndUser
        ' 
        lblCurrentEndUser.AutoSize = True
        lblCurrentEndUser.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentEndUser.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentEndUser.Location = New Point(20, 310)
        lblCurrentEndUser.Name = "lblCurrentEndUser"
        lblCurrentEndUser.Size = New Size(90, 21)
        lblCurrentEndUser.TabIndex = 13
        lblCurrentEndUser.Text = "End User"
        ' 
        ' lblCurrentConditionValue
        ' 
        lblCurrentConditionValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentConditionValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentConditionValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentConditionValue.Location = New Point(400, 175)
        lblCurrentConditionValue.Name = "lblCurrentConditionValue"
        lblCurrentConditionValue.Size = New Size(350, 40)
        lblCurrentConditionValue.TabIndex = 12
        lblCurrentConditionValue.Text = "-"
        lblCurrentConditionValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentCondition
        ' 
        lblCurrentCondition.AutoSize = True
        lblCurrentCondition.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentCondition.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentCondition.Location = New Point(400, 140)
        lblCurrentCondition.Name = "lblCurrentCondition"
        lblCurrentCondition.Size = New Size(94, 21)
        lblCurrentCondition.TabIndex = 11
        lblCurrentCondition.Text = "Condition"
        ' 
        ' lblCurrentDateAcquiredValue
        ' 
        lblCurrentDateAcquiredValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentDateAcquiredValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentDateAcquiredValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentDateAcquiredValue.Location = New Point(400, 90)
        lblCurrentDateAcquiredValue.Name = "lblCurrentDateAcquiredValue"
        lblCurrentDateAcquiredValue.Size = New Size(350, 40)
        lblCurrentDateAcquiredValue.TabIndex = 10
        lblCurrentDateAcquiredValue.Text = "-"
        lblCurrentDateAcquiredValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentDateAcquired
        ' 
        lblCurrentDateAcquired.AutoSize = True
        lblCurrentDateAcquired.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentDateAcquired.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentDateAcquired.Location = New Point(400, 55)
        lblCurrentDateAcquired.Name = "lblCurrentDateAcquired"
        lblCurrentDateAcquired.Size = New Size(133, 21)
        lblCurrentDateAcquired.TabIndex = 9
        lblCurrentDateAcquired.Text = "Date Acquired"
        ' 
        ' lblCurrentLocationValue
        ' 
        lblCurrentLocationValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentLocationValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentLocationValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentLocationValue.Location = New Point(20, 260)
        lblCurrentLocationValue.Name = "lblCurrentLocationValue"
        lblCurrentLocationValue.Size = New Size(350, 40)
        lblCurrentLocationValue.TabIndex = 8
        lblCurrentLocationValue.Text = "-"
        lblCurrentLocationValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentLocation
        ' 
        lblCurrentLocation.AutoSize = True
        lblCurrentLocation.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentLocation.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentLocation.Location = New Point(20, 225)
        lblCurrentLocation.Name = "lblCurrentLocation"
        lblCurrentLocation.Size = New Size(85, 21)
        lblCurrentLocation.TabIndex = 7
        lblCurrentLocation.Text = "Location"
        ' 
        ' lblCurrentDescriptionValue
        ' 
        lblCurrentDescriptionValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentDescriptionValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentDescriptionValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentDescriptionValue.Location = New Point(20, 175)
        lblCurrentDescriptionValue.Name = "lblCurrentDescriptionValue"
        lblCurrentDescriptionValue.Size = New Size(350, 40)
        lblCurrentDescriptionValue.TabIndex = 6
        lblCurrentDescriptionValue.Text = "-"
        lblCurrentDescriptionValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentDescription
        ' 
        lblCurrentDescription.AutoSize = True
        lblCurrentDescription.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentDescription.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentDescription.Location = New Point(20, 140)
        lblCurrentDescription.Name = "lblCurrentDescription"
        lblCurrentDescription.Size = New Size(110, 21)
        lblCurrentDescription.TabIndex = 5
        lblCurrentDescription.Text = "Description"
        ' 
        ' lblCurrentPropertyNoValue
        ' 
        lblCurrentPropertyNoValue.BorderStyle = BorderStyle.FixedSingle
        lblCurrentPropertyNoValue.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentPropertyNoValue.ForeColor = Color.FromArgb(CByte(31), CByte(41), CByte(55))
        lblCurrentPropertyNoValue.Location = New Point(20, 90)
        lblCurrentPropertyNoValue.Name = "lblCurrentPropertyNoValue"
        lblCurrentPropertyNoValue.Size = New Size(350, 40)
        lblCurrentPropertyNoValue.TabIndex = 4
        lblCurrentPropertyNoValue.Text = "-"
        lblCurrentPropertyNoValue.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCurrentPropertyNo
        ' 
        lblCurrentPropertyNo.AutoSize = True
        lblCurrentPropertyNo.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentPropertyNo.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentPropertyNo.Location = New Point(20, 55)
        lblCurrentPropertyNo.Name = "lblCurrentPropertyNo"
        lblCurrentPropertyNo.Size = New Size(161, 21)
        lblCurrentPropertyNo.TabIndex = 3
        lblCurrentPropertyNo.Text = "Property Number"
        ' 
        ' lblCurrentItemTitle
        ' 
        lblCurrentItemTitle.AutoSize = True
        lblCurrentItemTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCurrentItemTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblCurrentItemTitle.Location = New Point(10, 8)
        lblCurrentItemTitle.Name = "lblCurrentItemTitle"
        lblCurrentItemTitle.Size = New Size(266, 29)
        lblCurrentItemTitle.TabIndex = 2
        lblCurrentItemTitle.Text = "4. Current Item Information"
        ' 
        ' pnlScannedItems
        ' 
        pnlScannedItems.BackColor = Color.White
        pnlScannedItems.BorderStyle = BorderStyle.FixedSingle
        pnlScannedItems.Controls.Add(lblScannedRecordCount)
        pnlScannedItems.Controls.Add(txtSearchScanned)
        pnlScannedItems.Controls.Add(dgvScannedItems)
        pnlScannedItems.Controls.Add(lblScannedItemsTitle)
        pnlScannedItems.Location = New Point(15, 720)
        pnlScannedItems.Name = "pnlScannedItems"
        pnlScannedItems.Size = New Size(850, 350)
        pnlScannedItems.TabIndex = 5
        ' 
        ' lblScannedRecordCount
        ' 
        lblScannedRecordCount.Font = New Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScannedRecordCount.ForeColor = Color.FromArgb(CByte(107), CByte(124), CByte(154))
        lblScannedRecordCount.Location = New Point(480, 310)
        lblScannedRecordCount.Name = "lblScannedRecordCount"
        lblScannedRecordCount.Size = New Size(220, 30)
        lblScannedRecordCount.TabIndex = 12
        lblScannedRecordCount.Text = "Showing 1–5 of 0 records"
        lblScannedRecordCount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtSearchScanned
        ' 
        txtSearchScanned.BorderStyle = BorderStyle.FixedSingle
        txtSearchScanned.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchScanned.Location = New Point(480, 10)
        txtSearchScanned.Name = "txtSearchScanned"
        txtSearchScanned.PlaceholderText = "Search scanned items..."
        txtSearchScanned.Size = New Size(360, 28)
        txtSearchScanned.TabIndex = 4
        ' 
        ' dgvScannedItems
        ' 
        dgvScannedItems.AllowUserToAddRows = False
        dgvScannedItems.AllowUserToDeleteRows = False
        dgvScannedItems.AllowUserToResizeRows = False
        dgvScannedItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvScannedItems.BackgroundColor = Color.White
        DataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = SystemColors.Control
        DataGridViewCellStyle14.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle14.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = DataGridViewTriState.True
        dgvScannedItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        dgvScannedItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvScannedItems.Columns.AddRange(New DataGridViewColumn() {colScannedNo, colScannedDateTime, colScannedPropertyNo, colScannedDescription, colScannedEndUser, colScannedLocation, colScannedStatus})
        DataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = SystemColors.Window
        DataGridViewCellStyle15.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle15.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = DataGridViewTriState.False
        dgvScannedItems.DefaultCellStyle = DataGridViewCellStyle15
        dgvScannedItems.Location = New Point(10, 45)
        dgvScannedItems.MultiSelect = False
        dgvScannedItems.Name = "dgvScannedItems"
        dgvScannedItems.ReadOnly = True
        DataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = SystemColors.Control
        DataGridViewCellStyle16.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle16.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = DataGridViewTriState.True
        dgvScannedItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        dgvScannedItems.RowHeadersVisible = False
        dgvScannedItems.RowHeadersWidth = 62
        dgvScannedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvScannedItems.ShowCellToolTips = False
        dgvScannedItems.Size = New Size(830, 260)
        dgvScannedItems.TabIndex = 3
        ' 
        ' colScannedNo
        ' 
        colScannedNo.HeaderText = "#"
        colScannedNo.MinimumWidth = 8
        colScannedNo.Name = "colScannedNo"
        colScannedNo.ReadOnly = True
        colScannedNo.Width = 37
        ' 
        ' colScannedDateTime
        ' 
        colScannedDateTime.FillWeight = 18.1818142F
        colScannedDateTime.HeaderText = "Scanned Date/Time"
        colScannedDateTime.MinimumWidth = 8
        colScannedDateTime.Name = "colScannedDateTime"
        colScannedDateTime.ReadOnly = True
        colScannedDateTime.Width = 130
        ' 
        ' colScannedPropertyNo
        ' 
        colScannedPropertyNo.FillWeight = 284.090942F
        colScannedPropertyNo.HeaderText = "Property Number"
        colScannedPropertyNo.MinimumWidth = 8
        colScannedPropertyNo.Name = "colScannedPropertyNo"
        colScannedPropertyNo.ReadOnly = True
        colScannedPropertyNo.Width = 120
        ' 
        ' colScannedDescription
        ' 
        colScannedDescription.FillWeight = 79.54544F
        colScannedDescription.HeaderText = "Description"
        colScannedDescription.MinimumWidth = 8
        colScannedDescription.Name = "colScannedDescription"
        colScannedDescription.ReadOnly = True
        colScannedDescription.Width = 190
        ' 
        ' colScannedEndUser
        ' 
        colScannedEndUser.HeaderText = "End User"
        colScannedEndUser.MinimumWidth = 8
        colScannedEndUser.Name = "colScannedEndUser"
        colScannedEndUser.ReadOnly = True
        colScannedEndUser.Width = 120
        ' 
        ' colScannedLocation
        ' 
        colScannedLocation.HeaderText = "Location"
        colScannedLocation.MinimumWidth = 8
        colScannedLocation.Name = "colScannedLocation"
        colScannedLocation.ReadOnly = True
        colScannedLocation.Width = 110
        ' 
        ' colScannedStatus
        ' 
        colScannedStatus.FillWeight = 18.1818142F
        colScannedStatus.HeaderText = "Status"
        colScannedStatus.MinimumWidth = 8
        colScannedStatus.Name = "colScannedStatus"
        colScannedStatus.ReadOnly = True
        colScannedStatus.Width = 120
        ' 
        ' lblScannedItemsTitle
        ' 
        lblScannedItemsTitle.AutoSize = True
        lblScannedItemsTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScannedItemsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblScannedItemsTitle.Location = New Point(10, 8)
        lblScannedItemsTitle.Name = "lblScannedItemsTitle"
        lblScannedItemsTitle.Size = New Size(173, 29)
        lblScannedItemsTitle.TabIndex = 2
        lblScannedItemsTitle.Text = "5. Scanned Items"
        ' 
        ' pnlRemainingItems
        ' 
        pnlRemainingItems.BackColor = Color.White
        pnlRemainingItems.BorderStyle = BorderStyle.FixedSingle
        pnlRemainingItems.Controls.Add(txtSearchRemaining)
        pnlRemainingItems.Controls.Add(dgvRemainingItems)
        pnlRemainingItems.Controls.Add(lblRemainingItemsTitle)
        pnlRemainingItems.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        pnlRemainingItems.Location = New Point(870, 720)
        pnlRemainingItems.Name = "pnlRemainingItems"
        pnlRemainingItems.Size = New Size(830, 350)
        pnlRemainingItems.TabIndex = 6
        ' 
        ' txtSearchRemaining
        ' 
        txtSearchRemaining.BorderStyle = BorderStyle.FixedSingle
        txtSearchRemaining.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearchRemaining.Location = New Point(460, 10)
        txtSearchRemaining.Name = "txtSearchRemaining"
        txtSearchRemaining.PlaceholderText = "Search remaining..."
        txtSearchRemaining.Size = New Size(360, 28)
        txtSearchRemaining.TabIndex = 5
        ' 
        ' dgvRemainingItems
        ' 
        dgvRemainingItems.AllowUserToAddRows = False
        dgvRemainingItems.AllowUserToDeleteRows = False
        dgvRemainingItems.AllowUserToResizeRows = False
        dgvRemainingItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvRemainingItems.BackgroundColor = Color.White
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = SystemColors.Control
        DataGridViewCellStyle12.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle12.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.True
        dgvRemainingItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        dgvRemainingItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRemainingItems.Columns.AddRange(New DataGridViewColumn() {colRemainingPropertyNo, colRemainingDescription, colRemainingEndUser, colRemainingLocation})
        dgvRemainingItems.Location = New Point(10, 45)
        dgvRemainingItems.MultiSelect = False
        dgvRemainingItems.Name = "dgvRemainingItems"
        dgvRemainingItems.ReadOnly = True
        DataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = SystemColors.Control
        DataGridViewCellStyle13.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle13.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = DataGridViewTriState.True
        dgvRemainingItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        dgvRemainingItems.RowHeadersVisible = False
        dgvRemainingItems.RowHeadersWidth = 62
        dgvRemainingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRemainingItems.Size = New Size(810, 290)
        dgvRemainingItems.TabIndex = 4
        ' 
        ' colRemainingPropertyNo
        ' 
        colRemainingPropertyNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colRemainingPropertyNo.HeaderText = "Property No."
        colRemainingPropertyNo.MinimumWidth = 8
        colRemainingPropertyNo.Name = "colRemainingPropertyNo"
        colRemainingPropertyNo.ReadOnly = True
        colRemainingPropertyNo.Width = 177
        ' 
        ' colRemainingDescription
        ' 
        colRemainingDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colRemainingDescription.HeaderText = "Description"
        colRemainingDescription.MinimumWidth = 8
        colRemainingDescription.Name = "colRemainingDescription"
        colRemainingDescription.ReadOnly = True
        colRemainingDescription.Width = 280
        ' 
        ' colRemainingEndUser
        ' 
        colRemainingEndUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colRemainingEndUser.HeaderText = "End User"
        colRemainingEndUser.MinimumWidth = 8
        colRemainingEndUser.Name = "colRemainingEndUser"
        colRemainingEndUser.ReadOnly = True
        colRemainingEndUser.Width = 175
        ' 
        ' colRemainingLocation
        ' 
        colRemainingLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colRemainingLocation.HeaderText = "Location"
        colRemainingLocation.MinimumWidth = 8
        colRemainingLocation.Name = "colRemainingLocation"
        colRemainingLocation.ReadOnly = True
        colRemainingLocation.Width = 175
        ' 
        ' lblRemainingItemsTitle
        ' 
        lblRemainingItemsTitle.AutoSize = True
        lblRemainingItemsTitle.Font = New Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRemainingItemsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        lblRemainingItemsTitle.Location = New Point(10, 8)
        lblRemainingItemsTitle.Name = "lblRemainingItemsTitle"
        lblRemainingItemsTitle.Size = New Size(362, 29)
        lblRemainingItemsTitle.TabIndex = 3
        lblRemainingItemsTitle.Text = "6. Remaining / Not Yet Scanned Items"
        ' 
        ' frmQRScan
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1896, 1170)
        Controls.Add(pnlMain)
        Controls.Add(pnlSidebar)
        MinimumSize = New Size(1100, 750)
        Name = "frmQRScan"
        StartPosition = FormStartPosition.CenterScreen
        Text = "QR Scan / Physical Inventory"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMain.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(picQRHeader, ComponentModel.ISupportInitialize).EndInit()
        pnlFoundItems.ResumeLayout(False)
        pnlFoundItems.PerformLayout()
        CType(dgvFoundItems, ComponentModel.ISupportInitialize).EndInit()
        pnlInventoryCount.ResumeLayout(False)
        pnlInventoryCount.PerformLayout()
        pnlCountProgress.ResumeLayout(False)
        pnlCountProgress.PerformLayout()
        pnlProgress.ResumeLayout(False)
        pnlRemaining.ResumeLayout(False)
        pnlScanned.ResumeLayout(False)
        pnlExpected.ResumeLayout(False)
        pnlScanProperty.ResumeLayout(False)
        pnlScanProperty.PerformLayout()
        pnlQRScanArea.ResumeLayout(False)
        pnlQRScanArea.PerformLayout()
        CType(picQRScan, ComponentModel.ISupportInitialize).EndInit()
        pnlManualMode.ResumeLayout(False)
        pnlManualMode.PerformLayout()
        pnlCurrentItem.ResumeLayout(False)
        pnlCurrentItem.PerformLayout()
        CType(picCurrentItem, ComponentModel.ISupportInitialize).EndInit()
        pnlScannedItems.ResumeLayout(False)
        pnlScannedItems.PerformLayout()
        CType(dgvScannedItems, ComponentModel.ISupportInitialize).EndInit()
        pnlRemainingItems.ResumeLayout(False)
        pnlRemainingItems.PerformLayout()
        CType(dgvRemainingItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnQRScan As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblQRTitle As Label
    Friend WithEvents lblQRSubtitle As Label
    Friend WithEvents lblHeaderTime As Label
    Friend WithEvents lblHeaderDate As Label
    Friend WithEvents lblHeaderUser As Label
    Friend WithEvents pnlInventoryCount As Panel
    Friend WithEvents picQRHeader As PictureBox
    Friend WithEvents pnlCountProgress As Panel
    Friend WithEvents pnlScanProperty As Panel
    Friend WithEvents pnlCurrentItem As Panel
    Friend WithEvents pnlScannedItems As Panel
    Friend WithEvents pnlRemainingItems As Panel
    Friend WithEvents lblInventoryCountTitle As Label
    Friend WithEvents lblInventoryYear As Label
    Friend WithEvents cmbInventoryYear As ComboBox
    Friend WithEvents cmbLocation As ComboBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents cmbEndUser As ComboBox
    Friend WithEvents lblEndUser As Label
    Friend WithEvents btnStartCount As Button
    Friend WithEvents cmbClassification As ComboBox
    Friend WithEvents lblClassification As Label
    Friend WithEvents btnResetCount As Button
    Friend WithEvents lblCountProgressTitle As Label
    Friend WithEvents pnlExpected As Panel
    Friend WithEvents pnlScanned As Panel
    Friend WithEvents pnlProgress As Panel
    Friend WithEvents pnlRemaining As Panel
    Friend WithEvents lblExpectedTitle As Label
    Friend WithEvents lblExpectedCount As Label
    Friend WithEvents lblScannedTitle As Label
    Friend WithEvents lblScannedCount As Label
    Friend WithEvents lblProgressTitle As Label
    Friend WithEvents lblRemainingCount As Label
    Friend WithEvents lblRemainingTitle As Label
    Friend WithEvents progressInventory As ProgressBar
    Friend WithEvents lblProgressValue As Label
    Friend WithEvents lblProgressCount As Label
    Friend WithEvents btnScanQRCode As Button
    Friend WithEvents lblScanPropertyTitle As Label
    Friend WithEvents btnManualSearch As Button
    Friend WithEvents pnlQRScanArea As Panel
    Friend WithEvents picQRScan As PictureBox
    Friend WithEvents lblScanQRHere As Label
    Friend WithEvents lblScanInstruction As Label
    Friend WithEvents pnlManualMode As Panel
    Friend WithEvents lblManualPropertyNo As Label
    Friend WithEvents txtManualPropertyNo As TextBox
    Friend WithEvents btnSearchProperty As Button
    Friend WithEvents lblCurrentItemTitle As Label
    Friend WithEvents lblCurrentPropertyNoValue As Label
    Friend WithEvents lblCurrentPropertyNo As Label
    Friend WithEvents lblCurrentDescriptionValue As Label
    Friend WithEvents lblCurrentDescription As Label
    Friend WithEvents lblCurrentDateAcquiredValue As Label
    Friend WithEvents lblCurrentDateAcquired As Label
    Friend WithEvents lblCurrentLocationValue As Label
    Friend WithEvents lblCurrentLocation As Label
    Friend WithEvents lblCurrentConditionValue As Label
    Friend WithEvents lblCurrentCondition As Label
    Friend WithEvents lblCurrentEndUserValue As Label
    Friend WithEvents lblCurrentEndUser As Label
    Friend WithEvents lblCurrentUnitCost As Label
    Friend WithEvents btnMarkAccounted As Button
    Friend WithEvents lblCurrentUnitCostValue As Label
    Friend WithEvents btnOpenInventory As Button
    Friend WithEvents dgvScannedItems As DataGridView
    Friend WithEvents lblScannedItemsTitle As Label
    Friend WithEvents dgvRemainingItems As DataGridView
    Friend WithEvents lblRemainingItemsTitle As Label
    Friend WithEvents txtSearchScanned As TextBox
    Friend WithEvents colRemainingPropertyNo As DataGridViewTextBoxColumn
    Friend WithEvents colRemainingDescription As DataGridViewTextBoxColumn
    Friend WithEvents colRemainingEndUser As DataGridViewTextBoxColumn
    Friend WithEvents colRemainingLocation As DataGridViewTextBoxColumn
    Friend WithEvents txtSearchRemaining As TextBox
    Friend WithEvents colScannedNo As DataGridViewTextBoxColumn
    Friend WithEvents colScannedDateTime As DataGridViewTextBoxColumn
    Friend WithEvents colScannedPropertyNo As DataGridViewTextBoxColumn
    Friend WithEvents colScannedDescription As DataGridViewTextBoxColumn
    Friend WithEvents colScannedEndUser As DataGridViewTextBoxColumn
    Friend WithEvents colScannedLocation As DataGridViewTextBoxColumn
    Friend WithEvents colScannedStatus As DataGridViewTextBoxColumn
    Friend WithEvents picCurrentItem As PictureBox
    Friend WithEvents lblItemPhotoTitle As Label
    Friend WithEvents rdoQRCode As RadioButton
    Friend WithEvents rdoBarcode As RadioButton
    Friend WithEvents txtBarcodeInput As TextBox
    Friend WithEvents lblScannedRecordCount As Label
    Friend WithEvents btnRegisterFoundItem As Button
    Friend WithEvents pnlFoundItems As Panel
    Friend WithEvents lblFoundItemsTitle As Label
    Friend WithEvents btnDeleteFoundItem As Button
    Friend WithEvents btnOpenFoundItem As Button
    Friend WithEvents btnRefreshFoundItems As Button
    Friend WithEvents txtSearchFoundItems As TextBox
    Friend WithEvents dgvFoundItems As DataGridView
End Class
