﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCountries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCountries))
        Me.tlbToolbar = New System.Windows.Forms.ToolStrip()
        Me.tbJobInformation = New System.Windows.Forms.TabControl()
        Me.tbQualifications = New System.Windows.Forms.TabPage()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbDetail = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grdCountries = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btn_Prepare = New System.Windows.Forms.ToolStripButton()
        Me.btn_Modify = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btn_Delete = New System.Windows.Forms.ToolStripButton()
        Me.tlbToolbar.SuspendLayout()
        Me.tbJobInformation.SuspendLayout()
        Me.tbQualifications.SuspendLayout()
        Me.stbDetail.SuspendLayout()
        CType(Me.grdCountries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlbToolbar
        '
        Me.tlbToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Prepare, Me.btn_Modify, Me.btnSearch, Me.btn_Delete})
        Me.tlbToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tlbToolbar.Name = "tlbToolbar"
        Me.tlbToolbar.Size = New System.Drawing.Size(307, 25)
        Me.tlbToolbar.TabIndex = 6
        Me.tlbToolbar.Text = "tlbTop"
        '
        'tbJobInformation
        '
        Me.tbJobInformation.Controls.Add(Me.tbQualifications)
        Me.tbJobInformation.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbJobInformation.Location = New System.Drawing.Point(4, 27)
        Me.tbJobInformation.Name = "tbJobInformation"
        Me.tbJobInformation.SelectedIndex = 0
        Me.tbJobInformation.Size = New System.Drawing.Size(299, 299)
        Me.tbJobInformation.TabIndex = 8
        '
        'tbQualifications
        '
        Me.tbQualifications.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tbQualifications.Controls.Add(Me.grdCountries)
        Me.tbQualifications.Controls.Add(Me.txtCountry)
        Me.tbQualifications.Controls.Add(Me.Label1)
        Me.tbQualifications.Location = New System.Drawing.Point(4, 25)
        Me.tbQualifications.Name = "tbQualifications"
        Me.tbQualifications.Padding = New System.Windows.Forms.Padding(3)
        Me.tbQualifications.Size = New System.Drawing.Size(291, 270)
        Me.tbQualifications.TabIndex = 1
        Me.tbQualifications.Text = "Detail"
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(111, 8)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(175, 23)
        Me.txtCountry.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Country Name"
        '
        'stbDetail
        '
        Me.stbDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.stbDetail.Location = New System.Drawing.Point(0, 329)
        Me.stbDetail.Name = "stbDetail"
        Me.stbDetail.Size = New System.Drawing.Size(307, 22)
        Me.stbDetail.TabIndex = 9
        Me.stbDetail.Text = "Hello"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(0, 17)
        '
        'grdCountries
        '
        Me.grdCountries.AllowUpdate = False
        Me.grdCountries.CaptionHeight = 20
        Me.grdCountries.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.grdCountries.Images.Add(CType(resources.GetObject("grdCountries.Images"), System.Drawing.Image))
        Me.grdCountries.Location = New System.Drawing.Point(6, 38)
        Me.grdCountries.Name = "grdCountries"
        Me.grdCountries.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCountries.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCountries.PreviewInfo.ZoomFactor = 75.0R
        Me.grdCountries.PrintInfo.PageSettings = CType(resources.GetObject("grdCountries.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCountries.RowHeight = 15
        Me.grdCountries.Size = New System.Drawing.Size(279, 226)
        Me.grdCountries.TabIndex = 16
        Me.grdCountries.TabStop = False
        Me.grdCountries.PropBag = resources.GetString("grdCountries.PropBag")
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
        'frmCountries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 351)
        Me.Controls.Add(Me.stbDetail)
        Me.Controls.Add(Me.tbJobInformation)
        Me.Controls.Add(Me.tlbToolbar)
        Me.Name = "frmCountries"
        Me.Text = "Countries"
        Me.tlbToolbar.ResumeLayout(False)
        Me.tlbToolbar.PerformLayout()
        Me.tbJobInformation.ResumeLayout(False)
        Me.tbQualifications.ResumeLayout(False)
        Me.tbQualifications.PerformLayout()
        Me.stbDetail.ResumeLayout(False)
        Me.stbDetail.PerformLayout()
        CType(Me.grdCountries, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents grdCountries As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtCountry As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents stbDetail As StatusStrip
    Friend WithEvents slStatus As ToolStripStatusLabel
End Class
