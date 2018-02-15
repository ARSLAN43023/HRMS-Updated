<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeeDiscipline
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeDiscipline))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbAwardInformation = New System.Windows.Forms.TabControl()
        Me.tbDiscipline = New System.Windows.Forms.TabPage()
        Me.grdDiscipline = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlbToolbar.SuspendLayout()
        Me.tbAwardInformation.SuspendLayout()
        Me.tbDiscipline.SuspendLayout()
        CType(Me.grdDiscipline, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tlbToolbar.TabIndex = 4
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
        Me.tbAwardInformation.Controls.Add(Me.tbDiscipline)
        Me.tbAwardInformation.Controls.Add(Me.tbAudit)
        Me.tbAwardInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAwardInformation.Location = New System.Drawing.Point(4, 28)
        Me.tbAwardInformation.Name = "tbAwardInformation"
        Me.tbAwardInformation.SelectedIndex = 0
        Me.tbAwardInformation.Size = New System.Drawing.Size(658, 217)
        Me.tbAwardInformation.TabIndex = 7
        '
        'tbDiscipline
        '
        Me.tbDiscipline.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbDiscipline.Controls.Add(Me.grdDiscipline)
        Me.tbDiscipline.Controls.Add(Me.cbType)
        Me.tbDiscipline.Controls.Add(Me.Label12)
        Me.tbDiscipline.Controls.Add(Me.txtRemarks)
        Me.tbDiscipline.Controls.Add(Me.dtpDate)
        Me.tbDiscipline.Controls.Add(Me.Label6)
        Me.tbDiscipline.Controls.Add(Me.Label3)
        Me.tbDiscipline.Controls.Add(Me.txtEmployeeName)
        Me.tbDiscipline.Controls.Add(Me.Label1)
        Me.tbDiscipline.Location = New System.Drawing.Point(4, 25)
        Me.tbDiscipline.Name = "tbDiscipline"
        Me.tbDiscipline.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDiscipline.Size = New System.Drawing.Size(650, 188)
        Me.tbDiscipline.TabIndex = 1
        Me.tbDiscipline.Text = "Discipline"
        '
        'grdDiscipline
        '
        Me.grdDiscipline.AllowUpdate = False
        Me.grdDiscipline.CaptionHeight = 20
        Me.grdDiscipline.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdDiscipline.Images.Add(CType(resources.GetObject("grdDiscipline.Images"), System.Drawing.Image))
        Me.grdDiscipline.Location = New System.Drawing.Point(7, 97)
        Me.grdDiscipline.Name = "grdDiscipline"
        Me.grdDiscipline.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDiscipline.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDiscipline.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDiscipline.PrintInfo.PageSettings = CType(resources.GetObject("grdDiscipline.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDiscipline.RowHeight = 15
        Me.grdDiscipline.Size = New System.Drawing.Size(637, 87)
        Me.grdDiscipline.TabIndex = 41
        Me.grdDiscipline.TabStop = False
        Me.grdDiscipline.PropBag = resources.GetString("grdDiscipline.PropBag")
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Warning", "Show Cause", "Explanation", "Advice"})
        Me.cbType.Location = New System.Drawing.Point(143, 38)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(175, 24)
        Me.cbType.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(355, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 16)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Date"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(143, 68)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(500, 23)
        Me.txtRemarks.TabIndex = 4
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(468, 8)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.ShowCheckBox = True
        Me.dtpDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpDate.TabIndex = 2
        Me.dtpDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Remarks"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Type"
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
        Me.grdAudit.Location = New System.Drawing.Point(4, 3)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAudit.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAudit.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAudit.PrintInfo.PageSettings = CType(resources.GetObject("grdAudit.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAudit.RowHeight = 15
        Me.grdAudit.Size = New System.Drawing.Size(642, 180)
        Me.grdAudit.TabIndex = 35
        Me.grdAudit.TabStop = False
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 249)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 8
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'frmEmployeeDiscipline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 271)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbAwardInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeDiscipline"
        Me.Text = "Employee Discipline"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbAwardInformation.ResumeLayout(False)
        Me.tbDiscipline.ResumeLayout(False)
        Me.tbDiscipline.PerformLayout()
        CType(Me.grdDiscipline, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tbDiscipline As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents cbType As ComboBox
    Friend WithEvents grdDiscipline As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
