Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO

Public Class StickerSheetGenerator

    Public Shared Function CreateA4Sheet(
        stickerFiles As List(Of String)
    ) As String

        ' A4 at 300 DPI
        Dim pageWidth As Integer = 2480
        Dim pageHeight As Integer = 3508

        '========================
        ' PAGE MARGINS & SPACING
        '========================

        Dim margin As Integer = 100
        Dim spacing As Integer = 30

        Dim availableWidth As Integer =
    pageWidth - (margin * 2)

        Dim availableHeight As Integer =
    pageHeight - (margin * 2)

        ' Nothing to arrange
        If stickerFiles Is Nothing OrElse stickerFiles.Count = 0 Then
            Return String.Empty
        End If

        '========================
        ' READ STICKER SIZE
        '========================

        Dim firstStickerSize As Size

        Using firstImage As Image = Image.FromFile(stickerFiles(0))

            firstStickerSize = firstImage.Size

        End Using

        Dim stickerRatio As Double =
    CDbl(firstStickerSize.Width) /
    CDbl(firstStickerSize.Height)

        '========================
        ' FIND BEST GRID
        '========================

        Dim bestColumns As Integer = 1
        Dim bestRows As Integer = 1
        Dim bestStickerWidth As Integer = 0

        For columns As Integer = 1 To stickerFiles.Count

            Dim rows As Integer =
                CInt(Math.Ceiling(
                    CDbl(stickerFiles.Count) /
                    CDbl(columns)))

            Dim totalSpacingWidth As Integer =
                spacing * (columns - 1)

            Dim totalSpacingHeight As Integer =
                spacing * (rows - 1)

            Dim cellWidth As Double =
                CDbl(availableWidth - totalSpacingWidth) /
                CDbl(columns)

            Dim cellHeight As Double =
                CDbl(availableHeight - totalSpacingHeight) /
                CDbl(rows)

            Dim stickerWidth As Double =
                Math.Min(
                    cellWidth,
                    cellHeight * stickerRatio)

            If stickerWidth > bestStickerWidth Then

                bestStickerWidth = CInt(stickerWidth)
                bestColumns = columns
                bestRows = rows

            End If

        Next

        '========================
        ' CREATE A4 SHEET
        '========================

        Dim sheet As New Bitmap(
            pageWidth,
            pageHeight)

        sheet.SetResolution(300, 300)

        Using g As Graphics = Graphics.FromImage(sheet)

            g.Clear(Color.White)

            g.SmoothingMode = SmoothingMode.HighQuality
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.PixelOffsetMode = PixelOffsetMode.HighQuality

            Dim stickerWidth As Integer =
                CInt(bestStickerWidth * 0.4)

            Dim stickerHeight As Integer =
                 CInt(stickerWidth / stickerRatio)

            Dim totalWidth As Integer =
                (bestColumns * stickerWidth) +
                ((bestColumns - 1) * spacing)

            Dim totalHeight As Integer =
                (bestRows * stickerHeight) +
                ((bestRows - 1) * spacing)

            Dim startX As Integer =
                margin + ((availableWidth - totalWidth) \ 2)

            Dim startY As Integer =
                margin + ((availableHeight - totalHeight) \ 2)

            For i As Integer = 0 To stickerFiles.Count - 1

                Using stickerImage As Image =
                    Image.FromFile(stickerFiles(i))

                    Dim column As Integer =
                       i Mod bestColumns

                    Dim row As Integer =
                       i \ bestColumns

                    Dim x As Integer =
                        startX +
                        (column * (stickerWidth + spacing))

                    Dim y As Integer =
                        startY +
                        (row * (stickerHeight + spacing))

                    g.DrawImage(
                        stickerImage,
                        New Rectangle(
                            x,
                            y,
                            stickerWidth,
                            stickerHeight))

                End Using

            Next

        End Using

        Dim outputFolder As String =
            Path.Combine(Application.StartupPath, "Sticker Sheets")

        If Not Directory.Exists(outputFolder) Then
            Directory.CreateDirectory(outputFolder)
        End If

        Dim filePath As String =
            Path.Combine(
                outputFolder,
                "Sticker_Sheet_" &
                DateTime.Now.ToString("yyyyMMdd_HHmmss") &
                ".png")

        sheet.Save(
            filePath,
            ImageFormat.Png)

        sheet.Dispose()

        Return filePath

    End Function

    Public Shared Function CreateA4Sheets(
    stickerFiles As List(Of String)
) As List(Of String)

        Dim sheetPaths As New List(Of String)

        If stickerFiles Is Nothing OrElse stickerFiles.Count = 0 Then
            Return sheetPaths
        End If

        '========================
        ' A4 AT 300 DPI
        '========================

        Dim pageWidth As Integer = 2480
        Dim pageHeight As Integer = 3508

        Dim margin As Integer = 100
        Dim spacing As Integer = 30

        Dim availableWidth As Integer =
            pageWidth - (margin * 2)

        Dim availableHeight As Integer =
            pageHeight - (margin * 2)

        '========================
        ' READ STICKER SIZE
        '========================

        Dim firstStickerSize As Size

        Using firstImage As Image = Image.FromFile(stickerFiles(0))
            firstStickerSize = firstImage.Size
        End Using

        Dim stickerRatio As Double =
            CDbl(firstStickerSize.Width) /
            CDbl(firstStickerSize.Height)

        '========================
        ' FIND AUTOMATIC GRID
        '========================

        Dim bestColumns As Integer = 1
        Dim bestRows As Integer = 1
        Dim bestStickerWidth As Integer = 0

        ' Use the same automatic calculation
        ' as the current working A4 sheet.

        For columns As Integer = 1 To 10

            Dim rows As Integer =
                CInt(Math.Ceiling(
                    CDbl(stickerFiles.Count) /
                    CDbl(columns)))

            Dim totalSpacingWidth As Integer =
                spacing * (columns - 1)

            Dim totalSpacingHeight As Integer =
                spacing * (rows - 1)

            Dim cellWidth As Double =
                CDbl(availableWidth - totalSpacingWidth) /
                CDbl(columns)

            Dim cellHeight As Double =
                CDbl(availableHeight - totalSpacingHeight) /
                CDbl(rows)

            Dim stickerWidth As Double =
                Math.Min(
                    cellWidth,
                    cellHeight * stickerRatio)

            If stickerWidth > bestStickerWidth Then

                bestStickerWidth = CInt(stickerWidth)
                bestColumns = columns
                bestRows = rows

            End If

        Next

        '========================
        ' APPLY CURRENT 40% SIZE
        '========================

        Dim stickerWidthFinal As Integer =
            CInt(bestStickerWidth * 0.4)

        Dim stickerHeightFinal As Integer =
            CInt(stickerWidthFinal / stickerRatio)

        '========================
        ' CALCULATE HOW MANY
        ' FIT ON ONE A4
        '========================

        Dim columnsFinal As Integer =
            Math.Max(
                1,
                CInt(Math.Floor(
                    CDbl(availableWidth + spacing) /
                    CDbl(stickerWidthFinal + spacing))))

        Dim rowsFinal As Integer =
            Math.Max(
                1,
                CInt(Math.Floor(
                    CDbl(availableHeight + spacing) /
                    CDbl(stickerHeightFinal + spacing))))

        Dim stickersPerSheet As Integer =
            columnsFinal * rowsFinal

        '========================
        ' CREATE MULTIPLE SHEETS
        '========================

        Dim currentIndex As Integer = 0
        Dim sheetNumber As Integer = 1

        While currentIndex < stickerFiles.Count

            Dim sheet As New Bitmap(
                pageWidth,
                pageHeight)

            sheet.SetResolution(300, 300)

            Using g As Graphics = Graphics.FromImage(sheet)

                g.Clear(Color.White)

                g.SmoothingMode =
                    SmoothingMode.HighQuality

                g.InterpolationMode =
                    InterpolationMode.HighQualityBicubic

                g.PixelOffsetMode =
                    PixelOffsetMode.HighQuality

                Dim itemsOnThisSheet As Integer =
                    Math.Min(
                        stickersPerSheet,
                        stickerFiles.Count - currentIndex)

                Dim totalWidth As Integer =
                    (columnsFinal * stickerWidthFinal) +
                    ((columnsFinal - 1) * spacing)

                Dim totalHeight As Integer =
                    (rowsFinal * stickerHeightFinal) +
                    ((rowsFinal - 1) * spacing)

                Dim startX As Integer =
                    margin +
                    ((availableWidth - totalWidth) \ 2)

                Dim startY As Integer =
                    margin +
                    ((availableHeight - totalHeight) \ 2)

                For i As Integer = 0 To itemsOnThisSheet - 1

                    Using stickerImage As Image =
                        Image.FromFile(
                            stickerFiles(currentIndex + i))

                        Dim column As Integer =
                            i Mod columnsFinal

                        Dim row As Integer =
                            i \ columnsFinal

                        Dim x As Integer =
                            startX +
                            (column *
                            (stickerWidthFinal + spacing))

                        Dim y As Integer =
                            startY +
                            (row *
                            (stickerHeightFinal + spacing))

                        g.DrawImage(
                            stickerImage,
                            New Rectangle(
                                x,
                                y,
                                stickerWidthFinal,
                                stickerHeightFinal))

                    End Using

                Next

            End Using

            Dim outputFolder As String =
                Path.Combine(
                    Application.StartupPath,
                    "Sticker Sheets")

            If Not Directory.Exists(outputFolder) Then
                Directory.CreateDirectory(outputFolder)
            End If

            Dim filePath As String =
                Path.Combine(
                    outputFolder,
                    "Sticker_Sheet_" &
                    DateTime.Now.ToString(
                        "yyyyMMdd_HHmmss") &
                    "_" &
                    sheetNumber.ToString() &
                    ".png")

            sheet.Save(
                filePath,
                ImageFormat.Png)

            sheet.Dispose()

            sheetPaths.Add(filePath)

            currentIndex +=
                Math.Min(
                    stickersPerSheet,
                    stickerFiles.Count - currentIndex)

            sheetNumber += 1

        End While

        Return sheetPaths

    End Function

End Class