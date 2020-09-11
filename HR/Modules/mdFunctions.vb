Module mdFunctions
    Public conn As New ADODB.Connection
    'Public sConnectionString As String = "Dsn=ERP;uid=sa"
    Public sConnectionString As String = "Dsn=ERP;uid=sa"
    'Public sConnectionString As String = "Dsn=ERPACL;uid=sa;pwd=Delt@13l;pwd=Delt@13l"

    Public sUserId As String
    Public sCompanyId As String
    Public sVersion = "1822"
    Public g_nCompanyId As Integer
    Public g_sIsOtherCmpany As String
    Public g_sLoggedInUser As String
    Public Const AIS_SUCCESS = 0
    Public Const AIS_FAILURE = 1
    Public g_sConnectionLoginId As String
    Public g_sDSN As String
    Public g_sPassword As String
    Public g_sConnectionPassword As String
    Public nlResult As Integer
    Public connectionString As String

    Public Function GetRecordSet(ByRef rsRecordset As ADODB.Recordset, ByVal sSql As String) As Long
        Dim rsQuery As New ADODB.Recordset

        rsQuery.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        If rsQuery.State = ADODB.ObjectStateEnum.adStateOpen Then rsQuery.Close()
        rsQuery.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsQuery.RecordCount > 0 Then rsQuery.MoveFirst()

        rsRecordset = rsQuery
        GetRecordSet = 0
    End Function

    Public Sub PopulateControl(ByVal ctrlControl As Control, ByVal a_sSql As String, ByVal a_nID As String, ByVal a_sDescription As String)
        Dim connetionString As String = Nothing
        Dim conn As Odbc.OdbcConnection
        Dim command As Odbc.OdbcCommand
        Dim adapter As New Odbc.OdbcDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim nlResult As Long
        Dim sSql As String = a_sSql

        conn = New Odbc.OdbcConnection(connectionString)
        Try
            conn.Open()
            command = New Odbc.OdbcCommand(sSql, conn)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            conn.Close()
            If TypeOf ctrlControl Is ComboBox Then
                Dim cbComboBox As ComboBox = DirectCast(ctrlControl, ComboBox)
                cbComboBox.DisplayMember = a_sDescription
                cbComboBox.ValueMember = a_nID
                cbComboBox.DataSource = ds.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show("Could Not connect To database.")
        End Try
    End Sub

    Public Function AdjustSingleQuotes(ByVal a_sStr As String)
        Dim nIndex As Integer
        Dim sLocalStr As String
        Dim cCharacter As String

        sLocalStr = ""
        For nIndex = 1 To Len(a_sStr)
            cCharacter = Mid(a_sStr, nIndex, 1)
            If cCharacter = "'" Then
                sLocalStr = sLocalStr & "'" & "'"
            Else
                sLocalStr = sLocalStr & cCharacter
            End If
        Next
        AdjustSingleQuotes = sLocalStr
    End Function

    Public Function GetDocNumber(a_sDocType As String, a_sDocPrefix As String, a_sFormat As String) As String

        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nSeqNo As String
        'Dim nFyId As Long

        nSeqNo = 1

        Try
            sSql = "Select * From cDocumentNumbers Where vcDocumentNumber = '" & a_sDocType & "' And vcLocation = '1'"
            rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            If rsMisc.RecordCount > 0 Then
                nSeqNo = Convert.ToString(rsMisc("nSequenceNumber").Value)
            Else
                rsMisc.AddNew()

                'nFyId = GetFinYearID(GetServerDate)

                rsMisc!nCompanyId = 1
                rsMisc!vcDocumentNumber = a_sDocType
                rsMisc!vcLocation = 1
                rsMisc!nFinancialYear = 15 'nFyId
                rsMisc!vcPrefix = ""
                rsMisc!nVoucherMonth = 0
            End If

            rsMisc!nSequenceNumber = nSeqNo + 1
            rsMisc.Update()

        Catch ex As Exception
            MsgBox("Error getting document no." & ex.Message, vbCritical)
        End Try

        GetDocNumber = a_sDocPrefix & "-1-" & Format(nSeqNo, a_sFormat)
    End Function

    Public Function IsDuplicateNo(a_sDocNo As String, a_sTable As String, a_sFldName As String) As Boolean
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset

        sSql = "Select * From " & a_sTable & " Where " & a_sFldName & " = '" & a_sDocNo & "'"
        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        IsDuplicateNo = (rsMisc.RecordCount > 0)
    End Function

End Module
