Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data.SQLite
Imports OpenCvSharp
Imports OpenCvSharp.Extensions
Imports ZXing
Imports ZXing.Common
Public Class frmQRScan
    ' Responsive layout baseline captured before the form is hosted in the dashboard.
    Private ReadOnly _responsiveBounds As New Dictionary(Of Control, Rectangle)
    Private _responsiveBaseWidth As Integer = 0
    Private _applyingResponsiveLayout As Boolean = False

    Public Sub New()
        InitializeComponent()

        ' MainDashBoard supplies the shared blue header, so hide this page's duplicate
        ' header and move its content up to reclaim the unused vertical space.
        pnlHeader.Visible = False
        For Each child As Control In pnlMain.Controls
            If child IsNot pnlHeader Then
                child.Top = Math.Max(0, child.Top - 40)
            End If
        Next

        CaptureResponsiveBounds(pnlMain)
        _responsiveBaseWidth = Math.Max(1, pnlMain.ClientSize.Width)
        AddHandler pnlMain.Resize, AddressOf ResponsiveContent_Resize
    End Sub

    Private Sub CaptureResponsiveBounds(parent As Control)
        For Each child As Control In parent.Controls
            _responsiveBounds(child) = child.Bounds
            CaptureResponsiveBounds(child)
        Next
    End Sub

    Private Sub ResponsiveContent_Resize(sender As Object, e As EventArgs)
        If _applyingResponsiveLayout OrElse _responsiveBaseWidth <= 0 Then Return
        If pnlMain Is Nothing OrElse pnlMain.ClientSize.Width <= 0 Then Return

        Dim scaleX As Double = pnlMain.ClientSize.Width / CDbl(_responsiveBaseWidth)
        scaleX = Math.Max(0.35, Math.Min(1.5, scaleX))

        _applyingResponsiveLayout = True
        Try
            SuspendLayout()
            ApplyResponsiveBounds(pnlMain, scaleX)
            pnlMain.AutoScrollMinSize = New System.Drawing.Size(0, Math.Max(pnlMain.ClientSize.Height, GetBottomExtent(pnlMain)))
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


    Private CurrentSessionID As Integer = 0

    ' Camera preview
    Private camera As OpenCvSharp.VideoCapture
    Private cameraTimer As System.Windows.Forms.Timer
    Private cameraFrame As OpenCvSharp.Mat
    Private isCameraRunning As Boolean = False
    Private lastScannedQR As String = ""

    Private qrReader As New ZXing.Windows.Compatibility.BarcodeReader With {
    .Options = New ZXing.Common.DecodingOptions With {
        .PossibleFormats = New List(Of ZXing.BarcodeFormat) From {
            ZXing.BarcodeFormat.QR_CODE
        },
        .TryHarder = True
    }
}
    Private Sub frmQRScan_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        ' The dashboard owns navigation and the page title; hide the child-form duplicates.
        pnlSidebar.Visible = False
        pnlHeader.Visible = False
        pnlMain.AutoScroll = True
        ResponsiveContent_Resize(pnlMain, EventArgs.Empty)

        ' Start in Barcode mode so the camera never opens automatically.
        ' The camera starts only when the user explicitly selects QR Code.
        rdoBarcode.Checked = True
        picQRScan.Visible = False
        txtBarcodeInput.Visible = True
        lblScanQRHere.Text = "Scan barcode here..."
        lblScanInstruction.Text = "Scan the barcode using the USB scanner."

        LoadInventoryYears()
        LoadEndUsers()
        LoadClassifications()

        ' Let the page paint before loading the lower Found Items grid.
        ' This improves perceived first-open responsiveness without changing its query or data.
        If IsHandleCreated Then
            BeginInvoke(New MethodInvoker(AddressOf LoadFoundItems))
        Else
            LoadFoundItems()
        End If

    End Sub

    Private Sub LoadInventoryYears()

        cmbInventoryYear.Items.Clear()

        Dim currentYear As Integer = Date.Today.Year

        For yearValue As Integer = currentYear To currentYear - 5 Step -1
            cmbInventoryYear.Items.Add(yearValue.ToString())
        Next

        cmbInventoryYear.SelectedIndex = 0

    End Sub

    Private Sub LoadLocationsForEndUser(selectedEndUser As String)

        cmbLocation.Items.Clear()

        If String.IsNullOrWhiteSpace(selectedEndUser) Then
            Exit Sub
        End If

        Using conn As New SQLiteConnection(ConnString)
            conn.Open()

            Dim sql As String =
            "SELECT DISTINCT Location FROM InventoryDB " &
            "WHERE EndUser = @EndUser " &
            "AND Location IS NOT NULL " &
            "AND TRIM(Location) <> '' " &
            "ORDER BY Location"

            Using cmd As New SQLiteCommand(sql, conn)

                cmd.Parameters.AddWithValue("@EndUser", selectedEndUser)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        cmbLocation.Items.Add(reader("Location").ToString())
                    End While

                End Using
            End Using
        End Using

    End Sub
    Private Sub LoadEndUsers()

        cmbEndUser.Items.Clear()

        Using conn As New SQLiteConnection(ConnString)
            conn.Open()

            Dim sql As String =
                "SELECT DISTINCT EndUser FROM InventoryDB " &
                "WHERE EndUser IS NOT NULL " &
                "AND TRIM(EndUser) <> '' " &
                "ORDER BY EndUser"

            Using cmd As New SQLiteCommand(sql, conn)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        cmbEndUser.Items.Add(reader("EndUser").ToString())
                    End While

                End Using
            End Using
        End Using

    End Sub

    Private Sub cmbEndUser_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles cmbEndUser.SelectedIndexChanged

        If cmbEndUser.SelectedIndex = -1 Then
            cmbLocation.Items.Clear()
            Exit Sub
        End If

        LoadLocationsForEndUser(cmbEndUser.SelectedItem.ToString())

    End Sub

    Private Sub LoadClassifications()

        cmbClassification.Items.Clear()

        cmbClassification.Items.Add("All Classifications")
        cmbClassification.Items.Add("PPE")
        cmbClassification.Items.Add("Semi-Expendable")

        cmbClassification.SelectedIndex = 0

    End Sub
    Private Sub btnStartCount_Click(sender As Object, e As EventArgs) _
    Handles btnStartCount.Click

        If cmbInventoryYear.SelectedIndex = -1 Then
            MessageBox.Show("Please select the Inventory Year.")
            cmbInventoryYear.Focus()
            Exit Sub
        End If

        If cmbLocation.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Location.")
            cmbLocation.Focus()
            Exit Sub
        End If

        If cmbEndUser.SelectedIndex = -1 Then
            MessageBox.Show("Please select an End User.")
            cmbEndUser.Focus()
            Exit Sub
        End If

        If cmbClassification.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Classification.")
            cmbClassification.Focus()
            Exit Sub
        End If

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim inventoryYear As Integer =
                Convert.ToInt32(cmbInventoryYear.SelectedItem)

                Dim selectedLocation As String =
                cmbLocation.SelectedItem.ToString()

                Dim selectedEndUser As String =
                cmbEndUser.SelectedItem.ToString()

                Dim selectedClassification As String =
                cmbClassification.SelectedItem.ToString()

                Dim sqlFindSession As String =
                "SELECT ID FROM PhysicalInventoryDB " &
                "WHERE InventoryYear = @Year " &
                "AND Location = @Location " &
                "AND EndUser = @EndUser " &
                "AND Classification = @Classification " &
                "AND Status = 'In Progress' " &
                "ORDER BY ID DESC LIMIT 1"

                Using cmd As New SQLiteCommand(sqlFindSession, conn)

                    cmd.Parameters.AddWithValue("@Year", inventoryYear)
                    cmd.Parameters.AddWithValue("@Location", selectedLocation)
                    cmd.Parameters.AddWithValue("@EndUser", selectedEndUser)
                    cmd.Parameters.AddWithValue("@Classification",
                                             selectedClassification)

                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        CurrentSessionID = Convert.ToInt32(result)
                    Else
                        Dim sqlInsertSession As String =
                        "INSERT INTO PhysicalInventoryDB " &
                        "(InventoryYear, Location, EndUser, Classification, " &
                        "SessionDate, Status) " &
                        "VALUES (@Year, @Location, @EndUser, " &
                        "@Classification, @SessionDate, 'In Progress')"

                        Using cmdInsert As New SQLiteCommand(
                        sqlInsertSession, conn)

                            cmdInsert.Parameters.AddWithValue(
                            "@Year", inventoryYear)

                            cmdInsert.Parameters.AddWithValue(
                            "@Location", selectedLocation)

                            cmdInsert.Parameters.AddWithValue(
                            "@EndUser", selectedEndUser)

                            cmdInsert.Parameters.AddWithValue(
                            "@Classification", selectedClassification)

                            cmdInsert.Parameters.AddWithValue(
                            "@SessionDate",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

                            cmdInsert.ExecuteNonQuery()
                        End Using

                        Using cmdID As New SQLiteCommand(
                        "SELECT last_insert_rowid()", conn)

                            CurrentSessionID =
                            Convert.ToInt32(cmdID.ExecuteScalar())
                        End Using
                    End If
                End Using
            End Using

            LoadSessionItems()

        Catch ex As Exception
            MessageBox.Show(
            "Unable to start the inventory count." &
            Environment.NewLine & ex.Message,
            "Physical Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadSessionItems()

        If CurrentSessionID <= 0 Then Exit Sub

        Dim expectedCount As Integer = 0
        Dim scannedCount As Integer = 0

        dgvRemainingItems.Rows.Clear()
        dgvScannedItems.Rows.Clear()

        Using conn As New SQLiteConnection(ConnString)
            conn.Open()

            Dim selectedLocation As String = ""
            Dim selectedEndUser As String = ""
            Dim selectedClassification As String = ""

            ' Get the filters saved for this session
            Dim sqlSession As String =
            "SELECT Location, EndUser, Classification " &
            "FROM PhysicalInventoryDB WHERE ID = @SessionID"

            Using cmd As New SQLiteCommand(sqlSession, conn)

                cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    If Not reader.Read() Then
                        MessageBox.Show("The inventory session could not be found.")
                        Exit Sub
                    End If

                    selectedLocation = reader("Location").ToString()
                    selectedEndUser = reader("EndUser").ToString()
                    selectedClassification = reader("Classification").ToString()

                End Using
            End Using

            ' Load expected property records
            Dim sqlExpected As String =
            "SELECT PropertyNo, Description, EndUser, Location " &
            "FROM InventoryDB " &
            "WHERE Location = @Location " &
            "AND EndUser = @EndUser " &
            "AND PropertyNo IS NOT NULL " &
            "AND TRIM(PropertyNo) <> '' " &
            "AND (@Classification = 'All Classifications' " &
            "OR Category = @Classification) " &
            "ORDER BY PropertyNo"

            Using cmd As New SQLiteCommand(sqlExpected, conn)

                cmd.Parameters.AddWithValue("@Location", selectedLocation)
                cmd.Parameters.AddWithValue("@EndUser", selectedEndUser)
                cmd.Parameters.AddWithValue("@Classification",
                                         selectedClassification)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    While reader.Read()

                        expectedCount += 1

                        Dim propertyNo As String =
                        reader("PropertyNo").ToString()

                        Dim description As String =
                        reader("Description").ToString()

                        Dim endUser As String =
                        reader("EndUser").ToString()

                        Dim location As String =
                        reader("Location").ToString()

                        ' Check if this property was scanned in this session
                        Dim isScanned As Boolean = False

                        Using checkCmd As New SQLiteCommand(
                        "SELECT COUNT(*) FROM PhysicalInventoryScanDB " &
                        "WHERE SessionID = @SessionID " &
                        "AND PropertyNo = @PropertyNo", conn)

                            checkCmd.Parameters.AddWithValue(
                            "@SessionID", CurrentSessionID)

                            checkCmd.Parameters.AddWithValue(
                            "@PropertyNo", propertyNo)

                            isScanned =
                            Convert.ToInt32(checkCmd.ExecuteScalar()) > 0
                        End Using

                        If isScanned Then
                            scannedCount += 1
                        Else
                            dgvRemainingItems.Rows.Add(
                            propertyNo,
                            description,
                            endUser,
                            location)
                        End If

                    End While
                End Using
            End Using

            ' Load scanned property records
            Dim sqlScanned As String =
            "SELECT S.DateScanned, S.PropertyNo, I.Description, " &
            "I.EndUser, I.Location, S.Status " &
            "FROM PhysicalInventoryScanDB S " &
            "LEFT JOIN InventoryDB I ON I.PropertyNo = S.PropertyNo " &
            "WHERE S.SessionID = @SessionID " &
            "ORDER BY S.DateScanned DESC"

            Using cmd As New SQLiteCommand(sqlScanned, conn)

                cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID)

                Using reader As SQLiteDataReader = cmd.ExecuteReader()

                    Dim rowNumber As Integer = 0

                    While reader.Read()

                        rowNumber += 1

                        dgvScannedItems.Rows.Add(
                        rowNumber,
                        reader("DateScanned").ToString(),
                        reader("PropertyNo").ToString(),
                        If(IsDBNull(reader("Description")),
                           "",
                           reader("Description").ToString()),
                        If(IsDBNull(reader("EndUser")),
                           "",
                           reader("EndUser").ToString()),
                        If(IsDBNull(reader("Location")),
                           "",
                           reader("Location").ToString()),
                        reader("Status").ToString())

                    End While
                End Using
            End Using

        End Using

        Dim totalScanned As Integer = dgvScannedItems.Rows.Count

        If totalScanned = 0 Then
            lblScannedRecordCount.Text = "Showing 0 of 0 records"
        Else
            lblScannedRecordCount.Text =
                "Showing 1–" & totalScanned &
                " of " & totalScanned & " records"
        End If

        ' Update count cards
        Dim remainingCount As Integer = expectedCount - scannedCount

        lblExpectedCount.Text = expectedCount.ToString()
        lblScannedCount.Text = scannedCount.ToString()
        lblRemainingCount.Text = remainingCount.ToString()

        Dim progressPercent As Integer = 0

        If expectedCount > 0 Then
            progressPercent = CInt(
            Math.Round(scannedCount * 100.0 / expectedCount))
        End If

        lblProgressValue.Text = progressPercent.ToString() & "%"
        lblProgressCount.Text = scannedCount.ToString() &
                            " / " & expectedCount.ToString()

        progressInventory.Minimum = 0
        progressInventory.Maximum = Math.Max(expectedCount, 1)
        progressInventory.Value = Math.Min(
        scannedCount, progressInventory.Maximum)

        MessageBox.Show(
        "Inventory items loaded successfully." &
        Environment.NewLine &
        "Expected: " & expectedCount &
        Environment.NewLine &
        "Scanned: " & scannedCount &
        Environment.NewLine &
        "Remaining: " & remainingCount,
        "Physical Inventory",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information)

    End Sub
    Private Sub btnManualSearch_Click(sender As Object, e As EventArgs) _
    Handles btnManualSearch.Click

        ' Manual Search only changes panels; it must not leave the camera running.
        StopCameraPreview()
        ClearCameraPreviewImage()
        pnlQRScanArea.Visible = False
        pnlManualMode.Visible = True

        txtManualPropertyNo.Clear()
        txtManualPropertyNo.Focus()

    End Sub
    Private Sub txtManualPropertyNo_KeyDown(
    sender As Object,
    e As KeyEventArgs
) Handles txtManualPropertyNo.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSearchProperty.PerformClick()
        End If

    End Sub
    Private Sub btnScanQRCode_Click(sender As Object, e As EventArgs) _
    Handles btnScanQRCode.Click

        ' Scan Code only opens the scanning panel. It must never start the camera.
        pnlManualMode.Visible = False
        pnlQRScanArea.Visible = True

        If rdoQRCode.Checked Then
            picQRScan.Visible = True
            txtBarcodeInput.Visible = False
            lblScanQRHere.Text = "Scan QR code here..."
            lblScanInstruction.Text = "Select QR Code to start the camera."
        Else
            StopCameraPreview()
            ClearCameraPreviewImage()
            picQRScan.Visible = False
            txtBarcodeInput.Visible = True
            lblScanQRHere.Text = "Scan barcode here..."
            lblScanInstruction.Text = "Scan the barcode using the USB scanner."
            txtBarcodeInput.Clear()
            txtBarcodeInput.Focus()
        End If

    End Sub
    Private Sub btnSearchProperty_Click(sender As Object, e As EventArgs) _
    Handles btnSearchProperty.Click

        Dim propertyNo As String = txtManualPropertyNo.Text.Trim()

        If propertyNo = "" Then
            MessageBox.Show("Please enter a Property Number.",
                        "Manual Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtManualPropertyNo.Focus()
            Exit Sub
        End If

        LookupProperty(propertyNo)

        'Clear the search box after processing the search.
        txtManualPropertyNo.Clear()
        txtManualPropertyNo.Focus()


    End Sub
    Private Sub LookupProperty(propertyNo As String)

        If String.IsNullOrWhiteSpace(propertyNo) Then Return

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                "SELECT PropertyNo, Description, DateAcquired, " &
                "Condition, Location, EndUser, UnitCost, PhotoPath " &
                "FROM InventoryDB " &
                "WHERE PropertyNo = @PropertyNo LIMIT 1"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@PropertyNo", propertyNo.Trim())

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()

                        If reader.Read() Then

                            lblCurrentPropertyNoValue.Text =
                            reader("PropertyNo").ToString()

                            lblCurrentDescriptionValue.Text =
                            reader("Description").ToString()

                            lblCurrentDateAcquiredValue.Text =
                            reader("DateAcquired").ToString()

                            lblCurrentConditionValue.Text =
                            reader("Condition").ToString()

                            lblCurrentLocationValue.Text =
                            reader("Location").ToString()

                            lblCurrentEndUserValue.Text =
                            reader("EndUser").ToString()

                            lblCurrentUnitCostValue.Text =
                            If(IsDBNull(reader("UnitCost")),
                               "-",
                               Convert.ToDecimal(reader("UnitCost")).ToString("N2"))

                            ' Display the existing item photo, if available
                            If picCurrentItem.Image IsNot Nothing Then
                                Dim oldPhoto As Image = picCurrentItem.Image
                                picCurrentItem.Image = Nothing
                                oldPhoto.Dispose()
                            End If

                            If Not IsDBNull(reader("PhotoPath")) Then

                                Dim photoPath As String =
                                reader("PhotoPath").ToString()

                                If IO.File.Exists(photoPath) Then
                                    Using img As Image = Image.FromFile(photoPath)
                                        picCurrentItem.Image = New Bitmap(img)
                                    End Using

                                    picCurrentItem.SizeMode =
                                    PictureBoxSizeMode.Zoom
                                End If

                            End If

                        Else
                            MessageBox.Show(
                            "No property record was found for: " & propertyNo,
                            "Property Search",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
            "Unable to search for the property." &
            Environment.NewLine & ex.Message,
            "Property Search",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnMarkAccounted_Click(sender As Object, e As EventArgs) _
    Handles btnMarkAccounted.Click

        If CurrentSessionID <= 0 Then
            MessageBox.Show(
            "Please start an inventory count first.",
            "Physical Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim propertyNo =
        lblCurrentPropertyNoValue.Text.Trim

        If propertyNo = "" OrElse propertyNo = "-" Then
            MessageBox.Show(
            "Please search for a property first.",
            "Physical Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                ' Confirm the property belongs to the expected list
                Dim sqlExpected =
                "SELECT COUNT(*) FROM InventoryDB I " &
                "INNER JOIN PhysicalInventoryDB P " &
                "ON P.ID = @SessionID " &
                "WHERE I.PropertyNo = @PropertyNo " &
                "AND I.Location = P.Location " &
                "AND I.EndUser = P.EndUser " &
                "AND (P.Classification = 'All Classifications' " &
                "OR I.Category = P.Classification)"

                Using cmd As New SQLiteCommand(sqlExpected, conn)
                    cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID)
                    cmd.Parameters.AddWithValue("@PropertyNo", propertyNo)

                    If Convert.ToInt32(cmd.ExecuteScalar) = 0 Then
                        MessageBox.Show(
                        "This property is not in the expected inventory list." &
                        Environment.NewLine &
                        "Please review it as a possible discrepancy or unexpected item.",
                        "Property Not Expected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End Using

                ' Prevent duplicate scans
                Dim sqlDuplicate =
                "SELECT COUNT(*) FROM PhysicalInventoryScanDB " &
                "WHERE SessionID = @SessionID AND PropertyNo = @PropertyNo"

                Using cmd As New SQLiteCommand(sqlDuplicate, conn)
                    cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID)
                    cmd.Parameters.AddWithValue("@PropertyNo", propertyNo)

                    If Convert.ToInt32(cmd.ExecuteScalar) > 0 Then
                        MessageBox.Show(
                        "This property has already been scanned in this session.",
                        "Already Scanned",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End Using

                ' Save the scan
                Dim sqlInsert =
                "INSERT INTO PhysicalInventoryScanDB " &
                "(SessionID, PropertyNo, DateScanned, Status) " &
                "VALUES (@SessionID, @PropertyNo, @DateScanned, @Status)"

                Using cmd As New SQLiteCommand(sqlInsert, conn)
                    cmd.Parameters.AddWithValue("@SessionID", CurrentSessionID)
                    cmd.Parameters.AddWithValue("@PropertyNo", propertyNo)
                    cmd.Parameters.AddWithValue(
                    "@DateScanned",
                    Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@Status", "Accounted")

                    cmd.ExecuteNonQuery()
                End Using

            End Using

            ' Refresh both grids and the progress cards
            LoadSessionItems()

            MessageBox.Show(
            "Property successfully marked as accounted for this physical inventory session.",
            "Physical Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(
            "Unable to save the inventory scan." &
            Environment.NewLine & ex.Message,
            "Physical Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub rdoQRCode_CheckedChanged(sender As Object, e As EventArgs) _
    Handles rdoQRCode.CheckedChanged

        If rdoQRCode.Checked Then
            StopCameraPreview()
            ClearCameraPreviewImage()
            picQRScan.Visible = True
            txtBarcodeInput.Visible = False

            lblScanQRHere.Text = "Scan QR code here..."
            lblScanInstruction.Text = "Position the QR code in front of the camera to scan."

            ' Only selecting QR Code starts the camera, and only while the scan panel is active.
            If pnlQRScanArea.Visible AndAlso pnlManualMode.Visible = False Then
                StartCameraPreview()
            End If
        End If

    End Sub
    Private Sub rdoBarcode_CheckedChanged(sender As Object, e As EventArgs) _
    Handles rdoBarcode.CheckedChanged

        If rdoBarcode.Checked Then
            StopCameraPreview()
            ClearCameraPreviewImage()
            picQRScan.Visible = False

            txtBarcodeInput.Visible = True
            txtBarcodeInput.Clear()

            lblScanQRHere.Text = "Scan barcode here..."
            lblScanInstruction.Text = "Scan the barcode using the USB scanner."
            txtBarcodeInput.Focus()
        End If

    End Sub


    ' Start the laptop camera preview
    Private Sub StartCameraPreview()

        Try
            If isCameraRunning Then Return

            camera = New OpenCvSharp.VideoCapture(
                0,
                OpenCvSharp.VideoCaptureAPIs.DSHOW
            )

            If Not camera.IsOpened() Then
                camera.Dispose()
                camera = Nothing

                MessageBox.Show(
                    "Unable to open the camera. Please check that your camera is connected and not being used by another application.",
                    "Camera Unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )
                Return
            End If

            cameraFrame = New OpenCvSharp.Mat()

            cameraTimer = New System.Windows.Forms.Timer()
            cameraTimer.Interval = 33

            AddHandler cameraTimer.Tick, AddressOf CameraTimer_Tick

            isCameraRunning = True
            cameraTimer.Start()

        Catch ex As Exception
            StopCameraPreview()

            MessageBox.Show(
                "Unable to start the camera: " & ex.Message,
                "Camera Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try

    End Sub
    ' Update the live camera image
    Private Sub CameraTimer_Tick(
        sender As Object,
        e As EventArgs
    )

        Try
            If camera Is Nothing OrElse cameraFrame Is Nothing Then Return

            If camera.Read(cameraFrame) AndAlso Not cameraFrame.Empty() Then

                Dim newImage As System.Drawing.Bitmap =
                    OpenCvSharp.Extensions.BitmapConverter.ToBitmap(cameraFrame)

                Dim oldImage As System.Drawing.Image = picQRScan.Image
                picQRScan.Image = newImage

                If oldImage IsNot Nothing Then
                    oldImage.Dispose()
                End If

                picQRScan.SizeMode = PictureBoxSizeMode.Zoom

                ' Recognize QR code from the live camera image
                If rdoQRCode.Checked Then

                    Dim result As ZXing.Result = qrReader.Decode(newImage)

                    If result IsNot Nothing AndAlso
                       Not String.IsNullOrWhiteSpace(result.Text) AndAlso
                       result.Text <> lastScannedQR Then

                        lastScannedQR = result.Text.Trim()

                        StopCameraPreview()

                        ' Extract only the Property Number from the QR code
                        Dim propertyNo As String = lastScannedQR
                        Dim marker As String = "Property No.:"

                        Dim markerIndex As Integer =
                            propertyNo.IndexOf(marker, StringComparison.OrdinalIgnoreCase)

                        If markerIndex >= 0 Then
                            propertyNo = propertyNo.Substring(markerIndex + marker.Length).Trim()

                            Dim lineBreakIndex As Integer = propertyNo.IndexOfAny(
                                New Char() {ControlChars.Cr, ControlChars.Lf})

                            If lineBreakIndex >= 0 Then
                                propertyNo = propertyNo.Substring(0, lineBreakIndex).Trim()
                            End If
                        End If

                        If String.IsNullOrWhiteSpace(propertyNo) Then Return

                        txtManualPropertyNo.Text = propertyNo
                        LookupProperty(propertyNo)

                    End If

                End If
            End If

        Catch ex As Exception
            StopCameraPreview()

            MessageBox.Show(
                "The camera preview stopped: " & ex.Message,
                "Camera Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
        End Try

    End Sub

    ' Called by MainDashBoard when this cached page is hidden.
    ' FormClosing does not run when dashboard navigation merely hides the form.
    Public Sub OnPageHidden()
        StopCameraPreview()
    End Sub

    ' Clear the last camera frame so it cannot remain visible in Barcode mode.
    Private Sub ClearCameraPreviewImage()
        If picQRScan.Image IsNot Nothing Then
            Dim oldImage As System.Drawing.Image = picQRScan.Image
            picQRScan.Image = Nothing
            oldImage.Dispose()
        End If
    End Sub

    ' Release camera resources
    Private Sub StopCameraPreview()

        isCameraRunning = False

        If cameraTimer IsNot Nothing Then
            cameraTimer.Stop()
            RemoveHandler cameraTimer.Tick, AddressOf CameraTimer_Tick
            cameraTimer.Dispose()
            cameraTimer = Nothing
        End If

        If camera IsNot Nothing Then
            camera.Dispose()
            camera = Nothing
        End If

        If cameraFrame IsNot Nothing Then
            cameraFrame.Dispose()
            cameraFrame = Nothing
        End If

    End Sub

    ' Release camera resources when the form closes
    Private Sub frmQRScan_FormClosing(
        sender As Object,
        e As FormClosingEventArgs
    ) Handles MyBase.FormClosing

        StopCameraPreview()

        If picQRScan.Image IsNot Nothing Then
            picQRScan.Image.Dispose()
            picQRScan.Image = Nothing
        End If

    End Sub
    Private Sub txtBarcodeInput_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles txtBarcodeInput.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim propertyNo As String = txtBarcodeInput.Text.Trim()

            If propertyNo <> "" Then
                txtBarcodeInput.Clear()
                txtManualPropertyNo.Text = propertyNo
                LookupProperty(propertyNo)
            End If
        End If

    End Sub
    Private Sub btnOpenInventory_Click(
        sender As Object,
        e As EventArgs) Handles btnOpenInventory.Click

        Dim propertyNo As String = lblCurrentPropertyNoValue.Text.Trim()

        If String.IsNullOrWhiteSpace(propertyNo) OrElse propertyNo = "-" Then
            MessageBox.Show(
                "Please scan or select a property first.",
                "Open in Inventory",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        'Use the dashboard's hosted page instead of opening a separate window.
        For Each openForm As Form In Application.OpenForms
            If TypeOf openForm Is MainDashBoard Then
                DirectCast(openForm, MainDashBoard).OpenPropertyFromQR(propertyNo)
                Return
            End If
        Next

        MessageBox.Show(
            "The main dashboard could not be found. Please return to the dashboard and try again.",
            "Open in Inventory",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

    End Sub

    Private Sub btnResetCount_Click(
        sender As Object,
        e As EventArgs) Handles btnResetCount.Click

        If CurrentSessionID <= 0 Then
            MessageBox.Show(
                "Please start an inventory count first.",
                "Reset Count",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim answer As DialogResult = MessageBox.Show(
            "Are you sure you want to reset this physical inventory count?" &
            Environment.NewLine & Environment.NewLine &
            "All scanned records in the current session will be cleared. " &
            "Your property records will not be deleted.",
            "Confirm Reset Count",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If answer <> DialogResult.Yes Then Return

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                    "DELETE FROM PhysicalInventoryScanDB " &
                    "WHERE SessionID = @SessionID"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue(
                        "@SessionID", CurrentSessionID)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Refresh scanned/remaining lists and progress counters.
            LoadSessionItems()

            MessageBox.Show(
                "The physical inventory count has been reset.",
                "Reset Count",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(
                "Unable to reset the physical inventory count." &
                Environment.NewLine & ex.Message,
                "Reset Count",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnRegisterFoundItem_Click(
    sender As Object,
    e As EventArgs
) Handles btnRegisterFoundItem.Click

        If CurrentSessionID <= 0 Then
            MessageBox.Show(
            "Please start an inventory count first.",
            "Register Found Item",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim sessionLocation As String = ""

            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                "SELECT Location FROM PhysicalInventoryDB " &
                "WHERE ID = @SessionID"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue(
                    "@SessionID", CurrentSessionID)

                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso
                   result IsNot DBNull.Value Then

                        sessionLocation = result.ToString().Trim()
                    End If
                End Using
            End Using

            If String.IsNullOrWhiteSpace(sessionLocation) Then
                MessageBox.Show(
                "The location for the active inventory session " &
                "could not be found. Please verify the session.",
                "Register Found Item",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
                Return
            End If

            Using foundForm As New frmRegisterFoundItem()
                foundForm.ActiveSessionID = CurrentSessionID
                foundForm.SessionLocation = sessionLocation
                foundForm.ShowDialog(Me)
            End Using

            ' Refresh pending found items after closing the form.
            LoadFoundItems()

        Catch ex As Exception
            MessageBox.Show(
            "Unable to open the Register Found Item form." &
            Environment.NewLine & ex.Message,
            "Register Found Item",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadFoundItems()

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                "SELECT ID, DateRecorded, PropertyNo, Description, " &
                "ActualLocation, ObservedCondition, DiscrepancyNotes, Status " &
                "FROM PhysicalInventoryUnexpectedDB " &
                "WHERE Status = @Status " &
                "ORDER BY DateRecorded DESC"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Status", "Pending Review")

                    Using adapter As New SQLiteDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvFoundItems.DataSource = dt
                    End Using
                End Using
            End Using

            'Keep the database ID available for opening or deleting records.
            If dgvFoundItems.Columns.Contains("ID") Then
                dgvFoundItems.Columns("ID").Visible = False
            End If

            dgvFoundItems.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

            dgvFoundItems.ReadOnly = True
            dgvFoundItems.AllowUserToAddRows = False
            dgvFoundItems.AllowUserToDeleteRows = False
            dgvFoundItems.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
            dgvFoundItems.MultiSelect = False
            dgvFoundItems.RowHeadersVisible = False

        Catch ex As Exception
            MessageBox.Show(
            "Unable to load found items: " & ex.Message,
            "Found Items",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnRefreshFoundItems_Click(
    sender As Object,
    e As EventArgs
) Handles btnRefreshFoundItems.Click

        'Clear the previous search filter.
        txtSearchFoundItems.Clear()

        'Reload all current pending found-item records.
        LoadFoundItems()

    End Sub
    Private Sub btnOpenFoundItem_Click(
    sender As Object,
    e As EventArgs
) Handles btnOpenFoundItem.Click

        If dgvFoundItems.CurrentRow Is Nothing Then
            MessageBox.Show(
                "Please select a found item to review.",
                "Open Found Item",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim recordID As Integer =
            Convert.ToInt32(dgvFoundItems.CurrentRow.Cells("ID").Value)

        Using foundForm As New frmRegisterFoundItem()
            foundForm.LoadFoundItem(recordID)

            If foundForm.IsReviewMode Then
                foundForm.ShowDialog(Me)
            End If
        End Using

        'Refresh Section 7 after closing the review form.
        LoadFoundItems()

    End Sub
    Private Sub btnDeleteFoundItem_Click(
    sender As Object,
    e As EventArgs
) Handles btnDeleteFoundItem.Click

        If dgvFoundItems.CurrentRow Is Nothing Then
            MessageBox.Show(
                "Please select a found item to delete.",
                "Delete Found Item",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
            Return
        End If

        Dim recordID As Integer =
            Convert.ToInt32(
                dgvFoundItems.CurrentRow.Cells("ID").Value)

        Dim description As String =
            dgvFoundItems.CurrentRow.Cells("Description").Value.ToString()

        Dim answer As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this found-item record?" &
            Environment.NewLine & Environment.NewLine &
            "Description: " & description &
            Environment.NewLine & Environment.NewLine &
            "This will remove the pending-review record, not the master inventory record.",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If answer <> DialogResult.Yes Then Return

        Try
            Using conn As New SQLiteConnection(ConnString)
                conn.Open()

                Dim sql As String =
                    "DELETE FROM PhysicalInventoryUnexpectedDB " &
                    "WHERE ID = @ID AND Status = @Status"

                Using cmd As New SQLiteCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", recordID)
                    cmd.Parameters.AddWithValue("@Status", "Pending Review")

                    Dim affectedRows As Integer = cmd.ExecuteNonQuery()

                    If affectedRows = 0 Then
                        MessageBox.Show(
                            "The record was not deleted. It may no longer be pending review.",
                            "Delete Found Item",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                        Return
                    End If
                End Using
            End Using

            LoadFoundItems()

            MessageBox.Show(
                "The found-item record was deleted successfully.",
                "Delete Found Item",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(
                "Unable to delete the found-item record." &
                Environment.NewLine & ex.Message,
                "Delete Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtSearchFoundItems_TextChanged(
    sender As Object,
    e As EventArgs
) Handles txtSearchFoundItems.TextChanged

        Dim dt As DataTable =
            TryCast(dgvFoundItems.DataSource, DataTable)

        If dt Is Nothing Then Return

        Dim keyword As String = txtSearchFoundItems.Text.Trim()

        'Escape special characters used by the DataView filter.
        keyword = keyword.Replace("'", "''")
        keyword = keyword.Replace("[", "[[]")

        If String.IsNullOrWhiteSpace(keyword) Then
            dt.DefaultView.RowFilter = ""
            Return
        End If

        Dim filter As String =
            "Convert(DateRecorded, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(PropertyNo, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(Description, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(ActualLocation, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(ObservedCondition, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(DiscrepancyNotes, 'System.String') LIKE '%" & keyword & "%' OR " &
            "Convert(Status, 'System.String') LIKE '%" & keyword & "%'"

        dt.DefaultView.RowFilter = filter

    End Sub
    Private Sub txtSearchRemaining_TextChanged(
    sender As Object,
    e As EventArgs
) Handles txtSearchRemaining.TextChanged

        FilterGridRows(dgvRemainingItems, txtSearchRemaining.Text)

    End Sub
    Private Sub txtSearchScanned_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtSearchScanned.TextChanged

        FilterGridRows(dgvScannedItems, txtSearchScanned.Text)

    End Sub
    Private Sub FilterGridRows(
        grid As DataGridView,
        searchText As String
    )

        Dim keyword As String = searchText.Trim()

        'Clear the current cell before hiding matching rows.
        grid.CurrentCell = Nothing

        For Each row As DataGridViewRow In grid.Rows

            If row.IsNewRow Then Continue For

            Dim matches As Boolean = String.IsNullOrWhiteSpace(keyword)

            If Not matches Then
                For Each cell As DataGridViewCell In row.Cells

                    If cell.Value IsNot Nothing AndAlso
                       cell.Value.ToString().IndexOf(
                           keyword,
                           StringComparison.OrdinalIgnoreCase) >= 0 Then

                        matches = True
                        Exit For

                    End If

                Next
            End If

            row.Visible = matches

        Next

    End Sub
End Class