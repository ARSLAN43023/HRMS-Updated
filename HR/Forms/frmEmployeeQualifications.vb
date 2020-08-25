Public Class frmEmployeeQualifications
    Dim nEmployeeId As Integer = Nothing
    Dim nQualificationId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean


    Private Sub frmEmployeeProfessionalExperience_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        PopulateControls()
        Clear()
    End Sub

    Private Sub PopulateControls()
        PopulateControl(cbCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")
        PopulateControl(cbDegreeDiploma, "Select Id, Description From HR_PRMParameters Where Type = 8 Order by Description", "Id", "Description")
        PopulateControl(cbInstitution, "Select Id, Description From HR_PRMParameters Where Type = 9 Order by Description", "Id", "Description")
    End Sub
    Private Sub cbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCountry.SelectedIndexChanged
        PopulateControl(cbCity, "Select Id, Description From HR_PRMCity Where CountryId = " + IIf(IsNothing(cbCountry.SelectedValue), 969, cbCountry.SelectedValue).ToString() + " Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nQualificationId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
        cbDegreeDiploma.SelectedIndex = -1
        cbDegreeDiploma.Tag = cbDegreeDiploma.SelectedIndex
        txtOtherDegree.Text = ""
        txtOtherDegree.Tag = ""
        txtMajors.Text = ""
        txtMajors.Tag = ""
        txtGradeGPA.Text = ""
        txtGradeGPA.Tag = ""
        cbInstitution.SelectedIndex = -1
        cbInstitution.Tag = cbInstitution.SelectedIndex
        txtOtherInstitution.Text = ""
        txtOtherInstitution.Tag = ""
        txtStartYear.Text = ""
        txtStartYear.Tag = ""
        txtEndYear.Text = ""
        txtEndYear.Tag = ""
        radAcademic.Checked = True
        radAcademic.Tag = radAcademic.Checked
        radProfessional.Checked = False
        radProfessional.Tag = radAcademic.Checked
        cbCountry.SelectedIndex = -1
        cbCountry.Tag = cbCountry.SelectedIndex
        cbCity.SelectedIndex = -1
        cbCity.Tag = cbCountry.SelectedIndex
        txtExtraCurricular.Text = ""
        txtExtraCurricular.Tag = ""
        txtDistinctions.Text = ""
        txtDistinctions.Tag = ""

        FillGrid()
    End Sub

    Private Sub Display()
        Dim rsEmployeeName As New ADODB.Recordset
        Dim sSql As String
        Clear()

        If rsMain.RecordCount = 0 Then Exit Sub
        If rsMain.EOF Then Exit Sub
        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        bDisplaying = True

        nEmployeeId = CInt(rsMain("Id").Value)
        sSql = "Select dbo.emGetEmployeeName(" & Convert.ToString(nEmployeeId) & ") vcEmployeeName From EM_Employee Where Id = " & nEmployeeId
        rsEmployeeName.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
        If rsEmployeeName.RecordCount > 0 Then
            txtEmployeeName.Text = Convert.ToString(rsEmployeeName("vcEmployeeName").Value)
            txtEmployeeName.Tag = txtEmployeeName.Text
        End If
        rsEmployeeName.Close()
        FillGrid()
        FillAudit()

        Me.Refresh()
        bDisplaying = False
    End Sub

    Private Sub FillGrid()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString =  "Dsn=ERP;uid=sa"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "Select a.Id, CASE WHEN DegreeDiplomaId <> 0 THEN (Select Description From HR_PRMParameters Where Type = 8 And Id = a.DegreeDiplomaId) " &
                             "ELSE OtherDiploma END Degree, CASE WHEN InstitutionId <> 0 THEN (Select Description From HR_PRMParameters Where Type = 9 And Id = a.InstitutionId) " &
                             "ELSE OtherInstitute END Institution, a.SessionYearFrom, a.SessionYearTo From HR_EmployeeQualifications a Where EmployeeId = " & nEmployeeId

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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        frmEmployeeSearch.sCalledForm = "Employee Qualifications"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim nNewQualificationtId As Integer

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
        'If Not ValidateFields(a_nActionID, sAction) Then Exit Sub

        'Try
        bProcessing = True
        conn.BeginTrans()

        If (nQualificationId = Nothing) Or (nQualificationId = 0) Then
            sSql = "Select MAX(Id) As Id From HR_EmployeeQualifications Where EmployeeId = " & nEmployeeId
            GetRecordSet(rsMisc, sSql)
            nNewQualificationtId = CInt(rsMisc("Id").Value)
            nNewQualificationtId += 1

            sSql = "Insert INTO HR_EmployeeQualifications (Id, EmployeeId, DegreeDiplomaId, OtherDiploma, Majors, GradeObtained, " &
                        "InstitutionId, OtherInstitute, SessionYearFrom, SessionYearTo, IsAcademic, CountryId, CityId, ExtraActivities, " &
                        "AcademicDistinctions) Values(" & nNewQualificationtId & ", " & nEmployeeId & ", " & IIf(cbDegreeDiploma.SelectedIndex < 0, 0, cbDegreeDiploma.SelectedValue) &
                        ", '" & txtOtherDegree.Text & "', '" & txtMajors.Text & "', '" & txtGradeGPA.Text & "', " & IIf(cbInstitution.SelectedIndex < 0, 0, cbInstitution.SelectedValue) &
                        ", '" & txtOtherInstitution.Text & "', " & txtStartYear.Text & ", " & txtEndYear.Text &
                        ", " & IIf(radAcademic.Checked, 0, 1) & ", " & cbCountry.SelectedValue & ", " & cbCity.SelectedValue &
                        ", '" & txtExtraCurricular.Text & "', '" & txtDistinctions.Text & "')"
            conn.Execute(sSql)
        Else
            sSql = "Update HR_EmployeeQualifications Set DegreeDiplomaId = " & IIf(cbDegreeDiploma.SelectedIndex < 0, 0, cbDegreeDiploma.SelectedValue) & ", OtherDiploma = '" & txtOtherDegree.Text &
                   "', Majors = '" & txtMajors.Text & "', GradeObtained = '" & txtGradeGPA.Text & "', InstitutionId = " & IIf(cbInstitution.SelectedIndex < 0, 0, cbInstitution.SelectedValue) &
                   ", OtherInstitute = '" & txtOtherInstitution.Text & "', SessionYearFrom = " & txtStartYear.Text &
                   ", SessionYearTo = " & txtEndYear.Text & ", IsAcademic = " & IIf(radAcademic.Checked, 0, 1) &
                   ", CountryId = " & cbCountry.SelectedValue & ", CityId = " & cbCity.SelectedValue &
                   ", ExtraActivities = '" & txtExtraCurricular.Text & "', AcademicDistinctions = '" & txtDistinctions.Text &
                   "' Where Id = " & nQualificationId & " And EmployeeId = " & nEmployeeId
            conn.Execute(sSql)
        End If

        ' sSql = "Insert Into EM_Employee_Audit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
        'Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', 'MIS', 'Updated employee professional experience.', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
        ' conn.Execute(sSql)

        conn.CommitTrans()
        'Catch ex As Exception
        '    MessageBox.Show("Error saving record.")
        'End Try

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        conn.Close()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nQualificationId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this qualification?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeeQualifications Where Id = " & nQualificationId & " And EmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        'sSql = "Delete From EM_Employee_Audit Where vcDocumentId = '" & Trim(txtEmpID.Text) & "'"
        'conn.Execute(sSql)

        If nEmployeeId <> Nothing Then
            sSql = "Select * From EM_Employee Where Id = " & nEmployeeId
            If rsMain.State = 1 Then rsMain.Close()
            rsMain.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        End If

        Display()
        conn.Close()
        MsgBox("Qualification deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString =  "Dsn=ERP;uid=sa"
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcWorkStation, vcActionRemarks From EM_Employee_Audit Where vcDocumentId = '" + Convert.ToString(nEmployeeId) + "'"

        adapter.SelectCommand = New Odbc.OdbcCommand(sSql, connODBC)
        Try
            adapter.Fill(ds)
            grdAudit.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error loading Audit.")
        End Try
        connODBC.Close()
    End Sub

    Private Function ValidateFields(ByVal a_nActionID As Integer, r_sAction As String) As Boolean
        'Dim rsMisc As New ADODB.Recordset

        'ValidateFields = False

        'If Trim(txtEmployeeName.Text) = "" Then
        '    MsgBox("Please select employee.", vbCritical)
        '    Exit Function
        'End If

        'If txtDependentName.Text = "" Then
        '    MsgBox("Please enter dependent name.", vbCritical)
        '    txtDependentName.Focus()
        '    Exit Function
        'End If

        'If cbMaritalStatus.SelectedIndex < 0 Then
        '    MsgBox("Please select marital status.", vbCritical)
        '    cbMaritalStatus.Focus()
        '    Exit Function
        'End If

        'If cbRelation.SelectedIndex < 0 Then
        '    MsgBox("Please select relation.", vbCritical)
        '    cbRelation.Focus()
        '    Exit Function
        'End If

        'If cbGender.SelectedIndex < 0 Then
        '    MsgBox("Please select gender.", vbCritical)
        '    cbGender.Focus()
        '    Exit Function
        'End If

        'ValidateFields = True
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub grdQualifications_DoubleClick(sender As Object, e As EventArgs) Handles grdQualifications.DoubleClick
        Dim rsMisc As New ADODB.Recordset
        Dim sSql As String

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Select * From HR_EmployeeQualifications Where Id = " & Convert.ToString(grdQualifications.Columns(0).Value) & " And EmployeeId = " & nEmployeeId

        rsMisc.Open(sSql, conn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        nQualificationId = CInt(rsMisc("Id").Value)
        cbDegreeDiploma.SelectedValue = CInt(rsMisc("DegreeDiplomaId").Value)
        cbDegreeDiploma.Tag = cbDegreeDiploma.SelectedValue

        If Not IsDBNull(rsMisc("OtherDiploma").Value) Then
            txtOtherDegree.Text = Convert.ToString(rsMisc("OtherDiploma").Value)
            txtOtherDegree.Tag = txtOtherDegree.Text
        End If

        If Not IsDBNull(rsMisc("Majors").Value) Then
            txtMajors.Text = Convert.ToString(rsMisc("Majors").Value)
            txtMajors.Tag = txtMajors.Text
        End If

        If Not IsDBNull(rsMisc("GradeObtained").Value) Then
            txtGradeGPA.Text = Convert.ToString(rsMisc("GradeObtained").Value)
            txtGradeGPA.Tag = txtGradeGPA.Text
        End If

        cbInstitution.SelectedValue = CInt(rsMisc("InstitutionId").Value)
        cbInstitution.Tag = cbInstitution.SelectedValue

        If Not IsDBNull(rsMisc("OtherInstitute").Value) Then
            txtOtherInstitution.Text = Convert.ToString(rsMisc("OtherInstitute").Value)
            txtOtherInstitution.Tag = txtOtherInstitution.Text
        End If

        If Not IsDBNull(rsMisc("SessionYearFrom").Value) Then
            txtStartYear.Text = Convert.ToString(rsMisc("SessionYearFrom").Value)
            txtStartYear.Tag = txtStartYear.Text
        End If

        If Not IsDBNull(rsMisc("SessionYearTo").Value) Then
            txtEndYear.Text = Convert.ToString(rsMisc("SessionYearTo").Value)
            txtEndYear.Tag = txtEndYear.Text
        End If

        If CInt(rsMisc("IsAcademic").Value) = 0 Then
            radAcademic.Checked = True
            radAcademic.Tag = radAcademic.Checked
        Else
            radProfessional.Checked = True
            radAcademic.Tag = radAcademic.Checked
        End If

        cbCountry.SelectedValue = CInt(rsMisc("CountryId").Value)
        cbCountry.Tag = cbCountry.SelectedValue

        cbCity.SelectedValue = CInt(rsMisc("CityId").Value)
        cbCity.Tag = cbCity.SelectedValue

        If Not IsDBNull(rsMisc("ExtraActivities").Value) Then
            txtExtraCurricular.Text = Convert.ToString(rsMisc("ExtraActivities").Value)
            txtExtraCurricular.Tag = txtExtraCurricular.Text
        End If

        If Not IsDBNull(rsMisc("AcademicDistinctions").Value) Then
            txtDistinctions.Text = Convert.ToString(rsMisc("AcademicDistinctions").Value)
            txtDistinctions.Tag = txtDistinctions.Text
        End If
    End Sub

    Private Sub tlbToolbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tlbToolbar.ItemClicked

    End Sub
End Class

