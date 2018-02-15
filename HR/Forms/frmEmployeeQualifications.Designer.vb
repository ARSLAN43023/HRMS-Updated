<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeQualifications
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeQualifications))
        Me.vcActionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.dtmActionAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdQualifications = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtDistinctions = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtExtraCurricular = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.cbCity = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOtherDegree = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtStartYear = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radProfessional = New System.Windows.Forms.RadioButton()
        Me.radAcademic = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOtherInstitution = New System.Windows.Forms.TextBox()
        Me.cbInstitution = New System.Windows.Forms.ComboBox()
        Me.txtGradeGPA = New System.Windows.Forms.TextBox()
        Me.txtMajors = New System.Windows.Forms.TextBox()
        Me.cbDegreeDiploma = New System.Windows.Forms.ComboBox()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdQualifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbToolbar.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.stbDetail.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'vcActionRemarks
        '
        Me.vcActionRemarks.DataPropertyName = "vcActionRemarks"
        Me.vcActionRemarks.HeaderText = "Remarks"
        Me.vcActionRemarks.Name = "vcActionRemarks"
        Me.vcActionRemarks.ReadOnly = True
        Me.vcActionRemarks.Width = 200
        '
        'vcUserId
        '
        Me.vcUserId.DataPropertyName = "vcUserId"
        Me.vcUserId.HeaderText = "User"
        Me.vcUserId.Name = "vcUserId"
        Me.vcUserId.ReadOnly = True
        '
        'vcAction
        '
        Me.vcAction.DataPropertyName = "vcAction"
        Me.vcAction.HeaderText = "Action"
        Me.vcAction.Name = "vcAction"
        Me.vcAction.ReadOnly = True
        '
        'grdAudit
        '
        Me.grdAudit.AllowUserToAddRows = False
        Me.grdAudit.AllowUserToDeleteRows = False
        Me.grdAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAudit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vcAction, Me.vcUserId, Me.dtmActionAction, Me.vcActionRemarks})
        Me.grdAudit.Location = New System.Drawing.Point(7, 9)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.ReadOnly = True
        Me.grdAudit.Size = New System.Drawing.Size(637, 363)
        Me.grdAudit.TabIndex = 0
        '
        'dtmActionAction
        '
        Me.dtmActionAction.DataPropertyName = "dtmActionDate"
        Me.dtmActionAction.HeaderText = "Date & Time"
        Me.dtmActionAction.Name = "dtmActionAction"
        Me.dtmActionAction.ReadOnly = True
        Me.dtmActionAction.Width = 150
        '
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(650, 384)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
        '
        'grdQualifications
        '
        Me.grdQualifications.AllowUpdate = False
        Me.grdQualifications.CaptionHeight = 20
        Me.grdQualifications.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdQualifications.Images.Add(CType(resources.GetObject("grdQualifications.Images"), System.Drawing.Image))
        Me.grdQualifications.Location = New System.Drawing.Point(6, 279)
        Me.grdQualifications.Name = "grdQualifications"
        Me.grdQualifications.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdQualifications.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdQualifications.PreviewInfo.ZoomFactor = 75.0R
        Me.grdQualifications.PrintInfo.PageSettings = CType(resources.GetObject("grdQualifications.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdQualifications.RowHeight = 15
        Me.grdQualifications.Size = New System.Drawing.Size(637, 100)
        Me.grdQualifications.TabIndex = 16
        Me.grdQualifications.TabStop = False
        Me.grdQualifications.PropBag = resources.GetString("grdQualifications.PropBag")
        '
        'txtDistinctions
        '
        Me.txtDistinctions.Location = New System.Drawing.Point(143, 248)
        Me.txtDistinctions.Name = "txtDistinctions"
        Me.txtDistinctions.Size = New System.Drawing.Size(501, 23)
        Me.txtDistinctions.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Degree Type"
        '
        'txtExtraCurricular
        '
        Me.txtExtraCurricular.Location = New System.Drawing.Point(143, 218)
        Me.txtExtraCurricular.Name = "txtExtraCurricular"
        Me.txtExtraCurricular.Size = New System.Drawing.Size(500, 23)
        Me.txtExtraCurricular.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Country"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "End Year"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Start Year"
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(666, 25)
        Me.tlbToolbar.TabIndex = 5
        Me.tlbToolbar.Text = "tlbTop"
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = Global.HR.My.Resources.Resources._NEW
        Me.btnNew.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 22)
        Me.btnNew.Text = "New"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.HR.My.Resources.Resources.SAVE
        Me.btnSave.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save"
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Image = Global.HR.My.Resources.Resources.SEARCH
        Me.btnSearch.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSearch.Text = "Search"
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.HR.My.Resources.Resources.DELETE
        Me.btnDelete.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete"
        '
        'cbCity
        '
        Me.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCity.FormattingEnabled = True
        Me.cbCity.Location = New System.Drawing.Point(468, 157)
        Me.cbCity.Name = "cbCity"
        Me.cbCity.Size = New System.Drawing.Size(175, 24)
        Me.cbCity.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Other"
        '
        'cbCountry
        '
        Me.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCountry.FormattingEnabled = True
        Me.cbCountry.Location = New System.Drawing.Point(143, 158)
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Size = New System.Drawing.Size(175, 24)
        Me.cbCountry.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Institution"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Grade/GPA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Majors"
        '
        'txtOtherDegree
        '
        Me.txtOtherDegree.Location = New System.Drawing.Point(468, 38)
        Me.txtOtherDegree.Name = "txtOtherDegree"
        Me.txtOtherDegree.Size = New System.Drawing.Size(175, 23)
        Me.txtOtherDegree.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Other "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Degree/Diploma"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Enabled = False
        Me.txtEmployeeName.Location = New System.Drawing.Point(143, 8)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee Name"
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.txtEndYear)
        Me.tbQualifications.Controls.Add(Me.txtStartYear)
        Me.tbQualifications.Controls.Add(Me.GroupBox1)
        Me.tbQualifications.Controls.Add(Me.Label14)
        Me.tbQualifications.Controls.Add(Me.Label13)
        Me.tbQualifications.Controls.Add(Me.Label12)
        Me.tbQualifications.Controls.Add(Me.txtOtherInstitution)
        Me.tbQualifications.Controls.Add(Me.cbInstitution)
        Me.tbQualifications.Controls.Add(Me.txtGradeGPA)
        Me.tbQualifications.Controls.Add(Me.txtMajors)
        Me.tbQualifications.Controls.Add(Me.cbDegreeDiploma)
        Me.tbQualifications.Controls.Add(Me.grdQualifications)
        Me.tbQualifications.Controls.Add(Me.txtDistinctions)
        Me.tbQualifications.Controls.Add(Me.Label8)
        Me.tbQualifications.Controls.Add(Me.txtExtraCurricular)
        Me.tbQualifications.Controls.Add(Me.Label7)
        Me.tbQualifications.Controls.Add(Me.Label2)
        Me.tbQualifications.Controls.Add(Me.Label5)
        Me.tbQualifications.Controls.Add(Me.cbCity)
        Me.tbQualifications.Controls.Add(Me.Label11)
        Me.tbQualifications.Controls.Add(Me.cbCountry)
        Me.tbQualifications.Controls.Add(Me.Label10)
        Me.tbQualifications.Controls.Add(Me.Label9)
        Me.tbQualifications.Controls.Add(Me.Label6)
        Me.tbQualifications.Controls.Add(Me.txtOtherDegree)
        Me.tbQualifications.Controls.Add(Me.Label4)
        Me.tbQualifications.Controls.Add(Me.Label3)
        Me.tbQualifications.Controls.Add(Me.txtEmployeeName)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(650, 384)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Qualification Detail"
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(468, 128)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(175, 23)
        Me.txtEndYear.TabIndex = 9
        '
        'txtStartYear
        '
        Me.txtStartYear.Location = New System.Drawing.Point(143, 128)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(175, 23)
        Me.txtStartYear.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radProfessional)
        Me.GroupBox1.Controls.Add(Me.radAcademic)
        Me.GroupBox1.Location = New System.Drawing.Point(143, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(198, 34)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        '
        'radProfessional
        '
        Me.radProfessional.AutoSize = True
        Me.radProfessional.Location = New System.Drawing.Point(95, 11)
        Me.radProfessional.Name = "radProfessional"
        Me.radProfessional.Size = New System.Drawing.Size(104, 20)
        Me.radProfessional.TabIndex = 13
        Me.radProfessional.TabStop = True
        Me.radProfessional.Text = "Professional"
        Me.radProfessional.UseVisualStyleBackColor = True
        '
        'radAcademic
        '
        Me.radAcademic.AutoSize = True
        Me.radAcademic.Location = New System.Drawing.Point(4, 11)
        Me.radAcademic.Name = "radAcademic"
        Me.radAcademic.Size = New System.Drawing.Size(89, 20)
        Me.radAcademic.TabIndex = 12
        Me.radAcademic.TabStop = True
        Me.radAcademic.Text = "Academic"
        Me.radAcademic.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 252)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 16)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Distinctions"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 16)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Extra Curricular"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(355, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 16)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "City"
        '
        'txtOtherInstitution
        '
        Me.txtOtherInstitution.Location = New System.Drawing.Point(468, 98)
        Me.txtOtherInstitution.Name = "txtOtherInstitution"
        Me.txtOtherInstitution.Size = New System.Drawing.Size(175, 23)
        Me.txtOtherInstitution.TabIndex = 7
        '
        'cbInstitution
        '
        Me.cbInstitution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInstitution.FormattingEnabled = True
        Me.cbInstitution.Location = New System.Drawing.Point(143, 98)
        Me.cbInstitution.Name = "cbInstitution"
        Me.cbInstitution.Size = New System.Drawing.Size(175, 24)
        Me.cbInstitution.TabIndex = 6
        '
        'txtGradeGPA
        '
        Me.txtGradeGPA.Location = New System.Drawing.Point(468, 68)
        Me.txtGradeGPA.Name = "txtGradeGPA"
        Me.txtGradeGPA.Size = New System.Drawing.Size(175, 23)
        Me.txtGradeGPA.TabIndex = 5
        '
        'txtMajors
        '
        Me.txtMajors.Location = New System.Drawing.Point(143, 68)
        Me.txtMajors.Name = "txtMajors"
        Me.txtMajors.Size = New System.Drawing.Size(175, 23)
        Me.txtMajors.TabIndex = 4
        '
        'cbDegreeDiploma
        '
        Me.cbDegreeDiploma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDegreeDiploma.FormattingEnabled = True
        Me.cbDegreeDiploma.Location = New System.Drawing.Point(143, 38)
        Me.cbDegreeDiploma.Name = "cbDegreeDiploma"
        Me.cbDegreeDiploma.Size = New System.Drawing.Size(175, 24)
        Me.cbDegreeDiploma.TabIndex = 2
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 444)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 6
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Controls.Add(Me.tbAudit)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(6, 28)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(658, 413)
        Me.tbJobInformation.TabIndex = 7
        '
        'frmEmployeeQualifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 466)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Name = "frmEmployeeQualifications"
        Me.Text = "Employee Qualifications"
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdQualifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vcActionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents vcUserId As DataGridViewTextBoxColumn
    Friend WithEvents vcAction As DataGridViewTextBoxColumn
    Friend WithEvents grdAudit As DataGridView
    Friend WithEvents dtmActionAction As DataGridViewTextBoxColumn
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdQualifications As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtDistinctions As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtExtraCurricular As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents cbCity As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbCountry As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtOtherDegree As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbQualifications As TabPage
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents cbDegreeDiploma As ComboBox
    Friend WithEvents txtGradeGPA As TextBox
    Friend WithEvents txtMajors As TextBox
    Friend WithEvents txtOtherInstitution As TextBox
    Friend WithEvents cbInstitution As ComboBox
    Public WithEvents Label5 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents radProfessional As RadioButton
    Friend WithEvents radAcademic As RadioButton
    Friend WithEvents txtEndYear As TextBox
    Friend WithEvents txtStartYear As TextBox
End Class
