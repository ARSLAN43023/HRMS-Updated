<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeeProfileDW
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeeProfileDW))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnVerify = New System.Windows.Forms.ToolStripButton()
        Me.btnApprove = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbPersonal = New System.Windows.Forms.TabPage()
        Me.cbBloodGroup = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.cbDomicile = New System.Windows.Forms.ComboBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txtCNICNew = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.cmdUploadPicture = New System.Windows.Forms.Button()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmpID = New System.Windows.Forms.TextBox()
        Me.pbEmployeePhoto = New System.Windows.Forms.PictureBox()
        Me.dtpStatusSince = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbMaritalStatus = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbBirthCity = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbBirthCountry = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.cbNationality = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbReligion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFatherName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmployeeNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFCCL = New System.Windows.Forms.TabPage()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpGradeEffectiveDate = New System.Windows.Forms.DateTimePicker()
        Me.cbGrade = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbEmployeeType = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dtpContractEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpContractStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cbContractType = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpJoiningDate = New System.Windows.Forms.DateTimePicker()
        Me.cbDesignation = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbBusinessUnit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DsHR = New HR.dsHR()
        Me.EM_Employee_AuditTableAdapter = New HR.dsHRTableAdapters.EM_Employee_AuditTableAdapter()
        Me.tlbToolbar.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbPersonal.SuspendLayout()
        CType(Me.pbEmployeePhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbFCCL.SuspendLayout()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stbDetail.SuspendLayout()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnSave, Me.btnSearch, Me.btnDelete, Me.ToolStripSeparator1, Me.btnVerify, Me.btnApprove})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(1012, 25)
        Me.tlbToolbar.TabIndex = 1
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
        Me.btnDelete.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator1.Visible = False
        '
        'btnVerify
        '
        Me.btnVerify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnVerify.Image = Global.HR.My.Resources.Resources.Verify
        Me.btnVerify.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(23, 22)
        Me.btnVerify.Text = "Verify"
        Me.btnVerify.ToolTipText = "Verify"
        Me.btnVerify.Visible = False
        '
        'btnApprove
        '
        Me.btnApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnApprove.Image = Global.HR.My.Resources.Resources.Approve2
        Me.btnApprove.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(23, 22)
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbPersonal)
        Me.TabControl1.Controls.Add(Me.tbFCCL)
        Me.TabControl1.Controls.Add(Me.tbAudit)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(6, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1000, 318)
        Me.TabControl1.TabIndex = 2
        '
        'tbPersonal
        '
        Me.tbPersonal.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbPersonal.Controls.Add(Me.cbBloodGroup)
        Me.tbPersonal.Controls.Add(Me.Label63)
        Me.tbPersonal.Controls.Add(Me.cbDomicile)
        Me.tbPersonal.Controls.Add(Me.Label101)
        Me.tbPersonal.Controls.Add(Me.txtCNICNew)
        Me.tbPersonal.Controls.Add(Me.Label102)
        Me.tbPersonal.Controls.Add(Me.cmdUploadPicture)
        Me.tbPersonal.Controls.Add(Me.Label100)
        Me.tbPersonal.Controls.Add(Me.Label14)
        Me.tbPersonal.Controls.Add(Me.txtEmpID)
        Me.tbPersonal.Controls.Add(Me.pbEmployeePhoto)
        Me.tbPersonal.Controls.Add(Me.dtpStatusSince)
        Me.tbPersonal.Controls.Add(Me.Label13)
        Me.tbPersonal.Controls.Add(Me.cbMaritalStatus)
        Me.tbPersonal.Controls.Add(Me.Label12)
        Me.tbPersonal.Controls.Add(Me.cbBirthCity)
        Me.tbPersonal.Controls.Add(Me.Label11)
        Me.tbPersonal.Controls.Add(Me.cbBirthCountry)
        Me.tbPersonal.Controls.Add(Me.Label10)
        Me.tbPersonal.Controls.Add(Me.Label9)
        Me.tbPersonal.Controls.Add(Me.dtpDOB)
        Me.tbPersonal.Controls.Add(Me.cbNationality)
        Me.tbPersonal.Controls.Add(Me.Label8)
        Me.tbPersonal.Controls.Add(Me.cbReligion)
        Me.tbPersonal.Controls.Add(Me.Label7)
        Me.tbPersonal.Controls.Add(Me.cbGender)
        Me.tbPersonal.Controls.Add(Me.Label6)
        Me.tbPersonal.Controls.Add(Me.txtFatherName)
        Me.tbPersonal.Controls.Add(Me.Label2)
        Me.tbPersonal.Controls.Add(Me.txtLastName)
        Me.tbPersonal.Controls.Add(Me.Label5)
        Me.tbPersonal.Controls.Add(Me.txtMiddleName)
        Me.tbPersonal.Controls.Add(Me.Label4)
        Me.tbPersonal.Controls.Add(Me.txtFirstName)
        Me.tbPersonal.Controls.Add(Me.Label3)
        Me.tbPersonal.Controls.Add(Me.txtEmployeeNo)
        Me.tbPersonal.Controls.Add(Me.Label1)
        Me.tbPersonal.Location = New System.Drawing.Point(4, 25)
        Me.tbPersonal.Name = "tbPersonal"
        Me.tbPersonal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPersonal.Size = New System.Drawing.Size(992, 289)
        Me.tbPersonal.TabIndex = 1
        Me.tbPersonal.Text = "Personal Information"
        '
        'cbBloodGroup
        '
        Me.cbBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBloodGroup.FormattingEnabled = True
        Me.cbBloodGroup.Location = New System.Drawing.Point(471, 251)
        Me.cbBloodGroup.Name = "cbBloodGroup"
        Me.cbBloodGroup.Size = New System.Drawing.Size(175, 24)
        Me.cbBloodGroup.TabIndex = 17
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(323, 256)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(86, 16)
        Me.Label63.TabIndex = 56
        Me.Label63.Text = "Blood Group"
        '
        'cbDomicile
        '
        Me.cbDomicile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDomicile.FormattingEnabled = True
        Me.cbDomicile.Location = New System.Drawing.Point(472, 161)
        Me.cbDomicile.Name = "cbDomicile"
        Me.cbDomicile.Size = New System.Drawing.Size(175, 24)
        Me.cbDomicile.TabIndex = 11
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Location = New System.Drawing.Point(322, 166)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(61, 16)
        Me.Label101.TabIndex = 54
        Me.Label101.Text = "Domicile"
        '
        'txtCNICNew
        '
        Me.txtCNICNew.Location = New System.Drawing.Point(472, 131)
        Me.txtCNICNew.Name = "txtCNICNew"
        Me.txtCNICNew.Size = New System.Drawing.Size(175, 23)
        Me.txtCNICNew.TabIndex = 9
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(322, 136)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(73, 16)
        Me.Label102.TabIndex = 53
        Me.Label102.Text = "New CNIC"
        '
        'cmdUploadPicture
        '
        Me.cmdUploadPicture.Location = New System.Drawing.Point(123, 253)
        Me.cmdUploadPicture.Name = "cmdUploadPicture"
        Me.cmdUploadPicture.Size = New System.Drawing.Size(75, 25)
        Me.cmdUploadPicture.TabIndex = 16
        Me.cmdUploadPicture.Text = "Browse"
        Me.cmdUploadPicture.UseVisualStyleBackColor = True
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Location = New System.Drawing.Point(12, 255)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(54, 16)
        Me.Label100.TabIndex = 31
        Me.Label100.Text = "Picture"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(322, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 16)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Emp ID"
        Me.Label14.Visible = False
        '
        'txtEmpID
        '
        Me.txtEmpID.Location = New System.Drawing.Point(471, 11)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.Size = New System.Drawing.Size(175, 23)
        Me.txtEmpID.TabIndex = 29
        Me.txtEmpID.Visible = False
        '
        'pbEmployeePhoto
        '
        Me.pbEmployeePhoto.Location = New System.Drawing.Point(738, 11)
        Me.pbEmployeePhoto.Name = "pbEmployeePhoto"
        Me.pbEmployeePhoto.Size = New System.Drawing.Size(235, 235)
        Me.pbEmployeePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbEmployeePhoto.TabIndex = 28
        Me.pbEmployeePhoto.TabStop = False
        '
        'dtpStatusSince
        '
        Me.dtpStatusSince.CustomFormat = "dd/MM/yy"
        Me.dtpStatusSince.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStatusSince.Location = New System.Drawing.Point(471, 221)
        Me.dtpStatusSince.Name = "dtpStatusSince"
        Me.dtpStatusSince.ShowCheckBox = True
        Me.dtpStatusSince.Size = New System.Drawing.Size(175, 23)
        Me.dtpStatusSince.TabIndex = 15
        Me.dtpStatusSince.Value = New Date(2015, 11, 9, 11, 57, 14, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Marital Status Since"
        '
        'cbMaritalStatus
        '
        Me.cbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMaritalStatus.FormattingEnabled = True
        Me.cbMaritalStatus.Items.AddRange(New Object() {"-", "Married", "Unmarried", "Divorced", "Widowed"})
        Me.cbMaritalStatus.Location = New System.Drawing.Point(123, 221)
        Me.cbMaritalStatus.Name = "cbMaritalStatus"
        Me.cbMaritalStatus.Size = New System.Drawing.Size(175, 24)
        Me.cbMaritalStatus.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 226)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Marital Status"
        '
        'cbBirthCity
        '
        Me.cbBirthCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBirthCity.FormattingEnabled = True
        Me.cbBirthCity.Location = New System.Drawing.Point(471, 191)
        Me.cbBirthCity.Name = "cbBirthCity"
        Me.cbBirthCity.Size = New System.Drawing.Size(175, 24)
        Me.cbBirthCity.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(322, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Birth City"
        '
        'cbBirthCountry
        '
        Me.cbBirthCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBirthCountry.FormattingEnabled = True
        Me.cbBirthCountry.Location = New System.Drawing.Point(123, 191)
        Me.cbBirthCountry.Name = "cbBirthCountry"
        Me.cbBirthCountry.Size = New System.Drawing.Size(175, 24)
        Me.cbBirthCountry.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Birth Country"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(322, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Date of Birth"
        '
        'dtpDOB
        '
        Me.dtpDOB.CustomFormat = "dd/MM/yy"
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOB.Location = New System.Drawing.Point(471, 101)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.ShowCheckBox = True
        Me.dtpDOB.Size = New System.Drawing.Size(175, 23)
        Me.dtpDOB.TabIndex = 7
        Me.dtpDOB.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbNationality
        '
        Me.cbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNationality.FormattingEnabled = True
        Me.cbNationality.Location = New System.Drawing.Point(123, 161)
        Me.cbNationality.Name = "cbNationality"
        Me.cbNationality.Size = New System.Drawing.Size(175, 24)
        Me.cbNationality.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Nationality"
        '
        'cbReligion
        '
        Me.cbReligion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbReligion.FormattingEnabled = True
        Me.cbReligion.Location = New System.Drawing.Point(123, 131)
        Me.cbReligion.Name = "cbReligion"
        Me.cbReligion.Size = New System.Drawing.Size(175, 24)
        Me.cbReligion.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Religion"
        '
        'cbGender
        '
        Me.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cbGender.Location = New System.Drawing.Point(123, 101)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(175, 24)
        Me.cbGender.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Gender"
        '
        'txtFatherName
        '
        Me.txtFatherName.Location = New System.Drawing.Point(471, 71)
        Me.txtFatherName.Name = "txtFatherName"
        Me.txtFatherName.Size = New System.Drawing.Size(175, 23)
        Me.txtFatherName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(322, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Father's Name"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(123, 71)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(175, 23)
        Me.txtLastName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Last Name"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(471, 41)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(175, 23)
        Me.txtMiddleName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(322, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Middle Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(123, 41)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(175, 23)
        Me.txtFirstName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "First Name"
        '
        'txtEmployeeNo
        '
        Me.txtEmployeeNo.Location = New System.Drawing.Point(123, 11)
        Me.txtEmployeeNo.Name = "txtEmployeeNo"
        Me.txtEmployeeNo.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeNo.TabIndex = 1
        Me.txtEmployeeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee No."
        '
        'tbFCCL
        '
        Me.tbFCCL.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbFCCL.Controls.Add(Me.Label27)
        Me.tbFCCL.Controls.Add(Me.dtpGradeEffectiveDate)
        Me.tbFCCL.Controls.Add(Me.cbGrade)
        Me.tbFCCL.Controls.Add(Me.Label25)
        Me.tbFCCL.Controls.Add(Me.cbEmployeeType)
        Me.tbFCCL.Controls.Add(Me.Label26)
        Me.tbFCCL.Controls.Add(Me.Label22)
        Me.tbFCCL.Controls.Add(Me.dtpContractEndDate)
        Me.tbFCCL.Controls.Add(Me.Label21)
        Me.tbFCCL.Controls.Add(Me.dtpContractStartDate)
        Me.tbFCCL.Controls.Add(Me.cbContractType)
        Me.tbFCCL.Controls.Add(Me.Label20)
        Me.tbFCCL.Controls.Add(Me.Label19)
        Me.tbFCCL.Controls.Add(Me.dtpJoiningDate)
        Me.tbFCCL.Controls.Add(Me.cbDesignation)
        Me.tbFCCL.Controls.Add(Me.Label18)
        Me.tbFCCL.Controls.Add(Me.cbDepartment)
        Me.tbFCCL.Controls.Add(Me.Label17)
        Me.tbFCCL.Controls.Add(Me.cbBranch)
        Me.tbFCCL.Controls.Add(Me.Label15)
        Me.tbFCCL.Controls.Add(Me.cbBusinessUnit)
        Me.tbFCCL.Controls.Add(Me.Label16)
        Me.tbFCCL.Location = New System.Drawing.Point(4, 25)
        Me.tbFCCL.Name = "tbFCCL"
        Me.tbFCCL.Size = New System.Drawing.Size(992, 289)
        Me.tbFCCL.TabIndex = 10
        Me.tbFCCL.Text = "FCCL"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(660, 105)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(146, 16)
        Me.Label27.TabIndex = 41
        Me.Label27.Text = "Grade Effective Date"
        '
        'dtpGradeEffectiveDate
        '
        Me.dtpGradeEffectiveDate.CustomFormat = "dd/MM/yy"
        Me.dtpGradeEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpGradeEffectiveDate.Location = New System.Drawing.Point(806, 101)
        Me.dtpGradeEffectiveDate.Name = "dtpGradeEffectiveDate"
        Me.dtpGradeEffectiveDate.ShowCheckBox = True
        Me.dtpGradeEffectiveDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpGradeEffectiveDate.TabIndex = 27
        Me.dtpGradeEffectiveDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbGrade
        '
        Me.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrade.FormattingEnabled = True
        Me.cbGrade.Location = New System.Drawing.Point(475, 101)
        Me.cbGrade.Name = "cbGrade"
        Me.cbGrade.Size = New System.Drawing.Size(175, 24)
        Me.cbGrade.TabIndex = 26
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(334, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 16)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "Grade"
        '
        'cbEmployeeType
        '
        Me.cbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmployeeType.FormattingEnabled = True
        Me.cbEmployeeType.Location = New System.Drawing.Point(150, 101)
        Me.cbEmployeeType.Name = "cbEmployeeType"
        Me.cbEmployeeType.Size = New System.Drawing.Size(175, 24)
        Me.cbEmployeeType.TabIndex = 25
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 105)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(107, 16)
        Me.Label26.TabIndex = 36
        Me.Label26.Text = "Employee Type"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(660, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 16)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Contract End Date"
        '
        'dtpContractEndDate
        '
        Me.dtpContractEndDate.CustomFormat = "dd/MM/yy"
        Me.dtpContractEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContractEndDate.Location = New System.Drawing.Point(806, 71)
        Me.dtpContractEndDate.Name = "dtpContractEndDate"
        Me.dtpContractEndDate.ShowCheckBox = True
        Me.dtpContractEndDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpContractEndDate.TabIndex = 21
        Me.dtpContractEndDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(334, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(141, 16)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Contract Start Date"
        '
        'dtpContractStartDate
        '
        Me.dtpContractStartDate.CustomFormat = "dd/MM/yy"
        Me.dtpContractStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContractStartDate.Location = New System.Drawing.Point(476, 71)
        Me.dtpContractStartDate.Name = "dtpContractStartDate"
        Me.dtpContractStartDate.ShowCheckBox = True
        Me.dtpContractStartDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpContractStartDate.TabIndex = 20
        Me.dtpContractStartDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbContractType
        '
        Me.cbContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbContractType.FormattingEnabled = True
        Me.cbContractType.Items.AddRange(New Object() {"Permanent", "Contract"})
        Me.cbContractType.Location = New System.Drawing.Point(150, 71)
        Me.cbContractType.Name = "cbContractType"
        Me.cbContractType.Size = New System.Drawing.Size(175, 24)
        Me.cbContractType.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 16)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Contract Type"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(660, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Joining Date"
        '
        'dtpJoiningDate
        '
        Me.dtpJoiningDate.CustomFormat = "dd/MM/yy"
        Me.dtpJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpJoiningDate.Location = New System.Drawing.Point(806, 41)
        Me.dtpJoiningDate.Name = "dtpJoiningDate"
        Me.dtpJoiningDate.ShowCheckBox = True
        Me.dtpJoiningDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpJoiningDate.TabIndex = 18
        Me.dtpJoiningDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbDesignation
        '
        Me.cbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDesignation.FormattingEnabled = True
        Me.cbDesignation.Location = New System.Drawing.Point(150, 41)
        Me.cbDesignation.Name = "cbDesignation"
        Me.cbDesignation.Size = New System.Drawing.Size(500, 24)
        Me.cbDesignation.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 16)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Designation"
        '
        'cbDepartment
        '
        Me.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Location = New System.Drawing.Point(806, 11)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(175, 24)
        Me.cbDepartment.TabIndex = 16
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(660, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 16)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Department"
        '
        'cbBranch
        '
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(475, 11)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(175, 24)
        Me.cbBranch.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(334, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 16)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Branch"
        '
        'cbBusinessUnit
        '
        Me.cbBusinessUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBusinessUnit.FormattingEnabled = True
        Me.cbBusinessUnit.Location = New System.Drawing.Point(150, 11)
        Me.cbBusinessUnit.Name = "cbBusinessUnit"
        Me.cbBusinessUnit.Size = New System.Drawing.Size(175, 24)
        Me.cbBusinessUnit.TabIndex = 14
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 16)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Business Unit"
        '
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(992, 289)
        Me.tbAudit.TabIndex = 9
        Me.tbAudit.Text = "Audit"
        '
        'grdAudit
        '
        Me.grdAudit.AllowUpdate = False
        Me.grdAudit.CaptionHeight = 20
        Me.grdAudit.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAudit.Images.Add(CType(resources.GetObject("grdAudit.Images"), System.Drawing.Image))
        Me.grdAudit.Location = New System.Drawing.Point(7, 6)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAudit.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAudit.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAudit.PrintInfo.PageSettings = CType(resources.GetObject("grdAudit.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAudit.RowHeight = 15
        Me.grdAudit.Size = New System.Drawing.Size(979, 277)
        Me.grdAudit.TabIndex = 34
        Me.grdAudit.TabStop = False
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 351)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(1012, 22)
        Me.stbDetail.TabIndex = 3
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(120, 17)
        Me.slStatus.Text = "ToolStripStatusLabel1"
        '
        'DsHR
        '
        Me.DsHR.DataSetName = "dsHR"
        Me.DsHR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EM_Employee_AuditTableAdapter
        '
        Me.EM_Employee_AuditTableAdapter.ClearBeforeFill = True
        '
        'frmEmployeeProfileDW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 373)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmEmployeeProfileDW"
        Me.Text = "Employee Profile - Daily Wager"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbPersonal.ResumeLayout(False)
        Me.tbPersonal.PerformLayout()
        CType(Me.pbEmployeePhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbFCCL.ResumeLayout(False)
        Me.tbFCCL.PerformLayout()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnVerify As ToolStripButton
    Friend WithEvents btnApprove As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbPersonal As TabPage
    Friend WithEvents cbBloodGroup As ComboBox
    Friend WithEvents Label63 As Label
    Friend WithEvents cbDomicile As ComboBox
    Friend WithEvents Label101 As Label
    Friend WithEvents txtCNICNew As TextBox
    Friend WithEvents Label102 As Label
    Friend WithEvents cmdUploadPicture As Button
    Friend WithEvents Label100 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtEmpID As TextBox
    Friend WithEvents pbEmployeePhoto As PictureBox
    Friend WithEvents dtpStatusSince As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents cbMaritalStatus As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cbBirthCity As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbBirthCountry As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpDOB As DateTimePicker
    Friend WithEvents cbNationality As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbReligion As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbGender As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFatherName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmployeeNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbFCCL As TabPage
    Friend WithEvents Label27 As Label
    Friend WithEvents dtpGradeEffectiveDate As DateTimePicker
    Friend WithEvents cbGrade As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cbEmployeeType As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents dtpContractEndDate As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpContractStartDate As DateTimePicker
    Friend WithEvents cbContractType As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpJoiningDate As DateTimePicker
    Friend WithEvents cbDesignation As ComboBox
    Protected Friend WithEvents Label18 As Label
    Friend WithEvents cbDepartment As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cbBranch As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cbBusinessUnit As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents tbAudit As TabPage
    Friend WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents DsHR As dsHR
    Friend WithEvents EM_Employee_AuditTableAdapter As dsHRTableAdapters.EM_Employee_AuditTableAdapter
End Class
