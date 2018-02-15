Imports System.Data.Odbc
Imports System.IO
Imports C1.Win.C1TrueDBGrid

Public Class frmEmployeeProfileDW
    Public rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim nDependentId As Integer
    Dim nJobId As Integer
    Dim nQualificationId As Integer
    Dim bNewImage As Boolean

    Private Sub frmEmployeeProfileDW_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.MdiParent = frmMdiMain
        Me.BringToFront()
        ''TODO: This line of code loads data into the 'DsHR.EM_Employee_Audit' table. You can move, or remove it, as needed.
        'Me.EM_Employee_AuditTableAdapter.Fill(Me.DsHR.EM_Employee_Audit)
        'TODO: This line of code loads data into the 'DsFCCL.EM_Employee_Audit' table. You can move, or remove it, as needed.
        Me.EM_Employee_AuditTableAdapter.Fill(Me.DsHR.EM_Employee_Audit)
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        PopulateControls()
        Clear()
    End Sub


    Private Sub PopulateControls()
        ' Personal Tab
        PopulateControl(cbNationality, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbBirthCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbReligion, "Select Id, Description From HR_PRMParameters Where Type = 7 Order by Description", "Id", "Description")
        PopulateControl(cbBloodGroup, "Select Distinct '1' Id, 'A+' Description From HR_PRMParameters UNION Select Distinct '2' Id, 'A-' Description From HR_PRMParameters UNION Select Distinct '3' Id, 'B+' Description From HR_PRMParameters UNION Select Distinct '4' Id, 'B-' Description From HR_PRMParameters UNION Select Distinct '5' Id, 'O+' Description From HR_PRMParameters UNION Select Distinct '6' Id, 'O-' Description From HR_PRMParameters UNION Select Distinct '7' Id, 'AB+' Description From HR_PRMParameters UNION Select Distinct '8' Id, 'AB-' Description From HR_PRMParameters", "Id", "Description")
        PopulateControl(cbDomicile, "Select Id, Description From HR_PRMParameters Where Type = 26 Order by Description", "Id", "Description")
        dtpDOB.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpStatusSince.Value = CDate(Date.Now.ToString("dd MMM yyyy"))

        ' FCCL Tab
        PopulateControl(cbBusinessUnit, "Select Id, OrganizationName From HR_PRMBusinessUnit", "Id", "OrganizationName")
        PopulateControl(cbBranch, "Select Id, BranchName From HR_PRMBranch", "Id", "BranchName")
        PopulateControl(cbDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbEmployeeType, "Select Id, Description From HR_PRMParameters Where Type = 3 And Id = 820 Order by Description", "Id", "Description")
        PopulateControl(cbGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")
    End Sub

    Private Sub cbBirthCountry_SelectIndexChanged(sender As Object, e As EventArgs) Handles cbBirthCountry.SelectedIndexChanged
        PopulateControl(cbBirthCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbBirthCountry.SelectedValue), 969, cbBirthCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        'Personal Tab
        txtEmpID.Text = ""
        txtEmpID.Tag = ""
        txtEmployeeNo.Text = ""
        txtEmployeeNo.Tag = ""
        txtEmployeeNo.Enabled = True
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
        txtCNICNew.Text = ""
        txtCNICNew.Tag = ""

        'FCCL Tab
        cbBusinessUnit.SelectedIndex = -1
        cbBusinessUnit.Tag = cbBusinessUnit.SelectedIndex
        cbBranch.SelectedIndex = -1
        cbBranch.Tag = cbBranch.SelectedIndex
        cbDepartment.SelectedIndex = -1
        cbDepartment.Tag = cbDepartment.SelectedIndex
        cbDesignation.SelectedIndex = -1
        cbDesignation.Tag = cbDesignation.SelectedIndex
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
        cbEmployeeType.SelectedIndex = -1
        cbEmployeeType.Tag = cbEmployeeType.SelectedIndex
        cbGrade.SelectedIndex = -1
        cbGrade.Tag = cbGrade.SelectedIndex
        dtpGradeEffectiveDate.Checked = False
        dtpGradeEffectiveDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpGradeEffectiveDate.Tag = dtpGradeEffectiveDate.Value
        cbDomicile.SelectedIndex = -1
        cbDomicile.Tag = cbDomicile.SelectedIndex

        grdAudit.DataSource = Nothing

        slStatus.Text = "New Employee"
    End Sub

    Private Sub Display()
        Clear()

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub

        bDisplaying = True

        'Personal Tab
        txtEmpID.Text = Convert.ToString(rsMain("Id").Value)
        txtEmpID.Tag = txtEmpID.Text
        txtEmployeeNo.Text = Convert.ToString(rsMain("EmployeeNo").Value)
        txtEmployeeNo.Tag = txtEmployeeNo.Text
        txtEmployeeNo.Enabled = False
        txtFirstName.Text = Convert.ToString(rsMain("FirstName").Value)
        txtFirstName.Tag = txtFirstName.Text
        txtMiddleName.Text = Convert.ToString(rsMain("MiddleName").Value)
        txtMiddleName.Tag = txtMiddleName.Text
        txtLastName.Text = Convert.ToString(rsMain("LastName").Value)
        txtLastName.Tag = txtLastName.Text
        txtFatherName.Text = Convert.ToString(rsMain("FatherName").Value)
        txtFatherName.Tag = txtFatherName.Text
        txtCNICNew.Text = Convert.ToString(rsMain("NewNICNo").Value)
        txtCNICNew.Tag = txtCNICNew.Text
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
        If Not IsDBNull(rsMain("PlaceOfBirthCountryId").Value) Then
            cbBirthCountry.SelectedValue = CInt(rsMain("PlaceOfBirthCountryId").Value)
            cbBirthCountry.Tag = cbBirthCountry.SelectedValue
        End If
        If Not IsDBNull(rsMain("PlaceOfBirthCityId").Value) Then
            cbBirthCity.SelectedValue = CInt(rsMain("PlaceOfBirthCityId").Value)
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

        'If Not IsDBNull(rsMain("nsStatusId").Value) Then
        '    nStatus = CInt(rsMain("nsStatusId").Value)
        'End If

        'FCCL Tab
        cbBusinessUnit.SelectedValue = CInt(rsMain("BusinessUnitId").Value)
        cbBusinessUnit.Tag = cbBusinessUnit.SelectedValue
        cbBranch.SelectedValue = CInt(rsMain("BranchId").Value)
        cbBranch.Tag = cbBranch.SelectedValue
        cbDepartment.SelectedValue = CInt(rsMain("DepartmentId").Value)
        cbDepartment.Tag = cbDepartment.SelectedValue
        cbDesignation.SelectedValue = CInt(rsMain("DesignationId").Value)
        cbDesignation.Tag = cbDesignation.SelectedValue

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

        If Not IsDBNull(rsMain("ContractEndDate").Value) Then
            dtpContractEndDate.Value = CDate(rsMain("ContractEndDate").Value)
            dtpContractEndDate.Tag = dtpContractEndDate.Value
            dtpContractEndDate.Checked = True
        Else
            dtpContractEndDate.Checked = False
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

        If Not IsDBNull(rsMain("DomicileId").Value) Then
            cbDomicile.SelectedValue = CInt(rsMain("DomicileId").Value)
            cbDomicile.Tag = cbDomicile.SelectedValue
        End If

        FillAudit()

        If nStatus = 1 Then
            slStatus.Text = "Pending"
        ElseIf nStatus = 6 Then
            slStatus.Text = "Verified"
        ElseIf nStatus = 3 Then
            slStatus.Text = "Approved"
        End If

        Me.Refresh()

        bDisplaying = False
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String ', sAction As String
        Dim rsMisc As New ADODB.Recordset
        Dim nEmpIDEM As Integer, nEmpIDHR As Integer
        Dim nEmpId As Integer

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        'If rsMain.State = ADODB.ObjectStateEnum.adStateClosed Then Exit Sub
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        bProcessing = True
        'conn.BeginTrans()

        If Trim(txtEmpID.Text) = "" Then
            If rsMain.State = ADODB.ObjectStateEnum.adStateClosed Then
                sSql = "Select * From HR_Employee Where 1 = 2"
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            rsMain.AddNew()

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
            'rsMain!CurrentStatus = 0

            nStatus = 1
            sAction = "Prepared"
        End If

        'Personal Tab
        rsMain!EmployeeNo = txtEmployeeNo.Text
        rsMain!FirstName = txtFirstName.Text
        rsMain!MiddleName = txtMiddleName.Text
        rsMain!LastName = txtLastName.Text
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

        rsMain!PlaceOfBirthCountryId = CInt(cbBirthCountry.SelectedValue)
        rsMain!PlaceOfBirthCityId = CInt(cbBirthCity.SelectedValue)

        If cbBloodGroup.SelectedIndex <> -1 Then
            rsMain!BloodGroup = CInt(cbBloodGroup.SelectedValue)
        Else
            rsMain!BloodGroup = 0
        End If

        If cbDomicile.SelectedIndex <> -1 Then
            rsMain!DomicileId = CInt(cbDomicile.SelectedValue)
        Else
            rsMain!DomicileId = 0
        End If

        rsMain!NewNICNo = txtCNICNew.Text
        'If Not pbEmployeePhoto.Image Is Nothing Then
        If bNewImage = True Then
            Dim ms As New MemoryStream()
            pbEmployeePhoto.Image.Save(ms, pbEmployeePhoto.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            rsMain!Picture = data
        End If

        'rsMain!nsStatusId = nStatus

        'FCCL Tab
        rsMain!BusinessUnitId = CInt(cbBusinessUnit.SelectedValue)
        rsMain!BranchId = CInt(cbBranch.SelectedValue)
        rsMain!DepartmentId = CInt(cbDepartment.SelectedValue)
        rsMain!DesignationId = CInt(cbDesignation.SelectedValue)

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

        rsMain!EmployeeTypeId = CInt(cbEmployeeType.SelectedValue)
        rsMain!EmployeeGradeId = CInt(cbGrade.SelectedValue)

        If dtpGradeEffectiveDate.Checked = True Then
            rsMain!GradeEffectiveDate = CDate(dtpGradeEffectiveDate.Value.ToString("dd MMM yyyy"))
        Else
            rsMain!GradeEffectiveDate = DBNull.Value
        End If


        'rsMain!nSectionId = 0
        'rsMain!vcVehicleAccCode = "1"
        'rsMain!vcMobileAccCode = "1"
        rsMain.Update()

        sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           txtEmpID.Text & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        'conn.CommitTrans()

        If nStatus = 1 Then
            MsgBox("Daily Wager saved successfully.", vbInformation)
        End If

        Display()

        bProcessing = False
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        ValidateFields = False

        'If Trim(txtEmpID.Text) <> "" Then
        '    sSql = "Select nsStatusId From EM_Employee Where Id = " & txtEmpID.Text
        '    GetRecordSet(rsMisc, sSql)

        '    If rsMisc.RecordCount > 0 Then nStatus = CInt(rsMisc("nsStatusId").Value)
        '    rsMisc.Close()
        'End If

        'If nStatus = 3 Then
        '    MsgBox("Invalid Action.", vbCritical)
        '    Exit Function
        'End If

        If txtEmpID.Text = "" Then
            If Trim(txtEmployeeNo.Text) <> "" Then
                sSql = "Select EmployeeNo From HR_Employee Where EmployeeNo = '" & txtEmployeeNo.Text & "'"
                GetRecordSet(rsMisc, sSql)

                If rsMisc.RecordCount > 0 Then
                    MsgBox("Employee No aleady exists.", vbCritical)
                    txtEmployeeNo.Focus()
                    Exit Function
                End If
            End If
        End If

        If txtEmployeeNo.Text = "" Then
            MsgBox("Please enter employee no.", vbCritical)
            txtEmployeeNo.Focus()
            Exit Function
        End If

        If txtFirstName.Text = "" Then
            MsgBox("Please enter first name.", vbCritical)
            txtFirstName.Focus()
            Exit Function
        End If

        If txtLastName.Text = "" Then
            MsgBox("Please enter last name.", vbCritical)
            txtLastName.Focus()
            Exit Function
        End If

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

        If cbMaritalStatus.SelectedItem = Nothing Then
            MsgBox("Please select marital status.", vbCritical)
            cbMaritalStatus.Focus()
            Exit Function
        End If

        If cbBusinessUnit.SelectedIndex = -1 Then
            MsgBox("Please select business unit.", vbCritical)
            cbBusinessUnit.Focus()
            Exit Function
        End If

        If cbBranch.SelectedIndex = -1 Then
            MsgBox("Please select branch.", vbCritical)
            cbBranch.Focus()
            Exit Function
        End If


        If cbDepartment.SelectedIndex = -1 Then
            MsgBox("Please select department.", vbCritical)
            cbDepartment.Focus()
            Exit Function
        End If


        If cbDesignation.SelectedIndex = -1 Then
            MsgBox("Please select designation.", vbCritical)
            cbDesignation.Focus()
            Exit Function
        End If

        If cbEmployeeType.SelectedIndex = -1 Then
            MsgBox("Please select employee type.", vbCritical)
            cbEmployeeType.Focus()
            Exit Function
        End If


        If cbContractType.SelectedIndex = -1 Then
            MsgBox("Please select contract type.", vbCritical)
            cbContractType.Focus()
            Exit Function
        End If


        If Trim(txtEmpID.Tag) = "" Then
            sAction = "Prepared"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            slStatus.Text = "Approved"
        End If

        ValidateFields = True
    End Function

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmpID.Text) = "" Then Exit Sub

        If nStatus = 3 Then
            MsgBox("Invalid Action.", vbInformation)
            Exit Sub
        End If

        If MsgBox("Do you want to Delete the Record?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From EM_Employee_Audit Where vcDocumentId = '" & Trim(txtEmpID.Text) & "'"
        conn.Execute(sSql)

        rsMain.Delete()
        Clear()

        MsgBox("Daily Wager deleted successfully.", vbInformation)
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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If (txtEmployeeNo.Text = "") Or IsAnyFieldChanged() Then Exit Sub

        slStatus.Text = "Saving"

        Call Save()

        slStatus.Text = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        slStatus.Text = "Deleting"
        Call Delete()
        slStatus.Text = ""
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Employee Profile DW"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub


    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Save(4)
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Save(5)
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged
        If cbBranch.SelectedIndex <> -1 Then
            PopulateControl(cbDepartment, "Select Id, Description From HR_PRMDepartments Where BranchId = " + cbBranch.SelectedValue.ToString() + " Order by Description", "Id", "Description")
        End If
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_Employee_Audit Where vcDocumentId = '" + txtEmpID.Text + "' Order by dtmActionDate"

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

    Private Sub frmEmployeeProfile_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
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

End Class