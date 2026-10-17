Imports System.Data.SQLite
Imports QuestPDF.Infrastructure

Public Class MainDashBoard

    ' Shared header information displayed on every page hosted by this dashboard.
    Private lblSharedHeaderDate As Label
    Private lblSharedHeaderTime As Label
    Private lblSharedHeaderUser As Label
    Private headerClockTimer As System.Windows.Forms.Timer
    Private chartCardClassification As Panel
    Private chartCardAccountability As Panel
    Private chartCardCondition As Panel
    Private btnStockInventory As Button
    Private pnlPendingAccountabilityReview As Panel
    Private lblPendingAccountabilityCount As Label
    Private accountabilityReviewForm As frmAccountabilityReview

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub

    Private Sub MainDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        QuestPDF.Settings.License = LicenseType.Evaluation

        ' Explicitly run the shared schema migration at application startup.
        modDatabase.InitializeDatabase()
        LoadDefaultAccountCodes()
        LoadClassificationChart()
        LoadAccountabilityChart()
        LoadTotalInventoryCount()
        LoadPPECount()
        LoadSemiCount()
        LoadTotalInventoryValue()
        LoadRepairCount()
        LoadUnserviceableCount()
        LoadConditionChart()
        LoadLocationChart()

        LoadLocationSummary()

        InitializeSharedHeader()
        InitializeDashboardChartCards()
        InitializeDashboardReviewCard()
        RefreshPendingAccountabilityReviewCount()
        InitializeStockInventoryNavigation()

        ' Responsive layout: keep the sidebar and header docked while the dashboard rearranges.
        Me.AutoSize = False
        Me.AutoScroll = False
        pnlMain.AutoScroll = True
        AddHandler pnlMain.Resize, AddressOf MainContent_Resize
        ArrangeDashboardLayout()

        InitializePageHost()
        ShowDashboardPage()

    End Sub


    Private Sub InitializeSharedHeader()
        If lblSharedHeaderDate IsNot Nothing Then Return

        Dim headerFont As New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Regular)
        Dim headerColor As System.Drawing.Color = System.Drawing.Color.White

        lblSharedHeaderDate = New Label With {
            .Name = "lblSharedHeaderDate",
            .AutoSize = True,
            .BackColor = System.Drawing.Color.Transparent,
            .ForeColor = headerColor,
            .Font = headerFont,
            .TextAlign = ContentAlignment.MiddleRight
        }
        lblSharedHeaderTime = New Label With {
            .Name = "lblSharedHeaderTime",
            .AutoSize = True,
            .BackColor = System.Drawing.Color.Transparent,
            .ForeColor = headerColor,
            .Font = headerFont,
            .TextAlign = ContentAlignment.MiddleRight
        }
        lblSharedHeaderUser = New Label With {
            .Name = "lblSharedHeaderUser",
            .AutoSize = True,
            .BackColor = System.Drawing.Color.Transparent,
            .ForeColor = headerColor,
            .Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight,
            .Text = "Admin"
        }

        pnlHeader.Controls.Add(lblSharedHeaderDate)
        pnlHeader.Controls.Add(lblSharedHeaderTime)
        pnlHeader.Controls.Add(lblSharedHeaderUser)
        lblTitle.ForeColor = headerColor
        lblTitle.BackColor = System.Drawing.Color.Transparent

        AddHandler pnlHeader.Resize, AddressOf SharedHeader_Resize
        headerClockTimer = New System.Windows.Forms.Timer With {.Interval = 30000}
        AddHandler headerClockTimer.Tick, AddressOf SharedHeaderClock_Tick
        UpdateSharedHeaderClock()
        headerClockTimer.Start()
        ArrangeSharedHeader()
    End Sub

    Private Sub SharedHeaderClock_Tick(sender As Object, e As EventArgs)
        UpdateSharedHeaderClock()
    End Sub

    Private Sub UpdateSharedHeaderClock()
        If lblSharedHeaderDate Is Nothing OrElse lblSharedHeaderTime Is Nothing Then Return
        Dim nowValue As DateTime = DateTime.Now
        lblSharedHeaderDate.Text = nowValue.ToString("MMM d, yyyy")
        lblSharedHeaderTime.Text = nowValue.ToString("h:mm tt")
        ArrangeSharedHeader()
    End Sub

    Private Sub SharedHeader_Resize(sender As Object, e As EventArgs)
        ArrangeSharedHeader()
    End Sub

    Private Sub ArrangeSharedHeader()
        If pnlHeader Is Nothing OrElse lblTitle Is Nothing Then Return

        lblTitle.Location = New Point(20, Math.Max(8, (pnlHeader.ClientSize.Height - lblTitle.Height) \ 2))
        If lblSharedHeaderDate Is Nothing OrElse lblSharedHeaderTime Is Nothing OrElse lblSharedHeaderUser Is Nothing Then Return

        Dim rightEdge As Integer = pnlHeader.ClientSize.Width - 20
        Dim centerY As Integer = Math.Max(8, (pnlHeader.ClientSize.Height - lblSharedHeaderUser.Height) \ 2)
        lblSharedHeaderUser.Location = New Point(rightEdge - lblSharedHeaderUser.Width, centerY)
        lblSharedHeaderTime.Location = New Point(lblSharedHeaderUser.Left - 18 - lblSharedHeaderTime.Width, centerY)
        lblSharedHeaderDate.Location = New Point(lblSharedHeaderTime.Left - 18 - lblSharedHeaderDate.Width, centerY)
    End Sub

    Private Sub MainContent_Resize(sender As Object, e As EventArgs)
        ArrangeDashboardLayout()
    End Sub

    Private Sub ArrangeDashboardLayout()
        If pnlMain Is Nothing OrElse pnlMain.IsDisposed Then Return
        If pnlMain.ClientSize.Width <= 0 Then Return

        Dim contentWidth As Integer = pnlMain.ClientSize.Width
        Dim margin As Integer = 20
        Dim gap As Integer = 15
        Dim usableWidth As Integer = Math.Max(250, contentWidth - (margin * 2))

        ' Keep the eight summary cards in a compact grid. The accountability review
        ' card stays compact in width, but is taller so its title, count, and hint fit vertically.
        Dim cardPanels As Panel() = {
            pnlTotalInventory, pnlTotalPPE, pnlTotalSemi, pnlTotalValue,
            pnlAccounted, pnlUnaccounted, pnlRepair, pnlUnserviceable
        }

        Dim cardColumns As Integer
        If usableWidth >= 1100 Then
            cardColumns = 4
        ElseIf usableWidth >= 600 Then
            cardColumns = 2
        Else
            cardColumns = 1
        End If

        Dim cardWidth As Integer = Math.Max(200,
            (usableWidth - (gap * (cardColumns - 1))) \ cardColumns)
        Dim cardHeight As Integer = 100
        Dim cardTop As Integer = 25

        For i As Integer = 0 To cardPanels.Length - 1
            Dim row As Integer = i \ cardColumns
            Dim col As Integer = i Mod cardColumns
            cardPanels(i).SetBounds(
                margin + col * (cardWidth + gap),
                cardTop + row * (cardHeight + gap),
                cardWidth,
                cardHeight)
        Next

        Dim reviewCardWidth As Integer = Math.Min(330, usableWidth)
        Dim reviewCardHeight As Integer = 150
        Dim reviewCardTop As Integer = cardTop + 2 * (cardHeight + gap)
        pnlPendingAccountabilityReview.SetBounds(margin, reviewCardTop, reviewCardWidth, reviewCardHeight)
        For Each child As Control In pnlPendingAccountabilityReview.Controls
            If child.Name = "lblPendingAccountabilityTitle" Then
                child.SetBounds(15, 14, Math.Max(250, reviewCardWidth - 30), 24)
            ElseIf child.Name = "lblPendingAccountabilityCount" Then
                child.SetBounds(15, 43, 100, 42)
            ElseIf child.Name = "lblPendingAccountabilityHint" Then
                child.SetBounds(15, 112, Math.Max(200, reviewCardWidth - 30), 24)
            End If
        Next

        ' Chart cards flow into responsive columns, matching the modern dashboard reference.
        Dim chartCards As Panel() = {
            chartCardClassification, chartCardAccountability, chartCardCondition
        }

        Dim chartColumns As Integer
        If usableWidth >= 1100 Then
            chartColumns = 3
        ElseIf usableWidth >= 650 Then
            chartColumns = 2
        Else
            chartColumns = 1
        End If

        Dim chartWidth As Integer = Math.Max(260,
            (usableWidth - (gap * (chartColumns - 1))) \ chartColumns)
        Dim chartHeight As Integer = 320
        Dim chartTop As Integer = reviewCardTop + reviewCardHeight + gap + 10

        For i As Integer = 0 To chartCards.Length - 1
            Dim row As Integer = i \ chartColumns
            Dim col As Integer = i Mod chartColumns
            chartCards(i).SetBounds(
                margin + col * (chartWidth + gap),
                chartTop + row * (chartHeight + gap),
                chartWidth,
                chartHeight)

            Dim chartControl As Control = chartCards(i).Controls.OfType(Of DataVisualization.Charting.Chart)().FirstOrDefault()
            If chartControl IsNot Nothing Then
                chartControl.SetBounds(6, 36, Math.Max(220, chartCards(i).ClientSize.Width - 12), Math.Max(240, chartCards(i).ClientSize.Height - 42))
            End If
        Next

        Dim chartRows As Integer = CInt(Math.Ceiling(chartCards.Length / CDbl(chartColumns)))
        Dim locationTop As Integer = chartTop + chartRows * (chartHeight + gap) + 10
        pnlLocationSummary.SetBounds(margin, locationTop, usableWidth, 300)

        ' Keep the location chart and grid within their parent panel.
        Dim innerWidth As Integer = Math.Max(200, pnlLocationSummary.ClientSize.Width - 30)
        Dim innerHeight As Integer = Math.Max(180, pnlLocationSummary.ClientSize.Height - 45)
        Dim locationChartWidth As Integer = CInt(innerWidth * 0.4)
        chartLocation.SetBounds(15, 35, locationChartWidth, innerHeight)
        dgvLocationSummary.SetBounds(
            locationChartWidth + 25, 35,
            Math.Max(150, innerWidth - locationChartWidth - 10),
            innerHeight)
    End Sub
    Private Sub InitializeDashboardChartCards()
        If chartCardClassification IsNot Nothing Then Return

        chartCardClassification = CreateChartCard("Inventory by Classification", chartClassification)
        chartCardAccountability = CreateChartCard("Accountability Status", chartAccountability)
        chartCardCondition = CreateChartCard("Condition Status", chartCondition)

        ' Doughnut charts are easier to scan and match the approved reference layout.
        chartClassification.Series("ClassificationSeries").ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
        chartAccountability.Series("AccountabilitySeries").ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
        For Each chart As DataVisualization.Charting.Chart In New DataVisualization.Charting.Chart() {chartClassification, chartAccountability, chartCondition}
            chart.BorderlineColor = System.Drawing.Color.Transparent
            chart.BorderlineDashStyle = DataVisualization.Charting.ChartDashStyle.NotSet
            chart.BackColor = System.Drawing.Color.White
            chart.ChartAreas(0).BackColor = System.Drawing.Color.White
            chart.Legends(0).BackColor = System.Drawing.Color.White
            ' Use the available card area more efficiently without changing card dimensions.
            chart.Legends(0).Docking = DataVisualization.Charting.Docking.Bottom
            chart.Legends(0).Alignment = System.Drawing.StringAlignment.Center
            chart.Legends(0).IsDockedInsideChartArea = False
            chart.ChartAreas(0).Position.Auto = False
            chart.ChartAreas(0).Position = New DataVisualization.Charting.ElementPosition(0, 0, 100, 86)
            chart.ChartAreas(0).InnerPlotPosition.Auto = False
            chart.ChartAreas(0).InnerPlotPosition = New DataVisualization.Charting.ElementPosition(5, 4, 90, 91)
        Next
        chartClassification.Titles.Clear()
        chartAccountability.Titles.Clear()
        chartCondition.Titles.Clear()
    End Sub

    Private Function CreateChartCard(cardTitle As String, chart As DataVisualization.Charting.Chart) As Panel
        Dim card As New Panel With {
            .Name = "pnlChartCard" & cardTitle.Replace(" ", "").Replace("/", ""),
            .BackColor = System.Drawing.Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        Dim titleLabel As New Label With {
            .Text = cardTitle,
            .AutoSize = False,
            .Location = New Point(16, 10),
            .Size = New System.Drawing.Size(500, 26),
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = System.Drawing.Color.FromArgb(31, 41, 55),
            .BackColor = System.Drawing.Color.White
        }
        pnlMain.Controls.Remove(chart)
        card.Controls.Add(titleLabel)
        card.Controls.Add(chart)
        pnlMain.Controls.Add(card)
        card.BringToFront()
        Return card
    End Function

    Private Sub InitializeStockInventoryNavigation()
        If btnStockInventory IsNot Nothing Then Return

        btnInventory.Text = "Property & Equipment"
        btnInventory.Location = New Point(8, 130)
        btnInventory.Size = New System.Drawing.Size(Math.Max(120, pnlSidebar.ClientSize.Width - 16), 40)
        btnInventory.Padding = New Padding(12, 0, 0, 0)

        btnStockInventory = New Button With {
            .Name = "btnStockInventory",
            .Text = "Inventory",
            .Location = New Point(8, 180),
            .Size = New System.Drawing.Size(Math.Max(120, pnlSidebar.ClientSize.Width - 16), 40),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = System.Drawing.Color.Transparent,
            .ForeColor = System.Drawing.Color.White,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(12, 0, 0, 0),
            .Cursor = Cursors.Hand,
            .UseVisualStyleBackColor = False
        }
        btnStockInventory.FlatAppearance.BorderSize = 0
        pnlSidebar.Controls.Add(btnStockInventory)
        AddHandler btnStockInventory.Click, AddressOf btnStockInventory_Click

        btnReports.Location = New Point(8, 230)
        btnQRScan.Location = New Point(8, 280)
        btnSettings.Location = New Point(8, 330)
        For Each navButton As Button In New Button() {btnDashboard, btnInventory, btnStockInventory, btnReports, btnQRScan, btnSettings}
            navButton.Width = Math.Max(120, pnlSidebar.ClientSize.Width - 16)
        Next
        pnlSidebar.Controls.SetChildIndex(btnDashboard, 0)
        pnlSidebar.Controls.SetChildIndex(btnInventory, 1)
        pnlSidebar.Controls.SetChildIndex(btnStockInventory, 2)
        pnlSidebar.Controls.SetChildIndex(btnReports, 3)
        pnlSidebar.Controls.SetChildIndex(btnQRScan, 4)
        pnlSidebar.Controls.SetChildIndex(btnSettings, 5)
    End Sub

    Private Sub btnStockInventory_Click(sender As Object, e As EventArgs)
        ShowPlaceholderPage("Inventory", "The separate stock and inventory management module is planned for a future update.")
        SetActiveNavigation(btnStockInventory)
    End Sub

    Private Sub lstRecentActivity_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    ' All navigation pages are hosted inside pnlMain so the sidebar and header remain visible.
    Private pageHost As Panel
    Private currentChildForm As Form
    Private propertyEquipmentForm As frmInventory
    Private qrPhysicalInventoryForm As frmQRScan

    Private Sub InitializePageHost()
        If pageHost IsNot Nothing Then Return

        pageHost = New Panel With {
            .Name = "pnlPageHost",
            .Dock = DockStyle.Fill,
            .Visible = False,
            .BackColor = System.Drawing.Color.White
        }

        pnlMain.Controls.Add(pageHost)
        pageHost.BringToFront()
    End Sub

    Private Sub ShowDashboardPage()
        If pageHost Is Nothing Then Return
        If currentChildForm IsNot Nothing Then
            ' Stop camera resources before hiding the cached QR page. Hiding a form
            ' does not raise FormClosing, so relying on FormClosing leaks camera use.
            If TypeOf currentChildForm Is frmQRScan Then
                DirectCast(currentChildForm, frmQRScan).OnPageHidden()
            End If
            currentChildForm.Hide()
            currentChildForm = Nothing
        End If

        pageHost.Controls.Clear()
        pageHost.Visible = False
        ' Restore dashboard controls behind the page host.
        For Each ctl As Control In pnlMain.Controls
            If ctl IsNot pageHost Then ctl.Visible = True
        Next
        ArrangeDashboardLayout()
        ' Refresh the accountability cards/chart whenever the user returns to Dashboard.
        ' This prevents stale counts after marking items accounted for or resetting a session.
        RefreshAccountabilitySummary()
        SetActiveNavigation(btnDashboard)
    End Sub

    Public Sub RefreshAccountabilitySummary()
        LoadAccountabilityChart()
        RefreshPendingAccountabilityReviewCount()
    End Sub

    Private Sub InitializeDashboardReviewCard()
        If pnlPendingAccountabilityReview IsNot Nothing Then Return

        pnlPendingAccountabilityReview = New Panel With {
            .Name = "pnlPendingAccountabilityReview",
            .BackColor = System.Drawing.Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .Cursor = Cursors.Hand,
            .TabStop = True
        }

        Dim titleLabel As New Label With {
            .Name = "lblPendingAccountabilityTitle",
            .Text = "Properties Awaiting Review",
            .Location = New Point(15, 12),
            .Size = New System.Drawing.Size(250, 24),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = System.Drawing.Color.FromArgb(55, 65, 81),
            .BackColor = System.Drawing.Color.Transparent,
            .Cursor = Cursors.Hand
        }

        lblPendingAccountabilityCount = New Label With {
            .Name = "lblPendingAccountabilityCount",
            .Text = "0",
            .Location = New Point(15, 36),
            .Size = New System.Drawing.Size(250, 38),
            .Font = New Font("Segoe UI", 22.0F, FontStyle.Bold),
            .ForeColor = System.Drawing.Color.FromArgb(180, 83, 9),
            .BackColor = System.Drawing.Color.Transparent,
            .Cursor = Cursors.Hand
        }

        Dim hintLabel As New Label With {
            .Name = "lblPendingAccountabilityHint",
            .Text = "Click to review changes",
            .Location = New Point(15, 112),
            .Size = New System.Drawing.Size(250, 24),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Regular),
            .ForeColor = System.Drawing.Color.FromArgb(107, 114, 128),
            .BackColor = System.Drawing.Color.Transparent,
            .Cursor = Cursors.Hand
        }

        pnlPendingAccountabilityReview.Controls.Add(titleLabel)
        pnlPendingAccountabilityReview.Controls.Add(lblPendingAccountabilityCount)
        pnlPendingAccountabilityReview.Controls.Add(hintLabel)
        pnlMain.Controls.Add(pnlPendingAccountabilityReview)
        AddHandler pnlPendingAccountabilityReview.Click, AddressOf OpenAccountabilityReview
        AddHandler titleLabel.Click, AddressOf OpenAccountabilityReview
        AddHandler lblPendingAccountabilityCount.Click, AddressOf OpenAccountabilityReview
        AddHandler hintLabel.Click, AddressOf OpenAccountabilityReview
    End Sub

    Private Sub RefreshPendingAccountabilityReviewCount()
        If lblPendingAccountabilityCount Is Nothing OrElse lblPendingAccountabilityCount.IsDisposed Then Return

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()
                Using cmd As New SQLiteCommand(
                    "SELECT COUNT(DISTINCT InventoryID) FROM AccountabilityHistory " &
                    "WHERE ReviewStatus = 'Pending Review'", conn)
                    lblPendingAccountabilityCount.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
                End Using
            End Using
        Catch ex As Exception
            lblPendingAccountabilityCount.Text = "—"
        End Try
    End Sub

    Private Sub OpenAccountabilityReview(sender As Object, e As EventArgs)
        If accountabilityReviewForm Is Nothing OrElse accountabilityReviewForm.IsDisposed Then
            accountabilityReviewForm = New frmAccountabilityReview()
        End If
        ShowChildPage(accountabilityReviewForm, "Accountability Review")
    End Sub

    Private Sub ShowChildPage(child As Form, pageTitle As String)
        InitializePageHost()

        If currentChildForm IsNot Nothing Then
            ' Stop camera resources before hiding the cached QR page. Hiding a form
            ' does not raise FormClosing, so relying on FormClosing leaks camera use.
            If TypeOf currentChildForm Is frmQRScan Then
                DirectCast(currentChildForm, frmQRScan).OnPageHidden()
            End If
            currentChildForm.Hide()
            currentChildForm = Nothing
        End If

        pageHost.Controls.Clear()
        pageHost.Visible = True
        pageHost.BringToFront()

        ' Hide the dashboard controls while another page is active.
        For Each ctl As Control In pnlMain.Controls
            If ctl IsNot pageHost Then ctl.Visible = False
        Next

        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill
        child.ShowInTaskbar = False
        currentChildForm = child
        pageHost.Controls.Add(child)
        child.Show()
        child.BringToFront()
        lblTitle.Text = pageTitle
    End Sub

    Private Sub ShowPlaceholderPage(pageTitle As String, message As String)
        InitializePageHost()

        If currentChildForm IsNot Nothing Then
            If TypeOf currentChildForm Is frmQRScan Then
                DirectCast(currentChildForm, frmQRScan).OnPageHidden()
            End If
            currentChildForm.Hide()
            currentChildForm = Nothing
        End If

        pageHost.Controls.Clear()
        pageHost.Visible = True
        pageHost.BringToFront()

        For Each ctl As Control In pnlMain.Controls
            If ctl IsNot pageHost Then ctl.Visible = False
        Next

        Dim messageLabel As New Label With {
            .Text = message,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 16.0F, FontStyle.Regular),
            .ForeColor = System.Drawing.Color.FromArgb(70, 70, 70)
        }
        pageHost.Controls.Add(messageLabel)
        lblTitle.Text = pageTitle
    End Sub

    Private Sub SetActiveNavigation(activeButton As Button)
        For Each navButton As Button In New Button() {
            btnDashboard, btnInventory, btnStockInventory, btnReports, btnQRScan, btnSettings
        }
            navButton.BackColor = If(navButton Is activeButton,
                         System.Drawing.Color.FromArgb(255, 35, 75, 130),
                         System.Drawing.Color.Transparent)
        Next
        If activeButton Is btnDashboard Then
            lblTitle.Text = "Dashboard"
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowDashboardPage()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        If propertyEquipmentForm Is Nothing OrElse propertyEquipmentForm.IsDisposed Then
            propertyEquipmentForm = New frmInventory()
        End If

        ShowChildPage(propertyEquipmentForm, "Property & Equipment")
        SetActiveNavigation(btnInventory)
    End Sub

    Private Sub btnQRScan_Click(sender As Object, e As EventArgs) Handles btnQRScan.Click
        If qrPhysicalInventoryForm Is Nothing OrElse qrPhysicalInventoryForm.IsDisposed Then
            qrPhysicalInventoryForm = New frmQRScan()
        End If

        ShowChildPage(qrPhysicalInventoryForm, "QR / Physical Inventory")
        SetActiveNavigation(btnQRScan)
    End Sub

    'Navigate from QR/manual lookup to the existing hosted Property & Equipment page.
    Public Sub OpenPropertyFromQR(propertyNo As String)
        If propertyEquipmentForm Is Nothing OrElse propertyEquipmentForm.IsDisposed Then
            propertyEquipmentForm = New frmInventory()
        End If

        ShowChildPage(propertyEquipmentForm, "Property & Equipment")
        SetActiveNavigation(btnInventory)
        propertyEquipmentForm.OpenPropertyRecord(propertyNo)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        ShowPlaceholderPage("Reports", "Reports page is not implemented yet.")
        SetActiveNavigation(btnReports)
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowPlaceholderPage("Settings", "Settings page is not implemented yet.")
        SetActiveNavigation(btnSettings)
    End Sub
    Private Sub LoadClassificationChart()

        chartClassification.Series("ClassificationSeries").Points.Clear()

        chartClassification.Legends(0).Enabled = False

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT Category, COUNT(*) AS Total " &
                "FROM InventoryDB " &
                "WHERE Category IS NOT NULL AND TRIM(Category) <> '' " &
                "GROUP BY Category"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim category As String = reader("Category").ToString()
                        Dim total As Integer = Convert.ToInt32(reader("Total"))

                        Dim pointIndex As Integer = chartClassification.Series("ClassificationSeries").Points.AddXY(category, total)
                        Dim point As DataVisualization.Charting.DataPoint = chartClassification.Series("ClassificationSeries").Points(pointIndex)
                        If category.Trim().Equals("PPE", StringComparison.OrdinalIgnoreCase) Then
                            point.Color = System.Drawing.Color.FromArgb(99, 102, 241)
                        Else
                            point.Color = System.Drawing.Color.FromArgb(245, 158, 11)
                        End If

                    End While

                End Using

            End Using

        End Using

    End Sub
    Private Sub LoadAccountabilityChart()
        chartAccountability.Series("AccountabilitySeries").Points.Clear()

        chartAccountability.Legends(0).Enabled = False

        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Dim sql As String = "SELECT (SELECT COUNT(DISTINCT PropertyNo) FROM PhysicalInventoryScanDB WHERE Status = 'Accounted') AS AccountedCount, (SELECT COUNT(*) FROM InventoryDB) AS TotalCount"
            Using cmd As New SQLiteCommand(sql, conn)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim accounted As Integer = Convert.ToInt32(reader("AccountedCount"))
                        Dim total As Integer = Convert.ToInt32(reader("TotalCount"))
                        Dim unaccounted As Integer = Math.Max(0, total - accounted)

                        ' Update the dashboard summary cards
                        lblAccountedCount.Text = accounted.ToString()
                        lblUnaccountedCount.Text = unaccounted.ToString()

                        chartAccountability.Series("AccountabilitySeries").Points.AddXY("Accounted", Math.Min(accounted, total))
                        chartAccountability.Series("AccountabilitySeries").Points.AddXY("Unaccounted", unaccounted)
                    End If
                End Using
            End Using
        End Using
        If chartAccountability.Series("AccountabilitySeries").Points.Count = 0 Then Return
        For Each point As DataVisualization.Charting.DataPoint In chartAccountability.Series("AccountabilitySeries").Points
            If point.AxisLabel = "Accounted" Then
                point.Color = System.Drawing.Color.FromArgb(16, 185, 129)
            Else
                point.Color = System.Drawing.Color.FromArgb(239, 68, 68)
            End If
        Next
    End Sub

    Private Sub LoadTotalInventoryCount()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT COUNT(*) FROM InventoryDB"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                lblTotalInventoryCount.Text = total.ToString()

            End Using

        End Using

    End Sub
    Private Sub LoadPPECount()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT COUNT(*) FROM InventoryDB " &
                "WHERE Category = 'PPE'"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                lblPPECount.Text = total.ToString()

            End Using

        End Using

    End Sub
    Private Sub LoadSemiCount()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT COUNT(*) FROM InventoryDB " &
                "WHERE Category = 'Semi-Expendable'"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                lblSemiCount.Text = total.ToString()

            End Using

        End Using

    End Sub
    Private Sub LoadTotalInventoryValue()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT SUM(UnitCost * Quantity) FROM InventoryDB"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim result = cmd.ExecuteScalar()

                Dim totalValue As Decimal = 0D

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    totalValue = Convert.ToDecimal(result)
                End If

                lblTotalInventoryValue.Text =
                    "₱" & totalValue.ToString("#,##0.00")

            End Using

        End Using

    End Sub
    Private Sub LoadRepairCount()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT COUNT(*) FROM InventoryDB " &
                "WHERE Condition = 'Repairable'"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                lblRepairCount.Text = total.ToString()

            End Using

        End Using

    End Sub
    Private Sub LoadUnserviceableCount()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT COUNT(*) FROM InventoryDB " &
                "WHERE Condition = 'Unserviceable'"

            Using cmd As New SQLiteCommand(sql, conn)

                Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                lblUnservCount.Text = total.ToString()

            End Using

        End Using

    End Sub
    Private Sub LoadConditionChart()

        Dim series As DataVisualization.Charting.Series =
        chartCondition.Series("ConditionSeries")

        series.Points.Clear()
        series.IsXValueIndexed = True
        series.XValueType = DataVisualization.Charting.ChartValueType.String
        series.YValueType = DataVisualization.Charting.ChartValueType.Int32

        ' Condition names are displayed on the X-axis.
        ' The legend is unnecessary for a single-series chart.
        chartCondition.Legends(0).Enabled = False

        chartCondition.ChartAreas(0).AxisX.Interval = 1
        chartCondition.ChartAreas(0).AxisX.LabelStyle.Angle = 0
        chartCondition.ChartAreas(0).AxisX.LabelStyle.Font =
        New System.Drawing.Font("Segoe UI", 8.0F)

        chartCondition.ChartAreas(0).AxisY.Title = "Number of Items"
        chartCondition.ChartAreas(0).AxisY.Minimum = 0
        chartCondition.ChartAreas(0).AxisY.LabelStyle.Format = "0"

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT Condition, COUNT(*) AS Total " &
            "FROM InventoryDB " &
            "WHERE Condition IS NOT NULL AND TRIM(Condition) <> '' " &
            "GROUP BY Condition " &
            "ORDER BY CASE LOWER(TRIM(Condition)) " &
            "WHEN 'serviceable' THEN 1 " &
            "WHEN 'good' THEN 1 " &
            "WHEN 'repairable' THEN 2 " &
            "WHEN 'for repair' THEN 2 " &
            "WHEN 'unserviceable' THEN 3 " &
            "WHEN 'for disposal' THEN 4 " &
            "ELSE 5 END"

            Using cmd As New SQLiteCommand(sql, conn)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim condition As String =
                        reader("Condition").ToString().Trim()

                        Dim total As Integer =
                        Convert.ToInt32(reader("Total"))

                        Dim pointIndex As Integer =
                        series.Points.AddXY(condition, total)

                        Dim point As DataVisualization.Charting.DataPoint =
                        series.Points(pointIndex)

                        Select Case condition.ToLowerInvariant()

                            Case "serviceable", "good"
                                point.Color =
                                System.Drawing.Color.FromArgb(16, 185, 129)

                            Case "repairable", "for repair"
                                point.Color =
                                System.Drawing.Color.FromArgb(245, 158, 11)

                            Case "unserviceable", "for disposal"
                                point.Color =
                                System.Drawing.Color.FromArgb(239, 68, 68)

                            Case Else
                                point.Color =
                                System.Drawing.Color.FromArgb(99, 102, 241)

                        End Select

                    End While

                End Using
            End Using

        End Using

    End Sub

    Private Sub LoadLocationChart()

        chartLocation.Series("LocationSeries").Points.Clear()

        chartLocation.Legends(0).Enabled = False

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT Location, COUNT(*) AS Total " &
                "FROM InventoryDB " &
                "WHERE Location IS NOT NULL AND TRIM(Location) <> '' " &
                "GROUP BY Location " &
                "ORDER BY Total DESC " &
                "LIMIT 5"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim location As String = reader("Location").ToString()
                        Dim total As Integer = Convert.ToInt32(reader("Total"))

                        chartLocation.Series("LocationSeries").
                            Points.AddXY(location, total)

                    End While

                End Using

            End Using

        End Using

    End Sub
    Private Sub LoadLocationSummary()

        dgvLocationSummary.Rows.Clear()

        colTotalValue.DefaultCellStyle.Format = "#,##0.00"
        colTotalValue.DefaultCellStyle.Alignment =
        DataGridViewContentAlignment.MiddleRight

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT Location, " &
                "COUNT(*) AS TotalItems, " &
                "SUM(CASE WHEN Category = 'PPE' THEN 1 ELSE 0 END) AS PPE, " &
                "SUM(CASE WHEN Category = 'Semi-Expendable' THEN 1 ELSE 0 END) AS SEMI, " &
                "SUM(UnitCost * Quantity) AS TotalValue " &
                "FROM InventoryDB " &
                "WHERE Location IS NOT NULL AND TRIM(Location) <> '' " &
                "GROUP BY Location " &
                "ORDER BY TotalItems DESC " &
                "LIMIT 5"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    Dim rank As Integer = 1

                    While reader.Read()

                        dgvLocationSummary.Rows.Add(
                            rank,
                            reader("Location").ToString(),
                            Convert.ToInt32(reader("TotalItems")),
                            Convert.ToInt32(reader("PPE")),
                            Convert.ToInt32(reader("SEMI")),
                            Convert.ToDecimal(reader("TotalValue"))
                        )

                        rank += 1

                    End While

                End Using

            End Using

        End Using

    End Sub

End Class