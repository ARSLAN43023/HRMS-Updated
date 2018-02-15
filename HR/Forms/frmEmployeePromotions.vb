Imports C1.Win.C1TrueDBGrid

Public Class frmEmployeePromotions
    Dim nEmployeeId As Integer = Nothing
    Dim nPromotionId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeePromotions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain
        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        PopulateControls()
        Clear()
    End Sub

    Private Sub PopulateControls()
        PopulateControl(cbFromType, "Select Id, Description From HR_PRMParameters Where Type = 3 Order by Description", "Id", "Description")
        PopulateControl(cbToType, "Select Id, Description From HR_PRMParameters Where Type = 3 Order by Description", "Id", "Description")
        PopulateControl(cbFromDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbToDesignation, "Select Id, Description From HR_PRMParameters Where Type = 5 Order by Description", "Id", "Description")
        PopulateControl(cbFromGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")
        PopulateControl(cbToGrade, "Select Id, Description From HR_PRMGrades Order by Description", "Id", "Description")

    End Sub

    Private Sub Clear()
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

        FillGrid()
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

            nEmployeeId = CInt(rsMain("Id").Value)
            sSql = "Select dbo.emGetEmployeeName(" & Convert.ToString(nEmployeeId) & ") vcEmployeeName, EmployeeTypeId, DesignationId, EmployeeGradeId From EM_Employee Where Id = " & nEmployeeId
            rsEmployeeName.Open(sSql, conn, ADODB.CursorLocationEnum.adUseClient, ADODB.LockTypeEnum.adLockOptimistic)
            If rsEmployeeName.RecordCount > 0 Then
                txtEmployeeName.Text = Convert.ToString(rsEmployeeName("vcEmployeeName").Value)
                txtEmployeeName.Tag = txtEmployeeName.Text
                cbFromType.SelectedValue = CInt(rsMain("EmployeeTypeId").Value)
                cbFromType.Tag = cbFromType.SelectedValue
                cbFromDesignation.SelectedValue = CInt(rsMain("DesignationId").Value)
                cbFromDesignation.Tag = cbFromDesignation.SelectedValue
                cbFromGrade.SelectedValue = CInt(rsMain("EmployeeGradeId").Value)
                cbFromGrade.Tag = cbFromGrade.SelectedValue
                FillGrid()
            End If

            rsEmployeeName.Close()
            'FillAudit()

            Me.Refresh()
            bDisplaying = False
        Catch ex As Exception
            MessageBox.Show("Error displaying record: " + ex.Message)
        End Try

    End Sub

    Private Sub FillGrid()
        Try
            Dim connODBC As New Odbc.OdbcConnection
            connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
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
        frmEmployeeSearch.sCalledForm = "Employee Promotions"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Dim sEffectiveDate As String
        Try
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

            sSql = "Insert Into HR_EmployeePromotionsAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Convert.ToString(nPromotionId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record." & ex.Message)
        End Try

        Display()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nPromotionId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this promition?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From HR_EmployeePromotions Where Id = " & nPromotionId
        conn.Execute(sSql)
        sSql = "Delete From HR_EmployeePromotionsAudit Where vcDocumentId = '" & Convert.ToString(nPromotionId) & "'"
        conn.Execute(sSql)

        Display()
        MsgBox("Promotion deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = "Dsn=ERP;uid=sa;pwd=123456"
        connODBC.Open()
        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcActionRemarks From HR_EmployeePromotionsAudit Where vcDocumentId = '" + Convert.ToString(nPromotionId) + "' Order by dtmActionDate"

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
        'Dim rsMisc As New ADODB.Recordset
        'Dim sSql As String

        ValidateFields = False

        'If nPromotionId <> 0 Then
        '    sSql = "Select nsStatusId From HR_EmployeePromotions Where nWarningId = " & nWarningId
        '    GetRecordSet(rsMisc, sSql)

        '    If rsMisc.RecordCount > 0 Then nStatus = CInt(rsMisc("nsStatusId").Value)
        '    rsMisc.Close()
        'End If

        'If nStatus = 3 Then
        '    MsgBox("Invalid Action.", vbCritical)
        '    Exit Function
        'End If

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If nPromotionId = 0 Then
            sAction = "Prepared"
            nStatus = 1
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 0 Then 'Modify
            sAction = "Modified"
            nStatus = 1
            '            nStatus = CInt(rsMain("nsStatusId").Value)
            slStatus.Text = "Pending"
        ElseIf a_nActionID = 3 Then
            sAction = "Approved"
            nStatus = 3
            slStatus.Text = "Approved"
        End If

        ValidateFields = True
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

    Private Sub grdQualifications_DoubleClick(sender As Object, e As EventArgs) Handles grdPromotions.DoubleClick
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

    Private Sub frmEmployeePromotions_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If (conn.State = ConnectionState.Open) Then conn.Close()
    End Sub

End Class