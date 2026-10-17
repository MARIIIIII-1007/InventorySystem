Imports System.Data.SQLite
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmAccountabilityReview
    Inherits Form

    Private ReadOnly dgvReviews As New DataGridView()
    Private ReadOnly lblSummary As New Label()
    Private ReadOnly txtChangeReason As New TextBox()

    Public Sub New()
        BuildInterface()
        AddHandler Me.Load, AddressOf ReviewForm_Load
    End Sub

    Private Sub BuildInterface()
        Me.Name = "frmAccountabilityReview"
        Me.Text = "Accountability Review"
        Me.BackColor = Color.FromArgb(245, 247, 250)
        Me.MinimumSize = New Size(900, 560)

        Dim header As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 74,
            .BackColor = Color.White,
            .Padding = New Padding(18, 10, 18, 8)
        }
        Dim title As New Label With {
            .Text = "Accountability Review Queue",
            .AutoSize = True,
            .Font = New Font("Segoe UI", 16.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(17, 24, 39),
            .Location = New Point(18, 8)
        }
        lblSummary.AutoSize = True
        lblSummary.Text = "Review changes to accountable person or location."
        lblSummary.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        lblSummary.ForeColor = Color.FromArgb(75, 85, 99)
        lblSummary.Location = New Point(20, 42)
        header.Controls.Add(title)
        header.Controls.Add(lblSummary)

        dgvReviews.Name = "dgvAccountabilityReviews"
        dgvReviews.Dock = DockStyle.Fill
        dgvReviews.BackgroundColor = Color.White
        dgvReviews.BorderStyle = BorderStyle.FixedSingle
        dgvReviews.ReadOnly = True
        dgvReviews.AllowUserToAddRows = False
        dgvReviews.AllowUserToDeleteRows = False
        dgvReviews.AllowUserToResizeRows = False
        dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReviews.ScrollBars = ScrollBars.Vertical
        dgvReviews.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReviews.MultiSelect = False
        dgvReviews.RowHeadersVisible = False
        dgvReviews.AutoGenerateColumns = True
        dgvReviews.RowTemplate.Height = 30
        dgvReviews.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        dgvReviews.DefaultCellStyle.SelectionBackColor = Color.FromArgb(191, 219, 254)
        dgvReviews.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39)
        dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240)
        dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55)
        dgvReviews.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        dgvReviews.EnableHeadersVisualStyles = False
        dgvReviews.ColumnHeadersHeight = 34
        AddHandler dgvReviews.SelectionChanged, AddressOf UpdateSelectedReason

        Dim detailsPanel As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 112,
            .Padding = New Padding(12, 8, 12, 8),
            .BackColor = Color.FromArgb(248, 250, 252)
        }
        Dim lblReason As New Label With {
            .Text = "Selected Change Reason",
            .Dock = DockStyle.Top,
            .Height = 22,
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(55, 65, 81)
        }
        txtChangeReason.Name = "txtSelectedChangeReason"
        txtChangeReason.Dock = DockStyle.Fill
        txtChangeReason.Multiline = True
        txtChangeReason.ReadOnly = True
        txtChangeReason.ScrollBars = ScrollBars.Vertical
        txtChangeReason.BackColor = Color.White
        txtChangeReason.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        txtChangeReason.BorderStyle = BorderStyle.FixedSingle
        detailsPanel.Controls.Add(txtChangeReason)
        detailsPanel.Controls.Add(lblReason)

        Dim workspace As New Panel With {.Dock = DockStyle.Fill, .BackColor = Color.White}
        workspace.Controls.Add(dgvReviews)
        workspace.Controls.Add(detailsPanel)

        Dim footer As New FlowLayoutPanel With {
            .Dock = DockStyle.Bottom,
            .Height = 58,
            .FlowDirection = FlowDirection.RightToLeft,
            .Padding = New Padding(10),
            .BackColor = Color.White,
            .WrapContents = False
        }
        Dim btnClose As New Button With {.Text = "Close", .Width = 105, .Height = 34, .Margin = New Padding(6, 0, 0, 0)}
        Dim btnRefresh As New Button With {.Text = "Refresh", .Width = 105, .Height = 34, .Margin = New Padding(6, 0, 0, 0)}
        Dim btnResolve As New Button With {.Text = "Resolve Selected", .Width = 145, .Height = 34, .Margin = New Padding(6, 0, 0, 0), .BackColor = Color.FromArgb(0, 96, 64), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat}
        btnResolve.FlatAppearance.BorderSize = 0
        AddHandler btnClose.Click, Sub(sender, e) Close()
        AddHandler btnRefresh.Click, Sub(sender, e) LoadPendingReviews()
        AddHandler btnResolve.Click, AddressOf ResolveSelectedReview
        footer.Controls.Add(btnClose)
        footer.Controls.Add(btnRefresh)
        footer.Controls.Add(btnResolve)

        Me.Controls.Add(workspace)
        Me.Controls.Add(footer)
        Me.Controls.Add(header)
    End Sub

    Private Sub ReviewForm_Load(sender As Object, e As EventArgs)
        LoadPendingReviews()
    End Sub

    Private Sub ConfigureReviewColumns()
        If dgvReviews.Columns.Count = 0 Then Return

        If dgvReviews.Columns.Contains("HistoryID") Then dgvReviews.Columns("HistoryID").Visible = False
        If dgvReviews.Columns.Contains("InventoryID") Then dgvReviews.Columns("InventoryID").Visible = False
        If dgvReviews.Columns.Contains("ChangeReason") Then dgvReviews.Columns("ChangeReason").Visible = False

        SetColumn("PropertyNo", "Property No.", 12, 0)
        SetColumn("Description", "Description", 14, 1)
        SetColumn("ChangeType", "Change Type", 10, 2)
        SetColumn("PreviousEndUser", "Previous End User", 9, 3)
        SetColumn("NewEndUser", "New End User", 9, 4)
        SetColumn("PreviousLocation", "Previous Location", 9, 5)
        SetColumn("NewLocation", "New Location", 9, 6)
        SetColumn("ChangeDate", "Change Date", 12, 7)
        SetColumn("ChangedBy", "Changed By", 8, 8)
        SetColumn("ReviewStatus", "Review Status", 9, 9)
    End Sub

    Private Sub SetColumn(columnName As String, headerText As String, fillWeight As Single, displayIndex As Integer)
        If Not dgvReviews.Columns.Contains(columnName) Then Return
        With dgvReviews.Columns(columnName)
            .HeaderText = headerText
            .FillWeight = fillWeight
            .MinimumWidth = 55
            .DisplayIndex = displayIndex
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
    End Sub

    Private Sub LoadPendingReviews()
        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()
                Dim sql As String =
                    "SELECT h.ID AS HistoryID, h.InventoryID, i.PropertyNo, i.Description, " &
                    "h.ChangeType, h.PreviousEndUser, h.NewEndUser, h.PreviousLocation, " &
                    "h.NewLocation, h.ChangeDate, h.ChangeReason, h.ChangedBy, h.ReviewStatus " &
                    "FROM AccountabilityHistory h " &
                    "INNER JOIN InventoryDB i ON i.ID = h.InventoryID " &
                    "WHERE h.ReviewStatus = 'Pending Review' " &
                    "ORDER BY h.ChangeDate DESC, h.ID DESC"
                Using adapter As New SQLiteDataAdapter(sql, conn)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvReviews.DataSource = table
                End Using
            End Using

            ConfigureReviewColumns()
            lblSummary.Text = dgvReviews.Rows.Count.ToString() &
                " pending change record(s). Resolve only after the accountability action has been reviewed."
            If dgvReviews.Rows.Count > 0 Then
                dgvReviews.Rows(0).Selected = True
                UpdateSelectedReason(Nothing, EventArgs.Empty)
            Else
                txtChangeReason.Text = "No pending accountability reviews."
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to load accountability reviews." & Environment.NewLine & ex.Message,
                            "Accountability Review", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateSelectedReason(sender As Object, e As EventArgs)
        Try
            If dgvReviews.CurrentRow Is Nothing OrElse dgvReviews.CurrentRow.IsNewRow OrElse
               Not dgvReviews.Columns.Contains("ChangeReason") Then
                txtChangeReason.Text = String.Empty
                Return
            End If
            txtChangeReason.Text = Convert.ToString(dgvReviews.CurrentRow.Cells("ChangeReason").Value)
        Catch
            txtChangeReason.Text = String.Empty
        End Try
    End Sub

    Private Sub ResolveSelectedReview(sender As Object, e As EventArgs)
        If dgvReviews.CurrentRow Is Nothing OrElse dgvReviews.CurrentRow.IsNewRow Then
            MessageBox.Show("Select a pending review first.", "No Review Selected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim historyID As Integer
        If Not Integer.TryParse(Convert.ToString(dgvReviews.CurrentRow.Cells("HistoryID").Value), historyID) Then Return

        Dim actionTaken As String = Microsoft.VisualBasic.Interaction.InputBox(
            "Describe the accountability action taken (for example: verified relocation; PAR/ICS update required; no document change required after review)." & vbCrLf & vbCrLf &
            "Do not mark resolved until the required review/action is complete.",
            "Resolve Accountability Review", String.Empty).Trim()
        If String.IsNullOrWhiteSpace(actionTaken) Then Return

        Dim documentReference As String = Microsoft.VisualBasic.Interaction.InputBox(
            "Optional: enter the related PAR/ICS document number or reference, if applicable.",
            "Related Document Reference", String.Empty).Trim()

        Dim notes As String = If(String.IsNullOrWhiteSpace(documentReference),
                                 String.Empty,
                                 "Related document reference: " & documentReference)

        Dim answer = MessageBox.Show(
            "Confirm that this accountability review has been completed?" & vbCrLf & vbCrLf &
            "Action: " & actionTaken &
            If(notes.Length > 0, vbCrLf & notes, String.Empty),
            "Confirm Resolution", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer <> DialogResult.Yes Then Return

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()
                Using transaction As SQLiteTransaction = conn.BeginTransaction()
                    Using cmd As New SQLiteCommand(
                        "UPDATE AccountabilityHistory SET ReviewStatus = 'Resolved', " &
                        "ResolutionAction = @Action, ResolvedDate = @ResolvedDate, " &
                        "Notes = CASE WHEN @Notes = '' THEN Notes " &
                        "WHEN Notes IS NULL OR TRIM(Notes) = '' THEN @Notes " &
                        "ELSE Notes || char(10) || @Notes END " &
                        "WHERE ID = @ID AND ReviewStatus = 'Pending Review'", conn, transaction)
                        cmd.Parameters.AddWithValue("@Action", actionTaken)
                        cmd.Parameters.AddWithValue("@ResolvedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("@Notes", notes)
                        cmd.Parameters.AddWithValue("@ID", historyID)
                        Dim affected As Integer = cmd.ExecuteNonQuery()
                        If affected = 0 Then
                            transaction.Rollback()
                            MessageBox.Show("This review is no longer pending. Refresh the list and try again.",
                                            "Review Already Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoadPendingReviews()
                            Return
                        End If
                    End Using
                    transaction.Commit()
                End Using
            End Using

            LoadPendingReviews()
            MessageBox.Show("The review was marked as Resolved. The accountability history has been preserved.",
                            "Review Resolved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Unable to resolve the selected review." & Environment.NewLine & ex.Message,
                            "Accountability Review", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
