Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class StickerPngGenerator

    Public Shared Sub GenerateQRStickerPNG(
    unitOffice As String,
    inventoryNo As String,
    dateAcquired As String,
    inventoryDate As String,
    qrCodePath As String,
    openImage As Boolean)

        Dim width As Integer = 890
        Dim height As Integer = 330

        Dim safeInventoryNo As String =
            String.Join("_", inventoryNo.Split(IO.Path.GetInvalidFileNameChars()))

        Dim filePath As String =
            IO.Path.Combine(
                Application.StartupPath,
                "Sticker_QR_" & safeInventoryNo & ".png")

        Dim bmp As New Bitmap(width, height)
        bmp.SetResolution(300, 300)

        Dim g As Graphics = Graphics.FromImage(bmp)

        Dim qrImage As Image = Nothing

        If Not String.IsNullOrWhiteSpace(qrCodePath) AndAlso IO.File.Exists(qrCodePath) Then
            qrImage = Image.FromFile(qrCodePath)
        End If

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

        '========================
        ' STICKER FRAME
        '========================

        Dim blue As Color = Color.FromArgb(21, 80, 207)

        ' White background
        g.Clear(Color.White)

        ' Blue information area
        Dim blueBrush As New SolidBrush(blue)

        g.FillRectangle(
            blueBrush,
            305,
            0,
            585,
            330)

        blueBrush.Dispose()

        ' Outer border
        Dim borderPen As New Pen(Color.Black, 4)

        g.DrawRectangle(
            borderPen,
            2,
            2,
            886,
            326)

        borderPen.Dispose()

        ' Vertical divider
        Dim dividerPen As New Pen(Color.Black, 3)

        g.DrawLine(
            dividerPen,
            305,
            2,
            305,
            326)

        dividerPen.Dispose()

        '========================
        ' QR CODE
        '========================

        If qrImage IsNot Nothing Then

            g.DrawImage(
        qrImage,
        New Rectangle(
            25,
            25,
            255,
            255))

        End If

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
            330,
            10)

        ' GOVERNMENT
        Dim centerFormat As New StringFormat()
        centerFormat.Alignment = StringAlignment.Center

        g.DrawString(
            "GOVERNMENT",
            smallHeaderFont,
            whiteBrush,
            New RectangleF(450, 12, 300, 24),
            centerFormat)

        ' PROPERTY
        g.DrawString(
            "PROPERTY",
            smallHeaderFont,
            whiteBrush,
            New RectangleF(450, 42, 300, 26),
            centerFormat)

        ' AFP - calculate its position from the right edge
        Dim afpText As String = "AFP"
        Dim afpSize As SizeF = g.MeasureString(afpText, headerFont)

        g.DrawString(
            afpText,
            headerFont,
            whiteBrush,
            880 - afpSize.Width - 8,
            10)

        ' UNIT/OFFICE
        Dim labelFont As New Font("Arial", 6, FontStyle.Regular)

        g.DrawString(
            "UNIT/OFFICE",
            labelFont,
            whiteBrush,
            320,
            110)

        ' INVENTORY NR
        g.DrawString(
            "INVENTORY NR",
            labelFont,
            whiteBrush,
            320,
            150)

        ' DATE ACQUIRED
        g.DrawString(
            "DATE ACQUIRED",
            labelFont,
            whiteBrush,
            320,
            190)

        ' INVENTORY DATE
        g.DrawString(
            "INVENTORY DATE",
            labelFont,
            whiteBrush,
            320,
            230)

        ' UNIT/OFFICE VALUE BOX
        Dim whiteBoxBrush As New SolidBrush(Color.White)

        g.FillRectangle(
            whiteBoxBrush,
            550,
            108,
            320,
            28)

        whiteBoxBrush.Dispose()

        Dim whiteBoxPen As New Pen(Color.White, 2)

        g.DrawRectangle(
            whiteBoxPen,
            550,
            108,
            320,
            28)

        whiteBoxPen.Dispose()

        ' INVENTORY NR VALUE BOX
        Dim whiteBoxBrush2 As New SolidBrush(Color.White)

        g.FillRectangle(
            whiteBoxBrush2,
            550,
            148,
            320,
            28)

        whiteBoxBrush2.Dispose()


        ' DATE ACQUIRED VALUE BOX
        Dim whiteBoxBrush3 As New SolidBrush(Color.White)

        g.FillRectangle(
            whiteBoxBrush3,
            550,
            188,
            320,
            28)

        whiteBoxBrush3.Dispose()


        ' INVENTORY DATE VALUE BOX
        Dim whiteBoxBrush4 As New SolidBrush(Color.White)

        g.FillRectangle(
            whiteBoxBrush4,
            550,
            228,
            320,
            28)

        whiteBoxBrush4.Dispose()

        '========================
        ' SAMPLE STICKER DATA
        '========================

        Dim valueFont As New Font("Arial", 6, FontStyle.Regular)
        Dim blackBrush As New SolidBrush(Color.Black)

        g.DrawString(
            unitOffice,
            valueFont,
            blackBrush,
            550,
            110)

        g.DrawString(
            inventoryNo,
            valueFont,
            blackBrush,
            550,
            150)

        g.DrawString(
            dateAcquired,
            valueFont,
            blackBrush,
            550,
            190)

        g.DrawString(
            inventoryDate,
            valueFont,
            blackBrush,
            550,
            230)

        blackBrush.Dispose()
        valueFont.Dispose()

        ' FOOTER
        Dim footerFont As New Font("Arial", 4, FontStyle.Regular)

        g.DrawString(
            "(TAMPERING OF THIS STICKER IS PUNISHABLE BY AFP REG.)",
            footerFont,
            whiteBrush,
            New RectangleF(305, 285, 600, 25),
            centerFormat)

        footerFont.Dispose()

        centerFormat.Dispose()
        whiteBrush.Dispose()
        smallHeaderFont.Dispose()
        headerFont.Dispose()

        ' Dispose graphics
        g.Dispose()

        ' Save PNG
        bmp.Save(
            filePath,
            Imaging.ImageFormat.Png)

        bmp.Dispose()

        ' Open PNG
        If openImage Then

            Process.Start(
                New ProcessStartInfo(filePath) With {
                    .UseShellExecute = True
                })

        End If

    End Sub


End Class