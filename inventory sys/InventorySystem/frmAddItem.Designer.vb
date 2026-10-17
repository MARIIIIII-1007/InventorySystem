<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddItem
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
        pnlItemInfo = New Panel()
        cboArticle = New ComboBox()
        lblArticle = New Label()
        cboAccountCode = New ComboBox()
        lblAccountCode = New Label()
        cboCondition = New ComboBox()
        lblCondition = New Label()
        cboCategory = New ComboBox()
        lblCategory = New Label()
        txtDescription = New TextBox()
        lblDescription = New Label()
        txtPropertyNo = New TextBox()
        lblPropertyNo = New Label()
        lblItemInfo = New Label()
        pnlProcurement = New Panel()
        txtEUL = New TextBox()
        lblEUL = New Label()
        txtSourceDoc = New TextBox()
        lblSourceDoc = New Label()
        lblFundSource = New Label()
        txtQuantity = New TextBox()
        lblQuantity = New Label()
        txtUnitCost = New TextBox()
        lblUnitCost = New Label()
        cboProcurement = New ComboBox()
        lblModeProcurement = New Label()
        dtpDateAcquired = New DateTimePicker()
        lblDateAcquired = New Label()
        lblProcurement = New Label()
        pnlAssignment = New Panel()
        txtRemarks = New TextBox()
        lblRemarks = New Label()
        cboEndUser = New ComboBox()
        lblEndUser = New Label()
        cboLocation = New ComboBox()
        lblLocation = New Label()
        lblAssignment = New Label()
        pnlPhotoQR = New Panel()
        cmdClose = New Button()
        cmdClear = New Button()
        cmdSave = New Button()
        lblQRStatus = New Label()
        btnRemovePhoto = New Button()
        btnUploadPhoto = New Button()
        picItemPhoto = New PictureBox()
        lblPhotoQR = New Label()
        cboFundSource = New ComboBox()
        pnlItemInfo.SuspendLayout()
        pnlProcurement.SuspendLayout()
        pnlAssignment.SuspendLayout()
        pnlPhotoQR.SuspendLayout()
        CType(picItemPhoto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlItemInfo
        ' 
        pnlItemInfo.BackColor = Color.White
        pnlItemInfo.BorderStyle = BorderStyle.FixedSingle
        pnlItemInfo.Controls.Add(cboArticle)
        pnlItemInfo.Controls.Add(lblArticle)
        pnlItemInfo.Controls.Add(cboAccountCode)
        pnlItemInfo.Controls.Add(lblAccountCode)
        pnlItemInfo.Controls.Add(cboCondition)
        pnlItemInfo.Controls.Add(lblCondition)
        pnlItemInfo.Controls.Add(cboCategory)
        pnlItemInfo.Controls.Add(lblCategory)
        pnlItemInfo.Controls.Add(txtDescription)
        pnlItemInfo.Controls.Add(lblDescription)
        pnlItemInfo.Controls.Add(txtPropertyNo)
        pnlItemInfo.Controls.Add(lblPropertyNo)
        pnlItemInfo.Controls.Add(lblItemInfo)
        pnlItemInfo.Location = New Point(20, 20)
        pnlItemInfo.Name = "pnlItemInfo"
        pnlItemInfo.Size = New Size(1100, 220)
        pnlItemInfo.TabIndex = 0
        ' 
        ' cboArticle
        ' 
        cboArticle.DropDownStyle = ComboBoxStyle.DropDownList
        cboArticle.FormattingEnabled = True
        cboArticle.Location = New Point(710, 170)
        cboArticle.Name = "cboArticle"
        cboArticle.Size = New Size(350, 33)
        cboArticle.TabIndex = 16
        ' 
        ' lblArticle
        ' 
        lblArticle.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblArticle.Location = New Point(570, 170)
        lblArticle.Name = "lblArticle"
        lblArticle.Size = New Size(110, 30)
        lblArticle.TabIndex = 15
        lblArticle.Text = "Article:"
        ' 
        ' cboAccountCode
        ' 
        cboAccountCode.DropDownStyle = ComboBoxStyle.DropDownList
        cboAccountCode.FormattingEnabled = True
        cboAccountCode.Location = New Point(170, 170)
        cboAccountCode.Name = "cboAccountCode"
        cboAccountCode.Size = New Size(380, 33)
        cboAccountCode.TabIndex = 14
        ' 
        ' lblAccountCode
        ' 
        lblAccountCode.AutoSize = True
        lblAccountCode.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAccountCode.Location = New Point(20, 170)
        lblAccountCode.Name = "lblAccountCode"
        lblAccountCode.Size = New Size(139, 28)
        lblAccountCode.TabIndex = 13
        lblAccountCode.Text = "Account Code:"
        ' 
        ' cboCondition
        ' 
        cboCondition.DropDownStyle = ComboBoxStyle.DropDownList
        cboCondition.FormattingEnabled = True
        cboCondition.Location = New Point(710, 110)
        cboCondition.Name = "cboCondition"
        cboCondition.Size = New Size(350, 33)
        cboCondition.TabIndex = 12
        ' 
        ' lblCondition
        ' 
        lblCondition.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCondition.Location = New Point(570, 110)
        lblCondition.Name = "lblCondition"
        lblCondition.Size = New Size(110, 30)
        lblCondition.TabIndex = 11
        lblCondition.Text = "Condition:"
        ' 
        ' cboCategory
        ' 
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(710, 45)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(350, 33)
        cboCategory.TabIndex = 10
        ' 
        ' lblCategory
        ' 
        lblCategory.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCategory.Location = New Point(570, 50)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(110, 30)
        lblCategory.TabIndex = 9
        lblCategory.Text = "Category:"
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(170, 95)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.ScrollBars = ScrollBars.Vertical
        txtDescription.Size = New Size(380, 60)
        txtDescription.TabIndex = 8
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDescription.Location = New Point(20, 95)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(130, 30)
        lblDescription.TabIndex = 7
        lblDescription.Text = "Description:"
        ' 
        ' txtPropertyNo
        ' 
        txtPropertyNo.Location = New Point(170, 50)
        txtPropertyNo.Name = "txtPropertyNo"
        txtPropertyNo.Size = New Size(380, 31)
        txtPropertyNo.TabIndex = 6
        ' 
        ' lblPropertyNo
        ' 
        lblPropertyNo.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPropertyNo.Location = New Point(20, 50)
        lblPropertyNo.Name = "lblPropertyNo"
        lblPropertyNo.Size = New Size(130, 30)
        lblPropertyNo.TabIndex = 5
        lblPropertyNo.Text = "Property No:"
        ' 
        ' lblItemInfo
        ' 
        lblItemInfo.AutoSize = True
        lblItemInfo.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemInfo.ForeColor = Color.DimGray
        lblItemInfo.Location = New Point(15, 15)
        lblItemInfo.Name = "lblItemInfo"
        lblItemInfo.Size = New Size(226, 30)
        lblItemInfo.TabIndex = 4
        lblItemInfo.Text = "ITEM INFORMATION"
        ' 
        ' pnlProcurement
        ' 
        pnlProcurement.BackColor = Color.White
        pnlProcurement.BorderStyle = BorderStyle.FixedSingle
        pnlProcurement.Controls.Add(cboFundSource)
        pnlProcurement.Controls.Add(txtEUL)
        pnlProcurement.Controls.Add(lblEUL)
        pnlProcurement.Controls.Add(txtSourceDoc)
        pnlProcurement.Controls.Add(lblSourceDoc)
        pnlProcurement.Controls.Add(lblFundSource)
        pnlProcurement.Controls.Add(txtQuantity)
        pnlProcurement.Controls.Add(lblQuantity)
        pnlProcurement.Controls.Add(txtUnitCost)
        pnlProcurement.Controls.Add(lblUnitCost)
        pnlProcurement.Controls.Add(cboProcurement)
        pnlProcurement.Controls.Add(lblModeProcurement)
        pnlProcurement.Controls.Add(dtpDateAcquired)
        pnlProcurement.Controls.Add(lblDateAcquired)
        pnlProcurement.Controls.Add(lblProcurement)
        pnlProcurement.Location = New Point(20, 250)
        pnlProcurement.Name = "pnlProcurement"
        pnlProcurement.Size = New Size(1100, 220)
        pnlProcurement.TabIndex = 1
        ' 
        ' txtEUL
        ' 
        txtEUL.Location = New Point(710, 140)
        txtEUL.Name = "txtEUL"
        txtEUL.ReadOnly = True
        txtEUL.Size = New Size(350, 31)
        txtEUL.TabIndex = 23
        ' 
        ' lblEUL
        ' 
        lblEUL.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEUL.Location = New Point(570, 140)
        lblEUL.Name = "lblEUL"
        lblEUL.Size = New Size(120, 30)
        lblEUL.TabIndex = 22
        lblEUL.Text = "EUL:"
        ' 
        ' txtSourceDoc
        ' 
        txtSourceDoc.Location = New Point(170, 175)
        txtSourceDoc.Name = "txtSourceDoc"
        txtSourceDoc.Size = New Size(380, 31)
        txtSourceDoc.TabIndex = 21
        ' 
        ' lblSourceDoc
        ' 
        lblSourceDoc.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSourceDoc.Location = New Point(20, 175)
        lblSourceDoc.Name = "lblSourceDoc"
        lblSourceDoc.Size = New Size(150, 30)
        lblSourceDoc.TabIndex = 20
        lblSourceDoc.Text = "Source Docs:"
        ' 
        ' lblFundSource
        ' 
        lblFundSource.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFundSource.Location = New Point(20, 135)
        lblFundSource.Name = "lblFundSource"
        lblFundSource.Size = New Size(150, 30)
        lblFundSource.TabIndex = 18
        lblFundSource.Text = "Fund Source:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(710, 90)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(350, 31)
        txtQuantity.TabIndex = 17
        ' 
        ' lblQuantity
        ' 
        lblQuantity.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblQuantity.Location = New Point(570, 90)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(100, 30)
        lblQuantity.TabIndex = 16
        lblQuantity.Text = "Quantity:"
        ' 
        ' txtUnitCost
        ' 
        txtUnitCost.Location = New Point(710, 40)
        txtUnitCost.Name = "txtUnitCost"
        txtUnitCost.Size = New Size(350, 31)
        txtUnitCost.TabIndex = 15
        ' 
        ' lblUnitCost
        ' 
        lblUnitCost.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUnitCost.Location = New Point(570, 45)
        lblUnitCost.Name = "lblUnitCost"
        lblUnitCost.Size = New Size(100, 30)
        lblUnitCost.TabIndex = 14
        lblUnitCost.Text = "Unit Cost:"
        ' 
        ' cboProcurement
        ' 
        cboProcurement.DropDownStyle = ComboBoxStyle.DropDownList
        cboProcurement.FormattingEnabled = True
        cboProcurement.Location = New Point(170, 85)
        cboProcurement.Name = "cboProcurement"
        cboProcurement.Size = New Size(380, 33)
        cboProcurement.TabIndex = 13
        ' 
        ' lblModeProcurement
        ' 
        lblModeProcurement.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblModeProcurement.Location = New Point(20, 85)
        lblModeProcurement.Name = "lblModeProcurement"
        lblModeProcurement.Size = New Size(150, 30)
        lblModeProcurement.TabIndex = 8
        lblModeProcurement.Text = "Procurement:"
        ' 
        ' dtpDateAcquired
        ' 
        dtpDateAcquired.Checked = False
        dtpDateAcquired.Format = DateTimePickerFormat.Short
        dtpDateAcquired.Location = New Point(170, 45)
        dtpDateAcquired.Name = "dtpDateAcquired"
        dtpDateAcquired.Size = New Size(380, 31)
        dtpDateAcquired.TabIndex = 7
        ' 
        ' lblDateAcquired
        ' 
        lblDateAcquired.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDateAcquired.Location = New Point(20, 45)
        lblDateAcquired.Name = "lblDateAcquired"
        lblDateAcquired.Size = New Size(150, 30)
        lblDateAcquired.TabIndex = 6
        lblDateAcquired.Text = "Date Acquired:"
        ' 
        ' lblProcurement
        ' 
        lblProcurement.AutoSize = True
        lblProcurement.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProcurement.ForeColor = Color.DimGray
        lblProcurement.Location = New Point(15, 15)
        lblProcurement.Name = "lblProcurement"
        lblProcurement.Size = New Size(267, 30)
        lblProcurement.TabIndex = 5
        lblProcurement.Text = "PROCUREMENT DETAILS"
        ' 
        ' pnlAssignment
        ' 
        pnlAssignment.BackColor = Color.White
        pnlAssignment.BorderStyle = BorderStyle.FixedSingle
        pnlAssignment.Controls.Add(txtRemarks)
        pnlAssignment.Controls.Add(lblRemarks)
        pnlAssignment.Controls.Add(cboEndUser)
        pnlAssignment.Controls.Add(lblEndUser)
        pnlAssignment.Controls.Add(cboLocation)
        pnlAssignment.Controls.Add(lblLocation)
        pnlAssignment.Controls.Add(lblAssignment)
        pnlAssignment.Location = New Point(20, 480)
        pnlAssignment.Name = "pnlAssignment"
        pnlAssignment.Size = New Size(1100, 150)
        pnlAssignment.TabIndex = 2
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Location = New Point(710, 45)
        txtRemarks.Multiline = True
        txtRemarks.Name = "txtRemarks"
        txtRemarks.ScrollBars = ScrollBars.Vertical
        txtRemarks.Size = New Size(350, 75)
        txtRemarks.TabIndex = 18
        ' 
        ' lblRemarks
        ' 
        lblRemarks.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRemarks.Location = New Point(570, 45)
        lblRemarks.Name = "lblRemarks"
        lblRemarks.Size = New Size(90, 30)
        lblRemarks.TabIndex = 17
        lblRemarks.Text = "Remarks:"
        ' 
        ' cboEndUser
        ' 
        cboEndUser.DropDownStyle = ComboBoxStyle.DropDownList
        cboEndUser.FormattingEnabled = True
        cboEndUser.Location = New Point(150, 90)
        cboEndUser.Name = "cboEndUser"
        cboEndUser.Size = New Size(380, 33)
        cboEndUser.TabIndex = 16
        ' 
        ' lblEndUser
        ' 
        lblEndUser.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEndUser.Location = New Point(20, 90)
        lblEndUser.Name = "lblEndUser"
        lblEndUser.Size = New Size(120, 30)
        lblEndUser.TabIndex = 15
        lblEndUser.Text = "End User:"
        ' 
        ' cboLocation
        ' 
        cboLocation.DropDownStyle = ComboBoxStyle.DropDownList
        cboLocation.FormattingEnabled = True
        cboLocation.Location = New Point(150, 45)
        cboLocation.Name = "cboLocation"
        cboLocation.Size = New Size(380, 33)
        cboLocation.TabIndex = 14
        ' 
        ' lblLocation
        ' 
        lblLocation.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLocation.Location = New Point(20, 45)
        lblLocation.Name = "lblLocation"
        lblLocation.Size = New Size(120, 30)
        lblLocation.TabIndex = 7
        lblLocation.Text = "Location:"
        ' 
        ' lblAssignment
        ' 
        lblAssignment.AutoSize = True
        lblAssignment.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAssignment.ForeColor = Color.DimGray
        lblAssignment.Location = New Point(15, 15)
        lblAssignment.Name = "lblAssignment"
        lblAssignment.Size = New Size(248, 30)
        lblAssignment.TabIndex = 6
        lblAssignment.Text = "LOCATION / END USER"
        ' 
        ' pnlPhotoQR
        ' 
        pnlPhotoQR.BackColor = Color.White
        pnlPhotoQR.BorderStyle = BorderStyle.FixedSingle
        pnlPhotoQR.Controls.Add(cmdClose)
        pnlPhotoQR.Controls.Add(cmdClear)
        pnlPhotoQR.Controls.Add(cmdSave)
        pnlPhotoQR.Controls.Add(lblQRStatus)
        pnlPhotoQR.Controls.Add(btnRemovePhoto)
        pnlPhotoQR.Controls.Add(btnUploadPhoto)
        pnlPhotoQR.Controls.Add(picItemPhoto)
        pnlPhotoQR.Controls.Add(lblPhotoQR)
        pnlPhotoQR.Location = New Point(1140, 20)
        pnlPhotoQR.Name = "pnlPhotoQR"
        pnlPhotoQR.Size = New Size(320, 610)
        pnlPhotoQR.TabIndex = 3
        ' 
        ' cmdClose
        ' 
        cmdClose.BackColor = Color.SteelBlue
        cmdClose.Cursor = Cursors.Hand
        cmdClose.FlatAppearance.BorderSize = 0
        cmdClose.FlatStyle = FlatStyle.Flat
        cmdClose.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmdClose.ForeColor = Color.White
        cmdClose.Location = New Point(90, 550)
        cmdClose.Name = "cmdClose"
        cmdClose.Size = New Size(140, 40)
        cmdClose.TabIndex = 13
        cmdClose.Text = "Close"
        cmdClose.UseVisualStyleBackColor = False
        ' 
        ' cmdClear
        ' 
        cmdClear.BackColor = Color.SteelBlue
        cmdClear.Cursor = Cursors.Hand
        cmdClear.FlatAppearance.BorderSize = 0
        cmdClear.FlatStyle = FlatStyle.Flat
        cmdClear.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmdClear.ForeColor = Color.White
        cmdClear.Location = New Point(90, 500)
        cmdClear.Name = "cmdClear"
        cmdClear.Size = New Size(140, 40)
        cmdClear.TabIndex = 12
        cmdClear.Text = "Clear Form"
        cmdClear.UseVisualStyleBackColor = False
        ' 
        ' cmdSave
        ' 
        cmdSave.BackColor = Color.SteelBlue
        cmdSave.Cursor = Cursors.Hand
        cmdSave.FlatAppearance.BorderSize = 0
        cmdSave.FlatStyle = FlatStyle.Flat
        cmdSave.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmdSave.ForeColor = Color.White
        cmdSave.Location = New Point(90, 450)
        cmdSave.Name = "cmdSave"
        cmdSave.Size = New Size(140, 40)
        cmdSave.TabIndex = 4
        cmdSave.Text = "Save Item"
        cmdSave.UseVisualStyleBackColor = False
        ' 
        ' lblQRStatus
        ' 
        lblQRStatus.AutoSize = True
        lblQRStatus.ForeColor = Color.Gray
        lblQRStatus.Location = New Point(25, 385)
        lblQRStatus.Name = "lblQRStatus"
        lblQRStatus.Size = New Size(214, 25)
        lblQRStatus.TabIndex = 11
        lblQRStatus.Text = "QR Code : Not Generated"
        ' 
        ' btnRemovePhoto
        ' 
        btnRemovePhoto.FlatStyle = FlatStyle.Flat
        btnRemovePhoto.Location = New Point(155, 315)
        btnRemovePhoto.Name = "btnRemovePhoto"
        btnRemovePhoto.Size = New Size(120, 35)
        btnRemovePhoto.TabIndex = 10
        btnRemovePhoto.Text = "Remove"
        btnRemovePhoto.UseVisualStyleBackColor = True
        ' 
        ' btnUploadPhoto
        ' 
        btnUploadPhoto.FlatStyle = FlatStyle.Flat
        btnUploadPhoto.Location = New Point(25, 315)
        btnUploadPhoto.Name = "btnUploadPhoto"
        btnUploadPhoto.Size = New Size(120, 35)
        btnUploadPhoto.TabIndex = 9
        btnUploadPhoto.Text = "Upload "
        btnUploadPhoto.UseVisualStyleBackColor = True
        ' 
        ' picItemPhoto
        ' 
        picItemPhoto.BorderStyle = BorderStyle.FixedSingle
        picItemPhoto.Location = New Point(25, 50)
        picItemPhoto.Name = "picItemPhoto"
        picItemPhoto.Size = New Size(250, 250)
        picItemPhoto.SizeMode = PictureBoxSizeMode.Zoom
        picItemPhoto.TabIndex = 8
        picItemPhoto.TabStop = False
        ' 
        ' lblPhotoQR
        ' 
        lblPhotoQR.AutoSize = True
        lblPhotoQR.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPhotoQR.ForeColor = Color.DimGray
        lblPhotoQR.Location = New Point(15, 15)
        lblPhotoQR.Name = "lblPhotoQR"
        lblPhotoQR.Size = New Size(266, 30)
        lblPhotoQR.TabIndex = 7
        lblPhotoQR.Text = "ITEM PHOTO / QR CODE"
        ' 
        ' cboFundSource
        ' 
        cboFundSource.DropDownStyle = ComboBoxStyle.DropDownList
        cboFundSource.FormattingEnabled = True
        cboFundSource.Location = New Point(170, 132)
        cboFundSource.Name = "cboFundSource"
        cboFundSource.Size = New Size(380, 33)
        cboFundSource.TabIndex = 24
        ' 
        ' frmAddItem
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1478, 644)
        Controls.Add(pnlPhotoQR)
        Controls.Add(pnlAssignment)
        Controls.Add(pnlProcurement)
        Controls.Add(pnlItemInfo)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmAddItem"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Add Inventory Item"
        pnlItemInfo.ResumeLayout(False)
        pnlItemInfo.PerformLayout()
        pnlProcurement.ResumeLayout(False)
        pnlProcurement.PerformLayout()
        pnlAssignment.ResumeLayout(False)
        pnlAssignment.PerformLayout()
        pnlPhotoQR.ResumeLayout(False)
        pnlPhotoQR.PerformLayout()
        CType(picItemPhoto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlItemInfo As Panel
    Friend WithEvents pnlProcurement As Panel
    Friend WithEvents pnlAssignment As Panel
    Friend WithEvents pnlPhotoQR As Panel
    Friend WithEvents lblItemInfo As Label
    Friend WithEvents lblProcurement As Label
    Friend WithEvents lblAssignment As Label
    Friend WithEvents lblPhotoQR As Label
    Friend WithEvents txtPropertyNo As TextBox
    Friend WithEvents lblPropertyNo As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents cboCondition As ComboBox
    Friend WithEvents lblCondition As Label
    Friend WithEvents dtpDateAcquired As DateTimePicker
    Friend WithEvents lblDateAcquired As Label
    Friend WithEvents cboProcurement As ComboBox
    Friend WithEvents lblModeProcurement As Label
    Friend WithEvents txtUnitCost As TextBox
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblFundSource As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents cboEndUser As ComboBox
    Friend WithEvents lblEndUser As Label
    Friend WithEvents cboLocation As ComboBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents picItemPhoto As PictureBox
    Friend WithEvents btnRemovePhoto As Button
    Friend WithEvents btnUploadPhoto As Button
    Friend WithEvents lblQRStatus As Label
    Friend WithEvents lblAccountCode As Label
    Friend WithEvents lblArticle As Label
    Friend WithEvents cboAccountCode As ComboBox
    Friend WithEvents cboArticle As ComboBox
    Friend WithEvents lblSourceDoc As Label
    Friend WithEvents txtEUL As TextBox
    Friend WithEvents lblEUL As Label
    Friend WithEvents txtSourceDoc As TextBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cboFundSource As ComboBox
End Class
