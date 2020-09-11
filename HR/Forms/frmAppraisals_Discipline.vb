Imports System.Data.Odbc
Imports System.IO
Imports C1.Win.C1TrueDBGrid
Public Class frmAppraisals_Discipline

    Dim nEmployeeId As Integer = Nothing
    Dim nPromotionId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean
    Dim nAwardId As Integer = Nothing
    Dim nSeminarId As Integer = Nothing
    Dim nDisciplineId As Integer = Nothing
    Dim OBJ As frmMdiMain
    Dim OBJ2 As New frmEmployeeSearch
    Dim ss As String
    Private empName As String
    Public stringpass As String
    Public sCalledFrom As String
    Dim sQueryForTransfer As String
    Dim frmSearch As New frmEmployeeSearch
    Public stringpasssave As String
    Dim Obj3 As New frmEmployeeProfile
    Private sTitle As String
    Private sText As String
    Dim rsMisc As New ADODB.Recordset
    Dim PreviousTab As New TabPage
    Dim CurrentTab As New TabPage


    Private Sub frmAppraisals_Discipline_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = frmMdiMain
        Me.BringToFront()
        Me.Visible = True
        Me.Refresh()

        For Each ctrl In Me.Controls
            ctrl.refresh()
        Next
        Me.Location = New Point(0, 0)

        TabControl1.TabPages(0).Enabled = False
        TabControl1.TabPages(1).Enabled = False
        TabControl1.TabPages(2).Enabled = False
        TabControl1.TabPages(3).Enabled = False
        TabControl1.TabPages.Remove(tbAudit)
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

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

            'sSql = "Select a.nActionId, a.vcName,a.vcDocType, b.vcUserId from ComActionCodes a, ComAccessRights b " &
            '   "Where a.nActionId = b.nActionId And a.vcDocType = b.vcDocId And " &
            '   "b.vcUserId ='" & Trim(frmUserLogin.txtUserID.Text) & "'  And a.vcDocType = 'emsEmployee'"
            'GetRecordSet(rsMisc, sSql)


            'sSql = "Select comActionCodes.vcName,ComAccessRights.nGroupId From ComAccessRights, comActionCodes, ComUserGroups " &
            '    "Where comActionCodes.vcDocType = ComAccessRights.vcDocId  And " &
            '    "comActionCodes.nActionId = ComAccessRights.nActionId And " &
            '    "ComAccessRights.vcDocId = 'emsEmployee' And " &
            '    "ComUserGroups.nGroupId=ComAccessRights.nGroupId And " &
            '    "ComUserGroups.vcUserId = '" & Trim(frmUserLogin.txtUserID.Text) & "' "

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
                TabControlRights = "tb" & rsMisc("vcName").Value
                If Button = "btn_Prepare" Then
                    cmd_PreparePromotion.Enabled = True
                    cmd_PrepareTrainings.Enabled = True
                    cmd_PrepareAwards.Enabled = True
                    cmd_PrepareDiscipline.Enabled = True
                ElseIf Button = "btn_Modify" Then
                    btn_Modify.Enabled = True
                ElseIf Button = "btn_Delete" Then
                    btn_Delete.Enabled = True
                ElseIf TabControlRights = "tbPromotions" Then
                    TabControl1.TabPages(0).Enabled = True
                ElseIf TabControlRights = "tbAwards" Then
                    TabControl1.TabPages(1).Enabled = True
                ElseIf TabControlRights = "tbTrainings" Then
                    TabControl1.TabPages(2).Enabled = True
                ElseIf TabControlRights = "tbDiscipline" Then
                    TabControl1.TabPages(3).Enabled = True
                End If
                rsMisc.MoveNext()
            End While
            TabControl1.TabPages.Add(tbAudit)
        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try
    End Sub

    Private Sub PopulateControls()

        'TAB PROMOTIONS
        PopulateControl(cbFromType, "Select Id, Description From HR_PRMParameters Where Type = 3 Order by Description", "Id", "Description")
        PopulateControl(cbToType, "Select Id, Description From HR_PRMParameters Where Type = 3 Order by Description", "Id", "Description")
        PopulateControl(cbFromDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbToDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbFromGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")
        PopulateControl(cbToGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")

        'Tab Trainings

        PopulateControl(cbCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")

    End Sub


    Private Sub cbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCountry.SelectedIndexChanged
        PopulateControl(cbCity, "Select Id, Description From HR_PRMCity Where CountryId = " & IIf(IsNothing(cbCountry.SelectedValue), 969, cbCountry.SelectedValue).ToString() & " Order by Description", "Id", "Description")
    End Sub


    Public Sub Clear()


        'TAB PROMOTIONS
        nEmployeeId = Nothing
        nPromotionId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbFromType.SelectedIndex = -1
        cbFromType.Tag = cbFromType.SelectedIndex
        cbToType.SelectedIndex = -1
        cbToType.Tag = cbToType.SelectedIndex
        cbFromDesignation.SelectedIndex = -1
        cbFromDesignation.Tag = cbFromDesignation.SelectedIndex
        cbToDesignation.SelectedIndex = -1
        cbToDesignation.Tag = cbToDesignation.SelectedIndex
        cbFromGrade.SelectedIndex = -1
        cbFromGrade.Tag = cbFromGrade.SelectedIndex
        cbToGrade.SelectedIndex = -1
        cbToGrade.Tag = cbToGrade.SelectedIndex
        txtFromIncrement.Text = ""
        txtFromIncrement.Tag = ""
        txtToIncrement.Text = ""
        txtToIncrement.Tag = ""
        dtpEffectiveDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpEffectiveDate.Tag = dtpEffectiveDate.Value
        dtpEffectiveDate.Checked = False
        txtRemarks.Text = ""
        txtRemarks.Tag = ""
        txtNewJobDescription.Text = ""
        txtNewJobDescription.Tag = ""
        grdPromotions.DataSource = Nothing
        'FillGrid()


        'Tab Awards

        nEmployeeId = Nothing
        nAwardId = Nothing
        txtEmployeeNameA.Text = ""
        txtEmployeeNameA.Tag = ""
        txtAwardName.Text = ""
        txtAwardName.Tag = ""
        txtAwardingAuthority.Text = ""
        txtAwardingAuthority.Tag = ""
        dtpAwardingDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpAwardingDate.Tag = dtpAwardingDate.Value
        txtAwardDescription.Text = ""
        txtAwardDescription.Tag = ""
        grdAwards.DataSource = Nothing

        'Tab Trainings
        nEmployeeId = Nothing
        nSeminarId = Nothing
        txtEmployeeNameT.Text = ""
        txtEmployeeNameT.Tag = ""
        cbType.SelectedIndex = -1
        cbType.Tag = cbType.SelectedIndex
        txtTitle.Text = ""
        txtTitle.Tag = ""
        dtpStartDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpStartDate.Tag = dtpEndDate.Value
        dtpStartDate.Checked = False
        dtpEndDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpEndDate.Tag = dtpEndDate.Value
        dtpEndDate.Checked = False
        cbCountry.SelectedIndex = -1
        cbCountry.Tag = -1
        cbCity.SelectedIndex = -1
        cbCity.Tag = -1
        txtCost.Text = ""
        txtCost.Tag = ""
        txtDescription.Text = ""
        txtDescription.Tag = ""
        grdSeminars.DataSource = Nothing


        'Tab Discipline

        nEmployeeId = Nothing
        nDisciplineId = Nothing
        txtEmployeeNameD.Text = ""
        txtEmployeeNameD.Tag = ""
        cbType.SelectedIndex = -1
        cbType.Tag = -1
        dtpDate.Value = CDate(Date.Now.ToString("dd MMM yyyy"))
        dtpDate.Tag = dtpDate.Value
        dtpDate.Checked = False
        txtRemarks.Text = ""
        txtRemarks.Tag = ""
        nStatus = 0
        grdDiscipline.DataSource = Nothing
        grdAudit.DataSource = Nothing
        'slStatus.Text = "New Record"


        '  FillGrid()
    End Sub


    Private Sub Display()
        Dim rsEmployeeName As New ADODB.Recordset
        Dim sSql As String
        Clear()
        Try
            If rsMain.RecordCount = 0 Then Exit Sub
            If rsMain.EOF Then Exit Sub
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

            bDisplaying = True

            'TAB PROMOTIONS

            nEmployeeId = CInt(rsMain("Id").Value)
            sSql = "Select dbo.emGetEmployeeName(" & Convert.ToString(nEmployeeId) & ") vcEmployeeName, EmployeeTypeId, DesignationId, EmployeeGradeId From EM_Employee Where Id = " & nEmployeeId
            rsEmployeeName.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
            If rsEmployeeName.RecordCount > 0 Then
                txtEmployeeName.Text = Convert.ToString(rsEmployeeName("vcEmployeeName").Value)
                txtEmployeeName.Tag = txtEmployeeName.Text
                nEmployeeId = CInt(rsMain("Id").Value)
                txtEmployeeName.Tag = nEmployeeId
                cbFromType.SelectedValue = CInt(rsMain("EmployeeTypeId").Value)
                cbFromType.Tag = cbFromType.SelectedValue
                cbFromDesignation.SelectedValue = CInt(rsMain("DesignationId").Value)
                cbFromDesignation.Tag = cbFromDesignation.SelectedValue
                cbFromGrade.SelectedValue = CInt(rsMain("EmployeeGradeId").Value)
                cbFromGrade.Tag = cbFromGrade.SelectedValue

            End If


            'Tab Awards

            nEmployeeId = CInt(rsMain("Id").Value)
            txtEmployeeNameA.Text = Convert.ToString(rsMain("FullName").Value)
            txtEmployeeNameA.Tag = txtEmployeeNameA.Text




            'Tab Trainings

            nEmployeeId = CInt(rsMain("Id").Value)
            txtEmployeeNameT.Text = Convert.ToString(rsMain("FullName").Value)
            txtEmployeeNameT.Tag = txtEmployeeNameT.Text



            'Tab Discipline

            nEmployeeId = CInt(rsMain("Id").Value)
            txtEmployeeNameD.Text = Convert.ToString(rsMain("FullName").Value)
            txtEmployeeNameD.Tag = txtEmployeeNameD.Text


            rsEmployeeName.Close()

            FillAudit()
            FillPromotions()
            FillAwards()
            FillTrainings()
            FillDiscipline()


            Me.Refresh()
            bDisplaying = False
        Catch ex As Exception
            MessageBox.Show("Error displaying record: " + ex.Message)
        End Try

    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate As String
        Try
            'TAB PROMOTIONS

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If dtpEffectiveDate.Checked = True Then
                sEffectiveDate = "'" & dtpEffectiveDate.Value.ToString("dd MMM yyyy") & "'"
            Else
                sEffectiveDate = "NULL"
            End If


            bProcessing = True

            If (nPromotionId = Nothing) Or (nPromotionId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeePromotions"
                GetRecordSet(rsMisc, sSql)
                If Not IsDBNull(rsMisc("Id").Value) Then
                    nPromotionId = CInt(rsMisc("Id").Value)
                    nPromotionId += 1
                Else
                    nPromotionId = 1
                End If

                sSql = "Insert INTO HR_EmployeePromotions (Id, EmployeeId, FromEmployeeTypeId, ToEmployeeTypeId, FromDesignationId, " &
                        "ToDesignationId, FromGradeId, ToGradeId, FromScale, ToScale, EffectiveFromDate, Remarks, NewJobDescription) " &
                        "Values(" & nPromotionId & ", " & nEmployeeId & ", " & IIf(cbFromType.SelectedIndex < 0, 0, cbFromType.SelectedValue) &
                        ", " & IIf(cbToType.SelectedIndex < 0, 0, cbToType.SelectedValue) & ", " & IIf(cbFromDesignation.SelectedIndex < 0, 0, cbFromDesignation.SelectedValue) &
                        ", " & IIf(cbToDesignation.SelectedIndex < 0, 0, cbToDesignation.SelectedValue) & ", " & IIf(cbFromGrade.SelectedIndex < 0, 0, cbFromGrade.SelectedValue) &
                        ", " & IIf(cbToGrade.SelectedIndex < 0, 0, cbToGrade.SelectedValue) & ", " & IIf(txtFromIncrement.Text = "", 0, txtFromIncrement.Text) &
                        ", " & IIf(txtToIncrement.Text = "", 0, txtToIncrement.Text) & ", " & sEffectiveDate & ", '" & AdjustSingleQuotes(txtRemarks.Text) &
                        "', '" & AdjustSingleQuotes(txtNewJobDescription.Text) & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeePromotions SET FromEmployeeTypeId = " & IIf(cbFromType.SelectedIndex < 0, 0, cbFromType.SelectedValue) &
                       ", ToEmployeeTypeId = " & IIf(cbToType.SelectedIndex < 0, 0, cbToType.SelectedValue) & ", FromDesignationId = " &
                       IIf(cbFromDesignation.SelectedIndex < 0, 0, cbFromDesignation.SelectedValue) & ", ToDesignationId = " &
                       IIf(cbToDesignation.SelectedIndex < 0, 0, cbToDesignation.SelectedValue) & ", FromGradeId = " & IIf(cbFromGrade.SelectedIndex < 0, 0, cbFromGrade.SelectedValue) &
                       ", ToGradeId = " & IIf(cbToGrade.SelectedIndex < 0, 0, cbToGrade.SelectedValue) & ", FromScale = " & IIf(txtFromIncrement.Text = "", 0, txtFromIncrement.Text) &
                       ", ToScale = " & IIf(txtToIncrement.Text = "", 0, txtToIncrement.Text) & ", EffectiveFromDate = " & sEffectiveDate &
                       ", Remarks = '" & AdjustSingleQuotes(txtRemarks.Text) & "', NewJobDescription = '" & AdjustSingleQuotes(txtNewJobDescription.Text) &
                       "' Where Id = " & nPromotionId & " And EmployeeId = " & nEmployeeId

                conn.Execute(sSql)
            End If



            'Tab Awards

            If txtAwardName.Text <> "" Or txtAwardingAuthority.Text <> "" Then
                If (nAwardId = Nothing) Or (nAwardId = 0) Then
                    sSql = "Select MAX(Id) As Id From HR_EmployeeJobHistory_Award Where EmployeeId = " & nEmployeeId
                    GetRecordSet(rsMisc, sSql)
                    If rsMisc.RecordCount > 0 Then
                        If Not IsDBNull(rsMisc("Id").Value) Then
                            nAwardId = CInt(rsMisc("Id").Value)
                            nAwardId += 1
                        Else
                            nAwardId = 1
                        End If
                    Else
                        nAwardId = 1
                    End If

                    sSql = "Insert INTO HR_EmployeeJobHistory_Award (Id, EmployeeId, Award, AwardingAuthority, AwardingDate, Description)" &
               " Values(" & nAwardId & ", " & nEmployeeId & ", '" & AdjustSingleQuotes(txtAwardName.Text) &
               "', '" & AdjustSingleQuotes(txtAwardingAuthority.Text) & "', '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") &
               "', '" & AdjustSingleQuotes(txtAwardDescription.Text) & "')"
                    conn.Execute(sSql)
                Else
                    sSql = "Update HR_EmployeeJobHistory_Award Set Award = '" & AdjustSingleQuotes(txtAwardName.Text) &
                       "', AwardingAuthority = '" & AdjustSingleQuotes(txtAwardingAuthority.Text) &
                       "', AwardingDate = '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") & "', Description = '" & AdjustSingleQuotes(txtAwardDescription.Text) &
                       "' Where Id = " & nAwardId & " And EmployeeId = " & nEmployeeId
                    conn.Execute(sSql)
                End If

            End If


            ''' 'Tab Trainings


            If (nSeminarId = Nothing) Or (nSeminarId = 0) Then
                sSql = "Select MAX(nId) As nId From EM_EmployeeTrainingCS Where nEmployeeId = " & nEmployeeId
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("nId").Value) Then
                        nSeminarId = CInt(rsMisc("nId").Value)
                        nSeminarId += 1
                    Else
                        nSeminarId = 1
                    End If
                Else
                    nSeminarId = 1
                End If

                sSql = "Insert INTO EM_EmployeeTrainingCS (nId, nEmployeeId, nType, vcTitle, dtmStartDate, dtmEndDate, nCountryId, nCityId, vcDescription, flCost, nsStatusId)" &
                   " Values(" & nSeminarId & ", " & nEmployeeId & ", " & cbType.SelectedIndex & ", '" & AdjustSingleQuotes(txtTitle.Text) &
                   "', '" & dtpStartDate.Value.ToString("dd MMM yyyy") & "', '" & dtpEndDate.Value.ToString("dd MMM yyyy") &
                   "', " & cbCountry.SelectedIndex & ", " & cbCity.SelectedIndex & ", '" & AdjustSingleQuotes(txtDescription.Text) &
                   "', " & IIf(Trim(txtCost.Text) = "", 0, Trim(txtCost.Text)) & ", " & nStatus & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update EM_EmployeeTrainingCS Set nType = " & cbType.SelectedIndex & ", vcTitle = '" & AdjustSingleQuotes(txtTitle.Text) &
                       "', dtmStartDate = '" & dtpStartDate.Value.ToString("dd MMM yyyy") & "', dtmEndDate = '" & dtpEndDate.Value.ToString("dd MMM yyyy") &
                       "', nCountryId = " & cbCountry.SelectedIndex & ", nCityId = " & cbCity.SelectedIndex & ", flCost = " & IIf(Trim(txtCost.Text) = "", 0, Trim(txtCost.Text)) &
                       ", vcDescription = '" & AdjustSingleQuotes(txtDescription.Text) & "', nsStatusId = " & nStatus &
                       " Where nId = " & nSeminarId & " And nEmployeeId = " & nEmployeeId
                conn.Execute(sSql)
            End If

            ''' sSql = "Insert Into EM_EmployeeTrainingCSAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            ''' Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            ''' conn.Execute(sSql)



            ''' 'Tab Discipline

            ''' If (nDisciplineId = Nothing) Or (nDisciplineId = 0) Then
            '''     sSql = "Select MAX(nDisciplineId) As nDisciplineId From EM_EmployeeDiscipline"
            '''     GetRecordSet(rsMisc, sSql)
            '''     If rsMisc.RecordCount > 0 Then
            '''         If Not IsDBNull(rsMisc("nDisciplineId").Value) Then
            '''             nDisciplineId = CInt(rsMisc("nDisciplineId").Value)
            '''             nDisciplineId += 1
            '''         Else
            '''             nDisciplineId = 1
            '''         End If
            '''     Else
            '''         nDisciplineId = 1
            '''     End If

            '''     sSql = "Insert INTO EM_EmployeeDiscipline (nDisciplineId, nEmployeeId, dtmDate, nType, vcRemarks, nsStatusId)" &
            '''    " Values(" & nDisciplineId & ", " & nEmployeeId & ", '" & dtpDate.Value.ToString("dd MMM yyyy") &
            '''    "', " & cbType.SelectedIndex & ", '" & AdjustSingleQuotes(txtRemarks.Text) &
            '''    "', " & nStatus & ")"
            '''     conn.Execute(sSql)
            ''' Else
            '''     sSql = "Update EM_EmployeeDiscipline Set dtmDate = '" & dtpDate.Value.ToString("dd MMM yyyy") &
            '''            "', nType = " & cbType.SelectedIndex &
            '''            ", vcRemarks = '" & AdjustSingleQuotes(txtRemarks.Text) & "', nsStatusId = " & nStatus &
            '''            " Where nDisciplineId = " & nDisciplineId
            '''     conn.Execute(sSql)
            ''' End If

            ''' sSql = "Insert Into EM_EmployeeDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            '''Convert.ToString(nDisciplineId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            ''' conn.Execute(sSql)
            ''' 
            sSql = "Insert Into EM_EmployeeAppraisalsDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)


        Catch ex As Exception
            MessageBox.Show("Error saving record." & ex.Message)
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        'Tab Promotions

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nPromotionId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this promition?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeePromotions Where Id = " & nPromotionId
        conn.Execute(sSql)
        sSql = "Delete From HR_EmployeePromotionsAudit Where vcDocumentId = '" & Convert.ToString(nPromotionId) & "'"
        conn.Execute(sSql)


        MsgBox("Promotion deleted successfully.", vbInformation)

        'Tab Awards

        If MsgBox("Do you want to Delete this award?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeJobHistory_Award Where Id = " & nAwardId & " and EmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        sSql = "Delete From HR_EmployeeJobHistory_AwardAudit Where vcDocumentId = '" & Convert.ToString(nAwardId) & "'"
        conn.Execute(sSql)


        MsgBox("Award deleted successfully.", vbInformation)


        'TAb Trainings

        sSql = "Delete From EM_EmployeeTrainingCS Where nId = " & nSeminarId & " and nEmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        sSql = "Delete From EM_EmployeeTrainingCSAudit Where vcDocumentId = '" & Convert.ToString(nEmployeeId) & "'"
        conn.Execute(sSql)

        MsgBox("Record deleted successfully.", vbInformation)


        'TAb Discipline

        sSql = "Delete From EM_EmployeeDiscipline Where nDisciplineId = " & nDisciplineId
        conn.Execute(sSql)
        sSql = "Delete From EM_EmployeeDisciplineAudit Where vcDocumentId = '" & Convert.ToString(nDisciplineId) & "'"
        conn.Execute(sSql)

        Display()
    End Sub


    Private Sub FillPromotions()
        Try
            Dim connODBC As New Odbc.OdbcConnection
            connODBC.ConnectionString = "Dsn=ERP;uid=sa"
            connODBC.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New Odbc.OdbcDataAdapter
            Dim sSql As String = "Select Id, dbo.ufn_GetDesignation(FromDesignationId) FromDesignation, dbo.ufn_GetDesignation(ToDesignationId) " &
                             "ToDesignation, EffectiveFromDate, Remarks From HR_EmployeePromotions Where EmployeeId = " & nEmployeeId

            adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)

            adapter.Fill(ds)
            grdPromotions.DataSource = Nothing
            grdPromotions.SetDataBinding(ds.Tables(0), "", True)
            connODBC.Close()
            grdPromotions.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading promotions.")
        End Try
    End Sub



    Private Sub FillAwards()

        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT Id, Award, AwardingAuthority, AwardingDate, Description From " &
                             " HR_EmployeeJobHistory_Award Where EmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAwards.DataSource = Nothing
            grdAwards.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading awards.")
        End Try
        connODBC.Close()
        grdAwards.Refresh()



    End Sub

    Private Sub FillTrainings()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = sConnectionString
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT nId, nType, dtmStartDate, dtmEndDate, vcTitle From " &
                                 " EM_EmployeeTrainingCS Where nEmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdSeminars.DataSource = Nothing
            grdSeminars.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading courses/seminars.")
        End Try
        connODBC.Close()
        grdSeminars.Refresh()
    End Sub


    Private Sub FillDiscipline()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT nDisciplineId, dtmDate, nType, vcRemarks From " &
                             "EM_EmployeeDiscipline Where nEmployeeId = " & nEmployeeId

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdDiscipline.DataSource = Nothing
            grdDiscipline.SetDataBinding(ds.Tables(0), "", True)
        Catch ex As Exception
            MessageBox.Show("Error loading warnings.")
        End Try
        connODBC.Close()
        grdDiscipline.Refresh()



    End Sub


    Private Sub FillAudit()

        'TAB PROMOTIONS
        Dim sSql As String


        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        ' sSql = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_EmployeeAppraisalsDisciplineAudit Where DocumentId='" &   & "'  Order by dtmActionDate"
        sSql = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From EM_EmployeeAppraisalsDisciplineAudit Where vcDocumentId = '" & Convert.ToString(nEmployeeId) & "' And vcAction!='Uniform Size'  Order by dtmActionDate"


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

    Private Sub grdQualifications_DoubleClick(sender As Object, e As EventArgs)

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        frmEmployeeSearch.sCalledForm = "Appraisals_Discipline"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Save()
    End Sub



    Public Sub SearchRecords(ByVal a_sEmpNo As String, ByVal a_sSql As String)
        If rsMain.State = ADODB.ObjectStateEnum.adStateOpen Then rsMain.Close()
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        rsMain.Open(a_sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMain.RecordCount > 0 Then
            rsMain.MoveFirst()
            rsMain.Find("EmployeeNo = '" & a_sEmpNo & "'")
            If Not rsMain.EOF Then Display()
        End If
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean

        Dim rsMisc As New ADODB.Recordset

        ValidateFields = False

        'Tab Promotions

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If nPromotionId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            '    slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = 1
            ' nStatus = CInt(rsMain("nsStatusId").Value)
            'slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            'slStatus.Text = "Approved"
        End If

        'Tab Awards

        If Trim(txtEmployeeNameA.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        'If txtAwardName.Text = "" Then
        '    MsgBox("Please enter award name.", vbCritical)
        '    txtAwardName.Focus()
        '    Exit Function
        'End If

        'If txtAwardingAuthority.Text = "" Then
        '    MsgBox("Please enter awarding authority.", vbCritical)
        '    txtAwardingAuthority.Focus()
        '    Exit Function
        'End If

        If nAwardId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            ' slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            'nStatus = CInt(rsMain("nsStatusId").Value)
            '   slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            '  slStatus.Text = "Approved"
        End If


        'TAb Trainings

        If Trim(txtEmployeeNameT.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        'If cbType.SelectedIndex = -1 Then
        '    MsgBox("Please select type.", vbCritical)
        '    cbType.Focus()
        '    Exit Function
        'End If

        'If txtTitle.Text = "" Then
        '    MsgBox("Please enter course/seminar name.", vbCritical)
        '    txtTitle.Focus()
        '    Exit Function
        'End If

        'If dtpStartDate.Checked = False Then
        '    MsgBox("Please select start date.", vbCritical)
        '    dtpStartDate.Focus()
        '    Exit Function
        'End If

        'If dtpEndDate.Checked = False Then
        '    MsgBox("Please select end date.", vbCritical)
        '    dtpEndDate.Focus()
        '    Exit Function
        'End If

        'If cbCountry.SelectedIndex = -1 Then
        '    MsgBox("Please select country.", vbCritical)
        '    cbCountry.Focus()
        '    Exit Function
        'End If

        'If cbCity.SelectedIndex = -1 Then
        '    MsgBox("Please select city.", vbCritical)
        '    cbCity.Focus()
        '    Exit Function
        'End If

        If nSeminarId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            '  slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = 1
            'nStatus = CInt(rsMain("nsStatusId").Value)
            '  slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            'slStatus.Text = "Approved"
        End If



        Dim sSql As String
        'Tab Discipline

        If nDisciplineId <> 0 Then
            sSql = "Select nsStatusId From EM_EmployeeDiscipline Where nDisciplineId = " & nDisciplineId
            GetRecordSet(rsMisc, sSql)

            If rsMisc.RecordCount > 0 Then nStatus = CInt(rsMisc("nsStatusId").Value)
            rsMisc.Close()
        End If

        If nStatus = 3 Then
            MsgBox("Invalid Action.", vbCritical)
            Exit Function
        End If

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        'If dtpDate.Checked = False Then
        '    MsgBox("Please select date.", vbCritical)
        '    dtpDate.Focus()
        '    Exit Function
        'End If

        'If cbType.SelectedIndex = -1 Then
        '    MsgBox("Please select type.", vbCritical)
        '    cbType.Focus()
        '    Exit Function
        'End If

        If nDisciplineId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            'slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = CInt(rsMain("nsStatusId").Value)
            ' slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            ' slStatus.Text = "Approved"
        End If



        ValidateFields = True

    End Function

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Appraisals_Discipline"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub grdPromotions_DoubleClick(sender As Object, e As EventArgs) Handles grdPromotions.DoubleClick

        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeePromotions Where Id = " & Convert.ToString(grdPromotions.Columns(0).Value) & " And EmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nPromotionId = CInt(rsMisc("Id").Value)

        cbFromType.SelectedValue = CInt(rsMisc("FromEmployeeTypeId").Value)
        cbFromType.Tag = cbFromType.SelectedValue
        cbToType.SelectedValue = CInt(rsMisc("ToEmployeeTypeId").Value)
        cbToType.Tag = cbToType.SelectedValue
        cbFromDesignation.SelectedValue = CInt(rsMisc("FromDesignationId").Value)
        cbFromDesignation.Tag = cbFromDesignation.SelectedValue
        cbToDesignation.SelectedValue = CInt(rsMisc("ToDesignationId").Value)
        cbToDesignation.Tag = cbToDesignation.SelectedValue
        cbFromGrade.SelectedValue = CInt(rsMisc("FromGradeId").Value)
        cbFromGrade.Tag = cbFromGrade.SelectedValue
        cbToGrade.SelectedValue = CInt(rsMisc("ToGradeId").Value)
        cbToGrade.Tag = cbToGrade.SelectedValue

        If Not IsDBNull(rsMisc("FromScale").Value) Then
            txtFromIncrement.Text = Convert.ToString(rsMisc("FromScale").Value)
            txtFromIncrement.Tag = txtFromIncrement.Text
        End If

        If Not IsDBNull(rsMisc("ToScale").Value) Then
            txtToIncrement.Text = Convert.ToString(rsMisc("ToScale").Value)
            txtToIncrement.Tag = txtToIncrement.Text
        End If

        If Not IsDBNull(rsMisc("EffectiveFromDate").Value) Then
            dtpEffectiveDate.Value = CDate(rsMisc("EffectiveFromDate").Value)
            dtpEffectiveDate.Tag = dtpEffectiveDate.Value
            dtpEffectiveDate.Checked = True
        Else
            dtpEffectiveDate.Checked = False
        End If

        If Not IsDBNull(rsMisc("Remarks").Value) Then
            txtRemarks.Text = Convert.ToString(rsMisc("Remarks").Value)
            txtRemarks.Tag = txtRemarks.Text
        End If

        If Not IsDBNull(rsMisc("NewJobDescription").Value) Then
            txtNewJobDescription.Text = Convert.ToString(rsMisc("NewJobDescription").Value)
            txtNewJobDescription.Tag = txtNewJobDescription.Text
        End If
        FillAudit()
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btn_Modify.Click
        Save()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Delete()

    End Sub

    Private Sub grdAwards_DoubleClick(sender As Object, e As EventArgs) Handles grdAwards.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeJobHistory_Award Where Id = " & Convert.ToString(grdAwards.Columns(0).Value) &
               " And EmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMisc.RecordCount > 0 Then
            nAwardId = CInt(rsMisc("Id").Value)
            txtAwardName.Text = Convert.ToString(rsMisc("Award").Value)
            txtAwardName.Tag = txtAwardName.Text
            txtAwardingAuthority.Text = Convert.ToString(rsMisc("AwardingAuthority").Value)
            txtAwardingAuthority.Tag = txtAwardingAuthority.Text
            If Not IsDBNull(rsMisc("AwardingDate").Value) Then
                dtpAwardingDate.Value = CDate(rsMisc("AwardingDate").Value)
                dtpAwardingDate.Tag = dtpAwardingDate.Value
            End If
            If Not IsDBNull(rsMisc("Description").Value) Then
                txtAwardDescription.Text = Convert.ToString(rsMisc("Description").Value)
                txtAwardDescription.Tag = txtAwardDescription.Text
            End If
            FillAudit()
        End If
    End Sub

    Private Sub grdSeminars_DoubleClick(sender As Object, e As EventArgs) Handles grdSeminars.DoubleClick

        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From EM_EmployeeTrainingCS Where nId = " & Convert.ToString(grdSeminars.Columns(0).Value) &
                   " And nEmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMisc.RecordCount > 0 Then
            nSeminarId = CInt(rsMisc("nId").Value)

            If Not IsDBNull(rsMisc("nType").Value) Then
                cbType.SelectedIndex = CInt(rsMisc("nType").Value)
                cbType.Tag = cbType.SelectedIndex
            End If

            If Not IsDBNull(rsMisc("vcTitle").Value) Then
                txtTitle.Text = Convert.ToString(rsMisc("vcTitle").Value)
                txtTitle.Tag = txtTitle.Text
            End If

            If Not IsDBNull(rsMisc("dtmStartDate").Value) Then
                dtpStartDate.Value = CDate(rsMisc("dtmStartDate").Value)
                dtpStartDate.Tag = dtpStartDate.Value
                dtpStartDate.Checked = True
            Else
                dtpStartDate.Checked = False
            End If

            If Not IsDBNull(rsMisc("dtmEndDate").Value) Then
                dtpEndDate.Value = CDate(rsMisc("dtmEndDate").Value)
                dtpEndDate.Tag = dtpEndDate.Value
                dtpEndDate.Checked = True
            Else
                dtpEndDate.Checked = False
            End If

            If Not IsDBNull(rsMisc("nCountryId").Value) Then
                cbCountry.SelectedIndex = CInt(rsMisc("nCountryId").Value)
                cbCountry.Tag = cbCountry.SelectedIndex
            End If

            If Not IsDBNull(rsMisc("nCityId").Value) Then
                cbCity.SelectedIndex = CInt(rsMisc("nCityId").Value)
                cbCity.Tag = cbCity.SelectedIndex
            End If

            If Not IsDBNull(rsMisc("flCost").Value) Then
                txtCost.Text = Convert.ToString(rsMisc("flCost").Value)
                txtCost.Tag = txtCost.Text
            End If

            If Not IsDBNull(rsMisc("vcDescription").Value) Then
                txtDescription.Text = Convert.ToString(rsMisc("vcDescription").Value)
                txtDescription.Tag = txtDescription.Text
            End If

            nStatus = CInt(rsMisc("nsStatusId").Value)
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btn_Prepare.Click
        Clear()
    End Sub

    Private Sub grdDiscipline_DoubleClick(sender As Object, e As EventArgs) Handles grdDiscipline.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From EM_EmployeeDiscipline Where nDisciplineId = " & grdDiscipline.Columns(0).Value

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rsMisc.RecordCount > 0 Then
            nDisciplineId = CInt(rsMisc("nDisciplineId").Value)
            cbDisciplineType.SelectedIndex = CInt(rsMisc("nType").Value)
            cbType.Tag = cbType.SelectedIndex
            If Not IsDBNull(rsMisc("dtmDate").Value) Then
                dtpDate.Value = CDate(rsMisc("dtmDate").Value)
                dtpDate.Tag = dtpDate.Value
                dtpDate.Checked = True
            Else
                dtpDate.Checked = False
            End If
            If Not IsDBNull(rsMisc("vcRemarks").Value) Then
                txtDisciplineDescription.Text = Convert.ToString(rsMisc("vcRemarks").Value)
                txtDisciplineDescription.Tag = txtDisciplineDescription.Text
            End If
            If CInt(rsMisc("nsStatusId").Value) = 1 Then
                'slStatus.Text = "Pending"
            ElseIf CInt(rsMisc("nsStatusId").Value) = 3 Then
                '   slStatus.Text = "Approved"
            End If
            FillAudit()
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

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
        If TabControl1.TabPages(0).Enabled = False And PreviousTab.Name = tbPromotions.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(1).Enabled = False And PreviousTab.Name = tbAwards.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(2).Enabled = False And PreviousTab.Name = tbTrainings.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If
        If TabControl1.TabPages(3).Enabled = False And PreviousTab.Name = tbDiscipline.Name Then
            MessageBox.Show("You Don't have rights to this information", "Privilages Error ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            TabControl1.SelectedTab = CurrentTab
        End If

    End Sub

    Private Sub BunifuDropdown1_onItemSelected(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmd_PreparePromotion_Click(sender As Object, e As EventArgs) Handles cmd_PreparePromotion.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate As String
        Dim sAction As String, sActionRemarks As String

        Try
            'TAB PROMOTIONS

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If dtpEffectiveDate.Checked = True Then
                sEffectiveDate = "'" & dtpEffectiveDate.Value.ToString("dd MMM yyyy") & "'"
            Else
                sEffectiveDate = "NULL"
            End If

            bProcessing = True

            If (nPromotionId = Nothing) Or (nPromotionId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeePromotions"
                GetRecordSet(rsMisc, sSql)
                If Not IsDBNull(rsMisc("Id").Value) Then
                    nPromotionId = CInt(rsMisc("Id").Value)
                    nPromotionId += 1
                Else
                    nPromotionId = 1
                End If

                sSql = "Insert INTO HR_EmployeePromotions (Id, EmployeeId, FromEmployeeTypeId, ToEmployeeTypeId, FromDesignationId, " &
                        "ToDesignationId, FromGradeId, ToGradeId, FromScale, ToScale, EffectiveFromDate, Remarks, NewJobDescription) " &
                        "Values(" & nPromotionId & ", " & nEmployeeId & ", " & IIf(cbFromType.SelectedIndex < 0, 0, cbFromType.SelectedValue) &
                        ", " & IIf(cbToType.SelectedIndex < 0, 0, cbToType.SelectedValue) & ", " & IIf(cbFromDesignation.SelectedIndex < 0, 0, cbFromDesignation.SelectedValue) &
                        ", " & IIf(cbToDesignation.SelectedIndex < 0, 0, cbToDesignation.SelectedValue) & ", " & IIf(cbFromGrade.SelectedIndex < 0, 0, cbFromGrade.SelectedValue) &
                        ", " & IIf(cbToGrade.SelectedIndex < 0, 0, cbToGrade.SelectedValue) & ", " & IIf(txtFromIncrement.Text = "", 0, txtFromIncrement.Text) &
                        ", " & IIf(txtToIncrement.Text = "", 0, txtToIncrement.Text) & ", " & sEffectiveDate & ", '" & AdjustSingleQuotes(txtRemarks.Text) &
                        "', '" & AdjustSingleQuotes(txtNewJobDescription.Text) & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeePromotions SET FromEmployeeTypeId = " & IIf(cbFromType.SelectedIndex < 0, 0, cbFromType.SelectedValue) &
                       ", ToEmployeeTypeId = " & IIf(cbToType.SelectedIndex < 0, 0, cbToType.SelectedValue) & ", FromDesignationId = " &
                       IIf(cbFromDesignation.SelectedIndex < 0, 0, cbFromDesignation.SelectedValue) & ", ToDesignationId = " &
                       IIf(cbToDesignation.SelectedIndex < 0, 0, cbToDesignation.SelectedValue) & ", FromGradeId = " & IIf(cbFromGrade.SelectedIndex < 0, 0, cbFromGrade.SelectedValue) &
                       ", ToGradeId = " & IIf(cbToGrade.SelectedIndex < 0, 0, cbToGrade.SelectedValue) & ", FromScale = " & IIf(txtFromIncrement.Text = "", 0, txtFromIncrement.Text) &
                       ", ToScale = " & IIf(txtToIncrement.Text = "", 0, txtToIncrement.Text) & ", EffectiveFromDate = " & sEffectiveDate &
                       ", Remarks = '" & AdjustSingleQuotes(txtRemarks.Text) & "', NewJobDescription = '" & AdjustSingleQuotes(txtNewJobDescription.Text) &
                       "' Where Id = " & nPromotionId & " And EmployeeId = " & nEmployeeId

                conn.Execute(sSql)
            End If
            If nPromotionId = 0 Then
                sAction = "New Promotion"
                sActionRemarks = "Added a New Promotion."
            Else
                sAction = "Modified Promotion"
                sActionRemarks = "Modified a promotion."
            End If

            sSql = "Insert Into EM_EmployeeAppraisalsDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record." & ex.Message)
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()

    End Sub

    Private Sub cmd_PrepareAwards_Click(sender As Object, e As EventArgs) Handles cmd_PrepareAwards.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate, sActionRemarks As String

        Try
            'TAB PROMOTIONS

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If dtpEffectiveDate.Checked = True Then
                sEffectiveDate = "'" & dtpEffectiveDate.Value.ToString("dd MMM yyyy") & "'"
            Else
                sEffectiveDate = "NULL"
            End If

            bProcessing = True
            If (nAwardId = Nothing) Or (nAwardId = 0) Then
                sSql = "Select MAX(Id) As Id From HR_EmployeeJobHistory_Award Where EmployeeId = " & nEmployeeId
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("Id").Value) Then
                        nAwardId = CInt(rsMisc("Id").Value)
                        nAwardId += 1
                    Else
                        nAwardId = 1
                    End If
                Else
                    nAwardId = 1
                End If

                sSql = "Insert INTO HR_EmployeeJobHistory_Award (Id, EmployeeId, Award, AwardingAuthority, AwardingDate, Description)" &
               " Values(" & nAwardId & ", " & nEmployeeId & ", '" & AdjustSingleQuotes(txtAwardName.Text) &
               "', '" & AdjustSingleQuotes(txtAwardingAuthority.Text) & "', '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") &
               "', '" & AdjustSingleQuotes(txtAwardDescription.Text) & "')"
                conn.Execute(sSql)
            Else
                sSql = "Update HR_EmployeeJobHistory_Award Set Award = '" & AdjustSingleQuotes(txtAwardName.Text) &
               "', AwardingAuthority = '" & AdjustSingleQuotes(txtAwardingAuthority.Text) &
               "', AwardingDate = '" & dtpAwardingDate.Value.ToString("dd MMM yyyy") & "', Description = '" & AdjustSingleQuotes(txtAwardDescription.Text) &
               "' Where Id = " & nAwardId & " And EmployeeId = " & nEmployeeId
                conn.Execute(sSql)
            End If

            If nAwardId = 0 Then
                sAction = "New Award"
                sActionRemarks = "Added a New Award."
            Else
                sAction = "Modified Award"
                sActionRemarks = "Modified a Award."
            End If

            sSql = "Insert Into EM_EmployeeAppraisalsDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)


        Catch ex As Exception
            MessageBox.Show("Error saving record." & ex.Message)
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
    End Sub

    Private Sub cmd_PrepareTrainings_Click(sender As Object, e As EventArgs) Handles cmd_PrepareTrainings.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate, sActionRemarks As String

        Try
            'TAB PROMOTIONS

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If dtpEffectiveDate.Checked = True Then
                sEffectiveDate = "'" & dtpEffectiveDate.Value.ToString("dd MMM yyyy") & "'"
            Else
                sEffectiveDate = "NULL"
            End If

            bProcessing = True

            If (nSeminarId = Nothing) Or (nSeminarId = 0) Then
                sSql = "Select MAX(nId) As nId From EM_EmployeeTrainingCS Where nEmployeeId = " & nEmployeeId
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("nId").Value) Then
                        nSeminarId = CInt(rsMisc("nId").Value)
                        nSeminarId += 1
                    Else
                        nSeminarId = 1
                    End If
                Else
                    nSeminarId = 1
                End If

                sSql = "Insert INTO EM_EmployeeTrainingCS (nId, nEmployeeId, nType, vcTitle, dtmStartDate, dtmEndDate, nCountryId, nCityId, vcDescription, flCost, nsStatusId)" &
                   " Values(" & nSeminarId & ", " & nEmployeeId & ", " & cbType.SelectedIndex & ", '" & AdjustSingleQuotes(txtTitle.Text) &
                   "', '" & dtpStartDate.Value.ToString("dd MMM yyyy") & "', '" & dtpEndDate.Value.ToString("dd MMM yyyy") &
                   "', " & cbCountry.SelectedIndex & ", " & cbCity.SelectedIndex & ", '" & AdjustSingleQuotes(txtDescription.Text) &
                   "', " & IIf(Trim(txtCost.Text) = "", 0, Trim(txtCost.Text)) & ", " & nStatus & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update EM_EmployeeTrainingCS Set nType = " & cbType.SelectedIndex & ", vcTitle = '" & AdjustSingleQuotes(txtTitle.Text) &
                       "', dtmStartDate = '" & dtpStartDate.Value.ToString("dd MMM yyyy") & "', dtmEndDate = '" & dtpEndDate.Value.ToString("dd MMM yyyy") &
                       "', nCountryId = " & cbCountry.SelectedIndex & ", nCityId = " & cbCity.SelectedIndex & ", flCost = " & IIf(Trim(txtCost.Text) = "", 0, Trim(txtCost.Text)) &
                       ", vcDescription = '" & AdjustSingleQuotes(txtDescription.Text) & "', nsStatusId = " & nStatus &
                       " Where nId = " & nSeminarId & " And nEmployeeId = " & nEmployeeId
                conn.Execute(sSql)
            End If

            If nSeminarId = 0 Then
                sAction = "New Training"
                sActionRemarks = "Added a New Training."
            Else
                sAction = "Modified Training"
                sActionRemarks = "Modified a Training."
            End If

            sSql = "Insert Into EM_EmployeeAppraisalsDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
        MessageBox.Show("Error saving record." & ex.Message)
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmd_PrepareDiscipline.Click
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate, sActionRemarks As String

        Try
            'TAB PROMOTIONS

            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

            If dtpEffectiveDate.Checked = True Then
                sEffectiveDate = "'" & dtpEffectiveDate.Value.ToString("dd MMM yyyy") & "'"
            Else
                sEffectiveDate = "NULL"
            End If

            bProcessing = True

            If (nDisciplineId = Nothing) Or (nDisciplineId = 0) Then
                sSql = "Select MAX(nDisciplineId) As nDisciplineId From EM_EmployeeDiscipline"
                GetRecordSet(rsMisc, sSql)
                If rsMisc.RecordCount > 0 Then
                    If Not IsDBNull(rsMisc("nDisciplineId").Value) Then
                        nDisciplineId = CInt(rsMisc("nDisciplineId").Value)
                        nDisciplineId += 1
                    Else
                        nDisciplineId = 1
                    End If
                Else
                    nDisciplineId = 1
                End If

                sSql = "Insert INTO EM_EmployeeDiscipline (nDisciplineId, nEmployeeId, dtmDate, nType, vcRemarks, nsStatusId)" &
               " Values(" & nDisciplineId & ", " & nEmployeeId & ", '" & dtpDate.Value.ToString("dd MMM yyyy") &
               "', " & cbDisciplineType.SelectedIndex & ", '" & AdjustSingleQuotes(txtDisciplineDescription.Text) &
               "', " & nStatus & ")"
                conn.Execute(sSql)
            Else
                sSql = "Update EM_EmployeeDiscipline Set dtmDate = '" & dtpDate.Value.ToString("dd MMM yyyy") &
                       "', nType = " & cbDisciplineType.SelectedIndex &
                       ", vcRemarks = '" & AdjustSingleQuotes(txtDisciplineDescription.Text) & "', nsStatusId = " & nStatus &
                       " Where nDisciplineId = " & nDisciplineId
                conn.Execute(sSql)
            End If

            If nDisciplineId = 0 Then
                sAction = "New Discipline"
                sActionRemarks = "Added a New Discipline."
            Else
                sAction = "Modified Discipline"
                sActionRemarks = "Modified a Discipline."
            End If

            sSql = "Insert Into EM_EmployeeAppraisalsDisciplineAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
           Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & mdFunctions.sUserId & "', '" & sActionRemarks & "', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record." & ex.Message)
        End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
    End Sub

End Class