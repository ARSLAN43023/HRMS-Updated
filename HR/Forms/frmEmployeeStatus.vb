Public Class frmEmployeeStatus
    Dim nEmployeeId As Integer = Nothing
    Dim nIsActive As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim nStatus As Integer
    Dim sAction As String
    Dim nDocumentNo As Integer

    Private Sub frmEmployeeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Clear()
    End Sub

    Private Sub Clear()
        txtDocumentNo.Text = ""
        txtDocumentNo.Tag = ""
        nEmployeeId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbStatus.SelectedIndex = -1
        cbStatus.Tag = cbStatus.SelectedIndex
        dtpDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Tag = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Checked = False
        txtRemarks.Text = ""
        txtRemarks.Tag = ""
        nStatus = Nothing
        slStatus.Text = "New"

        FillAudit()
    End Sub

    Private Sub Display()
        Clear()
        Dim rsEmployeeName As New ADODB.Recordset
        Dim sSql As String

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        txtDocumentNo.Text = Convert.ToString(rsMain("vcDocumentNo").Value)
        txtDocumentNo.Tag = txtDocumentNo.Text
        nEmployeeId = CInt(rsMain("nEmployeeId").Value)
        nDocumentNo = CInt(rsMain("nDocumentNo").Value)

        sSql = "Select FullName From EM_Employee Where Id = " & nEmployeeId
        rsEmployeeName.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        txtEmployeeName.Text = Convert.ToString(rsEmployeeName("FullName").Value)
        txtEmployeeName.Tag = txtEmployeeName.Text

        If Not IsDBNull(rsMain("nStatusId").Value) Then
            cbStatus.SelectedIndex = CInt(rsMain("nStatusId").Value)
            cbStatus.Tag = cbStatus.SelectedIndex
        End If

        If Not IsDBNull(rsMain("dtmDate").Value) Then
            dtpDate.Value = CDate(rsMain("dtmDate").Value)
            dtpDate.Tag = dtpDate.Value
            dtpDate.Checked = True
        Else
            dtpDate.Checked = False
        End If

        If Not IsDBNull(rsMain("vcRemarks").Value) Then
            txtRemarks.Text = Convert.ToString(rsMain("vcRemarks").Value)
            txtRemarks.Tag = txtRemarks.Text
        End If

        nStatus = CInt(rsMain("nsStatusId").Value)
        If nStatus = 3 Then
            slStatus.Text = "Approved"
        Else
            slStatus.Text = "Pending"
        End If

        FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Public Sub SearchRecords(ByVal a_sSql As String, ByVal a_sDocNo As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("vcDocumentNo = '" & a_sDocNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim nEmployeeStatus As Integer
        Dim rsMisc As New ADODB.Recordset

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        If Trim(txtDocumentNo.Text) = "" Then
            If rsMain.State <> 1 Then
                sSql = "Select * From EM_EmployeeStatus Where 1 = 2"
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            rsMain.AddNew()

            sSql = "Select MAX(nDocumentNo) nDocumentNo From EM_EmployeeStatus"
            rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            If Not IsDBNull(rsMisc("nDocumentNo").Value) Then
                nDocumentNo = CInt(rsMisc("nDocumentNo").Value)
                nDocumentNo = nDocumentNo + 1
            Else
                nDocumentNo = 1
            End If

            txtDocumentNo.Text = "EMPST-1-" & nDocumentNo

            rsMain!vcDocumentNo = txtDocumentNo.Text
            rsMain!nDocumentNo = nDocumentNo
            nStatus = 1
            sAction = "Prepared"
        End If

        rsMain!nEmployeeId = nEmployeeId
        rsMain!nStatusId = cbStatus.SelectedIndex
        rsMain!dtmDate = dtpDate.Value
        rsMain!vcRemarks = txtRemarks.Text
        rsMain!nsStatusId = nStatus
        rsMain.Update()

        If nStatus = 3 Then
            sSql = "Update EM_Employee Set isActive = " & nIsActive & ", CurrentStatus = " & cbStatus.SelectedIndex & " Where Id = " & nEmployeeId
            conn.Execute(sSql)
            sAction = "Approved"

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
                nEmployeeId & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & cbStatus.SelectedItem & "', '" & sUserId & "', 'Status changed.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

            If (cbStatus.SelectedIndex = 5) Or (cbStatus.SelectedIndex = 0) Then
                nEmployeeStatus = 1
            Else
                nEmployeeStatus = 2
            End If
            sSql = "Insert Into HR_EmployeeActivationHistory (EmployeeId, ActionId, StatusId, FromDate, Reason, nCurrentStatus) " &
                   "Values(" & nEmployeeId & ", 3, " & nEmployeeStatus & ", '" & dtpDate.Value.ToString("dd MMM yyyy") & "', '" & cbStatus.Text & "', 4)"

            conn.Execute(sSql)
        End If

        'Try
        '    bProcessing = True

        '    sSql = "Update EM_Employee Set isActive = " & nIsActive & ", CurrentStatus = " & cbStatus.SelectedIndex & " Where Id = " & nEmployeeId
        '    conn.Execute(sSql)
        '    conn.CommitTrans()

        '    sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
        '   Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), 'Modified', '" & sUserId & "', 'Updated employee status.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        '    conn.Execute(sSql)

        'Catch ex As Exception
        '    MessageBox.Show("Error saving record.")
        'End Try

        sSql = "Insert Into EM_EmployeeStatusAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Trim(txtDocumentNo.Text) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        MsgBox("Employee status saved.", vbCritical)

        Display()

        bProcessing = False
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_EmployeeStatusAudit Where vcDocumentId = '" + Trim(txtDocumentNo.Text) + "' Order by dtmActionDate"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = Nothing
            grdAudit.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading audit entries.")
        End Try
        connODBC.Close()
        grdAudit.Refresh()
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset

        ValidateFields = False

        If nStatus = 3 Then
            MsgBox("Invalid action.", vbCritical)
        End If

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If cbStatus.SelectedIndex < 0 Then
            MsgBox("Please select status.", vbCritical)
            cbStatus.Focus()
            Exit Function
        End If

        If dtpDate.Checked = False Then
            MsgBox("Please select date.", vbCritical)
            dtpDate.Focus()
            Exit Function
        End If

        If (cbStatus.SelectedIndex = 0) Or (cbStatus.SelectedIndex = 5) Then
            nIsActive = 1
        Else
            nIsActive = 0
        End If

        sAction = "Prepared"
        If Trim(txtDocumentNo.Tag) <> "" Then
            sAction = "Modified"
            If a_nActionID = 4 Then
                nStatus = 3
                sAction = "Approved"
            End If
        End If

        'If Trim(txtDocumentNo.Tag) = "" Then
        '    sAction = "Prepared"
        '    nStatus = 1
        '    slStatus.Text = "Pending"
        'ElseIf a_nActionID = 0 Then 'Modify
        '    sAction = "Modified"
        '    nStatus = 1
        '    slStatus.Text = "Pending"
        'ElseIf a_nActionID = 3 Then
        '    sAction = "Approved"
        '    nStatus = 3
        '    slStatus.Text = "Approved"
        'End If

        ValidateFields = True
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If IsAnyFieldChanged() Then Exit Sub

        slStatus.Text = "Saving"

        Save()

        slStatus.Text = ""
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Save(4)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeStatusSearch.Show()
        frmEmployeeStatusSearch.Focus()
    End Sub

    Private Sub cmdSearchEmployee_Click(sender As Object, e As EventArgs) Handles cmdSearchEmployee.Click
        frmEmployeeSearch.sCalledForm = "Employee Status"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Public Sub GetEmployee(a_nId As Integer)
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        nEmployeeId = a_nId
        sSql = "Select FullName, CurrentStatus, IsActive From EM_Employee Where Id = " & nEmployeeId
        GetRecordSet(rsMisc, sSql)
        'rsMisc.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
        txtEmployeeName.Text = Convert.ToString(rsMisc("FullName").Value)
        If Not IsDBNull(rsMisc("CurrentStatus").Value) Then
            cbStatus.SelectedIndex = CInt(rsMisc("CurrentStatus").Value)
        Else
            If CInt(rsMisc("IsActive").Value) = True Then
                cbStatus.SelectedIndex = 0
            Else
                cbStatus.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Function IsAnyFieldChanged() As Boolean
        IsAnyFieldChanged = (Trim(txtDocumentNo.Text) <> Trim(txtDocumentNo.Tag)) Or
                            (Trim(txtEmployeeName.Text) <> Trim(txtEmployeeName.Tag)) Or (Trim(txtRemarks.Text) <> Trim(txtRemarks.Tag)) Or
                            (cbStatus.SelectedValue <> cbStatus.Tag) Or (dtpDate.Value <> dtpDate.Tag)
    End Function

End Class