Public Class frmEmployeeDependents
    Dim nEmployeeId As Integer = Nothing
    Dim nDependentId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeeProfessionalExperience_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Clear()
    End Sub
    Private Sub Clear()
        nEmployeeId = Nothing
        nDependentId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        txtDependentName.Text = ""
        txtDependentName.Tag = ""
        txtCNIC.Text = ""
        txtCNIC.Tag = ""
        dtpDOB.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDOB.Tag = dtpDOB.Value
        dtpStatusSince.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpStatusSince.Tag = dtpStatusSince.Value
        cbMaritalStatus.SelectedIndex = -1
        cbMaritalStatus.Tag = cbMaritalStatus.SelectedIndex
        cbRelation.SelectedIndex = -1
        cbRelation.Tag = cbRelation.SelectedIndex
        cbGender.SelectedIndex = -1
        cbGender.Tag = cbGender.SelectedIndex
        chkInsurance.Checked = False
        chkInsurance.Tag = chkInsurance.Checked

        FillGrid()
    End Sub

    Private Sub Display()
        Dim rsEmployeeName As New ADODB.Recordset
        Dim sSql As String
        Clear()

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        nEmployeeId = CInt(rsMain("Id").Value)
        sSql = "Select dbo.emGetEmployeeName(" & Convert.ToString(nEmployeeId) & ") vcEmployeeName From EM_Employee Where Id = " & nEmployeeId
        rsEmployeeName.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
        If rsEmployeeName.RecordCount > 0 Then
            txtEmployeeName.Text = Convert.ToString(rsEmployeeName("vcEmployeeName").Value)
            txtEmployeeName.Tag = txtEmployeeName.Text
        End If
        rsEmployeeName.Close()
        FillGrid()
        'FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Private Sub FillGrid()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT Id, Name, Relation, DATEDIFF(hour,DateOfBirth,GETDATE())/8766 AS Age, NICNo, InsuranceEntitlement From HR_EmployeeDependents Where EmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdDependents.DataSource = Nothing
            grdDependents.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading dependents.")
        End Try
        connODBC.Close()
        grdDependents.Refresh()
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
        frmEmployeeSearch.sCalledForm = "Employee Dependents"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub grdDependents_DoubleClick(sender As Object, e As EventArgs) Handles grdDependents.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeDependents Where Id = " & Convert.ToString(grdDependents.Columns(0).Value) & " And EmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nDependentId = CInt(rsMisc("Id").Value)
        txtDependentName.Text = Convert.ToString(rsMisc("Name").Value)
        txtDependentName.Tag = txtDependentName.Text

        If Not IsDBNull(rsMisc("NICNo").Value) Then
            txtCNIC.Text = Convert.ToString(rsMisc("NICNo").Value)
            txtCNIC.Tag = txtCNIC.Text
        End If

        If Not IsDBNull(rsMisc("DateOfBirth").Value) Then
            dtpDOB.Value = CDate(rsMisc("DateOfBirth").Value)
            dtpDOB.Tag = dtpDOB.Value
        Else
            dtpDOB.Checked = False
        End If

        If Not IsDBNull(rsMisc("MaritalStatusEffectiveFrom").Value) Then
            dtpStatusSince.Value = CDate(rsMisc("MaritalStatusEffectiveFrom").Value)
            dtpStatusSince.Tag = dtpStatusSince.Value
        End If

        If CInt(rsMisc("MaritalStatus").Value) = 0 Then
            cbMaritalStatus.SelectedIndex = -1
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 1 Then
            cbMaritalStatus.SelectedIndex = 0
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 2 Then
            cbMaritalStatus.SelectedIndex = 1
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 3 Then
            cbMaritalStatus.SelectedIndex = 2
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 4 Then
            cbMaritalStatus.SelectedIndex = 3
        End If
        cbMaritalStatus.Tag = cbMaritalStatus.SelectedIndex

        If CInt(rsMisc("Relation").Value) = 1 Then
            cbRelation.SelectedIndex = 1
        ElseIf CInt(rsMisc("Relation").Value) = 2 Then
            cbRelation.SelectedIndex = 0
        ElseIf CInt(rsMisc("Relation").Value) = 7 Then
            cbRelation.SelectedIndex = 2
        Else
            cbRelation.SelectedIndex = -1
        End If
        cbRelation.Tag = cbRelation.SelectedIndex

        If CInt(rsMisc("Gender").Value) = 1 Then
            cbGender.SelectedIndex = 0
        Else
            cbGender.SelectedIndex = 1
        End If
        cbGender.Tag = cbGender.SelectedIndex

        If CInt(rsMisc("InsuranceEntitlement").Value) = 0 Then
            chkInsurance.Checked = True
        Else
            chkInsurance.Checked = False
        End If
        chkInsurance.Tag = chkInsurance.Checked
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewDependentId As Integer
        Dim nRelation As Integer, nMaritalStatus As Integer, nGender As Integer, nInsurance As Integer

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        If cbMaritalStatus.SelectedIndex = -1 Then
            nMaritalStatus = 0
        ElseIf cbMaritalStatus.SelectedIndex = 0 Then
            nMaritalStatus = 1
        ElseIf cbMaritalStatus.SelectedIndex = 1 Then
            nMaritalStatus = 2
        ElseIf cbMaritalStatus.SelectedIndex = 2 Then
            nMaritalStatus = 3
        ElseIf cbMaritalStatus.SelectedIndex = 3 Then
            nMaritalStatus = 4
        End If

        If cbRelation.SelectedIndex = 0 Then
            nRelation = 2
        ElseIf cbRelation.SelectedIndex = 1
            nRelation = 1
        ElseIf cbRelation.SelectedIndex = 2
            nRelation = 7
        End If

        If cbGender.SelectedIndex = 0 Then
            nGender = 1
        Else
            nGender = 2
        End If

        If chkInsurance.Checked = True Then
            nInsurance = 0
        Else
            nInsurance = 1
        End If

        Try
            bProcessing = True
            conn.BeginTrans()

            If (nDependentId = Nothing) Or (nDependentId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeDependents Where EmployeeId = " & nEmployeeId
                GetRecordSet(rsMisc, sSql)
                nNewDependentId = CInt(rsMisc("Id").Value)
                nNewDependentId += 1

                sSql = "Insert INTO HR_EmployeeDependents (Id, EmployeeId, Name, Relation, DateOfBirth, NICNo, MaritalStatus" &
                   ", MaritalStatusEffectiveFrom, InsuranceEntitlement, Gender) Values(" & nNewDependentId & ", " & nEmployeeId & ", '" & AdjustSingleQuotes(txtDependentName.Text) &
                   "', " & nRelation & ", '" & dtpDOB.Value.ToString("dd MMM yyyy") & "', '" & AdjustSingleQuotes(txtCNIC.Text) &
                   "', " & nMaritalStatus & ", '" & dtpDOB.Value.ToString("dd MMM yyyy") & "', " & nInsurance & ", " & nGender & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeDependents Set Name = '" & AdjustSingleQuotes(txtDependentName.Text) & "', Relation = " & nRelation &
                       ", DateOfBirth = '" & dtpDOB.Value.ToString("dd MMM yyyy") & "', NICNo = '" & AdjustSingleQuotes(txtCNIC.Text) &
                       "', MaritalStatus = " & nMaritalStatus & ", MaritalStatusEffectiveFrom = '" & dtpStatusSince.Value.ToString("dd MMM yyyy") &
                       "', InsuranceEntitlement = " & nInsurance & ", Gender = " & nGender & " Where Id = " & nDependentId & " And EmployeeId = " & nEmployeeId
                conn.Execute(sSql)
            End If

            ' sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            'Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', 'MIS', 'Updated employee professional experience.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            ' conn.Execute(sSql)

            conn.CommitTrans()
        Catch ex As Exception
            MessageBox.Show("Error saving record.")
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        conn.Close()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nDependentId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this dependent?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeDependents Where Id = " & nDependentId & " And EmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        'sSql = "Delete From EM_Employee_Audit Where vcDocumentId = '" & Trim(txtEmpID.Text) & "'"
        'conn.Execute(sSql)

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        conn.Close()
        MsgBox("Dependent deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcWorkStation, vcActionRemarks From EM_Employee_Audit Where vcDocumentId = '" + Convert.ToString(nEmployeeId) + "'"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error loading Audit.")
        End Try
        connODBC.Close()
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset

        ValidateFields = False

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If txtDependentName.Text = "" Then
            MsgBox("Please enter dependent name.", vbCritical)
            txtDependentName.Focus()
            Exit Function
        End If

        If cbMaritalStatus.SelectedIndex < 0 Then
            MsgBox("Please select marital status.", vbCritical)
            cbMaritalStatus.Focus()
            Exit Function
        End If

        If cbRelation.SelectedIndex < 0 Then
            MsgBox("Please select relation.", vbCritical)
            cbRelation.Focus()
            Exit Function
        End If

        If cbGender.SelectedIndex < 0 Then
            MsgBox("Please select gender.", vbCritical)
            cbGender.Focus()
            Exit Function
        End If

        ValidateFields = True
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

End Class