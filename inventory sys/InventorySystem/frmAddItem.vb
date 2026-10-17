Imports System.Data.SQLite
Imports System.IO
Imports QRCoder
Imports ZXing
Imports ZXing.Common
Public Class frmAddItem
    Public IsEditMode As Boolean = False
    Public EditID As Integer

    Public IsFoundItemRegistration As Boolean = False
    Public FoundYear As Integer = 0
    Public FoundItemIDToLink As Integer = 0
    Public FoundItemDescription As String = ""
    Public FoundItemLocation As String = ""
    Public FoundItemCondition As String = ""
    Public FoundItemPhotoPath As String = ""

    Public SavedPropertyNo As String = ""

    Public SelectedPhotoPath As String = ""
    Private Sub frmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCategory.Items.Add("PPE")
        cboCategory.Items.Add("Semi-Expendable")

        cboCategory.Enabled = False
        txtPropertyNo.ReadOnly = True

        cboEndUser.Items.Add("WESTMINCOM")
        cboEndUser.Items.Add("5thFASU")
        cboEndUser.Items.Add("16FSU")
        cboEndUser.Items.Add("5CEISG")
        cboEndUser.Items.Add("CNGH")
        cboEndUser.Items.Add("CNVSU")
        cboEndUser.Items.Add("CNDD")

        cboCondition.Items.Add("Serviceable")
        cboCondition.Items.Add("Repairable")
        cboCondition.Items.Add("Unserviceable")
        cboCondition.Items.Add("For Disposal")

        cboFundSource.Items.Add("Regular Agency Fund")
        cboFundSource.Items.Add("Trust Receipt Fund")
        cboFundSource.Items.Add("AFP MATF")

        cboProcurement.Items.Add("Purchase")
        cboProcurement.Items.Add("Transfer")
        cboProcurement.Items.Add("Donation")
        cboProcurement.Items.Add("Found at Station")

        cboAccountCode.Items.Add("Furniture and Fixtures")
        cboAccountCode.Items.Add("Office Equipment")
        cboAccountCode.Items.Add("Communication Equipment")
        cboAccountCode.Items.Add("Information and Communication Technology Equipment")
        cboAccountCode.Items.Add("Disaster Risk and Response Equipment")
        cboAccountCode.Items.Add("Motor Vehicle")
        cboAccountCode.Items.Add("Military, Police and Security Equipment")
        cboAccountCode.Items.Add("Other Machinery and Equipment")
        cboAccountCode.Items.Add("Books")


        If IsEditMode Then

            LoadItemForEdit()

        ElseIf IsFoundItemRegistration Then

            ' Prefill details from the found-item review.
            txtDescription.Text = FoundItemDescription
            cboLocation.Text = FoundItemLocation

            If Not String.IsNullOrWhiteSpace(FoundItemCondition) Then
                cboCondition.Text = FoundItemCondition
            End If

            ' Preserve the photo path for saving with the new property.
            SelectedPhotoPath = FoundItemPhotoPath

            ' Identify the acquisition method without inventing
            ' a purchase price or acquisition date.
            cboProcurement.Text = "Found at Station"

        End If

        ' Display only the acquisition year
        dtpDateAcquired.Format = DateTimePickerFormat.Custom
        dtpDateAcquired.CustomFormat = "yyyy"
        dtpDateAcquired.ShowUpDown = True

    End Sub
    Private Sub LoadItemForEdit()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
            "SELECT * FROM InventoryDB WHERE ID=@ID"

            Using cmd As New SQLiteCommand(sql, conn)

                cmd.Parameters.AddWithValue("@ID", EditID)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    If reader.Read() Then

                        'Basic information
                        txtPropertyNo.Text =
                        reader("PropertyNo").ToString()

                        txtDescription.Text =
                        reader("Description").ToString()

                        cboCategory.Text =
                        reader("Category").ToString()

                        cboCondition.Text =
                        reader("Condition").ToString()

                        cboAccountCode.Text =
                        reader("AccountCode").ToString()

                        cboArticle.Text =
                        reader("Article").ToString()

                        'Procurement information
                        If Not IsDBNull(reader("DateAcquired")) Then

                            Dim acquiredDate As DateTime

                            If DateTime.TryParse(
                            reader("DateAcquired").ToString(),
                            acquiredDate) Then

                                dtpDateAcquired.Value = acquiredDate

                            End If

                        End If

                        cboProcurement.Text =
                        reader("Procurement").ToString()

                        cboFundSource.Text =
                        reader("FundSource").ToString()

                        txtSourceDoc.Text =
                        reader("SourceDocument").ToString()

                        txtUnitCost.Text =
                        reader("UnitCost").ToString()

                        txtQuantity.Text =
                        reader("Quantity").ToString()

                        txtEUL.Text =
                        reader("EUL").ToString()

                        'Location / End User
                        cboLocation.Text =
                        reader("Location").ToString()

                        cboEndUser.Text =
                        reader("EndUser").ToString()

                        txtRemarks.Text =
                        reader("Remarks").ToString()

                        'Photo
                        SelectedPhotoPath =
                        reader("PhotoPath").ToString()

                        If Not String.IsNullOrWhiteSpace(SelectedPhotoPath) AndAlso
                       File.Exists(SelectedPhotoPath) Then

                            Using tempImage As Image =
                            Image.FromFile(SelectedPhotoPath)

                                picItemPhoto.Image =
                                New Bitmap(tempImage)

                            End Using

                        Else

                            picItemPhoto.Image = Nothing

                        End If

                    End If

                End Using

            End Using

        End Using

    End Sub
    Private Function GenerateQRCode() As String

        If String.IsNullOrWhiteSpace(txtPropertyNo.Text) Then
            Return ""
        End If

        Dim qrFolder As String =
        Path.Combine(Application.StartupPath, "QR Codes")

        If Not Directory.Exists(qrFolder) Then
            Directory.CreateDirectory(qrFolder)
        End If

        Dim qrFileName As String =
        txtPropertyNo.Text.Trim().Replace("/", "-") & ".png"

        Dim qrPath As String =
        Path.Combine(qrFolder, qrFileName)

        Dim qrText As String =
        "Property No.: " & txtPropertyNo.Text.Trim() & vbCrLf &
        "Description: " & txtDescription.Text.Trim() & vbCrLf &
        "Location: " & cboLocation.Text.Trim() & vbCrLf &
        "Date Acquired: " & dtpDateAcquired.Value.ToString("yyyy-MM-dd") & vbCrLf &
        "Procurement: " & cboProcurement.Text.Trim()

        Using generator As New QRCodeGenerator()

            Using qrData As QRCodeData =
            generator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q)

                Using qrCode As New QRCode(qrData)

                    Using qrImage As Bitmap = qrCode.GetGraphic(10)

                        qrImage.Save(qrPath,
                                 Imaging.ImageFormat.Png)

                    End Using

                End Using

            End Using

        End Using

        Return qrPath

    End Function

    Private Function GenerateBarcode() As String

        If String.IsNullOrWhiteSpace(txtPropertyNo.Text) Then
            Return ""
        End If

        Dim barcodeFolder As String =
        Path.Combine(Application.StartupPath, "Barcodes")

        If Not Directory.Exists(barcodeFolder) Then
            Directory.CreateDirectory(barcodeFolder)
        End If

        Dim barcodeFileName As String =
        txtPropertyNo.Text.Trim().Replace("/", "-") & ".png"

        Dim barcodePath As String =
        Path.Combine(barcodeFolder, barcodeFileName)

        Dim writer As New ZXing.Windows.Compatibility.BarcodeWriter With {
        .Format = BarcodeFormat.CODE_128,
        .Options = New EncodingOptions With {
            .Width = 600,
            .Height = 150,
            .Margin = 10
        }
    }

        Using barcodeImage As Bitmap = writer.Write(txtPropertyNo.Text.Trim())
            barcodeImage.Save(barcodePath, Imaging.ImageFormat.Png)
        End Using

        Return barcodePath

    End Function
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Public Sub InitializeDatabase()

        If Not File.Exists(DBPath) Then
            SQLiteConnection.CreateFile(DBPath)
        End If

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            'Create table if it does not exist
            Dim createSQL As String =
            "CREATE TABLE IF NOT EXISTS InventoryDB (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "PropertyNo TEXT, " &
            "Description TEXT, " &
            "Category TEXT, " &
            "Condition TEXT, " &
            "AccountCode TEXT, " &
            "Article TEXT, " &
            "DateAcquired TEXT, " &
            "Procurement TEXT, " &
            "FundSource TEXT, " &
            "SourceDocument TEXT, " &
            "UnitCost REAL, " &
            "Quantity INTEGER, " &
            "EUL TEXT, " &
            "Location TEXT, " &
            "EndUser TEXT, " &
            "Remarks TEXT, " &
           "PhotoPath TEXT, " &
            "QRCodePath TEXT, " &
            "BarcodePath TEXT" &
            ")"

            Using cmd As New SQLiteCommand(createSQL, conn)
                cmd.ExecuteNonQuery()
            End Using

            'Check whether EUL already exists
            Dim eulExists As Boolean = False

            Using cmd As New SQLiteCommand(
            "PRAGMA table_info(InventoryDB)", conn)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        Dim columnName As String =
                        reader("name").ToString()

                        If columnName.Equals("EUL",
                                         StringComparison.OrdinalIgnoreCase) Then

                            eulExists = True
                            Exit While

                        End If

                    End While

                End Using

            End Using

            'Add EUL to an existing database if necessary
            If Not eulExists Then

                Using cmd As New SQLiteCommand(
                "ALTER TABLE InventoryDB ADD COLUMN EUL TEXT",
                conn)

                    cmd.ExecuteNonQuery()

                End Using


            End If

            ' Check whether BarcodePath column exists
            Dim barcodeColumnExists As Boolean = False

            Using checkCmd As New SQLiteCommand(
                "PRAGMA table_info(InventoryDB)", conn)

                Using reader As SQLiteDataReader = checkCmd.ExecuteReader()

                    While reader.Read()
                        If reader("name").ToString().Equals(
                            "BarcodePath",
                            StringComparison.OrdinalIgnoreCase) Then

                            barcodeColumnExists = True
                            Exit While

                        End If
                    End While

                End Using
            End Using

            ' Add BarcodePath if it is missing
            If Not barcodeColumnExists Then

                Using alterCmd As New SQLiteCommand(
                    "ALTER TABLE InventoryDB ADD COLUMN BarcodePath TEXT", conn)

                    alterCmd.ExecuteNonQuery()

                End Using

            End If

        End Using

        ' Keep the shared schema migrations in sync when this form initializes
        ' the database directly, rather than relying only on Dashboard startup.
        modDatabase.InitializeDatabase()

    End Sub

    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click

        Using dialog As New OpenFileDialog()

            dialog.Title = "Select Item Photo"
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*"
            dialog.Multiselect = False

            If dialog.ShowDialog() = DialogResult.OK Then

                Try
                    'Load a copy of the image so the original file is not locked
                    Using tempImage As Image = Image.FromFile(dialog.FileName)
                        picItemPhoto.Image = New Bitmap(tempImage)
                    End Using

                    'Remember the selected file path
                    SelectedPhotoPath = dialog.FileName

                Catch ex As Exception

                    MessageBox.Show(
                    "Unable to load the selected image." &
                    vbCrLf & vbCrLf & ex.Message,
                    "Photo Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                End Try

            End If

        End Using

    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        'Basic validation
        If IsEditMode AndAlso txtPropertyNo.Text.Trim() = "" Then

            MessageBox.Show(
                "The existing Property No. is missing.",
                "Missing Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If

        If txtDescription.Text.Trim() = "" Then
            MessageBox.Show("Please enter the Description.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtDescription.Focus()
            Exit Sub
        End If

        If cboCategory.Text.Trim() = "" Then
            MessageBox.Show("Please select the Category.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            cboCategory.Focus()
            Exit Sub
        End If

        If cboCondition.Text.Trim() = "" Then
            MessageBox.Show("Please select the Condition.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            cboCondition.Focus()
            Exit Sub
        End If

        'Validate Unit Cost
        Dim unitCost As Double = 0

        If txtUnitCost.Text.Trim() <> "" Then

            If Not Double.TryParse(txtUnitCost.Text, unitCost) Then
                MessageBox.Show("Please enter a valid Unit Cost.",
                            "Invalid Unit Cost",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                txtUnitCost.Focus()
                Exit Sub
            End If

        End If

        'Validate Quantity
        Dim quantity As Integer = 0

        If txtQuantity.Text.Trim() <> "" Then

            If Not Integer.TryParse(txtQuantity.Text, quantity) Then
                MessageBox.Show("Please enter a valid Quantity.",
                            "Invalid Quantity",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                txtQuantity.Focus()
                Exit Sub
            End If

        End If

        '=========================================
        ' GENERATE FINAL PROPERTY NUMBER
        '=========================================

        If Not IsEditMode Then

            If String.IsNullOrWhiteSpace(cboAccountCode.Text) Then

                MessageBox.Show(
                    "Please select the Account Code.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                cboAccountCode.Focus()
                Exit Sub

            End If

            Dim finalPropertyNo As String =
            GeneratePropertyNumber(
                cboAccountCode.Text.Trim(),
                unitCost,
                cboArticle.Text.Trim(),
                If(IsFoundItemRegistration AndAlso FoundYear > 0,
                   FoundYear,
                   dtpDateAcquired.Value.Year))

            If String.IsNullOrWhiteSpace(finalPropertyNo) Then

                MessageBox.Show(
                    "Unable to generate the Property Number." &
                    vbCrLf & vbCrLf &
                    "Please check the Account Code and Unit Cost.",
                    "Property Number Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                Exit Sub

            End If

            ' Verify that the generated property number is unique.
            If PropertyNumberExists(finalPropertyNo) Then

                MessageBox.Show(
                    "The generated property number already exists, " &
                    "or its uniqueness could not be verified." &
                    vbCrLf & vbCrLf &
                    "Property Number: " & finalPropertyNo &
                    vbCrLf & vbCrLf &
                    "The item was NOT saved. Please check the property number sequence.",
                    "Duplicate Property Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)

                Exit Sub

            End If

            txtPropertyNo.Text = finalPropertyNo


        End If

        InitializeDatabase()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            If IsEditMode = False Then

                '=========================================
                ' ADD NEW ITEM
                '=========================================

                Dim sql As String =
                "INSERT INTO InventoryDB " &
                "(PropertyNo, Description, Category, Condition, " &
                "AccountCode, Article, DateAcquired, Procurement, " &
                "FundSource, SourceDocument, UnitCost, Quantity, EUL, " &
                "Location, EndUser, Remarks, PhotoPath, QRCodePath, BarcodePath) " &
                "VALUES " &
                "(@PropertyNo, @Description, @Category, @Condition, " &
                "@AccountCode, @Article, @DateAcquired, @Procurement, " &
                "@FundSource, @SourceDocument, @UnitCost, @Quantity, @EUL, " &
                "@Location, @EndUser, @Remarks, @PhotoPath, @QRCodePath, @BarcodePath)"

                Using cmd As New SQLiteCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@PropertyNo",
                                             txtPropertyNo.Text.Trim())

                    cmd.Parameters.AddWithValue("@Description",
                                             txtDescription.Text.Trim())

                    cmd.Parameters.AddWithValue("@Category",
                                             cboCategory.Text.Trim())

                    cmd.Parameters.AddWithValue("@Condition",
                                             cboCondition.Text.Trim())

                    cmd.Parameters.AddWithValue("@AccountCode",
                                             cboAccountCode.Text.Trim())

                    cmd.Parameters.AddWithValue("@Article",
                                             cboArticle.Text.Trim())

                    cmd.Parameters.AddWithValue("@DateAcquired",
                        dtpDateAcquired.Value.ToString("yyyy"))

                    cmd.Parameters.AddWithValue("@Procurement",
                                             cboProcurement.Text.Trim())

                    cmd.Parameters.AddWithValue("@FundSource",
                                             cboFundSource.Text.Trim())

                    cmd.Parameters.AddWithValue("@SourceDocument",
                                             txtSourceDoc.Text.Trim())

                    cmd.Parameters.AddWithValue("@UnitCost",
                                             unitCost)

                    cmd.Parameters.AddWithValue("@Quantity",
                                             quantity)

                    cmd.Parameters.AddWithValue("@EUL",
                                             txtEUL.Text.Trim())

                    cmd.Parameters.AddWithValue("@Location",
                                             cboLocation.Text.Trim())

                    cmd.Parameters.AddWithValue("@EndUser",
                                             cboEndUser.Text.Trim())

                    cmd.Parameters.AddWithValue("@Remarks",
                                             txtRemarks.Text.Trim())

                    'Photo and QR will be connected later

                    cmd.Parameters.AddWithValue("@PhotoPath", SelectedPhotoPath)

                    Dim qrPath As String = GenerateQRCode()
                    cmd.Parameters.AddWithValue("@QRCodePath", qrPath)

                    Dim barcodePath As String = GenerateBarcode()
                    cmd.Parameters.AddWithValue("@BarcodePath", barcodePath)

                    cmd.ExecuteNonQuery()

                End Using

            Else

                '=========================================
                ' EDIT EXISTING ITEM
                '=========================================

                ' Capture the previous accountability values before saving edits.
                Dim previousEndUser As String = String.Empty
                Dim previousLocation As String = String.Empty

                Using cmdPrevious As New SQLiteCommand(
                    "SELECT EndUser, Location FROM InventoryDB WHERE ID = @ID", conn)

                    cmdPrevious.Parameters.AddWithValue("@ID", EditID)

                    Using readerPrevious As SQLiteDataReader = cmdPrevious.ExecuteReader()
                        If Not readerPrevious.Read() Then
                            MessageBox.Show(
                                "The selected property record could not be found. No changes were saved.",
                                "Property Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        If Not IsDBNull(readerPrevious("EndUser")) Then
                            previousEndUser = readerPrevious("EndUser").ToString().Trim()
                        End If
                        If Not IsDBNull(readerPrevious("Location")) Then
                            previousLocation = readerPrevious("Location").ToString().Trim()
                        End If
                    End Using
                End Using

                Dim newEndUser As String = cboEndUser.Text.Trim()
                Dim newLocation As String = cboLocation.Text.Trim()
                Dim endUserChanged As Boolean = Not String.Equals(
                    previousEndUser, newEndUser, StringComparison.OrdinalIgnoreCase)
                Dim locationChanged As Boolean = Not String.Equals(
                    previousLocation, newLocation, StringComparison.OrdinalIgnoreCase)
                Dim changeReason As String = String.Empty

                If endUserChanged OrElse locationChanged Then
                    changeReason = Microsoft.VisualBasic.Interaction.InputBox(
                        "You changed the accountable person/end user and/or item location." & vbCrLf & vbCrLf &
                        "Enter the reason for this change. The property will be flagged for accountability review.",
                        "Accountability Change Reason", String.Empty).Trim()

                    If String.IsNullOrWhiteSpace(changeReason) Then
                        MessageBox.Show(
                            "A reason is required to record an accountable person or location change. No changes were saved.",
                            "Reason Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                Using transaction As SQLiteTransaction = conn.BeginTransaction()

                Dim sql As String =
                "UPDATE InventoryDB SET " &
                "PropertyNo=@PropertyNo, " &
                "Description=@Description, " &
                "Category=@Category, " &
                "Condition=@Condition, " &
                "AccountCode=@AccountCode, " &
                "Article=@Article, " &
                "DateAcquired=@DateAcquired, " &
                "Procurement=@Procurement, " &
                "FundSource=@FundSource, " &
                "SourceDocument=@SourceDocument, " &
                "UnitCost=@UnitCost, " &
                "Quantity=@Quantity, " &
                "EUL=@EUL, " &
                "Location=@Location, " &
                "EndUser=@EndUser, " &
                "Remarks=@Remarks, " &
                "PhotoPath=@PhotoPath, " &
                "QRCodePath=@QRCodePath, " &
                "BarcodePath=@BarcodePath " &
                "WHERE ID=@ID"


                Using cmd As New SQLiteCommand(sql, conn)

                    cmd.Transaction = transaction

                    cmd.Parameters.AddWithValue("@PropertyNo",
                                             txtPropertyNo.Text.Trim())

                    cmd.Parameters.AddWithValue("@Description",
                                             txtDescription.Text.Trim())

                    cmd.Parameters.AddWithValue("@Category",
                                             cboCategory.Text.Trim())

                    cmd.Parameters.AddWithValue("@Condition",
                                             cboCondition.Text.Trim())

                    cmd.Parameters.AddWithValue("@AccountCode",
                                             cboAccountCode.Text.Trim())

                    cmd.Parameters.AddWithValue("@Article",
                                             cboArticle.Text.Trim())

                    cmd.Parameters.AddWithValue("@DateAcquired",
                                             dtpDateAcquired.Value.ToString("yyyy-MM-dd"))

                    cmd.Parameters.AddWithValue("@Procurement",
                                             cboProcurement.Text.Trim())

                    cmd.Parameters.AddWithValue("@FundSource",
                                             cboFundSource.Text.Trim())

                    cmd.Parameters.AddWithValue("@SourceDocument",
                                             txtSourceDoc.Text.Trim())

                    cmd.Parameters.AddWithValue("@UnitCost",
                                             unitCost)

                    cmd.Parameters.AddWithValue("@Quantity",
                                             quantity)

                    cmd.Parameters.AddWithValue("@EUL",
                                             txtEUL.Text.Trim())

                    cmd.Parameters.AddWithValue("@Location",
                                             cboLocation.Text.Trim())

                    cmd.Parameters.AddWithValue("@EndUser",
                                             cboEndUser.Text.Trim())

                    cmd.Parameters.AddWithValue("@Remarks",
                                             txtRemarks.Text.Trim())

                    cmd.Parameters.AddWithValue("@PhotoPath", SelectedPhotoPath)

                    Dim qrPath As String = GenerateQRCode()
                    cmd.Parameters.AddWithValue("@QRCodePath", qrPath)

                    Dim barcodePath As String = GenerateBarcode()
                    cmd.Parameters.AddWithValue("@BarcodePath", barcodePath)

                    cmd.Parameters.AddWithValue("@ID", EditID)


                    cmd.ExecuteNonQuery()

                End Using

                If endUserChanged OrElse locationChanged Then
                    Dim changeType As String
                    If endUserChanged AndAlso locationChanged Then
                        changeType = "End User and Location Changed"
                    ElseIf endUserChanged Then
                        changeType = "End User Changed"
                    Else
                        changeType = "Location Changed"
                    End If

                    Using cmdHistory As New SQLiteCommand(
                        "INSERT INTO AccountabilityHistory " &
                        "(InventoryID, ChangeType, PreviousEndUser, NewEndUser, " &
                        "PreviousLocation, NewLocation, ChangeDate, ChangeReason, " &
                        "ReviewStatus, ChangedBy) " &
                        "VALUES (@InventoryID, @ChangeType, @PreviousEndUser, @NewEndUser, " &
                        "@PreviousLocation, @NewLocation, @ChangeDate, @ChangeReason, " &
                        "@ReviewStatus, @ChangedBy)", conn, transaction)

                        cmdHistory.Parameters.AddWithValue("@InventoryID", EditID)
                        cmdHistory.Parameters.AddWithValue("@ChangeType", changeType)
                        cmdHistory.Parameters.AddWithValue("@PreviousEndUser", previousEndUser)
                        cmdHistory.Parameters.AddWithValue("@NewEndUser", newEndUser)
                        cmdHistory.Parameters.AddWithValue("@PreviousLocation", previousLocation)
                        cmdHistory.Parameters.AddWithValue("@NewLocation", newLocation)
                        cmdHistory.Parameters.AddWithValue("@ChangeDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmdHistory.Parameters.AddWithValue("@ChangeReason", changeReason)
                        cmdHistory.Parameters.AddWithValue("@ReviewStatus", "Pending Review")
                        cmdHistory.Parameters.AddWithValue("@ChangedBy", Environment.UserName)
                        cmdHistory.ExecuteNonQuery()
                    End Using
                End If

                transaction.Commit()
                End Using

            End If

        End Using


        ' Return the generated property number after saving.
        SavedPropertyNo = txtPropertyNo.Text.Trim()

        ' Refresh the Inventory form if it is open.
        If frmInventory.InventoryFormInstance IsNot Nothing Then
            frmInventory.InventoryFormInstance.LoadInventory()
        End If

        ' Return control to the found-item review workflow.
        If IsFoundItemRegistration Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Return
        End If

        ' Preserve the normal Add Item / Edit Item workflow.
        MessageBox.Show("Item saved successfully!",
                        "Inventory System",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        Me.Close()


    End Sub

    Private Sub cboAccountCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountCode.SelectedIndexChanged
        cboArticle.Items.Clear()

        If cboAccountCode.Text = "Furniture and Fixtures" Then

            cboArticle.Items.Add("Table")
            cboArticle.Items.Add("Chair")
            cboArticle.Items.Add("Bed")
            cboArticle.Items.Add("Cabinet")
            cboArticle.Items.Add("Sala Set")
            cboArticle.Items.Add("Décor")
            cboArticle.Items.Add("Board")
            cboArticle.Items.Add("Dining Set")
            cboArticle.Items.Add("Flag Stand")
            cboArticle.Items.Add("Bench")
            cboArticle.Items.Add("Vault")
            cboArticle.Items.Add("Drawer")
            cboArticle.Items.Add("Divider")
            cboArticle.Items.Add("Podium")
            cboArticle.Items.Add("Coffee Placer")
            cboArticle.Items.Add("Mirror")
            cboArticle.Items.Add("Musical Instrument")

        ElseIf cboAccountCode.Text = "Office Equipment" Then

            cboArticle.Items.Add("Airconditioner")
            cboArticle.Items.Add("Shredding Machine")
            cboArticle.Items.Add("Binding Machine")
            cboArticle.Items.Add("Paper Cutter")
            cboArticle.Items.Add("Laminating Machine")

        ElseIf cboAccountCode.Text = "Information and Communication Technology Equipment" Then

            cboArticle.Items.Add("Computer")
            cboArticle.Items.Add("Laptop")
            cboArticle.Items.Add("UPS")
            cboArticle.Items.Add("External Drive")
            cboArticle.Items.Add("Printer")
            cboArticle.Items.Add("WAP")
            cboArticle.Items.Add("NAS")

        ElseIf cboAccountCode.Text = "Communication Equipment" Then

            cboArticle.Items.Add("Television")
            cboArticle.Items.Add("Telephone")
            cboArticle.Items.Add("Camera")
            cboArticle.Items.Add("Audio-Visual")
            cboArticle.Items.Add("Sound System")
            cboArticle.Items.Add("Conference Microphone")
            cboArticle.Items.Add("Recorder")
            cboArticle.Items.Add("Base Radio")

        ElseIf cboAccountCode.Text = "Disaster Risk and Response Equipment" Then

            cboArticle.Items.Add("Fire Extinguisher")

        ElseIf cboAccountCode.Text = "Motor Vehicle" Then

            cboArticle.Items.Add("Utility Vehicle")
            cboArticle.Items.Add("Motorcycle")
            cboArticle.Items.Add("Military Truck")

        ElseIf cboAccountCode.Text = "Military, Police and Security Equipment" Then

            cboArticle.Items.Add("Rifle")
            cboArticle.Items.Add("Pistol")
            cboArticle.Items.Add("Ammunition")
            cboArticle.Items.Add("Magazines")

        ElseIf cboAccountCode.Text = "Other Machinery and Equipment" Then

            cboArticle.Items.Add("Generator")
            cboArticle.Items.Add("Concrete Mixer")
            cboArticle.Items.Add("Washing Machine")
            cboArticle.Items.Add("Fan")
            cboArticle.Items.Add("Refrigerator")
            cboArticle.Items.Add("Water Dispenser")
            cboArticle.Items.Add("Coffee Maker")
            cboArticle.Items.Add("Aircooler")
            cboArticle.Items.Add("Welding Machine")
            cboArticle.Items.Add("Grass Cutter")
            cboArticle.Items.Add("Blower")
            cboArticle.Items.Add("Aircompressor")
            cboArticle.Items.Add("Chainsaw")
            cboArticle.Items.Add("Pallet")
            cboArticle.Items.Add("Pallet Jack")
            cboArticle.Items.Add("Mower")

        ElseIf cboAccountCode.Text = "Books" Then

            cboArticle.Items.Add("Books")

        End If

        UpdatePropertyNumberPreview()

    End Sub

    Private Sub cboEndUser_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboEndUser.SelectedIndexChanged

        cboLocation.Items.Clear()
        cboLocation.Text = ""

        Select Case cboEndUser.Text

            Case "WESTMINCOM"

                cboLocation.Items.Add("OCWMC")
                cboLocation.Items.Add("DC EDO")
                cboLocation.Items.Add("DC IDO")
                cboLocation.Items.Add("CUCS")
                cboLocation.Items.Add("OU1")
                cboLocation.Items.Add("OU2")
                cboLocation.Items.Add("OU3")
                cboLocation.Items.Add("OU4")
                cboLocation.Items.Add("OU5")
                cboLocation.Items.Add("OU6")
                cboLocation.Items.Add("OU7")
                cboLocation.Items.Add("OU8")
                cboLocation.Items.Add("OU9")
                cboLocation.Items.Add("OU10")
                cboLocation.Items.Add("OCIA")
                cboLocation.Items.Add("OCIG")
                cboLocation.Items.Add("OESPA")
                cboLocation.Items.Add("OCSM")
                cboLocation.Items.Add("CPAB")
                cboLocation.Items.Add("COC")
                cboLocation.Items.Add("JAGO")
                cboLocation.Items.Add("HHC")
                cboLocation.Items.Add("OSAO")
                cboLocation.Items.Add("ORSO")
                cboLocation.Items.Add("HHC, FINANCE")
                cboLocation.Items.Add("GAS DUMP")
                cboLocation.Items.Add("CPIO")
                cboLocation.Items.Add("HHC. MTS")
                cboLocation.Items.Add("BAUTISTA LOUNGE")
                cboLocation.Items.Add("LAONG LAAN")
                cboLocation.Items.Add("WMC CONFERENCE ROOM ALPHA")
                cboLocation.Items.Add("WMC CONFERENCE ROOM BRAVO")
                cboLocation.Items.Add("WMC CONFERENCE ROOM CHARLIE")
                cboLocation.Items.Add("OCLUB HALL")
                cboLocation.Items.Add("EISSEN HOWER, MANSION")
                cboLocation.Items.Add("KHADAFI MANSION")
                cboLocation.Items.Add("SECURITY BARRACKS")

            Case "5thFASU"

                cboLocation.Items.Add("5thFASU")

            Case "16FSU"

                cboLocation.Items.Add("16FSU")

            Case "5CEISG"

                cboLocation.Items.Add("5CEISG")

            Case "CNGH"

                cboLocation.Items.Add("OPERATING ROOM")
                cboLocation.Items.Add("EMERGENCY ROOM")

            Case "CNVSU"

                cboLocation.Items.Add("CNVSU")

            Case "CNDD"

                cboLocation.Items.Add("CNDD")

        End Select

    End Sub
    Private Sub UpdatePropertyNumberPreview()

        '=========================================
        ' NEED AN ACCOUNT CODE
        '=========================================

        If String.IsNullOrWhiteSpace(cboAccountCode.Text) Then

            cboCategory.Text = ""
            txtEUL.Clear()

            If Not IsEditMode Then
                txtPropertyNo.Clear()
            End If

            Exit Sub

        End If


        '=========================================
        ' NEED A VALID UNIT COST
        '=========================================

        Dim unitCost As Double

        If Not Double.TryParse(txtUnitCost.Text, unitCost) Then

            cboCategory.Text = ""
            txtEUL.Clear()

            If Not IsEditMode Then
                txtPropertyNo.Clear()
            End If

            Exit Sub

        End If


        '=========================================
        ' DETERMINE CATEGORY
        '=========================================

        Dim isMotorVehicle As Boolean =
        cboAccountCode.Text.Trim().ToUpper().Contains("MOTOR VEHICLE") OrElse
        cboArticle.Text.Trim().ToUpper().Contains("MOTOR VEHICLE")

        If isMotorVehicle OrElse unitCost >= 50000 Then

            cboCategory.Text = "PPE"

        Else

            cboCategory.Text = "Semi-Expendable"

        End If


        '=========================================
        ' DETERMINE EUL
        '=========================================

        Dim eul As String =
        GetEUL(
            cboAccountCode.Text.Trim(),
            unitCost,
            cboArticle.Text.Trim())

        txtEUL.Text = eul


        '=========================================
        ' PROPERTY NUMBER
        '
        ' DO NOT REGENERATE DURING EDIT MODE
        '=========================================

        If IsEditMode Then
            Exit Sub
        End If


        '=========================================
        ' GENERATE PROPERTY NUMBER
        '=========================================
        Dim acquiredYear As Integer =
         If(IsFoundItemRegistration AndAlso FoundYear > 0,
           FoundYear,
           dtpDateAcquired.Value.Year)

        Dim propertyNo As String =
        GeneratePropertyNumber(
            cboAccountCode.Text.Trim(),
            unitCost,
            cboArticle.Text.Trim(),
            acquiredYear)

        txtPropertyNo.Text = propertyNo

    End Sub
    Private Sub txtUnitCost_TextChanged(
    sender As Object,
    e As EventArgs) Handles txtUnitCost.TextChanged

        UpdatePropertyNumberPreview()

    End Sub
    Private Sub cboArticle_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cboArticle.SelectedIndexChanged

        UpdatePropertyNumberPreview()

    End Sub
    Private Function PropertyNumberExists(
    propertyNo As String
) As Boolean

        If String.IsNullOrWhiteSpace(propertyNo) Then
            Return True
        End If

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                    "SELECT COUNT(*) FROM InventoryDB " &
                    "WHERE TRIM(PropertyNo) = TRIM(@PropertyNo)"

                Using cmd As New SQLiteCommand(sql, conn)

                    cmd.Parameters.AddWithValue(
                        "@PropertyNo",
                        propertyNo.Trim())

                    Dim count As Integer =
                        Convert.ToInt32(cmd.ExecuteScalar())

                    Return count > 0

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Unable to check the existing property number." &
                Environment.NewLine & ex.Message,
                "Property Verification",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            Return False
        End Try

    End Function

End Class