Public Class frmEmployeeSearch
    Public sCalledForm As String
    Dim sSql As String
    Dim sQueryForTransfer As String

    Private Sub frmEmployeeSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        PopulateControl(cbLocation, "Select Id, BranchName From HR_PRMBranch", "Id", "BranchName")
        ClearForm()
    End Sub

    Private Sub cbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLocation.SelectedIndexChanged
        If cbLocation.SelectedIndex <> -1 Then
            PopulateControl(cbDepartment, "Select Id, Description From HR_PRMDepartments Where BranchId = " + cbLocation.SelectedValue.ToString() + " Order by Description", "Id", "Description")
            cbDepartment.SelectedIndex = -1
        End If
    End Sub

    Private Sub ClearForm()
        txtEmployeeNo.Text = ""
        txtEmployeeName.Text = ""
        cbLocation.SelectedIndex = -1
        cbDepartment.SelectedIndex = -1
        chkHOD.CheckState = 0
        chkNewEmployees.CheckState = 0
        chkTechnical.CheckState = 0
        grdSearch.DataSource = Nothing
        grdSearch.Rebind(True)

        If sCalledForm = "Employee Status" Then
            chkAllEmployees.Visible = True
        Else
            chkAllEmployees.Visible = False
        End If
        chkAllEmployees.CheckState = 0
    End Sub
    Private Function GetQuery() As String
        Dim sSql As String
        Dim sCriteria As String = ""

        If Trim(txtEmployeeNo.Text) <> "" Then
            sCriteria = sCriteria & " And EmployeeNo = '" & Trim(txtEmployeeNo.Text) & "'"
        End If

        If Trim(txtEmployeeName.Text) <> "" Then
            sCriteria = sCriteria & " And FullName Like '%" & Trim(txtEmployeeName.Text) & "%'"
        End If

        If cbDepartment.SelectedValue <> Nothing Then
            sCriteria = sCriteria & " And DepartmentId = " & cbDepartment.SelectedValue
        End If

        If cbLocation.SelectedValue <> Nothing Then
            sCriteria = sCriteria & " And BranchId = " & cbLocation.SelectedValue
        End If

        If chkNewEmployees.CheckState = 1 Then sCriteria = sCriteria & " And isTechnical = -1"

        If chkTechnical.CheckState = 1 Then sCriteria = sCriteria & " And isTechnical = " & chkTechnical.CheckState

        If chkHOD.CheckState = 1 Then sCriteria = sCriteria & " And IsHeadOfDepartment = " & chkHOD.CheckState

        If chkAllEmployees.CheckState = 0 Then
            sCriteria = sCriteria & " And isActive = 1"
        End If

        If sCalledForm = "Employee Profile DW" Then
            sSql = "Select EmployeeNo, FirstName + ' ' + LastName As FullName, dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment, 0 As isTechnical, Id " &
           "From HR_Employee Where EmployeetypeId = 820 " & sCriteria
        Else
            sSql = "Select EmployeeNo, FullName, dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment, isTechnical, Id " &
           "From EM_Employee Where 1 = 1 " & sCriteria
        End If

        sSql = sSql & " Order by EmployeeNo"

        If sCalledForm = "Employee Profile DW" Then
            sQueryForTransfer = "Select * From HR_Employee Where 1 = 1 " & sCriteria & " Order By EmployeeNo "
        Else
            sQueryForTransfer = "Select * From EM_Employee Where 1 = 1 " & sCriteria & " Order By EmployeeNo "
        End If

        GetQuery = sSql
    End Function

    Private Sub SearchRecords()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()

        Dim sSql As String = GetQuery()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            'grdSearch.DataSource = ds.Tables(0)
            'grdSearch.Rebind(holdFields:=True)
            grdSearch.DataSource = Nothing
            grdSearch.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error getting results.")
        End Try
        connODBC.Close()
    End Sub

    Private Sub SendResultsToMainForm()
        If grdSearch.RowCount = 0 Then Exit Sub

        'If Not IsFormLoaded("frmEmployeeProfile", 1, False) Then 
        If sCalledForm = "Employee Profile" Then
            frmEmployeeProfile.Show()
            frmEmployeeProfile.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeProfile.Focus()
        ElseIf sCalledForm = "Employee Profile DW" Then
            frmEmployeeProfileDW.Show()
            frmEmployeeProfileDW.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeProfileDW.Focus()
        ElseIf sCalledForm = "Employee Professional Experience" Then
            frmEmployeeProfessionalExperience.Show()
            frmEmployeeProfessionalExperience.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeProfessionalExperience.Focus()
        ElseIf sCalledForm = "Employee Dependents" Then
            frmEmployeeDependents.Show()
            frmEmployeeDependents.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeDependents.Focus()
        ElseIf sCalledForm = "Employee Qualifications" Then
            frmEmployeeQualifications.Show()
            frmEmployeeQualifications.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeQualifications.Focus()
        ElseIf sCalledForm = "Employee Promotions" Then
            frmEmployeePromotions.Show()
            frmEmployeePromotions.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeePromotions.Focus()
        ElseIf sCalledForm = "Employee Bank Account" Then
            frmEmployeeBankAccount.Show()
            'frmEmployeeBankAccount.SearchRecords("Select Id, dbo.emGetEmployeeName(EmployeeId) EmployeeName, EmployeeId, BankAccountNo, AccountTitle, BankId, BankBranch From HR_EmployeeBankAccount Where EmployeeId = " & grdSearch.Columns(6).Value, grdSearch.Columns(6).Value)
            frmEmployeeBankAccount.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeBankAccount.Focus()
        ElseIf sCalledForm = "Employee Awards" Then
            frmEmployeeAwards.Show()
            frmEmployeeAwards.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeAwards.Focus()
        ElseIf sCalledForm = "Employee Training/Course/Seminar" Then
            frmEmployeeCourseSeminar.Show()
            frmEmployeeCourseSeminar.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeCourseSeminar.Focus()
        ElseIf sCalledForm = "Employee Discipline" Then
            frmEmployeeDiscipline.Show()
            frmEmployeeDiscipline.SearchRecords(sQueryForTransfer, grdSearch.Columns(0).Value)
            frmEmployeeDiscipline.Focus()
        ElseIf sCalledForm = "Employee Status" Then
            frmEmployeeStatus.Show()
            frmEmployeeStatus.GetEmployee(grdSearch.Columns(6).Value)
            frmEmployeeStatus.Focus()
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call SearchRecords()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearForm()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        Call SendResultsToMainForm()
    End Sub

    Private Sub grdSearch_DoubleClick(sender As Object, e As EventArgs) Handles grdSearch.DoubleClick
        Call SendResultsToMainForm()
    End Sub
End Class