<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeDependents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeDependents))
        Me.vcActionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.dtmActionAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.tbDependent = New System.Windows.Forms.TabControl()
        Me.tbPersonal = New System.Windows.Forms.TabPage()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.chkInsurance = New System.Windows.Forms.CheckBox()
        Me.grdDependents = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cbRelation = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbMaritalStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpStatusSince = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCNIC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDependentName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAudit.SuspendLayout()
        Me.tbDependent.SuspendLayout()
        Me.tbPersonal.SuspendLayout()
        CType(Me.grdDependents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbToolbar.SuspendLayout()
        Me.stbDetail.SuspendLayout()
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
        Me.tbAudit.Size = New System.Drawing.Size(650, 265)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Gender"
        '
        'dtpDOB
        '
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOB.Location = New System.Drawing.Point(143, 69)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(175, 23)
        Me.dtpDOB.TabIndex = 4
        Me.dtpDOB.Value = New Date(2015, 9, 10, 10, 51, 51, 0)
        '
        'tbDependent
        '
        Me.tbDependent.Controls.Add(Me.tbPersonal)
        Me.tbDependent.Controls.Add(Me.tbAudit)
        Me.tbDependent.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDependent.Location = New System.Drawing.Point(6, 28)
        Me.tbDependent.Name = "tbDependent"
        Me.tbDependent.SelectedIndex = 0
        Me.tbDependent.Size = New System.Drawing.Size(658, 294)
        Me.tbDependent.TabIndex = 7
        '
        'tbPersonal
        '
        Me.tbPersonal.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbPersonal.Controls.Add(Me.cbGender)
        Me.tbPersonal.Controls.Add(Me.chkInsurance)
        Me.tbPersonal.Controls.Add(Me.grdDependents)
        Me.tbPersonal.Controls.Add(Me.Label2)
        Me.tbPersonal.Controls.Add(Me.dtpDOB)
        Me.tbPersonal.Controls.Add(Me.cbRelation)
        Me.tbPersonal.Controls.Add(Me.Label11)
        Me.tbPersonal.Controls.Add(Me.cbMaritalStatus)
        Me.tbPersonal.Controls.Add(Me.Label10)
        Me.tbPersonal.Controls.Add(Me.Label9)
        Me.tbPersonal.Controls.Add(Me.dtpStatusSince)
        Me.tbPersonal.Controls.Add(Me.Label6)
        Me.tbPersonal.Controls.Add(Me.txtCNIC)
        Me.tbPersonal.Controls.Add(Me.Label4)
        Me.tbPersonal.Controls.Add(Me.txtDependentName)
        Me.tbPersonal.Controls.Add(Me.Label3)
        Me.tbPersonal.Controls.Add(Me.txtEmployeeName)
        Me.tbPersonal.Controls.Add(Me.Label1)
        Me.tbPersonal.Location = New System.Drawing.Point(4, 25)
        Me.tbPersonal.Name = "tbPersonal"
        Me.tbPersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPersonal.Size = New System.Drawing.Size(650, 265)
        Me.tbPersonal.TabIndex = 1
        Me.tbPersonal.Text = "Dependent Information"
        '
        'cbGender
        '
        Me.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cbGender.Location = New System.Drawing.Point(468, 129)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(175, 24)
        Me.cbGender.TabIndex = 9
        '
        'chkInsurance
        '
        Me.chkInsurance.AutoSize = True
        Me.chkInsurance.Location = New System.Drawing.Point(6, 134)
        Me.chkInsurance.Name = "chkInsurance"
        Me.chkInsurance.Size = New System.Drawing.Size(172, 20)
        Me.chkInsurance.TabIndex = 8
        Me.chkInsurance.Text = "Insurance Entitlement"
        Me.chkInsurance.UseVisualStyleBackColor = True
        '
        'grdDependents
        '
        Me.grdDependents.AllowUpdate = False
        Me.grdDependents.CaptionHeight = 20
        Me.grdDependents.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdDependents.Images.Add(CType(resources.GetObject("grdDependents.Images"), System.Drawing.Image))
        Me.grdDependents.Location = New System.Drawing.Point(6, 161)
        Me.grdDependents.Name = "grdDependents"
        Me.grdDependents.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDependents.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDependents.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDependents.PrintInfo.PageSettings = CType(resources.GetObject("grdDependents.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDependents.RowHeight = 15
        Me.grdDependents.Size = New System.Drawing.Size(637, 100)
        Me.grdDependents.TabIndex = 12
        Me.grdDependents.TabStop = False
        Me.grdDependents.PropBag = resources.GetString("grdDependents.PropBag")
        '
        'cbRelation
        '
        Me.cbRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRelation.FormattingEnabled = True
        Me.cbRelation.Items.AddRange(New Object() {"Daughter", "Son", "Wife"})
        Me.cbRelation.Location = New System.Drawing.Point(468, 39)
        Me.cbRelation.Name = "cbRelation"
        Me.cbRelation.Size = New System.Drawing.Size(175, 24)
        Me.cbRelation.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Status Since"
        '
        'cbMaritalStatus
        '
        Me.cbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMaritalStatus.FormattingEnabled = True
        Me.cbMaritalStatus.Items.AddRange(New Object() {"Married", "Single", "Divorced", "Widowed"})
        Me.cbMaritalStatus.Location = New System.Drawing.Point(143, 99)
        Me.cbMaritalStatus.Name = "cbMaritalStatus"
        Me.cbMaritalStatus.Size = New System.Drawing.Size(175, 24)
        Me.cbMaritalStatus.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Marital Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "CNIC"
        '
        'dtpStatusSince
        '
        Me.dtpStatusSince.Checked = False
        Me.dtpStatusSince.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStatusSince.Location = New System.Drawing.Point(468, 99)
        Me.dtpStatusSince.Name = "dtpStatusSince"
        Me.dtpStatusSince.ShowCheckBox = True
        Me.dtpStatusSince.Size = New System.Drawing.Size(175, 23)
        Me.dtpStatusSince.TabIndex = 7
        Me.dtpStatusSince.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Date of Birth"
        '
        'txtCNIC
        '
        Me.txtCNIC.Location = New System.Drawing.Point(468, 69)
        Me.txtCNIC.Name = "txtCNIC"
        Me.txtCNIC.Size = New System.Drawing.Size(175, 23)
        Me.txtCNIC.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Relation"
        '
        'txtDependentName
        '
        Me.txtDependentName.Location = New System.Drawing.Point(143, 39)
        Me.txtDependentName.Name = "txtDependentName"
        Me.txtDependentName.Size = New System.Drawing.Size(175, 23)
        Me.txtDependentName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Dependent Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Enabled = False
        Me.txtEmployeeName.Location = New System.Drawing.Point(143, 9)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee Name"
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(672, 25)
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
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus, Me.ToolStripDropDownButton1})
        Me.stbDetail.Location = New System.Drawing.Point(0, 315)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(672, 22)
        Me.stbDetail.TabIndex = 6
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 20)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'frmEmployeeDependents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 337)
        Me.Controls.Add(Me.tbDependent)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.stbDetail)
        Me.Name = "frmEmployeeDependents"
        Me.Text = "Employee Dependents"
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAudit.ResumeLayout(False)
        Me.tbDependent.ResumeLayout(False)
        Me.tbPersonal.ResumeLayout(False)
        Me.tbPersonal.PerformLayout()
        CType(Me.grdDependents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vcActionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents vcUserId As DataGridViewTextBoxColumn
    Friend WithEvents vcAction As DataGridViewTextBoxColumn
    Friend WithEvents grdAudit As DataGridView
    Friend WithEvents dtmActionAction As DataGridViewTextBoxColumn
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdDependents As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDOB As DateTimePicker
    Friend WithEvents tbDependent As TabControl
    Friend WithEvents tbPersonal As TabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents cbMaritalStatus As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpStatusSince As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCNIC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDependentName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents cbRelation As ComboBox
    Friend WithEvents chkInsurance As CheckBox
    Friend WithEvents cbGender As ComboBox
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
End Class
