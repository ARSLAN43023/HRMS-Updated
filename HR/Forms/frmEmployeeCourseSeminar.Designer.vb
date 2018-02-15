<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeCourseSeminar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeCourseSeminar))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbAwardInformation = New System.Windows.Forms.TabControl()
        Me.tbTrainingInfo = New System.Windows.Forms.TabPage()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.Cost = New System.Windows.Forms.Label()
        Me.cbCity = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grdSeminars = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.vcAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtmActionAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcActionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlbToolbar.SuspendLayout()
        Me.stbDetail.SuspendLayout()
        Me.tbAwardInformation.SuspendLayout()
        Me.tbTrainingInfo.SuspendLayout()
        CType(Me.grdSeminars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(666, 25)
        Me.tlbToolbar.TabIndex = 3
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
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus, Me.ToolStripStatusLabel1})
        Me.stbDetail.Location = New System.Drawing.Point(0, 333)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 7
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'tbAwardInformation
        '
        Me.tbAwardInformation.Controls.Add(Me.tbTrainingInfo)
        Me.tbAwardInformation.Controls.Add(Me.tbAudit)
        Me.tbAwardInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAwardInformation.Location = New System.Drawing.Point(4, 24)
        Me.tbAwardInformation.Name = "tbAwardInformation"
        Me.tbAwardInformation.SelectedIndex = 0
        Me.tbAwardInformation.Size = New System.Drawing.Size(658, 305)
        Me.tbAwardInformation.TabIndex = 8
        '
        'tbTrainingInfo
        '
        Me.tbTrainingInfo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbTrainingInfo.Controls.Add(Me.cbType)
        Me.tbTrainingInfo.Controls.Add(Me.txtCost)
        Me.tbTrainingInfo.Controls.Add(Me.Cost)
        Me.tbTrainingInfo.Controls.Add(Me.cbCity)
        Me.tbTrainingInfo.Controls.Add(Me.Label11)
        Me.tbTrainingInfo.Controls.Add(Me.cbCountry)
        Me.tbTrainingInfo.Controls.Add(Me.Label10)
        Me.tbTrainingInfo.Controls.Add(Me.Label2)
        Me.tbTrainingInfo.Controls.Add(Me.dtpStartDate)
        Me.tbTrainingInfo.Controls.Add(Me.txtTitle)
        Me.tbTrainingInfo.Controls.Add(Me.Label12)
        Me.tbTrainingInfo.Controls.Add(Me.grdSeminars)
        Me.tbTrainingInfo.Controls.Add(Me.txtDescription)
        Me.tbTrainingInfo.Controls.Add(Me.dtpEndDate)
        Me.tbTrainingInfo.Controls.Add(Me.Label6)
        Me.tbTrainingInfo.Controls.Add(Me.Label4)
        Me.tbTrainingInfo.Controls.Add(Me.Label3)
        Me.tbTrainingInfo.Controls.Add(Me.txtEmployeeName)
        Me.tbTrainingInfo.Controls.Add(Me.Label1)
        Me.tbTrainingInfo.Location = New System.Drawing.Point(4, 25)
        Me.tbTrainingInfo.Name = "tbTrainingInfo"
        Me.tbTrainingInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTrainingInfo.Size = New System.Drawing.Size(650, 276)
        Me.tbTrainingInfo.TabIndex = 1
        Me.tbTrainingInfo.Text = "Training/Course/Seminar"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Training", "Course", "Seminar"})
        Me.cbType.Location = New System.Drawing.Point(143, 38)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(175, 24)
        Me.cbType.TabIndex = 2
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(143, 128)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(175, 23)
        Me.txtCost.TabIndex = 8
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cost
        '
        Me.Cost.AutoSize = True
        Me.Cost.Location = New System.Drawing.Point(4, 133)
        Me.Cost.Name = "Cost"
        Me.Cost.Size = New System.Drawing.Size(38, 16)
        Me.Cost.TabIndex = 47
        Me.Cost.Text = "Cost"
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
        Me.Label11.Size = New System.Drawing.Size(43, 16)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "City*"
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
        Me.Label10.Size = New System.Drawing.Size(69, 16)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Country*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Type*"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd/MM/yy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(143, 68)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpStartDate.TabIndex = 4
        Me.dtpStartDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(468, 38)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(175, 23)
        Me.txtTitle.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(355, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Title*"
        '
        'grdSeminars
        '
        Me.grdSeminars.AllowUpdate = False
        Me.grdSeminars.CaptionHeight = 20
        Me.grdSeminars.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdSeminars.Images.Add(CType(resources.GetObject("grdSeminars.Images"), System.Drawing.Image))
        Me.grdSeminars.Location = New System.Drawing.Point(6, 185)
        Me.grdSeminars.Name = "grdSeminars"
        Me.grdSeminars.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSeminars.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSeminars.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSeminars.PrintInfo.PageSettings = CType(resources.GetObject("grdSeminars.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSeminars.RowHeight = 15
        Me.grdSeminars.Size = New System.Drawing.Size(637, 87)
        Me.grdSeminars.TabIndex = 6
        Me.grdSeminars.TabStop = False
        Me.grdSeminars.PropBag = resources.GetString("grdSeminars.PropBag")
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(143, 158)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtDescription.TabIndex = 9
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(468, 68)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpEndDate.TabIndex = 5
        Me.dtpEndDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "End Date*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Start Date*"
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
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee Name*"
        '
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(650, 276)
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
        Me.grdAudit.Size = New System.Drawing.Size(637, 174)
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
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Visible = False
        '
        'frmEmployeeCourseSeminar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 355)
        Me.Controls.Add(Me.tbAwardInformation)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeCourseSeminar"
        Me.Text = "Employee Training / Course / Seminar"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        Me.tbAwardInformation.ResumeLayout(False)
        Me.tbTrainingInfo.ResumeLayout(False)
        Me.tbTrainingInfo.PerformLayout()
        CType(Me.grdSeminars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents tbAwardInformation As TabControl
    Friend WithEvents tbTrainingInfo As TabPage
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents grdSeminars As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdAudit As DataGridView
    Friend WithEvents vcAction As DataGridViewTextBoxColumn
    Friend WithEvents vcUserId As DataGridViewTextBoxColumn
    Friend WithEvents dtmActionAction As DataGridViewTextBoxColumn
    Friend WithEvents vcActionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCity As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbCountry As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbType As ComboBox
    Friend WithEvents txtCost As TextBox
    Friend WithEvents Cost As Label
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
End Class
