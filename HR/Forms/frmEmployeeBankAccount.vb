Public Class frmEmployeeBankAccount
    Dim nEmployeeId As Integer = Nothing
    Dim nBankAccountId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeeBankAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        PopulateControls()
        Clear()
    End Sub

    Private Sub PopulateControls()
        PopulateControl(cbBank, "Select Id, Description From HR_PRMBank Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nBankAccountId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbBank.SelectedIndex = -1
        cbBank.Tag = cbBank.SelectedIndex
        txtAccountNo.Text = ""
        txtAccountNo.Tag = ""
        txtBranch.Text = ""
        txtBranch.Tag = ""
    End Sub

    Private Sub Display()
        Dim sSql As String
        Dim rsBankAccount As New ADODB.Recordset
        Clear()

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        nEmployeeId = CInt(rsMain("Id").Value)
        txtEmployeeName.Text = Convert.ToString(rsMain("FullName").Value)
        txtEmployeeName.Tag = txtEmployeeName.Text

        sSql = "Select * From HR_EmployeeBankAccount Where EmployeeId = " & nEmployeeId
        rsBankAccount.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsBankAccount.RecordCount > 0 Then
            nBankAccountId = CInt(rsBankAccount("Id").Value)
            txtAccountNo.Text = Convert.ToString(rsBankAccount("BankAccountNo").Value)
            txtAccountNo.Tag = txtAccountNo.Text
            txtAccountTitle.Text = Convert.ToString(rsBankAccount("AccountTitle").Value)
            txtAccountTitle.Tag = txtAccountTitle.Text
            cbBank.SelectedValue = CInt(rsBankAccount("BankId").Value)
            cbBank.Tag = cbBank.SelectedValue
            If Not IsDBNull(rsBankAccount("BankBranch").Value) Then
                txtBranch.Text = Convert.ToString(rsBankAccount("BankBranch").Value)
                txtBranch.Tag = txtBranch.Text
            End If
        End If

        FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Public Sub SearchRecords(ByVal a_sSql As String, ByVal a_sEmpNo As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("EmployeeNo = '" & a_sEmpNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Employee Bank Account"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewBankAccountId As Integer


        Try

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            bProcessing = True

            If (nBankAccountId = Nothing) Or (nBankAccountId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeBankAccount"
                GetRecordSet(rsMisc, sSql)
                nNewBankAccountId = CInt(rsMisc("Id").Value)
                nNewBankAccountId += 1

                sSql = "Insert INTO HR_EmployeeBankAccount (Id, EmployeeId, BankAccountNo, AccountTitle, BankId, BankBranch)" &
                       "Values(" & nNewBankAccountId & ", " & nEmployeeId & ", '" & txtAccountNo.Text & "', '" & txtAccountTitle.Text &
                       "', " & IIf(cbBank.SelectedIndex < 0, 0, cbBank.SelectedValue) & ", '" & txtBranch.Text & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeBankAccount Set BankAccountNo = '" & txtAccountNo.Text & "', AccountTitle = '" & txtAccountTitle.Text &
                       "', BankId = " & IIf(cbBank.SelectedIndex < 0, 0, cbBank.SelectedValue) & ", BankBranch = '" & txtBranch.Text & "'Where EmployeeId=" & nEmployeeId
                conn.Execute(sSql)
            End If

            ' sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            '  Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '" & sAction & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            '  conn.Execute(sSql)

            If nEmployeeId <> Nothing Then
                sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
                If rsMain.State = 1 Then rsMain.Close()
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If
        Catch ex As Exception
            MsgBox("Error Saving Bank Account " & ex.Message)

        End Try

        Display()

        conn.Close()

        bProcessing = False
        slStatus.Text = ""
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nBankAccountId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this bank account?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeBankAccount Where Id = " & nBankAccountId
        conn.Execute(sSql)
        'sSql = "Delete From EM_Employee_Audit Where vcDocumentId = '" & Trim(txtEmpID.Text) & "'"
        'conn.Execute(sSql)

        If nEmployeeId <> Nothing Then
            sSql = "Select * From HR_EmployeeBankAccount Where EmployeeId = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        conn.Close()
        MsgBox("Bank account deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_Employee_Audit Where vcDocumentId = '" + Convert.ToString(nEmployeeId) + "' Order by dtmActionDate"

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

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If cbBank.SelectedIndex < 0 Then
            MsgBox("Please select bank.", vbCritical)
            cbBank.Focus()
            Exit Function
        End If

        If txtAccountTitle.Text = "" Then
            MsgBox("Please enter account title.", vbCritical)
            txtAccountTitle.Focus()
            Exit Function
        End If

        sAction = "Prepared"
        If nBankAccountId > 0 Then
            sAction = "Modified"
            'If a_nActionID = 5 Then
            '    nStatus = 6
            '    sAction = "Verified"
            'End If
            'If a_nActionID = 4 Then
            '    nStatus = 3
            '    r_sAction = "Approved"
            'End If
        End If
        ValidateFields = True
    End Function

    Private Function IsAnyFieldChanged() As Boolean
        IsAnyFieldChanged = (nEmployeeId = 0) Or (nBankAccountId = 0) Or (Trim(txtAccountNo.Text) <> Trim(txtAccountNo.Tag)) Or
                            (Trim(txtAccountTitle.Text) <> Trim(txtAccountTitle.Tag)) Or (Trim(txtBranch.Text) <> Trim(txtBranch.Tag)) Or
                            (cbBank.SelectedValue <> cbBank.Tag)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ((nEmployeeId = 0) Or IsAnyFieldChanged()) Then Exit Sub
        slStatus.Text = "Saving"
        Call Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub tlbToolbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tlbToolbar.ItemClicked

    End Sub
End Class