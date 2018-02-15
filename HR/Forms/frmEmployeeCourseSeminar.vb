Public Class frmEmployeeCourseSeminar
    Dim nEmployeeId As Integer = Nothing
    Dim nSeminarId As Integer = Nothing
    Dim rsMain As ADODB.Recordset
    Dim nStatus As Integer
    Dim sAction As String
    Public bProcessing As Boolean
    Dim bDisplaying As Boolean

    Private Sub frmEmployeeCourseSeminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMdiMain

        rsMain = New ADODB.Recordset
        rsMain.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        PopulateControl(cbCountry, "Select Id, Description From HR_PRMParameters Where Type = 1 Order by Description", "Id", "Description")

        Clear()
    End Sub

    Private Sub cbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCountry.SelectedIndexChanged
        PopulateControl(cbCity, "Select Id, Description From HR_PRMCity Where CountryId = " & IIf(IsNothing(cbCountry.SelectedValue), 969, cbCountry.SelectedValue).ToString() & " Order by Description", "Id", "Description")
    End Sub

    Private Sub Clear()
        nEmployeeId = Nothing
        nSeminarId = Nothing
        txtEmployeeName.Text = ""
        txtEmployeeName.Tag = ""
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
        'slStatus.Text = "New Record"
    End Sub

    Private Sub Display()
        Clear()
        Try
            If rsMain.RecordCount = 0 Then Exit Sub
            If rsMain.EOF Then Exit Sub
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

            bDisplaying = True

            nEmployeeId = CInt(rsMain("Id").Value)
            txtEmployeeName.Text = Convert.ToString(rsMain("FullName").Value)
            txtEmployeeName.Tag = txtEmployeeName.Text
            FillGrid()
            FillAudit()

            Me.Refresh()
            bDisplaying = False

        Catch ex As Exception
            MessageBox.Show("Error displaying record: " + ex.Message)
        End Try

    End Sub

    Private Sub FillGrid()
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
        frmEmployeeSearch.sCalledForm = "Employee Training/Course/Seminar"
        frmEmployeeSearch.Show()
        frmEmployeeSearch.Focus()
    End Sub

    Private Sub grdAwards_DoubleClick(sender As Object, e As EventArgs) Handles grdSeminars.DoubleClick
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

    Private Sub Save(Optional a_nActionID As Integer = 0)
        Dim sSql As String
        Dim rsMisc As New ADODB.Recordset
        Try
            If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)
            If Not ValidateFields(a_nActionID, sAction) Then Exit Sub


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

            sSql = "Insert Into EM_EmployeeTrainingCSAudit (vcDocumentId, dtmActionDate, vcAction, vcUserId, vcActionRemarks, vcIP, vcWorkStation) Values ('" &
            Convert.ToString(nEmployeeId) & "', Convert(Datetime,'" & DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") & "'), '" & sAction & "', '" & sUserId & "', '', '', '')" '" & g_sUserId & "', '" & sActionRemarks & "', '" & frmMdiMain.GetIPAddress & "', '" & frmMdiMain.GetComputerName & "')"
            conn.Execute(sSql)

        Catch ex As Exception
            MessageBox.Show("Error saving record." + ex.Message)
        End Try

        Display()

        bProcessing = False
    End Sub

    Private Sub Delete()
        Dim sSql As String

        If Trim(txtEmployeeName.Text) = "" Then Exit Sub
        If nSeminarId = Nothing Then Exit Sub

        If MsgBox("Do you want to Delete this record?", vbYesNo) = vbNo Then Exit Sub

        If (conn.State <> ConnectionState.Open) Then conn.Open(sConnectionString)

        sSql = "Delete From EM_EmployeeTrainingCS Where nId = " & nSeminarId & " and nEmployeeId = " & nEmployeeId
        conn.Execute(sSql)
        sSql = "Delete From EM_EmployeeTrainingCSAudit Where vcDocumentId = '" & Convert.ToString(nEmployeeId) & "'"
        conn.Execute(sSql)

        Display()
        MsgBox("Record deleted successfully.", vbInformation)
    End Sub

    Private Sub FillAudit()
        Dim connODBC As New Odbc.OdbcConnection
        connODBC.ConnectionString = sConnectionString
        connODBC.Open()

        Dim ds As DataSet = New DataSet
        Dim adapter As New Odbc.OdbcDataAdapter
        Dim sSql As String = "SELECT vcAction, dtmActionDate, vcUserId, vcWorkStation, vcActionRemarks From EM_EmployeeTrainingCSAudit Where vcDocumentId = '" + Convert.ToString(nEmployeeId) + "'"

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
        Dim rsMisc As New ADODB.Recordset

        ValidateFields = False

        If Trim(txtEmployeeName.Text) = "" Then
            MsgBox("Please select employee.", vbCritical)
            Exit Function
        End If

        If cbType.SelectedIndex = -1 Then
            MsgBox("Please select type.", vbCritical)
            cbType.Focus()
            Exit Function
        End If

        If txtTitle.Text = "" Then
            MsgBox("Please enter course/seminar name.", vbCritical)
            txtTitle.Focus()
            Exit Function
        End If

        If dtpStartDate.Checked = False Then
            MsgBox("Please select start date.", vbCritical)
            dtpStartDate.Focus()
            Exit Function
        End If

        If dtpEndDate.Checked = False Then
            MsgBox("Please select end date.", vbCritical)
            dtpEndDate.Focus()
            Exit Function
        End If

        If cbCountry.SelectedIndex = -1 Then
            MsgBox("Please select country.", vbCritical)
            cbCountry.Focus()
            Exit Function
        End If

        If cbCity.SelectedIndex = -1 Then
            MsgBox("Please select city.", vbCritical)
            cbCity.Focus()
            Exit Function
        End If

        If nSeminarId = 0 Then
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

    Private Function IsAnyFieldChanged() As Boolean
        IsAnyFieldChanged = (nEmployeeId = 0) Or (nSeminarId = 0) Or (Trim(txtTitle.Text) <> Trim(txtTitle.Tag)) Or
                                (dtpStartDate.Value <> dtpStartDate.Tag) Or (Trim(txtDescription.Text) <> Trim(txtDescription.Tag)) Or
                                (dtpEndDate.Value <> dtpEndDate.Tag) Or (cbType.SelectedIndex <> cbType.Tag) Or (cbCountry.SelectedIndex <> cbCountry.Tag) Or
                                (cbCity.SelectedIndex <> cbCity.Tag) Or (Trim(txtCost.Text) <> Trim(txtCost.Tag))
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ((nEmployeeId = 0) Or IsAnyFieldChanged()) Then Exit Sub
        Call Save()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

End Class
