<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCities
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCities))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.grdCities = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New System.Windows.Forms.DataGridView()
        Me.vcAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtmActionAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcActionRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlbToolbar.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        CType(Me.grdCities, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tlbToolbar.Size = New System.Drawing.Size(515, 25)
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
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Image = Global.HR.My.Resources.Resources.DELETE
        Me.btnDelete.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Visible = False
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Controls.Add(Me.tbAudit)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(4, 26)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(512, 299)
        Me.tbJobInformation.TabIndex = 9
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.Label2)
        Me.tbQualifications.Controls.Add(Me.cbCountry)
        Me.tbQualifications.Controls.Add(Me.grdCities)
        Me.tbQualifications.Controls.Add(Me.txtCity)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(504, 270)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Detail"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "City"
        '
        'cbCountry
        '
        Me.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCountry.FormattingEnabled = True
        Me.cbCountry.Location = New System.Drawing.Point(69, 8)
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Size = New System.Drawing.Size(175, 24)
        Me.cbCountry.TabIndex = 1
        '
        'grdCities
        '
        Me.grdCities.AllowUpdate = False
        Me.grdCities.CaptionHeight = 20
        Me.grdCities.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdCities.Images.Add(CType(resources.GetObject("grdCities.Images"), System.Drawing.Image))
        Me.grdCities.Location = New System.Drawing.Point(6, 38)
        Me.grdCities.Name = "grdCities"
        Me.grdCities.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCities.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCities.PreviewInfo.ZoomFactor = 75.0R
        Me.grdCities.PrintInfo.PageSettings = CType(resources.GetObject("grdCities.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCities.PropBag = resources.GetString("grdCities.PropBag")
        Me.grdCities.RowHeight = 15
        Me.grdCities.Size = New System.Drawing.Size(494, 226)
        Me.grdCities.TabIndex = 16
        Me.grdCities.TabStop = False
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(325, 8)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(175, 23)
        Me.txtCity.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Country"
        '
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(504, 270)
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
        Me.grdAudit.Size = New System.Drawing.Size(494, 253)
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
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 329)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(515, 22)
        Me.stbDetail.TabIndex = 10
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'frmCities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 351)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmCities"
        Me.Text = "Cities"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        CType(Me.grdCities, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdAudit As DataGridView
    Friend WithEvents vcAction As DataGridViewTextBoxColumn
    Friend WithEvents vcUserId As DataGridViewTextBoxColumn
    Friend WithEvents dtmActionAction As DataGridViewTextBoxColumn
    Friend WithEvents vcActionRemarks As DataGridViewTextBoxColumn
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCountry As ComboBox
    Private WithEvents grdCities As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
