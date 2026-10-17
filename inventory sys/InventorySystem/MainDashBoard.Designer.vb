<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashBoard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New DataVisualization.Charting.Title()
        pnlSidebar = New Panel()
        btnSettings = New Button()
        btnQRScan = New Button()
        btnReports = New Button()
        btnInventory = New Button()
        btnDashboard = New Button()
        pnlHeader = New Panel()
        lblTitle = New Label()
        pnlMain = New Panel()
        pnlLocationSummary = New Panel()
        dgvLocationSummary = New DataGridView()
        colRank = New DataGridViewTextBoxColumn()
        colLocation = New DataGridViewTextBoxColumn()
        colTotalItems = New DataGridViewTextBoxColumn()
        colPPE = New DataGridViewTextBoxColumn()
        colSEMI = New DataGridViewTextBoxColumn()
        colTotalValue = New DataGridViewTextBoxColumn()
        chartLocation = New DataVisualization.Charting.Chart()
        lblLocationSummary = New Label()
        chartCondition = New DataVisualization.Charting.Chart()
        chartAccountability = New DataVisualization.Charting.Chart()
        chartClassification = New DataVisualization.Charting.Chart()
        pnlUnaccounted = New Panel()
        lblUnaccountedCount = New Label()
        lblUnaccounted = New Label()
        pnlAccounted = New Panel()
        lblAccountedCount = New Label()
        lblAccounted = New Label()
        pnlTotalValue = New Panel()
        lblTotalInventoryValue = New Label()
        lblTotalValue = New Label()
        pnlTotalInventory = New Panel()
        lblTotalInventoryCount = New Label()
        lblTotalInventory = New Label()
        pnlUnserviceable = New Panel()
        lblUnservCount = New Label()
        lblUnserviceable = New Label()
        pnlRepair = New Panel()
        lblRepairCount = New Label()
        lblRepair = New Label()
        pnlTotalSemi = New Panel()
        lblSemiCount = New Label()
        lblTotalSemi = New Label()
        pnlTotalPPE = New Panel()
        lblPPECount = New Label()
        lblPPEText = New Label()
        pnlSidebar.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlMain.SuspendLayout()
        pnlLocationSummary.SuspendLayout()
        CType(dgvLocationSummary, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartLocation, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartCondition, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartAccountability, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartClassification, ComponentModel.ISupportInitialize).BeginInit()
        pnlUnaccounted.SuspendLayout()
        pnlAccounted.SuspendLayout()
        pnlTotalValue.SuspendLayout()
        pnlTotalInventory.SuspendLayout()
        pnlUnserviceable.SuspendLayout()
        pnlRepair.SuspendLayout()
        pnlTotalSemi.SuspendLayout()
        pnlTotalPPE.SuspendLayout()
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
        pnlSidebar.Size = New Size(170, 694)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.Transparent
        btnSettings.Cursor = Cursors.Hand
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSettings.ForeColor = Color.White
        btnSettings.Location = New Point(10, 280)
        btnSettings.Name = "btnSettings"
        btnSettings.Padding = New Padding(15, 0, 0, 0)
        btnSettings.Size = New Size(160, 40)
        btnSettings.TabIndex = 6
        btnSettings.Text = "Settings"
        btnSettings.TextAlign = ContentAlignment.MiddleLeft
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnQRScan
        ' 
        btnQRScan.BackColor = Color.Transparent
        btnQRScan.Cursor = Cursors.Hand
        btnQRScan.FlatAppearance.BorderSize = 0
        btnQRScan.FlatStyle = FlatStyle.Flat
        btnQRScan.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnQRScan.ForeColor = Color.White
        btnQRScan.Location = New Point(10, 230)
        btnQRScan.Name = "btnQRScan"
        btnQRScan.Padding = New Padding(15, 0, 0, 0)
        btnQRScan.Size = New Size(160, 40)
        btnQRScan.TabIndex = 5
        btnQRScan.Text = "QR Scan"
        btnQRScan.TextAlign = ContentAlignment.MiddleLeft
        btnQRScan.UseVisualStyleBackColor = False
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.Transparent
        btnReports.Cursor = Cursors.Hand
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(10, 180)
        btnReports.Name = "btnReports"
        btnReports.Padding = New Padding(15, 0, 0, 0)
        btnReports.Size = New Size(160, 40)
        btnReports.TabIndex = 4
        btnReports.Text = "Reports"
        btnReports.TextAlign = ContentAlignment.MiddleLeft
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' btnInventory
        ' 
        btnInventory.BackColor = Color.Transparent
        btnInventory.Cursor = Cursors.Hand
        btnInventory.FlatAppearance.BorderSize = 0
        btnInventory.FlatStyle = FlatStyle.Flat
        btnInventory.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnInventory.ForeColor = Color.White
        btnInventory.Location = New Point(10, 130)
        btnInventory.Name = "btnInventory"
        btnInventory.Padding = New Padding(15, 0, 0, 0)
        btnInventory.Size = New Size(160, 40)
        btnInventory.TabIndex = 3
        btnInventory.Text = "Inventory"
        btnInventory.TextAlign = ContentAlignment.MiddleLeft
        btnInventory.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.Cursor = Cursors.Hand
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(10, 80)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(15, 0, 0, 0)
        btnDashboard.Size = New Size(160, 40)
        btnDashboard.TabIndex = 2
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(170, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(908, 100)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 16F)
        lblTitle.ForeColor = Color.Transparent
        lblTitle.Location = New Point(20, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(351, 45)
        lblTitle.TabIndex = 1
        lblTitle.Text = "WMC Inventory System"
        ' 
        ' pnlMain
        ' 
        pnlMain.AutoScroll = True
        pnlMain.BackColor = Color.White
        pnlMain.Controls.Add(pnlLocationSummary)
        pnlMain.Controls.Add(chartCondition)
        pnlMain.Controls.Add(chartAccountability)
        pnlMain.Controls.Add(chartClassification)
        pnlMain.Controls.Add(pnlUnaccounted)
        pnlMain.Controls.Add(pnlAccounted)
        pnlMain.Controls.Add(pnlTotalValue)
        pnlMain.Controls.Add(pnlTotalInventory)
        pnlMain.Controls.Add(pnlUnserviceable)
        pnlMain.Controls.Add(pnlRepair)
        pnlMain.Controls.Add(pnlTotalSemi)
        pnlMain.Controls.Add(pnlTotalPPE)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(170, 100)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(908, 594)
        pnlMain.TabIndex = 1
        ' 
        ' pnlLocationSummary
        ' 
        pnlLocationSummary.BorderStyle = BorderStyle.FixedSingle
        pnlLocationSummary.Controls.Add(dgvLocationSummary)
        pnlLocationSummary.Controls.Add(chartLocation)
        pnlLocationSummary.Controls.Add(lblLocationSummary)
        pnlLocationSummary.Location = New Point(20, 680)
        pnlLocationSummary.Name = "pnlLocationSummary"
        pnlLocationSummary.Size = New Size(1610, 300)
        pnlLocationSummary.TabIndex = 14
        ' 
        ' dgvLocationSummary
        ' 
        dgvLocationSummary.AllowUserToAddRows = False
        dgvLocationSummary.AllowUserToDeleteRows = False
        dgvLocationSummary.AllowUserToResizeRows = False
        dgvLocationSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvLocationSummary.BackgroundColor = Color.White
        dgvLocationSummary.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvLocationSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvLocationSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLocationSummary.Columns.AddRange(New DataGridViewColumn() {colRank, colLocation, colTotalItems, colPPE, colSEMI, colTotalValue})
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvLocationSummary.DefaultCellStyle = DataGridViewCellStyle2
        dgvLocationSummary.Location = New Point(640, 30)
        dgvLocationSummary.Name = "dgvLocationSummary"
        dgvLocationSummary.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvLocationSummary.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvLocationSummary.RowHeadersWidth = 62
        dgvLocationSummary.Size = New Size(960, 220)
        dgvLocationSummary.TabIndex = 2
        ' 
        ' colRank
        ' 
        colRank.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colRank.FillWeight = 8.47242451F
        colRank.HeaderText = "#"
        colRank.MinimumWidth = 8
        colRank.Name = "colRank"
        colRank.ReadOnly = True
        colRank.Width = 30
        ' 
        ' colLocation
        ' 
        colLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colLocation.FillWeight = 135.346985F
        colLocation.HeaderText = "Location"
        colLocation.MinimumWidth = 8
        colLocation.Name = "colLocation"
        colLocation.ReadOnly = True
        colLocation.Width = 220
        ' 
        ' colTotalItems
        ' 
        colTotalItems.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colTotalItems.FillWeight = 327.212067F
        colTotalItems.HeaderText = "Total Items"
        colTotalItems.MinimumWidth = 8
        colTotalItems.Name = "colTotalItems"
        colTotalItems.ReadOnly = True
        colTotalItems.Width = 150
        ' 
        ' colPPE
        ' 
        colPPE.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colPPE.FillWeight = 21.7669659F
        colPPE.HeaderText = "PPE"
        colPPE.MinimumWidth = 8
        colPPE.Name = "colPPE"
        colPPE.ReadOnly = True
        colPPE.Width = 150
        ' 
        ' colSEMI
        ' 
        colSEMI.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colSEMI.FillWeight = 7.20156145F
        colSEMI.HeaderText = "SEMI"
        colSEMI.MinimumWidth = 8
        colSEMI.Name = "colSEMI"
        colSEMI.ReadOnly = True
        colSEMI.Width = 150
        ' 
        ' colTotalValue
        ' 
        colTotalValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colTotalValue.HeaderText = "Total Value"
        colTotalValue.MinimumWidth = 8
        colTotalValue.Name = "colTotalValue"
        colTotalValue.ReadOnly = True
        colTotalValue.Width = 200
        ' 
        ' chartLocation
        ' 
        chartLocation.BorderlineColor = Color.Black
        chartLocation.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "ChartArea1"
        chartLocation.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        chartLocation.Legends.Add(Legend1)
        chartLocation.Location = New Point(20, 30)
        chartLocation.Name = "chartLocation"
        chartLocation.Palette = DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Series1.IsXValueIndexed = True
        Series1.Legend = "Legend1"
        Series1.Name = "LocationSeries"
        Series1.XValueType = DataVisualization.Charting.ChartValueType.String
        Series1.YValueType = DataVisualization.Charting.ChartValueType.Int32
        chartLocation.Series.Add(Series1)
        chartLocation.Size = New Size(600, 220)
        chartLocation.TabIndex = 1
        chartLocation.Text = "Chart1"
        ' 
        ' lblLocationSummary
        ' 
        lblLocationSummary.AutoSize = True
        lblLocationSummary.Location = New Point(0, 0)
        lblLocationSummary.Name = "lblLocationSummary"
        lblLocationSummary.Size = New Size(243, 25)
        lblLocationSummary.TabIndex = 0
        lblLocationSummary.Text = "Inventory by Location (Top 5)"
        ' 
        ' chartCondition
        ' 
        chartCondition.BorderlineColor = Color.Black
        chartCondition.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "ChartArea1"
        chartCondition.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        chartCondition.Legends.Add(Legend2)
        chartCondition.Location = New Point(1100, 270)
        chartCondition.Name = "chartCondition"
        chartCondition.Palette = DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "ConditionSeries"
        chartCondition.Series.Add(Series2)
        chartCondition.Size = New Size(530, 400)
        chartCondition.TabIndex = 13
        chartCondition.Text = "Chart1"
        Title1.IsDockedInsideChartArea = False
        Title1.Name = "Title1"
        Title1.Text = "Condition Status"
        chartCondition.Titles.Add(Title1)
        ' 
        ' chartAccountability
        ' 
        chartAccountability.BorderlineColor = Color.Black
        chartAccountability.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea3.Name = "ChartArea1"
        chartAccountability.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        chartAccountability.Legends.Add(Legend3)
        chartAccountability.Location = New Point(560, 270)
        chartAccountability.Name = "chartAccountability"
        chartAccountability.Palette = DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
        Series3.Legend = "Legend1"
        Series3.Name = "AccountabilitySeries"
        Series3.YValuesPerPoint = 4
        chartAccountability.Series.Add(Series3)
        chartAccountability.Size = New Size(530, 400)
        chartAccountability.TabIndex = 12
        chartAccountability.Text = "Accountability Status"
        Title2.Name = "Accountability Status"
        Title2.Text = "Accountability Status"
        chartAccountability.Titles.Add(Title2)
        ' 
        ' chartClassification
        ' 
        chartClassification.BorderlineColor = Color.Black
        chartClassification.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea4.Name = "ClassificationArea"
        chartClassification.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        chartClassification.Legends.Add(Legend4)
        chartClassification.Location = New Point(20, 270)
        chartClassification.Name = "chartClassification"
        chartClassification.Palette = DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series4.ChartArea = "ClassificationArea"
        Series4.ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Series4.Legend = "Legend1"
        Series4.Name = "ClassificationSeries"
        chartClassification.Series.Add(Series4)
        chartClassification.Size = New Size(530, 400)
        chartClassification.TabIndex = 11
        chartClassification.Text = "ClassificationArea"
        Title3.Name = "Title1"
        Title3.Text = "Inventory Classification"
        chartClassification.Titles.Add(Title3)
        ' 
        ' pnlUnaccounted
        ' 
        pnlUnaccounted.BackColor = Color.WhiteSmoke
        pnlUnaccounted.Controls.Add(lblUnaccountedCount)
        pnlUnaccounted.Controls.Add(lblUnaccounted)
        pnlUnaccounted.Location = New Point(440, 140)
        pnlUnaccounted.Name = "pnlUnaccounted"
        pnlUnaccounted.Size = New Size(350, 110)
        pnlUnaccounted.TabIndex = 9
        ' 
        ' lblUnaccountedCount
        ' 
        lblUnaccountedCount.AutoSize = True
        lblUnaccountedCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUnaccountedCount.ForeColor = Color.Black
        lblUnaccountedCount.Location = New Point(15, 45)
        lblUnaccountedCount.Name = "lblUnaccountedCount"
        lblUnaccountedCount.Size = New Size(46, 54)
        lblUnaccountedCount.TabIndex = 1
        lblUnaccountedCount.Text = "0"
        ' 
        ' lblUnaccounted
        ' 
        lblUnaccounted.AutoSize = True
        lblUnaccounted.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUnaccounted.ForeColor = Color.DimGray
        lblUnaccounted.Location = New Point(15, 15)
        lblUnaccounted.Name = "lblUnaccounted"
        lblUnaccounted.Size = New Size(194, 28)
        lblUnaccounted.TabIndex = 0
        lblUnaccounted.Text = "Unaccounted Items"
        ' 
        ' pnlAccounted
        ' 
        pnlAccounted.BackColor = Color.WhiteSmoke
        pnlAccounted.Controls.Add(lblAccountedCount)
        pnlAccounted.Controls.Add(lblAccounted)
        pnlAccounted.Location = New Point(20, 140)
        pnlAccounted.Name = "pnlAccounted"
        pnlAccounted.Size = New Size(400, 110)
        pnlAccounted.TabIndex = 8
        ' 
        ' lblAccountedCount
        ' 
        lblAccountedCount.AutoSize = True
        lblAccountedCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAccountedCount.ForeColor = Color.Black
        lblAccountedCount.Location = New Point(15, 45)
        lblAccountedCount.Name = "lblAccountedCount"
        lblAccountedCount.Size = New Size(46, 54)
        lblAccountedCount.TabIndex = 1
        lblAccountedCount.Text = "0"
        ' 
        ' lblAccounted
        ' 
        lblAccounted.AutoSize = True
        lblAccounted.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAccounted.ForeColor = Color.DimGray
        lblAccounted.Location = New Point(15, 15)
        lblAccounted.Name = "lblAccounted"
        lblAccounted.Size = New Size(171, 28)
        lblAccounted.TabIndex = 0
        lblAccounted.Text = "Accounted Items"
        ' 
        ' pnlTotalValue
        ' 
        pnlTotalValue.BackColor = Color.WhiteSmoke
        pnlTotalValue.Controls.Add(lblTotalInventoryValue)
        pnlTotalValue.Controls.Add(lblTotalValue)
        pnlTotalValue.Location = New Point(1280, 20)
        pnlTotalValue.Name = "pnlTotalValue"
        pnlTotalValue.Size = New Size(350, 110)
        pnlTotalValue.TabIndex = 7
        ' 
        ' lblTotalInventoryValue
        ' 
        lblTotalInventoryValue.AutoSize = True
        lblTotalInventoryValue.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalInventoryValue.ForeColor = Color.Black
        lblTotalInventoryValue.Location = New Point(15, 45)
        lblTotalInventoryValue.Name = "lblTotalInventoryValue"
        lblTotalInventoryValue.Size = New Size(46, 54)
        lblTotalInventoryValue.TabIndex = 2
        lblTotalInventoryValue.Text = "0"
        ' 
        ' lblTotalValue
        ' 
        lblTotalValue.AutoSize = True
        lblTotalValue.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalValue.ForeColor = Color.DimGray
        lblTotalValue.Location = New Point(15, 15)
        lblTotalValue.Name = "lblTotalValue"
        lblTotalValue.Size = New Size(214, 28)
        lblTotalValue.TabIndex = 1
        lblTotalValue.Text = "Total Inventory Value"
        ' 
        ' pnlTotalInventory
        ' 
        pnlTotalInventory.BackColor = Color.WhiteSmoke
        pnlTotalInventory.Controls.Add(lblTotalInventoryCount)
        pnlTotalInventory.Controls.Add(lblTotalInventory)
        pnlTotalInventory.Location = New Point(20, 20)
        pnlTotalInventory.Name = "pnlTotalInventory"
        pnlTotalInventory.Size = New Size(400, 110)
        pnlTotalInventory.TabIndex = 6
        ' 
        ' lblTotalInventoryCount
        ' 
        lblTotalInventoryCount.AutoSize = True
        lblTotalInventoryCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalInventoryCount.ForeColor = Color.Black
        lblTotalInventoryCount.Location = New Point(15, 45)
        lblTotalInventoryCount.Name = "lblTotalInventoryCount"
        lblTotalInventoryCount.Size = New Size(46, 54)
        lblTotalInventoryCount.TabIndex = 2
        lblTotalInventoryCount.Text = "0"
        ' 
        ' lblTotalInventory
        ' 
        lblTotalInventory.AutoSize = True
        lblTotalInventory.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalInventory.ForeColor = Color.DimGray
        lblTotalInventory.Location = New Point(15, 15)
        lblTotalInventory.Name = "lblTotalInventory"
        lblTotalInventory.Size = New Size(215, 28)
        lblTotalInventory.TabIndex = 1
        lblTotalInventory.Text = "Total Inventory Items"
        ' 
        ' pnlUnserviceable
        ' 
        pnlUnserviceable.BackColor = Color.WhiteSmoke
        pnlUnserviceable.Controls.Add(lblUnservCount)
        pnlUnserviceable.Controls.Add(lblUnserviceable)
        pnlUnserviceable.Location = New Point(1280, 140)
        pnlUnserviceable.Name = "pnlUnserviceable"
        pnlUnserviceable.Size = New Size(350, 110)
        pnlUnserviceable.TabIndex = 5
        ' 
        ' lblUnservCount
        ' 
        lblUnservCount.AutoSize = True
        lblUnservCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUnservCount.ForeColor = Color.Black
        lblUnservCount.Location = New Point(15, 45)
        lblUnservCount.Name = "lblUnservCount"
        lblUnservCount.Size = New Size(46, 54)
        lblUnservCount.TabIndex = 1
        lblUnservCount.Text = "0"
        ' 
        ' lblUnserviceable
        ' 
        lblUnserviceable.AutoSize = True
        lblUnserviceable.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUnserviceable.ForeColor = Color.DimGray
        lblUnserviceable.Location = New Point(15, 15)
        lblUnserviceable.Name = "lblUnserviceable"
        lblUnserviceable.Size = New Size(145, 28)
        lblUnserviceable.TabIndex = 0
        lblUnserviceable.Text = "Unserviceable"
        ' 
        ' pnlRepair
        ' 
        pnlRepair.BackColor = Color.WhiteSmoke
        pnlRepair.Controls.Add(lblRepairCount)
        pnlRepair.Controls.Add(lblRepair)
        pnlRepair.Location = New Point(860, 140)
        pnlRepair.Name = "pnlRepair"
        pnlRepair.Size = New Size(350, 110)
        pnlRepair.TabIndex = 4
        ' 
        ' lblRepairCount
        ' 
        lblRepairCount.AutoSize = True
        lblRepairCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRepairCount.ForeColor = Color.Black
        lblRepairCount.Location = New Point(15, 45)
        lblRepairCount.Name = "lblRepairCount"
        lblRepairCount.Size = New Size(46, 54)
        lblRepairCount.TabIndex = 1
        lblRepairCount.Text = "0"
        ' 
        ' lblRepair
        ' 
        lblRepair.AutoSize = True
        lblRepair.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRepair.ForeColor = Color.DimGray
        lblRepair.Location = New Point(15, 15)
        lblRepair.Name = "lblRepair"
        lblRepair.Size = New Size(165, 28)
        lblRepair.TabIndex = 0
        lblRepair.Text = "Items for Repair"
        ' 
        ' pnlTotalSemi
        ' 
        pnlTotalSemi.BackColor = Color.WhiteSmoke
        pnlTotalSemi.Controls.Add(lblSemiCount)
        pnlTotalSemi.Controls.Add(lblTotalSemi)
        pnlTotalSemi.Location = New Point(860, 20)
        pnlTotalSemi.Name = "pnlTotalSemi"
        pnlTotalSemi.Size = New Size(350, 110)
        pnlTotalSemi.TabIndex = 3
        ' 
        ' lblSemiCount
        ' 
        lblSemiCount.AutoSize = True
        lblSemiCount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSemiCount.ForeColor = Color.Black
        lblSemiCount.Location = New Point(15, 45)
        lblSemiCount.Name = "lblSemiCount"
        lblSemiCount.Size = New Size(46, 54)
        lblSemiCount.TabIndex = 1
        lblSemiCount.Text = "0"
        ' 
        ' lblTotalSemi
        ' 
        lblTotalSemi.AutoSize = True
        lblTotalSemi.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalSemi.ForeColor = Color.DimGray
        lblTotalSemi.Location = New Point(15, 12)
        lblTotalSemi.Name = "lblTotalSemi"
        lblTotalSemi.Size = New Size(186, 21)
        lblTotalSemi.TabIndex = 0
        lblTotalSemi.Text = "Total Semi-Expendable"
        ' 
        ' pnlTotalPPE
        ' 
        pnlTotalPPE.BackColor = Color.WhiteSmoke
        pnlTotalPPE.Controls.Add(lblPPECount)
        pnlTotalPPE.Controls.Add(lblPPEText)
        pnlTotalPPE.Location = New Point(440, 20)
        pnlTotalPPE.Name = "pnlTotalPPE"
        pnlTotalPPE.Size = New Size(350, 110)
        pnlTotalPPE.TabIndex = 2
        ' 
        ' lblPPECount
        ' 
        lblPPECount.AutoSize = True
        lblPPECount.Font = New Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPPECount.ForeColor = Color.Black
        lblPPECount.Location = New Point(15, 45)
        lblPPECount.Name = "lblPPECount"
        lblPPECount.Size = New Size(46, 54)
        lblPPECount.TabIndex = 1
        lblPPECount.Text = "0"
        ' 
        ' lblPPEText
        ' 
        lblPPEText.AutoSize = True
        lblPPEText.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPPEText.ForeColor = Color.DimGray
        lblPPEText.Location = New Point(15, 15)
        lblPPEText.Name = "lblPPEText"
        lblPPEText.Size = New Size(158, 28)
        lblPPEText.TabIndex = 0
        lblPPEText.Text = "Total PPE Items"
        ' 
        ' MainDashBoard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1078, 694)
        Controls.Add(pnlMain)
        Controls.Add(pnlHeader)
        Controls.Add(pnlSidebar)
        MinimumSize = New Size(1100, 750)
        Name = "MainDashBoard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventory Management System"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlMain.ResumeLayout(False)
        pnlLocationSummary.ResumeLayout(False)
        pnlLocationSummary.PerformLayout()
        CType(dgvLocationSummary, ComponentModel.ISupportInitialize).EndInit()
        CType(chartLocation, ComponentModel.ISupportInitialize).EndInit()
        CType(chartCondition, ComponentModel.ISupportInitialize).EndInit()
        CType(chartAccountability, ComponentModel.ISupportInitialize).EndInit()
        CType(chartClassification, ComponentModel.ISupportInitialize).EndInit()
        pnlUnaccounted.ResumeLayout(False)
        pnlUnaccounted.PerformLayout()
        pnlAccounted.ResumeLayout(False)
        pnlAccounted.PerformLayout()
        pnlTotalValue.ResumeLayout(False)
        pnlTotalValue.PerformLayout()
        pnlTotalInventory.ResumeLayout(False)
        pnlTotalInventory.PerformLayout()
        pnlUnserviceable.ResumeLayout(False)
        pnlUnserviceable.PerformLayout()
        pnlRepair.ResumeLayout(False)
        pnlRepair.PerformLayout()
        pnlTotalSemi.ResumeLayout(False)
        pnlTotalSemi.PerformLayout()
        pnlTotalPPE.ResumeLayout(False)
        pnlTotalPPE.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnQRScan As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlTotalPPE As Panel
    Friend WithEvents lblPPECount As Label
    Friend WithEvents lblPPEText As Label
    Friend WithEvents pnlTotalSemi As Panel
    Friend WithEvents lblSemiCount As Label
    Friend WithEvents lblTotalSemi As Label
    Friend WithEvents pnlUnserviceable As Panel
    Friend WithEvents lblUnservCount As Label
    Friend WithEvents lblUnserviceable As Label
    Friend WithEvents pnlRepair As Panel
    Friend WithEvents lblRepairCount As Label
    Friend WithEvents lblRepair As Label
    Friend WithEvents pnlTotalInventory As Panel
    Friend WithEvents lblTotalInventory As Label
    Friend WithEvents lblTotalInventoryCount As Label
    Friend WithEvents pnlTotalValue As Panel
    Friend WithEvents lblTotalInventoryValue As Label
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents pnlUnaccounted As Panel
    Friend WithEvents lblUnaccountedCount As Label
    Friend WithEvents lblUnaccounted As Label
    Friend WithEvents pnlAccounted As Panel
    Friend WithEvents lblAccountedCount As Label
    Friend WithEvents lblAccounted As Label
    Friend WithEvents chartClassification As DataVisualization.Charting.Chart
    Friend WithEvents chartAccountability As DataVisualization.Charting.Chart
    Friend WithEvents chartCondition As DataVisualization.Charting.Chart
    Friend WithEvents pnlLocationSummary As Panel
    Friend WithEvents lblLocationSummary As Label
    Friend WithEvents chartLocation As DataVisualization.Charting.Chart
    Friend WithEvents dgvLocationSummary As DataGridView
    Friend WithEvents colRank As DataGridViewTextBoxColumn
    Friend WithEvents colLocation As DataGridViewTextBoxColumn
    Friend WithEvents colTotalItems As DataGridViewTextBoxColumn
    Friend WithEvents colPPE As DataGridViewTextBoxColumn
    Friend WithEvents colSEMI As DataGridViewTextBoxColumn
    Friend WithEvents colTotalValue As DataGridViewTextBoxColumn

End Class
