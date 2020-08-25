<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeSearch
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeSearch))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAllEmployees = New System.Windows.Forms.CheckBox()
        Me.chkNewEmployees = New System.Windows.Forms.CheckBox()
        Me.chkHOD = New System.Windows.Forms.CheckBox()
        Me.chkTechnical = New System.Windows.Forms.CheckBox()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbLocation = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.txtEmployeeNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDetail = New System.Windows.Forms.ToolStripButton()
        Me.grdSearch = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.EMEmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsHR = New HR.dsHR()
        Me.EM_EmployeeTableAdapter = New HR.dsHRTableAdapters.EM_EmployeeTableAdapter()
        Me.GroupBox1.SuspendLayout()
        Me.tlbToolbar.SuspendLayout()
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EMEmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAllEmployees)
        Me.GroupBox1.Controls.Add(Me.chkNewEmployees)
        Me.GroupBox1.Controls.Add(Me.chkHOD)
        Me.GroupBox1.Controls.Add(Me.chkTechnical)
        Me.GroupBox1.Controls.Add(Me.cbDepartment)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cbLocation)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 88)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Criteria"
        '
        'chkAllEmployees
        '
        Me.chkAllEmployees.AutoSize = True
        Me.chkAllEmployees.Location = New System.Drawing.Point(281, 56)
        Me.chkAllEmployees.Name = "chkAllEmployees"
        Me.chkAllEmployees.Size = New System.Drawing.Size(79, 21)
        Me.chkAllEmployees.TabIndex = 38
        Me.chkAllEmployees.Text = "All Emp"
        Me.chkAllEmployees.UseVisualStyleBackColor = True
        Me.chkAllEmployees.Visible = False
        '
        'chkNewEmployees
        '
        Me.chkNewEmployees.AutoSize = True
        Me.chkNewEmployees.Location = New System.Drawing.Point(366, 56)
        Me.chkNewEmployees.Name = "chkNewEmployees"
        Me.chkNewEmployees.Size = New System.Drawing.Size(136, 21)
        Me.chkNewEmployees.TabIndex = 6
        Me.chkNewEmployees.Text = "New Employees"
        Me.chkNewEmployees.UseVisualStyleBackColor = True
        Me.chkNewEmployees.Visible = False
        '
        'chkHOD
        '
        Me.chkHOD.AutoSize = True
        Me.chkHOD.Location = New System.Drawing.Point(105, 56)
        Me.chkHOD.Name = "chkHOD"
        Me.chkHOD.Size = New System.Drawing.Size(170, 21)
        Me.chkHOD.TabIndex = 5
        Me.chkHOD.Text = "Head of Department"
        Me.chkHOD.UseVisualStyleBackColor = True
        '
        'chkTechnical
        '
        Me.chkTechnical.AutoSize = True
        Me.chkTechnical.Location = New System.Drawing.Point(9, 56)
        Me.chkTechnical.Name = "chkTechnical"
        Me.chkTechnical.Size = New System.Drawing.Size(88, 21)
        Me.chkTechnical.TabIndex = 4
        Me.chkTechnical.Text = "Technical"
        Me.chkTechnical.UseVisualStyleBackColor = True
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(626, 52)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(150, 25)
        Me.cbDepartment.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(534, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 17)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Department"
        '
        'cbLocation
        '
        Me.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocation.FormattingEnabled = True
        Me.cbLocation.Location = New System.Drawing.Point(626, 22)
        Me.cbLocation.Name = "cbLocation"
        Me.cbLocation.Size = New System.Drawing.Size(150, 25)
        Me.cbLocation.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(534, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 17)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Location"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(241, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 17)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Employee Name"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(366, 22)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(150, 24)
        Me.txtEmployeeName.TabIndex = 2
        '
        'txtEmployeeNo
        '
        Me.txtEmployeeNo.Location = New System.Drawing.Point(105, 22)
        Me.txtEmployeeNo.Name = "txtEmployeeNo"
        Me.txtEmployeeNo.Size = New System.Drawing.Size(75, 24)
        Me.txtEmployeeNo.TabIndex = 1
        Me.txtEmployeeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Employee No."
        '
        'tlbToolbar
        '
        Me.tlbToolbar.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClear, Me.btnSearch, Me.btnDetail})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(806, 25)
        Me.tlbToolbar.TabIndex = 2
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
        'grdSearch
        '
        Me.grdSearch.AllowUpdate = False
        Me.grdSearch.CaptionHeight = 17
        Me.grdSearch.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
        Me.grdSearch.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdSearch.Images.Add(CType(resources.GetObject("grdSearch.Images"), System.Drawing.Image))
        Me.grdSearch.Location = New System.Drawing.Point(9, 125)
        Me.grdSearch.Name = "grdSearch"
        Me.grdSearch.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSearch.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSearch.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSearch.PrintInfo.PageSettings = CType(resources.GetObject("grdSearch.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSearch.RowHeight = 15
        Me.grdSearch.Size = New System.Drawing.Size(789, 288)
        Me.grdSearch.TabIndex = 0
        Me.grdSearch.TabStop = False
        Me.grdSearch.PropBag = resources.GetString("grdSearch.PropBag")
        '
        'EMEmployeeBindingSource
        '
        Me.EMEmployeeBindingSource.DataMember = "EM_Employee"
        Me.EMEmployeeBindingSource.DataSource = Me.DsHR
        '
        'DsHR
        '
        Me.DsHR.DataSetName = "dsHR"
        Me.DsHR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EM_EmployeeTableAdapter
        '
        Me.EM_EmployeeTableAdapter.ClearBeforeFill = True
        '
        'frmEmployeeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 419)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdSearch)
        Me.Name = "frmEmployeeSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Search Employee"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        CType(Me.grdSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EMEmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDetail As ToolStripButton
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents Label14 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents txtEmployeeNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDepartment As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cbLocation As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents chkHOD As CheckBox
    Friend WithEvents chkTechnical As CheckBox
    Friend WithEvents chkNewEmployees As CheckBox
    Friend WithEvents DsHR As dsHR
    Friend WithEvents EMEmployeeBindingSource As BindingSource
    Friend WithEvents EM_EmployeeTableAdapter As dsHRTableAdapters.EM_EmployeeTableAdapter
    Friend WithEvents chkAllEmployees As CheckBox
    Public WithEvents grdSearch As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
