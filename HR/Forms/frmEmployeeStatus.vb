Imports System.Net.Mail
Imports System.Net

Imports System.Net.Security

Imports System.Security.Cryptography.X509Certificates


Public Class frmEmployeeStatus
    Dim nEmployeeId As Integer = Nothing
    Dim nIsActive As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim nStatus As Integer
    Dim sAction As String
    Dim nDocumentNo As Integer
    Dim rsMisc As ADODB.Recordset
    Dim sStatus As String
    Dim sDate As String
    Dim bEmail As Boolean
    Dim sEmpNo As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Shared Function customCertValidation(ByVal sender As Object,
                                                ByVal cert As X509Certificate,
                                                ByVal chain As X509Chain,
                                                ByVal errors As SslPolicyErrors) As Boolean

        Return True

    End Function

    Private Sub frmEmployeeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        Me.Location = New Point(0, 0)
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Clear()
        UserRights(rsMisc)
    End Sub

    Public Sub UserRights(ByRef rsMisc As ADODB.Recordset)

        Dim sSql As String
        Dim Button As String
        Dim TabControlRights As String

        Try

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

            'sSql = "Select a.nActionId, a.vcName,a.vcDocType, b.vcUserId from ComActionCodes a, ComAccessRights b " &
            '   "Where a.nActionId = b.nActionId And a.vcDocType = b.vcDocId And " &
            '   "b.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "'  And a.vcDocType = 'emsEmployee'"
            'GetRecordSet(rsMisc, sSql)
            sSql = "Select vcName, nGroupId, vcUserId,nActionId From((Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId,comActionCodes.nActionId From ComAccessRights, comActionCodes, ComUserGroups " &
                    " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                    "And comActionCodes.nActionId = ComAccessRights.nActionId " &
                    " And ComAccessRights.vcDocId ='emsEmpStatus'  " &
                    "And ComUserGroups.nGroupId = ComAccessRights.nGroupId " &
                    "And ComUserGroups.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "') " &
                    " Union (Select comActionCodes.vcName, ComAccessRights.nGroupId, ComAccessRights.vcUserId,comActionCodes.nActionId " &
                    " From ComAccessRights, comActionCodes " &
                    " Where comActionCodes.vcDocType = ComAccessRights.vcDocId " &
                    " And comActionCodes.nActionId = ComAccessRights.nActionId And " &
                    "ComAccessRights.nGroupId = 0  " &
                    " And ComAccessRights.vcDocId ='emsEmpStatus' " &
                    " And ComAccessRights.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "')) g Order by nActionId  "
            GetRecordSet(rsMisc, sSql)

            While Not rsMisc.EOF
                Button = "btn_" & rsMisc("vcName").Value
                TabControlRights = "tb" & rsMisc("vcName").Value
                If Button = "btn_Prepare" Then
                    btn_Prepare.Enabled = True
                ElseIf Button = "btn_Modify" Then
                    btn_Modify.Enabled = True
                ElseIf Button = "btn_Delete" Then
                    btn_Delete.Enabled = True
                ElseIf Button = "btn_Approve" Then
                    btn_Approve.Enabled = True
                End If
                rsMisc.MoveNext()
            End While

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub


    Private Sub Clear()
        txtDocumentNo.Text = ""
        txtDocumentNo.Tag = ""
        nEmployeeId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbStatus.SelectedIndex = -1
        cbStatus.Tag = cbStatus.SelectedIndex
        dtpDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Tag = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Checked = False
        txtRemarks.Text = ""
        txtRemarks.Tag = ""
        nStatus = Nothing
        slStatus.Text = "New"

        FillAudit()
    End Sub

    Private Sub Display()
        Clear()
        Dim rsEmployeeName As New ADODB.Recordset
        Dim sSql As String


        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        txtDocumentNo.Text = Convert.ToString(rsMain("vcDocumentNo").Value)
        txtDocumentNo.Tag = txtDocumentNo.Text
        nEmployeeId = CInt(rsMain("nEmployeeId").Value)
        nDocumentNo = CInt(rsMain("nDocumentNo").Value)

        sSql = "Select FullName, EmployeeNo From EM_Employee Where Id = " & nEmployeeId
        rsEmployeeName.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        txtEmployeeName.Text = Convert.ToString(rsEmployeeName("FullName").Value)
        txtEmployeeName.Tag = txtEmployeeName.Text
        sEmpNo = Convert.ToString(rsEmployeeName("EmployeeNo").Value)

        If Not IsDBNull(rsMain("nStatusId").Value) Then
            cbStatus.SelectedIndex = CInt(rsMain("nStatusId").Value)
            cbStatus.Tag = cbStatus.SelectedIndex
        End If

        If Not IsDBNull(rsMain("dtmDate").Value) Then
            dtpDate.Value = CDate(rsMain("dtmDate").Value)
            dtpDate.Tag = dtpDate.Value
            dtpDate.Checked = True
        Else
            dtpDate.Checked = False
        End If

        If Not IsDBNull(rsMain("vcRemarks").Value) Then
            txtRemarks.Text = Convert.ToString(rsMain("vcRemarks").Value)
            txtRemarks.Tag = txtRemarks.Text
        End If

        nStatus = CInt(rsMain("nsStatusId").Value)
        If nStatus = 3 Then
            slStatus.Text = "Approved"
        Else
            slStatus.Text = "Pending"
        End If

        FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Public Sub SearchRecords(ByVal a_sSql As String, ByVal a_sDocNo As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("vcDocumentNo = '" & a_sDocNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim nEmployeeStatus As Integer
        Dim rsMisc As New ADODB.Recordset

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        If Trim(txtDocumentNo.Text) = "" Then
            If rsMain.State <> 1 Then
                sSql = "Select * From EM_EmployeeStatus Where 1 = 2"
                rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            End If

            rsMain.AddNew()

            sSql = "Select MAX(nDocumentNo) nDocumentNo From EM_EmployeeStatus"
            rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

            If Not IsDBNull(rsMisc("nDocumentNo").Value) Then
                nDocumentNo = CInt(rsMisc("nDocumentNo").Value)
                nDocumentNo = nDocumentNo + 1
            Else
                nDocumentNo = 1
            End If

            txtDocumentNo.Text = "EMPST-1-" & nDocumentNo

            rsMain!vcDocumentNo = txtDocumentNo.Text
            rsMain!nDocumentNo = nDocumentNo
            nStatus = 1
            sAction = "Prepared"
        End If

        rsMain!nEmployeeId = nEmployeeId
        rsMain!nStatusId = cbStatus.SelectedIndex
        rsMain!dtmDate = dtpDate.Value
        rsMain!vcRemarks = txtRemarks.Text
        rsMain!nsStatusId = nStatus
        rsMain.Update()

        If nStatus = 3 Then
            sSql = "Update EM_Employee Set isActive = " & nIsActive & ", CurrentStatus = " & cbStatus.SelectedIndex & " Where Id = " & nEmployeeId
            conn.Execute(sSql)
            sAction = "Approved"

            sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
                nEmployeeId & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & cbStatus.SelectedItem & "', '" & sUserId & "', 'Status changed.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

            If (cbStatus.SelectedIndex = 5) Or (cbStatus.SelectedIndex = 0) Then
                nEmployeeStatus = 1
            Else
                nEmployeeStatus = 2
            End If
            sSql = "Insert Into HR_EmployeeActivationHistory (EmployeeId, ActionId, StatusId, FromDate, Reason, nCurrentStatus) " &
                   "Values(" & nEmployeeId & ", 3, " & nEmployeeStatus & ", '" & dtpDate.Value.ToString("dd MMM yyyy") & "', '" & cbStatus.Text & "', 4)"

            conn.Execute(sSql)
        End If

        'Try
        '    bProcessing = True

        '    sSql = "Update EM_Employee Set isActive = " & nIsActive & ", CurrentStatus = " & cbStatus.SelectedIndex & " Where Id = " & nEmployeeId
        '    conn.Execute(sSql)
        '    conn.CommitTrans()

        '    sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
        '   Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), 'Modified', '" & sUserId & "', 'Updated employee status.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        '    conn.Execute(sSql)

        'Catch ex As Exception
        '    MessageBox.Show("Error saving record.")
        'End Try

        sSql = "Insert Into EM_EmployeeStatusAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Trim(txtDocumentNo.Text) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        conn.Execute(sSql)

        MsgBox("Employee status saved.",)
        'GenerateMails()
        If g_nCompanyId = 1 Then
            GenerateMails()
        ElseIf g_nCompanyId = 2 Then
            GenerateMailsAcl()
        End If
        Display()

        bProcessing = False
    End Sub

    Private Function GenerateMails() As Boolean
        Dim sSql As String
        Dim rsMail As New ADODB.Recordset
        Dim rsEmailInt As New ADODB.Recordset
        Dim EmpDepartment As String
        Dim EmpDesignation As String
        Dim EmpBranchId As Integer
        Dim EmpBranch As String
        Dim EmpOfficialEmail As String
        If bEmail <> True Then Exit Function
        Dim EmailEmp As Integer
        Dim ContactEmail As String
        Dim EmpCount As Integer
        Dim EmailIntimation As String
        Dim ExitEmailBranch As Integer
        Dim rsMisc As New ADODB.Recordset
        Dim rsCont As New ADODB.Recordset

        sSql = "Select dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment,dbo.ufn_GetBranchName(BranchId)vcBranch,ContactOfficialEmail,BranchId,dbo.ufn_GetBranchName(BranchId)vcBranch From EM_Employee Where EmployeeNo='" & sEmpNo & "'"
        GetRecordSet(rsMail, sSql)

        EmpDepartment = Convert.ToString(rsMail("vcDepartment").Value)
        EmpDesignation = Convert.ToString(rsMail("vcDesignation").Value)
        EmpBranchId = Convert.ToInt32(rsMail("BranchId").Value)
        EmpBranch = Convert.ToString(rsMail("vcBranch").Value)
        EmpOfficialEmail = Convert.ToString(rsMail("ContactOfficialEmail").Value)

        EmpCount = 1
        EmailIntimation = "EmpExitEmail_Emp" & EmpCount

        sSql = "Select vcPrefName,vcPrefValue from EM_SysPreferences where vcPrefName Like '%EmpExitEmail_Emp%'"
        GetRecordSet(rsEmailInt, sSql)

        If rsEmailInt.RecordCount > 0 Then

            While Not rsEmailInt.EOF

                EmailIntimation = "EmpExitEmail_Emp" & EmpCount

                sSql = "Select vcPrefName,vcPrefValue from EM_SysPreferences where vcPrefName='" & EmailIntimation & "' "
                GetRecordSet(rsMisc, sSql)

                If rsMisc.EOF Then Exit Function

                EmailEmp = Convert.ToInt32(rsMisc("vcPrefValue").Value)

                sSql = "Select BranchId,ContactOfficialEmail from EM_Employee where EmployeeNo='" & EmailEmp & "'"
                GetRecordSet(rsCont, sSql)

                ContactEmail = Convert.ToString(rsCont("ContactOfficialEmail").Value)
                ExitEmailBranch = Convert.ToInt32(rsCont("BranchId").Value)

                If (EmpBranchId = ExitEmailBranch Or EmpBranchId = 2) And ExitEmailBranch <> 6 Then
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
                        e_mail.To.Add(ContactEmail)
                        'e_mail.To.Add("arslan.ahmed@fccl.com.pk")
                        e_mail.Subject = "Employee Status Updated"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Status of following Employee has been changed:" + vbNewLine + vbNewLine '( " & sEmpNo & " - " & txtEmployeeName.Text & " )
                        e_mail.Body = e_mail.Body & "Employee No : " & sEmpNo & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Employee Name: " & txtEmployeeName.Text & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Designation: " & EmpDesignation & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Department: " & EmpDepartment & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Location: " & EmpBranch & "" + vbNewLine
                        If EmpOfficialEmail = "" Then
                            e_mail.Body = e_mail.Body & "Email: No email exists" + vbNewLine + vbNewLine
                        Else
                            e_mail.Body = e_mail.Body & "Email: " & EmpOfficialEmail & "" + vbNewLine + vbNewLine
                        End If

                        If sStatus <> "" Then
                            e_mail.Body = e_mail.Body & "Employee status has been changed to : " & cbStatus.Text + vbNewLine
                            e_mail.Body = e_mail.Body & "Dated : " & dtpDate.Text + vbNewLine + vbNewLine
                            e_mail.Body = e_mail.Body & "Changes made by: " & g_sLoggedInUser + vbNewLine
                        End If
                        e_mail.Body = e_mail.Body + vbNewLine + vbNewLine
                        e_mail.Body = e_mail.Body & "Regards" + vbNewLine
                        e_mail.Body = e_mail.Body & "HR Department" + vbNewLine
                        e_mail.Body = e_mail.Body & "Fauji Cement Company Limited." + vbNewLine

                        ServicePointManager.ServerCertificateValidationCallback =
                        New System.Net.Security.RemoteCertificateValidationCallback(AddressOf customCertValidation)
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Send(e_mail)

                        bEmail = False


                    Catch error_t As Exception
                        MsgBox(error_t.ToString)
                    End Try

                End If

                If EmpBranchId = 6 Then

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
                        e_mail.To.Add(ContactEmail)
                        'e_mail.To.Add("arslan.ahmed@fccl.com.pk")
                        e_mail.Subject = "Employee Status Updated"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Status of following Employee has been changed" + vbNewLine + vbNewLine '( " & sEmpNo & " - " & txtEmployeeName.Text & " )
                        e_mail.Body = e_mail.Body & "Employee No : " & sEmpNo & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Employee Name: " & txtEmployeeName.Text & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Designation: " & EmpDesignation & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Department: " & EmpDepartment & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Location: " & EmpBranch & "" + vbNewLine
                        If EmpOfficialEmail = "" Then
                            e_mail.Body = e_mail.Body & "Email: No Email Exists" + vbNewLine + vbNewLine
                        Else
                            e_mail.Body = e_mail.Body & "Email: " & EmpOfficialEmail & "" + vbNewLine + vbNewLine
                        End If

                        If sStatus <> "" Then
                            e_mail.Body = e_mail.Body & "Employee status has been changed to : " & cbStatus.Text + vbNewLine
                            e_mail.Body = e_mail.Body & "Dated : " & dtpDate.Text + vbNewLine + vbNewLine
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

                        bEmail = False


                    Catch error_t As Exception
                        MsgBox(error_t.ToString)
                    End Try

                End If

                EmpCount = EmpCount + 1

                    rsEmailInt.MoveNext()

            End While

            Return bEmail
        End If

    End Function

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_EmployeeStatusAudit Where vcDocumentId = '" + Trim(txtDocumentNo.Text) + "' Order by dtmActionDate"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = Nothing
            grdAudit.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading audit entries.")
        End Try
        connODBC.Close()
        grdAudit.Refresh()
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        Dim rsMisc As New ADODB.Recordset

        ValidateFields = False

        If a_nActionID = 4 Then
            If cbStatus.Tag <> cbStatus.SelectedValue Then
                bEmail = True
                sStatus = cbStatus.Text
            Else
                MsgBox("Invalid action.", vbCritical)
            End If
        End If

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If cbStatus.SelectedIndex <0 Then
            MsgBox("Please select status.", vbCritical)
            cbStatus.Focus()
            Exit Function
        End If

        If dtpDate.Checked = False Then
            MsgBox("Please select date.", vbCritical)
            dtpDate.Focus()
            Exit Function
        End If

        If (cbStatus.SelectedIndex = 0) Or (cbStatus.SelectedIndex = 5) Then
            nIsActive = 1
        Else
            nIsActive = 0
        End If

        sAction = "Prepared"
        If Trim(txtDocumentNo.Tag) <> "" Then
            sAction = "Modified"
            If a_nActionID = 4 Then
                nStatus = 3
                sAction = "Approved"
            End If
        End If

        'If Trim(txtDocumentNo.Tag) = "" Then
        '    sAction = "Prepared"
        '    nStatus = 1
        '    slStatus.Text = "Pending"
        'ElseIf a_nActionID = 0 Then 'Modify
        '    sAction = "Modified"
        '    nStatus = 1
        '    slStatus.Text = "Pending"
        'ElseIf a_nActionID = 3 Then
        '    sAction = "Approved"
        '    nStatus = 3
        '    slStatus.Text = "Approved"
        'End If

        ValidateFields = True
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btn_Modify.Click
        'If IsAnyFieldChanged() Then Exit Sub

        slStatus.Text = "Saving"

        Save()

        slStatus.Text = ""
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btn_Prepare.Click
        Clear()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btn_Approve.Click
        Save(4)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeStatusSearch.Show()
        frmEmployeeStatusSearch.Focus()
    End Sub

    Private Sub cmdSearchEmployee_Click(sender As Object, e As EventArgs) Handles cmdSearchEmployee.Click
        frmEmployeeSearch.sCalledForm = "Employee Status"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Public Sub GetEmployee(a_nId As Integer)
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        nEmployeeId = a_nId
        sSql = "Select FullName, CurrentStatus, IsActive From EM_Employee Where Id = " & nEmployeeId
        GetRecordSet(rsMisc, sSql)
        'rsMisc.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
        txtEmployeeName.Text = Convert.ToString(rsMisc("FullName").Value)
        If Not IsDBNull(rsMisc("CurrentStatus").Value) Then
            cbStatus.SelectedIndex = CInt(rsMisc("CurrentStatus").Value)
        Else
            If CInt(rsMisc("IsActive").Value) = True Then
                cbStatus.SelectedIndex = 0
            Else
                cbStatus.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Function IsAnyFieldChanged() As Boolean
        IsAnyFieldChanged = (Trim(txtDocumentNo.Text) <> Trim(txtDocumentNo.Tag)) Or
                            (Trim(txtEmployeeName.Text) <> Trim(txtEmployeeName.Tag)) Or (Trim(txtRemarks.Text) <> Trim(txtRemarks.Tag)) Or
                            (cbStatus.SelectedValue <> cbStatus.Tag) Or (dtpDate.Value <> dtpDate.Tag)
    End Function

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click

    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Private Function GenerateMailsAcl() As Boolean
        Dim sSql As String
        Dim rsMail As New ADODB.Recordset
        Dim rsEmailInt As New ADODB.Recordset
        Dim EmpDepartment As String
        Dim EmpDesignation As String
        Dim EmpBranch As String
        Dim EmpBranchId As Integer
        Dim EmpOfficialEmail As String
        If bEmail <> True Then Exit Function
        'Dim EmailEmp As Integer
        Dim EmailEmp As String
        Dim ContactEmail As String
        Dim EmpCount As Integer
        Dim EmailIntimation As String
        Dim ExitEmailBranch As Integer
        Dim rsMisc As New ADODB.Recordset
        Dim rsCont As New ADODB.Recordset

        'sSql = "Select dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment,dbo.ufn_GetBranchName(BranchId)vcBranch,ContactOfficialEmail,BranchId From EM_Employee Where EmployeeNo='" & sEmpNo & "'"
        sSql = "Select dbo.ufn_GetDesignation(DesignationId) vcDesignation, dbo.ufn_GetDepartmentName(DepartmentId) vcDepartment,dbo.ufn_GetBranchName(BranchId)vcBranch,ContactOfficialEmail,BranchId,dbo.ufn_GetBranchName(BranchId)vcBranch From EM_Employee Where EmployeeNo='" & sEmpNo & "'"
        GetRecordSet(rsMail, sSql)

        EmpDepartment = Convert.ToString(rsMail("vcDepartment").Value)
        EmpDesignation = Convert.ToString(rsMail("vcDesignation").Value)
        EmpBranchId = Convert.ToInt32(rsMail("BranchId").Value)
        EmpBranch = Convert.ToString(rsMail("vcBranch").Value)
        EmpOfficialEmail = Convert.ToString(rsMail("ContactOfficialEmail").Value)

        EmpCount = 1
        EmailIntimation = "EmpExitEmail_Emp" & EmpCount

        sSql = "Select vcPrefName,vcPrefValue from EM_SysPreferences where vcPrefName Like '%EmpExitEmail_Emp%'"
        GetRecordSet(rsEmailInt, sSql)

        If rsEmailInt.RecordCount > 0 Then

            While Not rsEmailInt.EOF

                EmailIntimation = "EmpExitEmail_Emp" & EmpCount

                sSql = "Select vcPrefName,vcPrefValue from EM_SysPreferences where vcPrefName='" & EmailIntimation & "' "
                GetRecordSet(rsMisc, sSql)

                If rsMisc.EOF Then Exit Function

                'EmailEmp = Convert.ToInt32(rsMisc("vcPrefValue").Value)
                EmailEmp = Convert.ToString(rsMisc("vcPrefValue").Value)

                sSql = "Select BranchId,ContactOfficialEmail from EM_Employee where EmployeeNo='" & EmailEmp & "'"
                GetRecordSet(rsCont, sSql)

                ContactEmail = Convert.ToString(rsCont("ContactOfficialEmail").Value)
                ExitEmailBranch = Convert.ToInt32(rsCont("BranchId").Value)

                'If EmpBranch = ExitEmailBranch And ExitEmailBranch <> 6 Then
                'If EmpBranchId = ExitEmailBranch And (ExitEmailBranch <> 7 And ExitEmailBranch <> 8) Then
                If (EmpBranchId = ExitEmailBranch Or EmpBranchId = 2) And (ExitEmailBranch <> 7 And ExitEmailBranch <> 8) Then
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
                        e_mail.To.Add(ContactEmail)
                        'e_mail.To.Add("arslan.ahmed@fccl.com.pk")

                        e_mail.Subject = "Employee Status Updated"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Status of following Employee has been changed" + vbNewLine + vbNewLine '( " & sEmpNo & " - " & txtEmployeeName.Text & " )
                        e_mail.Body = e_mail.Body & "Employee No : " & sEmpNo & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Employee Name: " & txtEmployeeName.Text & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Designation: " & EmpDesignation & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Department: " & EmpDepartment & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Location: " & EmpBranch & "" + vbNewLine
                        If EmpOfficialEmail = "" Then
                            e_mail.Body = e_mail.Body & "Email: No Email Exists" + vbNewLine + vbNewLine
                        Else
                            e_mail.Body = e_mail.Body & "Email: " & EmpOfficialEmail & "" + vbNewLine + vbNewLine
                        End If

                        If sStatus <> "" Then
                            e_mail.Body = e_mail.Body & "Employee status has been changed to : " & cbStatus.Text + vbNewLine
                            e_mail.Body = e_mail.Body & "Dated : " & dtpDate.Text + vbNewLine + vbNewLine
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

                End If

                'If EmpBranch = 6 Then
                If EmpBranchId = 7 And ExitEmailBranch <> 8 Then

                    Try
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False
                        'Smtp_Server.Credentials = New Net.NetworkCredential("ems", "Ems753")
                        Smtp_Server.Credentials = New Net.NetworkCredential("ems@askarcement.com.pk", "Ems753")
                        Smtp_Server.Port = 25
                        'Smtp_Server.EnableSsl = True
                        'Smtp_Server.Host = "192.168.2.3"
                        Smtp_Server.Host = "mail.askaricement.com.pk"

                        e_mail = New MailMessage()
                        'e_mail.From = New MailAddress("ems@fccl.com.pk")
                        e_mail.From = New MailAddress("ems@askarcement.com.pk")
                        e_mail.To.Add(ContactEmail)
                        'e_mail.To.Add("arslan.ahmed@fccl.com.pk")

                        e_mail.Subject = "Employee Status Updated"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Status of following Employee has been changed" + vbNewLine + vbNewLine '( " & sEmpNo & " - " & txtEmployeeName.Text & " )
                        e_mail.Body = e_mail.Body & "Employee No : " & sEmpNo & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Employee Name: " & txtEmployeeName.Text & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Designation: " & EmpDesignation & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Department: " & EmpDepartment & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Location: " & EmpBranch & "" + vbNewLine
                        If EmpOfficialEmail = "" Then
                            e_mail.Body = e_mail.Body & "Email: No Email Exists" + vbNewLine + vbNewLine
                        Else
                            e_mail.Body = e_mail.Body & "Email: " & EmpOfficialEmail & "" + vbNewLine + vbNewLine
                        End If

                        If sStatus <> "" Then
                            e_mail.Body = e_mail.Body & "Employee status has been changed to : " & cbStatus.Text + vbNewLine
                            e_mail.Body = e_mail.Body & "Dated : " & dtpDate.Text + vbNewLine + vbNewLine
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

                End If

                If EmpBranchId = 8 And ExitEmailBranch <> 7 Then

                    Try
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False
                        'Smtp_Server.Credentials = New Net.NetworkCredential("ems", "Ems753")
                        Smtp_Server.Credentials = New Net.NetworkCredential("ems@askarcement.com.pk", "Ems753")
                        Smtp_Server.Port = 25
                        'Smtp_Server.EnableSsl = True
                        'Smtp_Server.Host = "192.168.2.3"
                        Smtp_Server.Host = "mail.askaricement.com.pk"

                        e_mail = New MailMessage()
                        'e_mail.From = New MailAddress("ems@fccl.com.pk")
                        e_mail.From = New MailAddress("ems@askarcement.com.pk")
                        e_mail.To.Add(ContactEmail)
                        'e_mail.To.Add("arslan.ahmed@fccl.com.pk")

                        e_mail.Subject = "Employee Status Updated"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Status of following Employee has been changed" + vbNewLine + vbNewLine '( " & sEmpNo & " - " & txtEmployeeName.Text & " )
                        e_mail.Body = e_mail.Body & "Employee No : " & sEmpNo & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Employee Name: " & txtEmployeeName.Text & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Designation: " & EmpDesignation & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Department: " & EmpDepartment & "" + vbNewLine
                        e_mail.Body = e_mail.Body & "Location: " & EmpBranch & "" + vbNewLine
                        If EmpOfficialEmail = "" Then
                            e_mail.Body = e_mail.Body & "Email: No Email Exists" + vbNewLine + vbNewLine
                        Else
                            e_mail.Body = e_mail.Body & "Email: " & EmpOfficialEmail & "" + vbNewLine + vbNewLine
                        End If

                        If sStatus <> "" Then
                            e_mail.Body = e_mail.Body & "Employee status has been changed to : " & cbStatus.Text + vbNewLine
                            e_mail.Body = e_mail.Body & "Dated : " & dtpDate.Text + vbNewLine + vbNewLine
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

                End If

                EmpCount = EmpCount + 1

                rsEmailInt.MoveNext()

            End While

            Return bEmail
        End If

    End Function
End Class