Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SQLite
Imports System.IO
Imports System.Linq
Public Class frmInventory
    Private _selectAllHeaderChecked As Boolean = False
    Private _updatingSelectAll As Boolean = False
    ' Responsive layout baseline captured before the form is hosted in the dashboard.
    Private ReadOnly _responsiveBounds As New Dictionary(Of Control, Rectangle)
    Private _responsiveBaseWidth As Integer = 0
    Private _applyingResponsiveLayout As Boolean = False

    Public Sub New()
        InitializeComponent()
        AddHandler dgvInventory.CellFormatting, AddressOf dgvInventory_CellFormatting
        CaptureResponsiveBounds(pnlMainContent)
        _responsiveBaseWidth = Math.Max(1, pnlMainContent.ClientSize.Width)
        AddHandler pnlMainContent.Resize, AddressOf ResponsiveContent_Resize
    End Sub

    Private Sub CaptureResponsiveBounds(parent As Control)
        For Each child As Control In parent.Controls
            _responsiveBounds(child) = child.Bounds
            CaptureResponsiveBounds(child)
        Next
    End Sub

    Private Sub ResponsiveContent_Resize(sender As Object, e As EventArgs)
        If _applyingResponsiveLayout OrElse _responsiveBaseWidth <= 0 Then Return
        If pnlMainContent Is Nothing OrElse pnlMainContent.ClientSize.Width <= 0 Then Return

        Dim scaleX As Double = pnlMainContent.ClientSize.Width / CDbl(_responsiveBaseWidth)
        scaleX = Math.Max(0.35, Math.Min(1.5, scaleX))

        _applyingResponsiveLayout = True
        Try
            SuspendLayout()
            ApplyResponsiveBounds(pnlMainContent, scaleX)

            ' Keep the inventory totals readable and aligned to the right edge.
            ' Their fonts do not scale with the window, so preserve their designed widths.
            Dim totalItemsBase As Rectangle
            If _responsiveBounds.TryGetValue(lblTotalItems, totalItemsBase) Then
                lblTotalItems.Width = totalItemsBase.Width
            End If

            Dim totalAmountBase As Rectangle
            If _responsiveBounds.TryGetValue(lblTotalAmount, totalAmountBase) Then
                lblTotalAmount.Width = totalAmountBase.Width
            End If

            Dim rightMargin As Integer = 20
            lblTotalAmount.Left = Math.Max(10, pnlMainContent.ClientSize.Width - rightMargin - lblTotalAmount.Width)
            lblTotalItems.Left = Math.Max(10, lblTotalAmount.Left - 15 - lblTotalItems.Width)

            pnlMainContent.AutoScrollMinSize = New Size(0, Math.Max(pnlMainContent.ClientSize.Height, GetBottomExtent(pnlMainContent)))
        Finally
            ResumeLayout(True)
            _applyingResponsiveLayout = False
        End Try
    End Sub

    Private Sub ApplyResponsiveBounds(parent As Control, scaleX As Double)
        For Each child As Control In parent.Controls
            Dim original As Rectangle
            If _responsiveBounds.TryGetValue(child, original) Then
                child.SetBounds(
                    CInt(Math.Round(original.X * scaleX)),
                    original.Y,
                    Math.Max(1, CInt(Math.Round(original.Width * scaleX))),
                    original.Height)
            End If
            ApplyResponsiveBounds(child, scaleX)
        Next
    End Sub

    Private Function GetBottomExtent(parent As Control) As Integer
        Dim bottom As Integer = 0
        For Each child As Control In parent.Controls
            bottom = Math.Max(bottom, child.Bottom)
            bottom = Math.Max(bottom, GetBottomExtent(child))
        Next
        Return bottom + 20
    End Function


    Public Shared InventoryFormInstance As frmInventory

    ' Prevent filter events from running repeated database searches while the form initializes.
    Private isInitializingFilters As Boolean = False
    Private isOpeningPropertyRecord As Boolean = False

    Public Sub LoadInventory()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "SELECT i.*, " &
                "CASE WHEN EXISTS (SELECT 1 FROM AccountabilityHistory h " &
                "WHERE h.InventoryID = i.ID AND h.ReviewStatus = 'Pending Review') " &
                "THEN 'Pending Review' ELSE 'No Pending Review' END AS AccountabilityReviewStatus " &
                "FROM InventoryDB i"

            Using adapter As New SQLiteDataAdapter(sql, conn)

                Dim table As New DataTable()

                adapter.Fill(table)

                dgvInventory.DataSource = table

                lblTotalItems.Text = "Total Items: " & table.Rows.Count.ToString()

                UpdateTotalInventoryAmount(table)

                ConfigureInventoryGrid()

            End Using

        End Using

    End Sub

    Private Sub UpdateTotalInventoryAmount(table As DataTable)

        Dim totalAmount As Decimal = 0D

        For Each row As DataRow In table.Rows

            Dim unitCost As Decimal = 0D
            Dim quantity As Decimal = 0D

            If Not IsDBNull(row("UnitCost")) Then
                Decimal.TryParse(row("UnitCost").ToString(), unitCost)
            End If

            If Not IsDBNull(row("Quantity")) Then
                Decimal.TryParse(row("Quantity").ToString(), quantity)
            End If

            totalAmount += unitCost * quantity

        Next

        lblTotalAmount.Text =
            "Total Inventory Amount: " &
            totalAmount.ToString("₱#,##0.00")

    End Sub

    Private Sub ConfigureInventoryGrid()

        'Make sure the grid has columns before configuring them
        If dgvInventory.Columns.Count = 0 Then
            Exit Sub
        End If

        dgvInventory.ReadOnly = False

        'Hide all columns first
        For Each col As DataGridViewColumn In dgvInventory.Columns
            If col.Name <> "chkSelect" Then
                col.Visible = False
            End If
        Next

        If dgvInventory.Columns.Contains("chkSelect") Then
            dgvInventory.Columns("chkSelect").Visible = True
            dgvInventory.Columns("chkSelect").DisplayIndex = 0
            dgvInventory.Columns("chkSelect").Width = 40
            dgvInventory.Columns("chkSelect").HeaderText = ""
            dgvInventory.Columns("chkSelect").SortMode = DataGridViewColumnSortMode.NotSortable
        End If

        'Show columns only if they actually exist
        ShowColumn("Category", "Classification", 1)
        ShowColumn("AccountCode", "Account Code", 2)
        ShowColumn("Article", "Article", 3)
        ShowColumn("Description", "Description", 4)
        ShowColumn("PropertyNo", "Property No.", 5)
        ShowColumn("DateAcquired", "Date Acquired", 6)
        ShowColumn("Quantity", "Qty", 7)
        ShowColumn("UnitCost", "Unit Cost", 8)
        ShowColumn("EndUser", "End User", 9)
        ShowColumn("Location", "Location", 10)
        ShowColumn("Condition", "Condition", 11)
        ShowColumn("AccountabilityReviewStatus", "Accountability Review", 12)

        If dgvInventory.Columns.Contains("AccountabilityReviewStatus") Then
            dgvInventory.Columns("AccountabilityReviewStatus").FillWeight = 125
        End If

        If dgvInventory.Columns.Contains("chkSelect") Then
            dgvInventory.Columns("chkSelect").ReadOnly = False
            dgvInventory.Columns("chkSelect").DisplayIndex = 0
            dgvInventory.Columns("chkSelect").Width = 40
            dgvInventory.Columns("chkSelect").Visible = True
        End If

        For Each col As DataGridViewColumn In dgvInventory.Columns
            If col.Name <> "chkSelect" Then
                col.ReadOnly = True
            End If
        Next
        'Set column proportions
        dgvInventory.Columns("Category").FillWeight = 90
        dgvInventory.Columns("AccountCode").FillWeight = 110
        dgvInventory.Columns("Article").FillWeight = 110
        dgvInventory.Columns("Description").FillWeight = 170
        dgvInventory.Columns("PropertyNo").FillWeight = 160
        dgvInventory.Columns("DateAcquired").FillWeight = 100
        dgvInventory.Columns("Quantity").FillWeight = 55
        dgvInventory.Columns("UnitCost").FillWeight = 90
        dgvInventory.Columns("EndUser").FillWeight = 110
        dgvInventory.Columns("Location").FillWeight = 100
        dgvInventory.Columns("Condition").FillWeight = 90

    End Sub
    Private Sub dgvInventory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvInventory.Columns(e.ColumnIndex).Name <> "AccountabilityReviewStatus" Then Return

        Dim statusText As String = If(e.Value Is Nothing, String.Empty, e.Value.ToString())
        If statusText = "Pending Review" Then
            e.CellStyle.BackColor = Color.FromArgb(255, 237, 213)
            e.CellStyle.ForeColor = Color.FromArgb(154, 52, 18)
        Else
            e.CellStyle.BackColor = Color.FromArgb(240, 253, 244)
            e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52)
        End If
    End Sub

    Private Sub ShowColumn(
    columnName As String,
    headerText As String,
    displayIndex As Integer)

        If dgvInventory.Columns.Contains(columnName) Then

            With dgvInventory.Columns(columnName)
                .Visible = True
                .HeaderText = headerText
                .DisplayIndex = displayIndex
            End With

        End If

    End Sub
    Private Sub SearchInventory()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT i.*, " &
            "CASE WHEN EXISTS (SELECT 1 FROM AccountabilityHistory h " &
            "WHERE h.InventoryID = i.ID AND h.ReviewStatus = 'Pending Review') " &
            "THEN 'Pending Review' ELSE 'No Pending Review' END AS AccountabilityReviewStatus " &
            "FROM InventoryDB i " &
            "WHERE (i.PropertyNo LIKE @search " &
            "OR i.Description LIKE @search " &
            "OR i.Category LIKE @search " &
            "OR i.AccountCode LIKE @search " &
            "OR i.Article LIKE @search " &
            "OR i.EndUser LIKE @search " &
            "OR i.Location LIKE @search) "

            'Classification filter
            If cboFilterClassification.SelectedIndex > 0 Then
                sql &= "AND i.Category = @classification "
            End If

            'End User filter
            If cboFilterEndUser.SelectedIndex > 0 Then
                sql &= "AND i.EndUser = @enduser "
            End If

            'Location filter
            If cboFilterLocation.SelectedIndex > 0 Then
                sql &= "AND i.Location = @location "
            End If

            'Condition filter
            If cboFilterCondition.SelectedIndex > 0 Then
                sql &= "AND i.Condition = @condition "
            End If

            Using adapter As New SQLiteDataAdapter(sql, conn)

                Dim searchText As String = txtSearch.Text

                If searchText = "Search Item..." Then
                    searchText = ""
                End If

                adapter.SelectCommand.Parameters.AddWithValue(
                "@search",
                "%" & searchText & "%")

                'Classification parameter
                If cboFilterClassification.SelectedIndex > 0 Then

                    adapter.SelectCommand.Parameters.AddWithValue(
                    "@classification",
                    cboFilterClassification.Text)

                End If

                'End User parameter
                If cboFilterEndUser.SelectedIndex > 0 Then

                    adapter.SelectCommand.Parameters.AddWithValue(
                    "@enduser",
                    cboFilterEndUser.Text)

                End If

                'Location parameter
                If cboFilterLocation.SelectedIndex > 0 Then

                    adapter.SelectCommand.Parameters.AddWithValue(
                    "@location",
                    cboFilterLocation.Text)

                End If
                'Condition parameter
                If cboFilterCondition.SelectedIndex > 0 Then

                    adapter.SelectCommand.Parameters.AddWithValue(
                    "@condition",
                    cboFilterCondition.Text)

                End If

                Dim table As New DataTable()

                adapter.Fill(table)

                dgvInventory.DataSource = table

                lblTotalItems.Text = "Total Items: " & table.Rows.Count.ToString()

                UpdateTotalInventoryAmount(table)

                ConfigureInventoryGrid()

            End Using

        End Using

    End Sub

    Public Sub OpenPropertyRecord(propertyNo As String)

        If String.IsNullOrWhiteSpace(propertyNo) Then
            MessageBox.Show(
                "No property number was provided.",
                "Open in Inventory",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Dim targetPropertyNo As String = propertyNo.Trim()
        isOpeningPropertyRecord = True
        Try
            'Clear filters so they cannot hide the scanned/searched property.
            txtSearch.Text = targetPropertyNo
            If cboFilterClassification.Items.Count > 0 Then cboFilterClassification.SelectedIndex = 0
            If cboFilterEndUser.Items.Count > 0 Then cboFilterEndUser.SelectedIndex = 0
            If cboFilterLocation.Items.Count > 0 Then cboFilterLocation.SelectedIndex = 0
            If cboFilterCondition.Items.Count > 0 Then cboFilterCondition.SelectedIndex = 0

            'Use an exact property-number match, not the normal multi-column LIKE search.
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()
                Using adapter As New SQLiteDataAdapter(
                    "SELECT * FROM InventoryDB WHERE PropertyNo = @PropertyNo ORDER BY ID LIMIT 1", conn)
                    adapter.SelectCommand.Parameters.AddWithValue("@PropertyNo", targetPropertyNo)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvInventory.DataSource = table
                    lblTotalItems.Text = "Total Items: " & table.Rows.Count.ToString()
                    UpdateTotalInventoryAmount(table)
                    ConfigureInventoryGrid()

                    If table.Rows.Count = 0 Then
                        ClearItemDetails()
                        MessageBox.Show(
                            "No inventory record was found for property number: " & targetPropertyNo,
                            "Open in Inventory",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                        Return
                    End If

                    Dim targetRow As DataGridViewRow = Nothing
                    For Each row As DataGridViewRow In dgvInventory.Rows
                        If Not row.IsNewRow AndAlso
                           String.Equals(GetCellText(row, "PropertyNo"), targetPropertyNo, StringComparison.OrdinalIgnoreCase) Then
                            targetRow = row
                            Exit For
                        End If
                    Next

                    If targetRow IsNot Nothing Then
                        dgvInventory.ClearSelection()
                        targetRow.Selected = True
                        If dgvInventory.Columns.Contains("PropertyNo") Then
                            dgvInventory.CurrentCell = targetRow.Cells("PropertyNo")
                        End If
                        dgvInventory.FirstDisplayedScrollingRowIndex = targetRow.Index
                        dgvInventory_CellClick(dgvInventory, New DataGridViewCellEventArgs(0, targetRow.Index))
                    End If
                End Using
            End Using
        Finally
            isOpeningPropertyRecord = False
        End Try

    End Sub

    Private Sub ClearItemDetails()
        txtDetailPropertyNo.Clear()
        txtDetailClassification.Clear()
        txtDetailAccountCode.Clear()
        txtDetailArticle.Clear()
        txtDetailDescription.Clear()
        txtDetailDateAcquired.Clear()
        txtDetailProcurement.Clear()
        txtDetailFundSource.Clear()
        txtDetailSourceDocument.Clear()
        txtDetailQuantity.Clear()
        txtDetailUnitCost.Clear()
        txtDetailUsefulLife.Clear()
        txtDetailEndUser.Clear()
        txtDetailLocation.Clear()
        txtDetailCondition.Clear()
        txtDetailPARICS.Clear()
        txtDetailRemarks.Clear()
        If picItemQR.Image IsNot Nothing Then
            picItemQR.Image.Dispose()
            picItemQR.Image = Nothing
        End If
        If picItemPhoto.Image IsNot Nothing Then
            picItemPhoto.Image.Dispose()
            picItemPhoto.Image = Nothing
        End If
    End Sub

    Private Sub LoadClassificationFilter()

        cboFilterClassification.Items.Clear()
        cboFilterClassification.Items.Add("All")

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT DISTINCT Category " &
            "FROM InventoryDB " &
            "WHERE Category IS NOT NULL " &
            "AND Category <> '' " &
            "ORDER BY Category"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        cboFilterClassification.Items.Add(
                        reader("Category").ToString())

                    End While

                End Using

            End Using

        End Using

        cboFilterClassification.SelectedIndex = 0

    End Sub
    Private Sub cboFilterEndUser_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboFilterEndUser.SelectedIndexChanged

        If isInitializingFilters Then Return
        If cboFilterEndUser.SelectedIndex = -1 Then Exit Sub

        LoadLocationFilter()

        SearchInventory()

    End Sub
    Private Sub cboFilterLocation_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboFilterLocation.SelectedIndexChanged

        If isInitializingFilters Then Return
        If cboFilterLocation.SelectedIndex = -1 Then Exit Sub

        SearchInventory()

    End Sub
    Private Sub cboFilterCondition_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboFilterCondition.SelectedIndexChanged

        If isInitializingFilters Then Return
        If cboFilterCondition.SelectedIndex = -1 Then Exit Sub

        SearchInventory()

    End Sub
    Private Sub LoadEndUserFilter()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT DISTINCT EndUser " &
            "FROM InventoryDB " &
            "WHERE EndUser IS NOT NULL " &
            "AND TRIM(EndUser) <> '' " &
            "ORDER BY EndUser"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    cboFilterEndUser.Items.Clear()
                    cboFilterEndUser.Items.Add("All")

                    While reader.Read()

                        cboFilterEndUser.Items.Add(
                        reader("EndUser").ToString())

                    End While

                End Using

            End Using

        End Using

        cboFilterEndUser.SelectedIndex = 0

    End Sub

    Private Sub LoadLocationFilter()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT DISTINCT Location " &
            "FROM InventoryDB " &
            "WHERE Location IS NOT NULL " &
            "AND TRIM(Location) <> '' "

            'If a specific End User is selected,
            'show only its locations.
            If cboFilterEndUser.SelectedIndex > 0 Then
                sql &= "AND EndUser = @enduser "
            End If

            sql &= "ORDER BY Location"

            Using cmd As New SQLiteCommand(sql, conn)

                If cboFilterEndUser.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue(
                    "@enduser",
                    cboFilterEndUser.Text)
                End If

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    cboFilterLocation.Items.Clear()
                    cboFilterLocation.Items.Add("All")

                    While reader.Read()

                        cboFilterLocation.Items.Add(
                        reader("Location").ToString())

                    End While

                End Using

            End Using

        End Using

        cboFilterLocation.SelectedIndex = 0

    End Sub
    Private Sub LoadConditionFilter()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT DISTINCT Condition " &
            "FROM InventoryDB " &
            "WHERE Condition IS NOT NULL " &
            "AND TRIM(Condition) <> '' " &
            "ORDER BY Condition"

            Using cmd As New SQLiteCommand(sql, conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    cboFilterCondition.Items.Clear()
                    cboFilterCondition.Items.Add("All")

                    While reader.Read()

                        cboFilterCondition.Items.Add(
                        reader("Condition").ToString())

                    End While

                End Using

            End Using

        End Using

        cboFilterCondition.SelectedIndex = 0

    End Sub

    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The dashboard owns navigation and the page title; hide the child-form duplicates.
        pnlSidebar.Visible = False
        pnlInventoryHeader.Visible = False
        pnlMainContent.AutoScroll = True
        ResponsiveContent_Resize(pnlMainContent, EventArgs.Empty)

        InventoryFormInstance = Me

        isInitializingFilters = True
        Try
            LoadClassificationFilter()
            LoadEndUserFilter()
            LoadLocationFilter()
            LoadConditionFilter()
        Finally
            isInitializingFilters = False
        End Try

        ' Load the inventory grid once after all filter controls are ready.
        LoadInventory()

        ApplyInventoryTheme()

        txtSearch.Text = "Search Item..."
        txtSearch.ForeColor = Color.Gray


    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Dim frm As New frmAddItem
        frm.ShowDialog()
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter

        txtSearch.SelectAll()

        If txtSearch.Text = "Search Item..." Then

            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black

        End If

    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        If Not isOpeningPropertyRecord AndAlso txtSearch.Text <> "Search Item..." Then
            SearchInventory()
        End If

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvInventory.CurrentRow Is Nothing Then

            MessageBox.Show("Please select an item first.")
            Exit Sub

        End If

        Dim selectedID As Integer =
            CInt(dgvInventory.CurrentRow.Cells("ID").Value)

        Dim result As DialogResult =
            MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

        If result = DialogResult.No Then
            Exit Sub
        End If

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
                "DELETE FROM InventoryDB WHERE ID=@ID"

            Using cmd As New SQLiteCommand(sql, conn)

                cmd.Parameters.AddWithValue("@ID", selectedID)

                cmd.ExecuteNonQuery()

            End Using

            conn.Close()

        End Using

        LoadInventory()

        MessageBox.Show("Item deleted successfully!")
    End Sub

    '==========================================================
    ' SELECT ALL CHECKBOX IN THE GRID HEADER
    '==========================================================

    Private Sub dgvInventory_CellPainting_SelectAllHeader(
        sender As Object,
        e As DataGridViewCellPaintingEventArgs) Handles dgvInventory.CellPainting

        If e.RowIndex <> -1 OrElse Not dgvInventory.Columns.Contains("chkSelect") Then Return
        If e.ColumnIndex <> dgvInventory.Columns("chkSelect").Index Then Return

        e.PaintBackground(e.CellBounds, True)
        e.PaintContent(e.CellBounds)

        Dim boxSize As Integer = 14
        Dim boxRect As New Rectangle(
            e.CellBounds.X + (e.CellBounds.Width - boxSize) \ 2,
            e.CellBounds.Y + (e.CellBounds.Height - boxSize) \ 2,
            boxSize,
            boxSize)

        Dim allChecked As Boolean = dgvInventory.Rows.Count > 0
        For Each row As DataGridViewRow In dgvInventory.Rows
            If row.IsNewRow Then Continue For
            If Not IsRowChecked(row) Then
                allChecked = False
                Exit For
            End If
        Next

        Dim state As ButtonState = If(allChecked, ButtonState.Checked, ButtonState.Normal)
        ControlPaint.DrawCheckBox(e.Graphics, boxRect, state)
        e.Handled = True
    End Sub

    Private Sub dgvInventory_HeaderSelectAllClick(
        sender As Object,
        e As DataGridViewCellMouseEventArgs) Handles dgvInventory.CellMouseClick

        If e.RowIndex <> -1 OrElse Not dgvInventory.Columns.Contains("chkSelect") Then Return
        If e.ColumnIndex <> dgvInventory.Columns("chkSelect").Index Then Return

        Dim anyUnchecked As Boolean = False
        For Each row As DataGridViewRow In dgvInventory.Rows
            If row.IsNewRow Then Continue For
            If Not IsRowChecked(row) Then
                anyUnchecked = True
                Exit For
            End If
        Next

        _updatingSelectAll = True
        Try
            For Each row As DataGridViewRow In dgvInventory.Rows
                If row.IsNewRow Then Continue For
                row.Cells("chkSelect").Value = anyUnchecked
            Next
        Finally
            _updatingSelectAll = False
        End Try

        dgvInventory.InvalidateColumn(dgvInventory.Columns("chkSelect").Index)
    End Sub

    Private Sub dgvInventory_CommitCheckboxEdit(
        sender As Object,
        e As EventArgs) Handles dgvInventory.CurrentCellDirtyStateChanged

        If dgvInventory.IsCurrentCellDirty AndAlso
           TypeOf dgvInventory.CurrentCell Is DataGridViewCheckBoxCell Then
            dgvInventory.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvInventory_CellValueChanged_UpdateSelectAllHeader(
        sender As Object,
        e As DataGridViewCellEventArgs) Handles dgvInventory.CellValueChanged

        If _updatingSelectAll Then Return
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso
           dgvInventory.Columns.Contains("chkSelect") AndAlso
           dgvInventory.Columns(e.ColumnIndex).Name <> "chkSelect" Then Return
        RefreshSelectAllHeader()
    End Sub

    Private Sub dgvInventory_RowsAdded_UpdateSelectAllHeader(
        sender As Object,
        e As DataGridViewRowsAddedEventArgs) Handles dgvInventory.RowsAdded
        RefreshSelectAllHeader()
    End Sub

    Private Sub dgvInventory_RowsRemoved_UpdateSelectAllHeader(
        sender As Object,
        e As DataGridViewRowsRemovedEventArgs) Handles dgvInventory.RowsRemoved
        RefreshSelectAllHeader()
    End Sub

    Private Sub RefreshSelectAllHeader()
        If _updatingSelectAll Then Return
        If dgvInventory.Columns.Contains("chkSelect") Then
            dgvInventory.InvalidateColumn(dgvInventory.Columns("chkSelect").Index)
        End If
    End Sub

    Private Function IsRowChecked(row As DataGridViewRow) As Boolean
        If row Is Nothing OrElse row.IsNewRow OrElse Not dgvInventory.Columns.Contains("chkSelect") Then Return False
        Dim value As Object = row.Cells("chkSelect").Value
        If value Is Nothing OrElse value Is DBNull.Value Then Return False
        Try
            Return Convert.ToBoolean(value)
        Catch
            Return False
        End Try
    End Function

    Private Sub dgvInventory_CellClick(
    sender As Object,
    e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim row = dgvInventory.Rows(e.RowIndex)

        'Basic information
        txtDetailPropertyNo.Text = GetCellText(row, "PropertyNo")
        txtDetailClassification.Text = GetCellText(row, "Category")
        txtDetailAccountCode.Text = GetCellText(row, "AccountCode")
        txtDetailArticle.Text = GetCellText(row, "Article")
        txtDetailDescription.Text = GetCellText(row, "Description")

        'Acquisition / financial information
        txtDetailDateAcquired.Text = GetCellText(row, "DateAcquired")
        txtDetailProcurement.Text = GetCellText(row, "Procurement")
        txtDetailFundSource.Text = GetCellText(row, "FundSource")
        txtDetailSourceDocument.Text = GetCellText(row, "SourceDocument")
        txtDetailQuantity.Text = GetCellText(row, "Quantity")
        txtDetailUnitCost.Text = GetCellText(row, "UnitCost")

        'Your current database uses EUL
        txtDetailUsefulLife.Text = GetCellText(row, "EUL")

        'Accountability / location information
        txtDetailEndUser.Text = GetCellText(row, "EndUser")
        txtDetailLocation.Text = GetCellText(row, "Location")
        txtDetailCondition.Text = GetCellText(row, "Condition")

        'PAR/ICS
        txtDetailPARICS.Text = ""

        'Remarks
        txtDetailRemarks.Text = GetCellText(row, "Remarks")

        'Load QR Code
        Dim qrPath As String = GetCellText(row, "QRCodePath")

        If Not String.IsNullOrWhiteSpace(qrPath) AndAlso
       File.Exists(qrPath) Then

            Using tempImage As Image = Image.FromFile(qrPath)
                picItemQR.Image = New Bitmap(tempImage)
            End Using

        Else

            picItemQR.Image = Nothing

        End If

        'Load item photo
        Dim photoPath As String = GetCellText(row, "PhotoPath")

        If Not String.IsNullOrWhiteSpace(photoPath) AndAlso
       File.Exists(photoPath) Then

            Using tempImage As Image = Image.FromFile(photoPath)
                picItemPhoto.Image = New Bitmap(tempImage)
            End Using

        Else

            picItemPhoto.Image = Nothing

        End If

    End Sub


    Private Function GetCellText(
    row As DataGridViewRow,
    columnName As String) As String

        If Not dgvInventory.Columns.Contains(columnName) Then
            Return ""
        End If

        Dim value As Object = row.Cells(columnName).Value

        If value Is Nothing OrElse IsDBNull(value) Then
            Return ""
        End If

        Return value.ToString()

    End Function

    Private Sub btnViewPhoto_Click(
    sender As Object,
    e As EventArgs) Handles btnViewPhoto.Click

        If picItemPhoto.Image Is Nothing Then
            MessageBox.Show(
            "No photo is available for this item.",
            "View Photo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim viewer As New Form()

        viewer.Text = "Item Photo"
        viewer.StartPosition = FormStartPosition.CenterScreen
        viewer.Size = New Size(800, 600)

        Dim picture As New PictureBox()

        picture.Dock = DockStyle.Fill
        picture.Image = picItemPhoto.Image
        picture.SizeMode = PictureBoxSizeMode.Zoom
        picture.BackColor = Color.White

        viewer.Controls.Add(picture)

        viewer.ShowDialog()

    End Sub

    Private Sub btnViewQR_Click(
    sender As Object,
    e As EventArgs) Handles btnViewQR.Click

        If picItemQR.Image Is Nothing Then
            MessageBox.Show(
            "No QR code is available for this item.",
            "View QR Code",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim viewer As New Form()

        viewer.Text = "Item QR Code"
        viewer.StartPosition = FormStartPosition.CenterScreen
        viewer.Size = New Size(600, 650)

        Dim picture As New PictureBox()

        picture.Dock = DockStyle.Fill
        picture.Image = picItemQR.Image
        picture.SizeMode = PictureBoxSizeMode.Zoom
        picture.BackColor = Color.White

        viewer.Controls.Add(picture)

        viewer.ShowDialog()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvInventory.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item first.")
            Exit Sub
        End If

        Dim selectedID As Integer =
            CInt(dgvInventory.CurrentRow.Cells("ID").Value)

        Dim frm As New frmAddItem

        frm.IsEditMode = True
        frm.EditID = selectedID

        frm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        ' Reset filters together so their SelectedIndexChanged events do not
        ' trigger several redundant database searches.
        isInitializingFilters = True
        Try
            txtSearch.Text = "Search Item..."
            txtSearch.ForeColor = Color.Gray

            If cboFilterClassification.Items.Count > 0 Then
                cboFilterClassification.SelectedIndex = 0
            End If

            If cboFilterEndUser.Items.Count > 0 Then
                cboFilterEndUser.SelectedIndex = 0
            End If

            ' Refresh the available locations for All End Users, then reset it.
            LoadLocationFilter()

            If cboFilterLocation.Items.Count > 0 Then
                cboFilterLocation.SelectedIndex = 0
            End If

            If cboFilterCondition.Items.Count > 0 Then
                cboFilterCondition.SelectedIndex = 0
            End If
        Finally
            isInitializingFilters = False
        End Try

        ' Reload the complete inventory list once after resetting all filters.
        LoadInventory()

    End Sub

    Private Sub cboFilterClassification_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboFilterClassification.SelectedIndexChanged

        If isInitializingFilters Then Return

        If cboFilterClassification.SelectedIndex = -1 Then
            Exit Sub
        End If

        SearchInventory()

    End Sub


    '==========================================================
    ' QR / BARCODE VALIDATION AND GENERATION FOR STICKERS
    '==========================================================

    Private Function IsUsableCodeImage(path As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(path) AndAlso File.Exists(path)
    End Function

    Private Function GetSafeCodeFileName(propertyNo As String) As String
        Dim safeName As String = propertyNo.Trim()
        For Each invalidChar As Char In Path.GetInvalidFileNameChars()
            safeName = safeName.Replace(invalidChar, "_"c)
        Next
        safeName = safeName.Replace("/", "-").Replace("\", "-")
        Return safeName
    End Function

    Private Function GenerateQRCodeForInventoryRow(row As DataGridViewRow) As String
        Dim propertyNo As String = GetCellText(row, "PropertyNo").Trim()
        If propertyNo = "" Then Return ""

        Dim qrFolder As String = Path.Combine(Application.StartupPath, "QR Codes")
        Directory.CreateDirectory(qrFolder)

        Dim qrPath As String = Path.Combine(qrFolder, GetSafeCodeFileName(propertyNo) & ".png")
        Dim description As String = GetCellText(row, "Description")
        Dim location As String = GetCellText(row, "Location")
        Dim dateAcquired As String = GetCellText(row, "DateAcquired")
        Dim procurement As String = GetCellText(row, "Procurement")

        Dim qrText As String =
            "Property No.: " & propertyNo & vbCrLf &
            "Description: " & description & vbCrLf &
            "Location: " & location & vbCrLf &
            "Date Acquired: " & dateAcquired & vbCrLf &
            "Procurement: " & procurement

        Using generator As New QRCoder.QRCodeGenerator()
            Using qrData As QRCoder.QRCodeData =
                generator.CreateQrCode(qrText, QRCoder.QRCodeGenerator.ECCLevel.Q)
                Using qrCode As New QRCoder.QRCode(qrData)
                    Using qrImage As Bitmap = qrCode.GetGraphic(10)
                        qrImage.Save(qrPath, Imaging.ImageFormat.Png)
                    End Using
                End Using
            End Using
        End Using

        Return qrPath
    End Function

    Private Function GenerateBarcodeForInventoryRow(row As DataGridViewRow) As String
        Dim propertyNo As String = GetCellText(row, "PropertyNo").Trim()
        If propertyNo = "" Then Return ""

        Dim barcodeFolder As String = Path.Combine(Application.StartupPath, "Barcodes")
        Directory.CreateDirectory(barcodeFolder)

        Dim barcodePath As String = Path.Combine(barcodeFolder, GetSafeCodeFileName(propertyNo) & ".png")
        Dim writer As New ZXing.Windows.Compatibility.BarcodeWriter With {
            .Format = ZXing.BarcodeFormat.CODE_128,
            .Options = New ZXing.Common.EncodingOptions With {
                .Width = 600,
                .Height = 150,
                .Margin = 10
            }
        }

        Using barcodeImage As Bitmap = writer.Write(propertyNo)
            barcodeImage.Save(barcodePath, Imaging.ImageFormat.Png)
        End Using

        Return barcodePath
    End Function

    Private Sub SaveGeneratedCodePaths(propertyNo As String, qrPath As String, barcodePath As String)
        Using conn As New SQLiteConnection(ConnString)
            conn.Open()
            Using cmd As New SQLiteCommand(
                "UPDATE InventoryDB SET QRCodePath = @qrPath, BarcodePath = @barcodePath WHERE PropertyNo = @propertyNo", conn)
                cmd.Parameters.AddWithValue("@qrPath", If(String.IsNullOrWhiteSpace(qrPath), CType(DBNull.Value, Object), qrPath))
                cmd.Parameters.AddWithValue("@barcodePath", If(String.IsNullOrWhiteSpace(barcodePath), CType(DBNull.Value, Object), barcodePath))
                cmd.Parameters.AddWithValue("@propertyNo", propertyNo)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Private Sub btnGeneratePARICS_Click(sender As Object, e As EventArgs) Handles btnGeneratePARICS.Click
        Dim selectedIDs As New List(Of Integer)
        For Each gridRow As DataGridViewRow In dgvInventory.Rows
            If gridRow.IsNewRow Then Continue For
            If dgvInventory.Columns.Contains("chkSelect") AndAlso IsRowChecked(gridRow) Then
                Dim idValue As Integer
                If Integer.TryParse(GetCellText(gridRow, "ID"), idValue) Then selectedIDs.Add(idValue)
            End If
        Next

        If selectedIDs.Count = 0 Then
            MessageBox.Show("Select the property records using the checkboxes first.", "Generate PAR/ICS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using generator As New frmGeneratePARICS(selectedIDs)
            ' Open the preview immediately; do not show the intermediate record-list window.
            generator.OpenPreviewDirect()
        End Using
        LoadInventory()
    End Sub

    Private Sub btnPrintSticker_Click(
    sender As Object,
    e As EventArgs) Handles btnPrintSticker.Click

        '========================
        ' SELECT STICKER FORMAT
        '========================

        Dim stickerFormat As New frmStickerFormat()

        If stickerFormat.ShowDialog(Me) <> DialogResult.OK Then
            Exit Sub
        End If

        Dim useQRCode As Boolean =
            stickerFormat.UseQRCode

        Dim useBarcode As Boolean =
            stickerFormat.UseBarcode

        '========================
        ' GET SELECTED INVENTORY
        '========================

        Dim selectedRows As New List(Of DataGridViewRow)

        For Each gridRow As DataGridViewRow In dgvInventory.Rows

            If Not gridRow.IsNewRow Then

                Dim isChecked As Boolean =
                    Convert.ToBoolean(
                        gridRow.Cells("chkSelect").Value)

                If isChecked Then
                    selectedRows.Add(gridRow)
                End If

            End If

        Next

        If selectedRows.Count = 0 Then

            MessageBox.Show(
                "Please select at least one item to print a sticker.",
                "Print Sticker",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Exit Sub

        End If

        '==========================================================
        ' WARN ABOUT MISSING QR / BARCODE IMAGES BEFORE PRINTING
        '==========================================================

        Dim itemsMissingQR As New List(Of String)
        Dim itemsMissingBarcode As New List(Of String)

        For Each row As DataGridViewRow In selectedRows
            Dim propertyNo As String = GetCellText(row, "PropertyNo")
            Dim qrPath As String = GetCellText(row, "QRCodePath")
            Dim barcodePath As String = GetCellText(row, "BarcodePath")

            If Not IsUsableCodeImage(qrPath) Then itemsMissingQR.Add(propertyNo)
            If Not IsUsableCodeImage(barcodePath) Then itemsMissingBarcode.Add(propertyNo)
        Next

        Dim generateMissingCodes As Boolean = False

        If (useQRCode OrElse useBarcode) AndAlso
           (itemsMissingQR.Count > 0 OrElse itemsMissingBarcode.Count > 0) Then
            Dim warning As New System.Text.StringBuilder()
            warning.AppendLine("Some selected items do not have a saved QR code and/or barcode image.")
            warning.AppendLine()

            If itemsMissingQR.Count > 0 Then
                warning.AppendLine("Missing QR code (" & itemsMissingQR.Count & "):")
                For Each itemNo As String In itemsMissingQR.Take(10)
                    warning.AppendLine("  • " & If(String.IsNullOrWhiteSpace(itemNo), "(no property number)", itemNo))
                Next
                If itemsMissingQR.Count > 10 Then warning.AppendLine("  ...and " & (itemsMissingQR.Count - 10).ToString() & " more")
                warning.AppendLine()
            End If

            If itemsMissingBarcode.Count > 0 Then
                warning.AppendLine("Missing barcode (" & itemsMissingBarcode.Count & "):")
                For Each itemNo As String In itemsMissingBarcode.Take(10)
                    warning.AppendLine("  • " & If(String.IsNullOrWhiteSpace(itemNo), "(no property number)", itemNo))
                Next
                If itemsMissingBarcode.Count > 10 Then warning.AppendLine("  ...and " & (itemsMissingBarcode.Count - 10).ToString() & " more")
                warning.AppendLine()
            End If

            warning.AppendLine("Yes = Generate and save any missing QR codes and barcodes, then continue.")
            warning.AppendLine("No = Continue using existing codes only; items missing the selected sticker code will be skipped.")
            warning.Append("Cancel = Stop printing.")

            Dim choice As DialogResult = MessageBox.Show(
                warning.ToString(),
                "Missing QR Code / Barcode",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1)

            If choice = DialogResult.Cancel Then Exit Sub
            generateMissingCodes = (choice = DialogResult.Yes)

            If generateMissingCodes Then
                Try
                    For Each row As DataGridViewRow In selectedRows
                        Dim propertyNo As String = GetCellText(row, "PropertyNo").Trim()
                        If propertyNo = "" Then Continue For

                        Dim qrPath As String = GetCellText(row, "QRCodePath")
                        Dim barcodePath As String = GetCellText(row, "BarcodePath")
                        Dim changed As Boolean = False

                        If Not IsUsableCodeImage(qrPath) Then
                            qrPath = GenerateQRCodeForInventoryRow(row)
                            changed = True
                        End If

                        If Not IsUsableCodeImage(barcodePath) Then
                            barcodePath = GenerateBarcodeForInventoryRow(row)
                            changed = True
                        End If

                        If changed Then
                            SaveGeneratedCodePaths(propertyNo, qrPath, barcodePath)
                            If dgvInventory.Columns.Contains("QRCodePath") Then row.Cells("QRCodePath").Value = qrPath
                            If dgvInventory.Columns.Contains("BarcodePath") Then row.Cells("BarcodePath").Value = barcodePath
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show(
                        "The missing QR code/barcode could not be generated or saved." & Environment.NewLine &
                        "No sticker sheets have been opened yet." & Environment.NewLine & Environment.NewLine &
                        ex.Message,
                        "Code Generation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        End If

        '========================
        ' STICKER FILE LIST
        '========================

        Dim stickerFiles As New List(Of String)

        '========================
        ' GENERATE INDIVIDUAL STICKERS
        '========================

        For Each row As DataGridViewRow In selectedRows

            Dim propertyNo As String =
                GetCellText(row, "PropertyNo")

            Dim endUser As String =
                GetCellText(row, "EndUser")

            Dim location As String =
                GetCellText(row, "Location")

            Dim dateAcquired As String =
                GetCellText(row, "DateAcquired")

            Dim inventoryDate As String =
                Date.Today.ToString("MM/dd/yyyy")

            Dim unitOffice As String =
                endUser & " - " & location

            Dim qrCodePath As String =
                GetCellText(row, "QRCodePath")

            Dim barcodePath As String =
                GetCellText(row, "BarcodePath")

            Dim safeInventoryNo As String =
                String.Join(
                    "_",
                    propertyNo.Split(
                        IO.Path.GetInvalidFileNameChars()))


            ' Do not create a QR/barcode sticker with an empty code area.
            If useQRCode AndAlso Not IsUsableCodeImage(qrCodePath) Then
                Continue For
            End If
            If useBarcode AndAlso Not IsUsableCodeImage(barcodePath) Then
                Continue For
            End If

            Dim stickerPath As String

            If useQRCode Then

                '========================
                ' WITH QR CODE
                '========================

                StickerPngGenerator.GenerateQRStickerPNG(
                    unitOffice,
                    propertyNo,
                    dateAcquired,
                    inventoryDate,
                    qrCodePath,
                    False)

                stickerPath =
                    IO.Path.Combine(
                        Application.StartupPath,
                        "Sticker_QR_" &
                        safeInventoryNo &
                        ".png")

            ElseIf useBarcode Then

                '========================
                ' WITH BARCODE
                '========================

                BarcodeStickerPngGenerator.GenerateBarcodeStickerPNG(
                    unitOffice,
                    propertyNo,
                    dateAcquired,
                    inventoryDate,
                    barcodePath,
                    False)

                stickerPath =
                    IO.Path.Combine(
                        Application.StartupPath,
                        "Sticker_Barcode_" &
                        safeInventoryNo &
                        ".png")

            Else

                '========================
                ' WITHOUT QR CODE
                '========================

                NoQRStickerPngGenerator.GenerateNoQRStickerPNG(
                    unitOffice,
                    propertyNo,
                    dateAcquired,
                    inventoryDate,
                    False)

                stickerPath =
                    IO.Path.Combine(
                        Application.StartupPath,
                        "Sticker_NoQR_" &
                        safeInventoryNo &
                        ".png")

            End If

            If IO.File.Exists(stickerPath) Then
                stickerFiles.Add(stickerPath)
            Else
                MessageBox.Show(
                    "Sticker image was not created for property: " &
                    propertyNo,
                    "Print Sticker",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
            End If


        Next

        '========================
        ' CREATE A4 SHEETS
        '========================

        Dim sheetPaths As List(Of String) =
            StickerSheetGenerator.CreateA4Sheets(
                stickerFiles)

        If sheetPaths Is Nothing OrElse
           sheetPaths.Count = 0 Then

            MessageBox.Show(
                "No A4 sheets were created.",
                "Print Sticker",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If

        '========================
        ' OPEN PRINT PREVIEW
        '========================

        Dim preview As New frmStickerPrintPreview(
            sheetPaths)

        preview.ShowDialog(Me)

    End Sub

    '==========================================================
    ' MODERN INVENTORY THEME - COLORS
    '==========================================================

    ' Light theme palette for Property & Equipment
    Private ReadOnly Navy950 As Color = Color.FromArgb(245, 247, 250) ' Main canvas
    Private ReadOnly Navy900 As Color = Color.White                  ' Cards and panels
    Private ReadOnly Navy800 As Color = Color.FromArgb(241, 245, 249) ' Inputs and headers

    Private ReadOnly Indigo500 As Color = Color.FromArgb(99, 102, 241)
    Private ReadOnly Indigo400 As Color = Color.FromArgb(129, 140, 248)

    Private ReadOnly Cyan400 As Color = Color.FromArgb(34, 211, 238)
    Private ReadOnly Emerald400 As Color = Color.FromArgb(52, 211, 153)
    Private ReadOnly Amber400 As Color = Color.FromArgb(251, 191, 36)
    Private ReadOnly Rose400 As Color = Color.FromArgb(248, 113, 113)

    Private ReadOnly TextPrimary As Color = Color.FromArgb(31, 41, 55)
    Private ReadOnly TextSecondary As Color = Color.FromArgb(71, 85, 105)
    Private ReadOnly TextMuted As Color = Color.FromArgb(100, 116, 139)

    '==========================================================
    ' APPLY INVENTORY THEME
    '==========================================================

    Private Sub ApplyInventoryTheme()

        '------------------------------------------------------
        ' FORM
        '------------------------------------------------------

        Me.BackColor = Navy950
        Me.ForeColor = TextPrimary


        '------------------------------------------------------
        ' MAIN INVENTORY STYLING
        '------------------------------------------------------

        StyleInventoryGrid()
        StyleInventoryPanels()
        StylePanelHeaders()
        StyleInventoryBackground()
        StyleInventoryHeader()
        StyleInventoryHeaderTitle()
        StyleInventorySummary()
        ApplyRoundedDetailTextBoxes()
        StyleInventoryFilters()
        StyleInventoryActionButtons()
        StyleInventoryDetailPanels()
        ApplyInventoryPanelRounding()
        StyleInventoryMediaButtons()
        RefineInventoryGrid()


        '------------------------------------------------------
        ' DETAIL TEXTBOXES
        '------------------------------------------------------

        StyleDetailTextBox(txtDetailPropertyNo)
        StyleDetailTextBox(txtDetailClassification)
        StyleDetailTextBox(txtDetailAccountCode)
        StyleDetailTextBox(txtDetailArticle)
        StyleDetailTextBox(txtDetailDescription)

        StyleDetailTextBox(txtDetailDateAcquired)
        StyleDetailTextBox(txtDetailProcurement)
        StyleDetailTextBox(txtDetailFundSource)
        StyleDetailTextBox(txtDetailSourceDocument)
        StyleDetailTextBox(txtDetailQuantity)
        StyleDetailTextBox(txtDetailUnitCost)
        StyleDetailTextBox(txtDetailUsefulLife)

        StyleDetailTextBox(txtDetailEndUser)
        StyleDetailTextBox(txtDetailLocation)
        StyleDetailTextBox(txtDetailCondition)
        StyleDetailTextBox(txtDetailPARICS)
        StyleDetailTextBox(txtDetailRemarks)


        '------------------------------------------------------
        ' PHOTO / QR BOXES
        '------------------------------------------------------

        picItemPhoto.BackColor = Navy800
        picItemQR.BackColor = Navy800

        picItemPhoto.BorderStyle = BorderStyle.FixedSingle
        picItemQR.BorderStyle = BorderStyle.FixedSingle


        '------------------------------------------------------
        ' LABELS
        '------------------------------------------------------

        StyleLabels(Me.Controls)

    End Sub

    '==========================================================
    ' STYLE COMBOBOX
    '==========================================================
    Private Sub StyleComboBox(cbo As ComboBox)

        cbo.BackColor = Color.White
        cbo.ForeColor = Color.FromArgb(31, 41, 55)

        ' Standard style keeps the dropdown arrow and field edge easy to see.
        cbo.FlatStyle = FlatStyle.Standard

        cbo.Font = New Font(
            "Segoe UI",
            9,
            FontStyle.Regular)

    End Sub

    '==========================================================
    ' STYLE PRIMARY BUTTON
    '==========================================================

    Private Sub StylePrimaryButton(btn As Button)

        btn.BackColor = Indigo500
        btn.ForeColor = Color.White

        btn.FlatStyle = FlatStyle.Flat

        btn.FlatAppearance.BorderSize = 0

        btn.Font = New Font(
            "Segoe UI Semibold",
            9,
            FontStyle.Bold)

        btn.Cursor = Cursors.Hand

    End Sub

    '==========================================================
    ' STYLE SECONDARY BUTTON
    '==========================================================

    Private Sub StyleSecondaryButton(btn As Button)

        btn.BackColor = Color.White
        btn.ForeColor = TextSecondary

        btn.FlatStyle = FlatStyle.Flat

        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225)

        btn.Font = New Font(
            "Segoe UI Semibold",
            9,
            FontStyle.Bold)

        btn.Cursor = Cursors.Hand

    End Sub

    '==========================================================
    ' STYLE DANGER BUTTON
    '==========================================================

    Private Sub StyleDangerButton(btn As Button)

        btn.BackColor = Color.FromArgb(127, 29, 29)
        btn.ForeColor = Color.White

        btn.FlatStyle = FlatStyle.Flat

        btn.FlatAppearance.BorderSize = 0

        btn.Font = New Font(
            "Segoe UI Semibold",
            9,
            FontStyle.Bold)

        btn.Cursor = Cursors.Hand

    End Sub

    '==========================================================
    ' STYLE DETAIL TEXTBOX
    '==========================================================

    Private Sub StyleDetailTextBox(txt As TextBox)

        txt.BackColor = Navy800
        txt.ForeColor = TextPrimary

        txt.BorderStyle = BorderStyle.FixedSingle

        txt.Font = New Font(
            "Segoe UI",
            9,
            FontStyle.Regular)

    End Sub

    '==========================================================
    ' STYLE LABELS
    '==========================================================

    Private Sub StyleLabels(parentControls As Control.ControlCollection)

        For Each ctrl As Control In parentControls

            If TypeOf ctrl Is Label Then

                Dim lbl As Label = DirectCast(ctrl, Label)

                If lbl.Name <> "lblTitle" Then

                    lbl.ForeColor = TextSecondary

                    lbl.Font = New Font(
                        "Segoe UI",
                        9,
                        FontStyle.Regular)

                End If

            ElseIf ctrl.HasChildren Then

                StyleLabels(ctrl.Controls)

            End If

        Next

    End Sub

    '==========================================================
    ' STYLE INVENTORY GRID
    '==========================================================

    Private Sub StyleInventoryGrid()

        With dgvInventory

            .BackgroundColor = Navy950
            .BorderStyle = BorderStyle.None

            .EnableHeadersVisualStyles = False

            ' Header
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(226, 235, 246)
            .ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary
            .ColumnHeadersDefaultCellStyle.Font = New Font(
                "Segoe UI Semibold",
                9,
                FontStyle.Bold)

            .ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft

            .ColumnHeadersHeight = 36

            ' Rows
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = TextPrimary
            .DefaultCellStyle.Font = New Font(
                "Segoe UI",
                9,
                FontStyle.Regular)

            .DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(191, 219, 254)

            .DefaultCellStyle.SelectionForeColor = TextPrimary

            .RowTemplate.Height = 32

            ' Grid lines
            .GridColor = Color.FromArgb(226, 232, 240)

            .CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal

            ' Alternating rows
            .AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252)

            ' Selection
            .SelectionMode =
                DataGridViewSelectionMode.FullRowSelect

            .MultiSelect = False

        End With

    End Sub

    '==========================================================
    ' STYLE INVENTORY PANELS
    '==========================================================

    Private Sub StyleInventoryPanels()

        ' Item Details panel
        pnlItemDetails.BackColor = Navy900
        pnlItemDetails.ForeColor = TextSecondary

        ' Item Photo / QR panel
        pnlItemMedia.BackColor = Navy900
        pnlItemMedia.ForeColor = TextSecondary

    End Sub

    '==========================================================
    ' STYLE PANEL LABELS
    '==========================================================

    Private Sub StylePanelHeaders()

        ' Item Details header
        If pnlItemDetails.Controls.Count > 0 Then

            For Each ctrl As Control In pnlItemDetails.Controls

                If TypeOf ctrl Is Label Then

                    ctrl.ForeColor = TextSecondary
                    ctrl.BackColor = Color.Transparent

                    ctrl.Font = New Font(
                        "Segoe UI Semibold",
                        9,
                        FontStyle.Bold)

                End If

            Next

        End If

        ' Item Photo / QR header
        If pnlItemMedia.Controls.Count > 0 Then

            For Each ctrl As Control In pnlItemMedia.Controls

                If TypeOf ctrl Is Label Then

                    ctrl.ForeColor = TextSecondary
                    ctrl.BackColor = Color.Transparent

                    ctrl.Font = New Font(
                        "Segoe UI Semibold",
                        9,
                        FontStyle.Bold)

                End If

            Next

        End If

    End Sub

    '==========================================================
    ' STYLE MAIN INVENTORY BACKGROUND
    '==========================================================

    Private Sub StyleInventoryBackground()

        ' Main content area
        pnlMainContent.BackColor = Navy950

        ' Sidebar
        ' Keep the navigation sidebar dark for contrast against the light page.
        pnlSidebar.BackColor = Color.FromArgb(10, 22, 40)

    End Sub
    '==========================================================
    ' STYLE INVENTORY HEADER
    '==========================================================

    Private Sub StyleInventoryHeader()

        pnlInventoryHeader.BackColor = Navy900
        pnlInventoryHeader.ForeColor = TextPrimary

        ' Style labels inside the header
        StyleLabels(pnlInventoryHeader.Controls)

    End Sub
    '==========================================================
    ' STYLE INVENTORY HEADER TITLE
    '==========================================================

    Private Sub StyleInventoryHeaderTitle()

        lblTitle.ForeColor = TextPrimary
        lblTitle.BackColor = Color.Transparent

        lblTitle.Font = New Font(
        "Segoe UI Semibold",
        16,
        FontStyle.Bold)

    End Sub
    '==========================================================
    ' STYLE INVENTORY SUMMARY LABELS
    '==========================================================

    Private Sub StyleInventorySummary()

        lblTotalItems.ForeColor = TextSecondary
        lblTotalItems.BackColor = Color.Transparent
        lblTotalItems.Font = New Font(
            "Segoe UI Semibold",
            9,
            FontStyle.Bold)

        lblTotalAmount.ForeColor = TextSecondary
        lblTotalAmount.BackColor = Color.Transparent
        lblTotalAmount.Font = New Font(
            "Segoe UI Semibold",
            9,
            FontStyle.Bold)

    End Sub

    '==========================================================
    ' STYLE INVENTORY SEARCH / FILTER AREA
    '==========================================================

    Private Sub StyleInventoryFilters()

        ' Search box: pure white with a visible single-line border.
        txtSearch.BackColor = Color.White
        txtSearch.ForeColor = TextPrimary
        txtSearch.BorderStyle = BorderStyle.FixedSingle

        txtSearch.Font = New Font(
            "Segoe UI",
            9,
            FontStyle.Regular)

        ' Filter ComboBoxes: white fill and darker text for better contrast.
        StyleComboBox(cboFilterClassification)
        StyleComboBox(cboFilterEndUser)
        StyleComboBox(cboFilterLocation)
        StyleComboBox(cboFilterCondition)

    End Sub

    '==========================================================
    ' STYLE INVENTORY ACTION BUTTONS
    '==========================================================

    Private Sub StyleInventoryActionButtons()

        Dim buttons() As Button = {
            btnAddItem,
            btnEdit,
            btnDelete,
            btnPrintSticker,
            btnRefresh
        }

        For Each btn As Button In buttons

            btn.Height = 36

            btn.Font = New Font(
                "Segoe UI Semibold",
                9,
                FontStyle.Bold)

            btn.Cursor = Cursors.Hand

        Next

    End Sub

    '==========================================================
    ' STYLE INVENTORY DETAIL PANELS
    '==========================================================

    Private Sub StyleInventoryDetailPanels()

        pnlItemDetails.BackColor = Navy900
        pnlItemDetails.ForeColor = TextPrimary

        pnlItemMedia.BackColor = Navy900
        pnlItemMedia.ForeColor = TextPrimary

        pnlItemDetails.BorderStyle = BorderStyle.None
        pnlItemMedia.BorderStyle = BorderStyle.None

    End Sub
    '==========================================================
    ' ROUND INVENTORY DETAIL TEXTBOXES
    '==========================================================

    Private Sub StyleRoundedDetailTextBox(txt As TextBox)

        txt.BackColor = Navy800
        txt.ForeColor = TextPrimary

        txt.BorderStyle = BorderStyle.FixedSingle

        txt.Font = New Font(
        "Segoe UI",
        9,
        FontStyle.Regular)

        'Create rounded corners
        Dim radius As Integer = 8

        Dim path As New Drawing2D.GraphicsPath()

        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(txt.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(txt.Width - radius, txt.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, txt.Height - radius, radius, radius, 90, 90)

        path.CloseFigure()

        txt.Region = New Region(path)

    End Sub

    Private Sub ApplyRoundedDetailTextBoxes()

        StyleRoundedDetailTextBox(txtDetailPropertyNo)
        StyleRoundedDetailTextBox(txtDetailClassification)
        StyleRoundedDetailTextBox(txtDetailAccountCode)
        StyleRoundedDetailTextBox(txtDetailArticle)
        StyleRoundedDetailTextBox(txtDetailDescription)
        StyleRoundedDetailTextBox(txtDetailDateAcquired)

        StyleRoundedDetailTextBox(txtDetailProcurement)
        StyleRoundedDetailTextBox(txtDetailFundSource)
        StyleRoundedDetailTextBox(txtDetailSourceDocument)
        StyleRoundedDetailTextBox(txtDetailQuantity)
        StyleRoundedDetailTextBox(txtDetailUnitCost)
        StyleRoundedDetailTextBox(txtDetailUsefulLife)

        StyleRoundedDetailTextBox(txtDetailEndUser)
        StyleRoundedDetailTextBox(txtDetailLocation)
        StyleRoundedDetailTextBox(txtDetailCondition)
        StyleRoundedDetailTextBox(txtDetailPARICS)
        StyleRoundedDetailTextBox(txtDetailRemarks)

    End Sub
    '==========================================================
    ' ROUND INVENTORY DETAIL PANELS
    '==========================================================

    '==========================================================
    ' ROUNDED PANEL WITH SUBTLE BORDER
    '==========================================================

    Private Sub StyleRoundedPanel(panel As Panel, radius As Integer)

        Dim path As New System.Drawing.Drawing2D.GraphicsPath()

        Dim rect As New Rectangle(
        0,
        0,
        panel.Width - 1,
        panel.Height - 1)

        Dim diameter As Integer = radius * 2

        path.AddArc(
        rect.X,
        rect.Y,
        diameter,
        diameter,
        180,
        90)

        path.AddArc(
        rect.Right - diameter,
        rect.Y,
        diameter,
        diameter,
        270,
        90)

        path.AddArc(
        rect.Right - diameter,
        rect.Bottom - diameter,
        diameter,
        diameter,
        0,
        90)

        path.AddArc(
        rect.X,
        rect.Bottom - diameter,
        diameter,
        diameter,
        90,
        90)

        path.CloseFigure()

        panel.Region = New Region(path)

        ' Draw subtle Figma-style border
        AddHandler panel.Paint,
        Sub(sender As Object, e As PaintEventArgs)

            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias

            Using pen As New Pen(
                Color.FromArgb(203, 213, 225),
                1)

                Dim borderRect As New Rectangle(
                    0,
                    0,
                    panel.Width - 1,
                    panel.Height - 1)

                e.Graphics.DrawPath(pen, path)

            End Using

        End Sub

    End Sub

    '==========================================================
    ' APPLY ROUNDED CORNERS TO INVENTORY PANELS
    '==========================================================

    Private Sub ApplyInventoryPanelRounding()

        StyleRoundedPanel(pnlItemDetails, 12)
        StyleRoundedPanel(pnlItemMedia, 12)

    End Sub
    '==========================================================
    ' STYLE PHOTO / QR BUTTONS
    '==========================================================

    Private Sub StyleInventoryMediaButtons()

        StyleSecondaryButton(btnViewPhoto)
        StyleSecondaryButton(btnViewQR)

        btnViewPhoto.Height = 32
        btnViewQR.Height = 32

    End Sub

    '==========================================================
    ' REFINE INVENTORY GRID
    '==========================================================

    Private Sub RefineInventoryGrid()

        With dgvInventory

            .RowHeadersVisible = False

            .AllowUserToResizeRows = False

            .AllowUserToResizeColumns = False

            .AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None

            .RowTemplate.Height = 32

            .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            .ColumnHeadersHeight = 36

        End With

    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        Me.Hide()
        MainDashBoard.Show()
    End Sub

    Private Sub btnSidebarQRScan_Click(sender As Object, e As EventArgs) Handles btnSidebarQRScan.Click
        Me.Hide()
        frmQRScan.Show()
    End Sub
End Class