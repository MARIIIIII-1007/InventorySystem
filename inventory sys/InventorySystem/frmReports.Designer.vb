<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        tlpReportsMain = New TableLayoutPanel()
        pnlReportCategories = New Panel()
        flpReportOptions = New FlowLayoutPanel()
        btnInventoryReports = New Button()
        btnAccountabilityReports = New Button()
        btnPropertyReports = New Button()
        btnStatusReports = New Button()
        pnlReportWorkspace = New Panel()
        tlpReportWorkspace = New TableLayoutPanel()
        tlpReportsMain.SuspendLayout()
        pnlReportCategories.SuspendLayout()
        flpReportOptions.SuspendLayout()
        pnlReportWorkspace.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpReportsMain
        ' 
        tlpReportsMain.ColumnCount = 2
        tlpReportsMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 300F))
        tlpReportsMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpReportsMain.Controls.Add(pnlReportCategories, 0, 0)
        tlpReportsMain.Controls.Add(pnlReportWorkspace, 1, 0)
        tlpReportsMain.Dock = DockStyle.Fill
        tlpReportsMain.Location = New Point(0, 0)
        tlpReportsMain.Margin = New Padding(0)
        tlpReportsMain.Name = "tlpReportsMain"
        tlpReportsMain.Padding = New Padding(10)
        tlpReportsMain.RowCount = 1
        tlpReportsMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpReportsMain.Size = New Size(1328, 794)
        tlpReportsMain.TabIndex = 0
        ' 
        ' pnlReportCategories
        ' 
        pnlReportCategories.AutoScroll = True
        pnlReportCategories.BorderStyle = BorderStyle.FixedSingle
        pnlReportCategories.Controls.Add(flpReportOptions)
        pnlReportCategories.Dock = DockStyle.Fill
        pnlReportCategories.Location = New Point(15, 15)
        pnlReportCategories.Margin = New Padding(5)
        pnlReportCategories.Name = "pnlReportCategories"
        pnlReportCategories.Padding = New Padding(5)
        pnlReportCategories.Size = New Size(290, 764)
        pnlReportCategories.TabIndex = 0
        ' 
        ' flpReportOptions
        ' 
        flpReportOptions.AutoScroll = True
        flpReportOptions.Controls.Add(btnInventoryReports)
        flpReportOptions.Controls.Add(btnAccountabilityReports)
        flpReportOptions.Controls.Add(btnPropertyReports)
        flpReportOptions.Controls.Add(btnStatusReports)
        flpReportOptions.Dock = DockStyle.Fill
        flpReportOptions.FlowDirection = FlowDirection.TopDown
        flpReportOptions.ForeColor = Color.DarkBlue
        flpReportOptions.Location = New Point(5, 5)
        flpReportOptions.Name = "flpReportOptions"
        flpReportOptions.Padding = New Padding(5)
        flpReportOptions.Size = New Size(278, 752)
        flpReportOptions.TabIndex = 0
        flpReportOptions.WrapContents = False
        ' 
        ' btnInventoryReports
        ' 
        btnInventoryReports.BackColor = Color.LightSteelBlue
        btnInventoryReports.FlatStyle = FlatStyle.Flat
        btnInventoryReports.Location = New Point(8, 8)
        btnInventoryReports.Name = "btnInventoryReports"
        btnInventoryReports.Size = New Size(250, 38)
        btnInventoryReports.TabIndex = 0
        btnInventoryReports.Text = "Inventory Reports"
        btnInventoryReports.TextAlign = ContentAlignment.MiddleLeft
        btnInventoryReports.UseVisualStyleBackColor = False
        ' 
        ' btnAccountabilityReports
        ' 
        btnAccountabilityReports.BackColor = Color.LightSteelBlue
        btnAccountabilityReports.FlatStyle = FlatStyle.Flat
        btnAccountabilityReports.Location = New Point(8, 52)
        btnAccountabilityReports.Name = "btnAccountabilityReports"
        btnAccountabilityReports.Size = New Size(250, 38)
        btnAccountabilityReports.TabIndex = 1
        btnAccountabilityReports.Text = "Accountability Reports"
        btnAccountabilityReports.TextAlign = ContentAlignment.MiddleLeft
        btnAccountabilityReports.UseVisualStyleBackColor = False
        ' 
        ' btnPropertyReports
        ' 
        btnPropertyReports.BackColor = Color.LightSteelBlue
        btnPropertyReports.FlatStyle = FlatStyle.Flat
        btnPropertyReports.Location = New Point(8, 96)
        btnPropertyReports.Name = "btnPropertyReports"
        btnPropertyReports.Size = New Size(250, 38)
        btnPropertyReports.TabIndex = 2
        btnPropertyReports.Text = "Property Reports"
        btnPropertyReports.TextAlign = ContentAlignment.MiddleLeft
        btnPropertyReports.UseVisualStyleBackColor = False
        ' 
        ' btnStatusReports
        ' 
        btnStatusReports.BackColor = Color.LightSteelBlue
        btnStatusReports.FlatStyle = FlatStyle.Flat
        btnStatusReports.Location = New Point(8, 140)
        btnStatusReports.Name = "btnStatusReports"
        btnStatusReports.Size = New Size(250, 38)
        btnStatusReports.TabIndex = 3
        btnStatusReports.Text = "Status Reports"
        btnStatusReports.TextAlign = ContentAlignment.MiddleLeft
        btnStatusReports.UseVisualStyleBackColor = False
        ' 
        ' pnlReportWorkspace
        ' 
        pnlReportWorkspace.AutoScroll = True
        pnlReportWorkspace.Controls.Add(tlpReportWorkspace)
        pnlReportWorkspace.Dock = DockStyle.Fill
        pnlReportWorkspace.Location = New Point(310, 10)
        pnlReportWorkspace.Margin = New Padding(0)
        pnlReportWorkspace.Name = "pnlReportWorkspace"
        pnlReportWorkspace.Padding = New Padding(10)
        pnlReportWorkspace.Size = New Size(1008, 774)
        pnlReportWorkspace.TabIndex = 1
        ' 
        ' tlpReportWorkspace
        ' 
        tlpReportWorkspace.ColumnCount = 1
        tlpReportWorkspace.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpReportWorkspace.Dock = DockStyle.Fill
        tlpReportWorkspace.Location = New Point(10, 10)
        tlpReportWorkspace.Name = "tlpReportWorkspace"
        tlpReportWorkspace.RowCount = 4
        tlpReportWorkspace.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        tlpReportWorkspace.RowStyles.Add(New RowStyle(SizeType.Absolute, 150F))
        tlpReportWorkspace.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpReportWorkspace.RowStyles.Add(New RowStyle(SizeType.Absolute, 55F))
        tlpReportWorkspace.Size = New Size(988, 754)
        tlpReportWorkspace.TabIndex = 0
        ' 
        ' frmReports
        ' 
        AutoScaleDimensions = New SizeF(144F, 144F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1328, 794)
        ControlBox = False
        Controls.Add(tlpReportsMain)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmReports"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        Text = "Reports"
        tlpReportsMain.ResumeLayout(False)
        pnlReportCategories.ResumeLayout(False)
        flpReportOptions.ResumeLayout(False)
        pnlReportWorkspace.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents tlpReportsMain As TableLayoutPanel
    Friend WithEvents pnlReportCategories As Panel
    Friend WithEvents flpReportOptions As FlowLayoutPanel
    Friend WithEvents btnInventoryReports As Button
    Friend WithEvents btnAccountabilityReports As Button
    Friend WithEvents btnPropertyReports As Button
    Friend WithEvents btnStatusReports As Button
    Friend WithEvents pnlReportWorkspace As Panel
    Friend WithEvents tlpReportWorkspace As TableLayoutPanel
End Class
