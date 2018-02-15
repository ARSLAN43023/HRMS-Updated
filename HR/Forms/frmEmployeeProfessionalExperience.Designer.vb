<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeProfessionalExperience
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeProfessionalExperience))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbPersonal = New System.Windows.Forms.TabPage()
        Me.txtReasonForLeaving = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtJobDescription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBenefits = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.cbCity = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDesignation = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmployer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.vcAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtmActionAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcActionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdJobHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tlbToolbar.SuspendLayout()
        Me.stbDetail.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.tbPersonal.SuspendLayout()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdJobHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(666, 25)
        Me.tlbToolbar.TabIndex = 1
        Me.tlbToolbar.Text = "tlbTop"
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 438)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 3
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbPersonal)
        Me.tbJobInformation.Controls.Add(Me.tbAudit)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(6, 28)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(658, 407)
        Me.tbJobInformation.TabIndex = 4
        '
        'tbPersonal
        '
        Me.tbPersonal.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbPersonal.Controls.Add(Me.grdJobHistory)
        Me.tbPersonal.Controls.Add(Me.txtReasonForLeaving)
        Me.tbPersonal.Controls.Add(Me.Label8)
        Me.tbPersonal.Controls.Add(Me.txtJobDescription)
        Me.tbPersonal.Controls.Add(Me.Label7)
        Me.tbPersonal.Controls.Add(Me.txtBenefits)
        Me.tbPersonal.Controls.Add(Me.Label2)
        Me.tbPersonal.Controls.Add(Me.txtSalary)
        Me.tbPersonal.Controls.Add(Me.Label5)
        Me.tbPersonal.Controls.Add(Me.dtpFromDate)
        Me.tbPersonal.Controls.Add(Me.cbCity)
        Me.tbPersonal.Controls.Add(Me.Label11)
        Me.tbPersonal.Controls.Add(Me.cbCountry)
        Me.tbPersonal.Controls.Add(Me.Label10)
        Me.tbPersonal.Controls.Add(Me.Label9)
        Me.tbPersonal.Controls.Add(Me.dtpToDate)
        Me.tbPersonal.Controls.Add(Me.Label6)
        Me.tbPersonal.Controls.Add(Me.txtDesignation)
        Me.tbPersonal.Controls.Add(Me.Label4)
        Me.tbPersonal.Controls.Add(Me.txtEmployer)
        Me.tbPersonal.Controls.Add(Me.Label3)
        Me.tbPersonal.Controls.Add(Me.txtEmployeeName)
        Me.tbPersonal.Controls.Add(Me.Label1)
        Me.tbPersonal.Location = New System.Drawing.Point(4, 25)
        Me.tbPersonal.Name = "tbPersonal"
        Me.tbPersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPersonal.Size = New System.Drawing.Size(650, 378)
        Me.tbPersonal.TabIndex = 1
        Me.tbPersonal.Text = "Job Information"
        '
        'txtReasonForLeaving
        '
        Me.txtReasonForLeaving.Location = New System.Drawing.Point(142, 188)
        Me.txtReasonForLeaving.Name = "txtReasonForLeaving"
        Me.txtReasonForLeaving.Size = New System.Drawing.Size(501, 23)
        Me.txtReasonForLeaving.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 16)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Reason for Leaving"
        '
        'txtJobDescription
        '
        Me.txtJobDescription.Location = New System.Drawing.Point(143, 158)
        Me.txtJobDescription.Name = "txtJobDescription"
        Me.txtJobDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtJobDescription.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Job Description"
        '
        'txtBenefits
        '
        Me.txtBenefits.Location = New System.Drawing.Point(468, 128)
        Me.txtBenefits.Name = "txtBenefits"
        Me.txtBenefits.Size = New System.Drawing.Size(175, 23)
        Me.txtBenefits.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Other Benefits"
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(143, 128)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Size = New System.Drawing.Size(175, 23)
        Me.txtSalary.TabIndex = 8
        Me.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Salary"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(143, 68)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpFromDate.TabIndex = 4
        Me.dtpFromDate.Value = New Date(2015, 9, 10, 10, 51, 51, 0)
        '
        'cbCity
        '
        Me.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCity.FormattingEnabled = True
        Me.cbCity.Location = New System.Drawing.Point(468, 98)
        Me.cbCity.Name = "cbCity"
        Me.cbCity.Size = New System.Drawing.Size(175, 24)
        Me.cbCity.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "City"
        '
        'cbCountry
        '
        Me.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCountry.FormattingEnabled = True
        Me.cbCountry.Location = New System.Drawing.Point(143, 98)
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Size = New System.Drawing.Size(175, 24)
        Me.cbCountry.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Country"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "To Date"
        '
        'dtpToDate
        '
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(468, 68)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpToDate.TabIndex = 5
        Me.dtpToDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From Date"
        '
        'txtDesignation
        '
        Me.txtDesignation.Location = New System.Drawing.Point(468, 38)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(175, 23)
        Me.txtDesignation.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Designation"
        '
        'txtEmployer
        '
        Me.txtEmployer.Location = New System.Drawing.Point(143, 38)
        Me.txtEmployer.Name = "txtEmployer"
        Me.txtEmployer.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployer.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Employer"
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
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(650, 378)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
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
        'vcAction
        '
        Me.vcAction.DataPropertyName = "vcAction"
        Me.vcAction.HeaderText = "Action"
        Me.vcAction.Name = "vcAction"
        Me.vcAction.ReadOnly = True
        '
        'vcUserId
        '
        Me.vcUserId.DataPropertyName = "vcUserId"
        Me.vcUserId.HeaderText = "User"
        Me.vcUserId.Name = "vcUserId"
        Me.vcUserId.ReadOnly = True
        '
        'dtmActionAction
        '
        Me.dtmActionAction.DataPropertyName = "dtmActionDate"
        Me.dtmActionAction.HeaderText = "Date & Time"
        Me.dtmActionAction.Name = "dtmActionAction"
        Me.dtmActionAction.ReadOnly = True
        Me.dtmActionAction.Width = 150
        '
        'vcActionRemarks
        '
        Me.vcActionRemarks.DataPropertyName = "vcActionRemarks"
        Me.vcActionRemarks.HeaderText = "Remarks"
        Me.vcActionRemarks.Name = "vcActionRemarks"
        Me.vcActionRemarks.ReadOnly = True
        Me.vcActionRemarks.Width = 200
        '
        'grdJobHistory
        '
        Me.grdJobHistory.AllowUpdate = False
        Me.grdJobHistory.CaptionHeight = 20
        Me.grdJobHistory.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdJobHistory.Images.Add(CType(resources.GetObject("grdJobHistory.Images"), System.Drawing.Image))
        Me.grdJobHistory.Location = New System.Drawing.Point(6, 221)
        Me.grdJobHistory.Name = "grdJobHistory"
        Me.grdJobHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdJobHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdJobHistory.PreviewInfo.ZoomFactor = 75.0R
        Me.grdJobHistory.PrintInfo.PageSettings = CType(resources.GetObject("grdJobHistory.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdJobHistory.RowHeight = 15
        Me.grdJobHistory.Size = New System.Drawing.Size(637, 151)
        Me.grdJobHistory.TabIndex = 12
        Me.grdJobHistory.TabStop = False
        Me.grdJobHistory.PropBag = resources.GetString("grdJobHistory.PropBag")
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
        'frmEmployeeProfessionalExperience
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 460)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeProfessionalExperience"
        Me.Text = "Employee Professional Experience"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbPersonal.ResumeLayout(False)
        Me.tbPersonal.PerformLayout()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdJobHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents tbPersonal As TabPage
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents cbCity As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbCountry As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents txtDesignation As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEmployer As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdAudit As DataGridView
    Friend WithEvents vcAction As DataGridViewTextBoxColumn
    Friend WithEvents vcUserId As DataGridViewTextBoxColumn
    Friend WithEvents dtmActionAction As DataGridViewTextBoxColumn
    Friend WithEvents vcActionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBenefits As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtJobDescription As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtReasonForLeaving As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents grdJobHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
