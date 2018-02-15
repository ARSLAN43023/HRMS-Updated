<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeStatusSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeStatusSearch))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDetail = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.txtEmployeeNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdSearch = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tlbToolbar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClear, Me.btnSearch, Me.btnDetail})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(806, 25)
        Me.tlbToolbar.TabIndex = 3
        Me.tlbToolbar.Text = "tlbTop"
        '
        'btnClear
        '
        Me.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClear.Image = Global.HR.My.Resources.Resources._NEW
        Me.btnClear.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(23, 22)
        Me.btnClear.Text = "Clear"
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
        'btnDetail
        '
        Me.btnDetail.BackColor = System.Drawing.SystemColors.Control
        Me.btnDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDetail.Image = Global.HR.My.Resources.Resources._NEXT
        Me.btnDetail.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(23, 22)
        Me.btnDetail.Text = "Detail"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpToDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFromDate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 88)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Criteria"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Active", "Retired", "Resigned", "Terminated", "Deceased", "Re-joined"})
        Me.cbStatus.Location = New System.Drawing.Point(602, 22)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(175, 24)
        Me.cbStatus.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "To Date"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MM/yy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(366, 51)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.ShowCheckBox = True
        Me.dtpToDate.Size = New System.Drawing.Size(150, 23)
        Me.dtpToDate.TabIndex = 5
        Me.dtpToDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "From Date"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(84, 52)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.ShowCheckBox = True
        Me.dtpFromDate.Size = New System.Drawing.Size(150, 23)
        Me.dtpFromDate.TabIndex = 4
        Me.dtpFromDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(534, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 16)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Status"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(250, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Emp. Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(366, 22)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(150, 23)
        Me.txtEmployeeName.TabIndex = 2
        '
        'txtEmployeeNo
        '
        Me.txtEmployeeNo.Location = New System.Drawing.Point(84, 22)
        Me.txtEmployeeNo.Name = "txtEmployeeNo"
        Me.txtEmployeeNo.Size = New System.Drawing.Size(150, 23)
        Me.txtEmployeeNo.TabIndex = 1
        Me.txtEmployeeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Emp. No."
        '
        'grdSearch
        '
        Me.grdSearch.AllowUpdate = False
        Me.grdSearch.CaptionHeight = 17
        Me.grdSearch.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        Me.grdSearch.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdSearch.Images.Add(CType(resources.GetObject("grdSearch.Images"), System.Drawing.Image))
        Me.grdSearch.Location = New System.Drawing.Point(9, 123)
        Me.grdSearch.Name = "grdSearch"
        Me.grdSearch.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSearch.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSearch.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSearch.PrintInfo.PageSettings = CType(resources.GetObject("grdSearch.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSearch.RowHeight = 15
        Me.grdSearch.Size = New System.Drawing.Size(789, 221)
        Me.grdSearch.TabIndex = 5
        Me.grdSearch.TabStop = False
        Me.grdSearch.PropBag = resources.GetString("grdSearch.PropBag")
        '
        'frmEmployeeStatusSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 347)
        Me.Controls.Add(Me.grdSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeStatusSearch"
        Me.Text = "Employee Status Search"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDetail As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents txtEmployeeNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents grdSearch As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents cbStatus As ComboBox
End Class
