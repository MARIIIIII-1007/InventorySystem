<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStickerFormat
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
        rdoWithQR = New RadioButton()
        rdoWithoutQR = New RadioButton()
        btnContinue = New Button()
        btnCancel = New Button()
        rdoWithBarcode = New RadioButton()
        SuspendLayout()
        ' 
        ' rdoWithQR
        ' 
        rdoWithQR.AutoSize = True
        rdoWithQR.Checked = True
        rdoWithQR.Location = New Point(70, 20)
        rdoWithQR.Name = "rdoWithQR"
        rdoWithQR.Size = New Size(151, 29)
        rdoWithQR.TabIndex = 0
        rdoWithQR.TabStop = True
        rdoWithQR.Text = "With QR Code"
        rdoWithQR.UseVisualStyleBackColor = True
        ' 
        ' rdoWithoutQR
        ' 
        rdoWithoutQR.AutoSize = True
        rdoWithoutQR.Location = New Point(70, 100)
        rdoWithoutQR.Name = "rdoWithoutQR"
        rdoWithoutQR.Size = New Size(178, 29)
        rdoWithoutQR.TabIndex = 1
        rdoWithoutQR.Text = "Without QR Code"
        rdoWithoutQR.UseVisualStyleBackColor = True
        ' 
        ' btnContinue
        ' 
        btnContinue.Location = New Point(70, 150)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(100, 34)
        btnContinue.TabIndex = 2
        btnContinue.Text = "Continue"
        btnContinue.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(190, 150)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(100, 34)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' rdoWithBarcode
        ' 
        rdoWithBarcode.AutoSize = True
        rdoWithBarcode.Location = New Point(70, 60)
        rdoWithBarcode.Name = "rdoWithBarcode"
        rdoWithBarcode.Size = New Size(143, 29)
        rdoWithBarcode.TabIndex = 4
        rdoWithBarcode.TabStop = True
        rdoWithBarcode.Text = "With Barcode"
        rdoWithBarcode.UseVisualStyleBackColor = True
        ' 
        ' frmStickerFormat
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(378, 194)
        Controls.Add(rdoWithBarcode)
        Controls.Add(btnCancel)
        Controls.Add(btnContinue)
        Controls.Add(rdoWithoutQR)
        Controls.Add(rdoWithQR)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmStickerFormat"
        StartPosition = FormStartPosition.CenterParent
        Text = "Select Sticker Format"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rdoWithQR As RadioButton
    Friend WithEvents rdoWithoutQR As RadioButton
    Friend WithEvents btnContinue As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents rdoWithBarcode As RadioButton
End Class
