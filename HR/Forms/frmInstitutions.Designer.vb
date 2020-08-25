<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstitutions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstitutions))
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.grdInstitution = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtInstitution = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.btn_Prepare = New System.Windows.Forms.ToolStripButton()
        Me.btn_Modify = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        CType(Me.grdInstitution, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(12, 37)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(484, 341)
        Me.tbJobInformation.TabIndex = 9
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.grdInstitution)
        Me.tbQualifications.Controls.Add(Me.txtInstitution)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(476, 312)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Detail"
        '
        'grdInstitution
        '
        Me.grdInstitution.AllowUpdate = False
        Me.grdInstitution.CaptionHeight = 20
        Me.grdInstitution.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdInstitution.Images.Add(CType(resources.GetObject("grdInstitution.Images"), System.Drawing.Image))
        Me.grdInstitution.Location = New System.Drawing.Point(6, 38)
        Me.grdInstitution.Name = "grdInstitution"
        Me.grdInstitution.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdInstitution.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdInstitution.PreviewInfo.ZoomFactor = 75.0R
        Me.grdInstitution.PrintInfo.PageSettings = CType(resources.GetObject("grdInstitution.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdInstitution.RowHeight = 15
        Me.grdInstitution.Size = New System.Drawing.Size(465, 268)
        Me.grdInstitution.TabIndex = 16
        Me.grdInstitution.TabStop = False
        Me.grdInstitution.PropBag = resources.GetString("grdInstitution.PropBag")
        '
        'txtInstitution
        '
        Me.txtInstitution.Location = New System.Drawing.Point(140, 8)
        Me.txtInstitution.Name = "txtInstitution"
        Me.txtInstitution.Size = New System.Drawing.Size(322, 23)
        Me.txtInstitution.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Institution Name"
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Prepare, Me.btn_Modify, Me.btnSearch, Me.btn_Delete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(506, 25)
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
        'frmInstitutions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 390)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Name = "frmInstitutions"
        Me.Text = "Institutions"
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        CType(Me.grdInstitution, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbJobInformation As TabControl
    Friend WithEvents tbQualifications As TabPage
    Friend WithEvents grdInstitution As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtInstitution As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tlbToolbar As ToolStrip
    Friend WithEvents btn_Prepare As ToolStripButton
    Friend WithEvents btn_Modify As ToolStripButton
    Friend WithEvents btnSearch As ToolStripButton
    Friend WithEvents btn_Delete As ToolStripButton
End Class
