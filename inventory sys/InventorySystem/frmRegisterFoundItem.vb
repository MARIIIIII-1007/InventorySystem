Imports System.IO
Imports System.ComponentModel
Imports System.Data.SQLite
Public Class frmRegisterFoundItem
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ActiveSessionID As Integer = 0
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FoundItemID As Integer = 0

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property IsReviewMode As Boolean = False

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property FoundYear As Integer = DateTime.Now.Year

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property SessionLocation As String = ""
    Private Sub btnBrowsePhoto_Click(
    sender As Object,
    e As EventArgs
) Handles btnBrowsePhoto.Click

        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Item Photo"
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.Multiselect = False

            If ofd.ShowDialog(Me) = DialogResult.OK Then
                txtPhotoPath.Text = ofd.FileName
            End If
        End Using

    End Sub

    Private Sub btnSave_Click(
    sender As Object,
    e As EventArgs
) Handles btnSave.Click

        ' Confirm that a physical inventory session is active.
        If ActiveSessionID <= 0 Then
            MessageBox.Show(
            "No active physical inventory session was found.",
            "Register Found Item",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        ' Validate required fields.
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show(
            "Please enter the item description.",
            "Required Field",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtActualLocation.Text) Then
            MessageBox.Show(
            "Please enter the actual location of the item.",
            "Required Field",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            txtActualLocation.Focus()
            Return
        End If

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String

                If IsReviewMode AndAlso FoundItemID > 0 Then
                    'Update the existing found-item record.
                    sql =
                "UPDATE PhysicalInventoryUnexpectedDB SET " &
                "PropertyNo = @PropertyNo, " &
                "Description = @Description, " &
                "ActualLocation = @ActualLocation, " &
                "ObservedCondition = @ObservedCondition, " &
                "DiscrepancyNotes = @DiscrepancyNotes, " &
                "PhotoPath = @PhotoPath " &
                "WHERE ID = @ID"
                Else
                    'Register a new found item.
                    sql =
                "INSERT INTO PhysicalInventoryUnexpectedDB " &
                "(SessionID, PropertyNo, Description, ActualLocation, " &
                "ObservedCondition, DiscrepancyNotes, PhotoPath, " &
                "DateRecorded, Status) " &
                "VALUES " &
                "(@SessionID, @PropertyNo, @Description, @ActualLocation, " &
                "@ObservedCondition, @DiscrepancyNotes, @PhotoPath, " &
                "@DateRecorded, @Status)"
                End If

                Using cmd As New SQLiteCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@SessionID", ActiveSessionID)

                    cmd.Parameters.AddWithValue(
                "@PropertyNo",
                If(String.IsNullOrWhiteSpace(txtPropertyNo.Text),
                   CType(DBNull.Value, Object),
                   txtPropertyNo.Text.Trim()))

                    cmd.Parameters.AddWithValue(
                "@Description", txtDescription.Text.Trim())

                    cmd.Parameters.AddWithValue(
                "@ActualLocation", txtActualLocation.Text.Trim())

                    cmd.Parameters.AddWithValue(
                "@ObservedCondition",
                If(String.IsNullOrWhiteSpace(cmbObservedCondition.Text),
                   CType(DBNull.Value, Object),
                   cmbObservedCondition.Text.Trim()))

                    cmd.Parameters.AddWithValue(
                "@DiscrepancyNotes",
                If(String.IsNullOrWhiteSpace(txtDiscrepancyNotes.Text),
                   CType(DBNull.Value, Object),
                   txtDiscrepancyNotes.Text.Trim()))

                    cmd.Parameters.AddWithValue(
                "@PhotoPath",
                If(String.IsNullOrWhiteSpace(txtPhotoPath.Text),
                   CType(DBNull.Value, Object),
                   txtPhotoPath.Text.Trim()))

                    If IsReviewMode AndAlso FoundItemID > 0 Then
                        cmd.Parameters.AddWithValue("@ID", FoundItemID)
                    Else
                        cmd.Parameters.AddWithValue(
                    "@DateRecorded",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

                        cmd.Parameters.AddWithValue("@Status", "Pending Review")
                    End If

                    Dim affectedRows As Integer = cmd.ExecuteNonQuery()

                    If affectedRows = 0 Then
                        MessageBox.Show(
                    "The found-item record could not be updated.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                        Return
                    End If

                End Using
            End Using

            MessageBox.Show(
                If(IsReviewMode,
                   "The found-item record has been updated.",
                   "The found item has been recorded successfully." &
                   Environment.NewLine & "Status: Pending Review"),
                "Save Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
            "Unable to save the found item." &
            Environment.NewLine & ex.Message,
            "Save Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub LoadFoundItem(recordID As Integer)

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                    "SELECT PropertyNo, Description, ActualLocation, " &
                    "ObservedCondition, DiscrepancyNotes, PhotoPath, " &
                    "SessionID, Status, DateRecorded " &
                    "FROM PhysicalInventoryUnexpectedDB " &
                    "WHERE ID = @ID"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", recordID)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()

                        If Not reader.Read() Then
                            MessageBox.Show(
                                "The selected found-item record could not be found.",
                                "Found Items",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                            Return
                        End If

                        FoundItemID = recordID

                        Dim recordedDate As DateTime

                        If DateTime.TryParse(reader("DateRecorded").ToString(), recordedDate) Then
                            FoundYear = recordedDate.Year
                        Else
                            FoundYear = DateTime.Now.Year
                        End If

                        ActiveSessionID = Convert.ToInt32(reader("SessionID"))

                        txtPropertyNo.Text =
                            If(IsDBNull(reader("PropertyNo")), "",
                               reader("PropertyNo").ToString())

                        txtDescription.Text = reader("Description").ToString()
                        txtActualLocation.Text = reader("ActualLocation").ToString()

                        cmbObservedCondition.Text =
                            If(IsDBNull(reader("ObservedCondition")), "",
                               reader("ObservedCondition").ToString())

                        txtDiscrepancyNotes.Text =
                            If(IsDBNull(reader("DiscrepancyNotes")), "",
                               reader("DiscrepancyNotes").ToString())

                        txtPhotoPath.Text =
                            If(IsDBNull(reader("PhotoPath")), "",
                               reader("PhotoPath").ToString())

                        IsReviewMode = True

                    End Using
                End Using
            End Using

            Me.Text = "Review Found Item"

        Catch ex As Exception
            MessageBox.Show(
                "Unable to load the found-item record." &
                Environment.NewLine & ex.Message,
                "Found Items",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnLinkExistingProperty_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnLinkExistingProperty.Click

        If Not IsReviewMode OrElse FoundItemID <= 0 Then
            MessageBox.Show(
                "Please open an existing found-item record for review first.",
                "Link Existing Property",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim propertyNo As String = txtPropertyNo.Text.Trim()

        If String.IsNullOrWhiteSpace(propertyNo) Then
            MessageBox.Show(
                "Enter the existing property's property number first.",
                "Property Number Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            txtPropertyNo.Focus()
            Return
        End If

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()


                Dim inventoryID As Integer

                ' Count matching property numbers in master inventory.
                Dim matchingCount As Integer

                Using cmdCount As New SQLiteCommand(
                "SELECT COUNT(*) FROM InventoryDB " &
                "WHERE TRIM(PropertyNo) = TRIM(@PropertyNo)", conn)

                    cmdCount.Parameters.AddWithValue(
                    "@PropertyNo", propertyNo)

                    matchingCount = Convert.ToInt32(cmdCount.ExecuteScalar())

                End Using

                ' Do not link if no matching property exists.
                If matchingCount = 0 Then

                    MessageBox.Show(
                        "No matching property was found in InventoryDB." &
                        Environment.NewLine &
                        "Verify the property number before linking.",
                        "Property Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    Return

                End If

                ' Do not link if multiple master records share the same number.
                If matchingCount > 1 Then

                    MessageBox.Show(
                        "This property number is assigned to " &
                        matchingCount.ToString() & " records in InventoryDB." &
                        Environment.NewLine & Environment.NewLine &
                        "Linking has been blocked to prevent linking the wrong item." &
                        Environment.NewLine &
                        "Please resolve the duplicate property numbers first.",
                        "Duplicate Property Number",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

                    Return

                End If


                ' Retrieve the existing property's ID and description.
                Dim masterDescription As String = ""

                Using cmdFind As New SQLiteCommand(
                    "SELECT ID, Description FROM InventoryDB " &
                    "WHERE TRIM(PropertyNo) = TRIM(@PropertyNo)", conn)

                    cmdFind.Parameters.AddWithValue("@PropertyNo", propertyNo)

                    Using reader As SQLiteDataReader = cmdFind.ExecuteReader()

                        If Not reader.Read() Then
                            MessageBox.Show(
                                "The matching property could not be retrieved.",
                                "Link Not Completed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                            Return
                        End If

                        inventoryID = Convert.ToInt32(reader("ID"))

                        masterDescription =
            If(IsDBNull(reader("Description")),
               "",
               reader("Description").ToString().Trim())

                    End Using
                End Using

                ' Prevent linking when the descriptions differ.
                Dim foundDescription As String = txtDescription.Text.Trim()

                If Not String.Equals(
                    foundDescription,
                    masterDescription,
                    StringComparison.OrdinalIgnoreCase) Then

                    MessageBox.Show(
                        "The property number exists, but the item descriptions do not match." &
                        Environment.NewLine & Environment.NewLine &
                        "Found item: " & foundDescription &
                        Environment.NewLine &
                        "Existing property: " & masterDescription &
                        Environment.NewLine & Environment.NewLine &
                        "Linking has been blocked. Verify the physical item or register it as a new property.",
                        "Item Mismatch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                    Return
                End If



                ' Link the found-item record to the master inventory record.
                Using cmdUpdate As New SQLiteCommand(
                    "UPDATE PhysicalInventoryUnexpectedDB " &
                    "SET LinkedInventoryID = @InventoryID, " &
                    "Status = 'Linked to Existing' " &
                    "WHERE ID = @FoundItemID " &
                    "AND Status = 'Pending Review'", conn)

                    cmdUpdate.Parameters.AddWithValue(
                        "@InventoryID", inventoryID)

                    cmdUpdate.Parameters.AddWithValue(
                        "@FoundItemID", FoundItemID)

                    If cmdUpdate.ExecuteNonQuery() = 0 Then
                        MessageBox.Show(
                            "The found-item record was not updated." &
                            Environment.NewLine &
                            "It may no longer be pending review.",
                            "Link Not Completed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            MessageBox.Show(
                "The found item has been linked to the existing property.",
                "Link Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(
                "Unable to link the existing property." &
                Environment.NewLine & ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnRegisterNewProperty_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegisterNewProperty.Click

        If Not IsReviewMode OrElse FoundItemID <= 0 Then
            MessageBox.Show(
                "Open an existing found-item record before registering it as a new property.",
                "Registration",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtDescription.Text) OrElse
           String.IsNullOrWhiteSpace(txtActualLocation.Text) Then

            MessageBox.Show(
                "Please provide the Description and Actual Location first.",
                "Missing Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Using addForm As New frmAddItem()

            addForm.IsFoundItemRegistration = True
            addForm.FoundYear = FoundYear
            addForm.FoundItemIDToLink = FoundItemID
            addForm.FoundItemDescription = txtDescription.Text.Trim()
            addForm.FoundItemLocation = txtActualLocation.Text.Trim()
            addForm.FoundItemCondition = cmbObservedCondition.Text.Trim()
            addForm.FoundItemPhotoPath = txtPhotoPath.Text.Trim()

            If addForm.ShowDialog() <> DialogResult.OK Then
                Return
            End If

            If String.IsNullOrWhiteSpace(addForm.SavedPropertyNo) Then
                MessageBox.Show(
                    "The new property number was not returned. " &
                    "The found-item record has not been updated.",
                    "Registration Incomplete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
                Return
            End If

            Try
                InitializeDatabase()

                Using conn As New SQLiteConnection(ConnString)
                    conn.Open()

                    Dim sql As String =
                        "UPDATE PhysicalInventoryUnexpectedDB " &
                        "SET PropertyNo = @PropertyNo, Status = @Status " &
                        "WHERE ID = @ID AND Status = 'Pending Review'"

                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.Parameters.AddWithValue(
                            "@PropertyNo", addForm.SavedPropertyNo.Trim())
                        cmd.Parameters.AddWithValue(
                            "@Status", "Registered")
                        cmd.Parameters.AddWithValue(
                            "@ID", FoundItemID)

                        If cmd.ExecuteNonQuery() <> 1 Then
                            MessageBox.Show(
                                "The property was saved, but the found-item " &
                                "record could not be updated. Refresh and " &
                                "verify both records before trying again.",
                                "Linking Incomplete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                End Using

                MessageBox.Show(
                    "The new property was saved and the found-item record was updated." &
                    Environment.NewLine &
                    "Property No.: " & addForm.SavedPropertyNo,
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As Exception
                MessageBox.Show(
                    "The property was saved, but updating the found-item record failed." &
                    Environment.NewLine & ex.Message,
                    "Linking Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try

        End Using

    End Sub
    Private Sub frmRegisterFoundItem_Load(
    sender As Object,
    e As EventArgs
) Handles MyBase.Load

        cmbObservedCondition.Items.Clear()

        cmbObservedCondition.Items.AddRange(
            New Object() {
                "Serviceable",
                "For Repair",
                "Unserviceable",
                "Damaged",
                "Missing Parts",
                "For Inspection",
                "Other"
            }
        )

        cmbObservedCondition.DropDownStyle =
            ComboBoxStyle.DropDownList

        ' Auto-fill location for new found-item registrations.
        ' Do not overwrite the saved location in review mode.
        If Not IsReviewMode AndAlso
           Not String.IsNullOrWhiteSpace(SessionLocation) Then

            txtActualLocation.Text = SessionLocation

        End If

    End Sub
End Class