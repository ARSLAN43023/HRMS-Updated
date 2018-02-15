Public Class frmMdiMain
    Private Sub frmMdiMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.IsMdiContainer = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mnuProfessionalExperience_Click(sender As Object, e As EventArgs) Handles mnuProfessionalExperience.Click
        frmEmployeeProfessionalExperience.Show()
        frmEmployeeProfessionalExperience.Focus()
    End Sub
    Private Sub EmployeeProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEmployeeProfile.Click
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
        frmEmployeeProfile.Focus()
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
End Class