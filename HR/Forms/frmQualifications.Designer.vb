<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQualifications
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQualifications))
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.txtQualificationName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btn_Prepare = New System.Windows.Forms.ToolStripButton()
        Me.btn_Modify = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton()
        Me.grdQualifications = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        Me.tlbToolbar.SuspendLayout()
        CType(Me.grdQualifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(12, 42)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(447, 381)
        Me.tbJobInformation.TabIndex = 9
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.grdQualifications)
        Me.tbQualifications.Controls.Add(Me.txtQualificationName)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(439, 352)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Detail"
        '
        'txtQualificationName
        '
        Me.txtQualificationName.Location = New System.Drawing.Point(140, 8)
        Me.txtQualificationName.Name = "txtQualificationName"
        Me.txtQualificationName.Size = New System.Drawing.Size(288, 23)
        Me.txtQualificationName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Qualification Name"
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Prepare, Me.btn_Modify, Me.btnSearch, Me.btn_Delete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(468, 25)
        Me.tlbToolbar.TabIndex = 10
        Me.tlbToolbar.Text = "tlbTop"
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
        Me.btn_Delete.Enabled = False
        Me.btn_Delete.Image = Global.HR.My.Resources.Resources.DELETE
        Me.btn_Delete.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(23, 22)
        Me.btn_Delete.Text = "Delete"
        '
        'grdQualifications
        '
        Me.grdQualifications.AllowUpdate = False
        Me.grdQualifications.CaptionHeight = 20
        Me.grdQualifications.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdQualifications.Images.Add(CType(resources.GetObject("grdQualifications.Images"), System.Drawing.Image))
        Me.grdQualifications.Location = New System.Drawing.Point(6, 38)
        Me.grdQualifications.Name = "grdQualifications"
        Me.grdQualifications.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdQualifications.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdQualifications.PreviewInfo.ZoomFactor = 75.0R
        Me.grdQualifications.PrintInfo.PageSettings = CType(resources.GetObject("grdQualifications.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdQualifications.RowHeight = 15
        Me.grdQualifications.Size = New System.Drawing.Size(422, 293)
        Me.grdQualifications.TabIndex = 16
        Me.grdQualifications.TabStop = False
        Me.grdQualifications.ViewCaptionWidth = 120
        Me.grdQualifications.PropBag = resources.GetString("grdQualifications.PropBag")
        '
        'frmQualifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 425)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Name = "frmQualifications"
        Me.Text = "Qualifications"
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        CType(Me.grdQualifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents tbQualifications As TabPage
    Friend WithEvents grdQualifications As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtQualificationName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btn_Prepare As ToolStripButton
    Friend WithEvents btn_Modify As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btn_Delete As ToolStripButton
End Class
