Public Class frmStickerFormat
    Public ReadOnly Property UseQRCode As Boolean
        Get
            Return rdoWithQR.Checked
        End Get
    End Property
    Public ReadOnly Property UseBarcode As Boolean
        Get
            Return rdoWithBarcode.Checked
        End Get
    End Property

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub
End Class