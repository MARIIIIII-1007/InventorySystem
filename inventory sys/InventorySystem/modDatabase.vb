Imports System.Data.SQLite
Imports System.IO

Module modDatabase

    Public DBPath As String = Application.StartupPath & "\InventoryDB.db"
    Public ConnString As String = "Data Source=" & DBPath & ";Version=3;"

    Public Sub InitializeDatabase()

        If Not File.Exists(DBPath) Then
            SQLiteConnection.CreateFile(DBPath)
        End If

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sql As String =
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
                    "UsefulLife TEXT, " &
                    "Location TEXT, " &
                    "EndUser TEXT, " &
                    "Remarks TEXT, " &
                    "PhotoPath TEXT, " &
                    "QRCodePath TEXT, " &
                    "BarcodePath TEXT" &
                     ")"


            Dim cmd As New SQLiteCommand(sql, conn)
            cmd.ExecuteNonQuery()

            ' Add BarcodePath to existing databases if missing
            EnsureColumnExists(conn, "InventoryDB", "BarcodePath", "TEXT")

            Dim sqlAccountCodes As String =
            "CREATE TABLE IF NOT EXISTS AccountCodes (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "AccountCode TEXT, " &
            "PPE_SubMajor TEXT, " &
            "PPE_GL TEXT, " &
            "Semi_SubMajor TEXT, " &
            "Semi_GL TEXT, " &
            "IsPPE TEXT, " &
            "IsSemi TEXT" &
            ")"

            Dim cmdAccountCodes As New SQLiteCommand(sqlAccountCodes, conn)
            cmdAccountCodes.ExecuteNonQuery()


            Dim sqlSeries As String =
            "CREATE TABLE IF NOT EXISTS SeriesDB (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "Category TEXT, " &
            "AccountCode TEXT, " &
            "LastSeries INTEGER" &
            ")"

            Dim cmdSeries As New SQLiteCommand(sqlSeries, conn)
            cmdSeries.ExecuteNonQuery()


            ' Physical Inventory Sessions
            Dim sqlPhysicalInventory As String =
            "CREATE TABLE IF NOT EXISTS PhysicalInventoryDB (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "InventoryYear INTEGER NOT NULL, " &
            "Location TEXT NOT NULL, " &
            "EndUser TEXT NOT NULL, " &
            "Classification TEXT NOT NULL, " &
            "SessionDate TEXT NOT NULL, " &
            "Status TEXT NOT NULL DEFAULT 'In Progress'" &
            ")"

            Using cmdPhysicalInventory As New SQLiteCommand(sqlPhysicalInventory, conn)
                cmdPhysicalInventory.ExecuteNonQuery()
            End Using

            ' Physical Inventory Scanned Items
            Dim sqlPhysicalInventoryScan As String =
            "CREATE TABLE IF NOT EXISTS PhysicalInventoryScanDB (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "SessionID INTEGER NOT NULL, " &
            "PropertyNo TEXT NOT NULL, " &
            "DateScanned TEXT NOT NULL, " &
            "Status TEXT NOT NULL DEFAULT 'Accounted', " &
            "FOREIGN KEY (SessionID) REFERENCES PhysicalInventoryDB(ID)" &
            ")"

            Using cmdPhysicalInventoryScan As New SQLiteCommand(sqlPhysicalInventoryScan, conn)
                cmdPhysicalInventoryScan.ExecuteNonQuery()
            End Using


            ' Add new fields to existing physical inventory scan table
            EnsureColumnExists(conn, "PhysicalInventoryScanDB", "ObservedCondition", "TEXT")
            EnsureColumnExists(conn, "PhysicalInventoryScanDB", "ActualLocation", "TEXT")
            EnsureColumnExists(conn, "PhysicalInventoryScanDB", "DiscrepancyNotes", "TEXT")
            EnsureColumnExists(conn, "PhysicalInventoryScanDB", "PhotoPath", "TEXT")

            ' Unexpected items found during physical inventory
            Dim sqlUnexpectedItems As String =
            "CREATE TABLE IF NOT EXISTS PhysicalInventoryUnexpectedDB (" &
            "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
            "SessionID INTEGER NOT NULL, " &
            "PropertyNo TEXT, " &
            "Description TEXT, " &
            "ActualLocation TEXT, " &
            "ObservedCondition TEXT, " &
            "DiscrepancyNotes TEXT, " &
            "PhotoPath TEXT, " &
            "DateRecorded TEXT NOT NULL, " &
            "Status TEXT NOT NULL DEFAULT 'Pending Review', " &
            "FOREIGN KEY (SessionID) REFERENCES PhysicalInventoryDB(ID)" &
            ")"

            Using cmdUnexpectedItems As New SQLiteCommand(sqlUnexpectedItems, conn)
                cmdUnexpectedItems.ExecuteNonQuery()
            End Using


            ' Add link to the existing master inventory record
            EnsureColumnExists(
            conn,
            "PhysicalInventoryUnexpectedDB",
            "LinkedInventoryID",
            "INTEGER"
)

            ' Accountability document register. A document can cover multiple
            ' property records, and a property can appear in multiple documents
            ' over time (for example, renewal or reissuance).
            Dim sqlAccountabilityDocuments As String =
                "CREATE TABLE IF NOT EXISTS AccountabilityDocuments (" &
                "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "DocumentType TEXT NOT NULL CHECK (DocumentType IN ('PAR','ICS')), " &
                "DocumentNo TEXT NOT NULL UNIQUE, " &
                "IssueDate TEXT, " &
                "LastRenewalDate TEXT, " &
                "Status TEXT NOT NULL DEFAULT 'Active', " &
                "SupersedesDocumentID INTEGER, " &
                "CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, " &
                "Notes TEXT, " &
                "FOREIGN KEY (SupersedesDocumentID) REFERENCES AccountabilityDocuments(ID)" &
                ")"

            Using cmdAccountabilityDocuments As New SQLiteCommand(sqlAccountabilityDocuments, conn)
                cmdAccountabilityDocuments.ExecuteNonQuery()
            End Using

            ' Link documents to property records without putting document-level
            ' information directly on InventoryDB (one document may contain many items).
            Dim sqlAccountabilityDocumentItems As String =
                "CREATE TABLE IF NOT EXISTS AccountabilityDocumentItems (" &
                "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "DocumentID INTEGER NOT NULL, " &
                "InventoryID INTEGER NOT NULL, " &
                "AddedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, " &
                "UNIQUE (DocumentID, InventoryID), " &
                "FOREIGN KEY (DocumentID) REFERENCES AccountabilityDocuments(ID), " &
                "FOREIGN KEY (InventoryID) REFERENCES InventoryDB(ID)" &
                ")"

            Using cmdAccountabilityDocumentItems As New SQLiteCommand(sqlAccountabilityDocumentItems, conn)
                cmdAccountabilityDocumentItems.ExecuteNonQuery()
            End Using

            ' Preserve accountability-related changes for audit and follow-up.
            Dim sqlAccountabilityHistory As String =
                "CREATE TABLE IF NOT EXISTS AccountabilityHistory (" &
                "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "InventoryID INTEGER NOT NULL, " &
                "ChangeType TEXT NOT NULL, " &
                "PreviousEndUser TEXT, " &
                "NewEndUser TEXT, " &
                "PreviousLocation TEXT, " &
                "NewLocation TEXT, " &
                "ChangeDate TEXT NOT NULL, " &
                "ChangeReason TEXT, " &
                "ReviewStatus TEXT NOT NULL DEFAULT 'Pending Review', " &
                "ResolutionAction TEXT, " &
                "ResolvedDate TEXT, " &
                "RelatedDocumentID INTEGER, " &
                "ChangedBy TEXT, " &
                "Notes TEXT, " &
                "FOREIGN KEY (InventoryID) REFERENCES InventoryDB(ID), " &
                "FOREIGN KEY (RelatedDocumentID) REFERENCES AccountabilityDocuments(ID)" &
                ")"

            Using cmdAccountabilityHistory As New SQLiteCommand(sqlAccountabilityHistory, conn)
                cmdAccountabilityHistory.ExecuteNonQuery()
            End Using

            ' Indexes used by Dashboard alerts and property accountability lookups.
            Using cmdIndexes As New SQLiteCommand(
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityDocumentItems_InventoryID ON AccountabilityDocumentItems(InventoryID); " &
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityDocumentItems_DocumentID ON AccountabilityDocumentItems(DocumentID); " &
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityDocuments_TypeStatus ON AccountabilityDocuments(DocumentType, Status); " &
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityDocuments_RenewalDates ON AccountabilityDocuments(LastRenewalDate, IssueDate); " &
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityHistory_InventoryStatus ON AccountabilityHistory(InventoryID, ReviewStatus); " &
                "CREATE INDEX IF NOT EXISTS IX_AccountabilityHistory_ChangeDate ON AccountabilityHistory(ChangeDate)", conn)
                cmdIndexes.ExecuteNonQuery()
            End Using

            conn.Close()

        End Using

    End Sub

    Private Sub EnsureColumnExists(
    conn As SQLiteConnection,
    tableName As String,
    columnName As String,
    columnDefinition As String)

        Dim columnExists As Boolean = False

        Dim sql As String = "PRAGMA table_info(" & tableName & ")"

        Using cmd As New SQLiteCommand(sql, conn)
            Using reader As SQLiteDataReader = cmd.ExecuteReader()

                While reader.Read()
                    If reader("name").ToString().Equals(
                    columnName,
                    StringComparison.OrdinalIgnoreCase) Then

                        columnExists = True
                        Exit While
                    End If
                End While

            End Using
        End Using

        If Not columnExists Then
            Dim alterSql As String =
            "ALTER TABLE " & tableName &
            " ADD COLUMN " & columnName &
            " " & columnDefinition

            Using cmdAlter As New SQLiteCommand(alterSql, conn)
                cmdAlter.ExecuteNonQuery()
            End Using
        End If

    End Sub


    Public Sub LoadDefaultAccountCodes()

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            Dim sqlCheck As String =
                "SELECT COUNT(*) FROM AccountCodes"

            Dim cmdCheck As New SQLiteCommand(sqlCheck, conn)

            Dim recordCount As Integer =
                Convert.ToInt32(cmdCheck.ExecuteScalar())

            If recordCount > 0 Then

                conn.Close()
                Exit Sub

            End If

            Dim sqlInsert As String =
            "INSERT INTO AccountCodes " &
            "(AccountCode, PPE_SubMajor, PPE_GL, Semi_SubMajor, Semi_GL, IsPPE, IsSemi) " &
            "VALUES " &
            "(@AccountCode, @PPE_SubMajor, @PPE_GL, @Semi_SubMajor, @Semi_GL, @IsPPE, @IsSemi)"

            Using cmdInsert As New SQLiteCommand(sqlInsert, conn)

                cmdInsert.Parameters.AddWithValue("@AccountCode", "FURNITURE AND FIXTURES")
                cmdInsert.Parameters.AddWithValue("@PPE_SubMajor", "07")
                cmdInsert.Parameters.AddWithValue("@PPE_GL", "01")
                cmdInsert.Parameters.AddWithValue("@Semi_SubMajor", "06")
                cmdInsert.Parameters.AddWithValue("@Semi_GL", "01")
                cmdInsert.Parameters.AddWithValue("@IsPPE", "YES")
                cmdInsert.Parameters.AddWithValue("@IsSemi", "YES")

                cmdInsert.ExecuteNonQuery()

            End Using

        End Using

    End Sub

End Module