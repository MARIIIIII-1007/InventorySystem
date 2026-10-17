Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Threading
Imports Microsoft.Web.WebView2.WinForms

Public Class frmPARICSPreview
    Inherits Form

    Private ReadOnly _docType As String
    Private ReadOnly _docNo As String
    Private _previewPath As String
    Private ReadOnly _signatories As PARICSSignatories
    Private ReadOnly _refreshPdf As Action(Of String, PARICSSignatories)
    Private ReadOnly _generateFinal As Func(Of Boolean)

    Private ReadOnly txtReceivedName As New TextBox()
    Private ReadOnly txtReceivedDesignation As New TextBox()
    Private ReadOnly txtIssuedName As New TextBox()
    Private ReadOnly txtIssuedDesignation As New TextBox()
    Private ReadOnly lblDoc As New Label()
    Private ReadOnly browser As New WebView2()
    Private ReadOnly btnRefresh As New Button()
    Private ReadOnly btnPrint As New Button()
    Private ReadOnly btnGenerate As New Button()
    Private ReadOnly btnClose As New Button()
    Private ReadOnly lblPreviewStatus As New Label()
    Private _browserReady As Boolean
    Private _refreshInProgress As Boolean

    Public Sub New(docType As String,
                   docNo As String,
                   previewPath As String,
                   signatories As PARICSSignatories,
                   refreshPdf As Action(Of String, PARICSSignatories),
                   generateFinal As Func(Of Boolean))
        _docType = docType
        _docNo = docNo
        _previewPath = previewPath
        _signatories = signatories
        _refreshPdf = refreshPdf
        _generateFinal = generateFinal

        Text = "Generate PAR / ICS"
        StartPosition = FormStartPosition.CenterParent
        Size = New Size(1320, 820)
        MinimumSize = New Size(1050, 650)
        BackColor = Color.FromArgb(244, 247, 251)
        Font = New Font("Segoe UI", 9.0F)
        BuildUI()
        PopulateFields()
        AddHandler Shown, AddressOf PreviewForm_Shown
        AddHandler FormClosing, Sub(sender As Object, e As FormClosingEventArgs) ApplyFieldsToSignatories()
    End Sub

    Private Sub BuildUI()
        Dim header As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 66,
            .BackColor = Color.White,
            .Padding = New Padding(20, 10, 18, 8)
        }
        Dim title As New Label With {
            .Text = "Generate PAR / ICS",
            .Font = New Font("Segoe UI", 15.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(18, 8),
            .ForeColor = Color.FromArgb(23, 32, 51)
        }
        Dim subtitle As New Label With {
            .Text = "Review the document and edit signatories before generating the final PDF.",
            .Font = New Font("Segoe UI", 9.0F),
            .AutoSize = True,
            .Location = New Point(20, 36),
            .ForeColor = Color.FromArgb(100, 116, 139)
        }
        header.Controls.Add(title)
        header.Controls.Add(subtitle)
        Controls.Add(header)

        Dim footer As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 58,
            .BackColor = Color.White,
            .Padding = New Padding(12, 8, 16, 8)
        }
        Dim footerButtons As New FlowLayoutPanel With {
            .Dock = DockStyle.Right,
            .Width = 490,
            .FlowDirection = FlowDirection.LeftToRight,
            .WrapContents = False,
            .Padding = New Padding(0),
            .Margin = New Padding(0)
        }
        btnPrint.Text = "Print"
        btnPrint.Size = New Size(100, 36)
        btnPrint.FlatStyle = FlatStyle.Flat
        AddHandler btnPrint.Click, AddressOf Print_Click
        btnGenerate.Text = "Generate PDF"
        btnGenerate.Size = New Size(130, 36)
        btnGenerate.BackColor = Color.FromArgb(79, 70, 229)
        btnGenerate.ForeColor = Color.White
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        AddHandler btnGenerate.Click, AddressOf GenerateFinal_Click

        btnClose.Text = "Close Preview"
        btnClose.Size = New Size(130, 36)
        btnClose.FlatStyle = FlatStyle.Flat
        AddHandler btnClose.Click, Sub() Close()
        footerButtons.Controls.Add(btnPrint)
        footerButtons.Controls.Add(btnGenerate)
        footerButtons.Controls.Add(btnClose)
        footer.Controls.Add(footerButtons)
        Controls.Add(footer)

        Dim split As New SplitContainer With {
            .Dock = DockStyle.Fill,
            .Orientation = Orientation.Vertical,
            .FixedPanel = FixedPanel.Panel1,
            .BackColor = Color.FromArgb(226, 232, 240)
        }
        AddHandler Shown, Sub(sender As Object, e As EventArgs)
                              If split.Width > 850 Then split.SplitterDistance = 340
                          End Sub
        Controls.Add(split)
        split.BringToFront()
        header.BringToFront()
        footer.BringToFront()

        Dim left As New Panel With {.Dock = DockStyle.Fill, .BackColor = Color.White, .Padding = New Padding(18), .AutoScroll = True}
        split.Panel1.Controls.Add(left)

        Dim detailsTitle As New Label With {
            .Text = "01   Document Details",
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(4, 4)
        }
        left.Controls.Add(detailsTitle)
        Dim typeLabel As New Label With {.Text = "Document type", .AutoSize = True, .Location = New Point(4, 42), .ForeColor = Color.FromArgb(71, 85, 105)}
        left.Controls.Add(typeLabel)
        Dim typeValue As New Label With {
            .Text = If(_docType = "PAR", "PAR — Property Acknowledgment Receipt", "ICS — Inventory Custodian Slip"),
            .AutoSize = False,
            .Height = 42,
            .Width = 275,
            .Location = New Point(4, 62),
            .Padding = New Padding(8),
            .BackColor = Color.FromArgb(248, 250, 252),
            .BorderStyle = BorderStyle.FixedSingle
        }
        left.Controls.Add(typeValue)
        lblDoc.Text = "GENERATED DOCUMENT" & Environment.NewLine & _docType & " · " & _docNo
        lblDoc.Location = New Point(4, 114)
        lblDoc.Size = New Size(275, 60)
        lblDoc.Padding = New Padding(10)
        lblDoc.BackColor = Color.FromArgb(238, 242, 255)
        lblDoc.ForeColor = Color.FromArgb(67, 56, 202)
        lblDoc.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        left.Controls.Add(lblDoc)

        Dim signTitle As New Label With {.Text = "02   Signatories", .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold), .AutoSize = True, .Location = New Point(4, 194)}
        left.Controls.Add(signTitle)

        AddField(left, "Received by", txtReceivedName, 228)
        AddField(left, "Designation", txtReceivedDesignation, 302)
        AddField(left, If(_docType = "ICS", "Received from / Issued by", "Issued by"), txtIssuedName, 376)
        AddField(left, "Designation", txtIssuedDesignation, 450)

        btnRefresh.Text = "Refresh Document Preview"
        btnRefresh.Size = New Size(275, 38)
        btnRefresh.Location = New Point(4, 526)
        btnRefresh.BackColor = Color.FromArgb(79, 70, 229)
        btnRefresh.ForeColor = Color.White
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        AddHandler btnRefresh.Click, AddressOf RefreshPreview_Click
        left.Controls.Add(btnRefresh)

        lblPreviewStatus.Text = "Preview ready. Edit the fields, then click Refresh Document Preview."
        lblPreviewStatus.AutoSize = False
        lblPreviewStatus.Width = 275
        lblPreviewStatus.Height = 38
        lblPreviewStatus.Location = New Point(4, 568)
        lblPreviewStatus.ForeColor = Color.FromArgb(100, 116, 139)
        left.Controls.Add(lblPreviewStatus)

        Dim note As New Label With {
            .Text = "Preview only: no document is issued and no inventory/accountability records are changed until you click Generate PDF.",
            .AutoSize = False,
            .Width = 275,
            .Height = 58,
            .Location = New Point(4, 610),
            .ForeColor = Color.FromArgb(100, 116, 139)
        }
        left.Controls.Add(note)

        Dim previewPanel As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(14), .BackColor = Color.FromArgb(226, 232, 240)}
        split.Panel2.Controls.Add(previewPanel)
        browser.Dock = DockStyle.Fill
        browser.DefaultBackgroundColor = Color.FromArgb(226, 232, 240)
        previewPanel.Controls.Add(browser)
    End Sub

    Private Sub AddField(parent As Control, caption As String, field As TextBox, y As Integer)
        Dim label As New Label With {
            .Text = caption,
            .AutoSize = True,
            .Location = New Point(4, y),
            .ForeColor = Color.FromArgb(71, 85, 105)
        }
        field.Location = New Point(4, y + 22)
        field.Size = New Size(275, 32)
        field.Font = New Font("Segoe UI", 10.0F)
        parent.Controls.Add(label)
        parent.Controls.Add(field)
    End Sub

    Private Sub PopulateFields()
        txtReceivedName.Text = _signatories.ReceivedName
        txtReceivedDesignation.Text = _signatories.ReceivedDesignation
        txtIssuedName.Text = _signatories.IssuedName
        txtIssuedDesignation.Text = _signatories.IssuedDesignation
    End Sub

    Private Async Sub PreviewForm_Shown(sender As Object, e As EventArgs)
        Try
            Await browser.EnsureCoreWebView2Async()
            _browserReady = True
            NavigateToPreview()
        Catch ex As Exception
            MessageBox.Show("The in-app PDF preview could not be initialized. You can still refresh the document and open it in your default PDF viewer." & Environment.NewLine & ex.Message,
                            "PDF Preview", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub NavigateToPreview()
        If Not _browserReady OrElse Not File.Exists(_previewPath) Then Return
        browser.Source = New Uri(Path.GetFullPath(_previewPath))
    End Sub

    Private Sub ApplyFieldsToSignatories()
        _signatories.ReceivedName = txtReceivedName.Text.Trim()
        _signatories.ReceivedDesignation = txtReceivedDesignation.Text.Trim()
        _signatories.IssuedName = txtIssuedName.Text.Trim()
        _signatories.IssuedDesignation = txtIssuedDesignation.Text.Trim()
    End Sub

    Private Function NewPreviewPath() As String
        Dim previewDir = Path.GetDirectoryName(_previewPath)
        Return Path.Combine(previewDir, "PREVIEW_" & _docNo & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") & "_" & Guid.NewGuid().ToString("N") & ".pdf")
    End Function

    Private Sub RefreshPreview_Click(sender As Object, e As EventArgs)
        RefreshPdfInBackground(False)
    End Sub

    Private Sub RefreshPdfInBackground(openForPrinting As Boolean)
        If _refreshInProgress Then Return
        Try
            ApplyFieldsToSignatories()
            Dim signatorySnapshot As New PARICSSignatories With {
                .ReceivedName = _signatories.ReceivedName,
                .ReceivedDesignation = _signatories.ReceivedDesignation,
                .IssuedName = _signatories.IssuedName,
                .IssuedDesignation = _signatories.IssuedDesignation
            }
            Dim refreshedPath = NewPreviewPath()
            _refreshInProgress = True
            btnRefresh.Enabled = False
            btnPrint.Enabled = False
            btnGenerate.Enabled = False
            txtReceivedName.Enabled = False
            txtReceivedDesignation.Enabled = False
            txtIssuedName.Enabled = False
            txtIssuedDesignation.Enabled = False
            lblPreviewStatus.Text = "Updating PDF preview… please wait."
            Cursor = Cursors.WaitCursor

            Dim worker As New Thread(Sub()
                Dim errorMessage As String = Nothing
                Try
                    _refreshPdf.Invoke(refreshedPath, signatorySnapshot)
                Catch ex As Exception
                    errorMessage = ex.Message
                End Try

                If IsDisposed OrElse Not IsHandleCreated Then Return
                BeginInvoke(New Action(Sub()
                    _refreshInProgress = False
                    btnRefresh.Enabled = True
                    btnPrint.Enabled = True
                    btnGenerate.Enabled = True
                    txtReceivedName.Enabled = True
                    txtReceivedDesignation.Enabled = True
                    txtIssuedName.Enabled = True
                    txtIssuedDesignation.Enabled = True
                    Cursor = Cursors.Default

                    If Not String.IsNullOrWhiteSpace(errorMessage) Then
                        lblPreviewStatus.Text = "Preview update failed. Please try again."
                        MessageBox.Show("The document preview could not be refreshed." & Environment.NewLine & errorMessage,
                                        "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    _signatories.ReceivedName = signatorySnapshot.ReceivedName
                    _signatories.ReceivedDesignation = signatorySnapshot.ReceivedDesignation
                    _signatories.IssuedName = signatorySnapshot.IssuedName
                    _signatories.IssuedDesignation = signatorySnapshot.IssuedDesignation
                    _previewPath = refreshedPath
                    NavigateToPreview()
                    lblPreviewStatus.Text = "Preview updated."
                    If openForPrinting Then
                        Try
                            Process.Start(New ProcessStartInfo(_previewPath) With {.UseShellExecute = True})
                        Catch ex As Exception
                            MessageBox.Show("The PDF was created, but could not be opened." & Environment.NewLine & ex.Message,
                                            "Print Preview", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End Sub))
            End Sub)
            worker.IsBackground = True
            worker.SetApartmentState(ApartmentState.STA)
            worker.Start()
        Catch ex As Exception
            _refreshInProgress = False
            Cursor = Cursors.Default
            btnRefresh.Enabled = True
            btnPrint.Enabled = True
            btnGenerate.Enabled = True
            txtReceivedName.Enabled = True
            txtReceivedDesignation.Enabled = True
            txtIssuedName.Enabled = True
            txtIssuedDesignation.Enabled = True
            MessageBox.Show("The document preview could not be refreshed." & Environment.NewLine & ex.Message,
                            "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateFinal_Click(sender As Object, e As EventArgs)
        Try
            ApplyFieldsToSignatories()
            If _generateFinal IsNot Nothing AndAlso _generateFinal.Invoke() Then
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Final PDF generation could not be completed." & Environment.NewLine & ex.Message,
                            "Generate PAR/ICS PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Print_Click(sender As Object, e As EventArgs)
        RefreshPdfInBackground(True)
    End Sub
End Class
