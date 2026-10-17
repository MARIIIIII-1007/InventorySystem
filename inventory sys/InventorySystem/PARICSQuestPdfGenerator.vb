Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure

''' <summary>
''' Creates the PAR and ICS forms directly as PDF, following the form layouts shown by the user.
''' No Excel automation is used.
''' </summary>
Public NotInheritable Class PARICSQuestPdfGenerator
    Private Sub New()
    End Sub

    Public Shared Sub Generate(outputPath As String,
                               docType As String,
                               docNo As String,
                               issueDate As Date,
                               items As List(Of Dictionary(Of String, Object)),
                               signatories As PARICSSignatories)
        If items Is Nothing OrElse items.Count = 0 Then
            Throw New ArgumentException("At least one inventory item is required to create a PAR/ICS PDF.", NameOf(items))
        End If

        Dim normalizedType As String = If(String.Equals(docType, "PAR", StringComparison.OrdinalIgnoreCase), "PAR", "ICS")
        Dim entityName As String = Value(items(0), "EndUser")
        Dim location As String = Value(items(0), "Location")
        If location <> "" Then
            If entityName <> "" Then
                entityName &= " (" & location & ")"
            Else
                entityName = location
            End If
        End If
        If entityName = "" Then entityName = "WMC"

        Dim fundCluster As String = Value(items(0), "FundSource", "REGULAR AGENCY FUND")
        Dim receivedName As String = If(signatories Is Nothing, "", signatories.ReceivedName)
        Dim receivedDesignation As String = If(signatories Is Nothing, "", signatories.ReceivedDesignation)
        Dim issuedName As String = If(signatories Is Nothing, "", signatories.IssuedName)
        Dim issuedDesignation As String = If(signatories Is Nothing, "", signatories.IssuedDesignation)

        Dim outputDirectory As String = Path.GetDirectoryName(Path.GetFullPath(outputPath))
        If Not Directory.Exists(outputDirectory) Then Directory.CreateDirectory(outputDirectory)

        Dim pdfDocument = Document.Create(
            Sub(container)
                container.Page(
                    Sub(page)
                        page.Size(PageSizes.A4)
                        page.MarginLeft(26)
                        page.MarginRight(26)
                        page.MarginTop(22)
                        page.MarginBottom(24)
                        page.DefaultTextStyle(Function(style) style.FontFamily("Lato").FontSize(7))

                        page.Header().Column(
                            Sub(header)
                                header.Item().AlignRight().Text(If(normalizedType = "PAR", "Appendix 71", "Exhibit 10")).FontSize(7)
                                header.Item().PaddingTop(10).AlignCenter().Text(If(normalizedType = "PAR", "PROPERTY ACKNOWLEDGMENT RECEIPT", "INVENTORY CUSTODIAN SLIP")).Bold().FontSize(11)
                                header.Item().PaddingTop(16).Row(
                                    Sub(meta)
                                        If normalizedType = "PAR" Then
                                            meta.RelativeItem(3).Column(
                                                Sub(leftMeta)
                                                    leftMeta.Item().Text("Entity Name : " & entityName)
                                                    leftMeta.Item().PaddingTop(3).Text("Fund Cluster: " & fundCluster)
                                                End Sub)
                                            meta.RelativeItem(1.5F).AlignRight().AlignBottom().Text("PAR No.: " & docNo)
                                        Else
                                            meta.RelativeItem(3).Text("Name of Department/Office : " & entityName)
                                            meta.RelativeItem(1.5F).AlignRight().AlignBottom().Text("ICS Control No.: " & docNo)
                                        End If
                                    End Sub)
                                header.Item().PaddingTop(12).LineHorizontal(0.5F).LineColor(Colors.Black)
                            End Sub)

                        page.Content().PaddingTop(7).Column(
                            Sub(content)
                                content.Item().Table(
                                    Sub(table)
                                        table.ColumnsDefinition(
                                            Sub(columns)
                                                If normalizedType = "PAR" Then
                                                    columns.RelativeColumn(0.62F)
                                                    columns.RelativeColumn(0.62F)
                                                    columns.RelativeColumn(2.05F)
                                                    columns.RelativeColumn(1.15F)
                                                    columns.RelativeColumn(1.02F)
                                                    columns.RelativeColumn(1.0F)
                                                Else
                                                    columns.RelativeColumn(0.62F)
                                                    columns.RelativeColumn(0.62F)
                                                    columns.RelativeColumn(0.92F)
                                                    columns.RelativeColumn(0.92F)
                                                    columns.RelativeColumn(2.1F)
                                                    columns.RelativeColumn(1.42F)
                                                    columns.RelativeColumn(0.92F)
                                                End If
                                            End Sub)

                                        table.Header(
                                            Sub(headerRow)
                                                If normalizedType = "PAR" Then
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Quantity")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Unit")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Description")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Property" & vbLf & "Number")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Date" & vbLf & "Acquired")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Amount")
                                                Else
                                                    HeaderCell(headerRow.Cell().RowSpan(2)).AlignCenter().AlignMiddle().Text("Quantity")
                                                    HeaderCell(headerRow.Cell().RowSpan(2)).AlignCenter().AlignMiddle().Text("Unit")
                                                    HeaderCell(headerRow.Cell().ColumnSpan(2)).AlignCenter().Text("Amount")
                                                    HeaderCell(headerRow.Cell().RowSpan(2)).AlignCenter().AlignMiddle().Text("Description")
                                                    HeaderCell(headerRow.Cell().RowSpan(2)).AlignCenter().AlignMiddle().Text("Inventory" & vbLf & "Item No.")
                                                    HeaderCell(headerRow.Cell().RowSpan(2)).AlignCenter().AlignMiddle().Text("Estimated" & vbLf & "Useful Life")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Unit Cost")
                                                    HeaderCell(headerRow.Cell()).AlignCenter().Text("Total Cost")
                                                End If
                                            End Sub)

                                        Dim totalRows As Integer = If(normalizedType = "PAR", 35, 24)
                                        Dim itemCount As Integer = items.Count
                                        For Each item In items
                                            Dim qty As Double = NumberValue(item, "Quantity", 1)
                                            Dim unitCost As Double = NumberValue(item, "UnitCost", 0)
                                            Dim amount As Double = qty * unitCost
                                            If normalizedType = "PAR" Then
                                                BodyCell(table.Cell()).AlignCenter().Text(FormatQuantity(qty))
                                                BodyCell(table.Cell()).AlignCenter().Text(Value(item, "Unit", "unit"))
                                                BodyCell(table.Cell()).Text(Value(item, "Description"))
                                                BodyCell(table.Cell()).AlignCenter().Text(Value(item, "PropertyNo"))
                                                BodyCell(table.Cell()).AlignCenter().Text(FormatDate(Value(item, "DateAcquired")))
                                                BodyCell(table.Cell()).AlignRight().Text(FormatMoney(amount))
                                            Else
                                                BodyCell(table.Cell()).AlignCenter().Text(FormatQuantity(qty))
                                                BodyCell(table.Cell()).AlignCenter().Text(Value(item, "Unit", "ea"))
                                                BodyCell(table.Cell()).AlignRight().Text(FormatMoney(unitCost))
                                                BodyCell(table.Cell()).AlignRight().Text(FormatMoney(amount))
                                                BodyCell(table.Cell()).Text(Value(item, "Description"))
                                                BodyCell(table.Cell()).AlignCenter().Text(Value(item, "PropertyNo"))
                                                BodyCell(table.Cell()).AlignCenter().Text(Value(item, "EUL", Value(item, "UsefulLife")))
                                            End If
                                        Next

                                        ' Keep the form's large blank entry area, as shown in the approved form images.
                                        Dim blankRows As Integer = Math.Max(0, totalRows - itemCount)
                                        For rowIndex As Integer = 1 To blankRows
                                            If normalizedType = "PAR" Then
                                                For colIndex As Integer = 1 To 6
                                                    BodyCell(table.Cell()).Text(" ")
                                                Next
                                            Else
                                                For colIndex As Integer = 1 To 7
                                                    BodyCell(table.Cell()).Text(" ")
                                                Next
                                            End If
                                        Next
                                    End Sub)

                                content.Item().PaddingTop(0).Row(
                                    Sub(signatureRow)
                                        If normalizedType = "PAR" Then
                                            SignatureCell(signatureRow.RelativeItem(), "Received by:", receivedName, receivedDesignation, "Signature over Printed Name of End User", True)
                                            SignatureCell(signatureRow.RelativeItem(), "Issued by:", issuedName, issuedDesignation, "Signature over Printed Name of the Accountable Officer", False)
                                        Else
                                            SignatureCell(signatureRow.RelativeItem(), "Received from:", issuedName, issuedDesignation, "Signature over Printed Name", True)
                                            SignatureCell(signatureRow.RelativeItem(), "Received by:", receivedName, receivedDesignation, "Signature over Printed Name", False)
                                        End If
                                    End Sub)
                            End Sub)

                        page.Footer().PaddingTop(5).Column(
                            Sub(footer)
                                footer.Item().LineHorizontal(0.5F).LineColor(Colors.Grey.Medium)
                                footer.Item().PaddingTop(3).AlignRight().
                                DefaultTextStyle(
                                    Function(style) style.
                                        FontSize(6).
                                        FontColor(Colors.Grey.Darken1)
                                ).Text(
                                    Sub(text)
                                        text.Span("System generated · Page ")
                                        text.CurrentPageNumber()
                                        text.Span(" of ")
                                        text.TotalPages()
                                    End Sub
                                )
                            End Sub)
                    End Sub)
            End Sub)

        pdfDocument.GeneratePdf(outputPath)
        If Not File.Exists(outputPath) OrElse New FileInfo(outputPath).Length = 0 Then
            Throw New IOException("QuestPDF did not create the PDF output file.")
        End If
    End Sub

    Private Shared Sub SignatureCell(container As IContainer,
                                     heading As String,
                                     printedName As String,
                                     designation As String,
                                     signatureCaption As String,
                                     isLeft As Boolean)
        container.Border(0.6F).Padding(4).MinHeight(96).Column(
            Sub(signature)
                signature.Item().Text(heading).Bold().FontSize(7)
                signature.Item().PaddingTop(24).AlignCenter().Text(If(printedName, "")).Bold().FontSize(7)
                signature.Item().PaddingHorizontal(16).LineHorizontal(0.5F).LineColor(Colors.Black)
                signature.Item().PaddingTop(2).AlignCenter().Text(If(String.IsNullOrWhiteSpace(designation), signatureCaption, designation)).FontSize(6)
                signature.Item().PaddingTop(10).PaddingHorizontal(24).LineHorizontal(0.5F).LineColor(Colors.Black)
                signature.Item().AlignCenter().Text("Date").FontSize(6)
            End Sub)
    End Sub

    Private Shared Function HeaderCell(container As IContainer) As IContainer
        Return container.Border(0.55F).BorderColor(Colors.Black).Padding(2).MinHeight(22).AlignMiddle().DefaultTextStyle(Function(style) style.Bold().FontSize(6.5F))
    End Function

    Private Shared Function BodyCell(container As IContainer) As IContainer
        Return container.Border(0.5F).BorderColor(Colors.Black).Padding(1.5F).MinHeight(9).AlignMiddle().DefaultTextStyle(Function(style) style.FontSize(6.2F))
    End Function

    Private Shared Function Value(item As Dictionary(Of String, Object), key As String, Optional fallback As String = "") As String
        If item Is Nothing OrElse Not item.ContainsKey(key) OrElse item(key) Is Nothing Then Return fallback
        Dim result As String = Convert.ToString(item(key), CultureInfo.CurrentCulture).Trim()
        If result = "" Then Return fallback
        Return result
    End Function

    Private Shared Function NumberValue(item As Dictionary(Of String, Object), key As String, fallback As Double) As Double
        Dim raw As String = Value(item, key)
        Dim result As Double
        If Double.TryParse(raw, NumberStyles.Any, CultureInfo.CurrentCulture, result) Then Return result
        If Double.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, result) Then Return result
        Return fallback
    End Function

    Private Shared Function FormatQuantity(value As Double) As String
        Return value.ToString("0.##", CultureInfo.InvariantCulture)
    End Function

    Private Shared Function FormatMoney(value As Double) As String
        Return "₱" & value.ToString("#,##0.00", CultureInfo.InvariantCulture)
    End Function

    Private Shared Function FormatDate(value As String) As String
        Dim parsed As Date
        If Date.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, parsed) Then
            Return parsed.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
        End If
        Return value
    End Function
End Class
