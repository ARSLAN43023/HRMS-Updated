<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeBankAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeBankAccount))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbBankDetail = New System.Windows.Forms.TabPage()
        Me.txtAccountTitle = New System.Windows.Forms.TextBox()
        Me.cbBank = New System.Windows.Forms.ComboBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
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
        Me.tbBankDetail.SuspendLayout()
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
        Me.tlbToolbar.TabIndex = 7
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
        Me.tbJobInformation.Controls.Add(Me.tbBankDetail)
        Me.tbJobInformation.Controls.Add(Me.tbAudit)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(4, 25)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(658, 155)
        Me.tbJobInformation.TabIndex = 9
        '
        'tbBankDetail
        '
        Me.tbBankDetail.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbBankDetail.Controls.Add(Me.txtAccountTitle)
        Me.tbBankDetail.Controls.Add(Me.cbBank)
        Me.tbBankDetail.Controls.Add(Me.txtBranch)
        Me.tbBankDetail.Controls.Add(Me.txtAccountNo)
        Me.tbBankDetail.Controls.Add(Me.Label9)
        Me.tbBankDetail.Controls.Add(Me.Label6)
        Me.tbBankDetail.Controls.Add(Me.Label4)
        Me.tbBankDetail.Controls.Add(Me.Label3)
        Me.tbBankDetail.Controls.Add(Me.txtEmployeeName)
        Me.tbBankDetail.Controls.Add(Me.Label1)
        Me.tbBankDetail.Location = New System.Drawing.Point(4, 25)
        Me.tbBankDetail.Name = "tbBankDetail"
        Me.tbBankDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.tbBankDetail.Size = New System.Drawing.Size(650, 126)
        Me.tbBankDetail.TabIndex = 1
        Me.tbBankDetail.Text = "Bank Detail"
        '
        'txtAccountTitle
        '
        Me.txtAccountTitle.Location = New System.Drawing.Point(468, 38)
        Me.txtAccountTitle.Name = "txtAccountTitle"
        Me.txtAccountTitle.Size = New System.Drawing.Size(175, 23)
        Me.txtAccountTitle.TabIndex = 3
        '
        'cbBank
        '
        Me.cbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBank.FormattingEnabled = True
        Me.cbBank.Location = New System.Drawing.Point(143, 68)
        Me.cbBank.Name = "cbBank"
        Me.cbBank.Size = New System.Drawing.Size(500, 24)
        Me.cbBank.TabIndex = 4
        '
        'txtBranch
        '
        Me.txtBranch.Location = New System.Drawing.Point(143, 98)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(500, 23)
        Me.txtBranch.TabIndex = 5
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(143, 38)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(175, 23)
        Me.txtAccountNo.TabIndex = 2
        Me.txtAccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Branch"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Bank"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Account Title"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Account No."
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
        Me.Label1.Location = New System.Drawing.Point(6, 15)
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
        Me.tbAudit.Size = New System.Drawing.Size(650, 126)
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
        Me.grdAudit.Size = New System.Drawing.Size(642, 119)
        Me.grdAudit.TabIndex = 37
        Me.grdAudit.TabStop = False
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 197)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(666, 22)
        Me.stbDetail.TabIndex = 10
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'frmEmployeeBankAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 219)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeBankAccount"
        Me.Text = "Employee Bank Detail"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbBankDetail.ResumeLayout(False)
        Me.tbBankDetail.PerformLayout()
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
    Friend WithEvents tbBankDetail As TabPage
    Friend WithEvents txtAccountTitle As TextBox
    Friend WithEvents cbBank As ComboBox
    Friend WithEvents txtBranch As TextBox
    Friend WithEvents txtAccountNo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Private WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
