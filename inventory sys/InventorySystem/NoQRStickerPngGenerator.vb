Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class NoQRStickerPngGenerator

    Public Shared Sub GenerateNoQRStickerPNG(
        unitOffice As String,
        inventoryNo As String,
        dateAcquired As String,
        inventoryDate As String,
        openImage As Boolean)

        ' Sticker dimensions
        Dim width As Integer = 890
        Dim height As Integer = 330

        Dim safeInventoryNo As String =
            String.Join("_", inventoryNo.Split(IO.Path.GetInvalidFileNameChars()))

        Dim filePath As String =
            IO.Path.Combine(
                Application.StartupPath,
                "Sticker_NoQR_" & safeInventoryNo & ".png")

        Dim bmp As New Bitmap(width, height)
        bmp.SetResolution(300, 300)

        Dim g As Graphics = Graphics.FromImage(bmp)

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

        '========================
        ' STICKER FRAME
        '========================

        Dim blue As Color = Color.FromArgb(21, 80, 207)

        ' Blue background
        g.Clear(blue)

        ' Outer border
        Dim borderPen As New Pen(Color.Black, 4)

        g.DrawRectangle(
            borderPen,
            2,
            2,
            886,
            326)

        borderPen.Dispose()

        '========================
        ' HEADER
        '========================

        Dim headerFont As New Font("Arial", 13, FontStyle.Bold)
        Dim smallHeaderFont As New Font("Arial", 6, FontStyle.Bold)
        Dim whiteBrush As New SolidBrush(Color.White)

        ' RP
        g.DrawString(
    "RP",
    headerFont,
    whiteBrush,
    25,
    10)

        ' GOVERNMENT
        Dim centerFormat As New StringFormat()
        centerFormat.Alignment = StringAlignment.Center

        g.DrawString(
            "GOVERNMENT",
            smallHeaderFont,
            whiteBrush,
            New RectangleF(295, 12, 300, 24),
            centerFormat)

        ' PROPERTY
        g.DrawString(
            "PROPERTY",
            smallHeaderFont,
            whiteBrush,
            New RectangleF(295, 42, 300, 26),
            centerFormat)

        ' AFP
        Dim afpText As String = "AFP"
        Dim afpSize As SizeF = g.MeasureString(afpText, headerFont)

        g.DrawString(
            afpText,
            headerFont,
            whiteBrush,
            880 - afpSize.Width - 8,
            10)

        '========================
        ' LABELS
        '========================

        Dim labelFont As New Font("Arial", 6, FontStyle.Regular)

        g.DrawString(
            "UNIT/OFFICE",
            labelFont,
            whiteBrush,
            25,
            110)

        g.DrawString(
            "INVENTORY NR",
            labelFont,
            whiteBrush,
            25,
            150)

        g.DrawString(
            "DATE ACQUIRED",
            labelFont,
            whiteBrush,
            25,
            190)

        g.DrawString(
            "INVENTORY DATE",
            labelFont,
            whiteBrush,
            25,
            230)

        '========================
        ' VALUE BOXES
        '========================

        Dim whiteBoxBrush As New SolidBrush(Color.White)

        ' UNIT/OFFICE
        g.FillRectangle(
            whiteBoxBrush,
            255,
            108,
            615,
            28)

        ' INVENTORY NR
        g.FillRectangle(
            whiteBoxBrush,
            255,
            148,
            615,
            28)

        ' DATE ACQUIRED
        g.FillRectangle(
            whiteBoxBrush,
            255,
            188,
            615,
            28)

        ' INVENTORY DATE
        g.FillRectangle(
            whiteBoxBrush,
            255,
            228,
            615,
            28)

        whiteBoxBrush.Dispose()

        '========================
        ' INVENTORY VALUES
        '========================

        Dim valueFont As New Font("Arial", 6, FontStyle.Regular)
        Dim blackBrush As New SolidBrush(Color.Black)

        g.DrawString(
            unitOffice,
            valueFont,
            blackBrush,
            255,
            110)

        g.DrawString(
            inventoryNo,
            valueFont,
            blackBrush,
            255,
            150)

        g.DrawString(
            dateAcquired,
            valueFont,
            blackBrush,
            255,
            190)

        g.DrawString(
            inventoryDate,
            valueFont,
            blackBrush,
            255,
            230)

        blackBrush.Dispose()
        valueFont.Dispose()

        '========================
        ' FOOTER
        '========================

        Dim footerFont As New Font("Arial", 4, FontStyle.Regular)

        g.DrawString(
            "(TAMPERING OF THIS STICKER IS PUNISHABLE BY AFP REG.)",
            footerFont,
            whiteBrush,
            New RectangleF(0, 285, 890, 25),
            centerFormat)

        footerFont.Dispose()

        centerFormat.Dispose()
        whiteBrush.Dispose()
        labelFont.Dispose()
        headerFont.Dispose()
        smallHeaderFont.Dispose()

        g.Dispose()

        bmp.Save(
            filePath,
            Imaging.ImageFormat.Png)

        bmp.Dispose()

        If openImage Then

            Process.Start(
                New ProcessStartInfo(filePath) With {
                    .UseShellExecute = True
                })

        End If

    End Sub

End Class