<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegisterFoundItem
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
        lblPropertyNo = New Label()
        lblDescription = New Label()
        lblActualLocation = New Label()
        lblObservedCondition = New Label()
        lblDiscrepancyNotes = New Label()
        lblPhoto = New Label()
        txtPropertyNo = New TextBox()
        txtDescription = New TextBox()
        txtActualLocation = New TextBox()
        cmbObservedCondition = New ComboBox()
        txtDiscrepancyNotes = New TextBox()
        txtPhotoPath = New TextBox()
        btnBrowsePhoto = New Button()
        btnCancel = New Button()
        btnSave = New Button()
        btnLinkExistingProperty = New Button()
        btnRegisterNewProperty = New Button()
        SuspendLayout()
        ' 
        ' lblPropertyNo
        ' 
        lblPropertyNo.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblPropertyNo.Location = New Point(20, 15)
        lblPropertyNo.Name = "lblPropertyNo"
        lblPropertyNo.Size = New Size(590, 25)
        lblPropertyNo.TabIndex = 0
        lblPropertyNo.Text = "Property Number (if known)"
        lblPropertyNo.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDescription
        ' 
        lblDescription.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblDescription.Location = New Point(20, 72)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(590, 25)
        lblDescription.TabIndex = 1
        lblDescription.Text = "Description *"
        lblDescription.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblActualLocation
        ' 
        lblActualLocation.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblActualLocation.Location = New Point(20, 129)
        lblActualLocation.Name = "lblActualLocation"
        lblActualLocation.Size = New Size(590, 25)
        lblActualLocation.TabIndex = 2
        lblActualLocation.Text = "Actual Location*"
        lblActualLocation.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblObservedCondition
        ' 
        lblObservedCondition.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblObservedCondition.Location = New Point(20, 186)
        lblObservedCondition.Name = "lblObservedCondition"
        lblObservedCondition.Size = New Size(590, 25)
        lblObservedCondition.TabIndex = 3
        lblObservedCondition.Text = "Observed Condition"
        lblObservedCondition.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDiscrepancyNotes
        ' 
        lblDiscrepancyNotes.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblDiscrepancyNotes.Location = New Point(20, 243)
        lblDiscrepancyNotes.Name = "lblDiscrepancyNotes"
        lblDiscrepancyNotes.Size = New Size(590, 25)
        lblDiscrepancyNotes.TabIndex = 4
        lblDiscrepancyNotes.Text = "Discrepancy Notes"
        lblDiscrepancyNotes.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPhoto
        ' 
        lblPhoto.Font = New Font("Arial", 9F, FontStyle.Bold)
        lblPhoto.Location = New Point(20, 342)
        lblPhoto.Name = "lblPhoto"
        lblPhoto.Size = New Size(590, 25)
        lblPhoto.TabIndex = 5
        lblPhoto.Text = "Item Photo (optional)"
        lblPhoto.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtPropertyNo
        ' 
        txtPropertyNo.Location = New Point(20, 40)
        txtPropertyNo.Name = "txtPropertyNo"
        txtPropertyNo.Size = New Size(590, 31)
        txtPropertyNo.TabIndex = 6
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(20, 100)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(590, 31)
        txtDescription.TabIndex = 7
        ' 
        ' txtActualLocation
        ' 
        txtActualLocation.Location = New Point(20, 155)
        txtActualLocation.Name = "txtActualLocation"
        txtActualLocation.Size = New Size(590, 31)
        txtActualLocation.TabIndex = 8
        ' 
        ' cmbObservedCondition
        ' 
        cmbObservedCondition.DropDownStyle = ComboBoxStyle.DropDownList
        cmbObservedCondition.FormattingEnabled = True
        cmbObservedCondition.Location = New Point(20, 210)
        cmbObservedCondition.Name = "cmbObservedCondition"
        cmbObservedCondition.Size = New Size(590, 33)
        cmbObservedCondition.TabIndex = 9
        ' 
        ' txtDiscrepancyNotes
        ' 
        txtDiscrepancyNotes.Location = New Point(20, 270)
        txtDiscrepancyNotes.MaxLength = 2000
        txtDiscrepancyNotes.Multiline = True
        txtDiscrepancyNotes.Name = "txtDiscrepancyNotes"
        txtDiscrepancyNotes.ScrollBars = ScrollBars.Vertical
        txtDiscrepancyNotes.Size = New Size(590, 70)
        txtDiscrepancyNotes.TabIndex = 10
        ' 
        ' txtPhotoPath
        ' 
        txtPhotoPath.Location = New Point(20, 370)
        txtPhotoPath.Name = "txtPhotoPath"
        txtPhotoPath.ReadOnly = True
        txtPhotoPath.Size = New Size(460, 31)
        txtPhotoPath.TabIndex = 11
        ' 
        ' btnBrowsePhoto
        ' 
        btnBrowsePhoto.Location = New Point(490, 364)
        btnBrowsePhoto.Name = "btnBrowsePhoto"
        btnBrowsePhoto.Size = New Size(120, 35)
        btnBrowsePhoto.TabIndex = 12
        btnBrowsePhoto.Text = "Browse..."
        btnBrowsePhoto.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.Location = New Point(370, 450)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 36)
        btnCancel.TabIndex = 13
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.SteelBlue
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(480, 450)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(130, 36)
        btnSave.TabIndex = 14
        btnSave.Text = "Save Record"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnLinkExistingProperty
        ' 
        btnLinkExistingProperty.Location = New Point(50, 410)
        btnLinkExistingProperty.Name = "btnLinkExistingProperty"
        btnLinkExistingProperty.Size = New Size(250, 35)
        btnLinkExistingProperty.TabIndex = 15
        btnLinkExistingProperty.Text = "Link Existing Property"
        btnLinkExistingProperty.UseVisualStyleBackColor = True
        ' 
        ' btnRegisterNewProperty
        ' 
        btnRegisterNewProperty.AutoSize = True
        btnRegisterNewProperty.Location = New Point(300, 410)
        btnRegisterNewProperty.Name = "btnRegisterNewProperty"
        btnRegisterNewProperty.Size = New Size(250, 35)
        btnRegisterNewProperty.TabIndex = 16
        btnRegisterNewProperty.Text = "Register as New Property"
        btnRegisterNewProperty.UseVisualStyleBackColor = True
        ' 
        ' frmRegisterFoundItem
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(628, 494)
        Controls.Add(btnRegisterNewProperty)
        Controls.Add(btnLinkExistingProperty)
        Controls.Add(btnSave)
        Controls.Add(btnCancel)
        Controls.Add(btnBrowsePhoto)
        Controls.Add(txtPhotoPath)
        Controls.Add(txtDiscrepancyNotes)
        Controls.Add(cmbObservedCondition)
        Controls.Add(txtActualLocation)
        Controls.Add(txtDescription)
        Controls.Add(txtPropertyNo)
        Controls.Add(lblPhoto)
        Controls.Add(lblDiscrepancyNotes)
        Controls.Add(lblObservedCondition)
        Controls.Add(lblActualLocation)
        Controls.Add(lblDescription)
        Controls.Add(lblPropertyNo)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmRegisterFoundItem"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Register Found Item"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblPropertyNo As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblActualLocation As Label
    Friend WithEvents lblObservedCondition As Label
    Friend WithEvents lblDiscrepancyNotes As Label
    Friend WithEvents lblPhoto As Label
    Friend WithEvents txtPropertyNo As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtActualLocation As TextBox
    Friend WithEvents cmbObservedCondition As ComboBox
    Friend WithEvents txtDiscrepancyNotes As TextBox
    Friend WithEvents txtPhotoPath As TextBox
    Friend WithEvents btnBrowsePhoto As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLinkExistingProperty As Button
    Friend WithEvents btnRegisterNewProperty As Button
End Class
