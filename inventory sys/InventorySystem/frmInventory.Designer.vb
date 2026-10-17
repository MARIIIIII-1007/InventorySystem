<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlInventoryHeader = New Panel()
        lblTitle = New Label()
        btnDelete = New Button()
        btnAddItem = New Button()
        txtSearch = New TextBox()
        cboFilterClassification = New ComboBox()
        lblFilterClassification = New Label()
        cboFilterEndUser = New ComboBox()
        lblFilterLocation = New Label()
        cboFilterLocation = New ComboBox()
        lblFilterCondition = New Label()
        cboFilterCondition = New ComboBox()
        pnlItemDetails = New Panel()
        txtDetailRemarks = New TextBox()
        lblDetailRemarks = New Label()
        txtDetailPARICS = New TextBox()
        lblDetailPARICS = New Label()
        txtDetailCondition = New TextBox()
        lblDetailCondition = New Label()
        txtDetailLocation = New TextBox()
        lblDetailLocation = New Label()
        txtDetailEndUser = New TextBox()
        lblDetailEndUser = New Label()
        txtDetailUsefulLife = New TextBox()
        lblDetailUsefulLife = New Label()
        txtDetailUnitCost = New TextBox()
        lblDetailUnitCost = New Label()
        txtDetailQuantity = New TextBox()
        lblDetailQuantity = New Label()
        txtDetailSourceDocument = New TextBox()
        lblDetailSourceDocument = New Label()
        txtDetailFundSource = New TextBox()
        lblDetailFundSource = New Label()
        txtDetailProcurement = New TextBox()
        lblDetailProcurement = New Label()
        txtDetailDateAcquired = New TextBox()
        lblDetailDateAcquired = New Label()
        txtDetailDescription = New TextBox()
        lblDetailDescription = New Label()
        txtDetailArticle = New TextBox()
        lblDetailArticle = New Label()
        txtDetailAccountCode = New TextBox()
        lblDetailAccountCode = New Label()
        txtDetailClassification = New TextBox()
        lblDetailClassification = New Label()
        txtDetailPropertyNo = New TextBox()
        lblDetailPropertyNo = New Label()
        lblItemDetails = New Label()
        pnlItemMedia = New Panel()
        btnViewPhoto = New Button()
        btnViewQR = New Button()
        picItemQR = New PictureBox()
        picItemPhoto = New PictureBox()
        lblItemMedia = New Label()
        pnlSidebar = New Panel()
        btnSidebarSettings = New Button()
        btnSidebarQRScan = New Button()
        btnSidebarReports = New Button()
        btnSidebarInventory = New Button()
        btnDashboard = New Button()
        pnlMainContent = New Panel()
        lblTotalAmount = New Label()
        lblTotalItems = New Label()
        lblSearch = New Label()
        btnGeneratePARICS = New Button()
        btnPrintSticker = New Button()
        btnRefresh = New Button()
        btnEdit = New Button()
        dgvInventory = New DataGridView()
        chkSelect = New DataGridViewCheckBoxColumn()
        lblFilterEndUser = New Label()
        pnlInventoryHeader.SuspendLayout()
        pnlItemDetails.SuspendLayout()
        pnlItemMedia.SuspendLayout()
        CType(picItemQR, ComponentModel.ISupportInitialize).BeginInit()
        CType(picItemPhoto, ComponentModel.ISupportInitialize).BeginInit()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        CType(dgvInventory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlInventoryHeader
        ' 
        pnlInventoryHeader.BackColor = Color.White
        pnlInventoryHeader.Controls.Add(lblTitle)
        pnlInventoryHeader.Dock = DockStyle.Top
        pnlInventoryHeader.Location = New Point(170, 0)
        pnlInventoryHeader.Name = "pnlInventoryHeader"
        pnlInventoryHeader.Size = New Size(1726, 70)
        pnlInventoryHeader.TabIndex = 0
        pnlInventoryHeader.Visible = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.DimGray
        lblTitle.Location = New Point(20, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(372, 45)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Inventory Management"
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.IndianRed
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(480, 125)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(200, 45)
        btnDelete.TabIndex = 5
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnAddItem
        ' 
        btnAddItem.BackColor = Color.Green
        btnAddItem.Cursor = Cursors.Hand
        btnAddItem.FlatAppearance.BorderSize = 0
        btnAddItem.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddItem.ForeColor = Color.White
        btnAddItem.Location = New Point(20, 125)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(200, 45)
        btnAddItem.TabIndex = 1
        btnAddItem.Text = "+ Add Item"
        btnAddItem.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.Gray
        txtSearch.Location = New Point(150, 20)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(300, 34)
        txtSearch.TabIndex = 3
        txtSearch.Text = "Search Item . . ."
        ' 
        ' cboFilterClassification
        ' 
        cboFilterClassification.FormattingEnabled = True
        cboFilterClassification.Location = New Point(700, 20)
        cboFilterClassification.Name = "cboFilterClassification"
        cboFilterClassification.Size = New Size(300, 33)
        cboFilterClassification.TabIndex = 6
        ' 
        ' lblFilterClassification
        ' 
        lblFilterClassification.AutoSize = True
        lblFilterClassification.Location = New Point(550, 25)
        lblFilterClassification.Name = "lblFilterClassification"
        lblFilterClassification.Size = New Size(114, 25)
        lblFilterClassification.TabIndex = 7
        lblFilterClassification.Text = "Classification"
        ' 
        ' cboFilterEndUser
        ' 
        cboFilterEndUser.FormattingEnabled = True
        cboFilterEndUser.Location = New Point(1200, 20)
        cboFilterEndUser.Name = "cboFilterEndUser"
        cboFilterEndUser.Size = New Size(300, 33)
        cboFilterEndUser.TabIndex = 9
        ' 
        ' lblFilterLocation
        ' 
        lblFilterLocation.AutoSize = True
        lblFilterLocation.Location = New Point(20, 80)
        lblFilterLocation.Name = "lblFilterLocation"
        lblFilterLocation.Size = New Size(79, 25)
        lblFilterLocation.TabIndex = 10
        lblFilterLocation.Text = "Location"
        ' 
        ' cboFilterLocation
        ' 
        cboFilterLocation.FormattingEnabled = True
        cboFilterLocation.Location = New Point(150, 75)
        cboFilterLocation.Name = "cboFilterLocation"
        cboFilterLocation.Size = New Size(300, 33)
        cboFilterLocation.TabIndex = 11
        ' 
        ' lblFilterCondition
        ' 
        lblFilterCondition.AutoSize = True
        lblFilterCondition.Location = New Point(550, 80)
        lblFilterCondition.Name = "lblFilterCondition"
        lblFilterCondition.Size = New Size(90, 25)
        lblFilterCondition.TabIndex = 12
        lblFilterCondition.Text = "Condition"
        ' 
        ' cboFilterCondition
        ' 
        cboFilterCondition.FormattingEnabled = True
        cboFilterCondition.Location = New Point(700, 75)
        cboFilterCondition.Name = "cboFilterCondition"
        cboFilterCondition.Size = New Size(300, 33)
        cboFilterCondition.TabIndex = 13
        ' 
        ' pnlItemDetails
        ' 
        pnlItemDetails.BackColor = Color.White
        pnlItemDetails.BorderStyle = BorderStyle.FixedSingle
        pnlItemDetails.Controls.Add(txtDetailRemarks)
        pnlItemDetails.Controls.Add(lblDetailRemarks)
        pnlItemDetails.Controls.Add(txtDetailPARICS)
        pnlItemDetails.Controls.Add(lblDetailPARICS)
        pnlItemDetails.Controls.Add(txtDetailCondition)
        pnlItemDetails.Controls.Add(lblDetailCondition)
        pnlItemDetails.Controls.Add(txtDetailLocation)
        pnlItemDetails.Controls.Add(lblDetailLocation)
        pnlItemDetails.Controls.Add(txtDetailEndUser)
        pnlItemDetails.Controls.Add(lblDetailEndUser)
        pnlItemDetails.Controls.Add(txtDetailUsefulLife)
        pnlItemDetails.Controls.Add(lblDetailUsefulLife)
        pnlItemDetails.Controls.Add(txtDetailUnitCost)
        pnlItemDetails.Controls.Add(lblDetailUnitCost)
        pnlItemDetails.Controls.Add(txtDetailQuantity)
        pnlItemDetails.Controls.Add(lblDetailQuantity)
        pnlItemDetails.Controls.Add(txtDetailSourceDocument)
        pnlItemDetails.Controls.Add(lblDetailSourceDocument)
        pnlItemDetails.Controls.Add(txtDetailFundSource)
        pnlItemDetails.Controls.Add(lblDetailFundSource)
        pnlItemDetails.Controls.Add(txtDetailProcurement)
        pnlItemDetails.Controls.Add(lblDetailProcurement)
        pnlItemDetails.Controls.Add(txtDetailDateAcquired)
        pnlItemDetails.Controls.Add(lblDetailDateAcquired)
        pnlItemDetails.Controls.Add(txtDetailDescription)
        pnlItemDetails.Controls.Add(lblDetailDescription)
        pnlItemDetails.Controls.Add(txtDetailArticle)
        pnlItemDetails.Controls.Add(lblDetailArticle)
        pnlItemDetails.Controls.Add(txtDetailAccountCode)
        pnlItemDetails.Controls.Add(lblDetailAccountCode)
        pnlItemDetails.Controls.Add(txtDetailClassification)
        pnlItemDetails.Controls.Add(lblDetailClassification)
        pnlItemDetails.Controls.Add(txtDetailPropertyNo)
        pnlItemDetails.Controls.Add(lblDetailPropertyNo)
        pnlItemDetails.Controls.Add(lblItemDetails)
        pnlItemDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        pnlItemDetails.Location = New Point(20, 610)
        pnlItemDetails.Name = "pnlItemDetails"
        pnlItemDetails.Size = New Size(1160, 350)
        pnlItemDetails.TabIndex = 14
        ' 
        ' txtDetailRemarks
        ' 
        txtDetailRemarks.Location = New Point(910, 240)
        txtDetailRemarks.Multiline = True
        txtDetailRemarks.Name = "txtDetailRemarks"
        txtDetailRemarks.ReadOnly = True
        txtDetailRemarks.Size = New Size(210, 80)
        txtDetailRemarks.TabIndex = 48
        ' 
        ' lblDetailRemarks
        ' 
        lblDetailRemarks.AutoSize = True
        lblDetailRemarks.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailRemarks.Location = New Point(780, 245)
        lblDetailRemarks.Name = "lblDetailRemarks"
        lblDetailRemarks.Size = New Size(90, 25)
        lblDetailRemarks.TabIndex = 47
        lblDetailRemarks.Text = "Remarks:"
        ' 
        ' txtDetailPARICS
        ' 
        txtDetailPARICS.Location = New Point(910, 190)
        txtDetailPARICS.Name = "txtDetailPARICS"
        txtDetailPARICS.ReadOnly = True
        txtDetailPARICS.Size = New Size(210, 31)
        txtDetailPARICS.TabIndex = 46
        ' 
        ' lblDetailPARICS
        ' 
        lblDetailPARICS.AutoSize = True
        lblDetailPARICS.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailPARICS.Location = New Point(780, 195)
        lblDetailPARICS.Name = "lblDetailPARICS"
        lblDetailPARICS.Size = New Size(87, 25)
        lblDetailPARICS.TabIndex = 45
        lblDetailPARICS.Text = "PAR/ICS:"
        ' 
        ' txtDetailCondition
        ' 
        txtDetailCondition.Location = New Point(910, 140)
        txtDetailCondition.Name = "txtDetailCondition"
        txtDetailCondition.ReadOnly = True
        txtDetailCondition.Size = New Size(210, 31)
        txtDetailCondition.TabIndex = 44
        ' 
        ' lblDetailCondition
        ' 
        lblDetailCondition.AutoSize = True
        lblDetailCondition.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailCondition.Location = New Point(780, 145)
        lblDetailCondition.Name = "lblDetailCondition"
        lblDetailCondition.Size = New Size(100, 25)
        lblDetailCondition.TabIndex = 43
        lblDetailCondition.Text = "Condition:"
        ' 
        ' txtDetailLocation
        ' 
        txtDetailLocation.Location = New Point(910, 90)
        txtDetailLocation.Name = "txtDetailLocation"
        txtDetailLocation.ReadOnly = True
        txtDetailLocation.Size = New Size(210, 31)
        txtDetailLocation.TabIndex = 42
        ' 
        ' lblDetailLocation
        ' 
        lblDetailLocation.AutoSize = True
        lblDetailLocation.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailLocation.Location = New Point(780, 95)
        lblDetailLocation.Name = "lblDetailLocation"
        lblDetailLocation.Size = New Size(90, 25)
        lblDetailLocation.TabIndex = 41
        lblDetailLocation.Text = "Location:"
        ' 
        ' txtDetailEndUser
        ' 
        txtDetailEndUser.Location = New Point(910, 40)
        txtDetailEndUser.Name = "txtDetailEndUser"
        txtDetailEndUser.ReadOnly = True
        txtDetailEndUser.Size = New Size(210, 31)
        txtDetailEndUser.TabIndex = 40
        ' 
        ' lblDetailEndUser
        ' 
        lblDetailEndUser.AutoSize = True
        lblDetailEndUser.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailEndUser.Location = New Point(780, 45)
        lblDetailEndUser.Name = "lblDetailEndUser"
        lblDetailEndUser.Size = New Size(93, 25)
        lblDetailEndUser.TabIndex = 39
        lblDetailEndUser.Text = "End User:"
        ' 
        ' txtDetailUsefulLife
        ' 
        txtDetailUsefulLife.Location = New Point(560, 291)
        txtDetailUsefulLife.Name = "txtDetailUsefulLife"
        txtDetailUsefulLife.ReadOnly = True
        txtDetailUsefulLife.Size = New Size(200, 31)
        txtDetailUsefulLife.TabIndex = 38
        ' 
        ' lblDetailUsefulLife
        ' 
        lblDetailUsefulLife.AutoSize = True
        lblDetailUsefulLife.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailUsefulLife.Location = New Point(370, 301)
        lblDetailUsefulLife.Name = "lblDetailUsefulLife"
        lblDetailUsefulLife.Size = New Size(107, 25)
        lblDetailUsefulLife.TabIndex = 37
        lblDetailUsefulLife.Text = "Useful Life:"
        ' 
        ' txtDetailUnitCost
        ' 
        txtDetailUnitCost.Location = New Point(560, 240)
        txtDetailUnitCost.Name = "txtDetailUnitCost"
        txtDetailUnitCost.ReadOnly = True
        txtDetailUnitCost.Size = New Size(200, 31)
        txtDetailUnitCost.TabIndex = 36
        ' 
        ' lblDetailUnitCost
        ' 
        lblDetailUnitCost.AutoSize = True
        lblDetailUnitCost.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailUnitCost.Location = New Point(370, 245)
        lblDetailUnitCost.Name = "lblDetailUnitCost"
        lblDetailUnitCost.Size = New Size(95, 25)
        lblDetailUnitCost.TabIndex = 35
        lblDetailUnitCost.Text = "Unit Cost:"
        ' 
        ' txtDetailQuantity
        ' 
        txtDetailQuantity.Location = New Point(560, 190)
        txtDetailQuantity.Name = "txtDetailQuantity"
        txtDetailQuantity.ReadOnly = True
        txtDetailQuantity.Size = New Size(200, 31)
        txtDetailQuantity.TabIndex = 34
        ' 
        ' lblDetailQuantity
        ' 
        lblDetailQuantity.AutoSize = True
        lblDetailQuantity.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailQuantity.Location = New Point(370, 195)
        lblDetailQuantity.Name = "lblDetailQuantity"
        lblDetailQuantity.Size = New Size(92, 25)
        lblDetailQuantity.TabIndex = 33
        lblDetailQuantity.Text = "Quantity:"
        ' 
        ' txtDetailSourceDocument
        ' 
        txtDetailSourceDocument.Location = New Point(560, 140)
        txtDetailSourceDocument.Name = "txtDetailSourceDocument"
        txtDetailSourceDocument.ReadOnly = True
        txtDetailSourceDocument.Size = New Size(200, 31)
        txtDetailSourceDocument.TabIndex = 32
        ' 
        ' lblDetailSourceDocument
        ' 
        lblDetailSourceDocument.AutoSize = True
        lblDetailSourceDocument.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailSourceDocument.Location = New Point(370, 145)
        lblDetailSourceDocument.Name = "lblDetailSourceDocument"
        lblDetailSourceDocument.Size = New Size(168, 25)
        lblDetailSourceDocument.TabIndex = 31
        lblDetailSourceDocument.Text = "Source Document:"
        ' 
        ' txtDetailFundSource
        ' 
        txtDetailFundSource.Location = New Point(560, 90)
        txtDetailFundSource.Name = "txtDetailFundSource"
        txtDetailFundSource.ReadOnly = True
        txtDetailFundSource.Size = New Size(200, 31)
        txtDetailFundSource.TabIndex = 30
        ' 
        ' lblDetailFundSource
        ' 
        lblDetailFundSource.AutoSize = True
        lblDetailFundSource.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailFundSource.Location = New Point(370, 95)
        lblDetailFundSource.Name = "lblDetailFundSource"
        lblDetailFundSource.Size = New Size(122, 25)
        lblDetailFundSource.TabIndex = 29
        lblDetailFundSource.Text = "Fund Source:"
        ' 
        ' txtDetailProcurement
        ' 
        txtDetailProcurement.Location = New Point(560, 40)
        txtDetailProcurement.Name = "txtDetailProcurement"
        txtDetailProcurement.ReadOnly = True
        txtDetailProcurement.Size = New Size(200, 31)
        txtDetailProcurement.TabIndex = 28
        ' 
        ' lblDetailProcurement
        ' 
        lblDetailProcurement.AutoSize = True
        lblDetailProcurement.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailProcurement.Location = New Point(370, 45)
        lblDetailProcurement.Name = "lblDetailProcurement"
        lblDetailProcurement.Size = New Size(127, 25)
        lblDetailProcurement.TabIndex = 27
        lblDetailProcurement.Text = "Procurement:"
        ' 
        ' txtDetailDateAcquired
        ' 
        txtDetailDateAcquired.Location = New Point(160, 290)
        txtDetailDateAcquired.Name = "txtDetailDateAcquired"
        txtDetailDateAcquired.ReadOnly = True
        txtDetailDateAcquired.Size = New Size(200, 31)
        txtDetailDateAcquired.TabIndex = 26
        ' 
        ' lblDetailDateAcquired
        ' 
        lblDetailDateAcquired.AutoSize = True
        lblDetailDateAcquired.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailDateAcquired.Location = New Point(20, 300)
        lblDetailDateAcquired.Name = "lblDetailDateAcquired"
        lblDetailDateAcquired.Size = New Size(139, 25)
        lblDetailDateAcquired.TabIndex = 25
        lblDetailDateAcquired.Text = "Date Acquired:"
        ' 
        ' txtDetailDescription
        ' 
        txtDetailDescription.AcceptsReturn = True
        txtDetailDescription.Location = New Point(160, 240)
        txtDetailDescription.Name = "txtDetailDescription"
        txtDetailDescription.ReadOnly = True
        txtDetailDescription.Size = New Size(200, 31)
        txtDetailDescription.TabIndex = 24
        ' 
        ' lblDetailDescription
        ' 
        lblDetailDescription.AutoSize = True
        lblDetailDescription.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailDescription.Location = New Point(20, 245)
        lblDetailDescription.Name = "lblDetailDescription"
        lblDetailDescription.Size = New Size(114, 25)
        lblDetailDescription.TabIndex = 23
        lblDetailDescription.Text = "Description:"
        ' 
        ' txtDetailArticle
        ' 
        txtDetailArticle.Location = New Point(160, 190)
        txtDetailArticle.Name = "txtDetailArticle"
        txtDetailArticle.ReadOnly = True
        txtDetailArticle.Size = New Size(200, 31)
        txtDetailArticle.TabIndex = 22
        ' 
        ' lblDetailArticle
        ' 
        lblDetailArticle.AutoSize = True
        lblDetailArticle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailArticle.Location = New Point(20, 195)
        lblDetailArticle.Name = "lblDetailArticle"
        lblDetailArticle.Size = New Size(74, 25)
        lblDetailArticle.TabIndex = 21
        lblDetailArticle.Text = "Article:"
        ' 
        ' txtDetailAccountCode
        ' 
        txtDetailAccountCode.Location = New Point(160, 140)
        txtDetailAccountCode.Name = "txtDetailAccountCode"
        txtDetailAccountCode.ReadOnly = True
        txtDetailAccountCode.Size = New Size(200, 31)
        txtDetailAccountCode.TabIndex = 20
        ' 
        ' lblDetailAccountCode
        ' 
        lblDetailAccountCode.AutoSize = True
        lblDetailAccountCode.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailAccountCode.Location = New Point(20, 145)
        lblDetailAccountCode.Name = "lblDetailAccountCode"
        lblDetailAccountCode.Size = New Size(136, 25)
        lblDetailAccountCode.TabIndex = 19
        lblDetailAccountCode.Text = "Account Code:"
        ' 
        ' txtDetailClassification
        ' 
        txtDetailClassification.Location = New Point(160, 90)
        txtDetailClassification.Name = "txtDetailClassification"
        txtDetailClassification.ReadOnly = True
        txtDetailClassification.Size = New Size(200, 31)
        txtDetailClassification.TabIndex = 18
        ' 
        ' lblDetailClassification
        ' 
        lblDetailClassification.AutoSize = True
        lblDetailClassification.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailClassification.Location = New Point(20, 95)
        lblDetailClassification.Name = "lblDetailClassification"
        lblDetailClassification.Size = New Size(129, 25)
        lblDetailClassification.TabIndex = 16
        lblDetailClassification.Text = "Classification:"
        ' 
        ' txtDetailPropertyNo
        ' 
        txtDetailPropertyNo.Location = New Point(160, 40)
        txtDetailPropertyNo.Name = "txtDetailPropertyNo"
        txtDetailPropertyNo.ReadOnly = True
        txtDetailPropertyNo.Size = New Size(200, 31)
        txtDetailPropertyNo.TabIndex = 17
        ' 
        ' lblDetailPropertyNo
        ' 
        lblDetailPropertyNo.AutoSize = True
        lblDetailPropertyNo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDetailPropertyNo.Location = New Point(20, 45)
        lblDetailPropertyNo.Name = "lblDetailPropertyNo"
        lblDetailPropertyNo.Size = New Size(122, 25)
        lblDetailPropertyNo.TabIndex = 16
        lblDetailPropertyNo.Text = "Property No:"
        ' 
        ' lblItemDetails
        ' 
        lblItemDetails.BackColor = Color.LightSteelBlue
        lblItemDetails.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemDetails.Location = New Point(10, 10)
        lblItemDetails.Name = "lblItemDetails"
        lblItemDetails.Size = New Size(1160, 30)
        lblItemDetails.TabIndex = 0
        lblItemDetails.Text = "ITEM DETAILS"
        ' 
        ' pnlItemMedia
        ' 
        pnlItemMedia.BackColor = Color.White
        pnlItemMedia.BorderStyle = BorderStyle.FixedSingle
        pnlItemMedia.Controls.Add(btnViewPhoto)
        pnlItemMedia.Controls.Add(btnViewQR)
        pnlItemMedia.Controls.Add(picItemQR)
        pnlItemMedia.Controls.Add(picItemPhoto)
        pnlItemMedia.Controls.Add(lblItemMedia)
        pnlItemMedia.Location = New Point(1190, 610)
        pnlItemMedia.Name = "pnlItemMedia"
        pnlItemMedia.Size = New Size(500, 350)
        pnlItemMedia.TabIndex = 15
        ' 
        ' btnViewPhoto
        ' 
        btnViewPhoto.Location = New Point(75, 275)
        btnViewPhoto.Name = "btnViewPhoto"
        btnViewPhoto.Size = New Size(115, 30)
        btnViewPhoto.TabIndex = 18
        btnViewPhoto.Text = "View Photo"
        btnViewPhoto.UseVisualStyleBackColor = True
        ' 
        ' btnViewQR
        ' 
        btnViewQR.Location = New Point(310, 275)
        btnViewQR.Name = "btnViewQR"
        btnViewQR.Size = New Size(115, 30)
        btnViewQR.TabIndex = 19
        btnViewQR.Text = "View QR"
        btnViewQR.UseVisualStyleBackColor = True
        ' 
        ' picItemQR
        ' 
        picItemQR.BorderStyle = BorderStyle.FixedSingle
        picItemQR.Location = New Point(260, 45)
        picItemQR.Name = "picItemQR"
        picItemQR.Size = New Size(220, 220)
        picItemQR.SizeMode = PictureBoxSizeMode.Zoom
        picItemQR.TabIndex = 17
        picItemQR.TabStop = False
        ' 
        ' picItemPhoto
        ' 
        picItemPhoto.BorderStyle = BorderStyle.FixedSingle
        picItemPhoto.Location = New Point(20, 45)
        picItemPhoto.Name = "picItemPhoto"
        picItemPhoto.Size = New Size(220, 220)
        picItemPhoto.SizeMode = PictureBoxSizeMode.Zoom
        picItemPhoto.TabIndex = 16
        picItemPhoto.TabStop = False
        ' 
        ' lblItemMedia
        ' 
        lblItemMedia.BackColor = Color.LightSteelBlue
        lblItemMedia.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemMedia.Location = New Point(10, 10)
        lblItemMedia.Name = "lblItemMedia"
        lblItemMedia.Size = New Size(500, 30)
        lblItemMedia.TabIndex = 0
        lblItemMedia.Text = "ITEM PHOTO / QR CODE"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        pnlSidebar.Controls.Add(btnSidebarSettings)
        pnlSidebar.Controls.Add(btnSidebarQRScan)
        pnlSidebar.Controls.Add(btnSidebarReports)
        pnlSidebar.Controls.Add(btnSidebarInventory)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(170, 694)
        pnlSidebar.TabIndex = 16
        pnlSidebar.Visible = False
        ' 
        ' btnSidebarSettings
        ' 
        btnSidebarSettings.FlatAppearance.BorderSize = 0
        btnSidebarSettings.FlatStyle = FlatStyle.Flat
        btnSidebarSettings.ForeColor = Color.White
        btnSidebarSettings.Location = New Point(10, 360)
        btnSidebarSettings.Name = "btnSidebarSettings"
        btnSidebarSettings.Size = New Size(170, 45)
        btnSidebarSettings.TabIndex = 25
        btnSidebarSettings.Text = "SETTINGS"
        btnSidebarSettings.UseVisualStyleBackColor = True
        ' 
        ' btnSidebarQRScan
        ' 
        btnSidebarQRScan.FlatAppearance.BorderSize = 0
        btnSidebarQRScan.FlatStyle = FlatStyle.Flat
        btnSidebarQRScan.ForeColor = Color.White
        btnSidebarQRScan.Location = New Point(10, 290)
        btnSidebarQRScan.Name = "btnSidebarQRScan"
        btnSidebarQRScan.Size = New Size(170, 45)
        btnSidebarQRScan.TabIndex = 24
        btnSidebarQRScan.Text = "QR SCAN"
        btnSidebarQRScan.UseVisualStyleBackColor = True
        ' 
        ' btnSidebarReports
        ' 
        btnSidebarReports.FlatAppearance.BorderSize = 0
        btnSidebarReports.FlatStyle = FlatStyle.Flat
        btnSidebarReports.ForeColor = Color.White
        btnSidebarReports.Location = New Point(10, 220)
        btnSidebarReports.Name = "btnSidebarReports"
        btnSidebarReports.Size = New Size(170, 45)
        btnSidebarReports.TabIndex = 23
        btnSidebarReports.Text = "REPORTS"
        btnSidebarReports.UseVisualStyleBackColor = True
        ' 
        ' btnSidebarInventory
        ' 
        btnSidebarInventory.FlatAppearance.BorderSize = 0
        btnSidebarInventory.FlatStyle = FlatStyle.Flat
        btnSidebarInventory.ForeColor = Color.White
        btnSidebarInventory.Location = New Point(10, 150)
        btnSidebarInventory.Name = "btnSidebarInventory"
        btnSidebarInventory.Size = New Size(170, 45)
        btnSidebarInventory.TabIndex = 22
        btnSidebarInventory.Text = "INVENTORY"
        btnSidebarInventory.UseVisualStyleBackColor = True
        ' 
        ' btnDashboard
        ' 
        btnDashboard.Cursor = Cursors.Hand
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(10, 80)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(170, 45)
        btnDashboard.TabIndex = 21
        btnDashboard.Text = "DASHBOARD"
        btnDashboard.UseVisualStyleBackColor = True
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.AutoScroll = True
        pnlMainContent.BackColor = Color.White
        pnlMainContent.Controls.Add(lblTotalAmount)
        pnlMainContent.Controls.Add(lblTotalItems)
        pnlMainContent.Controls.Add(lblSearch)
        pnlMainContent.Controls.Add(btnGeneratePARICS)
        pnlMainContent.Controls.Add(btnPrintSticker)
        pnlMainContent.Controls.Add(btnRefresh)
        pnlMainContent.Controls.Add(btnEdit)
        pnlMainContent.Controls.Add(dgvInventory)
        pnlMainContent.Controls.Add(lblFilterEndUser)
        pnlMainContent.Controls.Add(lblFilterClassification)
        pnlMainContent.Controls.Add(cboFilterCondition)
        pnlMainContent.Controls.Add(lblFilterCondition)
        pnlMainContent.Controls.Add(cboFilterLocation)
        pnlMainContent.Controls.Add(cboFilterEndUser)
        pnlMainContent.Controls.Add(cboFilterClassification)
        pnlMainContent.Controls.Add(txtSearch)
        pnlMainContent.Controls.Add(btnAddItem)
        pnlMainContent.Controls.Add(btnDelete)
        pnlMainContent.Controls.Add(lblFilterLocation)
        pnlMainContent.Controls.Add(pnlItemMedia)
        pnlMainContent.Controls.Add(pnlItemDetails)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(170, 70)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(1726, 624)
        pnlMainContent.TabIndex = 17
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Location = New Point(1400, 170)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(253, 25)
        lblTotalAmount.TabIndex = 22
        lblTotalAmount.Text = "Total Inventory Amount: ₱0.00"
        lblTotalAmount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblTotalItems
        ' 
        lblTotalItems.AutoSize = True
        lblTotalItems.Location = New Point(1250, 170)
        lblTotalItems.Name = "lblTotalItems"
        lblTotalItems.Size = New Size(117, 25)
        lblTotalItems.TabIndex = 18
        lblTotalItems.Text = "Total Items: 0"
        lblTotalItems.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(20, 25)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(64, 25)
        lblSearch.TabIndex = 21
        lblSearch.Text = "Search"
        ' 
        ' btnGeneratePARICS
        ' 
        btnGeneratePARICS.BackColor = Color.FromArgb(CByte(30), CByte(90), CByte(150))
        btnGeneratePARICS.Cursor = Cursors.Hand
        btnGeneratePARICS.FlatAppearance.BorderSize = 0
        btnGeneratePARICS.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGeneratePARICS.ForeColor = Color.White
        btnGeneratePARICS.Location = New Point(1170, 125)
        btnGeneratePARICS.Name = "btnGeneratePARICS"
        btnGeneratePARICS.Size = New Size(220, 45)
        btnGeneratePARICS.TabIndex = 22
        btnGeneratePARICS.Text = "Generate PAR/ICS"
        btnGeneratePARICS.UseVisualStyleBackColor = False
        ' 
        ' btnPrintSticker
        ' 
        btnPrintSticker.BackColor = Color.Transparent
        btnPrintSticker.Cursor = Cursors.Hand
        btnPrintSticker.FlatAppearance.BorderSize = 0
        btnPrintSticker.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintSticker.ForeColor = Color.Navy
        btnPrintSticker.Location = New Point(710, 125)
        btnPrintSticker.Name = "btnPrintSticker"
        btnPrintSticker.Size = New Size(200, 45)
        btnPrintSticker.TabIndex = 20
        btnPrintSticker.Text = "Print Sticker"
        btnPrintSticker.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.Transparent
        btnRefresh.Cursor = Cursors.Hand
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefresh.ForeColor = Color.Navy
        btnRefresh.Location = New Point(940, 125)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(200, 45)
        btnRefresh.TabIndex = 19
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DarkBlue
        btnEdit.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEdit.ForeColor = SystemColors.ControlLightLight
        btnEdit.Location = New Point(250, 125)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(200, 45)
        btnEdit.TabIndex = 18
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' dgvInventory
        ' 
        dgvInventory.AllowUserToAddRows = False
        dgvInventory.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dgvInventory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvInventory.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInventory.BackgroundColor = Color.White
        dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.DimGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvInventory.ColumnHeadersHeight = 35
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvInventory.Columns.AddRange(New DataGridViewColumn() {chkSelect})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgvInventory.DefaultCellStyle = DataGridViewCellStyle3
        dgvInventory.EnableHeadersVisualStyles = False
        dgvInventory.GridColor = Color.LightGray
        dgvInventory.Location = New Point(20, 200)
        dgvInventory.MultiSelect = False
        dgvInventory.Name = "dgvInventory"
        dgvInventory.ReadOnly = True
        dgvInventory.RowHeadersVisible = False
        dgvInventory.RowHeadersWidth = 62
        dgvInventory.RowTemplate.Height = 30
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInventory.Size = New Size(1662, 400)
        dgvInventory.TabIndex = 17
        ' 
        ' chkSelect
        ' 
        chkSelect.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        chkSelect.HeaderText = ""
        chkSelect.MinimumWidth = 8
        chkSelect.Name = "chkSelect"
        chkSelect.ReadOnly = True
        chkSelect.Width = 40
        ' 
        ' lblFilterEndUser
        ' 
        lblFilterEndUser.AutoSize = True
        lblFilterEndUser.Location = New Point(1080, 25)
        lblFilterEndUser.Name = "lblFilterEndUser"
        lblFilterEndUser.Size = New Size(82, 25)
        lblFilterEndUser.TabIndex = 16
        lblFilterEndUser.Text = "End User"
        ' 
        ' frmInventory
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1896, 694)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlInventoryHeader)
        Controls.Add(pnlSidebar)
        MinimumSize = New Size(1100, 750)
        Name = "frmInventory"
        Text = "WESTMINCOM INVENTORY SYSTEM"
        WindowState = FormWindowState.Maximized
        pnlInventoryHeader.ResumeLayout(False)
        pnlInventoryHeader.PerformLayout()
        pnlItemDetails.ResumeLayout(False)
        pnlItemDetails.PerformLayout()
        pnlItemMedia.ResumeLayout(False)
        CType(picItemQR, ComponentModel.ISupportInitialize).EndInit()
        CType(picItemPhoto, ComponentModel.ISupportInitialize).EndInit()
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlMainContent.PerformLayout()
        CType(dgvInventory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlInventoryHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents btnDelete As Button
    Friend WithEvents cboFilterClassification As ComboBox
    Friend WithEvents lblFilterClassification As Label
    Friend WithEvents lblFilterEndUser As Label
    Friend WithEvents cboFilterEndUser As ComboBox
    Friend WithEvents lblFilterLocation As Label
    Friend WithEvents cboFilterLocation As ComboBox
    Friend WithEvents lblFilterCondition As Label
    Friend WithEvents cboFilterCondition As ComboBox
    Friend WithEvents pnlItemDetails As Panel
    Friend WithEvents lblItemDetails As Label
    Friend WithEvents pnlItemMedia As Panel
    Friend WithEvents lblItemMedia As Label
    Friend WithEvents txtDetailPropertyNo As TextBox
    Friend WithEvents lblDetailPropertyNo As Label
    Friend WithEvents txtDetailClassification As TextBox
    Friend WithEvents lblDetailClassification As Label
    Friend WithEvents lblDetailAccountCode As Label
    Friend WithEvents txtDetailAccountCode As TextBox
    Friend WithEvents txtDetailArticle As TextBox
    Friend WithEvents lblDetailArticle As Label
    Friend WithEvents txtDetailDescription As TextBox
    Friend WithEvents lblDetailDescription As Label
    Friend WithEvents lblDetailDateAcquired As Label
    Friend WithEvents txtDetailDateAcquired As TextBox
    Friend WithEvents txtDetailProcurement As TextBox
    Friend WithEvents lblDetailProcurement As Label
    Friend WithEvents txtDetailFundSource As TextBox
    Friend WithEvents lblDetailFundSource As Label
    Friend WithEvents txtDetailSourceDocument As TextBox
    Friend WithEvents lblDetailSourceDocument As Label
    Friend WithEvents lblDetailQuantity As Label
    Friend WithEvents txtDetailQuantity As TextBox
    Friend WithEvents lblDetailUnitCost As Label
    Friend WithEvents txtDetailUnitCost As TextBox
    Friend WithEvents txtDetailUsefulLife As TextBox
    Friend WithEvents lblDetailUsefulLife As Label
    Friend WithEvents txtDetailLocation As TextBox
    Friend WithEvents lblDetailLocation As Label
    Friend WithEvents txtDetailEndUser As TextBox
    Friend WithEvents lblDetailEndUser As Label
    Friend WithEvents txtDetailCondition As TextBox
    Friend WithEvents lblDetailCondition As Label
    Friend WithEvents txtDetailPARICS As TextBox
    Friend WithEvents lblDetailPARICS As Label
    Friend WithEvents txtDetailRemarks As TextBox
    Friend WithEvents lblDetailRemarks As Label
    Friend WithEvents picItemPhoto As PictureBox
    Friend WithEvents picItemQR As PictureBox
    Friend WithEvents btnViewPhoto As Button
    Friend WithEvents btnViewQR As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnPrintSticker As Button
    Friend WithEvents btnGeneratePARICS As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnSidebarInventory As Button
    Friend WithEvents btnSidebarReports As Button
    Friend WithEvents btnSidebarSettings As Button
    Friend WithEvents btnSidebarQRScan As Button
    Friend WithEvents lblSearch As Label
    Friend WithEvents chkSelect As DataGridViewCheckBoxColumn
    Friend WithEvents lblTotalItems As Label
    Friend WithEvents lblTotalAmount As Label
End Class
