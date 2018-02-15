<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeePromotions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeePromotions))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.dtpEffectiveDate = New System.Windows.Forms.DateTimePicker()
        Me.cbToGrade = New System.Windows.Forms.ComboBox()
        Me.cbToDesignation = New System.Windows.Forms.ComboBox()
        Me.cbFromDesignation = New System.Windows.Forms.ComboBox()
        Me.cbToType = New System.Windows.Forms.ComboBox()
        Me.txtToIncrement = New System.Windows.Forms.TextBox()
        Me.txtFromIncrement = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbFromGrade = New System.Windows.Forms.ComboBox()
        Me.cbFromType = New System.Windows.Forms.ComboBox()
        Me.grdPromotions = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtNewJobDescription = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlbToolbar.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        CType(Me.grdPromotions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stbDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(666, 25)
        Me.tlbToolbar.TabIndex = 6
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
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Controls.Add(Me.tbAudit)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(4, 27)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(658, 380)
        Me.tbJobInformation.TabIndex = 8
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.dtpEffectiveDate)
        Me.tbQualifications.Controls.Add(Me.cbToGrade)
        Me.tbQualifications.Controls.Add(Me.cbToDesignation)
        Me.tbQualifications.Controls.Add(Me.cbFromDesignation)
        Me.tbQualifications.Controls.Add(Me.cbToType)
        Me.tbQualifications.Controls.Add(Me.txtToIncrement)
        Me.tbQualifications.Controls.Add(Me.txtFromIncrement)
        Me.tbQualifications.Controls.Add(Me.Label14)
        Me.tbQualifications.Controls.Add(Me.Label13)
        Me.tbQualifications.Controls.Add(Me.cbFromGrade)
        Me.tbQualifications.Controls.Add(Me.cbFromType)
        Me.tbQualifications.Controls.Add(Me.grdPromotions)
        Me.tbQualifications.Controls.Add(Me.txtNewJobDescription)
        Me.tbQualifications.Controls.Add(Me.txtRemarks)
        Me.tbQualifications.Controls.Add(Me.Label7)
        Me.tbQualifications.Controls.Add(Me.Label2)
        Me.tbQualifications.Controls.Add(Me.Label5)
        Me.tbQualifications.Controls.Add(Me.Label11)
        Me.tbQualifications.Controls.Add(Me.Label10)
        Me.tbQualifications.Controls.Add(Me.Label9)
        Me.tbQualifications.Controls.Add(Me.Label6)
        Me.tbQualifications.Controls.Add(Me.Label4)
        Me.tbQualifications.Controls.Add(Me.Label3)
        Me.tbQualifications.Controls.Add(Me.txtEmployeeName)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(650, 351)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Promotion Detail"
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.CustomFormat = "dd/MM/yy"
        Me.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(143, 158)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.ShowCheckBox = True
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpEffectiveDate.TabIndex = 10
        Me.dtpEffectiveDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbToGrade
        '
        Me.cbToGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToGrade.FormattingEnabled = True
        Me.cbToGrade.Location = New System.Drawing.Point(468, 98)
        Me.cbToGrade.Name = "cbToGrade"
        Me.cbToGrade.Size = New System.Drawing.Size(175, 24)
        Me.cbToGrade.TabIndex = 7
        '
        'cbToDesignation
        '
        Me.cbToDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToDesignation.FormattingEnabled = True
        Me.cbToDesignation.Location = New System.Drawing.Point(468, 68)
        Me.cbToDesignation.Name = "cbToDesignation"
        Me.cbToDesignation.Size = New System.Drawing.Size(175, 24)
        Me.cbToDesignation.TabIndex = 5
        '
        'cbFromDesignation
        '
        Me.cbFromDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromDesignation.FormattingEnabled = True
        Me.cbFromDesignation.Location = New System.Drawing.Point(143, 68)
        Me.cbFromDesignation.Name = "cbFromDesignation"
        Me.cbFromDesignation.Size = New System.Drawing.Size(175, 24)
        Me.cbFromDesignation.TabIndex = 4
        '
        'cbToType
        '
        Me.cbToType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToType.FormattingEnabled = True
        Me.cbToType.Location = New System.Drawing.Point(468, 38)
        Me.cbToType.Name = "cbToType"
        Me.cbToType.Size = New System.Drawing.Size(175, 24)
        Me.cbToType.TabIndex = 3
        '
        'txtToIncrement
        '
        Me.txtToIncrement.Location = New System.Drawing.Point(468, 128)
        Me.txtToIncrement.Name = "txtToIncrement"
        Me.txtToIncrement.Size = New System.Drawing.Size(175, 23)
        Me.txtToIncrement.TabIndex = 9
        Me.txtToIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFromIncrement
        '
        Me.txtFromIncrement.Location = New System.Drawing.Point(143, 128)
        Me.txtFromIncrement.Name = "txtFromIncrement"
        Me.txtFromIncrement.Size = New System.Drawing.Size(175, 23)
        Me.txtFromIncrement.TabIndex = 8
        Me.txtFromIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(4, 223)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 16)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "New Job Desc."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 16)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Remarks"
        '
        'cbFromGrade
        '
        Me.cbFromGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromGrade.FormattingEnabled = True
        Me.cbFromGrade.Location = New System.Drawing.Point(143, 98)
        Me.cbFromGrade.Name = "cbFromGrade"
        Me.cbFromGrade.Size = New System.Drawing.Size(175, 24)
        Me.cbFromGrade.TabIndex = 6
        '
        'cbFromType
        '
        Me.cbFromType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromType.FormattingEnabled = True
        Me.cbFromType.Location = New System.Drawing.Point(143, 38)
        Me.cbFromType.Name = "cbFromType"
        Me.cbFromType.Size = New System.Drawing.Size(175, 24)
        Me.cbFromType.TabIndex = 2
        '
        'grdPromotions
        '
        Me.grdPromotions.AllowUpdate = False
        Me.grdPromotions.CaptionHeight = 20
        Me.grdPromotions.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdPromotions.Images.Add(CType(resources.GetObject("grdPromotions.Images"), System.Drawing.Image))
        Me.grdPromotions.Location = New System.Drawing.Point(6, 247)
        Me.grdPromotions.Name = "grdPromotions"
        Me.grdPromotions.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPromotions.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPromotions.PreviewInfo.ZoomFactor = 75.0R
        Me.grdPromotions.PrintInfo.PageSettings = CType(resources.GetObject("grdPromotions.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPromotions.PropBag = resources.GetString("grdPromotions.PropBag")
        Me.grdPromotions.RowHeight = 15
        Me.grdPromotions.Size = New System.Drawing.Size(637, 100)
        Me.grdPromotions.TabIndex = 16
        Me.grdPromotions.TabStop = False
        '
        'txtNewJobDescription
        '
        Me.txtNewJobDescription.Location = New System.Drawing.Point(143, 218)
        Me.txtNewJobDescription.Name = "txtNewJobDescription"
        Me.txtNewJobDescription.Size = New System.Drawing.Size(501, 23)
        Me.txtNewJobDescription.TabIndex = 12
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(143, 188)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(500, 23)
        Me.txtRemarks.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Effective Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "To Incr. Level"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 16)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "From Incr. Level"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "To Grade"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "From Grade"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(355, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "To Designation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From Designation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "To Emp Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "From Emp Type"
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
        Me.tbAudit.Size = New System.Drawing.Size(650, 351)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
        '
        'grdAudit
        '
        Me.grdAudit.AllowUpdate = False
        Me.grdAudit.CaptionHeight = 20
        Me.grdAudit.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAudit.Images.Add(CType(resources.GetObject("grdAudit.Images"), System.Drawing.Image))
        Me.grdAudit.Location = New System.Drawing.Point(4, 5)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAudit.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAudit.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAudit.PrintInfo.PageSettings = CType(resources.GetObject("grdAudit.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        Me.grdAudit.RowHeight = 15
        Me.grdAudit.Size = New System.Drawing.Size(642, 341)
        Me.grdAudit.TabIndex = 36
        Me.grdAudit.TabStop = False
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 408)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 9
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'frmEmployeePromotions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 430)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeePromotions"
        Me.Text = "Employee Promotions"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        CType(Me.grdPromotions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents tbQualifications As TabPage
    Friend WithEvents txtToIncrement As TextBox
    Friend WithEvents txtFromIncrement As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cbFromGrade As ComboBox
    Friend WithEvents cbFromType As ComboBox
    Friend WithEvents txtNewJobDescription As TextBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Public WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents cbToType As ComboBox
    Friend WithEvents cbToDesignation As ComboBox
    Friend WithEvents cbFromDesignation As ComboBox
    Friend WithEvents cbToGrade As ComboBox
    Friend WithEvents dtpEffectiveDate As DateTimePicker
    Private WithEvents grdPromotions As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
