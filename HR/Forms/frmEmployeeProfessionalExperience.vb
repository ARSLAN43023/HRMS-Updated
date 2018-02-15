Public Class frmEmployeeProfessionalExperience
    Dim nEmployeeId As Integer = Nothing
    Dim nJobId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean


    Private Sub frmEmployeeProfessionalExperience_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain

        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        PopulateControl(cbCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        Clear()
    End Sub

    Private Sub cbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCountry.SelectedIndexChanged
        PopulateControl(cbCity, "Select Id, Description From HR_PRMCity Where CountryId = " & IIf(IsNothing(cbCountry.SelectedValue), 969, cbCountry.SelectedValue).ToString() & " Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nJobId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        txtEmployer.Text = ""
        txtEmployer.Tag = ""
        txtDesignation.Text = ""
        txtDesignation.Tag = ""
        dtpFromDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpFromDate.Tag = dtpFromDate.Value
        dtpToDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpToDate.Tag = dtpToDate.Value
        cbCountry.SelectedIndex = -1
        cbCountry.Tag = cbCountry.SelectedIndex
        cbCity.SelectedIndex = -1
        cbCity.Tag = cbCity.SelectedIndex
        txtSalary.Text = ""
        txtSalary.Tag = ""
        txtBenefits.Text = ""
        txtBenefits.Tag = ""
        txtJobDescription.Text = ""
        txtJobDescription.Tag = ""
        txtReasonForLeaving.Text = ""
        txtReasonForLeaving.Tag = ""
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
        Dim sSql As String = "SELECT Id, Employer, Designation, FromDate, ToDate From HR_EmployeeJobHistory Where EmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdJobHistory.DataSource = Nothing
            grdJobHistory.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading job history.")
        End Try
        connODBC.Close()
        grdJobHistory.Refresh()
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
        frmEmployeeSearch.sCalledForm = "Employee Professional Experience"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub grdJobHistory_DoubleClick(sender As Object, e As EventArgs) Handles grdJobHistory.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeJobHistory Where Id = " & Convert.ToString(grdJobHistory.Columns(0).Value)

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nJobId = CInt(rsMisc("Id").Value)
        txtEmployer.Text = Convert.ToString(rsMisc("Employer").Value)
        txtEmployer.Tag = txtEmployer.Text
        txtDesignation.Text = Convert.ToString(rsMisc("Designation").Value)
        txtDesignation.Tag = txtDesignation.Text
        dtpFromDate.Value = CDate(rsMisc("FromDate").Value)
        dtpFromDate.Tag = dtpFromDate.Value
        dtpToDate.Value = CDate(rsMisc("ToDate").Value)
        dtpToDate.Tag = dtpToDate.Value
        cbCountry.SelectedValue = CInt(rsMisc("CountryId").Value)
        cbCountry.Tag = cbCountry.SelectedValue
        cbCity.SelectedValue = CInt(rsMisc("CityId").Value)
        cbCity.Tag = cbCity.SelectedValue
        txtSalary.Text = Convert.ToString(rsMisc("EmployeeLastSalary").Value)
        txtSalary.Tag = txtSalary.Text
        txtBenefits.Text = Convert.ToString(rsMisc("OtherBenefits").Value)
        txtBenefits.Tag = txtBenefits.Text
        txtJobDescription.Text = Convert.ToString(rsMisc("JobDescription").Value)
        txtJobDescription.Tag = txtJobDescription.Text
        txtReasonForLeaving.Text = Convert.ToString(rsMisc("ReasonForLeaving").Value)
        txtReasonForLeaving.Tag = txtReasonForLeaving.Text
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewJobId As Integer

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        'If txtEmployeeName.Text = "" Then Exit Sub
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        Try
            bProcessing = True
            conn.BeginTrans()

            If (nJobId = Nothing) Or (nJobId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeJobHistory"
                GetRecordSet(rsMisc, sSql)
                nNewJobId = CInt(rsMisc("Id").Value)
                nNewJobId += 1

                sSql = "Insert INTO HR_EmployeeJobHistory (Id, EmployeeId, Employer, Designation, JobDescription, FromDate, ToDate, EmployeeLastSalary" &
               ", OtherBenefits, ReasonForLeaving, CountryId, CityId) Values(" & nNewJobId & ", " & nEmployeeId & ", '" & AdjustSingleQuotes(txtEmployer.Text) &
               "', '" & AdjustSingleQuotes(txtDesignation.Text) & "', '" & AdjustSingleQuotes(txtJobDescription.Text) & "', '" & dtpFromDate.Value.ToString("dd MMM yyyy") &
               "', '" & dtpToDate.Value.ToString("dd MMM yyyy") & "', " & IIf(txtSalary.Text = "", 0, txtSalary.Text) & ", '" & AdjustSingleQuotes(txtBenefits.Text) &
               "', '" & AdjustSingleQuotes(txtReasonForLeaving.Text) & "', " & cbCountry.SelectedValue & ", " & cbCity.SelectedValue & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeJobHistory Set Employer = '" & AdjustSingleQuotes(txtEmployer.Text) & "', Designation = '" & AdjustSingleQuotes(txtDesignation.Text) &
                   "', FromDate = '" & dtpFromDate.Value.ToString("dd MMM yyyy") & "', ToDate = '" & dtpToDate.Value.ToString("dd MMM yyyy") &
                   "', CountryId = " & cbCountry.SelectedValue & ", CityId = " & cbCity.SelectedValue & ", EmployeeLastSalary = " & IIf(txtSalary.Text = "", 0, txtSalary.Text) &
                   ", OtherBenefits = '" & AdjustSingleQuotes(txtBenefits.Text) & "', JobDescription = '" & AdjustSingleQuotes(txtJobDescription.Text) &
                   "', ReasonForLeaving = '" & AdjustSingleQuotes(txtReasonForLeaving.Text) & "' Where Id = " & nJobId
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
        If nJobId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this job?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeJobHistory Where Id = " & nJobId & ""
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
        MsgBox("Job deleted successfully.", vbInformation)
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

        If txtEmployer.Text = "" Then
            MsgBox("Please enter employer.", vbCritical)
            txtEmployer.Focus()
            Exit Function
        End If

        If txtDesignation.Text = "" Then
            MsgBox("Please enter designation.", vbCritical)
            txtDesignation.Focus()
            Exit Function
        End If

        If cbCountry.SelectedIndex < 0 Then
            MsgBox("Please select country.", vbCritical)
            cbCountry.Focus()
            Exit Function
        End If

        If cbCity.SelectedIndex < 0 Then
            MsgBox("Please select city.", vbCritical)
            cbCity.Focus()
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