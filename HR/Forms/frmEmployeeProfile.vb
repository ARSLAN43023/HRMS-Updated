Imports System.Data.Odbc
Imports System.IO
Imports System.Text.RegularExpressions
Imports C1.Win.C1TrueDBGrid
Imports System
Imports System.Net.Mail
Imports System.Net
Imports System.Data.SqlClient
Imports System.Data.Sql


Imports System.Net.Security

Imports System.Security.Cryptography.X509Certificates
Imports System.Data.OleDb

Public Class frmEmployeeProfile
    Public rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim nDependentId As Integer
    Dim nJobId As Integer
    Dim nQualificationId As Integer
    Dim bNewImage As Boolean
    Dim rsMisc As New ADODB.Recordset
    Public sUserId As String
    Dim nEmployeeId As Integer = Nothing
    Dim nBankAccountId As Integer = Nothing
    Dim PreviousTab As New TabPage
    Dim CurrentTab As New TabPage
    Dim sBranch As String
    Dim sDesignation As String
    Dim sDepartment As String
    Dim bEmail As Boolean
    Dim fromsBranch As String
    Dim fromsDepartment As String
    Dim fromsDesignation As String
    Dim nIncrementId As Integer
    Public ConnectionExcelString As String = "Dsn=ERP;uid=sa"


    Private Shared Function customCertValidation(ByVal sender As Object,
                                                ByVal cert As X509Certificate,
                                                ByVal chain As X509Chain,
                                                ByVal errors As SslPolicyErrors) As Boolean

        Return True

    End Function
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmEmployeeProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = frmMdiMain
        Me.BringToFront()
        Me.Visible = True
        Me.Refresh()

        ''''''''''''''''''''''''''''''''''''''''
        TabControl1.TabPages(1).Text = IIf(g_nCompanyId = 1, "FCCL Info", "ACL Info")
        chkOtherCompEmp.Text = IIf(g_nCompanyId = 1, "Is ACL Employee", "Is FCCL Employee")
        g_sIsOtherCmpany = chkOtherCompEmp.Text
        '''''''''''''''''''''''''''''''''''''''

        For Each ctrl In Me.Controls
            ctrl.refresh()
        Next
        'Me.EM_Employee_AuditTableAdapter.Fill(Me.DsHR.EM_Employee_Audit)
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Me.Location = New Point(0, 0)

        TabControl1.TabPages(0).Enabled = False
        TabControl1.TabPages(1).Enabled = False
        TabControl1.TabPages(2).Enabled = False
        TabControl1.TabPages(3).Enabled = False
        TabControl1.TabPages(4).Enabled = False
        TabControl1.TabPages(5).Enabled = False
        TabControl1.TabPages(6).Enabled = False
        TabControl1.TabPages(7).Enabled = False
        'TabControl1.TabPages(8).Enabled = False
        TabControl1.TabPages.Remove(tbAudit)
        TabControl1.TabPages(0).AutoScroll = True


        ''TODO: This line of code loads data into the 'DsHR.EM_Employee_Audit' table. You can move, or remove it, as needed.
        'Me.EM_Employee_AuditTableAdapter.Fill(Me.DsHR.EM_Employee_Audit)
        'TODO: This line of code loads data into the 'DsFCCL.EM_Employee_Audit' table. You can move, or remove it, as needed.

        UserRights(rsMisc)
        PopulateControls()
        Clear()


    End Sub

    Public Sub UserRights(ByRef rsMisc As ADODB.Recordset)

        Dim sSql As String
        Dim Button As String
        Dim TabControlRights As String

        Try

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

            'sSql = "Select vcUserId from comAccessRights"
            'rsMain.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
            'g_sUserId = Convert.ToString(rsMain("vcUserId").Value)

            'sSql = "Select a.nActionId, a.vcName,a.vcDocType, b.vcUserId from ComActionCodes a, ComAccessRights b " &
            '   "Where a.nActionId = b.nActionId And a.vcDocType = b.vcDocId And " &
            '   "b.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "'  And a.vcDocType = 'emsEmployee'"
            'GetRecordSet(rsMisc, sSql)


            'sSql = "Select comActionCodes.vcName From ComAccessRights, comDocTypes, comActionCodes,ComUserGroups " &
            '        "Where comDocTypes.vcDocType = comActionCodes.vcDocType And comActionCodes.vcDocType = ComAccessRights.vcDocId And " &
            '        "comActionCodes.nActionId = ComAccessRights.nActionId And ComAccessRights.vcDocId = 'emsEmployee' " &
            '        " And ComAccessRights.nGroupId = 0  And ComAccessRights.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "'"
            'GetRecordSet(rsMisc, sSql)


            sSql = "Select vcName, nGroupId, vcUserId,nActionId From((Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId,comActionCodes.nActionId From ComAccessRights, comActionCodes, ComUserGroups " &
                        " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                        "And comActionCodes.nActionId = ComAccessRights.nActionId " &
                        " And ComAccessRights.vcDocId ='emsEmployee' " &
                        "And ComUserGroups.nGroupId = ComAccessRights.nGroupId " &
                        "And ComUserGroups.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "') " &
                        " Union (Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId,comActionCodes.nActionId " &
                        " From ComAccessRights, comActionCodes " &
                        " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                        " And comActionCodes.nActionId = ComAccessRights.nActionId And " &
                        "ComAccessRights.nGroupId = 0  " &
                        " And ComAccessRights.vcDocId ='emsEmployee' " &
                        " And ComAccessRights.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "')) g Order by nActionId  "
            GetRecordSet(rsMisc, sSql)

            While Not rsMisc.EOF

                Button = "btn_" & rsMisc("vcName").Value
                ' Button = "cmd_" & rsMisc("vcName").Value
                TabControlRights = "tb" & rsMisc("vcName").Value
                If Button = "btn_Prepare" Then
                    btn_Prepare.Enabled = True
                    cmd_CreateExperience.Enabled = True
                ElseIf Button = "btn_Modify" Then
                    btn_Modify.Enabled = True
                    cmd_PrepareExperience.Enabled = True
                    cmd_PrepareQualifications.Enabled = True
                    cmd_PrepareExperience.Enabled = True
                    cmd_SaveBankAccount.Enabled = True
                    cmd_SaveDependent.Enabled = True
                ElseIf Button = "btn_Delete" Then
                    btn_Delete.Enabled = True
                ElseIf Button = "btn_Delete Experience" Then
                    btn_DeleteExperience.Enabled = True
                ElseIf Button = "btn_Delete Qualification" Then
                    btn_DeleteQualification.Enabled = True
                ElseIf Button = "btn_Delete Dependent" Then
                    btn_DeleteDependent.Enabled = True
                ElseIf Button = "btn_Verify" Then
                    btn_Verify.Enabled = True
                ElseIf Button = "btn_Approve" Then
                    btn_Approve.Enabled = True
                ElseIf Button = "btn_Increment" Then
                    btn_Increment.Enabled = True
                ElseIf TabControlRights = "tbPersonal" Then
                    TabControl1.TabPages(0).Enabled = True
                ElseIf TabControlRights = "tbFCCL" Then
                    TabControl1.TabPages(1).Enabled = True
                ElseIf TabControlRights = "tbExperience" Then
                    TabControl1.TabPages(2).Enabled = True
                ElseIf TabControlRights = "tbQualifications" Then
                    TabControl1.TabPages(3).Enabled = True
                ElseIf TabControlRights = "tbContacts" Then
                    TabControl1.TabPages(4).Enabled = True
                ElseIf TabControlRights = "tbDependents" Then
                    TabControl1.TabPages(5).Enabled = True
                ElseIf TabControlRights = "tbBank Account" Then
                    TabControl1.TabPages(6).Enabled = True
                ElseIf TabControlRights = "tbMisc" Then
                    TabControl1.TabPages(7).Enabled = True
                End If

                rsMisc.MoveNext()
            End While
            TabControl1.TabPages.Add(tbAudit)
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub



    Private Sub PopulateControls()
        ' Personal Tab
        PopulateControl(cbNationality, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbBirthCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbReligion, "Select Id, Description From HR_PRMParameters Where Type = 7 Order by Description", "Id", "Description")
        PopulateControl(cbBloodGroup, "Select Distinct '1' Id, 'A+' Description From HR_PRMParameters UNION Select Distinct '2' Id, 'A-' Description From HR_PRMParameters UNION Select Distinct '3' Id, 'B+' Description From HR_PRMParameters UNION Select Distinct '4' Id, 'B-' Description From HR_PRMParameters UNION Select Distinct '5' Id, 'O+' Description From HR_PRMParameters UNION Select Distinct '6' Id, 'O-' Description From HR_PRMParameters UNION Select Distinct '7' Id, 'AB+' Description From HR_PRMParameters UNION Select Distinct '8' Id, 'AB-' Description From HR_PRMParameters", "Id", "Description")
        dtpDOB.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpStatusSince.Value = CDate(Date.Now.ToString("dd MMM yyyy"))

        ' FCCL Tab
        PopulateControl(cbBusinessUnit, "Select Id, OrganizationName From HR_PRMBusinessUnit", "Id", "OrganizationName")
        PopulateControl(cbBranch, "Select Id, BranchName From HR_PRMBranch", "Id", "BranchName")
        PopulateControl(cbDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbEmployeeType, "Select Id, Description From HR_PRMParameters Where Type = 3 And Id <> 820 Order by Description", "Id", "Description")
        PopulateControl(cbGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")
        PopulateControl(cbJoinedAs, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbRank, "Select Id, Description From HR_PRMParameters Where Type = 27 Order by Description", "Id", "Description")
        PopulateControl(cbCorps, "Select Id, Description From HR_PRMParameters Where Type = 30 Order by Description", "Id", "Description")

        'Contacts Tab
        PopulateControl(cbPresentCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbPermanentCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")

        'Miscellaneous Tab
        PopulateControl(cbDomicile, "Select Id, Description From HR_PRMParameters Where Type = 26 Order by Description", "Id", "Description")
        PopulateControl(cbPassportCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")

        'Experience Tab
        PopulateControl(cbExperienceCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")

        'Qualifications Tab
        PopulateControl(cbQualificationCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbQualificationDegree, "Select Id, Description From HR_PRMParameters Where Type = 8 Order by Description", "Id", "Description")
        PopulateControl(cbQualificationInstitution, "Select Id, Description From HR_PRMParameters Where Type = 9 Order by Description", "Id", "Description")

        'BankAccount Tab

        PopulateControl(cbBank, "Select Id, Description From HR_PRMBank Order by Description", "Id", "Description")
        PopulateControl(cbSection, "Select nSectionId, vcSectionName From EM_Section Order by vcSectionName", "nSectionId", "vcSectionName")
    End Sub

    Private Sub cbQualificationCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQualificationCountry.SelectedIndexChanged
        PopulateControl(cbQualificationCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbQualificationCountry.SelectedValue), 969, cbQualificationCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub cbExperienceCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExperienceCountry.SelectedIndexChanged
        PopulateControl(cbExperienceCity, "Select Id, Description From HR_PRMCity Where CountryId = " & IIf(IsNothing(cbExperienceCountry.SelectedValue), 969, cbExperienceCountry.SelectedValue).ToString() & " Order by Description", "Id", "Description")
    End Sub

    Private Sub cbBirthCountry_SelectIndexChanged(sender As Object, e As EventArgs) Handles cbBirthCountry.SelectedIndexChanged
        PopulateControl(cbBirthCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbBirthCountry.SelectedValue), 969, cbBirthCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        'Personal Tab
        PopulateControl(cbSection, "Select nSectionId, vcSectionName From EM_Section Order by vcSectionName", "nSectionId", "vcSectionName")
        txtEmpID.Text = ""
        txtEmpID.Tag = ""
        txtEmployeeNo.Text = ""
        txtEmployeeNo.Tag = ""
        txtEmployeeNo.Enabled = True
        txtOldEmpNo.Text = ""
        txtFirstName.Text = ""
        txtFirstName.Tag = ""
        txtMiddleName.Text = ""
        txtMiddleName.Tag = ""
        txtLastName.Text = ""
        txtLastName.Tag = ""
        txtFatherName.Text = ""
        txtFatherName.Tag = ""
        cbGender.SelectedIndex = -1
        cbGender.Tag = cbGender.SelectedIndex
        cbReligion.SelectedIndex = -1
        cbReligion.Tag = cbReligion.SelectedIndex
        cbNationality.SelectedIndex = -1
        cbNationality.Tag = cbNationality.SelectedIndex
        dtpDOB.Checked = False
        dtpDOB.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDOB.Tag = dtpDOB.Value
        cbBirthCountry.SelectedIndex = -1
        cbBirthCountry.Tag = cbBirthCountry.SelectedIndex
        cbBirthCity.SelectedIndex = -1
        cbBirthCity.Tag = cbBirthCity.SelectedIndex
        cbMaritalStatus.SelectedIndex = -1
        cbMaritalStatus.Tag = cbMaritalStatus.SelectedIndex
        dtpStatusSince.Checked = False
        dtpStatusSince.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpStatusSince.Tag = dtpStatusSince.Value
        cbBloodGroup.SelectedIndex = -1
        cbBloodGroup.Tag = cbBloodGroup.SelectedIndex
        pbEmployeePhoto.Image = Nothing
        pbEmployeePhoto.Tag = Nothing
        nStatus = 0
        bNewImage = False

        'FCCL Tab
        cbBusinessUnit.SelectedIndex = -1
        cbBusinessUnit.Tag = cbBusinessUnit.SelectedIndex
        cbBranch.SelectedIndex = -1
        cbBranch.Tag = cbBranch.SelectedIndex
        cbSection.SelectedIndex = -1
        cbSection.Tag = cbSection.SelectedIndex
        cbDepartment.SelectedIndex = -1
        cbDepartment.Tag = cbDepartment.SelectedIndex
        cbDesignation.SelectedIndex = -1
        cbDesignation.Tag = cbDesignation.SelectedIndex
        cbJoinedAs.SelectedIndex = -1
        cbJoinedAs.Tag = cbJoinedAs.SelectedIndex
        dtpJoiningDate.Checked = False
        dtpJoiningDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpJoiningDate.Tag = dtpJoiningDate.Value
        cbContractType.SelectedIndex = -1
        cbContractType.Tag = cbContractType.SelectedIndex
        dtpContractStartDate.Checked = False
        dtpContractStartDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpContractStartDate.Tag = dtpContractStartDate.Value
        dtpContractEndDate.Checked = False
        dtpContractEndDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpContractEndDate.Tag = dtpContractEndDate.Value
        dtpProbationEndDate.Checked = False
        dtpProbationEndDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpProbationEndDate.Tag = dtpProbationEndDate.Value
        dtpConfirmationDate.Checked = False
        dtpConfirmationDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpConfirmationDate.Tag = dtpConfirmationDate.Value
        dtpRetirementDate.Checked = False
        dtpRetirementDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpRetirementDate.Tag = dtpRetirementDate.Value
        cbEmployeeType.SelectedIndex = -1
        cbEmployeeType.Tag = cbEmployeeType.SelectedIndex
        cbGrade.SelectedIndex = -1
        cbGrade.Tag = cbGrade.SelectedIndex
        dtpGradeEffectiveDate.Checked = False
        dtpGradeEffectiveDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpGradeEffectiveDate.Tag = dtpGradeEffectiveDate.Value
        chkIsTechnical.Checked = False
        chkIsTechnical.Tag = chkIsTechnical.Checked
        chkIsHOD.Checked = False
        chkIsHOD.Tag = chkIsHOD.Checked
        txtHOD.Text = ""
        txtHOD.Tag = ""
        txtHOD.Enabled = True
        txtJobDescription.Text = ""
        txtJobDescription.Tag = ""
        chkIsMilitaryPersonnel.Checked = False
        chkIsMilitaryPersonnel.Tag = chkIsMilitaryPersonnel.Checked
        cbRank.SelectedIndex = -1
        cbRank.Tag = cbRank.SelectedIndex
        dtpDateRetired.Checked = False
        dtpDateRetired.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDateRetired.Tag = dtpDateRetired.Value
        txtTradeAppointment.Text = ""
        txtTradeAppointment.Tag = ""
        cbCorps.SelectedIndex = -1
        cbCorps.Tag = cbCorps.SelectedIndex
        chkConfYes.Checked = False
        chkConfNo.Checked = False
        ChkLFAYes.Checked = False
        chkLFANo.Checked = False
        chkOtherCompEmp.Checked = False

        'Contacts Tab
        txtPresentAddress.Text = ""
        txtPresentAddress.Tag = ""
        cbPresentCountry.SelectedIndex = -1
        cbPresentCountry.Tag = cbPresentCountry.SelectedIndex
        txtPresentPhone.Text = ""
        txtPresentPhone.Tag = ""
        txtPresentMobile.Text = ""
        txtPresentMobile.Tag = ""
        txtPermanentAddress.Text = ""
        txtPermanentAddress.Tag = ""
        cbPermanentCountry.SelectedIndex = -1
        cbPermanentCountry.Tag = cbPermanentCountry.SelectedIndex
        txtPermanentPhone.Text = ""
        txtPermanentPhone.Tag = ""
        txtPersonalEmail.Text = ""
        txtPersonalEmail.Tag = ""
        txtOfficialEmail.Text = ""
        txtOfficialEmail.Tag = ""

        'Miscellaneous Tab
        txtCNICOld.Text = ""
        txtCNICOld.Tag = ""
        txtCNICNew.Text = ""
        txtCNICNew.Tag = ""
        txtNTN.Text = ""
        txtNTN.Tag = ""
        cbDomicile.SelectedIndex = -1
        cbDomicile.Tag = cbDomicile.SelectedIndex
        txtDrivingLicenseNo.Text = ""
        txtDrivingLicenseNo.Tag = ""
        chkPassport.Checked = False
        chkPassport.Tag = chkPassport.Checked
        dtpPassportIssueDate.Checked = False
        dtpPassportIssueDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpPassportIssueDate.Tag = dtpPassportIssueDate.Value
        dtpPassportExpiryDate.Checked = False
        dtpPassportExpiryDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpPassportExpiryDate.Tag = dtpPassportExpiryDate.Value


        'BankAccount Tab

        nEmployeeId = Nothing
        nBankAccountId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        txtAccountTitle.Text = ""
        cbBank.SelectedIndex = -1
        cbBank.Tag = cbBank.SelectedIndex
        txtAccountNo.Text = ""
        txtAccountNo.Tag = ""
        txtBranch.Text = ""
        txtBranch.Tag = ""

        grdAudit.DataSource = Nothing

        ClearDependents()
        ClearExperiences()
        ClearQualifications()

        slStatus.Text = "New Employee"
    End Sub

    Private Sub Display()

        Dim rsBankAccount As New ADODB.Recordset
        Dim sSql As String

        Clear()
        Try
            If rsMain.RecordCount = 0 Then Exit Sub
            If rsMain.EOF Then Exit Sub

            bDisplaying = True

            'Personal Tab
            txtEmpID.Text = Convert.ToString(rsMain("Id").Value)
            txtEmpID.Tag = txtEmpID.Text
            txtEmployeeNo.Text = Convert.ToString(rsMain("EmployeeNo").Value)
            txtEmployeeNo.Tag = txtEmployeeNo.Text
            txtEmployeeNo.Enabled = False
            txtOldEmpNo.Text = Convert.ToString(rsMain("OldEmployeeNo").Value)
            If txtOldEmpNo.Text <> "" Then
                txtOldEmpNo.Enabled = False
            End If
            txtFirstName.Text = Convert.ToString(rsMain("FirstName").Value)
            txtFirstName.Tag = txtFirstName.Text
            txtMiddleName.Text = Convert.ToString(rsMain("MiddleName").Value)
            txtMiddleName.Tag = txtMiddleName.Text
            txtLastName.Text = Convert.ToString(rsMain("LastName").Value)
            txtLastName.Tag = txtLastName.Text
            txtFatherName.Text = Convert.ToString(rsMain("FatherName").Value)
            txtFatherName.Tag = txtFatherName.Text
            cbGender.SelectedIndex = CInt(rsMain("Gender").Value)
            cbGender.Tag = cbGender.SelectedIndex
            cbReligion.SelectedValue = CInt(rsMain("Religion").Value)
            cbReligion.Tag = cbReligion.SelectedValue
            cbNationality.SelectedValue = CInt(rsMain("NationalityId").Value)
            cbNationality.Tag = cbNationality.SelectedValue
            If Not IsDBNull(rsMain("DateofBirth").Value) Then
                dtpDOB.Value = CDate(rsMain("DateofBirth").Value)
                dtpDOB.Tag = dtpDOB.Value
                dtpDOB.Checked = True
            Else
                dtpDOB.Checked = False
            End If
            If Not IsDBNull(rsMain("nBirthCountry").Value) Then
                cbBirthCountry.SelectedValue = CInt(rsMain("nBirthCountry").Value)
                cbBirthCountry.Tag = cbBirthCountry.SelectedValue
            End If
            If Not IsDBNull(rsMain("nBirthCity").Value) Then
                cbBirthCity.SelectedValue = CInt(rsMain("nBirthCity").Value)
                cbBirthCity.Tag = cbBirthCity.SelectedValue
            End If
            If Not IsDBNull(rsMain("MaritalStatus").Value) Then
                cbMaritalStatus.SelectedIndex = CInt(rsMain("MaritalStatus").Value)
                cbMaritalStatus.Tag = cbMaritalStatus.SelectedIndex
            End If
            If Not IsDBNull(rsMain("MaritalStatusEffectiveDate").Value) Then
                dtpStatusSince.Value = CDate(rsMain("MaritalStatusEffectiveDate").Value)
                dtpStatusSince.Tag = dtpStatusSince.Value
                dtpStatusSince.Checked = True
            Else
                dtpStatusSince.Checked = False
            End If

            If Not IsDBNull(rsMain("BloodGroup").Value) Then
                cbBloodGroup.SelectedValue = CInt(rsMain("BloodGroup").Value)
                cbBloodGroup.Tag = cbBloodGroup.SelectedValue
            End If

            If Not IsDBNull(rsMain("Picture").Value) Then
                Dim imageData As Byte() = rsMain("Picture").Value
                If Not imageData Is Nothing Then
                    'If Convert.ToString(rsMain("ImageType").Value) = "application/octet-stream" Then
                    '    MsgBox("Picture format is currently not supported.", vbCritical)
                    'Else
                    Try
                        Using ms As New MemoryStream(imageData, 0, imageData.Length)
                            ms.Write(imageData, 0, imageData.Length)
                            pbEmployeePhoto.Image = Image.FromStream(ms, True)
                        End Using
                    Catch ex As Exception
                        MsgBox("Image could not be loaded.", vbCritical)
                    End Try
                    'End If
                End If
            End If

            If Not IsDBNull(rsMain("nsStatusId").Value) Then
                nStatus = CInt(rsMain("nsStatusId").Value)
            End If

            'FCCL Tab
            cbBusinessUnit.SelectedValue = CInt(rsMain("BusinessUnitId").Value)
            cbBusinessUnit.Tag = cbBusinessUnit.SelectedValue
            cbBranch.SelectedValue = CInt(rsMain("BranchId").Value)
            cbBranch.Tag = cbBranch.SelectedValue
            fromsBranch = cbBranch.Text
            cbDepartment.SelectedValue = CInt(rsMain("DepartmentId").Value)
            fromsDepartment = cbDepartment.Text
            cbDepartment.Tag = cbDepartment.SelectedValue

            cbDesignation.SelectedValue = CInt(rsMain("DesignationId").Value)
            cbDesignation.Tag = cbDesignation.SelectedValue
            fromsDesignation = cbDesignation.Text

            PopulateControl(cbSection, "Select nSectionId, vcSectionName From EM_Section where nDepartmentId='" + cbDepartment.SelectedValue.ToString() + "' Order by vcSectionName", "nSectionId", "vcSectionName")

            cbSection.SelectedValue = CInt(rsMain("nSectionId").Value)
            cbSection.Tag = cbSection.SelectedValue

            If Not IsDBNull(rsMain("JoinedAsId").Value) Then
                cbJoinedAs.SelectedValue = CInt(rsMain("JoinedAsId").Value)
                cbJoinedAs.Tag = cbJoinedAs.SelectedValue
            Else
                cbJoinedAs.SelectedIndex = -1
            End If

            If Not IsDBNull(rsMain("JoiningDate").Value) Then
                dtpJoiningDate.Value = CDate(rsMain("JoiningDate").Value)
                dtpJoiningDate.Tag = dtpJoiningDate.Value
                dtpJoiningDate.Checked = True
            Else
                dtpJoiningDate.Checked = False
            End If
            If CInt(rsMain("ContractTypeId").Value) = 4 Then
                cbContractType.SelectedIndex = 0
                cbContractType.Tag = cbContractType.SelectedIndex
            ElseIf CInt(rsMain("ContractTypeId").Value) = 5 Then
                cbContractType.SelectedIndex = 1
            Else
                cbContractType.SelectedIndex = -1
            End If
            If Not IsDBNull(rsMain("ContractStartDate").Value) Then
                dtpContractStartDate.Value = CDate(rsMain("ContractStartDate").Value)
                dtpContractStartDate.Tag = dtpContractStartDate.Value
                dtpContractStartDate.Checked = True
            Else
                dtpContractStartDate.Checked = False
            End If
            If Not IsDBNull(rsMain("dtmRenewalDate").Value) Then
                dtpContractEndDate.Value = CDate(rsMain("dtmRenewalDate").Value)
                dtpContractEndDate.Tag = dtpContractEndDate.Value
                dtpContractEndDate.Checked = True
            Else
                dtpContractEndDate.Checked = False
            End If
            If Not IsDBNull(rsMain("ProbationEndDate").Value) Then
                dtpProbationEndDate.Value = CDate(rsMain("ProbationEndDate").Value)
                dtpProbationEndDate.Tag = dtpProbationEndDate.Value
                dtpProbationEndDate.Checked = True
            Else
                dtpProbationEndDate.Checked = False
            End If
            If Not IsDBNull(rsMain("ConfirmationDate").Value) Then
                dtpConfirmationDate.Value = CDate(rsMain("ConfirmationDate").Value)
                dtpConfirmationDate.Tag = dtpConfirmationDate.Value
                dtpConfirmationDate.Checked = True
            Else
                dtpConfirmationDate.Checked = False
            End If
            If Not IsDBNull(rsMain("dtmRetirementDate").Value) Then
                dtpRetirementDate.Value = CDate(rsMain("dtmRetirementDate").Value)
                dtpRetirementDate.Tag = dtpRetirementDate.Value
                dtpRetirementDate.Checked = True
            Else
                dtpRetirementDate.Checked = False
            End If

            cbEmployeeType.SelectedValue = CInt(rsMain("EmployeeTypeId").Value)
            cbEmployeeType.Tag = cbEmployeeType.SelectedValue
            cbGrade.SelectedValue = CInt(rsMain("EmployeeGradeId").Value)
            cbGrade.Tag = cbGrade.SelectedValue
            If Not IsDBNull(rsMain("GradeEffectiveDate").Value) Then
                dtpGradeEffectiveDate.Value = CDate(rsMain("GradeEffectiveDate").Value)
                dtpGradeEffectiveDate.Tag = dtpGradeEffectiveDate.Value
                dtpGradeEffectiveDate.Checked = True
            Else
                dtpGradeEffectiveDate.Checked = False
            End If
            chkIsTechnical.CheckState = CInt(rsMain("IsTechnical").Value)
            chkIsTechnical.Tag = chkIsTechnical.CheckState
            If Not IsDBNull(rsMain("IsHeadOfDepartment").Value) Then
                chkIsHOD.Checked = CInt(rsMain("IsHeadOfDepartment").Value)
                chkIsHOD.Tag = chkIsHOD.Checked
            End If
            'txtHOD.Text = Convert.ToString(rsMain("HeadOfDepartmentId").Value)
            'txtHOD.Tag = txtHOD.Text
            txtJobDescription.Text = Convert.ToString(rsMain("JobDescription").Value)
            txtJobDescription.Tag = txtJobDescription.Text
            If Not IsDBNull(rsMain("IsForcePersonal").Value) Then
                chkIsMilitaryPersonnel.Checked = CInt(rsMain("IsForcePersonal").Value)
                chkIsMilitaryPersonnel.Tag = chkIsMilitaryPersonnel.Checked
            End If
            If Not IsDBNull(rsMain("FPRetirementRankId").Value) Then
                cbRank.SelectedValue = CInt(rsMain("FPRetirementRankId").Value)
                cbRank.Tag = cbRank.SelectedValue
            End If
            If Not IsDBNull(rsMain("FPRetirementDate").Value) Then
                dtpDateRetired.Value = CDate(rsMain("FPRetirementDate").Value)
                dtpDateRetired.Tag = dtpDateRetired.Value
                dtpDateRetired.Checked = True
            Else
                dtpDateRetired.Checked = False
            End If
            If Not IsDBNull(rsMain("FPJobDescription").Value) Then
                txtTradeAppointment.Text = Convert.ToString(rsMain("FPJobDescription").Value)
                txtTradeAppointment.Tag = txtTradeAppointment.Text
            End If
            If Not IsDBNull(rsMain("FPCorpsId").Value) Then
                cbCorps.SelectedValue = CInt(rsMain("FPCorpsId").Value)
                cbCorps.Tag = cbCorps.SelectedValue
            End If

            If Not IsDBNull(rsMain("nConfirmationId").Value) Then
                If (rsMain("nConfirmationId").Value = 1) Then
                    chkConfYes.Checked = CInt(rsMain("nIncrementId").Value)
                    chkConfYes.Tag = chkConfYes.Checked
                    chkConfYes.Checked = True
                Else
                    chkConfNo.Checked = CInt(rsMain("nIncrementId").Value)
                    chkConfNo.Tag = chkConfNo.Checked
                    chkConfNo.Checked = True
                End If
            End If

            If Not IsDBNull(rsMain("nLFA").Value) Then
                If (rsMain("nLFA").Value = 1) Then
                    ChkLFAYes.Checked = CInt(rsMain("nLFA").Value)
                    ChkLFAYes.Tag = ChkLFAYes.Checked
                    ChkLFAYes.Checked = True
                Else
                    chkLFANo.Checked = CInt(rsMain("nLFA").Value)
                    chkLFANo.Tag = chkLFANo.Checked
                    chkLFANo.Checked = True
                End If
            End If

            If Not IsDBNull(rsMain("nOtherCompanyEmp").Value) Then
                If (rsMain("nOtherCompanyEmp").Value = 1) Then
                    chkOtherCompEmp.Checked = CInt(rsMain("nOtherCompanyEmp").Value)
                    chkOtherCompEmp.Tag = chkOtherCompEmp.Checked
                    chkOtherCompEmp.Checked = True
                Else
                    chkOtherCompEmp.Checked = CInt(rsMain("nOtherCompanyEmp").Value)
                    chkOtherCompEmp.Tag = chkOtherCompEmp.Checked
                    chkOtherCompEmp.Checked = False
                End If
            End If


            sSql = "Select nIncrementId from EM_Employee  Where Id = " & Trim(txtEmpID.Text)
            GetRecordSet(rsMisc, sSql)

            If Not IsDBNull(rsMisc("nIncrementId").Value) Then
                nIncrementId = CInt(rsMisc("nIncrementId").Value)
            End If

            If nIncrementId = 1 Then
                btn_Increment.Text = "Disable Increment"
                lblIncrement.Visible = True
                lblIncrement.Text = "Increment is Enabled"
                lblIncrement.ForeColor = Color.Green
            ElseIf nIncrementId = 0 Then
                btn_Increment.Text = "Enable Increment"
                lblIncrement.Visible = True
                lblIncrement.Text = "Increment is Disabled"
                lblIncrement.ForeColor = Color.Red
            End If


            'Contacts Tab
            txtPresentAddress.Text = Convert.ToString(rsMain("ContactPresentAddress").Value)
            txtPresentAddress.Tag = txtPresentAddress.Text
            If Not IsDBNull(rsMain("ContactPresentCountryId").Value) Then
                cbPresentCountry.SelectedValue = CInt(rsMain("ContactPresentCountryId").Value)
                cbPresentCountry.Tag = cbPresentCountry.SelectedValue
            End If
            If Not IsDBNull(rsMain("ContactPresentCityId").Value) Then
                cbPresentCity.SelectedValue = CInt(rsMain("ContactPresentCityId").Value)
                cbPresentCity.Tag = cbPresentCity.SelectedValue
            End If
            txtPresentPhone.Text = Convert.ToString(rsMain("ContactPresentPhone").Value)
            txtPresentPhone.Tag = txtPresentPhone.Text
            txtPresentMobile.Text = Convert.ToString(rsMain("ContactPresentMobile").Value)
            txtPresentMobile.Tag = txtPresentMobile.Text
            txtPermanentAddress.Text = Convert.ToString(rsMain("ContactPermanentAddress").Value)
            txtPermanentAddress.Tag = txtPermanentAddress.Text
            If Not IsDBNull(rsMain("ContactPermanentCountryId").Value) Then
                cbPermanentCountry.SelectedValue = CInt(rsMain("ContactPermanentCountryId").Value)
                cbPermanentCountry.Tag = cbPermanentCountry.SelectedValue
            End If
            If Not IsDBNull(rsMain("ContactPermanentCityId").Value) Then
                cbPermanentCity.SelectedValue = CInt(rsMain("ContactPermanentCityId").Value)
                cbPermanentCity.Tag = cbPermanentCity.SelectedValue
            End If
            If Not IsDBNull(rsMain("ContactPermanentPhone").Value) Then
                txtPermanentPhone.Text = Convert.ToString(rsMain("ContactPermanentPhone").Value)
                txtPermanentPhone.Tag = txtPermanentPhone.Text
            End If
            If Not IsDBNull(rsMain("ContactPersonalEmail").Value) Then
                txtPersonalEmail.Text = Convert.ToString(rsMain("ContactPersonalEmail").Value)
                txtPersonalEmail.Tag = txtPersonalEmail.Text
            End If
            If Not IsDBNull(rsMain("ContactOfficialEmail").Value) Then
                txtOfficialEmail.Text = Convert.ToString(rsMain("ContactOfficialEmail").Value)
                txtOfficialEmail.Tag = txtOfficialEmail.Text
            End If

            'Miscellaneous Tab
            txtCNICOld.Text = Convert.ToString(rsMain("OldNICNo").Value)
            txtCNICOld.Tag = txtCNICOld.Text
            txtCNICNew.Text = Convert.ToString(rsMain("NewNICNo").Value)
            txtCNICNew.Tag = txtCNICNew.Text
            txtNTN.Text = Convert.ToString(rsMain("NationalTaxNo").Value)
            txtNTN.Tag = txtNTN.Text
            cbDomicile.SelectedValue = CInt(rsMain("DomicileId").Value)
            cbDomicile.Tag = cbDomicile.SelectedValue
            txtDrivingLicenseNo.Text = Convert.ToString(rsMain("DrivingLicenseNo").Value)
            txtDrivingLicenseNo.Tag = txtDrivingLicenseNo.Text
            txtPassportNo.Text = Convert.ToString(rsMain("PassportNo").Value)
            txtPassportNo.Tag = txtPassportNo.Text
            If Not IsDBNull(rsMain("PassportCountryId").Value) Then
                cbPassportCountry.SelectedValue = CInt(rsMain("PassportCountryId").Value)
                cbPassportCountry.Tag = cbPassportCountry.SelectedValue
            End If
            If Not IsDBNull(rsMain("PassportIssueDate").Value) Then
                dtpPassportIssueDate.Value = CDate(rsMain("PassportIssueDate").Value)
                dtpPassportIssueDate.Tag = dtpPassportIssueDate.Value
                dtpPassportIssueDate.Checked = True
            Else
                dtpPassportIssueDate.Checked = False
            End If
            If Not IsDBNull(rsMain("PassportExpiryDate").Value) Then
                dtpPassportExpiryDate.Value = CDate(rsMain("PassportExpiryDate").Value)
                dtpPassportExpiryDate.Tag = dtpPassportExpiryDate.Value
                dtpPassportExpiryDate.Checked = True
            Else
                dtpPassportExpiryDate.Checked = False
            End If


            'Bank Account Tab

            nEmployeeId = CInt(rsMain("Id").Value)
            txtEmployeeName.Text = Convert.ToString(rsMain("FullName").Value)
            txtEmployeeName.Tag = txtEmployeeName.Text

            sSql = "Select * From HR_EmployeeBankAccount Where EmployeeId = " & nEmployeeId
            rsBankAccount.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            If rsBankAccount.RecordCount > 0 Then
                nBankAccountId = CInt(rsBankAccount("Id").Value)
                txtAccountNo.Text = Convert.ToString(rsBankAccount("BankAccountNo").Value)
                txtAccountNo.Tag = txtAccountNo.Text
                txtAccountTitle.Text = Convert.ToString(rsBankAccount("AccountTitle").Value)
                txtAccountTitle.Tag = txtAccountTitle.Text
                cbBank.SelectedValue = CInt(rsBankAccount("BankId").Value)
                cbBank.Tag = cbBank.SelectedValue
                If Not IsDBNull(rsBankAccount("BankBranch").Value) Then
                    txtBranch.Text = Convert.ToString(rsBankAccount("BankBranch").Value)
                    txtBranch.Tag = txtBranch.Text
                End If
            End If


            FillAudit()
            FillDependents()
            FillExperiences()
            FillQualifications()

            If nStatus = 1 Then
                slStatus.Text = "Pending"
            ElseIf nStatus = 6 Then
                slStatus.Text = "Verified"
            ElseIf nStatus = 3 Then
                slStatus.Text = "Approved"
            End If

            ' grdAudit.VScrollBar.Visible = True
            '  grdAudit.Enabled = True

            Me.Refresh()

            bDisplaying = False
        Catch ex As Exception
            MessageBox.Show("Error displaying record: " + ex.Message)
        End Try

    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String ', sAction As String
        Dim rsMisc As New ADODB.Recordset
        Dim nEmpIDEM As Integer, nEmpIDHR As Integer
        Dim nEmpId As Integer

        Try
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If rsMain.State = ADODB.ObjectStateEnum.adStateClosed Then Exit Sub
            If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            bProcessing = True
            'conn.BeginTrans()

            If Trim(txtEmpID.Text) = "" Then
                If rsMain.State = ADODB.ObjectStateEnum.adStateClosed Then
                    sSql = "Select * From EM_Employee Where 1 = 2"
                    rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                End If

                rsMain.AddNew()

                'sSql = "Select MAX(Id) As Id From EM_Employee"
                'GetRecordSet(rsMisc, sSql)
                'nEmpId = CInt(rsMisc("Id").Value)

                sSql = "Select MAX(Id) As Id From EM_Employee"
                GetRecordSet(rsMisc, sSql)
                nEmpIDEM = CInt(rsMisc("Id").Value)

                sSql = "Select MAX(Id) As Id From HR_Employee"
                GetRecordSet(rsMisc, sSql)
                nEmpIDHR = CInt(rsMisc("Id").Value)

                If nEmpIDEM > nEmpIDHR Then
                    nEmpId = nEmpIDEM
                Else
                    nEmpId = nEmpIDHR
                End If


                nEmpId += 1
                txtEmpID.Text = Convert.ToString(nEmpId)
                rsMain!Id = txtEmpID.Text
                rsMain!IsActive = 1
                rsMain!CurrentStatus = 0

                rsMain!nSectionId = 0
                rsMain!vcVehicleAccCode = "1"
                rsMain!vcMobileAccCode = "1"
                rsMain!ClerkEmpNo = ""
                rsMain!RecommendedByEmpNo1 = ""
                rsMain!RecommendedByEmpNo2 = ""
                rsMain!SanctionedByEmpNo = ""
                rsMain!GMEmpNo = ""
                rsMain!ManagerEmpNo = ""
                rsMain!RoEmpNo = ""
                rsMain!SroEmpNo = ""
                rsMain!AttVerificationEmpNo1 = ""
                rsMain!AttVerificationEmpNo2 = ""
                rsMain!AttApprovingEmpNo = ""

                nStatus = 1
                sAction = "Prepared"
            End If

            'Personal Tab
            rsMain!EmployeeNo = txtEmployeeNo.Text
            rsMain!OldEmployeeNo = txtOldEmpNo.Text
            If IsDBNull(rsMain("nIncrementId").Value) Then
                nIncrementId = 1
                rsMain!nIncrementId = nIncrementId
            End If
            rsMain!FirstName = txtFirstName.Text
            rsMain!MiddleName = txtMiddleName.Text
            rsMain!LastName = txtLastName.Text
            If chkIsMilitaryPersonnel.Checked = True Then
                rsMain!FullName = cbRank.Text + " (R) " + txtFirstName.Text + IIf(txtMiddleName.Text <> "", " " + txtMiddleName.Text, "") + " " + txtLastName.Text
            Else
                rsMain!FullName = txtFirstName.Text + IIf(txtMiddleName.Text <> "", " " + txtMiddleName.Text, "") + " " + txtLastName.Text
            End If
            rsMain!FatherName = txtFatherName.Text
            rsMain!Gender = CInt(cbGender.SelectedIndex)
            rsMain!Religion = CInt(cbReligion.SelectedValue)
            rsMain!NationalityId = CInt(cbNationality.SelectedValue)
            If dtpDOB.Checked = True Then
                rsMain!DateOfBirth = CDate(dtpDOB.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!DateOfBirth = DBNull.Value
            End If

            rsMain!MaritalStatus = CInt(cbMaritalStatus.SelectedIndex)

            If dtpStatusSince.Checked = True Then
                rsMain!MaritalStatusEffectiveDate = CDate(dtpStatusSince.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!MaritalStatusEffectiveDate = DBNull.Value
            End If

            rsMain!nBirthCountry = CInt(cbBirthCountry.SelectedValue)
            rsMain!nBirthCity = CInt(cbBirthCity.SelectedValue)

            If cbBloodGroup.SelectedIndex <> -1 Then
                rsMain!BloodGroup = CInt(cbBloodGroup.SelectedValue)
            Else
                rsMain!BloodGroup = 0
            End If

            'If Not pbEmployeePhoto.Image Is Nothing Then
            If bNewImage = True Then
                Dim ms As New MemoryStream()
                pbEmployeePhoto.Image.Save(ms, pbEmployeePhoto.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                rsMain!Picture = data
            End If

            rsMain!nsStatusId = nStatus

            'FCCL Tab
            rsMain!BusinessUnitId = CInt(cbBusinessUnit.SelectedValue)
            rsMain!BranchId = CInt(cbBranch.SelectedValue)
            rsMain!DepartmentId = CInt(cbDepartment.SelectedValue)
            rsMain!nSectionId = CInt(cbSection.SelectedValue)
            rsMain!DesignationId = CInt(cbDesignation.SelectedValue)

            If cbJoinedAs.SelectedIndex <> -1 Then
                rsMain!JoinedAsId = CInt(cbJoinedAs.SelectedValue)
            End If

            If dtpJoiningDate.Checked = True Then
                rsMain!JoiningDate = CDate(dtpJoiningDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!JoiningDate = DBNull.Value
            End If



            If cbContractType.SelectedIndex = 0 Then
                rsMain!ContractTypeId = 4
            ElseIf cbContractType.SelectedIndex = 1 Then
                rsMain!ContractTypeId = 5
            Else
                rsMain!ContractTypeId = -1
            End If

            If dtpContractStartDate.Checked = True Then
                rsMain!ContractStartDate = CDate(dtpContractStartDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!ContractStartDate = DBNull.Value
            End If

            If dtpContractEndDate.Checked = True Then
                rsMain!ContractEndDate = CDate(dtpContractEndDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!ContractEndDate = DBNull.Value
            End If

            If dtpProbationEndDate.Checked = True Then
                rsMain!ProbationEndDate = CDate(dtpProbationEndDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!ProbationEndDate = DBNull.Value
            End If

            If dtpConfirmationDate.Checked = True Then
                rsMain!ConfirmationDate = CDate(dtpConfirmationDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!ConfirmationDate = DBNull.Value
            End If

            If dtpRetirementDate.Checked = True Then
                rsMain!dtmRetirementDate = CDate(dtpRetirementDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!dtmRetirementDate = DBNull.Value
            End If

            rsMain!EmployeeTypeId = CInt(cbEmployeeType.SelectedValue)
            rsMain!EmployeeGradeId = CInt(cbGrade.SelectedValue)

            If dtpGradeEffectiveDate.Checked = True Then
                rsMain!GradeEffectiveDate = CDate(dtpGradeEffectiveDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!GradeEffectiveDate = DBNull.Value
            End If

            rsMain!isTechnical = CInt(chkIsTechnical.CheckState)
            rsMain!isHeadOfDepartment = CInt(chkIsHOD.CheckState)

            'If chkIsHOD.Checked = False Then
            '    rsMain!HeadOfDepartmentId = txtHOD.Text
            'End If

            rsMain!JobDescription = txtJobDescription.Text

            If chkIsMilitaryPersonnel.Checked = True Then
                rsMain!IsForcePersonal = 1
                '        rsMain!IsForcePersonal = CInt(chkIsMilitaryPersonnel.CheckState)
                rsMain!FPRetirementRankId = CInt(cbRank.SelectedValue)
                rsMain!vcRank = Convert.ToString(cbRank.Text)

                If dtpDateRetired.Checked = True Then
                    rsMain!FPRetirementDate = CDate(dtpDateRetired.Value.ToString("dd MMM yyyy"))
                Else
                    rsMain!FPRetirementDate = DBNull.Value
                End If

                rsMain!FPJobDescription = txtJobDescription.Text
                rsMain!FPCorpsId = CInt(cbCorps.SelectedValue)
            Else
                rsMain!IsForcePersonal = 0
                '        rsMain!IsForcePersonal = CInt(chkIsMilitaryPersonnel.CheckState)
                rsMain!FPRetirementRankId = 0
                rsMain!vcRank = ""
                rsMain!FPJobDescription = ""
                rsMain!FPCorpsId = 0
                rsMain!FPRetirementDate = DBNull.Value
            End If

            If chkConfYes.Checked = True Then
                rsMain!nConfirmationId = 1
            ElseIf chkConfNo.Checked = True Then
                rsMain!nConfirmationId = 0
            End If

            If ChkLFAYes.Checked = True Then
                rsMain!nLFA = 1
            ElseIf chkLFANo.Checked = True Then
                rsMain!nLFA = 0
            End If


            If chkOtherCompEmp.Checked = True Then
                rsMain!nOtherCompanyEmp = 1
            Else
                rsMain!nOtherCompanyEmp = 0
            End If


            'Contacts Tab
            rsMain!ContactPresentAddress = txtPresentAddress.Text
            rsMain!ContactPresentCountryId = CInt(cbPresentCountry.SelectedValue)
            rsMain!ContactPresentCityId = CInt(cbPresentCity.SelectedValue)
            rsMain!ContactPresentPhone = txtPresentPhone.Text
            rsMain!ContactPresentMobile = txtPresentMobile.Text
            rsMain!ContactPermanentAddress = txtPermanentAddress.Text
            rsMain!ContactPermanentCountryId = CInt(cbPermanentCountry.SelectedValue)
            rsMain!ContactPermanentCityId = CInt(cbPermanentCity.SelectedValue)
            rsMain!ContactPermanentPhone = txtPermanentPhone.Text

            rsMain!ContactPersonalEmail = txtPersonalEmail.Text
            rsMain!ContactOfficialEmail = txtOfficialEmail.Text

            'Miscellaneous Tab
            rsMain!OldNICNo = txtCNICOld.Text
            rsMain!NewNICNo = txtCNICNew.Text
            rsMain!NationalTaxNo = txtNTN.Text
            rsMain!DomicileId = CInt(cbDomicile.SelectedValue)
            rsMain!DrivingLicenseNo = txtDrivingLicenseNo.Text

            rsMain!PassportNo = txtPassportNo.Text
            rsMain!PassportCountryId = CInt(cbPassportCountry.SelectedValue)

            If dtpPassportIssueDate.Checked = True Then
                rsMain!PassportIssueDate = CDate(dtpPassportIssueDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!PassportIssueDate = DBNull.Value
            End If

            If dtpPassportExpiryDate.Checked = True Then
                rsMain!PassportExpiryDate = CDate(dtpPassportExpiryDate.Value.ToString("dd MMM yyyy"))
            Else
                rsMain!PassportExpiryDate = DBNull.Value
            End If

            rsMain.Update()

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

            'conn.CommitTrans()

            If nStatus = 1 Then
                MsgBox("Employee saved successfully.", vbInformation)
            End If



        Catch ex As Exception
            MsgBox("Error saving record:" + Convert.ToString(ex), vbCritical)
        End Try

        'If sAction = "Prepared" Then
        'sSql = "Select * From EM_Employee Where EmployeeNo = '" & txtEmployeeNo.Text & "'"
        'rsMain.Close()
        'rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        'End If

        'GenerateMails()
        If g_nCompanyId = 1 Then
            GenerateMails()
        ElseIf g_nCompanyId = 2 Then
            GenerateMailsAcl()
        End If

        Display()
        'conn.Close()

        bProcessing = False
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String
        Dim ValidateCNIC As New Regex("\d{5}-\d{7}-\d{1}")


        ValidateFields = False

        If Trim(txtEmpID.Text) <> "" Then
            sSql = "Select nsStatusId From EM_Employee Where Id = " & txtEmpID.Text
            GetRecordSet(rsMisc, sSql)

            If rsMisc.RecordCount > 0 Then nStatus = CInt(rsMisc("nsStatusId").Value)
            rsMisc.Close()
        End If

        If nStatus = 3 Then
            MsgBox("Invalid Action.", vbCritical)
            Exit Function
        End If

        If txtEmpID.Text = "" Then
            If Trim(txtEmployeeNo.Text) <> "" Then
                sSql = "Select EmployeeNo From EM_Employee Where EmployeeNo = '" & txtEmployeeNo.Text & "'"
                GetRecordSet(rsMisc, sSql)

                If rsMisc.RecordCount > 0 Then
                    MsgBox("Employee No aleady exists.", vbCritical)
                    txtEmployeeNo.Focus()
                    Exit Function
                End If
            End If
        End If

        If txtOldEmpNo.Text = "" Then
            If Trim(txtOldEmpNo.Text) <> "" Then
                sSql = "Select OldEmployeeNo From EM_Employee Where EmployeeNo = '" & txtEmployeeNo.Text & "'"
                GetRecordSet(rsMisc, sSql)

                If rsMisc.RecordCount > 0 Then
                    MsgBox("Old Employee No aleady exists.", vbCritical)
                    txtOldEmpNo.Focus()
                    Exit Function
                End If
            End If
        End If

        If txtEmployeeNo.Text = "" Then
            MsgBox("Please enter employee no.", vbCritical)
            txtEmployeeNo.Focus()
            Exit Function
        End If

        If g_nCompanyId = 1 Then
            If Regex.IsMatch(txtEmployeeNo.Text, "^[0-9 ]+$") And chkOtherCompEmp.Checked = False Then

            Else
                MsgBox("Please Check " + g_sIsOtherCmpany + "?", vbCritical)
                TabControl1.SelectedIndex = 1
                chkOtherCompEmp.Focus()
                Exit Function
            End If
        Else
            If Regex.IsMatch(txtEmployeeNo.Text, "^[0-9 ]+$") And chkOtherCompEmp.Checked = False Then
                MsgBox("Please Check " + g_sIsOtherCmpany + "?", vbCritical)
                TabControl1.SelectedIndex = 1
                chkOtherCompEmp.Focus()
                Exit Function
            End If
        End If

        If txtFirstName.Text = "" Then
            MsgBox("Please enter first name.", vbCritical)
            txtFirstName.Focus()
            Exit Function
        End If

        'If txtLastName.Text = "" Then
        '    MsgBox("Please enter last name.", vbCritical)
        '    txtLastName.Focus()
        '    Exit Function
        'End If

        If txtFatherName.Text = "" Then
            MsgBox("Please enter father name.", vbCritical)
            txtFatherName.Focus()
            Exit Function
        End If

        If cbGender.SelectedItem = Nothing Then
            MsgBox("Please select gender.", vbCritical)
            cbGender.Focus()
            Exit Function
        End If

        If dtpDOB.Checked = False Then
            MsgBox("Please Select Date of Birth", vbCritical)
            dtpDOB.Focus()
            Exit Function
        End If

        If cbReligion.SelectedIndex < 0 Then
            MsgBox("Please Select Religion.", vbCritical)
            cbReligion.Focus()
            Exit Function
        End If

        If txtCNICNew.Text = "" Then
            MsgBox("Please Enter Employee CNIC.", vbCritical)
            txtCNICNew.Focus()
            Exit Function
        Else
            sSql = "Select NewNICNo From EM_Employee Where NewNICNo = '" & txtCNICNew.Text & "' "
            GetRecordSet(rsMisc, sSql)

            If txtCNICNew.Tag <> txtCNICNew.Text Then
                If rsMisc.RecordCount <= 0 Then

                    If ValidateCNIC.IsMatch(txtCNICNew.Text) Then
                        txtCNICNew.Focus()
                    Else
                        MsgBox("Please Enter a valid 13 Digits CNIC Number Format XXXXX-XXXXXXX-X")
                        txtCNICNew.Focus()
                        Exit Function
                    End If
                Else
                    MsgBox("CNIC Already Exists")
                    txtCNICNew.Focus()
                    Exit Function
                End If
            End If
        End If

        If cbNationality.SelectedIndex < 0 Then
            MsgBox("Please Select Nationaltiy.", vbCritical)
            cbNationality.Focus()
            Exit Function
        End If

        If cbMaritalStatus.SelectedItem = Nothing Then
            MsgBox("Please select marital status.", vbCritical)
            cbMaritalStatus.Focus()
            Exit Function
        End If

        If cbBranch.SelectedIndex < 0 Then
            MsgBox("Please Select Branch.", vbCritical)
            cbBranch.Focus()
            Exit Function
        End If

        If cbDepartment.SelectedIndex < 0 Then
            MsgBox("Please Select Department.", vbCritical)
            cbDepartment.Focus()
            Exit Function
        End If

        If cbDesignation.SelectedIndex < 0 Then
            MsgBox("Please Select Designation.", vbCritical)
            cbDesignation.Focus()
            Exit Function
        End If

        If dtpJoiningDate.Checked = False Then
            MsgBox("Please Enter Joining Date", vbCritical)
            dtpJoiningDate.Focus()
            Exit Function
        End If

        If dtpContractStartDate.Checked = False Then
            MsgBox("Please Enter Contract Start Date", vbCritical)
            dtpContractStartDate.Focus()
            Exit Function
        End If

        'If dtpContractEndDate.Checked = False Then
        '    MsgBox("Please Enter Contract End Date", vbCritical)
        '    dtpContractEndDate.Focus()
        '    Exit Function
        'End If

        If cbContractType.SelectedIndex < 0 Then
            MsgBox("Please Select Contract Type.", vbCritical)
            cbContractType.Focus()
            Exit Function
        End If

        If cbEmployeeType.SelectedIndex < 0 Then
            MsgBox("Please Select Employee Type.", vbCritical)
            cbEmployeeType.Focus()
            Exit Function
        End If

        If cbGrade.SelectedIndex < 0 Then
            MsgBox("Please Select Employee Grade.", vbCritical)
            cbGrade.Focus()
            Exit Function
        End If

        If txtPresentAddress.Text = "" Then
            MsgBox("Please enter Present Address.", vbCritical)
            txtPresentAddress.Focus()
            Exit Function
        End If

        If cbPresentCountry.SelectedIndex < 0 Then
            MsgBox("Please Select Present Country.", vbCritical)
            cbPresentCountry.Focus()
            Exit Function
        End If

        If cbPresentCity.SelectedIndex < 0 Then
            MsgBox("Please Select Present City.", vbCritical)
            cbPresentCity.Focus()
            Exit Function
        End If

        If txtPresentMobile.Text = "" Then
            MsgBox("Please enter Present Mobile No.", vbCritical)
            txtPresentMobile.Focus()
            Exit Function
        End If

        If txtPermanentAddress.Text = "" Then
            MsgBox("Please enter Present Address.", vbCritical)
            txtPermanentAddress.Focus()
            Exit Function
        End If

        If cbPermanentCountry.SelectedIndex < 0 Then
            MsgBox("Please Select Permanent Country.", vbCritical)
            cbPermanentCountry.Focus()
            Exit Function
        End If

        If cbPermanentCity.SelectedIndex < 0 Then
            MsgBox("Please Select Permanant City.", vbCritical)
            cbPermanentCity.Focus()
            Exit Function
        End If

        If cbBranch.Tag <> cbBranch.SelectedValue Then
            If txtOfficialEmail.Text <> "" Then
                bEmail = True
                sBranch = cbBranch.Text
            End If
        End If

        If cbDepartment.Tag <> cbDepartment.SelectedValue Then
            If txtOfficialEmail.Text <> "" Then
                bEmail = True
                sDepartment = cbDepartment.Text
            End If
        End If

        If cbDesignation.Tag <> cbDesignation.SelectedValue Then
            If txtOfficialEmail.Text <> "" Then
                bEmail = True
                sDesignation = cbDesignation.Text
            End If
        End If

        If Trim(txtEmpID.Tag) = "" Then
            sAction = "Prepared"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 4 Then
            sAction = "Approved"
            nStatus = 3
            slStatus.Text = "Approved"
        End If

        ValidateFields = True
    End Function


    Private Function GenerateMails() As Boolean
        If bEmail <> True Then Exit Function

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("ems", "Ems753")
            Smtp_Server.Port = 25
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "192.168.2.3"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("ems@fccl.com.pk")
            e_mail.To.Add("raza@fccl.com.pk")
            'e_mail.To.Add("arslan.ahmed@fccl.com.pk")
            e_mail.Subject = "HR Profiles Update"
            e_mail.IsBodyHtml = False
            e_mail.Body = "HR Profiles Of Employee ( " & txtEmployeeNo.Text & " - " & txtEmployeeName.Text & " ) has been updated With following details." + vbNewLine + vbNewLine
            If sBranch <> "" Then
                e_mail.Body = e_mail.Body & "From Branch :" & fromsBranch + vbNewLine
                e_mail.Body = e_mail.Body & "To Branch : * " & cbBranch.Text + vbNewLine

            End If
            If sDepartment <> "" Then
                e_mail.Body = e_mail.Body & "From Department :" & fromsDepartment + vbNewLine
                e_mail.Body = e_mail.Body & "To Department : * " & cbDepartment.Text + vbNewLine

            End If
            If sDesignation <> "" Then
                e_mail.Body = e_mail.Body & "From Designation :" & fromsDesignation + vbNewLine
                e_mail.Body = e_mail.Body & "To Designation : * " & cbDesignation.Text + vbNewLine
            End If

            If sBranch = "" Then
                e_mail.Body = e_mail.Body & "Branch :" & cbBranch.Text + vbNewLine
            End If
            If sDepartment = "" Then
                e_mail.Body = e_mail.Body & "Department :" & cbDepartment.Text + vbNewLine
            End If
            If sDesignation = "" Then
                e_mail.Body = e_mail.Body & "Designation :" & cbDesignation.Text + vbNewLine
            End If

            If txtOfficialEmail.Text <> "" Then
                e_mail.Body = e_mail.Body & "Email : " & txtOfficialEmail.Text + vbNewLine + vbNewLine
                e_mail.Body = e_mail.Body & "Changes Made by: " & g_sLoggedInUser + vbNewLine

            End If

            e_mail.Body = e_mail.Body + vbNewLine + vbNewLine
            e_mail.Body = e_mail.Body & "Regards" + vbNewLine
            e_mail.Body = e_mail.Body & "HR Department" + vbNewLine
            e_mail.Body = e_mail.Body & "Fauji Cement Company Limited." + vbNewLine

            ServicePointManager.ServerCertificateValidationCallback =
            New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            Smtp_Server.EnableSsl = True
            Smtp_Server.Send(e_mail)
            '  MsgBox("Mail Sent")
            bEmail = False
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

        Return bEmail

    End Function

    Private Function GenerateMailsAcl() As Boolean
        If bEmail <> True Then Exit Function

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            'Smtp_Server.Credentials = New Net.NetworkCredential("ems", "Ems753")
            Smtp_Server.Credentials = New Net.NetworkCredential("ems@askaricement.com.pk", "Ems753")
            Smtp_Server.Port = 25
            'Smtp_Server.EnableSsl = True
            'Smtp_Server.Host = "192.168.2.3"
            Smtp_Server.Host = "mail.askaricement.com.pk"

            e_mail = New MailMessage()
            'e_mail.From = New MailAddress("ems@fccl.com.pk")
            e_mail.From = New MailAddress("ems@askaricement.com.pk")
            'e_mail.To.Add("raza@fccl.com.pk")
            e_mail.To.Add("rashid@askaricement.com.pk")
            'e_mail.To.Add("sabir@askaricement.com.pk")
            e_mail.Subject = "HR Profiles Update"
            e_mail.IsBodyHtml = False
            e_mail.Body = "HR Profiles Of Employee ( " & txtEmployeeNo.Text & " - " & txtEmployeeName.Text & " ) has been updated With following details." + vbNewLine + vbNewLine
            If sBranch <> "" Then
                e_mail.Body = e_mail.Body & "From Branch :" & fromsBranch + vbNewLine
                e_mail.Body = e_mail.Body & "To Branch : * " & cbBranch.Text + vbNewLine

            End If
            If sDepartment <> "" Then
                e_mail.Body = e_mail.Body & "From Department :" & fromsDepartment + vbNewLine
                e_mail.Body = e_mail.Body & "To Department : * " & cbDepartment.Text + vbNewLine

            End If
            If sDesignation <> "" Then
                e_mail.Body = e_mail.Body & "From Designation :" & fromsDesignation + vbNewLine
                e_mail.Body = e_mail.Body & "To Designation : * " & cbDesignation.Text + vbNewLine
            End If

            If sBranch = "" Then
                e_mail.Body = e_mail.Body & "Branch :" & cbBranch.Text + vbNewLine
            End If
            If sDepartment = "" Then
                e_mail.Body = e_mail.Body & "Department :" & cbDepartment.Text + vbNewLine
            End If
            If sDesignation = "" Then
                e_mail.Body = e_mail.Body & "Designation :" & cbDesignation.Text + vbNewLine
            End If

            If txtOfficialEmail.Text <> "" Then
                e_mail.Body = e_mail.Body & "Email : " & txtOfficialEmail.Text + vbNewLine + vbNewLine
                e_mail.Body = e_mail.Body & "Changes Made by: " & g_sLoggedInUser + vbNewLine

            End If

            e_mail.Body = e_mail.Body + vbNewLine + vbNewLine
            e_mail.Body = e_mail.Body & "Regards" + vbNewLine
            e_mail.Body = e_mail.Body & "HR Department" + vbNewLine
            'e_mail.Body = e_mail.Body & "Fauji Cement Company Limited." + vbNewLine
            e_mail.Body = e_mail.Body & "Askari Cement Ltd." + vbNewLine

            ServicePointManager.ServerCertificateValidationCallback =
            New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
            'Smtp_Server.EnableSsl = True
            Smtp_Server.Send(e_mail)
            '  MsgBox("Mail Sent")
            bEmail = False
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

        Return bEmail

    End Function

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmpID.Text) = "" Then Exit Sub

        If nStatus = 3 Then
            MsgBox("Invalid Action.", vbInformation)
            Exit Sub
        End If

        If MsgBox("Do you want To Delete the Record?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From EM_Employee_Audit Where vcDocumentId = '" & Trim(txtEmpID.Text) & "'"
        conn.Execute(sSql)

        rsMain.Delete()
        Clear()

        MsgBox("Employee deleted successfully.", vbInformation)
    End Sub

    Private Function IsAnyFieldChanged() As Boolean
        'IsAnyFieldChanged = (Trim(txtEmpID.Text) = "") Or (Trim(txtEmployeeNo.Text) <> Trim(txtEmployeeNo.Tag)) Or
        '                    (Trim(txtFirstName.Text) <> Trim(txtFirstName.Tag)) Or (Trim(txtMiddleName.Text) <> Trim(txtMiddleName.Tag)) Or
        '                    (Trim(txtLastName.Text) <> Trim(txtLastName.Tag)) Or (Trim(txtFatherName.Text) <> Trim(txtFatherName.Tag)) Or
        '                    (cbGender.SelectedValue <> cbGender.Tag) Or (cbReligion.SelectedValue <> cbReligion.Tag) Or
        '                    (cbNationality.SelectedValue <> cbNationality.Tag) Or (dtpDOB.Value <> dtpDOB.Tag) Or
        '                    (cbBirthCountry.SelectedValue <> cbBirthCountry.Tag) Or (cbBirthCity.SelectedValue <> cbBirthCity.Tag) Or
        '                    (cbMaritalStatus.SelectedValue <> cbMaritalStatus.Tag) Or (dtpStatusSince.Value <> dtpStatusSince.Tag)
    End Function

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btn_Prepare.Click
        Call Clear()
        ''frmAppraisals_Discipline.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btn_Modify.Click
        'If (txtEmployeeNo.Text = "") Or IsAnyFieldChanged() Then Exit Sub

        slStatus.Text = "Saving"

        Call Save()

        slStatus.Text = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        slStatus.Text = "Deleting"
        Call Delete()
        slStatus.Text = ""
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Employee Profile"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btn_Approve.Click
        Save(4)
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btn_Verify.Click
        Save(5)
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged
        If cbBranch.SelectedIndex <> -1 Then
            PopulateControl(cbDepartment, "Select Id, Description From HR_PRMDepartments Where BranchId = " + cbBranch.SelectedValue.ToString() + " Order by Description", "Id", "Description")
        End If
    End Sub

    Private Sub chkIsMilitaryPersonnel_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsMilitaryPersonnel.CheckedChanged
        If chkIsMilitaryPersonnel.Checked = True Then
            cbRank.Enabled = True
            dtpDateRetired.Enabled = True
            txtTradeAppointment.Enabled = True
            cbCorps.Enabled = True
        Else
            cbRank.Enabled = False
            dtpDateRetired.Enabled = False
            txtTradeAppointment.Enabled = False
            cbCorps.Enabled = False
        End If
    End Sub

    Private Sub chkIsHOD_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsHOD.CheckedChanged
        If chkIsHOD.Checked = True Then
            txtHOD.Enabled = False
        Else
            txtHOD.Enabled = True
        End If
    End Sub

    Private Sub cbPresentCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPresentCountry.SelectedIndexChanged
        PopulateControl(cbPresentCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbPresentCountry.SelectedValue), 969, cbPresentCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub cbPermanentCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPermanentCountry.SelectedIndexChanged
        PopulateControl(cbPermanentCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbPermanentCountry.SelectedValue), 969, cbPermanentCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub chkPassport_CheckedChanged(sender As Object, e As EventArgs) Handles chkPassport.CheckedChanged
        If chkPassport.Checked = True Then
            txtPassportNo.Enabled = True
            cbPassportCountry.Enabled = True
            dtpPassportIssueDate.Enabled = True
            dtpPassportExpiryDate.Enabled = True
        Else
            txtPassportNo.Enabled = False
            cbPassportCountry.Enabled = False
            dtpPassportIssueDate.Enabled = False
            dtpPassportExpiryDate.Enabled = False
        End If
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_Employee_Audit Where vcDocumentId = '" + txtEmpID.Text + "' And vcAction!='Uniform Size'  Order by dtmActionDate"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = Nothing
            grdAudit.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading dependents.")
        End Try
        connODBC.Close()
        grdAudit.Refresh()

    End Sub

    Private Sub FillDependents()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "Select Id, Name, Relation, DATEDIFF(hour,DateOfBirth,GETDATE())/8766 As Age, NICNo, InsuranceEntitlement, MaritalStatus From HR_EmployeeDependents Where EmployeeId = " & txtEmpID.Text

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdDependents.DataSource = Nothing
            grdDependents.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading Dependents.")
        End Try
        connODBC.Close()
        grdDependents.Refresh()
    End Sub

    Public Sub SearchRecords(ByVal a_sSql As String, ByVal a_sEmpNo As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("EmployeeNo = '" & a_sEmpNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Sub chkSameAsPresentAddress_CheckedChanged(sender As Object, e As EventArgs) Handles chkSameAsPresentAddress.CheckedChanged
        If chkSameAsPresentAddress.Checked = True Then
            txtPermanentAddress.Enabled = False
            txtPermanentPhone.Enabled = False
            cbPermanentCity.Enabled = False
            cbPermanentCountry.Enabled = False
            If txtPresentAddress.Text <> "" Then
                txtPermanentAddress.Text = txtPresentAddress.Text
            End If
            If txtPresentPhone.Text <> "" Then
                txtPermanentPhone.Text = txtPresentPhone.Text
            End If
            If cbPresentCountry.SelectedIndex <> -1 Then
                cbPermanentCountry.SelectedIndex = cbPresentCountry.SelectedIndex
            End If
            If cbPresentCity.SelectedIndex <> -1 Then
                cbPermanentCity.SelectedIndex = cbPresentCity.SelectedIndex
            End If
        Else
            txtPermanentAddress.Enabled = True
            txtPermanentPhone.Enabled = True
            cbPermanentCountry.Enabled = True
            cbPermanentCity.Enabled = True
        End If
    End Sub

    ' ======================= DEPENDENTS ======================================

    Private Sub cmdSaveDependent_Click(sender As Object, e As EventArgs) Handles cmd_SaveDependent.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewDependentId As Integer
        Dim nRelation As Integer, nMaritalStatus As Integer, nGender As Integer, nInsurance As Integer
        Dim sAction As String, sActionRemarks As String
        Dim sStatusSince As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        If txtEmpID.Text = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Sub
        End If

        If txtDependentName.Text = "" Then
            MsgBox("Please enter dependent name.", vbCritical)
            txtDependentName.Focus()
            Exit Sub
        End If

        If cbDependentRelation.SelectedIndex = -1 Then
            MsgBox("Please select dependent relation.", vbCritical)
            cbDependentRelation.Focus()
            Exit Sub
        End If

        If dtpDependentDOB.Checked = False Then
            MsgBox("Please select DOB of dependent.", vbCritical)
            dtpDependentDOB.Focus()
            Exit Sub
        End If

        If cbDependentMaritalStatus.SelectedIndex = -1 Then
            MsgBox("Please select dependent marital status.", vbCritical)
            cbDependentMaritalStatus.Focus()
            Exit Sub
        End If

        If cbDependentGender.SelectedIndex = -1 Then
            MsgBox("Please select dependent gender.", vbCritical)
            cbDependentGender.Focus()
            Exit Sub
        End If


        If dtpDependentStatusSince.Checked = False Then
            sStatusSince = "NULL"
        Else
            sStatusSince = "'" & dtpDependentStatusSince.Value.ToString("dd MMM yyyy") & "'"
        End If

        If cbDependentMaritalStatus.SelectedIndex = -1 Then
            nMaritalStatus = 0
        ElseIf cbDependentMaritalStatus.SelectedIndex = 0 Then
            nMaritalStatus = 1
        ElseIf cbDependentMaritalStatus.SelectedIndex = 1 Then
            nMaritalStatus = 2
        ElseIf cbDependentMaritalStatus.SelectedIndex = 2 Then
            nMaritalStatus = 3
        ElseIf cbDependentMaritalStatus.SelectedIndex = 3 Then
            nMaritalStatus = 4
        End If

        If cbDependentRelation.SelectedIndex = 0 Then
            nRelation = 2
        ElseIf cbDependentRelation.SelectedIndex = 1 Then
            nRelation = 1
        ElseIf cbDependentRelation.SelectedIndex = 2 Then
            nRelation = 7
        End If

        If cbDependentGender.SelectedIndex = 0 Then
            nGender = 1
        Else
            nGender = 2
        End If

        If chkDependentInsurance.Checked = True Then
            nInsurance = 0
        Else
            nInsurance = 1
        End If

        Try
            bProcessing = True

            If (nDependentId = Nothing) Or (nDependentId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeDependents Where EmployeeId = " & txtEmpID.Text
                GetRecordSet(rsMisc, sSql)
                If Not IsDBNull(rsMisc("Id").Value) Then
                    nNewDependentId = CInt(rsMisc("Id").Value)
                    nNewDependentId += 1
                Else
                    nNewDependentId = 1
                End If

                sSql = "Insert INTO HR_EmployeeDependents (Id, EmployeeId, Name, Relation, DateOfBirth, NICNo, MaritalStatus" &
                   ", MaritalStatusEffectiveFrom, InsuranceEntitlement, Gender) Values(" & nNewDependentId & ", " & txtEmpID.Text & ", '" & AdjustSingleQuotes(txtDependentName.Text) &
                   "', " & nRelation & ", '" & dtpDependentDOB.Value.ToString("dd MMM yyyy") & "', '" & AdjustSingleQuotes(txtDependentCNIC.Text) &
                   "', " & nMaritalStatus & ", " & sStatusSince & ", " & nInsurance & ", " & nGender & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeDependents Set Name = '" & AdjustSingleQuotes(txtDependentName.Text) & "', Relation = " & nRelation &
                   ", DateOfBirth = '" & dtpDependentDOB.Value.ToString("dd MMM yyyy") & "', NICNo = '" & AdjustSingleQuotes(txtDependentCNIC.Text) &
                   "', MaritalStatus = " & nMaritalStatus & ", MaritalStatusEffectiveFrom = " & sStatusSince &
                   ", InsuranceEntitlement = " & nInsurance & ", Gender = " & nGender & " Where Id = " & nDependentId & " And EmployeeId = " & txtEmpID.Text
                conn.Execute(sSql)
            End If
            'conn.CommitTrans()
            'rsMisc.Close()

            If nDependentId = 0 Then
                sAction = "New Dependent"
                sActionRemarks = "Added a new dependent."
            Else
                sAction = "Modified Dependent"
                sActionRemarks = "Modified a dependent."
            End If
            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record: " & ex.Message)
        End Try

        Display()

        bProcessing = False

    End Sub

    Private Sub grdDependents_DoubleClick(sender As Object, e As EventArgs) Handles grdDependents.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeDependents Where Id = " & Convert.ToString(grdDependents.Columns(0).Value) & " And EmployeeId = " & txtEmpID.Text

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nDependentId = CInt(rsMisc("Id").Value)
        txtDependentName.Text = Convert.ToString(rsMisc("Name").Value)
        txtDependentName.Tag = txtDependentName.Text

        If Not IsDBNull(rsMisc("NICNo").Value) Then
            txtDependentCNIC.Text = Convert.ToString(rsMisc("NICNo").Value)
            txtDependentCNIC.Tag = txtDependentCNIC.Text
        End If

        If Not IsDBNull(rsMisc("DateOfBirth").Value) Then
            dtpDependentDOB.Value = CDate(rsMisc("DateOfBirth").Value)
            dtpDependentDOB.Tag = dtpDependentDOB.Value
            dtpDependentDOB.Checked = True
        Else
            dtpDependentDOB.Checked = False
        End If

        If Not IsDBNull(rsMisc("MaritalStatusEffectiveFrom").Value) Then
            dtpDependentStatusSince.Value = CDate(rsMisc("MaritalStatusEffectiveFrom").Value)
            dtpDependentStatusSince.Tag = dtpDependentStatusSince.Value
            dtpDependentStatusSince.Checked = True
        Else
            dtpDependentStatusSince.Checked = False
        End If

        If CInt(rsMisc("MaritalStatus").Value) = 0 Then
            cbDependentMaritalStatus.SelectedIndex = -1
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 1 Then
            cbDependentMaritalStatus.SelectedIndex = 0
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 2 Then
            cbDependentMaritalStatus.SelectedIndex = 1
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 3 Then
            cbDependentMaritalStatus.SelectedIndex = 2
        ElseIf CInt(rsMisc("MaritalStatus").Value) = 4 Then
            cbDependentMaritalStatus.SelectedIndex = 3
        End If
        cbDependentMaritalStatus.Tag = cbDependentMaritalStatus.SelectedIndex

        If CInt(rsMisc("Relation").Value) = 1 Then
            cbDependentRelation.SelectedIndex = 1
        ElseIf CInt(rsMisc("Relation").Value) = 2 Then
            cbDependentRelation.SelectedIndex = 0
        ElseIf CInt(rsMisc("Relation").Value) = 7 Then
            cbDependentRelation.SelectedIndex = 2
        Else
            cbDependentRelation.SelectedIndex = -1
        End If
        cbDependentRelation.Tag = cbDependentRelation.SelectedIndex

        If CInt(rsMisc("Gender").Value) = 1 Then
            cbDependentGender.SelectedIndex = 0
        Else
            cbDependentGender.SelectedIndex = 1
        End If
        cbDependentGender.Tag = cbDependentGender.SelectedIndex

        If CInt(rsMisc("InsuranceEntitlement").Value) = 0 Then
            chkDependentInsurance.Checked = True
        Else
            chkDependentInsurance.Checked = False
        End If
        chkDependentInsurance.Tag = chkDependentInsurance.Checked

    End Sub

    Private Sub ClearDependents()
        nDependentId = Nothing
        txtDependentName.Text = ""
        txtDependentName.Tag = ""
        txtDependentCNIC.Text = ""
        txtDependentCNIC.Tag = ""
        dtpDependentDOB.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDependentDOB.Tag = dtpDOB.Value
        dtpDependentDOB.Checked = False
        dtpDependentStatusSince.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDependentStatusSince.Tag = dtpStatusSince.Value
        dtpDependentStatusSince.Checked = False
        cbDependentMaritalStatus.SelectedIndex = -1
        cbDependentMaritalStatus.Tag = cbMaritalStatus.SelectedIndex
        cbDependentRelation.SelectedIndex = -1
        cbDependentRelation.Tag = cbDependentRelation.SelectedIndex
        cbDependentGender.SelectedIndex = -1
        cbDependentGender.Tag = cbGender.SelectedIndex
        chkDependentInsurance.Checked = False
        chkDependentInsurance.Tag = chkDependentInsurance.Checked

        grdDependents.DataSource = Nothing
    End Sub

    Private Sub grdDependents_Click(sender As Object, e As EventArgs) Handles grdDependents.Click

    End Sub

    Private Sub cmdDeleteDependent_Click(sender As Object, e As EventArgs) Handles btn_DeleteDependent.Click
        Dim sSql As String

        If (nDependentId = Nothing) Or (nDependentId = 0) Then Exit Sub

        If MsgBox("Do you want to Delete the Record?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeDependents Where Id = " & nDependentId
        conn.Execute(sSql)

        sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), 'Deleted Dependent', '" & mdFunctions.sUserId & "', 'Deleted a dependent.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        'conn.Close()
        ClearDependents()
        FillDependents()

        MsgBox("Dependent deleted successfully.", vbInformation)
    End Sub

    ' ====================================== EXPERIENCE ============================================
    Private Sub FillExperiences()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT Id, Employer, Designation, FromDate, ToDate, EmployeeLastSalary, JobDescription From HR_EmployeeJobHistory Where EmployeeId = " & txtEmpID.Text

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdExperiences.DataSource = Nothing
            grdExperiences.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading professional experiences.")
        End Try
        connODBC.Close()
        grdExperiences.Refresh()
    End Sub

    Private Sub frmEmployeeProfile_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub

    Private Sub grdExperiences_DoubleClick(sender As Object, e As EventArgs) Handles grdExperiences.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeJobHistory Where Id = " & Convert.ToString(grdExperiences.Columns(0).Value)

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nJobId = CInt(rsMisc("Id").Value)
        txtExperienceEmployer.Text = Convert.ToString(rsMisc("Employer").Value)
        txtExperienceEmployer.Tag = txtExperienceEmployer.Text
        txtExperienceDesignation.Text = Convert.ToString(rsMisc("Designation").Value)
        txtExperienceDesignation.Tag = txtExperienceDesignation.Text
        If Not IsDBNull(rsMisc("FromDate").Value) Then
            dtpExperienceFromDate.Value = CDate(rsMisc("FromDate").Value)
            dtpExperienceFromDate.Tag = dtpExperienceFromDate.Value
            dtpExperienceFromDate.Checked = True
        Else
            dtpExperienceFromDate.Checked = False
        End If
        If Not IsDBNull(rsMisc("ToDate").Value) Then
            dtpExperienceToDate.Value = CDate(rsMisc("ToDate").Value)
            dtpExperienceToDate.Tag = dtpExperienceToDate.Value
            dtpExperienceToDate.Checked = True
        Else
            dtpExperienceToDate.Checked = False
        End If
        cbExperienceCountry.SelectedValue = CInt(rsMisc("CountryId").Value)
        cbExperienceCountry.Tag = cbExperienceCountry.SelectedValue
        cbExperienceCity.SelectedValue = CInt(rsMisc("CityId").Value)
        cbExperienceCity.Tag = cbExperienceCity.SelectedValue
        txtExperienceSalary.Text = Convert.ToString(rsMisc("EmployeeLastSalary").Value)
        txtExperienceSalary.Tag = txtExperienceSalary.Text
        txtExperienceBenefits.Text = Convert.ToString(rsMisc("OtherBenefits").Value)
        txtExperienceBenefits.Tag = txtExperienceBenefits.Text
        If Not IsDBNull(rsMisc("nIndustryId").Value) Then
            cbExperienceIndustry.SelectedIndex = CInt(rsMisc("nIndustryId").Value)
        Else
            cbExperienceIndustry.SelectedIndex = 0
        End If
        cbExperienceIndustry.Tag = cbExperienceIndustry.SelectedIndex
        txtExperienceJobDescription.Text = Convert.ToString(rsMisc("JobDescription").Value)
        txtExperienceJobDescription.Tag = txtExperienceJobDescription.Text
        txtExperienceReasonForLeaving.Text = Convert.ToString(rsMisc("ReasonForLeaving").Value)
        txtExperienceReasonForLeaving.Tag = txtExperienceReasonForLeaving.Text
    End Sub

    Private Sub cmdSaveExperience_Click(sender As Object, e As EventArgs) Handles cmd_PrepareExperience.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewJobId As Integer
        Dim sAction As String, sActionRemarks As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        If txtEmpID.Text = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Sub
        End If

        If txtExperienceEmployer.Text = "" Then
            MsgBox("Please enter employer name.", vbCritical)
            txtExperienceEmployer.Focus()
            Exit Sub
        End If

        If txtExperienceDesignation.Text = "" Then
            MsgBox("Please enter employer experience designation.", vbCritical)
            txtExperienceDesignation.Focus()
            Exit Sub
        End If

        If cbExperienceCountry.SelectedIndex = -1 Then
            MsgBox("Please select experience country", vbCritical)
            cbExperienceCountry.Focus()
            Exit Sub
        End If

        If cbExperienceCity.SelectedIndex = -1 Then
            MsgBox("Please select experience city.", vbCritical)
            cbExperienceCity.Focus()
            Exit Sub
        End If

        If cbExperienceIndustry.SelectedIndex = -1 Then
            MsgBox("Please select industry", vbCritical)
            cbExperienceIndustry.Focus()
            Exit Sub
        End If

        If dtpExperienceFromDate.Checked = False Then
            MsgBox("Please select experience from date.", vbCritical)
            dtpExperienceFromDate.Focus()
            Exit Sub
        End If

        If dtpExperienceToDate.Checked = False Then
            MsgBox("Please select experience to date.", vbCritical)
            dtpExperienceToDate.Focus()
            Exit Sub
        End If

        Try
            bProcessing = True

            If (nJobId = Nothing) Or (nJobId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeJobHistory"
                GetRecordSet(rsMisc, sSql)
                If Not IsDBNull(rsMisc("Id").Value) Then
                    nNewJobId = CInt(rsMisc("Id").Value)
                    nNewJobId += 1
                Else
                    nNewJobId = 1
                End If

                sSql = "Insert INTO HR_EmployeeJobHistory (Id, EmployeeId, Employer, Designation, JobDescription, FromDate, ToDate, EmployeeLastSalary" &
               ", OtherBenefits, ReasonForLeaving, CountryId, CityId, nIndustryId) Values(" & nNewJobId & ", " & txtEmpID.Text & ", '" & AdjustSingleQuotes(txtExperienceEmployer.Text) &
               "', '" & AdjustSingleQuotes(txtExperienceDesignation.Text) & "', '" & AdjustSingleQuotes(txtExperienceJobDescription.Text) & "', '" & dtpExperienceFromDate.Value.ToString("dd MMM yyyy") &
               "', '" & dtpExperienceToDate.Value.ToString("dd MMM yyyy") & "', " & IIf(txtExperienceSalary.Text = "", 0, txtExperienceSalary.Text) & ", '" & AdjustSingleQuotes(txtExperienceBenefits.Text) &
               "', '" & AdjustSingleQuotes(txtExperienceReasonForLeaving.Text) & "', " & cbExperienceCountry.SelectedValue & ", " & cbExperienceCity.SelectedValue & ", " & cbExperienceIndustry.SelectedIndex & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeJobHistory Set Employer = '" & AdjustSingleQuotes(txtExperienceEmployer.Text) & "', Designation = '" & AdjustSingleQuotes(txtExperienceDesignation.Text) &
               "', FromDate = '" & dtpExperienceFromDate.Value.ToString("dd MMM yyyy") & "', ToDate = '" & dtpExperienceToDate.Value.ToString("dd MMM yyyy") &
               "', CountryId = " & cbExperienceCountry.SelectedValue & ", CityId = " & cbExperienceCity.SelectedValue & ", EmployeeLastSalary = " & IIf(txtExperienceSalary.Text = "", 0, txtExperienceSalary.Text) &
               ", OtherBenefits = '" & AdjustSingleQuotes(txtExperienceBenefits.Text) & "', JobDescription = '" & AdjustSingleQuotes(txtExperienceJobDescription.Text) &
               "', ReasonForLeaving = '" & AdjustSingleQuotes(txtExperienceReasonForLeaving.Text) & "', nIndustryId = " & cbExperienceIndustry.SelectedIndex & "  Where Id = " & nJobId
                conn.Execute(sSql)
            End If

            If nJobId = 0 Then
                sAction = "New Job Experience"
                sActionRemarks = "Added a new job experience."
            Else
                sAction = "Modified Job Experience"
                sActionRemarks = "Modified a job experience."
            End If
            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record: " + ex.Message)
        End Try

        Display()

        bProcessing = False

    End Sub

    Private Sub ClearExperiences()
        nJobId = Nothing
        txtExperienceEmployer.Text = ""
        txtExperienceEmployer.Tag = ""
        txtExperienceDesignation.Text = ""
        txtExperienceDesignation.Tag = ""
        dtpExperienceFromDate.Checked = False
        dtpExperienceFromDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpExperienceFromDate.Tag = dtpExperienceFromDate.Value
        dtpExperienceToDate.Checked = False
        dtpExperienceToDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpExperienceToDate.Tag = dtpExperienceToDate.Value
        cbExperienceCountry.SelectedIndex = -1
        cbExperienceCountry.Tag = cbExperienceCountry.SelectedIndex
        cbExperienceCity.SelectedIndex = -1
        cbExperienceCity.Tag = cbExperienceCity.SelectedIndex
        txtExperienceSalary.Text = ""
        txtExperienceSalary.Tag = ""
        txtExperienceBenefits.Text = ""
        txtExperienceBenefits.Tag = ""
        cbExperienceIndustry.SelectedIndex = -1
        cbExperienceIndustry.Tag = cbExperienceIndustry.SelectedIndex
        txtExperienceJobDescription.Text = ""
        txtExperienceJobDescription.Tag = ""
        txtExperienceReasonForLeaving.Text = ""
        txtExperienceReasonForLeaving.Tag = ""

        grdExperiences.DataSource = Nothing

    End Sub

    Private Sub cmdDeleteExperience_Click(sender As Object, e As EventArgs) Handles btn_DeleteExperience.Click
        Dim sSql As String

        If (nJobId = Nothing) Or (nJobId = 0) Then Exit Sub

        If MsgBox("Do you want to Delete the Record?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeJobHistory Where Id = " & nJobId
        conn.Execute(sSql)

        sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), 'Deleted Job Experience', '" & mdFunctions.sUserId & "', 'Deleted a job experience.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        'conn.Close()
        ClearExperiences()
        FillExperiences()
        FillAudit()

        MsgBox("Experience deleted successfully.", vbInformation)
    End Sub

    ' ======================================= QUALIFICATIONS ===================================
    Private Sub FillQualifications()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "Select a.Id, CASE WHEN DegreeDiplomaId = 1236 THEN OtherDiploma " &
                             "ELSE (Select Description From HR_PRMParameters Where Type = 8 And Id = a.DegreeDiplomaId) END Degree, CASE WHEN InstitutionId = 1522 THEN OtherInstitute " &
                             "ELSE (Select Description From HR_PRMParameters Where Type = 9 And Id = a.InstitutionId) END Institution, a.SessionYearFrom, a.SessionYearTo From HR_EmployeeQualifications a Where EmployeeId = " & Trim(txtEmpID.Text)

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdQualifications.DataSource = Nothing
            grdQualifications.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading qualifications.")
        End Try
        connODBC.Close()
        grdQualifications.Refresh()
    End Sub

    Private Sub grdQualifications_DoubleClick(sender As Object, e As EventArgs) Handles grdQualifications.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeQualifications Where Id = " & Convert.ToString(grdQualifications.Columns(0).Value) & " And EmployeeId = " & Trim(txtEmpID.Text)
        GetRecordSet(rsMisc, sSql)
        'rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        ClearQualifications()
        FillQualifications()
        nQualificationId = CInt(rsMisc("Id").Value)
        cbQualificationDegree.SelectedValue = CInt(rsMisc("DegreeDiplomaId").Value)
        cbQualificationDegree.Tag = cbQualificationDegree.SelectedValue

        If Not IsDBNull(rsMisc("OtherDiploma").Value) Then
            txtQualificationOtherDegree.Text = Convert.ToString(rsMisc("OtherDiploma").Value)
            txtQualificationOtherDegree.Tag = txtQualificationOtherDegree.Text
        End If

        If Not IsDBNull(rsMisc("Majors").Value) Then
            txtQualificationMajors.Text = Convert.ToString(rsMisc("Majors").Value)
            txtQualificationMajors.Tag = txtQualificationMajors.Text
        End If

        If Not IsDBNull(rsMisc("GradeObtained").Value) Then
            txtQualificationGradeGPA.Text = Convert.ToString(rsMisc("GradeObtained").Value)
            txtQualificationGradeGPA.Tag = txtQualificationGradeGPA.Text
        End If

        cbQualificationInstitution.SelectedValue = CInt(rsMisc("InstitutionId").Value)
        cbQualificationInstitution.Tag = cbQualificationInstitution.SelectedValue

        If Not IsDBNull(rsMisc("OtherInstitute").Value) Then
            txtQualificationOtherInstitution.Text = Convert.ToString(rsMisc("OtherInstitute").Value)
            txtQualificationOtherInstitution.Tag = txtQualificationOtherInstitution.Text
        End If

        If Not IsDBNull(rsMisc("SessionYearFrom").Value) Then
            txtQualificationStartYear.Text = Convert.ToString(rsMisc("SessionYearFrom").Value)
            txtQualificationStartYear.Tag = txtQualificationStartYear.Text
        End If

        If Not IsDBNull(rsMisc("SessionYearTo").Value) Then
            txtQualificationEndYear.Text = Convert.ToString(rsMisc("SessionYearTo").Value)
            txtQualificationEndYear.Tag = txtQualificationEndYear.Text
        End If

        If CInt(rsMisc("IsAcademic").Value) = 0 Then
            radQualificationAcademic.Checked = True
            radQualificationAcademic.Tag = radQualificationAcademic.Checked
        Else
            radQualificationProfessional.Checked = True
            radQualificationAcademic.Tag = radQualificationAcademic.Checked
        End If

        cbQualificationCountry.SelectedValue = CInt(rsMisc("CountryId").Value)
        cbQualificationCountry.Tag = cbQualificationCountry.SelectedValue

        cbQualificationCity.SelectedValue = CInt(rsMisc("CityId").Value)
        cbQualificationCity.Tag = cbQualificationCity.SelectedValue

        If Not IsDBNull(rsMisc("ExtraActivities").Value) Then
            txtQualificationExtraCurricular.Text = Convert.ToString(rsMisc("ExtraActivities").Value)
            txtQualificationExtraCurricular.Tag = txtQualificationExtraCurricular.Text
        End If

        If Not IsDBNull(rsMisc("AcademicDistinctions").Value) Then
            txtQualificationDistinctions.Text = Convert.ToString(rsMisc("AcademicDistinctions").Value)
            txtQualificationDistinctions.Tag = txtQualificationDistinctions.Text
        End If
        FillAudit()
    End Sub

    Private Sub cmdSaveQualification_Click(sender As Object, e As EventArgs) Handles cmd_PrepareQualifications.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewQualificationtId As Integer
        Dim sAction As String, sActionRemarks As String

        If cbQualificationDegree.SelectedIndex = -1 Then
            MsgBox("Please select Qualification Degree", vbCritical)
            cbQualificationDegree.Focus()
            Exit Sub
        End If

        If txtQualificationStartYear.Text = "" Then
            MsgBox("Please enter Qualification Start Year.", vbCritical)
            txtQualificationStartYear.Focus()
            Exit Sub
        End If

        If txtQualificationEndYear.Text = "" Then
            MsgBox("Please enter Qualification End Year.", vbCritical)
            txtQualificationEndYear.Focus()
            Exit Sub
        End If

        If cbQualificationInstitution.SelectedIndex = -1 Then
            MsgBox("Please select Qualification Institution", vbCritical)
            cbQualificationInstitution.Focus()
            Exit Sub
        End If

        If cbQualificationCountry.SelectedIndex = -1 Then
            MsgBox("Please select Qualification country.", vbCritical)
            cbQualificationCountry.Focus()
            Exit Sub
        End If

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        Try
            bProcessing = True

            If (nQualificationId = Nothing) Or (nQualificationId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeQualifications Where EmployeeId = " & Trim(txtEmpID.Text)
                GetRecordSet(rsMisc, sSql)
                If Not IsDBNull(rsMisc("Id").Value) Then
                    nNewQualificationtId = CInt(rsMisc("Id").Value)
                    nNewQualificationtId += 1
                Else
                    nNewQualificationtId = 1
                End If


                sSql = "Insert INTO HR_EmployeeQualifications (Id, EmployeeId, DegreeDiplomaId, OtherDiploma, Majors, GradeObtained, " &
                        "InstitutionId, OtherInstitute, SessionYearFrom, SessionYearTo, IsAcademic, CountryId, CityId, ExtraActivities, " &
                        "AcademicDistinctions) Values(" & nNewQualificationtId & ", " & Trim(txtEmpID.Text) & ", " & IIf(cbQualificationDegree.SelectedIndex < 0, 0, cbQualificationDegree.SelectedValue) &
                        ", '" & txtQualificationOtherDegree.Text & "', '" & txtQualificationMajors.Text & "', '" & txtQualificationGradeGPA.Text & "', " & IIf(cbQualificationInstitution.SelectedIndex < 0, 0, cbQualificationInstitution.SelectedValue) &
                        ", '" & txtQualificationOtherInstitution.Text & "', " & IIf(txtQualificationStartYear.Text = "", 0, txtQualificationStartYear.Text) & ", " & IIf(txtQualificationEndYear.Text = "", 0, txtQualificationEndYear.Text) &
                        ", " & IIf(radQualificationAcademic.Checked, 0, 1) & ", " & cbQualificationCountry.SelectedValue & ", " & cbQualificationCity.SelectedValue &
                        ", '" & txtQualificationExtraCurricular.Text & "', '" & txtQualificationDistinctions.Text & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeQualifications Set DegreeDiplomaId = " & IIf(cbQualificationDegree.SelectedIndex < 0, 0, cbQualificationDegree.SelectedValue) & ", OtherDiploma = '" & txtQualificationOtherDegree.Text &
               "', Majors = '" & txtQualificationMajors.Text & "', GradeObtained = '" & txtQualificationGradeGPA.Text & "', InstitutionId = " & IIf(cbQualificationInstitution.SelectedIndex < 0, 0, cbQualificationInstitution.SelectedValue) &
               ", OtherInstitute = '" & txtQualificationOtherInstitution.Text & "', SessionYearFrom = " & IIf(txtQualificationStartYear.Text = "", 0, txtQualificationStartYear.Text) &
               ", SessionYearTo = " & IIf(txtQualificationEndYear.Text = "", 0, txtQualificationEndYear.Text) & ", IsAcademic = " & IIf(radQualificationAcademic.Checked, 0, 1) &
               ", CountryId = " & IIf(cbQualificationCountry.SelectedIndex < 0, 0, cbQualificationCountry.SelectedValue) & ", CityId = " & IIf(cbQualificationCity.SelectedIndex < 0, 0, cbQualificationCity.SelectedValue) &
               ", ExtraActivities = '" & txtQualificationExtraCurricular.Text & "', AcademicDistinctions = '" & txtQualificationDistinctions.Text &
               "' Where Id = " & nQualificationId & " And EmployeeId = " & Trim(txtEmpID.Text)
                conn.Execute(sSql)
            End If

            If nQualificationId = 0 Then
                sAction = "New Qualification"
                sActionRemarks = "Added a new qualification."
            Else
                sAction = "Modified Qualification"
                sActionRemarks = "Modified a qualification."
            End If

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           Trim(txtEmpID.Text) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record: " + ex.Message)
        End Try

        Display()

        bProcessing = False
    End Sub

    Private Sub ClearQualifications()
        nQualificationId = Nothing
        cbQualificationDegree.SelectedIndex = -1
        cbQualificationDegree.Tag = cbQualificationDegree.SelectedIndex
        txtQualificationOtherDegree.Text = ""
        txtQualificationOtherDegree.Tag = ""
        txtQualificationMajors.Text = ""
        txtQualificationMajors.Tag = ""
        txtQualificationGradeGPA.Text = ""
        txtQualificationGradeGPA.Tag = ""
        cbQualificationInstitution.SelectedIndex = -1
        cbQualificationInstitution.Tag = cbQualificationInstitution.SelectedIndex
        txtQualificationOtherInstitution.Text = ""
        txtQualificationOtherInstitution.Tag = ""
        txtQualificationStartYear.Text = ""
        txtQualificationStartYear.Tag = ""
        txtQualificationEndYear.Text = ""
        txtQualificationEndYear.Tag = ""
        radQualificationAcademic.Checked = True
        radQualificationAcademic.Tag = radQualificationAcademic.Checked
        radQualificationProfessional.Checked = False
        radQualificationProfessional.Tag = radQualificationAcademic.Checked
        cbQualificationCountry.SelectedIndex = -1
        cbQualificationCountry.Tag = cbQualificationCountry.SelectedIndex
        cbQualificationCity.SelectedIndex = -1
        cbQualificationCity.Tag = cbQualificationCountry.SelectedIndex
        txtQualificationExtraCurricular.Text = ""
        txtQualificationExtraCurricular.Tag = ""
        txtQualificationDistinctions.Text = ""
        txtQualificationDistinctions.Tag = ""
        grdQualifications.DataSource = Nothing

    End Sub

    Private Sub cmdDeleteQualification_Click(sender As Object, e As EventArgs) Handles btn_DeleteQualification.Click
        Dim sSql As String

        If Trim(txtEmpID.Text) = "" Then Exit Sub
        If nQualificationId = Nothing Then Exit Sub

        If MsgBox("Do you want to delete this qualification?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeQualifications Where Id = " & nQualificationId & " And EmployeeId = " & txtEmpID.Text
        conn.Execute(sSql)

        sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), 'Deleted Qualification', '" & mdFunctions.sUserId & "', 'Deleted a qualification.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        ClearQualifications()
        FillQualifications()
        FillAudit()

    End Sub

    Private Sub cmdUploadPicture_Click(sender As Object, e As EventArgs) Handles cmdUploadPicture.Click
        Dim ofdBrowsePicture As New OpenFileDialog
        If ofdBrowsePicture.ShowDialog() = DialogResult.OK Then
            pbEmployeePhoto.Image = Image.FromFile(ofdBrowsePicture.FileName)
            bNewImage = True
        Else
            bNewImage = False
        End If

    End Sub

    Private Sub cmdClearExperience_Click(sender As Object, e As EventArgs) Handles cmd_CreateExperience.Click
        ClearExperiences()
        FillExperiences()
    End Sub

    Private Sub stbDetail_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles stbDetail.ItemClicked

    End Sub


    Private Sub ToolStripSeparator1_Click(sender As Object, e As EventArgs) Handles ToolStripSeparator1.Click

    End Sub

    Private Sub tbPersonal_Click(sender As Object, e As EventArgs) Handles tbPersonal.Click

    End Sub

    Private Sub cbBloodGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBloodGroup.SelectedIndexChanged

    End Sub

    Private Sub Label63_Click(sender As Object, e As EventArgs) Handles Label63.Click

    End Sub

    Private Sub cbDomicile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDomicile.SelectedIndexChanged

    End Sub

    Private Sub Label101_Click(sender As Object, e As EventArgs) Handles Label101.Click

    End Sub

    Private Sub txtCNICNew_TextChanged(sender As Object, e As EventArgs) Handles txtCNICNew.TextChanged

    End Sub

    Private Sub Label102_Click(sender As Object, e As EventArgs) Handles Label102.Click

    End Sub

    Private Sub Label100_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub txtEmpID_TextChanged(sender As Object, e As EventArgs) Handles txtEmpID.TextChanged

    End Sub

    Private Sub pbEmployeePhoto_Click(sender As Object, e As EventArgs) Handles pbEmployeePhoto.Click

    End Sub

    Private Sub dtpStatusSince_ValueChanged(sender As Object, e As EventArgs) Handles dtpStatusSince.ValueChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub cbMaritalStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMaritalStatus.SelectedIndexChanged

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub cbBirthCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBirthCity.SelectedIndexChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged

    End Sub

    Private Sub cbNationality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNationality.SelectedIndexChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub cbReligion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReligion.SelectedIndexChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub cbGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGender.SelectedIndexChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub txtFatherName_TextChanged(sender As Object, e As EventArgs) Handles txtFatherName.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtMiddleName_TextChanged(sender As Object, e As EventArgs) Handles txtMiddleName.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub txtEmployeeNo_TextChanged(sender As Object, e As EventArgs) Handles txtEmployeeNo.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub tbFCCL_Click(sender As Object, e As EventArgs) Handles tbFCCL.Click

    End Sub

    Private Sub cbJoinedAs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbJoinedAs.SelectedIndexChanged

    End Sub

    Private Sub Label103_Click(sender As Object, e As EventArgs) Handles Label103.Click

    End Sub

    Private Sub Label99_Click(sender As Object, e As EventArgs) Handles Label99.Click

    End Sub

    Private Sub dtpRetirementDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpRetirementDate.ValueChanged

    End Sub

    Private Sub cbCorps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCorps.SelectedIndexChanged

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click

    End Sub

    Private Sub txtTradeAppointment_TextChanged(sender As Object, e As EventArgs) Handles txtTradeAppointment.TextChanged

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click

    End Sub

    Private Sub dtpDateRetired_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateRetired.ValueChanged

    End Sub

    Private Sub cbRank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRank.SelectedIndexChanged

    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

    End Sub

    Private Sub txtJobDescription_TextChanged(sender As Object, e As EventArgs) Handles txtJobDescription.TextChanged

    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click

    End Sub

    Private Sub txtSupervisor_TextChanged(sender As Object, e As EventArgs) Handles txtSupervisor.TextChanged

    End Sub

    Private Sub txtHOD_TextChanged(sender As Object, e As EventArgs) Handles txtHOD.TextChanged

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub chkIsTechnical_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsTechnical.CheckedChanged

    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub dtpGradeEffectiveDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpGradeEffectiveDate.ValueChanged

    End Sub

    Private Sub cbGrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrade.SelectedIndexChanged

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub cbEmployeeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEmployeeType.SelectedIndexChanged

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub dtpProbationEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpProbationEndDate.ValueChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub dtpConfirmationDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpConfirmationDate.ValueChanged

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub dtpContractEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpContractEndDate.ValueChanged

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub dtpContractStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpContractStartDate.ValueChanged

    End Sub

    Private Sub cbContractType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbContractType.SelectedIndexChanged

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub dtpJoiningDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpJoiningDate.ValueChanged

    End Sub

    Private Sub cbDesignation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDesignation.SelectedIndexChanged

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub cbBusinessUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBusinessUnit.SelectedIndexChanged

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub tbExperience_Click(sender As Object, e As EventArgs) Handles tbExperience.Click

    End Sub

    Private Sub cbExperienceIndustry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExperienceIndustry.SelectedIndexChanged

    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) Handles Label61.Click

    End Sub

    Private Sub grdExperiences_Click(sender As Object, e As EventArgs) Handles grdExperiences.Click

    End Sub

    Private Sub txtExperienceReasonForLeaving_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceReasonForLeaving.TextChanged

    End Sub

    Private Sub Label77_Click(sender As Object, e As EventArgs) Handles Label77.Click

    End Sub

    Private Sub txtExperienceJobDescription_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceJobDescription.TextChanged

    End Sub

    Private Sub Label78_Click(sender As Object, e As EventArgs) Handles Label78.Click

    End Sub

    Private Sub txtExperienceBenefits_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceBenefits.TextChanged

    End Sub

    Private Sub Label79_Click(sender As Object, e As EventArgs) Handles Label79.Click

    End Sub

    Private Sub txtExperienceSalary_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceSalary.TextChanged

    End Sub

    Private Sub Label80_Click(sender As Object, e As EventArgs) Handles Label80.Click

    End Sub

    Private Sub dtpExperienceFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpExperienceFromDate.ValueChanged

    End Sub

    Private Sub cbExperienceCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbExperienceCity.SelectedIndexChanged

    End Sub

    Private Sub Label81_Click(sender As Object, e As EventArgs) Handles Label81.Click

    End Sub

    Private Sub labelexperience_Click(sender As Object, e As EventArgs) Handles labelexperience.Click

    End Sub

    Private Sub Label83_Click(sender As Object, e As EventArgs) Handles Label83.Click

    End Sub

    Private Sub dtpExperienceToDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpExperienceToDate.ValueChanged

    End Sub

    Private Sub Label84_Click(sender As Object, e As EventArgs) Handles Label84.Click

    End Sub

    Private Sub txtExperienceDesignation_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceDesignation.TextChanged

    End Sub

    Private Sub Label85_Click(sender As Object, e As EventArgs) Handles Label85.Click

    End Sub

    Private Sub txtExperienceEmployer_TextChanged(sender As Object, e As EventArgs) Handles txtExperienceEmployer.TextChanged

    End Sub

    Private Sub Label86_Click(sender As Object, e As EventArgs) Handles Label86.Click

    End Sub

    Private Sub tbQualifications_Click(sender As Object, e As EventArgs) Handles tbQualifications.Click

    End Sub

    Private Sub txtQualificationEndYear_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationEndYear.TextChanged

    End Sub

    Private Sub txtQualificationStartYear_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationStartYear.TextChanged

    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub radQualificationProfessional_CheckedChanged(sender As Object, e As EventArgs) Handles radQualificationProfessional.CheckedChanged

    End Sub

    Private Sub radQualificationAcademic_CheckedChanged(sender As Object, e As EventArgs) Handles radQualificationAcademic.CheckedChanged

    End Sub

    Private Sub Label82_Click(sender As Object, e As EventArgs) Handles Label82.Click

    End Sub

    Private Sub Label87_Click(sender As Object, e As EventArgs) Handles Label87.Click

    End Sub

    Private Sub Label88_Click(sender As Object, e As EventArgs) Handles Label88.Click

    End Sub

    Private Sub txtQualificationOtherInstitution_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationOtherInstitution.TextChanged

    End Sub

    Private Sub cbQualificationInstitution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQualificationInstitution.SelectedIndexChanged

    End Sub

    Private Sub txtQualificationGradeGPA_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationGradeGPA.TextChanged

    End Sub

    Private Sub txtQualificationMajors_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationMajors.TextChanged

    End Sub

    Private Sub cbQualificationDegree_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQualificationDegree.SelectedIndexChanged

    End Sub

    Private Sub grdQualifications_Click(sender As Object, e As EventArgs) Handles grdQualifications.Click

    End Sub

    Private Sub txtQualificationDistinctions_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationDistinctions.TextChanged

    End Sub

    Private Sub Label89_Click(sender As Object, e As EventArgs) Handles Label89.Click

    End Sub

    Private Sub txtQualificationExtraCurricular_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationExtraCurricular.TextChanged

    End Sub

    Private Sub Label90_Click(sender As Object, e As EventArgs) Handles Label90.Click

    End Sub

    Private Sub Label91_Click(sender As Object, e As EventArgs) Handles Label91.Click

    End Sub

    Private Sub Label92_Click(sender As Object, e As EventArgs) Handles Label92.Click

    End Sub

    Private Sub cbQualificationCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbQualificationCity.SelectedIndexChanged

    End Sub

    Private Sub Label93_Click(sender As Object, e As EventArgs) Handles Label93.Click

    End Sub

    Private Sub Label94_Click(sender As Object, e As EventArgs) Handles Label94.Click

    End Sub

    Private Sub Label95_Click(sender As Object, e As EventArgs) Handles Label95.Click

    End Sub

    Private Sub Label96_Click(sender As Object, e As EventArgs) Handles Label96.Click

    End Sub

    Private Sub txtQualificationOtherDegree_TextChanged(sender As Object, e As EventArgs) Handles txtQualificationOtherDegree.TextChanged

    End Sub

    Private Sub Label97_Click(sender As Object, e As EventArgs) Handles Label97.Click

    End Sub

    Private Sub Label98_Click(sender As Object, e As EventArgs) Handles Label98.Click

    End Sub

    Private Sub tbContacts_Click(sender As Object, e As EventArgs) Handles tbContacts.Click

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub txtOfficialEmail_TextChanged(sender As Object, e As EventArgs) Handles txtOfficialEmail.TextChanged

    End Sub

    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.Click

    End Sub

    Private Sub GroupBox6_Enter(sender As Object, e As EventArgs) Handles GroupBox6.Enter

    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged

    End Sub

    Private Sub Label55_Click(sender As Object, e As EventArgs) Handles Label55.Click

    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged

    End Sub

    Private Sub Label56_Click(sender As Object, e As EventArgs) Handles Label56.Click

    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs) Handles Label57.Click

    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click

    End Sub

    Private Sub txtPersonalEmail_TextChanged(sender As Object, e As EventArgs) Handles txtPersonalEmail.TextChanged

    End Sub

    Private Sub Label64_Click(sender As Object, e As EventArgs) Handles Label64.Click

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged

    End Sub

    Private Sub Label46_Click(sender As Object, e As EventArgs) Handles Label46.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label47_Click(sender As Object, e As EventArgs) Handles Label47.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub Label49_Click(sender As Object, e As EventArgs) Handles Label49.Click

    End Sub

    Private Sub cbPermanentCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPermanentCity.SelectedIndexChanged

    End Sub

    Private Sub Label50_Click(sender As Object, e As EventArgs) Handles Label50.Click

    End Sub

    Private Sub Label51_Click(sender As Object, e As EventArgs) Handles Label51.Click

    End Sub

    Private Sub txtPermanentPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPermanentPhone.TextChanged

    End Sub

    Private Sub Label53_Click(sender As Object, e As EventArgs) Handles Label53.Click

    End Sub

    Private Sub txtPermanentAddress_TextChanged(sender As Object, e As EventArgs) Handles txtPermanentAddress.TextChanged

    End Sub

    Private Sub Label54_Click(sender As Object, e As EventArgs) Handles Label54.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click

    End Sub

    Private Sub cbPresentCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPresentCity.SelectedIndexChanged

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub txtPresentMobile_TextChanged(sender As Object, e As EventArgs) Handles txtPresentMobile.TextChanged

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub txtPresentPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPresentPhone.TextChanged

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Private Sub txtPresentAddress_TextChanged(sender As Object, e As EventArgs) Handles txtPresentAddress.TextChanged

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub tbDependents_Click(sender As Object, e As EventArgs) Handles tbDependents.Click

    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs) Handles Label76.Click

    End Sub

    Private Sub cbDependentGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDependentGender.SelectedIndexChanged

    End Sub

    Private Sub chkDependentInsurance_CheckedChanged(sender As Object, e As EventArgs) Handles chkDependentInsurance.CheckedChanged

    End Sub

    Private Sub dtpDependentDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDependentDOB.ValueChanged

    End Sub

    Private Sub cbDependentRelation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDependentRelation.SelectedIndexChanged

    End Sub

    Private Sub Label52_Click(sender As Object, e As EventArgs) Handles Label52.Click

    End Sub

    Private Sub cbDependentMaritalStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDependentMaritalStatus.SelectedIndexChanged

    End Sub

    Private Sub Label71_Click(sender As Object, e As EventArgs) Handles Label71.Click

    End Sub

    Private Sub Label72_Click(sender As Object, e As EventArgs) Handles Label72.Click

    End Sub

    Private Sub dtpDependentStatusSince_ValueChanged(sender As Object, e As EventArgs) Handles dtpDependentStatusSince.ValueChanged

    End Sub

    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click

    End Sub

    Private Sub txtDependentCNIC_TextChanged(sender As Object, e As EventArgs) Handles txtDependentCNIC.TextChanged

    End Sub

    Private Sub Label74_Click(sender As Object, e As EventArgs) Handles Label74.Click

    End Sub

    Private Sub txtDependentName_TextChanged(sender As Object, e As EventArgs) Handles txtDependentName.TextChanged

    End Sub

    Private Sub Label75_Click(sender As Object, e As EventArgs) Handles Label75.Click

    End Sub

    Private Sub cbMisc_Click(sender As Object, e As EventArgs) Handles tbMisc.Click

    End Sub

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click

    End Sub

    Private Sub dtpPassportIssueDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpPassportIssueDate.ValueChanged

    End Sub

    Private Sub Label70_Click(sender As Object, e As EventArgs) Handles Label70.Click

    End Sub

    Private Sub dtpPassportExpiryDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpPassportExpiryDate.ValueChanged

    End Sub

    Private Sub cbPassportCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPassportCountry.SelectedIndexChanged

    End Sub

    Private Sub Label67_Click(sender As Object, e As EventArgs) Handles Label67.Click

    End Sub

    Private Sub txtPassportNo_TextChanged(sender As Object, e As EventArgs) Handles txtPassportNo.TextChanged

    End Sub

    Private Sub Label68_Click(sender As Object, e As EventArgs) Handles Label68.Click

    End Sub

    Private Sub Label66_Click(sender As Object, e As EventArgs) Handles Label66.Click

    End Sub

    Private Sub txtNTN_TextChanged(sender As Object, e As EventArgs) Handles txtNTN.TextChanged

    End Sub

    Private Sub txtDrivingLicenseNo_TextChanged(sender As Object, e As EventArgs) Handles txtDrivingLicenseNo.TextChanged

    End Sub

    Private Sub Label62_Click(sender As Object, e As EventArgs) Handles Label62.Click

    End Sub

    Private Sub txtCNICOld_TextChanged(sender As Object, e As EventArgs) Handles txtCNICOld.TextChanged

    End Sub

    Private Sub Label65_Click(sender As Object, e As EventArgs) Handles Label65.Click

    End Sub

    Private Sub tbAudit_Click(sender As Object, e As EventArgs) Handles tbAudit.Click

    End Sub

    Private Sub grdAudit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tlbToolbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tlbToolbar.ItemClicked

    End Sub

    Private Sub slStatus_Click(sender As Object, e As EventArgs) Handles slStatus.Click

    End Sub

    Private Sub EMEmployeeAuditBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles EMEmployeeAuditBindingSource.CurrentChanged

    End Sub

    Private Sub frmEmployeeProfile_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub frmEmployeeProfile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        ''Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
        ''Dim Main As frmMdiMain = CType(Application.OpenForms("frmMdiMain"), frmMdiMain)

        ''Main.cmdApp.Visible = False
        ''Main.AppraisalsDisciiplineToolStripMenuItem.Visible = False
        ''Main.cmdStatus.Location = New Point(161, 3)

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs, Optional a_nActionID As Integer = 0) Handles cmd_SaveBankAccount.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewBankAccountId As Integer

        Try

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If txtAccountNo.Text = "" Then
                MsgBox("Please Enter Account No", vbCritical)
                txtAccountNo.Focus()
                Exit Sub
            Else
                sSql = "Select BankAccountNo From HR_EmployeeBankAccount Where BankAccountNo = '" & txtAccountNo.Text & "' "
                GetRecordSet(rsMisc, sSql)
                If txtAccountNo.Tag <> txtAccountNo.Text Then
                    If rsMisc.RecordCount <= 0 Then
                    Else
                        MessageBox.Show("Account No Already exists")
                        Exit Sub
                    End If
                End If
            End If

            If txtAccountTitle.Text = "" Then
                MsgBox("Please Enter Account Title", vbCritical)
                txtAccountTitle.Focus()
                Exit Sub
            End If

            If cbBank.SelectedIndex < 0 Then
                MsgBox("Please Select Bank", vbCritical)
                cbBank.Focus()
                Exit Sub
            End If

            bProcessing = True

            If (nBankAccountId = Nothing) Or (nBankAccountId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeBankAccount"
                GetRecordSet(rsMisc, sSql)
                nNewBankAccountId = CInt(rsMisc("Id").Value)
                nNewBankAccountId += 1
                sSql = "Insert INTO HR_EmployeeBankAccount (Id, EmployeeId, BankAccountNo, AccountTitle, BankId, BankBranch)" &
                                   "Values(" & nNewBankAccountId & ", " & nEmployeeId & ", '" & txtAccountNo.Text & "', '" & txtAccountTitle.Text &
                                   "', " & IIf(cbBank.SelectedIndex < 0, 0, cbBank.SelectedValue) & ", '" & txtBranch.Text & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeBankAccount Set BankAccountNo = '" & txtAccountNo.Text & "', AccountTitle = '" & txtAccountTitle.Text &
                                   "', BankId = " & IIf(cbBank.SelectedIndex < 0, 0, cbBank.SelectedValue) & ", BankBranch = '" & txtBranch.Text & "'Where EmployeeId=" & nEmployeeId
                conn.Execute(sSql)
            End If

            ' sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            '  Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '" & sAction & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            '  conn.Execute(sSql)

            If nEmployeeId <> Nothing Then
                sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
                If rsMain.State = 1 Then rsMain.Close()
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If
        Catch ex As Exception
            MsgBox("Error Saving Bank Account " & ex.Message)

        End Try

        Display()

        'conn.Close()

        bProcessing = False
        slStatus.Text = ""
    End Sub

    Private Sub frmEmployeeProfile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ''frmAppraisals_Discipline.Close()


    End Sub

    Private Sub cmdApp_Click(sender As Object, e As EventArgs) Handles cmdApp.Click
        'Dim f3 As frmAppraisals_Discipline = CType(Application.OpenForms("frmAppraisals_Discipline"), frmAppraisals_Discipline)
        'Dim f2 As frmEmployeeProfile = CType(Application.OpenForms("frmEmployeeProfile"), frmEmployeeProfile)

        'f3.Focus()
        'f3.WindowState = FormWindowState.Normal

        'frmAppraisals_Discipline.Show()
        'f3.txtEmployeeName = f2.txtEmployeeName


    End Sub

    Private Sub tbBankAccount_Click(sender As Object, e As EventArgs) Handles tbBankAccount.Click
        tbBankAccount.Enabled = False

    End Sub

    Private Sub frmEmployeeProfile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub tbBankAccount_MouseClick(sender As Object, e As MouseEventArgs) Handles tbBankAccount.MouseClick
        tbBankAccount.Enabled = False
    End Sub


    Private Sub TabControl1_Deselected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Deselected
        CurrentTab = e.TabPage
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        PreviousTab = e.TabPage
        'If (tbDependent.Name <> tbBank.Name) And (tbBank.Name = tbMisc.Name) Then
        '    ' MessageBox.Show("Tab disabled.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    TabControl1.SelectedTab = tbDependent
        'End If
        If TabControl1.TabPages(0).Enabled = False And PreviousTab.Name = tbPersonal.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(1).Enabled = False And PreviousTab.Name = tbFCCL.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(2).Enabled = False And PreviousTab.Name = tbExperience.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(3).Enabled = False And PreviousTab.Name = tbQualifications.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(4).Enabled = False And PreviousTab.Name = tbContacts.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(5).Enabled = False And PreviousTab.Name = tbDependents.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(6).Enabled = False And PreviousTab.Name = tbBankAccount.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(7).Enabled = False And PreviousTab.Name = tbMisc.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If

    End Sub

    Private Sub txtSendMail_Click(sender As Object, e As EventArgs) Handles txtImport.Click

        Dim rsExcel As New ADODB.Recordset
        Dim sConnStr As String, sSheetName As String

        If rsExcel.State = ADODB.ObjectStateEnum.adStateClosed Then
            rsExcel.Close()
        End If
        sConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TextBox1.Text & " ';Extended Properties=""Excel 12.0 Xml;HDR=Yes"""
        'Dim sConnStr As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TextBox1.Text & " ';Extended Properties=""Excel 12.0 Xml;HDR=Yes""")
        'sConnStr.Open()
        'Dim query_Excel As String = "Select [Id],[EmployeeNo],[FatherName] from [Sheet1$]"
        'Dim cmd As OleDbCommand = New OleDbCommand(query_Excel, sConnStr)
        'Dim sSql As String

        'Dim rd As OleDbDataReader

        'Dim conn1 As New SqlConnection
        'Dim conn1database As String = "Server=192.168.2.5;Database=ERP_FCCL;User Id=sa;Password=123456"
        ''"Server=my_server;Database=name_of_db;User Id=user_name;Password=my_password"
        'conn1.ConnectionString = conn1database

        'conn1.Open()

        'sSql = "Delete From EM_EmployeeTest1"
        'conn.Execute(sSql)

        'Using bulkcopy As New SqlClient.SqlBulkCopy(conn1)
        '    bulkcopy.DestinationTableName = "dbo.EM_EmployeeTest1"
        '    bulkcopy.ColumnMappings.Add("Id", "Id")
        '    bulkcopy.ColumnMappings.Add("EmployeeNo", "EmployeeNo")
        '    bulkcopy.ColumnMappings.Add("FatherName", "FatherName")

        '    Try
        '        rd = cmd.ExecuteReader
        '        bulkcopy.WriteToServer(rd)
        '        rd.Close()

        '        MessageBox.Show("Successfully imported data")
        '        TextBox1.Text = ""
        '    Catch ex As Exception
        '        MessageBox.Show("Error importing data" + ex.Message)
        '    End Try

        'End Using


    End Sub

    'Public Sub ReadExcelFile()
    '    On Error GoTo Err_Handler

    '    Dim RsExcel As New ADODB.Recordset, rMisc As New ADODB.Recordset
    '    Dim sConnStr As String, sSheetName As String, sTruckNo As String
    '    Dim nRow As Integer, nPos As Integer
    '    Dim sSql As String, sSql2 As String

    '    If Trim(TextBox1.Text) = "" Then Exit Sub

    '    sSheetName = Trim("All$")

    '    ' RsExcel.CursorLocation = adUseClient

    '    sConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(TextBox1.Text) & ";Extended Properties=Excel 3.0"

    '    ' If RsExcel.State = ADODB.ObjectStateEnum.adStateClosed Then RsExcel.Close()
    '    sSql = "Select * From [" & sSheetName & "]"
    '    RsExcel.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
    '    ' RsExcel.Open "Select * From [" & sSheetName & "]", sConnStr, adOpenKeyset, adLockOptimistic

    '    If RsExcel.EOF Then
    '        MessageBox.Show("No data found in the file.")
    '        'Screen.MousePointer = vbNormal
    '        Exit Sub
    '    End If

    '    RsExcel.MoveFirst()

    '    If RsExcel.RecordCount = 0 Then Exit Sub

    '    'Screen.MousePointer = vbHourglass

    '    For nRow = 0 To RsExcel.RecordCount - 1
    '        If Trim(RsExcel.Fields(0) & "") <> "" Then
    '            nCount = nCount + 1
    '            lblCount = nCount
    '            nAmount = nAmount + RsExcel.Fields(1)
    '        End If

    '        RsExcel.MoveNext()

    '    Next nRow

    '    RsExcel.Close()

    '    'Set RsExcel = Nothing

    '    'Screen.MousePointer = vbDefault

    '    Exit Sub

    '    'Err_Handler:
    '    '        conn.RollbackTrans()
    '    '        Screen.MousePointer = vbDefault
    '    '        MsgBox "Duplicate Invoice No: " & RsExcel.Fields(0) & vbLf & Err.Description, vbCritical, App.Title
    '    '    RsExcel.Close()
    '    '            Set RsExcel = Nothing
    'End Sub
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btn_Increment_Click(sender As Object, e As EventArgs) Handles btn_Increment.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset


        If btn_Increment.Text = "Enable Increment" Then
            If MsgBox("Do you want To Enable the increment ?", vbYesNo) = vbNo Then Exit Sub
        Else
            If MsgBox("Do you want To Disable the increment ?", vbYesNo) = vbNo Then Exit Sub
        End If

        If btn_Increment.Text = "Enable Increment" Then

            nIncrementId = 1

            sSql = "Update EM_Employee set nIncrementId='" & nIncrementId & "' Where Id = " & Trim(txtEmpID.Text)
            conn.Execute(sSql)

            sAction = "Enabled Increment"

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

            MessageBox.Show("Increment Enabled Successfully")
        Else
            nIncrementId = 0

            sSql = "Update EM_Employee set nIncrementId='" & nIncrementId & "' Where Id = " & Trim(txtEmpID.Text)
            conn.Execute(sSql)

            sAction = "Disabled Increment"

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

            MessageBox.Show("Increment Disabled Successfully")
        End If

        Display()
        grdAudit.Refresh()

    End Sub

    Private Sub chkConfNo_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfNo.CheckedChanged

    End Sub

    Private Sub chkConfYes_CheckedChanged(sender As Object, e As EventArgs) Handles chkConfYes.CheckedChanged

    End Sub

    Private Sub chkConfYes_Click(sender As Object, e As EventArgs) Handles chkConfYes.Click
        If chkConfYes.Checked = True Then
            chkConfNo.Checked = False
        End If
    End Sub

    Private Sub chkConfNo_Click(sender As Object, e As EventArgs) Handles chkConfNo.Click
        If chkConfNo.Checked = True Then
            chkConfYes.Checked = False
        End If
    End Sub

    Private Sub chkLFAYes_CheckedChanged(sender As Object, e As EventArgs) Handles chkLFAYes.CheckedChanged

    End Sub

    Private Sub chkLFAYes_Click(sender As Object, e As EventArgs) Handles chkLFAYes.Click
        If chkLFAYes.Checked = True Then
            chkLFANo.Checked = False
        End If
    End Sub

    Private Sub chkLFANo_CheckedChanged(sender As Object, e As EventArgs) Handles chkLFANo.CheckedChanged

    End Sub

    Private Sub chkLFANo_Click(sender As Object, e As EventArgs) Handles chkLFANo.Click
        If chkLFANo.Checked = True Then
            chkLFAYes.Checked = False
        End If
    End Sub

    Private Sub grdAudit_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkConfNo_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkConfNo.CheckedChanged

    End Sub

    Private Sub grdAudit_Click_2(sender As Object, e As EventArgs) Handles grdAudit.Click

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub
End Class