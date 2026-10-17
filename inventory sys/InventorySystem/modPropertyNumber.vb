Imports System.Data.SQLite

Module modPropertyNumber

    '========================================================
    ' PROPERTY NUMBER GENERATOR
    '
    ' PPE:
    ' YYYY-SubMajor-GL-####
    '
    ' SEMI-HV:
    ' YYYY-SubMajor-GL-HV-####
    '
    ' SEMI-LV:
    ' YYYY-SubMajor-GL-LV-####
    '
    ' HV and LV share ONE SEMI sequence.
    ' PPE has a separate sequence.
    '========================================================

    Public Function GeneratePropertyNumber(
        accountCode As String,
        unitCost As Double,
        article As String,
        acquiredYear As Integer
    ) As String

        If String.IsNullOrWhiteSpace(accountCode) Then
            Return ""
        End If

        '====================================================
        ' DETERMINE PPE / SEMI
        '====================================================

        Dim isMotorVehicle As Boolean =
            article.Trim().ToUpper().Contains("MOTOR VEHICLE") OrElse
            accountCode.Trim().ToUpper().Contains("MOTOR VEHICLE") OrElse
            accountCode.Trim().ToUpper().Contains("MOTOR VEHICLES")

        Dim classificationGroup As String
        Dim semiSuffix As String = ""

        If isMotorVehicle OrElse unitCost >= 50000 Then

            classificationGroup = "PPE"

        ElseIf unitCost >= 5000 Then

            classificationGroup = "SEMI"
            semiSuffix = "HV"

        Else

            classificationGroup = "SEMI"
            semiSuffix = "LV"

        End If

        '====================================================
        ' GET ACCOUNT CODE MAPPING
        '====================================================

        Dim ppeSubMajor As String = ""
        Dim ppeGL As String = ""
        Dim semiSubMajor As String = ""
        Dim semiGL As String = ""

        If Not GetAccountCodeMapping(
            accountCode,
            ppeSubMajor,
            ppeGL,
            semiSubMajor,
            semiGL) Then

            Return ""

        End If

        '====================================================
        ' SELECT SUBMAJOR / GL
        '====================================================

        Dim subMajor As String
        Dim gl As String

        If classificationGroup = "PPE" Then

            subMajor = ppeSubMajor
            gl = ppeGL

        Else

            subMajor = semiSubMajor
            gl = semiGL

        End If

        If String.IsNullOrWhiteSpace(subMajor) OrElse
           String.IsNullOrWhiteSpace(gl) Then

            Return ""

        End If

        '====================================================
        ' PROPERTY NUMBER PREFIX
        '====================================================

        Dim basePrefix As String =
            acquiredYear.ToString("0000") &
            "-" &
            subMajor &
            "-" &
            gl

        Dim propertyPrefix As String = basePrefix

        If classificationGroup = "SEMI" Then
            propertyPrefix &= "-" & semiSuffix
        End If

        Dim nextNumber As Integer =
            GetNextPropertySequence(
                basePrefix,
                classificationGroup,
                accountCode,
                acquiredYear)

        Return propertyPrefix &
               "-" &
               nextNumber.ToString("0000")

    End Function


    '========================================================
    ' ACCOUNT CODE MAPPING
    '========================================================

    Private Function GetAccountCodeMapping(
        accountCode As String,
        ByRef ppeSubMajor As String,
        ByRef ppeGL As String,
        ByRef semiSubMajor As String,
        ByRef semiGL As String
    ) As Boolean

        Dim code As String =
            accountCode.Trim().ToUpper()

        Select Case code

            Case "LAND"

                ppeSubMajor = "01"
                ppeGL = "00"

            Case "OTHER LAND IMPROVEMENT"

                ppeSubMajor = "02"
                ppeGL = "99"

            Case "POWER SUPPLY SYSTEM"

                ppeSubMajor = "03"
                ppeGL = "05"

            Case "BUILDINGS"

                ppeSubMajor = "04"
                ppeGL = "08"

            Case "HOSPITALS AND HEALTH CENTERS"

                ppeSubMajor = "04"
                ppeGL = "03"

            Case "OTHER STRUCTURES"

                ppeSubMajor = "04"
                ppeGL = "99"

            Case "MACHINERY"

                ppeSubMajor = "05"
                ppeGL = "01"

                semiSubMajor = "05"
                semiGL = "01"

            Case "OFFICE EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "02"

                semiSubMajor = "05"
                semiGL = "02"

            Case "INFORMATION AND COMMUNICATION TECHNOLOGY TECHNOLOGY EQUIPMENT",
                 "INFORMATION AND COMMUNICATION TECHNOLOGY EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "03"

                semiSubMajor = "05"
                semiGL = "03"

            Case "COMMUNICATION EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "07"

                semiSubMajor = "05"
                semiGL = "07"

            Case "DISASTER RESPONSE AND RESCUE EQUIPMENT",
                 "DISASTER RISK AND RESPONSE EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "09"

                semiSubMajor = "05"
                semiGL = "08"

            Case "MILITARY, POLICE AND SECURITY EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "10"

                semiSubMajor = "05"
                semiGL = "09"

            Case "MEDICAL EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "11"

                semiSubMajor = "05"
                semiGL = "10"

            Case "TECHNICAL AND SCIENTIFIC EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "14"

                semiSubMajor = "05"
                semiGL = "13"

            Case "OTHER MACHINERIES AND EQUIPMENT",
                 "OTHER MACHINERY AND EQUIPMENT"

                ppeSubMajor = "05"
                ppeGL = "99"

                semiSubMajor = "05"
                semiGL = "99"

            Case "MOTOR VEHICLES",
                 "MOTOR VEHICLE"

                ppeSubMajor = "06"
                ppeGL = "01"

                semiSubMajor = "05"
                semiGL = "07"

            Case "FURNITURE AND FIXTURES"

                ppeSubMajor = "07"
                ppeGL = "01"

                semiSubMajor = "06"
                semiGL = "01"

            Case "BOOKS"

                ppeSubMajor = "07"
                ppeGL = "02"

                semiSubMajor = "06"
                semiGL = "02"

            Case "OTHER PROPERTY PLANT AND EQUIPMENT"

                ppeSubMajor = "99"
                ppeGL = "99"

            Case Else

                Return False

        End Select

        Return True

    End Function
    '========================================================
    ' GET ESTIMATED USEFUL LIFE
    '
    ' PPE:
    '   Uses EUL_PPE
    '
    ' SEMI-HV:
    '   Uses EUL_SEMI
    '
    ' SEMI-LV:
    '   Uses EUL_SEMI_LV
    '
    ' Motor Vehicles are always PPE.
    '========================================================

    Public Function GetEUL(
    accountCode As String,
    unitCost As Double,
    article As String
) As String

        If String.IsNullOrWhiteSpace(accountCode) Then
            Return ""
        End If

        Dim code As String =
        accountCode.Trim().ToUpper()

        Dim articleText As String =
        If(article, "").Trim().ToUpper()

        '====================================================
        ' DETERMINE CLASSIFICATION
        '====================================================

        Dim isMotorVehicle As Boolean =
        code.Contains("MOTOR VEHICLE") OrElse
        code.Contains("MOTOR VEHICLES") OrElse
        articleText.Contains("MOTOR VEHICLE")

        Dim classificationGroup As String
        Dim semiSuffix As String = ""

        If isMotorVehicle OrElse unitCost >= 50000 Then

            classificationGroup = "PPE"

        ElseIf unitCost >= 5000 Then

            classificationGroup = "SEMI"
            semiSuffix = "HV"

        Else

            classificationGroup = "SEMI"
            semiSuffix = "LV"

        End If

        '====================================================
        ' EUL VALUES FROM THE EXCEL EUL TABLE
        '====================================================

        Select Case code

            Case "LAND"

                If classificationGroup = "PPE" Then
                    Return "10"
                End If

            Case "OTHER LAND IMPROVEMENT"

                If classificationGroup = "PPE" Then
                    Return "10"
                End If

            Case "POWER SUPPLY SYSTEM"

                If classificationGroup = "PPE" Then
                    Return "10"
                End If

            Case "BUILDINGS"

                If classificationGroup = "PPE" Then
                    Return "30"
                End If

            Case "HOSPITALS AND HEALTH CENTERS"

                If classificationGroup = "PPE" Then
                    Return "40"
                End If

            Case "OTHER STRUCTURES"

                If classificationGroup = "PPE" Then
                    Return "30"
                End If

            Case "MACHINERY"

                If classificationGroup = "PPE" Then
                    Return "10"
                Else
                    Return "5"
                End If

            Case "OFFICE EQUIPMENT"

                Return "5"

            Case "INFORMATION AND COMMUNICATION TECHNOLOGY EQUIPMENT"

                Return "5"

            Case "COMMUNICATION EQUIPMENT"

                If classificationGroup = "PPE" Then
                    Return "10"
                Else
                    Return "5"
                End If

            Case "DISASTER RESPONSE AND RESCUE EQUIPMENT"

                If classificationGroup = "SEMI" Then
                    Return "7"
                End If

            Case "MILITARY, POLICE AND SECURITY EQUIPMENT"

                Return "10"

            Case "MEDICAL EQUIPMENT"

                If classificationGroup = "PPE" Then
                    Return "10"
                Else
                    Return "5"
                End If

            Case "TECHNICAL AND SCIENTIFIC EQUIPMENT"

                If classificationGroup = "PPE" Then
                    Return "10"
                Else
                    Return "5"
                End If

            Case "OTHER MACHINERIES AND EQUIPMENT"

                Return "5"

            Case "MOTOR VEHICLES"

                Return "7"

            Case "FURNITURE AND FIXTURES"

                If classificationGroup = "PPE" Then
                    Return "5"

                ElseIf semiSuffix = "HV" Then
                    Return "5"

                Else
                    Return "2"
                End If

            Case "BOOKS"

                Return "5"

            Case "OTHER PROPERTY PLANT AND EQUIPMENT"

                If classificationGroup = "PPE" Then
                    Return "10"
                End If

        End Select

        'No EUL applicable
        Return ""

    End Function

    '========================================================
    ' FIND NEXT SEQUENCE
    '
    ' PPE:
    '   sequence is independent from SEMI
    '
    ' SEMI:
    '   HV + LV share the same sequence
    '
    ' The year is part of the prefix, so the sequence
    ' starts again for a new year.
    '========================================================

    Private Function GetNextPropertySequence(
    basePrefix As String,
    classificationGroup As String,
    accountCode As String,
    acquiredYear As Integer
     ) As Integer

        Dim highestNumber As Integer = 0

        Using conn As New SQLiteConnection(ConnString)

            conn.Open()

            '=========================================
            ' IMPORTANT:
            ' The sequence is NOT reset by year.
            '
            ' We therefore search all Property Numbers
            ' belonging to the same Account Code.
            '=========================================

            Dim sql As String =
            "SELECT PropertyNo " &
            "FROM InventoryDB " &
            "WHERE AccountCode = @AccountCode " &
            "AND PropertyNo IS NOT NULL"

            Using cmd As New SQLiteCommand(sql, conn)

                cmd.Parameters.AddWithValue(
                "@AccountCode",
                accountCode)

                Using reader As SQLiteDataReader =
                cmd.ExecuteReader()

                    While reader.Read()

                        Dim propertyNo As String =
                        reader("PropertyNo").ToString().Trim()

                        If String.IsNullOrWhiteSpace(propertyNo) Then
                            Continue While
                        End If

                        Dim parts() As String =
                        propertyNo.Split("-"c)

                        '=========================================
                        ' PPE
                        '
                        ' Format:
                        ' YYYY-SM-GL-####
                        '
                        ' Example:
                        ' 2025-05-02-0001
                        ' 2026-05-02-0002
                        '
                        ' Year is deliberately IGNORED.
                        '=========================================

                        If classificationGroup = "PPE" Then

                            If parts.Length = 4 Then

                                Dim existingNumber As Integer

                                If Integer.TryParse(
                                parts(3),
                                existingNumber) Then

                                    If existingNumber > highestNumber Then
                                        highestNumber = existingNumber
                                    End If

                                End If

                            End If

                            '=========================================
                            ' SEMI
                            '
                            ' Format:
                            ' YYYY-SM-GL-HV-####
                            ' YYYY-SM-GL-LV-####
                            '
                            ' HV and LV share ONE sequence.
                            ' Year is deliberately IGNORED.
                            '=========================================

                        ElseIf classificationGroup = "SEMI" Then

                            If parts.Length = 5 Then

                                Dim suffix As String =
                                parts(3).ToUpper()

                                If suffix = "HV" OrElse
                               suffix = "LV" Then

                                    Dim existingNumber As Integer

                                    If Integer.TryParse(
                                    parts(4),
                                    existingNumber) Then

                                        If existingNumber > highestNumber Then
                                            highestNumber = existingNumber
                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End While

                End Using

            End Using

        End Using

        Return highestNumber + 1

    End Function

End Module