
Imports ZXing
Imports ZXing.Common
Imports ZXing.Windows.Compatibility
Imports System.Drawing

Public Class frmBarcodeTest

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnGenerateBarcode_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGenerateBarcode.Click

        Dim propertyNo As String = txtPropertyNo.Text.Trim()

        If propertyNo = "" Then
            MessageBox.Show("Please enter a Property Number.")
            Return
        End If

        Try
            Dim writer As New BarcodeWriter()
            writer.Format = BarcodeFormat.CODE_128
            writer.Options = New EncodingOptions With {
                .Width = 600,
                .Height = 160,
                .Margin = 10
            }

            Dim barcodeBitmap As Bitmap = writer.Write(propertyNo)

            If picBarcode.Image IsNot Nothing Then
                picBarcode.Image.Dispose()
            End If

            picBarcode.Image = barcodeBitmap
            picBarcode.SizeMode = PictureBoxSizeMode.Zoom

        Catch ex As Exception
            MessageBox.Show(
                "Unable to generate barcode: " & ex.Message,
                "Barcode Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub

End Class
