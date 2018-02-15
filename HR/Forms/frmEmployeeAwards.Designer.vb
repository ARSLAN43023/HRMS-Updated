<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeAwards
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeAwards))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbAwardInformation = New System.Windows.Forms.TabControl()
        Me.tbAwardInfo = New System.Windows.Forms.TabPage()
        Me.txtAwardName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grdAwards = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtAwardDescription = New System.Windows.Forms.TextBox()
        Me.dtpAwardingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAwardingAuthority = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlbToolbar.SuspendLayout()
        Me.tbAwardInformation.SuspendLayout()
        Me.tbAwardInfo.SuspendLayout()
        CType(Me.grdAwards, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tlbToolbar.TabIndex = 2
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
        'tbAwardInformation
        '
        Me.tbAwardInformation.Controls.Add(Me.tbAwardInfo)
        Me.tbAwardInformation.Controls.Add(Me.tbAudit)
        Me.tbAwardInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAwardInformation.Location = New System.Drawing.Point(4, 27)
        Me.tbAwardInformation.Name = "tbAwardInformation"
        Me.tbAwardInformation.SelectedIndex = 0
        Me.tbAwardInformation.Size = New System.Drawing.Size(658, 217)
        Me.tbAwardInformation.TabIndex = 5
        '
        'tbAwardInfo
        '
        Me.tbAwardInfo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAwardInfo.Controls.Add(Me.txtAwardName)
        Me.tbAwardInfo.Controls.Add(Me.Label12)
        Me.tbAwardInfo.Controls.Add(Me.grdAwards)
        Me.tbAwardInfo.Controls.Add(Me.txtAwardDescription)
        Me.tbAwardInfo.Controls.Add(Me.dtpAwardingDate)
        Me.tbAwardInfo.Controls.Add(Me.Label6)
        Me.tbAwardInfo.Controls.Add(Me.Label4)
        Me.tbAwardInfo.Controls.Add(Me.txtAwardingAuthority)
        Me.tbAwardInfo.Controls.Add(Me.Label3)
        Me.tbAwardInfo.Controls.Add(Me.txtEmployeeName)
        Me.tbAwardInfo.Controls.Add(Me.Label1)
        Me.tbAwardInfo.Location = New System.Drawing.Point(4, 25)
        Me.tbAwardInfo.Name = "tbAwardInfo"
        Me.tbAwardInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAwardInfo.Size = New System.Drawing.Size(650, 188)
        Me.tbAwardInfo.TabIndex = 1
        Me.tbAwardInfo.Text = "Award Information"
        '
        'txtAwardName
        '
        Me.txtAwardName.Location = New System.Drawing.Point(468, 8)
        Me.txtAwardName.Name = "txtAwardName"
        Me.txtAwardName.Size = New System.Drawing.Size(175, 23)
        Me.txtAwardName.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(355, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Award Name"
        '
        'grdAwards
        '
        Me.grdAwards.AllowUpdate = False
        Me.grdAwards.CaptionHeight = 20
        Me.grdAwards.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAwards.Images.Add(CType(resources.GetObject("grdAwards.Images"), System.Drawing.Image))
        Me.grdAwards.Location = New System.Drawing.Point(6, 97)
        Me.grdAwards.Name = "grdAwards"
        Me.grdAwards.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAwards.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAwards.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAwards.PrintInfo.PageSettings = CType(resources.GetObject("grdAwards.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAwards.RowHeight = 15
        Me.grdAwards.Size = New System.Drawing.Size(637, 87)
        Me.grdAwards.TabIndex = 6
        Me.grdAwards.TabStop = False
        Me.grdAwards.PropBag = resources.GetString("grdAwards.PropBag")
        '
        'txtAwardDescription
        '
        Me.txtAwardDescription.Location = New System.Drawing.Point(143, 68)
        Me.txtAwardDescription.Name = "txtAwardDescription"
        Me.txtAwardDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtAwardDescription.TabIndex = 5
        '
        'dtpAwardingDate
        '
        Me.dtpAwardingDate.CustomFormat = "dd/MM/yy"
        Me.dtpAwardingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAwardingDate.Location = New System.Drawing.Point(468, 38)
        Me.dtpAwardingDate.Name = "dtpAwardingDate"
        Me.dtpAwardingDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpAwardingDate.TabIndex = 4
        Me.dtpAwardingDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Date Awarded"
        '
        'txtAwardingAuthority
        '
        Me.txtAwardingAuthority.Location = New System.Drawing.Point(143, 38)
        Me.txtAwardingAuthority.Name = "txtAwardingAuthority"
        Me.txtAwardingAuthority.Size = New System.Drawing.Size(175, 23)
        Me.txtAwardingAuthority.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Awarding Authority"
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
        Me.tbAudit.Size = New System.Drawing.Size(650, 188)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
        '
        'grdAudit
        '
        Me.grdAudit.AllowUpdate = False
        Me.grdAudit.CaptionHeight = 20
        Me.grdAudit.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAudit.Images.Add(CType(resources.GetObject("grdAudit.Images"), System.Drawing.Image))
        Me.grdAudit.Location = New System.Drawing.Point(4, 4)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAudit.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAudit.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAudit.PrintInfo.PageSettings = CType(resources.GetObject("grdAudit.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAudit.RowHeight = 15
        Me.grdAudit.Size = New System.Drawing.Size(642, 181)
        Me.grdAudit.TabIndex = 37
        Me.grdAudit.TabStop = False
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 243)
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
        'frmEmployeeAwards
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 265)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbAwardInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeAwards"
        Me.Text = "Employee Awards"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbAwardInformation.ResumeLayout(False)
        Me.tbAwardInfo.ResumeLayout(False)
        Me.tbAwardInfo.PerformLayout()
        CType(Me.grdAwards, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tbAwardInformation As TabControl
    Friend WithEvents tbAwardInfo As TabPage
    Friend WithEvents grdAwards As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtAwardDescription As TextBox
    Friend WithEvents dtpAwardingDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAwardingAuthority As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents txtAwardName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
