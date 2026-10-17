<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBarcodeTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtPropertyNo = New TextBox()
        btnGenerateBarcode = New Button()
        picBarcode = New PictureBox()
        CType(picBarcode, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtPropertyNo
        ' 
        txtPropertyNo.Location = New Point(175, 196)
        txtPropertyNo.Name = "txtPropertyNo"
        txtPropertyNo.Size = New Size(150, 31)
        txtPropertyNo.TabIndex = 0
        txtPropertyNo.Text = "2026-01-1234"
        ' 
        ' btnGenerateBarcode
        ' 
        btnGenerateBarcode.Location = New Point(193, 233)
        btnGenerateBarcode.Name = "btnGenerateBarcode"
        btnGenerateBarcode.Size = New Size(112, 34)
        btnGenerateBarcode.TabIndex = 1
        btnGenerateBarcode.Text = "Generate Barcode"
        btnGenerateBarcode.UseVisualStyleBackColor = True
        ' 
        ' picBarcode
        ' 
        picBarcode.Location = New Point(70, 40)
        picBarcode.Name = "picBarcode"
        picBarcode.Size = New Size(443, 131)
        picBarcode.SizeMode = PictureBoxSizeMode.Zoom
        picBarcode.TabIndex = 2
        picBarcode.TabStop = False
        ' 
        ' frmBarcodeTest
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(picBarcode)
        Controls.Add(btnGenerateBarcode)
        Controls.Add(txtPropertyNo)
        Name = "frmBarcodeTest"
        Text = "frmBarcodeTest"
        CType(picBarcode, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPropertyNo As TextBox
    Friend WithEvents btnGenerateBarcode As Button
    Friend WithEvents picBarcode As PictureBox
End Class
