
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO

Public Class BarcodeStickerPngGenerator

    Public Shared Sub GenerateBarcodeStickerPNG(
        unitOffice As String,
        inventoryNo As String,
        dateAcquired As String,
        inventoryDate As String,
        barcodePath As String,
        openImage As Boolean)

        If String.IsNullOrWhiteSpace(barcodePath) OrElse
           Not File.Exists(barcodePath) Then

            Throw New FileNotFoundException(
                "Barcode image was not found.",
                barcodePath)
        End If

        Dim width As Integer = 890
        Dim height As Integer = 330

        Dim safeInventoryNo As String =
            String.Join("_",
                inventoryNo.Split(
                    Path.GetInvalidFileNameChars()))

        Dim filePath As String =
            Path.Combine(
                Application.StartupPath,
                "Sticker_Barcode_" & safeInventoryNo & ".png")

        Using bmp As New Bitmap(width, height)

            bmp.SetResolution(300, 300)

            Using g As Graphics = Graphics.FromImage(bmp)

                g.SmoothingMode = SmoothingMode.AntiAlias
                g.InterpolationMode =
                    InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.TextRenderingHint =
                    TextRenderingHint.AntiAliasGridFit

                Dim blue As Color =
                    Color.FromArgb(21, 80, 207)

                ' WHITE BACKGROUND
                g.Clear(Color.White)

                ' BLUE INFORMATION AREA
                Using blueBrush As New SolidBrush(blue)
                    g.FillRectangle(
                        blueBrush,
                        305,
                        0,
                        585,
                        330)
                End Using

                ' OUTER BORDER
                Using borderPen As New Pen(Color.Black, 4)
                    g.DrawRectangle(
                        borderPen,
                        2,
                        2,
                        886,
                        326)
                End Using

                ' VERTICAL DIVIDER
                Using dividerPen As New Pen(Color.Black, 3)
                    g.DrawLine(
                        dividerPen,
                        305,
                        2,
                        305,
                        326)
                End Using

                ' BARCODE
                Using barcodeImage As Image =
                    Image.FromFile(barcodePath)

                    ' Fit the barcode inside the existing left area.
                    ' Preserve its proportions for readability.
                    Dim codeArea As New Rectangle(
                        25,
                        25,
                        255,
                        255)

                    Dim scale As Double =
                        Math.Min(
                            CDbl(codeArea.Width) / barcodeImage.Width,
                            CDbl(codeArea.Height) / barcodeImage.Height)

                    Dim drawWidth As Integer =
                        CInt(barcodeImage.Width * scale)

                    Dim drawHeight As Integer =
                        CInt(barcodeImage.Height * scale)

                    Dim drawX As Integer =
                        codeArea.X +
                        (codeArea.Width - drawWidth) \ 2

                    Dim drawY As Integer =
                        codeArea.Y +
                        (codeArea.Height - drawHeight) \ 2

                    g.DrawImage(
                        barcodeImage,
                        New Rectangle(
                            drawX,
                            drawY,
                            drawWidth,
                            drawHeight))
                End Using

                ' HEADER
                Using headerFont As New Font(
                    "Arial", 13, FontStyle.Bold),
                      smallHeaderFont As New Font(
                    "Arial", 6, FontStyle.Bold),
                      whiteBrush As New SolidBrush(Color.White),
                      centerFormat As New StringFormat()

                    centerFormat.Alignment =
                        StringAlignment.Center

                    g.DrawString(
                        "RP",
                        headerFont,
                        whiteBrush,
                        330,
                        10)

                    g.DrawString(
                        "GOVERNMENT",
                        smallHeaderFont,
                        whiteBrush,
                        New RectangleF(450, 12, 300, 24),
                        centerFormat)

                    g.DrawString(
                        "PROPERTY",
                        smallHeaderFont,
                        whiteBrush,
                        New RectangleF(450, 42, 300, 26),
                        centerFormat)

                    Dim afpText As String = "AFP"

                    Dim afpSize As SizeF =
                        g.MeasureString(afpText, headerFont)

                    g.DrawString(
                        afpText,
                        headerFont,
                        whiteBrush,
                        880 - afpSize.Width - 8,
                        10)

                    ' LABELS
                    Using labelFont As New Font(
                        "Arial", 6, FontStyle.Regular)

                        g.DrawString(
                            "UNIT/OFFICE",
                            labelFont,
                            whiteBrush,
                            320,
                            110)

                        g.DrawString(
                            "INVENTORY NR",
                            labelFont,
                            whiteBrush,
                            320,
                            150)

                        g.DrawString(
                            "DATE ACQUIRED",
                            labelFont,
                            whiteBrush,
                            320,
                            190)

                        g.DrawString(
                            "INVENTORY DATE",
                            labelFont,
                            whiteBrush,
                            320,
                            230)

                    End Using

                    ' FOUR WHITE VALUE BOXES
                    Using whiteBoxBrush As New SolidBrush(Color.White)

                        g.FillRectangle(
                            whiteBoxBrush,
                            550, 108, 320, 28)

                        g.FillRectangle(
                            whiteBoxBrush,
                            550, 148, 320, 28)

                        g.FillRectangle(
                            whiteBoxBrush,
                            550, 188, 320, 28)

                        g.FillRectangle(
                            whiteBoxBrush,
                            550, 228, 320, 28)

                    End Using

                    ' VALUE TEXT
                    Using valueFont As New Font(
                        "Arial", 6, FontStyle.Regular),
                          blackBrush As New SolidBrush(Color.Black)

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

                    End Using

                    ' FOOTER
                    Using footerFont As New Font(
                        "Arial", 4, FontStyle.Regular)

                        g.DrawString(
                            "(TAMPERING OF THIS STICKER IS PUNISHABLE BY AFP REG.)",
                            footerFont,
                            whiteBrush,
                            New RectangleF(305, 285, 600, 25),
                            centerFormat)

                    End Using

                End Using

            End Using

            bmp.Save(filePath, Imaging.ImageFormat.Png)

        End Using

        If openImage Then
            Process.Start(
                New ProcessStartInfo(filePath) With {
                    .UseShellExecute = True
                })
        End If

    End Sub

End Class
