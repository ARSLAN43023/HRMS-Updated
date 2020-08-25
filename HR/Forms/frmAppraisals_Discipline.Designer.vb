<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAppraisals_Discipline
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppraisals_Discipline))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbPromotions = New System.Windows.Forms.TabPage()
        Me.btn_DeleteQualification = New System.Windows.Forms.Button()
        Me.cmd_PreparePromotion = New System.Windows.Forms.Button()
        Me.grdPromotions = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
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
        Me.tbAwards = New System.Windows.Forms.TabPage()
        Me.cmd_PrepareAwards = New System.Windows.Forms.Button()
        Me.grdAwards = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtEmployeeNameA = New System.Windows.Forms.TextBox()
        Me.txtAwardName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAwardDescription = New System.Windows.Forms.TextBox()
        Me.dtpAwardingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAwardingAuthority = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbTrainings = New System.Windows.Forms.TabPage()
        Me.cmd_PrepareTrainings = New System.Windows.Forms.Button()
        Me.grdSeminars = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.Cost = New System.Windows.Forms.Label()
        Me.cbCity = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtEmployeeNameT = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbDiscipline = New System.Windows.Forms.TabPage()
        Me.cmd_PrepareDiscipline = New System.Windows.Forms.Button()
        Me.grdDiscipline = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cbDisciplineType = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDisciplineDescription = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtEmployeeNameD = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbAudit = New System.Windows.Forms.TabPage()
        Me.grdAudit = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btn_Prepare = New System.Windows.Forms.ToolStripButton()
        Me.btn_Modify = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DsHR = New HR.dsHR()
        Me.DsHRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tbPromotions.SuspendLayout()
        CType(Me.grdPromotions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAwards.SuspendLayout()
        CType(Me.grdAwards, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbTrainings.SuspendLayout()
        CType(Me.grdSeminars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDiscipline.SuspendLayout()
        CType(Me.grdDiscipline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAudit.SuspendLayout()
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbToolbar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsHRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbPromotions)
        Me.TabControl1.Controls.Add(Me.tbAwards)
        Me.TabControl1.Controls.Add(Me.tbTrainings)
        Me.TabControl1.Controls.Add(Me.tbDiscipline)
        Me.TabControl1.Controls.Add(Me.tbAudit)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(677, 392)
        Me.TabControl1.TabIndex = 0
        '
        'tbPromotions
        '
        Me.tbPromotions.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbPromotions.Controls.Add(Me.btn_DeleteQualification)
        Me.tbPromotions.Controls.Add(Me.cmd_PreparePromotion)
        Me.tbPromotions.Controls.Add(Me.grdPromotions)
        Me.tbPromotions.Controls.Add(Me.dtpEffectiveDate)
        Me.tbPromotions.Controls.Add(Me.cbToGrade)
        Me.tbPromotions.Controls.Add(Me.cbToDesignation)
        Me.tbPromotions.Controls.Add(Me.cbFromDesignation)
        Me.tbPromotions.Controls.Add(Me.cbToType)
        Me.tbPromotions.Controls.Add(Me.txtToIncrement)
        Me.tbPromotions.Controls.Add(Me.txtFromIncrement)
        Me.tbPromotions.Controls.Add(Me.Label14)
        Me.tbPromotions.Controls.Add(Me.Label13)
        Me.tbPromotions.Controls.Add(Me.cbFromGrade)
        Me.tbPromotions.Controls.Add(Me.cbFromType)
        Me.tbPromotions.Controls.Add(Me.txtNewJobDescription)
        Me.tbPromotions.Controls.Add(Me.txtRemarks)
        Me.tbPromotions.Controls.Add(Me.Label7)
        Me.tbPromotions.Controls.Add(Me.Label2)
        Me.tbPromotions.Controls.Add(Me.Label5)
        Me.tbPromotions.Controls.Add(Me.Label11)
        Me.tbPromotions.Controls.Add(Me.Label10)
        Me.tbPromotions.Controls.Add(Me.Label9)
        Me.tbPromotions.Controls.Add(Me.Label6)
        Me.tbPromotions.Controls.Add(Me.Label4)
        Me.tbPromotions.Controls.Add(Me.Label3)
        Me.tbPromotions.Controls.Add(Me.txtEmployeeName)
        Me.tbPromotions.Controls.Add(Me.Label1)
        Me.tbPromotions.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPromotions.Location = New System.Drawing.Point(4, 25)
        Me.tbPromotions.Name = "tbPromotions"
        Me.tbPromotions.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPromotions.Size = New System.Drawing.Size(669, 363)
        Me.tbPromotions.TabIndex = 0
        Me.tbPromotions.Text = "Promotions"
        '
        'btn_DeleteQualification
        '
        Me.btn_DeleteQualification.Enabled = False
        Me.btn_DeleteQualification.Location = New System.Drawing.Point(560, 254)
        Me.btn_DeleteQualification.Name = "btn_DeleteQualification"
        Me.btn_DeleteQualification.Size = New System.Drawing.Size(85, 25)
        Me.btn_DeleteQualification.TabIndex = 72
        Me.btn_DeleteQualification.Text = "Delete"
        Me.btn_DeleteQualification.UseVisualStyleBackColor = True
        Me.btn_DeleteQualification.Visible = False
        '
        'cmd_PreparePromotion
        '
        Me.cmd_PreparePromotion.Enabled = False
        Me.cmd_PreparePromotion.Location = New System.Drawing.Point(528, 254)
        Me.cmd_PreparePromotion.Name = "cmd_PreparePromotion"
        Me.cmd_PreparePromotion.Size = New System.Drawing.Size(117, 25)
        Me.cmd_PreparePromotion.TabIndex = 64
        Me.cmd_PreparePromotion.Text = "Save Promotion"
        Me.cmd_PreparePromotion.UseVisualStyleBackColor = True
        '
        'grdPromotions
        '
        Me.grdPromotions.AllowUpdate = False
        Me.grdPromotions.CaptionHeight = 20
        Me.grdPromotions.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdPromotions.Images.Add(CType(resources.GetObject("grdPromotions.Images"), System.Drawing.Image))
        Me.grdPromotions.Location = New System.Drawing.Point(9, 285)
        Me.grdPromotions.Name = "grdPromotions"
        Me.grdPromotions.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPromotions.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPromotions.PreviewInfo.ZoomFactor = 75.0R
        Me.grdPromotions.PrintInfo.PageSettings = CType(resources.GetObject("grdPromotions.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPromotions.RowHeight = 15
        Me.grdPromotions.Size = New System.Drawing.Size(637, 72)
        Me.grdPromotions.TabIndex = 71
        Me.grdPromotions.TabStop = False
        Me.grdPromotions.PropBag = resources.GetString("grdPromotions.PropBag")
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.CustomFormat = "dd/MM/yy"
        Me.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(145, 166)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.ShowCheckBox = True
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(175, 22)
        Me.dtpEffectiveDate.TabIndex = 59
        Me.dtpEffectiveDate.Value = New Date(2015, 8, 25, 15, 57, 38, 0)
        '
        'cbToGrade
        '
        Me.cbToGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToGrade.FormattingEnabled = True
        Me.cbToGrade.Location = New System.Drawing.Point(470, 106)
        Me.cbToGrade.Name = "cbToGrade"
        Me.cbToGrade.Size = New System.Drawing.Size(175, 22)
        Me.cbToGrade.TabIndex = 56
        '
        'cbToDesignation
        '
        Me.cbToDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToDesignation.FormattingEnabled = True
        Me.cbToDesignation.Location = New System.Drawing.Point(470, 76)
        Me.cbToDesignation.Name = "cbToDesignation"
        Me.cbToDesignation.Size = New System.Drawing.Size(175, 22)
        Me.cbToDesignation.TabIndex = 53
        '
        'cbFromDesignation
        '
        Me.cbFromDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromDesignation.FormattingEnabled = True
        Me.cbFromDesignation.Location = New System.Drawing.Point(145, 76)
        Me.cbFromDesignation.Name = "cbFromDesignation"
        Me.cbFromDesignation.Size = New System.Drawing.Size(175, 22)
        Me.cbFromDesignation.TabIndex = 51
        '
        'cbToType
        '
        Me.cbToType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbToType.FormattingEnabled = True
        Me.cbToType.Location = New System.Drawing.Point(470, 46)
        Me.cbToType.Name = "cbToType"
        Me.cbToType.Size = New System.Drawing.Size(175, 22)
        Me.cbToType.TabIndex = 50
        '
        'txtToIncrement
        '
        Me.txtToIncrement.Location = New System.Drawing.Point(470, 136)
        Me.txtToIncrement.Name = "txtToIncrement"
        Me.txtToIncrement.Size = New System.Drawing.Size(175, 22)
        Me.txtToIncrement.TabIndex = 58
        Me.txtToIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFromIncrement
        '
        Me.txtFromIncrement.Location = New System.Drawing.Point(145, 136)
        Me.txtFromIncrement.Name = "txtFromIncrement"
        Me.txtFromIncrement.Size = New System.Drawing.Size(175, 22)
        Me.txtFromIncrement.TabIndex = 57
        Me.txtFromIncrement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 231)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 14)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "New Job Desc."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 14)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "Remarks"
        '
        'cbFromGrade
        '
        Me.cbFromGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromGrade.FormattingEnabled = True
        Me.cbFromGrade.Location = New System.Drawing.Point(145, 106)
        Me.cbFromGrade.Name = "cbFromGrade"
        Me.cbFromGrade.Size = New System.Drawing.Size(175, 22)
        Me.cbFromGrade.TabIndex = 55
        '
        'cbFromType
        '
        Me.cbFromType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFromType.FormattingEnabled = True
        Me.cbFromType.Location = New System.Drawing.Point(145, 46)
        Me.cbFromType.Name = "cbFromType"
        Me.cbFromType.Size = New System.Drawing.Size(175, 22)
        Me.cbFromType.TabIndex = 49
        '
        'txtNewJobDescription
        '
        Me.txtNewJobDescription.Location = New System.Drawing.Point(145, 226)
        Me.txtNewJobDescription.Name = "txtNewJobDescription"
        Me.txtNewJobDescription.Size = New System.Drawing.Size(501, 22)
        Me.txtNewJobDescription.TabIndex = 62
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(145, 196)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(500, 22)
        Me.txtRemarks.TabIndex = 60
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 14)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Effective Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(357, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 14)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "To Incr. Level"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 14)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "From Incr. Level"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(357, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 14)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "To Grade"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 14)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "From Grade"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(357, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 14)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "To Designation"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 14)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "From Designation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(357, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 14)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "To Emp Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 14)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "From Emp Type"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Enabled = False
        Me.txtEmployeeName.Location = New System.Drawing.Point(145, 16)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(175, 22)
        Me.txtEmployeeName.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 14)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Employee Name"
        '
        'tbAwards
        '
        Me.tbAwards.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAwards.Controls.Add(Me.cmd_PrepareAwards)
        Me.tbAwards.Controls.Add(Me.grdAwards)
        Me.tbAwards.Controls.Add(Me.txtEmployeeNameA)
        Me.tbAwards.Controls.Add(Me.txtAwardName)
        Me.tbAwards.Controls.Add(Me.Label12)
        Me.tbAwards.Controls.Add(Me.txtAwardDescription)
        Me.tbAwards.Controls.Add(Me.dtpAwardingDate)
        Me.tbAwards.Controls.Add(Me.Label8)
        Me.tbAwards.Controls.Add(Me.Label15)
        Me.tbAwards.Controls.Add(Me.txtAwardingAuthority)
        Me.tbAwards.Controls.Add(Me.Label16)
        Me.tbAwards.Controls.Add(Me.Label17)
        Me.tbAwards.Location = New System.Drawing.Point(4, 25)
        Me.tbAwards.Name = "tbAwards"
        Me.tbAwards.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAwards.Size = New System.Drawing.Size(669, 363)
        Me.tbAwards.TabIndex = 1
        Me.tbAwards.Text = "Awards"
        '
        'cmd_PrepareAwards
        '
        Me.cmd_PrepareAwards.Enabled = False
        Me.cmd_PrepareAwards.Location = New System.Drawing.Point(528, 108)
        Me.cmd_PrepareAwards.Name = "cmd_PrepareAwards"
        Me.cmd_PrepareAwards.Size = New System.Drawing.Size(117, 25)
        Me.cmd_PrepareAwards.TabIndex = 65
        Me.cmd_PrepareAwards.Text = "Save Awards"
        Me.cmd_PrepareAwards.UseVisualStyleBackColor = True
        '
        'grdAwards
        '
        Me.grdAwards.AllowUpdate = False
        Me.grdAwards.CaptionHeight = 20
        Me.grdAwards.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAwards.Images.Add(CType(resources.GetObject("grdAwards.Images"), System.Drawing.Image))
        Me.grdAwards.Location = New System.Drawing.Point(9, 139)
        Me.grdAwards.Name = "grdAwards"
        Me.grdAwards.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAwards.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAwards.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAwards.PrintInfo.PageSettings = CType(resources.GetObject("grdAwards.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAwards.RowHeight = 15
        Me.grdAwards.Size = New System.Drawing.Size(637, 87)
        Me.grdAwards.TabIndex = 52
        Me.grdAwards.TabStop = False
        Me.grdAwards.PropBag = resources.GetString("grdAwards.PropBag")
        '
        'txtEmployeeNameA
        '
        Me.txtEmployeeNameA.Enabled = False
        Me.txtEmployeeNameA.Location = New System.Drawing.Point(145, 20)
        Me.txtEmployeeNameA.Name = "txtEmployeeNameA"
        Me.txtEmployeeNameA.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeNameA.TabIndex = 51
        '
        'txtAwardName
        '
        Me.txtAwardName.Location = New System.Drawing.Point(470, 18)
        Me.txtAwardName.Name = "txtAwardName"
        Me.txtAwardName.Size = New System.Drawing.Size(175, 23)
        Me.txtAwardName.TabIndex = 43
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(357, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Award Name"
        '
        'txtAwardDescription
        '
        Me.txtAwardDescription.Location = New System.Drawing.Point(145, 78)
        Me.txtAwardDescription.Name = "txtAwardDescription"
        Me.txtAwardDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtAwardDescription.TabIndex = 47
        '
        'dtpAwardingDate
        '
        Me.dtpAwardingDate.CustomFormat = "dd/MM/yy"
        Me.dtpAwardingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAwardingDate.Location = New System.Drawing.Point(470, 48)
        Me.dtpAwardingDate.Name = "dtpAwardingDate"
        Me.dtpAwardingDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpAwardingDate.TabIndex = 45
        Me.dtpAwardingDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Description"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(357, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 16)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Date Awarded"
        '
        'txtAwardingAuthority
        '
        Me.txtAwardingAuthority.Location = New System.Drawing.Point(145, 48)
        Me.txtAwardingAuthority.Name = "txtAwardingAuthority"
        Me.txtAwardingAuthority.Size = New System.Drawing.Size(175, 23)
        Me.txtAwardingAuthority.TabIndex = 44
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 16)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Awarding Authority"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 16)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Employee Name"
        '
        'tbTrainings
        '
        Me.tbTrainings.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbTrainings.Controls.Add(Me.cmd_PrepareTrainings)
        Me.tbTrainings.Controls.Add(Me.grdSeminars)
        Me.tbTrainings.Controls.Add(Me.cbType)
        Me.tbTrainings.Controls.Add(Me.txtCost)
        Me.tbTrainings.Controls.Add(Me.Cost)
        Me.tbTrainings.Controls.Add(Me.cbCity)
        Me.tbTrainings.Controls.Add(Me.Label18)
        Me.tbTrainings.Controls.Add(Me.cbCountry)
        Me.tbTrainings.Controls.Add(Me.Label19)
        Me.tbTrainings.Controls.Add(Me.Label20)
        Me.tbTrainings.Controls.Add(Me.dtpStartDate)
        Me.tbTrainings.Controls.Add(Me.txtTitle)
        Me.tbTrainings.Controls.Add(Me.Label21)
        Me.tbTrainings.Controls.Add(Me.txtDescription)
        Me.tbTrainings.Controls.Add(Me.dtpEndDate)
        Me.tbTrainings.Controls.Add(Me.Label22)
        Me.tbTrainings.Controls.Add(Me.Label23)
        Me.tbTrainings.Controls.Add(Me.Label24)
        Me.tbTrainings.Controls.Add(Me.txtEmployeeNameT)
        Me.tbTrainings.Controls.Add(Me.Label25)
        Me.tbTrainings.Location = New System.Drawing.Point(4, 25)
        Me.tbTrainings.Name = "tbTrainings"
        Me.tbTrainings.Size = New System.Drawing.Size(669, 363)
        Me.tbTrainings.TabIndex = 2
        Me.tbTrainings.Text = "Trainings"
        '
        'cmd_PrepareTrainings
        '
        Me.cmd_PrepareTrainings.Enabled = False
        Me.cmd_PrepareTrainings.Location = New System.Drawing.Point(535, 195)
        Me.cmd_PrepareTrainings.Name = "cmd_PrepareTrainings"
        Me.cmd_PrepareTrainings.Size = New System.Drawing.Size(117, 25)
        Me.cmd_PrepareTrainings.TabIndex = 67
        Me.cmd_PrepareTrainings.Text = "Save Trainings"
        Me.cmd_PrepareTrainings.UseVisualStyleBackColor = True
        '
        'grdSeminars
        '
        Me.grdSeminars.AllowUpdate = False
        Me.grdSeminars.CaptionHeight = 20
        Me.grdSeminars.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdSeminars.Images.Add(CType(resources.GetObject("grdSeminars.Images"), System.Drawing.Image))
        Me.grdSeminars.Location = New System.Drawing.Point(16, 229)
        Me.grdSeminars.Name = "grdSeminars"
        Me.grdSeminars.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSeminars.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSeminars.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSeminars.PrintInfo.PageSettings = CType(resources.GetObject("grdSeminars.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSeminars.RowHeight = 15
        Me.grdSeminars.Size = New System.Drawing.Size(637, 87)
        Me.grdSeminars.TabIndex = 66
        Me.grdSeminars.TabStop = False
        Me.grdSeminars.PropBag = resources.GetString("grdSeminars.PropBag")
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Training", "Course", "Seminar"})
        Me.cbType.Location = New System.Drawing.Point(152, 46)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(175, 24)
        Me.cbType.TabIndex = 50
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(152, 136)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(175, 23)
        Me.txtCost.TabIndex = 58
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cost
        '
        Me.Cost.AutoSize = True
        Me.Cost.Location = New System.Drawing.Point(13, 141)
        Me.Cost.Name = "Cost"
        Me.Cost.Size = New System.Drawing.Size(38, 16)
        Me.Cost.TabIndex = 65
        Me.Cost.Text = "Cost"
        '
        'cbCity
        '
        Me.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCity.FormattingEnabled = True
        Me.cbCity.Location = New System.Drawing.Point(477, 106)
        Me.cbCity.Name = "cbCity"
        Me.cbCity.Size = New System.Drawing.Size(175, 24)
        Me.cbCity.TabIndex = 57
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(364, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 16)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "City*"
        '
        'cbCountry
        '
        Me.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCountry.FormattingEnabled = True
        Me.cbCountry.Location = New System.Drawing.Point(152, 106)
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Size = New System.Drawing.Size(175, 24)
        Me.cbCountry.TabIndex = 55
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 111)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 16)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Country*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 16)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = "Type*"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd/MM/yy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(152, 76)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpStartDate.TabIndex = 53
        Me.dtpStartDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(477, 46)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(175, 23)
        Me.txtTitle.TabIndex = 51
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(364, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 16)
        Me.Label21.TabIndex = 61
        Me.Label21.Text = "Title*"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(152, 166)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtDescription.TabIndex = 59
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(477, 76)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpEndDate.TabIndex = 54
        Me.dtpEndDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 171)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 16)
        Me.Label22.TabIndex = 60
        Me.Label22.Text = "Description"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(364, 81)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 16)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "End Date*"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(13, 81)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 16)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "Start Date*"
        '
        'txtEmployeeNameT
        '
        Me.txtEmployeeNameT.Enabled = False
        Me.txtEmployeeNameT.Location = New System.Drawing.Point(152, 16)
        Me.txtEmployeeNameT.Name = "txtEmployeeNameT"
        Me.txtEmployeeNameT.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeNameT.TabIndex = 49
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(13, 21)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 16)
        Me.Label25.TabIndex = 48
        Me.Label25.Text = "Employee Name*"
        '
        'tbDiscipline
        '
        Me.tbDiscipline.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbDiscipline.Controls.Add(Me.cmd_PrepareDiscipline)
        Me.tbDiscipline.Controls.Add(Me.grdDiscipline)
        Me.tbDiscipline.Controls.Add(Me.cbDisciplineType)
        Me.tbDiscipline.Controls.Add(Me.Label26)
        Me.tbDiscipline.Controls.Add(Me.txtDisciplineDescription)
        Me.tbDiscipline.Controls.Add(Me.dtpDate)
        Me.tbDiscipline.Controls.Add(Me.Label27)
        Me.tbDiscipline.Controls.Add(Me.Label28)
        Me.tbDiscipline.Controls.Add(Me.txtEmployeeNameD)
        Me.tbDiscipline.Controls.Add(Me.Label29)
        Me.tbDiscipline.Location = New System.Drawing.Point(4, 25)
        Me.tbDiscipline.Name = "tbDiscipline"
        Me.tbDiscipline.Size = New System.Drawing.Size(669, 363)
        Me.tbDiscipline.TabIndex = 3
        Me.tbDiscipline.Text = "Discipline"
        '
        'cmd_PrepareDiscipline
        '
        Me.cmd_PrepareDiscipline.Enabled = False
        Me.cmd_PrepareDiscipline.Location = New System.Drawing.Point(535, 114)
        Me.cmd_PrepareDiscipline.Name = "cmd_PrepareDiscipline"
        Me.cmd_PrepareDiscipline.Size = New System.Drawing.Size(117, 25)
        Me.cmd_PrepareDiscipline.TabIndex = 68
        Me.cmd_PrepareDiscipline.Text = "Save Discipline"
        Me.cmd_PrepareDiscipline.UseVisualStyleBackColor = True
        '
        'grdDiscipline
        '
        Me.grdDiscipline.AllowUpdate = False
        Me.grdDiscipline.CaptionHeight = 20
        Me.grdDiscipline.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdDiscipline.Images.Add(CType(resources.GetObject("grdDiscipline.Images"), System.Drawing.Image))
        Me.grdDiscipline.Location = New System.Drawing.Point(16, 145)
        Me.grdDiscipline.Name = "grdDiscipline"
        Me.grdDiscipline.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDiscipline.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDiscipline.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDiscipline.PrintInfo.PageSettings = CType(resources.GetObject("grdDiscipline.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDiscipline.RowHeight = 15
        Me.grdDiscipline.Size = New System.Drawing.Size(637, 87)
        Me.grdDiscipline.TabIndex = 49
        Me.grdDiscipline.TabStop = False
        Me.grdDiscipline.PropBag = resources.GetString("grdDiscipline.PropBag")
        '
        'cbDisciplineType
        '
        Me.cbDisciplineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDisciplineType.FormattingEnabled = True
        Me.cbDisciplineType.Items.AddRange(New Object() {"Warning", "Show Cause", "Explanation", "Advice"})
        Me.cbDisciplineType.Location = New System.Drawing.Point(152, 55)
        Me.cbDisciplineType.Name = "cbDisciplineType"
        Me.cbDisciplineType.Size = New System.Drawing.Size(175, 24)
        Me.cbDisciplineType.TabIndex = 44
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(364, 30)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 16)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "Date"
        '
        'txtDisciplineDescription
        '
        Me.txtDisciplineDescription.Location = New System.Drawing.Point(152, 85)
        Me.txtDisciplineDescription.Name = "txtDisciplineDescription"
        Me.txtDisciplineDescription.Size = New System.Drawing.Size(500, 23)
        Me.txtDisciplineDescription.TabIndex = 45
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(408, 26)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.ShowCheckBox = True
        Me.dtpDate.Size = New System.Drawing.Size(175, 23)
        Me.dtpDate.TabIndex = 43
        Me.dtpDate.Value = New Date(2015, 9, 10, 0, 0, 0, 0)
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(13, 90)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 16)
        Me.Label27.TabIndex = 47
        Me.Label27.Text = "Remarks"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(13, 60)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(40, 16)
        Me.Label28.TabIndex = 46
        Me.Label28.Text = "Type"
        '
        'txtEmployeeNameD
        '
        Me.txtEmployeeNameD.Enabled = False
        Me.txtEmployeeNameD.Location = New System.Drawing.Point(152, 25)
        Me.txtEmployeeNameD.Name = "txtEmployeeNameD"
        Me.txtEmployeeNameD.Size = New System.Drawing.Size(175, 23)
        Me.txtEmployeeNameD.TabIndex = 42
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(13, 30)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(111, 16)
        Me.Label29.TabIndex = 41
        Me.Label29.Text = "Employee Name"
        '
        'tbAudit
        '
        Me.tbAudit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbAudit.Controls.Add(Me.grdAudit)
        Me.tbAudit.Location = New System.Drawing.Point(4, 25)
        Me.tbAudit.Name = "tbAudit"
        Me.tbAudit.Size = New System.Drawing.Size(669, 363)
        Me.tbAudit.TabIndex = 4
        Me.tbAudit.Text = "Audit"
        '
        'grdAudit
        '
        Me.grdAudit.AllowUpdate = False
        Me.grdAudit.CaptionHeight = 20
        Me.grdAudit.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdAudit.Images.Add(CType(resources.GetObject("grdAudit.Images"), System.Drawing.Image))
        Me.grdAudit.Location = New System.Drawing.Point(3, 0)
        Me.grdAudit.Name = "grdAudit"
        Me.grdAudit.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAudit.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAudit.PreviewInfo.ZoomFactor = 75.0R
        Me.grdAudit.PrintInfo.PageSettings = CType(resources.GetObject("grdAudit.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAudit.RowHeight = 15
        Me.grdAudit.Size = New System.Drawing.Size(663, 314)
        Me.grdAudit.TabIndex = 36
        Me.grdAudit.TabStop = False
        Me.grdAudit.PropBag = resources.GetString("grdAudit.PropBag")
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Prepare, Me.btn_Modify, Me.btnSearch, Me.btn_Delete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(692, 25)
        Me.tlbToolbar.TabIndex = 7
        Me.tlbToolbar.Text = "tlbTop"
        '
        'btn_Prepare
        '
        Me.btn_Prepare.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Prepare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Prepare.Image = Global.HR.My.Resources.Resources._NEW
        Me.btn_Prepare.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Prepare.Name = "btn_Prepare"
        Me.btn_Prepare.Size = New System.Drawing.Size(23, 22)
        Me.btn_Prepare.Text = "New"
        '
        'btn_Modify
        '
        Me.btn_Modify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Modify.Enabled = False
        Me.btn_Modify.Image = Global.HR.My.Resources.Resources.SAVE
        Me.btn_Modify.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Modify.Name = "btn_Modify"
        Me.btn_Modify.Size = New System.Drawing.Size(23, 22)
        Me.btn_Modify.Text = "Save"
        Me.btn_Modify.Visible = False
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
        'btn_Delete
        '
        Me.btn_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Delete.Enabled = False
        Me.btn_Delete.Image = Global.HR.My.Resources.Resources.DELETE
        Me.btn_Delete.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(23, 22)
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(670, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'DsHR
        '
        Me.DsHR.DataSetName = "dsHR"
        Me.DsHR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsHRBindingSource
        '
        Me.DsHRBindingSource.DataSource = Me.DsHR
        Me.DsHRBindingSource.Position = 0
        '
        'frmAppraisals_Discipline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmAppraisals_Discipline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Appraisals_Discipline"
        Me.TabControl1.ResumeLayout(False)
        Me.tbPromotions.ResumeLayout(False)
        Me.tbPromotions.PerformLayout()
        CType(Me.grdPromotions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAwards.ResumeLayout(False)
        Me.tbAwards.PerformLayout()
        CType(Me.grdAwards, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbTrainings.ResumeLayout(False)
        Me.tbTrainings.PerformLayout()
        CType(Me.grdSeminars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDiscipline.ResumeLayout(False)
        Me.tbDiscipline.PerformLayout()
        CType(Me.grdDiscipline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAudit.ResumeLayout(False)
        CType(Me.grdAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsHR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsHRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbPromotions As TabPage
    Friend WithEvents tbAwards As TabPage
    Friend WithEvents tbTrainings As TabPage
    Friend WithEvents tbDiscipline As TabPage
    Friend WithEvents dtpEffectiveDate As DateTimePicker
    Friend WithEvents cbToGrade As ComboBox
    Friend WithEvents cbToDesignation As ComboBox
    Friend WithEvents cbFromDesignation As ComboBox
    Friend WithEvents cbToType As ComboBox
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
    Friend WithEvents txtAwardName As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAwardDescription As TextBox
    Friend WithEvents dtpAwardingDate As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAwardingAuthority As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents cbType As ComboBox
    Friend WithEvents txtCost As TextBox
    Friend WithEvents Cost As Label
    Friend WithEvents cbCity As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cbCountry As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtEmployeeNameT As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cbDisciplineType As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtDisciplineDescription As TextBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtEmployeeNameD As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtEmployeeNameA As TextBox
    Friend WithEvents tbAudit As TabPage
    Private WithEvents grdPromotions As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdAwards As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSeminars As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdDiscipline As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdAudit As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents DsHR As dsHR
    Friend WithEvents DsHRBindingSource As BindingSource
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btn_Prepare As ToolStripButton
    Friend WithEvents btn_Modify As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btn_Delete As ToolStripButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmd_PreparePromotion As Button
    Friend WithEvents cmd_PrepareAwards As Button
    Friend WithEvents cmd_PrepareTrainings As Button
    Friend WithEvents cmd_PrepareDiscipline As Button
    Friend WithEvents btn_DeleteQualification As Button
End Class
