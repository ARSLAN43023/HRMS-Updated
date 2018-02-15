<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMdiMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.mnuMainMenu = New System.Windows.Forms.MenuStrip()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmployeeProfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyWagerProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCountries = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCities = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEducation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProfessionalExperience = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrainings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPromotions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTransfers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDependents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBankAccounts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBenefits = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLeaves = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAppraisals = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAwards = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrainingCourseSeminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDiscipline = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdDiscipline = New System.Windows.Forms.Button()
        Me.cmdTrainings = New System.Windows.Forms.Button()
        Me.cmdAwards = New System.Windows.Forms.Button()
        Me.cmdBankAccount = New System.Windows.Forms.Button()
        Me.cmdPromotions = New System.Windows.Forms.Button()
        Me.cmdStatus = New System.Windows.Forms.Button()
        Me.cmdEmployeeProfile = New System.Windows.Forms.Button()
        Me.mnuMainMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMainMenu
        '
        Me.mnuMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem, Me.FormsToolStripMenuItem})
        Me.mnuMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mnuMainMenu.Name = "mnuMainMenu"
        Me.mnuMainMenu.Size = New System.Drawing.Size(1028, 24)
        Me.mnuMainMenu.TabIndex = 1
        Me.mnuMainMenu.Text = "MenuStrip1"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmployeeProfile, Me.DailyWagerProfileToolStripMenuItem, Me.mnuCountries, Me.mnuCities})
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'mnuEmployeeProfile
        '
        Me.mnuEmployeeProfile.Name = "mnuEmployeeProfile"
        Me.mnuEmployeeProfile.Size = New System.Drawing.Size(174, 22)
        Me.mnuEmployeeProfile.Text = "Employee Profile"
        '
        'DailyWagerProfileToolStripMenuItem
        '
        Me.DailyWagerProfileToolStripMenuItem.Name = "DailyWagerProfileToolStripMenuItem"
        Me.DailyWagerProfileToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DailyWagerProfileToolStripMenuItem.Text = "Daily Wager Profile"
        '
        'mnuCountries
        '
        Me.mnuCountries.Name = "mnuCountries"
        Me.mnuCountries.Size = New System.Drawing.Size(174, 22)
        Me.mnuCountries.Text = "Countries"
        '
        'mnuCities
        '
        Me.mnuCities.Name = "mnuCities"
        Me.mnuCities.Size = New System.Drawing.Size(174, 22)
        Me.mnuCities.Text = "Cities"
        '
        'FormsToolStripMenuItem
        '
        Me.FormsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEducation, Me.mnuProfessionalExperience, Me.mnuTrainings, Me.mnuPromotions, Me.mnuTransfers, Me.mnuDependents, Me.mnuBankAccounts, Me.mnuBenefits, Me.mnuLeaves, Me.mnuAppraisals, Me.mnuAwards, Me.mnuTrainingCourseSeminar, Me.mnuDiscipline, Me.StatusToolStripMenuItem})
        Me.FormsToolStripMenuItem.Name = "FormsToolStripMenuItem"
        Me.FormsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.FormsToolStripMenuItem.Text = "Forms"
        '
        'mnuEducation
        '
        Me.mnuEducation.Name = "mnuEducation"
        Me.mnuEducation.Size = New System.Drawing.Size(207, 22)
        Me.mnuEducation.Text = "Qualifications"
        Me.mnuEducation.Visible = False
        '
        'mnuProfessionalExperience
        '
        Me.mnuProfessionalExperience.Name = "mnuProfessionalExperience"
        Me.mnuProfessionalExperience.Size = New System.Drawing.Size(207, 22)
        Me.mnuProfessionalExperience.Text = "Professional Experience"
        Me.mnuProfessionalExperience.Visible = False
        '
        'mnuTrainings
        '
        Me.mnuTrainings.Name = "mnuTrainings"
        Me.mnuTrainings.Size = New System.Drawing.Size(207, 22)
        Me.mnuTrainings.Text = "Trainings"
        Me.mnuTrainings.Visible = False
        '
        'mnuPromotions
        '
        Me.mnuPromotions.Name = "mnuPromotions"
        Me.mnuPromotions.Size = New System.Drawing.Size(207, 22)
        Me.mnuPromotions.Text = "Promotions"
        '
        'mnuTransfers
        '
        Me.mnuTransfers.Name = "mnuTransfers"
        Me.mnuTransfers.Size = New System.Drawing.Size(207, 22)
        Me.mnuTransfers.Text = "Transfers"
        Me.mnuTransfers.Visible = False
        '
        'mnuDependents
        '
        Me.mnuDependents.Name = "mnuDependents"
        Me.mnuDependents.Size = New System.Drawing.Size(207, 22)
        Me.mnuDependents.Text = "Dependents"
        Me.mnuDependents.Visible = False
        '
        'mnuBankAccounts
        '
        Me.mnuBankAccounts.Name = "mnuBankAccounts"
        Me.mnuBankAccounts.Size = New System.Drawing.Size(207, 22)
        Me.mnuBankAccounts.Text = "Bank Accounts"
        '
        'mnuBenefits
        '
        Me.mnuBenefits.Name = "mnuBenefits"
        Me.mnuBenefits.Size = New System.Drawing.Size(207, 22)
        Me.mnuBenefits.Text = "Benefits"
        Me.mnuBenefits.Visible = False
        '
        'mnuLeaves
        '
        Me.mnuLeaves.Name = "mnuLeaves"
        Me.mnuLeaves.Size = New System.Drawing.Size(207, 22)
        Me.mnuLeaves.Text = "Leaves"
        Me.mnuLeaves.Visible = False
        '
        'mnuAppraisals
        '
        Me.mnuAppraisals.Name = "mnuAppraisals"
        Me.mnuAppraisals.Size = New System.Drawing.Size(207, 22)
        Me.mnuAppraisals.Text = "Appraisals"
        Me.mnuAppraisals.Visible = False
        '
        'mnuAwards
        '
        Me.mnuAwards.Name = "mnuAwards"
        Me.mnuAwards.Size = New System.Drawing.Size(207, 22)
        Me.mnuAwards.Text = "Awards"
        '
        'mnuTrainingCourseSeminar
        '
        Me.mnuTrainingCourseSeminar.Name = "mnuTrainingCourseSeminar"
        Me.mnuTrainingCourseSeminar.Size = New System.Drawing.Size(207, 22)
        Me.mnuTrainingCourseSeminar.Text = "Training/Course/Seminar"
        '
        'mnuDiscipline
        '
        Me.mnuDiscipline.Name = "mnuDiscipline"
        Me.mnuDiscipline.Size = New System.Drawing.Size(207, 22)
        Me.mnuDiscipline.Text = "Discipline"
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.cmdExit)
        Me.Panel1.Controls.Add(Me.cmdDiscipline)
        Me.Panel1.Controls.Add(Me.cmdTrainings)
        Me.Panel1.Controls.Add(Me.cmdAwards)
        Me.Panel1.Controls.Add(Me.cmdBankAccount)
        Me.Panel1.Controls.Add(Me.cmdPromotions)
        Me.Panel1.Controls.Add(Me.cmdStatus)
        Me.Panel1.Controls.Add(Me.cmdEmployeeProfile)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 65)
        Me.Panel1.TabIndex = 39
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Red
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.White
        Me.cmdExit.Location = New System.Drawing.Point(1061, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(150, 60)
        Me.cmdExit.TabIndex = 38
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdDiscipline
        '
        Me.cmdDiscipline.BackColor = System.Drawing.Color.DimGray
        Me.cmdDiscipline.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDiscipline.ForeColor = System.Drawing.Color.White
        Me.cmdDiscipline.Location = New System.Drawing.Point(911, 3)
        Me.cmdDiscipline.Name = "cmdDiscipline"
        Me.cmdDiscipline.Size = New System.Drawing.Size(150, 60)
        Me.cmdDiscipline.TabIndex = 37
        Me.cmdDiscipline.Text = "Discipline"
        Me.cmdDiscipline.UseVisualStyleBackColor = False
        '
        'cmdTrainings
        '
        Me.cmdTrainings.BackColor = System.Drawing.Color.DimGray
        Me.cmdTrainings.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTrainings.ForeColor = System.Drawing.Color.White
        Me.cmdTrainings.Location = New System.Drawing.Point(761, 3)
        Me.cmdTrainings.Name = "cmdTrainings"
        Me.cmdTrainings.Size = New System.Drawing.Size(150, 60)
        Me.cmdTrainings.TabIndex = 36
        Me.cmdTrainings.Text = "Trainings"
        Me.cmdTrainings.UseVisualStyleBackColor = False
        '
        'cmdAwards
        '
        Me.cmdAwards.BackColor = System.Drawing.Color.DimGray
        Me.cmdAwards.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAwards.ForeColor = System.Drawing.Color.White
        Me.cmdAwards.Location = New System.Drawing.Point(611, 3)
        Me.cmdAwards.Name = "cmdAwards"
        Me.cmdAwards.Size = New System.Drawing.Size(150, 60)
        Me.cmdAwards.TabIndex = 35
        Me.cmdAwards.Text = "Awards"
        Me.cmdAwards.UseVisualStyleBackColor = False
        '
        'cmdBankAccount
        '
        Me.cmdBankAccount.BackColor = System.Drawing.Color.DimGray
        Me.cmdBankAccount.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBankAccount.ForeColor = System.Drawing.Color.White
        Me.cmdBankAccount.Location = New System.Drawing.Point(461, 3)
        Me.cmdBankAccount.Name = "cmdBankAccount"
        Me.cmdBankAccount.Size = New System.Drawing.Size(150, 60)
        Me.cmdBankAccount.TabIndex = 34
        Me.cmdBankAccount.Text = "Bank Account"
        Me.cmdBankAccount.UseVisualStyleBackColor = False
        '
        'cmdPromotions
        '
        Me.cmdPromotions.BackColor = System.Drawing.Color.DimGray
        Me.cmdPromotions.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPromotions.ForeColor = System.Drawing.Color.White
        Me.cmdPromotions.Location = New System.Drawing.Point(311, 3)
        Me.cmdPromotions.Name = "cmdPromotions"
        Me.cmdPromotions.Size = New System.Drawing.Size(150, 60)
        Me.cmdPromotions.TabIndex = 33
        Me.cmdPromotions.Text = "Promotions"
        Me.cmdPromotions.UseVisualStyleBackColor = False
        '
        'cmdStatus
        '
        Me.cmdStatus.BackColor = System.Drawing.Color.DimGray
        Me.cmdStatus.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStatus.ForeColor = System.Drawing.Color.White
        Me.cmdStatus.Location = New System.Drawing.Point(161, 3)
        Me.cmdStatus.Name = "cmdStatus"
        Me.cmdStatus.Size = New System.Drawing.Size(150, 60)
        Me.cmdStatus.TabIndex = 32
        Me.cmdStatus.Text = "Status"
        Me.cmdStatus.UseVisualStyleBackColor = False
        '
        'cmdEmployeeProfile
        '
        Me.cmdEmployeeProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdEmployeeProfile.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEmployeeProfile.ForeColor = System.Drawing.Color.White
        Me.cmdEmployeeProfile.Location = New System.Drawing.Point(12, 3)
        Me.cmdEmployeeProfile.Name = "cmdEmployeeProfile"
        Me.cmdEmployeeProfile.Size = New System.Drawing.Size(150, 60)
        Me.cmdEmployeeProfile.TabIndex = 31
        Me.cmdEmployeeProfile.Text = "Employee Profile"
        Me.cmdEmployeeProfile.UseVisualStyleBackColor = False
        '
        'frmMdiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 749)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.mnuMainMenu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMainMenu
        Me.Name = "frmMdiMain"
        Me.Text = "Human Resource Management System"
        Me.mnuMainMenu.ResumeLayout(False)
        Me.mnuMainMenu.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMainMenu As MenuStrip
    Friend WithEvents ConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuEmployeeProfile As ToolStripMenuItem
    Friend WithEvents FormsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuEducation As ToolStripMenuItem
    Friend WithEvents mnuProfessionalExperience As ToolStripMenuItem
    Friend WithEvents mnuTrainings As ToolStripMenuItem
    Friend WithEvents mnuPromotions As ToolStripMenuItem
    Friend WithEvents mnuTransfers As ToolStripMenuItem
    Friend WithEvents mnuDependents As ToolStripMenuItem
    Friend WithEvents mnuBankAccounts As ToolStripMenuItem
    Friend WithEvents mnuBenefits As ToolStripMenuItem
    Friend WithEvents mnuLeaves As ToolStripMenuItem
    Friend WithEvents mnuAppraisals As ToolStripMenuItem
    Friend WithEvents mnuAwards As ToolStripMenuItem
    Friend WithEvents mnuTrainingCourseSeminar As ToolStripMenuItem
    Friend WithEvents mnuDiscipline As ToolStripMenuItem
    Friend WithEvents StatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdDiscipline As Button
    Friend WithEvents cmdTrainings As Button
    Friend WithEvents cmdAwards As Button
    Friend WithEvents cmdBankAccount As Button
    Friend WithEvents cmdPromotions As Button
    Friend WithEvents cmdStatus As Button
    Friend WithEvents cmdEmployeeProfile As Button
    Friend WithEvents cmdExit As Button
    Friend WithEvents DailyWagerProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuCountries As ToolStripMenuItem
    Friend WithEvents mnuCities As ToolStripMenuItem
End Class
