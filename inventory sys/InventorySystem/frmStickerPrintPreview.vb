Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmStickerPrintPreview

    Private _sheetPaths As List(Of String)

    Private _currentPage As Integer = 0

    Private WithEvents _printDocument As New PrintDocument

    Public Sub New(sheetPaths As List(Of String))

        InitializeComponent()

        _sheetPaths = sheetPaths

    End Sub
    Private Sub frmStickerPrintPreview_Load(
        sender As Object,
        e As EventArgs) Handles MyBase.Load

        If _sheetPaths Is Nothing OrElse _sheetPaths.Count = 0 Then

            MessageBox.Show(
        "No A4 sheets were provided.",
        "Print Preview",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning)

            Me.Close()
            Exit Sub

        End If

        If Not IO.File.Exists(_sheetPaths(0)) Then
            MessageBox.Show(
                "The A4 sheet could not be found.",
                "Print Preview",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Me.Close()
            Exit Sub
        End If

        picPreview.Image = Image.FromFile(_sheetPaths(0))

        lblPage.Text =
            "Page 1 of " & _sheetPaths.Count.ToString()

        btnPrevious.Enabled = False
        btnNext.Enabled = (_sheetPaths.Count > 1)

    End Sub
    Private Sub btnPrint_Click(
    sender As Object,
    e As EventArgs) Handles btnPrint.Click

        Using printDialog As New PrintDialog()

            printDialog.Document = _printDocument

            If printDialog.ShowDialog(Me) = DialogResult.OK Then
                _printDocument.Print()
            End If

        End Using

    End Sub

    Private Sub _printDocument_PrintPage(
    sender As Object,
    e As PrintPageEventArgs) Handles _printDocument.PrintPage

        If picPreview.Image Is Nothing Then
            e.HasMorePages = False
            Exit Sub
        End If

        Dim pageBounds As Rectangle = e.MarginBounds

        Dim imageRatio As Double =
            CDbl(picPreview.Image.Width) /
            CDbl(picPreview.Image.Height)

        Dim printWidth As Integer = pageBounds.Width

        Dim printHeight As Integer =
            CInt(printWidth / imageRatio)

        If printHeight > pageBounds.Height Then

            printHeight = pageBounds.Height

            printWidth =
                CInt(printHeight * imageRatio)

        End If

        Dim x As Integer =
            pageBounds.Left +
            ((pageBounds.Width - printWidth) \ 2)

        Dim y As Integer =
            pageBounds.Top +
            ((pageBounds.Height - printHeight) \ 2)

        e.Graphics.DrawImage(
            picPreview.Image,
            New Rectangle(
                x,
                y,
                printWidth,
                printHeight))

        e.HasMorePages = False

    End Sub
    Private Sub btnCancel_Click(
    sender As Object,
    e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub
    Private Sub btnPrevious_Click(
    sender As Object,
    e As EventArgs) Handles btnPrevious.Click

        If _currentPage <= 0 Then
            Exit Sub
        End If

        _currentPage -= 1

        ShowCurrentPage()

    End Sub


    Private Sub btnNext_Click(
        sender As Object,
        e As EventArgs) Handles btnNext.Click

        If _currentPage >= _sheetPaths.Count - 1 Then
            Exit Sub
        End If

        _currentPage += 1

        ShowCurrentPage()

    End Sub
    Private Sub ShowCurrentPage()

        If _sheetPaths Is Nothing OrElse
           _sheetPaths.Count = 0 Then

            Exit Sub

        End If

        If _currentPage < 0 OrElse
           _currentPage >= _sheetPaths.Count Then

            Exit Sub

        End If

        If picPreview.Image IsNot Nothing Then

            picPreview.Image.Dispose()
            picPreview.Image = Nothing

        End If

        picPreview.Image =
            Image.FromFile(
                _sheetPaths(_currentPage))

        lblPage.Text =
            "Page " &
            (_currentPage + 1).ToString() &
            " of " &
            _sheetPaths.Count.ToString()

        btnPrevious.Enabled =
            (_currentPage > 0)

        btnNext.Enabled =
            (_currentPage < _sheetPaths.Count - 1)

    End Sub
End Class