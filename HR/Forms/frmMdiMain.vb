Public Class frmMdiMain


    Public Property stringpass As String
    Private Sub frmMdiMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.IsMdiContainer = True
        Me.WindowState = FormWindowState.Maximized
        cmdApp.Visible = False
        cmdStatus.Location = New Point(161, 3)

        If g_nCompanyId = 1 Then
            Me.Text = "Human Resource Management System - Fauji Cement Company Limited - Logged in: " & g_sLoggedInUser
        Else
            Me.Text = "Human Resource Management System - Askari Cement Company Limited - Logged in: " & g_sLoggedInUser
        End If

    End Sub

    Private Sub mnuProfessionalExperience_Click(sender As Object, e As EventArgs) Handles mnuProfessionalExperience.Click
        frmEmployeeProfessionalExperience.Show()
        frmEmployeeProfessionalExperience.Focus()
    End Sub
    Private Sub EmployeeProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmEmployeeProfile.Show()
        frmEmployeeProfile.Focus()
    End Sub

    Private Sub mnuDependents_Click(sender As Object, e As EventArgs) Handles mnuDependents.Click
        frmEmployeeDependents.Show()
        frmEmployeeDependents.Focus()
    End Sub

    Private Sub mnuEducation_Click(sender As Object, e As EventArgs) Handles mnuEducation.Click
        frmEmployeeQualifications.Show()
        frmEmployeeQualifications.Focus()
    End Sub

    Private Sub mnuPromotions_Click(sender As Object, e As EventArgs) Handles mnuPromotions.Click
        frmEmployeePromotions.Show()
        frmEmployeePromotions.Focus()
    End Sub

    Private Sub mnuBankAccounts_Click(sender As Object, e As EventArgs) Handles mnuBankAccounts.Click
        frmEmployeeBankAccount.Show()
        frmEmployeeBankAccount.Focus()
    End Sub

    Private Sub AwardsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuAwards.Click
        frmEmployeeAwards.Show()
        frmEmployeeAwards.Focus()
    End Sub

    Private Sub CourseSeminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuTrainingCourseSeminar.Click
        frmEmployeeCourseSeminar.Show()
        frmEmployeeCourseSeminar.Focus()
    End Sub

    Private Sub StatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem.Click
        frmEmployeeStatus.Show()
        frmEmployeeStatus.Focus()
    End Sub

    Private Sub mnuDiscipline_Click(sender As Object, e As EventArgs) Handles mnuDiscipline.Click
        frmEmployeeDiscipline.Show()
        frmEmployeeDiscipline.Focus()
    End Sub

    Private Sub frmMdiMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Exit()
    End Sub

    Private Sub cmdEmployeeProfile_Click(sender As Object, e As EventArgs) Handles cmdEmployeeProfile.Click

        frmEmployeeProfile.Show()
        frmEmployeeProfile.Visible = True

        frmAppraisals_Discipline.Show()
        frmEmployeeProfile.Focus()

        'frmEmployeeProfile.Visible = True
        'frmEmployeeProfile.Refresh()
        'For Each ctrl In frmEmployeeProfile.Controls
        '    ctrl.refresh()
        'Next
        'frmAppraisals_Discipline.Visible = False
        'frmAppraisals_Discipline.Refresh()
        'For Each ctrl1 In frmAppraisals_Discipline.Controls
        '    ctrl1.refresh()
        'Next
    End Sub

    Private Sub cmdStatus_Click(sender As Object, e As EventArgs) Handles cmdStatus.Click
        frmEmployeeStatus.Show()
        frmEmployeeStatus.Focus()
    End Sub

    Private Sub cmdPromotions_Click(sender As Object, e As EventArgs) Handles cmdPromotions.Click
        frmEmployeePromotions.Show()
        frmEmployeePromotions.Focus()
    End Sub

    Private Sub cmdBankAccount_Click(sender As Object, e As EventArgs) Handles cmdBankAccount.Click
        frmEmployeeBankAccount.Show()
        frmEmployeeBankAccount.Focus()
    End Sub

    Private Sub cmdAwards_Click(sender As Object, e As EventArgs) Handles cmdAwards.Click
        frmEmployeeAwards.Show()
        frmEmployeeAwards.Focus()
    End Sub

    Private Sub cmdTrainings_Click(sender As Object, e As EventArgs) Handles cmdTrainings.Click
        frmEmployeeCourseSeminar.Show()
        frmEmployeeCourseSeminar.Focus()
    End Sub

    Private Sub cmdDiscipline_Click(sender As Object, e As EventArgs) Handles cmdDiscipline.Click
        frmEmployeeDiscipline.Show()
        frmEmployeeDiscipline.Focus()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Application.Exit()
    End Sub

    Private Sub DailyWagerProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyWagerProfileToolStripMenuItem.Click
        frmEmployeeProfileDW.Show()
        frmEmployeeProfileDW.Focus()
    End Sub

    Private Sub mnuCountries_Click(sender As Object, e As EventArgs) Handles mnuCountries.Click
        frmCountries.Show()
        frmCountries.Focus()
    End Sub

    Private Sub mnuCities_Click(sender As Object, e As EventArgs) Handles mnuCities.Click
        frmCities.Show()
        frmCities.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdApp.Click

        Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
        Dim f2 As frmEmployeeProfile = CType(Application.OpenForms("frmEmployeeProfile"), frmEmployeeProfile)

        f3.Focus()
        f3.WindowState = FormWindowState.Normal

    End Sub

    Private Sub frmMdiMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Application.Exit()

    End Sub

    Private Sub frmMdiMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing


    End Sub

    Private Sub C1ReportDesigner1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub EmployeeProfileToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EmployeeProfileToolStripMenuItem.Click
        frmEmployeeProfile.Show()
        frmEmployeeProfile.Visible = True

        frmAppraisals_Discipline.Show()
        frmEmployeeProfile.Focus()
    End Sub

    Private Sub StatusToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem1.Click
        frmEmployeeStatus.Show()
        frmEmployeeStatus.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click


        Dim result As DialogResult
        result = MsgBox("Do you want to Exit", vbYesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Me.Close()

            Application.Exit()
        End If

        Me.Close()

        Application.Exit()

    End Sub

    Private Sub EmployeeProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmployeeProfileToolStripMenuItem1.Click
        frmEmployeeProfile.Show()
        frmEmployeeProfile.Visible = True

        'frmAppraisals_Discipline.Show()
        frmEmployeeProfile.Focus()
    End Sub

    Private Sub DailyWagerProfileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DailyWagerProfileToolStripMenuItem1.Click
        frmEmployeeProfileDW.Show()
        frmEmployeeProfileDW.Focus()
    End Sub

    Private Sub UpdateStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateStatusToolStripMenuItem.Click
        frmEmployeeStatus.Show()
        frmEmployeeStatus.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) 

        Dim result As DialogResult
        result = MsgBox("Do you want to Exit", vbYesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Me.Close()

            Application.Exit()
        End If

        Me.Close()

        Application.Exit()
    End Sub

    Private Sub AppraisalsDisciiplineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppraisalsDisciiplineToolStripMenuItem.Click
        ''Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
        ''Dim f2 As frmEmployeeProfile = CType(Application.OpenForms("frmEmployeeProfile"), frmEmployeeProfile)

        ''f3.Focus()
        ''f3.WindowState = FormWindowState.Normal
        frmAppraisals_Discipline.Show()
        frmAppraisals_Discipline.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Dim result As DialogResult
        result = MsgBox("Do you want to Exit", vbYesNo)
        If result = DialogResult.Yes Then
            Me.Close()

            Application.Exit()

        End If


    End Sub

    Private Sub CitiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CitiesToolStripMenuItem.Click
        frmCities.Show()
        frmCities.Focus()
    End Sub

    Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountriesToolStripMenuItem.Click
        frmCountries.Show()
        frmCountries.Focus()
    End Sub

    Private Sub QualificationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QualificationsToolStripMenuItem.Click
        frmQualifications.Show()
        frmQualifications.Focus()
    End Sub

    Private Sub InstitutionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstitutionsToolStripMenuItem.Click
        frmInstitutions.Show()
        frmInstitutions.Focus()
    End Sub
End Class