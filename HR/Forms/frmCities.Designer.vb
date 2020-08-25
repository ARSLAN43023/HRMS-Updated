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
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCountry = New System.Windows.Forms.ComboBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grdCities = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btn_Prepare = New System.Windows.Forms.ToolStripButton()
        Me.btn_Modify = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton()
        Me.tlbToolbar.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        Me.stbDetail.SuspendLayout()
        CType(Me.grdCities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Prepare, Me.btn_Modify, Me.btnSearch, Me.btn_Delete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(515, 25)
        Me.tlbToolbar.TabIndex = 7
        Me.tlbToolbar.Text = "tlbTop"
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
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
        Me.grdCities.RowHeight = 15
        Me.grdCities.Size = New System.Drawing.Size(494, 226)
        Me.grdCities.TabIndex = 16
        Me.grdCities.TabStop = False
        Me.grdCities.PropBag = resources.GetString("grdCities.PropBag")
        '
        'btn_Prepare
        '
        Me.btn_Prepare.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Prepare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Prepare.Enabled = False
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
        Me.btn_Delete.Image = Global.HR.My.Resources.Resources.DELETE
        Me.btn_Delete.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(23, 22)
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.Visible = False
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
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        CType(Me.grdCities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btn_Prepare As ToolStripButton
    Friend WithEvents btn_Modify As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btn_Delete As ToolStripButton
    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents tbQualifications As TabPage
    Friend WithEvents txtCity As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCountry As ComboBox
    Private WithEvents grdCities As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
