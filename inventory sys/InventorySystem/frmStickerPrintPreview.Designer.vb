<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStickerPrintPreview
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
        picPreview = New PictureBox()
        pnlBottom = New Panel()
        btnCancel = New Button()
        btnPrint = New Button()
        lblPage = New Label()
        btnNext = New Button()
        btnPrevious = New Button()
        CType(picPreview, ComponentModel.ISupportInitialize).BeginInit()
        pnlBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' picPreview
        ' 
        picPreview.BackColor = Color.Gray
        picPreview.Dock = DockStyle.Fill
        picPreview.Location = New Point(0, 0)
        picPreview.Name = "picPreview"
        picPreview.Size = New Size(800, 450)
        picPreview.SizeMode = PictureBoxSizeMode.Zoom
        picPreview.TabIndex = 0
        picPreview.TabStop = False
        ' 
        ' pnlBottom
        ' 
        pnlBottom.Controls.Add(btnCancel)
        pnlBottom.Controls.Add(btnPrint)
        pnlBottom.Controls.Add(lblPage)
        pnlBottom.Controls.Add(btnNext)
        pnlBottom.Controls.Add(btnPrevious)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(0, 395)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(800, 55)
        pnlBottom.TabIndex = 1
        ' 
        ' btnCancel
        ' 
        btnCancel.Location = New Point(650, 13)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(112, 34)
        btnCancel.TabIndex = 5
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnPrint
        ' 
        btnPrint.Location = New Point(500, 13)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(112, 34)
        btnPrint.TabIndex = 4
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = True
        ' 
        ' lblPage
        ' 
        lblPage.AutoSize = True
        lblPage.Location = New Point(165, 20)
        lblPage.Name = "lblPage"
        lblPage.Size = New Size(102, 25)
        lblPage.TabIndex = 2
        lblPage.Text = "Page 1 of 1"
        ' 
        ' btnNext
        ' 
        btnNext.Location = New Point(320, 13)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(112, 34)
        btnNext.TabIndex = 3
        btnNext.Text = "Next ▶"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnPrevious
        ' 
        btnPrevious.Location = New Point(20, 13)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(120, 34)
        btnPrevious.TabIndex = 2
        btnPrevious.Text = "◀ Previous"
        btnPrevious.UseVisualStyleBackColor = True
        ' 
        ' frmStickerPrintPreview
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(pnlBottom)
        Controls.Add(picPreview)
        Name = "frmStickerPrintPreview"
        StartPosition = FormStartPosition.CenterParent
        Text = "Sticker Print Preview"
        WindowState = FormWindowState.Maximized
        CType(picPreview, ComponentModel.ISupportInitialize).EndInit()
        pnlBottom.ResumeLayout(False)
        pnlBottom.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents picPreview As PictureBox
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblPage As Label
End Class
