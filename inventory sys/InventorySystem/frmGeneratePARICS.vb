Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

Public Class frmGeneratePARICS
    Inherits Form

    Private ReadOnly _inventoryIDs As List(Of Integer)
    Private ReadOnly dgv As New DataGridView()
    Private ReadOnly btnGenerate As New Button()
    Private ReadOnly btnPreview As New Button()
    Private ReadOnly btnCancel As New Button()
    Private ReadOnly lblInfo As New Label()
    Private ReadOnly _signatories As New PARICSSignatories()
    Private _finalGenerationCompleted As Boolean

    Public Sub New(inventoryIDs As IEnumerable(Of Integer))
        _inventoryIDs = inventoryIDs.Distinct().ToList()
        Text = "Generate PAR/ICS"
        StartPosition = FormStartPosition.CenterParent
        Size = New Size(1050, 620)
        MinimumSize = New Size(850, 500)
        BackColor = Color.White
        BuildUI()
        LoadPreview()
    End Sub

    Private Sub BuildUI()
        lblInfo.Text = "Review the selected property records. Documents are grouped by document type, End User, Location, and Fund Source."
        lblInfo.Dock = DockStyle.Top
        lblInfo.Height = 48
        lblInfo.Padding = New Padding(14, 12, 14, 6)
        lblInfo.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        Controls.Add(lblInfo)

        dgv.Dock = DockStyle.Fill
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.BackgroundColor = Color.White
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.RowHeadersVisible = False
        Controls.Add(dgv)

        Dim footer As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 64,
            .Padding = New Padding(12)
        }

        Dim buttonPanel As New FlowLayoutPanel With {
            .Dock = DockStyle.Right,
            .Width = 440,
            .Height = 42,
            .FlowDirection = FlowDirection.LeftToRight,
            .WrapContents = False,
            .AutoSize = False,
            .Margin = New Padding(0),
            .Padding = New Padding(0)
        }

        btnGenerate.Text = "Generate PDF"
        btnGenerate.Size = New Size(190, 38)
        btnGenerate.Margin = New Padding(0, 0, 5, 0)
        btnGenerate.BackColor = Color.FromArgb(30, 90, 150)
        btnGenerate.ForeColor = Color.White
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        AddHandler btnGenerate.Click, AddressOf Generate_Click

        btnPreview.Text = "Preview PDF"
        btnPreview.Size = New Size(120, 38)
        btnPreview.Margin = New Padding(0, 0, 5, 0)
        btnPreview.FlatStyle = FlatStyle.Flat
        btnPreview.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        btnPreview.Visible = True
        btnPreview.Enabled = True
        AddHandler btnPreview.Click, AddressOf Preview_Click

        btnCancel.Text = "Cancel"
        btnCancel.Size = New Size(100, 38)
        btnCancel.Margin = New Padding(0)
        btnCancel.FlatStyle = FlatStyle.Flat
        AddHandler btnCancel.Click, Sub() Close()

        buttonPanel.Controls.Add(btnGenerate)
        buttonPanel.Controls.Add(btnPreview)
        buttonPanel.Controls.Add(btnCancel)
        footer.Controls.Add(buttonPanel)
        Controls.Add(footer)
    End Sub

    Private Sub LoadPreview()
        Dim dt As New DataTable()
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Dim ids = String.Join(",", _inventoryIDs.Select(Function(x) x.ToString()).ToArray())
            Using da As New SQLiteDataAdapter(
                "SELECT i.ID, i.PropertyNo AS [Property Number], i.Description, i.Category AS Classification, " &
                "i.Quantity, i.UnitCost AS [Unit Cost], i.EndUser AS [End User], i.Location, i.FundSource AS [Fund Source], " &
                "CASE WHEN EXISTS (SELECT 1 FROM AccountabilityDocumentItems di WHERE di.InventoryID=i.ID) " &
                "THEN 'Already linked to a PAR/ICS' ELSE 'Eligible' END AS Eligibility " &
                "FROM InventoryDB i WHERE i.ID IN (" & ids & ") ORDER BY i.Category, i.EndUser, i.Location, i.PropertyNo", conn)
                da.Fill(dt)
            End Using
        End Using
        dgv.DataSource = dt
        If dgv.Columns.Contains("ID") Then dgv.Columns("ID").Visible = False
        If dgv.Columns.Contains("Eligibility") Then dgv.Columns("Eligibility").FillWeight = 130
        Dim eligible = dt.AsEnumerable().Count(Function(r) r("Eligibility").ToString() = "Eligible")
        lblInfo.Text = $"Selected: {dt.Rows.Count} | Eligible for new document: {eligible}. Grouping: Document Type + End User + Location + Fund Source. Existing linked items will be skipped."
    End Sub

    Private Sub Generate_Click(sender As Object, e As EventArgs)
        GenerateSelectedDocuments()
    End Sub

    Private Function GenerateSelectedDocuments() As Boolean
        Try
            Dim records As List(Of Dictionary(Of String, Object)) = LoadEligibleRecords()
            If records.Count = 0 Then
                MessageBox.Show("None of the selected items are eligible. Items already linked to accountability documents are not duplicated.", "Generate PAR/ICS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            Dim groups = records.GroupBy(Function(r) GroupKey(r)).ToList()
            Dim summary = String.Join(Environment.NewLine, groups.Select(Function(g) $"{g.Key}: {g.Count()} item(s)"))
            Dim prompt = $"This will generate {groups.Count} PDF document(s) for {records.Count} item(s):" & Environment.NewLine & Environment.NewLine & summary & Environment.NewLine & Environment.NewLine & "Continue?"
            If MessageBox.Show(prompt, "Confirm PAR/ICS PDF Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return False

            Dim outputSummary As New List(Of String)
            For Each grp In groups
                Dim items = grp.ToList()
                Dim docType = GetDocumentType(items(0))
                Dim docNo = NextDocumentNumber(docType)
                Dim issueDate = Date.Today
                Dim outputDir = Path.Combine(Application.StartupPath, If(docType = "PAR", "PAR_Forms", "ICS_Forms"))
                Directory.CreateDirectory(outputDir)
                Dim outputPath = Path.Combine(outputDir, docNo & ".pdf")
                If File.Exists(outputPath) Then Throw New IOException("The output PDF already exists: " & outputPath)

                ' Generate directly with QuestPDF. Excel is no longer launched for PAR/ICS output.
                PARICSQuestPdfGenerator.Generate(outputPath, docType, docNo, issueDate, items, _signatories)
                ' Save accountability links only after PDF export succeeds.
                SaveDocumentAndLinks(docType, docNo, issueDate, items)
                outputSummary.Add(docNo & " — " & items.Count & " item(s) — " & outputPath)
            Next

            MessageBox.Show("PDF generation completed:" & Environment.NewLine & Environment.NewLine & String.Join(Environment.NewLine, outputSummary) & Environment.NewLine & Environment.NewLine & "The final documents are saved as PDF files in PAR_Forms and ICS_Forms.", "PAR/ICS PDFs Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Visible Then
                DialogResult = DialogResult.OK
                Close()
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("PAR/ICS PDF generation could not be completed." & Environment.NewLine & ex.Message, "PDF Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Opens the document preview directly from the Property & Equipment page,
    ' without showing the intermediate record-list window.
    Public Sub OpenPreviewDirect()
        Preview_Click(Nothing, EventArgs.Empty)
    End Sub

    Private Sub Preview_Click(sender As Object, e As EventArgs)
        Try
            ' Preview only the records eligible for a new PAR/ICS, so the preview matches what can be issued.
            ' This method does not reserve document numbers or write accountability links.
            Dim records As List(Of Dictionary(Of String, Object)) = LoadEligibleRecords()
            If records.Count = 0 Then
                MessageBox.Show("None of the selected records are eligible for a new PAR/ICS. Items already linked to accountability documents are skipped.", "Preview PAR/ICS PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim groups = records.GroupBy(Function(r) GroupKey(r)).ToList()
            If groups.Count > 1 Then
                Dim answer = MessageBox.Show(
                    "The selected items form " & groups.Count.ToString() & " separate documents." & Environment.NewLine &
                    "A separate temporary PDF preview will be opened for each document." & Environment.NewLine & Environment.NewLine &
                    "Continue?", "Preview PAR/ICS PDFs", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If answer <> DialogResult.Yes Then Return
            End If

            Dim previewDir = Path.Combine(Path.GetTempPath(), "InventorySystem_PAR_ICS_Previews")
            Directory.CreateDirectory(previewDir)
            Dim typeCounters As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase)
            Dim index As Integer = 0

            For Each grp In groups
                index += 1
                Dim items = grp.ToList()
                Dim docType = GetDocumentType(items(0))
                Dim counter As Integer = 0
                If typeCounters.ContainsKey(docType) Then counter = typeCounters(docType)
                typeCounters(docType) = counter + 1

                Dim tentativeNo = GetPreviewDocumentNumber(docType, counter)
                Dim previewPath = Path.Combine(previewDir, "PREVIEW_" & tentativeNo & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") & "_" & index.ToString("00") & ".pdf")
                PARICSQuestPdfGenerator.Generate(previewPath, docType, tentativeNo, Date.Today, items, _signatories)
                Using previewForm As New frmPARICSPreview(
                    docType,
                    tentativeNo,
                    previewPath,
                    _signatories,
                    Sub(targetPath As String, updatedSignatories As PARICSSignatories)
                        PARICSQuestPdfGenerator.Generate(targetPath, docType, tentativeNo, Date.Today, items, updatedSignatories)
                    End Sub,
                    Function() As Boolean
                        Dim generated = GenerateSelectedDocuments()
                        If generated Then _finalGenerationCompleted = True
                        Return generated
                    End Function)
                    previewForm.ShowDialog()
                End Using
                If _finalGenerationCompleted Then Exit For
            Next
        Catch ex As Exception
            MessageBox.Show("PAR/ICS PDF preview could not be opened." & Environment.NewLine & ex.Message, "PDF Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetPreviewDocumentNumber(docType As String, sequenceOffset As Integer) As String
        Dim nextNo = NextDocumentNumber(docType)
        Dim parts = nextNo.Split("-"c)
        Dim n As Integer = 0
        If parts.Length >= 3 Then Integer.TryParse(parts(parts.Length - 1), n)
        Return docType & "-" & Date.Today.Year.ToString() & "-" & (n + sequenceOffset).ToString("000")
    End Function

    Private Function LoadSelectedRecords() As List(Of Dictionary(Of String, Object))
        ' Loads all selected records without modifying the database and without filtering existing links.
        ' Used for preview only; never use this method to issue documents.
        Dim result As New List(Of Dictionary(Of String, Object))
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Using tx = conn.BeginTransaction()
                For Each inventoryID In _inventoryIDs
                    Using cmd As New SQLiteCommand("SELECT i.* FROM InventoryDB i WHERE i.ID=@id", conn, tx)
                        cmd.Parameters.AddWithValue("@id", inventoryID)
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                Dim d As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
                                For i = 0 To rd.FieldCount - 1
                                    d(rd.GetName(i)) = If(rd.IsDBNull(i), Nothing, rd.GetValue(i))
                                Next
                                result.Add(d)
                            End If
                        End Using
                    End Using
                Next
                tx.Commit()
            End Using
        End Using
        Return result
    End Function

    Private Function LoadEligibleRecords() As List(Of Dictionary(Of String, Object))
        Dim result As New List(Of Dictionary(Of String, Object))
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Using tx = conn.BeginTransaction()
                For Each inventoryID In _inventoryIDs
                    Using cmd As New SQLiteCommand(
                        "SELECT i.* FROM InventoryDB i WHERE i.ID=@id AND NOT EXISTS " &
                        "(SELECT 1 FROM AccountabilityDocumentItems di WHERE di.InventoryID=i.ID)", conn, tx)
                        cmd.Parameters.AddWithValue("@id", inventoryID)
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                Dim d As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
                                For i = 0 To rd.FieldCount - 1
                                    d(rd.GetName(i)) = If(rd.IsDBNull(i), Nothing, rd.GetValue(i))
                                Next
                                result.Add(d)
                            End If
                        End Using
                    End Using
                Next
                tx.Commit()
            End Using
        End Using
        Return result
    End Function

    Private Function GetValue(r As Dictionary(Of String, Object), key As String, Optional fallback As String = "") As String
        If Not r.ContainsKey(key) OrElse r(key) Is Nothing Then Return fallback
        Return Convert.ToString(r(key)).Trim()
    End Function

    Private Function GetDocumentType(r As Dictionary(Of String, Object)) As String
        Dim category = GetValue(r, "Category")
        If category.Equals("PPE", StringComparison.OrdinalIgnoreCase) Then Return "PAR"
        If category.Equals("Semi-Expendable", StringComparison.OrdinalIgnoreCase) OrElse category.Equals("SEMI", StringComparison.OrdinalIgnoreCase) Then Return "ICS"
        Throw New InvalidOperationException("Unsupported classification for property " & GetValue(r, "PropertyNo") & ": " & category)
    End Function

    Private Function GroupKey(r As Dictionary(Of String, Object)) As String
        Return String.Join(" | ", GetDocumentType(r), GetValue(r, "EndUser", "(No End User)"), GetValue(r, "Location", "(No Location)"), GetValue(r, "FundSource", "(No Fund Source)"))
    End Function

    Private Function NextDocumentNumber(docType As String) As String
        Dim yr = Date.Today.Year
        Dim maxNo As Integer = 0
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Using cmd As New SQLiteCommand("SELECT DocumentNo FROM AccountabilityDocuments WHERE DocumentType=@type AND DocumentNo LIKE @prefix", conn)
                cmd.Parameters.AddWithValue("@type", docType)
                cmd.Parameters.AddWithValue("@prefix", docType & "-" & yr.ToString() & "-%")
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        Dim parts = rd.GetString(0).Split("-"c)
                        Dim n As Integer
                        If parts.Length >= 3 AndAlso Integer.TryParse(parts(parts.Length - 1), n) Then maxNo = Math.Max(maxNo, n)
                    End While
                End Using
            End Using
        End Using
        Return $"{docType}-{yr}-{maxNo + 1:000}"
    End Function

    Private Sub SaveDocumentAndLinks(docType As String, docNo As String, issueDate As Date, items As List(Of Dictionary(Of String, Object)))
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Using tx = conn.BeginTransaction()
                Dim docID As Long
                Using cmd As New SQLiteCommand("INSERT INTO AccountabilityDocuments (DocumentType, DocumentNo, IssueDate, LastRenewalDate, Status, Notes) VALUES (@type,@no,@date,@date,'Active','Generated from Property & Equipment')", conn, tx)
                    cmd.Parameters.AddWithValue("@type", docType)
                    cmd.Parameters.AddWithValue("@no", docNo)
                    cmd.Parameters.AddWithValue("@date", issueDate.ToString("yyyy-MM-dd"))
                    cmd.ExecuteNonQuery()
                End Using
                Using cmd As New SQLiteCommand("SELECT last_insert_rowid()", conn, tx)
                    docID = CLng(cmd.ExecuteScalar())
                End Using
                For Each item In items
                    Using cmd As New SQLiteCommand("INSERT INTO AccountabilityDocumentItems (DocumentID, InventoryID) VALUES (@doc,@inventory)", conn, tx)
                        cmd.Parameters.AddWithValue("@doc", docID)
                        cmd.Parameters.AddWithValue("@inventory", Convert.ToInt32(item("ID")))
                        cmd.ExecuteNonQuery()
                    End Using
                Next
                tx.Commit()
            End Using
        End Using
    End Sub
End Class
