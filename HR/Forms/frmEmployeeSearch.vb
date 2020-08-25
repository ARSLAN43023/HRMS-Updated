Public Class frmEmployeeSearch
    Public sCalledForm As String
    Dim sSql As String
    Dim sQueryForTransfer As String

    Private Sub frmEmployeeSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = frmMdiMain
        Me.Location = New Point(0, 0)
        PopulateControl(cbLocation, "Select Id, BranchName From HR_PRMBranch", "Id", "BranchName")
        ClearForm()

        If sCalledForm = "Employee Profile DW" Then

            chkHOD.Visible = False
            chkTechnical.Visible = False

        End If

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
           "From EM_Employee Where 1 = 1 And BranchId In(Select nBranchId From EM_UserBranchRights Where vcUserId= '" & Trim(frmUserLogin.txtUserID.Text) & "') " & sCriteria
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
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
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

    Public Sub sendResultsToPromotionsForm()
        ' frmAppraisals_Discipline.Show()
        frmAppraisals_Discipline.SearchRecords(grdSearch.Columns(0).Value, sQueryForTransfer)
        ' frmAppraisals_Discipline.Focus()

    End Sub

    Private Sub SendResultsToMainForm()
        If grdSearch.RowCount = 0 Then Exit Sub

        'If Not IsFormLoaded("frmEmployeeProfile", 1, False) Then 
        If sCalledForm = "Employee Profile" Then
            frmEmployeeProfile.Show()
            frmAppraisals_Discipline.Show()
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
        ElseIf sCalledForm = "Appraisals_Discipline" Then
            frmAppraisals_Discipline.Show()
            frmAppraisals_Discipline.SearchRecords(grdSearch.Columns(0).Value, sQueryForTransfer)
            frmAppraisals_Discipline.Focus()
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call SearchRecords()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call ClearForm()
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click

        Try

            If sCalledForm = "Employee Profile" Then
                Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
                Dim Main As frmMdiMain = CType(Application.OpenForms("frmMdiMain"), frmMdiMain)
                Dim empProfile As frmEmployeeProfile = CType(Application.OpenForms("frmEmployeeProfile"), frmEmployeeProfile)
                '  Main.cmdApp.Visible = True
                '  empProfile.cmdApp.Visible = True
                Main.AppraisalsDisciiplineToolStripMenuItem.Visible = True
                Main.cmdApp.Location = New Point(161, 3)
                Main.cmdStatus.Location = New Point(311, 3)

                f3.Show()
                f3.WindowState = FormWindowState.Minimized
                f3.Location = New Point(0, 0)
                Me.Close()

                Call SendResultsToMainForm()
                Call sendResultsToPromotionsForm()

                frmEmployeeProfile.Visible = True
                frmEmployeeProfile.Refresh()
                For Each ctrl In frmEmployeeProfile.Controls
                    ctrl.refresh()
                Next

            ElseIf sCalledForm = "Employee Status" Then
                Call SendResultsToMainForm()


            ElseIf sCalledForm = "Employee Profile DW" Then

                Call SendResultsToMainForm()

            End If

        Catch ex As Exception

            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub grdSearch_DoubleClick(sender As Object, e As EventArgs) Handles grdSearch.DoubleClick
        Try

            If sCalledForm = "Employee Profile" Then
                Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
                Dim Main As frmMdiMain = CType(Application.OpenForms("frmMdiMain"), frmMdiMain)
                Dim empProfile As frmEmployeeProfile = CType(Application.OpenForms("frmEmployeeProfile"), frmEmployeeProfile)
                ' Main.cmdApp.Visible = True
                ' empProfile.cmdApp.Visible = True
                Main.AppraisalsDisciiplineToolStripMenuItem.Visible = True
                Main.cmdApp.Location = New Point(161, 3)
                Main.cmdStatus.Location = New Point(311, 3)
                f3.Show()
                f3.WindowState = FormWindowState.Minimized
                f3.Location = New Point(0, 0)
                Me.Close()
                Call SendResultsToMainForm()
                Call sendResultsToPromotionsForm()

                frmEmployeeProfile.Visible = True
                frmEmployeeProfile.Refresh()
                For Each ctrl In frmEmployeeProfile.Controls
                    ctrl.refresh()
                Next

            ElseIf sCalledForm = "Employee Status" Then
                Call SendResultsToMainForm()


            ElseIf sCalledForm = "Employee Profile DW" Then

                Call SendResultsToMainForm()
                Me.Close()

            End If

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub tlbToolbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tlbToolbar.ItemClicked

    End Sub

    Private Sub chkHOD_CheckedChanged(sender As Object, e As EventArgs) Handles chkHOD.CheckedChanged

    End Sub

    Private Sub chkTechnical_CheckedChanged(sender As Object, e As EventArgs) Handles chkTechnical.CheckedChanged

    End Sub
End Class